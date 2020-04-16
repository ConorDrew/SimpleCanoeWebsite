// Decompiled with JetBrains decompiler
// Type: FSM.DataGridSchedulerJobColumn
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DataGridSchedulerJobColumn : DataGridLabelColumn
  {
    protected override void Paint(
      Graphics g,
      Rectangle bounds,
      CurrencyManager source,
      int rowNum,
      Brush backBrush,
      Brush foreBrush,
      bool alignToRight)
    {
      DataRow dataRow = (DataRow) NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null);
      if (dataRow.Table.Columns.Contains("IsJobLate") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["IsJobLate"])))
        backBrush = Brushes.Red;
      if (dataRow.Table.Columns.Contains("IsServiceOverDue") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["IsServiceOverDue"])))
        backBrush = Brushes.Orange;
      if (dataRow.Table.Columns.Contains("Declined") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["Declined"])))
        backBrush = Brushes.LightGray;
      base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
    }
  }
}
