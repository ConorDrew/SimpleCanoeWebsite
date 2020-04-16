// Decompiled with JetBrains decompiler
// Type: FSM.FRMConvertToAnOrder
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.CustomerOrders;
using FSM.Entity.EngineerVisitOrders;
using FSM.Entity.EngineerVisits;
using FSM.Entity.Jobs;
using FSM.Entity.OrderCharges;
using FSM.Entity.OrderLocationPart;
using FSM.Entity.OrderLocationProduct;
using FSM.Entity.OrderLocations;
using FSM.Entity.OrderParts;
using FSM.Entity.OrderProducts;
using FSM.Entity.Orders;
using FSM.Entity.Parts;
using FSM.Entity.PartSuppliers;
using FSM.Entity.PartTransactions;
using FSM.Entity.Products;
using FSM.Entity.ProductSuppliers;
using FSM.Entity.ProductTransactions;
using FSM.Entity.QuoteOrders;
using FSM.Entity.SiteOrders;
using FSM.Entity.Suppliers;
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
  public class FRMConvertToAnOrder : FRMBaseForm, IForm
  {
    private IContainer components;
    private SqlTransaction _Trans;
    private DataView m_dTable2;
    private QuoteOrder _QuoteOrder;
    private Enums.OrderType _OrderType;
    private int _ID;
    private int _EngineerVisitID;
    private DataView _EngineerVisitsDataView;
    private DataView _PartsAndProducts;
    private bool _NeedsTransaction;
    private DataView _ChargesDataView;
    private Enums.FormState _PageState;

    public FRMConvertToAnOrder()
    {
      this.Load += new EventHandler(this.FRMConvertToAnOrder_Load);
      this.m_dTable2 = (DataView) null;
      this._ID = 0;
      this._EngineerVisitID = 0;
      this._EngineerVisitsDataView = (DataView) null;
      this._PartsAndProducts = (DataView) null;
      this._NeedsTransaction = false;
      this._ChargesDataView = (DataView) null;
      this._PageState = Enums.FormState.Insert;
      this.InitializeComponent();
      ComboBox cboChargeType = this.cboChargeType;
      Combo.SetUpCombo(ref cboChargeType, App.DB.Picklists.GetAll(Enums.PickListTypes.OrderChargeTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboChargeType = cboChargeType;
    }

    public FRMConvertToAnOrder(SqlTransaction trans)
    {
      this.Load += new EventHandler(this.FRMConvertToAnOrder_Load);
      this.m_dTable2 = (DataView) null;
      this._ID = 0;
      this._EngineerVisitID = 0;
      this._EngineerVisitsDataView = (DataView) null;
      this._PartsAndProducts = (DataView) null;
      this._NeedsTransaction = false;
      this._ChargesDataView = (DataView) null;
      this._PageState = Enums.FormState.Insert;
      this.Trans = trans;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpJob { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgEngineerVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual GroupBox grpPartsAndProducts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPartsAndProducts
    {
      get
      {
        return this._dgPartsAndProducts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgPartsAndProducts_CurrentCellChanged);
        DataGrid partsAndProducts1 = this._dgPartsAndProducts;
        if (partsAndProducts1 != null)
          partsAndProducts1.CurrentCellChanged -= eventHandler;
        this._dgPartsAndProducts = value;
        DataGrid partsAndProducts2 = this._dgPartsAndProducts;
        if (partsAndProducts2 == null)
          return;
        partsAndProducts2.CurrentCellChanged += eventHandler;
      }
    }

    internal virtual Button btnAddProduct
    {
      get
      {
        return this._btnAddProduct;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddProduct_Click);
        Button btnAddProduct1 = this._btnAddProduct;
        if (btnAddProduct1 != null)
          btnAddProduct1.Click -= eventHandler;
        this._btnAddProduct = value;
        Button btnAddProduct2 = this._btnAddProduct;
        if (btnAddProduct2 == null)
          return;
        btnAddProduct2.Click += eventHandler;
      }
    }

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

    internal virtual Label lblinformation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkAwaiting
    {
      get
      {
        return this._chkAwaiting;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkAwaiting_CheckedChanged);
        CheckBox chkAwaiting1 = this._chkAwaiting;
        if (chkAwaiting1 != null)
          chkAwaiting1.CheckedChanged -= eventHandler;
        this._chkAwaiting = value;
        CheckBox chkAwaiting2 = this._chkAwaiting;
        if (chkAwaiting2 == null)
          return;
        chkAwaiting2.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkConfirmed
    {
      get
      {
        return this._chkConfirmed;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkConfirmed_CheckedChanged);
        CheckBox chkConfirmed1 = this._chkConfirmed;
        if (chkConfirmed1 != null)
          chkConfirmed1.CheckedChanged -= eventHandler;
        this._chkConfirmed = value;
        CheckBox chkConfirmed2 = this._chkConfirmed;
        if (chkConfirmed2 == null)
          return;
        chkConfirmed2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDeadline { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage TabPage1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage TabPage2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnChargesSave
    {
      get
      {
        return this._btnChargesSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnChargesSave_Click);
        Button btnChargesSave1 = this._btnChargesSave;
        if (btnChargesSave1 != null)
          btnChargesSave1.Click -= eventHandler;
        this._btnChargesSave = value;
        Button btnChargesSave2 = this._btnChargesSave;
        if (btnChargesSave2 == null)
          return;
        btnChargesSave2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboChargeType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgCharges
    {
      get
      {
        return this._dgCharges;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgCharges_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgCharges_Click);
        DataGrid dgCharges1 = this._dgCharges;
        if (dgCharges1 != null)
        {
          dgCharges1.Click -= eventHandler1;
          dgCharges1.CurrentCellChanged -= eventHandler2;
        }
        this._dgCharges = value;
        DataGrid dgCharges2 = this._dgCharges;
        if (dgCharges2 == null)
          return;
        dgCharges2.Click += eventHandler1;
        dgCharges2.CurrentCellChanged += eventHandler2;
      }
    }

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

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkDoNotConsolidate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemove
    {
      get
      {
        return this._btnRemove;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemove_Click);
        Button btnRemove1 = this._btnRemove;
        if (btnRemove1 != null)
          btnRemove1.Click -= eventHandler;
        this._btnRemove = value;
        Button btnRemove2 = this._btnRemove;
        if (btnRemove2 == null)
          return;
        btnRemove2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJob = new GroupBox();
      this.dgEngineerVisits = new DataGrid();
      this.grpPartsAndProducts = new GroupBox();
      this.btnExport = new Button();
      this.btnRemove = new Button();
      this.dgPartsAndProducts = new DataGrid();
      this.btnAddProduct = new Button();
      this.btnAddPart = new Button();
      this.btnSave = new Button();
      this.btnCancel = new Button();
      this.lblinformation = new Label();
      this.chkAwaiting = new CheckBox();
      this.chkConfirmed = new CheckBox();
      this.Label1 = new Label();
      this.dtpDeadline = new DateTimePicker();
      this.Label2 = new Label();
      this.TabControl1 = new TabControl();
      this.TabPage1 = new TabPage();
      this.TabPage2 = new TabPage();
      this.grpCharges = new GroupBox();
      this.btnDelete = new Button();
      this.btnChargesSave = new Button();
      this.txtAmount = new TextBox();
      this.Label3 = new Label();
      this.cboChargeType = new ComboBox();
      this.Label4 = new Label();
      this.dgCharges = new DataGrid();
      this.Label17 = new Label();
      this.txtDepartment = new TextBox();
      this.chkDoNotConsolidate = new CheckBox();
      this.grpJob.SuspendLayout();
      this.dgEngineerVisits.BeginInit();
      this.grpPartsAndProducts.SuspendLayout();
      this.dgPartsAndProducts.BeginInit();
      this.TabControl1.SuspendLayout();
      this.TabPage1.SuspendLayout();
      this.TabPage2.SuspendLayout();
      this.grpCharges.SuspendLayout();
      this.dgCharges.BeginInit();
      this.SuspendLayout();
      this.grpJob.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJob.Controls.Add((Control) this.dgEngineerVisits);
      this.grpJob.Location = new System.Drawing.Point(8, 40);
      this.grpJob.Name = "grpJob";
      this.grpJob.Size = new Size(976, 152);
      this.grpJob.TabIndex = 1;
      this.grpJob.TabStop = false;
      this.grpJob.Text = "More than one engineer visit exists for this job, please select the visit to assign this order to and click OK";
      this.dgEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgEngineerVisits.DataMember = "";
      this.dgEngineerVisits.HeaderForeColor = SystemColors.ControlText;
      this.dgEngineerVisits.Location = new System.Drawing.Point(8, 30);
      this.dgEngineerVisits.Name = "dgEngineerVisits";
      this.dgEngineerVisits.Size = new Size(960, 114);
      this.dgEngineerVisits.TabIndex = 1;
      this.grpPartsAndProducts.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpPartsAndProducts.Controls.Add((Control) this.btnExport);
      this.grpPartsAndProducts.Controls.Add((Control) this.btnRemove);
      this.grpPartsAndProducts.Controls.Add((Control) this.dgPartsAndProducts);
      this.grpPartsAndProducts.Controls.Add((Control) this.btnAddProduct);
      this.grpPartsAndProducts.Controls.Add((Control) this.btnAddPart);
      this.grpPartsAndProducts.Location = new System.Drawing.Point(0, 0);
      this.grpPartsAndProducts.Name = "grpPartsAndProducts";
      this.grpPartsAndProducts.Size = new Size(968, 275);
      this.grpPartsAndProducts.TabIndex = 2;
      this.grpPartsAndProducts.TabStop = false;
      this.grpPartsAndProducts.Text = "Parts && Products";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(198, 243);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(88, 23);
      this.btnExport.TabIndex = 9;
      this.btnExport.Text = "Export";
      this.btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemove.Location = new System.Drawing.Point(788, 241);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new Size(164, 23);
      this.btnRemove.TabIndex = 8;
      this.btnRemove.Text = "Remove Part / Product";
      this.dgPartsAndProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPartsAndProducts.DataMember = "";
      this.dgPartsAndProducts.HeaderForeColor = SystemColors.ControlText;
      this.dgPartsAndProducts.Location = new System.Drawing.Point(8, 20);
      this.dgPartsAndProducts.Name = "dgPartsAndProducts";
      this.dgPartsAndProducts.Size = new Size(952, 215);
      this.dgPartsAndProducts.TabIndex = 3;
      this.btnAddProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddProduct.Location = new System.Drawing.Point(104, 243);
      this.btnAddProduct.Name = "btnAddProduct";
      this.btnAddProduct.Size = new Size(88, 23);
      this.btnAddProduct.TabIndex = 6;
      this.btnAddProduct.Text = "Add Product";
      this.btnAddPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddPart.Location = new System.Drawing.Point(8, 243);
      this.btnAddPart.Name = "btnAddPart";
      this.btnAddPart.Size = new Size(88, 23);
      this.btnAddPart.TabIndex = 7;
      this.btnAddPart.Text = "Add Part";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(928, 536);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 23);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Save";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(8, 536);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(56, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.lblinformation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblinformation.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.lblinformation.Font = new Font("Verdana", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblinformation.Location = new System.Drawing.Point(328, 536);
      this.lblinformation.Name = "lblinformation";
      this.lblinformation.Size = new Size(600, 24);
      this.lblinformation.TabIndex = 8;
      this.lblinformation.TextAlign = ContentAlignment.MiddleCenter;
      this.chkAwaiting.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.chkAwaiting.AutoSize = true;
      this.chkAwaiting.Location = new System.Drawing.Point(91, 508);
      this.chkAwaiting.Name = "chkAwaiting";
      this.chkAwaiting.Size = new Size(152, 17);
      this.chkAwaiting.TabIndex = 9;
      this.chkAwaiting.Text = "Awaiting Confirmation";
      this.chkAwaiting.UseVisualStyleBackColor = true;
      this.chkConfirmed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.chkConfirmed.AutoSize = true;
      this.chkConfirmed.Location = new System.Drawing.Point(249, 508);
      this.chkConfirmed.Name = "chkConfirmed";
      this.chkConfirmed.Size = new Size(86, 17);
      this.chkConfirmed.TabIndex = 10;
      this.chkConfirmed.Text = "Confirmed";
      this.chkConfirmed.UseVisualStyleBackColor = true;
      this.Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(5, 508);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(80, 13);
      this.Label1.TabIndex = 11;
      this.Label1.Text = "Order Status";
      this.dtpDeadline.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.dtpDeadline.CustomFormat = "dddd dd MMMM yyyy";
      this.dtpDeadline.Format = DateTimePickerFormat.Custom;
      this.dtpDeadline.Location = new System.Drawing.Point(456, 508);
      this.dtpDeadline.Name = "dtpDeadline";
      this.dtpDeadline.Size = new Size(244, 21);
      this.dtpDeadline.TabIndex = 12;
      this.Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(341, 509);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(109, 13);
      this.Label2.TabIndex = 13;
      this.Label2.Text = "Delivery Deadline";
      this.TabControl1.Controls.Add((Control) this.TabPage1);
      this.TabControl1.Controls.Add((Control) this.TabPage2);
      this.TabControl1.Location = new System.Drawing.Point(8, 198);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(976, 304);
      this.TabControl1.TabIndex = 14;
      this.TabPage1.Controls.Add((Control) this.grpPartsAndProducts);
      this.TabPage1.Location = new System.Drawing.Point(4, 22);
      this.TabPage1.Name = "TabPage1";
      this.TabPage1.Padding = new Padding(3);
      this.TabPage1.Size = new Size(968, 278);
      this.TabPage1.TabIndex = 0;
      this.TabPage1.Text = "Parts & Products";
      this.TabPage1.UseVisualStyleBackColor = true;
      this.TabPage2.Controls.Add((Control) this.grpCharges);
      this.TabPage2.Location = new System.Drawing.Point(4, 22);
      this.TabPage2.Name = "TabPage2";
      this.TabPage2.Padding = new Padding(3);
      this.TabPage2.Size = new Size(968, 278);
      this.TabPage2.TabIndex = 1;
      this.TabPage2.Text = "Charges";
      this.TabPage2.UseVisualStyleBackColor = true;
      this.grpCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCharges.Controls.Add((Control) this.btnDelete);
      this.grpCharges.Controls.Add((Control) this.btnChargesSave);
      this.grpCharges.Controls.Add((Control) this.txtAmount);
      this.grpCharges.Controls.Add((Control) this.Label3);
      this.grpCharges.Controls.Add((Control) this.cboChargeType);
      this.grpCharges.Controls.Add((Control) this.Label4);
      this.grpCharges.Controls.Add((Control) this.dgCharges);
      this.grpCharges.Location = new System.Drawing.Point(6, 0);
      this.grpCharges.Name = "grpCharges";
      this.grpCharges.Size = new Size(956, 272);
      this.grpCharges.TabIndex = 3;
      this.grpCharges.TabStop = false;
      this.grpCharges.Text = "Charges";
      this.btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDelete.Location = new System.Drawing.Point(884, 208);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(64, 23);
      this.btnDelete.TabIndex = 5;
      this.btnDelete.Text = "Remove";
      this.btnChargesSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnChargesSave.Location = new System.Drawing.Point(884, 240);
      this.btnChargesSave.Name = "btnChargesSave";
      this.btnChargesSave.Size = new Size(64, 23);
      this.btnChargesSave.TabIndex = 4;
      this.btnChargesSave.Text = "Add";
      this.txtAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtAmount.Location = new System.Drawing.Point(804, 240);
      this.txtAmount.Name = "txtAmount";
      this.txtAmount.Size = new Size(72, 21);
      this.txtAmount.TabIndex = 3;
      this.Label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label3.Location = new System.Drawing.Point(740, 240);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(56, 23);
      this.Label3.TabIndex = 3;
      this.Label3.Text = "Amount:";
      this.cboChargeType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.cboChargeType.Location = new System.Drawing.Point(96, 240);
      this.cboChargeType.Name = "cboChargeType";
      this.cboChargeType.Size = new Size(636, 21);
      this.cboChargeType.TabIndex = 2;
      this.Label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label4.Location = new System.Drawing.Point(8, 240);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(88, 23);
      this.Label4.TabIndex = 1;
      this.Label4.Text = "Charge Type:";
      this.dgCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgCharges.DataMember = "";
      this.dgCharges.HeaderForeColor = SystemColors.ControlText;
      this.dgCharges.Location = new System.Drawing.Point(8, 25);
      this.dgCharges.Name = "dgCharges";
      this.dgCharges.Size = new Size(940, 175);
      this.dgCharges.TabIndex = 1;
      this.Label17.Location = new System.Drawing.Point(705, 508);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(38, 20);
      this.Label17.TabIndex = 70;
      this.Label17.Text = "Dept";
      this.txtDepartment.Location = new System.Drawing.Point(749, 511);
      this.txtDepartment.MaxLength = 100;
      this.txtDepartment.Name = "txtDepartment";
      this.txtDepartment.Size = new Size(131, 21);
      this.txtDepartment.TabIndex = 69;
      this.txtDepartment.Tag = (object) "";
      this.chkDoNotConsolidate.AutoSize = true;
      this.chkDoNotConsolidate.Location = new System.Drawing.Point(91, 540);
      this.chkDoNotConsolidate.Name = "chkDoNotConsolidate";
      this.chkDoNotConsolidate.Size = new Size(136, 17);
      this.chkDoNotConsolidate.TabIndex = 71;
      this.chkDoNotConsolidate.Text = "Do Not Consolidate";
      this.chkDoNotConsolidate.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(992, 566);
      this.ControlBox = false;
      this.Controls.Add((Control) this.chkDoNotConsolidate);
      this.Controls.Add((Control) this.Label17);
      this.Controls.Add((Control) this.txtDepartment);
      this.Controls.Add((Control) this.TabControl1);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.dtpDeadline);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.chkConfirmed);
      this.Controls.Add((Control) this.chkAwaiting);
      this.Controls.Add((Control) this.lblinformation);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.grpJob);
      this.Name = nameof (FRMConvertToAnOrder);
      this.Text = "Convert to an order";
      this.Controls.SetChildIndex((Control) this.grpJob, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.lblinformation, 0);
      this.Controls.SetChildIndex((Control) this.chkAwaiting, 0);
      this.Controls.SetChildIndex((Control) this.chkConfirmed, 0);
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.dtpDeadline, 0);
      this.Controls.SetChildIndex((Control) this.Label2, 0);
      this.Controls.SetChildIndex((Control) this.TabControl1, 0);
      this.Controls.SetChildIndex((Control) this.txtDepartment, 0);
      this.Controls.SetChildIndex((Control) this.Label17, 0);
      this.Controls.SetChildIndex((Control) this.chkDoNotConsolidate, 0);
      this.grpJob.ResumeLayout(false);
      this.dgEngineerVisits.EndInit();
      this.grpPartsAndProducts.ResumeLayout(false);
      this.dgPartsAndProducts.EndInit();
      this.TabControl1.ResumeLayout(false);
      this.TabPage1.ResumeLayout(false);
      this.TabPage2.ResumeLayout(false);
      this.grpCharges.ResumeLayout(false);
      this.grpCharges.PerformLayout();
      this.dgCharges.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.chkAwaiting.Checked = true;
      this.dtpDeadline.Value = DateAndTime.Now;
      this.OrderType = (Enums.OrderType) Conversions.ToInteger(this.get_GetParameter(0));
      switch (this.OrderType)
      {
        case Enums.OrderType.Customer:
          this.Size = new Size(1000, 448);
          this.MinimumSize = new Size(1000, 448);
          this.Height = 448;
          this.grpPartsAndProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
          this.PartsAndProducts = (DataView) this.get_GetParameter(2);
          this.QuoteOrder = (QuoteOrder) this.get_GetParameter(3);
          break;
        case Enums.OrderType.Job:
          this.Size = new Size(1000, 600);
          this.MinimumSize = new Size(1000, 600);
          this.Height = 608;
          this.grpPartsAndProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
          this.EngineerVisitID = Conversions.ToInteger(this.get_GetParameter(4));
          this.NeedsTransaction = Conversions.ToBoolean(this.get_GetParameter(5));
          if (this.EngineerVisitID > 0)
          {
            this.EngineerVisitsDataView = this.Trans == null ? App.DB.EngineerVisits.EngineerVisits_Get(this.EngineerVisitID) : App.DB.EngineerVisits.EngineerVisits_Get(this.EngineerVisitID, this.Trans);
            this.PartsAndProducts = (DataView) this.get_GetParameter(2);
            this.grpJob.Text = "Visit Information";
          }
          else
          {
            this.ID = Conversions.ToInteger(this.get_GetParameter(1));
            this.EngineerVisitsDataView = this.Trans == null ? App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(this.ID) : App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(this.ID, this.Trans);
            this.PartsAndProducts = (DataView) this.get_GetParameter(2);
          }
          this.RefreshDatagrid();
          break;
      }
      Application.DoEvents();
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupVisitsDataGrid();
      this.SetupPartsAndProductsDataGrid();
      this.SetupChargesDatagrid();
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public void ResetMe(int newID)
    {
      this.ID = newID;
    }

    public SqlTransaction Trans
    {
      get
      {
        return this._Trans;
      }
      set
      {
        this._Trans = value;
      }
    }

    public DataView PriceRequestItemsDataView
    {
      get
      {
        return this.m_dTable2;
      }
      set
      {
        this.m_dTable2 = value;
      }
    }

    public QuoteOrder QuoteOrder
    {
      get
      {
        return this._QuoteOrder;
      }
      set
      {
        this._QuoteOrder = value;
        if (this.QuoteOrder == null)
          return;
        this.dtpDeadline.Value = this.QuoteOrder.DeliveryDeadline;
      }
    }

    public Enums.OrderType OrderType
    {
      get
      {
        return this._OrderType;
      }
      set
      {
        this._OrderType = value;
      }
    }

    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
      }
    }

    public int EngineerVisitID
    {
      get
      {
        return this._EngineerVisitID;
      }
      set
      {
        this._EngineerVisitID = value;
      }
    }

    public DataView EngineerVisitsDataView
    {
      get
      {
        return this._EngineerVisitsDataView;
      }
      set
      {
        value.Table.AcceptChanges();
        value.Table.Columns.Add(new DataColumn("VisitCount"));
        int num = 1;
        IEnumerator enumerator;
        try
        {
          enumerator = value.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            ((DataRow) enumerator.Current)["VisitCount"] = (object) num;
            checked { ++num; }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this._EngineerVisitsDataView = value;
        this._EngineerVisitsDataView.Table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
        this._EngineerVisitsDataView.AllowNew = false;
        this._EngineerVisitsDataView.AllowEdit = false;
        this._EngineerVisitsDataView.AllowDelete = false;
        this.dgEngineerVisits.DataSource = (object) this.EngineerVisitsDataView;
      }
    }

    public DataRow SelectedEngineerVisitDataRow
    {
      get
      {
        return this.dgEngineerVisits.CurrentRowIndex != -1 ? this.EngineerVisitsDataView[this.dgEngineerVisits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView PartsAndProducts
    {
      get
      {
        return this._PartsAndProducts;
      }
      set
      {
        value.Table.AcceptChanges();
        value.Table.Columns.Add(new DataColumn("SupplierID"));
        value.Table.Columns.Add(new DataColumn("QuantityToOrder"));
        value.Table.Columns.Add(new DataColumn("GetFrom"));
        value.Table.Columns.Add(new DataColumn("GetFromText"));
        value.Table.Columns.Add(new DataColumn("GetID"));
        value.Table.Columns.Add(new DataColumn("BuyPrice", System.Type.GetType("System.Double")));
        value.Table.Columns.Add(new DataColumn("VisitCount"));
        value.Table.Columns.Add(new DataColumn("Shelf"));
        value.Table.Columns.Add(new DataColumn("Bin"));
        value.Table.AcceptChanges();
        IEnumerator enumerator1;
        try
        {
          enumerator1 = value.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator1.Current;
            DataTable dataTable = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(current1["type"]).ToUpper(), "PART", false) != 0 ? (this.Trans == null ? App.DB.Product.Stock_Get_Locations(Conversions.ToInteger(current1["PartProductID"])).Table : App.DB.Product.Stock_Get_Locations(Conversions.ToInteger(current1["PartProductID"]), this.Trans).Table) : (this.Trans == null ? App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(current1["PartProductID"]), 0).Table : App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(current1["PartProductID"]), this.Trans, 0).Table);
            int WarehouseID = 0;
            int num = 0;
            string str1 = "";
            string str2 = "";
            IEnumerator enumerator2;
            try
            {
              enumerator2 = dataTable.Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current2 = (DataRow) enumerator2.Current;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current2["Type"], (object) "WAREHOUSE", false) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual(current2["Quantity"], current1["quantity"], false))
                {
                  WarehouseID = Conversions.ToInteger(current2["WarehouseID"]);
                  num = Conversions.ToInteger(current2["LocationID"]);
                  str1 = Conversions.ToString(current2["Shelf"]);
                  str2 = Conversions.ToString(current2["Bin"]);
                  break;
                }
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            if ((uint) WarehouseID > 0U)
            {
              current1["QuantityToOrder"] = RuntimeHelpers.GetObjectValue(current1["quantity"]);
              current1["GetFrom"] = (object) 3;
              current1["GetFromText"] = this.Trans == null ? (object) App.DB.Warehouse.Warehouse_Get(WarehouseID).Name : (object) App.DB.Warehouse.Warehouse_Get(WarehouseID, this.Trans).Name;
              current1["GetID"] = (object) num;
              current1["BuyPrice"] = (object) 0;
              current1["Shelf"] = (object) str1;
              current1["Bin"] = (object) str2;
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        this._PartsAndProducts = value;
        this._PartsAndProducts.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
        this._PartsAndProducts.AllowNew = false;
        this._PartsAndProducts.AllowEdit = true;
        this._PartsAndProducts.AllowDelete = false;
        this.dgPartsAndProducts.DataSource = (object) this.PartsAndProducts;
      }
    }

    public DataRow SelectedPartProductDataRow
    {
      get
      {
        return this.dgPartsAndProducts.CurrentRowIndex != -1 ? this.PartsAndProducts[this.dgPartsAndProducts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public bool NeedsTransaction
    {
      get
      {
        return this._NeedsTransaction;
      }
      set
      {
        this._NeedsTransaction = value;
      }
    }

    public DataView ChargesDataView
    {
      get
      {
        return this._ChargesDataView;
      }
      set
      {
        this._ChargesDataView = value;
        this._ChargesDataView.Table.TableName = Enums.TableNames.tblOrderCharge.ToString();
        this._ChargesDataView.AllowNew = false;
        this._ChargesDataView.AllowEdit = false;
        this._ChargesDataView.AllowDelete = false;
        this.dgCharges.DataSource = (object) this.ChargesDataView;
      }
    }

    private DataRow SelectedChargeDataRow
    {
      get
      {
        return this.dgCharges.CurrentRowIndex != -1 ? this.ChargesDataView[this.dgCharges.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public Enums.FormState PageState
    {
      get
      {
        return this._PageState;
      }
      set
      {
        this._PageState = value;
        switch (this.PageState)
        {
          case Enums.FormState.Insert:
            this.btnSave.Text = "Add";
            break;
          case Enums.FormState.Update:
            this.btnSave.Text = "Update";
            break;
        }
        this.txtAmount.Text = "";
        ComboBox cboChargeType = this.cboChargeType;
        Combo.SetSelectedComboItem_By_Value(ref cboChargeType, Conversions.ToString(0));
        this.cboChargeType = cboChargeType;
      }
    }

    public void SetupVisitsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgEngineerVisits, false);
      DataGridTableStyle tableStyle = this.dgEngineerVisits.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "#";
      dataGridLabelColumn1.MappingName = "VisitCount";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 50;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Customer";
      dataGridLabelColumn2.MappingName = "Customer";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Property";
      dataGridLabelColumn3.MappingName = "Site";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Job Number";
      dataGridLabelColumn4.MappingName = "JobNumber";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "PO Number";
      dataGridLabelColumn5.MappingName = "PONumber";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Definition";
      dataGridLabelColumn6.MappingName = "JobDefinition";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Notes To Engineer";
      dataGridLabelColumn7.MappingName = "NotesToEngineer";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Type";
      dataGridLabelColumn8.MappingName = "Type";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 75;
      dataGridLabelColumn8.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Status";
      dataGridLabelColumn9.MappingName = "VisitStatus";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 75;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "dd/MMM/yyyy";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Date";
      dataGridLabelColumn10.MappingName = "startdatetime";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 100;
      dataGridLabelColumn10.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisit.ToString();
      this.dgEngineerVisits.TableStyles.Add(tableStyle);
    }

    public void SetupPartsAndProductsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgPartsAndProducts, false);
      DataGridTableStyle tableStyle = this.dgPartsAndProducts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgPartsAndProducts.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 75;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Number";
      dataGridLabelColumn2.MappingName = "number";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 120;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Name";
      dataGridLabelColumn3.MappingName = "Name";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 130;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      if (this.Trans != null)
      {
        DataGridComboBoxColumn gridComboBoxColumn = new DataGridComboBoxColumn(this.Trans, true);
        gridComboBoxColumn.HeaderText = "Get From (Select)";
        gridComboBoxColumn.MappingName = "GetFrom";
        gridComboBoxColumn.ReadOnly = false;
        gridComboBoxColumn.Width = 150;
        gridComboBoxColumn.ComboBox.DataSource = (object) App.DB.Order.Get_All_Places_Item_Can_Be_Got_From().Table;
        gridComboBoxColumn.ComboBox.DisplayMember = "DisplayMember";
        gridComboBoxColumn.ComboBox.ValueMember = "ValueMember";
        gridComboBoxColumn.itemSelected += new DataGridComboBoxColumn.itemSelectedEventHandler(this.ItemSelected);
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn);
      }
      else
      {
        DataGridComboBoxColumn gridComboBoxColumn = new DataGridComboBoxColumn(true);
        gridComboBoxColumn.HeaderText = "Get From (Select)";
        gridComboBoxColumn.MappingName = "GetFrom";
        gridComboBoxColumn.ReadOnly = false;
        gridComboBoxColumn.Width = 150;
        gridComboBoxColumn.ComboBox.DataSource = (object) App.DB.Order.Get_All_Places_Item_Can_Be_Got_From().Table;
        gridComboBoxColumn.ComboBox.DisplayMember = "DisplayMember";
        gridComboBoxColumn.ComboBox.ValueMember = "ValueMember";
        gridComboBoxColumn.itemSelected += new DataGridComboBoxColumn.itemSelectedEventHandler(this.ItemSelected);
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn);
      }
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "From";
      dataGridLabelColumn4.MappingName = "GetFromText";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 130;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Shelf";
      dataGridLabelColumn5.MappingName = "Shelf";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Bin";
      dataGridLabelColumn6.MappingName = "Bin";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridEditableTextBoxColumn editableTextBoxColumn1 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn1.Format = "C";
      editableTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn1.HeaderText = "Pack/Unit Buy Price";
      editableTextBoxColumn1.MappingName = "BuyPrice";
      editableTextBoxColumn1.ReadOnly = false;
      editableTextBoxColumn1.Width = 105;
      editableTextBoxColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn1);
      DataGridEditableTextBoxColumn editableTextBoxColumn2 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn2.Format = "C";
      editableTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn2.HeaderText = "Unit Sell Price";
      editableTextBoxColumn2.MappingName = "Sellprice";
      editableTextBoxColumn2.ReadOnly = false;
      editableTextBoxColumn2.Width = 100;
      editableTextBoxColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn2);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Qty Needed";
      dataGridLabelColumn7.MappingName = "quantity";
      dataGridLabelColumn7.ReadOnly = false;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridEditableTextBoxColumn editableTextBoxColumn3 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn3.Format = "";
      editableTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn3.HeaderText = "Qty Packs/Units to Order";
      editableTextBoxColumn3.MappingName = "QuantityToOrder";
      if (this.EngineerVisitID > 0)
        editableTextBoxColumn3.ReadOnly = true;
      else
        editableTextBoxColumn3.ReadOnly = false;
      editableTextBoxColumn3.Width = 120;
      editableTextBoxColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn3);
      if (this.OrderType == Enums.OrderType.Job & this.EngineerVisitID == 0)
      {
        DataGridComboBoxColumn gridComboBoxColumn = new DataGridComboBoxColumn(false);
        gridComboBoxColumn.HeaderText = "Visit # (Select)";
        gridComboBoxColumn.MappingName = "VisitCount";
        gridComboBoxColumn.ReadOnly = false;
        gridComboBoxColumn.Width = 90;
        gridComboBoxColumn.ComboBox.DataSource = (object) this.EngineerVisitsDataView.Table;
        gridComboBoxColumn.ComboBox.DisplayMember = "VisitCount";
        gridComboBoxColumn.ComboBox.ValueMember = "VisitCount";
        gridComboBoxColumn.ComboBox.SelectedValue = (object) 1;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn);
      }
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
      this.dgPartsAndProducts.TableStyles.Add(tableStyle);
    }

    public void SetupChargesDatagrid()
    {
      Helper.SetUpDataGrid(this.dgCharges, false);
      DataGridTableStyle tableStyle = this.dgCharges.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "ChargeType";
      dataGridLabelColumn1.MappingName = "ChargeType";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "C";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Amount";
      dataGridLabelColumn2.MappingName = "Amount";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 130;
      dataGridLabelColumn2.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblOrderCharge.ToString();
      this.dgCharges.TableStyles.Add(tableStyle);
    }

    public void ItemSelected()
    {
      if ((uint) ((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID > 0U)
      {
        this.SelectedPartProductDataRow["GetID"] = (object) ((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID;
        string searchingFor = ((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).SearchingFor;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(searchingFor, "Supplier", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(searchingFor, "Van", false) != 0)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(searchingFor, "Warehouse", false) == 0)
            {
              DataTable dataTable = (DataTable) null;
              if (this.Trans != null)
              {
                this.SelectedPartProductDataRow["GetFromText"] = (object) App.DB.Warehouse.Warehouse_GetByLocationID(((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID, this.Trans).Name;
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(this.SelectedPartProductDataRow["type"]).ToUpper(), "PART", false) == 0)
                  dataTable = App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(this.SelectedPartProductDataRow["PartProductID"]), this.Trans, 0).Table;
              }
              else
              {
                this.SelectedPartProductDataRow["GetFromText"] = (object) App.DB.Warehouse.Warehouse_GetByLocationID(((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID).Name;
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(this.SelectedPartProductDataRow["type"]).ToUpper(), "PART", false) == 0)
                  dataTable = App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(this.SelectedPartProductDataRow["PartProductID"]), 0).Table;
              }
              string str1 = "";
              string str2 = "";
              IEnumerator enumerator;
              if (dataTable != null)
              {
                try
                {
                  enumerator = dataTable.Rows.GetEnumerator();
                  while (enumerator.MoveNext())
                  {
                    DataRow current = (DataRow) enumerator.Current;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedPartProductDataRow["GetID"], current["LocationID"], false))
                    {
                      str1 = Conversions.ToString(current["Shelf"]);
                      str2 = Conversions.ToString(current["Bin"]);
                      break;
                    }
                  }
                }
                finally
                {
                  if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
                }
              }
              this.SelectedPartProductDataRow["BuyPrice"] = (object) 0;
              this.SelectedPartProductDataRow["GetFrom"] = (object) 3;
              this.SelectedPartProductDataRow["QuantityToOrder"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductDataRow["Quantity"]);
              this.SelectedPartProductDataRow["Shelf"] = (object) str1;
              this.SelectedPartProductDataRow["Bin"] = (object) str2;
            }
          }
          else
          {
            this.SelectedPartProductDataRow["GetFromText"] = this.Trans == null ? (object) App.DB.Van.Van_GetByLocationID(((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID).Registration : (object) App.DB.Van.Van_GetByLocationID(((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID, this.Trans).Registration;
            this.SelectedPartProductDataRow["BuyPrice"] = (object) 0;
            this.SelectedPartProductDataRow["GetFrom"] = (object) 2;
            this.SelectedPartProductDataRow["QuantityToOrder"] = RuntimeHelpers.GetObjectValue(this.SelectedPartProductDataRow["Quantity"]);
            this.SelectedPartProductDataRow["Shelf"] = (object) "";
            this.SelectedPartProductDataRow["Bin"] = (object) "";
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedPartProductDataRow["Type"], (object) "Product", false))
        {
          ProductSupplier productSupplier = this.Trans == null ? App.DB.ProductSupplier.ProductSupplier_Get(((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID) : App.DB.ProductSupplier.ProductSupplier_Get(((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID, this.Trans);
          Supplier supplier = this.Trans == null ? App.DB.Supplier.Supplier_Get(productSupplier.SupplierID) : App.DB.Supplier.Supplier_Get(productSupplier.SupplierID, this.Trans);
          this.SelectedPartProductDataRow["BuyPrice"] = (object) productSupplier.Price;
          this.SelectedPartProductDataRow["GetFromText"] = (object) supplier.Name;
          this.SelectedPartProductDataRow["SupplierID"] = (object) supplier.SupplierID;
          if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedPartProductDataRow["Quantity"])) == 0)
            this.SelectedPartProductDataRow["Quantity"] = (object) 1;
          this.SelectedPartProductDataRow["QuantityToOrder"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object) null, typeof (Math), "Ceiling", new object[1]
          {
            Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(this.SelectedPartProductDataRow["Quantity"], (object) productSupplier.QuantityInPack)
          }, (string[]) null, (System.Type[]) null, (bool[]) null));
          this.SelectedPartProductDataRow["GetFrom"] = (object) 1;
          this.SelectedPartProductDataRow["Shelf"] = (object) "";
          this.SelectedPartProductDataRow["Bin"] = (object) "";
        }
        else
        {
          PartSupplier partSupplier = this.Trans == null ? App.DB.PartSupplier.PartSupplier_Get(((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID) : App.DB.PartSupplier.PartSupplier_Get(((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID, this.Trans);
          Supplier supplier = this.Trans == null ? App.DB.Supplier.Supplier_Get(partSupplier.SupplierID) : App.DB.Supplier.Supplier_Get(partSupplier.SupplierID, this.Trans);
          this.SelectedPartProductDataRow["BuyPrice"] = (object) partSupplier.Price;
          this.SelectedPartProductDataRow["GetFromText"] = (object) supplier.Name;
          this.SelectedPartProductDataRow["SupplierID"] = (object) supplier.SupplierID;
          if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedPartProductDataRow["Quantity"])) == 0)
            this.SelectedPartProductDataRow["Quantity"] = (object) 1;
          this.SelectedPartProductDataRow["QuantityToOrder"] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object) null, typeof (Math), "Ceiling", new object[1]
          {
            Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(this.SelectedPartProductDataRow["Quantity"], (object) partSupplier.QuantityInPack)
          }, (string[]) null, (System.Type[]) null, (bool[]) null));
          this.SelectedPartProductDataRow["GetFrom"] = (object) 1;
          this.SelectedPartProductDataRow["Shelf"] = (object) "";
          this.SelectedPartProductDataRow["Bin"] = (object) "";
        }
      }
      else
      {
        ((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ComboBox.SelectedValue = (object) 0;
        this.SelectedPartProductDataRow["GetID"] = (object) "0";
        this.SelectedPartProductDataRow["QuantityToOrder"] = (object) "0";
        this.SelectedPartProductDataRow["BuyPrice"] = (object) "0";
        this.SelectedPartProductDataRow["QuantityToOrder"] = (object) 1;
        this.SelectedPartProductDataRow["GetFromText"] = (object) "";
        this.SelectedPartProductDataRow["Shelf"] = (object) "";
        this.SelectedPartProductDataRow["Bin"] = (object) "";
      }
      this.SelectedPartProductDataRow.AcceptChanges();
      this.SelectedPartProductDataRow.Table.AcceptChanges();
      Application.DoEvents();
    }

    public bool validatePartsAndProducts()
    {
      string empty = string.Empty;
      IEnumerator enumerator;
      try
      {
        enumerator = this.PartsAndProducts.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["GetFrom"])))
            empty = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) empty, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "You must select where to get Item : ", current["Name"]), (object) " : "), current["Number"]), (object) " from "), (object) "\r\n")));
          else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["GetFrom"])), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["GetFrom"], (object) 0, false))))
            empty = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) empty, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "You must select where to get Item : ", current["Name"]), (object) " : "), current["Number"]), (object) " from "), (object) "\r\n")));
          if (this.EngineerVisitID == 0 & this.OrderType == Enums.OrderType.Job)
          {
            if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["VisitCount"])))
              empty = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) empty, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "You must select a visit for item : ", current["Name"]), (object) " : "), current["Number"]), (object) "\r\n")));
            else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["VisitCount"])), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["VisitCount"], (object) 0, false))))
              empty = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) empty, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "You must select a visit for item : ", current["Name"]), (object) " : "), current["Number"]), (object) "\r\n")));
          }
          if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["SellPrice"])))
            empty = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) empty, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "You must set a sell price for item : ", current["Name"]), (object) " : "), current["Number"]), (object) "\r\n")));
          else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["SellPrice"])), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["SellPrice"], (object) 0, false))))
            empty = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) empty, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "You must set a sell price for item : ", current["Name"]), (object) " : "), current["Number"]), (object) "\r\n")));
          if (empty.Length > 0)
          {
            int num = (int) App.ShowMessage(empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return false;
          }
          object Left = current["GetFrom"];
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) "1", false))
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Product", false))
              new OrderProductValidator().Validate(new OrderProduct()
              {
                SetBuyPrice = RuntimeHelpers.GetObjectValue(current["BuyPrice"]),
                SetSellPrice = RuntimeHelpers.GetObjectValue(current["SellPrice"]),
                SetQuantity = RuntimeHelpers.GetObjectValue(current["QuantityToOrder"]),
                SetProductSupplierID = RuntimeHelpers.GetObjectValue(current["GetID"])
              });
            else
              new OrderPartValidator().Validate(new OrderPart()
              {
                SetBuyPrice = RuntimeHelpers.GetObjectValue(current["BuyPrice"]),
                SetSellPrice = RuntimeHelpers.GetObjectValue(current["SellPrice"]),
                SetQuantity = RuntimeHelpers.GetObjectValue(current["QuantityToOrder"]),
                SetPartSupplierID = RuntimeHelpers.GetObjectValue(current["GetID"])
              });
          }
          else if (Conversions.ToBoolean((object) (bool) (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(Left, (object) "2", false)) ? 1 : (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(Left, (object) "3", false)) ? 1 : 0))))
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Product", false))
            {
              FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct = new FSM.Entity.OrderLocationProduct.OrderLocationProduct();
              oOrderLocationProduct.SetProductID = RuntimeHelpers.GetObjectValue(current["PartProductID"]);
              oOrderLocationProduct.SetSellPrice = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
              oOrderLocationProduct.SetQuantity = RuntimeHelpers.GetObjectValue(current["QuantityToOrder"]);
              oOrderLocationProduct.SetLocationID = RuntimeHelpers.GetObjectValue(current["GetID"]);
              OrderLocationProductValidator productValidator = new OrderLocationProductValidator();
              if (this.Trans != null)
                productValidator.Validate(oOrderLocationProduct, this.Trans);
              else
                productValidator.Validate(oOrderLocationProduct);
            }
            else
            {
              FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart = new FSM.Entity.OrderLocationPart.OrderLocationPart();
              oOrderLocationPart.SetPartID = RuntimeHelpers.GetObjectValue(current["PartProductID"]);
              oOrderLocationPart.SetSellPrice = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
              oOrderLocationPart.SetQuantity = RuntimeHelpers.GetObjectValue(current["QuantityToOrder"]);
              oOrderLocationPart.SetLocationID = RuntimeHelpers.GetObjectValue(current["GetID"]);
              OrderLocationPartValidator locationPartValidator = new OrderLocationPartValidator();
              if (this.Trans != null)
                locationPartValidator.Validate(oOrderLocationPart, this.Trans);
              else
                locationPartValidator.Validate(oOrderLocationPart);
            }
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return true;
    }

    private void FRMConvertToAnOrder_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.lblinformation.Text = "Please Select where to get each item from by clicking in the Grid";
    }

    private void dgPartsAndProducts_CurrentCellChanged(object sender, EventArgs e)
    {
      ((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).TheID = Conversions.ToInteger(this.SelectedPartProductDataRow["PartProductID"]);
      ((DataGridComboBoxColumn) this.dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).Type = Conversions.ToString(this.SelectedPartProductDataRow["Type"]);
    }

    private void chkAwaiting_CheckedChanged(object sender, EventArgs e)
    {
      this.chkConfirmed.Checked = !this.chkAwaiting.Checked;
    }

    private void chkConfirmed_CheckedChanged(object sender, EventArgs e)
    {
      this.chkAwaiting.Checked = !this.chkConfirmed.Checked;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage("Are you sure you wish to cancel the auto creation of this order? You will need to manually create the order at a later date.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      this.DialogResult = DialogResult.Cancel;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      SqlConnection sqlConnection;
      if (this.NeedsTransaction)
      {
        sqlConnection = new SqlConnection(App.DB.ServerConnectionString);
        sqlConnection.Open();
        this.Trans = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
      }
      ArrayList arrayList1 = new ArrayList();
      bool flag;
      try
      {
        if (!this.validatePartsAndProducts())
          return;
        if (this.txtDepartment.Text.Trim().Length == 0 & this.chkConfirmed.Checked)
        {
          int num = (int) App.ShowMessage("Department Reference missing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          return;
        }
        string str1 = "";
        string[] strArray = App.loggedInUser.Fullname.Split(' ');
        int index1 = 0;
        while (index1 < strArray.Length)
        {
          string str2 = strArray[index1];
          str1 += str2.Substring(0, 1);
          checked { ++index1; }
        }
        if (this.OrderType == Enums.OrderType.Job)
        {
          Cursor.Current = Cursors.WaitCursor;
          IEnumerator enumerator1;
          if (this.EngineerVisitID > 0)
          {
            Hashtable hashtable1 = new Hashtable();
            DataRow[] dataRowArray1 = this.PartsAndProducts.Table.Select("GetFrom = 1");
            int index2 = 0;
            while (index2 < dataRowArray1.Length)
            {
              DataRow dataRow = dataRowArray1[index2];
              if (!hashtable1.Contains(RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])))
              {
                EngineerVisitOrder oEngineerVisitOrder = new EngineerVisitOrder();
                Job job = this.Trans == null ? App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisitID) : App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisitID, this.Trans);
                Order oOrder = new Order();
                if (this.Trans != null)
                  oOrder.SetOrderReference = (object) (str1 + job.JobNumber + "_V" + Conversions.ToString(this.EngineerVisitID) + "-" + Conversions.ToString(checked (App.DB.Order.Order_Get_ByRef(str1 + job.JobNumber + "_V" + Conversions.ToString(this.EngineerVisitID) + "-", this.Trans).Table.Rows.Count + 1)));
                else
                  oOrder.SetOrderReference = (object) (str1 + job.JobNumber + "_V" + Conversions.ToString(this.EngineerVisitID) + "-" + Conversions.ToString(checked (App.DB.Order.Order_Get_ByRef(str1 + job.JobNumber + "_V" + Conversions.ToString(this.EngineerVisitID) + "-").Table.Rows.Count + 1)));
                oOrder.SetOrderTypeID = (object) 4;
                oOrder.SetUserID = (object) App.loggedInUser.UserID;
                oOrder.DeliveryDeadline = this.dtpDeadline.Value.Date;
                oOrder.DatePlaced = DateAndTime.Now;
                if (this.chkAwaiting.Checked)
                {
                  oOrder.SetOrderStatusID = (object) 1;
                }
                else
                {
                  oOrder.SetOrderStatusID = (object) 2;
                  this.chkDoNotConsolidate.Checked = true;
                }
                oOrder.SetDepartmentRef = (object) this.txtDepartment.Text;
                Order order = this.Trans == null ? App.DB.Order.Insert(oOrder) : App.DB.Order.Insert(oOrder, this.Trans);
                IEnumerator enumerator2;
                try
                {
                  enumerator2 = this.ChargesDataView.Table.Rows.GetEnumerator();
                  while (enumerator2.MoveNext())
                  {
                    DataRow current = (DataRow) enumerator2.Current;
                    App.DB.OrderCharge.Insert(new OrderCharge()
                    {
                      SetAmount = RuntimeHelpers.GetObjectValue(current["Amount"]),
                      SetOrderChargeTypeID = RuntimeHelpers.GetObjectValue(current["OrderChargeTypeID"]),
                      SetOrderID = (object) order.OrderID,
                      SetReference = RuntimeHelpers.GetObjectValue(current["Reference"])
                    });
                  }
                }
                finally
                {
                  if (enumerator2 is IDisposable)
                    (enumerator2 as IDisposable).Dispose();
                }
                if (App.ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                  int record = App.FindRecord(Enums.TableNames.tblWarehouse, this.Trans, 0, "");
                  if (record > 0)
                    oEngineerVisitOrder.SetWarehouseID = (object) record;
                }
                oEngineerVisitOrder.SetEngineerVisitID = (object) this.EngineerVisitID;
                oEngineerVisitOrder.SetOrderID = (object) order.OrderID;
                EngineerVisitOrder engineerVisitOrder = this.Trans == null ? App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder) : App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, this.Trans);
                EngineerVisit oEngineerVisit = this.Trans == null ? App.DB.EngineerVisits.EngineerVisits_Get_As_Object(this.EngineerVisitID, true) : App.DB.EngineerVisits.EngineerVisits_Get_As_Object(this.EngineerVisitID, this.Trans);
                if (oEngineerVisit.StatusEnumID < 5)
                {
                  oEngineerVisit.SetStatusEnumID = (object) 2;
                  if (this.Trans != null)
                    App.DB.EngineerVisits.Update(oEngineerVisit, 0, true, this.Trans);
                  else
                    App.DB.EngineerVisits.Update(oEngineerVisit, 0, true);
                }
                arrayList1.Add((object) new object[2]
                {
                  (object) order.OrderID,
                  (object) this.EngineerVisitID
                });
                hashtable1.Add(RuntimeHelpers.GetObjectValue(dataRow["SupplierID"]), (object) order);
              }
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["Type"], (object) "Product", false))
              {
                OrderProduct oOrderProduct = new OrderProduct();
                oOrderProduct.SetOrderID = (object) ((Order) hashtable1[RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])]).OrderID;
                oOrderProduct.SetBuyPrice = RuntimeHelpers.GetObjectValue(dataRow["BuyPrice"]);
                oOrderProduct.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
                oOrderProduct.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
                oOrderProduct.SetProductSupplierID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
                OrderProduct orderProduct = this.Trans == null ? App.DB.OrderProduct.Insert(oOrderProduct, !this.chkDoNotConsolidate.Checked) : App.DB.OrderProduct.Insert(oOrderProduct, !this.chkDoNotConsolidate.Checked, this.Trans);
                try
                {
                  dataRow["OrderItemID"] = (object) orderProduct.OrderProductID;
                  dataRow["OrderLocationTypeID"] = (object) 1;
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  ProjectData.ClearProjectError();
                }
              }
              else
              {
                OrderPart oOrderPart = new OrderPart();
                oOrderPart.SetOrderID = (object) ((Order) hashtable1[RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])]).OrderID;
                oOrderPart.SetBuyPrice = RuntimeHelpers.GetObjectValue(dataRow["BuyPrice"]);
                oOrderPart.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
                oOrderPart.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
                oOrderPart.SetPartSupplierID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
                OrderPart orderPart = this.Trans == null ? App.DB.OrderPart.Insert(oOrderPart, !this.chkDoNotConsolidate.Checked) : App.DB.OrderPart.Insert(oOrderPart, !this.chkDoNotConsolidate.Checked, this.Trans);
                try
                {
                  dataRow["OrderItemID"] = (object) orderPart.OrderPartID;
                  dataRow["OrderLocationTypeID"] = (object) 1;
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  ProjectData.ClearProjectError();
                }
              }
              checked { ++index2; }
            }
            Hashtable hashtable2 = new Hashtable();
            DataRow[] dataRowArray2 = this.PartsAndProducts.Table.Select("GetFrom = 2 OR GetFrom = 3");
            int index3 = 0;
            while (index3 < dataRowArray2.Length)
            {
              DataRow dataRow = dataRowArray2[index3];
              if (!hashtable2.Contains(RuntimeHelpers.GetObjectValue(dataRow["GetID"])))
              {
                EngineerVisitOrder oEngineerVisitOrder = new EngineerVisitOrder();
                Job job = this.Trans == null ? App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisitID) : App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngineerVisitID, this.Trans);
                Order oOrder = new Order();
                if (this.Trans != null)
                  oOrder.SetOrderReference = (object) (str1 + job.JobNumber + "_V" + Conversions.ToString(this.EngineerVisitID) + "-" + Conversions.ToString(checked (App.DB.Order.Order_Get_ByRef(str1 + job.JobNumber + "_V" + Conversions.ToString(this.EngineerVisitID) + "-", this.Trans).Table.Rows.Count + 1)));
                else
                  oOrder.SetOrderReference = (object) (str1 + job.JobNumber + "_V" + Conversions.ToString(this.EngineerVisitID) + "-" + Conversions.ToString(checked (App.DB.Order.Order_Get_ByRef(str1 + job.JobNumber + "_V" + Conversions.ToString(this.EngineerVisitID) + "-").Table.Rows.Count + 1)));
                oOrder.SetOrderTypeID = (object) 4;
                oOrder.SetUserID = (object) App.loggedInUser.UserID;
                oOrder.DeliveryDeadline = this.dtpDeadline.Value.Date;
                oOrder.DatePlaced = DateAndTime.Now;
                if (this.chkAwaiting.Checked)
                {
                  oOrder.SetOrderStatusID = (object) 1;
                }
                else
                {
                  oOrder.SetOrderStatusID = (object) 2;
                  this.chkDoNotConsolidate.Checked = true;
                }
                Order order = this.Trans == null ? App.DB.Order.Insert(oOrder) : App.DB.Order.Insert(oOrder, this.Trans);
                if (App.ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                  int num = this.Trans == null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse, 0, "", false)) : App.FindRecord(Enums.TableNames.tblWarehouse, this.Trans, 0, "");
                  if (num > 0)
                    oEngineerVisitOrder.SetWarehouseID = (object) num;
                }
                oEngineerVisitOrder.SetEngineerVisitID = (object) this.EngineerVisitID;
                oEngineerVisitOrder.SetOrderID = (object) order.OrderID;
                EngineerVisitOrder engineerVisitOrder = this.Trans == null ? App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder) : App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, this.Trans);
                EngineerVisit oEngineerVisit = this.Trans == null ? App.DB.EngineerVisits.EngineerVisits_Get_As_Object(this.EngineerVisitID, true) : App.DB.EngineerVisits.EngineerVisits_Get_As_Object(this.EngineerVisitID, this.Trans);
                if (oEngineerVisit.StatusEnumID < 5)
                {
                  oEngineerVisit.SetStatusEnumID = (object) 2;
                  if (this.Trans != null)
                    App.DB.EngineerVisits.Update(oEngineerVisit, 0, true, this.Trans);
                  else
                    App.DB.EngineerVisits.Update(oEngineerVisit, 0, true);
                }
                arrayList1.Add((object) new object[2]
                {
                  (object) order.OrderID,
                  (object) this.EngineerVisitID
                });
                hashtable2.Add(RuntimeHelpers.GetObjectValue(dataRow["GetID"]), (object) order);
              }
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["Type"], (object) "Product", false))
              {
                FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct = new FSM.Entity.OrderLocationProduct.OrderLocationProduct();
                oOrderLocationProduct.SetProductID = RuntimeHelpers.GetObjectValue(dataRow["PartProductID"]);
                oOrderLocationProduct.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
                oOrderLocationProduct.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
                oOrderLocationProduct.SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
                oOrderLocationProduct.SetOrderID = (object) ((Order) hashtable2[RuntimeHelpers.GetObjectValue(dataRow["GetID"])]).OrderID;
                FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct = this.Trans == null ? App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !this.chkDoNotConsolidate.Checked) : App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !this.chkDoNotConsolidate.Checked, this.Trans);
                dataRow["OrderItemID"] = (object) orderLocationProduct.OrderLocationProductID;
                dataRow["OrderLocationTypeID"] = (object) 3;
                ProductTransaction oProductTransaction = new ProductTransaction();
                oProductTransaction.IgnoreExceptionsOnSetMethods = true;
                oProductTransaction.SetOrderLocationProductID = (object) orderLocationProduct.OrderLocationProductID;
                oProductTransaction.SetTransactionTypeID = (object) 5;
                oProductTransaction.SetProductID = (object) orderLocationProduct.ProductID;
                oProductTransaction.SetAmount = (object) checked (-orderLocationProduct.Quantity);
                oProductTransaction.SetLocationID = (object) orderLocationProduct.LocationID;
                ProductTransaction productTransaction = this.Trans == null ? App.DB.ProductTransaction.Insert(oProductTransaction) : App.DB.ProductTransaction.Insert(oProductTransaction, this.Trans);
              }
              else
              {
                FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart = new FSM.Entity.OrderLocationPart.OrderLocationPart();
                oOrderLocationPart.SetPartID = RuntimeHelpers.GetObjectValue(dataRow["PartProductID"]);
                oOrderLocationPart.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
                oOrderLocationPart.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
                oOrderLocationPart.SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
                oOrderLocationPart.SetOrderID = (object) ((Order) hashtable2[RuntimeHelpers.GetObjectValue(dataRow["GetID"])]).OrderID;
                FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart = this.Trans == null ? App.DB.OrderLocationPart.Insert(oOrderLocationPart, !this.chkDoNotConsolidate.Checked) : App.DB.OrderLocationPart.Insert(oOrderLocationPart, !this.chkDoNotConsolidate.Checked, this.Trans);
                dataRow["OrderItemID"] = (object) orderLocationPart.OrderLocationPartID;
                dataRow["OrderLocationTypeID"] = (object) 3;
                App.DB.PartTransaction.Insert(new PartTransaction()
                {
                  IgnoreExceptionsOnSetMethods = true,
                  SetOrderLocationPartID = (object) orderLocationPart.OrderLocationPartID,
                  SetTransactionTypeID = (object) 5,
                  SetPartID = (object) orderLocationPart.PartID,
                  SetAmount = (object) checked (-orderLocationPart.Quantity),
                  SetLocationID = (object) orderLocationPart.LocationID
                }, this.Trans);
              }
              checked { ++index3; }
            }
          }
          else
          {
            try
            {
              enumerator1 = this.EngineerVisitsDataView.Table.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current = (DataRow) enumerator1.Current;
                Hashtable hashtable1 = new Hashtable();
                DataRow[] dataRowArray1 = this.PartsAndProducts.Table.Select("GetFrom = 1");
                int index2 = 0;
                while (index2 < dataRowArray1.Length)
                {
                  DataRow dataRow = dataRowArray1[index2];
                  if (!hashtable1.Contains(RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])) && this.PartsAndProducts.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "VisitCount = ", current["VisitCount"]))).Length > 0)
                  {
                    Order oOrder = new Order();
                    oOrder.SetOrderReference = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) (str1 + "ENG-"), current["EngineerVisitID"]), (object) "-"), (object) checked (hashtable1.Count + 1));
                    oOrder.SetOrderTypeID = (object) 4;
                    oOrder.SetUserID = (object) App.loggedInUser.UserID;
                    oOrder.DeliveryDeadline = this.dtpDeadline.Value.Date;
                    oOrder.DatePlaced = DateAndTime.Now;
                    if (this.chkAwaiting.Checked)
                    {
                      oOrder.SetOrderStatusID = (object) 1;
                    }
                    else
                    {
                      oOrder.SetOrderStatusID = (object) 2;
                      this.chkDoNotConsolidate.Checked = true;
                    }
                    oOrder.SetDepartmentRef = (object) this.txtDepartment.Text;
                    Order order = this.Trans == null ? App.DB.Order.Insert(oOrder) : App.DB.Order.Insert(oOrder, this.Trans);
                    EngineerVisitOrder oEngineerVisitOrder = new EngineerVisitOrder();
                    if (App.ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                      int num = this.Trans == null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse, 0, "", false)) : App.FindRecord(Enums.TableNames.tblWarehouse, this.Trans, 0, "");
                      if (num > 0)
                        oEngineerVisitOrder.SetWarehouseID = (object) num;
                    }
                    oEngineerVisitOrder.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(current["EngineerVisitID"]);
                    oEngineerVisitOrder.SetOrderID = (object) order.OrderID;
                    EngineerVisitOrder engineerVisitOrder = this.Trans == null ? App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder) : App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, this.Trans);
                    EngineerVisit oEngineerVisit = this.Trans == null ? App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(current["EngineerVisitID"]), true) : App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(current["EngineerVisitID"]), this.Trans);
                    if (oEngineerVisit.StatusEnumID < 5)
                    {
                      oEngineerVisit.SetStatusEnumID = (object) 2;
                      if (this.Trans != null)
                        App.DB.EngineerVisits.Update(oEngineerVisit, 0, true, this.Trans);
                      else
                        App.DB.EngineerVisits.Update(oEngineerVisit, 0, true);
                    }
                    hashtable1.Add(RuntimeHelpers.GetObjectValue(dataRow["SupplierID"]), (object) order);
                    arrayList1.Add((object) new object[2]
                    {
                      (object) order.OrderID,
                      current["EngineerVisitID"]
                    });
                  }
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["VisitCount"], current["VisitCount"], false))
                  {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["Type"], (object) "Product", false))
                    {
                      OrderProduct oOrderProduct = new OrderProduct();
                      oOrderProduct.SetOrderID = (object) ((Order) hashtable1[RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])]).OrderID;
                      oOrderProduct.SetBuyPrice = RuntimeHelpers.GetObjectValue(dataRow["BuyPrice"]);
                      oOrderProduct.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
                      oOrderProduct.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
                      oOrderProduct.SetProductSupplierID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
                      OrderProduct orderProduct = this.Trans == null ? App.DB.OrderProduct.Insert(oOrderProduct, !this.chkDoNotConsolidate.Checked) : App.DB.OrderProduct.Insert(oOrderProduct, !this.chkDoNotConsolidate.Checked, this.Trans);
                      dataRow["OrderItemID"] = (object) orderProduct.OrderProductID;
                    }
                    else
                    {
                      OrderPart oOrderPart = new OrderPart();
                      oOrderPart.SetOrderID = (object) ((Order) hashtable1[RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])]).OrderID;
                      oOrderPart.SetBuyPrice = RuntimeHelpers.GetObjectValue(dataRow["BuyPrice"]);
                      oOrderPart.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
                      oOrderPart.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
                      oOrderPart.SetPartSupplierID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
                      OrderPart orderPart = this.Trans == null ? App.DB.OrderPart.Insert(oOrderPart, !this.chkDoNotConsolidate.Checked) : App.DB.OrderPart.Insert(oOrderPart, !this.chkDoNotConsolidate.Checked, this.Trans);
                      dataRow["OrderItemID"] = (object) orderPart.OrderPartID;
                    }
                  }
                  checked { ++index2; }
                }
                Hashtable hashtable2 = new Hashtable();
                DataRow[] dataRowArray2 = this.PartsAndProducts.Table.Select("GetFrom = 2 OR GetFrom = 3");
                int index3 = 0;
                while (index3 < dataRowArray2.Length)
                {
                  DataRow dataRow = dataRowArray2[index3];
                  if (!hashtable2.Contains(RuntimeHelpers.GetObjectValue(dataRow["GetID"])) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["VisitCount"], current["VisitCount"], false))
                  {
                    Order oOrder = new Order();
                    oOrder.SetOrderReference = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) (str1 + "ENG-"), current["EngineerVisitID"]), (object) "-"), (object) checked (hashtable2.Count + 1));
                    oOrder.SetOrderTypeID = (object) 4;
                    oOrder.SetUserID = (object) App.loggedInUser.UserID;
                    oOrder.DeliveryDeadline = this.dtpDeadline.Value.Date;
                    oOrder.DatePlaced = DateAndTime.Now;
                    if (this.chkAwaiting.Checked)
                    {
                      oOrder.SetOrderStatusID = (object) 1;
                    }
                    else
                    {
                      oOrder.SetOrderStatusID = (object) 2;
                      this.chkDoNotConsolidate.Checked = true;
                    }
                    oOrder.SetDepartmentRef = (object) this.txtDepartment.Text;
                    Order order = this.Trans == null ? App.DB.Order.Insert(oOrder) : App.DB.Order.Insert(oOrder, this.Trans);
                    EngineerVisitOrder oEngineerVisitOrder = new EngineerVisitOrder();
                    if (App.ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse, 0, "", false));
                      if (integer > 0)
                        oEngineerVisitOrder.SetWarehouseID = (object) integer;
                    }
                    oEngineerVisitOrder.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(current["EngineerVisitID"]);
                    oEngineerVisitOrder.SetOrderID = (object) order.OrderID;
                    EngineerVisitOrder engineerVisitOrder = this.Trans == null ? App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder) : App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, this.Trans);
                    EngineerVisit oEngineerVisit = this.Trans == null ? App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(current["EngineerVisitID"]), true) : App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(current["EngineerVisitID"]), this.Trans);
                    if (oEngineerVisit.StatusEnumID < 5)
                    {
                      oEngineerVisit.SetStatusEnumID = (object) 2;
                      if (this.Trans != null)
                        App.DB.EngineerVisits.Update(oEngineerVisit, 0, true, this.Trans);
                      else
                        App.DB.EngineerVisits.Update(oEngineerVisit, 0, true);
                    }
                    hashtable2.Add(RuntimeHelpers.GetObjectValue(dataRow["GetID"]), (object) order);
                    arrayList1.Add((object) new object[2]
                    {
                      (object) order.OrderID,
                      current["EngineerVisitID"]
                    });
                  }
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["VisitCount"], current["VisitCount"], false))
                  {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["Type"], (object) "Product", false))
                    {
                      FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct = new FSM.Entity.OrderLocationProduct.OrderLocationProduct();
                      oOrderLocationProduct.SetProductID = RuntimeHelpers.GetObjectValue(dataRow["PartProductID"]);
                      oOrderLocationProduct.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
                      oOrderLocationProduct.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
                      oOrderLocationProduct.SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
                      oOrderLocationProduct.SetOrderID = (object) ((Order) hashtable2[RuntimeHelpers.GetObjectValue(dataRow["GetID"])]).OrderID;
                      FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct = this.Trans == null ? App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !this.chkDoNotConsolidate.Checked) : App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !this.chkDoNotConsolidate.Checked, this.Trans);
                      dataRow["OrderItemID"] = (object) orderLocationProduct.OrderLocationProductID;
                      ProductTransaction productTransaction = new ProductTransaction()
                      {
                        IgnoreExceptionsOnSetMethods = true,
                        SetOrderLocationProductID = (object) orderLocationProduct.OrderLocationProductID,
                        SetTransactionTypeID = (object) 5,
                        SetProductID = (object) orderLocationProduct.ProductID,
                        SetAmount = (object) checked (-orderLocationProduct.Quantity),
                        SetLocationID = (object) orderLocationProduct.LocationID
                      };
                    }
                    else
                    {
                      FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart = new FSM.Entity.OrderLocationPart.OrderLocationPart();
                      oOrderLocationPart.SetPartID = RuntimeHelpers.GetObjectValue(dataRow["PartProductID"]);
                      oOrderLocationPart.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
                      oOrderLocationPart.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
                      oOrderLocationPart.SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
                      oOrderLocationPart.SetOrderID = (object) ((Order) hashtable2[RuntimeHelpers.GetObjectValue(dataRow["GetID"])]).OrderID;
                      FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart = this.Trans == null ? App.DB.OrderLocationPart.Insert(oOrderLocationPart, !this.chkDoNotConsolidate.Checked) : App.DB.OrderLocationPart.Insert(oOrderLocationPart, !this.chkDoNotConsolidate.Checked, this.Trans);
                      dataRow["OrderItemID"] = (object) orderLocationPart.OrderLocationPartID;
                      PartTransaction oPartTransaction = new PartTransaction();
                      oPartTransaction.IgnoreExceptionsOnSetMethods = true;
                      oPartTransaction.SetOrderLocationPartID = (object) orderLocationPart.OrderLocationPartID;
                      oPartTransaction.SetTransactionTypeID = (object) 5;
                      oPartTransaction.SetPartID = (object) orderLocationPart.PartID;
                      oPartTransaction.SetAmount = (object) checked (-orderLocationPart.Quantity);
                      oPartTransaction.SetLocationID = (object) orderLocationPart.LocationID;
                      PartTransaction partTransaction = this.Trans == null ? App.DB.PartTransaction.Insert(oPartTransaction) : App.DB.PartTransaction.Insert(oPartTransaction, this.Trans);
                    }
                  }
                  checked { ++index3; }
                }
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
          }
          if (this.NeedsTransaction)
          {
            IEnumerator enumerator2;
            try
            {
              enumerator2 = this.PartsAndProducts.Table.Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current = (DataRow) enumerator2.Current;
                current.AcceptChanges();
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["Quantity"])))
                  current["Quantity"] = RuntimeHelpers.GetObjectValue(current["QuantityToOrder"]);
                App.DB.EngineerVisitPartProductAllocated.UpdateOne(Conversions.ToInteger(current["ID"]), this.EngineerVisitID, Conversions.ToString(current["Type"]), Conversions.ToInteger(current["Quantity"]), Conversions.ToInteger(current["OrderItemID"]), Conversions.ToInteger(current["PartProductID"]), Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderLocationTypeID"])), this.Trans);
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            this.Trans.Commit();
          }
        }
        else
        {
          Hashtable hashtable1 = new Hashtable();
          DataRow[] dataRowArray1 = this.PartsAndProducts.Table.Select("GetFrom = 1");
          int index2 = 0;
          while (index2 < dataRowArray1.Length)
          {
            DataRow dataRow = dataRowArray1[index2];
            if (!hashtable1.Contains(RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])))
            {
              Order oOrder = new Order();
              CustomerOrder oCustomerOrder = new CustomerOrder();
              oOrder.SetOrderReference = (object) (str1 + this.QuoteOrder.CustomerRef + "-" + Conversions.ToString(checked (hashtable1.Count + 1)));
              oOrder.SetOrderTypeID = (object) 1;
              oOrder.SetUserID = (object) App.loggedInUser.UserID;
              oOrder.DeliveryDeadline = this.dtpDeadline.Value.Date;
              oOrder.DatePlaced = DateAndTime.Now;
              if (this.chkAwaiting.Checked)
              {
                oOrder.SetOrderStatusID = (object) 1;
              }
              else
              {
                oOrder.SetOrderStatusID = (object) 2;
                this.chkDoNotConsolidate.Checked = true;
              }
              oOrder.SetSpecialInstructions = (object) this.QuoteOrder.SpecialInstructions;
              oOrder.SetContactID = (object) this.QuoteOrder.ContactID;
              oOrder.SetInvoiceAddressID = (object) this.QuoteOrder.InvoiceAddressID;
              oOrder.SetAllocatedToUser = (object) this.QuoteOrder.AllocatedToUser;
              Order order = this.Trans == null ? App.DB.Order.Insert(oOrder) : App.DB.Order.Insert(oOrder, this.Trans);
              oCustomerOrder.SetCustomerID = (object) this.QuoteOrder.CustomerID;
              oCustomerOrder.SetOrderID = (object) order.OrderID;
              CustomerOrder customerOrder = this.Trans == null ? App.DB.CustomerOrder.Insert(oCustomerOrder) : App.DB.CustomerOrder.Insert(oCustomerOrder, this.Trans);
              if (this.QuoteOrder != null)
              {
                if (this.QuoteOrder.PropertyID > 0)
                {
                  SiteOrder oSiteOrder = new SiteOrder();
                  oSiteOrder.SetOrderID = (object) order.OrderID;
                  oSiteOrder.SetSiteID = (object) this.QuoteOrder.PropertyID;
                  SiteOrder siteOrder = this.Trans == null ? App.DB.SiteOrder.Insert(oSiteOrder) : App.DB.SiteOrder.Insert(oSiteOrder, this.Trans);
                }
                else
                {
                  OrderLocation oOrderLocation = new OrderLocation();
                  oOrderLocation.SetLocationID = this.Trans == null ? RuntimeHelpers.GetObjectValue(App.DB.Warehouse.Warehouse_GetDV(this.QuoteOrder.WarehouseID).Table.Rows[0]["LocationID"]) : RuntimeHelpers.GetObjectValue(App.DB.Warehouse.Warehouse_GetDV(this.QuoteOrder.WarehouseID, this.Trans).Table.Rows[0]["LocationID"]);
                  oOrderLocation.SetOrderID = (object) order.OrderID;
                  OrderLocation orderLocation = this.Trans == null ? App.DB.OrderLocation.Insert(oOrderLocation) : App.DB.OrderLocation.Insert(oOrderLocation, this.Trans);
                }
              }
              hashtable1.Add(RuntimeHelpers.GetObjectValue(dataRow["SupplierID"]), (object) order);
              arrayList1.Add((object) new object[2]
              {
                (object) order.OrderID,
                (object) this.QuoteOrder.PropertyID
              });
            }
            IEnumerator enumerator;
            try
            {
              enumerator = this.PriceRequestItemsDataView.Table.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["SupplierID"], dataRow["SupplierID"], false) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Included"], (object) "1", false))
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Product", false))
                  {
                    OrderProduct oOrderProduct = new OrderProduct();
                    oOrderProduct.SetOrderID = (object) ((Order) hashtable1[RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])]).OrderID;
                    oOrderProduct.SetBuyPrice = RuntimeHelpers.GetObjectValue(current["BuyPrice"]);
                    oOrderProduct.SetSellPrice = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
                    oOrderProduct.SetQuantity = (object) 1;
                    oOrderProduct.SetProductSupplierID = RuntimeHelpers.GetObjectValue(current["ProductSupplierID"]);
                    OrderProduct orderProduct = this.Trans == null ? App.DB.OrderProduct.Insert(oOrderProduct, !this.chkDoNotConsolidate.Checked) : App.DB.OrderProduct.Insert(oOrderProduct, !this.chkDoNotConsolidate.Checked, this.Trans);
                  }
                  else
                  {
                    OrderPart oOrderPart = new OrderPart();
                    oOrderPart.SetOrderID = (object) ((Order) hashtable1[RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])]).OrderID;
                    oOrderPart.SetBuyPrice = RuntimeHelpers.GetObjectValue(current["BuyPrice"]);
                    oOrderPart.SetSellPrice = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
                    oOrderPart.SetQuantity = (object) 1;
                    oOrderPart.SetPartSupplierID = RuntimeHelpers.GetObjectValue(current["PartSupplierID"]);
                    OrderPart orderPart = this.Trans == null ? App.DB.OrderPart.Insert(oOrderPart, !this.chkDoNotConsolidate.Checked) : App.DB.OrderPart.Insert(oOrderPart, !this.chkDoNotConsolidate.Checked, this.Trans);
                  }
                }
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["Type"], (object) "Product", false))
            {
              OrderProduct oOrderProduct = new OrderProduct();
              oOrderProduct.SetOrderID = (object) ((Order) hashtable1[RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])]).OrderID;
              oOrderProduct.SetBuyPrice = RuntimeHelpers.GetObjectValue(dataRow["BuyPrice"]);
              oOrderProduct.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
              oOrderProduct.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
              oOrderProduct.SetProductSupplierID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
              OrderProduct orderProduct = this.Trans == null ? App.DB.OrderProduct.Insert(oOrderProduct, !this.chkDoNotConsolidate.Checked) : App.DB.OrderProduct.Insert(oOrderProduct, !this.chkDoNotConsolidate.Checked, this.Trans);
            }
            else
            {
              OrderPart oOrderPart = new OrderPart();
              oOrderPart.SetOrderID = (object) ((Order) hashtable1[RuntimeHelpers.GetObjectValue(dataRow["SupplierID"])]).OrderID;
              oOrderPart.SetBuyPrice = RuntimeHelpers.GetObjectValue(dataRow["BuyPrice"]);
              oOrderPart.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
              oOrderPart.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
              oOrderPart.SetPartSupplierID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
              OrderPart orderPart = this.Trans == null ? App.DB.OrderPart.Insert(oOrderPart, !this.chkDoNotConsolidate.Checked) : App.DB.OrderPart.Insert(oOrderPart, !this.chkDoNotConsolidate.Checked, this.Trans);
            }
            checked { ++index2; }
          }
          Hashtable hashtable2 = new Hashtable();
          DataRow[] dataRowArray2 = this.PartsAndProducts.Table.Select("GetFrom = 2 OR GetFrom = 3");
          int index3 = 0;
          while (index3 < dataRowArray2.Length)
          {
            DataRow dataRow = dataRowArray2[index3];
            if (!hashtable2.Contains(RuntimeHelpers.GetObjectValue(dataRow["GetID"])))
            {
              Order oOrder = new Order();
              CustomerOrder oCustomerOrder = new CustomerOrder();
              oOrder.SetOrderReference = (object) (this.QuoteOrder.CustomerRef + "-" + Conversions.ToString(checked (hashtable2.Count + 1)));
              oOrder.SetOrderTypeID = (object) 1;
              oOrder.SetUserID = (object) App.loggedInUser.UserID;
              oOrder.DeliveryDeadline = this.dtpDeadline.Value.Date;
              oOrder.DatePlaced = DateAndTime.Now;
              if (this.chkAwaiting.Checked)
              {
                oOrder.SetOrderStatusID = (object) 1;
              }
              else
              {
                oOrder.SetOrderStatusID = (object) 2;
                this.chkDoNotConsolidate.Checked = true;
              }
              oOrder.SetSpecialInstructions = (object) this.QuoteOrder.SpecialInstructions;
              oOrder.SetContactID = (object) this.QuoteOrder.ContactID;
              oOrder.SetInvoiceAddressID = (object) this.QuoteOrder.InvoiceAddressID;
              oOrder.SetAllocatedToUser = (object) this.QuoteOrder.AllocatedToUser;
              Order order = this.Trans == null ? App.DB.Order.Insert(oOrder) : App.DB.Order.Insert(oOrder, this.Trans);
              oCustomerOrder.SetCustomerID = (object) this.QuoteOrder.CustomerID;
              oCustomerOrder.SetOrderID = (object) order.OrderID;
              CustomerOrder customerOrder = this.Trans == null ? App.DB.CustomerOrder.Insert(oCustomerOrder) : App.DB.CustomerOrder.Insert(oCustomerOrder, this.Trans);
              if (this.QuoteOrder != null)
              {
                if (this.QuoteOrder.PropertyID > 0)
                {
                  SiteOrder oSiteOrder = new SiteOrder();
                  oSiteOrder.SetOrderID = (object) order.OrderID;
                  oSiteOrder.SetSiteID = (object) this.QuoteOrder.PropertyID;
                  SiteOrder siteOrder = this.Trans == null ? App.DB.SiteOrder.Insert(oSiteOrder) : App.DB.SiteOrder.Insert(oSiteOrder, this.Trans);
                }
                else
                {
                  OrderLocation oOrderLocation = new OrderLocation();
                  oOrderLocation.SetLocationID = this.Trans == null ? RuntimeHelpers.GetObjectValue(App.DB.Warehouse.Warehouse_GetDV(this.QuoteOrder.WarehouseID).Table.Rows[0]["LocationID"]) : RuntimeHelpers.GetObjectValue(App.DB.Warehouse.Warehouse_GetDV(this.QuoteOrder.WarehouseID, this.Trans).Table.Rows[0]["LocationID"]);
                  oOrderLocation.SetOrderID = (object) order.OrderID;
                  OrderLocation orderLocation = this.Trans == null ? App.DB.OrderLocation.Insert(oOrderLocation) : App.DB.OrderLocation.Insert(oOrderLocation, this.Trans);
                }
              }
              hashtable2.Add(RuntimeHelpers.GetObjectValue(dataRow["GetID"]), (object) order);
              arrayList1.Add((object) new object[2]
              {
                (object) order.OrderID,
                (object) this.QuoteOrder.PropertyID
              });
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["Type"], (object) "Product", false))
            {
              FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct = new FSM.Entity.OrderLocationProduct.OrderLocationProduct();
              oOrderLocationProduct.SetProductID = RuntimeHelpers.GetObjectValue(dataRow["PartProductID"]);
              oOrderLocationProduct.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
              oOrderLocationProduct.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
              oOrderLocationProduct.SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
              oOrderLocationProduct.SetOrderID = (object) ((Order) hashtable2[RuntimeHelpers.GetObjectValue(dataRow["GetID"])]).OrderID;
              FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct = this.Trans == null ? App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !this.chkDoNotConsolidate.Checked) : App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !this.chkDoNotConsolidate.Checked, this.Trans);
              ProductTransaction productTransaction = new ProductTransaction()
              {
                IgnoreExceptionsOnSetMethods = true,
                SetOrderLocationProductID = (object) orderLocationProduct.OrderLocationProductID,
                SetTransactionTypeID = (object) 5,
                SetProductID = (object) orderLocationProduct.ProductID,
                SetAmount = (object) checked (-orderLocationProduct.Quantity),
                SetLocationID = (object) orderLocationProduct.LocationID
              };
            }
            else
            {
              FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart = new FSM.Entity.OrderLocationPart.OrderLocationPart();
              oOrderLocationPart.SetPartID = RuntimeHelpers.GetObjectValue(dataRow["PartProductID"]);
              oOrderLocationPart.SetSellPrice = RuntimeHelpers.GetObjectValue(dataRow["SellPrice"]);
              oOrderLocationPart.SetQuantity = RuntimeHelpers.GetObjectValue(dataRow["QuantityToOrder"]);
              oOrderLocationPart.SetLocationID = RuntimeHelpers.GetObjectValue(dataRow["GetID"]);
              oOrderLocationPart.SetOrderID = (object) ((Order) hashtable2[RuntimeHelpers.GetObjectValue(dataRow["GetID"])]).OrderID;
              FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart = this.Trans == null ? App.DB.OrderLocationPart.Insert(oOrderLocationPart, !this.chkDoNotConsolidate.Checked) : App.DB.OrderLocationPart.Insert(oOrderLocationPart, !this.chkDoNotConsolidate.Checked, this.Trans);
              PartTransaction oPartTransaction = new PartTransaction();
              oPartTransaction.IgnoreExceptionsOnSetMethods = true;
              oPartTransaction.SetOrderLocationPartID = (object) orderLocationPart.OrderLocationPartID;
              oPartTransaction.SetTransactionTypeID = (object) 5;
              oPartTransaction.SetPartID = (object) orderLocationPart.PartID;
              oPartTransaction.SetAmount = (object) checked (-orderLocationPart.Quantity);
              oPartTransaction.SetLocationID = (object) orderLocationPart.LocationID;
              PartTransaction partTransaction = this.Trans == null ? App.DB.PartTransaction.Insert(oPartTransaction) : App.DB.PartTransaction.Insert(oPartTransaction, this.Trans);
            }
            checked { ++index3; }
          }
        }
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = true;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        if (this.Trans != null)
          this.Trans.Rollback();
        sqlConnection?.Close();
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = true;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      if (this.OrderType != Enums.OrderType.Job)
      {
        if (arrayList1.Count == 1)
          App.ShowForm(typeof (FRMOrder), false, new object[4]
          {
            NewLateBinding.LateIndexGet(arrayList1[0], new object[1]
            {
              (object) 0
            }, (string[]) null),
            NewLateBinding.LateIndexGet(arrayList1[0], new object[1]
            {
              (object) 1
            }, (string[]) null),
            (object) 0,
            (object) this
          }, true);
        else if (arrayList1.Count > 1)
        {
          ArrayList arrayList2 = new ArrayList();
          IEnumerator enumerator;
          try
          {
            enumerator = arrayList1.GetEnumerator();
            while (enumerator.MoveNext())
            {
              object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
              arrayList2.Add(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[1]
              {
                (object) 0
              }, (string[]) null)));
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          App.ShowForm(typeof (FRMOrderManager), false, new object[2]
          {
            null,
            (object) arrayList2
          }, false);
        }
      }
      if (!flag)
        this.DialogResult = DialogResult.OK;
    }

    private void btnAddPart_Click(object sender, EventArgs e)
    {
      int PartID = this.Trans == null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblPart, 0, "", false)) : App.FindRecord(Enums.TableNames.tblPart, this.Trans, 0, "");
      if (PartID <= 0)
        return;
      Part part = this.Trans == null ? App.DB.Part.Part_Get(PartID) : App.DB.Part.Part_Get(PartID, this.Trans);
      DataRow row = this.PartsAndProducts.Table.NewRow();
      row["PartProductID"] = (object) part.PartID;
      row["Number"] = (object) part.Number;
      row["Name"] = (object) part.Name;
      row["Type"] = (object) "Part";
      this.PartsAndProducts.Table.Rows.Add(row);
      this.PartsAndProducts.Table.AcceptChanges();
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      string MessageText = "Are you sure you want to remove this item from the order?";
      if (this.OrderType == Enums.OrderType.Job)
        MessageText += "\r\nRemoving this item will remove it from the job";
      if (App.ShowMessage(MessageText, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes || this.SelectedPartProductDataRow == null)
        return;
      this.PartsAndProducts.Table.Rows.Remove(this.SelectedPartProductDataRow);
    }

    private void btnAddProduct_Click(object sender, EventArgs e)
    {
      int ProductID = this.Trans == null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblProduct, 0, "", false)) : App.FindRecord(Enums.TableNames.tblProduct, this.Trans, 0, "");
      if (ProductID <= 0)
        return;
      Product product = this.Trans == null ? App.DB.Product.Product_Get(ProductID) : App.DB.Product.Product_Get(ProductID, this.Trans);
      DataRow row = this.PartsAndProducts.Table.NewRow();
      row["PartProductID"] = (object) product.ProductID;
      row["Name"] = (object) product.Name;
      row["Number"] = (object) product.Number;
      row["Type"] = (object) "Product";
      this.PartsAndProducts.Table.Rows.Add(row);
      this.PartsAndProducts.Table.AcceptChanges();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      DataTable datatableIn = new DataTable();
      datatableIn.Columns.Add(new DataColumn("Type"));
      datatableIn.Columns.Add(new DataColumn("Name"));
      datatableIn.Columns.Add(new DataColumn("Number"));
      datatableIn.Columns.Add(new DataColumn("Quantity"));
      datatableIn.Columns.Add(new DataColumn("Location"));
      datatableIn.Columns.Add(new DataColumn("Shelf"));
      datatableIn.Columns.Add(new DataColumn("Bin"));
      IEnumerator enumerator;
      try
      {
        enumerator = this.PartsAndProducts.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          DataRow row = datatableIn.NewRow();
          row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
          row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
          row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
          row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
          row["Location"] = RuntimeHelpers.GetObjectValue(current["GetFromText"]);
          row["Shelf"] = RuntimeHelpers.GetObjectValue(current["Shelf"]);
          row["Bin"] = RuntimeHelpers.GetObjectValue(current["Bin"]);
          datatableIn.Rows.Add(row);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      Exporting exporting = new Exporting(datatableIn, "Job Order Pick List", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }

    public void RefreshDatagrid()
    {
      this.ChargesDataView = App.DB.OrderCharge.OrderCharge_GetForOrder(0);
      this.PageState = Enums.FormState.Insert;
    }

    private void dgCharges_Click(object sender, EventArgs e)
    {
      if (this.SelectedChargeDataRow == null)
      {
        this.PageState = Enums.FormState.Insert;
      }
      else
      {
        this.PageState = Enums.FormState.Update;
        this.txtAmount.Text = Conversions.ToString(this.SelectedChargeDataRow["Amount"]);
        ComboBox cboChargeType = this.cboChargeType;
        Combo.SetSelectedComboItem_By_Value(ref cboChargeType, Conversions.ToString(this.SelectedChargeDataRow["OrderChargeTypeID"]));
        this.cboChargeType = cboChargeType;
      }
    }

    private void btnChargesSave_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        OrderCharge oOrderCharge = new OrderCharge();
        oOrderCharge.IgnoreExceptionsOnSetMethods = true;
        oOrderCharge.SetAmount = (object) this.txtAmount.Text.Trim();
        oOrderCharge.SetOrderChargeTypeID = (object) Combo.get_GetSelectedItemValue(this.cboChargeType);
        oOrderCharge.SetOrderID = (object) 0;
        new OrderChargeValidator().Validate(oOrderCharge);
        switch (this.PageState)
        {
          case Enums.FormState.Insert:
            DataRow row = this.ChargesDataView.Table.NewRow();
            row["Amount"] = (object) oOrderCharge.Amount;
            row["Reference"] = (object) oOrderCharge.Reference;
            row["ChargeType"] = (object) Combo.get_GetSelectedItemDescription(this.cboChargeType);
            row["OrderChargeTypeID"] = (object) Combo.get_GetSelectedItemValue(this.cboChargeType);
            this.ChargesDataView.Table.Rows.Add(row);
            break;
          case Enums.FormState.Update:
            this.SelectedChargeDataRow["Amount"] = (object) oOrderCharge.Amount;
            this.SelectedChargeDataRow["Reference"] = (object) oOrderCharge.Reference;
            this.SelectedChargeDataRow["ChargeType"] = (object) Combo.get_GetSelectedItemDescription(this.cboChargeType);
            this.SelectedChargeDataRow["OrderChargeTypeID"] = (object) Combo.get_GetSelectedItemValue(this.cboChargeType);
            break;
        }
        this.PageState = Enums.FormState.Insert;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.SelectedChargeDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a charge to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.PageState = Enums.FormState.Insert;
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to remove this charge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        this.ChargesDataView.Table.Rows.Remove(this.SelectedChargeDataRow);
      }
    }
  }
}
