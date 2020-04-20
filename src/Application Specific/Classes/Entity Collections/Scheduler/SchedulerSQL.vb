Imports System.Data.SqlClient
Imports FSM.Entity.EngineerVisits
Imports FSM.Entity.Sys

Namespace Entity.Scheduler

    Public Class SchedulerSQL

        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

#Region "Functions"

        Public Function getJobsForVisitSummary(ByVal StartDateIN As Date, ByVal EndDateIN As Date) As DataTable
            Dim pStartDate As New SqlClient.SqlParameter("@StartDate", Format(StartDateIN, "dd-MMM-yyyy 00:00:00"))
            Dim pEndDate As New SqlClient.SqlParameter("@EndDate", Format(EndDateIN, "dd-MMM-yyyy 23:59:59"))

            Return _database.ExecuteSP_DataTable("Scheduler_Get_Jobs_For_VisitSummary", pStartDate, pEndDate)
        End Function

        Public Function Scheduler_GetWorkLoadForDaysAndEngineers(ByVal Engineers As String, ByVal Days As String) As DataTable
            Dim pDays As New SqlClient.SqlParameter("@DataRange", Days)
            Dim pEngineerID As New SqlClient.SqlParameter("@Engineers", Engineers)
            Dim dtSummary As DataTable
            dtSummary = _database.ExecuteSP_DataTable("Scheduler_GetWorkLoadForDaysAndEngineers", pDays, pEngineerID)
            dtSummary.TableName = "ScheduleSummary"
            Return dtSummary
        End Function

        Public Function getSummary(ByVal EngineerID As String, ByVal Days As String) As DataTable
            'Dim pDays As New SqlClient.SqlParameter("@DataRange", Days)
            'Dim pEngineerID As New SqlClient.SqlParameter("@EngineerID", EngineerID)

            Dim command As New SqlCommand("Scheduler_GetEngineerWorkLoadForDays", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure
            command.CommandTimeout = 100000

            command.Parameters.AddWithValue("@DataRange", Days)
            command.Parameters.AddWithValue("@EngineerID", EngineerID)

            Return _database.ExecuteCommand_DataTable(command)
            'Return _database.ExecuteSP_DataTable("Scheduler_GetEngineerWorkLoadForDays", pDays, pEngineerID)
        End Function

        Public Function getSummaryNEW(ByVal EngineerID As String, ByVal Start As Date, ByVal Endin As Date) As DataTable
            'Dim pDays As New SqlClient.SqlParameter("@DataRange", Days)
            'Dim pEngineerID As New SqlClient.SqlParameter("@EngineerID", EngineerID)

            Dim command As New SqlCommand("Scheduler_GetEngineerWorkLoadForDays_TEST", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure
            command.CommandTimeout = 100000

            command.Parameters.AddWithValue("@Start", Format(Start, "yyyy/MM/dd"))
            command.Parameters.AddWithValue("@End", Format(Endin, "yyyy/MM/dd"))
            command.Parameters.AddWithValue("@EngineerID", EngineerID)

            Return _database.ExecuteCommand_DataTable(command)
            'Return _database.ExecuteSP_DataTable("Scheduler_GetEngineerWorkLoadForDays", pDays, pEngineerID)
        End Function

        Public Function VisitOverlaps(ByVal EngineerID As String, ByVal StartDateTime As DateTime, ByVal EndDateTime As DateTime) As Boolean
            Dim dt As New DataTable
            Dim pEngineerID As New SqlClient.SqlParameter("@EngineerID", EngineerID)
            Dim pStartDate As New SqlClient.SqlParameter("@StartDateTime", StartDateTime)
            Dim pEndDate As New SqlClient.SqlParameter("@EndDateTime", EndDateTime)
            dt = _database.ExecuteSP_DataTable("Scheduler_VisitOverlapCheck", pEngineerID, pStartDate, pEndDate)
            dt.TableName = "dtVisitOverlap"

            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function AbsenceOverlap(ByVal EngineerID As String, ByVal Day As DateTime) As Boolean
            Dim dt As New DataTable
            'Dim pEngineerID As New SqlClient.SqlParameter("@EngineerID", EngineerID)
            'Dim pDay As New SqlClient.SqlParameter("@Day", Day)

            Dim command As New SqlCommand("Scheduler_AbsenceOverlapCheck", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@EngineerID", EngineerID)
            command.Parameters.AddWithValue("@Day", Day)

            dt = _database.ExecuteCommand_DataTable(command)
            dt.TableName = "dtAbsenceOverlap"

            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function GetUnscheduledVisits(ByVal viewAll As Boolean) As DataTable
            Dim dt As New DataTable
            Dim command As New SqlCommand("UnscheduledVisits_Get_Mk3", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@UserID", loggedInUser.UserID)
            command.Parameters.AddWithValue("@ViewAll", viewAll)

            dt = _database.ExecuteCommand_DataTable(command)
            dt.TableName = "dtUnscheduledVisits"
            Return dt
        End Function

        Public Function Scheduler_EngineerFreeMins(ByVal day As Date, ByVal engineerid As String) As Integer

            Dim command As New SqlCommand("Scheduler_EngineerFreeMins", New SqlConnection(_database.ServerConnectionString))
            Try
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@VisitDate", Format(day, "yyyy/MMM/dd").ToString)
                command.Parameters.AddWithValue("@EngineerID", engineerid)
                command.Connection.Open()

                Return CInt(command.ExecuteScalar)
            Finally
                command.Connection.Close()
            End Try

        End Function

        Public Function Scheduler_DayTimeSlots(ByVal day As Date, ByVal engineerid As String) As DataTable
            Dim pVisitDate As New SqlClient.SqlParameter("@VisitDate", Format(day, "yyyy/MMM/dd").ToString)
            Dim pEngineerID As New SqlClient.SqlParameter("@EngineerID", engineerid)

            Dim dt As DataTable

            dt = _database.ExecuteSP_DataTable("Scheduler_DayTimeSlots_TEST", pVisitDate, pEngineerID)

            Return dt
        End Function

        Public Function Scheduler_PlannerPopUp(ByVal day As DateTime, ByVal engineerid As String) As DataTable
            Dim pVisitDate As New SqlClient.SqlParameter("@VisitDate", Format(day, "yyyy/MMM/dd HH:mm:ss").ToString)
            Dim pEngineerID As New SqlClient.SqlParameter("@EngineerID", engineerid)

            Dim dt As DataTable

            dt = _database.ExecuteSP_DataTable("Scheduler_PlannerPopUp", pVisitDate, pEngineerID)

            Return dt
        End Function

        Public Function SORTime_GetForEngineerAndDay(ByVal EngineerID As Integer, ByVal DateToCheck As DateTime) As DataTable
            Dim pVisitDate As New SqlClient.SqlParameter("@dateToCheck", DateToCheck) 'Format(DateToCheck, "yyyy/MMM/dd").ToString
            Dim pEngineerID As New SqlClient.SqlParameter("@EngineerID", EngineerID)

            Dim dt As DataTable

            dt = _database.ExecuteSP_DataTable("SORTime_GetForEngineerAndDay", pVisitDate, pEngineerID)

            Return dt

        End Function

        Public Function Get_ScheduledJobsDay(ByVal day As Date, ByVal engineerid As String) As DataTable
            Dim pVisitDate As New SqlClient.SqlParameter("@VisitDate", Format(day, "yyyy/MMM/dd").ToString)
            Dim pEngineerID As New SqlClient.SqlParameter("@EngineerID", engineerid)
            Dim pVisitStatusID As New SqlClient.SqlParameter("@VisitStatusID", CInt(Entity.Sys.Enums.VisitStatus.Scheduled))
            Dim userID As New SqlClient.SqlParameter("@UserID", loggedInUser.UserID)

            Dim dt As DataTable
            dt = _database.ExecuteSP_DataTable("ScheduledJobsDay_Get_Mk2", pVisitDate, pEngineerID, pVisitStatusID, userID)
            Return dt
        End Function

        Public Function IsSiteOverdue(ByVal siteId As Integer) As Boolean
            Dim paramSiteId As New SqlParameter("@SiteID", siteId)

            Dim dt As DataTable
            dt = _database.ExecuteSP_DataTable("Scheduler_IsSiteOverdue", paramSiteId)
            Dim _isSiteOverdue As Boolean = False
            If Helper.MakeIntegerValid(dt?.Rows.Count) > 0 Then
                _isSiteOverdue = Helper.MakeBooleanValid(dt.Rows(0)("IsSiteOverdue"))
            End If
            Return _isSiteOverdue
        End Function

        Public Function IsVisitLate(ByVal engineerVisitId As Integer) As Boolean
            Dim paramEngineerVisitId As New SqlParameter("@EngineerVisitId", engineerVisitId)

            Dim dt As DataTable
            dt = _database.ExecuteSP_DataTable("Scheduler_IsVisitLate", paramEngineerVisitId)

            Dim _isVisitLate As Boolean = False
            If Helper.MakeIntegerValid(dt?.Rows.Count) > 0 Then
                _isVisitLate = Helper.MakeBooleanValid(dt.Rows(0)("IsVisitLate"))
            End If
            Return _isVisitLate
        End Function

        Public Sub ScheduleVisit(ByRef VisitRow As DataRow, Optional ByVal OldVisitID As Integer = 0, Optional ByVal AppointmentID As Integer = 0)

            If VisitRow("EngineerVisitID") <> 0 Then
                'GET OLD VISIT
                Dim originaldetail As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(VisitRow("EngineerVisitID"))

                _database.ClearParameter()
                _database.AddParameter("@StartDateTime", Format(VisitRow("StartDateTime"), "dd-MMM-yyyy HH:mm:ss"), True)
                _database.AddParameter("@EndDateTime", Format(VisitRow("EndDateTime"), "dd-MMM-yyyy HH:mm:ss"), True)
                _database.AddParameter("@EngineerID", VisitRow("EngineerID"), True)

                _database.AddParameter("@VisitID", VisitRow("EngineerVisitID"), True)
                _database.AddParameter("@AppointmentID", AppointmentID, True)
                If originaldetail.StatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Downloaded) Then

                    If CInt(VisitRow("EngineerID")) = originaldetail.EngineerID Then
                        If CDate(VisitRow("StartDateTime")) > Date.Now.AddHours(24) Then
                            _database.AddParameter("@VisitStatusID", CInt(Entity.Sys.Enums.VisitStatus.Scheduled), True)
                            _database.AddParameter("@TabletActionID", 1, True) 'move only
                            _database.AddParameter("@RemoveEngineerID", originaldetail.EngineerID, True) 'who
                        Else
                            _database.AddParameter("@VisitStatusID", CInt(Entity.Sys.Enums.VisitStatus.Downloaded), True)
                            _database.AddParameter("@TabletActionID", 2, True) 'move only
                        End If
                    Else
                        _database.AddParameter("@VisitStatusID", CInt(Entity.Sys.Enums.VisitStatus.Scheduled), True)
                        _database.AddParameter("@TabletActionID", 1, True) 'Remove from old engineer
                        _database.AddParameter("@RemoveEngineerID", originaldetail.EngineerID, True) 'who
                    End If
                Else
                    _database.AddParameter("@TabletActionID", 2, True) 'move only
                    _database.AddParameter("@VisitStatusID", CInt(Entity.Sys.Enums.VisitStatus.Scheduled), True)
                End If
                Dim jobId As Integer = 0
                If Entity.Sys.Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("scheduleVisit")) = True Then
                    ' Status Changed enter Job Audit
                    Dim jA As New Entity.JobAudits.JobAudit
                    jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(VisitRow("EngineerVisitID")).JobID
                    jobId = jA.JobID
                    jA.SetActionChange = "Visit Status changed to Scheduled, to Engineer: " & DB.Engineer.Engineer_Get(VisitRow("EngineerID")).Name &
                    " For " & Format(VisitRow("StartDateTime"), "dd-MMM-yyyy HH:mm") &
                        " (Unique Visit ID: " & VisitRow("EngineerVisitID") & ")"
                    DB.JobAudit.Insert(jA)
                Else

                    Dim jA As New Entity.JobAudits.JobAudit
                    jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(VisitRow("EngineerVisitID")).JobID
                    jobId = jA.JobID
                    jA.SetActionChange = "Visit moved to Engineer: " & DB.Engineer.Engineer_Get(VisitRow("EngineerID")).Name &
                    " For " & Format(VisitRow("StartDateTime"), "dd-MMM-yyyy HH:mm") &
                        " (Unique Visit ID: " & VisitRow("EngineerVisitID") & ")"
                    DB.JobAudit.Insert(jA)
                End If

                'Check if job is an import job
                If DB.JobImports.JobImport_Get_ByJobNumber(VisitRow("JobNumber")).Count > 0 Then
                    JobImportUpdate(VisitRow("JobNumber"), Helper.MakeIntegerValid(VisitRow("EngineerVisitID")))
                End If
            Else

                Dim engineerVisit As New EngineerVisits.EngineerVisit

                engineerVisit.SetEngineerID = VisitRow("EngineerID")
                engineerVisit.StartDateTime = Format(VisitRow("StartDateTime"), "dd-MMM-yyyy HH:mm:ss")
                engineerVisit.EndDateTime = Format(VisitRow("EndDateTime"), "dd-MMM-yyyy HH:mm:ss")
                engineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                engineerVisit.SetJobOfWorkID = VisitRow("JobOfWorkID")
                engineerVisit.SetNotesToEngineer = VisitRow("NotesToEngineer")
                If OldVisitID > 0 Then
                    With DB.EngineerVisits.EngineerVisits_Get_As_Object(OldVisitID)
                        engineerVisit.SetVisitNumber = .VisitNumber
                    End With
                End If

                engineerVisit = DB.EngineerVisits.Insert(engineerVisit, 0, AppointmentID, OldVisitID)

                If OldVisitID > 0 Then

                    Dim dtParts As DataTable = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(OldVisitID).Table

                    If dtParts.Rows.Count > 0 Then
                        If ShowMessage("This visit has parts and/or products allocated to it.  Would you like to move them to the new visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim movedOrders As DataTable = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_MoveVisit(OldVisitID, engineerVisit.EngineerVisitID)
                            engineerVisit.SetPartsToFit = True
                            DB.EngineerVisits.Update(engineerVisit, 0, True)
                        End If
                    End If
                End If

                VisitRow("EngineerVisitID") = engineerVisit.EngineerVisitID
            End If

        End Sub

        Public Sub ScheduleVisit(ByVal visit As EngineerVisit)
            If visit Is Nothing Then Exit Sub
            Dim orginialVisit As EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(visit.EngineerVisitID)
            _database.ClearParameter()
            _database.AddParameter("@StartDateTime", visit.StartDateTime, True)
            _database.AddParameter("@EndDateTime", visit.EndDateTime, True)
            _database.AddParameter("@EngineerID", visit.EngineerID, True)
            _database.AddParameter("@VisitID", visit.EngineerVisitID, True)
            _database.AddParameter("@AppointmentID", visit.AppointmentID, True)
            If orginialVisit.StatusEnumID = CInt(Enums.VisitStatus.Downloaded) Then
                If visit.EngineerID = orginialVisit.EngineerID Then
                    If visit.StartDateTime > Date.Now.AddHours(24) Then
                        _database.AddParameter("@VisitStatusID", CInt(Enums.VisitStatus.Scheduled), True)
                        _database.AddParameter("@TabletActionID", CInt(Enums.TabletAction.RemoveFromTablet), True) 'move only
                        _database.AddParameter("@RemoveEngineerID", orginialVisit.EngineerID, True) 'who
                    Else
                        _database.AddParameter("@VisitStatusID", CInt(Enums.VisitStatus.Downloaded), True)
                        _database.AddParameter("@TabletActionID", CInt(Enums.TabletAction.UpdateTime), True) 'move only
                    End If
                Else
                    _database.AddParameter("@VisitStatusID", CInt(Enums.VisitStatus.Scheduled), True)
                    _database.AddParameter("@TabletActionID", CInt(Enums.TabletAction.RemoveFromTablet), True) 'Remove from old engineer
                    _database.AddParameter("@RemoveEngineerID", orginialVisit.EngineerID, True) 'who
                End If
            Else
                _database.AddParameter("@TabletActionID", CInt(Enums.TabletAction.UpdateTime), True) 'move only
                _database.AddParameter("@VisitStatusID", CInt(Enums.VisitStatus.Scheduled), True)
            End If

            Dim success As Boolean = Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("scheduleVisit"))
            Dim job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(visit.EngineerVisitID)
            If success Then
                Dim jA As New JobAudits.JobAudit
                jA.SetJobID = job?.JobID
                jA.SetActionChange = "Visit Status changed to Scheduled, to Engineer: " & DB.Engineer.Engineer_Get(visit.EngineerID)?.Name &
                    " For " & Format(visit.StartDateTime, "dd-MMM-yyyy HH:mm") & " (Unique Visit ID: " & visit.EngineerVisitID & ")"
                DB.JobAudit.Insert(jA)
            Else
                Dim jA As New JobAudits.JobAudit
                jA.SetJobID = job?.JobID
                jA.SetActionChange = "Visit moved to Engineer: " & DB.Engineer.Engineer_Get(visit.EngineerID)?.Name &
                    " For " & Format(visit.StartDateTime, "dd-MMM-yyyy HH:mm") & " (Unique Visit ID: " & visit.EngineerVisitID & ")"
                DB.JobAudit.Insert(jA)
            End If

            If DB.JobImports.JobImport_Get_ByJobNumber(job?.JobNumber).Count > 0 Then
                JobImportUpdate(job?.JobNumber, visit.EngineerVisitID)
            End If
        End Sub

        Public Sub unscheduleVisit(ByVal visitRow As DataRow)

            Dim originaldetail As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(visitRow("EngineerVisitID"))
            'If DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(visitRow("JobOfWorkID")).Table.Rows.Count > 0 Then
            _database.ClearParameter()
            _database.AddParameter("@VisitStatusID", CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule), True)
            _database.AddParameter("@VisitID", visitRow("EngineerVisitID"), True)
            If originaldetail.StatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Downloaded) Then
                _database.AddParameter("@TabletActionID", 1, True) 'Remove from old engineer
                _database.AddParameter("@RemoveEngineerID", originaldetail.EngineerID, True) 'who
            End If

            If Entity.Sys.Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("unscheduleVisit")) = True Then
                ' Status Changed enter Job Audit
                Dim jA As New Entity.JobAudits.JobAudit
                jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(visitRow("EngineerVisitID")).JobID
                jA.SetActionChange = "Visit Status changed to Unscheduled" &
                    " (Unique Visit ID: " & visitRow("EngineerVisitID") & ")"
                DB.JobAudit.Insert(jA)

            End If

            'Check if job is an import job
            If DB.JobImports.JobImport_Get_ByJobNumber(visitRow("JobNumber")).Count > 0 Then
                JobImportUpdate(visitRow("JobNumber"), Helper.MakeIntegerValid(visitRow("EngineerVisitID")))
            End If
        End Sub

        Public Sub JobImportUpdate(ByVal jobNumber As String, ByVal engineerVisitId As Integer)
            Dim dt As DataTable = DB.JobImports.JobImport_Get_ByJobNumber(jobNumber)?.Table
            Dim visit As EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId)

            Dim email As New Entity.Sys.Emails
            email.To = Entity.Sys.EmailAddress.Electrical
            email.From = Entity.Sys.EmailAddress.FSM
            email.Subject = "Job Adjusted"
            email.Body = "Dear Electrical Team," & vbCrLf & vbCrLf
            email.Body += "The following job: " & jobNumber &
                " has been adjusted in the scheduler." & vbCrLf & vbCrLf

            If visit.StatusEnumID = Entity.Sys.Enums.VisitStatus.Scheduled Then
                email.Body += "The job has been rescheduled for: " &
                    visit.StartDateTime.ToLongDateString() & "<br/><br/>"
                email.Body += "Please find the new letter generated attached." & "<br/><br/>"
                email.Body += "Kind regards," & "<br/><br/>"
                email.Body += TheSystem.Configuration.CompanyName

                Dim details As New ArrayList
                details.Add(dt)

                Dim print As New Printing(details, dt?.Rows(0)("Type"), Entity.Sys.Enums.SystemDocumentType.JobImportLetters, False, 0, True)
                email.Attachments.Add(print.EmailWP())
            Else
                email.Body += "The job has been moved to the holding area." & vbCrLf & vbCrLf
            End If

            email.SendMe = True
            email.Send()
        End Sub

        Public Function getTimesheetStatus(ByVal EngId As Integer, Optional ByVal VisitId As Integer = 0) As Integer

            Dim i As Integer = 0

            _database.ClearParameter()
            _database.AddParameter("@EngID", EngId, True)
            _database.AddParameter("@VisitID", VisitId, True)

            i = _database.ExecuteSP_OBJECT("Scheduler_Timesheet_Get")

            Return i

        End Function

        Public Function GetLatestHeartBeat(ByVal EngId As Integer) As Entity.HeartBeats.HeartBeat
            Try

                Dim hb As Entity.HeartBeats.HeartBeat = New Entity.HeartBeats.HeartBeat
                If _database Is Nothing Then
                    Return New HeartBeats.HeartBeat
                End If
                _database.ClearParameter()
                _database.AddParameter("@EngID", EngId, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Scheduler_GetLatestHeartbeat")
                If dt.Rows.Count > 0 Then
                    With hb
                        .SetLockedVisitID = dt.Rows(0).Item("LockVisitID")
                        .LastHeartBeat = dt.Rows(0).Item("DateCreated")

                    End With
                End If

                hb.LastCheck = Now

                Return hb
            Catch ex As Exception
                Return New HeartBeats.HeartBeat
            End Try

        End Function

        Public Function Get_EngineerLocation(ByVal engineerId As Integer) As DataView
            Dim dt As New DataTable
            Dim command As New SqlCommand("Scheduler_Get_EngineerLocation", New SqlConnection(_database.ServerConnectionString))
            Try
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@EngineerID", engineerId)

                dt = _database.ExecuteCommand_DataTable(command)

                Return New DataView(dt)
            Catch ex As Exception
                Return New DataView(dt)
            Finally
                command.Connection.Close()
            End Try
        End Function

#End Region

    End Class

End Namespace