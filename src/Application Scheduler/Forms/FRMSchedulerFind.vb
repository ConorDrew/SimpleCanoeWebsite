Imports System.Collections.Generic
Imports FSM.Entity.Sys

Public Class FRMSchedulerFind
    Inherits System.Windows.Forms.Form

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

    Friend WithEvents grpFind As GroupBox
    Friend WithEvents rbtnOrder As RadioButton
    Friend WithEvents rbtnJob As RadioButton
    Friend WithEvents rbtnSite As RadioButton
    Friend WithEvents btnFind As Button
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents grpResult As GroupBox
    Friend WithEvents dgResults As DataGrid
    Friend WithEvents rbtnCustomer As RadioButton

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpFind = New System.Windows.Forms.GroupBox()
        Me.rbtnCustomer = New System.Windows.Forms.RadioButton()
        Me.rbtnOrder = New System.Windows.Forms.RadioButton()
        Me.rbtnJob = New System.Windows.Forms.RadioButton()
        Me.rbtnSite = New System.Windows.Forms.RadioButton()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.grpResult = New System.Windows.Forms.GroupBox()
        Me.dgResults = New System.Windows.Forms.DataGrid()
        Me.grpFind.SuspendLayout()
        Me.grpResult.SuspendLayout()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFind
        '
        Me.grpFind.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpFind.Controls.Add(Me.rbtnCustomer)
        Me.grpFind.Controls.Add(Me.rbtnOrder)
        Me.grpFind.Controls.Add(Me.rbtnJob)
        Me.grpFind.Controls.Add(Me.rbtnSite)
        Me.grpFind.Location = New System.Drawing.Point(12, 12)
        Me.grpFind.Name = "grpFind"
        Me.grpFind.Size = New System.Drawing.Size(97, 400)
        Me.grpFind.TabIndex = 0
        Me.grpFind.TabStop = False
        Me.grpFind.Text = "Find"
        '
        'rbtnCustomer
        '
        Me.rbtnCustomer.AutoSize = True
        Me.rbtnCustomer.Location = New System.Drawing.Point(11, 79)
        Me.rbtnCustomer.Name = "rbtnCustomer"
        Me.rbtnCustomer.Size = New System.Drawing.Size(69, 17)
        Me.rbtnCustomer.TabIndex = 4
        Me.rbtnCustomer.Text = "Customer"
        Me.rbtnCustomer.UseVisualStyleBackColor = True
        '
        'rbtnOrder
        '
        Me.rbtnOrder.AutoSize = True
        Me.rbtnOrder.Location = New System.Drawing.Point(11, 109)
        Me.rbtnOrder.Name = "rbtnOrder"
        Me.rbtnOrder.Size = New System.Drawing.Size(51, 17)
        Me.rbtnOrder.TabIndex = 3
        Me.rbtnOrder.Text = "Order"
        Me.rbtnOrder.UseVisualStyleBackColor = True
        Me.rbtnOrder.Visible = False
        '
        'rbtnJob
        '
        Me.rbtnJob.AutoSize = True
        Me.rbtnJob.Location = New System.Drawing.Point(11, 49)
        Me.rbtnJob.Name = "rbtnJob"
        Me.rbtnJob.Size = New System.Drawing.Size(42, 17)
        Me.rbtnJob.TabIndex = 2
        Me.rbtnJob.Text = "Job"
        Me.rbtnJob.UseVisualStyleBackColor = True
        '
        'rbtnSite
        '
        Me.rbtnSite.AutoSize = True
        Me.rbtnSite.Checked = True
        Me.rbtnSite.Location = New System.Drawing.Point(10, 19)
        Me.rbtnSite.Name = "rbtnSite"
        Me.rbtnSite.Size = New System.Drawing.Size(43, 17)
        Me.rbtnSite.TabIndex = 1
        Me.rbtnSite.TabStop = True
        Me.rbtnSite.Text = "Site"
        Me.rbtnSite.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.AccessibleDescription = ""
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFind.Location = New System.Drawing.Point(667, 18)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(48, 23)
        Me.btnFind.TabIndex = 5
        Me.btnFind.Text = "Find"
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(115, 20)
        Me.txtFilter.MaxLength = 25
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(546, 20)
        Me.txtFilter.TabIndex = 4
        '
        'grpResult
        '
        Me.grpResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResult.Controls.Add(Me.dgResults)
        Me.grpResult.Location = New System.Drawing.Point(115, 46)
        Me.grpResult.Name = "grpResult"
        Me.grpResult.Size = New System.Drawing.Size(600, 366)
        Me.grpResult.TabIndex = 4
        Me.grpResult.TabStop = False
        Me.grpResult.Text = "Result - Double Click to Open"
        '
        'dgResults
        '
        Me.dgResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgResults.DataMember = ""
        Me.dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgResults.Location = New System.Drawing.Point(6, 19)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.Size = New System.Drawing.Size(588, 341)
        Me.dgResults.TabIndex = 12
        '
        'FRMSchedulerFind
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(727, 424)
        Me.Controls.Add(Me.grpResult)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.grpFind)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.MinimizeBox = False
        Me.Name = "FRMSchedulerFind"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Find"
        Me.grpFind.ResumeLayout(False)
        Me.grpFind.PerformLayout()
        Me.grpResult.ResumeLayout(False)
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Properties"

    Private _dvResults As DataView

    Private Property DvResults() As DataView
        Get
            Return _dvResults
        End Get
        Set(ByVal value As DataView)
            _dvResults = value
            _dvResults.Table.TableName = Enums.TableNames.NO_TABLE.ToString
            Me.dgResults.DataSource = DvResults
        End Set
    End Property

    Private ReadOnly Property DrSelectedResult() As DataRow
        Get
            If Not Me.dgResults.CurrentRowIndex = -1 Then
                Return DvResults(Me.dgResults.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub FRMSchedulerFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _ssmList As New List(Of Enums.SecuritySystemModules) From {Enums.SecuritySystemModules.CreatePO, Enums.SecuritySystemModules.EditPO}
        rbtnOrder.Visible = loggedInUser.HasAccessToMulitpleModules(_ssmList)
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Find()
    End Sub

    Private Sub txtFilter_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFilter.KeyUp
        If e.KeyCode = Keys.Enter Then
            Find()
        End If
    End Sub

    Private Sub dgResults_DoubleClick(sender As Object, e As EventArgs) Handles dgResults.DoubleClick
        Open()
    End Sub

    Private Sub rbtn_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSite.CheckedChanged, rbtnCustomer.CheckedChanged, rbtnJob.CheckedChanged, rbtnOrder.CheckedChanged
        ResetForm()
    End Sub

#End Region

#Region "Function"

    Private Sub Find()
        Select Case True
            Case rbtnSite.Checked
                SetupDgSites()
                DvResults = DB.Sites.Search(Me.txtFilter.Text.Trim, loggedInUser.UserID)
            Case rbtnJob.Checked
                SetupDgJobs()
                DvResults = DB.Job.Search(Me.txtFilter.Text.Trim, loggedInUser.UserID)
            Case rbtnCustomer.Checked
                SetupDgCustomers()
                DvResults = DB.Customer.Customer_Search(Me.txtFilter.Text.Trim, loggedInUser.UserID)
            Case rbtnOrder.Checked
                SetupDgOrders()
                DvResults = DB.Order.Search(Me.txtFilter.Text.Trim, loggedInUser.UserID)
            Case Else
                ShowMessage("Please select an option!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    Private Sub Open()
        If DrSelectedResult Is Nothing Then
            ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Select Case True
            Case rbtnSite.Checked
                ShowForm(GetType(FRMSite), True, New Object() {Helper.MakeIntegerValid(DrSelectedResult("SiteID"))})
            Case rbtnJob.Checked
                ShowForm(GetType(FRMLogCallout), True, New Object() {Helper.MakeIntegerValid(DrSelectedResult("JobID")),
                         Helper.MakeIntegerValid(DrSelectedResult("SiteID")), Me})
            Case rbtnCustomer.Checked
                ShowForm(GetType(FRMCustomer), True, New Object() {Helper.MakeIntegerValid(DrSelectedResult("CustomerID"))})
            Case rbtnOrder.Checked
                Select Case Helper.MakeIntegerValid(DrSelectedResult("OrderTypeID"))
                    Case Enums.OrderType.Customer
                        ShowForm(GetType(FRMOrder), False, New Object() {Helper.MakeIntegerValid(DrSelectedResult("OrderID")),
                                 Helper.MakeIntegerValid(DrSelectedResult("SiteID")), 0, Me})
                    Case Enums.OrderType.StockProfile
                        ShowForm(GetType(FRMOrder), False, New Object() {Helper.MakeIntegerValid(DrSelectedResult("OrderID")),
                                 Helper.MakeIntegerValid(DrSelectedResult("VanID")), 0, Me})
                    Case Enums.OrderType.Warehouse
                        ShowForm(GetType(FRMOrder), False, New Object() {Helper.MakeIntegerValid(DrSelectedResult("OrderID")),
                                 Helper.MakeIntegerValid(DrSelectedResult("WarehouseID")), 0, Me})
                    Case Enums.OrderType.Job
                        ShowForm(GetType(FRMOrder), False, New Object() {Helper.MakeIntegerValid(DrSelectedResult("OrderID")),
                                 Helper.MakeIntegerValid(DrSelectedResult("EngineerVisitID")), 0, Me})
                End Select

            Case Else
                ShowMessage("Please select an option!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    Private Sub ResetForm()
        DvResults = New DataView(New DataTable)
        ClearDg()
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupDgSites()
        Helper.SetUpDataGrid(Me.dgResults)
        Dim dgts As DataGridTableStyle = Me.dgResults.TableStyles(0)

        Dim name As New DataGridLabelColumn
        name.Format = ""
        name.FormatInfo = Nothing
        name.HeaderText = "Name"
        name.MappingName = "Name"
        name.ReadOnly = True
        name.Width = 100
        name.NullText = ""
        dgts.GridColumnStyles.Add(name)

        Dim address1 As New DataGridLabelColumn
        address1.Format = ""
        address1.FormatInfo = Nothing
        address1.HeaderText = "Address 1"
        address1.MappingName = "Address1"
        address1.ReadOnly = True
        address1.Width = 100
        address1.NullText = ""
        dgts.GridColumnStyles.Add(address1)

        Dim address2 As New DataGridLabelColumn
        address2.Format = ""
        address2.FormatInfo = Nothing
        address2.HeaderText = "Address 2"
        address2.MappingName = "Address2"
        address2.ReadOnly = True
        address2.Width = 100
        address2.NullText = ""
        dgts.GridColumnStyles.Add(address2)

        Dim postcode As New DataGridLabelColumn
        postcode.Format = ""
        postcode.FormatInfo = Nothing
        postcode.HeaderText = "Postcode"
        postcode.MappingName = "Postcode"
        postcode.ReadOnly = True
        postcode.Width = 75
        postcode.NullText = ""
        dgts.GridColumnStyles.Add(postcode)

        Dim customer As New DataGridLabelColumn
        customer.Format = ""
        customer.FormatInfo = Nothing
        customer.HeaderText = "Customer"
        customer.MappingName = "CustomerName"
        customer.ReadOnly = True
        customer.Width = 100
        customer.NullText = ""
        dgts.GridColumnStyles.Add(customer)

        Dim policyNumber As New DataGridLabelColumn
        policyNumber.Format = ""
        policyNumber.FormatInfo = Nothing
        policyNumber.HeaderText = "Policy Number / UPRN"
        policyNumber.MappingName = "PolicyNumber"
        policyNumber.ReadOnly = True
        policyNumber.Width = 100
        policyNumber.NullText = ""
        dgts.GridColumnStyles.Add(policyNumber)

        Dim lsd As New DataGridLabelColumn
        lsd.Format = ""
        lsd.FormatInfo = Nothing
        lsd.HeaderText = "Last Service Date"
        lsd.MappingName = "LastServiceDate"
        lsd.ReadOnly = True
        lsd.Width = 100
        lsd.NullText = ""
        dgts.GridColumnStyles.Add(lsd)

        dgts.ReadOnly = True
        dgts.MappingName = Enums.TableNames.NO_TABLE.ToString
        Me.dgResults.TableStyles.Add(dgts)
    End Sub

    Public Sub SetupDgJobs()
        Helper.SetUpDataGrid(Me.dgResults)
        Dim dgts As DataGridTableStyle = Me.dgResults.TableStyles(0)

        Dim dateCreated As New DataGridLabelColumn
        dateCreated.Format = "dd/MM/yyyy"
        dateCreated.FormatInfo = Nothing
        dateCreated.HeaderText = "Created"
        dateCreated.MappingName = "DateCreated"
        dateCreated.ReadOnly = True
        dateCreated.Width = 75
        dateCreated.NullText = ""
        dgts.GridColumnStyles.Add(dateCreated)

        Dim jobNumber As New DataGridLabelColumn
        jobNumber.Format = ""
        jobNumber.FormatInfo = Nothing
        jobNumber.HeaderText = "Job No"
        jobNumber.MappingName = "JobNumber"
        jobNumber.ReadOnly = True
        jobNumber.Width = 75
        jobNumber.NullText = ""
        dgts.GridColumnStyles.Add(jobNumber)

        Dim type As New DataGridLabelColumn
        type.Format = ""
        type.FormatInfo = Nothing
        type.HeaderText = "Type"
        type.MappingName = "Type"
        type.ReadOnly = True
        type.Width = 100
        type.NullText = Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        dgts.GridColumnStyles.Add(type)

        Dim site As New DataGridLabelColumn
        site.Format = ""
        site.FormatInfo = Nothing
        site.HeaderText = "Site"
        site.MappingName = "Site"
        site.ReadOnly = True
        site.Width = 200
        site.NullText = ""
        dgts.GridColumnStyles.Add(site)

        Dim lastVisitDate As New DataGridLabelColumn
        lastVisitDate.Format = "dd/MM/yyyy"
        lastVisitDate.FormatInfo = Nothing
        lastVisitDate.HeaderText = "Last Visit's Date"
        lastVisitDate.MappingName = "LastVisitDate"
        lastVisitDate.ReadOnly = True
        lastVisitDate.Width = 100
        lastVisitDate.NullText = ""
        dgts.GridColumnStyles.Add(lastVisitDate)

        dgts.ReadOnly = True
        dgts.MappingName = Enums.TableNames.NO_TABLE.ToString
        Me.dgResults.TableStyles.Add(dgts)
    End Sub

    Public Sub SetupDgCustomers()
        Helper.SetUpDataGrid(Me.dgResults)
        Dim dgts As DataGridTableStyle = Me.dgResults.TableStyles(0)

        Dim customer As New DataGridLabelColumn
        customer.Format = ""
        customer.FormatInfo = Nothing
        customer.HeaderText = "Name"
        customer.MappingName = "Name"
        customer.ReadOnly = True
        customer.Width = 200
        customer.NullText = ""
        dgts.GridColumnStyles.Add(customer)

        Dim account As New DataGridLabelColumn
        account.Format = ""
        account.FormatInfo = Nothing
        account.HeaderText = "Account Number"
        account.MappingName = "AccountNumber"
        account.ReadOnly = True
        account.Width = 140
        account.NullText = ""
        dgts.GridColumnStyles.Add(account)

        Dim type As New DataGridLabelColumn
        type.Format = ""
        type.FormatInfo = Nothing
        type.HeaderText = "Type"
        type.MappingName = "Type"
        type.ReadOnly = True
        type.Width = 140
        type.NullText = ""
        dgts.GridColumnStyles.Add(type)

        Dim region As New DataGridLabelColumn
        region.Format = ""
        region.FormatInfo = Nothing
        region.HeaderText = "Region"
        region.MappingName = "Region"
        region.ReadOnly = True
        region.Width = 140
        region.NullText = ""
        dgts.GridColumnStyles.Add(region)

        dgts.ReadOnly = True
        dgts.MappingName = Enums.TableNames.NO_TABLE.ToString
        Me.dgResults.TableStyles.Add(dgts)
    End Sub

    Private Sub SetupDgOrders()
        Helper.SetUpDataGrid(Me.dgResults)
        Dim dgts As DataGridTableStyle = Me.dgResults.TableStyles(0)

        Dim dateCreated As New DataGridLabelColumn
        dateCreated.Format = "dd/MMM/yyyy"
        dateCreated.FormatInfo = Nothing
        dateCreated.HeaderText = "Date Placed"
        dateCreated.MappingName = "DatePlaced"
        dateCreated.ReadOnly = True
        dateCreated.Width = 90
        dateCreated.NullText = ""
        dgts.GridColumnStyles.Add(dateCreated)

        Dim orderReference As New DataGridLabelColumn
        orderReference.Format = ""
        orderReference.FormatInfo = Nothing
        orderReference.HeaderText = "Order Reference"
        orderReference.MappingName = "OrderReference"
        orderReference.ReadOnly = True
        orderReference.Width = 110
        orderReference.NullText = ""
        dgts.GridColumnStyles.Add(orderReference)

        Dim type As New DataGridLabelColumn
        type.Format = ""
        type.FormatInfo = Nothing
        type.HeaderText = "Type"
        type.MappingName = "Type"
        type.ReadOnly = True
        type.Width = 75
        type.NullText = Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        dgts.GridColumnStyles.Add(type)

        Dim supplier As New DataGridLabelColumn
        supplier.Format = ""
        supplier.FormatInfo = Nothing
        supplier.HeaderText = "Supplier"
        supplier.MappingName = "Supplier"
        supplier.ReadOnly = True
        supplier.Width = 100
        supplier.NullText = "N/A"
        dgts.GridColumnStyles.Add(supplier)

        Dim cost As New DataGridLabelColumn
        cost.Format = "C"
        cost.FormatInfo = Nothing
        cost.HeaderText = "Cost"
        cost.MappingName = "BuyPrice"
        cost.ReadOnly = True
        cost.Width = 75
        cost.NullText = "0"
        dgts.GridColumnStyles.Add(cost)

        Dim department As New DataGridLabelColumn
        department.Format = ""
        department.FormatInfo = Nothing
        department.HeaderText = "Dept"
        department.MappingName = "DepartmentRef"
        department.ReadOnly = True
        department.Width = 50
        department.NullText = ""
        dgts.GridColumnStyles.Add(department)

        Dim customer As New DataGridLabelColumn
        customer.Format = ""
        customer.FormatInfo = Nothing
        customer.HeaderText = "Customer"
        customer.MappingName = "Customer"
        customer.ReadOnly = True
        customer.Width = 140
        customer.NullText = "N/A"
        dgts.GridColumnStyles.Add(customer)

        Dim site As New DataGridLabelColumn
        site.Format = ""
        site.FormatInfo = Nothing
        site.HeaderText = "Property"
        site.MappingName = "Site"
        site.ReadOnly = True
        site.Width = 140
        site.NullText = "N/A"
        dgts.GridColumnStyles.Add(site)

        Dim jobNumber As New DataGridLabelColumn
        jobNumber.Format = ""
        jobNumber.FormatInfo = Nothing
        jobNumber.HeaderText = "Job Number"
        jobNumber.MappingName = "JobNumber"
        jobNumber.ReadOnly = True
        jobNumber.Width = 100
        jobNumber.NullText = "N/A"
        dgts.GridColumnStyles.Add(jobNumber)

        dgts.ReadOnly = True
        dgts.MappingName = Enums.TableNames.NO_TABLE.ToString
        Me.dgResults.TableStyles.Add(dgts)
    End Sub

    Private Sub ClearDg()
        Helper.SetUpDataGrid(Me.dgResults)
        Dim dgts As DataGridTableStyle = Me.dgResults.TableStyles(0)

        dgts.ReadOnly = True
        dgts.MappingName = Enums.TableNames.NO_TABLE.ToString
        Me.dgResults.TableStyles.Add(dgts)
    End Sub

#End Region

End Class