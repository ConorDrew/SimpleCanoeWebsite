Public Class FRMJobManager : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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

    Friend WithEvents grpJobs As System.Windows.Forms.GroupBox
    Friend WithEvents pnlFilters As System.Windows.Forms.Panel
    Friend WithEvents grpCustomerSearch As System.Windows.Forms.GroupBox
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents lblPostcode As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grpMiscSearch As System.Windows.Forms.GroupBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisitStatus As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblJobNumber As System.Windows.Forms.Label
    Friend WithEvents grpDateCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNoDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDateCreated As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
    Friend WithEvents lbPoNumber As System.Windows.Forms.Label
    Friend WithEvents chkNotShut As System.Windows.Forms.CheckBox
    Friend WithEvents btnFindSite As System.Windows.Forms.Button
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents lblProperty As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents dgJobs As DataGrid
    Friend WithEvents lblRegion As Label
    Friend WithEvents cboRegion As ComboBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobs = New System.Windows.Forms.GroupBox()
        Me.dgJobs = New System.Windows.Forms.DataGrid()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpCustomerSearch = New System.Windows.Forms.GroupBox()
        Me.btnFindSite = New System.Windows.Forms.Button()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.lblProperty = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.lblPostcode = New System.Windows.Forms.Label()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.grpMiscSearch = New System.Windows.Forms.GroupBox()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.chkNotShut = New System.Windows.Forms.CheckBox()
        Me.txtPONumber = New System.Windows.Forms.TextBox()
        Me.lbPoNumber = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblVisitStatus = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.lblJobNumber = New System.Windows.Forms.Label()
        Me.grpDateCriteria = New System.Windows.Forms.GroupBox()
        Me.rdoNoDate = New System.Windows.Forms.RadioButton()
        Me.rdoDateCreated = New System.Windows.Forms.RadioButton()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.grpJobs.SuspendLayout()
        CType(Me.dgJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        Me.grpCustomerSearch.SuspendLayout()
        Me.grpMiscSearch.SuspendLayout()
        Me.grpDateCriteria.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpJobs
        '
        Me.grpJobs.Controls.Add(Me.dgJobs)
        Me.grpJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpJobs.Location = New System.Drawing.Point(0, 247)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(1338, 354)
        Me.grpJobs.TabIndex = 44
        Me.grpJobs.TabStop = False
        Me.grpJobs.Text = "Results (awaiting search) - Double Click To View / Edit"
        '
        'dgJobs
        '
        Me.dgJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgJobs.DataMember = ""
        Me.dgJobs.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobs.Location = New System.Drawing.Point(6, 23)
        Me.dgJobs.Name = "dgJobs"
        Me.dgJobs.Size = New System.Drawing.Size(1326, 298)
        Me.dgJobs.TabIndex = 15
        '
        'pnlFilters
        '
        Me.pnlFilters.Controls.Add(Me.btnExport)
        Me.pnlFilters.Controls.Add(Me.grpCustomerSearch)
        Me.pnlFilters.Controls.Add(Me.btnReset)
        Me.pnlFilters.Controls.Add(Me.btnSearch)
        Me.pnlFilters.Controls.Add(Me.grpMiscSearch)
        Me.pnlFilters.Controls.Add(Me.grpDateCriteria)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 0)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(1338, 247)
        Me.pnlFilters.TabIndex = 43
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(964, 218)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(118, 23)
        Me.btnExport.TabIndex = 40
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'grpCustomerSearch
        '
        Me.grpCustomerSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCustomerSearch.Controls.Add(Me.btnFindSite)
        Me.grpCustomerSearch.Controls.Add(Me.txtSite)
        Me.grpCustomerSearch.Controls.Add(Me.lblProperty)
        Me.grpCustomerSearch.Controls.Add(Me.lblCustomer)
        Me.grpCustomerSearch.Controls.Add(Me.lblPostcode)
        Me.grpCustomerSearch.Controls.Add(Me.txtPostcode)
        Me.grpCustomerSearch.Controls.Add(Me.txtCustomer)
        Me.grpCustomerSearch.Controls.Add(Me.btnFindCustomer)
        Me.grpCustomerSearch.Location = New System.Drawing.Point(4, 3)
        Me.grpCustomerSearch.Name = "grpCustomerSearch"
        Me.grpCustomerSearch.Size = New System.Drawing.Size(943, 105)
        Me.grpCustomerSearch.TabIndex = 37
        Me.grpCustomerSearch.TabStop = False
        Me.grpCustomerSearch.Text = "Customer"
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.BackColor = System.Drawing.Color.White
        Me.btnFindSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSite.Location = New System.Drawing.Point(912, 43)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(25, 23)
        Me.btnFindSite.TabIndex = 35
        Me.btnFindSite.Text = "..."
        Me.btnFindSite.UseVisualStyleBackColor = False
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(107, 45)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(800, 21)
        Me.txtSite.TabIndex = 34
        '
        'lblProperty
        '
        Me.lblProperty.Location = New System.Drawing.Point(11, 44)
        Me.lblProperty.Name = "lblProperty"
        Me.lblProperty.Size = New System.Drawing.Size(65, 22)
        Me.lblProperty.TabIndex = 33
        Me.lblProperty.Text = "Property"
        '
        'lblCustomer
        '
        Me.lblCustomer.Location = New System.Drawing.Point(11, 17)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(64, 16)
        Me.lblCustomer.TabIndex = 27
        Me.lblCustomer.Text = "Customer"
        '
        'lblPostcode
        '
        Me.lblPostcode.Location = New System.Drawing.Point(11, 75)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(64, 16)
        Me.lblPostcode.TabIndex = 20
        Me.lblPostcode.Text = "Postcode"
        '
        'txtPostcode
        '
        Me.txtPostcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostcode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostcode.Location = New System.Drawing.Point(107, 72)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(830, 21)
        Me.txtPostcode.TabIndex = 5
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(107, 18)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(800, 21)
        Me.txtCustomer.TabIndex = 1
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(912, 17)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(25, 23)
        Me.btnFindCustomer.TabIndex = 2
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(1088, 218)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(118, 23)
        Me.btnReset.TabIndex = 16
        Me.btnReset.Text = "Reset All Filters"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(1212, 218)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(114, 23)
        Me.btnSearch.TabIndex = 39
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'grpMiscSearch
        '
        Me.grpMiscSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMiscSearch.Controls.Add(Me.lblRegion)
        Me.grpMiscSearch.Controls.Add(Me.cboRegion)
        Me.grpMiscSearch.Controls.Add(Me.chkNotShut)
        Me.grpMiscSearch.Controls.Add(Me.txtPONumber)
        Me.grpMiscSearch.Controls.Add(Me.lbPoNumber)
        Me.grpMiscSearch.Controls.Add(Me.cboStatus)
        Me.grpMiscSearch.Controls.Add(Me.lblVisitStatus)
        Me.grpMiscSearch.Controls.Add(Me.cboType)
        Me.grpMiscSearch.Controls.Add(Me.lblType)
        Me.grpMiscSearch.Controls.Add(Me.txtJobNumber)
        Me.grpMiscSearch.Controls.Add(Me.lblJobNumber)
        Me.grpMiscSearch.Location = New System.Drawing.Point(957, 3)
        Me.grpMiscSearch.Name = "grpMiscSearch"
        Me.grpMiscSearch.Size = New System.Drawing.Size(367, 209)
        Me.grpMiscSearch.TabIndex = 38
        Me.grpMiscSearch.TabStop = False
        Me.grpMiscSearch.Text = "Misc"
        '
        'lblRegion
        '
        Me.lblRegion.Location = New System.Drawing.Point(8, 77)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(88, 16)
        Me.lblRegion.TabIndex = 28
        Me.lblRegion.Text = "Region"
        '
        'cboRegion
        '
        Me.cboRegion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.Location = New System.Drawing.Point(102, 74)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(259, 21)
        Me.cboRegion.TabIndex = 27
        '
        'chkNotShut
        '
        Me.chkNotShut.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNotShut.Location = New System.Drawing.Point(102, 155)
        Me.chkNotShut.Name = "chkNotShut"
        Me.chkNotShut.Size = New System.Drawing.Size(245, 32)
        Me.chkNotShut.TabIndex = 26
        Me.chkNotShut.Text = "Only Show Jobs which are not completely shutdown"
        Me.chkNotShut.UseVisualStyleBackColor = True
        '
        'txtPONumber
        '
        Me.txtPONumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPONumber.Location = New System.Drawing.Point(102, 128)
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.Size = New System.Drawing.Size(259, 21)
        Me.txtPONumber.TabIndex = 12
        '
        'lbPoNumber
        '
        Me.lbPoNumber.Location = New System.Drawing.Point(8, 128)
        Me.lbPoNumber.Name = "lbPoNumber"
        Me.lbPoNumber.Size = New System.Drawing.Size(88, 16)
        Me.lbPoNumber.TabIndex = 11
        Me.lbPoNumber.Text = "PO Number"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(102, 47)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(259, 21)
        Me.cboStatus.TabIndex = 8
        '
        'lblVisitStatus
        '
        Me.lblVisitStatus.Location = New System.Drawing.Point(8, 50)
        Me.lblVisitStatus.Name = "lblVisitStatus"
        Me.lblVisitStatus.Size = New System.Drawing.Size(88, 16)
        Me.lblVisitStatus.TabIndex = 5
        Me.lblVisitStatus.Text = "Visit Status"
        '
        'cboType
        '
        Me.cboType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(102, 20)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(259, 21)
        Me.cboType.TabIndex = 7
        '
        'lblType
        '
        Me.lblType.Location = New System.Drawing.Point(8, 20)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(48, 16)
        Me.lblType.TabIndex = 4
        Me.lblType.Text = "Type"
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobNumber.Location = New System.Drawing.Point(102, 101)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(259, 21)
        Me.txtJobNumber.TabIndex = 9
        '
        'lblJobNumber
        '
        Me.lblJobNumber.Location = New System.Drawing.Point(8, 101)
        Me.lblJobNumber.Name = "lblJobNumber"
        Me.lblJobNumber.Size = New System.Drawing.Size(79, 16)
        Me.lblJobNumber.TabIndex = 6
        Me.lblJobNumber.Text = "Job Number"
        '
        'grpDateCriteria
        '
        Me.grpDateCriteria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDateCriteria.Controls.Add(Me.rdoNoDate)
        Me.grpDateCriteria.Controls.Add(Me.rdoDateCreated)
        Me.grpDateCriteria.Controls.Add(Me.dtpFrom)
        Me.grpDateCriteria.Controls.Add(Me.lblDateFrom)
        Me.grpDateCriteria.Controls.Add(Me.lblDateTo)
        Me.grpDateCriteria.Controls.Add(Me.dtpTo)
        Me.grpDateCriteria.Location = New System.Drawing.Point(4, 114)
        Me.grpDateCriteria.Name = "grpDateCriteria"
        Me.grpDateCriteria.Size = New System.Drawing.Size(943, 98)
        Me.grpDateCriteria.TabIndex = 36
        Me.grpDateCriteria.TabStop = False
        Me.grpDateCriteria.Text = "Date Criteria"
        '
        'rdoNoDate
        '
        Me.rdoNoDate.AutoSize = True
        Me.rdoNoDate.Checked = True
        Me.rdoNoDate.Location = New System.Drawing.Point(8, 28)
        Me.rdoNoDate.Name = "rdoNoDate"
        Me.rdoNoDate.Size = New System.Drawing.Size(54, 17)
        Me.rdoNoDate.TabIndex = 11
        Me.rdoNoDate.TabStop = True
        Me.rdoNoDate.Text = "None"
        Me.rdoNoDate.UseVisualStyleBackColor = True
        '
        'rdoDateCreated
        '
        Me.rdoDateCreated.AutoSize = True
        Me.rdoDateCreated.Location = New System.Drawing.Point(8, 48)
        Me.rdoDateCreated.Name = "rdoDateCreated"
        Me.rdoDateCreated.Size = New System.Drawing.Size(102, 17)
        Me.rdoDateCreated.TabIndex = 12
        Me.rdoDateCreated.Text = "Date Created"
        Me.rdoDateCreated.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(230, 30)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(169, 21)
        Me.dtpFrom.TabIndex = 14
        '
        'lblDateFrom
        '
        Me.lblDateFrom.Location = New System.Drawing.Point(176, 32)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(48, 16)
        Me.lblDateFrom.TabIndex = 9
        Me.lblDateFrom.Text = "From"
        '
        'lblDateTo
        '
        Me.lblDateTo.Location = New System.Drawing.Point(176, 57)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(48, 16)
        Me.lblDateTo.TabIndex = 10
        Me.lblDateTo.Text = "To"
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(230, 57)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(169, 21)
        Me.dtpTo.TabIndex = 15
        '
        'FRMJobManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1338, 601)
        Me.Controls.Add(Me.grpJobs)
        Me.Controls.Add(Me.pnlFilters)
        Me.MinimumSize = New System.Drawing.Size(808, 528)
        Me.Name = "FRMJobManager"
        Me.Text = "Job Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.pnlFilters, 0)
        Me.Controls.SetChildIndex(Me.grpJobs, 0)
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.grpCustomerSearch.ResumeLayout(False)
        Me.grpCustomerSearch.PerformLayout()
        Me.grpMiscSearch.ResumeLayout(False)
        Me.grpMiscSearch.PerformLayout()
        Me.grpDateCriteria.ResumeLayout(False)
        Me.grpDateCriteria.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupJobsDataGrid()

        Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboRegion, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)

        Me.rdoDateCreated.Checked = True
        Me.dtpFrom.Value = Now.AddMonths(-1)
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

    Private _dvJobs As DataView

    Private Property JobsDataview() As DataView
        Get
            Return _dvJobs
        End Get
        Set(ByVal value As DataView)
            _dvJobs = value

            If Not JobsDataview Is Nothing Then
                _dvJobs.AllowNew = False
                _dvJobs.AllowEdit = False
                _dvJobs.AllowDelete = False
                _dvJobs.Table.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
            End If

            Me.dgJobs.DataSource = JobsDataview

            If Not JobsDataview Is Nothing Then
                If JobsDataview.Table.Rows.Count > 0 Then
                    Me.dgJobs.Select(0)
                End If
            End If
        End Set
    End Property

    Private ReadOnly Property SelectedJobsDataRow() As DataRow
        Get
            If JobsDataview Is Nothing Then
                Return Nothing
            End If
            If Not Me.dgJobs.CurrentRowIndex = -1 Then
                Return JobsDataview(Me.dgJobs.CurrentRowIndex).Row
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

