Namespace Entity

    Namespace SalesCredits

        Public Class SalesCreditSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [SalesCredit_Get](ByVal SalesCreditID As Integer) As SalesCredit
                _database.ClearParameter()
                _database.AddParameter("@SalesCreditID", SalesCreditID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SalesCredit_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oSC As New SalesCredit
                        With oSC
                            .IgnoreExceptionsOnSetMethods = True
                            .SetAmountCredited = dt.Rows(0).Item("AmountCredited")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetTaxCodeID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("TaxCodeID"))
                            .SetNominalCode = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("NominalCode"))
                            .SetDepartmentRef = dt.Rows(0).Item("DepartmentRef")
                            .SetExtraRef = dt.Rows(0).Item("ExtraRef")
                            .SetReasonForCredit = dt.Rows(0).Item("ReasonForCredit")
                            .SetRequestedBy = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("RequestedBy"))
                            .SetInvoicedLineID = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("InvoicedLineID"))
                            .DateCredited = dt.Rows(0).Item("DateCredited")
                            .SetCreditReference = Sys.Helper.MakeStringValid(dt.Rows(0).Item("CreditReference"))

                        End With
                        oSC.Exists = True
                        Return oSC
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [SalesCredit_Get_For_InvoicedLine](ByVal SalesCreditID As Integer) As SalesCredit
                _database.ClearParameter()
                _database.AddParameter("@InvoicedLineID", SalesCreditID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SalesCredit_Get_For_InvoicedLine")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oSC As New SalesCredit
                        With oSC
                            .IgnoreExceptionsOnSetMethods = True
                            .SetAmountCredited = dt.Rows(0).Item("AmountCredited")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetTaxCodeID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("TaxCodeID"))
                            .SetNominalCode = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("NominalCode"))
                            .SetDepartmentRef = dt.Rows(0).Item("DepartmentRef")
                            .SetExtraRef = dt.Rows(0).Item("ExtraRef")
                            .SetReasonForCredit = dt.Rows(0).Item("ReasonForCredit")
                            .SetRequestedBy = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("RequestedBy"))
                            .SetInvoicedLineID = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("InvoicedLineID"))
                            .SetCreditReference = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("CreditReference"))
                            .DateCredited = dt.Rows(0).Item("DateCredited")
                            .SetAccountNumber = dt.Rows(0).Item("AccountNumber")

                        End With
                        oSC.Exists = True
                        Return oSC
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [PartsToBeCredited_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
                Return New DataView(dt)
            End Function

            Public Function PartsToBeCredited_Get_PartsCreditID(ByVal PartCreditID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartCreditID", PartCreditID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_PartsCreditID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
                Return New DataView(dt)
            End Function

            Public Function PartsToBeCredited_Get_OrderID(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_Order")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
                Return New DataView(dt)
            End Function

            Public Function PartsToBeCredited_Get_OrderPartID(ByVal OrderPartID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderPartID", OrderPartID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_OrderPart")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oSalesCredited As SalesCredit) As SalesCredit
                _database.ClearParameter()
                AddPartsToBeCreditedParametersToCommand(oSalesCredited)
                _database.AddParameter("@DateCredited", oSalesCredited.DateCredited, True)

                oSalesCredited.SetSalesCreditID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SalesCredit_Insert"))
                oSalesCredited.Exists = True
                Return oSalesCredited
            End Function

            Private Sub AddPartsToBeCreditedParametersToCommand(ByRef oPartsToBeCredited As SalesCredit)
                With _database
                    .AddParameter("@AmountCredited", oPartsToBeCredited.AmountCredited, True)
                    .AddParameter("@Notes", oPartsToBeCredited.Notes, True)
                    .AddParameter("@TaxCodeID", oPartsToBeCredited.TaxCodeID, True)
                    .AddParameter("@NominalCode", oPartsToBeCredited.NominalCode, True)
                    .AddParameter("@DepartmentRef", oPartsToBeCredited.DepartmentRef, True)
                    .AddParameter("@ExtraRef", oPartsToBeCredited.ExtraRef, True)
                    .AddParameter("@Reason", oPartsToBeCredited.ReasonForCredit, True)
                    .AddParameter("@RequestBy", oPartsToBeCredited.RequestedBy, True)
                    .AddParameter("@InvoicedLineID", oPartsToBeCredited.InvoicedLineID, True)
                    .AddParameter("@CreditReference", oPartsToBeCredited.CreditReference, True)
                    .AddParameter("@AddedBy", oPartsToBeCredited.AddedByUser, True)
                    .AddParameter("@AccountNumber", oPartsToBeCredited.AccountNumber, True)
                End With
            End Sub

            Public Function [InvoicedLines_GetAll_ByInvoicedID](ByVal InvoicedID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoicedID", InvoicedID, True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@OrderInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Order), True)
                _database.AddParameter("@Contract_Option1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByInvoicedID_ForCredits")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoicedLines.ToString
                Return New DataView(dt)
            End Function

            Public Function [InvoicedLines_GetAll_ByInvoicedIDRows](ByVal Invoiced As DataRow()) As DataView
                Dim masterdt As New DataTable
                For Each dr As DataRow In Invoiced

                    _database.ClearParameter()
                    _database.AddParameter("@InvoicedLineID", dr("InvoicedLineID"), True)
                    _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                    _database.AddParameter("@OrderInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Order), True)
                    _database.AddParameter("@Contract_Option1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)
                    Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByInvoicedLineID_ForCredits")
                    dt.TableName = Entity.Sys.Enums.TableNames.tblInvoicedLines.ToString
                    masterdt.Merge(dt)
                Next

                Return New DataView(masterdt)
            End Function

            Public Function [InvoicedLines_GetAll_ByInvoicedNumber](ByVal InvoicedNumber As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoicedNumber", InvoicedNumber, True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@OrderInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Order), True)
                _database.AddParameter("@Contract_Option1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_CreditsByInvoiceNumber")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoicedLines.ToString
                Return New DataView(dt)
            End Function

            Public Function [InvoicedLines_GetAll_ByCreditReference](ByVal creditReference As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CreditReference", creditReference, True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@OrderInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Order), True)
                _database.AddParameter("@Contract_Option1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByCreditReference")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoicedLines.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace