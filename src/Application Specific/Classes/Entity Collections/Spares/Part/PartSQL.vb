Imports System.Data.SqlClient

Namespace Entity

    Namespace Parts

        Public Class PartSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal PartID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.ExecuteSP_NO_Return("Part_Delete")
            End Sub

            Public Function [Part_Get](ByVal PartID As Integer, ByVal trans As SqlClient.SqlTransaction) As Part

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Part_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartID", PartID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oPart As New Part
                        With oPart
                            .IgnoreExceptionsOnSetMethods = True
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetName = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Name"))
                            .SetNumber = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Number"))
                            .SetReference = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Reference"))
                            .SetNotes = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Notes"))
                            .SetUnitTypeID = dt.Rows(0).Item("UnitTypeID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetSellPrice = dt.Rows(0).Item("SellPrice")
                            .SetMinimumQuantity = dt.Rows(0).Item("MinimumQuantity")
                            .SetRecommendedQuantity = dt.Rows(0).Item("RecommendedQuantity")
                            .SetCategoryID = dt.Rows(0).Item("CategoryID")
                            .SetWarehouseID = dt.Rows(0).Item("WarehouseID")
                            .SetShelfID = dt.Rows(0).Item("ShelfID")
                            .SetBinID = dt.Rows(0).Item("BinID")
                            .SetWarehouseQuantity = dt.Rows(0).Item("WarehouseQuantity")
                            .SetWarehouseIDAlternative = dt.Rows(0).Item("WarehouseIDAlternative")
                            .SetShelfIDAlternative = dt.Rows(0).Item("ShelfIDAlternative")
                            .SetBinIDAlternative = dt.Rows(0).Item("BinIDAlternative")
                            .SetEndFlagged = dt.Rows(0).Item("EndFlagged")
                            .SetEquipment = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Equipment"))
                            .SetFuelID = Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("FuelID"))
                            .SetMakeID = Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("MakeID"))
                        End With
                        oPart.Exists = True
                        Return oPart
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Part_Get](ByVal PartID As Integer) As Part
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Part_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oPart As New Part
                        With oPart
                            .IgnoreExceptionsOnSetMethods = True
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetName = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Name"))
                            .SetNumber = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Number"))
                            .SetReference = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Reference"))
                            .SetNotes = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Notes"))
                            .SetUnitTypeID = dt.Rows(0).Item("UnitTypeID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetSellPrice = dt.Rows(0).Item("SellPrice")
                            .SetMinimumQuantity = dt.Rows(0).Item("MinimumQuantity")
                            .SetRecommendedQuantity = dt.Rows(0).Item("RecommendedQuantity")
                            .SetCategoryID = dt.Rows(0).Item("CategoryID")
                            .SetWarehouseID = dt.Rows(0).Item("WarehouseID")
                            .SetShelfID = dt.Rows(0).Item("ShelfID")
                            .SetBinID = dt.Rows(0).Item("BinID")
                            .SetWarehouseQuantity = dt.Rows(0).Item("WarehouseQuantity")
                            .SetWarehouseIDAlternative = dt.Rows(0).Item("WarehouseIDAlternative")
                            .SetShelfIDAlternative = dt.Rows(0).Item("ShelfIDAlternative")
                            .SetBinIDAlternative = dt.Rows(0).Item("BinIDAlternative")
                            .SetEndFlagged = dt.Rows(0).Item("EndFlagged")
                            .SetEquipment = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Equipment"))
                            .SetFuelID = Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("FuelID"))
                            .SetMakeID = Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("MakeID"))
                            .SetIsSpecialPart = dt.Rows(0).Item("IsSpecialPart")

                        End With
                        oPart.Exists = True
                        Return oPart
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Part_Get_For_Code_And_Supplier](ByVal Code As String, ByVal SupplierID As Integer) As Part
                _database.ClearParameter()
                _database.AddParameter("@PartID", Code)
                _database.AddParameter("@SupplierID", SupplierID)
                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplier_GetByPartCodeAndSupplier")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oPart As New Part
                        With oPart
                            .IgnoreExceptionsOnSetMethods = True
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetName = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Name"))
                            .SetNumber = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Number"))
                            .SetSPartID = dt.Rows(0).Item("PartSupplierID")
                        End With
                        oPart.Exists = True
                        Return oPart
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function Check_Unique_Number(ByVal Number As String, ByVal ID As Integer) As Boolean
                Dim NumberOfParts As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(PartID) as 'NumberOfParts' " &
                "FROM tblpart WHERE Deleted = 0 AND Number = '" & Number & "' AND partid <> " & ID, False))

                If NumberOfParts = 0 Then
                    Return True
                Else
                    Return False
                End If
            End Function

            Public Function Check_Unique_Bin(ByVal BinID As Integer, ByVal ID As Integer, ByVal ColumnName As String) As Boolean
                Dim NumberOfParts As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(PartID) as 'NumberOfParts' " &
                "FROM tblpart WHERE " & ColumnName & " = " & BinID & " AND partid <> " & ID, False))

                If NumberOfParts = 0 Then
                    Return True
                Else
                    Return False
                End If
            End Function

            Public Function [Part_GetAll](ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Part_GetAll"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function [Part_GetAll](Optional ByVal ForMassPartEntry As Boolean = False) As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Part_GetAll")

                If ForMassPartEntry Then
                    dt.AcceptChanges()
                    dt.Columns.Add(New DataColumn("QuantityToAdd", System.Type.GetType("System.Int64")))

                    For Each row As DataRow In dt.Rows
                        row.Item("QuantityToAdd") = 0
                    Next

                    dt.AcceptChanges()
                End If

                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function [Customer_Parts_GetAll](ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_Parts_GetAll")

                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function Part_Exists(ByVal Part_Code As String, ByVal Supplier_Part_Code As String, Optional ByVal trans As SqlTransaction = Nothing) As Integer
                If trans Is Nothing Then
                    'Dim PartFoundID As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT DISTINCT COALESCE (tblPart.PartID, 0) AS PartID FROM tblPart LEFT OUTER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPartSupplier.PartCode = '" & Part_Code & "') OR (tblPart.Number = '" & Part_Code & "')", False))
                    Dim PartFoundID As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT DISTINCT COALESCE (tblPart.PartID, 0) AS PartID FROM tblPart LEFT OUTER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Number = '" & Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" & Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" & Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Number = '" & Supplier_Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" & Supplier_Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" & Supplier_Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0)", False))
                    Return PartFoundID
                Else
                    'Dim PartFoundID As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT DISTINCT COALESCE (tblPart.PartID, 0) AS PartID FROM tblPart LEFT OUTER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPartSupplier.PartCode = '" & Part_Code & "') OR (tblPart.Number = '" & Part_Code & "')", trans, False))
                    Dim PartFoundID As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT DISTINCT COALESCE (tblPart.PartID, 0) AS PartID FROM tblPart LEFT OUTER JOIN tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID WHERE (tblPart.Number = '" & Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" & Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" & Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Number = '" & Supplier_Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPart.Reference = '" & Supplier_Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0) OR (tblPartSupplier.PartCode = '" & Supplier_Part_Code & "') AND (tblPart.Deleted IS NULL OR tblPart.Deleted = 0)", trans, False))
                    Return PartFoundID
                End If
            End Function

            Public Function [Part_Search](ByVal criteria As String, ByVal SearchOnField As String) As DataView

                If SearchOnField.Trim.Length > 0 Then
                    criteria = "'%" & criteria & "%'"
                End If

                _database.ClearParameter()
                _database.AddParameter("@SearchString", criteria, True)
                _database.AddParameter("@SearchOnField", SearchOnField, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Part_SearchList")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function [Part_Check_Stock_Level](ByVal PartID As Integer, ByVal LocationID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@LocationID", LocationID, True)

                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Part_Check_Stock_Level"))
            End Function

            Public Function [Part_Check_Stock_Level](ByVal PartID As Integer, ByVal LocationID As Integer, ByVal trans As SqlClient.SqlTransaction) As Integer
                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Part_Check_Stock_Level"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartID", PartID)
                Command.Parameters.AddWithValue("@LocationID", LocationID)

                Return Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
            End Function

            Public Function [Insert](ByVal oPart As Part) As Part
                _database.ClearParameter()
                AddPartParametersToCommand(oPart)

                oPart.SetPartID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Part_Insert"))
                oPart.Exists = True
                Return oPart
            End Function

            Public Sub [Update](ByVal oPart As Part)
                _database.ClearParameter()
                _database.AddParameter("@PartID", oPart.PartID, True)
                AddPartParametersToCommand(oPart)
                _database.AddParameter("@LastChanged", Date.Now, True)
                _database.ExecuteSP_NO_Return("Part_Update")
            End Sub

            Private Sub AddPartParametersToCommand(ByRef oPart As Part)
                With _database
                    .AddParameter("@Name", oPart.Name, True)
                    .AddParameter("@Number", oPart.Number, True)
                    .AddParameter("@Reference", oPart.Reference, True)
                    .AddParameter("@Notes", oPart.Notes, True)
                    .AddParameter("@UnitTypeID", oPart.UnitTypeID, True)
                    .AddParameter("@SellPrice", oPart.SellPrice, True)
                    .AddParameter("@MinimumQuantity", oPart.MinimumQuantity, True)
                    .AddParameter("@RecommendedQuantity", oPart.RecommendedQuantity, True)
                    .AddParameter("@CategoryID", oPart.CategoryID, True)
                    .AddParameter("@WarehouseID", oPart.WarehouseID, True)
                    .AddParameter("@ShelfID", oPart.ShelfID, True)
                    .AddParameter("@BinID", oPart.BinID, True)
                    .AddParameter("@WarehouseIDAlternative", oPart.WarehouseIDAlternative, True)
                    .AddParameter("@ShelfIDAlternative", oPart.ShelfIDAlternative, True)
                    .AddParameter("@BinIDAlternative", oPart.BinIDAlternative, True)
                    .AddParameter("@EndFlagged", oPart.EndFlagged, True)
                    .AddParameter("@Equipment", oPart.Equipment, True)
                    .AddParameter("@FuelID", oPart.FuelID, True)
                    .AddParameter("@MakeID", oPart.MakeID, True)

                End With
            End Sub

            Public Function Stock_Valuation(ByVal CategoryID As Integer, ByVal WarehouseID As Integer, ByVal VanID As Integer, ByVal FilterString As String, ByVal ExactMatch As Boolean) As DataSet
                _database.ClearParameter()
                _database.AddParameter("@CategoryID", CategoryID, True)
                _database.AddParameter("@WarehouseID", WarehouseID, True)
                _database.AddParameter("@VanID", VanID, True)
                _database.AddParameter("@FilterString", FilterString, True)
                If ExactMatch Then
                    _database.AddParameter("@ExactMatch", "Y", True)
                Else
                    _database.AddParameter("@ExactMatch", "N", True)
                End If
                _database.AddParameter("@PartsToBeCreditedStatus_Awaiting", CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Awaiting_Part_Return), True)
                _database.AddParameter("@OrderType_Van", CInt(Entity.Sys.Enums.OrderType.StockProfile), True)
                _database.AddParameter("@DownloadedVisitStatus", CInt(Entity.Sys.Enums.VisitStatus.Downloaded), True)

                Return _database.ExecuteSP_DataSet("Stock_Valuation_Report")
            End Function

            Public Function Stock_Used() As DataView
                _database.ClearParameter()
                Return New DataView(_database.ExecuteSP_DataTable("Stock_Used_Report"))
            End Function

            Public Function Stock_Get_Locations(ByVal PartID As Integer, Optional ByVal WarehouseID As Integer = 0) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@ProductID", 0, True)
                _database.AddParameter("@WarehouseID", WarehouseID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Stock_Get_Locations")
                dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
                Return New DataView(dt)
            End Function

            Public Function Stock_Get_Locations(ByVal PartID As Integer, ByVal trans As SqlClient.SqlTransaction, Optional ByVal WarehouseID As Integer = 0) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Stock_Get_Locations"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartID", PartID)
                Command.Parameters.AddWithValue("@ProductID", 0)
                Command.Parameters.AddWithValue("@WarehouseID", WarehouseID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString

                Return New DataView(dt)

            End Function

            Public Function Stock_Quantities() As DataView
                _database.ClearParameter()
                Return New DataView(_database.ExecuteSP_DataTable("Stock_Quantities"))
            End Function

            Public Function Part_Locations_Get(ByVal PartID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartLocations_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function PartLocations_GetForVanHM(ByVal LocationID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartLocations_GetForVanHM")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function PartLocations_GetForVan(ByVal LocationID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartLocations_GetForVan")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function PartLocations_GetForVan2(ByVal LocationID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Part_VanProfile2")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function PartLocation_GetStockLevel(ByVal LocationID As Integer, ByVal PartID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID, True)
                _database.AddParameter("@PartID", PartID, True)
                Dim int As Integer = _database.ExecuteSP_OBJECT("Stock_Get_ForLocationAndPart")

                Return int

            End Function

            Public Sub Part_Locations_Update(ByVal PartID As Integer, ByVal DV As DataView)
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.ExecuteSP_NO_Return("PartLocations_Delete")

                For Each row As DataRow In DV.Table.Rows
                    _database.ClearParameter()
                    _database.AddParameter("@PartID", PartID, True)
                    _database.AddParameter("@LocationID", row.Item("LocationID"), True)
                    _database.AddParameter("@MinQty", row.Item("MinQty"), True)
                    _database.AddParameter("@RecQty", row.Item("RecQty"), True)

                    _database.ExecuteSP_NO_Return("PartLocations_Insert")
                Next
            End Sub

            Public Sub Part_Locations_Insert(ByVal PartID As Integer, ByVal LocationID As Integer, ByVal MinQty As Integer, ByVal MaxQty As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@LocationID", LocationID, True)
                _database.AddParameter("@MinQty", MinQty, True)
                _database.AddParameter("@RecQty", MaxQty, True)
                _database.ExecuteSP_NO_Return("PartLocations_Insert")
            End Sub

            Public Sub Part_Locations_Delete(ByVal PartID As Integer, ByVal LocationID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@LocationID", LocationID, True)
                _database.ExecuteSP_NO_Return("Part_Locations_Delete")
            End Sub

            Public Function Part_Locations_Get_For_Replenishment(ByVal PartID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartLocations_GetAll_For_Replenishment")
                dt.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function Part_Locations_Get_For_Replenishment_Suppliers_Only(ByVal PartID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartLocations_GetAll_For_Replenishment_Suppliers_Only")
                dt.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function [PartPack_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartPack_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
                Return New DataView(dt)

            End Function

            Public Function PartPack_Get(ByVal PackID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PackID", PackID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartPack_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function PartPack_Get_Suppliers(ByVal PackID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PackID", PackID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartPack_Get_Suppliers")
                dt.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace