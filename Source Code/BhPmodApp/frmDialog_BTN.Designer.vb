<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_BTN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_BTN))
        Me.BtnPollTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.LED_BTN3 = New System.Windows.Forms.Label()
        Me.LED_BTN2 = New System.Windows.Forms.Label()
        Me.LED_BTN1 = New System.Windows.Forms.Label()
        Me.LED_BTN0 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnPollTimer
        '
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
        Me.Group_Device_Description.Size = New System.Drawing.Size(570, 106)
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
        Me.Label3.Size = New System.Drawing.Size(355, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The peripheral provides 4 momentary push button inputs"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(21, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(426, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is PmodBTN"
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
        Me.Group_Device_Controls.Controls.Add(Me.LED_BTN3)
        Me.Group_Device_Controls.Controls.Add(Me.LED_BTN2)
        Me.Group_Device_Controls.Controls.Add(Me.LED_BTN1)
        Me.Group_Device_Controls.Controls.Add(Me.LED_BTN0)
        Me.Group_Device_Controls.Controls.Add(Me.Label7)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(13, 124)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 188)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'LED_BTN3
        '
        Me.LED_BTN3.BackColor = System.Drawing.Color.Gray
        Me.LED_BTN3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_BTN3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_BTN3.ForeColor = System.Drawing.Color.Black
        Me.LED_BTN3.Location = New System.Drawing.Point(215, 122)
        Me.LED_BTN3.Name = "LED_BTN3"
        Me.LED_BTN3.Size = New System.Drawing.Size(56, 48)
        Me.LED_BTN3.TabIndex = 156
        Me.LED_BTN3.Text = "BTN3"
        Me.LED_BTN3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_BTN2
        '
        Me.LED_BTN2.BackColor = System.Drawing.Color.Gray
        Me.LED_BTN2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_BTN2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_BTN2.ForeColor = System.Drawing.Color.Black
        Me.LED_BTN2.Location = New System.Drawing.Point(215, 56)
        Me.LED_BTN2.Name = "LED_BTN2"
        Me.LED_BTN2.Size = New System.Drawing.Size(56, 48)
        Me.LED_BTN2.TabIndex = 155
        Me.LED_BTN2.Text = "BTN2"
        Me.LED_BTN2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_BTN1
        '
        Me.LED_BTN1.BackColor = System.Drawing.Color.Gray
        Me.LED_BTN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_BTN1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_BTN1.ForeColor = System.Drawing.Color.Black
        Me.LED_BTN1.Location = New System.Drawing.Point(290, 122)
        Me.LED_BTN1.Name = "LED_BTN1"
        Me.LED_BTN1.Size = New System.Drawing.Size(56, 48)
        Me.LED_BTN1.TabIndex = 154
        Me.LED_BTN1.Text = "BTN1"
        Me.LED_BTN1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_BTN0
        '
        Me.LED_BTN0.BackColor = System.Drawing.Color.Gray
        Me.LED_BTN0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_BTN0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_BTN0.ForeColor = System.Drawing.Color.Black
        Me.LED_BTN0.Location = New System.Drawing.Point(290, 56)
        Me.LED_BTN0.Name = "LED_BTN0"
        Me.LED_BTN0.Size = New System.Drawing.Size(56, 48)
        Me.LED_BTN0.TabIndex = 153
        Me.LED_BTN0.Text = "BTN0"
        Me.LED_BTN0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(138, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(287, 16)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Press a button on the peripheral and see it here"
        '
        'frmDialog_BTN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(595, 324)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_BTN"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For Digilent Button Module"
        Me.Group_Device_Description.ResumeLayout(False)
        Me.Group_Device_Description.PerformLayout()
        Me.Group_Device_Controls.ResumeLayout(False)
        Me.Group_Device_Controls.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents BtnPollTimer As System.Windows.Forms.Timer
    Friend WithEvents Group_Device_Description As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_Device_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LED_BTN3 As System.Windows.Forms.Label
    Friend WithEvents LED_BTN2 As System.Windows.Forms.Label
    Friend WithEvents LED_BTN1 As System.Windows.Forms.Label
    Friend WithEvents LED_BTN0 As System.Windows.Forms.Label

End Class
