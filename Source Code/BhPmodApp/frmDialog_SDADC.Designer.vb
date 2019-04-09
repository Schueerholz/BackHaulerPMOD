<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_SDADC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_SDADC))
        Me.VoltagePollTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.LED_VoltageCh3 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LED_VoltageCh2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LED_VoltageCh1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LED_VoltageCh0 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LED_Temperature = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'VoltagePollTimer
        '
        Me.VoltagePollTimer.Interval = 200
        '
        'Group_Device_Description
        '
        Me.Group_Device_Description.Controls.Add(Me.Label19)
        Me.Group_Device_Description.Controls.Add(Me.Label17)
        Me.Group_Device_Description.Controls.Add(Me.Label6)
        Me.Group_Device_Description.Controls.Add(Me.Label14)
        Me.Group_Device_Description.Controls.Add(Me.Label13)
        Me.Group_Device_Description.Controls.Add(Me.Label11)
        Me.Group_Device_Description.Controls.Add(Me.Label10)
        Me.Group_Device_Description.Controls.Add(Me.Label4)
        Me.Group_Device_Description.Controls.Add(Me.Label3)
        Me.Group_Device_Description.Controls.Add(Me.Label2)
        Me.Group_Device_Description.Controls.Add(Me.Label1)
        Me.Group_Device_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Description.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Description.Location = New System.Drawing.Point(12, 12)
        Me.Group_Device_Description.Name = "Group_Device_Description"
        Me.Group_Device_Description.Size = New System.Drawing.Size(570, 228)
        Me.Group_Device_Description.TabIndex = 144
        Me.Group_Device_Description.TabStop = False
        Me.Group_Device_Description.Text = "Device Description"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Yellow
        Me.Label19.Location = New System.Drawing.Point(21, 188)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(484, 16)
        Me.Label19.TabIndex = 166
        Me.Label19.Text = "     but the noise floor in single ended mode will be much higher than the resolu" & _
    "tion"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(22, 172)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(455, 16)
        Me.Label17.TabIndex = 153
        Me.Label17.Text = "-> With a 3.3V reference, the ADC resolution per LSB is on the order of 0.2uV,"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(21, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(291, 16)
        Me.Label6.TabIndex = 152
        Me.Label6.Text = "-> Floating inputs will usually read as over range"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Yellow
        Me.Label14.Location = New System.Drawing.Point(21, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(518, 32)
        Me.Label14.TabIndex = 150
        Me.Label14.Text = "-> Polling for conversion complete would be possible but complex on the BackHaule" & _
    "r,  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     so this demonstration settles for reading after the known conversion " & _
    "time"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Yellow
        Me.Label13.Location = New System.Drawing.Point(22, 156)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(483, 16)
        Me.Label13.TabIndex = 149
        Me.Label13.Text = "     making the input range +/-1.65V (or 0 to 1.65V usable with a single ended in" & _
    "put)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(21, 140)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(488, 16)
        Me.Label11.TabIndex = 148
        Me.Label11.Text = "-> This demonstration assumes that the reference is connected to the 3.3V supply," & _
    ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(21, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(337, 16)
        Me.Label10.TabIndex = 147
        Me.Label10.Text = "-> This demonstration displays only single ended inputs"
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
        Me.Label3.Size = New System.Drawing.Size(397, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The peripheral provides an LTC2492 analog to digital converter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(21, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(459, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is AP1606-SDADC"
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
        Me.Group_Device_Controls.Controls.Add(Me.LED_VoltageCh3)
        Me.Group_Device_Controls.Controls.Add(Me.Label18)
        Me.Group_Device_Controls.Controls.Add(Me.LED_VoltageCh2)
        Me.Group_Device_Controls.Controls.Add(Me.Label16)
        Me.Group_Device_Controls.Controls.Add(Me.LED_VoltageCh1)
        Me.Group_Device_Controls.Controls.Add(Me.Label7)
        Me.Group_Device_Controls.Controls.Add(Me.LED_VoltageCh0)
        Me.Group_Device_Controls.Controls.Add(Me.Label9)
        Me.Group_Device_Controls.Controls.Add(Me.LED_Temperature)
        Me.Group_Device_Controls.Controls.Add(Me.Label8)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(12, 246)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 297)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'LED_VoltageCh3
        '
        Me.LED_VoltageCh3.BackColor = System.Drawing.Color.Gray
        Me.LED_VoltageCh3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_VoltageCh3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_VoltageCh3.ForeColor = System.Drawing.Color.Lime
        Me.LED_VoltageCh3.Location = New System.Drawing.Point(172, 200)
        Me.LED_VoltageCh3.Name = "LED_VoltageCh3"
        Me.LED_VoltageCh3.Size = New System.Drawing.Size(232, 26)
        Me.LED_VoltageCh3.TabIndex = 163
        Me.LED_VoltageCh3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Yellow
        Me.Label18.Location = New System.Drawing.Point(169, 184)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(115, 16)
        Me.Label18.TabIndex = 162
        Me.Label18.Text = "CH3 Voltage (mV)"
        '
        'LED_VoltageCh2
        '
        Me.LED_VoltageCh2.BackColor = System.Drawing.Color.Gray
        Me.LED_VoltageCh2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_VoltageCh2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_VoltageCh2.ForeColor = System.Drawing.Color.Lime
        Me.LED_VoltageCh2.Location = New System.Drawing.Point(172, 149)
        Me.LED_VoltageCh2.Name = "LED_VoltageCh2"
        Me.LED_VoltageCh2.Size = New System.Drawing.Size(232, 26)
        Me.LED_VoltageCh2.TabIndex = 161
        Me.LED_VoltageCh2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Yellow
        Me.Label16.Location = New System.Drawing.Point(169, 133)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 16)
        Me.Label16.TabIndex = 160
        Me.Label16.Text = "CH2 Voltage (mV)"
        '
        'LED_VoltageCh1
        '
        Me.LED_VoltageCh1.BackColor = System.Drawing.Color.Gray
        Me.LED_VoltageCh1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_VoltageCh1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_VoltageCh1.ForeColor = System.Drawing.Color.Lime
        Me.LED_VoltageCh1.Location = New System.Drawing.Point(172, 98)
        Me.LED_VoltageCh1.Name = "LED_VoltageCh1"
        Me.LED_VoltageCh1.Size = New System.Drawing.Size(232, 26)
        Me.LED_VoltageCh1.TabIndex = 159
        Me.LED_VoltageCh1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(169, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 16)
        Me.Label7.TabIndex = 158
        Me.Label7.Text = "CH1 Voltage (mV)"
        '
        'LED_VoltageCh0
        '
        Me.LED_VoltageCh0.BackColor = System.Drawing.Color.Gray
        Me.LED_VoltageCh0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_VoltageCh0.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_VoltageCh0.ForeColor = System.Drawing.Color.Lime
        Me.LED_VoltageCh0.Location = New System.Drawing.Point(172, 48)
        Me.LED_VoltageCh0.Name = "LED_VoltageCh0"
        Me.LED_VoltageCh0.Size = New System.Drawing.Size(232, 26)
        Me.LED_VoltageCh0.TabIndex = 157
        Me.LED_VoltageCh0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(169, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 16)
        Me.Label9.TabIndex = 156
        Me.Label9.Text = "CH0 Voltage (mV)"
        '
        'LED_Temperature
        '
        Me.LED_Temperature.BackColor = System.Drawing.Color.Gray
        Me.LED_Temperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_Temperature.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_Temperature.ForeColor = System.Drawing.Color.Lime
        Me.LED_Temperature.Location = New System.Drawing.Point(172, 250)
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
        Me.Label8.Location = New System.Drawing.Point(169, 234)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 16)
        Me.Label8.TabIndex = 153
        Me.Label8.Text = "Temperature (Degrees C)"
        '
        'frmDialog_SDADC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(594, 553)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_SDADC"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For ACW 4-Channel 24-Bit ADC"
        Me.Group_Device_Description.ResumeLayout(False)
        Me.Group_Device_Description.PerformLayout()
        Me.Group_Device_Controls.ResumeLayout(False)
        Me.Group_Device_Controls.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents VoltagePollTimer As System.Windows.Forms.Timer
    Friend WithEvents Group_Device_Description As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_Device_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LED_Temperature As System.Windows.Forms.Label
    Friend WithEvents LED_VoltageCh0 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LED_VoltageCh3 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LED_VoltageCh2 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LED_VoltageCh1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label

End Class
