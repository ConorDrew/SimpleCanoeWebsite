// Decompiled with JetBrains decompiler
// Type: FSM.TabletOrder
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Business.Orders;
using FSM.Entity.EngineerVisitOrders;
using FSM.Entity.EngineerVisits;
using FSM.Entity.JobAudits;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.OrderParts;
using FSM.Entity.Orders;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class TabletOrder : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _partsDataView;
    private DataView _searchDataView;
    private int SupplierID;
    private JobNumber _OrderNumber;
    private int _engineerVisitID;
    private int _engineerID;
    private DataTable PartsList;

    public TabletOrder()
    {
      this.Load += new EventHandler(this.TabletOrder_Load);
      this.Load += new EventHandler(this.FrmPartSearch_Load);
      this.SupplierID = 0;
      this._OrderNumber = new JobNumber();
      this.PartsList = new DataTable();
      this.InitializeComponent();
      if (true == App.IsGasway)
      {
        ComboBox cboCostCentre = this.cboCostCentre;
        Combo.SetUpCombo(ref cboCostCentre, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
        this.cboCostCentre = cboCostCentre;
      }
      else
      {
        ComboBox cboCostCentre = this.cboCostCentre;
        Combo.SetUpCombo(ref cboCostCentre, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
        this.cboCostCentre = cboCostCentre;
      }
    }

    public TabletOrder(SqlTransaction trans)
    {
      this.Load += new EventHandler(this.TabletOrder_Load);
      this.Load += new EventHandler(this.FrmPartSearch_Load);
      this.SupplierID = 0;
      this._OrderNumber = new JobNumber();
      this.PartsList = new DataTable();
      this.InitializeComponent();
    }

    public TabletOrder(int EngineerIDin)
    {
      this.Load += new EventHandler(this.TabletOrder_Load);
      this.Load += new EventHandler(this.FrmPartSearch_Load);
      this.SupplierID = 0;
      this._OrderNumber = new JobNumber();
      this.PartsList = new DataTable();
      this.InitializeComponent();
      this.EngineerID = EngineerIDin;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnFindPart
    {
      get
      {
        return this._btnFindPart;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindPart_Click);
        Button btnFindPart1 = this._btnFindPart;
        if (btnFindPart1 != null)
          btnFindPart1.Click -= eventHandler;
        this._btnFindPart = value;
        Button btnFindPart2 = this._btnFindPart;
        if (btnFindPart2 == null)
          return;
        btnFindPart2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtPartSearch
    {
      get
      {
        return this._txtPartSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtPartSearch_KeyDown);
        TextBox txtPartSearch1 = this._txtPartSearch;
        if (txtPartSearch1 != null)
          txtPartSearch1.KeyDown -= keyEventHandler;
        this._txtPartSearch = value;
        TextBox txtPartSearch2 = this._txtPartSearch;
        if (txtPartSearch2 == null)
          return;
        txtPartSearch2.KeyDown += keyEventHandler;
      }
    }

    internal virtual Label lblQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCreate
    {
      get
      {
        return this._btnCreate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCreate_Click);
        Button btnCreate1 = this._btnCreate;
        if (btnCreate1 != null)
          btnCreate1.Click -= eventHandler;
        this._btnCreate = value;
        Button btnCreate2 = this._btnCreate;
        if (btnCreate2 == null)
          return;
        btnCreate2.Click += eventHandler;
      }
    }

    internal virtual Label lblSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual NumericUpDown nudQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTopLabel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddPart
    {
      get
      {
        return this._btnAddPart;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddPart_Click);
        Button btnAddPart1 = this._btnAddPart;
        if (btnAddPart1 != null)
          btnAddPart1.Click -= eventHandler;
        this._btnAddPart = value;
        Button btnAddPart2 = this._btnAddPart;
        if (btnAddPart2 == null)
          return;
        btnAddPart2.Click += eventHandler;
      }
    }

    internal virtual RadioButton rbNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rbYes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnBack
    {
      get
      {
        return this._btnBack;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnBack_Click);
        Button btnBack1 = this._btnBack;
        if (btnBack1 != null)
          btnBack1.Click -= eventHandler;
        this._btnBack = value;
        Button btnBack2 = this._btnBack;
        if (btnBack2 == null)
          return;
        btnBack2.Click += eventHandler;
      }
    }

    internal virtual Panel pnlFilters { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgvSearch
    {
      get
      {
        return this._dgvSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DataGridViewCellEventHandler cellEventHandler1 = new DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
        DataGridViewCellEventHandler cellEventHandler2 = new DataGridViewCellEventHandler(this.btnAddPart_Click);
        DataGridView dgvSearch1 = this._dgvSearch;
        if (dgvSearch1 != null)
        {
          dgvSearch1.CellClick -= cellEventHandler1;
          dgvSearch1.CellDoubleClick -= cellEventHandler2;
        }
        this._dgvSearch = value;
        DataGridView dgvSearch2 = this._dgvSearch;
        if (dgvSearch2 == null)
          return;
        dgvSearch2.CellClick += cellEventHandler1;
        dgvSearch2.CellDoubleClick += cellEventHandler2;
      }
    }

    internal virtual TextBox txtSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCostCentre { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCostCentre { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNewOrderNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDatePlaced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnFindPart = new Button();
      this.txtPartSearch = new TextBox();
      this.lblQty = new Label();
      this.btnCreate = new Button();
      this.lblSearch = new Label();
      this.lblSupplier = new Label();
      this.nudQty = new NumericUpDown();
      this.dgParts = new DataGridView();
      this.lblTopLabel = new Label();
      this.btnAddPart = new Button();
      this.rbNo = new RadioButton();
      this.rbYes = new RadioButton();
      this.btnBack = new Button();
      this.pnlFilters = new Panel();
      this.dtpDatePlaced = new DateTimePicker();
      this.lblDate = new Label();
      this.cboCostCentre = new ComboBox();
      this.lblCostCentre = new Label();
      this.txtSupplier = new TextBox();
      this.dgvSearch = new DataGridView();
      this.txtNewOrderNumber = new TextBox();
      this.nudQty.BeginInit();
      ((ISupportInitialize) this.dgParts).BeginInit();
      this.pnlFilters.SuspendLayout();
      ((ISupportInitialize) this.dgvSearch).BeginInit();
      this.SuspendLayout();
      this.btnFindPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnFindPart.Location = new System.Drawing.Point(856, 105);
      this.btnFindPart.Name = "btnFindPart";
      this.btnFindPart.Size = new Size(145, 34);
      this.btnFindPart.TabIndex = 13;
      this.btnFindPart.Text = "Find";
      this.btnFindPart.UseVisualStyleBackColor = true;
      this.txtPartSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPartSearch.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPartSearch.Location = new System.Drawing.Point(321, 62);
      this.txtPartSearch.Name = "txtPartSearch";
      this.txtPartSearch.Size = new Size(680, 29);
      this.txtPartSearch.TabIndex = 2;
      this.lblQty.Font = new Font("Verdana", 9f);
      this.lblQty.ForeColor = Color.FromArgb(0, 0, 192);
      this.lblQty.Location = new System.Drawing.Point(4, 67);
      this.lblQty.Name = "lblQty";
      this.lblQty.Size = new Size(120, 21);
      this.lblQty.TabIndex = 19;
      this.lblQty.Text = "Qty";
      this.btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCreate.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnCreate.Location = new System.Drawing.Point(857, 552);
      this.btnCreate.Name = "btnCreate";
      this.btnCreate.Size = new Size(146, 40);
      this.btnCreate.TabIndex = 130;
      this.btnCreate.Text = "Create Order";
      this.btnCreate.UseVisualStyleBackColor = true;
      this.lblSearch.Font = new Font("Verdana", 9f);
      this.lblSearch.ForeColor = Color.FromArgb(0, 0, 192);
      this.lblSearch.Location = new System.Drawing.Point(249, 67);
      this.lblSearch.Name = "lblSearch";
      this.lblSearch.Size = new Size(67, 21);
      this.lblSearch.TabIndex = 20;
      this.lblSearch.Text = "Search";
      this.lblSupplier.Font = new Font("Verdana", 9f);
      this.lblSupplier.ForeColor = Color.FromArgb(0, 0, 192);
      this.lblSupplier.Location = new System.Drawing.Point(4, 22);
      this.lblSupplier.Name = "lblSupplier";
      this.lblSupplier.Size = new Size(120, 21);
      this.lblSupplier.TabIndex = 18;
      this.lblSupplier.Text = "Supplier";
      this.nudQty.BackColor = Color.White;
      this.nudQty.Font = new Font("Verdana", 16f);
      this.nudQty.Location = new System.Drawing.Point(130, 61);
      this.nudQty.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.nudQty.Name = "nudQty";
      this.nudQty.Size = new Size(112, 33);
      this.nudQty.TabIndex = 9;
      this.nudQty.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.dgParts.AllowUserToAddRows = false;
      this.dgParts.AllowUserToDeleteRows = false;
      this.dgParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgParts.Location = new System.Drawing.Point(13, 413);
      this.dgParts.Name = "dgParts";
      this.dgParts.Size = new Size(990, 133);
      this.dgParts.TabIndex = 133;
      this.lblTopLabel.AutoSize = true;
      this.lblTopLabel.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTopLabel.Location = new System.Drawing.Point(17, 50);
      this.lblTopLabel.Name = "lblTopLabel";
      this.lblTopLabel.Size = new Size(539, 24);
      this.lblTopLabel.TabIndex = 132;
      this.lblTopLabel.Text = "Are these parts to be fitted on this visit?  (NO creates a new visit)";
      this.btnAddPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddPart.Enabled = false;
      this.btnAddPart.Location = new System.Drawing.Point(857, 372);
      this.btnAddPart.Name = "btnAddPart";
      this.btnAddPart.Size = new Size(146, 34);
      this.btnAddPart.TabIndex = 124;
      this.btnAddPart.Text = "Add";
      this.btnAddPart.UseVisualStyleBackColor = true;
      this.rbNo.AutoSize = true;
      this.rbNo.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rbNo.Location = new System.Drawing.Point(949, 49);
      this.rbNo.Name = "rbNo";
      this.rbNo.Size = new Size(53, 28);
      this.rbNo.TabIndex = (int) sbyte.MaxValue;
      this.rbNo.TabStop = true;
      this.rbNo.Text = "No";
      this.rbNo.UseVisualStyleBackColor = true;
      this.rbYes.AutoSize = true;
      this.rbYes.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rbYes.Location = new System.Drawing.Point(836, 50);
      this.rbYes.Name = "rbYes";
      this.rbYes.Size = new Size(60, 28);
      this.rbYes.TabIndex = 126;
      this.rbYes.TabStop = true;
      this.rbYes.Text = "Yes";
      this.rbYes.UseVisualStyleBackColor = true;
      this.btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnBack.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnBack.Location = new System.Drawing.Point(12, 552);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new Size(146, 40);
      this.btnBack.TabIndex = 125;
      this.btnBack.Text = "Close";
      this.btnBack.UseVisualStyleBackColor = true;
      this.pnlFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlFilters.BackColor = SystemColors.Info;
      this.pnlFilters.Controls.Add((Control) this.dtpDatePlaced);
      this.pnlFilters.Controls.Add((Control) this.lblDate);
      this.pnlFilters.Controls.Add((Control) this.cboCostCentre);
      this.pnlFilters.Controls.Add((Control) this.lblCostCentre);
      this.pnlFilters.Controls.Add((Control) this.txtSupplier);
      this.pnlFilters.Controls.Add((Control) this.lblSearch);
      this.pnlFilters.Controls.Add((Control) this.lblSupplier);
      this.pnlFilters.Controls.Add((Control) this.btnFindPart);
      this.pnlFilters.Controls.Add((Control) this.txtPartSearch);
      this.pnlFilters.Controls.Add((Control) this.nudQty);
      this.pnlFilters.Controls.Add((Control) this.lblQty);
      this.pnlFilters.Location = new System.Drawing.Point(1, 91);
      this.pnlFilters.Name = "pnlFilters";
      this.pnlFilters.Size = new Size(1013, 145);
      this.pnlFilters.TabIndex = 123;
      this.dtpDatePlaced.Location = new System.Drawing.Point(130, 105);
      this.dtpDatePlaced.Name = "dtpDatePlaced";
      this.dtpDatePlaced.Size = new Size(702, 21);
      this.dtpDatePlaced.TabIndex = 25;
      this.lblDate.Font = new Font("Verdana", 9f);
      this.lblDate.ForeColor = Color.FromArgb(0, 0, 192);
      this.lblDate.Location = new System.Drawing.Point(4, 110);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new Size(120, 21);
      this.lblDate.TabIndex = 24;
      this.lblDate.Text = "Date Placed";
      this.cboCostCentre.FormattingEnabled = true;
      this.cboCostCentre.Location = new System.Drawing.Point(764, 29);
      this.cboCostCentre.Name = "cboCostCentre";
      this.cboCostCentre.Size = new Size(237, 21);
      this.cboCostCentre.TabIndex = 23;
      this.lblCostCentre.Font = new Font("Verdana", 9f);
      this.lblCostCentre.ForeColor = Color.FromArgb(0, 0, 192);
      this.lblCostCentre.Location = new System.Drawing.Point(761, 12);
      this.lblCostCentre.Name = "lblCostCentre";
      this.lblCostCentre.Size = new Size(89, 21);
      this.lblCostCentre.TabIndex = 22;
      this.lblCostCentre.Text = "Cost Centre:";
      this.txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSupplier.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSupplier.Location = new System.Drawing.Point(130, 21);
      this.txtSupplier.Name = "txtSupplier";
      this.txtSupplier.ReadOnly = true;
      this.txtSupplier.Size = new Size(625, 29);
      this.txtSupplier.TabIndex = 21;
      this.dgvSearch.AllowUserToAddRows = false;
      this.dgvSearch.AllowUserToDeleteRows = false;
      this.dgvSearch.AllowUserToResizeRows = false;
      this.dgvSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.dgvSearch.Location = new System.Drawing.Point(12, 242);
      this.dgvSearch.MultiSelect = false;
      this.dgvSearch.Name = "dgvSearch";
      this.dgvSearch.ReadOnly = true;
      this.dgvSearch.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvSearch.ShowCellErrors = false;
      this.dgvSearch.ShowCellToolTips = false;
      this.dgvSearch.ShowEditingIcon = false;
      this.dgvSearch.ShowRowErrors = false;
      this.dgvSearch.Size = new Size(839, 165);
      this.dgvSearch.TabIndex = 134;
      this.txtNewOrderNumber.BackColor = Color.White;
      this.txtNewOrderNumber.BorderStyle = BorderStyle.None;
      this.txtNewOrderNumber.Font = new Font("Verdana", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtNewOrderNumber.ForeColor = Color.Red;
      this.txtNewOrderNumber.Location = new System.Drawing.Point(243, 563);
      this.txtNewOrderNumber.Name = "txtNewOrderNumber";
      this.txtNewOrderNumber.ReadOnly = true;
      this.txtNewOrderNumber.Size = new Size(543, 20);
      this.txtNewOrderNumber.TabIndex = 135;
      this.txtNewOrderNumber.Text = "Your order number will be displayed here once created.";
      this.txtNewOrderNumber.TextAlign = HorizontalAlignment.Center;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1014, 608);
      this.ControlBox = false;
      this.Controls.Add((Control) this.txtNewOrderNumber);
      this.Controls.Add((Control) this.dgvSearch);
      this.Controls.Add((Control) this.btnCreate);
      this.Controls.Add((Control) this.dgParts);
      this.Controls.Add((Control) this.lblTopLabel);
      this.Controls.Add((Control) this.btnAddPart);
      this.Controls.Add((Control) this.rbNo);
      this.Controls.Add((Control) this.rbYes);
      this.Controls.Add((Control) this.btnBack);
      this.Controls.Add((Control) this.pnlFilters);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(1030, 647);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(1030, 647);
      this.Name = nameof (TabletOrder);
      this.Text = "Part Search";
      this.Controls.SetChildIndex((Control) this.pnlFilters, 0);
      this.Controls.SetChildIndex((Control) this.btnBack, 0);
      this.Controls.SetChildIndex((Control) this.rbYes, 0);
      this.Controls.SetChildIndex((Control) this.rbNo, 0);
      this.Controls.SetChildIndex((Control) this.btnAddPart, 0);
      this.Controls.SetChildIndex((Control) this.lblTopLabel, 0);
      this.Controls.SetChildIndex((Control) this.dgParts, 0);
      this.Controls.SetChildIndex((Control) this.btnCreate, 0);
      this.Controls.SetChildIndex((Control) this.dgvSearch, 0);
      this.Controls.SetChildIndex((Control) this.txtNewOrderNumber, 0);
      this.nudQty.EndInit();
      ((ISupportInitialize) this.dgParts).EndInit();
      this.pnlFilters.ResumeLayout(false);
      this.pnlFilters.PerformLayout();
      ((ISupportInitialize) this.dgvSearch).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
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

    private void SetupDataTable()
    {
      this.PartsList.Columns.Add("PartSupplierID");
      this.PartsList.Columns.Add("SPN");
      this.PartsList.Columns.Add("Description");
      this.PartsList.Columns.Add("Qty");
      this.PartsList.Columns.Add("Supplier");
      this.PartsList.Columns.Add("PartID");
      this.PartsList.Columns.Add("Price");
      this.PartsList.Columns.Add("IsSpecialPart");
    }

    private void SetupPartsDataGrid()
    {
      try
      {
        DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn1.HeaderText = "PartSupplierID";
        viewTextBoxColumn1.DataPropertyName = "PartSupplierID";
        viewTextBoxColumn1.Visible = false;
        viewTextBoxColumn1.Width = 10;
        this.dgParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
        DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn2.HeaderText = "PartID";
        viewTextBoxColumn2.DataPropertyName = "PartID";
        viewTextBoxColumn2.Visible = false;
        viewTextBoxColumn2.Width = 10;
        this.dgParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
        DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn3.HeaderText = "SPN";
        viewTextBoxColumn3.DataPropertyName = "SPN";
        viewTextBoxColumn3.Width = 200;
        this.dgParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
        viewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn4.HeaderText = "Description";
        viewTextBoxColumn4.DataPropertyName = "Description";
        this.dgParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
        viewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        viewTextBoxColumn4.Width = 300;
        DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn5.HeaderText = "Qty";
        viewTextBoxColumn5.DataPropertyName = "Qty";
        viewTextBoxColumn5.Width = 70;
        this.dgParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
        viewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        viewTextBoxColumn5.Width = 70;
        DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn6.HeaderText = "Buy Price";
        viewTextBoxColumn6.DataPropertyName = "Price";
        viewTextBoxColumn6.Width = 70;
        this.dgParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
        viewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        viewTextBoxColumn5.Width = 70;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
    }

    private void SetupSearchDataGrid()
    {
      try
      {
        this.dgvSearch.AutoGenerateColumns = false;
        DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn1.HeaderText = "PartSupplierID";
        viewTextBoxColumn1.DataPropertyName = "PartSupplierID";
        viewTextBoxColumn1.Width = 10;
        this.dgvSearch.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
        viewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        viewTextBoxColumn1.Visible = false;
        DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn2.HeaderText = "IsSpecialPart";
        viewTextBoxColumn2.DataPropertyName = "IsSpecialPart";
        viewTextBoxColumn2.Width = 10;
        this.dgvSearch.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
        viewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        viewTextBoxColumn2.Visible = false;
        DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn3.HeaderText = "SupplierID";
        viewTextBoxColumn3.DataPropertyName = "SupplierID";
        viewTextBoxColumn3.Name = "SupplierID";
        viewTextBoxColumn3.Visible = true;
        viewTextBoxColumn3.Width = 5;
        this.dgvSearch.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
        DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn4.HeaderText = "Supplier";
        viewTextBoxColumn4.DataPropertyName = "Supplier";
        viewTextBoxColumn4.Visible = true;
        viewTextBoxColumn4.Width = 120;
        this.dgvSearch.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
        DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn5.HeaderText = "SPN";
        viewTextBoxColumn5.DataPropertyName = "PartCode";
        viewTextBoxColumn5.Width = 80;
        this.dgvSearch.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
        viewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn6.HeaderText = "Number";
        viewTextBoxColumn6.DataPropertyName = "Number";
        viewTextBoxColumn6.Width = 80;
        this.dgvSearch.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
        DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn7.HeaderText = "Description";
        viewTextBoxColumn7.DataPropertyName = "Name";
        viewTextBoxColumn7.Width = 400;
        this.dgvSearch.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
        DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
        viewTextBoxColumn8.HeaderText = "Buy Price";
        viewTextBoxColumn8.DataPropertyName = "price";
        viewTextBoxColumn8.Width = 80;
        this.dgvSearch.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
    }

    private DataView PartsDataView
    {
      get
      {
        return this._partsDataView;
      }
      set
      {
        if (value != null)
        {
          this._partsDataView = value;
          this._partsDataView.Table.TableName = "tblPart";
        }
        this.dgParts.DataSource = (object) this._partsDataView;
      }
    }

    public DataRow SelectedPartsRow
    {
      get
      {
        return this.PartsDataView != null && this.PartsDataView.Table.Rows.Count > 0 ? this.PartsDataView[this.dgParts.CurrentRow.Index].Row : (DataRow) null;
      }
    }

    private DataView SearchDataView
    {
      get
      {
        return this._searchDataView;
      }
      set
      {
        if (value != null)
        {
          this._searchDataView = value;
          this._searchDataView.Table.TableName = "tblSearch";
        }
        this.dgvSearch.DataSource = (object) this._searchDataView;
      }
    }

    public DataRow SelectedSearchRow
    {
      get
      {
        return this.SearchDataView != null && this.SearchDataView.Table.Rows.Count > 0 ? this.SearchDataView[this.dgvSearch.CurrentRow.Index].Row : (DataRow) null;
      }
    }

    public JobNumber OrderNumber
    {
      get
      {
        return this._OrderNumber;
      }
      set
      {
        this._OrderNumber = value;
        this._OrderNumber.OrderNumber = Conversions.ToString(this.OrderNumber.JobNumber);
        while (this.OrderNumber.OrderNumber.Length < 5)
          this._OrderNumber.OrderNumber = "0" + this.OrderNumber.OrderNumber;
        string str1 = "V";
        string str2 = "";
        string[] strArray = App.loggedInUser.Fullname.Split(' ');
        int index = 0;
        while (index < strArray.Length)
        {
          string str3 = strArray[index];
          str2 += str3.Substring(0, 1);
          checked { ++index; }
        }
        this._OrderNumber.OrderNumber = str2 + str1 + this.OrderNumber.OrderNumber;
      }
    }

    public int EngineerVisitID
    {
      get
      {
        return this._engineerVisitID;
      }
      set
      {
        this._engineerVisitID = value;
      }
    }

    public int EngineerID
    {
      get
      {
        return this._engineerID;
      }
      set
      {
        this._engineerID = value;
      }
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
      if (!this.rbNo.Checked & !this.rbYes.Checked)
      {
        int num1 = (int) App.ShowMessage("You must select the visit option to be able to create an order.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (this.PartsList.Rows.Count == 0)
      {
        int num2 = (int) App.ShowMessage("You must select a part to create an order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        string str1 = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboCostCentre));
        if (Helper.IsValidInteger((object) str1) && Helper.MakeIntegerValid((object) str1) <= 0)
        {
          int num3 = (int) App.ShowMessage("You need to enter a department to create an order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          JobAudit jobAudit = new JobAudit();
          new SqlCommand().CommandType = CommandType.StoredProcedure;
          Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisitID);
          string str2 = Conversions.ToString(anEngineerVisitId.JobID);
          int jobTypeId = anEngineerVisitId.JobTypeID;
          int propertyId = anEngineerVisitId.PropertyID;
          if (this.rbNo.Checked)
          {
            if (jobTypeId == 519)
            {
              JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout);
              string str3 = Conversions.ToString(nextJobNumber.JobNumber);
              string str4 = nextJobNumber.Prefix + str3;
              str2 = Conversions.ToString(App.DB.Job.Insert(new Job()
              {
                SetPropertyID = (object) propertyId,
                SetJobDefinitionEnumID = (object) Enums.JobDefinition.Callout,
                SetJobTypeID = (object) 4703,
                SetCreatedByUserID = (object) App.loggedInUser.UserID,
                SetJobNumber = (object) str4,
                SetPONumber = (object) null,
                SetQuoteID = (object) 0,
                SetContractID = (object) 0,
                SetToBePartPaid = (object) false,
                SetRetention = (object) 0,
                SetCollectPayment = (object) false,
                SetPOC = (object) false,
                SetOTI = (object) false,
                SetFOC = (object) false,
                SetDeleted = false
              }).JobID);
              string str5 = "New Job Inserted (By User " + App.loggedInUser.Fullname.ToString() + ") - JobNumber: " + str4 + " (Unique Job ID: " + str2 + ")";
              App.DB.JobAudit.Insert(new JobAudit()
              {
                SetJobID = (object) str2,
                SetActionChange = (object) str5
              });
            }
            SqlConnection sqlConnection = new SqlConnection(App.DB.ServerConnectionString);
            sqlConnection.Open();
            SqlTransaction trans = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
            int jobOfWorkId = App.DB.JobOfWorks.Insert(new JobOfWork()
            {
              SetJobID = (object) str2,
              SetDeleted = false,
              SetPONumber = (object) "",
              SetStatus = (object) 1,
              SetPriority = (object) null
            }, trans).JobOfWorkID;
            trans.Commit();
            sqlConnection.Close();
            this.EngineerVisitID = App.DB.EngineerVisits.Insert(new EngineerVisit()
            {
              SetJobOfWorkID = (object) jobOfWorkId,
              SetEngineerID = (object) 0,
              SetStatusEnumID = (object) 4,
              SetNotesFromEngineer = (object) "Created for Tablet from Head Office",
              SetPartsToFit = (object) 1,
              SetExpectedEngineerID = (object) 0,
              SetRecharge = (object) 0,
              SetDeleted = false,
              SetAMPM = (object) null
            }, Conversions.ToInteger(str2), 0, 0).EngineerVisitID;
            string str6 = "New Visit Inserted (By User " + App.loggedInUser.Fullname + ") - Status: NOT SET (Unique Visit ID: " + Conversions.ToString(this.EngineerVisitID) + ")";
            App.DB.JobAudit.Insert(new JobAudit()
            {
              SetJobID = (object) str2,
              SetActionChange = (object) str6
            });
          }
          else
          {
            EngineerVisit asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(this.EngineerVisitID, true);
            if (asObject != null)
            {
              asObject.SetPartsToFit = (object) true;
              App.DB.EngineerVisits.Update(asObject, Conversions.ToInteger(str2), true);
            }
          }
          Order oOrder = new Order();
          oOrder.IgnoreExceptionsOnSetMethods = true;
          oOrder.SetSentToSage = (object) false;
          oOrder.SetOrderID = (object) 0;
          oOrder.DatePlaced = DateAndTime.Now;
          oOrder.SetOrderTypeID = (object) 4;
          oOrder.SetUserID = (object) App.loggedInUser.UserID;
          oOrder.SetOrderStatusID = (object) 2;
          oOrder.DeliveryDeadline = DateTime.MinValue;
          oOrder.SupplierInvoiceDate = DateTime.MinValue;
          this.OrderNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.ORDER);
          oOrder.SetDepartmentRef = (object) str1;
          oOrder.SetDoNotConsolidated = (object) true;
          oOrder.DatePlaced = this.dtpDatePlaced.Value;
          oOrder.SetOrderReference = (object) this.OrderNumber.OrderNumber;
          if (App.DB.Customer.Customer_Get_ForSiteID(anEngineerVisitId.PropertyID).IsPFH && App.DB.Supplier.Supplier_GetSecondaryPrice(this.SupplierID))
            oOrder.SetOrderReference = (object) (this.OrderNumber.OrderNumber + "F");
          Order order = App.DB.Order.Insert(oOrder);
          EngineerVisitOrder oEngineerVisitOrder = new EngineerVisitOrder();
          oEngineerVisitOrder.SetOrderID = (object) order.OrderID;
          oEngineerVisitOrder.SetEngineerVisitID = (object) this.EngineerVisitID;
          App.DB.EngineerVisitOrder.EngineerVisitOrder_DeleteForOrder(order.OrderID);
          App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder);
          IEnumerator enumerator;
          try
          {
            enumerator = this.PartsList.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              OrderPart oOrderPart = new OrderPart();
              oOrderPart.IgnoreExceptionsOnSetMethods = true;
              oOrderPart.SetOrderID = (object) order.OrderID;
              oOrderPart.SetPartSupplierID = RuntimeHelpers.GetObjectValue(current["PartSupplierID"]);
              Conversions.ToInteger(current["PartID"]);
              if (Conversions.ToBoolean(current["IsSpecialPart"]))
              {
                FRMSpecialOrder frmSpecialOrder = new FRMSpecialOrder(Conversions.ToInteger(current["PartSupplierID"]), Conversions.ToDouble(current["Price"]), Conversions.ToInteger(current["Qty"]));
                int num4 = (int) frmSpecialOrder.ShowDialog();
                if (frmSpecialOrder.DialogResult != DialogResult.OK)
                  return;
                oOrderPart.SetQuantity = (object) frmSpecialOrder.Quantity;
                oOrderPart.SetBuyPrice = (object) frmSpecialOrder.Price;
                oOrderPart.SetSpecialDescription = (object) frmSpecialOrder.PartName;
                oOrderPart.SetSpecialPartNumber = (object) frmSpecialOrder.SPN;
                oOrderPart.SetQuantityReceived = (object) frmSpecialOrder.Quantity;
              }
              else
              {
                oOrderPart.SetQuantity = RuntimeHelpers.GetObjectValue(current["Qty"]);
                oOrderPart.SetBuyPrice = RuntimeHelpers.GetObjectValue(current["Price"]);
                oOrderPart.SetQuantityReceived = RuntimeHelpers.GetObjectValue(current["Qty"]);
              }
              oOrderPart.SetChildSupplierID = (object) 0;
              new OrderPartValidator().Validate(oOrderPart);
              OrderPart orderPart = App.DB.OrderPart.Insert(oOrderPart, false);
              App.DB.EngineerVisitPartProductAllocated.InsertOne(this.EngineerVisitID, "Part", orderPart.Quantity, orderPart.OrderPartID, Conversions.ToInteger(current["PartID"]), 1);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          if (new OrderControl(order).IsWithinJobSpendLimit())
            order.SetOrderStatusID = (object) 4;
          else if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.POAuthorisation))
          {
            int num4 = (int) App.ShowMessage("Job cost capacity was exceeded when creating this purchase order!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            order.SetOrderStatusID = (object) 4;
          }
          else
          {
            int num4 = (int) App.ShowMessage("Job cost capacity was exceeded when creating this purchase order!\r\n\r\nPlease note that this order is currently awaiting approval!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            order.SetOrderStatusID = (object) 7;
          }
          App.DB.Order.Update(order);
          this.txtNewOrderNumber.Text = "Created Purchase Order Number : " + order.OrderReference;
          this.txtNewOrderNumber.Visible = order.OrderStatusID != 7;
          this.btnCreate.Enabled = false;
        }
      }
    }

    private void TabletOrder_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnFindPart_Click(object sender, EventArgs e)
    {
      string sql = "SELECT COALESCE(MasterSupplierID,0) FROM tblSupplier WHERE SupplierID = " + Conversions.ToString(this.SupplierID);
      if (Conversions.ToInteger(App.DB.ExecuteScalar(sql, true, false)) == 0)
        this.SearchDataView = (DataView) App.DB.PartSupplier.PartSupplier_FindTabletOrder(this.txtPartSearch.Text, this.SupplierID);
      else
        this.SearchDataView = (DataView) App.DB.PartSupplier.PartSupplier_FindTabletOrder(this.txtPartSearch.Text, this.SupplierID);
    }

    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvSearch.SelectedRows[0].Index > -1)
        this.btnAddPart.Enabled = true;
      else
        this.btnAddPart.Enabled = false;
    }

    private void FrmPartSearch_Load(object sender, EventArgs e)
    {
      try
      {
        this.SetupDataTable();
        this.SetupPartsDataGrid();
        this.SetupSearchDataGrid();
        this.Text = "Create Order (Current Visit: " + Conversions.ToString(this.EngineerVisitID) + " for Engineer: " + Conversions.ToString(this.EngineerID) + ")";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
      try
      {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAddPart_Click(object sender, EventArgs e)
    {
      string sql = "SELECT COALESCE(MasterSupplierID,0) FROM tblSupplier WHERE SupplierID = " + Conversions.ToString(this.SupplierID);
      int integer = Conversions.ToInteger(App.DB.ExecuteScalar(sql, true, false));
      if (this.dgvSearch.SelectedCells[0].RowIndex > -1)
      {
        this.PartsList.Rows.Add(this.SelectedSearchRow["PartSupplierID"], this.SelectedSearchRow["PartCode"], this.SelectedSearchRow["Name"], (object) this.nudQty.Value, this.SelectedSearchRow["Supplier"], this.SelectedSearchRow["PartID"], this.SelectedSearchRow["Price"], this.SelectedSearchRow["IsSpecialPart"]);
        this.txtPartSearch.Text = (string) null;
        this.btnAddPart.Enabled = false;
        this.dgParts.DataSource = (object) this.PartsList;
        this.nudQty.Value = Decimal.One;
        this.SupplierID = integer <= 0 ? Conversions.ToInteger(this.SelectedSearchRow["SupplierID"]) : integer;
        this.txtSupplier.Text = Conversions.ToString(this.SelectedSearchRow["Supplier"]);
        this.SearchDataView.Table.Clear();
      }
      else
      {
        int num = (int) Interaction.MsgBox((object) "Please select an item", MsgBoxStyle.OkOnly, (object) "Opps");
      }
    }

    private void txtPartSearch_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.btnFindPart_Click(RuntimeHelpers.GetObjectValue(sender), (EventArgs) e);
    }
  }
}
