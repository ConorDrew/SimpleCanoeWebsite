Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports Entity.Sys
Imports FSM.Entity.Sys
Imports FSM.Entity

Public Class UCJobWizard : Inherits FSM.UCBase : Implements IUserControl

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Try
            tcSites.TabPages(0).Enabled = True
            tcSites.TabPages.Remove(tabJobType)
            tcSites.TabPages.Remove(tabJobDetails)
            tcSites.TabPages.Remove(tabAppliance)
            tcSites.TabPages.Remove(TabCharging)
            tcSites.TabPages.Remove(tabAdditional)
            tcSites.TabPages.Remove(TabBook)
            tcSites.TabPages.Remove(tcComplete)
            tcSites.TabPages.Remove(tabExistingJobs)
        Catch ex As Exception

        End Try

        Combo.SetUpCombo(Me.cboTitle, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cbotypeWiz, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPayTerms, DynamicDataTables.JobWizTerms, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAdditional, DynamicDataTables.JobWizAdditional, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAppointment, DB.Picklists.GetAll(78).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.All_Appointments)
        Combo.SetUpCombo(Me.cboEngineer, DB.Engineer.Engineer_GetAll.Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)

        'cboEngineer.Items.Add(New Combo("-- Not Applicable --", 0))
        'Combo.SetSelectedComboItem_By_Value(cboEngineer, 0)

        btnxxSiteNext.Visible = False

        cbotypeWiz.AutoCompleteMode = AutoCompleteMode.Suggest
        cbotypeWiz.AutoCompleteSource = AutoCompleteSource.ListItems
        'Combo.SetUpCombo(Me.cboDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

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

