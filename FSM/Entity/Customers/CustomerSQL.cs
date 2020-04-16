// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Customers.CustomerSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Customers
{
    public class CustomerSQL
    {
        private Database _database;

        public CustomerSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            this._database.ExecuteSP_NO_Return("Customer_Delete", true);
        }

        public Customer Customer_Get(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Customer_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Customer)null;
            Customer customer1 = new Customer();
            Customer customer2 = customer1;
            customer2.IgnoreExceptionsOnSetMethods = true;
            customer2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(CustomerID)]);
            customer2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
            customer2.SetRegionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RegionID"]);
            customer2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            customer2.SetAccountNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AccountNumber"]);
            customer2.SetStatus = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Status"]);
            customer2.SetCustomerTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerTypeID"]);
            customer2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            customer2.SetAcceptChargesChanges = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AcceptChargesChanges"]);
            customer2.SetMainContractorDiscount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MainContractorDiscount"]);
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Logo"])))
                customer2.Logo = (byte[])dataTable.Rows[0]["Logo"];
            customer2.SetPoNumReqd = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerPoNumReqd"]);
            customer2.SetJobPriorityMandatory = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobPriorityMandatory"]));
            customer2.SetNominal = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Nominal"]));
            customer2.SetOverrideDept = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OverrideDept"]);
            customer2.SetTerms = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Terms"]);
            customer2.SetSuperBook = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SuperBook"]);
            customer2.SetSummerServ = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SummerServ"]);
            customer2.SetWinterServ = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WinterServ"]);
            customer2.SetAlertEmail = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AlertEmail"]);
            customer2.SetMOTStyleService = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MOTStyleService"]));
            customer2.SetIsOutOfScope = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IsOutOfScope"]));
            customer2.SetIsPFH = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IsPFH"]));
            customer2.SetJobSpendLimit = (object)Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobSpendLimit"]));
            customer1.Exists = true;
            return customer1;
        }

        public Customer Customer_Get_ByOrderID(int orderId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)orderId, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Customer_Get_ByOrderID), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Customer)null;
            Customer customer1 = new Customer();
            Customer customer2 = customer1;
            customer2.IgnoreExceptionsOnSetMethods = true;
            customer2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
            customer2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
            customer2.SetRegionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RegionID"]);
            customer2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            customer2.SetAccountNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AccountNumber"]);
            customer2.SetStatus = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Status"]);
            customer2.SetCustomerTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerTypeID"]);
            customer2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            customer2.SetAcceptChargesChanges = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AcceptChargesChanges"]);
            customer2.SetMainContractorDiscount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MainContractorDiscount"]);
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Logo"])))
                customer2.Logo = (byte[])dataTable.Rows[0]["Logo"];
            customer2.SetPoNumReqd = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerPoNumReqd"]);
            customer2.SetJobPriorityMandatory = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobPriorityMandatory"]));
            customer2.SetNominal = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Nominal"]));
            customer2.SetOverrideDept = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OverrideDept"]);
            customer2.SetTerms = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Terms"]);
            customer2.SetSuperBook = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SuperBook"]);
            customer2.SetSummerServ = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SummerServ"]);
            customer2.SetWinterServ = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WinterServ"]);
            customer2.SetAlertEmail = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AlertEmail"]);
            customer2.SetMOTStyleService = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MOTStyleService"]));
            customer2.SetIsOutOfScope = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IsOutOfScope"]));
            customer2.SetIsPFH = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IsPFH"]));
            customer2.SetJobSpendLimit = (object)Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobSpendLimit"]));
            customer1.Exists = true;
            return customer1;
        }

        public Customer Customer_Get_Light(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Customer_Get_Light), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Customer)null;
            Customer customer1 = new Customer();
            Customer customer2 = customer1;
            customer2.IgnoreExceptionsOnSetMethods = true;
            customer2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(CustomerID)]);
            customer2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
            customer2.SetStatus = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Status"]);
            customer2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            customer1.Exists = true;
            return customer1;
        }

        public Customer Customer_Get_ForSiteID(int SiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteID", (object)SiteID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Customer_Get_ForSiteID), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Customer)null;
            Customer customer1 = new Customer();
            Customer customer2 = customer1;
            customer2.IgnoreExceptionsOnSetMethods = true;
            customer2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
            customer2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
            customer2.SetRegionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RegionID"]);
            customer2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            customer2.SetAccountNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AccountNumber"]);
            customer2.SetStatus = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Status"]);
            customer2.SetCustomerTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerTypeID"]);
            customer2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            customer2.SetAcceptChargesChanges = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AcceptChargesChanges"]);
            customer2.SetMainContractorDiscount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MainContractorDiscount"]);
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Logo"])))
                customer2.Logo = (byte[])dataTable.Rows[0]["Logo"];
            customer2.SetPoNumReqd = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerPoNumReqd"]);
            customer2.SetJobPriorityMandatory = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobPriorityMandatory"]));
            customer2.SetNominal = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Nominal"]));
            customer2.SetOverrideDept = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OverrideDept"]);
            customer2.SetTerms = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Terms"]);
            customer2.SetSuperBook = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SuperBook"]);
            customer2.SetSummerServ = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SummerServ"]);
            customer2.SetWinterServ = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WinterServ"]);
            customer2.SetAlertEmail = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AlertEmail"]);
            customer2.SetMOTStyleService = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MOTStyleService"]));
            customer2.SetIsOutOfScope = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IsOutOfScope"]));
            customer2.SetIsPFH = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IsPFH"]));
            customer2.SetJobSpendLimit = (object)Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobSpendLimit"]));
            customer1.Exists = true;
            return customer1;
        }

        public Customer Customer_GetForOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("CustomerOrder_GetForOrder", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Customer)null;
            Customer customer1 = new Customer();
            Customer customer2 = customer1;
            customer2.IgnoreExceptionsOnSetMethods = true;
            customer2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
            customer2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
            customer2.SetRegionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RegionID"]);
            customer2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            customer2.SetAccountNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AccountNumber"]);
            customer2.SetStatus = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Status"]);
            customer2.SetCustomerTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerTypeID"]);
            customer2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            customer2.SetAcceptChargesChanges = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AcceptChargesChanges"]);
            customer2.SetMainContractorDiscount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MainContractorDiscount"]);
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Logo"])))
                customer2.Logo = (byte[])dataTable.Rows[0]["Logo"];
            customer2.SetPoNumReqd = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerPoNumReqd"]);
            customer2.SetOverrideDept = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OverrideDept"]);
            customer2.SetSuperBook = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SuperBook"]);
            customer2.SetSummerServ = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SummerServ"]);
            customer2.SetWinterServ = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WinterServ"]);
            customer2.SetAlertEmail = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AlertEmail"]);
            customer2.SetMOTStyleService = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MOTStyleService"]));
            customer2.SetIsOutOfScope = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IsOutOfScope"]));
            customer2.SetIsPFH = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IsPFH"]));
            customer2.SetJobSpendLimit = (object)Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobSpendLimit"]));
            customer1.Exists = true;
            return customer1;
        }

        public DataView CustomerType_GetAll_Promotions(int CustomerTypeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerTypeID", (object)CustomerTypeID, true);
            DataTable table = this._database.ExecuteSP_DataTable("Customer_GetPromotion_ForType", true);
            table.TableName = Enums.TableNames.tblCustomer.ToString();
            return new DataView(table);
        }

        public DataView Customer_GetAll_Light(int userId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)userId, true);
            DataTable table = this._database.ExecuteSP_DataTable("Customer_GetAll_Light_Mk1", true);
            table.TableName = Enums.TableNames.tblCustomer.ToString();
            return new DataView(table);
        }

        public DataView Site_Search_JobWizard(int userId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UserID", (object)userId, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Site_Search_JobWizard), true);
            table.TableName = Enums.TableNames.tblCustomer.ToString();
            return new DataView(table);
        }

        public Customer Insert(Customer oCustomer)
        {
            this._database.ClearParameter();
            this.AddCustomerParametersToCommand(ref oCustomer);
            this._database.AddParameter("@CustomerAddedByUserID", (object)App.loggedInUser.UserID, true);
            oCustomer.SetCustomerID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Customer_Insert", true)));
            oCustomer.Exists = true;
            App.DB.CustomerScheduleOfRate.Insert_Defaults(oCustomer.CustomerID);
            return oCustomer;
        }

        public void Update(Customer oCustomer)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)oCustomer.CustomerID, true);
            this.AddCustomerParametersToCommand(ref oCustomer);
            this._database.ExecuteSP_NO_Return("Customer_Update", true);
        }

        public DataView Customer_Search(string criteria, int userId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SearchString", (object)criteria, true);
            this._database.AddParameter("@UserID", (object)userId, true);
            DataTable table = this._database.ExecuteSP_DataTable("Customer_SearchList_Mk1", true);
            table.TableName = Enums.TableNames.tblCustomer.ToString();
            return new DataView(table);
        }

        public DataView Customer_GetAll_Sites(int customerId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)customerId, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Customer_GetAll_Sites), true);
            table.TableName = Enums.TableNames.tblSite.ToString();
            return new DataView(table);
        }

        private void AddCustomerParametersToCommand(ref Customer oCustomer)
        {
            Database database = this._database;
            database.AddParameter("@Name", (object)oCustomer.Name, true);
            database.AddParameter("@RegionID", (object)oCustomer.RegionID, true);
            database.AddParameter("@Notes", (object)oCustomer.Notes, true);
            database.AddParameter("@AccountNumber", (object)oCustomer.AccountNumber, true);
            database.AddParameter("@Status", (object)oCustomer.Status, true);
            database.AddParameter("@CustomerTypeID", (object)oCustomer.CustomerTypeID, true);
            database.AddParameter("@AcceptChargesChanges", (object)oCustomer.AcceptChargesChanges, true);
            database.AddParameter("@MainContractorDiscount", (object)oCustomer.MainContractorDiscount, true);
            database.AddParameter("@Logo", (object)oCustomer.Logo, true);
            database.AddParameter("@CustomerPoNumReqd", (object)oCustomer.PoNumReqd, true);
            database.AddParameter("@JobPriorityMandatory", (object)oCustomer.JobPriorityMandatory, true);
            database.AddParameter("@Nominal", (object)oCustomer.Nominal, true);
            database.AddParameter("@OverrideDept", (object)oCustomer.OverrideDept, true);
            database.AddParameter("@Terms", (object)oCustomer.Terms, true);
            database.AddParameter("@SuperBook", (object)oCustomer.SuperBook, true);
            database.AddParameter("@SummerServ", (object)oCustomer.SummerServ, true);
            database.AddParameter("@WinterServ", (object)oCustomer.WinterServ, true);
            database.AddParameter("@AlertEmail", (object)oCustomer.AlertEmail, true);
            database.AddParameter("@MOTStyleService", (object)oCustomer.MOTStyleService, true);
            database.AddParameter("@IsOutOfScope", (object)oCustomer.IsOutOfScope, true);
            database.AddParameter("@IsPFH", (object)oCustomer.IsPFH, true);
            object objectValue = RuntimeHelpers.GetObjectValue(Decimal.Compare(oCustomer.JobSpendLimit, Decimal.Zero) > 0 ? (object)oCustomer.JobSpendLimit : (object)DBNull.Value);
            database.AddParameter("@JobSpendLimit", RuntimeHelpers.GetObjectValue(objectValue), true);
        }

        public DataView Customer_Contracts_GetAll(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            DataTable table = this._database.ExecuteSP_DataTable("Customer_Contract_GetAll", true);
            table.TableName = Enums.TableNames.tblContract.ToString();
            return new DataView(table);
        }

        public DataView Priorities_Get_For_CustomerID(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Priorities_Get_For_CustomerID), true);
            table.TableName = Enums.TableNames.tblContract.ToString();
            return new DataView(table);
        }

        public DataView Requirements_Get_For_CustomerID(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Requirements_Get_For_CustomerID), true);
            table.TableName = Enums.TableNames.tblContract.ToString();
            return new DataView(table);
        }

        public DataView Priorities_Get_For_CustomerID_Active(int CustomerID, int ManagerID = 0)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            this._database.AddParameter("@ManagerID", (object)ManagerID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Priorities_Get_For_CustomerID_Active), true);
            table.TableName = Enums.TableNames.tblContract.ToString();
            return new DataView(table);
        }

        public DataView CustomerPriority_Get(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            return new DataView(this._database.ExecuteSP_DataTable("CustomerPriorties_Get", true));
        }

        public DataView Customer_EngineerRaise_Get(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            return new DataView(this._database.ExecuteSP_DataTable("EngineerRaise_ForCustomer", true));
        }

        public DataView Customer_EngineerRaise_Insert(
          int CustomerID,
          int EngineerID,
          bool Super)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            this._database.AddParameter("@EngineerID", (object)EngineerID, true);
            this._database.AddParameter("@Super", (object)Super, true);
            return new DataView(this._database.ExecuteSP_DataTable("EngineerRaise_Insert", true));
        }

        public DataView Customer_EngineerRaise_Update(
          int CustomerID,
          int EngineerID,
          bool Super,
          int RaiseJobCustomerEngineerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            this._database.AddParameter("@EngineerID", (object)EngineerID, true);
            this._database.AddParameter("@RaiseJobCustomerEngineerID", (object)RaiseJobCustomerEngineerID, true);
            this._database.AddParameter("@Super", (object)Super, true);
            return new DataView(this._database.ExecuteSP_DataTable("EngineerRaise_Update", true));
        }

        public void Customer_EngineerRaise_Delete(int RaiseJobCustomerEngineerID)
        {
            this._database.ClearParameter();
            App.DB.ExecuteScalar("Update tblRaiseJobCustomerEngineer SET Deleted = 1, LastChanged = GETDATE() Where RaiseJobCustomerEngineerID = " + Conversions.ToString(RaiseJobCustomerEngineerID), true, false);
        }

        public void Priorities_Delete_For_Customer(int CustomerID)
        {
            this._database.ClearParameter();
            App.DB.ExecuteScalar("DELETE FROM tblCustomerPriority Where CustomerID = " + Conversions.ToString(CustomerID), true, false);
        }

        public void Requirements_Delete_For_Customer(int CustomerID)
        {
            this._database.ClearParameter();
            App.DB.ExecuteScalar("DELETE FROM tblCustomerRequirements Where CustomerID = " + Conversions.ToString(CustomerID), true, false);
        }

        public void Priorities_Insert_For_Customer(
          int CustomerID,
          int ManagerID,
          int TargetHours,
          int IncludeWeekends,
          int IncludeBH,
          int IncludeOOH)
        {
            this._database.ClearParameter();
            App.DB.ExecuteScalar("INSERT INTO tblCustomerPriority VALUES (" + Conversions.ToString(CustomerID) + "," + Conversions.ToString(ManagerID) + "," + Conversions.ToString(TargetHours) + "," + Conversions.ToString(IncludeWeekends) + "," + Conversions.ToString(IncludeBH) + "," + Conversions.ToString(IncludeOOH) + ")", true, false);
        }

        public void Requirements_Insert_For_Customer(int CustomerID, int ManagerID)
        {
            this._database.ClearParameter();
            App.DB.ExecuteScalar("INSERT INTO tblCustomerRequirements VALUES (" + Conversions.ToString(CustomerID) + "," + Conversions.ToString(ManagerID) + ")", true, false);
        }

        public void Part_Insert_For_Customer(int CustomerID, int PartSupplierID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            this._database.AddParameter("@PartSupplierID", (object)PartSupplierID, true);
            Conversions.ToInteger(this._database.SP_ExecuteScalar("Customer_Part_Insert", true));
        }

        public void Part_Delete_For_Customer(int CustomerID, int PartSupplierID)
        {
            this._database.ClearParameter();
            App.DB.ExecuteScalar("UPDATE tblCustomerPart SET Deleted = 1 WHERE CUSTOMERID = " + Conversions.ToString(CustomerID) + " AND PartSupplierID = " + Conversions.ToString(PartSupplierID) ?? "", true, false);
        }

        public int Customer_GetActiveSiteCount(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            return Conversions.ToInteger(this._database.SP_ExecuteScalar(nameof(Customer_GetActiveSiteCount), true));
        }

        public CustomerServiceProcess CustomerServiceProcess_Get_ForCustomer(
          int customerId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)customerId, true);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(CustomerServiceProcess_Get_ForCustomer), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (CustomerServiceProcess)null;
            CustomerServiceProcess customerServiceProcess1 = new CustomerServiceProcess();
            CustomerServiceProcess customerServiceProcess2 = customerServiceProcess1;
            customerServiceProcess2.IgnoreExceptionsOnSetMethods = true;
            if (dataTable.Columns.Contains("CustomerServiceProcessID"))
                customerServiceProcess2.SetCustomerServiceProcessID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerServiceProcessID"]);
            if (dataTable.Columns.Contains("CustomerID"))
                customerServiceProcess2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
            if (dataTable.Columns.Contains("Letter1"))
                customerServiceProcess2.SetLetter1 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Letter1"]);
            if (dataTable.Columns.Contains("Letter2"))
                customerServiceProcess2.SetLetter2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Letter2"]);
            if (dataTable.Columns.Contains("Letter3"))
                customerServiceProcess2.SetLetter3 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Letter3"]);
            if (dataTable.Columns.Contains("Appointment1"))
                customerServiceProcess2.SetAppointment1 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Appointment1"]);
            if (dataTable.Columns.Contains("Appointment2"))
                customerServiceProcess2.SetAppointment2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Appointment2"]);
            if (dataTable.Columns.Contains("Appointment3"))
                customerServiceProcess2.SetAppointment3 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Appointment3"]);
            if (dataTable.Columns.Contains("DateAdded"))
                customerServiceProcess2.DateAdded = Conversions.ToDate(dataTable.Rows[0]["DateAdded"]);
            if (dataTable.Columns.Contains("AddedBy"))
                customerServiceProcess2.SetAddedBy = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AddedBy"]);
            if (dataTable.Columns.Contains("Template1") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Template1"])))
                customerServiceProcess2.Template1 = (byte[])dataTable.Rows[0]["Template1"];
            if (dataTable.Columns.Contains("Template2") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Template2"])))
                customerServiceProcess2.Template2 = (byte[])dataTable.Rows[0]["Template2"];
            if (dataTable.Columns.Contains("Template3") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Template3"])))
                customerServiceProcess2.Template3 = (byte[])dataTable.Rows[0]["Template3"];
            if (dataTable.Columns.Contains("PatchCheckTemplate") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PatchCheckTemplate"])))
                customerServiceProcess2.PatchCheckTemplate = (byte[])dataTable.Rows[0]["PatchCheckTemplate"];
            customerServiceProcess1.Exists = true;
            return customerServiceProcess1;
        }

        public bool CustomerServiceProcess_Update(CustomerServiceProcess serviceProcess)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerServiceProcessID", (object)serviceProcess.CustomerServiceProcessID, true);
            this._database.AddParameter("@CustomerID", (object)serviceProcess.CustomerID, true);
            this._database.AddParameter("@Letter1", (object)serviceProcess.Letter1, true);
            this._database.AddParameter("@Letter2", (object)serviceProcess.Letter2, true);
            this._database.AddParameter("@Letter3", (object)serviceProcess.Letter3, true);
            this._database.AddParameter("@Appointment1", (object)serviceProcess.Appointment1, true);
            this._database.AddParameter("@Appointment2", (object)serviceProcess.Appointment2, true);
            this._database.AddParameter("@Appointment3", (object)serviceProcess.Appointment3, true);
            this._database.AddParameter("@AddedBy", (object)App.loggedInUser.UserID, true);
            this._database.AddParameter("@Template1", (object)serviceProcess.Template1, true);
            this._database.AddParameter("@Template2", (object)serviceProcess.Template2, true);
            this._database.AddParameter("@Template3", (object)serviceProcess.Template3, true);
            this._database.AddParameter("@PatchCheckTemplate", (object)serviceProcess.PatchCheckTemplate, true);
            return this._database.ExecuteSP_ReturnRowsAffected(nameof(CustomerServiceProcess_Update)) == 1;
        }

        public bool CustomerServiceProcess_Delete(int customerServiceProcessId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerServiceProcessID", (object)customerServiceProcessId, true);
            return this._database.ExecuteSP_ReturnRowsAffected(nameof(CustomerServiceProcess_Delete)) == 1;
        }
    }
}