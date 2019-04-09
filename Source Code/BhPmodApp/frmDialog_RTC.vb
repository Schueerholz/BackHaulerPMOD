'---------------------------------------------------------------------------------------
'frmDialog_RTC.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_RTC

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_RTC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 Dim creg As Byte
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_0)
 'Disable the CLKOUT signal by default to agree with display (see more notes with routine below)
 BHPMOD_SetPinState(10, 0)
 'Set the CLKOE pin to active drive 
 'Rrequired to turn it on, but not to turn it off - though the stronger pull-up on pin 10 does tend to turn it on anyway when set
 BHPMOD_SetPinDrive(10, 1)
 Form1.CheckBox_PP_PIN10.Checked = True
 'Get the state of the 12-hour bit and set the checkbox accordingly
 ReadDeviceRegister(0, creg)
 If (creg And 4) Then CheckBox_TwelveHour.Checked = True
 'Do a software reset in case we hot plugged and did that in a bad way
 'WriteDeviceRegister(0, &H58&)
 'Sleep(500)
 'Enable poll timer
 TimePollTimer.Enabled = True
End Sub

Private Sub frmDialog_RTC_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Remove the configuration 
 ConfigurePassive()
 'Ok to leave with the 12-hour mode set as it is - this is detected on next opening
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------

'Generalized register write routine for our device
'Note that in most places we use absolute numbers for the arguments - while not really good
'coding practice, this code is small and numbers help to follow along with a datasheet in this demonstration
'By using the register address alone, the R/W bit (MSB) is always low (write)
'This device requires the address in the lower nibble with a 1 the upper nibble - ie &H1n& for register address n
Private Sub WriteDeviceRegister(ByVal RegAddr As Byte, ByVal RegVal As Byte)
 Dim buf(2) As Byte
 buf(0) = RegAddr Or &H10&
 buf(1) = RegVal
 BHPMOD_SPI_Transaction(2, buf(0))
End Sub

'Generalized register read routine for our device
'This is the dual of write, and sets the R/W bit high
'The value read is returned by reference
Private Sub ReadDeviceRegister(ByVal RegAddr As Byte, ByRef RegVal As Byte)
 Dim buf(2) As Byte
 buf(0) = RegAddr Or &H90&
 buf(1) = &HFF&
 BHPMOD_SPI_Transaction(2, buf(0))
 RegVal = buf(1)
End Sub

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub TimePollTimer_Tick(sender As Object, e As EventArgs) Handles TimePollTimer.Tick
 Dim buf(6) As Byte
 Dim reg(6) As Byte
 Dim i As Byte
 Dim cnt As Byte
 Dim twelvehour As Boolean
 Dim pm As Boolean
 'This timer fires every half second, so we should be able to more or less keep up with seconds changing
 'The slight inaccuracy of the resulting display seems reasonable for this demonstration
 'Get register data starting at 0 (control 1) and through 4 (hours) 
 'See comments with read/write register routines 
 'Read data prefill is not necessay, though it might be good measure to know if something went wrong 
 'Instead we look for the API to tell us, which is probably good enough here
 buf(0) = &H90&
 cnt = 6
 If (BHPMOD_SPI_Transaction(cnt, buf(0)) <> 1) Then
  LED_TimeDisplay.Text = ""
  Exit Sub
 End If
 If (cnt <> 6) Then
  LED_TimeDisplay.Text = ""
  Exit Sub
 End If
 'Get data into reg() values for easier interpretation
 For i = 0 To 4
  reg(i) = buf(i + 1)
 Next i
 'Look at register 0 to see if we are in 12 hour mode
 twelvehour = False
 If (reg(0) And 4) Then twelvehour = True
 'Data are seconds, minutes, hours in BCD
 'So printing in hex will show the information well
 'We don't care so much right now if the time is accurate, so mask that bit off of seconds
 'Also seems to require we mask off unused bits
 reg(2) = reg(2) And &H7F&
 reg(3) = reg(3) And &H7F&
 'If we are in 12 hour mode, get the PM status 
 pm = False
 If (twelvehour And (reg(4) And &H20)) Then pm = True
 'Mask hours according to mode
 If (twelvehour) Then reg(4) = reg(4) And &H1F& Else reg(4) = reg(4) And &H3F&
 If (reg(4) < &H10&) Then LED_TimeDisplay.Text = Trim(Str(reg(4))) Else LED_TimeDisplay.Text = LngToHexByte(reg(4))
 LED_TimeDisplay.Text += ":" + LngToHexByte(reg(3)) + ":" + LngToHexByte(reg(2))
 If (twelvehour And pm) Then LED_TimeDisplay.Text += " PM"
 If (twelvehour And Not pm) Then LED_TimeDisplay.Text += " AM"
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

