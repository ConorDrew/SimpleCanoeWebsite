Imports System.Data.SqlClient

Namespace Entity

    Namespace OrderConsolidations

        Public Class OrderConsolidationSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub OrderConsolidation_Clear_Orders(ByVal OrderConsolidationID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, True)
                _database.ExecuteSP_NO_Return("OrderConsolidation_Clear_Orders")
            End Sub

            Public Sub Order_Set_Consolidated(ByVal OrderConsolidationID As Integer, ByVal OrderID As Integer, ByVal ReleaseConsolidated As Boolean)
                _database.ClearParameter()
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, True)
                _database.AddParameter("@OrderID", OrderID, True)
                If ReleaseConsolidated Then
                    _database.AddParameter("@ReleaseConsolidated", 1, True)
                Else
                    _database.AddParameter("@ReleaseConsolidated", 0, True)
                End If
                _database.ExecuteSP_NO_Return("Order_Set_Consolidated")
            End Sub

            Public Sub Order_Set_Consolidated(ByVal OrderConsolidationID As Integer, ByVal OrderID As Integer, ByVal ReleaseConsolidated As Boolean, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Order_Set_Consolidated"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@OrderConsolidationID", OrderConsolidationID)
                Command.Parameters.AddWithValue("@OrderID", OrderID)

                If ReleaseConsolidated Then
                    Command.Parameters.AddWithValue("@ReleaseConsolidated", 1)
                Else
                    Command.Parameters.AddWithValue("@ReleaseConsolidated", 0)
                End If

                Command.ExecuteNonQuery()

            End Sub


            Public Function [OrderConsolidation_Get](ByVal OrderConsolidationID As Integer) As OrderConsolidation
                _database.ClearParameter()
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderConsolidation_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oOrderConsolidation As New OrderConsolidation
                        With oOrderConsolidation
                            .IgnoreExceptionsOnSetMethods = True
                            .SetOrderConsolidationID = dt.Rows(0).Item("OrderConsolidationID")
                            .SetSupplierID = dt.Rows(0).Item("SupplierID")
                            .SetLocationID = dt.Rows(0).Item("LocationID")
                            .ConsolidationDate = CDate(dt.Rows(0).Item("ConsolidationDate"))
                            .SetConsolidationRef = dt.Rows(0).Item("ConsolidationRef")
                            .SetComments = dt.Rows(0).Item("Comments")
                            .SetConsolidatedOrderStatusID = dt.Rows(0).Item("ConsolidatedOrderStatusID")
                            .HasSupplierPO = dt.Rows(0).Item("HasSupplierPO")

                            .SetSupplierInvoiceReference = dt.Rows(0).Item("SupplierInvoiceReference")
                            .SupplierInvoiceDate = Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("SupplierInvoiceDate"))
                            .SetSupplierInvoiceAmount = dt.Rows(0).Item("SupplierInvoiceAmount")
                            .SetVATAmount = dt.Rows(0).Item("VATAmount")
                            .SetTaxCodeID = dt.Rows(0).Item("TaxCodeID")
                            .SetExtraRef = dt.Rows(0).Item("ExtraRef")
                            .SetNominalCode = dt.Rows(0).Item("NominalCode")
                            .SetDepartmentRef = dt.Rows(0).Item("DepartmentRef")
                            .SetReadyToSendToSage = dt.Rows(0).Item("ReadyToSendToSage")
                            .SetSentToSage = dt.Rows(0).Item("SentToSage")
                            .DateExported = Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("DateExported"))
                        End With
                        oOrderConsolidation.Exists = True
                        Return oOrderConsolidation
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [OrderConsolidation_GetAll](ByVal forLocation As Boolean, ByVal SearchCriteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchCriteria", SearchCriteria, True)
                If forLocation Then
                    _database.AddParameter("@ForLocation", 1, True)
                Else
                    _database.AddParameter("@ForLocation", 0, True)
                End If

                Dim dt As DataTable = _database.ExecuteSP_DataTable("OrderConsolidation_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function [Order_GetForConsolidation](ByVal SupplierID As Integer, ByVal LocationID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SupplierID", SupplierID, True)
                _database.AddParameter("@LocationID", LocationID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("[Order_GetForConsolidation]")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Order_GetForConsolidationByID(ByVal OrderConsolidationID As Integer, ByVal SupplierID As Integer, ByVal LocationID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, True)
                _database.AddParameter("@SupplierID", SupplierID, True)
                _database.AddParameter("@LocationID", LocationID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("[Order_GetForConsolidationByID]")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Order_GetForConsolidationByID_Confirmed(ByVal OrderConsolidationID As Integer, ByVal ForLocation As Boolean) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, True)
                If ForLocation Then
                    _database.AddParameter("@ForLocation", 1, True)
                Else
                    _database.AddParameter("@ForLocation", 0, True)
                End If
                Dim dt As DataTable = _database.ExecuteSP_DataTable("[Order_GetForConsolidationByID_Confirmed]")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Sub Create_And_Insert_Supplier(ByVal PartSupplierID As Integer, ByVal ProductSupplierID As Integer, ByVal OrderID As Integer)
                Dim supplierID As Integer = 0

                Try
                    If Not PartSupplierID = 0 Then
                        supplierID = DB.PartSupplier.PartSupplier_Get(PartSupplierID).SupplierID
                    Else
                        If Not ProductSupplierID = 0 Then
                            supplierID = DB.ProductSupplier.ProductSupplier_Get(ProductSupplierID).SupplierID
                        End If
                    End If

                    If supplierID = 0 Then
                        Throw New Exception("Supplier could not be determined")
                    Else
                        Dim OrderConsolidationID As Integer = 0

                        OrderConsolidationID = DB.Order.Order_Get(OrderID).OrderConsolidationID

                        If OrderConsolidationID = 0 Then
                            _database.ClearParameter()
                            _database.AddParameter("@SupplierID", supplierID, True)
                            _database.AddParameter("@LocationID", 0, True)

                            OrderConsolidationID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderConsolidation_Check_If_Exists"))
                        End If

                        If OrderConsolidationID = 0 Then
                            Dim oOrderConsolidation As New OrderConsolidation
                            oOrderConsolidation.SetSupplierID = supplierID
                            oOrderConsolidation.SetComments = "Automatically Created"
                            oOrderConsolidation.SetConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)

                            Dim OrderNumber As JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.CONSOLIDATION)
                            OrderNumber.OrderNumber = OrderNumber.JobNumber
                            While OrderNumber.OrderNumber.Length < 5
                                OrderNumber.OrderNumber = "0" & OrderNumber.OrderNumber
                            End While

                            Dim typePrefix As String = "W"

                            Dim userPrefix As String = ""
                            Dim username() As String = loggedInUser.Fullname.Split(" ")
                            For Each s As String In username
                                userPrefix += s.Substring(0, 1)
                            Next

                            OrderNumber.OrderNumber = userPrefix & typePrefix & OrderNumber.OrderNumber
                            oOrderConsolidation.SetConsolidationRef = OrderNumber.OrderNumber

                            OrderConsolidationID = Insert(oOrderConsolidation)
                        End If

                        Order_Set_Consolidated(OrderConsolidationID, OrderID, False)
                    End If
                Catch ex As Exception
                    ShowMessage("Consolidation could not be created:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Sub

            Public Sub Create_And_Insert_Supplier(ByVal PartSupplierID As Integer, ByVal ProductSupplierID As Integer, ByVal OrderID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim supplierID As Integer = 0

                Try
                    If Not PartSupplierID = 0 Then
                        supplierID = DB.PartSupplier.PartSupplier_Get(PartSupplierID, trans).SupplierID
                    Else
                        If Not ProductSupplierID = 0 Then
                            supplierID = DB.ProductSupplier.ProductSupplier_Get(ProductSupplierID, trans).SupplierID
                        End If
                    End If

                    If supplierID = 0 Then
                        Throw New Exception("Supplier could not be determined")
                    Else
                        Dim OrderConsolidationID As Integer = 0

                        OrderConsolidationID = DB.Order.Order_Get(OrderID, trans).OrderConsolidationID

                        If OrderConsolidationID = 0 Then

                            Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                            Command.CommandText = "OrderConsolidation_Check_If_Exists"
                            Command.CommandType = CommandType.StoredProcedure
                            Command.Transaction = trans
                            Command.Connection = trans.Connection

                            Command.Parameters.AddWithValue("@SupplierID", supplierID)
                            Command.Parameters.AddWithValue("@LocationID", 0)

                            OrderConsolidationID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                        End If

                        If OrderConsolidationID = 0 Then
                            Dim oOrderConsolidation As New OrderConsolidation
                            oOrderConsolidation.SetSupplierID = supplierID
                            oOrderConsolidation.SetComments = "Automatically Created"
                            oOrderConsolidation.SetConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)

                            Dim OrderNumber As JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.CONSOLIDATION, trans)
                            OrderNumber.OrderNumber = OrderNumber.JobNumber
                            While OrderNumber.OrderNumber.Length < 5
                                OrderNumber.OrderNumber = "0" & OrderNumber.OrderNumber
                            End While

                            Dim typePrefix As String = "W"

                            Dim userPrefix As String = ""
                            Dim username() As String = loggedInUser.Fullname.Split(" ")
                            For Each s As String In username
                                userPrefix += s.Substring(0, 1)
                            Next

                            OrderNumber.OrderNumber = userPrefix & typePrefix & OrderNumber.OrderNumber
                            oOrderConsolidation.SetConsolidationRef = OrderNumber.OrderNumber

                            OrderConsolidationID = Insert(oOrderConsolidation, trans)
                        End If

                        Order_Set_Consolidated(OrderConsolidationID, OrderID, False, trans)
                    End If
                Catch ex As Exception
                    ShowMessage("Consolidation could not be created:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Sub

            Public Sub Create_And_Insert_Location(ByVal LocationID As Integer, ByVal OrderID As Integer, ByVal trans As SqlClient.SqlTransaction)
                Try
                    If LocationID = 0 Then
                        Throw New Exception("Location could not be determined")
                    Else
                        Dim OrderConsolidationID As Integer = 0

                        OrderConsolidationID = DB.Order.Order_Get(OrderID, trans).OrderConsolidationID

                        If OrderConsolidationID = 0 Then

                            Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                            Command.CommandText = "OrderConsolidation_Check_If_Exists"
                            Command.CommandType = CommandType.StoredProcedure
                            Command.Transaction = trans
                            Command.Connection = trans.Connection

                            Command.Parameters.AddWithValue("@SupplierID", 0)
                            Command.Parameters.AddWithValue("@LocationID", LocationID)

                            OrderConsolidationID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)

                        End If

                        If OrderConsolidationID = 0 Then
                            Dim oOrderConsolidation As New OrderConsolidation
                            oOrderConsolidation.SetLocationID = LocationID
                            oOrderConsolidation.SetComments = "Automatically Created"
                            oOrderConsolidation.SetConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)

                            Dim OrderNumber As JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.CONSOLIDATION, trans)
                            OrderNumber.OrderNumber = OrderNumber.JobNumber
                            While OrderNumber.OrderNumber.Length < 6
                                OrderNumber.OrderNumber = "0" & OrderNumber.OrderNumber
                            End While
                            oOrderConsolidation.SetConsolidationRef = OrderNumber.Prefix & OrderNumber.OrderNumber

                            OrderConsolidationID = Insert(oOrderConsolidation, trans)
                        End If

                        Order_Set_Consolidated(OrderConsolidationID, OrderID, False, trans)
                    End If
                Catch ex As Exception
                    ShowMessage("Consolidation could not be created:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Sub


            Public Sub Create_And_Insert_Location(ByVal LocationID As Integer, ByVal OrderID As Integer)
                Try
                    If LocationID = 0 Then
                        Throw New Exception("Location could not be determined")
                    Else
                        Dim OrderConsolidationID As Integer = 0

                        OrderConsolidationID = DB.Order.Order_Get(OrderID).OrderConsolidationID

                        If OrderConsolidationID = 0 Then
                            _database.ClearParameter()
                            _database.AddParameter("@SupplierID", 0, True)
                            _database.AddParameter("@LocationID", LocationID, True)

                            OrderConsolidationID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderConsolidation_Check_If_Exists"))
                        End If

                        If OrderConsolidationID = 0 Then
                            Dim oOrderConsolidation As New OrderConsolidation
                            oOrderConsolidation.SetLocationID = LocationID
                            oOrderConsolidation.SetComments = "Automatically Created"
                            oOrderConsolidation.SetConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)

                            Dim OrderNumber As JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.CONSOLIDATION)
                            OrderNumber.OrderNumber = OrderNumber.JobNumber
                            While OrderNumber.OrderNumber.Length < 6
                                OrderNumber.OrderNumber = "0" & OrderNumber.OrderNumber
                            End While
                            oOrderConsolidation.SetConsolidationRef = OrderNumber.Prefix & OrderNumber.OrderNumber

                            OrderConsolidationID = Insert(oOrderConsolidation)
                        End If

                        Order_Set_Consolidated(OrderConsolidationID, OrderID, False)
                    End If
                Catch ex As Exception
                    ShowMessage("Consolidation could not be created:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Sub

            Public Function [Insert](ByVal oOrderConsolidation As OrderConsolidation) As Integer
                _database.ClearParameter()
                _database.AddParameter("@SupplierID", oOrderConsolidation.SupplierID, True)
                _database.AddParameter("@LocationID", oOrderConsolidation.LocationID, True)
                _database.AddParameter("@ConsolidationRef", oOrderConsolidation.ConsolidationRef, True)
                _database.AddParameter("@Comments", oOrderConsolidation.Comments, True)
                _database.AddParameter("@ConsolidatedOrderStatusID", oOrderConsolidation.ConsolidatedOrderStatusID, True)

                oOrderConsolidation.SetOrderConsolidationID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderConsolidation_Insert"))
                oOrderConsolidation.Exists = True
                Return oOrderConsolidation.OrderConsolidationID
            End Function

            Public Function [Insert](ByVal oOrderConsolidation As OrderConsolidation, ByVal trans As SqlClient.SqlTransaction) As Integer

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "OrderConsolidation_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@SupplierID", oOrderConsolidation.SupplierID)
                Command.Parameters.AddWithValue("@LocationID", oOrderConsolidation.LocationID)
                Command.Parameters.AddWithValue("@ConsolidationRef", oOrderConsolidation.ConsolidationRef)
                Command.Parameters.AddWithValue("@Comments", oOrderConsolidation.Comments)
                Command.Parameters.AddWithValue("@ConsolidatedOrderStatusID", oOrderConsolidation.ConsolidatedOrderStatusID)

                oOrderConsolidation.SetOrderConsolidationID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                oOrderConsolidation.Exists = True
                Return oOrderConsolidation.OrderConsolidationID

            End Function

            Public sub [Update](ByVal oOrderConsolidation As OrderConsolidation) 
                _database.ClearParameter()
                _database.AddParameter("@OrderConsolidationID", oOrderConsolidation.OrderConsolidationID, True)
                _database.AddParameter("@Comments", oOrderConsolidation.Comments, True)
                _database.AddParameter("@ConsolidatedOrderStatusID", oOrderConsolidation.ConsolidatedOrderStatusID, True)
                If oOrderConsolidation.HasSupplierPO Then
                    _database.AddParameter("@HasSupplierPO", 1, True)
                Else
                    _database.AddParameter("@HasSupplierPO", 0, True)
                End If

                _database.AddParameter("@SupplierInvoiceReference", oOrderConsolidation.SupplierInvoiceReference, True)
                If oOrderConsolidation.SupplierInvoiceDate = Nothing Then
                    _database.AddParameter("@SupplierInvoiceDate", DBNull.Value, True)
                Else
                    _database.AddParameter("@SupplierInvoiceDate", oOrderConsolidation.SupplierInvoiceDate, True)
                End If
                _database.AddParameter("@SupplierInvoiceAmount", oOrderConsolidation.SupplierInvoiceAmount, True)
                _database.AddParameter("@VATAmount", oOrderConsolidation.VATAmount, True)
                _database.AddParameter("@TaxCodeID", oOrderConsolidation.TaxCodeID, True)
                _database.AddParameter("@ExtraRef", oOrderConsolidation.ExtraRef, True)
                _database.AddParameter("@NominalCode", oOrderConsolidation.NominalCode, True)
                _database.AddParameter("@DepartmentRef", oOrderConsolidation.DepartmentRef, True)
                If oOrderConsolidation.ReadyToSendToSage Then
                    _database.AddParameter("@ReadyToSendToSage", 1, True)
                Else
                    _database.AddParameter("@ReadyToSendToSage", 0, True)
                End If

                _database.ExecuteSP_NO_Return("OrderConsolidation_Update")
            End Sub

            Public Function Order_GetItemForConsolidationID(ByVal OrderConsolidationID As Integer, ByVal ForLocation As Boolean) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, True)
                If ForLocation Then
                    _database.AddParameter("@ForLocation", 1, True)
                Else
                    _database.AddParameter("@ForLocation", 0, True)
                End If
                Dim dt As DataTable = _database.ExecuteSP_DataTable("[Order_GetItemForConsolidationID]")
                dt.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
                Return New DataView(dt)
            End Function

            Public Function Orders_Complete_ByConsolidationOrderID(ByVal OrderConsolidationID As Integer) As DataSet
                _database.ClearParameter()
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, True)

                Return _database.ExecuteSP_DataSet("[Orders_Complete_ByConsolidationOrderID]")
            End Function

#End Region

        End Class

    End Namespace

End Namespace


