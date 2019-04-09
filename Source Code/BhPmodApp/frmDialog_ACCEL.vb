'---------------------------------------------------------------------------------------
'frmDialog_ACCEL.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_ACCEL

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------

Private Sub frmDialog_ACCEL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 'This device seems to prefer the clock to idle high, though other evidence suggests it might not matter
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_3)
 'Start looking for sensor data
 AccelPollTimer.Enabled = True
End Sub

Private Sub frmDialog_ACCEL_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 AccelPollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------

'Generalized register write routine for our device
'Note that in most places we use absolute numbers for the arguments - while not really good
'coding practice, this code is small and numbers help to follow along with a datasheet in this demonstration
'By using the register address alone, the R/W bit (MSB) is always low (write)
'The next MSB (bit 6) controls 1 = auto inc address, 0 = do not increment, and with only one byte to write we don't care
Private Sub WriteDeviceRegister(ByVal RegAddr As Byte, ByVal RegVal As Byte)
 Dim buf(2) As Byte
 buf(0) = RegAddr
 buf(1) = RegVal
 BHPMOD_SPI_Transaction(2, buf(0))
End Sub

'Generalized register read routine for our device
'This is the dual of write, and sets the R/W bit high
'The value read is returned by reference
Private Sub ReadDeviceRegister(ByVal RegAddr As Byte, ByRef RegVal As Byte)
 Dim buf(2) As Byte
 buf(0) = RegAddr Or &H80&
 buf(1) = &HFF&
 BHPMOD_SPI_Transaction(2, buf(0))
 RegVal = buf(1)
End Sub

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub AccelPollTimer_Tick(sender As Object, e As EventArgs) Handles AccelPollTimer.Tick
 Dim reading(7) As Byte
 Dim id As Byte
 Dim i As Byte
 Dim datacnt As Byte
 Dim sdata As Short
 Dim fdata As Double

 'The poll timer fires every second as temperature changes only just so fast

 'Driver or concept errors just show as error in a benign way
 On Error GoTo APT_ERREXIT

 'Get the device ID (subaddress 15) to be sure we are connected to the right device
 id = 0
 ReadDeviceRegister(15, id)
 'Show what we got as an ID
 LED_DeviceID.ForeColor = LED_COLOR_STATUS_GOOD
 LED_DeviceID.Text = LngToHexByte(id)
 'See if we have the right ID, and if not caution the user and show error and leave
 If (id <> &H33&) Then GoTo APT_ERREXIT

 'If the device is powered down, show indeterminate state and leave
 If (LED_DevicePowerState.Text <> "ACTIVE") Then
  LED_AccelX.Text = "----"
  LED_AccelX.ForeColor = LED_COLOR_STATUS_ON
  LED_AccelY.Text = "----"
  LED_AccelY.ForeColor = LED_COLOR_STATUS_ON
  LED_AccelZ.Text = "----"
  LED_AccelZ.ForeColor = LED_COLOR_STATUS_ON
  Exit Sub
 End If

 'Get the sensor data
 'The FIFO is not enabled by default, and lots of other similarly fancy features are left out
 'This timer fires ones per second and reads data known at that time, which will usually be new since the last second
 'In any case a running update is presented in a simple mannner
 'Collect 6 bytes of data (7 in transaction including address, starting at register 28H, read and auto increment set
 datacnt = 7
 For i = 1 To 6
  reading(i) = &HFF&
 Next i
 reading(0) = &HE8&
 If (BHPMOD_SPI_Transaction(datacnt, reading(0)) <> 1) Then GoTo APT_ERREXIT
 If (datacnt <> 7) Then GoTo APT_ERREXIT
 'Marshal the 16-bit data for each axis
 sdata = BitConverter.ToInt16(reading, 1)
 'Translate the LSBs to g over the +/-2g range at 4g/65536LSB
 fdata = sdata
 fdata *= 4
 fdata /= 65536
 'Display the data with the implied accuracy
 LED_AccelX.ForeColor = LED_COLOR_STATUS_GOOD
 LED_AccelX.Text = Format(fdata, "0.000")
 'Repeat for the others
 sdata = BitConverter.ToInt16(reading, 3)
 fdata = sdata
 fdata *= 4
 fdata /= 65536
 LED_AccelY.ForeColor = LED_COLOR_STATUS_GOOD
 LED_AccelY.Text = Format(fdata, "0.000")
 sdata = BitConverter.ToInt16(reading, 5)
 fdata = sdata
 fdata *= 4
 fdata /= 65536
 LED_AccelZ.ForeColor = LED_COLOR_STATUS_GOOD
 LED_AccelZ.Text = Format(fdata, "0.000")

 'Normal exit
 Exit Sub

 'Problems get us here
