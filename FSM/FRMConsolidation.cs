// Decompiled with JetBrains decompiler
// Type: FSM.FRMConsolidation
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.OrderConsolidations;
using FSM.Entity.OrderLocations;
using FSM.Entity.OrderParts;
using FSM.Entity.OrderProducts;
using FSM.Entity.PartSuppliers;
using FSM.Entity.PartTransactions;
using FSM.Entity.ProductSuppliers;
using FSM.Entity.ProductTransactions;
using FSM.Entity.Suppliers;
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
  public class FRMConsolidation : FRMBaseForm, IForm
  {
    private IContainer components;
    private bool IsLoading;
    private OrderConsolidation _OrderConsolidation;
    private JobNumber _OrderNumber;
    private bool _OrderNumberUsed;
    private Supplier _Supplier;
    private DataView _OrderDataView;
    private DataView _itemsDataView;
    private bool DoubleClicked;

    public FRMConsolidation()
    {
      this.Load += new EventHandler(this.FRMConsolidation_Load);
      this.IsLoading = true;
      this._OrderNumber = new JobNumber();
      this._OrderNumberUsed = false;
      this._OrderDataView = (DataView) null;
      this._itemsDataView = (DataView) null;
      this.DoubleClicked = false;
      this.InitializeComponent();
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, App.DB.Order.OrderStatus_Get_All().Table, "OrderStatusID", "Name", Enums.ComboValues.None);
      this.cboStatus = cboStatus;
      ComboBox cboTaxCode = this.cboTaxCode;
      Combo.SetUpCombo(ref cboTaxCode, App.DB.Picklists.GetAll(Enums.PickListTypes.VATCodes, false).Table, "ManagerID", "Name", Enums.ComboValues.Dashes);
      this.cboTaxCode = cboTaxCode;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

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

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStatus
    {
      get
      {
        return this._cboStatus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboStatus_SelectedIndexChanged);
        ComboBox cboStatus1 = this._cboStatus;
        if (cboStatus1 != null)
          cboStatus1.SelectedIndexChanged -= eventHandler;
        this._cboStatus = value;
        ComboBox cboStatus2 = this._cboStatus;
        if (cboStatus2 == null)
          return;
        cboStatus2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Button btnSupplier
    {
      get
      {
        return this._btnSupplier;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSupplier_Click);
        Button btnSupplier1 = this._btnSupplier;
        if (btnSupplier1 != null)
          btnSupplier1.Click -= eventHandler;
        this._btnSupplier = value;
        Button btnSupplier2 = this._btnSupplier;
        if (btnSupplier2 == null)
          return;
        btnSupplier2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtComments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpOrders { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpItems { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgOrders
    {
      get
      {
        return this._dgOrders;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgOrders_DoubleClick);
        DataGrid dgOrders1 = this._dgOrders;
        if (dgOrders1 != null)
          dgOrders1.DoubleClick -= eventHandler;
        this._dgOrders = value;
        DataGrid dgOrders2 = this._dgOrders;
        if (dgOrders2 == null)
          return;
        dgOrders2.DoubleClick += eventHandler;
      }
    }

    internal virtual DataGrid dgItems
    {
      get
      {
        return this._dgItems;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgItems_MouseUp);
        EventHandler eventHandler = new EventHandler(this.dgItems_DoubleClick);
        DataGrid dgItems1 = this._dgItems;
        if (dgItems1 != null)
        {
          dgItems1.MouseUp -= mouseEventHandler;
          dgItems1.DoubleClick -= eventHandler;
        }
        this._dgItems = value;
        DataGrid dgItems2 = this._dgItems;
        if (dgItems2 == null)
          return;
        dgItems2.MouseUp += mouseEventHandler;
        dgItems2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnPrint
    {
      get
      {
        return this._btnPrint;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrint_Click);
        Button btnPrint1 = this._btnPrint;
        if (btnPrint1 != null)
          btnPrint1.Click -= eventHandler;
        this._btnPrint = value;
        Button btnPrint2 = this._btnPrint;
        if (btnPrint2 == null)
          return;
        btnPrint2.Click += eventHandler;
      }
    }

    internal virtual Button btnReceiveAll
    {
      get
      {
        return this._btnReceiveAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReceiveAll_Click);
        Button btnReceiveAll1 = this._btnReceiveAll;
        if (btnReceiveAll1 != null)
          btnReceiveAll1.Click -= eventHandler;
        this._btnReceiveAll = value;
        Button btnReceiveAll2 = this._btnReceiveAll;
        if (btnReceiveAll2 == null)
          return;
        btnReceiveAll2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkPOSupplied { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbxReadyToSendToSage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNominalCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVAT
    {
      get
      {
        return this._txtVAT;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtVAT_GotFocus);
        CancelEventHandler cancelEventHandler = new CancelEventHandler(this.txtVAT_Validating);
        TextBox txtVat1 = this._txtVAT;
        if (txtVat1 != null)
        {
          txtVat1.GotFocus -= eventHandler;
          txtVat1.Validating -= cancelEventHandler;
        }
        this._txtVAT = value;
        TextBox txtVat2 = this._txtVAT;
        if (txtVat2 == null)
          return;
        txtVat2.GotFocus += eventHandler;
        txtVat2.Validating += cancelEventHandler;
      }
    }

    internal virtual TextBox txtExtraReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTaxCode
    {
      get
      {
        return this._cboTaxCode;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboTaxCode_SelectedIndexChanged);
        ComboBox cboTaxCode1 = this._cboTaxCode;
        if (cboTaxCode1 != null)
          cboTaxCode1.SelectedIndexChanged -= eventHandler;
        this._cboTaxCode = value;
        ComboBox cboTaxCode2 = this._cboTaxCode;
        if (cboTaxCode2 == null)
          return;
        cboTaxCode2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplierInvoiceAmount
    {
      get
      {
        return this._txtSupplierInvoiceAmount;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtSupplierInvoiceAmount_GotFocus);
        CancelEventHandler cancelEventHandler = new CancelEventHandler(this.txtSupplierInvoiceAmount_Validating);
        TextBox supplierInvoiceAmount1 = this._txtSupplierInvoiceAmount;
        if (supplierInvoiceAmount1 != null)
        {
          supplierInvoiceAmount1.GotFocus -= eventHandler;
          supplierInvoiceAmount1.Validating -= cancelEventHandler;
        }
        this._txtSupplierInvoiceAmount = value;
        TextBox supplierInvoiceAmount2 = this._txtSupplierInvoiceAmount;
        if (supplierInvoiceAmount2 == null)
          return;
        supplierInvoiceAmount2.GotFocus += eventHandler;
        supplierInvoiceAmount2.Validating += cancelEventHandler;
      }
    }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkSupInvDateNA
    {
      get
      {
        return this._chkSupInvDateNA;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkSupInvDateNA_CheckedChanged);
        CheckBox chkSupInvDateNa1 = this._chkSupInvDateNA;
        if (chkSupInvDateNa1 != null)
          chkSupInvDateNa1.CheckedChanged -= eventHandler;
        this._chkSupInvDateNA = value;
        CheckBox chkSupInvDateNa2 = this._chkSupInvDateNA;
        if (chkSupInvDateNa2 == null)
          return;
        chkSupInvDateNa2.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox txtSupplierInvoiceReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpSupplierInvoiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOrderTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPrintDistribution
    {
      get
      {
        return this._btnPrintDistribution;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintDistribution_Click);
        Button printDistribution1 = this._btnPrintDistribution;
        if (printDistribution1 != null)
          printDistribution1.Click -= eventHandler;
        this._btnPrintDistribution = value;
        Button printDistribution2 = this._btnPrintDistribution;
        if (printDistribution2 == null)
          return;
        printDistribution2.Click += eventHandler;
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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnSave = new Button();
      this.btnClose = new Button();
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.Label3 = new Label();
      this.Label4 = new Label();
      this.grpMain = new GroupBox();
      this.lblStatus = new Label();
      this.chkPOSupplied = new CheckBox();
      this.Label17 = new Label();
      this.cbxReadyToSendToSage = new CheckBox();
      this.txtDepartment = new TextBox();
      this.cboStatus = new ComboBox();
      this.txtNominalCode = new TextBox();
      this.btnSupplier = new Button();
      this.Label16 = new Label();
      this.txtComments = new TextBox();
      this.txtSupplier = new TextBox();
      this.txtVAT = new TextBox();
      this.txtExtraReference = new TextBox();
      this.Label14 = new Label();
      this.txtReference = new TextBox();
      this.cboTaxCode = new ComboBox();
      this.Label15 = new Label();
      this.Label13 = new Label();
      this.txtSupplierInvoiceAmount = new TextBox();
      this.Label10 = new Label();
      this.Label9 = new Label();
      this.chkSupInvDateNA = new CheckBox();
      this.txtSupplierInvoiceReference = new TextBox();
      this.dtpSupplierInvoiceDate = new DateTimePicker();
      this.Label11 = new Label();
      this.grpOrders = new GroupBox();
      this.dgOrders = new DataGrid();
      this.grpItems = new GroupBox();
      this.lblOrderTotal = new Label();
      this.dgItems = new DataGrid();
      this.btnPrint = new Button();
      this.btnReceiveAll = new Button();
      this.btnPrintDistribution = new Button();
      this.grpMain.SuspendLayout();
      this.grpOrders.SuspendLayout();
      this.dgOrders.BeginInit();
      this.grpItems.SuspendLayout();
      this.dgItems.BeginInit();
      this.SuspendLayout();
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(833, 681);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(60, 25);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Save";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(12, 681);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 25);
      this.btnClose.TabIndex = 7;
      this.btnClose.Text = "Close";
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(6, 26);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(65, 13);
      this.Label1.TabIndex = 4;
      this.Label1.Text = "Reference";
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(6, 83);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(69, 13);
      this.Label2.TabIndex = 5;
      this.Label2.Text = "Comments";
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(6, 52);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(54, 13);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Supplier";
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(185, 26);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(43, 13);
      this.Label4.TabIndex = 7;
      this.Label4.Text = "Status";
      this.grpMain.Controls.Add((Control) this.lblStatus);
      this.grpMain.Controls.Add((Control) this.chkPOSupplied);
      this.grpMain.Controls.Add((Control) this.Label17);
      this.grpMain.Controls.Add((Control) this.cbxReadyToSendToSage);
      this.grpMain.Controls.Add((Control) this.txtDepartment);
      this.grpMain.Controls.Add((Control) this.cboStatus);
      this.grpMain.Controls.Add((Control) this.txtNominalCode);
      this.grpMain.Controls.Add((Control) this.btnSupplier);
      this.grpMain.Controls.Add((Control) this.Label16);
      this.grpMain.Controls.Add((Control) this.txtComments);
      this.grpMain.Controls.Add((Control) this.txtSupplier);
      this.grpMain.Controls.Add((Control) this.txtVAT);
      this.grpMain.Controls.Add((Control) this.txtExtraReference);
      this.grpMain.Controls.Add((Control) this.Label14);
      this.grpMain.Controls.Add((Control) this.txtReference);
      this.grpMain.Controls.Add((Control) this.cboTaxCode);
      this.grpMain.Controls.Add((Control) this.Label15);
      this.grpMain.Controls.Add((Control) this.Label13);
      this.grpMain.Controls.Add((Control) this.Label1);
      this.grpMain.Controls.Add((Control) this.Label4);
      this.grpMain.Controls.Add((Control) this.Label2);
      this.grpMain.Controls.Add((Control) this.txtSupplierInvoiceAmount);
      this.grpMain.Controls.Add((Control) this.Label3);
      this.grpMain.Controls.Add((Control) this.Label10);
      this.grpMain.Controls.Add((Control) this.Label9);
      this.grpMain.Controls.Add((Control) this.chkSupInvDateNA);
      this.grpMain.Controls.Add((Control) this.txtSupplierInvoiceReference);
      this.grpMain.Controls.Add((Control) this.dtpSupplierInvoiceDate);
      this.grpMain.Controls.Add((Control) this.Label11);
      this.grpMain.Location = new System.Drawing.Point(12, 38);
      this.grpMain.Name = "grpMain";
      this.grpMain.Size = new Size(400, 337);
      this.grpMain.TabIndex = 1;
      this.grpMain.TabStop = false;
      this.grpMain.Text = "Main Details";
      this.lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblStatus.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.lblStatus.Font = new Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblStatus.Location = new System.Drawing.Point(10, 281);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new Size(233, 50);
      this.lblStatus.TabIndex = 89;
      this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;
      this.chkPOSupplied.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.chkPOSupplied.Location = new System.Drawing.Point(9, 135);
      this.chkPOSupplied.Name = "chkPOSupplied";
      this.chkPOSupplied.Size = new Size(251, 24);
      this.chkPOSupplied.TabIndex = 88;
      this.chkPOSupplied.Text = "Supplier purchase invoice provided";
      this.Label17.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label17.Location = new System.Drawing.Point(243, 282);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(38, 20);
      this.Label17.TabIndex = 87;
      this.Label17.Text = "Dept";
      this.cbxReadyToSendToSage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cbxReadyToSendToSage.Location = new System.Drawing.Point(232, 308);
      this.cbxReadyToSendToSage.Name = "cbxReadyToSendToSage";
      this.cbxReadyToSendToSage.RightToLeft = RightToLeft.Yes;
      this.cbxReadyToSendToSage.Size = new Size(163, 24);
      this.cbxReadyToSendToSage.TabIndex = 78;
      this.cbxReadyToSendToSage.Text = "Ready to send to sage";
      this.txtDepartment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtDepartment.Location = new System.Drawing.Point(302, 281);
      this.txtDepartment.MaxLength = 100;
      this.txtDepartment.Name = "txtDepartment";
      this.txtDepartment.Size = new Size(93, 21);
      this.txtDepartment.TabIndex = 77;
      this.txtDepartment.Tag = (object) "Order.SupplierInvoiceReference";
      this.cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboStatus.FormattingEnabled = true;
      this.cboStatus.Location = new System.Drawing.Point(234, 23);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(160, 21);
      this.cboStatus.TabIndex = 2;
      this.txtNominalCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtNominalCode.Location = new System.Drawing.Point(302, 252);
      this.txtNominalCode.MaxLength = 100;
      this.txtNominalCode.Name = "txtNominalCode";
      this.txtNominalCode.Size = new Size(93, 21);
      this.txtNominalCode.TabIndex = 76;
      this.txtNominalCode.Tag = (object) "Order.SupplierInvoiceReference";
      this.btnSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSupplier.Location = new System.Drawing.Point(359, 52);
      this.btnSupplier.Name = "btnSupplier";
      this.btnSupplier.Size = new Size(35, 23);
      this.btnSupplier.TabIndex = 4;
      this.btnSupplier.Text = "...";
      this.btnSupplier.UseVisualStyleBackColor = true;
      this.Label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label16.Location = new System.Drawing.Point(243, 252);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(70, 20);
      this.Label16.TabIndex = 86;
      this.Label16.Text = "Nominal";
      this.txtComments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtComments.Location = new System.Drawing.Point(89, 83);
      this.txtComments.Multiline = true;
      this.txtComments.Name = "txtComments";
      this.txtComments.ScrollBars = ScrollBars.Both;
      this.txtComments.Size = new Size(305, 46);
      this.txtComments.TabIndex = 5;
      this.txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSupplier.Location = new System.Drawing.Point(89, 52);
      this.txtSupplier.Name = "txtSupplier";
      this.txtSupplier.ReadOnly = true;
      this.txtSupplier.Size = new Size(264, 21);
      this.txtSupplier.TabIndex = 3;
      this.txtVAT.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtVAT.Location = new System.Drawing.Point(138, 251);
      this.txtVAT.MaxLength = 100;
      this.txtVAT.Name = "txtVAT";
      this.txtVAT.Size = new Size(105, 21);
      this.txtVAT.TabIndex = 75;
      this.txtVAT.Tag = (object) "Order.SupplierInvoiceAmount";
      this.txtExtraReference.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtExtraReference.Location = new System.Drawing.Point(302, 163);
      this.txtExtraReference.MaxLength = 100;
      this.txtExtraReference.Name = "txtExtraReference";
      this.txtExtraReference.Size = new Size(93, 21);
      this.txtExtraReference.TabIndex = 70;
      this.txtExtraReference.Tag = (object) "Order.SupplierInvoiceReference";
      this.Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label14.Location = new System.Drawing.Point(7, 252);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(125, 20);
      this.Label14.TabIndex = 84;
      this.Label14.Text = "Invoice VAT Amount";
      this.txtReference.Location = new System.Drawing.Point(89, 23);
      this.txtReference.Name = "txtReference";
      this.txtReference.Size = new Size(90, 21);
      this.txtReference.TabIndex = 1;
      this.cboTaxCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cboTaxCode.Location = new System.Drawing.Point(302, 223);
      this.cboTaxCode.Name = "cboTaxCode";
      this.cboTaxCode.Size = new Size(93, 21);
      this.cboTaxCode.TabIndex = 74;
      this.Label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label15.Location = new System.Drawing.Point(249, 166);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(56, 20);
      this.Label15.TabIndex = 85;
      this.Label15.Text = "Ex Ref.";
      this.Label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label13.Location = new System.Drawing.Point(243, 225);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(70, 20);
      this.Label13.TabIndex = 83;
      this.Label13.Text = "Tax Code";
      this.txtSupplierInvoiceAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtSupplierInvoiceAmount.Location = new System.Drawing.Point(138, 223);
      this.txtSupplierInvoiceAmount.MaxLength = 100;
      this.txtSupplierInvoiceAmount.Name = "txtSupplierInvoiceAmount";
      this.txtSupplierInvoiceAmount.Size = new Size(105, 21);
      this.txtSupplierInvoiceAmount.TabIndex = 73;
      this.txtSupplierInvoiceAmount.Tag = (object) "Order.SupplierInvoiceAmount";
      this.Label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label10.Location = new System.Drawing.Point(7, 222);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(106, 20);
      this.Label10.TabIndex = 80;
      this.Label10.Text = "Invoice Amount";
      this.Label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label9.Location = new System.Drawing.Point(7, 165);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(94, 20);
      this.Label9.TabIndex = 79;
      this.Label9.Text = "Invoice Ref.";
      this.chkSupInvDateNA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.chkSupInvDateNA.Location = new System.Drawing.Point(138, 193);
      this.chkSupInvDateNA.Name = "chkSupInvDateNA";
      this.chkSupInvDateNA.Size = new Size(48, 24);
      this.chkSupInvDateNA.TabIndex = 71;
      this.chkSupInvDateNA.Text = "N/A";
      this.txtSupplierInvoiceReference.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtSupplierInvoiceReference.Location = new System.Drawing.Point(138, 162);
      this.txtSupplierInvoiceReference.MaxLength = 100;
      this.txtSupplierInvoiceReference.Name = "txtSupplierInvoiceReference";
      this.txtSupplierInvoiceReference.Size = new Size(105, 21);
      this.txtSupplierInvoiceReference.TabIndex = 69;
      this.txtSupplierInvoiceReference.Tag = (object) "Order.SupplierInvoiceReference";
      this.dtpSupplierInvoiceDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.dtpSupplierInvoiceDate.Location = new System.Drawing.Point(189, 196);
      this.dtpSupplierInvoiceDate.Name = "dtpSupplierInvoiceDate";
      this.dtpSupplierInvoiceDate.Size = new Size(206, 21);
      this.dtpSupplierInvoiceDate.TabIndex = 72;
      this.dtpSupplierInvoiceDate.Tag = (object) "Order.SupplierInvoiceDate";
      this.Label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label11.Location = new System.Drawing.Point(7, 195);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(94, 20);
      this.Label11.TabIndex = 81;
      this.Label11.Text = "Invoice Date";
      this.grpOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpOrders.Controls.Add((Control) this.dgOrders);
      this.grpOrders.Location = new System.Drawing.Point(418, 38);
      this.grpOrders.Name = "grpOrders";
      this.grpOrders.Size = new Size(475, 337);
      this.grpOrders.TabIndex = 2;
      this.grpOrders.TabStop = false;
      this.grpOrders.Text = "Related Orders (Double click to view)";
      this.dgOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgOrders.DataMember = "";
      this.dgOrders.HeaderForeColor = SystemColors.ControlText;
      this.dgOrders.Location = new System.Drawing.Point(6, 23);
      this.dgOrders.Name = "dgOrders";
      this.dgOrders.Size = new Size(463, 308);
      this.dgOrders.TabIndex = 1;
      this.grpItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpItems.Controls.Add((Control) this.lblOrderTotal);
      this.grpItems.Controls.Add((Control) this.dgItems);
      this.grpItems.Location = new System.Drawing.Point(12, 381);
      this.grpItems.Name = "grpItems";
      this.grpItems.Size = new Size(881, 294);
      this.grpItems.TabIndex = 3;
      this.grpItems.TabStop = false;
      this.grpItems.Text = "Related Items";
      this.lblOrderTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblOrderTotal.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblOrderTotal.Location = new System.Drawing.Point(580, 17);
      this.lblOrderTotal.Name = "lblOrderTotal";
      this.lblOrderTotal.Size = new Size(295, 15);
      this.lblOrderTotal.TabIndex = 82;
      this.lblOrderTotal.Text = "Order Total : £0.00";
      this.lblOrderTotal.TextAlign = ContentAlignment.MiddleRight;
      this.dgItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgItems.DataMember = "";
      this.dgItems.HeaderForeColor = SystemColors.ControlText;
      this.dgItems.Location = new System.Drawing.Point(9, 35);
      this.dgItems.Name = "dgItems";
      this.dgItems.Size = new Size(866, 253);
      this.dgItems.TabIndex = 1;
      this.btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrint.Location = new System.Drawing.Point(434, 681);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new Size(249, 25);
      this.btnPrint.TabIndex = 6;
      this.btnPrint.Text = "Print combined supplier purchase order";
      this.btnReceiveAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnReceiveAll.Location = new System.Drawing.Point(689, 681);
      this.btnReceiveAll.Name = "btnReceiveAll";
      this.btnReceiveAll.Size = new Size(138, 25);
      this.btnReceiveAll.TabIndex = 5;
      this.btnReceiveAll.Text = "Save && Receive All";
      this.btnPrintDistribution.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrintDistribution.Location = new System.Drawing.Point(258, 681);
      this.btnPrintDistribution.Name = "btnPrintDistribution";
      this.btnPrintDistribution.Size = new Size(170, 25);
      this.btnPrintDistribution.TabIndex = 8;
      this.btnPrintDistribution.Text = "Print order distribution list";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(905, 718);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnPrintDistribution);
      this.Controls.Add((Control) this.btnReceiveAll);
      this.Controls.Add((Control) this.btnPrint);
      this.Controls.Add((Control) this.grpItems);
      this.Controls.Add((Control) this.grpOrders);
      this.Controls.Add((Control) this.grpMain);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.MinimumSize = new Size(913, 752);
      this.Name = nameof (FRMConsolidation);
      this.Text = "Consolidation : ID {0}";
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.grpMain, 0);
      this.Controls.SetChildIndex((Control) this.grpOrders, 0);
      this.Controls.SetChildIndex((Control) this.grpItems, 0);
      this.Controls.SetChildIndex((Control) this.btnPrint, 0);
      this.Controls.SetChildIndex((Control) this.btnReceiveAll, 0);
      this.Controls.SetChildIndex((Control) this.btnPrintDistribution, 0);
      this.grpMain.ResumeLayout(false);
      this.grpMain.PerformLayout();
      this.grpOrders.ResumeLayout(false);
      this.dgOrders.EndInit();
      this.grpItems.ResumeLayout(false);
      this.dgItems.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.OrderConsolidation = App.DB.OrderConsolidations.OrderConsolidation_Get(Conversions.ToInteger(this.get_GetParameter(0)));
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
    }

    private void SetupDG()
    {
      DataGridTableStyle tableStyle = this.dgOrders.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.ReadOnly = false;
      this.dgOrders.ReadOnly = false;
      tableStyle.AllowSorting = false;
      if (this.OrderConsolidation.ConsolidatedOrderStatusID > 1)
        ;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Order Reference";
      dataGridLabelColumn1.MappingName = "OrderReference";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Type";
      dataGridLabelColumn2.MappingName = "Type";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Order Is For";
      dataGridLabelColumn3.MappingName = "Destination";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 80;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Status";
      dataGridLabelColumn4.MappingName = "OrderStatus";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Date Placed";
      dataGridLabelColumn5.MappingName = "DatePlaced";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Created By";
      dataGridLabelColumn6.MappingName = "CreatedBy";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.MappingName = Enums.TableNames.tblOrder.ToString();
      this.dgOrders.TableStyles.Add(tableStyle);
    }

    private void SetupItemsDG()
    {
      Helper.SetUpDataGrid(this.dgItems, false);
      DataGridTableStyle tableStyle = this.dgItems.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.ReadOnly = false;
      this.dgItems.ReadOnly = false;
      tableStyle.AllowSorting = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Number";
      dataGridLabelColumn1.MappingName = "Number";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
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
      dataGridLabelColumn3.Format = "C";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Buy Price";
      dataGridLabelColumn3.MappingName = "BuyPrice";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 80;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Type";
      dataGridLabelColumn4.MappingName = "Type";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Destination";
      dataGridLabelColumn5.MappingName = "Destination";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Order";
      dataGridLabelColumn6.MappingName = "OrderReference";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "No. Ordered";
      dataGridLabelColumn7.MappingName = "QuantityOnOrder";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      if (this.OrderConsolidation.ConsolidatedOrderStatusID == 2)
      {
        DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
        dataGridLabelColumn8.Format = "";
        dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn8.HeaderText = "No. Received";
        dataGridLabelColumn8.MappingName = "QuantityReceived";
        dataGridLabelColumn8.ReadOnly = true;
        dataGridLabelColumn8.Width = 75;
        dataGridLabelColumn8.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
        DataGridTextBoxColumn gridTextBoxColumn = new DataGridTextBoxColumn();
        gridTextBoxColumn.Format = "";
        gridTextBoxColumn.FormatInfo = (IFormatProvider) null;
        gridTextBoxColumn.HeaderText = "Enter Received ";
        gridTextBoxColumn.MappingName = "EnterReceived";
        gridTextBoxColumn.ReadOnly = false;
        gridTextBoxColumn.Width = 75;
        gridTextBoxColumn.NullText = "";
        gridTextBoxColumn.TextBox.BackColor = Color.LightYellow;
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridTextBoxColumn);
      }
      if (this.OrderConsolidation.ConsolidatedOrderStatusID == 4)
      {
        DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
        dataGridLabelColumn8.Format = "";
        dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn8.HeaderText = "No. Received";
        dataGridLabelColumn8.MappingName = "QuantityReceived";
        dataGridLabelColumn8.ReadOnly = true;
        dataGridLabelColumn8.Width = 75;
        dataGridLabelColumn8.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      }
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
      this.dgItems.TableStyles.Add(tableStyle);
    }

    public OrderConsolidation OrderConsolidation
    {
      get
      {
        return this._OrderConsolidation;
      }
      set
      {
        this._OrderConsolidation = value;
        if (this.OrderConsolidation == null)
        {
          this._OrderConsolidation = new OrderConsolidation();
          this._OrderConsolidation.Exists = false;
        }
        if (!this.OrderConsolidation.Exists)
        {
          this.Text = "Consolidation : Adding New...";
          this.OrderNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.CONSOLIDATION);
          ComboBox cboStatus = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(1));
          this.cboStatus = cboStatus;
          this.cboStatus.Enabled = false;
          this.btnPrint.Enabled = false;
          this.btnPrintDistribution.Enabled = false;
          this.btnReceiveAll.Enabled = false;
          this.chkPOSupplied.Enabled = false;
          this.txtSupplierInvoiceReference.ReadOnly = true;
          this.chkSupInvDateNA.Enabled = false;
          this.dtpSupplierInvoiceDate.Enabled = false;
          this.txtSupplierInvoiceAmount.ReadOnly = true;
          this.txtVAT.ReadOnly = true;
          this.cboTaxCode.Enabled = false;
          this.txtExtraReference.ReadOnly = true;
          this.txtNominalCode.ReadOnly = true;
          this.txtDepartment.ReadOnly = true;
          this.cbxReadyToSendToSage.Enabled = false;
        }
        else
        {
          this.btnPrint.Enabled = true;
          this.btnPrintDistribution.Enabled = true;
          this.Text = "Consolidation : ID " + Conversions.ToString(this.OrderConsolidation.OrderConsolidationID);
          this.Populate();
          this.OrderNumberUsed = true;
        }
        this.SetupDG();
        this.SetupItemsDG();
        this.IsLoading = false;
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
        this.OrderNumberUsed = false;
        this.OrderNumber.OrderNumber = Conversions.ToString(this.OrderNumber.JobNumber);
        while (this.OrderNumber.OrderNumber.Length < 6)
          this.OrderNumber.OrderNumber = "0" + this.OrderNumber.OrderNumber;
        this.txtReference.Text = this.OrderNumber.Prefix + this.OrderNumber.OrderNumber;
      }
    }

    public bool OrderNumberUsed
    {
      get
      {
        return this._OrderNumberUsed;
      }
      set
      {
        this._OrderNumberUsed = value;
      }
    }

    public Supplier Supplier
    {
      get
      {
        return this._Supplier;
      }
      set
      {
        this._Supplier = value;
        if (this.Supplier == null)
        {
          this.txtSupplier.Text = "";
        }
        else
        {
          this.txtSupplier.Text = this.Supplier.Name + " (" + this.Supplier.AccountNumber + ")";
          this.ItemsDataView = App.DB.OrderConsolidations.Order_GetItemForConsolidationID(this.OrderConsolidation.OrderConsolidationID, false);
          this.OrderDataView = !this.OrderConsolidation.Exists ? App.DB.OrderConsolidations.Order_GetForConsolidation(this._Supplier.SupplierID, 0) : (this.OrderConsolidation.ConsolidatedOrderStatusID != 1 ? App.DB.OrderConsolidations.Order_GetForConsolidationByID_Confirmed(this.OrderConsolidation.OrderConsolidationID, false) : App.DB.OrderConsolidations.Order_GetForConsolidationByID(this.OrderConsolidation.OrderConsolidationID, this._Supplier.SupplierID, 0));
        }
      }
    }

    public DataView OrderDataView
    {
      get
      {
        return this._OrderDataView;
      }
      set
      {
        this._OrderDataView = value;
        this._OrderDataView.Table.TableName = Enums.TableNames.tblOrder.ToString();
        this._OrderDataView.AllowNew = false;
        this._OrderDataView.AllowEdit = true;
        this._OrderDataView.AllowDelete = false;
        this.dgOrders.DataSource = (object) this.OrderDataView;
      }
    }

    private DataRow SelectedOrderDataRow
    {
      get
      {
        return this.dgOrders.CurrentRowIndex != -1 ? this.OrderDataView[this.dgOrders.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView ItemsDataView
    {
      get
      {
        return this._itemsDataView;
      }
      set
      {
        this._itemsDataView = value;
        this._itemsDataView.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
        this._itemsDataView.AllowNew = false;
        this._itemsDataView.AllowEdit = true;
        this._itemsDataView.AllowDelete = false;
        this.dgItems.DataSource = (object) this.ItemsDataView;
        double num = 0.0;
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.ItemsDataView.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            num += Conversions.ToDouble(Strings.FormatCurrency((object) (Helper.MakeDoubleValid((object) Strings.FormatCurrency(RuntimeHelpers.GetObjectValue(current["BuyPrice"]), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)) * Helper.MakeDoubleValid((object) Strings.FormatCurrency(RuntimeHelpers.GetObjectValue(current["QuantityOnOrder"]), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault))), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault));
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
          enumerator2 = App.DB.OrderCharge.OrderCharge_GetForConsolidatedOrder(this.OrderConsolidation.OrderConsolidationID).Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            num += Conversions.ToDouble(Strings.FormatCurrency(RuntimeHelpers.GetObjectValue(current["Amount"]), 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault));
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        this.lblOrderTotal.Text = "Order Total : " + Strings.FormatCurrency((object) num, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
      }
    }

    private DataRow SelectedItemDataRow
    {
      get
      {
        return this.dgItems.CurrentRowIndex != -1 ? this.ItemsDataView[this.dgItems.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void FRMConsolidation_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (!this.OrderNumberUsed)
        App.DB.Job.DeleteReservedOrderNumber(this.OrderNumber.JobNumber, this.OrderNumber.Prefix);
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnSupplier_Click(object sender, EventArgs e)
    {
      this.Supplier = App.DB.Supplier.Supplier_Get(Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSupplier, 0, "", false)));
    }

    private void chkSupInvDateNA_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkSupInvDateNA.Checked)
      {
        this.dtpSupplierInvoiceDate.Enabled = false;
        this.dtpSupplierInvoiceDate.Value = DateAndTime.Now.Date;
      }
      else
        this.dtpSupplierInvoiceDate.Enabled = true;
    }

    private void txtSupplierInvoiceAmount_GotFocus(object sender, EventArgs e)
    {
      this.txtSupplierInvoiceAmount.Text = "";
    }

    private void txtSupplierInvoiceAmount_Validating(object sender, CancelEventArgs e)
    {
      if ((uint) this.txtSupplierInvoiceAmount.Text.Trim().Length > 0U && Versioned.IsNumeric((object) this.txtSupplierInvoiceAmount.Text.Trim()))
        this.OrderConsolidation.SetSupplierInvoiceAmount = (object) Helper.MakeDoubleValid((object) this.txtSupplierInvoiceAmount.Text.Trim());
      this.txtSupplierInvoiceAmount.Text = Strings.Format((object) this.OrderConsolidation.SupplierInvoiceAmount, "C");
      this.Calculate_Tax();
    }

    private void txtVAT_GotFocus(object sender, EventArgs e)
    {
      this.txtVAT.Text = "";
    }

    private void txtVAT_Validating(object sender, CancelEventArgs e)
    {
      if ((uint) this.txtVAT.Text.Trim().Length > 0U && Versioned.IsNumeric((object) this.txtVAT.Text.Trim()))
        this.OrderConsolidation.SetVATAmount = (object) Helper.MakeDoubleValid((object) this.txtVAT.Text.Trim());
      this.txtVAT.Text = Strings.Format((object) this.OrderConsolidation.VATAmount, "C");
    }

    private void cboTaxCode_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Calculate_Tax();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void dgOrders_DoubleClick(object sender, EventArgs e)
    {
      switch (Conversions.ToInteger(this.SelectedOrderDataRow["OrderTypeID"]))
      {
        case 1:
          App.ShowForm(typeof (FRMOrder), true, new object[5]
          {
            this.SelectedOrderDataRow["OrderID"],
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedOrderDataRow["SiteID"])),
            (object) 0,
            (object) this,
            (object) true
          }, false);
          break;
        case 2:
          App.ShowForm(typeof (FRMOrder), true, new object[5]
          {
            this.SelectedOrderDataRow["OrderID"],
            this.SelectedOrderDataRow["VanID"],
            (object) 0,
            (object) this,
            (object) true
          }, false);
          break;
        case 3:
          App.ShowForm(typeof (FRMOrder), true, new object[5]
          {
            this.SelectedOrderDataRow["OrderID"],
            this.SelectedOrderDataRow["WarehouseID"],
            (object) 0,
            (object) this,
            (object) true
          }, false);
          break;
        case 4:
          App.ShowForm(typeof (FRMOrder), true, new object[5]
          {
            this.SelectedOrderDataRow["OrderID"],
            this.SelectedOrderDataRow["EngineerVisitID"],
            (object) 0,
            (object) this,
            (object) true
          }, false);
          break;
      }
      if (this.OrderConsolidation.Exists)
      {
        if (this.OrderConsolidation.ConsolidatedOrderStatusID == 1)
          this.OrderDataView = App.DB.OrderConsolidations.Order_GetForConsolidationByID(this.OrderConsolidation.OrderConsolidationID, this._Supplier.SupplierID, 0);
        else
          this.OrderDataView = App.DB.OrderConsolidations.Order_GetForConsolidationByID_Confirmed(this.OrderConsolidation.OrderConsolidationID, false);
      }
      else
        this.OrderDataView = App.DB.OrderConsolidations.Order_GetForConsolidation(this._Supplier.SupplierID, 0);
    }

    private void dgItems_MouseUp(object sender, MouseEventArgs e)
    {
      if (!this.DoubleClicked)
        return;
      try
      {
        if (this.SelectedItemDataRow == null)
          return;
        DataGrid.HitTestInfo hitTestInfo = this.dgItems.HitTest(e.X, e.Y);
        if (hitTestInfo.Row == -1 || this.ItemsDataView.Table.Rows[hitTestInfo.Row] == null || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.ItemsDataView.Table.Columns[hitTestInfo.Column].ColumnName.Trim().ToLower(), "BuyPrice".ToLower(), false) != 0)
          return;
        App.ShowForm(typeof (FRMPart), true, new object[2]
        {
          this.SelectedItemDataRow["PartProductID"],
          (object) true
        }, false);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void dgItems_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedItemDataRow == null)
          this.DoubleClicked = false;
        else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedItemDataRow["Type"], (object) "OrderPart", false))))
          this.DoubleClicked = false;
        else
          this.DoubleClicked = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.DoubleClicked = false;
        ProjectData.ClearProjectError();
      }
    }

    private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.IsLoading)
        return;
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) > 1.0)
      {
        bool flag = true;
        string str = "";
        IEnumerator enumerator;
        try
        {
          enumerator = this.OrderDataView.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["DepartmentRef"])).Length == 0)
            {
              flag = false;
              str = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str, current["OrderReference"]));
              break;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        if (!flag)
        {
          int num = (int) App.ShowMessage("Order " + str + " is missing a department code", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          ComboBox cboStatus = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.OrderConsolidation.ConsolidatedOrderStatusID));
          this.cboStatus = cboStatus;
          return;
        }
      }
      string Left = Combo.get_GetSelectedItemValue(this.cboStatus);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
      {
        if (this.OrderConsolidation.ConsolidatedOrderStatusID == 1)
          return;
        if (this.OrderConsolidation.ConsolidatedOrderStatusID > 1)
        {
          int num = (int) App.ShowMessage("You cannot go back once the consolidation has progressed.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ComboBox cboStatus = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.OrderConsolidation.ConsolidatedOrderStatusID));
          this.cboStatus = cboStatus;
          return;
        }
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
      {
        if (this.OrderConsolidation.ConsolidatedOrderStatusID == 2)
          return;
        if (this.OrderConsolidation.ConsolidatedOrderStatusID > 2)
        {
          int num = (int) App.ShowMessage("You cannot go back once the consolidation has progressed.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ComboBox cboStatus = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.OrderConsolidation.ConsolidatedOrderStatusID));
          this.cboStatus = cboStatus;
          return;
        }
        if (App.ShowMessage("Are you sure you want to confirm this consolidation and all related orders? No changes can be made to orders once it has been confirmed.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
          ComboBox cboStatus = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.OrderConsolidation.ConsolidatedOrderStatusID));
          this.cboStatus = cboStatus;
          return;
        }
        this.OrderConsolidation.SetConsolidatedOrderStatusID = 2;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
      {
        if (this.OrderConsolidation.ConsolidatedOrderStatusID == 3)
          return;
        if (this.OrderConsolidation.ConsolidatedOrderStatusID > 3)
        {
          int num = (int) App.ShowMessage("You cannot go back once the consolidation has progressed.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ComboBox cboStatus = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.OrderConsolidation.ConsolidatedOrderStatusID));
          this.cboStatus = cboStatus;
          return;
        }
        if (App.ShowMessage("Are you sure you want to cancel this consolidation and all related orders?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          this.OrderConsolidation.SetConsolidatedOrderStatusID = 3;
        }
        else
        {
          ComboBox cboStatus = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.OrderConsolidation.ConsolidatedOrderStatusID));
          this.cboStatus = cboStatus;
          return;
        }
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
      {
        if (this.OrderConsolidation.ConsolidatedOrderStatusID == 4)
          return;
        if (this.OrderConsolidation.ConsolidatedOrderStatusID < 4)
        {
          int num = (int) App.ShowMessage("You cannot complete a consolidation manually.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ComboBox cboStatus = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.OrderConsolidation.ConsolidatedOrderStatusID));
          this.cboStatus = cboStatus;
          return;
        }
      }
      App.DB.OrderConsolidations.Update(this.OrderConsolidation);
      this.OrderConsolidation = App.DB.OrderConsolidations.OrderConsolidation_Get(this.OrderConsolidation.OrderConsolidationID);
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      this.PrintSupplierPurchaseOrders(false);
    }

    private void btnPrintDistribution_Click(object sender, EventArgs e)
    {
      this.PrintSupplierPurchaseOrders(true);
    }

    private void btnReceiveAll_Click(object sender, EventArgs e)
    {
      if (this.OrderConsolidation.ConsolidatedOrderStatusID == 1)
      {
        int num1 = (int) App.ShowMessage("Consolidation must be confirmed to receive stock", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.OrderConsolidation.ConsolidatedOrderStatusID == 3)
      {
        int num2 = (int) App.ShowMessage("Consolidation has been cancelled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.OrderConsolidation.ConsolidatedOrderStatusID == 4)
      {
        int num3 = (int) App.ShowMessage("Consolidation is fully received", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.OrderConsolidation.ConsolidatedOrderStatusID == 5)
      {
        int num4 = (int) App.ShowMessage("Consolidation is fully received", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.OrderConsolidation.ConsolidatedOrderStatusID == 6)
      {
        int num5 = (int) App.ShowMessage("Consolidation is fully received", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        IEnumerator enumerator;
        try
        {
          enumerator = this.ItemsDataView.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            current["EnterReceived"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(current["QuantityOnOrder"], current["QuantityReceived"]);
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(current["EnterReceived"], (object) 0, false))
              current["EnterReceived"] = (object) 0;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.Save();
      }
    }

    private void Populate()
    {
      this.txtReference.Text = this.OrderConsolidation.ConsolidationRef;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.OrderConsolidation.ConsolidatedOrderStatusID));
      this.cboStatus = cboStatus;
      this.Supplier = App.DB.Supplier.Supplier_Get(this.OrderConsolidation.SupplierID);
      this.txtComments.Text = this.OrderConsolidation.Comments;
      this.chkPOSupplied.Checked = this.OrderConsolidation.HasSupplierPO;
      this.txtSupplierInvoiceReference.Text = this.OrderConsolidation.SupplierInvoiceReference;
      if (DateTime.Compare(this.OrderConsolidation.SupplierInvoiceDate, DateTime.MinValue) == 0)
      {
        this.chkSupInvDateNA.Checked = true;
        this.dtpSupplierInvoiceDate.Value = DateAndTime.Now.Date;
        this.dtpSupplierInvoiceDate.Enabled = false;
      }
      else
      {
        this.chkSupInvDateNA.Checked = false;
        this.dtpSupplierInvoiceDate.Value = this.OrderConsolidation.SupplierInvoiceDate.Date;
        this.dtpSupplierInvoiceDate.Enabled = true;
      }
      this.txtSupplierInvoiceAmount.Text = Strings.Format((object) this.OrderConsolidation.SupplierInvoiceAmount, "C");
      ComboBox cboTaxCode = this.cboTaxCode;
      Combo.SetSelectedComboItem_By_Value(ref cboTaxCode, Conversions.ToString(this.OrderConsolidation.TaxCodeID));
      this.cboTaxCode = cboTaxCode;
      this.txtVAT.Text = Strings.Format((object) this.OrderConsolidation.VATAmount, "C");
      this.txtExtraReference.Text = this.OrderConsolidation.ExtraRef;
      this.txtNominalCode.Text = this.OrderConsolidation.NominalCode;
      this.txtDepartment.Text = this.OrderConsolidation.DepartmentRef;
      this.cbxReadyToSendToSage.Checked = this.OrderConsolidation.ReadyToSendToSage;
      this.txtReference.ReadOnly = true;
      this.btnSupplier.Enabled = false;
      if (this.OrderConsolidation.ConsolidatedOrderStatusID == 3 | this.OrderConsolidation.ConsolidatedOrderStatusID == 4)
      {
        this.cboStatus.Enabled = false;
        this.btnReceiveAll.Enabled = false;
        if (this.OrderConsolidation.ConsolidatedOrderStatusID == 3)
          this.btnSave.Enabled = false;
        else
          this.btnSave.Enabled = true;
      }
      else
      {
        this.cboStatus.Enabled = true;
        this.btnSave.Enabled = true;
        this.btnReceiveAll.Enabled = true;
      }
      if (this.OrderConsolidation.SentToSage)
      {
        this.chkPOSupplied.Enabled = false;
        this.txtSupplierInvoiceReference.ReadOnly = true;
        this.chkSupInvDateNA.Enabled = false;
        this.dtpSupplierInvoiceDate.Enabled = false;
        this.txtSupplierInvoiceAmount.ReadOnly = true;
        this.txtVAT.ReadOnly = true;
        this.cboTaxCode.Enabled = false;
        this.txtExtraReference.ReadOnly = true;
        this.txtNominalCode.ReadOnly = true;
        this.txtDepartment.ReadOnly = true;
        this.cbxReadyToSendToSage.Enabled = false;
        this.btnSave.Enabled = false;
        this.lblStatus.Text = "*Supplier PI was Sent to Sage on " + Strings.Format((object) this.OrderConsolidation.DateExported, "dd/MMM/yyyy") + "*";
      }
      else if (this.OrderConsolidation.ReadyToSendToSage)
      {
        this.chkPOSupplied.Enabled = false;
        this.txtSupplierInvoiceReference.ReadOnly = true;
        this.chkSupInvDateNA.Enabled = false;
        this.dtpSupplierInvoiceDate.Enabled = false;
        this.txtSupplierInvoiceAmount.ReadOnly = true;
        this.txtVAT.ReadOnly = true;
        this.cboTaxCode.Enabled = false;
        this.txtExtraReference.ReadOnly = true;
        this.txtNominalCode.ReadOnly = true;
        this.txtDepartment.ReadOnly = true;
        this.cbxReadyToSendToSage.Enabled = true;
        this.lblStatus.Text = "*Supplier PI is ready to be sent to Sage*";
      }
      else if (this.OrderConsolidation.HasSupplierPO)
      {
        this.chkPOSupplied.Enabled = true;
        this.txtSupplierInvoiceReference.ReadOnly = false;
        this.chkSupInvDateNA.Enabled = true;
        this.txtSupplierInvoiceAmount.ReadOnly = false;
        this.txtVAT.ReadOnly = false;
        this.cboTaxCode.Enabled = true;
        this.txtExtraReference.ReadOnly = false;
        this.txtNominalCode.ReadOnly = false;
        this.txtDepartment.ReadOnly = false;
        this.cbxReadyToSendToSage.Enabled = true;
        this.lblStatus.Text = "*Supplier PI is assigned but not ready to be sent to Sage*";
      }
      else
      {
        this.chkPOSupplied.Enabled = true;
        this.txtSupplierInvoiceReference.ReadOnly = true;
        this.chkSupInvDateNA.Enabled = false;
        this.dtpSupplierInvoiceDate.Enabled = false;
        this.txtSupplierInvoiceAmount.ReadOnly = true;
        this.txtVAT.ReadOnly = true;
        this.cboTaxCode.Enabled = false;
        this.txtExtraReference.ReadOnly = true;
        this.txtNominalCode.ReadOnly = true;
        this.txtDepartment.ReadOnly = true;
        this.cbxReadyToSendToSage.Enabled = false;
        this.lblStatus.Text = "*Supplier PI has NOT been assigned so should be actioned within each related order*";
      }
    }

    private void Calculate_Tax()
    {
      if (this.IsLoading)
        return;
      if (this.OrderConsolidation == null)
        this.txtVAT.Text = Strings.Format((object) 0.0, "C");
      else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboTaxCode)) == 0.0)
      {
        this.txtVAT.Text = Strings.Format((object) this.OrderConsolidation.VATAmount, "C");
      }
      else
      {
        try
        {
          this.OrderConsolidation.SetVATAmount = (object) (this.OrderConsolidation.SupplierInvoiceAmount * (App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboTaxCode))).PercentageRate / 100.0));
          this.txtVAT.Text = Strings.Format((object) this.OrderConsolidation.VATAmount, "C");
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.txtVAT.Text = Strings.Format((object) this.OrderConsolidation.VATAmount, "C");
          ProjectData.ClearProjectError();
        }
      }
    }

    private void Save()
    {
      try
      {
        bool flag = true;
        IEnumerator enumerator1;
        if (this.OrderConsolidation.ConsolidatedOrderStatusID == 2)
        {
          if (this.ItemsDataView != null)
          {
            try
            {
              enumerator1 = this.ItemsDataView.Table.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current = (DataRow) enumerator1.Current;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["EnterReceived"])), current["QuantityReceived"]), current["QuantityOnOrder"], false))
                  flag = false;
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
          }
        }
        if (!flag && App.ShowMessage("Some of the amounts entered for received are greater than the quantity ordered. Are you sure you wish to receive this quantity of stock?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        this.Cursor = Cursors.WaitCursor;
        this.OrderConsolidation.IgnoreExceptionsOnSetMethods = true;
        this.OrderConsolidation.SetConsolidationRef = (object) this.txtReference.Text.Trim();
        this.OrderConsolidation.SetComments = (object) this.txtComments.Text.Trim();
        this.OrderConsolidation.SetSupplierID = this.Supplier != null ? (object) this.Supplier.SupplierID : (object) 0;
        this.OrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboStatus));
        this.OrderConsolidation.HasSupplierPO = this.chkPOSupplied.Checked;
        this.OrderConsolidation.SetSupplierInvoiceReference = (object) this.txtSupplierInvoiceReference.Text.Trim();
        this.OrderConsolidation.SupplierInvoiceDate = !this.chkSupInvDateNA.Checked ? this.dtpSupplierInvoiceDate.Value.Date : DateTime.MinValue;
        this.OrderConsolidation.SetTaxCodeID = (object) Combo.get_GetSelectedItemValue(this.cboTaxCode);
        this.OrderConsolidation.SetExtraRef = (object) this.txtExtraReference.Text.Trim();
        this.OrderConsolidation.SetNominalCode = (object) this.txtNominalCode.Text.Trim();
        this.OrderConsolidation.SetDepartmentRef = (object) this.txtDepartment.Text.Trim();
        this.OrderConsolidation.SetReadyToSendToSage = this.cbxReadyToSendToSage.Checked;
        new OrderConsolidationValidator().Validate(this.OrderConsolidation, false);
        if (this.OrderConsolidation.ReadyToSendToSage)
        {
          double num1 = 0.0;
          IEnumerator enumerator2;
          try
          {
            enumerator2 = this.ItemsDataView.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              num1 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num1, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["BuyPrice"], current["QuantityOnOrder"])));
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          IEnumerator enumerator3;
          try
          {
            enumerator3 = App.DB.OrderCharge.OrderCharge_GetForConsolidatedOrder(this.OrderConsolidation.OrderConsolidationID).Table.Rows.GetEnumerator();
            while (enumerator3.MoveNext())
            {
              DataRow current = (DataRow) enumerator3.Current;
              num1 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num1, current["Amount"]));
            }
          }
          finally
          {
            if (enumerator3 is IDisposable)
              (enumerator3 as IDisposable).Dispose();
          }
          if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Format((object) this.OrderConsolidation.SupplierInvoiceAmount, "F"), Strings.Format((object) num1, "F"), false) > 0U)
          {
            int num2 = (int) App.ShowMessage("The entered supplier invoice amount does not match the total of the consolidation. You will now be prompted to enter the override password to continue", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (!App.EnterOverridePassword())
              return;
          }
        }
        if (!this.OrderConsolidation.Exists)
        {
          this.OrderConsolidation.SetOrderConsolidationID = (object) App.DB.OrderConsolidations.Insert(this.OrderConsolidation);
          this.OrderNumberUsed = true;
        }
        App.DB.OrderConsolidations.OrderConsolidation_Clear_Orders(this.OrderConsolidation.OrderConsolidationID);
        DataRow[] dataRowArray = this.OrderDataView.Table.Select("Tick = True");
        int index = 0;
        while (index < dataRowArray.Length)
        {
          DataRow dataRow = dataRowArray[index];
          App.DB.OrderConsolidations.Order_Set_Consolidated(this.OrderConsolidation.OrderConsolidationID, Conversions.ToInteger(dataRow["OrderID"]), false);
          checked { ++index; }
        }
        if (this.OrderConsolidation.ConsolidatedOrderStatusID == 2)
          this.ReceivedQuantityUpdated();
        App.DB.OrderConsolidations.Update(this.OrderConsolidation);
        this.IsLoading = true;
        this.OrderConsolidation = App.DB.OrderConsolidations.OrderConsolidation_Get(this.OrderConsolidation.OrderConsolidationID);
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

    private void ReceivedQuantityUpdated()
    {
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.ItemsDataView.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["EnterReceived"])) > 0)
            this.SaveReceived(Conversions.ToString(current["Type"]), Conversions.ToInteger(current["EnterReceived"]), Conversions.ToInteger(current["OrderProductPartID"]), Conversions.ToInteger(current["OrderTypeID"]));
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      DataSet dataSet = App.DB.OrderConsolidations.Orders_Complete_ByConsolidationOrderID(this.OrderConsolidation.OrderConsolidationID);
      IEnumerator enumerator2;
      try
      {
        enumerator2 = dataSet.Tables[0].Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current1 = (DataRow) enumerator2.Current;
          DataView forEngineerVisit = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(Conversions.ToInteger(current1["EngineerVisitID"]));
          bool flag = true;
          IEnumerator enumerator3;
          try
          {
            enumerator3 = forEngineerVisit.Table.Rows.GetEnumerator();
            while (enumerator3.MoveNext())
            {
              DataRow current2 = (DataRow) enumerator3.Current;
              if ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current2["OrderStatusID"])) > 0U && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current2["OrderStatusID"], (object) 4, false))))
                flag = false;
            }
          }
          finally
          {
            if (enumerator3 is IDisposable)
              (enumerator3 as IDisposable).Dispose();
          }
          if (flag)
            App.ShowForm(typeof (FRMPickDespatchDetails), true, new object[1]
            {
              (object) App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(current1["EngineerVisitID"]), true)
            }, false);
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      IEnumerator enumerator4;
      try
      {
        enumerator4 = dataSet.Tables[1].Rows.GetEnumerator();
        while (enumerator4.MoveNext())
        {
          DataRow current = (DataRow) enumerator4.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceToBeRaisedID"], (object) 0, false) && App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "The customer order '", current["OrderDetails"]), (object) "' which this consolidation relates to requires an invoice address. Would you like to assign now?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            App.ShowForm(typeof (FrmRaiseInvoiceDetails), true, new object[2]
            {
              current["OrderID"],
              current["InvoiceAddressID"]
            }, false);
        }
      }
      finally
      {
        if (enumerator4 is IDisposable)
          (enumerator4 as IDisposable).Dispose();
      }
      this.OrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(dataSet.Tables[2].Rows[0]["ConsolidatedOrderStatusID"]);
    }

    private void SaveReceived(
      string Type,
      int QuantityInput,
      int OrderProductPartID,
      int OrderTypeID)
    {
      string Left = Type;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderPart", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderProduct", false) != 0)
          return;
        OrderProduct oOrderProduct = App.DB.OrderProduct.OrderProduct_Get(OrderProductPartID);
        oOrderProduct.SetQuantityReceived = (object) checked (oOrderProduct.QuantityReceived + QuantityInput);
        App.DB.OrderProduct.Update(oOrderProduct);
        switch (OrderTypeID)
        {
          case 3:
            OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(oOrderProduct.OrderID);
            ProductSupplier productSupplier = App.DB.ProductSupplier.ProductSupplier_Get(oOrderProduct.ProductSupplierID);
            App.DB.ProductTransaction.Insert(new ProductTransaction()
            {
              SetLocationID = (object) forOrder.LocationID,
              SetProductID = (object) productSupplier.ProductID,
              SetOrderProductID = (object) oOrderProduct.OrderProductID,
              SetAmount = (object) ((double) QuantityInput * productSupplier.QuantityInPack),
              SetTransactionTypeID = (object) 2
            });
            break;
        }
      }
      else
      {
        OrderPart oOrderPart = App.DB.OrderPart.OrderPart_Get(OrderProductPartID);
        oOrderPart.SetQuantityReceived = (object) checked (oOrderPart.QuantityReceived + QuantityInput);
        App.DB.OrderPart.Update(oOrderPart);
        switch (OrderTypeID)
        {
          case 3:
            OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(oOrderPart.OrderID);
            PartSupplier partSupplier = App.DB.PartSupplier.PartSupplier_Get(oOrderPart.PartSupplierID);
            App.DB.PartTransaction.Insert(new PartTransaction()
            {
              SetLocationID = (object) forOrder.LocationID,
              SetPartID = (object) partSupplier.PartID,
              SetOrderPartID = (object) oOrderPart.OrderPartID,
              SetAmount = (object) ((double) QuantityInput * partSupplier.QuantityInPack),
              SetTransactionTypeID = (object) 2
            });
            break;
        }
      }
    }

    public void PrintSupplierPurchaseOrders(bool ShowDestination)
    {
      DataTable table = new DataTable();
      table.Columns.Add("OrderChargeID");
      table.Columns.Add("OrderID");
      table.Columns.Add("OrderChargeTypeID");
      table.Columns.Add("Amount");
      table.Columns.Add("Reference");
      table.Columns.Add("ChargeType");
      table.Columns.Add("Deleted");
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) this.OrderConsolidation.ConsolidationRef);
      arrayList.Add((object) App.DB.Supplier.Supplier_Get(this.OrderConsolidation.SupplierID));
      arrayList.Add((object) this.ItemsDataView.Table);
      DateTime dateTime = DateTime.MaxValue;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.OrderDataView.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current1 = (DataRow) enumerator1.Current;
          if (DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current1["DeliveryDeadline"])).Date, dateTime.Date) < 0)
            dateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current1["DeliveryDeadline"])).Date;
          DataView forOrder = App.DB.OrderCharge.OrderCharge_GetForOrder(Conversions.ToInteger(current1["OrderID"]));
          IEnumerator enumerator2;
          try
          {
            enumerator2 = forOrder.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current2 = (DataRow) enumerator2.Current;
              DataRow row = table.NewRow();
              row["OrderChargeID"] = RuntimeHelpers.GetObjectValue(current2["OrderChargeID"]);
              row["OrderID"] = RuntimeHelpers.GetObjectValue(current2["OrderID"]);
              row["OrderChargeTypeID"] = RuntimeHelpers.GetObjectValue(current2["OrderChargeTypeID"]);
              row["Amount"] = RuntimeHelpers.GetObjectValue(current2["Amount"]);
              row["Reference"] = RuntimeHelpers.GetObjectValue(current2["Reference"]);
              row["ChargeType"] = RuntimeHelpers.GetObjectValue(current2["ChargeType"]);
              row["Deleted"] = RuntimeHelpers.GetObjectValue(current2["Deleted"]);
              table.Rows.Add(row);
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      arrayList.Add((object) dateTime);
      arrayList.Add((object) new DataView(table));
      if (ShowDestination)
      {
        Printing printing1 = new Printing((object) arrayList, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder_WithDestination, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      }
      else
      {
        Printing printing2 = new Printing((object) arrayList, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      }
    }
  }
}
