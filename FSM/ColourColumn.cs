// Decompiled with JetBrains decompiler
// Type: FSM.ColourColumn
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
  public class ColourColumn : DataGridLabelColumn
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
      string s = "";
      Brush brush = Brushes.White;
      string Left = this.MappingName.ToString();
      if (Operators.CompareString(Left, "PartsToFit", false) != 0)
      {
        if (Operators.CompareString(Left, "AllPartsReceived", false) == 0)
        {
          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
          {
            (object) this.MappingName.ToString()
          }, (string[]) null, (System.Type[]) null, (bool[]) null))))
            brush = Brushes.Blue;
          this.TextBox.Text = "";
        }
      }
      else
      {
        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) this.MappingName.ToString()
        }, (string[]) null, (System.Type[]) null, (bool[]) null))))
          brush = Brushes.Orange;
        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) "PartsNeedOrdering"
        }, (string[]) null, (System.Type[]) null, (bool[]) null))))
          brush = Brushes.Purple;
        this.TextBox.Text = "";
      }
      Rectangle rect = bounds;
      g.FillRectangle(brush, rect);
      g.DrawString(s, this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
    }
  }
}
