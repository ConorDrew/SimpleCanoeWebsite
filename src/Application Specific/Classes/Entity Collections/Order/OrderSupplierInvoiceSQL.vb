Imports System.Data.SqlClient

Namespace Entity

    Namespace Orders

        Public Class SupplierInvoiceSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("Order_DeleteSupplierInvoicesForOrder")
            End Sub

            Public Sub Delete(ByVal SupplierInvoiceID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@SupplierInvoiceID", SupplierInvoiceID, True)
                _database.ExecuteSP_NO_Return("Order_DeleteSupplierInvoice")
            End Sub

            Public Function Order_GetSupplierInvoice(ByVal SupplierInvoiceID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SupplierInvoiceID", SupplierInvoiceID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetSupplierInvoice")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrderSupplierInvoices.ToString
                Return New DataView(dt)
            End Function

            Public Function Order_GetSupplierInvoices(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetSupplierInvoices")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrderSupplierInvoices.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oSupplierInvoice As SupplierInvoice) As SupplierInvoice
                _database.ClearParameter()
                AddSupplierInvoiceParametersToCommand(oSupplierInvoice)

                oSupplierInvoice.SetInvoiceID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Order_InsertSupplierInvoice"))
                oSupplierInvoice.Exists = True

                Return oSupplierInvoice
            End Function

            Public Function [Insert](ByVal oSupplierInvoice As SupplierInvoice, ByVal trans As SqlClient.SqlTransaction) As SupplierInvoice

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Order_InsertSupplierInvoice"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderID", oSupplierInvoice.OrderID)
                Command.Parameters.AddWithValue("@SupplierInvoiceReference", oSupplierInvoice.InvoiceReference)
                Command.Parameters.AddWithValue("@SupplierInvoiceDate", oSupplierInvoice.InvoiceDate)
                If oSupplierInvoice.GoodsAmount = Nothing Then
                    Command.Parameters.AddWithValue("@SupplierGoodsAmount", 0)
                Else
                    Command.Parameters.AddWithValue("@SupplierGoodsAmount", oSupplierInvoice.GoodsAmount)
                End If
                If oSupplierInvoice.GoodsAmount = Nothing Then
                    Command.Parameters.AddWithValue("@SupplierVATAmount", 0)
                Else
                    Command.Parameters.AddWithValue("@SupplierVATAmount", oSupplierInvoice.VATAmount)
                End If
                If oSupplierInvoice.GoodsAmount = Nothing Then
                    Command.Parameters.AddWithValue("@SupplierInvoiceAmount", 0)
                Else
                    Command.Parameters.AddWithValue("@SupplierInvoiceAmount", oSupplierInvoice.TotalAmount)
                End If
                If oSupplierInvoice.GoodsAmount = Nothing Then
                    Command.Parameters.AddWithValue("@TaxCodeID", 0)
                Else
                    Command.Parameters.AddWithValue("@TaxCodeID", oSupplierInvoice.TaxCodeID)
                End If
                Command.Parameters.AddWithValue("@NominalCode", oSupplierInvoice.NominalCode)
                Command.Parameters.AddWithValue("@ExtraRef", oSupplierInvoice.ExtraRef)
                If oSupplierInvoice.GoodsAmount = Nothing Then
                    Command.Parameters.AddWithValue("@ReadyToSendToSage", 0)
                Else
                    Command.Parameters.AddWithValue("@ReadyToSendToSage", oSupplierInvoice.ReadyToSendToSage)
                End If
                If oSupplierInvoice.GoodsAmount = Nothing Then
                    Command.Parameters.AddWithValue("@SentToSage", 0)
                Else
                    Command.Parameters.AddWithValue("@SentToSage", oSupplierInvoice.SentToSage)
                End If
                If oSupplierInvoice.GoodsAmount = Nothing Then
                    Command.Parameters.AddWithValue("@OldSystemInvoice", 0)
                Else
                    Command.Parameters.AddWithValue("@OldSystemInvoice", oSupplierInvoice.OldSystemInvoice)
                End If
                If oSupplierInvoice.GoodsAmount = Nothing Then
                    Command.Parameters.AddWithValue("@DateExported", DBNull.Value)
                Else
                    Command.Parameters.AddWithValue("@DateExported", oSupplierInvoice.DateExported)
                End If
                Command.Parameters.AddWithValue("@KeyedBy", loggedInUser.UserID)

                oSupplierInvoice.SetInvoiceID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oSupplierInvoice.Exists = True

                Return oSupplierInvoice
            End Function

            Public Sub [Update](ByVal oSupplierInvoice As SupplierInvoice)
                _database.ClearParameter()
                _database.AddParameter("@SupplierInvoiceID", oSupplierInvoice.InvoiceID, True)
                AddSupplierInvoiceParametersToCommand(oSupplierInvoice)
                _database.ExecuteSP_NO_Return("Order_UpdateSupplierInvoice")
            End Sub

            Private Sub AddSupplierInvoiceParametersToCommand(ByRef oSupplierInvoice As SupplierInvoice)
                With _database
                    .AddParameter("@OrderID", oSupplierInvoice.OrderID, True)
                    .AddParameter("@SupplierInvoiceReference", oSupplierInvoice.InvoiceReference, True)
                    .AddParameter("@SupplierInvoiceDate", oSupplierInvoice.InvoiceDate, True)
                    If oSupplierInvoice.GoodsAmount = Nothing Then
                        .AddParameter("@SupplierGoodsAmount", 0, True)
                    Else
                        .AddParameter("@SupplierGoodsAmount", oSupplierInvoice.GoodsAmount, True)
                    End If
                    If oSupplierInvoice.VATAmount = Nothing Then
                        .AddParameter("@SupplierVATAmount", 0, True)
                    Else
                        .AddParameter("@SupplierVATAmount", oSupplierInvoice.VATAmount, True)
                    End If
                    If oSupplierInvoice.TotalAmount = Nothing Then
                        .AddParameter("@SupplierInvoiceAmount", 0, True)
                    Else
                        .AddParameter("@SupplierInvoiceAmount", oSupplierInvoice.TotalAmount, True)
                    End If
                    If oSupplierInvoice.TaxCodeID = Nothing Then
                        .AddParameter("@TaxCodeID", 0, True)
                    Else
                        .AddParameter("@TaxCodeID", oSupplierInvoice.TaxCodeID, True)
                    End If
                    .AddParameter("@NominalCode", oSupplierInvoice.NominalCode, True)
                    .AddParameter("@ExtraRef", oSupplierInvoice.ExtraRef, True)
                    If oSupplierInvoice.ReadyToSendToSage = Nothing Then
                        .AddParameter("@ReadyToSendToSage", 0, True)
                    Else
                        .AddParameter("@ReadyToSendToSage", oSupplierInvoice.ReadyToSendToSage, True)
                    End If
                    If oSupplierInvoice.SentToSage = Nothing Then
                        .AddParameter("@SentToSage", 0, True)
                    Else
                        .AddParameter("@SentToSage", oSupplierInvoice.SentToSage, True)
                    End If
                    If oSupplierInvoice.OldSystemInvoice = Nothing Then
                        .AddParameter("@OldSystemInvoice", 0, True)
                    Else
                        .AddParameter("@OldSystemInvoice", oSupplierInvoice.OldSystemInvoice, True)
                    End If
                    If oSupplierInvoice.DateExported = Nothing Then
                        .AddParameter("@DateExported", DBNull.Value, True)
                    Else
                        .AddParameter("@DateExported", oSupplierInvoice.DateExported, True)
                    End If
                    .AddParameter("@KeyedBy", loggedInUser.UserID, True)
                End With
            End Sub
#End Region

        End Class

    End Namespace

End Namespace


