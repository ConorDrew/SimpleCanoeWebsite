// Decompiled with JetBrains decompiler
// Type: FSM.Entity.StockTakeAuditSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Runtime.CompilerServices;

namespace FSM.Entity
{
  public class StockTakeAuditSQL
  {
    private Database _database;

    public StockTakeAuditSQL(Database database)
    {
      this._database = database;
    }

    private void AddStockTakeAuditParametersToCommand(StockTakeAudit oStockTakeAudit)
    {
      this._database.AddParameter("@PartID", (object) oStockTakeAudit.PartID, true);
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.AddParameter("@OriginalAmount", (object) oStockTakeAudit.OriginalAmount, true);
      this._database.AddParameter("@NewAmount", (object) oStockTakeAudit.NewAmount, true);
      this._database.AddParameter("@ReasonChangeID", (object) oStockTakeAudit.ReasonChange, true);
      this._database.AddParameter("@LocationID", (object) oStockTakeAudit.LocationID, true);
    }

    public StockTakeAudit Insert(StockTakeAudit oStockTakeAudit)
    {
      this._database.ClearParameter();
      this.AddStockTakeAuditParametersToCommand(oStockTakeAudit);
      oStockTakeAudit.SetStockTakeAuditID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("StockTakeAudit_Insert", true)));
      oStockTakeAudit.Exists = true;
      return oStockTakeAudit;
    }
  }
}
