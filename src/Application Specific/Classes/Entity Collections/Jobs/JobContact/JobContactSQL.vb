Imports System.Data.SqlClient

Namespace Entity

    Namespace JobContacts

        Public Class JobContactSQL


            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Insert](ByVal oJobContact As JobContact) As JobContact
                _database.ClearParameter()
                _database.AddParameter("@JobID", oJobContact.JobID, True)
                _database.AddParameter("@ContactType", oJobContact.contactType, True)

                oJobContact.SetjobContactID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobContact_Insert"))
                Return oJobContact
            End Function

            Public Sub Update_Access(ByVal JobID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)
                _database.ExecuteSP_OBJECT("JobContact_Update_Access")

            End Sub

            Public Function Get_For_Job(ByVal JobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobContact_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblJobAudit.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace