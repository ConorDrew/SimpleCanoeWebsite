Imports FSM.Entity.Sys

Namespace Entity.RagRating

    Public Class RagRatingSql
        Private _database As Database

        Public Sub New(ByVal database As Database)
            _database = database
        End Sub

        Public Function [Get_All]() As DataView
            _database.ClearParameter()
            Return New DataView(_database.ExecuteSP_DataTable("RagRating_Get_All"))
        End Function

    End Class

End Namespace