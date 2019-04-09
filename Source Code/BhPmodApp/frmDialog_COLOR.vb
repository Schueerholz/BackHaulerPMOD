'---------------------------------------------------------------------------------------
'frmDialog_COLOR.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_COLOR

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------

'The I2C device address can be changed here
'This is the default as matches the default wiring of the peripheral
'Private so it applies only to this class and other private uses of this identifier are allowed
Private Const I2C_DEVICE_ADDRESS As Byte = &H38&

'The mode control 2 register contains our enable and gain settings
Private ModeControl2 As Byte = &H10&

'Color value information to and from calculations
'Raw data bytes
Private ColorData(8) As Byte
'Raw data converted to 16 bit numbers
Private RawRed As UInt16
Private RawGreen As UInt16
Private RawBlue As UInt16
Private RawClear As UInt16
'Scaling values for relative sensitivities, calculated from experimental results for a given condition
'Specifically, these values perform well with an LCD computer monitor 
'The data are similar to the graph of relative sensitivity in the datasheet, but are affected by the
'specific environment to which they are scaled. The alignment to the graph is actually quite clear except 
'that it seems like red needs further enhancement to align with the human visual response to an LCD monitor.
Private Const SCALE_RED As Double = 0.345
Private Const SCALE_GREEN As Double = 1
Private Const SCALE_BLUE As Double = 0.59
Private Const SCALE_CLEAR As Double = 0.06
'Scaled data taking into account relative sensor characteristics
Private ScaledRed As UInt16
Private ScaledGreen As UInt16
Private ScaledBlue As UInt16
Private ScaledClear As UInt16

'Address definitions help clarify code a bit and can be used as arguments to certain routines
'Bitwise settings are still set absolute to help follow along with the datasheet
Private Const REG_SYSTEM_CONTROL As Byte = &H40&
Private Const REG_MODE_CONTROL_2 As Byte = &H42&
Private Const REG_RED As Byte = &H50&
Private Const REG_GREEN As Byte = &H52&
Private Const REG_BLUE As Byte = &H54&
Private Const REG_CLEAR As Byte = &H56&
Private Const REG_MFG_ID As Byte = &H92&

'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_COLOR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_I2C
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Reset the sensor
 BHPMOD_I2C_Write(I2C_DEVICE_ADDRESS, 1, REG_SYSTEM_CONTROL, 1, &H80&)
 Sleep(10)
 'Configure for normal operation
 'The default settings after reset are all good for us at this state
 'Start looking for sensor status
 ColorPollTimer.Enabled = True
End Sub

Private Sub frmDialog_COLOR_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 ColorPollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------

'Routine to complete the color data read and conversions to usable numbers
'Data are left in public variables for use by the caller
Private Sub ReadColors()
 Dim conv As Double

 'Get the color data from the sensor device
 BHPMOD_I2C_Read(I2C_DEVICE_ADDRESS, 1, REG_RED, 8, ColorData(0))

 'Collect the data into 16 bit form
 'We should do this in a way that does not assume endian order and can just follow the device specification
 RawRed = ColorData(1) * 256 + ColorData(0)
 RawGreen = ColorData(3) * 256 + ColorData(2)
 RawBlue = ColorData(5) * 256 + ColorData(4)
 RawClear = ColorData(7) * 256 + ColorData(6)

 'Construct the scaled forms
 conv = RawRed
 conv /= SCALE_RED
 If (conv > UInt16.MaxValue) Then conv = UInt16.MaxValue
 ScaledRed = conv
 conv = RawGreen
 conv /= SCALE_GREEN
 If (conv > UInt16.MaxValue) Then conv = UInt16.MaxValue
 ScaledGreen = conv
 conv = RawBlue
 conv /= SCALE_BLUE
 If (conv > UInt16.MaxValue) Then conv = UInt16.MaxValue
 ScaledBlue = conv
 conv = RawClear
 conv /= SCALE_CLEAR
 If (conv > UInt16.MaxValue) Then conv = UInt16.MaxValue
 ScaledClear = conv

