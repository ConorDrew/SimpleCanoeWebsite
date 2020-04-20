Imports System.Data.SqlClient

Namespace Entity

    Namespace InvoiceToBeRaiseds

        Public Class InvoiceToBeRaisedSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal InvoiceToBeRaisedID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@InvoiceToBeRaisedID", InvoiceToBeRaisedID, True)
                _database.ExecuteSP_NO_Return("InvoiceToBeRaised_Delete")
            End Sub

            Public Function [InvoiceToBeRaised_Get](ByVal InvoiceToBeRaisedID As Integer) As InvoiceToBeRaised
                _database.ClearParameter()
                _database.AddParameter("@InvoiceToBeRaisedID", InvoiceToBeRaisedID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceToBeRaised_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oInvoiceToBeRaised As New InvoiceToBeRaised
                        With oInvoiceToBeRaised
                            .IgnoreExceptionsOnSetMethods = True
                            .SetInvoiceToBeRaisedID = dt.Rows(0).Item("InvoiceToBeRaisedID")
                            .RaiseDate = CDate(dt.Rows(0).Item("RaiseDate"))
                            .SetInvoiceTypeID = dt.Rows(0).Item("InvoiceTypeID")
                            .SetLinkID = dt.Rows(0).Item("LinkID")
                            .SetAddressTypeID = dt.Rows(0).Item("AddressTypeID")
                            .SetAddressLinkID = dt.Rows(0).Item("AddressLinkID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetPaymentTermID = dt.Rows(0).Item("PaymentTermID")
                        End With
                        oInvoiceToBeRaised.Exists = True
                        Return oInvoiceToBeRaised
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function InvoiceToBeRaised_Get_By_LinkID(ByVal LinkID As Integer,
                            ByVal InvoiceType As Entity.Sys.Enums.InvoiceType) As InvoiceToBeRaised
                _database.ClearParameter()
                _database.AddParameter("@LinkID", LinkID)
                _database.AddParameter("@InvoiceTypeID", CInt(InvoiceType))

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceToBeRaised_Get_By_LinkID")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oInvoiceToBeRaised As New InvoiceToBeRaised
                        With oInvoiceToBeRaised
                            .IgnoreExceptionsOnSetMethods = True
                            .SetInvoiceToBeRaisedID = dt.Rows(0).Item("InvoiceToBeRaisedID")
                            .RaiseDate = CDate(dt.Rows(0).Item("RaiseDate"))
                            .SetInvoiceTypeID = dt.Rows(0).Item("InvoiceTypeID")
                            .SetLinkID = dt.Rows(0).Item("LinkID")
                            .SetAddressTypeID = dt.Rows(0).Item("AddressTypeID")
                            .SetAddressLinkID = dt.Rows(0).Item("AddressLinkID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetTaxRateID = dt.Rows(0).Item("TAXRateID")
                            .SetPaymentTermID = dt.Rows(0).Item("PaymentTermID")
                        End With
                        oInvoiceToBeRaised.Exists = True
                        Return oInvoiceToBeRaised
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [InvoiceToBeRaised_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceToBeRaised_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiceToBeRaised.ToString
                Return New DataView(dt)
            End Function

            Public Function Invoices_GetAll_Manager(ByVal RaiseFrom As DateTime,
                                                                ByVal RaiseTo As DateTime) As DataView
                _database.ClearParameter()
                _database.AddParameter("@RaiseFrom", CDate(Format(RaiseFrom, "dd/MM/yyyy") & " 00:00:00"), True)
                _database.AddParameter("@RaiseTo", CDate(Format(RaiseTo, "dd/MM/yyyy") & " 23:59:59"), True)
                _database.AddParameter("@InvoiceEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice), True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@OrderInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Order), True)
                _database.AddParameter("@ContractOpt1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)
                _database.AddParameter("@ContractOpt2Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option2), True)
                _database.AddParameter("@ContractOpt3Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option3), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Invoices_GetAll_Manager")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString
                Return New DataView(dt)
            End Function

            Public Function Invoices_GetAll_For_EngineerVisitChargeID(ByVal EngineerVisitChargeID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoiceEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice), True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@EngineerVisitChargeID", EngineerVisitChargeID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Invoices_GetAll_For_EngineerVisitChargeID")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString
                Return New DataView(dt)
            End Function

            Public Function Invoices_GetAll_For_JobID(ByVal JobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoiceEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice), True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@JobID", JobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Invoices_GetAll_For_JobID")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oInvoiceToBeRaised As InvoiceToBeRaised) As InvoiceToBeRaised
                _database.ClearParameter()
                AddInvoiceToBeRaisedParametersToCommand(oInvoiceToBeRaised)
                _database.AddParameter("@RecordAddedBy", loggedInUser.UserID, True)
                _database.AddParameter("@RecordAddedOn", Now, True)
                oInvoiceToBeRaised.SetInvoiceToBeRaisedID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("InvoiceToBeRaised_Insert"))
                oInvoiceToBeRaised.Exists = True
                Return oInvoiceToBeRaised
            End Function

            Public Function [InvoiceToBeRaised_Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceToBeRaised_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiceToBeRaised.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Update](ByVal oInvoiceToBeRaised As InvoiceToBeRaised)
                _database.ClearParameter()
                _database.AddParameter("@InvoiceToBeRaisedID", oInvoiceToBeRaised.InvoiceToBeRaisedID, True)
                AddInvoiceToBeRaisedParametersToCommand(oInvoiceToBeRaised)
                _database.ExecuteSP_NO_Return("InvoiceToBeRaised_Update")
            End Sub

            Private Sub AddInvoiceToBeRaisedParametersToCommand(ByRef oInvoiceToBeRaised As InvoiceToBeRaised)
                With _database
                    .AddParameter("@RaiseDate", oInvoiceToBeRaised.RaiseDate, True)
                    .AddParameter("@InvoiceTypeID", oInvoiceToBeRaised.InvoiceTypeID, True)
                    .AddParameter("@LinkID", oInvoiceToBeRaised.LinkID, True)
                    .AddParameter("@AddressTypeID", oInvoiceToBeRaised.AddressTypeID, True)
                    .AddParameter("@AddressLinkID", oInvoiceToBeRaised.AddressLinkID, True)
                    .AddParameter("@CustomerID", oInvoiceToBeRaised.CustomerID, True)
                    .AddParameter("@TAXRateID", oInvoiceToBeRaised.TaxRateID, True)
                    .AddParameter("@TermID", oInvoiceToBeRaised.PaymentTermID, True)
                    .AddParameter("@PaidByID", oInvoiceToBeRaised.PaidByID, True)

                End With
            End Sub

            Public Function InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(ByVal JobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoiceTypeIDEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@JobID", JobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString
                Return New DataView(dt)
            End Function

            Public Function InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(ByVal JobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoiceTypeIDEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@JobID", JobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString
                Return New DataView(dt)
            End Function

            Public Function InvoicesToBeRaised_GetAmount_ByInvoiceToBeRaisedID(ByVal InvoiceToBeRaisedID As Integer) As Double
                _database.ClearParameter()
                _database.AddParameter("@InvoiceTypeIDEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@InvoiceToBeRaisedID", InvoiceToBeRaisedID, True)

                Return Entity.Sys.Helper.MakeDoubleValid(DB.ExecuteSP_OBJECT("InvoicesToBeRaised_GetAmount_ByInvoiceToBeRaisedID"))
            End Function

            Public Function Invoices_GetAll_ForDirectDebitRpt(ByVal DateFrom As DateTime, ByVal DateTo As DateTime) As DataView
                _database.ClearParameter()
                _database.AddParameter("@RaiseFrom", CDate(Format(DateFrom, "dd/MM/yyyy") & " 00:00:00"), True)
                _database.AddParameter("@RaiseTo", CDate(Format(DateTo, "dd/MM/yyyy") & " 23:59:59"), True)
                _database.AddParameter("@ContractOpt1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Invoices_GetAll_ForDirectDebitRpt")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiceToBeRaised.ToString
                Return New DataView(dt)
            End Function

            Public Function [InvoicesToBeRaised_Update_PaymentID](ByVal InvoiceToBeRaisedID As Integer,
                                                                  ByVal paymentTermID As Integer) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@InvoiceToBeRaisedID", InvoiceToBeRaisedID, True)
                _database.AddParameter("@PaymentTermID", paymentTermID, True)

                Return CBool(_database.ExecuteSP_OBJECT("InvoicesToBeRaised_Update_PaymentID") = 1)
            End Function

#End Region

        End Class

    End Namespace

End Namespace