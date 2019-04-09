'---------------------------------------------------------------------------------------
'frmDialog_DAC.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_DUALDAC

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------

'Keep track of the output status so we know about changes for tracking purposes
Private Setting_DACA As Short = 0
Private Setting_DACB As Short = 0

'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------

Private Sub frmDialog_DUALDAC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device 
 'This device really wants the clock to idle low (phase 0)
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_0)
 'Start the device with 0 outputs and wake it up
 WriteDAC(15, 0)
 DisplayVout()
End Sub

Private Sub frmDialog_DUALDAC_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Put the device back to sleep before leaving
 WriteDAC(14, 0)
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------

'Generalized register write routine for our device
'Note that in most places we use absolute numbers for the arguments - while not really good
'coding practice, this code is small and numbers help to follow along with a datasheet in this demonstration
'This routine assembles the control nibble (lower 4 bits) with the data value (lower 12 bits) to the form required by the DAC
Private Sub WriteDAC(ByVal Control As Byte, ByVal Data As Short)
 Dim buf(2) As Byte
 Dim dat As Short
 Control = Control And &HF&
 Control *= &H10&
 buf(0) = Control
 Data = Data And &H3FF&
 dat = Data * 4
 dat \= &H100&
 buf(0) += dat
 Data *= 4
 Data = Data And &HFF&
 buf(1) = Data
 BHPMOD_SPI_Transaction(2, buf(0))
End Sub

'Generalized write process to update both DAC outputs as the same time
Private Sub SetDACOutputs(ByVal A As Short, ByVal B As Short)
 'Write DAC A without updateing output
 WriteDAC(1, A)
 'Write DAC B and update both outputs
 WriteDAC(10, B)
End Sub

'Update the display of expected output voltages based on the global DAC setting values
'This assumes the reference is 3.3V (VCC, which could be rough but is about this)
'It is also assumed that the offset error has no impact at the ends of the scale
'although it probably in fact does (see datasheet) - remember this is just test and demo
Private Sub DisplayVout()
 Dim va As Double
 Dim vb As Double
 va = Setting_DACA
 va /= 1023
 va *= 3.3
 vb = Setting_DACB
 vb /= 1023
 vb *= 3.3
 LED_VoutA.Text = Format(va, "0.00") + " V"
 LED_VoutB.Text = Format(vb, "0.00") + " V"
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

Private Sub TrackBar_VoutA_Scroll(sender As Object, e As EventArgs) Handles Slider_VoutA.Scroll
 Dim diff As Short
 Dim newb As Short
 'This event could be triggered a number of times as the user moves the slider
 'Tracking updates the other slider with changes in this one
 'Note that a scroll event is not the same as a change event, 
 'so changing the other slider does not set off another event (in case that mattered)
 If (CheckBox_Track.Checked) Then
  diff = Slider_VoutA.Value - Setting_DACA
  newb = Slider_VoutB.Value + diff
  If (newb > 1023) Then newb = 1023
  If (newb < 0) Then newb = 0
  Slider_VoutB.Value = newb
 End If
 'Retain the settings for later tracking
 Setting_DACA = Slider_VoutA.Value
 Setting_DACB = Slider_VoutB.Value
 'Set the new values to the DACs  
 SetDACOutputs(Setting_DACA, Setting_DACB)
 'Show the expected values on the display
 DisplayVout()
End Sub

Private Sub TrackBar_VoutB_Scroll(sender As Object, e As EventArgs) Handles Slider_VoutB.Scroll
 Dim diff As Short
 Dim newa As Short
 'See comments with the above dual of this routine
 'We use two routines because one routine would be about as much code or more to sort it out at this level
 If (CheckBox_Track.Checked) Then
  diff = Slider_VoutB.Value - Setting_DACB
  newa = Slider_VoutA.Value + diff
  If (newa > 1023) Then newa = 1023
  If (newa < 0) Then newa = 0
  Slider_VoutA.Value = newa
 End If
 'Retain the settings for later tracking
 Setting_DACA = Slider_VoutA.Value
 Setting_DACB = Slider_VoutB.Value
 'Set the new values to the DACs  
 SetDACOutputs(Setting_DACA, Setting_DACB)
 'Show the expected values on the display
 DisplayVout()
End Sub

End Class