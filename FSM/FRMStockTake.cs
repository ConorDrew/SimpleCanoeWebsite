// Decompiled with JetBrains decompiler
// Type: FSM.FRMStockTake
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity;
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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMStockTake : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _StockDataView;
    private DataView _dvStockTakeReason;

    public FRMStockTake()
    {
      this.Load += new EventHandler(this.FRMStockTake_Load);
      this._StockDataView = (DataView) null;
      this.InitializeComponent();
      ComboBox cboCategory = this.cboCategory;
      Combo.SetUpCombo(ref cboCategory, App.DB.Picklists.GetAll(Enums.PickListTypes.PartCategories, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboCategory = cboCategory;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpStockLevels { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpFilterArea { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton radVans
    {
      get
      {
        return this._radVans;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radVans_CheckedChanged);
        RadioButton radVans1 = this._radVans;
        if (radVans1 != null)
          radVans1.CheckedChanged -= eventHandler;
        this._radVans = value;
        RadioButton radVans2 = this._radVans;
        if (radVans2 == null)
          return;
        radVans2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton radWarehouses
    {
      get
      {
        return this._radWarehouses;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radWarehouses_CheckedChanged);
        RadioButton radWarehouses1 = this._radWarehouses;
        if (radWarehouses1 != null)
          radWarehouses1.CheckedChanged -= eventHandler;
        this._radWarehouses = value;
        RadioButton radWarehouses2 = this._radWarehouses;
        if (radWarehouses2 == null)
          return;
        radWarehouses2.CheckedChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgStock { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblShow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblArrow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnExport
    {
      get
      {
        return this._btnExport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExport_Click);
        Button btnExport1 = this._btnExport;
        if (btnExport1 != null)
          btnExport1.Click -= eventHandler;
        this._btnExport = value;
        Button btnExport2 = this._btnExport;
        if (btnExport2 == null)
          return;
        btnExport2.Click += eventHandler;
      }
    }

    internal virtual RadioButton radBothLocations
    {
      get
      {
        return this._radBothLocations;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radBothLocations_CheckedChanged);
        RadioButton radBothLocations1 = this._radBothLocations;
        if (radBothLocations1 != null)
          radBothLocations1.CheckedChanged -= eventHandler;
        this._radBothLocations = value;
        RadioButton radBothLocations2 = this._radBothLocations;
        if (radBothLocations2 == null)
          return;
        radBothLocations2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label lblBottomInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCategory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCategory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRun
    {
      get
      {
        return this._btnRun;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRun_Click);
        Button btnRun1 = this._btnRun;
        if (btnRun1 != null)
          btnRun1.Click -= eventHandler;
        this._btnRun = value;
        Button btnRun2 = this._btnRun;
        if (btnRun2 == null)
          return;
        btnRun2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkLocations { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLocationFilter
    {
      get
      {
        return this._txtLocationFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtLocationFilter_TextChanged);
        TextBox txtLocationFilter1 = this._txtLocationFilter;
        if (txtLocationFilter1 != null)
          txtLocationFilter1.TextChanged -= eventHandler;
        this._txtLocationFilter = value;
        TextBox txtLocationFilter2 = this._txtLocationFilter;
        if (txtLocationFilter2 == null)
          return;
        txtLocationFilter2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lblLocationFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblStockValuation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkExpectedNotZero { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPartMpn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMPN
    {
      get
      {
        return this._txtMPN;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtMPN_TextChanged);
        TextBox txtMpn1 = this._txtMPN;
        if (txtMpn1 != null)
          txtMpn1.KeyDown -= keyEventHandler;
        this._txtMPN = value;
        TextBox txtMpn2 = this._txtMPN;
        if (txtMpn2 == null)
          return;
        txtMpn2.KeyDown += keyEventHandler;
      }
    }

    internal virtual TextBox txtPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnStockReplenishment
    {
      get
      {
        return this._btnStockReplenishment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnStockReplenishment_Click);
        Button stockReplenishment1 = this._btnStockReplenishment;
        if (stockReplenishment1 != null)
          stockReplenishment1.Click -= eventHandler;
        this._btnStockReplenishment = value;
        Button stockReplenishment2 = this._btnStockReplenishment;
        if (stockReplenishment2 == null)
          return;
        stockReplenishment2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.dgStock = new DataGrid();
      this.grpStockLevels = new GroupBox();
      this.txtPrice = new TextBox();
      this.lblStockValuation = new Label();
      this.txtLocationFilter = new TextBox();
      this.lblLocationFilter = new Label();
      this.grpFilterArea = new GroupBox();
      this.txtMPN = new TextBox();
      this.lblPartMpn = new Label();
      this.chkExpectedNotZero = new CheckBox();
      this.chkLocations = new CheckBox();
      this.btnRun = new Button();
      this.cboCategory = new ComboBox();
      this.lblCategory = new Label();
      this.Panel2 = new Panel();
      this.radBothLocations = new RadioButton();
      this.radWarehouses = new RadioButton();
      this.radVans = new RadioButton();
      this.lblArrow = new Label();
      this.cboFilter = new ComboBox();
      this.lblShow = new Label();
      this.btnSave = new Button();
      this.btnExport = new Button();
      this.lblBottomInfo = new Label();
      this.btnStockReplenishment = new Button();
      this.dgStock.BeginInit();
      this.grpStockLevels.SuspendLayout();
      this.grpFilterArea.SuspendLayout();
      this.Panel2.SuspendLayout();
      this.SuspendLayout();
      this.dgStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgStock.DataMember = "";
      this.dgStock.HeaderForeColor = SystemColors.ControlText;
      this.dgStock.Location = new System.Drawing.Point(10, 45);
      this.dgStock.Name = "dgStock";
      this.dgStock.Size = new Size(884, 296);
      this.dgStock.TabIndex = 8;
      this.grpStockLevels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpStockLevels.Controls.Add((Control) this.txtPrice);
      this.grpStockLevels.Controls.Add((Control) this.lblStockValuation);
      this.grpStockLevels.Controls.Add((Control) this.txtLocationFilter);
      this.grpStockLevels.Controls.Add((Control) this.lblLocationFilter);
      this.grpStockLevels.Controls.Add((Control) this.dgStock);
      this.grpStockLevels.Location = new System.Drawing.Point(8, 160);
      this.grpStockLevels.Name = "grpStockLevels";
      this.grpStockLevels.Size = new Size(903, 349);
      this.grpStockLevels.TabIndex = 1;
      this.grpStockLevels.TabStop = false;
      this.grpStockLevels.Text = "Current Stock Levels";
      this.txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPrice.Location = new System.Drawing.Point(764, 13);
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.ReadOnly = true;
      this.txtPrice.Size = new Size(130, 21);
      this.txtPrice.TabIndex = 16;
      this.lblStockValuation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblStockValuation.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblStockValuation.Location = new System.Drawing.Point(652, 16);
      this.lblStockValuation.Name = "lblStockValuation";
      this.lblStockValuation.Size = new Size(118, 22);
      this.lblStockValuation.TabIndex = 14;
      this.lblStockValuation.Text = "Stock Valuation";
      this.txtLocationFilter.Location = new System.Drawing.Point(100, 17);
      this.txtLocationFilter.Name = "txtLocationFilter";
      this.txtLocationFilter.Size = new Size(214, 21);
      this.txtLocationFilter.TabIndex = 11;
      this.lblLocationFilter.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblLocationFilter.Location = new System.Drawing.Point(7, 20);
      this.lblLocationFilter.Name = "lblLocationFilter";
      this.lblLocationFilter.Size = new Size(105, 22);
      this.lblLocationFilter.TabIndex = 9;
      this.lblLocationFilter.Text = "Location filter";
      this.grpFilterArea.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilterArea.Controls.Add((Control) this.txtMPN);
      this.grpFilterArea.Controls.Add((Control) this.lblPartMpn);
      this.grpFilterArea.Controls.Add((Control) this.chkExpectedNotZero);
      this.grpFilterArea.Controls.Add((Control) this.chkLocations);
      this.grpFilterArea.Controls.Add((Control) this.btnRun);
      this.grpFilterArea.Controls.Add((Control) this.cboCategory);
      this.grpFilterArea.Controls.Add((Control) this.lblCategory);
      this.grpFilterArea.Controls.Add((Control) this.Panel2);
      this.grpFilterArea.Controls.Add((Control) this.lblShow);
      this.grpFilterArea.Location = new System.Drawing.Point(8, 48);
      this.grpFilterArea.Name = "grpFilterArea";
      this.grpFilterArea.Size = new Size(903, 106);
      this.grpFilterArea.TabIndex = 2;
      this.grpFilterArea.TabStop = false;
      this.grpFilterArea.Text = "Filters";
      this.txtMPN.Location = new System.Drawing.Point(72, 79);
      this.txtMPN.Name = "txtMPN";
      this.txtMPN.Size = new Size(244, 21);
      this.txtMPN.TabIndex = 14;
      this.lblPartMpn.AutoSize = true;
      this.lblPartMpn.Location = new System.Drawing.Point(9, 82);
      this.lblPartMpn.Name = "lblPartMpn";
      this.lblPartMpn.Size = new Size(58, 13);
      this.lblPartMpn.TabIndex = 13;
      this.lblPartMpn.Text = "Part MPN";
      this.chkExpectedNotZero.AutoSize = true;
      this.chkExpectedNotZero.Location = new System.Drawing.Point(334, 77);
      this.chkExpectedNotZero.Name = "chkExpectedNotZero";
      this.chkExpectedNotZero.Size = new Size(259, 17);
      this.chkExpectedNotZero.TabIndex = 12;
      this.chkExpectedNotZero.Text = "Only show parts where expected is not 0";
      this.chkExpectedNotZero.UseVisualStyleBackColor = true;
      this.chkLocations.AutoSize = true;
      this.chkLocations.Checked = true;
      this.chkLocations.CheckState = CheckState.Checked;
      this.chkLocations.Location = new System.Drawing.Point(334, 57);
      this.chkLocations.Name = "chkLocations";
      this.chkLocations.Size = new Size(225, 17);
      this.chkLocations.TabIndex = 11;
      this.chkLocations.Text = "Only show parts with a location set";
      this.chkLocations.UseVisualStyleBackColor = true;
      this.btnRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRun.Location = new System.Drawing.Point(840, 78);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new Size(56, 25);
      this.btnRun.TabIndex = 10;
      this.btnRun.Text = "Run";
      this.cboCategory.Location = new System.Drawing.Point(72, 53);
      this.cboCategory.Name = "cboCategory";
      this.cboCategory.Size = new Size(244, 21);
      this.cboCategory.TabIndex = 9;
      this.lblCategory.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblCategory.Location = new System.Drawing.Point(9, 51);
      this.lblCategory.Name = "lblCategory";
      this.lblCategory.Size = new Size(64, 22);
      this.lblCategory.TabIndex = 8;
      this.lblCategory.Text = "Category";
      this.Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Panel2.Controls.Add((Control) this.radBothLocations);
      this.Panel2.Controls.Add((Control) this.radWarehouses);
      this.Panel2.Controls.Add((Control) this.radVans);
      this.Panel2.Controls.Add((Control) this.lblArrow);
      this.Panel2.Controls.Add((Control) this.cboFilter);
      this.Panel2.Location = new System.Drawing.Point(62, 14);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new Size(835, 32);
      this.Panel2.TabIndex = 6;
      this.radBothLocations.Checked = true;
      this.radBothLocations.Location = new System.Drawing.Point(216, 6);
      this.radBothLocations.Name = "radBothLocations";
      this.radBothLocations.Size = new Size(56, 26);
      this.radBothLocations.TabIndex = 6;
      this.radBothLocations.TabStop = true;
      this.radBothLocations.Text = "Both";
      this.radWarehouses.Location = new System.Drawing.Point(8, 6);
      this.radWarehouses.Name = "radWarehouses";
      this.radWarehouses.Size = new Size(96, 26);
      this.radWarehouses.TabIndex = 4;
      this.radWarehouses.Text = "Warehouses";
      this.radVans.Location = new System.Drawing.Point(110, 6);
      this.radVans.Name = "radVans";
      this.radVans.Size = new Size(97, 26);
      this.radVans.TabIndex = 5;
      this.radVans.Text = "Stock Profile";
      this.lblArrow.Location = new System.Drawing.Point(267, 10);
      this.lblArrow.Name = "lblArrow";
      this.lblArrow.Size = new Size(24, 23);
      this.lblArrow.TabIndex = 7;
      this.lblArrow.Text = ">";
      this.cboFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboFilter.Location = new System.Drawing.Point(293, 8);
      this.cboFilter.Name = "cboFilter";
      this.cboFilter.Size = new Size(534, 21);
      this.cboFilter.TabIndex = 7;
      this.lblShow.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblShow.Location = new System.Drawing.Point(8, 24);
      this.lblShow.Name = "lblShow";
      this.lblShow.Size = new Size(48, 22);
      this.lblShow.TabIndex = 7;
      this.lblShow.Text = "Show";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(855, 520);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 25);
      this.btnSave.TabIndex = 3;
      this.btnSave.Text = "Save";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 520);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 25);
      this.btnExport.TabIndex = 9;
      this.btnExport.Text = "Export";
      this.lblBottomInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblBottomInfo.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.lblBottomInfo.Font = new Font("Verdana", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblBottomInfo.Location = new System.Drawing.Point(180, 520);
      this.lblBottomInfo.Name = "lblBottomInfo";
      this.lblBottomInfo.Size = new Size(675, 23);
      this.lblBottomInfo.TabIndex = 5;
      this.lblBottomInfo.Text = "Use last columns to enter ACTUAL STOCK AMOUNT AND REASON then click save";
      this.lblBottomInfo.TextAlign = ContentAlignment.MiddleCenter;
      this.btnStockReplenishment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnStockReplenishment.Location = new System.Drawing.Point(72, 520);
      this.btnStockReplenishment.Name = "btnStockReplenishment";
      this.btnStockReplenishment.Size = new Size(184, 25);
      this.btnStockReplenishment.TabIndex = 10;
      this.btnStockReplenishment.Text = "Manage Stock Replenishment";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(919, 550);
      this.Controls.Add((Control) this.btnStockReplenishment);
      this.Controls.Add((Control) this.lblBottomInfo);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.grpFilterArea);
      this.Controls.Add((Control) this.grpStockLevels);
      this.MinimumSize = new Size(860, 584);
      this.Name = nameof (FRMStockTake);
      this.Text = "Stock Take";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpStockLevels, 0);
      this.Controls.SetChildIndex((Control) this.grpFilterArea, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.lblBottomInfo, 0);
      this.Controls.SetChildIndex((Control) this.btnStockReplenishment, 0);
      this.dgStock.EndInit();
      this.grpStockLevels.ResumeLayout(false);
      this.grpStockLevels.PerformLayout();
      this.grpFilterArea.ResumeLayout(false);
      this.grpFilterArea.PerformLayout();
      this.Panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      if (App.IsRFT)
      {
        this.DvStockTakeReason = App.DB.Location.StockTakeReason_Get();
        DataRow row = this.DvStockTakeReason.Table.NewRow();
        row["StockTakeReasonID"] = (object) 0;
        row["StockTakeReasonType"] = (object) "-- Select reason --";
        this.DvStockTakeReason.Table.Rows.InsertAt(row, 0);
      }
      this.StockDgSetup();
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
        this._StockDataView.AllowNew = false;
        this._StockDataView.AllowEdit = true;
        this._StockDataView.AllowDelete = false;
        this._StockDataView.Table.TableName = Enums.TableNames.tblStock.ToString();
        this.dgStock.DataSource = (object) this.StockDataView;
      }
    }

    private DataView DvStockTakeReason
    {
      get
      {
        return this._dvStockTakeReason;
      }
      set
      {
        this._dvStockTakeReason = value;
      }
    }

    public void StockDgSetup()
    {
      DataGridTableStyle tableStyle = this.dgStock.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Category";
      dataGridLabelColumn1.MappingName = "Category";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 200;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Name";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 200;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Number";
      dataGridLabelColumn3.MappingName = "Number";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Reference";
      dataGridLabelColumn4.MappingName = "Reference";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "c";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Unit Cost";
      dataGridLabelColumn5.MappingName = "Cost";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 80;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Location";
      dataGridLabelColumn6.MappingName = "Location";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Expected";
      dataGridLabelColumn7.MappingName = "Amount";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 80;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridOrderTextBoxColumn orderTextBoxColumn = new DataGridOrderTextBoxColumn();
      orderTextBoxColumn.Format = "";
      orderTextBoxColumn.FormatInfo = (IFormatProvider) null;
      orderTextBoxColumn.HeaderText = "Actual";
      orderTextBoxColumn.MappingName = "ActualAmount";
      orderTextBoxColumn.ReadOnly = false;
      orderTextBoxColumn.Width = 80;
      orderTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) orderTextBoxColumn);
      if (App.IsRFT)
      {
        DataGridComboBoxColumn gridComboBoxColumn = new DataGridComboBoxColumn(false);
        gridComboBoxColumn.HeaderText = "Reason";
        gridComboBoxColumn.MappingName = "Reason";
        gridComboBoxColumn.ReadOnly = false;
        gridComboBoxColumn.Width = 250;
        gridComboBoxColumn.ComboBox.DataSource = (object) this.DvStockTakeReason;
        gridComboBoxColumn.ComboBox.DisplayMember = "StockTakeReasonType";
        gridComboBoxColumn.ComboBox.ValueMember = "StockTakeReasonID";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn);
      }
      tableStyle.ReadOnly = false;
      this.dgStock.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblStock.ToString();
      this.dgStock.TableStyles.Add(tableStyle);
    }

    private void FRMStockTake_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void radWarehouses_CheckedChanged(object sender, EventArgs e)
    {
      ComboBox cboFilter1 = this.cboFilter;
      Combo.SetUpCombo(ref cboFilter1, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Enums.ComboValues.No_Filter);
      this.cboFilter = cboFilter1;
      ComboBox cboFilter2 = this.cboFilter;
      Combo.SetSelectedComboItem_By_Value(ref cboFilter2, Conversions.ToString(0));
      this.cboFilter = cboFilter2;
      this.cboFilter.Enabled = true;
    }

    private void radVans_CheckedChanged(object sender, EventArgs e)
    {
      ComboBox cboFilter1 = this.cboFilter;
      Combo.SetUpCombo(ref cboFilter1, App.DB.Van.Van_GetAll(false).Table, "VanID", "Registration", Enums.ComboValues.No_Filter);
      this.cboFilter = cboFilter1;
      ComboBox cboFilter2 = this.cboFilter;
      Combo.SetSelectedComboItem_By_Value(ref cboFilter2, Conversions.ToString(0));
      this.cboFilter = cboFilter2;
      this.cboFilter.Enabled = true;
    }

    private void radBothLocations_CheckedChanged(object sender, EventArgs e)
    {
      ComboBox cboFilter1 = this.cboFilter;
      Combo.SetUpCombo(ref cboFilter1, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Enums.ComboValues.No_Filter);
      this.cboFilter = cboFilter1;
      ComboBox cboFilter2 = this.cboFilter;
      Combo.SetSelectedComboItem_By_Value(ref cboFilter2, Conversions.ToString(0));
      this.cboFilter = cboFilter2;
      this.cboFilter.Enabled = false;
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
      this.Populate();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void btnStockReplenishment_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMStockReplenishment), true, new object[1]
      {
        (object) false
      }, false);
      this.Populate();
    }

    private void txtLocationFilter_TextChanged(object sender, EventArgs e)
    {
      this.Filter();
    }

    private void txtMPN_TextChanged(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.Populate();
    }

    private void Filter()
    {
      if (this.StockDataView == null)
        return;
      string str = "1 = 1 ";
      if ((uint) this.txtLocationFilter.Text.Trim().Length > 0U)
        str = str + " AND Location LIKE '%" + Helper.RemoveSpecialCharacters(this.txtLocationFilter.Text.Trim()) + "%' ";
      this.StockDataView.RowFilter = str.Replace("*", "[*]");
      this.CalcValuation();
    }

    private void Populate()
    {
      int WarehouseID = 0;
      int VanID = 0;
      bool ShowWarehousesOnly = false;
      bool ShowVansOnly = false;
      if (this.radWarehouses.Checked)
      {
        WarehouseID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboFilter));
        ShowWarehousesOnly = true;
      }
      if (this.radVans.Checked)
      {
        VanID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboFilter));
        ShowVansOnly = true;
      }
      Cursor.Current = Cursors.WaitCursor;
      this.StockDataView = Microsoft.VisualBasic.Strings.Len(this.txtMPN.Text) != 0 ? App.DB.Location.StockTake_GetAll_WithName(this.chkLocations.Checked, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboCategory)), WarehouseID, VanID, this.chkExpectedNotZero.Checked, ShowWarehousesOnly, ShowVansOnly, this.txtMPN.Text) : App.DB.Location.StockTake_GetAll(this.chkLocations.Checked, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboCategory)), WarehouseID, VanID, this.chkExpectedNotZero.Checked, ShowWarehousesOnly, ShowVansOnly);
      this.CalcValuation();
      Cursor.Current = Cursors.Default;
    }

    private void Save()
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        string str = "";
        bool flag = true;
        EnumerableRowCollection<DataRow> source = this.StockDataView.Table.AsEnumerable();
        Func<DataRow, bool> predicate;
        // ISSUE: reference to a compiler-generated field
        if (FRMStockTake._Closure\u0024__.\u0024I129\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          predicate = FRMStockTake._Closure\u0024__.\u0024I129\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMStockTake._Closure\u0024__.\u0024I129\u002D0 = predicate = (Func<DataRow, bool>) (x => !Helper.IsStringEmpty(RuntimeHelpers.GetObjectValue(x["actualAmount"])));
        }
        DataRow[] array = source.Where<DataRow>(predicate).ToArray<DataRow>();
        DataRow[] dataRowArray1 = array;
        int index1 = 0;
        while (index1 < dataRowArray1.Length)
        {
          DataRow dataRow = dataRowArray1[index1];
          if ((uint) Conversions.ToString(dataRow["actualAmount"]).Trim().Length > 0U)
          {
            if (!Helper.IsValidInteger(RuntimeHelpers.GetObjectValue(dataRow["actualAmount"])))
            {
              flag = false;
              str = Conversions.ToInteger(dataRow["PartID"]) <= 0 ? Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Amount for product '", dataRow["Number"]), (object) "' in '"), dataRow["Location"]), (object) "' is invalid"), (object) "\r\n"))) : Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Amount for part '", dataRow["Number"]), (object) "' in '"), dataRow["Location"]), (object) "' is invalid"), (object) "\r\n")));
            }
            if (App.IsRFT && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["Reason"])) <= 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["actualAmount"])) != Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["Amount"])))
            {
              flag = false;
              str = Conversions.ToInteger(dataRow["PartID"]) <= 0 ? Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Reason for product '", dataRow["Number"]), (object) "' in '"), dataRow["Location"]), (object) "' is missing"), (object) "\r\n"))) : Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Reason for part '", dataRow["Number"]), (object) "' in '"), dataRow["Location"]), (object) "' is missing"), (object) "\r\n")));
            }
          }
          checked { ++index1; }
        }
        if (!flag)
        {
          int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) str), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          if (App.ShowMessage("Perform stock adjustments now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            return;
          DataRow[] dataRowArray2 = array;
          int index2 = 0;
          while (index2 < dataRowArray2.Length)
          {
            DataRow dataRow = dataRowArray2[index2];
            if (Helper.IsValidInteger(RuntimeHelpers.GetObjectValue(dataRow["actualAmount"])))
            {
              if ((uint) Conversions.ToInteger(dataRow["PartID"]) > 0U)
              {
                App.DB.PartTransaction.PartTransaction_Consolidate_All(Conversions.ToInteger(dataRow["LocationID"]), Conversions.ToInteger(dataRow["PartID"]));
                App.DB.PartTransaction.Insert(new PartTransaction()
                {
                  SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["LocationID"]),
                  SetAmount = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dataRow["actualAmount"], dataRow["Amount"]),
                  SetPartID = RuntimeHelpers.GetObjectValue(dataRow["PartID"]),
                  SetTransactionTypeID = (object) 1
                });
              }
              else
              {
                App.DB.ProductTransaction.ProductTransaction_Consolidate_All(Conversions.ToInteger(dataRow["LocationID"]), Conversions.ToInteger(dataRow["ProductID"]));
                App.DB.ProductTransaction.Insert(new ProductTransaction()
                {
                  SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["LocationID"]),
                  SetAmount = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dataRow["actualAmount"], dataRow["Amount"]),
                  SetProductID = RuntimeHelpers.GetObjectValue(dataRow["ProductID"]),
                  SetTransactionTypeID = (object) 1
                });
              }
              if (App.IsRFT)
                App.DB.StockTakeAudit.Insert(new StockTakeAudit()
                {
                  SetPartID = RuntimeHelpers.GetObjectValue(dataRow["PartID"]),
                  SetOriginalAmount = RuntimeHelpers.GetObjectValue(dataRow["Amount"]),
                  SetNewAmount = RuntimeHelpers.GetObjectValue(dataRow["actualAmount"]),
                  SetReasonChange = Conversions.ToInteger(dataRow["Reason"]),
                  SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["LocationID"])
                });
            }
            checked { ++index2; }
          }
          this.Populate();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not perform stock adjustments : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
    }

    public void Export()
    {
      if (this.StockDataView == null)
        return;
      DataTable datatableIn = new DataTable();
      datatableIn.Columns.Add("Category");
      datatableIn.Columns.Add("Location");
      datatableIn.Columns.Add("Name");
      datatableIn.Columns.Add("Number");
      datatableIn.Columns.Add("Reference");
      datatableIn.Columns.Add("Cost");
      datatableIn.Columns.Add("MinQty");
      datatableIn.Columns.Add("MaxQty");
      datatableIn.Columns.Add("Amount Expected");
      datatableIn.Columns.Add("Actual Amount");
      IEnumerator enumerator;
      try
      {
        enumerator = this.StockDataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          DataRow row = datatableIn.NewRow();
          row["Category"] = RuntimeHelpers.GetObjectValue(current["Category"]);
          row["Location"] = RuntimeHelpers.GetObjectValue(current["Location"]);
          row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
          row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
          row["Reference"] = RuntimeHelpers.GetObjectValue(current["Reference"]);
          row["Cost"] = RuntimeHelpers.GetObjectValue(current["Cost"]);
          row["Amount Expected"] = RuntimeHelpers.GetObjectValue(current["Amount"]);
          row["Actual Amount"] = RuntimeHelpers.GetObjectValue(current["ActualAmount"]);
          row["MinQty"] = RuntimeHelpers.GetObjectValue(current["MinQty"]);
          row["MaxQty"] = RuntimeHelpers.GetObjectValue(current["RecQty"]);
          datatableIn.Rows.Add(row);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      Exporting exporting = new Exporting(datatableIn, "Stock Take", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }

    public void CalcValuation()
    {
      double num1 = 0.0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.StockDataView.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator.Current;
          double num2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Amount"]));
          if (num2 > 0.0)
            num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Cost"])) * num2;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.txtPrice.Text = Math.Round(num1, 2, MidpointRounding.AwayFromZero).ToString("C");
    }
  }
}
