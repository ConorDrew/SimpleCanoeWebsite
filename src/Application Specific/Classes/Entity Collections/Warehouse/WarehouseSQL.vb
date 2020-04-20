Imports System.Data.SqlClient

Namespace Entity

    Namespace Warehouses

        Public Class WarehouseSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal WarehouseID As Integer)
                Dim WarehouseName As String = Warehouse_Get(WarehouseID).Name.Trim

                _database.ClearParameter()
                _database.AddParameter("@WarehouseID", WarehouseID, True)
                _database.ExecuteSP_NO_Return("Warehouse_Delete")

                For Each row As DataRow In DB.Van.Van_GetAll(False).Table.Rows
                    If Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(1).Trim = WarehouseName Then
                        DB.Van.Delete(row.Item("VanID"), True)
                    End If
                Next
            End Sub

            Public Function [Warehouse_GetDV](ByVal WarehouseID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Warehouse_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@WarehouseID", WarehouseID)


                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
                Return New DataView(dt)

            End Function

            Public Function [Warehouse_GetDV](ByVal WarehouseID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@WarehouseID", WarehouseID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Warehouse_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
                Return New DataView(dt)

            End Function

            Public Function [Warehouse_Get](ByVal WarehouseID As Integer) As Warehouse

                _database.ClearParameter()
                _database.AddParameter("@WarehouseID", WarehouseID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Warehouse_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oWarehouse As New Warehouse
                        With oWarehouse
                            .IgnoreExceptionsOnSetMethods = True
                            .SetWarehouseID = dt.Rows(0).Item("WarehouseID")
                            .SetName = dt.Rows(0).Item("warehouseName")
                            .SetSize = dt.Rows(0).Item("Size")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetAddress1 = dt.Rows(0).Item("Address1")
                            .SetAddress2 = dt.Rows(0).Item("Address2")
                            .SetAddress3 = dt.Rows(0).Item("Address3")
                            .SetAddress4 = dt.Rows(0).Item("Address4")
                            .SetAddress5 = dt.Rows(0).Item("Address5")
                            .SetPostcode = dt.Rows(0).Item("Postcode")
                            .SetTelephoneNum = dt.Rows(0).Item("TelephoneNum")
                            .SetFaxNum = dt.Rows(0).Item("FaxNum")
                            .SetEmailAddress = dt.Rows(0).Item("EmailAddress")
                            .SetActive = dt.Rows(0).Item("Active")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oWarehouse.Exists = True
                        Return oWarehouse
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Warehouse_Get](ByVal WarehouseID As Integer, ByVal trans As SqlClient.SqlTransaction) As Warehouse

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Warehouse_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@WarehouseID", WarehouseID)
             

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oWarehouse As New Warehouse
                        With oWarehouse
                            .IgnoreExceptionsOnSetMethods = True
                            .SetWarehouseID = dt.Rows(0).Item("WarehouseID")
                            .SetName = dt.Rows(0).Item("warehouseName")
                            .SetSize = dt.Rows(0).Item("Size")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetAddress1 = dt.Rows(0).Item("Address1")
                            .SetAddress2 = dt.Rows(0).Item("Address2")
                            .SetAddress3 = dt.Rows(0).Item("Address3")
                            .SetAddress4 = dt.Rows(0).Item("Address4")
                            .SetAddress5 = dt.Rows(0).Item("Address5")
                            .SetPostcode = dt.Rows(0).Item("Postcode")
                            .SetTelephoneNum = dt.Rows(0).Item("TelephoneNum")
                            .SetFaxNum = dt.Rows(0).Item("FaxNum")
                            .SetEmailAddress = dt.Rows(0).Item("EmailAddress")
                            .SetActive = dt.Rows(0).Item("Active")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oWarehouse.Exists = True
                        Return oWarehouse
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Warehouse_GetByLocationID](ByVal LocationID As Integer) As Warehouse
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Warehouse_GetByLocationID")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oWarehouse As New Warehouse
                        With oWarehouse
                            .IgnoreExceptionsOnSetMethods = True
                            .SetWarehouseID = dt.Rows(0).Item("WarehouseID")
                            .SetName = dt.Rows(0).Item("warehouseName")
                            .SetSize = dt.Rows(0).Item("Size")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetAddress1 = dt.Rows(0).Item("Address1")
                            .SetAddress2 = dt.Rows(0).Item("Address2")
                            .SetAddress3 = dt.Rows(0).Item("Address3")
                            .SetAddress4 = dt.Rows(0).Item("Address4")
                            .SetAddress5 = dt.Rows(0).Item("Address5")
                            .SetPostcode = dt.Rows(0).Item("Postcode")
                            .SetTelephoneNum = dt.Rows(0).Item("TelephoneNum")
                            .SetFaxNum = dt.Rows(0).Item("FaxNum")
                            .SetEmailAddress = dt.Rows(0).Item("EmailAddress")
                            .SetActive = dt.Rows(0).Item("Active")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oWarehouse.Exists = True
                        Return oWarehouse
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Warehouse_GetByLocationID](ByVal LocationID As Integer, ByVal trans As SqlClient.SqlTransaction) As Warehouse

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Warehouse_GetByLocationID"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@LocationID", LocationID)


                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oWarehouse As New Warehouse
                        With oWarehouse
                            .IgnoreExceptionsOnSetMethods = True
                            .SetWarehouseID = dt.Rows(0).Item("WarehouseID")
                            .SetName = dt.Rows(0).Item("warehouseName")
                            .SetSize = dt.Rows(0).Item("Size")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetAddress1 = dt.Rows(0).Item("Address1")
                            .SetAddress2 = dt.Rows(0).Item("Address2")
                            .SetAddress3 = dt.Rows(0).Item("Address3")
                            .SetAddress4 = dt.Rows(0).Item("Address4")
                            .SetAddress5 = dt.Rows(0).Item("Address5")
                            .SetPostcode = dt.Rows(0).Item("Postcode")
                            .SetTelephoneNum = dt.Rows(0).Item("TelephoneNum")
                            .SetFaxNum = dt.Rows(0).Item("FaxNum")
                            .SetEmailAddress = dt.Rows(0).Item("EmailAddress")
                            .SetActive = dt.Rows(0).Item("Active")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oWarehouse.Exists = True
                        Return oWarehouse
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Warehouse_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Warehouse_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
                Return New DataView(dt)
            End Function

            Public Function Warehouse_GetAll_For_Van2(ByVal VanID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@VanID", VanID)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Warehouse_GetAll_For_Van2")  ' rd change
                dt.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
                Return New DataView(dt)
            End Function

            Public Function [Warehouse_GetAll](ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Warehouse_GetAll"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection


                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)
                dt.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
                Return New DataView(dt)

            End Function

            Public Function [Insert](ByVal oWarehouse As Warehouse, ByVal LocationsDataView As DataView) As Warehouse
                _database.ClearParameter()
                AddWarehouseParametersToCommand(oWarehouse)

                oWarehouse.SetWarehouseID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Warehouse_Insert"))
                oWarehouse.Exists = True

                Dim oLocation As New Entity.Locationss.Locations
                oLocation.SetDeleted = False
                oLocation.SetVanID = Nothing
                oLocation.SetWarehouseID = oWarehouse.WarehouseID
                DB.Location.Insert(oLocation)

                For Each row As DataRow In DB.Van.Van_GetAll(True).Table.Rows
                    Dim oVan As New Vans.Van
                    oVan.SetRegistration = row.Item("Registration") & " * " & oWarehouse.Name

                    oVan.SetNotes = row.Item("Notes")
                    oVan.InsuranceDue = row.Item("InsuranceDue")
                    oVan.MOTDue = row.Item("MOTDue")
                    oVan.TaxDue = row.Item("TaxDue")
                    oVan.ServiceDue = row.Item("ServiceDue")
                    oVan.SetMileageLimit = row.Item("MileageLimit")
                    oVan.SetPeriodValue = row.Item("PeriodValue")
                    oVan.SetPeriodType = row.Item("PeriodType")

                    DB.Van.Insert(oVan, "", Nothing, True)
                Next

                For Each row As DataRow In DB.Van.Van_GetAll(True).Table.Rows
                    For Each locationRow As DataRow In LocationsDataView.Table.Rows
                        If row.Item("Registration") = locationRow.Item("Registration") Then
                            Dim locID As Integer = DB.Van.Van_GetAll_For_Warehouse(oWarehouse.WarehouseID).Table.Select("Registration = '" & row.Item("Registration") & "'")(0).Item("LocationID")
                            DB.Location.Update(locID, Not locationRow.Item("Tick"))
                        End If
                    Next
                Next

                Return oWarehouse
            End Function

            Public Function [Warehouse_Search](ByVal criteria As String, ByVal SearchOnField As String) As DataView

                If SearchOnField.Trim.Length > 0 Then
                    criteria = "'%" & criteria & "%'"
                End If

                _database.ClearParameter()
                _database.AddParameter("@SearchString", criteria, True)
                _database.AddParameter("@SearchOnField", SearchOnField, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Warehouse_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Update](ByVal oWarehouse As Warehouse, ByVal LocationsDataView As DataView)
                Dim WarehouseName As String = Warehouse_Get(oWarehouse.WarehouseID).Name.Trim

                _database.ClearParameter()
                _database.AddParameter("@WarehouseID", oWarehouse.WarehouseID, True)
                AddWarehouseParametersToCommand(oWarehouse)
                _database.ExecuteSP_NO_Return("Warehouse_Update")

                For Each row As DataRow In DB.Van.Van_GetAll(False).Table.Rows
                    If Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(1).Trim = WarehouseName Then
                        Dim oVan As New Vans.Van

                        oVan.SetVanID = row.Item("VanID")
                        oVan.SetRegistration = Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(0).Trim & " * " & oWarehouse.Name
                        oVan.SetNotes = row.Item("Notes")
                        oVan.InsuranceDue = row.Item("InsuranceDue")
                        oVan.MOTDue = row.Item("MOTDue")
                        oVan.TaxDue = row.Item("TaxDue")
                        oVan.ServiceDue = row.Item("ServiceDue")
                        oVan.SetMileageLimit = row.Item("MileageLimit")
                        oVan.SetPeriodValue = row.Item("PeriodValue")
                        oVan.SetPeriodType = row.Item("PeriodType")

                        DB.Van.Update(oVan, LocationsDataView, True)
                    End If
                Next
            End Sub

            Private Sub AddWarehouseParametersToCommand(ByRef oWarehouse As Warehouse)
                With _database
                    .AddParameter("@Name", oWarehouse.Name, True)
                    .AddParameter("@Size", oWarehouse.Size, True)
                    .AddParameter("@Notes", oWarehouse.Notes, True)
                    .AddParameter("@Address1", oWarehouse.Address1, True)
                    .AddParameter("@Address2", oWarehouse.Address2, True)
                    .AddParameter("@Address3", oWarehouse.Address3, True)
                    .AddParameter("@Address4", oWarehouse.Address4, True)
                    .AddParameter("@Address5", oWarehouse.Address5, True)
                    .AddParameter("@Postcode", oWarehouse.Postcode, True)
                    .AddParameter("@TelephoneNum", oWarehouse.TelephoneNum, True)
                    .AddParameter("@FaxNum", oWarehouse.FaxNum, True)
                    .AddParameter("@EmailAddress", oWarehouse.EmailAddress, True)
                    .AddParameter("@Active", oWarehouse.Active, True)
                End With
            End Sub

            Public Function Warehouse_GetWithProduct(ByVal ProductID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ProductID", ProductID)

                'Get the datatable from the database store in dt
                Return New DataView(_database.ExecuteSP_DataTable("Warehouse_GetWithProduct"))
            End Function

            Public Function Warehouse_GetWithProduct(ByVal ProductID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Warehouse_GetWithProduct"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@ProductID", ProductID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                Return New DataView(dt)

            End Function

            Public Function Warehouse_GetWithPart(ByVal PartID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Warehouse_GetWithPart"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartID", PartID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                Return New DataView(dt)

            End Function

            Public Function Warehouse_GetWithPart(ByVal PartID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID)

                'Get the datatable from the database store in dt
                Return New DataView(_database.ExecuteSP_DataTable("Warehouse_GetWithPart"))
            End Function

#End Region

        End Class

    End Namespace

End Namespace


