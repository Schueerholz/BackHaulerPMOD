'---------------------------------------------------------------------------------------
'frmDialog_USBUART.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_USBUART

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_USBUART_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SERIAL
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'The serial configuration defaults to all other pins as inputs
 'We could leave it this way, but drive RTS active (low) so that anything expecting hardware handshake will work easier
 'The RTS is on pin 4, the CTS on pin 1, as defined by PMOD specification
 Form1.CheckBox_PP_PIN4.Checked = True
 BHPMOD_SetPinDrive(4, 1)
 BHPMOD_SetPinState(4, 0)
 'Start looking for serial input
 RxPollTimer.Enabled = True
End Sub

Private Sub frmDialog_USBUART_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 RxPollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub RxPollTimer_Tick(sender As Object, e As EventArgs) Handles RxPollTimer.Tick
 Dim cnt As Byte
 Dim content(70) As Byte
 Dim bcnt As Byte

 'The poll timer fires every few milliseconds, so at 9600 buad that would be less than 50 bytes or so
 'Look for more than that in case we were delayed further sometimes 
 'The maximum count is larger than this, but the API limits it as it needs, so we can use 
 'any byte value here as long as we have room in the buffer
 'Disable the timer so we don't call here repeatedly if the driver wants to wait
 RxPollTimer.Enabled = False
 cnt = 60
 If (BHPMOD_SERIAL_Read(cnt, content(0)) <> 1) Then
  'When we get back from the call we can restart the poll timer
  RxPollTimer.Enabled = True
  Exit Sub
 End If
 RxPollTimer.Enabled = True
 If (cnt = 0) Then Exit Sub

 'Process the number of bytes actually received
 For bcnt = 0 To cnt
  If (Chr(content(bcnt)) = vbCr) Then
   TextBox_Terminal.AppendText(vbCrLf)
  Else
   TextBox_Terminal.AppendText(Chr(content(bcnt)))
  End If
  TextBox_Terminal.Select(TextBox_Terminal.Text.Length, 0)
 Next

End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

Private Sub Button_Send_Click(sender As Object, e As EventArgs) Handles Button_Send.Click
 Dim str As String
 'Send the string with CR/LF
 str = Textbox_Send_String.Text + vbCrLf
 BHPMOD_SERIAL_Print(str)
End Sub

Private Sub Textbox_Send_String_DoubleClick(sender As Object, e As EventArgs) Handles Textbox_Send_String.DoubleClick
 'Gives us an easy way to clear the text box
 Textbox_Send_String.Text = ""
End Sub

Private Sub TextBox_Terminal_DoubleClick(sender As Object, e As EventArgs) Handles TextBox_Terminal.DoubleClick
 'Gives us an easy way to clear the text box
 TextBox_Terminal.Text = ""
End Sub

Private Sub TextBox_Terminal_Keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Terminal.KeyPress
 Dim cnt As Byte
 Dim val As Byte
 'If we entered something that causes grief, just let the system ignore it
 On Error Resume Next
 'Translate the key code to a byte we can send
 val = Microsoft.VisualBasic.Asc(e.KeyChar)
 'Send the byte
 cnt = 1
 BHPMOD_SERIAL_Write(cnt, val)
 'If we just send a CR, follow it with a line feed
 If (val = 13) Then
  cnt = 10
  val = vbLf
  BHPMOD_SERIAL_Write(cnt, val)
 End If
 'Indicate that the key press was handled
 e.Handled = True
End Sub

End Class