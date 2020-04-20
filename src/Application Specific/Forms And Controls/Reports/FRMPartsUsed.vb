Imports FSM.Entity.Sys

Public Class FRMPartsUsed : Inherits FSM.FRMBaseForm : Implements IForm

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        Combo.SetUpCombo(cboEngineer, DB.Engineer.Engineer_GetAll.Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select

        SetupPartsUsedDataGrid()
        ResetFilters()
        'PopulateDatagrid()
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

    Private _PartsDataview As DataView

    Private Property PartsDataview() As DataView
        Get
            Return _PartsDataview
        End Get
        Set(ByVal value As DataView)
            _PartsDataview = value
            _PartsDataview.AllowNew = False
            _PartsDataview.AllowEdit = False
            _PartsDataview.AllowDelete = False
            _PartsDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
            Me.dgPartsUsed.DataSource = PartsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedPartDataRow() As DataRow
        Get
            If Not Me.dgPartsUsed.CurrentRowIndex = -1 Then
                Return PartsDataview(Me.dgPartsUsed.CurrentRowIndex).Row
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
                Me.theSite = Nothing
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
                Me.txtSite.Text = theSite.Name & ", " & theSite.Address1 & ", " & theSite.Address2 & ", " & theSite.Postcode
            Else
                Me.txtSite.Text = ""
            End If
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupPartsUsedDataGrid()

        Dim tbStyle As DataGridTableStyle = Me.dgPartsUsed.TableStyles(0)

        Dim OrderReference As New DataGridLabelColumn
        OrderReference.Format = ""
        OrderReference.FormatInfo = Nothing
        OrderReference.HeaderText = "Order Ref"
        OrderReference.MappingName = "OrderReference"
        OrderReference.ReadOnly = True
        OrderReference.Width = 70
        OrderReference.NullText = ""
        tbStyle.GridColumnStyles.Add(OrderReference)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job No"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 60
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim PONumber As New DataGridLabelColumn
        PONumber.Format = ""
        PONumber.FormatInfo = Nothing
        PONumber.HeaderText = "PO No"
        PONumber.MappingName = "PONumber"
        PONumber.ReadOnly = True
        PONumber.Width = 70
        PONumber.NullText = ""
        tbStyle.GridColumnStyles.Add(PONumber)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Site"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 90
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 90
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Supplier As New DataGridLabelColumn
        Supplier.Format = ""
        Supplier.FormatInfo = Nothing
        Supplier.HeaderText = "Supplier"
        Supplier.MappingName = "Supplier"
        Supplier.ReadOnly = True
        Supplier.Width = 70
        Supplier.NullText = ""
        tbStyle.GridColumnStyles.Add(Supplier)

        Dim Engineer As New DataGridLabelColumn
        Engineer.Format = ""
        Engineer.FormatInfo = Nothing
        Engineer.HeaderText = "Engineer"
        Engineer.MappingName = "Engineer"
        Engineer.ReadOnly = True
        Engineer.Width = 90
        Engineer.NullText = ""
        tbStyle.GridColumnStyles.Add(Engineer)

        Dim BuyPrice As New DataGridLabelColumn
        BuyPrice.Format = "C"
        BuyPrice.FormatInfo = Nothing
        BuyPrice.HeaderText = "Buy Price"
        BuyPrice.MappingName = "BuyPrice"
        BuyPrice.ReadOnly = True
        BuyPrice.Width = 70
        BuyPrice.NullText = ""
        tbStyle.GridColumnStyles.Add(BuyPrice)

        Dim SellPrice As New DataGridLabelColumn
        SellPrice.Format = "C"
        SellPrice.FormatInfo = Nothing
        SellPrice.HeaderText = "SellPrice"
        SellPrice.MappingName = "SellPrice"
        SellPrice.ReadOnly = True
        SellPrice.Width = 70
        SellPrice.NullText = ""
        tbStyle.GridColumnStyles.Add(SellPrice)

        Dim PartName As New DataGridLabelColumn
        PartName.Format = ""
        PartName.FormatInfo = Nothing
        PartName.HeaderText = "Part Name"
        PartName.MappingName = "Name"
        PartName.ReadOnly = True
        PartName.Width = 70
        PartName.NullText = ""
        tbStyle.GridColumnStyles.Add(PartName)

        Dim PartNumber As New DataGridLabelColumn
        PartNumber.Format = ""
        PartNumber.FormatInfo = Nothing
        PartNumber.HeaderText = "PartNumber"
        PartNumber.MappingName = "Number"
        PartNumber.ReadOnly = True
        PartNumber.Width = 70
        PartNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(PartNumber)

        Dim Quantity As New DataGridLabelColumn
        Quantity.Format = ""
        Quantity.FormatInfo = Nothing
        Quantity.HeaderText = "Qty"
        Quantity.MappingName = "Quantity"
        Quantity.ReadOnly = True
        Quantity.Width = 35
        Quantity.NullText = ""
        tbStyle.GridColumnStyles.Add(Quantity)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MM/yyyy"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Visit Date"
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 70
        StartDateTime.NullText = ""
        tbStyle.GridColumnStyles.Add(StartDateTime)

        Dim JobType As New DataGridLabelColumn
        JobType.Format = ""
        JobType.FormatInfo = Nothing
        JobType.HeaderText = "Job Type"
        JobType.MappingName = "JobType"
        JobType.ReadOnly = True
        JobType.Width = 70
        JobType.NullText = ""
        tbStyle.GridColumnStyles.Add(JobType)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString

        Me.dgPartsUsed.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMEngineerTimesheetReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        'PopulateDatagrid()
        'RunFilter()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        'PopulateDatagrid()
        'RunFilter()
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim customerID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If customerID > 0 Then
            theCustomer = DB.Customer.Customer_Get(customerID)
        End If
        RunFilter()
    End Sub

    Private Sub btnFindSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSite.Click
        Dim siteID As Integer = 0
        If theCustomer Is Nothing Then
            siteID = FindRecord(Entity.Sys.Enums.TableNames.tblSite)
        Else
            siteID = FindRecord(Entity.Sys.Enums.TableNames.tblSite, theCustomer.CustomerID)
        End If
        If siteID > 0 Then
            theSite = DB.Sites.Get(siteID)
        End If

        RunFilter()
    End Sub

    Private Sub txtJobPONo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobPONo.TextChanged
        RunFilter()
    End Sub

    Private Sub txtPartNameOrNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartNameOrNumber.TextChanged
        RunFilter()
    End Sub

    Private Sub cboEngineer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEngineer.SelectedIndexChanged
        RunFilter()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            PartsDataview = DB.EngineerVisitsPartsAndProducts.Parts_Used_Report(Format(dtpFrom.Value, "dd-MMM-yyyy") & " 00:00:00", Format(dtpTo.Value, "dd-MMM-yyyy") & " 23:59:59")
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        theCustomer = Nothing
        Me.dtpFrom.Value = Today.AddMonths(-1)
        Me.dtpTo.Value = Today

        theCustomer = Nothing
        theSite = Nothing
        txtJobPONo.Text = ""
        txtPartNameOrNumber.Text = ""
        Combo.SetSelectedComboItem_By_Value(cboEngineer, 0)

        PopulateDatagrid()
        RunFilter()
    End Sub

    Private Sub RunFilter()
        If PartsDataview Is Nothing Then
            Exit Sub
        End If
        Dim whereClause As String = "1=1 "

        If Not theCustomer Is Nothing Then
            whereClause += " AND CustomerID = " & theCustomer.CustomerID & ""
        End If
        If Not theSite Is Nothing Then
            whereClause += " AND SiteID = " & theSite.SiteID & ""
        End If
        If txtJobPONo.Text.Length > 0 Then
            whereClause += " AND PONumber LIKE '" & txtJobPONo.Text & "%'"
        End If

        If txtPartNameOrNumber.Text.Length > 0 Then
            whereClause += " AND (Name LIKE '" & txtPartNameOrNumber.Text & "%' OR Number LIKE'" & txtPartNameOrNumber.Text & "%')"
        End If

        If Combo.GetSelectedItemValue(cboEngineer) > 0 Then
            whereClause += " AND EngineerID =" & Combo.GetSelectedItemValue(cboEngineer)
        End If

        Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(Me.cboDepartment))
        If Helper.IsValidInteger(department) AndAlso Not Helper.MakeIntegerValid(department) <= 0 Then
            whereClause += " AND Department = '" & department & "'"
        ElseIf Not IsNumeric(department) Then
            whereClause += " AND Department = '" & department & "'"
        End If

        PartsDataview.RowFilter = whereClause
    End Sub

    Public Sub Export()
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("OrderReference"))
        dt.Columns.Add(New DataColumn("JobNumber"))
        dt.Columns.Add(New DataColumn("PONumber"))
        dt.Columns.Add(New DataColumn("Site"))
        dt.Columns.Add(New DataColumn("Customer"))
        dt.Columns.Add(New DataColumn("Supplier"))
        dt.Columns.Add(New DataColumn("Engineer"))
        dt.Columns.Add(New DataColumn("BuyPrice"))
        dt.Columns.Add(New DataColumn("SellPrice"))
        dt.Columns.Add(New DataColumn("Name"))
        dt.Columns.Add(New DataColumn("Number"))
        dt.Columns.Add(New DataColumn("Quantity"))
        dt.Columns.Add(New DataColumn("StartDateTime"))
        dt.Columns.Add(New DataColumn("UPRN"))

        For itm As Integer = 0 To CType(dgPartsUsed.DataSource, DataView).Count - 1
            dgPartsUsed.CurrentRowIndex = itm

            Dim r As DataRow = dt.NewRow

            r.Item("OrderReference") = SelectedPartDataRow.Item("OrderReference")
            r.Item("JobNumber") = SelectedPartDataRow.Item("JobNumber")
            r.Item("PONumber") = SelectedPartDataRow.Item("PONumber")
            r.Item("Site") = SelectedPartDataRow.Item("Site")
            r.Item("Customer") = SelectedPartDataRow.Item("Customer")
            r.Item("Supplier") = SelectedPartDataRow.Item("Supplier")
            r.Item("Engineer") = SelectedPartDataRow.Item("Engineer")
            r.Item("BuyPrice") = SelectedPartDataRow.Item("BuyPrice")
            r.Item("SellPrice") = SelectedPartDataRow.Item("SellPrice")
            r.Item("Name") = SelectedPartDataRow.Item("Name")
            r.Item("Number") = SelectedPartDataRow.Item("Number")
            r.Item("Quantity") = SelectedPartDataRow.Item("Quantity")
            r.Item("StartDateTime") = SelectedPartDataRow.Item("StartDateTime")
            r.Item("UPRN") = SelectedPartDataRow.Item("UPRN")
            dt.Rows.Add(r)

            dgPartsUsed.UnSelect(itm)
        Next

        Dim exporter As New Entity.Sys.Exporting(dt, "Parts Used Report")
        exporter = Nothing
    End Sub

#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PopulateDatagrid()
        RunFilter()
    End Sub

End Class