Private Sub Button_SetTime_Click(sender As Object, e As EventArgs) Handles Button_SetTime.Click
 Dim buf(4) As Byte

 'Be sure to go to 24 hour mode
 CheckBox_TwelveHour.Checked = False
 CheckBox_TwelveHour_Click(sender, e)

 'Get write command with 24 hour time
 buf(0) = &H12&
 buf(1) = Now.Second
 buf(1) = (buf(1) \ 10) * 16 + (buf(1) Mod 10)
 buf(2) = Now.Minute
 buf(2) = (buf(2) \ 10) * 16 + (buf(2) Mod 10)
 buf(3) = Now.Hour
 buf(3) = (buf(3) \ 10) * 16 + (buf(3) Mod 10)
 'Write new time
 BHPMOD_SPI_Transaction(4, buf(0))
End Sub

Private Sub CheckBox_1Hz_Pulse_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_1Hz_Pulse.CheckedChanged
 'If not checked, simply use the CLKOE pin to inhibit the output
 If (CheckBox_1Hz_Pulse.Checked = False) Then
  BHPMOD_SetPinState(10, 0)
  Exit Sub
 End If
 'The box is checked, so start by setting the registers for 1Hz output
 'Set timer control to keep the default settings except set 1Hz output on CLKOUT
 WriteDeviceRegister(&HE&, &H63&)
 'Set the pin high to enable the CLKOUT (CLKOE true)
 BHPMOD_SetPinState(10, 1)
End Sub

Private Sub CheckBox_TwelveHour_Click(sender As Object, e As EventArgs) Handles CheckBox_TwelveHour.Click
 Dim creg As Byte
 Dim hour As Byte
 Dim twelvehour As Boolean

 'Process the click event rather than the checkedchanged so this only responds to the user while other things can change the check
 'Otherwise we would have to distinguish those events at this level

 'Get control register
 ReadDeviceRegister(0, creg)
 twelvehour = False
 If (creg And 4) Then twelvehour = True

 'If we are in the mode implied by the checkbox then quit here
 If Not (twelvehour Xor CheckBox_TwelveHour.Checked) Then Exit Sub

  'If we want a change, we can now assume the clock is set for the opposite
 'Change the 12-hour bit and the hour information 
 'Also requires reading and rewriting the hour as the clock does not do this itself, 
 'just interprets data as it counts, which can give some very strange results if it is set wrong
 'Get the present hour data 
 'Yes this could be timed badly, but that is rare and this is just a test
 ReadDeviceRegister(4, hour)
 'Rewrite the hour with the new format
 If (CheckBox_TwelveHour.Checked) Then
  'Was 24 hour, going to 12 hour
  If (hour >= &H12&) Then
   If (hour > &H12&) Then hour -= &H12&
   hour = hour Or &H20&
  ElseIf (hour = 0) Then
   hour = &H12&
  End If
  'Set the 12 hour bit
  creg = creg Or 4
 Else
  'Was 12 hour, going to 24 hour
  If (hour And &H20&) Then
   hour = hour And &H1F&
   If (hour < &H12&) Then hour += &H12&
  ElseIf (hour = &H12&) Then
   hour = 0
  End If
  'Clear the 12 hour bit
  creg = creg And &HFB&
 End If
 'Write the updated hour and control registers 
 WriteDeviceRegister(0, creg)
 WriteDeviceRegister(4, hour)
End Sub

End Class