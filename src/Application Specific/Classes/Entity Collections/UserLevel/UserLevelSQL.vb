Imports System.Data.SqlClient

Namespace Entity.UserLevels

    Public Class UserLevelSQL
        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

#Region "Functions"

        Public Sub [Insert](ByVal UserID As Integer, ByVal t As DataTable)

            'delete all first
            _database.ClearParameter()
            _database.AddParameter("@UserID", UserID, True)
            _database.ExecuteSP_NO_Return("UserLevel_Delete")

            If Not t Is Nothing Then
                For Each r As DataRow In t.Rows
                    _database.ClearParameter()
                    _database.AddParameter("@UserID", UserID, True)
                    _database.AddParameter("@LevelID", r("LevelID"), True)
                    _database.AddParameter("@Notes", Entity.Sys.Helper.MakeStringValid(r("Notes")), True)
                    _database.AddParameter("@DatePassed", r("DatePassed"), True)
                    _database.AddParameter("@DateExpires", r("DateExpires"), True)
                    _database.AddParameter("@DateBooked", r("DateBooked"), True)
                    _database.ExecuteSP_NO_Return("UserLevel_Insert")
                Next
            End If
        End Sub

        Public Function [Get](ByVal UserID As Integer) As DataView
            Dim command As New SqlCommand("UserLevels_Get", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@UserID", UserID)

            Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)
            dt.TableName = Entity.Sys.Enums.TableNames.tblUserQualification.ToString
            Return New DataView(dt)
        End Function

        Public Function [GetForSetup](ByVal UserID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@UserID", UserID, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("UserLevels_Setup_Get")
            dt.TableName = Entity.Sys.Enums.TableNames.tblUserQualification.ToString
            Return New DataView(dt)
        End Function

#End Region

    End Class

End Namespace