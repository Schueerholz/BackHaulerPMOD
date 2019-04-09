'---------------------------------------------------------------------------------------
'frmDialog_ALS.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_ALS

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_ALS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 'The default might do ok, but this device appears to prefer the clock to idle high
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_3)
 'Start looking for light sensor data
 LightPollTimer.Enabled = True
End Sub

Private Sub frmDialog_ALS_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 LightPollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub LightPollTimer_Tick(sender As Object, e As EventArgs) Handles LightPollTimer.Tick
 Dim cnt As Byte
 Dim buf(4) As Byte
 Dim adcreading As UInteger

 'This timer fires every 100mS or so
 'The first reading will be bogus but will bring the device out of power down mode
 'and will be quickly replaced with a good reading on the next poll

 'Driver or concept errors just show as error in a benign way
 On Error GoTo LPT_ERREXIT

 'Complete an SPI transaction - send two benign bytes and see what comes back
 cnt = 2
 buf(0) = buf(1) = &HFF&
 If (BHPMOD_SPI_Transaction(cnt, buf(0)) = 0) Then GoTo LPT_ERREXIT
 If (cnt <> 2) Then GoTo LPT_ERREXIT
 'Marshal bytes - device reports big endian, and the PC is little endian
 'Numbers are unsigned, so this is relatively straight forward - 
 'Reading variable must simply be large enough to hold that big of a positive number
 adcreading = buf(0)
 adcreading *= &H100&
 adcreading += buf(1)
 'From on the datasheet, we should be able to shift right by 4 bits and get what we are looking for, a one byte reading
 adcreading /= &H10&
 'Just in case, prevent an unecessary error
 If (adcreading > 255) Then adcreading = 255

 'Display light level
 LED_LightLevelDisplay.BackColor = Color.FromArgb(255, adcreading, adcreading, adcreading)
 LED_LightLevelNumeric.ForeColor = LED_COLOR_STATUS_GOOD
 LED_LightLevelNumeric.Text = Trim(Str(adcreading))

 'Normal exit
 Exit Sub

 'Problems get us here
LPT_ERREXIT:
 LED_LightLevelNumeric.Text = "ERROR"
 LED_LightLevelNumeric.ForeColor = LED_COLOR_STATUS_BAD
 LED_LightLevelDisplay.ForeColor = Color.Black
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'There are no user controls in this dialog

End Class