#End Region

#Region "Jobs DataGridView"

    Private Sub SetupJobsDataGrid()

        Dim tbStyle As DataGridTableStyle = Me.dgJobs.TableStyles(0)

        Dim DateCreated As New DataGridLabelColumn
        DateCreated.Format = "dd/MMM/yyyy"
        DateCreated.FormatInfo = Nothing
        DateCreated.HeaderText = "Date Created"
        DateCreated.MappingName = "DateCreated"
        DateCreated.ReadOnly = True
        DateCreated.Width = 100
        DateCreated.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(DateCreated)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 170
        Customer.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 170
        Name.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(Name)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 170
        Site.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(Site)

        Dim SitePostcode As New DataGridLabelColumn
        SitePostcode.Format = ""
        SitePostcode.FormatInfo = Nothing
        SitePostcode.HeaderText = "Postcode"
        SitePostcode.MappingName = "SitePostcode"
        SitePostcode.ReadOnly = True
        SitePostcode.Width = 170
        SitePostcode.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(SitePostcode)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 90
        JobNumber.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim Tel As New DataGridLabelColumn
        Tel.Format = ""
        Tel.FormatInfo = Nothing
        Tel.HeaderText = "Tel"
        Tel.MappingName = "Telephone"
        Tel.ReadOnly = True
        Tel.Width = 110
        Tel.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(Tel)

        Dim Mobile As New DataGridLabelColumn
        Mobile.Format = ""
        Mobile.FormatInfo = Nothing
        Mobile.HeaderText = "Mobile"
        Mobile.MappingName = "Mobile"
        Mobile.ReadOnly = True
        Mobile.Width = 110
        Mobile.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(Mobile)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 110
        Type.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(Type)

        Dim ContractType As New DataGridLabelColumn
        ContractType.Format = ""
        ContractType.FormatInfo = Nothing
        ContractType.HeaderText = "Contract Type"
        ContractType.MappingName = "ContractType"
        ContractType.ReadOnly = True
        ContractType.Width = 170
        ContractType.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(ContractType)

        Dim VisitStatuses As New DataGridLabelColumn
        VisitStatuses.Format = ""
        VisitStatuses.FormatInfo = Nothing
        VisitStatuses.HeaderText = "Visit Statuses"
        VisitStatuses.MappingName = "VisitStatuses"
        VisitStatuses.ReadOnly = True
        VisitStatuses.Width = 170
        VisitStatuses.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(VisitStatuses)

        Dim NotesToEngineer As New DataGridLabelColumn
        NotesToEngineer.Format = ""
        NotesToEngineer.FormatInfo = Nothing
        NotesToEngineer.HeaderText = "Initial Description"
        NotesToEngineer.MappingName = "NotesToEngineer"
        NotesToEngineer.ReadOnly = True
        NotesToEngineer.Width = 170
        NotesToEngineer.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(NotesToEngineer)

        Dim LastOutcomeDetails As New DataGridLabelColumn
        LastOutcomeDetails.Format = ""
        LastOutcomeDetails.FormatInfo = Nothing
        LastOutcomeDetails.HeaderText = "Last Outcome Details"
        LastOutcomeDetails.MappingName = "OutcomeDetails"
        LastOutcomeDetails.ReadOnly = True
        LastOutcomeDetails.Width = 170
        LastOutcomeDetails.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(LastOutcomeDetails)

        Dim CreatedBy As New DataGridLabelColumn
        CreatedBy.Format = ""
        CreatedBy.FormatInfo = Nothing
        CreatedBy.HeaderText = "Created By"
        CreatedBy.MappingName = "CreatedBy"
        CreatedBy.ReadOnly = True
        CreatedBy.Width = 170
        CreatedBy.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(CreatedBy)

        Dim isJobOpen As New DataGridLabelColumn
        isJobOpen.Format = ""
        isJobOpen.FormatInfo = Nothing
        isJobOpen.HeaderText = "Job Status"
        isJobOpen.MappingName = "JobStatus"
        isJobOpen.ReadOnly = True
        isJobOpen.Width = 120
        isJobOpen.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(isJobOpen)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblJob.ToString

        Me.dgJobs.TableStyles.Add(tbStyle)

    End Sub

