Imports System.Data.SqlClient

Namespace Entity

    Namespace Vans

        Public Class VanSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal VanID As Integer, Optional ByVal DeleteFromWarehouses As Boolean = False)
                If DeleteFromWarehouses Then
                    _database.ClearParameter()
                    _database.AddParameter("@VanID", VanID, True)
                    _database.ExecuteSP_NO_Return("Van_Delete")
                Else
                    Dim registration As String = Van_Get(VanID).Registration.Split("*")(0).Trim

                    For Each row As DataRow In Van_GetAll_incDeleted(False).Table.Rows
                        If Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(0).Trim = registration Then
                            _database.ClearParameter()
                            _database.AddParameter("@VanID", row.Item("VanID"), True)
                            _database.ExecuteSP_NO_Return("Van_Delete")
                        End If
                    Next
                End If
            End Sub

            Public Function [Van_GetDV](ByVal VanID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@VanID", VanID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Van_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
                Return New DataView(dt)
            End Function

            Public Function [Van_Get](ByVal VanID As Integer) As Van
                _database.ClearParameter()
                _database.AddParameter("@VanID", VanID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Van_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New Van
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetRegistration = dt.Rows(0).Item("Registration")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .InsuranceDue = CDate(dt.Rows(0).Item("InsuranceDue"))
                            .MOTDue = CDate(dt.Rows(0).Item("MOTDue"))
                            .TaxDue = CDate(dt.Rows(0).Item("TaxDue"))
                            .ServiceDue = CDate(dt.Rows(0).Item("ServiceDue"))
                            .SetMileageLimit = dt.Rows(0).Item("MileageLimit")
                            .SetPeriodValue = dt.Rows(0).Item("PeriodValue")
                            .SetPeriodType = dt.Rows(0).Item("PeriodType")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetPreferredSupplierID = dt.Rows(0).Item("PreferredSupplierID")
                            .SetExcludeFromAutoReplenishment = dt.Rows(0).Item("ExcludeFromAutoReplenishment")
                            .SetEngineerVanID = dt.Rows(0).Item("EngineerVanID")
                            .SecondaryPrice = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("SecondaryPrice"))
                            .SetUseContainerStock = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("UseContainerStock"))
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Van_GetByLocationID](ByVal LocationID As Integer) As Van
                _database.ClearParameter()
                _database.AddParameter("@LocationID", LocationID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Van_GetByLocationID")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oVan As New Van
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetRegistration = dt.Rows(0).Item("Registration")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .InsuranceDue = CDate(dt.Rows(0).Item("InsuranceDue"))
                            .MOTDue = CDate(dt.Rows(0).Item("MOTDue"))
                            .TaxDue = CDate(dt.Rows(0).Item("TaxDue"))
                            .ServiceDue = CDate(dt.Rows(0).Item("ServiceDue"))
                            .SetMileageLimit = dt.Rows(0).Item("MileageLimit")
                            .SetPeriodValue = dt.Rows(0).Item("PeriodValue")
                            .SetPeriodType = dt.Rows(0).Item("PeriodType")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetPreferredSupplierID = dt.Rows(0).Item("PreferredSupplierID")
                            .SetExcludeFromAutoReplenishment = dt.Rows(0).Item("ExcludeFromAutoReplenishment")
                            .SetUseContainerStock = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("UseContainerStock"))
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Van_GetByLocationID](ByVal LocationID As Integer, ByVal trans As SqlClient.SqlTransaction) As Van

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Van_GetByLocationID"
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
                        Dim oVan As New Van
                        With oVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .SetRegistration = dt.Rows(0).Item("Registration")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .InsuranceDue = CDate(dt.Rows(0).Item("InsuranceDue"))
                            .MOTDue = CDate(dt.Rows(0).Item("MOTDue"))
                            .TaxDue = CDate(dt.Rows(0).Item("TaxDue"))
                            .ServiceDue = CDate(dt.Rows(0).Item("ServiceDue"))
                            .SetMileageLimit = dt.Rows(0).Item("MileageLimit")
                            .SetPeriodValue = dt.Rows(0).Item("PeriodValue")
                            .SetPeriodType = dt.Rows(0).Item("PeriodType")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetPreferredSupplierID = dt.Rows(0).Item("PreferredSupplierID")
                            .SetExcludeFromAutoReplenishment = dt.Rows(0).Item("ExcludeFromAutoReplenishment")
                            .SetUseContainerStock = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("UseContainerStock"))
                        End With
                        oVan.Exists = True
                        Return oVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If

            End Function

            Public Function Check_Unique_Registration(ByVal Registration As String, ByVal ID As Integer) As Boolean
                Dim NumberOfVans As Integer = 0

                For Each row As DataRow In Van_GetAll(True).Table.Rows
                    If Not row.Item("VanID") = ID Then
                        If row.Item("Registration") = Registration Then
                            NumberOfVans += 1
                        End If
                    End If
                Next

                'NumberOfVans = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(VanID) as 'NumberOfVans' " & _
                '"FROM tblVan WHERE Registration = '" & Registration & "' AND vanid <> " & ID, False))

                If NumberOfVans = 0 Then
                    Return True
                Else
                    Return False
                End If
            End Function

            Public Function Van_GetAll_AllLocations() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Van_GetAll_AllLocations")
                dt.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
                Return New DataView(dt)

            End Function

            Public Function [Van_GetAll](ByVal Grouped As Boolean) As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Van_GetAll")

                If Grouped Then
                    Dim returnDT As New DataTable

                    For Each col As DataColumn In dt.Columns
                        returnDT.Columns.Add(New DataColumn(col.ColumnName, col.DataType))
                    Next

                    For Each row As DataRow In dt.Rows
                        Dim found As Boolean = False
                        Dim registrationToFind As String = Entity.Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(0).Trim

                        For Each groupedVan As DataRow In returnDT.Rows
                            If Entity.Sys.Helper.MakeStringValid(groupedVan.Item("Registration")).Split("*")(0).Trim = registrationToFind Then
                                found = True
                                Exit For
                            End If
                        Next

                        If Not found Then
                            Dim rowToAdd As DataRow = Nothing

                            For Each rowForRegistration As DataRow In dt.Rows
                                If Entity.Sys.Helper.MakeStringValid(rowForRegistration.Item("Registration")).Split("*")(0).Trim = registrationToFind Then
                                    If rowToAdd Is Nothing Then
                                        rowToAdd = rowForRegistration
                                    Else
                                        If rowForRegistration.Item("VanID") < rowToAdd.Item("VanID") Then
                                            rowToAdd = rowForRegistration
                                        End If
                                    End If
                                End If
                            Next

                            If Not rowToAdd Is Nothing Then
                                Dim r As DataRow = returnDT.NewRow
                                For Each col As DataColumn In returnDT.Columns
                                    If col.ColumnName = "Registration" Then
                                        r(col.ColumnName) = registrationToFind
                                    Else
                                        r(col.ColumnName) = rowToAdd(col.ColumnName)
                                    End If
                                Next
                                returnDT.Rows.Add(r)
                            End If
                        End If
                    Next

                    returnDT.Columns.Remove("InsuranceDue")
                    returnDT.Columns.Remove("MOTDue")
                    returnDT.Columns.Remove("ServiceDue")
                    returnDT.Columns.Remove("MileageLimit")
                    returnDT.Columns.Remove("PeriodValue")
                    returnDT.Columns.Remove("PeriodType")

                    returnDT.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
                    Return New DataView(returnDT)
                Else
                    dt.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
                    Return New DataView(dt)
                End If
            End Function

            Public Function [Van_GetAll_incDeleted](ByVal Grouped As Boolean) As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Van_GetAll_incDeleted")

                If Grouped Then
                    Dim returnDT As New DataTable

                    For Each col As DataColumn In dt.Columns
                        returnDT.Columns.Add(New DataColumn(col.ColumnName, col.DataType))
                    Next

                    For Each row As DataRow In dt.Rows
                        Dim found As Boolean = False
                        Dim registrationToFind As String = Entity.Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(0).Trim

                        For Each groupedVan As DataRow In returnDT.Rows
                            If Entity.Sys.Helper.MakeStringValid(groupedVan.Item("Registration")).Split("*")(0).Trim = registrationToFind Then
                                found = True
                                Exit For
                            End If
                        Next

                        If Not found Then
                            Dim rowToAdd As DataRow = Nothing

                            For Each rowForRegistration As DataRow In dt.Rows
                                If Entity.Sys.Helper.MakeStringValid(rowForRegistration.Item("Registration")).Split("*")(0).Trim = registrationToFind Then
                                    If rowToAdd Is Nothing Then
                                        rowToAdd = rowForRegistration
                                    Else
                                        If rowForRegistration.Item("VanID") < rowToAdd.Item("VanID") Then
                                            rowToAdd = rowForRegistration
                                        End If
                                    End If
                                End If
                            Next

                            If Not rowToAdd Is Nothing Then
                                Dim r As DataRow = returnDT.NewRow
                                For Each col As DataColumn In returnDT.Columns
                                    If col.ColumnName = "Registration" Then
                                        r(col.ColumnName) = registrationToFind
                                    Else
                                        r(col.ColumnName) = rowToAdd(col.ColumnName)
                                    End If
                                Next
                                returnDT.Rows.Add(r)
                            End If
                        End If
                    Next

                    returnDT.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
                    Return New DataView(returnDT)
                Else
                    dt.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
                    Return New DataView(dt)
                End If
            End Function

            Public Function [Van_GetAll](ByVal Grouped As Boolean, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Van_GetAll"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Grouped Then
                    Dim returnDT As New DataTable

                    For Each col As DataColumn In dt.Columns
                        returnDT.Columns.Add(New DataColumn(col.ColumnName, col.DataType))
                    Next

                    For Each row As DataRow In dt.Rows
                        Dim found As Boolean = False
                        Dim registrationToFind As String = Entity.Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(0).Trim

                        For Each groupedVan As DataRow In returnDT.Rows
                            If Entity.Sys.Helper.MakeStringValid(groupedVan.Item("Registration")).Split("*")(0).Trim = registrationToFind Then
                                found = True
                                Exit For
                            End If
                        Next

                        If Not found Then
                            Dim rowToAdd As DataRow = Nothing

                            For Each rowForRegistration As DataRow In dt.Rows
                                If Entity.Sys.Helper.MakeStringValid(rowForRegistration.Item("Registration")).Split("*")(0).Trim = registrationToFind Then
                                    If rowToAdd Is Nothing Then
                                        rowToAdd = rowForRegistration
                                    Else
                                        If rowForRegistration.Item("VanID") < rowToAdd.Item("VanID") Then
                                            rowToAdd = rowForRegistration
                                        End If
                                    End If
                                End If
                            Next

                            If Not rowToAdd Is Nothing Then
                                Dim r As DataRow = returnDT.NewRow
                                For Each col As DataColumn In returnDT.Columns
                                    If col.ColumnName = "Registration" Then
                                        r(col.ColumnName) = registrationToFind
                                    Else
                                        r(col.ColumnName) = rowToAdd(col.ColumnName)
                                    End If
                                Next
                                returnDT.Rows.Add(r)
                            End If
                        End If
                    Next

                    returnDT.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
                    Return New DataView(returnDT)
                Else
                    dt.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
                    Return New DataView(dt)
                End If
            End Function

            Public Function [Van_Search](ByVal Criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", Criteria, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Van_SearchList")

                Dim returnDT As New DataTable

                For Each col As DataColumn In dt.Columns
                    returnDT.Columns.Add(New DataColumn(col.ColumnName, col.DataType))
                Next

                For Each row As DataRow In dt.Rows
                    Dim found As Boolean = False
                    Dim registrationToFind As String = Entity.Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(0).Trim

                    For Each groupedVan As DataRow In returnDT.Rows
                        If Entity.Sys.Helper.MakeStringValid(groupedVan.Item("Registration")).Split("*")(0).Trim = registrationToFind Then
                            found = True
                            Exit For
                        End If
                    Next

                    If Not found Then
                        Dim rowToAdd As DataRow = Nothing

                        For Each rowForRegistration As DataRow In dt.Rows
                            If Entity.Sys.Helper.MakeStringValid(rowForRegistration.Item("Registration")).Split("*")(0).Trim = registrationToFind Then
                                If rowToAdd Is Nothing Then
                                    rowToAdd = rowForRegistration
                                Else
                                    If rowForRegistration.Item("VanID") < rowToAdd.Item("VanID") Then
                                        rowToAdd = rowForRegistration
                                    End If
                                End If
                            End If
                        Next

                        If Not rowToAdd Is Nothing Then
                            Dim r As DataRow = returnDT.NewRow
                            For Each col As DataColumn In returnDT.Columns
                                If col.ColumnName = "Registration" Then
                                    r(col.ColumnName) = registrationToFind
                                Else
                                    r(col.ColumnName) = rowToAdd(col.ColumnName)
                                End If
                            Next
                            returnDT.Rows.Add(r)
                        End If
                    End If
                Next

                returnDT.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
                Return New DataView(returnDT)
            End Function

            Public Function [Insert](ByVal oVan As Van, ByVal CopiedVanReg As String, ByVal LocationsDataView As DataView, ByVal InsertFromWarehouses As Boolean) As Van
                If InsertFromWarehouses Then
                    _database.ClearParameter()
                    AddVanParametersToCommand(oVan)
                    oVan.SetVanID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Van_Insert"))
                    oVan.Exists = True

                    Dim oLocation As New Entity.Locationss.Locations
                    oLocation.SetDeleted = False
                    oLocation.SetVanID = oVan.VanID
                    oLocation.SetWarehouseID = Nothing
                    DB.Location.Insert(oLocation)

                    Return oVan
                Else
                    Dim returnVan As Van = Nothing
                    Dim registrationEntered As String = oVan.Registration

                    Dim copiedVanLocations As DataTable

                    If CopiedVanReg.Length > 0 Then
                        copiedVanLocations = DB.Location.Locations_Get_ForVanReg(CopiedVanReg).Table
                    End If

                    For Each row As DataRow In DB.Warehouse.Warehouse_GetAll.Table.Rows
                        oVan.SetRegistration = registrationEntered.Trim & " * " & Sys.Helper.MakeStringValid(row.Item("Name")).Trim

                        _database.ClearParameter()
                        AddVanParametersToCommand(oVan)

                        oVan.SetVanID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Van_Insert"))
                        oVan.Exists = True

                        Dim oLocation As New Entity.Locationss.Locations
                        oLocation.SetDeleted = False
                        oLocation.SetVanID = oVan.VanID
                        oLocation.SetWarehouseID = Nothing
                        DB.Location.Insert(oLocation)

                        For Each warehouseRow As DataRow In LocationsDataView.Table.Rows
                            If warehouseRow.Item("WarehouseID") = row.Item("WarehouseID") Then
                                If Not warehouseRow.Item("Tick") Then
                                    DB.Location.Delete(oLocation.LocationID)
                                End If
                            End If
                        Next

                        If CopiedVanReg.Length > 0 Then
                            Dim drLoc As DataRow() = copiedVanLocations.Select("Registration='" & CopiedVanReg.Trim & " * " & Sys.Helper.MakeStringValid(row.Item("Name")).Trim & "'")
                            If drLoc.Length > 0 Then
                                For Each l As DataRow In drLoc
                                    Dim lParts As DataTable = DB.Part.PartLocations_GetForVan(l("LocationID")).Table
                                    For Each p As DataRow In lParts.Rows
                                        _database.ClearParameter()
                                        _database.AddParameter("@PartID", p("PartID"), True)
                                        _database.AddParameter("@LocationID", oLocation.LocationID, True)
                                        _database.AddParameter("@MinQty", p("MinQty"), True)
                                        _database.AddParameter("@RecQty", p("RecQty"), True)

                                        _database.ExecuteSP_NO_Return("PartLocations_Insert")

                                        Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                                        oPartTransaction.SetLocationID = oLocation.LocationID 'row.Item("LocationID")
                                        oPartTransaction.SetAmount = 0
                                        oPartTransaction.SetPartID = p("PartID") 'row.Item("PartID")
                                        oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockAdjustment)
                                        DB.PartTransaction.Insert(oPartTransaction)
                                    Next
                                Next l
                            End If
                        End If

                        If returnVan Is Nothing Then
                            returnVan = oVan
                        End If
                    Next row

                    Return returnVan
                End If
            End Function

            Public Sub [Update](ByVal oVan As Van, ByVal LocationsDataView As DataView, ByVal UpdateFromWarehouses As Boolean)
                If UpdateFromWarehouses Then
                    _database.ClearParameter()
                    _database.AddParameter("@VanID", oVan.VanID, True)
                    AddVanParametersToCommand(oVan)
                    _database.ExecuteSP_NO_Return("Van_Update")

                    For Each locationRow As DataRow In LocationsDataView.Table.Rows
                        If oVan.VanID = locationRow.Item("VanID") Then
                            DB.Location.Update(locationRow.Item("LocationID"), Not locationRow.Item("Tick"))
                        End If
                    Next
                Else
                    Dim registrationEntered As String = oVan.Registration

                    Dim registration As String = Van_Get(oVan.VanID).Registration.Split("*")(0).Trim

                    For Each row As DataRow In Van_GetAll_AllLocations.Table.Rows
                        If Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(0).Trim = registration Then
                            oVan.SetRegistration = registrationEntered.Trim & " * " & Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(1).Trim

                            _database.ClearParameter()
                            _database.AddParameter("@VanID", row.Item("VanID"), True)
                            AddVanParametersToCommand(oVan)
                            _database.ExecuteSP_NO_Return("Van_Update")
                        End If
                    Next

                    For Each row As DataRow In LocationsDataView.Table.Rows
                        DB.Location.Update(row.Item("LocationID"), Not row.Item("Tick"))
                    Next
                End If
            End Sub

            Private Sub AddVanParametersToCommand(ByRef oVan As Van)
                With _database
                    .AddParameter("@Registration", oVan.Registration, True)
                    .AddParameter("@Notes", oVan.Notes, True)
                    .AddParameter("@InsuranceDue", Sys.Helper.InsertDateIntoDb(oVan.InsuranceDue), True)
                    .AddParameter("@MOTDue", Sys.Helper.InsertDateIntoDb(oVan.MOTDue), True)
                    .AddParameter("@TaxDue", Sys.Helper.InsertDateIntoDb(oVan.TaxDue), True)
                    .AddParameter("@ServiceDue", Sys.Helper.InsertDateIntoDb(oVan.InsuranceDue), True)
                    .AddParameter("@MileageLimit", oVan.MileageLimit, True)
                    .AddParameter("@PeriodValue", oVan.PeriodValue, True)
                    .AddParameter("@PeriodType", oVan.PeriodType, True)
                    .AddParameter("@PreferredSupplierID", oVan.PreferredSupplierID, True)
                    .AddParameter("@ExcludeFromAutoReplenishment", oVan.ExcludeFromAutoReplenishment, True)
                    .AddParameter("@SecondaryPrice", oVan.SecondaryPrice, True)
                    .AddParameter("@UseContainerStock", oVan.UseContainerStock, True)
                End With
            End Sub

            Public Function Van_GetWithProduct(ByVal ProductID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Van_GetWithProduct"
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

            Public Function Van_GetWithProduct(ByVal ProductID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ProductID", ProductID)

                'Get the datatable from the database store in dt
                Return New DataView(_database.ExecuteSP_DataTable("Van_GetWithProduct"))
            End Function

            Public Function Van_GetWithPart(ByVal PartID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID)

                'Get the datatable from the database store in dt
                Return New DataView(_database.ExecuteSP_DataTable("Van_GetWithPart"))
            End Function

            Public Function Van_GetWithPart(ByVal PartID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Van_GetWithPart"
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

            Public Function Van_GetAll_For_Warehouse(ByVal WarehouseID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@WarehouseID", WarehouseID)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Van_GetAll_For_Warehouse")
                dt.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
                Return New DataView(dt)
            End Function

            Public Function Van_GetDepartment(ByVal VanID As Integer) As String
                _database.ClearParameter()
                _database.AddParameter("@VanID", VanID)

                'Get the datatable from the database store in dt
                Return _database.ExecuteScalar("SELECT tblEngineer.Department FROM tblVan INNER JOIN tblEngineerVan ON tblVan.VanID = tblEngineerVan.VanID INNER JOIN tblEngineer ON tblEngineerVan.EngineerID = tblEngineer.EngineerID WHERE (tblVan.VanID = @VanID) AND (tblVan.Deleted = 0) AND (tblEngineerVan.Deleted = 0)")
            End Function

            'Public Sub Van_ClearObject(ByVal oVan As Entity.Vans.Van)
            '    oVan.SetDeleted = Nothing
            '    oVan.s()
            'End Sub

            Public Function CopyVan(ByVal oVan As Van, ByVal CopiedVanReg As String, ByVal LocationsDataView As DataView, ByVal InsertFromWarehouses As Boolean) As Van
                If InsertFromWarehouses Then
                    _database.ClearParameter()
                    AddVanParametersToCommand(oVan)
                    oVan.SetVanID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Van_Insert"))
                    oVan.Exists = True

                    Dim oLocation As New Entity.Locationss.Locations
                    oLocation.SetDeleted = False
                    oLocation.SetVanID = oVan.VanID
                    oLocation.SetWarehouseID = Nothing
                    DB.Location.Insert(oLocation)

                    Return oVan
                Else
                    Dim returnVan As Van = Nothing
                    Dim registrationEntered As String = oVan.Registration

                    Dim copiedVanLocations As DataTable

                    For Each row As DataRow In DB.Warehouse.Warehouse_GetAll.Table.Rows
                        oVan.SetRegistration = registrationEntered.Trim & " * " & Sys.Helper.MakeStringValid(row.Item("Name")).Trim

                        _database.ClearParameter()
                        AddVanParametersToCommand(oVan)

                        oVan.SetVanID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Van_Insert"))
                        oVan.Exists = True

                        Dim oLocation As New Entity.Locationss.Locations
                        oLocation.SetDeleted = False
                        oLocation.SetVanID = oVan.VanID
                        oLocation.SetWarehouseID = Nothing
                        DB.Location.Insert(oLocation)

                        For Each warehouseRow As DataRow In LocationsDataView.Table.Rows
                            If warehouseRow.Item("WarehouseID") = row.Item("WarehouseID") Then
                                If Not warehouseRow.Item("Tick") Then
                                    DB.Location.Delete(oLocation.LocationID)
                                End If
                            End If
                        Next

                        If CopiedVanReg.Length > 0 Then
                            copiedVanLocations = DB.Location.Locations_Get_ForVanReg(CopiedVanReg).Table
                        End If

                        If CopiedVanReg.Length > 0 Then
                            Dim drLoc As DataRow() = copiedVanLocations.Select("Registration='" & CopiedVanReg.Trim & " * " & Sys.Helper.MakeStringValid(row.Item("Name")).Trim & "'")
                            If drLoc.Length > 0 Then
                                For Each l As DataRow In drLoc
                                    If Sys.Helper.MakeBooleanValid(l("Deleted")) = True Then
                                    Else
                                        Dim lParts As DataTable = DB.Part.PartLocations_GetForVan2(l("LocationID")).Table
                                        For Each p As DataRow In lParts.Rows
                                            _database.ClearParameter()
                                            _database.AddParameter("@PartID", p("PartID"), True)
                                            _database.AddParameter("@LocationID", oLocation.LocationID, True)
                                            _database.AddParameter("@MinQty", p("Min"), True)
                                            _database.AddParameter("@RecQty", p("Max"), True)

                                            _database.ExecuteSP_NO_Return("PartLocations_Insert")

                                            Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                                            oPartTransaction.SetLocationID = oLocation.LocationID 'row.Item("LocationID")
                                            oPartTransaction.SetAmount = 0
                                            oPartTransaction.SetPartID = p("PartID") 'row.Item("PartID")
                                            oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockAdjustment)
                                            DB.PartTransaction.Insert(oPartTransaction)
                                        Next
                                    End If
                                Next l
                            End If
                        End If

                        If returnVan Is Nothing Then
                            returnVan = oVan
                        End If
                    Next row

                    Return returnVan
                End If
            End Function

            Public Function MergeVan(ByVal oVanToMergeFrom As Van, ByVal CurrentVan As Van) As Van

                Dim returnVan As Van = CurrentVan

                Dim copiedVanLocations As DataTable

                For Each row As DataRow In DB.Warehouse.Warehouse_GetAll.Table.Rows

                    'Dim oLocation As New Entity.Locationss.Locations
                    'oLocation.SetDeleted = False
                    'oLocation.SetVanID = CurrentVan.VanID
                    'oLocation.SetWarehouseID = Nothing
                    'DB.Location.Insert(oLocation)

                    Dim LocationsFromDonorVan = DB.Location.Locations_Get_ForVanReg(oVanToMergeFrom.Registration).Table

                    Dim LocationsFromCurrentVan = DB.Location.Locations_Get_ForVanReg(CurrentVan.Registration).Table

                    Dim i As Integer = 0
                    Dim drLoc As DataRow() = LocationsFromDonorVan.Select("Registration='" & oVanToMergeFrom.Registration.Split("*")(0).Trim & " * " & Sys.Helper.MakeStringValid(row.Item("Name")).Trim & "'") '' from van
                    Dim drLocto As DataRow() = LocationsFromCurrentVan.Select("Registration='" & CurrentVan.Registration.Split("*")(0).Trim & " * " & Sys.Helper.MakeStringValid(row.Item("Name")).Trim & "'") '' to van
                    If drLoc.Length > 0 Then
                        For Each l As DataRow In drLoc  ' GAsway, Vokera ,Alpha Etc,
                            If Sys.Helper.MakeBooleanValid(l("Deleted")) = True Or (drLocto.Length = 0) Then
                            Else
                                Dim lParts As DataTable = DB.Part.PartLocations_GetForVan2(l("LocationID")).Table   '  gets parts list for from VAN
                                Dim lPartsto As DataTable = DB.Part.PartLocations_GetForVan2(drLocto(i)("LocationID")).Table ' Gets parts of the 'to' van  6

                                For Each p As DataRow In lParts.Rows
                                    If lPartsto.Select("PartID=" & p("PartID")).Length > 0 Then ' just change min /max
                                        _database.ClearParameter()
                                        _database.AddParameter("@PartLocationID", p("PartLocationID"), True)
                                        _database.AddParameter("@MinQty", p("Min"), True)
                                        _database.AddParameter("@MaxQty", p("Max"), True)

                                        _database.ExecuteSP_NO_Return("PartLocations_UpdateMinMax")
                                    Else   ' insert a new line

                                        _database.ClearParameter()
                                        _database.AddParameter("@PartID", p("PartID"), True)
                                        _database.AddParameter("@LocationID", drLocto(i)("LocationID"), True)
                                        _database.AddParameter("@MinQty", p("Min"), True)
                                        _database.AddParameter("@RecQty", p("Max"), True)

                                        _database.ExecuteSP_NO_Return("PartLocations_Insert")

                                        Dim stock As Integer = DB.Part.PartLocation_GetStockLevel(drLocto(i)("LocationID"), p("PartID"))

                                        If stock <> 0 Then ' but what if its not a location but stocked on the van?

                                            Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                                            oPartTransaction.SetLocationID = drLocto(i)("LocationID")
                                            oPartTransaction.SetAmount = stock
                                            oPartTransaction.SetPartID = p("PartID")
                                            oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockAdjustment)
                                            DB.PartTransaction.Insert(oPartTransaction)
                                        Else

                                            Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                                            oPartTransaction.SetLocationID = drLocto(i)("LocationID")
                                            oPartTransaction.SetAmount = 0
                                            oPartTransaction.SetPartID = p("PartID")
                                            oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockAdjustment)
                                            DB.PartTransaction.Insert(oPartTransaction)
                                        End If

                                    End If
                                Next
                            End If
                            i = i + 1
                        Next l
                    End If
                Next

                Return returnVan

            End Function

#End Region

        End Class

    End Namespace

End Namespace