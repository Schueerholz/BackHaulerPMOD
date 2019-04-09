<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog_MRAM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDialog_MRAM))
        Me.Group_Device_Description = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_Device_Controls = New System.Windows.Forms.GroupBox()
        Me.MRAM_BrowseScrollBar = New System.Windows.Forms.VScrollBar()
        Me.MRAM_BrowseWindow = New System.Windows.Forms.Label()
        Me.Button_Save_MRAM_To_File = New System.Windows.Forms.Button()
        Me.Button_Write_File_To_MRAM = New System.Windows.Forms.Button()
        Me.Button_Erase_MRAM = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MRAM_OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.MRAM_SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.Group_Device_Description.SuspendLayout()
        Me.Group_Device_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'Group_Device_Description
        '
        Me.Group_Device_Description.Controls.Add(Me.Label10)
        Me.Group_Device_Description.Controls.Add(Me.Label8)
        Me.Group_Device_Description.Controls.Add(Me.Label12)
        Me.Group_Device_Description.Controls.Add(Me.Label9)
        Me.Group_Device_Description.Controls.Add(Me.Label7)
        Me.Group_Device_Description.Controls.Add(Me.Label4)
        Me.Group_Device_Description.Controls.Add(Me.Label3)
        Me.Group_Device_Description.Controls.Add(Me.Label2)
        Me.Group_Device_Description.Controls.Add(Me.Label1)
        Me.Group_Device_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Description.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Description.Location = New System.Drawing.Point(12, 12)
        Me.Group_Device_Description.Name = "Group_Device_Description"
        Me.Group_Device_Description.Size = New System.Drawing.Size(681, 187)
        Me.Group_Device_Description.TabIndex = 144
        Me.Group_Device_Description.TabStop = False
        Me.Group_Device_Description.Text = "Device Description"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(21, 156)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(512, 16)
        Me.Label10.TabIndex = 151
        Me.Label10.Text = "-> This code leaves the status register with the memory unprotected but write dis" & _
    "abled"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(21, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(569, 16)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = "-> This code assumes WP and HOLD pins are inactive (logic high, by jumper or disc" & _
    "rete signal)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(21, 124)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(541, 16)
        Me.Label12.TabIndex = 149
        Me.Label12.Text = "-> Note that it is not necessary to erase MRAM to write to it, so erase is more o" & _
    "f a fill function"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(21, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(381, 16)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = "-> This dialog can be used to read and write the memory off line"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(21, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(517, 16)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "-> This peripheral can be used to add nonvolatile data storage to an application " & _
    "board"
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
        Me.Label3.Size = New System.Drawing.Size(598, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "-> The peripheral provides an Everspin MR25H10 serial MRAM chip for 1Mb (128K byt" & _
    "e) of memory  "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(21, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(453, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "-> Manufacturer part number or identifier for this peripheral is AP1708-MRAM"
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
        Me.Group_Device_Controls.Controls.Add(Me.MRAM_BrowseScrollBar)
        Me.Group_Device_Controls.Controls.Add(Me.MRAM_BrowseWindow)
        Me.Group_Device_Controls.Controls.Add(Me.Button_Save_MRAM_To_File)
        Me.Group_Device_Controls.Controls.Add(Me.Button_Write_File_To_MRAM)
        Me.Group_Device_Controls.Controls.Add(Me.Button_Erase_MRAM)
        Me.Group_Device_Controls.Controls.Add(Me.Label6)
        Me.Group_Device_Controls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Device_Controls.ForeColor = System.Drawing.Color.Aqua
        Me.Group_Device_Controls.Location = New System.Drawing.Point(12, 205)
        Me.Group_Device_Controls.Name = "Group_Device_Controls"
        Me.Group_Device_Controls.Size = New System.Drawing.Size(681, 279)
        Me.Group_Device_Controls.TabIndex = 149
        Me.Group_Device_Controls.TabStop = False
        Me.Group_Device_Controls.Text = "Device Controls"
        '
        'MRAM_BrowseScrollBar
        '
        Me.MRAM_BrowseScrollBar.LargeChange = 256
        Me.MRAM_BrowseScrollBar.Location = New System.Drawing.Point(648, 43)
        Me.MRAM_BrowseScrollBar.Maximum = 131071
        Me.MRAM_BrowseScrollBar.Name = "MRAM_BrowseScrollBar"
        Me.MRAM_BrowseScrollBar.Size = New System.Drawing.Size(17, 180)
        Me.MRAM_BrowseScrollBar.SmallChange = 16
        Me.MRAM_BrowseScrollBar.TabIndex = 183
        '
        'MRAM_BrowseWindow
        '
        Me.MRAM_BrowseWindow.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MRAM_BrowseWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MRAM_BrowseWindow.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MRAM_BrowseWindow.ForeColor = System.Drawing.Color.Black
        Me.MRAM_BrowseWindow.Location = New System.Drawing.Point(15, 43)
        Me.MRAM_BrowseWindow.Name = "MRAM_BrowseWindow"
        Me.MRAM_BrowseWindow.Size = New System.Drawing.Size(632, 180)
        Me.MRAM_BrowseWindow.TabIndex = 182
        Me.MRAM_BrowseWindow.Text = resources.GetString("MRAM_BrowseWindow.Text")
        '
        'Button_Save_MRAM_To_File
        '
        Me.Button_Save_MRAM_To_File.BackColor = System.Drawing.Color.Gray
        Me.Button_Save_MRAM_To_File.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Save_MRAM_To_File.ForeColor = System.Drawing.Color.Lime
        Me.Button_Save_MRAM_To_File.Location = New System.Drawing.Point(237, 237)
        Me.Button_Save_MRAM_To_File.Name = "Button_Save_MRAM_To_File"
        Me.Button_Save_MRAM_To_File.Size = New System.Drawing.Size(206, 26)
        Me.Button_Save_MRAM_To_File.TabIndex = 180
        Me.Button_Save_MRAM_To_File.Text = "Save MRAM To File"
        Me.Button_Save_MRAM_To_File.UseVisualStyleBackColor = False
        '
        'Button_Write_File_To_MRAM
        '
        Me.Button_Write_File_To_MRAM.BackColor = System.Drawing.Color.Gray
        Me.Button_Write_File_To_MRAM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Write_File_To_MRAM.ForeColor = System.Drawing.Color.Lime
        Me.Button_Write_File_To_MRAM.Location = New System.Drawing.Point(459, 237)
        Me.Button_Write_File_To_MRAM.Name = "Button_Write_File_To_MRAM"
        Me.Button_Write_File_To_MRAM.Size = New System.Drawing.Size(206, 26)
        Me.Button_Write_File_To_MRAM.TabIndex = 179
        Me.Button_Write_File_To_MRAM.Text = "Write File To MRAM"
        Me.Button_Write_File_To_MRAM.UseVisualStyleBackColor = False
        '
        'Button_Erase_MRAM
        '
        Me.Button_Erase_MRAM.BackColor = System.Drawing.Color.Gray
        Me.Button_Erase_MRAM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Erase_MRAM.ForeColor = System.Drawing.Color.Lime
        Me.Button_Erase_MRAM.Location = New System.Drawing.Point(15, 237)
        Me.Button_Erase_MRAM.Name = "Button_Erase_MRAM"
        Me.Button_Erase_MRAM.Size = New System.Drawing.Size(206, 26)
        Me.Button_Erase_MRAM.TabIndex = 177
        Me.Button_Erase_MRAM.Text = "Erase MRAM"
        Me.Button_Erase_MRAM.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(12, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 16)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "Browse MRAM Contents"
        '
        'MRAM_OpenFileDialog
        '
        Me.MRAM_OpenFileDialog.Filter = "All Files (*.*)|*.*|Binary Files (*.bin)|*.bin"
        Me.MRAM_OpenFileDialog.Title = "Select File For Writing To MRAM"
        '
        'MRAM_SaveFileDialog
        '
        Me.MRAM_SaveFileDialog.Filter = "All Files (*.*)|*.*|Binary Files (*.bin)|*.bin"
        Me.MRAM_SaveFileDialog.Title = "Select File To Save MRAM Data"
        '
        'frmDialog_MRAM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(705, 497)
        Me.Controls.Add(Me.Group_Device_Controls)
        Me.Controls.Add(Me.Group_Device_Description)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialog_MRAM"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dialog For ACW Everspin MRAM"
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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MRAM_OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button_Erase_MRAM As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button_Save_MRAM_To_File As System.Windows.Forms.Button
    Friend WithEvents Button_Write_File_To_MRAM As System.Windows.Forms.Button
    Friend WithEvents MRAM_BrowseWindow As System.Windows.Forms.Label
    Friend WithEvents MRAM_BrowseScrollBar As System.Windows.Forms.VScrollBar
    Friend WithEvents MRAM_SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
