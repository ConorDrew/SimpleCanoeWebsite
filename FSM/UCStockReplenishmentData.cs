// Decompiled with JetBrains decompiler
// Type: FSM.UCStockReplenishmentData
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCStockReplenishmentData : UCBase
  {
    private IContainer components;
    private DataView _Data;
    private DataGridViewCellStyle m_SelectedStyle;
    private int m_SelectedRow;

    public UCStockReplenishmentData()
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
        DataGridViewCellEventHandler cellEventHandler1 = new DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
        EventHandler eventHandler1 = new EventHandler(this.dgvData_Click);
        DataGridViewCellEventHandler cellEventHandler2 = new DataGridViewCellEventHandler(this.dgvData_RowLeave);
        EventHandler eventHandler2 = new EventHandler(this.dgvData_SelectionChanged);
        DataGridViewCellMouseEventHandler mouseEventHandler = new DataGridViewCellMouseEventHandler(this.dgvData_ColumnHeaderMouseClick);
        DataGridViewCellEventHandler cellEventHandler3 = new DataGridViewCellEventHandler(this.dgvData_RowLeave1);
        DataGridView dgvData1 = this._dgvData;
        if (dgvData1 != null)
        {
          dgvData1.CellValueChanged -= cellEventHandler1;
          dgvData1.DoubleClick -= eventHandler1;
          dgvData1.CellEndEdit -= cellEventHandler2;
          dgvData1.SelectionChanged -= eventHandler2;
          dgvData1.ColumnHeaderMouseClick -= mouseEventHandler;
          dgvData1.RowLeave -= cellEventHandler3;
        }
        this._dgvData = value;
        DataGridView dgvData2 = this._dgvData;
        if (dgvData2 == null)
          return;
        dgvData2.CellValueChanged += cellEventHandler1;
        dgvData2.DoubleClick += eventHandler1;
        dgvData2.CellEndEdit += cellEventHandler2;
        dgvData2.SelectionChanged += eventHandler2;
        dgvData2.ColumnHeaderMouseClick += mouseEventHandler;
        dgvData2.RowLeave += cellEventHandler3;
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
        this._Data.AllowEdit = true;
        this._Data.AllowDelete = false;
        this.dgvData.AutoGenerateColumns = false;
        this.dgvData.DataSource = (object) this.Data;
      }
    }

    public void SetupDG()
    {
      this.dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvData.Font = new Font("Arial", 7f);
      DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn.FillWeight = 5f;
      viewCheckBoxColumn.HeaderText = "Exclude";
      viewCheckBoxColumn.DataPropertyName = "Exclude";
      viewCheckBoxColumn.ReadOnly = false;
      viewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
      viewCheckBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn);
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "ID";
      viewTextBoxColumn1.DataPropertyName = "ID";
      viewTextBoxColumn1.ReadOnly = false;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Location";
      viewTextBoxColumn2.DataPropertyName = "Location";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "WarehouseID";
      viewTextBoxColumn3.DataPropertyName = "WarehouseID";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = false;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "VanID";
      viewTextBoxColumn4.DataPropertyName = "VanID";
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.Visible = false;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Part Name";
      viewTextBoxColumn5.DataPropertyName = "Item";
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.Visible = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.HeaderText = "Part ID";
      viewTextBoxColumn6.DataPropertyName = "PartID";
      viewTextBoxColumn6.ReadOnly = true;
      viewTextBoxColumn6.Visible = false;
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.HeaderText = "PartSupplierID";
      viewTextBoxColumn7.DataPropertyName = "PartSupplierID";
      viewTextBoxColumn7.ReadOnly = true;
      viewTextBoxColumn7.Visible = false;
      viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.HeaderText = "Supplier";
      viewTextBoxColumn8.DataPropertyName = "PartSupplierName";
      viewTextBoxColumn8.ReadOnly = true;
      viewTextBoxColumn8.Visible = true;
      viewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
      DataGridViewTextBoxColumn viewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn9.FillWeight = 5f;
      viewTextBoxColumn9.HeaderText = "Minimum Quantity";
      viewTextBoxColumn9.DataPropertyName = "MinimumQuantity";
      viewTextBoxColumn9.ReadOnly = true;
      viewTextBoxColumn9.Visible = true;
      viewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn9);
      DataGridViewTextBoxColumn viewTextBoxColumn10 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn10.FillWeight = 5f;
      viewTextBoxColumn10.HeaderText = "Recommended Quantity";
      viewTextBoxColumn10.DataPropertyName = "RecommendedQuantity";
      viewTextBoxColumn10.ReadOnly = true;
      viewTextBoxColumn10.Visible = true;
      viewTextBoxColumn10.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn10);
      DataGridViewTextBoxColumn viewTextBoxColumn11 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn11.FillWeight = 5f;
      viewTextBoxColumn11.HeaderText = "Current Amount";
      viewTextBoxColumn11.DataPropertyName = "Amount";
      viewTextBoxColumn11.ReadOnly = true;
      viewTextBoxColumn11.Visible = true;
      viewTextBoxColumn11.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn11);
      DataGridViewTextBoxColumn viewTextBoxColumn12 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn12.FillWeight = 5f;
      viewTextBoxColumn12.HeaderText = "Packs On Order";
      viewTextBoxColumn12.DataPropertyName = "PacksOnOrder";
      viewTextBoxColumn12.ReadOnly = true;
      viewTextBoxColumn12.Visible = true;
      viewTextBoxColumn12.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn12);
      DataGridViewTextBoxColumn viewTextBoxColumn13 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn13.FillWeight = 5f;
      viewTextBoxColumn13.HeaderText = "Units On Order";
      viewTextBoxColumn13.DataPropertyName = "UnitsOnOrder";
      viewTextBoxColumn13.ReadOnly = true;
      viewTextBoxColumn13.Visible = true;
      viewTextBoxColumn13.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn13);
      DataGridViewTextBoxColumn viewTextBoxColumn14 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn14.FillWeight = 5f;
      viewTextBoxColumn14.HeaderText = "Amount To Order";
      viewTextBoxColumn14.DataPropertyName = "AmountToOrder";
      viewTextBoxColumn14.ReadOnly = false;
      viewTextBoxColumn14.Visible = true;
      viewTextBoxColumn14.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn14);
      DataGridViewTextBoxColumn viewTextBoxColumn15 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn15.HeaderText = "Filter Type";
      viewTextBoxColumn15.DataPropertyName = "FilterType";
      viewTextBoxColumn15.ReadOnly = true;
      viewTextBoxColumn15.Visible = false;
      viewTextBoxColumn15.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn15);
    }

    private void UCData_Load(object sender, EventArgs e)
    {
      this.SetupDG();
      this.m_SelectedStyle.BackColor = Color.LightBlue;
    }

    private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex != 14)
        return;
      int integer1 = Conversions.ToInteger(this.dgvData[1, e.RowIndex].Value);
      int integer2 = Conversions.ToInteger(this.dgvData.Rows[e.RowIndex].Cells[14].Value);
      App.DB.Location.StockTake_Replenishment_UpdateAmountToOrder(integer1, integer2);
    }

    private void dgvData_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(this.dgvData[6, this.dgvData.CurrentCell.RowIndex].Value);
      if ((uint) integer <= 0U)
        return;
      App.ShowForm(typeof (FRMPart), true, new object[2]
      {
        (object) integer,
        (object) false
      }, false);
    }

    private void dgvData_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex != 0)
        return;
      int integer = Conversions.ToInteger(this.dgvData[1, e.RowIndex].Value);
      bool boolean = Conversions.ToBoolean(this.dgvData.Rows[e.RowIndex].Cells[0].Value);
      App.DB.Location.StockTake_Replenishment_UpdateExclude(integer, boolean);
    }

    private void dgvData_SelectionChanged(object sender, EventArgs e)
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
