// Decompiled with JetBrains decompiler
// Type: FSM.Contract3AssetsColourColumn
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
  public class Contract3AssetsColourColumn : DataGridEditableTextBoxColumn
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
      string s;
      Brush brush;
      if (Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
      {
        (object) this.MappingName.ToString()
      }, (string[]) null, (System.Type[]) null, (bool[]) null))), "", false) == 0)
      {
        s = "-";
        brush = Brushes.White;
        this.ReadOnly = true;
      }
      else
      {
        brush = Brushes.Yellow;
        s = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) this.MappingName.ToString()
        }, (string[]) null, (System.Type[]) null, (bool[]) null)));
        this.ReadOnly = false;
        this.TextBox.TextChanged += new EventHandler(this.ValidateAssetDuration);
      }
      Rectangle rect = bounds;
      g.FillRectangle(brush, rect);
      g.DrawString(s, this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
    }

    private void ValidateAssetDuration(object sender, EventArgs e)
    {
      if (!(!Versioned.IsNumeric((object) ((TextBox) sender).Text) & ((TextBox) sender).Text.Trim().Length > 0))
        return;
      ((TextBox) sender).Text = Conversions.ToString(0);
    }
  }
}
