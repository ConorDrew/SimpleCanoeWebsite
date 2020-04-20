<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMBookJob
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMBookJob))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEngineernotes = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.dtpDate = New Pabo.Calendar.MonthCalendar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAppointment = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtEngineernotes)
        Me.GroupBox1.Controls.Add(Me.lblMessage)
        Me.GroupBox1.Controls.Add(Me.dtpDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboAppointment)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(505, 421)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 333)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Additional Notes To Engineer"
        '
        'txtEngineernotes
        '
        Me.txtEngineernotes.Location = New System.Drawing.Point(170, 330)
        Me.txtEngineernotes.Multiline = True
        Me.txtEngineernotes.Name = "txtEngineernotes"
        Me.txtEngineernotes.Size = New System.Drawing.Size(226, 51)
        Me.txtEngineernotes.TabIndex = 13
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Maroon
        Me.lblMessage.Location = New System.Drawing.Point(7, 241)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(492, 24)
        Me.lblMessage.TabIndex = 12
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'dtpDate
        '
        Me.dtpDate.ActiveMonth.Month = 5
        Me.dtpDate.ActiveMonth.Year = 2017
        Me.dtpDate.Culture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpDate.Footer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dtpDate.Header.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dtpDate.Header.TextColor = System.Drawing.Color.White
        Me.dtpDate.ImageList = Nothing
        Me.dtpDate.Location = New System.Drawing.Point(170, 43)
        Me.dtpDate.MaxDate = New Date(2027, 5, 10, 12, 28, 13, 983)
        Me.dtpDate.MinDate = New Date(2007, 5, 10, 12, 28, 13, 983)
        Me.dtpDate.Month.BackgroundImage = Nothing
        Me.dtpDate.Month.DateFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpDate.Month.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.SelectionMode = Pabo.Calendar.mcSelectionMode.One
        Me.dtpDate.Size = New System.Drawing.Size(225, 195)
        Me.dtpDate.TabIndex = 11
        Me.dtpDate.Weekdays.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpDate.Weeknumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(93, 282)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Appointment"
        '
        'cboAppointment
        '
        Me.cboAppointment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAppointment.FormattingEnabled = True
        Me.cboAppointment.Location = New System.Drawing.Point(170, 277)
        Me.cboAppointment.Name = "cboAppointment"
        Me.cboAppointment.Size = New System.Drawing.Size(226, 21)
        Me.cboAppointment.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Location = New System.Drawing.Point(7, 392)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(184, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(186, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Please select an Appointment"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(93, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Date"
        '
        'btnOK
        '
        Me.btnOK.UseVisualStyleBackColor = True
        Me.btnOK.Location = New System.Drawing.Point(424, 392)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "Proceed"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FRMBookJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(513, 434)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(529, 393)
        Me.Name = "FRMBookJob"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Book Appointment"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAppointment As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDate As Pabo.Calendar.MonthCalendar
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEngineernotes As System.Windows.Forms.TextBox
End Class
