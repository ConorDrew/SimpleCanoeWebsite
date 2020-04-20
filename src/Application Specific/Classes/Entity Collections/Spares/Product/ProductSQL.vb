Imports System.Data.SqlClient

Namespace Entity.Products

    Public Class ProductSQL
        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

#Region "Functions"

        Public Sub Delete(ByVal ProductID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@ProductID", ProductID, True)
            _database.ExecuteSP_NO_Return("Product_Delete")
        End Sub

        Public Function [Product_Get](ByVal ProductID As Integer, ByVal trans As SqlClient.SqlTransaction) As Product

            Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

            Command.CommandText = "Product_Get"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.AddWithValue("@ProductID", ProductID)

            Dim Adapter As New SqlClient.SqlDataAdapter(Command)
            Dim returnDS As New DataSet
            Adapter.Fill(returnDS)

            'Get the datatable from the database store in dt
            Dim dt As DataTable = _database.ExecuteSP_DataTable("")

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Dim oProduct As New Product
                    With oProduct
                        .IgnoreExceptionsOnSetMethods = True
                        .SetProductID = dt.Rows(0).Item("ProductID")
                        .SetNumber = dt.Rows(0).Item("Number")
                        .SetReference = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Reference"))
                        .SetTypeID = dt.Rows(0).Item("TypeID")
                        .SetMakeID = dt.Rows(0).Item("MakeID")
                        .SetModelID = dt.Rows(0).Item("ModelID")
                        .SetNotes = dt.Rows(0).Item("Notes")
                        .SetSellPrice = dt.Rows(0).Item("SellPrice")
                        .SetName = dt.Rows(0).Item("Name")
                        .SetDeleted = dt.Rows(0).Item("Deleted")
                        .SetMinimumQuantity = dt.Rows(0).Item("MinimumQuantity")
                        .SetRecommendedQuantity = dt.Rows(0).Item("RecommendedQuantity")
                        .AssociatedPart = DB.ProductAssociatedPart.GetAll_For_ProductID(ProductID)
                    End With
                    oProduct.Exists = True
                    Return oProduct
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Function

        Public Function [Product_Get](ByVal ProductID As Integer) As Product

            _database.ClearParameter()
            _database.AddParameter("@ProductID", ProductID)

            'Get the datatable from the database store in dt
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Product_Get")

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Dim oProduct As New Product
                    With oProduct
                        .IgnoreExceptionsOnSetMethods = True
                        .SetProductID = dt.Rows(0).Item("ProductID")
                        .SetNumber = dt.Rows(0).Item("Number")
                        .SetReference = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Reference"))
                        .SetTypeID = dt.Rows(0).Item("TypeID")
                        .SetMakeID = dt.Rows(0).Item("MakeID")
                        .SetModelID = dt.Rows(0).Item("ModelID")
                        .SetNotes = dt.Rows(0).Item("Notes")
                        .SetSellPrice = dt.Rows(0).Item("SellPrice")
                        .SetName = dt.Rows(0).Item("Name")
                        .SetDeleted = dt.Rows(0).Item("Deleted")
                        .SetMinimumQuantity = dt.Rows(0).Item("MinimumQuantity")
                        .SetRecommendedQuantity = dt.Rows(0).Item("RecommendedQuantity")
                        .AssociatedPart = DB.ProductAssociatedPart.GetAll_For_ProductID(ProductID)
                    End With
                    oProduct.Exists = True
                    Return oProduct
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Function

        Public Function Check_Unique_Number(ByVal Number As String, ByVal ID As Integer) As Boolean
            Dim NumberOfProducts As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(ProductID) as 'NumberOfProducts' " & _
            "FROM tblproduct WHERE deleted =0 AND Number = '" & Number & "' AND ProductID <> " & ID, False))

            If NumberOfProducts = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function [Product_GetAll]() As DataView
            _database.ClearParameter()
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Product_GetAll")
            dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
            Return New DataView(dt)
        End Function

        Public Function [Product_GetAll](ByVal trans As SqlClient.SqlTransaction) As DataView

            Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

            Command.CommandText = "Product_GetAll"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection


            Dim Adapter As New SqlClient.SqlDataAdapter(Command)
            Dim returnDS As New DataSet
            Adapter.Fill(returnDS)

            Dim dt As DataTable = returnDS.Tables(0)

            dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString

            Return New DataView(dt)

        End Function

        Public Function [Product_Search](ByVal criteria As String, ByVal SearchOnField As String) As DataView

            If SearchOnField.Trim.Length > 0 Then
                criteria = "'%" & criteria & "%'"
            End If

            _database.ClearParameter()
            _database.AddParameter("@SearchString", criteria, True)
            _database.AddParameter("@SearchOnField", SearchOnField, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Product_SearchList")
            dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
            Return New DataView(dt)
        End Function

        Public Function [Product_Check_Stock_Level](ByVal ProductID As Integer, ByVal LocationID As Integer) As Integer
            _database.ClearParameter()
            _database.AddParameter("@ProductID", ProductID, True)
            _database.AddParameter("@LocationID", LocationID, True)

            Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Product_Check_Stock_Level"))
        End Function

        Public Function [Product_Check_Stock_Level](ByVal ProductID As Integer, ByVal LocationID As Integer, ByVal trans As SqlClient.SqlTransaction) As Integer

            Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

            Command.CommandText = "Product_Check_Stock_Level"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.AddWithValue("@ProductID", ProductID)
            Command.Parameters.AddWithValue("@LocationID", LocationID)

            Return Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)

        End Function

        Public Function [Insert](ByVal oProduct As Product) As Product
            _database.ClearParameter()
            AddProductParametersToCommand(oProduct)

            oProduct.SetProductID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Product_Insert"))
            oProduct.Exists = True
            InsertAssociatedParts(oProduct)
            Return oProduct
        End Function

        Public Sub [Update](ByVal oProduct As Product)
            _database.ClearParameter()
            _database.AddParameter("@ProductID", oProduct.ProductID, True)
            AddProductParametersToCommand(oProduct)
            _database.ExecuteSP_NO_Return("Product_Update")
            InsertAssociatedParts(oProduct)
        End Sub

        Private Sub AddProductParametersToCommand(ByRef oProduct As Product)
            With _database
                .AddParameter("@Number", oProduct.Number, True)
                .AddParameter("@Reference", oProduct.Reference, True)
                .AddParameter("@TypeID", oProduct.TypeID, True)
                .AddParameter("@MakeID", oProduct.MakeID, True)
                .AddParameter("@ModelID", oProduct.ModelID, True)
                .AddParameter("@Notes", oProduct.Notes, True)
                .AddParameter("@SellPrice", oProduct.SellPrice, True)
                .AddParameter("@MinimumQuantity", oProduct.MinimumQuantity, True)
                .AddParameter("@RecommendedQuantity", oProduct.RecommendedQuantity, True)
            End With
        End Sub

        Private Sub InsertAssociatedParts(ByVal oProduct As Entity.Products.Product)

            _database.ProductAssociatedPart.Delete(oProduct.ProductID)

            Dim oProductAssociatedPart As New Entity.ProductAssociatedParts.ProductAssociatedPart
            oProductAssociatedPart.SetProductID = oProduct.ProductID

            If Not oProduct.AssociatedPart Is Nothing Then
                For Each part As DataRow In oProduct.AssociatedPart.Table.Rows
                    If part("Tick") Then
                        oProductAssociatedPart.SetPartID = part("PartID")
                        _database.ProductAssociatedPart.Insert(oProductAssociatedPart)
                    End If

                Next part
            End If



        End Sub

        Public Function Stock_Get_Locations(ByVal ProductID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@PartID", 0, True)
            _database.AddParameter("@ProductID", ProductID, True)
            _database.AddParameter("@WarehouseID", 0, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Stock_Get_Locations")
            dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
            Return New DataView(dt)
        End Function

        Public Function Stock_Get_Locations(ByVal ProductID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

            Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

            Command.CommandText = "Stock_Get_Locations"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.AddWithValue("@PartID", 0)
            Command.Parameters.AddWithValue("@ProductID", ProductID)
            Command.Parameters.AddWithValue("@WarehouseID", 0)

            Dim Adapter As New SqlClient.SqlDataAdapter(Command)
            Dim returnDS As New DataSet
            Adapter.Fill(returnDS)

            Dim dt As DataTable = returnDS.Tables(0)

            dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString

            Return New DataView(dt)

        End Function

#End Region

    End Class

End Namespace




