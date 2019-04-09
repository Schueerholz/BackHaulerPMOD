'---------------------------------------------------------------------------------------
'frmDialog_SDADC.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_SDADC

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------

'Reference and LSB information for conversion
'We are looking at millivolts, and the data will be provided to us as a 32-bit signed number
'This is a function of our choices, even though the actual resolving power and what we can get out of it is only 24 bits
'Looking at it in 32 bits changes nothing (assuming the computational word size does not cause rounding errors)
'The important thing is that we can't expect the resolution of the finished number to be better than implied by 24 bits
'In reality, depending on external circuitry, the actual validity of the converted input will probably be not even 24 bits
'The developer should display or use data with these limitations in mind, regardless of the size of the data word in use
Public Const ADC_REFERENCE_mV As Double = 3300
Public Const ADC_LSB_32BIT_mV As Double = ADC_REFERENCE_mV / (2 ^ 32)
Public Const ADC_LSB_RESOLUTION_mV As Double = ADC_REFERENCE_mV / (2 ^ 24)
'For temperature we are basing this information on the datasheet formula Tk = (24-bit reading) * Vref / 1570
'For our 32-bit reading, we should multiply by 256/256 so that we get Tk = (32-bit reading) * Vref / (1570 * 256)
Public Const ADC_LSB_32BIT_K As Double = ADC_REFERENCE_mV / (1000 * 1570 * 256)

'A variable to keep track of the channel presently being read
'Start out of range as the initial data will be unknown
'Account for out of range or unknown in the timer routine
Public PresentChannel As Byte = 5

'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------

Private Sub frmDialog_SDADC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_0)
 'Start looking for sensor data
 VoltagePollTimer.Enabled = True
End Sub

Private Sub frmDialog_SDADC_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 VoltagePollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------

'This transaction routine accomplishes two things - read the data from the last conversion, and set the ADC for the next conversion
'These things could be done in two different steps, with the rising chip select starting a conversion for the then present
'configuration, but this method will produce faster results more cleanly at all levels
'
'The write portion of the transaction writes the convereter settings
'The settings here detault to 1x mode for full calibration and easier reading, along with various other default settings
'The argument requests the specific channel, 0 to 4 with 4 being temperature, not necessarily directly related to bits in the settings word
'The channel here is always the single ended option, channel input to common (COM) per the datasheet
'This will start a new conversion with the new settings 
'The conversion status can be checked as described in the datasheet, or we can just wait long enough to know it will be complete
'
'The read portion of the transaction reads the data word from the ADC and interpret it as it relates to the prior conversion
'This routine is a function that returns an indication of results as follows 
Public Const ADCREAD_INCOMPLETE As Byte = 0
Public Const ADCREAD_VALID As Byte = 1
Public Const ADCREAD_OVER_RANGE As Byte = 2
Public Const ADCREAD_UNDER_RANGE As Byte = 3
'The data bits are transformed to a 32-bit signed integer and returned by reference
'There are actually 28 data bits, even if only the upper 24 contain meaningful data
'The impact of the lower bits depends only on how they are used by the caller
'Using sub-lsb data does not impact the resolution of the converter
Private Function ADCTransaction(ByRef ReadingValue As Integer, ByVal NextChannel As Byte)
 Dim buf(4) As Byte
 Dim reading(4) As Byte
 Dim bufcnt As Byte
 Dim status As Byte
 Dim upperbits As Byte

 'Default return value
 ADCTransaction = ADCREAD_INCOMPLETE

 'Setup the write data in the buffer
 'Defaults
 buf(0) = buf(1) = buf(2) = buf(3) = &HFF&
 'Bits of command byte 0 = 1011 <channel> for single ended
 buf(0) = &HB0&
 Select Case NextChannel
  Case 1
   buf(0) += 8
  Case 2
   buf(0) += 1
  Case 3
   buf(0) += 9
 End Select
 'Bits of select mode byte = 10000xxx for most, 1100xxxx for temperature, sets 50/60 reject, 1x speed 
 buf(1) = &H87&
 If (NextChannel = 4) Then buf(1) = &HCF&

 'Write the buffer and at the same time read data back to the same buffer
 'If this fails, we don't really know what happened to the write data, but we do know the read data are not valid
 bufcnt = 4
 If (BHPMOD_SPI_Transaction(bufcnt, buf(0)) <> 1) Then Exit Function
 If (bufcnt <> 4) Then Exit Function

 'We got data, first interpret the upper bits to see if a special condition exists
 status = buf(0) \ &H10&
 If (status And 8) Then Exit Function 'Conversion not complete
 If (status And 4) Then Exit Function 'This should be 0, so if not then the data are bogus
 ADCTransaction = ADCREAD_VALID       'Note by above the EOC bit is already 0, so reading is valid unless the following
 If (status = 0) Then ADCTransaction = ADCREAD_UNDER_RANGE
 If (status = 3) Then ADCTransaction = ADCREAD_OVER_RANGE
 If (ADCTransaction <> ADCREAD_VALID) Then Exit Function

 'Got a valid reading, marshal the data here
 'The first set step is to get the bits in the right place and the bytes in little endian order
 'This requires a bit more math than should be necessary, strictly to satisfy VB type checking - this would be much easier in C
 reading(0) = (buf(3) And &H1F&) * 8
 upperbits = (buf(3) And &HE0&) \ &H20&
 reading(1) = (buf(2) And &H1F&) * 8 + upperbits
 upperbits = (buf(2) And &HE0&) \ &H20&
 reading(2) = (buf(1) And &H1F&) * 8 + upperbits
 upperbits = (buf(1) And &HE0&) \ &H20&
 reading(3) = (buf(0) And &H1F&) * 8 + upperbits
 'Use a .NET function to put these bytes into a signed integer
 ReadingValue = BitConverter.ToInt32(reading, 0)

