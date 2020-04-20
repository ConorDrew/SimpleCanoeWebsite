Imports System.Collections.Generic
Imports FSM.Entity.Sys

Namespace Entity.Customers

    Public Class CustomerAlertSql
        Private _database As Database

        Public Sub New(ByVal database As Database)
            _database = database
        End Sub

        Public Function [Get](ByVal Id As Integer) As List(Of CustomerAlert)
            _database.ClearParameter()
            _database.AddParameter("@Id", Id)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerAlert_Get")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim customerAlerts As List(Of CustomerAlert) = ObjectMap.DataTableToList(Of CustomerAlert)(dt)
                Return customerAlerts
            Else : Return Nothing
            End If
        End Function

        Public Function [Get_ForCustomer](ByVal customerId As Integer) As List(Of CustomerAlert)
            _database.ClearParameter()
            _database.AddParameter("@CustomerId", customerId)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerAlert_Get_ForCustomer")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim customerAlerts As List(Of CustomerAlert) = ObjectMap.DataTableToList(Of CustomerAlert)(dt)
                Return customerAlerts
            Else : Return Nothing
            End If
        End Function

        Public Function [Insert](ByVal customerAlert As CustomerAlert) As CustomerAlert
            _database.ClearParameter()
            _database.AddParameter("@CustomerId", customerAlert.CustomerId, True)
            _database.AddParameter("@AlertTypeId", customerAlert.AlertTypeId, True)
            _database.AddParameter("@EmailAddress", customerAlert.EmailAddress, True)
            customerAlert.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CustomerAlert_Insert"))
            Return customerAlert
        End Function

        Public Sub [Update](ByVal customerAlert As CustomerAlert)
            _database.ClearParameter()
            _database.AddParameter("@Id", customerAlert.Id, True)
            _database.AddParameter("@EmailAddress", customerAlert.EmailAddress, True)
            _database.ExecuteSP_NO_Return("CustomerAlert_Update")
        End Sub

        Public Sub [Delete](ByVal customerAlert As CustomerAlert)
            _database.ClearParameter()
            _database.AddParameter("@Id", customerAlert.Id, True)
            _database.ExecuteSP_NO_Return("CustomerAlert_Delete")
        End Sub

    End Class

End Namespace