'---------------------------------------------------------------------------------------
'frmDialog_RFPWR.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_RFPWR

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------

'Reference and LSB information for conversion
'We are looking at millivolts, and the data will be provided to us as a 12-bit unsigned number
Public Const ADC_REFERENCE_mV As Double = 3300
Public Const ADC_LSB_12BIT_mV As Double = ADC_REFERENCE_mV / 4096
'From the datasheet, 1LSB = VREF/(4096 * 32mV/dB) dB
Public Const ADC_LSB_12BIT_dB As Double = ADC_LSB_12BIT_mV / 32

'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------

Private Sub frmDialog_RFPWR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_0)
 'Start looking for sensor data
 PowerPollTimer.Enabled = True
End Sub

Private Sub frmDialog_RFPWR_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 PowerPollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------



'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub PowerPollTimer_Tick(sender As Object, e As EventArgs) Handles PowerPollTimer.Tick
 Dim buf(3) As Byte
 Dim bufcnt As Byte
 Dim sreading As UShort
 Dim freading As Double

 'Any problems should send us to the error exit
 On Error GoTo PPT_ERREXIT

 'Read the device
 'Lowering CS (CONV) captures a voltage at the sensor, raising CONV starts the conversion
 'The value read while CS is low is the result of the prior conversion
 buf(1) = buf(2) = &HFF&
 bufcnt = 2
 If (BHPMOD_SPI_Transaction(bufcnt, buf(1)) <> 1) Then GoTo PPT_ERREXIT
 If (bufcnt <> 2) Then GoTo PPT_ERREXIT

 'Marshal the data into a 16-bit unsigned number
 'The upper 12 bits will have data, the lower 4 bits will be 0
 buf(0) = buf(2)
 sreading = BitConverter.ToUInt16(buf, 0)
 'We could use 16-bits and change all our LSB defintions, which is a common approach
 'But to keep things consistent with the datasheet, shift the active bits right
 sreading \= &H10&

 'If the reading is pegged for some reason, it definately does not represent real data
 If ((sreading = 0) Or (sreading = 4095)) Then GoTo PPT_ERREXIT

 'Translate to LSB
 freading = sreading
 freading *= ADC_LSB_12BIT_dB

 'The datasheet says the notional y intercept is -40dB
 'y = mx + b would be dB = ADC_LSB_12BIT_dB * reading - 40
 'So we need to subtract 40 from the above
 'Note this is different than the minimum output expected, which is about -34dB
 freading -= 40

 'Display the result - at best we are good to one dB
 LED_RFPower.Text = Format(freading, "0")
 LED_RFPower.ForeColor = LED_COLOR_STATUS_GOOD

 'Normal exit here
 Exit Sub

 'Problems get us here
PPT_ERREXIT:
 LED_RFPower.Text = "ERROR"
 LED_RFPower.ForeColor = LED_COLOR_STATUS_BAD
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'There are no user controls in this dialog

End Class