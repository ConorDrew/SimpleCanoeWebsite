Imports System.Data.SqlClient

Namespace Entity

Namespace QuoteOrderProducts

Public Class QuoteOrderProductSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal QuoteOrderProductID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@QuoteOrderProductID", QuoteOrderProductID, True)
            _database.ExecuteSP_NO_Return("QuoteOrderProduct_Delete")
    End Sub

    Public Function [QuoteOrderProduct_Get](ByVal QuoteOrderProductID As Integer) As QuoteOrderProduct
        _database.ClearParameter()
        _database.AddParameter("@QuoteOrderProductID", QuoteOrderProductID)
        
        'Get the datatable from the database store in dt
        Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteOrderProduct_Get")
        
        If Not dt Is Nothing Then			
			if dt.rows.count > 0 then
				Dim oQuoteOrderProduct As New QuoteOrderProduct
				With oQuoteOrderProduct
				    .IgnoreExceptionsOnSetMethods = True
                            .SetQuoteOrderProductID = dt.Rows(0).Item("QuoteOrderProductID")
                            .SetQuoteOrderID = dt.Rows(0).Item("QuoteOrderID")
                            .SetProductID = dt.Rows(0).Item("ProductID")
                            .SetPrice = Entity.Sys.Helper.MakeDoubleValid("Price")
                            .SetQuantity = Entity.Sys.Helper.MakeIntegerValid("Quantity")
					.SetDeleted = dt.Rows(0).Item("Deleted")               
				End With		
				oQuoteOrderProduct.Exists = true				
			Return oQuoteOrderProduct
			else
					Return Nothing
			end if 
			       Else
            Return Nothing
        End If
    End Function

    Public Function [QuoteOrderProduct_GetAll]() As DataView
       _database.ClearParameter()
        Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteOrderProduct_GetAll")
        dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteOrderProduct.ToString
        Return New DataView(dt)
    End Function
   
    Public Function [Insert](ByVal oQuoteOrderProduct As QuoteOrderProduct) As QuoteOrderProduct
		 _database.ClearParameter()			
	     AddQuoteOrderProductParametersToCommand(oQuoteOrderProduct)	
						
		oQuoteOrderProduct.SetQuoteOrderProductID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteOrderProduct_Insert"))				
        oQuoteOrderProduct.Exists = True
        Return oQuoteOrderProduct
    End Function   
    

    Public Sub [Update](ByVal oQuoteOrderProduct As QuoteOrderProduct)
		_database.ClearParameter()
		_database.AddParameter("@QuoteOrderProductID", oQuoteOrderProduct.QuoteOrderProductID, True)  
		AddQuoteOrderProductParametersToCommand(oQuoteOrderProduct)
		_database.ExecuteSP_NO_Return("QuoteOrderProduct_Update")
    End Sub

            Public Function QuoteOrderProduct_GetForQuoteOrder(ByVal QuoteOrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteOrderProduct_GetForQuoteOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
                Return New DataView(dt)
            End Function

            Private Sub AddQuoteOrderProductParametersToCommand(ByRef oQuoteOrderProduct As QuoteOrderProduct)
                With _database
                    .AddParameter("@QuoteOrderID", oQuoteOrderProduct.QuoteOrderID, True)
                    .AddParameter("@ProductID", oQuoteOrderProduct.ProductID, True)
                    .AddParameter("@Price", oQuoteOrderProduct.Price, True)
                    .AddParameter("@Quantity", oQuoteOrderProduct.Quantity, True)
                End With
            End Sub

            Public Sub QuoteOrderProduct_DeleteForQuoteOrder(ByVal QuoteOrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, True)
                _database.ExecuteSP_NO_Return("QuoteOrderProduct_DeleteForQuoteOrder")
            End Sub

#End Region

End Class

End Namespace

End Namespace


