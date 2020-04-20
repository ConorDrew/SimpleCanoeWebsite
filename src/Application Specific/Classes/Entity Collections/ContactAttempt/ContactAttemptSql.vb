Imports FSM.Entity.Sys
Imports System.Collections.Generic

Namespace Entity.ContactAttempts

    Public Class ContactAttemptSql
        Private _database As Database

        Public Sub New(ByVal database As Database)
            _database = database
        End Sub

        Public Function [Insert](ByVal contactAttempt As ContactAttempt) As ContactAttempt
            _database.ClearParameter()
            _database.AddParameter("@ContactMethedID", contactAttempt.ContactMethedID)
            _database.AddParameter("@LinkID", contactAttempt.LinkID)
            _database.AddParameter("@LinkRef", contactAttempt.LinkRef)
            _database.AddParameter("@ContactMade", contactAttempt.ContactMade, True)
            _database.AddParameter("@Notes", contactAttempt.Notes)
            _database.AddParameter("@ContactMadeByUserId", contactAttempt.ContactMadeByUserId)
            contactAttempt.ContactAttemptID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContactAttempt_Insert"))
            Return contactAttempt
        End Function

        Public Function [GetAll](ByVal linkTable As Enums.TableNames, ByVal linkId As Integer) As List(Of ContactAttempt)
            _database.ClearParameter()
            _database.AddParameter("@LinkID", CInt(linkTable))
            _database.AddParameter("@LinkRef", linkId)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("ContactAttempt_GetAll")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim contactAttempts As List(Of ContactAttempt) = ObjectMap.DataTableToList(Of ContactAttempt)(dt)
                Return contactAttempts
            Else : Return Nothing
            End If
        End Function

        Public Function [GetAll_ForJob](ByVal jobId As Integer) As List(Of ContactAttempt)
            _database.ClearParameter()
            _database.AddParameter("@JobID", jobId)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("ContactAttempt_GetAll_ForJob")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim contactAttempts As List(Of ContactAttempt) = ObjectMap.DataTableToList(Of ContactAttempt)(dt)
                Return contactAttempts
            Else : Return Nothing
            End If
        End Function

        Public Function ContactMethod_GetAll() As DataView
            _database.ClearParameter()
            Dim dt As DataTable = _database.ExecuteSP_DataTable("ContactMethod_GetAll")
            dt.TableName = Enums.TableNames.tblContact.ToString
            Return New DataView(dt)
        End Function

    End Class

End Namespace