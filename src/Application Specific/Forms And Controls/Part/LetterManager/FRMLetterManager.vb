Public Class FRMLetterManager : Inherits FSM.FRMBaseForm : Implements IForm

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        Combo.SetUpCombo(Me.cboLetterNumber, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        ResetFilters()
        SetupLettersDataGrid()
        PopulateDatagrid()
        Me.WindowState = FormWindowState.Maximized
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

    Private _dvServiceDue As DataView

    Private Property ServiceDueDataview() As DataView
        Get
            Return _dvServiceDue
        End Get
        Set(ByVal value As DataView)
            _dvServiceDue = value
            _dvServiceDue.AllowNew = False
            _dvServiceDue.AllowEdit = False
            _dvServiceDue.AllowDelete = False
            _dvServiceDue.Table.TableName = "ServiceDue"
            Me.dgServicesDue.DataSource = ServiceDueDataview
        End Set
    End Property

    Private ReadOnly Property SelectedServiceDueDataRow() As DataRow
        Get
            If Not Me.dgServicesDue.CurrentRowIndex = -1 Then
                Return ServiceDueDataview(Me.dgServicesDue.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _customer As Entity.Customers.Customer

    Public Property Customer() As Entity.Customers.Customer
        Get
            Return _customer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _customer = Value
            If Not _customer Is Nothing Then
                Me.txtCustomer.Text = _customer.Name & " (A/C No : " & _customer.AccountNumber & ")"
            Else
                Me.txtCustomer.Text = ""
            End If

        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupLettersDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgServicesDue.TableStyles(0)

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tbStyle.GridColumnStyles.Add(Tick)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 80
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        Dim SiteFuel As New DataGridLabelColumn
        SiteFuel.Format = ""
        SiteFuel.FormatInfo = Nothing
        SiteFuel.HeaderText = "SiteFuel"
        SiteFuel.MappingName = "SiteFuel"
        SiteFuel.ReadOnly = True
        SiteFuel.Width = 150
        SiteFuel.NullText = ""
        tbStyle.GridColumnStyles.Add(SiteFuel)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 150
        Name.NullText = ""
        tbStyle.GridColumnStyles.Add(Name)

        Dim Address1 As New DataGridLabelColumn
        Address1.Format = ""
        Address1.FormatInfo = Nothing
        Address1.HeaderText = "Address1"
        Address1.MappingName = "Address1"
        Address1.ReadOnly = True
        Address1.Width = 150
        Address1.NullText = ""
        tbStyle.GridColumnStyles.Add(Address1)

        Dim Address2 As New DataGridLabelColumn
        Address2.Format = ""
        Address2.FormatInfo = Nothing
        Address2.HeaderText = "Address2"
        Address2.MappingName = "Address2"
        Address2.ReadOnly = True
        Address2.Width = 150
        Address2.NullText = ""
        tbStyle.GridColumnStyles.Add(Address2)

        Dim Address3 As New DataGridLabelColumn
        Address3.Format = ""
        Address3.FormatInfo = Nothing
        Address3.HeaderText = "Address3"
        Address3.MappingName = "Address3"
        Address3.ReadOnly = True
        Address3.Width = 150
        Address3.NullText = ""
        tbStyle.GridColumnStyles.Add(Address3)

        Dim Postcode As New DataGridLabelColumn
        Postcode.Format = ""
        Postcode.FormatInfo = Nothing
        Postcode.HeaderText = "Postcode"
        Postcode.MappingName = "Postcode"
        Postcode.ReadOnly = True
        Postcode.Width = 150
        Postcode.NullText = ""
        tbStyle.GridColumnStyles.Add(Postcode)

        Dim LastServiceDate As New DataGridLabelColumn
        LastServiceDate.Format = "dd/MM/yyyy"
        LastServiceDate.FormatInfo = Nothing
        LastServiceDate.HeaderText = "Last Service Date"
        LastServiceDate.MappingName = "LastServiceDate"
        LastServiceDate.ReadOnly = True
        LastServiceDate.Width = 150
        LastServiceDate.NullText = ""
        tbStyle.GridColumnStyles.Add(LastServiceDate)

        Dim NextVisitDate As New DueDateColourColumn
        NextVisitDate.Format = "dddd dd/MM/yyyy" 'Actually done in column
        NextVisitDate.FormatInfo = Nothing
        NextVisitDate.HeaderText = "Due Date"
        NextVisitDate.MappingName = "NextVisitDate"
        NextVisitDate.ReadOnly = True
        NextVisitDate.Width = 150
        NextVisitDate.NullText = ""
        tbStyle.GridColumnStyles.Add(NextVisitDate)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = "ServiceDue"

        Me.dgServicesDue.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMJobManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnResetFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetFilters.Click
        ResetFilters()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim theDate As DateTime = dtpLetterCreateDate.Value
        Dim bankHoliday As Boolean = False

        Dim dvBankHolidays As DataView = DB.TimeSlotRates.BankHolidays_GetAll

        For i As Integer = 1 To 4
            theDate = theDate.AddDays(1)
            If dvBankHolidays.Table.Select("BankHolidayDate='" & CDate(Format(theDate, "dd/MM/yyyy")) & "'").Length > 0 Then
                bankHoliday = True
            Else
                If theDate.DayOfWeek <> DayOfWeek.Saturday And theDate.DayOfWeek <> DayOfWeek.Sunday Then
                    Exit For
                End If
            End If
        Next i

        If bankHoliday Then
            If ShowMessage("Bank Holdiays are due soon, would you like to amended the filter dates before proceeding", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Exit Sub
            End If
        End If

        PopulateDatagrid()
        btnGenerateLetters.Enabled = True
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        ServiceDueDataview.AllowEdit = True

        For Each r As DataRowView In ServiceDueDataview
            r("Tick") = True

        Next

        ServiceDueDataview.Table.AcceptChanges()
        ServiceDueDataview.AllowEdit = False
    End Sub

    Private Sub btnUnselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnselect.Click
        For Each r As DataRow In ServiceDueDataview.Table.Rows
            r("Tick") = False
        Next
    End Sub

    Private Sub btnGenerateLetters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateLetters.Click
        GenerateLetters()
    End Sub

    Private Sub dgServicesDue_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgServicesDue.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgServicesDue.HitTest(e.X, e.Y)
        If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            If HitTestInfo.Column = 0 Then
                Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(SelectedServiceDueDataRow.Item("tick"))
                SelectedServiceDueDataRow.Item("Tick") = selected
            End If
        End If
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            Dim Letter2 As New DataTable
            If Customer.CustomerID = -1 Then  '5872 ' Victory removed
                ServiceDueDataview = DB.LetterManager.Letter1Manager(Format(GetTheFriday(dtpLetterCreateDate.Value), "dd/MM/yyyy"), Customer.CustomerID, -323) ' change in days..
            Else
                ServiceDueDataview = DB.LetterManager.Letter1Manager(Format(GetTheFriday(dtpLetterCreateDate.Value), "dd/MM/yyyy"), Customer.CustomerID)
            End If
            If Customer.CustomerID = -1 Then ' 5872' Victory removed
                Letter2 = DB.LetterManager.Letter2Manager(Format(dtpLetterCreateDate.Value, "dd/MM/yyyy"), Customer.CustomerID, -337) ' change in days
            Else
                Letter2 = DB.LetterManager.Letter2Manager(Format(dtpLetterCreateDate.Value, "dd/MM/yyyy"), Customer.CustomerID)
            End If
            For Each dr2 As DataRow In Letter2.Rows
                Dim r2 As DataRow = ServiceDueDataview.Table.NewRow
                r2("Tick") = dr2("Tick")
                r2("Type") = dr2("Type")
                r2("Name") = dr2("Name")
                r2("Address1") = dr2("Address1")
                r2("Address2") = dr2("Address2")
                r2("Address3") = dr2("Address3")
                r2("Address4") = dr2("Address4")
                r2("Address5") = dr2("Address5")
                r2("Postcode") = dr2("Postcode")
                r2("SiteID") = dr2("SiteID")
                r2("SolidFuel") = dr2("SolidFuel")
                r2("Notes") = dr2("Notes")
                r2("PropertyVoid") = dr2("PropertyVoid")
                r2("LastServiceDate") = dr2("LastServiceDate")
                r2("NextVisitDate") = dr2("NextVisitDate")
                r2("SiteFuel") = dr2("SiteFuel")
                ServiceDueDataview.Table.Rows.Add(r2)
            Next dr2

            Dim Letter3 As DataTable = DB.LetterManager.Letter3Manager(Format(dtpLetterCreateDate.Value, "yyyy-MM-dd"), Customer.CustomerID)

            If Customer.CustomerID = Entity.Sys.Enums.Customer.NCC Then ' NCC , WDC , HAS , COT , TEN,  Saff
                For Each dr3 As DataRow In Letter3.Rows
                    Dim r3 As DataRow = ServiceDueDataview.Table.NewRow
                    r3("Tick") = dr3("Tick")
                    r3("Type") = dr3("Type")
                    r3("Name") = dr3("Name")
                    r3("Address1") = dr3("Address1")
                    r3("Address2") = dr3("Address2")
                    r3("Address3") = dr3("Address3")
                    r3("Address4") = dr3("Address4")
                    r3("Address5") = dr3("Address5")
                    r3("Postcode") = dr3("Postcode")
                    r3("SiteID") = dr3("SiteID")
                    r3("SolidFuel") = dr3("SolidFuel")
                    r3("Notes") = dr3("Notes")
                    r3("PropertyVoid") = dr3("PropertyVoid")
                    r3("LastServiceDate") = dr3("LastServiceDate")
                    r3("NextVisitDate") = dr3("NextVisitDate")
                    r3("SiteFuel") = dr3("SiteFuel")
                    ServiceDueDataview.Table.Rows.Add(r3)
                Next dr3
            End If

            If Combo.GetSelectedItemValue(cboLetterNumber) <> "0" Then
                ServiceDueDataview.RowFilter = "Type ='" & Combo.GetSelectedItemDescription(cboLetterNumber) & "'"
            End If

            grpServices.Text = "Services Due - " & ServiceDueDataview.Count

            Me.btnGenerateLetters.Enabled = True
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetTheFriday(ByVal DateIn As DateTime) As DateTime

        Select Case DateIn.DayOfWeek
            Case DayOfWeek.Monday
                Return DateIn.AddDays(4)
            Case DayOfWeek.Tuesday
                Return DateIn.AddDays(3)
            Case DayOfWeek.Wednesday
                Return DateIn.AddDays(2)
            Case DayOfWeek.Thursday
                Return DateIn.AddDays(1)
            Case DayOfWeek.Friday
                Return DateIn
            Case DayOfWeek.Saturday
                Return DateIn.AddDays(6)
            Case DayOfWeek.Sunday
                Return DateIn.AddDays(5)
        End Select
    End Function

    Private Sub ResetFilters()
        Combo.SetSelectedComboItem_By_Value(Me.cboLetterNumber, 0)
        Me.dtpLetterCreateDate.Value = Now()
        Customer = DB.Customer.Customer_Get(Entity.Sys.Enums.Customer.NCC)
    End Sub

    Private Sub GenerateLetters()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startProcess As DateTime = Now

            Dim filterList() As DataRow
            filterList = SelectedServiceDueDataRow.Table.Select("Tick=1")

            Dim details As New ArrayList
            details.Add(filterList)

            Dim oPrint As New Entity.Sys.Printing(details, "NCC Service Letters", Entity.Sys.Enums.SystemDocumentType.ServiceLetters, True, 0, False, tbMinsPerDay.Text, Customer.CustomerID, dtpLetterCreateDate.Text)

            PopulateDatagrid()

            Dim endProcess As DateTime = Now

            MsgBox("Start: " & startProcess & vbCrLf &
                    "End: " & endProcess)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

End Class