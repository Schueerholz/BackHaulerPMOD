<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_8LD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_8LD))
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.LED_D7 = New System.Windows.Forms.Label()
        Me.LED_D6 = New System.Windows.Forms.Label()
        Me.LED_D5 = New System.Windows.Forms.Label()
        Me.LED_D4 = New System.Windows.Forms.Label()
        Me.LED_D3 = New System.Windows.Forms.Label()
        Me.LED_D2 = New System.Windows.Forms.Label()
        Me.LED_D1 = New System.Windows.Forms.Label()
        Me.LED_D0 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'Group_Device_Description
        '
        Me.Group_Device_Description.Controls.Add(Me.Label15)
        Me.Group_Device_Description.Controls.Add(Me.Label6)
        Me.Group_Device_Description.Controls.Add(Me.Label4)
        Me.Group_Device_Description.Controls.Add(Me.Label3)
        Me.Group_Device_Description.Controls.Add(Me.Label2)
        Me.Group_Device_Description.Controls.Add(Me.Label1)
        Me.Group_Device_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Description.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Description.Location = New System.Drawing.Point(12, 12)
        Me.Group_Device_Description.Name = "Group_Device_Description"
        Me.Group_Device_Description.Size = New System.Drawing.Size(570, 138)
        Me.Group_Device_Description.TabIndex = 144
        Me.Group_Device_Description.TabStop = False
        Me.Group_Device_Description.Text = "Device Description"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Yellow
        Me.Label15.Location = New System.Drawing.Point(21, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(507, 16)
        Me.Label15.TabIndex = 148
        Me.Label15.Text = "-> The numbers on the peripheral board are shown here, and are not the pin number" & _
    "s"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(21, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(354, 16)
        Me.Label6.TabIndex = 147
        Me.Label6.Text = "-> Note that the peripheral requires active push-pull outputs"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(21, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(294, 16)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "-> The PMOD interface configuration is IO_ONLY"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(21, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(377, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The peripheral provides 8 LEDs controlled by digital outputs"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(21, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(422, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is Pmod8LD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(21, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 16)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "-> Peripheral manufacturer is Digilent, Inc."
        '
        'Group_Device_Controls
        '
        Me.Group_Device_Controls.Controls.Add(Me.LED_D7)
        Me.Group_Device_Controls.Controls.Add(Me.LED_D6)
        Me.Group_Device_Controls.Controls.Add(Me.LED_D5)
        Me.Group_Device_Controls.Controls.Add(Me.LED_D4)
        Me.Group_Device_Controls.Controls.Add(Me.LED_D3)
        Me.Group_Device_Controls.Controls.Add(Me.LED_D2)
        Me.Group_Device_Controls.Controls.Add(Me.LED_D1)
        Me.Group_Device_Controls.Controls.Add(Me.LED_D0)
        Me.Group_Device_Controls.Controls.Add(Me.Label7)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(12, 156)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 102)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'LED_D7
        '
        Me.LED_D7.BackColor = System.Drawing.Color.Gray
        Me.LED_D7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_D7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_D7.ForeColor = System.Drawing.Color.Black
        Me.LED_D7.Location = New System.Drawing.Point(387, 55)
        Me.LED_D7.Name = "LED_D7"
        Me.LED_D7.Size = New System.Drawing.Size(28, 28)
        Me.LED_D7.TabIndex = 159
        Me.LED_D7.Text = "D7"
        Me.LED_D7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_D6
        '
        Me.LED_D6.BackColor = System.Drawing.Color.Gray
        Me.LED_D6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_D6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_D6.ForeColor = System.Drawing.Color.Black
        Me.LED_D6.Location = New System.Drawing.Point(353, 55)
        Me.LED_D6.Name = "LED_D6"
        Me.LED_D6.Size = New System.Drawing.Size(28, 28)
        Me.LED_D6.TabIndex = 158
        Me.LED_D6.Text = "D6"
        Me.LED_D6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_D5
        '
        Me.LED_D5.BackColor = System.Drawing.Color.Gray
        Me.LED_D5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_D5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_D5.ForeColor = System.Drawing.Color.Black
        Me.LED_D5.Location = New System.Drawing.Point(319, 55)
        Me.LED_D5.Name = "LED_D5"
        Me.LED_D5.Size = New System.Drawing.Size(28, 28)
        Me.LED_D5.TabIndex = 157
        Me.LED_D5.Text = "D5"
        Me.LED_D5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_D4
        '
        Me.LED_D4.BackColor = System.Drawing.Color.Gray
        Me.LED_D4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_D4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_D4.ForeColor = System.Drawing.Color.Black
        Me.LED_D4.Location = New System.Drawing.Point(285, 55)
        Me.LED_D4.Name = "LED_D4"
        Me.LED_D4.Size = New System.Drawing.Size(28, 28)
        Me.LED_D4.TabIndex = 156
        Me.LED_D4.Text = "D4"
        Me.LED_D4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_D3
        '
        Me.LED_D3.BackColor = System.Drawing.Color.Gray
        Me.LED_D3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_D3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_D3.ForeColor = System.Drawing.Color.Black
        Me.LED_D3.Location = New System.Drawing.Point(251, 55)
        Me.LED_D3.Name = "LED_D3"
        Me.LED_D3.Size = New System.Drawing.Size(28, 28)
        Me.LED_D3.TabIndex = 155
        Me.LED_D3.Text = "D3"
        Me.LED_D3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_D2
        '
        Me.LED_D2.BackColor = System.Drawing.Color.Gray
        Me.LED_D2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_D2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_D2.ForeColor = System.Drawing.Color.Black
        Me.LED_D2.Location = New System.Drawing.Point(217, 55)
        Me.LED_D2.Name = "LED_D2"
        Me.LED_D2.Size = New System.Drawing.Size(28, 28)
        Me.LED_D2.TabIndex = 154
        Me.LED_D2.Text = "D2"
        Me.LED_D2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_D1
        '
        Me.LED_D1.BackColor = System.Drawing.Color.Gray
        Me.LED_D1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_D1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_D1.ForeColor = System.Drawing.Color.Black
        Me.LED_D1.Location = New System.Drawing.Point(183, 55)
        Me.LED_D1.Name = "LED_D1"
        Me.LED_D1.Size = New System.Drawing.Size(28, 28)
        Me.LED_D1.TabIndex = 153
        Me.LED_D1.Text = "D1"
        Me.LED_D1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_D0
        '
        Me.LED_D0.BackColor = System.Drawing.Color.Gray
        Me.LED_D0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_D0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_D0.ForeColor = System.Drawing.Color.Black
        Me.LED_D0.Location = New System.Drawing.Point(149, 55)
        Me.LED_D0.Name = "LED_D0"
        Me.LED_D0.Size = New System.Drawing.Size(28, 28)
        Me.LED_D0.TabIndex = 152
        Me.LED_D0.Text = "D0"
        Me.LED_D0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(123, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(327, 16)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Click on a box to set the logic level applied to that LED"
        '
        'frmDialog_8LD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(595, 269)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_8LD"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For Digilent 8 LED Peripheral"
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LED_D6 As System.Windows.Forms.Label
    Friend WithEvents LED_D5 As System.Windows.Forms.Label
    Friend WithEvents LED_D4 As System.Windows.Forms.Label
    Friend WithEvents LED_D3 As System.Windows.Forms.Label
    Friend WithEvents LED_D2 As System.Windows.Forms.Label
    Friend WithEvents LED_D1 As System.Windows.Forms.Label
    Friend WithEvents LED_D0 As System.Windows.Forms.Label
    Friend WithEvents LED_D7 As System.Windows.Forms.Label

End Class
