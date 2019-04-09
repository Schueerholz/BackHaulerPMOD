<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_COMPAIR
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_COMPAIR))
    Me.SensorADCPollTimer = New System.Windows.Forms.Timer(Me.components)
    Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.ProgressBar_AirPressure = New System.Windows.Forms.ProgressBar()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LED_ADCReading = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Group_Device_Description.SuspendLayout()
    Me.Group_Device_Controls.SuspendLayout()
    Me.SuspendLayout()
    '
    'SensorADCPollTimer
    '
    Me.SensorADCPollTimer.Interval = 1000
    '
    'Group_Device_Description
    '
    Me.Group_Device_Description.Controls.Add(Me.Label10)
    Me.Group_Device_Description.Controls.Add(Me.Label5)
    Me.Group_Device_Description.Controls.Add(Me.Label4)
    Me.Group_Device_Description.Controls.Add(Me.Label3)
    Me.Group_Device_Description.Controls.Add(Me.Label2)
    Me.Group_Device_Description.Controls.Add(Me.Label1)
    Me.Group_Device_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Group_Device_Description.ForeColor = System.Drawing.Color.Aqua
    Me.Group_Device_Description.Location = New System.Drawing.Point(12, 12)
    Me.Group_Device_Description.Name = "Group_Device_Description"
    Me.Group_Device_Description.Size = New System.Drawing.Size(570, 135)
    Me.Group_Device_Description.TabIndex = 144
    Me.Group_Device_Description.TabStop = False
    Me.Group_Device_Description.Text = "Device Description"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.ForeColor = System.Drawing.Color.Yellow
    Me.Label5.Location = New System.Drawing.Point(21, 92)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(429, 16)
    Me.Label5.TabIndex = 146
    Me.Label5.Text = "-> The sensor has shown good approximate results but is not calibrated"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.ForeColor = System.Drawing.Color.Yellow
    Me.Label4.Location = New System.Drawing.Point(21, 60)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(259, 16)
    Me.Label4.TabIndex = 145
    Me.Label4.Text = "-> The PMOD interface configuration is SPI"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.ForeColor = System.Drawing.Color.Yellow
    Me.Label3.Location = New System.Drawing.Point(21, 76)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(473, 16)
    Me.Label3.TabIndex = 144
    Me.Label3.Text = "-> This peripheral includes an absolute air pressure sensor and an LTC2433-1  "
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Yellow
    Me.Label2.Location = New System.Drawing.Point(21, 44)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(473, 16)
    Me.Label2.TabIndex = 143
    Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is AP1708-COMPAIR"
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
    Me.Group_Device_Controls.Controls.Add(Me.Label8)
    Me.Group_Device_Controls.Controls.Add(Me.Label6)
    Me.Group_Device_Controls.Controls.Add(Me.ProgressBar_AirPressure)
    Me.Group_Device_Controls.Controls.Add(Me.Label7)
    Me.Group_Device_Controls.Controls.Add(Me.LED_ADCReading)
    Me.Group_Device_Controls.Controls.Add(Me.Label9)
    Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
    Me.Group_Device_Controls.Location = New System.Drawing.Point(12, 153)
    Me.Group_Device_Controls.Name = "Group_Device_Controls"
    Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 142)
    Me.Group_Device_Controls.TabIndex = 149
    Me.Group_Device_Controls.TabStop = False
    Me.Group_Device_Controls.Text = "Device Controls"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.ForeColor = System.Drawing.Color.Yellow
    Me.Label8.Location = New System.Drawing.Point(410, 108)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(53, 16)
    Me.Label8.TabIndex = 166
    Me.Label8.Text = "150 PSI"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.ForeColor = System.Drawing.Color.Yellow
    Me.Label6.Location = New System.Drawing.Point(127, 108)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(39, 16)
    Me.Label6.TabIndex = 165
    Me.Label6.Text = "0 PSI"
    '
    'ProgressBar_AirPressure
    '
    Me.ProgressBar_AirPressure.BackColor = System.Drawing.Color.Gray
    Me.ProgressBar_AirPressure.ForeColor = System.Drawing.Color.Lime
    Me.ProgressBar_AirPressure.Location = New System.Drawing.Point(172, 101)
    Me.ProgressBar_AirPressure.Maximum = 150
    Me.ProgressBar_AirPressure.Name = "ProgressBar_AirPressure"
    Me.ProgressBar_AirPressure.Size = New System.Drawing.Size(232, 23)
    Me.ProgressBar_AirPressure.Step = 1
    Me.ProgressBar_AirPressure.Style = System.Windows.Forms.ProgressBarStyle.Continuous
    Me.ProgressBar_AirPressure.TabIndex = 164
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.ForeColor = System.Drawing.Color.Yellow
    Me.Label7.Location = New System.Drawing.Point(169, 32)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(91, 16)
    Me.Label7.TabIndex = 158
    Me.Label7.Text = "ADC Reading"
    '
    'LED_ADCReading
    '
    Me.LED_ADCReading.BackColor = System.Drawing.Color.Gray
    Me.LED_ADCReading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LED_ADCReading.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LED_ADCReading.ForeColor = System.Drawing.Color.Lime
    Me.LED_ADCReading.Location = New System.Drawing.Point(172, 48)
    Me.LED_ADCReading.Name = "LED_ADCReading"
    Me.LED_ADCReading.Size = New System.Drawing.Size(232, 26)
    Me.LED_ADCReading.TabIndex = 157
    Me.LED_ADCReading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.ForeColor = System.Drawing.Color.Yellow
    Me.Label9.Location = New System.Drawing.Point(169, 82)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(160, 16)
    Me.Label9.TabIndex = 156
    Me.Label9.Text = "Approximate Air Pressure"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.ForeColor = System.Drawing.Color.Yellow
    Me.Label10.Location = New System.Drawing.Point(21, 108)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(457, 16)
    Me.Label10.TabIndex = 147
    Me.Label10.Text = "-> The module demonstrates the use of the ADC for direct sensor connection"
    '
    'frmDialog_COMPAIR
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.DimGray
    Me.CausesValidation = False
    Me.ClientSize = New System.Drawing.Size(594, 308)
    Me.Controls.Add(Me.Group_Device_Controls)
    Me.Controls.Add(Me.Group_Device_Description)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmDialog_COMPAIR"
    Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Dialog For ACW Compressed Air Sensor"
    Me.Group_Device_Description.ResumeLayout(False)
    Me.Group_Device_Description.PerformLayout()
    Me.Group_Device_Controls.ResumeLayout(False)
    Me.Group_Device_Controls.PerformLayout()
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents SensorADCPollTimer As System.Windows.Forms.Timer
    Friend WithEvents Group_Device_Description As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_Device_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents LED_ADCReading As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar_AirPressure As System.Windows.Forms.ProgressBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
