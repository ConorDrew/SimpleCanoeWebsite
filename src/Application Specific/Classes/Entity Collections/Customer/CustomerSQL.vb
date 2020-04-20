Namespace Entity

    Namespace Customers

        Public Class CustomerSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal CustomerID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.ExecuteSP_NO_Return("Customer_Delete")
            End Sub

            Public Function [Customer_Get](ByVal CustomerID As Integer) As Customer
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oCustomer As New Customer
                        With oCustomer
                            .IgnoreExceptionsOnSetMethods = True
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetRegionID = dt.Rows(0).Item("RegionID")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetAccountNumber = dt.Rows(0).Item("AccountNumber")
                            .SetStatus = dt.Rows(0).Item("Status")
                            .SetCustomerTypeID = dt.Rows(0).Item("CustomerTypeID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetAcceptChargesChanges = dt.Rows(0).Item("AcceptChargesChanges")
                            .SetMainContractorDiscount = dt.Rows(0).Item("MainContractorDiscount")
                            If Not IsDBNull(dt.Rows(0).Item("Logo")) Then
                                .Logo = CType(dt.Rows(0).Item("Logo"), Byte())
                            End If
                            .SetPoNumReqd = dt.Rows(0).Item("CustomerPoNumReqd")
                            .SetJobPriorityMandatory = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("JobPriorityMandatory"))
                            .SetNominal = Sys.Helper.MakeStringValid(dt.Rows(0).Item("Nominal"))
                            .SetOverrideDept = dt.Rows(0).Item("OverrideDept")
                            .SetTerms = dt.Rows(0).Item("Terms")
                            .SetSuperBook = dt.Rows(0).Item("SuperBook")
                            .SetSummerServ = dt.Rows(0).Item("SummerServ")
                            .SetWinterServ = dt.Rows(0).Item("WinterServ")
                            .SetAlertEmail = dt.Rows(0).Item("AlertEmail")
                            .SetMOTStyleService = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("MOTStyleService"))
                            .SetIsOutOfScope = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("IsOutOfScope"))
                            .SetIsPFH = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("IsPFH"))
                            .SetJobSpendLimit = Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("JobSpendLimit"))
                        End With
                        oCustomer.Exists = True
                        Return oCustomer
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Customer_Get_ByOrderID](ByVal orderId As Integer) As Customer
                _database.ClearParameter()
                _database.AddParameter("@OrderID", orderId)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_Get_ByOrderID")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oCustomer As New Customer
                        With oCustomer
                            .IgnoreExceptionsOnSetMethods = True
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetRegionID = dt.Rows(0).Item("RegionID")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetAccountNumber = dt.Rows(0).Item("AccountNumber")
                            .SetStatus = dt.Rows(0).Item("Status")
                            .SetCustomerTypeID = dt.Rows(0).Item("CustomerTypeID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetAcceptChargesChanges = dt.Rows(0).Item("AcceptChargesChanges")
                            .SetMainContractorDiscount = dt.Rows(0).Item("MainContractorDiscount")
                            If Not IsDBNull(dt.Rows(0).Item("Logo")) Then
                                .Logo = CType(dt.Rows(0).Item("Logo"), Byte())
                            End If
                            .SetPoNumReqd = dt.Rows(0).Item("CustomerPoNumReqd")
                            .SetJobPriorityMandatory = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("JobPriorityMandatory"))
                            .SetNominal = Sys.Helper.MakeStringValid(dt.Rows(0).Item("Nominal"))
                            .SetOverrideDept = dt.Rows(0).Item("OverrideDept")
                            .SetTerms = dt.Rows(0).Item("Terms")
                            .SetSuperBook = dt.Rows(0).Item("SuperBook")
                            .SetSummerServ = dt.Rows(0).Item("SummerServ")
                            .SetWinterServ = dt.Rows(0).Item("WinterServ")
                            .SetAlertEmail = dt.Rows(0).Item("AlertEmail")
                            .SetMOTStyleService = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("MOTStyleService"))
                            .SetIsOutOfScope = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("IsOutOfScope"))
                            .SetIsPFH = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("IsPFH"))
                            .SetJobSpendLimit = Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("JobSpendLimit"))
                        End With
                        oCustomer.Exists = True
                        Return oCustomer
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Customer_Get_Light](ByVal CustomerID As Integer) As Customer
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_Get_Light")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oCustomer As New Customer
                        With oCustomer
                            .IgnoreExceptionsOnSetMethods = True
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetStatus = dt.Rows(0).Item("Status")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oCustomer.Exists = True
                        Return oCustomer
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Customer_Get_ForSiteID](ByVal SiteID As Integer) As Customer
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_Get_ForSiteID")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oCustomer As New Customer
                        With oCustomer
                            .IgnoreExceptionsOnSetMethods = True
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetRegionID = dt.Rows(0).Item("RegionID")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetAccountNumber = dt.Rows(0).Item("AccountNumber")
                            .SetStatus = dt.Rows(0).Item("Status")
                            .SetCustomerTypeID = dt.Rows(0).Item("CustomerTypeID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetAcceptChargesChanges = dt.Rows(0).Item("AcceptChargesChanges")
                            .SetMainContractorDiscount = dt.Rows(0).Item("MainContractorDiscount")
                            If Not IsDBNull(dt.Rows(0).Item("Logo")) Then
                                .Logo = CType(dt.Rows(0).Item("Logo"), Byte())
                            End If
                            .SetPoNumReqd = dt.Rows(0).Item("CustomerPoNumReqd")
                            .SetJobPriorityMandatory = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("JobPriorityMandatory"))
                            .SetNominal = Sys.Helper.MakeStringValid(dt.Rows(0).Item("Nominal"))
                            .SetOverrideDept = dt.Rows(0).Item("OverrideDept")
                            .SetTerms = dt.Rows(0).Item("Terms")
                            .SetSuperBook = dt.Rows(0).Item("SuperBook")
                            .SetSummerServ = dt.Rows(0).Item("SummerServ")
                            .SetWinterServ = dt.Rows(0).Item("WinterServ")
                            .SetAlertEmail = dt.Rows(0).Item("AlertEmail")
                            .SetMOTStyleService = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("MOTStyleService"))
                            .SetIsOutOfScope = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("IsOutOfScope"))
                            .SetIsPFH = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("IsPFH"))
                            .SetJobSpendLimit = Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("JobSpendLimit"))
                        End With
                        oCustomer.Exists = True
                        Return oCustomer
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Customer_GetForOrder](ByVal OrderID As Integer) As Customer
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerOrder_GetForOrder")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oCustomer As New Customer
                        With oCustomer
                            .IgnoreExceptionsOnSetMethods = True
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetRegionID = dt.Rows(0).Item("RegionID")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetAccountNumber = dt.Rows(0).Item("AccountNumber")
                            .SetStatus = dt.Rows(0).Item("Status")
                            .SetCustomerTypeID = dt.Rows(0).Item("CustomerTypeID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetAcceptChargesChanges = dt.Rows(0).Item("AcceptChargesChanges")
                            .SetMainContractorDiscount = dt.Rows(0).Item("MainContractorDiscount")
                            If Not IsDBNull(dt.Rows(0).Item("Logo")) Then
                                .Logo = CType(dt.Rows(0).Item("Logo"), Byte())
                            End If
                            .SetPoNumReqd = dt.Rows(0).Item("CustomerPoNumReqd")
                            .SetOverrideDept = dt.Rows(0).Item("OverrideDept")
                            .SetSuperBook = dt.Rows(0).Item("SuperBook")
                            .SetSummerServ = dt.Rows(0).Item("SummerServ")
                            .SetWinterServ = dt.Rows(0).Item("WinterServ")
                            .SetAlertEmail = dt.Rows(0).Item("AlertEmail")
                            .SetMOTStyleService = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("MOTStyleService"))
                            .SetIsOutOfScope = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("IsOutOfScope"))
                            .SetIsPFH = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("IsPFH"))
                            .SetJobSpendLimit = Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("JobSpendLimit"))
                        End With
                        oCustomer.Exists = True
                        Return oCustomer
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [CustomerType_GetAll_Promotions](ByVal CustomerTypeID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerTypeID", CustomerTypeID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_GetPromotion_ForType")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCustomer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Customer_GetAll_Light](ByVal userId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@UserID", userId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_GetAll_Light_Mk1")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCustomer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Site_Search_JobWizard](ByVal userId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@UserID", userId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Site_Search_JobWizard")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCustomer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oCustomer As Customer) As Customer
                _database.ClearParameter()
                AddCustomerParametersToCommand(oCustomer)
                _database.AddParameter("@CustomerAddedByUserID", loggedInUser.UserID, True)
                oCustomer.SetCustomerID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Customer_Insert"))
                oCustomer.Exists = True
                DB.CustomerScheduleOfRate.Insert_Defaults(oCustomer.CustomerID)
                Return oCustomer
            End Function

            Public Sub [Update](ByVal oCustomer As Customer)
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", oCustomer.CustomerID, True)
                AddCustomerParametersToCommand(oCustomer)
                _database.ExecuteSP_NO_Return("Customer_Update")
            End Sub

            Public Function [Customer_Search](ByVal criteria As String, ByVal userId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", criteria, True)
                _database.AddParameter("@UserID", userId, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_SearchList_Mk1")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCustomer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Customer_GetAll_Sites](ByVal customerId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", customerId, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_GetAll_Sites")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
                Return New DataView(dt)
            End Function

            Private Sub AddCustomerParametersToCommand(ByRef oCustomer As Customer)
                With _database
                    .AddParameter("@Name", oCustomer.Name, True)
                    .AddParameter("@RegionID", oCustomer.RegionID, True)
                    .AddParameter("@Notes", oCustomer.Notes, True)
                    .AddParameter("@AccountNumber", oCustomer.AccountNumber, True)
                    .AddParameter("@Status", oCustomer.Status, True)
                    .AddParameter("@CustomerTypeID", oCustomer.CustomerTypeID, True)
                    .AddParameter("@AcceptChargesChanges", oCustomer.AcceptChargesChanges, True)
                    .AddParameter("@MainContractorDiscount", oCustomer.MainContractorDiscount, True)
                    .AddParameter("@Logo", oCustomer.Logo, True)
                    .AddParameter("@CustomerPoNumReqd", oCustomer.PoNumReqd, True)
                    .AddParameter("@JobPriorityMandatory", oCustomer.JobPriorityMandatory, True)
                    .AddParameter("@Nominal", oCustomer.Nominal, True)
                    .AddParameter("@OverrideDept", oCustomer.OverrideDept, True)
                    .AddParameter("@Terms", oCustomer.Terms, True)
                    .AddParameter("@SuperBook", oCustomer.SuperBook, True)
                    .AddParameter("@SummerServ", oCustomer.SummerServ, True)
                    .AddParameter("@WinterServ", oCustomer.WinterServ, True)
                    .AddParameter("@AlertEmail", oCustomer.AlertEmail, True)
                    .AddParameter("@MOTStyleService", oCustomer.MOTStyleService, True)
                    .AddParameter("@IsOutOfScope", oCustomer.IsOutOfScope, True)
                    .AddParameter("@IsPFH", oCustomer.IsPFH, True)
                    Dim spendLimit As Object = If(oCustomer.JobSpendLimit > 0, CObj(oCustomer.JobSpendLimit), DBNull.Value)
                    .AddParameter("@JobSpendLimit", spendLimit, True)
                End With
            End Sub

            Public Function [Customer_Contracts_GetAll](ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_Contract_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Function [Priorities_Get_For_CustomerID](ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Priorities_Get_For_CustomerID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)

            End Function

            Public Function [Requirements_Get_For_CustomerID](ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Requirements_Get_For_CustomerID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)
            End Function

            Public Function [Priorities_Get_For_CustomerID_Active](ByVal CustomerID As Integer, Optional ByVal ManagerID As Integer = 0) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.AddParameter("@ManagerID", ManagerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Priorities_Get_For_CustomerID_Active")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
                Return New DataView(dt)

            End Function

            Public Function [CustomerPriority_Get](ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerPriorties_Get")
                Return New DataView(dt)
            End Function

            Public Function [Customer_EngineerRaise_Get](ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerRaise_ForCustomer")
                Return New DataView(dt)
            End Function

            Public Function [Customer_EngineerRaise_Insert](ByVal CustomerID As Integer, ByVal EngineerID As Integer, ByVal Super As Boolean) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.AddParameter("@EngineerID", EngineerID, True)
                _database.AddParameter("@Super", Super, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerRaise_Insert")
                Return New DataView(dt)
            End Function

            Public Function [Customer_EngineerRaise_Update](ByVal CustomerID As Integer, ByVal EngineerID As Integer, ByVal Super As Boolean, ByVal RaiseJobCustomerEngineerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.AddParameter("@EngineerID", EngineerID, True)
                _database.AddParameter("@RaiseJobCustomerEngineerID", RaiseJobCustomerEngineerID, True)
                _database.AddParameter("@Super", Super, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerRaise_Update")
                Return New DataView(dt)
            End Function

            Public Sub [Customer_EngineerRaise_Delete](ByVal RaiseJobCustomerEngineerID As Integer)
                _database.ClearParameter()
                DB.ExecuteScalar("Update tblRaiseJobCustomerEngineer SET Deleted = 1, LastChanged = GETDATE() Where RaiseJobCustomerEngineerID = " & RaiseJobCustomerEngineerID)
            End Sub

            Public Sub [Priorities_Delete_For_Customer](ByVal CustomerID As Integer)
                _database.ClearParameter()

                DB.ExecuteScalar("DELETE FROM tblCustomerPriority Where CustomerID = " & CustomerID)

            End Sub

            Public Sub [Requirements_Delete_For_Customer](ByVal CustomerID As Integer)
                _database.ClearParameter()

                DB.ExecuteScalar("DELETE FROM tblCustomerRequirements Where CustomerID = " & CustomerID)

            End Sub

            Public Sub [Priorities_Insert_For_Customer](ByVal CustomerID As Integer, ByVal ManagerID As Integer, ByVal TargetHours As Integer, ByVal IncludeWeekends As Integer, ByVal IncludeBH As Integer, ByVal IncludeOOH As Integer)
                _database.ClearParameter()
                DB.ExecuteScalar("INSERT INTO tblCustomerPriority VALUES (" & CustomerID & "," & ManagerID & "," & TargetHours & "," & IncludeWeekends & "," & IncludeBH & "," & IncludeOOH & ")")
            End Sub

            Public Sub [Requirements_Insert_For_Customer](ByVal CustomerID As Integer, ByVal ManagerID As Integer)
                _database.ClearParameter()

                DB.ExecuteScalar("INSERT INTO tblCustomerRequirements VALUES (" & CustomerID & "," & ManagerID & ")")

            End Sub

            Public Sub [Part_Insert_For_Customer](ByVal CustomerID As Integer, ByVal PartSupplierID As Integer)

                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.AddParameter("@PartSupplierID", PartSupplierID, True)
                Dim siteCount As Integer = _database.SP_ExecuteScalar("Customer_Part_Insert")

            End Sub

            Public Sub [Part_Delete_For_Customer](ByVal CustomerID As Integer, ByVal PartSupplierID As Integer)
                _database.ClearParameter()

                DB.ExecuteScalar("UPDATE tblCustomerPart SET Deleted = 1 WHERE CUSTOMERID = " & CustomerID & " AND PartSupplierID = " & PartSupplierID & "")

            End Sub

            ''' <summary>
            ''' Gets the count of active sites in relation to the customer
            ''' </summary>
            ''' <param name="CustomerID"></param>
            ''' <returns></returns>
            Public Function [Customer_GetActiveSiteCount](ByVal CustomerID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim siteCount As Integer = _database.SP_ExecuteScalar("Customer_GetActiveSiteCount")
                Return siteCount
            End Function

#End Region

#Region "Customer Fuel Letter Day"

            Public Function [CustomerServiceProcess_Get_ForCustomer](ByVal customerId As Integer) As CustomerServiceProcess
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", customerId, True)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerServiceProcess_Get_ForCustomer")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oServiceProcess As New CustomerServiceProcess
                        With oServiceProcess
                            .IgnoreExceptionsOnSetMethods = True
                            If dt.Columns.Contains("CustomerServiceProcessID") Then .SetCustomerServiceProcessID = dt.Rows(0).Item("CustomerServiceProcessID")
                            If dt.Columns.Contains("CustomerID") Then .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            If dt.Columns.Contains("Letter1") Then .SetLetter1 = dt.Rows(0).Item("Letter1")
                            If dt.Columns.Contains("Letter2") Then .SetLetter2 = dt.Rows(0).Item("Letter2")
                            If dt.Columns.Contains("Letter3") Then .SetLetter3 = dt.Rows(0).Item("Letter3")
                            If dt.Columns.Contains("Appointment1") Then .SetAppointment1 = dt.Rows(0).Item("Appointment1")
                            If dt.Columns.Contains("Appointment2") Then .SetAppointment2 = dt.Rows(0).Item("Appointment2")
                            If dt.Columns.Contains("Appointment3") Then .SetAppointment3 = dt.Rows(0).Item("Appointment3")
                            If dt.Columns.Contains("DateAdded") Then .DateAdded = dt.Rows(0).Item("DateAdded")
                            If dt.Columns.Contains("AddedBy") Then .SetAddedBy = dt.Rows(0).Item("AddedBy")
                            If dt.Columns.Contains("Template1") AndAlso Not IsDBNull(dt.Rows(0)("Template1")) Then .Template1 = dt.Rows(0)("Template1")
                            If dt.Columns.Contains("Template2") AndAlso Not IsDBNull(dt.Rows(0)("Template2")) Then .Template2 = dt.Rows(0)("Template2")
                            If dt.Columns.Contains("Template3") AndAlso Not IsDBNull(dt.Rows(0)("Template3")) Then .Template3 = dt.Rows(0)("Template3")
                            If dt.Columns.Contains("PatchCheckTemplate") AndAlso Not IsDBNull(dt.Rows(0)("PatchCheckTemplate")) Then .PatchCheckTemplate = dt.Rows(0)("PatchCheckTemplate")
                        End With
                        oServiceProcess.Exists = True
                        Return oServiceProcess
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [CustomerServiceProcess_Update](ByVal serviceProcess As CustomerServiceProcess) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@CustomerServiceProcessID", serviceProcess.CustomerServiceProcessID, True)
                _database.AddParameter("@CustomerID", serviceProcess.CustomerID, True)
                _database.AddParameter("@Letter1", serviceProcess.Letter1, True)
                _database.AddParameter("@Letter2", serviceProcess.Letter2, True)
                _database.AddParameter("@Letter3", serviceProcess.Letter3, True)
                _database.AddParameter("@Appointment1", serviceProcess.Appointment1, True)
                _database.AddParameter("@Appointment2", serviceProcess.Appointment2, True)
                _database.AddParameter("@Appointment3", serviceProcess.Appointment3, True)
                _database.AddParameter("@AddedBy", loggedInUser.UserID, True)
                _database.AddParameter("@Template1", serviceProcess.Template1, True)
                _database.AddParameter("@Template2", serviceProcess.Template2, True)
                _database.AddParameter("@Template3", serviceProcess.Template3, True)
                _database.AddParameter("@PatchCheckTemplate", serviceProcess.PatchCheckTemplate, True)
                Return CBool(_database.ExecuteSP_ReturnRowsAffected("CustomerServiceProcess_Update") = 1)
            End Function

            Public Function [CustomerServiceProcess_Delete](ByVal customerServiceProcessId As Integer) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@CustomerServiceProcessID", customerServiceProcessId, True)
                Return CBool(_database.ExecuteSP_ReturnRowsAffected("CustomerServiceProcess_Delete") = 1)
            End Function

#End Region

        End Class

    End Namespace

End Namespace