'---------------------------------------------------------------------------------------
'frmDialog_THERMISTOR.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_THERMISTOR

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_THERMISTOR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_0)
 'Start looking for light sensor data
 TemperaturePollTimer.Enabled = True
End Sub

Private Sub frmDialog_THERMISTOR_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 TemperaturePollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub TemperaturePollTimer_Tick(sender As Object, e As EventArgs) Handles TemperaturePollTimer.Tick
 Dim cnt As Byte
 Dim buf(4) As Byte
 Dim stemp As Short
 Dim ftemp As Double

 'This timer fires every second or so

 'Driver or concept errors just show as error in a benign way
 On Error GoTo TPT_ERREXIT

 'Complete an SPI transaction - send two benign bytes and see what comes back
 cnt = 2
 buf(0) = buf(1) = &HFF&
 If (BHPMOD_SPI_Transaction(cnt, buf(0)) = 0) Then GoTo TPT_ERREXIT
 If (cnt <> 2) Then GoTo TPT_ERREXIT
 'The number is actually 11 bits, twos complement, left justified, so mask off unused bits
 buf(1) = buf(1) And &HE0&
 'Marshal bytes - device reports big endian, and the PC is little endian
 'Number is signed, although expected accurate numbers are all positive
 buf(2) = buf(0)
 stemp = BitConverter.ToInt16(buf, 1)
 'Now that we have our signed number, convert it to floating point and scale as required by the datasheet
 ftemp = stemp
 ftemp /= 32      'Bring back to 11-bit quantity
 ftemp *= 0.125   'Degrees per LSB
 'If the number is in the valid range, show green, otherwise yellow
 LED_Temperature.ForeColor = LED_COLOR_STATUS_GOOD
 If ((ftemp > 40) Or (ftemp < 10)) Then LED_Temperature.ForeColor = LED_COLOR_STATUS_ON
 'Display the number to the implied accuracy
 LED_Temperature.Text = "hex = " + LngToHexByte(buf(0)) + LngToHexByte(buf(1))
 LED_Temperature.Text = Format(ftemp, "0.0")
 'Check for sensible reading (ie more than absolute 0)
 If (ftemp < -273) Then LED_Temperature.Text = "THERMISTOR ?"
 'Normal exit
 Exit Sub

 'Problems get us here
TPT_ERREXIT:
 LED_Temperature.Text = "ERROR"
 LED_Temperature.ForeColor = LED_COLOR_STATUS_BAD
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'There are no user controls in this dialog

End Class