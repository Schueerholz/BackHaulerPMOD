'---------------------------------------------------------------------------------------
'frmDialog_HUMITURE.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_HUMITURE

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------

'The I2C device address can be changed here
'This is the default as matches the default wiring of the peripheral
'Private so it applies only to this class and other private uses of this identifier are allowed
Private Const I2C_DEVICE_ADDRESS As Byte = &H5F&

'Calibration variables
'This values are as defined in the datasheet and read from the device
'The values are installed by the device manufacturer (ST Microelectronics) to characterize
'the output developed for two known input stimulus values for each quantity 
'It is implied that these can be used defined a linear response over the specified operating range
Private H0_rH_x2 As Short
Private H1_rH_x2 As Short
Private T0_degC_x8 As Short
Private T1_degC_x8 As Short
Private H0_T0_OUT As Short
Private H1_T0_OUT As Short
Private T0_OUT As Short
Private T1_OUT As Short
'The following are the constants of a line fitting the above stored points
'The humidity is of course relative to temperature, but the implication is that the rH
'line is the same for any temperature, we assume based on the moisture absorbed in the sensor
'Yet rH appears to be calibrated at one temperature
'The line fit of y = mx + b for the following
'Temperature degC = mt * reading + bt 
'Humidity rH = mh * reading + bh
Private mh As Double
Private bh As Double
Private mt As Double
Private bt As Double

'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------
 
Private Sub frmDialog_HUMITURE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_I2C
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Start looking for sensor data
 HumiturePollTimer.Enabled = True
End Sub

Private Sub frmDialog_HUMITURE_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 HumiturePollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------

'Read the calibration values from the device
'Return true/false for pass/fail
Private Function ReadCal() As Boolean
 Dim cal(16) As Byte
 Dim datacnt As Byte
 Dim x0 As Double
 Dim x1 As Double
 Dim y0 As Double
 Dim y1 As Double

 'Success by default
 ReadCal = True

 'Attempt to read the calibration
 'Start at the base of the calibration registers and auto increment
 datacnt = 16
 If (BHPMOD_I2C_Read(I2C_DEVICE_ADDRESS, 1, &HB0&, datacnt, cal(0)) <> 1) Then ReadCal = False
 If (datacnt <> 16) Then ReadCal = False
 If (ReadCal = False) Then Exit Function

 'If we got the data, marshal the bytes into cal variables
 H0_rH_x2 = cal(0)
 H1_rH_x2 = cal(1)
 T0_degC_x8 = cal(5) And 3
 T0_degC_x8 *= &H100&
 T0_degC_x8 += cal(2)
 T1_degC_x8 = cal(5) And 12
 T1_degC_x8 \= 4
 T1_degC_x8 *= &H100&
 T1_degC_x8 += cal(3)
 H0_T0_OUT = BitConverter.ToInt16(cal, 6)
 H1_T0_OUT = BitConverter.ToInt16(cal, 10)
 T0_OUT = BitConverter.ToInt16(cal, 12)
 T1_OUT = BitConverter.ToInt16(cal, 14)

 'MsgBox(Str(H0_rH_x2) + vbCrLf + Str(H1_rH_x2) + vbCrLf + Str(T0_degC_x8) + vbCrLf + Str(T1_degC_x8) + vbCrLf + Str(H0_T0_OUT) + vbCrLf + Str(H1_T0_OUT) + vbCrLf + Str(T0_OUT) + vbCrLf + Str(T1_OUT))

 'Get linear fit coefficients for humidity
 y0 = H0_rH_x2
 y0 /= 2
 y1 = H1_rH_x2
 y1 /= 2
 x0 = H0_T0_OUT
 x1 = H1_T0_OUT
 If (x0 = x1) Then ReadCal = False
 If (ReadCal = False) Then Exit Function
 mh = (y1 - y0) / (x1 - x0)
 bh = y0 - mt * x0

 'Get linear fit coefficients for temperature
 y0 = T0_degC_x8
 y0 /= 8
 y1 = T1_degC_x8
 y1 /= 8
 x0 = T0_OUT
 x1 = T1_OUT
 If (x0 = x1) Then ReadCal = False
 If (ReadCal = False) Then Exit Function
 mt = (y1 - y0) / (x1 - x0)
 bt = y0 - mt * x0

