'---------------------------------------------------------------------------------------
'frmDialog_BTN.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_BTN

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_BTN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector - defaults to all input
 PresentConfiguration = PMOD_CONFIGURATION_IO_ONLY
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Start looking for input
 BtnPollTimer.Enabled = True
End Sub

Private Sub frmDialog_BTN_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 BtnPollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub BtnPollTimer_Tick(sender As Object, e As EventArgs) Handles BtnPollTimer.Tick
 Dim state As Byte

 'Read each pin state and set the corresponding button state display accordingly
 BHPMOD_GetPinState(1, state)
 If (state = 1) Then LED_BTN0.BackColor = LED_COLOR_STATUS_ON Else LED_BTN0.BackColor = LED_COLOR_STATUS_OFF
 BHPMOD_GetPinState(2, state)
 If (state = 1) Then LED_BTN1.BackColor = LED_COLOR_STATUS_ON Else LED_BTN1.BackColor = LED_COLOR_STATUS_OFF
 BHPMOD_GetPinState(3, state)
 If (state = 1) Then LED_BTN2.BackColor = LED_COLOR_STATUS_ON Else LED_BTN2.BackColor = LED_COLOR_STATUS_OFF
 BHPMOD_GetPinState(4, state)
 If (state = 1) Then LED_BTN3.BackColor = LED_COLOR_STATUS_ON Else LED_BTN3.BackColor = LED_COLOR_STATUS_OFF

End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'There are no user controls in this dialog

End Class