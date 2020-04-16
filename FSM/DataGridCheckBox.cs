// Decompiled with JetBrains decompiler
// Type: FSM.DataGridCheckBox
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DataGridCheckBox : DataGridColumnStyle
  {
    private bool isEditing;

    internal virtual CheckBox chkBox { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public DataGridCheckBox()
    {
      this.chkBox = new CheckBox();
      this.chkBox.Checked = false;
      this.chkBox.Visible = false;
      this.chkBox.CheckAlign = ContentAlignment.MiddleCenter;
      this.Alignment = HorizontalAlignment.Center;
    }

    protected override void Abort(int rowNum)
    {
      this.isEditing = false;
      this.chkBox.CheckedChanged -= new EventHandler(this.CheckBoxChanged);
      this.Invalidate();
    }

    public event DataGridCheckBox.CheckedChangedEventHandler CheckedChanged;

    private void CheckBoxChanged(object sender, EventArgs e)
    {
      this.isEditing = true;
      base.ColumnStartedEditing((Control) this.chkBox);
    }

    protected override bool Commit(CurrencyManager dataSource, int rowNum)
    {
      this.chkBox.Bounds = Rectangle.Empty;
      this.chkBox.CheckedChanged += new EventHandler(this.CheckBoxChanged);
      this.isEditing = false;
      this.chkBox.Enabled = true;
      try
      {
        int num = checked (-(this.chkBox.Checked ? 1 : 0) * -1);
        this.SetColumnValueAtRow(dataSource, rowNum, (object) num);
        // ISSUE: reference to a compiler-generated field
        DataGridCheckBox.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
        if (checkedChangedEvent != null)
          checkedChangedEvent(-(this.chkBox.Checked ? 1 : 0));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.Invalidate();
      try
      {
        ((DataRowView) dataSource.Current).Row.AcceptChanges();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return true;
    }

    protected override void Edit(
      CurrencyManager source,
      int rowNum,
      Rectangle bounds,
      bool readOnly,
      string instantText,
      bool cellIsVisible)
    {
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.GetColumnValueAtRow(source, rowNum))))
      {
        bool boolean = Conversions.ToBoolean(this.GetColumnValueAtRow(source, rowNum));
        if (cellIsVisible)
        {
          this.chkBox.Bounds = new Rectangle(checked (bounds.X + 2), checked (bounds.Y + 2), checked (bounds.Width - 4), checked (bounds.Height - 4));
          this.chkBox.BackColor = Color.Transparent;
          this.chkBox.Checked = !boolean;
          this.chkBox.Visible = true;
          this.SetColumnValueAtRow(source, rowNum, (object) this.chkBox.Checked);
          this.chkBox.CheckedChanged += new EventHandler(this.CheckBoxChanged);
          // ISSUE: reference to a compiler-generated field
          DataGridCheckBox.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
          if (checkedChangedEvent != null)
            checkedChangedEvent(-(this.chkBox.Checked ? 1 : 0));
        }
        else
        {
          this.chkBox.Checked = boolean;
          this.chkBox.Visible = false;
        }
        if (this.chkBox.Visible)
          this.DataGridTableStyle.DataGrid.Invalidate(bounds);
      }
      this.Commit(source, rowNum);
      this.ConcedeFocus();
      this.UpdateUI(source, rowNum, instantText);
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
      Rectangle rectangle = new Rectangle(checked (bounds.X + 1), checked (bounds.Y + 1), checked (bounds.Width - 3), checked (bounds.Height - 3));
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.GetColumnValueAtRow(source, rowNum))))
      {
        bool boolean = Conversions.ToBoolean(this.GetColumnValueAtRow(source, rowNum));
        g.FillRectangle(backBrush, bounds);
        if (boolean)
          ControlPaint.DrawCheckBox(g, rectangle, ButtonState.Checked);
        else
          ControlPaint.DrawCheckBox(g, rectangle, ButtonState.Normal);
      }
      else
      {
        g.FillRectangle(backBrush, bounds);
        ControlPaint.DrawCheckBox(g, rectangle, ButtonState.Inactive);
      }
    }

    protected override void SetDataGridInColumn(DataGrid value)
    {
      base.SetDataGridInColumn(value);
      if (this.chkBox.Parent != null)
        this.chkBox.Parent.Controls.Remove((Control) this.chkBox);
      value?.Controls.Add((Control) this.chkBox);
    }

    public override bool ReadOnly
    {
      get
      {
        return !this.chkBox.Enabled;
      }
      set
      {
        this.chkBox.Enabled = !value;
      }
    }

    protected override Size GetPreferredSize(Graphics g, object value)
    {
      Size size;
      return size;
    }

    protected override int GetMinimumHeight()
    {
      int num;
      return num;
    }

    protected override int GetPreferredHeight(Graphics g, object value)
    {
      int num;
      return num;
    }

    protected override void ColumnStartedEditing(Control editingControl)
    {
    }

    protected override void Paint(
      Graphics g,
      Rectangle bounds,
      CurrencyManager source,
      int rowNum)
    {
    }

    protected override void Paint(
      Graphics g,
      Rectangle bounds,
      CurrencyManager source,
      int rowNum,
      bool alignToRight)
    {
    }

    public delegate void CheckedChangedEventHandler(int @checked);
  }
}
