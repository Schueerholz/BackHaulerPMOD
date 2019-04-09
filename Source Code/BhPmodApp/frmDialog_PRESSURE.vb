'---------------------------------------------------------------------------------------
'frmDialog_PRESSURE.VB
'
'This is a dialog form for a specific PMOD peripheral.
'
'---------------------------------------------------------------------------------------

Public Class frmDialog_PRESSURE

'---------------------------------------------------------------------------------------
'Local Public Variables (Application Private)
'---------------------------------------------------------------------------------------


'---------------------------------------------------------------------------------------
'Module Entry And Exit Functions
'---------------------------------------------------------------------------------------

Private Sub frmDialog_PRESSURE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 'Configure the PMOD connector
 PresentConfiguration = PMOD_CONFIGURATION_SPI
 SetPresentConfiguration()
 DisplayPresentConfiguration()
 'Set the SPI clock phase for this device
 'This device seems to prefer the clock to idle high - we did not test if this matters
 BHPMOD_SPI_SetClockPhase(SPI_CLOCK_PHASE_3)
 'Start looking for sensor data
 PressurePollTimer.Enabled = True
End Sub

Private Sub frmDialog_PRESSURE_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
 'Stop polling for data
 PressurePollTimer.Enabled = False
 'Remove the configuration 
 ConfigurePassive()
End Sub

'---------------------------------------------------------------------------------------
'Private General Subroutines
'---------------------------------------------------------------------------------------

'Generalized register write routine for our device
'Note that in most places we use absolute numbers for the arguments - while not really good
'coding practice, this code is small and numbers help to follow along with a datasheet in this demonstration
'By using the register address alone, the R/W bit (MSB) is always low (write)
'The next MSB (bit 6) controls 1 = auto inc address, 0 = do not increment, and with only one byte to write we don't care
Private Sub WriteDeviceRegister(ByVal RegAddr As Byte, ByVal RegVal As Byte)
 Dim buf(2) As Byte
 buf(0) = RegAddr
 buf(1) = RegVal
 BHPMOD_SPI_Transaction(2, buf(0))
End Sub

'Generalized register read routine for our device
'This is the dual of write, and sets the R/W bit high
'The value read is returned by reference
Private Sub ReadDeviceRegister(ByVal RegAddr As Byte, ByRef RegVal As Byte)
 Dim buf(2) As Byte
 buf(0) = RegAddr Or &H80&
 buf(1) = &HFF&
 BHPMOD_SPI_Transaction(2, buf(0))
 RegVal = buf(1)
End Sub

'---------------------------------------------------------------------------------------
'Handler For Polling Timer
'---------------------------------------------------------------------------------------

Private Sub PressurePollTimer_Tick(sender As Object, e As EventArgs) Handles PressurePollTimer.Tick
 Dim reading(6) As Byte
 Dim id As Byte
 Dim i As Byte
 Dim ipressure As Integer
 Dim stemperature As Short
 Dim fpressure As Double
 Dim ftemperature As Double
 Dim datacnt As Byte

 'The poll timer fires every second as temperature changes only just so fast

 'Driver or concept errors just show as error in a benign way
 On Error GoTo PPT_ERREXIT

 'Get the device ID (subaddress 15) to be sure we are connected to the right device
 id = 0
 ReadDeviceRegister(15, id)
 'Show what we got as an ID
 LED_DeviceID.ForeColor = LED_COLOR_STATUS_GOOD
 LED_DeviceID.Text = LngToHexByte(id)
 'See if we have the right ID, and if not caution the user and show error and leave
 If (id <> &HBD&) Then GoTo PPT_ERREXIT

 'If the device is powered down, show indeterminate state and leave
 If (LED_DevicePowerState.Text <> "ACTIVE") Then
  LED_Pressure.Text = "----"
  LED_Pressure.ForeColor = LED_COLOR_STATUS_ON
  LED_Temperature.Text = "----"
  LED_Temperature.ForeColor = LED_COLOR_STATUS_ON
  Exit Sub
 End If

 'Get the sensor data
 'The FIFO is not enabled by default, and lots of other similarly fancy features are left out
 'This timer fires ones per second and reads data known at that time, which will usually be new since the last second
 'In any case a running update is presented in a simple mannner
 'Collect 5 bytes of data (6 in transaction including address, starting at register 28H, read and auto increment set
 datacnt = 6
 For i = 1 To 5
  reading(i) = &HFF&
 Next i
 reading(0) = &HE8&
 If (BHPMOD_SPI_Transaction(datacnt, reading(0)) <> 1) Then GoTo PPT_ERREXIT
 If (datacnt <> 6) Then GoTo PPT_ERREXIT
 'Marshal the 24-bit pressure reading to a signed 32-bit number
 'The bytes are in little endian order from the device, which is consistent with the PC, except one more byte is needed to interpret get 32 bits
 reading(0) = 0
 ipressure = BitConverter.ToInt32(reading, 0)
 ipressure /= 256
 'Marshal the temperature bytes to be a 16-bit number 
 'The bytes are in little endian order from the device, which is consistent with the PC
 stemperature = BitConverter.ToInt16(reading, 4)

 'Scale the readings as described in the datasheet and tech notes (the datasheet says nothing about temperature, at least the version we have)
 fpressure = ipressure
 fpressure /= 4096
 ftemperature = stemperature
 ftemperature /= 480
 ftemperature += 42.5

 'Display sensor data to the accuracy implied on the datasheet
 'Scale the pressure based on the user unit selection
 'The device produces millibar (mbar)
 'These conversions are based on one atmosphere, per wikipedia
 Select Case LED_Units.Text
  Case "BAR"
   LED_Pressure.Text = Format(fpressure / 1000, "0.0000")
  Case "ATM"
   LED_Pressure.Text = Format(fpressure / 1013.25, "0.000")
  Case "PSI"
   fpressure /= 1013.25
   fpressure *= 14.69595
   LED_Pressure.Text = Format(fpressure, "0.00")
 End Select

 'Temperature is a relatively low accuracy degrees C reading
 LED_Temperature.Text = Format(ftemperature, "0")
 'Show readings are good
 LED_Pressure.ForeColor = LED_COLOR_STATUS_GOOD
 LED_Temperature.ForeColor = LED_COLOR_STATUS_GOOD

 'Normal exit
 Exit Sub

 'Problems get us here
