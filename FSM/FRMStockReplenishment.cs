// Decompiled with JetBrains decompiler
// Type: FSM.FRMStockReplenishment
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.OrderLocations;
using FSM.Entity.OrderParts;
using FSM.Entity.Orders;
using FSM.Entity.PartTransactions;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
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
  public class FRMStockReplenishment : FRMBaseForm, IForm
  {
    private IContainer components;
    private string lastSelectedType;
    private int lastSelectedID;
    private ArrayList warehouses;
    private ArrayList vans;
    private DataView _StockDataView;

    public FRMStockReplenishment()
    {
      this.Load += new EventHandler(this.FRMStockReplenishment_Load);
      this.lastSelectedType = "";
      this.lastSelectedID = 0;
      this.warehouses = new ArrayList();
      this.vans = new ArrayList();
      this._StockDataView = (DataView) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgStockReplenishment
    {
      get
      {
        return this._dgStockReplenishment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgStockReplenishment_MouseUp);
        DataGrid stockReplenishment1 = this._dgStockReplenishment;
        if (stockReplenishment1 != null)
          stockReplenishment1.MouseUp -= mouseEventHandler;
        this._dgStockReplenishment = value;
        DataGrid stockReplenishment2 = this._dgStockReplenishment;
        if (stockReplenishment2 == null)
          return;
        stockReplenishment2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual Button btnToMinimum
    {
      get
      {
        return this._btnToMinimum;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnToMinimum_Click);
        Button btnToMinimum1 = this._btnToMinimum;
        if (btnToMinimum1 != null)
          btnToMinimum1.Click -= eventHandler;
        this._btnToMinimum = value;
        Button btnToMinimum2 = this._btnToMinimum;
        if (btnToMinimum2 == null)
          return;
        btnToMinimum2.Click += eventHandler;
      }
    }

    internal virtual Button btnToRecommended
    {
      get
      {
        return this._btnToRecommended;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnToRecommended_Click);
        Button btnToRecommended1 = this._btnToRecommended;
        if (btnToRecommended1 != null)
          btnToRecommended1.Click -= eventHandler;
        this._btnToRecommended = value;
        Button btnToRecommended2 = this._btnToRecommended;
        if (btnToRecommended2 == null)
          return;
        btnToRecommended2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkRecommended { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkMinimum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNumberOfItems { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtItem { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLocation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRunFilter
    {
      get
      {
        return this._btnRunFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRunFilter_Click);
        Button btnRunFilter1 = this._btnRunFilter;
        if (btnRunFilter1 != null)
          btnRunFilter1.Click -= eventHandler;
        this._btnRunFilter = value;
        Button btnRunFilter2 = this._btnRunFilter;
        if (btnRunFilter2 == null)
          return;
        btnRunFilter2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkIncludeVans { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.dgStockReplenishment = new DataGrid();
      this.btnToMinimum = new Button();
      this.btnToRecommended = new Button();
      this.chkRecommended = new CheckBox();
      this.chkMinimum = new CheckBox();
      this.lblNumberOfItems = new Label();
      this.Label2 = new Label();
      this.Panel1 = new Panel();
      this.Panel2 = new Panel();
      this.Panel3 = new Panel();
      this.Label3 = new Label();
      this.Label4 = new Label();
      this.Panel4 = new Panel();
      this.Label5 = new Label();
      this.GroupBox2 = new GroupBox();
      this.btnRunFilter = new Button();
      this.chkIncludeVans = new CheckBox();
      this.txtItem = new TextBox();
      this.txtLocation = new TextBox();
      this.Label6 = new Label();
      this.Label8 = new Label();
      this.GroupBox3 = new GroupBox();
      this.btnClose = new Button();
      this.GroupBox1.SuspendLayout();
      this.dgStockReplenishment.BeginInit();
      this.GroupBox2.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dgStockReplenishment);
      this.GroupBox1.Location = new System.Drawing.Point(8, 204);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(992, 488);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Tick those combinations you wish to update";
      this.dgStockReplenishment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgStockReplenishment.DataMember = "";
      this.dgStockReplenishment.HeaderForeColor = SystemColors.ControlText;
      this.dgStockReplenishment.Location = new System.Drawing.Point(8, 25);
      this.dgStockReplenishment.Name = "dgStockReplenishment";
      this.dgStockReplenishment.Size = new Size(976, 455);
      this.dgStockReplenishment.TabIndex = 7;
      this.btnToMinimum.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnToMinimum.Location = new System.Drawing.Point(432, 700);
      this.btnToMinimum.Name = "btnToMinimum";
      this.btnToMinimum.Size = new Size(280, 23);
      this.btnToMinimum.TabIndex = 3;
      this.btnToMinimum.Text = "Bring amounts up to minimum quantities";
      this.btnToRecommended.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnToRecommended.Location = new System.Drawing.Point(720, 700);
      this.btnToRecommended.Name = "btnToRecommended";
      this.btnToRecommended.Size = new Size(280, 23);
      this.btnToRecommended.TabIndex = 4;
      this.btnToRecommended.Text = "Bring amounts up to maximum quantities";
      this.chkRecommended.Location = new System.Drawing.Point(10, 76);
      this.chkRecommended.Name = "chkRecommended";
      this.chkRecommended.Size = new Size(271, 24);
      this.chkRecommended.TabIndex = 2;
      this.chkRecommended.Text = "Items where amount is below maximum";
      this.chkMinimum.Checked = true;
      this.chkMinimum.CheckState = CheckState.Checked;
      this.chkMinimum.Location = new System.Drawing.Point(10, 103);
      this.chkMinimum.Name = "chkMinimum";
      this.chkMinimum.Size = new Size(256, 24);
      this.chkMinimum.TabIndex = 3;
      this.chkMinimum.Text = "Items where amount is below minimum";
      this.lblNumberOfItems.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblNumberOfItems.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.lblNumberOfItems.Font = new Font("Verdana", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblNumberOfItems.Location = new System.Drawing.Point(85, 700);
      this.lblNumberOfItems.Name = "lblNumberOfItems";
      this.lblNumberOfItems.Size = new Size(341, 24);
      this.lblNumberOfItems.TabIndex = 7;
      this.lblNumberOfItems.TextAlign = ContentAlignment.MiddleCenter;
      this.Label2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.Location = new System.Drawing.Point(32, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(425, 16);
      this.Label2.TabIndex = 9;
      this.Label2.Text = "Amount ABOVE or EQUAL to both minimum and the maximum quantities";
      this.Panel1.BackColor = Color.Yellow;
      this.Panel1.Location = new System.Drawing.Point(8, 54);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(16, 16);
      this.Panel1.TabIndex = 10;
      this.Panel2.BackColor = Color.Salmon;
      this.Panel2.Location = new System.Drawing.Point(8, 82);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new Size(16, 16);
      this.Panel2.TabIndex = 11;
      this.Panel3.BackColor = Color.LightGreen;
      this.Panel3.Location = new System.Drawing.Point(8, 24);
      this.Panel3.Name = "Panel3";
      this.Panel3.Size = new Size(16, 16);
      this.Panel3.TabIndex = 12;
      this.Label3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label3.Location = new System.Drawing.Point(32, 54);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(425, 16);
      this.Label3.TabIndex = 13;
      this.Label3.Text = "Amount ABOVE or EQUAL to minimum but BELOW maximum quantities";
      this.Label4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label4.Location = new System.Drawing.Point(32, 82);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(376, 16);
      this.Label4.TabIndex = 14;
      this.Label4.Text = "Amount BELOW both minimum and the maximum quantities";
      this.Panel4.BackColor = Color.LightBlue;
      this.Panel4.Location = new System.Drawing.Point(8, 109);
      this.Panel4.Name = "Panel4";
      this.Panel4.Size = new Size(16, 16);
      this.Panel4.TabIndex = 15;
      this.Label5.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label5.Location = new System.Drawing.Point(32, 109);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(376, 16);
      this.Label5.TabIndex = 16;
      this.Label5.Text = "A quantity is on order to replenish stock";
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.btnRunFilter);
      this.GroupBox2.Controls.Add((Control) this.chkIncludeVans);
      this.GroupBox2.Controls.Add((Control) this.txtItem);
      this.GroupBox2.Controls.Add((Control) this.txtLocation);
      this.GroupBox2.Controls.Add((Control) this.Label6);
      this.GroupBox2.Controls.Add((Control) this.Label8);
      this.GroupBox2.Controls.Add((Control) this.chkRecommended);
      this.GroupBox2.Controls.Add((Control) this.chkMinimum);
      this.GroupBox2.Location = new System.Drawing.Point(8, 40);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(479, 158);
      this.GroupBox2.TabIndex = 0;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Filters";
      this.btnRunFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRunFilter.Location = new System.Drawing.Point(388, 128);
      this.btnRunFilter.Name = "btnRunFilter";
      this.btnRunFilter.Size = new Size(85, 23);
      this.btnRunFilter.TabIndex = 12;
      this.btnRunFilter.Text = "Filter";
      this.btnRunFilter.UseVisualStyleBackColor = true;
      this.chkIncludeVans.Location = new System.Drawing.Point(10, 128);
      this.chkIncludeVans.Name = "chkIncludeVans";
      this.chkIncludeVans.Size = new Size(256, 24);
      this.chkIncludeVans.TabIndex = 11;
      this.chkIncludeVans.Text = "Include Vans";
      this.txtItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtItem.Location = new System.Drawing.Point(80, 49);
      this.txtItem.Name = "txtItem";
      this.txtItem.Size = new Size(393, 21);
      this.txtItem.TabIndex = 1;
      this.txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtLocation.Location = new System.Drawing.Point(80, 21);
      this.txtLocation.Name = "txtLocation";
      this.txtLocation.Size = new Size(393, 21);
      this.txtLocation.TabIndex = 0;
      this.Label6.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label6.Location = new System.Drawing.Point(10, 49);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 23);
      this.Label6.TabIndex = 10;
      this.Label6.Text = "Item";
      this.Label8.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label8.Location = new System.Drawing.Point(10, 23);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(88, 23);
      this.Label8.TabIndex = 7;
      this.Label8.Text = "Location";
      this.GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.GroupBox3.Controls.Add((Control) this.Panel1);
      this.GroupBox3.Controls.Add((Control) this.Panel3);
      this.GroupBox3.Controls.Add((Control) this.Panel4);
      this.GroupBox3.Controls.Add((Control) this.Panel2);
      this.GroupBox3.Controls.Add((Control) this.Label2);
      this.GroupBox3.Controls.Add((Control) this.Label3);
      this.GroupBox3.Controls.Add((Control) this.Label4);
      this.GroupBox3.Controls.Add((Control) this.Label5);
      this.GroupBox3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.GroupBox3.Location = new System.Drawing.Point(493, 40);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(507, 158);
      this.GroupBox3.TabIndex = 1;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "KEY";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(8, 700);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(64, 23);
      this.btnClose.TabIndex = 5;
      this.btnClose.Text = "Close";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1008, 730);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.GroupBox3);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.lblNumberOfItems);
      this.Controls.Add((Control) this.btnToRecommended);
      this.Controls.Add((Control) this.btnToMinimum);
      this.Controls.Add((Control) this.GroupBox1);
      this.MinimumSize = new Size(832, 544);
      this.Name = nameof (FRMStockReplenishment);
      this.Text = "Stock Replenishment";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.btnToMinimum, 0);
      this.Controls.SetChildIndex((Control) this.btnToRecommended, 0);
      this.Controls.SetChildIndex((Control) this.lblNumberOfItems, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox2, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox3, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.GroupBox1.ResumeLayout(false);
      this.dgStockReplenishment.EndInit();
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox2.PerformLayout();
      this.GroupBox3.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      if (Conversions.ToBoolean(this.get_GetParameter(0)))
        this.WindowState = FormWindowState.Maximized;
      this.SetupStockDatagrid();
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
        this.dgStockReplenishment.DataSource = (object) this.StockDataView;
      }
    }

    private DataRow SelectedStockDataRow
    {
      get
      {
        return this.dgStockReplenishment.CurrentRowIndex != -1 ? this.StockDataView[this.dgStockReplenishment.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupStockDatagrid()
    {
      Helper.SetUpDataGrid(this.dgStockReplenishment, false);
      DataGridTableStyle tableStyle = this.dgStockReplenishment.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgStockReplenishment.ReadOnly = false;
      tableStyle.AllowSorting = true;
      tableStyle.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Location";
      dataGridLabelColumn1.MappingName = "Location";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Item";
      dataGridLabelColumn2.MappingName = "Item";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Minimum Quantity";
      dataGridLabelColumn3.MappingName = "MinimumQuantity";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Maximum Quantity";
      dataGridLabelColumn4.MappingName = "RecommendedQuantity";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      StockReplenishmentColourColumn replenishmentColourColumn = new StockReplenishmentColourColumn();
      replenishmentColourColumn.Format = "";
      replenishmentColourColumn.FormatInfo = (IFormatProvider) null;
      replenishmentColourColumn.HeaderText = "Amount";
      replenishmentColourColumn.MappingName = "Amount";
      replenishmentColourColumn.ReadOnly = true;
      replenishmentColourColumn.Width = 75;
      replenishmentColourColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) replenishmentColourColumn);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Packs On Order";
      dataGridLabelColumn5.MappingName = "PacksOnOrder";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 120;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Units On Order";
      dataGridLabelColumn6.MappingName = "UnitsOnOrder";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 120;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.MappingName = Enums.TableNames.tblStock.ToString();
      this.dgStockReplenishment.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgStockReplenishment);
    }

    private void FRMStockReplenishment_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgStockReplenishment_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        if (this.SelectedStockDataRow == null)
          return;
        DataGrid.HitTestInfo hitTestInfo = this.dgStockReplenishment.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell && hitTestInfo.Column == 0)
          this.dgStockReplenishment[this.dgStockReplenishment.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgStockReplenishment[this.dgStockReplenishment.CurrentRowIndex, 0]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnToMinimum_Click(object sender, EventArgs e)
    {
      try
      {
        this.lastSelectedType = "";
        this.lastSelectedID = 0;
        if (App.ShowMessage("This will create orders. Some stock can be replenished from warehouses, others may require a supplier selection. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        Cursor.Current = Cursors.WaitCursor;
        this.warehouses.Clear();
        this.vans.Clear();
        IEnumerator enumerator;
        try
        {
          enumerator = this.StockDataView.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Conversions.ToBoolean(current["Tick"]))
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["WarehouseID"], (object) 0, false))
                this.AddPlaceToGetFrom(current, "MinimumQuantity", this.CheckAndAddVan(Conversions.ToInteger(current["VanID"]), Conversions.ToString(current["Location"])), true);
              else
                this.AddPlaceToGetFrom(current, "MinimumQuantity", this.CheckAndAddWarehouse(Conversions.ToInteger(current["WarehouseID"]), Conversions.ToString(current["Location"])), false);
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.CreateOrders();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error generating orders : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.WaitCursor;
      }
    }

    private void btnToRecommended_Click(object sender, EventArgs e)
    {
      try
      {
        this.lastSelectedType = "";
        this.lastSelectedID = 0;
        if (App.ShowMessage("This will create orders. Some stock can be replenished from warehouses, others may require a supplier selection. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        Cursor.Current = Cursors.WaitCursor;
        this.warehouses.Clear();
        this.vans.Clear();
        IEnumerator enumerator;
        try
        {
          enumerator = this.StockDataView.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Conversions.ToBoolean(current["Tick"]))
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["WarehouseID"], (object) 0, false))
                this.AddPlaceToGetFrom(current, "RecommendedQuantity", this.CheckAndAddVan(Conversions.ToInteger(current["VanID"]), Conversions.ToString(current["Location"])), true);
              else
                this.AddPlaceToGetFrom(current, "RecommendedQuantity", this.CheckAndAddWarehouse(Conversions.ToInteger(current["WarehouseID"]), Conversions.ToString(current["Location"])), false);
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.CreateOrders();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error generating orders : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.WaitCursor;
      }
    }

    private void btnRunFilter_Click(object sender, EventArgs e)
    {
      this.Filter();
    }

    private void Filter()
    {
      this.StockDataView = App.DB.Location.StockTake_Replenishment_Filtered(this.txtLocation.Text, this.txtItem.Text, this.chkIncludeVans.Checked, this.chkMinimum.Checked, this.chkRecommended.Checked);
      this.lblNumberOfItems.Text = Conversions.ToString(this.StockDataView.Count) + " Items";
    }

    private int CheckAndAddWarehouse(int WarehouseID, string Warehouse)
    {
      bool flag = false;
      int num = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.warehouses.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((ArrayList) enumerator.Current)[0], (object) WarehouseID, false))
          {
            flag = true;
            break;
          }
          checked { ++num; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (!flag)
        this.warehouses.Add((object) new ArrayList()
        {
          (object) WarehouseID,
          (object) new DataTable()
          {
            Columns = {
              new DataColumn("PartID"),
              new DataColumn("PartSupplierID"),
              new DataColumn("LocationID"),
              new DataColumn("Quantity"),
              new DataColumn("BuyPrice"),
              new DataColumn("SupplierID"),
              new DataColumn("Deleted")
            }
          },
          (object) Warehouse
        });
      return num;
    }

    private int CheckAndAddVan(int VanID, string Van)
    {
      bool flag = false;
      int num = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.vans.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((ArrayList) enumerator.Current)[0], (object) VanID, false))
          {
            flag = true;
            break;
          }
          checked { ++num; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (!flag)
        this.vans.Add((object) new ArrayList()
        {
          (object) VanID,
          (object) new DataTable()
          {
            Columns = {
              new DataColumn("PartID"),
              new DataColumn("PartSupplierID"),
              new DataColumn("LocationID"),
              new DataColumn("Quantity"),
              new DataColumn("BuyPrice"),
              new DataColumn("SupplierID"),
              new DataColumn("Deleted")
            }
          },
          (object) Van
        });
      return num;
    }

    private void AddPlaceToGetFrom(
      DataRow row,
      string MinimumOrRecommended,
      int Index,
      bool ForVan)
    {
      int num1 = 0;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MinimumOrRecommended, "MinimumQuantity", false) == 0)
        num1 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(row["MinimumQuantity"], row["Amount"]), row["PacksOnOrder"]));
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MinimumOrRecommended, "RecommendedQuantity", false) == 0)
        num1 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(row["RecommendedQuantity"], row["Amount"]), row["PacksOnOrder"]));
      if (num1 <= 0)
        return;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      double num6 = 0.0;
      FRMSelectLocation frmSelectLocation = (FRMSelectLocation) App.ShowForm(typeof (FRMSelectLocation), true, new object[9]
      {
        row["PartID"],
        row["Item"],
        row["Location"],
        (object) num1,
        (object) this.warehouses,
        (object) this.vans,
        (object) this.lastSelectedType,
        (object) this.lastSelectedID,
        (object) ""
      }, false);
      if (frmSelectLocation == null)
        return;
      if (frmSelectLocation.DialogResult == DialogResult.OK)
      {
        num2 = frmSelectLocation.LocationID;
        num3 = frmSelectLocation.PartSupplierID;
        num4 = frmSelectLocation.InPack;
        num5 = frmSelectLocation.SupplierID;
        num6 = frmSelectLocation.Price;
      }
      frmSelectLocation.Dispose();
      if (num2 == 0 & num3 == 0)
      {
        int num7 = (int) App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "No location selected for the item : ", row["Item"]), (object) " at "), row["Location"])), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (num2 == 0)
      {
        int num8 = 0;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MinimumOrRecommended, "MinimumQuantity", false) == 0)
          num8 = Conversions.ToInteger(NewLateBinding.LateGet((object) null, typeof (Math), "Ceiling", new object[1]
          {
            Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(row["MinimumQuantity"], row["Amount"]), row["PacksOnOrder"]), (object) num4)
          }, (string[]) null, (System.Type[]) null, (bool[]) null));
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MinimumOrRecommended, "RecommendedQuantity", false) == 0)
          num8 = Conversions.ToInteger(NewLateBinding.LateGet((object) null, typeof (Math), "Ceiling", new object[1]
          {
            Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(row["RecommendedQuantity"], row["Amount"]), row["PacksOnOrder"]), (object) num4)
          }, (string[]) null, (System.Type[]) null, (bool[]) null));
        if (num8 <= 0)
        {
          int num9 = (int) App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "No order needed for the item : ", row["Item"]), (object) " at "), row["Location"])), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          DataRow row1 = !ForVan ? ((DataTable) ((ArrayList) this.warehouses[Index])[1]).NewRow() : ((DataTable) ((ArrayList) this.vans[Index])[1]).NewRow();
          row1["PartID"] = RuntimeHelpers.GetObjectValue(row["PartID"]);
          row1["PartSupplierID"] = (object) num3;
          row1["LocationID"] = (object) 0;
          row1["Quantity"] = (object) num8;
          row1["BuyPrice"] = (object) num6;
          row1["SupplierID"] = (object) num5;
          if (ForVan)
            ((DataTable) ((ArrayList) this.vans[Index])[1]).Rows.Add(row1);
          else
            ((DataTable) ((ArrayList) this.warehouses[Index])[1]).Rows.Add(row1);
          this.lastSelectedType = "Supplier";
          this.lastSelectedID = num3;
        }
      }
      else
      {
        DataRow row1 = !ForVan ? ((DataTable) ((ArrayList) this.warehouses[Index])[1]).NewRow() : ((DataTable) ((ArrayList) this.vans[Index])[1]).NewRow();
        row1["PartID"] = RuntimeHelpers.GetObjectValue(row["PartID"]);
        row1["PartSupplierID"] = (object) 0;
        row1["LocationID"] = (object) num2;
        row1["Quantity"] = (object) num1;
        row1["BuyPrice"] = (object) 0.0;
        row1["SupplierID"] = (object) 0;
        if (ForVan)
          ((DataTable) ((ArrayList) this.vans[Index])[1]).Rows.Add(row1);
        else
          ((DataTable) ((ArrayList) this.warehouses[Index])[1]).Rows.Add(row1);
        this.lastSelectedType = "Warehouse";
        this.lastSelectedID = num2;
      }
    }

    private string GetOrderReference(Enums.OrderType oOrderType)
    {
      JobNumber jobNumber = new JobNumber();
      JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.ORDER);
      nextJobNumber.OrderNumber = Conversions.ToString(nextJobNumber.JobNumber);
      while (nextJobNumber.OrderNumber.Length < 5)
        nextJobNumber.OrderNumber = "0" + nextJobNumber.OrderNumber;
      string str1 = "";
      switch (oOrderType)
      {
        case Enums.OrderType.Customer:
          str1 = "W";
          break;
        case Enums.OrderType.StockProfile:
          str1 = "V";
          break;
        case Enums.OrderType.Warehouse:
          str1 = "W";
          break;
      }
      string str2 = "";
      string[] strArray = App.loggedInUser.Fullname.Split(' ');
      int index = 0;
      while (index < strArray.Length)
      {
        string str3 = strArray[index];
        str2 += str3.Substring(0, 1);
        checked { ++index; }
      }
      return str2 + str1 + nextJobNumber.OrderNumber;
    }

    private void CreateOrders()
    {
      int num1 = 0;
      if (this.warehouses.Count == 0 & this.vans.Count == 0)
      {
        int num2 = (int) App.ShowMessage("No orders were needed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int index1 = checked (this.warehouses.Count - 1);
        while (index1 >= 0)
        {
          if (((DataTable) ((ArrayList) this.warehouses[index1])[1]).Rows.Count == 0)
          {
            this.warehouses.RemoveAt(index1);
          }
          else
          {
            ArrayList arrayList1 = new ArrayList();
            IEnumerator enumerator1;
            try
            {
              enumerator1 = ((DataTable) ((ArrayList) this.warehouses[index1])[1]).Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current = (DataRow) enumerator1.Current;
                if ((uint) Conversions.ToInteger(current["SupplierID"]) > 0U && !arrayList1.Contains((object) Conversions.ToInteger(current["SupplierID"])))
                  arrayList1.Add((object) Conversions.ToInteger(current["SupplierID"]));
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            int num3 = checked (arrayList1.Count - 1);
            int index2 = 0;
            while (index2 <= num3)
            {
              Order order = App.DB.Order.Insert(new Order()
              {
                IgnoreExceptionsOnSetMethods = true,
                DatePlaced = DateAndTime.Now,
                SetOrderTypeID = (object) 3,
                SetOrderReference = (object) this.GetOrderReference(Enums.OrderType.Warehouse),
                SetUserID = (object) App.loggedInUser.UserID,
                SetOrderStatusID = (object) 1,
                DeliveryDeadline = DateTime.MinValue,
                SetDoNotConsolidated = (object) true
              });
              checked { ++num1; }
              App.DB.OrderLocation.Insert(new OrderLocation()
              {
                SetOrderID = (object) order.OrderID,
                SetLocationID = RuntimeHelpers.GetObjectValue(App.DB.Warehouse.Warehouse_GetDV(Conversions.ToInteger(((ArrayList) this.warehouses[index1])[0])).Table.Rows[0]["LocationID"])
              });
              DataRow[] dataRowArray = ((DataTable) ((ArrayList) this.warehouses[index1])[1]).Select("SupplierID='" + Conversions.ToString(Conversions.ToInteger(arrayList1[index2])) + "'");
              int num4 = checked (dataRowArray.Length - 1);
              int index3 = 0;
              while (index3 <= num4)
              {
                DataRow dataRow = dataRowArray[index3];
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["LocationID"], (object) 0, false))
                  App.DB.OrderPart.Insert(new OrderPart()
                  {
                    IgnoreExceptionsOnSetMethods = true,
                    SetOrderID = (object) order.OrderID,
                    SetPartSupplierID = RuntimeHelpers.GetObjectValue(dataRow["PartSupplierID"]),
                    SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["Quantity"]),
                    SetBuyPrice = RuntimeHelpers.GetObjectValue(dataRow["BuyPrice"]),
                    SetSellPrice = (object) 0.0,
                    SetQuantityReceived = (object) 0
                  }, !order.DoNotConsolidated);
                checked { ++index3; }
              }
              checked { ++index2; }
            }
            ArrayList arrayList2 = new ArrayList();
            IEnumerator enumerator2;
            try
            {
              enumerator2 = ((DataTable) ((ArrayList) this.warehouses[index1])[1]).Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current = (DataRow) enumerator2.Current;
                if ((uint) Conversions.ToInteger(current["LocationID"]) > 0U && !arrayList2.Contains((object) Conversions.ToInteger(current["LocationID"])))
                  arrayList2.Add((object) Conversions.ToInteger(current["LocationID"]));
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            int num5 = checked (arrayList2.Count - 1);
            int index4 = 0;
            while (index4 <= num5)
            {
              Order order = App.DB.Order.Insert(new Order()
              {
                IgnoreExceptionsOnSetMethods = true,
                DatePlaced = DateAndTime.Now,
                SetOrderTypeID = (object) 3,
                SetOrderReference = (object) this.GetOrderReference(Enums.OrderType.Warehouse),
                SetUserID = (object) App.loggedInUser.UserID,
                SetOrderStatusID = (object) 1,
                DeliveryDeadline = DateTime.MinValue
              });
              checked { ++num1; }
              App.DB.OrderLocation.Insert(new OrderLocation()
              {
                SetOrderID = (object) order.OrderID,
                SetLocationID = RuntimeHelpers.GetObjectValue(App.DB.Warehouse.Warehouse_GetDV(Conversions.ToInteger(((ArrayList) this.warehouses[index1])[0])).Table.Rows[0]["LocationID"])
              });
              DataRow[] dataRowArray = ((DataTable) ((ArrayList) this.warehouses[index1])[1]).Select("LocationID='" + Conversions.ToString(Conversions.ToInteger(arrayList2[index4])) + "'");
              int num4 = checked (dataRowArray.Length - 1);
              int index3 = 0;
              while (index3 <= num4)
              {
                DataRow dataRow = dataRowArray[index3];
                if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRow["LocationID"], (object) 0, false))))
                {
                  FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart = App.DB.OrderLocationPart.Insert(new FSM.Entity.OrderLocationPart.OrderLocationPart()
                  {
                    IgnoreExceptionsOnSetMethods = true,
                    SetOrderID = (object) order.OrderID,
                    SetPartID = RuntimeHelpers.GetObjectValue(dataRow["PartID"]),
                    SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["LocationID"]),
                    SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["Quantity"]),
                    SetSellPrice = (object) 0.0,
                    SetQuantityReceived = (object) 0
                  }, true);
                  App.DB.PartTransaction.Insert(new PartTransaction()
                  {
                    IgnoreExceptionsOnSetMethods = true,
                    SetOrderLocationPartID = (object) orderLocationPart.OrderLocationPartID,
                    SetTransactionTypeID = (object) 5,
                    SetPartID = (object) orderLocationPart.PartID,
                    SetAmount = (object) checked (-orderLocationPart.Quantity),
                    SetLocationID = (object) orderLocationPart.LocationID
                  });
                }
                checked { ++index3; }
              }
              checked { ++index4; }
            }
          }
          checked { index1 += -1; }
        }
        int index5 = checked (this.vans.Count - 1);
        while (index5 >= 0)
        {
          if (((DataTable) ((ArrayList) this.vans[index5])[1]).Rows.Count == 0)
          {
            this.vans.RemoveAt(index5);
          }
          else
          {
            ArrayList arrayList1 = new ArrayList();
            IEnumerator enumerator1;
            try
            {
              enumerator1 = ((DataTable) ((ArrayList) this.vans[index5])[1]).Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current = (DataRow) enumerator1.Current;
                if ((uint) Conversions.ToInteger(current["SupplierID"]) > 0U && !arrayList1.Contains((object) Conversions.ToInteger(current["SupplierID"])))
                  arrayList1.Add((object) Conversions.ToInteger(current["SupplierID"]));
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            int num3 = checked (arrayList1.Count - 1);
            int index2 = 0;
            while (index2 <= num3)
            {
              Order order = App.DB.Order.Insert(new Order()
              {
                IgnoreExceptionsOnSetMethods = true,
                DatePlaced = DateAndTime.Now,
                SetOrderTypeID = (object) 2,
                SetOrderReference = (object) this.GetOrderReference(Enums.OrderType.StockProfile),
                SetUserID = (object) App.loggedInUser.UserID,
                SetOrderStatusID = (object) 1,
                DeliveryDeadline = DateTime.MinValue
              });
              checked { ++num1; }
              App.DB.OrderLocation.Insert(new OrderLocation()
              {
                SetOrderID = (object) order.OrderID,
                SetLocationID = RuntimeHelpers.GetObjectValue(App.DB.Van.Van_GetDV(Conversions.ToInteger(((ArrayList) this.vans[index5])[0])).Table.Rows[0]["LocationID"])
              });
              DataRow[] dataRowArray = ((DataTable) ((ArrayList) this.vans[index5])[1]).Select("SupplierID='" + Conversions.ToString(Conversions.ToInteger(arrayList1[index2])) + "'");
              int num4 = checked (dataRowArray.Length - 1);
              int index3 = 0;
              while (index3 <= num4)
              {
                DataRow dataRow = dataRowArray[index3];
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["LocationID"], (object) 0, false))
                  App.DB.OrderPart.Insert(new OrderPart()
                  {
                    IgnoreExceptionsOnSetMethods = true,
                    SetOrderID = (object) order.OrderID,
                    SetPartSupplierID = RuntimeHelpers.GetObjectValue(dataRow["PartSupplierID"]),
                    SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["Quantity"]),
                    SetBuyPrice = RuntimeHelpers.GetObjectValue(dataRow["BuyPrice"]),
                    SetSellPrice = (object) 0.0,
                    SetQuantityReceived = (object) 0
                  }, !order.DoNotConsolidated);
                checked { ++index3; }
              }
              checked { ++index2; }
            }
            ArrayList arrayList2 = new ArrayList();
            IEnumerator enumerator2;
            try
            {
              enumerator2 = ((DataTable) ((ArrayList) this.vans[index5])[1]).Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current = (DataRow) enumerator2.Current;
                if ((uint) Conversions.ToInteger(current["LocationID"]) > 0U && !arrayList2.Contains((object) Conversions.ToInteger(current["LocationID"])))
                  arrayList2.Add((object) Conversions.ToInteger(current["LocationID"]));
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            int num5 = checked (arrayList2.Count - 1);
            int index4 = 0;
            while (index4 <= num5)
            {
              Order order = App.DB.Order.Insert(new Order()
              {
                IgnoreExceptionsOnSetMethods = true,
                DatePlaced = DateAndTime.Now,
                SetOrderTypeID = (object) 2,
                SetOrderReference = (object) this.GetOrderReference(Enums.OrderType.StockProfile),
                SetUserID = (object) App.loggedInUser.UserID,
                SetOrderStatusID = (object) 1,
                DeliveryDeadline = DateTime.MinValue
              });
              checked { ++num1; }
              App.DB.OrderLocation.Insert(new OrderLocation()
              {
                SetOrderID = (object) order.OrderID,
                SetLocationID = RuntimeHelpers.GetObjectValue(App.DB.Van.Van_GetDV(Conversions.ToInteger(((ArrayList) this.vans[index5])[0])).Table.Rows[0]["LocationID"])
              });
              DataRow[] dataRowArray = ((DataTable) ((ArrayList) this.vans[index5])[1]).Select("LocationID='" + Conversions.ToString(Conversions.ToInteger(arrayList2[index4])) + "'");
              int num4 = checked (dataRowArray.Length - 1);
              int index3 = 0;
              while (index3 <= num4)
              {
                DataRow dataRow = dataRowArray[index3];
                if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRow["LocationID"], (object) 0, false))))
                {
                  FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart = App.DB.OrderLocationPart.Insert(new FSM.Entity.OrderLocationPart.OrderLocationPart()
                  {
                    IgnoreExceptionsOnSetMethods = true,
                    SetOrderID = (object) order.OrderID,
                    SetPartID = RuntimeHelpers.GetObjectValue(dataRow["PartID"]),
                    SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["LocationID"]),
                    SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["Quantity"]),
                    SetSellPrice = (object) 0.0,
                    SetQuantityReceived = (object) 0
                  }, true);
                  App.DB.PartTransaction.Insert(new PartTransaction()
                  {
                    IgnoreExceptionsOnSetMethods = true,
                    SetOrderLocationPartID = (object) orderLocationPart.OrderLocationPartID,
                    SetTransactionTypeID = (object) 5,
                    SetPartID = (object) orderLocationPart.PartID,
                    SetAmount = (object) checked (-orderLocationPart.Quantity),
                    SetLocationID = (object) orderLocationPart.LocationID
                  });
                }
                checked { ++index3; }
              }
              checked { ++index4; }
            }
          }
          checked { index5 += -1; }
        }
        int num6 = (int) App.ShowMessage(Conversions.ToString(num1) + " orders created", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        if (num1 > 0)
          this.Filter();
      }
    }
  }
}
