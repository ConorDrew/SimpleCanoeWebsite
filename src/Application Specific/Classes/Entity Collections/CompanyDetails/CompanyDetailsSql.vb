Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Sys

Namespace Entity.CompanyDetails

    Public Class CompanyDetailsSql
        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

        Public Function [Get]() As CompanyDetails
            _database.ClearParameter()
            Dim dt As DataTable = _database.ExecuteSP_DataTable("CompanyDetails_Get")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim companyDetails As List(Of CompanyDetails) = ObjectMap.DataTableToList(Of CompanyDetails)(dt)
                Return companyDetails.FirstOrDefault()
            Else : Return Nothing
            End If
        End Function

    End Class

End Namespace