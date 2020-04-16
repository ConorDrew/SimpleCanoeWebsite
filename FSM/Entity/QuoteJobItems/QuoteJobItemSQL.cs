// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobItems.QuoteJobItemSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobItems
{
    public class QuoteJobItemSQL
    {
        private Database _database;

        public QuoteJobItemSQL(Database database)
        {
            this._database = database;
        }

        public QuoteJobItem Insert(QuoteJobItem qJobItem)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteJobOfWorkID", (object)qJobItem.QuoteJobOfWorkID, true);
            this._database.AddParameter("@Summary", (object)qJobItem.Summary, true);
            this._database.AddParameter("@RateID", (object)qJobItem.RateID, true);
            this._database.AddParameter("@Qty", (object)qJobItem.Qty, true);
            this._database.AddParameter("@SystemLinkID", (object)qJobItem.SystemLinkID, true);
            qJobItem.SetQuoteJobItemID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteJobItem_Insert", true)));
            return qJobItem;
        }

        public DataView QuoteJobItems_Get_For_QuoteJob_Of_Work(int QuoteJobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteJobOfWorkID", (object)QuoteJobOfWorkID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(QuoteJobItems_Get_For_QuoteJob_Of_Work), true);
            table.TableName = Enums.TableNames.tblQuoteJobItem.ToString();
            return new DataView(table);
        }

        public ArrayList QuoteJobOfWork_Get_For_QuoteJob_Of_Work_As_Objects(
          int QuoteJobOfWorkID)
        {
            ArrayList arrayList = new ArrayList();

            foreach (DataRow current in this.QuoteJobItems_Get_For_QuoteJob_Of_Work(QuoteJobOfWorkID).Table.Rows)
            {
                arrayList.Add((object)new QuoteJobItem()
                {
                    IgnoreExceptionsOnSetMethods = true,
                    SetQuoteJobItemID = RuntimeHelpers.GetObjectValue(current["QuoteJobItemID"]),
                    SetQuoteJobOfWorkID = RuntimeHelpers.GetObjectValue(current[nameof(QuoteJobOfWorkID)]),
                    SetSummary = RuntimeHelpers.GetObjectValue(current["Summary"]),
                    SetRateID = RuntimeHelpers.GetObjectValue(current["RateID"]),
                    SetQty = RuntimeHelpers.GetObjectValue(current["Qty"]),
                    SetSystemLinkID = RuntimeHelpers.GetObjectValue(current["SystemLinkID"])
                });
            }

            return arrayList;
        }

        public void Delete(int QuoteJobOfWorkID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteJobOfWorkID", (object)QuoteJobOfWorkID, true);
            this._database.ExecuteSP_NO_Return("QuoteJobItem_Delete", true);
        }
    }
}