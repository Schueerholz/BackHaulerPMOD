<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_HUMITURE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_HUMITURE))
        Me.HumiturePollTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.CheckBox_InternalHeater = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LED_DevicePowerState = New System.Windows.Forms.Label()
        Me.LED_Humidity = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LED_DeviceID = New System.Windows.Forms.Label()
        Me.LED_Temperature = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'HumiturePollTimer
        '
        Me.HumiturePollTimer.Interval = 1000
        '
        'Group_Device_Description
        '
        Me.Group_Device_Description.Controls.Add(Me.Label4)
        Me.Group_Device_Description.Controls.Add(Me.Label3)
        Me.Group_Device_Description.Controls.Add(Me.Label2)
        Me.Group_Device_Description.Controls.Add(Me.Label1)
        Me.Group_Device_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Description.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Description.Location = New System.Drawing.Point(12, 12)
        Me.Group_Device_Description.Name = "Group_Device_Description"
        Me.Group_Device_Description.Size = New System.Drawing.Size(570, 105)
        Me.Group_Device_Description.TabIndex = 144
        Me.Group_Device_Description.TabStop = False
        Me.Group_Device_Description.Text = "Device Description"
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
        Me.Label3.Size = New System.Drawing.Size(461, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The peripheral provides an HTS221 humidity and temperature sensor chip"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(21, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(484, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is AP1606-HUMITURE"
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
        Me.Group_Device_Controls.Controls.Add(Me.CheckBox_InternalHeater)
        Me.Group_Device_Controls.Controls.Add(Me.Label6)
        Me.Group_Device_Controls.Controls.Add(Me.LED_DevicePowerState)
        Me.Group_Device_Controls.Controls.Add(Me.LED_Humidity)
        Me.Group_Device_Controls.Controls.Add(Me.Label9)
        Me.Group_Device_Controls.Controls.Add(Me.LED_DeviceID)
        Me.Group_Device_Controls.Controls.Add(Me.LED_Temperature)
        Me.Group_Device_Controls.Controls.Add(Me.Label8)
        Me.Group_Device_Controls.Controls.Add(Me.Label7)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(12, 123)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 245)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'CheckBox_InternalHeater
        '
        Me.CheckBox_InternalHeater.AutoSize = True
        Me.CheckBox_InternalHeater.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_InternalHeater.Location = New System.Drawing.Point(410, 205)
        Me.CheckBox_InternalHeater.Name = "CheckBox_InternalHeater"
        Me.CheckBox_InternalHeater.Size = New System.Drawing.Size(114, 20)
        Me.CheckBox_InternalHeater.TabIndex = 160
        Me.CheckBox_InternalHeater.Text = "Internal Heater"
        Me.CheckBox_InternalHeater.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(160, 184)
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
        Me.LED_DevicePowerState.Location = New System.Drawing.Point(163, 200)
        Me.LED_DevicePowerState.Name = "LED_DevicePowerState"
        Me.LED_DevicePowerState.Size = New System.Drawing.Size(232, 26)
        Me.LED_DevicePowerState.TabIndex = 158
        Me.LED_DevicePowerState.Text = "POWER DOWN"
        Me.LED_DevicePowerState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_Humidity
        '
        Me.LED_Humidity.BackColor = System.Drawing.Color.Gray
        Me.LED_Humidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_Humidity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_Humidity.ForeColor = System.Drawing.Color.Lime
        Me.LED_Humidity.Location = New System.Drawing.Point(163, 95)
        Me.LED_Humidity.Name = "LED_Humidity"
        Me.LED_Humidity.Size = New System.Drawing.Size(232, 26)
        Me.LED_Humidity.TabIndex = 157
        Me.LED_Humidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(160, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 16)
        Me.Label9.TabIndex = 156
        Me.Label9.Text = "Relative Humidity (%)"
        '
        'LED_DeviceID
        '
        Me.LED_DeviceID.BackColor = System.Drawing.Color.Gray
        Me.LED_DeviceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_DeviceID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_DeviceID.ForeColor = System.Drawing.Color.Lime
        Me.LED_DeviceID.Location = New System.Drawing.Point(163, 43)
        Me.LED_DeviceID.Name = "LED_DeviceID"
        Me.LED_DeviceID.Size = New System.Drawing.Size(232, 26)
        Me.LED_DeviceID.TabIndex = 155
        Me.LED_DeviceID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_Temperature
        '
        Me.LED_Temperature.BackColor = System.Drawing.Color.Gray
        Me.LED_Temperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_Temperature.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_Temperature.ForeColor = System.Drawing.Color.Lime
        Me.LED_Temperature.Location = New System.Drawing.Point(163, 148)
        Me.LED_Temperature.Name = "LED_Temperature"
        Me.LED_Temperature.Size = New System.Drawing.Size(232, 26)
        Me.LED_Temperature.TabIndex = 154
        Me.LED_Temperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(160, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 16)
        Me.Label8.TabIndex = 153
        Me.Label8.Text = "Temperature (Degrees C)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(160, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(235, 16)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Device ID (Should be BC if connected)"
        '
        'frmDialog_HUMITURE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(595, 379)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_HUMITURE"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For ACW Humiture Sensor"
        Me.Group_Device_Description.ResumeLayout(False)
        Me.Group_Device_Description.PerformLayout()
        Me.Group_Device_Controls.ResumeLayout(False)
        Me.Group_Device_Controls.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents HumiturePollTimer As System.Windows.Forms.Timer
    Friend WithEvents Group_Device_Description As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_Device_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LED_DeviceID As System.Windows.Forms.Label
    Friend WithEvents LED_Temperature As System.Windows.Forms.Label
    Friend WithEvents LED_Humidity As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LED_DevicePowerState As System.Windows.Forms.Label
    Friend WithEvents CheckBox_InternalHeater As System.Windows.Forms.CheckBox

End Class
