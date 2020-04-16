// Decompiled with JetBrains decompiler
// Type: FSM.DataGridSiteSafetyAuditColumn
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
  public class DataGridSiteSafetyAuditColumn : DataGridLabelColumn
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
      if (dataRow.Table.Columns.Contains("Result"))
      {
        double num = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["Result"]));
        if (num >= 90.0)
        {
          backBrush = Brushes.Green;
          foreBrush = (Brush) new SolidBrush(Helper.ContrastColor(Color.Green));
        }
        else if (num >= 75.0 && num < 90.0)
        {
          backBrush = Brushes.Orange;
          foreBrush = (Brush) new SolidBrush(Helper.ContrastColor(Color.Orange));
        }
        else if (num >= 60.0 && num < 75.0)
        {
          backBrush = Brushes.Orange;
          foreBrush = (Brush) new SolidBrush(Helper.ContrastColor(Color.Orange));
        }
        else
        {
          backBrush = Brushes.Red;
          foreBrush = (Brush) new SolidBrush(Helper.ContrastColor(Color.Red));
        }
      }
      base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
    }
  }
}
