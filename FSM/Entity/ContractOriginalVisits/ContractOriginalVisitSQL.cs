// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalVisits.ContractOriginalVisitSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOriginalVisits
{
  public class ContractOriginalVisitSQL
  {
    private Database _database;

    public ContractOriginalVisitSQL(Database database)
    {
      this._database = database;
    }

    public DataView GetAll_For_ContractSiteID(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractOriginalVisit_GetAll_For_ContractSiteID", true);
      table.TableName = "ContractOriginalVisit";
      return new DataView(table);
    }

    public ContractOriginalVisit Insert(ContractOriginalVisit oContractVisit)
    {
      this._database.ClearParameter();
      this.AddContractVisitParametersToCommand(ref oContractVisit);
      oContractVisit.SetContractVisitID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOriginalVisit_Insert", true)));
      oContractVisit.Exists = true;
      return oContractVisit;
    }

    public void Delete(int ContractVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractVisitID", (object) ContractVisitID, true);
      this._database.ExecuteSP_NO_Return("ContractOriginalVisit_Delete", true);
    }

    private void AddContractVisitParametersToCommand(ref ContractOriginalVisit oContractVisit)
    {
      Database database = this._database;
      database.AddParameter("@ContractSiteID", (object) oContractVisit.ContractSiteID, true);
      database.AddParameter("@VisitDate", (object) oContractVisit.EstimatedVisitDate, true);
      database.AddParameter("@JobID", (object) oContractVisit.JobID, true);
      database.AddParameter("@Cost", (object) oContractVisit.Cost, true);
      database.AddParameter("@SubcontractorID", (object) oContractVisit.SubContractorID, true);
      database.AddParameter("@PreferredEngineerID", (object) oContractVisit.PreferredEngineerID, true);
      database.AddParameter("@VisitTypeID", (object) oContractVisit.VisitTypeID, true);
      database.AddParameter("@FrequencyID", (object) oContractVisit.FrequencyID, true);
      database.AddParameter("@Frequency", (object) oContractVisit.Frequency, true);
      database.AddParameter("@SubContractor", (object) oContractVisit.SubContractor, true);
      database.AddParameter("@PreferredEngineer", (object) oContractVisit.PreferredEngineer, true);
      database.AddParameter("@VisitType", (object) oContractVisit.VisitType, true);
      database.AddParameter("@HoursReq", (object) oContractVisit.HoursReq, true);
      database.AddParameter("@AdditionalNotes", (object) oContractVisit.AdditionalNotes, true);
    }
  }
}
