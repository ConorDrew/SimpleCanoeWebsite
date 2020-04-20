Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Sys

Public Class FRMJobImportManager : Inherits FSM.FRMBaseForm : Implements IForm

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        Combo.SetUpCombo(Me.cboLetterNumber, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter)

        Me.cboLetterNumber.Items.RemoveAt(0)
        Me.cboLetterNumber.Items.RemoveAt(2) 'Remove letter 3

        Combo.SetSelectedComboItem_By_Value(Me.cboLetterNumber, 1)
        Combo.SetUpCombo(cboJobType, DB.JobImports.JobImportType_GetAll().Table, "JobImportTypeID", "Name", Enums.ComboValues.Please_Select)
        SetupJobDataGrid()

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

    Private _dvJobs As DataView
    Private jobsPerWeek As Integer = 0

    Private Property JobsDataView As DataView
        Get
            Return _dvJobs
        End Get
        Set(ByVal value As DataView)
            _dvJobs = value
            _dvJobs.Table.TableName = Enums.TableNames.tblJob.ToString
            Me.dgJobs.DataSource = JobsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedJobDataRow() As DataRow
        Get
            If Not Me.dgJobs.CurrentRowIndex = -1 Then
                Return JobsDataView(Me.dgJobs.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Class MaxAmPmAmounts
        Public amAmount As Integer
        Public pmAmount As Integer
    End Class

#End Region

#Region "Setup"

    Private Sub SetupJobDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgJobs.TableStyles(0)

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tbStyle.GridColumnStyles.Add(Tick)

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
        Address1.HeaderText = "Address 1"
        Address1.MappingName = "Address1"
        Address1.ReadOnly = True
        Address1.Width = 150
        Address1.NullText = ""
        tbStyle.GridColumnStyles.Add(Address1)

        Dim Address2 As New DataGridLabelColumn
        Address2.Format = ""
        Address2.FormatInfo = Nothing
        Address2.HeaderText = "Address 2"
        Address2.MappingName = "Address2"
        Address2.ReadOnly = True
        Address2.Width = 120
        Address2.NullText = ""
        tbStyle.GridColumnStyles.Add(Address2)

        Dim Address3 As New DataGridLabelColumn
        Address3.Format = ""
        Address3.FormatInfo = Nothing
        Address3.HeaderText = "Address 3"
        Address3.MappingName = "Address3"
        Address3.ReadOnly = True
        Address3.Width = 120
        Address3.NullText = ""
        tbStyle.GridColumnStyles.Add(Address3)

        Dim Postcode As New DataGridLabelColumn
        Postcode.Format = ""
        Postcode.FormatInfo = Nothing
        Postcode.HeaderText = "Postcode"
        Postcode.MappingName = "Postcode"
        Postcode.ReadOnly = True
        Postcode.Width = 85
        Postcode.NullText = ""
        tbStyle.GridColumnStyles.Add(Postcode)

        Dim TelNo As New DataGridLabelColumn
        TelNo.Format = ""
        TelNo.FormatInfo = Nothing
        TelNo.HeaderText = "Tel No."
        TelNo.MappingName = "TelNo"
        TelNo.ReadOnly = True
        TelNo.Width = 175
        TelNo.NullText = ""
        tbStyle.GridColumnStyles.Add(TelNo)

        Dim uprn As New DataGridLabelColumn
        uprn.Format = ""
        uprn.FormatInfo = Nothing
        uprn.HeaderText = "UPRN"
        uprn.MappingName = "UPRN"
        uprn.ReadOnly = True
        uprn.Width = 100
        uprn.NullText = ""
        tbStyle.GridColumnStyles.Add(uprn)

        Dim type As New DataGridLabelColumn
        type.Format = ""
        type.FormatInfo = Nothing
        type.HeaderText = "Type"
        type.MappingName = "Type"
        type.ReadOnly = True
        type.Width = 75
        type.NullText = ""
        tbStyle.GridColumnStyles.Add(type)

        Dim letter1 As New DataGridLabelColumn
        letter1.Format = "dd/MM/yyyy"
        letter1.FormatInfo = Nothing
        letter1.HeaderText = "Letter 1 Date"
        letter1.MappingName = "Letter1"
        letter1.ReadOnly = True
        letter1.Width = 110
        letter1.NullText = ""
        tbStyle.GridColumnStyles.Add(letter1)

        Dim letter2 As New DataGridLabelColumn
        letter2.Format = "dd/MM/yyyy"
        letter2.FormatInfo = Nothing
        letter2.HeaderText = "Letter 2 Date"
        letter2.MappingName = "Letter2"
        letter2.ReadOnly = True
        letter2.Width = 110
        letter2.NullText = ""
        tbStyle.GridColumnStyles.Add(letter2)

        Dim NextVisitDate As New DataGridLabelColumn
        NextVisitDate.Format = "dddd dd/MM/yyyy" 'Actually done in column
        NextVisitDate.FormatInfo = Nothing
        NextVisitDate.HeaderText = "Suggested Visit Date"
        NextVisitDate.MappingName = "NextVisitDate"
        NextVisitDate.ReadOnly = True
        NextVisitDate.Width = 130
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

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Enums.TableNames.tblJob.ToString

        Me.dgJobs.TableStyles.Add(tbStyle)
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

        For i As Integer = 1 To 13
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
        GetAppointments()

        btnGenerateLetters.Enabled = True
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        If JobsDataView IsNot Nothing AndAlso JobsDataView.Count > 0 Then
            For Each dr As DataRow In JobsDataView.Table.Select(JobsDataView.RowFilter)
                dr("Tick") = True
            Next
        End If
    End Sub

    Private Sub btnUnselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnselect.Click
        If JobsDataView IsNot Nothing AndAlso JobsDataView.Count > 0 Then
            For Each dr As DataRow In JobsDataView.Table.Select(JobsDataView.RowFilter)
                dr("Tick") = False
            Next
        End If
    End Sub

    Private Sub btnGenerateLetters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateLetters.Click
        GetAppointments(True)
        PopulateDatagrid()
        GetAppointments()
    End Sub

    Private Sub dgJobs_Click(sender As Object, e As EventArgs) Handles dgJobs.Click
        If SelectedJobDataRow Is Nothing Then
            Exit Sub
        End If

        Dim selected As Boolean = Not CBool(Me.dgJobs(Me.dgJobs.CurrentRowIndex, 0))
        Me.dgJobs(Me.dgJobs.CurrentRowIndex, 0) = selected
    End Sub

    Private Sub btnFindSite_Click(sender As Object, e As EventArgs) Handles btnFindSite.Click
        Dim ID As Integer = FindRecord(Enums.TableNames.tblSite)
        If Not ID = 0 Then
            Dim oSite As Entity.Sites.Site = DB.Sites.Get(ID)

            If oSite IsNot Nothing AndAlso oSite.Exists Then
                Me.grpJobs.Text = "Sites"
                JobsDataView = DB.JobImports.JobImport_Get_BySiteID(oSite.SiteID, Combo.GetSelectedItemValue(cboJobType))
                If JobsDataView.Count > 0 Then
                    Me.dgJobs.ContextMenuStrip = cmsAction
                Else
                    If Combo.GetSelectedItemValue(cboJobType) = 0 Then
                        ShowMessage("If you want to add site to the process." & vbCrLf & "Please select a work stream for site", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If ShowMessage("Add site to " & Combo.GetSelectedItemDescription(cboJobType) & " process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim jobImport As New Entity.JobImport.JobImport
                        With jobImport
                            .SetSiteID = oSite.SiteID
                            .SetUPRN = oSite.PolicyNumber
                            .SetJobImportTypeID = Combo.GetSelectedItemValue(cboJobType)
                            .DateAdded = Now
                        End With

                        jobImport = DB.JobImports.JobImport_Insert(jobImport)
                        If jobImport.Exists Then
                            If ShowMessage("Create job?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                JobsDataView = DB.JobImports.JobImport_Get_BySiteID(oSite.SiteID, Combo.GetSelectedItemValue(cboJobType))
                                Me.dgJobs.ContextMenuStrip = cmsAction
                            Else
                                Exit Sub
                            End If
                        End If
                    Else
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub tsmiDeleteSite_Click(sender As Object, e As EventArgs) Handles tsmiDeleteSite.Click
        If SelectedJobDataRow Is Nothing Then
            ShowMessage("Please select a site", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            If Not IsDBNull(SelectedJobDataRow("JobImportID")) Then
                If Not IsDBNull(SelectedJobDataRow("JobID")) Then
                    If ShowMessage("There is a job against this site!" & vbCrLf & vbCrLf & "Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                        Throw New Exception("Operation cancelled by user!")
                    End If
                End If
                Dim jobImportId As Integer = Helper.MakeIntegerValid(SelectedJobDataRow("JobImportID"))
                Dim jobImportTypeId As Integer = Helper.MakeIntegerValid(SelectedJobDataRow("JobImportTypeID"))

                DB.JobImports.JobImport_Delete_WithJobType(jobImportId, jobImportTypeId)
                ShowMessage("Site has been removed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.grpJobs.Text = "Jobs"
            JobsDataView = New DataView(New DataTable)
            Me.dgJobs.ContextMenuStrip = Nothing
        End Try
    End Sub

    Private Sub tsmiCreateJob_Click(sender As Object, e As EventArgs) Handles tsmiCreateJob.Click
        If SelectedJobDataRow Is Nothing Then
            ShowMessage("Please select a site", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            Dim job As New Entity.Jobs.Job
            job = DB.Job.CreateJobImportAdHocVisit(SelectedJobDataRow, False)
            If job Is Nothing Then Throw New Exception("Failed to generate job")
            Dim jobImportId As Integer = Helper.MakeIntegerValid(SelectedJobDataRow("JobImportID"))
            DB.JobImports.JobImport_Update_Job(jobImportId, job)
            ShowMessage("Job Created" & vbCrLf & vbCrLf & "Job Number: " & job.JobNumber, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.grpJobs.Text = "Jobs"
            JobsDataView = New DataView(New DataTable)
            Me.dgJobs.ContextMenuStrip = Nothing
        End Try
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            If Helper.MakeIntegerValid(Me.txtJobsPerDay.Text) = 0 Then
                ShowMessage("Cannot have 0 jobs a day!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim jobsPerDay As Integer = Helper.MakeIntegerValid(Me.txtJobsPerDay.Text)
            Dim jobimportTypeId As Integer = CInt(Combo.GetSelectedItemValue(cboJobType))
            Dim twoWeeks As Date = dtpLetterCreateDate.Value.AddDays(14)
            Dim workingDaysInWeek As Integer = DateHelper.GetWorkingDays(DateHelper.GetTheMonday(twoWeeks), DateHelper.GetTheFriday(twoWeeks))

            Dim letter1 As Boolean = Combo.GetSelectedItemValue(cboLetterNumber) = 1
            Dim jobsDt As DataTable = Nothing
            If chkSortPostcode.Checked Then
                jobsDt = If(letter1, DB.JobImports.JobImport_Get_L1Jobs(jobimportTypeId).Table, DB.JobImports.JobImport_Get_L2Jobs(jobimportTypeId).Table)
            Else
                jobsDt = If(letter1, DB.JobImports.JobImport_Get_L1Jobs_NoOrder(jobimportTypeId).Table, DB.JobImports.JobImport_Get_L2Jobs(jobimportTypeId).Table)
            End If

            jobsDt.Columns.Add("NextVisitDate")
            jobsDt.Columns.Add("LetterDate")

            Dim dates As List(Of Date) = DateHelper.GetWorkingDates(DateHelper.GetTheMonday(twoWeeks), DateHelper.GetTheFriday(twoWeeks))
            Dim amntJobsNeeded As Integer = dates.Count * jobsPerDay

            If jobsDt?.Rows.Count > 0 Then
                For Each row As DataRow In jobsDt?.Rows
                    If row.Item("NextVisitDate") Is Nothing Or IsDBNull(row.Item("NextVisitDate")) Then
                        row.Item("NextVisitDate") = dates.FirstOrDefault()
                    End If
                Next
            End If

            JobsDataView = New DataView(jobsDt)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        Combo.SetSelectedComboItem_By_Value(Me.cboLetterNumber, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboJobType, 0)
        Me.txtJobsPerDay.Text = 6
        Me.dtpLetterCreateDate.Value = Now()
    End Sub

    Private Function GetAppointments(Optional ByVal doJobs As Boolean = False) As Boolean

        Me.Cursor = Cursors.WaitCursor

        Dim startProcess As DateTime = Now
        Dim selectedJobView As New DataView

        If JobsDataView IsNot Nothing AndAlso JobsDataView.Count > 0 Then
            selectedJobView.Table = SelectedJobDataRow.Table

            If Not selectedJobView.Table.Columns.Contains("EngName") Then selectedJobView.Table.Columns.Add("EngName")
            If Not selectedJobView.Table.Columns.Contains("EngineerID") Then selectedJobView.Table.Columns.Add("EngineerID")
            If Not selectedJobView.Table.Columns.Contains("AMPM") Then selectedJobView.Table.Columns.Add("AMPM")
            If Not selectedJobView.Table.Columns.Contains("ETA") Then selectedJobView.Table.Columns.Add("ETA") 'boolean for when visit has been applied

            If doJobs Then
                selectedJobView.RowFilter = "Tick = 1"
            End If

            If selectedJobView.Count = 0 Then
                ShowMessage("No Services to Process!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
            End If

            selectedJobView.Sort = "Postcode"
            Dim twoWeeks As Date = dtpLetterCreateDate.Value.AddDays(14)
            Dim startDate As Date = DateHelper.CheckBankHolidaySatOrSunForward(DateHelper.GetDateZeroTime(DateHelper.GetTheMonday(twoWeeks)))
            Dim endDate As Date = DateHelper.CheckBankHolidaySatOrSun(DateHelper.GetDateZeroTime(DateHelper.GetTheFriday(twoWeeks))).AddDays(1)

            Dim jobImportTypeId As Integer = CInt(Combo.GetSelectedItemValue(cboJobType))
            Dim jobImportType As Entity.JobImport.JobImportType = DB.JobImports.JobImportType_Get(jobImportTypeId)
            Dim jobsPerDay As Integer = Helper.MakeIntegerValid(Me.txtJobsPerDay.Text)
            Dim dvAppointments As DataView = DB.JobImports.JobImport_Get_EngineerJobs(startDate, endDate, jobImportTypeId)
            Dim visitTime As Integer = 60
            Dim dvSOR As DataView = DB.SystemScheduleOfRate.SystemScheduleOfRate_Get_ByEngineerQual(jobImportType.EngineerQualID)
            visitTime = dvSOR.Table.Rows(0)("TimeInMins")

            Dim dvEngineerPostcodes As DataView = DB.EngineerPostalRegion.GetALLTicked()

            Try ' Added a try to stop it breaking the app when an error occours
                Dim c As Integer = -1
                Do
                    c = c + 1
                    Dim job As DataRowView = selectedJobView(c)

                    If IsDBNull(job("Letter1")) Then 'letter 1
                        dvAppointments.RowFilter = "TheDate <= #" & DateHelper.GetTheFriday(CDate(job("NextVisitDate"))).ToString("yyyy-MM-dd") &
                                "# AND TheDate >= #" & DateHelper.GetTheMonday(CDate(job("NextVisitDate"))).ToString("yyyy-MM-dd") & "#"
                    ElseIf IsDBNull(job("Letter2")) Then 'letter2
                        dvAppointments.RowFilter = "TheDate <= #" & DateHelper.GetTheFriday(CDate(job("NextVisitDate"))).ToString("yyyy-MM-dd") &
                                "# AND TheDate >= #" & CDate(job("NextVisitDate")).ToString("yyyy-MM-dd") & "#"
                    Else 'we should generate a report for it
                    End If

                    For Each appointment As DataRowView In dvAppointments

                        Dim countOfAssignedJobs As Integer = (From row In selectedJobView.Table.AsEnumerable() Where row("NextVisitDate") = CDate(appointment("TheDate")).ToString("dd/MM/yyyy") And Helper.MakeBooleanValid(row("ETA")) = True And Helper.MakeIntegerValid(row("EngineerID")) = Helper.MakeIntegerValid(appointment("EngineerID")) Select row).ToArray().Count
                        If countOfAssignedJobs = jobsPerDay Then
                            Continue For
                        End If

                        Dim maxAmPmAmounts As MaxAmPmAmounts = GetMaxAmPmAmount(Helper.MakeIntegerValid(appointment("MaxSOR")), visitTime)

                        If Helper.MakeIntegerValid(appointment("AM")) < maxAmPmAmounts.amAmount And
                            (IsDBNull(job("BookedVisit")) Or Not IsDBNull(job("Letter1"))) And
                            (appointment("RemainingSOR") > 0) And IsDBNull(job("ETA")) And
                            (dvEngineerPostcodes.Table.Select("EngineerID = " & appointment("EngineerID") & " And Name = '" & job("OutwardCode") & "'").Length > 0) Then

                            job("EngName") = appointment("Name")
                            job("EngineerID") = appointment("EngineerID")
                            job("NextVisitDate") = CDate(appointment("TheDate")).ToString("dd/MM/yyyy")
                            job("AMPM") = "AM"
                            appointment("AM") = Helper.MakeIntegerValid(appointment("AM")) + 1
                            job("LetterDate") = dtpLetterCreateDate.Value
                            job("ETA") = True
                            appointment("RemainingSOR") -= visitTime
                            Continue For
                        End If

                        If Helper.MakeIntegerValid(appointment("PM")) < maxAmPmAmounts.pmAmount And
                           (IsDBNull(job("BookedVisit")) Or Not IsDBNull(job("Letter1"))) And
                            (appointment("RemainingSOR") > 0) And IsDBNull(job("ETA")) And
                            (dvEngineerPostcodes.Table.Select("EngineerID = " & appointment("EngineerID") & " And Name = '" & job("OutwardCode") & "'").Length > 0) Then

                            job("EngName") = appointment("Name")
                            job("EngineerID") = appointment("EngineerID")
                            job("NextVisitDate") = CDate(appointment("TheDate")).ToString("dd/MM/yyyy")
                            job("AMPM") = "PM"
                            appointment("PM") = Helper.MakeIntegerValid(appointment("PM")) + 1
                            job("LetterDate") = dtpLetterCreateDate.Value
                            job("ETA") = True
                            appointment("RemainingSOR") -= visitTime
                        End If 'end of main if
                    Next

                Loop Until c >= selectedJobView.Count - 1

                If chkScheduleJobs.Checked Then JobsDataView.RowFilter = "AMPM Is Not Null"
                JobsDataView.Sort = "NextVisitDate ASC, AMPM ASC"
            Catch ex As Exception 'show the user
                ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Try
                If doJobs = True Then

                    selectedJobView.RowFilter = "Tick = 1"

                    Dim details As New ArrayList
                    details.Add(selectedJobView)
                    details.Add(chkScheduleJobs.Checked)

                    Dim letterName As String = Combo.GetSelectedItemDescription(cboJobType)

                    Dim oPrint As New Printing(details, letterName, Enums.SystemDocumentType.JobImportLetters, True)
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

    Public Function GetMaxAmPmAmount(ByVal maxSor As Integer, ByVal visitMins As Integer) As MaxAmPmAmounts
        Dim maxValues As New MaxAmPmAmounts
        Dim amountOfJobs As Integer = maxSor / visitMins
        Dim maxAm As Integer = Math.Round(amountOfJobs / 2, 0, MidpointRounding.AwayFromZero)
        Dim maxPm As Integer = Math.Floor(amountOfJobs / 2)

        With maxValues
            .amAmount = maxAm
            .pmAmount = maxPm
        End With
        Return maxValues
    End Function

#End Region

End Class