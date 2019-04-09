<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_RTC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_RTC))
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.LED_TimeDisplay = New System.Windows.Forms.Label()
        Me.CheckBox_TwelveHour = New System.Windows.Forms.CheckBox()
        Me.CheckBox_1Hz_Pulse = New System.Windows.Forms.CheckBox()
        Me.Button_SetTime = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TimePollTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'Group_Device_Description
        '
        Me.Group_Device_Description.Controls.Add(Me.Label6)
        Me.Group_Device_Description.Controls.Add(Me.Label4)
        Me.Group_Device_Description.Controls.Add(Me.Label3)
        Me.Group_Device_Description.Controls.Add(Me.Label2)
        Me.Group_Device_Description.Controls.Add(Me.Label1)
        Me.Group_Device_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Description.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Description.Location = New System.Drawing.Point(12, 12)
        Me.Group_Device_Description.Name = "Group_Device_Description"
        Me.Group_Device_Description.Size = New System.Drawing.Size(570, 121)
        Me.Group_Device_Description.TabIndex = 144
        Me.Group_Device_Description.TabStop = False
        Me.Group_Device_Description.Text = "Device Description"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(21, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(493, 16)
        Me.Label6.TabIndex = 147
        Me.Label6.Text = "-> This software uses only a few of the device features, leaving plenty to implem" & _
    "ent"
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
        Me.Label3.Size = New System.Drawing.Size(423, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The peripheral provides an integrated real time clock module (RTC)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(21, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(440, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is AP1606-RTC"
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
        Me.Group_Device_Controls.Controls.Add(Me.LED_TimeDisplay)
        Me.Group_Device_Controls.Controls.Add(Me.CheckBox_TwelveHour)
        Me.Group_Device_Controls.Controls.Add(Me.CheckBox_1Hz_Pulse)
        Me.Group_Device_Controls.Controls.Add(Me.Button_SetTime)
        Me.Group_Device_Controls.Controls.Add(Me.Label8)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(12, 139)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 160)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'LED_TimeDisplay
        '
        Me.LED_TimeDisplay.BackColor = System.Drawing.Color.Gray
        Me.LED_TimeDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_TimeDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_TimeDisplay.ForeColor = System.Drawing.Color.Lime
        Me.LED_TimeDisplay.Location = New System.Drawing.Point(23, 45)
        Me.LED_TimeDisplay.Name = "LED_TimeDisplay"
        Me.LED_TimeDisplay.Size = New System.Drawing.Size(526, 26)
        Me.LED_TimeDisplay.TabIndex = 155
        Me.LED_TimeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox_TwelveHour
        '
        Me.CheckBox_TwelveHour.AutoSize = True
        Me.CheckBox_TwelveHour.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_TwelveHour.Location = New System.Drawing.Point(409, 28)
        Me.CheckBox_TwelveHour.Name = "CheckBox_TwelveHour"
        Me.CheckBox_TwelveHour.Size = New System.Drawing.Size(140, 20)
        Me.CheckBox_TwelveHour.TabIndex = 159
        Me.CheckBox_TwelveHour.Text = "Use 12-Hour Mode"
        Me.CheckBox_TwelveHour.UseVisualStyleBackColor = True
        '
        'CheckBox_1Hz_Pulse
        '
        Me.CheckBox_1Hz_Pulse.AutoSize = True
        Me.CheckBox_1Hz_Pulse.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_1Hz_Pulse.Location = New System.Drawing.Point(23, 124)
        Me.CheckBox_1Hz_Pulse.Name = "CheckBox_1Hz_Pulse"
        Me.CheckBox_1Hz_Pulse.Size = New System.Drawing.Size(363, 20)
        Me.CheckBox_1Hz_Pulse.TabIndex = 158
        Me.CheckBox_1Hz_Pulse.Text = "Enable 1Hz on CLKOUT (see it on the main window PIN9)"
        Me.CheckBox_1Hz_Pulse.UseVisualStyleBackColor = True
        '
        'Button_SetTime
        '
        Me.Button_SetTime.BackColor = System.Drawing.Color.Gray
        Me.Button_SetTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_SetTime.ForeColor = System.Drawing.Color.Lime
        Me.Button_SetTime.Location = New System.Drawing.Point(23, 85)
        Me.Button_SetTime.Name = "Button_SetTime"
        Me.Button_SetTime.Size = New System.Drawing.Size(526, 26)
        Me.Button_SetTime.TabIndex = 157
        Me.Button_SetTime.Text = "Set Module Time With System Time"
        Me.Button_SetTime.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(20, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(178, 16)
        Me.Label8.TabIndex = 153
        Me.Label8.Text = "Time read from RTC module"
        '
        'TimePollTimer
        '
        Me.TimePollTimer.Interval = 500
        '
        'frmDialog_RTC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(595, 310)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_RTC"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For ACW Real Time Clock Module"
        Me.Group_Device_Description.ResumeLayout(False)
        Me.Group_Device_Description.PerformLayout()
        Me.Group_Device_Controls.ResumeLayout(False)
        Me.Group_Device_Controls.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents Group_Device_Description As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_Device_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LED_TimeDisplay As System.Windows.Forms.Label
    Friend WithEvents Button_SetTime As System.Windows.Forms.Button
    Friend WithEvents TimePollTimer As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_1Hz_Pulse As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_TwelveHour As System.Windows.Forms.CheckBox

End Class
