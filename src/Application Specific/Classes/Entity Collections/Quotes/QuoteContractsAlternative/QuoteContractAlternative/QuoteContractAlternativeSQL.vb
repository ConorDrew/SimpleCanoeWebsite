Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractAlternatives

        Public Class QuoteContractAlternativeSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function CalculatedTotal(ByVal QuoteContractID As Integer) As Double
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID, True)

                Return Entity.Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativeCalculatedTotal"))
            End Function

            Public Function VisitFrequency_Get() As DataTable
                _database.ClearParameter()
                Return _database.ExecuteSP_DataTable("VisitFrequency_Get")
            End Function

            Public Function [Get](ByVal QuoteContractID As Integer) As QuoteContractAlternative
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternative_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oQuoteContract As New QuoteContractAlternative
                        With oQuoteContract
                            .IgnoreExceptionsOnSetMethods = True
                            .SetQuoteContractID = dt.Rows(0).Item("QuoteContractID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetQuoteContractReference = dt.Rows(0).Item("QuoteContractReference")
                            .QuoteContractDate = CDate(dt.Rows(0).Item("QuoteContractDate"))
                            .ContractStart = CDate(dt.Rows(0).Item("ContractStart"))
                            .ContractEnd = CDate(dt.Rows(0).Item("ContractEnd"))
                            .SetQuoteContractStatusID = dt.Rows(0).Item("QuoteContractStatusID")
                            .SetQuoteContractPrice = dt.Rows(0).Item("QuoteContractPrice")
                            .SetReasonForReject = dt.Rows(0).Item("ReasonForReject")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oQuoteContract.Exists = True
                        Return oQuoteContract
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function Insert(ByVal oQuoteContract As QuoteContractAlternative) As QuoteContractAlternative
                _database.ClearParameter()
                AddQuoteContractParametersToCommand(oQuoteContract)

                oQuoteContract.SetQuoteContractID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternative_Insert"))
                oQuoteContract.Exists = True
                Return oQuoteContract
            End Function

            Public Sub Update(ByVal oQuoteContract As QuoteContractAlternative)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", oQuoteContract.QuoteContractID, True)
                AddQuoteContractParametersToCommand(oQuoteContract)
                _database.ExecuteSP_NO_Return("QuoteContractAlternative_Update")
            End Sub

            Public Sub Delete(ByVal QuoteContractID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID, True)
                _database.ExecuteSP_NO_Return("QuoteContractAlternative_Delete")
            End Sub

            Private Sub AddQuoteContractParametersToCommand(ByRef oQuoteContract As QuoteContractAlternative)
                With _database
                    .AddParameter("@CustomerID", oQuoteContract.CustomerID, True)
                    .AddParameter("@QuoteContractReference", oQuoteContract.QuoteContractReference, True)
                    .AddParameter("@QuoteContractDate", oQuoteContract.QuoteContractDate, True)
                    .AddParameter("@ContractStart", oQuoteContract.ContractStart, True)
                    .AddParameter("@ContractEnd", oQuoteContract.ContractEnd, True)
                    .AddParameter("@QuoteContractStatusID", oQuoteContract.QuoteContractStatusID, True)
                    .AddParameter("@QuoteContractPrice", oQuoteContract.QuoteContractPrice, True)
                    .AddParameter("@ReasonForReject", oQuoteContract.ReasonForReject, True)

                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


