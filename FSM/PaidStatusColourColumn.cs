// Decompiled with JetBrains decompiler
// Type: FSM.PaidStatusColourColumn
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class PaidStatusColourColumn : DataGridLabelColumn
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
      Brush brush;
      switch (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "PaidStatus"
      }, (string[]) null, (System.Type[]) null, (bool[]) null))))
      {
        case -2:
          brush = Brushes.White;
          break;
        case -1:
          brush = Brushes.Red;
          break;
        case 0:
          brush = Brushes.Gold;
          break;
        case 1:
          brush = Brushes.LightGreen;
          break;
      }
      Rectangle rect = bounds;
      g.FillRectangle(brush, rect);
      g.DrawString("", this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
    }
  }
}
