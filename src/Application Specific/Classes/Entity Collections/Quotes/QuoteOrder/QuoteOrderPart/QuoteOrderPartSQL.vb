Imports System.Data.SqlClient

Namespace Entity

Namespace QuoteOrderParts

Public Class QuoteOrderPartSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal QuoteOrderPartID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@QuoteOrderPartID", QuoteOrderPartID, True)
            _database.ExecuteSP_NO_Return("QuoteOrderPart_Delete")
    End Sub

    Public Function [QuoteOrderPart_Get](ByVal QuoteOrderPartID As Integer) As QuoteOrderPart
        _database.ClearParameter()
        _database.AddParameter("@QuoteOrderPartID", QuoteOrderPartID)
        
        'Get the datatable from the database store in dt
        Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteOrderPart_Get")
        
        If Not dt Is Nothing Then			
			if dt.rows.count > 0 then
				Dim oQuoteOrderPart As New QuoteOrderPart
				With oQuoteOrderPart
				    .IgnoreExceptionsOnSetMethods = True
                            .SetQuoteOrderPartID = dt.Rows(0).Item("QuoteOrderPartID")
                            .SetQuoteOrderID = dt.Rows(0).Item("QuoteOrderID")
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetPrice = Entity.Sys.Helper.MakeDoubleValid("Price")
                            .SetQuantity = Entity.Sys.Helper.MakeIntegerValid("Quantity")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
				End With		
				oQuoteOrderPart.Exists = true				
			Return oQuoteOrderPart
			else
					Return Nothing
			end if 
			       Else
            Return Nothing
        End If
    End Function

    Public Function [QuoteOrderPart_GetAll]() As DataView
       _database.ClearParameter()
        Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteOrderPart_GetAll")
        dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteOrderPart.ToString
        Return New DataView(dt)
    End Function
   
    Public Function [Insert](ByVal oQuoteOrderPart As QuoteOrderPart) As QuoteOrderPart
		 _database.ClearParameter()			
	     AddQuoteOrderPartParametersToCommand(oQuoteOrderPart)	
						
		oQuoteOrderPart.SetQuoteOrderPartID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteOrderPart_Insert"))				
        oQuoteOrderPart.Exists = True
        Return oQuoteOrderPart
    End Function   

            Public Sub QuoteOrderPart_DeleteForQuoteOrder(ByVal QuoteOrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, True)
                _database.ExecuteSP_NO_Return("QuoteOrderPart_DeleteForQuoteOrder")
            End Sub

            Public Sub [Update](ByVal oQuoteOrderPart As QuoteOrderPart)
                _database.ClearParameter()
                _database.AddParameter("@QuoteOrderPartID", oQuoteOrderPart.QuoteOrderPartID, True)
                AddQuoteOrderPartParametersToCommand(oQuoteOrderPart)
                _database.ExecuteSP_NO_Return("QuoteOrderPart_Update")
            End Sub

            Public Function QuoteOrderPart_GetForQuoteOrder(ByVal QuoteOrderID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteOrderPart_GetForQuoteOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Private Sub AddQuoteOrderPartParametersToCommand(ByRef oQuoteOrderPart As QuoteOrderPart)
                With _database
                    .AddParameter("@QuoteOrderID", oQuoteOrderPart.QuoteOrderID, True)
                    .AddParameter("@PartID", oQuoteOrderPart.PartID, True)
                    .AddParameter("@Price", oQuoteOrderPart.Price, True)
                    .AddParameter("@Quantity", oQuoteOrderPart.Quantity, True)
                End With
            End Sub


#End Region

End Class

End Namespace

End Namespace


