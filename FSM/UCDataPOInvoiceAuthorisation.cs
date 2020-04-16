// Decompiled with JetBrains decompiler
// Type: FSM.UCDataPOInvoiceAuthorisation
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
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
  public class UCDataPOInvoiceAuthorisation : UCBase
  {
    private IContainer components;
    private DataView _Data;
    private string _ValidateType;
    private string _Department;
    private DataGridViewCellStyle m_SelectedStyle;
    private int m_SelectedRow;

    public UCDataPOInvoiceAuthorisation()
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

    public string Department
    {
      get
      {
        string str;
        return str;
      }
      set
      {
        this._Department = value;
      }
    }

    public void SetupDG()
    {
      this.dgvData.AutoGenerateColumns = false;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "Invoice No";
      viewTextBoxColumn1.DataPropertyName = "InvoiceNo";
      viewTextBoxColumn1.Name = "InvoiceNo";
      viewTextBoxColumn1.FillWeight = 15f;
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn.FillWeight = 5f;
      viewCheckBoxColumn.HeaderText = "Exclude";
      viewCheckBoxColumn.DataPropertyName = "Exclude";
      viewCheckBoxColumn.Name = "Exclude";
      viewCheckBoxColumn.ReadOnly = false;
      viewCheckBoxColumn.Visible = false;
      viewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewCheckBoxColumn);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "ID";
      viewTextBoxColumn2.DataPropertyName = "ID";
      viewTextBoxColumn2.Name = "ID";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = false;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Invoice Date";
      viewTextBoxColumn3.DataPropertyName = "InvoiceDate";
      viewTextBoxColumn3.Name = "InvoiceDate";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Purchase Order No";
      viewTextBoxColumn4.DataPropertyName = "PurchaseOrderNo";
      viewTextBoxColumn4.Name = "PurchaseOrderNo";
      viewTextBoxColumn4.ReadOnly = false;
      viewTextBoxColumn4.Visible = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Supplier ID";
      viewTextBoxColumn5.DataPropertyName = "SupplierID";
      viewTextBoxColumn5.Name = "SupplierID";
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.Visible = false;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.HeaderText = "Supplier";
      viewTextBoxColumn6.DataPropertyName = "SupplierName";
      viewTextBoxColumn6.Name = "SupplierName";
      viewTextBoxColumn6.ReadOnly = true;
      viewTextBoxColumn6.Visible = true;
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.HeaderText = "No Of Parts";
      viewTextBoxColumn7.DataPropertyName = "NoOfParts";
      viewTextBoxColumn7.Name = "NoOfParts";
      viewTextBoxColumn7.ReadOnly = false;
      viewTextBoxColumn7.Visible = false;
      viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.HeaderText = "No of Parts (total qty)";
      viewTextBoxColumn8.DataPropertyName = "Quantities";
      viewTextBoxColumn8.Name = "Quantities";
      viewTextBoxColumn8.FillWeight = 10f;
      viewTextBoxColumn8.ReadOnly = false;
      viewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
      DataGridViewTextBoxColumn viewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn9.HeaderText = "Total Unit Price";
      viewTextBoxColumn9.DataPropertyName = "TotalUnitPrice";
      viewTextBoxColumn9.Name = "TotalUnitPrice";
      viewTextBoxColumn9.ReadOnly = true;
      viewTextBoxColumn9.Visible = false;
      viewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn9);
      DataGridViewTextBoxColumn viewTextBoxColumn10 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn10.HeaderText = "PO Net Value";
      viewTextBoxColumn10.DataPropertyName = "PONetValue";
      viewTextBoxColumn10.Name = "PONetValue";
      viewTextBoxColumn10.ReadOnly = true;
      viewTextBoxColumn10.Visible = true;
      viewTextBoxColumn10.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn10);
      DataGridViewTextBoxColumn viewTextBoxColumn11 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn11.HeaderText = "Net Difference (£)";
      viewTextBoxColumn11.DataPropertyName = "PONetDifference";
      viewTextBoxColumn11.Name = "PONetDifference";
      viewTextBoxColumn11.ReadOnly = true;
      viewTextBoxColumn11.Visible = true;
      viewTextBoxColumn11.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn11);
      DataGridViewTextBoxColumn viewTextBoxColumn12 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn12.HeaderText = "Invoice Net Amount";
      viewTextBoxColumn12.DataPropertyName = "TotalNetAmount";
      viewTextBoxColumn12.Name = "TotalNetAmount";
      viewTextBoxColumn12.ReadOnly = true;
      viewTextBoxColumn12.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn12);
      DataGridViewTextBoxColumn viewTextBoxColumn13 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn13.HeaderText = "Invoice VAT Amount";
      viewTextBoxColumn13.DataPropertyName = "TotalVATAmount";
      viewTextBoxColumn13.Name = "TotalVATAmount";
      viewTextBoxColumn13.ReadOnly = true;
      viewTextBoxColumn13.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn13);
      DataGridViewTextBoxColumn viewTextBoxColumn14 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn14.HeaderText = "Invoice Gross Amount";
      viewTextBoxColumn14.DataPropertyName = "TotalGrossAmount";
      viewTextBoxColumn14.Name = "TotalGrossAmount";
      viewTextBoxColumn14.ReadOnly = true;
      viewTextBoxColumn14.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn14);
      DataGridViewTextBoxColumn viewTextBoxColumn15 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn15.HeaderText = "Total Credit on Order";
      viewTextBoxColumn15.DataPropertyName = "CreditAmount";
      viewTextBoxColumn15.Name = "CreditAmount";
      viewTextBoxColumn15.ReadOnly = true;
      viewTextBoxColumn15.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn15);
      DataGridViewTextBoxColumn viewTextBoxColumn16 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn16.HeaderText = "Validate Result";
      viewTextBoxColumn16.DataPropertyName = "ValidateResult";
      viewTextBoxColumn16.Name = "ValidateResult";
      viewTextBoxColumn16.ReadOnly = true;
      viewTextBoxColumn16.Visible = false;
      viewTextBoxColumn16.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn16);
      DataGridViewTextBoxColumn viewTextBoxColumn17 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn17.HeaderText = "POOrderID";
      viewTextBoxColumn17.DataPropertyName = "OrderID";
      viewTextBoxColumn17.Name = "OrderID";
      viewTextBoxColumn17.ReadOnly = true;
      viewTextBoxColumn17.Visible = false;
      viewTextBoxColumn17.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn17);
      DataGridViewTextBoxColumn viewTextBoxColumn18 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn18.HeaderText = "View Parts";
      viewTextBoxColumn18.DataPropertyName = "ViewParts";
      viewTextBoxColumn18.Name = "ViewParts";
      viewTextBoxColumn18.ReadOnly = true;
      viewTextBoxColumn18.Visible = true;
      viewTextBoxColumn18.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn18);
      DataGridViewTextBoxColumn viewTextBoxColumn19 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn19.HeaderText = "OrderTypeID";
      viewTextBoxColumn19.DataPropertyName = "OrderTypeID";
      viewTextBoxColumn19.Name = "OrderTypeID";
      viewTextBoxColumn19.ReadOnly = true;
      viewTextBoxColumn19.Visible = false;
      viewTextBoxColumn19.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn19);
      DataGridViewTextBoxColumn viewTextBoxColumn20 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn20.HeaderText = "OrderForID";
      viewTextBoxColumn20.DataPropertyName = "OrderForID";
      viewTextBoxColumn20.Name = "OrderForID";
      viewTextBoxColumn20.ReadOnly = true;
      viewTextBoxColumn20.Visible = false;
      viewTextBoxColumn20.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn20);
      DataGridViewTextBoxColumn viewTextBoxColumn21 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn21.HeaderText = "View Order";
      viewTextBoxColumn21.DataPropertyName = "ViewOrder";
      viewTextBoxColumn21.Name = "ViewOrder";
      viewTextBoxColumn21.ReadOnly = true;
      viewTextBoxColumn21.Visible = true;
      viewTextBoxColumn21.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn21);
      DataGridViewTextBoxColumn viewTextBoxColumn22 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn22.HeaderText = "Authorise";
      viewTextBoxColumn22.DataPropertyName = "Authorise";
      viewTextBoxColumn22.Name = "Authorise";
      viewTextBoxColumn22.ReadOnly = true;
      viewTextBoxColumn22.Visible = true;
      viewTextBoxColumn22.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn22);
      DataGridViewTextBoxColumn viewTextBoxColumn23 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn23.HeaderText = "Department";
      viewTextBoxColumn23.DataPropertyName = "PODepartment";
      viewTextBoxColumn23.Name = "PODepartment";
      viewTextBoxColumn23.FillWeight = 15f;
      viewTextBoxColumn23.ReadOnly = true;
      viewTextBoxColumn23.Visible = true;
      viewTextBoxColumn23.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn23);
      this.dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
    }

    private void UCDataPOInvoiceAuthorisation_Load(object sender, EventArgs e)
    {
      this.SetupDG();
      this.m_SelectedStyle.BackColor = Color.LightBlue;
    }

    private void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      try
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
        if (column.ValueType == null)
          return;
        this.dgvData.Sort(column, direction);
        column.HeaderCell.SortGlyphDirection = direction != ListSortDirection.Ascending ? SortOrder.Descending : SortOrder.Ascending;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void dgvData_Click(object sender, MouseEventArgs e)
    {
      try
      {
        int index1 = 0;
        if (this.dgvData != null && this.dgvData.CurrentCell != null)
          index1 = this.dgvData.CurrentCell.ColumnIndex;
        if (index1 <= 0)
          return;
        string name = this.dgvData.Columns[index1].Name;
        if (e.Button == MouseButtons.Left)
        {
          string lower = name.ToLower();
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "viewparts", false) != 0)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "vieworder", false) != 0)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "authorise", false) == 0)
              {
                int integer = Conversions.ToInteger(this.dgvData[this.dgvData.Columns.IndexOf(this.dgvData.Columns["ID"]), this.dgvData.CurrentCell.RowIndex].Value);
                FRMPOInvoiceAuthReasons invoiceAuthReasons = (FRMPOInvoiceAuthReasons) App.checkIfExists(typeof (FRMPOInvoiceAuthReasons).Name, true) ?? (FRMPOInvoiceAuthReasons) Activator.CreateInstance(typeof (FRMPOInvoiceAuthReasons));
                invoiceAuthReasons.ShowInTaskbar = false;
                invoiceAuthReasons.AuthReason = (string) null;
                invoiceAuthReasons.AuthReasonDetail = (string) null;
                int num = (int) invoiceAuthReasons.ShowDialog();
                if (invoiceAuthReasons.DialogResult == DialogResult.OK)
                {
                  string AuthReason = string.Empty;
                  if (invoiceAuthReasons._AuthReason != null)
                    AuthReason = invoiceAuthReasons._AuthReason;
                  string AuthReasonDetail = string.Empty;
                  if (invoiceAuthReasons._AuthReasonDetail != null)
                    AuthReasonDetail = invoiceAuthReasons._AuthReasonDetail;
                  int index2 = this.dgvData.SortedColumn == null ? 0 : this.dgvData.SortedColumn.Index;
                  SortOrder sortOrder = this.dgvData.SortOrder;
                  App.DB.POInvoice.POInvoiceImport_UpdateAuthorised(integer, true, App.loggedInUser.UserID, DateAndTime.Now, AuthReason, AuthReasonDetail);
                  this.Data = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this._Department, "", false) != 0 ? App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(this._ValidateType), this._Department) : App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(this._ValidateType), "%");
                  try
                  {
                    switch (sortOrder)
                    {
                      case SortOrder.Ascending:
                        this.dgvData.Sort(this.dgvData.Columns[index2], ListSortDirection.Ascending);
                        break;
                      case SortOrder.Descending:
                        this.dgvData.Sort(this.dgvData.Columns[index2], ListSortDirection.Descending);
                        break;
                    }
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                  }
                }
                invoiceAuthReasons.Close();
              }
            }
            else
            {
              int index2 = this.dgvData.Columns.IndexOf(this.dgvData.Columns["OrderID"]);
              int index3 = this.dgvData.Columns.IndexOf(this.dgvData.Columns["OrderForID"]);
              if (this.dgvData[index2, this.dgvData.CurrentCell.RowIndex].Value != DBNull.Value)
                App.ShowForm(typeof (FRMOrder), true, new object[5]
                {
                  this.dgvData[index2, this.dgvData.CurrentCell.RowIndex].Value,
                  this.dgvData[index3, this.dgvData.CurrentCell.RowIndex].Value,
                  (object) 0,
                  (object) this,
                  (object) true
                }, false);
            }
          }
          else
          {
            FRMPOInvoiceIncludedItems invoiceIncludedItems = (FRMPOInvoiceIncludedItems) App.checkIfExists(typeof (FRMPOInvoiceIncludedItems).Name, true) ?? (FRMPOInvoiceIncludedItems) Activator.CreateInstance(typeof (FRMPOInvoiceIncludedItems));
            invoiceIncludedItems.ShowInTaskbar = false;
            int index2 = this.dgvData.Columns.IndexOf(this.dgvData.Columns["PurchaseOrderNo"]);
            invoiceIncludedItems.POToShow = Conversions.ToString(this.dgvData[index2, this.dgvData.CurrentCell.RowIndex].Value);
            int index3 = this.dgvData.Columns.IndexOf(this.dgvData.Columns["InvoiceNo"]);
            invoiceIncludedItems.InvoiceNo = Conversions.ToString(this.dgvData[index3, this.dgvData.CurrentCell.RowIndex].Value);
            int num = (int) invoiceIncludedItems.ShowDialog();
            this.Data = invoiceIncludedItems.DialogResult != DialogResult.OK ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this._Department, "", false) != 0 ? App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(this._ValidateType), this._Department) : App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(this._ValidateType), "%")) : (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this._Department, "", false) != 0 ? App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(this._ValidateType), this._Department) : App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(this._ValidateType), "%"));
            invoiceIncludedItems.Close();
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }
  }
}