APT_ERREXIT:
  LED_DeviceID.ForeColor = LED_COLOR_STATUS_ON
  LED_AccelX.Text = "ERR"
  LED_AccelX.ForeColor = LED_COLOR_STATUS_BAD
  LED_AccelY.Text = "ERR"
  LED_AccelY.ForeColor = LED_COLOR_STATUS_BAD
  LED_AccelZ.Text = "ERR"
  LED_AccelZ.ForeColor = LED_COLOR_STATUS_BAD
  LED_DevicePowerState.Text = "DEVICE ERROR"
  LED_DevicePowerState.ForeColor = LED_COLOR_STATUS_ON
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'There are no user controls in this dialog

Private Sub LED_DevicePowerState_Click(sender As Object, e As EventArgs) Handles LED_DevicePowerState.Click
 Dim datacnt As Byte
 Dim ctrl_reg(6) As Byte

 'If we are in power down, try to go to active 
 If (LED_DevicePowerState.Text = "POWER DOWN") Then
  'Upon enabling, set the various bits of the configuration registers for our use
  'Note that VB creates variables for the constants in the ByRef items, while other languages might not allow this
  'We start with the first control register subaddress and set the MSB auto increment bit
  ctrl_reg(1) = &H27&   '10Hz, normal mode, enable each axis
  ctrl_reg(2) = &H0&    'Keep default - filters bypassed
  ctrl_reg(3) = &H0&    'Keep default - features disabled
  ctrl_reg(4) = &H88&   'Use data read protection, keep little endian for the PC, keep 2g range, high res (high power), keep 4 wire SPI
  'Control reg 5 and 6 keep default
  datacnt = 5
  ctrl_reg(0) = &H60&   'Address of CTRL_REG1 with auto increment bit set
  If (BHPMOD_SPI_Transaction(datacnt, ctrl_reg(0)) <> 1) Then Exit Sub
  If (datacnt <> 5) Then Exit Sub
  'If all appears successful, show running, allowing the timer to actually read and interpret data
  LED_DevicePowerState.ForeColor = LED_COLOR_STATUS_GOOD
  LED_DevicePowerState.Text = "ACTIVE"
  Exit Sub
 End If

 'We are not in power down, so it must be we want to go to power down
 'If we are in some error state, this would be the right thing to try on click anyway
 'If this fails, just leave here and let the timer put us in that error state
 'Set the configuration register power control bit to power down, and others don't really care
 ctrl_reg(1) = &H28&   'Same as above, but powered down
 ctrl_reg(2) = &H0&
 ctrl_reg(3) = &H0&
 ctrl_reg(4) = &H80&   'Low res (low power)
 datacnt = 5
 ctrl_reg(0) = &H60&   'Address of CTRL_REG1 with auto increment bit set
 If (BHPMOD_SPI_Transaction(datacnt, ctrl_reg(0)) <> 1) Then Exit Sub
 If (datacnt <> 5) Then Exit Sub
 'Show shutdown - even if there was an error, these are all good reasons to tell timer to stop reading data
 LED_DevicePowerState.ForeColor = LED_COLOR_STATUS_GOOD
 LED_DevicePowerState.Text = "POWER DOWN"
End Sub
 
End Class