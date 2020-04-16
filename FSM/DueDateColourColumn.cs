// Decompiled with JetBrains decompiler
// Type: FSM.DueDateColourColumn
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DueDateColourColumn : DataGridLabelColumn
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
      Brush brush = ((DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "NextVisitDate"
      }, (string[]) null, (System.Type[]) null, (bool[]) null))), DateAndTime.Now.AddDays(14.0)) < 0 ? 1 : 0) & ((uint) Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "Type"
      }, (string[]) null, (System.Type[]) null, (bool[]) null))), "Letter 3", false) > 0U ? 1 : 0) | (DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "NextVisitDate"
      }, (string[]) null, (System.Type[]) null, (bool[]) null))), DateAndTime.Now.AddDays(9.0)) < 0 ? 1 : 0) & (Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "Type"
      }, (string[]) null, (System.Type[]) null, (bool[]) null))), "Letter 3", false) == 0 ? 1 : 0)) == 0 ? Brushes.White : Brushes.Red;
      Rectangle rect = bounds;
      g.FillRectangle(brush, rect);
      string s = Strings.Format((object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) "NextVisitDate"
      }, (string[]) null, (System.Type[]) null, (bool[]) null))), "dddd dd/MM/yyyy");
      g.DrawString(s, this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
    }
  }
}
