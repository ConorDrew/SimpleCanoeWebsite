Public Class FRMJobCostings : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal oJob As Entity.Jobs.Job)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        CurrentJob = oJob
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
    Friend WithEvents btnPrintJobCosting As System.Windows.Forms.Button
    Friend WithEvents tpJobCostings As System.Windows.Forms.TabPage
    Friend WithEvents tpInstall As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDeposit As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCalledSuper As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSurveyed As System.Windows.Forms.ComboBox
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtProfitActPerc As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtProfitEstPerc As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtProfitActMoney As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtProfitEstMoney As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotalEst As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalAct As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtEstLabour As System.Windows.Forms.TextBox
    Friend WithEvents txtActLabour As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPartEst As System.Windows.Forms.TextBox
    Friend WithEvents txtPartAct As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboPaperwork As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboQC As System.Windows.Forms.ComboBox
    Friend WithEvents txtPayment As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboFurtherWorks As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboExtraLabour As System.Windows.Forms.ComboBox
    Friend WithEvents txtQuoted As System.Windows.Forms.TextBox
    Friend WithEvents lblQuoted As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtEstElec As System.Windows.Forms.TextBox
    Friend WithEvents txtActElec As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtQuotedGross As System.Windows.Forms.TextBox
    Friend WithEvents txtDepositGross As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierInv As System.Windows.Forms.TextBox
    Friend WithEvents txtManual As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtEstSub As System.Windows.Forms.TextBox
    Friend WithEvents txtActSub As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents grpTotalCostings As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtProfitPerc As System.Windows.Forms.TextBox
    Friend WithEvents TxtProfitPounds As System.Windows.Forms.TextBox
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtSales As System.Windows.Forms.TextBox
    Friend WithEvents txtCosts As System.Windows.Forms.TextBox
    Friend WithEvents grpPartCostings As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents txtPartCost As System.Windows.Forms.TextBox
    Friend WithEvents txtLabourCost As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtSorTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtSORSales As System.Windows.Forms.TextBox
    Friend WithEvents dgTimesheetCharges As System.Windows.Forms.DataGrid
    Friend WithEvents dgPartsProductCharging As System.Windows.Forms.DataGrid
    Friend WithEvents dgScheduleOfRateCharges As System.Windows.Forms.DataGrid
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtPartPerc As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtLabourPerc As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpJobCostings = New System.Windows.Forms.TabPage()
        Me.grpTotalCostings = New System.Windows.Forms.GroupBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtSorTotal = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtProfitPerc = New System.Windows.Forms.TextBox()
        Me.TxtProfitPounds = New System.Windows.Forms.TextBox()
        Me.lbl5 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtSales = New System.Windows.Forms.TextBox()
        Me.txtCosts = New System.Windows.Forms.TextBox()
        Me.grpPartCostings = New System.Windows.Forms.GroupBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtPartPerc = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtLabourPerc = New System.Windows.Forms.TextBox()
        Me.dgScheduleOfRateCharges = New System.Windows.Forms.DataGrid()
        Me.dgPartsProductCharging = New System.Windows.Forms.DataGrid()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtSORSales = New System.Windows.Forms.TextBox()
        Me.dgTimesheetCharges = New System.Windows.Forms.DataGrid()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.txtPartCost = New System.Windows.Forms.TextBox()
        Me.txtLabourCost = New System.Windows.Forms.TextBox()
        Me.tpInstall = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtManual = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtEstSub = New System.Windows.Forms.TextBox()
        Me.txtActSub = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtSupplierInv = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtEstElec = New System.Windows.Forms.TextBox()
        Me.txtActElec = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtQuotedGross = New System.Windows.Forms.TextBox()
        Me.txtDepositGross = New System.Windows.Forms.TextBox()
        Me.txtQuoted = New System.Windows.Forms.TextBox()
        Me.lblQuoted = New System.Windows.Forms.Label()
        Me.txtProfitActPerc = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtProfitEstPerc = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtProfitActMoney = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtProfitEstMoney = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalEst = New System.Windows.Forms.TextBox()
        Me.txtTotalAct = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEstLabour = New System.Windows.Forms.TextBox()
        Me.txtActLabour = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPartEst = New System.Windows.Forms.TextBox()
        Me.txtPartAct = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboPaperwork = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboQC = New System.Windows.Forms.ComboBox()
        Me.txtPayment = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboFurtherWorks = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboExtraLabour = New System.Windows.Forms.ComboBox()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCalledSuper = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSurveyed = New System.Windows.Forms.ComboBox()
        Me.txtDeposit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPrintJobCosting = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tpJobCostings.SuspendLayout()
        Me.grpTotalCostings.SuspendLayout()
        Me.grpPartCostings.SuspendLayout()
        CType(Me.dgScheduleOfRateCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPartsProductCharging, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTimesheetCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpInstall.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.TabControl1.Controls.Add(Me.tpJobCostings)
        Me.TabControl1.Controls.Add(Me.tpInstall)
        Me.TabControl1.Location = New System.Drawing.Point(0, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(942, 627)
        Me.TabControl1.TabIndex = 23
        '
        'tpJobCostings
        '
        Me.tpJobCostings.Controls.Add(Me.grpTotalCostings)
        Me.tpJobCostings.Controls.Add(Me.grpPartCostings)
        Me.tpJobCostings.Location = New System.Drawing.Point(4, 22)
        Me.tpJobCostings.Name = "tpJobCostings"
        Me.tpJobCostings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpJobCostings.Size = New System.Drawing.Size(934, 601)
        Me.tpJobCostings.TabIndex = 5
        Me.tpJobCostings.Text = "Job Costings"
        Me.tpJobCostings.UseVisualStyleBackColor = True
        '
        'grpTotalCostings
        '
        Me.grpTotalCostings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTotalCostings.Controls.Add(Me.Label41)
        Me.grpTotalCostings.Controls.Add(Me.txtSorTotal)
        Me.grpTotalCostings.Controls.Add(Me.Label32)
        Me.grpTotalCostings.Controls.Add(Me.Label33)
        Me.grpTotalCostings.Controls.Add(Me.txtProfitPerc)
        Me.grpTotalCostings.Controls.Add(Me.TxtProfitPounds)
        Me.grpTotalCostings.Controls.Add(Me.lbl5)
        Me.grpTotalCostings.Controls.Add(Me.Label34)
        Me.grpTotalCostings.Controls.Add(Me.txtSales)
        Me.grpTotalCostings.Controls.Add(Me.txtCosts)
        Me.grpTotalCostings.Location = New System.Drawing.Point(4, 477)
        Me.grpTotalCostings.Name = "grpTotalCostings"
        Me.grpTotalCostings.Size = New System.Drawing.Size(928, 80)
        Me.grpTotalCostings.TabIndex = 7
        Me.grpTotalCostings.TabStop = False
        '
        'Label41
        '
        Me.Label41.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(510, 11)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(67, 13)
        Me.Label41.TabIndex = 13
        Me.Label41.Text = "SOR Sales"
        '
        'txtSorTotal
        '
        Me.txtSorTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSorTotal.Location = New System.Drawing.Point(500, 30)
        Me.txtSorTotal.Name = "txtSorTotal"
        Me.txtSorTotal.Size = New System.Drawing.Size(100, 21)
        Me.txtSorTotal.TabIndex = 14
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(748, 47)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(53, 13)
        Me.Label32.TabIndex = 11
        Me.Label32.Text = "Profit %"
        '
        'Label33
        '
        Me.Label33.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(748, 20)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(48, 13)
        Me.Label33.TabIndex = 9
        Me.Label33.Text = "Profit £"
        '
        'txtProfitPerc
        '
        Me.txtProfitPerc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfitPerc.Location = New System.Drawing.Point(806, 41)
        Me.txtProfitPerc.Name = "txtProfitPerc"
        Me.txtProfitPerc.Size = New System.Drawing.Size(100, 21)
        Me.txtProfitPerc.TabIndex = 12
        '
        'TxtProfitPounds
        '
        Me.TxtProfitPounds.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtProfitPounds.Location = New System.Drawing.Point(806, 14)
        Me.TxtProfitPounds.Name = "TxtProfitPounds"
        Me.TxtProfitPounds.Size = New System.Drawing.Size(100, 21)
        Me.TxtProfitPounds.TabIndex = 10
        '
        'lbl5
        '
        Me.lbl5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl5.AutoSize = True
        Me.lbl5.Location = New System.Drawing.Point(632, 11)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(74, 13)
        Me.lbl5.TabIndex = 7
        Me.lbl5.Text = "Other Sales"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(36, 11)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(39, 13)
        Me.Label34.TabIndex = 3
        Me.Label34.Text = "Costs"
        '
        'txtSales
        '
        Me.txtSales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSales.Location = New System.Drawing.Point(622, 30)
        Me.txtSales.Name = "txtSales"
        Me.txtSales.Size = New System.Drawing.Size(100, 21)
        Me.txtSales.TabIndex = 8
        '
        'txtCosts
        '
        Me.txtCosts.Location = New System.Drawing.Point(9, 30)
        Me.txtCosts.Name = "txtCosts"
        Me.txtCosts.Size = New System.Drawing.Size(100, 21)
        Me.txtCosts.TabIndex = 6
        '
        'grpPartCostings
        '
        Me.grpPartCostings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPartCostings.BackColor = System.Drawing.Color.White
        Me.grpPartCostings.Controls.Add(Me.Label43)
        Me.grpPartCostings.Controls.Add(Me.txtPartPerc)
        Me.grpPartCostings.Controls.Add(Me.Label42)
        Me.grpPartCostings.Controls.Add(Me.txtLabourPerc)
        Me.grpPartCostings.Controls.Add(Me.dgScheduleOfRateCharges)
        Me.grpPartCostings.Controls.Add(Me.dgPartsProductCharging)
        Me.grpPartCostings.Controls.Add(Me.Label40)
        Me.grpPartCostings.Controls.Add(Me.TextBox2)
        Me.grpPartCostings.Controls.Add(Me.Label39)
        Me.grpPartCostings.Controls.Add(Me.txtSORSales)
        Me.grpPartCostings.Controls.Add(Me.dgTimesheetCharges)
        Me.grpPartCostings.Controls.Add(Me.Label35)
        Me.grpPartCostings.Controls.Add(Me.Label36)
        Me.grpPartCostings.Controls.Add(Me.Label37)
        Me.grpPartCostings.Controls.Add(Me.Label38)
        Me.grpPartCostings.Controls.Add(Me.lbl1)
        Me.grpPartCostings.Controls.Add(Me.txtPartCost)
        Me.grpPartCostings.Controls.Add(Me.txtLabourCost)
        Me.grpPartCostings.Location = New System.Drawing.Point(4, 3)
        Me.grpPartCostings.Name = "grpPartCostings"
        Me.grpPartCostings.Size = New System.Drawing.Size(928, 468)
        Me.grpPartCostings.TabIndex = 6
        Me.grpPartCostings.TabStop = False
        Me.grpPartCostings.Text = "Job Profit/Loss"
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(824, 408)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(46, 13)
        Me.Label43.TabIndex = 24
        Me.Label43.Text = "Part %"
        '
        'txtPartPerc
        '
        Me.txtPartPerc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartPerc.Location = New System.Drawing.Point(806, 427)
        Me.txtPartPerc.Name = "txtPartPerc"
        Me.txtPartPerc.Size = New System.Drawing.Size(100, 21)
        Me.txtPartPerc.TabIndex = 23
        '
        'Label42
        '
        Me.Label42.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(817, 255)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(62, 13)
        Me.Label42.TabIndex = 22
        Me.Label42.Text = "Labour %"
        '
        'txtLabourPerc
        '
        Me.txtLabourPerc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLabourPerc.Location = New System.Drawing.Point(806, 276)
        Me.txtLabourPerc.Name = "txtLabourPerc"
        Me.txtLabourPerc.Size = New System.Drawing.Size(100, 21)
        Me.txtLabourPerc.TabIndex = 21
        '
        'dgScheduleOfRateCharges
        '
        Me.dgScheduleOfRateCharges.DataMember = ""
        Me.dgScheduleOfRateCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgScheduleOfRateCharges.Location = New System.Drawing.Point(9, 35)
        Me.dgScheduleOfRateCharges.Name = "dgScheduleOfRateCharges"
        Me.dgScheduleOfRateCharges.Size = New System.Drawing.Size(779, 118)
        Me.dgScheduleOfRateCharges.TabIndex = 20
        '
        'dgPartsProductCharging
        '
        Me.dgPartsProductCharging.DataMember = ""
        Me.dgPartsProductCharging.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPartsProductCharging.Location = New System.Drawing.Point(9, 348)
        Me.dgPartsProductCharging.Name = "dgPartsProductCharging"
        Me.dgPartsProductCharging.Size = New System.Drawing.Size(779, 100)
        Me.dgPartsProductCharging.TabIndex = 19
        '
        'Label40
        '
        Me.Label40.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(817, 33)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(53, 13)
        Me.Label40.TabIndex = 18
        Me.Label40.Text = "SOR Est"
        Me.Label40.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Location = New System.Drawing.Point(806, 54)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 21)
        Me.TextBox2.TabIndex = 17
        Me.TextBox2.Visible = False
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(817, 111)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(67, 13)
        Me.Label39.TabIndex = 16
        Me.Label39.Text = "SOR Sales"
        '
        'txtSORSales
        '
        Me.txtSORSales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSORSales.Location = New System.Drawing.Point(806, 132)
        Me.txtSORSales.Name = "txtSORSales"
        Me.txtSORSales.Size = New System.Drawing.Size(100, 21)
        Me.txtSORSales.TabIndex = 15
        '
        'dgTimesheetCharges
        '
        Me.dgTimesheetCharges.DataMember = ""
        Me.dgTimesheetCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTimesheetCharges.Location = New System.Drawing.Point(9, 205)
        Me.dgTimesheetCharges.Name = "dgTimesheetCharges"
        Me.dgTimesheetCharges.Size = New System.Drawing.Size(779, 92)
        Me.dgTimesheetCharges.TabIndex = 14
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(6, 19)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(87, 13)
        Me.Label35.TabIndex = 13
        Me.Label35.Text = "SOR's Applied"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(6, 332)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(72, 13)
        Me.Label36.TabIndex = 11
        Me.Label36.Text = "Parts Costs"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 189)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(82, 13)
        Me.Label37.TabIndex = 9
        Me.Label37.Text = "Labour Costs"
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(824, 353)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(66, 13)
        Me.Label38.TabIndex = 2
        Me.Label38.Text = "Part Costs"
        '
        'lbl1
        '
        Me.lbl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(817, 205)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(82, 13)
        Me.lbl1.TabIndex = 1
        Me.lbl1.Text = "Labour Costs"
        '
        'txtPartCost
        '
        Me.txtPartCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartCost.Location = New System.Drawing.Point(806, 372)
        Me.txtPartCost.Name = "txtPartCost"
        Me.txtPartCost.Size = New System.Drawing.Size(100, 21)
        Me.txtPartCost.TabIndex = 1
        '
        'txtLabourCost
        '
        Me.txtLabourCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLabourCost.Location = New System.Drawing.Point(806, 226)
        Me.txtLabourCost.Name = "txtLabourCost"
        Me.txtLabourCost.Size = New System.Drawing.Size(100, 21)
        Me.txtLabourCost.TabIndex = 0
        '
        'tpInstall
        '
        Me.tpInstall.Controls.Add(Me.GroupBox1)
        Me.tpInstall.Location = New System.Drawing.Point(4, 22)
        Me.tpInstall.Name = "tpInstall"
        Me.tpInstall.Size = New System.Drawing.Size(934, 601)
        Me.tpInstall.TabIndex = 6
        Me.tpInstall.Text = "Installation Data"
        Me.tpInstall.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtManual)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.txtEstSub)
        Me.GroupBox1.Controls.Add(Me.txtActSub)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txtSupplierInv)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtEstElec)
        Me.GroupBox1.Controls.Add(Me.txtActElec)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtQuotedGross)
        Me.GroupBox1.Controls.Add(Me.txtDepositGross)
        Me.GroupBox1.Controls.Add(Me.txtQuoted)
        Me.GroupBox1.Controls.Add(Me.lblQuoted)
        Me.GroupBox1.Controls.Add(Me.txtProfitActPerc)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtProfitEstPerc)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtProfitActMoney)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtProfitEstMoney)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtTotalEst)
        Me.GroupBox1.Controls.Add(Me.txtTotalAct)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtEstLabour)
        Me.GroupBox1.Controls.Add(Me.txtActLabour)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtPartEst)
        Me.GroupBox1.Controls.Add(Me.txtPartAct)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cboPaperwork)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cboQC)
        Me.GroupBox1.Controls.Add(Me.txtPayment)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboFurtherWorks)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboExtraLabour)
        Me.GroupBox1.Controls.Add(Me.txtPO)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboCalledSuper)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboSurveyed)
        Me.GroupBox1.Controls.Add(Me.txtDeposit)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(926, 599)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Details"
        '
        'txtManual
        '
        Me.txtManual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtManual.Location = New System.Drawing.Point(668, 353)
        Me.txtManual.Name = "txtManual"
        Me.txtManual.Size = New System.Drawing.Size(214, 21)
        Me.txtManual.TabIndex = 112
        Me.txtManual.TabStop = False
        Me.txtManual.Text = "0"
        Me.txtManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.Location = New System.Drawing.Point(500, 356)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(147, 23)
        Me.Label31.TabIndex = 111
        Me.Label31.Text = "Manual Adjustment"
        '
        'txtEstSub
        '
        Me.txtEstSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEstSub.Location = New System.Drawing.Point(668, 276)
        Me.txtEstSub.Name = "txtEstSub"
        Me.txtEstSub.Size = New System.Drawing.Size(214, 21)
        Me.txtEstSub.TabIndex = 110
        Me.txtEstSub.TabStop = False
        Me.txtEstSub.Text = "0"
        Me.txtEstSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtActSub
        '
        Me.txtActSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtActSub.Location = New System.Drawing.Point(668, 306)
        Me.txtActSub.Name = "txtActSub"
        Me.txtActSub.ReadOnly = True
        Me.txtActSub.Size = New System.Drawing.Size(214, 21)
        Me.txtActSub.TabIndex = 109
        Me.txtActSub.TabStop = False
        Me.txtActSub.Text = "0"
        Me.txtActSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.Location = New System.Drawing.Point(500, 279)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(147, 23)
        Me.Label29.TabIndex = 108
        Me.Label29.Text = "Est SubContractor Cost"
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.Location = New System.Drawing.Point(500, 309)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(147, 23)
        Me.Label30.TabIndex = 107
        Me.Label30.Text = "Act SubContractor Cost"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(683, 65)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(86, 19)
        Me.Label28.TabIndex = 106
        Me.Label28.Text = "PO Value"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(796, 62)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(86, 19)
        Me.Label27.TabIndex = 105
        Me.Label27.Text = "Supplier Inv"
        '
        'txtSupplierInv
        '
        Me.txtSupplierInv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplierInv.Location = New System.Drawing.Point(781, 84)
        Me.txtSupplierInv.Name = "txtSupplierInv"
        Me.txtSupplierInv.ReadOnly = True
        Me.txtSupplierInv.Size = New System.Drawing.Size(101, 21)
        Me.txtSupplierInv.TabIndex = 104
        Me.txtSupplierInv.TabStop = False
        Me.txtSupplierInv.Text = "0"
        Me.txtSupplierInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(223, 122)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(61, 18)
        Me.Label26.TabIndex = 103
        Me.Label26.Text = "Nett"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(223, 63)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 14)
        Me.Label25.TabIndex = 102
        Me.Label25.Text = "Nett"
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(323, 62)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 19)
        Me.Label24.TabIndex = 101
        Me.Label24.Text = "Gross"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(323, 122)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(61, 18)
        Me.Label23.TabIndex = 100
        Me.Label23.Text = "Gross"
        '
        'txtEstElec
        '
        Me.txtEstElec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEstElec.Location = New System.Drawing.Point(668, 127)
        Me.txtEstElec.Name = "txtEstElec"
        Me.txtEstElec.Size = New System.Drawing.Size(214, 21)
        Me.txtEstElec.TabIndex = 99
        Me.txtEstElec.TabStop = False
        Me.txtEstElec.Text = "0"
        Me.txtEstElec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtActElec
        '
        Me.txtActElec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtActElec.Location = New System.Drawing.Point(668, 157)
        Me.txtActElec.Name = "txtActElec"
        Me.txtActElec.ReadOnly = True
        Me.txtActElec.Size = New System.Drawing.Size(214, 21)
        Me.txtActElec.TabIndex = 98
        Me.txtActElec.TabStop = False
        Me.txtActElec.Text = "0"
        Me.txtActElec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.Location = New System.Drawing.Point(500, 133)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(116, 23)
        Me.Label21.TabIndex = 97
        Me.Label21.Text = "Est Electrical Cost"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.Location = New System.Drawing.Point(500, 163)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(131, 23)
        Me.Label22.TabIndex = 96
        Me.Label22.Text = "Act Electrical Cost"
        '
        'txtQuotedGross
        '
        Me.txtQuotedGross.Location = New System.Drawing.Point(304, 84)
        Me.txtQuotedGross.Name = "txtQuotedGross"
        Me.txtQuotedGross.Size = New System.Drawing.Size(97, 21)
        Me.txtQuotedGross.TabIndex = 95
        Me.txtQuotedGross.TabStop = False
        Me.txtQuotedGross.Text = "0"
        Me.txtQuotedGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDepositGross
        '
        Me.txtDepositGross.Location = New System.Drawing.Point(304, 141)
        Me.txtDepositGross.Name = "txtDepositGross"
        Me.txtDepositGross.Size = New System.Drawing.Size(97, 21)
        Me.txtDepositGross.TabIndex = 94
        Me.txtDepositGross.TabStop = False
        Me.txtDepositGross.Text = "0"
        Me.txtDepositGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtQuoted
        '
        Me.txtQuoted.Location = New System.Drawing.Point(187, 84)
        Me.txtQuoted.Name = "txtQuoted"
        Me.txtQuoted.Size = New System.Drawing.Size(97, 21)
        Me.txtQuoted.TabIndex = 93
        Me.txtQuoted.TabStop = False
        Me.txtQuoted.Text = "0"
        Me.txtQuoted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblQuoted
        '
        Me.lblQuoted.Location = New System.Drawing.Point(17, 90)
        Me.lblQuoted.Name = "lblQuoted"
        Me.lblQuoted.Size = New System.Drawing.Size(121, 23)
        Me.lblQuoted.TabIndex = 92
        Me.lblQuoted.Text = "Amount Quoted"
        '
        'txtProfitActPerc
        '
        Me.txtProfitActPerc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfitActPerc.Location = New System.Drawing.Point(670, 551)
        Me.txtProfitActPerc.Name = "txtProfitActPerc"
        Me.txtProfitActPerc.ReadOnly = True
        Me.txtProfitActPerc.Size = New System.Drawing.Size(214, 21)
        Me.txtProfitActPerc.TabIndex = 91
        Me.txtProfitActPerc.TabStop = False
        Me.txtProfitActPerc.Text = "0"
        Me.txtProfitActPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.Location = New System.Drawing.Point(500, 554)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 23)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "Act Profit %"
        '
        'txtProfitEstPerc
        '
        Me.txtProfitEstPerc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfitEstPerc.Location = New System.Drawing.Point(670, 524)
        Me.txtProfitEstPerc.Name = "txtProfitEstPerc"
        Me.txtProfitEstPerc.ReadOnly = True
        Me.txtProfitEstPerc.Size = New System.Drawing.Size(214, 21)
        Me.txtProfitEstPerc.TabIndex = 89
        Me.txtProfitEstPerc.TabStop = False
        Me.txtProfitEstPerc.Text = "0"
        Me.txtProfitEstPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.Location = New System.Drawing.Point(500, 527)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(116, 23)
        Me.Label16.TabIndex = 88
        Me.Label16.Text = "Est Profit %"
        '
        'txtProfitActMoney
        '
        Me.txtProfitActMoney.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfitActMoney.Location = New System.Drawing.Point(670, 485)
        Me.txtProfitActMoney.Name = "txtProfitActMoney"
        Me.txtProfitActMoney.ReadOnly = True
        Me.txtProfitActMoney.Size = New System.Drawing.Size(214, 21)
        Me.txtProfitActMoney.TabIndex = 87
        Me.txtProfitActMoney.TabStop = False
        Me.txtProfitActMoney.Text = "0"
        Me.txtProfitActMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.Location = New System.Drawing.Point(500, 488)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(116, 23)
        Me.Label15.TabIndex = 86
        Me.Label15.Text = "Act Profit £"
        '
        'txtProfitEstMoney
        '
        Me.txtProfitEstMoney.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfitEstMoney.Location = New System.Drawing.Point(670, 458)
        Me.txtProfitEstMoney.Name = "txtProfitEstMoney"
        Me.txtProfitEstMoney.ReadOnly = True
        Me.txtProfitEstMoney.Size = New System.Drawing.Size(214, 21)
        Me.txtProfitEstMoney.TabIndex = 85
        Me.txtProfitEstMoney.TabStop = False
        Me.txtProfitEstMoney.Text = "0"
        Me.txtProfitEstMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Location = New System.Drawing.Point(500, 461)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(116, 23)
        Me.Label14.TabIndex = 84
        Me.Label14.Text = "Est Profit £"
        '
        'txtTotalEst
        '
        Me.txtTotalEst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalEst.Location = New System.Drawing.Point(670, 396)
        Me.txtTotalEst.Name = "txtTotalEst"
        Me.txtTotalEst.ReadOnly = True
        Me.txtTotalEst.Size = New System.Drawing.Size(214, 21)
        Me.txtTotalEst.TabIndex = 83
        Me.txtTotalEst.TabStop = False
        Me.txtTotalEst.Text = "0"
        Me.txtTotalEst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalAct
        '
        Me.txtTotalAct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAct.Location = New System.Drawing.Point(670, 426)
        Me.txtTotalAct.Name = "txtTotalAct"
        Me.txtTotalAct.ReadOnly = True
        Me.txtTotalAct.Size = New System.Drawing.Size(214, 21)
        Me.txtTotalAct.TabIndex = 82
        Me.txtTotalAct.TabStop = False
        Me.txtTotalAct.Text = "0"
        Me.txtTotalAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(502, 397)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 23)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "Est Total Cost"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Location = New System.Drawing.Point(502, 427)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 23)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "Act total Cost"
        '
        'txtEstLabour
        '
        Me.txtEstLabour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEstLabour.Location = New System.Drawing.Point(668, 201)
        Me.txtEstLabour.Name = "txtEstLabour"
        Me.txtEstLabour.Size = New System.Drawing.Size(214, 21)
        Me.txtEstLabour.TabIndex = 79
        Me.txtEstLabour.TabStop = False
        Me.txtEstLabour.Text = "0"
        Me.txtEstLabour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtActLabour
        '
        Me.txtActLabour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtActLabour.Location = New System.Drawing.Point(668, 231)
        Me.txtActLabour.Name = "txtActLabour"
        Me.txtActLabour.ReadOnly = True
        Me.txtActLabour.Size = New System.Drawing.Size(214, 21)
        Me.txtActLabour.TabIndex = 78
        Me.txtActLabour.TabStop = False
        Me.txtActLabour.Text = "0"
        Me.txtActLabour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(500, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 23)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Est Labour Cost"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Location = New System.Drawing.Point(500, 234)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(116, 23)
        Me.Label17.TabIndex = 76
        Me.Label17.Text = "Act Labour Cost"
        '
        'txtPartEst
        '
        Me.txtPartEst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartEst.Location = New System.Drawing.Point(670, 37)
        Me.txtPartEst.Name = "txtPartEst"
        Me.txtPartEst.Size = New System.Drawing.Size(214, 21)
        Me.txtPartEst.TabIndex = 75
        Me.txtPartEst.TabStop = False
        Me.txtPartEst.Text = "0"
        Me.txtPartEst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPartAct
        '
        Me.txtPartAct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartAct.Location = New System.Drawing.Point(670, 84)
        Me.txtPartAct.Name = "txtPartAct"
        Me.txtPartAct.ReadOnly = True
        Me.txtPartAct.Size = New System.Drawing.Size(99, 21)
        Me.txtPartAct.TabIndex = 64
        Me.txtPartAct.TabStop = False
        Me.txtPartAct.Text = "0"
        Me.txtPartAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.Location = New System.Drawing.Point(500, 40)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 23)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "Est Part Cost"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.Location = New System.Drawing.Point(498, 87)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 23)
        Me.Label20.TabIndex = 57
        Me.Label20.Text = "Act Part Cost"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 342)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 23)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Paperwork Returned"
        '
        'cboPaperwork
        '
        Me.cboPaperwork.FormattingEnabled = True
        Me.cboPaperwork.Location = New System.Drawing.Point(187, 336)
        Me.cboPaperwork.Name = "cboPaperwork"
        Me.cboPaperwork.Size = New System.Drawing.Size(214, 21)
        Me.cboPaperwork.TabIndex = 55
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 307)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 23)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "QC Carried Out"
        '
        'cboQC
        '
        Me.cboQC.FormattingEnabled = True
        Me.cboQC.Location = New System.Drawing.Point(187, 304)
        Me.cboQC.Name = "cboQC"
        Me.cboQC.Size = New System.Drawing.Size(214, 21)
        Me.cboQC.TabIndex = 53
        '
        'txtPayment
        '
        Me.txtPayment.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtPayment.Location = New System.Drawing.Point(187, 276)
        Me.txtPayment.Name = "txtPayment"
        Me.txtPayment.ReadOnly = True
        Me.txtPayment.Size = New System.Drawing.Size(214, 21)
        Me.txtPayment.TabIndex = 51
        Me.txtPayment.TabStop = False
        Me.txtPayment.Text = "0"
        Me.txtPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 282)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 23)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Payment Taken"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 255)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 23)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Further Works Noted"
        '
        'cboFurtherWorks
        '
        Me.cboFurtherWorks.FormattingEnabled = True
        Me.cboFurtherWorks.Location = New System.Drawing.Point(187, 249)
        Me.cboFurtherWorks.Name = "cboFurtherWorks"
        Me.cboFurtherWorks.Size = New System.Drawing.Size(214, 21)
        Me.cboFurtherWorks.TabIndex = 47
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 228)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 23)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Extra Labour Noted"
        '
        'cboExtraLabour
        '
        Me.cboExtraLabour.FormattingEnabled = True
        Me.cboExtraLabour.Location = New System.Drawing.Point(187, 222)
        Me.cboExtraLabour.Name = "cboExtraLabour"
        Me.cboExtraLabour.Size = New System.Drawing.Size(214, 21)
        Me.cboExtraLabour.TabIndex = 45
        '
        'txtPO
        '
        Me.txtPO.Location = New System.Drawing.Point(187, 168)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.ReadOnly = True
        Me.txtPO.Size = New System.Drawing.Size(214, 21)
        Me.txtPO.TabIndex = 44
        Me.txtPO.TabStop = False
        Me.txtPO.Text = "0"
        Me.txtPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 23)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "PO Status"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 23)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Eng Called Supervisor"
        '
        'cboCalledSuper
        '
        Me.cboCalledSuper.FormattingEnabled = True
        Me.cboCalledSuper.Location = New System.Drawing.Point(187, 195)
        Me.cboCalledSuper.Name = "cboCalledSuper"
        Me.cboCalledSuper.Size = New System.Drawing.Size(214, 21)
        Me.cboCalledSuper.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 23)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Surveyed by"
        '
        'cboSurveyed
        '
        Me.cboSurveyed.FormattingEnabled = True
        Me.cboSurveyed.Location = New System.Drawing.Point(187, 32)
        Me.cboSurveyed.Name = "cboSurveyed"
        Me.cboSurveyed.Size = New System.Drawing.Size(214, 21)
        Me.cboSurveyed.TabIndex = 37
        '
        'txtDeposit
        '
        Me.txtDeposit.Location = New System.Drawing.Point(187, 141)
        Me.txtDeposit.Name = "txtDeposit"
        Me.txtDeposit.Size = New System.Drawing.Size(97, 21)
        Me.txtDeposit.TabIndex = 36
        Me.txtDeposit.TabStop = False
        Me.txtDeposit.Text = "0"
        Me.txtDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Deposit Taken"
        '
        'btnPrintJobCosting
        '
        Me.btnPrintJobCosting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintJobCosting.Location = New System.Drawing.Point(822, 664)
        Me.btnPrintJobCosting.Name = "btnPrintJobCosting"
        Me.btnPrintJobCosting.Size = New System.Drawing.Size(114, 23)
        Me.btnPrintJobCosting.TabIndex = 25
        Me.btnPrintJobCosting.Text = "Print Job Costing"
        Me.btnPrintJobCosting.UseVisualStyleBackColor = True
        '
        'FRMJobCostings
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(942, 690)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnPrintJobCosting)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(950, 724)
        Me.Name = "FRMJobCostings"
        Me.Text = "Job"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.btnPrintJobCosting, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.tpJobCostings.ResumeLayout(False)
        Me.grpTotalCostings.ResumeLayout(False)
        Me.grpTotalCostings.PerformLayout()
        Me.grpPartCostings.ResumeLayout(False)
        Me.grpPartCostings.PerformLayout()
        CType(Me.dgScheduleOfRateCharges, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPartsProductCharging, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTimesheetCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpInstall.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CurrentJob.JobTypeID <> 521 Then
            Me.TabControl1.TabPages.Remove(tpInstall)
        End If

        Combo.SetUpCombo(cboSurveyed, DynamicDataTables.Surveyor, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboCalledSuper, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboExtraLabour, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboFurtherWorks, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboQC, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboPaperwork, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        SetupJobInstall()
        CalculatePL()
    End Sub

#End Region

#Region "Properties"

    Dim vatRateID As Integer
    Dim vatRate As New Entity.VATRatess.VATRates

    Private _TimeSheetCharges As DataView

    Private Property TimeSheetCharges() As DataView
        Get
            Return _TimeSheetCharges
        End Get
        Set(ByVal value As DataView)
            _TimeSheetCharges = value
            _TimeSheetCharges.AllowNew = False
            _TimeSheetCharges.AllowEdit = True
            _TimeSheetCharges.AllowDelete = False
            _TimeSheetCharges.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString
            Me.dgTimesheetCharges.DataSource = TimeSheetCharges
        End Set
    End Property

    Private _ScheduleOfRateCharges As DataView

    Private Property ScheduleOfRateCharges() As DataView
        Get
            Return _ScheduleOfRateCharges
        End Get
        Set(ByVal value As DataView)
            _ScheduleOfRateCharges = value
            _ScheduleOfRateCharges.AllowNew = False
            _ScheduleOfRateCharges.AllowEdit = True
            _ScheduleOfRateCharges.AllowDelete = False
            _ScheduleOfRateCharges.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString
            Me.dgScheduleOfRateCharges.DataSource = ScheduleOfRateCharges
        End Set
    End Property

    Private _PartProductsCharges As DataView

    Private Property PartProductsCharges() As DataView
        Get
            Return _PartProductsCharges
        End Get
        Set(ByVal value As DataView)
            _PartProductsCharges = value
            _PartProductsCharges.AllowNew = False
            _PartProductsCharges.AllowEdit = False
            _PartProductsCharges.AllowDelete = False
            _PartProductsCharges.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitPartProductCharges.ToString
            Me.dgPartsProductCharging.DataSource = PartProductsCharges
        End Set
    End Property

    Private _CurrentJob As Entity.Jobs.Job = Nothing

    Public Property CurrentJob() As Entity.Jobs.Job
        Get
            Return _CurrentJob
        End Get
        Set(ByVal Value As Entity.Jobs.Job)
            _CurrentJob = Value

            If _CurrentJob Is Nothing Then
                _CurrentJob = New Entity.Jobs.Job
                _CurrentJob.Exists = False
            End If
        End Set
    End Property

    Private _JI As Entity.JobInstalls.JobInstall

    Private Property JI() As Entity.JobInstalls.JobInstall
        Get
            Return _JI
        End Get
        Set(ByVal value As Entity.JobInstalls.JobInstall)
            _JI = value
        End Set
    End Property

#End Region

#Region "Setup"

    Public Sub SetupTimeSheetChargeDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgTimesheetCharges)
        Dim tStyle As DataGridTableStyle = Me.dgTimesheetCharges.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False
        dgTimesheetCharges.ReadOnly = False

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MM/yy HH:mm"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Start "
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 95
        StartDateTime.NullText = ""
        tStyle.GridColumnStyles.Add(StartDateTime)

        Dim EndDateTime As New DataGridLabelColumn
        EndDateTime.Format = "dd/MM/yy HH:mm"
        EndDateTime.FormatInfo = Nothing
        EndDateTime.HeaderText = "End"
        EndDateTime.MappingName = "EndDateTime"
        EndDateTime.ReadOnly = True
        EndDateTime.Width = 95
        EndDateTime.NullText = ""
        tStyle.GridColumnStyles.Add(EndDateTime)

        Dim EngineerCost As New DataGridLabelColumn
        EngineerCost.Format = "C"
        EngineerCost.FormatInfo = Nothing
        EngineerCost.HeaderText = "Eng. Cost"
        EngineerCost.MappingName = "EngineerCost"
        EngineerCost.ReadOnly = True
        EngineerCost.Width = 80
        EngineerCost.NullText = ""
        tStyle.GridColumnStyles.Add(EngineerCost)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 60
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim Summary As New DataGridLabelColumn
        Summary.Format = ""
        Summary.FormatInfo = Nothing
        Summary.HeaderText = "Summary"
        Summary.MappingName = "Summary"
        Summary.ReadOnly = True
        Summary.Width = 500
        Summary.NullText = ""
        tStyle.GridColumnStyles.Add(Summary)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString
        Me.dgTimesheetCharges.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupSoRChargeDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgScheduleOfRateCharges)
        Dim tStyle As DataGridTableStyle = Me.dgScheduleOfRateCharges.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False
        dgScheduleOfRateCharges.ReadOnly = False

        Dim Code As New DataGridLabelColumn
        Code.Format = ""
        Code.FormatInfo = Nothing
        Code.HeaderText = "Code"
        Code.MappingName = "Code"
        Code.ReadOnly = True
        Code.Width = 65
        Code.NullText = ""
        tStyle.GridColumnStyles.Add(Code)

        Dim category As New DataGridLabelColumn
        category.Format = ""
        category.FormatInfo = Nothing
        category.HeaderText = "Category"
        category.MappingName = "category"
        category.ReadOnly = True
        category.Width = 75
        category.NullText = ""
        tStyle.GridColumnStyles.Add(category)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Summary"
        Description.ReadOnly = True
        Description.Width = 85
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim NumUnitsUsed As New DataGridLabelColumn
        NumUnitsUsed.Format = ""
        NumUnitsUsed.FormatInfo = Nothing
        NumUnitsUsed.HeaderText = "# Used"
        NumUnitsUsed.MappingName = "NumUnitsUsed"
        NumUnitsUsed.ReadOnly = True
        NumUnitsUsed.Width = 52
        NumUnitsUsed.NullText = "0"
        tStyle.GridColumnStyles.Add(NumUnitsUsed)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 60
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim Charge As New DataGridLabelColumn
        Charge.Format = "C"
        Charge.FormatInfo = Nothing
        Charge.HeaderText = "Charge"
        Charge.MappingName = "Total"
        Charge.ReadOnly = True
        Charge.Width = 65
        Charge.NullText = "£0.00"
        tStyle.GridColumnStyles.Add(Charge)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString
        Me.dgScheduleOfRateCharges.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupPartProductDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgPartsProductCharging)
        Dim tStyle As DataGridTableStyle = Me.dgPartsProductCharging.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False
        dgScheduleOfRateCharges.ReadOnly = False

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 40
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        Dim PartProduct As New DataGridLabelColumn
        PartProduct.Format = ""
        PartProduct.FormatInfo = Nothing
        PartProduct.HeaderText = "Part/Product"
        PartProduct.MappingName = "Part/Product"
        PartProduct.ReadOnly = True
        PartProduct.Width = 75
        PartProduct.NullText = ""
        tStyle.GridColumnStyles.Add(PartProduct)

        Dim Asset As New DataGridLabelColumn
        Asset.Format = ""
        Asset.FormatInfo = Nothing
        Asset.HeaderText = "Appliance (part applied to)"
        Asset.MappingName = "Asset"
        Asset.ReadOnly = True
        Asset.Width = 60
        Asset.NullText = ""
        tStyle.GridColumnStyles.Add(Asset)

        Dim Warranty As New DataGridLabelColumn
        Warranty.Format = ""
        Warranty.FormatInfo = Nothing
        Warranty.HeaderText = "Warranty? (Appliance on)"
        Warranty.MappingName = "Warranty"
        Warranty.ReadOnly = True
        Warranty.Width = 55
        Warranty.NullText = ""
        tStyle.GridColumnStyles.Add(Warranty)

        Dim Quantity As New DataGridLabelColumn
        Quantity.Format = ""
        Quantity.FormatInfo = Nothing
        Quantity.HeaderText = "Qty"
        Quantity.MappingName = "Quantity"
        Quantity.ReadOnly = True
        Quantity.Width = 40
        Quantity.NullText = ""
        tStyle.GridColumnStyles.Add(Quantity)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 45
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim Charge As New DataGridLabelColumn
        Charge.Format = "C"
        Charge.FormatInfo = Nothing
        Charge.HeaderText = "Charge"
        Charge.MappingName = "Total"
        Charge.ReadOnly = True
        Charge.Width = 65
        Charge.NullText = "£0.00"
        tStyle.GridColumnStyles.Add(Charge)

        Dim Cost As New DataGridLabelColumn
        Cost.Format = "C"
        Cost.FormatInfo = Nothing
        Cost.HeaderText = "Cost"
        Cost.MappingName = "Cost"
        Cost.ReadOnly = True
        Cost.Width = 45
        Cost.NullText = ""
        tStyle.GridColumnStyles.Add(Cost)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisitPartProductCharges.ToString
        Me.dgPartsProductCharging.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub btnPrintJobCosting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintJobCosting.Click
        Dim details As New ArrayList
        details.Add(CurrentJob.JobID)
        Dim oPrint As New Entity.Sys.Printing(details, "Costing" & CurrentJob.JobNumber & " ", Entity.Sys.Enums.SystemDocumentType.JobCosting)
    End Sub

    Private Sub FRMLogCallout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)

        SetupTimeSheetChargeDataGrid()
        SetupSoRChargeDataGrid()
        SetupPartProductDataGrid()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If CurrentJob.JobTypeID = 521 Then
            SaveJI()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub SaveJI()
        Try
            JI.SetSurveyed = Combo.GetSelectedItemValue(cboSurveyed)
            JI.SetDeposit = cfn(txtDeposit.Text)
            JI.SetQuotedAmount = cfn(txtQuoted.Text)
            JI.SetEngCalledSuper = Combo.GetSelectedItemValue(cboCalledSuper)
            JI.SetExtraLabour = Combo.GetSelectedItemValue(cboExtraLabour)
            JI.SetFurtherWorks = Combo.GetSelectedItemValue(cboFurtherWorks)
            JI.SetPaymentTaken = cfn(txtPayment.Text)

            JI.SetEstElecCost = cfn(txtEstElec.Text)

            JI.SetQC = Combo.GetSelectedItemValue(cboQC)
            JI.SetPaperWork = Combo.GetSelectedItemValue(cboPaperwork)

            JI.SetEstPartCost = cfn(txtPartEst.Text)
            JI.SetEstLabourCost = cfn(txtEstLabour.Text)
            JI.SetEstTotalCost = cfn(txtTotalEst.Text)
            JI.SetJobID = CurrentJob.JobID

            JI.SetEstProfitMoney = cfn(txtProfitEstMoney.Text)
            JI.SetManual = cfn(txtManual.Text)

            JI.SetSubConEst = cfn(txtEstSub.Text)

            If JI.Exists Then
                DB.JobInstallSQL.Update(JI)
            Else
                DB.JobInstallSQL.Insert(JI)
            End If
        Catch ex As Exception
            ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End Try
    End Sub

