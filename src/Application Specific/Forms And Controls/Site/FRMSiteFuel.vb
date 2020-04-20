Public Class FRMSiteFuel : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal oSite As Entity.Sites.Site)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        CurrentSite = oSite
        Combo.SetUpCombo(Me.cboFuel, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.GasTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboChargeType, DB.Sites.SiteFuelCharge_GetAll().Table, "SiteFuelChargeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select_Negative)
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

    Friend WithEvents SiteFuelTabControl As TabControl
    Friend WithEvents tabSiteFuel As TabPage
    Friend WithEvents tabAudit As TabPage
    Friend WithEvents grpSiteFuels As GroupBox
    Friend WithEvents dgSiteFuel As DataGrid
    Friend WithEvents btnSaveFuel As Button
    Friend WithEvents btnDeleteSiteFuel As Button
    Friend WithEvents grpSiteFuelUpdate As GroupBox
    Friend WithEvents lblFuel As Label
    Friend WithEvents cboFuel As ComboBox
    Friend WithEvents dtpLastServiceDate As DateTimePicker
    Friend WithEvents lblLastService As Label
    Friend WithEvents grpSite As GroupBox
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents lblSite As Label
    Friend WithEvents txtSiteName As TextBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents txtTelephoneNum As TextBox
    Friend WithEvents lblTelephoneNum As Label
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents lblEmailAddress As Label
    Friend WithEvents txtFaxNum As TextBox
    Friend WithEvents lblFaxNum As Label
    Friend WithEvents txtSite As TextBox
    Friend WithEvents lblSiteName As Label
    Friend WithEvents ttSiteFuel As ToolTip
    Friend WithEvents grpSiteFuelAudit As GroupBox
    Friend WithEvents dgSiteFuelAudit As DataGrid
    Friend WithEvents txtAddedOn As TextBox
    Friend WithEvents lblAddedOn As Label
    Friend WithEvents txtAddedByText As TextBox
    Friend WithEvents lblAddedBy As Label
    Friend WithEvents lblChargeType As Label
    Friend WithEvents cboChargeType As ComboBox
    Friend WithEvents dtpActualServiceDate As DateTimePicker
    Friend WithEvents lblActualServiceDate As Label
    Friend WithEvents btnUpdateSiteService As Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SiteFuelTabControl = New System.Windows.Forms.TabControl()
        Me.tabSiteFuel = New System.Windows.Forms.TabPage()
        Me.grpSiteFuels = New System.Windows.Forms.GroupBox()
        Me.grpSite = New System.Windows.Forms.GroupBox()
        Me.btnUpdateSiteService = New System.Windows.Forms.Button()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.lblSiteName = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.lblSite = New System.Windows.Forms.Label()
        Me.txtSiteName = New System.Windows.Forms.TextBox()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.txtTelephoneNum = New System.Windows.Forms.TextBox()
        Me.lblTelephoneNum = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.txtFaxNum = New System.Windows.Forms.TextBox()
        Me.lblFaxNum = New System.Windows.Forms.Label()
        Me.grpSiteFuelUpdate = New System.Windows.Forms.GroupBox()
        Me.dtpActualServiceDate = New System.Windows.Forms.DateTimePicker()
        Me.lblActualServiceDate = New System.Windows.Forms.Label()
        Me.lblChargeType = New System.Windows.Forms.Label()
        Me.cboChargeType = New System.Windows.Forms.ComboBox()
        Me.txtAddedOn = New System.Windows.Forms.TextBox()
        Me.lblAddedOn = New System.Windows.Forms.Label()
        Me.txtAddedByText = New System.Windows.Forms.TextBox()
        Me.lblAddedBy = New System.Windows.Forms.Label()
        Me.dtpLastServiceDate = New System.Windows.Forms.DateTimePicker()
        Me.lblLastService = New System.Windows.Forms.Label()
        Me.lblFuel = New System.Windows.Forms.Label()
        Me.cboFuel = New System.Windows.Forms.ComboBox()
        Me.btnSaveFuel = New System.Windows.Forms.Button()
        Me.btnDeleteSiteFuel = New System.Windows.Forms.Button()
        Me.dgSiteFuel = New System.Windows.Forms.DataGrid()
        Me.tabAudit = New System.Windows.Forms.TabPage()
        Me.grpSiteFuelAudit = New System.Windows.Forms.GroupBox()
        Me.dgSiteFuelAudit = New System.Windows.Forms.DataGrid()
        Me.ttSiteFuel = New System.Windows.Forms.ToolTip(Me.components)
        Me.SiteFuelTabControl.SuspendLayout()
        Me.tabSiteFuel.SuspendLayout()
        Me.grpSiteFuels.SuspendLayout()
        Me.grpSite.SuspendLayout()
        Me.grpSiteFuelUpdate.SuspendLayout()
        CType(Me.dgSiteFuel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAudit.SuspendLayout()
        Me.grpSiteFuelAudit.SuspendLayout()
        CType(Me.dgSiteFuelAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SiteFuelTabControl
        '
        Me.SiteFuelTabControl.Controls.Add(Me.tabSiteFuel)
        Me.SiteFuelTabControl.Controls.Add(Me.tabAudit)
        Me.SiteFuelTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SiteFuelTabControl.Location = New System.Drawing.Point(0, 0)
        Me.SiteFuelTabControl.Name = "SiteFuelTabControl"
        Me.SiteFuelTabControl.SelectedIndex = 0
        Me.SiteFuelTabControl.Size = New System.Drawing.Size(800, 557)
        Me.SiteFuelTabControl.TabIndex = 2
        '
        'tabSiteFuel
        '
        Me.tabSiteFuel.Controls.Add(Me.grpSiteFuels)
        Me.tabSiteFuel.Location = New System.Drawing.Point(4, 22)
        Me.tabSiteFuel.Name = "tabSiteFuel"
        Me.tabSiteFuel.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSiteFuel.Size = New System.Drawing.Size(792, 531)
        Me.tabSiteFuel.TabIndex = 0
        Me.tabSiteFuel.Text = "Site Fuels"
        Me.tabSiteFuel.UseVisualStyleBackColor = True
        '
        'grpSiteFuels
        '
        Me.grpSiteFuels.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSiteFuels.Controls.Add(Me.grpSite)
        Me.grpSiteFuels.Controls.Add(Me.grpSiteFuelUpdate)
        Me.grpSiteFuels.Controls.Add(Me.dgSiteFuel)
        Me.grpSiteFuels.Location = New System.Drawing.Point(5, 3)
        Me.grpSiteFuels.Margin = New System.Windows.Forms.Padding(0)
        Me.grpSiteFuels.Name = "grpSiteFuels"
        Me.grpSiteFuels.Padding = New System.Windows.Forms.Padding(0)
        Me.grpSiteFuels.Size = New System.Drawing.Size(782, 523)
        Me.grpSiteFuels.TabIndex = 14
        Me.grpSiteFuels.TabStop = False
        Me.grpSiteFuels.Text = "Site Fuel"
        '
        'grpSite
        '
        Me.grpSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSite.Controls.Add(Me.btnUpdateSiteService)
        Me.grpSite.Controls.Add(Me.txtSite)
        Me.grpSite.Controls.Add(Me.lblSiteName)
        Me.grpSite.Controls.Add(Me.txtCustomerName)
        Me.grpSite.Controls.Add(Me.lblSite)
        Me.grpSite.Controls.Add(Me.txtSiteName)
        Me.grpSite.Controls.Add(Me.lblCustomer)
        Me.grpSite.Controls.Add(Me.txtTelephoneNum)
        Me.grpSite.Controls.Add(Me.lblTelephoneNum)
        Me.grpSite.Controls.Add(Me.txtEmailAddress)
        Me.grpSite.Controls.Add(Me.lblEmailAddress)
        Me.grpSite.Controls.Add(Me.txtFaxNum)
        Me.grpSite.Controls.Add(Me.lblFaxNum)
        Me.grpSite.Location = New System.Drawing.Point(489, 17)
        Me.grpSite.Name = "grpSite"
        Me.grpSite.Size = New System.Drawing.Size(287, 229)
        Me.grpSite.TabIndex = 115
        Me.grpSite.TabStop = False
        Me.grpSite.Text = "Site "
        '
        'btnUpdateSiteService
        '
        Me.btnUpdateSiteService.Location = New System.Drawing.Point(139, 196)
        Me.btnUpdateSiteService.Name = "btnUpdateSiteService"
        Me.btnUpdateSiteService.Size = New System.Drawing.Size(139, 23)
        Me.btnUpdateSiteService.TabIndex = 126
        Me.btnUpdateSiteService.Text = "Update Site Service"
        '
        'txtSite
        '
        Me.txtSite.Location = New System.Drawing.Point(117, 48)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(161, 21)
        Me.txtSite.TabIndex = 121
        '
        'lblSiteName
        '
        Me.lblSiteName.Location = New System.Drawing.Point(8, 51)
        Me.lblSiteName.Name = "lblSiteName"
        Me.lblSiteName.Size = New System.Drawing.Size(80, 23)
        Me.lblSiteName.TabIndex = 125
        Me.lblSiteName.Text = "Name:"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Location = New System.Drawing.Point(117, 20)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(161, 21)
        Me.txtCustomerName.TabIndex = 120
        '
        'lblSite
        '
        Me.lblSite.Location = New System.Drawing.Point(8, 79)
        Me.lblSite.Name = "lblSite"
        Me.lblSite.Size = New System.Drawing.Size(80, 23)
        Me.lblSite.TabIndex = 124
        Me.lblSite.Text = "Property:"
        '
        'txtSiteName
        '
        Me.txtSiteName.Location = New System.Drawing.Point(117, 76)
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.ReadOnly = True
        Me.txtSiteName.Size = New System.Drawing.Size(161, 21)
        Me.txtSiteName.TabIndex = 122
        '
        'lblCustomer
        '
        Me.lblCustomer.Location = New System.Drawing.Point(6, 23)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(80, 23)
        Me.lblCustomer.TabIndex = 123
        Me.lblCustomer.Text = "Customer:"
        '
        'txtTelephoneNum
        '
        Me.txtTelephoneNum.Location = New System.Drawing.Point(117, 104)
        Me.txtTelephoneNum.MaxLength = 50
        Me.txtTelephoneNum.Name = "txtTelephoneNum"
        Me.txtTelephoneNum.ReadOnly = True
        Me.txtTelephoneNum.Size = New System.Drawing.Size(161, 21)
        Me.txtTelephoneNum.TabIndex = 114
        Me.txtTelephoneNum.Tag = "Site.TelephoneNum"
        '
        'lblTelephoneNum
        '
        Me.lblTelephoneNum.Location = New System.Drawing.Point(8, 107)
        Me.lblTelephoneNum.Name = "lblTelephoneNum"
        Me.lblTelephoneNum.Size = New System.Drawing.Size(48, 20)
        Me.lblTelephoneNum.TabIndex = 119
        Me.lblTelephoneNum.Text = "Tel"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(117, 160)
        Me.txtEmailAddress.MaxLength = 100
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.ReadOnly = True
        Me.txtEmailAddress.Size = New System.Drawing.Size(161, 21)
        Me.txtEmailAddress.TabIndex = 116
        Me.txtEmailAddress.Tag = "Site.EmailAddress"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(8, 163)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(98, 20)
        Me.lblEmailAddress.TabIndex = 118
        Me.lblEmailAddress.Text = "Email Address"
        '
        'txtFaxNum
        '
        Me.txtFaxNum.Location = New System.Drawing.Point(117, 132)
        Me.txtFaxNum.MaxLength = 50
        Me.txtFaxNum.Name = "txtFaxNum"
        Me.txtFaxNum.ReadOnly = True
        Me.txtFaxNum.Size = New System.Drawing.Size(161, 21)
        Me.txtFaxNum.TabIndex = 115
        Me.txtFaxNum.Tag = "Site.FaxNum"
        '
        'lblFaxNum
        '
        Me.lblFaxNum.Location = New System.Drawing.Point(8, 135)
        Me.lblFaxNum.Name = "lblFaxNum"
        Me.lblFaxNum.Size = New System.Drawing.Size(50, 20)
        Me.lblFaxNum.TabIndex = 117
        Me.lblFaxNum.Text = "Mobile"
        '
        'grpSiteFuelUpdate
        '
        Me.grpSiteFuelUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSiteFuelUpdate.Controls.Add(Me.dtpActualServiceDate)
        Me.grpSiteFuelUpdate.Controls.Add(Me.lblActualServiceDate)
        Me.grpSiteFuelUpdate.Controls.Add(Me.lblChargeType)
        Me.grpSiteFuelUpdate.Controls.Add(Me.cboChargeType)
        Me.grpSiteFuelUpdate.Controls.Add(Me.txtAddedOn)
        Me.grpSiteFuelUpdate.Controls.Add(Me.lblAddedOn)
        Me.grpSiteFuelUpdate.Controls.Add(Me.txtAddedByText)
        Me.grpSiteFuelUpdate.Controls.Add(Me.lblAddedBy)
        Me.grpSiteFuelUpdate.Controls.Add(Me.dtpLastServiceDate)
        Me.grpSiteFuelUpdate.Controls.Add(Me.lblLastService)
        Me.grpSiteFuelUpdate.Controls.Add(Me.lblFuel)
        Me.grpSiteFuelUpdate.Controls.Add(Me.cboFuel)
        Me.grpSiteFuelUpdate.Controls.Add(Me.btnSaveFuel)
        Me.grpSiteFuelUpdate.Controls.Add(Me.btnDeleteSiteFuel)
        Me.grpSiteFuelUpdate.Location = New System.Drawing.Point(489, 252)
        Me.grpSiteFuelUpdate.Name = "grpSiteFuelUpdate"
        Me.grpSiteFuelUpdate.Size = New System.Drawing.Size(287, 266)
        Me.grpSiteFuelUpdate.TabIndex = 12
        Me.grpSiteFuelUpdate.TabStop = False
        Me.grpSiteFuelUpdate.Text = "Fuel"
        '
        'dtpActualServiceDate
        '
        Me.dtpActualServiceDate.Location = New System.Drawing.Point(142, 119)
        Me.dtpActualServiceDate.Name = "dtpActualServiceDate"
        Me.dtpActualServiceDate.Size = New System.Drawing.Size(139, 21)
        Me.dtpActualServiceDate.TabIndex = 133
        '
        'lblActualServiceDate
        '
        Me.lblActualServiceDate.Location = New System.Drawing.Point(6, 125)
        Me.lblActualServiceDate.Name = "lblActualServiceDate"
        Me.lblActualServiceDate.Size = New System.Drawing.Size(124, 20)
        Me.lblActualServiceDate.TabIndex = 132
        Me.lblActualServiceDate.Text = "Service Date"
        '
        'lblChargeType
        '
        Me.lblChargeType.AutoSize = True
        Me.lblChargeType.Location = New System.Drawing.Point(6, 56)
        Me.lblChargeType.Name = "lblChargeType"
        Me.lblChargeType.Size = New System.Drawing.Size(49, 13)
        Me.lblChargeType.TabIndex = 131
        Me.lblChargeType.Text = "Charge"
        '
        'cboChargeType
        '
        Me.cboChargeType.FormattingEnabled = True
        Me.cboChargeType.Location = New System.Drawing.Point(72, 53)
        Me.cboChargeType.Name = "cboChargeType"
        Me.cboChargeType.Size = New System.Drawing.Size(209, 21)
        Me.cboChargeType.TabIndex = 130
        '
        'txtAddedOn
        '
        Me.txtAddedOn.Location = New System.Drawing.Point(120, 185)
        Me.txtAddedOn.Name = "txtAddedOn"
        Me.txtAddedOn.ReadOnly = True
        Me.txtAddedOn.Size = New System.Drawing.Size(161, 21)
        Me.txtAddedOn.TabIndex = 128
        '
        'lblAddedOn
        '
        Me.lblAddedOn.Location = New System.Drawing.Point(8, 188)
        Me.lblAddedOn.Name = "lblAddedOn"
        Me.lblAddedOn.Size = New System.Drawing.Size(80, 23)
        Me.lblAddedOn.TabIndex = 129
        Me.lblAddedOn.Text = "Added On:"
        '
        'txtAddedByText
        '
        Me.txtAddedByText.Location = New System.Drawing.Point(120, 152)
        Me.txtAddedByText.Name = "txtAddedByText"
        Me.txtAddedByText.ReadOnly = True
        Me.txtAddedByText.Size = New System.Drawing.Size(161, 21)
        Me.txtAddedByText.TabIndex = 126
        '
        'lblAddedBy
        '
        Me.lblAddedBy.Location = New System.Drawing.Point(6, 155)
        Me.lblAddedBy.Name = "lblAddedBy"
        Me.lblAddedBy.Size = New System.Drawing.Size(80, 23)
        Me.lblAddedBy.TabIndex = 127
        Me.lblAddedBy.Text = "Added By:"
        '
        'dtpLastServiceDate
        '
        Me.dtpLastServiceDate.Location = New System.Drawing.Point(142, 86)
        Me.dtpLastServiceDate.Name = "dtpLastServiceDate"
        Me.dtpLastServiceDate.Size = New System.Drawing.Size(139, 21)
        Me.dtpLastServiceDate.TabIndex = 57
        '
        'lblLastService
        '
        Me.lblLastService.Location = New System.Drawing.Point(6, 92)
        Me.lblLastService.Name = "lblLastService"
        Me.lblLastService.Size = New System.Drawing.Size(114, 20)
        Me.lblLastService.TabIndex = 56
        Me.lblLastService.Text = "Service Due Date"
        '
        'lblFuel
        '
        Me.lblFuel.AutoSize = True
        Me.lblFuel.Location = New System.Drawing.Point(8, 23)
        Me.lblFuel.Name = "lblFuel"
        Me.lblFuel.Size = New System.Drawing.Size(30, 13)
        Me.lblFuel.TabIndex = 55
        Me.lblFuel.Text = "Fuel"
        '
        'cboFuel
        '
        Me.cboFuel.FormattingEnabled = True
        Me.cboFuel.Location = New System.Drawing.Point(72, 20)
        Me.cboFuel.Name = "cboFuel"
        Me.cboFuel.Size = New System.Drawing.Size(209, 21)
        Me.cboFuel.TabIndex = 54
        '
        'btnSaveFuel
        '
        Me.btnSaveFuel.Location = New System.Drawing.Point(191, 233)
        Me.btnSaveFuel.Name = "btnSaveFuel"
        Me.btnSaveFuel.Size = New System.Drawing.Size(90, 23)
        Me.btnSaveFuel.TabIndex = 9
        Me.btnSaveFuel.Text = "Save"
        '
        'btnDeleteSiteFuel
        '
        Me.btnDeleteSiteFuel.Location = New System.Drawing.Point(9, 233)
        Me.btnDeleteSiteFuel.Name = "btnDeleteSiteFuel"
        Me.btnDeleteSiteFuel.Size = New System.Drawing.Size(90, 23)
        Me.btnDeleteSiteFuel.TabIndex = 10
        Me.btnDeleteSiteFuel.Text = "Delete"
        '
        'dgSiteFuel
        '
        Me.dgSiteFuel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSiteFuel.DataMember = ""
        Me.dgSiteFuel.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSiteFuel.Location = New System.Drawing.Point(5, 19)
        Me.dgSiteFuel.Name = "dgSiteFuel"
        Me.dgSiteFuel.Size = New System.Drawing.Size(478, 499)
        Me.dgSiteFuel.TabIndex = 11
        '
        'tabAudit
        '
        Me.tabAudit.Controls.Add(Me.grpSiteFuelAudit)
        Me.tabAudit.Location = New System.Drawing.Point(4, 22)
        Me.tabAudit.Name = "tabAudit"
        Me.tabAudit.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAudit.Size = New System.Drawing.Size(792, 531)
        Me.tabAudit.TabIndex = 1
        Me.tabAudit.Text = "Audit"
        Me.tabAudit.UseVisualStyleBackColor = True
        '
        'grpSiteFuelAudit
        '
        Me.grpSiteFuelAudit.Controls.Add(Me.dgSiteFuelAudit)
        Me.grpSiteFuelAudit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpSiteFuelAudit.Location = New System.Drawing.Point(3, 3)
        Me.grpSiteFuelAudit.Name = "grpSiteFuelAudit"
        Me.grpSiteFuelAudit.Size = New System.Drawing.Size(786, 525)
        Me.grpSiteFuelAudit.TabIndex = 5
        Me.grpSiteFuelAudit.TabStop = False
        Me.grpSiteFuelAudit.Text = "Site Fuel Audit"
        '
        'dgSiteFuelAudit
        '
        Me.dgSiteFuelAudit.DataMember = ""
        Me.dgSiteFuelAudit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSiteFuelAudit.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSiteFuelAudit.Location = New System.Drawing.Point(3, 17)
        Me.dgSiteFuelAudit.Name = "dgSiteFuelAudit"
        Me.dgSiteFuelAudit.Size = New System.Drawing.Size(780, 505)
        Me.dgSiteFuelAudit.TabIndex = 15
        '
        'FRMSiteFuel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(800, 557)
        Me.Controls.Add(Me.SiteFuelTabControl)
        Me.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Name = "FRMSiteFuel"
        Me.Text = "Site Fuel"
        Me.Controls.SetChildIndex(Me.SiteFuelTabControl, 0)
        Me.SiteFuelTabControl.ResumeLayout(False)
        Me.tabSiteFuel.ResumeLayout(False)
        Me.grpSiteFuels.ResumeLayout(False)
        Me.grpSite.ResumeLayout(False)
        Me.grpSite.PerformLayout()
        Me.grpSiteFuelUpdate.ResumeLayout(False)
        Me.grpSiteFuelUpdate.PerformLayout()
        CType(Me.dgSiteFuel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAudit.ResumeLayout(False)
        Me.grpSiteFuelAudit.ResumeLayout(False)
        CType(Me.dgSiteFuelAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupSiteFuelDataGrid()
        SetupSiteFuelAuditDataGrid()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Setup"

    Public Sub SetupSiteFuelDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgSiteFuel)
        Dim tStyle As DataGridTableStyle = Me.dgSiteFuel.TableStyles(0)

        Dim fuelType As New DataGridSiteFuelColumn
        fuelType.Format = ""
        fuelType.FormatInfo = Nothing
        fuelType.HeaderText = "Fuel Type"
        fuelType.MappingName = "FuelType"
        fuelType.ReadOnly = True
        fuelType.Width = 100
        fuelType.NullText = ""
        tStyle.GridColumnStyles.Add(fuelType)

        Dim serviceDue As New DataGridSiteFuelColumn
        serviceDue.Format = "dd/MM/yyyy"
        serviceDue.FormatInfo = Nothing
        serviceDue.HeaderText = "Service Due"
        serviceDue.MappingName = "ServiceDue"
        serviceDue.ReadOnly = True
        serviceDue.Width = 105
        serviceDue.NullText = "N/A"
        tStyle.GridColumnStyles.Add(serviceDue)

        Dim lastServiceDate As New DataGridSiteFuelColumn
        lastServiceDate.Format = "dd/MM/yyyy"
        lastServiceDate.FormatInfo = Nothing
        lastServiceDate.HeaderText = "Service Date"
        lastServiceDate.MappingName = "ActualServiceDate"
        lastServiceDate.ReadOnly = True
        lastServiceDate.Width = 105
        lastServiceDate.NullText = "N/A"
        tStyle.GridColumnStyles.Add(lastServiceDate)

        Dim FuelChargeType As New DataGridSiteFuelColumn
        FuelChargeType.Format = "dd/MM/yyyy"
        FuelChargeType.FormatInfo = Nothing
        FuelChargeType.HeaderText = "Charge Type"
        FuelChargeType.MappingName = "FuelChargeType"
        FuelChargeType.ReadOnly = True
        FuelChargeType.Width = 170
        FuelChargeType.NullText = ""
        tStyle.GridColumnStyles.Add(FuelChargeType)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString
        Me.dgSiteFuel.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupSiteFuelAuditDataGrid()
        Dim tStyle As DataGridTableStyle = Me.dgSiteFuelAudit.TableStyles(0)
        tStyle.GridColumnStyles.Clear()

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Action"
        Name.MappingName = "ActionChange"
        Name.ReadOnly = True
        Name.Width = 350
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Date"
        Site.MappingName = "ActionDateTime"
        Site.ReadOnly = True
        Site.Width = 100
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "User"
        Type.MappingName = "Fullname"
        Type.ReadOnly = True
        Type.Width = 200
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString
        Me.dgSiteFuelAudit.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Properties"

    Private _osite As Entity.Sites.Site
    Public Property CurrentSite() As Entity.Sites.Site
        Get
            Return _osite
        End Get
        Set(ByVal value As Entity.Sites.Site)
            _osite = value

            Me.txtSite.Text = CurrentSite.Name
            Me.txtSiteName.Text = CurrentSite.Address1 & "," & CurrentSite.Postcode

            Dim CurrentCustomer As New Entity.Customers.Customer
            CurrentCustomer = DB.Customer.Customer_Get_Light(CurrentSite.CustomerID)
            Me.txtCustomerName.Text = CurrentCustomer.Name

            Me.txtTelephoneNum.Text = CurrentSite.TelephoneNum
            Me.txtFaxNum.Text = CurrentSite.FaxNum
            Me.txtEmailAddress.Text = CurrentSite.EmailAddress
            PopulateSiteFuelDataGrid()
            PopulateSiteAuditFuelDataGrid()
        End Set
    End Property

    Private _dvSiteFuels As DataView = Nothing
    Public Property SiteFuelsDataView() As DataView
        Get
            Return _dvSiteFuels
        End Get
        Set(ByVal Value As DataView)
            _dvSiteFuels = Value
            _dvSiteFuels.AllowNew = False
            _dvSiteFuels.AllowEdit = False
            _dvSiteFuels.AllowDelete = False
            _dvSiteFuels.Table.TableName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString
            Me.dgSiteFuel.DataSource = SiteFuelsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedSiteFuelDataRow() As DataRow
        Get
            If Not Me.dgSiteFuel.CurrentRowIndex = -1 Then
                Return SiteFuelsDataView(Me.dgSiteFuel.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _dvSiteFuelAudit As DataView
    Private Property SiteFuelAuditDataView() As DataView
        Get
            Return _dvSiteFuelAudit
        End Get
        Set(ByVal value As DataView)
            _dvSiteFuelAudit = value
            _dvSiteFuelAudit.AllowNew = False
            _dvSiteFuelAudit.AllowEdit = False
            _dvSiteFuelAudit.AllowDelete = False
            _dvSiteFuelAudit.Table.TableName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString
            Me.dgSiteFuelAudit.DataSource = SiteFuelAuditDataView
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMContactInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSaveFuel.Click
        Dim fuelId As Integer =
            Entity.Sys.Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboFuel))

        If fuelId = 0 Or fuelId = Entity.Sys.Enums.FuelTypes.NA Then
            Exit Sub
        End If

        Dim chargeTypeId As Integer = Entity.Sys.Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboChargeType))
        Dim siteFuels As DataRow() = SiteFuelsDataView.Table.Select("FuelID = " & fuelId)
        Dim message As String = ""
        Dim noServiceDate As Boolean = False
        Dim change As String = Combo.GetSelectedItemDescription(cboFuel) & " added"
        Dim siteFuelID As Integer = 0
        If siteFuels.Length > 0 Then
            If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Servicing) Then
                Dim msg As String = "You do not have the necessary security permissions."
                Throw New Security.SecurityException(msg)
                Exit Sub
            End If

            message += "Update Fuel?"
            change = String.Empty

            For Each fuel As DataRow In siteFuels
                siteFuelID = CInt(fuel("SiteFuelID"))
                If Entity.Sys.Helper.MakeDateTimeValid(fuel("LastServiceDate")).Date.AddYears(1) <>
                    dtpLastServiceDate.Value.Date.AddYears(1) Then
                    message += vbCrLf & vbCrLf & "You have changed the last service date, do you wish to continue?"
                    change = "Updated " & Combo.GetSelectedItemDescription(cboFuel) &
                        ", changed service due date from " & CDate(fuel("LastServiceDate")).Date.AddYears(1) & " to " &
                         dtpLastServiceDate.Value.Date.AddYears(1)
                End If

                If Entity.Sys.Helper.MakeDateTimeValid(fuel("ActualServiceDate")).Date <>
                    dtpActualServiceDate.Value.Date Then
                    message += vbCrLf & vbCrLf & "You have changed the service date, do you wish to continue?"
                    change = "Updated " & Combo.GetSelectedItemDescription(cboFuel) &
                        ", changed service date from " & CDate(fuel("ActualServiceDate")).Date & " to " &
                         dtpLastServiceDate.Value.Date
                End If

                If Entity.Sys.Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboChargeType)) <>
                        CInt(fuel("SiteFuelChargeID")) Then
                    change = "Updated " & Combo.GetSelectedItemDescription(cboFuel) &
                        ", changed contract charge type from " & fuel("FuelChargeType") & " to " &
                        Combo.GetSelectedItemDescription(cboChargeType)
                Else
                    chargeTypeId = CInt(fuel("SiteFuelChargeID"))
                End If
            Next

            If ShowMessage(message, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim currentFuel As Entity.Sites.SiteFuel = DB.Sites.[SiteFuel_Get](siteFuelID)
        If currentFuel Is Nothing Then
            currentFuel = New Entity.Sites.SiteFuel
            If ShowMessage("Use dates selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                noServiceDate = True
            End If
        End If


        With currentFuel
            .SetSiteFuelID = siteFuelID
            .SetSiteID = CurrentSite.SiteID
            .SetFuelID = fuelId
            If noServiceDate Then
                .LastServiceDate = SqlTypes.SqlDateTime.MinValue
                .ActualServiceDate = SqlTypes.SqlDateTime.MinValue
            Else
                .LastServiceDate = dtpLastServiceDate.Value.AddYears(-1)
                .ActualServiceDate = dtpActualServiceDate.Value
            End If
            .SetSiteFuelChargeID = chargeTypeId
        End With

        Try
            If Not DB.Sites.[SiteFuel_Update](currentFuel) Then Throw New Exception("Failed to save!")
            'check if site has a service date against it 
            If CurrentSite.LastServiceDate.Date < currentFuel.LastServiceDate Then
                DB.Sites.Site_UpdateLastServiceDate(CurrentSite.SiteID, currentFuel.LastServiceDate, currentFuel.ActualServiceDate, True)
            Else
                If ShowMessage("Service due date on site is later than fuel." & vbCrLf & vbCrLf &
                        "Do you want to update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    DB.Sites.Site_UpdateLastServiceDate(CurrentSite.SiteID, currentFuel.LastServiceDate, currentFuel.ActualServiceDate, True)
                End If
            End If
            If Not String.IsNullOrEmpty(change) Then DB.Sites.[SiteFuelAudit_Insert](CurrentSite.SiteID, change)
            PopulateSiteFuelDataGrid()
            PopulateSiteAuditFuelDataGrid()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgSiteFuel_Click(sender As Object, e As EventArgs) Handles dgSiteFuel.Click
        If SelectedSiteFuelDataRow Is Nothing Then
            Exit Sub
        End If
        Combo.SetSelectedComboItem_By_Value(cboFuel, SelectedSiteFuelDataRow("FuelID"))
        Combo.SetSelectedComboItem_By_Value(cboChargeType, SelectedSiteFuelDataRow("SiteFuelChargeID"))
        dtpLastServiceDate.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedSiteFuelDataRow("LastServiceDate")).AddYears(1)
        If Not IsDBNull(SelectedSiteFuelDataRow("ActualServiceDate")) Then
            dtpActualServiceDate.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedSiteFuelDataRow("ActualServiceDate"))
        Else
            dtpActualServiceDate.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedSiteFuelDataRow("LastServiceDate"))
        End If
        txtAddedByText.Text = SelectedSiteFuelDataRow("Fullname")
        txtAddedOn.Text = CDate(SelectedSiteFuelDataRow("DateAdded")).Date
    End Sub

    Private Sub btnDeleteSiteFuel_Click(sender As Object, e As EventArgs) Handles btnDeleteSiteFuel.Click
        If SelectedSiteFuelDataRow Is Nothing Then
            Exit Sub
        End If

        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Servicing) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
            Exit Sub
        End If

        If ShowMessage("Remove " & SelectedSiteFuelDataRow("FuelType") & "?" &
                       vbCrLf & vbCrLf & "Are you sure?",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim siteFuelId As Integer =
            Entity.Sys.Helper.MakeIntegerValid(SelectedSiteFuelDataRow("SiteFuelID"))

        Try
            If Not DB.Sites.[SiteFuel_Delete](siteFuelId) Then Throw New Exception("Failed to delete!")
            Dim change As String = SelectedSiteFuelDataRow("FuelType") & " removed"
            If Not String.IsNullOrEmpty(change) Then DB.Sites.[SiteFuelAudit_Insert](CurrentSite.SiteID, change)
            PopulateSiteFuelDataGrid()
            PopulateSiteAuditFuelDataGrid()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgSiteFuel_MouseUp(sender As Object, e As MouseEventArgs) Handles dgSiteFuel.MouseUp
        Me.ttSiteFuel.Hide(Me.dgSiteFuel)
        If SelectedSiteFuelDataRow Is Nothing Then
            Exit Sub
        End If
        Dim message As String = ""
        'check for row before we call it
        If SelectedSiteFuelDataRow.Table.Columns.Contains("lastservicedate") Then
            Dim lsd As DateTime = Entity.Sys.Helper.MakeDateTimeValid(SelectedSiteFuelDataRow("lastservicedate"))
            If lsd <> Nothing AndAlso lsd > SqlTypes.SqlDateTime.MinValue.Value.AddYears(1) Then
                If lsd <= Now().AddDays(-365) Then
                    message = "Overdue"
                ElseIf lsd <= Now().AddDays(-352) And lsd > Now().AddDays(-365) Then
                    message = "Third letter stage"
                ElseIf lsd <= Now().AddDays(-330) And lsd > Now().AddDays(-352) Then
                    message = "Second letter stage"
                ElseIf lsd <= Now().AddDays(-309) And lsd > Now().AddDays(-330) Then
                    message = "First letter stage"
                ElseIf lsd <= Now().AddDays(-281) And lsd > Now().AddDays(-309) Then
                    message = "Service due soon"
                Else
                    Exit Sub
                End If
            Else
                message = "No service recorded"
            End If
        End If

        Dim hittest As System.Windows.Forms.DataGrid.HitTestInfo = dgSiteFuel.HitTest(e.X, e.Y)
        If hittest.Type = DataGrid.HitTestType.Cell Then
            If hittest.Row >= 0 Then
                Me.ttSiteFuel.Show(message, Me.dgSiteFuel, e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub dgSiteFuel_Leave(sender As Object, e As EventArgs) Handles dgSiteFuel.Leave
        Me.ttSiteFuel.Hide(Me.dgSiteFuel)
    End Sub

#End Region

#Region "Functions"

    Private Sub PopulateSiteFuelDataGrid()
        Try
            SiteFuelsDataView = DB.Sites.[SiteFuel_GetAll_ForSite](CurrentSite.SiteID)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateSiteAuditFuelDataGrid()
        Try
            SiteFuelAuditDataView = DB.Sites.[SiteFuelAudit_Get](CurrentSite.SiteID)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateSiteService_Click(sender As Object, e As EventArgs) Handles btnUpdateSiteService.Click
        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Servicing) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
            Exit Sub
        End If
        Dim fLSD As FRMLastServiceDate = ShowForm(GetType(FRMLastServiceDate), True, New Object() {CurrentSite.SiteID})
    End Sub

#End Region

End Class
