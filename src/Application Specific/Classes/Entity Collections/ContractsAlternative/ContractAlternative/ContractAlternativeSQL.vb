Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractsAlternative

        Public Class ContractAlternativeSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Get](ByVal ContractID As Integer) As ContractAlternative
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternative_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContract As New ContractAlternative
                        With oContract
                            .IgnoreExceptionsOnSetMethods = True
                            .SetContractID = dt.Rows(0).Item("ContractID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetContractReference = dt.Rows(0).Item("ContractReference")
                            .ContractStartDate = CDate(dt.Rows(0).Item("ContractStartDate"))
                            .ContractEndDate = CDate(dt.Rows(0).Item("ContractEndDate"))
                            .SetContractStatusID = dt.Rows(0).Item("ContractStatusID")
                            .SetContractPrice = dt.Rows(0).Item("ContractPrice")
                            .SetQuoteContractID = dt.Rows(0).Item("QuoteContractID")
                            .SetInvoiceFrequencyID = dt.Rows(0).Item("InvoiceFrequencyID")
                            .SetInvoiceAddressID = dt.Rows(0).Item("InvoiceAddressID")
                            .SetInvoiceAddressTypeID = dt.Rows(0).Item("InvoiceAddressTypeID")
                            .FirstInvoiceDate = dt.Rows(0).Item("FirstInvoiceDate")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oContract.Exists = True
                        Return oContract
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function GetAll_For_Customer_ID(ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternative_GetAll_For_Customer_ID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblDocuments.ToString
                Return New DataView(dt)
            End Function

            Public Function ContractAlternativeCalculatedTotal(ByVal ContractID As Integer) As Double
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)

                Return Entity.Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("ContractAlternativeCalculatedTotal"))
            End Function

            Public Function Get_For_Quote_ID(ByVal QuoteContractID As Integer) As ContractAlternative
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternative_Get_For_Quote_ID")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContract As New ContractAlternative
                        With oContract
                            .IgnoreExceptionsOnSetMethods = True
                            .SetContractID = dt.Rows(0).Item("ContractID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetContractReference = dt.Rows(0).Item("ContractReference")
                            .ContractStartDate = CDate(dt.Rows(0).Item("ContractStartDate"))
                            .ContractEndDate = CDate(dt.Rows(0).Item("ContractEndDate"))
                            .SetContractStatusID = dt.Rows(0).Item("ContractStatusID")
                            .SetContractPrice = dt.Rows(0).Item("ContractPrice")
                            .SetQuoteContractID = dt.Rows(0).Item("QuoteContractID")
                            .SetInvoiceFrequencyID = dt.Rows(0).Item("InvoiceFrequencyID")
                            .SetInvoiceAddressID = dt.Rows(0).Item("InvoiceAddressID")
                            .SetInvoiceAddressTypeID = dt.Rows(0).Item("InvoiceAddressTypeID")
                            .FirstInvoiceDate = dt.Rows(0).Item("FirstInvoiceDate")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oContract.Exists = True
                        Return oContract
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function Insert(ByVal oContract As ContractAlternative) As ContractAlternative
                _database.ClearParameter()
                AddContractParametersToCommand(oContract)

                oContract.SetContractID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternative_Insert"))
                oContract.Exists = True
                Return oContract
            End Function

            Public Sub Update(ByVal oContract As ContractAlternative)
                _database.ClearParameter()
                _database.AddParameter("@ContractID", oContract.ContractID, True)
                AddContractParametersToCommand(oContract)
                _database.ExecuteSP_NO_Return("ContractAlternative_Update")
            End Sub

            Public Sub Delete(ByVal ContractID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)
                _database.AddParameter("@ContractOpt2Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option2), True)
                _database.ExecuteSP_NO_Return("ContractAlternative_Delete")
            End Sub

            Private Sub AddContractParametersToCommand(ByRef oContract As ContractAlternative)
                With _database
                    .AddParameter("@CustomerID", oContract.CustomerID, True)
                    .AddParameter("@ContractReference", oContract.ContractReference, True)
                    .AddParameter("@ContractStartDate", oContract.ContractStartDate, True)
                    .AddParameter("@ContractEndDate", oContract.ContractEndDate, True)
                    .AddParameter("@ContractStatusID", oContract.ContractStatusID, True)
                    .AddParameter("@ContractPrice", oContract.ContractPrice, True)
                    .AddParameter("@QuoteContractID", oContract.QuoteContractID, True)
                    .AddParameter("@InvoiceFrequencyID", oContract.InvoiceFrequencyID, True)
                    .AddParameter("@InvoiceAddressID", oContract.InvoiceAddressID, True)
                    .AddParameter("@InvoiceAddressTypeID", oContract.InvoiceAddressTypeID, True)
                    .AddParameter("@FirstInvoiceDate", oContract.FirstInvoiceDate, True)
                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


