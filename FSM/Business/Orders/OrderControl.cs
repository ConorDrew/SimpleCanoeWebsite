// Decompiled with JetBrains decompiler
// Type: FSM.Business.Orders.OrderControl
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.CostCentres;
using FSM.Entity.Jobs;
using FSM.Entity.Orders;
using FSM.Entity.Sys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FSM.Business.Orders
{
  public class OrderControl
  {
    private Order _order;

    public OrderControl(Order order)
    {
      this._order = order;
    }

    public bool IsWithinJobSpendLimit()
    {
      Job byOrderId = App.DB.Job.Job_Get_ByOrderID(this._order.OrderID);
      bool flag;
      if (byOrderId == null)
      {
        flag = true;
      }
      else
      {
        Decimal jobSpendLimit = this.GetJobSpendLimit(byOrderId.JobID);
        flag = Decimal.Compare(jobSpendLimit, Decimal.MinusOne) == 0 || Decimal.Compare(this.GetCurrentJobCost(byOrderId.JobID), jobSpendLimit) <= 0;
      }
      return flag;
    }

    private Decimal GetJobSpendLimit(int jobId)
    {
      Decimal num = Decimal.MinusOne;
      List<CostCentre> source = App.DB.CostCentre.Get(jobId, 0, FSM.Entity.CostCentres.Enums.GetBy.JobId);
      CostCentre costCentre = source != null ? source.FirstOrDefault<CostCentre>() : (CostCentre) null;
      if (costCentre != null && Decimal.Compare(costCentre.JobSpendLimit, Decimal.Zero) > 0)
      {
        num = costCentre.JobSpendLimit;
      }
      else
      {
        FSM.Entity.Customers.Customer byOrderId = App.DB.Customer.Customer_Get_ByOrderID(this._order.OrderID);
        if (byOrderId != null && Decimal.Compare(byOrderId.JobSpendLimit, Decimal.Zero) > 0)
          num = byOrderId.JobSpendLimit;
      }
      return num;
    }

    private Decimal GetCurrentJobCost(int jobId)
    {
      DataView currentCostByJobId = App.DB.EngineerVisitsPartsAndProducts.Get_CurrentCost_ByJobID(jobId);
      Decimal num = new Decimal();
      IEnumerator enumerator;
      try
      {
        enumerator = currentCostByJobId.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (!Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Part"])).Contains("IBC"))
            num = new Decimal(Convert.ToDouble(num) + Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Cost"])));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return num;
    }
  }
}