End Sub

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub ColorPollTimer_Tick(sender As Object, e As EventArgs) Handles ColorPollTimer.Tick
 Dim mfgid As Byte
 Dim devid As Byte
 Dim level As Integer
 Dim lscale As UInt16 = &H10&
 'They never tell us how many bits the data have, so we assume 12 bits based on performance

 'The poll timer fires slower than the conversion rate on the device

 'Driver or concept errors just show as error in a benign way
 On Error GoTo CPT_ERREXIT

 'Get the device IDs to be sure we are connected to the right device
 'Note that VB creates variables for the constants in the ByRef items, while other languages might not allow this
 'Don't check the call success here so if the id does not come back right for any reason we can display similar to
 'how it is handled for SPI devices at this point (benignly showing a nonsense id of FF)
 mfgid = &HFF&
 BHPMOD_I2C_Read(I2C_DEVICE_ADDRESS, 1, REG_MFG_ID, 1, mfgid)
 devid = &HFF&
 BHPMOD_I2C_Read(I2C_DEVICE_ADDRESS, 1, REG_SYSTEM_CONTROL, 1, devid)
 devid = devid And &H3F&
 'Show what we got as an ID
 LED_MfgID.ForeColor = LED_COLOR_STATUS_GOOD
 LED_MfgID.Text = LngToHexByte(mfgid)
 LED_DeviceID.ForeColor = LED_COLOR_STATUS_GOOD
 LED_DeviceID.Text = LngToHexByte(devid)

 'See if we have the right IDs, and if not caution the user and show error and leave
 If ((mfgid <> &HE0&) Or (devid <> &HB&)) Then
  LED_MfgID.ForeColor = LED_COLOR_STATUS_BAD
  LED_DeviceID.ForeColor = LED_COLOR_STATUS_BAD
  GoTo CPT_ERREXIT
 End If

 'If the device is powered down, show indeterminate state and leave
 If (LED_DevicePowerState.Text <> "ACTIVE") Then GoTo CPT_NOSENSOREXIT

 'Get color sensor readings to globals
 ReadColors()
 'Populate the displays
 LED_RedLightNumeric.Text = RawRed
 LED_GreenLightNumeric.Text = RawGreen
 LED_BlueLightNumeric.Text = RawBlue
 LED_ClearLightNumeric.Text = RawClear
 'Apply scaled colors somehow to the background of the light displays
 'LED_RedLightDisplay.Text = ScaledRed
 level = ScaledRed / lscale
 If (level > 255) Then level = 255
 LED_RedLightDisplay.BackColor = Color.FromArgb(255, level, 0, 0)
 'LED_GreenLightDisplay.Text = ScaledGreen
 level = ScaledGreen / lscale
 If (level > 255) Then level = 255
 LED_GreenLightDisplay.BackColor = Color.FromArgb(255, 0, level, 0)
 'LED_BlueLightDisplay.Text = ScaledBlue
 level = ScaledBlue / lscale
 If (level > 255) Then level = 255
 LED_BlueLightDisplay.BackColor = Color.FromArgb(255, 0, 0, level)
 'LED_ClearLightDisplay.Text = ScaledClear
 level = ScaledClear / lscale
 If (level > 255) Then level = 255
 LED_ClearLightDisplay.BackColor = Color.FromArgb(255, level, level, level)

 'Display conditions for no error
 LED_DevicePowerState.ForeColor = LED_COLOR_STATUS_GOOD
 LED_SensorGain.ForeColor = LED_COLOR_STATUS_GOOD

 'Normal exit
 Exit Sub

 'Problems get us here
CPT_ERREXIT:
 LED_DevicePowerState.ForeColor = LED_COLOR_STATUS_GRAY
 LED_SensorGain.ForeColor = LED_COLOR_STATUS_GRAY
CPT_NOSENSOREXIT:
 LED_RedLightNumeric.Text = ""
 LED_GreenLightNumeric.Text = ""
 LED_BlueLightNumeric.Text = ""
 LED_ClearLightNumeric.Text = ""
 LED_RedLightDisplay.BackColor = LED_COLOR_STATUS_OFF
 LED_GreenLightDisplay.BackColor = LED_COLOR_STATUS_OFF
 LED_BlueLightDisplay.BackColor = LED_COLOR_STATUS_OFF
 LED_ClearLightDisplay.BackColor = LED_COLOR_STATUS_OFF
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

Private Sub LED_DevicePowerState_Click(sender As Object, e As EventArgs) Handles LED_DevicePowerState.Click
 'Change state setting 
 If (LED_DevicePowerState.Text = "POWER DOWN") Then
  LED_DevicePowerState.Text = "ACTIVE"
  ModeControl2 = ModeControl2 Or &H10&
 Else
  LED_DevicePowerState.Text = "POWER DOWN"
  ModeControl2 = ModeControl2 And &HEF&
 End If
 'Send new setting to sensor device
 BHPMOD_I2C_Write(I2C_DEVICE_ADDRESS, 1, REG_MODE_CONTROL_2, 1, ModeControl2)
End Sub

Private Sub LED_SensorGain_Click(sender As Object, e As EventArgs) Handles LED_SensorGain.Click
 'Retain control state other than gain
 ModeControl2 = ModeControl2 And &HFC&
 'Change setting, use OR to add in new gain
 Select Case (LED_SensorGain.Text)
  Case "1X"
   LED_SensorGain.Text = "2X"
   ModeControl2 = ModeControl2 Or 1
  Case "2X"
   LED_SensorGain.Text = "16X"
   ModeControl2 = ModeControl2 Or 2
 Case "16X"
   LED_SensorGain.Text = "1X"
   ModeControl2 = ModeControl2 Or 0
 End Select
 'Send new setting to sensor device
 BHPMOD_I2C_Write(I2C_DEVICE_ADDRESS, 1, REG_MODE_CONTROL_2, 1, ModeControl2)
End Sub

End Class