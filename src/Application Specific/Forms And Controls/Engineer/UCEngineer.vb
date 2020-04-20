Imports System.Linq
Imports System.Reflection
Imports FSM.Entity.Engineers
Imports FSM.Entity.Engineers.SiteSafetyAudits
Imports FSM.Entity.Sys
Imports Newtonsoft.Json.Linq

Public Class UCEngineer : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        TabControl1.TabPages.Clear()
        TabControl1.TabPages.Add(tpMain)
        TabControl1.TabPages.Add(tpPostalRegions)
        TabControl1.TabPages.Add(tpMaxTimes)
        TabControl1.TabPages.Add(tpTrainingQualifications)
        ''TabControl1.TabPages.Add(tpWages)
        TabControl1.TabPages.Add(tpHolidayAbsences)
        TabControl1.TabPages.Add(tpDisciplinary)
        TabControl1.TabPages.Add(tpKit)
        TabControl1.TabPages.Add(tpDocuments)
        TabControl1.TabPages.Add(tpSiteSafetyAudits)

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboRegionID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboEngineerGroup, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.EngineerGroup).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        ''Combo.SetUpCombo(Me.cboPayGrade, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PayGrades).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboDisciplinary, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.DisciplinaryStatus).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQualificationType, DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpComboQual(cboQualification, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboUser, DB.User.GetAll().Table, "UserID", "FullName", Entity.Sys.Enums.ComboValues.Not_Applicable)
        Combo.SetUpCombo(Me.cboRagRating, DB.RagRating.Get_All().Table, "Id", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboLinkToUser, DB.User.GetAll().Table, "UserID", "FullName", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboEngineerRoleId, DB.EngineerRole.GetLookupData.Table, "Id", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents grpEngineer As System.Windows.Forms.GroupBox

    Friend WithEvents txtEngineerID As System.Windows.Forms.TextBox
    Friend WithEvents cboRegionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegionID As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtTelephoneNum As System.Windows.Forms.TextBox
    Friend WithEvents lblTelephoneNum As System.Windows.Forms.Label
    Friend WithEvents lblEngineerID As System.Windows.Forms.Label
    Friend WithEvents chkApprentice As System.Windows.Forms.CheckBox
    Friend WithEvents btnVanHistory As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents tpDisciplinary As System.Windows.Forms.TabPage
    Friend WithEvents tpTrainingQualifications As System.Windows.Forms.TabPage
    Friend WithEvents tpHolidayAbsences As System.Windows.Forms.TabPage
    Friend WithEvents tpDocuments As System.Windows.Forms.TabPage
    Friend WithEvents txtNextOfKinName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNextOfKinContact As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tpPostalRegions As System.Windows.Forms.TabPage
    Friend WithEvents grpPostalRegions As System.Windows.Forms.GroupBox
    Friend WithEvents dgPostalRegions As System.Windows.Forms.DataGrid
    Friend WithEvents tpKit As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dtpDrivingLicenceIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDrivingLicenceNo As System.Windows.Forms.TextBox
    Friend WithEvents txtStartingDetails As System.Windows.Forms.TextBox
    Friend WithEvents txtDaysHolidayAllowed As System.Windows.Forms.TextBox
    Friend WithEvents txtHolidayYearEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtHolidayYearStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpQualificationExpires As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpQualificationPassed As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboDisciplinary As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDisciplinaryIssued As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDisciplinary As System.Windows.Forms.TextBox
    Friend WithEvents txtEquipmentTool As System.Windows.Forms.TextBox
    Friend WithEvents dgTrainingQualifications As System.Windows.Forms.DataGrid
    Friend WithEvents btnRemoveTrainingQualifications As System.Windows.Forms.Button
    Friend WithEvents btnSaveQualification As System.Windows.Forms.Button
    Friend WithEvents btnSaveEquipment As System.Windows.Forms.Button
    Friend WithEvents dgEquipment As System.Windows.Forms.DataGrid
    Friend WithEvents btnRemoveEngineerEquipment As System.Windows.Forms.Button
    Friend WithEvents pnlDocuments As System.Windows.Forms.Panel
    Friend WithEvents dgDisciplinaries As System.Windows.Forms.DataGrid
    Friend WithEvents btnSaveDisciplinaries As System.Windows.Forms.Button
    Friend WithEvents txtDisciplinaryID As System.Windows.Forms.TextBox
    Friend WithEvents btnEditDisciplinaries As System.Windows.Forms.Button
    Friend WithEvents btnRemoveDisciplinaries As System.Windows.Forms.Button
    Friend WithEvents btnAddDisciplinaries As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboQualification As System.Windows.Forms.ComboBox
    Friend WithEvents txtQualificatioNote As System.Windows.Forms.TextBox
    Friend WithEvents dgAbsences As System.Windows.Forms.DataGrid
    Friend WithEvents cboEngineerGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtGasSafeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtTechnician As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents tpMaxTimes As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtSundayValue As System.Windows.Forms.TextBox
    Friend WithEvents txtSaturdayValue As System.Windows.Forms.TextBox
    Friend WithEvents txtFridayValue As System.Windows.Forms.TextBox
    Friend WithEvents txtThursdayValue As System.Windows.Forms.TextBox
    Friend WithEvents txtWednesdayValue As System.Windows.Forms.TextBox
    Friend WithEvents txtTuesdayValue As System.Windows.Forms.TextBox
    Friend WithEvents txtMondayValue As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxtOftec As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cbxShowOnJob As System.Windows.Forms.CheckBox
    Friend WithEvents dtpQualificationBooked As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtPCSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dgUnTicked As System.Windows.Forms.DataGrid
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtBreakPri As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtServPri As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtDailyServiceLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents cboUser As System.Windows.Forms.ComboBox
    Friend WithEvents cboQualificationType As ComboBox
    Friend WithEvents lblQualificationType As Label
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents txtWebAppPassword As TextBox
    Friend WithEvents lbllWebAppPassword As Label
    Friend WithEvents cboRagRating As ComboBox
    Friend WithEvents lblRagDate As Label
    Friend WithEvents lblRagRating As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents dtpRagDate As DateTimePicker
    Friend WithEvents tpSiteSafetyAudits As TabPage
    Friend WithEvents grpSiteSafetyAudits As GroupBox
    Friend WithEvents grpSiteSafetyAudit As GroupBox
    Friend WithEvents btnSaveAudit As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgSiteSafetyAudits As DataGrid
    Friend WithEvents btnNewAudit As Button
    Friend WithEvents dtpAuditDate As DateTimePicker
    Friend WithEvents lblAuditDate As Label
    Friend WithEvents txtVehicleSafetyCondition As TextBox
    Friend WithEvents lblVehicleCheck As Label
    Friend WithEvents lblLine As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents txtAsbestos As TextBox
    Friend WithEvents lblAsbestos As Label
    Friend WithEvents txtCOSSH As TextBox
    Friend WithEvents lblCOSSH As Label
    Friend WithEvents txtFirstAidWelfare As TextBox
    Friend WithEvents lblFirstAidWelfare As Label
    Friend WithEvents txtWorkingAtHeight As TextBox
    Friend WithEvents lblWorkingAtHeight As Label
    Friend WithEvents txtManualHandling As TextBox
    Friend WithEvents lblManualHandling As Label
    Friend WithEvents txtMachineryEquipment As TextBox
    Friend WithEvents lblMachineryEquipment As Label
    Friend WithEvents txtHousekeeping As TextBox
    Friend WithEvents lblHousekeeping As Label
    Friend WithEvents txtEnvironmentalConditions As TextBox
    Friend WithEvents lblEnvironmentalConditions As Label
    Friend WithEvents txtUniformPPE As TextBox
    Friend WithEvents lblUniformPPE As Label
    Friend WithEvents txtDocumentProcedures As TextBox
    Friend WithEvents lblDocumentationProcedures As Label
    Friend WithEvents btnDeleteAudit As Button
    Friend WithEvents lblAuditor As Label
    Friend WithEvents btnfindEngineer As Button
    Friend WithEvents txtAuditor As TextBox
    Friend WithEvents txtVisitSpendLimit As TextBox
    Friend WithEvents lblVisitSpendLimit As Label
    Friend WithEvents lblSiteSafetyAuditInfo As Label
    Friend WithEvents cboLinkToUser As ComboBox
    Friend WithEvents lblLinkToUser As Label
    Friend WithEvents lblAssignEngineerRole As Label
    Friend WithEvents cboEngineerRoleId As ComboBox
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents lblEmailAddress As Label
    Friend WithEvents grpAbsences As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.grpEngineer = New System.Windows.Forms.GroupBox()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.lblAssignEngineerRole = New System.Windows.Forms.Label()
        Me.cboEngineerRoleId = New System.Windows.Forms.ComboBox()
        Me.txtVisitSpendLimit = New System.Windows.Forms.TextBox()
        Me.lblVisitSpendLimit = New System.Windows.Forms.Label()
        Me.cboLinkToUser = New System.Windows.Forms.ComboBox()
        Me.lblLinkToUser = New System.Windows.Forms.Label()
        Me.dtpRagDate = New System.Windows.Forms.DateTimePicker()
        Me.cboRagRating = New System.Windows.Forms.ComboBox()
        Me.lblRagDate = New System.Windows.Forms.Label()
        Me.lblRagRating = New System.Windows.Forms.Label()
        Me.txtWebAppPassword = New System.Windows.Forms.TextBox()
        Me.lbllWebAppPassword = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.txtBreakPri = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtServPri = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TxtOftec = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtTechnician = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboEngineerGroup = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtGasSafeNo = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dtpDrivingLicenceIssueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDrivingLicenceNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtStartingDetails = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNextOfKinContact = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNextOfKinName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnVanHistory = New System.Windows.Forms.Button()
        Me.txtEngineerID = New System.Windows.Forms.TextBox()
        Me.cboRegionID = New System.Windows.Forms.ComboBox()
        Me.lblRegionID = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtTelephoneNum = New System.Windows.Forms.TextBox()
        Me.lblTelephoneNum = New System.Windows.Forms.Label()
        Me.lblEngineerID = New System.Windows.Forms.Label()
        Me.chkApprentice = New System.Windows.Forms.CheckBox()
        Me.tpMaxTimes = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDailyServiceLimit = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtSundayValue = New System.Windows.Forms.TextBox()
        Me.txtSaturdayValue = New System.Windows.Forms.TextBox()
        Me.txtFridayValue = New System.Windows.Forms.TextBox()
        Me.txtThursdayValue = New System.Windows.Forms.TextBox()
        Me.txtWednesdayValue = New System.Windows.Forms.TextBox()
        Me.txtTuesdayValue = New System.Windows.Forms.TextBox()
        Me.txtMondayValue = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tpTrainingQualifications = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboQualificationType = New System.Windows.Forms.ComboBox()
        Me.lblQualificationType = New System.Windows.Forms.Label()
        Me.dtpQualificationBooked = New System.Windows.Forms.DateTimePicker()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cbxShowOnJob = New System.Windows.Forms.CheckBox()
        Me.cboQualification = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtQualificatioNote = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnSaveQualification = New System.Windows.Forms.Button()
        Me.dtpQualificationExpires = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpQualificationPassed = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnRemoveTrainingQualifications = New System.Windows.Forms.Button()
        Me.dgTrainingQualifications = New System.Windows.Forms.DataGrid()
        Me.tpKit = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtEquipmentTool = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSaveEquipment = New System.Windows.Forms.Button()
        Me.btnRemoveEngineerEquipment = New System.Windows.Forms.Button()
        Me.dgEquipment = New System.Windows.Forms.DataGrid()
        Me.tpDisciplinary = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnAddDisciplinaries = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtDisciplinaryID = New System.Windows.Forms.TextBox()
        Me.cboDisciplinary = New System.Windows.Forms.ComboBox()
        Me.btnSaveDisciplinaries = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpDisciplinaryIssued = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDisciplinary = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnRemoveDisciplinaries = New System.Windows.Forms.Button()
        Me.btnEditDisciplinaries = New System.Windows.Forms.Button()
        Me.dgDisciplinaries = New System.Windows.Forms.DataGrid()
        Me.tpDocuments = New System.Windows.Forms.TabPage()
        Me.pnlDocuments = New System.Windows.Forms.Panel()
        Me.tpHolidayAbsences = New System.Windows.Forms.TabPage()
        Me.grpAbsences = New System.Windows.Forms.GroupBox()
        Me.dgAbsences = New System.Windows.Forms.DataGrid()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtDaysHolidayAllowed = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtHolidayYearEnd = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtHolidayYearStart = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tpPostalRegions = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.grpPostalRegions = New System.Windows.Forms.GroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtPCSearch = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dgUnTicked = New System.Windows.Forms.DataGrid()
        Me.dgPostalRegions = New System.Windows.Forms.DataGrid()
        Me.tpSiteSafetyAudits = New System.Windows.Forms.TabPage()
        Me.grpSiteSafetyAudits = New System.Windows.Forms.GroupBox()
        Me.dgSiteSafetyAudits = New System.Windows.Forms.DataGrid()
        Me.grpSiteSafetyAudit = New System.Windows.Forms.GroupBox()
        Me.lblSiteSafetyAuditInfo = New System.Windows.Forms.Label()
        Me.btnfindEngineer = New System.Windows.Forms.Button()
        Me.txtAuditor = New System.Windows.Forms.TextBox()
        Me.lblAuditor = New System.Windows.Forms.Label()
        Me.btnDeleteAudit = New System.Windows.Forms.Button()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtAsbestos = New System.Windows.Forms.TextBox()
        Me.lblAsbestos = New System.Windows.Forms.Label()
        Me.txtCOSSH = New System.Windows.Forms.TextBox()
        Me.lblCOSSH = New System.Windows.Forms.Label()
        Me.txtFirstAidWelfare = New System.Windows.Forms.TextBox()
        Me.lblFirstAidWelfare = New System.Windows.Forms.Label()
        Me.txtWorkingAtHeight = New System.Windows.Forms.TextBox()
        Me.lblWorkingAtHeight = New System.Windows.Forms.Label()
        Me.txtManualHandling = New System.Windows.Forms.TextBox()
        Me.lblManualHandling = New System.Windows.Forms.Label()
        Me.txtMachineryEquipment = New System.Windows.Forms.TextBox()
        Me.lblMachineryEquipment = New System.Windows.Forms.Label()
        Me.txtHousekeeping = New System.Windows.Forms.TextBox()
        Me.lblHousekeeping = New System.Windows.Forms.Label()
        Me.txtEnvironmentalConditions = New System.Windows.Forms.TextBox()
        Me.lblEnvironmentalConditions = New System.Windows.Forms.Label()
        Me.txtUniformPPE = New System.Windows.Forms.TextBox()
        Me.lblUniformPPE = New System.Windows.Forms.Label()
        Me.txtDocumentProcedures = New System.Windows.Forms.TextBox()
        Me.lblDocumentationProcedures = New System.Windows.Forms.Label()
        Me.txtVehicleSafetyCondition = New System.Windows.Forms.TextBox()
        Me.lblVehicleCheck = New System.Windows.Forms.Label()
        Me.dtpAuditDate = New System.Windows.Forms.DateTimePicker()
        Me.lblAuditDate = New System.Windows.Forms.Label()
        Me.btnNewAudit = New System.Windows.Forms.Button()
        Me.btnSaveAudit = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.grpEngineer.SuspendLayout()
        Me.tpMaxTimes.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tpTrainingQualifications.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgTrainingQualifications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpKit.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDisciplinary.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgDisciplinaries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDocuments.SuspendLayout()
        Me.tpHolidayAbsences.SuspendLayout()
        Me.grpAbsences.SuspendLayout()
        CType(Me.dgAbsences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.tpPostalRegions.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.grpPostalRegions.SuspendLayout()
        CType(Me.dgUnTicked, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPostalRegions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSiteSafetyAudits.SuspendLayout()
        Me.grpSiteSafetyAudits.SuspendLayout()
        CType(Me.dgSiteSafetyAudits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSiteSafetyAudit.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpMain)
        Me.TabControl1.Controls.Add(Me.tpMaxTimes)
        Me.TabControl1.Controls.Add(Me.tpTrainingQualifications)
        Me.TabControl1.Controls.Add(Me.tpKit)
        Me.TabControl1.Controls.Add(Me.tpDisciplinary)
        Me.TabControl1.Controls.Add(Me.tpDocuments)
        Me.TabControl1.Controls.Add(Me.tpHolidayAbsences)
        Me.TabControl1.Controls.Add(Me.tpPostalRegions)
        Me.TabControl1.Controls.Add(Me.tpSiteSafetyAudits)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(512, 663)
        Me.TabControl1.TabIndex = 1
        '
        'tpMain
        '
        Me.tpMain.Controls.Add(Me.grpEngineer)
        Me.tpMain.Location = New System.Drawing.Point(4, 22)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Size = New System.Drawing.Size(504, 637)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'grpEngineer
        '
        Me.grpEngineer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineer.Controls.Add(Me.txtEmailAddress)
        Me.grpEngineer.Controls.Add(Me.lblEmailAddress)
        Me.grpEngineer.Controls.Add(Me.lblAssignEngineerRole)
        Me.grpEngineer.Controls.Add(Me.cboEngineerRoleId)
        Me.grpEngineer.Controls.Add(Me.txtVisitSpendLimit)
        Me.grpEngineer.Controls.Add(Me.lblVisitSpendLimit)
        Me.grpEngineer.Controls.Add(Me.cboLinkToUser)
        Me.grpEngineer.Controls.Add(Me.lblLinkToUser)
        Me.grpEngineer.Controls.Add(Me.dtpRagDate)
        Me.grpEngineer.Controls.Add(Me.cboRagRating)
        Me.grpEngineer.Controls.Add(Me.lblRagDate)
        Me.grpEngineer.Controls.Add(Me.lblRagRating)
        Me.grpEngineer.Controls.Add(Me.txtWebAppPassword)
        Me.grpEngineer.Controls.Add(Me.lbllWebAppPassword)
        Me.grpEngineer.Controls.Add(Me.cboDepartment)
        Me.grpEngineer.Controls.Add(Me.cboUser)
        Me.grpEngineer.Controls.Add(Me.txtBreakPri)
        Me.grpEngineer.Controls.Add(Me.Label40)
        Me.grpEngineer.Controls.Add(Me.txtServPri)
        Me.grpEngineer.Controls.Add(Me.Label39)
        Me.grpEngineer.Controls.Add(Me.TxtOftec)
        Me.grpEngineer.Controls.Add(Me.Label35)
        Me.grpEngineer.Controls.Add(Me.Label34)
        Me.grpEngineer.Controls.Add(Me.Label26)
        Me.grpEngineer.Controls.Add(Me.txtTechnician)
        Me.grpEngineer.Controls.Add(Me.Label25)
        Me.grpEngineer.Controls.Add(Me.cboEngineerGroup)
        Me.grpEngineer.Controls.Add(Me.Label24)
        Me.grpEngineer.Controls.Add(Me.txtGasSafeNo)
        Me.grpEngineer.Controls.Add(Me.Label23)
        Me.grpEngineer.Controls.Add(Me.dtpDrivingLicenceIssueDate)
        Me.grpEngineer.Controls.Add(Me.Label9)
        Me.grpEngineer.Controls.Add(Me.txtDrivingLicenceNo)
        Me.grpEngineer.Controls.Add(Me.Label8)
        Me.grpEngineer.Controls.Add(Me.txtStartingDetails)
        Me.grpEngineer.Controls.Add(Me.Label7)
        Me.grpEngineer.Controls.Add(Me.txtNextOfKinContact)
        Me.grpEngineer.Controls.Add(Me.Label6)
        Me.grpEngineer.Controls.Add(Me.txtNextOfKinName)
        Me.grpEngineer.Controls.Add(Me.Label5)
        Me.grpEngineer.Controls.Add(Me.btnVanHistory)
        Me.grpEngineer.Controls.Add(Me.txtEngineerID)
        Me.grpEngineer.Controls.Add(Me.cboRegionID)
        Me.grpEngineer.Controls.Add(Me.lblRegionID)
        Me.grpEngineer.Controls.Add(Me.txtName)
        Me.grpEngineer.Controls.Add(Me.lblName)
        Me.grpEngineer.Controls.Add(Me.txtTelephoneNum)
        Me.grpEngineer.Controls.Add(Me.lblTelephoneNum)
        Me.grpEngineer.Controls.Add(Me.lblEngineerID)
        Me.grpEngineer.Controls.Add(Me.chkApprentice)
        Me.grpEngineer.Location = New System.Drawing.Point(8, 0)
        Me.grpEngineer.Name = "grpEngineer"
        Me.grpEngineer.Size = New System.Drawing.Size(488, 631)
        Me.grpEngineer.TabIndex = 0
        Me.grpEngineer.TabStop = False
        Me.grpEngineer.Text = "Details"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(120, 277)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(359, 21)
        Me.txtEmailAddress.TabIndex = 83
        Me.txtEmailAddress.Tag = ""
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(4, 280)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(104, 20)
        Me.lblEmailAddress.TabIndex = 84
        Me.lblEmailAddress.Text = "Email Address"
        '
        'lblAssignEngineerRole
        '
        Me.lblAssignEngineerRole.AutoSize = True
        Me.lblAssignEngineerRole.Location = New System.Drawing.Point(4, 573)
        Me.lblAssignEngineerRole.Name = "lblAssignEngineerRole"
        Me.lblAssignEngineerRole.Size = New System.Drawing.Size(73, 13)
        Me.lblAssignEngineerRole.TabIndex = 82
        Me.lblAssignEngineerRole.Text = "Assign Role"
        '
        'cboEngineerRoleId
        '
        Me.cboEngineerRoleId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEngineerRoleId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEngineerRoleId.FormattingEnabled = True
        Me.cboEngineerRoleId.Location = New System.Drawing.Point(117, 566)
        Me.cboEngineerRoleId.Name = "cboEngineerRoleId"
        Me.cboEngineerRoleId.Size = New System.Drawing.Size(362, 21)
        Me.cboEngineerRoleId.TabIndex = 81
        '
        'txtVisitSpendLimit
        '
        Me.txtVisitSpendLimit.Location = New System.Drawing.Point(120, 539)
        Me.txtVisitSpendLimit.Name = "txtVisitSpendLimit"
        Me.txtVisitSpendLimit.Size = New System.Drawing.Size(64, 21)
        Me.txtVisitSpendLimit.TabIndex = 80
        '
        'lblVisitSpendLimit
        '
        Me.lblVisitSpendLimit.AutoSize = True
        Me.lblVisitSpendLimit.Location = New System.Drawing.Point(4, 542)
        Me.lblVisitSpendLimit.Name = "lblVisitSpendLimit"
        Me.lblVisitSpendLimit.Size = New System.Drawing.Size(113, 13)
        Me.lblVisitSpendLimit.TabIndex = 79
        Me.lblVisitSpendLimit.Text = "Visit Spend Limit £"
        '
        'cboLinkToUser
        '
        Me.cboLinkToUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLinkToUser.FormattingEnabled = True
        Me.cboLinkToUser.Location = New System.Drawing.Point(120, 512)
        Me.cboLinkToUser.Name = "cboLinkToUser"
        Me.cboLinkToUser.Size = New System.Drawing.Size(359, 21)
        Me.cboLinkToUser.TabIndex = 69
        '
        'lblLinkToUser
        '
        Me.lblLinkToUser.AutoSize = True
        Me.lblLinkToUser.Location = New System.Drawing.Point(4, 521)
        Me.lblLinkToUser.Name = "lblLinkToUser"
        Me.lblLinkToUser.Size = New System.Drawing.Size(77, 13)
        Me.lblLinkToUser.TabIndex = 68
        Me.lblLinkToUser.Text = "Link To User"
        '
        'dtpRagDate
        '
        Me.dtpRagDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpRagDate.Location = New System.Drawing.Point(341, 481)
        Me.dtpRagDate.Name = "dtpRagDate"
        Me.dtpRagDate.Size = New System.Drawing.Size(138, 21)
        Me.dtpRagDate.TabIndex = 67
        Me.dtpRagDate.Tag = "Van.InsuranceDue"
        '
        'cboRagRating
        '
        Me.cboRagRating.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRagRating.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRagRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRagRating.Location = New System.Drawing.Point(120, 481)
        Me.cboRagRating.Name = "cboRagRating"
        Me.cboRagRating.Size = New System.Drawing.Size(112, 21)
        Me.cboRagRating.TabIndex = 66
        Me.cboRagRating.Tag = ""
        '
        'lblRagDate
        '
        Me.lblRagDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRagDate.Location = New System.Drawing.Point(245, 484)
        Me.lblRagDate.Name = "lblRagDate"
        Me.lblRagDate.Size = New System.Drawing.Size(68, 20)
        Me.lblRagDate.TabIndex = 65
        Me.lblRagDate.Text = "Rag Date"
        '
        'lblRagRating
        '
        Me.lblRagRating.Location = New System.Drawing.Point(4, 480)
        Me.lblRagRating.Name = "lblRagRating"
        Me.lblRagRating.Size = New System.Drawing.Size(112, 20)
        Me.lblRagRating.TabIndex = 64
        Me.lblRagRating.Text = "Rag Rating"
        '
        'txtWebAppPassword
        '
        Me.txtWebAppPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWebAppPassword.Location = New System.Drawing.Point(120, 449)
        Me.txtWebAppPassword.Name = "txtWebAppPassword"
        Me.txtWebAppPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtWebAppPassword.Size = New System.Drawing.Size(359, 21)
        Me.txtWebAppPassword.TabIndex = 60
        Me.txtWebAppPassword.Tag = "Engineer.TelephoneNum"
        Me.txtWebAppPassword.UseSystemPasswordChar = True
        '
        'lbllWebAppPassword
        '
        Me.lbllWebAppPassword.Location = New System.Drawing.Point(4, 452)
        Me.lbllWebAppPassword.Name = "lbllWebAppPassword"
        Me.lbllWebAppPassword.Size = New System.Drawing.Size(114, 20)
        Me.lbllWebAppPassword.TabIndex = 61
        Me.lbllWebAppPassword.Text = "WebApp Password"
        '
        'cboDepartment
        '
        Me.cboDepartment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDepartment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Location = New System.Drawing.Point(120, 151)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(359, 21)
        Me.cboDepartment.TabIndex = 59
        Me.cboDepartment.Tag = ""
        '
        'cboUser
        '
        Me.cboUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.Location = New System.Drawing.Point(120, 202)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(359, 21)
        Me.cboUser.TabIndex = 58
        Me.cboUser.Tag = ""
        '
        'txtBreakPri
        '
        Me.txtBreakPri.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBreakPri.Location = New System.Drawing.Point(292, 605)
        Me.txtBreakPri.Name = "txtBreakPri"
        Me.txtBreakPri.Size = New System.Drawing.Size(41, 21)
        Me.txtBreakPri.TabIndex = 57
        Me.txtBreakPri.Text = "1"
        '
        'Label40
        '
        Me.Label40.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label40.Location = New System.Drawing.Point(186, 597)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(95, 29)
        Me.Label40.TabIndex = 56
        Me.Label40.Text = "Breakdown Priority (1-10)"
        '
        'txtServPri
        '
        Me.txtServPri.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtServPri.Location = New System.Drawing.Point(117, 605)
        Me.txtServPri.Name = "txtServPri"
        Me.txtServPri.Size = New System.Drawing.Size(41, 21)
        Me.txtServPri.TabIndex = 55
        Me.txtServPri.Text = "1"
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label39.Location = New System.Drawing.Point(5, 597)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(112, 29)
        Me.Label39.TabIndex = 54
        Me.Label39.Text = "Service Priority (1-10)"
        '
        'TxtOftec
        '
        Me.TxtOftec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOftec.Location = New System.Drawing.Point(120, 97)
        Me.TxtOftec.Name = "TxtOftec"
        Me.TxtOftec.Size = New System.Drawing.Size(359, 21)
        Me.TxtOftec.TabIndex = 52
        Me.TxtOftec.Tag = "Engineer.Name"
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(4, 97)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(104, 20)
        Me.Label35.TabIndex = 53
        Me.Label35.Text = "Oftec No."
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(4, 151)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(104, 20)
        Me.Label34.TabIndex = 51
        Me.Label34.Text = "Department"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(4, 205)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(104, 20)
        Me.Label26.TabIndex = 49
        Me.Label26.Text = "Manager"
        '
        'txtTechnician
        '
        Me.txtTechnician.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTechnician.Location = New System.Drawing.Point(120, 178)
        Me.txtTechnician.Name = "txtTechnician"
        Me.txtTechnician.Size = New System.Drawing.Size(359, 21)
        Me.txtTechnician.TabIndex = 5
        Me.txtTechnician.Tag = ""
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(4, 181)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 20)
        Me.Label25.TabIndex = 47
        Me.Label25.Text = "Technician"
        '
        'cboEngineerGroup
        '
        Me.cboEngineerGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEngineerGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboEngineerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEngineerGroup.Location = New System.Drawing.Point(120, 124)
        Me.cboEngineerGroup.Name = "cboEngineerGroup"
        Me.cboEngineerGroup.Size = New System.Drawing.Size(359, 21)
        Me.cboEngineerGroup.TabIndex = 4
        Me.cboEngineerGroup.Tag = ""
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(4, 126)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(105, 20)
        Me.Label24.TabIndex = 45
        Me.Label24.Text = "Engineer Group"
        '
        'txtGasSafeNo
        '
        Me.txtGasSafeNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGasSafeNo.Location = New System.Drawing.Point(120, 72)
        Me.txtGasSafeNo.Name = "txtGasSafeNo"
        Me.txtGasSafeNo.Size = New System.Drawing.Size(359, 21)
        Me.txtGasSafeNo.TabIndex = 3
        Me.txtGasSafeNo.Tag = "Engineer.Name"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(4, 72)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(104, 20)
        Me.Label23.TabIndex = 43
        Me.Label23.Text = "Gas Safe No."
        '
        'dtpDrivingLicenceIssueDate
        '
        Me.dtpDrivingLicenceIssueDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDrivingLicenceIssueDate.Checked = False
        Me.dtpDrivingLicenceIssueDate.Location = New System.Drawing.Point(319, 347)
        Me.dtpDrivingLicenceIssueDate.Name = "dtpDrivingLicenceIssueDate"
        Me.dtpDrivingLicenceIssueDate.ShowCheckBox = True
        Me.dtpDrivingLicenceIssueDate.Size = New System.Drawing.Size(160, 21)
        Me.dtpDrivingLicenceIssueDate.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(240, 352)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Issued Date"
        '
        'txtDrivingLicenceNo
        '
        Me.txtDrivingLicenceNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDrivingLicenceNo.Location = New System.Drawing.Point(120, 348)
        Me.txtDrivingLicenceNo.Name = "txtDrivingLicenceNo"
        Me.txtDrivingLicenceNo.Size = New System.Drawing.Size(112, 21)
        Me.txtDrivingLicenceNo.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(4, 347)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Driving Licence No"
        '
        'txtStartingDetails
        '
        Me.txtStartingDetails.AcceptsReturn = True
        Me.txtStartingDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStartingDetails.Location = New System.Drawing.Point(120, 312)
        Me.txtStartingDetails.Multiline = True
        Me.txtStartingDetails.Name = "txtStartingDetails"
        Me.txtStartingDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStartingDetails.Size = New System.Drawing.Size(359, 32)
        Me.txtStartingDetails.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(4, 315)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Starting Details"
        '
        'txtNextOfKinContact
        '
        Me.txtNextOfKinContact.AcceptsReturn = True
        Me.txtNextOfKinContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNextOfKinContact.Location = New System.Drawing.Point(120, 412)
        Me.txtNextOfKinContact.Multiline = True
        Me.txtNextOfKinContact.Name = "txtNextOfKinContact"
        Me.txtNextOfKinContact.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNextOfKinContact.Size = New System.Drawing.Size(359, 30)
        Me.txtNextOfKinContact.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(4, 408)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Next of Kin Details"
        '
        'txtNextOfKinName
        '
        Me.txtNextOfKinName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNextOfKinName.Location = New System.Drawing.Point(120, 388)
        Me.txtNextOfKinName.Name = "txtNextOfKinName"
        Me.txtNextOfKinName.Size = New System.Drawing.Size(359, 21)
        Me.txtNextOfKinName.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(4, 384)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Next of Kin Name"
        '
        'btnVanHistory
        '
        Me.btnVanHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVanHistory.Location = New System.Drawing.Point(341, 603)
        Me.btnVanHistory.Name = "btnVanHistory"
        Me.btnVanHistory.Size = New System.Drawing.Size(139, 23)
        Me.btnVanHistory.TabIndex = 15
        Me.btnVanHistory.Text = "Stock Profile History"
        '
        'txtEngineerID
        '
        Me.txtEngineerID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEngineerID.Location = New System.Drawing.Point(120, 250)
        Me.txtEngineerID.Name = "txtEngineerID"
        Me.txtEngineerID.ReadOnly = True
        Me.txtEngineerID.Size = New System.Drawing.Size(359, 21)
        Me.txtEngineerID.TabIndex = 8
        Me.txtEngineerID.TabStop = False
        '
        'cboRegionID
        '
        Me.cboRegionID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRegionID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRegionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegionID.Location = New System.Drawing.Point(120, 24)
        Me.cboRegionID.Name = "cboRegionID"
        Me.cboRegionID.Size = New System.Drawing.Size(359, 21)
        Me.cboRegionID.TabIndex = 1
        Me.cboRegionID.Tag = "Engineer.RegionID"
        '
        'lblRegionID
        '
        Me.lblRegionID.Location = New System.Drawing.Point(4, 28)
        Me.lblRegionID.Name = "lblRegionID"
        Me.lblRegionID.Size = New System.Drawing.Size(64, 20)
        Me.lblRegionID.TabIndex = 31
        Me.lblRegionID.Text = "Region"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(120, 48)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(359, 21)
        Me.txtName.TabIndex = 2
        Me.txtName.Tag = "Engineer.Name"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(4, 48)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(48, 20)
        Me.lblName.TabIndex = 31
        Me.lblName.Text = "Name"
        '
        'txtTelephoneNum
        '
        Me.txtTelephoneNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelephoneNum.Location = New System.Drawing.Point(120, 226)
        Me.txtTelephoneNum.Name = "txtTelephoneNum"
        Me.txtTelephoneNum.Size = New System.Drawing.Size(359, 21)
        Me.txtTelephoneNum.TabIndex = 7
        Me.txtTelephoneNum.Tag = "Engineer.TelephoneNum"
        '
        'lblTelephoneNum
        '
        Me.lblTelephoneNum.Location = New System.Drawing.Point(4, 229)
        Me.lblTelephoneNum.Name = "lblTelephoneNum"
        Me.lblTelephoneNum.Size = New System.Drawing.Size(104, 20)
        Me.lblTelephoneNum.TabIndex = 31
        Me.lblTelephoneNum.Text = "Telephone"
        '
        'lblEngineerID
        '
        Me.lblEngineerID.Location = New System.Drawing.Point(4, 253)
        Me.lblEngineerID.Name = "lblEngineerID"
        Me.lblEngineerID.Size = New System.Drawing.Size(94, 20)
        Me.lblEngineerID.TabIndex = 31
        Me.lblEngineerID.Text = "Engineer ID"
        '
        'chkApprentice
        '
        Me.chkApprentice.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.chkApprentice.Location = New System.Drawing.Point(120, 366)
        Me.chkApprentice.Name = "chkApprentice"
        Me.chkApprentice.Size = New System.Drawing.Size(112, 24)
        Me.chkApprentice.TabIndex = 12
        Me.chkApprentice.Tag = "Engineer.Apprentice"
        Me.chkApprentice.Text = "Apprentice"
        '
        'tpMaxTimes
        '
        Me.tpMaxTimes.Controls.Add(Me.GroupBox2)
        Me.tpMaxTimes.Location = New System.Drawing.Point(4, 22)
        Me.tpMaxTimes.Name = "tpMaxTimes"
        Me.tpMaxTimes.Size = New System.Drawing.Size(504, 637)
        Me.tpMaxTimes.TabIndex = 8
        Me.tpMaxTimes.Text = "Max SOR Times"
        Me.tpMaxTimes.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDailyServiceLimit)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.txtSundayValue)
        Me.GroupBox2.Controls.Add(Me.txtSaturdayValue)
        Me.GroupBox2.Controls.Add(Me.txtFridayValue)
        Me.GroupBox2.Controls.Add(Me.txtThursdayValue)
        Me.GroupBox2.Controls.Add(Me.txtWednesdayValue)
        Me.GroupBox2.Controls.Add(Me.txtTuesdayValue)
        Me.GroupBox2.Controls.Add(Me.txtMondayValue)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(498, 253)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Max Schedule Of Rate Times Per Day (In minutes)"
        '
        'txtDailyServiceLimit
        '
        Me.txtDailyServiceLimit.Location = New System.Drawing.Point(163, 226)
        Me.txtDailyServiceLimit.Name = "txtDailyServiceLimit"
        Me.txtDailyServiceLimit.Size = New System.Drawing.Size(131, 21)
        Me.txtDailyServiceLimit.TabIndex = 15
        Me.txtDailyServiceLimit.Text = "0"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(29, 229)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(114, 13)
        Me.Label41.TabIndex = 14
        Me.Label41.Text = "Daily Service Limit"
        '
        'txtSundayValue
        '
        Me.txtSundayValue.Location = New System.Drawing.Point(163, 175)
        Me.txtSundayValue.Name = "txtSundayValue"
        Me.txtSundayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtSundayValue.TabIndex = 13
        Me.txtSundayValue.Text = "0"
        '
        'txtSaturdayValue
        '
        Me.txtSaturdayValue.Location = New System.Drawing.Point(163, 150)
        Me.txtSaturdayValue.Name = "txtSaturdayValue"
        Me.txtSaturdayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtSaturdayValue.TabIndex = 12
        Me.txtSaturdayValue.Text = "0"
        '
        'txtFridayValue
        '
        Me.txtFridayValue.Location = New System.Drawing.Point(163, 125)
        Me.txtFridayValue.Name = "txtFridayValue"
        Me.txtFridayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtFridayValue.TabIndex = 11
        Me.txtFridayValue.Text = "0"
        '
        'txtThursdayValue
        '
        Me.txtThursdayValue.Location = New System.Drawing.Point(163, 101)
        Me.txtThursdayValue.Name = "txtThursdayValue"
        Me.txtThursdayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtThursdayValue.TabIndex = 10
        Me.txtThursdayValue.Text = "0"
        '
        'txtWednesdayValue
        '
        Me.txtWednesdayValue.Location = New System.Drawing.Point(163, 77)
        Me.txtWednesdayValue.Name = "txtWednesdayValue"
        Me.txtWednesdayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtWednesdayValue.TabIndex = 9
        Me.txtWednesdayValue.Text = "0"
        '
        'txtTuesdayValue
        '
        Me.txtTuesdayValue.Location = New System.Drawing.Point(163, 54)
        Me.txtTuesdayValue.Name = "txtTuesdayValue"
        Me.txtTuesdayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtTuesdayValue.TabIndex = 8
        Me.txtTuesdayValue.Text = "0"
        '
        'txtMondayValue
        '
        Me.txtMondayValue.Location = New System.Drawing.Point(163, 30)
        Me.txtMondayValue.Name = "txtMondayValue"
        Me.txtMondayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtMondayValue.TabIndex = 7
        Me.txtMondayValue.Text = "0"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(29, 178)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(50, 13)
        Me.Label33.TabIndex = 6
        Me.Label33.Text = "Sunday"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(28, 153)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(59, 13)
        Me.Label32.TabIndex = 5
        Me.Label32.Text = "Saturday"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(28, 128)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(42, 13)
        Me.Label31.TabIndex = 4
        Me.Label31.Text = "Friday"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(28, 104)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 13)
        Me.Label30.TabIndex = 3
        Me.Label30.Text = "Thursday"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(28, 80)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(72, 13)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "Wednesday"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(28, 57)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(54, 13)
        Me.Label28.TabIndex = 1
        Me.Label28.Text = "Tuesday"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(28, 33)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(51, 13)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Monday"
        '
        'tpTrainingQualifications
        '
        Me.tpTrainingQualifications.Controls.Add(Me.GroupBox5)
        Me.tpTrainingQualifications.Location = New System.Drawing.Point(4, 22)
        Me.tpTrainingQualifications.Name = "tpTrainingQualifications"
        Me.tpTrainingQualifications.Size = New System.Drawing.Size(504, 637)
        Me.tpTrainingQualifications.TabIndex = 3
        Me.tpTrainingQualifications.Text = "Training & Qualifications"
        Me.tpTrainingQualifications.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Panel1)
        Me.GroupBox5.Controls.Add(Me.btnRemoveTrainingQualifications)
        Me.GroupBox5.Controls.Add(Me.dgTrainingQualifications)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(488, 623)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Training && Qualifications"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cboQualificationType)
        Me.Panel1.Controls.Add(Me.lblQualificationType)
        Me.Panel1.Controls.Add(Me.dtpQualificationBooked)
        Me.Panel1.Controls.Add(Me.Label36)
        Me.Panel1.Controls.Add(Me.cbxShowOnJob)
        Me.Panel1.Controls.Add(Me.cboQualification)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.txtQualificatioNote)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.btnSaveQualification)
        Me.Panel1.Controls.Add(Me.dtpQualificationExpires)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.dtpQualificationPassed)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Location = New System.Drawing.Point(5, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(475, 212)
        Me.Panel1.TabIndex = 42
        '
        'cboQualificationType
        '
        Me.cboQualificationType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboQualificationType.Location = New System.Drawing.Point(140, 4)
        Me.cboQualificationType.Name = "cboQualificationType"
        Me.cboQualificationType.Size = New System.Drawing.Size(324, 21)
        Me.cboQualificationType.TabIndex = 52
        Me.cboQualificationType.Text = "ComboBox1"
        '
        'lblQualificationType
        '
        Me.lblQualificationType.Location = New System.Drawing.Point(8, 4)
        Me.lblQualificationType.Name = "lblQualificationType"
        Me.lblQualificationType.Size = New System.Drawing.Size(126, 23)
        Me.lblQualificationType.TabIndex = 53
        Me.lblQualificationType.Text = "Qualification Type"
        '
        'dtpQualificationBooked
        '
        Me.dtpQualificationBooked.Checked = False
        Me.dtpQualificationBooked.Location = New System.Drawing.Point(96, 107)
        Me.dtpQualificationBooked.Name = "dtpQualificationBooked"
        Me.dtpQualificationBooked.ShowCheckBox = True
        Me.dtpQualificationBooked.Size = New System.Drawing.Size(152, 21)
        Me.dtpQualificationBooked.TabIndex = 50
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(8, 107)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(80, 23)
        Me.Label36.TabIndex = 51
        Me.Label36.Text = "Booked"
        '
        'cbxShowOnJob
        '
        Me.cbxShowOnJob.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxShowOnJob.AutoSize = True
        Me.cbxShowOnJob.Enabled = False
        Me.cbxShowOnJob.Location = New System.Drawing.Point(96, 181)
        Me.cbxShowOnJob.Name = "cbxShowOnJob"
        Me.cbxShowOnJob.Size = New System.Drawing.Size(98, 17)
        Me.cbxShowOnJob.TabIndex = 49
        Me.cbxShowOnJob.Text = "Show on Job"
        Me.cbxShowOnJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbxShowOnJob.UseVisualStyleBackColor = True
        Me.cbxShowOnJob.Visible = False
        '
        'cboQualification
        '
        Me.cboQualification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboQualification.Location = New System.Drawing.Point(96, 30)
        Me.cboQualification.Name = "cboQualification"
        Me.cboQualification.Size = New System.Drawing.Size(368, 21)
        Me.cboQualification.TabIndex = 1
        Me.cboQualification.Text = "ComboBox1"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(8, 30)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 23)
        Me.Label22.TabIndex = 48
        Me.Label22.Text = "Qualification"
        '
        'txtQualificatioNote
        '
        Me.txtQualificatioNote.AcceptsReturn = True
        Me.txtQualificatioNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQualificatioNote.Location = New System.Drawing.Point(96, 133)
        Me.txtQualificatioNote.Multiline = True
        Me.txtQualificatioNote.Name = "txtQualificatioNote"
        Me.txtQualificatioNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQualificatioNote.Size = New System.Drawing.Size(368, 42)
        Me.txtQualificatioNote.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 136)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 20)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "Note"
        '
        'btnSaveQualification
        '
        Me.btnSaveQualification.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveQualification.Location = New System.Drawing.Point(327, 181)
        Me.btnSaveQualification.Name = "btnSaveQualification"
        Me.btnSaveQualification.Size = New System.Drawing.Size(137, 23)
        Me.btnSaveQualification.TabIndex = 5
        Me.btnSaveQualification.Text = "Add / Update"
        '
        'dtpQualificationExpires
        '
        Me.dtpQualificationExpires.Checked = False
        Me.dtpQualificationExpires.Location = New System.Drawing.Point(96, 80)
        Me.dtpQualificationExpires.Name = "dtpQualificationExpires"
        Me.dtpQualificationExpires.ShowCheckBox = True
        Me.dtpQualificationExpires.Size = New System.Drawing.Size(152, 21)
        Me.dtpQualificationExpires.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 23)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Expires"
        '
        'dtpQualificationPassed
        '
        Me.dtpQualificationPassed.Checked = False
        Me.dtpQualificationPassed.Location = New System.Drawing.Point(96, 56)
        Me.dtpQualificationPassed.Name = "dtpQualificationPassed"
        Me.dtpQualificationPassed.ShowCheckBox = True
        Me.dtpQualificationPassed.Size = New System.Drawing.Size(152, 21)
        Me.dtpQualificationPassed.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 23)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Date Passed"
        '
        'btnRemoveTrainingQualifications
        '
        Me.btnRemoveTrainingQualifications.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveTrainingQualifications.Location = New System.Drawing.Point(10, 591)
        Me.btnRemoveTrainingQualifications.Name = "btnRemoveTrainingQualifications"
        Me.btnRemoveTrainingQualifications.Size = New System.Drawing.Size(75, 21)
        Me.btnRemoveTrainingQualifications.TabIndex = 7
        Me.btnRemoveTrainingQualifications.Text = "Delete"
        '
        'dgTrainingQualifications
        '
        Me.dgTrainingQualifications.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTrainingQualifications.DataMember = ""
        Me.dgTrainingQualifications.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTrainingQualifications.Location = New System.Drawing.Point(8, 235)
        Me.dgTrainingQualifications.Name = "dgTrainingQualifications"
        Me.dgTrainingQualifications.Size = New System.Drawing.Size(472, 348)
        Me.dgTrainingQualifications.TabIndex = 6
        '
        'tpKit
        '
        Me.tpKit.Controls.Add(Me.GroupBox4)
        Me.tpKit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpKit.Location = New System.Drawing.Point(4, 22)
        Me.tpKit.Name = "tpKit"
        Me.tpKit.Size = New System.Drawing.Size(504, 637)
        Me.tpKit.TabIndex = 4
        Me.tpKit.Text = "Equipment"
        Me.tpKit.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Panel2)
        Me.GroupBox4.Controls.Add(Me.btnRemoveEngineerEquipment)
        Me.GroupBox4.Controls.Add(Me.dgEquipment)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(488, 623)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Specialised Equipment and Tools Issued"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtEquipmentTool)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.btnSaveEquipment)
        Me.Panel2.Location = New System.Drawing.Point(8, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(472, 64)
        Me.Panel2.TabIndex = 2
        '
        'txtEquipmentTool
        '
        Me.txtEquipmentTool.AcceptsReturn = True
        Me.txtEquipmentTool.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEquipmentTool.Location = New System.Drawing.Point(115, 4)
        Me.txtEquipmentTool.MaxLength = 255
        Me.txtEquipmentTool.Multiline = True
        Me.txtEquipmentTool.Name = "txtEquipmentTool"
        Me.txtEquipmentTool.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEquipmentTool.Size = New System.Drawing.Size(256, 56)
        Me.txtEquipmentTool.TabIndex = 1
        Me.txtEquipmentTool.Tag = "Engineer.Name"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Equipment\Tool"
        '
        'btnSaveEquipment
        '
        Me.btnSaveEquipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveEquipment.Location = New System.Drawing.Point(384, 36)
        Me.btnSaveEquipment.Name = "btnSaveEquipment"
        Me.btnSaveEquipment.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveEquipment.TabIndex = 2
        Me.btnSaveEquipment.Text = "Save"
        '
        'btnRemoveEngineerEquipment
        '
        Me.btnRemoveEngineerEquipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveEngineerEquipment.Location = New System.Drawing.Point(8, 591)
        Me.btnRemoveEngineerEquipment.Name = "btnRemoveEngineerEquipment"
        Me.btnRemoveEngineerEquipment.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveEngineerEquipment.TabIndex = 4
        Me.btnRemoveEngineerEquipment.Text = "Delete"
        '
        'dgEquipment
        '
        Me.dgEquipment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgEquipment.DataMember = ""
        Me.dgEquipment.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEquipment.Location = New System.Drawing.Point(8, 103)
        Me.dgEquipment.Name = "dgEquipment"
        Me.dgEquipment.Size = New System.Drawing.Size(472, 480)
        Me.dgEquipment.TabIndex = 3
        '
        'tpDisciplinary
        '
        Me.tpDisciplinary.Controls.Add(Me.GroupBox6)
        Me.tpDisciplinary.Location = New System.Drawing.Point(4, 22)
        Me.tpDisciplinary.Name = "tpDisciplinary"
        Me.tpDisciplinary.Size = New System.Drawing.Size(504, 637)
        Me.tpDisciplinary.TabIndex = 2
        Me.tpDisciplinary.Text = "Disciplinary"
        Me.tpDisciplinary.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.btnAddDisciplinaries)
        Me.GroupBox6.Controls.Add(Me.Panel3)
        Me.GroupBox6.Controls.Add(Me.btnRemoveDisciplinaries)
        Me.GroupBox6.Controls.Add(Me.btnEditDisciplinaries)
        Me.GroupBox6.Controls.Add(Me.dgDisciplinaries)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(488, 519)
        Me.GroupBox6.TabIndex = 14
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Disciplinary Records"
        '
        'btnAddDisciplinaries
        '
        Me.btnAddDisciplinaries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddDisciplinaries.Location = New System.Drawing.Point(8, 487)
        Me.btnAddDisciplinaries.Name = "btnAddDisciplinaries"
        Me.btnAddDisciplinaries.Size = New System.Drawing.Size(75, 21)
        Me.btnAddDisciplinaries.TabIndex = 6
        Me.btnAddDisciplinaries.Text = "Add"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.txtDisciplinaryID)
        Me.Panel3.Controls.Add(Me.cboDisciplinary)
        Me.Panel3.Controls.Add(Me.btnSaveDisciplinaries)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.dtpDisciplinaryIssued)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.txtDisciplinary)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Location = New System.Drawing.Point(5, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(475, 80)
        Me.Panel3.TabIndex = 42
        '
        'txtDisciplinaryID
        '
        Me.txtDisciplinaryID.Location = New System.Drawing.Point(352, 31)
        Me.txtDisciplinaryID.Name = "txtDisciplinaryID"
        Me.txtDisciplinaryID.Size = New System.Drawing.Size(100, 21)
        Me.txtDisciplinaryID.TabIndex = 47
        Me.txtDisciplinaryID.TabStop = False
        Me.txtDisciplinaryID.Visible = False
        '
        'cboDisciplinary
        '
        Me.cboDisciplinary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDisciplinary.Location = New System.Drawing.Point(96, 53)
        Me.cboDisciplinary.Name = "cboDisciplinary"
        Me.cboDisciplinary.Size = New System.Drawing.Size(272, 21)
        Me.cboDisciplinary.TabIndex = 3
        Me.cboDisciplinary.Text = "ComboBox2"
        '
        'btnSaveDisciplinaries
        '
        Me.btnSaveDisciplinaries.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveDisciplinaries.Location = New System.Drawing.Point(376, 53)
        Me.btnSaveDisciplinaries.Name = "btnSaveDisciplinaries"
        Me.btnSaveDisciplinaries.Size = New System.Drawing.Size(88, 21)
        Me.btnSaveDisciplinaries.TabIndex = 4
        Me.btnSaveDisciplinaries.Text = "Save"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 53)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 23)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Status"
        '
        'dtpDisciplinaryIssued
        '
        Me.dtpDisciplinaryIssued.Checked = False
        Me.dtpDisciplinaryIssued.Location = New System.Drawing.Point(96, 29)
        Me.dtpDisciplinaryIssued.Name = "dtpDisciplinaryIssued"
        Me.dtpDisciplinaryIssued.ShowCheckBox = True
        Me.dtpDisciplinaryIssued.Size = New System.Drawing.Size(152, 21)
        Me.dtpDisciplinaryIssued.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 23)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Issued"
        '
        'txtDisciplinary
        '
        Me.txtDisciplinary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDisciplinary.Location = New System.Drawing.Point(96, 5)
        Me.txtDisciplinary.Name = "txtDisciplinary"
        Me.txtDisciplinary.Size = New System.Drawing.Size(376, 21)
        Me.txtDisciplinary.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 20)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "Disciplinary"
        '
        'btnRemoveDisciplinaries
        '
        Me.btnRemoveDisciplinaries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveDisciplinaries.Location = New System.Drawing.Point(168, 487)
        Me.btnRemoveDisciplinaries.Name = "btnRemoveDisciplinaries"
        Me.btnRemoveDisciplinaries.Size = New System.Drawing.Size(75, 21)
        Me.btnRemoveDisciplinaries.TabIndex = 7
        Me.btnRemoveDisciplinaries.Text = "Delete"
        '
        'btnEditDisciplinaries
        '
        Me.btnEditDisciplinaries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEditDisciplinaries.Location = New System.Drawing.Point(88, 487)
        Me.btnEditDisciplinaries.Name = "btnEditDisciplinaries"
        Me.btnEditDisciplinaries.Size = New System.Drawing.Size(75, 21)
        Me.btnEditDisciplinaries.TabIndex = 6
        Me.btnEditDisciplinaries.Text = "Edit"
        '
        'dgDisciplinaries
        '
        Me.dgDisciplinaries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDisciplinaries.DataMember = ""
        Me.dgDisciplinaries.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDisciplinaries.Location = New System.Drawing.Point(8, 113)
        Me.dgDisciplinaries.Name = "dgDisciplinaries"
        Me.dgDisciplinaries.Size = New System.Drawing.Size(472, 366)
        Me.dgDisciplinaries.TabIndex = 5
        '
        'tpDocuments
        '
        Me.tpDocuments.Controls.Add(Me.pnlDocuments)
        Me.tpDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tpDocuments.Name = "tpDocuments"
        Me.tpDocuments.Size = New System.Drawing.Size(504, 637)
        Me.tpDocuments.TabIndex = 6
        Me.tpDocuments.Text = "Documents"
        Me.tpDocuments.UseVisualStyleBackColor = True
        '
        'pnlDocuments
        '
        Me.pnlDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDocuments.Location = New System.Drawing.Point(0, 0)
        Me.pnlDocuments.Name = "pnlDocuments"
        Me.pnlDocuments.Size = New System.Drawing.Size(504, 637)
        Me.pnlDocuments.TabIndex = 0
        '
        'tpHolidayAbsences
        '
        Me.tpHolidayAbsences.Controls.Add(Me.grpAbsences)
        Me.tpHolidayAbsences.Controls.Add(Me.GroupBox7)
        Me.tpHolidayAbsences.Location = New System.Drawing.Point(4, 22)
        Me.tpHolidayAbsences.Name = "tpHolidayAbsences"
        Me.tpHolidayAbsences.Size = New System.Drawing.Size(504, 637)
        Me.tpHolidayAbsences.TabIndex = 5
        Me.tpHolidayAbsences.Text = "Holidays & Absences"
        Me.tpHolidayAbsences.UseVisualStyleBackColor = True
        '
        'grpAbsences
        '
        Me.grpAbsences.Controls.Add(Me.dgAbsences)
        Me.grpAbsences.Location = New System.Drawing.Point(8, 112)
        Me.grpAbsences.Name = "grpAbsences"
        Me.grpAbsences.Size = New System.Drawing.Size(488, 328)
        Me.grpAbsences.TabIndex = 4
        Me.grpAbsences.TabStop = False
        Me.grpAbsences.Text = "Absences"
        '
        'dgAbsences
        '
        Me.dgAbsences.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAbsences.DataMember = ""
        Me.dgAbsences.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAbsences.Location = New System.Drawing.Point(8, 21)
        Me.dgAbsences.Name = "dgAbsences"
        Me.dgAbsences.Size = New System.Drawing.Size(472, 299)
        Me.dgAbsences.TabIndex = 4
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.txtDaysHolidayAllowed)
        Me.GroupBox7.Controls.Add(Me.Label21)
        Me.GroupBox7.Controls.Add(Me.txtHolidayYearEnd)
        Me.GroupBox7.Controls.Add(Me.Label20)
        Me.GroupBox7.Controls.Add(Me.txtHolidayYearStart)
        Me.GroupBox7.Controls.Add(Me.Label19)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(488, 104)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Holiday Entitlement"
        '
        'txtDaysHolidayAllowed
        '
        Me.txtDaysHolidayAllowed.Location = New System.Drawing.Point(144, 72)
        Me.txtDaysHolidayAllowed.Name = "txtDaysHolidayAllowed"
        Me.txtDaysHolidayAllowed.Size = New System.Drawing.Size(100, 21)
        Me.txtDaysHolidayAllowed.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(16, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(128, 23)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Holiday Entitlement"
        '
        'txtHolidayYearEnd
        '
        Me.txtHolidayYearEnd.Location = New System.Drawing.Point(144, 48)
        Me.txtHolidayYearEnd.Name = "txtHolidayYearEnd"
        Me.txtHolidayYearEnd.Size = New System.Drawing.Size(100, 21)
        Me.txtHolidayYearEnd.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(16, 48)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(128, 23)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "End Period (dd/mm)"
        '
        'txtHolidayYearStart
        '
        Me.txtHolidayYearStart.Location = New System.Drawing.Point(144, 24)
        Me.txtHolidayYearStart.Name = "txtHolidayYearStart"
        Me.txtHolidayYearStart.Size = New System.Drawing.Size(100, 21)
        Me.txtHolidayYearStart.TabIndex = 1
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(16, 24)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(128, 23)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Start Period (dd/mm)"
        '
        'tpPostalRegions
        '
        Me.tpPostalRegions.Controls.Add(Me.GroupBox8)
        Me.tpPostalRegions.Controls.Add(Me.grpPostalRegions)
        Me.tpPostalRegions.Location = New System.Drawing.Point(4, 22)
        Me.tpPostalRegions.Name = "tpPostalRegions"
        Me.tpPostalRegions.Size = New System.Drawing.Size(504, 637)
        Me.tpPostalRegions.TabIndex = 7
        Me.tpPostalRegions.Text = "Postal Regions"
        Me.tpPostalRegions.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.Controls.Add(Me.Button1)
        Me.GroupBox8.Controls.Add(Me.txtPostcode)
        Me.GroupBox8.Controls.Add(Me.Label42)
        Me.GroupBox8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(8, 34)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(488, 70)
        Me.GroupBox8.TabIndex = 13
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Home "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(288, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 43
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'txtPostcode
        '
        Me.txtPostcode.Location = New System.Drawing.Point(132, 25)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(123, 21)
        Me.txtPostcode.TabIndex = 41
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(29, 28)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(97, 20)
        Me.Label42.TabIndex = 42
        Me.Label42.Text = "Home Postcode"
        '
        'grpPostalRegions
        '
        Me.grpPostalRegions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPostalRegions.Controls.Add(Me.Label38)
        Me.grpPostalRegions.Controls.Add(Me.txtPCSearch)
        Me.grpPostalRegions.Controls.Add(Me.Label37)
        Me.grpPostalRegions.Controls.Add(Me.dgUnTicked)
        Me.grpPostalRegions.Controls.Add(Me.dgPostalRegions)
        Me.grpPostalRegions.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPostalRegions.Location = New System.Drawing.Point(8, 110)
        Me.grpPostalRegions.Name = "grpPostalRegions"
        Me.grpPostalRegions.Size = New System.Drawing.Size(488, 524)
        Me.grpPostalRegions.TabIndex = 12
        Me.grpPostalRegions.TabStop = False
        Me.grpPostalRegions.Text = "Postal Regions"
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Verdana", 10.25!)
        Me.Label38.Location = New System.Drawing.Point(8, 56)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(235, 20)
        Me.Label38.TabIndex = 43
        Me.Label38.Text = "Assigned Areas"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPCSearch
        '
        Me.txtPCSearch.Location = New System.Drawing.Point(341, 55)
        Me.txtPCSearch.Name = "txtPCSearch"
        Me.txtPCSearch.Size = New System.Drawing.Size(123, 21)
        Me.txtPCSearch.TabIndex = 41
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(258, 58)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(59, 20)
        Me.Label37.TabIndex = 42
        Me.Label37.Text = "Search"
        '
        'dgUnTicked
        '
        Me.dgUnTicked.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgUnTicked.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgUnTicked.DataMember = ""
        Me.dgUnTicked.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgUnTicked.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUnTicked.Location = New System.Drawing.Point(249, 85)
        Me.dgUnTicked.Name = "dgUnTicked"
        Me.dgUnTicked.Size = New System.Drawing.Size(233, 433)
        Me.dgUnTicked.TabIndex = 1
        '
        'dgPostalRegions
        '
        Me.dgPostalRegions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgPostalRegions.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgPostalRegions.DataMember = ""
        Me.dgPostalRegions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgPostalRegions.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPostalRegions.Location = New System.Drawing.Point(8, 85)
        Me.dgPostalRegions.Name = "dgPostalRegions"
        Me.dgPostalRegions.Size = New System.Drawing.Size(235, 433)
        Me.dgPostalRegions.TabIndex = 0
        '
        'tpSiteSafetyAudits
        '
        Me.tpSiteSafetyAudits.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.tpSiteSafetyAudits.Controls.Add(Me.grpSiteSafetyAudits)
        Me.tpSiteSafetyAudits.Controls.Add(Me.grpSiteSafetyAudit)
        Me.tpSiteSafetyAudits.Location = New System.Drawing.Point(4, 22)
        Me.tpSiteSafetyAudits.Name = "tpSiteSafetyAudits"
        Me.tpSiteSafetyAudits.Size = New System.Drawing.Size(504, 637)
        Me.tpSiteSafetyAudits.TabIndex = 9
        Me.tpSiteSafetyAudits.Text = "Site Safety Audits"
        Me.tpSiteSafetyAudits.UseVisualStyleBackColor = True
        '
        'grpSiteSafetyAudits
        '
        Me.grpSiteSafetyAudits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSiteSafetyAudits.Controls.Add(Me.dgSiteSafetyAudits)
        Me.grpSiteSafetyAudits.Location = New System.Drawing.Point(3, 442)
        Me.grpSiteSafetyAudits.Name = "grpSiteSafetyAudits"
        Me.grpSiteSafetyAudits.Size = New System.Drawing.Size(498, 192)
        Me.grpSiteSafetyAudits.TabIndex = 1
        Me.grpSiteSafetyAudits.TabStop = False
        Me.grpSiteSafetyAudits.Text = "Site Safety Audits"
        '
        'dgSiteSafetyAudits
        '
        Me.dgSiteSafetyAudits.DataMember = ""
        Me.dgSiteSafetyAudits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSiteSafetyAudits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSiteSafetyAudits.Location = New System.Drawing.Point(3, 17)
        Me.dgSiteSafetyAudits.Name = "dgSiteSafetyAudits"
        Me.dgSiteSafetyAudits.Size = New System.Drawing.Size(492, 172)
        Me.dgSiteSafetyAudits.TabIndex = 16
        '
        'grpSiteSafetyAudit
        '
        Me.grpSiteSafetyAudit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblSiteSafetyAuditInfo)
        Me.grpSiteSafetyAudit.Controls.Add(Me.btnfindEngineer)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtAuditor)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblAuditor)
        Me.grpSiteSafetyAudit.Controls.Add(Me.btnDeleteAudit)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblLine)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtTotal)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblTotal)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtAsbestos)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblAsbestos)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtCOSSH)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblCOSSH)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtFirstAidWelfare)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblFirstAidWelfare)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtWorkingAtHeight)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblWorkingAtHeight)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtManualHandling)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblManualHandling)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtMachineryEquipment)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblMachineryEquipment)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtHousekeeping)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblHousekeeping)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtEnvironmentalConditions)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblEnvironmentalConditions)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtUniformPPE)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblUniformPPE)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtDocumentProcedures)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblDocumentationProcedures)
        Me.grpSiteSafetyAudit.Controls.Add(Me.txtVehicleSafetyCondition)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblVehicleCheck)
        Me.grpSiteSafetyAudit.Controls.Add(Me.dtpAuditDate)
        Me.grpSiteSafetyAudit.Controls.Add(Me.lblAuditDate)
        Me.grpSiteSafetyAudit.Controls.Add(Me.btnNewAudit)
        Me.grpSiteSafetyAudit.Controls.Add(Me.btnSaveAudit)
        Me.grpSiteSafetyAudit.Location = New System.Drawing.Point(3, 3)
        Me.grpSiteSafetyAudit.Name = "grpSiteSafetyAudit"
        Me.grpSiteSafetyAudit.Size = New System.Drawing.Size(498, 433)
        Me.grpSiteSafetyAudit.TabIndex = 0
        Me.grpSiteSafetyAudit.TabStop = False
        Me.grpSiteSafetyAudit.Text = "Site Safety Audit"
        '
        'lblSiteSafetyAuditInfo
        '
        Me.lblSiteSafetyAuditInfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSiteSafetyAuditInfo.Location = New System.Drawing.Point(6, 18)
        Me.lblSiteSafetyAuditInfo.Name = "lblSiteSafetyAuditInfo"
        Me.lblSiteSafetyAuditInfo.Size = New System.Drawing.Size(486, 20)
        Me.lblSiteSafetyAuditInfo.TabIndex = 98
        Me.lblSiteSafetyAuditInfo.Text = "Please Key In -1 For N/A sections"
        '
        'btnfindEngineer
        '
        Me.btnfindEngineer.BackColor = System.Drawing.Color.White
        Me.btnfindEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindEngineer.Location = New System.Drawing.Point(460, 362)
        Me.btnfindEngineer.Name = "btnfindEngineer"
        Me.btnfindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnfindEngineer.TabIndex = 97
        Me.btnfindEngineer.Text = "..."
        Me.btnfindEngineer.UseVisualStyleBackColor = False
        '
        'txtAuditor
        '
        Me.txtAuditor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuditor.Location = New System.Drawing.Point(66, 362)
        Me.txtAuditor.Name = "txtAuditor"
        Me.txtAuditor.ReadOnly = True
        Me.txtAuditor.Size = New System.Drawing.Size(388, 21)
        Me.txtAuditor.TabIndex = 96
        '
        'lblAuditor
        '
        Me.lblAuditor.Location = New System.Drawing.Point(6, 366)
        Me.lblAuditor.Name = "lblAuditor"
        Me.lblAuditor.Size = New System.Drawing.Size(64, 21)
        Me.lblAuditor.TabIndex = 95
        Me.lblAuditor.Text = "Auditor"
        '
        'btnDeleteAudit
        '
        Me.btnDeleteAudit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteAudit.Location = New System.Drawing.Point(93, 404)
        Me.btnDeleteAudit.Name = "btnDeleteAudit"
        Me.btnDeleteAudit.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteAudit.TabIndex = 94
        Me.btnDeleteAudit.Text = "Delete"
        Me.btnDeleteAudit.UseVisualStyleBackColor = True
        '
        'lblLine
        '
        Me.lblLine.Location = New System.Drawing.Point(9, 299)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(496, 15)
        Me.lblLine.TabIndex = 93
        Me.lblLine.Text = "---------------------------------------------------------------------------------" &
    "--------------------------------------"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(185, 326)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(51, 21)
        Me.txtTotal.TabIndex = 92
        '
        'lblTotal
        '
        Me.lblTotal.Location = New System.Drawing.Point(6, 329)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(162, 20)
        Me.lblTotal.TabIndex = 91
        Me.lblTotal.Text = "Total"
        '
        'txtAsbestos
        '
        Me.txtAsbestos.Location = New System.Drawing.Point(185, 263)
        Me.txtAsbestos.Name = "txtAsbestos"
        Me.txtAsbestos.Size = New System.Drawing.Size(51, 21)
        Me.txtAsbestos.TabIndex = 90
        '
        'lblAsbestos
        '
        Me.lblAsbestos.Location = New System.Drawing.Point(6, 266)
        Me.lblAsbestos.Name = "lblAsbestos"
        Me.lblAsbestos.Size = New System.Drawing.Size(162, 20)
        Me.lblAsbestos.TabIndex = 89
        Me.lblAsbestos.Text = "Asbestos"
        '
        'txtCOSSH
        '
        Me.txtCOSSH.Location = New System.Drawing.Point(185, 220)
        Me.txtCOSSH.Name = "txtCOSSH"
        Me.txtCOSSH.Size = New System.Drawing.Size(51, 21)
        Me.txtCOSSH.TabIndex = 88
        '
        'lblCOSSH
        '
        Me.lblCOSSH.Location = New System.Drawing.Point(6, 223)
        Me.lblCOSSH.Name = "lblCOSSH"
        Me.lblCOSSH.Size = New System.Drawing.Size(162, 20)
        Me.lblCOSSH.TabIndex = 87
        Me.lblCOSSH.Text = "COSSH"
        '
        'txtFirstAidWelfare
        '
        Me.txtFirstAidWelfare.Location = New System.Drawing.Point(185, 177)
        Me.txtFirstAidWelfare.Name = "txtFirstAidWelfare"
        Me.txtFirstAidWelfare.Size = New System.Drawing.Size(51, 21)
        Me.txtFirstAidWelfare.TabIndex = 86
        '
        'lblFirstAidWelfare
        '
        Me.lblFirstAidWelfare.Location = New System.Drawing.Point(6, 180)
        Me.lblFirstAidWelfare.Name = "lblFirstAidWelfare"
        Me.lblFirstAidWelfare.Size = New System.Drawing.Size(162, 20)
        Me.lblFirstAidWelfare.TabIndex = 85
        Me.lblFirstAidWelfare.Text = "First Aid && Welfare"
        '
        'txtWorkingAtHeight
        '
        Me.txtWorkingAtHeight.Location = New System.Drawing.Point(441, 220)
        Me.txtWorkingAtHeight.Name = "txtWorkingAtHeight"
        Me.txtWorkingAtHeight.Size = New System.Drawing.Size(51, 21)
        Me.txtWorkingAtHeight.TabIndex = 84
        '
        'lblWorkingAtHeight
        '
        Me.lblWorkingAtHeight.Location = New System.Drawing.Point(255, 223)
        Me.lblWorkingAtHeight.Name = "lblWorkingAtHeight"
        Me.lblWorkingAtHeight.Size = New System.Drawing.Size(162, 20)
        Me.lblWorkingAtHeight.TabIndex = 83
        Me.lblWorkingAtHeight.Text = "Working At Height"
        '
        'txtManualHandling
        '
        Me.txtManualHandling.Location = New System.Drawing.Point(441, 177)
        Me.txtManualHandling.Name = "txtManualHandling"
        Me.txtManualHandling.Size = New System.Drawing.Size(51, 21)
        Me.txtManualHandling.TabIndex = 82
        '
        'lblManualHandling
        '
        Me.lblManualHandling.Location = New System.Drawing.Point(255, 180)
        Me.lblManualHandling.Name = "lblManualHandling"
        Me.lblManualHandling.Size = New System.Drawing.Size(162, 20)
        Me.lblManualHandling.TabIndex = 81
        Me.lblManualHandling.Text = "Manual Handling"
        '
        'txtMachineryEquipment
        '
        Me.txtMachineryEquipment.Location = New System.Drawing.Point(441, 134)
        Me.txtMachineryEquipment.Name = "txtMachineryEquipment"
        Me.txtMachineryEquipment.Size = New System.Drawing.Size(51, 21)
        Me.txtMachineryEquipment.TabIndex = 80
        '
        'lblMachineryEquipment
        '
        Me.lblMachineryEquipment.Location = New System.Drawing.Point(255, 137)
        Me.lblMachineryEquipment.Name = "lblMachineryEquipment"
        Me.lblMachineryEquipment.Size = New System.Drawing.Size(162, 20)
        Me.lblMachineryEquipment.TabIndex = 79
        Me.lblMachineryEquipment.Text = "Machinery && Equipment"
        '
        'txtHousekeeping
        '
        Me.txtHousekeeping.Location = New System.Drawing.Point(185, 134)
        Me.txtHousekeeping.Name = "txtHousekeeping"
        Me.txtHousekeeping.Size = New System.Drawing.Size(51, 21)
        Me.txtHousekeeping.TabIndex = 78
        '
        'lblHousekeeping
        '
        Me.lblHousekeeping.Location = New System.Drawing.Point(6, 137)
        Me.lblHousekeeping.Name = "lblHousekeeping"
        Me.lblHousekeeping.Size = New System.Drawing.Size(162, 20)
        Me.lblHousekeeping.TabIndex = 77
        Me.lblHousekeeping.Text = "Housekeeping"
        '
        'txtEnvironmentalConditions
        '
        Me.txtEnvironmentalConditions.Location = New System.Drawing.Point(441, 91)
        Me.txtEnvironmentalConditions.Name = "txtEnvironmentalConditions"
        Me.txtEnvironmentalConditions.Size = New System.Drawing.Size(51, 21)
        Me.txtEnvironmentalConditions.TabIndex = 76
        '
        'lblEnvironmentalConditions
        '
        Me.lblEnvironmentalConditions.Location = New System.Drawing.Point(255, 94)
        Me.lblEnvironmentalConditions.Name = "lblEnvironmentalConditions"
        Me.lblEnvironmentalConditions.Size = New System.Drawing.Size(162, 20)
        Me.lblEnvironmentalConditions.TabIndex = 75
        Me.lblEnvironmentalConditions.Text = "Environmental Conditions"
        '
        'txtUniformPPE
        '
        Me.txtUniformPPE.Location = New System.Drawing.Point(185, 91)
        Me.txtUniformPPE.Name = "txtUniformPPE"
        Me.txtUniformPPE.Size = New System.Drawing.Size(51, 21)
        Me.txtUniformPPE.TabIndex = 74
        '
        'lblUniformPPE
        '
        Me.lblUniformPPE.Location = New System.Drawing.Point(6, 94)
        Me.lblUniformPPE.Name = "lblUniformPPE"
        Me.lblUniformPPE.Size = New System.Drawing.Size(162, 20)
        Me.lblUniformPPE.TabIndex = 73
        Me.lblUniformPPE.Text = "Uniform && PPE"
        '
        'txtDocumentProcedures
        '
        Me.txtDocumentProcedures.Location = New System.Drawing.Point(441, 48)
        Me.txtDocumentProcedures.Name = "txtDocumentProcedures"
        Me.txtDocumentProcedures.Size = New System.Drawing.Size(51, 21)
        Me.txtDocumentProcedures.TabIndex = 72
        '
        'lblDocumentationProcedures
        '
        Me.lblDocumentationProcedures.Location = New System.Drawing.Point(255, 51)
        Me.lblDocumentationProcedures.Name = "lblDocumentationProcedures"
        Me.lblDocumentationProcedures.Size = New System.Drawing.Size(162, 20)
        Me.lblDocumentationProcedures.TabIndex = 71
        Me.lblDocumentationProcedures.Text = "Document && Procedures"
        '
        'txtVehicleSafetyCondition
        '
        Me.txtVehicleSafetyCondition.Location = New System.Drawing.Point(185, 46)
        Me.txtVehicleSafetyCondition.Name = "txtVehicleSafetyCondition"
        Me.txtVehicleSafetyCondition.Size = New System.Drawing.Size(51, 21)
        Me.txtVehicleSafetyCondition.TabIndex = 70
        '
        'lblVehicleCheck
        '
        Me.lblVehicleCheck.Location = New System.Drawing.Point(6, 49)
        Me.lblVehicleCheck.Name = "lblVehicleCheck"
        Me.lblVehicleCheck.Size = New System.Drawing.Size(162, 20)
        Me.lblVehicleCheck.TabIndex = 69
        Me.lblVehicleCheck.Text = "Vehicle Safety && Condition"
        '
        'dtpAuditDate
        '
        Me.dtpAuditDate.Location = New System.Drawing.Point(346, 326)
        Me.dtpAuditDate.Name = "dtpAuditDate"
        Me.dtpAuditDate.Size = New System.Drawing.Size(146, 21)
        Me.dtpAuditDate.TabIndex = 66
        Me.dtpAuditDate.Tag = ""
        '
        'lblAuditDate
        '
        Me.lblAuditDate.Location = New System.Drawing.Point(255, 329)
        Me.lblAuditDate.Name = "lblAuditDate"
        Me.lblAuditDate.Size = New System.Drawing.Size(85, 13)
        Me.lblAuditDate.TabIndex = 67
        Me.lblAuditDate.Text = "Audit Date"
        '
        'btnNewAudit
        '
        Me.btnNewAudit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNewAudit.Location = New System.Drawing.Point(3, 404)
        Me.btnNewAudit.Name = "btnNewAudit"
        Me.btnNewAudit.Size = New System.Drawing.Size(75, 23)
        Me.btnNewAudit.TabIndex = 8
        Me.btnNewAudit.Text = "New"
        Me.btnNewAudit.UseVisualStyleBackColor = True
        '
        'btnSaveAudit
        '
        Me.btnSaveAudit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAudit.Location = New System.Drawing.Point(417, 404)
        Me.btnSaveAudit.Name = "btnSaveAudit"
        Me.btnSaveAudit.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveAudit.TabIndex = 3
        Me.btnSaveAudit.Text = "Save"
        '
        'UCEngineer
        '
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "UCEngineer"
        Me.Size = New System.Drawing.Size(520, 679)
        Me.TabControl1.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.grpEngineer.ResumeLayout(False)
        Me.grpEngineer.PerformLayout()
        Me.tpMaxTimes.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tpTrainingQualifications.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgTrainingQualifications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpKit.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDisciplinary.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgDisciplinaries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDocuments.ResumeLayout(False)
        Me.tpHolidayAbsences.ResumeLayout(False)
        Me.grpAbsences.ResumeLayout(False)
        CType(Me.dgAbsences, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.tpPostalRegions.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.grpPostalRegions.ResumeLayout(False)
        Me.grpPostalRegions.PerformLayout()
        CType(Me.dgUnTicked, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPostalRegions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSiteSafetyAudits.ResumeLayout(False)
        Me.grpSiteSafetyAudits.ResumeLayout(False)
        CType(Me.dgSiteSafetyAudits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSiteSafetyAudit.ResumeLayout(False)
        Me.grpSiteSafetyAudit.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        'SetupLevelsDataGrid()
        SetupPostalRegionsDataGrid()
        SetupPostalRegionsDataGridUnTicked()
        SetupTrainingQualificationsDataGrid()
        SetupEngineerEquipmentDataGrid()
        SetupDisciplinariesDataGrid()
        SetupAbsenceDataGridGrid()
        SetupDgSiteSafetyAudit()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentEngineer
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private DocumentsControl As UCDocumentsList

    Private oldDepartment As String = String.Empty

    Private _MaxTimes As Entity.MaxEngineerTimes.MaxEngineerTime

    Public Property MaxTimes() As Entity.MaxEngineerTimes.MaxEngineerTime
        Get
            Return _MaxTimes
        End Get
        Set(ByVal value As Entity.MaxEngineerTimes.MaxEngineerTime)
            _MaxTimes = value
        End Set
    End Property

    Private _currentEngineer As Entity.Engineers.Engineer

    Public Property CurrentEngineer() As Entity.Engineers.Engineer
        Get
            Return _currentEngineer
        End Get
        Set(ByVal Value As Entity.Engineers.Engineer)
            _currentEngineer = Value

            If _currentEngineer Is Nothing Then
                _currentEngineer = New Entity.Engineers.Engineer
                _currentEngineer.Exists = False
            End If

            txtHolidayYearStart.Text = _currentEngineer.HolidayYearStart
            txtHolidayYearEnd.Text = _currentEngineer.HolidayYearEnd

            If _currentEngineer.Exists Then
                Populate()
                Me.btnVanHistory.Enabled = True
                Me.pnlDocuments.Controls.Clear()
                DocumentsControl = New UCDocumentsList(Entity.Sys.Enums.TableNames.tblEngineer, _currentEngineer.EngineerID)
                Me.pnlDocuments.Controls.Add(DocumentsControl)
            Else
                Me.btnVanHistory.Enabled = False
            End If
            PopulatePostalRegions()
            PopulateTrainingQualifications()
            PopulateEngineerEquipment()
            PopulateDisciplinaries()
            PopulateAbsences()
            PopulateSiteSafetyAuditDataGrid()
        End Set
    End Property

    Public Property PostalRegionsDataView() As DataView
        Get
            Return postalRegionsDV
        End Get
        Set(ByVal Value As DataView)
            postalRegionsDV = Value
            postalRegionsDV.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString
            postalRegionsDV.AllowNew = False
            postalRegionsDV.AllowEdit = False
            postalRegionsDV.AllowDelete = False
            Me.dgPostalRegions.DataSource = PostalRegionsDataView
        End Set
    End Property

    Private postalRegionsDV As DataView = Nothing

    Private ReadOnly Property SelectedPostalRegionDataRow() As DataRow
        Get

            If Not Me.dgPostalRegions.CurrentRowIndex = -1 Then
                Return PostalRegionsDataView(Me.dgPostalRegions.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property PostalRegionsDataViewUT() As DataView
        Get
            Return postalRegionsDVUT
        End Get
        Set(ByVal Value As DataView)
            postalRegionsDVUT = Value
            postalRegionsDVUT.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString
            postalRegionsDVUT.AllowNew = False
            postalRegionsDVUT.AllowEdit = False
            postalRegionsDVUT.AllowDelete = False
            Me.dgUnTicked.DataSource = PostalRegionsDataViewUT
        End Set
    End Property

    Private postalRegionsDVUT As DataView = Nothing

    Private ReadOnly Property SelectedPostalRegionDataRowUT() As DataRow
        Get

            If Not Me.dgUnTicked.CurrentRowIndex = -1 Then
                Return PostalRegionsDataViewUT(Me.dgUnTicked.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPCSearch.TextChanged
        RunFilter()
    End Sub

    Private Sub RunFilter()
        Dim whereClause As String = "Name Like '%" + txtPCSearch.Text + "%'"

        PostalRegionsDataViewUT.RowFilter = whereClause
    End Sub

    Private Sub UCEngineer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub dgPostalRegions_Clicks(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPostalRegions.Click
        Try
            If SelectedPostalRegionDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not CBool(Me.dgPostalRegions(Me.dgPostalRegions.CurrentRowIndex, 0))
            SelectedPostalRegionDataRow.Item(0) = selected
            PostalRegionsDataViewUT.Table.ImportRow(SelectedPostalRegionDataRow)
            PostalRegionsDataView.Table.Rows.RemoveAt(Me.dgPostalRegions.CurrentRowIndex)
            PostalRegionsDataViewUT.Table.Select("", "Name ASC")
            dgUnTicked.DataSource = PostalRegionsDataViewUT
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgPostalRegionsUnticked_Clicks(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgUnTicked.Click
        Try
            If SelectedPostalRegionDataRowUT Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not CBool(Me.dgUnTicked(Me.dgUnTicked.CurrentRowIndex, 0))

            SelectedPostalRegionDataRowUT.Item(0) = selected

            PostalRegionsDataView.Table.ImportRow(SelectedPostalRegionDataRowUT)
            PostalRegionsDataViewUT.Table.Rows.Remove(SelectedPostalRegionDataRowUT)
            PostalRegionsDataView.Table.Select("", "Name ASC")
            dgPostalRegions.DataSource = PostalRegionsDataView
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVanHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVanHistory.Click
        ShowForm(GetType(FRMVanHistory), True, New Object() {CurrentEngineer.EngineerID})
    End Sub

    Private Sub dgTrainingQualifications_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTrainingQualifications.Click, dgTrainingQualifications.CurrentCellChanged
        Try
            Combo.SetUpCombo(Me.cboQualificationType, DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
            Combo.SetSelectedComboItem_By_Value(cboQualification, SelectedTrainingQualificationsRow.Item(0).ToString)
            txtQualificatioNote.Text = SelectedTrainingQualificationsRow.Item(3)
            dtpQualificationPassed.Value = SelectedTrainingQualificationsRow.Item(4)
            dtpQualificationExpires.Value = SelectedTrainingQualificationsRow.Item(5)
            dtpQualificationBooked.Value = SelectedTrainingQualificationsRow.Item(6)
        Catch
        End Try
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentEngineer = DB.Engineer.Engineer_Get(ID)
        End If
        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Qualifications) Then
            Me.txtGasSafeNo.ReadOnly = True
            Me.TxtOftec.ReadOnly = True
        End If

        ' fix for blank departments , this should never of been a string anyhow..

        If CurrentEngineer.Department = "" Then CurrentEngineer.SetDepartment = "0"
        oldDepartment = CurrentEngineer.Department

        Combo.SetSelectedComboItem_By_Value(Me.cboRegionID, CurrentEngineer.RegionID)
        If Not CurrentEngineer.Exists Or Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Region) Then
            Me.cboRegionID.Enabled = False
        End If
        Combo.SetSelectedComboItem_By_Value(Me.cboEngineerGroup, CurrentEngineer.EngineerGroupID)
        Combo.SetSelectedComboItem_By_Value(cboLinkToUser, CurrentEngineer.UserID)
        Combo.SetSelectedComboItem_By_Value(cboEngineerRoleId, CurrentEngineer.EngineerRoleId)
        Combo.SetSelectedComboItem_By_Value(Me.cboDepartment, CurrentEngineer.Department.Trim())
        txtGasSafeNo.Text = CurrentEngineer.GasSafeNo
        TxtOftec.Text = CurrentEngineer.OftecNo
        Me.txtName.Text = CurrentEngineer.Name
        Me.txtTelephoneNum.Text = CurrentEngineer.TelephoneNum
        Me.txtEmailAddress.Text = CurrentEngineer.EmailAddress
        If CurrentEngineer.EngineerID = 0 Then
            Me.txtEngineerID.Text = "<Not Set>"
        Else
            Me.txtEngineerID.Text = CurrentEngineer.EngineerID
        End If
        Me.chkApprentice.Checked = CurrentEngineer.Apprentice
        'Me.txtCostToCompanyNormal.Text = Format(CurrentEngineer.CostToCompanyNormal, "C")
        'Me.txtCostToCompanyTimeHalf.Text = Format(CurrentEngineer.CostToCompanyTimeAndHalf, "C")
        'Me.txtCostToCompanyDouble.Text = Format(CurrentEngineer.CostToCompanyDouble, "C")

        MaxTimes = DB.MaxEngineerTime.MaxEngineerTime_GetForEngineer(CurrentEngineer.EngineerID)

        If Not MaxTimes Is Nothing Then
            Me.txtMondayValue.Text = MaxTimes.MondayValue
            Me.txtTuesdayValue.Text = MaxTimes.TuesdayValue
            Me.txtWednesdayValue.Text = MaxTimes.WednesdayValue
            Me.txtThursdayValue.Text = MaxTimes.ThursdayValue
            Me.txtFridayValue.Text = MaxTimes.FridayValue
            Me.txtSaturdayValue.Text = MaxTimes.SaturdayValue
            Me.txtSundayValue.Text = MaxTimes.SundayValue
        Else
            MaxTimes = New Entity.MaxEngineerTimes.MaxEngineerTime
        End If

        txtTechnician.Text = CurrentEngineer.Technician
        Combo.SetSelectedComboItem_By_Value(cboUser, CurrentEngineer.ManagerUserID)
        ' txtSupervisor.Text = CurrentEngineer.Supervisor

        txtNextOfKinName.Text = CurrentEngineer.NextOfKinName
        txtNextOfKinContact.Text = CurrentEngineer.NextOfKinContact
        txtStartingDetails.Text = CurrentEngineer.StartingDetails
        txtDrivingLicenceNo.Text = CurrentEngineer.DrivingLicenceNo

        If Not CurrentEngineer.DrivingLicenceIssueDate = Nothing Then
            dtpDrivingLicenceIssueDate.Value = CurrentEngineer.DrivingLicenceIssueDate
            dtpDrivingLicenceIssueDate.Checked = True
        Else
            dtpDrivingLicenceIssueDate.Value = Now.Date
            dtpDrivingLicenceIssueDate.Checked = False
        End If

        ''Combo.SetSelectedComboItem_By_Value(Me.cboPayGrade, CurrentEngineer.PayGradeID)
        ''txtAnnualSalary.Text = CurrentEngineer.AnnualSalary
        ''txtNINumber.Text = CurrentEngineer.NINumber
        txtHolidayYearStart.Text = CurrentEngineer.HolidayYearStart
        txtHolidayYearEnd.Text = CurrentEngineer.HolidayYearEnd
        txtDaysHolidayAllowed.Text = CurrentEngineer.DaysHolidayAllowed

        If CurrentEngineer.Name.Trim.StartsWith("SUBCONTRACTOR : ") Then
            Me.txtName.ReadOnly = True
            Me.txtTelephoneNum.ReadOnly = True
        End If

        txtServPri.Text = CurrentEngineer.ServPri
        txtBreakPri.Text = CurrentEngineer.BreakPri
        txtPostcode.Text = CurrentEngineer.HomePostcode
        txtDailyServiceLimit.Text = CurrentEngineer.DailyServiceLimit
        Combo.SetSelectedComboItem_By_Value(Me.cboRagRating, CurrentEngineer.RagRating)
        dtpRagDate.Value = CurrentEngineer.RagDate

        Me.txtVisitSpendLimit.Text = CurrentEngineer.VisitSpendLimit
        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Private Sub PopulatePostalRegions()
        PostalRegionsDataView = DB.EngineerPostalRegion.GetTicked(CurrentEngineer.EngineerID)
        PostalRegionsDataViewUT = DB.EngineerPostalRegion.GetUnTicked(CurrentEngineer.EngineerID)
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentEngineer.IgnoreExceptionsOnSetMethods = True

            If Not CurrentEngineer.Exists Or loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region) Then
                CurrentEngineer.SetRegionID = Combo.GetSelectedItemValue(Me.cboRegionID)
            End If
            CurrentEngineer.SetUserID = Combo.GetSelectedItemValue(cboLinkToUser)
            CurrentEngineer.SetEngineerGroupID = Combo.GetSelectedItemValue(cboEngineerGroup)
            CurrentEngineer.SetGasSafeNo = txtGasSafeNo.Text.Trim()
            CurrentEngineer.SetOftecNo = TxtOftec.Text.Trim()

            CurrentEngineer.SetName = Me.txtName.Text.Trim
            CurrentEngineer.SetTelephoneNum = Me.txtTelephoneNum.Text.Trim
            CurrentEngineer.SetEmailAddress = Me.txtEmailAddress.Text.Trim

            CurrentEngineer.SetPDAID = 0

            CurrentEngineer.SetTechnician = txtTechnician.Text.Trim()
            CurrentEngineer.SetSupervisor = Combo.GetSelectedItemDescription(cboUser)
            CurrentEngineer.SetManagerUserID = Combo.GetSelectedItemValue(cboUser)

            CurrentEngineer.SetNextOfKinName = txtNextOfKinName.Text
            CurrentEngineer.SetNextOfKinContact = txtNextOfKinContact.Text
            CurrentEngineer.SetStartingDetails = txtStartingDetails.Text
            CurrentEngineer.SetDrivingLicenceNo = txtDrivingLicenceNo.Text
            If dtpDrivingLicenceIssueDate.Checked Then
                CurrentEngineer.DrivingLicenceIssueDate = dtpDrivingLicenceIssueDate.Value
            Else
                CurrentEngineer.DrivingLicenceIssueDate = Nothing
            End If

            CurrentEngineer.SetHolidayYearStart = txtHolidayYearStart.Text
            CurrentEngineer.SetHolidayYearEnd = txtHolidayYearEnd.Text

            If txtDaysHolidayAllowed.Text.Trim().Length > 0 Then
                CurrentEngineer.SetDaysHolidayAllowed = txtDaysHolidayAllowed.Text
            End If

            Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(cboDepartment))
            If Helper.IsValidInteger(department) AndAlso Not Helper.MakeIntegerValid(department) <= 0 Then
                CurrentEngineer.SetDepartment = department
            ElseIf Not IsNumeric(department) Then
                CurrentEngineer.SetDepartment = department
            End If
            CurrentEngineer.SetServPri = txtServPri.Text
            CurrentEngineer.SetBreakPri = txtBreakPri.Text
            CurrentEngineer.SetDailyServiceLimit = txtDailyServiceLimit.Text

            CurrentEngineer.SetHomePostcode = txtPostcode.Text
            If txtWebAppPassword.Text.Trim.Length > 0 Then CurrentEngineer.SetWebAppPassword = txtWebAppPassword.Text.Trim
            If CurrentEngineer.Exists Then
                CurrentEngineer.SetRagRating = Combo.GetSelectedItemValue(cboRagRating)
                CurrentEngineer.RagDate = dtpRagDate.Value
            Else
                CurrentEngineer.SetRagRating = 2
                CurrentEngineer.RagDate = Now
            End If

            Try
                Dim ls As New LocationServices.LocationServices

                Dim json As JObject = ls.GetLongLat(txtPostcode.Text)
                CurrentEngineer.SetLongitude = json.SelectToken("result.longitude").ToString
                CurrentEngineer.SetLatitude = json.SelectToken("result.latitude").ToString
            Catch ex As Exception

            End Try

            If Me.txtVisitSpendLimit.Text.Trim.Length > 0 Then CurrentEngineer.SetVisitSpendLimit = Helper.MakeDoubleValid(Me.txtVisitSpendLimit.Text.Trim)
            CurrentEngineer.SetEngineerRoleId = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboEngineerRoleId))

            Dim cV As New Entity.Engineers.EngineerValidator
            cV.Validate(CurrentEngineer)

            If CurrentEngineer.Exists Then
                DB.Engineer.Update(CurrentEngineer)
                DB.EngineerPostalRegion.Delete(CurrentEngineer.EngineerID)
                For Each row As DataRow In PostalRegionsDataView.Table.Rows
                    If row.Item("Tick") Then
                        DB.EngineerPostalRegion.Insert(CurrentEngineer.EngineerID, row.Item("ManagerID"))
                    End If
                Next

                If MaxTimes Is Nothing Then
                    MaxTimes = New Entity.MaxEngineerTimes.MaxEngineerTime
                End If

                MaxTimes.SetEngineerID = CurrentEngineer.EngineerID
                MaxTimes.SetMondayValue = Me.txtMondayValue.Text
                MaxTimes.SetTuesdayValue = Me.txtTuesdayValue.Text
                MaxTimes.SetWednesdayValue = Me.txtWednesdayValue.Text
                MaxTimes.SetThursdayValue = Me.txtThursdayValue.Text
                MaxTimes.SetFridayValue = Me.txtFridayValue.Text
                MaxTimes.SetSaturdayValue = Me.txtSaturdayValue.Text
                MaxTimes.SetSundayValue = Me.txtSundayValue.Text

                Dim mTV As New Entity.MaxEngineerTimes.MaxEngineerTimeValidator
                mTV.Validate(MaxTimes)

                If MaxTimes.Exists Then
                    DB.MaxEngineerTime.Update(MaxTimes)
                Else
                    DB.MaxEngineerTime.Insert(MaxTimes)
                End If

                DB.EngineerLevel.Insert(CurrentEngineer.EngineerID, TrainingQualificationsDataView.Table)
                DB.Engineer.SaveEquipmentRecords(CurrentEngineer.EngineerID, EngineerEquipmentDataView.Table)
                DB.Engineer.SaveDisciplinaryRecords(CurrentEngineer.EngineerID, DisciplinariesDataView.Table)

                'send another email
                If CurrentEngineer.Department <> oldDepartment Then

                    If DB.User.Get(Combo.GetSelectedItemValue(cboUser))?.EmailAddress.Length > 2 Then
                        Dim message1 As String = ""
                        message1 = "The engineer " & CurrentEngineer.Name & " has been Ammended. They have been moved from department " & oldDepartment & " to department " &
                            CurrentEngineer.Department & " you have been marked as his line manager. Please ensure all necessary records are updated."

                        Email2(DB.User.Get(Combo.GetSelectedItemValue(cboUser)).EmailAddress, message1, loggedInUser.Fullname, Entity.Sys.EmailAddress.StockFinancials)
                    Else
                        Dim message1 As String = ""
                        message1 = "The engineer " & CurrentEngineer.Name & " has been Ammended. They have been moved from department " & oldDepartment & " to department " &
                            CurrentEngineer.Department & ". Please ensure all necessary records are updated."

                        Email2(Entity.Sys.EmailAddress.StockFinancials, message1, loggedInUser.Fullname, "")
                    End If

                End If
            Else
                Dim tempEng As Entity.Engineers.Engineer = DB.Engineer.Insert(CurrentEngineer)
                DB.EngineerPostalRegion.Delete(tempEng.EngineerID)
                For Each row As DataRow In PostalRegionsDataView.Table.Rows
                    If row.Item("Tick") Then
                        DB.EngineerPostalRegion.Insert(tempEng.EngineerID, row.Item("ManagerID"))
                    End If
                Next

                If MaxTimes Is Nothing Then
                    MaxTimes = New Entity.MaxEngineerTimes.MaxEngineerTime
                End If

                MaxTimes.SetEngineerID = tempEng.EngineerID
                MaxTimes.SetMondayValue = Me.txtMondayValue.Text
                MaxTimes.SetTuesdayValue = Me.txtTuesdayValue.Text
                MaxTimes.SetWednesdayValue = Me.txtWednesdayValue.Text
                MaxTimes.SetThursdayValue = Me.txtThursdayValue.Text
                MaxTimes.SetFridayValue = Me.txtFridayValue.Text
                MaxTimes.SetSaturdayValue = Me.txtSaturdayValue.Text
                MaxTimes.SetSundayValue = Me.txtSundayValue.Text

                Dim mTV As New Entity.MaxEngineerTimes.MaxEngineerTimeValidator
                mTV.Validate(MaxTimes)

                DB.MaxEngineerTime.Insert(MaxTimes)

                DB.EngineerLevel.Insert(tempEng.EngineerID, TrainingQualificationsDataView.Table)
                DB.Engineer.SaveEquipmentRecords(tempEng.EngineerID, EngineerEquipmentDataView.Table)
                DB.Engineer.SaveDisciplinaryRecords(tempEng.EngineerID, DisciplinariesDataView.Table)

                CurrentEngineer = tempEng

                'SEND AN EMAIL

                Dim message As String = ""
                Dim gassafe As Boolean = False
                Dim Oftec As Boolean = False

                If TxtOftec.Text.Length > 0 And Not TxtOftec.Text = "tbc" Then Oftec = True
                If txtGasSafeNo.Text.Length > 0 And Not txtGasSafeNo.Text = "tbc" Then gassafe = True

                If Combo.GetSelectedItemValue(cboUser) > 0 AndAlso DB.User.Get(Combo.GetSelectedItemValue(cboUser)).EmailAddress.Length > 3 Then
                    message = "The engineer " & CurrentEngineer.Name & " has been added for department " & CurrentEngineer.Department & " you have been marked as his line manager." &
                        "<br/><br/>" &
                        "Please ensure all necessary records are updated."
                    If Not Oftec Then message += "<br/>No oftec registered reference has been added."
                    If Not gassafe Then message += "<br/>No Gas Safe registered reference has been added."
                    If Not Oftec Or Not gassafe Then message += "<br/>Engineer CANNOT work on gas or oil until the GSR or OFTEC number has been filled in!"

                    Email(DB.User.Get(Combo.GetSelectedItemValue(cboUser)).EmailAddress, message, loggedInUser.Fullname, Entity.Sys.EmailAddress.HR & ", " & Entity.Sys.EmailAddress.Compliance)
                Else
                    message = "The engineer " & CurrentEngineer.Name & " has been added for department " & CurrentEngineer.Department & "." &
                        "<br/><br/>" & "Please ensure all necessary records are updated."
                    If Not Oftec Then message += "<br/>No oftec registered reference has been added."
                    If Not gassafe Then message += "<br/>No Gas Safe registered reference has been added."
                    If Not Oftec Or Not gassafe Then message += "<br/>Engineer CANNOT work on gas Or oil until the GSR Or OFTEC number has been filled in!"

                    Email(Entity.Sys.EmailAddress.HR & ", " & Entity.Sys.EmailAddress.Compliance, message, loggedInUser.Fullname, "")
                End If
            End If

            RaiseEvent RecordsChanged(DB.Engineer.Engineer_GetAll_NoSub(), Entity.Sys.Enums.PageViewing.Engineer, True, False, "")
            RaiseEvent StateChanged(CurrentEngineer.EngineerID)
            MainForm.RefreshEntity(CurrentEngineer.EngineerID)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Sub Email(ByVal emailadd As String, ByVal message As String, ByVal addinguser As String, ByVal cc As String)

        Dim PersonName As String = Nothing
        Dim GreetingPart As String = Nothing

        Dim FeedbackEmail As New Entity.Sys.Emails
        FeedbackEmail.From = Entity.Sys.EmailAddress.Gabriel
        FeedbackEmail.To = emailadd

        FeedbackEmail.CC = cc

        FeedbackEmail.Subject = "A New Engineer Has been added"
        FeedbackEmail.Body = "<span style='font-family: Calibri, Sans-Serif'>" &
            "<p>Hi</p>" &
            "<p>User : " & addinguser & " has added a new engineer</p>" &
            "<p>" & message & "</p>" &
            "<p>King Regards</p>" &
            "<p>" & TheSystem.Configuration.CompanyName & "</p>" &
            "</span>"

        FeedbackEmail.SendMe = True
        If FeedbackEmail.Send() Then
        End If
    End Sub

    Private Sub Email2(ByVal emailadd As String, ByVal message As String, ByVal addinguser As String, ByVal cc As String)
        Dim PersonName As String = Nothing
        Dim GreetingPart As String = Nothing

        Dim FeedbackEmail As New Entity.Sys.Emails
        FeedbackEmail.From = Entity.Sys.EmailAddress.Gabriel
        FeedbackEmail.To = emailadd

        FeedbackEmail.CC = cc

        FeedbackEmail.Subject = "An Engineers department has changed"
        FeedbackEmail.Body = "<span style='font-family: Calibri, Sans-Serif'>" &
            "<p>Hi</p>" &
            "<p>User : " & addinguser & " has ammended an engineer</p>" &
            "<p>" & message & "</p>" &
            "<p>King Regards</p>" &
            "<p>" & TheSystem.Configuration.CompanyName & "</p>" &
            "</span>"

        FeedbackEmail.SendMe = True
        If FeedbackEmail.Send() Then
        End If
    End Sub

    Public Sub SetupPostalRegionsDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgPostalRegions)
        Dim tStyle As DataGridTableStyle = Me.dgPostalRegions.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgPostalRegions.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Postcode"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 200
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString
        Me.dgPostalRegions.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgPostalRegions)
    End Sub

    Public Sub SetupPostalRegionsDataGridUnTicked()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgUnTicked)
        Dim tStyle As DataGridTableStyle = Me.dgUnTicked.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgPostalRegions.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Postcode"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 200
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString
        Me.dgUnTicked.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgUnTicked)
    End Sub

