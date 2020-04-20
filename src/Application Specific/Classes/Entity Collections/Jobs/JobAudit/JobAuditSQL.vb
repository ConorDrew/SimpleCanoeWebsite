Imports System.Data.SqlClient

Namespace Entity

    Namespace JobAudits

        Public Class JobAuditSQL


                Private _database As Sys.Database

                Public Sub New(ByVal database As Sys.Database)
                    _database = database
                End Sub

#Region "Functions"

            Public Function [Insert](ByVal oJobAudit As JobAudit) As JobAudit
                _database.ClearParameter()
                _database.AddParameter("@JobID", oJobAudit.JobID, True)
                _database.AddParameter("@ActionChange", oJobAudit.ActionChange, True)
                _database.AddParameter("@ActionDateTime", Now, True)
                _database.AddParameter("@UserID", loggedInUser.UserID, True)

                oJobAudit.SetJobAuditID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobAudit_Insert"))
                Return oJobAudit
            End Function

            Public Function [Insert](ByVal oJobAudit As JobAudit, ByVal trans As SqlClient.SqlTransaction) As JobAudit

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "JobAudit_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobID", oJobAudit.JobID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ActionChange", oJobAudit.ActionChange))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ActionDateTime", Now))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserID", loggedInUser.UserID))

                oJobAudit.SetJobAuditID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                Return oJobAudit

            End Function

            Public Function Get_For_Job(ByVal JobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobAudit_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblJobAudit.ToString
                Return New DataView(dt)
            End Function

#End Region

            End Class

        End Namespace

End Namespace