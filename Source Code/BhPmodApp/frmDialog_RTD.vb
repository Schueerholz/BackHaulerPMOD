'---------------------------------------------------------------------------------------
'frmDialog_RTD.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_RTD

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------

Private Sub frmDialog_RTD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 Dim buf(5) As Byte

 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 'Note there seems to be some inconsistency in the part datasheet on this point, 
 'but it is definitely an unusual configuration and works like this
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_1)
 'Configure the converter
 'Vbias on, auto conversion, 4 wire, not a fault detection cycle, 60Hz filter
 buf(0) = &H80&
 buf(1) = &HC0&
 BHPMOD_SPI_Transaction(2, buf(0))
 'Set the reading based fault thresholds for numbers unlikely to be seen unless there is a problem
 'This is somewhat application dependant, but we are assuming a casual desktop user doing an evaluation
 'Note that the format of all data registers has the LSB in bit 1
 buf(0) = &H83&
 buf(1) = &HFF&
 buf(2) = &H0&
 buf(3) = &H0&
 buf(4) = &HFE&
 BHPMOD_SPI_Transaction(5, buf(0))
 'Start looking for sensor data
 RTDPollTimer.Enabled = True
End Sub

Private Sub frmDialog_RTD_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 RTDPollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub RTDPollTimer_Tick(sender As Object, e As EventArgs) Handles RTDPollTimer.Tick
 Dim buf(3) As Byte
 Dim ireading As Integer
 Dim fault As Boolean = False
 Dim ftemp As Double

 'Any problems should send us to the error exit
 On Error GoTo RPT_ERREXIT

 'Read the data register
 buf(0) = &H1&
 buf(1) = &HFF&
 buf(2) = &HFF&
 BHPMOD_SPI_Transaction(3, buf(0))
 
 'If there is a fault indicated, go show error
 If (buf(2) And 1) Then GoTo RPT_ERREXIT

 'Otherwise collect the data to calculation variables
 ireading = buf(1)
 ireading *= 256
 ireading += buf(2)
 ireading \= 2

 'Convert to temperature in display form using approximation
 ftemp = ireading
 ftemp /= 32
 ftemp -= 256

 'Display the value in a sensible form
 LED_Temperature.Text = Format(ftemp, "0.0")
 LED_Temperature.ForeColor = LED_COLOR_STATUS_GOOD

 'Warn as estimation starts to get less accurate
 If ((ftemp > 70) Or (ftemp < -70)) Then LED_Temperature.ForeColor = LED_COLOR_STATUS_ON

 'Normal exit here
 Exit Sub

 'Problems get us here
RPT_ERREXIT:
 LED_Temperature.Text = "ERROR"
 LED_Temperature.ForeColor = LED_COLOR_STATUS_BAD
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'There are no user controls in this dialog

End Class