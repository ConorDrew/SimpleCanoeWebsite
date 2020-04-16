// Decompiled with JetBrains decompiler
// Type: FSM.DataGridSchedulerColumn
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
  public class DataGridSchedulerColumn : DataGridLabelColumn
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
      base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
      Brush brush = Brushes.White;
      Brush midnightBlue = Brushes.MidnightBlue;
      string s = "";
      DataRow dataRow = (DataRow) NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null);
      if (dataRow.Table.Columns.Contains("IsJobLate") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["IsJobLate"])))
      {
        brush = Brushes.Red;
        s = "L";
      }
      if (dataRow.Table.Columns.Contains("IsServiceOverDue") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["IsServiceOverDue"])))
      {
        brush = Brushes.Orange;
        s = "O";
      }
      if (dataRow.Table.Columns.Contains("Declined") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["Declined"])))
      {
        brush = Brushes.LightGray;
        s = "D";
      }
      Rectangle rect = bounds;
      g.FillRectangle(brush, rect);
      g.DrawString(s, this.DataGridTableStyle.DataGrid.Font, midnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
    }
  }
}
