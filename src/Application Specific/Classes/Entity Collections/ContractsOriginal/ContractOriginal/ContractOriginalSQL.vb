Imports System.Data.SqlClient
Imports FSM.Entity.Sys

Namespace Entity

    Namespace ContractsOriginal

        Public Class ContractOriginalSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Get](ByVal ContractID As Integer) As ContractOriginal
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginal_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContract As New ContractOriginal
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
                            .SetContractTypeID = dt.Rows(0).Item("ContractTypeID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetCheque = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Cheque"))
                            .SetCreditCard = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("CreditCard"))
                            .SetDirectDebit = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("DirectDebit"))
                            .SetBankName = Sys.Helper.MakeStringValid(dt.Rows(0).Item("BankName"))
                            .SetAccountNumber = Sys.Helper.MakeStringValid(dt.Rows(0).Item("AccountNumber"))
                            .SetSortCode = Sys.Helper.MakeStringValid(dt.Rows(0).Item("SortCode"))
                            .SetGasSupplyPipework = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("GasSupplyPipework"))
                            If IsDBNull((dt.Rows(0).Item("CancelledDate"))) Then
                                .CancelledDate = Date.MinValue
                            Else
                                .CancelledDate = Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("CancelledDate"))
                            End If
                            .SetReasonID = Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("ReasonID"))
                            .SetPlumbingDrainage = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("PlumbingDrainage"))
                            .SetWindowLockPest = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("WindowLockPest"))
                            .SetPoNumber = Sys.Helper.MakeStringValid(dt.Rows(0).Item("PONumber"))
                            .SetAnnual = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Annual"))
                            .SetDiscountID = dt.Rows(0).Item("DiscountID")
                            .SetDoNotRenew = dt.Rows(0).Item("DoNotRenew")
                            .SetDDMSRef = dt.Rows(0).Item("DDMSRef")
                            .SetNotes = dt.Rows(0).Item("Notes")
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

            Public Function ContractCalculatedTotal(ByVal ContractID As Integer) As Double
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)

                Return Entity.Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("ContractOriginalCalculatedTotal"))
            End Function

            Public Function [Contract_GetAll_Renewal]() As DataView

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contract_GetAll_Renewal")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Function [Contract_Get_Renewal](ByVal ContractID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contract_Get_Renewal")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Function Get_For_Quote_ID(ByVal QuoteContractID As Integer) As ContractOriginal
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginal_Get_For_Quote_ID")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContract As New ContractOriginal
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
                            .FirstInvoiceDate = dt.Rows(0).Item("FirstInvoiceDate")
                            .SetInvoiceAddressID = dt.Rows(0).Item("InvoiceAddressID")
                            .SetInvoiceAddressTypeID = dt.Rows(0).Item("InvoiceAddressTypeID")
                            .SetContractTypeID = dt.Rows(0).Item("ContractTypeID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetCheque = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Cheque"))
                            .SetCreditCard = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("CreditCard"))
                            .SetDirectDebit = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("DirectDebit"))
                            .SetBankName = Sys.Helper.MakeStringValid(dt.Rows(0).Item("BankName"))
                            .SetAccountNumber = Sys.Helper.MakeStringValid(dt.Rows(0).Item("AccountNumber"))
                            .SetSortCode = Sys.Helper.MakeStringValid(dt.Rows(0).Item("SortCode"))
                            .SetGasSupplyPipework = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("GasSupplyPipework"))
                            .SetPlumbingDrainage = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("PlumbingDrainage"))
                            .SetWindowLockPest = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("WindowLockPest"))
                            .SetPoNumber = Sys.Helper.MakeStringValid(dt.Rows(0).Item("PONumber"))
                            .SetDiscountID = dt.Rows(0).Item("DiscountID")
                            .SetDoNotRenew = dt.Rows(0).Item("DoNotRenew")
                            .SetDDMSRef = dt.Rows(0).Item("DDMSRef")
                            .SetNotes = dt.Rows(0).Item("Notes")
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

            Public Function Insert(ByVal oContract As ContractOriginal) As ContractOriginal
                _database.ClearParameter()
                AddContractParametersToCommand(oContract)

                oContract.SetContractID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginal_Insert"))
                oContract.Exists = True
                Return oContract
            End Function

            Public Sub Insert_UpgradedFrom(ByVal contractId As Integer, ByVal upgradedFrom As String)
                _database.ClearParameter()
                _database.AddParameter("@ContractID", contractId, True)
                _database.AddParameter("@UpgradedFrom", upgradedFrom, True)
                _database.ExecuteSP_NO_Return("ContractOriginal_Insert_UpgradedFrom")
            End Sub

            Public Sub Update(ByVal oContract As ContractOriginal)
                _database.ClearParameter()
                _database.AddParameter("@ContractID", oContract.ContractID, True)
                If oContract.CancelledDate = Date.MinValue Then
                    _database.AddParameter("@CancelledDate", DBNull.Value, True)
                Else
                    _database.AddParameter("@CancelledDate", oContract.CancelledDate, True)
                End If
                _database.AddParameter("@ReasonID", oContract.ReasonID, True)

                AddContractParametersToCommand(oContract)
                _database.ExecuteSP_NO_Return("ContractOriginal_Update")
            End Sub

            Public Sub Delete(ByVal ContractID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)
                _database.AddParameter("@ContractOpt1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)
                _database.ExecuteSP_NO_Return("ContractOriginal_Delete")
            End Sub

            Public Function Transfer(ByVal ContractID As Integer, ByVal ContractSiteID As Integer, ByVal EffDate As Date) As Object
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                _database.AddParameter("@EffDate", EffDate, True)
                Return _database.ExecuteSP_OBJECT("ContractOriginal_Transfer")
            End Function

            Private Sub AddContractParametersToCommand(ByRef oContract As ContractOriginal)
                With _database
                    .AddParameter("@CustomerID", oContract.CustomerID, True)
                    .AddParameter("@ContractReference", oContract.ContractReference, True)
                    .AddParameter("@ContractStartDate", oContract.ContractStartDate, True)
                    .AddParameter("@ContractEndDate", oContract.ContractEndDate, True)
                    .AddParameter("@ContractStatusID", oContract.ContractStatusID, True)
                    .AddParameter("@ContractPrice", oContract.ContractPrice, True)
                    .AddParameter("@QuoteContractID", oContract.QuoteContractID, True)
                    .AddParameter("@InvoiceFrequencyID", oContract.InvoiceFrequencyID, True)
                    .AddParameter("@FirstInvoiceDate", oContract.FirstInvoiceDate, True)
                    .AddParameter("@InvoiceAddressID", oContract.InvoiceAddressID, True)
                    .AddParameter("@InvoiceAddressTypeID", oContract.InvoiceAddressTypeID, True)
                    .AddParameter("@ContractTypeID", oContract.ContractTypeID, True)

                    .AddParameter("@Cheque", oContract.Cheque, True)
                    .AddParameter("@CreditCard", oContract.CreditCard, True)
                    .AddParameter("@DirectDebit", oContract.DirectDebit, True)
                    .AddParameter("@BankName", oContract.BankName, True)
                    .AddParameter("@AccountNumber", oContract.AccountNumber, True)
                    .AddParameter("@SortCode", oContract.SortCode, True)
                    .AddParameter("@GasSupplyPipework", oContract.GasSupplyPipework, True)
                    .AddParameter("@PlumbingDrainage", oContract.PlumbingDrainage, True)
                    .AddParameter("@WindowLockPest", oContract.WindowLockPest, True)
                    .AddParameter("@PONumber", oContract.PoNumber, True)
                    .AddParameter("@Annual", oContract.Annual, True)
                    .AddParameter("@AfterVAT", oContract.ContractPriceAfterVAT, True)
                    .AddParameter("@DiscountID", oContract.DiscountID, True)
                    .AddParameter("@DoNotRenew", oContract.DoNotRenew, True)
                    .AddParameter("@DDMSRef", oContract.DDMSRef, True)
                    .AddParameter("@PreviousInvoiceFrequencyID", oContract.PreviousInvoiceFrequencyID, True)
                    .AddParameter("@Notes", oContract.Notes, True)

                End With
            End Sub

            Public Function Get_Current_ForSite(ByVal SiteID As Integer) As ContractOriginal
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginal_Get_Current_ForSite")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContract As New ContractOriginal
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
                            .SetContractTypeID = dt.Rows(0).Item("ContractTypeID")
                            .SetContractType = dt.Rows(0).Item("Type")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetGasSupplyPipework = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("GasSupplyPipework"))
                            .SetPlumbingDrainage = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("PlumbingDrainage"))
                            .SetWindowLockPest = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("WindowLockPest"))
                            .SetPoNumber = Sys.Helper.MakeStringValid(dt.Rows(0).Item("PONumber"))
                            .SetDiscountID = dt.Rows(0).Item("DiscountID")
                            .SetDoNotRenew = dt.Rows(0).Item("DoNotRenew")
                            .SetDDMSRef = dt.Rows(0).Item("DDMSRef")
                            .SetNotes = dt.Rows(0).Item("Notes")
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

            Public Function [GetAll_ForSite](ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contract_GetAll_ForSite")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Function [GetAll]() As DataView
                _database.ClearParameter()

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginal_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Function [GetAllActive]() As DataView
                _database.ClearParameter()

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginal_GetAll_Active")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Function [GetAll_ForSite_Active](ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contract_GetAll_ForSite_Active")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Function [GetAssetsForContract](ByVal ContractSiteID As Integer, ByVal MainApp As Boolean) As DataView

                Dim dt As DataTable = _database.ExecuteWithReturn("Select AssetID,Product From tblContractOriginalSiteAsset Where ContractSiteID =" & ContractSiteID & " AND (PrimaryAsset = '" & MainApp & "' ) ")

                Return New DataView(dt)

            End Function

            Public Function [Get_NotProcessed](ByVal ContractID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contract_Get_NotProcessed")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Function ContractOriginalSiteAsset_GetAll_SiteID(ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalSiteAsset_GetAll_SiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Function ProcessContract(ByVal contractId As Integer) As DataTable
                Dim dtContracts As DataTable = DB.ContractOriginal.Get_NotProcessed(contractId).Table
                dtContracts.Columns.Add("InvoiceNumber")
                Try
                    For Each i As DataRow In dtContracts.Rows
                        Dim PayType As String = ""
                        If IsDBNull(i("Type")) Then
                            PayType = ""
                        Else
                            PayType = i("Type")
                        End If

                        Dim printed As String = "0"
                        If Not IsDBNull(i("Printed")) Then
                            printed = i("Printed")
                        End If

                        If printed Or IsDBNull(i("Processed")) Or Helper.MakeBooleanValid(i("Processed")) Then ' added fail for old plans
                            Dim dt As DataTable = DB.ExecuteWithReturn("select * from tblInvoicedLines il INNER join tblInvoiced i on i.InvoicedID = il.InvoicedID WHERE InvoiceToBeRaisedID = " & i("InvoiceToBeRaisedID"))
                            If dt.Rows.Count > 0 Then ' an invoice already exists
                                i("InvoiceNumber") = dt.Rows(0)("InvoiceNumber")
                            End If
                        Else
                            If PayType = "TRANS" Or PayType = "AMEND" Or
                                (PayType = "RENEWAL" And (i("InvoiceFrequencyID") = Entity.Sys.Enums.InvoiceFrequency.AnnuallyDD Or i("InvoiceFrequencyID") = Entity.Sys.Enums.InvoiceFrequency.Monthly)) Or
                                (i("installments") Mod 12 = 0 And i("installments") <> 0) Then
                                'DONT RAISE A FUCKING INVOICE
                            Else
                                Dim dt As DataTable = DB.ExecuteWithReturn("select * from tblInvoicedLines il INNER join tblInvoiced i on i.InvoicedID = il.InvoicedID WHERE InvoiceToBeRaisedID = " & i("InvoiceToBeRaisedID"))
                                If dt.Rows.Count > 0 Then ' an invoice already exists
                                    i("InvoiceNumber") = dt.Rows(0)("InvoiceNumber")
                                Else

                                    Dim inv As New Entity.Invoiceds.Invoiced
                                    Dim invNum As New JobNumber
                                    invNum = DB.Job.GetNextJobNumber(5)

                                    inv.SetInvoiceNumber = invNum.Prefix & invNum.JobNumber
                                    inv.SetRaisedByUserID = loggedInUser.UserID
                                    inv.RaisedDate = i("RaiseDate")
                                    inv.SetVATRateID = DB.VATRatesSQL.VATRates_Get_ByDate(Now)
                                    inv = DB.Invoiced.Insert(inv) 'stop creating for now

                                    Dim invLines As New Entity.InvoicedLiness.InvoicedLines
                                    If i("InvoiceFrequencyID") = Entity.Sys.Enums.InvoiceFrequency.Monthly Then
                                        invLines.SetAmount = (i("FirstAmount") / 1.2)
                                    Else
                                        invLines.SetAmount = (i("ContractPrice"))
                                    End If

                                    invLines.SetInvoicedID = inv.InvoicedID
                                    invLines.SetInvoiceToBeRaisedID = i("InvoiceToBeRaisedID")
                                    invLines = DB.InvoicedLines.Insert(invLines)

                                    i("InvoiceNumber") = inv.InvoiceNumber
                                End If
                            End If
                        End If

                    Next
                    Return dtContracts
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function

#End Region

        End Class

    End Namespace

End Namespace