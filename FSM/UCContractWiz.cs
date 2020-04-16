// Decompiled with JetBrains decompiler
// Type: FSM.UCContractWiz
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractOriginalPPMVisits;
using FSM.Entity.ContractOriginalSiteAssets;
using FSM.Entity.ContractOriginalSiteRatess;
using FSM.Entity.ContractOriginalSites;
using FSM.Entity.ContractsOriginal;
using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.EngineerVisits;
using FSM.Entity.InvoiceToBeRaiseds;
using FSM.Entity.JobAssets;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.Sites;
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
using System.Security.Cryptography;
using System.Windows.Forms;

namespace FSM
{
  public class UCContractWiz : UCBase, IUserControl
  {
    private IContainer components;
    private ContractOriginal _currentContract;
    private int _IDToLinkTo;
    private DataView _Sites;
    private DataView _MainDataView;
    private DataView _SecondAppliances;
    private int _SiteID;
    private bool _NumberUsed;
    private double _Price;
    private JobNumber _jobNumber;
    private ContractOriginalSite _currentContractSite;
    private string p;
    private DateTime newdate;
    private Control[] c;
    private Button b;
    private double discount;
    private bool needDD;
    private DateTime EffDate;
    private DateTime OldEndDate;
    private int NewSiteID;
    private string NewPayer;
    private string ddsort;
    private string ddAcc;
    private bool Offset;
    private string ManualApp;
    private string SecondApp;
    private JobNumber Jn;
    private string PreviousRef;
    private double previousFirst;
    private double previousSecond;
    private double previousTotal;
    private bool OverridePrice;

