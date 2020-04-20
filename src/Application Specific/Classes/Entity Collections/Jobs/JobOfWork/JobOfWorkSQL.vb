Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports FSM.Entity.Sys

Namespace Entity

    Namespace JobOfWorks

        Public Class JobOfWorkSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal JobOfWorkID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, True)

                _database.ExecuteSP_NO_Return("JobOfWork_Delete")
            End Sub

            Public Sub Delete(ByVal JobOfWorkID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "JobOfWork_Delete"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobOfWorkID", JobOfWorkID))

                Command.ExecuteNonQuery()

            End Sub

            Public Function [Insert](ByVal oJobOfWork As JobOfWork, ByVal trans As SqlClient.SqlTransaction) As JobOfWork

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "JobOfWork_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobID", oJobOfWork.JobID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Deleted", oJobOfWork.Deleted))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PONumber", oJobOfWork.PONumber))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Status", oJobOfWork.Status))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Priority", oJobOfWork.Priority))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@QualificationID", oJobOfWork.QualificationID))
                If oJobOfWork.PriorityDateSet = Date.MinValue Then
                    Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PriorityDateSet", DBNull.Value))
                Else
                    Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PriorityDateSet", oJobOfWork.PriorityDateSet))
                End If

                oJobOfWork.SetJobOfWorkID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oJobOfWork.Exists = True

                For Each jobItem As Entity.JobItems.JobItem In oJobOfWork.JobItems
                    jobItem.SetJobOfWorkID = oJobOfWork.JobOfWorkID
                    jobItem = _database.JobItems.Insert(jobItem, trans)
                Next

                For Each engineerVisit As Entity.EngineerVisits.EngineerVisit In oJobOfWork.EngineerVisits
                    engineerVisit.SetJobOfWorkID = oJobOfWork.JobOfWorkID
                    engineerVisit = _database.EngineerVisits.Insert(engineerVisit, oJobOfWork.JobID, trans)
                Next

                Return oJobOfWork
            End Function

            Public Function [Insert](ByVal oJobOfWork As JobOfWork) As JobOfWork

                _database.ClearParameter()
                _database.AddParameter("@JobID", oJobOfWork.JobID, True)
                _database.AddParameter("@Deleted", oJobOfWork.Deleted, True)
                _database.AddParameter("@PONumber ", oJobOfWork.PONumber, True)
                _database.AddParameter("@Status", oJobOfWork.Status, True)
                _database.AddParameter("@Priority ", oJobOfWork.Priority, True)
                _database.AddParameter("@QualificationID ", oJobOfWork.QualificationID, True)

                If oJobOfWork.PriorityDateSet = Date.MinValue Or oJobOfWork.PriorityDateSet = Nothing Then
                    _database.AddParameter("@PriorityDateSet ", DBNull.Value, True)
                Else
                    _database.AddParameter("@PriorityDateSet ", oJobOfWork.PriorityDateSet, True)
                End If

                oJobOfWork.SetJobOfWorkID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobOfWork_Insert"))
                oJobOfWork.Exists = True

                For Each jobItem As Entity.JobItems.JobItem In oJobOfWork.JobItems
                    jobItem.SetJobOfWorkID = oJobOfWork.JobOfWorkID
                    jobItem = _database.JobItems.Insert(jobItem)
                Next

                For Each engineerVisit As Entity.EngineerVisits.EngineerVisit In oJobOfWork.EngineerVisits
                    engineerVisit.SetJobOfWorkID = oJobOfWork.JobOfWorkID
                    engineerVisit = _database.EngineerVisits.Insert(engineerVisit, oJobOfWork.JobID)
                Next

                Return oJobOfWork
            End Function

            Public Sub Update_PONumber(ByVal oJobOfWork As JobOfWork)
                If oJobOfWork.PriorityDateSet = Date.MinValue Then
                    oJobOfWork.PriorityDateSet = DateTime.Now
                End If
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", oJobOfWork.JobOfWorkID, True)
                _database.AddParameter("@PONumber ", oJobOfWork.PONumber, True)
                _database.AddParameter("@Priority", oJobOfWork.Priority, True)
                _database.AddParameter("@PriorityDateSet", oJobOfWork.PriorityDateSet, True)
                _database.AddParameter("@QualificationID", oJobOfWork.QualificationID, True)

                _database.ExecuteSP_NO_Return("JobOfWork_Update_PONumber")
            End Sub

            Public Sub Update_PONumber(ByVal oJobOfWork As JobOfWork, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "JobOfWork_Update_PONumber"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobOfWorkID", oJobOfWork.JobOfWorkID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PONumber", oJobOfWork.PONumber))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@QualificationID", oJobOfWork.QualificationID))

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Priority", oJobOfWork.Priority))
                If oJobOfWork.PriorityDateSet = Date.MinValue Then
                    Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PriorityDateSet", DBNull.Value))
                Else
                    Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PriorityDateSet", oJobOfWork.PriorityDateSet))
                End If

                Command.ExecuteNonQuery()

            End Sub

            Public Sub Update_Status(ByVal JobOfWorkID As Integer, ByVal Status As Integer)

                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, True)
                _database.AddParameter("@Status ", Status, True)

                _database.ExecuteSP_NO_Return("JobOfWork_Update_Status")

            End Sub

            Public Sub Update_Priority(ByVal Jow As Entity.JobOfWorks.JobOfWork)
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", Jow.JobOfWorkID, True)
                _database.AddParameter("@Priority ", Jow.Priority, True)
                _database.AddParameter("@PriorityDateSet ", Jow.PriorityDateSet, True)
                _database.AddParameter("@QualificationID ", Jow.QualificationID, True)

                _database.ExecuteSP_NO_Return("JobOfWork_Update_Priority")

            End Sub

            Public Function JobOfWork_Get_For_Job(ByVal JobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobOfWork_Get_For_Job")
                dt.TableName = Entity.Sys.Enums.TableNames.tblJobOfWork.ToString
                Return New DataView(dt)
            End Function

            Public Function JobOfWork_Get_For_Job(ByVal JobID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "JobOfWork_Get_For_Job"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@JobID", JobID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Entity.Sys.Enums.TableNames.tblJobOfWork.ToString
                Return New DataView(dt)

            End Function

            Public Function JobOfWork_Get_ForEngineerVisitID(ByVal engineerVisitId As Integer) As DataTable
                Dim dt As New DataTable
                Dim command As New SqlCommand("JobOfWork_Get_ForEngineerVisitID", New SqlConnection(_database.ServerConnectionString))
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@EngineerVisitID", engineerVisitId)

                    dt = _database.ExecuteCommand_DataTable(command)
                    dt.TableName = "tblJobOfWork"

                    Return dt
                Catch ex As Exception
                    Return dt
                Finally
                    command.Connection.Close()
                End Try
            End Function

            Public Function JobOfWork_Get(ByVal JobOfWorkID As Integer) As JobOfWorks.JobOfWork

                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobOfWork_Get")
                Dim jobOfWork As JobOfWorks.JobOfWork = Nothing

                If dt.Rows.Count > 0 Then

                    jobOfWork = New JobOfWork

                    With dt.Rows(0)
                        jobOfWork.IgnoreExceptionsOnSetMethods = True
                        jobOfWork.Exists = True
                        jobOfWork.SetJobOfWorkID = .Item("JobOFWorkID")
                        jobOfWork.SetJobID = .Item("JobID")
                        jobOfWork.SetPONumber = .Item("PONumber")
                        jobOfWork.SetDeleted = .Item("Deleted")
                        jobOfWork.SetStatus = Sys.Helper.MakeIntegerValid(.Item("Status"))
                        jobOfWork.SetPriority = Sys.Helper.MakeIntegerValid(.Item("Priority"))
                        jobOfWork.PriorityDateSet = Sys.Helper.MakeDateTimeValid(.Item("PriorityDateSet"))
                        If dt.Rows(0).Table.Columns.Contains("QualificationID") Then jobOfWork.SetQualificationID = Sys.Helper.MakeIntegerValid(.Item("QualificationID"))
                    End With

                End If

                Return jobOfWork

            End Function

            Public Function JobOfWork_Get_As_Object(ByVal jobOfWorkID As Integer) As JobOfWork
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", jobOfWorkID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobOfWork_Get")
                Dim jobOfWork As JobOfWork = Nothing

                If dt.Rows.Count > 0 Then

                    jobOfWork = New JobOfWork

                    With dt.Rows(0)
                        jobOfWork.IgnoreExceptionsOnSetMethods = True
                        jobOfWork.Exists = True
                        jobOfWork.SetJobOfWorkID = .Item("JobOFWorkID")
                        jobOfWork.SetJobID = .Item("JobID")
                        jobOfWork.SetPONumber = .Item("PONumber")
                        jobOfWork.SetDeleted = .Item("Deleted")
                        jobOfWork.SetStatus = Sys.Helper.MakeIntegerValid(.Item("Status"))
                        jobOfWork.SetPriority = Sys.Helper.MakeIntegerValid(.Item("Priority"))
                        jobOfWork.PriorityDateSet = Sys.Helper.MakeDateTimeValid(.Item("PriorityDateSet"))
                        If dt.Rows(0).Table.Columns.Contains("QualificationID") Then jobOfWork.SetQualificationID = Sys.Helper.MakeIntegerValid(.Item("QualificationID"))
                        jobOfWork.JobItems = _database.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID)
                        jobOfWork.EngineerVisits = _database.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work_As_Objects_Light(jobOfWork.JobOfWorkID)
                    End With

                End If
                Return jobOfWork
            End Function

            Public Function JobOfWork_Get_For_Job_As_Objects(ByVal JobID As Integer, ByVal trans As SqlClient.SqlTransaction) As ArrayList

                Dim jobOfWorks As New ArrayList
                For Each row As DataRow In JobOfWork_Get_For_Job(JobID, trans).Table.Rows
                    Dim jobOfWork As New JobOfWorks.JobOfWork
                    jobOfWork.IgnoreExceptionsOnSetMethods = True
                    jobOfWork.Exists = True
                    jobOfWork.SetJobOfWorkID = row.Item("JobOFWorkID")
                    jobOfWork.SetJobID = row.Item("JobID")
                    jobOfWork.SetPONumber = row.Item("PONumber")
                    jobOfWork.SetDeleted = row.Item("Deleted")
                    jobOfWork.SetStatus = Sys.Helper.MakeIntegerValid(row.Item("Status"))
                    jobOfWork.SetPriority = Sys.Helper.MakeIntegerValid(row.Item("Priority"))
                    jobOfWork.PriorityDateSet = Sys.Helper.MakeDateTimeValid(row.Item("PriorityDateSet"))
                    If row.Table.Columns.Contains("QualificationID") Then jobOfWork.SetQualificationID = Sys.Helper.MakeIntegerValid(row.Item("QualificationID"))
                    jobOfWork.JobItems = _database.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID, trans)
                    jobOfWork.EngineerVisits = _database.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID, trans)
                    jobOfWorks.Add(jobOfWork)
                Next

                Return jobOfWorks
            End Function

            Public Function JobOfWork_Get_For_Job_As_Objects(ByVal JobID As Integer) As ArrayList
                Dim jobOfWorks As New ArrayList
                For Each row As DataRow In JobOfWork_Get_For_Job(JobID).Table.Rows
                    Dim jobOfWork As New JobOfWorks.JobOfWork
                    jobOfWork.IgnoreExceptionsOnSetMethods = True
                    jobOfWork.Exists = True
                    jobOfWork.SetJobOfWorkID = row.Item("JobOFWorkID")
                    jobOfWork.SetJobID = row.Item("JobID")
                    jobOfWork.SetPONumber = row.Item("PONumber")
                    jobOfWork.SetDeleted = row.Item("Deleted")
                    jobOfWork.SetStatus = Sys.Helper.MakeIntegerValid(row.Item("Status"))
                    jobOfWork.SetPriority = Sys.Helper.MakeIntegerValid(row.Item("Priority"))
                    jobOfWork.PriorityDateSet = Sys.Helper.MakeDateTimeValid(row.Item("PriorityDateSet"))
                    If row.Table.Columns.Contains("QualificationID") Then jobOfWork.SetQualificationID = Sys.Helper.MakeIntegerValid(row.Item("QualificationID"))
                    jobOfWork.JobItems = _database.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID)
                    jobOfWork.EngineerVisits = _database.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work_As_Objects_Light(jobOfWork.JobOfWorkID)

                    jobOfWorks.Add(jobOfWork)
                Next

                Return jobOfWorks
            End Function

            Public Sub Update_PONumberByJobOfWorkID(ByVal jobOfWorkId As Integer, ByVal poNumber As String)
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID ", jobOfWorkId, True)
                _database.AddParameter("@PONumber ", poNumber, True)
                _database.ExecuteSP_NO_Return("JobOfWork_Update_PONumberByJobOfWorkID")
            End Sub

            Public Function [Get_ByJobId](ByVal jobId As Integer) As List(Of JobOfWork)
                _database.ClearParameter()
                _database.AddParameter("@JobID", jobId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobOfWork_Get_For_Job")
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                    Dim jobOfWorks As List(Of JobOfWork) =
                        (From x In dt.AsEnumerable() Select New JobOfWork With {
                            .Exists = True,
                            .SetJobOfWorkID = Helper.MakeIntegerValid(x("JobOfWorkId")),
                            .SetJobID = Helper.MakeIntegerValid(x("JobId")),
                            .SetPONumber = Helper.MakeStringValid(x("PONumber")),
                            .SetPriority = Helper.MakeIntegerValid(x("Priority")),
                            .SetStatus = Helper.MakeIntegerValid(x("Status")),
                            .PriorityDateSet = Helper.MakeDateTimeValid(x("PriorityDateSet")),
                            .SetQualificationID = Helper.MakeIntegerValid(x("QualificationID"))
                        }).ToList()
                    Return jobOfWorks
                Else : Return Nothing
                End If
            End Function

#End Region

        End Class

    End Namespace

End Namespace