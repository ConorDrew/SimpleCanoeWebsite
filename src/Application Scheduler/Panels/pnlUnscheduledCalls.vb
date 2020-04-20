Imports FSM.Entity.Sys

Public Class pnlUnscheduledCalls
    Inherits UserControl
    Friend WithEvents splitForm As System.Windows.Forms.Splitter
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkHasPartsToFit As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkEstimatedVisitDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkDeclined As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboSiteFuel As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkPNO As System.Windows.Forms.CheckBox
    Friend WithEvents chkWaitingParts As CheckBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents lblQualification As Label
    Friend WithEvents cboQualification As ComboBox
    Friend WithEvents chkViewAll As CheckBox
    Friend WithEvents pnlControls As System.Windows.Forms.Panel

    Public Sub New(ByVal gridMouseDown As System.Windows.Forms.MouseEventHandler,
                   ByVal gridMouseMove As System.Windows.Forms.MouseEventHandler,
                   ByVal gridDragOver As System.Windows.Forms.DragEventHandler,
                   ByVal gridDragDrop As System.Windows.Forms.DragEventHandler,
                   ByVal gridMouseUp As System.Windows.Forms.MouseEventHandler, ByVal TEXTSIZEs As Integer)
        MyBase.New()

        Me.TEXTSIZE = TEXTSIZEs

        InitializeComponent()

        AddHandler dgCalls.MouseDown, gridMouseDown
        AddHandler dgCalls.MouseMove, gridMouseMove
        AddHandler dgCalls.DragOver, gridDragOver
        AddHandler dgCalls.DragDrop, gridDragDrop
        AddHandler dgCalls.MouseUp, gridMouseUp
    End Sub

    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents mnuVisitAction As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuView As System.Windows.Forms.MenuItem
    Friend WithEvents pnlLegend As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSearchPostcode As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchJobNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgCalls As System.Windows.Forms.DataGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtSearchAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents lblOverdue As System.Windows.Forms.Label
    Friend WithEvents picRegion As System.Windows.Forms.PictureBox
    Friend WithEvents picPostalRegions As System.Windows.Forms.PictureBox
    Friend WithEvents picLevels As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pnlUnscheduledCalls))
        Me.splitForm = New System.Windows.Forms.Splitter()
        Me.mnuVisitAction = New System.Windows.Forms.ContextMenu()
        Me.mnuView = New System.Windows.Forms.MenuItem()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlControls = New System.Windows.Forms.Panel()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.dgCalls = New System.Windows.Forms.DataGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblQualification = New System.Windows.Forms.Label()
        Me.cboQualification = New System.Windows.Forms.ComboBox()
        Me.chkWaitingParts = New System.Windows.Forms.CheckBox()
        Me.chkPNO = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboSiteFuel = New System.Windows.Forms.ComboBox()
        Me.chkDeclined = New System.Windows.Forms.CheckBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkEstimatedVisitDate = New System.Windows.Forms.CheckBox()
        Me.chkHasPartsToFit = New System.Windows.Forms.CheckBox()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSearchAddress1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSearchPostcode = New System.Windows.Forms.TextBox()
        Me.txtSearchCustomerName = New System.Windows.Forms.TextBox()
        Me.txtSearchJobNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlLegend = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.picLevels = New System.Windows.Forms.PictureBox()
        Me.picPostalRegions = New System.Windows.Forms.PictureBox()
        Me.picRegion = New System.Windows.Forms.PictureBox()
        Me.lblOverdue = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkViewAll = New System.Windows.Forms.CheckBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlControls.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        CType(Me.dgCalls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlLegend.SuspendLayout()
        CType(Me.picLevels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPostalRegions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRegion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'splitForm
        '
        Me.splitForm.Dock = System.Windows.Forms.DockStyle.Right
        Me.splitForm.Location = New System.Drawing.Point(545, 0)
        Me.splitForm.Name = "splitForm"
        Me.splitForm.Size = New System.Drawing.Size(3, 536)
        Me.splitForm.TabIndex = 1
        Me.splitForm.TabStop = False
        '
        'mnuVisitAction
        '
        Me.mnuVisitAction.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuView})
        '
        'mnuView
        '
        Me.mnuView.Index = 0
        Me.mnuView.Text = "&View"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(205, 20)
        Me.pnlHeader.TabIndex = 6
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(205, 20)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Unscheduled Calls"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlControls
        '
        Me.pnlControls.Controls.Add(Me.pnlTop)
        Me.pnlControls.Controls.Add(Me.pnlHeader)
        Me.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlControls.Location = New System.Drawing.Point(0, 0)
        Me.pnlControls.Name = "pnlControls"
        Me.pnlControls.Size = New System.Drawing.Size(545, 536)
        Me.pnlControls.TabIndex = 0
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.dgCalls)
        Me.pnlTop.Controls.Add(Me.GroupBox1)
        Me.pnlTop.Controls.Add(Me.pnlLegend)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.pnlTop.Size = New System.Drawing.Size(545, 536)
        Me.pnlTop.TabIndex = 12
        '
        'dgCalls
        '
        Me.dgCalls.AllowDrop = True
        Me.dgCalls.CaptionText = "Holding Area"
        Me.dgCalls.ContextMenu = Me.mnuVisitAction
        Me.dgCalls.DataMember = ""
        Me.dgCalls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCalls.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCalls.Location = New System.Drawing.Point(0, 0)
        Me.dgCalls.Name = "dgCalls"
        Me.dgCalls.Size = New System.Drawing.Size(545, 175)
        Me.dgCalls.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.chkViewAll)
        Me.GroupBox1.Controls.Add(Me.lblQualification)
        Me.GroupBox1.Controls.Add(Me.cboQualification)
        Me.GroupBox1.Controls.Add(Me.chkWaitingParts)
        Me.GroupBox1.Controls.Add(Me.chkPNO)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cboRegion)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cboSiteFuel)
        Me.GroupBox1.Controls.Add(Me.chkDeclined)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.chkEstimatedVisitDate)
        Me.GroupBox1.Controls.Add(Me.chkHasPartsToFit)
        Me.GroupBox1.Controls.Add(Me.cboType)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtSearchAddress1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtSearchPostcode)
        Me.GroupBox1.Controls.Add(Me.txtSearchCustomerName)
        Me.GroupBox1.Controls.Add(Me.txtSearchJobNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 175)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(545, 229)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters"
        '
        'lblQualification
        '
        Me.lblQualification.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQualification.Location = New System.Drawing.Point(216, 140)
        Me.lblQualification.Name = "lblQualification"
        Me.lblQualification.Size = New System.Drawing.Size(81, 18)
        Me.lblQualification.TabIndex = 42
        Me.lblQualification.Text = "Qualification"
        '
        'cboQualification
        '
        Me.cboQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQualification.FormattingEnabled = True
        Me.cboQualification.Location = New System.Drawing.Point(321, 137)
        Me.cboQualification.Name = "cboQualification"
        Me.cboQualification.Size = New System.Drawing.Size(214, 21)
        Me.cboQualification.TabIndex = 41
        '
        'chkWaitingParts
        '
        Me.chkWaitingParts.Location = New System.Drawing.Point(280, 202)
        Me.chkWaitingParts.Name = "chkWaitingParts"
        Me.chkWaitingParts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkWaitingParts.Size = New System.Drawing.Size(255, 21)
        Me.chkWaitingParts.TabIndex = 40
        Me.chkWaitingParts.Text = "Include Waiting For Parts"
        Me.chkWaitingParts.UseVisualStyleBackColor = True
        '
        'chkPNO
        '
        Me.chkPNO.Location = New System.Drawing.Point(280, 180)
        Me.chkPNO.Name = "chkPNO"
        Me.chkPNO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPNO.Size = New System.Drawing.Size(255, 21)
        Me.chkPNO.TabIndex = 39
        Me.chkPNO.Text = "Include Parts Need Ordering"
        Me.chkPNO.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(321, 110)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(214, 21)
        Me.TextBox1.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(217, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Summary"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(216, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 16)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Region"
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Location = New System.Drawing.Point(321, 85)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(214, 21)
        Me.cboRegion.TabIndex = 35
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(218, 63)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "Site Fuel"
        '
        'cboSiteFuel
        '
        Me.cboSiteFuel.FormattingEnabled = True
        Me.cboSiteFuel.Location = New System.Drawing.Point(321, 60)
        Me.cboSiteFuel.Name = "cboSiteFuel"
        Me.cboSiteFuel.Size = New System.Drawing.Size(214, 21)
        Me.cboSiteFuel.TabIndex = 33
        '
        'chkDeclined
        '
        Me.chkDeclined.Location = New System.Drawing.Point(6, 201)
        Me.chkDeclined.Name = "chkDeclined"
        Me.chkDeclined.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDeclined.Size = New System.Drawing.Size(249, 23)
        Me.chkDeclined.TabIndex = 31
        Me.chkDeclined.Text = "Only Declined jobs - Red Highlight"
        Me.chkDeclined.UseVisualStyleBackColor = True
        '
        'dtpTo
        '
        Me.dtpTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(399, 35)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(136, 21)
        Me.dtpTo.TabIndex = 30
        '
        'dtpFrom
        '
        Me.dtpFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(399, 11)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(136, 21)
        Me.dtpFrom.TabIndex = 29
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(357, 38)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(20, 13)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "To"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(357, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "From"
        '
        'chkEstimatedVisitDate
        '
        Me.chkEstimatedVisitDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEstimatedVisitDate.Location = New System.Drawing.Point(221, 16)
        Me.chkEstimatedVisitDate.Name = "chkEstimatedVisitDate"
        Me.chkEstimatedVisitDate.Size = New System.Drawing.Size(119, 19)
        Me.chkEstimatedVisitDate.TabIndex = 26
        Me.chkEstimatedVisitDate.Text = "Estimated Visit Date"
        Me.chkEstimatedVisitDate.UseVisualStyleBackColor = True
        '
        'chkHasPartsToFit
        '
        Me.chkHasPartsToFit.Location = New System.Drawing.Point(6, 180)
        Me.chkHasPartsToFit.Name = "chkHasPartsToFit"
        Me.chkHasPartsToFit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkHasPartsToFit.Size = New System.Drawing.Size(268, 20)
        Me.chkHasPartsToFit.TabIndex = 6
        Me.chkHasPartsToFit.Text = "Only parts to fit jobs - Orange Highlight"
        Me.chkHasPartsToFit.UseVisualStyleBackColor = True
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(111, 110)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(94, 21)
        Me.cboType.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 114)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 16)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Job Type"
        '
        'txtSearchAddress1
        '
        Me.txtSearchAddress1.Location = New System.Drawing.Point(111, 86)
        Me.txtSearchAddress1.Name = "txtSearchAddress1"
        Me.txtSearchAddress1.Size = New System.Drawing.Size(94, 21)
        Me.txtSearchAddress1.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Address 1"
        '
        'txtSearchPostcode
        '
        Me.txtSearchPostcode.Location = New System.Drawing.Point(111, 62)
        Me.txtSearchPostcode.Name = "txtSearchPostcode"
        Me.txtSearchPostcode.Size = New System.Drawing.Size(94, 21)
        Me.txtSearchPostcode.TabIndex = 3
        '
        'txtSearchCustomerName
        '
        Me.txtSearchCustomerName.Location = New System.Drawing.Point(111, 38)
        Me.txtSearchCustomerName.Name = "txtSearchCustomerName"
        Me.txtSearchCustomerName.Size = New System.Drawing.Size(94, 21)
        Me.txtSearchCustomerName.TabIndex = 2
        '
        'txtSearchJobNo
        '
        Me.txtSearchJobNo.Location = New System.Drawing.Point(111, 15)
        Me.txtSearchJobNo.Name = "txtSearchJobNo"
        Me.txtSearchJobNo.Size = New System.Drawing.Size(94, 21)
        Me.txtSearchJobNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 21)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Postcode"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Job No"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 21)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Customer Name"
        '
        'pnlLegend
        '
        Me.pnlLegend.BackColor = System.Drawing.Color.White
        Me.pnlLegend.Controls.Add(Me.Label20)
        Me.pnlLegend.Controls.Add(Me.Panel7)
        Me.pnlLegend.Controls.Add(Me.Panel6)
        Me.pnlLegend.Controls.Add(Me.Label19)
        Me.pnlLegend.Controls.Add(Me.Label14)
        Me.pnlLegend.Controls.Add(Me.Label13)
        Me.pnlLegend.Controls.Add(Me.Label12)
        Me.pnlLegend.Controls.Add(Me.picLevels)
        Me.pnlLegend.Controls.Add(Me.picPostalRegions)
        Me.pnlLegend.Controls.Add(Me.picRegion)
        Me.pnlLegend.Controls.Add(Me.lblOverdue)
        Me.pnlLegend.Controls.Add(Me.Label7)
        Me.pnlLegend.Controls.Add(Me.Label8)
        Me.pnlLegend.Controls.Add(Me.Panel3)
        Me.pnlLegend.Controls.Add(Me.Panel4)
        Me.pnlLegend.Controls.Add(Me.Label6)
        Me.pnlLegend.Controls.Add(Me.Label5)
        Me.pnlLegend.Controls.Add(Me.Panel2)
        Me.pnlLegend.Controls.Add(Me.Panel1)
        Me.pnlLegend.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlLegend.Location = New System.Drawing.Point(0, 404)
        Me.pnlLegend.Name = "pnlLegend"
        Me.pnlLegend.Size = New System.Drawing.Size(545, 127)
        Me.pnlLegend.TabIndex = 24
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label20.Location = New System.Drawing.Point(328, 103)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(192, 16)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Service overdue on site"
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BackColor = System.Drawing.Color.Orange
        Me.Panel7.Location = New System.Drawing.Point(304, 101)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(16, 16)
        Me.Panel7.TabIndex = 22
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.Red
        Me.Panel6.Location = New System.Drawing.Point(8, 101)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(16, 16)
        Me.Panel6.TabIndex = 21
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label19.Location = New System.Drawing.Point(32, 101)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(192, 16)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Visit is extremely late"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label14.Location = New System.Drawing.Point(328, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(192, 16)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Qualification check passed"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label13.Location = New System.Drawing.Point(328, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(216, 16)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Postal region check passed"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label12.Location = New System.Drawing.Point(328, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(192, 16)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Region check passed"
        '
        'picLevels
        '
        Me.picLevels.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picLevels.BackColor = System.Drawing.Color.Transparent
        Me.picLevels.Image = CType(resources.GetObject("picLevels.Image"), System.Drawing.Image)
        Me.picLevels.Location = New System.Drawing.Point(304, 85)
        Me.picLevels.Name = "picLevels"
        Me.picLevels.Size = New System.Drawing.Size(16, 16)
        Me.picLevels.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLevels.TabIndex = 14
        Me.picLevels.TabStop = False
        '
        'picPostalRegions
        '
        Me.picPostalRegions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPostalRegions.BackColor = System.Drawing.Color.Transparent
        Me.picPostalRegions.Image = CType(resources.GetObject("picPostalRegions.Image"), System.Drawing.Image)
        Me.picPostalRegions.Location = New System.Drawing.Point(304, 69)
        Me.picPostalRegions.Name = "picPostalRegions"
        Me.picPostalRegions.Size = New System.Drawing.Size(16, 16)
        Me.picPostalRegions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPostalRegions.TabIndex = 13
        Me.picPostalRegions.TabStop = False
        '
        'picRegion
        '
        Me.picRegion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picRegion.BackColor = System.Drawing.Color.Transparent
        Me.picRegion.Image = CType(resources.GetObject("picRegion.Image"), System.Drawing.Image)
        Me.picRegion.Location = New System.Drawing.Point(304, 53)
        Me.picRegion.Name = "picRegion"
        Me.picRegion.Size = New System.Drawing.Size(16, 16)
        Me.picRegion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRegion.TabIndex = 12
        Me.picRegion.TabStop = False
        '
        'lblOverdue
        '
        Me.lblOverdue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOverdue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverdue.ForeColor = System.Drawing.Color.Black
        Me.lblOverdue.Location = New System.Drawing.Point(0, 3)
        Me.lblOverdue.Name = "lblOverdue"
        Me.lblOverdue.Size = New System.Drawing.Size(545, 32)
        Me.lblOverdue.TabIndex = 11
        Me.lblOverdue.Text = "There are no contract jobs overdue."
        Me.lblOverdue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(32, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Booked Schedule Period"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label8.Location = New System.Drawing.Point(32, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(192, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Free Schedule Period"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.Location = New System.Drawing.Point(8, 85)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(16, 16)
        Me.Panel3.TabIndex = 5
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(8, 69)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(16, 16)
        Me.Panel4.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(32, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(192, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Some job tests failed"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(32, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(192, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "All job tests passed"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Coral
        Me.Panel2.Location = New System.Drawing.Point(8, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(16, 16)
        Me.Panel2.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightGreen
        Me.Panel1.Location = New System.Drawing.Point(8, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(16, 16)
        Me.Panel1.TabIndex = 0
        '
        'chkViewAll
        '
        Me.chkViewAll.AutoCheck = False
        Me.chkViewAll.Location = New System.Drawing.Point(10, 140)
        Me.chkViewAll.Name = "chkViewAll"
        Me.chkViewAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkViewAll.Size = New System.Drawing.Size(195, 20)
        Me.chkViewAll.TabIndex = 43
        Me.chkViewAll.Text = "View All Visits"
        Me.chkViewAll.UseVisualStyleBackColor = True
        '
        'pnlUnscheduledCalls
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.pnlControls)
        Me.Controls.Add(Me.splitForm)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "pnlUnscheduledCalls"
        Me.Size = New System.Drawing.Size(548, 536)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlControls.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        CType(Me.dgCalls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlLegend.ResumeLayout(False)
        CType(Me.picLevels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPostalRegions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRegion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public Class createdTypeColour : Inherits DataGridLabelColumn

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager,
                                                ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            Dim brush As Brush

            Dim str As String = CStr(CType(source.List.Item(rowNum), DataRow).Item("createdType"))
            Select Case str
                Case "manual"
                    brush = New SolidBrush(Color.LightBlue)
                Case "recent"
                    brush = New SolidBrush(Color.LightGreen)
                Case "generated"
                    brush = New SolidBrush(Color.LightYellow)
            End Select

            Dim rect As Rectangle = bounds
            g.FillRectangle(brush, rect)
        End Sub

    End Class

    Private _dvunsched As DataView

    Public Property CallsDataview() As DataView
        Get
            Return _dvunsched
        End Get
        Set(ByVal Value As DataView)
            _dvunsched = Value
        End Set
    End Property

    Private _dtUnscheduledCalls As DataTable

    Public Property unscheduledCalls() As DataTable
        Get
            Return _dtUnscheduledCalls
        End Get
        Set(ByVal Value As DataTable)
            _dtUnscheduledCalls = Value
            CallsDataview = New DataView(_dtUnscheduledCalls)
            dgCalls.DataSource = CallsDataview
            setOverdueLabel()
        End Set
    End Property

    Private ReadOnly Property SelectedDataRow() As DataRow
        Get
            If Not Me.dgCalls.CurrentRowIndex = -1 Then
                Return CallsDataview(Me.dgCalls.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property MinimumSize() As Size
        Get
            Return New Size(208, 536)
        End Get
    End Property

    Private TEXTSIZE As Integer = 7

    Public Sub setOverdueLabel()
        Try

            Dim dvFiltered As New DataView(_dtUnscheduledCalls)

            dvFiltered.RowFilter = String.Format("EstimatedVisitDate <= '{0}'", Format(Now(), "yyyy/MM/dd"))

            Dim overdueCount As Int16 = dvFiltered.Count
            If overdueCount > 1 Then
                lblOverdue.Text = String.Format("There are {0} contract jobs overdue.", overdueCount)
                lblOverdue.ForeColor = Color.Red
            ElseIf overdueCount = 1 Then
                lblOverdue.Text = String.Format("There is 1 contract job overdue.", overdueCount)
                lblOverdue.ForeColor = Color.Red
            ElseIf overdueCount = 0 Then
                lblOverdue.Text = "There are no contract job overdue."
                lblOverdue.ForeColor = Color.Black
            End If
        Catch
            lblOverdue.Text = "There are no contract job overdue."
            lblOverdue.ForeColor = Color.Black
        End Try
    End Sub

    Private isLoading As Boolean = False

    Private Sub pnlUnscheduledCalls_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUpCallsDataGrid()
        isLoading = True

        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboSiteFuel, DB.Picklists.GetAll(Enums.PickListTypes.GasTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        If loggedInUser.UserRegions.Count > 0 Then
            Combo.SetUpCombo(Me.cboRegion, loggedInUser.UserRegions.Table, "RegionID", "Name", Enums.ComboValues.No_Filter)
        Else
            Combo.SetUpCombo(Me.cboRegion, DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter)
        End If
        Me.chkHasPartsToFit.Checked = False
        Me.chkEstimatedVisitDate.Checked = True
        Me.chkPNO.Checked = True
        Me.dtpTo.Value = Now.AddDays(14)
        Me.dtpFrom.Value = Now.AddYears(-2)

        Combo.SetUpCombo(cboQualification, DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Select Case True
            Case IsRFT
                Me.lblQualification.Text = "Trade"
            Case Else
                Me.lblQualification.Text = "Qualification"
                Me.lblQualification.Visible = False
                Me.cboQualification.Visible = False
        End Select

        isLoading = False
    End Sub

    Private Sub SetUpCallsDataGrid()
        Dim diff As Double = 1
        Select Case TEXTSIZE
            Case 8
                diff = 1.1
            Case 9
                diff = 1.15
            Case 10
                diff = 1.2
            Case 11
                diff = 1.25
            Case 12
                diff = 1.3
        End Select

        SetUpSchedulerDataGrid(dgCalls, True)
        Dim tStyle As DataGridTableStyle = Me.dgCalls.TableStyles(0)
        tStyle.DataGrid.Font = New System.Drawing.Font("Verdana", TEXTSIZE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        tStyle.DataGrid.HeaderFont = New System.Drawing.Font("Verdana", TEXTSIZE, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim PartsToFit As New ColourColumn
        PartsToFit.Format = ""
        PartsToFit.FormatInfo = Nothing
        PartsToFit.HeaderText = ""
        PartsToFit.MappingName = "PartsToFit"
        PartsToFit.ReadOnly = True
        PartsToFit.Width = CInt(10 * diff)
        PartsToFit.NullText = ""
        tStyle.GridColumnStyles.Add(PartsToFit)

        Dim JobID As New UnscheduledCallsColumn
        JobID.Format = ""
        JobID.FormatInfo = Nothing
        JobID.HeaderText = "Job No"
        JobID.MappingName = "JobNumber"
        JobID.ReadOnly = True
        JobID.Width = CInt(55 * diff)
        JobID.NullText = ""
        tStyle.GridColumnStyles.Add(JobID)

        Dim Site As New UnscheduledCallsColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Address"
        Site.MappingName = "Address1"
        Site.ReadOnly = True
        Site.Width = CInt(95 * diff)
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

        Dim PostCode As New UnscheduledCallsColumn
        PostCode.Format = ""
        PostCode.FormatInfo = Nothing
        PostCode.HeaderText = "Postcode"
        PostCode.MappingName = "PostCode"
        PostCode.ReadOnly = True
        PostCode.Width = CInt(65 * diff)
        PostCode.NullText = ""
        tStyle.GridColumnStyles.Add(PostCode)

        Dim Items As New UnscheduledCallsColumn
        Items.Format = ""
        Items.FormatInfo = Nothing
        Items.HeaderText = "Job Summary"
        Items.MappingName = "JobItems"
        Items.ReadOnly = True
        Items.Width = CInt(100 * diff)
        Items.NullText = ""
        tStyle.GridColumnStyles.Add(Items)

        Dim SiteFuel As New UnscheduledCallsColumn
        SiteFuel.Format = ""
        SiteFuel.FormatInfo = Nothing
        SiteFuel.HeaderText = "Fuel"
        SiteFuel.MappingName = "SiteFuel"
        SiteFuel.ReadOnly = True
        SiteFuel.Width = CInt(30 * diff)
        SiteFuel.NullText = ""
        tStyle.GridColumnStyles.Add(SiteFuel)

        Dim Notes As New UnscheduledCallsColumn
        Notes.Format = ""
        Notes.FormatInfo = Nothing
        Notes.HeaderText = "Notes"
        Notes.MappingName = "NotesToEngineer"
        Notes.ReadOnly = True
        Notes.Width = CInt(200 * diff)
        Notes.NullText = ""
        tStyle.GridColumnStyles.Add(Notes)

        Dim qualification As New UnscheduledCallsColumn
        qualification.Format = ""
        qualification.FormatInfo = Nothing
        Select Case True
            Case IsRFT
                qualification.HeaderText = "Trade"
            Case Else
                qualification.HeaderText = "Qualification"
        End Select
        qualification.MappingName = "Qualification"
        qualification.ReadOnly = True
        qualification.Width = CInt(75 * diff)
        qualification.NullText = ""
        tStyle.GridColumnStyles.Add(qualification)

        Dim DueDate As New UnscheduledCallsColumn
        DueDate.Format = ""
        DueDate.FormatInfo = Nothing
        DueDate.HeaderText = "Due Date"
        DueDate.MappingName = "DueDate"
        DueDate.ReadOnly = True
        DueDate.Width = CInt(75 * diff)

        DueDate.NullText = ""
        tStyle.GridColumnStyles.Add(DueDate)

        Dim AMPM As New UnscheduledCallsColumn
        AMPM.Format = ""
        AMPM.FormatInfo = Nothing
        AMPM.HeaderText = ""
        AMPM.MappingName = "AMPM"
        AMPM.ReadOnly = True
        AMPM.Width = CInt(25 * diff)
        AMPM.NullText = ""
        tStyle.GridColumnStyles.Add(AMPM)

        Dim CustomerName As New UnscheduledCallsColumn
        CustomerName.Format = ""
        CustomerName.FormatInfo = Nothing
        CustomerName.HeaderText = "Customer"
        CustomerName.MappingName = "customername"
        CustomerName.ReadOnly = True
        CustomerName.Width = CInt(100 * diff)
        CustomerName.NullText = ""
        tStyle.GridColumnStyles.Add(CustomerName)

        Dim JobType As New DataGridJobTypeColumn
        JobType.Format = ""
        JobType.FormatInfo = Nothing
        JobType.HeaderText = "Type"
        JobType.MappingName = "Type"
        JobType.ReadOnly = True
        JobType.Width = CInt(75 * diff)
        JobType.NullText = ""
        tStyle.GridColumnStyles.Add(JobType)

        Dim SummedSOR As New UnscheduledCallsColumn
        SummedSOR.Format = ""
        SummedSOR.FormatInfo = Nothing
        SummedSOR.HeaderText = "SOR Time"
        SummedSOR.MappingName = "SummedSOR"
        SummedSOR.ReadOnly = True
        SummedSOR.Width = CInt(50 * diff)
        SummedSOR.NullText = ""
        tStyle.GridColumnStyles.Add(SummedSOR)

        Dim EstimatedVisitDate As New UnscheduledCallsColumn
        EstimatedVisitDate.Format = "dd/MM/yyyy"
        EstimatedVisitDate.FormatInfo = Nothing
        EstimatedVisitDate.HeaderText = "Est Date"
        EstimatedVisitDate.MappingName = "EstimatedVisitDate"
        EstimatedVisitDate.ReadOnly = True
        EstimatedVisitDate.Width = CInt(75 * diff)
        EstimatedVisitDate.NullText = "N/A"
        tStyle.GridColumnStyles.Add(EstimatedVisitDate)

        tStyle.ReadOnly = True
        tStyle.MappingName = "UnscheduledWork"
        dgCalls.TableStyles.Add(tStyle)
    End Sub

    Public Sub clearSelections()
        Try
            For rowCount As Integer = 0 To CType(dgCalls.DataSource, DataView).Count - 1
                dgCalls.UnSelect(rowCount)
            Next
        Catch
        End Try
    End Sub

    Private Sub TextBox_Filter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchAddress1.TextChanged, txtSearchCustomerName.TextChanged, txtSearchJobNo.TextChanged, txtSearchPostcode.TextChanged
        ApplyFilters()
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub chkHasPartsToFit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHasPartsToFit.CheckedChanged
        ApplyFilters()
    End Sub

    Public Sub ApplyFilters()
        If isLoading Then
            Exit Sub
        End If

        Dim FilterString As String

        FilterString = "postcode like '%" & Helper.RemoveSpecialCharacters(Trim(txtSearchPostcode.Text)) & "%' AND "
        FilterString += "Address1 like '%" & Helper.RemoveSpecialCharacters(Trim(txtSearchAddress1.Text)) & "%' AND "
        FilterString += "JobNumber like '%" & Helper.RemoveSpecialCharacters(Trim(txtSearchJobNo.Text)) & "%' AND "
        FilterString += "customername like '%" & Helper.RemoveSpecialCharacters(Trim(txtSearchCustomerName.Text)) & "%' AND "
        FilterString += "JobItems like '%" & Helper.RemoveSpecialCharacters(Trim(TextBox1.Text)) & "%' "
        If Not Combo.GetSelectedItemValue(Me.cboType) = 0 Then
            FilterString += "AND JobTypeID = " & Combo.GetSelectedItemValue(Me.cboType) & " "
        End If
        If Me.chkHasPartsToFit.Checked Then
            FilterString += "AND PartsToFit <> 0 "
        End If
        If Me.chkDeclined.Checked Then
            FilterString += "AND FollowUpDeclined <> 0 "
        End If

        If Me.chkPNO.Checked = False Then
            FilterString += "AND PartsNeedOrdering = 0 "
        End If

        If Me.chkWaitingParts.Checked = False Then
            FilterString += "AND WaitingForParts = 0 "
        End If

        If Me.chkHasPartsToFit.Checked = False Then
            If Me.chkEstimatedVisitDate.Checked Then
                Me.dtpFrom.Enabled = True
                Me.dtpTo.Enabled = True
                FilterString += " AND ((EstimatedVisitDate >= '" & Format(Me.dtpFrom.Value.Date, "dd-MMM-yyyy 00:00:00") & "' AND EstimatedVisitDate <= '" &
                                Format(Me.dtpTo.Value.Date, "dd-MMM-yyyy 23:59:59") & "') OR (EstimatedVisitDate IS NULL))"
            Else
                Me.dtpFrom.Enabled = False
                Me.dtpTo.Enabled = False
                Me.dtpFrom.Value = Now
                Me.dtpTo.Value = Now
            End If
        End If
        If Not Combo.GetSelectedItemValue(Me.cboSiteFuel) = "0" Then
            FilterString += " AND FuelID = '" & Combo.GetSelectedItemValue(Me.cboSiteFuel) & "' "
        End If

        If Not Combo.GetSelectedItemValue(Me.cboRegion) = "0" Then
            FilterString += " AND RegionID = " & Combo.GetSelectedItemValue(Me.cboRegion) & " "
        End If

        If Not Combo.GetSelectedItemValue(Me.cboQualification) = "0" Then
            FilterString += " AND QualificationID = " & Combo.GetSelectedItemValue(Me.cboQualification) & " "
        End If

        If Not CallsDataview Is Nothing Then
            CallsDataview.RowFilter = FilterString
        End If
    End Sub

    Private Sub pnlUnscheduledCalls_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim skip As Boolean = False
        If Me.Height < MinimumSize.Height Then
            Me.Height = MinimumSize.Height
        End If
        If Me.Width < MinimumSize.Width Then
            Me.Width = MinimumSize.Width
        End If
        pnlTop.Height = CInt(Me.Height * 0.7)
    End Sub

    Dim mousePosDownX As Integer = -1

    Private Sub splitForm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles splitForm.MouseDown
        mousePosDownX = e.X
    End Sub

    Private Sub splitForm_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles splitForm.MouseMove
        If Not mousePosDownX = -1 Then
            Me.Width += e.X - mousePosDownX
        End If
    End Sub

    Private Sub splitForm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles splitForm.MouseUp
        mousePosDownX = -1
    End Sub

    Private Sub dgCalls_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCalls.DoubleClick
        If SelectedDataRow Is Nothing Then
            ShowMessage("Please select a visit to open the job", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedDataRow.Item("JobID"), SelectedDataRow.Item("SiteID"), Me, Nothing, SelectedDataRow("EngineerVisitID")})
        Catch
        End Try
    End Sub

    Private Sub chkEstimatedVisitDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEstimatedVisitDate.CheckedChanged
        ApplyFilters()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        ApplyFilters()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        ApplyFilters()
    End Sub

    Private Sub chkDeclined_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDeclined.CheckedChanged
        ApplyFilters()
    End Sub

    Private Sub cboSiteFuel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSiteFuel.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub cboRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRegion.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ApplyFilters()
    End Sub

    Private Sub chkPNO_CheckedChanged(sender As Object, e As EventArgs) Handles chkPNO.CheckedChanged
        ApplyFilters()
    End Sub

    Private Sub chkWaitingParts_CheckedChanged(sender As Object, e As EventArgs) Handles chkWaitingParts.CheckedChanged
        ApplyFilters()
    End Sub

    Private Sub cboQualification_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboQualification.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub chkViewAll_Click(sender As Object, e As EventArgs) Handles chkViewAll.Click
        chkViewAll.Checked = Not chkViewAll.Checked
    End Sub

End Class