Imports System.Data.SqlClient

Namespace Entity


    Namespace Locationss

        Public Class LocationsSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Sub Delete(ByVal LocationID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID, True)
                _database.ExecuteSP_NO_Return("Locations_Delete")
            End Sub

            Public Function [Locations_Get](ByVal LocationID As Integer) As Locations
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Locations_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oLocations As New Locations
                        With oLocations
                            .IgnoreExceptionsOnSetMethods = True
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetWarehouseID = dt.Rows(0).Item("WarehouseID")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oLocations.Exists = True
                        Return oLocations
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Locations_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Locations_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function Locations_Get_ForVanReg(ByVal VanReg As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Reg", VanReg, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Locations_Get_ForVanReg_ActiveOnly")  '' Why would it be pulling deleted ones? I changed this to not. 
                dt.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function Locations_Get_ForVanReg_ActiveOnly(ByVal VanReg As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Reg", VanReg, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Locations_Get_ForVanReg_ActiveOnly")
                dt.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function [Locations_GetAll_WithNames](ByVal trans As SqlClient.SqlTransaction) As DataView
                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Locations_GetAll_WithNames"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)
                Return New DataView(dt)

            End Function

            Public Function [Locations_GetAll_WithNames]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Locations_GetAll_WithNames")
                dt.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
                Return New DataView(dt)
            End Function

            Public Function StockTake_GetAll(ByVal ShowOnlyWithLocation As Boolean, ByVal CategoryID As Integer, ByVal WarehouseID As Integer, ByVal VanID As Integer, _
                                             ByVal ExpectedNotZero As Boolean, ByVal ShowWarehousesOnly As Boolean, ByVal ShowVansOnly As Boolean) As DataView
                _database.ClearParameter()
                If ShowOnlyWithLocation Then
                    _database.AddParameter("@ShowOnlyWithLocation", 1, True)
                Else
                    _database.AddParameter("@ShowOnlyWithLocation", 0, True)
                End If
                If ExpectedNotZero Then
                    _database.AddParameter("@ExpectedNotZero", 1, True)
                Else
                    _database.AddParameter("@ExpectedNotZero", 0, True)
                End If
                _database.AddParameter("@CategoryID", CategoryID, True)
                _database.AddParameter("@WarehouseID", WarehouseID, True)
                _database.AddParameter("@VanID", VanID, True)

                If ShowWarehousesOnly Then
                    _database.AddParameter("@ShowWarehousesOnly", 1, True)
                Else
                    _database.AddParameter("@ShowWarehousesOnly", 0, True)
                End If

                If ShowVansOnly Then
                    _database.AddParameter("@ShowVansOnly", 1, True)
                Else
                    _database.AddParameter("@ShowVansOnly", 0, True)
                End If


                Dim dt As DataTable = _database.ExecuteSP_DataTable("StockTake_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
                Return New DataView(dt)
            End Function

            Public Function StockTake_GetAll_WithName(ByVal ShowOnlyWithLocation As Boolean, ByVal CategoryID As Integer, ByVal WarehouseID As Integer, ByVal VanID As Integer, _
                                             ByVal ExpectedNotZero As Boolean, ByVal ShowWarehousesOnly As Boolean, ByVal ShowVansOnly As Boolean, ByVal MPN As String) As DataView
                _database.ClearParameter()
                If ShowOnlyWithLocation Then
                    _database.AddParameter("@ShowOnlyWithLocation", 1, True)
                Else
                    _database.AddParameter("@ShowOnlyWithLocation", 0, True)
                End If
                If ExpectedNotZero Then
                    _database.AddParameter("@ExpectedNotZero", 1, True)
                Else
                    _database.AddParameter("@ExpectedNotZero", 0, True)
                End If
                _database.AddParameter("@CategoryID", CategoryID, True)
                _database.AddParameter("@WarehouseID", WarehouseID, True)
                _database.AddParameter("@VanID", VanID, True)

                If ShowWarehousesOnly Then
                    _database.AddParameter("@ShowWarehousesOnly", 1, True)
                Else
                    _database.AddParameter("@ShowWarehousesOnly", 0, True)
                End If

                If ShowVansOnly Then
                    _database.AddParameter("@ShowVansOnly", 1, True)
                Else
                    _database.AddParameter("@ShowVansOnly", 0, True)
                End If

                _database.AddParameter("@MPN", MPN, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("StockTake_GetAll_PartName")
                dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
                Return New DataView(dt)
            End Function

            'Public Function StockTake_Replenishment_GetAll() As DataView
            '    _database.ClearParameter()

            '    Dim dt As DataTable = _database.ExecuteSP_DataTable("StockTake_Replenishment_GetAll")
            '    dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
            '    Return New DataView(dt)
            'End Function


            Public Function StockTake_Replenishment_Filtered(ByVal Location As String, ByVal Item As String, _
                                                             ByVal IncludeVans As Boolean, ByVal LessMin As Boolean, _
                                                             ByVal LessRec As Boolean) As DataView
                _database.ClearParameter()

                _database.AddParameter("@Location", Location, True)
                _database.AddParameter("@Item", Item, True)
                _database.AddParameter("@IncludeVans", IncludeVans, True)
                _database.AddParameter("@LessMin", LessMin, True)
                _database.AddParameter("@LessRec", LessRec, True)


                Dim dt As DataTable = _database.ExecuteSP_DataTable("StockTake_Replenishment_Filtered")
                dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
                Return New DataView(dt)
            End Function

            Public Function StockTake_Replenishment_Filtered_OvernightSP() As DataView
                _database.ClearParameter()

                _database.AddParameter("@Location", "", True)
                _database.AddParameter("@Item", "", True)
                _database.AddParameter("@IncludeVans", True, True)
                _database.AddParameter("@LessMin", True, True)
                _database.AddParameter("@LessRec", True, True)


                Dim dt As DataTable = _database.ExecuteSP_DataTable("StockTake_Replenishment_OvernightSP_VansOnly")
                dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
                Return New DataView(dt)
            End Function

            Public Function StockTake_Replenishment_Daily_Filtered(Optional ByVal FilterType As Integer = 0, Optional ByVal VanID As Integer = 0) As DataView
                _database.ClearParameter()
                _database.AddParameter("@FilterType", FilterType, True)
                _database.AddParameter("@VanID", VanID, True)
                Dim dt As DataTable

                If FilterType = 0 Then
                    dt = _database.ExecuteSP_DataTable("StockTake_Replenishment_Daily_FilterResults_ALL")
                Else
                    dt = _database.ExecuteSP_DataTable("StockTake_Replenishment_Daily_FilterResults")
                End If
                dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
                Return New DataView(dt)
            End Function

            Public Function StockTake_Replenishment_UpdateExclude(ByVal ItemID As Integer, ByVal Exclude As Boolean) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ItemID", ItemID, True)
                _database.AddParameter("@Exclude", Exclude, True)

                _database.ExecuteSP_NO_Return("StockTake_Replenishment_Daily_UpdateExclude")
            End Function

            Public Function StockTake_Replenishment_UpdateAmountToOrder(ByVal ItemID As Integer, ByVal AmountToOrder As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ItemID", ItemID, True)
                _database.AddParameter("@AmountToOrder", AmountToOrder, True)

                _database.ExecuteSP_NO_Return("StockTake_Replenishment_Daily_UpdateAmountToOrder")
            End Function

            Public Function StockTake_Replenishment_Daily_UpdateFilterType(ByVal ItemID As Integer, ByVal FilterType As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ItemID", ItemID, True)
                _database.AddParameter("@FilterType", FilterType, True)

                _database.ExecuteSP_NO_Return("StockTake_Replenishment_Daily_UpdateFilterType")
            End Function

            Public Function StockTake_Replenishment_Daily_UpdateSupplier(ByVal ItemID As Integer, ByVal PartSupplierID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ItemID", ItemID, True)
                _database.AddParameter("@PartSupplierID", PartSupplierID, True)

                _database.ExecuteSP_NO_Return("StockTake_Replenishment_Daily_UpdateSupplier")
            End Function

            Public Function StockTakeReason_Get() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("StockReason_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oLocations As Locations) As Locations
                _database.ClearParameter()
                AddLocationsParametersToCommand(oLocations)

                oLocations.SetLocationID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Locations_Insert"))
                oLocations.Exists = True
                Return oLocations
            End Function


            Public Sub [Update](ByVal LocationID As Integer, ByVal Deleted As Boolean)
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID, True)
                If Deleted Then
                    _database.AddParameter("@Deleted", 1, True)
                Else
                    _database.AddParameter("@Deleted", 0, True)
                End If
                _database.ExecuteSP_NO_Return("Locations_Update")
            End Sub



            Private Sub AddLocationsParametersToCommand(ByRef oLocations As Locations)
                With _database
                    If oLocations.VanID = 0 Then
                        .AddParameter("@VanID", DBNull.Value, True)
                    Else
                        .AddParameter("@VanID", oLocations.VanID, True)
                    End If

                    If oLocations.WarehouseID = 0 Then
                        .AddParameter("@WarehouseID", DBNull.Value, True)
                    Else
                        .AddParameter("@WarehouseID", oLocations.WarehouseID, True)
                    End If

                   
                End With
            End Sub

            Public Sub IPT_Audit_Insert(ByVal PartID As Integer, ByVal ProductID As Integer, ByVal FromLocationID As Integer, ByVal ToLocationID As Integer, ByVal Quantity As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@ProductID", ProductID, True)
                _database.AddParameter("@FromLocationID", FromLocationID, True)
                _database.AddParameter("@ToLocationID", ToLocationID, True)
                _database.AddParameter("@Quantity", Quantity, True)
                _database.AddParameter("@MovedByUserID", loggedInUser.UserID, True)

                _database.ExecuteSP_NO_Return("IPT_Audit_Insert")
            End Sub

            Public Function IPT_Audit_Get(ByVal Type As String, ByVal Name As String, ByVal Number As String, ByVal Reference As String, ByVal FromLocationID As Integer, ByVal ToLocationID As Integer) As DataView
                _database.ClearParameter()

                _database.AddParameter("@Type", Type, True)
                _database.AddParameter("@Name", Name, True)
                _database.AddParameter("@Number", Number, True)
                _database.AddParameter("@Reference", Reference, True)
                _database.AddParameter("@FromLocationID", FromLocationID, True)
                _database.AddParameter("@ToLocationID", ToLocationID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("IPT_Audit_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblIPTAudit.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace


