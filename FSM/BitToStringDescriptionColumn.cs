// Decompiled with JetBrains decompiler
// Type: FSM.BitToStringDescriptionColumn
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class BitToStringDescriptionColumn : DataGridEditableTextBoxColumn
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
      Brush white = Brushes.White;
      try
      {
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      string s = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) this.MappingName.ToString()
      }, (string[]) null, (System.Type[]) null, (bool[]) null))) ? "No" : "Yes";
      Rectangle rect = bounds;
      g.FillRectangle(white, rect);
      g.DrawString(s, this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
    }
  }
}
