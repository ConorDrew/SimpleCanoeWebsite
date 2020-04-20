Imports System.Data.SqlClient

Namespace Entity

Namespace PartTransactions

Public Class PartTransactionSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

            Public Function PartTransaction_GetByOrderLocationPart(ByVal OrderLocationPartID As Integer, ByVal trans As SqlClient.SqlTransaction) As Entity.PartTransactions.PartTransaction

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand
                Command.CommandText = "PartTransaction_GetByOrderLocationPart"
                Command.CommandType = CommandType.StoredProcedure

                If Not trans Is Nothing Then
                    Command.Transaction = trans
                    Command.Connection = trans.Connection
                End If

                Command.Parameters.AddWithValue("@OrderLocationPartID", OrderLocationPartID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oPartTransaction As New PartTransaction
                        With oPartTransaction
                            .IgnoreExceptionsOnSetMethods = True
                            .SetPartTransactionID = dt.Rows(0).Item("PartTransactionID")
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetAmount = dt.Rows(0).Item("Amount")
                            .TransactionDate = CDate(dt.Rows(0).Item("TransactionDate"))
                            .SetUserID = dt.Rows(0).Item("UserID")
                            .SetTransactionTypeID = dt.Rows(0).Item("TransactionTypeID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetOrderPartID = dt.Rows(0).Item("OrderPartID")
                            .SetOrderLocationPartID = dt.Rows(0).Item("OrderLocationPartID")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oPartTransaction.Exists = True
                        Return oPartTransaction
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function PartTransaction_GetByOrderLocationPart(ByVal OrderLocationPartID As Integer) As Entity.PartTransactions.PartTransaction
                _database.ClearParameter()
                _database.AddParameter("@OrderLocationPartID", OrderLocationPartID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartTransaction_GetByOrderLocationPart")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oPartTransaction As New PartTransaction
                        With oPartTransaction
                            .IgnoreExceptionsOnSetMethods = True
                            .SetPartTransactionID = dt.Rows(0).Item("PartTransactionID")
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetAmount = dt.Rows(0).Item("Amount")
                            .TransactionDate = CDate(dt.Rows(0).Item("TransactionDate"))
                            .SetUserID = dt.Rows(0).Item("UserID")
                            .SetTransactionTypeID = dt.Rows(0).Item("TransactionTypeID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetOrderPartID = dt.Rows(0).Item("OrderPartID")
                            .SetOrderLocationPartID = dt.Rows(0).Item("OrderLocationPartID")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oPartTransaction.Exists = True
                        Return oPartTransaction
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function PartTransaction_Consolidate_All(ByVal LocationID As Integer, ByVal PartID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID, True)
                _database.AddParameter("@PartID", PartID, True)
                _database.ExecuteSP_NO_Return("PartTransaction_Consolidate_All")
            End Function

            Public Function SearchByVan(ByVal SearchString As String, ByVal LocationID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", SearchString, True)
                _database.AddParameter("@LocationID", LocationID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Part_SearchByVan")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function GetByVan4(ByVal VanID As Integer, Optional ByVal WithLocation As Boolean = False, Optional ByVal ForIPT As Boolean = False, Optional ByVal SupplierID As Integer = 0) As DataView
                If WithLocation Then
                    Dim registration As String = DB.Van.Van_Get(VanID).Registration.Split("*")(0).Trim
                    Dim dtPartSupplier As DataTable
                    Dim dt As New DataTable
                    dt.Columns.Add(New DataColumn("Location"))
                    dt.Columns.Add(New DataColumn("PartID", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("PartName"))
                    dt.Columns.Add(New DataColumn("PartNumber"))
                    dt.Columns.Add(New DataColumn("Reference"))
                    dt.Columns.Add(New DataColumn("Amount", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("CategoryID", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("LocationID", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("Min", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("Max", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("MinMaxID", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("SPN"))

                    For Each vanRow As DataRow In DB.Van.Van_GetAll(False).Table.Rows
                        If Sys.Helper.MakeStringValid(vanRow.Item("Registration")).Split("*")(0).Trim = registration Then
                            _database.ClearParameter()
                            _database.AddParameter("@VanID", vanRow.Item("VanID"), True)
                            If ForIPT Then
                                _database.AddParameter("@ForIPT", 1, True)
                            Else
                                _database.AddParameter("@ForIPT", 0, True)
                            End If

                            Dim dtPartsByVan As DataTable = _database.ExecuteSP_DataTable("Part_GetByVan")

                            For Each row As DataRow In dtPartsByVan.Rows
                                Dim r As DataRow = dt.NewRow
                                r("Location") = Sys.Helper.MakeStringValid(vanRow.Item("Registration")).Split("*")(1).Trim
                                r("PartID") = row.Item("PartID")
                                r("PartName") = row.Item("PartName")
                                r("PartNumber") = row.Item("PartNumber")
                                r("Reference") = row.Item("Reference")
                                r("Amount") = row.Item("Amount")
                                r("CategoryID") = row.Item("CategoryID")
                                r("LocationID") = row.Item("LocationID")

                                _database.ClearParameter()
                                _database.AddParameter("@PartID", row.Item("PartID"), True)
                                Dim dtMinMaxByPart As DataTable = _database.ExecuteSP_DataTable("PartLocations_GetAll")
                                If Not dtMinMaxByPart Is Nothing Then
                                    If dtMinMaxByPart.Rows.Count = 0 Then
                                        r("Min") = 0
                                        r("Max") = 0
                                        r("MinMaxID") = 0
                                        r("SPN") = ""
                                    Else
                                        Dim rowadded As Boolean = False
                                        For Each partrow As DataRow In dtMinMaxByPart.Rows
                                            If partrow.Item("VanID") = vanRow.Item("VanID") Then
                                                r("Min") = partrow.Item("MinQty")
                                                r("Max") = partrow.Item("RecQty")
                                                r("MinMaxID") = partrow.Item("PartLocationID")

                                                _database.ClearParameter()
                                                _database.AddParameter("@PartID", row.Item("PartID"), True)
                                                _database.AddParameter("@SupplierID", SupplierID, True)
                                                dtPartSupplier = _database.ExecuteSP_DataTable("PartSupplier_GetByPartAndSupplier")
                                                If dtPartSupplier.Rows.Count = 0 Then
                                                    r("SPN") = ""
                                                ElseIf dtPartSupplier.Rows.Count > 1 Then
                                                    r("SPN") = "Multi"
                                                Else
                                                    r("SPN") = dtPartSupplier.Rows(0).Item("PartCode").ToString
                                                End If
                                                rowadded = True
                                            End If
                                        Next
                                        If rowadded = False Then
                                            r("Min") = 0
                                            r("Max") = 0
                                            r("MinMaxID") = 0
                                            r("SPN") = ""
                                        End If
                                    End If
                                Else
                                    r("Min") = 0
                                    r("Max") = 0
                                    r("MinMaxID") = 0
                                    r("SPN") = ""
                                End If

                                dt.Rows.Add(r)
                            Next
                        End If
                    Next

                    dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                    Return New DataView(dt)
                Else
                    _database.ClearParameter()
                    _database.AddParameter("@VanID", VanID, True)
                    If ForIPT Then
                        _database.AddParameter("@ForIPT", 1, True)
                    Else
                        _database.AddParameter("@ForIPT", 0, True)
                    End If
                    Dim dt As DataTable = _database.ExecuteSP_DataTable("Part_GetByVan")
                    dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                    Return New DataView(dt)
                End If
            End Function

            Public Function GetByVan2(ByVal VanID As Integer, Optional ByVal WithLocation As Boolean = False, Optional ByVal ForIPT As Boolean = False, Optional ByVal SupplierID As Integer = 0) As DataTable

                Dim ChildSupplier As Integer = DB.Supplier.GetChildSupplier(SupplierID)

                If Not ChildSupplier = 0 And Not ChildSupplier = SupplierID Then
                    SupplierID = ChildSupplier
                End If

                If WithLocation Then
                    Dim registration As String = DB.Van.Van_Get(VanID).Registration.Split("*")(0).Trim
               
                    Dim dt As New DataTable
                    Dim loopTable As New DataTable
                    Dim i As Integer = 0
                    For Each vanRow As DataRow In DB.Van.Van_GetAll(False).Table.Rows
                        If Sys.Helper.MakeStringValid(vanRow.Item("Registration")).Split("*")(0).Trim = registration Then
                            _database.ClearParameter()
                            'chkval = vanRow("VanID").ToString
                            _database.AddParameter("@VanID", vanRow.Item("VanID"), True)
                            _database.AddParameter("@SupplierID", SupplierID, True)
                            _database.AddParameter("@Location", Sys.Helper.MakeStringValid(vanRow.Item("Registration")).Split("*")(1).Trim, True)
                            'If ForIPT Then
                            '    _database.AddParameter("@ForIPT", 1, True)
                            'Else
                            '    _database.AddParameter("@ForIPT", 0, True)
                            'End If
                            If i = 0 Then
                                dt = (_database.ExecuteSP_DataTable("Part_VanProfile"))
                            Else
                                loopTable = _database.ExecuteSP_DataTable("Part_VanProfile")
                                dt.Merge(loopTable)
                            End If
                            i = i + 1

                           
                        End If
                    Next

                    dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                    Dim dvSort As New DataView(dt)
                    dvSort.Sort = "Amount ASC"
                    Return dvSort.Table
                Else
                    _database.ClearParameter()
                    _database.AddParameter("@VanID", VanID, True)
                    If ForIPT Then
                        _database.AddParameter("@ForIPT", 1, True)
                    Else
                        _database.AddParameter("@ForIPT", 0, True)
                    End If
                    Dim dt As DataTable = _database.ExecuteSP_DataTable("Part_GetByVan")
                    dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                    Return dt
                End If
            End Function

            Public Function GetByWarehouse(ByVal WarehouseID As Integer, Optional ByVal ForIPT As Boolean = False) As DataView
                _database.ClearParameter()
                _database.AddParameter("@WarehouseID", WarehouseID, True)
                If ForIPT Then
                    _database.AddParameter("@ForIPT", 1, True)
                Else
                    _database.AddParameter("@ForIPT", 0, True)
                End If

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Part_GetByWarehouse")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function SearchByWarehouse(ByVal SearchString As String, ByVal LocationID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", SearchString, True)
                _database.AddParameter("@LocationID", LocationID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Part_SearchByWarehouse")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Sub Delete(ByVal PartTransactionID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartTransactionID", PartTransactionID, True)
                _database.ExecuteSP_NO_Return("PartTransaction_Delete")
            End Sub

            Public Sub Delete(ByVal PartTransactionID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "PartTransaction_Delete"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartTransactionID", PartTransactionID)
                Command.ExecuteNonQuery()

            End Sub

            Public Sub DeleteForOrder(ByVal OrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.ExecuteSP_NO_Return("PartTransactions_DeleteForOrder")
            End Sub

            Public Sub DeleteByPartAndLocation(ByVal PartID As Integer, ByVal LocationID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@LocationID", LocationID, True)
                _database.ExecuteSP_NO_Return("PartTransaction_DeleteByPartAndLocation")
            End Sub

            Public Function [PartTransaction_Get](ByVal PartTransactionID As Integer) As PartTransaction
                _database.ClearParameter()
                _database.AddParameter("@PartTransactionID", PartTransactionID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartTransaction_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oPartTransaction As New PartTransaction
                        With oPartTransaction
                            .IgnoreExceptionsOnSetMethods = True
                            .SetPartTransactionID = dt.Rows(0).Item("PartTransactionID")
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetAmount = dt.Rows(0).Item("Amount")
                            .TransactionDate = CDate(dt.Rows(0).Item("TransactionDate"))
                            .SetUserID = dt.Rows(0).Item("UserID")
                            .SetTransactionTypeID = dt.Rows(0).Item("TransactionTypeID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetOrderPartID = dt.Rows(0).Item("OrderPartID")
                            .SetOrderLocationPartID = dt.Rows(0).Item("OrderLocationPartID")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oPartTransaction.Exists = True
                        Return oPartTransaction
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [PartTransaction_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartTransaction_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartTransaction.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oPartTransaction As PartTransaction) As PartTransaction
                _database.ClearParameter()
                AddPartTransactionParametersToCommand(oPartTransaction)

                oPartTransaction.SetPartTransactionID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartTransaction_Insert"))
                oPartTransaction.Exists = True
                Return oPartTransaction
            End Function

            Public Function [Insert](ByVal oPartTransaction As PartTransaction, ByVal trans As SqlClient.SqlTransaction) As PartTransaction

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "PartTransaction_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PartID", oPartTransaction.PartID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Amount", oPartTransaction.Amount))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserID", loggedInUser.UserID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TransactionTypeID", oPartTransaction.TransactionTypeID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LocationID", oPartTransaction.LocationID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderPartID", oPartTransaction.OrderPartID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderLocationPartID", oPartTransaction.OrderLocationPartID))

                oPartTransaction.SetPartTransactionID = Command.ExecuteScalar
                oPartTransaction.Exists = True

                Return oPartTransaction

            End Function

            Public Sub [Update](ByVal oPartTransaction As PartTransaction)
                _database.ClearParameter()
                _database.AddParameter("@PartTransactionID", oPartTransaction.PartTransactionID, True)
                AddPartTransactionParametersToCommand(oPartTransaction)

                _database.ExecuteSP_NO_Return("PartTransaction_Update")
            End Sub

            Private Sub AddPartTransactionParametersToCommand(ByVal oPartTransaction As PartTransaction)
                _database.AddParameter("@PartID", oPartTransaction.PartID, True)
                _database.AddParameter("@Amount", oPartTransaction.Amount, True)
                _database.AddParameter("@UserID", loggedInUser.UserID, True)
                _database.AddParameter("@TransactionTypeID", oPartTransaction.TransactionTypeID, True)
                _database.AddParameter("@LocationID", oPartTransaction.LocationID, True)
                _database.AddParameter("@OrderPartID", oPartTransaction.OrderPartID, True)
                _database.AddParameter("@OrderLocationPartID", oPartTransaction.OrderLocationPartID, True)
            End Sub

            Public Sub UpdateMinMaxValues(ByVal PartLocationID As Integer, ByVal MinValue As Integer, ByVal MaxValue As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartLocationID", PartLocationID, True)
                _database.AddParameter("@MinQty", MinValue, True)
                _database.AddParameter("@MaxQty", MaxValue, True)
                _database.ExecuteSP_NO_Return("PartLocations_UpdateMinMax")
            End Sub

            Public Sub PartLocations_Insert(ByVal PartID As Integer, ByVal LocationID As Integer, ByVal MinValue As Integer, ByVal MaxValue As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@LocationID", LocationID, True)
                _database.AddParameter("@MinQty", MinValue, True)
                _database.AddParameter("@RecQty", MaxValue, True)
                _database.ExecuteSP_NO_Return("PartLocations_Insert")
            End Sub

            Public Function PartLocations_Insert2(ByVal PartID As Integer, ByVal LocationID As Integer, ByVal MinValue As Integer, ByVal MaxValue As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@LocationID", LocationID, True)
                _database.AddParameter("@MinQty", MinValue, True)
                _database.AddParameter("@RecQty", MaxValue, True)

                Return _database.ExecuteSP_OBJECT("PartLocations_Insert_WithPartLocationReturn")
            End Function
#End Region

        End Class

End Namespace

End Namespace


