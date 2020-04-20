Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractOption3s

        Public Class QuoteContractOption3SQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function VisitFrequency_Get() As DataTable
                _database.ClearParameter()
                Return _database.ExecuteSP_DataTable("VisitFrequencyOption3_Get")
            End Function

            Public Function InvoiceFrequency_Get() As DataTable
                _database.ClearParameter()
                Return _database.ExecuteSP_DataTable("InvoiceFrequency_Get")
            End Function

            Public Sub Delete(ByVal QuoteContractID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID, True)
                _database.ExecuteSP_NO_Return("QuoteContractOption3_Delete")
            End Sub

            Public Function [QuoteContractOption3_Get](ByVal QuoteContractID As Integer) As QuoteContractOption3
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOption3_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oQuoteContractOption3 As New QuoteContractOption3
                        With oQuoteContractOption3
                            .IgnoreExceptionsOnSetMethods = True
                            .SetQuoteContractID = dt.Rows(0).Item("QuoteContractID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetQuoteContractReference = dt.Rows(0).Item("QuoteContractReference")
                            .SetQuoteContractStatusID = dt.Rows(0).Item("QuoteContractStatusID")
                            .QuoteContractDate = CDate(dt.Rows(0).Item("QuoteContractDate"))
                            .SetQuoteContractPrice = dt.Rows(0).Item("QuoteContractPrice")
                            .SetReasonForReject = dt.Rows(0).Item("ReasonForReject")

                        End With
                        oQuoteContractOption3.Exists = True
                        Return oQuoteContractOption3
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [QuoteContractOption3_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOption3_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oQuoteContractOption3 As QuoteContractOption3) As QuoteContractOption3
                _database.ClearParameter()
                AddQuoteContractOption3ParametersToCommand(oQuoteContractOption3)

                oQuoteContractOption3.SetQuoteContractID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOption3_Insert"))
                oQuoteContractOption3.Exists = True
                Return oQuoteContractOption3
            End Function

            Public Sub [Update](ByVal oQuoteContractOption3 As QuoteContractOption3)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", oQuoteContractOption3.QuoteContractID, True)
                AddQuoteContractOption3ParametersToCommand(oQuoteContractOption3)
                _database.ExecuteSP_NO_Return("QuoteContractOption3_Update")
            End Sub

            Private Sub AddQuoteContractOption3ParametersToCommand(ByRef oQuoteContractOption3 As QuoteContractOption3)
                With _database
                    .AddParameter("@CustomerID", oQuoteContractOption3.CustomerID, True)
                    .AddParameter("@QuoteContractReference", oQuoteContractOption3.QuoteContractReference, True)
                    .AddParameter("@QuoteContractStatusID", oQuoteContractOption3.QuoteContractStatusID, True)
                    .AddParameter("@QuoteContractDate", oQuoteContractOption3.QuoteContractDate, True)
                    .AddParameter("@QuoteContractPrice", oQuoteContractOption3.QuoteContractPrice, True)
                    .AddParameter("@ReasonForReject", oQuoteContractOption3.ReasonForReject, True)
                End With
            End Sub

            Public Function QuoteContractCalculatedTotal(ByVal QuoteContractID As Integer) As Double
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID, True)

                Return Entity.Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("QuoteContractOption3CalculatedTotal"))
            End Function

#End Region

        End Class

    End Namespace

End Namespace


