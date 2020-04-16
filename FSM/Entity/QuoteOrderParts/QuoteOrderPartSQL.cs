// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteOrderParts.QuoteOrderPartSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteOrderParts
{
    public class QuoteOrderPartSQL
    {
        private Database _database;

        public QuoteOrderPartSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int QuoteOrderPartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderPartID", (object)QuoteOrderPartID, true);
            this._database.ExecuteSP_NO_Return("QuoteOrderPart_Delete", true);
        }

        public QuoteOrderPart QuoteOrderPart_Get(int QuoteOrderPartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderPartID", (object)QuoteOrderPartID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(QuoteOrderPart_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (QuoteOrderPart)null;
            QuoteOrderPart quoteOrderPart1 = new QuoteOrderPart();
            QuoteOrderPart quoteOrderPart2 = quoteOrderPart1;
            quoteOrderPart2.IgnoreExceptionsOnSetMethods = true;
            quoteOrderPart2.SetQuoteOrderPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(QuoteOrderPartID)]);
            quoteOrderPart2.SetQuoteOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteOrderID"]);
            quoteOrderPart2.SetPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartID"]);
            quoteOrderPart2.SetPrice = (object)Helper.MakeDoubleValid((object)"Price");
            quoteOrderPart2.SetQuantity = (object)Helper.MakeIntegerValid((object)"Quantity");
            quoteOrderPart2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            quoteOrderPart1.Exists = true;
            return quoteOrderPart1;
        }

        public DataView QuoteOrderPart_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(QuoteOrderPart_GetAll), true);
            table.TableName = Enums.TableNames.tblQuoteOrderPart.ToString();
            return new DataView(table);
        }

        public QuoteOrderPart Insert(QuoteOrderPart oQuoteOrderPart)
        {
            this._database.ClearParameter();
            this.AddQuoteOrderPartParametersToCommand(ref oQuoteOrderPart);
            oQuoteOrderPart.SetQuoteOrderPartID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteOrderPart_Insert", true)));
            oQuoteOrderPart.Exists = true;
            return oQuoteOrderPart;
        }

        public void QuoteOrderPart_DeleteForQuoteOrder(int QuoteOrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderID", (object)QuoteOrderID, true);
            this._database.ExecuteSP_NO_Return(nameof(QuoteOrderPart_DeleteForQuoteOrder), true);
        }

        public void Update(QuoteOrderPart oQuoteOrderPart)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderPartID", (object)oQuoteOrderPart.QuoteOrderPartID, true);
            this.AddQuoteOrderPartParametersToCommand(ref oQuoteOrderPart);
            this._database.ExecuteSP_NO_Return("QuoteOrderPart_Update", true);
        }

        public object QuoteOrderPart_GetForQuoteOrder(int QuoteOrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteOrderID", (object)QuoteOrderID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(QuoteOrderPart_GetForQuoteOrder), true);
            table.TableName = Enums.TableNames.tblPart.ToString();
            return (object)new DataView(table);
        }

        private void AddQuoteOrderPartParametersToCommand(ref QuoteOrderPart oQuoteOrderPart)
        {
            Database database = this._database;
            database.AddParameter("@QuoteOrderID", (object)oQuoteOrderPart.QuoteOrderID, true);
            database.AddParameter("@PartID", (object)oQuoteOrderPart.PartID, true);
            database.AddParameter("@Price", (object)oQuoteOrderPart.Price, true);
            database.AddParameter("@Quantity", (object)oQuoteOrderPart.Quantity, true);
        }
    }
}