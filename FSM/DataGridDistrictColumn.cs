// Decompiled with JetBrains decompiler
// Type: FSM.DataGridDistrictColumn
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
  public class DataGridDistrictColumn : DataGridLabelColumn
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
      bool flag = false;
      if (dataRow.Table.Columns.Contains("CommercialDistrict"))
        flag = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["CommercialDistrict"]));
      backBrush = !flag ? backBrush : Brushes.Orange;
      base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
    }
  }
}
