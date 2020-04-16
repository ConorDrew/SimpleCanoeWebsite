// Decompiled with JetBrains decompiler
// Type: FSM.ImporterLabelColumn
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
  public class ImporterLabelColumn : DataGridTextBoxColumn
  {
    private string _ColumnName;

    protected override void Edit(
      CurrencyManager source,
      int rowNum,
      Rectangle bounds,
      bool readOnly,
      string instantText)
    {
    }

    protected override void Edit(
      CurrencyManager source,
      int rowNum,
      Rectangle bounds,
      bool readOnly,
      string instantText,
      bool cellIsVisible)
    {
    }

    protected override void Edit(
      CurrencyManager source,
      int rowNum,
      Rectangle bounds,
      bool readOnly)
    {
    }

    public string ColumnName
    {
      get
      {
        return this._ColumnName;
      }
      set
      {
        this._ColumnName = value;
      }
    }

    public ImporterLabelColumn(string ColumnNameIn)
    {
      this.ColumnName = ColumnNameIn;
    }

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
      Rectangle rect = bounds;
      try
      {
        if (Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) (this.ColumnName + "COLOURBOOLEANCOLUMN")
        }, (string[]) null, (System.Type[]) null, (bool[]) null)))
          g.FillRectangle(Brushes.Red, rect);
        else
          g.FillRectangle(Brushes.White, rect);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        g.FillRectangle(Brushes.White, rect);
        ProjectData.ClearProjectError();
      }
      Graphics graphics = g;
      object[] objArray;
      bool[] flagArray;
      object obj = NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", objArray = new object[1]
      {
        (object) this.ColumnName
      }, (string[]) null, (System.Type[]) null, flagArray = new bool[1]
      {
        true
      });
      if (flagArray[0])
        this.ColumnName = (string) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof (string));
      string s = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(obj));
      Font font = this.DataGridTableStyle.DataGrid.Font;
      Brush midnightBlue = Brushes.MidnightBlue;
      RectangleF layoutRectangle = RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom);
      graphics.DrawString(s, font, midnightBlue, layoutRectangle);
    }
  }
}
