<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_USBUART
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_USBUART))
        Me.RxPollTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.TextBox_Terminal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button_Send = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Textbox_Send_String = New System.Windows.Forms.TextBox()
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'RxPollTimer
        '
        Me.RxPollTimer.Interval = 20
        '
        'Group_Device_Description
        '
        Me.Group_Device_Description.Controls.Add(Me.Label9)
        Me.Group_Device_Description.Controls.Add(Me.Label6)
        Me.Group_Device_Description.Controls.Add(Me.Label4)
        Me.Group_Device_Description.Controls.Add(Me.Label3)
        Me.Group_Device_Description.Controls.Add(Me.Label2)
        Me.Group_Device_Description.Controls.Add(Me.Label1)
        Me.Group_Device_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Description.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Description.Location = New System.Drawing.Point(12, 12)
        Me.Group_Device_Description.Name = "Group_Device_Description"
        Me.Group_Device_Description.Size = New System.Drawing.Size(570, 139)
        Me.Group_Device_Description.TabIndex = 144
        Me.Group_Device_Description.TabStop = False
        Me.Group_Device_Description.Text = "Device Description"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(21, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(350, 16)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = "-> The RTS signal is driven active, CTS is an unused input"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(21, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(417, 16)
        Me.Label6.TabIndex = 147
        Me.Label6.Text = "-> The user can communicate with a remote terminal set for 9600,N,8,1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(21, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(285, 16)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "-> The PMOD interface configuration is SERIAL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(21, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(538, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The peripheral provides a standard FTDI based virtual COM port on a remote USB" & _
    " host"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(21, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(464, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is PmodUSBUART"
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
        Me.Group_Device_Controls.Controls.Add(Me.TextBox_Terminal)
        Me.Group_Device_Controls.Controls.Add(Me.Label8)
        Me.Group_Device_Controls.Controls.Add(Me.Button_Send)
        Me.Group_Device_Controls.Controls.Add(Me.Label7)
        Me.Group_Device_Controls.Controls.Add(Me.Textbox_Send_String)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(12, 157)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 243)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'TextBox_Terminal
        '
        Me.TextBox_Terminal.AcceptsReturn = True
        Me.TextBox_Terminal.BackColor = System.Drawing.Color.White
        Me.TextBox_Terminal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox_Terminal.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Terminal.ForeColor = System.Drawing.Color.Black
        Me.TextBox_Terminal.Location = New System.Drawing.Point(23, 100)
        Me.TextBox_Terminal.Multiline = True
        Me.TextBox_Terminal.Name = "TextBox_Terminal"
        Me.TextBox_Terminal.ReadOnly = True
        Me.TextBox_Terminal.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_Terminal.Size = New System.Drawing.Size(525, 120)
        Me.TextBox_Terminal.TabIndex = 155
        Me.TextBox_Terminal.WordWrap = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(20, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(474, 16)
        Me.Label8.TabIndex = 153
        Me.Label8.Text = "Use this box like a terminal to send characters, displaying only what is received" & _
    ""
        '
        'Button_Send
        '
        Me.Button_Send.BackColor = System.Drawing.Color.Gray
        Me.Button_Send.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Send.ForeColor = System.Drawing.Color.Lime
        Me.Button_Send.Location = New System.Drawing.Point(453, 47)
        Me.Button_Send.Name = "Button_Send"
        Me.Button_Send.Size = New System.Drawing.Size(95, 26)
        Me.Button_Send.TabIndex = 151
        Me.Button_Send.Text = "Send"
        Me.Button_Send.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(20, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(420, 16)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Use this box to send a complete string up to 62 characters, plus CR/LF"
        '
        'Textbox_Send_String
        '
        Me.Textbox_Send_String.BackColor = System.Drawing.Color.White
        Me.Textbox_Send_String.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Textbox_Send_String.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textbox_Send_String.ForeColor = System.Drawing.Color.Black
        Me.Textbox_Send_String.Location = New System.Drawing.Point(23, 47)
        Me.Textbox_Send_String.Name = "Textbox_Send_String"
        Me.Textbox_Send_String.Size = New System.Drawing.Size(424, 26)
        Me.Textbox_Send_String.TabIndex = 149
        Me.Textbox_Send_String.WordWrap = False
        '
        'frmDialog_USBUART
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(595, 412)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_USBUART"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For Digilent USB UART"
        Me.Group_Device_Description.ResumeLayout(False)
        Me.Group_Device_Description.PerformLayout()
        Me.Group_Device_Controls.ResumeLayout(False)
        Me.Group_Device_Controls.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents RxPollTimer As System.Windows.Forms.Timer
    Friend WithEvents Group_Device_Description As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_Device_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents Textbox_Send_String As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button_Send As System.Windows.Forms.Button
    Friend WithEvents TextBox_Terminal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