#Region " Windows Form Designer generated code "

    Friend WithEvents tabJobDetails As System.Windows.Forms.TabPage
    Friend WithEvents tabAppliance As System.Windows.Forms.TabPage
    Friend WithEvents tabJobType As System.Windows.Forms.TabPage
    Friend WithEvents tabProp As System.Windows.Forms.TabPage
    Friend WithEvents tcSites As System.Windows.Forms.TabControl
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents DGVSites As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEditSite As System.Windows.Forms.Button
    Friend WithEvents btnAddSite As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTitle As System.Windows.Forms.ComboBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents txtSurname As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMob As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents btnxxSiteNext As System.Windows.Forms.Button
    Friend WithEvents btnxxOther As System.Windows.Forms.Button
    Friend WithEvents btnxxBreakdown As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnxxService As System.Windows.Forms.Button
    Friend WithEvents lbltype As System.Windows.Forms.Label
    Friend WithEvents cbotypeWiz As System.Windows.Forms.ComboBox
    Friend WithEvents DgMain As System.Windows.Forms.DataGridView
    Friend WithEvents btnMinusMain As System.Windows.Forms.Button
    Friend WithEvents btnAddMain As System.Windows.Forms.Button
    Friend WithEvents cboMainApps As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnxxJobNext As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnxxSOR As System.Windows.Forms.Button
    Friend WithEvents pnlSOR As System.Windows.Forms.Panel
    Friend WithEvents DGSOR As System.Windows.Forms.DataGridView
    Friend WithEvents txtSORQty As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnSORAdd As System.Windows.Forms.Button
    Friend WithEvents cboSOR As System.Windows.Forms.ComboBox
    Friend WithEvents btnSORMinus As System.Windows.Forms.Button
    Friend WithEvents btnxxApplianceNext As System.Windows.Forms.Button
    Friend WithEvents btnxxDetailsNext As System.Windows.Forms.Button
    Friend WithEvents TabCharging As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents pnlCharge As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCharge As System.Windows.Forms.TextBox
    Friend WithEvents btnxxChargeNext As System.Windows.Forms.Button
    Friend WithEvents txtPayInst As System.Windows.Forms.TextBox
    Friend WithEvents chkRecall As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents pnlSymptoms As System.Windows.Forms.Panel
    Friend WithEvents lblSymptom As System.Windows.Forms.Label
    Friend WithEvents cboSymptom As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DGSymptoms As System.Windows.Forms.DataGridView
    Friend WithEvents btnSymMinus As System.Windows.Forms.Button
    Friend WithEvents btnSymAdd As System.Windows.Forms.Button
    Friend WithEvents lblPriority As System.Windows.Forms.Label
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents tabAdditional As System.Windows.Forms.TabPage
    Friend WithEvents btnxxAdditionalNext As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboAdditional As System.Windows.Forms.ComboBox
    Friend WithEvents DGAdditional As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdditionalMinus As System.Windows.Forms.Button
    Friend WithEvents btnAdditionalPlus As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboPayTerms As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoverplanServ As System.Windows.Forms.Label
    Friend WithEvents TabBook As System.Windows.Forms.TabPage
    Friend WithEvents lblBookText As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnOption10 As System.Windows.Forms.Button
    Friend WithEvents btnOption4 As System.Windows.Forms.Button
    Friend WithEvents btnOption3 As System.Windows.Forms.Button
    Friend WithEvents btnOption2 As System.Windows.Forms.Button
    Friend WithEvents btnOption1 As System.Windows.Forms.Button
    Friend WithEvents chkKeepTogether As System.Windows.Forms.CheckBox
    Friend WithEvents gpCombo As System.Windows.Forms.GroupBox
    Friend WithEvents pnlTypeOfWorks As System.Windows.Forms.Panel
    Friend WithEvents cboTypeOfWorks As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnxxFollow As System.Windows.Forms.Button
    Friend WithEvents btnxx1 As System.Windows.Forms.Button
    Friend WithEvents btnxx2 As System.Windows.Forms.Button
    Friend WithEvents btnxx3 As System.Windows.Forms.Button
    Friend WithEvents btnxx4 As System.Windows.Forms.Button
    Friend WithEvents btnxx5 As System.Windows.Forms.Button
    Friend WithEvents btnxx6 As System.Windows.Forms.Button
    Friend WithEvents btnJobHistory As System.Windows.Forms.Button
    Friend WithEvents chkCert As System.Windows.Forms.CheckBox
    Friend WithEvents lblcert As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
    Friend WithEvents lblAdditional As System.Windows.Forms.Label
    Friend WithEvents txtAdditional As System.Windows.Forms.TextBox
    Friend WithEvents cboAppointment As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboEngineer As System.Windows.Forms.ComboBox
    Friend WithEvents tcComplete As System.Windows.Forms.TabPage
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnRestart As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtContractRef As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tabExistingJobs As System.Windows.Forms.TabPage
    Friend WithEvents dgExistingVisits As System.Windows.Forms.DataGridView
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents btnxxNewJob As System.Windows.Forms.Button
    Friend WithEvents btnxxExistingJobBack As System.Windows.Forms.Button
    Friend WithEvents btnxxExistingJobNext As System.Windows.Forms.Button
    Friend WithEvents lblUnabletoConfirm As System.Windows.Forms.Label
    Friend WithEvents txtSiteNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblBookedInfo As Label
    Friend WithEvents btnxxExternalBM As Button
    Friend WithEvents btnxxCarpentry As Button
    Friend WithEvents btnxxPlumbing As Button
    Friend WithEvents btnxxElectrical As Button
    Friend WithEvents btnxxMultiTrade As Button
    Friend WithEvents btnxxKitchens As Button
    Friend WithEvents pnlTimeReq As Panel
    Friend WithEvents Label34 As Label
    Friend WithEvents txtHrs As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents txtDays As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnOption8 As Button
    Friend WithEvents btnOption7 As Button
    Friend WithEvents btnOption6 As Button
    Friend WithEvents btnOption5 As Button
    Friend WithEvents Label35 As Label
    Friend WithEvents txtDiscountCode As TextBox
    Friend WithEvents picTick As PictureBox
    Friend WithEvents picCross As PictureBox
    Friend WithEvents btnDocument As Button
    Friend WithEvents txtSearchSite As Button
    Friend WithEvents chbCommercial As CheckBox
    Friend WithEvents lblContactAlert As Label
    Friend WithEvents txtContactAlert As TextBox
    Friend WithEvents lblDefect As Label
    Friend WithEvents txtDefect As TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCJobWizard))
        Me.tabJobDetails = New System.Windows.Forms.TabPage()
        Me.pnlTimeReq = New System.Windows.Forms.Panel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtHrs = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtDays = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPONumber = New System.Windows.Forms.TextBox()
        Me.lblAdditional = New System.Windows.Forms.Label()
        Me.txtAdditional = New System.Windows.Forms.TextBox()
        Me.btnxx2 = New System.Windows.Forms.Button()
        Me.pnlTypeOfWorks = New System.Windows.Forms.Panel()
        Me.cboTypeOfWorks = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.pnlSymptoms = New System.Windows.Forms.Panel()
        Me.lblSymptom = New System.Windows.Forms.Label()
        Me.cboSymptom = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DGSymptoms = New System.Windows.Forms.DataGridView()
        Me.btnSymMinus = New System.Windows.Forms.Button()
        Me.btnSymAdd = New System.Windows.Forms.Button()
        Me.lblPriority = New System.Windows.Forms.Label()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnxxDetailsNext = New System.Windows.Forms.Button()
        Me.tabAppliance = New System.Windows.Forms.TabPage()
        Me.btnxx3 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DgMain = New System.Windows.Forms.DataGridView()
        Me.btnMinusMain = New System.Windows.Forms.Button()
        Me.btnAddMain = New System.Windows.Forms.Button()
        Me.cboMainApps = New System.Windows.Forms.ComboBox()
        Me.btnxxApplianceNext = New System.Windows.Forms.Button()
        Me.tabJobType = New System.Windows.Forms.TabPage()
        Me.btnxxExternalBM = New System.Windows.Forms.Button()
        Me.btnxxCarpentry = New System.Windows.Forms.Button()
        Me.btnxxPlumbing = New System.Windows.Forms.Button()
        Me.btnxxElectrical = New System.Windows.Forms.Button()
        Me.btnxxMultiTrade = New System.Windows.Forms.Button()
        Me.btnxxKitchens = New System.Windows.Forms.Button()
        Me.btnxx1 = New System.Windows.Forms.Button()
        Me.pnlSOR = New System.Windows.Forms.Panel()
        Me.DGSOR = New System.Windows.Forms.DataGridView()
        Me.btnxxFollow = New System.Windows.Forms.Button()
        Me.txtSORQty = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnSORAdd = New System.Windows.Forms.Button()
        Me.cboSOR = New System.Windows.Forms.ComboBox()
        Me.btnSORMinus = New System.Windows.Forms.Button()
        Me.btnxxSOR = New System.Windows.Forms.Button()
        Me.lbltype = New System.Windows.Forms.Label()
        Me.cbotypeWiz = New System.Windows.Forms.ComboBox()
        Me.btnxxBreakdown = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnxxService = New System.Windows.Forms.Button()
        Me.btnxxOther = New System.Windows.Forms.Button()
        Me.btnxxJobNext = New System.Windows.Forms.Button()
        Me.tabProp = New System.Windows.Forms.TabPage()
        Me.lblDefect = New System.Windows.Forms.Label()
        Me.txtDefect = New System.Windows.Forms.TextBox()
        Me.chbCommercial = New System.Windows.Forms.CheckBox()
        Me.lblContactAlert = New System.Windows.Forms.Label()
        Me.txtContactAlert = New System.Windows.Forms.TextBox()
        Me.txtSearchSite = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtSiteNotes = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtContractRef = New System.Windows.Forms.TextBox()
        Me.btnJobHistory = New System.Windows.Forms.Button()
        Me.btnxxSiteNext = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMob = New System.Windows.Forms.TextBox()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTitle = New System.Windows.Forms.ComboBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.btnEditSite = New System.Windows.Forms.Button()
        Me.btnAddSite = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.DGVSites = New System.Windows.Forms.DataGridView()
        Me.tcSites = New System.Windows.Forms.TabControl()
        Me.tabExistingJobs = New System.Windows.Forms.TabPage()
        Me.btnxxExistingJobBack = New System.Windows.Forms.Button()
        Me.btnxxExistingJobNext = New System.Windows.Forms.Button()
        Me.dgExistingVisits = New System.Windows.Forms.DataGridView()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnxxNewJob = New System.Windows.Forms.Button()
        Me.tabAdditional = New System.Windows.Forms.TabPage()
        Me.chkCert = New System.Windows.Forms.CheckBox()
        Me.lblcert = New System.Windows.Forms.Label()
        Me.btnxx4 = New System.Windows.Forms.Button()
        Me.lblCoverplanServ = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboAdditional = New System.Windows.Forms.ComboBox()
        Me.DGAdditional = New System.Windows.Forms.DataGridView()
        Me.btnAdditionalMinus = New System.Windows.Forms.Button()
        Me.btnAdditionalPlus = New System.Windows.Forms.Button()
        Me.btnxxAdditionalNext = New System.Windows.Forms.Button()
        Me.TabCharging = New System.Windows.Forms.TabPage()
        Me.lblUnabletoConfirm = New System.Windows.Forms.Label()
        Me.btnxx5 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboPayTerms = New System.Windows.Forms.ComboBox()
        Me.chkRecall = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.pnlCharge = New System.Windows.Forms.Panel()
        Me.picTick = New System.Windows.Forms.PictureBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtDiscountCode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCharge = New System.Windows.Forms.TextBox()
        Me.picCross = New System.Windows.Forms.PictureBox()
        Me.txtPayInst = New System.Windows.Forms.TextBox()
        Me.btnxxChargeNext = New System.Windows.Forms.Button()
        Me.TabBook = New System.Windows.Forms.TabPage()
        Me.btnOption8 = New System.Windows.Forms.Button()
        Me.btnOption7 = New System.Windows.Forms.Button()
        Me.btnOption6 = New System.Windows.Forms.Button()
        Me.btnOption5 = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboEngineer = New System.Windows.Forms.ComboBox()
        Me.btnxx6 = New System.Windows.Forms.Button()
        Me.gpCombo = New System.Windows.Forms.GroupBox()
        Me.cboAppointment = New System.Windows.Forms.ComboBox()
        Me.lblBookText = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.btnOption10 = New System.Windows.Forms.Button()
        Me.btnOption4 = New System.Windows.Forms.Button()
        Me.btnOption3 = New System.Windows.Forms.Button()
        Me.btnOption2 = New System.Windows.Forms.Button()
        Me.btnOption1 = New System.Windows.Forms.Button()
        Me.chkKeepTogether = New System.Windows.Forms.CheckBox()
        Me.tcComplete = New System.Windows.Forms.TabPage()
        Me.btnDocument = New System.Windows.Forms.Button()
        Me.lblBookedInfo = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tabJobDetails.SuspendLayout()
        Me.pnlTimeReq.SuspendLayout()
        Me.pnlTypeOfWorks.SuspendLayout()
        Me.pnlSymptoms.SuspendLayout()
        CType(Me.DGSymptoms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAppliance.SuspendLayout()
        CType(Me.DgMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabJobType.SuspendLayout()
        Me.pnlSOR.SuspendLayout()
        CType(Me.DGSOR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabProp.SuspendLayout()
        CType(Me.DGVSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcSites.SuspendLayout()
        Me.tabExistingJobs.SuspendLayout()
        CType(Me.dgExistingVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAdditional.SuspendLayout()
        CType(Me.DGAdditional, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCharging.SuspendLayout()
        Me.pnlCharge.SuspendLayout()
        CType(Me.picTick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCross, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabBook.SuspendLayout()
        Me.gpCombo.SuspendLayout()
        Me.tcComplete.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabJobDetails
        '
        Me.tabJobDetails.Controls.Add(Me.pnlTimeReq)
        Me.tabJobDetails.Controls.Add(Me.Label26)
        Me.tabJobDetails.Controls.Add(Me.txtPONumber)
        Me.tabJobDetails.Controls.Add(Me.lblAdditional)
        Me.tabJobDetails.Controls.Add(Me.txtAdditional)
        Me.tabJobDetails.Controls.Add(Me.btnxx2)
        Me.tabJobDetails.Controls.Add(Me.pnlTypeOfWorks)
        Me.tabJobDetails.Controls.Add(Me.pnlSymptoms)
        Me.tabJobDetails.Controls.Add(Me.lblPriority)
        Me.tabJobDetails.Controls.Add(Me.cboPriority)
        Me.tabJobDetails.Controls.Add(Me.Label12)
        Me.tabJobDetails.Controls.Add(Me.btnxxDetailsNext)
        Me.tabJobDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabJobDetails.Name = "tabJobDetails"
        Me.tabJobDetails.Size = New System.Drawing.Size(877, 774)
        Me.tabJobDetails.TabIndex = 4
        Me.tabJobDetails.Text = "Job Details"
        '
        'pnlTimeReq
        '
        Me.pnlTimeReq.Controls.Add(Me.Label34)
        Me.pnlTimeReq.Controls.Add(Me.txtHrs)
        Me.pnlTimeReq.Controls.Add(Me.Label32)
        Me.pnlTimeReq.Controls.Add(Me.Label33)
        Me.pnlTimeReq.Controls.Add(Me.txtDays)
        Me.pnlTimeReq.Location = New System.Drawing.Point(124, 354)
        Me.pnlTimeReq.Name = "pnlTimeReq"
        Me.pnlTimeReq.Size = New System.Drawing.Size(550, 42)
        Me.pnlTimeReq.TabIndex = 173
        Me.pnlTimeReq.Visible = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label34.Location = New System.Drawing.Point(432, 11)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(32, 17)
        Me.Label34.TabIndex = 174
        Me.Label34.Text = "Hrs"
        '
        'txtHrs
        '
        Me.txtHrs.Location = New System.Drawing.Point(347, 10)
        Me.txtHrs.Name = "txtHrs"
        Me.txtHrs.Size = New System.Drawing.Size(79, 21)
        Me.txtHrs.TabIndex = 173
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label32.Location = New System.Drawing.Point(3, 12)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(135, 17)
        Me.Label32.TabIndex = 170
        Me.Label32.Text = "Time Requirement"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label33.Location = New System.Drawing.Point(264, 11)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(43, 17)
        Me.Label33.TabIndex = 172
        Me.Label33.Text = "Days"
        '
        'txtDays
        '
        Me.txtDays.Location = New System.Drawing.Point(189, 10)
        Me.txtDays.Name = "txtDays"
        Me.txtDays.Size = New System.Drawing.Size(69, 21)
        Me.txtDays.TabIndex = 171
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label26.Location = New System.Drawing.Point(128, 407)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(143, 17)
        Me.Label26.TabIndex = 169
        Me.Label26.Text = "PO / Order Number"
        '
        'txtPONumber
        '
        Me.txtPONumber.Location = New System.Drawing.Point(306, 407)
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.Size = New System.Drawing.Size(358, 21)
        Me.txtPONumber.TabIndex = 168
        '
        'lblAdditional
        '
        Me.lblAdditional.AutoSize = True
        Me.lblAdditional.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.lblAdditional.Location = New System.Drawing.Point(127, 453)
        Me.lblAdditional.Name = "lblAdditional"
        Me.lblAdditional.Size = New System.Drawing.Size(97, 17)
        Me.lblAdditional.TabIndex = 167
        Me.lblAdditional.Text = "Work Details"
        Me.lblAdditional.Visible = False
        '
        'txtAdditional
        '
        Me.txtAdditional.Location = New System.Drawing.Point(305, 450)
        Me.txtAdditional.Multiline = True
        Me.txtAdditional.Name = "txtAdditional"
        Me.txtAdditional.Size = New System.Drawing.Size(358, 99)
        Me.txtAdditional.TabIndex = 166
        Me.txtAdditional.Visible = False
        '
        'btnxx2
        '
        Me.btnxx2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnxx2.BackColor = System.Drawing.SystemColors.Control
        Me.btnxx2.BackgroundImage = CType(resources.GetObject("btnxx2.BackgroundImage"), System.Drawing.Image)
        Me.btnxx2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxx2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxx2.Location = New System.Drawing.Point(3, 707)
        Me.btnxx2.Name = "btnxx2"
        Me.btnxx2.Size = New System.Drawing.Size(62, 45)
        Me.btnxx2.TabIndex = 163
        Me.btnxx2.UseVisualStyleBackColor = False
        '
        'pnlTypeOfWorks
        '
        Me.pnlTypeOfWorks.Controls.Add(Me.cboTypeOfWorks)
        Me.pnlTypeOfWorks.Controls.Add(Me.Label25)
        Me.pnlTypeOfWorks.Location = New System.Drawing.Point(124, 354)
        Me.pnlTypeOfWorks.Name = "pnlTypeOfWorks"
        Me.pnlTypeOfWorks.Size = New System.Drawing.Size(550, 42)
        Me.pnlTypeOfWorks.TabIndex = 162
        '
        'cboTypeOfWorks
        '
        Me.cboTypeOfWorks.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cboTypeOfWorks.FormattingEnabled = True
        Me.cboTypeOfWorks.Location = New System.Drawing.Point(189, 10)
        Me.cboTypeOfWorks.Name = "cboTypeOfWorks"
        Me.cboTypeOfWorks.Size = New System.Drawing.Size(357, 22)
        Me.cboTypeOfWorks.TabIndex = 163
        Me.cboTypeOfWorks.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label25.Location = New System.Drawing.Point(11, 10)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 17)
        Me.Label25.TabIndex = 162
        Me.Label25.Text = "Type Of Works"
        Me.Label25.Visible = False
        '
        'pnlSymptoms
        '
        Me.pnlSymptoms.Controls.Add(Me.lblSymptom)
        Me.pnlSymptoms.Controls.Add(Me.cboSymptom)
        Me.pnlSymptoms.Controls.Add(Me.Label15)
        Me.pnlSymptoms.Controls.Add(Me.DGSymptoms)
        Me.pnlSymptoms.Controls.Add(Me.btnSymMinus)
        Me.pnlSymptoms.Controls.Add(Me.btnSymAdd)
        Me.pnlSymptoms.Location = New System.Drawing.Point(95, 155)
        Me.pnlSymptoms.Name = "pnlSymptoms"
        Me.pnlSymptoms.Size = New System.Drawing.Size(602, 193)
        Me.pnlSymptoms.TabIndex = 158
        '
        'lblSymptom
        '
        Me.lblSymptom.AutoSize = True
        Me.lblSymptom.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.lblSymptom.Location = New System.Drawing.Point(34, 14)
        Me.lblSymptom.Name = "lblSymptom"
        Me.lblSymptom.Size = New System.Drawing.Size(76, 17)
        Me.lblSymptom.TabIndex = 159
        Me.lblSymptom.Text = "Symptom"
        '
        'cboSymptom
        '
        Me.cboSymptom.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cboSymptom.FormattingEnabled = True
        Me.cboSymptom.Location = New System.Drawing.Point(210, 12)
        Me.cboSymptom.Name = "cboSymptom"
        Me.cboSymptom.Size = New System.Drawing.Size(358, 22)
        Me.cboSymptom.TabIndex = 158
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label15.Location = New System.Drawing.Point(34, 67)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(140, 17)
        Me.Label15.TabIndex = 157
        Me.Label15.Text = "Applied Symptoms"
        '
        'DGSymptoms
        '
        Me.DGSymptoms.AllowUserToAddRows = False
        Me.DGSymptoms.AllowUserToDeleteRows = False
        Me.DGSymptoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGSymptoms.ColumnHeadersVisible = False
        Me.DGSymptoms.Location = New System.Drawing.Point(210, 67)
        Me.DGSymptoms.MultiSelect = False
        Me.DGSymptoms.Name = "DGSymptoms"
        Me.DGSymptoms.ReadOnly = True
        Me.DGSymptoms.RowHeadersVisible = False
        Me.DGSymptoms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGSymptoms.ShowCellErrors = False
        Me.DGSymptoms.ShowEditingIcon = False
        Me.DGSymptoms.ShowRowErrors = False
        Me.DGSymptoms.Size = New System.Drawing.Size(359, 122)
        Me.DGSymptoms.TabIndex = 156
        '
        'btnSymMinus
        '
        Me.btnSymMinus.Location = New System.Drawing.Point(346, 39)
        Me.btnSymMinus.Name = "btnSymMinus"
        Me.btnSymMinus.Size = New System.Drawing.Size(39, 23)
        Me.btnSymMinus.TabIndex = 155
        Me.btnSymMinus.Text = "-"
        Me.btnSymMinus.UseVisualStyleBackColor = True
        '
        'btnSymAdd
        '
        Me.btnSymAdd.Location = New System.Drawing.Point(391, 39)
        Me.btnSymAdd.Name = "btnSymAdd"
        Me.btnSymAdd.Size = New System.Drawing.Size(39, 23)
        Me.btnSymAdd.TabIndex = 154
        Me.btnSymAdd.Text = "+"
        Me.btnSymAdd.UseVisualStyleBackColor = True
        '
        'lblPriority
        '
        Me.lblPriority.AutoSize = True
        Me.lblPriority.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.lblPriority.Location = New System.Drawing.Point(127, 120)
        Me.lblPriority.Name = "lblPriority"
        Me.lblPriority.Size = New System.Drawing.Size(57, 17)
        Me.lblPriority.TabIndex = 157
        Me.lblPriority.Text = "Priority"
        Me.lblPriority.Visible = False
        '
        'cboPriority
        '
        Me.cboPriority.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cboPriority.FormattingEnabled = True
        Me.cboPriority.Location = New System.Drawing.Point(304, 118)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(357, 22)
        Me.cboPriority.TabIndex = 156
        Me.cboPriority.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(411, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(141, 25)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Job Details"
        '
        'btnxxDetailsNext
        '
        Me.btnxxDetailsNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnxxDetailsNext.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxDetailsNext.BackgroundImage = CType(resources.GetObject("btnxxDetailsNext.BackgroundImage"), System.Drawing.Image)
        Me.btnxxDetailsNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxxDetailsNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxDetailsNext.Location = New System.Drawing.Point(812, 707)
        Me.btnxxDetailsNext.Name = "btnxxDetailsNext"
        Me.btnxxDetailsNext.Size = New System.Drawing.Size(62, 45)
        Me.btnxxDetailsNext.TabIndex = 154
        Me.btnxxDetailsNext.UseVisualStyleBackColor = False
        Me.btnxxDetailsNext.Visible = False
        '
        'tabAppliance
        '
        Me.tabAppliance.Controls.Add(Me.btnxx3)
        Me.tabAppliance.Controls.Add(Me.Label20)
        Me.tabAppliance.Controls.Add(Me.Label13)
        Me.tabAppliance.Controls.Add(Me.DgMain)
        Me.tabAppliance.Controls.Add(Me.btnMinusMain)
        Me.tabAppliance.Controls.Add(Me.btnAddMain)
        Me.tabAppliance.Controls.Add(Me.cboMainApps)
        Me.tabAppliance.Controls.Add(Me.btnxxApplianceNext)
        Me.tabAppliance.Location = New System.Drawing.Point(4, 22)
        Me.tabAppliance.Name = "tabAppliance"
        Me.tabAppliance.Size = New System.Drawing.Size(877, 774)
        Me.tabAppliance.TabIndex = 3
        Me.tabAppliance.Text = "Associated Assets"
        '
        'btnxx3
        '
        Me.btnxx3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnxx3.BackColor = System.Drawing.SystemColors.Control
        Me.btnxx3.BackgroundImage = CType(resources.GetObject("btnxx3.BackgroundImage"), System.Drawing.Image)
        Me.btnxx3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxx3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxx3.Location = New System.Drawing.Point(3, 627)
        Me.btnxx3.Name = "btnxx3"
        Me.btnxx3.Size = New System.Drawing.Size(62, 45)
        Me.btnxx3.TabIndex = 169
        Me.btnxx3.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label20.Location = New System.Drawing.Point(218, 97)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(436, 17)
        Me.Label20.TabIndex = 168
        Me.Label20.Text = "Add any asset either to be serviced or affected by the works"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(291, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(243, 25)
        Me.Label13.TabIndex = 150
        Me.Label13.Text = "Associated Asset(s)"
        '
        'DgMain
        '
        Me.DgMain.AllowUserToAddRows = False
        Me.DgMain.AllowUserToDeleteRows = False
        Me.DgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgMain.ColumnHeadersVisible = False
        Me.DgMain.Location = New System.Drawing.Point(292, 210)
        Me.DgMain.MultiSelect = False
        Me.DgMain.Name = "DgMain"
        Me.DgMain.ReadOnly = True
        Me.DgMain.RowHeadersVisible = False
        Me.DgMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgMain.ShowCellErrors = False
        Me.DgMain.ShowEditingIcon = False
        Me.DgMain.ShowRowErrors = False
        Me.DgMain.Size = New System.Drawing.Size(293, 175)
        Me.DgMain.TabIndex = 149
        '
        'btnMinusMain
        '
        Me.btnMinusMain.Location = New System.Drawing.Point(392, 182)
        Me.btnMinusMain.Name = "btnMinusMain"
        Me.btnMinusMain.Size = New System.Drawing.Size(39, 23)
        Me.btnMinusMain.TabIndex = 148
        Me.btnMinusMain.Text = "-"
        Me.btnMinusMain.UseVisualStyleBackColor = True
        '
        'btnAddMain
        '
        Me.btnAddMain.Location = New System.Drawing.Point(437, 182)
        Me.btnAddMain.Name = "btnAddMain"
        Me.btnAddMain.Size = New System.Drawing.Size(39, 23)
        Me.btnAddMain.TabIndex = 147
        Me.btnAddMain.Text = "+"
        Me.btnAddMain.UseVisualStyleBackColor = True
        '
        'cboMainApps
        '
        Me.cboMainApps.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMainApps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMainApps.Location = New System.Drawing.Point(292, 155)
        Me.cboMainApps.Name = "cboMainApps"
        Me.cboMainApps.Size = New System.Drawing.Size(293, 21)
        Me.cboMainApps.TabIndex = 146
        Me.cboMainApps.Tag = ""
        '
        'btnxxApplianceNext
        '
        Me.btnxxApplianceNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnxxApplianceNext.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxApplianceNext.BackgroundImage = CType(resources.GetObject("btnxxApplianceNext.BackgroundImage"), System.Drawing.Image)
        Me.btnxxApplianceNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxxApplianceNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxApplianceNext.Location = New System.Drawing.Point(812, 627)
        Me.btnxxApplianceNext.Name = "btnxxApplianceNext"
        Me.btnxxApplianceNext.Size = New System.Drawing.Size(62, 45)
        Me.btnxxApplianceNext.TabIndex = 151
        Me.btnxxApplianceNext.UseVisualStyleBackColor = False
        Me.btnxxApplianceNext.Visible = False
        '
        'tabJobType
        '
        Me.tabJobType.Controls.Add(Me.btnxxExternalBM)
        Me.tabJobType.Controls.Add(Me.btnxxCarpentry)
        Me.tabJobType.Controls.Add(Me.btnxxPlumbing)
        Me.tabJobType.Controls.Add(Me.btnxxElectrical)
        Me.tabJobType.Controls.Add(Me.btnxxMultiTrade)
        Me.tabJobType.Controls.Add(Me.btnxxKitchens)
        Me.tabJobType.Controls.Add(Me.btnxx1)
        Me.tabJobType.Controls.Add(Me.pnlSOR)
        Me.tabJobType.Controls.Add(Me.btnxxSOR)
        Me.tabJobType.Controls.Add(Me.lbltype)
        Me.tabJobType.Controls.Add(Me.cbotypeWiz)
        Me.tabJobType.Controls.Add(Me.btnxxBreakdown)
        Me.tabJobType.Controls.Add(Me.Label11)
        Me.tabJobType.Controls.Add(Me.BtnxxService)
        Me.tabJobType.Controls.Add(Me.btnxxOther)
        Me.tabJobType.Controls.Add(Me.btnxxJobNext)
        Me.tabJobType.Location = New System.Drawing.Point(4, 22)
        Me.tabJobType.Name = "tabJobType"
        Me.tabJobType.Size = New System.Drawing.Size(877, 774)
        Me.tabJobType.TabIndex = 8
        Me.tabJobType.Text = "Job Type"
        '
        'btnxxExternalBM
        '
        Me.btnxxExternalBM.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxExternalBM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxExternalBM.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxExternalBM.Location = New System.Drawing.Point(196, 270)
        Me.btnxxExternalBM.Name = "btnxxExternalBM"
        Me.btnxxExternalBM.Size = New System.Drawing.Size(511, 41)
        Me.btnxxExternalBM.TabIndex = 164
        Me.btnxxExternalBM.Text = "Other External B and M"
        Me.btnxxExternalBM.UseVisualStyleBackColor = False
        Me.btnxxExternalBM.Visible = False
        '
        'btnxxCarpentry
        '
        Me.btnxxCarpentry.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxCarpentry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxCarpentry.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxCarpentry.Location = New System.Drawing.Point(196, 226)
        Me.btnxxCarpentry.Name = "btnxxCarpentry"
        Me.btnxxCarpentry.Size = New System.Drawing.Size(511, 41)
        Me.btnxxCarpentry.TabIndex = 163
        Me.btnxxCarpentry.Tag = "71039"
        Me.btnxxCarpentry.Text = "Carpentry"
        Me.btnxxCarpentry.UseVisualStyleBackColor = False
        Me.btnxxCarpentry.Visible = False
        '
        'btnxxPlumbing
        '
        Me.btnxxPlumbing.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxPlumbing.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxPlumbing.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxPlumbing.Location = New System.Drawing.Point(196, 182)
        Me.btnxxPlumbing.Name = "btnxxPlumbing"
        Me.btnxxPlumbing.Size = New System.Drawing.Size(511, 41)
        Me.btnxxPlumbing.TabIndex = 162
        Me.btnxxPlumbing.Tag = "4754"
        Me.btnxxPlumbing.Text = "Plumbing"
        Me.btnxxPlumbing.UseVisualStyleBackColor = False
        Me.btnxxPlumbing.Visible = False
        '
        'btnxxElectrical
        '
        Me.btnxxElectrical.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxElectrical.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxElectrical.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxElectrical.Location = New System.Drawing.Point(196, 138)
        Me.btnxxElectrical.Name = "btnxxElectrical"
        Me.btnxxElectrical.Size = New System.Drawing.Size(511, 41)
        Me.btnxxElectrical.TabIndex = 161
        Me.btnxxElectrical.Tag = "68121"
        Me.btnxxElectrical.Text = "Electrical"
        Me.btnxxElectrical.UseVisualStyleBackColor = False
        Me.btnxxElectrical.Visible = False
        '
        'btnxxMultiTrade
        '
        Me.btnxxMultiTrade.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxMultiTrade.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxMultiTrade.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxMultiTrade.Location = New System.Drawing.Point(196, 94)
        Me.btnxxMultiTrade.Name = "btnxxMultiTrade"
        Me.btnxxMultiTrade.Size = New System.Drawing.Size(511, 41)
        Me.btnxxMultiTrade.TabIndex = 160
        Me.btnxxMultiTrade.Tag = "71044"
        Me.btnxxMultiTrade.Text = "Multi Trade"
        Me.btnxxMultiTrade.UseVisualStyleBackColor = False
        Me.btnxxMultiTrade.Visible = False
        '
        'btnxxKitchens
        '
        Me.btnxxKitchens.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxKitchens.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxKitchens.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxKitchens.Location = New System.Drawing.Point(196, 50)
        Me.btnxxKitchens.Name = "btnxxKitchens"
        Me.btnxxKitchens.Size = New System.Drawing.Size(511, 41)
        Me.btnxxKitchens.TabIndex = 159
        Me.btnxxKitchens.Text = "Kitchens"
        Me.btnxxKitchens.UseVisualStyleBackColor = False
        Me.btnxxKitchens.Visible = False
        '
        'btnxx1
        '
        Me.btnxx1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnxx1.BackColor = System.Drawing.SystemColors.Control
        Me.btnxx1.BackgroundImage = CType(resources.GetObject("btnxx1.BackgroundImage"), System.Drawing.Image)
        Me.btnxx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxx1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxx1.Location = New System.Drawing.Point(3, 627)
        Me.btnxx1.Name = "btnxx1"
        Me.btnxx1.Size = New System.Drawing.Size(62, 45)
        Me.btnxx1.TabIndex = 158
        Me.btnxx1.UseVisualStyleBackColor = False
        '
        'pnlSOR
        '
        Me.pnlSOR.Controls.Add(Me.DGSOR)
        Me.pnlSOR.Controls.Add(Me.btnxxFollow)
        Me.pnlSOR.Controls.Add(Me.txtSORQty)
        Me.pnlSOR.Controls.Add(Me.Label14)
        Me.pnlSOR.Controls.Add(Me.btnSORAdd)
        Me.pnlSOR.Controls.Add(Me.cboSOR)
        Me.pnlSOR.Controls.Add(Me.btnSORMinus)
        Me.pnlSOR.Location = New System.Drawing.Point(193, 423)
        Me.pnlSOR.Name = "pnlSOR"
        Me.pnlSOR.Size = New System.Drawing.Size(519, 159)
        Me.pnlSOR.TabIndex = 156
        Me.pnlSOR.Visible = False
        '
        'DGSOR
        '
        Me.DGSOR.AllowUserToAddRows = False
        Me.DGSOR.AllowUserToDeleteRows = False
        Me.DGSOR.AllowUserToResizeRows = False
        Me.DGSOR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGSOR.Location = New System.Drawing.Point(3, 31)
        Me.DGSOR.MultiSelect = False
        Me.DGSOR.Name = "DGSOR"
        Me.DGSOR.ReadOnly = True
        Me.DGSOR.ShowCellErrors = False
        Me.DGSOR.ShowEditingIcon = False
        Me.DGSOR.ShowRowErrors = False
        Me.DGSOR.Size = New System.Drawing.Size(513, 120)
        Me.DGSOR.TabIndex = 150
        '
        'btnxxFollow
        '
        Me.btnxxFollow.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxFollow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxFollow.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxFollow.Location = New System.Drawing.Point(3, 53)
        Me.btnxxFollow.Name = "btnxxFollow"
        Me.btnxxFollow.Size = New System.Drawing.Size(511, 72)
        Me.btnxxFollow.TabIndex = 157
        Me.btnxxFollow.Text = "Quoted Works /" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Follow Up Works"
        Me.btnxxFollow.UseVisualStyleBackColor = False
        Me.btnxxFollow.Visible = False
        '
        'txtSORQty
        '
        Me.txtSORQty.Location = New System.Drawing.Point(412, 5)
        Me.txtSORQty.Name = "txtSORQty"
        Me.txtSORQty.Size = New System.Drawing.Size(44, 21)
        Me.txtSORQty.TabIndex = 155
        Me.txtSORQty.Text = "1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label14.Location = New System.Drawing.Point(382, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 17)
        Me.Label14.TabIndex = 154
        Me.Label14.Text = "Qty"
        Me.Label14.Visible = False
        '
        'btnSORAdd
        '
        Me.btnSORAdd.Location = New System.Drawing.Point(488, 3)
        Me.btnSORAdd.Name = "btnSORAdd"
        Me.btnSORAdd.Size = New System.Drawing.Size(26, 23)
        Me.btnSORAdd.TabIndex = 151
        Me.btnSORAdd.Text = "+"
        Me.btnSORAdd.UseVisualStyleBackColor = True
        '
        'cboSOR
        '
        Me.cboSOR.BackColor = System.Drawing.SystemColors.Window
        Me.cboSOR.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cboSOR.FormattingEnabled = True
        Me.cboSOR.Location = New System.Drawing.Point(3, 4)
        Me.cboSOR.Name = "cboSOR"
        Me.cboSOR.Size = New System.Drawing.Size(373, 22)
        Me.cboSOR.TabIndex = 153
        '
        'btnSORMinus
        '
        Me.btnSORMinus.Location = New System.Drawing.Point(460, 3)
        Me.btnSORMinus.Name = "btnSORMinus"
        Me.btnSORMinus.Size = New System.Drawing.Size(25, 23)
        Me.btnSORMinus.TabIndex = 152
        Me.btnSORMinus.Text = "-"
        Me.btnSORMinus.UseVisualStyleBackColor = True
        '
        'btnxxSOR
        '
        Me.btnxxSOR.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxSOR.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxSOR.Location = New System.Drawing.Point(196, 379)
        Me.btnxxSOR.Name = "btnxxSOR"
        Me.btnxxSOR.Size = New System.Drawing.Size(513, 38)
        Me.btnxxSOR.TabIndex = 28
        Me.btnxxSOR.Tag = "67098"
        Me.btnxxSOR.Text = "SOR Based Works"
        Me.btnxxSOR.UseVisualStyleBackColor = False
        '
        'lbltype
        '
        Me.lbltype.AutoSize = True
        Me.lbltype.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.lbltype.Location = New System.Drawing.Point(206, 324)
        Me.lbltype.Name = "lbltype"
        Me.lbltype.Size = New System.Drawing.Size(70, 17)
        Me.lbltype.TabIndex = 9
        Me.lbltype.Text = "Job Type"
        Me.lbltype.Visible = False
        '
        'cbotypeWiz
        '
        Me.cbotypeWiz.BackColor = System.Drawing.SystemColors.Window
        Me.cbotypeWiz.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cbotypeWiz.FormattingEnabled = True
        Me.cbotypeWiz.Location = New System.Drawing.Point(282, 322)
        Me.cbotypeWiz.Name = "cbotypeWiz"
        Me.cbotypeWiz.Size = New System.Drawing.Size(326, 22)
        Me.cbotypeWiz.TabIndex = 8
        Me.cbotypeWiz.Visible = False
        '
        'btnxxBreakdown
        '
        Me.btnxxBreakdown.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxBreakdown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxBreakdown.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxBreakdown.Location = New System.Drawing.Point(196, 147)
        Me.btnxxBreakdown.Name = "btnxxBreakdown"
        Me.btnxxBreakdown.Size = New System.Drawing.Size(511, 72)
        Me.btnxxBreakdown.TabIndex = 4
        Me.btnxxBreakdown.Tag = "4703"
        Me.btnxxBreakdown.Text = "Breakdown"
        Me.btnxxBreakdown.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(390, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 25)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Job Type"
        '
        'BtnxxService
        '
        Me.BtnxxService.BackColor = System.Drawing.SystemColors.Control
        Me.BtnxxService.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnxxService.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnxxService.Location = New System.Drawing.Point(196, 63)
        Me.BtnxxService.Name = "BtnxxService"
        Me.BtnxxService.Size = New System.Drawing.Size(511, 72)
        Me.BtnxxService.TabIndex = 0
        Me.BtnxxService.Tag = "519"
        Me.BtnxxService.Text = "Service"
        Me.BtnxxService.UseVisualStyleBackColor = False
        '
        'btnxxOther
        '
        Me.btnxxOther.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxOther.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxOther.Location = New System.Drawing.Point(196, 314)
        Me.btnxxOther.Name = "btnxxOther"
        Me.btnxxOther.Size = New System.Drawing.Size(511, 38)
        Me.btnxxOther.TabIndex = 5
        Me.btnxxOther.Text = "Other"
        Me.btnxxOther.UseVisualStyleBackColor = False
        '
        'btnxxJobNext
        '
        Me.btnxxJobNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnxxJobNext.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxJobNext.BackgroundImage = CType(resources.GetObject("btnxxJobNext.BackgroundImage"), System.Drawing.Image)
        Me.btnxxJobNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxxJobNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxJobNext.Location = New System.Drawing.Point(812, 627)
        Me.btnxxJobNext.Name = "btnxxJobNext"
        Me.btnxxJobNext.Size = New System.Drawing.Size(62, 45)
        Me.btnxxJobNext.TabIndex = 27
        Me.btnxxJobNext.UseVisualStyleBackColor = False
        Me.btnxxJobNext.Visible = False
        '
        'tabProp
        '
        Me.tabProp.Controls.Add(Me.lblDefect)
        Me.tabProp.Controls.Add(Me.txtDefect)
        Me.tabProp.Controls.Add(Me.chbCommercial)
        Me.tabProp.Controls.Add(Me.lblContactAlert)
        Me.tabProp.Controls.Add(Me.txtContactAlert)
        Me.tabProp.Controls.Add(Me.txtSearchSite)
        Me.tabProp.Controls.Add(Me.txtName)
        Me.tabProp.Controls.Add(Me.txtSiteNotes)
        Me.tabProp.Controls.Add(Me.Label30)
        Me.tabProp.Controls.Add(Me.Label28)
        Me.tabProp.Controls.Add(Me.txtContractRef)
        Me.tabProp.Controls.Add(Me.btnJobHistory)
        Me.tabProp.Controls.Add(Me.btnxxSiteNext)
        Me.tabProp.Controls.Add(Me.Label10)
        Me.tabProp.Controls.Add(Me.txtCustomer)
        Me.tabProp.Controls.Add(Me.Label9)
        Me.tabProp.Controls.Add(Me.txtEmail)
        Me.tabProp.Controls.Add(Me.Label8)
        Me.tabProp.Controls.Add(Me.txtTel)
        Me.tabProp.Controls.Add(Me.Label6)
        Me.tabProp.Controls.Add(Me.txtMob)
        Me.tabProp.Controls.Add(Me.txtAddress3)
        Me.tabProp.Controls.Add(Me.Label7)
        Me.tabProp.Controls.Add(Me.Label5)
        Me.tabProp.Controls.Add(Me.Label4)
        Me.tabProp.Controls.Add(Me.Label3)
        Me.tabProp.Controls.Add(Me.Label2)
        Me.tabProp.Controls.Add(Me.cboTitle)
        Me.tabProp.Controls.Add(Me.txtAddress1)
        Me.tabProp.Controls.Add(Me.txtAddress2)
        Me.tabProp.Controls.Add(Me.txtPostcode)
        Me.tabProp.Controls.Add(Me.txtSurname)
        Me.tabProp.Controls.Add(Me.txtFirstName)
        Me.tabProp.Controls.Add(Me.btnEditSite)
        Me.tabProp.Controls.Add(Me.btnAddSite)
        Me.tabProp.Controls.Add(Me.Label1)
        Me.tabProp.Controls.Add(Me.txtSearch)
        Me.tabProp.Controls.Add(Me.DGVSites)
        Me.tabProp.Location = New System.Drawing.Point(4, 22)
        Me.tabProp.Name = "tabProp"
        Me.tabProp.Size = New System.Drawing.Size(877, 774)
        Me.tabProp.TabIndex = 0
        Me.tabProp.Text = "Property"
        '
        'lblDefect
        '
        Me.lblDefect.AutoSize = True
        Me.lblDefect.Location = New System.Drawing.Point(208, 583)
        Me.lblDefect.Name = "lblDefect"
        Me.lblDefect.Size = New System.Drawing.Size(109, 13)
        Me.lblDefect.TabIndex = 38
        Me.lblDefect.Text = "Defect Contractor"
        '
        'txtDefect
        '
        Me.txtDefect.Location = New System.Drawing.Point(318, 582)
        Me.txtDefect.Name = "txtDefect"
        Me.txtDefect.ReadOnly = True
        Me.txtDefect.Size = New System.Drawing.Size(300, 21)
        Me.txtDefect.TabIndex = 37
        '
        'chbCommercial
        '
        Me.chbCommercial.AutoSize = True
        Me.chbCommercial.Enabled = False
        Me.chbCommercial.Location = New System.Drawing.Point(476, 525)
        Me.chbCommercial.Name = "chbCommercial"
        Me.chbCommercial.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbCommercial.Size = New System.Drawing.Size(140, 17)
        Me.chbCommercial.TabIndex = 36
        Me.chbCommercial.Text = "Commercial/District"
        Me.chbCommercial.UseVisualStyleBackColor = True
        '
        'lblContactAlert
        '
        Me.lblContactAlert.AutoSize = True
        Me.lblContactAlert.Location = New System.Drawing.Point(208, 553)
        Me.lblContactAlert.Name = "lblContactAlert"
        Me.lblContactAlert.Size = New System.Drawing.Size(88, 13)
        Me.lblContactAlert.TabIndex = 35
        Me.lblContactAlert.Text = "Contact Alerts"
        '
        'txtContactAlert
        '
        Me.txtContactAlert.Location = New System.Drawing.Point(318, 552)
        Me.txtContactAlert.Name = "txtContactAlert"
        Me.txtContactAlert.ReadOnly = True
        Me.txtContactAlert.Size = New System.Drawing.Size(300, 21)
        Me.txtContactAlert.TabIndex = 34
        '
        'txtSearchSite
        '
        Me.txtSearchSite.Location = New System.Drawing.Point(610, 56)
        Me.txtSearchSite.Name = "txtSearchSite"
        Me.txtSearchSite.Size = New System.Drawing.Size(69, 21)
        Me.txtSearchSite.TabIndex = 33
        Me.txtSearchSite.Text = "Search"
        Me.txtSearchSite.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(448, 279)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(171, 21)
        Me.txtName.TabIndex = 32
        '
        'txtSiteNotes
        '
        Me.txtSiteNotes.Location = New System.Drawing.Point(318, 611)
        Me.txtSiteNotes.Multiline = True
        Me.txtSiteNotes.Name = "txtSiteNotes"
        Me.txtSiteNotes.ReadOnly = True
        Me.txtSiteNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSiteNotes.Size = New System.Drawing.Size(301, 55)
        Me.txtSiteNotes.TabIndex = 31
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(208, 616)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(65, 13)
        Me.Label30.TabIndex = 30
        Me.Label30.Text = "Site Notes"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(208, 525)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(79, 13)
        Me.Label28.TabIndex = 29
        Me.Label28.Text = "Contract Ref"
        '
        'txtContractRef
        '
        Me.txtContractRef.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtContractRef.Location = New System.Drawing.Point(318, 522)
        Me.txtContractRef.Name = "txtContractRef"
        Me.txtContractRef.ReadOnly = True
        Me.txtContractRef.Size = New System.Drawing.Size(121, 21)
        Me.txtContractRef.TabIndex = 28
        '
        'btnJobHistory
        '
        Me.btnJobHistory.Location = New System.Drawing.Point(318, 672)
        Me.btnJobHistory.Name = "btnJobHistory"
        Me.btnJobHistory.Size = New System.Drawing.Size(144, 51)
        Me.btnJobHistory.TabIndex = 27
        Me.btnJobHistory.Text = "Job History"
        Me.btnJobHistory.UseVisualStyleBackColor = True
        '
        'btnxxSiteNext
        '
        Me.btnxxSiteNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnxxSiteNext.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxSiteNext.BackgroundImage = CType(resources.GetObject("btnxxSiteNext.BackgroundImage"), System.Drawing.Image)
        Me.btnxxSiteNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxxSiteNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxSiteNext.Location = New System.Drawing.Point(812, 681)
        Me.btnxxSiteNext.Name = "btnxxSiteNext"
        Me.btnxxSiteNext.Size = New System.Drawing.Size(62, 45)
        Me.btnxxSiteNext.TabIndex = 26
        Me.btnxxSiteNext.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(208, 255)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Customer"
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(318, 252)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(301, 21)
        Me.txtCustomer.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(208, 498)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(318, 495)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(301, 21)
        Me.txtEmail.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(208, 471)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Tel No."
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(318, 468)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.ReadOnly = True
        Me.txtTel.Size = New System.Drawing.Size(121, 21)
        Me.txtTel.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(445, 471)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Mob No."
        '
        'txtMob
        '
        Me.txtMob.Location = New System.Drawing.Point(498, 468)
        Me.txtMob.Name = "txtMob"
        Me.txtMob.ReadOnly = True
        Me.txtMob.Size = New System.Drawing.Size(121, 21)
        Me.txtMob.TabIndex = 18
        '
        'txtAddress3
        '
        Me.txtAddress3.Location = New System.Drawing.Point(318, 414)
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.ReadOnly = True
        Me.txtAddress3.Size = New System.Drawing.Size(301, 21)
        Me.txtAddress3.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(208, 444)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Postcode"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(208, 363)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Address "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(208, 336)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Surname"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(208, 309)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "First Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(208, 282)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Title"
        '
        'cboTitle
        '
        Me.cboTitle.Enabled = False
        Me.cboTitle.FormattingEnabled = True
        Me.cboTitle.Location = New System.Drawing.Point(318, 279)
        Me.cboTitle.Name = "cboTitle"
        Me.cboTitle.Size = New System.Drawing.Size(121, 21)
        Me.cboTitle.TabIndex = 10
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(318, 360)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.ReadOnly = True
        Me.txtAddress1.Size = New System.Drawing.Size(301, 21)
        Me.txtAddress1.TabIndex = 9
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(318, 387)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.ReadOnly = True
        Me.txtAddress2.Size = New System.Drawing.Size(301, 21)
        Me.txtAddress2.TabIndex = 8
        '
        'txtPostcode
        '
        Me.txtPostcode.Location = New System.Drawing.Point(318, 441)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.ReadOnly = True
        Me.txtPostcode.Size = New System.Drawing.Size(301, 21)
        Me.txtPostcode.TabIndex = 7
        '
        'txtSurname
        '
        Me.txtSurname.Location = New System.Drawing.Point(318, 333)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.ReadOnly = True
        Me.txtSurname.Size = New System.Drawing.Size(301, 21)
        Me.txtSurname.TabIndex = 6
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(318, 306)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(301, 21)
        Me.txtFirstName.TabIndex = 5
        '
        'btnEditSite
        '
        Me.btnEditSite.Location = New System.Drawing.Point(468, 672)
        Me.btnEditSite.Name = "btnEditSite"
        Me.btnEditSite.Size = New System.Drawing.Size(151, 51)
        Me.btnEditSite.TabIndex = 4
        Me.btnEditSite.Text = "Ammend Other " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fields / View Other Notes"
        Me.btnEditSite.UseVisualStyleBackColor = True
        '
        'btnAddSite
        '
        Me.btnAddSite.Location = New System.Drawing.Point(788, 54)
        Me.btnAddSite.Name = "btnAddSite"
        Me.btnAddSite.Size = New System.Drawing.Size(75, 23)
        Me.btnAddSite.TabIndex = 3
        Me.btnAddSite.Text = "Add Site"
        Me.btnAddSite.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(383, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Search Site"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(303, 56)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(301, 21)
        Me.txtSearch.TabIndex = 1
        '
        'DGVSites
        '
        Me.DGVSites.AllowUserToAddRows = False
        Me.DGVSites.AllowUserToDeleteRows = False
        Me.DGVSites.AllowUserToOrderColumns = True
        Me.DGVSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSites.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGVSites.Location = New System.Drawing.Point(14, 88)
        Me.DGVSites.MultiSelect = False
        Me.DGVSites.Name = "DGVSites"
        Me.DGVSites.ReadOnly = True
        Me.DGVSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVSites.Size = New System.Drawing.Size(849, 150)
        Me.DGVSites.TabIndex = 0
        '
        'tcSites
        '
        Me.tcSites.Controls.Add(Me.tabProp)
        Me.tcSites.Controls.Add(Me.tabExistingJobs)
        Me.tcSites.Controls.Add(Me.tabJobType)
        Me.tcSites.Controls.Add(Me.tabJobDetails)
        Me.tcSites.Controls.Add(Me.tabAppliance)
        Me.tcSites.Controls.Add(Me.tabAdditional)
        Me.tcSites.Controls.Add(Me.TabCharging)
        Me.tcSites.Controls.Add(Me.TabBook)
        Me.tcSites.Controls.Add(Me.tcComplete)
        Me.tcSites.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcSites.Location = New System.Drawing.Point(0, 0)
        Me.tcSites.Name = "tcSites"
        Me.tcSites.SelectedIndex = 0
        Me.tcSites.Size = New System.Drawing.Size(885, 800)
        Me.tcSites.TabIndex = 0
        '
        'tabExistingJobs
        '
        Me.tabExistingJobs.BackColor = System.Drawing.SystemColors.Control
        Me.tabExistingJobs.Controls.Add(Me.btnxxExistingJobBack)
        Me.tabExistingJobs.Controls.Add(Me.btnxxExistingJobNext)
        Me.tabExistingJobs.Controls.Add(Me.dgExistingVisits)
        Me.tabExistingJobs.Controls.Add(Me.Label29)
        Me.tabExistingJobs.Controls.Add(Me.btnxxNewJob)
        Me.tabExistingJobs.Location = New System.Drawing.Point(4, 22)
        Me.tabExistingJobs.Name = "tabExistingJobs"
        Me.tabExistingJobs.Size = New System.Drawing.Size(877, 774)
        Me.tabExistingJobs.TabIndex = 13
        Me.tabExistingJobs.Text = "ExistingJobs"
        '
        'btnxxExistingJobBack
        '
        Me.btnxxExistingJobBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnxxExistingJobBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxExistingJobBack.BackgroundImage = CType(resources.GetObject("btnxxExistingJobBack.BackgroundImage"), System.Drawing.Image)
        Me.btnxxExistingJobBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxxExistingJobBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxExistingJobBack.Location = New System.Drawing.Point(3, 627)
        Me.btnxxExistingJobBack.Name = "btnxxExistingJobBack"
        Me.btnxxExistingJobBack.Size = New System.Drawing.Size(62, 45)
        Me.btnxxExistingJobBack.TabIndex = 179
        Me.btnxxExistingJobBack.UseVisualStyleBackColor = False
        '
        'btnxxExistingJobNext
        '
        Me.btnxxExistingJobNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnxxExistingJobNext.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxExistingJobNext.BackgroundImage = CType(resources.GetObject("btnxxExistingJobNext.BackgroundImage"), System.Drawing.Image)
        Me.btnxxExistingJobNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxxExistingJobNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxExistingJobNext.Location = New System.Drawing.Point(812, 627)
        Me.btnxxExistingJobNext.Name = "btnxxExistingJobNext"
        Me.btnxxExistingJobNext.Size = New System.Drawing.Size(62, 45)
        Me.btnxxExistingJobNext.TabIndex = 178
        Me.btnxxExistingJobNext.UseVisualStyleBackColor = False
        '
        'dgExistingVisits
        '
        Me.dgExistingVisits.AllowUserToAddRows = False
        Me.dgExistingVisits.AllowUserToDeleteRows = False
        Me.dgExistingVisits.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgExistingVisits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgExistingVisits.ColumnHeadersVisible = False
        Me.dgExistingVisits.Location = New System.Drawing.Point(40, 103)
        Me.dgExistingVisits.MultiSelect = False
        Me.dgExistingVisits.Name = "dgExistingVisits"
        Me.dgExistingVisits.ReadOnly = True
        Me.dgExistingVisits.RowHeadersVisible = False
        Me.dgExistingVisits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgExistingVisits.ShowCellErrors = False
        Me.dgExistingVisits.ShowEditingIcon = False
        Me.dgExistingVisits.ShowRowErrors = False
        Me.dgExistingVisits.Size = New System.Drawing.Size(805, 164)
        Me.dgExistingVisits.TabIndex = 177
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(314, 35)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(249, 25)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "New Or Existing Job"
        '
        'btnxxNewJob
        '
        Me.btnxxNewJob.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxNewJob.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxNewJob.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnxxNewJob.Location = New System.Drawing.Point(173, 319)
        Me.btnxxNewJob.Name = "btnxxNewJob"
        Me.btnxxNewJob.Size = New System.Drawing.Size(511, 72)
        Me.btnxxNewJob.TabIndex = 4
        Me.btnxxNewJob.Text = "New Job"
        Me.btnxxNewJob.UseVisualStyleBackColor = False
        '
        'tabAdditional
        '
        Me.tabAdditional.Controls.Add(Me.chkCert)
        Me.tabAdditional.Controls.Add(Me.lblcert)
        Me.tabAdditional.Controls.Add(Me.btnxx4)
        Me.tabAdditional.Controls.Add(Me.lblCoverplanServ)
        Me.tabAdditional.Controls.Add(Me.Label22)
        Me.tabAdditional.Controls.Add(Me.Label21)
        Me.tabAdditional.Controls.Add(Me.cboAdditional)
        Me.tabAdditional.Controls.Add(Me.DGAdditional)
        Me.tabAdditional.Controls.Add(Me.btnAdditionalMinus)
        Me.tabAdditional.Controls.Add(Me.btnAdditionalPlus)
        Me.tabAdditional.Controls.Add(Me.btnxxAdditionalNext)
        Me.tabAdditional.Location = New System.Drawing.Point(4, 22)
        Me.tabAdditional.Name = "tabAdditional"
        Me.tabAdditional.Size = New System.Drawing.Size(877, 774)
        Me.tabAdditional.TabIndex = 10
        Me.tabAdditional.Text = "Additional Items"
        Me.tabAdditional.UseVisualStyleBackColor = True
        '
        'chkCert
        '
        Me.chkCert.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkCert.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCert.Location = New System.Drawing.Point(561, 431)
        Me.chkCert.Name = "chkCert"
        Me.chkCert.Size = New System.Drawing.Size(40, 40)
        Me.chkCert.TabIndex = 184
        Me.chkCert.UseVisualStyleBackColor = True
        '
        'lblcert
        '
        Me.lblcert.AutoSize = True
        Me.lblcert.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.lblcert.ForeColor = System.Drawing.Color.Maroon
        Me.lblcert.Location = New System.Drawing.Point(311, 442)
        Me.lblcert.Name = "lblcert"
        Me.lblcert.Size = New System.Drawing.Size(145, 17)
        Me.lblcert.TabIndex = 183
        Me.lblcert.Text = "L/L Cert Required? "
        Me.lblcert.Visible = False
        '
        'btnxx4
        '
        Me.btnxx4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnxx4.BackColor = System.Drawing.SystemColors.Control
        Me.btnxx4.BackgroundImage = CType(resources.GetObject("btnxx4.BackgroundImage"), System.Drawing.Image)
        Me.btnxx4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxx4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxx4.Location = New System.Drawing.Point(3, 627)
        Me.btnxx4.Name = "btnxx4"
        Me.btnxx4.Size = New System.Drawing.Size(62, 45)
        Me.btnxx4.TabIndex = 182
        Me.btnxx4.UseVisualStyleBackColor = False
        '
        'lblCoverplanServ
        '
        Me.lblCoverplanServ.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCoverplanServ.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblCoverplanServ.ForeColor = System.Drawing.Color.Red
        Me.lblCoverplanServ.Location = New System.Drawing.Point(145, 80)
        Me.lblCoverplanServ.Name = "lblCoverplanServ"
        Me.lblCoverplanServ.Size = New System.Drawing.Size(594, 106)
        Me.lblCoverplanServ.TabIndex = 181
        Me.lblCoverplanServ.Text = "This Site Has A Coverplan Service Outstanding"
        Me.lblCoverplanServ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCoverplanServ.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(349, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(208, 25)
        Me.Label22.TabIndex = 179
        Me.Label22.Text = "Additional Items"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label21.Location = New System.Drawing.Point(138, 240)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(114, 17)
        Me.Label21.TabIndex = 178
        Me.Label21.Text = "Additional Item"
        '
        'cboAdditional
        '
        Me.cboAdditional.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cboAdditional.FormattingEnabled = True
        Me.cboAdditional.Location = New System.Drawing.Point(314, 238)
        Me.cboAdditional.Name = "cboAdditional"
        Me.cboAdditional.Size = New System.Drawing.Size(285, 22)
        Me.cboAdditional.TabIndex = 177
        '
        'DGAdditional
        '
        Me.DGAdditional.AllowUserToAddRows = False
        Me.DGAdditional.AllowUserToDeleteRows = False
        Me.DGAdditional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGAdditional.ColumnHeadersVisible = False
        Me.DGAdditional.Location = New System.Drawing.Point(141, 294)
        Me.DGAdditional.MultiSelect = False
        Me.DGAdditional.Name = "DGAdditional"
        Me.DGAdditional.ReadOnly = True
        Me.DGAdditional.RowHeadersVisible = False
        Me.DGAdditional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGAdditional.ShowCellErrors = False
        Me.DGAdditional.ShowEditingIcon = False
        Me.DGAdditional.ShowRowErrors = False
        Me.DGAdditional.Size = New System.Drawing.Size(598, 113)
        Me.DGAdditional.TabIndex = 176
        '
        'btnAdditionalMinus
        '
        Me.btnAdditionalMinus.Location = New System.Drawing.Point(406, 266)
        Me.btnAdditionalMinus.Name = "btnAdditionalMinus"
        Me.btnAdditionalMinus.Size = New System.Drawing.Size(39, 23)
        Me.btnAdditionalMinus.TabIndex = 175
        Me.btnAdditionalMinus.Text = "-"
        Me.btnAdditionalMinus.UseVisualStyleBackColor = True
        '
        'btnAdditionalPlus
        '
        Me.btnAdditionalPlus.Location = New System.Drawing.Point(451, 266)
        Me.btnAdditionalPlus.Name = "btnAdditionalPlus"
        Me.btnAdditionalPlus.Size = New System.Drawing.Size(39, 23)
        Me.btnAdditionalPlus.TabIndex = 174
        Me.btnAdditionalPlus.Text = "+"
        Me.btnAdditionalPlus.UseVisualStyleBackColor = True
        '
        'btnxxAdditionalNext
        '
        Me.btnxxAdditionalNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnxxAdditionalNext.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxAdditionalNext.BackgroundImage = CType(resources.GetObject("btnxxAdditionalNext.BackgroundImage"), System.Drawing.Image)
        Me.btnxxAdditionalNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxxAdditionalNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxAdditionalNext.Location = New System.Drawing.Point(812, 627)
        Me.btnxxAdditionalNext.Name = "btnxxAdditionalNext"
        Me.btnxxAdditionalNext.Size = New System.Drawing.Size(62, 45)
        Me.btnxxAdditionalNext.TabIndex = 180
        Me.btnxxAdditionalNext.UseVisualStyleBackColor = False
        Me.btnxxAdditionalNext.Visible = False
        '
        'TabCharging
        '
        Me.TabCharging.Controls.Add(Me.lblUnabletoConfirm)
        Me.TabCharging.Controls.Add(Me.btnxx5)
        Me.TabCharging.Controls.Add(Me.Label16)
        Me.TabCharging.Controls.Add(Me.cboPayTerms)
        Me.TabCharging.Controls.Add(Me.chkRecall)
        Me.TabCharging.Controls.Add(Me.Label19)
        Me.TabCharging.Controls.Add(Me.Label18)
        Me.TabCharging.Controls.Add(Me.pnlCharge)
        Me.TabCharging.Controls.Add(Me.txtPayInst)
        Me.TabCharging.Controls.Add(Me.btnxxChargeNext)
        Me.TabCharging.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabCharging.Location = New System.Drawing.Point(4, 22)
        Me.TabCharging.Name = "TabCharging"
        Me.TabCharging.Size = New System.Drawing.Size(877, 774)
        Me.TabCharging.TabIndex = 9
        Me.TabCharging.Text = "Charging"
        Me.TabCharging.UseVisualStyleBackColor = True
        '
        'lblUnabletoConfirm
        '
        Me.lblUnabletoConfirm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnabletoConfirm.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnabletoConfirm.ForeColor = System.Drawing.Color.Red
        Me.lblUnabletoConfirm.Location = New System.Drawing.Point(141, 269)
        Me.lblUnabletoConfirm.Name = "lblUnabletoConfirm"
        Me.lblUnabletoConfirm.Size = New System.Drawing.Size(594, 106)
        Me.lblUnabletoConfirm.TabIndex = 182
        Me.lblUnabletoConfirm.Text = "Unable to confirm if any payment is due please check notes"
        Me.lblUnabletoConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblUnabletoConfirm.Visible = False
        '
        'btnxx5
        '
        Me.btnxx5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnxx5.BackColor = System.Drawing.SystemColors.Control
        Me.btnxx5.BackgroundImage = CType(resources.GetObject("btnxx5.BackgroundImage"), System.Drawing.Image)
        Me.btnxx5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxx5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxx5.Location = New System.Drawing.Point(3, 627)
        Me.btnxx5.Name = "btnxx5"
        Me.btnxx5.Size = New System.Drawing.Size(62, 45)
        Me.btnxx5.TabIndex = 176
        Me.btnxx5.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label16.Location = New System.Drawing.Point(142, 561)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 17)
        Me.Label16.TabIndex = 175
        Me.Label16.Text = "Payment Terms"
        '
        'cboPayTerms
        '
        Me.cboPayTerms.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cboPayTerms.FormattingEnabled = True
        Me.cboPayTerms.Location = New System.Drawing.Point(318, 561)
        Me.cboPayTerms.Name = "cboPayTerms"
        Me.cboPayTerms.Size = New System.Drawing.Size(285, 22)
        Me.cboPayTerms.TabIndex = 174
        '
        'chkRecall
        '
        Me.chkRecall.AutoSize = True
        Me.chkRecall.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecall.ForeColor = System.Drawing.Color.Red
        Me.chkRecall.Location = New System.Drawing.Point(445, 239)
        Me.chkRecall.Name = "chkRecall"
        Me.chkRecall.Size = New System.Drawing.Size(15, 14)
        Me.chkRecall.TabIndex = 168
        Me.chkRecall.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label19.Location = New System.Drawing.Point(142, 237)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 17)
        Me.Label19.TabIndex = 167
        Me.Label19.Text = "Recall"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(389, 28)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(118, 25)
        Me.Label18.TabIndex = 166
        Me.Label18.Text = "Charging"
        '
        'pnlCharge
        '
        Me.pnlCharge.Controls.Add(Me.picTick)
        Me.pnlCharge.Controls.Add(Me.Label35)
        Me.pnlCharge.Controls.Add(Me.txtDiscountCode)
        Me.pnlCharge.Controls.Add(Me.Label17)
        Me.pnlCharge.Controls.Add(Me.txtCharge)
        Me.pnlCharge.Controls.Add(Me.picCross)
        Me.pnlCharge.Location = New System.Drawing.Point(132, 458)
        Me.pnlCharge.Name = "pnlCharge"
        Me.pnlCharge.Size = New System.Drawing.Size(611, 78)
        Me.pnlCharge.TabIndex = 165
        '
        'picTick
        '
        Me.picTick.BackColor = System.Drawing.Color.White
        Me.picTick.BackgroundImage = Global.FSM.My.Resources.Resources.tick
        Me.picTick.Cursor = System.Windows.Forms.Cursors.No
        Me.picTick.Image = Global.FSM.My.Resources.Resources.tick
        Me.picTick.InitialImage = Global.FSM.My.Resources.Resources.tick
        Me.picTick.Location = New System.Drawing.Point(407, 6)
        Me.picTick.Name = "picTick"
        Me.picTick.Size = New System.Drawing.Size(33, 27)
        Me.picTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTick.TabIndex = 183
        Me.picTick.TabStop = False
        Me.picTick.Visible = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label35.Location = New System.Drawing.Point(10, 11)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(132, 17)
        Me.Label35.TabIndex = 168
        Me.Label35.Text = "Promotional Code"
        '
        'txtDiscountCode
        '
        Me.txtDiscountCode.Location = New System.Drawing.Point(255, 6)
        Me.txtDiscountCode.Name = "txtDiscountCode"
        Me.txtDiscountCode.Size = New System.Drawing.Size(123, 27)
        Me.txtDiscountCode.TabIndex = 167
        Me.txtDiscountCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label17.Location = New System.Drawing.Point(10, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(232, 17)
        Me.Label17.TabIndex = 166
        Me.Label17.Text = "Payment On Completion Charge"
        '
        'txtCharge
        '
        Me.txtCharge.Location = New System.Drawing.Point(255, 39)
        Me.txtCharge.Name = "txtCharge"
        Me.txtCharge.Size = New System.Drawing.Size(123, 27)
        Me.txtCharge.TabIndex = 165
        Me.txtCharge.Text = "0"
        Me.txtCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'picCross
        '
        Me.picCross.BackColor = System.Drawing.Color.White
        Me.picCross.BackgroundImage = Global.FSM.My.Resources.Resources.cross
        Me.picCross.Cursor = System.Windows.Forms.Cursors.No
        Me.picCross.Image = Global.FSM.My.Resources.Resources.cross
        Me.picCross.InitialImage = Global.FSM.My.Resources.Resources.cross
        Me.picCross.Location = New System.Drawing.Point(407, 6)
        Me.picCross.Name = "picCross"
        Me.picCross.Size = New System.Drawing.Size(33, 27)
        Me.picCross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCross.TabIndex = 184
        Me.picCross.TabStop = False
        Me.picCross.Visible = False
        '
        'txtPayInst
        '
        Me.txtPayInst.Location = New System.Drawing.Point(145, 75)
        Me.txtPayInst.Multiline = True
        Me.txtPayInst.Name = "txtPayInst"
        Me.txtPayInst.ReadOnly = True
        Me.txtPayInst.Size = New System.Drawing.Size(598, 141)
        Me.txtPayInst.TabIndex = 0
        Me.txtPayInst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnxxChargeNext
        '
        Me.btnxxChargeNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnxxChargeNext.BackColor = System.Drawing.SystemColors.Control
        Me.btnxxChargeNext.BackgroundImage = CType(resources.GetObject("btnxxChargeNext.BackgroundImage"), System.Drawing.Image)
        Me.btnxxChargeNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxxChargeNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxxChargeNext.Location = New System.Drawing.Point(812, 627)
        Me.btnxxChargeNext.Name = "btnxxChargeNext"
        Me.btnxxChargeNext.Size = New System.Drawing.Size(62, 45)
        Me.btnxxChargeNext.TabIndex = 162
        Me.btnxxChargeNext.UseVisualStyleBackColor = False
        Me.btnxxChargeNext.Visible = False
        '
        'TabBook
        '
        Me.TabBook.Controls.Add(Me.btnOption8)
        Me.TabBook.Controls.Add(Me.btnOption7)
        Me.TabBook.Controls.Add(Me.btnOption6)
        Me.TabBook.Controls.Add(Me.btnOption5)
        Me.TabBook.Controls.Add(Me.btnRefresh)
        Me.TabBook.Controls.Add(Me.Label31)
        Me.TabBook.Controls.Add(Me.Label24)
        Me.TabBook.Controls.Add(Me.cboEngineer)
        Me.TabBook.Controls.Add(Me.btnxx6)
        Me.TabBook.Controls.Add(Me.gpCombo)
        Me.TabBook.Controls.Add(Me.lblBookText)
        Me.TabBook.Controls.Add(Me.Label23)
        Me.TabBook.Controls.Add(Me.dtpFromDate)
        Me.TabBook.Controls.Add(Me.btnOption10)
        Me.TabBook.Controls.Add(Me.btnOption4)
        Me.TabBook.Controls.Add(Me.btnOption3)
        Me.TabBook.Controls.Add(Me.btnOption2)
        Me.TabBook.Controls.Add(Me.btnOption1)
        Me.TabBook.Controls.Add(Me.chkKeepTogether)
        Me.TabBook.Location = New System.Drawing.Point(4, 22)
        Me.TabBook.Name = "TabBook"
        Me.TabBook.Size = New System.Drawing.Size(877, 774)
        Me.TabBook.TabIndex = 11
        Me.TabBook.Text = "Book Visit"
        Me.TabBook.UseVisualStyleBackColor = True
        '
        'btnOption8
        '
        Me.btnOption8.BackColor = System.Drawing.Color.PaleGreen
        Me.btnOption8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOption8.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.btnOption8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption8.Location = New System.Drawing.Point(441, 422)
        Me.btnOption8.Name = "btnOption8"
        Me.btnOption8.Size = New System.Drawing.Size(404, 72)
        Me.btnOption8.TabIndex = 187
        Me.btnOption8.Text = "Searching....."
        Me.btnOption8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption8.UseVisualStyleBackColor = False
        '
        'btnOption7
        '
        Me.btnOption7.BackColor = System.Drawing.Color.PaleGreen
        Me.btnOption7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOption7.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.btnOption7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption7.Location = New System.Drawing.Point(33, 422)
        Me.btnOption7.Name = "btnOption7"
        Me.btnOption7.Size = New System.Drawing.Size(404, 72)
        Me.btnOption7.TabIndex = 186
        Me.btnOption7.Text = "Searching....."
        Me.btnOption7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption7.UseVisualStyleBackColor = False
        '
        'btnOption6
        '
        Me.btnOption6.BackColor = System.Drawing.Color.PaleGreen
        Me.btnOption6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOption6.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.btnOption6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption6.Location = New System.Drawing.Point(441, 344)
        Me.btnOption6.Name = "btnOption6"
        Me.btnOption6.Size = New System.Drawing.Size(404, 72)
        Me.btnOption6.TabIndex = 185
        Me.btnOption6.Text = "Searching....."
        Me.btnOption6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption6.UseVisualStyleBackColor = False
        '
        'btnOption5
        '
        Me.btnOption5.BackColor = System.Drawing.Color.PaleGreen
        Me.btnOption5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOption5.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.btnOption5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption5.Location = New System.Drawing.Point(33, 344)
        Me.btnOption5.Name = "btnOption5"
        Me.btnOption5.Size = New System.Drawing.Size(404, 72)
        Me.btnOption5.TabIndex = 184
        Me.btnOption5.Text = "Searching....."
        Me.btnOption5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption5.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(754, 137)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 183
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(167, 575)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(539, 13)
        Me.Label31.TabIndex = 182
        Me.Label31.Text = "Green = Best Selection(s)   , Orange = Not as efficient option ,  Red = Only use " &
    "if authorised"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label24.Location = New System.Drawing.Point(42, 140)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(126, 17)
        Me.Label24.TabIndex = 181
        Me.Label24.Text = "Specific Engineer"
        '
        'cboEngineer
        '
        Me.cboEngineer.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cboEngineer.FormattingEnabled = True
        Me.cboEngineer.Location = New System.Drawing.Point(215, 138)
        Me.cboEngineer.Name = "cboEngineer"
        Me.cboEngineer.Size = New System.Drawing.Size(176, 22)
        Me.cboEngineer.TabIndex = 180
        '
        'btnxx6
        '
        Me.btnxx6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnxx6.BackColor = System.Drawing.SystemColors.Control
        Me.btnxx6.BackgroundImage = CType(resources.GetObject("btnxx6.BackgroundImage"), System.Drawing.Image)
        Me.btnxx6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnxx6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnxx6.Location = New System.Drawing.Point(3, 627)
        Me.btnxx6.Name = "btnxx6"
        Me.btnxx6.Size = New System.Drawing.Size(62, 45)
        Me.btnxx6.TabIndex = 179
        Me.btnxx6.UseVisualStyleBackColor = False
        '
        'gpCombo
        '
        Me.gpCombo.Controls.Add(Me.cboAppointment)
        Me.gpCombo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.gpCombo.Location = New System.Drawing.Point(401, 86)
        Me.gpCombo.Name = "gpCombo"
        Me.gpCombo.Size = New System.Drawing.Size(434, 51)
        Me.gpCombo.TabIndex = 178
        Me.gpCombo.TabStop = False
        Me.gpCombo.Text = "Appointment Type"
        '
        'cboAppointment
        '
        Me.cboAppointment.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cboAppointment.FormattingEnabled = True
        Me.cboAppointment.Location = New System.Drawing.Point(6, 16)
        Me.cboAppointment.Name = "cboAppointment"
        Me.cboAppointment.Size = New System.Drawing.Size(422, 22)
        Me.cboAppointment.TabIndex = 175
        '
        'lblBookText
        '
        Me.lblBookText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBookText.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookText.Location = New System.Drawing.Point(3, 49)
        Me.lblBookText.Name = "lblBookText"
        Me.lblBookText.Size = New System.Drawing.Size(871, 34)
        Me.lblBookText.TabIndex = 177
        Me.lblBookText.Text = "Booking Visits"
        Me.lblBookText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Label23.Location = New System.Drawing.Point(42, 104)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(106, 17)
        Me.Label23.TabIndex = 176
        Me.Label23.Text = "Booking From"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.Location = New System.Drawing.Point(215, 102)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(176, 21)
        Me.dtpFromDate.TabIndex = 175
        '
        'btnOption10
        '
        Me.btnOption10.BackColor = System.Drawing.Color.PaleGreen
        Me.btnOption10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOption10.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.btnOption10.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption10.Location = New System.Drawing.Point(33, 500)
        Me.btnOption10.Name = "btnOption10"
        Me.btnOption10.Size = New System.Drawing.Size(812, 72)
        Me.btnOption10.TabIndex = 174
        Me.btnOption10.Text = "Searching....."
        Me.btnOption10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption10.UseVisualStyleBackColor = False
        '
        'btnOption4
        '
        Me.btnOption4.BackColor = System.Drawing.Color.PaleGreen
        Me.btnOption4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOption4.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.btnOption4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption4.Location = New System.Drawing.Point(441, 266)
        Me.btnOption4.Name = "btnOption4"
        Me.btnOption4.Size = New System.Drawing.Size(404, 72)
        Me.btnOption4.TabIndex = 173
        Me.btnOption4.Text = "Searching....."
        Me.btnOption4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption4.UseVisualStyleBackColor = False
        '
        'btnOption3
        '
        Me.btnOption3.BackColor = System.Drawing.Color.PaleGreen
        Me.btnOption3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOption3.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.btnOption3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption3.Location = New System.Drawing.Point(33, 266)
        Me.btnOption3.Name = "btnOption3"
        Me.btnOption3.Size = New System.Drawing.Size(404, 72)
        Me.btnOption3.TabIndex = 172
        Me.btnOption3.Text = "Searching....."
        Me.btnOption3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption3.UseVisualStyleBackColor = False
        '
        'btnOption2
        '
        Me.btnOption2.BackColor = System.Drawing.Color.PaleGreen
        Me.btnOption2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOption2.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.btnOption2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption2.Location = New System.Drawing.Point(441, 188)
        Me.btnOption2.Name = "btnOption2"
        Me.btnOption2.Size = New System.Drawing.Size(404, 72)
        Me.btnOption2.TabIndex = 171
        Me.btnOption2.Text = "Searching....."
        Me.btnOption2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption2.UseVisualStyleBackColor = False
        '
        'btnOption1
        '
        Me.btnOption1.BackColor = System.Drawing.Color.PaleGreen
        Me.btnOption1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOption1.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.btnOption1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption1.Location = New System.Drawing.Point(31, 188)
        Me.btnOption1.Name = "btnOption1"
        Me.btnOption1.Size = New System.Drawing.Size(406, 72)
        Me.btnOption1.TabIndex = 170
        Me.btnOption1.Text = "Searching....."
        Me.btnOption1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOption1.UseVisualStyleBackColor = False
        '
        'chkKeepTogether
        '
        Me.chkKeepTogether.AutoSize = True
        Me.chkKeepTogether.Checked = True
        Me.chkKeepTogether.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKeepTogether.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKeepTogether.ForeColor = System.Drawing.Color.Black
        Me.chkKeepTogether.Location = New System.Drawing.Point(356, 17)
        Me.chkKeepTogether.Name = "chkKeepTogether"
        Me.chkKeepTogether.Size = New System.Drawing.Size(196, 22)
        Me.chkKeepTogether.TabIndex = 169
        Me.chkKeepTogether.Text = "Keep Visits Together"
        Me.chkKeepTogether.UseVisualStyleBackColor = True
        '
        'tcComplete
        '
        Me.tcComplete.Controls.Add(Me.btnDocument)
        Me.tcComplete.Controls.Add(Me.lblBookedInfo)
        Me.tcComplete.Controls.Add(Me.Label27)
        Me.tcComplete.Controls.Add(Me.btnRestart)
        Me.tcComplete.Location = New System.Drawing.Point(4, 22)
        Me.tcComplete.Name = "tcComplete"
        Me.tcComplete.Size = New System.Drawing.Size(877, 774)
        Me.tcComplete.TabIndex = 12
        Me.tcComplete.Text = "Complete"
        Me.tcComplete.UseVisualStyleBackColor = True
        '
        'btnDocument
        '
        Me.btnDocument.Location = New System.Drawing.Point(84, 311)
        Me.btnDocument.Name = "btnDocument"
        Me.btnDocument.Size = New System.Drawing.Size(708, 23)
        Me.btnDocument.TabIndex = 180
        Me.btnDocument.Text = "Add Documentation"
        Me.btnDocument.UseVisualStyleBackColor = True
        '
        'lblBookedInfo
        '
        Me.lblBookedInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBookedInfo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBookedInfo.Location = New System.Drawing.Point(8, 236)
        Me.lblBookedInfo.Name = "lblBookedInfo"
        Me.lblBookedInfo.Size = New System.Drawing.Size(856, 32)
        Me.lblBookedInfo.TabIndex = 179
        Me.lblBookedInfo.Text = "Booked with"
        Me.lblBookedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(3, 185)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(871, 34)
        Me.Label27.TabIndex = 178
        Me.Label27.Text = "Bookings Complete"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRestart
        '
        Me.btnRestart.BackColor = System.Drawing.Color.PaleGreen
        Me.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRestart.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestart.Location = New System.Drawing.Point(84, 334)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(708, 72)
        Me.btnRestart.TabIndex = 171
        Me.btnRestart.Text = "Restart"
        Me.btnRestart.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 20
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 10
        '
        'UCJobWizard
        '
        Me.Controls.Add(Me.tcSites)
        Me.Name = "UCJobWizard"
        Me.Size = New System.Drawing.Size(885, 800)
        Me.tabJobDetails.ResumeLayout(False)
        Me.tabJobDetails.PerformLayout()
        Me.pnlTimeReq.ResumeLayout(False)
        Me.pnlTimeReq.PerformLayout()
        Me.pnlTypeOfWorks.ResumeLayout(False)
        Me.pnlTypeOfWorks.PerformLayout()
        Me.pnlSymptoms.ResumeLayout(False)
        Me.pnlSymptoms.PerformLayout()
        CType(Me.DGSymptoms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAppliance.ResumeLayout(False)
        Me.tabAppliance.PerformLayout()
        CType(Me.DgMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabJobType.ResumeLayout(False)
        Me.tabJobType.PerformLayout()
        Me.pnlSOR.ResumeLayout(False)
        Me.pnlSOR.PerformLayout()
        CType(Me.DGSOR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabProp.ResumeLayout(False)
        Me.tabProp.PerformLayout()
        CType(Me.DGVSites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcSites.ResumeLayout(False)
        Me.tabExistingJobs.ResumeLayout(False)
        Me.tabExistingJobs.PerformLayout()
        CType(Me.dgExistingVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAdditional.ResumeLayout(False)
        Me.tabAdditional.PerformLayout()
        CType(Me.DGAdditional, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCharging.ResumeLayout(False)
        Me.TabCharging.PerformLayout()
        Me.pnlCharge.ResumeLayout(False)
        Me.pnlCharge.PerformLayout()
        CType(Me.picTick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCross, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabBook.ResumeLayout(False)
        Me.TabBook.PerformLayout()
        Me.gpCombo.ResumeLayout(False)
        Me.tcComplete.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

        Me.tcSites.TabPages.Clear()
        Me.tcSites.TabPages.Add(Me.tabProp)

    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            ' Return CurrentSite
        End Get
    End Property

#End Region

#Region "Properties"

    Dim StopSelect As Boolean = False
    Dim SkillsList As List(Of String) = New List(Of String)
    Dim PromotionText As String = ""
    Dim FinalCharge As Double = 0
    Dim FinalText As String = ""
    Dim PromotionsDT As DataTable
    Dim ProgChange As Boolean

    Dim TimeReqOption As Boolean = False
    Dim BookingDetail As String = ""
    Dim visitcharge1 As Double
    Dim visitterm1 As String
    Dim visitcharge2 As Double
    Dim visitterm2 As String
    Dim jobids As Integer
    Dim servTime As Integer = 0
    Dim visitsBooked As Integer = 0
    Dim lastDate As Date = Date.MinValue
    Dim lastEngineerID As Integer = 0
    Dim reqtime As Integer
    Private Manualrecall As Boolean = False
    Private jobtype As String = ""
    Private RecallJobTypeID As Integer
    Private RecallJobID As Integer
    Private DocumentsControl As UCDocumentsList
    Private QuotesControl As UCQuotesList
    Private CustomerScheduleOfRateControl As UCCustomerScheduleOfRate
    Dim CurrentContract As Entity.ContractsOriginal.ContractOriginal = Nothing
    Dim appointments As DataTable = New DataTable
    Dim Temp As DataTable = New DataTable
    Dim Schedulerapps As DataTable = New DataTable
    Dim SpecialTrade As String = ""
    Dim LPGNEEDED As Boolean = False
    Dim OILNEEDED As Boolean = False
    Dim NATNEEDED As Boolean = False
    Dim HETASNEEDED As Boolean = False
    Dim ASNEEDED As Boolean = False
    Dim WAUNEEDED As Boolean = False
    Dim COMMNEEDED As Boolean = False
    Dim currentFilterDate As Date
    Dim LastsiteID As Integer
    Dim GasConfirmedInBoiler As Boolean = True
    Dim SiteChange As Boolean = False
    Dim DTPrivNotes As DataTable
    Dim CurrentJob As Entity.Jobs.Job
    Dim currentVisit As Entity.EngineerVisits.EngineerVisit
    Dim rftBundle As List(Of String) = New List(Of String)
    Dim costCentre As String = Nothing

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _FromForm As Form

    Public Property FromForm() As Form
        Get
            Return _FromForm
        End Get
        Set(ByVal value As Form)
            _FromForm = value
        End Set
    End Property

    Private _MainDataView As DataView = Nothing

    Public Property MainDataView() As DataView
        Get
            Return _MainDataView
        End Get
        Set(ByVal Value As DataView)
            _MainDataView = Value
            _MainDataView.Table.TableName = "MainApps"
            _MainDataView.AllowNew = False
            _MainDataView.AllowEdit = True
            _MainDataView.AllowDelete = False
            Me.DgMain.DataSource = MainDataView
        End Set
    End Property

    Private _DGVAdditional As DataView = Nothing

    Public Property DGVAdditional() As DataView
        Get
            Return _DGVAdditional
        End Get
        Set(ByVal Value As DataView)
            _DGVAdditional = Value
            _DGVAdditional.Table.TableName = "Additional"
            _DGVAdditional.AllowNew = False
            _DGVAdditional.AllowEdit = True
            _DGVAdditional.AllowDelete = False
            Me.DGAdditional.DataSource = _DGVAdditional
        End Set
    End Property

    Private _SORDataView As DataView = Nothing

    Public Property SORDataView() As DataView
        Get
            Return _SORDataView
        End Get
        Set(ByVal Value As DataView)
            _SORDataView = Value
            _SORDataView.Table.TableName = "SOR"
            _SORDataView.AllowNew = False
            _SORDataView.AllowEdit = True
            _SORDataView.AllowDelete = False
            Me.DGSOR.DataSource = SORDataView
        End Set
    End Property

    Private _SORSymp As DataView = Nothing
    Dim CoverApps As New List(Of Integer)
    Dim ChargeApps As New List(Of Integer)

    Public Property SympDataView() As DataView
        Get
            Return _SORSymp
        End Get
        Set(ByVal Value As DataView)
            _SORSymp = Value
            _SORSymp.Table.TableName = "Symptoms"
            _SORSymp.AllowNew = False
            _SORSymp.AllowEdit = True
            _SORSymp.AllowDelete = False
            Me.DGSymptoms.DataSource = SympDataView
        End Set
    End Property

    Private ReadOnly Property SelectedMainDataRow() As DataGridViewRow
        Get
            If (Not Me.DgMain.CurrentRow Is Nothing) AndAlso Not Me.DgMain.CurrentRow.Index = -1 Then
                Return Me.DgMain.CurrentRow
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _SiteDT As DataView

    Public Property SiteDT() As DataView
        Get
            Return _SiteDT
        End Get
        Set(ByVal Value As DataView)
            _SiteDT = Value
        End Set
    End Property

    Private _SiteID As Integer

    Public Property SiteID() As Integer
        Get
            Return _SiteID
        End Get
        Set(value As Integer)
            _SiteID = value
        End Set
    End Property

    Private ReadOnly Property SelecteddgvSitesDataRow() As DataGridViewRow
        Get
            If Not Me.DGVSites.CurrentRow Is Nothing AndAlso Not Me.DGVSites.CurrentRow.Index = -1 Then
                Return Me.DGVSites.CurrentRow
            Else
                Return Nothing
            End If

        End Get
    End Property

    Private _theCustomer As Entity.Customers.Customer

    Private Property theCustomer() As Entity.Customers.Customer
        Get
            Return _theCustomer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _theCustomer = Value
        End Set
    End Property

    Private _SelectedCustomerID As Integer = 0

    Private Property SelectedCustomerID() As Integer
        Get
            Return _SelectedCustomerID
        End Get
        Set(ByVal Value As Integer)
            _SelectedCustomerID = Value
        End Set
    End Property

    Dim time As Integer = 0
    Dim priTime As Integer = 0
    Dim secTime As Integer = 0

    Private FlagShown As Boolean = False
    Dim CurrentSite As Entity.Sites.Site
    Dim CurrentCustomer As Entity.Customers.Customer
    Dim UseContractVisit As Boolean = False

#End Region

#Region "Setup"

    Public Sub SetupSiteDataGridView()

        Entity.Sys.Helper.SetUpDataGridView(Me.DGVSites)
        DGVSites.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGVSites.AutoGenerateColumns = False
        DGVSites.Columns.Clear()
        DGVSites.EditMode = DataGridViewEditMode.EditOnEnter

        Dim Terms As New DataGridViewTextBoxColumn
        Terms.HeaderText = "Terms"
        Terms.FillWeight = 25
        Terms.DataPropertyName = "Terms"
        Terms.Name = "Terms"
        Terms.ReadOnly = True
        Terms.Visible = False
        Terms.SortMode = DataGridViewColumnSortMode.Programmatic
        DGVSites.Columns.Add(Terms)

        Dim ContractID As New DataGridViewTextBoxColumn
        ContractID.HeaderText = "ContractID"
        ContractID.FillWeight = 25
        ContractID.DataPropertyName = "ContractID"
        ContractID.Name = "ContractID"
        ContractID.ReadOnly = True
        ContractID.Visible = False
        ContractID.SortMode = DataGridViewColumnSortMode.Programmatic
        DGVSites.Columns.Add(ContractID)

        Dim SiteID As New DataGridViewTextBoxColumn
        SiteID.HeaderText = "SiteID"
        SiteID.FillWeight = 25
        SiteID.DataPropertyName = "siteid"
        SiteID.Name = "siteid"
        SiteID.ReadOnly = True
        SiteID.Visible = False
        SiteID.SortMode = DataGridViewColumnSortMode.Programmatic
        DGVSites.Columns.Add(SiteID)

        Dim Customer As New DataGridViewTextBoxColumn
        Customer.HeaderText = "Customer"
        Customer.FillWeight = 25
        Customer.DataPropertyName = "Customer"
        Customer.Name = "Customer"
        Customer.ReadOnly = True
        Customer.Visible = True
        Customer.SortMode = DataGridViewColumnSortMode.Automatic
        DGVSites.Columns.Add(Customer)

        Dim PartNumber As New DataGridViewTextBoxColumn
        PartNumber.HeaderText = "Site Name"
        PartNumber.DataPropertyName = "SiteName"
        PartNumber.FillWeight = 20
        PartNumber.ReadOnly = True
        PartNumber.SortMode = DataGridViewColumnSortMode.Automatic
        DGVSites.Columns.Add(PartNumber)

        Dim Address1 As New DataGridViewTextBoxColumn
        Address1.FillWeight = 35
        Address1.HeaderText = "Address 1"
        Address1.DataPropertyName = "Address1"
        Address1.Name = "Address1"
        Address1.ReadOnly = True
        Address1.Visible = True
        Address1.SortMode = DataGridViewColumnSortMode.Automatic
        DGVSites.Columns.Add(Address1)

        Dim Address2 As New DataGridViewTextBoxColumn
        Address2.FillWeight = 30
        Address2.HeaderText = "Address 2"
        Address2.DataPropertyName = "Address2"
        Address2.Name = "Address2"
        Address2.ReadOnly = True
        Address2.Visible = True
        Address2.SortMode = DataGridViewColumnSortMode.Automatic
        DGVSites.Columns.Add(Address2)

        Dim Address3 As New DataGridViewTextBoxColumn
        Address3.FillWeight = 30
        Address3.HeaderText = "Address 3"
        Address3.DataPropertyName = "Address3"
        Address3.Name = "Address3"
        Address3.ReadOnly = True
        Address3.Visible = False
        Address3.SortMode = DataGridViewColumnSortMode.Automatic
        DGVSites.Columns.Add(Address3)

        Dim Postcode As New DataGridViewTextBoxColumn
        Postcode.HeaderText = "Postcode"
        Postcode.DataPropertyName = "Postcode"
        Postcode.Name = "Postcode"
        Postcode.FillWeight = 25
        Postcode.ReadOnly = True
        Postcode.SortMode = DataGridViewColumnSortMode.Automatic
        DGVSites.Columns.Add(Postcode)

        Dim Tel As New DataGridViewTextBoxColumn
        Tel.HeaderText = "Tel No."
        Tel.DataPropertyName = "TelephoneNum"
        Tel.Name = "TelephoneNum"
        Tel.FillWeight = 20
        Tel.ReadOnly = True
        Tel.SortMode = DataGridViewColumnSortMode.Automatic
        DGVSites.Columns.Add(Tel)

        Dim Mob As New DataGridViewTextBoxColumn
        Mob.HeaderText = "Mobile No."
        Mob.DataPropertyName = "faxnum"
        Mob.Name = "faxnum"
        Mob.FillWeight = 20
        Mob.ReadOnly = True
        Mob.SortMode = DataGridViewColumnSortMode.Automatic
        DGVSites.Columns.Add(Mob)

        Dim EmailAddress As New DataGridViewTextBoxColumn
        EmailAddress.HeaderText = "Email Address"
        EmailAddress.DataPropertyName = "EmailAddress"
        EmailAddress.Name = "EmailAddress"
        EmailAddress.FillWeight = 16
        EmailAddress.ReadOnly = True
        EmailAddress.SortMode = DataGridViewColumnSortMode.Automatic
        DGVSites.Columns.Add(EmailAddress)

        Dim ContractRef As New DataGridViewTextBoxColumn
        ContractRef.HeaderText = "Contract Ref"
        ContractRef.DataPropertyName = "ContractRef"
        ContractRef.Name = "ContractRef"
        ContractRef.FillWeight = 20
        ContractRef.ReadOnly = True
        ContractRef.SortMode = DataGridViewColumnSortMode.Automatic
        DGVSites.Columns.Add(ContractRef)

        Dim Title As New DataGridViewTextBoxColumn
        Title.FillWeight = 40
        Title.HeaderText = "Title"
        Title.DataPropertyName = "Title"
        Title.Name = "Title"
        Title.ReadOnly = True
        Title.Visible = False
        Title.SortMode = DataGridViewColumnSortMode.Programmatic
        DGVSites.Columns.Add(Title)

        Dim FirstName As New DataGridViewTextBoxColumn
        FirstName.FillWeight = 40
        FirstName.HeaderText = "Address 3"
        FirstName.DataPropertyName = "FirstName"
        FirstName.Name = "FirstName"
        FirstName.ReadOnly = True
        FirstName.Visible = False
        FirstName.SortMode = DataGridViewColumnSortMode.Programmatic
        DGVSites.Columns.Add(FirstName)

        Dim Surname As New DataGridViewTextBoxColumn
        Surname.FillWeight = 40
        Surname.HeaderText = "Address 3"
        Surname.DataPropertyName = "Surname"
        Surname.Name = "Surname"
        Surname.ReadOnly = True
        Surname.Visible = False
        Surname.SortMode = DataGridViewColumnSortMode.Programmatic
        DGVSites.Columns.Add(Surname)

        Dim Notes As New DataGridViewTextBoxColumn
        Notes.FillWeight = 40
        Notes.HeaderText = "Notes"
        Notes.DataPropertyName = "Notes"
        Notes.Name = "Notes"
        Notes.ReadOnly = True
        Notes.Visible = False
        Notes.SortMode = DataGridViewColumnSortMode.Programmatic
        DGVSites.Columns.Add(Notes)

        Dim Name As New DataGridViewTextBoxColumn
        Name.FillWeight = 40
        Name.HeaderText = "Address 3"
        Name.DataPropertyName = "Name"
        Name.Name = "Name"
        Name.ReadOnly = True
        Name.Visible = False
        Name.SortMode = DataGridViewColumnSortMode.Programmatic
        DGVSites.Columns.Add(Name)

        ' DGVSites.Sort(Customer, System.ComponentModel.ListSortDirection.Descending)

    End Sub

    Public Sub SetupAppsDG()

        Entity.Sys.Helper.SetUpDataGridView(Me.DgMain)
        DgMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DgMain.AutoGenerateColumns = False
        DgMain.Columns.Clear()
        DgMain.EditMode = DataGridViewEditMode.EditOnEnter

        Dim SiteID As New DataGridViewTextBoxColumn

        SiteID.FillWeight = 25
        SiteID.DataPropertyName = "AssetID"
        SiteID.Name = "AssetID"
        SiteID.ReadOnly = True
        SiteID.Visible = False
        SiteID.SortMode = DataGridViewColumnSortMode.Programmatic
        DgMain.Columns.Add(SiteID)

        Dim Customer As New DataGridViewTextBoxColumn

        Customer.FillWeight = 25
        Customer.DataPropertyName = "Product"
        Customer.Name = "Product"
        Customer.ReadOnly = True
        Customer.Visible = True
        Customer.SortMode = DataGridViewColumnSortMode.Programmatic
        DgMain.Columns.Add(Customer)

        ' DGVSites.Sort(Customer, System.ComponentModel.ListSortDirection.Descending)

    End Sub

    Public Sub SetupSOR()

        Entity.Sys.Helper.SetUpDataGridView(Me.DGSOR)
        DGSOR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGSOR.AutoGenerateColumns = False
        DGSOR.Columns.Clear()
        DGSOR.EditMode = DataGridViewEditMode.EditOnEnter

        Dim SiteID As New DataGridViewTextBoxColumn

        SiteID.FillWeight = 25
        SiteID.DataPropertyName = "SORID"
        SiteID.Name = "SORID"
        SiteID.ReadOnly = True
        SiteID.Visible = False
        SiteID.SortMode = DataGridViewColumnSortMode.Programmatic
        DGSOR.Columns.Add(SiteID)

        Dim Code As New DataGridViewTextBoxColumn

        Code.FillWeight = 25
        Code.DataPropertyName = "Code"
        Code.Name = "Code"
        Code.ReadOnly = True
        Code.Visible = True
        Code.SortMode = DataGridViewColumnSortMode.Programmatic
        DGSOR.Columns.Add(Code)

        Dim Description As New DataGridViewTextBoxColumn

        Description.FillWeight = 100
        Description.DataPropertyName = "Description"
        Description.Name = "Description"
        Description.ReadOnly = True
        Description.Visible = True
        Description.SortMode = DataGridViewColumnSortMode.Programmatic
        DGSOR.Columns.Add(Description)

        Dim Qty As New DataGridViewTextBoxColumn

        Qty.FillWeight = 15
        Qty.DataPropertyName = "Qty"
        Qty.Name = "Qty"
        Qty.ReadOnly = True
        Qty.Visible = True
        Qty.SortMode = DataGridViewColumnSortMode.Programmatic
        DGSOR.Columns.Add(Qty)

        Dim Time As New DataGridViewTextBoxColumn

        Time.FillWeight = 20
        Time.DataPropertyName = "TimeInMins"
        Time.HeaderText = "Mins"
        Time.Name = "TimeInMins"
        Time.ReadOnly = True
        Time.Visible = True
        Time.SortMode = DataGridViewColumnSortMode.Programmatic
        DGSOR.Columns.Add(Time)

        Dim Price As New DataGridViewTextBoxColumn

        Price.FillWeight = 25
        Price.DataPropertyName = "Price"
        Price.Name = "Price"
        Price.ReadOnly = True
        Price.Visible = False
        Price.SortMode = DataGridViewColumnSortMode.Programmatic
        DGSOR.Columns.Add(Price)

        ' DGVSites.Sort(Customer, System.ComponentModel.ListSortDirection.Descending)

    End Sub

    Public Sub SetupDGSymptoms()

        Entity.Sys.Helper.SetUpDataGridView(Me.DGSymptoms)
        DGSymptoms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGSymptoms.AutoGenerateColumns = False
        DGSymptoms.Columns.Clear()
        DGSymptoms.EditMode = DataGridViewEditMode.EditOnEnter

        Dim ID As New DataGridViewTextBoxColumn

        ID.FillWeight = 1
        ID.DataPropertyName = "SypID"
        ID.Name = "SypID"
        ID.ReadOnly = True
        ID.Visible = True
        ID.SortMode = DataGridViewColumnSortMode.Programmatic
        DGSymptoms.Columns.Add(ID)

        Dim Code As New DataGridViewTextBoxColumn

        Code.FillWeight = 25
        Code.DataPropertyName = "Code"
        Code.Name = "Code"
        Code.ReadOnly = True
        Code.Visible = True
        Code.SortMode = DataGridViewColumnSortMode.Programmatic
        DGSymptoms.Columns.Add(Code)

        Dim Description As New DataGridViewTextBoxColumn

        Description.FillWeight = 100
        Description.DataPropertyName = "Description"
        Description.Name = "Description"
        Description.ReadOnly = True
        Description.Visible = True
        Description.SortMode = DataGridViewColumnSortMode.Programmatic
        DGSymptoms.Columns.Add(Description)

    End Sub

    Public Sub SetupDGAdditional()

        Entity.Sys.Helper.SetUpDataGridView(Me.DGAdditional)
        DGAdditional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGAdditional.AutoGenerateColumns = False
        DGAdditional.Columns.Clear()
        DGAdditional.EditMode = DataGridViewEditMode.EditOnEnter

        Dim ID As New DataGridViewTextBoxColumn

        ID.FillWeight = 25
        ID.DataPropertyName = "ID"
        ID.Name = "ID"
        ID.ReadOnly = True
        ID.Visible = False
        ID.SortMode = DataGridViewColumnSortMode.Programmatic
        DGAdditional.Columns.Add(ID)

        Dim Product As New DataGridViewTextBoxColumn

        Product.FillWeight = 25
        Product.DataPropertyName = "Product"
        Product.Name = "Product"
        Product.ReadOnly = True
        Product.Visible = False
        Product.SortMode = DataGridViewColumnSortMode.Programmatic
        DGAdditional.Columns.Add(Product)

        Dim AssetID As New DataGridViewTextBoxColumn

        AssetID.FillWeight = 25
        AssetID.DataPropertyName = "AssetID"
        AssetID.Name = "AssetID"
        AssetID.ReadOnly = True
        AssetID.Visible = False
        AssetID.SortMode = DataGridViewColumnSortMode.Programmatic
        DGAdditional.Columns.Add(AssetID)

        Dim Description As New DataGridViewTextBoxColumn

        Description.FillWeight = 100
        Description.DataPropertyName = "Description"
        Description.Name = "Description"
        Description.ReadOnly = True
        Description.Visible = True
        Description.SortMode = DataGridViewColumnSortMode.Programmatic
        DGAdditional.Columns.Add(Description)

    End Sub

    Public Sub SetupExisitingJobs()

        Entity.Sys.Helper.SetUpDataGridView(Me.dgExistingVisits)
        dgExistingVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgExistingVisits.AutoGenerateColumns = False
        dgExistingVisits.Columns.Clear()
        dgExistingVisits.EditMode = DataGridViewEditMode.EditOnEnter

        Dim ID As New DataGridViewTextBoxColumn

        ID.FillWeight = 25
        ID.DataPropertyName = "ID"
        ID.Name = "ID"
        ID.ReadOnly = True
        ID.Visible = False
        ID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgExistingVisits.Columns.Add(ID)

        Dim AssetID As New DataGridViewTextBoxColumn

        AssetID.FillWeight = 26
        AssetID.DataPropertyName = "CreatedDate"
        AssetID.Name = "Created Date"
        AssetID.ReadOnly = True
        AssetID.Visible = True
        AssetID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgExistingVisits.Columns.Add(AssetID)

        Dim JobNumber As New DataGridViewTextBoxColumn

        JobNumber.FillWeight = 25
        JobNumber.DataPropertyName = "JobNumber"
        JobNumber.Name = "Job Number"
        JobNumber.ReadOnly = True
        JobNumber.Visible = True
        JobNumber.SortMode = DataGridViewColumnSortMode.Programmatic
        dgExistingVisits.Columns.Add(JobNumber)

        Dim Product As New DataGridViewTextBoxColumn

        Product.FillWeight = 25
        Product.DataPropertyName = "JobType"
        Product.Name = "Job Type"
        Product.ReadOnly = True
        Product.Visible = True
        Product.SortMode = DataGridViewColumnSortMode.Programmatic
        dgExistingVisits.Columns.Add(Product)

        Dim Description As New DataGridViewTextBoxColumn

        Description.FillWeight = 150
        Description.DataPropertyName = "Description"
        Description.Name = "Description"
        Description.ReadOnly = True
        Description.Visible = True
        Description.SortMode = DataGridViewColumnSortMode.Programmatic
        dgExistingVisits.Columns.Add(Description)

    End Sub

    Private Sub dgvSitesContracrPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGVSites.RowPostPaint

        If e.RowIndex < Me.DGVSites.RowCount - 1 Then
            Dim dgvRow As DataGridViewRow = Me.DGVSites.Rows(e.RowIndex)

            '<== This is the header Name
            'If CInt(dgvRow.Cells("EmployeeStatus_Training_e26").Value) <> 2 Then

            '<== But this is the name assigned to it in the properties of the control
            If (dgvRow.Cells("ContractRef").Value.ToString) <> "" Then

                dgvRow.DefaultCellStyle.ForeColor = Color.Green
                dgvRow.DefaultCellStyle.SelectionForeColor = Color.Green
            Else
                ' dgvRow.DefaultCellStyle.BackColor = Color.LightPink

            End If

        End If

    End Sub

#End Region

#Region "Events"

    Function Save() As Boolean Implements IUserControl.Save

        Return True
    End Function

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate

    End Sub

#End Region

#Region "Sites"

    Private Sub txtSearch_TextChanged(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            RunFilter()
        End If
    End Sub

    Private Sub RunFilter()
        If txtSearch.Text.Length > 0 Then

            SiteDT = DB.Sites.Search_JobWizard(Helper.MakeStringValid(txtSearch.Text), loggedInUser.UserID)
            StopSelect = True
            DGVSites.DataSource = SiteDT
            If DGVSites.RowCount > 0 Then
                DGVSites.Rows(0).Selected = False
                StopSelect = False
            Else
                ClearSiteDetails()
            End If
        Else
            ClearSiteDetails()

        End If

    End Sub

    Private Sub btnAddSite_Click(sender As Object, e As EventArgs) Handles btnAddSite.Click
        ShowForm(GetType(FRMSite), True, Nothing)
        Me.Cursor = Cursors.WaitCursor

        RunFilter()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnEditSite_Click(sender As Object, e As EventArgs) Handles btnEditSite.Click
        If SelecteddgvSitesDataRow.Index >= 0 Then
            Dim selectedRow As Integer = DGVSites.CurrentCell.RowIndex
            Dim selectedCol As Integer = DGVSites.CurrentCell.ColumnIndex
            Dim selectedSiteID As Integer = SiteID
            ShowForm(GetType(FRMSite), True, New Object() {SiteID, FRMJobWizard})

            Me.Cursor = Cursors.WaitCursor
            RunFilter()

            DGVSites.Rows(selectedRow).Cells(selectedCol).Selected = True
            SiteID = selectedSiteID
            populateSiteData()
            Me.Cursor = Cursors.Default

            PopulateSite()
        End If

    End Sub

    Private Sub PopulateSite()
        Me.txtCustomer.Text = CurrentCustomer.Name

        ProgChange = True
        Combo.SetSelectedComboItem_By_Description(Me.cboTitle, CurrentSite.Salutation)
        Me.txtFirstName.Text = CurrentSite.FirstName
        Me.txtSurname.Text = CurrentSite.Surname
        Me.txtAddress1.Text = CurrentSite.Address1
        Me.txtAddress2.Text = CurrentSite.Address2
        Me.txtAddress3.Text = CurrentSite.Address3
        Me.txtPostcode.Text = CurrentSite.Postcode
        Me.txtTel.Text = CurrentSite.TelephoneNum
        Me.txtMob.Text = CurrentSite.FaxNum
        Me.txtEmail.Text = CurrentSite.EmailAddress
        Me.txtContactAlert.Text = CurrentSite.ContactAlerts
        Me.txtDefect.Text = CurrentSite.Defects
        Me.chbCommercial.Checked = CurrentSite.CommercialDistrict
        Me.txtContractRef.Text = Helper.MakeStringValid(SelecteddgvSitesDataRow.Cells("ContractRef").Value)
        ProgChange = False
        SiteChange = False
    End Sub

    Private Sub DGVSites_CellContentClick() Handles DGVSites.SelectionChanged
        If StopSelect = False AndAlso Not SelecteddgvSitesDataRow Is Nothing AndAlso SelecteddgvSitesDataRow.Index > -1 Then

            SiteID = Helper.MakeIntegerValid(SelecteddgvSitesDataRow.Cells.Item("SiteID").Value)

            btnxxSiteNext.Visible = True
            If LastsiteID <> SiteID Then
                CurrentContract = Nothing
                '''''' HERE FOR ANY CLEARING '''''''

                chkCert.Visible = False
                chkCert.Checked = False
                lblcert.Visible = False

                Try
                    tcSites.TabPages(0).Enabled = True
                    tab = 0
                    tcSites.TabPages.Remove(tabExistingJobs)
                    tcSites.TabPages.Remove(tabJobType)
                    tcSites.TabPages.Remove(tabJobDetails)
                    tcSites.TabPages.Remove(tabAppliance)
                    tcSites.TabPages.Remove(TabCharging)
                    tcSites.TabPages.Remove(tabAdditional)
                    tcSites.TabPages.Remove(TabBook)
                    tcSites.TabPages.Remove(tcComplete)

                    tcSites.SelectedIndex = 0
                    '   tcSites.SelectedIndex = 1
                Catch ex As Exception
                    tcSites.SelectedIndex = 0
                End Try

                GasConfirmedInBoiler = True

                Dim dv As New DataView
                Dim dt1 As New DataTable
                dt1.TableName = "1"
                dt1.Columns.Add("SypID")
                dt1.Columns.Add("Code")
                dt1.Columns.Add("Description")

                dv.Table = dt1
                SympDataView = dv
                DGSymptoms.DataSource = dt1
                SiteChange = False

                For Each c As Control In tabJobType.Controls   ' neat way to toggle button colors
                    If TypeOf c Is Button Then
                        c.BackColor = SystemColors.Control

                    End If
                Next
                btnxxNewJob.BackColor = SystemColors.Control

                txtPONumber.Text = ""
                txtAdditional.Text = ""

            End If
            LastsiteID = SiteID
            DTPrivNotes = DB.Job.GetAllJobNotes(SiteID)

            populateSiteData()
            If CurrentCustomer.CustomerTypeID <> Enums.CustomerType.Domestic Then
                chkCert.Checked = True
            Else
                chkCert.Checked = False
            End If
            PromotionsDT = DB.Customer.CustomerType_GetAll_Promotions(CurrentCustomer.CustomerTypeID).Table

            ParentForm.Text = "Job: Adding new for " & CurrentSite.Salutation &
                                                    " " & CurrentSite.Surname & " - " &
                                                            CurrentSite.Address1 & " " &
                                                            CurrentSite.Postcode & If(CurrentSite.CommercialDistrict, " *DISTRICT* ", "")

            Dim c1 As Control() = ParentForm.Controls.Find("btnPrivateNotes", True)
            Dim b1 As Button = c1(0)
            b1.Visible = False
            PopulateSite()

            Dim ContractText As String = ""
            If Not IsDBNull(SelecteddgvSitesDataRow.Cells("ContractID").Value) Then
                CurrentContract = New Entity.ContractsOriginal.ContractOriginal
                CurrentContract = DB.ContractOriginal.Get(SelecteddgvSitesDataRow.Cells("ContractID").Value)

                ContractText += txtContractRef.Text & " - " & DB.Picklists.Get_One_As_Object(CurrentContract.ContractTypeID).Name & vbNewLine & "(" & CurrentContract.ContractStartDate.ToString("dd/MM/yy") & "-" & CurrentContract.ContractEndDate.ToString("dd/MM/yy") & ")"

                If CurrentContract.PlumbingDrainage = True Then

                    ContractText += vbNewLine & "Plumbing And Drainage Cover : YES"
                Else
                    ContractText += vbNewLine & "Plumbing And Drainage Cover : NO"

                End If
                If CurrentContract.GasSupplyPipework = True Then
                    ContractText += vbNewLine & "Gas Pipework Cover : YES"
                Else
                    ContractText += vbNewLine & "Gas Pipework Cover : NO"
                End If

                If CurrentContract.WindowLockPest = True Then
                    ContractText += vbNewLine & "Window Lock And Pest Cover : YES"
                Else
                    ContractText += vbNewLine & "Window Lock And Pest Cover : NO"
                End If

            End If

            ToolTip1.SetToolTip(txtContractRef, ContractText)
        Else
            btnxxSiteNext.Visible = False

            '         ClearSiteDetails()

        End If

    End Sub

    Private Sub populateSiteData()
        CurrentSite = DB.Sites.Get(SiteID)
        CurrentCustomer = DB.Customer.Customer_Get(CurrentSite.CustomerID)
    End Sub

    Private Sub btnJobHistory_Click(sender As Object, e As EventArgs) Handles btnJobHistory.Click
        If SelecteddgvSitesDataRow.Index >= 0 Then
            ShowForm(GetType(FRMSiteVisitManager), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SiteID), FRMJobWizard})
        End If
    End Sub

#End Region

#Region "ExisistingJob"

    Private Sub dgExistingVisits_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgExistingVisits.CellClick
        If dgExistingVisits.SelectedRows.Count > 0 Then
            btnxxExistingJobNext.Enabled = True
            btnxxExistingJobNext.Visible = True
            btnxxNewJob.BackColor = System.Drawing.SystemColors.Control
            CurrentJob = DB.Job.Job_Get_For_An_EngineerVisit_ID(dgExistingVisits.SelectedRows(0).Cells(0).Value)
            currentVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(dgExistingVisits.SelectedRows(0).Cells(0).Value)

            If Not CurrentJob Is Nothing Then

                Dim assetdt As DataTable = DB.Asset.Asset_GetForSite(SiteID).Table

                Dim alist As ArrayList = CurrentJob.Assets

                MainDataView = DB.ContractOriginal.GetAssetsForContract(0, True)

                For Each ar As Entity.JobAssets.JobAsset In alist
                    Try

                        Dim datarow As DataRow = assetdt.Select("AssetID = " & ar.AssetID)(0)

                        MainDataView.AllowNew = True
                        Dim newrow As DataRowView = MainDataView.AddNew
                        newrow("AssetID") = ar.AssetID
                        Dim asset As Entity.Assets.Asset = DB.Asset.Asset_Get(ar.AssetID)

                        newrow("Product") = datarow("Product")

                        newrow.EndEdit()
                    Catch ex As Exception

                    End Try
                Next

                DgMain.DataSource = MainDataView

            End If
        Else
            btnxxExistingJobNext.Enabled = False
        End If

    End Sub

    Private Sub btnxxNewJob_Click(sender As Object, e As EventArgs) Handles btnxxNewJob.Click
        If CType(sender, Button).BackColor = System.Drawing.Color.PaleGreen Then

            CType(sender, Button).BackColor = System.Drawing.SystemColors.Control
            If dgExistingVisits.SelectedRows.Count < 1 Then
                btnxxExistingJobNext.Visible = False
            End If
        Else
            dgExistingVisits.ClearSelection()
            CType(sender, Button).BackColor = System.Drawing.Color.PaleGreen
            btnxxExistingJobNext.Visible = True
            CurrentJob = Nothing
            currentVisit = Nothing
        End If

    End Sub

#End Region

#Region "Job Type"

    Private Sub cbotypeWiz_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotypeWiz.SelectedIndexChanged

        If Combo.GetSelectedItemValue(cbotypeWiz) < 1 Then
            btnxxJobNext.Visible = False
        ElseIf Combo.GetSelectedItemValue(cbotypeWiz) = Enums.JobTypes.ServiceCertificate Then
            lblcert.Visible = True
            chkCert.Visible = True
            chkCert.Checked = True
            btnxxJobNext.Visible = True
            jobtype = Combo.GetSelectedItemDescription(cbotypeWiz).ToUpper
        ElseIf Combo.GetSelectedItemValue(cbotypeWiz) = Enums.JobTypes.Service Then
            lblcert.Visible = True
            chkCert.Visible = True
            chkCert.Checked = False
            btnxxJobNext.Visible = True
            jobtype = Combo.GetSelectedItemDescription(cbotypeWiz).ToUpper
        Else
            lblcert.Visible = False
            chkCert.Visible = False
            btnxxJobNext.Visible = True
            jobtype = Combo.GetSelectedItemDescription(cbotypeWiz).ToUpper
            btnxxDetailsNext.Visible = True
        End If

    End Sub

    'End Sub

    Private Sub btnSORAdd_Click(sender As Object, e As EventArgs) Handles btnSORAdd.Click

        If Combo.GetSelectedItemValue(cboSOR) > 0 AndAlso IsNumeric(txtSORQty.Text) AndAlso txtSORQty.Text.Length > 0 AndAlso txtSORQty.Text > 0 Then
            SORDataView.AllowNew = True
            Dim newrow As DataRowView = SORDataView.AddNew
            Dim sor As Entity.CustomerScheduleOfRates.CustomerScheduleOfRate
            sor = DB.CustomerScheduleOfRate.Get(Combo.GetSelectedItemValue(cboSOR))
            newrow("SORID") = sor.CustomerScheduleOfRateID
            newrow("Code") = sor.Code
            newrow("Description") = sor.Description
            newrow("Qty") = txtSORQty.Text
            newrow("TimeInMins") = sor.TimeInMins
            newrow("Price") = sor.Price
            newrow.EndEdit()
            DGSOR.DataSource = SORDataView
            txtSORQty.Text = "1"
        End If

        If DGSOR.RowCount > 0 Then
            '    If CurrentSite.PoNumReqd And txtPONumber.Text.Length = 0 Then

            '    Else

            '        If cboPriority.Items.Count > 0 And Combo.GetSelectedItemValue(cboPriority) < 1 Then
            '        Else
            btnxxJobNext.Visible = True
            '        End If
            '    End If
        Else
            btnxxJobNext.Visible = False
        End If

    End Sub

    Private Sub btnSORMinus_Click(sender As Object, e As EventArgs) Handles btnSORMinus.Click

        If Not DGSOR.CurrentRow Is Nothing Then
            SORDataView.AllowDelete = True
            SORDataView.Table.Rows.RemoveAt(DGSOR.CurrentRow.Index)
        End If

        If DGSOR.RowCount > 0 Then
            If CurrentSite.PoNumReqd And txtPONumber.Text.Length = 0 Then
            Else

                If cboPriority.Items.Count > 0 And Combo.GetSelectedItemValue(cboPriority) < 1 Then
                Else
                    btnxxJobNext.Visible = True
                End If
            End If
        Else
            btnxxJobNext.Visible = False
        End If

    End Sub

#End Region

#Region "Appliances"

    Private Sub btnAddMain_Click(sender As Object, e As EventArgs) Handles btnAddMain.Click

        If Combo.GetSelectedItemValue(cboMainApps) > 0 Then

            MainDataView.AllowNew = True
            Dim newrow As DataRowView = MainDataView.AddNew
            newrow("AssetID") = Combo.GetSelectedItemValue(cboMainApps)
            newrow("Product") = Combo.GetSelectedItemDescription(cboMainApps)

            newrow.EndEdit()

            DgMain.DataSource = MainDataView

        End If

        If DgMain.RowCount > 0 Then

            btnxxApplianceNext.Visible = True
        Else
            btnxxApplianceNext.Visible = False

        End If

    End Sub

    Private Sub btnMinusMain_Click(sender As Object, e As EventArgs) Handles btnMinusMain.Click
        If Not DgMain.CurrentRow Is Nothing Then

            MainDataView.AllowDelete = True
            MainDataView.Table.Rows.RemoveAt(SelectedMainDataRow.Index)

        End If

        If DgMain.RowCount > 0 Then

            btnxxApplianceNext.Visible = True
        Else
            btnxxApplianceNext.Visible = False

        End If

    End Sub

#End Region

#Region "Details"

    Private Sub cboPriority_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPriority.SelectedIndexChanged
        ValidateJobDetails()
    End Sub

    Private Sub txtPONumber_TextChanged(sender As Object, e As EventArgs) Handles txtPONumber.TextChanged
        ValidateJobDetails()
    End Sub

    Private Sub btnSymAdd_Click(sender As Object, e As EventArgs) Handles btnSymAdd.Click
        If Combo.GetSelectedItemValue(cboSymptom) > 0 Then
            SympDataView.AllowNew = True
            Dim newrow As DataRowView = SympDataView.AddNew
            newrow("SypID") = Combo.GetSelectedItemValue(cboSymptom)
            newrow("Code") = Combo.GetSelectedItemDescription(cboSymptom).Split(" ")(0)
            newrow("Description") = Combo.GetSelectedItemDescription(cboSymptom).Substring(Combo.GetSelectedItemDescription(cboSymptom).IndexOf(" ") + 1)
            'Combo.GetSelectedItemDescription(cboSymptom).Split("^")(1)
            newrow.EndEdit()
            DGSymptoms.DataSource = SympDataView
        End If
        ValidateJobDetails()
    End Sub

    Private Sub ValidateJobDetails()
        If (DGSymptoms.RowCount > 0 Or pnlSymptoms.Visible = False) And (cboPriority.Visible = False Or Combo.GetSelectedItemValue(cboPriority) > 0) Or ((jobtype <> "BREAKDOWN" And jobtype <> "SERVICE") Or Combo.GetSelectedItemValue(cboTypeOfWorks) > 0) Then
            If (CurrentSite.PoNumReqd And txtPONumber.Text.Length > 0) Or Not CurrentSite.PoNumReqd Then
                btnxxDetailsNext.Visible = True
            Else
                btnxxDetailsNext.Visible = True
            End If
            For Each dr As DataGridViewRow In DGSymptoms.Rows
                If dr.Cells("Code").Value = "OTHER" AndAlso txtAdditional.Text.Length = 0 Then
                    btnxxDetailsNext.Visible = False
                End If
            Next
        Else
            btnxxDetailsNext.Visible = False
        End If
    End Sub

    Private Sub btnSymMinus_Click(sender As Object, e As EventArgs) Handles btnSymMinus.Click
        If Not DGSymptoms.CurrentRow Is Nothing Then
            SympDataView.AllowDelete = True
            SympDataView.Table.Rows.RemoveAt(DGSymptoms.CurrentRow.Index)
        End If
        ValidateJobDetails()
    End Sub

    Private Sub cboTypeOfWorks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTypeOfWorks.SelectedIndexChanged
        ValidateJobDetails()
    End Sub

#End Region

#Region "Next Buttons"

    Private Sub btnSiteNext_Click(sender As Object, e As EventArgs) Handles btnxxSiteNext.Click

        Combo.SetUpCombo(Me.cboPriority, DB.Customer.Priorities_Get_For_CustomerID_Active(CurrentSite.CustomerID).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        Combo.SetUpCombo(Me.cboSymptom, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Symptoms).Table, "ManagerID", "Combo", Entity.Sys.Enums.ComboValues.Please_Select)
        Dim dv As New DataView
        Dim dt1 As New DataTable
        dt1.TableName = "1"
        dt1.Columns.Add("SORID")
        dt1.Columns.Add("Code")
        dt1.Columns.Add("Description")
        dt1.Columns.Add("Qty")
        dt1.Columns.Add("TimeInMins")
        dt1.Columns.Add("Price")
        dv.Table = dt1
        SORDataView = dv
        DGSOR.DataSource = dt1
        If tcSites.TabCount = 1 Then
            tcSites.TabPages.Insert(1, tabExistingJobs)
        End If
        tab = 1
        tcSites.SelectedIndex = 1

        Application.DoEvents()
        tcSites.SelectedTab = tcSites.TabPages.Item(tab)
        Application.DoEvents()

        dgExistingVisits.DataSource = DB.EngineerVisits.EngineerVisits_Get_AllReady_ForSite(CurrentSite.SiteID)
        dgExistingVisits.ClearSelection()
        btnxxExistingJobNext.BackColor = System.Drawing.SystemColors.Control

    End Sub

    Private Sub btnxxExistingJobNext_Click(sender As Object, e As EventArgs) Handles btnxxExistingJobNext.Click

        If IsRFT Then  ' TODO drive a favorite for customer id in db  ' ATM im using button name and tag to hold text type and jobtypeID

            btnxxBreakdown.Visible = False
            BtnxxService.Visible = False
            btnxxKitchens.Visible = False
            btnxxMultiTrade.Visible = True
            btnxxPlumbing.Visible = True
            btnxxElectrical.Visible = True
            btnxxExternalBM.Visible = False
            btnxxCarpentry.Visible = True
        Else

            btnxxBreakdown.Visible = True
            BtnxxService.Visible = True
            btnxxKitchens.Visible = False
            btnxxMultiTrade.Visible = False
            btnxxPlumbing.Visible = False
            btnxxElectrical.Visible = False
            btnxxExternalBM.Visible = False
            btnxxCarpentry.Visible = False

        End If

        If btnxxNewJob.BackColor = System.Drawing.Color.PaleGreen Then
            If tcSites.TabCount = 2 Then
                tcSites.TabPages.Insert(2, tabJobType)
            End If
            tab = 2
            tcSites.SelectedIndex = 2
            lblUnabletoConfirm.Visible = False
            CurrentJob = Nothing

            Dim c1 As Control() = ParentForm.Controls.Find("btnPrivateNotes", True)
            Dim b1 As Button = c1(0)
            b1.Visible = True

        ElseIf dgExistingVisits.SelectedRows.Count > 0 Then

            lblUnabletoConfirm.Visible = True
            CurrentJob = DB.Job.Job_Get_For_An_EngineerVisit_ID(dgExistingVisits.SelectedRows(0).Cells(0).Value)
            currentVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(dgExistingVisits.SelectedRows(0).Cells(0).Value)
            DGSymptoms.DataSource = DB.EngineerVisits.GetSymptoms(currentVisit.EngineerVisitID)
            Dim extpropdt As DataTable = DB.EngineerVisits.GetExtendedProperties(currentVisit.EngineerVisitID)
            If extpropdt.Rows.Count > 0 Then
                txtAdditional.Text = extpropdt.Rows(0)("AdditionalNotes")
            Else
                If currentVisit.NotesToEngineer.LastIndexOf("based Works -") > 0 Then

                    txtAdditional.Text = currentVisit.NotesToEngineer.Substring(currentVisit.NotesToEngineer.LastIndexOf("based Works -") + 13).Trim(" ")
                ElseIf currentVisit.NotesToEngineer.LastIndexOf("- See SOR List") > 0 Then
                    txtAdditional.Text = currentVisit.NotesToEngineer.Substring(currentVisit.NotesToEngineer.LastIndexOf("- See SOR List") + 14).Trim(" ")
                Else
                    txtAdditional.Text = currentVisit.NotesToEngineer
                End If
            End If

            ' JOB TYPES '''''''''''''''''''''''''

            'JobTypes

            If tcSites.TabCount = 2 Then
                tcSites.TabPages.Insert(2, tabJobType)
            End If
            tab = 2
            tcSites.SelectedIndex = 2

            Select Case CurrentJob.JobTypeID
                Case Enums.JobTypes.Service
                    btnxx_Click(BtnxxService, New EventArgs)
                Case Enums.JobTypes.ServiceCertificate
                    btnxx_Click(BtnxxService, New EventArgs)
                    chkCert.Checked = True
                Case Enums.JobTypes.Breakdown
                    btnxx_Click(btnxxBreakdown, New EventArgs)
                Case Enums.JobTypes.Dayworks
                    btnxx_Click(btnxxSOR, New EventArgs)
                    pnlSOR.Visible = True
                    Combo.SetUpCombo(Me.cboSOR, DB.CustomerScheduleOfRate.GetAll_For_CustomerID(CurrentCustomer.CustomerID).Table, "CustomerScheduleOfRateID", "Description", Entity.Sys.Enums.ComboValues.Please_Select)
                    Dim al As ArrayList = DB.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(currentVisit.JobOfWorkID)

                    For Each a As Entity.JobItems.JobItem In al

                        Dim Sor As Entity.CustomerScheduleOfRates.CustomerScheduleOfRate = DB.CustomerScheduleOfRate.Get(a.RateID)
                        If Not Sor Is Nothing Then
                            SORDataView.AllowNew = True
                            Dim newrow As DataRowView = SORDataView.AddNew

                            newrow("SORID") = a.RateID
                            newrow("Code") = Sor.Code
                            newrow("Description") = Sor.Description
                            newrow("Qty") = a.Qty
                            newrow("TimeInMins") = Sor.TimeInMins
                            newrow("Price") = Sor.Price
                            newrow.EndEdit()
                            DGSOR.DataSource = SORDataView

                        End If

                    Next

                    If DGSOR.RowCount > 0 Then
                        btnxxJobNext.Visible = True
                        jobtype = "SOR"
                    Else
                        btnxxJobNext.Visible = False
                    End If

                Case Entity.Sys.Enums.JobTypes.Installation

                    btnxx_Click(btnxxOther, New EventArgs)
                    Combo.SetSelectedComboItem_By_Value(cbotypeWiz, CurrentJob.JobTypeID)

                    If Combo.GetSelectedItemValue(cbotypeWiz) < 1 Then
                        btnxxJobNext.Visible = False
                    Else
                        btnxxJobNext.Visible = True
                    End If

                    Dim al As ArrayList = DB.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(currentVisit.JobOfWorkID) ' for each JobOfWorks get the sors applied - SORS are attaached to JOWS not Visits directly.

                    For Each a As Entity.JobItems.JobItem In al

                        Dim Sor As Entity.CustomerScheduleOfRates.CustomerScheduleOfRate = DB.CustomerScheduleOfRate.Get(a.RateID)
                        If Not Sor Is Nothing Then
                            SORDataView.AllowNew = True
                            Dim newrow As DataRowView = SORDataView.AddNew

                            newrow("SORID") = a.RateID
                            newrow("Code") = Sor.Code
                            newrow("Description") = Sor.Description
                            newrow("Qty") = a.Qty
                            newrow("TimeInMins") = Sor.TimeInMins
                            newrow("Price") = Sor.Price
                            newrow.EndEdit()
                            DGSOR.DataSource = SORDataView

                        End If

                    Next

                Case Else
                    btnxx_Click(btnxxOther, New EventArgs)

                    cbotypeWiz.Visible = True
                    lbltype.Visible = True

                    If cboPriority.Items.Count > 1 Then
                        lblPriority.Visible = True
                        cboPriority.Visible = True
                    Else
                        lblPriority.Visible = False
                        cboPriority.Visible = False
                    End If

                    pnlSymptoms.Visible = True

                    lblAdditional.Visible = True
                    txtAdditional.Visible = True

                    lblcert.Visible = False
                    chkCert.Visible = False

                    pnlSOR.Visible = False

                    Combo.SetSelectedComboItem_By_Value(cbotypeWiz, CurrentJob.JobTypeID)

                    If Combo.GetSelectedItemValue(cbotypeWiz) < 1 Then
                        btnxxJobNext.Visible = False
                    Else
                        btnxxJobNext.Visible = True
                    End If

                    Dim al As ArrayList = DB.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(currentVisit.JobOfWorkID)

                    For Each a As Entity.JobItems.JobItem In al

                        Dim Sor As Entity.CustomerScheduleOfRates.CustomerScheduleOfRate = DB.CustomerScheduleOfRate.Get(a.RateID)
                        If Not Sor Is Nothing Then
                            SORDataView.AllowNew = True
                            Dim newrow As DataRowView = SORDataView.AddNew

                            newrow("SORID") = a.RateID
                            newrow("Code") = Sor.Code
                            newrow("Description") = Sor.Description
                            newrow("Qty") = a.Qty
                            newrow("TimeInMins") = Sor.TimeInMins
                            newrow("Price") = Sor.Price
                            newrow.EndEdit()
                            DGSOR.DataSource = SORDataView

                        End If

                    Next

            End Select

            Dim c As Control() = ParentForm.Controls.Find("btnSaveProg", True)
            Dim b As Button = c(0)
            b.Visible = True

            If tcSites.TabCount = 3 Then
                btnJobNext_Click(btnxxJobNext, New EventArgs)
            End If

            If DgMain.RowCount > 0 And tcSites.TabCount = 4 Then

                btnxxApplianceNext_Click(btnxxApplianceNext, New EventArgs)
                'tcSites.TabPages.Insert(4, tabJobDetails)
                'tab = tcSites.SelectedIndex + 1
                'tcSites.SelectedIndex = tcSites.SelectedIndex + 1

            End If

            Dim dv As New DataView
            Dim dt1 As New DataTable
            dt1.TableName = "1"
            dt1.Columns.Add("SypID")
            dt1.Columns.Add("Code")
            dt1.Columns.Add("Description")

            dv.Table = dt1
            SympDataView = dv
            DGSymptoms.DataSource = dt1

            If jobtype = "SERVICE" Then

                btnxxDetailsNext.Visible = True

            End If

            Dim JOW As Entity.JobOfWorks.JobOfWork = DB.JobOfWorks.JobOfWork_Get(currentVisit.JobOfWorkID)

            txtPONumber.Text = JOW.PONumber

            Combo.SetSelectedComboItem_By_Value(cboPriority, JOW.Priority)
            Dim Sympdt As DataTable = DB.EngineerVisits.GetSymptoms(currentVisit.EngineerVisitID)

            For Each dr As DataRow In Sympdt.Rows
                SympDataView.AllowNew = True
                Dim newrow As DataRowView = SympDataView.AddNew
                newrow("SypID") = dr("SymptomID")
                newrow("Code") = dr("Code")
                newrow("Description") = dr("Description")
                newrow.EndEdit()
                DGSymptoms.DataSource = SympDataView
            Next

            ValidateJobDetails()

            Dim c1 As Control() = ParentForm.Controls.Find("btnPrivateNotes", True)
            Dim b1 As Button = c1(0)
            b1.Visible = True

        End If

    End Sub

    Private Sub btnJobNext_Click(sender As Object, e As EventArgs) Handles btnxxJobNext.Click

        Dim c As Control() = ParentForm.Controls.Find("btnSaveProg", True)
        Dim b As Button = c(0)
        b.Visible = True

        pnlSymptoms.Visible = True

        rftBundle.AddRange({"KITCHENS", "BATHROOMS", "PLUMBING", "ELECTRICAL", "OTHER INTERNAL B AND M", "OTHER EXTERNAL B AND M", "MULTI TRADE", "BATHROOM FITTING", "BRICKLAYER", "BB"})

        If tcSites.TabCount = 3 Then
            tcSites.TabPages.Insert(3, tabAppliance)
            Combo.SetUpCombo(Me.cboMainApps, DB.Asset.Asset_GetForSite(SiteID).Table, "AssetID", "Product", Entity.Sys.Enums.ComboValues.Please_Select)
            If jobtype <> "SERVICE" Then
                cboMainApps.Items.Add(New Combo("Non Asset Related", 1))
            End If

            If IsGasway Then
                cboMainApps.Items.Add(New Combo("Boiler - Unknown", 2))
                cboMainApps.Items.Add(New Combo("Storage Boiler - Unknown", 3))
                cboMainApps.Items.Add(New Combo("Oil Boiler - Unknown", 4))
                cboMainApps.Items.Add(New Combo("Gas Fire - Unknown", 5))
                cboMainApps.Items.Add(New Combo("Unit Heater - Unknown", 6))

                cboMainApps.Items.Add(New Combo("Large Unit Heater - Unknown", 7))
                cboMainApps.Items.Add(New Combo("Water Heater - Unknown", 8))
                cboMainApps.Items.Add(New Combo("Unvented Cylinder - Unknown", 9))
                cboMainApps.Items.Add(New Combo("Cooker - Unknown", 10))
                cboMainApps.Items.Add(New Combo("Hob - Unknown", 11))
                cboMainApps.Items.Add(New Combo("Warm Air Unit - Unknown", 12))
                cboMainApps.Items.Add(New Combo("Air Source - Unknown", 13))
                cboMainApps.Items.Add(New Combo("Range Cooker - Unknown", 14))
                cboMainApps.Items.Add(New Combo("Solid Fuel - Unknown", 15))
            End If

            If btnxxNewJob.BackColor = System.Drawing.Color.PaleGreen Then

                MainDataView = DB.ContractOriginal.GetAssetsForContract(0, True) ' just to setup the grid

            End If

        End If

        If jobtype = "BREAKDOWN" Then
            TimeReqOption = False
            pnlTimeReq.Visible = False
            pnlTypeOfWorks.Visible = True
            cboTypeOfWorks.Items.Clear()
            Combo.SetUpCombo(Me.cboTypeOfWorks, DynamicDataTables.JobWizTypesOfWork, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

        ElseIf jobtype = "SERVICE" Then
            TimeReqOption = False
            pnlTimeReq.Visible = False
            pnlTypeOfWorks.Visible = True
            cboTypeOfWorks.Items.Clear()
            Combo.SetUpCombo(Me.cboTypeOfWorks, DynamicDataTables.JobWizServTypesOfWork, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

        ElseIf jobtype = "INSTALLATION" Or jobtype = "KITCHENS AND BATHROOMS" Or IsRFT Then

            TimeReqOption = True  ' use the days and hours options
            pnlTimeReq.Visible = True
            pnlTypeOfWorks.Visible = False
            cboTypeOfWorks.Items.Clear()
        Else
            TimeReqOption = False
            pnlTimeReq.Visible = False
            pnlTypeOfWorks.Visible = False
            cboTypeOfWorks.Items.Clear()

        End If

        tab = tcSites.SelectedIndex + 1
        tcSites.SelectedIndex = tcSites.SelectedIndex + 1

        If DgMain.RowCount > 0 Then

            btnxxApplianceNext.Visible = True
        Else
            btnxxApplianceNext.Visible = False

        End If

    End Sub

    Private Sub btnxxApplianceNext_Click(sender As Object, e As EventArgs) Handles btnxxApplianceNext.Click

        If tcSites.TabCount = 4 Then

            Dim dv As New DataView
            Dim dt1 As New DataTable
            dt1.TableName = "1"
            dt1.Columns.Add("SypID")
            dt1.Columns.Add("Code")
            dt1.Columns.Add("Description")

            dv.Table = dt1
            SympDataView = dv
            DGSymptoms.DataSource = dt1

            tcSites.TabPages.Insert(4, tabJobDetails)
        End If
        tab = tcSites.SelectedIndex + 1
        tcSites.SelectedIndex = tcSites.SelectedIndex + 1

        If DGSymptoms.RowCount > 0 And (cboPriority.Visible = False Or Combo.GetSelectedItemValue(cboPriority) > 0) Or ((jobtype <> "BREAKDOWN" And jobtype <> "SERVICE") Or Combo.GetSelectedItemValue(cboTypeOfWorks) > 0) Then

            If (CurrentSite.PoNumReqd And txtPONumber.Text.Length > 0) Or Not CurrentSite.PoNumReqd Then
                btnxxDetailsNext.Visible = True
            Else
                btnxxDetailsNext.Visible = True
            End If
        Else
            btnxxDetailsNext.Visible = False

        End If

        If jobtype = "SERVICE" Then

            lblPriority.Visible = False
            cboPriority.Visible = False
            pnlSymptoms.Visible = False
            btnxxDetailsNext.Visible = True
        Else
            'lblPriority.Visible = True
            'cboPriority.Visible = True
            'pnlSymptoms.Visible = True
            'btnxxDetailsNext.Visible = True
        End If

    End Sub

    Private Sub btnxxDetailsNext_Click(sender As Object, e As EventArgs) Handles btnxxDetailsNext.Click

        If CurrentSite.PoNumReqd AndAlso txtPONumber.Text.Length < 1 Then
            MsgBox("Please add a PO Reference", MsgBoxStyle.OkOnly, "Opps")
            Exit Sub
        End If

        Dim Assetsdt As New DataTable
        If Not SelecteddgvSitesDataRow.Cells("ContractID").Value Is DBNull.Value Then
            Dim dt As DataTable = DB.ContractOriginalSite.GetAll_ContractID2(SelecteddgvSitesDataRow.Cells("ContractID").Value, CurrentSite.CustomerID).Table
            Assetsdt = DB.ContractOriginalPPMVisit.GetAllAssets_For_ContractSiteID(dt.Rows(0)("ContractSiteID")).Table
        End If
        lblCoverplanServ.Text = ""
        If CurrentSite.LastServiceDate.AddMonths(10) < Today Then ' is it 10 months or more old
            lblCoverplanServ.Visible = True
            lblCoverplanServ.Text = "This Sites service visit is due soon, please book." & vbNewLine
            lblCoverplanServ.Visible = True
        ElseIf CurrentSite.LastServiceDate.AddMonths(12) < Today And CurrentCustomer.CustomerTypeID = 516 Then
            lblCoverplanServ.Text = "This Sites service visit is overdue and must be booked now." & vbNewLine
        Else
            lblCoverplanServ.Visible = False
        End If

        If Assetsdt.Rows.Count > 0 Then
            lblCoverplanServ.Visible = True
            lblCoverplanServ.Text += "This Site Has A Coverplan Service Outstanding - Due Before " & CurrentSite.LastServiceDate.AddMonths(12)
        Else
            lblCoverplanServ.Visible = False
        End If

        Dim dv As New DataView
        Dim dt1 As New DataTable
        dt1.TableName = "2"
        dt1.Columns.Add("ID")
        dt1.Columns.Add("AssetID")
        dt1.Columns.Add("Description")
        dt1.Columns.Add("Product")
        dt1.Columns.Add("Cert")

        dv.Table = dt1
        DGVAdditional = dv
        DGAdditional.DataSource = dt1

        btnxxAdditionalNext.Visible = True

        If IsRFT Then

            If tcSites.TabCount = 5 Then
                tcSites.TabPages.Insert(5, TabCharging)
            End If
            tab = tcSites.SelectedIndex + 1
            tcSites.SelectedIndex = tcSites.SelectedIndex + 1

            DoCharging()
            AdditionalCharging()

            Combo.SetSelectedComboItem_By_Value(cboPayTerms, 2)
            btnxxChargeNext_Click(btnxxChargeNext, New EventArgs)
        Else

            If tcSites.TabCount = 5 Then
                tcSites.TabPages.Insert(5, tabAdditional)
            End If
            tab = tcSites.SelectedIndex + 1
            tcSites.SelectedIndex = tcSites.SelectedIndex + 1

        End If

        'DoCharging()
        'AdditionalCharging()

    End Sub

    Private Sub btnxxAdditionalNext_Click(sender As Object, e As EventArgs) Handles btnxxAdditionalNext.Click

        If Combo.GetSelectedItemValue(cboPayTerms) < 1 Then
            btnxxChargeNext.Visible = False
        Else
            btnxxChargeNext.Visible = True
        End If

        If tcSites.TabCount = 6 Then
            tcSites.TabPages.Insert(6, TabCharging)
        End If
        tab = tcSites.SelectedIndex + 1
        tcSites.SelectedIndex = tcSites.SelectedIndex + 1

        DoCharging()
        AdditionalCharging()
        FinalCharge = CDbl(txtCharge.Text)
        FinalText = txtPayInst.Text
        txtCharge.Text = Format(CDbl(txtCharge.Text), "C")

        CheckDiscount()

    End Sub

    Private Sub btnxxChargeNext_Click(sender As Object, e As EventArgs) Handles btnxxChargeNext.Click
        'If IsRFT Then
        '    If tcSites.TabCount = 6 Then
        '        tcSites.TabPages.Insert(6, TabBook)
        '    End If
        '    tab = tcSites.SelectedIndex + 1
        '    tcSites.SelectedIndex = tcSites.SelectedIndex + 1
        'Else
        '    If tcSites.TabCount = 7 Then
        '        tcSites.TabPages.Insert(7, TabBook)
        '    End If
        '    tab = tcSites.SelectedIndex + 1
        '    tcSites.SelectedIndex = tcSites.SelectedIndex + 1
        'End If

        ' CreateVisits()

        'FindAppointments()
        SaveProgress()

    End Sub

#End Region

#Region "Additional"

    Private Sub btnAdditionalPlus_Click(sender As Object, e As EventArgs) Handles btnAdditionalPlus.Click

        If Combo.GetSelectedItemValue(cboAdditional) > 0 Then

            Dim ResultAsset As Integer
            Dim ResultProduct As String
            Dim ResultCert As Boolean
            If Combo.GetSelectedItemValue(cboAdditional) = 1 Then  ' 1 = service also

                Dim dialogue As FRMSelectAsset

                dialogue = checkIfExists(GetType(FRMSelectAsset).Name, True)
                If dialogue Is Nothing Then
                    dialogue = Activator.CreateInstance(GetType(FRMSelectAsset))
                End If
                '   dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
                dialogue.ShowInTaskbar = False
                dialogue.SiteID = CurrentSite.SiteID
                dialogue.ShowDialog()

                If dialogue.DialogResult = DialogResult.OK Then
                    '    newRow.Item("AssetID") = dialogue.SelectedAssetDataRow.Item("AssetID")
                    ResultAsset = dialogue.SelectedAssetDataRow.Item("AssetID")
                    ResultProduct = dialogue.SelectedAssetDataRow.Item("Product")
                    ResultCert = dialogue.chkCERT2.Checked
                End If

                dialogue.Close()

            End If

            chkCert.Visible = True
            chkCert.Checked = True
            lblcert.Visible = True

            DGVAdditional.AllowNew = True
            Dim newrow As DataRowView = DGVAdditional.AddNew

            newrow("ID") = Combo.GetSelectedItemValue(cboAdditional)
            newrow("description") = Combo.GetSelectedItemDescription(cboAdditional) & " - " & ResultProduct.Split("-")(0)
            newrow("AssetID") = ResultAsset
            newrow("Product") = ResultProduct
            newrow("Cert") = ResultCert
            newrow.EndEdit()

            DGAdditional.DataSource = DGVAdditional

        End If

    End Sub

    Private Sub btnAdditionalMinus_Click(sender As Object, e As EventArgs) Handles btnAdditionalMinus.Click

        If Not DGAdditional.CurrentRow Is Nothing Then

            DGVAdditional.AllowDelete = True
            DGVAdditional.Table.Rows.RemoveAt(DGAdditional.CurrentRow.Index)

        End If

    End Sub

#End Region

#Region "Charging"

    Private Sub chkRecall_CheckedChanged(sender As Object, e As EventArgs) Handles chkRecall.CheckedChanged
        Manualrecall = True
    End Sub

    Sub DoCharging()
        Dim defaultTerm As Integer = 0
        visitcharge1 = 0
        visitterm1 = ""
        Select Case CurrentCustomer.Terms

            Case Enums.Terms.POC
                defaultTerm = 3
            Case Enums.Terms.OTI30Days, Enums.Terms.OTI7Days, Enums.Terms.OTIByReturn
                defaultTerm = 2
            Case Else
                defaultTerm = 3

        End Select

        SpecialTrade = ""
        time = 0
        LPGNEEDED = False
        OILNEEDED = False
        NATNEEDED = False
        HETASNEEDED = False
        ASNEEDED = False
        WAUNEEDED = False
        COMMNEEDED = False

        UseContractVisit = False

        txtPayInst.Text = vbNewLine
        txtCharge.Text = "£0.00"
        ''customer type
        Dim c As Entity.Customers.Customer = DB.Customer.Customer_Get(CurrentSite.CustomerID)

        Select Case jobtype

            Case "BREAKDOWN"

                txtPayInst.Text += "Breakdown job applied" + vbNewLine
                '' check if recall likely
                Dim gassupplyissue As Boolean = False
                Dim quoterate As String = DB.Picklists.Get_One_As_Object(Enums.JobItemPrice.BDOWN).Description

                Select Case Combo.GetSelectedItemValue(cboTypeOfWorks)

                    Case 2
                        SpecialTrade = "COMM"
                        quoterate = DB.Picklists.Get_One_As_Object(Enums.JobItemPrice.COMM).Description
                    Case 3
                        SpecialTrade = "PLUM"
                        quoterate = DB.Picklists.Get_One_As_Object(Enums.JobItemPrice.PLUM).Description
                    Case 4
                        SpecialTrade = "ELEC"
                        quoterate = DB.Picklists.Get_One_As_Object(Enums.JobItemPrice.ELEC).Description
                    Case 5
                        SpecialTrade = "BANDM"
                        quoterate = DB.Picklists.Get_One_As_Object(Enums.JobItemPrice.BANDM).Description
                    Case Else

                        For Each dr As DataRowView In SympDataView
                            If dr("SypID") = 69783 Then
                                SpecialTrade = "PLUM"
                                quoterate = DB.Picklists.Get_One_As_Object(Enums.JobItemPrice.PLUM).Description
                            End If

                            If dr("SypID") = 69784 Then
                                SpecialTrade = "ELEC"
                                quoterate = DB.Picklists.Get_One_As_Object(Enums.JobItemPrice.ELEC).Description

                            End If

                            If dr("SypID") = 69785 Then
                                SpecialTrade = "BANDM"
                                quoterate = DB.Picklists.Get_One_As_Object(Enums.JobItemPrice.BANDM).Description
                            End If

                        Next

                End Select

                Dim ss As Boolean = False

                Dim sys As Boolean = False

                For Each dgv As DataRowView In SympDataView
                    If dgv("SypID") = 69790 Or dgv("SypID") = 69791 Then ' gas
                        ss = True
                    End If
                    If dgv("SypID") = 69663 Or dgv("SypID") = 69664 Or dgv("SypID") = 69668 Then
                        sys = True
                    End If

                Next

                Dim recall As Boolean = False
                Dim PosRecall As Boolean = False
                If Not Manualrecall Then
                    Dim dt As DataTable = DB.EngineerVisits.GetLastVisit(CurrentSite.SiteID)
                    Dim PrevSymptoms As New DataTable
                    If dt.Rows.Count > 0 Then
                        PrevSymptoms = DB.EngineerVisits.GetSymptoms(dt.Rows(0)("Engineervisitid"))
                    End If

                    '' catch a pos recall

                    For Each dvr As DataRowView In SympDataView

                        If dvr("Code") = "RECALL " Then

                            PosRecall = True
                            Exit For

                        End If

                    Next

                    If dt.Rows.Count > 0 Then
                        If PrevSymptoms.Rows.Count = 0 Then

                            If dt.Rows.Count > 0 AndAlso (Not IsDBNull(dt.Rows(0)("StartdateTime"))) AndAlso CDate(dt.Rows(0)("StartdateTime")).AddDays(28) < DateTime.Today And PosRecall Then
                                recall = True
                                RecallJobTypeID = dt.Rows(0)("JobTypeID")
                                RecallJobID = dt.Rows(0)("JobID")
                            End If
                        Else

                            If (Not IsDBNull(dt.Rows(0)("StartdateTime"))) AndAlso CDate(dt.Rows(0)("StartdateTime")).AddDays(28) < DateTime.Today And jobtype = "BREAKDOWN" Then

                                For Each dd As DataRow In PrevSymptoms.Rows

                                    For Each dvr As DataRowView In SympDataView

                                        If dvr("SypID") = dd("SymptomID") Then

                                            If dvr("SypID") <> 69668 Then
                                                recall = True
                                                RecallJobTypeID = dt.Rows(0)("JobTypeID")
                                                RecallJobID = dt.Rows(0)("JobID")
                                                Exit For
                                            End If

                                        End If

                                    Next

                                    If recall Then Exit For

                                Next

                                If recall = False Then
                                    txtPayInst.Text += "A visit has been carried out within 28 days but as the symptoms have changed, it is suggested this is an new fault" + vbNewLine
                                End If

                            End If

                        End If

                    End If

                    chkRecall.Checked = recall
                Else
                    recall = chkRecall.Checked
                End If

                If recall Then

                    txtPayInst.Text += "This visit has been marked as a recall no charge will be applied" & vbNewLine
                    Combo.SetSelectedComboItem_By_Value(cboPayTerms, 4)
                    txtCharge.Text = "£0.00"
                Else

                    If PosRecall = True Then

                        txtPayInst.Text += "This visit has been marked as a recall no charge will be applied" & vbNewLine

                    End If

                    Select Case c.CustomerTypeID

                        Case Entity.Sys.Enums.CustomerType.SocialHousing
                            time = 45
                            'housing
                            txtPayInst.Text += "Social Housing or Council works are not chargeable" & vbNewLine
                            Combo.SetSelectedComboItem_By_Value(cboPayTerms, 4)
                            txtCharge.Text = "£0.00"

                        Case Entity.Sys.Enums.CustomerType.Insurance
                            time = 45
                            'Insurance
                            txtPayInst.Text += "Insurance Works are OTI" & vbNewLine
                            Combo.SetSelectedComboItem_By_Value(cboPayTerms, 2)
                            txtCharge.Text = "£0.00"

                        Case Else

                            time = 45

                            Dim IsContract = False

                            If Not IsDBNull(SelecteddgvSitesDataRow.Cells("ContractID").Value) Then
                                CurrentContract = New Entity.ContractsOriginal.ContractOriginal
                                CurrentContract = DB.ContractOriginal.Get(SelecteddgvSitesDataRow.Cells("ContractID").Value)
                            End If
                            'others

                            If Not CurrentContract Is Nothing Then

                                IsContract = True
                                Dim drt As DataRow
                                Dim dt As New DataTable

                                'Dim contractSite As Entity.QuoteContractOriginalSites.QuoteContractOriginalSite
                                If Not IsDBNull(SelecteddgvSitesDataRow.Cells("ContractID").Value) Then
                                    CurrentContract = DB.ContractOriginal.Get(SelecteddgvSitesDataRow.Cells("ContractID").Value)
                                    dt = DB.ContractOriginalSite.GetAll_ContractID2(SelecteddgvSitesDataRow.Cells("ContractID").Value, CurrentSite.CustomerID).Table

                                    drt = dt.Select("tick = 1")(0)
                                End If

                                Combo.SetSelectedComboItem_By_Value(cboPayTerms, 1)
                                txtPayInst.Text += "Works charges would normally be covered by Contract" + vbNewLine
                                txtCharge.Text = "£0.00"

                                If ss And Not CurrentContract.GasSupplyPipework Then
                                    If MsgBox("Symptoms Indicate a gas leak has been suggested. Is this leak / smell located near / on the covered appliance", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                        txtPayInst.Text += "Gas leak works not covered by any contract extras" + vbNewLine
                                        gassupplyissue = True
                                        txtCharge.Text = "£" & quoterate
                                        GasConfirmedInBoiler = False
                                        Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)
                                    End If
                                End If

                                If sys And (CurrentContract.ContractTypeID <> 68032 And CurrentContract.ContractTypeID <> 69767 And CurrentContract.ContractTypeID <> 369) Then
                                    txtPayInst.Text += "This Coverplan does not cover system issues" + vbNewLine

                                    txtCharge.Text = "£" & quoterate

                                    Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)
                                End If

                                'here

                                If SpecialTrade <> "" AndAlso ((SpecialTrade = "PLUM" And Not CurrentContract.PlumbingDrainage) Or (SpecialTrade = "ELEC" And Not CurrentContract.PlumbingDrainage) Or (SpecialTrade = "BANDM" And Not CurrentContract.WindowLockPest)) Then
                                    Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)
                                    txtCharge.Text = "£" & quoterate
                                    txtPayInst.Text += "Works not covered by any contract extras" + vbNewLine
                                End If

                                ''' go through cover apps work out if anything to pay.
                                Dim Assetsdt As New DataTable

                                Assetsdt = DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(drt("ContractSiteID"), CurrentSite.SiteID).Table

                                Dim mainapps As Integer = 0
                                Dim Secondryapps As Integer = 0

                                If dt.Rows.Count > 0 Then ' dt is from above its contractoriginalsite table
                                    mainapps = dt.Rows(0)("MainAppliances")
                                    Secondryapps = dt.Rows(0)("SecondryAppliances")
                                End If

                                Dim pri As Integer = 0
                                Dim Sec As Integer = 0

                                If Assetsdt.Rows.Count > 0 AndAlso Not IsDBNull(Assetsdt.Rows(0)("AssetID")) Then
                                    ' we got accosiated apps
                                    For Each dr As DataRow In Assetsdt.Rows
                                        For Each dr1 As DataGridViewRow In DgMain.Rows
                                            If dr1.Cells("AssetID").Value = dr("AssetID") Then
                                                CoverApps.Add(dr("AssetID"))
                                                If CheckMainApps(dr1.Cells("Product").Value.ToString.Split("-")(0)) Then
                                                    ' main apps
                                                    pri = pri + 1
                                                Else
                                                    Sec = Sec + 1
                                                End If

                                                If pri + Sec >= DgMain.Rows.Count Then Exit For
                                            End If
                                        Next
                                        If pri + Sec >= DgMain.Rows.Count Then Exit For
                                    Next
                                End If
                                'may or may not have all the appliances listed by user

                                If pri + Sec < DgMain.Rows.Count Then ' user has hinted there may be another app under cover

                                    If pri < mainapps Then
                                        'missing a main appliance which should be under cover
                                        For Each dr1 As DataGridViewRow In DgMain.Rows
                                            If CoverApps.Contains(dr1.Cells("AssetID").Value) Then Continue For
                                            If CheckMainApps(dr1.Cells("Product").Value.ToString.Split("-")(0)) Then
                                                CoverApps.Add(dr1.Cells("AssetID").Value) ' main app added to list
                                                pri = pri + 1
                                                If pri >= mainapps Then Exit For ' all main apps found
                                            End If
                                        Next

                                    End If
                                End If

                                If pri + Sec < DgMain.Rows.Count Then ' still havent hit the total so .. check on secondrys

                                    If Sec < Secondryapps Then
                                        'missing a secondry appliance which should be covered
                                        For Each dr1 As DataGridViewRow In DgMain.Rows
                                            If CoverApps.Contains(dr1.Cells("AssetID").Value) Then Continue For
                                            If Not CheckMainApps(dr1.Cells("Product").Value.ToString.Split("-")(0)) Then
                                                CoverApps.Add(dr1.Cells("AssetID").Value) 'sec app added to list
                                                Sec = Sec + 1
                                                If Sec >= Secondryapps Then Exit For ' all sec apps found
                                            End If

                                        Next

                                    End If

                                End If

                                '''Anything left over will be chargeable?
                                Dim excontcount As Integer = 0

                                For Each dr2 As DataGridViewRow In DgMain.Rows
                                    If CoverApps.Contains(dr2.Cells("AssetID").Value) Then Continue For

                                    '''''TODO
                                    txtPayInst.Text += "Additional Appliances listed to that which are covered in plan or non appliance related , A callout Charge Has been Applied" + vbNewLine
                                    Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)
                                    txtPayInst.Text += "Breakdown Charge Applied" + vbNewLine
                                    txtCharge.Text = "£" & quoterate ' breakdown

                                Next
                                For Each dr1 As DataGridViewRow In DgMain.Rows
                                    If CoverApps.Contains(dr1.Cells("AssetID").Value) Then Continue For

                                Next
                            Else

                                Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)
                                txtPayInst.Text += "Breakdown Charge Applied" + vbNewLine
                                txtCharge.Text = "£" & quoterate ' breakdown

                            End If

                            Dim userissue As Boolean = False
                            For Each dr As DataRowView In SympDataView
                                If dr("Code") = "USER " Or dr("Code") = "NOISE " Then
                                    userissue = True
                                    If Not CurrentContract Is Nothing Then
                                        Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)
                                        txtPayInst.Text += "Symptoms selected indicate this visit should be chargeable."
                                        txtCharge.Text = "£" & quoterate ' breakdown current rate
                                    End If
                                    Exit For

                                End If
                            Next

                            '   If userissue and
                    End Select

                End If

            Case "SERVICE"

                txtPayInst.Text += "Service job Applied" + vbNewLine

                Select Case c.CustomerTypeID
                    Case Entity.Sys.Enums.CustomerType.SocialHousing

                        time = 45
                        'housing
                        txtPayInst.Text += "Social Housing or Council Service works are not chargeable" & vbNewLine
                        Combo.SetSelectedComboItem_By_Value(cboPayTerms, 4)
                        txtCharge.Text = "£0.00"

                    Case Entity.Sys.Enums.CustomerType.Insurance
                        time = 45
                        'Insurance
                        txtPayInst.Text += "Insurance Works are OTI" & vbNewLine
                        Combo.SetSelectedComboItem_By_Value(cboPayTerms, 2)
                        txtCharge.Text = "£0.00"

                    Case Else

                        Dim dt As New DataTable
                        Dim drt As DataRow
                        Dim IsContract = False

                        Dim contractSite As Entity.QuoteContractOriginalSites.QuoteContractOriginalSite
                        If Not IsDBNull(SelecteddgvSitesDataRow.Cells("ContractID").Value) Then
                            CurrentContract = DB.ContractOriginal.Get(SelecteddgvSitesDataRow.Cells("ContractID").Value)
                            dt = DB.ContractOriginalSite.GetAll_ContractID2(SelecteddgvSitesDataRow.Cells("ContractID").Value, CurrentSite.CustomerID).Table

                            drt = dt.Select("tick = 1")(0)
                        End If
                        'others
                        CoverApps = New List(Of Integer)
                        ChargeApps = New List(Of Integer)
                        If Not CurrentContract Is Nothing Then

                            IsContract = True
                            Combo.SetSelectedComboItem_By_Value(cboPayTerms, 1)
                            txtPayInst.Text += "Works charges would normally be covered by Contract" + vbNewLine
                            txtCharge.Text = "£0.00"

                            ''' go through cover apps work out if anything to pay.
                            Dim Assetsdt As New DataTable

                            Assetsdt = DB.ContractOriginalPPMVisit.GetAllAssets_For_ContractSiteID(drt("ContractSiteID")).Table

                            Dim mainapps As Integer = 0
                            Dim Secondryapps As Integer = 0

                            If dt.Rows.Count > 0 Then ' dt is from above its contractoriginalsite table
                                mainapps = dt.Rows(0)("MainAppliances")
                                Secondryapps = dt.Rows(0)("SecondryAppliances")
                            End If

                            Dim pri As Integer = 0
                            Dim Sec As Integer = 0

                            If Assetsdt.Rows.Count = 0 Then

                                Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)
                                txtPayInst.Text += "Any Service Visits Have already been completed for this Contract Period" + vbNewLine
                                txtCharge.Text = "£0.00"
                            Else
                                UseContractVisit = True

                                If Not IsDBNull(Assetsdt.Rows(0)("AssetID")) Then
                                    ' we got accosiated apps
                                    For Each dr As DataRow In Assetsdt.Rows
                                        For Each dr1 As DataGridViewRow In DgMain.Rows
                                            If dr1.Cells("AssetID").Value = dr("AssetID") Then
                                                CoverApps.Add(dr("AssetID"))
                                                If CheckMainApps(dr1.Cells("Product").Value.ToString.Split("-")(0)) Then
                                                    ' main apps
                                                    time += servTime
                                                    pri = pri + 1
                                                Else
                                                    time += servTime
                                                    Sec = Sec + 1
                                                End If

                                                If pri + Sec >= DgMain.Rows.Count Then Exit For
                                            End If
                                        Next
                                        If pri + Sec >= DgMain.Rows.Count Then Exit For
                                    Next
                                End If
                                'may or may not have all the appliances listed by user

                                If pri + Sec < DgMain.Rows.Count Then ' user has hinted there may be another app under cover

                                    If pri < mainapps Then
                                        'missing a main appliance which should be under cover
                                        For Each dr1 As DataGridViewRow In DgMain.Rows
                                            If CoverApps.Contains(dr1.Cells("AssetID").Value) Then Continue For
                                            If CheckMainApps(dr1.Cells("Product").Value.ToString.Split("-")(0)) Then

                                                time += servTime

                                                CoverApps.Add(dr1.Cells("AssetID").Value) ' main app added to list
                                                pri = pri + 1
                                                If pri >= mainapps Then Exit For ' all main apps found
                                            End If
                                        Next

                                    End If
                                End If

                                If pri + Sec < DgMain.Rows.Count Then ' still havent hit the total so .. check on secondrys

                                    If Sec < Secondryapps Then
                                        'missing a secondry appliance which should be covered
                                        For Each dr1 As DataGridViewRow In DgMain.Rows
                                            If CoverApps.Contains(dr1.Cells("AssetID").Value) Then Continue For
                                            If Not CheckMainApps(dr1.Cells("Product").Value.ToString.Split("-")(0)) Then
                                                CoverApps.Add(dr1.Cells("AssetID").Value) 'sec app added to list
                                                Sec = Sec + 1

                                                time += servTime

                                                If Sec >= Secondryapps Then Exit For ' all sec apps found
                                            End If

                                        Next

                                    End If

                                End If

                                '''Anything left over will be chargeable?
                                Dim excontcount As Integer = 0

                                Dim HighService As Double = 0
                                For Each dr2 As DataGridViewRow In DgMain.Rows   ''' NEW Pricing bit ''''
                                    If CoverApps.Contains(dr2.Cells("AssetID").Value) Then Continue For

                                    ' bit for adding more time
                                    CheckMainApps(dr2.Cells("Product").Value.ToString.Split("-")(0))
                                    time += servTime

                                    If CDbl(Pricing(dr2.Cells("Product").Value.ToString.Split("-")(0))) > HighService Then
                                        HighService = CDbl(Pricing(dr2.Cells("Product").Value.ToString.Split("-")(0)))
                                    End If
                                Next
                                For Each dr1 As DataGridViewRow In DgMain.Rows
                                    If CoverApps.Contains(dr1.Cells("AssetID").Value) Then Continue For
                                    '' start charging
                                    ChargeApps.Add(dr1.Cells("AssetID").Value)
                                    excontcount += 1
                                    Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)

                                    '''''''''''''''''''''''''''''''''''''''''''''''''''NEW PRICING''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                    If CoverApps.Count + excontcount > 1 Then
                                        txtCharge.Text = "£" & CDbl(CDbl(txtCharge.Text) + CDbl(DB.Picklists.Get_Single_Description("ADDAPP", 71)))
                                    Else
                                        txtCharge.Text = "£" & CDbl(CDbl(txtCharge.Text) + CDbl(HighService))
                                    End If

                                    txtPayInst.Text += dr1.Cells("Product").Value.ToString.Split("-")(0) & " Service Not covered under contract." + vbNewLine
                                Next

                                '   If excontcount > 2 Then txtCharge.Text = CDbl(txtCharge.Text) * 0.9
                            End If
                        Else ' non coverplan
                            Dim excontcount As Integer = 0
                            Dim HighService As Double = 0
                            For Each dr2 As DataGridViewRow In DgMain.Rows   ''' NEW Pricing bit ''''
                                If CDbl(Pricing(dr2.Cells("Product").Value.ToString.Split("-")(0))) > HighService Then
                                    HighService = CDbl(Pricing(dr2.Cells("Product").Value.ToString.Split("-")(0)))
                                End If
                            Next
                            For Each dr1 As DataGridViewRow In DgMain.Rows

                                ''

                                '' start charging
                                ChargeApps.Add(dr1.Cells("AssetID").Value)
                                excontcount += 1
                                CheckMainApps(dr1.Cells("Product").Value.ToString.Split("-")(0))
                                time += servTime

                                Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)

                                '''''''''''''''''''''''''''''''''''''''''''NEW PRICING''''''''''''''''''''''''''''''''''''
                                If excontcount > 1 Then
                                    txtCharge.Text = "£" & CDbl(CDbl(txtCharge.Text) + CDbl(DB.Picklists.Get_Single_Description("ADDAPP", 71)))
                                Else
                                    txtCharge.Text = "£" & CDbl(HighService)
                                End If

                            Next

                        End If

                End Select

                If OILNEEDED Then
                    MsgBox("Please explain to the customer that the Oil boiler will need to be turned off the previous evening in order it cool for the service", MsgBoxStyle.OkOnly, "Advice")
                End If

            Case "SOR"
                ' SOR BASED Call
                Dim cost As Double = 0
                For Each dr As DataGridViewRow In DGSOR.Rows

                    time += dr.Cells("TimeInMins").Value
                    cost += dr.Cells("Price").Value

                Next

                Select Case c.CustomerTypeID

                    Case Enums.CustomerType.SocialHousing
                        txtPayInst.Text += "SOR Works not chargeable upfront" + vbNewLine
                        '    Combo.SetSelectedComboItem_By_Value(cboPayTerms, 4)
                    Case Else
                        txtPayInst.Text += "SOR Works charges Applied" + vbNewLine
                        txtCharge.Text = "£" & CDbl(CDbl(txtCharge.Text) + CDbl(cost))

                End Select

            Case Else

                If TimeReqOption Then
                    If IsNumeric(txtDays.Text) AndAlso CInt(txtDays.Text) > 0 Then
                        time = 200
                    ElseIf IsNumeric(txtHrs.Text) Then
                        time = CDbl(txtHrs.Text)

                    End If
                End If

                If time = 0 Then time = 60
                txtPayInst.Text += "Unknown costs, please manually complete" + vbNewLine

        End Select

        For Each dr As DataGridViewRow In DgMain.Rows

            CheckMainApps(dr.Cells("Product").Value.ToString.Split("-")(0))  ' just to check the engineer in a mo
        Next

        If c.CustomerTypeID = Enums.CustomerType.Agency Then
            Combo.SetSelectedComboItem_By_Value(cboPayTerms, 2)
        End If

        If time > 200 Then time = 200 'TODO - the most the SP can handle at this time without rewrite - also need to check into next days (BIG)
        priTime = time

        visitcharge1 = CDbl(txtCharge.Text)
        visitterm1 = Combo.GetSelectedItemDescription(cboPayTerms)

    End Sub

    Sub AdditionalCharging()
        visitcharge2 = 0
        visitterm2 = ""
        time = 0

        Dim defaultTerm As Integer = 0
        Select Case CurrentCustomer.Terms

            Case Enums.Terms.POC
                defaultTerm = 3
            Case Enums.Terms.OTI30Days, Enums.Terms.OTI7Days, Enums.Terms.OTIByReturn
                defaultTerm = 2
            Case Else
                defaultTerm = 3

        End Select

        txtPayInst.Text += vbNewLine
        ''customer type
        Dim c As Entity.Customers.Customer = DB.Customer.Customer_Get(CurrentSite.CustomerID)

        Dim CoverApps As New List(Of Integer)
        Dim pri As Integer = 0
        Dim Sec As Integer = 0
        Dim serviceCharge As Double = 0
        Dim BreakdownCharge As Double = 0

        If DGAdditional.Rows.Count > 0 Then
            For Each dgr As DataRowView In DGVAdditional

                Select Case dgr("ID")
                    Case "1" 'service

                        DGVAdditional.RowFilter = "ID=1"
                        serviceCharge = 0
                        Select Case c.CustomerTypeID
                            Case Enums.CustomerType.SocialHousing

                                time = 40  'hack for now // 'todo
                                'housing

                            Case Else

                                Dim dt As New DataTable
                                Dim drt As DataRow
                                Dim Contract As Entity.ContractsOriginal.ContractOriginal
                                Dim contractSite As Entity.QuoteContractOriginalSites.QuoteContractOriginalSite
                                If Not IsDBNull(SelecteddgvSitesDataRow.Cells("ContractID").Value) Then
                                    Contract = DB.ContractOriginal.Get(SelecteddgvSitesDataRow.Cells("ContractID").Value)
                                    dt = DB.ContractOriginalSite.GetAll_ContractID2(SelecteddgvSitesDataRow.Cells("ContractID").Value, CurrentSite.CustomerID).Table

                                    drt = dt.Select("tick = 1")(0)
                                End If
                                'others

                                If Contract IsNot Nothing Then
                                    Combo.SetSelectedComboItem_By_Value(cboPayTerms, 1)
                                    txtPayInst.Text += "Service charges would normally be covered by Contract" + vbNewLine
                                    ''' go through cover apps work out if anything to pay.
                                    Dim Assetsdt As New DataTable

                                    Assetsdt = DB.ContractOriginalPPMVisit.GetAllAssets_For_ContractSiteID(drt("ContractSiteID")).Table

                                    If Assetsdt.Rows.Count = 0 Then
                                        txtPayInst.Text += "Any Service Visits Have already been completed for this Contract Period servicing will be chargeable" + vbNewLine
                                    Else
                                        Dim mainapps As Integer = Assetsdt.Rows(0)("MainAppliances")
                                        Dim Secondryapps As Integer = Assetsdt.Rows(0)("SecondryAppliances")
                                        UseContractVisit = True

                                        If Not IsDBNull(Assetsdt.Rows(0)("AssetID")) Then
                                            ' we got accosiated apps
                                            For Each dr As DataRow In Assetsdt.Rows
                                                For Each dr1 As DataRowView In DGVAdditional
                                                    If dr1("AssetID") = dr("AssetID") Then
                                                        CoverApps.Add(dr("AssetID"))
                                                        If CheckMainApps(dr1("Product").ToString.Split("-")(0)) Then
                                                            ' main apps
                                                            time += servTime
                                                            pri = pri + 1
                                                        Else
                                                            time += servTime
                                                            Sec = Sec + 1
                                                        End If

                                                        If pri + Sec >= DgMain.Rows.Count Then Exit For
                                                    End If
                                                Next
                                                If pri + Sec >= DgMain.Rows.Count Then Exit For
                                            Next
                                        End If
                                        'may not have all the appliances listed by user

                                        If pri < mainapps Then
                                            'missing a main appliance which should be under cover

                                            If CoverApps.Contains(dgr("AssetID")) Then Continue For
                                            If CheckMainApps(dgr("Product").ToString.Split("-")(0), True) Then
                                                CoverApps.Add(dgr("AssetID")) ' main app added to list
                                                pri = pri + 1
                                                time += servTime
                                            End If

                                        End If

                                        If Sec < Secondryapps Then
                                            'missing a secondry appliance which should be covered

                                            If CoverApps.Contains(dgr("AssetID")) Then Continue For
                                            If Not CheckMainApps(dgr("Product").ToString.Split("-")(0), True) Then
                                                CoverApps.Add(dgr("AssetID")) 'sec app added to list
                                                Sec = Sec + 1
                                                time += servTime
                                                If Sec >= Secondryapps Then Exit For ' all sec apps found
                                            End If

                                        End If

                                        '''Anything left over will be chargeable?
                                        Dim excontcount As Integer = 0

                                        Dim HighService As Double = 0
                                        For Each dr2 As DataRowView In DGVAdditional  ''' NEW Pricing bit ''''
                                            If CoverApps.Contains(dr2("AssetID")) Then Continue For
                                            If CDbl(Pricing(dr2("Product").ToString.Split("-")(0))) > HighService Then
                                                HighService = CDbl(Pricing(dr2("Product").ToString.Split("-")(0)))
                                            End If
                                        Next
                                        For Each dr1 As DataRowView In DGVAdditional
                                            If CoverApps.Contains(dr1("AssetID")) Then Continue For
                                            '' start charging
                                            ChargeApps.Add(dr1("AssetID"))
                                            excontcount += 1
                                            Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)

                                            CheckMainApps(dr1("Product").ToString.Split("-")(0))
                                            time += servTime

                                            '''''''''''''''''''''''''''''''''''''''''''''''''''NEW PRICING''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                            If CoverApps.Count + excontcount > 1 Then
                                                serviceCharge = serviceCharge + CDbl(DB.Picklists.Get_Single_Description("ADDAPP", 71))
                                            Else
                                                serviceCharge = serviceCharge + CDbl(DB.Picklists.Get_Single_Description("BDOWNPLUS", 71))
                                            End If

                                            txtPayInst.Text += dr1("Product").ToString.Split("-")(0) & " Service Not covered under contract." + vbNewLine

                                        Next
                                        If Me.chkCert.Checked = True AndAlso DGVAdditional.Count > 0 Then
                                            txtPayInst.Text += " LandLord Certificate covered under coverplan" + vbNewLine
                                        End If
                                    End If
                                Else
                                    Combo.SetSelectedComboItem_By_Value(cboPayTerms, defaultTerm)

                                    Dim highestPrice As Double = 0
                                    Dim tempPrice As Double
                                    For Each item As DataRowView In DGVAdditional
                                        tempPrice = Helper.MakeDoubleValid(Pricing(item("Product").ToString.Split("-")(0)))
                                        If tempPrice > highestPrice Then
                                            highestPrice = tempPrice
                                        End If
                                        time += servTime

                                    Next

                                    serviceCharge += (Helper.MakeDoubleValid(DB.Picklists.Get_Single_Description("ADDAPP", 71)) * (DGVAdditional.Count - 1)) + highestPrice

                                    If Me.chkCert.Checked = True AndAlso DGVAdditional.Count > 0 Then
                                        serviceCharge += Helper.MakeDoubleValid(DB.Picklists.Get_Single_Description("LLCERT", 71))
                                    End If
                                End If
                        End Select
                End Select
            Next
        End If

        txtCharge.Text = "£" & CDbl(CDbl(txtCharge.Text) + CDbl(serviceCharge))

        secTime = time

        DGVAdditional.RowFilter = "1=1"

        visitcharge2 = CDbl(serviceCharge)
        visitterm2 = Combo.GetSelectedItemDescription(cboPayTerms)

    End Sub

#End Region

#Region "Appointments"

    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles btnOption1.Click, btnOption2.Click, btnOption3.Click, btnOption4.Click, btnOption5.Click, btnOption6.Click, btnOption7.Click, btnOption8.Click, btnOption10.Click
        Dim btn As Button = CType(sender, Button) ' stop duplicating button code
        Dim engineerID As Integer = btn.Tag.ToString.Split("^")(0)
        Dim Datein As Date = CDate(btn.Tag.ToString.Split("^")(1))
        Dim Period As String = btn.Tag.ToString.Split("^")(2)

        Dim c As Control() = ParentForm.Controls.Find("btnSaveProg", True)
        Dim b As Button = c(0)

        If Not RunValidation() Then
            Exit Sub
        End If

        b.Visible = False

        BookingDetail = "Visit booked with " & DB.Engineer.Engineer_Get(engineerID).Name & " Scheduled " & Datein.ToString("dd/MM/yyyy") & " " & Period

        Try
            If CInt(txtCharge.Text.Replace("£", "")) > 0 Then

                BookingDetail += " Charging " & Format(CDbl(txtCharge.Text), "C")

            End If
        Catch ex As Exception

        End Try

        btnxx6.Enabled = False

        visitsBooked += 1
        Me.Cursor = Cursors.WaitCursor
        'Add Notes about appointment
        Dim f As New FrmAdditionalNotes
        f.ShowDialog()

        Dim job As Entity.Jobs.Job = CreateVisits(engineerID, Datein, Period, priTime, f.txtAdditionalNotes.Text, visitsBooked)
        CurrentJob = job
        BookingDetail += " Job Number : " & job.JobNumber

        If chkKeepTogether.Checked And secTime > 0 Then
            visitsBooked += 1
            job = CreateVisits(engineerID, Datein, Period, secTime, f.txtAdditionalNotes.Text, visitsBooked)
            BookingDetail += ", " & job.JobNumber
        ElseIf secTime > 0 Then
            '  jobtype = "SERVICE"    ''''''''''''''''''''''''''''''''''' HARD CODE DODGYNESS
            FindAppointments(True)   ''' -  lets go round again '''' :)

        End If
        lblBookedInfo.Text = BookingDetail & " (Click here to view job)"
        Me.Cursor = Cursors.Default
        btnxx6.Enabled = True
        Notes() ' prompt for notes

    End Sub

    Function RunValidation() As Boolean

        If CurrentSite.PoNumReqd AndAlso txtPONumber.Text.Length < 1 Then

        End If
        Return True

    End Function

    Function CreateVisits(ByVal EngineerID As Integer, ByVal Datein As Date, ByVal Period As String, ByVal time As Double, ByVal additionalNotes As String, Optional ByVal visit As Integer = 1) As Entity.Jobs.Job

        Dim newJob As Boolean = False
        If CurrentJob Is Nothing Or visit = 2 Then
            newJob = True
        End If

        Dim job As Entity.Jobs.Job
        If newJob Then
            job = New Entity.Jobs.Job
        Else
            job = CurrentJob
        End If

        Dim visittime As Double = time

        If chkRecall.Checked And RecallJobTypeID = 4703 And jobtype <> "SERVICE" And newJob = True Then  ' if its a recall just add on the current job

            job = DB.Job.Job_Get(RecallJobID)
        Else

            Dim JobNumber_ds As New DataSet

            Dim jobnumber As JobNumber

            If newJob Then
                jobnumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Callout)
                job.SetJobNumber = jobnumber.Prefix & jobnumber.JobNumber
                '  job.SetJobNumber = Job_JobNumber
            End If

            job.SetPropertyID = CurrentSite.SiteID
            job.SetJobDefinitionEnumID = 3

            If jobtype.ToUpper.Contains("SERVICE") Or visit = 2 Then
                job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.Service) 'service
                If chkCert.Checked Then
                    job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.llCert) ' ll cert
                End If

            ElseIf Me.btnxxOther.BackColor = System.Drawing.Color.PaleGreen And Combo.GetSelectedItemValue(cboTypeOfWorks) > 0 Then
                job.SetJobTypeID = Combo.GetSelectedItemValue(cboTypeOfWorks)
            ElseIf jobtype = "SOR" Then
                job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.Dayworks) ' Dayworks
            ElseIf jobtype = "BREAKDOWN" Then
                job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.Breakdown) 'breakdown
            ElseIf jobtype = "PLUMBING" Then
                job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.Plumbing)
            ElseIf jobtype = "CARPENTRY" Then
                job.SetJobTypeID = 71039
            ElseIf jobtype = "ELECTRICAL" Then
                job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.RenewablesElectrical)
            ElseIf jobtype = "MULTI TRADE" Then
                job.SetJobTypeID = 71044
            Else
                job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.Dayworks) ' Dayworks
            End If

            job.SetCreatedByUserID = loggedInUser.UserID
            job.SetPONumber = DBNull.Value
            job.SetQuoteID = 0
            job.SetContractID = 0
            job.SetToBePartPaid = False
            job.SetRetention = 0
            job.SetCollectPayment = False
            job.SetPOC = False
            job.SetFOC = False
            job.SetOTI = False

            If visit = 1 Then

                Select Case visitterm1

                    Case "OTI"
                        job.SetOTI = True
                    Case "POC"
                        job.SetPOC = True
                    Case "FOC"
                        job.SetFOC = True
                    Case Else
                        job.SetFOC = True

                End Select
            Else

            End If

            job.SetDeleted = 0

            '''  job assets
            '''
            Dim arraylist1 As New ArrayList

            If newJob = False Then

                DB.ExecuteScalar("Delete tblJobAsset where JobID = " & CurrentJob.JobID)

            End If

            If visit = 1 Then
                For Each dr As DataGridViewRow In DgMain.Rows
                    If (dr.Cells("Product").Value.ToString.Contains("- Unknown") Or dr.Cells("Product").Value.ToString.Contains("Non Appliance Related")) And dr.Cells("AssetID").Value < 21 Then
                    Else
                        Dim jobass As New Entity.JobAssets.JobAsset
                        jobass.SetAssetID = dr.Cells("AssetID").Value
                        jobass.SetJobID = job.JobID
                        arraylist1.Add(jobass)
                    End If

                Next
            Else

                For Each dr As DataGridViewRow In DGAdditional.Rows
                    If dr.Cells("ID").Value = 1 Then
                        Dim jobass As New Entity.JobAssets.JobAsset
                        jobass.SetAssetID = dr.Cells("AssetID").Value
                        jobass.SetJobID = job.JobID
                        arraylist1.Add(jobass)
                    End If

                Next

            End If

            job.Assets = arraylist1
        End If

        Dim jow As Entity.JobOfWorks.JobOfWork

        If newJob Then
            jow = New Entity.JobOfWorks.JobOfWork
        Else
            jow = DB.JobOfWorks.JobOfWork_Get(currentVisit.JobOfWorkID)
        End If

        jow.SetJobID = job.JobID
        jow.SetDeleted = "0"
        jow.SetPONumber = txtPONumber.Text
        jow.SetStatus = "1"
        jow.SetPriority = Combo.GetSelectedItemValue(cboPriority)
        If newJob Then
            jow.PriorityDateSet = DateTime.Now
        ElseIf jow.PriorityDateSet < New DateTime(2001, 1, 1) Or jow.PriorityDateSet = DateTime.MinValue Then ' check if it's way old
            jow.PriorityDateSet = DateTime.Now
        End If

        If Not newJob Then
            DB.JobItems.DeleteAll_ForJOW(currentVisit.JobOfWorkID)
        End If

        Dim SORdt As DataTable = DB.CustomerScheduleOfRate.GetAll_For_CustomerID(CurrentCustomer.CustomerID).Table
        Dim sorRows() As DataRow

        Dim sorTableSERV As DataTable = SORdt.Clone

        Dim count As Integer = 0

        If CurrentCustomer.CustomerTypeID = Enums.CustomerType.SocialHousing Then
            If jobtype = "SERVICE" Or visit = 2 Then

                Try
                    sorTableSERV.Rows.Add(SORdt.Select("Code='EA7007,'")(0).ItemArray)
                Catch ex As Exception

                End Try

            ElseIf jobtype = "BREAKDOWN" Then

                Try
                    If Combo.GetSelectedItemValue(cboPriority) = Enums.JobPriority.EMTwentyFourHours Then
                        sorTableSERV.Rows.Add(SORdt.Select("Code='EA7003'")(0).ItemArray)
                    Else
                        sorTableSERV.Rows.Add(SORdt?.Select("Code='EA7005'")(0).ItemArray)
                    End If
                Catch ex As Exception

                End Try

            ElseIf jobtype = "SOR" Then
                Try
                    For Each dr As DataGridViewRow In DGSOR.Rows

                        sorTableSERV.Rows.Add(SORdt.Select("Code='" & dr.Cells("code").Value.ToString & "'")(0).ItemArray)

                    Next
                Catch ex As Exception

                End Try

            End If
        Else
            If jobtype = "SERVICE" Or visit = 2 Then

                If visit = 1 Then

                    For Each dr As DataGridViewRow In DgMain.Rows

                        Try
                            If count > 0 Then

                                sorTableSERV.Rows.Add(SORdt.Select("Code='SERVADD'")(0).ItemArray)
                                Continue For

                            End If

                            Select Case True

                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("SOLID"), dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("WOOD"), dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("OPEN FIRE")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='EA7001^'")(0).ItemArray)

                                    count += 1

                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("COMMERCIAL"), dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("CONVECTOR HEATER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='C1'")(0).ItemArray)

                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("STORE")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV5'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("OIL BOILER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SVOB'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("BOILER"), dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("COND BOILER"), dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("COND COMBI"), dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("BACK BOILER"), dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("STD EFF BOILER"), dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("STD EFF COMBI")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV1'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("WARM AIR UNIT")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV4'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("AIR SOURCE"), dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("GROUND SOURCE")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SVASHP'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("LARGE UNIT HEATER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV10A'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("UNIT HEATER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV10'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("GAS FIRE")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV6'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("WATER HEATER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV7'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("UNVENTED CYLINDER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SERV UNVENT'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("RANGE COOKER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV8'")(0).ItemArray)
                                    count += 1
                                    '2 X attend

                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("COOKER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV8'")(0).ItemArray)
                                    count += 1
                                Case dr.Cells("Product").Value.ToString.ToUpper.Split("-")(0).Contains("HOB")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV9'")(0).ItemArray)
                                    count += 1

                            End Select
                        Catch ex As Exception

                        End Try

                    Next
                Else

                    For Each dr As DataRowView In DGVAdditional

                        If count > 0 Then

                            sorTableSERV.Rows.Add(SORdt.Select("Code='SERVADD'")(0).ItemArray)
                            Continue For

                        End If

                        Try

                            Select Case True

                                Case dr("Product").ToString.ToUpper.ToUpper.Split("-")(0).Contains("SOLID"), dr("Product").ToString.ToUpper.Split("-")(0).Contains("WOOD"), dr("Product").ToString.ToUpper.Split("-")(0).Contains("OPEN FIRE")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='EA7001^'")(0).ItemArray)
                                    count += 1

                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("COMMERCIAL"), dr("Product").ToString.ToUpper.Split("-")(0).Contains("CONVECTOR HEATER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='C1'")(0).ItemArray)

                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("STORE")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV5'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("OIL BOILER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SVOB'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("BOILER"), dr("Product").ToString.ToUpper.Split("-")(0).Contains("COND BOILER"), dr("Product").ToString.ToUpper.Split("-")(0).Contains("COND COMBI"), dr("Product").ToString.ToUpper.Split("-")(0).Contains("BACK BOILER"), dr("Product").ToString.ToUpper.Split("-")(0).Contains("STD EFF BOILER"), dr("Product").ToString.ToUpper.Split("-")(0).Contains("STD EFF COMBI")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV1'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("WARM AIR UNIT")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV4'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("AIR SOURCE"), dr("Product").ToString.ToUpper.Split("-")(0).Contains("GROUND SOURCE")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SVASHP'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("LARGE UNIT HEATER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV10A'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("UNIT HEATER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV10'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("GAS FIRE")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV6'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("WATER HEATER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV7'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("UNVENTED CYLINDER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SERV UNVENT'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("RANGE COOKER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV8'")(0).ItemArray)
                                    count += 1
                                    '2 X attend

                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("COOKER")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV8'")(0).ItemArray)
                                    count += 1
                                Case dr("Product").ToString.ToUpper.Split("-")(0).Contains("HOB")

                                    sorTableSERV.Rows.Add(SORdt.Select("Code='SV9'")(0).ItemArray)
                                    count += 1

                            End Select
                        Catch ex As Exception

                        End Try

                    Next

                End If

            ElseIf jobtype = "BREAKDOWN" Then

                Try
                    sorTableSERV.Rows.Add(SORdt.Select("Code='CBK'")(0).ItemArray)
                Catch ex As Exception

                End Try

                If CurrentCustomer.CustomerTypeID = Enums.CustomerType.Insurance Then

                    Try
                        sorTableSERV.Rows.Add(SORdt.Select("Code='INSBRK'")(0).ItemArray)
                    Catch ex As Exception

                    End Try
                End If

            ElseIf jobtype = "SOR" Then

                For Each dr As DataGridViewRow In DGSOR.Rows
                    Try
                        sorTableSERV.Rows.Add(SORdt.Select("Code='" & dr.Cells("code").Value.ToString & "'")(0).ItemArray)
                    Catch ex As Exception

                    End Try

                Next

            End If

        End If

        If sorTableSERV.Rows.Count < 1 Then
            sorTableSERV.Rows.Add(SORdt.Select("Code='DEFAULTS' AND Description = 'Normal Labour'")(0).ItemArray)
        End If

        sorRows = sorTableSERV.Select("1=1")

        For Each DR As DataRow In sorRows
            Dim sorRow As DataRow = DR
            Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(sorRow("ScheduleOfRatesCategoryID"), sorRow("Description"), sorRow("Code"), CurrentSite.CustomerID)
            Dim customerSorId As Integer = 0
            If customerSors.Rows.Count > 0 Then customerSorId = Helper.MakeIntegerValid(customerSors.Rows(0).Item(0))

            If Not customerSorId > 0 Then
                Dim customerSor As New CustomerScheduleOfRates.CustomerScheduleOfRate With {
                    .SetCode = sorRow("Code"),
                    .SetDescription = sorRow("Description"),
                    .SetPrice = sorRow("Price"),
                    .SetScheduleOfRatesCategoryID = sorRow("ScheduleOfRatesCategoryID"),
                    .SetTimeInMins = sorRow("TimeInMins"),
                    .SetCustomerID = CurrentSite.CustomerID
                }
                customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID
            End If

            Dim sorqty As Double = 1  ' make sor qty react to time allowance

            If TimeReqOption = True Then

                If IsNumeric(txtDays.Text) AndAlso CInt(txtDays.Text) > 0 Then
                    sorqty = CInt(txtDays.Text) * 8
                Else
                    sorqty = 0
                End If

                If IsNumeric(txtHrs.Text) AndAlso CInt(txtHrs.Text) > 0 Then
                    sorqty += CDbl(txtHrs.Text)
                End If

                If sorqty = 0 Then sorqty = 1 ' SET A DEFAULT UP

            End If

            Dim jobItem As New JobItems.JobItem
            jobItem.IgnoreExceptionsOnSetMethods = True
            jobItem.SetSummary = sorRow("Description")
            jobItem.SetQty = 1
            jobItem.SetRateID = customerSorId
            jobItem.SetSystemLinkID = CInt(Enums.TableNames.tblCustomerScheduleOfRate)
            If newJob Then
                jow.JobItems.Add(jobItem)
            Else
                jobItem.SetJobOfWorkID = jow.JobOfWorkID
                DB.JobItems.Insert(jobItem)
            End If

        Next

        Dim startdatetime As String = ""
        Dim enddatetime As String = ""
        Dim appointmentID As Integer = 0
        Dim ev As Entity.EngineerVisits.EngineerVisit

        If newJob Then
            ev = New Entity.EngineerVisits.EngineerVisit
            If Not costCentre Is Nothing Then
                ev.SetExpectedDepartment = costCentre
            End If
        Else
            ev = currentVisit
        End If

        ' FIND THE GAP
        If Datein > Date.MinValue.AddDays(2) Then

            Select Case Period

                Case "AM"

                    Datein = CStr(Datein).Substring(0, 10) & " 08:00:01"
                    appointmentID = 69943
                Case "PM"

                    Datein = CStr(Datein).Substring(0, 10) & " 12:00:01"

                    appointmentID = 69944
                Case "8-12"

                    Datein = CStr(Datein).Substring(0, 10) & " 08:00:01"

                    appointmentID = 69939
                Case "10-2"

                    Datein = CStr(Datein).Substring(0, 10) & " 10:00:01"

                    appointmentID = 69940
                Case "12-4"

                    Datein = CStr(Datein).Substring(0, 10) & " 12:00:01"

                    appointmentID = 69941
                Case "2-6"

                    Datein = CStr(Datein).Substring(0, 10) & " 14:00:01"

                    appointmentID = 69942

                Case "8AM"

                    Datein = CStr(Datein).Substring(0, 10) & " 08:00:00"

                    appointmentID = 69938

                Case "ANY"

                    Datein = CStr(Datein).Substring(0, 10) & " 12:00:00"

                    appointmentID = 69945

            End Select

            startdatetime = CStr(Datein).Replace("/", "-")

            Dim DT As DataTable = DB.EngineerVisits.Find_The_Gap(Format(Datein, "yyyy-MM-dd"), EngineerID, Period)

            If DT.Rows.Count = 0 Or Period = "8AM" Then

                '69938	78	8AM / FIRST CALL
                '69939	78	8AM - 12PM
                '69940	78	10AM - 2PM
                '69941	78	12PM - 4PM
                '69942	78	2PM - 6PM
                '69943	78	AM
                '69944	78	PM
                '69945	78	ANYTIME
            Else

                startdatetime = DT.Rows(0)("EndDateTime")

            End If

            If TimeReqOption = True Then

                If IsNumeric(txtDays.Text) AndAlso CInt(txtDays.Text) > 0 Then
                    visittime = (CInt(txtDays.Text) * 24) * 60
                Else
                    visittime = 0
                End If

                If IsNumeric(txtHrs.Text) AndAlso CInt(txtHrs.Text) > 0 Then
                    visittime += (CDbl(txtHrs.Text) * 60)
                End If

                If visittime = 0 Then visittime = 60 ' SET A DEFAULT UP

            End If

            enddatetime = CDate(startdatetime).AddMinutes(CDbl(visittime))

            startdatetime = Format(CDate(startdatetime), "yyyy-MM-dd HH:mm:ss")
            enddatetime = Format(CDate(enddatetime), "yyyy-MM-dd HH:mm:ss")

            ev.StartDateTime = startdatetime
            ev.EndDateTime = enddatetime
            ev.SetAppointmentID = appointmentID
            ev.SetStatusEnumID = "5"
        Else

            ev.SetStatusEnumID = "4"

        End If

        ev.SetJobOfWorkID = jow.JobOfWorkID

        Dim payterms As String

        If visit = 1 Then

            payterms = visitterm1
        Else

            payterms = visitterm2

        End If

        If Period = "Anytime" Then
            Period = "ANY"
        End If

        ev.SetNotesToEngineer = "(" & Period & ")"

        For Each s As String In SkillsList
            ev.SetNotesToEngineer = ev.NotesToEngineer & " *" & s & "*"
        Next

        If CurrentSite.CommercialDistrict Then
            ev.SetNotesToEngineer = ev.NotesToEngineer & " DISTRICT"
        End If

        If additionalNotes.Length > 0 Then
            ev.SetNotesToEngineer = ev.NotesToEngineer & " - " & additionalNotes & " -"
        End If

        If jobtype = "SERVICE" Or visit = 2 Then

            If chkCert.Checked Then

                ev.SetNotesToEngineer = ev.NotesToEngineer & " Service & Cert Visit - "
            Else

                ev.SetNotesToEngineer = ev.NotesToEngineer & " Service Visit - "

            End If

            For Each dr As DataGridViewRow In DgMain.Rows

                ev.SetNotesToEngineer = ev.NotesToEngineer & (dr.Cells("Product").Value.ToString.Split("-")(0)) & " - " & (dr.Cells("Product").Value.ToString.Split("-")(1)) & ", "

            Next

            ev.SetNotesToEngineer = ev.NotesToEngineer & " " & txtAdditional.Text & " - " & payterms

        ElseIf jobtype = "BREAKDOWN" Then

            ev.SetNotesToEngineer = ev.NotesToEngineer & " Breakdown Visit - "
            For Each dr As DataGridViewRow In DGSymptoms.Rows
                If dr.Cells("Code").Value = "OTHER" Then Continue For
                ev.SetNotesToEngineer = ev.NotesToEngineer & dr.Cells("Description").Value & ", "

            Next

            ev.SetNotesToEngineer = ev.NotesToEngineer & " " & txtAdditional.Text & " - " & payterms

        ElseIf jobtype = "SOR" Then

            ev.SetNotesToEngineer = ev.NotesToEngineer & " Complete SOR based Works  - See SOR List"

            ev.SetNotesToEngineer = ev.NotesToEngineer & " " & txtAdditional.Text & " - " & payterms
        Else

            ev.SetNotesToEngineer = ev.NotesToEngineer & " Complete " & jobtype & " based Works - "

            ev.SetNotesToEngineer = ev.NotesToEngineer & " " & txtAdditional.Text & " - " & payterms

        End If

        If visit = 1 Then

            If visitterm1 = "POC" Then ' POC

                ev.SetNotesToEngineer = ev.NotesToEngineer & " £" & visitcharge1 & " inc VAT"

            End If
        Else
            If visitterm2 = "POC" Then ' POC

                ev.SetNotesToEngineer = ev.NotesToEngineer & " £" & visitcharge2 & " inc VAT"

            End If

        End If

        ev.SetPartsToFit = False
        ev.SetEngineerID = EngineerID

        Dim ja1 As New Entity.JobAudits.JobAudit

        Dim ActionChange As String = ""

        If Not job.Exists Then
            jow.EngineerVisits.Add(ev)
            job.JobOfWorks.Add(jow)
            job = DB.Job.Insert(job)

            ActionChange = "New Visit Inserted through the Wizard (By User " & loggedInUser.Fullname & ") - Status: NOT SET (Unique Visit ID: " & ev.EngineerVisitID & ")"
        Else
            job = DB.Job.Update(job, New ArrayList, New ArrayList, New ArrayList)
            DB.JobOfWorks.Update_PONumber(jow)
            DB.JobOfWorks.Update_Priority(jow)
            DB.EngineerVisits.Update(ev, CurrentJob.JobID, True)
            ActionChange = "Visit Updated through the Wizard (By User " & loggedInUser.Fullname & ") - Status: NOT SET (Unique Visit ID: " & ev.EngineerVisitID & ")"
        End If

        jobids = job.JobID

        ' Add symptoms to visit
        DB.EngineerVisits.DeleteExtendedProperties(ev.EngineerVisitID)
        DB.EngineerVisits.DeleteSymptoms(ev.EngineerVisitID)
        For Each dr As DataGridViewRow In DGSymptoms.Rows
            DB.EngineerVisits.InsertSymptom(ev.EngineerVisitID, dr.Cells("SypID").Value)
        Next
        'Add Additional Text
        If txtAdditional.Text.ToString.Length > 0 Then
            DB.EngineerVisits.InsertAdditionalText(ev.EngineerVisitID, txtAdditional.Text.ToString)
        End If

        ja1.SetJobID = job.JobID
        ja1.SetActionChange = ActionChange

        DB.JobAudit.Insert(ja1)

        If BookingDetail = "" Then

            BookingDetail = "Job saved as ready for schedule Job Number - " & job.JobNumber

            For Each dr As DataRow In DTPrivNotes.Select("JobNoteID = 0")

                DB.Job.SaveJobNotes(0, dr("Note"), dr("EditedByUserID"), job.JobID, dr("CreatedByUserID")).ToTable()

            Next

            DTPrivNotes = DB.Job.GetAllJobNotes(CurrentSite.SiteID)

            Try

                tcSites.TabPages(0).Enabled = True
                tcSites.TabPages.Remove(tabProp)
                '  tcSites.TabPages.Add(tabProp)
                tcSites.TabPages.Remove(tabExistingJobs)
                tcSites.TabPages.Remove(tabJobType)
                tcSites.TabPages.Remove(tabJobDetails)
                tcSites.TabPages.Remove(tabAppliance)
                tcSites.TabPages.Remove(TabCharging)
                tcSites.TabPages.Remove(tabAdditional)
                tcSites.TabPages.Remove(TabBook)
                tcSites.TabPages.Insert(tcSites.TabCount, tcComplete)
                tab = tcSites.SelectedIndex + 1
                tcSites.SelectedIndex = tcSites.SelectedIndex + 1
                tcSites.SelectedIndex = 1
                '  tcSites.SelectedIndex = 1
                '  Temp.Clear()
            Catch ex As Exception
                tcSites.TabPages.Insert(tcSites.TabCount, tcComplete)
                tab = tcSites.SelectedIndex + 1
                tcSites.SelectedIndex = tcSites.SelectedIndex + 1
                tcSites.SelectedIndex = 0
            End Try

            Return job

        ElseIf visit = 2 Or (Not DGVAdditional Is Nothing AndAlso DGVAdditional.Count = 0) Then

            If BookingDetail.Contains("Job saved as ready for schedule Job") Then
                BookingDetail += " & " & job.JobNumber
            Else
                '   If tcSites.TabCount = 8 Then
                Dim dt As New DataTable
                dt = DTPrivNotes
                Dim dr As DataRow = dt.NewRow

                dr(0) = 0
                dr(1) = loggedInUser.UserID
                dr(2) = loggedInUser.UserID
                dr(3) = "Visit booked with " & DB.Engineer.Engineer_Get(EngineerID).Name & " Scheduled " & Datein.ToString("dd/MM/yyyy") & " " & Period
                dr(4) = Date.Now
                dr(5) = loggedInUser.Username
                dr(6) = Date.Now
                dr(7) = loggedInUser.Username
                dr(8) = 0
                dr(9) = "New.."
                dr(10) = 0

                dt.Rows.InsertAt(dr, 0)

                DTPrivNotes = dt

                For Each dr1 As DataRow In DTPrivNotes.Select("JobNoteID = 0")

                    DB.Job.SaveJobNotes(0, dr1("Note"), dr1("EditedByUserID"), job.JobID, dr1("CreatedByUserID")).ToTable()

                Next
                DTPrivNotes = DB.Job.GetAllJobNotes(CurrentSite.SiteID)

                Try

                    tcSites.TabPages(0).Enabled = True
                    tcSites.TabPages.Remove(tabProp)
                    '   tcSites.TabPages.Add(tabProp)
                    tcSites.TabPages.Remove(tabExistingJobs)
                    tcSites.TabPages.Remove(tabJobType)
                    tcSites.TabPages.Remove(tabJobDetails)
                    tcSites.TabPages.Remove(tabAppliance)
                    tcSites.TabPages.Remove(TabCharging)
                    tcSites.TabPages.Remove(tabAdditional)
                    tcSites.TabPages.Remove(TabBook)

                    tcSites.SelectedIndex = 1
                    '  tcSites.SelectedIndex = 1
                    '  Temp.Clear()
                    tcSites.TabPages.Insert(tcSites.TabCount, tcComplete)
                    tab = tcSites.SelectedIndex + 1
                    tcSites.SelectedIndex = tcSites.SelectedIndex + 1
                Catch ex As Exception
                    tcSites.TabPages.Insert(tcSites.TabCount, tcComplete)
                    tab = tcSites.SelectedIndex + 1
                    tcSites.SelectedIndex = tcSites.SelectedIndex + 1
                    tcSites.SelectedIndex = 0
                End Try

            End If

        End If
        Return job
    End Function

    Private Function CheckMainApps(ByVal Wordin As String, Optional ByVal secondry As Boolean = False) As Boolean

        Select Case True

            Case Wordin.ToUpper.Contains("SOLID"), Wordin.ToUpper.Contains("WOOD"), Wordin.ToUpper.Contains("OPEN FIRE")
                HETASNEEDED = True
                servTime = 90

            Case Wordin.ToUpper.Contains("COMMERCIAL"), Wordin.ToUpper.Contains("CONVECTOR HEATER")
                COMMNEEDED = True
                servTime = 90

            Case Wordin.ToUpper.Contains("STORE")

                servTime = 45
                Return True

            Case Wordin.ToUpper.Contains("OIL BOILER")

                servTime = 60
                OILNEEDED = True
                Return True

            Case Wordin.ToUpper.Contains("BOILER"), Wordin.ToUpper.Contains("COND BOILER"), Wordin.ToUpper.Contains("COND COMBI"), Wordin.ToUpper.Contains("BACK BOILER"), Wordin.ToUpper.Contains("STD EFF BOILER"), Wordin.ToUpper.Contains("STD EFF COMBI")

                servTime = 45
                NATNEEDED = True
                Return True

            Case Wordin.ToUpper.Contains("WARM AIR UNIT")
                NATNEEDED = True
                WAUNEEDED = True
                servTime = 75
                Return True

            Case Wordin.ToUpper.Contains("AIR SOURCE"), Wordin.ToUpper.Contains("GROUND SOURCE")
                ASNEEDED = True
                servTime = 35
                Return True

            Case Wordin.ToUpper.Contains("LARGE UNIT HEATER")
                NATNEEDED = True
                servTime = 60

                ' 2 x Attend

            Case Wordin.ToUpper.Contains("UNIT HEATER")
                NATNEEDED = True
                servTime = 30

            Case Wordin.ToUpper.Contains("GAS FIRE")
                NATNEEDED = True
                servTime = 45

            Case Wordin.ToUpper.Contains("WATER HEATER")
                NATNEEDED = True
                servTime = 60

            Case Wordin.ToUpper.Contains("UNVENTED CYLINDER")

                servTime = 15

            Case Wordin.ToUpper.Contains("RANGE COOKER")
                NATNEEDED = True
                servTime = 90

                '2 X attend

            Case Wordin.ToUpper.Contains("COOKER")
                NATNEEDED = True
                servTime = 55

            Case Wordin.ToUpper.Contains("HOB")
                NATNEEDED = True
                servTime = 30

        End Select

        Return False

    End Function

    Private Function Pricing(ByVal wordin As String) As String

        Select Case True

            Case wordin.ToUpper.Contains("STORE")

                Return DB.Picklists.Get_Single_Description("STOREBLR", 71)

            Case wordin.ToUpper.Contains("OIL BOILER")

                Return DB.Picklists.Get_Single_Description("OILBLR", 71)

            Case wordin.ToUpper.Contains("BOILER"), wordin.ToUpper.Contains("COND BOILER"), wordin.ToUpper.Contains("COND COMBI"), wordin.ToUpper.Contains("BACK BOILER"), wordin.ToUpper.Contains("STD EFF BOILER"), wordin.ToUpper.Contains("STD EFF COMBI")

                Return DB.Picklists.Get_Single_Description("BOILER", 71)

            Case wordin.ToUpper.Contains("WARM AIR UNIT")

                Return DB.Picklists.Get_Single_Description("WARMAIR", 71)

            Case wordin.ToUpper.Contains("AIR SOURCE")

                Return DB.Picklists.Get_Single_Description("AIRANDSOL", 71)

            Case wordin.ToUpper.Contains("LARGE UNIT HEATER")

                Return DB.Picklists.Get_Single_Description("LRGUNIT", 71)

            Case wordin.ToUpper.Contains("UNIT HEATER")

                Return DB.Picklists.Get_Single_Description("UNITHTR", 71)

            Case wordin.ToUpper.Contains("GAS FIRE")

                Return DB.Picklists.Get_Single_Description("GASFIRE", 71)

            Case wordin.ToUpper.Contains("WATER HEATER")

                Return DB.Picklists.Get_Single_Description("WATERHTR", 71)

            Case wordin.ToUpper.Contains("UNVENTED CYLINDER")

                If DgMain.RowCount = 1 Then
                    Return DB.Picklists.Get_Single_Description("UNVENT", 71)
                Else
                    Return DB.Picklists.Get_Single_Description("UNVENTPLUS", 71)
                End If
            Case wordin.ToUpper.Contains("RANGE COOKER")
                Return DB.Picklists.Get_Single_Description("RNGCKR", 71)

            Case wordin.ToUpper.Contains("COOKER")
                Return DB.Picklists.Get_Single_Description("CKR", 71)

            Case wordin.ToUpper.Contains("HOB")
                Return DB.Picklists.Get_Single_Description("HOB", 71)

        End Select

    End Function

    '    475	14	Domestic
    '513	14	Agency
    '514	14	Manufacturer
    '515	14	Commercial/Industrial
    '516	14	Housing Association/Council
    '517	14	Insurance
    '518	14	Private Landlord
    '539	14	Unknown
    '4715	14	Sub Contractor
    '6430	14	Non Chargeable
    '68552	14	GBS

    Private Sub FindAppointments(Optional ByVal SecondVisit As Boolean = False)
        'work out time requirement
        Dim btns As Button() = {btnOption1, btnOption2, btnOption3, btnOption4, btnOption5, btnOption6, btnOption7, btnOption8, btnOption10}
        For Each b As Button In btns
            b.Visible = False
        Next

        Application.DoEvents()
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        '  Dim temp As New DataTable

        If secTime = 0 Then
            chkKeepTogether.Visible = False
        Else
            chkKeepTogether.Visible = True
        End If

        If chkKeepTogether.Checked Then
            reqtime = priTime + secTime
            lblBookText.Text = "Booking All Visits"

        ElseIf Not SecondVisit Then

            reqtime = priTime

            If jobtype.ToUpper.Contains("SERVICE") Then
                dtpFromDate.Value = Now.AddDays(14)
                ' TODO title
                lblBookText.Text = "Booking Service Visit"
            Else
                dtpFromDate.Value = Now
                ' TODO title
                lblBookText.Text = "Booking " & jobtype & " Visit"
            End If
        Else

            reqtime = secTime

            dtpFromDate.Value = Now.AddDays(14)
            If jobtype.ToUpper.Contains("SERVICE") Then
                dtpFromDate.Value = Now.AddDays(14)
                ' TODO title
                lblBookText.Text = "Booking Service Visit"
            Else
                dtpFromDate.Value = Now
                ' TODO title
                lblBookText.Text = "Booking " & jobtype & " Visit"
            End If
        End If

        Dim liverefresh As Boolean = False

        If Temp.Rows.Count = 0 Or (currentFilterDate > Date.MinValue And dtpFromDate.Value.AddDays(-7) > currentFilterDate) Or dtpFromDate.Value < currentFilterDate Then
            'temp.Clear()
            liverefresh = True
            currentFilterDate = CDate(dtpFromDate.Value)
            If Not CurrentCustomer.SuperBook Then
                Temp = DB.EngineerVisits.Get_Appointments_Multi(dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm"), priTime)
            Else
                Temp = DB.EngineerVisits.Get_Appointments_Multi(dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm"), priTime, 1) ' create the structure
                Temp.Clear()
            End If
            Temp.Columns.Add("AssignedArea")
        End If

        'get the skills needed for this customer (if any)
        Dim levelsList As IList(Of Integer) = New List(Of Integer)
        Dim co As Integer = 0
        Dim dd() As DataRow = DB.Customer.Requirements_Get_For_CustomerID(CurrentCustomer.CustomerID).Table.Select("tick = 1")
        For Each d As DataRow In dd
            levelsList.Add(d("ManagerID"))
            co += 1

        Next

        'Get any skills needed for this job type
        Dim JobLevels As DataTable = DB.EngineerLevel.Get_List_For_JobType(Combo.GetSelectedItemValue(cbotypeWiz))
        For Each dr As DataRow In JobLevels.Rows
            levelsList.Add(dr("SkillID"))
        Next

        'if no skills / qualifications are needed then add the default retail trained qual - always need one qual
        If co = 0 And JobLevels.Rows.Count = 0 Then
            levelsList.Add(69697)
        End If

        Dim SiteFuel As DataView = DB.Sites.SiteFuel_GetAll_ForSite(CurrentSite.SiteID)
        'Dim AdditionalService As Boolean
        'For Each dd1 As DataGridViewRow In DGAdditional.Rows
        '    If dd1.Cells("ID").Value = 1 Then
        '        AdditionalService = True
        '    End If

        'Next
        ' if site is flagged as district commercial guys should go
        If (jobtype.ToUpper.Contains("BREAKDOWN")) And CurrentSite.CommercialDistrict = 1 Then
            COMMNEEDED = True
        End If

        'if a selected appliance is fuel LPG, an LPG skill is required
        LPGNEEDED = False
        Dim ass As New Entity.Assets.Asset
        For Each row As DataGridViewRow In DgMain.Rows
            If row.Cells.Item("ASSETID").Value > 20 Then
                ass = DB.Asset.Asset_Get(CInt(row.Cells.Item("ASSETID").Value))
            Else
                For Each dr As DataRow In SiteFuel.Table.Rows
                    If dr("FuelID") = 378 Then
                        LPGNEEDED = True
                    End If

                Next
            End If

            If ass.GasTypeID = 378 Then ' LPG
                LPGNEEDED = True
            End If

        Next

        '''''''''''''''''''''''''''WHATS NEEDED ''''''''''''''''''''''''''''''''''''

        SkillsList.Clear()

        'CORE GAS
        If NATNEEDED Then
            levelsList.Add(68820)
            SkillsList.Add("NAT GAS")
        End If
        'LPG
        If LPGNEEDED Then
            levelsList.Add(68857)
            SkillsList.Add("LPG")
        End If
        'COMM
        If COMMNEEDED Then
            levelsList.Add(68846)
            SkillsList.Add("COMMERCIAL")
        End If
        'WAU
        If WAUNEEDED Then
            levelsList.Add(68836)
            SkillsList.Add("WAU")
        End If
        'OIL
        If OILNEEDED Then
            levelsList.Add(68863)
            SkillsList.Add("OIL")
        End If
        'AIR SOURCE
        If ASNEEDED Then
            levelsList.Add(69743)
            SkillsList.Add("ASHP")
        End If
        'HETAS
        If HETASNEEDED Then
            levelsList.Add(68877)
            SkillsList.Add("HEATAS")
        End If
        'ELECT
        If SpecialTrade = "ELEC" Then
            levelsList.Add(68868)
            SkillsList.Add("ELEC")
        End If
        'PLUMBER
        If SpecialTrade = "PLUM" Then
            '  levelsList.Add(68857)
        End If
        'BANDM
        If SpecialTrade = "BANDM" Then
            '  levelsList.Add(68857)
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If liverefresh Then

            For Each r As DataRow In Temp.Rows

                r("AssignedArea") = 1

            Next

            Temp = AppointmentStrip(Temp, levelsList, False) ' strip out not postcoded engineers and those who dont work on this work.

        End If

        appointments.Clear()
        appointments = Temp.Clone

        appointments.Columns("EIGHT_TWELVE").DataType = Type.GetType("System.Double")
        appointments.Columns("TEN_TWO").DataType = Type.GetType("System.Double")
        appointments.Columns("TWELVE_FOUR").DataType = Type.GetType("System.Double")
        appointments.Columns("TWO_SIX").DataType = Type.GetType("System.Double")
        appointments.Columns.Add("SCORE")

        appointments.Columns("SCORE").DataType = Type.GetType("System.Int32")

        For Each row As DataRow In Temp.Rows
            appointments.ImportRow(row)
        Next

        Dim AppointmentsView As New DataView

        appointments.TableName = "Appointments"
        AppointmentsView.Table = appointments

        Dim targettime As DateTime = CDate(workingdays(DateTime.Now.ToString, 2))

        If jobtype = "BREAKDOWN" Then
        Else
            targettime = workingdays(DateTime.Now.ToString, 200)
        End If

        '' get target time
        Dim dt As DataTable = DB.Customer.Priorities_Get_For_CustomerID_Active(CurrentCustomer.CustomerID, Combo.GetSelectedItemValue(cboPriority)).Table
        If dt.Rows.Count = 1 Then
            Dim dr As DataRow = dt.Rows(0)
            If dr("IncludeWeekends") = True Then
                targettime = DateTime.Now.AddHours(dr("TargetHours"))
            Else
                If dr("TargetHours") < 24 Then
                    targettime = DateTime.Now.AddHours(dr("TargetHours"))
                End If

                Dim days1 As Double = dr("TargetHours") / 24 'cheat
                If days1 < 1 Then
                    targettime = workingdays(DateTime.Now.ToString, 1)
                Else
                    targettime = workingdays(DateTime.Now.ToString, CInt(days1))
                End If
            End If

            ' need to do explicit ones like only exclude ooh or only exclude BH but its rare so ent bothered right now

            'Select Case Combo.GetSelectedItemDescription(cboPriority)
            '    Case "P1 - 5 Days"
            '        targettime = workingdays(DateTime.Now.ToString, 5)
            '    Case "Service"
            '    Case "EM - 24HRS"
            '        targettime = DateTime.Now.AddHours(24) ' 24 Hours is 24Hrs
            '    Case "R1 - 20 Days"
            '        targettime = workingdays(DateTime.Now.ToString, 20)
            '    Case "RC -Recall"
            '        targettime = workingdays(DateTime.Now.ToString, 5)
            '    Case "Dayworks"
            '    Case "P3 - 3 Days"
            '        targettime = workingdays(DateTime.Now.ToString, 3)
            '    Case "Appt - 28 Days"
            '        targettime = workingdays(DateTime.Now.ToString, 28)
            'End Select
        End If

        Dim Contract247 As List(Of Integer) = New List(Of Integer)

        Contract247.AddRange({67353, 68032, 68376})

        If Not CurrentContract Is Nothing AndAlso Contract247.Contains(CurrentContract.ContractTypeID) Then
            targettime = CDate(DateTime.Now.AddHours(24).ToString("yyyy-MM-dd") & " 18:00") ' end of next day
        ElseIf Not CurrentContract Is Nothing Then
            targettime = CDate(CDate(workingdays(DateTime.Now, 1)).ToString("yyyy-MM-dd") & " 18:00") ' end of next WORKING day
        End If

        AppointmentsView.Table.Columns.Add("InTarget")

        For Each dr As DataRow In AppointmentsView.Table.Rows

            Dim t1 As DateTime = CDate(dr("Date") & " 12:00")
            If t1 < targettime Then
                dr("InTarget") = "1"
            Else
                dr("InTarget") = "0"
            End If

        Next

        ''''''''''''''''''''''just for schedulers'''''''''''''''''''''

        levelsList = New List(Of Integer)
        Dim co1 As Integer = 0
        Dim dd1() As DataRow = DB.Customer.Requirements_Get_For_CustomerID(CurrentCustomer.CustomerID).Table.Select("tick = 1")
        For Each d As DataRow In dd1
            levelsList.Add(d("ManagerID"))
            co1 += 1

        Next

        If co1 = 0 Then
            levelsList.Add(69697)
        End If

        ''' pull in the schedulers
        Schedulerapps.Columns.Add("AssignedArea")

        Schedulerapps = DB.EngineerVisits.Get_Appointments_Scheduler(dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm"), reqtime)

        Schedulerapps = AppointmentStrip(Schedulerapps, levelsList, True) ' still strip postcodes but keep weekends regardless

        Dim SchedulerAppsView As New DataView

        Schedulerapps.TableName = "SchAppointments"
        SchedulerAppsView.Table = Schedulerapps

        SchedulerAppsView.Table.Columns.Add("InTarget")

        For Each dr As DataRow In SchedulerAppsView.Table.Rows

            Dim t1 As DateTime = CDate(dr("Date") & " 12:00")
            If t1 < targettime Then
                dr("InTarget") = "1"
            Else
                dr("InTarget") = "0"
            End If

        Next

        Dim secFilter As String = ""

        If Combo.GetSelectedItemValue(cboEngineer) > 0 Then

            secFilter = " AND EngineerID = " & Combo.GetSelectedItemValue(cboEngineer)

        End If

        If Not SecondVisit Then

            Select Case Combo.GetSelectedItemValue(cboAppointment)
                Case Enums.AppointmentsPicklist.FirstCall

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND EightAMAvail = 1 AND remainingAM >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.Am

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND remainingAM >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.Pm

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND remainingPM >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.EightAmTillTwelvePm ' 8 - 12

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND [EIGHT_TWELVE] >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.TenAmTillTwoPm ' 10- 2

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND [TEN_TWO] >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.TwelvePmTillFourPm ' 12- 4

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND [TWELVE_FOUR] >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.TwoPmTillSixPm ' 2 - 6

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND [TWO_SIX] >= " & reqtime & secFilter

                Case Else
                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "#" & secFilter

            End Select
        Else  '  second visit try to lock the engineer ///////// TODO ////////////

            Select Case Combo.GetSelectedItemValue(cboAppointment)
                Case Enums.AppointmentsPicklist.FirstCall

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND EightAMAvail = 1 AND remainingAM >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.Am

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND remainingAM >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.Pm

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND remainingPM >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.EightAmTillTwelvePm ' 8 - 12

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND [EIGHT_TWELVE] >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.TenAmTillTwoPm ' 10- 2

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND [TEN_TWO] >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.TwelvePmTillFourPm ' 12- 4

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND [TWELVE_FOUR] >= " & reqtime & secFilter

                Case Enums.AppointmentsPicklist.TwoPmTillSixPm ' 2 - 6

                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "# AND [TWO_SIX] >= " & reqtime & secFilter

                Case Else
                    AppointmentsView.RowFilter = "Date>= #" & dtpFromDate.Value.ToString("yyyy-MM-dd") & "#" & secFilter

            End Select

        End If

        'If rbANY.Checked Or rbALL.Checked Then
        '    '
        'End If

        AppointmentsView.Table.Columns.Add("AMCLOSE")
        AppointmentsView.Table.Columns.Add("PMCLOSE")
        AppointmentsView.Table.Columns.Add("COMBCLOSE")
        AppointmentsView.Table.Columns.Add("ORIGAMCLOSE")
        AppointmentsView.Table.Columns.Add("ORIGPMCLOSE")
        '''''''''''''''''''''''''''In Area Shit ''''''''''''''''''''''''''''''''

        For Each dr As DataRow In AppointmentsView.Table.Rows

            If Not IsDBNull(dr("AMLatitude")) And Not IsDBNull(CurrentSite.Latitude) And (CurrentSite.Latitude) <> 0.0 Then
                Dim d As Double = distance(dr("AMLatitude"), dr("AMLongitude"), CurrentSite.Latitude, CurrentSite.Longitude, "M")

                dr("AMCLOSE") = d
                dr("ORIGAMCLOSE") = Math.Round(d, 2)
            Else
                dr("AMCLOSE") = DBNull.Value
            End If
            If Not IsDBNull(dr("PMLatitude")) And Not IsDBNull(CurrentSite.Latitude) And (CurrentSite.Latitude) <> 0.0 Then
                Dim d2 As Double = distance(dr("PMLatitude"), dr("PMLongitude"), CurrentSite.Latitude, CurrentSite.Longitude, "M")

                dr("PMCLOSE") = d2
                dr("ORIGPMCLOSE") = Math.Round(d2, 2)
            Else
                dr("PMCLOSE") = DBNull.Value
            End If

            If IsDBNull(dr("ORIGPMCLOSE")) OrElse dr("ORIGPMCLOSE") = "" Then dr("ORIGPMCLOSE") = "Unknown"
            If IsDBNull(dr("ORIGAMCLOSE")) OrElse dr("ORIGAMCLOSE") = "" Then dr("ORIGAMCLOSE") = "Unknown"

            If IsDBNull(dr("AMCLOSE")) And IsDBNull(dr("PMCLOSE")) Then
                If dr("AssignedArea") = 1 Then
                    dr("AMCLOSE") = 9
                    dr("PMCLOSE") = 9
                Else
                    dr("AMCLOSE") = 21
                    dr("PMCLOSE") = 21
                End If

            ElseIf IsDBNull(dr("AMCLOSE")) Then
                dr("AMCLOSE") = dr("PMCLOSE") - CInt(8)

            ElseIf IsDBNull(dr("PMCLOSE")) Then
                dr("PMCLOSE") = dr("AMCLOSE") - CInt(8)

            End If

            dr("COMBCLOSE") = CInt(dr("PMCLOSE")) + CInt(dr("AMCLOSE"))
        Next

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '''''''''''''''''''''''''''''SCORING SECTION'''''''''''''''''''''''''''''''

        For Each row As DataRowView In AppointmentsView

            Dim score As Integer = (DateDiff(DateInterval.Day, CDate(row("Date")), dtpFromDate.Value) * 4) ' multiply to increase effect

            If row("AssignedArea") = 1 Then score = score + 25
            score = score + (DateDiff(DateInterval.Day, CDate(row("Date")), Now.Date) * 2) ' general time score - sooner the better

            If jobtype = "SERVICE" Or SecondVisit Then  ''' assume second visit is service
                score += 30
                score = score + ((row("ServPri") * -1))
                If row("ServPri") = 0 Then
                    score += -1000
                End If

            ElseIf jobtype = "BREAKDOWN" Then

                If row("InTarget") = 1 Then score = score + 50
                score = score + (DateDiff(DateInterval.Day, CDate(row("Date")), targettime) * 2)

                score = score + (row("BreakPri") * -1)
                If row("BreakPri") = 0 Then
                    score += -1000
                End If
            End If
            score = score + ((row("COMBCLOSE") * -1) * 2) ' the further away the more it deducts

            row("SCORE") = score

        Next

        'multiday checks

        Dim days As Integer = 0
        txtHrs.Text = If((txtHrs.Text.Length = 0), "0", txtHrs.Text)
        txtDays.Text = If((txtDays.Text.Length = 0), "0", txtDays.Text)
        If (txtDays.Text) > 0 AndAlso txtHrs.Text > 0 Then
            days = CInt(txtDays.Text) + 1
        End If
        Dim engCollection As List(Of Integer) = New List(Of Integer)

        Dim appointmentstableCopy As DataTable = AppointmentsView.Table.Copy

        If CInt(txtHrs.Text) > 8 Or CInt(txtDays.Text) > 0 Then

            For Each dr As DataRow In AppointmentsView.Table.Rows ' Fucked up way of getting unique values
                If engCollection.Contains(dr("EngineerID")) Then
                Else
                    engCollection.Add(dr("EngineerID"))
                End If

            Next

            For Each ii As Integer In engCollection

                If DB.EngineerVisits.Get_Appointments_ForEngineer(dtpFromDate.Value.ToString("yyyy-MM-dd"), 120, ii, days).Rows.Count = days Then
                    ' pass
                Else

                    Dim drs As DataRow() = appointmentstableCopy.Select("EngineerID = " & ii)
                    For Each dr As DataRow In drs
                        appointmentstableCopy.Rows.Remove(dr)
                    Next

                End If

            Next

            AppointmentsView.Table = appointmentstableCopy

        End If

        ''''' SORTING

        AppointmentsView.Sort = "Score DESC"

        If jobtype = "SERVICE" Then
            '  AppointmentsView.Sort = "InTarget DESC,AssignedArea DESC, ServPri ASC, COMBCLOSE ASC, AMCLOSE ASC, PMCLOSE ASC, daynumber ASC ,cbuoc ASC, TotalRemaining DESC, RemainingAM DESC,RemainingPM DESC"
        Else
            ' AppointmentsView.Sort = "InTarget DESC,AssignedArea DESC, BreakPri ASC, COMBCLOSE ASC, AMCLOSE ASC, PMCLOSE ASC, daynumber ASC ,cbuoc ASC, TotalRemaining DESC, RemainingAM DESC,RemainingPM DESC"
        End If

        SchedulerAppsView.Sort = "InTarget Desc, daynumber asc, TotalRemaining DESC, RemainingAM ASC,RemainingPM ASC"

        Dim buttons As Button() = {btnOption1, btnOption2, btnOption3, btnOption4, btnOption5, btnOption6, btnOption7, btnOption8, btnOption10}

        Dim buts As Integer = 0
        Dim c As Integer = 0
        Dim i As Integer = 0
        '  For i As Integer = 0 To 4 ' appoints - 1

        While c < AppointmentsView.Count

            If i = 8 Then Exit While

            Dim detail As String = ""
            Dim aa As String = ""
            Dim callo As String = ""
            Dim target As String = ""
            If AppointmentsView(c)("AssignedArea") = 1 Then
                aa = "Yes"
            Else
                aa = "No"
            End If

            If AppointmentsView(c)("cbuoc") = 1 Then
                callo = "Yes"
            Else
                callo = "No"
            End If

            If AppointmentsView(c)("InTarget") = 1 Then
                target = "Yes"
            Else
                target = "No"
            End If

            ' code will stop offering 8AM's if its today
            If AppointmentsView(c)("EightAMAvail") = "1" And AppointmentsView(c)("remainingAM") >= reqtime And CDate(CDate(AppointmentsView(c)("Date")).ToString("dd/MM/yyyy") & " 00:00") > CDate(DateTime.Today.ToString("dd/MM/yyyy") & " 08:00") Then  '' can offer 8AM

                detail = "Distance : " & AppointmentsView(c)("ORIGAMCLOSE") & "  Area Engineer : " & aa & "  On Call Engineer : " & callo & "  In Target : " & target

                If AppointmentsView(c)("AMCLOSE") < 22 Then

                    If Combo.GetSelectedItemValue(cboAppointment) = 69938 Or Combo.GetSelectedItemValue(cboAppointment) = 0 Then

                        buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " 8AM"
                        buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^8AM" & "^" & detail
                        buttons(i).Visible = True
                        DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                        buttons(i).Refresh()

                        i = i + 1
                        buts = buts + 1
                        If i = 8 Then Exit While
                    End If
                End If

            End If

            'anytime
            If AppointmentsView(c)("remainingAM") >= reqtime And AppointmentsView(c)("remainingPM") >= reqtime And AppointmentsView(c)("AMCLOSE") < 22 And AppointmentsView(c)("PMCLOSE") < 22 Then '' can offer am or pm

                If DateTime.Now.Hour > 9 And CDate(AppointmentsView(c)("Date")).ToString("dd/MM/yyyy") = Today.ToString("dd/MM/yyyy") Then  ' its too late to book mornings

                    'nope
                Else

                    If Combo.GetSelectedItemValue(cboAppointment) = 69943 Or Combo.GetSelectedItemValue(cboAppointment) = 0 Then

                        detail = "Distance : " & AppointmentsView(c)("ORIGAMCLOSE") & "  Area Engineer : " & aa & "  On Call Engineer : " & callo & "  In Target : " & target

                        buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " AM"
                        buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^AM" & "^" & detail
                        buttons(i).Visible = True
                        'give a chance in hell

                        DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                        buttons(i).Refresh()
                        i = i + 1
                        buts = buts + 1
                        If i = 8 Then Exit While

                    End If

                End If

                If Combo.GetSelectedItemValue(cboAppointment) = 69944 Or Combo.GetSelectedItemValue(cboAppointment) = 0 Then
                    detail = "Distance : " & AppointmentsView(c)("ORIGPMCLOSE") & "  Area Engineer : " & aa & "  On Call Engineer : " & callo & "  In Target : " & target
                    buts = buts + 1
                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " PM"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^PM" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                    buttons(i).Refresh()
                    i = i + 1
                End If

                If Combo.GetSelectedItemValue(cboAppointment) = 69945 Then
                    buts = buts + 1

                    detail = "Distance : " & AppointmentsView(c)("ORIGPMCLOSE") & "  Area Engineer : " & aa & "  On Call Engineer : " & callo & "  In Target : " & target

                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " ANYTIME"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^ANY" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                    buttons(i).Refresh()

                    i = i + 1
                End If

                If Combo.GetSelectedItemValue(cboAppointment) = 69939 And AppointmentsView(c)("EIGHT_TWELVE") >= reqtime Then

                    detail = "Distance : " & AppointmentsView(c)("ORIGAMCLOSE") & "  Area Engineer : " & aa & "  On Call Engineer : " & callo & "  In Target : " & target

                    buts = buts + 1
                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " 8AM - 12PM"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^8-12" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))

                    buttons(i).Refresh()
                    i = i + 1
                End If

                If Combo.GetSelectedItemValue(cboAppointment) = 69940 And AppointmentsView(c)("TEN_TWO") >= reqtime Then

                    detail = "Distance : " & AppointmentsView(c)("ORIGPMCLOSE") & "  Area Engineer : " & aa & "  On Call Engineer : " & callo & "  In Target : " & target
                    buts = buts + 1
                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " 10AM - 2PM"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^10-2" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))

                    buttons(i).Refresh()
                    i = i + 1
                End If

                If Combo.GetSelectedItemValue(cboAppointment) = 69941 And AppointmentsView(c)("TWELVE_FOUR") >= reqtime Then

                    detail = "Distance : " & AppointmentsView(c)("ORIGPMCLOSE") & "  Area Engineer : " & aa & "  On Call Engineer : " & callo & "  In Target : " & target
                    buts = buts + 1
                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " 12PM - 4PM"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^12-4" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))

                    buttons(i).Refresh()
                    i = i + 1
                End If

                If Combo.GetSelectedItemValue(cboAppointment) = 69942 And AppointmentsView(c)("TWO_SIX") >= reqtime Then
                    buts = buts + 1
                    detail = "Distance : " & AppointmentsView(c)("ORIGPMCLOSE") & "  Area Engineer : " & aa & "  On Call Engineer : " & callo & "  In Target : " & target
                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " 2PM - 6PM"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^2-6" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                    buttons(i).Refresh()
                    i = i + 1
                End If

                'AM

            ElseIf AppointmentsView(c)("remainingAM") >= reqtime And AppointmentsView(c)("AMCLOSE") < 22 Then  '' offer AM

                If DateTime.Today.Hour > 9 And CDate(AppointmentsView(c)("Date")).ToString("dd/MM/yyyy") = Today.ToString("dd/MM/yyyy") Then  ' its too late to book mornings

                    'nope
                Else

                    detail = "Distance : " & AppointmentsView(c)("ORIGAMCLOSE") & "  Area Engineer : " & aa & "  On Call Engineer : " & callo & "  In Target : " & target

                    If Combo.GetSelectedItemValue(cboAppointment) = 69943 Or Combo.GetSelectedItemValue(cboAppointment) = 0 Then
                        buts = buts + 1
                        buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " AM"
                        buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^AM" & "^" & detail
                        buttons(i).Visible = True

                        DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                        buttons(i).Refresh()
                        i = i + 1
                    End If

                    If Combo.GetSelectedItemValue(cboAppointment) = 69945 Then
                        buts = buts + 1
                        buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " ANYTIME"
                        buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^ANY" & "^" & detail
                        buttons(i).Visible = True

                        DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                        buttons(i).Refresh()
                        i = i + 1

                    End If

                    If Combo.GetSelectedItemValue(cboAppointment) = 69939 And AppointmentsView(c)("EIGHT_TWELVE") >= reqtime Then
                        buts = buts + 1
                        buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " 8AM - 12PM"
                        buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^8-12" & "^" & detail
                        buttons(i).Visible = True

                        DoButtonColor(AppointmentsView(c), targettime, buttons(i))

                        buttons(i).Refresh()
                        i = i + 1
                    End If

                    If Combo.GetSelectedItemValue(cboAppointment) = 69940 And AppointmentsView(c)("TEN_TWO") >= reqtime Then
                        buts = buts + 1
                        buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " 10AM - 2PM"
                        buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^10-2" & "^" & detail
                        buttons(i).Visible = True

                        DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                        buttons(i).Refresh()

                        i = i + 1
                    End If

                End If

            ElseIf AppointmentsView(c)("remainingPM") >= reqtime And AppointmentsView(c)("PMCLOSE") < 22 Then  '' Offer PM

                detail = "Distance : " & AppointmentsView(c)("ORIGPMCLOSE") & "  Area Engineer : " & aa & "  On Call Engineer : " & callo & "  In Target : " & target

                If Combo.GetSelectedItemValue(cboAppointment) = 69944 Or Combo.GetSelectedItemValue(cboAppointment) = 0 Then
                    buts = buts + 1
                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " PM"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^PM" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                    buttons(i).Refresh()
                    i = i + 1
                End If

                If Combo.GetSelectedItemValue(cboAppointment) = 69945 Then
                    buts = buts + 1
                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " ANYTIME"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^ANY" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                    buttons(i).Refresh()
                    i = i + 1

                End If

                If Combo.GetSelectedItemValue(cboAppointment) = 69940 And AppointmentsView(c)("TEN_TWO") >= reqtime Then
                    buts = buts + 1
                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " 10AM - 2PM"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^10-2" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))
                    buttons(i).Refresh()

                    i = i + 1
                End If

                If Combo.GetSelectedItemValue(cboAppointment) = 69941 And AppointmentsView(c)("TWELVE_FOUR") >= reqtime Then

                    buts = buts + 1
                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " 12PM - 4PM"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^12-4" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))

                    buttons(i).Refresh()
                    i = i + 1
                End If

                If Combo.GetSelectedItemValue(cboAppointment) = 69942 And AppointmentsView(c)("TWO_SIX") >= reqtime Then
                    buts = buts + 1
                    buttons(i).Text = AppointmentsView(c)("name") & vbNewLine & AppointmentsView(c)("Date") & " 2PM - 6PM"
                    buttons(i).Tag = AppointmentsView(c)("EngineerID") & "^" & AppointmentsView(c)("Date") & "^2-6" & "^" & detail
                    buttons(i).Visible = True

                    DoButtonColor(AppointmentsView(c), targettime, buttons(i))

                    buttons(i).Refresh()
                    i = i + 1
                End If

            End If

            'buttons(i).Text = AppointmentsView.Table.Rows(i)("name") & vbNewLine & AppointmentsView.Table.Rows(i)("Date") & " " & AppointmentsView.Table.Rows(i)("TimeOfDay")
            'buttons(i).Tag = AppointmentsView.Table.Rows(i)("EngineerID") & "^" & AppointmentsView.Table.Rows(i)("Date") & "^" & AppointmentsView.Table.Rows(i)("TimeOfDay")
            c = c + 1

        End While

        Dim appoints As Integer = buts
        If buts < 8 Then
            appoints = buts
            Dim c1 As Integer = 0
            For Each bt As Button In buttons
                c1 = c1 + 1
                If c1 > appoints Then
                    bt.Visible = False
                End If

            Next

        End If

        Dim fail As Boolean
        Dim appointmentperiod As String

        Select Case Combo.GetSelectedItemValue(cboAppointment)
            Case Enums.AppointmentsPicklist.FirstCall
                If Today.ToString("tt") = "PM" Then
                    appointmentperiod = "PM"
                Else
                    appointmentperiod = "AM"
                End If

            Case Enums.AppointmentsPicklist.Am
                If Today.ToString("tt") = "PM" Then
                    appointmentperiod = "PM"
                Else
                    appointmentperiod = "AM"
                End If

            Case Enums.AppointmentsPicklist.Pm

                appointmentperiod = "PM"

            Case Enums.AppointmentsPicklist.EightAmTillTwelvePm ' 8 - 12
                If Today.ToString("tt") = "PM" Then
                    appointmentperiod = "12PM - 4PM"
                Else
                    appointmentperiod = "8AM - 12PM"
                End If

            Case Enums.AppointmentsPicklist.TenAmTillTwoPm ' 10- 2
                If Today.ToString("tt") = "PM" Then
                    appointmentperiod = "12PM - 4PM"
                Else
                    appointmentperiod = "10AM - 2PM"
                End If

            Case Enums.AppointmentsPicklist.TwelvePmTillFourPm ' 12- 4

                appointmentperiod = "12PM - 4PM"

            Case Enums.AppointmentsPicklist.TwoPmTillSixPm ' 2 - 6

                appointmentperiod = "2PM - 6PM"

            Case Enums.AppointmentsPicklist.Anytime

                appointmentperiod = "ANYTIME"

        End Select

        For Each dr As DataRowView In SchedulerAppsView

            If CDate(dr("Date")) >= CDate(Date.Now.AddHours(8).ToString("dd/MM/yyyy")) Then
                If CDate(dr("Date")).ToString("dd/MM/yyyy") = targettime.ToString("dd/MM/yyyy") Then
                    'If dr("RemainingAM") < reqtime And targettime.ToString("tt") = "AM" Then 'No AM appointment
                    '    fail = True
                    'Else
                    ' all ok
                    buttons(appoints).Text = dr("name") & vbNewLine & CDate(dr("Date")).ToString("dd/MM/yyyy") & " " & appointmentperiod
                    buttons(appoints).Tag = dr("EngineerID") & "^" & CDate(dr("Date")).ToString("dd/MM/yyyy") & "^" & appointmentperiod
                    buttons(appoints).Visible = True
                    If CDate(dr("Date")).ToString("dd/MM/yyyy") = targettime.ToString("dd/MM/yyyy") And CDate(dr("Date") & " 18:00") < targettime Or (CDate(dr("Date")).ToString("dd/MM/yyyy") = Today.ToString("dd/MM/yyyy") And Today.ToString("tt") = "PM") Then
                        buttons(appoints).BackColor = Color.Coral

                    ElseIf CDate(dr("Date") & " 12:00") < targettime Then
                        buttons(appoints).BackColor = Color.PaleGreen
                    Else
                        buttons(appoints).BackColor = Color.Red

                    End If
                    fail = False
                    Exit For
                    'End If
                Else 'CDate(dr("Date")) < targettime Then
                    'all ok
                    buttons(appoints).Text = SchedulerAppsView(0)("name") & vbNewLine & CDate(dr("Date")).ToString("dd/MM/yyyy") & " " & appointmentperiod
                    buttons(appoints).Tag = SchedulerAppsView(0)("EngineerID") & "^" & CDate(dr("Date")).ToString("dd/MM/yyyy") & "^" & appointmentperiod
                    buttons(appoints).Visible = True
                    If CDate(dr("Date")).ToString("dd/MM/yyyy") = targettime.ToString("dd/MM/yyyy") And CDate(dr("Date") & " 18:00") < targettime Or (CDate(dr("Date")).ToString("dd/MM/yyyy") = Today.ToString("dd/MM/yyyy") And Today.ToString("tt") = "PM") Then
                        buttons(appoints).BackColor = Color.Coral

                    ElseIf CDate(dr("Date") & " 12:00") < targettime Then
                        buttons(appoints).BackColor = Color.PaleGreen
                    Else
                        buttons(appoints).BackColor = Color.Red

                    End If
                    fail = False
                    Exit For

                End If
            End If

            fail = True

        Next

        If fail = True Then

            buttons(appoints).Visible = False

        End If

        Me.Cursor = Cursors.Default

    End Sub

#End Region

    Public Function distance(ByVal lat1 As Double, ByVal lon1 As Double, ByVal lat2 As Double, ByVal lon2 As Double, ByVal unit As Char) As Double
        Dim theta As Double = lon1 - lon2
        Dim dist As Double = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta))
        dist = Math.Acos(dist)
        dist = rad2deg(dist)
        dist = dist * 60 * 1.1515
        If unit = "K" Then
            dist = dist * 1.609344
        ElseIf unit = "N" Then
            dist = dist * 0.8684
        End If
        Return dist
    End Function

    Private Function deg2rad(ByVal deg As Double) As Double
        Return (deg * Math.PI / 180.0)
    End Function

    Private Function rad2deg(ByVal rad As Double) As Double
        Return rad / Math.PI * 180.0
    End Function

    Function AppointmentStrip(ByRef appointments As DataTable, ByVal levelslist As List(Of Integer), Optional ByVal IsScheduler As Boolean = False) As DataTable

        Dim engineerLevels As DataTable = DB.EngineerLevel.GetAllInDate().Table

        For i1 As Integer = appointments.Rows.Count - 1 To 0 Step -1

            Dim dr As DataRow = appointments.Rows.Item(i1)

            If dr("keep") = 0 And dr("remove") = 0 Then

                '' remove non qualified engineers

                '   Dim engineerLevels As DataTable = DB.EngineerLevel.Get(dr("EngineerID")).Table
                Dim removeengineer As Boolean = True
                Dim AssignedArea As Boolean = True

                Dim cbuoc As Boolean = False
                For Each i As Integer In levelslist

                    For Each dr2 As DataRow In engineerLevels.Select("EngineerID = " & dr("EngineerID"))

                        If dr2("ManagerID") = 69698 Then 'hes on call and avaialble
                            cbuoc = True
                        End If

                        If i = dr2("ManagerID") Then
                            removeengineer = False
                            Exit For
                        End If

                        removeengineer = True
                    Next

                    If removeengineer = True Then Exit For

                Next

                If jobtype = "SERVICE" Then
                    If Not IsDBNull(dr("ServPri")) AndAlso dr("ServPri") = "10" Then 'And Not IsScheduler Then
                        removeengineer = True
                    End If

                ElseIf jobtype = "BREAKDOWN" Then
                    If Not IsDBNull(dr("BreakPri")) AndAlso dr("BreakPri") = "10" Then 'And Not IsScheduler Then
                        removeengineer = True
                    End If

                End If

                If cbuoc AndAlso dr("ONCALL") = 1 Then
                    dr("cbuoc") = 1
                End If

                If removeengineer = False Then
                    removeengineer = True ' will remove unless
                    If IsScheduler Then
                        removeengineer = True
                    Else
                        AssignedArea = False
                        removeengineer = False
                    End If

                    Dim engpostcodes As List(Of String) = New List(Of String)
                    Dim dt As DataTable = DB.EngineerPostalRegion.GetTicked(dr("EngineerID")).Table
                    For Each row As DataRow In dt.Rows
                        engpostcodes.Add(row("Name"))
                    Next
                    If engpostcodes.Contains(CurrentSite.Postcode.Substring(0, CurrentSite.Postcode.IndexOf("-"))) Then
                        If IsScheduler Then
                            removeengineer = False
                        Else
                            AssignedArea = True
                            removeengineer = False
                        End If

                    End If

                End If

                If cbuoc Then
                    For Each dr3 As DataRow In appointments.Select("engineerid = " & dr("EngineerID") & " AND ONCALL = 0")   ' dont remove the oncall engineer days
                        If removeengineer Then
                            dr3("remove") = 1
                        Else
                            dr3("keep") = 1
                            If AssignedArea = False Then
                                dr3("AssignedArea") = 0
                            End If

                        End If
                    Next
                Else
                    For Each dr3 As DataRow In appointments.Select("engineerid = " & dr("EngineerID"))
                        If removeengineer Then
                            dr3("remove") = 1
                        Else
                            dr3("keep") = 1
                            If AssignedArea = False Then
                                dr3("AssignedArea") = 0
                            End If
                        End If
                    Next

                End If

            End If ' end of if that checks if its already been marked to be deleted

        Next

        Dim dtr As DataRow() = appointments.Select("remove = 1  AND CBUOC = 0")

        For Each dr9 As DataRow In dtr  '  remove the engineers not eligable
            appointments.Rows.Remove(dr9)
        Next

        Dim Contract247 As List(Of Integer) = New List(Of Integer)

        Contract247.AddRange({67353, 68032, 68376})

        'Saturdays / bank holidays - FOR EM AND PLAT OR RECALL

        Dim includeweekends As Boolean = False
        Dim dt2 As DataTable = DB.Customer.Priorities_Get_For_CustomerID_Active(CurrentCustomer.CustomerID, Combo.GetSelectedItemValue(cboPriority)).Table
        If dt2.Rows.Count = 1 Then
            Dim dr1 As DataRow = dt2.Rows(0)
            includeweekends = dr1("IncludeWeekends")
        End If

        If (Combo.GetSelectedItemValue(cboPriority) = 66983 Or includeweekends) OrElse (Not CurrentContract Is Nothing AndAlso (Contract247.Contains(CurrentContract.ContractTypeID)) OrElse chkRecall.Checked) Then

            ' remove unless its the scheduler or a on call engineer

            'For Each dr10 As DataRow In appointments.Select("1=1")
            '    If (CDate(dr10("thedate")).DayOfWeek = DayOfWeek.Saturday OrElse CDate(dr10("thedate")).DayOfWeek = DayOfWeek.Sunday OrElse dr10("BH") = 1) And IsScheduler = False And dr10("cbuoc") = 0 Then
            '        appointments.Rows.Remove(dr10)
            '    End If

            'Next
        Else
            'remove BH and saturdays
            For Each dr10 As DataRow In appointments.Select("1=1")

                If CDate(dr10("thedate")).DayOfWeek = DayOfWeek.Saturday OrElse CDate(dr10("thedate")).DayOfWeek = DayOfWeek.Sunday OrElse dr10("BH") = 1 Then
                    appointments.Rows.Remove(dr10)
                End If
            Next

        End If

        Return appointments

    End Function

    Public Function workingdays(ByVal Startdate As String, ByVal Workingdaysin As Integer) As String

        Dim count = 0

        Dim dvBankHolidays As DataView = DB.TimeSlotRates.BankHolidays_GetAll

        For i As Integer = 0 To Workingdaysin
            count = count + 1
            Dim weekday As DayOfWeek = CDate(Startdate).AddDays(count).DayOfWeek
            If dvBankHolidays.Table.Select("BankHolidayDate='" & CDate(Strings.Format(CDate(Startdate).AddDays(count), "dd/MM/yyyy")) & "'").Length > 0 Then

            ElseIf weekday = DayOfWeek.Saturday Or weekday = DayOfWeek.Sunday Then
            Else
                i = i + 1
            End If

        Next
        Return CDate(Startdate).AddDays(count).ToString()
    End Function

#Region "tab configuration"

    Dim tab As Integer = 1

    'Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcSites.SelectedIndexChanged
    '    tcSites.SelectedTab = tcSites.TabPages.Item(tab)

    'End Sub

    '  event of tabpages

    Private Sub btnxx1_Click(sender As Object, e As EventArgs) Handles btnxx1.Click, btnxx2.Click, btnxx3.Click, btnxx4.Click, btnxx5.Click, btnxx6.Click, btnxxExistingJobBack.Click
        tab = tcSites.SelectedIndex - 1
        tcSites.SelectedTab = tcSites.TabPages.Item(tab)
        Temp.Clear()
    End Sub

#End Region

    Private Sub dtpFromDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFromDate.ValueChanged
        FindAppointments()
    End Sub

    Private Sub cboAppointment_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboAppointment.SelectedIndexChanged
        If tcSites.TabPages.Contains(TabBook) Then
            FindAppointments()
        End If

    End Sub

    Private Sub DoButtonColor(ByVal dr As DataRowView, ByVal targettime As DateTime, ByRef button As Button)

        If CInt(dr("SCORE")) > 10 Then

            button.BackColor = Color.PaleGreen

        ElseIf CInt(dr("SCORE")) > -10 Then

            button.BackColor = Color.Coral
        Else

            button.BackColor = Color.Red

        End If

    End Sub

    Private Sub cboEngineer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEngineer.SelectedIndexChanged
        '  If Combo.GetSelectedItemValue(cboEngineer) > 0 Then
        If tab > 4 Then
            FindAppointments()
        End If

        'End If

    End Sub

    Public Sub ClearSiteDetails()
        DGVSites.DataSource = Nothing
        txtAddress1.Text = ""
        txtAddress2.Text = ""
        txtAddress3.Text = ""
        txtPostcode.Text = ""
        txtCustomer.Text = ""
        txtEmail.Text = ""
        txtFirstName.Text = ""
        txtMob.Text = ""

        txtSurname.Text = ""
        txtTel.Text = ""
        chkCert.Visible = False
        chkCert.Checked = False
        lblcert.Visible = False
        txtAdditional.Text = ""
        CurrentContract = Nothing
        txtContractRef.Text = ""
        txtName.Text = ""
        txtPONumber.Text = ""
        txtSiteNotes.Text = ""
        Combo.SetSelectedComboItem_By_Value(cboTitle, 0)
        DGVSites.DataSource = Nothing
    End Sub

    Public Sub Reset()

        'For Each dr As DataRow In DTPrivNotes.Select("JobNoteID = 0")

        '    DB.Job.SaveJobNotes(0, dr("Note"), dr("EditedByUserID"), CurrentJob.JobID, dr("CreatedByUserID")).ToTable()

        'Next

        btnxxNewJob.BackColor = SystemColors.Control
        cbotypeWiz.BackColor = System.Drawing.SystemColors.Window
        txtHrs.Text = ""
        txtDays.Text = ""
        btnxxExistingJobNext.Visible = False
        btnxxJobNext.Visible = False
        btnxxSiteNext.Visible = False
        btnxxDetailsNext.Visible = False

        For Each c As Control In tabJobType.Controls   ' neat way to toggle button colors
            If TypeOf c Is Button Then
                c.BackColor = SystemColors.Control

            End If
        Next

        txtSearch.Text = ""

        '''''' HERE FOR ANY CLEARING '''''''
        Try
            tab = 0
            tcSites.TabPages(0).Enabled = True
            tcSites.TabPages.Remove(tabProp)
            tcSites.TabPages.Add(tabProp)
            tcSites.TabPages.Remove(tabExistingJobs)
            tcSites.TabPages.Remove(tabJobType)
            tcSites.TabPages.Remove(tabJobDetails)
            tcSites.TabPages.Remove(tabAppliance)
            tcSites.TabPages.Remove(TabCharging)
            tcSites.TabPages.Remove(tabAdditional)
            tcSites.TabPages.Remove(TabBook)
            tcSites.TabPages.Remove(tcComplete)
            tcSites.SelectedIndex = 0
            '  tcSites.SelectedIndex = 1
            Temp.Clear()
        Catch ex As Exception
            tcSites.SelectedIndex = 0
        End Try

        GasConfirmedInBoiler = True

        Dim dv As New DataView
        Dim dt1 As New DataTable
        dt1.TableName = "1"
        dt1.Columns.Add("SypID")
        dt1.Columns.Add("Code")
        dt1.Columns.Add("Description")

        dv.Table = dt1
        SympDataView = dv
        DGSymptoms.DataSource = dt1
        SiteChange = False

        BookingDetail = ""

        visitsBooked = 0

        Try
            Dim c1 As Control() = ParentForm.Controls.Find("btnSaveProg", True)
            Dim b As Button = c1(0)
            b.Visible = False

            Dim c2 As Control() = ParentForm.Controls.Find("btnPrivateNotes", True)
            Dim b2 As Button = c2(0)
            b2.Visible = False
        Catch ex As Exception

        End Try
        RunFilter()

    End Sub

    Public Sub SaveProgress()

        BookingDetail = ""

        visitsBooked += 1
        If tab < 5 Then
            DoCharging()
        End If

        CurrentJob = CreateVisits(0, Date.MinValue, "", priTime, "", visitsBooked)
        If chkKeepTogether.Checked And secTime > 0 Then
            visitsBooked += 1
            CreateVisits(0, Date.MinValue, "", secTime, "", visitsBooked)
            'ElseIf secTime > 0 Then
            '    '  jobtype = "SERVICE"    ''''''''''''''''''''''''''''''''''' HARD CODE DODGYNESS
            '    FindAppointments(True)   ''' -  lets go round again '''' :)

        End If
        lblBookedInfo.Text = BookingDetail & " (Click here to view job)"

        Try
            Dim c1 As Control() = ParentForm.Controls.Find("btnSaveProg", True)
            Dim b As Button = c1(0)
            b.Visible = False

            Dim c2 As Control() = ParentForm.Controls.Find("btnPrivateNotes", True)
            Dim b2 As Button = c2(0)
            b2.Visible = False
        Catch ex As Exception

        End Try
        '   CreateVisits(0, Date.MinValue, "", 0, 1)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        Reset()
    End Sub

    Public Sub Notes()

        Dim f As New FRMPrivNotes

        f.dt = DTPrivNotes

        f.ShowDialog()

        DTPrivNotes = f.dt

        If tcSites.TabCount = 9 Then ' complete tab
        End If
        For Each dr As DataRow In DTPrivNotes.Select("JobNoteID = 0")

            DB.Job.SaveJobNotes(0, dr("Note"), dr("EditedByUserID"), jobids, dr("CreatedByUserID"))

        Next
        DTPrivNotes = DB.Job.GetAllJobNotes(CurrentSite.SiteID)

    End Sub

    Private Sub chkKeepTogether_CheckedChanged(sender As Object, e As EventArgs) Handles chkKeepTogether.CheckedChanged
        If tcSites.SelectedIndex = 6 Then
            FindAppointments()
        End If

    End Sub

    Private Sub Button_Paint(sender As Object, e As PaintEventArgs) Handles btnOption1.Paint, btnOption2.Paint, btnOption3.Paint, btnOption4.Paint, btnOption5.Paint, btnOption6.Paint, btnOption7.Paint, btnOption8.Paint, btnOption10.Paint

        Dim button2 As Button = CType(sender, Button)
        Dim detail As String = ""
        Try
            detail = button2.Tag.ToString.Split("^")(3)
        Catch ex As Exception
            detail = ""
        End Try

        Dim bfont As Font = New Font("Verdana", 7)

        Dim stringFormat As StringFormat = New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        e.Graphics.DrawString(detail, bfont, Brushes.Black, CInt((button2.Width / 2)), button2.Height - 10, stringFormat)

    End Sub

    Private Sub btnxx_Click(sender As Object, e As EventArgs) Handles btnxxKitchens.Click, btnxxElectrical.Click, btnxxMultiTrade.Click, btnxxPlumbing.Click, btnxxCarpentry.Click, btnxxExternalBM.Click, btnxxOther.Click, BtnxxService.Click, btnxxBreakdown.Click, btnxxSOR.Click
        For Each c As Control In tabJobType.Controls   ' neat way to toggle button colors
            If TypeOf c Is Button Then
                If c.Name = CType(sender, Button).Name Then
                    c.BackColor = System.Drawing.Color.PaleGreen
                    jobtype = c.Text.ToUpper
                    If Not c.Tag Is Nothing AndAlso c.Tag.ToString.Length > 0 Then
                        Combo.SetSelectedComboItem_By_Value(cbotypeWiz, c.Tag)  ' set the cbojobtype if there is a tag on the button
                    End If

                    btnxxJobNext.Visible = True
                    If c.Name = "btnxxSOR" Then
                        pnlSOR.Visible = True
                        jobtype = "SOR"
                        pnlSOR.Visible = True
                        Combo.SetUpCombo(Me.cboSOR, DB.CustomerScheduleOfRate.GetAll_For_CustomerID(CurrentCustomer.CustomerID).Table, "CustomerScheduleOfRateID", "Description", Entity.Sys.Enums.ComboValues.Please_Select)

                        If DGSOR.RowCount > 0 Then
                            If CurrentSite.PoNumReqd And txtPONumber.Text.Length = 0 Then
                            Else

                                If cboPriority.Items.Count > 0 And Combo.GetSelectedItemValue(cboPriority) < 1 Then
                                Else
                                    btnxxJobNext.Visible = True
                                End If
                            End If
                        Else
                            btnxxJobNext.Visible = False
                        End If
                    End If
                    If c.Name = "btnxxOther" Then
                        btnxxOther.Visible = False
                        pnlSymptoms.Visible = True
                        lbltype.Visible = True
                        cbotypeWiz.Visible = True
                        cbotypeWiz.BackColor = System.Drawing.Color.PaleGreen
                        If Combo.GetSelectedItemValue(cbotypeWiz) < 1 Then
                            btnxxJobNext.Visible = False
                        Else
                            If CurrentSite.PoNumReqd And txtPONumber.Text.Length = 0 Then
                            Else

                                If cboPriority.Items.Count > 0 And Combo.GetSelectedItemValue(cboPriority) < 1 Then
                                Else
                                    btnxxJobNext.Visible = True
                                End If
                            End If
                            jobtype = Combo.GetSelectedItemDescription(cbotypeWiz).ToUpper
                        End If
                    End If
                    If c.Name = "BtnxxService" Then
                        pnlSymptoms.Visible = False
                        chkCert.Checked = True
                    End If
                    If cboPriority.Items.Count > 1 Then
                        lblPriority.Visible = True
                        cboPriority.Visible = True
                    Else
                        lblPriority.Visible = False
                        cboPriority.Visible = False
                    End If
                    lblAdditional.Visible = True
                    txtAdditional.Visible = True
                ElseIf c.Parent.Name = "tabJobType" Then
                    c.BackColor = System.Drawing.SystemColors.Control
                    If c.Name = "btnxxOther" Then
                        c.Visible = True
                        lbltype.Visible = False
                        cbotypeWiz.Visible = False
                        cbotypeWiz.BackColor = System.Drawing.SystemColors.Window
                    End If
                    If c.Name = "btnxxSOR" Then
                        pnlSOR.Visible = False
                    End If

                End If
            End If
        Next

    End Sub

    Private Sub cboPayTerms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayTerms.SelectedIndexChanged

        If Combo.GetSelectedItemValue(cboPayTerms) < 1 Then
            btnxxChargeNext.Visible = False
        Else
            btnxxChargeNext.Visible = True
        End If
        '   DoCharging()

        visitcharge1 = CDbl(txtCharge.Text)
        visitterm1 = Combo.GetSelectedItemDescription(cboPayTerms)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        FindAppointments()
    End Sub

    Private Sub txtDiscountCode_TextChanged(sender As Object, e As EventArgs) Handles txtDiscountCode.TextChanged

        CheckDiscount()

    End Sub

    Private Sub CheckDiscount()

        PromotionText = ""

        Dim dr() As DataRow = PromotionsDT.Select("Code = '" & txtDiscountCode.Text & "'")

        If dr.Length > 0 Then
            picCross.Visible = False
            picTick.Visible = True

            txtCharge.Text = CDbl(FinalCharge) - (CDbl(FinalCharge) * (dr(0)("DiscountPercent") / 100))

            txtPayInst.Text = FinalText & vbNewLine & "Promotion Applied: " & dr(0)("PromotionText") & " = -" & Format(CDbl(CStr(Math.Round((CDbl(FinalCharge) * (dr(0)("DiscountPercent") / 100)), 2))), "C")
            PromotionText = "Promotion Applied: " & dr(0)("PromotionText") & " = -" & Format(CDbl(CStr(Math.Round((CDbl(FinalCharge) * (dr(0)("DiscountPercent") / 100)), 2))), "C")
        Else
            picCross.Visible = True
            picTick.Visible = False
            txtCharge.Text = FinalCharge
            txtPayInst.Text = FinalText
        End If

        If txtDiscountCode.Text.Length = 0 Then
            picCross.Visible = False
            picTick.Visible = False
            txtCharge.Text = FinalCharge
            txtPayInst.Text = FinalText
        End If

        txtCharge.Text = Format(CDbl(txtCharge.Text), "C")

    End Sub

    Private Sub txtAdditional_TextChanged(sender As Object, e As EventArgs) Handles txtAdditional.TextChanged
        ValidateJobDetails()
    End Sub

    Private Sub lblBookedInfo_Click(sender As Object, e As EventArgs) Handles lblBookedInfo.Click
        ShowForm(GetType(FRMLogCallout), True, New Object() {CurrentJob.JobID, CurrentSite.SiteID, Me})
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnDocument.Click
        ShowForm(GetType(FRMDocuments), True, New Object() {Entity.Sys.Enums.TableNames.tblJob, CurrentJob.JobID, 0, Me})
    End Sub

    Private Sub txtSearchSite_MouseClick(sender As Object, e As EventArgs) Handles txtSearchSite.Click
        RunFilter()
    End Sub

End Class