'---------------------------------------------------------------------------------------
'frmDialog_MRAM.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_MRAM

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------

'File name of data file including full path
'Note the lexicon is intended to avoid confusion about read/write file versus MRAM
Private SaveFileName As String = "example.bin"  'For reading MRAM
Private BurnFileName As String = "example.bin"  'For writing MRAM

'Memory command definitions 
'These are substantially the same as commands for flash memory of the same type
'but the performance is quite a bit different in a few places for MRAM
'Note there is no erase command or ready status bit as there are no write restrictions or delays with MRAM
Private Const MRAM_CMD_WREN As Byte = &H6&    'Write enable
Private Const MRAM_CMD_WRDI As Byte = &H4&    'Write disable
Private Const MRAM_CMD_RDSR As Byte = &H5&    'Read status register
Private Const MRAM_CMD_WRSR As Byte = &H1&    'Write status register
Private Const MRAM_CMD_READ As Byte = &H3&    'Read data bytes
Private Const MRAM_CMD_WRITE As Byte = &H2&   'Write data bytes
Private Const MRAM_CMD_SLEEP As Byte = &HB9&  'Enter sleep mode
Private Const MRAM_CMD_WAKE As Byte = &HAB&   'Exit sleep mode

'Size of our MRAM device
Private Const MRAM_SIZE As UInt32 = 131072

'Max transfer size is how many bytes at a time we read or write
'This is driven by the hardware and software structure of the BackHauler PMOD
Private Const MRAM_MAX_TRANSFER_SIZE As UInt32 = 32

'Browse line size is how many bytes to show in a line of the browse window
'This must be less than or equal the max transfer size
Private Const MRAM_BROWSE_LINE_SIZE As UInt32 = 16

'Buffer for data transactions with the MRAM device
Private MRAM_DataBuffer(MRAM_MAX_TRANSFER_SIZE) As Byte

'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------

Private Sub frmDialog_MRAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_0)
 'The remaining I/O are passive until we set the drives  
 'Be sure to drive WP and HOLD high in case the jumpers are moved to that position
 BHPMOD_SetPinState(7, 1)
 BHPMOD_SetPinState(8, 1)
 BHPMOD_SetPinDrive(7, 1)
 BHPMOD_SetPinDrive(8, 1)
 Form1.CheckBox_PP_PIN7.Checked = True
 Form1.CheckBox_PP_PIN8.Checked = True
 'Set for write disable in order to also wake up and unprotect the device
 'This assumes the device is plugged in, but the same call is also used before later accesses
 MRAM_WriteEnable(False)
 'Construct an initial browse window
 MRAM_Browse(0)
End Sub

Private Sub frmDialog_MRAM_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------

'MRAM_WriteEnable toggles the condition of the write enables and protection
'This code is intended to leave the memory unprotected but allow callers to enable 
'writes only when needed to write the memory
'The caller or hardware must have set WP and HOLD pins high for this to work
'Note that for MRAM there are no write delays required
Private Sub MRAM_WriteEnable(ByVal NewEnableState As Boolean)
 Dim buf(2) As Byte

 'Bring the device out of sleep mode in case it is sleeping
 'This code leaves the device awake as there are no power considerations here
 buf(0) = MRAM_CMD_WAKE
 BHPMOD_SPI_Transaction(1, buf(0))

 'In all cases, enable the memory write and remove any protection
 buf(0) = MRAM_CMD_WREN
 BHPMOD_SPI_Transaction(1, buf(0))
 buf(0) = MRAM_CMD_WRSR
 buf(1) = 2   'Keep WEL high, all others low
 BHPMOD_SPI_Transaction(2, buf(0))
 buf(0) = MRAM_CMD_WRSR
 buf(1) = 2   'Keep WEL high, all others low - second run in case WRSR was active
 BHPMOD_SPI_Transaction(2, buf(0))

 'If we were intending to enable write, stop here as its done
 If (NewEnableState) Then Exit Sub

 'If we were intending to disable write, disable the global write here
 buf(0) = MRAM_CMD_WRDI
 BHPMOD_SPI_Transaction(1, buf(0))
End Sub

