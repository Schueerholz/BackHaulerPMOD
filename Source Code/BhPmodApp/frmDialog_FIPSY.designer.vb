<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_FIPSY
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_FIPSY))
        Me.FipsyPollTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.LED_FPGAUniqueID = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LED_FPGADeviceID = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button_EraseAndProgram = New System.Windows.Forms.Button()
        Me.Button_Program = New System.Windows.Forms.Button()
        Me.Button_Erase = New System.Windows.Forms.Button()
        Me.Button_Browse = New System.Windows.Forms.Button()
        Me.LED_JEDECFileName = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FipsyOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'FipsyPollTimer
        '
        Me.FipsyPollTimer.Interval = 200
        '
        'Group_Device_Description
        '
        Me.Group_Device_Description.Controls.Add(Me.Label12)
        Me.Group_Device_Description.Controls.Add(Me.Label13)
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
        Me.Group_Device_Description.Size = New System.Drawing.Size(570, 167)
        Me.Group_Device_Description.TabIndex = 144
        Me.Group_Device_Description.TabStop = False
        Me.Group_Device_Description.Text = "Device Description"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(21, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(501, 16)
        Me.Label12.TabIndex = 167
        Me.Label12.Text = "-> The Fipsy FPGA module is an initiative of MoCo Makers (www.mocomakers.com)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Yellow
        Me.Label13.Location = New System.Drawing.Point(22, 140)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(516, 16)
        Me.Label13.TabIndex = 149
        Me.Label13.Text = "     and is intended to demonstrate the use of the module slave SPI port for that" & _
    " purpose"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(22, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(503, 16)
        Me.Label10.TabIndex = 147
        Me.Label10.Text = "-> This software is one of several mechanisms for loading FPGA code to the module" & _
    ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(21, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(487, 16)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "-> This dialog communicates on SPI through the library BhPmodFipsyLoader.DLL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(21, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(444, 16)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "-> The Fipsy module is mounted on AP1606-BREADBOARD or equivalent"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(21, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(504, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The Fipsy module provides a Lattice FPGA part number LCMXO2-256HC-4SG32C"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(22, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(473, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is Fipsy version 17" & _
    "12"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(21, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(378, 16)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "-> The hardware manufacturer is Allied Component Works, LLC"
        '
        'Group_Device_Controls
        '
        Me.Group_Device_Controls.Controls.Add(Me.LED_FPGAUniqueID)
        Me.Group_Device_Controls.Controls.Add(Me.Label11)
        Me.Group_Device_Controls.Controls.Add(Me.LED_FPGADeviceID)
        Me.Group_Device_Controls.Controls.Add(Me.Label7)
        Me.Group_Device_Controls.Controls.Add(Me.Button_EraseAndProgram)
        Me.Group_Device_Controls.Controls.Add(Me.Button_Program)
        Me.Group_Device_Controls.Controls.Add(Me.Button_Erase)
        Me.Group_Device_Controls.Controls.Add(Me.Button_Browse)
        Me.Group_Device_Controls.Controls.Add(Me.LED_JEDECFileName)
        Me.Group_Device_Controls.Controls.Add(Me.Label9)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(12, 185)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(570, 244)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'LED_FPGAUniqueID
        '
        Me.LED_FPGAUniqueID.BackColor = System.Drawing.Color.Gray
        Me.LED_FPGAUniqueID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_FPGAUniqueID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_FPGAUniqueID.ForeColor = System.Drawing.Color.Lime
        Me.LED_FPGAUniqueID.Location = New System.Drawing.Point(25, 93)
        Me.LED_FPGAUniqueID.Name = "LED_FPGAUniqueID"
        Me.LED_FPGAUniqueID.Size = New System.Drawing.Size(521, 26)
        Me.LED_FPGAUniqueID.TabIndex = 177
        Me.LED_FPGAUniqueID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(22, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 16)
        Me.Label11.TabIndex = 176
        Me.Label11.Text = "FPGA Unique ID"
        '
        'LED_FPGADeviceID
        '
        Me.LED_FPGADeviceID.BackColor = System.Drawing.Color.Gray
        Me.LED_FPGADeviceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_FPGADeviceID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_FPGADeviceID.ForeColor = System.Drawing.Color.Lime
        Me.LED_FPGADeviceID.Location = New System.Drawing.Point(24, 41)
        Me.LED_FPGADeviceID.Name = "LED_FPGADeviceID"
        Me.LED_FPGADeviceID.Size = New System.Drawing.Size(522, 26)
        Me.LED_FPGADeviceID.TabIndex = 175
        Me.LED_FPGADeviceID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(21, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 16)
        Me.Label7.TabIndex = 174
        Me.Label7.Text = "FPGA Device ID"
        '
        'Button_EraseAndProgram
        '
        Me.Button_EraseAndProgram.BackColor = System.Drawing.Color.Gray
        Me.Button_EraseAndProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_EraseAndProgram.ForeColor = System.Drawing.Color.Lime
        Me.Button_EraseAndProgram.Location = New System.Drawing.Point(297, 196)
        Me.Button_EraseAndProgram.Name = "Button_EraseAndProgram"
        Me.Button_EraseAndProgram.Size = New System.Drawing.Size(249, 26)
        Me.Button_EraseAndProgram.TabIndex = 173
        Me.Button_EraseAndProgram.Text = "Erase And Program"
        Me.Button_EraseAndProgram.UseVisualStyleBackColor = False
        '
        'Button_Program
        '
        Me.Button_Program.BackColor = System.Drawing.Color.Gray
        Me.Button_Program.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Program.ForeColor = System.Drawing.Color.Lime
        Me.Button_Program.Location = New System.Drawing.Point(161, 196)
        Me.Button_Program.Name = "Button_Program"
        Me.Button_Program.Size = New System.Drawing.Size(122, 26)
        Me.Button_Program.TabIndex = 172
        Me.Button_Program.Text = "Program"
        Me.Button_Program.UseVisualStyleBackColor = False
        '
        'Button_Erase
        '
        Me.Button_Erase.BackColor = System.Drawing.Color.Gray
        Me.Button_Erase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Erase.ForeColor = System.Drawing.Color.Lime
        Me.Button_Erase.Location = New System.Drawing.Point(25, 196)
        Me.Button_Erase.Name = "Button_Erase"
        Me.Button_Erase.Size = New System.Drawing.Size(121, 26)
        Me.Button_Erase.TabIndex = 167
        Me.Button_Erase.Text = "Erase"
        Me.Button_Erase.UseVisualStyleBackColor = False
        '
        'Button_Browse
        '
        Me.Button_Browse.BackColor = System.Drawing.Color.Gray
        Me.Button_Browse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Browse.ForeColor = System.Drawing.Color.Lime
        Me.Button_Browse.Location = New System.Drawing.Point(423, 145)
        Me.Button_Browse.Name = "Button_Browse"
        Me.Button_Browse.Size = New System.Drawing.Size(122, 26)
        Me.Button_Browse.TabIndex = 164
        Me.Button_Browse.Text = "Browse"
        Me.Button_Browse.UseVisualStyleBackColor = False
        '
        'LED_JEDECFileName
        '
        Me.LED_JEDECFileName.BackColor = System.Drawing.Color.Gray
        Me.LED_JEDECFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_JEDECFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_JEDECFileName.ForeColor = System.Drawing.Color.Lime
        Me.LED_JEDECFileName.Location = New System.Drawing.Point(24, 145)
        Me.LED_JEDECFileName.Name = "LED_JEDECFileName"
        Me.LED_JEDECFileName.Size = New System.Drawing.Size(386, 26)
        Me.LED_JEDECFileName.TabIndex = 157
        Me.LED_JEDECFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(21, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 16)
        Me.Label9.TabIndex = 156
        Me.Label9.Text = "JEDEC File Name"
        '
        'FipsyOpenFileDialog
        '
        Me.FipsyOpenFileDialog.FileName = "*.jed"
        '
        'frmDialog_FIPSY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(594, 441)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_FIPSY"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For Fipsy FPGA Module"
        Me.Group_Device_Description.ResumeLayout(False)
        Me.Group_Device_Description.PerformLayout()
        Me.Group_Device_Controls.ResumeLayout(False)
        Me.Group_Device_Controls.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents FipsyPollTimer As System.Windows.Forms.Timer
    Friend WithEvents Group_Device_Description As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_Device_Controls As System.Windows.Forms.GroupBox
    Friend WithEvents LED_JEDECFileName As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button_Browse As System.Windows.Forms.Button
    Friend WithEvents Button_Erase As System.Windows.Forms.Button
    Friend WithEvents LED_FPGAUniqueID As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LED_FPGADeviceID As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button_EraseAndProgram As System.Windows.Forms.Button
    Friend WithEvents Button_Program As System.Windows.Forms.Button
    Friend WithEvents FipsyOpenFileDialog As System.Windows.Forms.OpenFileDialog

End Class
