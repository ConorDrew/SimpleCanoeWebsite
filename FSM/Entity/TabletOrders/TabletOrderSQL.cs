// Decompiled with JetBrains decompiler
// Type: FSM.Entity.TabletOrders.TabletOrderSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Runtime.CompilerServices;

namespace FSM.Entity.TabletOrders
{
  public class TabletOrderSQL
  {
    private Database _database;

    public TabletOrderSQL(Database database)
    {
      this._database = database;
    }

    public int InsertTabletOrderItem(TabletOrderItem oTabletOrder)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) oTabletOrder.TabletOrderID, true);
      this._database.AddParameter("@EngineerID", (object) oTabletOrder.EngineerID, true);
      this._database.AddParameter("@SupplierID", (object) oTabletOrder.SupplierID, true);
      this._database.AddParameter("@SelectedVisitID", (object) oTabletOrder.SelectedVisitID, true);
      this._database.AddParameter("@ForNextVisit", (object) oTabletOrder.ForNextVisit, true);
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("TabletOrderItem_Insert", true)));
    }

    public int InsertTabletOrderPart(TabletOrderPart oTabletOrderPart)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderPartID", (object) oTabletOrderPart.OrderPartID, true);
      this._database.AddParameter("@OrderID", (object) oTabletOrderPart.OrderID, true);
      this._database.AddParameter("@EngineerID", (object) oTabletOrderPart.EngineerID, true);
      this._database.AddParameter("@Quantity", (object) oTabletOrderPart.Quantity, true);
      this._database.AddParameter("@PartSupplierID", (object) oTabletOrderPart.PartSupplierID, true);
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("TabletOrderPart_Insert", true)));
    }
  }
}