    public UCContractWiz()
    {
      this.Load += new EventHandler(this.UCContract_Load);
      this._IDToLinkTo = 0;
      this._MainDataView = (DataView) null;
      this._SiteID = 0;
      this._NumberUsed = false;
      this._Price = 0.0;
      this._jobNumber = (JobNumber) null;
      this.p = "Gasway100";
      this.discount = 0.0;
      this.needDD = true;
      this.EffDate = DateTime.MinValue;
      this.NewSiteID = 0;
      this.NewPayer = "";
      this.ddsort = "";
      this.ddAcc = "";
      this.Offset = true;
      this.ManualApp = "";
      this.SecondApp = "";
      this.PreviousRef = "";
      this.previousFirst = 0.0;
      this.previousSecond = 0.0;
      this.previousTotal = 0.0;
      this.OverridePrice = false;
      this.InitializeComponent();
      ComboBox cboPaymentType = this.cboPaymentType;
      Combo.SetUpCombo(ref cboPaymentType, DynamicDataTables.ContractPaymentTypes, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboPaymentType = cboPaymentType;
      ComboBox cboPeriod = this.cboPeriod;
      Combo.SetUpCombo(ref cboPeriod, DynamicDataTables.ContractPeriod, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboPeriod = cboPeriod;
      ComboBox cboContractType = this.cboContractType;
      Combo.SetUpCombo(ref cboContractType, App.DB.Picklists.GetAll(Enums.PickListTypes.ContractTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboContractType = cboContractType;
      ComboBox cboReasonId = this.cboReasonID;
      Combo.SetUpCombo(ref cboReasonId, App.DB.Picklists.GetAll(Enums.PickListTypes.CancellationReasons, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboReasonID = cboReasonId;
      ComboBox initialPaymentType = this.cboInitialPaymentType;
      Combo.SetUpCombo(ref initialPaymentType, DynamicDataTables.ContractInitialPaymentTypes, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboInitialPaymentType = initialPaymentType;
      ComboBox cboPromotion = this.cboPromotion;
      Combo.SetUpCombo(ref cboPromotion, App.DB.Picklists.GetAll(Enums.PickListTypes.CoverPlanDiscounts, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPromotion = cboPromotion;
      this.SetUpSoldByCombo();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnAmend
    {
      get
      {
        return this._btnAmend;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAmend_Click);
        Button btnAmend1 = this._btnAmend;
        if (btnAmend1 != null)
          btnAmend1.Click -= eventHandler;
        this._btnAmend = value;
        Button btnAmend2 = this._btnAmend;
        if (btnAmend2 == null)
          return;
        btnAmend2.Click += eventHandler;
      }
    }

    internal virtual Button btnNew
    {
      get
      {
        return this._btnNew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button btnNew1 = this._btnNew;
        if (btnNew1 != null)
          btnNew1.Click -= eventHandler;
        this._btnNew = value;
        Button btnNew2 = this._btnNew;
        if (btnNew2 == null)
          return;
        btnNew2.Click += eventHandler;
      }
    }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button BtnCancel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMonthly { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel grpPromo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPromoOK
    {
      get
      {
        return this._btnPromoOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPromoOK_Click);
        Button btnPromoOk1 = this._btnPromoOK;
        if (btnPromoOk1 != null)
          btnPromoOk1.Click -= eventHandler;
        this._btnPromoOK = value;
        Button btnPromoOk2 = this._btnPromoOK;
        if (btnPromoOk2 == null)
          return;
        btnPromoOk2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboPromotion
    {
      get
      {
        return this._cboPromotion;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboPromotion_SelectedIndexChanged);
        ComboBox cboPromotion1 = this._cboPromotion;
        if (cboPromotion1 != null)
          cboPromotion1.SelectedIndexChanged -= eventHandler;
        this._cboPromotion = value;
        ComboBox cboPromotion2 = this._cboPromotion;
        if (cboPromotion2 == null)
          return;
        cboPromotion2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblPromotionalOffer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel grpContractType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcancel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCancelReason { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnTypeOk
    {
      get
      {
        return this._btnTypeOk;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnTypeOk_Click_1);
        Button btnTypeOk1 = this._btnTypeOk;
        if (btnTypeOk1 != null)
          btnTypeOk1.Click -= eventHandler;
        this._btnTypeOk = value;
        Button btnTypeOk2 = this._btnTypeOk;
        if (btnTypeOk2 == null)
          return;
        btnTypeOk2.Click += eventHandler;
      }
    }

    internal virtual Label lblConType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboReasonID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpCancelledDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboContractType
    {
      get
      {
        return this._cboContractType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboContractType_SelectedIndexChanged);
        ComboBox cboContractType1 = this._cboContractType;
        if (cboContractType1 != null)
          cboContractType1.SelectedIndexChanged -= eventHandler;
        this._cboContractType = value;
        ComboBox cboContractType2 = this._cboContractType;
        if (cboContractType2 == null)
          return;
        cboContractType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Panel grpAppliancesCovered { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnMinusSecond
    {
      get
      {
        return this._btnMinusSecond;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMinusSecond_Click);
        Button btnMinusSecond1 = this._btnMinusSecond;
        if (btnMinusSecond1 != null)
          btnMinusSecond1.Click -= eventHandler;
        this._btnMinusSecond = value;
        Button btnMinusSecond2 = this._btnMinusSecond;
        if (btnMinusSecond2 == null)
          return;
        btnMinusSecond2.Click += eventHandler;
      }
    }

    internal virtual Button btnMinusMain
    {
      get
      {
        return this._btnMinusMain;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMinusMain_Click);
        Button btnMinusMain1 = this._btnMinusMain;
        if (btnMinusMain1 != null)
          btnMinusMain1.Click -= eventHandler;
        this._btnMinusMain = value;
        Button btnMinusMain2 = this._btnMinusMain;
        if (btnMinusMain2 == null)
          return;
        btnMinusMain2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddSecond
    {
      get
      {
        return this._btnAddSecond;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddSecond_Click);
        Button btnAddSecond1 = this._btnAddSecond;
        if (btnAddSecond1 != null)
          btnAddSecond1.Click -= eventHandler;
        this._btnAddSecond = value;
        Button btnAddSecond2 = this._btnAddSecond;
        if (btnAddSecond2 == null)
          return;
        btnAddSecond2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddMain
    {
      get
      {
        return this._btnAddMain;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddMain_Click);
        Button btnAddMain1 = this._btnAddMain;
        if (btnAddMain1 != null)
          btnAddMain1.Click -= eventHandler;
        this._btnAddMain = value;
        Button btnAddMain2 = this._btnAddMain;
        if (btnAddMain2 == null)
          return;
        btnAddMain2.Click += eventHandler;
      }
    }

    internal virtual Label LblSecondApps2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSecondryCount
    {
      get
      {
        return this._txtSecondryCount;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtMainAppCount_TextChanged);
        TextBox txtSecondryCount1 = this._txtSecondryCount;
        if (txtSecondryCount1 != null)
          txtSecondryCount1.TextAlignChanged -= eventHandler;
        this._txtSecondryCount = value;
        TextBox txtSecondryCount2 = this._txtSecondryCount;
        if (txtSecondryCount2 == null)
          return;
        txtSecondryCount2.TextAlignChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboSecondryApps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSecondOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAppsOK
    {
      get
      {
        return this._btnAppsOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAppsOK_Click);
        Button btnAppsOk1 = this._btnAppsOK;
        if (btnAppsOk1 != null)
          btnAppsOk1.Click -= eventHandler;
        this._btnAppsOK = value;
        Button btnAppsOk2 = this._btnAppsOK;
        if (btnAppsOk2 == null)
          return;
        btnAppsOk2.Click += eventHandler;
      }
    }

    internal virtual Label lblAdditionalApps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMainApps2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMainAppCount
    {
      get
      {
        return this._txtMainAppCount;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtMainAppCount_TextChanged);
        TextBox txtMainAppCount1 = this._txtMainAppCount;
        if (txtMainAppCount1 != null)
          txtMainAppCount1.TextChanged -= eventHandler;
        this._txtMainAppCount = value;
        TextBox txtMainAppCount2 = this._txtMainAppCount;
        if (txtMainAppCount2 == null)
          return;
        txtMainAppCount2.TextChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboMainApps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMainOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMainApps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAppsCovered { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel grpContractPeriod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPeriodOK
    {
      get
      {
        return this._btnPeriodOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPeriodOK_Click_1);
        Button btnPeriodOk1 = this._btnPeriodOK;
        if (btnPeriodOk1 != null)
          btnPeriodOk1.Click -= eventHandler;
        this._btnPeriodOK = value;
        Button btnPeriodOk2 = this._btnPeriodOK;
        if (btnPeriodOk2 == null)
          return;
        btnPeriodOk2.Click += eventHandler;
      }
    }

    internal virtual Label lblPeriod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPeriod
    {
      get
      {
        return this._cboPeriod;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboPeriod_SelectedIndexChanged);
        ComboBox cboPeriod1 = this._cboPeriod;
        if (cboPeriod1 != null)
          cboPeriod1.SelectedIndexChanged -= eventHandler;
        this._cboPeriod = value;
        ComboBox cboPeriod2 = this._cboPeriod;
        if (cboPeriod2 == null)
          return;
        cboPeriod2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblConPeriod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpContractStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel grpAdditionalOptions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAdditionalOK
    {
      get
      {
        return this._btnAdditionalOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdditionalOK_Click);
        Button btnAdditionalOk1 = this._btnAdditionalOK;
        if (btnAdditionalOk1 != null)
          btnAdditionalOk1.Click -= eventHandler;
        this._btnAdditionalOK = value;
        Button btnAdditionalOk2 = this._btnAdditionalOK;
        if (btnAdditionalOk2 == null)
          return;
        btnAdditionalOk2.Click += eventHandler;
      }
    }

    internal virtual Label lblAdditionalOptions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkPlumbingDrainage
    {
      get
      {
        return this._chkPlumbingDrainage;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkWindowLockPest_CheckedChanged);
        CheckBox plumbingDrainage1 = this._chkPlumbingDrainage;
        if (plumbingDrainage1 != null)
          plumbingDrainage1.CheckedChanged -= eventHandler;
        this._chkPlumbingDrainage = value;
        CheckBox plumbingDrainage2 = this._chkPlumbingDrainage;
        if (plumbingDrainage2 == null)
          return;
        plumbingDrainage2.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkWindowLockPest
    {
      get
      {
        return this._chkWindowLockPest;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkWindowLockPest_CheckedChanged);
        CheckBox chkWindowLockPest1 = this._chkWindowLockPest;
        if (chkWindowLockPest1 != null)
          chkWindowLockPest1.CheckedChanged -= eventHandler;
        this._chkWindowLockPest = value;
        CheckBox chkWindowLockPest2 = this._chkWindowLockPest;
        if (chkWindowLockPest2 == null)
          return;
        chkWindowLockPest2.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkGasSupplyPipework
    {
      get
      {
        return this._chkGasSupplyPipework;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkWindowLockPest_CheckedChanged);
        CheckBox gasSupplyPipework1 = this._chkGasSupplyPipework;
        if (gasSupplyPipework1 != null)
          gasSupplyPipework1.CheckedChanged -= eventHandler;
        this._chkGasSupplyPipework = value;
        CheckBox gasSupplyPipework2 = this._chkGasSupplyPipework;
        if (gasSupplyPipework2 == null)
          return;
        gasSupplyPipework2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Panel grpPayers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPaymentOK
    {
      get
      {
        return this._btnPaymentOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPaymentOK_Click);
        Button btnPaymentOk1 = this._btnPaymentOK;
        if (btnPaymentOk1 != null)
          btnPaymentOk1.Click -= eventHandler;
        this._btnPaymentOK = value;
        Button btnPaymentOk2 = this._btnPaymentOK;
        if (btnPaymentOk2 == null)
          return;
        btnPaymentOk2.Click += eventHandler;
      }
    }

    internal virtual Label lblPaymentMethod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPaymentType
    {
      get
      {
        return this._cboPaymentType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboPaymentType_SelectedIndexChanged);
        ComboBox cboPaymentType1 = this._cboPaymentType;
        if (cboPaymentType1 != null)
          cboPaymentType1.SelectedIndexChanged -= eventHandler;
        this._cboPaymentType = value;
        ComboBox cboPaymentType2 = this._cboPaymentType;
        if (cboPaymentType2 == null)
          return;
        cboPaymentType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboPAyer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPayer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPayersDetail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel grpAdditionalDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotesToEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblServiceNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPONumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPO { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView DgMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgSecondAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMonthlyEst { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTotalEst { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFollowedBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkLandlord { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkCommercial { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboContract
    {
      get
      {
        return this._cboContract;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboContract_SelectedIndexChanged);
        ComboBox cboContract1 = this._cboContract;
        if (cboContract1 != null)
          cboContract1.SelectedIndexChanged -= eventHandler;
        this._cboContract = value;
        ComboBox cboContract2 = this._cboContract;
        if (cboContract2 == null)
          return;
        cboContract2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboInitialPaymentType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPaidBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel grpDD { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBankName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAccNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBankName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAccNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSortCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSortCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRenew
    {
      get
      {
        return this._btnRenew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRenew_Click);
        Button btnRenew1 = this._btnRenew;
        if (btnRenew1 != null)
          btnRenew1.Click -= eventHandler;
        this._btnRenew = value;
        Button btnRenew2 = this._btnRenew;
        if (btnRenew2 == null)
          return;
        btnRenew2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtAccName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbl3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRenewed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSoldBy
    {
      get
      {
        return this._cboSoldBy;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboSoldBy_SelectedIndexChanged);
        ComboBox cboSoldBy1 = this._cboSoldBy;
        if (cboSoldBy1 != null)
          cboSoldBy1.SelectedIndexChanged -= eventHandler;
        this._cboSoldBy = value;
        ComboBox cboSoldBy2 = this._cboSoldBy;
        if (cboSoldBy2 == null)
          return;
        cboSoldBy2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblsold { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnTransfer
    {
      get
      {
        return this._btnTransfer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnTransfer_Click);
        Button btnTransfer1 = this._btnTransfer;
        if (btnTransfer1 != null)
          btnTransfer1.Click -= eventHandler;
        this._btnTransfer = value;
        Button btnTransfer2 = this._btnTransfer;
        if (btnTransfer2 == null)
          return;
        btnTransfer2.Click += eventHandler;
      }
    }

    internal virtual Label lblchanging { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblIsLandlord { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpContract { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpContract = new GroupBox();
      this.btnTransfer = new Button();
      this.lblsold = new Label();
      this.btnRenew = new Button();
      this.Label2 = new Label();
      this.lblFollowedBy = new Label();
      this.Label1 = new Label();
      this.lblMonthlyEst = new Label();
      this.lblContractRef = new Label();
      this.lblTotalEst = new Label();
      this.grpPromo = new Panel();
      this.btnPromoOK = new Button();
      this.cboPromotion = new ComboBox();
      this.lblPromotionalOffer = new Label();
      this.grpContractType = new Panel();
      this.cboContract = new ComboBox();
      this.lblcancel = new Label();
      this.lblCancelReason = new Label();
      this.btnTypeOk = new Button();
      this.lblConType = new Label();
      this.cboReasonID = new ComboBox();
      this.dtpCancelledDate = new DateTimePicker();
      this.cboContractType = new ComboBox();
      this.lblIsLandlord = new Label();
      this.grpAppliancesCovered = new Panel();
      this.dgSecondAssets = new DataGridView();
      this.DgMain = new DataGridView();
      this.btnMinusSecond = new Button();
      this.btnMinusMain = new Button();
      this.btnAddSecond = new Button();
      this.btnAddMain = new Button();
      this.LblSecondApps2 = new Label();
      this.txtSecondryCount = new TextBox();
      this.cboSecondryApps = new ComboBox();
      this.lblSecondOR = new Label();
      this.btnAppsOK = new Button();
      this.lblAdditionalApps = new Label();
      this.lblMainApps2 = new Label();
      this.txtMainAppCount = new TextBox();
      this.cboMainApps = new ComboBox();
      this.lblMainOR = new Label();
      this.lblMainApps = new Label();
      this.lblAppsCovered = new Label();
      this.lblReference = new Label();
      this.lblMonthly = new Label();
      this.BtnCancel = new Button();
      this.btnAmend = new Button();
      this.btnNew = new Button();
      this.Label7 = new Label();
      this.cboSoldBy = new ComboBox();
      this.lblRenewed = new Label();
      this.grpContractPeriod = new Panel();
      this.btnPeriodOK = new Button();
      this.lblPeriod = new Label();
      this.cboPeriod = new ComboBox();
      this.lblConPeriod = new Label();
      this.dtpContractStartDate = new DateTimePicker();
      this.lblContractStartDate = new Label();
      this.grpAdditionalOptions = new Panel();
      this.btnAdditionalOK = new Button();
      this.lblAdditionalOptions = new Label();
      this.chkPlumbingDrainage = new CheckBox();
      this.chkWindowLockPest = new CheckBox();
      this.chkGasSupplyPipework = new CheckBox();
      this.grpPayers = new Panel();
      this.grpDD = new Panel();
      this.lblchanging = new Label();
      this.txtAccName = new TextBox();
      this.lbl3 = new Label();
      this.txtBankName = new TextBox();
      this.txtAccNumber = new TextBox();
      this.lblBankName = new Label();
      this.lblAccNumber = new Label();
      this.txtSortCode = new TextBox();
      this.lblSortCode = new Label();
      this.Panel2 = new Panel();
      this.Panel1 = new Panel();
      this.lblPaidBy = new Label();
      this.cboInitialPaymentType = new ComboBox();
      this.btnPaymentOK = new Button();
      this.lblPaymentMethod = new Label();
      this.cboPaymentType = new ComboBox();
      this.cboPAyer = new ComboBox();
      this.lblPayer = new Label();
      this.lblPayersDetail = new Label();
      this.grpAdditionalDetails = new Panel();
      this.chkCommercial = new CheckBox();
      this.chkLandlord = new CheckBox();
      this.txtNotesToEngineer = new TextBox();
      this.lblServiceNotes = new Label();
      this.txtPONumber = new TextBox();
      this.lblPO = new Label();
      this.lblAddDetails = new Label();
      this.grpContract.SuspendLayout();
      this.grpPromo.SuspendLayout();
      this.grpContractType.SuspendLayout();
      this.grpAppliancesCovered.SuspendLayout();
      ((ISupportInitialize) this.dgSecondAssets).BeginInit();
      ((ISupportInitialize) this.DgMain).BeginInit();
      this.grpContractPeriod.SuspendLayout();
      this.grpAdditionalOptions.SuspendLayout();
      this.grpPayers.SuspendLayout();
      this.grpDD.SuspendLayout();
      this.Panel1.SuspendLayout();
      this.grpAdditionalDetails.SuspendLayout();
      this.SuspendLayout();
      this.grpContract.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContract.Controls.Add((Control) this.btnTransfer);
      this.grpContract.Controls.Add((Control) this.lblsold);
      this.grpContract.Controls.Add((Control) this.btnRenew);
      this.grpContract.Controls.Add((Control) this.Label2);
      this.grpContract.Controls.Add((Control) this.lblFollowedBy);
      this.grpContract.Controls.Add((Control) this.Label1);
      this.grpContract.Controls.Add((Control) this.lblMonthlyEst);
      this.grpContract.Controls.Add((Control) this.lblContractRef);
      this.grpContract.Controls.Add((Control) this.lblTotalEst);
      this.grpContract.Controls.Add((Control) this.grpPromo);
      this.grpContract.Controls.Add((Control) this.grpContractType);
      this.grpContract.Controls.Add((Control) this.grpAppliancesCovered);
      this.grpContract.Controls.Add((Control) this.lblReference);
      this.grpContract.Controls.Add((Control) this.lblMonthly);
      this.grpContract.Controls.Add((Control) this.BtnCancel);
      this.grpContract.Controls.Add((Control) this.btnAmend);
      this.grpContract.Controls.Add((Control) this.btnNew);
      this.grpContract.Controls.Add((Control) this.Label7);
      this.grpContract.Controls.Add((Control) this.cboSoldBy);
      this.grpContract.Controls.Add((Control) this.lblRenewed);
      this.grpContract.Location = new System.Drawing.Point(8, 8);
      this.grpContract.Name = "grpContract";
      this.grpContract.Size = new Size(1080, 690);
      this.grpContract.TabIndex = 0;
      this.grpContract.TabStop = false;
      this.grpContract.Text = "Contract Wizard";
      this.btnTransfer.Location = new System.Drawing.Point(593, 28);
      this.btnTransfer.Name = "btnTransfer";
      this.btnTransfer.Size = new Size(146, 23);
      this.btnTransfer.TabIndex = 155;
      this.btnTransfer.Text = "TRANSFER CONTRACT";
      this.btnTransfer.UseVisualStyleBackColor = true;
      this.btnTransfer.Visible = false;
      this.lblsold.Location = new System.Drawing.Point(667, 33);
      this.lblsold.Name = "lblsold";
      this.lblsold.Size = new Size(79, 20);
      this.lblsold.TabIndex = 154;
      this.lblsold.Text = "Sold By";
      this.lblsold.Visible = false;
      this.btnRenew.Location = new System.Drawing.Point(748, 28);
      this.btnRenew.Name = "btnRenew";
      this.btnRenew.Size = new Size(146, 23);
      this.btnRenew.TabIndex = 151;
      this.btnRenew.Text = "RENEW CONTRACT";
      this.btnRenew.UseVisualStyleBackColor = true;
      this.btnRenew.Visible = false;
      this.Label2.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label2.Location = new System.Drawing.Point(346, 625);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(191, 25);
      this.Label2.TabIndex = 90;
      this.Label2.Text = "Annual Amount: ";
      this.lblFollowedBy.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblFollowedBy.Location = new System.Drawing.Point(242, 658);
      this.lblFollowedBy.Name = "lblFollowedBy";
      this.lblFollowedBy.Size = new Size(97, 25);
      this.lblFollowedBy.TabIndex = 150;
      this.Label1.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new System.Drawing.Point(5, 658);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(230, 25);
      this.Label1.TabIndex = 149;
      this.Label1.Text = "Followed By:";
      this.lblMonthlyEst.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMonthlyEst.Location = new System.Drawing.Point(238, 625);
      this.lblMonthlyEst.Name = "lblMonthlyEst";
      this.lblMonthlyEst.Size = new Size(108, 25);
      this.lblMonthlyEst.TabIndex = 148;
      this.lblContractRef.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblContractRef.Location = new System.Drawing.Point(898, 625);
      this.lblContractRef.Name = "lblContractRef";
      this.lblContractRef.Size = new Size(137, 25);
      this.lblContractRef.TabIndex = 148;
      this.lblTotalEst.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTotalEst.Location = new System.Drawing.Point(538, 625);
      this.lblTotalEst.Name = "lblTotalEst";
      this.lblTotalEst.Size = new Size(118, 25);
      this.lblTotalEst.TabIndex = 147;
      this.grpPromo.Controls.Add((Control) this.btnPromoOK);
      this.grpPromo.Controls.Add((Control) this.cboPromotion);
      this.grpPromo.Controls.Add((Control) this.lblPromotionalOffer);
      this.grpPromo.Location = new System.Drawing.Point(0, 377);
      this.grpPromo.Name = "grpPromo";
      this.grpPromo.Size = new Size(1040, 36);
      this.grpPromo.TabIndex = 95;
      this.btnPromoOK.Location = new System.Drawing.Point(998, 7);
      this.btnPromoOK.Name = "btnPromoOK";
      this.btnPromoOK.Size = new Size(36, 23);
      this.btnPromoOK.TabIndex = 79;
      this.btnPromoOK.Text = "OK";
      this.btnPromoOK.UseVisualStyleBackColor = true;
      this.cboPromotion.Cursor = Cursors.Hand;
      this.cboPromotion.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPromotion.Location = new System.Drawing.Point(409, 8);
      this.cboPromotion.Name = "cboPromotion";
      this.cboPromotion.Size = new Size(581, 21);
      this.cboPromotion.TabIndex = 78;
      this.cboPromotion.Tag = (object) "Contract.ContractStatusID";
      this.lblPromotionalOffer.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblPromotionalOffer.Location = new System.Drawing.Point(9, 4);
      this.lblPromotionalOffer.Name = "lblPromotionalOffer";
      this.lblPromotionalOffer.Size = new Size(345, 25);
      this.lblPromotionalOffer.TabIndex = 77;
      this.lblPromotionalOffer.Text = "Promotional Offer / Discounts";
      this.grpContractType.Controls.Add((Control) this.cboContract);
      this.grpContractType.Controls.Add((Control) this.lblcancel);
      this.grpContractType.Controls.Add((Control) this.lblCancelReason);
      this.grpContractType.Controls.Add((Control) this.btnTypeOk);
      this.grpContractType.Controls.Add((Control) this.lblConType);
      this.grpContractType.Controls.Add((Control) this.cboReasonID);
      this.grpContractType.Controls.Add((Control) this.dtpCancelledDate);
      this.grpContractType.Controls.Add((Control) this.cboContractType);
      this.grpContractType.Controls.Add((Control) this.lblIsLandlord);
      this.grpContractType.Location = new System.Drawing.Point(1, 57);
      this.grpContractType.Name = "grpContractType";
      this.grpContractType.Size = new Size(1039, 51);
      this.grpContractType.TabIndex = 94;
      this.cboContract.Cursor = Cursors.Hand;
      this.cboContract.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboContract.Location = new System.Drawing.Point(257, 14);
      this.cboContract.Name = "cboContract";
      this.cboContract.Size = new Size(379, 21);
      this.cboContract.TabIndex = 69;
      this.cboContract.Tag = (object) "";
      this.lblcancel.Location = new System.Drawing.Point(254, 17);
      this.lblcancel.Name = "lblcancel";
      this.lblcancel.Size = new Size(79, 20);
      this.lblcancel.TabIndex = 74;
      this.lblcancel.Text = "Cancel Date";
      this.lblCancelReason.Location = new System.Drawing.Point(665, 20);
      this.lblCancelReason.Name = "lblCancelReason";
      this.lblCancelReason.Size = new Size(50, 20);
      this.lblCancelReason.TabIndex = 73;
      this.lblCancelReason.Text = "Reason";
      this.btnTypeOk.Location = new System.Drawing.Point(996, 15);
      this.btnTypeOk.Name = "btnTypeOk";
      this.btnTypeOk.Size = new Size(36, 23);
      this.btnTypeOk.TabIndex = 72;
      this.btnTypeOk.Text = "OK";
      this.btnTypeOk.UseVisualStyleBackColor = true;
      this.lblConType.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblConType.Location = new System.Drawing.Point(6, 12);
      this.lblConType.Name = "lblConType";
      this.lblConType.Size = new Size(207, 25);
      this.lblConType.TabIndex = 71;
      this.lblConType.Text = "Contract Type";
      this.cboReasonID.Cursor = Cursors.Hand;
      this.cboReasonID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboReasonID.Location = new System.Drawing.Point(775, 15);
      this.cboReasonID.Name = "cboReasonID";
      this.cboReasonID.Size = new Size(215, 21);
      this.cboReasonID.TabIndex = 70;
      this.cboReasonID.Tag = (object) "Contract.ContractStatusID";
      this.dtpCancelledDate.Location = new System.Drawing.Point(408, 14);
      this.dtpCancelledDate.Name = "dtpCancelledDate";
      this.dtpCancelledDate.Size = new Size(229, 21);
      this.dtpCancelledDate.TabIndex = 69;
      this.cboContractType.Cursor = Cursors.Hand;
      this.cboContractType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboContractType.Location = new System.Drawing.Point(644, 15);
      this.cboContractType.Name = "cboContractType";
      this.cboContractType.Size = new Size(346, 21);
      this.cboContractType.TabIndex = 68;
      this.cboContractType.Tag = (object) "";
      this.lblIsLandlord.Location = new System.Drawing.Point(254, 8);
      this.lblIsLandlord.Name = "lblIsLandlord";
      this.lblIsLandlord.Size = new Size(384, 36);
      this.lblIsLandlord.TabIndex = 75;
      this.lblIsLandlord.Text = "Reason";
      this.lblIsLandlord.Visible = false;
      this.grpAppliancesCovered.Controls.Add((Control) this.dgSecondAssets);
      this.grpAppliancesCovered.Controls.Add((Control) this.DgMain);
      this.grpAppliancesCovered.Controls.Add((Control) this.btnMinusSecond);
      this.grpAppliancesCovered.Controls.Add((Control) this.btnMinusMain);
      this.grpAppliancesCovered.Controls.Add((Control) this.btnAddSecond);
      this.grpAppliancesCovered.Controls.Add((Control) this.btnAddMain);
      this.grpAppliancesCovered.Controls.Add((Control) this.LblSecondApps2);
      this.grpAppliancesCovered.Controls.Add((Control) this.txtSecondryCount);
      this.grpAppliancesCovered.Controls.Add((Control) this.cboSecondryApps);
      this.grpAppliancesCovered.Controls.Add((Control) this.lblSecondOR);
      this.grpAppliancesCovered.Controls.Add((Control) this.btnAppsOK);
      this.grpAppliancesCovered.Controls.Add((Control) this.lblAdditionalApps);
      this.grpAppliancesCovered.Controls.Add((Control) this.lblMainApps2);
      this.grpAppliancesCovered.Controls.Add((Control) this.txtMainAppCount);
      this.grpAppliancesCovered.Controls.Add((Control) this.cboMainApps);
      this.grpAppliancesCovered.Controls.Add((Control) this.lblMainOR);
      this.grpAppliancesCovered.Controls.Add((Control) this.lblMainApps);
      this.grpAppliancesCovered.Controls.Add((Control) this.lblAppsCovered);
      this.grpAppliancesCovered.Location = new System.Drawing.Point(0, 154);
      this.grpAppliancesCovered.Name = "grpAppliancesCovered";
      this.grpAppliancesCovered.Size = new Size(1040, 183);
      this.grpAppliancesCovered.TabIndex = 93;
      this.dgSecondAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgSecondAssets.Location = new System.Drawing.Point(645, 99);
      this.dgSecondAssets.MultiSelect = false;
      this.dgSecondAssets.Name = "dgSecondAssets";
      this.dgSecondAssets.ReadOnly = true;
      this.dgSecondAssets.RowHeadersVisible = false;
      this.dgSecondAssets.ShowCellErrors = false;
      this.dgSecondAssets.ShowEditingIcon = false;
      this.dgSecondAssets.ShowRowErrors = false;
      this.dgSecondAssets.Size = new Size(293, 70);
      this.dgSecondAssets.TabIndex = 146;
      this.DgMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DgMain.Location = new System.Drawing.Point(645, 13);
      this.DgMain.MultiSelect = false;
      this.DgMain.Name = "DgMain";
      this.DgMain.ReadOnly = true;
      this.DgMain.RowHeadersVisible = false;
      this.DgMain.ShowCellErrors = false;
      this.DgMain.ShowEditingIcon = false;
      this.DgMain.ShowRowErrors = false;
      this.DgMain.Size = new Size(293, 70);
      this.DgMain.TabIndex = 145;
      this.btnMinusSecond.Location = new System.Drawing.Point(599, 146);
      this.btnMinusSecond.Name = "btnMinusSecond";
      this.btnMinusSecond.Size = new Size(39, 23);
      this.btnMinusSecond.TabIndex = 144;
      this.btnMinusSecond.Text = "-";
      this.btnMinusSecond.UseVisualStyleBackColor = true;
      this.btnMinusMain.Location = new System.Drawing.Point(599, 60);
      this.btnMinusMain.Name = "btnMinusMain";
      this.btnMinusMain.Size = new Size(39, 23);
      this.btnMinusMain.TabIndex = 143;
      this.btnMinusMain.Text = "-";
      this.btnMinusMain.UseVisualStyleBackColor = true;
      this.btnAddSecond.Location = new System.Drawing.Point(599, 122);
      this.btnAddSecond.Name = "btnAddSecond";
      this.btnAddSecond.Size = new Size(39, 23);
      this.btnAddSecond.TabIndex = 142;
      this.btnAddSecond.Text = "+";
      this.btnAddSecond.UseVisualStyleBackColor = true;
      this.btnAddMain.Location = new System.Drawing.Point(599, 36);
      this.btnAddMain.Name = "btnAddMain";
      this.btnAddMain.Size = new Size(39, 23);
      this.btnAddMain.TabIndex = 141;
      this.btnAddMain.Text = "+";
      this.btnAddMain.UseVisualStyleBackColor = true;
      this.LblSecondApps2.Location = new System.Drawing.Point(940, 123);
      this.LblSecondApps2.Name = "LblSecondApps2";
      this.LblSecondApps2.Size = new Size(87, 20);
      this.LblSecondApps2.TabIndex = 140;
      this.LblSecondApps2.Text = "APPLIANCES";
      this.txtSecondryCount.Location = new System.Drawing.Point(973, 96);
      this.txtSecondryCount.MaxLength = 100;
      this.txtSecondryCount.Name = "txtSecondryCount";
      this.txtSecondryCount.Size = new Size(36, 21);
      this.txtSecondryCount.TabIndex = 139;
      this.txtSecondryCount.Tag = (object) "";
      this.cboSecondryApps.Cursor = Cursors.Hand;
      this.cboSecondryApps.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSecondryApps.Location = new System.Drawing.Point(409, 99);
      this.cboSecondryApps.Name = "cboSecondryApps";
      this.cboSecondryApps.Size = new Size(229, 21);
      this.cboSecondryApps.TabIndex = 138;
      this.cboSecondryApps.Tag = (object) "";
      this.lblSecondOR.Location = new System.Drawing.Point(942, 99);
      this.lblSecondOR.Name = "lblSecondOR";
      this.lblSecondOR.Size = new Size(25, 20);
      this.lblSecondOR.TabIndex = 137;
      this.lblSecondOR.Text = "OR";
      this.btnAppsOK.Location = new System.Drawing.Point(995, 146);
      this.btnAppsOK.Name = "btnAppsOK";
      this.btnAppsOK.Size = new Size(39, 23);
      this.btnAppsOK.TabIndex = 136;
      this.btnAppsOK.Text = "OK";
      this.btnAppsOK.UseVisualStyleBackColor = true;
      this.lblAdditionalApps.Location = new System.Drawing.Point(254, 104);
      this.lblAdditionalApps.Name = "lblAdditionalApps";
      this.lblAdditionalApps.Size = new Size(144, 20);
      this.lblAdditionalApps.TabIndex = 134;
      this.lblAdditionalApps.Text = "Additional Appliance(s)";
      this.lblMainApps2.Location = new System.Drawing.Point(940, 54);
      this.lblMainApps2.Name = "lblMainApps2";
      this.lblMainApps2.Size = new Size(87, 20);
      this.lblMainApps2.TabIndex = 133;
      this.lblMainApps2.Text = "APPLIANCES";
      this.txtMainAppCount.Location = new System.Drawing.Point(973, 27);
      this.txtMainAppCount.MaxLength = 100;
      this.txtMainAppCount.Name = "txtMainAppCount";
      this.txtMainAppCount.Size = new Size(36, 21);
      this.txtMainAppCount.TabIndex = 132;
      this.txtMainAppCount.Tag = (object) "";
      this.cboMainApps.Cursor = Cursors.Hand;
      this.cboMainApps.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboMainApps.Location = new System.Drawing.Point(409, 13);
      this.cboMainApps.Name = "cboMainApps";
      this.cboMainApps.Size = new Size(229, 21);
      this.cboMainApps.TabIndex = 131;
      this.cboMainApps.Tag = (object) "";
      this.lblMainOR.Location = new System.Drawing.Point(942, 30);
      this.lblMainOR.Name = "lblMainOR";
      this.lblMainOR.Size = new Size(25, 20);
      this.lblMainOR.TabIndex = 130;
      this.lblMainOR.Text = "OR";
      this.lblMainApps.Location = new System.Drawing.Point(254, 18);
      this.lblMainApps.Name = "lblMainApps";
      this.lblMainApps.Size = new Size(125, 20);
      this.lblMainApps.TabIndex = 128;
      this.lblMainApps.Text = "Main Appliance(s)";
      this.lblAppsCovered.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblAppsCovered.Location = new System.Drawing.Point(5, 13);
      this.lblAppsCovered.Name = "lblAppsCovered";
      this.lblAppsCovered.Size = new Size(230, 25);
      this.lblAppsCovered.TabIndex = (int) sbyte.MaxValue;
      this.lblAppsCovered.Text = "Appliances Covered";
      this.lblReference.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblReference.Location = new System.Drawing.Point(666, 625);
      this.lblReference.Name = "lblReference";
      this.lblReference.Size = new Size(228, 25);
      this.lblReference.TabIndex = 79;
      this.lblReference.Text = "Contract Reference: ";
      this.lblMonthly.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMonthly.Location = new System.Drawing.Point(5, 625);
      this.lblMonthly.Name = "lblMonthly";
      this.lblMonthly.Size = new Size(230, 25);
      this.lblMonthly.TabIndex = 77;
      this.lblMonthly.Text = "First Month Amount";
      this.BtnCancel.Enabled = false;
      this.BtnCancel.Location = new System.Drawing.Point(902, 28);
      this.BtnCancel.Name = "BtnCancel";
      this.BtnCancel.Size = new Size(138, 23);
      this.BtnCancel.TabIndex = 38;
      this.BtnCancel.Text = "CANCEL CURRENT";
      this.BtnCancel.UseVisualStyleBackColor = true;
      this.BtnCancel.Visible = false;
      this.btnAmend.Location = new System.Drawing.Point(427, 28);
      this.btnAmend.Name = "btnAmend";
      this.btnAmend.Size = new Size(146, 23);
      this.btnAmend.TabIndex = 33;
      this.btnAmend.Text = "AMEND CURRENT";
      this.btnAmend.UseVisualStyleBackColor = true;
      this.btnNew.Location = new System.Drawing.Point(271, 28);
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new Size(150, 23);
      this.btnNew.TabIndex = 32;
      this.btnNew.Text = "ADD NEW";
      this.btnNew.UseVisualStyleBackColor = true;
      this.Label7.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label7.Location = new System.Drawing.Point(2, 28);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(263, 25);
      this.Label7.TabIndex = 30;
      this.Label7.Text = "Add, Amend or Cancel?";
      this.cboSoldBy.Cursor = Cursors.Hand;
      this.cboSoldBy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSoldBy.Location = new System.Drawing.Point(776, 30);
      this.cboSoldBy.Name = "cboSoldBy";
      this.cboSoldBy.Size = new Size(257, 21);
      this.cboSoldBy.TabIndex = 153;
      this.cboSoldBy.Tag = (object) "";
      this.cboSoldBy.Visible = false;
      this.lblRenewed.AutoSize = true;
      this.lblRenewed.ForeColor = Color.DarkRed;
      this.lblRenewed.Location = new System.Drawing.Point(700, 33);
      this.lblRenewed.Name = "lblRenewed";
      this.lblRenewed.Size = new Size(196, 13);
      this.lblRenewed.TabIndex = 152;
      this.lblRenewed.Text = "This Contract Has been Renewed";
      this.lblRenewed.Visible = false;
      this.grpContractPeriod.Controls.Add((Control) this.btnPeriodOK);
      this.grpContractPeriod.Controls.Add((Control) this.lblPeriod);
      this.grpContractPeriod.Controls.Add((Control) this.cboPeriod);
      this.grpContractPeriod.Controls.Add((Control) this.lblConPeriod);
      this.grpContractPeriod.Controls.Add((Control) this.dtpContractStartDate);
      this.grpContractPeriod.Controls.Add((Control) this.lblContractStartDate);
      this.grpContractPeriod.Location = new System.Drawing.Point(8, 112);
      this.grpContractPeriod.Name = "grpContractPeriod";
      this.grpContractPeriod.Size = new Size(1040, 48);
      this.grpContractPeriod.TabIndex = 94;
      this.btnPeriodOK.Location = new System.Drawing.Point(997, 11);
      this.btnPeriodOK.Name = "btnPeriodOK";
      this.btnPeriodOK.Size = new Size(36, 23);
      this.btnPeriodOK.TabIndex = 53;
      this.btnPeriodOK.Text = "OK";
      this.btnPeriodOK.UseVisualStyleBackColor = true;
      this.lblPeriod.Location = new System.Drawing.Point(667, 16);
      this.lblPeriod.Name = "lblPeriod";
      this.lblPeriod.Size = new Size(50, 20);
      this.lblPeriod.TabIndex = 52;
      this.lblPeriod.Text = "Period";
      this.cboPeriod.Cursor = Cursors.Hand;
      this.cboPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPeriod.Location = new System.Drawing.Point(776, 12);
      this.cboPeriod.Name = "cboPeriod";
      this.cboPeriod.Size = new Size(214, 21);
      this.cboPeriod.TabIndex = 51;
      this.cboPeriod.Tag = (object) "Contract.ContractStatusID";
      this.lblConPeriod.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblConPeriod.Location = new System.Drawing.Point(5, 13);
      this.lblConPeriod.Name = "lblConPeriod";
      this.lblConPeriod.Size = new Size(207, 25);
      this.lblConPeriod.TabIndex = 50;
      this.lblConPeriod.Text = "Contract Period";
      this.dtpContractStartDate.Location = new System.Drawing.Point(406, 10);
      this.dtpContractStartDate.Name = "dtpContractStartDate";
      this.dtpContractStartDate.Size = new Size(230, 21);
      this.dtpContractStartDate.TabIndex = 49;
      this.dtpContractStartDate.Tag = (object) "Contract.ContractStartDate";
      this.lblContractStartDate.Location = new System.Drawing.Point(252, 13);
      this.lblContractStartDate.Name = "lblContractStartDate";
      this.lblContractStartDate.Size = new Size(148, 20);
      this.lblContractStartDate.TabIndex = 48;
      this.lblContractStartDate.Text = "Starting From";
      this.grpAdditionalOptions.Controls.Add((Control) this.btnAdditionalOK);
      this.grpAdditionalOptions.Controls.Add((Control) this.lblAdditionalOptions);
      this.grpAdditionalOptions.Controls.Add((Control) this.chkPlumbingDrainage);
      this.grpAdditionalOptions.Controls.Add((Control) this.chkWindowLockPest);
      this.grpAdditionalOptions.Controls.Add((Control) this.chkGasSupplyPipework);
      this.grpAdditionalOptions.Location = new System.Drawing.Point(8, 348);
      this.grpAdditionalOptions.Name = "grpAdditionalOptions";
      this.grpAdditionalOptions.Size = new Size(1040, 31);
      this.grpAdditionalOptions.TabIndex = 95;
      this.btnAdditionalOK.Location = new System.Drawing.Point(996, 4);
      this.btnAdditionalOK.Name = "btnAdditionalOK";
      this.btnAdditionalOK.Size = new Size(39, 23);
      this.btnAdditionalOK.TabIndex = 68;
      this.btnAdditionalOK.Text = "OK";
      this.btnAdditionalOK.UseVisualStyleBackColor = true;
      this.lblAdditionalOptions.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblAdditionalOptions.Location = new System.Drawing.Point(8, 2);
      this.lblAdditionalOptions.Name = "lblAdditionalOptions";
      this.lblAdditionalOptions.Size = new Size(230, 25);
      this.lblAdditionalOptions.TabIndex = 67;
      this.lblAdditionalOptions.Text = "Additional Options";
      this.chkPlumbingDrainage.AutoSize = true;
      this.chkPlumbingDrainage.Location = new System.Drawing.Point(487, 9);
      this.chkPlumbingDrainage.Name = "chkPlumbingDrainage";
      this.chkPlumbingDrainage.Size = new Size(252, 17);
      this.chkPlumbingDrainage.TabIndex = 66;
      this.chkPlumbingDrainage.Text = "Plumbing, drainage and electrical cover";
      this.chkPlumbingDrainage.UseVisualStyleBackColor = true;
      this.chkWindowLockPest.AutoSize = true;
      this.chkWindowLockPest.Location = new System.Drawing.Point(257, 9);
      this.chkWindowLockPest.Name = "chkWindowLockPest";
      this.chkWindowLockPest.Size = new Size(190, 17);
      this.chkWindowLockPest.TabIndex = 65;
      this.chkWindowLockPest.Text = "Window, lock and pest cover";
      this.chkWindowLockPest.UseVisualStyleBackColor = true;
      this.chkGasSupplyPipework.AutoSize = true;
      this.chkGasSupplyPipework.Location = new System.Drawing.Point(775, 9);
      this.chkGasSupplyPipework.Name = "chkGasSupplyPipework";
      this.chkGasSupplyPipework.Size = new Size(147, 17);
      this.chkGasSupplyPipework.TabIndex = 64;
      this.chkGasSupplyPipework.Text = "Gas Supply Pipework";
      this.chkGasSupplyPipework.UseVisualStyleBackColor = true;
      this.grpPayers.Controls.Add((Control) this.grpDD);
      this.grpPayers.Controls.Add((Control) this.Panel2);
      this.grpPayers.Controls.Add((Control) this.Panel1);
      this.grpPayers.Controls.Add((Control) this.cboInitialPaymentType);
      this.grpPayers.Controls.Add((Control) this.btnPaymentOK);
      this.grpPayers.Controls.Add((Control) this.lblPaymentMethod);
      this.grpPayers.Controls.Add((Control) this.cboPaymentType);
      this.grpPayers.Controls.Add((Control) this.cboPAyer);
      this.grpPayers.Controls.Add((Control) this.lblPayer);
      this.grpPayers.Controls.Add((Control) this.lblPayersDetail);
      this.grpPayers.Location = new System.Drawing.Point(8, 430);
      this.grpPayers.Name = "grpPayers";
      this.grpPayers.Size = new Size(1040, 69);
      this.grpPayers.TabIndex = 96;
      this.grpDD.Controls.Add((Control) this.lblchanging);
      this.grpDD.Controls.Add((Control) this.txtAccName);
      this.grpDD.Controls.Add((Control) this.lbl3);
      this.grpDD.Controls.Add((Control) this.txtBankName);
      this.grpDD.Controls.Add((Control) this.txtAccNumber);
      this.grpDD.Controls.Add((Control) this.lblBankName);
      this.grpDD.Controls.Add((Control) this.lblAccNumber);
      this.grpDD.Controls.Add((Control) this.txtSortCode);
      this.grpDD.Controls.Add((Control) this.lblSortCode);
      this.grpDD.Location = new System.Drawing.Point(3, 31);
      this.grpDD.Name = "grpDD";
      this.grpDD.Size = new Size(991, 38);
      this.grpDD.TabIndex = 117;
      this.grpDD.Visible = false;
      this.lblchanging.ForeColor = Color.Red;
      this.lblchanging.Location = new System.Drawing.Point(7, 5);
      this.lblchanging.Name = "lblchanging";
      this.lblchanging.Size = new Size(236, 28);
      this.lblchanging.TabIndex = 129;
      this.lblchanging.Text = "Changing D/D details will create a new D/D (even if original details are blank)";
      this.lblchanging.Visible = false;
      this.txtAccName.Location = new System.Drawing.Point(340, 8);
      this.txtAccName.Name = "txtAccName";
      this.txtAccName.Size = new Size(137, 21);
      this.txtAccName.TabIndex = 1;
      this.lbl3.Location = new System.Drawing.Point(249, 12);
      this.lbl3.Name = "lbl3";
      this.lbl3.Size = new Size(89, 20);
      this.lbl3.TabIndex = 110;
      this.lbl3.Text = "Account Name";
      this.txtBankName.Location = new System.Drawing.Point(883, 8);
      this.txtBankName.Name = "txtBankName";
      this.txtBankName.Size = new Size(104, 21);
      this.txtBankName.TabIndex = 4;
      this.txtAccNumber.Location = new System.Drawing.Point(726, 8);
      this.txtAccNumber.Name = "txtAccNumber";
      this.txtAccNumber.Size = new Size(84, 21);
      this.txtAccNumber.TabIndex = 3;
      this.lblBankName.Location = new System.Drawing.Point(811, 11);
      this.lblBankName.Name = "lblBankName";
      this.lblBankName.Size = new Size(78, 20);
      this.lblBankName.TabIndex = 107;
      this.lblBankName.Text = "Bank Name";
      this.lblAccNumber.Location = new System.Drawing.Point(625, 11);
      this.lblAccNumber.Name = "lblAccNumber";
      this.lblAccNumber.Size = new Size(108, 20);
      this.lblAccNumber.TabIndex = 106;
      this.lblAccNumber.Text = "Account Number";
      this.txtSortCode.Location = new System.Drawing.Point(544, 8);
      this.txtSortCode.Name = "txtSortCode";
      this.txtSortCode.Size = new Size(77, 21);
      this.txtSortCode.TabIndex = 2;
      this.lblSortCode.Location = new System.Drawing.Point(480, 12);
      this.lblSortCode.Name = "lblSortCode";
      this.lblSortCode.Size = new Size(73, 20);
      this.lblSortCode.TabIndex = 104;
      this.lblSortCode.Text = "Sort Code";
      this.Panel2.Location = new System.Drawing.Point(634, 33);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new Size(357, 33);
      this.Panel2.TabIndex = 117;
      this.Panel1.Controls.Add((Control) this.lblPaidBy);
      this.Panel1.Location = new System.Drawing.Point(645, 38);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(110, 22);
      this.Panel1.TabIndex = 116;
      this.lblPaidBy.Location = new System.Drawing.Point(6, 1);
      this.lblPaidBy.Name = "lblPaidBy";
      this.lblPaidBy.Size = new Size(106, 20);
      this.lblPaidBy.TabIndex = 115;
      this.lblPaidBy.Text = "Paid By:";
      this.cboInitialPaymentType.Cursor = Cursors.Hand;
      this.cboInitialPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInitialPaymentType.Location = new System.Drawing.Point(773, 38);
      this.cboInitialPaymentType.Name = "cboInitialPaymentType";
      this.cboInitialPaymentType.Size = new Size(216, 21);
      this.cboInitialPaymentType.TabIndex = 113;
      this.cboInitialPaymentType.Tag = (object) "Contract.ContractStatusID";
      this.btnPaymentOK.Location = new System.Drawing.Point(998, 37);
      this.btnPaymentOK.Name = "btnPaymentOK";
      this.btnPaymentOK.Size = new Size(36, 23);
      this.btnPaymentOK.TabIndex = 98;
      this.btnPaymentOK.Text = "OK";
      this.btnPaymentOK.UseVisualStyleBackColor = true;
      this.lblPaymentMethod.Location = new System.Drawing.Point(722, 10);
      this.lblPaymentMethod.Name = "lblPaymentMethod";
      this.lblPaymentMethod.Size = new Size(106, 20);
      this.lblPaymentMethod.TabIndex = 93;
      this.lblPaymentMethod.Text = "Payment Method";
      this.cboPaymentType.Cursor = Cursors.Hand;
      this.cboPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPaymentType.Location = new System.Drawing.Point(834, 6);
      this.cboPaymentType.Name = "cboPaymentType";
      this.cboPaymentType.Size = new Size(154, 21);
      this.cboPaymentType.TabIndex = 92;
      this.cboPaymentType.Tag = (object) "Contract.ContractStatusID";
      this.cboPAyer.Cursor = Cursors.Hand;
      this.cboPAyer.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPAyer.Location = new System.Drawing.Point(407, 5);
      this.cboPAyer.Name = "cboPAyer";
      this.cboPAyer.Size = new Size(309, 21);
      this.cboPAyer.TabIndex = 91;
      this.cboPAyer.Tag = (object) "";
      this.lblPayer.Location = new System.Drawing.Point(252, 10);
      this.lblPayer.Name = "lblPayer";
      this.lblPayer.Size = new Size(59, 20);
      this.lblPayer.TabIndex = 90;
      this.lblPayer.Text = "Payer";
      this.lblPayersDetail.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblPayersDetail.Location = new System.Drawing.Point(9, 5);
      this.lblPayersDetail.Name = "lblPayersDetail";
      this.lblPayersDetail.Size = new Size(230, 25);
      this.lblPayersDetail.TabIndex = 89;
      this.lblPayersDetail.Text = "Payers Detail";
      this.grpAdditionalDetails.Controls.Add((Control) this.chkCommercial);
      this.grpAdditionalDetails.Controls.Add((Control) this.chkLandlord);
      this.grpAdditionalDetails.Controls.Add((Control) this.txtNotesToEngineer);
      this.grpAdditionalDetails.Controls.Add((Control) this.lblServiceNotes);
      this.grpAdditionalDetails.Controls.Add((Control) this.txtPONumber);
      this.grpAdditionalDetails.Controls.Add((Control) this.lblPO);
      this.grpAdditionalDetails.Controls.Add((Control) this.lblAddDetails);
      this.grpAdditionalDetails.Location = new System.Drawing.Point(8, 509);
      this.grpAdditionalDetails.Name = "grpAdditionalDetails";
      this.grpAdditionalDetails.Size = new Size(1040, 87);
      this.grpAdditionalDetails.TabIndex = 96;
      this.chkCommercial.AutoSize = true;
      this.chkCommercial.Location = new System.Drawing.Point(487, 55);
      this.chkCommercial.Name = "chkCommercial";
      this.chkCommercial.Size = new Size(123, 17);
      this.chkCommercial.TabIndex = 8;
      this.chkCommercial.Text = "Commercial Plan";
      this.chkCommercial.UseVisualStyleBackColor = true;
      this.chkLandlord.AutoSize = true;
      this.chkLandlord.Location = new System.Drawing.Point(256, 55);
      this.chkLandlord.Name = "chkLandlord";
      this.chkLandlord.Size = new Size(159, 17);
      this.chkLandlord.TabIndex = 7;
      this.chkLandlord.Text = "Landlord Cert Required";
      this.chkLandlord.UseVisualStyleBackColor = true;
      this.txtNotesToEngineer.Location = new System.Drawing.Point(773, 8);
      this.txtNotesToEngineer.Multiline = true;
      this.txtNotesToEngineer.Name = "txtNotesToEngineer";
      this.txtNotesToEngineer.Size = new Size(216, 71);
      this.txtNotesToEngineer.TabIndex = 6;
      this.lblServiceNotes.Location = new System.Drawing.Point(650, 8);
      this.lblServiceNotes.Name = "lblServiceNotes";
      this.lblServiceNotes.Size = new Size(114, 20);
      this.lblServiceNotes.TabIndex = 89;
      this.lblServiceNotes.Text = "Service Visit Notes";
      this.txtPONumber.Location = new System.Drawing.Point(408, 8);
      this.txtPONumber.Name = "txtPONumber";
      this.txtPONumber.Size = new Size(229, 21);
      this.txtPONumber.TabIndex = 5;
      this.lblPO.Location = new System.Drawing.Point(254, 11);
      this.lblPO.Name = "lblPO";
      this.lblPO.Size = new Size(159, 20);
      this.lblPO.TabIndex = 86;
      this.lblPO.Text = "PO Number";
      this.lblAddDetails.Font = new Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblAddDetails.Location = new System.Drawing.Point(6, 8);
      this.lblAddDetails.Name = "lblAddDetails";
      this.lblAddDetails.Size = new Size(230, 25);
      this.lblAddDetails.TabIndex = 85;
      this.lblAddDetails.Text = "Additional Details";
      this.Controls.Add((Control) this.grpAdditionalDetails);
      this.Controls.Add((Control) this.grpPayers);
      this.Controls.Add((Control) this.grpAdditionalOptions);
      this.Controls.Add((Control) this.grpContractPeriod);
      this.Controls.Add((Control) this.grpContract);
      this.Name = nameof (UCContractWiz);
      this.Size = new Size(1095, 701);
      this.grpContract.ResumeLayout(false);
      this.grpContract.PerformLayout();
      this.grpPromo.ResumeLayout(false);
      this.grpContractType.ResumeLayout(false);
      this.grpAppliancesCovered.ResumeLayout(false);
      this.grpAppliancesCovered.PerformLayout();
      ((ISupportInitialize) this.dgSecondAssets).EndInit();
      ((ISupportInitialize) this.DgMain).EndInit();
      this.grpContractPeriod.ResumeLayout(false);
      this.grpAdditionalOptions.ResumeLayout(false);
      this.grpAdditionalOptions.PerformLayout();
      this.grpPayers.ResumeLayout(false);
      this.grpDD.ResumeLayout(false);
      this.grpDD.PerformLayout();
      this.Panel1.ResumeLayout(false);
      this.grpAdditionalDetails.ResumeLayout(false);
      this.grpAdditionalDetails.PerformLayout();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentContract;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public ContractOriginal CurrentContract
    {
      get
      {
        return this._currentContract;
      }
      set
      {
        this._currentContract = value;
        if (this._currentContract == null)
        {
          this._currentContract = new ContractOriginal();
          this._currentContract.Exists = false;
        }
        if (this._currentContract.Exists)
          this.dtpContractStartDate.Enabled = false;
        else
          this.lblTotalEst.Text = Strings.Format((object) 0.0, "C");
        if (this.CurrentContractSite != null)
          return;
        this.CurrentContractSite = new ContractOriginalSite();
        this.CurrentContractSite.Exists = false;
      }
    }

    public int IDToLinkTo
    {
      get
      {
        return this._IDToLinkTo;
      }
      set
      {
        this._IDToLinkTo = value;
        this.Sites = App.DB.ContractOriginalSite.GetAll_ContractID(this.CurrentContract.ContractID, this.IDToLinkTo);
      }
    }

    public DataView Sites
    {
      get
      {
        return this._Sites;
      }
      set
      {
        this._Sites = value;
        this._Sites.Table.TableName = Enums.TableNames.tblContractSite.ToString();
        this._Sites.AllowNew = false;
        this._Sites.AllowEdit = false;
        this._Sites.AllowDelete = false;
        this.SiteID = this.SiteID;
      }
    }

    public DataView MainDataView
    {
      get
      {
        return this._MainDataView;
      }
      set
      {
        this._MainDataView = value;
        this._MainDataView.Table.TableName = "MainApps";
        this._MainDataView.AllowNew = false;
        this._MainDataView.AllowEdit = true;
        this._MainDataView.AllowDelete = false;
        this.DgMain.DataSource = (object) this.MainDataView;
      }
    }

    private DataGridViewRow SelectedMainDataRow
    {
      get
      {
        return this.DgMain.CurrentRow != null && this.DgMain.CurrentRow.Index != -1 ? this.DgMain.CurrentRow : (DataGridViewRow) null;
      }
    }

    private DataView SecondAppliances
    {
      get
      {
        return this._SecondAppliances;
      }
      set
      {
        this._SecondAppliances = value;
        this._SecondAppliances.AllowDelete = false;
        this._SecondAppliances.AllowEdit = false;
        this._SecondAppliances.AllowNew = false;
        this._SecondAppliances.Table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
        this.dgSecondAssets.DataSource = (object) this.SecondAppliances;
      }
    }

    private DataGridViewRow SelectedSecondAppDataRow
    {
      get
      {
        return this.dgSecondAssets.CurrentRow != null && this.dgSecondAssets.CurrentRow.Index != -1 ? this.dgSecondAssets.CurrentRow : (DataGridViewRow) null;
      }
    }

    public int SiteID
    {
      get
      {
        return this._SiteID;
      }
      set
      {
        this._SiteID = value;
        if (App.DB.ContractOriginal.GetAll_ForSite_Active(this.SiteID).Table.Rows.Count == 0)
          this.btnAmend.Enabled = false;
        else
          this.btnAmend.Enabled = true;
        if (!(this.SiteID > 0 & this.IDToLinkTo == 787))
          return;
        this._Sites.RowFilter = "SiteID=" + Conversions.ToString(this.SiteID);
      }
    }

    public bool NumberUsed
    {
      get
      {
        return this._NumberUsed;
      }
      set
      {
        this._NumberUsed = value;
      }
    }

    public double Price
    {
      get
      {
        return this._Price;
      }
      set
      {
        this._Price = value;
      }
    }

    public JobNumber Number
    {
      get
      {
        return this._jobNumber;
      }
      set
      {
        this._jobNumber = value;
      }
    }

    public ContractOriginalSite CurrentContractSite
    {
      get
      {
        return this._currentContractSite;
      }
      set
      {
        this._currentContractSite = value;
        if (this._currentContractSite != null)
          return;
        this._currentContractSite = new ContractOriginalSite();
        this._currentContractSite.Exists = false;
      }
    }

    public void SetupMainDataGrid()
    {
      this.DgMain.Columns[0].Visible = false;
      this.DgMain.ColumnHeadersVisible = false;
      this.DgMain.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.DgMain.AllowUserToAddRows = false;
    }

    public void SetupSecondryDataGrid()
    {
      this.dgSecondAssets.Columns[0].Visible = false;
      this.dgSecondAssets.ColumnHeadersVisible = false;
      this.dgSecondAssets.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.dgSecondAssets.AllowUserToAddRows = false;
    }

    private void UCContract_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
      this.grpAppliancesCovered.Visible = false;
      this.grpContractType.Visible = false;
      this.grpContractPeriod.Visible = false;
      this.grpAdditionalDetails.Visible = false;
      this.grpAdditionalOptions.Visible = false;
      this.grpPayers.Visible = false;
      this.grpPromo.Visible = false;
    }

    private void cboContractType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboContractType)) > 0.0)
      {
        if (this.CurrentContractSite.Exists)
        {
          this.lblContractRef.Text = this.CurrentContract.ContractReference;
          if ((Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Amend Contract", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Renew Contract", false) == 0) & (double) this.CurrentContract.ContractTypeID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboContractType)))
          {
            this.OverridePrice = false;
            if (this.Number != null)
              App.DB.Job.DeleteReservedOrderNumber(this.Number.JobNumber, this.Number.Prefix);
            this.Number = App.DB.Job.GetNextJobNumber((Enums.JobDefinition) Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractType)));
            int jobNumber = this.Number.JobNumber;
            if (jobNumber.ToString().Length < 3)
            {
              this.lblContractRef.Text = this.Number.Prefix + "00" + Conversions.ToString(this.Number.JobNumber);
            }
            else
            {
              jobNumber = this.Number.JobNumber;
              this.lblContractRef.Text = jobNumber.ToString().Length >= 4 ? this.Number.Prefix + Conversions.ToString(this.Number.JobNumber) : this.Number.Prefix + "0" + Conversions.ToString(this.Number.JobNumber);
            }
          }
        }
        else
        {
          if (this.Number != null)
            App.DB.Job.DeleteReservedOrderNumber(this.Number.JobNumber, this.Number.Prefix);
          this.Number = App.DB.Job.GetNextJobNumber((Enums.JobDefinition) Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractType)));
          int jobNumber = this.Number.JobNumber;
          if (jobNumber.ToString().Length < 3)
          {
            this.lblContractRef.Text = this.Number.Prefix + "00" + Conversions.ToString(this.Number.JobNumber);
          }
          else
          {
            jobNumber = this.Number.JobNumber;
            this.lblContractRef.Text = jobNumber.ToString().Length >= 4 ? this.Number.Prefix + Conversions.ToString(this.Number.JobNumber) : this.Number.Prefix + "0" + Conversions.ToString(this.Number.JobNumber);
          }
        }
        if (!this.CurrentContract.Exists)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboContractType), "Totally Assured", false) == 0)
          {
            ComboBox cboPeriod = this.cboPeriod;
            Combo.SetUpCombo(ref cboPeriod, DynamicDataTables.ContractPeriod, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            this.cboPeriod = cboPeriod;
          }
          else
          {
            this.cboPeriod.Items.Clear();
            this.cboPeriod.Items.Add((object) new Combo("-- Please Select --", "0", (object) null));
            this.cboPeriod.Items.Add((object) new Combo("1 Year", "1", (object) null));
            this.cboPeriod.DisplayMember = "Description";
            this.cboPeriod.ValueMember = "Value";
            ComboBox cboPeriod1 = this.cboPeriod;
            Combo.SetSelectedComboItem_By_Value(ref cboPeriod1, "0");
            this.cboPeriod = cboPeriod1;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Amend Contract", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Renew Contract", false) == 0)
            {
              ComboBox cboPeriod2 = this.cboPeriod;
              Combo.SetSelectedComboItem_By_Value(ref cboPeriod2, "1");
              this.cboPeriod = cboPeriod2;
            }
          }
        }
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPeriod)) > 1.0 & (this.chkGasSupplyPipework.Checked | this.chkPlumbingDrainage.Checked | this.chkWindowLockPest.Checked))
        {
          int num = (int) App.ShowMessage("Additional Options can not be added to a plan which runs for more than one year.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.chkWindowLockPest.Checked = false;
          this.chkPlumbingDrainage.Checked = false;
          this.chkGasSupplyPipework.Checked = false;
        }
        else
          this.DoTotals();
      }
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.btnTypeOk.Visible = true;
      if (App.DB.ContractOriginal.GetAll_ForSite_Active(this.SiteID).Table.Rows.Count > 0 && App.ShowMessage("Contracts already exist for this site are you sure you wish to add a new contract?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      this.c = this.ParentForm.Controls.Find("btnSave", true);
      this.b = (Button) this.c[0];
      this.b.Text = "Create Contract";
      this.b.Visible = false;
      this.cboSoldBy.SelectedValue = (object) App.loggedInUser.UserID;
      this.lblsold.Visible = true;
      this.cboSoldBy.Visible = true;
      this.btnTransfer.Visible = false;
      this.lblIsLandlord.Visible = true;
      this.lblIsLandlord.Text = "Is this a Landlords property? - Please attached L/L before continuing";
      this.cboContract.Visible = false;
      this.grpAppliancesCovered.Visible = false;
      this.grpContractPeriod.Visible = false;
      this.grpAdditionalDetails.Visible = false;
      this.grpAdditionalOptions.Visible = false;
      this.grpPayers.Visible = false;
      this.grpPromo.Visible = false;
      ComboBox cboMainApps = this.cboMainApps;
      Combo.SetUpCombo(ref cboMainApps, App.DB.Asset.Asset_GetForSite(this.SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select);
      this.cboMainApps = cboMainApps;
      ComboBox cboSecondryApps = this.cboSecondryApps;
      Combo.SetUpCombo(ref cboSecondryApps, App.DB.Asset.Asset_GetForSite(this.SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select);
      this.cboSecondryApps = cboSecondryApps;
      this.PayerDrop();
      this.MainDataView = App.DB.ContractOriginal.GetAssetsForContract(0, true);
      this.SecondAppliances = App.DB.ContractOriginal.GetAssetsForContract(0, false);
      this.SetupMainDataGrid();
      this.SetupSecondryDataGrid();
      this.grpContractType.Visible = true;
      this.lblcancel.Visible = false;
      this.lblCancelReason.Visible = false;
      this.dtpCancelledDate.Visible = false;
      this.cboReasonID.Visible = false;
      this.needDD = true;
      this.lblchanging.Visible = false;
    }

    private void btnAmend_Click(object sender, EventArgs e)
    {
      this.lblsold.Visible = false;
      this.cboSoldBy.Visible = false;
      this.c = this.ParentForm.Controls.Find("btnSave", true);
      this.b = (Button) this.c[0];
      this.b.Text = "Amend Contract";
      this.b.Enabled = false;
      this.grpContractType.Visible = true;
      this.cboContract.Visible = true;
      this.lblcancel.Visible = false;
      this.lblCancelReason.Visible = false;
      this.dtpCancelledDate.Visible = false;
      this.cboReasonID.Visible = false;
      this.cboPaymentType.Enabled = false;
      this.lblIsLandlord.Visible = false;
      this.ContractDrop();
      ComboBox cboMainApps = this.cboMainApps;
      Combo.SetUpCombo(ref cboMainApps, App.DB.Asset.Asset_GetForSite(this.SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select);
      this.cboMainApps = cboMainApps;
      ComboBox cboSecondryApps = this.cboSecondryApps;
      Combo.SetUpCombo(ref cboSecondryApps, App.DB.Asset.Asset_GetForSite(this.SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select);
      this.cboSecondryApps = cboSecondryApps;
      this.lblchanging.Visible = true;
      this.needDD = false;
      this.b.Enabled = false;
    }

    private void btnTransfer_Click(object sender, EventArgs e)
    {
      DLGFindSite dlgFindSite = new DLGFindSite();
      dlgFindSite.TableToSearch = Enums.TableNames.tblSite;
      dlgFindSite.AddressID = Conversions.ToString(this.CurrentContract.InvoiceAddressID);
      dlgFindSite.InvoiceFrequencyID = Conversions.ToString(this.CurrentContract.InvoiceFrequencyID);
      int num = (int) dlgFindSite.ShowDialog();
      this.NewSiteID = dlgFindSite.ID;
      this.NewPayer = dlgFindSite.SecondID;
      this.EffDate = dlgFindSite.EffDate;
      if (((this.CurrentContract.InvoiceFrequencyID == 4 ? 1 : 0) & ((Conversions.ToDouble(this.NewPayer.Split('`')[0]) != (double) this.CurrentContract.InvoiceAddressID ? 1 : 0) | (Conversions.ToDouble(this.NewPayer.Split('`')[1]) != (double) this.CurrentContract.InvoiceAddressTypeID ? 1 : 0))) != 0)
      {
        this.txtAccName.Text = "";
        this.txtAccNumber.Text = "";
        this.txtBankName.Text = "";
        this.txtSortCode.Text = "";
        this.grpAdditionalDetails.Visible = false;
        this.b.Text = "Transfer Contract";
        this.b.Enabled = false;
      }
      else
      {
        this.grpAdditionalDetails.Visible = false;
        this.b.Text = "Transfer Contract";
        this.b.Enabled = false;
      }
      DataTable table = App.DB.InvoiceAddress.InvoiceAddress_Get_SiteID(this.NewSiteID).Table;
      this.cboPAyer.Items.Clear();
      IEnumerator enumerator;
      try
      {
        enumerator = table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          this.cboPAyer.Items.Add((object) new Combo(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["Address1"], (object) ","), current["Address2"]), (object) ","), current["Postcode"])), Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["AddressID"], (object) "`"), current["AddressTypeID"])), (object) null));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.cboPAyer.Items.Add((object) new Combo("-- Please Select --", Conversions.ToString(0), (object) null));
      this.cboPAyer.DisplayMember = "Description";
      this.cboPAyer.ValueMember = "Value";
      ComboBox cboPayer = this.cboPAyer;
      Combo.SetSelectedComboItem_By_Value(ref cboPayer, this.NewPayer);
      this.cboPAyer = cboPayer;
      this.lblchanging.Visible = true;
    }

    private void btnAddMain_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboMainApps)) > 0.0)
      {
        this.MainDataView.AllowNew = true;
        DataRowView dataRowView = this.MainDataView.AddNew();
        dataRowView["AssetID"] = (object) Combo.get_GetSelectedItemValue(this.cboMainApps);
        dataRowView["Product"] = (object) Combo.get_GetSelectedItemDescription(this.cboMainApps);
        dataRowView.EndEdit();
        this.DgMain.DataSource = (object) this.MainDataView;
      }
      this.txtMainAppCount.Text = Conversions.ToString(this.DgMain.Rows.Count);
      this.DoTotals();
    }

    private void btnAddSecond_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboSecondryApps)) > 0.0)
      {
        this.SecondAppliances.AllowNew = true;
        DataRowView dataRowView = this.SecondAppliances.AddNew();
        dataRowView["AssetID"] = (object) Combo.get_GetSelectedItemValue(this.cboSecondryApps);
        dataRowView["Product"] = (object) Combo.get_GetSelectedItemDescription(this.cboSecondryApps);
        dataRowView.EndEdit();
        this.dgSecondAssets.DataSource = (object) this.SecondAppliances;
      }
      this.txtSecondryCount.Text = Conversions.ToString(this.dgSecondAssets.Rows.Count);
      this.DoTotals();
    }

    private void btnTypeOk_Click_1(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboContractType)) > 0.0)
      {
        this.grpContractPeriod.Visible = true;
        this.DoTotals();
      }
      else
      {
        int num = (int) App.ShowMessage("You Must Select a contract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void btnPeriodOK_Click_1(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPeriod)) > 0.0)
      {
        this.grpAppliancesCovered.Visible = true;
        this.DoTotals();
      }
      else
      {
        int num = (int) App.ShowMessage("You Must Select a Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void btnAppsOK_Click(object sender, EventArgs e)
    {
      if (this.DgMain.RowCount == 0 & Conversions.ToDouble(this.CBT(this.txtMainAppCount.Text)) > 0.0)
      {
        FRMManualApp frmManualApp = new FRMManualApp();
        frmManualApp.lblMsg.Text = "As you haven't identified the main applaince, please provide one below.";
        int num = (int) frmManualApp.ShowDialog();
        this.ManualApp = Combo.get_GetSelectedItemDescription(frmManualApp.cboInitialPaymentType);
      }
      if (this.dgSecondAssets.RowCount == 0 & Conversions.ToDouble(this.CBT(this.txtSecondryCount.Text)) > 0.0)
      {
        FRMManualApp frmManualApp = new FRMManualApp();
        frmManualApp.lblMsg.Text = "As you haven't identified the second applaince, please provide one below.";
        int num = (int) frmManualApp.ShowDialog();
        this.SecondApp = Combo.get_GetSelectedItemDescription(frmManualApp.cboInitialPaymentType);
      }
      if (Conversions.ToDouble(this.CBT(this.txtMainAppCount.Text) + this.CBT(this.txtSecondryCount.Text)) > 0.0)
      {
        this.grpAdditionalOptions.Visible = true;
        this.DoTotals();
      }
      else
      {
        int num1 = (int) App.ShowMessage("You Must add at least one appliance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void btnPromoOK_Click(object sender, EventArgs e)
    {
      this.grpPayers.Visible = true;
      this.DoTotals();
      int num = (int) App.ShowMessage("Please be aware that all levels of cover exclude damage caused by scale, shale and sludge, plus the removal of such debris. \r\nThe repair or replacement of flues or their components is also excluded, as is pipework located inside the fabric of the building.\r\nAll cover plans are twelve month contracts, and cancellation during the cover period may not entitle you to a refund.\r\nDuring our first visit under cover, if we find that the appliance is in a seriously degraded state, then we may cancel your plan and return any policy payments made to that point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private void btnPaymentOK_Click(object sender, EventArgs e)
    {
      int integer1 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPaymentType));
      if (integer1 == 4 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtAccNumber.Text, this.ddAcc, false) == 0 & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Create Contract", false) > 0U)
      {
        this.grpAdditionalDetails.Visible = true;
        this.DoTotals();
        if (Conversions.ToDouble(this.lblTotalEst.Text) == 0.0 & this.discount != 100.0)
        {
          FRMNewPrice frmNewPrice = new FRMNewPrice();
          int num = (int) frmNewPrice.ShowDialog();
          if (Versioned.IsNumeric((object) frmNewPrice.txtPrice.Text) && Conversions.ToDouble(frmNewPrice.txtPrice.Text) > 0.0)
          {
            this.lblTotalEst.Text = Strings.Format((object) Conversions.ToDouble(frmNewPrice.txtPrice.Text), "C");
            this.lblMonthlyEst.Text = Strings.Format((object) (Conversions.ToDouble(this.lblTotalEst.Text) / 12.0), "C");
            this.lblFollowedBy.Text = Strings.Format((object) (Conversions.ToDouble(this.lblTotalEst.Text) / 12.0), "C");
            this.OverridePrice = true;
          }
        }
        this.b.Visible = true;
        this.b.Enabled = true;
      }
      else
      {
        this.discount = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPromotion)))?.PercentageRate.Value;
        int integer2 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractType));
        if (integer2 == 68698 | integer2 == 68696)
          this.discount = 100.0;
        if (Conversions.ToDouble(this.lblTotalEst.Text) == 0.0 & this.discount != 100.0)
        {
          FRMNewPrice frmNewPrice = new FRMNewPrice();
          int num = (int) frmNewPrice.ShowDialog();
          if (Versioned.IsNumeric((object) frmNewPrice.txtPrice.Text) && Conversions.ToDouble(frmNewPrice.txtPrice.Text) > 0.0)
          {
            this.lblTotalEst.Text = Strings.Format((object) Conversions.ToDouble(frmNewPrice.txtPrice.Text), "C");
            this.lblMonthlyEst.Text = Strings.Format((object) (Conversions.ToDouble(this.lblTotalEst.Text) / 12.0), "C");
            this.lblFollowedBy.Text = Strings.Format((object) (Conversions.ToDouble(this.lblTotalEst.Text) / 12.0), "C");
            this.OverridePrice = true;
          }
        }
        if (Conversions.ToDouble(this.lblTotalEst.Text) > 0.0)
        {
          if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboPAyer), "0", false) > 0U & integer1 > 0)
          {
            if (integer1 == 4 & (this.txtBankName.Text.Length > 0 & this.txtAccName.Text.Length > 2 & this.txtAccNumber.Text.Length < 9 & this.txtAccNumber.Text.Length > 2 & this.txtSortCode.Text.Length > 5 & this.txtSortCode.Text.Length < 7) | integer1 != 4)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Create Contract", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Renew Contract", false) == 0)
              {
                FRMGenDropBox frmGenDropBox = new FRMGenDropBox();
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboPaymentType), Conversions.ToString(3), false) == 0)
                {
                  frmGenDropBox.lblTop.Text = "You Must Take Full Payment Now In order to set up this Contract.";
                }
                else
                {
                  int num = (int) App.ShowMessage("All Direct Debits are protected by a guarantee. Would you like me to read the guarantee to you, or you can read it in the confirmation letter? \r\n\r\nThis guarantee is offered by all banks and building societies that take part in the Direct Debit scheme.If the amounts to be paid or the payment dates change, Gasway Services Ltd will notify you 10 working days in advance of your account being debited Or as otherwise agreed. If an error Is made by Gasway Services Ltd Or your bank Or building society, you are guaranteed a full And immediate refund from your branch of the amount paid. You can cancel a Direct Debit at any time by writing to your bank Or building society.  Please also send a copy of your letter to us.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  frmGenDropBox.lblTop.Text = "You Must Take the first Payment Now, In order to set up this Contract.";
                }
                int num1 = (int) frmGenDropBox.ShowDialog();
                ComboBox initialPaymentType = this.cboInitialPaymentType;
                Combo.SetSelectedComboItem_By_Value(ref initialPaymentType, Combo.get_GetSelectedItemValue(frmGenDropBox.cbo1));
                this.cboInitialPaymentType = initialPaymentType;
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboInitialPaymentType), "0", false) == 0)
                  return;
                this.ShowAdditionalDetails();
              }
              this.ShowAdditionalDetails();
            }
            else
            {
              int num2 = (int) App.ShowMessage("You must enter Bank name, Account name, sortcode (6 Digits) And account code (8 digits) correctly for Direct Debit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
          }
          else
          {
            int num3 = (int) App.ShowMessage("You must select a payer And payment method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
        else if (this.discount == 100.0)
        {
          this.ShowAdditionalDetails();
        }
        else
        {
          int num4 = (int) App.ShowMessage("You cannot create a contract of Zero Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
    }

    private void ShowAdditionalDetails()
    {
      this.grpAdditionalDetails.Visible = true;
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboContractType)) != 69420.0)
        this.DoTotals();
      this.b.Visible = true;
      this.b.Enabled = true;
      this.dtpContractStartDate.Enabled = false;
    }

    private void cboPaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPaymentType));
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b?.Text, "Create Contract", false) == 0)
      {
        this.b.Visible = false;
        this.grpAdditionalDetails.Visible = false;
      }
      if (integer == 3 | integer == 0)
        this.grpDD.Visible = false;
      else
        this.grpDD.Visible = true;
    }

    private void btnAdditionalOK_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPeriod)) > 1.0 & (this.chkGasSupplyPipework.Checked | this.chkPlumbingDrainage.Checked | this.chkWindowLockPest.Checked))
      {
        int num = (int) App.ShowMessage("Additional Options can Not be added to a plan which runs for more than one year.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        this.grpPromo.Visible = true;
        this.DoTotals();
      }
    }

    private void btnMinusMain_Click(object sender, EventArgs e)
    {
      if (this.DgMain.CurrentRow == null)
        return;
      this.MainDataView.AllowDelete = true;
      this.MainDataView.Table.Rows.RemoveAt(this.SelectedMainDataRow.Index);
      this.txtMainAppCount.Text = Conversions.ToString(this.DgMain.Rows.Count);
      this.DoTotals();
    }

    private void btnMinusSecond_Click(object sender, EventArgs e)
    {
      if (this.dgSecondAssets.CurrentRow == null)
        return;
      this.SecondAppliances.AllowDelete = true;
      this.SecondAppliances.Table.Rows.RemoveAt(this.SelectedSecondAppDataRow.Index);
      this.txtSecondryCount.Text = Conversions.ToString(this.dgSecondAssets.Rows.Count);
      this.DoTotals();
    }

    private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPeriod)) > 0.0)
      {
        if (this.b != null)
          this.b.Enabled = true;
        this.DoTotals();
      }
      else if (this.b != null)
        this.b.Enabled = false;
    }

    private void cboPromotion_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPromotion)) > 0.0)
      {
        this.discount = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPromotion))).PercentageRate;
      }
      else
      {
        ComboBox cboPromotion = this.cboPromotion;
        Combo.SetSelectedComboItem_By_Value(ref cboPromotion, "0");
        this.cboPromotion = cboPromotion;
        this.discount = 0.0;
      }
      this.DoTotals();
    }

    private void cboContract_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboContract), "0", false) > 0U)
      {
        this.CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContract).Split('`')[0]));
        this.CurrentContractSite = App.DB.ContractOriginalSite.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContract).Split('`')[1]));
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Amend Contract", false) == 0)
        {
          this.lblContractStartDate.Text = "Change Effective from";
          ComboBox cboPeriod = this.cboPeriod;
          Combo.SetSelectedComboItem_By_Value(ref cboPeriod, "1");
          this.cboPeriod = cboPeriod;
          this.cboPeriod.Enabled = false;
          this.btnPeriodOK.Enabled = true;
        }
        else
        {
          this.lblContractStartDate.Text = "Starting From";
          this.lblPeriod.Visible = true;
          this.cboPeriod.Visible = true;
        }
        this.grpContractPeriod.Visible = true;
        this.grpContractPeriod.Enabled = true;
        this.PayerDrop();
        this.lblcancel.Visible = false;
        this.lblCancelReason.Visible = false;
        this.dtpCancelledDate.Visible = false;
        this.cboReasonID.Visible = false;
        this.MainDataView = App.DB.ContractOriginal.GetAssetsForContract(0, true);
        this.SecondAppliances = App.DB.ContractOriginal.GetAssetsForContract(0, false);
        this.SetupMainDataGrid();
        this.SetupSecondryDataGrid();
        this.Populate(0);
        this.btnTypeOk.Visible = true;
        this.cboContractType.Enabled = true;
        this.BtnCancel.Visible = true;
        if (Conversions.ToInteger(App.DB.ExecuteScalar("Select Count(*) FROM tblContractRenewals WHERE OldContractID = " + Conversions.ToString(this.CurrentContract.ContractID), true, false)) > 0)
        {
          this.btnTransfer.Visible = true;
          this.btnRenew.Visible = false;
          this.lblRenewed.Visible = true;
        }
        else
        {
          this.btnTransfer.Visible = true;
          this.btnRenew.Visible = true;
          this.lblRenewed.Visible = false;
        }
      }
      else
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Amend Contract", false) != 0)
          return;
        this.btnTypeOk.Visible = false;
        this.cboContractType.Enabled = false;
      }
    }

    private void btnRenew_Click(object sender, EventArgs e)
    {
      this.c = this.ParentForm.Controls.Find("btnSave", true);
      this.b = (Button) this.c[0];
      this.b.Text = "Renew Contract";
      this.b.Enabled = false;
      this.btnRenew.BackColor = Color.Blue;
      this.grpAppliancesCovered.Enabled = true;
      this.grpContractPeriod.Enabled = true;
      this.grpAppliancesCovered.Visible = true;
      this.grpAdditionalOptions.Visible = true;
      this.grpPromo.Enabled = true;
      this.grpPayers.Visible = true;
      this.cboPaymentType.Enabled = true;
      this.DoTotals();
      this.dtpContractStartDate.Value = this.CurrentContract.ContractEndDate.AddDays(1.0);
      this.grpAdditionalDetails.Visible = false;
      this.btnPaymentOK.ForeColor = Color.OrangeRed;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.CurrentContract.ContractType, "68032", false) != 0)
        return;
      this.CurrentContract.SetContractType = (object) Enums.ContractTypes.PlatinumStar;
      ComboBox cboContractType = this.cboContractType;
      Combo.SetSelectedComboItem_By_Value(ref cboContractType, Conversions.ToString(369));
      this.cboContractType = cboContractType;
      if (this.Number != null)
        App.DB.Job.DeleteReservedOrderNumber(this.Number.JobNumber, this.Number.Prefix);
      this.Number = App.DB.Job.GetNextJobNumber((Enums.JobDefinition) 369);
      this.lblContractRef.Text = this.Number.JobNumber.ToString().Length >= 3 ? (this.Number.JobNumber.ToString().Length >= 4 ? this.Number.Prefix + Conversions.ToString(this.Number.JobNumber) : this.Number.Prefix + "0" + Conversions.ToString(this.Number.JobNumber)) : this.Number.Prefix + "00" + Conversions.ToString(this.Number.JobNumber);
      this.CurrentContract.SetContractReference = (object) this.lblContractRef.Text;
      this.DoTotals();
    }

    private void cboSoldBy_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.cboSoldBy.Visible || App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Invoicing))
        return;
      int num = (int) App.ShowMessage("You can not authorise discounts on this plan", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      this.cboSoldBy.SelectedValue = (object) App.loggedInUser.UserID;
    }

    private void chkWindowLockPest_CheckedChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPeriod)) > 1.0 & (this.chkGasSupplyPipework.Checked | this.chkPlumbingDrainage.Checked | this.chkWindowLockPest.Checked))
      {
        int num = (int) App.ShowMessage("Additional Options can not be added to a plan which runs for more than one year.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.chkWindowLockPest.Checked = false;
        this.chkPlumbingDrainage.Checked = false;
        this.chkGasSupplyPipework.Checked = false;
      }
      else
        this.DoTotals();
    }

    private void txtMainAppCount_TextChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(this.CBT(this.txtMainAppCount.Text) + this.CBT(this.txtSecondryCount.Text)) > 0.0)
      {
        this.DoTotals();
        if (this.b == null)
          return;
        this.b.Enabled = true;
      }
      else
      {
        this.DoTotals();
        if (this.b != null)
          this.b.Enabled = false;
      }
    }

    void IUserControl.Populate(int ID = 0)
    {
      this.MainDataView = App.DB.ContractOriginal.GetAssetsForContract(this.CurrentContractSite.ContractSiteID, true);
      this.SecondAppliances = App.DB.ContractOriginal.GetAssetsForContract(this.CurrentContractSite.ContractSiteID, false);
      this.txtMainAppCount.Text = Conversions.ToString(this.MainDataView.Table.Rows.Count);
      this.txtSecondryCount.Text = Conversions.ToString(this.SecondAppliances.Table.Rows.Count);
      ComboBox cboContractType = this.cboContractType;
      Combo.SetSelectedComboItem_By_Value(ref cboContractType, Conversions.ToString(this.CurrentContract.ContractTypeID));
      this.cboContractType = cboContractType;
      this.dtpContractStartDate.Value = this.CurrentContract.ContractStartDate;
      int num1 = checked ((int) Math.Round(DateHelper.GetYearsBetween(this.CurrentContract.ContractStartDate, this.CurrentContract.ContractEndDate.AddDays(10.0))));
      if (num1 == 0)
        num1 = 1;
      ComboBox cboPeriod = this.cboPeriod;
      Combo.SetSelectedComboItem_By_Value(ref cboPeriod, Conversions.ToString(num1));
      this.cboPeriod = cboPeriod;
      this.lblTotalEst.Text = this.CurrentContract.ContractPriceAfterVAT <= 0.0 ? Strings.Format((object) (Convert.ToDouble(this.CurrentContract.ContractPrice) * 1.2), "C") : Strings.Format((object) this.CurrentContract.ContractPriceAfterVAT, "C");
      this.previousTotal = Conversions.ToDouble(this.lblTotalEst.Text);
      double num2 = Math.Round(Conversions.ToDouble(this.lblTotalEst.Text) / 12.0, 2);
      this.previousFirst = Conversions.ToDouble(Strings.Format((object) (num2 + (Conversions.ToDouble(this.lblTotalEst.Text) - num2 * 12.0)), "C"));
      this.previousSecond = Conversions.ToDouble(Strings.Format((object) num2, "C"));
      this.txtPONumber.Text = this.CurrentContract.PoNumber;
      ComboBox cboPromotion = this.cboPromotion;
      Combo.SetSelectedComboItem_By_Value(ref cboPromotion, Conversions.ToString(this.CurrentContract.DiscountID));
      this.cboPromotion = cboPromotion;
      this.txtBankName.Text = this.CurrentContract.BankName;
      this.txtAccNumber.Text = this.CurrentContract.AccountNumber;
      this.txtSortCode.Text = this.CurrentContract.SortCode;
      this.chkGasSupplyPipework.Checked = this.CurrentContract.GasSupplyPipework;
      this.chkPlumbingDrainage.Checked = this.CurrentContract.PlumbingDrainage;
      this.chkWindowLockPest.Checked = this.CurrentContract.WindowLockPest;
      this.chkLandlord.Checked = this.CurrentContractSite.LLCertReqd;
      this.chkCommercial.Checked = this.CurrentContractSite.Commercial;
      this.txtNotesToEngineer.Text = this.CurrentContractSite.AdditionalNotes;
      ComboBox cboPayer = this.cboPAyer;
      Combo.SetSelectedComboItem_By_Value(ref cboPayer, Conversions.ToString(this.CurrentContract.InvoiceAddressID) + "`" + Conversions.ToString(this.CurrentContract.InvoiceAddressTypeID));
      this.cboPAyer = cboPayer;
      if (this.CurrentContract.InvoiceFrequencyID == 2)
      {
        ComboBox cboPaymentType = this.cboPaymentType;
        Combo.SetSelectedComboItem_By_Value(ref cboPaymentType, Conversions.ToString(4));
        this.cboPaymentType = cboPaymentType;
      }
      if (this.CurrentContract.InvoiceFrequencyID == 6)
      {
        ComboBox cboPaymentType = this.cboPaymentType;
        Combo.SetSelectedComboItem_By_Value(ref cboPaymentType, Conversions.ToString(3));
        this.cboPaymentType = cboPaymentType;
      }
      if (this.CurrentContract.InvoiceFrequencyID == 9)
      {
        ComboBox cboPaymentType = this.cboPaymentType;
        Combo.SetSelectedComboItem_By_Value(ref cboPaymentType, Conversions.ToString(5));
        this.cboPaymentType = cboPaymentType;
      }
      DataTable dataTable = App.DB.ExecuteWithReturn("Select  SC, AC, InitialPaymentType,FirstAmount,SecondPayment,AccName FROM tblContractP where ContractSiteID = " + Conversions.ToString(this.CurrentContractSite.ContractSiteID), true);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtMainAppCount.Text, "0", false) == 0)
        this.txtMainAppCount.Text = Conversions.ToString(this.CurrentContractSite.MainAppliances);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtSecondryCount.Text, "0", false) == 0)
        this.txtSecondryCount.Text = Conversions.ToString(this.CurrentContractSite.SecondryAppliances);
      Simple3Des simple3Des = new Simple3Des(this.p);
      if (dataTable.Rows.Count > 0)
      {
        try
        {
          this.ddsort = simple3Des.DecryptData(Conversions.ToString(dataTable.Rows[0]["sc"]));
          this.ddAcc = simple3Des.DecryptData(Conversions.ToString(dataTable.Rows[0]["Ac"]));
        }
        catch (CryptographicException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          int num3 = (int) Interaction.MsgBox((object) "The Account data could not be decrypted", MsgBoxStyle.OkOnly, (object) null);
          ProjectData.ClearProjectError();
        }
        ComboBox initialPaymentType = this.cboInitialPaymentType;
        Combo.SetSelectedComboItem_By_Description(ref initialPaymentType, dataTable.Rows[0]["InitialPaymentType"].ToString());
        this.cboInitialPaymentType = initialPaymentType;
        this.txtSortCode.Text = this.ddsort;
        this.txtAccNumber.Text = this.ddAcc;
        this.txtAccName.Text = Conversions.ToString(dataTable.Rows[0]["AccName"]);
        this.lblFollowedBy.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SecondPayment"]), "C");
      }
      if (this.CurrentContract.ContractStatusID == 5)
      {
        this.dtpCancelledDate.Value = this.CurrentContract.CancelledDate;
        this.dtpCancelledDate.Visible = true;
        this.cboReasonID.Visible = true;
        ComboBox cboReasonId = this.cboReasonID;
        Combo.SetSelectedComboItem_By_Value(ref cboReasonId, Conversions.ToString(this.CurrentContract.ReasonID));
        this.cboReasonID = cboReasonId;
      }
      else
      {
        this.dtpCancelledDate.Visible = false;
        this.cboReasonID.Visible = false;
      }
      this.PreviousRef = this.CurrentContract.ContractReference;
      this.lblContractRef.Text = this.CurrentContract.ContractReference;
    }

    public int workingdays(DateTime Startdate, DateTime EndDate)
    {
      int num1 = 0;
      int days = (EndDate - Startdate).Days;
      DataView all = App.DB.TimeSlotRates.BankHolidays_GetAll();
      int num2 = days;
      int num3 = 0;
      while (num3 <= num2)
      {
        DayOfWeek dayOfWeek = Startdate.AddDays((double) num3).DayOfWeek;
        if (all.Table.Select("BankHolidayDate='" + Conversions.ToString(Conversions.ToDate(Strings.Format((object) Startdate.AddDays((double) num3), "dd/MM/yyyy"))) + "'").Length <= 0 && (dayOfWeek != DayOfWeek.Saturday && (uint) dayOfWeek > 0U))
          checked { ++num1; }
        checked { ++num3; }
      }
      return num1;
    }

    public DateTime ProcessingDateSub()
    {
      DateTime contractStartDate = this.CurrentContract.ContractStartDate;
      DateTime dateTime1;
      DateTime dateTime2;
      if (this.workingdays(DateAndTime.Today.AddDays(1.0), new DateTime(DateAndTime.Year(contractStartDate), DateAndTime.Month(contractStartDate), contractStartDate.Day)) < 11)
      {
        dateTime1 = new DateTime(DateAndTime.Today.Year, DateAndTime.Today.Month, 1);
        dateTime2 = dateTime1.AddMonths(2);
      }
      else
      {
        dateTime1 = new DateTime(contractStartDate.Year, contractStartDate.Month, 1);
        dateTime2 = dateTime1.AddMonths(1);
      }
      DataView all = App.DB.TimeSlotRates.BankHolidays_GetAll();
      int num1 = 0;
      int num2 = 0;
      while (num2 < 11)
      {
        dateTime1 = dateTime2.AddDays((double) checked (-num1));
        DayOfWeek dayOfWeek = dateTime1.DayOfWeek;
        if (all.Table.Select("BankHolidayDate='" + Conversions.ToString(Conversions.ToDate(Strings.Format((object) dateTime2.AddDays((double) checked (-num1)), "dd/MM/yyyy"))) + "'").Length <= 0 && (dayOfWeek != DayOfWeek.Saturday && (uint) dayOfWeek > 0U))
          checked { ++num2; }
        checked { --num1; }
      }
      return dateTime2.AddDays((double) num1);
    }

    public void SetContract()
    {
      try
      {
        int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPaymentType));
        this.CurrentContract.SetContractReference = (object) this.lblContractRef.Text;
        this.CurrentContract.SetContractStatusID = Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboReasonID)) <= 0.0 ? (object) 3 : (object) 5;
        this.CurrentContract.SetContractPrice = (object) (this.Price / (1.0 + App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(this.CurrentContract.ContractStartDate)).VATRate / 100.0));
        this.CurrentContract.SetContractPriceAfterVAT = (object) this.Price;
        this.CurrentContract.FirstInvoiceDate = this.CurrentContract.ContractStartDate;
        switch (integer)
        {
          case 3:
            this.CurrentContract.SetDirectDebit = (object) false;
            this.CurrentContract.SetAnnual = (object) true;
            this.CurrentContract.SetInvoiceFrequencyID = (object) 6;
            break;
          case 5:
            this.CurrentContract.SetDirectDebit = (object) true;
            this.CurrentContract.SetAnnual = (object) true;
            this.CurrentContract.SetInvoiceFrequencyID = (object) 9;
            break;
          default:
            this.CurrentContract.SetDirectDebit = (object) true;
            this.CurrentContract.SetAnnual = (object) false;
            this.CurrentContract.SetInvoiceFrequencyID = (object) 2;
            break;
        }
        this.CurrentContract.SetContractTypeID = (object) Combo.get_GetSelectedItemValue(this.cboContractType);
        this.CurrentContract.SetDiscountID = (object) Combo.get_GetSelectedItemValue(this.cboPromotion);
        this.CurrentContract.SetBankName = (object) this.txtBankName.Text;
        this.CurrentContract.SetPoNumber = (object) this.txtPONumber.Text;
        this.CurrentContract.SetGasSupplyPipework = (object) this.chkGasSupplyPipework.Checked;
        this.CurrentContract.SetPlumbingDrainage = (object) this.chkPlumbingDrainage.Checked;
        this.CurrentContract.SetWindowLockPest = (object) this.chkWindowLockPest.Checked;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboPAyer), "0", false) > 0U)
        {
          this.CurrentContract.SetInvoiceAddressID = (object) Combo.get_GetSelectedItemValue(this.cboPAyer).Split('`')[0];
          this.CurrentContract.SetInvoiceAddressTypeID = (object) Combo.get_GetSelectedItemValue(this.cboPAyer).Split('`')[1];
        }
        this.CurrentContract.SetCustomerID = (object) this.IDToLinkTo;
        new ContractOriginalValidator().Validate(this.CurrentContract);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public void SetContractSite()
    {
      try
      {
        this.CurrentContractSite.IgnoreExceptionsOnSetMethods = true;
        this.CurrentContractSite.SetPropertyID = (object) this.SiteID;
        this.CurrentContractSite.SetContractID = (object) this.CurrentContract.ContractID;
        this.CurrentContractSite.SetPricePerVisit = (object) 25;
        this.NextVisit();
        this.CurrentContractSite.FirstVisitDate = this.newdate;
        this.CurrentContractSite.SetVisitFrequencyID = (object) 7;
        this.CurrentContractSite.SetVisitDuration = (object) (Conversions.ToDouble(this.CBT(this.txtMainAppCount.Text)) * 50.0 + Conversions.ToDouble(this.CBT(this.txtSecondryCount.Text)) * 30.0);
        this.CurrentContractSite.SetAverageMileage = (object) 0;
        this.CurrentContractSite.SetIncludeAssetPrice = (object) false;
        this.CurrentContractSite.SetIncludeMileagePrice = (object) false;
        this.CurrentContractSite.SetTotalSitePrice = (object) 100;
        this.CurrentContractSite.SetPricePerMile = (object) 0;
        this.CurrentContractSite.SetIncludeRates = (object) true;
        this.CurrentContractSite.SetLLCertReqd = (object) this.chkLandlord.Checked;
        this.CurrentContractSite.SetAdditionalNotes = (object) this.txtNotesToEngineer.Text;
        this.CurrentContractSite.SetCommercial = (object) this.chkCommercial.Checked;
        this.CurrentContractSite.SetMainAppliances = (object) this.CBT(this.txtMainAppCount.Text);
        this.CurrentContractSite.SetSecondryAppliances = (object) this.CBT(this.txtSecondryCount.Text);
        new ContractOriginalSiteValidator().Validate(this.CurrentContractSite, this.CurrentContract);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public void SetContractSiteAsset()
    {
      try
      {
        App.DB.ContractOriginalSiteAsset.Delete(this.CurrentContractSite.ContractSiteID);
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.MainDataView.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            App.DB.ContractOriginalSiteAsset.Insert(new ContractOriginalSiteAsset()
            {
              SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"]),
              SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
              SetPricePerVisit = (object) 25,
              SetType = (object) current["Product"].ToString().Split('-')[0].Trim(' '),
              SetPrimaryAsset = (object) true,
              SetProduct = RuntimeHelpers.GetObjectValue(current["Product"])
            });
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
          enumerator2 = this.SecondAppliances.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            App.DB.ContractOriginalSiteAsset.Insert(new ContractOriginalSiteAsset()
            {
              SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"]),
              SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
              SetPricePerVisit = (object) 25,
              SetPrimaryAsset = (object) false,
              SetType = (object) current["Product"].ToString().Split('-')[0].Trim(' '),
              SetProduct = RuntimeHelpers.GetObjectValue(current["Product"])
            });
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        if (Conversions.ToDouble(this.CBT(this.txtMainAppCount.Text)) > 0.0)
          App.DB.ContractOriginalSiteRates.Insert(new ContractOriginalSiteRates()
          {
            SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
            SetQty = (object) this.CBT(this.txtMainAppCount.Text),
            SetRateID = (object) 244
          });
        if (Conversions.ToDouble(this.CBT(this.txtSecondryCount.Text)) <= 0.0)
          return;
        App.DB.ContractOriginalSiteRates.Insert(new ContractOriginalSiteRates()
        {
          SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
          SetQty = (object) this.CBT(this.txtSecondryCount.Text),
          SetRateID = (object) 245
        });
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public bool Save()
    {
      bool flag;
      if (Conversions.ToDouble(this.CBT(this.txtMainAppCount.Text)) > 0.0 | Conversions.ToDouble(this.CBT(this.txtSecondryCount.Text)) > 0.0)
      {
        try
        {
          this.Cursor = Cursors.WaitCursor;
          this.CurrentContract.IgnoreExceptionsOnSetMethods = true;
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPeriod)) == 0.0)
          {
            int num = (int) App.ShowMessage("Period missing! Please correct!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            flag = false;
            goto label_111;
          }
          else
          {
            int num1 = checked ((int) Math.Round(unchecked (12.0 * Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPeriod)))));
            this.Price = Conversions.ToDouble(this.lblTotalEst.Text);
            double num2 = 0.0;
            int integer1 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPaymentType));
            Simple3Des simple3Des1 = new Simple3Des(this.p);
            string str1 = simple3Des1.EncryptData(this.txtSortCode.Text.Replace("-", ""));
            Simple3Des simple3Des2 = new Simple3Des(this.p);
            string str2 = simple3Des1.EncryptData(this.txtAccNumber.Text);
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Create Contract", false) == 0)
            {
              if (App.ShowMessage("Are you sure you want to save?\r\nInformation cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
              {
                this.CurrentContract.ContractStartDate = this.dtpContractStartDate.Value;
                this.CurrentContract.ContractEndDate = this.dtpContractStartDate.Value.AddYears(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPeriod))).AddDays(-1.0);
                this.SetContract();
                this.CurrentContract = App.DB.ContractOriginal.Insert(this.CurrentContract);
                this.NumberUsed = true;
                this.InsertInvoiceToBeRaiseLines(false, false);
                this.SetContractSite();
                this.CurrentContractSite = App.DB.ContractOriginalSite.Insert(this.CurrentContractSite);
                double num3;
                int num4;
                if (integer1 == 3 || integer1 == 5)
                {
                  num3 = Helper.MakeDoubleValid((object) this.lblTotalEst.Text);
                  num4 = 0;
                }
                else
                {
                  num3 = Helper.MakeDoubleValid((object) this.lblMonthlyEst.Text);
                  num2 = Helper.MakeDoubleValid((object) this.lblFollowedBy.Text);
                  num4 = checked (num1 - 1);
                }
                App.DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type,ManualApp) VALUES (" + Conversions.ToString(this.CurrentContractSite.ContractSiteID) + ",'" + str1 + "','" + str2 + "',17," + Conversions.ToString(num3) + ",'" + Strings.Format((object) this.ProcessingDateSub(), "yyyy-MM-dd") + "',0," + Conversions.ToString(num2) + " ," + Conversions.ToString(num4) + ",'" + Combo.get_GetSelectedItemDescription(this.cboInitialPaymentType) + "','" + this.txtAccName.Text.Replace("'", "") + "'," + Conversions.ToString(Conversions.ToInteger(this.cboSoldBy.SelectedValue)) + ",'NEW','" + this.ManualApp + "')", true, false);
                this.SetContractSiteAsset();
                this.ScheduleJob();
                this.NumberUsed = true;
                // ISSUE: reference to a compiler-generated field
                IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
                if (stateChangedEvent != null)
                  stateChangedEvent(this.CurrentContract.ContractID);
                this.b.Enabled = false;
                int num5 = (int) App.ShowMessage("Contract " + this.lblContractRef.Text + " has been created.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                flag = true;
                goto label_111;
              }
              else
                goto label_111;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Amend Contract", false) == 0)
            {
              if (App.ShowMessage("Are you sure you want to save?\r\nInformation cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
              {
                bool contractChanged = false;
                int integer2 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractType));
                if (this.CurrentContract.ContractTypeID != integer2)
                {
                  switch (integer2)
                  {
                    case 367:
                      contractChanged = this.ChangeContract(false, integer2);
                      break;
                    case 368:
                      contractChanged = this.ChangeContract(this.CurrentContract.ContractTypeID > 368, integer2);
                      break;
                    case 369:
                      contractChanged = this.ChangeContract(this.CurrentContract.ContractTypeID > 369, integer2);
                      break;
                    case 68032:
                      contractChanged = this.ChangeContract(true, integer2);
                      break;
                    case 68294:
                      contractChanged = this.ChangeContract(this.CurrentContract.ContractTypeID != 68032, integer2);
                      break;
                  }
                }
                DataTable table = App.DB.ContractOriginal.Get_NotProcessed(this.CurrentContract.ContractID).Table;
                if (table.Rows.Count > 0 && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(table.Rows[0]["InvoiceToBeRaisedID"], (object) 0, false))
                  checked { --num1; }
                string Left = "AMEND";
                if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtAccNumber.Text, this.ddAcc, false) > 0U | contractChanged & integer2 == 68294)
                {
                  Left = "AMENDD";
                  this.CurrentContract.FirstInvoiceDate = DateAndTime.Today;
                }
                else
                {
                  ContractOriginal currentContract = this.CurrentContract;
                  DateTime dateTime1 = DateAndTime.Today;
                  int year = dateTime1.Year;
                  dateTime1 = DateAndTime.Today;
                  int month = dateTime1.Month;
                  dateTime1 = new DateTime(year, month, 1);
                  DateTime dateTime2 = dateTime1.AddMonths(1);
                  currentContract.FirstInvoiceDate = dateTime2;
                  this.Offset = false;
                }
                int num3 = 0;
                if (this.CurrentContract.InvoiceFrequencyID == 2 | this.CurrentContract.InvoiceFrequencyID == 9)
                {
                  App.DB.ExecuteScalar("DELETE FROM tblInvoiceToBeRaised WHERE InvoiceToBeRaisedID IN ( Select tblInvoiceToBeRaised.InvoiceToBeRaisedID FROM tblInvoiceToBeRaised  LEFT JOIN tblInvoicedLines ON tblInvoicedLines.InvoiceToBeRaisedID = tblInvoiceToBeRaised.InvoiceToBeRaisedID WHERE tblInvoicedLines.InvoicedLineID is null AND LinkID = " + Conversions.ToString(this.CurrentContract.ContractID) + " AND InvoiceTypeID = 327 and tblInvoiceToBeRaised.RaiseDate > GETDATE())", true, false);
                  this.EffDate = DateAndTime.Today;
                  if (!contractChanged || integer2 != 68294)
                    num3 = this.InsertInvoiceToBeRaiseLines(true, contractChanged);
                }
                App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(this.CurrentContract.ContractStartDate));
                if (contractChanged)
                  this.CurrentContract.SetDDMSRef = (object) this.PreviousRef;
                this.SetContract();
                this.SetContractSiteAsset();
                this.SetContractSite();
                if (this.CurrentContract.Exists)
                {
                  if (contractChanged)
                  {
                    new ContractOriginalValidator().Validate(this.CurrentContract);
                    App.DB.ContractOriginal.Insert(this.CurrentContract);
                    this.CurrentContractSite.SetContractID = (object) this.CurrentContract.ContractID;
                    App.DB.ContractOriginalSite.Insert(this.CurrentContractSite);
                    this.SetContractSiteAsset();
                    num3 = this.InsertInvoiceToBeRaiseLines(true, contractChanged);
                    App.DB.ContractOriginal.Insert_UpgradedFrom(this.CurrentContract.ContractID, this.PreviousRef);
                  }
                  else
                  {
                    this.CurrentContract.SetReasonID = (object) Combo.get_GetSelectedItemValue(this.cboReasonID);
                    this.CurrentContract.CancelledDate = this.dtpCancelledDate.Value;
                    new ContractOriginalValidator().Validate(this.CurrentContract);
                    App.DB.ContractOriginal.Update(this.CurrentContract);
                    App.DB.ContractOriginalSite.Update(this.CurrentContractSite);
                  }
                  this.NumberUsed = true;
                }
                else
                {
                  this.CurrentContract.SetCustomerID = (object) this.IDToLinkTo;
                  new ContractOriginalValidator().Validate(this.CurrentContract);
                  this.CurrentContract = App.DB.ContractOriginal.Insert(this.CurrentContract);
                  this.NumberUsed = true;
                }
                double num4;
                if (integer1 == 3 || integer1 == 5)
                {
                  num4 = Helper.MakeDoubleValid((object) this.lblTotalEst.Text);
                  num1 = 0;
                }
                else
                {
                  num4 = Helper.MakeDoubleValid((object) this.lblMonthlyEst.Text);
                  num2 = Helper.MakeDoubleValid((object) this.lblFollowedBy.Text);
                  if (contractChanged & this.CurrentContract.ContractTypeID == 68294)
                    num1 = 1;
                }
                if (Conversions.ToInteger(App.DB.ExecuteScalar("Select Count(*) from tblcontractp where Processed = 0 AND Installments > 0 AND contractsiteID = " + Conversions.ToString(this.CurrentContractSite.ContractSiteID), true, false)) > 0)
                {
                  App.DB.ExecuteScalar("Delete from tblcontractp where Processed = 0 AND Installments > 0 AND contractsiteID = " + Conversions.ToString(this.CurrentContractSite.ContractSiteID), true, false);
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "AMEND", false) == 0)
                    Left = "NEW";
                  App.DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type,ManualApp,SecondApp) VALUES (" + Conversions.ToString(this.CurrentContractSite.ContractSiteID) + ",'" + str1 + "','" + str2 + "',17," + Conversions.ToString(num4) + ",'" + Strings.Format((object) this.ProcessingDateSub(), "yyyy-MM-dd") + "',0," + Conversions.ToString(num2) + " ," + Conversions.ToString(num1) + ",'" + Combo.get_GetSelectedItemDescription(this.cboInitialPaymentType) + "','" + this.txtAccName.Text + "'," + Conversions.ToString(App.loggedInUser.UserID) + ",'" + Left + "','" + this.ManualApp + "','" + this.SecondApp + "')", true, false);
                }
                else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "AMENDD", false) == 0)
                {
                  App.DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type,ManualApp,SecondApp) VALUES (" + Conversions.ToString(this.CurrentContractSite.ContractSiteID) + ",'" + str1 + "','" + str2 + "',17," + Conversions.ToString(num2) + ",'" + Strings.Format((object) this.ProcessingDateSub(), "yyyy-MM-dd") + "',0," + Conversions.ToString(num2) + " ," + Conversions.ToString(num3) + ",'" + Combo.get_GetSelectedItemDescription(this.cboInitialPaymentType) + "','" + this.txtAccName.Text + "'," + Conversions.ToString(App.loggedInUser.UserID) + ",'" + Left + "','" + this.ManualApp + "','" + this.SecondApp + "')", true, false);
                  Emails emails = new Emails();
                  emails.From = EmailAddress.FSM;
                  emails.To = EmailAddress.Coverplan;
                  emails.Subject = "A DDMS Record Requires Manually Changing";
                  string str3 = this.CurrentContract.DDMSRef.Length <= 0 ? this.CurrentContract.ContractReference : this.CurrentContract.DDMSRef;
                  emails.Body = "Please amend record " + str3 + ", a new direct debit instruction will be added to DDMS tonight But the existing dd instructions should be removed or cancelled.";
                  emails.SendMe = true;
                  emails.Send();
                }
                else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "AMEND", false) == 0)
                {
                  DataTable dataTable = App.DB.ExecuteWithReturn("SELECT DirectDebitID, ManualApp, SecondApp, FirstAmount, SecondPayment, Installments FROM tblContractP WHERE ContractSiteID = " + Conversions.ToString(this.CurrentContractSite.ContractSiteID), true);
                  IEnumerator enumerator;
                  try
                  {
                    enumerator = dataTable.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                      DataRow current = (DataRow) enumerator.Current;
                      if (!string.IsNullOrEmpty(this.ManualApp) && (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["ManualApp"])), this.ManualApp, false) > 0U)
                        App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("UPDATE tblContractP SET ManualApp = '" + this.ManualApp + "' WHERE DirectDebitID = "), current["DirectDebitID"])), true, false);
                      if (!string.IsNullOrEmpty(this.SecondApp) && (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["SecondApp"])), this.SecondApp, false) > 0U)
                        App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("UPDATE tblContractP SET SecondApp = '" + this.SecondApp + "' WHERE DirectDebitID = "), current["DirectDebitID"])), true, false);
                      if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["FirstAmount"])) != num4 | Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["FirstAmount"])) != num2)
                        App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("UPDATE tblContractP SET FirstAmount = " + Conversions.ToString(num4) + " WHERE DirectDebitID = "), current["DirectDebitID"])), true, false);
                      if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["SecondPayment"])) != num2)
                        App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("UPDATE tblContractP SET SecondPayment = " + Conversions.ToString(num2) + " WHERE DirectDebitID = "), current["DirectDebitID"])), true, false);
                      if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Installments"])) != num3)
                        App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("UPDATE tblContractP SET Installments = " + Conversions.ToString(num3) + " WHERE DirectDebitID = "), current["DirectDebitID"])), true, false);
                    }
                  }
                  finally
                  {
                    if (enumerator is IDisposable)
                      (enumerator as IDisposable).Dispose();
                  }
                }
                this.NumberUsed = true;
                // ISSUE: reference to a compiler-generated field
                IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
                if (stateChangedEvent != null)
                  stateChangedEvent(this.CurrentContract.ContractID);
                this.b.Enabled = false;
                int num5 = (int) App.ShowMessage("Contract " + this.lblContractRef.Text + " has been Amended.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (contractChanged && this.CurrentContract.ContractTypeID == 68294)
                  this.ScheduleJob();
                flag = true;
                goto label_111;
              }
              else
                goto label_111;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Transfer Contract", false) == 0)
            {
              if (App.ShowMessage("Are you sure you want to save?\r\nInformation cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
              {
                this.SetContract();
                this.CurrentContractSite.SetPropertyID = (object) this.NewSiteID;
                if (this.NewPayer.Length > 1)
                {
                  this.OldEndDate = this.CurrentContract.ContractEndDate;
                  this.CurrentContract.ContractEndDate = this.EffDate.AddDays(-1.0);
                  this.CurrentContract.SetReasonID = (object) 67883;
                  App.DB.ContractOriginal.Update(this.CurrentContract);
                  this.CurrentContract.SetInvoiceAddressID = (object) this.NewPayer.Split('`')[0];
                  this.CurrentContract.SetInvoiceAddressTypeID = (object) this.NewPayer.Split('`')[1];
                  this.CurrentContract.SetReasonID = (object) 0;
                  this.CurrentContract.ContractEndDate = this.OldEndDate;
                  if (DateTime.Compare(this.EffDate, this.OldEndDate) <= 0)
                  {
                    if (DateTime.Compare(this.EffDate, this.CurrentContract.ContractStartDate) >= 0)
                      this.CurrentContract.ContractStartDate = this.EffDate;
                    this.CurrentContract.SetPreviousInvoiceFrequencyID = (object) this.CurrentContract.InvoiceFrequencyID;
                    this.CurrentContract.SetContractStatusID = Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboReasonID)) <= 0.0 ? (object) 3 : (object) 5;
                    this.CurrentContract.SetContractPrice = (object) (this.Price / (1.0 + App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(this.CurrentContract.ContractStartDate)).VATRate / 100.0));
                    this.CurrentContract.SetContractPriceAfterVAT = (object) this.Price;
                    ContractOriginalValidator originalValidator = new ContractOriginalValidator();
                    this.newdate = Conversions.ToDate(App.DB.ContractOriginal.Transfer(this.CurrentContract.ContractID, this.CurrentContractSite.ContractSiteID, this.EffDate));
                    int contractId = this.CurrentContract.ContractID;
                    this.CurrentContract = App.DB.ContractOriginal.Insert(this.CurrentContract);
                    this.NumberUsed = true;
                    App.DB.ExecuteScalar("UPDATE tblContractOriginal SET MigratedToContractID = " + Conversions.ToString(this.CurrentContract.ContractID) + " WHERE ContractID = " + Conversions.ToString(contractId), true, false);
                    this.CurrentContractSite.SetContractID = (object) this.CurrentContract.ContractID;
                    if (DateTime.Compare(this.newdate, DateTime.MinValue) != 0)
                      this.CurrentContractSite.FirstVisitDate = this.newdate;
                    string Left = "TRANS";
                    if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtAccNumber.Text, this.ddAcc, false) > 0U)
                    {
                      Left = "TRANSD";
                      this.CurrentContract.FirstInvoiceDate = this.EffDate;
                    }
                    else
                    {
                      ContractOriginal currentContract = this.CurrentContract;
                      int year = this.CurrentContract.ContractStartDate.Year;
                      DateTime dateTime1 = this.CurrentContract.ContractStartDate;
                      int month = dateTime1.Month;
                      dateTime1 = new DateTime(year, month, 1);
                      DateTime dateTime2 = dateTime1.AddMonths(1);
                      currentContract.FirstInvoiceDate = dateTime2;
                      this.Offset = false;
                    }
                    if (this.CurrentContract.InvoiceFrequencyID == 2 | this.CurrentContract.InvoiceFrequencyID == 9)
                      this.InsertInvoiceToBeRaiseLines(true, false);
                    this.CurrentContractSite.IgnoreExceptionsOnSetMethods = true;
                    this.CurrentContractSite.SetLLCertReqd = (object) this.chkLandlord.Checked;
                    this.CurrentContractSite.SetAdditionalNotes = (object) this.txtNotesToEngineer.Text;
                    this.CurrentContractSite.SetCommercial = (object) this.chkCommercial.Checked;
                    ContractOriginalSiteValidator originalSiteValidator = new ContractOriginalSiteValidator();
                    App.DB.ExecuteScalar("DELETE tblcontractp where Processed = 0 AND Installments > 0 AND contractsiteID = " + Conversions.ToString(this.CurrentContractSite.ContractSiteID) ?? "", true, false);
                    double num3;
                    if (integer1 == 3 || integer1 == 5)
                    {
                      num3 = Helper.MakeDoubleValid((object) this.lblTotalEst.Text);
                    }
                    else
                    {
                      num3 = Helper.MakeDoubleValid((object) this.lblMonthlyEst.Text);
                      num2 = Helper.MakeDoubleValid((object) this.lblFollowedBy.Text);
                    }
                    this.CurrentContractSite = App.DB.ContractOriginalSite.Insert(this.CurrentContractSite);
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "TRANSD", false) == 0)
                      App.DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type) VALUES (" + Conversions.ToString(this.CurrentContractSite.ContractSiteID) + ",'" + str1 + "','" + str2 + "',17," + Conversions.ToString(num3) + ",'" + Strings.Format((object) this.ProcessingDateSub(), "yyyy-MM-dd") + "',0," + Conversions.ToString(num2) + " ," + Conversions.ToString(num1) + ",'" + Combo.get_GetSelectedItemDescription(this.cboInitialPaymentType) + "','" + this.txtAccName.Text + "'," + Conversions.ToString(App.loggedInUser.UserID) + ",'" + Left + "')", true, false);
                    if (DateTime.Compare(this.newdate, DateTime.MinValue) != 0)
                      this.ScheduleJob();
                    this.NumberUsed = true;
                    // ISSUE: reference to a compiler-generated field
                    IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
                    if (stateChangedEvent != null)
                      stateChangedEvent(this.CurrentContract.ContractID);
                    this.b.Enabled = false;
                    int num4 = (int) App.ShowMessage("Contract " + this.lblContractRef.Text + " has been Transfered.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    flag = true;
                    goto label_111;
                  }
                  else
                    goto label_111;
                }
                else
                  goto label_111;
              }
              else
                goto label_111;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Renew Contract", false) == 0)
            {
              if (App.ShowMessage("Are you sure you want to save?\r\nInformation cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
              {
                this.SetContract();
                string str3 = Conversions.ToString(this.CurrentContract.ContractID);
                this.CurrentContract.SetContractReference = (object) this.lblContractRef.Text;
                this.CurrentContract.ContractStartDate = this.CurrentContract.ContractEndDate.AddDays(1.0);
                this.CurrentContract.ContractEndDate = this.CurrentContract.ContractStartDate.AddYears(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPeriod))).AddDays(-1.0);
                this.CurrentContract.SetDiscountID = (object) Combo.get_GetSelectedItemValue(this.cboPromotion);
                this.CurrentContract.SetPreviousInvoiceFrequencyID = (object) this.CurrentContract.InvoiceFrequencyID;
                this.CurrentContract.SetContractStatusID = Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboReasonID)) <= 0.0 ? (object) 3 : (object) 5;
                this.CurrentContract.SetContractPrice = (object) (this.Price / (1.0 + App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(this.CurrentContract.ContractStartDate)).VATRate / 100.0));
                this.CurrentContract.SetContractPriceAfterVAT = (object) this.Price;
                string str4 = "RENEWAL";
                if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtAccNumber.Text, this.ddAcc, false) > 0U)
                {
                  str4 = "RENEWALD";
                  this.CurrentContract.FirstInvoiceDate = this.CurrentContract.ContractStartDate;
                }
                else if (integer1 == 3)
                {
                  this.CurrentContract.FirstInvoiceDate = this.CurrentContract.ContractStartDate;
                }
                else
                {
                  this.Offset = false;
                  this.CurrentContract.FirstInvoiceDate = new DateTime(this.CurrentContract.ContractStartDate.Year, this.CurrentContract.ContractStartDate.Month, 1);
                  this.Offset = false;
                }
                this.CurrentContract.SetCustomerID = (object) this.IDToLinkTo;
                this.CurrentContract = App.DB.ContractOriginal.Insert(this.CurrentContract);
                this.NumberUsed = true;
                this.InsertInvoiceToBeRaiseLines(false, false);
                this.SetContractSite();
                this.CurrentContractSite.FirstVisitDate = this.newdate;
                this.CurrentContractSite = App.DB.ContractOriginalSite.Insert(this.CurrentContractSite);
                string str5 = integer1 != 3 ? "RENEWAL" : Combo.get_GetSelectedItemDescription(this.cboInitialPaymentType);
                double num3;
                if (integer1 == 3 || integer1 == 5)
                {
                  num3 = Helper.MakeDoubleValid((object) this.lblTotalEst.Text);
                  num1 = 0;
                }
                else
                {
                  num3 = Helper.MakeDoubleValid((object) this.lblMonthlyEst.Text);
                  num2 = Helper.MakeDoubleValid((object) this.lblFollowedBy.Text);
                }
                App.DB.ExecuteScalar("INSERT INTO tblContractP(ContractSiteID, Sc, Ac, TransactionType, FirstAmount, DDProcessingDate, Processed, SecondPayment, Installments, InitialPaymentType, AccName, UserID, Type) VALUES (" + Conversions.ToString(this.CurrentContractSite.ContractSiteID) + ",'" + str1 + "','" + str2 + "', 17," + Conversions.ToString(num3) + ",'" + Strings.Format((object) this.ProcessingDateSub(), "yyyy-MM-dd") + "',0," + Conversions.ToString(num2) + " ," + Conversions.ToString(num1) + ",'" + str5 + "','" + this.txtAccName.Text + "'," + Conversions.ToString(App.loggedInUser.UserID) + ",'" + str4 + "')", true, false);
                this.SetContractSiteAsset();
                this.ScheduleJob();
                this.NumberUsed = true;
                App.DB.ContractManager.ContractRenewalsInsert(Conversions.ToInteger(str3), this.CurrentContract.ContractID, 1);
                // ISSUE: reference to a compiler-generated field
                IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
                if (stateChangedEvent != null)
                  stateChangedEvent(this.CurrentContract.ContractID);
                this.b.Enabled = false;
                int num4 = (int) App.ShowMessage("Contract " + this.lblContractRef.Text + " has been Renewed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                flag = true;
                goto label_111;
              }
              else
                goto label_111;
            }
          }
        }
        catch (ValidationException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          flag = false;
          ProjectData.ClearProjectError();
          goto label_111;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          flag = false;
          ProjectData.ClearProjectError();
          goto label_111;
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
label_111:
      return flag;
    }

    public bool ChangeContract(bool upgrade, int contractypeId)
    {
      string name1 = App.DB.Picklists.Get_One_As_Object(this.CurrentContract.ContractTypeID).Name;
      string name2 = App.DB.Picklists.Get_One_As_Object(contractypeId).Name;
      string str = !upgrade ? "Downgrade" : "Upgrade";
      if (App.ShowMessage(str + " contract, Contract - " + this.CurrentContract.ContractReference + " will be " + str.ToLower() + "d from " + name1 + " to " + name2, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
        return false;
      FRMContractUpgradeDowngrade upgradeDowngrade = new FRMContractUpgradeDowngrade();
      int num = (int) upgradeDowngrade.ShowDialog();
      if (upgradeDowngrade.DialogResult != DialogResult.OK)
        return false;
      this.EffDate = upgradeDowngrade.EffDate;
      if (DateTime.Compare(this.EffDate.Date, this.CurrentContract.ContractStartDate.Date) <= 0)
        throw new Exception("Effective date less than contract start date");
      this.OldEndDate = this.CurrentContract.ContractEndDate;
      this.CurrentContract.ContractEndDate = this.EffDate.AddDays(-1.0);
      this.CurrentContract.SetReasonID = !upgrade ? (object) 70996 : (object) 70995;
      this.CurrentContract.SetDoNotRenew = (object) true;
      new ContractOriginalValidator().Validate(this.CurrentContract);
      App.DB.ContractOriginal.Update(this.CurrentContract);
      this.CurrentContract.SetDoNotRenew = (object) false;
      this.CurrentContract.ContractStartDate = this.EffDate;
      if (contractypeId == 68294)
      {
        this.CurrentContract.ContractEndDate = this.EffDate.AddYears(1).AddDays(-1.0);
        this.CurrentContract.FirstInvoiceDate = DateAndTime.Today;
      }
      else
        this.CurrentContract.ContractEndDate = this.OldEndDate;
      return true;
    }

    private void NextVisit()
    {
      Random random = new Random();
      object Instance = RuntimeHelpers.GetObjectValue(App.DB.ExecuteScalar("select MAX(Startdatetime) from tblEngineerVisit ev inner join tblJobOfWork jow on jow.JobOfWorkID = ev.JobOfWorkID inner join tblJob j on j.JobID = jow.JobID where j.JobTypeID in (4702,519) and OutcomeEnumID in (1) and SiteID = " + Conversions.ToString(this.SiteID), true, false));
      DateTime dateTime;
      DateTime t2;
      if (DateAndTime.DateDiff(DateInterval.Day, this.CurrentContract.ContractStartDate, this.CurrentContract.ContractEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) > 366L)
      {
        dateTime = this.CurrentContract.ContractStartDate;
        t2 = dateTime.AddYears(1);
      }
      else
        t2 = this.CurrentContract.ContractEndDate;
      if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(Instance)))
      {
        dateTime = DateAndTime.Today;
        dateTime = dateTime.AddYears(-1);
        Instance = (object) new DateTime(dateTime.Year, 6, 15);
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
        {
          (object) 1
        }, (string[]) null, (System.Type[]) null, (bool[]) null), (object) this.CurrentContract.ContractStartDate, false))
        {
          dateTime = this.CurrentContract.ContractStartDate;
          if (dateTime.DayOfYear < 91)
          {
            dateTime = this.CurrentContract.ContractStartDate;
            dateTime = new DateTime(dateTime.Year, 1, 1);
            this.newdate = dateTime.AddDays((double) checked (91 + random.Next(0, 30)));
          }
          else if (t2.DayOfYear > 275)
          {
            dateTime = new DateTime(t2.Year, 1, 1);
            this.newdate = dateTime.AddDays((double) checked (275 - random.Next(0, 30)));
          }
          else
          {
            dateTime = this.CurrentContract.ContractStartDate;
            this.newdate = dateTime.AddDays((double) checked (5 + random.Next(0, 20)));
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
        {
          (object) 1
        }, (string[]) null, (System.Type[]) null, (bool[]) null), (object) t2, false))
        {
          if (t2.DayOfYear > 275)
          {
            dateTime = new DateTime(t2.Year, 1, 1);
            this.newdate = dateTime.AddDays((double) checked (275 - random.Next(0, 30)));
          }
          else
          {
            dateTime = new DateTime(t2.Year, 1, 1);
            this.newdate = dateTime.AddDays((double) checked (-random.Next(0, 10)));
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
        {
          (object) 1
        }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "DayOfYear", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) 91, false))
        {
          dateTime = new DateTime(Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
          {
            (object) 1
          }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "Year", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null)), 1, 1);
          this.newdate = dateTime.AddDays((double) checked (91 + random.Next(0, 30)));
          if (DateTime.Compare(this.newdate, t2) > 0)
            this.newdate = Conversions.ToDate(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
            {
              (object) 1
            }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "AddDays", new object[1]
            {
              (object) -180
            }, (string[]) null, (System.Type[]) null, (bool[]) null));
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
        {
          (object) 1
        }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "DayOfYear", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) 275, false))
        {
          dateTime = new DateTime(Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
          {
            (object) 1
          }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "Year", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null)), 1, 1);
          this.newdate = dateTime.AddDays((double) checked (275 - random.Next(0, 30)));
          if (DateTime.Compare(this.newdate, this.CurrentContract.ContractStartDate) < 0)
            this.newdate = Conversions.ToDate(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
            {
              (object) 1
            }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "AddDays", new object[1]
            {
              (object) 180
            }, (string[]) null, (System.Type[]) null, (bool[]) null));
        }
        else
        {
          dateTime = Conversions.ToDate(Instance);
          this.newdate = dateTime.AddYears(1);
        }
      }
      if (this.chkLandlord.Checked)
      {
        dateTime = Conversions.ToDate(Instance);
        this.newdate = dateTime.AddYears(1);
        if (DateTime.Compare(this.newdate, t2) > 0)
          this.newdate = t2.AddDays(-3.0);
        else if (DateTime.Compare(this.newdate, this.CurrentContract.ContractStartDate) < 0)
        {
          dateTime = this.CurrentContract.ContractStartDate;
          this.newdate = dateTime.AddDays(3.0);
        }
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
      {
        (object) 1
      }, (string[]) null, (System.Type[]) null, (bool[]) null), (object) this.CurrentContract.ContractStartDate, false))
      {
        dateTime = this.CurrentContract.ContractStartDate;
        if (dateTime.DayOfYear < 91)
        {
          dateTime = this.CurrentContract.ContractStartDate;
          dateTime = new DateTime(dateTime.Year, 1, 1);
          this.newdate = dateTime.AddDays((double) checked (91 + random.Next(0, 30)));
        }
        else if (t2.DayOfYear > 275)
        {
          dateTime = new DateTime(t2.Year, 1, 1);
          this.newdate = dateTime.AddDays((double) checked (275 - random.Next(0, 30)));
        }
        else
        {
          dateTime = this.CurrentContract.ContractStartDate;
          this.newdate = dateTime.AddDays((double) checked (5 + random.Next(0, 20)));
        }
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
      {
        (object) 1
      }, (string[]) null, (System.Type[]) null, (bool[]) null), (object) t2, false))
      {
        if (t2.DayOfYear > 275)
        {
          dateTime = new DateTime(t2.Year, 1, 1);
          this.newdate = dateTime.AddDays((double) checked (275 - random.Next(0, 30)));
        }
        else
        {
          dateTime = new DateTime(t2.Year, 1, 1);
          this.newdate = dateTime.AddDays((double) checked (-random.Next(0, 10)));
        }
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
      {
        (object) 1
      }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "DayOfYear", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) 91, false))
      {
        dateTime = new DateTime(Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
        {
          (object) 1
        }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "Year", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null)), 1, 1);
        this.newdate = dateTime.AddDays((double) checked (91 + random.Next(0, 30)));
        if (DateTime.Compare(this.newdate, t2) > 0)
          this.newdate = Conversions.ToDate(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
          {
            (object) 1
          }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "AddDays", new object[1]
          {
            (object) -180
          }, (string[]) null, (System.Type[]) null, (bool[]) null));
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
      {
        (object) 1
      }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "DayOfYear", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) 275, false))
      {
        dateTime = new DateTime(Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
        {
          (object) 1
        }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "Year", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null)), 1, 1);
        this.newdate = dateTime.AddDays((double) checked (275 - random.Next(0, 30)));
        if (DateTime.Compare(this.newdate, this.CurrentContract.ContractStartDate) < 0)
          this.newdate = Conversions.ToDate(NewLateBinding.LateGet(NewLateBinding.LateGet(Instance, (System.Type) null, "AddYears", new object[1]
          {
            (object) 1
          }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "AddDays", new object[1]
          {
            (object) 180
          }, (string[]) null, (System.Type[]) null, (bool[]) null));
      }
      else
      {
        dateTime = Conversions.ToDate(Instance);
        dateTime = dateTime.AddYears(1);
        this.newdate = dateTime.AddDays(-1.0);
      }
      DateTime newdate1 = this.newdate;
      dateTime = this.CurrentContract.ContractStartDate;
      DateTime date1 = dateTime.Date;
      int num1 = DateTime.Compare(newdate1, date1) < 0 ? 1 : 0;
      DateTime newdate2 = this.newdate;
      dateTime = this.CurrentContract.ContractEndDate;
      DateTime date2 = dateTime.Date;
      int num2 = DateTime.Compare(newdate2, date2) >= 0 ? 1 : 0;
      if ((num1 | num2) == 0)
        return;
      dateTime = this.CurrentContract.ContractEndDate;
      this.newdate = dateTime.AddMonths(-6);
    }

    private void ScheduleJob()
    {
      try
      {
        DateTime dateZeroTime1 = DateHelper.GetDateZeroTime(this.CurrentContract.ContractStartDate);
        DateTime dateZeroTime2 = DateHelper.GetDateZeroTime(this.CurrentContract.ContractEndDate.AddDays(1.0));
        TimeSpan timeSpan = dateZeroTime2.Subtract(dateZeroTime1);
        int days1 = timeSpan.Days;
        int num1 = checked (Math.Abs(dateZeroTime1.Year - dateZeroTime2.Year) * 12 + Math.Abs(dateZeroTime1.Month - dateZeroTime2.Month));
        timeSpan = dateZeroTime2.Subtract(dateZeroTime1);
        int days2 = timeSpan.Days;
        int num2 = 0;
        int months = 0;
        int num3 = 0;
        switch (this.CurrentContractSite.VisitFrequencyID)
        {
          case 4:
            months = 1;
            break;
          case 5:
            months = 3;
            break;
          case 6:
            months = 6;
            break;
          case 7:
            months = 12;
            break;
          case 8:
            months = 4;
            break;
          case 9:
            num3 = 14;
            break;
        }
        if (num3 == 0)
        {
          num2 = checked ((int) Math.Floor(unchecked ((double) num1 / (double) months)));
          if (num2 == 0)
            num2 = 1;
        }
        else if (num3 > 0)
        {
          num2 = checked ((int) Math.Floor(unchecked ((double) days2 / (double) num3)));
          if (num2 == 0)
            num2 = 1;
        }
        if (DateTime.Compare(this.newdate, DateTime.MinValue) == 0)
          this.NextVisit();
        DateTime sourceDate = Conversions.ToDate(Conversions.ToString(this.newdate.Date) + " 09:00:00");
        string str1 = string.Empty;
        int num4 = 0;
        if (Conversions.ToDouble(this.CBT(this.txtMainAppCount.Text)) > 0.0)
        {
          if (num4 > 0)
            str1 += " And ";
          str1 = Conversions.ToDouble(this.CBT(this.txtMainAppCount.Text)) <= 1.0 ? str1 + "Service Primary Coverplan Appliance" : str1 + this.CBT(this.txtMainAppCount.Text) + " x Service Primary Coverplan Appliances";
          checked { ++num4; }
        }
        if (Conversions.ToDouble(this.CBT(this.txtSecondryCount.Text)) > 0.0)
        {
          if (num4 > 0)
            str1 += " And ";
          str1 = Conversions.ToDouble(this.CBT(this.txtSecondryCount.Text)) <= 1.0 ? str1 + "Service Additional Coverplan Appliance" : str1 + this.CBT(this.txtSecondryCount.Text) + " x Service Additional Coverplan Appliances";
          int num5 = checked (num4 + 1);
        }
        if (this.CurrentContractSite.LLCertReqd)
        {
          if (str1.Length > 0)
            str1 += ". ";
          str1 += "Landlord Certificate Required";
        }
        if (str1.Length > 0)
          str1 += ". ";
        string str2 = str1 + this.CurrentContractSite.AdditionalNotes;
        int num6 = num2;
        int num7 = 1;
        while (num7 <= num6)
        {
          if (DateTime.Compare(DateHelper.GetDateZeroTime(sourceDate), DateHelper.GetDateZeroTime(this.CurrentContract.ContractStartDate)) >= 0 & DateTime.Compare(DateHelper.GetDateZeroTime(sourceDate), DateHelper.GetDateZeroTime(this.CurrentContract.ContractEndDate)) <= 0)
          {
            if (sourceDate.DayOfWeek == DayOfWeek.Saturday)
              sourceDate = sourceDate.AddDays(2.0);
            else if (sourceDate.DayOfWeek == DayOfWeek.Sunday)
              sourceDate = sourceDate.AddDays(1.0);
            Job oJob = new Job();
            oJob.SetPropertyID = (object) this.CurrentContractSite.PropertyID;
            oJob.SetJobDefinitionEnumID = (object) 2;
            oJob.SetJobTypeID = !this.chkCommercial.Checked ? (!this.chkLandlord.Checked ? RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Service'")[0]["ManagerID"]) : RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Service and Certificate'")[0]["ManagerID"])) : RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Commercial'")[0]["ManagerID"]);
            oJob.SetStatusEnumID = (object) 1;
            oJob.SetCreatedByUserID = (object) App.loggedInUser.UserID;
            oJob.SetFOC = (object) true;
            JobNumber jobNumber = new JobNumber();
            JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
            oJob.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
            oJob.SetPONumber = (object) "";
            oJob.SetQuoteID = (object) 0;
            oJob.SetContractID = (object) this.CurrentContract.ContractID;
            if (this.CurrentContract.ContractStatusID == 4)
              oJob.SetDeleted = true;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = this.MainDataView.Table.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current = (DataRow) enumerator1.Current;
                oJob.Assets.Add((object) new JobAsset()
                {
                  SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"])
                });
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
              enumerator2 = this.SecondAppliances.Table.Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current = (DataRow) enumerator2.Current;
                oJob.Assets.Add((object) new JobAsset()
                {
                  SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"])
                });
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            JobOfWork jobOfWork = new JobOfWork();
            jobOfWork.SetPONumber = (object) "";
            jobOfWork.IgnoreExceptionsOnSetMethods = true;
            if (this.CurrentContract.ContractStatusID == 4)
              jobOfWork.SetDeleted = true;
            FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) this.CurrentContractSite.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
            if (Conversions.ToDouble(this.CBT(this.txtMainAppCount.Text)) > 0.0)
            {
              DataTable dataTable = App.DB.CustomerScheduleOfRate.Exists(4700, "Service Primary Coverplan Appliance", "CS1", site.CustomerID);
              int CustomerScheduleOfRateID = 0;
              if (dataTable.Rows.Count > 0)
                CustomerScheduleOfRateID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][0]));
              if (CustomerScheduleOfRateID <= 0)
              {
                CustomerScheduleOfRate oCustomerScheduleOfRate = new CustomerScheduleOfRate()
                {
                  SetCode = (object) "CS1",
                  SetDescription = (object) "Service Primary Coverplan Appliance",
                  SetPrice = (object) 0.0,
                  SetScheduleOfRatesCategoryID = (object) 4700,
                  SetTimeInMins = (object) 50,
                  SetCustomerID = (object) site.CustomerID
                };
                CustomerScheduleOfRateID = App.DB.CustomerScheduleOfRate.Insert(oCustomerScheduleOfRate).CustomerScheduleOfRateID;
                App.DB.CustomerScheduleOfRate.Delete(CustomerScheduleOfRateID);
              }
              jobOfWork.JobItems.Add((object) new JobItem()
              {
                IgnoreExceptionsOnSetMethods = true,
                SetSummary = (object) "Service Primary Coverplan Appliance",
                SetQty = (object) this.txtMainAppCount.Text,
                SetRateID = (object) CustomerScheduleOfRateID,
                SetSystemLinkID = (object) 95
              });
            }
            if (Conversions.ToDouble(this.CBT(this.txtSecondryCount.Text)) > 0.0)
            {
              DataTable dataTable = App.DB.CustomerScheduleOfRate.Exists(4700, "Service Additional Coverplan Appliance", "CS2", site.CustomerID);
              int CustomerScheduleOfRateID = 0;
              if (dataTable.Rows.Count > 0)
                CustomerScheduleOfRateID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][0]));
              if (CustomerScheduleOfRateID <= 0)
              {
                CustomerScheduleOfRate oCustomerScheduleOfRate = new CustomerScheduleOfRate()
                {
                  SetCode = (object) "CS2",
                  SetDescription = (object) "Service Additional Coverplan Appliance",
                  SetPrice = (object) 0.0,
                  SetScheduleOfRatesCategoryID = (object) 4700,
                  SetTimeInMins = (object) 30,
                  SetCustomerID = (object) site.CustomerID
                };
                CustomerScheduleOfRateID = App.DB.CustomerScheduleOfRate.Insert(oCustomerScheduleOfRate).CustomerScheduleOfRateID;
                App.DB.CustomerScheduleOfRate.Delete(CustomerScheduleOfRateID);
              }
              jobOfWork.JobItems.Add((object) new JobItem()
              {
                IgnoreExceptionsOnSetMethods = true,
                SetSummary = (object) "Service Additional Coverplan Appliance",
                SetQty = (object) this.txtSecondryCount.Text,
                SetRateID = (object) CustomerScheduleOfRateID,
                SetSystemLinkID = (object) 95
              });
            }
            if (jobOfWork.JobItems.Count == 0)
              jobOfWork.JobItems.Add((object) new JobItem()
              {
                IgnoreExceptionsOnSetMethods = true,
                SetSummary = (object) str2
              });
            EngineerVisit engineerVisit = new EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.SetEngineerID = (object) 0;
            engineerVisit.SetNotesToEngineer = (object) str2;
            if (this.chkLandlord.Checked)
              engineerVisit.SetNotesToEngineer = (object) ("DUE " + Strings.Format((object) sourceDate, "dd/MM/yyyy") + " " + engineerVisit.NotesToEngineer);
            engineerVisit.SetNotesToEngineer = (object) (engineerVisit.NotesToEngineer + " Covered by " + Combo.get_GetSelectedItemDescription(this.cboContractType));
            engineerVisit.StartDateTime = DateTime.MinValue;
            engineerVisit.EndDateTime = DateTime.MinValue;
            engineerVisit.SetStatusEnumID = (object) 4;
            if (this.CurrentContract.ContractStatusID == 4)
              engineerVisit.SetDeleted = true;
            jobOfWork.EngineerVisits.Add((object) engineerVisit);
            oJob.JobOfWorks.Add((object) jobOfWork);
            Job job = App.DB.Job.Insert(oJob);
            App.DB.ContractOriginalPPMVisit.Insert(new ContractOriginalPPMVisit()
            {
              SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
              EstimatedVisitDate = sourceDate,
              SetJobID = (object) job.JobID
            });
            if (num3 == 0)
              sourceDate = sourceDate.AddMonths(months);
            else if (num3 > 0)
              sourceDate = sourceDate.AddDays((double) num3);
          }
          checked { ++num7; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private int InsertInvoiceToBeRaiseLines(bool part = false, bool contractChanged = false)
    {
      DateTime date1;
      DateTime date2;
      if (!part)
      {
        date1 = Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00");
        date2 = Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractEndDate.AddDays(1.0), "dd/MM/yyyy") + " 00:00:00");
      }
      else
      {
        date1 = Conversions.ToDate(Strings.Format((object) new DateTime(this.EffDate.Year, this.EffDate.Month, 1).AddMonths(1), "dd/MM/yyy") + " 00:00:00");
        date2 = Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractEndDate.AddDays(1.0), "dd/MM/yyyy") + " 00:00:00");
      }
      int days = date2.Subtract(date1).Days;
      int num1 = checked ((int) DateAndTime.DateDiff(DateInterval.Month, date1, date2, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
      int num2 = 0;
      switch (this.CurrentContract.InvoiceFrequencyID)
      {
        case 2:
          num2 = checked ((int) Math.Round(unchecked ((double) num1 / 1.0)));
          break;
        case 3:
          num2 = checked ((int) Math.Round(unchecked ((double) num1 / 3.0)));
          break;
        case 4:
          num2 = checked ((int) Math.Round(unchecked ((double) num1 / 6.0)));
          break;
        case 6:
        case 9:
          num2 = 1;
          break;
        case 8:
          num2 = checked ((int) Math.Round(unchecked ((double) num1 / 4.0)));
          break;
      }
      if (num2 < 1)
        num2 = 1;
      if (((!contractChanged ? 0 : (this.CurrentContract.ContractTypeID == 68294 ? 1 : 0)) | (this.CurrentContract.ContractTypeID == 68698 ? 1 : 0) | (this.CurrentContract.ContractTypeID == 68696 ? 1 : 0)) != 0)
        return 0;
      DateTime dateTime = this.CurrentContract.FirstInvoiceDate;
      int num3 = num2;
      int num4 = 1;
      while (num4 <= num3)
      {
        App.DB.InvoiceToBeRaised.Insert(new InvoiceToBeRaised()
        {
          SetAddressLinkID = (object) this.CurrentContract.InvoiceAddressID,
          SetAddressTypeID = (object) this.CurrentContract.InvoiceAddressTypeID,
          SetInvoiceTypeID = (object) 327,
          SetLinkID = (object) this.CurrentContract.ContractID,
          RaiseDate = dateTime
        });
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPaymentType)) == 4.0 & num4 == 1 & this.Offset)
          dateTime = new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1);
        switch (this.CurrentContract.InvoiceFrequencyID)
        {
          case 2:
            dateTime = dateTime.AddMonths(1);
            break;
          case 3:
            dateTime = dateTime.AddMonths(3);
            break;
          case 4:
            dateTime = dateTime.AddMonths(6);
            break;
          case 6:
          case 9:
            dateTime = dateTime.AddYears(1);
            break;
          case 8:
            dateTime = dateTime.AddMonths(4);
            break;
        }
        checked { ++num4; }
      }
      return num2;
    }

    private void DoTotals()
    {
      double num1 = 0.0;
      double num2 = 1.0;
      double num3 = 1.0;
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPaymentType)) == 4.0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboInitialPaymentType)) == 2.0)
        num2 = 1.0;
      else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPaymentType)) == 3.0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboInitialPaymentType)) == 2.0)
        num3 = 1.0;
      string str = Combo.get_GetSelectedItemDescription(this.cboContractType);
      // ISSUE: reference to a compiler-generated method
      switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(str))
      {
        case 681182856:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Platinum Immediate", false) == 0)
          {
            double num4 = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Immediate", Enums.PickListTypes.ContractPricing)) * (double) Conversions.ToInteger(this.CBT(this.txtMainAppCount.Text)) + (double) Conversions.ToInteger(this.CBT(this.txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", Enums.PickListTypes.ContractPricing));
            double num5 = !(this.chkWindowLockPest.Checked & this.chkPlumbingDrainage.Checked & this.chkGasSupplyPipework.Checked) ? num4 - (double) -(this.chkGasSupplyPipework.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkPlumbingDrainage.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkWindowLockPest.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing)) : num4 + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
            double num6 = (num5 - num5 / 100.0 * this.discount) * num3;
            this.lblTotalEst.Text = Strings.Format((object) num6, "C");
            double num7 = Math.Round(num6 / 12.0, 2);
            this.lblMonthlyEst.Text = Strings.Format((object) ((num7 + (num6 - num7 * 12.0)) * num2), "C");
            this.lblFollowedBy.Text = Strings.Format((object) num7, "C");
            goto label_29;
          }
          else
            goto default;
        case 681770764:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Family Free Give Away", false) == 0)
            break;
          goto default;
        case 713018181:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Totally Assured", false) == 0)
          {
            double num4 = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("TA", Enums.PickListTypes.ContractPricing)) * Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPeriod)) + (double) Conversions.ToInteger(this.CBT(this.txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", Enums.PickListTypes.ContractPricing));
            double num5 = !(this.chkWindowLockPest.Checked & this.chkPlumbingDrainage.Checked & this.chkGasSupplyPipework.Checked) ? num4 - (double) -(this.chkGasSupplyPipework.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkPlumbingDrainage.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkWindowLockPest.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing)) : num4 + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
            double num6 = (num5 - num5 / 100.0 * this.discount) * num3;
            this.lblTotalEst.Text = Strings.Format((object) num6, "C");
            double num7 = Math.Round(num6 / (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPeriod)) * 12.0), 2);
            double num8 = num6 - num7 * (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPeriod)) * 12.0);
            this.lblMonthlyEst.Text = Strings.Format((object) ((num7 + num8) * num2), "C");
            this.lblFollowedBy.Text = Strings.Format((object) num7, "C");
            goto label_29;
          }
          else
            goto default;
        case 862025233:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Preventative Maintenance Contract", false) == 0)
            break;
          goto default;
        case 921614270:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Platinum Star Agency", false) == 0)
          {
            double num4 = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Star Agency", Enums.PickListTypes.ContractPricing)) / (1.0 + this.discount / 100.0) * num3;
            this.lblTotalEst.Text = Strings.Format((object) num4, "C");
            double num5 = Math.Round(num4 / 12.0, 2);
            this.lblMonthlyEst.Text = Strings.Format((object) ((num5 + (num4 - num5 * 12.0)) * num2), "C");
            this.lblFollowedBy.Text = Strings.Format((object) num5, "C");
            goto label_29;
          }
          else
            goto default;
        case 2505818397:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Gold Star", false) == 0)
          {
            double num4 = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gold Star", Enums.PickListTypes.ContractPricing)) * (double) Conversions.ToInteger(this.CBT(this.txtMainAppCount.Text)) + (double) Conversions.ToInteger(this.CBT(this.txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance", Enums.PickListTypes.ContractPricing));
            double num5 = !(this.chkWindowLockPest.Checked & this.chkPlumbingDrainage.Checked & this.chkGasSupplyPipework.Checked) ? num4 - (double) -(this.chkGasSupplyPipework.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkPlumbingDrainage.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkWindowLockPest.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing)) : num4 + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
            double num6 = (num5 - num5 / 100.0 * this.discount) * num3;
            this.lblTotalEst.Text = Strings.Format((object) num6, "C");
            double num7 = Math.Round(num6 / 12.0, 2);
            this.lblMonthlyEst.Text = Strings.Format((object) ((num7 + (num6 - num7 * 12.0)) * num2), "C");
            this.lblFollowedBy.Text = Strings.Format((object) num7, "C");
            goto label_29;
          }
          else
            goto default;
        case 2877296480:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Silver Star", false) == 0)
          {
            double num4 = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Silver Star", Enums.PickListTypes.ContractPricing)) * (double) Conversions.ToInteger(this.CBT(this.txtMainAppCount.Text)) + (double) Conversions.ToInteger(this.CBT(this.txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance", Enums.PickListTypes.ContractPricing));
            double num5 = !(this.chkWindowLockPest.Checked & this.chkPlumbingDrainage.Checked & this.chkGasSupplyPipework.Checked) ? num4 - (double) -(this.chkGasSupplyPipework.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkPlumbingDrainage.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkWindowLockPest.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing)) : num4 + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
            double num6 = (num5 - num5 / 100.0 * this.discount) * num3;
            this.lblTotalEst.Text = Strings.Format((object) num6, "C");
            double num7 = Math.Round(num6 / 12.0, 2);
            this.lblMonthlyEst.Text = Strings.Format((object) ((num7 + (num6 - num7 * 12.0)) * num2), "C");
            this.lblFollowedBy.Text = Strings.Format((object) num7, "C");
            goto label_29;
          }
          else
            goto default;
        case 2995039481:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Employee Free", false) == 0)
            break;
          goto default;
        case 3140857416:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Platinum Star System", false) == 0)
          {
            double num4 = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Star System", Enums.PickListTypes.ContractPricing)) * (double) Conversions.ToInteger(this.CBT(this.txtMainAppCount.Text)) + (double) Conversions.ToInteger(this.CBT(this.txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", Enums.PickListTypes.ContractPricing));
            double num5 = !(this.chkWindowLockPest.Checked & this.chkPlumbingDrainage.Checked & this.chkGasSupplyPipework.Checked) ? num4 - (double) -(this.chkGasSupplyPipework.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkPlumbingDrainage.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkWindowLockPest.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing)) : num4 + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
            double num6 = (num5 - num5 / 100.0 * this.discount) * num3;
            this.lblTotalEst.Text = Strings.Format((object) num6, "C");
            double num7 = Math.Round(num6 / 12.0, 2);
            this.lblMonthlyEst.Text = Strings.Format((object) ((num7 + (num6 - num7 * 12.0)) * num2), "C");
            this.lblFollowedBy.Text = Strings.Format((object) num7, "C");
            goto label_29;
          }
          else
            goto default;
        case 3429338259:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Platinum Star", false) == 0)
          {
            double num4 = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Star", Enums.PickListTypes.ContractPricing)) * (double) Conversions.ToInteger(this.CBT(this.txtMainAppCount.Text)) + (double) Conversions.ToInteger(this.CBT(this.txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", Enums.PickListTypes.ContractPricing));
            double num5 = !(this.chkWindowLockPest.Checked & this.chkPlumbingDrainage.Checked & this.chkGasSupplyPipework.Checked) ? num4 - (double) -(this.chkGasSupplyPipework.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkPlumbingDrainage.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing)) - (double) -(this.chkWindowLockPest.Checked ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing)) : num4 + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
            double num6 = (num5 - num5 / 100.0 * this.discount) * num3;
            this.lblTotalEst.Text = Strings.Format((object) num6, "C");
            double num7 = Math.Round(num6 / 12.0, 2);
            this.lblMonthlyEst.Text = Strings.Format((object) ((num7 + (num6 - num7 * 12.0)) * num2), "C");
            this.lblFollowedBy.Text = Strings.Format((object) num7, "C");
            goto label_29;
          }
          else
            goto default;
        case 3790111760:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Gold Star Agency", false) == 0)
          {
            double num4 = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gold Star Agency", Enums.PickListTypes.ContractPricing));
            double num5 = (num4 - num4 / 100.0 * this.discount) * num3;
            this.lblTotalEst.Text = Strings.Format((object) num5, "C");
            double num6 = Math.Round(num5 / 12.0, 2);
            this.lblMonthlyEst.Text = Strings.Format((object) ((num6 + (num5 - num6 * 12.0)) * num2), "C");
            this.lblFollowedBy.Text = Strings.Format((object) num6, "C");
            goto label_29;
          }
          else
            goto default;
        default:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b?.Text, "Renew Contract", false) == 0 & !this.OverridePrice)
          {
            FRMNewPrice frmNewPrice = new FRMNewPrice();
            int num4 = (int) frmNewPrice.ShowDialog();
            if (Versioned.IsNumeric((object) frmNewPrice.txtPrice.Text) && Conversions.ToDouble(frmNewPrice.txtPrice.Text) > 0.0)
            {
              this.lblTotalEst.Text = Strings.Format((object) Conversions.ToDouble(frmNewPrice.txtPrice.Text), "C");
              this.lblMonthlyEst.Text = Strings.Format((object) (Conversions.ToDouble(this.lblTotalEst.Text) / 12.0), "C");
              this.lblFollowedBy.Text = Strings.Format((object) (Conversions.ToDouble(this.lblTotalEst.Text) / 12.0), "C");
              this.OverridePrice = true;
              num1 = Conversions.ToDouble(frmNewPrice.txtPrice.Text);
              this.discount = 0.0;
            }
            goto label_29;
          }
          else
            goto label_29;
      }
      double num9 = 0.0;
      this.discount = 0.0;
      this.lblMonthlyEst.Text = Strings.Format((object) 0, "C");
      this.lblFollowedBy.Text = Strings.Format((object) 0, "C");
      this.lblTotalEst.Text = Strings.Format((object) num9, "C");
