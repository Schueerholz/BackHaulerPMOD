'---------------------------------------------------------------------------------------
'FORM1.VB
'
'This is the default name given to the primary user form.  This application is configured
'to use this form as the main entry point and exit point.  Thus, we keep the name "Form1",
'for "number one form", or "top form".  Other forms would have more specific names.
'
'---------------------------------------------------------------------------------------

Imports BhPmodApp.My

Public Class Form1

    'This class forms the main program and the commuter module for Form1 controls

    '---------------------------------------------------------------------------------------
    'Public Variables
    '---------------------------------------------------------------------------------------


    '---------------------------------------------------------------------------------------
    'Module Entry And Exit Functions
    '---------------------------------------------------------------------------------------

    'Form1_Load is set as the application entry point
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim status As Byte
        Dim PMODPeripheralIndex As Integer

        'On Error GoTo FLERR

        'Accessing the API will load the library and open the driver
        'This startup activity also performs and configuration and initialization associted with it
        'The entry is coded to open devices on the SPI bridge as well
        If (BHPMOD_GetStatus(status) <> 1) Then GoTo FLERR

        'Show our display and wait a little while longer for the sensor configuration to be done
        PMODPeripheralIndex = My.Settings.PMODPeripheralIndex
        ComboBox_SelectPMODPeripheral.SelectedIndex = PMODPeripheralIndex ' Pre-select users last selection
        Me.Show()

 'Set the initial configuration to agree with the display being formed
 ConfigurePassive()

 'Enable regular status update
 'This will update the test set status
 PollTimer.Enabled = True
 PollTimer_Tick(sender, e)

 'End of normal activity
 Exit Sub

FLERR:
 MsgBox("Error starting Backhauler PMOD test software", vbExclamation)
 Me.Close()
End Sub

'Form1_Unload allows for cleanup before the application exits
'Most things are cleaned up automatically, but there are often unique needs too
Private Sub Form1_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        My.Settings.Save()
    End Sub

    '---------------------------------------------------------------------------------------
    'Handler For Polling Timer
    '---------------------------------------------------------------------------------------

    'When enabled, the timer event is set to occur periodically, about one or two times a second
    'This event monitors the health of the test set and pushes the testing forward 
    'where the operator is not involved
    Private Sub PollTimer_Tick(sender As Object, e As EventArgs) Handles PollTimer.Tick
 Dim status As Byte

 'See if the test set is still there, and if not it is time to leave
 If (BHPMOD_GetStatus(status) <> 1) Then Me.Close()

 'Dispatch timed functions below

 'If we are going to monitor pin state
 If (CheckBox_Poll_Pin_State.Checked) Then
  If (LED_PIN1.BackColor <> Color.Black) Then
   BHPMOD_GetPinState(1, status)
   If (status = 1) Then LED_PIN1.BackColor = LED_COLOR_STATUS_ON Else LED_PIN1.BackColor = LED_COLOR_STATUS_OFF
  End If
  If (LED_PIN2.BackColor <> Color.Black) Then
   BHPMOD_GetPinState(2, status)
   If (status = 1) Then LED_PIN2.BackColor = LED_COLOR_STATUS_ON Else LED_PIN2.BackColor = LED_COLOR_STATUS_OFF
  End If
  If (LED_PIN3.BackColor <> Color.Black) Then
   BHPMOD_GetPinState(3, status)
   If (status = 1) Then LED_PIN3.BackColor = LED_COLOR_STATUS_ON Else LED_PIN3.BackColor = LED_COLOR_STATUS_OFF
  End If
  If (LED_PIN4.BackColor <> Color.Black) Then
   BHPMOD_GetPinState(4, status)
   If (status = 1) Then LED_PIN4.BackColor = LED_COLOR_STATUS_ON Else LED_PIN4.BackColor = LED_COLOR_STATUS_OFF
  End If
  If (LED_PIN7.BackColor <> Color.Black) Then
   BHPMOD_GetPinState(7, status)
   If (status = 1) Then LED_PIN7.BackColor = LED_COLOR_STATUS_ON Else LED_PIN7.BackColor = LED_COLOR_STATUS_OFF
  End If
  If (LED_PIN8.BackColor <> Color.Black) Then
   BHPMOD_GetPinState(8, status)
   If (status = 1) Then LED_PIN8.BackColor = LED_COLOR_STATUS_ON Else LED_PIN8.BackColor = LED_COLOR_STATUS_OFF
  End If
  If (LED_PIN9.BackColor <> Color.Black) Then
   BHPMOD_GetPinState(9, status)
   If (status = 1) Then LED_PIN9.BackColor = LED_COLOR_STATUS_ON Else LED_PIN9.BackColor = LED_COLOR_STATUS_OFF
  End If
  If (LED_PIN10.BackColor <> Color.Black) Then
   BHPMOD_GetPinState(10, status)
   If (status = 1) Then LED_PIN10.BackColor = LED_COLOR_STATUS_ON Else LED_PIN10.BackColor = LED_COLOR_STATUS_OFF
  End If
 End If