#End Region

#Region "Events"

    Private Sub FRMJobManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            theCustomer = DB.Customer.Customer_Get(ID)
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
        End If
    End Sub

    Private Sub BtnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub rdoDateCreated_CheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDateCreated.CheckedChanged
        dtpFrom.Enabled = rdoDateCreated.Checked
        dtpTo.Enabled = rdoDateCreated.Checked
    End Sub

    Private Sub rdoNoDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoNoDate.CheckedChanged
        dtpFrom.Enabled = Not rdoNoDate.Checked
        dtpTo.Enabled = Not rdoNoDate.Checked
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If rdoNoDate.Checked = True Then
            If ShowMessage("No date range is selected, please make sure other fields are selected as this may pull all the files from the database and crash your system, would you like to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                PopulateDatagrid(True)
            Else
                Exit Sub
            End If
        Else
            PopulateDatagrid(True)
        End If
    End Sub

    Private Sub dgJobs_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgJobs.DoubleClick
        If SelectedJobsDataRow Is Nothing Then
            ShowMessage("Please select a visit to view", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedJobsDataRow.Item("JobID"), SelectedJobsDataRow.Item("SiteID"), Me})
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid(ByVal withRun As Boolean)
        Try
            Cursor.Current = Cursors.WaitCursor
            If GetParameter(0) Is Nothing Then

                Dim dateFrom As DateTime = Nothing
                Dim dateTo As DateTime = Nothing
                Dim customerId As Integer = If(theCustomer IsNot Nothing, theCustomer.CustomerID, 0)
                Dim siteId As Integer = If(theSite IsNot Nothing, theSite.SiteID, 0)
                Dim postcode As String = If(Me.txtPostcode.Text.Trim.Length > 0, Me.txtPostcode.Text, Nothing)
                Dim jobTypeId As Integer = Combo.GetSelectedItemValue(Me.cboType)
                Dim statusEnumId As Integer = Combo.GetSelectedItemValue(Me.cboStatus)
                Dim regionId As Integer = Combo.GetSelectedItemValue(Me.cboRegion)
                Dim jobNumber As String = If(Not Me.txtJobNumber.Text.Trim.Length = 0, Entity.Sys.Helper.CleanText(Me.txtJobNumber.Text.Trim), Nothing)
                Dim poNumber As String = If(Not Me.txtPONumber.Text.Trim.Length = 0, Entity.Sys.Helper.CleanText(Me.txtPONumber.Text.Trim), Nothing)
                Dim isJobOpen As Boolean = Me.chkNotShut.Checked

                If Me.rdoDateCreated.Checked Then
                    dateFrom = Me.dtpFrom.Value
                    dateTo = Me.dtpTo.Value
                End If

                JobsDataview = DB.Job.Job_Manager_Search(dateFrom, dateTo, jobNumber, postcode, jobTypeId, customerId, siteId, statusEnumId, regionId, poNumber, isJobOpen)

                count = JobsDataview.Count
                Me.grpJobs.Text = "Double Click To View / Edit (" + CStr(count) + ")"
            Else
                JobsDataview = Nothing
            End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub ResetFilters()
        theCustomer = Nothing
        theSite = Nothing
        Combo.SetSelectedComboItem_By_Value(Me.cboType, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, 0)
        Me.txtJobNumber.Text = ""
        Me.txtPONumber.Text = ""
        Me.txtPostcode.Text = ""
        Me.rdoDateCreated.Checked = True
        Me.dtpFrom.Value = Today
        Me.dtpTo.Value = Today
        Me.dtpFrom.Enabled = True
        Me.dtpTo.Enabled = True
        Me.dtpFrom.Value = Now.AddMonths(-1)
        chkNotShut.Checked = False

    End Sub

    Public Sub Export()
        If JobsDataview IsNot Nothing Then
            Entity.Sys.ExportHelper.Export(JobsDataview.Table, "Job Manager", Entity.Sys.Enums.ExportType.XLS)
        End If
    End Sub

#End Region

End Class