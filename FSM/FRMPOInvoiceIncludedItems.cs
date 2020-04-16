// Decompiled with JetBrains decompiler
// Type: FSM.FRMPOInvoiceIncludedItems
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
  [DesignerGenerated]
  public class FRMPOInvoiceIncludedItems : FRMBaseForm, IForm
  {
    private IContainer components;
    private string _POToShow;
    private string _InvoiceNo;
    private DataView _dvRecords;
    private DataView _dvPORecords;

    public FRMPOInvoiceIncludedItems()
    {
      this.Load += new EventHandler(this.FRMPOInvoiceIncludedItems_Load);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.dgvData = new DataGridView();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.GroupBox2 = new GroupBox();
      this.dgvPOData = new DataGridView();
      this.GroupBox1.SuspendLayout();
      ((ISupportInitialize) this.dgvData).BeginInit();
      this.GroupBox2.SuspendLayout();
      ((ISupportInitialize) this.dgvPOData).BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.dgvData);
      this.GroupBox1.Location = new System.Drawing.Point(12, 313);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(1073, 287);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "INVOICE Included Items";
      this.dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvData.Location = new System.Drawing.Point(6, 20);
      this.dgvData.Name = "dgvData";
      this.dgvData.Size = new Size(1061, 261);
      this.dgvData.TabIndex = 0;
      this.btnOK.Location = new System.Drawing.Point(1010, 606);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnCancel.Location = new System.Drawing.Point(929, 606);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Visible = false;
      this.GroupBox2.AutoSize = true;
      this.GroupBox2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.GroupBox2.Controls.Add((Control) this.dgvPOData);
      this.GroupBox2.Location = new System.Drawing.Point(13, 39);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(1072, 267);
      this.GroupBox2.TabIndex = 5;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "PURCHASE ORDER Included Items";
      this.dgvPOData.AllowUserToAddRows = false;
      this.dgvPOData.AllowUserToDeleteRows = false;
      this.dgvPOData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPOData.Location = new System.Drawing.Point(7, 21);
      this.dgvPOData.Name = "dgvPOData";
      this.dgvPOData.ReadOnly = true;
      this.dgvPOData.Size = new Size(1059, 226);
      this.dgvPOData.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1097, 641);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.GroupBox1);
      this.MinimumSize = new Size(820, 420);
      this.Name = nameof (FRMPOInvoiceIncludedItems);
      this.SizeGripStyle = SizeGripStyle.Show;
      this.Text = "PO Invoice Included Items";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox2, 0);
      this.GroupBox1.ResumeLayout(false);
      ((ISupportInitialize) this.dgvData).EndInit();
      this.GroupBox2.ResumeLayout(false);
      ((ISupportInitialize) this.dgvPOData).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        Button btnOk1 = this._btnOK;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOK = value;
        Button btnOk2 = this._btnOK;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
      }
    }

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        Button btnCancel1 = this._btnCancel;
        if (btnCancel1 != null)
          btnCancel1.Click -= eventHandler;
        this._btnCancel = value;
        Button btnCancel2 = this._btnCancel;
        if (btnCancel2 == null)
          return;
        btnCancel2.Click += eventHandler;
      }
    }

    internal virtual DataGridView dgvData
    {
      get
      {
        return this._dgvData;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DataGridViewCellEventHandler cellEventHandler = new DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
        EventHandler eventHandler = new EventHandler(this.dgvData_Click);
        DataGridView dgvData1 = this._dgvData;
        if (dgvData1 != null)
        {
          dgvData1.CellValueChanged -= cellEventHandler;
          dgvData1.Click -= eventHandler;
        }
        this._dgvData = value;
        DataGridView dgvData2 = this._dgvData;
        if (dgvData2 == null)
          return;
        dgvData2.CellValueChanged += cellEventHandler;
        dgvData2.Click += eventHandler;
      }
    }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgvPOData { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public void LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
    }

    public void ResetMe(int newID)
    {
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    public string POToShow
    {
      get
      {
        string str;
        return str;
      }
      set
      {
        this._POToShow = value;
      }
    }

    public string InvoiceNo
    {
      get
      {
        string str;
        return str;
      }
      set
      {
        this._InvoiceNo = value;
      }
    }

    private DataView Records
    {
      get
      {
        return this._dvRecords;
      }
      set
      {
        this._dvRecords = value;
        this._dvRecords.Table.TableName = "POInvoiceImport_Parts";
        this._dvRecords.AllowNew = false;
        this._dvRecords.AllowEdit = true;
        this._dvRecords.AllowDelete = false;
        this.dgvData.DataSource = (object) this.Records;
      }
    }

    private DataView PORecords
    {
      get
      {
        return this._dvPORecords;
      }
      set
      {
        this._dvPORecords = value;
        this._dvPORecords.Table.TableName = "PO_Parts";
        this._dvPORecords.AllowNew = false;
        this._dvPORecords.AllowEdit = true;
        this._dvPORecords.AllowDelete = false;
        this.dgvPOData.DataSource = (object) this.PORecords;
      }
    }

    public void SetupDG()
    {
      this.dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvData.AutoGenerateColumns = false;
      this.dgvData.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "Supplier PC";
      viewTextBoxColumn1.FillWeight = 25f;
      viewTextBoxColumn1.DataPropertyName = "SupplierPartCode";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 60f;
      viewTextBoxColumn2.HeaderText = "Description";
      viewTextBoxColumn2.DataPropertyName = "Description";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Qty";
      viewTextBoxColumn3.DataPropertyName = "Quantity";
      viewTextBoxColumn3.FillWeight = 15f;
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Unit Price";
      viewTextBoxColumn4.DataPropertyName = "UnitPrice";
      viewTextBoxColumn4.FillWeight = 15f;
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Net Amount";
      viewTextBoxColumn5.DataPropertyName = "NetAmount";
      viewTextBoxColumn5.FillWeight = 15f;
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.HeaderText = "VAT Amount";
      viewTextBoxColumn6.DataPropertyName = "VATAmount";
      viewTextBoxColumn6.FillWeight = 15f;
      viewTextBoxColumn6.ReadOnly = true;
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.HeaderText = "Gross Amount";
      viewTextBoxColumn7.DataPropertyName = "GrossAmount";
      viewTextBoxColumn7.FillWeight = 15f;
      viewTextBoxColumn7.ReadOnly = true;
      viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.HeaderText = "Failed";
      viewTextBoxColumn8.DataPropertyName = "FailedPart";
      viewTextBoxColumn8.FillWeight = 15f;
      viewTextBoxColumn8.ReadOnly = true;
      viewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvData.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
    }

    public void SetupDGPOParts()
    {
      this.dgvPOData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvPOData.AutoGenerateColumns = false;
      this.dgvPOData.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "Supplier PC";
      viewTextBoxColumn1.FillWeight = 25f;
      viewTextBoxColumn1.DataPropertyName = "SupplierPartCode";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPOData.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 60f;
      viewTextBoxColumn2.HeaderText = "Description";
      viewTextBoxColumn2.DataPropertyName = "Name";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPOData.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Qty";
      viewTextBoxColumn3.DataPropertyName = "QuantityOnOrder";
      viewTextBoxColumn3.FillWeight = 15f;
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPOData.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Unit Price";
      viewTextBoxColumn4.DataPropertyName = "BuyPrice";
      viewTextBoxColumn4.FillWeight = 15f;
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPOData.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
    }

    private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      int columnIndex = e.ColumnIndex;
    }

    private void dgvData_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      Cursor.Current = Cursors.Default;
    }

    private void FRMPOInvoiceIncludedItems_Load(object sender, EventArgs e)
    {
      this.dgvData.AutoGenerateColumns = false;
      this.Records = App.DB.ImportValidation.POInvoiceImport_ShowPOParts(this._POToShow, this._InvoiceNo);
      this.SetupDG();
      this.dgvPOData.AutoGenerateColumns = false;
      string orderIdByRef = App.DB.Order.Order_Get_OrderID_ByRef(this._POToShow);
      this.PORecords = App.DB.Order.Order_ItemsGetAll(Conversions.ToInteger(orderIdByRef));
      this.SetupDGPOParts();
    }
  }
}
