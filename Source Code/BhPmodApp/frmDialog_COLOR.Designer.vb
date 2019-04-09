<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_COLOR
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_COLOR))
        Me.ColorPollTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LED_ClearLightDisplay = New System.Windows.Forms.Label()
        Me.LED_ClearLightNumeric = New System.Windows.Forms.Label()
        Me.LED_BlueLightDisplay = New System.Windows.Forms.Label()
        Me.LED_BlueLightNumeric = New System.Windows.Forms.Label()
        Me.LED_GreenLightDisplay = New System.Windows.Forms.Label()
        Me.LED_GreenLightNumeric = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LED_SensorGain = New System.Windows.Forms.Label()
        Me.LED_MfgID = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LED_DevicePowerState = New System.Windows.Forms.Label()
        Me.LED_RedLightDisplay = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LED_DeviceID = New System.Windows.Forms.Label()
        Me.LED_RedLightNumeric = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'ColorPollTimer
        '
        Me.ColorPollTimer.Interval = 500
        '
        'Group_Device_Description
        '
        Me.Group_Device_Description.Controls.Add(Me.Label20)
        Me.Group_Device_Description.Controls.Add(Me.Label19)
        Me.Group_Device_Description.Controls.Add(Me.Label14)
        Me.Group_Device_Description.Controls.Add(Me.Label13)
        Me.Group_Device_Description.Controls.Add(Me.Label4)
        Me.Group_Device_Description.Controls.Add(Me.Label3)
        Me.Group_Device_Description.Controls.Add(Me.Label2)
        Me.Group_Device_Description.Controls.Add(Me.Label1)
        Me.Group_Device_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Description.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Description.Location = New System.Drawing.Point(12, 12)
        Me.Group_Device_Description.Name = "Group_Device_Description"
        Me.Group_Device_Description.Size = New System.Drawing.Size(570, 187)
        Me.Group_Device_Description.TabIndex = 144
        Me.Group_Device_Description.TabStop = False
        Me.Group_Device_Description.Text = "Device Description"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Yellow
        Me.Label20.Location = New System.Drawing.Point(21, 140)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(462, 16)
        Me.Label20.TabIndex = 150
        Me.Label20.Text = "-> Scaled visual is manually tuned to roughly match an LCD computer monitor"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Yellow
        Me.Label19.Location = New System.Drawing.Point(21, 156)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(469, 16)
        Me.Label19.TabIndex = 149
        Me.Label19.Text = "-> The gain setting will need to be adjusted for specific ambient light condition" & _
    "s"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Yellow
        Me.Label14.Location = New System.Drawing.Point(21, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(397, 16)
        Me.Label14.TabIndex = 148
        Me.Label14.Text = "-> Interrupt thresholds or operation are not set or used by this code"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Yellow
        Me.Label13.Location = New System.Drawing.Point(21, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(465, 32)
        Me.Label13.TabIndex = 147
        Me.Label13.Text = "-> Color information is relative and is not calibrated, so estimates are possible" & _
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     but more information would be needed to calculate color temperature"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(21, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(257, 16)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "-> The PMOD interface configuration is I2C"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(21, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(495, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The peripheral provides a BH1745NUC color sensitive ambient light sensor chip"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(21, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(458, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is AP1708-COLOR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(21, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(357, 16)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "-> Peripheral manufacturer is Allied Component Works, LLC"
        '
        'Group_Device_Controls
        '
        Me.Group_Device_Controls.Controls.Add(Me.Label18)
        Me.Group_Device_Controls.Controls.Add(Me.Label17)
        Me.Group_Device_Controls.Controls.Add(Me.Label16)
        Me.Group_Device_Controls.Controls.Add(Me.Label15)
        Me.Group_Device_Controls.Controls.Add(Me.Label12)
        Me.Group_Device_Controls.Controls.Add(Me.Label11)
        Me.Group_Device_Controls.Controls.Add(Me.LED_ClearLightDisplay)
        Me.Group_Device_Controls.Controls.Add(Me.LED_ClearLightNumeric)
        Me.Group_Device_Controls.Controls.Add(Me.LED_BlueLightDisplay)
        Me.Group_Device_Controls.Controls.Add(Me.LED_BlueLightNumeric)
        Me.Group_Device_Controls.Controls.Add(Me.LED_GreenLightDisplay)
        Me.Group_Device_Controls.Controls.Add(Me.LED_GreenLightNumeric)
        Me.Group_Device_Controls.Controls.Add(Me.Label8)
        Me.Group_Device_Controls.Controls.Add(Me.LED_SensorGain)
        Me.Group_Device_Controls.Controls.Add(Me.LED_MfgID)
        Me.Group_Device_Controls.Controls.Add(Me.Label10)
        Me.Group_Device_Controls.Controls.Add(Me.Label6)
        Me.Group_Device_Controls.Controls.Add(Me.LED_DevicePowerState)
        Me.Group_Device_Controls.Controls.Add(Me.LED_RedLightDisplay)
        Me.Group_Device_Controls.Controls.Add(Me.Label9)
        Me.Group_Device_Controls.Controls.Add(Me.LED_DeviceID)
        Me.Group_Device_Controls.Controls.Add(Me.LED_RedLightNumeric)
        Me.Group_Device_Controls.Controls.Add(Me.Label7)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(12, 205)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 346)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Yellow
        Me.Label18.Location = New System.Drawing.Point(406, 207)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 16)
        Me.Label18.TabIndex = 180
        Me.Label18.Text = "Clear"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(406, 179)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 16)
        Me.Label17.TabIndex = 179
        Me.Label17.Text = "Blue"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Yellow
        Me.Label16.Location = New System.Drawing.Point(406, 151)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 16)
        Me.Label16.TabIndex = 178
        Me.Label16.Text = "Green"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Yellow
        Me.Label15.Location = New System.Drawing.Point(406, 123)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 16)
        Me.Label15.TabIndex = 177
        Me.Label15.Text = "Red"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(285, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 16)
        Me.Label12.TabIndex = 176
        Me.Label12.Text = "ADC Readings"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(168, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 16)
        Me.Label11.TabIndex = 175
        Me.Label11.Text = "Scaled Visual"
        '
        'LED_ClearLightDisplay
        '
        Me.LED_ClearLightDisplay.BackColor = System.Drawing.Color.Gray
        Me.LED_ClearLightDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_ClearLightDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_ClearLightDisplay.ForeColor = System.Drawing.Color.Aqua
        Me.LED_ClearLightDisplay.Location = New System.Drawing.Point(171, 201)
        Me.LED_ClearLightDisplay.Name = "LED_ClearLightDisplay"
        Me.LED_ClearLightDisplay.Size = New System.Drawing.Size(115, 26)
        Me.LED_ClearLightDisplay.TabIndex = 174
        Me.LED_ClearLightDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_ClearLightNumeric
        '
        Me.LED_ClearLightNumeric.BackColor = System.Drawing.Color.Gray
        Me.LED_ClearLightNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_ClearLightNumeric.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_ClearLightNumeric.ForeColor = System.Drawing.Color.Lime
        Me.LED_ClearLightNumeric.Location = New System.Drawing.Point(288, 201)
        Me.LED_ClearLightNumeric.Name = "LED_ClearLightNumeric"
        Me.LED_ClearLightNumeric.Size = New System.Drawing.Size(115, 26)
        Me.LED_ClearLightNumeric.TabIndex = 173
        Me.LED_ClearLightNumeric.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_BlueLightDisplay
        '
        Me.LED_BlueLightDisplay.BackColor = System.Drawing.Color.Gray
        Me.LED_BlueLightDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_BlueLightDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_BlueLightDisplay.ForeColor = System.Drawing.Color.Aqua
        Me.LED_BlueLightDisplay.Location = New System.Drawing.Point(171, 173)
        Me.LED_BlueLightDisplay.Name = "LED_BlueLightDisplay"
        Me.LED_BlueLightDisplay.Size = New System.Drawing.Size(115, 26)
        Me.LED_BlueLightDisplay.TabIndex = 170
        Me.LED_BlueLightDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_BlueLightNumeric
        '
        Me.LED_BlueLightNumeric.BackColor = System.Drawing.Color.Gray
        Me.LED_BlueLightNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_BlueLightNumeric.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_BlueLightNumeric.ForeColor = System.Drawing.Color.Lime
        Me.LED_BlueLightNumeric.Location = New System.Drawing.Point(288, 173)
        Me.LED_BlueLightNumeric.Name = "LED_BlueLightNumeric"
        Me.LED_BlueLightNumeric.Size = New System.Drawing.Size(115, 26)
        Me.LED_BlueLightNumeric.TabIndex = 169
        Me.LED_BlueLightNumeric.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_GreenLightDisplay
        '
        Me.LED_GreenLightDisplay.BackColor = System.Drawing.Color.Gray
        Me.LED_GreenLightDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_GreenLightDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_GreenLightDisplay.ForeColor = System.Drawing.Color.Aqua
        Me.LED_GreenLightDisplay.Location = New System.Drawing.Point(171, 145)
        Me.LED_GreenLightDisplay.Name = "LED_GreenLightDisplay"
        Me.LED_GreenLightDisplay.Size = New System.Drawing.Size(115, 26)
        Me.LED_GreenLightDisplay.TabIndex = 166
        Me.LED_GreenLightDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_GreenLightNumeric
        '
        Me.LED_GreenLightNumeric.BackColor = System.Drawing.Color.Gray
        Me.LED_GreenLightNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_GreenLightNumeric.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_GreenLightNumeric.ForeColor = System.Drawing.Color.Lime
        Me.LED_GreenLightNumeric.Location = New System.Drawing.Point(288, 145)
        Me.LED_GreenLightNumeric.Name = "LED_GreenLightNumeric"
        Me.LED_GreenLightNumeric.Size = New System.Drawing.Size(115, 26)
        Me.LED_GreenLightNumeric.TabIndex = 165
        Me.LED_GreenLightNumeric.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(168, 236)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 16)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "Sensor Gain"
        '
        'LED_SensorGain
        '
        Me.LED_SensorGain.BackColor = System.Drawing.Color.Gray
        Me.LED_SensorGain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_SensorGain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_SensorGain.ForeColor = System.Drawing.Color.Lime
        Me.LED_SensorGain.Location = New System.Drawing.Point(171, 252)
        Me.LED_SensorGain.Name = "LED_SensorGain"
        Me.LED_SensorGain.Size = New System.Drawing.Size(232, 26)
        Me.LED_SensorGain.TabIndex = 163
        Me.LED_SensorGain.Text = "1X"
        Me.LED_SensorGain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_MfgID
        '
        Me.LED_MfgID.BackColor = System.Drawing.Color.Gray
        Me.LED_MfgID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_MfgID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_MfgID.ForeColor = System.Drawing.Color.Lime
        Me.LED_MfgID.Location = New System.Drawing.Point(171, 42)
        Me.LED_MfgID.Name = "LED_MfgID"
        Me.LED_MfgID.Size = New System.Drawing.Size(115, 26)
        Me.LED_MfgID.TabIndex = 162
        Me.LED_MfgID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(168, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 16)
        Me.Label10.TabIndex = 161
        Me.Label10.Text = "Mfg ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(168, 287)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 16)
        Me.Label6.TabIndex = 159
        Me.Label6.Text = "Device Power State"
        '
        'LED_DevicePowerState
        '
        Me.LED_DevicePowerState.BackColor = System.Drawing.Color.Gray
        Me.LED_DevicePowerState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_DevicePowerState.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_DevicePowerState.ForeColor = System.Drawing.Color.Lime
        Me.LED_DevicePowerState.Location = New System.Drawing.Point(171, 303)
        Me.LED_DevicePowerState.Name = "LED_DevicePowerState"
        Me.LED_DevicePowerState.Size = New System.Drawing.Size(232, 26)
        Me.LED_DevicePowerState.TabIndex = 158
        Me.LED_DevicePowerState.Text = "POWER DOWN"
        Me.LED_DevicePowerState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_RedLightDisplay
        '
        Me.LED_RedLightDisplay.BackColor = System.Drawing.Color.Gray
        Me.LED_RedLightDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_RedLightDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_RedLightDisplay.ForeColor = System.Drawing.Color.Aqua
        Me.LED_RedLightDisplay.Location = New System.Drawing.Point(171, 117)
        Me.LED_RedLightDisplay.Name = "LED_RedLightDisplay"
        Me.LED_RedLightDisplay.Size = New System.Drawing.Size(115, 26)
        Me.LED_RedLightDisplay.TabIndex = 157
        Me.LED_RedLightDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(169, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(235, 16)
        Me.Label9.TabIndex = 156
        Me.Label9.Text = "----------------- Light Sensors ------------------"
        '
        'LED_DeviceID
        '
        Me.LED_DeviceID.BackColor = System.Drawing.Color.Gray
        Me.LED_DeviceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_DeviceID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_DeviceID.ForeColor = System.Drawing.Color.Lime
        Me.LED_DeviceID.Location = New System.Drawing.Point(288, 42)
        Me.LED_DeviceID.Name = "LED_DeviceID"
        Me.LED_DeviceID.Size = New System.Drawing.Size(115, 26)
        Me.LED_DeviceID.TabIndex = 155
        Me.LED_DeviceID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_RedLightNumeric
        '
        Me.LED_RedLightNumeric.BackColor = System.Drawing.Color.Gray
        Me.LED_RedLightNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_RedLightNumeric.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_RedLightNumeric.ForeColor = System.Drawing.Color.Lime
        Me.LED_RedLightNumeric.Location = New System.Drawing.Point(288, 117)
        Me.LED_RedLightNumeric.Name = "LED_RedLightNumeric"
        Me.LED_RedLightNumeric.Size = New System.Drawing.Size(115, 26)
        Me.LED_RedLightNumeric.TabIndex = 154
        Me.LED_RedLightNumeric.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(285, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 16)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Device ID"
        '
        'frmDialog_COLOR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(596, 564)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_COLOR"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For ACW Color Light Sensor"
        Me.Group_Device_Description.ResumeLayout(False)
        Me.Group_Device_Description.PerformLayout()
        Me.Group_Device_Controls.ResumeLayout(False)
        Me.Group_Device_Controls.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents ColorPollTimer As System.Windows.Forms.Timer
    Friend WithEvents Group_Device_Description As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_Device_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LED_DeviceID As System.Windows.Forms.Label
    Friend WithEvents LED_RedLightNumeric As System.Windows.Forms.Label
    Friend WithEvents LED_RedLightDisplay As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LED_DevicePowerState As System.Windows.Forms.Label
    Friend WithEvents LED_ClearLightDisplay As System.Windows.Forms.Label
    Friend WithEvents LED_ClearLightNumeric As System.Windows.Forms.Label
    Friend WithEvents LED_BlueLightDisplay As System.Windows.Forms.Label
    Friend WithEvents LED_BlueLightNumeric As System.Windows.Forms.Label
    Friend WithEvents LED_GreenLightDisplay As System.Windows.Forms.Label
    Friend WithEvents LED_GreenLightNumeric As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LED_SensorGain As System.Windows.Forms.Label
    Friend WithEvents LED_MfgID As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label

End Class
