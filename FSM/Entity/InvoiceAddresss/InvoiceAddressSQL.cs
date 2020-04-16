// Decompiled with JetBrains decompiler
// Type: FSM.Entity.InvoiceAddresss.InvoiceAddressSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.InvoiceAddresss
{
    public class InvoiceAddressSQL
    {
        private Database _database;

        public InvoiceAddressSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int InvoiceAddressID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceAddressID", (object)InvoiceAddressID, true);
            this._database.ExecuteSP_NO_Return("InvoiceAddress_Delete", true);
        }

        public InvoiceAddress InvoiceAddress_Get(int InvoiceAddressID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceAddressID", (object)InvoiceAddressID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(InvoiceAddress_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (InvoiceAddress)null;
            InvoiceAddress invoiceAddress1 = new InvoiceAddress();
            InvoiceAddress invoiceAddress2 = invoiceAddress1;
            invoiceAddress2.IgnoreExceptionsOnSetMethods = true;
            invoiceAddress2.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(InvoiceAddressID)]);
            invoiceAddress2.SetAddress1 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address1"]);
            invoiceAddress2.SetAddress2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address2"]);
            invoiceAddress2.SetAddress3 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address3"]);
            invoiceAddress2.SetAddress4 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address4"]);
            invoiceAddress2.SetAddress5 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address5"]);
            invoiceAddress2.SetPostcode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Postcode"]);
            invoiceAddress2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TelephoneNum"]);
            invoiceAddress2.SetFaxNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaxNum"]);
            invoiceAddress2.SetEmailAddress = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"]);
            invoiceAddress2.SetSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
            invoiceAddress2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            invoiceAddress1.Exists = true;
            return invoiceAddress1;
        }

        public DataView InvoiceAddress_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoiceAddress_GetAll), true);
            table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
            return new DataView(table);
        }

        public DataView InvoiceAddress_Get_EngineerVisitID(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.AddParameter("@InvoiceEnumVal", (object)258, true);
            this._database.AddParameter("@SiteEnumVal", (object)253, true);
            this._database.AddParameter("@HQEnumVal", (object)254, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoiceAddress_Get_EngineerVisitID), true);
            table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
            return new DataView(table);
        }

        public DataView InvoiceAddress_Get_CustomerID(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            this._database.AddParameter("@InvoiceEnumVal", (object)258, true);
            this._database.AddParameter("@SiteEnumVal", (object)253, true);
            this._database.AddParameter("@HQEnumVal", (object)254, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoiceAddress_Get_CustomerID), true);
            table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
            return new DataView(table);
        }

        public DataView InvoiceAddress_Get_SiteID(int SiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteID", (object)SiteID, true);
            this._database.AddParameter("@InvoiceEnumVal", (object)258, true);
            this._database.AddParameter("@SiteEnumVal", (object)253, true);
            this._database.AddParameter("@HQEnumVal", (object)254, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoiceAddress_Get_SiteID), true);
            table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
            return new DataView(table);
        }

        public DataView InvoiceAddress_Get_OrderID(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            this._database.AddParameter("@InvoiceEnumVal", (object)258, true);
            this._database.AddParameter("@SiteEnumVal", (object)253, true);
            this._database.AddParameter("@HQEnumVal", (object)254, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoiceAddress_Get_OrderID), true);
            table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
            return new DataView(table);
        }

        public InvoiceAddress Insert(InvoiceAddress oInvoiceAddress)
        {
            this._database.ClearParameter();
            this.AddInvoiceAddressParametersToCommand(ref oInvoiceAddress);
            oInvoiceAddress.SetInvoiceAddressID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("InvoiceAddress_Insert", true)));
            oInvoiceAddress.Exists = true;
            return oInvoiceAddress;
        }

        public DataView InvoiceAddress_GetForSite(int SiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteID", (object)SiteID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoiceAddress_GetForSite), true);
            table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
            return new DataView(table);
        }

        public DataView InvoiceAddress_Search(string criteria)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Criteria", (object)criteria, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoiceAddress_Search), true);
            table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
            return new DataView(table);
        }

        public void Update(InvoiceAddress oInvoiceAddress)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceAddressID", (object)oInvoiceAddress.InvoiceAddressID, true);
            this.AddInvoiceAddressParametersToCommand(ref oInvoiceAddress);
            this._database.ExecuteSP_NO_Return("InvoiceAddress_Update", true);
        }

        private void AddInvoiceAddressParametersToCommand(ref InvoiceAddress oInvoiceAddress)
        {
            Database database = this._database;
            database.AddParameter("@Address1", (object)oInvoiceAddress.Address1, true);
            database.AddParameter("@Address2", (object)oInvoiceAddress.Address2, true);
            database.AddParameter("@Address3", (object)oInvoiceAddress.Address3, true);
            database.AddParameter("@Address4", (object)oInvoiceAddress.Address4, true);
            database.AddParameter("@Address5", (object)oInvoiceAddress.Address5, true);
            database.AddParameter("@Postcode", (object)oInvoiceAddress.Postcode, true);
            database.AddParameter("@TelephoneNum", (object)oInvoiceAddress.TelephoneNum, true);
            database.AddParameter("@FaxNum", (object)oInvoiceAddress.FaxNum, true);
            database.AddParameter("@EmailAddress", (object)oInvoiceAddress.EmailAddress, true);
            database.AddParameter("@SiteID", (object)oInvoiceAddress.SiteID, true);
        }
    }
}