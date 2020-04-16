// Decompiled with JetBrains decompiler
// Type: FSM.FRMCustomerSORJobType
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.CostCentres;
using FSM.Entity.CostCentres.Enums;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMCustomerSORJobType : FRMBaseForm, IForm
  {
    private IContainer components;
    private FSM.Entity.Customers.Customer _theCustomer;
    private FSM.Entity.Customers.Customer _customer;
    private DataView _SORSkills;
    private DataView _costCentreMatrix;

    public FRMCustomerSORJobType()
    {
      this.Load += new EventHandler(this.FRMJobLocks_Load);
      this._theCustomer = new FSM.Entity.Customers.Customer();
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpLocks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cboJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCustomerSorJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        Button btnAdd1 = this._btnAdd;
        if (btnAdd1 != null)
          btnAdd1.Click -= eventHandler;
        this._btnAdd = value;
        Button btnAdd2 = this._btnAdd;
        if (btnAdd2 == null)
          return;
        btnAdd2.Click += eventHandler;
      }
    }

    internal virtual ComboBox CboSOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbSorCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindCustomer
    {
      get
      {
        return this._btnFindCustomer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindCustomer_Click);
        Button btnFindCustomer1 = this._btnFindCustomer;
        if (btnFindCustomer1 != null)
          btnFindCustomer1.Click -= eventHandler;
        this._btnFindCustomer = value;
        Button btnFindCustomer2 = this._btnFindCustomer;
        if (btnFindCustomer2 == null)
          return;
        btnFindCustomer2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpCostCentreMatrix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCCJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDeleteCCM
    {
      get
      {
        return this._btnDeleteCCM;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteCCM_Click);
        Button btnDeleteCcm1 = this._btnDeleteCCM;
        if (btnDeleteCcm1 != null)
          btnDeleteCcm1.Click -= eventHandler;
        this._btnDeleteCCM = value;
        Button btnDeleteCcm2 = this._btnDeleteCCM;
        if (btnDeleteCcm2 == null)
          return;
        btnDeleteCcm2.Click += eventHandler;
      }
    }

    internal virtual Label lblJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgCostCentreMatrix
    {
      get
      {
        return this._dgCostCentreMatrix;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgCostCentreMatrix_Click);
        DataGrid costCentreMatrix1 = this._dgCostCentreMatrix;
        if (costCentreMatrix1 != null)
          costCentreMatrix1.Click -= eventHandler;
        this._dgCostCentreMatrix = value;
        DataGrid costCentreMatrix2 = this._dgCostCentreMatrix;
        if (costCentreMatrix2 == null)
          return;
        costCentreMatrix2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddCCM
    {
      get
      {
        return this._btnAddCCM;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddCCM_Click);
        Button btnAddCcm1 = this._btnAddCCM;
        if (btnAddCcm1 != null)
          btnAddCcm1.Click -= eventHandler;
        this._btnAddCCM = value;
        Button btnAddCcm2 = this._btnAddCCM;
        if (btnAddCcm2 == null)
          return;
        btnAddCcm2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboCostCentre { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCostCentre { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLinkType
    {
      get
      {
        return this._cboLinkType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboLinkType_SelectedIndexChanged);
        ComboBox cboLinkType1 = this._cboLinkType;
        if (cboLinkType1 != null)
          cboLinkType1.SelectedIndexChanged -= eventHandler;
        this._cboLinkType = value;
        ComboBox cboLinkType2 = this._cboLinkType;
        if (cboLinkType2 == null)
          return;
        cboLinkType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblLinkType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCcCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCcFindCustomer
    {
      get
      {
        return this._btnCcFindCustomer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCcFindCustomer_Click);
        Button btnCcFindCustomer1 = this._btnCcFindCustomer;
        if (btnCcFindCustomer1 != null)
          btnCcFindCustomer1.Click -= eventHandler;
        this._btnCcFindCustomer = value;
        Button btnCcFindCustomer2 = this._btnCcFindCustomer;
        if (btnCcFindCustomer2 == null)
          return;
        btnCcFindCustomer2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtCcCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobSpendLimit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobSpendLimit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnReset
    {
      get
      {
        return this._btnReset;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReset_Click);
        Button btnReset1 = this._btnReset;
        if (btnReset1 != null)
          btnReset1.Click -= eventHandler;
        this._btnReset = value;
        Button btnReset2 = this._btnReset;
        if (btnReset2 == null)
          return;
        btnReset2.Click += eventHandler;
      }
    }

    internal virtual Button btnDelete
    {
      get
      {
        return this._btnDelete;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDelete_Click);
        Button btnDelete1 = this._btnDelete;
        if (btnDelete1 != null)
          btnDelete1.Click -= eventHandler;
        this._btnDelete = value;
        Button btnDelete2 = this._btnDelete;
        if (btnDelete2 == null)
          return;
        btnDelete2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpLocks = new GroupBox();
      this.btnSave = new Button();
      this.lbSorCustomer = new Label();
      this.txtCustomer = new TextBox();
      this.btnFindCustomer = new Button();
      this.btnDelete = new Button();
      this.btnAdd = new Button();
      this.CboSOR = new ComboBox();
      this.lblSor = new Label();
      this.cboJobType = new ComboBox();
      this.lblCustomerSorJobType = new Label();
      this.dgSOR = new DataGrid();
      this.btnClose = new Button();
      this.grpCostCentreMatrix = new GroupBox();
      this.btnReset = new Button();
      this.txtJobSpendLimit = new TextBox();
      this.lblJobSpendLimit = new Label();
      this.cboLinkType = new ComboBox();
      this.lblLinkType = new Label();
      this.lblCcCustomer = new Label();
      this.btnCcFindCustomer = new Button();
      this.txtCcCustomer = new TextBox();
      this.cboCostCentre = new ComboBox();
      this.lblCostCentre = new Label();
      this.btnAddCCM = new Button();
      this.cboRegion = new ComboBox();
      this.lblRegion = new Label();
      this.cboCCJobType = new ComboBox();
      this.btnDeleteCCM = new Button();
      this.lblJobType = new Label();
      this.dgCostCentreMatrix = new DataGrid();
      this.grpLocks.SuspendLayout();
      this.dgSOR.BeginInit();
      this.grpCostCentreMatrix.SuspendLayout();
      this.dgCostCentreMatrix.BeginInit();
      this.SuspendLayout();
      this.grpLocks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpLocks.Controls.Add((Control) this.btnSave);
      this.grpLocks.Controls.Add((Control) this.lbSorCustomer);
      this.grpLocks.Controls.Add((Control) this.txtCustomer);
      this.grpLocks.Controls.Add((Control) this.btnFindCustomer);
      this.grpLocks.Controls.Add((Control) this.btnDelete);
      this.grpLocks.Controls.Add((Control) this.btnAdd);
      this.grpLocks.Controls.Add((Control) this.CboSOR);
      this.grpLocks.Controls.Add((Control) this.lblSor);
      this.grpLocks.Controls.Add((Control) this.cboJobType);
      this.grpLocks.Controls.Add((Control) this.lblCustomerSorJobType);
      this.grpLocks.Controls.Add((Control) this.dgSOR);
      this.grpLocks.Location = new System.Drawing.Point(8, 40);
      this.grpLocks.Name = "grpLocks";
      this.grpLocks.Size = new Size(683, 743);
      this.grpLocks.TabIndex = 1;
      this.grpLocks.TabStop = false;
      this.btnSave.AccessibleDescription = "Save item";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Cursor = Cursors.Hand;
      this.btnSave.ImageIndex = 1;
      this.btnSave.Location = new System.Drawing.Point(621, 714);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 22);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.lbSorCustomer.Location = new System.Drawing.Point(6, 23);
      this.lbSorCustomer.Name = "lbSorCustomer";
      this.lbSorCustomer.Size = new Size(64, 16);
      this.lbSorCustomer.TabIndex = 36;
      this.lbSorCustomer.Text = "Customer";
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(76, 20);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(131, 21);
      this.txtCustomer.TabIndex = 34;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(213, 18);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(25, 23);
      this.btnFindCustomer.TabIndex = 35;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.btnDelete.AccessibleDescription = "Save item";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnDelete.Cursor = Cursors.Hand;
      this.btnDelete.ImageIndex = 1;
      this.btnDelete.Location = new System.Drawing.Point(9, 714);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(56, 22);
      this.btnDelete.TabIndex = 2;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnAdd.AccessibleDescription = "Save item";
      this.btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.btnAdd.Cursor = Cursors.Hand;
      this.btnAdd.ImageIndex = 1;
      this.btnAdd.Location = new System.Drawing.Point(8, 47);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(667, 23);
      this.btnAdd.TabIndex = 33;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.CboSOR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.CboSOR.FormattingEnabled = true;
      this.CboSOR.Location = new System.Drawing.Point(451, 21);
      this.CboSOR.Name = "CboSOR";
      this.CboSOR.Size = new Size(222, 21);
      this.CboSOR.TabIndex = 32;
      this.lblSor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblSor.AutoSize = true;
      this.lblSor.Location = new System.Drawing.Point(413, 23);
      this.lblSor.Name = "lblSor";
      this.lblSor.Size = new Size(32, 13);
      this.lblSor.TabIndex = 31;
      this.lblSor.Text = "SOR";
      this.cboJobType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboJobType.FormattingEnabled = true;
      this.cboJobType.Location = new System.Drawing.Point(307, 20);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new Size(100, 21);
      this.cboJobType.TabIndex = 3;
      this.lblCustomerSorJobType.AutoSize = true;
      this.lblCustomerSorJobType.Location = new System.Drawing.Point(244, 24);
      this.lblCustomerSorJobType.Name = "lblCustomerSorJobType";
      this.lblCustomerSorJobType.Size = new Size(57, 13);
      this.lblCustomerSorJobType.TabIndex = 2;
      this.lblCustomerSorJobType.Text = "Job Type";
      this.dgSOR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSOR.DataMember = "";
      this.dgSOR.HeaderForeColor = SystemColors.ControlText;
      this.dgSOR.Location = new System.Drawing.Point(8, 76);
      this.dgSOR.Name = "dgSOR";
      this.dgSOR.Size = new Size(667, 623);
      this.dgSOR.TabIndex = 1;
      this.btnClose.AccessibleDescription = "Save item";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Cursor = Cursors.Hand;
      this.btnClose.ImageIndex = 1;
      this.btnClose.Location = new System.Drawing.Point(16, 802);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 24);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.grpCostCentreMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCostCentreMatrix.Controls.Add((Control) this.btnReset);
      this.grpCostCentreMatrix.Controls.Add((Control) this.txtJobSpendLimit);
      this.grpCostCentreMatrix.Controls.Add((Control) this.lblJobSpendLimit);
      this.grpCostCentreMatrix.Controls.Add((Control) this.cboLinkType);
      this.grpCostCentreMatrix.Controls.Add((Control) this.lblLinkType);
      this.grpCostCentreMatrix.Controls.Add((Control) this.lblCcCustomer);
      this.grpCostCentreMatrix.Controls.Add((Control) this.btnCcFindCustomer);
      this.grpCostCentreMatrix.Controls.Add((Control) this.txtCcCustomer);
      this.grpCostCentreMatrix.Controls.Add((Control) this.cboCostCentre);
      this.grpCostCentreMatrix.Controls.Add((Control) this.lblCostCentre);
      this.grpCostCentreMatrix.Controls.Add((Control) this.btnAddCCM);
      this.grpCostCentreMatrix.Controls.Add((Control) this.cboRegion);
      this.grpCostCentreMatrix.Controls.Add((Control) this.lblRegion);
      this.grpCostCentreMatrix.Controls.Add((Control) this.cboCCJobType);
      this.grpCostCentreMatrix.Controls.Add((Control) this.btnDeleteCCM);
      this.grpCostCentreMatrix.Controls.Add((Control) this.lblJobType);
      this.grpCostCentreMatrix.Controls.Add((Control) this.dgCostCentreMatrix);
      this.grpCostCentreMatrix.Location = new System.Drawing.Point(697, 40);
      this.grpCostCentreMatrix.Name = "grpCostCentreMatrix";
      this.grpCostCentreMatrix.Size = new Size(896, 743);
      this.grpCostCentreMatrix.TabIndex = 35;
      this.grpCostCentreMatrix.TabStop = false;
      this.grpCostCentreMatrix.Text = "Cost Centre Matrix";
      this.btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnReset.Location = new System.Drawing.Point(810, 50);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(78, 20);
      this.btnReset.TabIndex = 77;
      this.btnReset.Tag = (object) "";
      this.btnReset.Text = "Reset";
      this.txtJobSpendLimit.Location = new System.Drawing.Point(336, 49);
      this.txtJobSpendLimit.Name = "txtJobSpendLimit";
      this.txtJobSpendLimit.Size = new Size(117, 21);
      this.txtJobSpendLimit.TabIndex = 76;
      this.lblJobSpendLimit.AutoSize = true;
      this.lblJobSpendLimit.Location = new System.Drawing.Point(222, 52);
      this.lblJobSpendLimit.Name = "lblJobSpendLimit";
      this.lblJobSpendLimit.Size = new Size(108, 13);
      this.lblJobSpendLimit.TabIndex = 75;
      this.lblJobSpendLimit.Text = "Job Spend Limit £";
      this.cboLinkType.FormattingEnabled = true;
      this.cboLinkType.Location = new System.Drawing.Point(90, 49);
      this.cboLinkType.Name = "cboLinkType";
      this.cboLinkType.Size = new Size(119, 21);
      this.cboLinkType.TabIndex = 74;
      this.lblLinkType.AutoSize = true;
      this.lblLinkType.Location = new System.Drawing.Point(8, 52);
      this.lblLinkType.Name = "lblLinkType";
      this.lblLinkType.Size = new Size(61, 13);
      this.lblLinkType.TabIndex = 73;
      this.lblLinkType.Text = "Link Type";
      this.lblCcCustomer.AutoSize = true;
      this.lblCcCustomer.Location = new System.Drawing.Point(471, 25);
      this.lblCcCustomer.Name = "lblCcCustomer";
      this.lblCcCustomer.Size = new Size(63, 13);
      this.lblCcCustomer.TabIndex = 72;
      this.lblCcCustomer.Text = "Customer";
      this.lblCcCustomer.Visible = false;
      this.btnCcFindCustomer.BackColor = Color.White;
      this.btnCcFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnCcFindCustomer.Location = new System.Drawing.Point(712, 18);
      this.btnCcFindCustomer.Name = "btnCcFindCustomer";
      this.btnCcFindCustomer.Size = new Size(32, 23);
      this.btnCcFindCustomer.TabIndex = 71;
      this.btnCcFindCustomer.Text = "...";
      this.btnCcFindCustomer.UseVisualStyleBackColor = false;
      this.btnCcFindCustomer.Visible = false;
      this.txtCcCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCcCustomer.Location = new System.Drawing.Point(540, 19);
      this.txtCcCustomer.Name = "txtCcCustomer";
      this.txtCcCustomer.ReadOnly = true;
      this.txtCcCustomer.Size = new Size(166, 21);
      this.txtCcCustomer.TabIndex = 70;
      this.txtCcCustomer.Visible = false;
      this.cboCostCentre.FormattingEnabled = true;
      this.cboCostCentre.Location = new System.Drawing.Point(90, 19);
      this.cboCostCentre.Name = "cboCostCentre";
      this.cboCostCentre.Size = new Size(73, 21);
      this.cboCostCentre.TabIndex = 69;
      this.lblCostCentre.AutoSize = true;
      this.lblCostCentre.Location = new System.Drawing.Point(8, 23);
      this.lblCostCentre.Name = "lblCostCentre";
      this.lblCostCentre.Size = new Size(76, 13);
      this.lblCostCentre.TabIndex = 68;
      this.lblCostCentre.Text = "Cost Centre";
      this.btnAddCCM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddCCM.Location = new System.Drawing.Point(810, 20);
      this.btnAddCCM.Name = "btnAddCCM";
      this.btnAddCCM.Size = new Size(78, 20);
      this.btnAddCCM.TabIndex = 67;
      this.btnAddCCM.Tag = (object) "";
      this.btnAddCCM.Text = "Save";
      this.cboRegion.FormattingEnabled = true;
      this.cboRegion.Location = new System.Drawing.Point(523, 19);
      this.cboRegion.Name = "cboRegion";
      this.cboRegion.Size = new Size(159, 21);
      this.cboRegion.TabIndex = 32;
      this.lblRegion.AutoSize = true;
      this.lblRegion.Location = new System.Drawing.Point(471, 23);
      this.lblRegion.Name = "lblRegion";
      this.lblRegion.Size = new Size(46, 13);
      this.lblRegion.TabIndex = 31;
      this.lblRegion.Text = "Region";
      this.cboCCJobType.FormattingEnabled = true;
      this.cboCCJobType.Location = new System.Drawing.Point(300, 19);
      this.cboCCJobType.Name = "cboCCJobType";
      this.cboCCJobType.Size = new Size(153, 21);
      this.cboCCJobType.TabIndex = 3;
      this.btnDeleteCCM.AccessibleDescription = "Save item";
      this.btnDeleteCCM.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeleteCCM.Cursor = Cursors.Hand;
      this.btnDeleteCCM.ImageIndex = 1;
      this.btnDeleteCCM.Location = new System.Drawing.Point(810, 714);
      this.btnDeleteCCM.Name = "btnDeleteCCM";
      this.btnDeleteCCM.Size = new Size(78, 22);
      this.btnDeleteCCM.TabIndex = 2;
      this.btnDeleteCCM.Text = "Delete";
      this.btnDeleteCCM.UseVisualStyleBackColor = true;
      this.lblJobType.AutoSize = true;
      this.lblJobType.Location = new System.Drawing.Point(222, 23);
      this.lblJobType.Name = "lblJobType";
      this.lblJobType.Size = new Size(57, 13);
      this.lblJobType.TabIndex = 2;
      this.lblJobType.Text = "Job Type";
      this.dgCostCentreMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgCostCentreMatrix.DataMember = "";
      this.dgCostCentreMatrix.HeaderForeColor = SystemColors.ControlText;
      this.dgCostCentreMatrix.Location = new System.Drawing.Point(11, 76);
      this.dgCostCentreMatrix.Name = "dgCostCentreMatrix";
      this.dgCostCentreMatrix.Size = new Size(880, 623);
      this.dgCostCentreMatrix.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1604, 852);
      this.Controls.Add((Control) this.grpCostCentreMatrix);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.grpLocks);
      this.MinimumSize = new Size(793, 520);
      this.Name = nameof (FRMCustomerSORJobType);
      this.Text = "Setup";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpLocks, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.grpCostCentreMatrix, 0);
      this.grpLocks.ResumeLayout(false);
      this.grpLocks.PerformLayout();
      this.dgSOR.EndInit();
      this.grpCostCentreMatrix.ResumeLayout(false);
      this.grpCostCentreMatrix.PerformLayout();
      this.dgCostCentreMatrix.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDataGrid();
      this.SetupCCMDataGrid();
      ComboBox cboJobType = this.cboJobType;
      Combo.SetUpCombo(ref cboJobType, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboJobType = cboJobType;
      ComboBox cboCcJobType = this.cboCCJobType;
      Combo.SetUpCombo(ref cboCcJobType, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboCCJobType = cboCcJobType;
      ComboBox cboRegion = this.cboRegion;
      Combo.SetUpCombo(ref cboRegion, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboRegion = cboRegion;
      ComboBox cboLinkType = this.cboLinkType;
      Combo.SetUpCombo(ref cboLinkType, App.DB.CostCentreLinkType.GetAll().Table, "Id", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboLinkType = cboLinkType;
      if (true == App.IsGasway)
      {
        ComboBox cboCostCentre = this.cboCostCentre;
        Combo.SetUpCombo(ref cboCostCentre, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Department, false).Table, "Name", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select_Negative);
        this.cboCostCentre = cboCostCentre;
      }
      else
      {
        ComboBox cboCostCentre = this.cboCostCentre;
        Combo.SetUpCombo(ref cboCostCentre, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Department, false).Table, "Name", "Description", FSM.Entity.Sys.Enums.ComboValues.Please_Select_Negative);
        this.cboCostCentre = cboCostCentre;
      }
      this.cboLinkType.Items.RemoveAt(0);
      ComboBox comboBox = this.cboLinkType;
      Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(1));
      this.cboLinkType = comboBox;
      comboBox = this.CboSOR;
      Combo.SetUpCombo(ref comboBox, App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(App.CurrentCustomerID).Table, "CustomerScheduleOfRateID", "Description", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.CboSOR = comboBox;
      this.SORSkills = App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_GetAll();
      this.UpdateCostCentreMatrixDg();
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

    public FSM.Entity.Customers.Customer theCustomer
    {
      get
      {
        return this._theCustomer;
      }
      set
      {
        this._theCustomer = value;
        if ((uint) this._theCustomer.CustomerID > 0U)
        {
          this.txtCustomer.Text = this.theCustomer.Name + " (A/C No : " + this._theCustomer.AccountNumber + ")";
          ComboBox cboSor = this.CboSOR;
          Combo.SetUpCombo(ref cboSor, App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(this._theCustomer.CustomerID).Table, "CustomerScheduleOfRateID", "Description", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
          this.CboSOR = cboSor;
        }
        else
          this.txtCustomer.Text = "";
      }
    }

    public FSM.Entity.Customers.Customer Customer
    {
      get
      {
        return this._customer;
      }
      set
      {
        this._customer = value;
        if (Helper.MakeIntegerValid((object) this._customer?.CustomerID) > 0)
          this.txtCcCustomer.Text = this._customer.Name;
        else
          this.txtCcCustomer.Text = "";
      }
    }

    private DataView SORSkills
    {
      get
      {
        return this._SORSkills;
      }
      set
      {
        this._SORSkills = value;
        this._SORSkills.AllowNew = false;
        this._SORSkills.AllowEdit = false;
        this._SORSkills.AllowDelete = false;
        this._SORSkills.Table.TableName = "Skills";
        this.dgSOR.DataSource = (object) this._SORSkills;
      }
    }

    private DataRow SelectedDataRow
    {
      get
      {
        return this.dgSOR.CurrentRowIndex != -1 ? this.SORSkills[this.dgSOR.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataView CostCentreMatrix
    {
      get
      {
        return this._costCentreMatrix;
      }
      set
      {
        this._costCentreMatrix = value;
        this._costCentreMatrix.AllowNew = false;
        this._costCentreMatrix.AllowEdit = false;
        this._costCentreMatrix.AllowDelete = false;
        this._costCentreMatrix.Table.TableName = nameof (CostCentreMatrix);
        this.dgCostCentreMatrix.DataSource = (object) this.CostCentreMatrix;
      }
    }

    private DataRow SelectedDataRowCCM
    {
      get
      {
        return this.dgCostCentreMatrix.CurrentRowIndex != -1 ? this.CostCentreMatrix[this.dgCostCentreMatrix.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSOR, false);
      DataGridTableStyle tableStyle = this.dgSOR.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "CustomerJobTypeSORID";
      dataGridLabelColumn1.MappingName = "CustomerJobTypeSORID";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 5;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "CustomerScheduleOfRateID";
      dataGridLabelColumn2.MappingName = "CustomerScheduleOfRateID";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 5;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "CustomerID";
      dataGridLabelColumn3.MappingName = "CustomerID";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 5;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "JobTypeID";
      dataGridLabelColumn4.MappingName = "JobTypeID";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 5;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Customer Name";
      dataGridLabelColumn5.MappingName = "Customer";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Job Type";
      dataGridLabelColumn6.MappingName = "JobType";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 150;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "SOR Code";
      dataGridLabelColumn7.MappingName = "code";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "SOR Description";
      dataGridLabelColumn8.MappingName = "Description";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 150;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "Skills";
      this.dgSOR.TableStyles.Add(tableStyle);
    }

    private void SetupCCMDataGrid()
    {
      Helper.SetUpDataGrid(this.dgCostCentreMatrix, false);
      DataGridTableStyle tableStyle = this.dgCostCentreMatrix.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Cost Centre";
      dataGridLabelColumn1.MappingName = "CostCentre";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Job Type";
      dataGridLabelColumn2.MappingName = "JobType";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 250;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Link";
      dataGridLabelColumn3.MappingName = "Link";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Link Type";
      dataGridLabelColumn4.MappingName = "LinkType";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "c";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Job Spend Limit";
      dataGridLabelColumn5.MappingName = "JobSpendLimit";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 150;
      dataGridLabelColumn5.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "CostCentreMatrix";
      this.dgCostCentreMatrix.TableStyles.Add(tableStyle);
    }

    private void FRMJobLocks_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (App.EnterOverridePassword())
      {
        if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        try
        {
          Cursor.Current = Cursors.WaitCursor;
          App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Delete(Conversions.ToInteger(this.SelectedDataRow["CustomerJobTypeSORID"]));
          this.SORSkills = App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_GetAll();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Error unlocking job : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Cursor.Current = Cursors.Default;
        }
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (!(this.theCustomer.CustomerID > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboJobType)) > 0.0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.CboSOR)) > 0.0))
        return;
      App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Insert(this.theCustomer.CustomerID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboJobType)), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.CboSOR)));
      this.SORSkills = App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_GetAll();
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(FSM.Entity.Sys.Enums.TableNames.tblCustomer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theCustomer = App.DB.Customer.Customer_Get(integer);
    }

    private void btnCcFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(FSM.Entity.Sys.Enums.TableNames.tblCustomer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Customer = App.DB.Customer.Customer_Get(integer);
    }

    private void btnAddCCM_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToMulitpleModules(new List<FSM.Entity.Sys.Enums.SecuritySystemModules>()
      {
        FSM.Entity.Sys.Enums.SecuritySystemModules.IT,
        FSM.Entity.Sys.Enums.SecuritySystemModules.Finance
      }))
        App.ShowSecurityError();
      string Left = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboCostCentre).Trim());
      int @ref = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboCCJobType));
      Decimal num3 = new Decimal(this.txtJobSpendLimit.Text.Length > 0 ? Helper.MakeDoubleValid((object) this.txtJobSpendLimit.Text) : 0.0);
      if (@ref == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "-1", false) == 0)
        return;
      List<CostCentre> list = App.DB.CostCentre.Get(@ref, 0, GetBy.JobTypeId);
      int num1 = 0;
      int num2 = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboLinkType));
      switch (num2)
      {
        case 1:
          num1 = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboRegion));
          if (num1 == 0)
          {
            int num4 = (int) App.ShowMessage("Please select a region!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return;
          }
          break;
        case 2:
          num1 = Helper.MakeIntegerValid((object) this.Customer?.CustomerID);
          if (num1 == 0)
          {
            int num4 = (int) App.ShowMessage("Please select a customer!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return;
          }
          break;
      }
      if (list != null)
        list = list.Where<CostCentre>((Func<CostCentre, bool>) (x => x.JobTypeId == @ref & x.LinkId == num1 & x.LinkTypeId == num2)).ToList<CostCentre>();
      if (list != null && list.Count > 0)
      {
        list.FirstOrDefault<CostCentre>().Name = Conversions.ToInteger(Left);
        list.FirstOrDefault<CostCentre>().JobTypeId = @ref;
        list.FirstOrDefault<CostCentre>().LinkId = num1;
        list.FirstOrDefault<CostCentre>().LinkTypeId = num2;
        list.FirstOrDefault<CostCentre>().JobSpendLimit = num3;
        App.DB.CostCentre.Update(list.FirstOrDefault<CostCentre>());
        this.UpdateCostCentreMatrixDg();
      }
      else
      {
        CostCentre ccm = new CostCentre()
        {
          Name = Conversions.ToInteger(Left),
          JobTypeId = @ref,
          LinkId = num1,
          LinkTypeId = num2,
          JobSpendLimit = num3
        };
        if (App.DB.CostCentre.Insert(ccm).Id > 0)
          this.UpdateCostCentreMatrixDg();
      }
    }

    public void UpdateCostCentreMatrixDg()
    {
      this.CostCentreMatrix = App.DB.CostCentre.GetAll();
      this.ResetControls();
    }

    public void ResetControls()
    {
      ComboBox cboCcJobType = this.cboCCJobType;
      Combo.SetSelectedComboItem_By_Value(ref cboCcJobType, Conversions.ToString(0));
      this.cboCCJobType = cboCcJobType;
      ComboBox cboRegion = this.cboRegion;
      Combo.SetSelectedComboItem_By_Value(ref cboRegion, Conversions.ToString(0));
      this.cboRegion = cboRegion;
      ComboBox cboCostCentre = this.cboCostCentre;
      Combo.SetSelectedComboItem_By_Value(ref cboCostCentre, "-1");
      this.cboCostCentre = cboCostCentre;
      this.Customer = (FSM.Entity.Customers.Customer) null;
      this.txtJobSpendLimit.Text = "";
    }

    private void btnDeleteCCM_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToMulitpleModules(new List<FSM.Entity.Sys.Enums.SecuritySystemModules>()
      {
        FSM.Entity.Sys.Enums.SecuritySystemModules.IT,
        FSM.Entity.Sys.Enums.SecuritySystemModules.Finance
      }))
        App.ShowSecurityError();
      if (this.SelectedDataRowCCM == null)
      {
        int num1 = (int) App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
          return;
        try
        {
          Cursor.Current = Cursors.WaitCursor;
          App.DB.CostCentre.Delete(Conversions.ToInteger(this.SelectedDataRowCCM["Id"]));
          this.UpdateCostCentreMatrixDg();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Error deleting: \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Cursor.Current = Cursors.Default;
        }
      }
    }

    private void cboLinkType_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboLinkType)))
      {
        case 1:
          this.lblRegion.Visible = true;
          this.cboRegion.Visible = true;
          this.lblCcCustomer.Visible = false;
          this.txtCcCustomer.Visible = false;
          this.btnCcFindCustomer.Visible = false;
          break;
        case 2:
          this.lblCcCustomer.Visible = true;
          this.txtCcCustomer.Visible = true;
          this.btnCcFindCustomer.Visible = true;
          this.lblRegion.Visible = false;
          this.cboRegion.Visible = false;
          break;
      }
    }

    private void dgCostCentreMatrix_Click(object sender, EventArgs e)
    {
      if (this.SelectedDataRowCCM == null)
        return;
      CostCentre costCentre = App.DB.CostCentre.Get(Conversions.ToInteger(this.SelectedDataRowCCM["Id"]), 0, GetBy.Id).FirstOrDefault<CostCentre>();
      ComboBox cboCostCentre = this.cboCostCentre;
      Combo.SetSelectedComboItem_By_Value(ref cboCostCentre, Conversions.ToString(costCentre.Name));
      this.cboCostCentre = cboCostCentre;
      ComboBox combo = this.cboCCJobType;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(costCentre.JobTypeId));
      this.cboCCJobType = combo;
      combo = this.cboLinkType;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(costCentre.LinkTypeId));
      this.cboLinkType = combo;
      if (costCentre.LinkTypeId == 1)
      {
        combo = this.cboRegion;
        Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(costCentre.LinkId));
        this.cboRegion = combo;
      }
      else
        this.Customer = App.DB.Customer.Customer_Get(costCentre.LinkId);
      this.txtJobSpendLimit.Text = Helper.MakeStringValid((object) costCentre.JobSpendLimit);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetControls();
    }
  }
}
