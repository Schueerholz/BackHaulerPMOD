'---------------------------------------------------------------------------------------
'frmDialog_COMPAIR.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_COMPAIR

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------

Private Sub frmDialog_COMPAIR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_0)
 'Start looking for sensor data
 SensorADCPollTimer.Enabled = True
End Sub

Private Sub frmDialog_COMPAIR_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 SensorADCPollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------



'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub SensorADCPollTimer_Tick(sender As Object, e As EventArgs) Handles SensorADCPollTimer.Tick
 Dim buf(3) As Byte
 Dim reading As Int32
 Dim mv As Double
 Dim psi As Double

 'General coverage error exit
 On Error GoTo SAPT_ERREXIT

 'Collect a reading, generally starting the next conversion as well
 buf(0) = &HFF&
 buf(1) = &HFF&
 buf(2) = &HFF&
 If (BHPMOD_SPI_Transaction(3, buf(0)) <> 1) Then GoTo SAPT_ERREXIT

 'Should be a positive number, and not saturated
 If ((buf(0) And &HF0&) <> &H20&) Then GoTo SAPT_ERREXIT

 'Get reading from bytes read
 reading = buf(0) And &HF&
 reading *= 256
 reading += buf(1)
 reading *= 256
 reading += buf(2) And &HE0&
 reading \= &H20&

 'Translate to millivolts
 mv = reading
 mv *= 150 / (2 ^ 15 - 1)
 LED_ADCReading.Text = Format(mv, "0.0 mV")

 'Translate to PSI
 psi = mv * 150 / 85.8
 LED_ADCReading.Text += " => " + Format(psi, "0.0 PSI")

 'Show on level bar as rounded number
 If (psi > 150) Then psi = 150
 If (psi < 0) Then psi = 0
 ProgressBar_AirPressure.Value = psi

 'Normal exit here
 Exit Sub

 'Problems get us here
SAPT_ERREXIT:
 LED_ADCReading.Text = "ERROR"
 LED_ADCReading.ForeColor = LED_COLOR_STATUS_BAD
 ProgressBar_AirPressure.Value = 0
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'There are no user controls in this dialog

End Class