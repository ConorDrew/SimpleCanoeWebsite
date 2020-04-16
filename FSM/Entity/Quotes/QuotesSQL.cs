// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Quotes.QuotesSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;

namespace FSM.Entity.Quotes
{
    public class QuotesSQL
    {
        private Database _database;

        public QuotesSQL(Database database)
        {
            this._database = database;
        }

        public DataView QuotesGet_All()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("Quotes_GetAll", true);
            table.TableName = Enums.TableNames.tblQuotes.ToString();
            return new DataView(table);
        }

        public DataView Quotes_Search(string Criteria)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Criteria", (object)Criteria, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Quotes_Search), true);
            table.TableName = Enums.TableNames.tblQuotes.ToString();
            return new DataView(table);
        }

        public DataView QuotesGet_All_For_CustomerID(int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CustomerID", (object)CustomerID, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(QuotesGet_All_For_CustomerID), true);
            table.TableName = Enums.TableNames.tblQuotes.ToString();
            return new DataView(table);
        }

        public DataView QuotesGet_All_For_SiteID(int SiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteID", (object)SiteID, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(QuotesGet_All_For_SiteID), true);
            table.TableName = Enums.TableNames.tblQuotes.ToString();
            return new DataView(table);
        }
    }
}