// Decompiled with JetBrains decompiler
// Type: FSM.UCData
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
  public class UCData : UCBase
  {
    private IContainer components;
    private DataView _Data;
    private DataGridViewCellStyle m_SelectedStyle;
    private int m_SelectedRow;

    public UCData()
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
        EventHandler eventHandler1 = new EventHandler(this.dgData_Click);
        DataGridViewCellMouseEventHandler mouseEventHandler1 = new DataGridViewCellMouseEventHandler(this.dgData_CellMouseUp);
        DataGridViewCellEventHandler cellEventHandler1 = new DataGridViewCellEventHandler(this.dgvData_RowLeave);
        EventHandler eventHandler2 = new EventHandler(this.DataGridView1_SelectionChanged);
        DataGridViewCellMouseEventHandler mouseEventHandler2 = new DataGridViewCellMouseEventHandler(this.dgvData_ColumnHeaderMouseClick);
        DataGridViewCellEventHandler cellEventHandler2 = new DataGridViewCellEventHandler(this.dgvData_RowLeave1);
        DataGridView dgvData1 = this._dgvData;
        if (dgvData1 != null)
        {
          dgvData1.DoubleClick -= eventHandler1;
          dgvData1.CellMouseUp -= mouseEventHandler1;
          dgvData1.CellEndEdit -= cellEventHandler1;
          dgvData1.SelectionChanged -= eventHandler2;
          dgvData1.ColumnHeaderMouseClick -= mouseEventHandler2;
          dgvData1.RowLeave -= cellEventHandler2;
        }
        this._dgvData = value;
        DataGridView dgvData2 = this._dgvData;
        if (dgvData2 == null)
          return;
        dgvData2.DoubleClick += eventHandler1;
        dgvData2.CellMouseUp += mouseEventHandler1;
        dgvData2.CellEndEdit += cellEventHandler1;
        dgvData2.SelectionChanged += eventHandler2;
        dgvData2.ColumnHeaderMouseClick += mouseEventHandler2;
        dgvData2.RowLeave += cellEventHandler2;
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
      this.Name = nameof (UCData);
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
      DataGridViewCheckBoxColumn viewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn1.FillWeight = 25f;
      viewCheckBoxColumn1.HeaderText = "Exclude";
      viewCheckBoxColumn1.DataPropertyName = "Exclude";
      viewCheckBoxColumn1.ReadOnly = false;
      viewCheckBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn1);
      DataGridViewCheckBoxColumn viewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn2.FillWeight = 25f;
      viewCheckBoxColumn2.HeaderText = "Force Insert";
      viewCheckBoxColumn2.DataPropertyName = "ForceInsert";
      viewCheckBoxColumn2.ReadOnly = false;
      viewCheckBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "Import ID";
      viewTextBoxColumn1.DataPropertyName = "ImportID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Part ID";
      viewTextBoxColumn2.DataPropertyName = "PartID";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = false;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.FillWeight = 35f;
      viewTextBoxColumn3.HeaderText = "Import Price";
      viewTextBoxColumn3.DataPropertyName = "Import Price";
      viewTextBoxColumn3.ReadOnly = false;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      viewTextBoxColumn3.DefaultCellStyle.Format = "N3";
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.FillWeight = 35f;
      viewTextBoxColumn4.HeaderText = "Existing Price";
      viewTextBoxColumn4.DataPropertyName = "Existing Price";
      viewTextBoxColumn4.DefaultCellStyle.Format = "N3";
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.FillWeight = 35f;
      viewTextBoxColumn5.HeaderText = "Percent Difference";
      viewTextBoxColumn5.DataPropertyName = "PercentDifference";
      viewTextBoxColumn5.DefaultCellStyle.Format = "0.00\\%";
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.FillWeight = 35f;
      viewTextBoxColumn6.HeaderText = "Import Secondary Price";
      viewTextBoxColumn6.DataPropertyName = "Import Secondary Price";
      viewTextBoxColumn6.ReadOnly = false;
      viewTextBoxColumn6.DefaultCellStyle.Format = "N3";
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.FillWeight = 35f;
      viewTextBoxColumn7.HeaderText = "Existing Secondary Price";
      viewTextBoxColumn7.DataPropertyName = "Existing Secondary Price";
      viewTextBoxColumn7.ReadOnly = true;
      viewTextBoxColumn7.DefaultCellStyle.Format = "N3";
      viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.FillWeight = 35f;
      viewTextBoxColumn8.HeaderText = "Secondary Percent Difference";
      viewTextBoxColumn8.DataPropertyName = "SecondaryPercentDifference";
      viewTextBoxColumn8.DefaultCellStyle.Format = "0.00\\%";
      viewTextBoxColumn8.ReadOnly = true;
      viewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
      DataGridViewTextBoxColumn viewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn9.FillWeight = 200f;
      viewTextBoxColumn9.HeaderText = "Import Description";
      viewTextBoxColumn9.DataPropertyName = "Import Desc";
      viewTextBoxColumn9.ReadOnly = false;
      viewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn9);
      DataGridViewTextBoxColumn viewTextBoxColumn10 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn10.FillWeight = 200f;
      viewTextBoxColumn10.HeaderText = "Existing Description";
      viewTextBoxColumn10.DataPropertyName = "Existing Desc";
      viewTextBoxColumn10.ReadOnly = true;
      viewTextBoxColumn10.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn10);
      DataGridViewTextBoxColumn viewTextBoxColumn11 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn11.FillWeight = 75f;
      viewTextBoxColumn11.HeaderText = "Import MPN";
      viewTextBoxColumn11.DataPropertyName = "Import PC";
      viewTextBoxColumn11.ReadOnly = true;
      viewTextBoxColumn11.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn11);
      DataGridViewTextBoxColumn viewTextBoxColumn12 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn12.FillWeight = 75f;
      viewTextBoxColumn12.HeaderText = "Existing MPN";
      viewTextBoxColumn12.DataPropertyName = "Existing PC";
      viewTextBoxColumn12.ReadOnly = true;
      viewTextBoxColumn12.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn12);
      DataGridViewTextBoxColumn viewTextBoxColumn13 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn13.FillWeight = 75f;
      viewTextBoxColumn13.HeaderText = "Import SPN";
      viewTextBoxColumn13.DataPropertyName = "Import SPC";
      viewTextBoxColumn13.ReadOnly = false;
      viewTextBoxColumn13.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn13);
      DataGridViewTextBoxColumn viewTextBoxColumn14 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn14.FillWeight = 75f;
      viewTextBoxColumn14.HeaderText = "Existing SPN";
      viewTextBoxColumn14.DataPropertyName = "Existing SPC";
      viewTextBoxColumn14.ReadOnly = false;
      viewTextBoxColumn14.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn14);
      DataGridViewTextBoxColumn viewTextBoxColumn15 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn15.FillWeight = 100f;
      viewTextBoxColumn15.HeaderText = "Supplier Name";
      viewTextBoxColumn15.DataPropertyName = "Supplier Name";
      viewTextBoxColumn15.ReadOnly = true;
      viewTextBoxColumn15.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn15);
      DataGridViewTextBoxColumn viewTextBoxColumn16 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn16.FillWeight = 100f;
      viewTextBoxColumn16.HeaderText = "Category";
      viewTextBoxColumn16.DataPropertyName = "Category";
      viewTextBoxColumn16.Name = "Category";
      viewTextBoxColumn16.ReadOnly = true;
      viewTextBoxColumn16.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn16);
      DataGridViewCheckBoxColumn viewCheckBoxColumn3 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn3.FillWeight = 25f;
      viewCheckBoxColumn3.HeaderText = "Swap SPN";
      viewCheckBoxColumn3.DataPropertyName = "SwapSPN";
      viewCheckBoxColumn3.Name = "SwapSPN";
      viewCheckBoxColumn3.ReadOnly = false;
      viewTextBoxColumn2.Visible = false;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn3);
    }

    private void UCData_Load(object sender, EventArgs e)
    {
      this.m_SelectedStyle.BackColor = Color.LightBlue;
    }

    private void dgData_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(this.dgvData[3, this.dgvData.CurrentCell.RowIndex].Value);
      if ((uint) integer <= 0U)
        return;
      App.ShowForm(typeof (FRMPart), true, new object[2]
      {
        (object) integer,
        (object) false
      }, false);
    }

    private void dgData_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (!((e.ColumnIndex == 0 | e.ColumnIndex == this.dgvData.Columns["SwapSPN"].Index | e.ColumnIndex == 1) & e.RowIndex >= 0))
        return;
      this.dgvData.EndEdit();
    }

    private void dgvData_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0)
        return;
      int integer = Conversions.ToInteger(this.dgvData[2, e.RowIndex].Value);
      bool boolean1 = Conversions.ToBoolean(this.dgvData.Rows[e.RowIndex].Cells[0].Value);
      bool boolean2 = Conversions.ToBoolean(this.dgvData.Rows[e.RowIndex].Cells[1].Value);
      double ImportPrice = Conversions.ToDouble(this.dgvData[4, e.RowIndex].Value);
      bool boolean3 = Conversions.ToBoolean(this.dgvData.Rows[e.RowIndex].Cells[this.dgvData.Columns["SwapSPN"].Index].Value);
      string Category = Conversions.ToString(this.dgvData.Rows[e.RowIndex].Cells[this.dgvData.Columns["Category"].Index].Value);
      string ImportDescription = "";
      App.DB.ImportValidation.Parts_PreImportChange(integer, boolean1, boolean2, ImportPrice, ImportDescription, boolean3, Category);
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