End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

Private Sub CheckBox_PP_PINn_Click(sender As Object, e As EventArgs) Handles _
 CheckBox_PP_PIN1.Click, CheckBox_PP_PIN2.Click, CheckBox_PP_PIN3.Click, CheckBox_PP_PIN4.Click, _
 CheckBox_PP_PIN7.Click, CheckBox_PP_PIN8.Click, CheckBox_PP_PIN9.Click, CheckBox_PP_PIN10.Click
 'If we are not polling, we say we can't do this
 If (Not CheckBox_Poll_Pin_State.Checked) Then Exit Sub
 'Edit based on local enable as well
 If (sender.Equals(CheckBox_PP_PIN1) And CheckBox_PP_PIN1.Enabled) Then BHPMOD_SetPinDrive(1, CheckBox_PP_PIN1.Checked)
 If (sender.Equals(CheckBox_PP_PIN2) And CheckBox_PP_PIN2.Enabled) Then BHPMOD_SetPinDrive(2, CheckBox_PP_PIN2.Checked)
 If (sender.Equals(CheckBox_PP_PIN3) And CheckBox_PP_PIN3.Enabled) Then BHPMOD_SetPinDrive(3, CheckBox_PP_PIN3.Checked)
 If (sender.Equals(CheckBox_PP_PIN4) And CheckBox_PP_PIN4.Enabled) Then BHPMOD_SetPinDrive(4, CheckBox_PP_PIN4.Checked)
 If (sender.Equals(CheckBox_PP_PIN7) And CheckBox_PP_PIN7.Enabled) Then BHPMOD_SetPinDrive(7, CheckBox_PP_PIN7.Checked)
 If (sender.Equals(CheckBox_PP_PIN8) And CheckBox_PP_PIN8.Enabled) Then BHPMOD_SetPinDrive(8, CheckBox_PP_PIN8.Checked)
 If (sender.Equals(CheckBox_PP_PIN9) And CheckBox_PP_PIN9.Enabled) Then BHPMOD_SetPinDrive(9, CheckBox_PP_PIN9.Checked)
 If (sender.Equals(CheckBox_PP_PIN10) And CheckBox_PP_PIN10.Enabled) Then BHPMOD_SetPinDrive(10, CheckBox_PP_PIN10.Checked)
End Sub

Private Sub LED_PINn_Click(sender As Object, e As EventArgs) Handles _
 LED_PIN1.Click, LED_PIN2.Click, LED_PIN3.Click, LED_PIN4.Click, _
 LED_PIN7.Click, LED_PIN8.Click, LED_PIN9.Click, LED_PIN10.Click
 Dim pin_number As Byte
 Dim pin_state As Boolean

 'If we are not polling, we say we can't do this
 If (Not CheckBox_Poll_Pin_State.Checked) Then Exit Sub

 'See if we can get the pin number out of the text in the sender control,
 'but if not then we just need to gracefully exit because something is quite wrong
 Try
  pin_number = CLng(DirectCast(sender, Label).Text)
 Catch
  Exit Sub
 End Try

 'We know the sender casting is working, so let's get the presented pin state based on the background color 
 pin_state = (DirectCast(sender, Label).BackColor = LED_COLOR_STATUS_ON)

 'Based on the pin we clicked, if the state can be edited, change to the new state
 'Note that the PP checkbox enable serves here as a state change enable as well 
 'Disabling the LED changes the colors in a way we don't like - we want to show feedback if the user wants that
 pin_state = Not pin_state
 Select Case pin_number
  Case 1
   If (CheckBox_PP_PIN1.Enabled) Then BHPMOD_SetPinState(1, pin_state)
  Case 2
   If (CheckBox_PP_PIN2.Enabled) Then BHPMOD_SetPinState(2, pin_state)
  Case 3
   If (CheckBox_PP_PIN3.Enabled) Then BHPMOD_SetPinState(3, pin_state)
  Case 4
   If (CheckBox_PP_PIN4.Enabled) Then BHPMOD_SetPinState(4, pin_state)
  Case 7
   If (CheckBox_PP_PIN7.Enabled) Then BHPMOD_SetPinState(7, pin_state)
  Case 8
   If (CheckBox_PP_PIN8.Enabled) Then BHPMOD_SetPinState(8, pin_state)
  Case 9
   If (CheckBox_PP_PIN9.Enabled) Then BHPMOD_SetPinState(9, pin_state)
  Case 10
   If (CheckBox_PP_PIN10.Enabled) Then BHPMOD_SetPinState(10, pin_state)
 End Select

 'Changes to the pin state are reported by the next polling
 'This keeps us from printing a false state change that failed to take effect in hardware for some other reason
 'Force a polling cycle here so the display will be updated quickly
 PollTimer_Tick(sender, e)

