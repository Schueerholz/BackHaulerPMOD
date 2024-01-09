'---------------------------------------------------------------------------------------
'frmDialog_Fipsy.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Imports System.IO

Public Class frmDialog_FIPSY

    '---------------------------------------------------------------------------------------
    'Local Public Variables (Application Private)
    '---------------------------------------------------------------------------------------

    'File name of JEDEC file including full path
    Public JEDECFileName As String = ""

    '---------------------------------------------------------------------------------------
    'Module Entry And Exit Functions
    '---------------------------------------------------------------------------------------

    Private Sub frmDialog_Fipsy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Restore the last used file path
        JEDECFileName = My.Settings.JEDECFileName
        LED_JEDECFileName.Text = System.IO.Path.GetFileName(JEDECFileName)
        'Configure the PMOD connector
        PresentConfiguration = PMOD_CONFIGURATION_SPI
        SetPresentConfiguration()
        DisplayPresentConfiguration()
        'Note that the above is necessary to update our local display
        'We do need to call the custom library, which also configures the port
        'The library call sets the clock phase, so that does not need to be done seperately here
        Fipsy_Open()
        'Go get device id's
        LED_FPGADeviceID_Click(sender, e)
        LED_FPGAUniqueID_Click(sender, e)
    End Sub

    Private Sub frmDialog_Fipsy_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        'Stop polling the module (if we are polling)
        FipsyPollTimer.Enabled = False
        'Close the connection 
        Fipsy_Close()
        'Remove the configuration 
        ConfigurePassive()
    End Sub

    '---------------------------------------------------------------------------------------
    'Private General Subroutines
    '---------------------------------------------------------------------------------------

    'There is no need for such subroutines as most requirements are implemented by the library

    '---------------------------------------------------------------------------------------
    'Handler For Polling Timer
    '---------------------------------------------------------------------------------------

    Private Sub FipsyPollTimer_Tick(sender As Object, e As EventArgs) Handles FipsyPollTimer.Tick

        'This routine is not presently used, but might be useful if we want to poll for some sort  
        'of custom designed input from the FPGA logic

    End Sub

    '---------------------------------------------------------------------------------------
    'Handlers For User Controls
    '---------------------------------------------------------------------------------------

    Private Sub LED_FPGADeviceID_Click(sender As Object, e As EventArgs) Handles LED_FPGADeviceID.Click
        Dim device_id(6) As Byte

        If (Fipsy_ReadDeviceID(device_id(0)) = 0) Then
            LED_FPGAUniqueID.Text = "ERROR"
            Exit Sub
        End If

        LED_FPGADeviceID.Text = ""
        For i = 0 To 3
            LED_FPGADeviceID.Text += LngToHexByte(device_id(i)) + " "
        Next i

    End Sub

    Private Sub LED_FPGAUniqueID_Click(sender As Object, e As EventArgs) Handles LED_FPGAUniqueID.Click
        Dim unique_id(10) As Byte
        Dim i As Byte

        If (Fipsy_ReadUniqueID(unique_id(0)) = 0) Then
            LED_FPGAUniqueID.Text = "ERROR"
            Exit Sub
        End If

        LED_FPGAUniqueID.Text = ""
        For i = 0 To 7
            LED_FPGAUniqueID.Text += LngToHexByte(unique_id(i)) + " "
        Next i

    End Sub

    Private Sub Button_Browse_Click(sender As Object, e As EventArgs) Handles Button_Browse.Click
        FipsyOpenFileDialog.FileName = JEDECFileName
        FipsyOpenFileDialog.Filter = "Lattice JEDEC Files (*.jed)|*.jed|All Files (*.*)|*.*"
        If (FipsyOpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel) Then Exit Sub
        Application.DoEvents()
        JEDECFileName = FipsyOpenFileDialog.FileName
        My.Settings.JEDECFileName = JEDECFileName
        LED_JEDECFileName.Text = System.IO.Path.GetFileName(JEDECFileName)
    End Sub

    Private Sub Button_Erase_Click(sender As Object, e As EventArgs) Handles Button_Erase.Click
        Dim resp As UInteger
        Dim prevcur As Cursor

        'Call erase routine with wait cursor present in case it takes a while
        prevcur = Me.Cursor
        Me.Cursor = Cursors.WaitCursor
        resp = Fipsy_EraseAll()
        Me.Cursor = prevcur
    End Sub

    Private Sub Button_Program_Click(sender As Object, e As EventArgs) Handles Button_Program.Click
        Dim resp As UInteger
        Dim prevcur As Cursor
        Try
            Dim fileInfo As New FileInfo(JEDECFileName)

            'Be sure the user has not just forgotten to select a file, to say nothing of if it is any good
            If (Not fileInfo.Exists) Then
                Throw New FileNotFoundException("JEDEC file does not exist.", JEDECFileName)
            End If

            'Call program routine with wait cursor present in case it takes a while
            prevcur = Me.Cursor
            Me.Cursor = Cursors.WaitCursor
            resp = Fipsy_WriteConfiguration(JEDECFileName)
            Me.Cursor = prevcur
        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, "Missing Information")
            Exit Sub
        End Try
    End Sub

    Private Sub Button_EraseAndProgram_Click(sender As Object, e As EventArgs) Handles Button_EraseAndProgram.Click
 'This button for convenience just executes both of the above
 'Note that this effectively excercises all programming related routines, not all of which are exposed to the user directly
 Button_Erase_Click(sender, e)
 Button_Program_Click(sender, e)
End Sub

End Class