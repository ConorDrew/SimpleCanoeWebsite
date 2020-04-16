// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalSiteRatess.ContractOriginalSiteRatesSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOriginalSiteRatess
{
  public class ContractOriginalSiteRatesSQL
  {
    private Database _database;

    public ContractOriginalSiteRatesSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int ContractOriginalSiteRateID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractOriginalSiteRateID", (object) ContractOriginalSiteRateID, true);
      this._database.ExecuteSP_NO_Return("ContractOriginalSiteRates_Delete", true);
    }

    public ContractOriginalSiteRates ContractOriginalSiteRates_Get(
      int ContractOriginalSiteRateID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractOriginalSiteRateID", (object) ContractOriginalSiteRateID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (ContractOriginalSiteRates_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (ContractOriginalSiteRates) null;
      ContractOriginalSiteRates originalSiteRates1 = new ContractOriginalSiteRates();
      ContractOriginalSiteRates originalSiteRates2 = originalSiteRates1;
      originalSiteRates2.IgnoreExceptionsOnSetMethods = true;
      originalSiteRates2.SetContractOriginalSiteRateID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ContractOriginalSiteRateID)]);
      originalSiteRates2.SetContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractSiteID"]);
      originalSiteRates2.SetRateID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RateID"]);
      originalSiteRates2.SetQty = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Qty"]);
      originalSiteRates2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      originalSiteRates1.Exists = true;
      return originalSiteRates1;
    }

    public DataView ContractOriginalSiteRates_GetForContractSite(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, false);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (ContractOriginalSiteRates_GetForContractSite), true);
      table.TableName = Enums.TableNames.tblContractOriginalSiteRates.ToString();
      return new DataView(table);
    }

    public DataView ContractOriginalSiteRates_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (ContractOriginalSiteRates_GetAll), true);
      table.TableName = Enums.TableNames.tblContractOriginalSiteRates.ToString();
      return new DataView(table);
    }

    public ContractOriginalSiteRates Insert(
      ContractOriginalSiteRates oContractOriginalSiteRates)
    {
      this._database.ClearParameter();
      this.AddContractOriginalSiteRatesParametersToCommand(ref oContractOriginalSiteRates);
      oContractOriginalSiteRates.SetContractOriginalSiteRateID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOriginalSiteRates_Insert", true)));
      oContractOriginalSiteRates.Exists = true;
      return oContractOriginalSiteRates;
    }

    public void Update(
      ContractOriginalSiteRates oContractOriginalSiteRates)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractOriginalSiteRateID", (object) oContractOriginalSiteRates.ContractOriginalSiteRateID, true);
      this.AddContractOriginalSiteRatesParametersToCommand(ref oContractOriginalSiteRates);
      this._database.ExecuteSP_NO_Return("ContractOriginalSiteRates_Update", true);
    }

    private void AddContractOriginalSiteRatesParametersToCommand(
      ref ContractOriginalSiteRates oContractOriginalSiteRates)
    {
      Database database = this._database;
      database.AddParameter("@ContractSiteID", (object) oContractOriginalSiteRates.ContractSiteID, true);
      database.AddParameter("@RateID", (object) oContractOriginalSiteRates.RateID, true);
      database.AddParameter("@Qty", (object) oContractOriginalSiteRates.Qty, true);
    }
  }
}
