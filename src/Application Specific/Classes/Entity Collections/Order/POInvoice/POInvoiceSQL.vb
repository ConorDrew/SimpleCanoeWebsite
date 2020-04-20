Imports System.Data.SqlClient

Namespace Entity

    Namespace Orders

        Public Class POInvoiceSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub
#Region "Functions"
            Public Sub POInvoiceImport_UpdateAuthorised(ByVal ID As Integer, ByVal Authorised As Boolean, ByVal AuthorisedByUserID As Integer, ByVal AuthorisedOn As Date, ByVal AuthReason As String, Optional ByVal AuthReasonDetail As String = "")
                _database.ClearParameter()
                _database.AddParameter("@ID", ID, True)
                _database.AddParameter("@Authorised", Authorised, True)
                _database.AddParameter("@AuthorisedByUserID", AuthorisedByUserID, True)
                _database.AddParameter("@AuthorisedOn", AuthorisedOn, True)
                _database.AddParameter("@AuthReason", AuthReason, True)
                _database.AddParameter("@AuthReasonDetail", AuthReasonDetail, True)
                _database.AddParameter("@ValidateResult", 11, True)

                _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateAuthorisation")
            End Sub

            Public Function POInvoiceImport_RefreshData(ByVal ValidateResult As Integer, ByVal PODepartment As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ValidateResult", ValidateResult, True)
                _database.AddParameter("@PODepartment", PODepartment, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("POInvoiceImport_ShowDataAuthorisation")
                dt.TableName = "POInvoiceImport_ShowData"
                Return New DataView(dt)
            End Function

            Public Function POExceptionCount(ByVal PODepartment As String) As Integer
                _database.ClearParameter()
                _database.AddParameter("@PODepartment", PODepartment, True)

                Return _database.ExecuteScalar("SELECT COUNT(*) from tblPOInvoiceImport_Orders WHERE RequiresAuthorisation = 1 AND Authorised = 0 AND PODepartment = @PODepartment")
            End Function

#End Region
        End Class

    End Namespace

End Namespace