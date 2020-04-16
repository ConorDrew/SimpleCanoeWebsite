// Decompiled with JetBrains decompiler
// Type: FSM.UCDataPODuplicateInvoice
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
  public class UCDataPODuplicateInvoice : UCBase
  {
    private IContainer components;
    private DataView _Data;
    private DataGridViewCellStyle m_SelectedStyle;
    private int m_SelectedRow;

    public UCDataPODuplicateInvoice()
    {
      this.Load += new EventHandler(this.UCDataPOInvoiceAuthorisation_Load);
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
        DataGridViewCellMouseEventHandler mouseEventHandler = new DataGridViewCellMouseEventHandler(this.dgvData_ColumnHeaderMouseClick);
        EventHandler eventHandler = (EventHandler) ((a0, a1) => this.dgvData_Click(RuntimeHelpers.GetObjectValue(a0), (MouseEventArgs) a1));
        DataGridView dgvData1 = this._dgvData;
        if (dgvData1 != null)
        {
          dgvData1.ColumnHeaderMouseClick -= mouseEventHandler;
          dgvData1.Click -= eventHandler;
        }
        this._dgvData = value;
        DataGridView dgvData2 = this._dgvData;
        if (dgvData2 == null)
          return;
        dgvData2.ColumnHeaderMouseClick += mouseEventHandler;
        dgvData2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.dgvData = new DataGridView();
      ((ISupportInitialize) this.dgvData).BeginInit();
      this.SuspendLayout();
      this.dgvData.AllowUserToAddRows = false;
      this.dgvData.AllowUserToDeleteRows = false;
      this.dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvData.Location = new System.Drawing.Point(0, 0);
      this.dgvData.Name = "dgvData";
      this.dgvData.Size = new Size(512, 344);
      this.dgvData.TabIndex = 3;
      this.Controls.Add((Control) this.dgvData);
      this.Name = "UCDataPartsInvoiceImport";
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
        this.dgvData.AutoGenerateColumns = false;
        this.dgvData.DataSource = (object) this.Data;
      }
    }

    public void SetupDG()
    {
      this.dgvData.AutoGenerateColumns = false;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "Invoice No";
      viewTextBoxColumn1.DataPropertyName = "InvoiceNo";
      viewTextBoxColumn1.FillWeight = 15f;
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Invoice Date";
      viewTextBoxColumn2.DataPropertyName = "InvoiceDate";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Purchase Order No";
      viewTextBoxColumn3.DataPropertyName = "PurchaseOrderNo";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Supplier ID";
      viewTextBoxColumn4.DataPropertyName = "SupplierID";
      viewTextBoxColumn4.Visible = false;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Supplier Part Code";
      viewTextBoxColumn5.DataPropertyName = "SupplierPartCode";
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.HeaderText = "Part Description";
      viewTextBoxColumn6.DataPropertyName = "Description";
      viewTextBoxColumn6.Visible = true;
      viewTextBoxColumn6.ReadOnly = true;
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.HeaderText = "Quantity Of Parts";
      viewTextBoxColumn7.DataPropertyName = "Quantity";
      viewTextBoxColumn7.FillWeight = 10f;
      viewTextBoxColumn7.ReadOnly = true;
      viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.HeaderText = "Unit Price";
      viewTextBoxColumn8.DataPropertyName = "UnitPrice";
      viewTextBoxColumn8.ReadOnly = true;
      viewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
      DataGridViewTextBoxColumn viewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn9.HeaderText = "Net Amount";
      viewTextBoxColumn9.DataPropertyName = "NetAmount";
      viewTextBoxColumn9.ReadOnly = true;
      viewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn9);
      DataGridViewTextBoxColumn viewTextBoxColumn10 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn10.HeaderText = "VAT Amount";
      viewTextBoxColumn10.DataPropertyName = "VATAmount";
      viewTextBoxColumn10.ReadOnly = true;
      viewTextBoxColumn10.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn10);
      DataGridViewTextBoxColumn viewTextBoxColumn11 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn11.HeaderText = "Gross Amount";
      viewTextBoxColumn11.DataPropertyName = "GrossAmount";
      viewTextBoxColumn11.ReadOnly = true;
      viewTextBoxColumn11.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn11);
      DataGridViewTextBoxColumn viewTextBoxColumn12 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn12.HeaderText = "Total Qty Of Parts";
      viewTextBoxColumn12.DataPropertyName = "TotalQtyOfParts";
      viewTextBoxColumn12.ReadOnly = true;
      viewTextBoxColumn12.Visible = false;
      viewTextBoxColumn12.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn12);
      DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn.FillWeight = 5f;
      viewCheckBoxColumn.HeaderText = "Allow";
      viewCheckBoxColumn.DataPropertyName = "Allow";
      viewCheckBoxColumn.ReadOnly = false;
      viewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn);
      DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn();
      viewButtonColumn.HeaderText = "Update";
      viewButtonColumn.DataPropertyName = "Update";
      viewButtonColumn.ReadOnly = true;
      viewButtonColumn.Visible = true;
      viewButtonColumn.DefaultCellStyle.NullValue = (object) "Update";
      viewButtonColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewButtonColumn);
      this.dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
    }

    private void UCDataPOInvoiceAuthorisation_Load(object sender, EventArgs e)
    {
      this.SetupDG();
      this.m_SelectedStyle.BackColor = Color.LightBlue;
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

    private void dgvData_Click(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left || this.dgvData.CurrentCell == null || (this.dgvData.CurrentCell.ColumnIndex != 13 || !Conversions.ToBoolean(this.dgvData[12, this.dgvData.CurrentCell.RowIndex].Value)) || App.ShowMessage("Add " + Conversions.ToString(this.dgvData[0, this.dgvData.CurrentCell.RowIndex].Value) + " to database?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
        return;
      App.DB.ImportValidation.POInvoiceImport_InsertPart(Conversions.ToString(this.dgvData[2, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToString(this.dgvData[4, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToString(this.dgvData[5, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToInteger(this.dgvData[6, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(this.dgvData[7, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(this.dgvData[8, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(this.dgvData[9, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(this.dgvData[10, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToString(this.dgvData[0, this.dgvData.CurrentCell.RowIndex].Value));
      App.DB.ImportValidation.POInvoiceImport_UpdateOrderTotals(Conversions.ToString(this.dgvData[2, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToInteger(this.dgvData[6, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(this.dgvData[7, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(this.dgvData[8, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(this.dgvData[9, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(this.dgvData[10, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToInteger(this.dgvData[11, this.dgvData.CurrentCell.RowIndex].Value), Conversions.ToString(this.dgvData[0, this.dgvData.CurrentCell.RowIndex].Value));
      this.Data.Delete(this.dgvData.CurrentCell.RowIndex);
      this.dgvData.Refresh();
    }
  }
}
