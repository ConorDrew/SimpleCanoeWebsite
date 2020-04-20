<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMCreditReceived : Inherits FSM.FRMBaseForm : Implements IForm

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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtExtraRef = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpDateReceived = New System.Windows.Forms.DateTimePicker
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.txtNominalCode = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtVAT = New System.Windows.Forms.TextBox
        Me.cboTaxCode = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtnotes = New System.Windows.Forms.TextBox
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.txtCreditReference = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.grpJobs = New System.Windows.Forms.GroupBox
        Me.dgCredits = New System.Windows.Forms.DataGrid
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtOrignalAmount = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSupplierCreditRef = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.grpJobs.SuspendLayout()
        CType(Me.dgCredits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtSupplierCreditRef)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtExtraRef)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpDateReceived)
        Me.GroupBox1.Controls.Add(Me.txtDepartment)
        Me.GroupBox1.Controls.Add(Me.txtNominalCode)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtVAT)
        Me.GroupBox1.Controls.Add(Me.cboTaxCode)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtnotes)
        Me.GroupBox1.Controls.Add(Me.txtTotalAmount)
        Me.GroupBox1.Controls.Add(Me.txtCreditReference)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(868, 126)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Credit Received"
        '
        'txtExtraRef
        '
        Me.txtExtraRef.Location = New System.Drawing.Point(329, 95)
        Me.txtExtraRef.MaxLength = 100
        Me.txtExtraRef.Name = "txtExtraRef"
        Me.txtExtraRef.Size = New System.Drawing.Size(195, 21)
        Me.txtExtraRef.TabIndex = 8
        Me.txtExtraRef.Tag = " "
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(265, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 20)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Extra Ref"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Date Received"
        '
        'dtpDateReceived
        '
        Me.dtpDateReceived.Location = New System.Drawing.Point(116, 66)
        Me.dtpDateReceived.Name = "dtpDateReceived"
        Me.dtpDateReceived.Size = New System.Drawing.Size(142, 21)
        Me.dtpDateReceived.TabIndex = 2
        '
        'txtDepartment
        '
        Me.txtDepartment.Location = New System.Drawing.Point(437, 43)
        Me.txtDepartment.MaxLength = 100
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(88, 21)
        Me.txtDepartment.TabIndex = 5
        Me.txtDepartment.Tag = "Order.SupplierInvoiceReference"
        '
        'txtNominalCode
        '
        Me.txtNominalCode.Location = New System.Drawing.Point(329, 43)
        Me.txtNominalCode.MaxLength = 100
        Me.txtNominalCode.Name = "txtNominalCode"
        Me.txtNominalCode.Size = New System.Drawing.Size(58, 21)
        Me.txtNominalCode.TabIndex = 4
        Me.txtNominalCode.Tag = "Order.SupplierInvoiceReference"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(265, 43)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 20)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "Nominal"
        '
        'txtVAT
        '
        Me.txtVAT.Location = New System.Drawing.Point(437, 69)
        Me.txtVAT.MaxLength = 100
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.ReadOnly = True
        Me.txtVAT.Size = New System.Drawing.Size(87, 21)
        Me.txtVAT.TabIndex = 7
        Me.txtVAT.Tag = "Order.SupplierInvoiceAmount"
        '
        'cboTaxCode
        '
        Me.cboTaxCode.Location = New System.Drawing.Point(329, 69)
        Me.cboTaxCode.Name = "cboTaxCode"
        Me.cboTaxCode.Size = New System.Drawing.Size(58, 21)
        Me.cboTaxCode.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(265, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 20)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "Tax Code"
        '
        'txtnotes
        '
        Me.txtnotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtnotes.Location = New System.Drawing.Point(571, 14)
        Me.txtnotes.Multiline = True
        Me.txtnotes.Name = "txtnotes"
        Me.txtnotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtnotes.Size = New System.Drawing.Size(290, 102)
        Me.txtnotes.TabIndex = 9
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Location = New System.Drawing.Point(116, 40)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(142, 21)
        Me.txtTotalAmount.TabIndex = 1
        '
        'txtCreditReference
        '
        Me.txtCreditReference.Location = New System.Drawing.Point(116, 14)
        Me.txtCreditReference.Name = "txtCreditReference"
        Me.txtCreditReference.ReadOnly = True
        Me.txtCreditReference.Size = New System.Drawing.Size(142, 21)
        Me.txtCreditReference.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(526, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Notes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Amount"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Credit Reference"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(402, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 20)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "VAT"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(402, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 20)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "Dept"
        '
        'grpJobs
        '
        Me.grpJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobs.Controls.Add(Me.dgCredits)
        Me.grpJobs.Location = New System.Drawing.Point(12, 170)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(868, 261)
        Me.grpJobs.TabIndex = 3
        Me.grpJobs.TabStop = False
        Me.grpJobs.Text = "Parts"
        '
        'dgCredits
        '
        Me.dgCredits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCredits.DataMember = ""
        Me.dgCredits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCredits.Location = New System.Drawing.Point(8, 20)
        Me.dgCredits.Name = "dgCredits"
        Me.dgCredits.Size = New System.Drawing.Size(852, 233)
        Me.dgCredits.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(805, 439)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtOrignalAmount
        '
        Me.txtOrignalAmount.Location = New System.Drawing.Point(117, 439)
        Me.txtOrignalAmount.Name = "txtOrignalAmount"
        Me.txtOrignalAmount.ReadOnly = True
        Me.txtOrignalAmount.Size = New System.Drawing.Size(142, 21)
        Me.txtOrignalAmount.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 442)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Original Amount"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(265, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Supplier Credit Ref"
        '
        'txtSupplierCreditRef
        '
        Me.txtSupplierCreditRef.Location = New System.Drawing.Point(387, 14)
        Me.txtSupplierCreditRef.MaxLength = 100
        Me.txtSupplierCreditRef.Name = "txtSupplierCreditRef"
        Me.txtSupplierCreditRef.Size = New System.Drawing.Size(138, 21)
        Me.txtSupplierCreditRef.TabIndex = 3
        Me.txtSupplierCreditRef.Tag = " "
        '
        'FRMCreditReceived
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 470)
        Me.Controls.Add(Me.txtOrignalAmount)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpJobs)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRMCreditReceived"
        Me.Text = "Credit Received"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.grpJobs, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtOrignalAmount, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgCredits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnotes As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditReference As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpJobs As System.Windows.Forms.GroupBox
    Friend WithEvents dgCredits As System.Windows.Forms.DataGrid
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents txtNominalCode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents cboTaxCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtExtraRef As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpDateReceived As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtOrignalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierCreditRef As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
