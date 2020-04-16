// Decompiled with JetBrains decompiler
// Type: FSM.FRMStockMove
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.PartTransactions;
using FSM.Entity.ProductTransactions;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMStockMove : FRMBaseForm, IForm
  {
    private IContainer components;
    private int CurrentQty;
    private DataView _StockDataView;

    public FRMStockMove()
    {
      this.Load += new EventHandler(this.FRMStockMove_Load);
      this.CurrentQty = 1;
      this._StockDataView = (DataView) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual RadioButton radWarehouseCurrent
    {
      get
      {
        return this._radWarehouseCurrent;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radWarehouseCurrent_CheckedChanged);
        RadioButton warehouseCurrent1 = this._radWarehouseCurrent;
        if (warehouseCurrent1 != null)
          warehouseCurrent1.CheckedChanged -= eventHandler;
        this._radWarehouseCurrent = value;
        RadioButton warehouseCurrent2 = this._radWarehouseCurrent;
        if (warehouseCurrent2 == null)
          return;
        warehouseCurrent2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton radVanCurrent
    {
      get
      {
        return this._radVanCurrent;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radVanCurrent_CheckedChanged);
        RadioButton radVanCurrent1 = this._radVanCurrent;
        if (radVanCurrent1 != null)
          radVanCurrent1.CheckedChanged -= eventHandler;
        this._radVanCurrent = value;
        RadioButton radVanCurrent2 = this._radVanCurrent;
        if (radVanCurrent2 == null)
          return;
        radVanCurrent2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLocationCurrent
    {
      get
      {
        return this._cboLocationCurrent;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboLocationCurrent_SelectedIndexChanged);
        ComboBox cboLocationCurrent1 = this._cboLocationCurrent;
        if (cboLocationCurrent1 != null)
          cboLocationCurrent1.SelectedIndexChanged -= eventHandler;
        this._cboLocationCurrent = value;
        ComboBox cboLocationCurrent2 = this._cboLocationCurrent;
        if (cboLocationCurrent2 == null)
          return;
        cboLocationCurrent2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual GroupBox grpCurrent { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpNew { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton radWarehouseNew
    {
      get
      {
        return this._radWarehouseNew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radWarehouseNew_CheckedChanged);
        RadioButton radWarehouseNew1 = this._radWarehouseNew;
        if (radWarehouseNew1 != null)
          radWarehouseNew1.CheckedChanged -= eventHandler;
        this._radWarehouseNew = value;
        RadioButton radWarehouseNew2 = this._radWarehouseNew;
        if (radWarehouseNew2 == null)
          return;
        radWarehouseNew2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton radVanNew
    {
      get
      {
        return this._radVanNew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radVanNew_CheckedChanged);
        RadioButton radVanNew1 = this._radVanNew;
        if (radVanNew1 != null)
          radVanNew1.CheckedChanged -= eventHandler;
        this._radVanNew = value;
        RadioButton radVanNew2 = this._radVanNew;
        if (radVanNew2 == null)
          return;
        radVanNew2.CheckedChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboLocationNew { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpItems { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQuantity
    {
      get
      {
        return this._txtQuantity;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtQuantity_GotFocus);
        CancelEventHandler cancelEventHandler = new CancelEventHandler(this.txtQuantity_Validating);
        TextBox txtQuantity1 = this._txtQuantity;
        if (txtQuantity1 != null)
        {
          txtQuantity1.GotFocus -= eventHandler;
          txtQuantity1.Validating -= cancelEventHandler;
        }
        this._txtQuantity = value;
        TextBox txtQuantity2 = this._txtQuantity;
        if (txtQuantity2 == null)
          return;
        txtQuantity2.GotFocus += eventHandler;
        txtQuantity2.Validating += cancelEventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgItems
    {
      get
      {
        return this._dgItems;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgItems_DoubleClick);
        EventHandler eventHandler2 = new EventHandler(this.dgItems_Click);
        DataGrid dgItems1 = this._dgItems;
        if (dgItems1 != null)
        {
          dgItems1.DoubleClick -= eventHandler1;
          dgItems1.Click -= eventHandler2;
        }
        this._dgItems = value;
        DataGrid dgItems2 = this._dgItems;
        if (dgItems2 == null)
          return;
        dgItems2.DoubleClick += eventHandler1;
        dgItems2.Click += eventHandler2;
      }
    }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    internal virtual Button btnMove
    {
      get
      {
        return this._btnMove;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMove_Click);
        Button btnMove1 = this._btnMove;
        if (btnMove1 != null)
          btnMove1.Click -= eventHandler;
        this._btnMove = value;
        Button btnMove2 = this._btnMove;
        if (btnMove2 == null)
          return;
        btnMove2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtFilter
    {
      get
      {
        return this._txtFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtFilter_TextChanged);
        TextBox txtFilter1 = this._txtFilter;
        if (txtFilter1 != null)
          txtFilter1.TextChanged -= eventHandler;
        this._txtFilter = value;
        TextBox txtFilter2 = this._txtFilter;
        if (txtFilter2 == null)
          return;
        txtFilter2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSelectAll
    {
      get
      {
        return this._btnSelectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSelectAll_Click);
        Button btnSelectAll1 = this._btnSelectAll;
        if (btnSelectAll1 != null)
          btnSelectAll1.Click -= eventHandler;
        this._btnSelectAll = value;
        Button btnSelectAll2 = this._btnSelectAll;
        if (btnSelectAll2 == null)
          return;
        btnSelectAll2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeselectAll
    {
      get
      {
        return this._btnDeselectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeselectAll_Click);
        Button btnDeselectAll1 = this._btnDeselectAll;
        if (btnDeselectAll1 != null)
          btnDeselectAll1.Click -= eventHandler;
        this._btnDeselectAll = value;
        Button btnDeselectAll2 = this._btnDeselectAll;
        if (btnDeselectAll2 == null)
          return;
        btnDeselectAll2.Click += eventHandler;
      }
    }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.radWarehouseCurrent = new RadioButton();
      this.radVanCurrent = new RadioButton();
      this.Label5 = new Label();
      this.cboLocationCurrent = new ComboBox();
      this.grpCurrent = new GroupBox();
      this.grpNew = new GroupBox();
      this.radWarehouseNew = new RadioButton();
      this.Label1 = new Label();
      this.radVanNew = new RadioButton();
      this.cboLocationNew = new ComboBox();
      this.grpItems = new GroupBox();
      this.Label4 = new Label();
      this.btnSelectAll = new Button();
      this.btnDeselectAll = new Button();
      this.txtFilter = new TextBox();
      this.Label3 = new Label();
      this.txtQuantity = new TextBox();
      this.Label2 = new Label();
      this.dgItems = new DataGrid();
      this.btnClose = new Button();
      this.btnMove = new Button();
      this.grpCurrent.SuspendLayout();
      this.grpNew.SuspendLayout();
      this.grpItems.SuspendLayout();
      this.dgItems.BeginInit();
      this.SuspendLayout();
      this.radWarehouseCurrent.Checked = true;
      this.radWarehouseCurrent.Location = new System.Drawing.Point(8, 20);
      this.radWarehouseCurrent.Name = "radWarehouseCurrent";
      this.radWarehouseCurrent.Size = new Size(96, 26);
      this.radWarehouseCurrent.TabIndex = 1;
      this.radWarehouseCurrent.TabStop = true;
      this.radWarehouseCurrent.Text = "Warehouse";
      this.radVanCurrent.Location = new System.Drawing.Point(110, 20);
      this.radVanCurrent.Name = "radVanCurrent";
      this.radVanCurrent.Size = new Size(99, 26);
      this.radVanCurrent.TabIndex = 2;
      this.radVanCurrent.Text = "Stock Profile";
      this.Label5.Location = new System.Drawing.Point(214, 25);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(24, 23);
      this.Label5.TabIndex = 7;
      this.Label5.Text = ">";
      this.cboLocationCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboLocationCurrent.Location = new System.Drawing.Point(247, 25);
      this.cboLocationCurrent.Name = "cboLocationCurrent";
      this.cboLocationCurrent.Size = new Size(337, 21);
      this.cboLocationCurrent.TabIndex = 3;
      this.grpCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCurrent.Controls.Add((Control) this.radWarehouseCurrent);
      this.grpCurrent.Controls.Add((Control) this.Label5);
      this.grpCurrent.Controls.Add((Control) this.radVanCurrent);
      this.grpCurrent.Controls.Add((Control) this.cboLocationCurrent);
      this.grpCurrent.Location = new System.Drawing.Point(4, 38);
      this.grpCurrent.Name = "grpCurrent";
      this.grpCurrent.Size = new Size(592, 58);
      this.grpCurrent.TabIndex = 1;
      this.grpCurrent.TabStop = false;
      this.grpCurrent.Text = "Select current stock location";
      this.grpNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpNew.Controls.Add((Control) this.radWarehouseNew);
      this.grpNew.Controls.Add((Control) this.Label1);
      this.grpNew.Controls.Add((Control) this.radVanNew);
      this.grpNew.Controls.Add((Control) this.cboLocationNew);
      this.grpNew.Location = new System.Drawing.Point(4, 337);
      this.grpNew.Name = "grpNew";
      this.grpNew.Size = new Size(592, 58);
      this.grpNew.TabIndex = 3;
      this.grpNew.TabStop = false;
      this.grpNew.Text = "Select new stock location";
      this.radWarehouseNew.Checked = true;
      this.radWarehouseNew.Location = new System.Drawing.Point(8, 20);
      this.radWarehouseNew.Name = "radWarehouseNew";
      this.radWarehouseNew.Size = new Size(96, 26);
      this.radWarehouseNew.TabIndex = 1;
      this.radWarehouseNew.TabStop = true;
      this.radWarehouseNew.Text = "Warehouse";
      this.Label1.Location = new System.Drawing.Point(214, 23);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(24, 23);
      this.Label1.TabIndex = 7;
      this.Label1.Text = ">";
      this.radVanNew.Location = new System.Drawing.Point(110, 20);
      this.radVanNew.Name = "radVanNew";
      this.radVanNew.Size = new Size(98, 26);
      this.radVanNew.TabIndex = 2;
      this.radVanNew.Text = "Stock Profile";
      this.cboLocationNew.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboLocationNew.Location = new System.Drawing.Point(247, 25);
      this.cboLocationNew.Name = "cboLocationNew";
      this.cboLocationNew.Size = new Size(337, 21);
      this.cboLocationNew.TabIndex = 3;
      this.grpItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpItems.Controls.Add((Control) this.Label4);
      this.grpItems.Controls.Add((Control) this.btnSelectAll);
      this.grpItems.Controls.Add((Control) this.btnDeselectAll);
      this.grpItems.Controls.Add((Control) this.txtFilter);
      this.grpItems.Controls.Add((Control) this.Label3);
      this.grpItems.Controls.Add((Control) this.txtQuantity);
      this.grpItems.Controls.Add((Control) this.Label2);
      this.grpItems.Controls.Add((Control) this.dgItems);
      this.grpItems.Location = new System.Drawing.Point(4, 102);
      this.grpItems.Name = "grpItems";
      this.grpItems.Size = new Size(592, 229);
      this.grpItems.TabIndex = 2;
      this.grpItems.TabStop = false;
      this.grpItems.Text = "Select item to move";
      this.Label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label4.Location = new System.Drawing.Point(295, 201);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size((int) byte.MaxValue, 14);
      this.Label4.TabIndex = 23;
      this.Label4.Text = "The current quantity will be moved across";
      this.Label4.Visible = false;
      this.btnSelectAll.AccessibleDescription = "Export Job List To Excel";
      this.btnSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSelectAll.Location = new System.Drawing.Point(400, 18);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(88, 23);
      this.btnSelectAll.TabIndex = 21;
      this.btnSelectAll.Text = "Select All";
      this.btnDeselectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDeselectAll.Location = new System.Drawing.Point(496, 18);
      this.btnDeselectAll.Name = "btnDeselectAll";
      this.btnDeselectAll.Size = new Size(88, 23);
      this.btnDeselectAll.TabIndex = 22;
      this.btnDeselectAll.Text = "Deselect All";
      this.txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFilter.Location = new System.Drawing.Point(48, 20);
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new Size(335, 21);
      this.txtFilter.TabIndex = 1;
      this.Label3.Location = new System.Drawing.Point(4, 23);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(51, 18);
      this.Label3.TabIndex = 3;
      this.Label3.Text = "Filter";
      this.txtQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtQuantity.Location = new System.Drawing.Point(189, 198);
      this.txtQuantity.Name = "txtQuantity";
      this.txtQuantity.Size = new Size(100, 21);
      this.txtQuantity.TabIndex = 3;
      this.txtQuantity.Text = "1";
      this.Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label2.Location = new System.Drawing.Point(6, 201);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(177, 16);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Enter quantity being moved";
      this.dgItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgItems.DataMember = "";
      this.dgItems.HeaderForeColor = SystemColors.ControlText;
      this.dgItems.Location = new System.Drawing.Point(6, 47);
      this.dgItems.Name = "dgItems";
      this.dgItems.Size = new Size(580, 145);
      this.dgItems.TabIndex = 2;
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(4, 401);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(59, 23);
      this.btnClose.TabIndex = 5;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnMove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnMove.Location = new System.Drawing.Point(537, 401);
      this.btnMove.Name = "btnMove";
      this.btnMove.Size = new Size(59, 23);
      this.btnMove.TabIndex = 4;
      this.btnMove.Text = "Move";
      this.btnMove.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(601, 435);
      this.Controls.Add((Control) this.btnMove);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.grpItems);
      this.Controls.Add((Control) this.grpNew);
      this.Controls.Add((Control) this.grpCurrent);
      this.MinimumSize = new Size(609, 469);
      this.Name = nameof (FRMStockMove);
      this.Text = "Internal Parts Transfer";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpCurrent, 0);
      this.Controls.SetChildIndex((Control) this.grpNew, 0);
      this.Controls.SetChildIndex((Control) this.grpItems, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.btnMove, 0);
      this.grpCurrent.ResumeLayout(false);
      this.grpNew.ResumeLayout(false);
      this.grpItems.ResumeLayout(false);
      this.grpItems.PerformLayout();
      this.dgItems.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboLocationCurrent = this.cboLocationCurrent;
      Combo.SetUpCombo(ref cboLocationCurrent, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Enums.ComboValues.None);
      this.cboLocationCurrent = cboLocationCurrent;
      if (this.cboLocationCurrent.Items.Count > 0)
        this.cboLocationCurrent.SelectedIndex = 0;
      this.ShowStock(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLocationCurrent)), 0);
      ComboBox cboLocationNew = this.cboLocationNew;
      Combo.SetUpCombo(ref cboLocationNew, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Enums.ComboValues.None);
      this.cboLocationNew = cboLocationNew;
      if (this.cboLocationNew.Items.Count > 0)
        this.cboLocationNew.SelectedIndex = 0;
      this.SetupDatagrid();
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    void IForm.ResetMe(int newID)
    {
    }

    public DataView StockDataView
    {
      get
      {
        return this._StockDataView;
      }
      set
      {
        this._StockDataView = value;
        this._StockDataView.Table.TableName = Enums.TableNames.tblStock.ToString();
        this._StockDataView.AllowNew = false;
        this._StockDataView.AllowEdit = false;
        this._StockDataView.AllowDelete = false;
        this.dgItems.DataSource = (object) this.StockDataView;
      }
    }

    private DataRow SelectedStockDataRow
    {
      get
      {
        return this.dgItems.CurrentRowIndex != -1 ? this.StockDataView[this.dgItems.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupDatagrid()
    {
      Helper.SetUpDataGrid(this.dgItems, false);
      DataGridTableStyle tableStyle = this.dgItems.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.ReadOnly = false;
      tableStyle.AllowSorting = false;
      this.dgItems.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Select";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 75;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Description";
      dataGridLabelColumn2.MappingName = "Description";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 180;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Number";
      dataGridLabelColumn3.MappingName = "Number";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 140;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Reference";
      dataGridLabelColumn4.MappingName = "Reference";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 200;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Amount";
      dataGridLabelColumn5.MappingName = "Amount";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 120;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblStock.ToString();
      this.dgItems.TableStyles.Add(tableStyle);
    }

    private void FRMStockMove_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgItems_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedStockDataRow == null || !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedStockDataRow["Type"], (object) "PART", false))
        return;
      App.ShowForm(typeof (FRMPart), true, new object[2]
      {
        this.SelectedStockDataRow["ID"],
        (object) true
      }, false);
      this.ShowStock(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLocationCurrent)), 0);
    }

    private void radWarehouseCurrent_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radWarehouseCurrent.Checked)
        return;
      ComboBox cboLocationCurrent = this.cboLocationCurrent;
      Combo.SetUpCombo(ref cboLocationCurrent, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Enums.ComboValues.None);
      this.cboLocationCurrent = cboLocationCurrent;
      if (this.cboLocationCurrent.Items.Count > 0)
      {
        this.cboLocationCurrent.SelectedIndex = 0;
        this.ShowStock(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLocationCurrent)), 0);
      }
    }

    private void radVanCurrent_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radVanCurrent.Checked)
        return;
      ComboBox cboLocationCurrent = this.cboLocationCurrent;
      Combo.SetUpCombo(ref cboLocationCurrent, App.DB.Van.Van_GetAll(false).Table, "VanID", "Registration", Enums.ComboValues.None);
      this.cboLocationCurrent = cboLocationCurrent;
      if (this.cboLocationCurrent.Items.Count > 0)
      {
        this.cboLocationCurrent.SelectedIndex = 0;
        this.ShowStock(0, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLocationCurrent)));
      }
    }

    private void radWarehouseNew_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radWarehouseNew.Checked)
        return;
      ComboBox cboLocationNew = this.cboLocationNew;
      Combo.SetUpCombo(ref cboLocationNew, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Enums.ComboValues.None);
      this.cboLocationNew = cboLocationNew;
      if (this.cboLocationNew.Items.Count > 0)
        this.cboLocationNew.SelectedIndex = 0;
    }

    private void radVanNew_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radVanNew.Checked)
        return;
      ComboBox cboLocationNew = this.cboLocationNew;
      Combo.SetUpCombo(ref cboLocationNew, App.DB.Van.Van_GetAll(false).Table, "VanID", "Registration", Enums.ComboValues.None);
      this.cboLocationNew = cboLocationNew;
      if (this.cboLocationNew.Items.Count > 0)
        this.cboLocationNew.SelectedIndex = 0;
    }

    private void cboLocationCurrent_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.radWarehouseCurrent.Checked)
        this.ShowStock(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLocationCurrent)), 0);
      else
        this.ShowStock(0, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLocationCurrent)));
    }

    private void txtQuantity_GotFocus(object sender, EventArgs e)
    {
      this.CurrentQty = Conversions.ToInteger(this.txtQuantity.Text.Trim());
      this.txtQuantity.Text = "";
    }

    private void txtQuantity_Validating(object sender, CancelEventArgs e)
    {
      try
      {
        if (Helper.IsValidInteger((object) this.txtQuantity.Text.Trim()))
          this.CurrentQty = Conversions.ToInteger(this.txtQuantity.Text.Trim());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.txtQuantity.Text = Conversions.ToString(this.CurrentQty);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnMove_Click(object sender, EventArgs e)
    {
      if (this.SelectedStockDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select an item to move", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.radWarehouseCurrent.Checked & this.radWarehouseNew.Checked && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboLocationCurrent), Combo.get_GetSelectedItemValue(this.cboLocationNew), false) == 0)
      {
        int num2 = (int) App.ShowMessage("You are attempting to move stock to the same place", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.radVanCurrent.Checked & this.radVanNew.Checked && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboLocationCurrent), Combo.get_GetSelectedItemValue(this.cboLocationNew), false) == 0)
      {
        int num3 = (int) App.ShowMessage("You are attempting to move stock to the same place", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        bool flag = false;
        int num4 = 0;
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.StockDataView.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((DataRow) enumerator1.Current)["Select"], (object) true, false))
            {
              checked { ++num4; }
              if (num4 > 1)
              {
                flag = true;
                break;
              }
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) !flag, Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater((object) this.CurrentQty, this.SelectedStockDataRow["Amount"], false))) && App.ShowMessage("You are attempting to move more than there is available\r\nThis will result in negative stock\r\nAre you sure you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        int locationID = 0;
        IEnumerator enumerator2;
        try
        {
          enumerator2 = App.DB.Location.Locations_GetAll().Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            if (this.radWarehouseNew.Checked)
            {
              if ((double) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["WarehouseID"])) == Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboLocationNew)))
              {
                locationID = Conversions.ToInteger(current["LocationID"]);
                break;
              }
            }
            else if ((double) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["VanID"])) == Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboLocationNew)))
            {
              locationID = Conversions.ToInteger(current["LocationID"]);
              break;
            }
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        if (locationID == 0)
        {
          int num5 = (int) App.ShowMessage("Location being moved to could not be determined", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          if (flag)
          {
            if (App.ShowMessage("You are about to mulitple parts/products from '" + Combo.get_GetSelectedItemDescription(this.cboLocationCurrent) + "' to '" + Combo.get_GetSelectedItemDescription(this.cboLocationNew) + "'. Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
              return;
            IEnumerator enumerator3;
            try
            {
              enumerator3 = this.StockDataView.Table.Rows.GetEnumerator();
              while (enumerator3.MoveNext())
              {
                DataRow current = (DataRow) enumerator3.Current;
                if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["Select"], (object) true, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(current["Amount"], (object) 0, false))))
                  this.MovePart(current, Conversions.ToInteger(current["Amount"]), locationID);
              }
            }
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
          }
          else
          {
            if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("You are about to move " + Conversions.ToString(this.CurrentQty) + " '"), this.SelectedStockDataRow["Description"]), (object) "' from '"), (object) Combo.get_GetSelectedItemDescription(this.cboLocationCurrent)), (object) "' to '"), (object) Combo.get_GetSelectedItemDescription(this.cboLocationNew)), (object) "'. Are you sure?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
              return;
            this.MovePart(this.SelectedStockDataRow, this.CurrentQty, locationID);
          }
          if (this.radWarehouseCurrent.Checked)
            this.ShowStock(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLocationCurrent)), 0);
          else
            this.ShowStock(0, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboLocationCurrent)));
          string str = "";
          if ((uint) this.txtFilter.Text.Trim().Length > 0U)
            str = str + "(Description LIKE '%" + this.txtFilter.Text.Trim() + "%' " + "OR Number LIKE '%" + this.txtFilter.Text.Trim() + "%' " + "OR Reference LIKE '%" + this.txtFilter.Text.Trim() + "%')";
          this.StockDataView.RowFilter = str;
        }
      }
    }

    private void txtFilter_TextChanged(object sender, EventArgs e)
    {
      if (this.StockDataView == null || this.StockDataView.Table == null)
        return;
      string str = "";
      if ((uint) this.txtFilter.Text.Trim().Length > 0U)
        str = str + "(Description LIKE '%" + this.txtFilter.Text.Trim() + "%' " + "OR Number LIKE '%" + this.txtFilter.Text.Trim() + "%' " + "OR Reference LIKE '%" + this.txtFilter.Text.Trim() + "%')";
      this.StockDataView.RowFilter = str;
    }

    private void ShowStock(int WarehouseID, int VanID)
    {
      DataTable table = new DataTable();
      table.TableName = Enums.TableNames.tblStock.ToString();
      table.Columns.Add(new DataColumn("Select", typeof (bool)));
      table.Columns.Add(new DataColumn("Type"));
      table.Columns.Add(new DataColumn("ID"));
      table.Columns.Add(new DataColumn("LocationID"));
      table.Columns.Add(new DataColumn("Description"));
      table.Columns.Add(new DataColumn("Number"));
      table.Columns.Add(new DataColumn("Reference"));
      table.Columns.Add(new DataColumn("Amount"));
      if ((uint) WarehouseID > 0U)
      {
        IEnumerator enumerator1;
        try
        {
          enumerator1 = App.DB.PartTransaction.GetByWarehouse(WarehouseID, true).Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            DataRow row = table.NewRow();
            row["Select"] = (object) false;
            row["Type"] = (object) "PART";
            row["ID"] = RuntimeHelpers.GetObjectValue(current["PartID"]);
            row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
            row["Description"] = RuntimeHelpers.GetObjectValue(current["PartName"]);
            row["Number"] = RuntimeHelpers.GetObjectValue(current["PartNumber"]);
            row["Reference"] = RuntimeHelpers.GetObjectValue(current["Reference"]);
            row["Amount"] = RuntimeHelpers.GetObjectValue(current["Amount"]);
            table.Rows.Add(row);
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        IEnumerator enumerator2;
        try
        {
          enumerator2 = App.DB.ProductTransaction.GetByWarehouse(WarehouseID).Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            DataRow row = table.NewRow();
            row["Select"] = (object) false;
            row["Type"] = (object) "PRODUCT";
            row["ID"] = RuntimeHelpers.GetObjectValue(current["ProductID"]);
            row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
            row["Description"] = RuntimeHelpers.GetObjectValue(current["typemakemodel"]);
            row["Number"] = RuntimeHelpers.GetObjectValue(current["ProductNumber"]);
            row["Reference"] = (object) "";
            row["Amount"] = RuntimeHelpers.GetObjectValue(current["Amount"]);
            table.Rows.Add(row);
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      else
      {
        IEnumerator enumerator1;
        try
        {
          enumerator1 = App.DB.PartTransaction.GetByVan2(VanID, false, true, 0).Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            DataRow row = table.NewRow();
            row["Select"] = (object) false;
            row["Type"] = (object) "PART";
            row["ID"] = RuntimeHelpers.GetObjectValue(current["PartID"]);
            row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
            row["Description"] = RuntimeHelpers.GetObjectValue(current["PartName"]);
            row["Number"] = RuntimeHelpers.GetObjectValue(current["PartNumber"]);
            row["Reference"] = RuntimeHelpers.GetObjectValue(current["Reference"]);
            row["Amount"] = RuntimeHelpers.GetObjectValue(current["Amount"]);
            table.Rows.Add(row);
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        IEnumerator enumerator2;
        try
        {
          enumerator2 = App.DB.ProductTransaction.GetByVan(VanID, false).Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            DataRow row = table.NewRow();
            row["Select"] = (object) false;
            row["Type"] = (object) "PRODUCT";
            row["ID"] = RuntimeHelpers.GetObjectValue(current["ProductID"]);
            row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
            row["Description"] = RuntimeHelpers.GetObjectValue(current["typemakemodel"]);
            row["Number"] = RuntimeHelpers.GetObjectValue(current["ProductNumber"]);
            row["Reference"] = (object) "";
            row["Amount"] = RuntimeHelpers.GetObjectValue(current["Amount"]);
            table.Rows.Add(row);
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      this.StockDataView = new DataView(table);
      this.CurrentQty = 1;
      this.txtQuantity.Text = Conversions.ToString(this.CurrentQty);
      this.Label2.Visible = true;
      this.txtQuantity.Visible = true;
      this.Label4.Visible = false;
    }

    private void dgItems_Click(object sender, EventArgs e)
    {
      this.Label2.Visible = true;
      this.txtQuantity.Visible = true;
      this.Label4.Visible = false;
      if (this.SelectedStockDataRow == null)
        return;
      this.dgItems[this.dgItems.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgItems[this.dgItems.CurrentRowIndex, 0]);
      int num = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.StockDataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((DataRow) enumerator.Current)["Select"], (object) true, false))
          {
            checked { ++num; }
            if (num > 1)
            {
              this.Label2.Visible = false;
              this.txtQuantity.Visible = false;
              this.Label4.Visible = true;
              break;
            }
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      DataRow[] dataRowArray = this.StockDataView.Table.Select(this.StockDataView.RowFilter);
      int index = 0;
      while (index < dataRowArray.Length)
      {
        dataRowArray[index]["Select"] = (object) true;
        checked { ++index; }
      }
      this.Label2.Visible = false;
      this.txtQuantity.Visible = false;
      this.Label4.Visible = true;
    }

    private void btnDeselectAll_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.StockDataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["Select"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.Label2.Visible = true;
      this.txtQuantity.Visible = true;
      this.Label4.Visible = false;
    }

    public void MovePart(DataRow dr, int qty, int locationID)
    {
      int PartID = 0;
      int ProductID = 0;
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "PART", false))
      {
        App.DB.PartTransaction.Insert(new PartTransaction()
        {
          IgnoreExceptionsOnSetMethods = true,
          SetTransactionTypeID = (object) 3,
          SetPartID = RuntimeHelpers.GetObjectValue(dr["ID"]),
          SetAmount = (object) checked (-qty),
          SetLocationID = RuntimeHelpers.GetObjectValue(dr["LocationID"])
        });
        App.DB.PartTransaction.Insert(new PartTransaction()
        {
          IgnoreExceptionsOnSetMethods = true,
          SetTransactionTypeID = (object) 2,
          SetPartID = RuntimeHelpers.GetObjectValue(dr["ID"]),
          SetAmount = (object) qty,
          SetLocationID = (object) locationID
        });
        PartID = Conversions.ToInteger(dr["ID"]);
      }
      else
      {
        App.DB.ProductTransaction.Insert(new ProductTransaction()
        {
          IgnoreExceptionsOnSetMethods = true,
          SetTransactionTypeID = (object) 3,
          SetProductID = RuntimeHelpers.GetObjectValue(dr["ID"]),
          SetAmount = (object) checked (-qty),
          SetLocationID = RuntimeHelpers.GetObjectValue(dr["LocationID"])
        });
        App.DB.ProductTransaction.Insert(new ProductTransaction()
        {
          IgnoreExceptionsOnSetMethods = true,
          SetTransactionTypeID = (object) 2,
          SetProductID = RuntimeHelpers.GetObjectValue(dr["ID"]),
          SetAmount = (object) qty,
          SetLocationID = (object) dr
        });
        ProductID = Conversions.ToInteger(dr["ID"]);
      }
      App.DB.Location.IPT_Audit_Insert(PartID, ProductID, Conversions.ToInteger(dr["LocationID"]), locationID, qty);
    }
  }
}
