Imports System.Data.SqlClient

Namespace Entity

Namespace ProductSuppliers

Public Class ProductSupplierSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

            Public Function ProductSupplier_Search(ByVal SearchString As String, Optional ByVal SupplierID As Integer = 0)
                _database.ClearParameter()
                _database.AddParameter("@SearchString", SearchString, True)
                _database.AddParameter("@SupplierID", SupplierID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductSupplier_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
                Return New DataView(dt)
            End Function

            Public Function [ProductSupplier_Get](ByVal ProductSupplierID As Integer, ByVal trans As SqlClient.SqlTransaction) As ProductSupplier

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "ProductSupplier_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@ProductSupplierID", ProductSupplierID)


                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oProductSupplier As New ProductSupplier
                        With oProductSupplier
                            .IgnoreExceptionsOnSetMethods = True
                            .SetProductID = dt.Rows(0).Item("ProductID")
                            .SetProductSupplierID = dt.Rows(0).Item("ProductSupplierID")
                            .SetProductCode = dt.Rows(0).Item("ProductCode")
                            .SetPrice = dt.Rows(0).Item("Price")
                            .SetSupplierID = dt.Rows(0).Item("SupplierID")
                            .SetQuantityInPack = dt.Rows(0).Item("QuantityInPack")
                        End With
                        oProductSupplier.Exists = True
                        Return oProductSupplier
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [ProductSupplier_Get](ByVal ProductSupplierID As Integer) As ProductSupplier
                _database.ClearParameter()
                _database.AddParameter("@ProductSupplierID", ProductSupplierID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductSupplier_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oProductSupplier As New ProductSupplier
                        With oProductSupplier
                            .IgnoreExceptionsOnSetMethods = True
                            .SetProductID = dt.Rows(0).Item("ProductID")
                            .SetProductSupplierID = dt.Rows(0).Item("ProductSupplierID")
                            .SetProductCode = dt.Rows(0).Item("ProductCode")
                            .SetPrice = dt.Rows(0).Item("Price")
                            .SetSupplierID = dt.Rows(0).Item("SupplierID")
                            .SetQuantityInPack = dt.Rows(0).Item("QuantityInPack")
                        End With
                        oProductSupplier.Exists = True
                        Return oProductSupplier
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function ProductSupplierPacks_Get(ByVal ProductID As Integer, ByVal SupplierID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ProductID", ProductID, True)
                _database.AddParameter("@SupplierID", SupplierID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductSupplierPacks_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProductSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function ProductSupplierPacks_Get(ByVal ProductID As Integer, ByVal SupplierID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "ProductSupplierPacks_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@ProductID", ProductID)
                Command.Parameters.AddWithValue("@SupplierID", SupplierID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Entity.Sys.Enums.TableNames.tblProductSupplier.ToString

                Return New DataView(dt)

            End Function

            Public Function ProductSupplierGet_All() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductSupplier_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProductSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function Get_ByProductID(ByVal ProductID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ProductID", ProductID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ProductSupplier_GetByProduct")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProductSupplier.ToString
                Return New DataView(dt)
            End Function


            Public Sub Delete(ByVal ProductSupplierID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ProductSupplierID", ProductSupplierID, True)
                _database.ExecuteSP_NO_Return("ProductSupplier_Delete")
            End Sub

            Public Function [Insert](ByVal oProductSupplier As ProductSupplier) As ProductSupplier
                _database.ClearParameter()
                AddProductSupplierParametersToCommand(oProductSupplier)

                oProductSupplier.SetProductSupplierID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ProductSupplier_Insert"))
                oProductSupplier.Exists = True
                Return oProductSupplier
            End Function


            Public Sub [Update](ByVal oProductSupplier As ProductSupplier)
                _database.ClearParameter()
                _database.AddParameter("@ProductSupplierID", oProductSupplier.ProductSupplierID, True)
                AddProductSupplierParametersToCommand(oProductSupplier)
                _database.ExecuteSP_NO_Return("ProductSupplier_Update")
            End Sub



            Private Sub AddProductSupplierParametersToCommand(ByRef oProductSupplier As ProductSupplier)
                With _database
                    .AddParameter("@ProductID", oProductSupplier.ProductID, True)
                    .AddParameter("@SupplierID", oProductSupplier.SupplierID, True)
                    .AddParameter("@ProductCode", oProductSupplier.ProductCode, True)
                    .AddParameter("@Price", oProductSupplier.Price, True)
                    .AddParameter("@QuantityInPack", oProductSupplier.QuantityInPack, True)
                End With
            End Sub


#End Region

End Class

End Namespace

End Namespace


