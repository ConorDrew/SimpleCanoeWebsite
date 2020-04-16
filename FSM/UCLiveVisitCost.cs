// Decompiled with JetBrains decompiler
// Type: FSM.UCLiveVisitCost
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCLiveVisitCost : UCBase
  {
    private IContainer components;
    private DataView _Data;
    private DataGridViewCellStyle m_SelectedStyle;
    private int m_SelectedRow;

    public UCLiveVisitCost()
    {
      this.Load += new EventHandler(this.UCData_Load);
      this.m_SelectedStyle = new DataGridViewCellStyle();
      this.m_SelectedRow = -1;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual DataGridView dgvData
    {
      get
      {
        return this._dgvData;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.DataGridView1_SelectionChanged);
        DataGridViewCellMouseEventHandler mouseEventHandler = new DataGridViewCellMouseEventHandler(this.dgvData_ColumnHeaderMouseClick);
        DataGridViewCellEventHandler cellEventHandler = new DataGridViewCellEventHandler(this.dgvData_RowLeave1);
        DataGridView dgvData1 = this._dgvData;
        if (dgvData1 != null)
        {
          dgvData1.SelectionChanged -= eventHandler;
          dgvData1.ColumnHeaderMouseClick -= mouseEventHandler;
          dgvData1.RowLeave -= cellEventHandler;
        }
        this._dgvData = value;
        DataGridView dgvData2 = this._dgvData;
        if (dgvData2 == null)
          return;
        dgvData2.SelectionChanged += eventHandler;
        dgvData2.ColumnHeaderMouseClick += mouseEventHandler;
        dgvData2.RowLeave += cellEventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.dgvData = new DataGridView();
      ((ISupportInitialize) this.dgvData).BeginInit();
      this.SuspendLayout();
      this.dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvData.Location = new System.Drawing.Point(0, 0);
      this.dgvData.Name = "dgvData";
      this.dgvData.Size = new Size(512, 344);
      this.dgvData.TabIndex = 3;
      this.Controls.Add((Control) this.dgvData);
      this.Name = "UCData";
      this.Size = new Size(512, 344);
      ((ISupportInitialize) this.dgvData).EndInit();
      this.ResumeLayout(false);
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.Data;
      }
    }

    public DataView Data
    {
      get
      {
        return this._Data;
      }
      set
      {
        this._Data = value;
        this._Data.AllowNew = false;
        this._Data.AllowEdit = false;
        this._Data.AllowDelete = false;
        this.dgvData.AutoGenerateColumns = true;
        this.dgvData.DataSource = (object) this.Data;
      }
    }

    public void SetupDG()
    {
      this.dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void UCData_Load(object sender, EventArgs e)
    {
      this.SetupDG();
      this.m_SelectedStyle.BackColor = Color.LightBlue;
    }

    private void DataGridView1_SelectionChanged(object sender, EventArgs e)
    {
      if (this.m_SelectedRow == -1)
        return;
      this.m_SelectedRow = this.dgvData.CurrentRow.Index;
      this.dgvData.CurrentRow.DefaultCellStyle = this.m_SelectedStyle;
    }

    private void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      DataGridViewColumn column = this.dgvData.Columns[e.ColumnIndex];
      DataGridViewColumn sortedColumn = this.dgvData.SortedColumn;
      ListSortDirection direction;
      if (sortedColumn != null)
      {
        if (sortedColumn == column && this.dgvData.SortOrder == SortOrder.Ascending)
        {
          direction = ListSortDirection.Descending;
        }
        else
        {
          direction = ListSortDirection.Ascending;
          sortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
        }
      }
      else
        direction = ListSortDirection.Ascending;
      this.dgvData.Sort(column, direction);
      if (direction == ListSortDirection.Ascending)
        column.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
      else
        column.HeaderCell.SortGlyphDirection = SortOrder.Descending;
    }

    private void dgvData_RowLeave1(object sender, DataGridViewCellEventArgs e)
    {
      if (this.m_SelectedRow < 0)
        return;
      this.dgvData.Rows[this.m_SelectedRow].DefaultCellStyle = (DataGridViewCellStyle) null;
    }
  }
}
