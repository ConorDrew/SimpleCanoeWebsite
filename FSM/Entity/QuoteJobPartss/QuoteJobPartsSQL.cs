// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobPartss.QuoteJobPartsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobPartss
{
    public class QuoteJobPartsSQL
    {
        private Database _database;

        public QuoteJobPartsSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int QuoteJobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteJobID", (object)QuoteJobID, true);
            this._database.ExecuteSP_NO_Return("QuoteJobParts_Delete", true);
        }

        public void DeleteAll(int QuoteJobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteJobID", (object)QuoteJobID, true);
            this._database.ExecuteSP_NO_Return("QuoteJobParts_DeleteAllMarkedDeleted", true);
        }

        public QuoteJobParts Insert(QuoteJobParts oQuoteJobParts)
        {
            this._database.ClearParameter();
            this.AddQuoteJobPartsParametersToCommand(ref oQuoteJobParts);
            oQuoteJobParts.SetQuoteJobPartsID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteJob_Parts_Insert", true)));
            oQuoteJobParts.Exists = true;
            return oQuoteJobParts;
        }

        private void AddQuoteJobPartsParametersToCommand(ref QuoteJobParts oQuoteJobParts)
        {
            Database database = this._database;
            database.AddParameter("@QuoteJobID", (object)oQuoteJobParts.QuoteJobID, true);
            database.AddParameter("@PartID", (object)oQuoteJobParts.PartID, true);
            database.AddParameter("@Quantity", (object)oQuoteJobParts.Quantity, true);
            database.AddParameter("@BuyPrice", (object)oQuoteJobParts.BuyPrice, true);
            database.AddParameter("@PartSupplierID", (object)oQuoteJobParts.PartSupplierID, true);
            if (oQuoteJobParts.SpecialDescription.Length == 0)
                database.AddParameter("@SpecialDescription", (object)DBNull.Value, true);
            else
                database.AddParameter("@SpecialDescription", (object)oQuoteJobParts.SpecialDescription, true);
            database.AddParameter("@SpecialCost", (object)oQuoteJobParts.SpecialCost, true);
            database.AddParameter("@Extra", (object)oQuoteJobParts.Extra, true);
        }
    }
}