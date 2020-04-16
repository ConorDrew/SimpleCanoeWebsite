// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteOrders.QuoteOrderSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteOrders
{
    public class QuoteOrderSQL
    {
        private Database _database;

        public QuoteOrderSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int QuoteOrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderID", (object)QuoteOrderID, true);
            this._database.ExecuteSP_NO_Return("QuoteOrder_Delete", true);
        }

        public void QuoteOrderProductsToInclude_Insert(
          int QuoteOrderID,
          int ProductSupplierID,
          double SellPrice)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderID", (object)QuoteOrderID, true);
            this._database.AddParameter("@ProductSupplierID", (object)ProductSupplierID, true);
            this._database.AddParameter("@SellPrice", (object)SellPrice, true);
            this._database.ExecuteSP_NO_Return(nameof(QuoteOrderProductsToInclude_Insert), true);
        }

        public void QuoteOrderPartsToInclude_Insert(
          int QuoteOrderID,
          int PartSupplierID,
          double SellPrice)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderID", (object)QuoteOrderID, true);
            this._database.AddParameter("@PartSupplierID", (object)PartSupplierID, true);
            this._database.AddParameter("@SellPrice", (object)SellPrice, true);
            this._database.ExecuteSP_NO_Return(nameof(QuoteOrderPartsToInclude_Insert), true);
        }

        public void QuoteOrder_DeleteItemsIncluded(int QuoteOrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderID", (object)QuoteOrderID, true);
            this._database.ExecuteSP_NO_Return(nameof(QuoteOrder_DeleteItemsIncluded), true);
        }

        public QuoteOrder QuoteOrder_Get(int QuoteOrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderID", (object)QuoteOrderID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(QuoteOrder_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (QuoteOrder)null;
            QuoteOrder quoteOrder1 = new QuoteOrder();
            QuoteOrder quoteOrder2 = quoteOrder1;
            quoteOrder2.IgnoreExceptionsOnSetMethods = true;
            quoteOrder2.SetQuoteOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(QuoteOrderID)]);
            quoteOrder2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
            quoteOrder2.SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
            quoteOrder2.SetWarehouseID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarehouseID"]);
            quoteOrder2.SetContactID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContactID"]);
            quoteOrder2.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressID"]);
            quoteOrder2.SetCustomerRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerRef"]);
            quoteOrder2.DeliveryDeadline = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DeliveryDeadline"])) ? Conversions.ToDate(dataTable.Rows[0]["DeliveryDeadline"]) : DateTime.MinValue;
            quoteOrder2.SetSpecialInstructions = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SpecialInstructions"]);
            quoteOrder2.SetCreatedByUser = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreatedByUser"]);
            quoteOrder2.SetAllocatedToUser = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AllocatedToUser"]);
            quoteOrder2.EnquiryDate = Conversions.ToDate(dataTable.Rows[0]["EnquiryDate"]);
            quoteOrder2.ValidUntilDate = Conversions.ToDate(dataTable.Rows[0]["ValidUntilDate"]);
            quoteOrder2.SetAvailability = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Availability"]);
            quoteOrder2.SetPriceDetails = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PriceDetails"]);
            quoteOrder2.SetPriceExcludeDetails = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PriceExcludeDetails"]);
            quoteOrder2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            quoteOrder2.SetQuoteStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StatusID"]);
            quoteOrder2.SetReasonForReject = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonForReject"]);
            quoteOrder1.Exists = true;
            return quoteOrder1;
        }

        public DataView QuoteOrder_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(QuoteOrder_GetAll), true);
            table.TableName = Enums.TableNames.tblQuoteOrder.ToString();
            return new DataView(table);
        }

        public QuoteOrder Insert(QuoteOrder oQuoteOrder)
        {
            this._database.ClearParameter();
            this.AddQuoteOrderParametersToCommand(ref oQuoteOrder);
            oQuoteOrder.SetQuoteOrderID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteOrder_Insert", true)));
            oQuoteOrder.Exists = true;
            return oQuoteOrder;
        }

        public void Update(QuoteOrder oQuoteOrder)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderID", (object)oQuoteOrder.QuoteOrderID, true);
            this.AddQuoteOrderParametersToCommand(ref oQuoteOrder);
            this._database.ExecuteSP_NO_Return("QuoteOrder_Update", true);
        }

        public DataView Quote_PriceRequests_GetAll(int QuoteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteID", (object)QuoteID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Quote_PriceRequests_GetAll), true);
            table.TableName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
            return new DataView(table);
        }

        public DataView Quote_PriceRequests_GetConfirmed(int QuoteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteID", (object)QuoteID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Quote_PriceRequests_GetConfirmed), true);
            table.TableName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
            IEnumerator enumerator;
            try
            {
                enumerator = table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["Included"])))
                        current["Included"] = (object)0;
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
            }
            return new DataView(table);
        }

        private void AddQuoteOrderParametersToCommand(ref QuoteOrder oQuoteOrder)
        {
            Database database = this._database;
            database.AddParameter("@CustomerID", (object)oQuoteOrder.CustomerID, true);
            database.AddParameter("@SiteID", (object)oQuoteOrder.PropertyID, true);
            database.AddParameter("@WarehouseID", (object)oQuoteOrder.WarehouseID, true);
            database.AddParameter("@ContactID", (object)oQuoteOrder.ContactID, true);
            database.AddParameter("@InvoiceAddressID", (object)oQuoteOrder.InvoiceAddressID, true);
            database.AddParameter("@CustomerRef", (object)oQuoteOrder.CustomerRef, true);
            database.AddParameter("@SpecialInstructions", (object)oQuoteOrder.SpecialInstructions, true);
            database.AddParameter("@CreatedByUser", (object)oQuoteOrder.CreatedByUser, true);
            database.AddParameter("@AllocatedToUser", (object)oQuoteOrder.AllocatedToUser, true);
            database.AddParameter("@EnquiryDate", (object)oQuoteOrder.EnquiryDate, true);
            database.AddParameter("@ValidUntilDate", (object)oQuoteOrder.ValidUntilDate, true);
            if (DateTime.Compare(oQuoteOrder.DeliveryDeadline, DateTime.MinValue) == 0)
                database.AddParameter("@DeliveryDeadline", (object)DBNull.Value, true);
            else
                database.AddParameter("@DeliveryDeadline", (object)oQuoteOrder.DeliveryDeadline, true);
            database.AddParameter("@Availability", (object)oQuoteOrder.Availability, true);
            database.AddParameter("@PriceDetails", (object)oQuoteOrder.PriceDetails, true);
            database.AddParameter("@PriceExcludeDetails", (object)oQuoteOrder.PriceExcludeDetails, true);
            database.AddParameter("@StatusID", (object)oQuoteOrder.QuoteStatusID, true);
            database.AddParameter("@ReasonForReject", (object)oQuoteOrder.ReasonForReject, true);
        }
    }
}