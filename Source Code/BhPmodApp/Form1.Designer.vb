<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PollTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Group_PMOD_Configuration_And_Status = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LED_Configuration = New System.Windows.Forms.Label()
        Me.CheckBox_Poll_Pin_State = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox_PP_PIN7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_PP_PIN8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_PP_PIN9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_PP_PIN10 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_PP_PIN1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_PP_PIN2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_PP_PIN3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_PP_PIN4 = New System.Windows.Forms.CheckBox()
        Me.LED_PIN7 = New System.Windows.Forms.Label()
        Me.LED_PIN8 = New System.Windows.Forms.Label()
        Me.LED_PIN9 = New System.Windows.Forms.Label()
        Me.LED_PIN10 = New System.Windows.Forms.Label()
        Me.LED_PIN11 = New System.Windows.Forms.Label()
        Me.LED_PIN12 = New System.Windows.Forms.Label()
        Me.LED_PIN6 = New System.Windows.Forms.Label()
        Me.LED_PIN5 = New System.Windows.Forms.Label()
        Me.LED_PIN4 = New System.Windows.Forms.Label()
        Me.LED_PIN3 = New System.Windows.Forms.Label()
        Me.LED_PIN2 = New System.Windows.Forms.Label()
        Me.LED_PIN1 = New System.Windows.Forms.Label()
        Me.Group_PMOD_Peripheral_Support_Examples = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button_OpenDialog = New System.Windows.Forms.Button()
        Me.ComboBox_SelectPMODPeripheral = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Group_PMOD_Configuration_And_Status.SuspendLayout()
        Me.Group_PMOD_Peripheral_Support_Examples.SuspendLayout()
        Me.SuspendLayout()
        '
        'PollTimer
        '
        Me.PollTimer.Interval = 200
        '
        'Group_PMOD_Configuration_And_Status
        '
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.Label5)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.Label3)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.Label2)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_Configuration)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.CheckBox_Poll_Pin_State)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.Label1)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.Label4)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.CheckBox_PP_PIN7)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.CheckBox_PP_PIN8)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.CheckBox_PP_PIN9)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.CheckBox_PP_PIN10)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.CheckBox_PP_PIN1)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.CheckBox_PP_PIN2)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.CheckBox_PP_PIN3)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.CheckBox_PP_PIN4)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN7)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN8)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN9)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN10)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN11)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN12)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN6)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN5)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN4)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN3)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN2)
        Me.Group_PMOD_Configuration_And_Status.Controls.Add(Me.LED_PIN1)
        Me.Group_PMOD_Configuration_And_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_PMOD_Configuration_And_Status.ForeColor = System.Drawing.Color.Aqua
        Me.Group_PMOD_Configuration_And_Status.Location = New System.Drawing.Point(15, 15)
        Me.Group_PMOD_Configuration_And_Status.Margin = New System.Windows.Forms.Padding(4)
        Me.Group_PMOD_Configuration_And_Status.Name = "Group_PMOD_Configuration_And_Status"
        Me.Group_PMOD_Configuration_And_Status.Padding = New System.Windows.Forms.Padding(4)
        Me.Group_PMOD_Configuration_And_Status.Size = New System.Drawing.Size(764, 217)
        Me.Group_PMOD_Configuration_And_Status.TabIndex = 89
        Me.Group_PMOD_Configuration_And_Status.TabStop = False
        Me.Group_PMOD_Configuration_And_Status.Text = "PMOD Configuration And Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(305, 165)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 17)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "-- Push-Pull"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(305, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 17)
        Me.Label3.TabIndex = 142
        Me.Label3.Text = "-- Push-Pull"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(428, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 20)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Configuration"
        '
        'LED_Configuration
        '
        Me.LED_Configuration.BackColor = System.Drawing.Color.Gray
        Me.LED_Configuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_Configuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_Configuration.ForeColor = System.Drawing.Color.Lime
        Me.LED_Configuration.Location = New System.Drawing.Point(432, 119)
        Me.LED_Configuration.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_Configuration.Name = "LED_Configuration"
        Me.LED_Configuration.Size = New System.Drawing.Size(298, 32)
        Me.LED_Configuration.TabIndex = 140
        Me.LED_Configuration.Text = "IO ONLY"
        Me.LED_Configuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox_Poll_Pin_State
        '
        Me.CheckBox_Poll_Pin_State.AutoSize = True
        Me.CheckBox_Poll_Pin_State.Checked = True
        Me.CheckBox_Poll_Pin_State.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Poll_Pin_State.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Poll_Pin_State.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_Poll_Pin_State.Location = New System.Drawing.Point(432, 50)
        Me.CheckBox_Poll_Pin_State.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_Poll_Pin_State.Name = "CheckBox_Poll_Pin_State"
        Me.CheckBox_Poll_Pin_State.Size = New System.Drawing.Size(284, 24)
        Me.CheckBox_Poll_Pin_State.TabIndex = 139
        Me.CheckBox_Poll_Pin_State.Text = "Poll For Pin State And Allow Edits"
        Me.CheckBox_Poll_Pin_State.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(305, 129)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "-- State"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(305, 87)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 17)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "-- State"
        '
        'CheckBox_PP_PIN7
        '
        Me.CheckBox_PP_PIN7.AutoSize = True
        Me.CheckBox_PP_PIN7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_PP_PIN7.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_PP_PIN7.Location = New System.Drawing.Point(260, 165)
        Me.CheckBox_PP_PIN7.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_PP_PIN7.Name = "CheckBox_PP_PIN7"
        Me.CheckBox_PP_PIN7.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox_PP_PIN7.TabIndex = 136
        Me.CheckBox_PP_PIN7.UseVisualStyleBackColor = True
        '
        'CheckBox_PP_PIN8
        '
        Me.CheckBox_PP_PIN8.AutoSize = True
        Me.CheckBox_PP_PIN8.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_PP_PIN8.Location = New System.Drawing.Point(215, 165)
        Me.CheckBox_PP_PIN8.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_PP_PIN8.Name = "CheckBox_PP_PIN8"
        Me.CheckBox_PP_PIN8.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox_PP_PIN8.TabIndex = 135
        Me.CheckBox_PP_PIN8.UseVisualStyleBackColor = True
        '
        'CheckBox_PP_PIN9
        '
        Me.CheckBox_PP_PIN9.AutoSize = True
        Me.CheckBox_PP_PIN9.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_PP_PIN9.Location = New System.Drawing.Point(169, 165)
        Me.CheckBox_PP_PIN9.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_PP_PIN9.Name = "CheckBox_PP_PIN9"
        Me.CheckBox_PP_PIN9.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox_PP_PIN9.TabIndex = 134
        Me.CheckBox_PP_PIN9.UseVisualStyleBackColor = True
        '
        'CheckBox_PP_PIN10
        '
        Me.CheckBox_PP_PIN10.AutoSize = True
        Me.CheckBox_PP_PIN10.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_PP_PIN10.Location = New System.Drawing.Point(124, 165)
        Me.CheckBox_PP_PIN10.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_PP_PIN10.Name = "CheckBox_PP_PIN10"
        Me.CheckBox_PP_PIN10.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox_PP_PIN10.TabIndex = 133
        Me.CheckBox_PP_PIN10.UseVisualStyleBackColor = True
        '
        'CheckBox_PP_PIN1
        '
        Me.CheckBox_PP_PIN1.AutoSize = True
        Me.CheckBox_PP_PIN1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_PP_PIN1.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_PP_PIN1.Location = New System.Drawing.Point(260, 50)
        Me.CheckBox_PP_PIN1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_PP_PIN1.Name = "CheckBox_PP_PIN1"
        Me.CheckBox_PP_PIN1.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox_PP_PIN1.TabIndex = 132
        Me.CheckBox_PP_PIN1.UseVisualStyleBackColor = True
        '
        'CheckBox_PP_PIN2
        '
        Me.CheckBox_PP_PIN2.AutoSize = True
        Me.CheckBox_PP_PIN2.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_PP_PIN2.Location = New System.Drawing.Point(215, 50)
        Me.CheckBox_PP_PIN2.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_PP_PIN2.Name = "CheckBox_PP_PIN2"
        Me.CheckBox_PP_PIN2.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox_PP_PIN2.TabIndex = 131
        Me.CheckBox_PP_PIN2.UseVisualStyleBackColor = True
        '
        'CheckBox_PP_PIN3
        '
        Me.CheckBox_PP_PIN3.AutoSize = True
        Me.CheckBox_PP_PIN3.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_PP_PIN3.Location = New System.Drawing.Point(169, 50)
        Me.CheckBox_PP_PIN3.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_PP_PIN3.Name = "CheckBox_PP_PIN3"
        Me.CheckBox_PP_PIN3.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox_PP_PIN3.TabIndex = 130
        Me.CheckBox_PP_PIN3.UseVisualStyleBackColor = True
        '
        'CheckBox_PP_PIN4
        '
        Me.CheckBox_PP_PIN4.AutoSize = True
        Me.CheckBox_PP_PIN4.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBox_PP_PIN4.Location = New System.Drawing.Point(124, 50)
        Me.CheckBox_PP_PIN4.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_PP_PIN4.Name = "CheckBox_PP_PIN4"
        Me.CheckBox_PP_PIN4.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox_PP_PIN4.TabIndex = 129
        Me.CheckBox_PP_PIN4.UseVisualStyleBackColor = True
        '
        'LED_PIN7
        '
        Me.LED_PIN7.BackColor = System.Drawing.Color.Gray
        Me.LED_PIN7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN7.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN7.Location = New System.Drawing.Point(260, 119)
        Me.LED_PIN7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN7.Name = "LED_PIN7"
        Me.LED_PIN7.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN7.TabIndex = 128
        Me.LED_PIN7.Text = "7"
        Me.LED_PIN7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN8
        '
        Me.LED_PIN8.BackColor = System.Drawing.Color.Gray
        Me.LED_PIN8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN8.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN8.Location = New System.Drawing.Point(215, 119)
        Me.LED_PIN8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN8.Name = "LED_PIN8"
        Me.LED_PIN8.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN8.TabIndex = 127
        Me.LED_PIN8.Text = "8"
        Me.LED_PIN8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN9
        '
        Me.LED_PIN9.BackColor = System.Drawing.Color.Gray
        Me.LED_PIN9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN9.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN9.Location = New System.Drawing.Point(169, 119)
        Me.LED_PIN9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN9.Name = "LED_PIN9"
        Me.LED_PIN9.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN9.TabIndex = 126
        Me.LED_PIN9.Text = "9"
        Me.LED_PIN9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN10
        '
        Me.LED_PIN10.BackColor = System.Drawing.Color.Gray
        Me.LED_PIN10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN10.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN10.Location = New System.Drawing.Point(124, 119)
        Me.LED_PIN10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN10.Name = "LED_PIN10"
        Me.LED_PIN10.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN10.TabIndex = 125
        Me.LED_PIN10.Text = "10"
        Me.LED_PIN10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN11
        '
        Me.LED_PIN11.BackColor = System.Drawing.Color.Green
        Me.LED_PIN11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN11.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN11.Location = New System.Drawing.Point(79, 119)
        Me.LED_PIN11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN11.Name = "LED_PIN11"
        Me.LED_PIN11.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN11.TabIndex = 124
        Me.LED_PIN11.Text = "11"
        Me.LED_PIN11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN12
        '
        Me.LED_PIN12.BackColor = System.Drawing.Color.Red
        Me.LED_PIN12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN12.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN12.Location = New System.Drawing.Point(33, 119)
        Me.LED_PIN12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN12.Name = "LED_PIN12"
        Me.LED_PIN12.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN12.TabIndex = 123
        Me.LED_PIN12.Text = "12"
        Me.LED_PIN12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN6
        '
        Me.LED_PIN6.BackColor = System.Drawing.Color.Red
        Me.LED_PIN6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN6.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN6.Location = New System.Drawing.Point(33, 78)
        Me.LED_PIN6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN6.Name = "LED_PIN6"
        Me.LED_PIN6.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN6.TabIndex = 122
        Me.LED_PIN6.Text = "6"
        Me.LED_PIN6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN5
        '
        Me.LED_PIN5.BackColor = System.Drawing.Color.Green
        Me.LED_PIN5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN5.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN5.Location = New System.Drawing.Point(79, 78)
        Me.LED_PIN5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN5.Name = "LED_PIN5"
        Me.LED_PIN5.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN5.TabIndex = 121
        Me.LED_PIN5.Text = "5"
        Me.LED_PIN5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN4
        '
        Me.LED_PIN4.BackColor = System.Drawing.Color.Gray
        Me.LED_PIN4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN4.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN4.Location = New System.Drawing.Point(124, 78)
        Me.LED_PIN4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN4.Name = "LED_PIN4"
        Me.LED_PIN4.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN4.TabIndex = 120
        Me.LED_PIN4.Text = "4"
        Me.LED_PIN4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN3
        '
        Me.LED_PIN3.BackColor = System.Drawing.Color.Gray
        Me.LED_PIN3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN3.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN3.Location = New System.Drawing.Point(169, 78)
        Me.LED_PIN3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN3.Name = "LED_PIN3"
        Me.LED_PIN3.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN3.TabIndex = 119
        Me.LED_PIN3.Text = "3"
        Me.LED_PIN3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN2
        '
        Me.LED_PIN2.BackColor = System.Drawing.Color.Gray
        Me.LED_PIN2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN2.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN2.Location = New System.Drawing.Point(215, 78)
        Me.LED_PIN2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN2.Name = "LED_PIN2"
        Me.LED_PIN2.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN2.TabIndex = 118
        Me.LED_PIN2.Text = "2"
        Me.LED_PIN2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LED_PIN1
        '
        Me.LED_PIN1.BackColor = System.Drawing.Color.Gray
        Me.LED_PIN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LED_PIN1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LED_PIN1.ForeColor = System.Drawing.Color.Black
        Me.LED_PIN1.Location = New System.Drawing.Point(260, 78)
        Me.LED_PIN1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LED_PIN1.Name = "LED_PIN1"
        Me.LED_PIN1.Size = New System.Drawing.Size(37, 34)
        Me.LED_PIN1.TabIndex = 117
        Me.LED_PIN1.Text = "1"
        Me.LED_PIN1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Group_PMOD_Peripheral_Support_Examples
        '
        Me.Group_PMOD_Peripheral_Support_Examples.Controls.Add(Me.Label9)
        Me.Group_PMOD_Peripheral_Support_Examples.Controls.Add(Me.Button_OpenDialog)
        Me.Group_PMOD_Peripheral_Support_Examples.Controls.Add(Me.ComboBox_SelectPMODPeripheral)
        Me.Group_PMOD_Peripheral_Support_Examples.Controls.Add(Me.Label8)
        Me.Group_PMOD_Peripheral_Support_Examples.Controls.Add(Me.Label7)
        Me.Group_PMOD_Peripheral_Support_Examples.Controls.Add(Me.Label6)
        Me.Group_PMOD_Peripheral_Support_Examples.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_PMOD_Peripheral_Support_Examples.ForeColor = System.Drawing.Color.Aqua
        Me.Group_PMOD_Peripheral_Support_Examples.Location = New System.Drawing.Point(16, 239)
        Me.Group_PMOD_Peripheral_Support_Examples.Margin = New System.Windows.Forms.Padding(4)
        Me.Group_PMOD_Peripheral_Support_Examples.Name = "Group_PMOD_Peripheral_Support_Examples"
        Me.Group_PMOD_Peripheral_Support_Examples.Padding = New System.Windows.Forms.Padding(4)
        Me.Group_PMOD_Peripheral_Support_Examples.Size = New System.Drawing.Size(764, 183)
        Me.Group_PMOD_Peripheral_Support_Examples.TabIndex = 90
        Me.Group_PMOD_Peripheral_Support_Examples.TabStop = False
        Me.Group_PMOD_Peripheral_Support_Examples.Text = "PMOD Peripheral Support Examples"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(31, 110)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(193, 20)
        Me.Label9.TabIndex = 162
        Me.Label9.Text = "Select PMOD Peripheral"
        '
        'Button_OpenDialog
        '
        Me.Button_OpenDialog.BackColor = System.Drawing.Color.Gray
        Me.Button_OpenDialog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_OpenDialog.ForeColor = System.Drawing.Color.Lime
        Me.Button_OpenDialog.Location = New System.Drawing.Point(431, 133)
        Me.Button_OpenDialog.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_OpenDialog.Name = "Button_OpenDialog"
        Me.Button_OpenDialog.Size = New System.Drawing.Size(299, 30)
        Me.Button_OpenDialog.TabIndex = 161
        Me.Button_OpenDialog.Text = "OPEN DIALOG"
        Me.Button_OpenDialog.UseVisualStyleBackColor = False
        '
        'ComboBox_SelectPMODPeripheral
        '
        Me.ComboBox_SelectPMODPeripheral.BackColor = System.Drawing.Color.Gray
        Me.ComboBox_SelectPMODPeripheral.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBox_SelectPMODPeripheral.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox_SelectPMODPeripheral.ForeColor = System.Drawing.Color.Lime
        Me.ComboBox_SelectPMODPeripheral.FormattingEnabled = True
        Me.ComboBox_SelectPMODPeripheral.Items.AddRange(New Object() {"ACW 24-Bit ADC", "ACW Dual 10-Bit DAC", "ACW Quad 10-Bit DAC", "ACW Humiture Sensor", "ACW Tri-color LED Module", "ACW RF Power Sensor", "ACW Presssure Sensor", "ACW Thermistor Input", "ACW RTD Input", "ACW Real Time Clock", "ACW 3-Axis Accelerometer", "ACW Everspin MRAM", "ACW Potentiometer", "ACW Compressed Air Sensor", "ACW Color Light Sensor", "Moco Makers Fipsy FPGA", "Digilent USB UART", "Digilent 4 Button Module", "Digilent 8 LED Module", "Digilent Temperature Sensor", "Digilent Ambient Light Sensor"})
        Me.ComboBox_SelectPMODPeripheral.Location = New System.Drawing.Point(32, 133)
        Me.ComboBox_SelectPMODPeripheral.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_SelectPMODPeripheral.Name = "ComboBox_SelectPMODPeripheral"
        Me.ComboBox_SelectPMODPeripheral.Size = New System.Drawing.Size(351, 28)
        Me.ComboBox_SelectPMODPeripheral.TabIndex = 91
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(29, 57)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(661, 20)
        Me.Label8.TabIndex = 160
        Me.Label8.Text = "-> Hot plugging usually causes problems, so connect peripheral before plugging in" &
    " USB"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(31, 76)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(674, 20)
        Me.Label7.TabIndex = 159
        Me.Label7.Text = "-> Remember, these dialogs are for test and demonstration, without a specific app" &
    "lication"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(28, 37)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(525, 20)
        Me.Label6.TabIndex = 142
        Me.Label6.Text = "-> Select connected PMOD peripheral and click button to open dialog"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(793, 438)
        Me.Controls.Add(Me.Group_PMOD_Peripheral_Support_Examples)
        Me.Controls.Add(Me.Group_PMOD_Configuration_And_Status)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(100, 100)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "BackHauler PMOD Test Software"
        Me.Group_PMOD_Configuration_And_Status.ResumeLayout(False)
        Me.Group_PMOD_Configuration_And_Status.PerformLayout()
        Me.Group_PMOD_Peripheral_Support_Examples.ResumeLayout(False)
        Me.Group_PMOD_Peripheral_Support_Examples.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PollTimer As System.Windows.Forms.Timer
    Friend WithEvents Group_PMOD_Configuration_And_Status As System.Windows.Forms.GroupBox
    Friend WithEvents LED_PIN1 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN7 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN8 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN9 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN10 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN11 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN12 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN6 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN5 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN4 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN3 As System.Windows.Forms.Label
    Friend WithEvents LED_PIN2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_PP_PIN7 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_PP_PIN8 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_PP_PIN9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_PP_PIN10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_PP_PIN1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_PP_PIN2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_PP_PIN3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_PP_PIN4 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_Poll_Pin_State As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LED_Configuration As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Group_PMOD_Peripheral_Support_Examples As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_SelectPMODPeripheral As System.Windows.Forms.ComboBox
    Friend WithEvents Button_OpenDialog As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
