// Decompiled with JetBrains decompiler
// Type: FSM.DataGridVisitManagerColumn
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
  public class DataGridVisitManagerColumn : DataGridLabelColumn
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
      DataRow dataRow = (DataRow) NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null);
      if (dataRow.Table.Columns.Contains("VisitChargeable"))
      {
        switch (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["VisitChargeable"])))
        {
          case 66597:
            backBrush = Brushes.Yellow;
            break;
          case 66598:
            backBrush = Brushes.LightGreen;
            break;
          default:
            backBrush = backBrush;
            break;
        }
      }
      Rectangle rect = bounds;
      g.FillRectangle(backBrush, rect);
      g.DrawString("", this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
    }
  }
}