#End Region

#Region " Job Install"

    Private Sub SetupJobInstall()

        If CurrentJob.JobTypeID = 521 Then

            vatRateID = DB.VATRatesSQL.VATRates_Get_ByDate(CurrentJob.DateCreated)
            vatRate = DB.VATRatesSQL.VATRates_Get(vatRateID)

            JI = New Entity.JobInstalls.JobInstall
            JI = DB.JobInstallSQL.JobINstall_GetFor_JobID(CurrentJob.JobID)
            If JI Is Nothing Then
                JI = New Entity.JobInstalls.JobInstall
            End If

            Combo.SetSelectedComboItem_By_Value(cboSurveyed, JI.Surveyed)
            txtDeposit.Text = "£" & JI.Deposit

            Me.txtDepositGross.Text = Format(CDec(txtDeposit.Text) * (1 + (vatRate.VATRate / 100)), "C")

            txtPO.Text = JI.POStatus
            Combo.SetSelectedComboItem_By_Value(cboCalledSuper, JI.EngCalledSuper)
            Combo.SetSelectedComboItem_By_Value(cboExtraLabour, JI.ExtraLabour)

            Combo.SetSelectedComboItem_By_Value(cboFurtherWorks, JI.FurtherWorks)
            txtPayment.Text = "£" & JI.PaymentTaken
            Combo.SetSelectedComboItem_By_Value(cboQC, JI.QC)

            Combo.SetSelectedComboItem_By_Value(cboPaperwork, JI.PaperWork)

            txtPartEst.Text = "£" & JI.EstPartCost
            txtPartAct.Text = "£" & JI.actPartCost

            txtEstLabour.Text = "£" & JI.EstLabourCost
            txtActLabour.Text = "£" & JI.actLabourCost

            txtEstElec.Text = "£" & JI.EstElecCost
            txtActElec.Text = "£" & JI.actElecCost

            txtTotalEst.Text = "£" & JI.EstTotalCost
            txtTotalAct.Text = "£" & JI.actTotalCost

            txtProfitEstMoney.Text = "£" & (CDbl(JI.QuotedAmount) - CDbl(JI.EstTotalCost))
            txtProfitActMoney.Text = "£" & JI.ActProfitMoney

            txtProfitEstPerc.Text = JI.EstProfitPerc & "%"
            txtProfitActPerc.Text = JI.ActProfitPerc & "%"

            txtEstElec.Text = "£" & JI.EstElecCost
            txtActElec.Text = "£" & JI.actElecCost

            txtEstSub.Text = "£" & JI.SubConEst

            If JI.SubConSI <> 0 Then
                txtActSub.Text = "£" & JI.SubConSI
            Else
                txtActSub.Text = "£" & JI.SubConPO
            End If

            txtManual.Text = "£" & JI.Manual
            txtQuoted.Text = "£" & JI.QuotedAmount
            Me.txtQuotedGross.Text = Format(CDec(txtQuoted.Text) * (1 + (vatRate.VATRate / 100)), "C")

            txtSupplierInv.Text = "£" & JI.SupplierInvoice
        End If
        CalcTotals()

    End Sub

