<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_DUALDAC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_DUALDAC))
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.Slider_VoutA = New System.Windows.Forms.TrackBar()
        Me.LED_VoutB = New System.Windows.Forms.Label()
        Me.LED_VoutA = New System.Windows.Forms.Label()
        Me.CheckBox_Track = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Slider_VoutB = New System.Windows.Forms.TrackBar()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        CType(Me.Slider_VoutA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Slider_VoutB, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Group_Device_Description.Size = New System.Drawing.Size(570, 122)
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
        Me.Label7.Size = New System.Drawing.Size(323, 16)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "-> The reference input is connected to the 3.3V supply"
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
        Me.Label3.Size = New System.Drawing.Size(381, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The peripheral provides a dual 10-bit DAC using an LTC1661"
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
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is AP1606-DAC"
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
        Me.Group_Device_Controls.Controls.Add(Me.Slider_VoutA)
        Me.Group_Device_Controls.Controls.Add(Me.LED_VoutB)
        Me.Group_Device_Controls.Controls.Add(Me.LED_VoutA)
        Me.Group_Device_Controls.Controls.Add(Me.CheckBox_Track)
        Me.Group_Device_Controls.Controls.Add(Me.Label6)
        Me.Group_Device_Controls.Controls.Add(Me.Slider_VoutB)
        Me.Group_Device_Controls.Controls.Add(Me.Label11)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(13, 140)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 233)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'Slider_VoutA
        '
        Me.Slider_VoutA.BackColor = System.Drawing.Color.DimGray
        Me.Slider_VoutA.LargeChange = 0
        Me.Slider_VoutA.Location = New System.Drawing.Point(173, 38)
        Me.Slider_VoutA.Maximum = 1023
        Me.Slider_VoutA.Name = "Slider_VoutA"
        Me.Slider_VoutA.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Slider_VoutA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Slider_VoutA.Size = New System.Drawing.Size(45, 153)
        Me.Slider_VoutA.TabIndex = 165
        Me.Slider_VoutA.TickFrequency = 64
        Me.Slider_VoutA.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'LED_VoutB
        '
        Me.LED_VoutB.BackColor = System.Drawing.Color.Gray
        Me.LED_VoutB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_VoutB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_VoutB.ForeColor = System.Drawing.Color.Lime
        Me.LED_VoutB.Location = New System.Drawing.Point(322, 193)
        Me.LED_VoutB.Name = "LED_VoutB"
        Me.LED_VoutB.Size = New System.Drawing.Size(68, 26)
        Me.LED_VoutB.TabIndex = 164
        Me.LED_VoutB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_VoutA
        '
        Me.LED_VoutA.BackColor = System.Drawing.Color.Gray
        Me.LED_VoutA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_VoutA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_VoutA.ForeColor = System.Drawing.Color.Lime
        Me.LED_VoutA.Location = New System.Drawing.Point(160, 193)
        Me.LED_VoutA.Name = "LED_VoutA"
        Me.LED_VoutA.Size = New System.Drawing.Size(68, 26)
        Me.LED_VoutA.TabIndex = 163
        Me.LED_VoutA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox_Track
        '
        Me.CheckBox_Track.AutoSize = True
        Me.CheckBox_Track.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_Track.Location = New System.Drawing.Point(250, 198)
        Me.CheckBox_Track.Name = "CheckBox_Track"
        Me.CheckBox_Track.Size = New System.Drawing.Size(62, 20)
        Me.CheckBox_Track.TabIndex = 162
        Me.CheckBox_Track.Text = "Track"
        Me.CheckBox_Track.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(333, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 161
        Me.Label6.Text = "Vout B"
        '
        'Slider_VoutB
        '
        Me.Slider_VoutB.BackColor = System.Drawing.Color.DimGray
        Me.Slider_VoutB.LargeChange = 0
        Me.Slider_VoutB.Location = New System.Drawing.Point(336, 38)
        Me.Slider_VoutB.Maximum = 1023
        Me.Slider_VoutB.Name = "Slider_VoutB"
        Me.Slider_VoutB.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Slider_VoutB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Slider_VoutB.Size = New System.Drawing.Size(45, 153)
        Me.Slider_VoutB.TabIndex = 160
        Me.Slider_VoutB.TickFrequency = 64
        Me.Slider_VoutB.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(171, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 16)
        Me.Label11.TabIndex = 159
        Me.Label11.Text = "Vout A"
        '
        'frmDialog_DUALDAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(595, 383)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_DUALDAC"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For ACW Dual 10-Bit DAC Module"
        Me.Group_Device_Description.ResumeLayout(False)
        Me.Group_Device_Description.PerformLayout()
        Me.Group_Device_Controls.ResumeLayout(False)
        Me.Group_Device_Controls.PerformLayout()
        CType(Me.Slider_VoutA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Slider_VoutB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents Group_Device_Description As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_Device_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Slider_VoutB As System.Windows.Forms.TrackBar
    Friend WithEvents CheckBox_Track As System.Windows.Forms.CheckBox
    Friend WithEvents LED_VoutB As System.Windows.Forms.Label
    Friend WithEvents LED_VoutA As System.Windows.Forms.Label
    Friend WithEvents Slider_VoutA As System.Windows.Forms.TrackBar

End Class
