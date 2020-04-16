// Decompiled with JetBrains decompiler
// Type: FSM.Entity.InvoiceToBeRaiseds.InvoiceToBeRaisedSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.InvoiceToBeRaiseds
{
    public class InvoiceToBeRaisedSQL
    {
        private Database _database;

        public InvoiceToBeRaisedSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int InvoiceToBeRaisedID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceToBeRaisedID", (object)InvoiceToBeRaisedID, true);
            this._database.ExecuteSP_NO_Return("InvoiceToBeRaised_Delete", true);
        }

        public InvoiceToBeRaised InvoiceToBeRaised_Get(int InvoiceToBeRaisedID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceToBeRaisedID", (object)InvoiceToBeRaisedID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(InvoiceToBeRaised_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (InvoiceToBeRaised)null;
            InvoiceToBeRaised invoiceToBeRaised1 = new InvoiceToBeRaised();
            InvoiceToBeRaised invoiceToBeRaised2 = invoiceToBeRaised1;
            invoiceToBeRaised2.IgnoreExceptionsOnSetMethods = true;
            invoiceToBeRaised2.SetInvoiceToBeRaisedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(InvoiceToBeRaisedID)]);
            invoiceToBeRaised2.RaiseDate = Conversions.ToDate(dataTable.Rows[0]["RaiseDate"]);
            invoiceToBeRaised2.SetInvoiceTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceTypeID"]);
            invoiceToBeRaised2.SetLinkID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LinkID"]);
            invoiceToBeRaised2.SetAddressTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AddressTypeID"]);
            invoiceToBeRaised2.SetAddressLinkID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AddressLinkID"]);
            invoiceToBeRaised2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
            invoiceToBeRaised2.SetPaymentTermID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PaymentTermID"]);
            invoiceToBeRaised1.Exists = true;
            return invoiceToBeRaised1;
        }

        public InvoiceToBeRaised InvoiceToBeRaised_Get_By_LinkID(
          int LinkID,
          Enums.InvoiceType InvoiceType)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LinkID", (object)LinkID, false);
            this._database.AddParameter("@InvoiceTypeID", (object)(int)InvoiceType, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(InvoiceToBeRaised_Get_By_LinkID), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (InvoiceToBeRaised)null;
            InvoiceToBeRaised invoiceToBeRaised1 = new InvoiceToBeRaised();
            InvoiceToBeRaised invoiceToBeRaised2 = invoiceToBeRaised1;
            invoiceToBeRaised2.IgnoreExceptionsOnSetMethods = true;
            invoiceToBeRaised2.SetInvoiceToBeRaisedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceToBeRaisedID"]);
            invoiceToBeRaised2.RaiseDate = Conversions.ToDate(dataTable.Rows[0]["RaiseDate"]);
            invoiceToBeRaised2.SetInvoiceTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceTypeID"]);
            invoiceToBeRaised2.SetLinkID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(LinkID)]);
            invoiceToBeRaised2.SetAddressTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AddressTypeID"]);
            invoiceToBeRaised2.SetAddressLinkID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AddressLinkID"]);
            invoiceToBeRaised2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
            invoiceToBeRaised2.SetTaxRateID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAXRateID"]);
            invoiceToBeRaised2.SetPaymentTermID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PaymentTermID"]);
            invoiceToBeRaised1.Exists = true;
            return invoiceToBeRaised1;
        }

        public DataView InvoiceToBeRaised_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoiceToBeRaised_GetAll), true);
            table.TableName = Enums.TableNames.tblInvoiceToBeRaised.ToString();
            return new DataView(table);
        }

        public DataView Invoices_GetAll_Manager(DateTime RaiseFrom, DateTime RaiseTo)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@RaiseFrom", (object)Conversions.ToDate(Strings.Format((object)RaiseFrom, "dd/MM/yyyy") + " 00:00:00"), true);
            this._database.AddParameter("@RaiseTo", (object)Conversions.ToDate(Strings.Format((object)RaiseTo, "dd/MM/yyyy") + " 23:59:59"), true);
            this._database.AddParameter("@InvoiceEnumVal", (object)258, true);
            this._database.AddParameter("@JobInvTypeEnum", (object)260, true);
            this._database.AddParameter("@OrderInvTypeEnum", (object)261, true);
            this._database.AddParameter("@ContractOpt1Enum", (object)327, true);
            this._database.AddParameter("@ContractOpt2Enum", (object)329, true);
            this._database.AddParameter("@ContractOpt3Enum", (object)330, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Invoices_GetAll_Manager), true);
            table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
            return new DataView(table);
        }

        public DataView Invoices_GetAll_For_EngineerVisitChargeID(int EngineerVisitChargeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceEnumVal", (object)258, true);
            this._database.AddParameter("@JobInvTypeEnum", (object)260, true);
            this._database.AddParameter("@EngineerVisitChargeID", (object)EngineerVisitChargeID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Invoices_GetAll_For_EngineerVisitChargeID), true);
            table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
            return new DataView(table);
        }

        public DataView Invoices_GetAll_For_JobID(int JobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceEnumVal", (object)258, true);
            this._database.AddParameter("@JobInvTypeEnum", (object)260, true);
            this._database.AddParameter("@JobID", (object)JobID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Invoices_GetAll_For_JobID), true);
            table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
            return new DataView(table);
        }

        public InvoiceToBeRaised Insert(InvoiceToBeRaised oInvoiceToBeRaised)
        {
            this._database.ClearParameter();
            this.AddInvoiceToBeRaisedParametersToCommand(ref oInvoiceToBeRaised);
            this._database.AddParameter("@RecordAddedBy", (object)App.loggedInUser.UserID, true);
            this._database.AddParameter("@RecordAddedOn", (object)DateAndTime.Now, true);
            oInvoiceToBeRaised.SetInvoiceToBeRaisedID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("InvoiceToBeRaised_Insert", true)));
            oInvoiceToBeRaised.Exists = true;
            return oInvoiceToBeRaised;
        }

        public DataView InvoiceToBeRaised_Search(string criteria)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Criteria", (object)criteria, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoiceToBeRaised_Search), true);
            table.TableName = Enums.TableNames.tblInvoiceToBeRaised.ToString();
            return new DataView(table);
        }

        public void Update(InvoiceToBeRaised oInvoiceToBeRaised)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceToBeRaisedID", (object)oInvoiceToBeRaised.InvoiceToBeRaisedID, true);
            this.AddInvoiceToBeRaisedParametersToCommand(ref oInvoiceToBeRaised);
            this._database.ExecuteSP_NO_Return("InvoiceToBeRaised_Update", true);
        }

        private void AddInvoiceToBeRaisedParametersToCommand(ref InvoiceToBeRaised oInvoiceToBeRaised)
        {
            Database database = this._database;
            database.AddParameter("@RaiseDate", (object)oInvoiceToBeRaised.RaiseDate, true);
            database.AddParameter("@InvoiceTypeID", (object)oInvoiceToBeRaised.InvoiceTypeID, true);
            database.AddParameter("@LinkID", (object)oInvoiceToBeRaised.LinkID, true);
            database.AddParameter("@AddressTypeID", (object)oInvoiceToBeRaised.AddressTypeID, true);
            database.AddParameter("@AddressLinkID", (object)oInvoiceToBeRaised.AddressLinkID, true);
            database.AddParameter("@CustomerID", (object)oInvoiceToBeRaised.CustomerID, true);
            database.AddParameter("@TAXRateID", (object)oInvoiceToBeRaised.TaxRateID, true);
            database.AddParameter("@TermID", (object)oInvoiceToBeRaised.PaymentTermID, true);
            database.AddParameter("@PaidByID", (object)oInvoiceToBeRaised.PaidByID, true);
        }

        public DataView InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(int JobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceTypeIDEnum", (object)260, true);
            this._database.AddParameter("@JobID", (object)JobID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID), true);
            table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
            return new DataView(table);
        }

        public DataView InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(int JobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceTypeIDEnum", (object)260, true);
            this._database.AddParameter("@JobID", (object)JobID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID), true);
            table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
            return new DataView(table);
        }

        public double InvoicesToBeRaised_GetAmount_ByInvoiceToBeRaisedID(int InvoiceToBeRaisedID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceTypeIDEnum", (object)260, true);
            this._database.AddParameter("@InvoiceToBeRaisedID", (object)InvoiceToBeRaisedID, true);
            return Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(App.DB.ExecuteSP_OBJECT(nameof(InvoicesToBeRaised_GetAmount_ByInvoiceToBeRaisedID), true)));
        }

        public DataView Invoices_GetAll_ForDirectDebitRpt(DateTime DateFrom, DateTime DateTo)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@RaiseFrom", (object)Conversions.ToDate(Strings.Format((object)DateFrom, "dd/MM/yyyy") + " 00:00:00"), true);
            this._database.AddParameter("@RaiseTo", (object)Conversions.ToDate(Strings.Format((object)DateTo, "dd/MM/yyyy") + " 23:59:59"), true);
            this._database.AddParameter("@ContractOpt1Enum", (object)327, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Invoices_GetAll_ForDirectDebitRpt), true);
            table.TableName = Enums.TableNames.tblInvoiceToBeRaised.ToString();
            return new DataView(table);
        }

        public bool InvoicesToBeRaised_Update_PaymentID(int InvoiceToBeRaisedID, int paymentTermID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@InvoiceToBeRaisedID", (object)InvoiceToBeRaisedID, true);
            this._database.AddParameter("@PaymentTermID", (object)paymentTermID, true);
            return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT(nameof(InvoicesToBeRaised_Update_PaymentID), true), (object)1, false);
        }
    }
}