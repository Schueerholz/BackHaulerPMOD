'---------------------------------------------------------------------------------------
'frmDialog_QUADDAC.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_QUADDAC

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------

'Keep track of the output status so we know about changes for tracking purposes
Private Setting_DACA As UShort = 0
Private Setting_DACB As UShort = 0
Private Setting_DACC As UShort = 0
Private Setting_DACD As UShort = 0

'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_QUADDAC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device 
 'This device really wants the clock to idle low (phase 0)
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_0)
 'Select and power up internal reference 
 WriteDAC(&H6F&, 0)
 'Start the device with 0 outputs and power up all channels (write, update, power up)
 WriteDAC(&H3F&, 0)
 'Update outputs writes the DACs again, this time also synchronizing the user controls
 UpdateDACOutputs()
End Sub

Private Sub frmDialog_QUADDAC_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Put the device back to sleep before leaving
 WriteDAC(&H5F&, 0)
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------

'Generalized register write routine for our device
'Note that in most places we use absolute numbers for the arguments - while not really good
'coding practice, this code is small and numbers help to follow along with a datasheet in this demonstration
'This routine assembles the control/address byte with the data value (lower 16 bits) to the form required by the DAC
'The control byte should include the command and the address, generally with the convention that commands not
'using an address will use address 0xF (all DACs) - both the command and address must be valid
Private Sub WriteDAC(ByVal ControlAddress As Byte, ByVal Data As UInt16)
 Dim buf(3) As Byte
 Dim dat As UShort
 buf(0) = ControlAddress
 Data = Data And &H3FF&
 dat = Data * &H40&
 dat \= &H100&
 buf(1) = dat
 dat = Data And &HFF&
 buf(2) = dat
 BHPMOD_SPI_Transaction(3, buf(0))
End Sub

'Routine to update all DAC outputs and display results
Private Sub UpdateDACOutputs()
 Dim v As Double

 'Collect and retain user slider values for updates and later tracking
 Setting_DACA = Slider_VoutA.Value
 Setting_DACB = Slider_VoutB.Value
 Setting_DACC = Slider_VoutC.Value
 Setting_DACD = Slider_VoutD.Value

 'Write DACs without updating outputs
 WriteDAC(0, Setting_DACA)
 WriteDAC(1, Setting_DACB)
 WriteDAC(2, Setting_DACC)
 WriteDAC(3, Setting_DACD)
 'Update all outputs
 WriteDAC(&H1F&, 0)

'Update the display of expected output voltages based on the global DAC setting values
'This assumes the reference is 2.5V (internal reference)
'It is also assumed that the offset error has no impact at the ends of the scale
'although it probably in fact does (see datasheet) - remember this is just test and demo
 v = Setting_DACA
 v /= 1023
 v *= 2.5
 LED_VoutA.Text = Format(v, "0.00") + " V"
 v = Setting_DACB
 v /= 1023
 v *= 2.5
 LED_VoutB.Text = Format(v, "0.00") + " V"
 v = Setting_DACC
 v /= 1023
 v *= 2.5
 LED_VoutC.Text = Format(v, "0.00") + " V"
 v = Setting_DACD
 v /= 1023
 v *= 2.5
 LED_VoutD.Text = Format(v, "0.00") + " V"

End Sub

'Routine to get a new slider value that respects the slider limits
'Because we are dealing with a slider of known maximum value, we can assume everything fits in a short
Private Function NewSliderValue(ByVal OldSliderValue As Short, ByVal SliderDelta As Short) As Short
 NewSliderValue = OldSliderValue + SliderDelta
 If (NewSliderValue > 1023) Then NewSliderValue = 1023
 If (NewSliderValue < 0) Then NewSliderValue = 0
End Function

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'Slider handlers -
'These events could be triggered a number of times as the user moves a slider
'Tracking updates the other sliders with changes in one slider
'Note that a scroll event is not the same as a change event, 
'so changing the other slider does not set off another event (in case that mattered)
'We use seperate routines because one routine would be about as much code or more to sort it out at this level

'---------------------------------------------------------------------------------------

Private Sub TrackBar_VoutA_Scroll(sender As Object, e As EventArgs) Handles Slider_VoutA.Scroll
 Dim delta As Short

 'Do tracking
 If (CheckBox_Track.Checked) Then
  delta = Slider_VoutA.Value - Setting_DACA
  Slider_VoutB.Value = NewSliderValue(Slider_VoutB.Value, delta)
  Slider_VoutC.Value = NewSliderValue(Slider_VoutC.Value, delta)
  Slider_VoutD.Value = NewSliderValue(Slider_VoutD.Value, delta)
 End If

 'Set the new values to the DACs and display
 UpdateDACOutputs()
End Sub

Private Sub TrackBar_VoutB_Scroll(sender As Object, e As EventArgs) Handles Slider_VoutB.Scroll
 Dim delta As Short

 'Do tracking
 If (CheckBox_Track.Checked) Then
  delta = Slider_VoutB.Value - Setting_DACB
  Slider_VoutA.Value = NewSliderValue(Slider_VoutA.Value, delta)
  Slider_VoutC.Value = NewSliderValue(Slider_VoutC.Value, delta)
  Slider_VoutD.Value = NewSliderValue(Slider_VoutD.Value, delta)
 End If

 'Set the new values to the DACs and display
 UpdateDACOutputs()
End Sub

Private Sub Slider_VoutC_Scroll(sender As Object, e As EventArgs) Handles Slider_VoutC.Scroll
 Dim delta As Short

 'Do tracking
 If (CheckBox_Track.Checked) Then
  delta = Slider_VoutC.Value - Setting_DACC
  Slider_VoutA.Value = NewSliderValue(Slider_VoutA.Value, delta)
  Slider_VoutB.Value = NewSliderValue(Slider_VoutB.Value, delta)
  Slider_VoutD.Value = NewSliderValue(Slider_VoutD.Value, delta)
 End If

 'Set the new values to the DACs and display
 UpdateDACOutputs()
End Sub

Private Sub Slider_VoutD_Scroll(sender As Object, e As EventArgs) Handles Slider_VoutD.Scroll
 Dim delta As Short

 'Do tracking
 If (CheckBox_Track.Checked) Then
  delta = Slider_VoutD.Value - Setting_DACD
  Slider_VoutA.Value = NewSliderValue(Slider_VoutA.Value, delta)
  Slider_VoutB.Value = NewSliderValue(Slider_VoutB.Value, delta)
  Slider_VoutC.Value = NewSliderValue(Slider_VoutC.Value, delta)
 End If

 'Set the new values to the DACs and display
 UpdateDACOutputs()
End Sub

End Class