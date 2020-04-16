// Decompiled with JetBrains decompiler
// Type: FSM.FRMJobCostings
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisits;
using FSM.Entity.JobInstalls;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.Sys;
using FSM.Entity.VATRatess;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FSM
{
  public class FRMJobCostings : FRMBaseForm
  {
    private IContainer components;
    private int vatRateID;
    private VATRates vatRate;
    private DataView _TimeSheetCharges;
    private DataView _ScheduleOfRateCharges;
    private DataView _PartProductsCharges;
    private Job _CurrentJob;
    private JobInstall _JI;

    public FRMJobCostings(Job oJob)
    {
      this.Load += new EventHandler(this.LoadMe);
      this.Load += new EventHandler(this.FRMLogCallout_Load);
      this.vatRate = new VATRates();
      this._CurrentJob = (Job) null;
      this.InitializeComponent();
      this.CurrentJob = oJob;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
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

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPrintJobCosting
    {
      get
      {
        return this._btnPrintJobCosting;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintJobCosting_Click);
        Button btnPrintJobCosting1 = this._btnPrintJobCosting;
        if (btnPrintJobCosting1 != null)
          btnPrintJobCosting1.Click -= eventHandler;
        this._btnPrintJobCosting = value;
        Button btnPrintJobCosting2 = this._btnPrintJobCosting;
        if (btnPrintJobCosting2 == null)
          return;
        btnPrintJobCosting2.Click += eventHandler;
      }
    }

    internal virtual TabPage tpJobCostings { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpInstall { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDeposit
    {
      get
      {
        return this._txtDeposit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtDeposit_TextChanged);
        TextBox txtDeposit1 = this._txtDeposit;
        if (txtDeposit1 != null)
          txtDeposit1.KeyUp -= keyEventHandler;
        this._txtDeposit = value;
        TextBox txtDeposit2 = this._txtDeposit;
        if (txtDeposit2 == null)
          return;
        txtDeposit2.KeyUp += keyEventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCalledSuper { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSurveyed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPO { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProfitActPerc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProfitEstPerc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProfitActMoney { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProfitEstMoney { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTotalEst { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTotalAct { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEstLabour
    {
      get
      {
        return this._txtEstLabour;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEstLabour_TextChanged);
        TextBox txtEstLabour1 = this._txtEstLabour;
        if (txtEstLabour1 != null)
          txtEstLabour1.TextChanged -= eventHandler;
        this._txtEstLabour = value;
        TextBox txtEstLabour2 = this._txtEstLabour;
        if (txtEstLabour2 == null)
          return;
        txtEstLabour2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtActLabour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartEst
    {
      get
      {
        return this._txtPartEst;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPartEst_TextChanged);
        TextBox txtPartEst1 = this._txtPartEst;
        if (txtPartEst1 != null)
          txtPartEst1.TextChanged -= eventHandler;
        this._txtPartEst = value;
        TextBox txtPartEst2 = this._txtPartEst;
        if (txtPartEst2 == null)
          return;
        txtPartEst2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtPartAct { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPaperwork { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQC { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPayment
    {
      get
      {
        return this._txtPayment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPayment_TextChanged);
        TextBox txtPayment1 = this._txtPayment;
        if (txtPayment1 != null)
          txtPayment1.TextChanged -= eventHandler;
        this._txtPayment = value;
        TextBox txtPayment2 = this._txtPayment;
        if (txtPayment2 == null)
          return;
        txtPayment2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFurtherWorks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboExtraLabour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQuoted
    {
      get
      {
        return this._txtQuoted;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.TextBox1_TextChanged);
        TextBox txtQuoted1 = this._txtQuoted;
        if (txtQuoted1 != null)
          txtQuoted1.KeyUp -= keyEventHandler;
        this._txtQuoted = value;
        TextBox txtQuoted2 = this._txtQuoted;
        if (txtQuoted2 == null)
          return;
        txtQuoted2.KeyUp += keyEventHandler;
      }
    }

    internal virtual Label lblQuoted { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label26 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label25 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label23 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEstElec
    {
      get
      {
        return this._txtEstElec;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEstElectrical_TextChanged);
        TextBox txtEstElec1 = this._txtEstElec;
        if (txtEstElec1 != null)
          txtEstElec1.TextChanged -= eventHandler;
        this._txtEstElec = value;
        TextBox txtEstElec2 = this._txtEstElec;
        if (txtEstElec2 == null)
          return;
        txtEstElec2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtActElec { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label21 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label22 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQuotedGross
    {
      get
      {
        return this._txtQuotedGross;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtQuotedGross_TextChanged);
        TextBox txtQuotedGross1 = this._txtQuotedGross;
        if (txtQuotedGross1 != null)
          txtQuotedGross1.KeyUp -= keyEventHandler;
        this._txtQuotedGross = value;
        TextBox txtQuotedGross2 = this._txtQuotedGross;
        if (txtQuotedGross2 == null)
          return;
        txtQuotedGross2.KeyUp += keyEventHandler;
      }
    }

    internal virtual TextBox txtDepositGross
    {
      get
      {
        return this._txtDepositGross;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtDepositGross_TextChanged);
        TextBox txtDepositGross1 = this._txtDepositGross;
        if (txtDepositGross1 != null)
          txtDepositGross1.KeyUp -= keyEventHandler;
        this._txtDepositGross = value;
        TextBox txtDepositGross2 = this._txtDepositGross;
        if (txtDepositGross2 == null)
          return;
        txtDepositGross2.KeyUp += keyEventHandler;
      }
    }

    internal virtual Label Label28 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label27 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplierInv { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtManual
    {
      get
      {
        return this._txtManual;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtManual_TextChanged);
        TextBox txtManual1 = this._txtManual;
        if (txtManual1 != null)
          txtManual1.KeyUp -= keyEventHandler;
        this._txtManual = value;
        TextBox txtManual2 = this._txtManual;
        if (txtManual2 == null)
          return;
        txtManual2.KeyUp += keyEventHandler;
      }
    }

    internal virtual Label Label31 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEstSub
    {
      get
      {
        return this._txtEstSub;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEstSub_TextChanged);
        TextBox txtEstSub1 = this._txtEstSub;
        if (txtEstSub1 != null)
          txtEstSub1.TextChanged -= eventHandler;
        this._txtEstSub = value;
        TextBox txtEstSub2 = this._txtEstSub;
        if (txtEstSub2 == null)
          return;
        txtEstSub2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtActSub { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label29 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label30 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpTotalCostings { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label32 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label33 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProfitPerc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox TxtProfitPounds { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbl5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label34 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSales { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCosts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpPartCostings { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label35 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label36 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label37 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label38 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLabourCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label41 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSorTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label40 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox TextBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label39 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSORSales { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgTimesheetCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPartsProductCharging { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgScheduleOfRateCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label43 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartPerc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label42 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLabourPerc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnClose = new Button();
      this.btnSave = new Button();
      this.TabControl1 = new TabControl();
      this.tpJobCostings = new TabPage();
      this.grpTotalCostings = new GroupBox();
      this.Label41 = new Label();
      this.txtSorTotal = new TextBox();
      this.Label32 = new Label();
      this.Label33 = new Label();
      this.txtProfitPerc = new TextBox();
      this.TxtProfitPounds = new TextBox();
      this.lbl5 = new Label();
      this.Label34 = new Label();
      this.txtSales = new TextBox();
      this.txtCosts = new TextBox();
      this.grpPartCostings = new GroupBox();
      this.Label43 = new Label();
      this.txtPartPerc = new TextBox();
      this.Label42 = new Label();
      this.txtLabourPerc = new TextBox();
      this.dgScheduleOfRateCharges = new DataGrid();
      this.dgPartsProductCharging = new DataGrid();
      this.Label40 = new Label();
      this.TextBox2 = new TextBox();
      this.Label39 = new Label();
      this.txtSORSales = new TextBox();
      this.dgTimesheetCharges = new DataGrid();
      this.Label35 = new Label();
      this.Label36 = new Label();
      this.Label37 = new Label();
      this.Label38 = new Label();
      this.lbl1 = new Label();
      this.txtPartCost = new TextBox();
      this.txtLabourCost = new TextBox();
      this.tpInstall = new TabPage();
      this.GroupBox1 = new GroupBox();
      this.txtManual = new TextBox();
      this.Label31 = new Label();
      this.txtEstSub = new TextBox();
      this.txtActSub = new TextBox();
      this.Label29 = new Label();
      this.Label30 = new Label();
      this.Label28 = new Label();
      this.Label27 = new Label();
      this.txtSupplierInv = new TextBox();
      this.Label26 = new Label();
      this.Label25 = new Label();
      this.Label24 = new Label();
      this.Label23 = new Label();
      this.txtEstElec = new TextBox();
      this.txtActElec = new TextBox();
      this.Label21 = new Label();
      this.Label22 = new Label();
      this.txtQuotedGross = new TextBox();
      this.txtDepositGross = new TextBox();
      this.txtQuoted = new TextBox();
      this.lblQuoted = new Label();
      this.txtProfitActPerc = new TextBox();
      this.Label18 = new Label();
      this.txtProfitEstPerc = new TextBox();
      this.Label16 = new Label();
      this.txtProfitActMoney = new TextBox();
      this.Label15 = new Label();
      this.txtProfitEstMoney = new TextBox();
      this.Label14 = new Label();
      this.txtTotalEst = new TextBox();
      this.txtTotalAct = new TextBox();
      this.Label12 = new Label();
      this.Label13 = new Label();
      this.txtEstLabour = new TextBox();
      this.txtActLabour = new TextBox();
      this.Label5 = new Label();
      this.Label17 = new Label();
      this.txtPartEst = new TextBox();
      this.txtPartAct = new TextBox();
      this.Label19 = new Label();
      this.Label20 = new Label();
      this.Label11 = new Label();
      this.cboPaperwork = new ComboBox();
      this.Label10 = new Label();
      this.cboQC = new ComboBox();
      this.txtPayment = new TextBox();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.cboFurtherWorks = new ComboBox();
      this.Label7 = new Label();
      this.cboExtraLabour = new ComboBox();
      this.txtPO = new TextBox();
      this.Label6 = new Label();
      this.Label4 = new Label();
      this.cboCalledSuper = new ComboBox();
      this.Label3 = new Label();
      this.cboSurveyed = new ComboBox();
      this.txtDeposit = new TextBox();
      this.Label2 = new Label();
      this.btnPrintJobCosting = new Button();
      this.TabControl1.SuspendLayout();
      this.tpJobCostings.SuspendLayout();
      this.grpTotalCostings.SuspendLayout();
      this.grpPartCostings.SuspendLayout();
      this.dgScheduleOfRateCharges.BeginInit();
      this.dgPartsProductCharging.BeginInit();
      this.dgTimesheetCharges.BeginInit();
      this.tpInstall.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(70, 664);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 23);
      this.btnClose.TabIndex = 16;
      this.btnClose.Text = "Close";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Location = new System.Drawing.Point(8, 664);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 23);
      this.btnSave.TabIndex = 15;
      this.btnSave.Text = "Save";
      this.TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TabControl1.Controls.Add((Control) this.tpJobCostings);
      this.TabControl1.Controls.Add((Control) this.tpInstall);
      this.TabControl1.Location = new System.Drawing.Point(0, 31);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(942, 627);
      this.TabControl1.TabIndex = 23;
      this.tpJobCostings.Controls.Add((Control) this.grpTotalCostings);
      this.tpJobCostings.Controls.Add((Control) this.grpPartCostings);
      this.tpJobCostings.Location = new System.Drawing.Point(4, 22);
      this.tpJobCostings.Name = "tpJobCostings";
      this.tpJobCostings.Padding = new Padding(3);
      this.tpJobCostings.Size = new Size(934, 601);
      this.tpJobCostings.TabIndex = 5;
      this.tpJobCostings.Text = "Job Costings";
      this.tpJobCostings.UseVisualStyleBackColor = true;
      this.grpTotalCostings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpTotalCostings.Controls.Add((Control) this.Label41);
      this.grpTotalCostings.Controls.Add((Control) this.txtSorTotal);
      this.grpTotalCostings.Controls.Add((Control) this.Label32);
      this.grpTotalCostings.Controls.Add((Control) this.Label33);
      this.grpTotalCostings.Controls.Add((Control) this.txtProfitPerc);
      this.grpTotalCostings.Controls.Add((Control) this.TxtProfitPounds);
      this.grpTotalCostings.Controls.Add((Control) this.lbl5);
      this.grpTotalCostings.Controls.Add((Control) this.Label34);
      this.grpTotalCostings.Controls.Add((Control) this.txtSales);
      this.grpTotalCostings.Controls.Add((Control) this.txtCosts);
      this.grpTotalCostings.Location = new System.Drawing.Point(4, 477);
      this.grpTotalCostings.Name = "grpTotalCostings";
      this.grpTotalCostings.Size = new Size(928, 80);
      this.grpTotalCostings.TabIndex = 7;
      this.grpTotalCostings.TabStop = false;
      this.Label41.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label41.AutoSize = true;
      this.Label41.Location = new System.Drawing.Point(510, 11);
      this.Label41.Name = "Label41";
      this.Label41.Size = new Size(67, 13);
      this.Label41.TabIndex = 13;
      this.Label41.Text = "SOR Sales";
      this.txtSorTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtSorTotal.Location = new System.Drawing.Point(500, 30);
      this.txtSorTotal.Name = "txtSorTotal";
      this.txtSorTotal.Size = new Size(100, 21);
      this.txtSorTotal.TabIndex = 14;
      this.Label32.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label32.AutoSize = true;
      this.Label32.Location = new System.Drawing.Point(748, 47);
      this.Label32.Name = "Label32";
      this.Label32.Size = new Size(53, 13);
      this.Label32.TabIndex = 11;
      this.Label32.Text = "Profit %";
      this.Label33.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label33.AutoSize = true;
      this.Label33.Location = new System.Drawing.Point(748, 20);
      this.Label33.Name = "Label33";
      this.Label33.Size = new Size(48, 13);
      this.Label33.TabIndex = 9;
      this.Label33.Text = "Profit £";
      this.txtProfitPerc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtProfitPerc.Location = new System.Drawing.Point(806, 41);
      this.txtProfitPerc.Name = "txtProfitPerc";
      this.txtProfitPerc.Size = new Size(100, 21);
      this.txtProfitPerc.TabIndex = 12;
      this.TxtProfitPounds.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.TxtProfitPounds.Location = new System.Drawing.Point(806, 14);
      this.TxtProfitPounds.Name = "TxtProfitPounds";
      this.TxtProfitPounds.Size = new Size(100, 21);
      this.TxtProfitPounds.TabIndex = 10;
      this.lbl5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbl5.AutoSize = true;
      this.lbl5.Location = new System.Drawing.Point(632, 11);
      this.lbl5.Name = "lbl5";
      this.lbl5.Size = new Size(74, 13);
      this.lbl5.TabIndex = 7;
      this.lbl5.Text = "Other Sales";
      this.Label34.AutoSize = true;
      this.Label34.Location = new System.Drawing.Point(36, 11);
      this.Label34.Name = "Label34";
      this.Label34.Size = new Size(39, 13);
      this.Label34.TabIndex = 3;
      this.Label34.Text = "Costs";
      this.txtSales.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtSales.Location = new System.Drawing.Point(622, 30);
      this.txtSales.Name = "txtSales";
      this.txtSales.Size = new Size(100, 21);
      this.txtSales.TabIndex = 8;
      this.txtCosts.Location = new System.Drawing.Point(9, 30);
      this.txtCosts.Name = "txtCosts";
      this.txtCosts.Size = new Size(100, 21);
      this.txtCosts.TabIndex = 6;
      this.grpPartCostings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpPartCostings.BackColor = Color.White;
      this.grpPartCostings.Controls.Add((Control) this.Label43);
      this.grpPartCostings.Controls.Add((Control) this.txtPartPerc);
      this.grpPartCostings.Controls.Add((Control) this.Label42);
      this.grpPartCostings.Controls.Add((Control) this.txtLabourPerc);
      this.grpPartCostings.Controls.Add((Control) this.dgScheduleOfRateCharges);
      this.grpPartCostings.Controls.Add((Control) this.dgPartsProductCharging);
      this.grpPartCostings.Controls.Add((Control) this.Label40);
      this.grpPartCostings.Controls.Add((Control) this.TextBox2);
      this.grpPartCostings.Controls.Add((Control) this.Label39);
      this.grpPartCostings.Controls.Add((Control) this.txtSORSales);
      this.grpPartCostings.Controls.Add((Control) this.dgTimesheetCharges);
      this.grpPartCostings.Controls.Add((Control) this.Label35);
      this.grpPartCostings.Controls.Add((Control) this.Label36);
      this.grpPartCostings.Controls.Add((Control) this.Label37);
      this.grpPartCostings.Controls.Add((Control) this.Label38);
      this.grpPartCostings.Controls.Add((Control) this.lbl1);
      this.grpPartCostings.Controls.Add((Control) this.txtPartCost);
      this.grpPartCostings.Controls.Add((Control) this.txtLabourCost);
      this.grpPartCostings.Location = new System.Drawing.Point(4, 3);
      this.grpPartCostings.Name = "grpPartCostings";
      this.grpPartCostings.Size = new Size(928, 468);
      this.grpPartCostings.TabIndex = 6;
      this.grpPartCostings.TabStop = false;
      this.grpPartCostings.Text = "Job Profit/Loss";
      this.Label43.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label43.AutoSize = true;
      this.Label43.Location = new System.Drawing.Point(824, 408);
      this.Label43.Name = "Label43";
      this.Label43.Size = new Size(46, 13);
      this.Label43.TabIndex = 24;
      this.Label43.Text = "Part %";
      this.txtPartPerc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPartPerc.Location = new System.Drawing.Point(806, 427);
      this.txtPartPerc.Name = "txtPartPerc";
      this.txtPartPerc.Size = new Size(100, 21);
      this.txtPartPerc.TabIndex = 23;
      this.Label42.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label42.AutoSize = true;
      this.Label42.Location = new System.Drawing.Point(817, (int) byte.MaxValue);
      this.Label42.Name = "Label42";
      this.Label42.Size = new Size(62, 13);
      this.Label42.TabIndex = 22;
      this.Label42.Text = "Labour %";
      this.txtLabourPerc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtLabourPerc.Location = new System.Drawing.Point(806, 276);
      this.txtLabourPerc.Name = "txtLabourPerc";
      this.txtLabourPerc.Size = new Size(100, 21);
      this.txtLabourPerc.TabIndex = 21;
      this.dgScheduleOfRateCharges.DataMember = "";
      this.dgScheduleOfRateCharges.HeaderForeColor = SystemColors.ControlText;
      this.dgScheduleOfRateCharges.Location = new System.Drawing.Point(9, 35);
      this.dgScheduleOfRateCharges.Name = "dgScheduleOfRateCharges";
      this.dgScheduleOfRateCharges.Size = new Size(779, 118);
      this.dgScheduleOfRateCharges.TabIndex = 20;
      this.dgPartsProductCharging.DataMember = "";
      this.dgPartsProductCharging.HeaderForeColor = SystemColors.ControlText;
      this.dgPartsProductCharging.Location = new System.Drawing.Point(9, 348);
      this.dgPartsProductCharging.Name = "dgPartsProductCharging";
      this.dgPartsProductCharging.Size = new Size(779, 100);
      this.dgPartsProductCharging.TabIndex = 19;
      this.Label40.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label40.AutoSize = true;
      this.Label40.Location = new System.Drawing.Point(817, 33);
      this.Label40.Name = "Label40";
      this.Label40.Size = new Size(53, 13);
      this.Label40.TabIndex = 18;
      this.Label40.Text = "SOR Est";
      this.Label40.Visible = false;
      this.TextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.TextBox2.Location = new System.Drawing.Point(806, 54);
      this.TextBox2.Name = "TextBox2";
      this.TextBox2.Size = new Size(100, 21);
      this.TextBox2.TabIndex = 17;
      this.TextBox2.Visible = false;
      this.Label39.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label39.AutoSize = true;
      this.Label39.Location = new System.Drawing.Point(817, 111);
      this.Label39.Name = "Label39";
      this.Label39.Size = new Size(67, 13);
      this.Label39.TabIndex = 16;
      this.Label39.Text = "SOR Sales";
      this.txtSORSales.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtSORSales.Location = new System.Drawing.Point(806, 132);
      this.txtSORSales.Name = "txtSORSales";
      this.txtSORSales.Size = new Size(100, 21);
      this.txtSORSales.TabIndex = 15;
      this.dgTimesheetCharges.DataMember = "";
      this.dgTimesheetCharges.HeaderForeColor = SystemColors.ControlText;
      this.dgTimesheetCharges.Location = new System.Drawing.Point(9, 205);
      this.dgTimesheetCharges.Name = "dgTimesheetCharges";
      this.dgTimesheetCharges.Size = new Size(779, 92);
      this.dgTimesheetCharges.TabIndex = 14;
      this.Label35.AutoSize = true;
      this.Label35.Location = new System.Drawing.Point(6, 19);
      this.Label35.Name = "Label35";
      this.Label35.Size = new Size(87, 13);
      this.Label35.TabIndex = 13;
      this.Label35.Text = "SOR's Applied";
      this.Label36.AutoSize = true;
      this.Label36.Location = new System.Drawing.Point(6, 332);
      this.Label36.Name = "Label36";
      this.Label36.Size = new Size(72, 13);
      this.Label36.TabIndex = 11;
      this.Label36.Text = "Parts Costs";
      this.Label37.AutoSize = true;
      this.Label37.Location = new System.Drawing.Point(6, 189);
      this.Label37.Name = "Label37";
      this.Label37.Size = new Size(82, 13);
      this.Label37.TabIndex = 9;
      this.Label37.Text = "Labour Costs";
      this.Label38.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label38.AutoSize = true;
      this.Label38.Location = new System.Drawing.Point(824, 353);
      this.Label38.Name = "Label38";
      this.Label38.Size = new Size(66, 13);
      this.Label38.TabIndex = 2;
      this.Label38.Text = "Part Costs";
      this.lbl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbl1.AutoSize = true;
      this.lbl1.Location = new System.Drawing.Point(817, 205);
      this.lbl1.Name = "lbl1";
      this.lbl1.Size = new Size(82, 13);
      this.lbl1.TabIndex = 1;
      this.lbl1.Text = "Labour Costs";
      this.txtPartCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPartCost.Location = new System.Drawing.Point(806, 372);
      this.txtPartCost.Name = "txtPartCost";
      this.txtPartCost.Size = new Size(100, 21);
      this.txtPartCost.TabIndex = 1;
      this.txtLabourCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtLabourCost.Location = new System.Drawing.Point(806, 226);
      this.txtLabourCost.Name = "txtLabourCost";
      this.txtLabourCost.Size = new Size(100, 21);
      this.txtLabourCost.TabIndex = 0;
      this.tpInstall.Controls.Add((Control) this.GroupBox1);
      this.tpInstall.Location = new System.Drawing.Point(4, 22);
      this.tpInstall.Name = "tpInstall";
      this.tpInstall.Size = new Size(934, 601);
      this.tpInstall.TabIndex = 6;
      this.tpInstall.Text = "Installation Data";
      this.tpInstall.UseVisualStyleBackColor = true;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.txtManual);
      this.GroupBox1.Controls.Add((Control) this.Label31);
      this.GroupBox1.Controls.Add((Control) this.txtEstSub);
      this.GroupBox1.Controls.Add((Control) this.txtActSub);
      this.GroupBox1.Controls.Add((Control) this.Label29);
      this.GroupBox1.Controls.Add((Control) this.Label30);
      this.GroupBox1.Controls.Add((Control) this.Label28);
      this.GroupBox1.Controls.Add((Control) this.Label27);
      this.GroupBox1.Controls.Add((Control) this.txtSupplierInv);
      this.GroupBox1.Controls.Add((Control) this.Label26);
      this.GroupBox1.Controls.Add((Control) this.Label25);
      this.GroupBox1.Controls.Add((Control) this.Label24);
      this.GroupBox1.Controls.Add((Control) this.Label23);
      this.GroupBox1.Controls.Add((Control) this.txtEstElec);
      this.GroupBox1.Controls.Add((Control) this.txtActElec);
      this.GroupBox1.Controls.Add((Control) this.Label21);
      this.GroupBox1.Controls.Add((Control) this.Label22);
      this.GroupBox1.Controls.Add((Control) this.txtQuotedGross);
      this.GroupBox1.Controls.Add((Control) this.txtDepositGross);
      this.GroupBox1.Controls.Add((Control) this.txtQuoted);
      this.GroupBox1.Controls.Add((Control) this.lblQuoted);
      this.GroupBox1.Controls.Add((Control) this.txtProfitActPerc);
      this.GroupBox1.Controls.Add((Control) this.Label18);
      this.GroupBox1.Controls.Add((Control) this.txtProfitEstPerc);
      this.GroupBox1.Controls.Add((Control) this.Label16);
      this.GroupBox1.Controls.Add((Control) this.txtProfitActMoney);
      this.GroupBox1.Controls.Add((Control) this.Label15);
      this.GroupBox1.Controls.Add((Control) this.txtProfitEstMoney);
      this.GroupBox1.Controls.Add((Control) this.Label14);
      this.GroupBox1.Controls.Add((Control) this.txtTotalEst);
      this.GroupBox1.Controls.Add((Control) this.txtTotalAct);
      this.GroupBox1.Controls.Add((Control) this.Label12);
      this.GroupBox1.Controls.Add((Control) this.Label13);
      this.GroupBox1.Controls.Add((Control) this.txtEstLabour);
      this.GroupBox1.Controls.Add((Control) this.txtActLabour);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.Label17);
      this.GroupBox1.Controls.Add((Control) this.txtPartEst);
      this.GroupBox1.Controls.Add((Control) this.txtPartAct);
      this.GroupBox1.Controls.Add((Control) this.Label19);
      this.GroupBox1.Controls.Add((Control) this.Label20);
      this.GroupBox1.Controls.Add((Control) this.Label11);
      this.GroupBox1.Controls.Add((Control) this.cboPaperwork);
      this.GroupBox1.Controls.Add((Control) this.Label10);
      this.GroupBox1.Controls.Add((Control) this.cboQC);
      this.GroupBox1.Controls.Add((Control) this.txtPayment);
      this.GroupBox1.Controls.Add((Control) this.Label9);
      this.GroupBox1.Controls.Add((Control) this.Label8);
      this.GroupBox1.Controls.Add((Control) this.cboFurtherWorks);
      this.GroupBox1.Controls.Add((Control) this.Label7);
      this.GroupBox1.Controls.Add((Control) this.cboExtraLabour);
      this.GroupBox1.Controls.Add((Control) this.txtPO);
      this.GroupBox1.Controls.Add((Control) this.Label6);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.cboCalledSuper);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.cboSurveyed);
      this.GroupBox1.Controls.Add((Control) this.txtDeposit);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Location = new System.Drawing.Point(0, 3);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(926, 599);
      this.GroupBox1.TabIndex = 34;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Details";
      this.txtManual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtManual.Location = new System.Drawing.Point(668, 353);
      this.txtManual.Name = "txtManual";
      this.txtManual.Size = new Size(214, 21);
      this.txtManual.TabIndex = 112;
      this.txtManual.TabStop = false;
      this.txtManual.Text = "0";
      this.txtManual.TextAlign = HorizontalAlignment.Center;
      this.Label31.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label31.Location = new System.Drawing.Point(500, 356);
      this.Label31.Name = "Label31";
      this.Label31.Size = new Size(147, 23);
      this.Label31.TabIndex = 111;
      this.Label31.Text = "Manual Adjustment";
      this.txtEstSub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtEstSub.Location = new System.Drawing.Point(668, 276);
      this.txtEstSub.Name = "txtEstSub";
      this.txtEstSub.Size = new Size(214, 21);
      this.txtEstSub.TabIndex = 110;
      this.txtEstSub.TabStop = false;
      this.txtEstSub.Text = "0";
      this.txtEstSub.TextAlign = HorizontalAlignment.Center;
      this.txtActSub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtActSub.Location = new System.Drawing.Point(668, 306);
      this.txtActSub.Name = "txtActSub";
      this.txtActSub.ReadOnly = true;
      this.txtActSub.Size = new Size(214, 21);
      this.txtActSub.TabIndex = 109;
      this.txtActSub.TabStop = false;
      this.txtActSub.Text = "0";
      this.txtActSub.TextAlign = HorizontalAlignment.Center;
      this.Label29.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label29.Location = new System.Drawing.Point(500, 279);
      this.Label29.Name = "Label29";
      this.Label29.Size = new Size(147, 23);
      this.Label29.TabIndex = 108;
      this.Label29.Text = "Est SubContractor Cost";
      this.Label30.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label30.Location = new System.Drawing.Point(500, 309);
      this.Label30.Name = "Label30";
      this.Label30.Size = new Size(147, 23);
      this.Label30.TabIndex = 107;
      this.Label30.Text = "Act SubContractor Cost";
      this.Label28.Location = new System.Drawing.Point(683, 65);
      this.Label28.Name = "Label28";
      this.Label28.Size = new Size(86, 19);
      this.Label28.TabIndex = 106;
      this.Label28.Text = "PO Value";
      this.Label27.Location = new System.Drawing.Point(796, 62);
      this.Label27.Name = "Label27";
      this.Label27.Size = new Size(86, 19);
      this.Label27.TabIndex = 105;
      this.Label27.Text = "Supplier Inv";
      this.txtSupplierInv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtSupplierInv.Location = new System.Drawing.Point(781, 84);
      this.txtSupplierInv.Name = "txtSupplierInv";
      this.txtSupplierInv.ReadOnly = true;
      this.txtSupplierInv.Size = new Size(101, 21);
      this.txtSupplierInv.TabIndex = 104;
      this.txtSupplierInv.TabStop = false;
      this.txtSupplierInv.Text = "0";
      this.txtSupplierInv.TextAlign = HorizontalAlignment.Center;
      this.Label26.Location = new System.Drawing.Point(223, 122);
      this.Label26.Name = "Label26";
      this.Label26.Size = new Size(61, 18);
      this.Label26.TabIndex = 103;
      this.Label26.Text = "Nett";
      this.Label25.Location = new System.Drawing.Point(223, 63);
      this.Label25.Name = "Label25";
      this.Label25.Size = new Size(61, 14);
      this.Label25.TabIndex = 102;
      this.Label25.Text = "Nett";
      this.Label24.Location = new System.Drawing.Point(323, 62);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(61, 19);
      this.Label24.TabIndex = 101;
      this.Label24.Text = "Gross";
      this.Label23.Location = new System.Drawing.Point(323, 122);
      this.Label23.Name = "Label23";
      this.Label23.Size = new Size(61, 18);
      this.Label23.TabIndex = 100;
      this.Label23.Text = "Gross";
      this.txtEstElec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtEstElec.Location = new System.Drawing.Point(668, (int) sbyte.MaxValue);
      this.txtEstElec.Name = "txtEstElec";
      this.txtEstElec.Size = new Size(214, 21);
      this.txtEstElec.TabIndex = 99;
      this.txtEstElec.TabStop = false;
      this.txtEstElec.Text = "0";
      this.txtEstElec.TextAlign = HorizontalAlignment.Center;
      this.txtActElec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtActElec.Location = new System.Drawing.Point(668, 157);
      this.txtActElec.Name = "txtActElec";
      this.txtActElec.ReadOnly = true;
      this.txtActElec.Size = new Size(214, 21);
      this.txtActElec.TabIndex = 98;
      this.txtActElec.TabStop = false;
      this.txtActElec.Text = "0";
      this.txtActElec.TextAlign = HorizontalAlignment.Center;
      this.Label21.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label21.Location = new System.Drawing.Point(500, 133);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(116, 23);
      this.Label21.TabIndex = 97;
      this.Label21.Text = "Est Electrical Cost";
      this.Label22.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label22.Location = new System.Drawing.Point(500, 163);
      this.Label22.Name = "Label22";
      this.Label22.Size = new Size(131, 23);
      this.Label22.TabIndex = 96;
      this.Label22.Text = "Act Electrical Cost";
      this.txtQuotedGross.Location = new System.Drawing.Point(304, 84);
      this.txtQuotedGross.Name = "txtQuotedGross";
      this.txtQuotedGross.Size = new Size(97, 21);
      this.txtQuotedGross.TabIndex = 95;
      this.txtQuotedGross.TabStop = false;
      this.txtQuotedGross.Text = "0";
      this.txtQuotedGross.TextAlign = HorizontalAlignment.Center;
      this.txtDepositGross.Location = new System.Drawing.Point(304, 141);
      this.txtDepositGross.Name = "txtDepositGross";
      this.txtDepositGross.Size = new Size(97, 21);
      this.txtDepositGross.TabIndex = 94;
      this.txtDepositGross.TabStop = false;
      this.txtDepositGross.Text = "0";
      this.txtDepositGross.TextAlign = HorizontalAlignment.Center;
      this.txtQuoted.Location = new System.Drawing.Point(187, 84);
      this.txtQuoted.Name = "txtQuoted";
      this.txtQuoted.Size = new Size(97, 21);
      this.txtQuoted.TabIndex = 93;
      this.txtQuoted.TabStop = false;
      this.txtQuoted.Text = "0";
      this.txtQuoted.TextAlign = HorizontalAlignment.Center;
      this.lblQuoted.Location = new System.Drawing.Point(17, 90);
      this.lblQuoted.Name = "lblQuoted";
      this.lblQuoted.Size = new Size(121, 23);
      this.lblQuoted.TabIndex = 92;
      this.lblQuoted.Text = "Amount Quoted";
      this.txtProfitActPerc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtProfitActPerc.Location = new System.Drawing.Point(670, 551);
      this.txtProfitActPerc.Name = "txtProfitActPerc";
      this.txtProfitActPerc.ReadOnly = true;
      this.txtProfitActPerc.Size = new Size(214, 21);
      this.txtProfitActPerc.TabIndex = 91;
      this.txtProfitActPerc.TabStop = false;
      this.txtProfitActPerc.Text = "0";
      this.txtProfitActPerc.TextAlign = HorizontalAlignment.Center;
      this.Label18.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label18.Location = new System.Drawing.Point(500, 554);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(116, 23);
      this.Label18.TabIndex = 90;
      this.Label18.Text = "Act Profit %";
      this.txtProfitEstPerc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtProfitEstPerc.Location = new System.Drawing.Point(670, 524);
      this.txtProfitEstPerc.Name = "txtProfitEstPerc";
      this.txtProfitEstPerc.ReadOnly = true;
      this.txtProfitEstPerc.Size = new Size(214, 21);
      this.txtProfitEstPerc.TabIndex = 89;
      this.txtProfitEstPerc.TabStop = false;
      this.txtProfitEstPerc.Text = "0";
      this.txtProfitEstPerc.TextAlign = HorizontalAlignment.Center;
      this.Label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label16.Location = new System.Drawing.Point(500, 527);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(116, 23);
      this.Label16.TabIndex = 88;
      this.Label16.Text = "Est Profit %";
      this.txtProfitActMoney.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtProfitActMoney.Location = new System.Drawing.Point(670, 485);
      this.txtProfitActMoney.Name = "txtProfitActMoney";
      this.txtProfitActMoney.ReadOnly = true;
      this.txtProfitActMoney.Size = new Size(214, 21);
      this.txtProfitActMoney.TabIndex = 87;
      this.txtProfitActMoney.TabStop = false;
      this.txtProfitActMoney.Text = "0";
      this.txtProfitActMoney.TextAlign = HorizontalAlignment.Center;
      this.Label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label15.Location = new System.Drawing.Point(500, 488);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(116, 23);
      this.Label15.TabIndex = 86;
      this.Label15.Text = "Act Profit £";
      this.txtProfitEstMoney.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtProfitEstMoney.Location = new System.Drawing.Point(670, 458);
      this.txtProfitEstMoney.Name = "txtProfitEstMoney";
      this.txtProfitEstMoney.ReadOnly = true;
      this.txtProfitEstMoney.Size = new Size(214, 21);
      this.txtProfitEstMoney.TabIndex = 85;
      this.txtProfitEstMoney.TabStop = false;
      this.txtProfitEstMoney.Text = "0";
      this.txtProfitEstMoney.TextAlign = HorizontalAlignment.Center;
      this.Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label14.Location = new System.Drawing.Point(500, 461);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(116, 23);
      this.Label14.TabIndex = 84;
      this.Label14.Text = "Est Profit £";
      this.txtTotalEst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtTotalEst.Location = new System.Drawing.Point(670, 396);
      this.txtTotalEst.Name = "txtTotalEst";
      this.txtTotalEst.ReadOnly = true;
      this.txtTotalEst.Size = new Size(214, 21);
      this.txtTotalEst.TabIndex = 83;
      this.txtTotalEst.TabStop = false;
      this.txtTotalEst.Text = "0";
      this.txtTotalEst.TextAlign = HorizontalAlignment.Center;
      this.txtTotalAct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtTotalAct.Location = new System.Drawing.Point(670, 426);
      this.txtTotalAct.Name = "txtTotalAct";
      this.txtTotalAct.ReadOnly = true;
      this.txtTotalAct.Size = new Size(214, 21);
      this.txtTotalAct.TabIndex = 82;
      this.txtTotalAct.TabStop = false;
      this.txtTotalAct.Text = "0";
      this.txtTotalAct.TextAlign = HorizontalAlignment.Center;
      this.Label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label12.Location = new System.Drawing.Point(502, 397);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(116, 23);
      this.Label12.TabIndex = 81;
      this.Label12.Text = "Est Total Cost";
      this.Label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label13.Location = new System.Drawing.Point(502, 427);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(116, 23);
      this.Label13.TabIndex = 80;
      this.Label13.Text = "Act total Cost";
      this.txtEstLabour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtEstLabour.Location = new System.Drawing.Point(668, 201);
      this.txtEstLabour.Name = "txtEstLabour";
      this.txtEstLabour.Size = new Size(214, 21);
      this.txtEstLabour.TabIndex = 79;
      this.txtEstLabour.TabStop = false;
      this.txtEstLabour.Text = "0";
      this.txtEstLabour.TextAlign = HorizontalAlignment.Center;
      this.txtActLabour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtActLabour.Location = new System.Drawing.Point(668, 231);
      this.txtActLabour.Name = "txtActLabour";
      this.txtActLabour.ReadOnly = true;
      this.txtActLabour.Size = new Size(214, 21);
      this.txtActLabour.TabIndex = 78;
      this.txtActLabour.TabStop = false;
      this.txtActLabour.Text = "0";
      this.txtActLabour.TextAlign = HorizontalAlignment.Center;
      this.Label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label5.Location = new System.Drawing.Point(500, 204);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(116, 23);
      this.Label5.TabIndex = 77;
      this.Label5.Text = "Est Labour Cost";
      this.Label17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label17.Location = new System.Drawing.Point(500, 234);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(116, 23);
      this.Label17.TabIndex = 76;
      this.Label17.Text = "Act Labour Cost";
      this.txtPartEst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPartEst.Location = new System.Drawing.Point(670, 37);
      this.txtPartEst.Name = "txtPartEst";
      this.txtPartEst.Size = new Size(214, 21);
      this.txtPartEst.TabIndex = 75;
      this.txtPartEst.TabStop = false;
      this.txtPartEst.Text = "0";
      this.txtPartEst.TextAlign = HorizontalAlignment.Center;
      this.txtPartAct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtPartAct.Location = new System.Drawing.Point(670, 84);
      this.txtPartAct.Name = "txtPartAct";
      this.txtPartAct.ReadOnly = true;
      this.txtPartAct.Size = new Size(99, 21);
      this.txtPartAct.TabIndex = 64;
      this.txtPartAct.TabStop = false;
      this.txtPartAct.Text = "0";
      this.txtPartAct.TextAlign = HorizontalAlignment.Center;
      this.Label19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label19.Location = new System.Drawing.Point(500, 40);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(88, 23);
      this.Label19.TabIndex = 60;
      this.Label19.Text = "Est Part Cost";
      this.Label20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label20.Location = new System.Drawing.Point(498, 87);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(88, 23);
      this.Label20.TabIndex = 57;
      this.Label20.Text = "Act Part Cost";
      this.Label11.Location = new System.Drawing.Point(17, 342);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(134, 23);
      this.Label11.TabIndex = 56;
      this.Label11.Text = "Paperwork Returned";
      this.cboPaperwork.FormattingEnabled = true;
      this.cboPaperwork.Location = new System.Drawing.Point(187, 336);
      this.cboPaperwork.Name = "cboPaperwork";
      this.cboPaperwork.Size = new Size(214, 21);
      this.cboPaperwork.TabIndex = 55;
      this.Label10.Location = new System.Drawing.Point(17, 307);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(134, 23);
      this.Label10.TabIndex = 54;
      this.Label10.Text = "QC Carried Out";
      this.cboQC.FormattingEnabled = true;
      this.cboQC.Location = new System.Drawing.Point(187, 304);
      this.cboQC.Name = "cboQC";
      this.cboQC.Size = new Size(214, 21);
      this.cboQC.TabIndex = 53;
      this.txtPayment.ImeMode = ImeMode.NoControl;
      this.txtPayment.Location = new System.Drawing.Point(187, 276);
      this.txtPayment.Name = "txtPayment";
      this.txtPayment.ReadOnly = true;
      this.txtPayment.Size = new Size(214, 21);
      this.txtPayment.TabIndex = 51;
      this.txtPayment.TabStop = false;
      this.txtPayment.Text = "0";
      this.txtPayment.TextAlign = HorizontalAlignment.Center;
      this.Label9.Location = new System.Drawing.Point(17, 282);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(134, 23);
      this.Label9.TabIndex = 50;
      this.Label9.Text = "Payment Taken";
      this.Label8.Location = new System.Drawing.Point(17, (int) byte.MaxValue);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(134, 23);
      this.Label8.TabIndex = 48;
      this.Label8.Text = "Further Works Noted";
      this.cboFurtherWorks.FormattingEnabled = true;
      this.cboFurtherWorks.Location = new System.Drawing.Point(187, 249);
      this.cboFurtherWorks.Name = "cboFurtherWorks";
      this.cboFurtherWorks.Size = new Size(214, 21);
      this.cboFurtherWorks.TabIndex = 47;
      this.Label7.Location = new System.Drawing.Point(17, 228);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(134, 23);
      this.Label7.TabIndex = 46;
      this.Label7.Text = "Extra Labour Noted";
      this.cboExtraLabour.FormattingEnabled = true;
      this.cboExtraLabour.Location = new System.Drawing.Point(187, 222);
      this.cboExtraLabour.Name = "cboExtraLabour";
      this.cboExtraLabour.Size = new Size(214, 21);
      this.cboExtraLabour.TabIndex = 45;
      this.txtPO.Location = new System.Drawing.Point(187, 168);
      this.txtPO.Name = "txtPO";
      this.txtPO.ReadOnly = true;
      this.txtPO.Size = new Size(214, 21);
      this.txtPO.TabIndex = 44;
      this.txtPO.TabStop = false;
      this.txtPO.Text = "0";
      this.txtPO.TextAlign = HorizontalAlignment.Center;
      this.Label6.Location = new System.Drawing.Point(17, 174);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 23);
      this.Label6.TabIndex = 43;
      this.Label6.Text = "PO Status";
      this.Label4.Location = new System.Drawing.Point(17, 201);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(134, 23);
      this.Label4.TabIndex = 40;
      this.Label4.Text = "Eng Called Supervisor";
      this.cboCalledSuper.FormattingEnabled = true;
      this.cboCalledSuper.Location = new System.Drawing.Point(187, 195);
      this.cboCalledSuper.Name = "cboCalledSuper";
      this.cboCalledSuper.Size = new Size(214, 21);
      this.cboCalledSuper.TabIndex = 39;
      this.Label3.Location = new System.Drawing.Point(20, 35);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(88, 23);
      this.Label3.TabIndex = 38;
      this.Label3.Text = "Surveyed by";
      this.cboSurveyed.FormattingEnabled = true;
      this.cboSurveyed.Location = new System.Drawing.Point(187, 32);
      this.cboSurveyed.Name = "cboSurveyed";
      this.cboSurveyed.Size = new Size(214, 21);
      this.cboSurveyed.TabIndex = 37;
      this.txtDeposit.Location = new System.Drawing.Point(187, 141);
      this.txtDeposit.Name = "txtDeposit";
      this.txtDeposit.Size = new Size(97, 21);
      this.txtDeposit.TabIndex = 36;
      this.txtDeposit.TabStop = false;
      this.txtDeposit.Text = "0";
      this.txtDeposit.TextAlign = HorizontalAlignment.Center;
      this.Label2.Location = new System.Drawing.Point(17, 147);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(88, 23);
      this.Label2.TabIndex = 34;
      this.Label2.Text = "Deposit Taken";
      this.btnPrintJobCosting.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrintJobCosting.Location = new System.Drawing.Point(822, 664);
      this.btnPrintJobCosting.Name = "btnPrintJobCosting";
      this.btnPrintJobCosting.Size = new Size(114, 23);
      this.btnPrintJobCosting.TabIndex = 25;
      this.btnPrintJobCosting.Text = "Print Job Costing";
      this.btnPrintJobCosting.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(942, 690);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnPrintJobCosting);
      this.Controls.Add((Control) this.TabControl1);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(950, 724);
      this.Name = nameof (FRMJobCostings);
      this.Text = "Job";
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.TabControl1, 0);
      this.Controls.SetChildIndex((Control) this.btnPrintJobCosting, 0);
      this.TabControl1.ResumeLayout(false);
      this.tpJobCostings.ResumeLayout(false);
      this.grpTotalCostings.ResumeLayout(false);
      this.grpTotalCostings.PerformLayout();
      this.grpPartCostings.ResumeLayout(false);
      this.grpPartCostings.PerformLayout();
      this.dgScheduleOfRateCharges.EndInit();
      this.dgPartsProductCharging.EndInit();
      this.dgTimesheetCharges.EndInit();
      this.tpInstall.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    private void LoadMe(object sender, EventArgs e)
    {
      if (this.CurrentJob.JobTypeID != 521)
        this.TabControl1.TabPages.Remove(this.tpInstall);
      ComboBox cboSurveyed = this.cboSurveyed;
      Combo.SetUpCombo(ref cboSurveyed, DynamicDataTables.Surveyor, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboSurveyed = cboSurveyed;
      ComboBox c = this.cboCalledSuper;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCalledSuper = c;
      c = this.cboExtraLabour;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboExtraLabour = c;
      c = this.cboFurtherWorks;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFurtherWorks = c;
      c = this.cboQC;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboQC = c;
      c = this.cboPaperwork;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPaperwork = c;
      this.SetupJobInstall();
      this.CalculatePL();
    }

    private DataView TimeSheetCharges
    {
      get
      {
        return this._TimeSheetCharges;
      }
      set
      {
        this._TimeSheetCharges = value;
        this._TimeSheetCharges.AllowNew = false;
        this._TimeSheetCharges.AllowEdit = true;
        this._TimeSheetCharges.AllowDelete = false;
        this._TimeSheetCharges.Table.TableName = Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
        this.dgTimesheetCharges.DataSource = (object) this.TimeSheetCharges;
      }
    }

    private DataView ScheduleOfRateCharges
    {
      get
      {
        return this._ScheduleOfRateCharges;
      }
      set
      {
        this._ScheduleOfRateCharges = value;
        this._ScheduleOfRateCharges.AllowNew = false;
        this._ScheduleOfRateCharges.AllowEdit = true;
        this._ScheduleOfRateCharges.AllowDelete = false;
        this._ScheduleOfRateCharges.Table.TableName = Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString();
        this.dgScheduleOfRateCharges.DataSource = (object) this.ScheduleOfRateCharges;
      }
    }

    private DataView PartProductsCharges
    {
      get
      {
        return this._PartProductsCharges;
      }
      set
      {
        this._PartProductsCharges = value;
        this._PartProductsCharges.AllowNew = false;
        this._PartProductsCharges.AllowEdit = false;
        this._PartProductsCharges.AllowDelete = false;
        this._PartProductsCharges.Table.TableName = Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
        this.dgPartsProductCharging.DataSource = (object) this.PartProductsCharges;
      }
    }

    public Job CurrentJob
    {
      get
      {
        return this._CurrentJob;
      }
      set
      {
        this._CurrentJob = value;
        if (this._CurrentJob != null)
          return;
        this._CurrentJob = new Job();
        this._CurrentJob.Exists = false;
      }
    }

    private JobInstall JI
    {
      get
      {
        return this._JI;
      }
      set
      {
        this._JI = value;
      }
    }

    public void SetupTimeSheetChargeDataGrid()
    {
      Helper.SetUpDataGrid(this.dgTimesheetCharges, false);
      DataGridTableStyle tableStyle = this.dgTimesheetCharges.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgTimesheetCharges.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yy HH:mm";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Start ";
      dataGridLabelColumn1.MappingName = "StartDateTime";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 95;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yy HH:mm";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "End";
      dataGridLabelColumn2.MappingName = "EndDateTime";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 95;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "C";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Eng. Cost";
      dataGridLabelColumn3.MappingName = "EngineerCost";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 80;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Price";
      dataGridLabelColumn4.MappingName = "Price";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 60;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Summary";
      dataGridLabelColumn5.MappingName = "Summary";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 500;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
      this.dgTimesheetCharges.TableStyles.Add(tableStyle);
    }

    public void SetupSoRChargeDataGrid()
    {
      Helper.SetUpDataGrid(this.dgScheduleOfRateCharges, false);
      DataGridTableStyle tableStyle = this.dgScheduleOfRateCharges.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgScheduleOfRateCharges.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Code";
      dataGridLabelColumn1.MappingName = "Code";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 65;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Category";
      dataGridLabelColumn2.MappingName = "category";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Description";
      dataGridLabelColumn3.MappingName = "Summary";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 85;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "# Used";
      dataGridLabelColumn4.MappingName = "NumUnitsUsed";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 52;
      dataGridLabelColumn4.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Price";
      dataGridLabelColumn5.MappingName = "Price";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 60;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Charge";
      dataGridLabelColumn6.MappingName = "Total";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 65;
      dataGridLabelColumn6.NullText = "£0.00";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString();
      this.dgScheduleOfRateCharges.TableStyles.Add(tableStyle);
    }

    public void SetupPartProductDataGrid()
    {
      Helper.SetUpDataGrid(this.dgPartsProductCharging, false);
      DataGridTableStyle tableStyle = this.dgPartsProductCharging.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgScheduleOfRateCharges.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 40;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Part/Product";
      dataGridLabelColumn2.MappingName = "Part/Product";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Appliance (part applied to)";
      dataGridLabelColumn3.MappingName = "Asset";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 60;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Warranty? (Appliance on)";
      dataGridLabelColumn4.MappingName = "Warranty";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 55;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Qty";
      dataGridLabelColumn5.MappingName = "Quantity";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 40;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Price";
      dataGridLabelColumn6.MappingName = "Price";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 45;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Charge";
      dataGridLabelColumn7.MappingName = "Total";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 65;
      dataGridLabelColumn7.NullText = "£0.00";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "C";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Cost";
      dataGridLabelColumn8.MappingName = "Cost";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 45;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
      this.dgPartsProductCharging.TableStyles.Add(tableStyle);
    }

    private void btnPrintJobCosting_Click(object sender, EventArgs e)
    {
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.CurrentJob.JobID
      }, "Costing" + this.CurrentJob.JobNumber + " ", Enums.SystemDocumentType.JobCosting, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void FRMLogCallout_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.SetupTimeSheetChargeDataGrid();
      this.SetupSoRChargeDataGrid();
      this.SetupPartProductDataGrid();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (this.CurrentJob.JobTypeID != 521)
        return;
      this.SaveJI();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void SaveJI()
    {
      try
      {
        this.JI.SetSurveyed = (object) Combo.get_GetSelectedItemValue(this.cboSurveyed);
        this.JI.SetDeposit = (object) this.cfn(this.txtDeposit.Text);
        this.JI.SetQuotedAmount = (object) this.cfn(this.txtQuoted.Text);
        this.JI.SetEngCalledSuper = (object) Combo.get_GetSelectedItemValue(this.cboCalledSuper);
        this.JI.SetExtraLabour = (object) Combo.get_GetSelectedItemValue(this.cboExtraLabour);
        this.JI.SetFurtherWorks = (object) Combo.get_GetSelectedItemValue(this.cboFurtherWorks);
        this.JI.SetPaymentTaken = (object) this.cfn(this.txtPayment.Text);
        this.JI.SetEstElecCost = (object) this.cfn(this.txtEstElec.Text);
        this.JI.SetQC = (object) Combo.get_GetSelectedItemValue(this.cboQC);
        this.JI.SetPaperWork = (object) Combo.get_GetSelectedItemValue(this.cboPaperwork);
        this.JI.SetEstPartCost = (object) this.cfn(this.txtPartEst.Text);
        this.JI.SetEstLabourCost = (object) this.cfn(this.txtEstLabour.Text);
        this.JI.SetEstTotalCost = (object) this.cfn(this.txtTotalEst.Text);
        this.JI.SetJobID = (object) this.CurrentJob.JobID;
        this.JI.SetEstProfitMoney = (object) this.cfn(this.txtProfitEstMoney.Text);
        this.JI.SetManual = (object) this.cfn(this.txtManual.Text);
        this.JI.SetSubConEst = (object) this.cfn(this.txtEstSub.Text);
        if (this.JI.Exists)
          App.DB.JobInstallSQL.Update(this.JI);
        else
          App.DB.JobInstallSQL.Insert(this.JI);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        ProjectData.ClearProjectError();
      }
    }

    private void SetupJobInstall()
    {
      if (this.CurrentJob.JobTypeID == 521)
      {
        this.vatRateID = App.DB.VATRatesSQL.VATRates_Get_ByDate(this.CurrentJob.DateCreated);
        this.vatRate = App.DB.VATRatesSQL.VATRates_Get(this.vatRateID);
        this.JI = new JobInstall();
        this.JI = App.DB.JobInstallSQL.JobINstall_GetFor_JobID(this.CurrentJob.JobID);
        if (this.JI == null)
          this.JI = new JobInstall();
        ComboBox cboSurveyed = this.cboSurveyed;
        Combo.SetSelectedComboItem_By_Value(ref cboSurveyed, Conversions.ToString(this.JI.Surveyed));
        this.cboSurveyed = cboSurveyed;
        this.txtDeposit.Text = "£" + Conversions.ToString(this.JI.Deposit);
        this.txtDepositGross.Text = Strings.Format((object) (Convert.ToDouble(Conversions.ToDecimal(this.txtDeposit.Text)) * (1.0 + this.vatRate.VATRate / 100.0)), "C");
        this.txtPO.Text = Conversions.ToString(this.JI.POStatus);
        ComboBox cboCalledSuper = this.cboCalledSuper;
        Combo.SetSelectedComboItem_By_Value(ref cboCalledSuper, Conversions.ToString(this.JI.EngCalledSuper));
        this.cboCalledSuper = cboCalledSuper;
        ComboBox cboExtraLabour = this.cboExtraLabour;
        Combo.SetSelectedComboItem_By_Value(ref cboExtraLabour, Conversions.ToString(this.JI.ExtraLabour));
        this.cboExtraLabour = cboExtraLabour;
        ComboBox cboFurtherWorks = this.cboFurtherWorks;
        Combo.SetSelectedComboItem_By_Value(ref cboFurtherWorks, Conversions.ToString(this.JI.FurtherWorks));
        this.cboFurtherWorks = cboFurtherWorks;
        this.txtPayment.Text = "£" + Conversions.ToString(this.JI.PaymentTaken);
        ComboBox cboQc = this.cboQC;
        Combo.SetSelectedComboItem_By_Value(ref cboQc, Conversions.ToString(this.JI.QC));
        this.cboQC = cboQc;
        ComboBox cboPaperwork = this.cboPaperwork;
        Combo.SetSelectedComboItem_By_Value(ref cboPaperwork, Conversions.ToString(this.JI.PaperWork));
        this.cboPaperwork = cboPaperwork;
        this.txtPartEst.Text = "£" + Conversions.ToString(this.JI.EstPartCost);
        this.txtPartAct.Text = "£" + Conversions.ToString(this.JI.actPartCost);
        this.txtEstLabour.Text = "£" + Conversions.ToString(this.JI.EstLabourCost);
        this.txtActLabour.Text = "£" + Conversions.ToString(this.JI.actLabourCost);
        this.txtEstElec.Text = "£" + Conversions.ToString(this.JI.EstElecCost);
        this.txtActElec.Text = "£" + Conversions.ToString(this.JI.actElecCost);
        this.txtTotalEst.Text = "£" + Conversions.ToString(this.JI.EstTotalCost);
        this.txtTotalAct.Text = "£" + Conversions.ToString(this.JI.actTotalCost);
        this.txtProfitEstMoney.Text = "£" + Conversions.ToString(this.JI.QuotedAmount - this.JI.EstTotalCost);
        this.txtProfitActMoney.Text = "£" + Conversions.ToString(this.JI.ActProfitMoney);
        this.txtProfitEstPerc.Text = Conversions.ToString(this.JI.EstProfitPerc) + "%";
        this.txtProfitActPerc.Text = Conversions.ToString(this.JI.ActProfitPerc) + "%";
        this.txtEstElec.Text = "£" + Conversions.ToString(this.JI.EstElecCost);
        this.txtActElec.Text = "£" + Conversions.ToString(this.JI.actElecCost);
        this.txtEstSub.Text = "£" + Conversions.ToString(this.JI.SubConEst);
        this.txtActSub.Text = this.JI.SubConSI == 0.0 ? "£" + Conversions.ToString(this.JI.SubConPO) : "£" + Conversions.ToString(this.JI.SubConSI);
        this.txtManual.Text = "£" + Conversions.ToString(this.JI.Manual);
        this.txtQuoted.Text = "£" + Conversions.ToString(this.JI.QuotedAmount);
        this.txtQuotedGross.Text = Strings.Format((object) (Convert.ToDouble(Conversions.ToDecimal(this.txtQuoted.Text)) * (1.0 + this.vatRate.VATRate / 100.0)), "C");
        this.txtSupplierInv.Text = "£" + Conversions.ToString(this.JI.SupplierInvoice);
      }
      this.CalcTotals();
    }

    private void txtEstLabour_TextChanged(object sender, EventArgs e)
    {
      this.CalcTotals();
    }

    private void txtEstElectrical_TextChanged(object sender, EventArgs e)
    {
      this.CalcTotals();
    }

    private void txtPartEst_TextChanged(object sender, EventArgs e)
    {
      this.CalcTotals();
    }

    private void txtEstSub_TextChanged(object sender, EventArgs e)
    {
      this.CalcTotals();
    }

    private void CalcTotals()
    {
      this.txtTotalEst.Text = "£" + Conversions.ToString(this.cfn(this.txtPartEst.Text) + (this.cfn(this.txtEstLabour.Text) + this.cfn(this.txtEstElec.Text) + this.cfn(this.txtEstSub.Text)));
      this.txtProfitEstMoney.Text = "£" + Conversions.ToString(this.cfn(this.txtQuoted.Text) - this.cfn(this.txtTotalEst.Text));
      this.txtProfitEstPerc.Text = Conversions.ToString(Math.Round(Conversions.ToDouble(this.txtProfitEstMoney.Text) / this.cfn(this.txtQuoted.Text), 4) * 100.0) + "%";
    }

    private void txtPayment_TextChanged(object sender, EventArgs e)
    {
      this.txtProfitActMoney.Text = "£" + Conversions.ToString(this.cfn(this.txtPayment.Text) - this.cfn(this.txtTotalAct.Text));
      this.txtProfitActPerc.Text = Conversions.ToString(Math.Round(this.cfn(this.txtProfitActMoney.Text) / this.cfn(this.txtPayment.Text), 4) * 100.0) + "%";
    }

    private void txtManual_TextChanged(object sender, EventArgs e)
    {
      try
      {
        this.txtTotalAct.Text = !this.JI.SIExists ? Conversions.ToString(this.cfn(this.txtPartAct.Text) + this.cfn(this.txtActLabour.Text) + this.cfn(this.txtActElec.Text) + this.cfn(this.txtActSub.Text) + this.cfn(this.txtManual.Text)) : Conversions.ToString(this.cfn(this.txtSupplierInv.Text) + this.cfn(this.txtActLabour.Text) + this.cfn(this.txtActElec.Text) + this.cfn(this.txtActSub.Text) + this.cfn(this.txtManual.Text));
        this.txtProfitActMoney.Text = "£" + Conversions.ToString(this.cfn(this.txtPayment.Text) - this.cfn(this.txtTotalAct.Text));
        this.txtProfitActPerc.Text = Conversions.ToString(Math.Round(this.cfn(this.txtProfitActMoney.Text) / this.cfn(this.txtPayment.Text), 4) * 100.0) + "%";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
      this.txtQuotedGross.Text = Strings.Format((object) (Convert.ToDouble(new Decimal(this.cfn(this.txtQuoted.Text))) * (1.0 + this.vatRate.VATRate / 100.0)), "C");
      this.txtProfitEstMoney.Text = "£" + Conversions.ToString(this.cfn(this.txtQuoted.Text) - this.cfn(this.txtTotalEst.Text));
      this.txtProfitEstPerc.Text = Conversions.ToString(Math.Round(this.cfn(this.txtProfitEstMoney.Text) / this.cfn(this.txtQuoted.Text), 4) * 100.0) + "%";
    }

    private void txtQuotedGross_TextChanged(object sender, EventArgs e)
    {
      this.txtQuoted.Text = Strings.Format((object) (Convert.ToDouble(new Decimal(this.cfn(this.txtQuotedGross.Text))) / (1.0 + this.vatRate.VATRate / 100.0)), "C");
      this.txtProfitEstMoney.Text = "£" + Conversions.ToString(this.cfn(this.txtQuoted.Text) - this.cfn(this.txtTotalEst.Text));
      this.txtProfitEstPerc.Text = Conversions.ToString(Math.Round(this.cfn(this.txtProfitEstMoney.Text) / this.cfn(this.txtQuoted.Text), 4) * 100.0) + "%";
    }

    private void txtDeposit_TextChanged(object sender, EventArgs e)
    {
      this.txtDepositGross.Text = Strings.Format((object) (Convert.ToDouble(new Decimal(this.cfn(this.txtDeposit.Text))) * (1.0 + this.vatRate.VATRate / 100.0)), "C");
      this.txtProfitEstMoney.Text = "£" + Conversions.ToString(this.cfn(this.txtQuoted.Text) - this.cfn(this.txtTotalEst.Text));
      this.txtProfitEstPerc.Text = Conversions.ToString(Math.Round(this.cfn(this.txtProfitEstMoney.Text) / this.cfn(this.txtQuoted.Text), 4) * 100.0) + "%";
    }

    private void txtDepositGross_TextChanged(object sender, EventArgs e)
    {
      this.txtDeposit.Text = Strings.Format((object) (Convert.ToDouble(new Decimal(this.cfn(this.txtDepositGross.Text))) / (1.0 + this.vatRate.VATRate / 100.0)), "C");
      this.txtProfitEstMoney.Text = "£" + Conversions.ToString(this.cfn(this.txtQuoted.Text) - this.cfn(this.txtTotalEst.Text));
      this.txtProfitEstPerc.Text = Conversions.ToString(Math.Round(this.cfn(this.txtProfitEstMoney.Text) / this.cfn(this.txtQuoted.Text), 4) * 100.0) + "%";
    }

    public double cfn(string text)
    {
      string Left = Regex.Replace(text, "[^0-9.]", "");
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "", false) == 0)
        Left = Conversions.ToString(0);
      if (text.Contains("-"))
        Left = "-" + Left;
      return Conversions.ToDouble(Left);
    }

    public void CalculatePL()
    {
      DataTable table1 = new DataTable();
      DataTable table2 = new DataTable();
      DataTable table3 = new DataTable();
      int num = 0;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.CurrentJob.JobOfWorks.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          JobOfWork current1 = (JobOfWork) enumerator1.Current;
          IEnumerator enumerator2;
          try
          {
            enumerator2 = current1.EngineerVisits.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              EngineerVisit current2 = (EngineerVisit) enumerator2.Current;
              current2.TimeSheets = App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Get(current2.EngineerVisitID);
              if (App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(current2.EngineerVisitID) != null)
                num = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(current2.EngineerVisitID).InvoiceReadyID;
              if (num == 2)
                table3.Merge(App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(current2.EngineerVisitID).Table);
              if (current2.TimeSheets.Count > 0)
                table1.Merge(current2.TimeSheets.Table);
              table2.Merge(App.DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Get_For_EngineerVisitID(current2.EngineerVisitID).Table);
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
      this.txtPartCost.Text = Conversions.ToString(Helper.MakeDoubleValid((object) 0));
      this.txtLabourCost.Text = Conversions.ToString(Helper.MakeDoubleValid((object) 0));
      this.txtCosts.Text = Conversions.ToString(Helper.MakeDoubleValid((object) 0));
      this.txtSORSales.Text = Conversions.ToString(Helper.MakeDoubleValid((object) 0));
      this.txtSorTotal.Text = Conversions.ToString(Helper.MakeDoubleValid((object) 0));
      this.TimeSheetCharges = new DataView(table1);
      this.PartProductsCharges = new DataView(table2);
      this.ScheduleOfRateCharges = new DataView(table3);
      IEnumerator enumerator3;
      try
      {
        enumerator3 = this.PartProductsCharges.Table.Rows.GetEnumerator();
        while (enumerator3.MoveNext())
        {
          DataRow current = (DataRow) enumerator3.Current;
          TextBox txtPartCost;
          string str1 = Conversions.ToString(Conversions.ToDouble((txtPartCost = this.txtPartCost).Text) + Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Cost"])));
          txtPartCost.Text = str1;
          TextBox txtCosts;
          string str2 = Conversions.ToString(Conversions.ToDouble((txtCosts = this.txtCosts).Text) + Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Cost"])));
          txtCosts.Text = str2;
        }
      }
      finally
      {
        if (enumerator3 is IDisposable)
          (enumerator3 as IDisposable).Dispose();
      }
      IEnumerator enumerator4;
      try
      {
        enumerator4 = this.TimeSheetCharges.Table.Rows.GetEnumerator();
        while (enumerator4.MoveNext())
        {
          DataRow current = (DataRow) enumerator4.Current;
          TextBox txtLabourCost;
          string str1 = Conversions.ToString(Conversions.ToDouble((txtLabourCost = this.txtLabourCost).Text) + Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["EngineerCost"])));
          txtLabourCost.Text = str1;
          TextBox txtCosts;
          string str2 = Conversions.ToString(Conversions.ToDouble((txtCosts = this.txtCosts).Text) + Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["EngineerCost"])));
          txtCosts.Text = str2;
        }
      }
      finally
      {
        if (enumerator4 is IDisposable)
          (enumerator4 as IDisposable).Dispose();
      }
      IEnumerator enumerator5;
      try
      {
        enumerator5 = this.ScheduleOfRateCharges.Table.Rows.GetEnumerator();
        while (enumerator5.MoveNext())
        {
          DataRow current = (DataRow) enumerator5.Current;
          TextBox txtSorSales;
          string str1 = Conversions.ToString(Conversions.ToDouble((txtSorSales = this.txtSORSales).Text) + Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Total"])));
          txtSorSales.Text = str1;
          TextBox txtSorTotal;
          string str2 = Conversions.ToString(Conversions.ToDouble((txtSorTotal = this.txtSorTotal).Text) + Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Total"])));
          txtSorTotal.Text = str2;
        }
      }
      finally
      {
        if (enumerator5 is IDisposable)
          (enumerator5 as IDisposable).Dispose();
      }
      this.JI = new JobInstall();
      this.JI = App.DB.JobInstallSQL.JobINstall_GetFor_JobID(this.CurrentJob.JobID);
      if (this.JI != null)
        this.txtSales.Text = Conversions.ToString(Math.Round(this.JI.PaymentTaken - Conversions.ToDouble(this.txtSorTotal.Text), 2));
      this.TxtProfitPounds.Text = "£" + Conversions.ToString(Math.Round(this.JI.PaymentTaken - Conversions.ToDouble(this.txtCosts.Text), 2));
      this.txtProfitPerc.Text = Conversions.ToString(Math.Round(Conversions.ToDouble(this.TxtProfitPounds.Text) / this.JI.PaymentTaken * 100.0, 2));
      this.txtLabourPerc.Text = Conversions.ToString(Math.Round(Conversions.ToDouble(this.txtLabourCost.Text) / this.JI.PaymentTaken * 100.0, 2));
      this.txtPartPerc.Text = Conversions.ToString(Math.Round(Conversions.ToDouble(this.txtPartCost.Text) / this.JI.PaymentTaken * 100.0, 2));
    }
  }
}
