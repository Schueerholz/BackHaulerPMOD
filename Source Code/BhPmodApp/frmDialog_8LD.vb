'---------------------------------------------------------------------------------------
'frmDialog_8LD.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_8LD

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_8LD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_IO_ONLY
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'The I/O mode is passive until we set the drives for all pins
 'Start with the outputs low and the drive push-pull
 BHPMOD_SetPinState(1, 0)
 BHPMOD_SetPinState(2, 0)
 BHPMOD_SetPinState(3, 0)
 BHPMOD_SetPinState(4, 0)
 BHPMOD_SetPinState(7, 0)
 BHPMOD_SetPinState(8, 0)
 BHPMOD_SetPinState(9, 0)
 BHPMOD_SetPinState(10, 0)
 BHPMOD_SetPinDrive(1, 1)
 BHPMOD_SetPinDrive(2, 1)
 BHPMOD_SetPinDrive(3, 1)
 BHPMOD_SetPinDrive(4, 1)
 BHPMOD_SetPinDrive(7, 1)
 BHPMOD_SetPinDrive(8, 1)
 BHPMOD_SetPinDrive(9, 1)
 BHPMOD_SetPinDrive(10, 1)
 Form1.CheckBox_PP_PIN1.Checked = True
 Form1.CheckBox_PP_PIN2.Checked = True
 Form1.CheckBox_PP_PIN3.Checked = True
 Form1.CheckBox_PP_PIN4.Checked = True
 Form1.CheckBox_PP_PIN7.Checked = True
 Form1.CheckBox_PP_PIN8.Checked = True
 Form1.CheckBox_PP_PIN9.Checked = True
 Form1.CheckBox_PP_PIN10.Checked = True
End Sub

Private Sub frmDialog_8LD_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

Private Sub LED_Dn_Click(sender As Object, e As EventArgs) Handles _
 LED_D0.Click, LED_D1.Click, LED_D2.Click, LED_D3.Click, LED_D4.Click, LED_D5.Click, LED_D6.Click, LED_D7.Click, _
 LED_D0.DoubleClick, LED_D1.DoubleClick, LED_D2.DoubleClick, LED_D3.DoubleClick, LED_D4.DoubleClick, LED_D5.DoubleClick, LED_D6.DoubleClick, LED_D7.DoubleClick

 Dim led_number As Byte
 Dim led_state As Boolean

 'See if we can get the led number out of the text in the sender control,
 'but if not then we just need to gracefully exit because something is quite wrong
 Try
  led_number = CLng(Microsoft.VisualBasic.Strings.Right(DirectCast(sender, Label).Text, 1))
 Catch
  Exit Sub
 End Try

 'We know the sender casting is working, so let's get the presented pin state based on the background color 
 led_state = (DirectCast(sender, Label).BackColor = LED_COLOR_STATUS_GOOD)

 'Toggle the intended state
 led_state = Not led_state

 'Based on the led we are addressing, edit the control and the actual pin
 'The connectivity is derived from the schematic and is needed only here
 Select Case led_number
  Case 0
   LED_D0.BackColor = LED_COLOR_STATUS_OFF
   If (led_state) Then LED_D0.BackColor = LED_COLOR_STATUS_GOOD
   BHPMOD_SetPinState(1, led_state)
  Case 1
   LED_D1.BackColor = LED_COLOR_STATUS_OFF
   If (led_state) Then LED_D1.BackColor = LED_COLOR_STATUS_GOOD
   BHPMOD_SetPinState(2, led_state)
  Case 2
   LED_D2.BackColor = LED_COLOR_STATUS_OFF
   If (led_state) Then LED_D2.BackColor = LED_COLOR_STATUS_GOOD
  BHPMOD_SetPinState(3, led_state)
  Case 3
   LED_D3.BackColor = LED_COLOR_STATUS_OFF
   If (led_state) Then LED_D3.BackColor = LED_COLOR_STATUS_GOOD
   BHPMOD_SetPinState(4, led_state)
  Case 4
   LED_D4.BackColor = LED_COLOR_STATUS_OFF
   If (led_state) Then LED_D4.BackColor = LED_COLOR_STATUS_GOOD
  BHPMOD_SetPinState(7, led_state)
  Case 5
   LED_D5.BackColor = LED_COLOR_STATUS_OFF
   If (led_state) Then LED_D5.BackColor = LED_COLOR_STATUS_GOOD
   BHPMOD_SetPinState(8, led_state)
  Case 6
   LED_D6.BackColor = LED_COLOR_STATUS_OFF
   If (led_state) Then LED_D6.BackColor = LED_COLOR_STATUS_GOOD
   BHPMOD_SetPinState(9, led_state)
  Case 7
   LED_D7.BackColor = LED_COLOR_STATUS_OFF
   If (led_state) Then LED_D7.BackColor = LED_COLOR_STATUS_GOOD
   BHPMOD_SetPinState(10, led_state)
 End Select

End Sub

End Class