#End Region

#Region "Calulations"

    Private Sub txtEstLabour_TextChanged(sender As Object, e As EventArgs) Handles txtEstLabour.TextChanged
        CalcTotals()
    End Sub

    Private Sub txtEstElectrical_TextChanged(sender As Object, e As EventArgs) Handles txtEstElec.TextChanged
        CalcTotals()
    End Sub

    Private Sub txtPartEst_TextChanged(sender As Object, e As EventArgs) Handles txtPartEst.TextChanged
        CalcTotals()
    End Sub

    Private Sub txtEstSub_TextChanged(sender As Object, e As EventArgs) Handles txtEstSub.TextChanged
        CalcTotals()
    End Sub

    Private Sub CalcTotals()
        txtTotalEst.Text = "£" & CDbl(cfn(txtPartEst.Text)) + CDbl(cfn(txtEstLabour.Text) + CDbl(cfn(txtEstElec.Text)) + CDbl(cfn(txtEstSub.Text)))
        txtProfitEstMoney.Text = "£" & CDbl(cfn(txtQuoted.Text)) - CDbl(cfn(txtTotalEst.Text))
        txtProfitEstPerc.Text = (Math.Round(CDbl(txtProfitEstMoney.Text) / CDbl(CDbl(cfn(txtQuoted.Text))), 4) * 100) & "%"
    End Sub

    Private Sub txtPayment_TextChanged(sender As Object, e As EventArgs) Handles txtPayment.TextChanged
        txtProfitActMoney.Text = "£" & CDbl(cfn(txtPayment.Text) - cfn(txtTotalAct.Text))
        txtProfitActPerc.Text = (Math.Round(CDbl(cfn(txtProfitActMoney.Text)) / CDbl(CDbl(cfn(txtPayment.Text))), 4) * 100) & "%"
    End Sub

    Private Sub txtManual_TextChanged(sender As Object, e As EventArgs) Handles txtManual.KeyUp
        Try
            If JI.SIExists Then
                txtTotalAct.Text = CDbl(cfn(txtSupplierInv.Text) + cfn(txtActLabour.Text) + cfn(txtActElec.Text) + cfn(txtActSub.Text)) + CDbl(cfn(txtManual.Text))
            Else
                txtTotalAct.Text = CDbl(cfn(txtPartAct.Text) + cfn(txtActLabour.Text) + cfn(txtActElec.Text) + cfn(txtActSub.Text)) + CDbl(cfn(txtManual.Text))
            End If

            txtProfitActMoney.Text = "£" & CDbl(cfn(txtPayment.Text) - cfn(txtTotalAct.Text))
            txtProfitActPerc.Text = (Math.Round(CDbl(cfn(txtProfitActMoney.Text)) / CDbl(CDbl(cfn(txtPayment.Text))), 4) * 100) & "%"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtQuoted.KeyUp
        Me.txtQuotedGross.Text = Format(CDec(cfn(txtQuoted.Text)) * (1 + (vatRate.VATRate / 100)), "C")
        txtProfitEstMoney.Text = "£" & CDbl(cfn(txtQuoted.Text)) - CDbl(cfn(txtTotalEst.Text))
        txtProfitEstPerc.Text = (Math.Round(CDbl(cfn(txtProfitEstMoney.Text)) / CDbl(CDbl(cfn(txtQuoted.Text))), 4) * 100) & "%"
    End Sub

    Private Sub txtQuotedGross_TextChanged(sender As Object, e As EventArgs) Handles txtQuotedGross.KeyUp
        Me.txtQuoted.Text = Format(CDec(cfn(txtQuotedGross.Text)) / (1 + (vatRate.VATRate / 100)), "C")
        txtProfitEstMoney.Text = "£" & CDbl(cfn(txtQuoted.Text)) - CDbl(cfn(txtTotalEst.Text))
        txtProfitEstPerc.Text = (Math.Round(CDbl(cfn(txtProfitEstMoney.Text)) / CDbl(CDbl(cfn(txtQuoted.Text))), 4) * 100) & "%"
    End Sub

    Private Sub txtDeposit_TextChanged(sender As Object, e As EventArgs) Handles txtDeposit.KeyUp
        Me.txtDepositGross.Text = Format(CDec(cfn(txtDeposit.Text)) * (1 + (vatRate.VATRate / 100)), "C")
        txtProfitEstMoney.Text = "£" & CDbl(cfn(txtQuoted.Text)) - CDbl(cfn(txtTotalEst.Text))
        txtProfitEstPerc.Text = (Math.Round(CDbl(cfn(txtProfitEstMoney.Text)) / CDbl(CDbl(cfn(txtQuoted.Text))), 4) * 100) & "%"
    End Sub

    Private Sub txtDepositGross_TextChanged(sender As Object, e As EventArgs) Handles txtDepositGross.KeyUp
        Me.txtDeposit.Text = Format(CDec(cfn(txtDepositGross.Text)) / (1 + (vatRate.VATRate / 100)), "C")
        txtProfitEstMoney.Text = "£" & CDbl(cfn(txtQuoted.Text)) - CDbl(cfn(txtTotalEst.Text))
        txtProfitEstPerc.Text = (Math.Round(CDbl(cfn(txtProfitEstMoney.Text)) / CDbl(CDbl(cfn(txtQuoted.Text))), 4) * 100) & "%"
    End Sub

    Function cfn(ByVal text As String) As Double
        Dim s As String
        '  s = System.Text.RegularExpressions.Regex.Replace(text, "[+-]?[^0-9.]", "")
        s = System.Text.RegularExpressions.Regex.Replace(text, "[^0-9.]", "")
        If s = "" Then s = 0
        If text.Contains("-") Then
            s = "-" & s
        End If
        Return s
    End Function

    Sub CalculatePL()

        Dim dtTime As New DataTable
        Dim dtParts As New DataTable
        Dim dtSors As New DataTable
        Dim evc As Integer = 0

        For Each jow As Entity.JobOfWorks.JobOfWork In CurrentJob.JobOfWorks
            For Each ev As Entity.EngineerVisits.EngineerVisit In jow.EngineerVisits
                ev.TimeSheets = DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Get(ev.EngineerVisitID)
                If Not DB.EngineerVisitCharge.EngineerVisitCharge_Get(ev.EngineerVisitID) Is Nothing Then
                    evc = DB.EngineerVisitCharge.EngineerVisitCharge_Get(ev.EngineerVisitID).InvoiceReadyID
                End If

                If evc = 2 Then
                    dtSors.Merge(DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(ev.EngineerVisitID).Table)
                End If

                If ev.TimeSheets.Count > 0 Then
                    dtTime.Merge(ev.TimeSheets.Table)
                End If
                dtParts.Merge(DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Get_For_EngineerVisitID(ev.EngineerVisitID).Table)
            Next
        Next

        txtPartCost.Text = Entity.Sys.Helper.MakeDoubleValid(0)
        txtLabourCost.Text = Entity.Sys.Helper.MakeDoubleValid(0)
        txtCosts.Text = Entity.Sys.Helper.MakeDoubleValid(0)
        txtSORSales.Text = Entity.Sys.Helper.MakeDoubleValid(0)
        txtSorTotal.Text = Entity.Sys.Helper.MakeDoubleValid(0)

        TimeSheetCharges = New DataView(dtTime)
        PartProductsCharges = New DataView(dtParts)
        ScheduleOfRateCharges = New DataView(dtSors)

        For Each charge As DataRow In PartProductsCharges.Table.Rows
            txtPartCost.Text += Entity.Sys.Helper.MakeDoubleValid(charge("Cost"))
            txtCosts.Text += Entity.Sys.Helper.MakeDoubleValid(charge("Cost"))
        Next

        For Each charge As DataRow In TimeSheetCharges.Table.Rows
            txtLabourCost.Text += Entity.Sys.Helper.MakeDoubleValid(charge("EngineerCost"))
            txtCosts.Text += Entity.Sys.Helper.MakeDoubleValid(charge("EngineerCost"))
        Next

        For Each charge As DataRow In ScheduleOfRateCharges.Table.Rows
            txtSORSales.Text += Entity.Sys.Helper.MakeDoubleValid(charge("Total"))
            txtSorTotal.Text += Entity.Sys.Helper.MakeDoubleValid(charge("Total"))
        Next

        JI = New Entity.JobInstalls.JobInstall
        JI = DB.JobInstallSQL.JobINstall_GetFor_JobID(CurrentJob.JobID)
        If Not JI Is Nothing Then
            txtSales.Text = Math.Round(JI.PaymentTaken - txtSorTotal.Text, 2)
        End If
        TxtProfitPounds.Text = "£" & Math.Round((CDbl(JI.PaymentTaken) - CDbl(txtCosts.Text)), 2)
        txtProfitPerc.Text = Math.Round((TxtProfitPounds.Text / JI.PaymentTaken) * 100, 2)

        txtLabourPerc.Text = (Math.Round((txtLabourCost.Text / JI.PaymentTaken) * 100, 2))
        txtPartPerc.Text = (Math.Round((txtPartCost.Text / JI.PaymentTaken) * 100, 2))
    End Sub

#End Region

End Class