PPT_ERREXIT:
 LED_DeviceID.ForeColor = LED_COLOR_STATUS_ON
 LED_Pressure.Text = "ERROR"
 LED_Pressure.ForeColor = LED_COLOR_STATUS_BAD
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
 Dim ctrl_reg(5) As Byte

 'If we are in power down, try to go to active 
 If (LED_DevicePowerState.Text = "POWER DOWN") Then
  'Upon enabling, set the various bits of the configuration registers for our use
  'Note that VB creates variables for the constants in the ByRef items, while other languages might not allow this
  'We start with the first control register subaddress and set the MSB auto increment bit
  ctrl_reg(1) = &HA4&   'Sampling at 7Hz (to refresh the averager quicker) and with data read protection,  4-wire SPI
  ctrl_reg(2) = &H8&    'Request I2C disabled, in case something tries to use it, note ref pressure defaults to 0
  ctrl_reg(3) = &H0&    'Leave data ready output disabled as by default - could change if we wanted to use it
  ctrl_reg(4) = &H0&    'More interrupt control bits, leave at defaults for now
  datacnt = 5
  ctrl_reg(0) = &H60&   'Address of CTRL_REG1 with auto increment bit set
  If (BHPMOD_SPI_Transaction(datacnt, ctrl_reg(0)) <> 1) Then Exit Sub
  If (datacnt <> 5) Then Exit Sub
  'If all appears successful show running, allowing the timer to actually read and interpret data
  LED_DevicePowerState.ForeColor = LED_COLOR_STATUS_GOOD
  LED_DevicePowerState.Text = "ACTIVE"
  Exit Sub
 End If

 'We are not in power down, so it must be we want to go to power down
 'If we are in some error state, this would be the right thing to try on click anyway
 'If this fails, just leave here and let the timer put us in that error state
 'Set the configuration register power control bit to power down, and others don't really care
 ctrl_reg(1) = &H24&   'Same as above, but powered down
 ctrl_reg(2) = &H8&
 ctrl_reg(3) = &H0&
 ctrl_reg(4) = &H0&
 datacnt = 5
 ctrl_reg(0) = &H60&   'Address of CTRL_REG1 with auto increment bit set
 If (BHPMOD_SPI_Transaction(datacnt, ctrl_reg(0)) <> 1) Then Exit Sub
 If (datacnt <> 5) Then Exit Sub
 'Show shutdown - even if there was an error, these are all good reasons to tell timer to stop reading data
 LED_DevicePowerState.ForeColor = LED_COLOR_STATUS_GOOD
 LED_DevicePowerState.Text = "POWER DOWN"
End Sub

Private Sub LED_Units_Click(sender As Object, e As EventArgs) Handles LED_Units.Click
 'Select in what units we want to display (valid on the next update)
 Select Case LED_Units.Text
  Case "BAR"
   LED_Units.Text = "ATM"
  Case "ATM"
   LED_Units.Text = "PSI"
  Case "PSI"
   LED_Units.Text = "BAR"
 End Select
End Sub

End Class