End Sub

Private Sub LED_Configuration_Click(sender As Object, e As EventArgs) Handles LED_Configuration.Click
 'Set new configuration based on where we were
 Select Case PresentConfiguration
  Case PMOD_CONFIGURATION_IO_ONLY
   PresentConfiguration = PMOD_CONFIGURATION_SPI
  Case PMOD_CONFIGURATION_SPI
   PresentConfiguration = PMOD_CONFIGURATION_I2C
  Case PMOD_CONFIGURATION_I2C
   PresentConfiguration = PMOD_CONFIGURATION_SERIAL
  Case PMOD_CONFIGURATION_SERIAL
   PresentConfiguration = PMOD_CONFIGURATION_IO_ONLY
 End Select

 'Write the new configuration
 SetPresentConfiguration()

 'Update the display  
 DisplayPresentConfiguration()

End Sub

Private Sub CheckBox_Poll_Pin_State_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Poll_Pin_State.CheckedChanged
 'Update the display and enables based on this selection
 DisplayPresentConfiguration()
End Sub

Private Sub Button_OpenDialog_Click(sender As Object, e As EventArgs) Handles Button_OpenDialog.Click
 Dim Dialog As Form

 'Use this code to dumb out the dropdown box and just start the dialog of interest now
 'This code is used during development of a new dialog and is commented out in distribution
 'Dialog = New frmDialog_COMPAIR
 'Dialog.ShowDialog()
 'Dialog.Dispose()
 'Exit Sub

 'Create a dialog based on the dropdown box selection
 'Use the text just so we don't have to count indexes and update references to an ever changing list
 'This way each new PMOD just gets a user friendly name which must simply be the same here and in the dropdown
 'There is no requirement that the order of the dropdown list be the same as the order here - just style drives us to do that to some extent,
 'but using the text we can put the entry anywhere in either list without affecting other entries
 Select Case ComboBox_SelectPMODPeripheral.Text
  Case "ACW 24-Bit ADC"
   Dialog = New frmDialog_SDADC
  Case "ACW Dual 10-Bit DAC"
   Dialog = New frmDialog_DUALDAC
  Case "ACW Quad 10-Bit DAC"
   Dialog = New frmDialog_QUADDAC
  Case "ACW Humiture Sensor"
   Dialog = New frmDialog_HUMITURE
  Case "ACW Tri-color LED Module"
   Dialog = New frmDialog_TRILED
  Case "ACW RF Power Sensor"
   Dialog = New frmDialog_RFPWR
  Case "ACW Presssure Sensor"
   Dialog = New frmDialog_PRESSURE
  Case "ACW Thermistor Input"
   Dialog = New frmDialog_THERMISTOR
  Case "ACW RTD Input"
   Dialog = New frmDialog_RTD
  Case "ACW Real Time Clock"
   Dialog = New frmDialog_RTC
  Case "ACW 3-Axis Accelerometer"
   Dialog = New frmDialog_ACCEL
  Case "ACW Everspin MRAM"
   Dialog = New frmDialog_MRAM
  Case "ACW Potentiometer"
   Dialog = New frmDialog_POTENTIOMETER
  Case "ACW Compressed Air Sensor"
   Dialog = New frmDialog_COMPAIR
  Case "ACW Color Light Sensor"
   Dialog = New frmDialog_COLOR
  Case "Moco Makers Fipsy FPGA"
   Dialog = New frmDialog_FIPSY
  Case "Digilent USB UART"
   Dialog = New frmDialog_USBUART
  Case "Digilent 4 Button Module"
   Dialog = New frmDialog_BTN
  Case "Digilent 8 LED Module"
   Dialog = New frmDialog_8LD
  Case "Digilent Temperature Sensor"
   Dialog = New frmDialog_TMP2
  Case "Digilent Ambient Light Sensor"
   Dialog = New frmDialog_ALS
  Case Else
   Exit Sub
 End Select

 'Adjust the positon of the dialog so we know it is seperate form Form1
 Dialog.Left = Me.Left + 100
 Dialog.Top = Me.Top + 100

 'Open the selected dialog as a modal form
 Dialog.ShowDialog()

 'After returning from the dialog, get rid of it
 Dialog.Dispose()
End Sub

    Private Sub ComboBox_SelectPMODPeripheral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_SelectPMODPeripheral.SelectedIndexChanged
        My.Settings.PMODPeripheralIndex = ComboBox_SelectPMODPeripheral.SelectedIndex
    End Sub
End Class