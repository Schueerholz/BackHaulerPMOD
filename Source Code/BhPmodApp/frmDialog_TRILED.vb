'---------------------------------------------------------------------------------------
'frmDialog_TRILED.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_TRILED

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_TRILED_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_0)
 'Start the device in shutdown to agree with the display being created 
 'This does nothing if the device is not yet connected - it should be connected, but we should not assume
 DeviceShutdown()
End Sub

Private Sub frmDialog_TRILED_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Shutdown the device before leaving
 DeviceShutdown()
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
Private Sub WriteDeviceRegister(ByVal RegAddr As Byte, ByVal RegVal As Byte)
 Dim buf(2) As Byte
 buf(0) = RegAddr
 buf(1) = RegVal
 BHPMOD_SPI_Transaction(2, buf(0))
End Sub

'Steps required to turn off the device
Private Sub DeviceShutdown()
 'Configure to shutdown, with fade off, always use stagger mode
 WriteDeviceRegister(&H10&, &H28&)
End Sub

'Steps required to turn on the device
Private Sub DeviceRun()
 'Set everything during enable process in case the device was just plugged in
 'Use full scale for the current on all outputs
 WriteDeviceRegister(&H13&, &HFF&)
 WriteDeviceRegister(&H14&, &HFF&)
 'Set the global current according to the slider
 WriteDeviceRegister(&H15&, TrackBar_Intensity.Value)
 'Set for one second ramp fade and ramp up
 WriteDeviceRegister(&H11&, 5)
 WriteDeviceRegister(&H12&, 5)
 'Set all colors
 SetLEDColors()
 'Configure to run, with ramp up on, always use stagger mode
 WriteDeviceRegister(&H10&, &H25&)
End Sub

'Set the PWM registers for the color of the LED starting with red at the register specified
'Per the schematic, R-G-B outputs and thus registers are in sequence for a given LED
'This routine limits the values to those valid for PWM
'Note that the device requires that one register be written at a time (could in principle be daisy chained that way)
'The off/hi-z/zero output value is all 1 (ie 255), the all on/full output is 2, 3-254 are PWM settings in that order of brightness
Private Sub SetPwmRegisters(ByVal RedReg As Byte, ByVal R As Byte, ByVal G As Byte, ByVal B As Byte)
 If (R < 3) Then R = 255 Else If (R > 254) Then R = 2
 If (G < 3) Then G = 255 Else If (G > 254) Then G = 2
 If (B < 3) Then B = 255 Else If (B > 254) Then B = 2
 WriteDeviceRegister(RedReg, R)
 RedReg += 1
 WriteDeviceRegister(RedReg, G)
 RedReg += 1
 WriteDeviceRegister(RedReg, B)
End Sub

'Collect colors from colored labels and set to device
Private Sub SetLEDColors()
 SetPwmRegisters(0, LED_Color_1.BackColor.R, LED_Color_1.BackColor.G, LED_Color_1.BackColor.B)
 SetPwmRegisters(3, LED_Color_2.BackColor.R, LED_Color_2.BackColor.G, LED_Color_2.BackColor.B)
 SetPwmRegisters(6, LED_Color_3.BackColor.R, LED_Color_3.BackColor.G, LED_Color_3.BackColor.B)
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

Private Sub LED_DevicePowerState_Click(sender As Object, e As EventArgs) Handles LED_DevicePowerState.Click
 'If we are in shutdown, go to enabled
 If (LED_DevicePowerState.Text = "SHUTDOWN") Then
  DeviceRun()
  LED_DevicePowerState.Text = "RUN"
 Else 'If we are enabled, go to shutdown
  DeviceShutdown()
  LED_DevicePowerState.Text = "SHUTDOWN"
 End If
End Sub

Private Sub TrackBar_Intensity_Scroll(sender As Object, e As EventArgs) Handles TrackBar_Intensity.Scroll
 'Set the global current according to the slider
 WriteDeviceRegister(&H15&, TrackBar_Intensity.Value)
End Sub

Private Sub LED_Color_1_Click(sender As Object, e As EventArgs) Handles LED_Color_1.Click
  If (LEDColorDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
   LED_Color_1.BackColor = LEDColorDialog.Color
   Application.DoEvents()
   SetPwmRegisters(0, LED_Color_1.BackColor.R, LED_Color_1.BackColor.G, LED_Color_1.BackColor.B)
  End If
End Sub

Private Sub LED_Color_2_Click(sender As Object, e As EventArgs) Handles LED_Color_2.Click
  If (LEDColorDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
   LED_Color_2.BackColor = LEDColorDialog.Color
   Application.DoEvents()
   SetPwmRegisters(3, LED_Color_2.BackColor.R, LED_Color_2.BackColor.G, LED_Color_2.BackColor.B)
  End If
End Sub

Private Sub LED_Color_3_Click(sender As Object, e As EventArgs) Handles LED_Color_3.Click
  If (LEDColorDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
   LED_Color_3.BackColor = LEDColorDialog.Color
   Application.DoEvents()
   SetPwmRegisters(6, LED_Color_3.BackColor.R, LED_Color_3.BackColor.G, LED_Color_3.BackColor.B)
  End If
End Sub

Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

End Sub
End Class