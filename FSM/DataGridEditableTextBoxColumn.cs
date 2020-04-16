// Decompiled with JetBrains decompiler
// Type: FSM.DataGridEditableTextBoxColumn
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
  public class DataGridEditableTextBoxColumn : DataGridTextBoxColumn
  {
    private Brush _backColour;

    public DataGridEditableTextBoxColumn()
    {
      this._backColour = Brushes.White;
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
      try
      {
        backBrush = this._backColour;
        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public Brush BackColourBrush
    {
      get
      {
        return this._backColour;
      }
      set
      {
        this._backColour = value;
      }
    }
  }
}
