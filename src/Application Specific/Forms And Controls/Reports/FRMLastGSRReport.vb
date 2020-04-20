Public Class FRMLastGSRReport : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpJobs As System.Windows.Forms.GroupBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnPrintGSRReminders As System.Windows.Forms.Button
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkNotPrinted As System.Windows.Forms.CheckBox
    Friend WithEvents cboContract As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeTenantsAssets As System.Windows.Forms.CheckBox
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFilter As Button
    Friend WithEvents btnUnselect As Button
    Friend WithEvents btnSelectAll As Button
    Friend WithEvents btnEmailNone As Button
    Friend WithEvents btnEmailAll As Button
    Friend WithEvents dgProductsLastGSR As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobs = New System.Windows.Forms.GroupBox()
        Me.dgProductsLastGSR = New System.Windows.Forms.DataGrid()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboContract = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkIncludeTenantsAssets = New System.Windows.Forms.CheckBox()
        Me.chkNotPrinted = New System.Windows.Forms.CheckBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnPrintGSRReminders = New System.Windows.Forms.Button()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.btnUnselect = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnEmailNone = New System.Windows.Forms.Button()
        Me.btnEmailAll = New System.Windows.Forms.Button()
        Me.grpJobs.SuspendLayout()
        CType(Me.dgProductsLastGSR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpJobs
        '
        Me.grpJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobs.Controls.Add(Me.dgProductsLastGSR)
        Me.grpJobs.Location = New System.Drawing.Point(8, 185)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(1172, 271)
        Me.grpJobs.TabIndex = 1
        Me.grpJobs.TabStop = False
        Me.grpJobs.Text = "Service Reminders"
        '
        'dgProductsLastGSR
        '
        Me.dgProductsLastGSR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProductsLastGSR.DataMember = ""
        Me.dgProductsLastGSR.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProductsLastGSR.Location = New System.Drawing.Point(8, 19)
        Me.dgProductsLastGSR.Name = "dgProductsLastGSR"
        Me.dgProductsLastGSR.Size = New System.Drawing.Size(1156, 244)
        Me.dgProductsLastGSR.TabIndex = 0
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 464)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "Export"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.btnFilter)
        Me.grpFilter.Controls.Add(Me.cboRegion)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.cboContract)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.chkIncludeTenantsAssets)
        Me.grpFilter.Controls.Add(Me.chkNotPrinted)
        Me.grpFilter.Controls.Add(Me.btnFindCustomer)
        Me.grpFilter.Controls.Add(Me.txtCustomer)
        Me.grpFilter.Controls.Add(Me.Label4)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(1172, 115)
        Me.grpFilter.TabIndex = 0
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'btnFilter
        '
        Me.btnFilter.AccessibleDescription = ""
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(1031, 75)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(126, 23)
        Me.btnFilter.TabIndex = 15
        Me.btnFilter.Text = "Run Filter"
        '
        'cboRegion
        '
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Location = New System.Drawing.Point(310, 73)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(144, 21)
        Me.cboRegion.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(248, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Region"
        '
        'cboContract
        '
        Me.cboContract.FormattingEnabled = True
        Me.cboContract.Location = New System.Drawing.Point(85, 71)
        Me.cboContract.Name = "cboContract"
        Me.cboContract.Size = New System.Drawing.Size(144, 21)
        Me.cboContract.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Contract"
        '
        'chkIncludeTenantsAssets
        '
        Me.chkIncludeTenantsAssets.AutoSize = True
        Me.chkIncludeTenantsAssets.Location = New System.Drawing.Point(487, 21)
        Me.chkIncludeTenantsAssets.Name = "chkIncludeTenantsAssets"
        Me.chkIncludeTenantsAssets.Size = New System.Drawing.Size(157, 17)
        Me.chkIncludeTenantsAssets.TabIndex = 11
        Me.chkIncludeTenantsAssets.Text = "Include Tenants Assets"
        Me.chkIncludeTenantsAssets.UseVisualStyleBackColor = True
        '
        'chkNotPrinted
        '
        Me.chkNotPrinted.AutoSize = True
        Me.chkNotPrinted.Location = New System.Drawing.Point(664, 23)
        Me.chkNotPrinted.Name = "chkNotPrinted"
        Me.chkNotPrinted.Size = New System.Drawing.Size(66, 17)
        Me.chkNotPrinted.TabIndex = 12
        Me.chkNotPrinted.Text = "Printed"
        Me.chkNotPrinted.UseVisualStyleBackColor = True
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(1125, 44)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 7
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(85, 46)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(1034, 21)
        Me.txtCustomer.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Customer"
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(310, 20)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(144, 21)
        Me.dtpTo.TabIndex = 3
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(85, 20)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(144, 21)
        Me.dtpFrom.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(273, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 16)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "To"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Date From"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(72, 464)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        '
        'btnPrintGSRReminders
        '
        Me.btnPrintGSRReminders.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintGSRReminders.Location = New System.Drawing.Point(1039, 464)
        Me.btnPrintGSRReminders.Name = "btnPrintGSRReminders"
        Me.btnPrintGSRReminders.Size = New System.Drawing.Size(141, 23)
        Me.btnPrintGSRReminders.TabIndex = 5
        Me.btnPrintGSRReminders.Text = "Print GSR Reminders"
        Me.btnPrintGSRReminders.UseVisualStyleBackColor = True
        '
        'pbStatus
        '
        Me.pbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbStatus.Location = New System.Drawing.Point(134, 464)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(899, 23)
        Me.pbStatus.TabIndex = 4
        '
        'btnUnselect
        '
        Me.btnUnselect.Location = New System.Drawing.Point(137, 156)
        Me.btnUnselect.Name = "btnUnselect"
        Me.btnUnselect.Size = New System.Drawing.Size(96, 23)
        Me.btnUnselect.TabIndex = 9
        Me.btnUnselect.Text = "Unselect All"
        Me.btnUnselect.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(12, 156)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(119, 23)
        Me.btnSelectAll.TabIndex = 8
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnEmailNone
        '
        Me.btnEmailNone.Location = New System.Drawing.Point(373, 156)
        Me.btnEmailNone.Name = "btnEmailNone"
        Me.btnEmailNone.Size = New System.Drawing.Size(96, 23)
        Me.btnEmailNone.TabIndex = 11
        Me.btnEmailNone.Text = "Email None"
        Me.btnEmailNone.UseVisualStyleBackColor = True
        '
        'btnEmailAll
        '
        Me.btnEmailAll.Location = New System.Drawing.Point(248, 156)
        Me.btnEmailAll.Name = "btnEmailAll"
        Me.btnEmailAll.Size = New System.Drawing.Size(119, 23)
        Me.btnEmailAll.TabIndex = 10
        Me.btnEmailAll.Text = "Email All"
        Me.btnEmailAll.UseVisualStyleBackColor = True
        '
        'FRMLastGSRReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1188, 494)
        Me.Controls.Add(Me.btnEmailNone)
        Me.Controls.Add(Me.btnEmailAll)
        Me.Controls.Add(Me.btnUnselect)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.btnPrintGSRReminders)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpJobs)
        Me.Controls.Add(Me.btnReset)
        Me.MinimumSize = New System.Drawing.Size(808, 528)
        Me.Name = "FRMLastGSRReport"
        Me.Text = "Product Last GSR Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpJobs, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.Controls.SetChildIndex(Me.btnPrintGSRReminders, 0)
        Me.Controls.SetChildIndex(Me.pbStatus, 0)
        Me.Controls.SetChildIndex(Me.btnSelectAll, 0)
        Me.Controls.SetChildIndex(Me.btnUnselect, 0)
        Me.Controls.SetChildIndex(Me.btnEmailAll, 0)
        Me.Controls.SetChildIndex(Me.btnEmailNone, 0)
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgProductsLastGSR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        Combo.SetUpCombo(cboContract, DynamicDataTables.ContractOnOrNone, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboRegion, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        SetupTimesheetsDataGrid()
        Me.dtpFrom.Value = Today.AddYears(-1)
        Me.dtpTo.Value = Today.AddYears(-1).AddMonths(1)
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

    Private _ProductsDataview As DataView
    Private Property ProductsDataview() As DataView
        Get
            Return _ProductsDataview
        End Get
        Set(ByVal value As DataView)
            _ProductsDataview = value
            _ProductsDataview.AllowNew = False
            _ProductsDataview.AllowEdit = False
            _ProductsDataview.AllowDelete = False
            _ProductsDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString
            Me.dgProductsLastGSR.DataSource = ProductsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedProductDataRow() As DataRow
        Get
            If Not Me.dgProductsLastGSR.CurrentRowIndex = -1 Then
                Return ProductsDataview(Me.dgProductsLastGSR.CurrentRowIndex).Row
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
            If Not _theCustomer Is Nothing Then
                Me.txtCustomer.Text = theCustomer.Name & " (A/C No : " & theCustomer.AccountNumber & ")"
            Else
                Me.txtCustomer.Text = ""
            End If
        End Set
    End Property
#End Region

#Region "Setup"

    Private Sub SetupTimesheetsDataGrid()

        Dim tbStyle As DataGridTableStyle = Me.dgProductsLastGSR.TableStyles(0)

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tbStyle.GridColumnStyles.Add(Tick)

        Dim Email As New DataGridBoolColumn
        Email.HeaderText = "Email?"
        Email.MappingName = "Email"
        Email.ReadOnly = True
        Email.Width = 75
        Email.NullText = ""
        tbStyle.GridColumnStyles.Add(Email)

        Dim VisitDate As New DataGridLabelColumn
        VisitDate.Format = "dd/MM/yyyy"
        VisitDate.FormatInfo = Nothing
        VisitDate.HeaderText = "Last GSR Date"
        VisitDate.MappingName = "VisitDate"
        VisitDate.ReadOnly = True
        VisitDate.Width = 75
        VisitDate.NullText = "Not Done"
        tbStyle.GridColumnStyles.Add(VisitDate)

        Dim DueDate As New DataGridLabelColumn
        DueDate.Format = "dd/MM/yyyy"
        DueDate.FormatInfo = Nothing
        DueDate.HeaderText = "Due Date"
        DueDate.MappingName = "DueDate"
        DueDate.ReadOnly = True
        DueDate.Width = 75
        DueDate.NullText = "Not Done"
        tbStyle.GridColumnStyles.Add(DueDate)

        Dim Appliance As New DataGridLabelColumn
        Appliance.Format = ""
        Appliance.FormatInfo = Nothing
        Appliance.HeaderText = "Appliance"
        Appliance.MappingName = "Appliance"
        Appliance.ReadOnly = True
        Appliance.Width = 200
        Appliance.NullText = ""
        tbStyle.GridColumnStyles.Add(Appliance)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 200
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim Tenant As New DataGridLabelColumn
        Tenant.Format = ""
        Tenant.FormatInfo = Nothing
        Tenant.HeaderText = "Tenant"
        Tenant.MappingName = "Tenant"
        Tenant.ReadOnly = True
        Tenant.Width = 100
        Tenant.NullText = ""
        tbStyle.GridColumnStyles.Add(Tenant)

        Dim SerialNum As New DataGridLabelColumn
        SerialNum.Format = ""
        SerialNum.FormatInfo = Nothing
        SerialNum.HeaderText = "Serial"
        SerialNum.MappingName = "SerialNum"
        SerialNum.ReadOnly = True
        SerialNum.Width = 70
        SerialNum.NullText = ""
        tbStyle.GridColumnStyles.Add(SerialNum)

        Dim GaswayRef As New DataGridLabelColumn
        GaswayRef.Format = ""
        GaswayRef.FormatInfo = Nothing
        GaswayRef.HeaderText = "Gasway Ref"
        GaswayRef.MappingName = "BoughtFrom"
        GaswayRef.ReadOnly = True
        GaswayRef.Width = 70
        GaswayRef.NullText = ""
        tbStyle.GridColumnStyles.Add(GaswayRef)

        Dim Active As New BitToStringDescriptionColumn
        Active.Format = ""
        Active.FormatInfo = Nothing
        Active.HeaderText = "Active"
        Active.MappingName = "Active"
        Active.ReadOnly = True
        Active.Width = 70
        Active.NullText = ""
        tbStyle.GridColumnStyles.Add(Active)

        Dim TenantsAppliance As New BitToStringDescriptionColumn
        TenantsAppliance.Format = ""
        TenantsAppliance.FormatInfo = Nothing
        TenantsAppliance.HeaderText = "Tenants Appliance"
        TenantsAppliance.MappingName = "TenantsAppliance"
        TenantsAppliance.ReadOnly = True
        TenantsAppliance.Width = 100
        TenantsAppliance.NullText = ""
        tbStyle.GridColumnStyles.Add(TenantsAppliance)

        Dim OnContract As New BitToStringDescriptionColumn
        OnContract.Format = ""
        OnContract.FormatInfo = Nothing
        OnContract.HeaderText = "On Contract"
        OnContract.MappingName = "OnContract"
        OnContract.ReadOnly = True
        OnContract.Width = 75
        OnContract.NullText = ""
        tbStyle.GridColumnStyles.Add(OnContract)

        Dim Printed As New BitToStringDescriptionColumn
        Printed.Format = ""
        Printed.FormatInfo = Nothing
        Printed.HeaderText = "Printed"
        Printed.MappingName = "Printed"
        Printed.ReadOnly = True
        Printed.Width = 75
        Printed.NullText = ""
        tbStyle.GridColumnStyles.Add(Printed)

        Dim CustomerName As New DataGridLabelColumn
        CustomerName.Format = ""
        CustomerName.FormatInfo = Nothing
        CustomerName.HeaderText = "Customer"
        CustomerName.MappingName = "CustomerName"
        CustomerName.ReadOnly = True
        CustomerName.Width = 75
        CustomerName.NullText = ""
        tbStyle.GridColumnStyles.Add(CustomerName)

        Dim ContactNumbers As New DataGridLabelColumn
        CustomerName.Format = ""
        CustomerName.FormatInfo = Nothing
        ContactNumbers.HeaderText = "Contact Numbers"
        ContactNumbers.MappingName = "ContactNumbers"
        ContactNumbers.ReadOnly = True
        ContactNumbers.Width = 75
        ContactNumbers.NullText = ""
        tbStyle.GridColumnStyles.Add(ContactNumbers)

        Dim EmailAddress As New DataGridLabelColumn
        EmailAddress.Format = ""
        EmailAddress.FormatInfo = Nothing
        EmailAddress.HeaderText = "EmailAddress"
        EmailAddress.MappingName = "EmailAddress"
        EmailAddress.ReadOnly = True
        EmailAddress.Width = 75
        EmailAddress.NullText = ""
        tbStyle.GridColumnStyles.Add(EmailAddress)

        Dim ContactMade As New DataGridBoolColumn
        ContactMade.HeaderText = "Contact Made"
        ContactMade.MappingName = "OtherContactMade"
        ContactMade.ReadOnly = True
        ContactMade.Width = 75
        ContactMade.NullText = ""
        tbStyle.GridColumnStyles.Add(ContactMade)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString

        Me.dgProductsLastGSR.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMEngineerTimesheetReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Cursor.Current = Cursors.WaitCursor
        PopulateDatagrid()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnPrintGSRReminders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintGSRReminders.Click
        Cursor.Current = Cursors.WaitCursor
        Me.pbStatus.Value = 0
        Me.pbStatus.Maximum = CType(dgProductsLastGSR.DataSource, DataView).Count + 5

        Dim dvSelectedServiceReminders As New DataView
        dvSelectedServiceReminders.Table = ProductsDataview.Table
        dvSelectedServiceReminders.RowFilter = "tick = 1"

        Dim dt As New DataTable
        dt = ProductsDataview.Table.Clone

        For Each dr As DataRowView In dvSelectedServiceReminders
            Dim nr As DataRow
            nr = dt.NewRow
            nr("AssetID") = dr("AssetID")
            nr("VisitDate") = dr("VisitDate")
            nr("Appliance") = dr("Appliance")
            nr("Site") = dr("Site")
            nr("Tenant") = dr("Tenant")
            nr("Address1") = dr("Address1")
            nr("Address2") = dr("Address2")
            nr("Address3") = dr("Address3")
            nr("Postcode") = dr("Postcode")
            nr("SerialNum") = dr("SerialNum")
            nr("CustomerName") = dr("CustomerName")
            nr("Active") = dr("Active")
            nr("TenantsAppliance") = dr("TenantsAppliance")
            nr("BoughtFrom") = dr("BoughtFrom")
            nr("SiteID") = dr("SiteID")
            nr("CustomerID") = dr("CustomerID")
            nr("DueDate") = dr("DueDate")
            nr("Email") = dr("Email")
            nr("EmailAddress") = dr("EmailAddress")
            dt.Rows.Add(nr)
        Next dr

        Dim details As New ArrayList
        details.Add(New DataView(dt))
        details.Add(Me)
        Dim oPrint As New Entity.Sys.Printing(details, "GSR Reminder Letter", Entity.Sys.Enums.SystemDocumentType.GSRDue, True)
        MoveProgressOn(True)
        Me.pbStatus.Value = 0
        PopulateDatagrid()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            theCustomer = DB.Customer.Customer_Get(ID)
        End If
    End Sub

    Private Sub dg_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgProductsLastGSR.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgProductsLastGSR.HitTest(e.X, e.Y)
        If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            If HitTestInfo.Column = 0 Then
                If SelectedProductDataRow Is Nothing Then
                    Exit Sub
                End If

                Dim selected As Boolean = Not CBool(Me.dgProductsLastGSR(Me.dgProductsLastGSR.CurrentRowIndex, 0))
                Me.dgProductsLastGSR(Me.dgProductsLastGSR.CurrentRowIndex, 0) = selected
            End If

            If HitTestInfo.Column = 1 Then
                If SelectedProductDataRow Is Nothing Then
                    Exit Sub
                End If

                Dim selected As Boolean = Not CBool(Me.dgProductsLastGSR(Me.dgProductsLastGSR.CurrentRowIndex, 1))
                Me.dgProductsLastGSR(Me.dgProductsLastGSR.CurrentRowIndex, 1) = selected
            End If

            If HitTestInfo.Column = 14 Then
                Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(SelectedProductDataRow.Item("OtherContactMade"))
                SelectedProductDataRow.Item("OtherContactMade") = selected
                Dim exists As Integer = DB.ExecuteScalar("Select Count(*) from tblPrintedGSRLetters where CONVERT(DATE,DateDue) = CONVERT(DATE,'" & Entity.Sys.Helper.MakeDateTimeValid(SelectedProductDataRow.Item("DueDate")).ToString("yyyy-MM-dd") & "') AND AssetID = " & Entity.Sys.Helper.MakeIntegerValid(SelectedProductDataRow.Item("AssetID")))
                Dim i As Integer = 0
                If selected = True Then
                    i = 1
                Else
                    i = 0
                End If
                If exists = 0 Then
                    'insert
                    DB.EngineerVisitAssetWorkSheet.PrintedGSRLettersInsert(Entity.Sys.Helper.MakeIntegerValid(SelectedProductDataRow.Item("AssetID")), Entity.Sys.Helper.MakeDateTimeValid(SelectedProductDataRow.Item("DueDate")), True)
                Else
                    'update
                    DB.ExecuteScalar("UPDATE tblprintedGSRLetters set OtherContactMade = " & i & " where CONVERT(DATE,DateDue) = CONVERT(DATE,'" & Entity.Sys.Helper.MakeDateTimeValid(SelectedProductDataRow.Item("DueDate")).ToString("yyyy-MM-dd") & "') AND AssetID = " & Entity.Sys.Helper.MakeIntegerValid(SelectedProductDataRow.Item("AssetID")))
                End If
            End If
        End If

    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        ProductsDataview.AllowEdit = True
        For Each r As DataRowView In ProductsDataview
            r("tick") = True
        Next
        ProductsDataview.AllowEdit = False
    End Sub

    Private Sub btnUnselect_Click(sender As Object, e As EventArgs) Handles btnUnselect.Click
        ProductsDataview.AllowEdit = True
        For Each r As DataRowView In ProductsDataview
            r("tick") = False
        Next
        ProductsDataview.AllowEdit = False
    End Sub

    Private Sub btnEmailAll_Click(sender As Object, e As EventArgs) Handles btnEmailAll.Click
        ProductsDataview.AllowEdit = True
        For Each r As DataRowView In ProductsDataview
            r("email") = True
        Next
        ProductsDataview.AllowEdit = False
    End Sub

    Private Sub btnEmailNone_Click(sender As Object, e As EventArgs) Handles btnEmailNone.Click
        ProductsDataview.AllowEdit = True
        For Each r As DataRowView In ProductsDataview
            r("email") = False
        Next
        ProductsDataview.AllowEdit = False
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            Dim regionId As Integer = Combo.GetSelectedItemValue(Me.cboRegion)
            Dim customerId As Integer = 0
            If Not theCustomer Is Nothing Then customerId = theCustomer.CustomerID
            Dim onContract As Integer = 0
            Select Case Combo.GetSelectedItemValue(cboContract)
                Case "On Contract"
                    onContract = 1
                Case "Not On Contract"
                    onContract = 2
            End Select

            ProductsDataview = DB.EngineerVisitAssetWorkSheet.Products_LastGSRDone(
                Me.dtpFrom.Value, Me.dtpTo.Value, Combo.GetSelectedItemValue(Me.cboRegion),
                customerId, onContract, Me.chkIncludeTenantsAssets.Checked, Me.chkNotPrinted.Checked)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        theCustomer = Nothing
        Me.dtpFrom.Value = Today.AddYears(-1)
        Me.dtpTo.Value = Today.AddYears(-1).AddMonths(1)
        Me.grpFilter.Enabled = True
        Combo.SetSelectedComboItem_By_Value(cboContract, 0)
        Me.chkIncludeTenantsAssets.Checked = False
        Me.chkNotPrinted.Checked = True
    End Sub

    Public Sub Export()
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Visit Date"))
        dt.Columns.Add(New DataColumn("Appliance"))
        dt.Columns.Add(New DataColumn("Customer"))
        dt.Columns.Add(New DataColumn("Tenant"))
        dt.Columns.Add(New DataColumn("Address1"))
        dt.Columns.Add(New DataColumn("Address2"))
        dt.Columns.Add(New DataColumn("Address3"))
        dt.Columns.Add(New DataColumn("Address4"))
        dt.Columns.Add(New DataColumn("Postcode"))
        dt.Columns.Add(New DataColumn("Serial"))
        dt.Columns.Add(New DataColumn("GaswayRef"))
        dt.Columns.Add(New DataColumn("Active"))
        dt.Columns.Add(New DataColumn("TenantsAppliance"))
        dt.Columns.Add(New DataColumn("OnContract"))
        dt.Columns.Add(New DataColumn("Printed"))

        For itm As Integer = 0 To CType(dgProductsLastGSR.DataSource, DataView).Count - 1
            dgProductsLastGSR.CurrentRowIndex = itm

            Dim r As DataRow = dt.NewRow

            If Entity.Sys.Helper.MakeDateTimeValid(SelectedProductDataRow.Item("VisitDate")) = Nothing Then
                r.Item("Visit Date") = "Not Done"
            Else
                r.Item("Visit Date") = Format(Entity.Sys.Helper.MakeDateTimeValid(SelectedProductDataRow.Item("VisitDate")), "dd/MM/yyyy")
            End If

            r.Item("Appliance") = SelectedProductDataRow.Item("Appliance")
            r.Item("Customer") = SelectedProductDataRow.Item("CustomerName")
            r.Item("Address1") = SelectedProductDataRow.Item("Address1")
            r.Item("Address2") = SelectedProductDataRow.Item("Address2")
            r.Item("Address3") = SelectedProductDataRow.Item("Address3")
            r.Item("Address4") = SelectedProductDataRow.Item("Address4")
            r.Item("Postcode") = SelectedProductDataRow.Item("Postcode")
            r.Item("Tenant") = SelectedProductDataRow.Item("Tenant")
            r.Item("Serial") = SelectedProductDataRow.Item("SerialNum")
            r.Item("Active") = SelectedProductDataRow.Item("Active")
            r.Item("TenantsAppliance") = SelectedProductDataRow.Item("TenantsAppliance")
            r.Item("GaswayRef") = SelectedProductDataRow.Item("BoughtFrom")
            r.Item("OnContract") = SelectedProductDataRow.Item("OnContract")
            r.Item("Printed") = SelectedProductDataRow.Item("Printed")
            dt.Rows.Add(r)

            dgProductsLastGSR.UnSelect(itm)
        Next

        Dim exporter As New Entity.Sys.Exporting(dt, "Appliance GSR Report")
        exporter = Nothing
    End Sub

    Public Sub MoveProgressOn(Optional ByVal toMaximum As Boolean = False)
        If toMaximum Then
            Me.pbStatus.Value = Me.pbStatus.Maximum
        Else
            Me.pbStatus.Value += 1
        End If
        Application.DoEvents()
    End Sub

#End Region

End Class
