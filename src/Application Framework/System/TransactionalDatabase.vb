Imports System.Data.SqlClient

Namespace Entity.Sys

    Public Class TransactionalDatabase

#Region "Functions"

        Public Function Transaction_Get() As SqlTransaction
            Dim c As SqlConnection = New SqlConnection(TheSystem.Configuration.ConnectionString)
            Try
                c.Open()
                Return CType(c.BeginTransaction(IsolationLevel.ReadUncommitted), SqlTransaction)
            Catch
                If Not c.State = ConnectionState.Closed Then
                    c.Close()
                End If
                c.Dispose()
                Throw
            End Try
        End Function

        Public Function CreateStoredProcedure(ByVal spName As String, ByVal Trans As SqlTransaction) As SqlClient.SqlCommand
            Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand
            Command.CommandText = spName
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = Trans
            Return Command
        End Function

        Public Sub ExecuteNonQuerySPTrans(ByVal cmd As SqlCommand)
            cmd.Connection = cmd.Transaction.Connection
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Function ExecuteTableSPTrans(ByVal cmd As SqlCommand) As DataTable
            cmd.Connection = cmd.Transaction.Connection
            Try
                Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)
                Return returnDS.Tables(0)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Function ExecuteScalarSPTrans(ByVal cmd As SqlCommand) As Integer
            cmd.Connection = cmd.Transaction.Connection
            Try
                Return Entity.Sys.Helper.MakeIntegerValid(cmd.ExecuteScalar())
            Catch ex As Exception
                Throw
            End Try
        End Function

        Public Sub Transaction_Commit(ByVal trans As SqlTransaction)
            Dim con As SqlClient.SqlConnection = trans.Connection
            trans.Commit()
            con.Close()
        End Sub

        Public Sub Transaction_Rollback(ByVal trans As SqlTransaction)
            Dim con As SqlClient.SqlConnection = trans.Connection
            trans.Rollback()
            con.Close()
        End Sub

#End Region

    End Class

End Namespace