End Function

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub HumiturePollTimer_Tick(sender As Object, e As EventArgs) Handles HumiturePollTimer.Tick
 Dim reading(4) As Byte
 Dim id As Byte
 Dim shumidity As Short
 Dim stemperature As Short
 Dim fhumidity As Double
 Dim ftemperature As Double
 Dim datacnt As Byte

 'The poll timer fires every second as temperature changes only just so fast

 'Driver or concept errors just show as error in a benign way
 On Error GoTo HPT_ERREXIT

 'Get the device ID (subaddress 15) to be sure we are connected to the right device
 'Note that VB creates variables for the constants in the ByRef items, while other languages might not allow this
 'Don't check the call success here so if the id does not come back right for any reason we can display similar 
 'to how it is handled for SPI devices at this point (benignly showing a nonsense id of FF)
 id = &HFF&
 BHPMOD_I2C_Read(I2C_DEVICE_ADDRESS, 1, 15, 1, id)
 'Show what we got as an ID
 LED_DeviceID.ForeColor = LED_COLOR_STATUS_GOOD
 LED_DeviceID.Text = LngToHexByte(id)
 'See if we have the right ID, and if not caution the user and show error and leave
 If (id <> &HBC&) Then GoTo HPT_ERREXIT

 'If the device is powered down, show indeterminate state and leave
 If (LED_DevicePowerState.Text <> "ACTIVE") Then
  LED_Humidity.Text = "----"
  LED_Humidity.ForeColor = LED_COLOR_STATUS_ON
  LED_Temperature.Text = "----"
  LED_Temperature.ForeColor = LED_COLOR_STATUS_ON
  Exit Sub
 End If

 'Get the sensor data
 'This will read the present known data, which may or may not be newer than the last reading of the registers.
 'The update rate here (timer) is about one second, which is more than fast enough for such data in the atmosphere 
 'But the data ready status is not examined, meaning if the sample rate in the part is slow enough,
 'then the data may not be new since the last time we read it, just valid at the time it was generated.
 'We typically have the data generated at 1Hz or faster (ie not in one shot) so the data will usually
 'be new versus the last reading, and we do not have to make an effort to begin a new sample.  It will 
 'at least appear to be 1Hz updates to the user.  This is appropriate for the present use case, but begining  
 'a new sample from code and examining data ready would allow our reading to be more synchronized with 
 'some other outside event, if there were such a thing that we cared about.  
 'Collect 4 bytes of data, starting at register 28H, auto increment MSB set
 datacnt = 4
 If (BHPMOD_I2C_Read(I2C_DEVICE_ADDRESS, 1, &HA8&, datacnt, reading(0)) <> 1) Then GoTo HPT_ERREXIT
 If (datacnt <> 4) Then GoTo HPT_ERREXIT
 'Marshal the bytes and bits to be a 16-bit numbers
 'The bytes are in little endian order from the device, which is consistent with the PC
 shumidity = BitConverter.ToInt16(reading, 0)
 stemperature = BitConverter.ToInt16(reading, 2)

 'Scale the readings by the lines defined in the calibration
 fhumidity = shumidity
 fhumidity *= mh
 fhumidity += bh
 ftemperature = stemperature
 ftemperature *= mt
 ftemperature += bt

 'Display sensor data to the accuracy implied on the datasheet
 LED_Humidity.Text = Format(fhumidity, "0")
 LED_Temperature.Text = Format(ftemperature, "0.0")
 If (CheckBox_InternalHeater.Checked) Then
  LED_Humidity.ForeColor = Color.Pink
  LED_Temperature.ForeColor = Color.Pink
 Else
  LED_Humidity.ForeColor = LED_COLOR_STATUS_GOOD
  LED_Temperature.ForeColor = LED_COLOR_STATUS_GOOD
 End If

 'Normal exit
 Exit Sub

 'Problems get us here