'MRAM_ReadToDataBuffer reads MRAM_MAX_TRANSFER_SIZE bytes of data to the global data buffer starting at the specified address.
'Note that if the address is less than MRAM_MAX_TRANSFER_SIZE bytes from the end of memory, the transaction will
'roll to the beginning of memory.  The address is not checked here for significant digits and address bits above 
'the memory address size are just ignored by the code and/or the device.  If fewer bytes are desired, the caller 
'just takes what is needed from the global array.  To save transactions, this routine does not toggle the enables 
'and that should be done by the caller.
Private Sub MRAM_ReadToDataBuffer(ByVal Address As UInt32)
 Dim buf(MRAM_MAX_TRANSFER_SIZE + 8) As Byte

 'Construct the command
 buf(0) = MRAM_CMD_READ
 SplitAddress(Address, buf(1), buf(2), buf(3))

 'Perform the read
 BHPMOD_SPI_Transaction((4 + MRAM_MAX_TRANSFER_SIZE), buf(0))

 'Return the data to the global array
 Array.Copy(buf, 4, MRAM_DataBuffer, 0, MRAM_MAX_TRANSFER_SIZE)

End Sub

'MRAM_WriteFromDataBuffer writes a specified count of bytes of data from the global data buffer starting at the specified address.
'Note that if the address is less than count bytes from the end of MRAM, the transaction will roll to the beginning of MRAM.  
'The address is not checked here for significant digits and address bits above the memory address size are just ignored by the code and/or the device.
'Count must be less than or equal MRAM_MAX_TRANSFER_SIZE and the code will simply limit there.
'To save transactions, this routine does not toggle the enables and that should be done by the caller.
Private Sub MRAM_WriteFromDataBuffer(ByVal Address As UInt32, ByVal Count As UInt32)
 Dim buf(MRAM_MAX_TRANSFER_SIZE + 8) As Byte

 'Constrain argument
 If (Count > MRAM_MAX_TRANSFER_SIZE) Then Count = MRAM_MAX_TRANSFER_SIZE
 If (Count = 0) Then Exit Sub

 'Construct the command
 buf(0) = MRAM_CMD_WRITE
 SplitAddress(Address, buf(1), buf(2), buf(3))

 'Get the data to write from the global buffer
 Array.Copy(MRAM_DataBuffer, 0, buf, 4, Count)

 'Perform the write
 BHPMOD_SPI_Transaction((4 + Count), buf(0))

End Sub

'MRAM_Browse constructs and displays the browse window contents starting at the address provided
'To simplify matters, browse lines collect and print a specified number of bytes at a time, even though
'each read generally reads more than the bytes presented on that one line.  This is not a speed issue 
'because the browse window is manual, so we accept the overlap and duplication of effort in order to 
'keep the definitions abstract.  
Private Sub MRAM_Browse(ByVal StartAddress As UInt32)
 Dim address As UInt32 = StartAddress
 Dim a2 As Byte, a1 As Byte, a0 As Byte
 Dim i As UInt32
 Dim hexdumpline As String

 'Clear the browse window text string 
 'This may or may not show as a short blip on some machines, but should not while we are hogging the assigned processor here
 MRAM_BrowseWindow.Text = ""

 'Set to be sure we can read
 MRAM_WriteEnable(False)

 'Repeat until the address is 256 bytes ahead of the start address (the count of bytes in a browse window)
 Do
  'Get data
  MRAM_ReadToDataBuffer(address)
  'Print the line of data
  SplitAddress(address, a2, a1, a0)
  hexdumpline = " " + LngToHexByte(a2) + LngToHexByte(a1) + LngToHexByte(a0) + "   "
  For i = 0 To MRAM_BROWSE_LINE_SIZE - 1
   hexdumpline += LngToHexByte(MRAM_DataBuffer(i)) + " "
  Next i
  hexdumpline += "  "
  For i = 0 To MRAM_BROWSE_LINE_SIZE - 1
   If ((MRAM_DataBuffer(i) < &H20&) Or (MRAM_DataBuffer(i) > &H7E&)) Then
    hexdumpline += "."
   Else
    hexdumpline += Convert.ToChar(MRAM_DataBuffer(i))
   End If
  Next i
  hexdumpline += vbCrLf
  'Add the line to the browse window
  MRAM_BrowseWindow.Text += hexdumpline
  'Set the address for the next line
  address += MRAM_BROWSE_LINE_SIZE
 Loop Until (address >= StartAddress + 256)

End Sub

'MRAM_BrowseReset resets the global browse address and calls for a browse 
Private Sub MRAM_BrowseReset()

 'If the scroll bar is already at 0, just browse again
 If (MRAM_BrowseScrollBar.Value = 0) Then
  MRAM_Browse(0)
  Exit Sub
 End If

 'If we need to set the scroll bar to 0, this action will cause the above normally
 'We just don't want to cause it happen more than once for no reason, even if it probably won't be noticed
 MRAM_BrowseScrollBar.Value = 0
 Application.DoEvents()

