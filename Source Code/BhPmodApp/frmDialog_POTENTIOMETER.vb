'---------------------------------------------------------------------------------------
'frmDialog_POTENTIOMETER.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_POTENTIOMETER

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------

Private Sub frmDialog_POTENTIOMETER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 'The datasheet is confusing on this point, with diagrams suggesting clock phase 3 should be used
 'However, if clock phase 3 is used, the datasheet does show we will lose the first leading 0, and we did (we got 3 as shown)
 'If clock phase 0 is used, we should clock in the first leading zero and still meet the timing requirements of the ADC, 
 'which is actually the CS falling edge to first clock falling edge, regardless of the clock start state, despite the confusing way it is drawn
 'Either method is actually acceptable, but the software should aware the data will be shifted
 'We use clock phase 0 so that the data processing follows the text of the datasheet, and is consistent with the majority of SPI slave devices
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_0)
 'Start looking for sensor data
 PotPollTimer.Enabled = True
End Sub

Private Sub frmDialog_POTENTIOMETER_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 PotPollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------



'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub PotPollTimer_Tick(sender As Object, e As EventArgs) Handles PotPollTimer.Tick
 Dim buf(2) As Byte
 Dim value As UInt32

 'General coverage error exit
 On Error GoTo PPT_ERREXIT

 'Collect a reading, generally starting the next conversion as well
 buf(0) = &HFF&
 buf(1) = &HFF&
 If (BHPMOD_SPI_Transaction(2, buf(0)) <> 1) Then GoTo PPT_ERREXIT

 'If the reading was successful, the highest bits will be 0
 If ((buf(0) And &HF0&) <> 0) Then GoTo PPT_ERREXIT

 'The reading looks like it is potentially good
 'Construct the value from the data bytes (see datasheet)
 value = buf(0)
 value *= 256
 value += buf(1)
 value \= 4

 'Update the displays
 LED_PositionValue.Text = Trim(Str(value))
 LED_PositionValue.ForeColor = LED_COLOR_STATUS_GOOD
 ProgressBar_RelativeLevel.Value = value

 'Normal exit here
 Exit Sub

 'Problems get us here
PPT_ERREXIT:
 LED_PositionValue.Text = "ERROR"
 LED_PositionValue.ForeColor = LED_COLOR_STATUS_BAD
 ProgressBar_RelativeLevel.Value = 0
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'There are no user controls in this dialog

End Class