Imports System.Linq
Imports FSM.Entity.Sys

Public Class FRMVisitManager : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox

    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboDefinition As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents chkVisitDate As System.Windows.Forms.CheckBox
    Friend WithEvents grpEngineerVisits As System.Windows.Forms.GroupBox
    Friend WithEvents dgVisits As System.Windows.Forms.DataGrid
    Friend WithEvents btnRequiringParts As System.Windows.Forms.Button
    Friend WithEvents btnCreateOrder As System.Windows.Forms.Button
    Friend WithEvents btnFindSite As System.Windows.Forms.Button
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnfindEngineer As System.Windows.Forms.Button
    Friend WithEvents txtEngineer As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboOutcome As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CboServExp As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents chkftfcode As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboLetterNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents dtpToServiceDate As DateTimePicker
    Friend WithEvents dtpFromServiceDate As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents chkServiceDate As CheckBox
    Friend WithEvents dtpVisitEndTo As DateTimePicker
    Friend WithEvents dtpVisitEndFrom As DateTimePicker
    Friend WithEvents lblVisitEndTo As Label
    Friend WithEvents lblVisitEndFrom As Label
    Friend WithEvents chkVisitEnd As CheckBox
    Friend WithEvents chkRecharge As CheckBox
    Friend WithEvents lblVisitCharge As Label
    Friend WithEvents cboVisitCharge As ComboBox
    Friend WithEvents lblNonChargeable As Label
    Friend WithEvents lblGreenColour As Label
    Friend WithEvents lblVisitChargeable As Label
    Friend WithEvents lblYellowColour As Label
    Friend WithEvents lblQualification As Label
    Friend WithEvents cboQualification As ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpEngineerVisits = New System.Windows.Forms.GroupBox()
        Me.dgVisits = New System.Windows.Forms.DataGrid()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.lblQualification = New System.Windows.Forms.Label()
        Me.cboQualification = New System.Windows.Forms.ComboBox()
        Me.lblNonChargeable = New System.Windows.Forms.Label()
        Me.lblGreenColour = New System.Windows.Forms.Label()
        Me.lblVisitChargeable = New System.Windows.Forms.Label()
        Me.lblYellowColour = New System.Windows.Forms.Label()
        Me.lblVisitCharge = New System.Windows.Forms.Label()
        Me.cboVisitCharge = New System.Windows.Forms.ComboBox()
        Me.chkRecharge = New System.Windows.Forms.CheckBox()
        Me.dtpVisitEndTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpVisitEndFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblVisitEndTo = New System.Windows.Forms.Label()
        Me.lblVisitEndFrom = New System.Windows.Forms.Label()
        Me.chkVisitEnd = New System.Windows.Forms.CheckBox()
        Me.dtpToServiceDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromServiceDate = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkServiceDate = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboLetterNumber = New System.Windows.Forms.ComboBox()
        Me.chkftfcode = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CboServExp = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboOutcome = New System.Windows.Forms.ComboBox()
        Me.btnfindEngineer = New System.Windows.Forms.Button()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFindSite = New System.Windows.Forms.Button()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtPONumber = New System.Windows.Forms.TextBox()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkVisitDate = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboDefinition = New System.Windows.Forms.ComboBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnRequiringParts = New System.Windows.Forms.Button()
        Me.btnCreateOrder = New System.Windows.Forms.Button()
        Me.grpEngineerVisits.SuspendLayout()
        CType(Me.dgVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpEngineerVisits
        '
        Me.grpEngineerVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineerVisits.Controls.Add(Me.dgVisits)
        Me.grpEngineerVisits.Location = New System.Drawing.Point(8, 303)
        Me.grpEngineerVisits.Name = "grpEngineerVisits"
        Me.grpEngineerVisits.Size = New System.Drawing.Size(1438, 222)
        Me.grpEngineerVisits.TabIndex = 2
        Me.grpEngineerVisits.TabStop = False
        '
        'dgVisits
        '
        Me.dgVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgVisits.DataMember = ""
        Me.dgVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVisits.Location = New System.Drawing.Point(8, 20)
        Me.dgVisits.Name = "dgVisits"
        Me.dgVisits.Size = New System.Drawing.Size(1422, 194)
        Me.dgVisits.TabIndex = 14
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 531)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 15
        Me.btnExport.Text = "Export"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.lblQualification)
        Me.grpFilter.Controls.Add(Me.cboQualification)
        Me.grpFilter.Controls.Add(Me.lblNonChargeable)
        Me.grpFilter.Controls.Add(Me.lblGreenColour)
        Me.grpFilter.Controls.Add(Me.lblVisitChargeable)
        Me.grpFilter.Controls.Add(Me.lblYellowColour)
        Me.grpFilter.Controls.Add(Me.lblVisitCharge)
        Me.grpFilter.Controls.Add(Me.cboVisitCharge)
        Me.grpFilter.Controls.Add(Me.chkRecharge)
        Me.grpFilter.Controls.Add(Me.dtpVisitEndTo)
        Me.grpFilter.Controls.Add(Me.dtpVisitEndFrom)
        Me.grpFilter.Controls.Add(Me.lblVisitEndTo)
        Me.grpFilter.Controls.Add(Me.lblVisitEndFrom)
        Me.grpFilter.Controls.Add(Me.chkVisitEnd)
        Me.grpFilter.Controls.Add(Me.dtpToServiceDate)
        Me.grpFilter.Controls.Add(Me.dtpFromServiceDate)
        Me.grpFilter.Controls.Add(Me.Label18)
        Me.grpFilter.Controls.Add(Me.Label19)
        Me.grpFilter.Controls.Add(Me.chkServiceDate)
        Me.grpFilter.Controls.Add(Me.Label17)
        Me.grpFilter.Controls.Add(Me.cboPriority)
        Me.grpFilter.Controls.Add(Me.Label16)
        Me.grpFilter.Controls.Add(Me.cboLetterNumber)
        Me.grpFilter.Controls.Add(Me.chkftfcode)
        Me.grpFilter.Controls.Add(Me.Label15)
        Me.grpFilter.Controls.Add(Me.cboDepartment)
        Me.grpFilter.Controls.Add(Me.Label14)
        Me.grpFilter.Controls.Add(Me.CboServExp)
        Me.grpFilter.Controls.Add(Me.Label13)
        Me.grpFilter.Controls.Add(Me.cboRegion)
        Me.grpFilter.Controls.Add(Me.btnSearch)
        Me.grpFilter.Controls.Add(Me.Label12)
        Me.grpFilter.Controls.Add(Me.cboOutcome)
        Me.grpFilter.Controls.Add(Me.btnfindEngineer)
        Me.grpFilter.Controls.Add(Me.txtEngineer)
        Me.grpFilter.Controls.Add(Me.Label5)
        Me.grpFilter.Controls.Add(Me.btnFindCustomer)
        Me.grpFilter.Controls.Add(Me.txtCustomer)
        Me.grpFilter.Controls.Add(Me.Label4)
        Me.grpFilter.Controls.Add(Me.txtPostcode)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.btnFindSite)
        Me.grpFilter.Controls.Add(Me.txtSite)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.txtPONumber)
        Me.grpFilter.Controls.Add(Me.txtJobNumber)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Controls.Add(Me.chkVisitDate)
        Me.grpFilter.Controls.Add(Me.Label7)
        Me.grpFilter.Controls.Add(Me.Label6)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.Label10)
        Me.grpFilter.Controls.Add(Me.cboType)
        Me.grpFilter.Controls.Add(Me.Label11)
        Me.grpFilter.Controls.Add(Me.cboStatus)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(1438, 271)
        Me.grpFilter.TabIndex = 1
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'lblQualification
        '
        Me.lblQualification.BackColor = System.Drawing.Color.Transparent
        Me.lblQualification.Location = New System.Drawing.Point(662, 150)
        Me.lblQualification.Name = "lblQualification"
        Me.lblQualification.Size = New System.Drawing.Size(90, 16)
        Me.lblQualification.TabIndex = 63
        Me.lblQualification.Text = "Qualification"
        '
        'cboQualification
        '
        Me.cboQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQualification.Location = New System.Drawing.Point(776, 147)
        Me.cboQualification.Name = "cboQualification"
        Me.cboQualification.Size = New System.Drawing.Size(266, 21)
        Me.cboQualification.TabIndex = 62
        '
        'lblNonChargeable
        '
        Me.lblNonChargeable.Location = New System.Drawing.Point(876, 244)
        Me.lblNonChargeable.Name = "lblNonChargeable"
        Me.lblNonChargeable.Size = New System.Drawing.Size(139, 16)
        Me.lblNonChargeable.TabIndex = 61
        Me.lblNonChargeable.Text = "Non-Chargeable Visit"
        '
        'lblGreenColour
        '
        Me.lblGreenColour.BackColor = System.Drawing.Color.LightGreen
        Me.lblGreenColour.Location = New System.Drawing.Point(850, 240)
        Me.lblGreenColour.Name = "lblGreenColour"
        Me.lblGreenColour.Size = New System.Drawing.Size(20, 20)
        Me.lblGreenColour.TabIndex = 60
        '
        'lblVisitChargeable
        '
        Me.lblVisitChargeable.Location = New System.Drawing.Point(738, 244)
        Me.lblVisitChargeable.Name = "lblVisitChargeable"
        Me.lblVisitChargeable.Size = New System.Drawing.Size(109, 17)
        Me.lblVisitChargeable.TabIndex = 59
        Me.lblVisitChargeable.Text = "Chargeable Visit"
        '
        'lblYellowColour
        '
        Me.lblYellowColour.BackColor = System.Drawing.Color.Yellow
        Me.lblYellowColour.Location = New System.Drawing.Point(712, 240)
        Me.lblYellowColour.Name = "lblYellowColour"
        Me.lblYellowColour.Size = New System.Drawing.Size(20, 20)
        Me.lblYellowColour.TabIndex = 58
        '
        'lblVisitCharge
        '
        Me.lblVisitCharge.Location = New System.Drawing.Point(662, 117)
        Me.lblVisitCharge.Name = "lblVisitCharge"
        Me.lblVisitCharge.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitCharge.TabIndex = 57
        Me.lblVisitCharge.Text = "Visit Chargeable?"
        '
        'cboVisitCharge
        '
        Me.cboVisitCharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboVisitCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitCharge.Location = New System.Drawing.Point(776, 113)
        Me.cboVisitCharge.MinimumSize = New System.Drawing.Size(70, 0)
        Me.cboVisitCharge.Name = "cboVisitCharge"
        Me.cboVisitCharge.Size = New System.Drawing.Size(297, 21)
        Me.cboVisitCharge.TabIndex = 56
        '
        'chkRecharge
        '
        Me.chkRecharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkRecharge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkRecharge.Location = New System.Drawing.Point(1106, 209)
        Me.chkRecharge.Name = "chkRecharge"
        Me.chkRecharge.Size = New System.Drawing.Size(95, 24)
        Me.chkRecharge.TabIndex = 55
        Me.chkRecharge.Text = "Recharge"
        Me.chkRecharge.UseVisualStyleBackColor = True
        '
        'dtpVisitEndTo
        '
        Me.dtpVisitEndTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpVisitEndTo.Enabled = False
        Me.dtpVisitEndTo.Location = New System.Drawing.Point(1274, 118)
        Me.dtpVisitEndTo.Name = "dtpVisitEndTo"
        Me.dtpVisitEndTo.Size = New System.Drawing.Size(156, 21)
        Me.dtpVisitEndTo.TabIndex = 54
        '
        'dtpVisitEndFrom
        '
        Me.dtpVisitEndFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpVisitEndFrom.Enabled = False
        Me.dtpVisitEndFrom.Location = New System.Drawing.Point(1274, 91)
        Me.dtpVisitEndFrom.Name = "dtpVisitEndFrom"
        Me.dtpVisitEndFrom.Size = New System.Drawing.Size(156, 21)
        Me.dtpVisitEndFrom.TabIndex = 53
        '
        'lblVisitEndTo
        '
        Me.lblVisitEndTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVisitEndTo.Location = New System.Drawing.Point(1220, 121)
        Me.lblVisitEndTo.Name = "lblVisitEndTo"
        Me.lblVisitEndTo.Size = New System.Drawing.Size(48, 16)
        Me.lblVisitEndTo.TabIndex = 51
        Me.lblVisitEndTo.Text = "To"
        '
        'lblVisitEndFrom
        '
        Me.lblVisitEndFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVisitEndFrom.Location = New System.Drawing.Point(1220, 93)
        Me.lblVisitEndFrom.Name = "lblVisitEndFrom"
        Me.lblVisitEndFrom.Size = New System.Drawing.Size(48, 16)
        Me.lblVisitEndFrom.TabIndex = 50
        Me.lblVisitEndFrom.Text = "From"
        '
        'chkVisitEnd
        '
        Me.chkVisitEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkVisitEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkVisitEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkVisitEnd.Location = New System.Drawing.Point(1106, 84)
        Me.chkVisitEnd.Name = "chkVisitEnd"
        Me.chkVisitEnd.Size = New System.Drawing.Size(115, 24)
        Me.chkVisitEnd.TabIndex = 52
        Me.chkVisitEnd.Text = "Visit End Date"
        '
        'dtpToServiceDate
        '
        Me.dtpToServiceDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpToServiceDate.Location = New System.Drawing.Point(1274, 184)
        Me.dtpToServiceDate.Name = "dtpToServiceDate"
        Me.dtpToServiceDate.Size = New System.Drawing.Size(158, 21)
        Me.dtpToServiceDate.TabIndex = 49
        '
        'dtpFromServiceDate
        '
        Me.dtpFromServiceDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFromServiceDate.Location = New System.Drawing.Point(1274, 153)
        Me.dtpFromServiceDate.Name = "dtpFromServiceDate"
        Me.dtpFromServiceDate.Size = New System.Drawing.Size(158, 21)
        Me.dtpFromServiceDate.TabIndex = 48
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.Location = New System.Drawing.Point(1220, 187)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 16)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "To"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.Location = New System.Drawing.Point(1220, 155)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 16)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "From"
        '
        'chkServiceDate
        '
        Me.chkServiceDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkServiceDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkServiceDate.Location = New System.Drawing.Point(1106, 150)
        Me.chkServiceDate.Name = "chkServiceDate"
        Me.chkServiceDate.Size = New System.Drawing.Size(95, 24)
        Me.chkServiceDate.TabIndex = 47
        Me.chkServiceDate.Text = "Service Date"
        Me.chkServiceDate.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(6, 248)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(94, 15)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Priority"
        '
        'cboPriority
        '
        Me.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriority.Location = New System.Drawing.Point(104, 243)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(184, 21)
        Me.cboPriority.TabIndex = 43
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(295, 244)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 16)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Letter Number"
        '
        'cboLetterNumber
        '
        Me.cboLetterNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLetterNumber.Location = New System.Drawing.Point(390, 240)
        Me.cboLetterNumber.Name = "cboLetterNumber"
        Me.cboLetterNumber.Size = New System.Drawing.Size(266, 21)
        Me.cboLetterNumber.TabIndex = 41
        '
        'chkftfcode
        '
        Me.chkftfcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkftfcode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkftfcode.Location = New System.Drawing.Point(1335, 213)
        Me.chkftfcode.Name = "chkftfcode"
        Me.chkftfcode.Size = New System.Drawing.Size(95, 17)
        Me.chkftfcode.TabIndex = 40
        Me.chkftfcode.Text = "No FTF code"
        Me.chkftfcode.UseVisualStyleBackColor = True
        Me.chkftfcode.Visible = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(296, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 20)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Cost Centre"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Location = New System.Drawing.Point(390, 116)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(266, 21)
        Me.cboDepartment.TabIndex = 38
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(6, 220)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Serv Expires in"
        '
        'CboServExp
        '
        Me.CboServExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboServExp.Location = New System.Drawing.Point(104, 214)
        Me.CboServExp.Name = "CboServExp"
        Me.CboServExp.Size = New System.Drawing.Size(184, 21)
        Me.CboServExp.TabIndex = 36
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(6, 153)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Region"
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.Location = New System.Drawing.Point(104, 149)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(184, 21)
        Me.cboRegion.TabIndex = 34
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(1360, 242)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(70, 23)
        Me.btnSearch.TabIndex = 33
        Me.btnSearch.Text = "Run Filter"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(296, 181)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 22)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Outcome"
        '
        'cboOutcome
        '
        Me.cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOutcome.Location = New System.Drawing.Point(390, 178)
        Me.cboOutcome.Name = "cboOutcome"
        Me.cboOutcome.Size = New System.Drawing.Size(266, 21)
        Me.cboOutcome.TabIndex = 32
        '
        'btnfindEngineer
        '
        Me.btnfindEngineer.BackColor = System.Drawing.Color.White
        Me.btnfindEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindEngineer.Location = New System.Drawing.Point(624, 85)
        Me.btnfindEngineer.Name = "btnfindEngineer"
        Me.btnfindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnfindEngineer.TabIndex = 29
        Me.btnfindEngineer.Text = "..."
        Me.btnfindEngineer.UseVisualStyleBackColor = False
        '
        'txtEngineer
        '
        Me.txtEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngineer.Location = New System.Drawing.Point(390, 86)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(228, 21)
        Me.txtEngineer.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(296, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Engineer"
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(1043, 26)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 2
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(104, 25)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(933, 21)
        Me.txtCustomer.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Customer"
        '
        'txtPostcode
        '
        Me.txtPostcode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostcode.Location = New System.Drawing.Point(104, 85)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(184, 21)
        Me.txtPostcode.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Postcode"
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.BackColor = System.Drawing.Color.White
        Me.btnFindSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSite.Location = New System.Drawing.Point(1043, 53)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSite.TabIndex = 4
        Me.btnFindSite.Text = "..."
        Me.btnFindSite.UseVisualStyleBackColor = False
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(104, 55)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(933, 21)
        Me.txtSite.TabIndex = 3
        '
        'dtpTo
        '
        Me.dtpTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTo.Location = New System.Drawing.Point(1274, 56)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(156, 21)
        Me.dtpTo.TabIndex = 13
        '
        'dtpFrom
        '
        Me.dtpFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFrom.Location = New System.Drawing.Point(1274, 29)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(156, 21)
        Me.dtpFrom.TabIndex = 12
        '
        'txtPONumber
        '
        Me.txtPONumber.Location = New System.Drawing.Point(104, 182)
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.Size = New System.Drawing.Size(184, 21)
        Me.txtPONumber.TabIndex = 10
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Location = New System.Drawing.Point(390, 210)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(266, 21)
        Me.txtJobNumber.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(1220, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "To"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Location = New System.Drawing.Point(1220, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "From"
        '
        'chkVisitDate
        '
        Me.chkVisitDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkVisitDate.Checked = True
        Me.chkVisitDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVisitDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkVisitDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkVisitDate.Location = New System.Drawing.Point(1106, 26)
        Me.chkVisitDate.Name = "chkVisitDate"
        Me.chkVisitDate.Size = New System.Drawing.Size(80, 24)
        Me.chkVisitDate.TabIndex = 11
        Me.chkVisitDate.Text = "Visit Date"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "PO Number"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(297, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Job Number"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Property"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(296, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 22)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Job Type"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(390, 147)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(266, 21)
        Me.cboType.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 123)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 22)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(104, 117)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(184, 21)
        Me.cboStatus.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Definition"
        '
        'cboDefinition
        '
        Me.cboDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefinition.Location = New System.Drawing.Point(104, 116)
        Me.cboDefinition.Name = "cboDefinition"
        Me.cboDefinition.Size = New System.Drawing.Size(184, 21)
        Me.cboDefinition.TabIndex = 6
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(72, 531)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 16
        Me.btnReset.Text = "Reset"
        '
        'btnRequiringParts
        '
        Me.btnRequiringParts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRequiringParts.Location = New System.Drawing.Point(136, 531)
        Me.btnRequiringParts.Name = "btnRequiringParts"
        Me.btnRequiringParts.Size = New System.Drawing.Size(144, 23)
        Me.btnRequiringParts.TabIndex = 17
        Me.btnRequiringParts.Text = "Visits Requiring Parts"
        '
        'btnCreateOrder
        '
        Me.btnCreateOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCreateOrder.Location = New System.Drawing.Point(288, 531)
        Me.btnCreateOrder.Name = "btnCreateOrder"
        Me.btnCreateOrder.Size = New System.Drawing.Size(112, 23)
        Me.btnCreateOrder.TabIndex = 18
        Me.btnCreateOrder.Text = "Create Order"
        '
        'FRMVisitManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1454, 561)
        Me.Controls.Add(Me.btnCreateOrder)
        Me.Controls.Add(Me.btnRequiringParts)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpEngineerVisits)
        Me.Controls.Add(Me.btnReset)
        Me.MinimumSize = New System.Drawing.Size(808, 528)
        Me.Name = "FRMVisitManager"
        Me.Text = "Visit Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpEngineerVisits, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.Controls.SetChildIndex(Me.btnRequiringParts, 0)
        Me.Controls.SetChildIndex(Me.btnCreateOrder, 0)
        Me.grpEngineerVisits.ResumeLayout(False)
        CType(Me.dgVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupVisitDataGrid()
        'Combo.SetUpCombo(Me.cboDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboOutcome, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        'get the region assigned to the user
        If loggedInUser.UserRegions.Count > 0 Then
            Combo.SetUpCombo(Me.cboRegion, loggedInUser.UserRegions.Table, "RegionID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Else
            Combo.SetUpCombo(Me.cboRegion, DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        End If

        Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.CboServExp, DynamicDataTables.ServExpiry, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboLetterNumber, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboPriority, DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboVisitCharge, DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboQualification, DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select

        Select Case True
            Case IsRFT
                Me.lblQualification.Text = "Trade"
            Case Else
                Me.lblQualification.Text = "Qualification"
                Me.lblQualification.Visible = False
                Me.cboQualification.Visible = False
        End Select

        If loggedInUser.Admin = False Then
            Me.btnExport.Enabled = False
        End If

        If Not GetParameter(1) Is Nothing And Not GetParameter(2) Is Nothing Then
            If GetParameter(2) = "From Invoice Manager" Then
                dtVisitFilters = GetParameter(1)
                LoadLastFilters()
            Else

                PopulateDatagrid(False)

            End If
        Else

            ' PopulateDatagrid(False)

        End If

    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Dim count As Integer = 0

    Private _dvVisits As DataView

    Private Property VisitsDataview() As DataView
        Get
            Return _dvVisits
        End Get
        Set(ByVal value As DataView)
            _dvVisits = value

            If Not VisitsDataview Is Nothing Then
                _dvVisits.AllowNew = False
                _dvVisits.AllowEdit = False
                _dvVisits.AllowDelete = False
                _dvVisits.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
            End If

            Me.dgVisits.DataSource = VisitsDataview

            If Not VisitsDataview Is Nothing Then
                If VisitsDataview.Table.Rows.Count > 0 Then
                    Me.dgVisits.Select(0)
                End If
            End If
        End Set
    End Property

    Private ReadOnly Property SelectedVisitDataRow() As DataRow
        Get
            If VisitsDataview Is Nothing Then
                Return Nothing
            End If
            If Not Me.dgVisits.CurrentRowIndex = -1 Then
                Return VisitsDataview(Me.dgVisits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _theCustomer As Entity.Customers.Customer

    Public Property theCustomer() As Entity.Customers.Customer
        Get
            Return _theCustomer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _theCustomer = Value
            theSite = Nothing
            If Not _theCustomer Is Nothing Then
                Me.txtCustomer.Text = theCustomer.Name & " (A/C No : " & theCustomer.AccountNumber & ")"
            Else
                Me.txtCustomer.Text = ""

            End If
        End Set
    End Property

    Private _oSite As Entity.Sites.Site

    Public Property theSite() As Entity.Sites.Site
        Get
            Return _oSite
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _oSite = Value
            If Not _oSite Is Nothing Then
                Me.txtSite.Text = theSite.Address1 & ", " & theSite.Address2 & ", " & theSite.Postcode
            Else
                Me.txtSite.Text = ""
            End If
        End Set
    End Property

    Private _theEngineer As Entity.Engineers.Engineer

    Public Property theEngineer() As Entity.Engineers.Engineer
        Get
            Return _theEngineer
        End Get
        Set(ByVal Value As Entity.Engineers.Engineer)
            _theEngineer = Value
            If Not _theEngineer Is Nothing Then
                Me.txtEngineer.Text = theEngineer.Name
            Else
                Me.txtEngineer.Text = ""
            End If
        End Set
    End Property

    Private _dtVisit As New DataTable

    Public Property dtVisitFilters() As DataTable
        Get
            If _dtVisit.Columns.Count = 0 Then
                _dtVisit.Columns.Add("Field")
                _dtVisit.Columns.Add("Value")
                _dtVisit.Columns.Add("Type")
            End If
            Return _dtVisit
        End Get
        Set(ByVal value As DataTable)
            _dtVisit = value
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupVisitDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgVisits.TableStyles(0)

        Dim visitCharge As New DataGridVisitManagerColumn
        visitCharge.Format = ""
        visitCharge.FormatInfo = Nothing
        visitCharge.HeaderText = ""
        visitCharge.MappingName = "VisitChargeable"
        visitCharge.ReadOnly = True
        visitCharge.Width = 30
        visitCharge.NullText = ""
        visitCharge.TextBox.Text = ""
        tbStyle.GridColumnStyles.Add(visitCharge)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 120
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 200
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 65
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        tbStyle.GridColumnStyles.Add(Type)

        Dim PartsToFit As New BitToStringDescriptionColumn
        PartsToFit.Format = ""
        PartsToFit.FormatInfo = Nothing
        PartsToFit.HeaderText = "Parts To Fit"
        PartsToFit.MappingName = "PartsToFit"
        PartsToFit.ReadOnly = True
        PartsToFit.Width = 25
        PartsToFit.NullText = ""
        tbStyle.GridColumnStyles.Add(PartsToFit)

        Dim VisitStatus As New DataGridLabelColumn
        VisitStatus.Format = ""
        VisitStatus.FormatInfo = Nothing
        VisitStatus.HeaderText = "Status"
        VisitStatus.MappingName = "VisitStatus"
        VisitStatus.ReadOnly = True
        VisitStatus.Width = 75
        VisitStatus.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitStatus)

        Dim VisitOutcome As New DataGridLabelColumn
        VisitOutcome.Format = ""
        VisitOutcome.FormatInfo = Nothing
        VisitOutcome.HeaderText = "Outcome"
        VisitOutcome.MappingName = "VisitOutcome"
        VisitOutcome.ReadOnly = True
        VisitOutcome.Width = 75
        VisitOutcome.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitOutcome)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MMM/yyyy"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Visit Date"
        StartDateTime.MappingName = "VisitDate"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 170
        StartDateTime.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(StartDateTime)

        Select Case True
            Case IsRFT
                Dim trade As New DataGridLabelColumn
                trade.Format = ""
                trade.FormatInfo = Nothing
                trade.HeaderText = "Trade"
                trade.MappingName = "Qualification"
                trade.ReadOnly = True
                trade.Width = 85
                trade.NullText = ""
                tbStyle.GridColumnStyles.Add(trade)
        End Select

        Dim NotesTo As New DataGridLabelColumn
        NotesTo.Format = ""
        NotesTo.FormatInfo = Nothing
        NotesTo.HeaderText = "Notes to Engineer"
        NotesTo.MappingName = "NotesToEngineer"
        NotesTo.ReadOnly = True
        NotesTo.Width = 250
        NotesTo.NullText = "N/A"
        tbStyle.GridColumnStyles.Add(NotesTo)

        Dim Engineer As New DataGridLabelColumn
        Engineer.Format = ""
        Engineer.FormatInfo = Nothing
        Engineer.HeaderText = "Engineer"
        Engineer.MappingName = "Engineer"
        Engineer.ReadOnly = True
        Engineer.Width = 90
        Engineer.NullText = ""
        tbStyle.GridColumnStyles.Add(Engineer)

        Dim InvoiceNotes As New DataGridLabelColumn
        InvoiceNotes.Format = ""
        InvoiceNotes.FormatInfo = Nothing
        InvoiceNotes.HeaderText = "Invoice Notes"
        InvoiceNotes.MappingName = "InvoiceNotes"
        InvoiceNotes.ReadOnly = True
        InvoiceNotes.Width = 200
        InvoiceNotes.NullText = ""
        tbStyle.GridColumnStyles.Add(InvoiceNotes)

        Dim ServiceExpiryDate As New DataGridLabelColumn
        ServiceExpiryDate.Format = "dd/MMM/yyyy"
        ServiceExpiryDate.FormatInfo = Nothing
        ServiceExpiryDate.HeaderText = "Service Expiry Date"
        ServiceExpiryDate.MappingName = "ServiceExpiryDate"
        ServiceExpiryDate.ReadOnly = True
        ServiceExpiryDate.Width = 80
        ServiceExpiryDate.NullText = ""
        tbStyle.GridColumnStyles.Add(ServiceExpiryDate)

        Dim SiteFuel As New DataGridLabelColumn
        SiteFuel.Format = ""
        SiteFuel.FormatInfo = Nothing
        SiteFuel.HeaderText = "Site Fuel"
        SiteFuel.MappingName = "SiteFuel"
        SiteFuel.ReadOnly = True
        SiteFuel.Width = 75
        SiteFuel.NullText = ""
        tbStyle.GridColumnStyles.Add(SiteFuel)

        Dim PONumber As New DataGridLabelColumn
        PONumber.Format = ""
        PONumber.FormatInfo = Nothing
        PONumber.HeaderText = "PO Number"
        PONumber.MappingName = "PONumber"
        PONumber.ReadOnly = True
        PONumber.Width = 55
        PONumber.NullText = ""
        tbStyle.GridColumnStyles.Add(PONumber)

        Dim estimatedService As New DataGridLabelColumn
        estimatedService.Format = "dd/MMM/yyyy"
        estimatedService.FormatInfo = Nothing
        estimatedService.HeaderText = "Estimated Service Date"
        estimatedService.MappingName = "EstimatedVisitDate"
        estimatedService.ReadOnly = True
        estimatedService.Width = 80
        estimatedService.NullText = ""
        tbStyle.GridColumnStyles.Add(estimatedService)

        Dim Priority As New DataGridLabelColumn
        Priority.Format = ""
        Priority.FormatInfo = Nothing
        Priority.HeaderText = "Priority"
        Priority.MappingName = "Priority"
        Priority.ReadOnly = True
        Priority.Width = 65
        Priority.NullText = ""
        tbStyle.GridColumnStyles.Add(Priority)

        Dim LetterNumber As New DataGridLabelColumn
        LetterNumber.Format = ""
        LetterNumber.FormatInfo = Nothing
        LetterNumber.HeaderText = "Let Num"
        LetterNumber.MappingName = "VisitNumber"
        LetterNumber.ReadOnly = True
        LetterNumber.Width = 55
        LetterNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(LetterNumber)

        Dim jobCreatedTime As New DataGridLabelColumn
        jobCreatedTime.Format = "dd/MMM/yyyy"
        jobCreatedTime.FormatInfo = Nothing
        jobCreatedTime.HeaderText = "Job Created"
        jobCreatedTime.MappingName = "JobCreatedDateTime"
        jobCreatedTime.ReadOnly = True
        jobCreatedTime.Width = 120
        jobCreatedTime.NullText = ""
        tbStyle.GridColumnStyles.Add(jobCreatedTime)

        Dim visitCreatedTime As New DataGridLabelColumn
        visitCreatedTime.Format = "dd/MMM/yyyy"
        visitCreatedTime.FormatInfo = Nothing
        visitCreatedTime.HeaderText = "Visit Created"
        visitCreatedTime.MappingName = "VisitCreatedDateTime"
        visitCreatedTime.ReadOnly = True
        visitCreatedTime.Width = 120
        visitCreatedTime.NullText = ""
        tbStyle.GridColumnStyles.Add(visitCreatedTime)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
        Me.dgVisits.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMVisitManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            theCustomer = DB.Customer.Customer_Get(ID)
            'RunFilter()
        End If
    End Sub

    Private Sub btnFindSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSite.Click
        Dim ID As Integer
        If theCustomer Is Nothing Then
            ID = FindRecord(Entity.Sys.Enums.TableNames.tblSite)
        Else
            ID = FindRecord(Entity.Sys.Enums.TableNames.tblSite, theCustomer.CustomerID)
        End If
        If Not ID = 0 Then
            theSite = DB.Sites.Get(ID)
            'RunFilter()
        End If
    End Sub

    Private Sub btnfindEngineer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfindEngineer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            theEngineer = DB.Engineer.Engineer_Get(ID)
            'RunFilter()
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub chkVisitDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVisitDate.CheckedChanged
        If Me.chkVisitDate.Checked Then
            Me.dtpFrom.Enabled = True
            Me.dtpTo.Enabled = True
        Else
            Me.dtpFrom.Value = Today
            Me.dtpTo.Value = Today
            Me.dtpFrom.Enabled = False
            Me.dtpTo.Enabled = False
        End If
        'RunFilter()
    End Sub

    Private Sub chkVisitEnd_CheckedChanged(sender As Object, e As EventArgs) Handles chkVisitEnd.CheckedChanged
        If Me.chkVisitEnd.Checked Then
            Me.dtpVisitEndFrom.Enabled = True
            Me.dtpVisitEndTo.Enabled = True
        Else
            Me.dtpVisitEndFrom.Value = Today
            Me.dtpVisitEndTo.Value = Today
            Me.dtpVisitEndFrom.Enabled = False
            Me.dtpVisitEndTo.Enabled = False
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub btnRequiringParts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequiringParts.Click
        ResetFilters()
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts))
        'RunFilter()
        PopulateDatagrid(True)
    End Sub

    Private Sub btnCreateOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateOrder.Click
        If SelectedVisitDataRow Is Nothing Then
            ShowMessage("Please select a visit to create an order for", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not SelectedVisitDataRow.Item("StatusEnumID") = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule) And Not SelectedVisitDataRow.Item("StatusEnumID") = CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts) Then
            ShowMessage("Only Visits that are waiting for parts or are ready for schedule are allowed to create orders", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim fOrders As FRMOrder = ShowForm(GetType(FRMOrder), False, New Object() {0, SelectedVisitDataRow().Item("EngineerVisitID"), CInt(Entity.Sys.Enums.OrderType.Job)})
    End Sub

    Private Sub dgVisits_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgVisits.DoubleClick
        If SelectedVisitDataRow Is Nothing Then
            ShowMessage("Please select a visit to view", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim [continue] As Boolean = False

        Select Case CInt(SelectedVisitDataRow.Item("StatusEnumID"))
            Case CInt(Entity.Sys.Enums.VisitStatus.NOT_SET)
                If ShowMessage("This visit has not entered a visit life span yet.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedVisitDataRow.Item("JobID"), SelectedVisitDataRow.Item("SiteID"), Me, Nothing, SelectedVisitDataRow("EngineerVisitID")})
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Parts_Need_Ordering)
                If ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedVisitDataRow.Item("JobID"), SelectedVisitDataRow.Item("SiteID"), Me, Nothing, SelectedVisitDataRow("EngineerVisitID")})
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts)
                If ShowMessage("This visit is waiting for parts, once recieved you may proceed.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedVisitDataRow.Item("JobID"), SelectedVisitDataRow.Item("SiteID"), Me, Nothing, SelectedVisitDataRow("EngineerVisitID")})
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
                If ShowMessage("This visit is ready for schedule, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    [continue] = True
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                If ShowMessage("This visit is scheduled, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    [continue] = True
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Downloaded)
                If ShowMessage("This visit is currently with an engineer, once returned you may view the details.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedVisitDataRow.Item("JobID"), SelectedVisitDataRow.Item("SiteID"), Me, Nothing, SelectedVisitDataRow("EngineerVisitID")})
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Uploaded)
                [continue] = True
            Case Entity.Sys.Enums.VisitStatus.Not_To_Be_Invoiced
                [continue] = True
            Case Entity.Sys.Enums.VisitStatus.Ready_To_Be_Invoiced
                [continue] = True
            Case Entity.Sys.Enums.VisitStatus.Invoiced
                [continue] = True
        End Select

        If [continue] Then
            ShowForm(GetType(FRMEngineerVisit), True, New Object() {SelectedVisitDataRow.Item("EngineerVisitID"), dtVisitFilters})
            updaterow()
            'PopulateDatagrid(True)
            'LoadLastFilters()

        End If
    End Sub

    Sub updaterow()
        Dim visit As DataView = DB.EngineerVisits.EngineerVisit_GetUpdate(SelectedVisitDataRow("EngineerVisitID"))
        VisitsDataview.AllowDelete = True

        SelectedVisitDataRow("VisitStatus") = visit.Table.Rows(0)("VisitStatus")
        SelectedVisitDataRow("StatusEnumID") = visit.Table.Rows(0)("StatusEnumID")
        SelectedVisitDataRow("InvoiceNotes") = visit.Table.Rows(0)("NotesFromEngineer")

        'If Not Combo.GetSelectedItemValue(Me.cboStatus) = 0 AndAlso Combo.GetSelectedItemValue(Me.cboStatus) <> SelectedVisitDataRow("StatusEnumID") Then
        '    VisitsDataview.Delete(Me.dgVisits.CurrentRowIndex)
        'End If
    End Sub

    Private Sub txtPostcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPostcode.TextChanged
        'RunFilter()
    End Sub

    Private Sub cboOutcome_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'RunFilter()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        PopulateDatagrid(True)
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid(ByVal withRun As Boolean)
        Try
            If GetParameter(0) Is Nothing Then
                If withRun Then
                    Dim whereClause As String = "(1 = 1 "
                    Dim addwhereClause As String = "(1 = 1 "
                    If Not theCustomer Is Nothing Then
                        whereClause += " AND tblCustomer.CustomerID = " & theCustomer.CustomerID & ""
                    End If
                    If Not theSite Is Nothing Then
                        whereClause += " AND tblSite.SiteID = " & theSite.SiteID & ""
                    End If
                    If Not theEngineer Is Nothing Then
                        whereClause += " AND tblEngineer.EngineerID = " & theEngineer.EngineerID & ""
                    End If
                    'If Not Combo.GetSelectedItemValue(Me.cboDefinition) = 0 Then
                    '    whereClause += " AND tblJob.JobDefinitionEnumID = " & Combo.GetSelectedItemValue(Me.cboDefinition) & ""
                    'End If
                    If Not Combo.GetSelectedItemValue(Me.cboType) = 0 Then
                        whereClause += " AND tblJob.JobTypeID = " & Combo.GetSelectedItemValue(Me.cboType) & ""
                    End If
                    If Not Combo.GetSelectedItemValue(Me.cboStatus) = 0 Then
                        whereClause += " AND @THEStatusEnumIDString = " & Combo.GetSelectedItemValue(Me.cboStatus) & ""
                    End If
                    If Not Combo.GetSelectedItemValue(Me.cboOutcome) = 0 Then
                        whereClause += " AND tblEngineerVisit.OutcomeEnumID = " & Combo.GetSelectedItemValue(Me.cboOutcome) & ""
                    End If
                    If loggedInUser.UserRegions.Count > 0 Then
                        If Not Combo.GetSelectedItemValue(Me.cboRegion) = 0 Then
                            whereClause += " AND tblsite.RegionID = " & Combo.GetSelectedItemValue(Me.cboRegion) & ""
                        Else
                            Dim regionString As String =
                                String.Join(",", loggedInUser.UserRegions.Table.AsEnumerable().[Select](Function(x) x.Field(Of Integer)("RegionID").ToString()).ToArray())

                            whereClause += " AND tblsite.RegionID in (" & regionString & ")"
                        End If
                    Else
                        If Not Combo.GetSelectedItemValue(Me.cboRegion) = 0 Then
                            whereClause += " AND tblsite.RegionID = " & Combo.GetSelectedItemValue(Me.cboRegion) & ""
                        End If
                    End If

                    If Not Combo.GetSelectedItemValue(Me.CboServExp) = 0 Then
                        whereClause += " AND DATEADD(year,1,tblsite.lastservicedate) < '" & Format(DateAndTime.Today.AddDays(Combo.GetSelectedItemValue(Me.CboServExp)), "yyyy-MM-dd") & "'"
                    End If

                    Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(cboDepartment))
                    If Helper.IsValidInteger(department) AndAlso Not Helper.MakeIntegerValid(department) <= 0 Then
                        whereClause += " AND tblEngineer.Department = '" & department & "'"
                    ElseIf Not IsNumeric(department) Then
                        whereClause += " AND tblEngineer.Department = '" & department & "'"
                    End If

                    If Not Combo.GetSelectedItemValue(Me.cboLetterNumber) = 0 Then
                        whereClause += " AND tblEngineerVisit.VisitNumber = " & Combo.GetSelectedItemValue(Me.cboLetterNumber)
                    End If

                    If Not Combo.GetSelectedItemValue(Me.cboPriority) = 0 Then
                        whereClause += " AND pris.managerid = " & Combo.GetSelectedItemValue(Me.cboPriority)
                    End If

                    If Not Combo.GetSelectedItemValue(Me.cboVisitCharge) = 0 Then
                        addwhereClause += " AND VisitChargeable = " & Combo.GetSelectedItemValue(Me.cboVisitCharge)
                    End If

                    If Not Me.txtJobNumber.Text.Trim.Length = 0 Then
                        whereClause += " AND tblJob.JobNumber LIKE '" & Me.txtJobNumber.Text.Trim & "%'"
                    End If
                    If Not Me.txtPONumber.Text.Trim.Length = 0 Then
                        whereClause += " AND tblJobOfWork.PONumber LIKE '" & Me.txtPONumber.Text.Trim & "%'"
                    End If
                    If Me.chkVisitDate.Checked Then
                        whereClause += " AND tblEngineerVisit.StartDateTime >= '" & Format(Me.dtpFrom.Value, "dd-MMM-yyyy 00:00:00") & "' AND tblEngineerVisit.StartDateTime <= '" & Format(Me.dtpTo.Value, "dd-MMM-yyyy 23:59:59") & "'"
                    End If
                    If Me.chkVisitEnd.Checked Then
                        whereClause += " AND tblEngineerVisit.EndDateTime >= '" & Format(Me.dtpVisitEndFrom.Value, "dd-MMM-yyyy 00:00:00") & "' AND tblEngineerVisit.EndDateTime <= '" & Format(Me.dtpVisitEndTo.Value, "dd-MMM-yyyy 23:59:59") & "'"
                    End If
                    If Me.chkServiceDate.Checked Then
                        whereClause += " AND tblContractOriginalPPMVisit.EstimatedVisitDate >= '" & Format(Me.dtpFromServiceDate.Value, "dd-MMM-yyyy 00:00:00") & "' AND tblContractOriginalPPMVisit.EstimatedVisitDate <= '" & Format(Me.dtpToServiceDate.Value, "dd-MMM-yyyy 23:59:59") & "'"
                    End If
                    If Me.chkftfcode.Checked Then
                        whereClause += " AND tblEngineerVisitQC.FTFCode IS NULL "
                    End If
                    If Me.chkRecharge.Checked Then
                        whereClause += " AND tblEngineerVisit.Recharge = 1 "
                    End If
                    If Not Me.txtPostcode.Text.Trim.Length = 0 Then
                        whereClause += " AND tblSite.Postcode LIKE '" & Me.txtPostcode.Text.Trim & "%'"
                    End If

                    If Not Combo.GetSelectedItemValue(Me.cboQualification) = 0 Then
                        whereClause += " AND tblJobOfWork.QualificationID = " & Combo.GetSelectedItemValue(Me.cboQualification)
                    End If

                    whereClause += ")"
                    addwhereClause += ")"

                    VisitsDataview = DB.EngineerVisits.EngineerVisits_Manager_Get_ByWhere(whereClause, addwhereClause)
                    count = VisitsDataview.Count
                    Me.grpEngineerVisits.Text = "Double Click To View / Edit (" + CStr(count) + ")"
                Else
                    VisitsDataview = Nothing
                End If
                'VisitsDataview = DB.EngineerVisits.EngineerVisits_Get_All()
                'RunFilter()
            Else
                VisitsDataview = GetParameter(0)
                Me.grpFilter.Enabled = False
            End If

            LogSearchCriteria()
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()

        theCustomer = Nothing
        theEngineer = Nothing
        Combo.SetSelectedComboItem_By_Value(Me.cboDefinition, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboType, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboOutcome, 0)
        Me.txtJobNumber.Text = ""
        Me.txtPONumber.Text = ""
        Me.txtPostcode.Text = ""
        Me.chkVisitDate.Checked = False
        Me.dtpFrom.Value = Today
        Me.dtpTo.Value = Today
        Me.dtpFrom.Enabled = False
        Me.dtpTo.Enabled = False
        Me.grpFilter.Enabled = True

    End Sub

    Public Sub Export()
        If VisitsDataview IsNot Nothing AndAlso VisitsDataview.Table.Rows.Count > 0 Then

            Dim exportData As New DataTable
            exportData.Columns.Add("Customer")
            exportData.Columns.Add("Site")
            exportData.Columns.Add("JobNumber")
            exportData.Columns.Add("PONumber")
            exportData.Columns.Add("VisitOutcome")
            exportData.Columns.Add("Type")
            exportData.Columns.Add("VisitStatus")
            exportData.Columns.Add("Engineer")
            exportData.Columns.Add("PolicyNumber")
            exportData.Columns.Add("Priority")
            exportData.Columns.Add("Department")
            exportData.Columns.Add("VisitNumber")
            exportData.Columns.Add("SiteContact")
            exportData.Columns.Add("FirstLine")
            exportData.Columns.Add("Area")
            exportData.Columns.Add("PostCode")
            exportData.Columns.Add("TelephoneNum")
            exportData.Columns.Add("MobileNum")
            exportData.Columns.Add("EmailAddress")
            exportData.Columns.Add("ServiceExpiryDate", GetType(Date))
            exportData.Columns.Add("SiteFuel")
            exportData.Columns.Add("StartDateTime", GetType(Date))
            exportData.Columns.Add("NotesToEngineer")
            exportData.Columns.Add("NotesFromEngineer")
            exportData.Columns.Add("InvoiceNotes")
            exportData.Columns.Add("JobCreatedDateTime", GetType(Date))
            exportData.Columns.Add("VisitCreatedDateTime", GetType(Date))

            For Each dr As DataRow In VisitsDataview.Table.Rows
                Dim newRw As DataRow
                newRw = exportData.NewRow

                newRw("Customer") = dr("Customer")
                newRw("Site") = dr("Site")
                newRw("JobNumber") = dr("JobNumber")
                newRw("PONumber") = dr("PONumber")
                newRw("VisitOutcome") = dr("VisitOutcome")
                newRw("Type") = dr("Type")
                newRw("VisitStatus") = dr("VisitStatus")
                newRw("Engineer") = dr("Engineer")
                newRw("PolicyNumber") = dr("PolicyNumber")
                newRw("Priority") = dr("Priority")
                newRw("Department") = dr("Department")
                newRw("VisitNumber") = dr("VisitNumber")
                newRw("SiteContact") = dr("SiteContact")
                newRw("FirstLine") = dr("FirstLine")
                newRw("Area") = dr("Area")
                newRw("PostCode") = dr("PostCode")
                newRw("TelephoneNum") = dr("TelephoneNum")
                newRw("MobileNum") = dr("MobileNum")
                newRw("EmailAddress") = dr("EmailAddress")
                newRw("ServiceExpiryDate") = dr("ServiceExpiryDate")
                newRw("SiteFuel") = dr("SiteFuel")
                newRw("StartDateTime") = dr("StartDateTime")
                newRw("NotesToEngineer") = dr("NotesToEngineer")
                newRw("NotesFromEngineer") = dr("OutcomeDetails")
                newRw("InvoiceNotes") = dr("InvoiceNotes")
                newRw("JobCreatedDateTime") = dr("JobCreatedDateTime")
                newRw("VisitCreatedDateTime") = dr("VisitCreatedDateTime")

                exportData.Rows.Add(newRw)
            Next

            Entity.Sys.ExportHelper.Export(exportData, "VisitManager", Entity.Sys.Enums.ExportType.XLS)
        Else
            ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

    End Sub

#End Region

    Private Sub cboOutcome_TextChanged(sender As Object, e As EventArgs) Handles cboOutcome.TextChanged
        If cboOutcome.Text().ToString = "Further Works" Then
            chkftfcode.Visible = True
        Else
            chkftfcode.CheckState = CheckState.Unchecked
            chkftfcode.Visible = True
        End If
    End Sub

    Private Sub cboOutcome_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboOutcome.SelectedIndexChanged
        If cboOutcome.Text().ToString = "Further Works" Then
            chkftfcode.Visible = True
        Else
            chkftfcode.CheckState = CheckState.Unchecked
            chkftfcode.Visible = False
        End If
    End Sub

    Private Sub LogSearchCriteria()

        dtVisitFilters.Rows.Clear()
        Dim dt As DataTable = dtVisitFilters
        Dim dr As DataRow

        dr = dt.NewRow
        dr("Field") = "theCustomer"
        If theCustomer Is Nothing Then
            dr("Value") = 0
        Else
            dr("Value") = theCustomer.CustomerID
        End If
        dr("Type") = "Object"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "theSite"
        If theSite Is Nothing Then
            dr("Value") = 0
        Else
            dr("Value") = theSite.SiteID
        End If

        dr("Type") = "Object"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "theEngineer"
        If theEngineer Is Nothing Then
            dr("Value") = 0
        Else
            dr("Value") = theEngineer.EngineerID
        End If

        dr("Type") = "Object"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "cboType"
        dr("Value") = Combo.GetSelectedItemValue(cboType)
        dr("Type") = "Combo"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "cboStatus"
        dr("Value") = Combo.GetSelectedItemValue(cboStatus)
        dr("Type") = "Combo"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "cboOutcome"
        dr("Value") = Combo.GetSelectedItemValue(cboOutcome)
        dr("Type") = "Combo"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "txtJobNumber"
        dr("Value") = txtJobNumber.Text
        dr("Type") = "Text"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "txtPONumber"
        dr("Value") = txtPONumber.Text
        dr("Type") = "Text"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "txtPostcode"
        dr("Value") = txtPostcode.Text
        dr("Type") = "Text"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "chkVisitDate"
        dr("Value") = chkVisitDate.Checked
        dr("Type") = "CHECK"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "dtpFrom"
        dr("Value") = dtpFrom.Value
        dr("Type") = "DTP"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "dtpTo"
        dr("Value") = dtpTo.Value
        dr("Type") = "DTP"
        dt.Rows.Add(dr)

    End Sub

    Private Sub LoadLastFilters()
        If Controls.Count > 0 Then

            If dtVisitFilters.Rows.Count > 0 Then
                For Each dr As DataRow In dtVisitFilters.Rows
                    Select Case dr("Type").ToString()
                        Case "Object"
                            Select Case dr("Field").ToString()
                                Case "theCustomer"
                                    Dim cust As Entity.Customers.Customer = DB.Customer.Customer_Get(dr("Value"))
                                    If Not cust Is Nothing Then
                                        theCustomer = cust
                                    End If

                                Case "theSite"
                                    Dim s As Entity.Sites.Site = DB.Sites.Get(dr("Value"))
                                    If Not s Is Nothing Then
                                        theSite = s
                                    End If

                                Case "theEngineer"
                                    Dim eng As Entity.Engineers.Engineer = DB.Engineer.Engineer_Get(dr("Value"))
                                    If Not eng Is Nothing Then
                                        theEngineer = eng
                                    End If

                            End Select
                        Case "Combo"
                            Combo.SetSelectedComboItem_By_Value(Controls.Find(dr("Field"), True)(0), dr("Value"))
                        Case "Text"
                            CType(Controls.Find(dr("Field"), True)(0), TextBox).Text = dr("Value")
                        Case "Radio"
                            CType(Controls.Find(dr("Field"), True)(0), RadioButton).Checked = dr("Value")
                        Case "DTP"
                            CType(Controls.Find(dr("Field"), True)(0), DateTimePicker).Value = dr("Value")
                        Case "CHECK"
                            CType(Controls.Find(dr("Field"), True)(0), CheckBox).Checked = dr("Value")
                    End Select
                Next
                PopulateDatagrid(True)
            End If

        End If
    End Sub

    Private Sub txtJobNumber_TextChanged(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtJobNumber.KeyDown, txtPostcode.KeyDown, txtPONumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            PopulateDatagrid(True)
        End If
    End Sub

End Class