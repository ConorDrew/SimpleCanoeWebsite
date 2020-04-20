Imports FSM.Entity.Sys

Public Class FRMLogCallout : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        TheLoadedControl = New UCLogCallout
        Me.tpMain.Controls.Add(TheLoadedControl)
        AddHandler LoadedControl.StateChanged, AddressOf ResetMe

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents btnClose As System.Windows.Forms.Button

    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents tpDocuments As System.Windows.Forms.TabPage
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents tpAssets As System.Windows.Forms.TabPage
    Friend WithEvents dgAssets As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddAppliance As System.Windows.Forms.Button
    Friend WithEvents grpAssets As System.Windows.Forms.GroupBox
    Friend WithEvents tpNotes As System.Windows.Forms.TabPage
    Friend WithEvents gpbNotes As System.Windows.Forms.GroupBox
    Friend WithEvents dgNotes As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddNote As System.Windows.Forms.Button
    Friend WithEvents gpbNotesDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoteID As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveNote As System.Windows.Forms.Button
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteNote As System.Windows.Forms.Button
    Friend WithEvents tbquote As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmsView As ContextMenuStrip
    Friend WithEvents PropertyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AuditTrailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InvoiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuoteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CostingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdoAXA As RadioButton
    Friend WithEvents rdoPOC As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkExcludeVat As CheckBox
    Friend WithEvents cboVATRate As ComboBox
    Friend WithEvents lblVAT As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rbStandard As RadioButton
    Friend WithEvents rbSite As RadioButton
    Friend WithEvents txtPartQty As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents dgvQuote As DataGridView
    Friend WithEvents cboLabour As ComboBox
    Friend WithEvents btnQuoteAdd As Button
    Friend WithEvents Label45 As Label
    Friend WithEvents txtLabourQty As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents btnaddtonotes As Button
    Friend WithEvents btnEmail As Button
    Friend WithEvents btncalc As Button
    Friend WithEvents tbresult As TextBox
    Friend WithEvents txtPartRate As TextBox
    Friend WithEvents lbltc1 As Label
    Friend WithEvents txtPartNumber As TextBox
    Friend WithEvents lblnumber1 As Label
    Friend WithEvents txtPartName As TextBox
    Friend WithEvents lblpart1 As Label
    Friend WithEvents txtClaimLimit As TextBox
    Friend WithEvents tpContactAttempts As TabPage
    Friend WithEvents grpContactAttemptDetails As GroupBox
    Friend WithEvents txtContactAttemptDetails As TextBox
    Friend WithEvents lblContactNotes As Label
    Friend WithEvents grpContactAttempts As GroupBox
    Friend WithEvents dgContactAttempts As DataGrid
    Friend WithEvents btnAddAttempt As Button
    Friend WithEvents lblClaimLimit As Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.tpAssets = New System.Windows.Forms.TabPage()
        Me.grpAssets = New System.Windows.Forms.GroupBox()
        Me.dgAssets = New System.Windows.Forms.DataGrid()
        Me.btnAddAppliance = New System.Windows.Forms.Button()
        Me.tpDocuments = New System.Windows.Forms.TabPage()
        Me.tbquote = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoAXA = New System.Windows.Forms.RadioButton()
        Me.rdoPOC = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtClaimLimit = New System.Windows.Forms.TextBox()
        Me.lblClaimLimit = New System.Windows.Forms.Label()
        Me.chkExcludeVat = New System.Windows.Forms.CheckBox()
        Me.cboVATRate = New System.Windows.Forms.ComboBox()
        Me.lblVAT = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbStandard = New System.Windows.Forms.RadioButton()
        Me.rbSite = New System.Windows.Forms.RadioButton()
        Me.txtPartQty = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.dgvQuote = New System.Windows.Forms.DataGridView()
        Me.cboLabour = New System.Windows.Forms.ComboBox()
        Me.btnQuoteAdd = New System.Windows.Forms.Button()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtLabourQty = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnaddtonotes = New System.Windows.Forms.Button()
        Me.btnEmail = New System.Windows.Forms.Button()
        Me.btncalc = New System.Windows.Forms.Button()
        Me.tbresult = New System.Windows.Forms.TextBox()
        Me.txtPartRate = New System.Windows.Forms.TextBox()
        Me.lbltc1 = New System.Windows.Forms.Label()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.lblnumber1 = New System.Windows.Forms.Label()
        Me.txtPartName = New System.Windows.Forms.TextBox()
        Me.lblpart1 = New System.Windows.Forms.Label()
        Me.tpNotes = New System.Windows.Forms.TabPage()
        Me.gpbNotesDetails = New System.Windows.Forms.GroupBox()
        Me.txtNoteID = New System.Windows.Forms.TextBox()
        Me.btnSaveNote = New System.Windows.Forms.Button()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gpbNotes = New System.Windows.Forms.GroupBox()
        Me.btnDeleteNote = New System.Windows.Forms.Button()
        Me.dgNotes = New System.Windows.Forms.DataGrid()
        Me.btnAddNote = New System.Windows.Forms.Button()
        Me.tpContactAttempts = New System.Windows.Forms.TabPage()
        Me.grpContactAttemptDetails = New System.Windows.Forms.GroupBox()
        Me.txtContactAttemptDetails = New System.Windows.Forms.TextBox()
        Me.lblContactNotes = New System.Windows.Forms.Label()
        Me.grpContactAttempts = New System.Windows.Forms.GroupBox()
        Me.dgContactAttempts = New System.Windows.Forms.DataGrid()
        Me.btnAddAttempt = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.cmsView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PropertyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuditTrailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CostingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.tpAssets.SuspendLayout()
        Me.grpAssets.SuspendLayout()
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbquote.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvQuote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpNotes.SuspendLayout()
        Me.gpbNotesDetails.SuspendLayout()
        Me.gpbNotes.SuspendLayout()
        CType(Me.dgNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpContactAttempts.SuspendLayout()
        Me.grpContactAttemptDetails.SuspendLayout()
        Me.grpContactAttempts.SuspendLayout()
        CType(Me.dgContactAttempts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsView.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(70, 664)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(8, 664)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 23)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpMain)
        Me.TabControl1.Controls.Add(Me.tpAssets)
        Me.TabControl1.Controls.Add(Me.tpDocuments)
        Me.TabControl1.Controls.Add(Me.tbquote)
        Me.TabControl1.Controls.Add(Me.tpNotes)
        Me.TabControl1.Controls.Add(Me.tpContactAttempts)
        Me.TabControl1.Location = New System.Drawing.Point(0, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1184, 627)
        Me.TabControl1.TabIndex = 23
        '
        'tpMain
        '
        Me.tpMain.Location = New System.Drawing.Point(4, 22)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(1176, 601)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main Details"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'tpAssets
        '
        Me.tpAssets.Controls.Add(Me.grpAssets)
        Me.tpAssets.Location = New System.Drawing.Point(4, 22)
        Me.tpAssets.Name = "tpAssets"
        Me.tpAssets.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAssets.Size = New System.Drawing.Size(1176, 601)
        Me.tpAssets.TabIndex = 2
        Me.tpAssets.Text = "Appliances"
        Me.tpAssets.UseVisualStyleBackColor = True
        '
        'grpAssets
        '
        Me.grpAssets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAssets.Controls.Add(Me.dgAssets)
        Me.grpAssets.Controls.Add(Me.btnAddAppliance)
        Me.grpAssets.Location = New System.Drawing.Point(6, 6)
        Me.grpAssets.Name = "grpAssets"
        Me.grpAssets.Size = New System.Drawing.Size(1162, 596)
        Me.grpAssets.TabIndex = 29
        Me.grpAssets.TabStop = False
        Me.grpAssets.Text = "Select those related to the job"
        '
        'dgAssets
        '
        Me.dgAssets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAssets.DataMember = ""
        Me.dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAssets.Location = New System.Drawing.Point(6, 20)
        Me.dgAssets.Name = "dgAssets"
        Me.dgAssets.Size = New System.Drawing.Size(1150, 541)
        Me.dgAssets.TabIndex = 1
        '
        'btnAddAppliance
        '
        Me.btnAddAppliance.AccessibleDescription = "Add Job Of Work"
        Me.btnAddAppliance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddAppliance.Location = New System.Drawing.Point(6, 567)
        Me.btnAddAppliance.Name = "btnAddAppliance"
        Me.btnAddAppliance.Size = New System.Drawing.Size(155, 23)
        Me.btnAddAppliance.TabIndex = 28
        Me.btnAddAppliance.Text = "New Appliance"
        '
        'tpDocuments
        '
        Me.tpDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tpDocuments.Name = "tpDocuments"
        Me.tpDocuments.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDocuments.Size = New System.Drawing.Size(1176, 601)
        Me.tpDocuments.TabIndex = 1
        Me.tpDocuments.Text = "Documents"
        Me.tpDocuments.UseVisualStyleBackColor = True
        '
        'tbquote
        '
        Me.tbquote.Controls.Add(Me.GroupBox2)
        Me.tbquote.Location = New System.Drawing.Point(4, 22)
        Me.tbquote.Name = "tbquote"
        Me.tbquote.Padding = New System.Windows.Forms.Padding(3)
        Me.tbquote.Size = New System.Drawing.Size(1176, 601)
        Me.tbquote.TabIndex = 7
        Me.tbquote.Text = "Quote Calc"
        Me.tbquote.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1170, 595)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Quote Calculator"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoAXA)
        Me.GroupBox1.Controls.Add(Me.rdoPOC)
        Me.GroupBox1.Location = New System.Drawing.Point(55, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(121, 45)
        Me.GroupBox1.TabIndex = 82
        Me.GroupBox1.TabStop = False
        '
        'rdoAXA
        '
        Me.rdoAXA.AutoSize = True
        Me.rdoAXA.Location = New System.Drawing.Point(65, 17)
        Me.rdoAXA.Name = "rdoAXA"
        Me.rdoAXA.Size = New System.Drawing.Size(49, 17)
        Me.rdoAXA.TabIndex = 1
        Me.rdoAXA.Text = "AXA"
        Me.rdoAXA.UseVisualStyleBackColor = True
        '
        'rdoPOC
        '
        Me.rdoPOC.AutoSize = True
        Me.rdoPOC.Checked = True
        Me.rdoPOC.Location = New System.Drawing.Point(6, 17)
        Me.rdoPOC.Name = "rdoPOC"
        Me.rdoPOC.Size = New System.Drawing.Size(50, 17)
        Me.rdoPOC.TabIndex = 0
        Me.rdoPOC.TabStop = True
        Me.rdoPOC.Text = "POC"
        Me.rdoPOC.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtClaimLimit)
        Me.Panel1.Controls.Add(Me.lblClaimLimit)
        Me.Panel1.Controls.Add(Me.chkExcludeVat)
        Me.Panel1.Controls.Add(Me.cboVATRate)
        Me.Panel1.Controls.Add(Me.lblVAT)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.txtPartQty)
        Me.Panel1.Controls.Add(Me.Label46)
        Me.Panel1.Controls.Add(Me.dgvQuote)
        Me.Panel1.Controls.Add(Me.cboLabour)
        Me.Panel1.Controls.Add(Me.btnQuoteAdd)
        Me.Panel1.Controls.Add(Me.Label45)
        Me.Panel1.Controls.Add(Me.txtLabourQty)
        Me.Panel1.Controls.Add(Me.Label44)
        Me.Panel1.Controls.Add(Me.btnReset)
        Me.Panel1.Controls.Add(Me.btnaddtonotes)
        Me.Panel1.Controls.Add(Me.btnEmail)
        Me.Panel1.Controls.Add(Me.btncalc)
        Me.Panel1.Controls.Add(Me.tbresult)
        Me.Panel1.Controls.Add(Me.txtPartRate)
        Me.Panel1.Controls.Add(Me.lbltc1)
        Me.Panel1.Controls.Add(Me.txtPartNumber)
        Me.Panel1.Controls.Add(Me.lblnumber1)
        Me.Panel1.Controls.Add(Me.txtPartName)
        Me.Panel1.Controls.Add(Me.lblpart1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1164, 575)
        Me.Panel1.TabIndex = 1
        '
        'txtClaimLimit
        '
        Me.txtClaimLimit.Location = New System.Drawing.Point(585, 62)
        Me.txtClaimLimit.Name = "txtClaimLimit"
        Me.txtClaimLimit.Size = New System.Drawing.Size(121, 21)
        Me.txtClaimLimit.TabIndex = 83
        Me.txtClaimLimit.Visible = False
        '
        'lblClaimLimit
        '
        Me.lblClaimLimit.AutoSize = True
        Me.lblClaimLimit.Location = New System.Drawing.Point(505, 65)
        Me.lblClaimLimit.Name = "lblClaimLimit"
        Me.lblClaimLimit.Size = New System.Drawing.Size(71, 13)
        Me.lblClaimLimit.TabIndex = 82
        Me.lblClaimLimit.Text = "Claim Limit"
        Me.lblClaimLimit.Visible = False
        '
        'chkExcludeVat
        '
        Me.chkExcludeVat.AutoSize = True
        Me.chkExcludeVat.Location = New System.Drawing.Point(425, 505)
        Me.chkExcludeVat.Name = "chkExcludeVat"
        Me.chkExcludeVat.Size = New System.Drawing.Size(103, 17)
        Me.chkExcludeVat.TabIndex = 81
        Me.chkExcludeVat.Text = "Exclude V.A.T"
        Me.chkExcludeVat.UseVisualStyleBackColor = True
        '
        'cboVATRate
        '
        Me.cboVATRate.FormattingEnabled = True
        Me.cboVATRate.Location = New System.Drawing.Point(499, 528)
        Me.cboVATRate.Name = "cboVATRate"
        Me.cboVATRate.Size = New System.Drawing.Size(109, 21)
        Me.cboVATRate.TabIndex = 79
        '
        'lblVAT
        '
        Me.lblVAT.Location = New System.Drawing.Point(422, 529)
        Me.lblVAT.Name = "lblVAT"
        Me.lblVAT.Size = New System.Drawing.Size(68, 17)
        Me.lblVAT.TabIndex = 80
        Me.lblVAT.Text = "VAT Rate"
        Me.lblVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbStandard)
        Me.GroupBox3.Controls.Add(Me.rbSite)
        Me.GroupBox3.Location = New System.Drawing.Point(48, 491)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(343, 45)
        Me.GroupBox3.TabIndex = 77
        Me.GroupBox3.TabStop = False
        '
        'rbStandard
        '
        Me.rbStandard.AutoSize = True
        Me.rbStandard.Checked = True
        Me.rbStandard.Location = New System.Drawing.Point(207, 16)
        Me.rbStandard.Name = "rbStandard"
        Me.rbStandard.Size = New System.Drawing.Size(121, 17)
        Me.rbStandard.TabIndex = 1
        Me.rbStandard.TabStop = True
        Me.rbStandard.Text = "Markup standard"
        Me.rbStandard.UseVisualStyleBackColor = True
        '
        'rbSite
        '
        Me.rbSite.AutoSize = True
        Me.rbSite.Location = New System.Drawing.Point(6, 17)
        Me.rbSite.Name = "rbSite"
        Me.rbSite.Size = New System.Drawing.Size(185, 17)
        Me.rbSite.TabIndex = 0
        Me.rbSite.Text = "Markup parts using site rate"
        Me.rbSite.UseVisualStyleBackColor = True
        '
        'txtPartQty
        '
        Me.txtPartQty.Location = New System.Drawing.Point(659, 89)
        Me.txtPartQty.Name = "txtPartQty"
        Me.txtPartQty.Size = New System.Drawing.Size(48, 21)
        Me.txtPartQty.TabIndex = 76
        Me.txtPartQty.Text = "0"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(629, 92)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(27, 13)
        Me.Label46.TabIndex = 75
        Me.Label46.Text = "Qty"
        '
        'dgvQuote
        '
        Me.dgvQuote.AllowUserToAddRows = False
        Me.dgvQuote.AllowUserToResizeColumns = False
        Me.dgvQuote.AllowUserToResizeRows = False
        Me.dgvQuote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuote.Location = New System.Drawing.Point(48, 124)
        Me.dgvQuote.Name = "dgvQuote"
        Me.dgvQuote.Size = New System.Drawing.Size(811, 210)
        Me.dgvQuote.TabIndex = 74
        '
        'cboLabour
        '
        Me.cboLabour.FormattingEnabled = True
        Me.cboLabour.Location = New System.Drawing.Point(125, 62)
        Me.cboLabour.Name = "cboLabour"
        Me.cboLabour.Size = New System.Drawing.Size(294, 21)
        Me.cboLabour.TabIndex = 73
        '
        'btnQuoteAdd
        '
        Me.btnQuoteAdd.Location = New System.Drawing.Point(820, 65)
        Me.btnQuoteAdd.Name = "btnQuoteAdd"
        Me.btnQuoteAdd.Size = New System.Drawing.Size(39, 47)
        Me.btnQuoteAdd.TabIndex = 72
        Me.btnQuoteAdd.Text = "Add"
        Me.btnQuoteAdd.UseVisualStyleBackColor = True
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(45, 65)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(77, 13)
        Me.Label45.TabIndex = 71
        Me.Label45.Text = "Labour Type"
        '
        'txtLabourQty
        '
        Me.txtLabourQty.Location = New System.Drawing.Point(449, 62)
        Me.txtLabourQty.Name = "txtLabourQty"
        Me.txtLabourQty.Size = New System.Drawing.Size(29, 21)
        Me.txtLabourQty.TabIndex = 70
        Me.txtLabourQty.Text = "0"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(427, 65)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(15, 13)
        Me.Label44.TabIndex = 69
        Me.Label44.Text = "X"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(614, 526)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(110, 23)
        Me.btnReset.TabIndex = 68
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnaddtonotes
        '
        Me.btnaddtonotes.Enabled = False
        Me.btnaddtonotes.Location = New System.Drawing.Point(730, 499)
        Me.btnaddtonotes.Name = "btnaddtonotes"
        Me.btnaddtonotes.Size = New System.Drawing.Size(130, 23)
        Me.btnaddtonotes.TabIndex = 67
        Me.btnaddtonotes.Text = "Add Quote to Notes"
        Me.btnaddtonotes.UseVisualStyleBackColor = True
        '
        'btnEmail
        '
        Me.btnEmail.Enabled = False
        Me.btnEmail.Location = New System.Drawing.Point(730, 526)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(130, 23)
        Me.btnEmail.TabIndex = 66
        Me.btnEmail.Text = "Email Quote"
        Me.btnEmail.UseVisualStyleBackColor = True
        '
        'btncalc
        '
        Me.btncalc.Location = New System.Drawing.Point(614, 499)
        Me.btncalc.Name = "btncalc"
        Me.btncalc.Size = New System.Drawing.Size(110, 23)
        Me.btncalc.TabIndex = 65
        Me.btncalc.Text = "Generate Quote"
        Me.btncalc.UseVisualStyleBackColor = True
        '
        'tbresult
        '
        Me.tbresult.Location = New System.Drawing.Point(48, 357)
        Me.tbresult.Multiline = True
        Me.tbresult.Name = "tbresult"
        Me.tbresult.ReadOnly = True
        Me.tbresult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbresult.Size = New System.Drawing.Size(812, 128)
        Me.tbresult.TabIndex = 64
        Me.tbresult.Text = "Please enter details above. Quote will appear here"
        '
        'txtPartRate
        '
        Me.txtPartRate.Location = New System.Drawing.Point(558, 89)
        Me.txtPartRate.Name = "txtPartRate"
        Me.txtPartRate.Size = New System.Drawing.Size(55, 21)
        Me.txtPartRate.TabIndex = 5
        '
        'lbltc1
        '
        Me.lbltc1.AutoSize = True
        Me.lbltc1.Location = New System.Drawing.Point(456, 92)
        Me.lbltc1.Name = "lbltc1"
        Me.lbltc1.Size = New System.Drawing.Size(96, 13)
        Me.lbltc1.TabIndex = 4
        Me.lbltc1.Text = "Part Trade Cost"
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Location = New System.Drawing.Point(349, 89)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(89, 21)
        Me.txtPartNumber.TabIndex = 3
        '
        'lblnumber1
        '
        Me.lblnumber1.AutoSize = True
        Me.lblnumber1.Location = New System.Drawing.Point(264, 92)
        Me.lblnumber1.Name = "lblnumber1"
        Me.lblnumber1.Size = New System.Drawing.Size(79, 13)
        Me.lblnumber1.TabIndex = 2
        Me.lblnumber1.Text = "Part Number"
        '
        'txtPartName
        '
        Me.txtPartName.Location = New System.Drawing.Point(125, 89)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(121, 21)
        Me.txtPartName.TabIndex = 1
        '
        'lblpart1
        '
        Me.lblpart1.AutoSize = True
        Me.lblpart1.Location = New System.Drawing.Point(45, 92)
        Me.lblpart1.Name = "lblpart1"
        Me.lblpart1.Size = New System.Drawing.Size(67, 13)
        Me.lblpart1.TabIndex = 0
        Me.lblpart1.Text = "Part Name"
        '
        'tpNotes
        '
        Me.tpNotes.Controls.Add(Me.gpbNotesDetails)
        Me.tpNotes.Controls.Add(Me.gpbNotes)
        Me.tpNotes.Location = New System.Drawing.Point(4, 22)
        Me.tpNotes.Name = "tpNotes"
        Me.tpNotes.Size = New System.Drawing.Size(1176, 601)
        Me.tpNotes.TabIndex = 4
        Me.tpNotes.Text = "Notes"
        Me.tpNotes.UseVisualStyleBackColor = True
        '
        'gpbNotesDetails
        '
        Me.gpbNotesDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbNotesDetails.Controls.Add(Me.txtNoteID)
        Me.gpbNotesDetails.Controls.Add(Me.btnSaveNote)
        Me.gpbNotesDetails.Controls.Add(Me.txtNotes)
        Me.gpbNotesDetails.Controls.Add(Me.Label1)
        Me.gpbNotesDetails.Location = New System.Drawing.Point(791, 6)
        Me.gpbNotesDetails.Name = "gpbNotesDetails"
        Me.gpbNotesDetails.Size = New System.Drawing.Size(377, 596)
        Me.gpbNotesDetails.TabIndex = 33
        Me.gpbNotesDetails.TabStop = False
        Me.gpbNotesDetails.Text = "Details"
        '
        'txtNoteID
        '
        Me.txtNoteID.Location = New System.Drawing.Point(66, 14)
        Me.txtNoteID.Name = "txtNoteID"
        Me.txtNoteID.Size = New System.Drawing.Size(100, 21)
        Me.txtNoteID.TabIndex = 36
        Me.txtNoteID.TabStop = False
        Me.txtNoteID.Visible = False
        '
        'btnSaveNote
        '
        Me.btnSaveNote.AccessibleDescription = ""
        Me.btnSaveNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveNote.Location = New System.Drawing.Point(292, 567)
        Me.btnSaveNote.Name = "btnSaveNote"
        Me.btnSaveNote.Size = New System.Drawing.Size(79, 23)
        Me.btnSaveNote.TabIndex = 1
        Me.btnSaveNote.Text = "Save"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(6, 37)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(365, 524)
        Me.txtNotes.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Notes:"
        '
        'gpbNotes
        '
        Me.gpbNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbNotes.Controls.Add(Me.btnDeleteNote)
        Me.gpbNotes.Controls.Add(Me.dgNotes)
        Me.gpbNotes.Controls.Add(Me.btnAddNote)
        Me.gpbNotes.Location = New System.Drawing.Point(7, 6)
        Me.gpbNotes.Name = "gpbNotes"
        Me.gpbNotes.Size = New System.Drawing.Size(773, 596)
        Me.gpbNotes.TabIndex = 30
        Me.gpbNotes.TabStop = False
        Me.gpbNotes.Text = "Notes"
        '
        'btnDeleteNote
        '
        Me.btnDeleteNote.AccessibleDescription = ""
        Me.btnDeleteNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteNote.Location = New System.Drawing.Point(95, 567)
        Me.btnDeleteNote.Name = "btnDeleteNote"
        Me.btnDeleteNote.Size = New System.Drawing.Size(85, 23)
        Me.btnDeleteNote.TabIndex = 3
        Me.btnDeleteNote.Text = "Delete"
        Me.btnDeleteNote.Visible = False
        '
        'dgNotes
        '
        Me.dgNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgNotes.DataMember = ""
        Me.dgNotes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgNotes.Location = New System.Drawing.Point(6, 20)
        Me.dgNotes.Name = "dgNotes"
        Me.dgNotes.Size = New System.Drawing.Size(761, 541)
        Me.dgNotes.TabIndex = 1
        '
        'btnAddNote
        '
        Me.btnAddNote.AccessibleDescription = ""
        Me.btnAddNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddNote.Location = New System.Drawing.Point(6, 567)
        Me.btnAddNote.Name = "btnAddNote"
        Me.btnAddNote.Size = New System.Drawing.Size(85, 23)
        Me.btnAddNote.TabIndex = 2
        Me.btnAddNote.Text = "Add"
        '
        'tpContactAttempts
        '
        Me.tpContactAttempts.Controls.Add(Me.grpContactAttemptDetails)
        Me.tpContactAttempts.Controls.Add(Me.grpContactAttempts)
        Me.tpContactAttempts.Location = New System.Drawing.Point(4, 22)
        Me.tpContactAttempts.Name = "tpContactAttempts"
        Me.tpContactAttempts.Size = New System.Drawing.Size(1176, 601)
        Me.tpContactAttempts.TabIndex = 8
        Me.tpContactAttempts.Text = "Contact Attempts"
        Me.tpContactAttempts.UseVisualStyleBackColor = True
        '
        'grpContactAttemptDetails
        '
        Me.grpContactAttemptDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContactAttemptDetails.Controls.Add(Me.txtContactAttemptDetails)
        Me.grpContactAttemptDetails.Controls.Add(Me.lblContactNotes)
        Me.grpContactAttemptDetails.Location = New System.Drawing.Point(792, 2)
        Me.grpContactAttemptDetails.Name = "grpContactAttemptDetails"
        Me.grpContactAttemptDetails.Size = New System.Drawing.Size(377, 596)
        Me.grpContactAttemptDetails.TabIndex = 35
        Me.grpContactAttemptDetails.TabStop = False
        Me.grpContactAttemptDetails.Text = "Details"
        '
        'txtContactAttemptDetails
        '
        Me.txtContactAttemptDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContactAttemptDetails.Location = New System.Drawing.Point(6, 37)
        Me.txtContactAttemptDetails.Multiline = True
        Me.txtContactAttemptDetails.Name = "txtContactAttemptDetails"
        Me.txtContactAttemptDetails.ReadOnly = True
        Me.txtContactAttemptDetails.Size = New System.Drawing.Size(365, 553)
        Me.txtContactAttemptDetails.TabIndex = 0
        '
        'lblContactNotes
        '
        Me.lblContactNotes.Location = New System.Drawing.Point(3, 20)
        Me.lblContactNotes.Name = "lblContactNotes"
        Me.lblContactNotes.Size = New System.Drawing.Size(88, 23)
        Me.lblContactNotes.TabIndex = 34
        Me.lblContactNotes.Text = "Notes:"
        '
        'grpContactAttempts
        '
        Me.grpContactAttempts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContactAttempts.Controls.Add(Me.dgContactAttempts)
        Me.grpContactAttempts.Controls.Add(Me.btnAddAttempt)
        Me.grpContactAttempts.Location = New System.Drawing.Point(8, 2)
        Me.grpContactAttempts.Name = "grpContactAttempts"
        Me.grpContactAttempts.Size = New System.Drawing.Size(773, 596)
        Me.grpContactAttempts.TabIndex = 34
        Me.grpContactAttempts.TabStop = False
        Me.grpContactAttempts.Text = "Attempts"
        '
        'dgContactAttempts
        '
        Me.dgContactAttempts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgContactAttempts.DataMember = ""
        Me.dgContactAttempts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgContactAttempts.Location = New System.Drawing.Point(6, 20)
        Me.dgContactAttempts.Name = "dgContactAttempts"
        Me.dgContactAttempts.Size = New System.Drawing.Size(761, 541)
        Me.dgContactAttempts.TabIndex = 1
        '
        'btnAddAttempt
        '
        Me.btnAddAttempt.AccessibleDescription = ""
        Me.btnAddAttempt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddAttempt.Location = New System.Drawing.Point(6, 567)
        Me.btnAddAttempt.Name = "btnAddAttempt"
        Me.btnAddAttempt.Size = New System.Drawing.Size(85, 23)
        Me.btnAddAttempt.TabIndex = 2
        Me.btnAddAttempt.Text = "Add"
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnView.Location = New System.Drawing.Point(132, 664)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(99, 23)
        Me.btnView.TabIndex = 24
        Me.btnView.Text = "View..."
        '
        'cmsView
        '
        Me.cmsView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertyToolStripMenuItem, Me.CustomerToolStripMenuItem, Me.AuditTrailToolStripMenuItem, Me.OrdersToolStripMenuItem, Me.InvoiceToolStripMenuItem, Me.QuoteToolStripMenuItem, Me.CostingsToolStripMenuItem, Me.HistoryToolStripMenuItem})
        Me.cmsView.Name = "cmsView"
        Me.cmsView.Size = New System.Drawing.Size(128, 180)
        '
        'PropertyToolStripMenuItem
        '
        Me.PropertyToolStripMenuItem.Name = "PropertyToolStripMenuItem"
        Me.PropertyToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.PropertyToolStripMenuItem.Text = "Property"
        '
        'CustomerToolStripMenuItem
        '
        Me.CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem"
        Me.CustomerToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.CustomerToolStripMenuItem.Text = "Customer"
        '
        'AuditTrailToolStripMenuItem
        '
        Me.AuditTrailToolStripMenuItem.Name = "AuditTrailToolStripMenuItem"
        Me.AuditTrailToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.AuditTrailToolStripMenuItem.Text = "Audit Trail"
        '
        'OrdersToolStripMenuItem
        '
        Me.OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem"
        Me.OrdersToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.OrdersToolStripMenuItem.Text = "Orders"
        '
        'InvoiceToolStripMenuItem
        '
        Me.InvoiceToolStripMenuItem.Name = "InvoiceToolStripMenuItem"
        Me.InvoiceToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.InvoiceToolStripMenuItem.Text = "Invoice"
        '
        'QuoteToolStripMenuItem
        '
        Me.QuoteToolStripMenuItem.Name = "QuoteToolStripMenuItem"
        Me.QuoteToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.QuoteToolStripMenuItem.Text = "Quote"
        '
        'CostingsToolStripMenuItem
        '
        Me.CostingsToolStripMenuItem.Name = "CostingsToolStripMenuItem"
        Me.CostingsToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.CostingsToolStripMenuItem.Text = "Costings"
        '
        'HistoryToolStripMenuItem
        '
        Me.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
        Me.HistoryToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.HistoryToolStripMenuItem.Text = "History"
        '
        'FRMLogCallout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1184, 690)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1200, 724)
        Me.Name = "FRMLogCallout"
        Me.Text = "Job"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.btnView, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.tpAssets.ResumeLayout(False)
        Me.grpAssets.ResumeLayout(False)
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbquote.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvQuote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpNotes.ResumeLayout(False)
        Me.gpbNotesDetails.ResumeLayout(False)
        Me.gpbNotesDetails.PerformLayout()
        Me.gpbNotes.ResumeLayout(False)
        CType(Me.dgNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpContactAttempts.ResumeLayout(False)
        Me.grpContactAttemptDetails.ResumeLayout(False)
        Me.grpContactAttemptDetails.PerformLayout()
        Me.grpContactAttempts.ResumeLayout(False)
        CType(Me.dgContactAttempts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsView.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe

        LoadForm(sender, e, Me)
        If IsRFT Then
            TabControl1.Controls.Remove(Me.tbquote)
        End If

        ID = Helper.MakeIntegerValid(GetParameter(0))
        CType(LoadedControl, UCLogCallout).OnForm = Me
        CType(LoadedControl, UCLogCallout).JobId = ID
        If GetParameter(1).GetType Is GetType(Entity.Jobs.Job) Then
            CType(LoadedControl, UCLogCallout).SiteId = CType(GetParameter(1), Entity.Jobs.Job).PropertyID
        Else
            CType(LoadedControl, UCLogCallout).SiteId = Helper.MakeIntegerValid(GetParameter(1))
        End If
        CType(LoadedControl, UCLogCallout).Populate()

        For Each LogCallout As TabPage In CType(LoadedControl, UCLogCallout).tcJobOfWorks.TabPages
            For Each CalloutBreakdown As TabPage In CType(LogCallout.Controls(0), UCCalloutBreakdown).tcEngineerVisits.TabPages
                CType(CalloutBreakdown.Controls(0), UCVisitBreakdown).SetupDG()
            Next
        Next

        If CType(LoadedControl, UCLogCallout).Job.QuoteID = 0 Then
            Me.QuoteToolStripMenuItem.Visible = False
        End If

        Combo.SetUpCombo(cboLabour, DB.CustomerScheduleOfRate.CustomerScheduleOfRates_GetALL_Labour(CType(LoadedControl, UCLogCallout).Site.CustomerID).Table, "Price", "Description", Entity.Sys.Enums.ComboValues.Not_Applicable)
        Combo.SetSelectedComboItem_By_Description(cboLabour, "Normal Labour")
        Combo.SetUpCombo(Me.cboVATRate, DB.VATRatesSQL.VATRates_GetAll_InputOrOutput("O").Table, "VATRateID", "Friendly", Entity.Sys.Enums.ComboValues.Not_Applicable)
        Combo.SetSelectedComboItem_By_Value(cboVATRate, 6)

        SetupAssetDataGrid()
        SetupNotesDataGrid()
        SetupContactAttemptDataGrid()
        SetupQuoteDGV()

        PopulateContactAttempts()

        Try
            If GetParameterCount > 4 AndAlso Helper.MakeIntegerValid(GetParameter(4)) <> 0 Then
                Dim dvEngineerVisit As DataView = DB.EngineerVisits.EngineerVisits_Get(GetParameter(4))
                Dim jobOfWorkNum As Integer = dvEngineerVisit.Table.Rows(0)("JOWNo")
                Dim engineerVisitNum As Integer = dvEngineerVisit.Table.Rows(0)("VisitNo")

                CType(LoadedControl, UCLogCallout).tcJobOfWorks.SelectedIndex = (jobOfWorkNum - 1)
                CType(CType(LoadedControl, UCLogCallout).tcJobOfWorks.SelectedTab.Controls(0), UCCalloutBreakdown).tcEngineerVisits.SelectedIndex = (engineerVisitNum - 1)
            End If
        Catch

        End Try

        If ID > 0 Then
            If JobLock Is Nothing Then JobLock = DB.JobLock.JobLock(ID)
            If JobLock?.UserID <> loggedInUser.UserID Then
                Dim message As String = "The job is currently being viewed by: " & JobLock.NameOfUserWhoLocked
                MessageBox.Show(message, "READ ONLY - JOB LOCKED!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MakeReadOnly()
                Me.Text += " Job Locked by: " & JobLock.NameOfUserWhoLocked
            End If
        End If

    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Me.tpMain.Controls(0)
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        ID = newID
        If GetParameter(2).Name.ToLower = GetType(UCSite).Name.ToLower Then
            CType(GetParameter(2), UCSite).PopulateJobs()
            MainForm.RefreshEntity(Entity.Sys.Helper.MakeIntegerValid(GetParameter(1)))
        End If
        If GetParameter(2).Name.ToLower = GetType(UCAsset).Name.ToLower Then
            CType(GetParameter(2), UCAsset).PopulateJobs()
            MainForm.RefreshEntity(Entity.Sys.Helper.MakeIntegerValid(GetParameter(1)))
        End If
        If GetParameter(2).Name.ToLower = GetType(UCQuoteJob).Name.ToLower Then
            'CType(LoadedControl, UCLogCallout).CurrentJob = DB.Job.Job_Get(ID)
        End If
    End Sub

#End Region

#Region "Properties"

    Private DocumentsControl As UCDocumentsList

    ' Private CostingsControl As UCJobCostings
    Private TheLoadedControl As IUserControl

    Private _Data As DataView

    Public Property Data() As DataView
        Get
            Return _Data
        End Get
        Set(ByVal value As DataView)
            _Data = value
            _Data.AllowNew = False
            _Data.AllowEdit = False
            _Data.AllowDelete = True
            dgvQuote.AutoGenerateColumns = False

            Me.dgvQuote.DataSource = Data
        End Set
    End Property

    Private _ID As Integer = 0

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
            If ID = 0 Then
                PageState = Entity.Sys.Enums.FormState.Insert
                Me.Text = "Job : Adding New..."
                Me.btnSave.Enabled = True
                AuditTrailToolStripMenuItem.Visible = False
                Me.OrdersToolStripMenuItem.Visible = False
                Me.InvoiceToolStripMenuItem.Visible = False
                Me.gpbNotes.Enabled = False
                Me.gpbNotesDetails.Enabled = False
                Me.btnSaveNote.Enabled = False
                Me.btnAddNote.Enabled = False
                Me.btnDeleteNote.Enabled = False
                Me.CostingsToolStripMenuItem.Visible = False
                Me.btnAddAttempt.Enabled = False
            Else
                PageState = Entity.Sys.Enums.FormState.Update
                Me.Text = "Job : ID " & ID
                AuditTrailToolStripMenuItem.Visible = True
                Me.OrdersToolStripMenuItem.Visible = True
                Me.InvoiceToolStripMenuItem.Visible = True

                Me.tpDocuments.Controls.Clear()
                DocumentsControl = New UCDocumentsList(Entity.Sys.Enums.TableNames.tblJob, ID)
                Me.tpDocuments.Controls.Add(DocumentsControl)

                PopulateJobNotes()

                Me.gpbNotes.Enabled = True
                Me.gpbNotesDetails.Enabled = True
                Me.btnSaveNote.Enabled = True
                Me.btnAddNote.Enabled = True
                Me.btnDeleteNote.Enabled = True
            End If

        End Set
    End Property

    Private _pageState As Entity.Sys.Enums.FormState

    Private Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _pageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _pageState = Value
        End Set
    End Property

    Private _AssetsTable As DataView = Nothing

    Public Property AssetsDataView() As DataView
        Get
            Return _AssetsTable
        End Get
        Set(ByVal Value As DataView)
            _AssetsTable = Value
            _AssetsTable.Table.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString
            _AssetsTable.AllowNew = False
            _AssetsTable.AllowEdit = False
            _AssetsTable.AllowDelete = False
            Me.dgAssets.DataSource = AssetsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedAssetDataRow() As DataRow
        Get
            If Not Me.dgAssets.CurrentRowIndex = -1 Then
                Return AssetsDataView(Me.dgAssets.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _JobLock As Entity.JobLock.JobLock

    Public Property JobLock() As Entity.JobLock.JobLock
        Get
            Return _JobLock
        End Get
        Set(ByVal value As Entity.JobLock.JobLock)
            _JobLock = value
        End Set
    End Property

#End Region

    Private _JI As Entity.JobInstalls.JobInstall

    Private Property JI() As Entity.JobInstalls.JobInstall
        Get
            Return _JI
        End Get
        Set(ByVal value As Entity.JobInstalls.JobInstall)
            _JI = value
        End Set
    End Property

    Public Property LastViewedEngineerVisitID As Integer

#Region "Setup"

    Public Sub SetupQuoteDGV()
        Data = New DataView
        Dim dt As New DataTable
        dt.TableName = "QuoteTable"
        Data.Table = dt
        Data.Table.Columns.Add("PartName")
        Data.Table.Columns.Add("PartNumber")
        Data.Table.Columns.Add("PartCost")
        Data.Table.Columns.Add("PartQty")

        Dim ID As New DataGridViewTextBoxColumn
        ID.HeaderText = "CustomerScheduleOfRateID"
        ID.DataPropertyName = "CustomerScheduleOfRateID"
        ID.Name = "CustomerScheduleOfRateID"
        ID.ReadOnly = True
        ID.Visible = False
        ID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvQuote.Columns.Add(ID)

        Dim PartName As New DataGridViewTextBoxColumn
        PartName.HeaderText = "Part Name"
        PartName.FillWeight = 15
        PartName.DataPropertyName = "PartName"
        PartName.Name = "PartName"
        PartName.Visible = True
        PartName.MinimumWidth = 400
        PartName.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvQuote.Columns.Add(PartName)

        Dim PartNo As New DataGridViewTextBoxColumn
        PartNo.HeaderText = "Part Number"
        PartNo.FillWeight = 15
        PartNo.DataPropertyName = "PartNumber"
        PartNo.Name = "PartNumber"
        PartNo.Visible = True
        PartNo.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvQuote.Columns.Add(PartNo)

        Dim PartRate As New DataGridViewTextBoxColumn
        PartRate.HeaderText = "Part U.Cost"
        PartRate.FillWeight = 15
        PartRate.DataPropertyName = "PartCost"
        PartRate.Name = "PartCost"
        PartRate.Visible = True
        PartRate.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvQuote.Columns.Add(PartRate)

        Dim PartQty As New DataGridViewTextBoxColumn
        PartQty.HeaderText = "Part Qty"
        PartQty.FillWeight = 15
        PartQty.DataPropertyName = "PartQty"
        PartQty.Name = "PartQty"
        PartQty.Visible = True
        PartQty.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvQuote.Columns.Add(PartQty)

    End Sub

    Public Sub SetupAssetDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgAssets)
        Dim tStyle As DataGridTableStyle = Me.dgAssets.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgAssets.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Active As New BitToStringDescriptionColumn
        Active.Format = ""
        Active.FormatInfo = Nothing
        Active.HeaderText = "Active"
        Active.MappingName = "Active"
        Active.ReadOnly = True
        Active.Width = 50
        Active.NullText = ""
        tStyle.GridColumnStyles.Add(Active)

        Dim TenantsAppliance As New BitToStringDescriptionColumn
        TenantsAppliance.Format = ""
        TenantsAppliance.FormatInfo = Nothing
        TenantsAppliance.HeaderText = "Tenants Appliance"
        TenantsAppliance.MappingName = "TenantsAppliance"
        TenantsAppliance.ReadOnly = True
        TenantsAppliance.Width = 50
        TenantsAppliance.NullText = ""
        tStyle.GridColumnStyles.Add(TenantsAppliance)

        Dim Product As New DataGridLabelColumn
        Product.Format = ""
        Product.FormatInfo = Nothing
        Product.HeaderText = "Product"
        Product.MappingName = "Product"
        Product.ReadOnly = True
        Product.Width = 250
        Product.NullText = ""
        tStyle.GridColumnStyles.Add(Product)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 75
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim SerialNum As New DataGridLabelColumn
        SerialNum.Format = ""
        SerialNum.FormatInfo = Nothing
        SerialNum.HeaderText = "Serial"
        SerialNum.MappingName = "SerialNum"
        SerialNum.ReadOnly = True
        SerialNum.Width = 75
        SerialNum.NullText = ""
        tStyle.GridColumnStyles.Add(SerialNum)

        Dim GaswayRef As New DataGridLabelColumn
        GaswayRef.Format = ""
        GaswayRef.FormatInfo = Nothing
        GaswayRef.HeaderText = "Gasway Ref"
        GaswayRef.MappingName = "BoughtFrom"
        GaswayRef.ReadOnly = True
        GaswayRef.Width = 75
        GaswayRef.NullText = ""
        tStyle.GridColumnStyles.Add(GaswayRef)

        Dim GCNum As New DataGridLabelColumn
        GCNum.Format = ""
        GCNum.FormatInfo = Nothing
        GCNum.HeaderText = "GC Number"
        GCNum.MappingName = "GCNumber"
        GCNum.ReadOnly = True
        GCNum.Width = 75
        GCNum.NullText = ""
        tStyle.GridColumnStyles.Add(GCNum)

        Dim YearOfManufacture As New DataGridLabelColumn
        YearOfManufacture.Format = ""
        YearOfManufacture.FormatInfo = Nothing
        YearOfManufacture.HeaderText = "Year Of Manufacture"
        YearOfManufacture.MappingName = "YearOfManufacture"
        YearOfManufacture.ReadOnly = True
        YearOfManufacture.Width = 75
        YearOfManufacture.NullText = ""
        tStyle.GridColumnStyles.Add(YearOfManufacture)

        Dim ApproxValue As New DataGridLabelColumn
        ApproxValue.Format = "C"
        ApproxValue.FormatInfo = Nothing
        ApproxValue.HeaderText = "Approx.Value"
        ApproxValue.MappingName = "ApproximateValue"
        ApproxValue.ReadOnly = True
        ApproxValue.Width = 75
        ApproxValue.NullText = ""
        tStyle.GridColumnStyles.Add(ApproxValue)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblAsset.ToString
        Me.dgAssets.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgAssets)

    End Sub

#End Region

#Region "Events"

    Private Sub FRMLogCallout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Public Sub MakeReadOnly()
        btnSave.Enabled = False
        tpAssets.Enabled = False
        tbquote.Enabled = False
        tpDocuments.Enabled = False
        CType(LoadedControl, UCLogCallout).gbPaymentType.Enabled = False
        CType(LoadedControl, UCLogCallout).btnFindUser.Enabled = False
        CType(LoadedControl, UCLogCallout).cboJobType.Enabled = False
        CType(LoadedControl, UCLogCallout).btnChange.Enabled = False
        CType(LoadedControl, UCLogCallout).btnfindVan.Enabled = False
        CType(LoadedControl, UCLogCallout).btnAddJobOfWork.Enabled = False
        CType(LoadedControl, UCLogCallout).btnRemoveJobOfWork.Enabled = False

        For Each tp As TabPage In CType(LoadedControl, UCLogCallout)?.tcJobOfWorks?.TabPages
            CType(tp.Controls(0), UCCalloutBreakdown).txtPONumber.Enabled = False
            CType(tp.Controls(0), UCCalloutBreakdown).cboPriority.Enabled = False
            CType(tp.Controls(0), UCCalloutBreakdown).cboQualification.Enabled = False
            CType(tp.Controls(0), UCCalloutBreakdown).btnAddEngineerVisit.Enabled = False
            CType(tp.Controls(0), UCCalloutBreakdown).btnRemoveEngineerVisit.Enabled = False
            CType(tp.Controls(0), UCCalloutBreakdown).txtJobItemSummary.Enabled = False
            CType(tp.Controls(0), UCCalloutBreakdown).btnRemoveItem.Enabled = False
            CType(tp.Controls(0), UCCalloutBreakdown).btnSaveItem.Enabled = False
            CType(tp.Controls(0), UCCalloutBreakdown).btnAddRate.Enabled = False

            For Each tp1 As TabPage In CType(tp.Controls(0), UCCalloutBreakdown)?.tcEngineerVisits?.TabPages
                CType(tp1.Controls(0), UCVisitBreakdown).tpParts.Enabled = False
                CType(tp1.Controls(0), UCVisitBreakdown).EstVisitDate.Enabled = False
                CType(tp1.Controls(0), UCVisitBreakdown).chkRecharge.Enabled = False
                CType(tp1.Controls(0), UCVisitBreakdown).cbxPartsToFit.Enabled = False
                CType(tp1.Controls(0), UCVisitBreakdown).txtNotesToEngineer.Enabled = False
            Next
        Next
    End Sub

    Private Sub dgAssets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgAssets.Click
        Try
            If SelectedAssetDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not CBool(Me.dgAssets(Me.dgAssets.CurrentRowIndex, 0))
            Me.dgAssets(Me.dgAssets.CurrentRowIndex, 0) = selected
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddAppliance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAppliance.Click
        ShowForm(GetType(FRMAsset), True, New Object() {0, 0, CType(LoadedControl, UCLogCallout).Site.SiteID})
        AssetsDataView = DB.Asset.Asset_GetForSite(CType(LoadedControl, UCLogCallout).Job.PropertyID)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If LoadedControl.Save() Then
            'NO NEED TO DO ANYTHING AS THIS WILL ACTION THE SAME THING TWICE
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        CloseForm()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        cmsView.Show(btnView, New Point(0, 0))
    End Sub

#End Region

#Region "Functions"

    Public Sub CloseForm()
        If CType(TheLoadedControl, UCLogCallout).Job.JobID = 0 Then
            DB.Job.DeleteReservedOrderNumber(CType(TheLoadedControl, UCLogCallout).JobNumber.JobNumber, CType(TheLoadedControl, UCLogCallout).JobNumber.Prefix)
        End If

        If Not JobLock Is Nothing Then
            If JobLock.UserID = loggedInUser.UserID Then
                DB.JobLock.Delete(JobLock.JobLockID)
            End If
        End If

        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

#Region "Job Notes"

#Region "Notes Properties "

    Private _jobNotes As DataView = Nothing

    Public Property JobNotesDataView() As DataView
        Get
            Return _jobNotes
        End Get
        Set(ByVal Value As DataView)
            _jobNotes = Value
            _jobNotes.Table.TableName = Entity.Sys.Enums.TableNames.tblJobNotes.ToString
            _jobNotes.AllowNew = False
            _jobNotes.AllowEdit = False
            _jobNotes.AllowDelete = False
            Me.dgNotes.DataSource = _jobNotes
        End Set
    End Property

    Private ReadOnly Property SelectedJobNoteDataRow() As DataRow
        Get
            If Not Me.dgNotes.CurrentRowIndex = -1 Then
                Return JobNotesDataView(Me.dgNotes.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region " Notes Setup"

    Public Sub SetupNotesDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgNotes)
        Dim tStyle As DataGridTableStyle = Me.dgNotes.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        Me.dgNotes.ReadOnly = True

        Dim Note As New DataGridLabelColumn
        Note.Format = ""
        Note.FormatInfo = Nothing
        Note.HeaderText = "Note"
        Note.MappingName = "Note"
        Note.ReadOnly = True
        Note.Width = 250
        Note.NullText = ""
        tStyle.GridColumnStyles.Add(Note)

        Dim CreatedBy As New DataGridLabelColumn
        CreatedBy.Format = ""
        CreatedBy.FormatInfo = Nothing
        CreatedBy.HeaderText = "Created By"
        CreatedBy.MappingName = "CreatedBy"
        CreatedBy.ReadOnly = True
        CreatedBy.Width = 125
        CreatedBy.NullText = ""
        tStyle.GridColumnStyles.Add(CreatedBy)

        Dim DateCreated As New DataGridLabelColumn
        DateCreated.Format = "dd/MMM/yyyy HH:mm:ss"
        DateCreated.FormatInfo = Nothing
        DateCreated.HeaderText = "Created"
        DateCreated.MappingName = "DateCreated"
        DateCreated.ReadOnly = True
        DateCreated.Width = 135
        DateCreated.NullText = ""
        tStyle.GridColumnStyles.Add(DateCreated)

        Dim EditedBy As New DataGridLabelColumn
        EditedBy.Format = ""
        EditedBy.FormatInfo = Nothing
        EditedBy.HeaderText = "Edited By"
        EditedBy.MappingName = "EditedBy"
        EditedBy.ReadOnly = True
        EditedBy.Width = 125
        EditedBy.NullText = ""
        tStyle.GridColumnStyles.Add(EditedBy)

        Dim LastEdited As New DataGridLabelColumn
        LastEdited.Format = "dd/MMM/yyyy HH:mm:ss"
        LastEdited.FormatInfo = Nothing
        LastEdited.HeaderText = "Last Edited"
        LastEdited.MappingName = "LastEdited"
        LastEdited.ReadOnly = True
        LastEdited.Width = 135
        LastEdited.NullText = ""
        tStyle.GridColumnStyles.Add(LastEdited)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblJobNotes.ToString
        Me.dgNotes.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgNotes)

    End Sub

#End Region

#Region " Notes Events"

    Private Sub dgNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgNotes.Click, dgNotes.CurrentCellChanged
        If SelectedJobNoteDataRow Is Nothing Then
            Exit Sub
        Else
            PopulateJobNoteFields()
            Me.txtNotes.ReadOnly = True
            Me.btnSaveNote.Enabled = False
        End If
    End Sub

    Private Sub btnAddNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNote.Click
        ClearNotesFields()
    End Sub

    Private Sub btnDeleteNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteNote.Click
        Dim msg As String = "Are you sure you want to delete this note?" & vbCrLf
        msg += "You will not be able to undo the delete if you proceed."

        Dim r As DataRow
        r = SelectedJobNoteDataRow
        If Not r Is Nothing Then
            If MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                DB.Job.DeleteJobNote(CInt(r("JobNoteID")))
                JobNotesDataView.Table.Rows.Remove(SelectedJobNoteDataRow)
                ClearNotesFields()
            End If
        End If
    End Sub

    Private Sub btnSaveNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNote.Click
        If Me.txtNotes.Text.Trim.Length > 0 Then
            JobNotesDataView = DB.Job.SaveJobNotes(Entity.Sys.Helper.MakeIntegerValid(txtNoteID.Text), txtNotes.Text.Trim, loggedInUser.UserID, ID, loggedInUser.UserID)
        End If
        ClearNotesFields()
    End Sub

#End Region

#Region " Notes Functions"

    Private Sub ClearNotesFields()
        txtNoteID.Text = ""
        txtNotes.Text = ""
        ActiveControl = txtNotes
        Me.txtNotes.ReadOnly = False
        txtNotes.Focus()
        Me.btnSaveNote.Enabled = True
        tpNotes.Text = "Notes (" & JobNotesDataView.Table.Rows.Count & ")"
    End Sub

    Private Sub PopulateJobNoteFields()
        Dim r As DataRow
        r = SelectedJobNoteDataRow
        If Not r Is Nothing Then
            txtNoteID.Text = CStr(r("JobNoteID"))
            txtNotes.Text = CStr(r("Note"))
        End If

        ActiveControl = txtNotes
        txtNotes.Focus()
    End Sub

    Private Sub PopulateJobNotes()
        JobNotesDataView = DB.Job.GetJobNotes(ID)
        tpNotes.Text = "Notes (" & JobNotesDataView.Table.Rows.Count & ")"
    End Sub

#End Region

#End Region

    Public quotecreated As Boolean = False
    Public quoteresult As String = ""

    Private Sub btncalc_Click(sender As Object, e As EventArgs) Handles btncalc.Click
        Try
            Dim labourRate As Double =
                Entity.Sys.Helper.MakeDoubleValid(Combo.GetSelectedItemValue(cboLabour))
            If labourRate <= 0 Then Throw New Exception("No Labour Rate selected!")
            Dim labour As Double =
                Entity.Sys.Helper.MakeDoubleValid(txtLabourQty.Text)
            If labour <= 0 Then Throw New Exception("Labour Value incorrect!")
            Dim labourCost As Double = Math.Round(labour * labourRate, 2)

            Dim claimLimit As Decimal =
                Entity.Sys.Helper.MakeDoubleValid(txtClaimLimit.Text)

            If rdoAXA.Checked And claimLimit < 0 Then Throw New Exception("Invalid claim limit!")

            Dim partResult As String = ""
            Dim LabourResult As String = ""
            Dim result As String = ""

            Dim partMup As Double = 0.0
            Dim partTotal As Double = 0.0
            Dim axaCallout As Double = 59.08
            Dim axaAdmin As Double = 30

            Dim rCount As Integer = 0

            Dim markup2 As Decimal = 1 + Helper.MakeDoubleValid(DB.CustomerCharge.CustomerCharge_GetForCustomer(CType(LoadedControl, UCLogCallout).Site.CustomerID)?.PartsMarkup / 100)

            result = "Quote for Works:" & vbCrLf

            For Each dr As DataRow In Data.Table.Rows
                If rbStandard.Checked And dr("PartQty") > 0 Then
                    rCount += 1
                    partMup = Markup(Math.Round(Decimal.Parse(dr("PartCost")), 2, MidpointRounding.AwayFromZero))
                    partResult += "Materials " & rCount & ": Code: " & dr("PartNumber") &
                            " / Name: " & dr("PartName") & " / Cost: £" & partMup & " X " & dr("PartQty") &
                            " = £" & Math.Round((partMup * dr("PartQty")), 2, MidpointRounding.AwayFromZero) & vbCrLf
                    partTotal += Math.Round((partMup * dr("PartQty")), 2, MidpointRounding.AwayFromZero)
                ElseIf dr("PartQty") > 0 Then
                    rCount += 1
                    partMup = dr("Partcost") * markup2
                    partResult += "Materials " & rCount & ": Code: " & dr("PartNumber") &
                            " / Name: " & dr("PartName") & " / Cost: £" & partMup & " X " & dr("PartQty") &
                            " = £" & Math.Round((partMup * dr("PartQty")), 2, MidpointRounding.AwayFromZero) & vbCrLf
                    partTotal += Math.Round((partMup * dr("PartQty")), 2, MidpointRounding.AwayFromZero)
                End If
            Next

            LabourResult += "Labour @ £" & labourRate & " X " & labour & " = £" & labourCost & vbCrLf

            Dim subtotal As Decimal = 0.0
            If rdoPOC.Checked Then
                subtotal = Math.Round((partTotal + (labourCost)), 2, MidpointRounding.AwayFromZero)
            Else
                subtotal = Math.Round((partTotal + axaCallout + labourCost), 2, MidpointRounding.AwayFromZero)
            End If

            Dim vat As Decimal = 0
            If Combo.GetSelectedItemValue(cboVATRate) > 0 Then
                vat = Math.Round(((subtotal * (1 + (DB.VATRatesSQL.VATRates_Get(Combo.GetSelectedItemValue(cboVATRate)).VATRate / 100))) - subtotal), 2, MidpointRounding.AwayFromZero)
            End If

            Dim total As Decimal = subtotal + vat
            result += partResult
            If rdoAXA.Checked Then
                result += "Callout @ £" & axaCallout & vbCrLf
            End If
            result += LabourResult
            result += "Sub Total = £" & subtotal
            If Combo.GetSelectedItemValue(cboVATRate) > 0 And Not chkExcludeVat.Checked Then
                If rdoPOC.Checked Then
                    result += " + VAT (£" & (total) & " inc VAT) "
                Else
                    result += " + VAT (£" & (total) & " inc VAT) "
                    result += " Plus AXA admin fee: £" & axaAdmin
                    total += axaAdmin
                    result += " Grand total: £" & total & vbCrLf
                    result += "Total Price for work: £" & total & " minus claim limit £" & claimLimit
                    Dim grandtotal As Double = total - claimLimit
                    If grandtotal <= 0 Then
                        result += " = Underlimit - Please proceed"
                    Else
                        result += " = Total payable of £" & grandtotal & " inc VAT"
                    End If
                End If
            Else
                result += " Ex VAT"
            End If

            Me.quotecreated = True
            Me.quoteresult = result
            tbresult.Text = result
            btnaddtonotes.Enabled = True
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function Markup(ByVal cost As Decimal) As Decimal

        Dim thiscost As Decimal

        If cost <= 20 Then
            thiscost = cost * 2
        ElseIf cost > 20 And cost <= 50 Then
            thiscost = cost * 1.8
        ElseIf cost > 50 And cost <= 100 Then
            thiscost = cost * 1.7
        ElseIf cost > 100 And cost <= 200 Then
            thiscost = cost * 1.6
        ElseIf cost > 200 And cost <= 300 Then
            thiscost = cost * 1.5
        ElseIf cost > 300 And cost <= 400 Then
            thiscost = cost * 1.45
        Else
            thiscost = cost * 1.4
        End If
        Return Math.Round(thiscost, 2, MidpointRounding.AwayFromZero)

    End Function

    Private Function numbertest(number As String) As Double

        Dim Result As Decimal
        Dim outcome As Double

        If Decimal.TryParse(number, Result) Then
            outcome = CDbl(number)
        Else
            outcome = 0
        End If

        Return outcome

    End Function

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        MessageBox.Show("Please manually email this quote to the client. Button not in operation", "Gasway Services: Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnaddtonotes_Click(sender As Object, e As EventArgs) Handles btnaddtonotes.Click
        If Me.quoteresult.Length > 1 = True Then
            JobNotesDataView = DB.Job.SaveJobNotes(0, Me.quoteresult, loggedInUser.UserID, ID, loggedInUser.UserID)
            PopulateJobNotes()
            btnEmail.Enabled = True
        End If
    End Sub

    Private Sub BtnQuoteAdd_Click(sender As Object, e As EventArgs) Handles btnQuoteAdd.Click

        Dim dr As DataRow = Data.Table.NewRow

        If (numbertest(txtPartQty.Text) > 0 AndAlso numbertest(txtPartRate.Text) > 0) Then
            If numbertest(txtPartQty.Text) > 0 Then
                dr("PartQty") = numbertest(txtPartQty.Text)
                dr("PartName") = (txtPartName.Text)
                dr("PartNumber") = (txtPartNumber.Text)
                dr("PartCost") = numbertest(txtPartRate.Text)
            Else

                dr("PartQty") = "0"
                dr("PartName") = "N/A"
                dr("PartNumber") = "N/A"
                dr("PartCost") = "N/A"

            End If

            Data.Table.Rows.Add(dr)

            txtPartQty.Text = 0
            txtPartName.Text = ""
            txtPartNumber.Text = ""
            txtPartRate.Text = ""
        Else
            MsgBox("Nothing to add", MsgBoxStyle.OkOnly, "Error")
        End If
    End Sub

    Private Sub PropertyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropertyToolStripMenuItem.Click
        ShowForm(GetType(FRMSite), True, New Object() {CType(LoadedControl, UCLogCallout).Site.SiteID, Me})
    End Sub

    Private Sub AuditTrailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditTrailToolStripMenuItem.Click
        ShowForm(GetType(FRMJobAudit), True, New Object() {ID})
    End Sub

    Private Sub OrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdersToolStripMenuItem.Click
        If ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Navigation.Navigate(Entity.Sys.Enums.MenuTypes.Spares) Then
                Me.CloseForm()

                ShowForm(GetType(FRMOrderManager), False, New Object() {DB.Order.Orders_GetForJob(ID), Nothing})
            End If
        End If
    End Sub

    Private Sub InvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InvoiceToolStripMenuItem.Click
        If ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Navigation.Navigate(Entity.Sys.Enums.MenuTypes.Invoicing) = True Then
                Me.CloseForm()

                Dim dv As DataView = DB.InvoiceToBeRaised.Invoices_GetAll_For_JobID(ID)

                Dim checked As Boolean = True
                If dv.Table.Rows.Count > 0 Then
                    If DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(dv.Table.Rows(0).Item("InvoiceToBeRaisedID")).Table.Rows.Count > 0 Then
                        checked = False
                    End If
                End If

                ShowForm(GetType(FRMInvoiceManager), False, New Object() {dv, checked})
            End If
        End If
    End Sub

    Private Sub QuoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuoteToolStripMenuItem.Click
        ShowForm(GetType(FRMQuoteJob), True, New Object() {CType(LoadedControl, UCLogCallout).Job.QuoteID, CType(LoadedControl, UCLogCallout).Site.SiteID})
    End Sub

    Private Sub HistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryToolStripMenuItem.Click
        ShowForm(GetType(FRMSiteVisitManager), True, New Object() {CType(LoadedControl, UCLogCallout).Site.SiteID})
    End Sub

    Private Sub CostingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CostingsToolStripMenuItem.Click
        PdfFactory.GenerateJobCostings(CType(LoadedControl, UCLogCallout).Job)
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        tbresult.Text = ""
        Data.Table.Clear()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        ShowForm(GetType(FRMCustomer), True, New Object() {CType(LoadedControl, UCLogCallout).Site.CustomerID})
    End Sub

    Private Sub rdoCust_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAXA.CheckedChanged, rdoPOC.CheckedChanged
        lblClaimLimit.Visible = rdoAXA.Checked
        txtClaimLimit.Visible = rdoAXA.Checked
        chkExcludeVat.Visible = rdoPOC.Checked
        If rdoAXA.Checked Then
            chkExcludeVat.Checked = False
        End If
    End Sub

#Region "Contact Attempts"

    Private _dvcontactAttempts As DataView = Nothing

    Public Property DvContactAttempts() As DataView
        Get
            Return _dvcontactAttempts
        End Get
        Set(ByVal value As DataView)
            _dvcontactAttempts = value
            _dvcontactAttempts.Table.TableName = Enums.TableNames.tblContact.ToString
            _dvcontactAttempts.AllowNew = False
            _dvcontactAttempts.AllowEdit = False
            _dvcontactAttempts.AllowDelete = False
            Me.dgContactAttempts.DataSource = _dvcontactAttempts
        End Set
    End Property

    Private ReadOnly Property DrSelectedContactAttempt() As DataRow
        Get
            If Not Me.dgContactAttempts.CurrentRowIndex = -1 Then
                Return DvContactAttempts(Me.dgContactAttempts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub SetupContactAttemptDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgContactAttempts)
        Dim tStyle As DataGridTableStyle = Me.dgContactAttempts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        Me.dgContactAttempts.ReadOnly = True

        Dim contactMethod As New DataGridLabelColumn
        contactMethod.Format = ""
        contactMethod.FormatInfo = Nothing
        contactMethod.HeaderText = "Method"
        contactMethod.MappingName = "ContactMethod"
        contactMethod.ReadOnly = True
        contactMethod.Width = 250
        contactMethod.NullText = ""
        tStyle.GridColumnStyles.Add(contactMethod)

        Dim contactDate As New DataGridLabelColumn
        contactDate.Format = "dd/MMM/yyyy HH:mm:ss"
        contactDate.FormatInfo = Nothing
        contactDate.HeaderText = "Contact Date"
        contactDate.MappingName = "ContactMade"
        contactDate.ReadOnly = True
        contactDate.Width = 135
        contactDate.NullText = ""
        tStyle.GridColumnStyles.Add(contactDate)

        Dim notes As New DataGridLabelColumn
        notes.Format = ""
        notes.FormatInfo = Nothing
        notes.HeaderText = "Note"
        notes.MappingName = "Note"
        notes.ReadOnly = True
        notes.Width = 250
        notes.NullText = ""
        tStyle.GridColumnStyles.Add(notes)

        Dim contactMadeBy As New DataGridLabelColumn
        contactMadeBy.Format = ""
        contactMadeBy.FormatInfo = Nothing
        contactMadeBy.HeaderText = "By"
        contactMadeBy.MappingName = "ContactMadeBy"
        contactMadeBy.ReadOnly = True
        contactMadeBy.Width = 125
        contactMadeBy.NullText = ""
        tStyle.GridColumnStyles.Add(contactMadeBy)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContact.ToString
        Me.dgContactAttempts.TableStyles.Add(tStyle)

        Helper.RemoveEventHandlers(Me.dgContactAttempts)

    End Sub

    Public Sub PopulateContactAttempts()
        Dim countRows As Integer = 0
        If CType(LoadedControl, UCLogCallout).ContactAttempts?.Count > 0 Then
            DvContactAttempts = New DataView(Helper.ToDataTable(CType(LoadedControl, UCLogCallout).ContactAttempts))
            countRows = DvContactAttempts.Table.Rows.Count
        End If

        tpContactAttempts.Text = "Contact Attempts (" & countRows & ")"
    End Sub

    Private Sub btnAddAttempt_Click(sender As Object, e As EventArgs) Handles btnAddAttempt.Click
        CType(LoadedControl, UCLogCallout).AddContactAttempt()
    End Sub

    Private Sub dgContactAttempts_Click(sender As Object, e As EventArgs) Handles dgContactAttempts.Click
        If DrSelectedContactAttempt Is Nothing Then
            Exit Sub
        Else
            txtContactAttemptDetails.Text = DrSelectedContactAttempt("ContactMethod") & " on " & Helper.MakeDateTimeValid(DrSelectedContactAttempt("ContactMade")).ToString("dddd, dd MMMM yyyy HH:mm")
            txtContactAttemptDetails.Text += vbCrLf & "By " & DrSelectedContactAttempt("ContactMadeBy")
            txtContactAttemptDetails.Text += vbCrLf & vbCrLf & "Note: " & DrSelectedContactAttempt("Notes")
        End If
    End Sub

#End Region

End Class