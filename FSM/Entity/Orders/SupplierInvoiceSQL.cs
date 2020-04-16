// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Orders.SupplierInvoiceSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Orders
{
    public class SupplierInvoiceSQL
    {
        private Database _database;

        public SupplierInvoiceSQL(Database database)
        {
            this._database = database;
        }

        public void DeleteForOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            this._database.ExecuteSP_NO_Return("Order_DeleteSupplierInvoicesForOrder", true);
        }

        public void Delete(int SupplierInvoiceID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SupplierInvoiceID", (object)SupplierInvoiceID, true);
            this._database.ExecuteSP_NO_Return("Order_DeleteSupplierInvoice", true);
        }

        public DataView Order_GetSupplierInvoice(int SupplierInvoiceID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SupplierInvoiceID", (object)SupplierInvoiceID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Order_GetSupplierInvoice), true);
            table.TableName = Enums.TableNames.tblOrderSupplierInvoices.ToString();
            return new DataView(table);
        }

        public DataView Order_GetSupplierInvoices(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Order_GetSupplierInvoices), true);
            table.TableName = Enums.TableNames.tblOrderSupplierInvoices.ToString();
            return new DataView(table);
        }

        public SupplierInvoice Insert(SupplierInvoice oSupplierInvoice)
        {
            this._database.ClearParameter();
            this.AddSupplierInvoiceParametersToCommand(ref oSupplierInvoice);
            oSupplierInvoice.SetInvoiceID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Order_InsertSupplierInvoice", true)));
            oSupplierInvoice.Exists = true;
            return oSupplierInvoice;
        }

        public SupplierInvoice Insert(
          SupplierInvoice oSupplierInvoice,
          SqlTransaction trans)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "Order_InsertSupplierInvoice";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Transaction = trans;
            sqlCommand.Connection = trans.Connection;
            sqlCommand.Parameters.AddWithValue("@OrderID", (object)oSupplierInvoice.OrderID);
            sqlCommand.Parameters.AddWithValue("@SupplierInvoiceReference", (object)oSupplierInvoice.InvoiceReference);
            sqlCommand.Parameters.AddWithValue("@SupplierInvoiceDate", (object)oSupplierInvoice.InvoiceDate);
            if (oSupplierInvoice.GoodsAmount == 0.0)
                sqlCommand.Parameters.AddWithValue("@SupplierGoodsAmount", (object)0);
            else
                sqlCommand.Parameters.AddWithValue("@SupplierGoodsAmount", (object)oSupplierInvoice.GoodsAmount);
            if (oSupplierInvoice.GoodsAmount == 0.0)
                sqlCommand.Parameters.AddWithValue("@SupplierVATAmount", (object)0);
            else
                sqlCommand.Parameters.AddWithValue("@SupplierVATAmount", (object)oSupplierInvoice.VATAmount);
            if (oSupplierInvoice.GoodsAmount == 0.0)
                sqlCommand.Parameters.AddWithValue("@SupplierInvoiceAmount", (object)0);
            else
                sqlCommand.Parameters.AddWithValue("@SupplierInvoiceAmount", (object)oSupplierInvoice.TotalAmount);
            if (oSupplierInvoice.GoodsAmount == 0.0)
                sqlCommand.Parameters.AddWithValue("@TaxCodeID", (object)0);
            else
                sqlCommand.Parameters.AddWithValue("@TaxCodeID", (object)oSupplierInvoice.TaxCodeID);
            sqlCommand.Parameters.AddWithValue("@NominalCode", (object)oSupplierInvoice.NominalCode);
            sqlCommand.Parameters.AddWithValue("@ExtraRef", (object)oSupplierInvoice.ExtraRef);
            if (oSupplierInvoice.GoodsAmount == 0.0)
                sqlCommand.Parameters.AddWithValue("@ReadyToSendToSage", (object)0);
            else
                sqlCommand.Parameters.AddWithValue("@ReadyToSendToSage", (object)oSupplierInvoice.ReadyToSendToSage);
            if (oSupplierInvoice.GoodsAmount == 0.0)
                sqlCommand.Parameters.AddWithValue("@SentToSage", (object)0);
            else
                sqlCommand.Parameters.AddWithValue("@SentToSage", (object)oSupplierInvoice.SentToSage);
            if (oSupplierInvoice.GoodsAmount == 0.0)
                sqlCommand.Parameters.AddWithValue("@OldSystemInvoice", (object)0);
            else
                sqlCommand.Parameters.AddWithValue("@OldSystemInvoice", (object)oSupplierInvoice.OldSystemInvoice);
            if (oSupplierInvoice.GoodsAmount == 0.0)
                sqlCommand.Parameters.AddWithValue("@DateExported", (object)DBNull.Value);
            else
                sqlCommand.Parameters.AddWithValue("@DateExported", (object)oSupplierInvoice.DateExported);
            sqlCommand.Parameters.AddWithValue("@KeyedBy", (object)App.loggedInUser.UserID);
            oSupplierInvoice.SetInvoiceID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
            oSupplierInvoice.Exists = true;
            return oSupplierInvoice;
        }

        public void Update(SupplierInvoice oSupplierInvoice)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SupplierInvoiceID", (object)oSupplierInvoice.InvoiceID, true);
            this.AddSupplierInvoiceParametersToCommand(ref oSupplierInvoice);
            this._database.ExecuteSP_NO_Return("Order_UpdateSupplierInvoice", true);
        }

        private void AddSupplierInvoiceParametersToCommand(ref SupplierInvoice oSupplierInvoice)
        {
            Database database = this._database;
            database.AddParameter("@OrderID", (object)oSupplierInvoice.OrderID, true);
            database.AddParameter("@SupplierInvoiceReference", (object)oSupplierInvoice.InvoiceReference, true);
            database.AddParameter("@SupplierInvoiceDate", (object)oSupplierInvoice.InvoiceDate, true);
            if (oSupplierInvoice.GoodsAmount == 0.0)
                database.AddParameter("@SupplierGoodsAmount", (object)0, true);
            else
                database.AddParameter("@SupplierGoodsAmount", (object)oSupplierInvoice.GoodsAmount, true);
            if (oSupplierInvoice.VATAmount == 0.0)
                database.AddParameter("@SupplierVATAmount", (object)0, true);
            else
                database.AddParameter("@SupplierVATAmount", (object)oSupplierInvoice.VATAmount, true);
            if (oSupplierInvoice.TotalAmount == 0.0)
                database.AddParameter("@SupplierInvoiceAmount", (object)0, true);
            else
                database.AddParameter("@SupplierInvoiceAmount", (object)oSupplierInvoice.TotalAmount, true);
            if (oSupplierInvoice.TaxCodeID == 0)
                database.AddParameter("@TaxCodeID", (object)0, true);
            else
                database.AddParameter("@TaxCodeID", (object)oSupplierInvoice.TaxCodeID, true);
            database.AddParameter("@NominalCode", (object)oSupplierInvoice.NominalCode, true);
            database.AddParameter("@ExtraRef", (object)oSupplierInvoice.ExtraRef, true);
            if (!oSupplierInvoice.ReadyToSendToSage)
                database.AddParameter("@ReadyToSendToSage", (object)0, true);
            else
                database.AddParameter("@ReadyToSendToSage", (object)oSupplierInvoice.ReadyToSendToSage, true);
            if (!oSupplierInvoice.SentToSage)
                database.AddParameter("@SentToSage", (object)0, true);
            else
                database.AddParameter("@SentToSage", (object)oSupplierInvoice.SentToSage, true);
            if (!oSupplierInvoice.OldSystemInvoice)
                database.AddParameter("@OldSystemInvoice", (object)0, true);
            else
                database.AddParameter("@OldSystemInvoice", (object)oSupplierInvoice.OldSystemInvoice, true);
            if (DateTime.Compare(oSupplierInvoice.DateExported, DateTime.MinValue) == 0)
                database.AddParameter("@DateExported", (object)DBNull.Value, true);
            else
                database.AddParameter("@DateExported", (object)oSupplierInvoice.DateExported, true);
            database.AddParameter("@KeyedBy", (object)App.loggedInUser.UserID, true);
        }
    }
}