#End Region

#Region "Training & Qualifications Datagrid"

    Public Sub SetupTrainingQualificationsDataGrid()
        Try
            dgTrainingQualifications.TableStyles.Add(New DataGridTableStyle)
            Entity.Sys.Helper.SetUpDataGrid(Me.dgTrainingQualifications)

            Dim tStyle As DataGridTableStyle = dgTrainingQualifications.TableStyles(0)

            ', DateExpires

            Dim Qualification As New DataGridTextBoxColumn
            Qualification.HeaderText = "Level\Qualification"
            Qualification.MappingName = "Level"
            Qualification.NullText = ""
            Qualification.Width = 150
            tStyle.GridColumnStyles.Add(Qualification)

            Dim Description As New DataGridTextBoxColumn
            Description.HeaderText = "Description"
            Description.MappingName = "Description"
            Description.NullText = ""
            Description.Width = 200
            tStyle.GridColumnStyles.Add(Description)

            Dim Notes As New DataGridTextBoxColumn
            Notes.HeaderText = "Notes"
            Notes.MappingName = "Notes"
            Notes.NullText = ""
            Notes.Width = 400
            tStyle.GridColumnStyles.Add(Notes)

            Dim DatePassed As New DataGridTextBoxColumn
            DatePassed.HeaderText = "Passed"
            DatePassed.MappingName = "DatePassed"
            DatePassed.Format = "dd/MM/yyyy"
            DatePassed.NullText = ""
            DatePassed.Width = 80
            tStyle.GridColumnStyles.Add(DatePassed)

            Dim DateExpires As New DataGridTextBoxColumn
            DateExpires.HeaderText = "Expires"
            DateExpires.MappingName = "DateExpires"
            DateExpires.Format = "dd/MM/yyyy"
            DateExpires.NullText = ""
            DateExpires.Width = 80
            tStyle.GridColumnStyles.Add(DateExpires)

            Dim DateBooked As New DataGridTextBoxColumn
            DateBooked.HeaderText = "Booked"
            DateBooked.MappingName = "DateBooked"
            DateBooked.Format = "dd/MM/yyyy"
            DateBooked.NullText = ""
            DateBooked.Width = 80
            tStyle.GridColumnStyles.Add(DateBooked)

            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private _trainingQualificationsDataView As DataView

    Private Property TrainingQualificationsDataView() As DataView
        Get
            Return _trainingQualificationsDataView
        End Get
        Set(ByVal Value As DataView)
            If Not Value Is Nothing Then
                _trainingQualificationsDataView = Value
                _trainingQualificationsDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString
            End If
            dgTrainingQualifications.DataSource = _trainingQualificationsDataView
        End Set
    End Property

    Public ReadOnly Property SelectedTrainingQualificationsRow() As DataRow
        Get
            If Not TrainingQualificationsDataView Is Nothing Then
                If TrainingQualificationsDataView.Table.Rows.Count > 0 Then
                    Return TrainingQualificationsDataView(Me.dgTrainingQualifications.CurrentRowIndex).Row
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Sub PopulateTrainingQualifications()
        Try
            TrainingQualificationsDataView = DB.EngineerLevel.GetForSetup(CurrentEngineer.EngineerID)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearQualificationDetailPanel()
        Combo.SetSelectedComboItem_By_Value(Me.cboQualification, 0)
        txtQualificatioNote.Text = ""
        dtpQualificationPassed.Checked = False
        dtpQualificationExpires.Checked = False
    End Sub

    Private Sub btnSaveQualification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveQualification.Click
        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Qualifications) Then ShowSecurityError()
        Try
            Dim UpdateFlag As Boolean
            Dim r As DataRow
            r = TrainingQualificationsDataView.Table.NewRow()

            Dim v As BaseValidator = New BaseValidator

            Dim check As DataRow = TrainingQualificationsDataView.Table.Select("LevelID = " & Combo.GetSelectedItemValue(cboQualification)).FirstOrDefault()

            If check IsNot Nothing Then
                Dim msg As String = "This will update the qualification. "
                msg += "Do you wish to Procceed."
                If ShowMessage(msg, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.Cancel Then
                    Exit Sub
                Else
                    UpdateFlag = True
                End If
            End If

            If cboQualification.SelectedIndex = 0 Then
                v.AddCriticalMessage("'Qualification' is required")
            End If
            If dtpQualificationPassed.Checked = False Then
                v.AddCriticalMessage("'Date Passed' must be specified.")
            End If

            If v.ValidatorMessages.CriticalMessages.Count > 0 Then
                Throw New ValidationException(v)
            End If

            r("LevelID") = CInt(Combo.GetSelectedItemValue(cboQualification))
            r("Description") = Combo.GetSelectedItemDescription(cboQualification).ToString.Split("*")(0).Trim()
            r("Level") = Combo.GetSelectedItemDescription(cboQualification).ToString.Split("*")(1).Trim()
            r("Notes") = txtQualificatioNote.Text
            If dtpQualificationPassed.Checked Then
                r("DatePassed") = dtpQualificationPassed.Value
            End If
            If dtpQualificationExpires.Checked Then
                r("DateExpires") = dtpQualificationExpires.Value
            End If

            If dtpQualificationBooked.Checked Then
                r("DateBooked") = dtpQualificationBooked.Value
            End If
            If UpdateFlag Then
                For Each dc As DataColumn In check.Table.Columns
                    check(dc) = r(dc)
                Next
            Else
                TrainingQualificationsDataView.Table.Rows.Add(r)
            End If
            ClearQualificationDetailPanel()
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveTrainingQualifications_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTrainingQualifications.Click
        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Qualifications) Then ShowSecurityError()
        Try
            Dim r As DataRow = SelectedTrainingQualificationsRow
            If Not r Is Nothing Then
                If MessageBox.Show("Are you sure you want to delete this qualification?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    TrainingQualificationsDataView.Table.Rows.Remove(r)
                End If
            End If

            ClearQualificationDetailPanel()
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Engineer Equipment Datagrid"

    Public Sub SetupEngineerEquipmentDataGrid()
        Try
            dgEquipment.TableStyles.Add(New DataGridTableStyle)
            Entity.Sys.Helper.SetUpDataGrid(Me.dgEquipment)
            Dim tStyle As DataGridTableStyle = dgEquipment.TableStyles(0)

            Dim Equipment As New DataGridTextBoxColumn
            Equipment.HeaderText = "Equipment"
            Equipment.MappingName = "Equipment"
            Equipment.NullText = ""
            Equipment.Width = 250
            tStyle.GridColumnStyles.Add(Equipment)

            tStyle.MappingName = "tblEngineerEquipment"
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private _engineerEquipmentDataView As DataView

    Private Property EngineerEquipmentDataView() As DataView
        Get
            Return _engineerEquipmentDataView
        End Get
        Set(ByVal Value As DataView)
            If Not Value Is Nothing Then
                _engineerEquipmentDataView = Value
                _engineerEquipmentDataView.Table.TableName = "tblEngineerEquipment"
            End If
            dgEquipment.DataSource = _engineerEquipmentDataView
        End Set
    End Property

    Public ReadOnly Property SelectedEngineerEquipmentRow() As DataRow
        Get
            If Not EngineerEquipmentDataView Is Nothing Then
                If EngineerEquipmentDataView.Table.Rows.Count > 0 Then
                    Return EngineerEquipmentDataView(Me.dgEquipment.CurrentRowIndex).Row
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Sub PopulateEngineerEquipment()
        Try
            EngineerEquipmentDataView = New DataView(DB.Engineer.GetEquipmentRecords(CurrentEngineer.EngineerID))
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearEquipmentDetailPanel()
        txtEquipmentTool.Text = ""
    End Sub

    Private Sub btnSaveEquipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveEquipment.Click
        Try

            Dim r As DataRow
            r = EngineerEquipmentDataView.Table.NewRow()

            Dim v As BaseValidator = New BaseValidator
            If txtEquipmentTool.Text.Length = 0 Then
                v.AddCriticalMessage("'Equipment\Tool' cannot be empty.")
            End If

            If v.ValidatorMessages.CriticalMessages.Count > 0 Then
                Throw New ValidationException(v)
            End If

            r("Equipment") = txtEquipmentTool.Text

            EngineerEquipmentDataView.Table.Rows.Add(r)

            ClearEquipmentDetailPanel()
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveEngineerEquipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveEngineerEquipment.Click
        Try
            Dim r As DataRow = SelectedEngineerEquipmentRow
            If Not r Is Nothing Then
                If MessageBox.Show("Are you sure you want to delete this equipment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    EngineerEquipmentDataView.Table.Rows.Remove(r)
                End If
            End If

            ClearEquipmentDetailPanel()
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Disciplinaries Datagrid"

    Public Sub SetupDisciplinariesDataGrid()
        Try

            dgDisciplinaries.TableStyles.Add(New DataGridTableStyle)
            Entity.Sys.Helper.SetUpDataGrid(Me.dgDisciplinaries)
            Dim tStyle As DataGridTableStyle = dgDisciplinaries.TableStyles(0)

            Dim Disciplinary As New DataGridTextBoxColumn
            Disciplinary.HeaderText = "Disciplinary"
            Disciplinary.MappingName = "Disciplinary"
            Disciplinary.NullText = ""
            Disciplinary.Width = 150
            tStyle.GridColumnStyles.Add(Disciplinary)

            Dim DisciplinaryStatus As New DataGridTextBoxColumn
            DisciplinaryStatus.HeaderText = "Status"
            DisciplinaryStatus.MappingName = "DisciplinaryStatus"
            DisciplinaryStatus.NullText = ""
            DisciplinaryStatus.Width = 150
            tStyle.GridColumnStyles.Add(DisciplinaryStatus)

            Dim DateIssued As New DataGridTextBoxColumn
            DateIssued.HeaderText = "Date Issued"
            DateIssued.MappingName = "DateIssued"
            DateIssued.NullText = ""
            DateIssued.Width = 80
            tStyle.GridColumnStyles.Add(DateIssued)

            tStyle.MappingName = "tblDisciplinaries"
        Catch ex As Exception

            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private _disciplinariesDataView As DataView

    Private Property DisciplinariesDataView() As DataView
        Get
            Return _disciplinariesDataView
        End Get
        Set(ByVal Value As DataView)
            If Not Value Is Nothing Then
                _disciplinariesDataView = Value
                _disciplinariesDataView.Table.TableName = "tblDisciplinaries"
            End If
            dgDisciplinaries.DataSource = _disciplinariesDataView
        End Set
    End Property

    Public ReadOnly Property SelectedDisciplinariesRow() As DataRow
        Get
            If Not DisciplinariesDataView Is Nothing Then
                If DisciplinariesDataView.Table.Rows.Count > 0 Then
                    Return DisciplinariesDataView(Me.dgDisciplinaries.CurrentRowIndex).Row
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Sub ClearDisciplinaryDetailPanel()
        txtDisciplinaryID.Text = ""
        txtDisciplinary.Text = ""
        dtpDisciplinaryIssued.Checked = False
        cboDisciplinary.SelectedIndex = 0
    End Sub

    Private Sub PopulateDisciplinaries()
        Try
            DisciplinariesDataView = New DataView(DB.Engineer.GetDisciplinaryRecords(CurrentEngineer.EngineerID))
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSaveDisciplinaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveDisciplinaries.Click
        Try

            Dim r As DataRow
            If txtDisciplinaryID.Text.Length = 0 Then
                r = DisciplinariesDataView.Table.NewRow()
                r("DisciplinaryID") = DisciplinariesDataView.Table.Rows.Count + 1
            Else
                r = SelectedDisciplinariesRow
            End If

            Dim v As BaseValidator = New BaseValidator

            If txtDisciplinary.Text.Length = 0 Then
                v.AddCriticalMessage("'Disciplinary' cannot be empty.")
            End If
            If dtpDisciplinaryIssued.Checked = False Then
                v.AddCriticalMessage("'Issued' must have a date.")
            End If

            If cboDisciplinary.SelectedIndex = 0 Then
                v.AddCriticalMessage("'Disciplinary Status' required.")
            End If

            If v.ValidatorMessages.CriticalMessages.Count > 0 Then
                Throw New ValidationException(v)
            End If

            If Not r Is Nothing Then
                r("Disciplinary") = txtDisciplinary.Text
                r("DateIssued") = dtpDisciplinaryIssued.Value
                r("DisciplinaryStatusID") = Combo.GetSelectedItemValue(cboDisciplinary)
                r("DisciplinaryStatus") = Combo.GetSelectedItemDescription(cboDisciplinary)
            End If

            If txtDisciplinaryID.Text.Length = 0 Then
                DisciplinariesDataView.Table.Rows.Add(r)
            Else
                r.AcceptChanges()
            End If

            ClearDisciplinaryDetailPanel()
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddDisciplinaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDisciplinaries.Click
        Try
            ClearDisciplinaryDetailPanel()
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEditDisciplinaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDisciplinaries.Click
        Try
            Dim r As DataRow = SelectedDisciplinariesRow
            If Not r Is Nothing Then
                txtDisciplinaryID.Text = CStr(r("DisciplinaryID"))
                txtDisciplinary.Text = CStr(r("Disciplinary"))
                dtpDisciplinaryIssued.Value = CDate(r("DateIssued"))
                Combo.SetSelectedComboItem_By_Value(cboDisciplinary, CStr(r("DisciplinaryStatusID")))
            End If
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveDisciplinaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveDisciplinaries.Click
        Try
            Dim r As DataRow = SelectedDisciplinariesRow
            If Not r Is Nothing Then
                If MessageBox.Show("Are you sure you want to delete this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    DisciplinariesDataView.Table.Rows.Remove(r)
                End If
            End If

            ClearDisciplinaryDetailPanel()
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Absences"

    Public Sub SetupAbsenceDataGridGrid()

        SuspendLayout()
        Entity.Sys.Helper.SetUpDataGrid(dgAbsences)

        Dim tbStyle As DataGridTableStyle = Me.dgAbsences.TableStyles(0)
        tbStyle.GridColumnStyles.Clear()
        dgAbsences.ReadOnly = True

        Dim UnavailableType As New DataGridLabelColumn
        UnavailableType.MappingName = "Description"
        UnavailableType.HeaderText = "Type"
        UnavailableType.Width = 110
        UnavailableType.NullText = ""
        UnavailableType.ReadOnly = True
        tbStyle.GridColumnStyles.Add(UnavailableType)

        Dim DateFrom As New DataGridLabelColumn
        DateFrom.MappingName = "DateFrom"
        DateFrom.HeaderText = "Date From"
        DateFrom.Format = "dd/MM/yyyy HH:mm"
        DateFrom.Width = 100
        DateFrom.NullText = ""
        DateFrom.ReadOnly = True
        tbStyle.GridColumnStyles.Add(DateFrom)

        Dim DateTo As New DataGridLabelColumn
        DateTo.MappingName = "DateTo"
        DateTo.HeaderText = "Date To"
        DateTo.Format = "dd/MM/yyyy HH:mm"
        DateTo.NullText = ""
        DateTo.Width = 100
        DateTo.ReadOnly = True
        tbStyle.GridColumnStyles.Add(DateTo)

        Dim Comments As New DataGridLabelColumn
        Comments.MappingName = "Comments"
        Comments.HeaderText = "Comments"
        Comments.NullText = ""
        Comments.Width = 200
        Comments.ReadOnly = True
        tbStyle.GridColumnStyles.Add(Comments)

        tbStyle.MappingName = "tblEngineerAbsence"

        dgAbsences.TableStyles.Add(tbStyle)
        ResumeLayout()
    End Sub

    Private _dvAbsences As New DataView

    Public Property AbsencesDataView() As DataView
        Get
            Return _dvAbsences
        End Get
        Set(ByVal Value As DataView)
            _dvAbsences = Value
            _dvAbsences.Table.TableName = "tblEngineerAbsence"
            dgAbsences.DataSource = _dvAbsences
            _dvAbsences.AllowNew = False
            _dvAbsences.AllowEdit = False
            _dvAbsences.AllowDelete = False
        End Set
    End Property

    Private Sub PopulateAbsences()
        Try
            AbsencesDataView = New DataView(DB.EngineerAbsence.GetAbsencesForEngineer(CurrentEngineer.EngineerID))
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboQualificationType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboQualificationType.SelectedIndexChanged
        Try
            Dim skillTypeId As Integer = Entity.Sys.Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboQualificationType))
            If skillTypeId > 0 Then
                Combo.SetUpCombo(cboQualification, DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId).Table, "SkillID", "Skill", Entity.Sys.Enums.ComboValues.Please_Select)
            Else
                Combo.SetUpComboQual(cboQualification, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles lbllWebAppPassword.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtWebAppPassword.TextChanged

    End Sub

#Region "Site Safety Audit"

    Private _auditor As Engineer

    Public Property Auditor() As Engineer
        Get
            Return _auditor
        End Get
        Set
            _auditor = Value
            If Not _auditor Is Nothing Then
                Me.txtAuditor.Text = Auditor.Name
            Else
                Me.txtAuditor.Text = "<Not Set>"
            End If
        End Set
    End Property

    Private SiteSafetyAudit As SiteSafetyAudit

    Private _dvSiteSafetyAudits As DataView

    Private Property DvSiteSafetyAudits() As DataView
        Get
            Return _dvSiteSafetyAudits
        End Get
        Set(ByVal value As DataView)
            _dvSiteSafetyAudits = value
            _dvSiteSafetyAudits.AllowNew = False
            _dvSiteSafetyAudits.AllowEdit = False
            _dvSiteSafetyAudits.AllowDelete = False
            _dvSiteSafetyAudits.Table.TableName = Enums.TableNames.tblEngineer.ToString
            Me.dgSiteSafetyAudits.DataSource = DvSiteSafetyAudits
        End Set
    End Property

    Private ReadOnly Property DrSelectedSiteSafetyAudit() As DataRow
        Get
            If Not Me.dgSiteSafetyAudits.CurrentRowIndex = -1 Then
                Return DvSiteSafetyAudits(Me.dgSiteSafetyAudits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub SetupDgSiteSafetyAudit()
        Helper.SetUpDataGrid(dgSiteSafetyAudits)
        Dim tStyle As DataGridTableStyle = Me.dgSiteSafetyAudits.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim auditDate As New DataGridSiteSafetyAuditColumn
        auditDate.Format = "dd/MM/yyyy"
        auditDate.FormatInfo = Nothing
        auditDate.HeaderText = "Audit Date"
        auditDate.MappingName = "AuditDate"
        auditDate.ReadOnly = True
        auditDate.Width = 100
        auditDate.NullText = ""
        tStyle.GridColumnStyles.Add(auditDate)

        Dim auditor As New DataGridSiteSafetyAuditColumn
        auditor.Format = ""
        auditor.FormatInfo = Nothing
        auditor.HeaderText = "Auditor"
        auditor.MappingName = "Auditor"
        auditor.ReadOnly = True
        auditor.Width = 120
        auditor.NullText = ""
        tStyle.GridColumnStyles.Add(auditor)

        Dim question1 As New DataGridSiteSafetyAuditColumn
        question1.Format = ""
        question1.FormatInfo = Nothing
        question1.HeaderText = "Vehicle Safety & Condition"
        question1.MappingName = "Question1"
        question1.ReadOnly = True
        question1.Width = 120
        question1.NullText = ""
        tStyle.GridColumnStyles.Add(question1)

        Dim question2 As New DataGridSiteSafetyAuditColumn
        question2.Format = ""
        question2.FormatInfo = Nothing
        question2.HeaderText = "Document & Procedures"
        question2.MappingName = "Question2"
        question2.ReadOnly = True
        question2.Width = 120
        question2.NullText = ""
        tStyle.GridColumnStyles.Add(question2)

        Dim question3 As New DataGridSiteSafetyAuditColumn
        question3.Format = ""
        question3.FormatInfo = Nothing
        question3.HeaderText = "Uniform & PPE"
        question3.MappingName = "question3"
        question3.ReadOnly = True
        question3.Width = 120
        question3.NullText = ""
        tStyle.GridColumnStyles.Add(question3)

        Dim question4 As New DataGridSiteSafetyAuditColumn
        question4.Format = ""
        question4.FormatInfo = Nothing
        question4.HeaderText = "Environmental Conditions"
        question4.MappingName = "question4"
        question4.ReadOnly = True
        question4.Width = 120
        question4.NullText = ""
        tStyle.GridColumnStyles.Add(question4)

        Dim question5 As New DataGridSiteSafetyAuditColumn
        question5.Format = ""
        question5.FormatInfo = Nothing
        question5.HeaderText = "Housekeeping"
        question5.MappingName = "question5"
        question5.ReadOnly = True
        question5.Width = 120
        question5.NullText = ""
        tStyle.GridColumnStyles.Add(question5)

        Dim question6 As New DataGridSiteSafetyAuditColumn
        question6.Format = ""
        question6.FormatInfo = Nothing
        question6.HeaderText = "Machinery & Equipment"
        question6.MappingName = "question6"
        question6.ReadOnly = True
        question6.Width = 120
        question6.NullText = ""
        tStyle.GridColumnStyles.Add(question6)

        Dim question7 As New DataGridSiteSafetyAuditColumn
        question7.Format = ""
        question7.FormatInfo = Nothing
        question7.HeaderText = "First Aid & Welfare"
        question7.MappingName = "question7"
        question7.ReadOnly = True
        question7.Width = 120
        question7.NullText = ""
        tStyle.GridColumnStyles.Add(question7)

        Dim question8 As New DataGridSiteSafetyAuditColumn
        question8.Format = ""
        question8.FormatInfo = Nothing
        question8.HeaderText = "Manual Handling"
        question8.MappingName = "question8"
        question8.ReadOnly = True
        question8.Width = 120
        question8.NullText = ""
        tStyle.GridColumnStyles.Add(question8)

        Dim question9 As New DataGridSiteSafetyAuditColumn
        question9.Format = ""
        question9.FormatInfo = Nothing
        question9.HeaderText = "COSSH"
        question9.MappingName = "question9"
        question9.ReadOnly = True
        question9.Width = 120
        question9.NullText = ""
        tStyle.GridColumnStyles.Add(question9)

        Dim question10 As New DataGridSiteSafetyAuditColumn
        question10.Format = ""
        question10.FormatInfo = Nothing
        question10.HeaderText = "Working At Height"
        question10.MappingName = "question10"
        question10.ReadOnly = True
        question10.Width = 120
        question10.NullText = ""
        tStyle.GridColumnStyles.Add(question10)

        Dim question11 As New DataGridSiteSafetyAuditColumn
        question11.Format = ""
        question11.FormatInfo = Nothing
        question11.HeaderText = "Asbestos"
        question11.MappingName = "question11"
        question11.ReadOnly = True
        question11.Width = 120
        question11.NullText = ""
        tStyle.GridColumnStyles.Add(question11)

        Dim result As New DataGridSiteSafetyAuditColumn
        result.Format = ""
        result.FormatInfo = Nothing
        result.HeaderText = "Total"
        result.MappingName = "result"
        result.ReadOnly = True
        result.Width = 120
        result.NullText = ""
        tStyle.GridColumnStyles.Add(result)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.tblEngineer.ToString
        Me.dgSiteSafetyAudits.TableStyles.Add(tStyle)

    End Sub

    Public Sub PopulateSiteSafetyAuditDataGrid()
        Try
            DvSiteSafetyAudits = DB.SiteSafteyAudit.Get_As_DataView(CurrentEngineer.EngineerID, Entity.Engineers.SiteSafetyAudits.Enums.GetBy.EngineerId)
        Catch ex As Exception
            ShowMessage("Cannot load datagrid: " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSaveAudit_Click(sender As Object, e As EventArgs) Handles btnSaveAudit.Click
        If CurrentEngineer Is Nothing Then Exit Sub
        If Not ShowMessage("Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Exit Sub
        End If

        If SiteSafetyAudit Is Nothing Then
            SiteSafetyAudit = New SiteSafetyAudit
        End If

        With SiteSafetyAudit
            .EngineerId = CurrentEngineer.EngineerID
            .Department = CurrentEngineer.Department
            .AuditDate = dtpAuditDate.Value
            .Question1 = Helper.MakeDoubleValid(txtVehicleSafetyCondition.Text)
            .Question2 = Helper.MakeDoubleValid(txtDocumentProcedures.Text)
            .Question3 = Helper.MakeDoubleValid(txtUniformPPE.Text)
            .Question4 = Helper.MakeDoubleValid(txtEnvironmentalConditions.Text)
            .Question5 = Helper.MakeDoubleValid(txtHousekeeping.Text)
            .Question6 = Helper.MakeDoubleValid(txtMachineryEquipment.Text)
            .Question7 = Helper.MakeDoubleValid(txtFirstAidWelfare.Text)
            .Question8 = Helper.MakeDoubleValid(txtManualHandling.Text)
            .Question9 = Helper.MakeDoubleValid(txtCOSSH.Text)
            .Question10 = Helper.MakeDoubleValid(txtWorkingAtHeight.Text)
            .Question11 = Helper.MakeDoubleValid(txtAsbestos.Text)
            .Result = Helper.MakeDoubleValid(txtTotal.Text)
            .AuditorId = Helper.MakeIntegerValid(Auditor?.EngineerID)
        End With

        Dim isValid As Boolean = True
        Dim props() As PropertyInfo = SiteSafetyAudit.GetType().GetProperties()
        For Each prop As PropertyInfo In props
            If prop.PropertyType().Name = GetType(Double).Name Then
                Dim score As Double = prop.GetValue(SiteSafetyAudit, Nothing)
                If score < -1 Or score > 100 Then
                    isValid = False
                End If
            End If
        Next

        If Not isValid Then
            ShowMessage("Please ensure values are between 0 & 100!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If SiteSafetyAudit.AuditDate > Now Then
            ShowMessage("Audit date cannot be in the future!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If SiteSafetyAudit.Id > 0 Then
            DB.SiteSafteyAudit.Update(SiteSafetyAudit)
        Else
            SiteSafetyAudit = DB.SiteSafteyAudit.Insert(SiteSafetyAudit)
        End If

        PopulateSiteSafetyAuditDataGrid()
        ClearAuditForm()
    End Sub

    Private Sub btnNewAudit_Click(sender As Object, e As EventArgs) Handles btnNewAudit.Click
        ClearAuditForm()
    End Sub

    Private Sub ClearAuditForm()
        SiteSafetyAudit = Nothing
        dtpAuditDate.Value = Now
        txtVehicleSafetyCondition.Text = ""
        txtDocumentProcedures.Text = ""
        txtUniformPPE.Text = ""
        txtEnvironmentalConditions.Text = ""
        txtHousekeeping.Text = ""
        txtMachineryEquipment.Text = ""
        txtFirstAidWelfare.Text = ""
        txtManualHandling.Text = ""
        txtCOSSH.Text = ""
        txtWorkingAtHeight.Text = ""
        txtAsbestos.Text = ""
        txtTotal.Text = ""
        Auditor = Nothing
    End Sub

    Private Sub btnDeleteAudit_Click(sender As Object, e As EventArgs) Handles btnDeleteAudit.Click
        If DrSelectedSiteSafetyAudit Is Nothing Then
            ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            Cursor.Current = Cursors.WaitCursor
            DB.SiteSafteyAudit.Delete(DrSelectedSiteSafetyAudit("Id"))
            PopulateSiteSafetyAuditDataGrid()
            ClearAuditForm()
        Catch ex As Exception
            ShowMessage("Error deleting: " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub dgSiteSafetyAudits_Click(sender As Object, e As EventArgs) Handles dgSiteSafetyAudits.Click
        If DrSelectedSiteSafetyAudit Is Nothing Then
            Exit Sub
        End If
        SiteSafetyAudit = DB.SiteSafteyAudit.Get_As_Entity(DrSelectedSiteSafetyAudit("Id"), Entity.Engineers.SiteSafetyAudits.Enums.GetBy.Id)?.FirstOrDefault()
        If SiteSafetyAudit IsNot Nothing Then
            With SiteSafetyAudit
                dtpAuditDate.Value = .AuditDate
                txtVehicleSafetyCondition.Text = .Question1
                txtDocumentProcedures.Text = .Question2
                txtUniformPPE.Text = .Question3
                txtEnvironmentalConditions.Text = .Question4
                txtHousekeeping.Text = .Question5
                txtMachineryEquipment.Text = .Question6
                txtFirstAidWelfare.Text = .Question7
                txtManualHandling.Text = .Question8
                txtCOSSH.Text = .Question9
                txtWorkingAtHeight.Text = .Question10
                txtAsbestos.Text = .Question11
                txtTotal.Text = .Result
                Auditor = DB.Engineer.Engineer_Get(.AuditorId)
            End With
        End If

    End Sub

    Private Sub btnfindEngineer_Click(sender As Object, e As EventArgs) Handles btnfindEngineer.Click
        Dim ID As Integer = FindRecord(Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            Auditor = DB.Engineer.Engineer_Get(ID)
        End If
    End Sub

    Private Sub cboLinkToUser_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboLinkToUser.SelectionChangeCommitted
        If Me.cboLinkToUser.SelectedValue Is Nothing Then
            Dim userId As Integer = Combo.GetSelectedItemValue(cboLinkToUser)
            If (DB.Engineer.UserIsLinkedToEngineer(userId)) Then
                ShowMessage("This user is already linked to an engineer. Please try another user.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboLinkToUser.SelectedIndex = 0
            End If
        End If
    End Sub

#End Region

#End Region

End Class