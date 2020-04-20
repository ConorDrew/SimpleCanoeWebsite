// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobProductss.QuoteJobProductsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobProductss
{
    public class QuoteJobProductsSQL
    {
        private Database _database;

        public QuoteJobProductsSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int QuoteJobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteJobID", (object)QuoteJobID, true);
            this._database.ExecuteSP_NO_Return("QuoteJobProducts_Delete", true);
        }

        public QuoteJobProducts Insert(QuoteJobProducts oQuoteJobProducts)
        {
            this._database.ClearParameter();
            this.AddQuoteJobProductsParametersToCommand(ref oQuoteJobProducts);
            oQuoteJobProducts.SetQuoteJobProductsID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteJobProducts_Insert", true)));
            oQuoteJobProducts.Exists = true;
            return oQuoteJobProducts;
        }

        private void AddQuoteJobProductsParametersToCommand(ref QuoteJobProducts oQuoteJobProducts)
        {
            Database database = this._database;
            database.AddParameter("@QuoteJobID", (object)oQuoteJobProducts.QuoteJobID, true);
            database.AddParameter("@ProductID", (object)oQuoteJobProducts.ProductID, true);
            database.AddParameter("@Quantity", (object)oQuoteJobProducts.Quantity, true);
            database.AddParameter("@SellPrice", (object)oQuoteJobProducts.SellPrice, true);
        }
    }
}