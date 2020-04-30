using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Customers
    {
        public class CustomerSQL
        {
            private Sys.Database _database;

            public CustomerSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.ExecuteSP_NO_Return("Customer_Delete");
            }

            public Customer Customer_Get(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Customer_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oCustomer = new Customer();
                        oCustomer.IgnoreExceptionsOnSetMethods = true;
                        oCustomer.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oCustomer.SetName = dt.Rows[0]["Name"];
                        oCustomer.SetRegionID = dt.Rows[0]["RegionID"];
                        oCustomer.SetNotes = dt.Rows[0]["Notes"];
                        oCustomer.SetAccountNumber = dt.Rows[0]["AccountNumber"];
                        oCustomer.SetStatus = dt.Rows[0]["Status"];
                        oCustomer.SetCustomerTypeID = dt.Rows[0]["CustomerTypeID"];
                        oCustomer.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oCustomer.SetAcceptChargesChanges = dt.Rows[0]["AcceptChargesChanges"];
                        oCustomer.SetMainContractorDiscount = dt.Rows[0]["MainContractorDiscount"];
                        if (!Information.IsDBNull(dt.Rows[0]["Logo"]))
                        {
                            oCustomer.Logo = (byte[])dt.Rows[0]["Logo"];
                        }

                        oCustomer.SetPoNumReqd = dt.Rows[0]["CustomerPoNumReqd"];
                        oCustomer.SetJobPriorityMandatory = Sys.Helper.MakeBooleanValid(dt.Rows[0]["JobPriorityMandatory"]);
                        oCustomer.SetNominal = Sys.Helper.MakeStringValid(dt.Rows[0]["Nominal"]);
                        oCustomer.SetOverrideDept = dt.Rows[0]["OverrideDept"];
                        oCustomer.SetTerms = dt.Rows[0]["Terms"];
                        oCustomer.SetSuperBook = dt.Rows[0]["SuperBook"];
                        oCustomer.SetSummerServ = dt.Rows[0]["SummerServ"];
                        oCustomer.SetWinterServ = dt.Rows[0]["WinterServ"];
                        oCustomer.SetAlertEmail = dt.Rows[0]["AlertEmail"];
                        oCustomer.SetMOTStyleService = Sys.Helper.MakeBooleanValid(dt.Rows[0]["MOTStyleService"]);
                        oCustomer.SetIsOutOfScope = Sys.Helper.MakeBooleanValid(dt.Rows[0]["IsOutOfScope"]);
                        oCustomer.SetIsPFH = Sys.Helper.MakeBooleanValid(dt.Rows[0]["IsPFH"]);
                        oCustomer.SetJobSpendLimit = Sys.Helper.MakeDoubleValid(dt.Rows[0]["JobSpendLimit"]);
                        oCustomer.Exists = true;
                        return oCustomer;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public Customer Customer_Get_ByOrderID(int orderId)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", orderId);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Customer_Get_ByOrderID");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oCustomer = new Customer();
                        oCustomer.IgnoreExceptionsOnSetMethods = true;
                        oCustomer.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oCustomer.SetName = dt.Rows[0]["Name"];
                        oCustomer.SetRegionID = dt.Rows[0]["RegionID"];
                        oCustomer.SetNotes = dt.Rows[0]["Notes"];
                        oCustomer.SetAccountNumber = dt.Rows[0]["AccountNumber"];
                        oCustomer.SetStatus = dt.Rows[0]["Status"];
                        oCustomer.SetCustomerTypeID = dt.Rows[0]["CustomerTypeID"];
                        oCustomer.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oCustomer.SetAcceptChargesChanges = dt.Rows[0]["AcceptChargesChanges"];
                        oCustomer.SetMainContractorDiscount = dt.Rows[0]["MainContractorDiscount"];
                        if (!Information.IsDBNull(dt.Rows[0]["Logo"]))
                        {
                            oCustomer.Logo = (byte[])dt.Rows[0]["Logo"];
                        }

                        oCustomer.SetPoNumReqd = dt.Rows[0]["CustomerPoNumReqd"];
                        oCustomer.SetJobPriorityMandatory = Sys.Helper.MakeBooleanValid(dt.Rows[0]["JobPriorityMandatory"]);
                        oCustomer.SetNominal = Sys.Helper.MakeStringValid(dt.Rows[0]["Nominal"]);
                        oCustomer.SetOverrideDept = dt.Rows[0]["OverrideDept"];
                        oCustomer.SetTerms = dt.Rows[0]["Terms"];
                        oCustomer.SetSuperBook = dt.Rows[0]["SuperBook"];
                        oCustomer.SetSummerServ = dt.Rows[0]["SummerServ"];
                        oCustomer.SetWinterServ = dt.Rows[0]["WinterServ"];
                        oCustomer.SetAlertEmail = dt.Rows[0]["AlertEmail"];
                        oCustomer.SetMOTStyleService = Sys.Helper.MakeBooleanValid(dt.Rows[0]["MOTStyleService"]);
                        oCustomer.SetIsOutOfScope = Sys.Helper.MakeBooleanValid(dt.Rows[0]["IsOutOfScope"]);
                        oCustomer.SetIsPFH = Sys.Helper.MakeBooleanValid(dt.Rows[0]["IsPFH"]);
                        oCustomer.SetJobSpendLimit = Sys.Helper.MakeDoubleValid(dt.Rows[0]["JobSpendLimit"]);
                        oCustomer.Exists = true;
                        return oCustomer;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public Customer Customer_Get_Light(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Customer_Get_Light");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oCustomer = new Customer();
                        oCustomer.IgnoreExceptionsOnSetMethods = true;
                        oCustomer.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oCustomer.SetName = dt.Rows[0]["Name"];
                        oCustomer.SetStatus = dt.Rows[0]["Status"];
                        oCustomer.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oCustomer.Exists = true;
                        return oCustomer;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public Customer Customer_Get_ForSiteID(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Customer_Get_ForSiteID");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oCustomer = new Customer();
                        oCustomer.IgnoreExceptionsOnSetMethods = true;
                        oCustomer.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oCustomer.SetName = dt.Rows[0]["Name"];
                        oCustomer.SetRegionID = dt.Rows[0]["RegionID"];
                        oCustomer.SetNotes = dt.Rows[0]["Notes"];
                        oCustomer.SetAccountNumber = dt.Rows[0]["AccountNumber"];
                        oCustomer.SetStatus = dt.Rows[0]["Status"];
                        oCustomer.SetCustomerTypeID = dt.Rows[0]["CustomerTypeID"];
                        oCustomer.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oCustomer.SetAcceptChargesChanges = dt.Rows[0]["AcceptChargesChanges"];
                        oCustomer.SetMainContractorDiscount = dt.Rows[0]["MainContractorDiscount"];
                        if (!Information.IsDBNull(dt.Rows[0]["Logo"]))
                        {
                            oCustomer.Logo = (byte[])dt.Rows[0]["Logo"];
                        }

                        oCustomer.SetPoNumReqd = dt.Rows[0]["CustomerPoNumReqd"];
                        oCustomer.SetJobPriorityMandatory = Sys.Helper.MakeBooleanValid(dt.Rows[0]["JobPriorityMandatory"]);
                        oCustomer.SetNominal = Sys.Helper.MakeStringValid(dt.Rows[0]["Nominal"]);
                        oCustomer.SetOverrideDept = dt.Rows[0]["OverrideDept"];
                        oCustomer.SetTerms = dt.Rows[0]["Terms"];
                        oCustomer.SetSuperBook = dt.Rows[0]["SuperBook"];
                        oCustomer.SetSummerServ = dt.Rows[0]["SummerServ"];
                        oCustomer.SetWinterServ = dt.Rows[0]["WinterServ"];
                        oCustomer.SetAlertEmail = dt.Rows[0]["AlertEmail"];
                        oCustomer.SetMOTStyleService = Sys.Helper.MakeBooleanValid(dt.Rows[0]["MOTStyleService"]);
                        oCustomer.SetIsOutOfScope = Sys.Helper.MakeBooleanValid(dt.Rows[0]["IsOutOfScope"]);
                        oCustomer.SetIsPFH = Sys.Helper.MakeBooleanValid(dt.Rows[0]["IsPFH"]);
                        oCustomer.SetJobSpendLimit = Sys.Helper.MakeDoubleValid(dt.Rows[0]["JobSpendLimit"]);
                        oCustomer.Exists = true;
                        return oCustomer;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public Customer Customer_GetForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("CustomerOrder_GetForOrder");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oCustomer = new Customer();
                        oCustomer.IgnoreExceptionsOnSetMethods = true;
                        oCustomer.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oCustomer.SetName = dt.Rows[0]["Name"];
                        oCustomer.SetRegionID = dt.Rows[0]["RegionID"];
                        oCustomer.SetNotes = dt.Rows[0]["Notes"];
                        oCustomer.SetAccountNumber = dt.Rows[0]["AccountNumber"];
                        oCustomer.SetStatus = dt.Rows[0]["Status"];
                        oCustomer.SetCustomerTypeID = dt.Rows[0]["CustomerTypeID"];
                        oCustomer.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oCustomer.SetAcceptChargesChanges = dt.Rows[0]["AcceptChargesChanges"];
                        oCustomer.SetMainContractorDiscount = dt.Rows[0]["MainContractorDiscount"];
                        if (!Information.IsDBNull(dt.Rows[0]["Logo"]))
                        {
                            oCustomer.Logo = (byte[])dt.Rows[0]["Logo"];
                        }

                        oCustomer.SetPoNumReqd = dt.Rows[0]["CustomerPoNumReqd"];
                        oCustomer.SetOverrideDept = dt.Rows[0]["OverrideDept"];
                        oCustomer.SetSuperBook = dt.Rows[0]["SuperBook"];
                        oCustomer.SetSummerServ = dt.Rows[0]["SummerServ"];
                        oCustomer.SetWinterServ = dt.Rows[0]["WinterServ"];
                        oCustomer.SetAlertEmail = dt.Rows[0]["AlertEmail"];
                        oCustomer.SetMOTStyleService = Sys.Helper.MakeBooleanValid(dt.Rows[0]["MOTStyleService"]);
                        oCustomer.SetIsOutOfScope = Sys.Helper.MakeBooleanValid(dt.Rows[0]["IsOutOfScope"]);
                        oCustomer.SetIsPFH = Sys.Helper.MakeBooleanValid(dt.Rows[0]["IsPFH"]);
                        oCustomer.SetJobSpendLimit = Sys.Helper.MakeDoubleValid(dt.Rows[0]["JobSpendLimit"]);
                        oCustomer.Exists = true;
                        return oCustomer;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public DataView CustomerType_GetAll_Promotions(int CustomerTypeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerTypeID", CustomerTypeID, true);
                var dt = _database.ExecuteSP_DataTable("Customer_GetPromotion_ForType");
                dt.TableName = Sys.Enums.TableNames.tblCustomer.ToString();
                return new DataView(dt);
            }

            public DataView Customer_GetAll_Light(int userId)
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", userId, true);
                var dt = _database.ExecuteSP_DataTable("Customer_GetAll_Light_Mk1");
                dt.TableName = Sys.Enums.TableNames.tblCustomer.ToString();
                return new DataView(dt);
            }

            public Customer Insert(Customer oCustomer)
            {
                _database.ClearParameter();
                AddCustomerParametersToCommand(ref oCustomer);
                _database.AddParameter("@CustomerAddedByUserID", App.loggedInUser.UserID, true);
                oCustomer.SetCustomerID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Customer_Insert"));
                oCustomer.Exists = true;
                App.DB.CustomerScheduleOfRate.Insert_Defaults(oCustomer.CustomerID);
                return oCustomer;
            }

            public void Update(Customer oCustomer)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", oCustomer.CustomerID, true);
                AddCustomerParametersToCommand(ref oCustomer);
                _database.ExecuteSP_NO_Return("Customer_Update");
            }

            public DataView Customer_Search(string criteria, int userId)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", criteria, true);
                _database.AddParameter("@UserID", userId, true);
                var dt = _database.ExecuteSP_DataTable("Customer_SearchList_Mk1");
                dt.TableName = Sys.Enums.TableNames.tblCustomer.ToString();
                return new DataView(dt);
            }

            public DataView Customer_GetAll_Sites(int customerId)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", customerId, true);
                var dt = _database.ExecuteSP_DataTable("Customer_GetAll_Sites");
                dt.TableName = Sys.Enums.TableNames.tblSite.ToString();
                return new DataView(dt);
            }

            private void AddCustomerParametersToCommand(ref Customer oCustomer)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Name", oCustomer.Name, true);
                    withBlock.AddParameter("@RegionID", oCustomer.RegionID, true);
                    withBlock.AddParameter("@Notes", oCustomer.Notes, true);
                    withBlock.AddParameter("@AccountNumber", oCustomer.AccountNumber, true);
                    withBlock.AddParameter("@Status", oCustomer.Status, true);
                    withBlock.AddParameter("@CustomerTypeID", oCustomer.CustomerTypeID, true);
                    withBlock.AddParameter("@AcceptChargesChanges", oCustomer.AcceptChargesChanges, true);
                    withBlock.AddParameter("@MainContractorDiscount", oCustomer.MainContractorDiscount, true);
                    withBlock.AddParameter("@Logo", oCustomer.Logo, true);
                    withBlock.AddParameter("@CustomerPoNumReqd", oCustomer.PoNumReqd, true);
                    withBlock.AddParameter("@JobPriorityMandatory", oCustomer.JobPriorityMandatory, true);
                    withBlock.AddParameter("@Nominal", oCustomer.Nominal, true);
                    withBlock.AddParameter("@OverrideDept", oCustomer.OverrideDept, true);
                    withBlock.AddParameter("@Terms", oCustomer.Terms, true);
                    withBlock.AddParameter("@SuperBook", oCustomer.SuperBook, true);
                    withBlock.AddParameter("@SummerServ", oCustomer.SummerServ, true);
                    withBlock.AddParameter("@WinterServ", oCustomer.WinterServ, true);
                    withBlock.AddParameter("@AlertEmail", oCustomer.AlertEmail, true);
                    withBlock.AddParameter("@MOTStyleService", oCustomer.MOTStyleService, true);
                    withBlock.AddParameter("@IsOutOfScope", oCustomer.IsOutOfScope, true);
                    withBlock.AddParameter("@IsPFH", oCustomer.IsPFH, true);
                    var spendLimit = oCustomer.JobSpendLimit > 0 ? (object)oCustomer.JobSpendLimit : DBNull.Value;
                    withBlock.AddParameter("@JobSpendLimit", spendLimit, true);
                }
            }

            public DataView Customer_Contracts_GetAll(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("Customer_Contract_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataView Priorities_Get_For_CustomerID(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("Priorities_Get_For_CustomerID");
                dt.TableName = Sys.Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataView Requirements_Get_For_CustomerID(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("Requirements_Get_For_CustomerID");
                dt.TableName = Sys.Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataView Priorities_Get_For_CustomerID_Active(int CustomerID, int ManagerID = 0)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.AddParameter("@ManagerID", ManagerID, true);
                var dt = _database.ExecuteSP_DataTable("Priorities_Get_For_CustomerID_Active");
                dt.TableName = Sys.Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataView CustomerPriority_Get(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("CustomerPriorties_Get");
                return new DataView(dt);
            }

            public DataView Customer_EngineerRaise_Get(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerRaise_ForCustomer");
                return new DataView(dt);
            }

            public DataView Customer_EngineerRaise_Insert(int CustomerID, int EngineerID, bool Super)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.AddParameter("@EngineerID", EngineerID, true);
                _database.AddParameter("@Super", Super, true);
                var dt = _database.ExecuteSP_DataTable("EngineerRaise_Insert");
                return new DataView(dt);
            }

            public DataView Customer_EngineerRaise_Update(int CustomerID, int EngineerID, bool Super, int RaiseJobCustomerEngineerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.AddParameter("@EngineerID", EngineerID, true);
                _database.AddParameter("@RaiseJobCustomerEngineerID", RaiseJobCustomerEngineerID, true);
                _database.AddParameter("@Super", Super, true);
                var dt = _database.ExecuteSP_DataTable("EngineerRaise_Update");
                return new DataView(dt);
            }

            public void Customer_EngineerRaise_Delete(int RaiseJobCustomerEngineerID)
            {
                _database.ClearParameter();
                App.DB.ExecuteScalar("Update tblRaiseJobCustomerEngineer SET Deleted = 1, LastChanged = GETDATE() Where RaiseJobCustomerEngineerID = " + RaiseJobCustomerEngineerID);
            }

            public void Priorities_Delete_For_Customer(int CustomerID)
            {
                _database.ClearParameter();
                App.DB.ExecuteScalar("DELETE FROM tblCustomerPriority Where CustomerID = " + CustomerID);
            }

            public void Requirements_Delete_For_Customer(int CustomerID)
            {
                _database.ClearParameter();
                App.DB.ExecuteScalar("DELETE FROM tblCustomerRequirements Where CustomerID = " + CustomerID);
            }

            public void Priorities_Insert_For_Customer(int CustomerID, int ManagerID, int TargetHours, int IncludeWeekends, int IncludeBH, int IncludeOOH)
            {
                _database.ClearParameter();
                App.DB.ExecuteScalar("INSERT INTO tblCustomerPriority VALUES (" + CustomerID + "," + ManagerID + "," + TargetHours + "," + IncludeWeekends + "," + IncludeBH + "," + IncludeOOH + ")");
            }

            public void Requirements_Insert_For_Customer(int CustomerID, int ManagerID)
            {
                _database.ClearParameter();
                App.DB.ExecuteScalar("INSERT INTO tblCustomerRequirements VALUES (" + CustomerID + "," + ManagerID + ")");
            }

            public void Part_Insert_For_Customer(int CustomerID, int PartSupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.AddParameter("@PartSupplierID", PartSupplierID, true);
                int siteCount = Conversions.ToInteger(_database.SP_ExecuteScalar("Customer_Part_Insert"));
            }

            public void Part_Delete_For_Customer(int CustomerID, int PartSupplierID)
            {
                _database.ClearParameter();
                App.DB.ExecuteScalar("UPDATE tblCustomerPart SET Deleted = 1 WHERE CUSTOMERID = " + CustomerID + " AND PartSupplierID = " + PartSupplierID + "");
            }

            /// <summary>
            /// Gets the count of active sites in relation to the customer
            /// </summary>
            /// <param name="CustomerID"></param>
            /// <returns></returns>
            public int Customer_GetActiveSiteCount(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                int siteCount = Conversions.ToInteger(_database.SP_ExecuteScalar("Customer_GetActiveSiteCount"));
                return siteCount;
            }

            public CustomerServiceProcess CustomerServiceProcess_Get_ForCustomer(int customerId)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", customerId, true);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("CustomerServiceProcess_Get_ForCustomer");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oServiceProcess = new CustomerServiceProcess();
                        oServiceProcess.IgnoreExceptionsOnSetMethods = true;
                        if (dt.Columns.Contains("CustomerServiceProcessID"))
                            oServiceProcess.SetCustomerServiceProcessID = dt.Rows[0]["CustomerServiceProcessID"];
                        if (dt.Columns.Contains("CustomerID"))
                            oServiceProcess.SetCustomerID = dt.Rows[0]["CustomerID"];
                        if (dt.Columns.Contains("Letter1"))
                            oServiceProcess.SetLetter1 = dt.Rows[0]["Letter1"];
                        if (dt.Columns.Contains("Letter2"))
                            oServiceProcess.SetLetter2 = dt.Rows[0]["Letter2"];
                        if (dt.Columns.Contains("Letter3"))
                            oServiceProcess.SetLetter3 = dt.Rows[0]["Letter3"];
                        if (dt.Columns.Contains("Appointment1"))
                            oServiceProcess.SetAppointment1 = dt.Rows[0]["Appointment1"];
                        if (dt.Columns.Contains("Appointment2"))
                            oServiceProcess.SetAppointment2 = dt.Rows[0]["Appointment2"];
                        if (dt.Columns.Contains("Appointment3"))
                            oServiceProcess.SetAppointment3 = dt.Rows[0]["Appointment3"];
                        if (dt.Columns.Contains("DateAdded"))
                            oServiceProcess.DateAdded = Conversions.ToDate(dt.Rows[0]["DateAdded"]);
                        if (dt.Columns.Contains("AddedBy"))
                            oServiceProcess.SetAddedBy = dt.Rows[0]["AddedBy"];
                        if (dt.Columns.Contains("Template1") && !Information.IsDBNull(dt.Rows[0]["Template1"]))
                            oServiceProcess.Template1 = (byte[])dt.Rows[0]["Template1"];
                        if (dt.Columns.Contains("Template2") && !Information.IsDBNull(dt.Rows[0]["Template2"]))
                            oServiceProcess.Template2 = (byte[])dt.Rows[0]["Template2"];
                        if (dt.Columns.Contains("Template3") && !Information.IsDBNull(dt.Rows[0]["Template3"]))
                            oServiceProcess.Template3 = (byte[])dt.Rows[0]["Template3"];
                        if (dt.Columns.Contains("PatchCheckTemplate") && !Information.IsDBNull(dt.Rows[0]["PatchCheckTemplate"]))
                            oServiceProcess.PatchCheckTemplate = (byte[])dt.Rows[0]["PatchCheckTemplate"];
                        oServiceProcess.Exists = true;
                        return oServiceProcess;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public bool CustomerServiceProcess_Update(CustomerServiceProcess serviceProcess)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerServiceProcessID", serviceProcess.CustomerServiceProcessID, true);
                _database.AddParameter("@CustomerID", serviceProcess.CustomerID, true);
                _database.AddParameter("@Letter1", serviceProcess.Letter1, true);
                _database.AddParameter("@Letter2", serviceProcess.Letter2, true);
                _database.AddParameter("@Letter3", serviceProcess.Letter3, true);
                _database.AddParameter("@Appointment1", serviceProcess.Appointment1, true);
                _database.AddParameter("@Appointment2", serviceProcess.Appointment2, true);
                _database.AddParameter("@Appointment3", serviceProcess.Appointment3, true);
                _database.AddParameter("@AddedBy", App.loggedInUser.UserID, true);
                _database.AddParameter("@Template1", serviceProcess.Template1, true);
                _database.AddParameter("@Template2", serviceProcess.Template2, true);
                _database.AddParameter("@Template3", serviceProcess.Template3, true);
                _database.AddParameter("@PatchCheckTemplate", serviceProcess.PatchCheckTemplate, true);
                return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("CustomerServiceProcess_Update") == 1);
            }

            public bool CustomerServiceProcess_Delete(int customerServiceProcessId)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerServiceProcessID", customerServiceProcessId, true);
                return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("CustomerServiceProcess_Delete") == 1);
            }
        }
    }
}