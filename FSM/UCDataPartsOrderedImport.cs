// Decompiled with JetBrains decompiler
// Type: FSM.UCDataPartsOrderedImport
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
  public class UCDataPartsOrderedImport : UCBase
  {
    private IContainer components;
    private DataView _Data;
    private string _ValidateType;
    private DataGridViewCellStyle m_SelectedStyle;
    private int m_SelectedRow;

    public UCDataPartsOrderedImport()
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
        DataGridViewCellMouseEventHandler mouseEventHandler1 = new DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
        DataGridViewCellEventHandler cellEventHandler1 = new DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
        DataGridViewCellEventHandler cellEventHandler2 = new DataGridViewCellEventHandler(this.dgvData_RowLeave);
        DataGridViewCellMouseEventHandler mouseEventHandler2 = new DataGridViewCellMouseEventHandler(this.dgvData_ColumnHeaderMouseClick);
        DataGridView dgvData1 = this._dgvData;
        if (dgvData1 != null)
        {
          dgvData1.CellMouseDoubleClick -= mouseEventHandler1;
          dgvData1.CellValueChanged -= cellEventHandler1;
          dgvData1.CellEndEdit -= cellEventHandler2;
          dgvData1.ColumnHeaderMouseClick -= mouseEventHandler2;
        }
        this._dgvData = value;
        DataGridView dgvData2 = this._dgvData;
        if (dgvData2 == null)
          return;
        dgvData2.CellMouseDoubleClick += mouseEventHandler1;
        dgvData2.CellValueChanged += cellEventHandler1;
        dgvData2.CellEndEdit += cellEventHandler2;
        dgvData2.ColumnHeaderMouseClick += mouseEventHandler2;
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
        this._Data.AllowDelete = false;
        this.dgvData.AutoGenerateColumns = false;
        this.dgvData.DataSource = (object) this.Data;
      }
    }

    public string ValidateType
    {
      get
      {
        string str;
        return str;
      }
      set
      {
        this._ValidateType = value;
      }
    }

    public void SetupDG()
    {
      DataGridViewCheckBoxColumn viewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn1.FillWeight = 5f;
      viewCheckBoxColumn1.HeaderText = "Exclude";
      viewCheckBoxColumn1.DataPropertyName = "Exclude";
      viewCheckBoxColumn1.ReadOnly = false;
      viewCheckBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "ID";
      viewTextBoxColumn1.DataPropertyName = "ID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Supplier Order Number";
      viewTextBoxColumn2.DataPropertyName = "SupplierOrderNumber";
      viewTextBoxColumn2.FillWeight = 15f;
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Order Date";
      viewTextBoxColumn3.DataPropertyName = "OrderDate";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Purchase Order Number";
      viewTextBoxColumn4.DataPropertyName = "PurchaseOrderNumber";
      viewTextBoxColumn4.ReadOnly = false;
      viewTextBoxColumn4.Visible = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Supplier PartCode";
      viewTextBoxColumn5.DataPropertyName = "SupplierPartCode";
      viewTextBoxColumn5.ReadOnly = false;
      viewTextBoxColumn5.Visible = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.HeaderText = "Description";
      viewTextBoxColumn6.DataPropertyName = "Description";
      viewTextBoxColumn6.ReadOnly = true;
      viewTextBoxColumn6.Visible = true;
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.HeaderText = "Quantity";
      viewTextBoxColumn7.DataPropertyName = "Quantity";
      viewTextBoxColumn7.ReadOnly = true;
      viewTextBoxColumn7.Visible = true;
      viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.HeaderText = "SupplierID";
      viewTextBoxColumn8.DataPropertyName = "SupplierID";
      viewTextBoxColumn8.FillWeight = 10f;
      viewTextBoxColumn8.ReadOnly = true;
      viewTextBoxColumn8.Visible = false;
      viewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
      DataGridViewTextBoxColumn viewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn9.HeaderText = "Supplier";
      viewTextBoxColumn9.DataPropertyName = "SupplierName";
      viewTextBoxColumn9.FillWeight = 10f;
      viewTextBoxColumn9.ReadOnly = true;
      viewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn9);
      DataGridViewCheckBoxColumn viewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn2.FillWeight = 5f;
      viewCheckBoxColumn2.HeaderText = "Delete";
      viewCheckBoxColumn2.DataPropertyName = "Delete";
      viewCheckBoxColumn2.ReadOnly = false;
      viewCheckBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn2);
      this.dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
    }

    private void UCData_Load(object sender, EventArgs e)
    {
      this.SetupDG();
      this.m_SelectedStyle.BackColor = Color.LightBlue;
    }

    private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      int clicks = e.Clicks;
    }

    private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      switch (e.ColumnIndex)
      {
        case 4:
          Cursor.Current = Cursors.WaitCursor;
          int integer1 = Conversions.ToInteger(this.dgvData[1, e.RowIndex].Value);
          string PurchaseOrderNumber = Conversions.ToString(this.dgvData[4, e.RowIndex].Value);
          App.DB.ImportValidation.PartsOrderedImport_UpdatePurchaseOrderNumber(integer1, PurchaseOrderNumber);
          Cursor.Current = Cursors.Default;
          break;
        case 5:
          Cursor.Current = Cursors.WaitCursor;
          int integer2 = Conversions.ToInteger(this.dgvData[1, e.RowIndex].Value);
          string SupplierPartCode = Conversions.ToString(this.dgvData[5, e.RowIndex].Value);
          App.DB.ImportValidation.PartsOrderedImport_UpdateSupplierPartCode(integer2, SupplierPartCode);
          Cursor.Current = Cursors.Default;
          break;
      }
    }

    private void dgvData_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
      int integer = Conversions.ToInteger(this.dgvData[1, e.RowIndex].Value);
      bool boolean1 = Conversions.ToBoolean(this.dgvData.Rows[e.RowIndex].Cells[0].Value);
      App.DB.ImportValidation.PartsOrderedImport_UpdateExclude(integer, boolean1);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(App.loggedInUser.Fullname, "Jane Lockett", false) != 0)
        return;
      bool boolean2 = Conversions.ToBoolean(this.dgvData.Rows[e.RowIndex].Cells[10].Value);
      App.DB.ImportValidation.PartsOrderedImport_UpdateDelete(integer, boolean2);
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
  }
}