End Sub

'SplitAdddress returns a set of 3 bytes representing the address.
'The bytes are masked so that only valid bits can be set and only valid bytes returned
'based on an arbitrary incoming address.  This effect is set for the device we are using
'and further enforces the argument precondition for routines that accept an address.
'The values are returned in discrete arguments so they can easily be used in 
'arbitrary ways.  They are considered MSB first in Byte2 ... Byte0, for 17 valid bits.
Private Sub SplitAddress(ByVal Address As UInt32, ByRef Byte2 As Byte, ByRef Byte1 As Byte, ByRef Byte0 As Byte)
 Dim address_bytes() As Byte = BitConverter.GetBytes(Address)

 'Sort out bytes based on actual endian order of this machine
 If (BitConverter.IsLittleEndian) Then
  Byte2 = address_bytes(2) And 1
  Byte1 = address_bytes(1)
  Byte0 = address_bytes(0)
 Else
  Byte2 = address_bytes(1) And 1
  Byte1 = address_bytes(2)
  Byte0 = address_bytes(3)
 End If

End Sub

'User controls and cursor state are toggled during certain operations
'Some machines and machine states make it hard to get the wait cursor to start in a loop routine
'The wait cursor also will not start properly if the user cursor is off the dialog at the time wait is suppose to start
'So DoEvents needs to be run regularly to keep the GUI responsive in this sense, also requiring that user controls be disabled
Private Sub MRAM_UserControlEnable(ByVal EnableState As Boolean)

 'Set the cursor to show wait while the user is not in control
 If (EnableState) Then
  Me.Cursor = Cursors.Default
 Else
  Me.Cursor = Cursors.WaitCursor
 End If

 'Toggle controls states
 Button_Erase_MRAM.Enabled = EnableState
 Button_Save_MRAM_To_File.Enabled = EnableState
 Button_Write_File_To_MRAM.Enabled = EnableState

 'Help the new states take effect
 'If the cursor is known to be in the dialog, then this is all that is required
 'But it is still helpful to repeat this regularly so that window moves and so on are still responsive
 Application.DoEvents()

End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

Private Sub Button_Erase_Click(sender As Object, e As EventArgs) Handles Button_Erase_MRAM.Click
 Dim address As UInteger
 Dim i As Byte

 'Fill the buffer with all 1's 
 'This default state for data mirrors the behavior of flash, but it is just fill for MRAM
 For i = 0 To MRAM_MAX_TRANSFER_SIZE
  MRAM_DataBuffer(i) = &HFF&
 Next i

 'Set for write
 MRAM_WriteEnable(True)

 'Show that patient waiting is required
 MRAM_UserControlEnable(False)

 'For all addresses, 32-bytes at a time, write the all zeros array
 'Note that unlike flash Everspin says the default condition for MRAM is zero
 For address = 0 To (MRAM_SIZE - MRAM_MAX_TRANSFER_SIZE) Step MRAM_MAX_TRANSFER_SIZE
  MRAM_WriteFromDataBuffer(address, MRAM_MAX_TRANSFER_SIZE)
  Application.DoEvents()
 Next address

 'Disable writes
 MRAM_WriteEnable(False)

 'Reload the browse window from the beginning
 MRAM_BrowseReset()

 'Restore control
 MRAM_UserControlEnable(True)

End Sub

Private Sub Button_Save_MRAM_To_File_Click(sender As Object, e As EventArgs) Handles Button_Save_MRAM_To_File.Click
 Dim address As UInteger
 Dim savefile As System.IO.FileStream

 'On any of the huge number of possible errors, do closeout and leave
 On Error GoTo BSMTFC_ERR

 'Complete the file dialog
 'Filters and other sticky defaults are set in the properties and/or part of the dialog object function
 'Clear the filename to reduce overwites and conclusions
 MRAM_SaveFileDialog.FileName = ""
 If (MRAM_SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel) Then Exit Sub
 Application.DoEvents()
 SaveFileName = MRAM_SaveFileDialog.FileName

 'Attempt to create the file, overwriting any existing file
 savefile = IO.File.Open(SaveFileName, IO.FileMode.Create)

 'Show that patient waiting is required
 MRAM_UserControlEnable(False)

 'Set for read
 MRAM_WriteEnable(False)

 'Read all bytes in the MRAM and write them to the file
 'First access overwrites file, remaining accesses append
 For address = 0 To (MRAM_SIZE - MRAM_MAX_TRANSFER_SIZE) Step MRAM_MAX_TRANSFER_SIZE
  'Read a block
  MRAM_ReadToDataBuffer(address)
  'Attempt to write the block to the file
  savefile.Write(MRAM_DataBuffer, 0, MRAM_MAX_TRANSFER_SIZE)
  Application.DoEvents()
 Next address

 'Close the file
 savefile.Close()

 'Reload the browse window from the beginning
 MRAM_BrowseReset()

 'Restore control
 MRAM_UserControlEnable(True)

 'Normal exit
 Exit Sub

