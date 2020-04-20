Imports System.Data.SqlClient

Namespace Entity

    Namespace Accounts

        Public Class SunFinanceSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"
            Public Function GetAllMaps() As DataTable
                _database.ClearParameter()
                Return _database.ExecuteSP_DataTable("AccountsMapping_Get_All")
            End Function
#End Region

        End Class

    End Namespace

End Namespace


