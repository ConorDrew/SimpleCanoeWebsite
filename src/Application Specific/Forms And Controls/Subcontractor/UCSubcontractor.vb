Imports System.Linq
Imports FSM.Entity.Sys

Public Class UCSubcontractor : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        TabControl1.TabPages.Clear()
        TabControl1.TabPages.Add(tpContact)
        TabControl1.TabPages.Add(tpMain)
        TabControl1.TabPages.Add(tabMaxSor)
        TabControl1.TabPages.Add(tpPostalRegions)
        TabControl1.TabPages.Add(tpTrainingQualifications)
        TabControl1.TabPages.Add(tpWages)
        TabControl1.TabPages.Add(tpHolidayAbsences)
        TabControl1.TabPages.Add(tpDisciplinary)
        TabControl1.TabPages.Add(tpKit)
        TabControl1.TabPages.Add(tpDocuments)

        Combo.SetUpCombo(Me.cboLinkToSupplier, DB.Supplier.Supplier_GetAll.Table, "SupplierID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        Combo.SetUpCombo(Me.cboRegion, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPayGrade, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PayGrades).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboTaxRate, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.SubTaxRate).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboDisciplinary, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.DisciplinaryStatus).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboQualification, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboEngineerGroup, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.EngineerGroup).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPayGrade, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PayGrades).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboDisciplinary, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.DisciplinaryStatus).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboQualificationType, DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpComboQual(cboQualification, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboUser, DB.User.GetAll().Table, "UserID", "FullName", Entity.Sys.Enums.ComboValues.Not_Applicable)

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

    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress3 As System.Windows.Forms.Label
    Friend WithEvents txtAddress4 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress4 As System.Windows.Forms.Label
    Friend WithEvents txtAddress5 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress5 As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents lblPostcode As System.Windows.Forms.Label
    Friend WithEvents txtTelephoneNum As System.Windows.Forms.TextBox
    Friend WithEvents lblTelephoneNum As System.Windows.Forms.Label
    Friend WithEvents txtFaxNum As System.Windows.Forms.TextBox
    Friend WithEvents lblFaxNum As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents grpEngineer As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDrivingLicenceIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDrivingLicenseDate As System.Windows.Forms.Label
    Friend WithEvents txtDrivingLicenceNo As System.Windows.Forms.TextBox
    Friend WithEvents lblDrivingLicense As System.Windows.Forms.Label
    Friend WithEvents txtStartingDetails As System.Windows.Forms.TextBox
    Friend WithEvents lblStartDetails As System.Windows.Forms.Label
    Friend WithEvents txtNextOfKinContact As System.Windows.Forms.TextBox
    Friend WithEvents lblNextOfKinDetails As System.Windows.Forms.Label
    Friend WithEvents txtNextOfKinName As System.Windows.Forms.TextBox
    Friend WithEvents lblNextOfKin As System.Windows.Forms.Label
    Friend WithEvents btnVanHistory As System.Windows.Forms.Button
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents lblPDAID As System.Windows.Forms.Label
    Friend WithEvents chkApprentice As System.Windows.Forms.CheckBox
    Friend WithEvents tpWages As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCostToCompanyDouble As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCostToCompanyTimeHalf As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCostToCompanyNormal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNINumber As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboPayGrade As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAnnualSalary As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tpTrainingQualifications As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboQualification As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtQualificatioNote As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnSaveQualification As System.Windows.Forms.Button
    Friend WithEvents dtpQualificationExpires As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpQualificationPassed As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnRemoveTrainingQualifications As System.Windows.Forms.Button
    Friend WithEvents dgTrainingQualifications As System.Windows.Forms.DataGrid
    Friend WithEvents tpKit As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtEquipmentTool As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnSaveEquipment As System.Windows.Forms.Button
    Friend WithEvents btnRemoveEngineerEquipment As System.Windows.Forms.Button
    Friend WithEvents dgEquipment As System.Windows.Forms.DataGrid
    Friend WithEvents tpDisciplinary As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddDisciplinaries As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtDisciplinaryID As System.Windows.Forms.TextBox
    Friend WithEvents cboDisciplinary As System.Windows.Forms.ComboBox
    Friend WithEvents btnSaveDisciplinaries As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dtpDisciplinaryIssued As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtDisciplinary As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnRemoveDisciplinaries As System.Windows.Forms.Button
    Friend WithEvents btnEditDisciplinaries As System.Windows.Forms.Button
    Friend WithEvents dgDisciplinaries As System.Windows.Forms.DataGrid
    Friend WithEvents tpDocuments As System.Windows.Forms.TabPage
    Friend WithEvents pnlDocuments As System.Windows.Forms.Panel
    Friend WithEvents tpHolidayAbsences As System.Windows.Forms.TabPage
    Friend WithEvents grpAbsences As System.Windows.Forms.GroupBox
    Friend WithEvents dgAbsences As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDaysHolidayAllowed As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtHolidayYearEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtHolidayYearStart As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tpPostalRegions As System.Windows.Forms.TabPage
    Friend WithEvents tpContact As System.Windows.Forms.TabPage
    Friend WithEvents txtPDAID As System.Windows.Forms.TextBox
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents cboLinkToSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents lblLinkToSupplier As System.Windows.Forms.Label
    Friend WithEvents tabMaxSor As TabPage
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents txtDailyServiceLimit As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents txtSundayValue As TextBox
    Friend WithEvents txtSaturdayValue As TextBox
    Friend WithEvents txtFridayValue As TextBox
    Friend WithEvents txtThursdayValue As TextBox
    Friend WithEvents txtWednesdayValue As TextBox
    Friend WithEvents txtTuesdayValue As TextBox
    Friend WithEvents txtMondayValue As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents cboUser As ComboBox
    Friend WithEvents txtOftecNo As TextBox
    Friend WithEvents txtTechnician As TextBox
    Friend WithEvents txtGasSafeNo As TextBox
    Friend WithEvents txtEngineerID As TextBox
    Friend WithEvents lblOftecNo As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents lblManager As Label
    Friend WithEvents lblTechnician As Label
    Friend WithEvents cboEngineerGroup As ComboBox
    Friend WithEvents Label37 As Label
    Friend WithEvents lblGasSafeId As Label
    Friend WithEvents lblEngID As Label
    Friend WithEvents txtBreakPri As TextBox
    Friend WithEvents txtServPri As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents dtpQualificationBooked As DateTimePicker
    Friend WithEvents Label36 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents grpPostalRegions As GroupBox
    Friend WithEvents Label38 As Label
    Friend WithEvents txtPCSearch As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dgUnTicked As DataGrid
    Friend WithEvents dgPostalRegions As DataGrid
    Friend WithEvents cboQualificationType As ComboBox
    Friend WithEvents lblQualificationType As Label
    Friend WithEvents cboTaxRate As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.lblAddress1 = New System.Windows.Forms.Label()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.lblAddress2 = New System.Windows.Forms.Label()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.lblAddress3 = New System.Windows.Forms.Label()
        Me.txtAddress4 = New System.Windows.Forms.TextBox()
        Me.lblAddress4 = New System.Windows.Forms.Label()
        Me.txtAddress5 = New System.Windows.Forms.TextBox()
        Me.lblAddress5 = New System.Windows.Forms.Label()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.lblPostcode = New System.Windows.Forms.Label()
        Me.txtTelephoneNum = New System.Windows.Forms.TextBox()
        Me.lblTelephoneNum = New System.Windows.Forms.Label()
        Me.txtFaxNum = New System.Windows.Forms.TextBox()
        Me.lblFaxNum = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpContact = New System.Windows.Forms.TabPage()
        Me.cboTaxRate = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboLinkToSupplier = New System.Windows.Forms.ComboBox()
        Me.lblLinkToSupplier = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.grpEngineer = New System.Windows.Forms.GroupBox()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.txtOftecNo = New System.Windows.Forms.TextBox()
        Me.txtTechnician = New System.Windows.Forms.TextBox()
        Me.txtGasSafeNo = New System.Windows.Forms.TextBox()
        Me.txtEngineerID = New System.Windows.Forms.TextBox()
        Me.lblOftecNo = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblManager = New System.Windows.Forms.Label()
        Me.lblTechnician = New System.Windows.Forms.Label()
        Me.cboEngineerGroup = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lblGasSafeId = New System.Windows.Forms.Label()
        Me.lblEngID = New System.Windows.Forms.Label()
        Me.dtpDrivingLicenceIssueDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDrivingLicenseDate = New System.Windows.Forms.Label()
        Me.txtDrivingLicenceNo = New System.Windows.Forms.TextBox()
        Me.lblDrivingLicense = New System.Windows.Forms.Label()
        Me.txtStartingDetails = New System.Windows.Forms.TextBox()
        Me.lblStartDetails = New System.Windows.Forms.Label()
        Me.txtNextOfKinContact = New System.Windows.Forms.TextBox()
        Me.lblNextOfKinDetails = New System.Windows.Forms.Label()
        Me.txtNextOfKinName = New System.Windows.Forms.TextBox()
        Me.lblNextOfKin = New System.Windows.Forms.Label()
        Me.btnVanHistory = New System.Windows.Forms.Button()
        Me.txtPDAID = New System.Windows.Forms.TextBox()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.lblPDAID = New System.Windows.Forms.Label()
        Me.chkApprentice = New System.Windows.Forms.CheckBox()
        Me.tabMaxSor = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtBreakPri = New System.Windows.Forms.TextBox()
        Me.txtServPri = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtDailyServiceLimit = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtSundayValue = New System.Windows.Forms.TextBox()
        Me.txtSaturdayValue = New System.Windows.Forms.TextBox()
        Me.txtFridayValue = New System.Windows.Forms.TextBox()
        Me.txtThursdayValue = New System.Windows.Forms.TextBox()
        Me.txtWednesdayValue = New System.Windows.Forms.TextBox()
        Me.txtTuesdayValue = New System.Windows.Forms.TextBox()
        Me.txtMondayValue = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.tpWages = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCostToCompanyDouble = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCostToCompanyTimeHalf = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCostToCompanyNormal = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNINumber = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboPayGrade = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAnnualSalary = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tpTrainingQualifications = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboQualificationType = New System.Windows.Forms.ComboBox()
        Me.lblQualificationType = New System.Windows.Forms.Label()
        Me.dtpQualificationBooked = New System.Windows.Forms.DateTimePicker()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cboQualification = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtQualificatioNote = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnSaveQualification = New System.Windows.Forms.Button()
        Me.dtpQualificationExpires = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtpQualificationPassed = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnRemoveTrainingQualifications = New System.Windows.Forms.Button()
        Me.dgTrainingQualifications = New System.Windows.Forms.DataGrid()
        Me.tpKit = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtEquipmentTool = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
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
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpDisciplinaryIssued = New System.Windows.Forms.DateTimePicker()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtDisciplinary = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
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
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtHolidayYearEnd = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtHolidayYearStart = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tpPostalRegions = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpPostalRegions = New System.Windows.Forms.GroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtPCSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgUnTicked = New System.Windows.Forms.DataGrid()
        Me.dgPostalRegions = New System.Windows.Forms.DataGrid()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.tpContact.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.grpEngineer.SuspendLayout()
        Me.tabMaxSor.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.tpWages.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.GroupBox2.SuspendLayout()
        Me.grpPostalRegions.SuspendLayout()
        CType(Me.dgUnTicked, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPostalRegions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(112, 16)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(504, 21)
        Me.txtName.TabIndex = 1
        Me.txtName.Tag = "Subcontractor.Name"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(8, 16)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(53, 20)
        Me.lblName.TabIndex = 31
        Me.lblName.Text = "Name"
        '
        'txtAddress1
        '
        Me.txtAddress1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress1.Location = New System.Drawing.Point(112, 48)
        Me.txtAddress1.MaxLength = 255
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(504, 21)
        Me.txtAddress1.TabIndex = 2
        Me.txtAddress1.Tag = "Subcontractor.Address1"
        '
        'lblAddress1
        '
        Me.lblAddress1.Location = New System.Drawing.Point(8, 48)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(78, 20)
        Me.lblAddress1.TabIndex = 31
        Me.lblAddress1.Text = "Address 1"
        '
        'txtAddress2
        '
        Me.txtAddress2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress2.Location = New System.Drawing.Point(112, 80)
        Me.txtAddress2.MaxLength = 255
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(504, 21)
        Me.txtAddress2.TabIndex = 3
        Me.txtAddress2.Tag = "Subcontractor.Address2"
        '
        'lblAddress2
        '
        Me.lblAddress2.Location = New System.Drawing.Point(8, 80)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(73, 20)
        Me.lblAddress2.TabIndex = 31
        Me.lblAddress2.Text = "Address 2"
        '
        'txtAddress3
        '
        Me.txtAddress3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress3.Location = New System.Drawing.Point(112, 112)
        Me.txtAddress3.MaxLength = 255
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(504, 21)
        Me.txtAddress3.TabIndex = 4
        Me.txtAddress3.Tag = "Subcontractor.Address3"
        '
        'lblAddress3
        '
        Me.lblAddress3.Location = New System.Drawing.Point(8, 112)
        Me.lblAddress3.Name = "lblAddress3"
        Me.lblAddress3.Size = New System.Drawing.Size(66, 20)
        Me.lblAddress3.TabIndex = 31
        Me.lblAddress3.Text = "Address 3"
        '
        'txtAddress4
        '
        Me.txtAddress4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress4.Location = New System.Drawing.Point(112, 144)
        Me.txtAddress4.MaxLength = 255
        Me.txtAddress4.Name = "txtAddress4"
        Me.txtAddress4.Size = New System.Drawing.Size(504, 21)
        Me.txtAddress4.TabIndex = 5
        Me.txtAddress4.Tag = "Subcontractor.Address4"
        '
        'lblAddress4
        '
        Me.lblAddress4.Location = New System.Drawing.Point(8, 144)
        Me.lblAddress4.Name = "lblAddress4"
        Me.lblAddress4.Size = New System.Drawing.Size(67, 20)
        Me.lblAddress4.TabIndex = 31
        Me.lblAddress4.Text = "Address 4"
        '
        'txtAddress5
        '
        Me.txtAddress5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress5.Location = New System.Drawing.Point(112, 176)
        Me.txtAddress5.MaxLength = 255
        Me.txtAddress5.Name = "txtAddress5"
        Me.txtAddress5.Size = New System.Drawing.Size(504, 21)
        Me.txtAddress5.TabIndex = 6
        Me.txtAddress5.Tag = "Subcontractor.Address5"
        '
        'lblAddress5
        '
        Me.lblAddress5.Location = New System.Drawing.Point(8, 176)
        Me.lblAddress5.Name = "lblAddress5"
        Me.lblAddress5.Size = New System.Drawing.Size(79, 20)
        Me.lblAddress5.TabIndex = 31
        Me.lblAddress5.Text = "Address 5"
        '
        'txtPostcode
        '
        Me.txtPostcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostcode.Location = New System.Drawing.Point(112, 208)
        Me.txtPostcode.MaxLength = 20
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(504, 21)
        Me.txtPostcode.TabIndex = 7
        Me.txtPostcode.Tag = "Subcontractor.Postcode"
        '
        'lblPostcode
        '
        Me.lblPostcode.Location = New System.Drawing.Point(8, 208)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(72, 20)
        Me.lblPostcode.TabIndex = 31
        Me.lblPostcode.Text = "Postcode"
        '
        'txtTelephoneNum
        '
        Me.txtTelephoneNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelephoneNum.Location = New System.Drawing.Point(112, 240)
        Me.txtTelephoneNum.MaxLength = 50
        Me.txtTelephoneNum.Name = "txtTelephoneNum"
        Me.txtTelephoneNum.Size = New System.Drawing.Size(504, 21)
        Me.txtTelephoneNum.TabIndex = 8
        Me.txtTelephoneNum.Tag = "Subcontractor.TelephoneNum"
        '
        'lblTelephoneNum
        '
        Me.lblTelephoneNum.Location = New System.Drawing.Point(8, 240)
        Me.lblTelephoneNum.Name = "lblTelephoneNum"
        Me.lblTelephoneNum.Size = New System.Drawing.Size(113, 20)
        Me.lblTelephoneNum.TabIndex = 31
        Me.lblTelephoneNum.Text = "Telephone"
        '
        'txtFaxNum
        '
        Me.txtFaxNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFaxNum.Location = New System.Drawing.Point(112, 272)
        Me.txtFaxNum.MaxLength = 50
        Me.txtFaxNum.Name = "txtFaxNum"
        Me.txtFaxNum.Size = New System.Drawing.Size(504, 21)
        Me.txtFaxNum.TabIndex = 9
        Me.txtFaxNum.Tag = "Subcontractor.FaxNum"
        '
        'lblFaxNum
        '
        Me.lblFaxNum.Location = New System.Drawing.Point(8, 272)
        Me.lblFaxNum.Name = "lblFaxNum"
        Me.lblFaxNum.Size = New System.Drawing.Size(73, 20)
        Me.lblFaxNum.TabIndex = 31
        Me.lblFaxNum.Text = "Fax"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(112, 304)
        Me.txtEmailAddress.MaxLength = 255
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(504, 21)
        Me.txtEmailAddress.TabIndex = 10
        Me.txtEmailAddress.Tag = "Subcontractor.EmailAddress"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(8, 304)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(103, 20)
        Me.lblEmailAddress.TabIndex = 31
        Me.lblEmailAddress.Text = "Email Address"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(112, 409)
        Me.txtNotes.MaxLength = 0
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(504, 194)
        Me.txtNotes.TabIndex = 13
        Me.txtNotes.Tag = "Subcontractor.Notes"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpContact)
        Me.TabControl1.Controls.Add(Me.tpMain)
        Me.TabControl1.Controls.Add(Me.tabMaxSor)
        Me.TabControl1.Controls.Add(Me.tpWages)
        Me.TabControl1.Controls.Add(Me.tpTrainingQualifications)
        Me.TabControl1.Controls.Add(Me.tpKit)
        Me.TabControl1.Controls.Add(Me.tpDisciplinary)
        Me.TabControl1.Controls.Add(Me.tpDocuments)
        Me.TabControl1.Controls.Add(Me.tpHolidayAbsences)
        Me.TabControl1.Controls.Add(Me.tpPostalRegions)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(632, 648)
        Me.TabControl1.TabIndex = 2
        '
        'tpContact
        '
        Me.tpContact.Controls.Add(Me.cboTaxRate)
        Me.tpContact.Controls.Add(Me.Label3)
        Me.tpContact.Controls.Add(Me.cboLinkToSupplier)
        Me.tpContact.Controls.Add(Me.lblLinkToSupplier)
        Me.tpContact.Controls.Add(Me.lblNotes)
        Me.tpContact.Controls.Add(Me.lblFaxNum)
        Me.tpContact.Controls.Add(Me.txtEmailAddress)
        Me.tpContact.Controls.Add(Me.lblEmailAddress)
        Me.tpContact.Controls.Add(Me.txtNotes)
        Me.tpContact.Controls.Add(Me.txtName)
        Me.tpContact.Controls.Add(Me.lblName)
        Me.tpContact.Controls.Add(Me.txtAddress1)
        Me.tpContact.Controls.Add(Me.lblAddress1)
        Me.tpContact.Controls.Add(Me.txtAddress2)
        Me.tpContact.Controls.Add(Me.lblAddress2)
        Me.tpContact.Controls.Add(Me.txtAddress3)
        Me.tpContact.Controls.Add(Me.lblAddress3)
        Me.tpContact.Controls.Add(Me.txtAddress4)
        Me.tpContact.Controls.Add(Me.lblAddress4)
        Me.tpContact.Controls.Add(Me.txtAddress5)
        Me.tpContact.Controls.Add(Me.lblAddress5)
        Me.tpContact.Controls.Add(Me.txtPostcode)
        Me.tpContact.Controls.Add(Me.lblPostcode)
        Me.tpContact.Controls.Add(Me.txtTelephoneNum)
        Me.tpContact.Controls.Add(Me.lblTelephoneNum)
        Me.tpContact.Controls.Add(Me.txtFaxNum)
        Me.tpContact.Location = New System.Drawing.Point(4, 22)
        Me.tpContact.Name = "tpContact"
        Me.tpContact.Size = New System.Drawing.Size(624, 622)
        Me.tpContact.TabIndex = 8
        Me.tpContact.Text = "Contact Details"
        '
        'cboTaxRate
        '
        Me.cboTaxRate.FormattingEnabled = True
        Me.cboTaxRate.Location = New System.Drawing.Point(112, 372)
        Me.cboTaxRate.Name = "cboTaxRate"
        Me.cboTaxRate.Size = New System.Drawing.Size(504, 21)
        Me.cboTaxRate.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 375)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Tax Rate"
        '
        'cboLinkToSupplier
        '
        Me.cboLinkToSupplier.FormattingEnabled = True
        Me.cboLinkToSupplier.Location = New System.Drawing.Point(112, 338)
        Me.cboLinkToSupplier.Name = "cboLinkToSupplier"
        Me.cboLinkToSupplier.Size = New System.Drawing.Size(504, 21)
        Me.cboLinkToSupplier.TabIndex = 36
        '
        'lblLinkToSupplier
        '
        Me.lblLinkToSupplier.Location = New System.Drawing.Point(8, 341)
        Me.lblLinkToSupplier.Name = "lblLinkToSupplier"
        Me.lblLinkToSupplier.Size = New System.Drawing.Size(103, 20)
        Me.lblLinkToSupplier.TabIndex = 35
        Me.lblLinkToSupplier.Text = "Link To Supplier"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(8, 412)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(103, 20)
        Me.lblNotes.TabIndex = 32
        Me.lblNotes.Text = "Notes"
        '
        'tpMain
        '
        Me.tpMain.Controls.Add(Me.grpEngineer)
        Me.tpMain.Location = New System.Drawing.Point(4, 22)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Size = New System.Drawing.Size(624, 622)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Engineer Details"
        '
        'grpEngineer
        '
        Me.grpEngineer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineer.Controls.Add(Me.cboDepartment)
        Me.grpEngineer.Controls.Add(Me.cboUser)
        Me.grpEngineer.Controls.Add(Me.txtOftecNo)
        Me.grpEngineer.Controls.Add(Me.txtTechnician)
        Me.grpEngineer.Controls.Add(Me.txtGasSafeNo)
        Me.grpEngineer.Controls.Add(Me.txtEngineerID)
        Me.grpEngineer.Controls.Add(Me.lblOftecNo)
        Me.grpEngineer.Controls.Add(Me.lblDepartment)
        Me.grpEngineer.Controls.Add(Me.lblManager)
        Me.grpEngineer.Controls.Add(Me.lblTechnician)
        Me.grpEngineer.Controls.Add(Me.cboEngineerGroup)
        Me.grpEngineer.Controls.Add(Me.Label37)
        Me.grpEngineer.Controls.Add(Me.lblGasSafeId)
        Me.grpEngineer.Controls.Add(Me.lblEngID)
        Me.grpEngineer.Controls.Add(Me.dtpDrivingLicenceIssueDate)
        Me.grpEngineer.Controls.Add(Me.lblDrivingLicenseDate)
        Me.grpEngineer.Controls.Add(Me.txtDrivingLicenceNo)
        Me.grpEngineer.Controls.Add(Me.lblDrivingLicense)
        Me.grpEngineer.Controls.Add(Me.txtStartingDetails)
        Me.grpEngineer.Controls.Add(Me.lblStartDetails)
        Me.grpEngineer.Controls.Add(Me.txtNextOfKinContact)
        Me.grpEngineer.Controls.Add(Me.lblNextOfKinDetails)
        Me.grpEngineer.Controls.Add(Me.txtNextOfKinName)
        Me.grpEngineer.Controls.Add(Me.lblNextOfKin)
        Me.grpEngineer.Controls.Add(Me.btnVanHistory)
        Me.grpEngineer.Controls.Add(Me.txtPDAID)
        Me.grpEngineer.Controls.Add(Me.cboRegion)
        Me.grpEngineer.Controls.Add(Me.lblRegion)
        Me.grpEngineer.Controls.Add(Me.lblPDAID)
        Me.grpEngineer.Controls.Add(Me.chkApprentice)
        Me.grpEngineer.Location = New System.Drawing.Point(8, 0)
        Me.grpEngineer.Name = "grpEngineer"
        Me.grpEngineer.Size = New System.Drawing.Size(608, 616)
        Me.grpEngineer.TabIndex = 0
        Me.grpEngineer.TabStop = False
        Me.grpEngineer.Text = "Details"
        '
        'cboUser
        '
        Me.cboUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.Location = New System.Drawing.Point(121, 172)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(470, 21)
        Me.cboUser.TabIndex = 72
        Me.cboUser.Tag = ""
        '
        'txtOftecNo
        '
        Me.txtOftecNo.Location = New System.Drawing.Point(512, 18)
        Me.txtOftecNo.Name = "txtOftecNo"
        Me.txtOftecNo.Size = New System.Drawing.Size(79, 21)
        Me.txtOftecNo.TabIndex = 70
        Me.txtOftecNo.Tag = "Engineer.Name"
        '
        'txtTechnician
        '
        Me.txtTechnician.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTechnician.Location = New System.Drawing.Point(121, 134)
        Me.txtTechnician.Name = "txtTechnician"
        Me.txtTechnician.Size = New System.Drawing.Size(470, 21)
        Me.txtTechnician.TabIndex = 61
        Me.txtTechnician.Tag = ""
        '
        'txtGasSafeNo
        '
        Me.txtGasSafeNo.Location = New System.Drawing.Point(333, 18)
        Me.txtGasSafeNo.Name = "txtGasSafeNo"
        Me.txtGasSafeNo.Size = New System.Drawing.Size(79, 21)
        Me.txtGasSafeNo.TabIndex = 59
        Me.txtGasSafeNo.Tag = "Engineer.Name"
        '
        'txtEngineerID
        '
        Me.txtEngineerID.Location = New System.Drawing.Point(121, 20)
        Me.txtEngineerID.Name = "txtEngineerID"
        Me.txtEngineerID.ReadOnly = True
        Me.txtEngineerID.Size = New System.Drawing.Size(79, 21)
        Me.txtEngineerID.TabIndex = 62
        Me.txtEngineerID.TabStop = False
        '
        'lblOftecNo
        '
        Me.lblOftecNo.Location = New System.Drawing.Point(438, 21)
        Me.lblOftecNo.Name = "lblOftecNo"
        Me.lblOftecNo.Size = New System.Drawing.Size(68, 20)
        Me.lblOftecNo.TabIndex = 71
        Me.lblOftecNo.Text = "Oftec No."
        '
        'lblDepartment
        '
        Me.lblDepartment.Location = New System.Drawing.Point(5, 99)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(104, 20)
        Me.lblDepartment.TabIndex = 69
        Me.lblDepartment.Text = "Department"
        '
        'lblManager
        '
        Me.lblManager.Location = New System.Drawing.Point(5, 175)
        Me.lblManager.Name = "lblManager"
        Me.lblManager.Size = New System.Drawing.Size(104, 20)
        Me.lblManager.TabIndex = 67
        Me.lblManager.Text = "Manager"
        '
        'lblTechnician
        '
        Me.lblTechnician.Location = New System.Drawing.Point(6, 137)
        Me.lblTechnician.Name = "lblTechnician"
        Me.lblTechnician.Size = New System.Drawing.Size(104, 20)
        Me.lblTechnician.TabIndex = 66
        Me.lblTechnician.Text = "Technician"
        '
        'cboEngineerGroup
        '
        Me.cboEngineerGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEngineerGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboEngineerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEngineerGroup.Location = New System.Drawing.Point(121, 58)
        Me.cboEngineerGroup.Name = "cboEngineerGroup"
        Me.cboEngineerGroup.Size = New System.Drawing.Size(470, 21)
        Me.cboEngineerGroup.TabIndex = 60
        Me.cboEngineerGroup.Tag = ""
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(5, 61)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(105, 20)
        Me.Label37.TabIndex = 65
        Me.Label37.Text = "Engineer Group"
        '
        'lblGasSafeId
        '
        Me.lblGasSafeId.Location = New System.Drawing.Point(223, 23)
        Me.lblGasSafeId.Name = "lblGasSafeId"
        Me.lblGasSafeId.Size = New System.Drawing.Size(90, 20)
        Me.lblGasSafeId.TabIndex = 64
        Me.lblGasSafeId.Text = "Gas Safe No."
        '
        'lblEngID
        '
        Me.lblEngID.Location = New System.Drawing.Point(6, 23)
        Me.lblEngID.Name = "lblEngID"
        Me.lblEngID.Size = New System.Drawing.Size(94, 20)
        Me.lblEngID.TabIndex = 63
        Me.lblEngID.Text = "Engineer ID"
        '
        'dtpDrivingLicenceIssueDate
        '
        Me.dtpDrivingLicenceIssueDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDrivingLicenceIssueDate.Checked = False
        Me.dtpDrivingLicenceIssueDate.Location = New System.Drawing.Point(441, 377)
        Me.dtpDrivingLicenceIssueDate.Name = "dtpDrivingLicenceIssueDate"
        Me.dtpDrivingLicenceIssueDate.ShowCheckBox = True
        Me.dtpDrivingLicenceIssueDate.Size = New System.Drawing.Size(150, 21)
        Me.dtpDrivingLicenceIssueDate.TabIndex = 7
        '
        'lblDrivingLicenseDate
        '
        Me.lblDrivingLicenseDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDrivingLicenseDate.Location = New System.Drawing.Point(359, 380)
        Me.lblDrivingLicenseDate.Name = "lblDrivingLicenseDate"
        Me.lblDrivingLicenseDate.Size = New System.Drawing.Size(112, 20)
        Me.lblDrivingLicenseDate.TabIndex = 41
        Me.lblDrivingLicenseDate.Text = "Issued Date"
        '
        'txtDrivingLicenceNo
        '
        Me.txtDrivingLicenceNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDrivingLicenceNo.Location = New System.Drawing.Point(121, 377)
        Me.txtDrivingLicenceNo.Name = "txtDrivingLicenceNo"
        Me.txtDrivingLicenceNo.Size = New System.Drawing.Size(232, 21)
        Me.txtDrivingLicenceNo.TabIndex = 6
        '
        'lblDrivingLicense
        '
        Me.lblDrivingLicense.Location = New System.Drawing.Point(6, 380)
        Me.lblDrivingLicense.Name = "lblDrivingLicense"
        Me.lblDrivingLicense.Size = New System.Drawing.Size(112, 20)
        Me.lblDrivingLicense.TabIndex = 39
        Me.lblDrivingLicense.Text = "Driving Licence No"
        '
        'txtStartingDetails
        '
        Me.txtStartingDetails.AcceptsReturn = True
        Me.txtStartingDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStartingDetails.Location = New System.Drawing.Point(121, 286)
        Me.txtStartingDetails.Multiline = True
        Me.txtStartingDetails.Name = "txtStartingDetails"
        Me.txtStartingDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStartingDetails.Size = New System.Drawing.Size(470, 74)
        Me.txtStartingDetails.TabIndex = 5
        '
        'lblStartDetails
        '
        Me.lblStartDetails.Location = New System.Drawing.Point(6, 289)
        Me.lblStartDetails.Name = "lblStartDetails"
        Me.lblStartDetails.Size = New System.Drawing.Size(105, 20)
        Me.lblStartDetails.TabIndex = 37
        Me.lblStartDetails.Text = "Starting Details"
        '
        'txtNextOfKinContact
        '
        Me.txtNextOfKinContact.AcceptsReturn = True
        Me.txtNextOfKinContact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNextOfKinContact.Location = New System.Drawing.Point(117, 494)
        Me.txtNextOfKinContact.Multiline = True
        Me.txtNextOfKinContact.Name = "txtNextOfKinContact"
        Me.txtNextOfKinContact.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNextOfKinContact.Size = New System.Drawing.Size(474, 63)
        Me.txtNextOfKinContact.TabIndex = 10
        '
        'lblNextOfKinDetails
        '
        Me.lblNextOfKinDetails.Location = New System.Drawing.Point(5, 497)
        Me.lblNextOfKinDetails.Name = "lblNextOfKinDetails"
        Me.lblNextOfKinDetails.Size = New System.Drawing.Size(112, 20)
        Me.lblNextOfKinDetails.TabIndex = 35
        Me.lblNextOfKinDetails.Text = "Next of Kin Details"
        '
        'txtNextOfKinName
        '
        Me.txtNextOfKinName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNextOfKinName.Location = New System.Drawing.Point(117, 456)
        Me.txtNextOfKinName.Name = "txtNextOfKinName"
        Me.txtNextOfKinName.Size = New System.Drawing.Size(474, 21)
        Me.txtNextOfKinName.TabIndex = 9
        '
        'lblNextOfKin
        '
        Me.lblNextOfKin.Location = New System.Drawing.Point(6, 459)
        Me.lblNextOfKin.Name = "lblNextOfKin"
        Me.lblNextOfKin.Size = New System.Drawing.Size(112, 20)
        Me.lblNextOfKin.TabIndex = 33
        Me.lblNextOfKin.Text = "Next of Kin Name"
        '
        'btnVanHistory
        '
        Me.btnVanHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVanHistory.Location = New System.Drawing.Point(512, 584)
        Me.btnVanHistory.Name = "btnVanHistory"
        Me.btnVanHistory.Size = New System.Drawing.Size(88, 23)
        Me.btnVanHistory.TabIndex = 11
        Me.btnVanHistory.Text = "Van History"
        '
        'txtPDAID
        '
        Me.txtPDAID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPDAID.Location = New System.Drawing.Point(121, 248)
        Me.txtPDAID.Name = "txtPDAID"
        Me.txtPDAID.Size = New System.Drawing.Size(470, 21)
        Me.txtPDAID.TabIndex = 4
        '
        'cboRegion
        '
        Me.cboRegion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.Location = New System.Drawing.Point(121, 210)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(470, 21)
        Me.cboRegion.TabIndex = 1
        Me.cboRegion.Tag = "Engineer.RegionID"
        '
        'lblRegion
        '
        Me.lblRegion.Location = New System.Drawing.Point(5, 213)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(64, 20)
        Me.lblRegion.TabIndex = 31
        Me.lblRegion.Text = "Region"
        '
        'lblPDAID
        '
        Me.lblPDAID.Location = New System.Drawing.Point(6, 251)
        Me.lblPDAID.Name = "lblPDAID"
        Me.lblPDAID.Size = New System.Drawing.Size(64, 20)
        Me.lblPDAID.TabIndex = 31
        Me.lblPDAID.Text = "PDA ID"
        '
        'chkApprentice
        '
        Me.chkApprentice.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.chkApprentice.Location = New System.Drawing.Point(121, 415)
        Me.chkApprentice.Name = "chkApprentice"
        Me.chkApprentice.Size = New System.Drawing.Size(112, 24)
        Me.chkApprentice.TabIndex = 8
        Me.chkApprentice.Tag = "Engineer.Apprentice"
        Me.chkApprentice.Text = "Apprentice"
        '
        'tabMaxSor
        '
        Me.tabMaxSor.Controls.Add(Me.GroupBox8)
        Me.tabMaxSor.Location = New System.Drawing.Point(4, 22)
        Me.tabMaxSor.Name = "tabMaxSor"
        Me.tabMaxSor.Size = New System.Drawing.Size(624, 622)
        Me.tabMaxSor.TabIndex = 10
        Me.tabMaxSor.Text = "Max SOR"
        Me.tabMaxSor.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox8.Controls.Add(Me.txtBreakPri)
        Me.GroupBox8.Controls.Add(Me.txtServPri)
        Me.GroupBox8.Controls.Add(Me.Label40)
        Me.GroupBox8.Controls.Add(Me.Label39)
        Me.GroupBox8.Controls.Add(Me.txtDailyServiceLimit)
        Me.GroupBox8.Controls.Add(Me.Label42)
        Me.GroupBox8.Controls.Add(Me.txtSundayValue)
        Me.GroupBox8.Controls.Add(Me.txtSaturdayValue)
        Me.GroupBox8.Controls.Add(Me.txtFridayValue)
        Me.GroupBox8.Controls.Add(Me.txtThursdayValue)
        Me.GroupBox8.Controls.Add(Me.txtWednesdayValue)
        Me.GroupBox8.Controls.Add(Me.txtTuesdayValue)
        Me.GroupBox8.Controls.Add(Me.txtMondayValue)
        Me.GroupBox8.Controls.Add(Me.Label43)
        Me.GroupBox8.Controls.Add(Me.Label44)
        Me.GroupBox8.Controls.Add(Me.Label45)
        Me.GroupBox8.Controls.Add(Me.Label46)
        Me.GroupBox8.Controls.Add(Me.Label47)
        Me.GroupBox8.Controls.Add(Me.Label48)
        Me.GroupBox8.Controls.Add(Me.Label49)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(624, 622)
        Me.GroupBox8.TabIndex = 1
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Max Schedule Of Rate Times Per Day (In minutes)"
        '
        'txtBreakPri
        '
        Me.txtBreakPri.Location = New System.Drawing.Point(193, 262)
        Me.txtBreakPri.Name = "txtBreakPri"
        Me.txtBreakPri.Size = New System.Drawing.Size(41, 21)
        Me.txtBreakPri.TabIndex = 80
        '
        'txtServPri
        '
        Me.txtServPri.Location = New System.Drawing.Point(193, 235)
        Me.txtServPri.Name = "txtServPri"
        Me.txtServPri.Size = New System.Drawing.Size(41, 21)
        Me.txtServPri.TabIndex = 78
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(28, 265)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(167, 29)
        Me.Label40.TabIndex = 79
        Me.Label40.Text = "Breakdown Priority (1-10)"
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(28, 238)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(159, 29)
        Me.Label39.TabIndex = 77
        Me.Label39.Text = "Service Priority (1-10)"
        '
        'txtDailyServiceLimit
        '
        Me.txtDailyServiceLimit.Location = New System.Drawing.Point(193, 209)
        Me.txtDailyServiceLimit.Name = "txtDailyServiceLimit"
        Me.txtDailyServiceLimit.Size = New System.Drawing.Size(131, 21)
        Me.txtDailyServiceLimit.TabIndex = 15
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(28, 212)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(114, 13)
        Me.Label42.TabIndex = 14
        Me.Label42.Text = "Daily Service Limit"
        '
        'txtSundayValue
        '
        Me.txtSundayValue.Location = New System.Drawing.Point(193, 183)
        Me.txtSundayValue.Name = "txtSundayValue"
        Me.txtSundayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtSundayValue.TabIndex = 13
        '
        'txtSaturdayValue
        '
        Me.txtSaturdayValue.Location = New System.Drawing.Point(193, 157)
        Me.txtSaturdayValue.Name = "txtSaturdayValue"
        Me.txtSaturdayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtSaturdayValue.TabIndex = 12
        '
        'txtFridayValue
        '
        Me.txtFridayValue.Location = New System.Drawing.Point(193, 131)
        Me.txtFridayValue.Name = "txtFridayValue"
        Me.txtFridayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtFridayValue.TabIndex = 11
        '
        'txtThursdayValue
        '
        Me.txtThursdayValue.Location = New System.Drawing.Point(193, 105)
        Me.txtThursdayValue.Name = "txtThursdayValue"
        Me.txtThursdayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtThursdayValue.TabIndex = 10
        '
        'txtWednesdayValue
        '
        Me.txtWednesdayValue.Location = New System.Drawing.Point(193, 79)
        Me.txtWednesdayValue.Name = "txtWednesdayValue"
        Me.txtWednesdayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtWednesdayValue.TabIndex = 9
        '
        'txtTuesdayValue
        '
        Me.txtTuesdayValue.Location = New System.Drawing.Point(193, 53)
        Me.txtTuesdayValue.Name = "txtTuesdayValue"
        Me.txtTuesdayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtTuesdayValue.TabIndex = 8
        '
        'txtMondayValue
        '
        Me.txtMondayValue.Location = New System.Drawing.Point(193, 27)
        Me.txtMondayValue.Name = "txtMondayValue"
        Me.txtMondayValue.Size = New System.Drawing.Size(131, 21)
        Me.txtMondayValue.TabIndex = 7
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(28, 186)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(50, 13)
        Me.Label43.TabIndex = 6
        Me.Label43.Text = "Sunday"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(28, 160)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(59, 13)
        Me.Label44.TabIndex = 5
        Me.Label44.Text = "Saturday"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(28, 134)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(42, 13)
        Me.Label45.TabIndex = 4
        Me.Label45.Text = "Friday"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(28, 108)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(60, 13)
        Me.Label46.TabIndex = 3
        Me.Label46.Text = "Thursday"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(28, 82)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(72, 13)
        Me.Label47.TabIndex = 2
        Me.Label47.Text = "Wednesday"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(28, 56)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(54, 13)
        Me.Label48.TabIndex = 1
        Me.Label48.Text = "Tuesday"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(28, 30)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(51, 13)
        Me.Label49.TabIndex = 0
        Me.Label49.Text = "Monday"
        '
        'tpWages
        '
        Me.tpWages.Controls.Add(Me.GroupBox3)
        Me.tpWages.Controls.Add(Me.GroupBox1)
        Me.tpWages.Location = New System.Drawing.Point(4, 22)
        Me.tpWages.Name = "tpWages"
        Me.tpWages.Size = New System.Drawing.Size(624, 622)
        Me.tpWages.TabIndex = 1
        Me.tpWages.Text = "Wages"
        Me.tpWages.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtCostToCompanyDouble)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtCostToCompanyTimeHalf)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtCostToCompanyNormal)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 136)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(608, 120)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cost to Company"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 20)
        Me.Label11.TabIndex = 55
        Me.Label11.Text = "Normal"
        '
        'txtCostToCompanyDouble
        '
        Me.txtCostToCompanyDouble.Location = New System.Drawing.Point(120, 88)
        Me.txtCostToCompanyDouble.Name = "txtCostToCompanyDouble"
        Me.txtCostToCompanyDouble.Size = New System.Drawing.Size(144, 21)
        Me.txtCostToCompanyDouble.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 20)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "Double"
        '
        'txtCostToCompanyTimeHalf
        '
        Me.txtCostToCompanyTimeHalf.Location = New System.Drawing.Point(120, 56)
        Me.txtCostToCompanyTimeHalf.Name = "txtCostToCompanyTimeHalf"
        Me.txtCostToCompanyTimeHalf.Size = New System.Drawing.Size(144, 21)
        Me.txtCostToCompanyTimeHalf.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 20)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "Time && Half"
        '
        'txtCostToCompanyNormal
        '
        Me.txtCostToCompanyNormal.Location = New System.Drawing.Point(120, 24)
        Me.txtCostToCompanyNormal.Name = "txtCostToCompanyNormal"
        Me.txtCostToCompanyNormal.Size = New System.Drawing.Size(144, 21)
        Me.txtCostToCompanyNormal.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtNINumber)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cboPayGrade)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtAnnualSalary)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Wages Information"
        '
        'txtNINumber
        '
        Me.txtNINumber.Location = New System.Drawing.Point(120, 88)
        Me.txtNINumber.Name = "txtNINumber"
        Me.txtNINumber.Size = New System.Drawing.Size(144, 21)
        Me.txtNINumber.TabIndex = 3
        Me.txtNINumber.Tag = "Engineer.Name"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 20)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "NI Number"
        '
        'cboPayGrade
        '
        Me.cboPayGrade.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPayGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayGrade.Location = New System.Drawing.Point(120, 28)
        Me.cboPayGrade.Name = "cboPayGrade"
        Me.cboPayGrade.Size = New System.Drawing.Size(480, 21)
        Me.cboPayGrade.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 23)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Pay Grade"
        '
        'txtAnnualSalary
        '
        Me.txtAnnualSalary.Location = New System.Drawing.Point(120, 56)
        Me.txtAnnualSalary.Name = "txtAnnualSalary"
        Me.txtAnnualSalary.Size = New System.Drawing.Size(143, 21)
        Me.txtAnnualSalary.TabIndex = 2
        Me.txtAnnualSalary.Tag = "Engineer.Name"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(9, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 20)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "Annual Salary"
        '
        'tpTrainingQualifications
        '
        Me.tpTrainingQualifications.Controls.Add(Me.GroupBox5)
        Me.tpTrainingQualifications.Location = New System.Drawing.Point(4, 22)
        Me.tpTrainingQualifications.Name = "tpTrainingQualifications"
        Me.tpTrainingQualifications.Size = New System.Drawing.Size(624, 622)
        Me.tpTrainingQualifications.TabIndex = 3
        Me.tpTrainingQualifications.Text = "Training & Qualifications"
        Me.tpTrainingQualifications.Visible = False
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
        Me.GroupBox5.Size = New System.Drawing.Size(608, 608)
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
        Me.Panel1.Controls.Add(Me.cboQualification)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.txtQualificatioNote)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.btnSaveQualification)
        Me.Panel1.Controls.Add(Me.dtpQualificationExpires)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.dtpQualificationPassed)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Location = New System.Drawing.Point(5, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(595, 225)
        Me.Panel1.TabIndex = 42
        '
        'cboQualificationType
        '
        Me.cboQualificationType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboQualificationType.Location = New System.Drawing.Point(139, 8)
        Me.cboQualificationType.Name = "cboQualificationType"
        Me.cboQualificationType.Size = New System.Drawing.Size(445, 21)
        Me.cboQualificationType.TabIndex = 54
        Me.cboQualificationType.Text = "ComboBox1"
        '
        'lblQualificationType
        '
        Me.lblQualificationType.Location = New System.Drawing.Point(7, 8)
        Me.lblQualificationType.Name = "lblQualificationType"
        Me.lblQualificationType.Size = New System.Drawing.Size(126, 23)
        Me.lblQualificationType.TabIndex = 55
        Me.lblQualificationType.Text = "Qualification Type"
        '
        'dtpQualificationBooked
        '
        Me.dtpQualificationBooked.Checked = False
        Me.dtpQualificationBooked.Location = New System.Drawing.Point(332, 68)
        Me.dtpQualificationBooked.Name = "dtpQualificationBooked"
        Me.dtpQualificationBooked.ShowCheckBox = True
        Me.dtpQualificationBooked.Size = New System.Drawing.Size(152, 21)
        Me.dtpQualificationBooked.TabIndex = 52
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(269, 74)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(57, 23)
        Me.Label36.TabIndex = 53
        Me.Label36.Text = "Booked"
        '
        'cboQualification
        '
        Me.cboQualification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboQualification.Location = New System.Drawing.Point(96, 38)
        Me.cboQualification.Name = "cboQualification"
        Me.cboQualification.Size = New System.Drawing.Size(488, 21)
        Me.cboQualification.TabIndex = 1
        Me.cboQualification.Text = "ComboBox1"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(8, 38)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 23)
        Me.Label22.TabIndex = 48
        Me.Label22.Text = "Qualification"
        '
        'txtQualificatioNote
        '
        Me.txtQualificatioNote.AcceptsReturn = True
        Me.txtQualificatioNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQualificatioNote.Location = New System.Drawing.Point(96, 132)
        Me.txtQualificatioNote.Multiline = True
        Me.txtQualificatioNote.Name = "txtQualificatioNote"
        Me.txtQualificatioNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQualificatioNote.Size = New System.Drawing.Size(488, 61)
        Me.txtQualificatioNote.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 132)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 20)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Note"
        '
        'btnSaveQualification
        '
        Me.btnSaveQualification.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveQualification.Location = New System.Drawing.Point(496, 199)
        Me.btnSaveQualification.Name = "btnSaveQualification"
        Me.btnSaveQualification.Size = New System.Drawing.Size(88, 23)
        Me.btnSaveQualification.TabIndex = 5
        Me.btnSaveQualification.Text = "Save"
        '
        'dtpQualificationExpires
        '
        Me.dtpQualificationExpires.Checked = False
        Me.dtpQualificationExpires.Location = New System.Drawing.Point(96, 99)
        Me.dtpQualificationExpires.Name = "dtpQualificationExpires"
        Me.dtpQualificationExpires.ShowCheckBox = True
        Me.dtpQualificationExpires.Size = New System.Drawing.Size(152, 21)
        Me.dtpQualificationExpires.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 105)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 23)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "Expires"
        '
        'dtpQualificationPassed
        '
        Me.dtpQualificationPassed.Checked = False
        Me.dtpQualificationPassed.Location = New System.Drawing.Point(96, 68)
        Me.dtpQualificationPassed.Name = "dtpQualificationPassed"
        Me.dtpQualificationPassed.ShowCheckBox = True
        Me.dtpQualificationPassed.Size = New System.Drawing.Size(152, 21)
        Me.dtpQualificationPassed.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 74)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 23)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "Date Passed"
        '
        'btnRemoveTrainingQualifications
        '
        Me.btnRemoveTrainingQualifications.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveTrainingQualifications.Location = New System.Drawing.Point(10, 576)
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
        Me.dgTrainingQualifications.Location = New System.Drawing.Point(8, 248)
        Me.dgTrainingQualifications.Name = "dgTrainingQualifications"
        Me.dgTrainingQualifications.Size = New System.Drawing.Size(592, 320)
        Me.dgTrainingQualifications.TabIndex = 6
        '
        'tpKit
        '
        Me.tpKit.Controls.Add(Me.GroupBox4)
        Me.tpKit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpKit.Location = New System.Drawing.Point(4, 22)
        Me.tpKit.Name = "tpKit"
        Me.tpKit.Size = New System.Drawing.Size(624, 622)
        Me.tpKit.TabIndex = 4
        Me.tpKit.Text = "Equipment"
        Me.tpKit.Visible = False
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
        Me.GroupBox4.Size = New System.Drawing.Size(608, 608)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Specialised Equipment and Tools Issued"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.txtEquipmentTool)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.btnSaveEquipment)
        Me.Panel2.Location = New System.Drawing.Point(8, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(592, 80)
        Me.Panel2.TabIndex = 2
        '
        'txtEquipmentTool
        '
        Me.txtEquipmentTool.AcceptsReturn = True
        Me.txtEquipmentTool.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEquipmentTool.Location = New System.Drawing.Point(115, 4)
        Me.txtEquipmentTool.MaxLength = 255
        Me.txtEquipmentTool.Multiline = True
        Me.txtEquipmentTool.Name = "txtEquipmentTool"
        Me.txtEquipmentTool.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEquipmentTool.Size = New System.Drawing.Size(376, 68)
        Me.txtEquipmentTool.TabIndex = 1
        Me.txtEquipmentTool.Tag = "Engineer.Name"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(3, 4)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(112, 20)
        Me.Label20.TabIndex = 55
        Me.Label20.Text = "Equipment\Tool"
        '
        'btnSaveEquipment
        '
        Me.btnSaveEquipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveEquipment.Location = New System.Drawing.Point(504, 48)
        Me.btnSaveEquipment.Name = "btnSaveEquipment"
        Me.btnSaveEquipment.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveEquipment.TabIndex = 2
        Me.btnSaveEquipment.Text = "Save"
        '
        'btnRemoveEngineerEquipment
        '
        Me.btnRemoveEngineerEquipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveEngineerEquipment.Location = New System.Drawing.Point(8, 576)
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
        Me.dgEquipment.Location = New System.Drawing.Point(8, 106)
        Me.dgEquipment.Name = "dgEquipment"
        Me.dgEquipment.Size = New System.Drawing.Size(592, 462)
        Me.dgEquipment.TabIndex = 3
        '
        'tpDisciplinary
        '
        Me.tpDisciplinary.Controls.Add(Me.GroupBox6)
        Me.tpDisciplinary.Location = New System.Drawing.Point(4, 22)
        Me.tpDisciplinary.Name = "tpDisciplinary"
        Me.tpDisciplinary.Size = New System.Drawing.Size(624, 622)
        Me.tpDisciplinary.TabIndex = 2
        Me.tpDisciplinary.Text = "Disciplinary"
        Me.tpDisciplinary.Visible = False
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
        Me.GroupBox6.Size = New System.Drawing.Size(608, 608)
        Me.GroupBox6.TabIndex = 14
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Disciplinary Records"
        '
        'btnAddDisciplinaries
        '
        Me.btnAddDisciplinaries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddDisciplinaries.Location = New System.Drawing.Point(8, 576)
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
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.dtpDisciplinaryIssued)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.txtDisciplinary)
        Me.Panel3.Controls.Add(Me.Label24)
        Me.Panel3.Location = New System.Drawing.Point(5, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(595, 80)
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
        Me.cboDisciplinary.Size = New System.Drawing.Size(392, 21)
        Me.cboDisciplinary.TabIndex = 3
        Me.cboDisciplinary.Text = "ComboBox2"
        '
        'btnSaveDisciplinaries
        '
        Me.btnSaveDisciplinaries.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveDisciplinaries.Location = New System.Drawing.Point(496, 53)
        Me.btnSaveDisciplinaries.Name = "btnSaveDisciplinaries"
        Me.btnSaveDisciplinaries.Size = New System.Drawing.Size(88, 21)
        Me.btnSaveDisciplinaries.TabIndex = 4
        Me.btnSaveDisciplinaries.Text = "Save"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(8, 53)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 23)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Status"
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
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(8, 29)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 23)
        Me.Label23.TabIndex = 41
        Me.Label23.Text = "Issued"
        '
        'txtDisciplinary
        '
        Me.txtDisciplinary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDisciplinary.Location = New System.Drawing.Point(96, 5)
        Me.txtDisciplinary.Name = "txtDisciplinary"
        Me.txtDisciplinary.Size = New System.Drawing.Size(496, 21)
        Me.txtDisciplinary.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(8, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 20)
        Me.Label24.TabIndex = 40
        Me.Label24.Text = "Disciplinary"
        '
        'btnRemoveDisciplinaries
        '
        Me.btnRemoveDisciplinaries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveDisciplinaries.Location = New System.Drawing.Point(168, 576)
        Me.btnRemoveDisciplinaries.Name = "btnRemoveDisciplinaries"
        Me.btnRemoveDisciplinaries.Size = New System.Drawing.Size(75, 21)
        Me.btnRemoveDisciplinaries.TabIndex = 7
        Me.btnRemoveDisciplinaries.Text = "Delete"
        '
        'btnEditDisciplinaries
        '
        Me.btnEditDisciplinaries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEditDisciplinaries.Location = New System.Drawing.Point(88, 576)
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
        Me.dgDisciplinaries.Location = New System.Drawing.Point(8, 116)
        Me.dgDisciplinaries.Name = "dgDisciplinaries"
        Me.dgDisciplinaries.Size = New System.Drawing.Size(592, 452)
        Me.dgDisciplinaries.TabIndex = 5
        '
        'tpDocuments
        '
        Me.tpDocuments.Controls.Add(Me.pnlDocuments)
        Me.tpDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tpDocuments.Name = "tpDocuments"
        Me.tpDocuments.Size = New System.Drawing.Size(624, 622)
        Me.tpDocuments.TabIndex = 6
        Me.tpDocuments.Text = "Documents"
        Me.tpDocuments.Visible = False
        '
        'pnlDocuments
        '
        Me.pnlDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDocuments.Location = New System.Drawing.Point(0, 0)
        Me.pnlDocuments.Name = "pnlDocuments"
        Me.pnlDocuments.Size = New System.Drawing.Size(624, 622)
        Me.pnlDocuments.TabIndex = 0
        '
        'tpHolidayAbsences
        '
        Me.tpHolidayAbsences.Controls.Add(Me.grpAbsences)
        Me.tpHolidayAbsences.Controls.Add(Me.GroupBox7)
        Me.tpHolidayAbsences.Location = New System.Drawing.Point(4, 22)
        Me.tpHolidayAbsences.Name = "tpHolidayAbsences"
        Me.tpHolidayAbsences.Size = New System.Drawing.Size(624, 622)
        Me.tpHolidayAbsences.TabIndex = 5
        Me.tpHolidayAbsences.Text = "Holidays & Absences"
        Me.tpHolidayAbsences.Visible = False
        '
        'grpAbsences
        '
        Me.grpAbsences.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAbsences.Controls.Add(Me.dgAbsences)
        Me.grpAbsences.Location = New System.Drawing.Point(8, 112)
        Me.grpAbsences.Name = "grpAbsences"
        Me.grpAbsences.Size = New System.Drawing.Size(608, 504)
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
        Me.dgAbsences.Location = New System.Drawing.Point(8, 24)
        Me.dgAbsences.Name = "dgAbsences"
        Me.dgAbsences.Size = New System.Drawing.Size(592, 472)
        Me.dgAbsences.TabIndex = 4
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.txtDaysHolidayAllowed)
        Me.GroupBox7.Controls.Add(Me.Label25)
        Me.GroupBox7.Controls.Add(Me.txtHolidayYearEnd)
        Me.GroupBox7.Controls.Add(Me.Label26)
        Me.GroupBox7.Controls.Add(Me.txtHolidayYearStart)
        Me.GroupBox7.Controls.Add(Me.Label27)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(608, 104)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Holiday Entitlement"
        '
        'txtDaysHolidayAllowed
        '
        Me.txtDaysHolidayAllowed.Location = New System.Drawing.Point(144, 72)
        Me.txtDaysHolidayAllowed.Name = "txtDaysHolidayAllowed"
        Me.txtDaysHolidayAllowed.Size = New System.Drawing.Size(176, 21)
        Me.txtDaysHolidayAllowed.TabIndex = 3
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(16, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 23)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "Holiday Entitlement"
        '
        'txtHolidayYearEnd
        '
        Me.txtHolidayYearEnd.Location = New System.Drawing.Point(144, 48)
        Me.txtHolidayYearEnd.Name = "txtHolidayYearEnd"
        Me.txtHolidayYearEnd.Size = New System.Drawing.Size(176, 21)
        Me.txtHolidayYearEnd.TabIndex = 2
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(16, 48)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(128, 23)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "End Period (dd/mm)"
        '
        'txtHolidayYearStart
        '
        Me.txtHolidayYearStart.Location = New System.Drawing.Point(144, 24)
        Me.txtHolidayYearStart.Name = "txtHolidayYearStart"
        Me.txtHolidayYearStart.Size = New System.Drawing.Size(176, 21)
        Me.txtHolidayYearStart.TabIndex = 1
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(16, 24)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(128, 23)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Start Period (dd/mm)"
        '
        'tpPostalRegions
        '
        Me.tpPostalRegions.Controls.Add(Me.GroupBox2)
        Me.tpPostalRegions.Controls.Add(Me.grpPostalRegions)
        Me.tpPostalRegions.Location = New System.Drawing.Point(4, 22)
        Me.tpPostalRegions.Name = "tpPostalRegions"
        Me.tpPostalRegions.Size = New System.Drawing.Size(624, 622)
        Me.tpPostalRegions.TabIndex = 7
        Me.tpPostalRegions.Text = "Postal Regions"
        Me.tpPostalRegions.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(605, 80)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Home "
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
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(132, 25)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(123, 21)
        Me.TextBox1.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(29, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 20)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Home Postcode"
        '
        'grpPostalRegions
        '
        Me.grpPostalRegions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPostalRegions.Controls.Add(Me.Label38)
        Me.grpPostalRegions.Controls.Add(Me.txtPCSearch)
        Me.grpPostalRegions.Controls.Add(Me.Label2)
        Me.grpPostalRegions.Controls.Add(Me.dgUnTicked)
        Me.grpPostalRegions.Controls.Add(Me.dgPostalRegions)
        Me.grpPostalRegions.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPostalRegions.Location = New System.Drawing.Point(3, 89)
        Me.grpPostalRegions.Name = "grpPostalRegions"
        Me.grpPostalRegions.Size = New System.Drawing.Size(618, 530)
        Me.grpPostalRegions.TabIndex = 14
        Me.grpPostalRegions.TabStop = False
        Me.grpPostalRegions.Text = "Postal Regions"
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Verdana", 10.25!)
        Me.Label38.Location = New System.Drawing.Point(15, 26)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(143, 20)
        Me.Label38.TabIndex = 43
        Me.Label38.Text = "Assigned Areas"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPCSearch
        '
        Me.txtPCSearch.Location = New System.Drawing.Point(369, 28)
        Me.txtPCSearch.Name = "txtPCSearch"
        Me.txtPCSearch.Size = New System.Drawing.Size(123, 21)
        Me.txtPCSearch.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(304, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Search"
        '
        'dgUnTicked
        '
        Me.dgUnTicked.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgUnTicked.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgUnTicked.DataMember = ""
        Me.dgUnTicked.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgUnTicked.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUnTicked.Location = New System.Drawing.Point(310, 62)
        Me.dgUnTicked.Name = "dgUnTicked"
        Me.dgUnTicked.Size = New System.Drawing.Size(284, 450)
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
        Me.dgPostalRegions.Location = New System.Drawing.Point(7, 62)
        Me.dgPostalRegions.Name = "dgPostalRegions"
        Me.dgPostalRegions.Size = New System.Drawing.Size(284, 450)
        Me.dgPostalRegions.TabIndex = 0
        '
        'cboDepartment
        '
        Me.cboDepartment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDepartment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Location = New System.Drawing.Point(121, 99)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(470, 21)
        Me.cboDepartment.TabIndex = 73
        Me.cboDepartment.Tag = "Engineer.Department"
        '
        'UCSubcontractor
        '
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "UCSubcontractor"
        Me.Size = New System.Drawing.Size(640, 652)
        Me.TabControl1.ResumeLayout(False)
        Me.tpContact.ResumeLayout(False)
        Me.tpContact.PerformLayout()
        Me.tpMain.ResumeLayout(False)
        Me.grpEngineer.ResumeLayout(False)
        Me.grpEngineer.PerformLayout()
        Me.tabMaxSor.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.tpWages.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpPostalRegions.ResumeLayout(False)
        Me.grpPostalRegions.PerformLayout()
        CType(Me.dgUnTicked, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPostalRegions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

        SetupPostalRegionsDataGrid()
        SetupPostalRegionsDataGridUnTicked()
        SetupTrainingQualificationsDataGrid()
        SetupEngineerEquipmentDataGrid()
        SetupDisciplinariesDataGrid()
        SetupAbsenceDataGridGrid()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentSubcontractor
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private DocumentsControl As UCDocumentsList

    Private _currentSubcontractor As Entity.Subcontractors.Subcontractor

    Public Property CurrentSubcontractor() As Entity.Subcontractors.Subcontractor
        Get
            Return _currentSubcontractor
        End Get
        Set(ByVal Value As Entity.Subcontractors.Subcontractor)
            _currentSubcontractor = Value

            If _currentSubcontractor Is Nothing Then
                _currentSubcontractor = New Entity.Subcontractors.Subcontractor
                _currentSubcontractor.Engineer = New Entity.Engineers.Engineer
                _currentSubcontractor.Engineer.Exists = False
                _currentSubcontractor.Exists = False
            End If

            txtHolidayYearStart.Text = CurrentSubcontractor.Engineer.HolidayYearStart
            txtHolidayYearEnd.Text = CurrentSubcontractor.Engineer.HolidayYearEnd

            If CurrentSubcontractor.Exists Then
                Populate()
                Me.btnVanHistory.Enabled = True
                Me.pnlDocuments.Controls.Clear()
                DocumentsControl = New UCDocumentsList(Entity.Sys.Enums.TableNames.tblEngineer, CurrentSubcontractor.EngineerID)
                Me.pnlDocuments.Controls.Add(DocumentsControl)
            Else
                Me.btnVanHistory.Enabled = False
            End If

            PopulatePostalRegions()
            PopulateTrainingQualifications()
            PopulateEngineerEquipment()
            PopulateDisciplinaries()
            PopulateAbsences()

        End Set
    End Property

    Private _MaxTimes As Entity.MaxEngineerTimes.MaxEngineerTime

    Public Property MaxTimes() As Entity.MaxEngineerTimes.MaxEngineerTime
        Get
            Return _MaxTimes
        End Get
        Set(ByVal value As Entity.MaxEngineerTimes.MaxEngineerTime)
            _MaxTimes = value
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

#Region "Setup"

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

#Region "Events"

    Private Sub UCSubcontractor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub dgPostalRegions_Clicks(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If SelectedPostalRegionDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not CBool(Me.dgPostalRegions(Me.dgPostalRegions.CurrentRowIndex, 0))
            Me.dgPostalRegions(Me.dgPostalRegions.CurrentRowIndex, 0) = selected
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVanHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVanHistory.Click
        ShowForm(GetType(FRMVanHistory), True, New Object() {CurrentSubcontractor.EngineerID})
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentSubcontractor = DB.SubContractor.Subcontractor_Get(ID)
        End If

        Me.txtName.Text = CurrentSubcontractor.Name
        Me.txtAddress1.Text = CurrentSubcontractor.Address1
        Me.txtAddress2.Text = CurrentSubcontractor.Address2
        Me.txtAddress3.Text = CurrentSubcontractor.Address3
        Me.txtAddress4.Text = CurrentSubcontractor.Address4
        Me.txtAddress5.Text = CurrentSubcontractor.Address5
        Me.txtPostcode.Text = CurrentSubcontractor.Postcode
        Me.txtTelephoneNum.Text = CurrentSubcontractor.TelephoneNum
        Me.txtFaxNum.Text = CurrentSubcontractor.FaxNum
        Me.txtEmailAddress.Text = CurrentSubcontractor.EmailAddress
        Me.txtNotes.Text = CurrentSubcontractor.Notes
        Combo.SetSelectedComboItem_By_Value(cboLinkToSupplier, CurrentSubcontractor.LinkToSupplierID)
        Combo.SetSelectedComboItem_By_Value(cboTaxRate, CurrentSubcontractor.TaxRate)

        'engineer details
        txtEngineerID.Text = CurrentSubcontractor.Engineer.EngineerID
        txtGasSafeNo.Text = CurrentSubcontractor.Engineer.GasSafeNo
        txtOftecNo.Text = CurrentSubcontractor.Engineer.OftecNo
        Combo.SetSelectedComboItem_By_Value(Me.cboEngineerGroup, CurrentSubcontractor.Engineer.EngineerGroupID)
        Combo.SetSelectedComboItem_By_Value(Me.cboDepartment, CurrentSubcontractor.Engineer.Department.Trim())
        txtTechnician.Text = CurrentSubcontractor.Engineer.Technician
        Combo.SetSelectedComboItem_By_Value(cboUser, CurrentSubcontractor.Engineer.ManagerUserID)
        Combo.SetSelectedComboItem_By_Value(Me.cboRegion, CurrentSubcontractor.Engineer.RegionID)
        If Not CurrentSubcontractor.Exists Or Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Region) Then
            Me.cboRegion.Enabled = False
        End If
        If CurrentSubcontractor.Engineer.PDAID = 0 Then
            Me.txtPDAID.Text = String.Empty
        Else
            Me.txtPDAID.Text = CurrentSubcontractor.Engineer.PDAID
        End If
        txtStartingDetails.Text = CurrentSubcontractor.Engineer.StartingDetails
        txtDrivingLicenceNo.Text = CurrentSubcontractor.Engineer.DrivingLicenceNo
        If Not CurrentSubcontractor.Engineer.DrivingLicenceIssueDate = Nothing Then
            dtpDrivingLicenceIssueDate.Value = CurrentSubcontractor.Engineer.DrivingLicenceIssueDate
            dtpDrivingLicenceIssueDate.Checked = True
        Else
            dtpDrivingLicenceIssueDate.Value = Now.Date
            dtpDrivingLicenceIssueDate.Checked = False
        End If
        Me.chkApprentice.Checked = CurrentSubcontractor.Engineer.Apprentice
        txtNextOfKinName.Text = CurrentSubcontractor.Engineer.NextOfKinName
        txtNextOfKinContact.Text = CurrentSubcontractor.Engineer.NextOfKinContact

        'sors
        MaxTimes = DB.MaxEngineerTime.MaxEngineerTime_GetForEngineer(CurrentSubcontractor.Engineer.EngineerID)

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
        txtDailyServiceLimit.Text = CurrentSubcontractor.Engineer.DailyServiceLimit
        txtServPri.Text = CurrentSubcontractor.Engineer.ServPri
        txtBreakPri.Text = CurrentSubcontractor.Engineer.BreakPri

        'wages
        Combo.SetSelectedComboItem_By_Value(Me.cboPayGrade, CurrentSubcontractor.Engineer.PayGradeID)
        txtAnnualSalary.Text = CurrentSubcontractor.Engineer.AnnualSalary
        txtNINumber.Text = CurrentSubcontractor.Engineer.NINumber
        Me.txtCostToCompanyNormal.Text = Format(CurrentSubcontractor.Engineer.CostToCompanyNormal, "C")
        Me.txtCostToCompanyTimeHalf.Text = Format(CurrentSubcontractor.Engineer.CostToCompanyTimeAndHalf, "C")
        Me.txtCostToCompanyDouble.Text = Format(CurrentSubcontractor.Engineer.CostToCompanyDouble, "C")

        'holiday
        txtHolidayYearStart.Text = CurrentSubcontractor.Engineer.HolidayYearStart
        txtHolidayYearEnd.Text = CurrentSubcontractor.Engineer.HolidayYearEnd
        txtDaysHolidayAllowed.Text = CurrentSubcontractor.Engineer.DaysHolidayAllowed

        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Private Sub PopulatePostalRegions()
        PostalRegionsDataView = DB.EngineerPostalRegion.Get(CurrentSubcontractor.EngineerID)
        PostalRegionsDataViewUT = DB.EngineerPostalRegion.GetUnTicked(CurrentSubcontractor.EngineerID)
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor

            CurrentSubcontractor.IgnoreExceptionsOnSetMethods = True
            CurrentSubcontractor.SetName = Me.txtName.Text.Trim
            CurrentSubcontractor.SetAddress1 = Me.txtAddress1.Text.Trim
            CurrentSubcontractor.SetAddress2 = Me.txtAddress2.Text.Trim
            CurrentSubcontractor.SetAddress3 = Me.txtAddress3.Text.Trim
            CurrentSubcontractor.SetAddress4 = Me.txtAddress4.Text.Trim
            CurrentSubcontractor.SetAddress5 = Me.txtAddress5.Text.Trim
            CurrentSubcontractor.SetPostcode = Me.txtPostcode.Text.Trim
            CurrentSubcontractor.SetTelephoneNum = Me.txtTelephoneNum.Text.Trim
            CurrentSubcontractor.SetFaxNum = Me.txtFaxNum.Text.Trim
            CurrentSubcontractor.SetEmailAddress = Me.txtEmailAddress.Text.Trim
            CurrentSubcontractor.SetNotes = Me.txtNotes.Text.Trim

            CurrentSubcontractor.Engineer.IgnoreExceptionsOnSetMethods = True
            If Not CurrentSubcontractor.Exists Or loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Region) Then
                CurrentSubcontractor.Engineer.SetRegionID = Combo.GetSelectedItemValue(Me.cboRegion)
            End If
            CurrentSubcontractor.Engineer.SetEngineerGroupID = Combo.GetSelectedItemValue(cboEngineerGroup)
            CurrentSubcontractor.Engineer.SetGasSafeNo = txtGasSafeNo.Text.Trim()
            CurrentSubcontractor.Engineer.SetOftecNo = txtOftecNo.Text.Trim()
            CurrentSubcontractor.Engineer.SetName = "SUBCONTRACTOR : " & Me.txtName.Text.Trim
            CurrentSubcontractor.Engineer.SetTelephoneNum = Me.txtTelephoneNum.Text.Trim

            If Me.txtPDAID.Text.Trim.Length = 0 Then
                CurrentSubcontractor.Engineer.SetPDAID = 0
            Else
                CurrentSubcontractor.Engineer.SetPDAID = Me.txtPDAID.Text.Trim
            End If

            CurrentSubcontractor.Engineer.SetApprentice = Me.chkApprentice.Checked
            CurrentSubcontractor.Engineer.SetCostToCompanyNormal = Replace(Me.txtCostToCompanyNormal.Text.Trim, "£", "")
            CurrentSubcontractor.Engineer.SetCostToCompanyTimeAndHalf = Replace(Me.txtCostToCompanyTimeHalf.Text.Trim, "£", "")
            CurrentSubcontractor.Engineer.SetCostToCompanyDouble = Replace(Me.txtCostToCompanyDouble.Text.Trim, "£", "")
            CurrentSubcontractor.Engineer.SetNextOfKinName = txtNextOfKinName.Text
            CurrentSubcontractor.Engineer.SetNextOfKinContact = txtNextOfKinContact.Text
            CurrentSubcontractor.Engineer.SetStartingDetails = txtStartingDetails.Text
            CurrentSubcontractor.Engineer.SetDrivingLicenceNo = txtDrivingLicenceNo.Text
            If dtpDrivingLicenceIssueDate.Checked Then
                CurrentSubcontractor.Engineer.DrivingLicenceIssueDate = dtpDrivingLicenceIssueDate.Value
            Else
                CurrentSubcontractor.Engineer.DrivingLicenceIssueDate = Nothing
            End If

            CurrentSubcontractor.Engineer.SetPayGradeID = Combo.GetSelectedItemValue(Me.cboPayGrade)
            If txtAnnualSalary.Text.Trim().Length > 0 Then
                CurrentSubcontractor.Engineer.SetAnnualSalary = txtAnnualSalary.Text
            End If
            CurrentSubcontractor.Engineer.SetNINumber = txtNINumber.Text
            CurrentSubcontractor.Engineer.SetHolidayYearStart = txtHolidayYearStart.Text
            CurrentSubcontractor.Engineer.SetHolidayYearEnd = txtHolidayYearEnd.Text
            If txtDaysHolidayAllowed.Text.Trim().Length > 0 Then
                CurrentSubcontractor.Engineer.SetDaysHolidayAllowed = txtDaysHolidayAllowed.Text
            End If

            Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(cboDepartment))
            If Helper.IsValidInteger(department) AndAlso Not Helper.MakeIntegerValid(department) <= 0 Then
                CurrentSubcontractor.Engineer.SetDepartment = department
            ElseIf Not IsNumeric(department) Then
                CurrentSubcontractor.Engineer.SetDepartment = department
            End If

            CurrentSubcontractor.Engineer.SetServPri = txtServPri.Text
            CurrentSubcontractor.Engineer.SetBreakPri = txtBreakPri.Text
            CurrentSubcontractor.Engineer.SetDailyServiceLimit = txtDailyServiceLimit.Text
            CurrentSubcontractor.Engineer.SetHomePostcode = txtPostcode.Text

            Dim cV As New Entity.Subcontractors.SubcontractorValidator
            cV.Validate(CurrentSubcontractor)

            CurrentSubcontractor.SetLinkToSupplierID = Combo.GetSelectedItemValue(cboLinkToSupplier)
            CurrentSubcontractor.SetTaxRate = Combo.GetSelectedItemValue(cboTaxRate)

            If CurrentSubcontractor.Exists Then
                DB.SubContractor.Update(CurrentSubcontractor)
                DB.Engineer.Update(CurrentSubcontractor.Engineer)
                DB.EngineerPostalRegion.Delete(CurrentSubcontractor.EngineerID)
                For Each row As DataRow In PostalRegionsDataView.Table.Rows
                    If row.Item("Tick") Then
                        DB.EngineerPostalRegion.Insert(CurrentSubcontractor.EngineerID, row.Item("ManagerID"))
                    End If
                Next

                DB.EngineerLevel.Insert(CurrentSubcontractor.EngineerID, TrainingQualificationsDataView.Table)
                DB.Engineer.SaveEquipmentRecords(CurrentSubcontractor.EngineerID, EngineerEquipmentDataView.Table)
                DB.Engineer.SaveDisciplinaryRecords(CurrentSubcontractor.EngineerID, DisciplinariesDataView.Table)
            Else
                Dim tempEng As Entity.Engineers.Engineer = DB.Engineer.Insert(CurrentSubcontractor.Engineer)
                DB.EngineerPostalRegion.Delete(tempEng.EngineerID)
                For Each row As DataRow In PostalRegionsDataView.Table.Rows
                    If row.Item("Tick") Then
                        DB.EngineerPostalRegion.Insert(tempEng.EngineerID, row.Item("ManagerID"))
                    End If
                Next

                DB.EngineerLevel.Insert(tempEng.EngineerID, TrainingQualificationsDataView.Table)
                DB.Engineer.SaveEquipmentRecords(tempEng.EngineerID, EngineerEquipmentDataView.Table)
                DB.Engineer.SaveDisciplinaryRecords(tempEng.EngineerID, DisciplinariesDataView.Table)

                CurrentSubcontractor.Engineer = tempEng

                CurrentSubcontractor.SetEngineerID = tempEng.EngineerID
                CurrentSubcontractor = DB.SubContractor.Insert(CurrentSubcontractor)
            End If

            If MaxTimes Is Nothing Then
                MaxTimes = New Entity.MaxEngineerTimes.MaxEngineerTime
            End If

            MaxTimes.SetEngineerID = CurrentSubcontractor.Engineer.EngineerID
            MaxTimes.SetMondayValue = Entity.Sys.Helper.MakeIntegerValid(Me.txtMondayValue.Text.Trim)
            MaxTimes.SetTuesdayValue = Entity.Sys.Helper.MakeIntegerValid(Me.txtTuesdayValue.Text.Trim)
            MaxTimes.SetWednesdayValue = Entity.Sys.Helper.MakeIntegerValid(Me.txtWednesdayValue.Text.Trim)
            MaxTimes.SetThursdayValue = Entity.Sys.Helper.MakeIntegerValid(Me.txtThursdayValue.Text.Trim)
            MaxTimes.SetFridayValue = Entity.Sys.Helper.MakeIntegerValid(Me.txtFridayValue.Text.Trim)
            MaxTimes.SetSaturdayValue = Entity.Sys.Helper.MakeIntegerValid(Me.txtSaturdayValue.Text.Trim)
            MaxTimes.SetSundayValue = Entity.Sys.Helper.MakeIntegerValid(Me.txtSundayValue.Text.Trim)

            Dim mTV As New Entity.MaxEngineerTimes.MaxEngineerTimeValidator
            mTV.Validate(MaxTimes)

            If MaxTimes.Exists Then
                DB.MaxEngineerTime.Update(MaxTimes)
            Else
                DB.MaxEngineerTime.Insert(MaxTimes)
            End If

            RaiseEvent RecordsChanged(DB.SubContractor.Subcontractor_GetAll(), Entity.Sys.Enums.PageViewing.Subcontractor, True, False, "")
            RaiseEvent StateChanged(CurrentSubcontractor.SubcontractorID)
            MainForm.RefreshEntity(CurrentSubcontractor.SubcontractorID)

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
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 200
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString
        Me.dgPostalRegions.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgPostalRegions)
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
                Return Nothing
            End If
        End Get
    End Property

    Private Sub PopulateTrainingQualifications()
        Try
            TrainingQualificationsDataView = DB.EngineerLevel.GetForSetup(CurrentSubcontractor.EngineerID)
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
            r("Level") = Combo.GetSelectedItemDescription(cboQualification).ToString.Split("*")(1).Trim()
            r("Description") = Combo.GetSelectedItemDescription(cboQualification).ToString.Split("*")(0).Trim()
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
                Return Nothing
            End If
        End Get
    End Property

    Private Sub PopulateEngineerEquipment()
        Try
            EngineerEquipmentDataView = New DataView(DB.Engineer.GetEquipmentRecords(CurrentSubcontractor.EngineerID))
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
            DisciplinariesDataView = New DataView(DB.Engineer.GetDisciplinaryRecords(CurrentSubcontractor.EngineerID))
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
            AbsencesDataView = New DataView(DB.EngineerAbsence.GetAbsencesForEngineer(CurrentSubcontractor.EngineerID))
        Catch ex As Exception
            ShowMessage("The following error occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgTrainingQualifications_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgTrainingQualifications.Click, dgTrainingQualifications.CurrentCellChanged
        Try
            Combo.SetUpCombo(Me.cboQualificationType, DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
            Combo.SetSelectedComboItem_By_Value(cboQualification, SelectedTrainingQualificationsRow.Item(0).ToString)
            txtQualificatioNote.Text = Entity.Sys.Helper.MakeStringValid(SelectedTrainingQualificationsRow.Item(3))
            dtpQualificationPassed.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedTrainingQualificationsRow.Item(4))
            dtpQualificationExpires.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedTrainingQualificationsRow.Item(5))
            dtpQualificationBooked.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedTrainingQualificationsRow.Item(6))
        Catch
        End Try
    End Sub

    Private Sub dgPostalRegions_Click(sender As Object, e As EventArgs) Handles dgPostalRegions.Click
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

    Private Sub dgUnTicked_Click(sender As Object, e As EventArgs) Handles dgUnTicked.Click
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

    Private Sub txtPCSearch_TextChanged(sender As Object, e As EventArgs) Handles txtPCSearch.TextChanged
        Dim whereClause As String = "Name Like '%" + txtPCSearch.Text + "%'"
        PostalRegionsDataViewUT.RowFilter = whereClause
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

#End Region

End Class