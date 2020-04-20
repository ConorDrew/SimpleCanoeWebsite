Namespace Entity

    Namespace EngineerVisitPartProductAllocateds

        Public Class EngineerVisitPartProductAllocatedSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit](ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@OrderLocationSupplierEnumValue", Entity.Sys.Enums.LocationType.Supplier, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsAllocated_GetAll_For_Engineer_Visit2")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblEngineerVisitPartAndProductAllocated.ToString
                Return New DataView(dt)
            End Function

            Public Function [EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit](ByVal EngineerVisitID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "EngineerVisitPartsAndProductsAllocated_GetAll_For_Engineer_Visit"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@EngineerVisitID", EngineerVisitID)
                Command.Parameters.AddWithValue("@OrderLocationSupplierEnumValue", Entity.Sys.Enums.LocationType.Supplier)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblEngineerVisitPartAndProductAllocated.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitPartAllocated_MoveVisit(ByVal OldEngineerVisitID As Integer, ByVal NewEngineerVisitID As Integer) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@OldEngineerVisitID", OldEngineerVisitID, True)
                _database.AddParameter("@NewEngineerVisitID", NewEngineerVisitID, True)
                Return _database.ExecuteSP_DataTable("EngineerVisitPartAllocated_MoveVisit")
            End Function

            Public Sub Insert(ByVal PartsAndProducts As DataView, ByVal EngineerVisitID As Integer, ByVal JobID As Integer, ByVal trans As SqlClient.SqlTransaction)

                If Not PartsAndProducts.Table Is Nothing Then
                    'THIS IS VERY CONFUSING BUT BASICALLY I SPLITTING IT IN TWO TABLES ORDER / NOT ORDER
                    'ALP

                    Dim PartProductToOrder As New DataTable
                    PartProductToOrder.Columns.Add("Type")
                    PartProductToOrder.Columns.Add("ID")
                    PartProductToOrder.Columns.Add("EngineerVisitID")
                    PartProductToOrder.Columns.Add("PartProductID")
                    PartProductToOrder.Columns.Add("Name")
                    PartProductToOrder.Columns.Add("Number")
                    PartProductToOrder.Columns.Add("Quantity")
                    PartProductToOrder.Columns.Add("OrderItemID")
                    PartProductToOrder.Columns.Add("OrderLocationTypeID")
                    PartProductToOrder.Columns.Add("SellPrice")

                    Dim PartProductNOTToOrder As New DataTable
                    PartProductNOTToOrder.Columns.Add("Type")
                    PartProductNOTToOrder.Columns.Add("ID")
                    PartProductNOTToOrder.Columns.Add("EngineerVisitID")
                    PartProductNOTToOrder.Columns.Add("PartProductID")
                    PartProductNOTToOrder.Columns.Add("Name")
                    PartProductNOTToOrder.Columns.Add("Number")
                    PartProductNOTToOrder.Columns.Add("Quantity")
                    PartProductNOTToOrder.Columns.Add("OrderItemID")
                    PartProductNOTToOrder.Columns.Add("OrderLocationTypeID")
                    PartProductNOTToOrder.Columns.Add("SellPrice")

                    Dim msgStr As String = ""
                    For Each row As DataRow In PartsAndProducts.Table.Rows
                        If row.Item("OrderItemID") = 0 Then
                            msgStr += " * " & row.Item("Name") & ", " & row.Item("Number") & ", " & row.Item("Quantity") & vbCrLf
                            Dim ppr As DataRow
                            ppr = PartProductToOrder.NewRow
                            ppr("Type") = row.Item("Type")
                            ppr("ID") = row.Item("ID")
                            ppr("EngineerVisitID") = EngineerVisitID
                            ppr("PartProductID") = row.Item("PartProductID")
                            ppr("Name") = row.Item("Name")
                            ppr("Number") = row.Item("Number")
                            ppr("Quantity") = row.Item("Quantity")
                            ppr("OrderItemID") = row.Item("OrderItemID")
                            ppr("OrderLocationTypeID") = row.Item("OrderLocationTypeID")
                            ppr("SellPrice") = row.Item("SellPrice")
                            PartProductToOrder.Rows.Add(ppr)
                        Else
                            Dim ppr As DataRow
                            ppr = PartProductNOTToOrder.NewRow
                            ppr("Type") = row.Item("Type")
                            ppr("ID") = row.Item("ID")
                            ppr("EngineerVisitID") = EngineerVisitID
                            ppr("PartProductID") = row.Item("PartProductID")
                            ppr("Name") = row.Item("Name")
                            ppr("Number") = row.Item("Number")
                            ppr("Quantity") = row.Item("Quantity")
                            ppr("OrderItemID") = row.Item("OrderItemID")
                            ppr("OrderLocationTypeID") = row.Item("OrderLocationTypeID")
                            ppr("SellPrice") = row.Item("SellPrice")
                            PartProductNOTToOrder.Rows.Add(ppr)
                        End If
                    Next

                    'DO THEY WANT TO ORDER NOW?
                    If msgStr.Length > 0 Then
                        If MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: " & vbCrLf &
                                        msgStr & vbCrLf & " Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                            ShowForm(GetType(FRMConvertToAnOrder), True, New Object() {CInt(Entity.Sys.Enums.OrderType.Job), JobID, New DataView(PartProductToOrder), 0, EngineerVisitID, trans})

                        End If
                    End If

                    'DELETE EVERYTHING

                    Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                    Command.CommandText = "EngineerVisitPartsAndProductsAllocated_Delete"
                    Command.CommandType = CommandType.StoredProcedure
                    Command.Transaction = trans
                    Command.Connection = trans.Connection

                    Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID))
                    Command.ExecuteNonQuery()

                    'CYCLE THROUGH NOT ORDERS
                    For Each row As DataRow In PartProductNOTToOrder.Rows

                        InsertOne(EngineerVisitID, row.Item("Type"), row.Item("Quantity"),
                             row.Item("OrderItemID"), row.Item("PartProductID"), row.Item("OrderLocationTypeID"), trans)

                    Next

                    'CYCLE THROUGH ORDERS
                    For Each row As DataRow In PartProductToOrder.Rows

                        row.AcceptChanges()
                        If IsDBNull(row.Item("Quantity")) Then
                            row.Item("Quantity") = row.Item("QuantityToOrder")
                        End If

                        InsertOne(EngineerVisitID, row.Item("Type"), row.Item("Quantity"),
                             row.Item("OrderItemID"), row.Item("PartProductID"),
                             Entity.Sys.Helper.MakeIntegerValid(row.Item("OrderLocationTypeID")), trans)

                    Next

                End If
            End Sub

            Public Sub NewInsert(ByVal PartsAndProducts As DataView, ByVal EngineerVisitID As Integer, ByVal JobID As Integer, ByVal trans As SqlClient.SqlTransaction)

                If Not PartsAndProducts.Table Is Nothing Then

                    ''DELETE EVERYTHING

                    'Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                    'Command.CommandText = "EngineerVisitPartsAndProductsAllocated_Delete"
                    'Command.CommandType = CommandType.StoredProcedure
                    'Command.Transaction = trans
                    'Command.Connection = trans.Connection

                    'Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID))
                    'Command.ExecuteNonQuery()

                    'CYCLE THROUGH NOT ORDERS
                    For Each row As DataRow In PartsAndProducts.Table.Rows
                        Dim allocationID As Integer = InsertOne(EngineerVisitID, row.Item("Type"), row.Item("Quantity"), 0, row.Item("PartProductID"), 0, trans)
                        row.Item("ID") = allocationID
                        row.AcceptChanges()
                    Next

                End If
            End Sub

            Public Sub SplitToOrder(ByVal PartsAndProducts As DataView, ByVal EngineerVisitID As Integer, ByVal JobID As Integer)

                If Not PartsAndProducts.Table Is Nothing Then
                    'THIS IS VERY CONFUSING BUT BASICALLY I SPLITTING IT IN TWO TABLES ORDER / NOT ORDER
                    'ALP

                    Dim PartProductToOrder As New DataTable
                    PartProductToOrder.Columns.Add("Type")
                    PartProductToOrder.Columns.Add("ID")
                    PartProductToOrder.Columns.Add("EngineerVisitID")
                    PartProductToOrder.Columns.Add("PartProductID")
                    PartProductToOrder.Columns.Add("Name")
                    PartProductToOrder.Columns.Add("Number")
                    PartProductToOrder.Columns.Add("Quantity")
                    PartProductToOrder.Columns.Add("OrderItemID")
                    PartProductToOrder.Columns.Add("OrderLocationTypeID")
                    PartProductToOrder.Columns.Add("SellPrice")

                    Dim PartProductNOTToOrder As New DataTable
                    PartProductNOTToOrder.Columns.Add("Type")
                    PartProductNOTToOrder.Columns.Add("ID")
                    PartProductNOTToOrder.Columns.Add("EngineerVisitID")
                    PartProductNOTToOrder.Columns.Add("PartProductID")
                    PartProductNOTToOrder.Columns.Add("Name")
                    PartProductNOTToOrder.Columns.Add("Number")
                    PartProductNOTToOrder.Columns.Add("Quantity")
                    PartProductNOTToOrder.Columns.Add("OrderItemID")
                    PartProductNOTToOrder.Columns.Add("OrderLocationTypeID")
                    PartProductNOTToOrder.Columns.Add("SellPrice")

                    Dim msgStr As String = ""
                    For Each row As DataRow In PartsAndProducts.Table.Rows
                        If row.Item("OrderItemID") = 0 Then
                            msgStr += " * " & row.Item("Name") & ", " & row.Item("Number") & ", " & row.Item("Quantity") & vbCrLf
                            Dim ppr As DataRow
                            ppr = PartProductToOrder.NewRow
                            ppr("Type") = row.Item("Type")
                            ppr("ID") = row.Item("ID")
                            ppr("EngineerVisitID") = EngineerVisitID
                            ppr("PartProductID") = row.Item("PartProductID")
                            ppr("Name") = row.Item("Name")
                            ppr("Number") = row.Item("Number")
                            ppr("Quantity") = row.Item("Quantity")
                            ppr("OrderItemID") = row.Item("OrderItemID")
                            ppr("OrderLocationTypeID") = row.Item("OrderLocationTypeID")
                            ppr("SellPrice") = row.Item("SellPrice")
                            PartProductToOrder.Rows.Add(ppr)
                        Else
                            Dim ppr As DataRow
                            ppr = PartProductNOTToOrder.NewRow
                            ppr("Type") = row.Item("Type")
                            ppr("ID") = row.Item("ID")
                            ppr("EngineerVisitID") = EngineerVisitID
                            ppr("PartProductID") = row.Item("PartProductID")
                            ppr("Name") = row.Item("Name")
                            ppr("Number") = row.Item("Number")
                            ppr("Quantity") = row.Item("Quantity")
                            ppr("OrderItemID") = row.Item("OrderItemID")
                            ppr("OrderLocationTypeID") = row.Item("OrderLocationTypeID")
                            ppr("SellPrice") = row.Item("SellPrice")
                            PartProductNOTToOrder.Rows.Add(ppr)
                        End If
                    Next

                    'DO THEY WANT TO ORDER NOW?
                    If msgStr.Length > 0 Then
                        If MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: " & vbCrLf &
                                        msgStr & vbCrLf & " Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                            ShowForm(GetType(FRMConvertToAnOrder), True, New Object() {CInt(Entity.Sys.Enums.OrderType.Job), JobID, New DataView(PartProductToOrder), 0, EngineerVisitID, True})

                        End If
                    End If

                End If
            End Sub

            Public Sub Insert(ByVal PartsAndProducts As DataView, ByVal EngineerVisitID As Integer, ByVal JobID As Integer)

                If Not PartsAndProducts.Table Is Nothing Then
                    'THIS IS VERY CONFUSING BUT BASICALLY I SPLITTING IT IN TWO TABLES ORDER / NOT ORDER
                    'ALP

                    Dim PartProductToOrder As New DataTable
                    PartProductToOrder.Columns.Add("Type")
                    PartProductToOrder.Columns.Add("ID")
                    PartProductToOrder.Columns.Add("EngineerVisitID")
                    PartProductToOrder.Columns.Add("PartProductID")
                    PartProductToOrder.Columns.Add("Name")
                    PartProductToOrder.Columns.Add("Number")
                    PartProductToOrder.Columns.Add("Quantity")
                    PartProductToOrder.Columns.Add("OrderItemID")
                    PartProductToOrder.Columns.Add("OrderLocationTypeID")
                    PartProductToOrder.Columns.Add("SellPrice")

                    Dim PartProductNOTToOrder As New DataTable
                    PartProductNOTToOrder.Columns.Add("Type")
                    PartProductNOTToOrder.Columns.Add("ID")
                    PartProductNOTToOrder.Columns.Add("EngineerVisitID")
                    PartProductNOTToOrder.Columns.Add("PartProductID")
                    PartProductNOTToOrder.Columns.Add("Name")
                    PartProductNOTToOrder.Columns.Add("Number")
                    PartProductNOTToOrder.Columns.Add("Quantity")
                    PartProductNOTToOrder.Columns.Add("OrderItemID")
                    PartProductNOTToOrder.Columns.Add("OrderLocationTypeID")
                    PartProductNOTToOrder.Columns.Add("SellPrice")

                    Dim msgStr As String = ""
                    For Each row As DataRow In PartsAndProducts.Table.Rows
                        If row.Item("OrderItemID") = 0 Then
                            msgStr += " * " & row.Item("Name") & ", " & row.Item("Number") & ", " & row.Item("Quantity") & vbCrLf
                            Dim ppr As DataRow
                            ppr = PartProductToOrder.NewRow
                            ppr("Type") = row.Item("Type")
                            ppr("ID") = row.Item("ID")
                            ppr("EngineerVisitID") = EngineerVisitID
                            ppr("PartProductID") = row.Item("PartProductID")
                            ppr("Name") = row.Item("Name")
                            ppr("Number") = row.Item("Number")
                            ppr("Quantity") = row.Item("Quantity")
                            ppr("OrderItemID") = row.Item("OrderItemID")
                            ppr("OrderLocationTypeID") = row.Item("OrderLocationTypeID")
                            ppr("SellPrice") = row.Item("SellPrice")
                            PartProductToOrder.Rows.Add(ppr)
                        Else
                            Dim ppr As DataRow
                            ppr = PartProductNOTToOrder.NewRow
                            ppr("Type") = row.Item("Type")
                            ppr("ID") = row.Item("ID")
                            ppr("EngineerVisitID") = EngineerVisitID
                            ppr("PartProductID") = row.Item("PartProductID")
                            ppr("Name") = row.Item("Name")
                            ppr("Number") = row.Item("Number")
                            ppr("Quantity") = row.Item("Quantity")
                            ppr("OrderItemID") = row.Item("OrderItemID")
                            ppr("OrderLocationTypeID") = row.Item("OrderLocationTypeID")
                            ppr("SellPrice") = row.Item("SellPrice")
                            PartProductNOTToOrder.Rows.Add(ppr)
                        End If
                    Next

                    'DO THEY WANT TO ORDER NOW?
                    If msgStr.Length > 0 Then
                        If MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: " & vbCrLf &
                                        msgStr & vbCrLf & " Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                            ShowForm(GetType(FRMConvertToAnOrder), True, New Object() {CInt(Entity.Sys.Enums.OrderType.Job), JobID, New DataView(PartProductToOrder), 0, EngineerVisitID})

                        End If
                    End If

                    'DELETE EVERYTHING
                    _database.ClearParameter()
                    _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                    _database.ExecuteSP_OBJECT("EngineerVisitPartsAndProductsAllocated_Delete")

                    'CYCLE THROUGH NOT ORDERS
                    For Each row As DataRow In PartProductNOTToOrder.Rows

                        InsertOne(EngineerVisitID, row.Item("Type"), row.Item("Quantity"),
                             row.Item("OrderItemID"), row.Item("PartProductID"), row.Item("OrderLocationTypeID"))

                    Next

                    'CYCLE THROUGH ORDERS
                    For Each row As DataRow In PartProductToOrder.Rows

                        row.AcceptChanges()
                        If IsDBNull(row.Item("Quantity")) Then
                            row.Item("Quantity") = row.Item("QuantityToOrder")
                        End If

                        InsertOne(EngineerVisitID, row.Item("Type"), row.Item("Quantity"),
                             row.Item("OrderItemID"), row.Item("PartProductID"),
                             Entity.Sys.Helper.MakeIntegerValid(row.Item("OrderLocationTypeID")))

                    Next

                End If
            End Sub

            Public Sub InsertOne(ByVal EngineerVisitID As Integer, ByVal type As String,
                                    ByVal Quantity As Integer, ByVal OrderItemID As Integer,
                                    ByVal PartProductID As Integer, ByVal OrderLocationTypeID As Integer)

                Dim spToRun As String = ""
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@Quantity", Quantity, True)
                _database.AddParameter("@OrderLocationTypeID", OrderLocationTypeID, True)

                Select Case type
                    Case "Part"
                        _database.AddParameter("@PartID", PartProductID, True)
                        _database.AddParameter("@OrderPartID", OrderItemID, True)
                        spToRun = "EngineerVisitPartAllocated_Insert"
                    Case "Product"
                        _database.AddParameter("@ProductID", PartProductID, True)
                        _database.AddParameter("@OrderProductID", OrderItemID, True)
                        spToRun = "EngineerVisitProductAllocated_Insert"
                End Select

                _database.ExecuteSP_OBJECT(spToRun)

            End Sub

            Public Function InsertOne(ByVal EngineerVisitID As Integer, ByVal type As String,
                                   ByVal Quantity As Integer, ByVal OrderItemID As Integer,
                                   ByVal PartProductID As Integer, ByVal OrderLocationTypeID As Integer, ByVal trans As SqlClient.SqlTransaction) As Integer

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand
                Command.CommandType = CommandType.StoredProcedure

                Select Case type
                    Case "Part"
                        Command.CommandText = "EngineerVisitPartAllocated_Insert"
                        Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PartID", PartProductID))
                        Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderPartID", OrderItemID))
                    Case "Product"
                        Command.CommandText = "EngineerVisitProductAllocated_Insert"
                        Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductID", PartProductID))
                        Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderProductID", OrderItemID))
                End Select

                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Quantity", Quantity))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderLocationTypeID", OrderLocationTypeID))

                Return Command.ExecuteScalar

            End Function

            Public Sub UpdateOne(ByVal AllocationID As Integer, ByVal EngineerVisitID As Integer, ByVal type As String,
                                  ByVal Quantity As Integer, ByVal OrderItemID As Integer,
                                  ByVal PartProductID As Integer, ByVal OrderLocationTypeID As Integer)

                Dim spToRun As String = ""
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@Quantity", Quantity, True)
                _database.AddParameter("@OrderLocationTypeID", OrderLocationTypeID, True)

                Select Case type
                    Case "Part"
                        _database.AddParameter("@EngineerVisitPartAllocatedID", AllocationID, True)
                        _database.AddParameter("@PartID", PartProductID, True)
                        _database.AddParameter("@OrderPartID", OrderItemID, True)
                        spToRun = "EngineerVisitPartAllocated_Update"
                    Case "Product"
                        _database.AddParameter("@EngineerVisitProductAllocatedID", AllocationID, True)
                        _database.AddParameter("@ProductID", PartProductID, True)
                        _database.AddParameter("@OrderProductID", OrderItemID, True)
                        spToRun = "EngineerVisitProductAllocated_Update"
                End Select

                _database.ExecuteSP_OBJECT(spToRun)

            End Sub

            Public Sub UpdateOne(ByVal AllocationID As Integer, ByVal EngineerVisitID As Integer, ByVal type As String,
                                 ByVal Quantity As Integer, ByVal OrderItemID As Integer,
                                 ByVal PartProductID As Integer, ByVal OrderLocationTypeID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand
                Command.CommandType = CommandType.StoredProcedure

                Select Case type
                    Case "Part"
                        Command.CommandText = "EngineerVisitPartAllocated_Update"
                        Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EngineerVisitPartAllocatedID", AllocationID))
                        Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PartID", PartProductID))
                        Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderPartID", OrderItemID))
                    Case "Product"
                        Command.CommandText = "EngineerVisitProductAllocated_Update"
                        Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EngineerVisitProductAllocatedID", AllocationID))
                        Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductID", PartProductID))
                        Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderProductID", OrderItemID))
                End Select

                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Quantity", Quantity))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderLocationTypeID", OrderLocationTypeID))

                Command.ExecuteNonQuery()

            End Sub

            Public Sub EngineerVisitProductAllocated_Delete(ByVal OrderLocationTypeID As Integer, ByVal OrderProductID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderProductID", OrderProductID, True)
                _database.AddParameter("@OrderLocationTypeID", OrderLocationTypeID, True)
                _database.AddParameter("@SupplierOrderLocationEnumValue", CInt(Entity.Sys.Enums.LocationType.Supplier), True)

                DB.ExecuteSP_NO_Return("EngineerVisitProductAllocated_Delete")
            End Sub

            Public Sub EngineerVisitPartAllocated_Delete(ByVal OrderLocationTypeID As Integer, ByVal OrderPartID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderPartID", OrderPartID, True)
                _database.AddParameter("@OrderLocationTypeID", OrderLocationTypeID, True)
                _database.AddParameter("@SupplierOrderLocationEnumValue", CInt(Entity.Sys.Enums.LocationType.Supplier), True)

                DB.ExecuteSP_NO_Return("EngineerVisitPartAllocated_Delete")
            End Sub

            Public Sub EngineerVisitPartAllocated_DeleteByID(ByVal EngineerVisitPartAllocatedID As Integer, ByVal PartsAndProductsDistribution As DataView)
                For Each row As DataRow In PartsAndProductsDistribution.Table.Rows
                    If row.Item("StockTransactionType") = -1 Then
                        'PART CREDIT
                        Dim CurrentPartsToBeCredited As New Entity.PartsToBeCrediteds.PartsToBeCredited
                        CurrentPartsToBeCredited.IgnoreExceptionsOnSetMethods = True

                        Dim op As Entity.OrderParts.OrderPart = DB.OrderPart.OrderPart_Get(row.Item("OrderPartProductID"))
                        Dim ps As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(op.PartSupplierID)

                        CurrentPartsToBeCredited.SetOrderID = op.OrderID
                        CurrentPartsToBeCredited.SetSupplierID = ps.SupplierID
                        CurrentPartsToBeCredited.SetPartID = row.Item("PartProductID")
                        CurrentPartsToBeCredited.SetQty = row.Item("Quantity")
                        CurrentPartsToBeCredited.SetStatusID = CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Awaiting_Part_Return)
                        CurrentPartsToBeCredited.SetManuallyAdded = False
                        CurrentPartsToBeCredited.SetOrderReference = DB.Order.Order_Get(op.OrderID).OrderReference
                        DB.PartsToBeCredited.Insert(CurrentPartsToBeCredited)
                    End If

                    If row.Item("LocationID") > 0 And row.Item("StockTransactionType") > 0 Then
                        Select Case row.Item("Type")
                            Case "Part"
                                Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                                oPartTransaction.SetLocationID = row.Item("LocationID")
                                oPartTransaction.SetPartID = row.Item("PartProductID")
                                oPartTransaction.SetOrderPartID = row.Item("OrderPartProductID")
                                If CInt(row("StockTransactionType")) = CInt(Entity.Sys.Enums.Transaction.StockOut) Then
                                    oPartTransaction.SetAmount = row.Item("Quantity") * -1
                                Else
                                    oPartTransaction.SetAmount = row.Item("Quantity")
                                End If
                                oPartTransaction.SetTransactionTypeID = row.Item("StockTransactionType")
                                DB.PartTransaction.Insert(oPartTransaction)
                            Case "Product"
                                Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                                oProductTransaction.SetLocationID = row.Item("LocationID")
                                oProductTransaction.SetProductID = row.Item("PartProductID")
                                oProductTransaction.SetOrderProductID = row.Item("OrderPartProductID")
                                If CInt(row("StockTransactionType")) = CInt(Entity.Sys.Enums.Transaction.StockOut) Then
                                    oProductTransaction.SetAmount = row.Item("Quantity") * -1
                                Else
                                    oProductTransaction.SetAmount = row.Item("Quantity")
                                End If
                                oProductTransaction.SetTransactionTypeID = row.Item("StockTransactionType")
                                DB.ProductTransaction.Insert(oProductTransaction)
                        End Select
                    End If
                Next

                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitPartAllocatedID", EngineerVisitPartAllocatedID, True)

                DB.ExecuteSP_NO_Return("EngineerVisitPartAllocated_DeleteByID")
            End Sub

            Public Sub EngineerVisitPartAllocated_RemoveFromOrder(ByVal OrderLocationTypeID As Integer, ByVal OrderPartID As Integer)

                _database.ClearParameter()
                _database.AddParameter("@OrderPartID", OrderPartID, True)
                _database.AddParameter("@OrderLocationTypeID", OrderLocationTypeID, True)
                _database.AddParameter("@SupplierOrderLocationEnumValue", CInt(Entity.Sys.Enums.LocationType.Supplier), True)

                DB.ExecuteSP_NO_Return("EngineerVisitPartAllocated_RemoveFromOrder")

            End Sub

            Public Function Get_ByJobId(ByVal jobId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobID", jobId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartAllocated_Get_ByJobId")
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
                Return New DataView(dt)

            End Function

#End Region

        End Class

    End Namespace

End Namespace