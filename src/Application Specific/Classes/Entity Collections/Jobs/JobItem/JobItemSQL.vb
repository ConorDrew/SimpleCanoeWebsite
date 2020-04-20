Imports System.Data.SqlClient

Namespace Entity

    Namespace JobItems

        Public Class JobItemSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal JobItemIDs As String, ByVal JobOfWorkID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@JobItemIDs", JobItemIDs, True)
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, True)

                _database.ExecuteSP_NO_Return("JobItem_Delete")
            End Sub

            Public Sub DeleteAll_ForJOW(ByVal JobOfWorkID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, True)
                _database.ExecuteSP_NO_Return("JobItem_DeleteALL_ForJOW")
            End Sub

            Public Sub Delete(ByVal JobItemIDs As String, ByVal JobOfWorkID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "JobItem_Delete"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobOfWorkID", JobOfWorkID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobItemIDs", JobItemIDs))
                Command.ExecuteNonQuery()

            End Sub

            Public Function [Insert](ByVal oJobItem As JobItem, ByVal trans As SqlClient.SqlTransaction) As JobItem

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Dim IDs As String = ""
                'AMY CHANGED THIS BECAUSE I NEED TO RETAIN THE LINK!
                If oJobItem.JobItemID > 0 Then
                    'UPDATE
                    Command.CommandText = "JobItem_Update"
                    Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobItemID", oJobItem.JobItemID))
                Else
                    'INSERT
                    Command.CommandText = "JobItem_Insert"
                End If

                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobOfWorkID", oJobItem.JobOfWorkID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Summary", oJobItem.Summary))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RateID", oJobItem.RateID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Qty", oJobItem.Qty))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SystemLinkID", oJobItem.SystemLinkID))

                If oJobItem.JobItemID > 0 Then
                    Command.ExecuteNonQuery()
                Else
                    oJobItem.SetJobItemID = Command.ExecuteScalar
                End If

                Return oJobItem
            End Function

            Public Function [Insert](ByVal oJobItem As JobItem) As JobItem
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", oJobItem.JobOfWorkID, True)
                _database.AddParameter("@Summary", oJobItem.Summary, True)
                _database.AddParameter("@RateID", oJobItem.RateID, True)
                _database.AddParameter("@Qty", oJobItem.Qty, True)
                _database.AddParameter("@SystemLinkID", oJobItem.SystemLinkID, True)

                Dim IDs As String = ""
                'AMY CHANGED THIS BECAUSE I NEED TO RETAIN THE LINK!
                If oJobItem.JobItemID > 0 Then
                    'UPDATE
                    _database.AddParameter("@JobItemID", oJobItem.JobItemID, True)
                    _database.ExecuteSP_NO_Return("JobItem_Update")
                Else
                    'INSERT
                    oJobItem.SetJobItemID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobItem_Insert"))
                End If

                Return oJobItem
            End Function

            Public Function JobItems_Get_For_Job_Of_Work(ByVal JobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobItems_Get_For_Job_Of_Work")
                dt.TableName = Entity.Sys.Enums.TableNames.tblJobItem.ToString
                Return New DataView(dt)
            End Function

            Public Function JobItems_Get_For_Job_Of_Work(ByVal JobOfWorkID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "JobItems_Get_For_Job_Of_Work"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@JobOfWorkID", JobOfWorkID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Entity.Sys.Enums.TableNames.tblJobItem.ToString
                Return New DataView(dt)
            End Function

            Public Function JobOfWork_Get_For_Job_Of_Work_As_Objects(ByVal JobOfWorkID As Integer) As ArrayList
                Dim jobItems As New ArrayList
                For Each row As DataRow In JobItems_Get_For_Job_Of_Work(JobOfWorkID).Table.Rows
                    Dim jobItem As New JobItems.JobItem
                    jobItem.IgnoreExceptionsOnSetMethods = True
                    jobItem.SetJobItemID = row.Item("JobItemID")
                    jobItem.SetJobOfWorkID = row.Item("JobOfWorkID")
                    jobItem.SetSummary = row.Item("Summary")
                    jobItem.SetRateID = row.Item("RateID")
                    jobItem.SetQty = row.Item("Qty")
                    If row.Table.Columns.Contains("SystemLinkID") Then jobItem.SetSystemLinkID = row.Item("SystemLinkID")
                    jobItems.Add(jobItem)
                Next

                Return jobItems
            End Function

            Public Function JobOfWork_Get_For_Job_Of_Work_As_Objects(ByVal JobOfWorkID As Integer, ByVal trans As SqlClient.SqlTransaction) As ArrayList
                Dim jobItems As New ArrayList
                For Each row As DataRow In JobItems_Get_For_Job_Of_Work(JobOfWorkID, trans).Table.Rows
                    Dim jobItem As New JobItems.JobItem
                    jobItem.IgnoreExceptionsOnSetMethods = True
                    jobItem.SetJobItemID = row.Item("JobItemID")
                    jobItem.SetJobOfWorkID = row.Item("JobOfWorkID")
                    jobItem.SetSummary = row.Item("Summary")
                    jobItem.SetRateID = row.Item("RateID")
                    jobItem.SetQty = row.Item("Qty")
                    If row.Table.Columns.Contains("SystemLinkID") Then jobItem.SetSystemLinkID = row.Item("SystemLinkID")
                    jobItems.Add(jobItem)
                Next

                Return jobItems
            End Function

            Public Function JobItems_Get_For_Job(ByVal JobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobItems_Get_For_Job")
                dt.TableName = Entity.Sys.Enums.TableNames.tblJobItem.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace