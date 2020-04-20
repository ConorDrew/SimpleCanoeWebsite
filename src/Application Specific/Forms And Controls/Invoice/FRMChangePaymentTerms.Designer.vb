<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMChangePaymentTerms : Inherits FSM.FRMBaseForm : Implements IForm

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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPaymentTerm = New System.Windows.Forms.ComboBox()
        Me.cboPaidBy = New System.Windows.Forms.ComboBox()
        Me.lblPaidBy = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cboPaidBy)
        Me.GroupBox1.Controls.Add(Me.lblPaidBy)
        Me.GroupBox1.Controls.Add(Me.cboPaymentTerm)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(502, 189)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Change Invoiced Total"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Payment Term"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(410, 160)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(194, 27)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(291, 21)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter the override password"
        '
        'cboPaymentTerm
        '
        Me.cboPaymentTerm.Enabled = False
        Me.cboPaymentTerm.FormattingEnabled = True
        Me.cboPaymentTerm.Location = New System.Drawing.Point(194, 58)
        Me.cboPaymentTerm.Name = "cboPaymentTerm"
        Me.cboPaymentTerm.Size = New System.Drawing.Size(291, 21)
        Me.cboPaymentTerm.TabIndex = 5
        '
        'cboPaidBy
        '
        Me.cboPaidBy.FormattingEnabled = True
        Me.cboPaidBy.Location = New System.Drawing.Point(194, 90)
        Me.cboPaidBy.Name = "cboPaidBy"
        Me.cboPaidBy.Size = New System.Drawing.Size(291, 21)
        Me.cboPaidBy.TabIndex = 7
        Me.cboPaidBy.Visible = False
        '
        'lblPaidBy
        '
        Me.lblPaidBy.AutoSize = True
        Me.lblPaidBy.Location = New System.Drawing.Point(6, 93)
        Me.lblPaidBy.Name = "lblPaidBy"
        Me.lblPaidBy.Size = New System.Drawing.Size(50, 13)
        Me.lblPaidBy.TabIndex = 6
        Me.lblPaidBy.Text = "Paid By"
        Me.lblPaidBy.Visible = False
        '
        'FRMChangePaymentTerms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 239)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRMChangePaymentTerms"
        Me.Text = "Change Invoiced Total"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPaidBy As System.Windows.Forms.ComboBox
    Friend WithEvents lblPaidBy As System.Windows.Forms.Label
    Friend WithEvents cboPaymentTerm As System.Windows.Forms.ComboBox
End Class
