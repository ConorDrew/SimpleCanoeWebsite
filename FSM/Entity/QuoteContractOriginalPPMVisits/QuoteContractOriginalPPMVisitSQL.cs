// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOriginalPPMVisits.QuoteContractOriginalPPMVisitSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOriginalPPMVisits
{
    public class QuoteContractOriginalPPMVisitSQL
    {
        private Database _database;

        public QuoteContractOriginalPPMVisitSQL(Database database)
        {
            this._database = database;
        }

        public DataView GetAll_For_QuoteContractSiteID(int QuoteContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)QuoteContractSiteID, true);
            DataTable table = this._database.ExecuteSP_DataTable("QuoteContractOriginalPPMVisit_GetAll_For_QuoteContractSiteID", true);
            table.TableName = Enums.TableNames.tblQuoteContractPPMVisit.ToString();
            return new DataView(table);
        }

        public QuoteContractOriginalPPMVisit Insert(
          QuoteContractOriginalPPMVisit oQuoteContractPPMVisit)
        {
            this._database.ClearParameter();
            this.AddQuoteContractPPMVisitParametersToCommand(ref oQuoteContractPPMVisit);
            oQuoteContractPPMVisit.SetQuoteContractPPMVisitID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractOriginalPPMVisit_Insert", true)));
            oQuoteContractPPMVisit.Exists = true;
            return oQuoteContractPPMVisit;
        }

        private void AddQuoteContractPPMVisitParametersToCommand(
          ref QuoteContractOriginalPPMVisit oQuoteContractPPMVisit)
        {
            Database database = this._database;
            database.AddParameter("@QuoteContractSiteID", (object)oQuoteContractPPMVisit.QuoteContractSiteID, true);
            database.AddParameter("@EstimatedVisitDate", (object)oQuoteContractPPMVisit.EstimatedVisitDate, true);
        }
    }
}