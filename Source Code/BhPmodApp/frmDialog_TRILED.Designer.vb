<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_TRILED
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_TRILED))
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TrackBar_Intensity = New System.Windows.Forms.TrackBar()
        Me.LED_Color_3 = New System.Windows.Forms.Label()
        Me.LED_Color_2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LED_DevicePowerState = New System.Windows.Forms.Label()
        Me.LED_Color_1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LEDColorDialog = New System.Windows.Forms.ColorDialog()
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        CType(Me.TrackBar_Intensity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Group_Device_Description
        '
        Me.Group_Device_Description.Controls.Add(Me.Label7)
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(21, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(466, 16)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "-> This peripheral can be an indicator device with an ability to express ""mood"""
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
        Me.Label3.Size = New System.Drawing.Size(383, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The peripheral provides 3 tricolor LEDs driven by a MAX6966"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(21, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(460, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is AP1606-TRILED"
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
        Me.Group_Device_Controls.Controls.Add(Me.Label11)
        Me.Group_Device_Controls.Controls.Add(Me.TrackBar_Intensity)
        Me.Group_Device_Controls.Controls.Add(Me.LED_Color_3)
        Me.Group_Device_Controls.Controls.Add(Me.LED_Color_2)
        Me.Group_Device_Controls.Controls.Add(Me.Label6)
        Me.Group_Device_Controls.Controls.Add(Me.LED_DevicePowerState)
        Me.Group_Device_Controls.Controls.Add(Me.LED_Color_1)
        Me.Group_Device_Controls.Controls.Add(Me.Label8)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(13, 139)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 211)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(436, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 159
        Me.Label11.Text = "Intensity"
        '
        'TrackBar_Intensity
        '
        Me.TrackBar_Intensity.BackColor = System.Drawing.Color.DimGray
        Me.TrackBar_Intensity.LargeChange = 1
        Me.TrackBar_Intensity.Location = New System.Drawing.Point(439, 42)
        Me.TrackBar_Intensity.Maximum = 7
        Me.TrackBar_Intensity.Name = "TrackBar_Intensity"
        Me.TrackBar_Intensity.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar_Intensity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TrackBar_Intensity.Size = New System.Drawing.Size(45, 153)
        Me.TrackBar_Intensity.TabIndex = 150
        Me.TrackBar_Intensity.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.TrackBar_Intensity.Value = 4
        '
        'LED_Color_3
        '
        Me.LED_Color_3.BackColor = System.Drawing.Color.Blue
        Me.LED_Color_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_Color_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_Color_3.ForeColor = System.Drawing.Color.Lime
        Me.LED_Color_3.Location = New System.Drawing.Point(329, 49)
        Me.LED_Color_3.Name = "LED_Color_3"
        Me.LED_Color_3.Size = New System.Drawing.Size(75, 79)
        Me.LED_Color_3.TabIndex = 158
        Me.LED_Color_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_Color_2
        '
        Me.LED_Color_2.BackColor = System.Drawing.Color.Green
        Me.LED_Color_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_Color_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_Color_2.ForeColor = System.Drawing.Color.Green
        Me.LED_Color_2.Location = New System.Drawing.Point(218, 49)
        Me.LED_Color_2.Name = "LED_Color_2"
        Me.LED_Color_2.Size = New System.Drawing.Size(75, 79)
        Me.LED_Color_2.TabIndex = 157
        Me.LED_Color_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(106, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(276, 16)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "Device Power State (With Ramped Changes)"
        '
        'LED_DevicePowerState
        '
        Me.LED_DevicePowerState.BackColor = System.Drawing.Color.Gray
        Me.LED_DevicePowerState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_DevicePowerState.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_DevicePowerState.ForeColor = System.Drawing.Color.Lime
        Me.LED_DevicePowerState.Location = New System.Drawing.Point(109, 160)
        Me.LED_DevicePowerState.Name = "LED_DevicePowerState"
        Me.LED_DevicePowerState.Size = New System.Drawing.Size(295, 26)
        Me.LED_DevicePowerState.TabIndex = 155
        Me.LED_DevicePowerState.Text = "SHUTDOWN"
        Me.LED_DevicePowerState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_Color_1
        '
        Me.LED_Color_1.BackColor = System.Drawing.Color.Red
        Me.LED_Color_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_Color_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_Color_1.ForeColor = System.Drawing.Color.Lime
        Me.LED_Color_1.Location = New System.Drawing.Point(109, 49)
        Me.LED_Color_1.Name = "LED_Color_1"
        Me.LED_Color_1.Size = New System.Drawing.Size(75, 79)
        Me.LED_Color_1.TabIndex = 154
        Me.LED_Color_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(106, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(220, 16)
        Me.Label8.TabIndex = 153
        Me.Label8.Text = "Click to adjust the color of each LED"
        '
        'LEDColorDialog
        '
        Me.LEDColorDialog.FullOpen = True
        '
        'frmDialog_TRILED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(595, 362)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_TRILED"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For ACW Tricolor LED Module"
        Me.Group_Device_Description.ResumeLayout(False)
        Me.Group_Device_Description.PerformLayout()
        Me.Group_Device_Controls.ResumeLayout(False)
        Me.Group_Device_Controls.PerformLayout()
        CType(Me.TrackBar_Intensity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents Group_Device_Description As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_Device_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LED_DevicePowerState As System.Windows.Forms.Label
    Friend WithEvents LED_Color_1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LED_Color_3 As System.Windows.Forms.Label
    Friend WithEvents LED_Color_2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TrackBar_Intensity As System.Windows.Forms.TrackBar
    Friend WithEvents LEDColorDialog As System.Windows.Forms.ColorDialog

End Class
