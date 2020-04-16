// Decompiled with JetBrains decompiler
// Type: FSM.DataGridOrderTextBoxColumn
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DataGridOrderTextBoxColumn : DataGridTextBoxColumn
  {
    public DataGridOrderTextBoxColumn()
    {
      this.TextBox.BackColor = Color.LightYellow;
    }

    protected override void Abort(int rowNum)
    {
      base.Abort(rowNum);
    }

    protected override bool Commit(CurrencyManager dataSource, int rowNum)
    {
      return base.Commit(dataSource, rowNum);
    }

    protected override void Edit(
      CurrencyManager source,
      int rowNum,
      Rectangle bounds,
      bool readOnly,
      string instantText,
      bool cellIsVisible)
    {
      this.TextBox.Enabled = true;
      base.Edit(source, rowNum, bounds, false, instantText, cellIsVisible);
    }

    protected override int GetMinimumHeight()
    {
      return base.GetMinimumHeight();
    }

    protected override int GetPreferredHeight(Graphics g, object value)
    {
      return base.GetPreferredHeight(g, RuntimeHelpers.GetObjectValue(value));
    }

    protected override Size GetPreferredSize(Graphics g, object value)
    {
      return base.GetPreferredSize(g, RuntimeHelpers.GetObjectValue(value));
    }

    protected override void Paint(
      Graphics g,
      Rectangle bounds,
      CurrencyManager source,
      int rowNum)
    {
      base.Paint(g, bounds, source, rowNum);
    }

    protected override void Paint(
      Graphics g,
      Rectangle bounds,
      CurrencyManager source,
      int rowNum,
      bool alignToRight)
    {
      base.Paint(g, bounds, source, rowNum, alignToRight);
    }
  }
}
