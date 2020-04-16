// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItemsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractAlternativeSiteJobItems
{
  public class ContractAlternativeSiteJobItemsSQL
  {
    private Database _database;

    public ContractAlternativeSiteJobItemsSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int ContractSiteJobItemID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteJobItemID", (object) ContractSiteJobItemID, true);
      this._database.ExecuteSP_NO_Return("ContractAlternativeSiteJobItems_Delete", true);
    }

    public FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems Get(
      int ContractSiteJobItemID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteJobItemID", (object) ContractSiteJobItemID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems) null;
      FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems alternativeSiteJobItems1 = new FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems();
      FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems alternativeSiteJobItems2 = alternativeSiteJobItems1;
      alternativeSiteJobItems2.IgnoreExceptionsOnSetMethods = true;
      alternativeSiteJobItems2.SetContractSiteJobItemID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ContractSiteJobItemID)]);
      alternativeSiteJobItems2.SetContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractSiteID"]);
      alternativeSiteJobItems2.SetDescription = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Description"]);
      alternativeSiteJobItems2.SetVisitFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitFrequencyID"]);
      alternativeSiteJobItems2.SetVisitDuration = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitDuration"]);
      alternativeSiteJobItems2.SetItemPricePerVisit = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ItemPricePerVisit"]);
      alternativeSiteJobItems2.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobOfWorkID"]);
      alternativeSiteJobItems2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      alternativeSiteJobItems1.Exists = true;
      return alternativeSiteJobItems1;
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_GetAll", true);
      table.TableName = Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
      return new DataView(table);
    }

    public DataView GetAll_For_ContractSiteID(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, false);
      DataTable table = this._database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_GetAll_For_ContractSiteID", true);
      table.TableName = Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
      return new DataView(table);
    }

    public DataView GetAll_For_JobOfWorkID(int JobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID", (object) JobOfWorkID, false);
      DataTable table = this._database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_GetAll_For_JobOfWorkID", true);
      table.TableName = Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
      return new DataView(table);
    }

    public FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems Insert(
      FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems oContractAlternativeSiteJobItems)
    {
      this._database.ClearParameter();
      this.AddContractAlternativeSiteJobItemsParametersToCommand(ref oContractAlternativeSiteJobItems);
      oContractAlternativeSiteJobItems.SetContractSiteJobItemID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractAlternativeSiteJobItems_Insert", true)));
      oContractAlternativeSiteJobItems.Exists = true;
      return oContractAlternativeSiteJobItems;
    }

    public void Update(int ContractSiteJobItemID, int JobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteJobItemID", (object) ContractSiteJobItemID, true);
      this._database.AddParameter("@JobOfWorkID", (object) JobOfWorkID, true);
      this._database.ExecuteSP_NO_Return("ContractAlternativeSiteJobItems_Update", true);
    }

    private void AddContractAlternativeSiteJobItemsParametersToCommand(
      ref FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems oContractAlternativeSiteJobItems)
    {
      Database database = this._database;
      database.AddParameter("@ContractSiteID", (object) oContractAlternativeSiteJobItems.ContractSiteID, true);
      database.AddParameter("@Description", (object) oContractAlternativeSiteJobItems.Description, true);
      database.AddParameter("@VisitFrequencyID", (object) oContractAlternativeSiteJobItems.VisitFrequencyID, true);
      database.AddParameter("@VisitDuration", (object) oContractAlternativeSiteJobItems.VisitDuration, true);
      database.AddParameter("@ItemPricePerVisit", (object) oContractAlternativeSiteJobItems.ItemPricePerVisit, true);
      database.AddParameter("@JobOfWorkID", (object) oContractAlternativeSiteJobItems.JobOfWorkID, true);
    }
  }
}
