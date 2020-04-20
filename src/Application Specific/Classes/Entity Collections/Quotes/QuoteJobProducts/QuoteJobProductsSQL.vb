Imports System.Data.SqlClient

Namespace Entity

Namespace QuoteJobProductss

Public Class QuoteJobProductsSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
            Public Sub Delete(ByVal QuoteJobID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", QuoteJobID, True)
                _database.ExecuteSP_NO_Return("QuoteJobProducts_Delete")
            End Sub

            Public Function [Insert](ByVal oQuoteJobProducts As QuoteJobProducts) As QuoteJobProducts
                _database.ClearParameter()
                AddQuoteJobProductsParametersToCommand(oQuoteJobProducts)

                oQuoteJobProducts.SetQuoteJobProductsID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJobProducts_Insert"))
                oQuoteJobProducts.Exists = True
                Return oQuoteJobProducts
            End Function

            Private Sub AddQuoteJobProductsParametersToCommand(ByRef oQuoteJobProducts As QuoteJobProducts)
                With _database
                    .AddParameter("@QuoteJobID", oQuoteJobProducts.QuoteJobID, True)
                    .AddParameter("@ProductID", oQuoteJobProducts.ProductID, True)
                    .AddParameter("@Quantity", oQuoteJobProducts.Quantity, True)
                    .AddParameter("@SellPrice", oQuoteJobProducts.SellPrice, True)
                End With
            End Sub

#End Region

End Class

End Namespace

End Namespace


