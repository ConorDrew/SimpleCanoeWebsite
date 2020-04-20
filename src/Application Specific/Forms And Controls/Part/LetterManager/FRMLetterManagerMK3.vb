Imports System.Collections.Generic
Imports FSM.Entity.Sys

Public Class FRMLetterManagerMK3 : Inherits FSM.FRMBaseForm : Implements IForm

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        Combo.SetUpCombo(Me.cboLetterNumber, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter)
        Me.cboLetterNumber.Items.RemoveAt(0)
        ResetFilters()
        SetupLettersDataGrid()
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

    Dim Avail As New DataTable
    Dim AvailView As New DataView
    Dim amtServ As Integer = 0 'how many services we need?
    Dim profile As Boolean = False
    Dim siteOnly As Boolean = False
    Dim Postcodes As List(Of String) = New List(Of String) ' postcode list
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

    Private Sub SetupLettersDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgServicesDue.TableStyles(0)

        Dim SendLetterTick As New DataGridBoolColumn
        SendLetterTick.HeaderText = "Send Letter"
        SendLetterTick.MappingName = "SendLetterTick"
        SendLetterTick.ReadOnly = True
        SendLetterTick.Width = 75
        SendLetterTick.NullText = ""
        tbStyle.GridColumnStyles.Add(SendLetterTick)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 60
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        Dim SiteFuel As New DataGridDistrictColumn
        SiteFuel.Format = ""
        SiteFuel.FormatInfo = Nothing
        SiteFuel.HeaderText = "Fuel Type"
        SiteFuel.MappingName = "SiteFuel"
        SiteFuel.ReadOnly = True
        SiteFuel.Width = 80
        SiteFuel.NullText = ""
        tbStyle.GridColumnStyles.Add(SiteFuel)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 300
        Name.NullText = ""
        tbStyle.GridColumnStyles.Add(Name)

        Dim Address1 As New DataGridLabelColumn
        Address1.Format = ""
        Address1.FormatInfo = Nothing
        Address1.HeaderText = "Address 1"
        Address1.MappingName = "Address1"
        Address1.ReadOnly = True
        Address1.Width = 250
        Address1.NullText = ""
        tbStyle.GridColumnStyles.Add(Address1)

        Dim Address2 As New DataGridLabelColumn
        Address2.Format = ""
        Address2.FormatInfo = Nothing
        Address2.HeaderText = "Address 2"
        Address2.MappingName = "Address2"
        Address2.ReadOnly = True
        Address2.Width = 140
        Address2.NullText = ""
        tbStyle.GridColumnStyles.Add(Address2)

        Dim Postcode As New DataGridLabelColumn
        Postcode.Format = ""
        Postcode.FormatInfo = Nothing
        Postcode.HeaderText = "Postcode"
        Postcode.MappingName = "Postcode"
        Postcode.ReadOnly = True
        Postcode.Width = 80
        Postcode.NullText = ""
        tbStyle.GridColumnStyles.Add(Postcode)

        Dim void As New DataGridVoidColumn
        void.Format = ""
        void.FormatInfo = Nothing
        void.HeaderText = "Void"
        void.MappingName = "PropertyVoid"
        void.ReadOnly = True
        void.Width = 80
        void.NullText = ""
        tbStyle.GridColumnStyles.Add(void)

        Dim LastServiceDate As New DataGridLabelColumn
        LastServiceDate.Format = "dd/MM/yyyy"
        LastServiceDate.FormatInfo = Nothing
        LastServiceDate.HeaderText = "Last Service Date"
        LastServiceDate.MappingName = "LastServiceDate"
        LastServiceDate.ReadOnly = True
        LastServiceDate.Width = 110
        LastServiceDate.NullText = ""
        tbStyle.GridColumnStyles.Add(LastServiceDate)

        Dim NextVisitDate As New DueDateColourColumn
        NextVisitDate.Format = "dd/MM/yyyy" 'Actually done in column
        NextVisitDate.FormatInfo = Nothing
        NextVisitDate.HeaderText = "Suggested Visit Date"
        NextVisitDate.MappingName = "NextVisitDate"
        NextVisitDate.ReadOnly = True
        NextVisitDate.Width = 160
        NextVisitDate.NullText = ""
        tbStyle.GridColumnStyles.Add(NextVisitDate)

        Dim AMPM As New DataGridLabelColumn
        AMPM.Format = ""
        AMPM.FormatInfo = Nothing
        AMPM.HeaderText = "AM/PM"
        AMPM.MappingName = "AMPM"
        AMPM.ReadOnly = True
        AMPM.Width = 50
        AMPM.NullText = ""
        tbStyle.GridColumnStyles.Add(AMPM)

        Dim EngName As New DataGridLabelColumn
        EngName.Format = ""
        EngName.FormatInfo = Nothing
        EngName.HeaderText = "Engineer"
        EngName.MappingName = "EngName"
        EngName.ReadOnly = True
        EngName.Width = 180
        EngName.NullText = ""
        tbStyle.GridColumnStyles.Add(EngName)

        Dim NextVisit As New DataGridLabelColumn
        NextVisit.Format = "dd/MM/yyyy"
        NextVisit.FormatInfo = Nothing
        NextVisit.HeaderText = "Next Visit"
        NextVisit.MappingName = "NextVisit"
        NextVisit.ReadOnly = True
        NextVisit.Width = 100
        NextVisit.NullText = ""
        tbStyle.GridColumnStyles.Add(NextVisit)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = "ServiceDue"
        Me.dgServicesDue.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnFindCustomer.Click
        Dim customerID As Integer = FindRecord(Enums.TableNames.tblCustomer)
        If customerID > 0 Then
            theCustomer = DB.Customer.Customer_Get(customerID)
        End If
        btnGenerateLetters.Enabled = False
    End Sub

    Private Sub FRMLetterManagerMK3_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnResetFilters_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnResetFilters.Click
        ResetFilters()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnFilter.Click
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
            If ShowMessage("Bank Holdiays are due soon, would you like to amended the filter dates before proceeding",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Exit Sub
            End If
        End If

        PopulateDatagrid()
        If chkLettersOnly.Checked = False Then
            GetAppointments()
        End If

        btnGenerateLetters.Enabled = True
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        If ServiceDueDataview IsNot Nothing AndAlso ServiceDueDataview.Count > 0 Then
            ServiceDueDataview.AllowEdit = True
            For Each r As DataRowView In ServiceDueDataview
                r("SendLetterTick") = True
            Next
            ServiceDueDataview.AllowEdit = False
        End If
    End Sub

    Private Sub btnUnselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnselect.Click
        If ServiceDueDataview IsNot Nothing AndAlso ServiceDueDataview.Count > 0 Then
            ServiceDueDataview.AllowEdit = True
            For Each r As DataRow In ServiceDueDataview.Table.Rows
                r("SendLetterTick") = False
            Next
            ServiceDueDataview.AllowEdit = False
        End If
    End Sub

    Private Sub btnGenerateLetters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateLetters.Click
        If chkLettersOnly.Checked = False Then
            GetAppointments(True)

            If siteOnly = True Then
                Me.grpServices.Text = "Services Due"
                ServiceDueDataview = New DataView(New DataTable)
                siteOnly = False
                Exit Sub
            End If

            PopulateDatagrid()
            GetAppointments()
        Else
            Dim SelectedServiceDueView As New DataView
            SelectedServiceDueView.Table = ServiceDueDataview.Table
            SelectedServiceDueView.RowFilter = "SendLetterTick = 1"
            Dim details As New ArrayList
            details.Add(SelectedServiceDueView)
            Dim oPrint As New Printing(details, "NCC Service Letters MK3", Enums.SystemDocumentType.ServiceLettersMK2,
                                       True, 0, False, tbMinsPerDay.Text, theCustomer.CustomerID, dtpLetterCreateDate.Text)
        End If
    End Sub

    Private Sub chkLettersOnly_CheckedChanged(sender As Object, e As EventArgs) Handles chkLettersOnly.CheckedChanged
        If Not ServiceDueDataview Is Nothing AndAlso ServiceDueDataview.Count > 0 Then
            ServiceDueDataview.Table.Clear()
        End If
    End Sub

    Private Sub btnReleaseLockedSites_Click(sender As Object, e As EventArgs) Handles btnReleaseLockedSites.Click
        For Each dr As DataRowView In ServiceDueDataview
            DB.LetterManager.ClearStuckSite(dr("LastServiceDate"), dr("SiteID"), dr("Type"))
        Next
    End Sub

    Private Sub dgServicesDue_MouseClick(sender As Object, e As MouseEventArgs) Handles dgServicesDue.MouseClick
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgServicesDue.HitTest(e.X, e.Y)
        If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            If HitTestInfo.Column = 0 Then
                If SelectedServiceDueDataRow Is Nothing Then
                    Exit Sub
                End If

                Dim selected As Boolean = Not CBool(Me.dgServicesDue(Me.dgServicesDue.CurrentRowIndex, 0))
                Me.dgServicesDue(Me.dgServicesDue.CurrentRowIndex, 0) = selected

                If Not SelectedServiceDueDataRow.Table.Columns.Contains("MultipleFuelSite") Then
                    Exit Sub
                End If

                If Helper.MakeBooleanValid(SelectedServiceDueDataRow("MultipleFuelSite")) Then
                    Dim mf As DataRow() =
                        ServiceDueDataview.Table.Select("SiteID = " & Helper.MakeIntegerValid(SelectedServiceDueDataRow("SiteID")) &
                        "AND MultipleFuelSite = True")
                    For Each f As DataRow In mf
                        f("SendLetterTick") = SelectedServiceDueDataRow("SendLetterTick")
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub btnFindSite_Click(sender As Object, e As EventArgs) Handles btnFindSite.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblSite)
        If Not ID = 0 Then
            Dim oSite As Entity.Sites.Site = DB.Sites.Get(ID)

            If oSite IsNot Nothing AndAlso oSite.Exists Then
                ServiceDueDataview = DB.LetterManager.LetterManagerAddSiteMK3(dtpLetterCreateDate.Value, oSite.SiteID)
                If ServiceDueDataview.Count > 0 Then
                    CalcAvail()
                    Me.grpServices.Text = "Site"
                    GetAppointments()
                    siteOnly = True
                    btnGenerateLetters.Enabled = True
                Else
                    ShowMessage("Site could not be added to process, please check site or contact IT!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

#End Region

#Region "Functions"

    Public Sub CalcAvail()

        profile = False
        Dim fake As Boolean = False
        If Avail.Columns.Count = 0 Then
            Avail.Columns.Add("Day")
            Avail.Columns.Add("Avail")
            Avail.Columns("Avail").DataType = Type.GetType("System.Int32")
            Avail.TableName = "apps"
        End If
        Avail.Clear()
        AvailView.Table = Avail
        If theCustomer.WinterServ > 0 And theCustomer.SummerServ > 0 Then
            Dim friday2weeks As Date = DateHelper.GetTheFriday(dtpLetterCreateDate.Value.AddDays(14))

            For i As Integer = -4 To 0 Step 1
                Dim workingDaysInMonth As Integer = DateHelper.GetWorkingDays(
                    DateHelper.GetFirstDayOfMonth(friday2weeks.AddDays(i)),
                    DateHelper.GetLastDayOfMonth(friday2weeks.AddDays(i)))

                Dim nr As DataRow = AvailView.Table.NewRow
                If DateHelper.GetWorkingDays(friday2weeks.AddDays(i), friday2weeks.AddDays(i)) > 0 Then
                    Dim AlreadyBookedDT As DataTable =
                        DB.LetterManager.GetBucketsL1(friday2weeks.AddDays(i), theCustomer.CustomerID).Table

                    Dim Alreadybooked As Integer = 0
                    If AlreadyBookedDT.Rows.Count > 0 Then
                        Alreadybooked = AlreadyBookedDT.Rows(0)("ServicesBooked")
                    End If

                    If Month(friday2weeks.AddDays(i)) < 4 Or Month(friday2weeks.AddDays(i)) > 9 Then 'winter
                        nr("Day") = (i + 5)
                        nr("Avail") = CInt(Int((theCustomer.WinterServ / workingDaysInMonth) - Alreadybooked))
                        AvailView.Table.Rows.Add(nr)
                    Else
                        nr("Day") = (i + 5)
                        nr("Avail") = CInt(Int((theCustomer.SummerServ / workingDaysInMonth) - Alreadybooked))
                        AvailView.Table.Rows.Add(nr)
                    End If
                Else
                    nr("Day") = (i + 5)
                    nr("Avail") = 0
                    AvailView.Table.Rows.Add(nr)
                End If
            Next
        Else
            For i As Integer = 0 To 4 Step 1
                Dim nr As DataRow = AvailView.Table.NewRow
                nr("Day") = (i + 1)
                nr("Avail") = 0
                AvailView.Table.Rows.Add(nr)
            Next
            fake = True
        End If

        For Each dr As DataRow In AvailView.Table.Rows
            amtServ = amtServ + dr("Avail")
        Next

        If AvailView.Count > 0 And fake = False Then profile = True
    End Sub

    Public Sub PopulateDatagrid()
        Try
            If chkLettersOnly.Checked = False Then

                CalcAvail()

                Select Case Combo.GetSelectedItemValue(cboLetterNumber)
                    Case "1"
                        ServiceDueDataview = DB.LetterManager.Get_Letter1Jobs_MultipleFuel(DateHelper.GetTheFriday(dtpLetterCreateDate.Value), theCustomer.CustomerID)
                        If ServiceDueDataview.Count > 0 And amtServ > 0 Then amtServ -= ServiceDueDataview.Count
                        If amtServ < 0 Then amtServ = 0
                        ServiceDueDataview.Table.Merge(DB.LetterManager.Get_Letter1Jobs(DateHelper.GetTheFriday(dtpLetterCreateDate.Value), theCustomer.CustomerID, profile, amtServ).Table)
                    Case "2"
                        ServiceDueDataview = DB.LetterManager.Get_Letter2Jobs(dtpLetterCreateDate.Value, theCustomer.CustomerID)
                    Case "3"
                        Select Case theCustomer.CustomerID
                            Case Enums.Customer.NCC, Enums.Customer.WDC,
                                 Enums.Customer.Kier, Enums.Customer.CotmanHousing,
                                 Enums.Customer.Tendring, Enums.Customer.Saffron
                                ServiceDueDataview = DB.LetterManager.Get_Letter3Jobs(dtpLetterCreateDate.Value, theCustomer.CustomerID)
                        End Select
                    Case Else
                        ServiceDueDataview = DB.LetterManager.Get_Letter1Jobs_MultipleFuel(DateHelper.GetTheFriday(dtpLetterCreateDate.Value), theCustomer.CustomerID)
                        If ServiceDueDataview.Count > 0 And amtServ > 0 Then amtServ -= ServiceDueDataview.Count
                        If amtServ < 0 Then amtServ = 0
                        ServiceDueDataview.Table.Merge(DB.LetterManager.Get_Letter1Jobs(DateHelper.GetTheFriday(dtpLetterCreateDate.Value), theCustomer.CustomerID, profile, amtServ).Table)
                        ServiceDueDataview.Table.Merge(DB.LetterManager.Get_Letter2Jobs(dtpLetterCreateDate.Value, theCustomer.CustomerID).Table)
                        ServiceDueDataview.Table.Merge(DB.LetterManager.Get_Letter3Jobs(dtpLetterCreateDate.Value, theCustomer.CustomerID).Table)
                End Select
                If Not chkVoidProperty.Checked Then
                    ServiceDueDataview.RowFilter = "PropertyVoid = 0"
                End If
                If Not chkIncludePatchChecks.Checked AndAlso ServiceDueDataview.Table.Columns.Contains("PatchCheck") Then
                    ServiceDueDataview.RowFilter = "PatchCheck = 0"
                End If
            Else
                ServiceDueDataview = DB.LetterManager.GetLetterScheduledAppointmentsMK3(dtpLetterCreateDate.Value, theCustomer.CustomerID)
            End If

            grpServices.Text = "Services Due - " & ServiceDueDataview.Count
            Me.btnGenerateLetters.Enabled = True
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        Combo.SetSelectedComboItem_By_Value(Me.cboLetterNumber, 1)
        Me.dtpLetterCreateDate.Value = Now()
        theCustomer = DB.Customer.Customer_Get(CInt(Enums.Customer.Flagship))
    End Sub

    Function AppointmentStrip(ByRef appointments As DataTable, ByVal levelslist As List(Of Integer), ByVal Postcodes As List(Of String), Optional ByVal keepweekends As Boolean = False) As DataTable
        appointments.Columns.Add("SolidQual")
        appointments.Columns.Add("OilQual")
        appointments.Columns.Add("GasQual")
        appointments.Columns.Add("ASHPQual")
        appointments.Columns.Add("ComQual")

        For i1 As Integer = appointments.Rows.Count - 1 To 0 Step -1
            Dim dr As DataRow = appointments.Rows.Item(i1)
            If dr("keep") = 0 And dr("remove") = 0 Then

                '' remove non qualified engineers
                Dim engineerLevels As DataTable = DB.EngineerLevel.Get(dr("EngineerID")).Table
                Dim removeengineer As Boolean = True
                Dim cbuoc As Boolean = False
                Dim Solid As Boolean = False
                Dim Oil As Boolean = False
                Dim Gas As Boolean = False
                Dim ASHP As Boolean = False
                Dim com As Boolean = False
                For Each i As Integer In levelslist

                    For Each dr2 As DataRow In engineerLevels.Select("tick = 1")
                        If dr2("ManagerID") = CInt(Enums.EngineerQual.CBUOC) Then cbuoc = True
                        If dr2("ManagerID") = CInt(Enums.EngineerQual.SOLIDFUEL) Then Solid = True
                        If dr2("ManagerID") = CInt(Enums.EngineerQual.OILOFTEC) Then Oil = True
                        If dr2("ManagerID") = CInt(Enums.EngineerQual.DOMGAS) Then Gas = True
                        If dr2("ManagerID") = CInt(Enums.EngineerQual.ASHP) Then ASHP = True
                        If Helper.MakeStringValid(dr2("Name")).Length > 2 Then
                            If Helper.MakeStringValid(dr2("Name")).Substring(0, 3).Contains("COM") Then com = True
                        End If
                    Next

                    For Each dr2 As DataRow In engineerLevels.Select("tick = 1")
                        If i = dr2("ManagerID") Then
                            removeengineer = False
                            Exit For
                        End If
                        removeengineer = True
                    Next
                    If removeengineer = True Then Exit For
                Next

                If (Not IsDBNull(dr("ServPri"))) AndAlso dr("ServPri") = "10" Then removeengineer = True

                If removeengineer = False Then
                    removeengineer = True
                    Dim engpostcodes As List(Of String) = New List(Of String)
                    Dim dt As DataTable = DB.EngineerPostalRegion.GetTicked(dr("EngineerID")).Table
                    For Each row As DataRow In dt.Rows
                        engpostcodes.Add(row("Name"))
                    Next
                    For Each pc As String In Postcodes
                        If engpostcodes.Contains(pc) Then
                            removeengineer = False
                        End If
                    Next
                End If

                If removeengineer = False Then
                    If (Not IsDBNull(dr("ServPri"))) AndAlso dr("ServPri") = 10 Then
                        removeengineer = True
                    End If
                End If

                For Each dr3 As DataRow In appointments.Select("engineerid = " & dr("EngineerID"))
                    If removeengineer Then
                        dr3("remove") = 1
                    Else
                        dr3("keep") = 1
                        If Oil = True Then
                            dr3("OilQual") = 1
                        Else
                            dr3("OilQual") = 0
                        End If
                        If Solid = True Then
                            dr3("SolidQual") = 1
                        Else
                            dr3("SolidQual") = 0
                        End If
                        If ASHP = True Then
                            dr3("ASHPQual") = 1
                        Else
                            dr3("ASHPQual") = 0
                        End If
                        If Gas = True Then
                            dr3("GasQual") = 1
                        Else
                            dr3("GasQual") = 0
                        End If
                        If com = True Then
                            dr3("ComQual") = 1
                        Else
                            dr3("ComQual") = 0
                        End If
                    End If
                Next
            End If ' end of if that checks if its already been marked to be deleted
        Next

        Dim dtr As DataRow() = appointments.Select("remove = 1  AND CBUOC = 0")
        For Each dr9 As DataRow In dtr  '  remove the engineers not eligable
            appointments.Rows.Remove(dr9)
        Next

        'remove BH and saturdays
        If keepweekends = False Then
            Dim dtr2 As DataRow() = appointments.Select("1=1")

            For Each dr10 As DataRow In dtr2
                If CDate(dr10("thedate")).DayOfWeek = DayOfWeek.Saturday OrElse CDate(dr10("thedate")).DayOfWeek = DayOfWeek.Sunday OrElse dr10("BH") = 1 Then
                    appointments.Rows.Remove(dr10)
                End If
            Next
        End If

        Return appointments
    End Function

    Private Function GetAppointments(Optional ByVal DoJobs As Boolean = False) As Boolean
        Dim BookedAMPM As String = ""

        Me.Cursor = Cursors.WaitCursor

        Dim startProcess As DateTime = Now
        Dim SelectedServiceDueView As New DataView

        If ServiceDueDataview IsNot Nothing AndAlso ServiceDueDataview.Count > 0 Then
            SelectedServiceDueView.Table = SelectedServiceDueDataRow.Table

            If Not SelectedServiceDueView.Table.Columns.Contains("EngName") Then SelectedServiceDueView.Table.Columns.Add("EngName")
            If DoJobs Then
                SelectedServiceDueView.RowFilter = "SendLetterTick = 1"
            End If

            If SelectedServiceDueView.Count = 0 Then
                ShowMessage("No Services to Process!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
            End If

            If chkLastService.Checked Then SelectedServiceDueView.Sort = "LastServiceDate" Else SelectedServiceDueView.Sort = "Postcode"

            Dim AppointmentsView As New DataView
            AppointmentsView.Table = DB.LetterManager.Get_Appointments_Main_MK3(DateHelper.GetTheMonday(dtpLetterCreateDate.Value), 15, 31, CInt(tbMinsPerDay.Text) / 2)

            Dim levelsList As IList(Of Integer) = New List(Of Integer)
            Dim co As Integer = 0
            Dim dd() As DataRow = DB.Customer.Requirements_Get_For_CustomerID(theCustomer.CustomerID).Table.Select("tick = 1")
            For Each d As DataRow In dd
                levelsList.Add(d("ManagerID"))
                co += 1
            Next

            If co = 0 Then
                levelsList.Add(CInt(Enums.EngineerQual.RETAIL)) 'Retail Engineer Skill level
            End If
            Postcodes.Clear()

            For Each dr As DataRowView In SelectedServiceDueView
                Postcodes.Add(dr("Postcode").Substring(0, dr("Postcode").IndexOf("-")))
            Next

            AppointmentsView.Table = AppointmentStrip(AppointmentsView.Table, levelsList, Postcodes) ' strip out not postcoded engineers and those who dont work on this work.
            ' only engineers for this client who touch one of the postcodes left in the view

            Dim dtCloned As DataTable = AppointmentsView.Table.Clone  ' I was having issues with incorrect DataTypes when doing select statements .
            ' so i have Cloned the database here in order to set the columns DataType correctly
            dtCloned.Columns.Add("AMCLOSE")
            dtCloned.Columns.Add("PMCLOSE")
            dtCloned.Columns("AMCLOSE").DataType = Type.GetType("System.Int32")
            dtCloned.Columns("PMCLOSE").DataType = Type.GetType("System.Int32")
            dtCloned.Columns("DATE").DataType = Type.GetType("System.DateTime")

            For Each row As DataRow In AppointmentsView.Table.Rows  ' then copy the data back
                dtCloned.ImportRow(row)
            Next

            AppointmentsView.Table = dtCloned ' and apply the new structure
            AppointmentsView.Sort = "ServPri ASC, EngineerID, daynumber"
            Dim AllEngineerPostcodes As DataView = DB.EngineerPostalRegion.GetALLTicked()

            Try ' Added a try to stop it breaking the app when an error occours

                Dim c As Integer = -1
                Do
                    c = c + 1
                    Dim ServiceVisit As DataRowView = SelectedServiceDueView(c)

                    '''''''''''''''''''''''''''In Area Shit ''''''''''''''''''''''''''''''''

                    For Each dr As DataRow In AppointmentsView.Table.Rows
                        If Not IsDBNull(dr("AMLatitude")) And Not IsDBNull(ServiceVisit("Latitude")) Then
                            Dim d As Double = Helper.MakeDoubleValid(Helper.Distance(dr("AMLatitude"), dr("AMLongitude"), ServiceVisit("Latitude"), ServiceVisit("Longitude"), "M"))
                            dr("AMCLOSE") = d
                        Else
                            dr("AMCLOSE") = DBNull.Value
                        End If
                        If Not IsDBNull(dr("PMLatitude")) And Not IsDBNull(ServiceVisit("Latitude")) Then
                            Dim d2 As Double = Helper.MakeDoubleValid(Helper.Distance(dr("PMLatitude"), dr("PMLongitude"), ServiceVisit("Latitude"), ServiceVisit("Longitude"), "M"))
                            dr("PMCLOSE") = d2
                        Else
                            dr("PMCLOSE") = DBNull.Value
                        End If
                    Next
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If IsDBNull(ServiceVisit("FuelID")) Then ServiceVisit("FuelID") = 0
                    If IsDBNull(ServiceVisit("CommercialDistrict")) Then ServiceVisit("CommercialDistrict") = False

                    Dim BookedDate As String = ""
                    Dim VisitTime As Integer = 40
                    Dim patchCheck As Boolean = ServiceVisit.Row.Table.Columns.Contains("PatchCheck") AndAlso ServiceVisit("PatchCheck") = True

                    If ServiceVisit("CommercialDistrict") = True Or patchCheck Then
                        VisitTime = 15
                    ElseIf (Not IsDBNull(ServiceVisit("FuelID")) AndAlso CInt(ServiceVisit("FuelID")) = Enums.FuelTypes.SolidFuel) Or
                        ServiceVisit("SolidFuel") = True Or
                        ServiceVisit("SiteFuel").ToString.ToUpper.Contains("SOLID FUEL") Then
                        VisitTime = 75
                    ElseIf (Not IsDBNull(ServiceVisit("FuelID")) AndAlso ServiceVisit("FuelID") = Enums.FuelTypes.Oil) Or
                        ServiceVisit("SiteFuel").ToString.ToUpper.Contains("OIL") Then
                        VisitTime = 60
                    Else
                        VisitTime = 40
                    End If

                    Dim suggestedVisit As DateTime = Helper.MakeDateTimeValid(ServiceVisit("NextVisitDate"))

                    Select Case ServiceVisit("Type").ToString()
                        Case "Letter 1"
                            AppointmentsView.RowFilter = "DATE <= #" & DateHelper.GetTheFriday(suggestedVisit).ToString("yyyy-MM-dd") & "# AND DATE >= #" & DateHelper.GetTheMonday(suggestedVisit).ToString("yyyy-MM-dd") & "#"
                        Case "Letter 2"
                            suggestedVisit = DateHelper.CheckBankHolidaySatOrSunForward(suggestedVisit)
                            AppointmentsView.RowFilter = "DATE <= #" & DateHelper.GetTheFriday(suggestedVisit).ToString("yyyy-MM-dd") & "# AND DATE >= #" & suggestedVisit.ToString("yyyy-MM-dd") & "#"
                        Case "Letter 3"
                            AppointmentsView.RowFilter = "DATE = #" & DateHelper.CheckBankHolidaySatOrSun(suggestedVisit).ToString("yyyy-MM-dd") & "#"
                    End Select

                    For Each EngineerApp As DataRowView In AppointmentsView

                        If AllEngineerPostcodes.Table.Select("EngineerID = " & EngineerApp("EngineerID") & " AND Name = '" & ServiceVisit("Postcode").ToString.Substring(0, ServiceVisit("Postcode").IndexOf("-")) & "'").Length > 0 Then
                            ' engineer works this area
                            'quals?
                            If ((ServiceVisit("FuelID") = Enums.FuelTypes.NatGas Or
                                ServiceVisit("FuelID") = Enums.FuelTypes.LPG Or
                                ServiceVisit("SiteFuel").ToString.ToUpper.Contains("GAS") Or
                                ServiceVisit("SiteFuel").ToString.ToUpper.Contains("LPG")) And
                                EngineerApp("GasQual") = 0) Or
                                ((ServiceVisit("FuelID") = Enums.FuelTypes.SolidFuel Or
                                ServiceVisit("SolidFuel") = True Or
                                ServiceVisit("SiteFuel").ToString.ToUpper.Contains("SOLID FUEL")) And
                                EngineerApp("SolidQual") = 0) Or
                                ((ServiceVisit("FuelID") = Enums.FuelTypes.Oil Or
                                ServiceVisit("SiteFuel").ToString.ToUpper.Contains("OIL")) And
                                EngineerApp("OilQual") = 0) Or
                                ((ServiceVisit("SiteFuel").ToString.ToUpper.Contains("AIR SOURCE") Or
                                ServiceVisit("SiteFuel").ToString.ToUpper.Contains("ASHP")) And
                                EngineerApp("ASHPQual") = 0) Or
                                ((ServiceVisit("CommercialDistrict") = True) And
                                EngineerApp("ComQual") = 0) Then
                                Continue For
                                ''''''''''          NULL ISSUE
                            End If

                            Dim FlagAMPeriodWasEmpty As Boolean = False
                            Dim FlagPMPeriodWasEmpty As Boolean = False

                            If IsDBNull(EngineerApp("AMCLOSE")) And IsDBNull(EngineerApp("PMCLOSE")) Then
                                EngineerApp("AMCLOSE") = -1
                                EngineerApp("PMCLOSE") = -1
                            ElseIf IsDBNull(EngineerApp("AMCLOSE")) Then
                                EngineerApp("AMCLOSE") = EngineerApp("PMCLOSE") - CInt(txtTravelBetween.Text)
                                FlagAMPeriodWasEmpty = True
                            ElseIf IsDBNull(EngineerApp("PMCLOSE")) Then
                                EngineerApp("PMCLOSE") = EngineerApp("AMCLOSE") - CInt(txtTravelBetween.Text)
                                FlagPMPeriodWasEmpty = True
                            End If

                            If EngineerApp("remainingAM") >= VisitTime And EngineerApp("AMCLOSE") < CInt(txtMaxTravel.Text) And Not (Not BookedDate Is Nothing And BookedAMPM = "PM") Then
                                ServiceVisit("EngName") = EngineerApp("Name")
                                ServiceVisit("EngineerID") = EngineerApp("EngineerID")
                                ServiceVisit("BookedDateTime") = EngineerApp("Date")
                                ServiceVisit("NextVisitDate") = EngineerApp("Date")
                                ServiceVisit("AMPM") = "AM"
                                EngineerApp("remainingAM") = EngineerApp("remainingAM") - VisitTime

                                AvailView.Table.Rows(CDate(EngineerApp("Date")).DayOfWeek - 1)("Avail") = AvailView.Table.Rows(CDate(EngineerApp("Date")).DayOfWeek - 1)("Avail") - 1

                                If CInt(EngineerApp("PMCLOSE")) = -1 Or FlagAMPeriodWasEmpty Then
                                    ' split this out to follow the code below
                                    Dim drs As DataRow() = AppointmentsView.Table.Select("EngineerID = " & CInt(ServiceVisit("EngineerID")) & " AND DATE = #" & suggestedVisit.ToString("yyyy-MM-dd") & "#")
                                    If drs.Length > -1 Then ' If We got results
                                        For Each dr As DataRow In drs
                                            dr("AMLatitude") = ServiceVisit("Latitude")
                                            dr("AMLongitude") = ServiceVisit("Longitude")
                                        Next
                                    End If

                                End If

                                Exit For
                            ElseIf EngineerApp("RemainingPM") >= VisitTime And EngineerApp("PMCLOSE") < CInt(txtMaxTravel.Text) And Not (Not BookedDate Is Nothing And BookedAMPM = "AM") Then
                                ServiceVisit("EngName") = EngineerApp("Name")
                                ServiceVisit("EngineerID") = EngineerApp("EngineerID")
                                ServiceVisit("BookedDateTime") = EngineerApp("Date")
                                ServiceVisit("NextVisitDate") = EngineerApp("Date")

                                ServiceVisit("AMPM") = "PM"
                                EngineerApp("remainingPM") = EngineerApp("remainingPM") - VisitTime

                                AvailView.Table.Rows(CDate(EngineerApp("Date")).DayOfWeek - 1)("Avail") = AvailView.Table.Rows(CDate(EngineerApp("Date")).DayOfWeek - 1)("Avail") - 1

                                If CInt(EngineerApp("PMCLOSE")) = -1 Or FlagPMPeriodWasEmpty Then ' legacy way was to do the select in one line
                                    For Each ee As DataRow In AppointmentsView.Table.Select("EngineerID = '" & ServiceVisit("EngineerID") & "' AND DATE = #" & suggestedVisit.ToString("yyyy-MM-dd") & "#")
                                        ee("PMLatitude") = ServiceVisit("Latitude")
                                        ee("PMLongitude") = ServiceVisit("Longitude")
                                    Next
                                End If

                                Exit For
                            End If
                        End If 'end of main if

                    Next

                    If Helper.MakeBooleanValid(ServiceVisit("MultipleFuelSite")) And Not IsDBNull(ServiceVisit("BookedDateTime")) Then
                        Dim mf As DataRow() = SelectedServiceDueView.Table.Select("SiteID = " & Helper.MakeIntegerValid(ServiceVisit("SiteID")))
                        For Each f As DataRow In mf
                            If Helper.MakeBooleanValid(f("MultipleFuelSite")) Then f("NextVisitDate") = ServiceVisit("NextVisitDate")
                        Next
                    End If

                Loop Until c >= SelectedServiceDueView.Count - 1
            Catch ex As Exception 'show the user
                ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' different way of catching the change
            Dim SchedulerAppsView As New DataView
            SchedulerAppsView.Table = DB.EngineerVisits.Get_Appointments_Scheduler(DateTime.Now.ToString("yyyy-MM-dd"), 15)
            SchedulerAppsView.Table = AppointmentStrip(SchedulerAppsView.Table, levelsList, Postcodes, False)
            SchedulerAppsView.Sort = "Daynumber"

            If SchedulerAppsView.Count = 0 Then
                MsgBox("Please ensure there is a scheduler which can except " & DB.Picklists.Get_One_As_Object(levelsList(0)).Name & " And you are not booking further than 28 days ahead", MsgBoxStyle.Critical)
                Return False
                Exit Function
            End If

            AvailView.Sort = "Avail DESC"
            Dim availdt As DataTable = AvailView.ToTable
            SelectedServiceDueView.RowFilter = ("EngineerID = 0 OR EngineerID IS NULL or EngName LIKE '%SCHED%'")
            SelectedServiceDueView.Sort = "MultipleFuelSite Desc"
            Dim c1 As Integer = 0
            For Each ServiceVisit As DataRowView In SelectedServiceDueView
                Dim BookedDate As String = ""
                c1 = c1 + 1
                Dim suggestedVisit As DateTime = Helper.MakeDateTimeValid(ServiceVisit("NextVisitDate"))
                Select Case ServiceVisit("Type").ToString()
                    Case "Letter 1"
                        SchedulerAppsView.RowFilter = "DATE <= #" & DateHelper.GetTheFriday(suggestedVisit).ToString("yyyy-MM-dd") & "# AND DATE >= #" & DateHelper.GetTheMonday(suggestedVisit).ToString("yyyy-MM-dd") & "#"
                        BookedDate = DateHelper.CheckBankHolidaySatOrSunForward(DateHelper.GetTheMonday(dtpLetterCreateDate.Value).AddDays(14 + (availdt.Rows(0)("Day") - 1)))
                    Case "Letter 2"
                        SchedulerAppsView.RowFilter = "DATE <= #" & DateHelper.GetTheFriday(suggestedVisit).ToString("yyyy-MM-dd") & "# AND DATE >= #" & DateHelper.GetTheMonday(suggestedVisit).ToString("yyyy-MM-dd") & "#"
                        BookedDate = DateHelper.CheckBankHolidaySatOrSunForward(DateHelper.GetTheMonday(dtpLetterCreateDate.Value).AddDays(14 + (availdt.Rows(0)("Day") - 1)))
                    Case "Letter 3"
                        SchedulerAppsView.RowFilter = "DATE = #" & DateHelper.CheckBankHolidaySatOrSun(suggestedVisit).ToString("yyyy-MM-dd") & "#"
                        BookedDate = DateHelper.CheckBankHolidaySatOrSun(suggestedVisit).ToString("dd/MM/yyyy")
                End Select

                If Helper.MakeBooleanValid(ServiceVisit("MultipleFuelSite")) Then
                    BookedDate = suggestedVisit
                End If

                For Each Scheduler As DataRowView In SchedulerAppsView
                    If AllEngineerPostcodes.Table.Select("EngineerID = " & Scheduler("EngineerID") & " AND Name = '" & ServiceVisit("Postcode").ToString.Substring(0, ServiceVisit("Postcode").IndexOf("-")) & "'").Length > 0 Then
                        ServiceVisit("EngName") = Scheduler("Name")
                        ServiceVisit("EngineerID") = Scheduler("EngineerID")
                        ServiceVisit("BookedDateTime") = BookedDate
                        ServiceVisit("NextVisitDate") = BookedDate
                        If c1 < 5 Then
                            ServiceVisit("AMPM") = "AM"
                            AvailView.Table.Rows((availdt.Rows(0)("Day") - 1))("Avail") = AvailView.Table.Rows((availdt.Rows(0)("Day") - 1))("Avail") - 1
                        ElseIf c1 > 4 Then
                            ServiceVisit("AMPM") = "PM"
                            AvailView.Table.Rows((availdt.Rows(0)("Day") - 1))("Avail") = AvailView.Table.Rows((availdt.Rows(0)("Day") - 1))("Avail") - 1
                            If c1 > 7 Then
                                c1 = 0
                                AvailView.Sort = "Avail DESC"
                                availdt = AvailView.ToTable
                            End If
                        End If
                    End If
                Next
            Next

            Try
                If DoJobs = True Then
                    SelectedServiceDueView.RowFilter = "SendLetterTick = 1"

                    Dim details As New ArrayList
                    details.Add(SelectedServiceDueView)
                    Dim oPrint As New Printing(details, "NCC Service Letters MK2", Enums.SystemDocumentType.ServiceLettersMK2, True, 0, False, tbMinsPerDay.Text, theCustomer.CustomerID, dtpLetterCreateDate.Text)
                    Dim endProcess As DateTime = Now
                    MsgBox("Start: " & startProcess & vbCrLf & "End: " & endProcess)
                End If
            Catch ex As Exception
                Return False
                ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                Me.Cursor = Cursors.Default

            End Try
        End If
        Me.Cursor = Cursors.Default
        Return True

    End Function

#End Region

End Class