// Decompiled with JetBrains decompiler
// Type: FSM.UCDataPartsInvoiceImport
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.My;
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
  public class UCDataPartsInvoiceImport : UCBase
  {
    private IContainer components;
    private DataView _Data;
    private string _ValidateType;
    private DataGridViewCellStyle m_SelectedStyle;
    private int m_SelectedRow;

    public UCDataPartsInvoiceImport()
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
        EventHandler eventHandler = (EventHandler) ((a0, a1) => this.dgvData_Click(RuntimeHelpers.GetObjectValue(a0), (MouseEventArgs) a1));
        DataGridView dgvData1 = this._dgvData;
        if (dgvData1 != null)
        {
          dgvData1.CellMouseDoubleClick -= mouseEventHandler1;
          dgvData1.CellValueChanged -= cellEventHandler1;
          dgvData1.CellEndEdit -= cellEventHandler2;
          dgvData1.ColumnHeaderMouseClick -= mouseEventHandler2;
          dgvData1.Click -= eventHandler;
        }
        this._dgvData = value;
        DataGridView dgvData2 = this._dgvData;
        if (dgvData2 == null)
          return;
        dgvData2.CellMouseDoubleClick += mouseEventHandler1;
        dgvData2.CellValueChanged += cellEventHandler1;
        dgvData2.CellEndEdit += cellEventHandler2;
        dgvData2.ColumnHeaderMouseClick += mouseEventHandler2;
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
      this.Name = nameof (UCDataPartsInvoiceImport);
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
      viewCheckBoxColumn1.Visible = false;
      viewCheckBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn1);
      DataGridViewCheckBoxColumn viewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn2.FillWeight = 5f;
      viewCheckBoxColumn2.HeaderText = "Requires Auth";
      viewCheckBoxColumn2.DataPropertyName = "RequiresAuthorisation";
      viewCheckBoxColumn2.ReadOnly = false;
      viewCheckBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "ID";
      viewTextBoxColumn1.DataPropertyName = "ID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Invoice No";
      viewTextBoxColumn2.DataPropertyName = "InvoiceNo";
      viewTextBoxColumn2.FillWeight = 15f;
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Invoice Date";
      viewTextBoxColumn3.DataPropertyName = "InvoiceDate";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Purchase Order No";
      viewTextBoxColumn4.DataPropertyName = "PurchaseOrderNo";
      viewTextBoxColumn4.ReadOnly = false;
      viewTextBoxColumn4.Visible = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Inv Supp";
      viewTextBoxColumn5.DataPropertyName = "SupplierName";
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.Visible = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.HeaderText = "PO Supp";
      viewTextBoxColumn6.DataPropertyName = "POSupp";
      viewTextBoxColumn6.ReadOnly = true;
      viewTextBoxColumn6.Visible = true;
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.HeaderText = "PO Net Value";
      viewTextBoxColumn7.DataPropertyName = "PONetValue";
      viewTextBoxColumn7.ReadOnly = true;
      viewTextBoxColumn7.Visible = true;
      viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.HeaderText = "Net Difference (£)";
      viewTextBoxColumn8.DataPropertyName = "PONetDifference";
      viewTextBoxColumn8.ReadOnly = true;
      viewTextBoxColumn8.Visible = true;
      viewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
      DataGridViewTextBoxColumn viewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn9.HeaderText = "Invoice Net Amount";
      viewTextBoxColumn9.DataPropertyName = "TotalNetAmount";
      viewTextBoxColumn9.ReadOnly = true;
      viewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn9);
      DataGridViewTextBoxColumn viewTextBoxColumn10 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn10.HeaderText = "Invoice VAT Amount";
      viewTextBoxColumn10.DataPropertyName = "TotalVATAmount";
      viewTextBoxColumn10.ReadOnly = true;
      viewTextBoxColumn10.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn10);
      DataGridViewTextBoxColumn viewTextBoxColumn11 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn11.HeaderText = "Invoice Gross Amount";
      viewTextBoxColumn11.DataPropertyName = "TotalGrossAmount";
      viewTextBoxColumn11.ReadOnly = true;
      viewTextBoxColumn11.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn11);
      DataGridViewTextBoxColumn viewTextBoxColumn12 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn12.HeaderText = "View Parts";
      viewTextBoxColumn12.DataPropertyName = "ViewParts";
      viewTextBoxColumn12.ReadOnly = true;
      viewTextBoxColumn12.Visible = true;
      viewTextBoxColumn12.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn12);
      DataGridViewTextBoxColumn viewTextBoxColumn13 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn13.HeaderText = "View Order";
      viewTextBoxColumn13.DataPropertyName = "ViewOrder";
      viewTextBoxColumn13.ReadOnly = true;
      viewTextBoxColumn13.Visible = true;
      viewTextBoxColumn13.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn13);
      DataGridViewCheckBoxColumn viewCheckBoxColumn3 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn3.FillWeight = 5f;
      viewCheckBoxColumn3.HeaderText = "Update Supplier";
      viewCheckBoxColumn3.DataPropertyName = "EditOrder";
      viewCheckBoxColumn3.ReadOnly = false;
      viewCheckBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn3);
      DataGridViewCheckBoxColumn viewCheckBoxColumn4 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn4.FillWeight = 5f;
      viewCheckBoxColumn4.HeaderText = "Delete";
      viewCheckBoxColumn4.DataPropertyName = "Delete";
      viewCheckBoxColumn4.ReadOnly = false;
      viewCheckBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn14 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn14.HeaderText = "POOrderID";
      viewTextBoxColumn14.DataPropertyName = "OrderID";
      viewTextBoxColumn14.ReadOnly = true;
      viewTextBoxColumn14.Visible = false;
      viewTextBoxColumn14.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn14);
      DataGridViewTextBoxColumn viewTextBoxColumn15 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn15.HeaderText = "OrderForID";
      viewTextBoxColumn15.DataPropertyName = "OrderForID";
      viewTextBoxColumn15.ReadOnly = true;
      viewTextBoxColumn15.Visible = false;
      viewTextBoxColumn15.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn15);
      DataGridViewTextBoxColumn viewTextBoxColumn16 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn16.HeaderText = "Validate Result";
      viewTextBoxColumn16.DataPropertyName = "ValidateResult";
      viewTextBoxColumn16.ReadOnly = true;
      viewTextBoxColumn16.Visible = false;
      viewTextBoxColumn16.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn16);
      DataGridViewTextBoxColumn viewTextBoxColumn17 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn17.HeaderText = "Supplier ID";
      viewTextBoxColumn17.DataPropertyName = "SupplierID";
      viewTextBoxColumn17.ReadOnly = true;
      viewTextBoxColumn17.Visible = false;
      viewTextBoxColumn17.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn17);
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
      if (e.ColumnIndex != 5)
        return;
      Cursor.Current = Cursors.WaitCursor;
      int integer = Conversions.ToInteger(this.dgvData[2, e.RowIndex].Value);
      string PurchaseOrderNo = Conversions.ToString(this.dgvData[5, e.RowIndex].Value);
      App.DB.ImportValidation.POInvoiceImport_UpdatePurchaseOrderNoAndValidate(integer, PurchaseOrderNo);
      Cursor.Current = Cursors.Default;
    }

    private void dgvData_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
      int integer1 = Conversions.ToInteger(this.dgvData[2, e.RowIndex].Value);
      bool boolean1 = Conversions.ToBoolean(this.dgvData.Rows[e.RowIndex].Cells[1].Value);
      double num = 0.0;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dgvData.Rows[e.RowIndex].Cells[8].Value.ToString(), "", false) != 0)
        num = Conversions.ToDouble(this.dgvData.Rows[e.RowIndex].Cells[8].Value);
      if (boolean1 & num != 0.0)
        App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(integer1, boolean1);
      else if (!boolean1)
        App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(integer1, boolean1);
      if (Conversions.ToBoolean(this.dgvData.Rows[e.RowIndex].Cells[15].Value) & Conversions.ToInteger(this.dgvData.Rows[e.RowIndex].Cells[19].Value) == 14)
      {
        int integer2 = Conversions.ToInteger(this.dgvData[17, this.dgvData.CurrentCell.RowIndex].Value);
        int integer3 = Conversions.ToInteger(this.dgvData[20, this.dgvData.CurrentCell.RowIndex].Value);
        App.DB.ImportValidation.Order_UpdateSupplier(integer2, integer3);
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(App.loggedInUser.Fullname, "Jane Lockett", false) != 0)
        return;
      bool boolean2 = Conversions.ToBoolean(this.dgvData.Rows[e.RowIndex].Cells[16].Value);
      App.DB.ImportValidation.POInvoiceImport_UpdateDelete(integer1, boolean2);
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
      if (e.Button != MouseButtons.Left || this.dgvData.CurrentCell == null)
        return;
      switch (this.dgvData.CurrentCell.ColumnIndex)
      {
        case 0:
          int integer = Conversions.ToInteger(this.dgvData[2, this.dgvData.CurrentCell.RowIndex].Value);
          bool Exclude = !Conversions.ToBoolean(((DataGridViewCheckBoxCell) this.dgvData.CurrentCell).EditingCellFormattedValue);
          App.DB.ImportValidation.POInvoiceImport_UpdateExclude(integer, Exclude);
          break;
        case 13:
          FRMPOInvoiceIncludedItems invoiceIncludedItems = (FRMPOInvoiceIncludedItems) App.checkIfExists(typeof (FRMPOInvoiceIncludedItems).Name, true) ?? (FRMPOInvoiceIncludedItems) Activator.CreateInstance(typeof (FRMPOInvoiceIncludedItems));
          invoiceIncludedItems.Icon = new Icon(invoiceIncludedItems.GetType(), "Logo.ico");
          invoiceIncludedItems.ShowInTaskbar = false;
          invoiceIncludedItems.POToShow = Conversions.ToString(this.dgvData[5, this.dgvData.CurrentCell.RowIndex].Value);
          invoiceIncludedItems.InvoiceNo = Conversions.ToString(this.dgvData[3, this.dgvData.CurrentCell.RowIndex].Value);
          int num = (int) invoiceIncludedItems.ShowDialog();
          if (invoiceIncludedItems.DialogResult == DialogResult.OK)
            MyProject.Forms.FRMPartsInvoiceImport.ShowData(Conversions.ToInteger(this._ValidateType));
          invoiceIncludedItems.Close();
          break;
        case 14:
          if (this.dgvData[17, this.dgvData.CurrentCell.RowIndex].Value != DBNull.Value)
          {
            App.ShowForm(typeof (FRMOrder), true, new object[5]
            {
              this.dgvData[17, this.dgvData.CurrentCell.RowIndex].Value,
              this.dgvData[18, this.dgvData.CurrentCell.RowIndex].Value,
              (object) 0,
              (object) this,
              (object) true
            }, false);
            break;
          }
          break;
      }
    }
  }
}