HPT_ERREXIT:
 LED_DeviceID.ForeColor = LED_COLOR_STATUS_ON
 LED_Humidity.Text = "ERROR"
 LED_Humidity.ForeColor = LED_COLOR_STATUS_BAD
 LED_Temperature.Text = "ERROR"
 LED_Temperature.ForeColor = LED_COLOR_STATUS_BAD
 LED_DevicePowerState.Text = "DEVICE ERROR"
 LED_DevicePowerState.ForeColor = LED_COLOR_STATUS_ON
End Sub

'---------------------------------------------------------------------------------------
'Handlers For User Controls
'---------------------------------------------------------------------------------------

Private Sub LED_DevicePowerState_Click(sender As Object, e As EventArgs) Handles LED_DevicePowerState.Click
 Dim datacnt As Byte
 Dim ctrl_reg(4) As Byte

 'If we are in power down, try to go to active 
 If (LED_DevicePowerState.Text = "POWER DOWN") Then
  'Upon enabling, set the various bits of the configuration registers for our use
  'Note that VB creates variables for the constants in the ByRef items, while other languages might not allow this
  'We start with the first control register subaddress and set the MSB auto increment bit
  ctrl_reg(1) = &H86&   'Sampling at 7Hz (to refresh the averager quicker) and with data read protection
  ctrl_reg(2) = &H0&    'Do not set any of these bits, based on mode selected above
  ctrl_reg(3) = &H0&    'Leave data ready output disabled as by default - could change if we wanted to use it
  datacnt = 3
  If (BHPMOD_I2C_Write(I2C_DEVICE_ADDRESS, 1, &HA0&, datacnt, ctrl_reg(1)) <> 1) Then Exit Sub
  If (datacnt <> 3) Then Exit Sub
  'Read the calibration
  If (Not ReadCal()) Then Exit Sub
  'If all appears successful show running, allowing the timer to actually read and interpret data
  CheckBox_InternalHeater.Enabled = True
  LED_DevicePowerState.ForeColor = LED_COLOR_STATUS_GOOD
  LED_DevicePowerState.Text = "ACTIVE"
  Exit Sub
 End If

 'We are not in power down, so it must be we want to go to power down
 'If we are in some error state, this would be the right thing to try on click anyway
 'If this fails, just leave here and let the timer put us in that error state
 'Set the configuration register power control bit to power down, and others don't really care
 ctrl_reg(1) = &H5&   'Same as above but just in power down setting
 ctrl_reg(2) = &H0&   'This includes heater off
 ctrl_reg(3) = &H0&
 datacnt = 3
 If (BHPMOD_I2C_Write(I2C_DEVICE_ADDRESS, 1, &HA0&, datacnt, ctrl_reg(1)) <> 1) Then Exit Sub
 If (datacnt <> 3) Then Exit Sub
 'Show shutdown - even if there was an error, these are all good reasons to tell timer to stop reading data
 CheckBox_InternalHeater.Enabled = False
 CheckBox_InternalHeater.Checked = False
 LED_DevicePowerState.ForeColor = LED_COLOR_STATUS_GOOD
 LED_DevicePowerState.Text = "POWER DOWN"
End Sub

Private Sub CheckBox_InternalHeater_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_InternalHeater.CheckedChanged
 Dim datacnt As Byte
 Dim ctrl_reg2 As Byte
 'If someone has already disabled this control, then leave here
 If (Not CheckBox_InternalHeater.Enabled) Then Exit Sub
 'Change CTRL_REG2 based on check setting
 If (CheckBox_InternalHeater.Checked) Then
  datacnt = 1
  ctrl_reg2 = 2
  BHPMOD_I2C_Write(I2C_DEVICE_ADDRESS, 1, &H21&, datacnt, ctrl_reg2)
 Else
  datacnt = 1
  ctrl_reg2 = 0
  BHPMOD_I2C_Write(I2C_DEVICE_ADDRESS, 1, &H21&, datacnt, ctrl_reg2)
 End If
End Sub

End Class