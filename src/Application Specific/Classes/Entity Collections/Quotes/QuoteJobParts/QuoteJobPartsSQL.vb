Imports System.Data.SqlClient

Namespace Entity

Namespace QuoteJobPartss

Public Class QuoteJobPartsSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

            Public Sub Delete(ByVal QuoteJobID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", QuoteJobID, True)
                _database.ExecuteSP_NO_Return("QuoteJobParts_Delete")
            End Sub

            Public Sub DeleteAll(ByVal QuoteJobID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", QuoteJobID, True)
                _database.ExecuteSP_NO_Return("QuoteJobParts_DeleteAllMarkedDeleted")
            End Sub

            Public Function [Insert](ByVal oQuoteJobParts As QuoteJobParts) As QuoteJobParts
                _database.ClearParameter()
                AddQuoteJobPartsParametersToCommand(oQuoteJobParts)

                oQuoteJobParts.SetQuoteJobPartsID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJob_Parts_Insert"))
                oQuoteJobParts.Exists = True
                Return oQuoteJobParts
            End Function

            Private Sub AddQuoteJobPartsParametersToCommand(ByRef oQuoteJobParts As QuoteJobParts)
                With _database
                    .AddParameter("@QuoteJobID", oQuoteJobParts.QuoteJobID, True)
                    .AddParameter("@PartID", oQuoteJobParts.PartID, True)
                    .AddParameter("@Quantity", oQuoteJobParts.Quantity, True)

                    .AddParameter("@BuyPrice", oQuoteJobParts.BuyPrice, True)
                    .AddParameter("@PartSupplierID", oQuoteJobParts.PartSupplierID, True)
                    If oQuoteJobParts.SpecialDescription.Length = 0 Then
                        .AddParameter("@SpecialDescription", DBNull.Value, True)
                    Else
                        .AddParameter("@SpecialDescription", oQuoteJobParts.SpecialDescription, True)
                    End If

                    .AddParameter("@SpecialCost", oQuoteJobParts.SpecialCost, True)
                    .AddParameter("@Extra", oQuoteJobParts.Extra, True)

                End With
            End Sub

#End Region

End Class

End Namespace

End Namespace