End Function

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub VoltagePollTimer_Tick(sender As Object, e As EventArgs) Handles VoltagePollTimer.Tick
 Dim next_channel As Byte
 Dim reading_status As Byte
 Dim ireading As Integer
 Dim fvolt As Double
 Dim ftemp As Double
 Dim voltstr As String
 Dim tempstr As String
 Dim display_color As Color

 'Any problems should send us to the error exit
 On Error GoTo VPT_ERREXIT

 'Read the prior conversion and set the next conversion
 next_channel = PresentChannel + 1
 If (next_channel > 4) Then next_channel = 0
 reading_status = ADCTransaction(ireading, next_channel)
 If (reading_status = ADCREAD_INCOMPLETE) Then GoTo VPT_ERREXIT

 'Translate the reading to a display message
 'This effort is agnostic about what is being read
 fvolt = ireading
 fvolt *= ADC_LSB_32BIT_mV
 ftemp = ireading
 ftemp *= ADC_LSB_32BIT_K
 ftemp -= 273
 'Defaults should never display
 voltstr = "UNKNOWN"
 tempstr = "UNKNOWN"
 display_color = LED_COLOR_STATUS_BAD
 'Create what should display
 Select Case reading_status
  Case ADCREAD_VALID
   voltstr = Format(fvolt, "0.0")
   tempstr = Format(ftemp, "0")
   display_color = LED_COLOR_STATUS_GOOD
  Case ADCREAD_OVER_RANGE
   voltstr = "OVER RANGE"
   tempstr = "OVER RANGE"
   display_color = LED_COLOR_STATUS_ON
  Case ADCREAD_UNDER_RANGE
   voltstr = "UNDER RANGE"
   tempstr = "UNDER RANGE"
   display_color = LED_COLOR_STATUS_ON
 End Select

 'Write the information to the display for the present channel
 'This will do nothing if the present channel is not valid
 Select Case PresentChannel
  Case 0
   LED_VoltageCh0.Text = voltstr
   LED_VoltageCh0.ForeColor = display_color
  Case 1
   LED_VoltageCh1.Text = voltstr
   LED_VoltageCh1.ForeColor = display_color
  Case 2
   LED_VoltageCh2.Text = voltstr
   LED_VoltageCh2.ForeColor = display_color
  Case 3
   LED_VoltageCh3.Text = voltstr
   LED_VoltageCh3.ForeColor = display_color
  Case 4
   LED_Temperature.Text = tempstr
   LED_Temperature.ForeColor = display_color
 End Select

 'Move the present channel to the conversion in process now
 PresentChannel = next_channel

 'Normal exit here
 Exit Sub

 'Problems get us here
VPT_ERREXIT:
 LED_VoltageCh0.Text = "ERROR"
 LED_VoltageCh0.ForeColor = LED_COLOR_STATUS_BAD
 LED_VoltageCh1.Text = "ERROR"
 LED_VoltageCh1.ForeColor = LED_COLOR_STATUS_BAD
 LED_VoltageCh2.Text = "ERROR"
 LED_VoltageCh2.ForeColor = LED_COLOR_STATUS_BAD
 LED_VoltageCh3.Text = "ERROR"
 LED_VoltageCh3.ForeColor = LED_COLOR_STATUS_BAD
 LED_Temperature.Text = "ERROR"
 LED_Temperature.ForeColor = LED_COLOR_STATUS_BAD
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'There are no user controls in this dialog

End Class