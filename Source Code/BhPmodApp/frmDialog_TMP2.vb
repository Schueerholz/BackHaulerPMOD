'---------------------------------------------------------------------------------------
'frmDialog_TMP2.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_TMP2

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------

'The I2C device address can be changed here
'This is the default as matches the default wiring of the peripheral
'Private so it applies only to this class and other private uses of this identifier are allowed
Private Const I2C_DEVICE_ADDRESS As Byte = &H4B&

'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_TMP2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_I2C
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Start looking for temperature sensor data
 TempPollTimer.Enabled = True
End Sub

Private Sub frmDialog_TMP2_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 TempPollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub TempPollTimer_Tick(sender As Object, e As EventArgs) Handles TempPollTimer.Tick
 Dim temp(4) As Byte
 Dim id As Byte
 Dim stemperature As Short
 Dim ftemperature As Double
 Dim datacnt As Byte

 'The poll timer fires every second as temperature changes only just so fast

 'Driver or concept errors just show as error in a benign way
 On Error GoTo TPT_ERREXIT

 'Get the device ID (subaddress 11) to be sure we are connected to the right device
 'Note that VB creates variables for the constants in the ByRef items, while other languages might not allow this
 id = 0
 datacnt = 1
 If (BHPMOD_I2C_Read(I2C_DEVICE_ADDRESS, 1, 11, datacnt, id) <> 1) Then GoTo TPT_ERREXIT
 If (datacnt <> 1) Then GoTo TPT_ERREXIT
 'Show what we got as an ID
 LED_DeviceID.ForeColor = LED_COLOR_STATUS_GOOD
 LED_DeviceID.Text = LngToHexByte(id)
 'See if we have the right ID, and if not caution the user and show error on temperature and leave
 If (id <> &HCB&) Then GoTo TPT_ERREXIT

 'Get the temperature (subaddress 0 and 1) to upper part of our array
 datacnt = 2
 If (BHPMOD_I2C_Read(I2C_DEVICE_ADDRESS, 1, 0, datacnt, temp(1)) <> 1) Then GoTo TPT_ERREXIT
 If (datacnt <> 2) Then GoTo TPT_ERREXIT
 'Marshal the bytes and bits to be a 16-bit number
 'We never asked for 16-bits, so only the upper 13-bits are valid by default, so mask off the flags in the lower bits (see part datasheet)
 'Mask bits
 temp(2) = temp(2) And &HF8&
 'Marshal bytes - device reports big endian, and the PC is little endian
 temp(0) = temp(2)
 'Use a .NET function get integer equivalent - this would be easy in C but a pain in VB with its variable range protection
 stemperature = BitConverter.ToInt16(temp, 0)

 'Convert temperature from LSB to degrees C
 'Looked at as 16-bits, the resolution is still 0.0078 degrees, even if our actual resolving power at 13-bits is a bigger number (see part datasheet)
 ftemperature = stemperature
 ftemperature *= 0.0078
 'Round to nearest degrees C
 stemperature = ftemperature

 'Display temperature
 LED_Temperature.ForeColor = LED_COLOR_STATUS_GOOD
 LED_Temperature.Text = Trim(Str(stemperature))

 'Normal exit
 Exit Sub

 'Problems get us here
TPT_ERREXIT:
 LED_DeviceID.ForeColor = LED_COLOR_STATUS_ON
 LED_Temperature.Text = "ERROR"
 LED_Temperature.ForeColor = LED_COLOR_STATUS_BAD
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

'There are no user controls in this dialog

End Class