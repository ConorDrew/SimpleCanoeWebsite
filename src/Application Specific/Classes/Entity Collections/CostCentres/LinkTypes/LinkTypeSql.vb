Imports FSM.Entity.Sys

Namespace Entity.CostCentres.LinkTypes

    Public Class LinkTypeSql
        Private _database As Database

        Public Sub New(ByVal database As Database)
            _database = database
        End Sub

        Public Function [GetAll]() As DataView
            _database.ClearParameter()
            Return New DataView(_database.ExecuteSP_DataTable("CostCentreLinkType_GetAll"))
        End Function

    End Class

End Namespace