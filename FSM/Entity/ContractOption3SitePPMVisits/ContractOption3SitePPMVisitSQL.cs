// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOption3SitePPMVisits.ContractOption3SitePPMVisitSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOption3SitePPMVisits
{
    public class ContractOption3SitePPMVisitSQL
    {
        private Database _database;

        public ContractOption3SitePPMVisitSQL(Database database)
        {
            this._database = database;
        }

        public DataView ContractOption3SitePPMVisit_GetAll_ContractSiteID(int ContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContractSiteID", (object)ContractSiteID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(ContractOption3SitePPMVisit_GetAll_ContractSiteID), true);
            table.TableName = Enums.TableNames.tblContractOption3SitePPMVisit.ToString();
            return new DataView(table);
        }

        public ContractOption3SitePPMVisit Insert(
          ContractOption3SitePPMVisit oContractOption3SitePPMVisit)
        {
            this._database.ClearParameter();
            this.AddContractOption3SitePPMVisitParametersToCommand(ref oContractOption3SitePPMVisit);
            oContractOption3SitePPMVisit.SetContractSitePPMVisitID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOption3SitePPMVisit_Insert", true)));
            oContractOption3SitePPMVisit.Exists = true;
            return oContractOption3SitePPMVisit;
        }

        private void AddContractOption3SitePPMVisitParametersToCommand(
          ref ContractOption3SitePPMVisit oContractOption3SitePPMVisit)
        {
            Database database = this._database;
            database.AddParameter("@ContractSiteID", (object)oContractOption3SitePPMVisit.ContractSiteID, true);
            database.AddParameter("@VisitDate", (object)oContractOption3SitePPMVisit.VisitDate, true);
            database.AddParameter("@JobID", (object)oContractOption3SitePPMVisit.JobID, true);
        }
    }
}