label_29:
      if (this.b == null || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.b.Text, "Amend Contract", false) != 0 || (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblMonthlyEst.Text, "", false) <= 0U)
        return;
      double num10 = 0.0;
      DateTime contractStartDate = this.CurrentContract.ContractStartDate;
      DateTime today = DateAndTime.Today;
      int year = today.Year;
      today = DateAndTime.Today;
      int month = today.Month;
      today = DateAndTime.Today;
      int day = today.Day;
      DateTime EndDate = new DateTime(year, month, day).AddMonths(1);
      if (this.workingdays(contractStartDate, EndDate) >= 11)
      {
        double previousSecond = this.previousSecond;
        num10 = Conversions.ToDouble(this.lblFollowedBy.Text);
        double num4 = Conversions.ToDouble(this.lblTotalEst.Text) / 12.0 * (double) DateAndTime.DateDiff(DateInterval.Month, DateAndTime.Today, this.CurrentContract.ContractEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
        Decimal num5 = new Decimal(Math.Round(num4 - previousSecond, 2));
        if (num4 != previousSecond * (double) DateAndTime.DateDiff(DateInterval.Month, DateAndTime.Today, this.CurrentContract.ContractEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))
        {
          double num6 = Math.Round(num4 / (double) DateAndTime.DateDiff(DateInterval.Month, DateAndTime.Today, this.CurrentContract.ContractEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1), 2);
          double num7 = num4 - num6 * (double) DateAndTime.DateDiff(DateInterval.Month, DateAndTime.Today, this.CurrentContract.ContractEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
          this.lblMonthlyEst.Text = Strings.Format((object) ((num6 + num7) * num2), "C");
          this.lblFollowedBy.Text = Strings.Format((object) num6, "C");
        }
      }
    }

    public string CBT(string s)
    {
      s = !Versioned.IsNumeric((object) s) ? "0" : s;
      return s;
    }

    public void ContractDrop()
    {
      DataTable table = App.DB.ContractOriginal.GetAll_ForSite_Active(this.SiteID).Table;
      this.cboContract.Items.Clear();
      IEnumerator enumerator;
      try
      {
        enumerator = table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          this.cboContract.Items.Add((object) new Combo(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["ContractReference"], (object) " : "), current["ContractStartDate"]), (object) " to "), current["ContractEndDate"])), Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["ContractID"], (object) "`"), current["ContractSiteID"])), (object) null));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.cboContract.Items.Add((object) new Combo("-- Please Select --", Conversions.ToString(0), (object) null));
      this.cboContract.DisplayMember = "Description";
      this.cboContract.ValueMember = "Value";
      ComboBox cboContract = this.cboContract;
      Combo.SetSelectedComboItem_By_Value(ref cboContract, "0");
      this.cboContract = cboContract;
    }

    public void CloseForm()
    {
      if (this.Number != null & !this.NumberUsed)
        App.DB.Job.DeleteReservedOrderNumber(this.Number.JobNumber, this.Number.Prefix);
      this.Dispose();
    }

    public void PayerDrop()
    {
      DataTable table = App.DB.InvoiceAddress.InvoiceAddress_Get_SiteID(this.SiteID).Table;
      this.cboPAyer.Items.Clear();
      IEnumerator enumerator;
      try
      {
        enumerator = table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          this.cboPAyer.Items.Add((object) new Combo(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["Address1"], (object) ","), current["Address2"]), (object) ","), current["Postcode"])), Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["AddressID"], (object) "`"), current["AddressTypeID"])), (object) null));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.cboPAyer.Items.Add((object) new Combo("-- Please Select --", Conversions.ToString(0), (object) null));
      this.cboPAyer.DisplayMember = "Description";
      this.cboPAyer.ValueMember = "Value";
      ComboBox cboPayer = this.cboPAyer;
      Combo.SetSelectedComboItem_By_Value(ref cboPayer, "0");
      this.cboPAyer = cboPayer;
    }

    public void ProcessContracts()
    {
      if (this.CurrentContract != null && this.CurrentContract.ContractID > 0)
      {
        DataTable dt = App.DB.ContractOriginal.ProcessContract(this.CurrentContract.ContractID);
        if (dt == null)
          return;
        try
        {
          ArrayList arrayList1 = new Printing((object) new ArrayList(), "ContractBatch", Enums.SystemDocumentType.ContractBatch, true, 0, true, 13, 0, DateTime.MinValue, dt).MultiEmail();
          ArrayList arrayList2;
          object[] objArray;
          bool[] flagArray;
          NewLateBinding.LateCall((object) null, typeof (Process), "Start", objArray = new object[1]
          {
            (arrayList2 = arrayList1)[0]
          }, (string[]) null, (System.Type[]) null, flagArray = new bool[1]
          {
            true
          }, true);
          if (flagArray[0])
            arrayList2[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray[0]));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
    }

    public void ProcessExpiry()
    {
      bool flag = false;
      if (this.CurrentContract.ContractID > 0)
      {
        try
        {
          DataTable table = App.DB.ContractOriginal.Contract_Get_Renewal(this.CurrentContract.ContractID).Table;
          table.Columns.Add("RenewalPrice");
          if (table.Select("InvoiceFrequencyID = 6").Length > 0)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(table.Rows[0]["ContractTypeID"], (object) Enums.ContractTypes.PreventativeMaintenance, false))
            {
              FRMNewPrice frmNewPrice = new FRMNewPrice();
              int num1 = (int) frmNewPrice.ShowDialog();
              if (Versioned.IsNumeric((object) frmNewPrice.txtPrice.Text) && Conversions.ToDouble(frmNewPrice.txtPrice.Text) > 0.0)
              {
                table.Rows[0]["RenewalPrice"] = (object) Conversions.ToDouble(frmNewPrice.txtPrice.Text);
                this.OverridePrice = true;
              }
              else
              {
                int num2 = (int) App.ShowMessage("Please enter amount without commas or pound sign", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
              }
            }
            else
            {
              double newRateAndRenew = this.CalculateNewRateAndRenew(table.Rows[0]);
              table.Rows[0]["RenewalPrice"] = (object) newRateAndRenew;
            }
            ArrayList arrayList1 = new Printing((object) new ArrayList(), "ContractExpiry", Enums.SystemDocumentType.ContractExpiry, true, 0, true, 13, 0, DateTime.MinValue, table).MultiEmail();
            ArrayList arrayList2;
            object[] objArray;
            bool[] flagArray;
            NewLateBinding.LateCall((object) null, typeof (Process), "Start", objArray = new object[1]
            {
              (arrayList2 = arrayList1)[0]
            }, (string[]) null, (System.Type[]) null, flagArray = new bool[1]
            {
              true
            }, true);
            if (flagArray[0])
              arrayList2[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objArray[0]));
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          flag = true;
          ProjectData.ClearProjectError();
        }
      }
    }

    public double CalculateNewRateAndRenew(DataRow dr)
    {
      Decimal d1 = new Decimal(DateAndTime.DateDiff(DateInterval.Year, Conversions.ToDate(dr["ContractStartDate"]), Conversions.ToDate(dr["ContractEndDate"]).AddDays(10.0), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
      if (Decimal.Compare(d1, Decimal.Zero) == 0)
        d1 = Decimal.One;
      double num1 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(dr["ContractPrice"], (object) d1), (object) 1.2));
      int Main = 0;
      int Add = 0;
      DataTable table = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(Conversions.ToInteger(dr["ContractSiteID"]), Conversions.ToInteger(dr["siteid"])).Table;
      table.Columns.Add("PrimaryAsset");
      if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dr["MainAppliances"])) && Information.IsDBNull(RuntimeHelpers.GetObjectValue(dr["SecondryAppliances"])))
      {
        string Left = "";
        int index1 = 0;
        DataRow[] dataRowArray1 = table.Select("Tick = 1");
        int index2 = 0;
        while (index2 < dataRowArray1.Length)
        {
          DataRow dataRow = dataRowArray1[index2];
          if (((Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Back Boiler", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Warm Air unit", false) == 0 ? 1 : 0)) != 0)
            Left = dataRow["product"].ToString().Split('-')[1].Trim();
          if (((Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Back Boiler", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Oil Boiler", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Air Source Heat Pump", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Cond Boiler", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Cond Boiler Store", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Cond Combi", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Std Eff Boiler", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Std Eff Boiler Store", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Std Eff Combi", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Warn Air Unit", false) == 0 ? 1 : 0)) != 0)
          {
            checked { ++Main; }
            table.Rows[index1]["PrimaryAsset"] = (object) true;
          }
          else
          {
            checked { ++Add; }
            table.Rows[index1]["PrimaryAsset"] = (object) false;
          }
          checked { ++index1; }
          checked { ++index2; }
        }
        DataRow[] dataRowArray2 = table.Select("Tick = 1");
        int index3 = 0;
        while (index3 < dataRowArray2.Length)
        {
          DataRow dataRow = dataRowArray2[index3];
          int num2;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, dataRow["product"].ToString().Split('-')[1].Trim(), false) == 0)
            num2 = (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Gas Fire", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Circulator", false) == 0 ? 1 : 0);
          else
            num2 = 0;
          if (num2 != 0)
          {
            checked { Add += -1; }
            break;
          }
          checked { ++index3; }
        }
      }
      else
      {
        Main = Conversions.ToInteger(dr["MainAppliances"]);
        Add = Conversions.ToInteger(dr["SecondryAppliances"]);
        int num2 = 0;
        int num3 = 0;
        string Left = "";
        int index1 = 0;
        DataRow[] dataRowArray1 = table.Select("Tick = 1");
        int index2 = 0;
        while (index2 < dataRowArray1.Length)
        {
          DataRow dataRow = dataRowArray1[index2];
          if (((Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Back Boiler", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Warm Air unit", false) == 0 ? 1 : 0)) != 0)
            Left = dataRow["product"].ToString().Split('-')[1].Trim();
          if (((Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Back Boiler", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Oil Boiler", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Air Source Heat Pump", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Cond Boiler", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Cond Boiler Store", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Cond Combi", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Std Eff Boiler", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Std Eff Boiler Store", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Std Eff Combi", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Warn Air Unit", false) == 0 ? 1 : 0)) != 0)
          {
            checked { ++num2; }
            table.Rows[index1]["PrimaryAsset"] = (object) true;
          }
          else
          {
            checked { ++num3; }
            table.Rows[index1]["PrimaryAsset"] = (object) false;
          }
          checked { ++index1; }
          checked { ++index2; }
        }
        DataRow[] dataRowArray2 = table.Select("Tick = 1");
        int index3 = 0;
        while (index3 < dataRowArray2.Length)
        {
          DataRow dataRow = dataRowArray2[index3];
          int num4;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, dataRow["product"].ToString().Split('-')[1].Trim(), false) == 0)
            num4 = (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Gas Fire", false) == 0 ? 1 : 0) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataRow["product"].ToString().Split('-')[0].Trim(), "Circulator", false) == 0 ? 1 : 0);
          else
            num4 = 0;
          if (num4 != 0)
          {
            checked { num3 += -1; }
            break;
          }
          checked { ++index3; }
        }
        if (checked (Main + Add) < 1)
        {
          Main = num2;
          Add = num3;
        }
      }
      int DiscountID = 0;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dr["DiscountID"])))
        DiscountID = Conversions.ToInteger(dr["DiscountID"]);
      int Years = checked ((int) DateAndTime.DateDiff(DateInterval.Year, Conversions.ToDate(dr["ContractStartDate"]), Conversions.ToDate(dr["ContractEndDate"]).AddDays(10.0), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
      if (Years == 0)
        Years = 1;
      int ContractTypeID = Conversions.ToInteger(dr["ContractTypeID"]);
      if (ContractTypeID == 68032)
        ContractTypeID = 369;
      double[] numArray = this.Gettotal(ContractTypeID, Main, Add, Conversions.ToBoolean(dr["WindowLockPest"]), Conversions.ToBoolean(dr["PlumbingDrainage"]), Conversions.ToBoolean(dr["GasSupplyPipework"]), DiscountID, Years);
      if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (numArray[0] / num1 > 1.1), Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dr["ContractTypeID"], (object) 68032, false))), Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (numArray[0] / num1 < 0.9), Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dr["ContractTypeID"], (object) 68032, false))))))
        numArray[0] = 0.0;
      return numArray[0];
    }

    public double[] Gettotal(
      int ContractTypeID,
      int Main,
      int Add,
      bool WindowsLocks,
      bool PlumbingDrainage,
      bool GasSupply,
      int DiscountID,
      int Years)
    {
      double[] numArray = new double[3]{ 0.01, 0.01, 0.01 };
      double num1 = 0.0;
      if (!Information.IsDBNull((object) DiscountID) && DiscountID > 0)
        num1 = App.DB.Picklists.Get_One_As_Object(DiscountID).PercentageRate;
      if (Main == 0 & Add > 1)
      {
        Main = 1;
        checked { --Add; }
      }
      if (Main == 0 & Add == 0)
        Main = 1;
      switch (ContractTypeID)
      {
        case 367:
          numArray[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Silver Star", Enums.PickListTypes.ContractPricing));
          numArray[0] = numArray[0] * (double) Main;
          numArray[0] = numArray[0] + (double) Add * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance", Enums.PickListTypes.ContractPricing));
          if (WindowsLocks & PlumbingDrainage & GasSupply)
          {
            numArray[0] = numArray[0] + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
          }
          else
          {
            numArray[0] = numArray[0] - (double) -(GasSupply ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing));
            numArray[0] = numArray[0] - (double) -(PlumbingDrainage ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing));
            numArray[0] = numArray[0] - (double) -(WindowsLocks ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing));
          }
          numArray[0] = numArray[0] - numArray[0] / 100.0 * num1;
          double num2 = Math.Round(numArray[0] / 12.0, 2);
          numArray[1] = Conversions.ToDouble(Strings.Format((object) (num2 + (numArray[0] - num2 * 12.0)), "C"));
          numArray[2] = Conversions.ToDouble(Strings.Format((object) num2, "C"));
          break;
        case 368:
          numArray[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gold Star", Enums.PickListTypes.ContractPricing));
          numArray[0] = numArray[0] * (double) Main;
          numArray[0] = numArray[0] + (double) Add * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance", Enums.PickListTypes.ContractPricing));
          if (WindowsLocks & PlumbingDrainage & GasSupply)
          {
            numArray[0] = numArray[0] + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
          }
          else
          {
            numArray[0] = numArray[0] - (double) -(GasSupply ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing));
            numArray[0] = numArray[0] - (double) -(PlumbingDrainage ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing));
            numArray[0] = numArray[0] - (double) -(WindowsLocks ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing));
          }
          numArray[0] = numArray[0] - numArray[0] / 100.0 * num1;
          double num3 = Math.Round(numArray[0] / 12.0, 2);
          numArray[1] = Conversions.ToDouble(Strings.Format((object) (num3 + (numArray[0] - num3 * 12.0)), "C"));
          numArray[2] = Conversions.ToDouble(Strings.Format((object) num3, "C"));
          break;
        case 369:
          numArray[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Star", Enums.PickListTypes.ContractPricing));
          numArray[0] = numArray[0] * (double) Main;
          numArray[0] = numArray[0] + (double) Add * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", Enums.PickListTypes.ContractPricing));
          if (WindowsLocks & PlumbingDrainage & GasSupply)
          {
            numArray[0] = numArray[0] + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
          }
          else
          {
            numArray[0] = numArray[0] - (double) -(GasSupply ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing));
            numArray[0] = numArray[0] - (double) -(PlumbingDrainage ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing));
            numArray[0] = numArray[0] - (double) -(WindowsLocks ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing));
          }
          numArray[0] = numArray[0] - numArray[0] / 100.0 * num1;
          double num4 = Math.Round(numArray[0] / 12.0, 2);
          numArray[1] = Conversions.ToDouble(Strings.Format((object) (num4 + (numArray[0] - num4 * 12.0)), "C"));
          numArray[2] = Conversions.ToDouble(Strings.Format((object) num4, "C"));
          break;
        case 67247:
          numArray[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gold Star Agency", Enums.PickListTypes.ContractPricing));
          double num5 = Math.Round(numArray[0] / 12.0, 2);
          numArray[1] = Conversions.ToDouble(Strings.Format((object) (num5 + (numArray[0] - num5 * 12.0)), "C"));
          numArray[2] = Conversions.ToDouble(Strings.Format((object) num5, "C"));
          break;
        case 67353:
          numArray[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Star Agency", Enums.PickListTypes.ContractPricing));
          numArray[0] = numArray[0] - numArray[0] / 100.0 * num1;
          double num6 = Math.Round(numArray[0] / 12.0, 2);
          numArray[1] = Conversions.ToDouble(Strings.Format((object) (num6 + (numArray[0] - num6 * 12.0)), "C"));
          numArray[2] = Conversions.ToDouble(Strings.Format((object) num6, "C"));
          break;
        case 68032:
          numArray[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Immediate", Enums.PickListTypes.ContractPricing));
          numArray[0] = numArray[0] * (double) Main;
          numArray[0] = numArray[0] + (double) Add * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", Enums.PickListTypes.ContractPricing));
          if (WindowsLocks & PlumbingDrainage & GasSupply)
          {
            numArray[0] = numArray[0] + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
          }
          else
          {
            numArray[0] = numArray[0] - (double) -(GasSupply ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing));
            numArray[0] = numArray[0] - (double) -(PlumbingDrainage ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing));
            numArray[0] = numArray[0] - (double) -(WindowsLocks ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing));
          }
          numArray[0] = numArray[0] - numArray[0] / 100.0 * num1;
          double num7 = Math.Round(numArray[0] / 12.0, 2);
          numArray[1] = Conversions.ToDouble(Strings.Format((object) (num7 + (numArray[0] - num7 * 12.0)), "C"));
          numArray[2] = Conversions.ToDouble(Strings.Format((object) num7, "C"));
          break;
        case 68294:
          numArray[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("TA", Enums.PickListTypes.ContractPricing)) * (double) Years;
          numArray[0] = numArray[0] - numArray[0] / 100.0 * num1;
          numArray[0] = numArray[0] + (double) Add * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", Enums.PickListTypes.ContractPricing));
          if (WindowsLocks & PlumbingDrainage & GasSupply)
          {
            numArray[0] = numArray[0] + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
          }
          else
          {
            numArray[0] = numArray[0] - (double) -(GasSupply ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", Enums.PickListTypes.ContractPricing));
            numArray[0] = numArray[0] - (double) -(PlumbingDrainage ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", Enums.PickListTypes.ContractPricing));
            numArray[0] = numArray[0] - (double) -(WindowsLocks ? 1 : 0) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", Enums.PickListTypes.ContractPricing));
          }
          double num8 = Math.Round(numArray[0] / (Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("TA", Enums.PickListTypes.ContractPricing)) / 12.0), 2);
          numArray[1] = Conversions.ToDouble(Strings.Format((object) (num8 + (numArray[0] - num8 * (Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("TA", Enums.PickListTypes.ContractPricing)) / 12.0))), "C"));
          numArray[2] = Conversions.ToDouble(Strings.Format((object) num8, "C"));
          break;
      }
      return numArray;
    }

    public void SetUpSoldByCombo()
    {
      this.cboSoldBy.Items.Clear();
      this.cboSoldBy.Items.Add((object) "-- Not Applicable --");
      this.cboSoldBy.DataSource = (object) App.DB.Engineer.User_And_Engineer_GetAll();
      this.cboSoldBy.DisplayMember = "Name";
      this.cboSoldBy.ValueMember = "UID";
      this.cboSoldBy.SelectedIndex = 0;
    }
  }
}
