// Decompiled with JetBrains decompiler
// Type: FSM.StockReplenishmentColourColumn
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
  public class StockReplenishmentColourColumn : DataGridLabelColumn
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
      Brush lightGreen = Brushes.LightGreen;
      Brush brush;
      if (((Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "UnitsOnOrder"
      }, (string[]) null, (System.Type[]) null, (bool[]) null))) > 0 ? 1 : 0) & (checked (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        unchecked ((object) "UnitsOnOrder")
      }, (string[]) null, (System.Type[]) null, (bool[]) null))) + Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        unchecked ((object) "Amount")
      }, (string[]) null, (System.Type[]) null, (bool[]) null)))) >= Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "MinimumQuantity"
      }, (string[]) null, (System.Type[]) null, (bool[]) null))) ? 1 : 0)) != 0)
        brush = Brushes.LightBlue;
      else if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "Amount"
      }, (string[]) null, (System.Type[]) null, (bool[]) null))) < Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "MinimumQuantity"
      }, (string[]) null, (System.Type[]) null, (bool[]) null))))
        brush = Brushes.Salmon;
      else
        brush = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) "Amount"
        }, (string[]) null, (System.Type[]) null, (bool[]) null))) >= Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) "RecommendedQuantity"
        }, (string[]) null, (System.Type[]) null, (bool[]) null))) ? Brushes.LightGreen : Brushes.Yellow;
      Rectangle rect = bounds;
      g.FillRectangle(brush, rect);
      g.DrawString(Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "Amount"
      }, (string[]) null, (System.Type[]) null, (bool[]) null)))), this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
    }
  }
}