BSMTFC_ERR:
 'Closeout and report errors
 If (Not IsNothing(savefile)) Then savefile.Close()
 MRAM_BrowseReset()
 Me.Cursor = Cursors.Default
 MRAM_UserControlEnable(True)
 MsgBox("The system reported a problem using the file " + vbCrLf + SaveFileName, vbExclamation, "File Error")

End Sub

Private Sub Button_Write_File_To_MRAM_Click(sender As Object, e As EventArgs) Handles Button_Write_File_To_MRAM.Click
 Dim address As UInteger
 Dim burnfile As System.IO.FileStream
 Dim burnfilereadcount As Integer
 Dim endoffile As Boolean = False

 'On any of the huge number of possible errors, do closeout and leave
 On Error GoTo BBMFFC_ERR

 'Complete the file dialog
 'Filters and other sticky defaults are set in the properties and/or part of the dialog object function
 'Clear the filename to reduce overwrites and conclusions
 MRAM_OpenFileDialog.FileName = ""
 If (MRAM_OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel) Then Exit Sub
 Application.DoEvents()
 BurnFileName = MRAM_OpenFileDialog.FileName

 'Attempt to open the file
 burnfile = IO.File.Open(BurnFileName, IO.FileMode.Open)

 'Show that patient waiting is required
 MRAM_UserControlEnable(False)

 'Enable writes
 MRAM_WriteEnable(True)

 'Read bytes from file and write them to MRAM from the beginning until the MRAM or the file ends 
 address = 0
 Do
  'Attempt to read a full block from the file
  burnfilereadcount = burnfile.Read(MRAM_DataBuffer, 0, MRAM_MAX_TRANSFER_SIZE)
  'See what we got
  If (burnfilereadcount <= 0) Then
   'If we got zero back or a normal error, such as EOF, this must be the end of the file
   endoffile = True
  Else
   'Otherwise write the number of bytes we actually got
   MRAM_WriteFromDataBuffer(address, burnfilereadcount)
   'If it's not a full block, this must be the end of the file
   If (burnfilereadcount <> MRAM_MAX_TRANSFER_SIZE) Then endoffile = True
   'Increment the address we are interested in by at the count we last wrote
   'This will generally be MRAM_MAX_TRANSFER_SIZE unless the file has already ended, but prevent unexpected large numbers
   If (burnfilereadcount > MRAM_MAX_TRANSFER_SIZE) Then burnfilereadcount = MRAM_MAX_TRANSFER_SIZE
   'This gives an opportunity to see the end of MRAM and describe it as endoffile
   address += burnfilereadcount
   If (address >= MRAM_SIZE) Then endoffile = True
  End If
  Application.DoEvents()
 Loop Until endoffile

 'Close the file
 burnfile.Close()

 'Disable writes
 MRAM_WriteEnable(False)

 'Reload the browse window from the beginning
 MRAM_BrowseReset()

 'Restore control
 MRAM_UserControlEnable(True)

 'Normal exit
 Exit Sub

BBMFFC_ERR:
 'Closeout and report errors
 If (Not IsNothing(burnfile)) Then burnfile.Close()
 MRAM_WriteEnable(False)
 MRAM_BrowseReset()
 MRAM_UserControlEnable(True)
 MsgBox("The system reported a problem using the file " + vbCrLf + BurnFileName, vbExclamation, "File Error")

End Sub

Private Sub MRAM_BrowseScrollBar_ValueChanged(sender As Object, e As EventArgs) Handles MRAM_BrowseScrollBar.ValueChanged
 Dim browse_address As UInt32

 'Use value changed event to avoid extra events on click
 'This will cause an event if the value is changed programatically as well (generally to 0)
 'Note that the highest value actually retrievable from this scroll bare is the maximum value less the large change

 'It is possible to hold the slider and get a number not on a small change boundary, so we need additional means to be sure
 'that the browse lines start at even increments of the line size
 browse_address = MRAM_BrowseScrollBar.Value
 browse_address -= (browse_address Mod MRAM_BROWSE_LINE_SIZE)

 'Write the browse window from the determined address
 MRAM_Browse(browse_address)

End Sub
 
End Class