<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMPartsToBeCreditedManager : Inherits FSM.FRMBaseForm : Implements IForm

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
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.txtCreditReference = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPart = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOrderReference = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpJobs = New System.Windows.Forms.GroupBox()
        Me.dgCredits = New System.Windows.Forms.DataGrid()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnGenerateCreditDocument = New System.Windows.Forms.Button()
        Me.btnCreditAmount = New System.Windows.Forms.Button()
        Me.grpFilter.SuspendLayout()
        Me.grpJobs.SuspendLayout()
        CType(Me.dgCredits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.Label5)
        Me.grpFilter.Controls.Add(Me.cboStatus)
        Me.grpFilter.Controls.Add(Me.txtCreditReference)
        Me.grpFilter.Controls.Add(Me.Label4)
        Me.grpFilter.Controls.Add(Me.txtPart)
        Me.grpFilter.Controls.Add(Me.Label3)
        Me.grpFilter.Controls.Add(Me.txtSupplier)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.txtOrderReference)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Location = New System.Drawing.Point(12, 38)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(859, 101)
        Me.grpFilter.TabIndex = 1
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(329, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(439, 41)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(329, 21)
        Me.cboStatus.TabIndex = 0
        '
        'txtCreditReference
        '
        Me.txtCreditReference.Location = New System.Drawing.Point(439, 14)
        Me.txtCreditReference.Name = "txtCreditReference"
        Me.txtCreditReference.Size = New System.Drawing.Size(206, 21)
        Me.txtCreditReference.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(329, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Credit Reference"
        '
        'txtPart
        '
        Me.txtPart.Location = New System.Drawing.Point(114, 68)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(206, 21)
        Me.txtPart.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Part"
        '
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(114, 41)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(206, 21)
        Me.txtSupplier.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Supplier"
        '
        'txtOrderReference
        '
        Me.txtOrderReference.Location = New System.Drawing.Point(114, 14)
        Me.txtOrderReference.Name = "txtOrderReference"
        Me.txtOrderReference.Size = New System.Drawing.Size(206, 21)
        Me.txtOrderReference.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order Reference"
        '
        'grpJobs
        '
        Me.grpJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobs.Controls.Add(Me.dgCredits)
        Me.grpJobs.Location = New System.Drawing.Point(12, 145)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(859, 309)
        Me.grpJobs.TabIndex = 2
        Me.grpJobs.TabStop = False
        Me.grpJobs.Text = "Double Click To View / Edit"
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
        Me.dgCredits.Size = New System.Drawing.Size(843, 281)
        Me.dgCredits.TabIndex = 0
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(12, 460)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        '
        'btnAddNew
        '
        Me.btnAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddNew.Location = New System.Drawing.Point(379, 460)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(162, 23)
        Me.btnAddNew.TabIndex = 4
        Me.btnAddNew.Text = "Add New Part To Credit"
        '
        'btnGenerateCreditDocument
        '
        Me.btnGenerateCreditDocument.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateCreditDocument.Location = New System.Drawing.Point(547, 460)
        Me.btnGenerateCreditDocument.Name = "btnGenerateCreditDocument"
        Me.btnGenerateCreditDocument.Size = New System.Drawing.Size(176, 23)
        Me.btnGenerateCreditDocument.TabIndex = 5
        Me.btnGenerateCreditDocument.Text = "Generate Credit Document"
        '
        'btnCreditAmount
        '
        Me.btnCreditAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreditAmount.Location = New System.Drawing.Point(729, 460)
        Me.btnCreditAmount.Name = "btnCreditAmount"
        Me.btnCreditAmount.Size = New System.Drawing.Size(134, 23)
        Me.btnCreditAmount.TabIndex = 0
        Me.btnCreditAmount.Text = "Add Credit Amount"
        '
        'FRMPartsToBeCreditedManager
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(883, 485)
        Me.Controls.Add(Me.btnCreditAmount)
        Me.Controls.Add(Me.btnGenerateCreditDocument)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.grpJobs)
        Me.Controls.Add(Me.btnReset)
        Me.Name = "FRMPartsToBeCreditedManager"
        Me.Text = "Parts To Be Credited Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpJobs, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.Controls.SetChildIndex(Me.btnAddNew, 0)
        Me.Controls.SetChildIndex(Me.btnGenerateCreditDocument, 0)
        Me.Controls.SetChildIndex(Me.btnCreditAmount, 0)
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgCredits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents grpJobs As System.Windows.Forms.GroupBox
    Friend WithEvents dgCredits As System.Windows.Forms.DataGrid
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnGenerateCreditDocument As System.Windows.Forms.Button
    Friend WithEvents btnCreditAmount As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtCreditReference As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOrderReference As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
