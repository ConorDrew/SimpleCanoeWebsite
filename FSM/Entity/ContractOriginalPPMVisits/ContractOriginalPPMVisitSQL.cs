// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisitSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOriginalPPMVisits
{
  public class ContractOriginalPPMVisitSQL
  {
    private Database _database;

    public ContractOriginalPPMVisitSQL(Database database)
    {
      this._database = database;
    }

    public DataView GetAll_For_ContractSiteID(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractOriginalPPMVisit_GetAll_For_ContractSiteID", true);
      table.TableName = Enums.TableNames.tblContractPPMVisit.ToString();
      return new DataView(table);
    }

    public DataView GetAllAssets_For_ContractSiteID(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractOriginalPPMVisit_Assets_GetAll_For_ContractSiteID", true);
      table.TableName = Enums.TableNames.tblContractPPMVisit.ToString();
      return new DataView(table);
    }

    public ContractOriginalPPMVisit Insert(
      ContractOriginalPPMVisit oContractPPMVisit)
    {
      this._database.ClearParameter();
      this.AddContractPPMVisitParametersToCommand(ref oContractPPMVisit);
      oContractPPMVisit.SetContractPPMVisitID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOriginalPPMVisit_Insert", true)));
      oContractPPMVisit.Exists = true;
      return oContractPPMVisit;
    }

    private void AddContractPPMVisitParametersToCommand(
      ref ContractOriginalPPMVisit oContractPPMVisit)
    {
      Database database = this._database;
      database.AddParameter("@ContractSiteID", (object) oContractPPMVisit.ContractSiteID, true);
      database.AddParameter("@EstimatedVisitDate", (object) oContractPPMVisit.EstimatedVisitDate, true);
      database.AddParameter("@JobID", (object) oContractPPMVisit.JobID, true);
    }
  }
}
