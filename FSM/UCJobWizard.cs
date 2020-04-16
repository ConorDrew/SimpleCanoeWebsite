// Decompiled with JetBrains decompiler
// Type: FSM.UCJobWizard
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Assets;
using FSM.Entity.ContractsOriginal;
using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.EngineerVisits;
using FSM.Entity.JobAssets;
using FSM.Entity.JobAudits;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using FSM.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCJobWizard : UCBase, IUserControl
  {
    private IContainer components;
    private bool StopSelect;
    private List<string> SkillsList;
    private string PromotionText;
    private double FinalCharge;
    private string FinalText;
    private DataTable PromotionsDT;
    private bool ProgChange;
    private bool TimeReqOption;
    private string BookingDetail;
    private double visitcharge1;
    private string visitterm1;
    private double visitcharge2;
    private string visitterm2;
    private int jobids;
    private int servTime;
    private int visitsBooked;
    private DateTime lastDate;
    private int lastEngineerID;
    private int reqtime;
    private bool Manualrecall;
    private string jobtype;
    private int RecallJobTypeID;
    private int RecallJobID;
    private UCDocumentsList DocumentsControl;
    private UCQuotesList QuotesControl;
    private UCCustomerScheduleOfRate CustomerScheduleOfRateControl;
    private ContractOriginal CurrentContract;
    private DataTable appointments;
    private DataTable Temp;
    private DataTable Schedulerapps;
    private string SpecialTrade;
    private bool LPGNEEDED;
    private bool OILNEEDED;
    private bool NATNEEDED;
    private bool HETASNEEDED;
    private bool ASNEEDED;
    private bool WAUNEEDED;
    private bool COMMNEEDED;
    private DateTime currentFilterDate;
    private int LastsiteID;
    private bool GasConfirmedInBoiler;
    private bool SiteChange;
    private DataTable DTPrivNotes;
    private Job CurrentJob;
    private EngineerVisit currentVisit;
    private List<string> rftBundle;
    private string costCentre;
    private Form _FromForm;
    private DataView _MainDataView;
    private DataView _DGVAdditional;
    private DataView _SORDataView;
    private DataView _SORSymp;
    private List<int> CoverApps;
    private List<int> ChargeApps;
    private DataView _SiteDT;
    private int _SiteID;
    private FSM.Entity.Customers.Customer _theCustomer;
    private int _SelectedCustomerID;
    private int time;
    private int priTime;
    private int secTime;
    private bool FlagShown;
    private FSM.Entity.Sites.Site CurrentSite;
    private FSM.Entity.Customers.Customer CurrentCustomer;
    private bool UseContractVisit;
    private int tab;

    public UCJobWizard()
    {
      this.StopSelect = false;
      this.SkillsList = new List<string>();
      this.PromotionText = "";
      this.FinalCharge = 0.0;
      this.FinalText = "";
      this.TimeReqOption = false;
      this.BookingDetail = "";
      this.servTime = 0;
      this.visitsBooked = 0;
      this.lastDate = DateTime.MinValue;
      this.lastEngineerID = 0;
      this.Manualrecall = false;
      this.jobtype = "";
      this.CurrentContract = (ContractOriginal) null;
      this.appointments = new DataTable();
      this.Temp = new DataTable();
      this.Schedulerapps = new DataTable();
      this.SpecialTrade = "";
      this.LPGNEEDED = false;
      this.OILNEEDED = false;
      this.NATNEEDED = false;
      this.HETASNEEDED = false;
      this.ASNEEDED = false;
      this.WAUNEEDED = false;
      this.COMMNEEDED = false;
      this.GasConfirmedInBoiler = true;
      this.SiteChange = false;
      this.rftBundle = new List<string>();
      this.costCentre = (string) null;
      this._MainDataView = (DataView) null;
      this._DGVAdditional = (DataView) null;
      this._SORDataView = (DataView) null;
      this._SORSymp = (DataView) null;
      this.CoverApps = new List<int>();
      this.ChargeApps = new List<int>();
      this._SelectedCustomerID = 0;
      this.time = 0;
      this.priTime = 0;
      this.secTime = 0;
      this.FlagShown = false;
      this.UseContractVisit = false;
      this.tab = 1;
      this.InitializeComponent();
      try
      {
        this.tcSites.TabPages[0].Enabled = true;
        this.tcSites.TabPages.Remove(this.tabJobType);
        this.tcSites.TabPages.Remove(this.tabJobDetails);
        this.tcSites.TabPages.Remove(this.tabAppliance);
        this.tcSites.TabPages.Remove(this.TabCharging);
        this.tcSites.TabPages.Remove(this.tabAdditional);
        this.tcSites.TabPages.Remove(this.TabBook);
        this.tcSites.TabPages.Remove(this.tcComplete);
        this.tcSites.TabPages.Remove(this.tabExistingJobs);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      ComboBox cboTitle = this.cboTitle;
      Combo.SetUpCombo(ref cboTitle, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboTitle = cboTitle;
      ComboBox c = this.cbotypeWiz;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbotypeWiz = c;
      c = this.cboPayTerms;
      Combo.SetUpCombo(ref c, DynamicDataTables.JobWizTerms, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboPayTerms = c;
      c = this.cboAdditional;
      Combo.SetUpCombo(ref c, DynamicDataTables.JobWizAdditional, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboAdditional = c;
      c = this.cboAppointment;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.CustomerTypes | Enums.PickListTypes.Symptoms, false).Table, "ManagerID", "Name", Enums.ComboValues.All_Appointments);
      this.cboAppointment = c;
      c = this.cboEngineer;
      Combo.SetUpCombo(ref c, App.DB.Engineer.Engineer_GetAll().Table, "EngineerID", "Name", Enums.ComboValues.Not_Applicable);
      this.cboEngineer = c;
      this.btnxxSiteNext.Visible = false;
      this.cbotypeWiz.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.cbotypeWiz.AutoCompleteSource = AutoCompleteSource.ListItems;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabPage tabJobDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabProp { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl tcSites { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSearch
    {
      get
      {
        return this._txtSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtSearch_TextChanged);
        TextBox txtSearch1 = this._txtSearch;
        if (txtSearch1 != null)
          txtSearch1.KeyDown -= keyEventHandler;
        this._txtSearch = value;
        TextBox txtSearch2 = this._txtSearch;
        if (txtSearch2 == null)
          return;
        txtSearch2.KeyDown += keyEventHandler;
      }
    }

    internal virtual DataGridView DGVSites
    {
      get
      {
        return this._DGVSites;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DataGridViewRowPostPaintEventHandler paintEventHandler = new DataGridViewRowPostPaintEventHandler(this.dgvSitesContracrPaint);
        EventHandler eventHandler = (EventHandler) ((a0, a1) => this.DGVSites_CellContentClick());
        DataGridView dgvSites1 = this._DGVSites;
        if (dgvSites1 != null)
        {
          dgvSites1.RowPostPaint -= paintEventHandler;
          dgvSites1.SelectionChanged -= eventHandler;
        }
        this._DGVSites = value;
        DataGridView dgvSites2 = this._DGVSites;
        if (dgvSites2 == null)
          return;
        dgvSites2.RowPostPaint += paintEventHandler;
        dgvSites2.SelectionChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnEditSite
    {
      get
      {
        return this._btnEditSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEditSite_Click);
        Button btnEditSite1 = this._btnEditSite;
        if (btnEditSite1 != null)
          btnEditSite1.Click -= eventHandler;
        this._btnEditSite = value;
        Button btnEditSite2 = this._btnEditSite;
        if (btnEditSite2 == null)
          return;
        btnEditSite2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddSite
    {
      get
      {
        return this._btnAddSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddSite_Click);
        Button btnAddSite1 = this._btnAddSite;
        if (btnAddSite1 != null)
          btnAddSite1.Click -= eventHandler;
        this._btnAddSite = value;
        Button btnAddSite2 = this._btnAddSite;
        if (btnAddSite2 == null)
          return;
        btnAddSite2.Click += eventHandler;
      }
    }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSurname { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFirstName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMob { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnxxSiteNext
    {
      get
      {
        return this._btnxxSiteNext;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSiteNext_Click);
        Button btnxxSiteNext1 = this._btnxxSiteNext;
        if (btnxxSiteNext1 != null)
          btnxxSiteNext1.Click -= eventHandler;
        this._btnxxSiteNext = value;
        Button btnxxSiteNext2 = this._btnxxSiteNext;
        if (btnxxSiteNext2 == null)
          return;
        btnxxSiteNext2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxOther
    {
      get
      {
        return this._btnxxOther;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx_Click);
        Button btnxxOther1 = this._btnxxOther;
        if (btnxxOther1 != null)
          btnxxOther1.Click -= eventHandler;
        this._btnxxOther = value;
        Button btnxxOther2 = this._btnxxOther;
        if (btnxxOther2 == null)
          return;
        btnxxOther2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxBreakdown
    {
      get
      {
        return this._btnxxBreakdown;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx_Click);
        Button btnxxBreakdown1 = this._btnxxBreakdown;
        if (btnxxBreakdown1 != null)
          btnxxBreakdown1.Click -= eventHandler;
        this._btnxxBreakdown = value;
        Button btnxxBreakdown2 = this._btnxxBreakdown;
        if (btnxxBreakdown2 == null)
          return;
        btnxxBreakdown2.Click += eventHandler;
      }
    }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button BtnxxService
    {
      get
      {
        return this._BtnxxService;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx_Click);
        Button btnxxService1 = this._BtnxxService;
        if (btnxxService1 != null)
          btnxxService1.Click -= eventHandler;
        this._BtnxxService = value;
        Button btnxxService2 = this._BtnxxService;
        if (btnxxService2 == null)
          return;
        btnxxService2.Click += eventHandler;
      }
    }

    internal virtual Label lbltype { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbotypeWiz
    {
      get
      {
        return this._cbotypeWiz;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbotypeWiz_SelectedIndexChanged);
        ComboBox cbotypeWiz1 = this._cbotypeWiz;
        if (cbotypeWiz1 != null)
          cbotypeWiz1.SelectedIndexChanged -= eventHandler;
        this._cbotypeWiz = value;
        ComboBox cbotypeWiz2 = this._cbotypeWiz;
        if (cbotypeWiz2 == null)
          return;
        cbotypeWiz2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual DataGridView DgMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cboMainApps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnxxJobNext
    {
      get
      {
        return this._btnxxJobNext;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnJobNext_Click);
        Button btnxxJobNext1 = this._btnxxJobNext;
        if (btnxxJobNext1 != null)
          btnxxJobNext1.Click -= eventHandler;
        this._btnxxJobNext = value;
        Button btnxxJobNext2 = this._btnxxJobNext;
        if (btnxxJobNext2 == null)
          return;
        btnxxJobNext2.Click += eventHandler;
      }
    }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnxxSOR
    {
      get
      {
        return this._btnxxSOR;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx_Click);
        Button btnxxSor1 = this._btnxxSOR;
        if (btnxxSor1 != null)
          btnxxSor1.Click -= eventHandler;
        this._btnxxSOR = value;
        Button btnxxSor2 = this._btnxxSOR;
        if (btnxxSor2 == null)
          return;
        btnxxSor2.Click += eventHandler;
      }
    }

    internal virtual Panel pnlSOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView DGSOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSORQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSORAdd
    {
      get
      {
        return this._btnSORAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSORAdd_Click);
        Button btnSorAdd1 = this._btnSORAdd;
        if (btnSorAdd1 != null)
          btnSorAdd1.Click -= eventHandler;
        this._btnSORAdd = value;
        Button btnSorAdd2 = this._btnSORAdd;
        if (btnSorAdd2 == null)
          return;
        btnSorAdd2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboSOR { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSORMinus
    {
      get
      {
        return this._btnSORMinus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSORMinus_Click);
        Button btnSorMinus1 = this._btnSORMinus;
        if (btnSorMinus1 != null)
          btnSorMinus1.Click -= eventHandler;
        this._btnSORMinus = value;
        Button btnSorMinus2 = this._btnSORMinus;
        if (btnSorMinus2 == null)
          return;
        btnSorMinus2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxApplianceNext
    {
      get
      {
        return this._btnxxApplianceNext;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxxApplianceNext_Click);
        Button btnxxApplianceNext1 = this._btnxxApplianceNext;
        if (btnxxApplianceNext1 != null)
          btnxxApplianceNext1.Click -= eventHandler;
        this._btnxxApplianceNext = value;
        Button btnxxApplianceNext2 = this._btnxxApplianceNext;
        if (btnxxApplianceNext2 == null)
          return;
        btnxxApplianceNext2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxDetailsNext
    {
      get
      {
        return this._btnxxDetailsNext;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxxDetailsNext_Click);
        Button btnxxDetailsNext1 = this._btnxxDetailsNext;
        if (btnxxDetailsNext1 != null)
          btnxxDetailsNext1.Click -= eventHandler;
        this._btnxxDetailsNext = value;
        Button btnxxDetailsNext2 = this._btnxxDetailsNext;
        if (btnxxDetailsNext2 == null)
          return;
        btnxxDetailsNext2.Click += eventHandler;
      }
    }

    internal virtual TabPage TabCharging { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnxxChargeNext
    {
      get
      {
        return this._btnxxChargeNext;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxxChargeNext_Click);
        Button btnxxChargeNext1 = this._btnxxChargeNext;
        if (btnxxChargeNext1 != null)
          btnxxChargeNext1.Click -= eventHandler;
        this._btnxxChargeNext = value;
        Button btnxxChargeNext2 = this._btnxxChargeNext;
        if (btnxxChargeNext2 == null)
          return;
        btnxxChargeNext2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtPayInst { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkRecall
    {
      get
      {
        return this._chkRecall;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkRecall_CheckedChanged);
        CheckBox chkRecall1 = this._chkRecall;
        if (chkRecall1 != null)
          chkRecall1.CheckedChanged -= eventHandler;
        this._chkRecall = value;
        CheckBox chkRecall2 = this._chkRecall;
        if (chkRecall2 == null)
          return;
        chkRecall2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlSymptoms { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSymptom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSymptom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView DGSymptoms { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSymMinus
    {
      get
      {
        return this._btnSymMinus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSymMinus_Click);
        Button btnSymMinus1 = this._btnSymMinus;
        if (btnSymMinus1 != null)
          btnSymMinus1.Click -= eventHandler;
        this._btnSymMinus = value;
        Button btnSymMinus2 = this._btnSymMinus;
        if (btnSymMinus2 == null)
          return;
        btnSymMinus2.Click += eventHandler;
      }
    }

    internal virtual Button btnSymAdd
    {
      get
      {
        return this._btnSymAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSymAdd_Click);
        Button btnSymAdd1 = this._btnSymAdd;
        if (btnSymAdd1 != null)
          btnSymAdd1.Click -= eventHandler;
        this._btnSymAdd = value;
        Button btnSymAdd2 = this._btnSymAdd;
        if (btnSymAdd2 == null)
          return;
        btnSymAdd2.Click += eventHandler;
      }
    }

    internal virtual Label lblPriority { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPriority
    {
      get
      {
        return this._cboPriority;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboPriority_SelectedIndexChanged);
        ComboBox cboPriority1 = this._cboPriority;
        if (cboPriority1 != null)
          cboPriority1.SelectedIndexChanged -= eventHandler;
        this._cboPriority = value;
        ComboBox cboPriority2 = this._cboPriority;
        if (cboPriority2 == null)
          return;
        cboPriority2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TabPage tabAdditional { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnxxAdditionalNext
    {
      get
      {
        return this._btnxxAdditionalNext;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxxAdditionalNext_Click);
        Button btnxxAdditionalNext1 = this._btnxxAdditionalNext;
        if (btnxxAdditionalNext1 != null)
          btnxxAdditionalNext1.Click -= eventHandler;
        this._btnxxAdditionalNext = value;
        Button btnxxAdditionalNext2 = this._btnxxAdditionalNext;
        if (btnxxAdditionalNext2 == null)
          return;
        btnxxAdditionalNext2.Click += eventHandler;
      }
    }

    internal virtual Label Label22 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label21 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAdditional { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView DGAdditional { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAdditionalMinus
    {
      get
      {
        return this._btnAdditionalMinus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdditionalMinus_Click);
        Button btnAdditionalMinus1 = this._btnAdditionalMinus;
        if (btnAdditionalMinus1 != null)
          btnAdditionalMinus1.Click -= eventHandler;
        this._btnAdditionalMinus = value;
        Button btnAdditionalMinus2 = this._btnAdditionalMinus;
        if (btnAdditionalMinus2 == null)
          return;
        btnAdditionalMinus2.Click += eventHandler;
      }
    }

    internal virtual Button btnAdditionalPlus
    {
      get
      {
        return this._btnAdditionalPlus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdditionalPlus_Click);
        Button btnAdditionalPlus1 = this._btnAdditionalPlus;
        if (btnAdditionalPlus1 != null)
          btnAdditionalPlus1.Click -= eventHandler;
        this._btnAdditionalPlus = value;
        Button btnAdditionalPlus2 = this._btnAdditionalPlus;
        if (btnAdditionalPlus2 == null)
          return;
        btnAdditionalPlus2.Click += eventHandler;
      }
    }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPayTerms
    {
      get
      {
        return this._cboPayTerms;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboPayTerms_SelectedIndexChanged);
        ComboBox cboPayTerms1 = this._cboPayTerms;
        if (cboPayTerms1 != null)
          cboPayTerms1.SelectedIndexChanged -= eventHandler;
        this._cboPayTerms = value;
        ComboBox cboPayTerms2 = this._cboPayTerms;
        if (cboPayTerms2 == null)
          return;
        cboPayTerms2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblCoverplanServ { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage TabBook { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBookText { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label23 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFromDate
    {
      get
      {
        return this._dtpFromDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpFromDate_ValueChanged);
        DateTimePicker dtpFromDate1 = this._dtpFromDate;
        if (dtpFromDate1 != null)
          dtpFromDate1.ValueChanged -= eventHandler;
        this._dtpFromDate = value;
        DateTimePicker dtpFromDate2 = this._dtpFromDate;
        if (dtpFromDate2 == null)
          return;
        dtpFromDate2.ValueChanged += eventHandler;
      }
    }

    internal virtual Button btnOption10
    {
      get
      {
        return this._btnOption10;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOption_Click);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.Button_Paint);
        Button btnOption10_1 = this._btnOption10;
        if (btnOption10_1 != null)
        {
          btnOption10_1.Click -= eventHandler;
          btnOption10_1.Paint -= paintEventHandler;
        }
        this._btnOption10 = value;
        Button btnOption10_2 = this._btnOption10;
        if (btnOption10_2 == null)
          return;
        btnOption10_2.Click += eventHandler;
        btnOption10_2.Paint += paintEventHandler;
      }
    }

    internal virtual Button btnOption4
    {
      get
      {
        return this._btnOption4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOption_Click);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.Button_Paint);
        Button btnOption4_1 = this._btnOption4;
        if (btnOption4_1 != null)
        {
          btnOption4_1.Click -= eventHandler;
          btnOption4_1.Paint -= paintEventHandler;
        }
        this._btnOption4 = value;
        Button btnOption4_2 = this._btnOption4;
        if (btnOption4_2 == null)
          return;
        btnOption4_2.Click += eventHandler;
        btnOption4_2.Paint += paintEventHandler;
      }
    }

    internal virtual Button btnOption3
    {
      get
      {
        return this._btnOption3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOption_Click);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.Button_Paint);
        Button btnOption3_1 = this._btnOption3;
        if (btnOption3_1 != null)
        {
          btnOption3_1.Click -= eventHandler;
          btnOption3_1.Paint -= paintEventHandler;
        }
        this._btnOption3 = value;
        Button btnOption3_2 = this._btnOption3;
        if (btnOption3_2 == null)
          return;
        btnOption3_2.Click += eventHandler;
        btnOption3_2.Paint += paintEventHandler;
      }
    }

    internal virtual Button btnOption2
    {
      get
      {
        return this._btnOption2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOption_Click);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.Button_Paint);
        Button btnOption2_1 = this._btnOption2;
        if (btnOption2_1 != null)
        {
          btnOption2_1.Click -= eventHandler;
          btnOption2_1.Paint -= paintEventHandler;
        }
        this._btnOption2 = value;
        Button btnOption2_2 = this._btnOption2;
        if (btnOption2_2 == null)
          return;
        btnOption2_2.Click += eventHandler;
        btnOption2_2.Paint += paintEventHandler;
      }
    }

    internal virtual Button btnOption1
    {
      get
      {
        return this._btnOption1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOption_Click);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.Button_Paint);
        Button btnOption1_1 = this._btnOption1;
        if (btnOption1_1 != null)
        {
          btnOption1_1.Click -= eventHandler;
          btnOption1_1.Paint -= paintEventHandler;
        }
        this._btnOption1 = value;
        Button btnOption1_2 = this._btnOption1;
        if (btnOption1_2 == null)
          return;
        btnOption1_2.Click += eventHandler;
        btnOption1_2.Paint += paintEventHandler;
      }
    }

    internal virtual CheckBox chkKeepTogether
    {
      get
      {
        return this._chkKeepTogether;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkKeepTogether_CheckedChanged);
        CheckBox chkKeepTogether1 = this._chkKeepTogether;
        if (chkKeepTogether1 != null)
          chkKeepTogether1.CheckedChanged -= eventHandler;
        this._chkKeepTogether = value;
        CheckBox chkKeepTogether2 = this._chkKeepTogether;
        if (chkKeepTogether2 == null)
          return;
        chkKeepTogether2.CheckedChanged += eventHandler;
      }
    }

    internal virtual GroupBox gpCombo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlTypeOfWorks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTypeOfWorks
    {
      get
      {
        return this._cboTypeOfWorks;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboTypeOfWorks_SelectedIndexChanged);
        ComboBox cboTypeOfWorks1 = this._cboTypeOfWorks;
        if (cboTypeOfWorks1 != null)
          cboTypeOfWorks1.SelectedIndexChanged -= eventHandler;
        this._cboTypeOfWorks = value;
        ComboBox cboTypeOfWorks2 = this._cboTypeOfWorks;
        if (cboTypeOfWorks2 == null)
          return;
        cboTypeOfWorks2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label25 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnxxFollow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnxx1
    {
      get
      {
        return this._btnxx1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx1_Click);
        Button btnxx1_1 = this._btnxx1;
        if (btnxx1_1 != null)
          btnxx1_1.Click -= eventHandler;
        this._btnxx1 = value;
        Button btnxx1_2 = this._btnxx1;
        if (btnxx1_2 == null)
          return;
        btnxx1_2.Click += eventHandler;
      }
    }

    internal virtual Button btnxx2
    {
      get
      {
        return this._btnxx2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx1_Click);
        Button btnxx2_1 = this._btnxx2;
        if (btnxx2_1 != null)
          btnxx2_1.Click -= eventHandler;
        this._btnxx2 = value;
        Button btnxx2_2 = this._btnxx2;
        if (btnxx2_2 == null)
          return;
        btnxx2_2.Click += eventHandler;
      }
    }

    internal virtual Button btnxx3
    {
      get
      {
        return this._btnxx3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx1_Click);
        Button btnxx3_1 = this._btnxx3;
        if (btnxx3_1 != null)
          btnxx3_1.Click -= eventHandler;
        this._btnxx3 = value;
        Button btnxx3_2 = this._btnxx3;
        if (btnxx3_2 == null)
          return;
        btnxx3_2.Click += eventHandler;
      }
    }

    internal virtual Button btnxx4
    {
      get
      {
        return this._btnxx4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx1_Click);
        Button btnxx4_1 = this._btnxx4;
        if (btnxx4_1 != null)
          btnxx4_1.Click -= eventHandler;
        this._btnxx4 = value;
        Button btnxx4_2 = this._btnxx4;
        if (btnxx4_2 == null)
          return;
        btnxx4_2.Click += eventHandler;
      }
    }

    internal virtual Button btnxx5
    {
      get
      {
        return this._btnxx5;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx1_Click);
        Button btnxx5_1 = this._btnxx5;
        if (btnxx5_1 != null)
          btnxx5_1.Click -= eventHandler;
        this._btnxx5 = value;
        Button btnxx5_2 = this._btnxx5;
        if (btnxx5_2 == null)
          return;
        btnxx5_2.Click += eventHandler;
      }
    }

    internal virtual Button btnxx6
    {
      get
      {
        return this._btnxx6;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx1_Click);
        Button btnxx6_1 = this._btnxx6;
        if (btnxx6_1 != null)
          btnxx6_1.Click -= eventHandler;
        this._btnxx6 = value;
        Button btnxx6_2 = this._btnxx6;
        if (btnxx6_2 == null)
          return;
        btnxx6_2.Click += eventHandler;
      }
    }

    internal virtual Button btnJobHistory
    {
      get
      {
        return this._btnJobHistory;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnJobHistory_Click);
        Button btnJobHistory1 = this._btnJobHistory;
        if (btnJobHistory1 != null)
          btnJobHistory1.Click -= eventHandler;
        this._btnJobHistory = value;
        Button btnJobHistory2 = this._btnJobHistory;
        if (btnJobHistory2 == null)
          return;
        btnJobHistory2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkCert { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcert { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label26 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPONumber
    {
      get
      {
        return this._txtPONumber;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPONumber_TextChanged);
        TextBox txtPoNumber1 = this._txtPONumber;
        if (txtPoNumber1 != null)
          txtPoNumber1.TextChanged -= eventHandler;
        this._txtPONumber = value;
        TextBox txtPoNumber2 = this._txtPONumber;
        if (txtPoNumber2 == null)
          return;
        txtPoNumber2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lblAdditional { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAdditional
    {
      get
      {
        return this._txtAdditional;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtAdditional_TextChanged);
        TextBox txtAdditional1 = this._txtAdditional;
        if (txtAdditional1 != null)
          txtAdditional1.TextChanged -= eventHandler;
        this._txtAdditional = value;
        TextBox txtAdditional2 = this._txtAdditional;
        if (txtAdditional2 == null)
          return;
        txtAdditional2.TextChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboAppointment
    {
      get
      {
        return this._cboAppointment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboAppointment_SelectedIndexChanged_1);
        ComboBox cboAppointment1 = this._cboAppointment;
        if (cboAppointment1 != null)
          cboAppointment1.SelectedIndexChanged -= eventHandler;
        this._cboAppointment = value;
        ComboBox cboAppointment2 = this._cboAppointment;
        if (cboAppointment2 == null)
          return;
        cboAppointment2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEngineer
    {
      get
      {
        return this._cboEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboEngineer_SelectedIndexChanged);
        ComboBox cboEngineer1 = this._cboEngineer;
        if (cboEngineer1 != null)
          cboEngineer1.SelectedIndexChanged -= eventHandler;
        this._cboEngineer = value;
        ComboBox cboEngineer2 = this._cboEngineer;
        if (cboEngineer2 == null)
          return;
        cboEngineer2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TabPage tcComplete { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label27 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRestart
    {
      get
      {
        return this._btnRestart;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button btnRestart1 = this._btnRestart;
        if (btnRestart1 != null)
          btnRestart1.Click -= eventHandler;
        this._btnRestart = value;
        Button btnRestart2 = this._btnRestart;
        if (btnRestart2 == null)
          return;
        btnRestart2.Click += eventHandler;
      }
    }

    internal virtual Label Label28 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContractRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolTip ToolTip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabExistingJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgExistingVisits
    {
      get
      {
        return this._dgExistingVisits;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DataGridViewCellEventHandler cellEventHandler = new DataGridViewCellEventHandler(this.dgExistingVisits_CellClick);
        DataGridView dgExistingVisits1 = this._dgExistingVisits;
        if (dgExistingVisits1 != null)
          dgExistingVisits1.CellClick -= cellEventHandler;
        this._dgExistingVisits = value;
        DataGridView dgExistingVisits2 = this._dgExistingVisits;
        if (dgExistingVisits2 == null)
          return;
        dgExistingVisits2.CellClick += cellEventHandler;
      }
    }

    internal virtual Label Label29 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnxxNewJob
    {
      get
      {
        return this._btnxxNewJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxxNewJob_Click);
        Button btnxxNewJob1 = this._btnxxNewJob;
        if (btnxxNewJob1 != null)
          btnxxNewJob1.Click -= eventHandler;
        this._btnxxNewJob = value;
        Button btnxxNewJob2 = this._btnxxNewJob;
        if (btnxxNewJob2 == null)
          return;
        btnxxNewJob2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxExistingJobBack
    {
      get
      {
        return this._btnxxExistingJobBack;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx1_Click);
        Button btnxxExistingJobBack1 = this._btnxxExistingJobBack;
        if (btnxxExistingJobBack1 != null)
          btnxxExistingJobBack1.Click -= eventHandler;
        this._btnxxExistingJobBack = value;
        Button btnxxExistingJobBack2 = this._btnxxExistingJobBack;
        if (btnxxExistingJobBack2 == null)
          return;
        btnxxExistingJobBack2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxExistingJobNext
    {
      get
      {
        return this._btnxxExistingJobNext;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxxExistingJobNext_Click);
        Button btnxxExistingJobNext1 = this._btnxxExistingJobNext;
        if (btnxxExistingJobNext1 != null)
          btnxxExistingJobNext1.Click -= eventHandler;
        this._btnxxExistingJobNext = value;
        Button btnxxExistingJobNext2 = this._btnxxExistingJobNext;
        if (btnxxExistingJobNext2 == null)
          return;
        btnxxExistingJobNext2.Click += eventHandler;
      }
    }

    internal virtual Label lblUnabletoConfirm { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSiteNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label30 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label31 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBookedInfo
    {
      get
      {
        return this._lblBookedInfo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lblBookedInfo_Click);
        Label lblBookedInfo1 = this._lblBookedInfo;
        if (lblBookedInfo1 != null)
          lblBookedInfo1.Click -= eventHandler;
        this._lblBookedInfo = value;
        Label lblBookedInfo2 = this._lblBookedInfo;
        if (lblBookedInfo2 == null)
          return;
        lblBookedInfo2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxExternalBM
    {
      get
      {
        return this._btnxxExternalBM;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx_Click);
        Button btnxxExternalBm1 = this._btnxxExternalBM;
        if (btnxxExternalBm1 != null)
          btnxxExternalBm1.Click -= eventHandler;
        this._btnxxExternalBM = value;
        Button btnxxExternalBm2 = this._btnxxExternalBM;
        if (btnxxExternalBm2 == null)
          return;
        btnxxExternalBm2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxCarpentry
    {
      get
      {
        return this._btnxxCarpentry;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx_Click);
        Button btnxxCarpentry1 = this._btnxxCarpentry;
        if (btnxxCarpentry1 != null)
          btnxxCarpentry1.Click -= eventHandler;
        this._btnxxCarpentry = value;
        Button btnxxCarpentry2 = this._btnxxCarpentry;
        if (btnxxCarpentry2 == null)
          return;
        btnxxCarpentry2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxPlumbing
    {
      get
      {
        return this._btnxxPlumbing;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx_Click);
        Button btnxxPlumbing1 = this._btnxxPlumbing;
        if (btnxxPlumbing1 != null)
          btnxxPlumbing1.Click -= eventHandler;
        this._btnxxPlumbing = value;
        Button btnxxPlumbing2 = this._btnxxPlumbing;
        if (btnxxPlumbing2 == null)
          return;
        btnxxPlumbing2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxElectrical
    {
      get
      {
        return this._btnxxElectrical;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx_Click);
        Button btnxxElectrical1 = this._btnxxElectrical;
        if (btnxxElectrical1 != null)
          btnxxElectrical1.Click -= eventHandler;
        this._btnxxElectrical = value;
        Button btnxxElectrical2 = this._btnxxElectrical;
        if (btnxxElectrical2 == null)
          return;
        btnxxElectrical2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxMultiTrade
    {
      get
      {
        return this._btnxxMultiTrade;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx_Click);
        Button btnxxMultiTrade1 = this._btnxxMultiTrade;
        if (btnxxMultiTrade1 != null)
          btnxxMultiTrade1.Click -= eventHandler;
        this._btnxxMultiTrade = value;
        Button btnxxMultiTrade2 = this._btnxxMultiTrade;
        if (btnxxMultiTrade2 == null)
          return;
        btnxxMultiTrade2.Click += eventHandler;
      }
    }

    internal virtual Button btnxxKitchens
    {
      get
      {
        return this._btnxxKitchens;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnxx_Click);
        Button btnxxKitchens1 = this._btnxxKitchens;
        if (btnxxKitchens1 != null)
          btnxxKitchens1.Click -= eventHandler;
        this._btnxxKitchens = value;
        Button btnxxKitchens2 = this._btnxxKitchens;
        if (btnxxKitchens2 == null)
          return;
        btnxxKitchens2.Click += eventHandler;
      }
    }

    internal virtual Panel pnlTimeReq { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label34 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHrs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label32 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label33 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDays { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRefresh
    {
      get
      {
        return this._btnRefresh;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button2_Click);
        Button btnRefresh1 = this._btnRefresh;
        if (btnRefresh1 != null)
          btnRefresh1.Click -= eventHandler;
        this._btnRefresh = value;
        Button btnRefresh2 = this._btnRefresh;
        if (btnRefresh2 == null)
          return;
        btnRefresh2.Click += eventHandler;
      }
    }

    internal virtual Button btnOption8
    {
      get
      {
        return this._btnOption8;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOption_Click);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.Button_Paint);
        Button btnOption8_1 = this._btnOption8;
        if (btnOption8_1 != null)
        {
          btnOption8_1.Click -= eventHandler;
          btnOption8_1.Paint -= paintEventHandler;
        }
        this._btnOption8 = value;
        Button btnOption8_2 = this._btnOption8;
        if (btnOption8_2 == null)
          return;
        btnOption8_2.Click += eventHandler;
        btnOption8_2.Paint += paintEventHandler;
      }
    }

    internal virtual Button btnOption7
    {
      get
      {
        return this._btnOption7;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOption_Click);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.Button_Paint);
        Button btnOption7_1 = this._btnOption7;
        if (btnOption7_1 != null)
        {
          btnOption7_1.Click -= eventHandler;
          btnOption7_1.Paint -= paintEventHandler;
        }
        this._btnOption7 = value;
        Button btnOption7_2 = this._btnOption7;
        if (btnOption7_2 == null)
          return;
        btnOption7_2.Click += eventHandler;
        btnOption7_2.Paint += paintEventHandler;
      }
    }

    internal virtual Button btnOption6
    {
      get
      {
        return this._btnOption6;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOption_Click);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.Button_Paint);
        Button btnOption6_1 = this._btnOption6;
        if (btnOption6_1 != null)
        {
          btnOption6_1.Click -= eventHandler;
          btnOption6_1.Paint -= paintEventHandler;
        }
        this._btnOption6 = value;
        Button btnOption6_2 = this._btnOption6;
        if (btnOption6_2 == null)
          return;
        btnOption6_2.Click += eventHandler;
        btnOption6_2.Paint += paintEventHandler;
      }
    }

    internal virtual Button btnOption5
    {
      get
      {
        return this._btnOption5;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOption_Click);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.Button_Paint);
        Button btnOption5_1 = this._btnOption5;
        if (btnOption5_1 != null)
        {
          btnOption5_1.Click -= eventHandler;
          btnOption5_1.Paint -= paintEventHandler;
        }
        this._btnOption5 = value;
        Button btnOption5_2 = this._btnOption5;
        if (btnOption5_2 == null)
          return;
        btnOption5_2.Click += eventHandler;
        btnOption5_2.Paint += paintEventHandler;
      }
    }

    internal virtual Label Label35 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDiscountCode
    {
      get
      {
        return this._txtDiscountCode;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtDiscountCode_TextChanged);
        TextBox txtDiscountCode1 = this._txtDiscountCode;
        if (txtDiscountCode1 != null)
          txtDiscountCode1.TextChanged -= eventHandler;
        this._txtDiscountCode = value;
        TextBox txtDiscountCode2 = this._txtDiscountCode;
        if (txtDiscountCode2 == null)
          return;
        txtDiscountCode2.TextChanged += eventHandler;
      }
    }

    internal virtual PictureBox picTick { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picCross { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDocument
    {
      get
      {
        return this._btnDocument;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click_1);
        Button btnDocument1 = this._btnDocument;
        if (btnDocument1 != null)
          btnDocument1.Click -= eventHandler;
        this._btnDocument = value;
        Button btnDocument2 = this._btnDocument;
        if (btnDocument2 == null)
          return;
        btnDocument2.Click += eventHandler;
      }
    }

    internal virtual Button txtSearchSite
    {
      get
      {
        return this._txtSearchSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtSearchSite_MouseClick);
        Button txtSearchSite1 = this._txtSearchSite;
        if (txtSearchSite1 != null)
          txtSearchSite1.Click -= eventHandler;
        this._txtSearchSite = value;
        Button txtSearchSite2 = this._txtSearchSite;
        if (txtSearchSite2 == null)
          return;
        txtSearchSite2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chbCommercial { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContactAlert { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContactAlert { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDefect { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDefect { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (UCJobWizard));
      this.tabJobDetails = new TabPage();
      this.pnlTimeReq = new Panel();
      this.Label34 = new Label();
      this.txtHrs = new TextBox();
      this.Label32 = new Label();
      this.Label33 = new Label();
      this.txtDays = new TextBox();
      this.Label26 = new Label();
      this.txtPONumber = new TextBox();
      this.lblAdditional = new Label();
      this.txtAdditional = new TextBox();
      this.btnxx2 = new Button();
      this.pnlTypeOfWorks = new Panel();
      this.cboTypeOfWorks = new ComboBox();
      this.Label25 = new Label();
      this.pnlSymptoms = new Panel();
      this.lblSymptom = new Label();
      this.cboSymptom = new ComboBox();
      this.Label15 = new Label();
      this.DGSymptoms = new DataGridView();
      this.btnSymMinus = new Button();
      this.btnSymAdd = new Button();
      this.lblPriority = new Label();
      this.cboPriority = new ComboBox();
      this.Label12 = new Label();
      this.btnxxDetailsNext = new Button();
      this.tabAppliance = new TabPage();
      this.btnxx3 = new Button();
      this.Label20 = new Label();
      this.Label13 = new Label();
      this.DgMain = new DataGridView();
      this.btnMinusMain = new Button();
      this.btnAddMain = new Button();
      this.cboMainApps = new ComboBox();
      this.btnxxApplianceNext = new Button();
      this.tabJobType = new TabPage();
      this.btnxxExternalBM = new Button();
      this.btnxxCarpentry = new Button();
      this.btnxxPlumbing = new Button();
      this.btnxxElectrical = new Button();
      this.btnxxMultiTrade = new Button();
      this.btnxxKitchens = new Button();
      this.btnxx1 = new Button();
      this.pnlSOR = new Panel();
      this.DGSOR = new DataGridView();
      this.btnxxFollow = new Button();
      this.txtSORQty = new TextBox();
      this.Label14 = new Label();
      this.btnSORAdd = new Button();
      this.cboSOR = new ComboBox();
      this.btnSORMinus = new Button();
      this.btnxxSOR = new Button();
      this.lbltype = new Label();
      this.cbotypeWiz = new ComboBox();
      this.btnxxBreakdown = new Button();
      this.Label11 = new Label();
      this.BtnxxService = new Button();
      this.btnxxOther = new Button();
      this.btnxxJobNext = new Button();
      this.tabProp = new TabPage();
      this.lblDefect = new Label();
      this.txtDefect = new TextBox();
      this.chbCommercial = new CheckBox();
      this.lblContactAlert = new Label();
      this.txtContactAlert = new TextBox();
      this.txtSearchSite = new Button();
      this.txtName = new TextBox();
      this.txtSiteNotes = new TextBox();
      this.Label30 = new Label();
      this.Label28 = new Label();
      this.txtContractRef = new TextBox();
      this.btnJobHistory = new Button();
      this.btnxxSiteNext = new Button();
      this.Label10 = new Label();
      this.txtCustomer = new TextBox();
      this.Label9 = new Label();
      this.txtEmail = new TextBox();
      this.Label8 = new Label();
      this.txtTel = new TextBox();
      this.Label6 = new Label();
      this.txtMob = new TextBox();
      this.txtAddress3 = new TextBox();
      this.Label7 = new Label();
      this.Label5 = new Label();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.cboTitle = new ComboBox();
      this.txtAddress1 = new TextBox();
      this.txtAddress2 = new TextBox();
      this.txtPostcode = new TextBox();
      this.txtSurname = new TextBox();
      this.txtFirstName = new TextBox();
      this.btnEditSite = new Button();
      this.btnAddSite = new Button();
      this.Label1 = new Label();
      this.txtSearch = new TextBox();
      this.DGVSites = new DataGridView();
      this.tcSites = new TabControl();
      this.tabExistingJobs = new TabPage();
      this.btnxxExistingJobBack = new Button();
      this.btnxxExistingJobNext = new Button();
      this.dgExistingVisits = new DataGridView();
      this.Label29 = new Label();
      this.btnxxNewJob = new Button();
      this.tabAdditional = new TabPage();
      this.chkCert = new CheckBox();
      this.lblcert = new Label();
      this.btnxx4 = new Button();
      this.lblCoverplanServ = new Label();
      this.Label22 = new Label();
      this.Label21 = new Label();
      this.cboAdditional = new ComboBox();
      this.DGAdditional = new DataGridView();
      this.btnAdditionalMinus = new Button();
      this.btnAdditionalPlus = new Button();
      this.btnxxAdditionalNext = new Button();
      this.TabCharging = new TabPage();
      this.lblUnabletoConfirm = new Label();
      this.btnxx5 = new Button();
      this.Label16 = new Label();
      this.cboPayTerms = new ComboBox();
      this.chkRecall = new CheckBox();
      this.Label19 = new Label();
      this.Label18 = new Label();
      this.pnlCharge = new Panel();
      this.picTick = new PictureBox();
      this.Label35 = new Label();
      this.txtDiscountCode = new TextBox();
      this.Label17 = new Label();
      this.txtCharge = new TextBox();
      this.picCross = new PictureBox();
      this.txtPayInst = new TextBox();
      this.btnxxChargeNext = new Button();
      this.TabBook = new TabPage();
      this.btnOption8 = new Button();
      this.btnOption7 = new Button();
      this.btnOption6 = new Button();
      this.btnOption5 = new Button();
      this.btnRefresh = new Button();
      this.Label31 = new Label();
      this.Label24 = new Label();
      this.cboEngineer = new ComboBox();
      this.btnxx6 = new Button();
      this.gpCombo = new GroupBox();
      this.cboAppointment = new ComboBox();
      this.lblBookText = new Label();
      this.Label23 = new Label();
      this.dtpFromDate = new DateTimePicker();
      this.btnOption10 = new Button();
      this.btnOption4 = new Button();
      this.btnOption3 = new Button();
      this.btnOption2 = new Button();
      this.btnOption1 = new Button();
      this.chkKeepTogether = new CheckBox();
      this.tcComplete = new TabPage();
      this.btnDocument = new Button();
      this.lblBookedInfo = new Label();
      this.Label27 = new Label();
      this.btnRestart = new Button();
      this.ToolTip1 = new ToolTip(this.components);
      this.tabJobDetails.SuspendLayout();
      this.pnlTimeReq.SuspendLayout();
      this.pnlTypeOfWorks.SuspendLayout();
      this.pnlSymptoms.SuspendLayout();
      ((ISupportInitialize) this.DGSymptoms).BeginInit();
      this.tabAppliance.SuspendLayout();
      ((ISupportInitialize) this.DgMain).BeginInit();
      this.tabJobType.SuspendLayout();
      this.pnlSOR.SuspendLayout();
      ((ISupportInitialize) this.DGSOR).BeginInit();
      this.tabProp.SuspendLayout();
      ((ISupportInitialize) this.DGVSites).BeginInit();
      this.tcSites.SuspendLayout();
      this.tabExistingJobs.SuspendLayout();
      ((ISupportInitialize) this.dgExistingVisits).BeginInit();
      this.tabAdditional.SuspendLayout();
      ((ISupportInitialize) this.DGAdditional).BeginInit();
      this.TabCharging.SuspendLayout();
      this.pnlCharge.SuspendLayout();
      ((ISupportInitialize) this.picTick).BeginInit();
      ((ISupportInitialize) this.picCross).BeginInit();
      this.TabBook.SuspendLayout();
      this.gpCombo.SuspendLayout();
      this.tcComplete.SuspendLayout();
      this.SuspendLayout();
      this.tabJobDetails.Controls.Add((Control) this.pnlTimeReq);
      this.tabJobDetails.Controls.Add((Control) this.Label26);
      this.tabJobDetails.Controls.Add((Control) this.txtPONumber);
      this.tabJobDetails.Controls.Add((Control) this.lblAdditional);
      this.tabJobDetails.Controls.Add((Control) this.txtAdditional);
      this.tabJobDetails.Controls.Add((Control) this.btnxx2);
      this.tabJobDetails.Controls.Add((Control) this.pnlTypeOfWorks);
      this.tabJobDetails.Controls.Add((Control) this.pnlSymptoms);
      this.tabJobDetails.Controls.Add((Control) this.lblPriority);
      this.tabJobDetails.Controls.Add((Control) this.cboPriority);
      this.tabJobDetails.Controls.Add((Control) this.Label12);
      this.tabJobDetails.Controls.Add((Control) this.btnxxDetailsNext);
      this.tabJobDetails.Location = new System.Drawing.Point(4, 22);
      this.tabJobDetails.Name = "tabJobDetails";
      this.tabJobDetails.Size = new Size(877, 774);
      this.tabJobDetails.TabIndex = 4;
      this.tabJobDetails.Text = "Job Details";
      this.pnlTimeReq.Controls.Add((Control) this.Label34);
      this.pnlTimeReq.Controls.Add((Control) this.txtHrs);
      this.pnlTimeReq.Controls.Add((Control) this.Label32);
      this.pnlTimeReq.Controls.Add((Control) this.Label33);
      this.pnlTimeReq.Controls.Add((Control) this.txtDays);
      this.pnlTimeReq.Location = new System.Drawing.Point(124, 354);
      this.pnlTimeReq.Name = "pnlTimeReq";
      this.pnlTimeReq.Size = new Size(550, 42);
      this.pnlTimeReq.TabIndex = 173;
      this.pnlTimeReq.Visible = false;
      this.Label34.AutoSize = true;
      this.Label34.Font = new Font("Verdana", 10f);
      this.Label34.Location = new System.Drawing.Point(432, 11);
      this.Label34.Name = "Label34";
      this.Label34.Size = new Size(32, 17);
      this.Label34.TabIndex = 174;
      this.Label34.Text = "Hrs";
      this.txtHrs.Location = new System.Drawing.Point(347, 10);
      this.txtHrs.Name = "txtHrs";
      this.txtHrs.Size = new Size(79, 21);
      this.txtHrs.TabIndex = 173;
      this.Label32.AutoSize = true;
      this.Label32.Font = new Font("Verdana", 10f);
      this.Label32.Location = new System.Drawing.Point(3, 12);
      this.Label32.Name = "Label32";
      this.Label32.Size = new Size(135, 17);
      this.Label32.TabIndex = 170;
      this.Label32.Text = "Time Requirement";
      this.Label33.AutoSize = true;
      this.Label33.Font = new Font("Verdana", 10f);
      this.Label33.Location = new System.Drawing.Point(264, 11);
      this.Label33.Name = "Label33";
      this.Label33.Size = new Size(43, 17);
      this.Label33.TabIndex = 172;
      this.Label33.Text = "Days";
      this.txtDays.Location = new System.Drawing.Point(189, 10);
      this.txtDays.Name = "txtDays";
      this.txtDays.Size = new Size(69, 21);
      this.txtDays.TabIndex = 171;
      this.Label26.AutoSize = true;
      this.Label26.Font = new Font("Verdana", 10f);
      this.Label26.Location = new System.Drawing.Point(128, 407);
      this.Label26.Name = "Label26";
      this.Label26.Size = new Size(143, 17);
      this.Label26.TabIndex = 169;
      this.Label26.Text = "PO / Order Number";
      this.txtPONumber.Location = new System.Drawing.Point(306, 407);
      this.txtPONumber.Name = "txtPONumber";
      this.txtPONumber.Size = new Size(358, 21);
      this.txtPONumber.TabIndex = 168;
      this.lblAdditional.AutoSize = true;
      this.lblAdditional.Font = new Font("Verdana", 10f);
      this.lblAdditional.Location = new System.Drawing.Point((int) sbyte.MaxValue, 453);
      this.lblAdditional.Name = "lblAdditional";
      this.lblAdditional.Size = new Size(97, 17);
      this.lblAdditional.TabIndex = 167;
      this.lblAdditional.Text = "Work Details";
      this.lblAdditional.Visible = false;
      this.txtAdditional.Location = new System.Drawing.Point(305, 450);
      this.txtAdditional.Multiline = true;
      this.txtAdditional.Name = "txtAdditional";
      this.txtAdditional.Size = new Size(358, 99);
      this.txtAdditional.TabIndex = 166;
      this.txtAdditional.Visible = false;
      this.btnxx2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnxx2.BackColor = SystemColors.Control;
      this.btnxx2.BackgroundImage = (Image) componentResourceManager.GetObject("btnxx2.BackgroundImage");
      this.btnxx2.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxx2.Cursor = Cursors.Hand;
      this.btnxx2.Location = new System.Drawing.Point(3, 707);
      this.btnxx2.Name = "btnxx2";
      this.btnxx2.Size = new Size(62, 45);
      this.btnxx2.TabIndex = 163;
      this.btnxx2.UseVisualStyleBackColor = false;
      this.pnlTypeOfWorks.Controls.Add((Control) this.cboTypeOfWorks);
      this.pnlTypeOfWorks.Controls.Add((Control) this.Label25);
      this.pnlTypeOfWorks.Location = new System.Drawing.Point(124, 354);
      this.pnlTypeOfWorks.Name = "pnlTypeOfWorks";
      this.pnlTypeOfWorks.Size = new Size(550, 42);
      this.pnlTypeOfWorks.TabIndex = 162;
      this.cboTypeOfWorks.Font = new Font("Verdana", 9f);
      this.cboTypeOfWorks.FormattingEnabled = true;
      this.cboTypeOfWorks.Location = new System.Drawing.Point(189, 10);
      this.cboTypeOfWorks.Name = "cboTypeOfWorks";
      this.cboTypeOfWorks.Size = new Size(357, 22);
      this.cboTypeOfWorks.TabIndex = 163;
      this.cboTypeOfWorks.Visible = false;
      this.Label25.AutoSize = true;
      this.Label25.Font = new Font("Verdana", 10f);
      this.Label25.Location = new System.Drawing.Point(11, 10);
      this.Label25.Name = "Label25";
      this.Label25.Size = new Size(112, 17);
      this.Label25.TabIndex = 162;
      this.Label25.Text = "Type Of Works";
      this.Label25.Visible = false;
      this.pnlSymptoms.Controls.Add((Control) this.lblSymptom);
      this.pnlSymptoms.Controls.Add((Control) this.cboSymptom);
      this.pnlSymptoms.Controls.Add((Control) this.Label15);
      this.pnlSymptoms.Controls.Add((Control) this.DGSymptoms);
      this.pnlSymptoms.Controls.Add((Control) this.btnSymMinus);
      this.pnlSymptoms.Controls.Add((Control) this.btnSymAdd);
      this.pnlSymptoms.Location = new System.Drawing.Point(95, 155);
      this.pnlSymptoms.Name = "pnlSymptoms";
      this.pnlSymptoms.Size = new Size(602, 193);
      this.pnlSymptoms.TabIndex = 158;
      this.lblSymptom.AutoSize = true;
      this.lblSymptom.Font = new Font("Verdana", 10f);
      this.lblSymptom.Location = new System.Drawing.Point(34, 14);
      this.lblSymptom.Name = "lblSymptom";
      this.lblSymptom.Size = new Size(76, 17);
      this.lblSymptom.TabIndex = 159;
      this.lblSymptom.Text = "Symptom";
      this.cboSymptom.Font = new Font("Verdana", 9f);
      this.cboSymptom.FormattingEnabled = true;
      this.cboSymptom.Location = new System.Drawing.Point(210, 12);
      this.cboSymptom.Name = "cboSymptom";
      this.cboSymptom.Size = new Size(358, 22);
      this.cboSymptom.TabIndex = 158;
      this.Label15.AutoSize = true;
      this.Label15.Font = new Font("Verdana", 10f);
      this.Label15.Location = new System.Drawing.Point(34, 67);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(140, 17);
      this.Label15.TabIndex = 157;
      this.Label15.Text = "Applied Symptoms";
      this.DGSymptoms.AllowUserToAddRows = false;
      this.DGSymptoms.AllowUserToDeleteRows = false;
      this.DGSymptoms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGSymptoms.ColumnHeadersVisible = false;
      this.DGSymptoms.Location = new System.Drawing.Point(210, 67);
      this.DGSymptoms.MultiSelect = false;
      this.DGSymptoms.Name = "DGSymptoms";
      this.DGSymptoms.ReadOnly = true;
      this.DGSymptoms.RowHeadersVisible = false;
      this.DGSymptoms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.DGSymptoms.ShowCellErrors = false;
      this.DGSymptoms.ShowEditingIcon = false;
      this.DGSymptoms.ShowRowErrors = false;
      this.DGSymptoms.Size = new Size(359, 122);
      this.DGSymptoms.TabIndex = 156;
      this.btnSymMinus.Location = new System.Drawing.Point(346, 39);
      this.btnSymMinus.Name = "btnSymMinus";
      this.btnSymMinus.Size = new Size(39, 23);
      this.btnSymMinus.TabIndex = 155;
      this.btnSymMinus.Text = "-";
      this.btnSymMinus.UseVisualStyleBackColor = true;
      this.btnSymAdd.Location = new System.Drawing.Point(391, 39);
      this.btnSymAdd.Name = "btnSymAdd";
      this.btnSymAdd.Size = new Size(39, 23);
      this.btnSymAdd.TabIndex = 154;
      this.btnSymAdd.Text = "+";
      this.btnSymAdd.UseVisualStyleBackColor = true;
      this.lblPriority.AutoSize = true;
      this.lblPriority.Font = new Font("Verdana", 10f);
      this.lblPriority.Location = new System.Drawing.Point((int) sbyte.MaxValue, 120);
      this.lblPriority.Name = "lblPriority";
      this.lblPriority.Size = new Size(57, 17);
      this.lblPriority.TabIndex = 157;
      this.lblPriority.Text = "Priority";
      this.lblPriority.Visible = false;
      this.cboPriority.Font = new Font("Verdana", 9f);
      this.cboPriority.FormattingEnabled = true;
      this.cboPriority.Location = new System.Drawing.Point(304, 118);
      this.cboPriority.Name = "cboPriority";
      this.cboPriority.Size = new Size(357, 22);
      this.cboPriority.TabIndex = 156;
      this.cboPriority.Visible = false;
      this.Label12.AutoSize = true;
      this.Label12.Font = new Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label12.Location = new System.Drawing.Point(411, 28);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(141, 25);
      this.Label12.TabIndex = 20;
      this.Label12.Text = "Job Details";
      this.btnxxDetailsNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnxxDetailsNext.BackColor = SystemColors.Control;
      this.btnxxDetailsNext.BackgroundImage = (Image) componentResourceManager.GetObject("btnxxDetailsNext.BackgroundImage");
      this.btnxxDetailsNext.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxxDetailsNext.Cursor = Cursors.Hand;
      this.btnxxDetailsNext.Location = new System.Drawing.Point(812, 707);
      this.btnxxDetailsNext.Name = "btnxxDetailsNext";
      this.btnxxDetailsNext.Size = new Size(62, 45);
      this.btnxxDetailsNext.TabIndex = 154;
      this.btnxxDetailsNext.UseVisualStyleBackColor = false;
      this.btnxxDetailsNext.Visible = false;
      this.tabAppliance.Controls.Add((Control) this.btnxx3);
      this.tabAppliance.Controls.Add((Control) this.Label20);
      this.tabAppliance.Controls.Add((Control) this.Label13);
      this.tabAppliance.Controls.Add((Control) this.DgMain);
      this.tabAppliance.Controls.Add((Control) this.btnMinusMain);
      this.tabAppliance.Controls.Add((Control) this.btnAddMain);
      this.tabAppliance.Controls.Add((Control) this.cboMainApps);
      this.tabAppliance.Controls.Add((Control) this.btnxxApplianceNext);
      this.tabAppliance.Location = new System.Drawing.Point(4, 22);
      this.tabAppliance.Name = "tabAppliance";
      this.tabAppliance.Size = new Size(877, 774);
      this.tabAppliance.TabIndex = 3;
      this.tabAppliance.Text = "Associated Assets";
      this.btnxx3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnxx3.BackColor = SystemColors.Control;
      this.btnxx3.BackgroundImage = (Image) componentResourceManager.GetObject("btnxx3.BackgroundImage");
      this.btnxx3.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxx3.Cursor = Cursors.Hand;
      this.btnxx3.Location = new System.Drawing.Point(3, 627);
      this.btnxx3.Name = "btnxx3";
      this.btnxx3.Size = new Size(62, 45);
      this.btnxx3.TabIndex = 169;
      this.btnxx3.UseVisualStyleBackColor = false;
      this.Label20.AutoSize = true;
      this.Label20.Font = new Font("Verdana", 10f);
      this.Label20.Location = new System.Drawing.Point(218, 97);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(436, 17);
      this.Label20.TabIndex = 168;
      this.Label20.Text = "Add any asset either to be serviced or affected by the works";
      this.Label13.AutoSize = true;
      this.Label13.Font = new Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label13.Location = new System.Drawing.Point(291, 31);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(243, 25);
      this.Label13.TabIndex = 150;
      this.Label13.Text = "Associated Asset(s)";
      this.DgMain.AllowUserToAddRows = false;
      this.DgMain.AllowUserToDeleteRows = false;
      this.DgMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DgMain.ColumnHeadersVisible = false;
      this.DgMain.Location = new System.Drawing.Point(292, 210);
      this.DgMain.MultiSelect = false;
      this.DgMain.Name = "DgMain";
      this.DgMain.ReadOnly = true;
      this.DgMain.RowHeadersVisible = false;
      this.DgMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.DgMain.ShowCellErrors = false;
      this.DgMain.ShowEditingIcon = false;
      this.DgMain.ShowRowErrors = false;
      this.DgMain.Size = new Size(293, 175);
      this.DgMain.TabIndex = 149;
      this.btnMinusMain.Location = new System.Drawing.Point(392, 182);
      this.btnMinusMain.Name = "btnMinusMain";
      this.btnMinusMain.Size = new Size(39, 23);
      this.btnMinusMain.TabIndex = 148;
      this.btnMinusMain.Text = "-";
      this.btnMinusMain.UseVisualStyleBackColor = true;
      this.btnAddMain.Location = new System.Drawing.Point(437, 182);
      this.btnAddMain.Name = "btnAddMain";
      this.btnAddMain.Size = new Size(39, 23);
      this.btnAddMain.TabIndex = 147;
      this.btnAddMain.Text = "+";
      this.btnAddMain.UseVisualStyleBackColor = true;
      this.cboMainApps.Cursor = Cursors.Hand;
      this.cboMainApps.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboMainApps.Location = new System.Drawing.Point(292, 155);
      this.cboMainApps.Name = "cboMainApps";
      this.cboMainApps.Size = new Size(293, 21);
      this.cboMainApps.TabIndex = 146;
      this.cboMainApps.Tag = (object) "";
      this.btnxxApplianceNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnxxApplianceNext.BackColor = SystemColors.Control;
      this.btnxxApplianceNext.BackgroundImage = (Image) componentResourceManager.GetObject("btnxxApplianceNext.BackgroundImage");
      this.btnxxApplianceNext.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxxApplianceNext.Cursor = Cursors.Hand;
      this.btnxxApplianceNext.Location = new System.Drawing.Point(812, 627);
      this.btnxxApplianceNext.Name = "btnxxApplianceNext";
      this.btnxxApplianceNext.Size = new Size(62, 45);
      this.btnxxApplianceNext.TabIndex = 151;
      this.btnxxApplianceNext.UseVisualStyleBackColor = false;
      this.btnxxApplianceNext.Visible = false;
      this.tabJobType.Controls.Add((Control) this.btnxxExternalBM);
      this.tabJobType.Controls.Add((Control) this.btnxxCarpentry);
      this.tabJobType.Controls.Add((Control) this.btnxxPlumbing);
      this.tabJobType.Controls.Add((Control) this.btnxxElectrical);
      this.tabJobType.Controls.Add((Control) this.btnxxMultiTrade);
      this.tabJobType.Controls.Add((Control) this.btnxxKitchens);
      this.tabJobType.Controls.Add((Control) this.btnxx1);
      this.tabJobType.Controls.Add((Control) this.pnlSOR);
      this.tabJobType.Controls.Add((Control) this.btnxxSOR);
      this.tabJobType.Controls.Add((Control) this.lbltype);
      this.tabJobType.Controls.Add((Control) this.cbotypeWiz);
      this.tabJobType.Controls.Add((Control) this.btnxxBreakdown);
      this.tabJobType.Controls.Add((Control) this.Label11);
      this.tabJobType.Controls.Add((Control) this.BtnxxService);
      this.tabJobType.Controls.Add((Control) this.btnxxOther);
      this.tabJobType.Controls.Add((Control) this.btnxxJobNext);
      this.tabJobType.Location = new System.Drawing.Point(4, 22);
      this.tabJobType.Name = "tabJobType";
      this.tabJobType.Size = new Size(877, 774);
      this.tabJobType.TabIndex = 8;
      this.tabJobType.Text = "Job Type";
      this.btnxxExternalBM.BackColor = SystemColors.Control;
      this.btnxxExternalBM.Cursor = Cursors.Hand;
      this.btnxxExternalBM.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxExternalBM.Location = new System.Drawing.Point(196, 270);
      this.btnxxExternalBM.Name = "btnxxExternalBM";
      this.btnxxExternalBM.Size = new Size(511, 41);
      this.btnxxExternalBM.TabIndex = 164;
      this.btnxxExternalBM.Text = "Other External B and M";
      this.btnxxExternalBM.UseVisualStyleBackColor = false;
      this.btnxxExternalBM.Visible = false;
      this.btnxxCarpentry.BackColor = SystemColors.Control;
      this.btnxxCarpentry.Cursor = Cursors.Hand;
      this.btnxxCarpentry.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxCarpentry.Location = new System.Drawing.Point(196, 226);
      this.btnxxCarpentry.Name = "btnxxCarpentry";
      this.btnxxCarpentry.Size = new Size(511, 41);
      this.btnxxCarpentry.TabIndex = 163;
      this.btnxxCarpentry.Tag = (object) "71039";
      this.btnxxCarpentry.Text = "Carpentry";
      this.btnxxCarpentry.UseVisualStyleBackColor = false;
      this.btnxxCarpentry.Visible = false;
      this.btnxxPlumbing.BackColor = SystemColors.Control;
      this.btnxxPlumbing.Cursor = Cursors.Hand;
      this.btnxxPlumbing.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxPlumbing.Location = new System.Drawing.Point(196, 182);
      this.btnxxPlumbing.Name = "btnxxPlumbing";
      this.btnxxPlumbing.Size = new Size(511, 41);
      this.btnxxPlumbing.TabIndex = 162;
      this.btnxxPlumbing.Tag = (object) "4754";
      this.btnxxPlumbing.Text = "Plumbing";
      this.btnxxPlumbing.UseVisualStyleBackColor = false;
      this.btnxxPlumbing.Visible = false;
      this.btnxxElectrical.BackColor = SystemColors.Control;
      this.btnxxElectrical.Cursor = Cursors.Hand;
      this.btnxxElectrical.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxElectrical.Location = new System.Drawing.Point(196, 138);
      this.btnxxElectrical.Name = "btnxxElectrical";
      this.btnxxElectrical.Size = new Size(511, 41);
      this.btnxxElectrical.TabIndex = 161;
      this.btnxxElectrical.Tag = (object) "68121";
      this.btnxxElectrical.Text = "Electrical";
      this.btnxxElectrical.UseVisualStyleBackColor = false;
      this.btnxxElectrical.Visible = false;
      this.btnxxMultiTrade.BackColor = SystemColors.Control;
      this.btnxxMultiTrade.Cursor = Cursors.Hand;
      this.btnxxMultiTrade.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxMultiTrade.Location = new System.Drawing.Point(196, 94);
      this.btnxxMultiTrade.Name = "btnxxMultiTrade";
      this.btnxxMultiTrade.Size = new Size(511, 41);
      this.btnxxMultiTrade.TabIndex = 160;
      this.btnxxMultiTrade.Tag = (object) "71044";
      this.btnxxMultiTrade.Text = "Multi Trade";
      this.btnxxMultiTrade.UseVisualStyleBackColor = false;
      this.btnxxMultiTrade.Visible = false;
      this.btnxxKitchens.BackColor = SystemColors.Control;
      this.btnxxKitchens.Cursor = Cursors.Hand;
      this.btnxxKitchens.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxKitchens.Location = new System.Drawing.Point(196, 50);
      this.btnxxKitchens.Name = "btnxxKitchens";
      this.btnxxKitchens.Size = new Size(511, 41);
      this.btnxxKitchens.TabIndex = 159;
      this.btnxxKitchens.Text = "Kitchens";
      this.btnxxKitchens.UseVisualStyleBackColor = false;
      this.btnxxKitchens.Visible = false;
      this.btnxx1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnxx1.BackColor = SystemColors.Control;
      this.btnxx1.BackgroundImage = (Image) componentResourceManager.GetObject("btnxx1.BackgroundImage");
      this.btnxx1.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxx1.Cursor = Cursors.Hand;
      this.btnxx1.Location = new System.Drawing.Point(3, 627);
      this.btnxx1.Name = "btnxx1";
      this.btnxx1.Size = new Size(62, 45);
      this.btnxx1.TabIndex = 158;
      this.btnxx1.UseVisualStyleBackColor = false;
      this.pnlSOR.Controls.Add((Control) this.DGSOR);
      this.pnlSOR.Controls.Add((Control) this.btnxxFollow);
      this.pnlSOR.Controls.Add((Control) this.txtSORQty);
      this.pnlSOR.Controls.Add((Control) this.Label14);
      this.pnlSOR.Controls.Add((Control) this.btnSORAdd);
      this.pnlSOR.Controls.Add((Control) this.cboSOR);
      this.pnlSOR.Controls.Add((Control) this.btnSORMinus);
      this.pnlSOR.Location = new System.Drawing.Point(193, 423);
      this.pnlSOR.Name = "pnlSOR";
      this.pnlSOR.Size = new Size(519, 159);
      this.pnlSOR.TabIndex = 156;
      this.pnlSOR.Visible = false;
      this.DGSOR.AllowUserToAddRows = false;
      this.DGSOR.AllowUserToDeleteRows = false;
      this.DGSOR.AllowUserToResizeRows = false;
      this.DGSOR.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGSOR.Location = new System.Drawing.Point(3, 31);
      this.DGSOR.MultiSelect = false;
      this.DGSOR.Name = "DGSOR";
      this.DGSOR.ReadOnly = true;
      this.DGSOR.ShowCellErrors = false;
      this.DGSOR.ShowEditingIcon = false;
      this.DGSOR.ShowRowErrors = false;
      this.DGSOR.Size = new Size(513, 120);
      this.DGSOR.TabIndex = 150;
      this.btnxxFollow.BackColor = SystemColors.Control;
      this.btnxxFollow.Cursor = Cursors.Hand;
      this.btnxxFollow.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxFollow.Location = new System.Drawing.Point(3, 53);
      this.btnxxFollow.Name = "btnxxFollow";
      this.btnxxFollow.Size = new Size(511, 72);
      this.btnxxFollow.TabIndex = 157;
      this.btnxxFollow.Text = "Quoted Works /\r\nFollow Up Works";
      this.btnxxFollow.UseVisualStyleBackColor = false;
      this.btnxxFollow.Visible = false;
      this.txtSORQty.Location = new System.Drawing.Point(412, 5);
      this.txtSORQty.Name = "txtSORQty";
      this.txtSORQty.Size = new Size(44, 21);
      this.txtSORQty.TabIndex = 155;
      this.txtSORQty.Text = "1";
      this.Label14.AutoSize = true;
      this.Label14.Font = new Font("Verdana", 10f);
      this.Label14.Location = new System.Drawing.Point(382, 6);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(33, 17);
      this.Label14.TabIndex = 154;
      this.Label14.Text = "Qty";
      this.Label14.Visible = false;
      this.btnSORAdd.Location = new System.Drawing.Point(488, 3);
      this.btnSORAdd.Name = "btnSORAdd";
      this.btnSORAdd.Size = new Size(26, 23);
      this.btnSORAdd.TabIndex = 151;
      this.btnSORAdd.Text = "+";
      this.btnSORAdd.UseVisualStyleBackColor = true;
      this.cboSOR.BackColor = SystemColors.Window;
      this.cboSOR.Font = new Font("Verdana", 9f);
      this.cboSOR.FormattingEnabled = true;
      this.cboSOR.Location = new System.Drawing.Point(3, 4);
      this.cboSOR.Name = "cboSOR";
      this.cboSOR.Size = new Size(373, 22);
      this.cboSOR.TabIndex = 153;
      this.btnSORMinus.Location = new System.Drawing.Point(460, 3);
      this.btnSORMinus.Name = "btnSORMinus";
      this.btnSORMinus.Size = new Size(25, 23);
      this.btnSORMinus.TabIndex = 152;
      this.btnSORMinus.Text = "-";
      this.btnSORMinus.UseVisualStyleBackColor = true;
      this.btnxxSOR.BackColor = SystemColors.Control;
      this.btnxxSOR.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxSOR.Location = new System.Drawing.Point(196, 379);
      this.btnxxSOR.Name = "btnxxSOR";
      this.btnxxSOR.Size = new Size(513, 38);
      this.btnxxSOR.TabIndex = 28;
      this.btnxxSOR.Tag = (object) "67098";
      this.btnxxSOR.Text = "SOR Based Works";
      this.btnxxSOR.UseVisualStyleBackColor = false;
      this.lbltype.AutoSize = true;
      this.lbltype.Font = new Font("Verdana", 10f);
      this.lbltype.Location = new System.Drawing.Point(206, 324);
      this.lbltype.Name = "lbltype";
      this.lbltype.Size = new Size(70, 17);
      this.lbltype.TabIndex = 9;
      this.lbltype.Text = "Job Type";
      this.lbltype.Visible = false;
      this.cbotypeWiz.BackColor = SystemColors.Window;
      this.cbotypeWiz.Font = new Font("Verdana", 9f);
      this.cbotypeWiz.FormattingEnabled = true;
      this.cbotypeWiz.Location = new System.Drawing.Point(282, 322);
      this.cbotypeWiz.Name = "cbotypeWiz";
      this.cbotypeWiz.Size = new Size(326, 22);
      this.cbotypeWiz.TabIndex = 8;
      this.cbotypeWiz.Visible = false;
      this.btnxxBreakdown.BackColor = SystemColors.Control;
      this.btnxxBreakdown.Cursor = Cursors.Hand;
      this.btnxxBreakdown.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxBreakdown.Location = new System.Drawing.Point(196, 147);
      this.btnxxBreakdown.Name = "btnxxBreakdown";
      this.btnxxBreakdown.Size = new Size(511, 72);
      this.btnxxBreakdown.TabIndex = 4;
      this.btnxxBreakdown.Tag = (object) "4703";
      this.btnxxBreakdown.Text = "Breakdown";
      this.btnxxBreakdown.UseVisualStyleBackColor = false;
      this.Label11.AutoSize = true;
      this.Label11.Font = new Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label11.Location = new System.Drawing.Point(390, 23);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(117, 25);
      this.Label11.TabIndex = 3;
      this.Label11.Text = "Job Type";
      this.BtnxxService.BackColor = SystemColors.Control;
      this.BtnxxService.Cursor = Cursors.Hand;
      this.BtnxxService.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnxxService.Location = new System.Drawing.Point(196, 63);
      this.BtnxxService.Name = "BtnxxService";
      this.BtnxxService.Size = new Size(511, 72);
      this.BtnxxService.TabIndex = 0;
      this.BtnxxService.Tag = (object) "519";
      this.BtnxxService.Text = "Service";
      this.BtnxxService.UseVisualStyleBackColor = false;
      this.btnxxOther.BackColor = SystemColors.Control;
      this.btnxxOther.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxOther.Location = new System.Drawing.Point(196, 314);
      this.btnxxOther.Name = "btnxxOther";
      this.btnxxOther.Size = new Size(511, 38);
      this.btnxxOther.TabIndex = 5;
      this.btnxxOther.Text = "Other";
      this.btnxxOther.UseVisualStyleBackColor = false;
      this.btnxxJobNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnxxJobNext.BackColor = SystemColors.Control;
      this.btnxxJobNext.BackgroundImage = (Image) componentResourceManager.GetObject("btnxxJobNext.BackgroundImage");
      this.btnxxJobNext.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxxJobNext.Cursor = Cursors.Hand;
      this.btnxxJobNext.Location = new System.Drawing.Point(812, 627);
      this.btnxxJobNext.Name = "btnxxJobNext";
      this.btnxxJobNext.Size = new Size(62, 45);
      this.btnxxJobNext.TabIndex = 27;
      this.btnxxJobNext.UseVisualStyleBackColor = false;
      this.btnxxJobNext.Visible = false;
      this.tabProp.Controls.Add((Control) this.lblDefect);
      this.tabProp.Controls.Add((Control) this.txtDefect);
      this.tabProp.Controls.Add((Control) this.chbCommercial);
      this.tabProp.Controls.Add((Control) this.lblContactAlert);
      this.tabProp.Controls.Add((Control) this.txtContactAlert);
      this.tabProp.Controls.Add((Control) this.txtSearchSite);
      this.tabProp.Controls.Add((Control) this.txtName);
      this.tabProp.Controls.Add((Control) this.txtSiteNotes);
      this.tabProp.Controls.Add((Control) this.Label30);
      this.tabProp.Controls.Add((Control) this.Label28);
      this.tabProp.Controls.Add((Control) this.txtContractRef);
      this.tabProp.Controls.Add((Control) this.btnJobHistory);
      this.tabProp.Controls.Add((Control) this.btnxxSiteNext);
      this.tabProp.Controls.Add((Control) this.Label10);
      this.tabProp.Controls.Add((Control) this.txtCustomer);
      this.tabProp.Controls.Add((Control) this.Label9);
      this.tabProp.Controls.Add((Control) this.txtEmail);
      this.tabProp.Controls.Add((Control) this.Label8);
      this.tabProp.Controls.Add((Control) this.txtTel);
      this.tabProp.Controls.Add((Control) this.Label6);
      this.tabProp.Controls.Add((Control) this.txtMob);
      this.tabProp.Controls.Add((Control) this.txtAddress3);
      this.tabProp.Controls.Add((Control) this.Label7);
      this.tabProp.Controls.Add((Control) this.Label5);
      this.tabProp.Controls.Add((Control) this.Label4);
      this.tabProp.Controls.Add((Control) this.Label3);
      this.tabProp.Controls.Add((Control) this.Label2);
      this.tabProp.Controls.Add((Control) this.cboTitle);
      this.tabProp.Controls.Add((Control) this.txtAddress1);
      this.tabProp.Controls.Add((Control) this.txtAddress2);
      this.tabProp.Controls.Add((Control) this.txtPostcode);
      this.tabProp.Controls.Add((Control) this.txtSurname);
      this.tabProp.Controls.Add((Control) this.txtFirstName);
      this.tabProp.Controls.Add((Control) this.btnEditSite);
      this.tabProp.Controls.Add((Control) this.btnAddSite);
      this.tabProp.Controls.Add((Control) this.Label1);
      this.tabProp.Controls.Add((Control) this.txtSearch);
      this.tabProp.Controls.Add((Control) this.DGVSites);
      this.tabProp.Location = new System.Drawing.Point(4, 22);
      this.tabProp.Name = "tabProp";
      this.tabProp.Size = new Size(877, 774);
      this.tabProp.TabIndex = 0;
      this.tabProp.Text = "Property";
      this.lblDefect.AutoSize = true;
      this.lblDefect.Location = new System.Drawing.Point(208, 583);
      this.lblDefect.Name = "lblDefect";
      this.lblDefect.Size = new Size(109, 13);
      this.lblDefect.TabIndex = 38;
      this.lblDefect.Text = "Defect Contractor";
      this.txtDefect.Location = new System.Drawing.Point(318, 582);
      this.txtDefect.Name = "txtDefect";
      this.txtDefect.ReadOnly = true;
      this.txtDefect.Size = new Size(300, 21);
      this.txtDefect.TabIndex = 37;
      this.chbCommercial.AutoSize = true;
      this.chbCommercial.Enabled = false;
      this.chbCommercial.Location = new System.Drawing.Point(476, 525);
      this.chbCommercial.Name = "chbCommercial";
      this.chbCommercial.RightToLeft = RightToLeft.Yes;
      this.chbCommercial.Size = new Size(140, 17);
      this.chbCommercial.TabIndex = 36;
      this.chbCommercial.Text = "Commercial/District";
      this.chbCommercial.UseVisualStyleBackColor = true;
      this.lblContactAlert.AutoSize = true;
      this.lblContactAlert.Location = new System.Drawing.Point(208, 553);
      this.lblContactAlert.Name = "lblContactAlert";
      this.lblContactAlert.Size = new Size(88, 13);
      this.lblContactAlert.TabIndex = 35;
      this.lblContactAlert.Text = "Contact Alerts";
      this.txtContactAlert.Location = new System.Drawing.Point(318, 552);
      this.txtContactAlert.Name = "txtContactAlert";
      this.txtContactAlert.ReadOnly = true;
      this.txtContactAlert.Size = new Size(300, 21);
      this.txtContactAlert.TabIndex = 34;
      this.txtSearchSite.Location = new System.Drawing.Point(610, 56);
      this.txtSearchSite.Name = "txtSearchSite";
      this.txtSearchSite.Size = new Size(69, 21);
      this.txtSearchSite.TabIndex = 33;
      this.txtSearchSite.Text = "Search";
      this.txtSearchSite.UseVisualStyleBackColor = true;
      this.txtName.Location = new System.Drawing.Point(448, 279);
      this.txtName.Name = "txtName";
      this.txtName.ReadOnly = true;
      this.txtName.Size = new Size(171, 21);
      this.txtName.TabIndex = 32;
      this.txtSiteNotes.Location = new System.Drawing.Point(318, 611);
      this.txtSiteNotes.Multiline = true;
      this.txtSiteNotes.Name = "txtSiteNotes";
      this.txtSiteNotes.ReadOnly = true;
      this.txtSiteNotes.ScrollBars = ScrollBars.Vertical;
      this.txtSiteNotes.Size = new Size(301, 55);
      this.txtSiteNotes.TabIndex = 31;
      this.Label30.AutoSize = true;
      this.Label30.Location = new System.Drawing.Point(208, 616);
      this.Label30.Name = "Label30";
      this.Label30.Size = new Size(65, 13);
      this.Label30.TabIndex = 30;
      this.Label30.Text = "Site Notes";
      this.Label28.AutoSize = true;
      this.Label28.Location = new System.Drawing.Point(208, 525);
      this.Label28.Name = "Label28";
      this.Label28.Size = new Size(79, 13);
      this.Label28.TabIndex = 29;
      this.Label28.Text = "Contract Ref";
      this.txtContractRef.Cursor = Cursors.Hand;
      this.txtContractRef.Location = new System.Drawing.Point(318, 522);
      this.txtContractRef.Name = "txtContractRef";
      this.txtContractRef.ReadOnly = true;
      this.txtContractRef.Size = new Size(121, 21);
      this.txtContractRef.TabIndex = 28;
      this.btnJobHistory.Location = new System.Drawing.Point(318, 672);
      this.btnJobHistory.Name = "btnJobHistory";
      this.btnJobHistory.Size = new Size(144, 51);
      this.btnJobHistory.TabIndex = 27;
      this.btnJobHistory.Text = "Job History";
      this.btnJobHistory.UseVisualStyleBackColor = true;
      this.btnxxSiteNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnxxSiteNext.BackColor = SystemColors.Control;
      this.btnxxSiteNext.BackgroundImage = (Image) componentResourceManager.GetObject("btnxxSiteNext.BackgroundImage");
      this.btnxxSiteNext.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxxSiteNext.Cursor = Cursors.Hand;
      this.btnxxSiteNext.Location = new System.Drawing.Point(812, 681);
      this.btnxxSiteNext.Name = "btnxxSiteNext";
      this.btnxxSiteNext.Size = new Size(62, 45);
      this.btnxxSiteNext.TabIndex = 26;
      this.btnxxSiteNext.UseVisualStyleBackColor = false;
      this.Label10.AutoSize = true;
      this.Label10.Location = new System.Drawing.Point(208, (int) byte.MaxValue);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(63, 13);
      this.Label10.TabIndex = 25;
      this.Label10.Text = "Customer";
      this.txtCustomer.Location = new System.Drawing.Point(318, 252);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(301, 21);
      this.txtCustomer.TabIndex = 24;
      this.Label9.AutoSize = true;
      this.Label9.Location = new System.Drawing.Point(208, 498);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(38, 13);
      this.Label9.TabIndex = 23;
      this.Label9.Text = "Email";
      this.txtEmail.Location = new System.Drawing.Point(318, 495);
      this.txtEmail.Name = "txtEmail";
      this.txtEmail.ReadOnly = true;
      this.txtEmail.Size = new Size(301, 21);
      this.txtEmail.TabIndex = 22;
      this.Label8.AutoSize = true;
      this.Label8.Location = new System.Drawing.Point(208, 471);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(46, 13);
      this.Label8.TabIndex = 21;
      this.Label8.Text = "Tel No.";
      this.txtTel.Location = new System.Drawing.Point(318, 468);
      this.txtTel.Name = "txtTel";
      this.txtTel.ReadOnly = true;
      this.txtTel.Size = new Size(121, 21);
      this.txtTel.TabIndex = 20;
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(445, 471);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(53, 13);
      this.Label6.TabIndex = 19;
      this.Label6.Text = "Mob No.";
      this.txtMob.Location = new System.Drawing.Point(498, 468);
      this.txtMob.Name = "txtMob";
      this.txtMob.ReadOnly = true;
      this.txtMob.Size = new Size(121, 21);
      this.txtMob.TabIndex = 18;
      this.txtAddress3.Location = new System.Drawing.Point(318, 414);
      this.txtAddress3.Name = "txtAddress3";
      this.txtAddress3.ReadOnly = true;
      this.txtAddress3.Size = new Size(301, 21);
      this.txtAddress3.TabIndex = 17;
      this.Label7.AutoSize = true;
      this.Label7.Location = new System.Drawing.Point(208, 444);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(58, 13);
      this.Label7.TabIndex = 16;
      this.Label7.Text = "Postcode";
      this.Label5.AutoSize = true;
      this.Label5.Location = new System.Drawing.Point(208, 363);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(57, 13);
      this.Label5.TabIndex = 14;
      this.Label5.Text = "Address ";
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(208, 336);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(59, 13);
      this.Label4.TabIndex = 13;
      this.Label4.Text = "Surname";
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(208, 309);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(68, 13);
      this.Label3.TabIndex = 12;
      this.Label3.Text = "First Name";
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(208, 282);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(31, 13);
      this.Label2.TabIndex = 11;
      this.Label2.Text = "Title";
      this.cboTitle.Enabled = false;
      this.cboTitle.FormattingEnabled = true;
      this.cboTitle.Location = new System.Drawing.Point(318, 279);
      this.cboTitle.Name = "cboTitle";
      this.cboTitle.Size = new Size(121, 21);
      this.cboTitle.TabIndex = 10;
      this.txtAddress1.Location = new System.Drawing.Point(318, 360);
      this.txtAddress1.Name = "txtAddress1";
      this.txtAddress1.ReadOnly = true;
      this.txtAddress1.Size = new Size(301, 21);
      this.txtAddress1.TabIndex = 9;
      this.txtAddress2.Location = new System.Drawing.Point(318, 387);
      this.txtAddress2.Name = "txtAddress2";
      this.txtAddress2.ReadOnly = true;
      this.txtAddress2.Size = new Size(301, 21);
      this.txtAddress2.TabIndex = 8;
      this.txtPostcode.Location = new System.Drawing.Point(318, 441);
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.ReadOnly = true;
      this.txtPostcode.Size = new Size(301, 21);
      this.txtPostcode.TabIndex = 7;
      this.txtSurname.Location = new System.Drawing.Point(318, 333);
      this.txtSurname.Name = "txtSurname";
      this.txtSurname.ReadOnly = true;
      this.txtSurname.Size = new Size(301, 21);
      this.txtSurname.TabIndex = 6;
      this.txtFirstName.Location = new System.Drawing.Point(318, 306);
      this.txtFirstName.Name = "txtFirstName";
      this.txtFirstName.ReadOnly = true;
      this.txtFirstName.Size = new Size(301, 21);
      this.txtFirstName.TabIndex = 5;
      this.btnEditSite.Location = new System.Drawing.Point(468, 672);
      this.btnEditSite.Name = "btnEditSite";
      this.btnEditSite.Size = new Size(151, 51);
      this.btnEditSite.TabIndex = 4;
      this.btnEditSite.Text = "Ammend Other \r\nFields / View Other Notes";
      this.btnEditSite.UseVisualStyleBackColor = true;
      this.btnAddSite.Location = new System.Drawing.Point(788, 54);
      this.btnAddSite.Name = "btnAddSite";
      this.btnAddSite.Size = new Size(75, 23);
      this.btnAddSite.TabIndex = 3;
      this.btnAddSite.Text = "Add Site";
      this.btnAddSite.UseVisualStyleBackColor = true;
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new System.Drawing.Point(383, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(145, 25);
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Search Site";
      this.txtSearch.Location = new System.Drawing.Point(303, 56);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new Size(301, 21);
      this.txtSearch.TabIndex = 1;
      this.DGVSites.AllowUserToAddRows = false;
      this.DGVSites.AllowUserToDeleteRows = false;
      this.DGVSites.AllowUserToOrderColumns = true;
      this.DGVSites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGVSites.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.DGVSites.Location = new System.Drawing.Point(14, 88);
      this.DGVSites.MultiSelect = false;
      this.DGVSites.Name = "DGVSites";
      this.DGVSites.ReadOnly = true;
      this.DGVSites.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.DGVSites.Size = new Size(849, 150);
      this.DGVSites.TabIndex = 0;
      this.tcSites.Controls.Add((Control) this.tabProp);
      this.tcSites.Controls.Add((Control) this.tabExistingJobs);
      this.tcSites.Controls.Add((Control) this.tabJobType);
      this.tcSites.Controls.Add((Control) this.tabJobDetails);
      this.tcSites.Controls.Add((Control) this.tabAppliance);
      this.tcSites.Controls.Add((Control) this.tabAdditional);
      this.tcSites.Controls.Add((Control) this.TabCharging);
      this.tcSites.Controls.Add((Control) this.TabBook);
      this.tcSites.Controls.Add((Control) this.tcComplete);
      this.tcSites.Dock = DockStyle.Fill;
      this.tcSites.Location = new System.Drawing.Point(0, 0);
      this.tcSites.Name = "tcSites";
      this.tcSites.SelectedIndex = 0;
      this.tcSites.Size = new Size(885, 800);
      this.tcSites.TabIndex = 0;
      this.tabExistingJobs.BackColor = SystemColors.Control;
      this.tabExistingJobs.Controls.Add((Control) this.btnxxExistingJobBack);
      this.tabExistingJobs.Controls.Add((Control) this.btnxxExistingJobNext);
      this.tabExistingJobs.Controls.Add((Control) this.dgExistingVisits);
      this.tabExistingJobs.Controls.Add((Control) this.Label29);
      this.tabExistingJobs.Controls.Add((Control) this.btnxxNewJob);
      this.tabExistingJobs.Location = new System.Drawing.Point(4, 22);
      this.tabExistingJobs.Name = "tabExistingJobs";
      this.tabExistingJobs.Size = new Size(877, 774);
      this.tabExistingJobs.TabIndex = 13;
      this.tabExistingJobs.Text = "ExistingJobs";
      this.btnxxExistingJobBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnxxExistingJobBack.BackColor = SystemColors.Control;
      this.btnxxExistingJobBack.BackgroundImage = (Image) componentResourceManager.GetObject("btnxxExistingJobBack.BackgroundImage");
      this.btnxxExistingJobBack.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxxExistingJobBack.Cursor = Cursors.Hand;
      this.btnxxExistingJobBack.Location = new System.Drawing.Point(3, 627);
      this.btnxxExistingJobBack.Name = "btnxxExistingJobBack";
      this.btnxxExistingJobBack.Size = new Size(62, 45);
      this.btnxxExistingJobBack.TabIndex = 179;
      this.btnxxExistingJobBack.UseVisualStyleBackColor = false;
      this.btnxxExistingJobNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnxxExistingJobNext.BackColor = SystemColors.Control;
      this.btnxxExistingJobNext.BackgroundImage = (Image) componentResourceManager.GetObject("btnxxExistingJobNext.BackgroundImage");
      this.btnxxExistingJobNext.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxxExistingJobNext.Cursor = Cursors.Hand;
      this.btnxxExistingJobNext.Location = new System.Drawing.Point(812, 627);
      this.btnxxExistingJobNext.Name = "btnxxExistingJobNext";
      this.btnxxExistingJobNext.Size = new Size(62, 45);
      this.btnxxExistingJobNext.TabIndex = 178;
      this.btnxxExistingJobNext.UseVisualStyleBackColor = false;
      this.dgExistingVisits.AllowUserToAddRows = false;
      this.dgExistingVisits.AllowUserToDeleteRows = false;
      this.dgExistingVisits.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dgExistingVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgExistingVisits.ColumnHeadersVisible = false;
      this.dgExistingVisits.Location = new System.Drawing.Point(40, 103);
      this.dgExistingVisits.MultiSelect = false;
      this.dgExistingVisits.Name = "dgExistingVisits";
      this.dgExistingVisits.ReadOnly = true;
      this.dgExistingVisits.RowHeadersVisible = false;
      this.dgExistingVisits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgExistingVisits.ShowCellErrors = false;
      this.dgExistingVisits.ShowEditingIcon = false;
      this.dgExistingVisits.ShowRowErrors = false;
      this.dgExistingVisits.Size = new Size(805, 164);
      this.dgExistingVisits.TabIndex = 177;
      this.Label29.AutoSize = true;
      this.Label29.Font = new Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label29.Location = new System.Drawing.Point(314, 35);
      this.Label29.Name = "Label29";
      this.Label29.Size = new Size(249, 25);
      this.Label29.TabIndex = 5;
      this.Label29.Text = "New Or Existing Job";
      this.btnxxNewJob.BackColor = SystemColors.Control;
      this.btnxxNewJob.Cursor = Cursors.Hand;
      this.btnxxNewJob.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnxxNewJob.Location = new System.Drawing.Point(173, 319);
      this.btnxxNewJob.Name = "btnxxNewJob";
      this.btnxxNewJob.Size = new Size(511, 72);
      this.btnxxNewJob.TabIndex = 4;
      this.btnxxNewJob.Text = "New Job";
      this.btnxxNewJob.UseVisualStyleBackColor = false;
      this.tabAdditional.Controls.Add((Control) this.chkCert);
      this.tabAdditional.Controls.Add((Control) this.lblcert);
      this.tabAdditional.Controls.Add((Control) this.btnxx4);
      this.tabAdditional.Controls.Add((Control) this.lblCoverplanServ);
      this.tabAdditional.Controls.Add((Control) this.Label22);
      this.tabAdditional.Controls.Add((Control) this.Label21);
      this.tabAdditional.Controls.Add((Control) this.cboAdditional);
      this.tabAdditional.Controls.Add((Control) this.DGAdditional);
      this.tabAdditional.Controls.Add((Control) this.btnAdditionalMinus);
      this.tabAdditional.Controls.Add((Control) this.btnAdditionalPlus);
      this.tabAdditional.Controls.Add((Control) this.btnxxAdditionalNext);
      this.tabAdditional.Location = new System.Drawing.Point(4, 22);
      this.tabAdditional.Name = "tabAdditional";
      this.tabAdditional.Size = new Size(877, 774);
      this.tabAdditional.TabIndex = 10;
      this.tabAdditional.Text = "Additional Items";
      this.tabAdditional.UseVisualStyleBackColor = true;
      this.chkCert.CheckAlign = ContentAlignment.MiddleCenter;
      this.chkCert.Font = new Font("Verdana", 20.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chkCert.Location = new System.Drawing.Point(561, 431);
      this.chkCert.Name = "chkCert";
      this.chkCert.Size = new Size(40, 40);
      this.chkCert.TabIndex = 184;
      this.chkCert.UseVisualStyleBackColor = true;
      this.lblcert.AutoSize = true;
      this.lblcert.Font = new Font("Verdana", 10f);
      this.lblcert.ForeColor = Color.Maroon;
      this.lblcert.Location = new System.Drawing.Point(311, 442);
      this.lblcert.Name = "lblcert";
      this.lblcert.Size = new Size(145, 17);
      this.lblcert.TabIndex = 183;
      this.lblcert.Text = "L/L Cert Required? ";
      this.lblcert.Visible = false;
      this.btnxx4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnxx4.BackColor = SystemColors.Control;
      this.btnxx4.BackgroundImage = (Image) componentResourceManager.GetObject("btnxx4.BackgroundImage");
      this.btnxx4.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxx4.Cursor = Cursors.Hand;
      this.btnxx4.Location = new System.Drawing.Point(3, 627);
      this.btnxx4.Name = "btnxx4";
      this.btnxx4.Size = new Size(62, 45);
      this.btnxx4.TabIndex = 182;
      this.btnxx4.UseVisualStyleBackColor = false;
      this.lblCoverplanServ.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblCoverplanServ.Font = new Font("Verdana", 16f, FontStyle.Bold);
      this.lblCoverplanServ.ForeColor = Color.Red;
      this.lblCoverplanServ.Location = new System.Drawing.Point(145, 80);
      this.lblCoverplanServ.Name = "lblCoverplanServ";
      this.lblCoverplanServ.Size = new Size(594, 106);
      this.lblCoverplanServ.TabIndex = 181;
      this.lblCoverplanServ.Text = "This Site Has A Coverplan Service Outstanding";
      this.lblCoverplanServ.TextAlign = ContentAlignment.MiddleCenter;
      this.lblCoverplanServ.Visible = false;
      this.Label22.AutoSize = true;
      this.Label22.Font = new Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label22.Location = new System.Drawing.Point(349, 35);
      this.Label22.Name = "Label22";
      this.Label22.Size = new Size(208, 25);
      this.Label22.TabIndex = 179;
      this.Label22.Text = "Additional Items";
      this.Label21.AutoSize = true;
      this.Label21.Font = new Font("Verdana", 10f);
      this.Label21.Location = new System.Drawing.Point(138, 240);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(114, 17);
      this.Label21.TabIndex = 178;
      this.Label21.Text = "Additional Item";
      this.cboAdditional.Font = new Font("Verdana", 9f);
      this.cboAdditional.FormattingEnabled = true;
      this.cboAdditional.Location = new System.Drawing.Point(314, 238);
      this.cboAdditional.Name = "cboAdditional";
      this.cboAdditional.Size = new Size(285, 22);
      this.cboAdditional.TabIndex = 177;
      this.DGAdditional.AllowUserToAddRows = false;
      this.DGAdditional.AllowUserToDeleteRows = false;
      this.DGAdditional.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DGAdditional.ColumnHeadersVisible = false;
      this.DGAdditional.Location = new System.Drawing.Point(141, 294);
      this.DGAdditional.MultiSelect = false;
      this.DGAdditional.Name = "DGAdditional";
      this.DGAdditional.ReadOnly = true;
      this.DGAdditional.RowHeadersVisible = false;
      this.DGAdditional.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.DGAdditional.ShowCellErrors = false;
      this.DGAdditional.ShowEditingIcon = false;
      this.DGAdditional.ShowRowErrors = false;
      this.DGAdditional.Size = new Size(598, 113);
      this.DGAdditional.TabIndex = 176;
      this.btnAdditionalMinus.Location = new System.Drawing.Point(406, 266);
      this.btnAdditionalMinus.Name = "btnAdditionalMinus";
      this.btnAdditionalMinus.Size = new Size(39, 23);
      this.btnAdditionalMinus.TabIndex = 175;
      this.btnAdditionalMinus.Text = "-";
      this.btnAdditionalMinus.UseVisualStyleBackColor = true;
      this.btnAdditionalPlus.Location = new System.Drawing.Point(451, 266);
      this.btnAdditionalPlus.Name = "btnAdditionalPlus";
      this.btnAdditionalPlus.Size = new Size(39, 23);
      this.btnAdditionalPlus.TabIndex = 174;
      this.btnAdditionalPlus.Text = "+";
      this.btnAdditionalPlus.UseVisualStyleBackColor = true;
      this.btnxxAdditionalNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnxxAdditionalNext.BackColor = SystemColors.Control;
      this.btnxxAdditionalNext.BackgroundImage = (Image) componentResourceManager.GetObject("btnxxAdditionalNext.BackgroundImage");
      this.btnxxAdditionalNext.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxxAdditionalNext.Cursor = Cursors.Hand;
      this.btnxxAdditionalNext.Location = new System.Drawing.Point(812, 627);
      this.btnxxAdditionalNext.Name = "btnxxAdditionalNext";
      this.btnxxAdditionalNext.Size = new Size(62, 45);
      this.btnxxAdditionalNext.TabIndex = 180;
      this.btnxxAdditionalNext.UseVisualStyleBackColor = false;
      this.btnxxAdditionalNext.Visible = false;
      this.TabCharging.Controls.Add((Control) this.lblUnabletoConfirm);
      this.TabCharging.Controls.Add((Control) this.btnxx5);
      this.TabCharging.Controls.Add((Control) this.Label16);
      this.TabCharging.Controls.Add((Control) this.cboPayTerms);
      this.TabCharging.Controls.Add((Control) this.chkRecall);
      this.TabCharging.Controls.Add((Control) this.Label19);
      this.TabCharging.Controls.Add((Control) this.Label18);
      this.TabCharging.Controls.Add((Control) this.pnlCharge);
      this.TabCharging.Controls.Add((Control) this.txtPayInst);
      this.TabCharging.Controls.Add((Control) this.btnxxChargeNext);
      this.TabCharging.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.TabCharging.Location = new System.Drawing.Point(4, 22);
      this.TabCharging.Name = "TabCharging";
      this.TabCharging.Size = new Size(877, 774);
      this.TabCharging.TabIndex = 9;
      this.TabCharging.Text = "Charging";
      this.TabCharging.UseVisualStyleBackColor = true;
      this.lblUnabletoConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblUnabletoConfirm.Font = new Font("Verdana", 16f, FontStyle.Bold);
      this.lblUnabletoConfirm.ForeColor = Color.Red;
      this.lblUnabletoConfirm.Location = new System.Drawing.Point(141, 269);
      this.lblUnabletoConfirm.Name = "lblUnabletoConfirm";
      this.lblUnabletoConfirm.Size = new Size(594, 106);
      this.lblUnabletoConfirm.TabIndex = 182;
      this.lblUnabletoConfirm.Text = "Unable to confirm if any payment is due please check notes";
      this.lblUnabletoConfirm.TextAlign = ContentAlignment.MiddleCenter;
      this.lblUnabletoConfirm.Visible = false;
      this.btnxx5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnxx5.BackColor = SystemColors.Control;
      this.btnxx5.BackgroundImage = (Image) componentResourceManager.GetObject("btnxx5.BackgroundImage");
      this.btnxx5.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxx5.Cursor = Cursors.Hand;
      this.btnxx5.Location = new System.Drawing.Point(3, 627);
      this.btnxx5.Name = "btnxx5";
      this.btnxx5.Size = new Size(62, 45);
      this.btnxx5.TabIndex = 176;
      this.btnxx5.UseVisualStyleBackColor = false;
      this.Label16.AutoSize = true;
      this.Label16.Font = new Font("Verdana", 10f);
      this.Label16.Location = new System.Drawing.Point(142, 561);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(115, 17);
      this.Label16.TabIndex = 175;
      this.Label16.Text = "Payment Terms";
      this.cboPayTerms.Font = new Font("Verdana", 9f);
      this.cboPayTerms.FormattingEnabled = true;
      this.cboPayTerms.Location = new System.Drawing.Point(318, 561);
      this.cboPayTerms.Name = "cboPayTerms";
      this.cboPayTerms.Size = new Size(285, 22);
      this.cboPayTerms.TabIndex = 174;
      this.chkRecall.AutoSize = true;
      this.chkRecall.Font = new Font("Verdana", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chkRecall.ForeColor = Color.Red;
      this.chkRecall.Location = new System.Drawing.Point(445, 239);
      this.chkRecall.Name = "chkRecall";
      this.chkRecall.Size = new Size(15, 14);
      this.chkRecall.TabIndex = 168;
      this.chkRecall.UseVisualStyleBackColor = true;
      this.Label19.AutoSize = true;
      this.Label19.Font = new Font("Verdana", 10f);
      this.Label19.Location = new System.Drawing.Point(142, 237);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(47, 17);
      this.Label19.TabIndex = 167;
      this.Label19.Text = "Recall";
      this.Label18.AutoSize = true;
      this.Label18.Font = new Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label18.Location = new System.Drawing.Point(389, 28);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(118, 25);
      this.Label18.TabIndex = 166;
      this.Label18.Text = "Charging";
      this.pnlCharge.Controls.Add((Control) this.picTick);
      this.pnlCharge.Controls.Add((Control) this.Label35);
      this.pnlCharge.Controls.Add((Control) this.txtDiscountCode);
      this.pnlCharge.Controls.Add((Control) this.Label17);
      this.pnlCharge.Controls.Add((Control) this.txtCharge);
      this.pnlCharge.Controls.Add((Control) this.picCross);
      this.pnlCharge.Location = new System.Drawing.Point(132, 458);
      this.pnlCharge.Name = "pnlCharge";
      this.pnlCharge.Size = new Size(611, 78);
      this.pnlCharge.TabIndex = 165;
      this.picTick.BackColor = Color.White;
      this.picTick.BackgroundImage = (Image) FSM.My.Resources.Resources.tick;
      this.picTick.Cursor = Cursors.No;
      this.picTick.Image = (Image) FSM.My.Resources.Resources.tick;
      this.picTick.InitialImage = (Image) FSM.My.Resources.Resources.tick;
      this.picTick.Location = new System.Drawing.Point(407, 6);
      this.picTick.Name = "picTick";
      this.picTick.Size = new Size(33, 27);
      this.picTick.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picTick.TabIndex = 183;
      this.picTick.TabStop = false;
      this.picTick.Visible = false;
      this.Label35.AutoSize = true;
      this.Label35.Font = new Font("Verdana", 10f);
      this.Label35.Location = new System.Drawing.Point(10, 11);
      this.Label35.Name = "Label35";
      this.Label35.Size = new Size(132, 17);
      this.Label35.TabIndex = 168;
      this.Label35.Text = "Promotional Code";
      this.txtDiscountCode.Location = new System.Drawing.Point((int) byte.MaxValue, 6);
      this.txtDiscountCode.Name = "txtDiscountCode";
      this.txtDiscountCode.Size = new Size(123, 27);
      this.txtDiscountCode.TabIndex = 167;
      this.txtDiscountCode.TextAlign = HorizontalAlignment.Center;
      this.Label17.AutoSize = true;
      this.Label17.Font = new Font("Verdana", 10f);
      this.Label17.Location = new System.Drawing.Point(10, 44);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(232, 17);
      this.Label17.TabIndex = 166;
      this.Label17.Text = "Payment On Completion Charge";
      this.txtCharge.Location = new System.Drawing.Point((int) byte.MaxValue, 39);
      this.txtCharge.Name = "txtCharge";
      this.txtCharge.Size = new Size(123, 27);
      this.txtCharge.TabIndex = 165;
      this.txtCharge.Text = "0";
      this.txtCharge.TextAlign = HorizontalAlignment.Center;
      this.picCross.BackColor = Color.White;
      this.picCross.BackgroundImage = (Image) FSM.My.Resources.Resources.cross;
      this.picCross.Cursor = Cursors.No;
      this.picCross.Image = (Image) FSM.My.Resources.Resources.cross;
      this.picCross.InitialImage = (Image) FSM.My.Resources.Resources.cross;
      this.picCross.Location = new System.Drawing.Point(407, 6);
      this.picCross.Name = "picCross";
      this.picCross.Size = new Size(33, 27);
      this.picCross.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picCross.TabIndex = 184;
      this.picCross.TabStop = false;
      this.picCross.Visible = false;
      this.txtPayInst.Location = new System.Drawing.Point(145, 75);
      this.txtPayInst.Multiline = true;
      this.txtPayInst.Name = "txtPayInst";
      this.txtPayInst.ReadOnly = true;
      this.txtPayInst.Size = new Size(598, 141);
      this.txtPayInst.TabIndex = 0;
      this.txtPayInst.TextAlign = HorizontalAlignment.Center;
      this.btnxxChargeNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnxxChargeNext.BackColor = SystemColors.Control;
      this.btnxxChargeNext.BackgroundImage = (Image) componentResourceManager.GetObject("btnxxChargeNext.BackgroundImage");
      this.btnxxChargeNext.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxxChargeNext.Cursor = Cursors.Hand;
      this.btnxxChargeNext.Location = new System.Drawing.Point(812, 627);
      this.btnxxChargeNext.Name = "btnxxChargeNext";
      this.btnxxChargeNext.Size = new Size(62, 45);
      this.btnxxChargeNext.TabIndex = 162;
      this.btnxxChargeNext.UseVisualStyleBackColor = false;
      this.btnxxChargeNext.Visible = false;
      this.TabBook.Controls.Add((Control) this.btnOption8);
      this.TabBook.Controls.Add((Control) this.btnOption7);
      this.TabBook.Controls.Add((Control) this.btnOption6);
      this.TabBook.Controls.Add((Control) this.btnOption5);
      this.TabBook.Controls.Add((Control) this.btnRefresh);
      this.TabBook.Controls.Add((Control) this.Label31);
      this.TabBook.Controls.Add((Control) this.Label24);
      this.TabBook.Controls.Add((Control) this.cboEngineer);
      this.TabBook.Controls.Add((Control) this.btnxx6);
      this.TabBook.Controls.Add((Control) this.gpCombo);
      this.TabBook.Controls.Add((Control) this.lblBookText);
      this.TabBook.Controls.Add((Control) this.Label23);
      this.TabBook.Controls.Add((Control) this.dtpFromDate);
      this.TabBook.Controls.Add((Control) this.btnOption10);
      this.TabBook.Controls.Add((Control) this.btnOption4);
      this.TabBook.Controls.Add((Control) this.btnOption3);
      this.TabBook.Controls.Add((Control) this.btnOption2);
      this.TabBook.Controls.Add((Control) this.btnOption1);
      this.TabBook.Controls.Add((Control) this.chkKeepTogether);
      this.TabBook.Location = new System.Drawing.Point(4, 22);
      this.TabBook.Name = "TabBook";
      this.TabBook.Size = new Size(877, 774);
      this.TabBook.TabIndex = 11;
      this.TabBook.Text = "Book Visit";
      this.TabBook.UseVisualStyleBackColor = true;
      this.btnOption8.BackColor = Color.PaleGreen;
      this.btnOption8.Cursor = Cursors.Hand;
      this.btnOption8.Font = new Font("Verdana", 14f);
      this.btnOption8.ImageAlign = ContentAlignment.TopCenter;
      this.btnOption8.Location = new System.Drawing.Point(441, 422);
      this.btnOption8.Name = "btnOption8";
      this.btnOption8.Size = new Size(404, 72);
      this.btnOption8.TabIndex = 187;
      this.btnOption8.Text = "Searching.....";
      this.btnOption8.TextAlign = ContentAlignment.TopCenter;
      this.btnOption8.UseVisualStyleBackColor = false;
      this.btnOption7.BackColor = Color.PaleGreen;
      this.btnOption7.Cursor = Cursors.Hand;
      this.btnOption7.Font = new Font("Verdana", 14f);
      this.btnOption7.ImageAlign = ContentAlignment.TopCenter;
      this.btnOption7.Location = new System.Drawing.Point(33, 422);
      this.btnOption7.Name = "btnOption7";
      this.btnOption7.Size = new Size(404, 72);
      this.btnOption7.TabIndex = 186;
      this.btnOption7.Text = "Searching.....";
      this.btnOption7.TextAlign = ContentAlignment.TopCenter;
      this.btnOption7.UseVisualStyleBackColor = false;
      this.btnOption6.BackColor = Color.PaleGreen;
      this.btnOption6.Cursor = Cursors.Hand;
      this.btnOption6.Font = new Font("Verdana", 14f);
      this.btnOption6.ImageAlign = ContentAlignment.TopCenter;
      this.btnOption6.Location = new System.Drawing.Point(441, 344);
      this.btnOption6.Name = "btnOption6";
      this.btnOption6.Size = new Size(404, 72);
      this.btnOption6.TabIndex = 185;
      this.btnOption6.Text = "Searching.....";
      this.btnOption6.TextAlign = ContentAlignment.TopCenter;
      this.btnOption6.UseVisualStyleBackColor = false;
      this.btnOption5.BackColor = Color.PaleGreen;
      this.btnOption5.Cursor = Cursors.Hand;
      this.btnOption5.Font = new Font("Verdana", 14f);
      this.btnOption5.ImageAlign = ContentAlignment.TopCenter;
      this.btnOption5.Location = new System.Drawing.Point(33, 344);
      this.btnOption5.Name = "btnOption5";
      this.btnOption5.Size = new Size(404, 72);
      this.btnOption5.TabIndex = 184;
      this.btnOption5.Text = "Searching.....";
      this.btnOption5.TextAlign = ContentAlignment.TopCenter;
      this.btnOption5.UseVisualStyleBackColor = false;
      this.btnRefresh.Location = new System.Drawing.Point(754, 137);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new Size(75, 23);
      this.btnRefresh.TabIndex = 183;
      this.btnRefresh.Text = "Refresh";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.Label31.AutoSize = true;
      this.Label31.Location = new System.Drawing.Point(167, 575);
      this.Label31.Name = "Label31";
      this.Label31.Size = new Size(539, 13);
      this.Label31.TabIndex = 182;
      this.Label31.Text = "Green = Best Selection(s)   , Orange = Not as efficient option ,  Red = Only use if authorised";
      this.Label24.AutoSize = true;
      this.Label24.Font = new Font("Verdana", 10f);
      this.Label24.Location = new System.Drawing.Point(42, 140);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(126, 17);
      this.Label24.TabIndex = 181;
      this.Label24.Text = "Specific Engineer";
      this.cboEngineer.Font = new Font("Verdana", 9f);
      this.cboEngineer.FormattingEnabled = true;
      this.cboEngineer.Location = new System.Drawing.Point(215, 138);
      this.cboEngineer.Name = "cboEngineer";
      this.cboEngineer.Size = new Size(176, 22);
      this.cboEngineer.TabIndex = 180;
      this.btnxx6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnxx6.BackColor = SystemColors.Control;
      this.btnxx6.BackgroundImage = (Image) componentResourceManager.GetObject("btnxx6.BackgroundImage");
      this.btnxx6.BackgroundImageLayout = ImageLayout.Stretch;
      this.btnxx6.Cursor = Cursors.Hand;
      this.btnxx6.Location = new System.Drawing.Point(3, 627);
      this.btnxx6.Name = "btnxx6";
      this.btnxx6.Size = new Size(62, 45);
      this.btnxx6.TabIndex = 179;
      this.btnxx6.UseVisualStyleBackColor = false;
      this.gpCombo.Controls.Add((Control) this.cboAppointment);
      this.gpCombo.ForeColor = SystemColors.ActiveCaptionText;
      this.gpCombo.Location = new System.Drawing.Point(401, 86);
      this.gpCombo.Name = "gpCombo";
      this.gpCombo.Size = new Size(434, 51);
      this.gpCombo.TabIndex = 178;
      this.gpCombo.TabStop = false;
      this.gpCombo.Text = "Appointment Type";
      this.cboAppointment.Font = new Font("Verdana", 9f);
      this.cboAppointment.FormattingEnabled = true;
      this.cboAppointment.Location = new System.Drawing.Point(6, 16);
      this.cboAppointment.Name = "cboAppointment";
      this.cboAppointment.Size = new Size(422, 22);
      this.cboAppointment.TabIndex = 175;
      this.lblBookText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblBookText.Font = new Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblBookText.Location = new System.Drawing.Point(3, 49);
      this.lblBookText.Name = "lblBookText";
      this.lblBookText.Size = new Size(871, 34);
      this.lblBookText.TabIndex = 177;
      this.lblBookText.Text = "Booking Visits";
      this.lblBookText.TextAlign = ContentAlignment.MiddleCenter;
      this.Label23.AutoSize = true;
      this.Label23.Font = new Font("Verdana", 10f);
      this.Label23.Location = new System.Drawing.Point(42, 104);
      this.Label23.Name = "Label23";
      this.Label23.Size = new Size(106, 17);
      this.Label23.TabIndex = 176;
      this.Label23.Text = "Booking From";
      this.dtpFromDate.Location = new System.Drawing.Point(215, 102);
      this.dtpFromDate.Name = "dtpFromDate";
      this.dtpFromDate.Size = new Size(176, 21);
      this.dtpFromDate.TabIndex = 175;
      this.btnOption10.BackColor = Color.PaleGreen;
      this.btnOption10.Cursor = Cursors.Hand;
      this.btnOption10.Font = new Font("Verdana", 14f);
      this.btnOption10.ImageAlign = ContentAlignment.TopCenter;
      this.btnOption10.Location = new System.Drawing.Point(33, 500);
      this.btnOption10.Name = "btnOption10";
      this.btnOption10.Size = new Size(812, 72);
      this.btnOption10.TabIndex = 174;
      this.btnOption10.Text = "Searching.....";
      this.btnOption10.TextAlign = ContentAlignment.TopCenter;
      this.btnOption10.UseVisualStyleBackColor = false;
      this.btnOption4.BackColor = Color.PaleGreen;
      this.btnOption4.Cursor = Cursors.Hand;
      this.btnOption4.Font = new Font("Verdana", 14f);
      this.btnOption4.ImageAlign = ContentAlignment.TopCenter;
      this.btnOption4.Location = new System.Drawing.Point(441, 266);
      this.btnOption4.Name = "btnOption4";
      this.btnOption4.Size = new Size(404, 72);
      this.btnOption4.TabIndex = 173;
      this.btnOption4.Text = "Searching.....";
      this.btnOption4.TextAlign = ContentAlignment.TopCenter;
      this.btnOption4.UseVisualStyleBackColor = false;
      this.btnOption3.BackColor = Color.PaleGreen;
      this.btnOption3.Cursor = Cursors.Hand;
      this.btnOption3.Font = new Font("Verdana", 14f);
      this.btnOption3.ImageAlign = ContentAlignment.TopCenter;
      this.btnOption3.Location = new System.Drawing.Point(33, 266);
      this.btnOption3.Name = "btnOption3";
      this.btnOption3.Size = new Size(404, 72);
      this.btnOption3.TabIndex = 172;
      this.btnOption3.Text = "Searching.....";
      this.btnOption3.TextAlign = ContentAlignment.TopCenter;
      this.btnOption3.UseVisualStyleBackColor = false;
      this.btnOption2.BackColor = Color.PaleGreen;
      this.btnOption2.Cursor = Cursors.Hand;
      this.btnOption2.Font = new Font("Verdana", 14f);
      this.btnOption2.ImageAlign = ContentAlignment.TopCenter;
      this.btnOption2.Location = new System.Drawing.Point(441, 188);
      this.btnOption2.Name = "btnOption2";
      this.btnOption2.Size = new Size(404, 72);
      this.btnOption2.TabIndex = 171;
      this.btnOption2.Text = "Searching.....";
      this.btnOption2.TextAlign = ContentAlignment.TopCenter;
      this.btnOption2.UseVisualStyleBackColor = false;
      this.btnOption1.BackColor = Color.PaleGreen;
      this.btnOption1.Cursor = Cursors.Hand;
      this.btnOption1.Font = new Font("Verdana", 14f);
      this.btnOption1.ImageAlign = ContentAlignment.TopCenter;
      this.btnOption1.Location = new System.Drawing.Point(31, 188);
      this.btnOption1.Name = "btnOption1";
      this.btnOption1.Size = new Size(406, 72);
      this.btnOption1.TabIndex = 170;
      this.btnOption1.Text = "Searching.....";
      this.btnOption1.TextAlign = ContentAlignment.TopCenter;
      this.btnOption1.UseVisualStyleBackColor = false;
      this.chkKeepTogether.AutoSize = true;
      this.chkKeepTogether.Checked = true;
      this.chkKeepTogether.CheckState = CheckState.Checked;
      this.chkKeepTogether.Font = new Font("Verdana", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chkKeepTogether.ForeColor = Color.Black;
      this.chkKeepTogether.Location = new System.Drawing.Point(356, 17);
      this.chkKeepTogether.Name = "chkKeepTogether";
      this.chkKeepTogether.Size = new Size(196, 22);
      this.chkKeepTogether.TabIndex = 169;
      this.chkKeepTogether.Text = "Keep Visits Together";
      this.chkKeepTogether.UseVisualStyleBackColor = true;
      this.tcComplete.Controls.Add((Control) this.btnDocument);
      this.tcComplete.Controls.Add((Control) this.lblBookedInfo);
      this.tcComplete.Controls.Add((Control) this.Label27);
      this.tcComplete.Controls.Add((Control) this.btnRestart);
      this.tcComplete.Location = new System.Drawing.Point(4, 22);
      this.tcComplete.Name = "tcComplete";
      this.tcComplete.Size = new Size(877, 774);
      this.tcComplete.TabIndex = 12;
      this.tcComplete.Text = "Complete";
      this.tcComplete.UseVisualStyleBackColor = true;
      this.btnDocument.Location = new System.Drawing.Point(84, 311);
      this.btnDocument.Name = "btnDocument";
      this.btnDocument.Size = new Size(708, 23);
      this.btnDocument.TabIndex = 180;
      this.btnDocument.Text = "Add Documentation";
      this.btnDocument.UseVisualStyleBackColor = true;
      this.lblBookedInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.lblBookedInfo.Font = new Font("Verdana", 10f, FontStyle.Bold);
      this.lblBookedInfo.Location = new System.Drawing.Point(8, 236);
      this.lblBookedInfo.Name = "lblBookedInfo";
      this.lblBookedInfo.Size = new Size(856, 32);
      this.lblBookedInfo.TabIndex = 179;
      this.lblBookedInfo.Text = "Booked with";
      this.lblBookedInfo.TextAlign = ContentAlignment.MiddleCenter;
      this.Label27.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Label27.Font = new Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label27.Location = new System.Drawing.Point(3, 185);
      this.Label27.Name = "Label27";
      this.Label27.Size = new Size(871, 34);
      this.Label27.TabIndex = 178;
      this.Label27.Text = "Bookings Complete";
      this.Label27.TextAlign = ContentAlignment.MiddleCenter;
      this.btnRestart.BackColor = Color.PaleGreen;
      this.btnRestart.Cursor = Cursors.Hand;
      this.btnRestart.Font = new Font("Verdana", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnRestart.Location = new System.Drawing.Point(84, 334);
      this.btnRestart.Name = "btnRestart";
      this.btnRestart.Size = new Size(708, 72);
      this.btnRestart.TabIndex = 171;
      this.btnRestart.Text = "Restart";
      this.btnRestart.UseVisualStyleBackColor = false;
      this.ToolTip1.AutomaticDelay = 100;
      this.ToolTip1.AutoPopDelay = 5000;
      this.ToolTip1.InitialDelay = 20;
      this.ToolTip1.IsBalloon = true;
      this.ToolTip1.ReshowDelay = 10;
      this.Controls.Add((Control) this.tcSites);
      this.Name = nameof (UCJobWizard);
      this.Size = new Size(885, 800);
      this.tabJobDetails.ResumeLayout(false);
      this.tabJobDetails.PerformLayout();
      this.pnlTimeReq.ResumeLayout(false);
      this.pnlTimeReq.PerformLayout();
      this.pnlTypeOfWorks.ResumeLayout(false);
      this.pnlTypeOfWorks.PerformLayout();
      this.pnlSymptoms.ResumeLayout(false);
      this.pnlSymptoms.PerformLayout();
      ((ISupportInitialize) this.DGSymptoms).EndInit();
      this.tabAppliance.ResumeLayout(false);
      this.tabAppliance.PerformLayout();
      ((ISupportInitialize) this.DgMain).EndInit();
      this.tabJobType.ResumeLayout(false);
      this.tabJobType.PerformLayout();
      this.pnlSOR.ResumeLayout(false);
      this.pnlSOR.PerformLayout();
      ((ISupportInitialize) this.DGSOR).EndInit();
      this.tabProp.ResumeLayout(false);
      this.tabProp.PerformLayout();
      ((ISupportInitialize) this.DGVSites).EndInit();
      this.tcSites.ResumeLayout(false);
      this.tabExistingJobs.ResumeLayout(false);
      this.tabExistingJobs.PerformLayout();
      ((ISupportInitialize) this.dgExistingVisits).EndInit();
      this.tabAdditional.ResumeLayout(false);
      this.tabAdditional.PerformLayout();
      ((ISupportInitialize) this.DGAdditional).EndInit();
      this.TabCharging.ResumeLayout(false);
      this.TabCharging.PerformLayout();
      this.pnlCharge.ResumeLayout(false);
      this.pnlCharge.PerformLayout();
      ((ISupportInitialize) this.picTick).EndInit();
      ((ISupportInitialize) this.picCross).EndInit();
      this.TabBook.ResumeLayout(false);
      this.TabBook.PerformLayout();
      this.gpCombo.ResumeLayout(false);
      this.tcComplete.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.tcSites.TabPages.Clear();
      this.tcSites.TabPages.Add(this.tabProp);
    }

    public object LoadedItem
    {
      get
      {
        object obj;
        return obj;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Form FromForm
    {
      get
      {
        return this._FromForm;
      }
      set
      {
        this._FromForm = value;
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

    public DataView DGVAdditional
    {
      get
      {
        return this._DGVAdditional;
      }
      set
      {
        this._DGVAdditional = value;
        this._DGVAdditional.Table.TableName = "Additional";
        this._DGVAdditional.AllowNew = false;
        this._DGVAdditional.AllowEdit = true;
        this._DGVAdditional.AllowDelete = false;
        this.DGAdditional.DataSource = (object) this._DGVAdditional;
      }
    }

    public DataView SORDataView
    {
      get
      {
        return this._SORDataView;
      }
      set
      {
        this._SORDataView = value;
        this._SORDataView.Table.TableName = "SOR";
        this._SORDataView.AllowNew = false;
        this._SORDataView.AllowEdit = true;
        this._SORDataView.AllowDelete = false;
        this.DGSOR.DataSource = (object) this.SORDataView;
      }
    }

    public DataView SympDataView
    {
      get
      {
        return this._SORSymp;
      }
      set
      {
        this._SORSymp = value;
        this._SORSymp.Table.TableName = "Symptoms";
        this._SORSymp.AllowNew = false;
        this._SORSymp.AllowEdit = true;
        this._SORSymp.AllowDelete = false;
        this.DGSymptoms.DataSource = (object) this.SympDataView;
      }
    }

    private DataGridViewRow SelectedMainDataRow
    {
      get
      {
        return this.DgMain.CurrentRow != null && this.DgMain.CurrentRow.Index != -1 ? this.DgMain.CurrentRow : (DataGridViewRow) null;
      }
    }

    public DataView SiteDT
    {
      get
      {
        return this._SiteDT;
      }
      set
      {
        this._SiteDT = value;
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
      }
    }

    private DataGridViewRow SelecteddgvSitesDataRow
    {
      get
      {
        return this.DGVSites.CurrentRow != null && this.DGVSites.CurrentRow.Index != -1 ? this.DGVSites.CurrentRow : (DataGridViewRow) null;
      }
    }

    private FSM.Entity.Customers.Customer theCustomer
    {
      get
      {
        return this._theCustomer;
      }
      set
      {
        this._theCustomer = value;
      }
    }

    private int SelectedCustomerID
    {
      get
      {
        return this._SelectedCustomerID;
      }
      set
      {
        this._SelectedCustomerID = value;
      }
    }

    public void SetupSiteDataGridView()
    {
      Helper.SetUpDataGridView(this.DGVSites, false);
      this.DGVSites.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.DGVSites.AutoGenerateColumns = false;
      this.DGVSites.Columns.Clear();
      this.DGVSites.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "Terms";
      viewTextBoxColumn1.FillWeight = 25f;
      viewTextBoxColumn1.DataPropertyName = "Terms";
      viewTextBoxColumn1.Name = "Terms";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "ContractID";
      viewTextBoxColumn2.FillWeight = 25f;
      viewTextBoxColumn2.DataPropertyName = "ContractID";
      viewTextBoxColumn2.Name = "ContractID";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = false;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "SiteID";
      viewTextBoxColumn3.FillWeight = 25f;
      viewTextBoxColumn3.DataPropertyName = "siteid";
      viewTextBoxColumn3.Name = "siteid";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = false;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Customer";
      viewTextBoxColumn4.FillWeight = 25f;
      viewTextBoxColumn4.DataPropertyName = "Customer";
      viewTextBoxColumn4.Name = "Customer";
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.Visible = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Automatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Site Name";
      viewTextBoxColumn5.DataPropertyName = "SiteName";
      viewTextBoxColumn5.FillWeight = 20f;
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Automatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.FillWeight = 35f;
      viewTextBoxColumn6.HeaderText = "Address 1";
      viewTextBoxColumn6.DataPropertyName = "Address1";
      viewTextBoxColumn6.Name = "Address1";
      viewTextBoxColumn6.ReadOnly = true;
      viewTextBoxColumn6.Visible = true;
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Automatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.FillWeight = 30f;
      viewTextBoxColumn7.HeaderText = "Address 2";
      viewTextBoxColumn7.DataPropertyName = "Address2";
      viewTextBoxColumn7.Name = "Address2";
      viewTextBoxColumn7.ReadOnly = true;
      viewTextBoxColumn7.Visible = true;
      viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Automatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.FillWeight = 30f;
      viewTextBoxColumn8.HeaderText = "Address 3";
      viewTextBoxColumn8.DataPropertyName = "Address3";
      viewTextBoxColumn8.Name = "Address3";
      viewTextBoxColumn8.ReadOnly = true;
      viewTextBoxColumn8.Visible = false;
      viewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.Automatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
      DataGridViewTextBoxColumn viewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn9.HeaderText = "Postcode";
      viewTextBoxColumn9.DataPropertyName = "Postcode";
      viewTextBoxColumn9.Name = "Postcode";
      viewTextBoxColumn9.FillWeight = 25f;
      viewTextBoxColumn9.ReadOnly = true;
      viewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.Automatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn9);
      DataGridViewTextBoxColumn viewTextBoxColumn10 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn10.HeaderText = "Tel No.";
      viewTextBoxColumn10.DataPropertyName = "TelephoneNum";
      viewTextBoxColumn10.Name = "TelephoneNum";
      viewTextBoxColumn10.FillWeight = 20f;
      viewTextBoxColumn10.ReadOnly = true;
      viewTextBoxColumn10.SortMode = DataGridViewColumnSortMode.Automatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn10);
      DataGridViewTextBoxColumn viewTextBoxColumn11 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn11.HeaderText = "Mobile No.";
      viewTextBoxColumn11.DataPropertyName = "faxnum";
      viewTextBoxColumn11.Name = "faxnum";
      viewTextBoxColumn11.FillWeight = 20f;
      viewTextBoxColumn11.ReadOnly = true;
      viewTextBoxColumn11.SortMode = DataGridViewColumnSortMode.Automatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn11);
      DataGridViewTextBoxColumn viewTextBoxColumn12 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn12.HeaderText = "Email Address";
      viewTextBoxColumn12.DataPropertyName = "EmailAddress";
      viewTextBoxColumn12.Name = "EmailAddress";
      viewTextBoxColumn12.FillWeight = 16f;
      viewTextBoxColumn12.ReadOnly = true;
      viewTextBoxColumn12.SortMode = DataGridViewColumnSortMode.Automatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn12);
      DataGridViewTextBoxColumn viewTextBoxColumn13 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn13.HeaderText = "Contract Ref";
      viewTextBoxColumn13.DataPropertyName = "ContractRef";
      viewTextBoxColumn13.Name = "ContractRef";
      viewTextBoxColumn13.FillWeight = 20f;
      viewTextBoxColumn13.ReadOnly = true;
      viewTextBoxColumn13.SortMode = DataGridViewColumnSortMode.Automatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn13);
      DataGridViewTextBoxColumn viewTextBoxColumn14 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn14.FillWeight = 40f;
      viewTextBoxColumn14.HeaderText = "Title";
      viewTextBoxColumn14.DataPropertyName = "Title";
      viewTextBoxColumn14.Name = "Title";
      viewTextBoxColumn14.ReadOnly = true;
      viewTextBoxColumn14.Visible = false;
      viewTextBoxColumn14.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn14);
      DataGridViewTextBoxColumn viewTextBoxColumn15 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn15.FillWeight = 40f;
      viewTextBoxColumn15.HeaderText = "Address 3";
      viewTextBoxColumn15.DataPropertyName = "FirstName";
      viewTextBoxColumn15.Name = "FirstName";
      viewTextBoxColumn15.ReadOnly = true;
      viewTextBoxColumn15.Visible = false;
      viewTextBoxColumn15.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn15);
      DataGridViewTextBoxColumn viewTextBoxColumn16 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn16.FillWeight = 40f;
      viewTextBoxColumn16.HeaderText = "Address 3";
      viewTextBoxColumn16.DataPropertyName = "Surname";
      viewTextBoxColumn16.Name = "Surname";
      viewTextBoxColumn16.ReadOnly = true;
      viewTextBoxColumn16.Visible = false;
      viewTextBoxColumn16.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn16);
      DataGridViewTextBoxColumn viewTextBoxColumn17 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn17.FillWeight = 40f;
      viewTextBoxColumn17.HeaderText = "Notes";
      viewTextBoxColumn17.DataPropertyName = "Notes";
      viewTextBoxColumn17.Name = "Notes";
      viewTextBoxColumn17.ReadOnly = true;
      viewTextBoxColumn17.Visible = false;
      viewTextBoxColumn17.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn17);
      DataGridViewTextBoxColumn viewTextBoxColumn18 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn18.FillWeight = 40f;
      viewTextBoxColumn18.HeaderText = "Address 3";
      viewTextBoxColumn18.DataPropertyName = "Name";
      viewTextBoxColumn18.Name = "Name";
      viewTextBoxColumn18.ReadOnly = true;
      viewTextBoxColumn18.Visible = false;
      viewTextBoxColumn18.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGVSites.Columns.Add((DataGridViewColumn) viewTextBoxColumn18);
    }

    public void SetupAppsDG()
    {
      Helper.SetUpDataGridView(this.DgMain, false);
      this.DgMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.DgMain.AutoGenerateColumns = false;
      this.DgMain.Columns.Clear();
      this.DgMain.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.FillWeight = 25f;
      viewTextBoxColumn1.DataPropertyName = "AssetID";
      viewTextBoxColumn1.Name = "AssetID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DgMain.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 25f;
      viewTextBoxColumn2.DataPropertyName = "Product";
      viewTextBoxColumn2.Name = "Product";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DgMain.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
    }

    public void SetupSOR()
    {
      Helper.SetUpDataGridView(this.DGSOR, false);
      this.DGSOR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.DGSOR.AutoGenerateColumns = false;
      this.DGSOR.Columns.Clear();
      this.DGSOR.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.FillWeight = 25f;
      viewTextBoxColumn1.DataPropertyName = "SORID";
      viewTextBoxColumn1.Name = "SORID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGSOR.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 25f;
      viewTextBoxColumn2.DataPropertyName = "Code";
      viewTextBoxColumn2.Name = "Code";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGSOR.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.FillWeight = 100f;
      viewTextBoxColumn3.DataPropertyName = "Description";
      viewTextBoxColumn3.Name = "Description";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGSOR.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.FillWeight = 15f;
      viewTextBoxColumn4.DataPropertyName = "Qty";
      viewTextBoxColumn4.Name = "Qty";
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.Visible = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGSOR.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.FillWeight = 20f;
      viewTextBoxColumn5.DataPropertyName = "TimeInMins";
      viewTextBoxColumn5.HeaderText = "Mins";
      viewTextBoxColumn5.Name = "TimeInMins";
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.Visible = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGSOR.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.FillWeight = 25f;
      viewTextBoxColumn6.DataPropertyName = "Price";
      viewTextBoxColumn6.Name = "Price";
      viewTextBoxColumn6.ReadOnly = true;
      viewTextBoxColumn6.Visible = false;
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGSOR.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
    }

    public void SetupDGSymptoms()
    {
      Helper.SetUpDataGridView(this.DGSymptoms, false);
      this.DGSymptoms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.DGSymptoms.AutoGenerateColumns = false;
      this.DGSymptoms.Columns.Clear();
      this.DGSymptoms.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.FillWeight = 1f;
      viewTextBoxColumn1.DataPropertyName = "SypID";
      viewTextBoxColumn1.Name = "SypID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGSymptoms.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 25f;
      viewTextBoxColumn2.DataPropertyName = "Code";
      viewTextBoxColumn2.Name = "Code";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGSymptoms.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.FillWeight = 100f;
      viewTextBoxColumn3.DataPropertyName = "Description";
      viewTextBoxColumn3.Name = "Description";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGSymptoms.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
    }

    public void SetupDGAdditional()
    {
      Helper.SetUpDataGridView(this.DGAdditional, false);
      this.DGAdditional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.DGAdditional.AutoGenerateColumns = false;
      this.DGAdditional.Columns.Clear();
      this.DGAdditional.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.FillWeight = 25f;
      viewTextBoxColumn1.DataPropertyName = "ID";
      viewTextBoxColumn1.Name = "ID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGAdditional.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 25f;
      viewTextBoxColumn2.DataPropertyName = "Product";
      viewTextBoxColumn2.Name = "Product";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = false;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGAdditional.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.FillWeight = 25f;
      viewTextBoxColumn3.DataPropertyName = "AssetID";
      viewTextBoxColumn3.Name = "AssetID";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = false;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGAdditional.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.FillWeight = 100f;
      viewTextBoxColumn4.DataPropertyName = "Description";
      viewTextBoxColumn4.Name = "Description";
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.Visible = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.DGAdditional.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
    }

    public void SetupExisitingJobs()
    {
      Helper.SetUpDataGridView(this.dgExistingVisits, false);
      this.dgExistingVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgExistingVisits.AutoGenerateColumns = false;
      this.dgExistingVisits.Columns.Clear();
      this.dgExistingVisits.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.FillWeight = 25f;
      viewTextBoxColumn1.DataPropertyName = "ID";
      viewTextBoxColumn1.Name = "ID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgExistingVisits.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 26f;
      viewTextBoxColumn2.DataPropertyName = "CreatedDate";
      viewTextBoxColumn2.Name = "Created Date";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgExistingVisits.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.FillWeight = 25f;
      viewTextBoxColumn3.DataPropertyName = "JobNumber";
      viewTextBoxColumn3.Name = "Job Number";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgExistingVisits.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.FillWeight = 25f;
      viewTextBoxColumn4.DataPropertyName = "JobType";
      viewTextBoxColumn4.Name = "Job Type";
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.Visible = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgExistingVisits.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.FillWeight = 150f;
      viewTextBoxColumn5.DataPropertyName = "Description";
      viewTextBoxColumn5.Name = "Description";
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.Visible = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgExistingVisits.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
    }

    private void dgvSitesContracrPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
      if (e.RowIndex >= checked (this.DGVSites.RowCount - 1))
        return;
      DataGridViewRow row = this.DGVSites.Rows[e.RowIndex];
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(row.Cells["ContractRef"].Value.ToString(), "", false) > 0U)
      {
        row.DefaultCellStyle.ForeColor = Color.Green;
        row.DefaultCellStyle.SelectionForeColor = Color.Green;
      }
    }

    public bool Save()
    {
      return true;
    }

    void IUserControl.Populate(int ID = 0)
    {
    }

    private void txtSearch_TextChanged(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.RunFilter();
    }

    private void RunFilter()
    {
      if (this.txtSearch.Text.Length > 0)
      {
        this.SiteDT = App.DB.Sites.Search_JobWizard(Helper.MakeStringValid((object) this.txtSearch.Text), App.loggedInUser.UserID);
        this.StopSelect = true;
        this.DGVSites.DataSource = (object) this.SiteDT;
        if (this.DGVSites.RowCount > 0)
        {
          this.DGVSites.Rows[0].Selected = false;
          this.StopSelect = false;
        }
        else
          this.ClearSiteDetails();
      }
      else
        this.ClearSiteDetails();
    }

    private void btnAddSite_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMSite), true, (object[]) null, false);
      this.Cursor = Cursors.WaitCursor;
      this.RunFilter();
      this.Cursor = Cursors.Default;
    }

    private void btnEditSite_Click(object sender, EventArgs e)
    {
      if (this.SelecteddgvSitesDataRow.Index < 0)
        return;
      int rowIndex = this.DGVSites.CurrentCell.RowIndex;
      int columnIndex = this.DGVSites.CurrentCell.ColumnIndex;
      int siteId = this.SiteID;
      App.ShowForm(typeof (FRMSite), true, new object[2]
      {
        (object) this.SiteID,
        (object) MyProject.Forms.FRMJobWizard
      }, false);
      this.Cursor = Cursors.WaitCursor;
      this.RunFilter();
      this.DGVSites.Rows[rowIndex].Cells[columnIndex].Selected = true;
      this.SiteID = siteId;
      this.populateSiteData();
      this.Cursor = Cursors.Default;
      this.PopulateSite();
    }

    private void PopulateSite()
    {
      this.txtCustomer.Text = this.CurrentCustomer.Name;
      this.ProgChange = true;
      ComboBox cboTitle = this.cboTitle;
      Combo.SetSelectedComboItem_By_Description(ref cboTitle, this.CurrentSite.Salutation);
      this.cboTitle = cboTitle;
      this.txtFirstName.Text = this.CurrentSite.FirstName;
      this.txtSurname.Text = this.CurrentSite.Surname;
      this.txtAddress1.Text = this.CurrentSite.Address1;
      this.txtAddress2.Text = this.CurrentSite.Address2;
      this.txtAddress3.Text = this.CurrentSite.Address3;
      this.txtPostcode.Text = this.CurrentSite.Postcode;
      this.txtTel.Text = this.CurrentSite.TelephoneNum;
      this.txtMob.Text = this.CurrentSite.FaxNum;
      this.txtEmail.Text = this.CurrentSite.EmailAddress;
      this.txtContactAlert.Text = this.CurrentSite.ContactAlerts;
      this.txtDefect.Text = this.CurrentSite.Defects;
      this.chbCommercial.Checked = this.CurrentSite.CommercialDistrict;
      this.txtContractRef.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelecteddgvSitesDataRow.Cells["ContractRef"].Value));
      this.ProgChange = false;
      this.SiteChange = false;
    }

    private void DGVSites_CellContentClick()
    {
      if (!this.StopSelect && this.SelecteddgvSitesDataRow != null && this.SelecteddgvSitesDataRow.Index > -1)
      {
        this.SiteID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelecteddgvSitesDataRow.Cells["SiteID"].Value));
        this.btnxxSiteNext.Visible = true;
        if (this.LastsiteID != this.SiteID)
        {
          this.CurrentContract = (ContractOriginal) null;
          this.chkCert.Visible = false;
          this.chkCert.Checked = false;
          this.lblcert.Visible = false;
          try
          {
            this.tcSites.TabPages[0].Enabled = true;
            this.tab = 0;
            this.tcSites.TabPages.Remove(this.tabExistingJobs);
            this.tcSites.TabPages.Remove(this.tabJobType);
            this.tcSites.TabPages.Remove(this.tabJobDetails);
            this.tcSites.TabPages.Remove(this.tabAppliance);
            this.tcSites.TabPages.Remove(this.TabCharging);
            this.tcSites.TabPages.Remove(this.tabAdditional);
            this.tcSites.TabPages.Remove(this.TabBook);
            this.tcSites.TabPages.Remove(this.tcComplete);
            this.tcSites.SelectedIndex = 0;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.tcSites.SelectedIndex = 0;
            ProjectData.ClearProjectError();
          }
          this.GasConfirmedInBoiler = true;
          DataView dataView = new DataView();
          DataTable dataTable = new DataTable();
          dataTable.TableName = "1";
          dataTable.Columns.Add("SypID");
          dataTable.Columns.Add("Code");
          dataTable.Columns.Add("Description");
          dataView.Table = dataTable;
          this.SympDataView = dataView;
          this.DGSymptoms.DataSource = (object) dataTable;
          this.SiteChange = false;
          IEnumerator enumerator;
          try
          {
            enumerator = this.tabJobType.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
              Control current = (Control) enumerator.Current;
              if (current is Button)
                current.BackColor = SystemColors.Control;
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          this.btnxxNewJob.BackColor = SystemColors.Control;
          this.txtPONumber.Text = "";
          this.txtAdditional.Text = "";
        }
        this.LastsiteID = this.SiteID;
        this.DTPrivNotes = App.DB.Job.GetAllJobNotes(this.SiteID);
        this.populateSiteData();
        this.chkCert.Checked = this.CurrentCustomer.CustomerTypeID != 475;
        this.PromotionsDT = App.DB.Customer.CustomerType_GetAll_Promotions(this.CurrentCustomer.CustomerTypeID).Table;
        this.ParentForm.Text = "Job: Adding new for " + this.CurrentSite.Salutation + " " + this.CurrentSite.Surname + " - " + this.CurrentSite.Address1 + " " + this.CurrentSite.Postcode + (this.CurrentSite.CommercialDistrict ? " *DISTRICT* " : "");
        this.ParentForm.Controls.Find("btnPrivateNotes", true)[0].Visible = false;
        this.PopulateSite();
        string caption = "";
        if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value)))
        {
          this.CurrentContract = new ContractOriginal();
          this.CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value));
          string str1 = caption + this.txtContractRef.Text + " - " + App.DB.Picklists.Get_One_As_Object(this.CurrentContract.ContractTypeID).Name + "\r\n(" + this.CurrentContract.ContractStartDate.ToString("dd/MM/yy") + "-" + this.CurrentContract.ContractEndDate.ToString("dd/MM/yy") + ")";
          string str2 = !this.CurrentContract.PlumbingDrainage ? str1 + "\r\nPlumbing And Drainage Cover : NO" : str1 + "\r\nPlumbing And Drainage Cover : YES";
          string str3 = !this.CurrentContract.GasSupplyPipework ? str2 + "\r\nGas Pipework Cover : NO" : str2 + "\r\nGas Pipework Cover : YES";
          caption = !this.CurrentContract.WindowLockPest ? str3 + "\r\nWindow Lock And Pest Cover : NO" : str3 + "\r\nWindow Lock And Pest Cover : YES";
        }
        this.ToolTip1.SetToolTip((Control) this.txtContractRef, caption);
      }
      else
        this.btnxxSiteNext.Visible = false;
    }

    private void populateSiteData()
    {
      this.CurrentSite = App.DB.Sites.Get((object) this.SiteID, SiteSQL.GetBy.SiteId, (object) null);
      this.CurrentCustomer = App.DB.Customer.Customer_Get(this.CurrentSite.CustomerID);
    }

    private void btnJobHistory_Click(object sender, EventArgs e)
    {
      if (this.SelecteddgvSitesDataRow.Index < 0)
        return;
      App.ShowForm(typeof (FRMSiteVisitManager), true, new object[2]
      {
        (object) Helper.MakeIntegerValid((object) this.SiteID),
        (object) MyProject.Forms.FRMJobWizard
      }, false);
    }

    private void dgExistingVisits_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgExistingVisits.SelectedRows.Count > 0)
      {
        this.btnxxExistingJobNext.Enabled = true;
        this.btnxxExistingJobNext.Visible = true;
        this.btnxxNewJob.BackColor = SystemColors.Control;
        this.CurrentJob = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(Conversions.ToInteger(this.dgExistingVisits.SelectedRows[0].Cells[0].Value));
        this.currentVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(this.dgExistingVisits.SelectedRows[0].Cells[0].Value), true);
        if (this.CurrentJob == null)
          return;
        DataTable table = App.DB.Asset.Asset_GetForSite(this.SiteID).Table;
        ArrayList assets = this.CurrentJob.Assets;
        this.MainDataView = App.DB.ContractOriginal.GetAssetsForContract(0, true);
        IEnumerator enumerator;
        try
        {
          enumerator = assets.GetEnumerator();
          while (enumerator.MoveNext())
          {
            JobAsset current = (JobAsset) enumerator.Current;
            try
            {
              DataRow dataRow = table.Select("AssetID = " + Conversions.ToString(current.AssetID))[0];
              this.MainDataView.AllowNew = true;
              DataRowView dataRowView = this.MainDataView.AddNew();
              dataRowView["AssetID"] = (object) current.AssetID;
              App.DB.Asset.Asset_Get(current.AssetID);
              dataRowView["Product"] = RuntimeHelpers.GetObjectValue(dataRow["Product"]);
              dataRowView.EndEdit();
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              ProjectData.ClearProjectError();
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.DgMain.DataSource = (object) this.MainDataView;
      }
      else
        this.btnxxExistingJobNext.Enabled = false;
    }

    private void btnxxNewJob_Click(object sender, EventArgs e)
    {
      if (((ButtonBase) sender).BackColor == Color.PaleGreen)
      {
        ((ButtonBase) sender).BackColor = SystemColors.Control;
        if (this.dgExistingVisits.SelectedRows.Count >= 1)
          return;
        this.btnxxExistingJobNext.Visible = false;
      }
      else
      {
        this.dgExistingVisits.ClearSelection();
        ((ButtonBase) sender).BackColor = Color.PaleGreen;
        this.btnxxExistingJobNext.Visible = true;
        this.CurrentJob = (Job) null;
        this.currentVisit = (EngineerVisit) null;
      }
    }

    private void cbotypeWiz_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cbotypeWiz)) < 1.0)
        this.btnxxJobNext.Visible = false;
      else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cbotypeWiz)) == 4702.0)
      {
        this.lblcert.Visible = true;
        this.chkCert.Visible = true;
        this.chkCert.Checked = true;
        this.btnxxJobNext.Visible = true;
        this.jobtype = Combo.get_GetSelectedItemDescription(this.cbotypeWiz).ToUpper();
      }
      else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cbotypeWiz)) == 519.0)
      {
        this.lblcert.Visible = true;
        this.chkCert.Visible = true;
        this.chkCert.Checked = false;
        this.btnxxJobNext.Visible = true;
        this.jobtype = Combo.get_GetSelectedItemDescription(this.cbotypeWiz).ToUpper();
      }
      else
      {
        this.lblcert.Visible = false;
        this.chkCert.Visible = false;
        this.btnxxJobNext.Visible = true;
        this.jobtype = Combo.get_GetSelectedItemDescription(this.cbotypeWiz).ToUpper();
        this.btnxxDetailsNext.Visible = true;
      }
    }

    private void btnSORAdd_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboSOR)) > 0.0 && Versioned.IsNumeric((object) this.txtSORQty.Text) && this.txtSORQty.Text.Length > 0 && Conversions.ToDouble(this.txtSORQty.Text) > 0.0)
      {
        this.SORDataView.AllowNew = true;
        DataRowView dataRowView = this.SORDataView.AddNew();
        CustomerScheduleOfRate customerScheduleOfRate = App.DB.CustomerScheduleOfRate.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboSOR)));
        dataRowView["SORID"] = (object) customerScheduleOfRate.CustomerScheduleOfRateID;
        dataRowView["Code"] = (object) customerScheduleOfRate.Code;
        dataRowView["Description"] = (object) customerScheduleOfRate.Description;
        dataRowView["Qty"] = (object) this.txtSORQty.Text;
        dataRowView["TimeInMins"] = (object) customerScheduleOfRate.TimeInMins;
        dataRowView["Price"] = (object) customerScheduleOfRate.Price;
        dataRowView.EndEdit();
        this.DGSOR.DataSource = (object) this.SORDataView;
        this.txtSORQty.Text = "1";
      }
      if (this.DGSOR.RowCount > 0)
        this.btnxxJobNext.Visible = true;
      else
        this.btnxxJobNext.Visible = false;
    }

    private void btnSORMinus_Click(object sender, EventArgs e)
    {
      if (this.DGSOR.CurrentRow != null)
      {
        this.SORDataView.AllowDelete = true;
        this.SORDataView.Table.Rows.RemoveAt(this.DGSOR.CurrentRow.Index);
      }
      if (this.DGSOR.RowCount > 0)
      {
        if (this.CurrentSite.PoNumReqd & this.txtPONumber.Text.Length == 0 || this.cboPriority.Items.Count > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPriority)) < 1.0)
          return;
        this.btnxxJobNext.Visible = true;
      }
      else
        this.btnxxJobNext.Visible = false;
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
      if (this.DgMain.RowCount > 0)
        this.btnxxApplianceNext.Visible = true;
      else
        this.btnxxApplianceNext.Visible = false;
    }

    private void btnMinusMain_Click(object sender, EventArgs e)
    {
      if (this.DgMain.CurrentRow != null)
      {
        this.MainDataView.AllowDelete = true;
        this.MainDataView.Table.Rows.RemoveAt(this.SelectedMainDataRow.Index);
      }
      if (this.DgMain.RowCount > 0)
        this.btnxxApplianceNext.Visible = true;
      else
        this.btnxxApplianceNext.Visible = false;
    }

    private void cboPriority_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ValidateJobDetails();
    }

    private void txtPONumber_TextChanged(object sender, EventArgs e)
    {
      this.ValidateJobDetails();
    }

    private void btnSymAdd_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboSymptom)) > 0.0)
      {
        this.SympDataView.AllowNew = true;
        DataRowView dataRowView = this.SympDataView.AddNew();
        dataRowView["SypID"] = (object) Combo.get_GetSelectedItemValue(this.cboSymptom);
        dataRowView["Code"] = (object) Combo.get_GetSelectedItemDescription(this.cboSymptom).Split(' ')[0];
        dataRowView["Description"] = (object) Combo.get_GetSelectedItemDescription(this.cboSymptom).Substring(checked (Combo.get_GetSelectedItemDescription(this.cboSymptom).IndexOf(" ") + 1));
        dataRowView.EndEdit();
        this.DGSymptoms.DataSource = (object) this.SympDataView;
      }
      this.ValidateJobDetails();
    }

    private void ValidateJobDetails()
    {
      if ((this.DGSymptoms.RowCount > 0 | !this.pnlSymptoms.Visible) & (!this.cboPriority.Visible | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPriority)) > 0.0) | ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) > 0U | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboTypeOfWorks)) > 0.0))
      {
        if (this.CurrentSite.PoNumReqd & this.txtPONumber.Text.Length > 0 | !this.CurrentSite.PoNumReqd)
          this.btnxxDetailsNext.Visible = true;
        else
          this.btnxxDetailsNext.Visible = true;
        IEnumerator enumerator;
        try
        {
          enumerator = ((IEnumerable) this.DGSymptoms.Rows).GetEnumerator();
          while (enumerator.MoveNext())
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((DataGridViewRow) enumerator.Current).Cells["Code"].Value, (object) "OTHER", false) && this.txtAdditional.Text.Length == 0)
              this.btnxxDetailsNext.Visible = false;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      else
        this.btnxxDetailsNext.Visible = false;
    }

    private void btnSymMinus_Click(object sender, EventArgs e)
    {
      if (this.DGSymptoms.CurrentRow != null)
      {
        this.SympDataView.AllowDelete = true;
        this.SympDataView.Table.Rows.RemoveAt(this.DGSymptoms.CurrentRow.Index);
      }
      this.ValidateJobDetails();
    }

    private void cboTypeOfWorks_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ValidateJobDetails();
    }

    private void btnSiteNext_Click(object sender, EventArgs e)
    {
      ComboBox cboPriority = this.cboPriority;
      Combo.SetUpCombo(ref cboPriority, App.DB.Customer.Priorities_Get_For_CustomerID_Active(this.CurrentSite.CustomerID, 0).Table, "ManagerID", "Name", Enums.ComboValues.Not_Applicable);
      this.cboPriority = cboPriority;
      ComboBox cboSymptom = this.cboSymptom;
      Combo.SetUpCombo(ref cboSymptom, App.DB.Picklists.GetAll(Enums.PickListTypes.Symptoms, false).Table, "ManagerID", "Combo", Enums.ComboValues.Please_Select);
      this.cboSymptom = cboSymptom;
      DataView dataView = new DataView();
      DataTable dataTable = new DataTable();
      dataTable.TableName = "1";
      dataTable.Columns.Add("SORID");
      dataTable.Columns.Add("Code");
      dataTable.Columns.Add("Description");
      dataTable.Columns.Add("Qty");
      dataTable.Columns.Add("TimeInMins");
      dataTable.Columns.Add("Price");
      dataView.Table = dataTable;
      this.SORDataView = dataView;
      this.DGSOR.DataSource = (object) dataTable;
      if (this.tcSites.TabCount == 1)
        this.tcSites.TabPages.Insert(1, this.tabExistingJobs);
      this.tab = 1;
      this.tcSites.SelectedIndex = 1;
      Application.DoEvents();
      this.tcSites.SelectedTab = this.tcSites.TabPages[this.tab];
      Application.DoEvents();
      this.dgExistingVisits.DataSource = (object) App.DB.EngineerVisits.EngineerVisits_Get_AllReady_ForSite(this.CurrentSite.SiteID);
      this.dgExistingVisits.ClearSelection();
      this.btnxxExistingJobNext.BackColor = SystemColors.Control;
    }

    private void btnxxExistingJobNext_Click(object sender, EventArgs e)
    {
      if (App.IsRFT)
      {
        this.btnxxBreakdown.Visible = false;
        this.BtnxxService.Visible = false;
        this.btnxxKitchens.Visible = false;
        this.btnxxMultiTrade.Visible = true;
        this.btnxxPlumbing.Visible = true;
        this.btnxxElectrical.Visible = true;
        this.btnxxExternalBM.Visible = false;
        this.btnxxCarpentry.Visible = true;
      }
      else
      {
        this.btnxxBreakdown.Visible = true;
        this.BtnxxService.Visible = true;
        this.btnxxKitchens.Visible = false;
        this.btnxxMultiTrade.Visible = false;
        this.btnxxPlumbing.Visible = false;
        this.btnxxElectrical.Visible = false;
        this.btnxxExternalBM.Visible = false;
        this.btnxxCarpentry.Visible = false;
      }
      if (this.btnxxNewJob.BackColor == Color.PaleGreen)
      {
        if (this.tcSites.TabCount == 2)
          this.tcSites.TabPages.Insert(2, this.tabJobType);
        this.tab = 2;
        this.tcSites.SelectedIndex = 2;
        this.lblUnabletoConfirm.Visible = false;
        this.CurrentJob = (Job) null;
        this.ParentForm.Controls.Find("btnPrivateNotes", true)[0].Visible = true;
      }
      else
      {
        if (this.dgExistingVisits.SelectedRows.Count <= 0)
          return;
        this.lblUnabletoConfirm.Visible = true;
        this.CurrentJob = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(Conversions.ToInteger(this.dgExistingVisits.SelectedRows[0].Cells[0].Value));
        this.currentVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(this.dgExistingVisits.SelectedRows[0].Cells[0].Value), true);
        this.DGSymptoms.DataSource = (object) App.DB.EngineerVisits.GetSymptoms(this.currentVisit.EngineerVisitID);
        DataTable extendedProperties = App.DB.EngineerVisits.GetExtendedProperties(this.currentVisit.EngineerVisitID);
        if (extendedProperties.Rows.Count > 0)
          this.txtAdditional.Text = Conversions.ToString(extendedProperties.Rows[0]["AdditionalNotes"]);
        else if (this.currentVisit.NotesToEngineer.LastIndexOf("based Works -") > 0)
          this.txtAdditional.Text = this.currentVisit.NotesToEngineer.Substring(checked (this.currentVisit.NotesToEngineer.LastIndexOf("based Works -") + 13)).Trim(' ');
        else if (this.currentVisit.NotesToEngineer.LastIndexOf("- See SOR List") > 0)
          this.txtAdditional.Text = this.currentVisit.NotesToEngineer.Substring(checked (this.currentVisit.NotesToEngineer.LastIndexOf("- See SOR List") + 14)).Trim(' ');
        else
          this.txtAdditional.Text = this.currentVisit.NotesToEngineer;
        if (this.tcSites.TabCount == 2)
          this.tcSites.TabPages.Insert(2, this.tabJobType);
        this.tab = 2;
        this.tcSites.SelectedIndex = 2;
        switch (this.CurrentJob.JobTypeID)
        {
          case 519:
            this.btnxx_Click((object) this.BtnxxService, new EventArgs());
            break;
          case 521:
            this.btnxx_Click((object) this.btnxxOther, new EventArgs());
            ComboBox cbotypeWiz1 = this.cbotypeWiz;
            Combo.SetSelectedComboItem_By_Value(ref cbotypeWiz1, Conversions.ToString(this.CurrentJob.JobTypeID));
            this.cbotypeWiz = cbotypeWiz1;
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cbotypeWiz)) < 1.0)
              this.btnxxJobNext.Visible = false;
            else
              this.btnxxJobNext.Visible = true;
            ArrayList jobOfWorkAsObjects1 = App.DB.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(this.currentVisit.JobOfWorkID);
            IEnumerator enumerator1;
            try
            {
              enumerator1 = jobOfWorkAsObjects1.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                JobItem current = (JobItem) enumerator1.Current;
                CustomerScheduleOfRate customerScheduleOfRate = App.DB.CustomerScheduleOfRate.Get(current.RateID);
                if (customerScheduleOfRate != null)
                {
                  this.SORDataView.AllowNew = true;
                  DataRowView dataRowView = this.SORDataView.AddNew();
                  dataRowView["SORID"] = (object) current.RateID;
                  dataRowView["Code"] = (object) customerScheduleOfRate.Code;
                  dataRowView["Description"] = (object) customerScheduleOfRate.Description;
                  dataRowView["Qty"] = (object) current.Qty;
                  dataRowView["TimeInMins"] = (object) customerScheduleOfRate.TimeInMins;
                  dataRowView["Price"] = (object) customerScheduleOfRate.Price;
                  dataRowView.EndEdit();
                  this.DGSOR.DataSource = (object) this.SORDataView;
                }
              }
              break;
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
          case 4702:
            this.btnxx_Click((object) this.BtnxxService, new EventArgs());
            this.chkCert.Checked = true;
            break;
          case 4703:
            this.btnxx_Click((object) this.btnxxBreakdown, new EventArgs());
            break;
          case 67098:
            this.btnxx_Click((object) this.btnxxSOR, new EventArgs());
            this.pnlSOR.Visible = true;
            ComboBox cboSor = this.cboSOR;
            Combo.SetUpCombo(ref cboSor, App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(this.CurrentCustomer.CustomerID).Table, "CustomerScheduleOfRateID", "Description", Enums.ComboValues.Please_Select);
            this.cboSOR = cboSor;
            ArrayList jobOfWorkAsObjects2 = App.DB.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(this.currentVisit.JobOfWorkID);
            IEnumerator enumerator2;
            try
            {
              enumerator2 = jobOfWorkAsObjects2.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                JobItem current = (JobItem) enumerator2.Current;
                CustomerScheduleOfRate customerScheduleOfRate = App.DB.CustomerScheduleOfRate.Get(current.RateID);
                if (customerScheduleOfRate != null)
                {
                  this.SORDataView.AllowNew = true;
                  DataRowView dataRowView = this.SORDataView.AddNew();
                  dataRowView["SORID"] = (object) current.RateID;
                  dataRowView["Code"] = (object) customerScheduleOfRate.Code;
                  dataRowView["Description"] = (object) customerScheduleOfRate.Description;
                  dataRowView["Qty"] = (object) current.Qty;
                  dataRowView["TimeInMins"] = (object) customerScheduleOfRate.TimeInMins;
                  dataRowView["Price"] = (object) customerScheduleOfRate.Price;
                  dataRowView.EndEdit();
                  this.DGSOR.DataSource = (object) this.SORDataView;
                }
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            if (this.DGSOR.RowCount > 0)
            {
              this.btnxxJobNext.Visible = true;
              this.jobtype = "SOR";
              break;
            }
            this.btnxxJobNext.Visible = false;
            break;
          default:
            this.btnxx_Click((object) this.btnxxOther, new EventArgs());
            this.cbotypeWiz.Visible = true;
            this.lbltype.Visible = true;
            if (this.cboPriority.Items.Count > 1)
            {
              this.lblPriority.Visible = true;
              this.cboPriority.Visible = true;
            }
            else
            {
              this.lblPriority.Visible = false;
              this.cboPriority.Visible = false;
            }
            this.pnlSymptoms.Visible = true;
            this.lblAdditional.Visible = true;
            this.txtAdditional.Visible = true;
            this.lblcert.Visible = false;
            this.chkCert.Visible = false;
            this.pnlSOR.Visible = false;
            ComboBox cbotypeWiz2 = this.cbotypeWiz;
            Combo.SetSelectedComboItem_By_Value(ref cbotypeWiz2, Conversions.ToString(this.CurrentJob.JobTypeID));
            this.cbotypeWiz = cbotypeWiz2;
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cbotypeWiz)) < 1.0)
              this.btnxxJobNext.Visible = false;
            else
              this.btnxxJobNext.Visible = true;
            ArrayList jobOfWorkAsObjects3 = App.DB.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(this.currentVisit.JobOfWorkID);
            IEnumerator enumerator3;
            try
            {
              enumerator3 = jobOfWorkAsObjects3.GetEnumerator();
              while (enumerator3.MoveNext())
              {
                JobItem current = (JobItem) enumerator3.Current;
                CustomerScheduleOfRate customerScheduleOfRate = App.DB.CustomerScheduleOfRate.Get(current.RateID);
                if (customerScheduleOfRate != null)
                {
                  this.SORDataView.AllowNew = true;
                  DataRowView dataRowView = this.SORDataView.AddNew();
                  dataRowView["SORID"] = (object) current.RateID;
                  dataRowView["Code"] = (object) customerScheduleOfRate.Code;
                  dataRowView["Description"] = (object) customerScheduleOfRate.Description;
                  dataRowView["Qty"] = (object) current.Qty;
                  dataRowView["TimeInMins"] = (object) customerScheduleOfRate.TimeInMins;
                  dataRowView["Price"] = (object) customerScheduleOfRate.Price;
                  dataRowView.EndEdit();
                  this.DGSOR.DataSource = (object) this.SORDataView;
                }
              }
              break;
            }
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
        }
        this.ParentForm.Controls.Find("btnSaveProg", true)[0].Visible = true;
        if (this.tcSites.TabCount == 3)
          this.btnJobNext_Click((object) this.btnxxJobNext, new EventArgs());
        if (this.DgMain.RowCount > 0 & this.tcSites.TabCount == 4)
          this.btnxxApplianceNext_Click((object) this.btnxxApplianceNext, new EventArgs());
        DataView dataView = new DataView();
        DataTable dataTable = new DataTable();
        dataTable.TableName = "1";
        dataTable.Columns.Add("SypID");
        dataTable.Columns.Add("Code");
        dataTable.Columns.Add("Description");
        dataView.Table = dataTable;
        this.SympDataView = dataView;
        this.DGSymptoms.DataSource = (object) dataTable;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) == 0)
          this.btnxxDetailsNext.Visible = true;
        JobOfWork jobOfWork = App.DB.JobOfWorks.JobOfWork_Get(this.currentVisit.JobOfWorkID);
        this.txtPONumber.Text = jobOfWork.PONumber;
        ComboBox cboPriority = this.cboPriority;
        Combo.SetSelectedComboItem_By_Value(ref cboPriority, Conversions.ToString(jobOfWork.Priority));
        this.cboPriority = cboPriority;
        DataTable symptoms = App.DB.EngineerVisits.GetSymptoms(this.currentVisit.EngineerVisitID);
        IEnumerator enumerator4;
        try
        {
          enumerator4 = symptoms.Rows.GetEnumerator();
          while (enumerator4.MoveNext())
          {
            DataRow current = (DataRow) enumerator4.Current;
            this.SympDataView.AllowNew = true;
            DataRowView dataRowView = this.SympDataView.AddNew();
            dataRowView["SypID"] = RuntimeHelpers.GetObjectValue(current["SymptomID"]);
            dataRowView["Code"] = RuntimeHelpers.GetObjectValue(current["Code"]);
            dataRowView["Description"] = RuntimeHelpers.GetObjectValue(current["Description"]);
            dataRowView.EndEdit();
            this.DGSymptoms.DataSource = (object) this.SympDataView;
          }
        }
        finally
        {
          if (enumerator4 is IDisposable)
            (enumerator4 as IDisposable).Dispose();
        }
        this.ValidateJobDetails();
        this.ParentForm.Controls.Find("btnPrivateNotes", true)[0].Visible = true;
      }
    }

    private void btnJobNext_Click(object sender, EventArgs e)
    {
      this.ParentForm.Controls.Find("btnSaveProg", true)[0].Visible = true;
      this.pnlSymptoms.Visible = true;
      this.rftBundle.AddRange((IEnumerable<string>) new string[10]
      {
        "KITCHENS",
        "BATHROOMS",
        "PLUMBING",
        "ELECTRICAL",
        "OTHER INTERNAL B AND M",
        "OTHER EXTERNAL B AND M",
        "MULTI TRADE",
        "BATHROOM FITTING",
        "BRICKLAYER",
        "BB"
      });
      if (this.tcSites.TabCount == 3)
      {
        this.tcSites.TabPages.Insert(3, this.tabAppliance);
        ComboBox cboMainApps = this.cboMainApps;
        Combo.SetUpCombo(ref cboMainApps, App.DB.Asset.Asset_GetForSite(this.SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select);
        this.cboMainApps = cboMainApps;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) > 0U)
          this.cboMainApps.Items.Add((object) new Combo("Non Asset Related", Conversions.ToString(1), (object) null));
        if (App.IsGasway)
        {
          this.cboMainApps.Items.Add((object) new Combo("Boiler - Unknown", Conversions.ToString(2), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Storage Boiler - Unknown", Conversions.ToString(3), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Oil Boiler - Unknown", Conversions.ToString(4), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Gas Fire - Unknown", Conversions.ToString(5), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Unit Heater - Unknown", Conversions.ToString(6), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Large Unit Heater - Unknown", Conversions.ToString(7), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Water Heater - Unknown", Conversions.ToString(8), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Unvented Cylinder - Unknown", Conversions.ToString(9), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Cooker - Unknown", Conversions.ToString(10), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Hob - Unknown", Conversions.ToString(11), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Warm Air Unit - Unknown", Conversions.ToString(12), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Air Source - Unknown", Conversions.ToString(13), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Range Cooker - Unknown", Conversions.ToString(14), (object) null));
          this.cboMainApps.Items.Add((object) new Combo("Solid Fuel - Unknown", Conversions.ToString(15), (object) null));
        }
        if (this.btnxxNewJob.BackColor == Color.PaleGreen)
          this.MainDataView = App.DB.ContractOriginal.GetAssetsForContract(0, true);
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) == 0)
      {
        this.TimeReqOption = false;
        this.pnlTimeReq.Visible = false;
        this.pnlTypeOfWorks.Visible = true;
        this.cboTypeOfWorks.Items.Clear();
        ComboBox cboTypeOfWorks = this.cboTypeOfWorks;
        Combo.SetUpCombo(ref cboTypeOfWorks, DynamicDataTables.JobWizTypesOfWork, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
        this.cboTypeOfWorks = cboTypeOfWorks;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) == 0)
      {
        this.TimeReqOption = false;
        this.pnlTimeReq.Visible = false;
        this.pnlTypeOfWorks.Visible = true;
        this.cboTypeOfWorks.Items.Clear();
        ComboBox cboTypeOfWorks = this.cboTypeOfWorks;
        Combo.SetUpCombo(ref cboTypeOfWorks, DynamicDataTables.JobWizServTypesOfWork, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
        this.cboTypeOfWorks = cboTypeOfWorks;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "INSTALLATION", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "KITCHENS AND BATHROOMS", false) == 0 | App.IsRFT)
      {
        this.TimeReqOption = true;
        this.pnlTimeReq.Visible = true;
        this.pnlTypeOfWorks.Visible = false;
        this.cboTypeOfWorks.Items.Clear();
      }
      else
      {
        this.TimeReqOption = false;
        this.pnlTimeReq.Visible = false;
        this.pnlTypeOfWorks.Visible = false;
        this.cboTypeOfWorks.Items.Clear();
      }
      this.tab = checked (this.tcSites.SelectedIndex + 1);
      checked { ++this.tcSites.SelectedIndex; }
      if (this.DgMain.RowCount > 0)
        this.btnxxApplianceNext.Visible = true;
      else
        this.btnxxApplianceNext.Visible = false;
    }

    private void btnxxApplianceNext_Click(object sender, EventArgs e)
    {
      if (this.tcSites.TabCount == 4)
      {
        DataView dataView = new DataView();
        DataTable dataTable = new DataTable();
        dataTable.TableName = "1";
        dataTable.Columns.Add("SypID");
        dataTable.Columns.Add("Code");
        dataTable.Columns.Add("Description");
        dataView.Table = dataTable;
        this.SympDataView = dataView;
        this.DGSymptoms.DataSource = (object) dataTable;
        this.tcSites.TabPages.Insert(4, this.tabJobDetails);
      }
      this.tab = checked (this.tcSites.SelectedIndex + 1);
      checked { ++this.tcSites.SelectedIndex; }
      if (this.DGSymptoms.RowCount > 0 & (!this.cboPriority.Visible | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPriority)) > 0.0) | ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) > 0U | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboTypeOfWorks)) > 0.0))
      {
        if (this.CurrentSite.PoNumReqd & this.txtPONumber.Text.Length > 0 | !this.CurrentSite.PoNumReqd)
          this.btnxxDetailsNext.Visible = true;
        else
          this.btnxxDetailsNext.Visible = true;
      }
      else
        this.btnxxDetailsNext.Visible = false;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) != 0)
        return;
      this.lblPriority.Visible = false;
      this.cboPriority.Visible = false;
      this.pnlSymptoms.Visible = false;
      this.btnxxDetailsNext.Visible = true;
    }

    private void btnxxDetailsNext_Click(object sender, EventArgs e)
    {
      if (this.CurrentSite.PoNumReqd && this.txtPONumber.Text.Length < 1)
      {
        int num = (int) Interaction.MsgBox((object) "Please add a PO Reference", MsgBoxStyle.OkOnly, (object) "Opps");
      }
      else
      {
        DataTable dataTable1 = new DataTable();
        if (this.SelecteddgvSitesDataRow.Cells["ContractID"].Value != DBNull.Value)
        {
          DataTable table = App.DB.ContractOriginalSite.GetAll_ContractID2(Conversions.ToInteger(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value), this.CurrentSite.CustomerID).Table;
          dataTable1 = App.DB.ContractOriginalPPMVisit.GetAllAssets_For_ContractSiteID(Conversions.ToInteger(table.Rows[0]["ContractSiteID"])).Table;
        }
        this.lblCoverplanServ.Text = "";
        DateTime lastServiceDate = this.CurrentSite.LastServiceDate;
        if (DateTime.Compare(lastServiceDate.AddMonths(10), DateAndTime.Today) < 0)
        {
          this.lblCoverplanServ.Visible = true;
          this.lblCoverplanServ.Text = "This Sites service visit is due soon, please book.\r\n";
          this.lblCoverplanServ.Visible = true;
        }
        else
        {
          lastServiceDate = this.CurrentSite.LastServiceDate;
          if (DateTime.Compare(lastServiceDate.AddMonths(12), DateAndTime.Today) < 0 & this.CurrentCustomer.CustomerTypeID == 516)
            this.lblCoverplanServ.Text = "This Sites service visit is overdue and must be booked now.\r\n";
          else
            this.lblCoverplanServ.Visible = false;
        }
        if (dataTable1.Rows.Count > 0)
        {
          this.lblCoverplanServ.Visible = true;
          Label lblCoverplanServ;
          string text = (lblCoverplanServ = this.lblCoverplanServ).Text;
          lastServiceDate = this.CurrentSite.LastServiceDate;
          string str1 = Conversions.ToString(lastServiceDate.AddMonths(12));
          string str2 = text + "This Site Has A Coverplan Service Outstanding - Due Before " + str1;
          lblCoverplanServ.Text = str2;
        }
        else
          this.lblCoverplanServ.Visible = false;
        DataView dataView = new DataView();
        DataTable dataTable2 = new DataTable();
        dataTable2.TableName = "2";
        dataTable2.Columns.Add("ID");
        dataTable2.Columns.Add("AssetID");
        dataTable2.Columns.Add("Description");
        dataTable2.Columns.Add("Product");
        dataTable2.Columns.Add("Cert");
        dataView.Table = dataTable2;
        this.DGVAdditional = dataView;
        this.DGAdditional.DataSource = (object) dataTable2;
        this.btnxxAdditionalNext.Visible = true;
        if (App.IsRFT)
        {
          if (this.tcSites.TabCount == 5)
            this.tcSites.TabPages.Insert(5, this.TabCharging);
          this.tab = checked (this.tcSites.SelectedIndex + 1);
          checked { ++this.tcSites.SelectedIndex; }
          this.DoCharging();
          this.AdditionalCharging();
          ComboBox cboPayTerms = this.cboPayTerms;
          Combo.SetSelectedComboItem_By_Value(ref cboPayTerms, Conversions.ToString(2));
          this.cboPayTerms = cboPayTerms;
          this.btnxxChargeNext_Click((object) this.btnxxChargeNext, new EventArgs());
        }
        else
        {
          if (this.tcSites.TabCount == 5)
            this.tcSites.TabPages.Insert(5, this.tabAdditional);
          this.tab = checked (this.tcSites.SelectedIndex + 1);
          checked { ++this.tcSites.SelectedIndex; }
        }
      }
    }

    private void btnxxAdditionalNext_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPayTerms)) < 1.0)
        this.btnxxChargeNext.Visible = false;
      else
        this.btnxxChargeNext.Visible = true;
      if (this.tcSites.TabCount == 6)
        this.tcSites.TabPages.Insert(6, this.TabCharging);
      this.tab = checked (this.tcSites.SelectedIndex + 1);
      checked { ++this.tcSites.SelectedIndex; }
      this.DoCharging();
      this.AdditionalCharging();
      this.FinalCharge = Conversions.ToDouble(this.txtCharge.Text);
      this.FinalText = this.txtPayInst.Text;
      this.txtCharge.Text = Strings.Format((object) Conversions.ToDouble(this.txtCharge.Text), "C");
      this.CheckDiscount();
    }

    private void btnxxChargeNext_Click(object sender, EventArgs e)
    {
      this.SaveProgress();
    }

    private void btnAdditionalPlus_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAdditional)) <= 0.0)
        return;
      int integer;
      string str;
      bool flag;
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAdditional)) == 1.0)
      {
        FRMSelectAsset frmSelectAsset = (FRMSelectAsset) App.checkIfExists(typeof (FRMSelectAsset).Name, true) ?? (FRMSelectAsset) Activator.CreateInstance(typeof (FRMSelectAsset));
        frmSelectAsset.ShowInTaskbar = false;
        frmSelectAsset.SiteID = this.CurrentSite.SiteID;
        int num = (int) frmSelectAsset.ShowDialog();
        if (frmSelectAsset.DialogResult == DialogResult.OK)
        {
          integer = Conversions.ToInteger(frmSelectAsset.SelectedAssetDataRow["AssetID"]);
          str = Conversions.ToString(frmSelectAsset.SelectedAssetDataRow["Product"]);
          flag = frmSelectAsset.chkCERT2.Checked;
        }
        frmSelectAsset.Close();
      }
      this.chkCert.Visible = true;
      this.chkCert.Checked = true;
      this.lblcert.Visible = true;
      this.DGVAdditional.AllowNew = true;
      DataRowView dataRowView = this.DGVAdditional.AddNew();
      dataRowView["ID"] = (object) Combo.get_GetSelectedItemValue(this.cboAdditional);
      dataRowView["description"] = (object) (Combo.get_GetSelectedItemDescription(this.cboAdditional) + " - " + str.Split('-')[0]);
      dataRowView["AssetID"] = (object) integer;
      dataRowView["Product"] = (object) str;
      dataRowView["Cert"] = (object) flag;
      dataRowView.EndEdit();
      this.DGAdditional.DataSource = (object) this.DGVAdditional;
    }

    private void btnAdditionalMinus_Click(object sender, EventArgs e)
    {
      if (this.DGAdditional.CurrentRow == null)
        return;
      this.DGVAdditional.AllowDelete = true;
      this.DGVAdditional.Table.Rows.RemoveAt(this.DGAdditional.CurrentRow.Index);
    }

    private void chkRecall_CheckedChanged(object sender, EventArgs e)
    {
      this.Manualrecall = true;
    }

    public void DoCharging()
    {
      this.visitcharge1 = 0.0;
      this.visitterm1 = "";
      int num1;
      switch (this.CurrentCustomer.Terms)
      {
        case 69650:
          num1 = 3;
          break;
        case 69651:
        case 69652:
        case 69655:
          num1 = 2;
          break;
        default:
          num1 = 3;
          break;
      }
      this.SpecialTrade = "";
      this.time = 0;
      this.LPGNEEDED = false;
      this.OILNEEDED = false;
      this.NATNEEDED = false;
      this.HETASNEEDED = false;
      this.ASNEEDED = false;
      this.WAUNEEDED = false;
      this.COMMNEEDED = false;
      this.UseContractVisit = false;
      this.txtPayInst.Text = "\r\n";
      this.txtCharge.Text = "£0.00";
      FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(this.CurrentSite.CustomerID);
      string jobtype = this.jobtype;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(jobtype, "BREAKDOWN", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(jobtype, "SERVICE", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(jobtype, "SOR", false) == 0)
          {
            double num2 = 0.0;
            IEnumerator enumerator;
            try
            {
              enumerator = ((IEnumerable) this.DGSOR.Rows).GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataGridViewRow current = (DataGridViewRow) enumerator.Current;
                // ISSUE: variable of a reference type
                int& local;
                // ISSUE: explicit reference operation
                int integer = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) ^(local = ref this.time), current.Cells["TimeInMins"].Value));
                local = integer;
                num2 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, current.Cells["Price"].Value));
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            if (customer.CustomerTypeID == 516)
            {
              TextBox txtPayInst;
              string str = (txtPayInst = this.txtPayInst).Text + "SOR Works not chargeable upfront\r\n";
              txtPayInst.Text = str;
            }
            else
            {
              TextBox txtPayInst;
              string str = (txtPayInst = this.txtPayInst).Text + "SOR Works charges Applied\r\n";
              txtPayInst.Text = str;
              this.txtCharge.Text = "£" + Conversions.ToString(Conversions.ToDouble(this.txtCharge.Text) + num2);
            }
          }
          else
          {
            if (this.TimeReqOption)
            {
              if (Versioned.IsNumeric((object) this.txtDays.Text) && Conversions.ToInteger(this.txtDays.Text) > 0)
                this.time = 200;
              else if (Versioned.IsNumeric((object) this.txtHrs.Text))
                this.time = checked ((int) Math.Round(Conversions.ToDouble(this.txtHrs.Text)));
            }
            if (this.time == 0)
              this.time = 60;
            TextBox txtPayInst;
            string str = (txtPayInst = this.txtPayInst).Text + "Unknown costs, please manually complete\r\n";
            txtPayInst.Text = str;
          }
        }
        else
        {
          TextBox txtPayInst1;
          string str1 = (txtPayInst1 = this.txtPayInst).Text + "Service job Applied\r\n";
          txtPayInst1.Text = str1;
          switch (customer.CustomerTypeID)
          {
            case 516:
              this.time = 45;
              TextBox txtPayInst2;
              string str2 = (txtPayInst2 = this.txtPayInst).Text + "Social Housing or Council Service works are not chargeable\r\n";
              txtPayInst2.Text = str2;
              ComboBox cboPayTerms1 = this.cboPayTerms;
              Combo.SetSelectedComboItem_By_Value(ref cboPayTerms1, Conversions.ToString(4));
              this.cboPayTerms = cboPayTerms1;
              this.txtCharge.Text = "£0.00";
              break;
            case 517:
              this.time = 45;
              TextBox txtPayInst3;
              string str3 = (txtPayInst3 = this.txtPayInst).Text + "Insurance Works are OTI\r\n";
              txtPayInst3.Text = str3;
              ComboBox cboPayTerms2 = this.cboPayTerms;
              Combo.SetSelectedComboItem_By_Value(ref cboPayTerms2, Conversions.ToString(2));
              this.cboPayTerms = cboPayTerms2;
              this.txtCharge.Text = "£0.00";
              break;
            default:
              DataTable dataTable1 = new DataTable();
              object obj = (object) false;
              DataRow dataRow;
              if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value)))
              {
                this.CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value));
                dataTable1 = App.DB.ContractOriginalSite.GetAll_ContractID2(Conversions.ToInteger(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value), this.CurrentSite.CustomerID).Table;
                dataRow = dataTable1.Select("tick = 1")[0];
              }
              this.CoverApps = new List<int>();
              this.ChargeApps = new List<int>();
              if (this.CurrentContract != null)
              {
                obj = (object) true;
                ComboBox cboPayTerms3 = this.cboPayTerms;
                Combo.SetSelectedComboItem_By_Value(ref cboPayTerms3, Conversions.ToString(1));
                this.cboPayTerms = cboPayTerms3;
                TextBox txtPayInst4;
                string str4 = (txtPayInst4 = this.txtPayInst).Text + "Works charges would normally be covered by Contract\r\n";
                txtPayInst4.Text = str4;
                this.txtCharge.Text = "£0.00";
                DataTable dataTable2 = new DataTable();
                DataTable table = App.DB.ContractOriginalPPMVisit.GetAllAssets_For_ContractSiteID(Conversions.ToInteger(dataRow["ContractSiteID"])).Table;
                int num2 = 0;
                int num3 = 0;
                if (dataTable1.Rows.Count > 0)
                {
                  num2 = Conversions.ToInteger(dataTable1.Rows[0]["MainAppliances"]);
                  num3 = Conversions.ToInteger(dataTable1.Rows[0]["SecondryAppliances"]);
                }
                int num4 = 0;
                int num5 = 0;
                if (table.Rows.Count == 0)
                {
                  ComboBox cboPayTerms4 = this.cboPayTerms;
                  Combo.SetSelectedComboItem_By_Value(ref cboPayTerms4, Conversions.ToString(num1));
                  this.cboPayTerms = cboPayTerms4;
                  TextBox txtPayInst5;
                  string str5 = (txtPayInst5 = this.txtPayInst).Text + "Any Service Visits Have already been completed for this Contract Period\r\n";
                  txtPayInst5.Text = str5;
                  this.txtCharge.Text = "£0.00";
                  break;
                }
                this.UseContractVisit = true;
                IEnumerator enumerator1;
                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["AssetID"])))
                {
                  try
                  {
                    enumerator1 = table.Rows.GetEnumerator();
                    while (enumerator1.MoveNext())
                    {
                      DataRow current1 = (DataRow) enumerator1.Current;
                      IEnumerator enumerator2;
                      try
                      {
                        enumerator2 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                          DataGridViewRow current2 = (DataGridViewRow) enumerator2.Current;
                          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current2.Cells["AssetID"].Value, current1["AssetID"], false))
                          {
                            this.CoverApps.Add(Conversions.ToInteger(current1["AssetID"]));
                            if (this.CheckMainApps(current2.Cells["Product"].Value.ToString().Split('-')[0], false))
                            {
                              // ISSUE: variable of a reference type
                              int& local;
                              // ISSUE: explicit reference operation
                              int num6 = checked (^(local = ref this.time) + this.servTime);
                              local = num6;
                              checked { ++num4; }
                            }
                            else
                            {
                              // ISSUE: variable of a reference type
                              int& local;
                              // ISSUE: explicit reference operation
                              int num6 = checked (^(local = ref this.time) + this.servTime);
                              local = num6;
                              checked { ++num5; }
                            }
                            if (checked (num4 + num5) >= this.DgMain.Rows.Count)
                              break;
                          }
                        }
                      }
                      finally
                      {
                        if (enumerator2 is IDisposable)
                          (enumerator2 as IDisposable).Dispose();
                      }
                      if (checked (num4 + num5) >= this.DgMain.Rows.Count)
                        break;
                    }
                  }
                  finally
                  {
                    if (enumerator1 is IDisposable)
                      (enumerator1 as IDisposable).Dispose();
                  }
                }
                IEnumerator enumerator3;
                if (checked (num4 + num5) < this.DgMain.Rows.Count)
                {
                  if (num4 < num2)
                  {
                    try
                    {
                      enumerator3 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                      while (enumerator3.MoveNext())
                      {
                        DataGridViewRow current = (DataGridViewRow) enumerator3.Current;
                        if (!this.CoverApps.Contains(Conversions.ToInteger(current.Cells["AssetID"].Value)))
                        {
                          if (this.CheckMainApps(current.Cells["Product"].Value.ToString().Split('-')[0], false))
                          {
                            // ISSUE: variable of a reference type
                            int& local;
                            // ISSUE: explicit reference operation
                            int num6 = checked (^(local = ref this.time) + this.servTime);
                            local = num6;
                            this.CoverApps.Add(Conversions.ToInteger(current.Cells["AssetID"].Value));
                            checked { ++num4; }
                            if (num4 >= num2)
                              break;
                          }
                        }
                      }
                    }
                    finally
                    {
                      if (enumerator3 is IDisposable)
                        (enumerator3 as IDisposable).Dispose();
                    }
                  }
                }
                IEnumerator enumerator4;
                if (checked (num4 + num5) < this.DgMain.Rows.Count)
                {
                  if (num5 < num3)
                  {
                    try
                    {
                      enumerator4 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                      while (enumerator4.MoveNext())
                      {
                        DataGridViewRow current = (DataGridViewRow) enumerator4.Current;
                        if (!this.CoverApps.Contains(Conversions.ToInteger(current.Cells["AssetID"].Value)))
                        {
                          if (!this.CheckMainApps(current.Cells["Product"].Value.ToString().Split('-')[0], false))
                          {
                            this.CoverApps.Add(Conversions.ToInteger(current.Cells["AssetID"].Value));
                            checked { ++num5; }
                            // ISSUE: variable of a reference type
                            int& local;
                            // ISSUE: explicit reference operation
                            int num6 = checked (^(local = ref this.time) + this.servTime);
                            local = num6;
                            if (num5 >= num3)
                              break;
                          }
                        }
                      }
                    }
                    finally
                    {
                      if (enumerator4 is IDisposable)
                        (enumerator4 as IDisposable).Dispose();
                    }
                  }
                }
                int num7 = 0;
                double num8 = 0.0;
                IEnumerator enumerator5;
                try
                {
                  enumerator5 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                  while (enumerator5.MoveNext())
                  {
                    DataGridViewRow current = (DataGridViewRow) enumerator5.Current;
                    if (!this.CoverApps.Contains(Conversions.ToInteger(current.Cells["AssetID"].Value)))
                    {
                      this.CheckMainApps(current.Cells["Product"].Value.ToString().Split('-')[0], false);
                      // ISSUE: variable of a reference type
                      int& local;
                      // ISSUE: explicit reference operation
                      int num6 = checked (^(local = ref this.time) + this.servTime);
                      local = num6;
                      if (Conversions.ToDouble(this.Pricing(current.Cells["Product"].Value.ToString().Split('-')[0])) > num8)
                        num8 = Conversions.ToDouble(this.Pricing(current.Cells["Product"].Value.ToString().Split('-')[0]));
                    }
                  }
                }
                finally
                {
                  if (enumerator5 is IDisposable)
                    (enumerator5 as IDisposable).Dispose();
                }
                IEnumerator enumerator6;
                try
                {
                  enumerator6 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                  while (enumerator6.MoveNext())
                  {
                    DataGridViewRow current = (DataGridViewRow) enumerator6.Current;
                    if (!this.CoverApps.Contains(Conversions.ToInteger(current.Cells["AssetID"].Value)))
                    {
                      this.ChargeApps.Add(Conversions.ToInteger(current.Cells["AssetID"].Value));
                      checked { ++num7; }
                      ComboBox cboPayTerms4 = this.cboPayTerms;
                      Combo.SetSelectedComboItem_By_Value(ref cboPayTerms4, Conversions.ToString(num1));
                      this.cboPayTerms = cboPayTerms4;
                      this.txtCharge.Text = checked (this.CoverApps.Count + num7) <= 1 ? "£" + Conversions.ToString(Conversions.ToDouble(this.txtCharge.Text) + num8) : "£" + Conversions.ToString(Conversions.ToDouble(this.txtCharge.Text) + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("ADDAPP", Enums.PickListTypes.PriceList)));
                      TextBox txtPayInst5;
                      string str5 = (txtPayInst5 = this.txtPayInst).Text + current.Cells["Product"].Value.ToString().Split('-')[0] + " Service Not covered under contract.\r\n";
                      txtPayInst5.Text = str5;
                    }
                  }
                  break;
                }
                finally
                {
                  if (enumerator6 is IDisposable)
                    (enumerator6 as IDisposable).Dispose();
                }
              }
              else
              {
                int num2 = 0;
                double num3 = 0.0;
                IEnumerator enumerator1;
                try
                {
                  enumerator1 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                  while (enumerator1.MoveNext())
                  {
                    DataGridViewRow current = (DataGridViewRow) enumerator1.Current;
                    if (Conversions.ToDouble(this.Pricing(current.Cells["Product"].Value.ToString().Split('-')[0])) > num3)
                      num3 = Conversions.ToDouble(this.Pricing(current.Cells["Product"].Value.ToString().Split('-')[0]));
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
                  enumerator2 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                  while (enumerator2.MoveNext())
                  {
                    DataGridViewRow current = (DataGridViewRow) enumerator2.Current;
                    this.ChargeApps.Add(Conversions.ToInteger(current.Cells["AssetID"].Value));
                    checked { ++num2; }
                    this.CheckMainApps(current.Cells["Product"].Value.ToString().Split('-')[0], false);
                    // ISSUE: variable of a reference type
                    int& local;
                    // ISSUE: explicit reference operation
                    int num4 = checked (^(local = ref this.time) + this.servTime);
                    local = num4;
                    ComboBox cboPayTerms3 = this.cboPayTerms;
                    Combo.SetSelectedComboItem_By_Value(ref cboPayTerms3, Conversions.ToString(num1));
                    this.cboPayTerms = cboPayTerms3;
                    this.txtCharge.Text = num2 <= 1 ? "£" + Conversions.ToString(num3) : "£" + Conversions.ToString(Conversions.ToDouble(this.txtCharge.Text) + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("ADDAPP", Enums.PickListTypes.PriceList)));
                  }
                  break;
                }
                finally
                {
                  if (enumerator2 is IDisposable)
                    (enumerator2 as IDisposable).Dispose();
                }
              }
          }
          if (this.OILNEEDED)
          {
            int num9 = (int) Interaction.MsgBox((object) "Please explain to the customer that the Oil boiler will need to be turned off the previous evening in order it cool for the service", MsgBoxStyle.OkOnly, (object) "Advice");
          }
        }
      }
      else
      {
        TextBox txtPayInst1;
        string str1 = (txtPayInst1 = this.txtPayInst).Text + "Breakdown job applied\r\n";
        txtPayInst1.Text = str1;
        bool flag1 = false;
        string description = App.DB.Picklists.Get_One_As_Object(69669).Description;
        string Left = Combo.get_GetSelectedItemValue(this.cboTypeOfWorks);
        IEnumerator enumerator1;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
        {
          this.SpecialTrade = "COMM";
          description = App.DB.Picklists.Get_One_As_Object(69788).Description;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
        {
          this.SpecialTrade = "PLUM";
          description = App.DB.Picklists.Get_One_As_Object(69787).Description;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
        {
          this.SpecialTrade = "ELEC";
          description = App.DB.Picklists.Get_One_As_Object(69789).Description;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(5), false) == 0)
        {
          this.SpecialTrade = "BANDM";
          description = App.DB.Picklists.Get_One_As_Object(69786).Description;
        }
        else
        {
          try
          {
            enumerator1 = this.SympDataView.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataRowView current = (DataRowView) enumerator1.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["SypID"], (object) 69783, false))
              {
                this.SpecialTrade = "PLUM";
                description = App.DB.Picklists.Get_One_As_Object(69787).Description;
              }
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["SypID"], (object) 69784, false))
              {
                this.SpecialTrade = "ELEC";
                description = App.DB.Picklists.Get_One_As_Object(69789).Description;
              }
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["SypID"], (object) 69785, false))
              {
                this.SpecialTrade = "BANDM";
                description = App.DB.Picklists.Get_One_As_Object(69786).Description;
              }
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
        }
        bool flag2 = false;
        bool flag3 = false;
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.SympDataView.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRowView current = (DataRowView) enumerator2.Current;
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["SypID"], (object) 69790, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["SypID"], (object) 69791, false))))
              flag2 = true;
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["SypID"], (object) 69663, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["SypID"], (object) 69664, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["SypID"], (object) 69668, false))))
              flag3 = true;
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        bool flag4 = false;
        bool flag5 = false;
        if (!this.Manualrecall)
        {
          DataTable lastVisit = App.DB.EngineerVisits.GetLastVisit(this.CurrentSite.SiteID);
          DataTable dataTable = new DataTable();
          if (lastVisit.Rows.Count > 0)
            dataTable = App.DB.EngineerVisits.GetSymptoms(Conversions.ToInteger(lastVisit.Rows[0]["Engineervisitid"]));
          IEnumerator enumerator3;
          try
          {
            enumerator3 = this.SympDataView.GetEnumerator();
            while (enumerator3.MoveNext())
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((DataRowView) enumerator3.Current)["Code"], (object) "RECALL ", false))
              {
                flag5 = true;
                break;
              }
            }
          }
          finally
          {
            if (enumerator3 is IDisposable)
              (enumerator3 as IDisposable).Dispose();
          }
          if (lastVisit.Rows.Count > 0)
          {
            if (dataTable.Rows.Count == 0)
            {
              if (((lastVisit.Rows.Count <= 0 || Information.IsDBNull(RuntimeHelpers.GetObjectValue(lastVisit.Rows[0]["StartdateTime"])) ? 0 : (DateTime.Compare(Conversions.ToDate(lastVisit.Rows[0]["StartdateTime"]).AddDays(28.0), DateTime.Today) < 0 ? 1 : 0)) & (flag5 ? 1 : 0)) != 0)
              {
                flag4 = true;
                this.RecallJobTypeID = Conversions.ToInteger(lastVisit.Rows[0]["JobTypeID"]);
                this.RecallJobID = Conversions.ToInteger(lastVisit.Rows[0]["JobID"]);
              }
            }
            else if (((Information.IsDBNull(RuntimeHelpers.GetObjectValue(lastVisit.Rows[0]["StartdateTime"])) ? 0 : (DateTime.Compare(Conversions.ToDate(lastVisit.Rows[0]["StartdateTime"]).AddDays(28.0), DateTime.Today) < 0 ? 1 : 0)) & (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) == 0 ? 1 : 0)) != 0)
            {
              IEnumerator enumerator4;
              try
              {
                enumerator4 = dataTable.Rows.GetEnumerator();
                while (enumerator4.MoveNext())
                {
                  DataRow current1 = (DataRow) enumerator4.Current;
                  IEnumerator enumerator5;
                  try
                  {
                    enumerator5 = this.SympDataView.GetEnumerator();
                    while (enumerator5.MoveNext())
                    {
                      DataRowView current2 = (DataRowView) enumerator5.Current;
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current2["SypID"], current1["SymptomID"], false) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(current2["SypID"], (object) 69668, false))
                      {
                        flag4 = true;
                        this.RecallJobTypeID = Conversions.ToInteger(lastVisit.Rows[0]["JobTypeID"]);
                        this.RecallJobID = Conversions.ToInteger(lastVisit.Rows[0]["JobID"]);
                        break;
                      }
                    }
                  }
                  finally
                  {
                    if (enumerator5 is IDisposable)
                      (enumerator5 as IDisposable).Dispose();
                  }
                  if (flag4)
                    break;
                }
              }
              finally
              {
                if (enumerator4 is IDisposable)
                  (enumerator4 as IDisposable).Dispose();
              }
              if (!flag4)
              {
                TextBox txtPayInst2;
                string str2 = (txtPayInst2 = this.txtPayInst).Text + "A visit has been carried out within 28 days but as the symptoms have changed, it is suggested this is an new fault\r\n";
                txtPayInst2.Text = str2;
              }
            }
          }
          this.chkRecall.Checked = flag4;
        }
        else
          flag4 = this.chkRecall.Checked;
        if (flag4)
        {
          TextBox txtPayInst2;
          string str2 = (txtPayInst2 = this.txtPayInst).Text + "This visit has been marked as a recall no charge will be applied\r\n";
          txtPayInst2.Text = str2;
          ComboBox cboPayTerms = this.cboPayTerms;
          Combo.SetSelectedComboItem_By_Value(ref cboPayTerms, Conversions.ToString(4));
          this.cboPayTerms = cboPayTerms;
          this.txtCharge.Text = "£0.00";
        }
        else
        {
          if (flag5)
          {
            TextBox txtPayInst2;
            string str2 = (txtPayInst2 = this.txtPayInst).Text + "This visit has been marked as a recall no charge will be applied\r\n";
            txtPayInst2.Text = str2;
          }
          switch (customer.CustomerTypeID)
          {
            case 516:
              this.time = 45;
              TextBox txtPayInst3;
              string str3 = (txtPayInst3 = this.txtPayInst).Text + "Social Housing or Council works are not chargeable\r\n";
              txtPayInst3.Text = str3;
              ComboBox cboPayTerms1 = this.cboPayTerms;
              Combo.SetSelectedComboItem_By_Value(ref cboPayTerms1, Conversions.ToString(4));
              this.cboPayTerms = cboPayTerms1;
              this.txtCharge.Text = "£0.00";
              break;
            case 517:
              this.time = 45;
              TextBox txtPayInst4;
              string str4 = (txtPayInst4 = this.txtPayInst).Text + "Insurance Works are OTI\r\n";
              txtPayInst4.Text = str4;
              ComboBox cboPayTerms2 = this.cboPayTerms;
              Combo.SetSelectedComboItem_By_Value(ref cboPayTerms2, Conversions.ToString(2));
              this.cboPayTerms = cboPayTerms2;
              this.txtCharge.Text = "£0.00";
              break;
            default:
              this.time = 45;
              object obj = (object) false;
              if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value)))
              {
                this.CurrentContract = new ContractOriginal();
                this.CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value));
              }
              if (this.CurrentContract != null)
              {
                obj = (object) true;
                DataTable dataTable1 = new DataTable();
                DataRow dataRow;
                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value)))
                {
                  this.CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value));
                  dataTable1 = App.DB.ContractOriginalSite.GetAll_ContractID2(Conversions.ToInteger(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value), this.CurrentSite.CustomerID).Table;
                  dataRow = dataTable1.Select("tick = 1")[0];
                }
                ComboBox cboPayTerms3 = this.cboPayTerms;
                Combo.SetSelectedComboItem_By_Value(ref cboPayTerms3, Conversions.ToString(1));
                this.cboPayTerms = cboPayTerms3;
                TextBox txtPayInst2;
                string str2 = (txtPayInst2 = this.txtPayInst).Text + "Works charges would normally be covered by Contract\r\n";
                txtPayInst2.Text = str2;
                this.txtCharge.Text = "£0.00";
                ComboBox cboPayTerms4;
                if (flag2 & !this.CurrentContract.GasSupplyPipework && Interaction.MsgBox((object) "Symptoms Indicate a gas leak has been suggested. Is this leak / smell located near / on the covered appliance", MsgBoxStyle.YesNo, (object) null) == MsgBoxResult.No)
                {
                  TextBox txtPayInst5;
                  string str5 = (txtPayInst5 = this.txtPayInst).Text + "Gas leak works not covered by any contract extras\r\n";
                  txtPayInst5.Text = str5;
                  flag1 = true;
                  this.txtCharge.Text = "£" + description;
                  this.GasConfirmedInBoiler = false;
                  cboPayTerms4 = this.cboPayTerms;
                  Combo.SetSelectedComboItem_By_Value(ref cboPayTerms4, Conversions.ToString(num1));
                  this.cboPayTerms = cboPayTerms4;
                }
                if (flag3 & (this.CurrentContract.ContractTypeID != 68032 & this.CurrentContract.ContractTypeID != 69767 & this.CurrentContract.ContractTypeID != 369))
                {
                  TextBox txtPayInst5;
                  string str5 = (txtPayInst5 = this.txtPayInst).Text + "This Coverplan does not cover system issues\r\n";
                  txtPayInst5.Text = str5;
                  this.txtCharge.Text = "£" + description;
                  cboPayTerms4 = this.cboPayTerms;
                  Combo.SetSelectedComboItem_By_Value(ref cboPayTerms4, Conversions.ToString(num1));
                  this.cboPayTerms = cboPayTerms4;
                }
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.SpecialTrade, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.SpecialTrade, "PLUM", false) == 0 & !this.CurrentContract.PlumbingDrainage | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.SpecialTrade, "ELEC", false) == 0 & !this.CurrentContract.PlumbingDrainage | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.SpecialTrade, "BANDM", false) == 0 & !this.CurrentContract.WindowLockPest)
                {
                  cboPayTerms4 = this.cboPayTerms;
                  Combo.SetSelectedComboItem_By_Value(ref cboPayTerms4, Conversions.ToString(num1));
                  this.cboPayTerms = cboPayTerms4;
                  this.txtCharge.Text = "£" + description;
                  TextBox txtPayInst5;
                  string str5 = (txtPayInst5 = this.txtPayInst).Text + "Works not covered by any contract extras\r\n";
                  txtPayInst5.Text = str5;
                }
                DataTable dataTable2 = new DataTable();
                DataTable table = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(Conversions.ToInteger(dataRow["ContractSiteID"]), this.CurrentSite.SiteID).Table;
                int num2 = 0;
                int num3 = 0;
                if (dataTable1.Rows.Count > 0)
                {
                  num2 = Conversions.ToInteger(dataTable1.Rows[0]["MainAppliances"]);
                  num3 = Conversions.ToInteger(dataTable1.Rows[0]["SecondryAppliances"]);
                }
                int num4 = 0;
                int num5 = 0;
                IEnumerator enumerator3;
                if (table.Rows.Count > 0 && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["AssetID"])))
                {
                  try
                  {
                    enumerator3 = table.Rows.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                      DataRow current1 = (DataRow) enumerator3.Current;
                      IEnumerator enumerator4;
                      try
                      {
                        enumerator4 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                        while (enumerator4.MoveNext())
                        {
                          DataGridViewRow current2 = (DataGridViewRow) enumerator4.Current;
                          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current2.Cells["AssetID"].Value, current1["AssetID"], false))
                          {
                            this.CoverApps.Add(Conversions.ToInteger(current1["AssetID"]));
                            if (this.CheckMainApps(current2.Cells["Product"].Value.ToString().Split('-')[0], false))
                              checked { ++num4; }
                            else
                              checked { ++num5; }
                            if (checked (num4 + num5) >= this.DgMain.Rows.Count)
                              break;
                          }
                        }
                      }
                      finally
                      {
                        if (enumerator4 is IDisposable)
                          (enumerator4 as IDisposable).Dispose();
                      }
                      if (checked (num4 + num5) >= this.DgMain.Rows.Count)
                        break;
                    }
                  }
                  finally
                  {
                    if (enumerator3 is IDisposable)
                      (enumerator3 as IDisposable).Dispose();
                  }
                }
                IEnumerator enumerator5;
                if (checked (num4 + num5) < this.DgMain.Rows.Count)
                {
                  if (num4 < num2)
                  {
                    try
                    {
                      enumerator5 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                      while (enumerator5.MoveNext())
                      {
                        DataGridViewRow current = (DataGridViewRow) enumerator5.Current;
                        if (!this.CoverApps.Contains(Conversions.ToInteger(current.Cells["AssetID"].Value)))
                        {
                          if (this.CheckMainApps(current.Cells["Product"].Value.ToString().Split('-')[0], false))
                          {
                            this.CoverApps.Add(Conversions.ToInteger(current.Cells["AssetID"].Value));
                            checked { ++num4; }
                            if (num4 >= num2)
                              break;
                          }
                        }
                      }
                    }
                    finally
                    {
                      if (enumerator5 is IDisposable)
                        (enumerator5 as IDisposable).Dispose();
                    }
                  }
                }
                IEnumerator enumerator6;
                if (checked (num4 + num5) < this.DgMain.Rows.Count)
                {
                  if (num5 < num3)
                  {
                    try
                    {
                      enumerator6 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                      while (enumerator6.MoveNext())
                      {
                        DataGridViewRow current = (DataGridViewRow) enumerator6.Current;
                        if (!this.CoverApps.Contains(Conversions.ToInteger(current.Cells["AssetID"].Value)))
                        {
                          if (!this.CheckMainApps(current.Cells["Product"].Value.ToString().Split('-')[0], false))
                          {
                            this.CoverApps.Add(Conversions.ToInteger(current.Cells["AssetID"].Value));
                            checked { ++num5; }
                            if (num5 >= num3)
                              break;
                          }
                        }
                      }
                    }
                    finally
                    {
                      if (enumerator6 is IDisposable)
                        (enumerator6 as IDisposable).Dispose();
                    }
                  }
                }
                IEnumerator enumerator7;
                try
                {
                  enumerator7 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                  while (enumerator7.MoveNext())
                  {
                    if (!this.CoverApps.Contains(Conversions.ToInteger(((DataGridViewRow) enumerator7.Current).Cells["AssetID"].Value)))
                    {
                      TextBox txtPayInst5;
                      string str5 = (txtPayInst5 = this.txtPayInst).Text + "Additional Appliances listed to that which are covered in plan or non appliance related , A callout Charge Has been Applied\r\n";
                      txtPayInst5.Text = str5;
                      cboPayTerms4 = this.cboPayTerms;
                      Combo.SetSelectedComboItem_By_Value(ref cboPayTerms4, Conversions.ToString(num1));
                      this.cboPayTerms = cboPayTerms4;
                      TextBox txtPayInst6;
                      string str6 = (txtPayInst6 = this.txtPayInst).Text + "Breakdown Charge Applied\r\n";
                      txtPayInst6.Text = str6;
                      this.txtCharge.Text = "£" + description;
                    }
                  }
                }
                finally
                {
                  if (enumerator7 is IDisposable)
                    (enumerator7 as IDisposable).Dispose();
                }
                IEnumerator enumerator8;
                try
                {
                  enumerator8 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
                  while (enumerator8.MoveNext())
                  {
                    if (!this.CoverApps.Contains(Conversions.ToInteger(((DataGridViewRow) enumerator8.Current).Cells["AssetID"].Value)))
                      ;
                  }
                }
                finally
                {
                  if (enumerator8 is IDisposable)
                    (enumerator8 as IDisposable).Dispose();
                }
              }
              else
              {
                ComboBox cboPayTerms3 = this.cboPayTerms;
                Combo.SetSelectedComboItem_By_Value(ref cboPayTerms3, Conversions.ToString(num1));
                this.cboPayTerms = cboPayTerms3;
                TextBox txtPayInst2;
                string str2 = (txtPayInst2 = this.txtPayInst).Text + "Breakdown Charge Applied\r\n";
                txtPayInst2.Text = str2;
                this.txtCharge.Text = "£" + description;
              }
              bool flag6 = false;
              IEnumerator enumerator9;
              try
              {
                enumerator9 = this.SympDataView.GetEnumerator();
                while (enumerator9.MoveNext())
                {
                  DataRowView current = (DataRowView) enumerator9.Current;
                  if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["Code"], (object) "USER ", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["Code"], (object) "NOISE ", false))))
                  {
                    flag6 = true;
                    if (this.CurrentContract != null)
                    {
                      ComboBox cboPayTerms3 = this.cboPayTerms;
                      Combo.SetSelectedComboItem_By_Value(ref cboPayTerms3, Conversions.ToString(num1));
                      this.cboPayTerms = cboPayTerms3;
                      TextBox txtPayInst2;
                      string str2 = (txtPayInst2 = this.txtPayInst).Text + "Symptoms selected indicate this visit should be chargeable.";
                      txtPayInst2.Text = str2;
                      this.txtCharge.Text = "£" + description;
                      break;
                    }
                    break;
                  }
                }
                break;
              }
              finally
              {
                if (enumerator9 is IDisposable)
                  (enumerator9 as IDisposable).Dispose();
              }
          }
        }
      }
      IEnumerator enumerator10;
      try
      {
        enumerator10 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
        while (enumerator10.MoveNext())
          this.CheckMainApps(((DataGridViewRow) enumerator10.Current).Cells["Product"].Value.ToString().Split('-')[0], false);
      }
      finally
      {
        if (enumerator10 is IDisposable)
          (enumerator10 as IDisposable).Dispose();
      }
      if (customer.CustomerTypeID == 513)
      {
        ComboBox cboPayTerms = this.cboPayTerms;
        Combo.SetSelectedComboItem_By_Value(ref cboPayTerms, Conversions.ToString(2));
        this.cboPayTerms = cboPayTerms;
      }
      if (this.time > 200)
        this.time = 200;
      this.priTime = this.time;
      this.visitcharge1 = Conversions.ToDouble(this.txtCharge.Text);
      this.visitterm1 = Combo.get_GetSelectedItemDescription(this.cboPayTerms);
    }

    public void AdditionalCharging()
    {
      this.visitcharge2 = 0.0;
      this.visitterm2 = "";
      this.time = 0;
      int num1;
      switch (this.CurrentCustomer.Terms)
      {
        case 69650:
          num1 = 3;
          break;
        case 69651:
        case 69652:
        case 69655:
          num1 = 2;
          break;
        default:
          num1 = 3;
          break;
      }
      TextBox txtPayInst1;
      string str1 = (txtPayInst1 = this.txtPayInst).Text + "\r\n";
      txtPayInst1.Text = str1;
      FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(this.CurrentSite.CustomerID);
      List<int> intList = new List<int>();
      int num2 = 0;
      int num3 = 0;
      double num4 = 0.0;
      IEnumerator enumerator1;
      if (this.DGAdditional.Rows.Count > 0)
      {
        try
        {
          enumerator1 = this.DGVAdditional.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRowView current1 = (DataRowView) enumerator1.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current1["ID"], (object) "1", false))
            {
              this.DGVAdditional.RowFilter = "ID=1";
              num4 = 0.0;
              if (customer.CustomerTypeID == 516)
              {
                this.time = 40;
              }
              else
              {
                DataTable dataTable1 = new DataTable();
                ContractOriginal contractOriginal;
                DataRow dataRow;
                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value)))
                {
                  contractOriginal = App.DB.ContractOriginal.Get(Conversions.ToInteger(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value));
                  dataRow = App.DB.ContractOriginalSite.GetAll_ContractID2(Conversions.ToInteger(this.SelecteddgvSitesDataRow.Cells["ContractID"].Value), this.CurrentSite.CustomerID).Table.Select("tick = 1")[0];
                }
                if (contractOriginal != null)
                {
                  ComboBox cboPayTerms1 = this.cboPayTerms;
                  Combo.SetSelectedComboItem_By_Value(ref cboPayTerms1, Conversions.ToString(1));
                  this.cboPayTerms = cboPayTerms1;
                  TextBox txtPayInst2;
                  string str2 = (txtPayInst2 = this.txtPayInst).Text + "Service charges would normally be covered by Contract\r\n";
                  txtPayInst2.Text = str2;
                  DataTable dataTable2 = new DataTable();
                  DataTable table = App.DB.ContractOriginalPPMVisit.GetAllAssets_For_ContractSiteID(Conversions.ToInteger(dataRow["ContractSiteID"])).Table;
                  if (table.Rows.Count == 0)
                  {
                    TextBox txtPayInst3;
                    string str3 = (txtPayInst3 = this.txtPayInst).Text + "Any Service Visits Have already been completed for this Contract Period servicing will be chargeable\r\n";
                    txtPayInst3.Text = str3;
                  }
                  else
                  {
                    int integer1 = Conversions.ToInteger(table.Rows[0]["MainAppliances"]);
                    int integer2 = Conversions.ToInteger(table.Rows[0]["SecondryAppliances"]);
                    this.UseContractVisit = true;
                    IEnumerator enumerator2;
                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["AssetID"])))
                    {
                      try
                      {
                        enumerator2 = table.Rows.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                          DataRow current2 = (DataRow) enumerator2.Current;
                          IEnumerator enumerator3;
                          try
                          {
                            enumerator3 = this.DGVAdditional.GetEnumerator();
                            while (enumerator3.MoveNext())
                            {
                              DataRowView current3 = (DataRowView) enumerator3.Current;
                              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current3["AssetID"], current2["AssetID"], false))
                              {
                                intList.Add(Conversions.ToInteger(current2["AssetID"]));
                                if (this.CheckMainApps(current3["Product"].ToString().Split('-')[0], false))
                                {
                                  // ISSUE: variable of a reference type
                                  int& local;
                                  // ISSUE: explicit reference operation
                                  int num5 = checked (^(local = ref this.time) + this.servTime);
                                  local = num5;
                                  checked { ++num2; }
                                }
                                else
                                {
                                  // ISSUE: variable of a reference type
                                  int& local;
                                  // ISSUE: explicit reference operation
                                  int num5 = checked (^(local = ref this.time) + this.servTime);
                                  local = num5;
                                  checked { ++num3; }
                                }
                                if (checked (num2 + num3) >= this.DgMain.Rows.Count)
                                  break;
                              }
                            }
                          }
                          finally
                          {
                            if (enumerator3 is IDisposable)
                              (enumerator3 as IDisposable).Dispose();
                          }
                          if (checked (num2 + num3) >= this.DgMain.Rows.Count)
                            break;
                        }
                      }
                      finally
                      {
                        if (enumerator2 is IDisposable)
                          (enumerator2 as IDisposable).Dispose();
                      }
                    }
                    if (num2 < integer1)
                    {
                      if (!intList.Contains(Conversions.ToInteger(current1["AssetID"])))
                      {
                        if (this.CheckMainApps(current1["Product"].ToString().Split('-')[0], true))
                        {
                          intList.Add(Conversions.ToInteger(current1["AssetID"]));
                          checked { ++num2; }
                          // ISSUE: variable of a reference type
                          int& local;
                          // ISSUE: explicit reference operation
                          int num5 = checked (^(local = ref this.time) + this.servTime);
                          local = num5;
                        }
                      }
                      else
                        goto label_83;
                    }
                    if (num3 < integer2)
                    {
                      if (!intList.Contains(Conversions.ToInteger(current1["AssetID"])))
                      {
                        if (!this.CheckMainApps(current1["Product"].ToString().Split('-')[0], true))
                        {
                          intList.Add(Conversions.ToInteger(current1["AssetID"]));
                          checked { ++num3; }
                          // ISSUE: variable of a reference type
                          int& local;
                          // ISSUE: explicit reference operation
                          int num5 = checked (^(local = ref this.time) + this.servTime);
                          local = num5;
                          if (num3 >= integer2)
                            break;
                        }
                      }
                      else
                        goto label_83;
                    }
                    int num6 = 0;
                    double num7 = 0.0;
                    IEnumerator enumerator4;
                    try
                    {
                      enumerator4 = this.DGVAdditional.GetEnumerator();
                      while (enumerator4.MoveNext())
                      {
                        DataRowView current2 = (DataRowView) enumerator4.Current;
                        if (!intList.Contains(Conversions.ToInteger(current2["AssetID"])))
                        {
                          if (Conversions.ToDouble(this.Pricing(current2["Product"].ToString().Split('-')[0])) > num7)
                            num7 = Conversions.ToDouble(this.Pricing(current2["Product"].ToString().Split('-')[0]));
                        }
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
                      enumerator5 = this.DGVAdditional.GetEnumerator();
                      while (enumerator5.MoveNext())
                      {
                        DataRowView current2 = (DataRowView) enumerator5.Current;
                        if (!intList.Contains(Conversions.ToInteger(current2["AssetID"])))
                        {
                          this.ChargeApps.Add(Conversions.ToInteger(current2["AssetID"]));
                          checked { ++num6; }
                          ComboBox cboPayTerms2 = this.cboPayTerms;
                          Combo.SetSelectedComboItem_By_Value(ref cboPayTerms2, Conversions.ToString(num1));
                          this.cboPayTerms = cboPayTerms2;
                          this.CheckMainApps(current2["Product"].ToString().Split('-')[0], false);
                          // ISSUE: variable of a reference type
                          int& local;
                          // ISSUE: explicit reference operation
                          int num5 = checked (^(local = ref this.time) + this.servTime);
                          local = num5;
                          if (checked (intList.Count + num6) > 1)
                            num4 += Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("ADDAPP", Enums.PickListTypes.PriceList));
                          else
                            num4 += Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("BDOWNPLUS", Enums.PickListTypes.PriceList));
                          TextBox txtPayInst3;
                          string str3 = (txtPayInst3 = this.txtPayInst).Text + current2["Product"].ToString().Split('-')[0] + " Service Not covered under contract.\r\n";
                          txtPayInst3.Text = str3;
                        }
                      }
                    }
                    finally
                    {
                      if (enumerator5 is IDisposable)
                        (enumerator5 as IDisposable).Dispose();
                    }
                    if (this.chkCert.Checked && this.DGVAdditional.Count > 0)
                    {
                      TextBox txtPayInst3;
                      string str3 = (txtPayInst3 = this.txtPayInst).Text + " LandLord Certificate covered under coverplan\r\n";
                      txtPayInst3.Text = str3;
                    }
                  }
                }
                else
                {
                  ComboBox cboPayTerms = this.cboPayTerms;
                  Combo.SetSelectedComboItem_By_Value(ref cboPayTerms, Conversions.ToString(num1));
                  this.cboPayTerms = cboPayTerms;
                  double num5 = 0.0;
                  IEnumerator enumerator2;
                  try
                  {
                    enumerator2 = this.DGVAdditional.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                      double num6 = Helper.MakeDoubleValid((object) this.Pricing(((DataRowView) enumerator2.Current)["Product"].ToString().Split('-')[0]));
                      if (num6 > num5)
                        num5 = num6;
                      // ISSUE: variable of a reference type
                      int& local;
                      // ISSUE: explicit reference operation
                      int num7 = checked (^(local = ref this.time) + this.servTime);
                      local = num7;
                    }
                  }
                  finally
                  {
                    if (enumerator2 is IDisposable)
                      (enumerator2 as IDisposable).Dispose();
                  }
                  num4 += Helper.MakeDoubleValid((object) App.DB.Picklists.Get_Single_Description("ADDAPP", Enums.PickListTypes.PriceList)) * (double) checked (this.DGVAdditional.Count - 1) + num5;
                  if (this.chkCert.Checked && this.DGVAdditional.Count > 0)
                    num4 += Helper.MakeDoubleValid((object) App.DB.Picklists.Get_Single_Description("LLCERT", Enums.PickListTypes.PriceList));
                }
              }
            }
label_83:;
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
      }
      this.txtCharge.Text = "£" + Conversions.ToString(Conversions.ToDouble(this.txtCharge.Text) + num4);
      this.secTime = this.time;
      this.DGVAdditional.RowFilter = "1=1";
      this.visitcharge2 = num4;
      this.visitterm2 = Combo.get_GetSelectedItemDescription(this.cboPayTerms);
    }

    private void btnOption_Click(object sender, EventArgs e)
    {
      Button button1 = (Button) sender;
      int integer = Conversions.ToInteger(button1.Tag.ToString().Split('^')[0]);
      DateTime date = Conversions.ToDate(button1.Tag.ToString().Split('^')[1]);
      string Period = button1.Tag.ToString().Split('^')[2];
      Button button2 = (Button) this.ParentForm.Controls.Find("btnSaveProg", true)[0];
      if (!this.RunValidation())
        return;
      button2.Visible = false;
      this.BookingDetail = "Visit booked with " + App.DB.Engineer.Engineer_Get(integer).Name + " Scheduled " + date.ToString("dd/MM/yyyy") + " " + Period;
      try
      {
        if (Conversions.ToInteger(this.txtCharge.Text.Replace("£", "")) > 0)
        {
          // ISSUE: variable of a reference type
          string& local;
          // ISSUE: explicit reference operation
          string str = ^(local = ref this.BookingDetail) + " Charging " + Strings.Format((object) Conversions.ToDouble(this.txtCharge.Text), "C");
          local = str;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.btnxx6.Enabled = false;
      // ISSUE: variable of a reference type
      int& local1;
      // ISSUE: explicit reference operation
      int num1 = checked (^(local1 = ref this.visitsBooked) + 1);
      local1 = num1;
      this.Cursor = Cursors.WaitCursor;
      FrmAdditionalNotes frmAdditionalNotes = new FrmAdditionalNotes();
      int num2 = (int) frmAdditionalNotes.ShowDialog();
      Job visits1 = this.CreateVisits(integer, date, Period, (double) this.priTime, frmAdditionalNotes.txtAdditionalNotes.Text, this.visitsBooked);
      this.CurrentJob = visits1;
      // ISSUE: variable of a reference type
      string& local2;
      // ISSUE: explicit reference operation
      string str1 = ^(local2 = ref this.BookingDetail) + " Job Number : " + visits1.JobNumber;
      local2 = str1;
      if (this.chkKeepTogether.Checked & this.secTime > 0)
      {
        // ISSUE: variable of a reference type
        int& local3;
        // ISSUE: explicit reference operation
        int num3 = checked (^(local3 = ref this.visitsBooked) + 1);
        local3 = num3;
        Job visits2 = this.CreateVisits(integer, date, Period, (double) this.secTime, frmAdditionalNotes.txtAdditionalNotes.Text, this.visitsBooked);
        // ISSUE: variable of a reference type
        string& local4;
        // ISSUE: explicit reference operation
        string str2 = ^(local4 = ref this.BookingDetail) + ", " + visits2.JobNumber;
        local4 = str2;
      }
      else if (this.secTime > 0)
        this.FindAppointments(true);
      this.lblBookedInfo.Text = this.BookingDetail + " (Click here to view job)";
      this.Cursor = Cursors.Default;
      this.btnxx6.Enabled = true;
      this.Notes();
    }

    public bool RunValidation()
    {
      if (!this.CurrentSite.PoNumReqd || this.txtPONumber.Text.Length >= 1)
        ;
      return true;
    }

    public Job CreateVisits(
      int EngineerID,
      DateTime Datein,
      string Period,
      double time,
      string additionalNotes,
      int visit = 1)
    {
      bool flag1 = false;
      if (this.CurrentJob == null | visit == 2)
        flag1 = true;
      Job oJob = !flag1 ? this.CurrentJob : new Job();
      double num1 = time;
      if (this.chkRecall.Checked & this.RecallJobTypeID == 4703 & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) > 0U & flag1)
      {
        oJob = App.DB.Job.Job_Get(this.RecallJobID);
      }
      else
      {
        DataSet dataSet = new DataSet();
        if (flag1)
        {
          JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout);
          oJob.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
        }
        oJob.SetPropertyID = (object) this.CurrentSite.SiteID;
        oJob.SetJobDefinitionEnumID = (object) 3;
        if (this.jobtype.ToUpper().Contains("SERVICE") | visit == 2)
        {
          oJob.SetJobTypeID = (object) Helper.MakeIntegerValid((object) Enums.JobTypes.Service);
          if (this.chkCert.Checked)
            oJob.SetJobTypeID = (object) Helper.MakeIntegerValid((object) Enums.JobTypes.ServiceCertificate);
        }
        else
          oJob.SetJobTypeID = !(this.btnxxOther.BackColor == Color.PaleGreen & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboTypeOfWorks)) > 0.0) ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SOR", false) != 0 ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) != 0 ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "PLUMBING", false) != 0 ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "CARPENTRY", false) != 0 ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "ELECTRICAL", false) != 0 ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "MULTI TRADE", false) != 0 ? (object) Helper.MakeIntegerValid((object) Enums.JobTypes.Dayworks) : (object) 71044) : (object) Helper.MakeIntegerValid((object) Enums.JobTypes.RenewablesElectrical)) : (object) 71039) : (object) Helper.MakeIntegerValid((object) Enums.JobTypes.Plumbing)) : (object) Helper.MakeIntegerValid((object) Enums.JobTypes.Breakdown)) : (object) Helper.MakeIntegerValid((object) Enums.JobTypes.Dayworks)) : (object) Combo.get_GetSelectedItemValue(this.cboTypeOfWorks);
        oJob.SetCreatedByUserID = (object) App.loggedInUser.UserID;
        oJob.SetPONumber = (object) DBNull.Value;
        oJob.SetQuoteID = (object) 0;
        oJob.SetContractID = (object) 0;
        oJob.SetToBePartPaid = (object) false;
        oJob.SetRetention = (object) 0;
        oJob.SetCollectPayment = (object) false;
        oJob.SetPOC = (object) false;
        oJob.SetFOC = (object) false;
        oJob.SetOTI = (object) false;
        if (visit == 1)
        {
          string visitterm1 = this.visitterm1;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(visitterm1, "OTI", false) != 0)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(visitterm1, "POC", false) != 0)
              oJob.SetFOC = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(visitterm1, "FOC", false) == 0 ? (object) true : (object) true;
            else
              oJob.SetPOC = (object) true;
          }
          else
            oJob.SetOTI = (object) true;
        }
        oJob.SetDeleted = false;
        ArrayList arrayList = new ArrayList();
        if (!flag1)
          App.DB.ExecuteScalar("Delete tblJobAsset where JobID = " + Conversions.ToString(this.CurrentJob.JobID), true, false);
        IEnumerator enumerator1;
        IEnumerator enumerator2;
        if (visit == 1)
        {
          try
          {
            enumerator1 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataGridViewRow current = (DataGridViewRow) enumerator1.Current;
              if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (current.Cells["Product"].Value.ToString().Contains("- Unknown") | current.Cells["Product"].Value.ToString().Contains("Non Appliance Related")), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLess(current.Cells["AssetID"].Value, (object) 21, false))))
                arrayList.Add((object) new JobAsset()
                {
                  SetAssetID = RuntimeHelpers.GetObjectValue(current.Cells["AssetID"].Value),
                  SetJobID = (object) oJob.JobID
                });
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
        }
        else
        {
          try
          {
            enumerator2 = ((IEnumerable) this.DGAdditional.Rows).GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataGridViewRow current = (DataGridViewRow) enumerator2.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current.Cells["ID"].Value, (object) 1, false))
                arrayList.Add((object) new JobAsset()
                {
                  SetAssetID = RuntimeHelpers.GetObjectValue(current.Cells["AssetID"].Value),
                  SetJobID = (object) oJob.JobID
                });
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
        oJob.Assets = arrayList;
      }
      JobOfWork jobOfWork = !flag1 ? App.DB.JobOfWorks.JobOfWork_Get(this.currentVisit.JobOfWorkID) : new JobOfWork();
      jobOfWork.SetJobID = (object) oJob.JobID;
      jobOfWork.SetDeleted = Conversions.ToBoolean("0");
      jobOfWork.SetPONumber = (object) this.txtPONumber.Text;
      jobOfWork.SetStatus = (object) "1";
      jobOfWork.SetPriority = (object) Combo.get_GetSelectedItemValue(this.cboPriority);
      if (flag1)
        jobOfWork.PriorityDateSet = DateTime.Now;
      else if (DateTime.Compare(jobOfWork.PriorityDateSet, new DateTime(2001, 1, 1)) < 0 | DateTime.Compare(jobOfWork.PriorityDateSet, DateTime.MinValue) == 0)
        jobOfWork.PriorityDateSet = DateTime.Now;
      if (!flag1)
        App.DB.JobItems.DeleteAll_ForJOW(this.currentVisit.JobOfWorkID);
      DataTable table = App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(this.CurrentCustomer.CustomerID).Table;
      DataTable dataTable1 = table.Clone();
      int num2 = 0;
      IEnumerator enumerator3;
      IEnumerator enumerator4;
      IEnumerator enumerator5;
      if (this.CurrentCustomer.CustomerTypeID == 516)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) == 0 | visit == 2)
        {
          try
          {
            dataTable1.Rows.Add(table.Select("Code='EA7007,'")[0].ItemArray);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) == 0)
        {
          try
          {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPriority)) == 66983.0)
              dataTable1.Rows.Add(table.Select("Code='EA7003'")[0].ItemArray);
            else
              dataTable1.Rows.Add(table?.Select("Code='EA7005'")[0].ItemArray);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SOR", false) == 0)
        {
          try
          {
            IEnumerator enumerator1;
            try
            {
              enumerator1 = ((IEnumerable) this.DGSOR.Rows).GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataGridViewRow current = (DataGridViewRow) enumerator1.Current;
                dataTable1.Rows.Add(table.Select("Code='" + current.Cells["code"].Value.ToString() + "'")[0].ItemArray);
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
        }
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) == 0 | visit == 2)
      {
        if (visit == 1)
        {
          try
          {
            enumerator3 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
            while (enumerator3.MoveNext())
            {
              DataGridViewRow current = (DataGridViewRow) enumerator3.Current;
              try
              {
                if (num2 > 0)
                {
                  dataTable1.Rows.Add(table.Select("Code='SERVADD'")[0].ItemArray);
                  goto label_116;
                }
                else
                {
                  bool flag2 = true;
                  int num3;
                  if ((flag2 ? 1 : 0) != (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("SOLID") ? 1 : 0))
                  {
                    if ((flag2 ? 1 : 0) != (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("WOOD") ? 1 : 0))
                    {
                      num3 = (flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("OPEN FIRE") ? 1 : 0) ? 1 : 0;
                      goto label_71;
                    }
                  }
                  num3 = 1;
label_71:
                  if (num3 != 0)
                  {
                    dataTable1.Rows.Add(table.Select("Code='EA7001^'")[0].ItemArray);
                    checked { ++num2; }
                  }
                  else
                  {
                    int num4;
                    if ((flag2 ? 1 : 0) != (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("COMMERCIAL") ? 1 : 0))
                      num4 = (flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("CONVECTOR HEATER") ? 1 : 0) ? 1 : 0;
                    else
                      num4 = 1;
                    if (num4 != 0)
                    {
                      dataTable1.Rows.Add(table.Select("Code='C1'")[0].ItemArray);
                      checked { ++num2; }
                    }
                    else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("STORE") ? 1 : 0))
                    {
                      dataTable1.Rows.Add(table.Select("Code='SV5'")[0].ItemArray);
                      checked { ++num2; }
                    }
                    else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("OIL BOILER") ? 1 : 0))
                    {
                      dataTable1.Rows.Add(table.Select("Code='SVOB'")[0].ItemArray);
                      checked { ++num2; }
                    }
                    else
                    {
                      int num5;
                      if ((flag2 ? 1 : 0) != (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("BOILER") ? 1 : 0))
                      {
                        if ((flag2 ? 1 : 0) != (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("COND BOILER") ? 1 : 0))
                        {
                          if ((flag2 ? 1 : 0) != (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("COND COMBI") ? 1 : 0))
                          {
                            if ((flag2 ? 1 : 0) != (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("BACK BOILER") ? 1 : 0))
                            {
                              if ((flag2 ? 1 : 0) != (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("STD EFF BOILER") ? 1 : 0))
                              {
                                num5 = (flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("STD EFF COMBI") ? 1 : 0) ? 1 : 0;
                                goto label_89;
                              }
                            }
                          }
                        }
                      }
                      num5 = 1;
label_89:
                      if (num5 != 0)
                      {
                        dataTable1.Rows.Add(table.Select("Code='SV1'")[0].ItemArray);
                        checked { ++num2; }
                      }
                      else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("WARM AIR UNIT") ? 1 : 0))
                      {
                        dataTable1.Rows.Add(table.Select("Code='SV4'")[0].ItemArray);
                        checked { ++num2; }
                      }
                      else
                      {
                        int num6;
                        if ((flag2 ? 1 : 0) != (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("AIR SOURCE") ? 1 : 0))
                          num6 = (flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("GROUND SOURCE") ? 1 : 0) ? 1 : 0;
                        else
                          num6 = 1;
                        if (num6 != 0)
                        {
                          dataTable1.Rows.Add(table.Select("Code='SVASHP'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("LARGE UNIT HEATER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV10A'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("UNIT HEATER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV10'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("GAS FIRE") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV6'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("WATER HEATER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV7'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("UNVENTED CYLINDER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SERV UNVENT'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("RANGE COOKER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV8'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("COOKER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV8'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("HOB") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV9'")[0].ItemArray);
                          checked { ++num2; }
                        }
                      }
                    }
                  }
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
label_116:;
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
          try
          {
            enumerator4 = this.DGVAdditional.GetEnumerator();
            while (enumerator4.MoveNext())
            {
              DataRowView current = (DataRowView) enumerator4.Current;
              if (num2 > 0)
              {
                dataTable1.Rows.Add(table.Select("Code='SERVADD'")[0].ItemArray);
              }
              else
              {
                try
                {
                  bool flag2 = true;
                  int num3;
                  if ((flag2 ? 1 : 0) != (current["Product"].ToString().ToUpper().ToUpper().Split('-')[0].Contains("SOLID") ? 1 : 0))
                  {
                    if ((flag2 ? 1 : 0) != (current["Product"].ToString().ToUpper().Split('-')[0].Contains("WOOD") ? 1 : 0))
                    {
                      num3 = (flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("OPEN FIRE") ? 1 : 0) ? 1 : 0;
                      goto label_128;
                    }
                  }
                  num3 = 1;
label_128:
                  if (num3 != 0)
                  {
                    dataTable1.Rows.Add(table.Select("Code='EA7001^'")[0].ItemArray);
                    checked { ++num2; }
                  }
                  else
                  {
                    int num4;
                    if ((flag2 ? 1 : 0) != (current["Product"].ToString().ToUpper().Split('-')[0].Contains("COMMERCIAL") ? 1 : 0))
                      num4 = (flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("CONVECTOR HEATER") ? 1 : 0) ? 1 : 0;
                    else
                      num4 = 1;
                    if (num4 != 0)
                    {
                      dataTable1.Rows.Add(table.Select("Code='C1'")[0].ItemArray);
                      checked { ++num2; }
                    }
                    else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("STORE") ? 1 : 0))
                    {
                      dataTable1.Rows.Add(table.Select("Code='SV5'")[0].ItemArray);
                      checked { ++num2; }
                    }
                    else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("OIL BOILER") ? 1 : 0))
                    {
                      dataTable1.Rows.Add(table.Select("Code='SVOB'")[0].ItemArray);
                      checked { ++num2; }
                    }
                    else
                    {
                      int num5;
                      if ((flag2 ? 1 : 0) != (current["Product"].ToString().ToUpper().Split('-')[0].Contains("BOILER") ? 1 : 0))
                      {
                        if ((flag2 ? 1 : 0) != (current["Product"].ToString().ToUpper().Split('-')[0].Contains("COND BOILER") ? 1 : 0))
                        {
                          if ((flag2 ? 1 : 0) != (current["Product"].ToString().ToUpper().Split('-')[0].Contains("COND COMBI") ? 1 : 0))
                          {
                            if ((flag2 ? 1 : 0) != (current["Product"].ToString().ToUpper().Split('-')[0].Contains("BACK BOILER") ? 1 : 0))
                            {
                              if ((flag2 ? 1 : 0) != (current["Product"].ToString().ToUpper().Split('-')[0].Contains("STD EFF BOILER") ? 1 : 0))
                              {
                                num5 = (flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("STD EFF COMBI") ? 1 : 0) ? 1 : 0;
                                goto label_146;
                              }
                            }
                          }
                        }
                      }
                      num5 = 1;
label_146:
                      if (num5 != 0)
                      {
                        dataTable1.Rows.Add(table.Select("Code='SV1'")[0].ItemArray);
                        checked { ++num2; }
                      }
                      else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("WARM AIR UNIT") ? 1 : 0))
                      {
                        dataTable1.Rows.Add(table.Select("Code='SV4'")[0].ItemArray);
                        checked { ++num2; }
                      }
                      else
                      {
                        int num6;
                        if ((flag2 ? 1 : 0) != (current["Product"].ToString().ToUpper().Split('-')[0].Contains("AIR SOURCE") ? 1 : 0))
                          num6 = (flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("GROUND SOURCE") ? 1 : 0) ? 1 : 0;
                        else
                          num6 = 1;
                        if (num6 != 0)
                        {
                          dataTable1.Rows.Add(table.Select("Code='SVASHP'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("LARGE UNIT HEATER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV10A'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("UNIT HEATER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV10'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("GAS FIRE") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV6'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("WATER HEATER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV7'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("UNVENTED CYLINDER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SERV UNVENT'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("RANGE COOKER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV8'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("COOKER") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV8'")[0].ItemArray);
                          checked { ++num2; }
                        }
                        else if ((flag2 ? 1 : 0) == (current["Product"].ToString().ToUpper().Split('-')[0].Contains("HOB") ? 1 : 0))
                        {
                          dataTable1.Rows.Add(table.Select("Code='SV9'")[0].ItemArray);
                          checked { ++num2; }
                        }
                      }
                    }
                  }
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  ProjectData.ClearProjectError();
                }
              }
            }
          }
          finally
          {
            if (enumerator4 is IDisposable)
              (enumerator4 as IDisposable).Dispose();
          }
        }
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) == 0)
      {
        try
        {
          dataTable1.Rows.Add(table.Select("Code='CBK'")[0].ItemArray);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        if (this.CurrentCustomer.CustomerTypeID == 517)
        {
          try
          {
            dataTable1.Rows.Add(table.Select("Code='INSBRK'")[0].ItemArray);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
        }
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SOR", false) == 0)
      {
        try
        {
          enumerator5 = ((IEnumerable) this.DGSOR.Rows).GetEnumerator();
          while (enumerator5.MoveNext())
          {
            DataGridViewRow current = (DataGridViewRow) enumerator5.Current;
            try
            {
              dataTable1.Rows.Add(table.Select("Code='" + current.Cells["code"].Value.ToString() + "'")[0].ItemArray);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              ProjectData.ClearProjectError();
            }
          }
        }
        finally
        {
          if (enumerator5 is IDisposable)
            (enumerator5 as IDisposable).Dispose();
        }
      }
      if (dataTable1.Rows.Count < 1)
        dataTable1.Rows.Add(table.Select("Code='DEFAULTS' AND Description = 'Normal Labour'")[0].ItemArray);
      DataRow[] dataRowArray1 = dataTable1.Select("1=1");
      int index1 = 0;
      while (index1 < dataRowArray1.Length)
      {
        DataRow dataRow = dataRowArray1[index1];
        DataTable dataTable2 = App.DB.CustomerScheduleOfRate.Exists(Conversions.ToInteger(dataRow["ScheduleOfRatesCategoryID"]), Conversions.ToString(dataRow["Description"]), Conversions.ToString(dataRow["Code"]), this.CurrentSite.CustomerID);
        int num3 = 0;
        if (dataTable2.Rows.Count > 0)
          num3 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0][0]));
        if (num3 <= 0)
        {
          CustomerScheduleOfRate oCustomerScheduleOfRate = new CustomerScheduleOfRate()
          {
            SetCode = RuntimeHelpers.GetObjectValue(dataRow["Code"]),
            SetDescription = RuntimeHelpers.GetObjectValue(dataRow["Description"]),
            SetPrice = RuntimeHelpers.GetObjectValue(dataRow["Price"]),
            SetScheduleOfRatesCategoryID = RuntimeHelpers.GetObjectValue(dataRow["ScheduleOfRatesCategoryID"]),
            SetTimeInMins = RuntimeHelpers.GetObjectValue(dataRow["TimeInMins"]),
            SetCustomerID = (object) this.CurrentSite.CustomerID
          };
          num3 = App.DB.CustomerScheduleOfRate.Insert(oCustomerScheduleOfRate).CustomerScheduleOfRateID;
        }
        double num4 = 1.0;
        if (this.TimeReqOption)
        {
          double num5 = !Versioned.IsNumeric((object) this.txtDays.Text) || Conversions.ToInteger(this.txtDays.Text) <= 0 ? 0.0 : (double) checked (Conversions.ToInteger(this.txtDays.Text) * 8);
          if (Versioned.IsNumeric((object) this.txtHrs.Text) && Conversions.ToInteger(this.txtHrs.Text) > 0)
            num5 += Conversions.ToDouble(this.txtHrs.Text);
          if (num5 == 0.0)
            num4 = 1.0;
        }
        JobItem oJobItem = new JobItem();
        oJobItem.IgnoreExceptionsOnSetMethods = true;
        oJobItem.SetSummary = RuntimeHelpers.GetObjectValue(dataRow["Description"]);
        oJobItem.SetQty = (object) 1;
        oJobItem.SetRateID = (object) num3;
        oJobItem.SetSystemLinkID = (object) 95;
        if (flag1)
        {
          jobOfWork.JobItems.Add((object) oJobItem);
        }
        else
        {
          oJobItem.SetJobOfWorkID = (object) jobOfWork.JobOfWorkID;
          App.DB.JobItems.Insert(oJobItem);
        }
        checked { ++index1; }
      }
      int num7 = 0;
      EngineerVisit oEngineerVisit;
      if (flag1)
      {
        oEngineerVisit = new EngineerVisit();
        if (this.costCentre != null)
          oEngineerVisit.SetExpectedDepartment = (object) this.costCentre;
      }
      else
        oEngineerVisit = this.currentVisit;
      if (DateTime.Compare(Datein, DateTime.MinValue.AddDays(2.0)) > 0)
      {
        string str1 = Period;
        // ISSUE: reference to a compiler-generated method
        switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(str1))
        {
          case 534056211:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "AM", false) == 0)
            {
              Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 08:00:01");
              num7 = 69943;
              break;
            }
            break;
          case 603976806:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "PM", false) == 0)
            {
              Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 12:00:01");
              num7 = 69944;
              break;
            }
            break;
          case 864471853:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "8AM", false) == 0)
            {
              Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 08:00:00");
              num7 = 69938;
              break;
            }
            break;
          case 1771548003:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "12-4", false) == 0)
            {
              Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 12:00:01");
              num7 = 69941;
              break;
            }
            break;
          case 2658973563:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "10-2", false) == 0)
            {
              Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 10:00:01");
              num7 = 69940;
              break;
            }
            break;
          case 2925960045:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "ANY", false) == 0)
            {
              Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 12:00:00");
              num7 = 69945;
              break;
            }
            break;
          case 3155601658:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "2-6", false) == 0)
            {
              Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 14:00:01");
              num7 = 69942;
              break;
            }
            break;
          case 3338149021:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "8-12", false) == 0)
            {
              Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 08:00:01");
              num7 = 69939;
              break;
            }
            break;
        }
        string str2 = Conversions.ToString(Datein).Replace("/", "-");
        DataTable theGap = App.DB.EngineerVisits.Find_The_Gap(Strings.Format((object) Datein, "yyyy-MM-dd"), EngineerID, Period);
        if (!(theGap.Rows.Count == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Period, "8AM", false) == 0))
          str2 = Conversions.ToString(theGap.Rows[0]["EndDateTime"]);
        if (this.TimeReqOption)
        {
          num1 = !Versioned.IsNumeric((object) this.txtDays.Text) || Conversions.ToInteger(this.txtDays.Text) <= 0 ? 0.0 : (double) checked (Conversions.ToInteger(this.txtDays.Text) * 24 * 60);
          if (Versioned.IsNumeric((object) this.txtHrs.Text) && Conversions.ToInteger(this.txtHrs.Text) > 0)
            num1 += Conversions.ToDouble(this.txtHrs.Text) * 60.0;
          if (num1 == 0.0)
            num1 = 60.0;
        }
        string str3 = Conversions.ToString(Conversions.ToDate(str2).AddMinutes(num1));
        string str4 = Strings.Format((object) Conversions.ToDate(str2), "yyyy-MM-dd HH:mm:ss");
        string str5 = Strings.Format((object) Conversions.ToDate(str3), "yyyy-MM-dd HH:mm:ss");
        oEngineerVisit.StartDateTime = Conversions.ToDate(str4);
        oEngineerVisit.EndDateTime = Conversions.ToDate(str5);
        oEngineerVisit.SetAppointmentID = (object) num7;
        oEngineerVisit.SetStatusEnumID = (object) "5";
      }
      else
        oEngineerVisit.SetStatusEnumID = (object) "4";
      oEngineerVisit.SetJobOfWorkID = (object) jobOfWork.JobOfWorkID;
      string str6 = visit != 1 ? this.visitterm2 : this.visitterm1;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Period, "Anytime", false) == 0)
        Period = "ANY";
      oEngineerVisit.SetNotesToEngineer = (object) ("(" + Period + ")");
      try
      {
        foreach (string skills in this.SkillsList)
          oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " *" + skills + "*");
      }
      finally
      {
        List<string>.Enumerator enumerator1;
        enumerator1.Dispose();
      }
      if (this.CurrentSite.CommercialDistrict)
        oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " DISTRICT");
      if (additionalNotes.Length > 0)
        oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " - " + additionalNotes + " -");
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) == 0 | visit == 2)
      {
        oEngineerVisit.SetNotesToEngineer = !this.chkCert.Checked ? (object) (oEngineerVisit.NotesToEngineer + " Service Visit - ") : (object) (oEngineerVisit.NotesToEngineer + " Service & Cert Visit - ");
        IEnumerator enumerator1;
        try
        {
          enumerator1 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataGridViewRow current = (DataGridViewRow) enumerator1.Current;
            oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + current.Cells["Product"].Value.ToString().Split('-')[0] + " - " + current.Cells["Product"].Value.ToString().Split('-')[1] + ", ");
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " " + this.txtAdditional.Text + " - " + str6);
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) == 0)
      {
        oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " Breakdown Visit - ");
        IEnumerator enumerator1;
        try
        {
          enumerator1 = ((IEnumerable) this.DGSymptoms.Rows).GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataGridViewRow current = (DataGridViewRow) enumerator1.Current;
            if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current.Cells["Code"].Value, (object) "OTHER", false))
              oEngineerVisit.SetNotesToEngineer = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) oEngineerVisit.NotesToEngineer, current.Cells["Description"].Value), (object) ", ");
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " " + this.txtAdditional.Text + " - " + str6);
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SOR", false) == 0)
      {
        oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " Complete SOR based Works  - See SOR List");
        oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " " + this.txtAdditional.Text + " - " + str6);
      }
      else
      {
        oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " Complete " + this.jobtype + " based Works - ");
        oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " " + this.txtAdditional.Text + " - " + str6);
      }
      if (visit == 1)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.visitterm1, "POC", false) == 0)
          oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " £" + Conversions.ToString(this.visitcharge1) + " inc VAT");
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.visitterm2, "POC", false) == 0)
        oEngineerVisit.SetNotesToEngineer = (object) (oEngineerVisit.NotesToEngineer + " £" + Conversions.ToString(this.visitcharge2) + " inc VAT");
      oEngineerVisit.SetPartsToFit = (object) false;
      oEngineerVisit.SetEngineerID = (object) EngineerID;
      JobAudit oJobAudit = new JobAudit();
      Job job;
      string str7;
      if (!oJob.Exists)
      {
        jobOfWork.EngineerVisits.Add((object) oEngineerVisit);
        oJob.JobOfWorks.Add((object) jobOfWork);
        job = App.DB.Job.Insert(oJob);
        str7 = "New Visit Inserted through the Wizard (By User " + App.loggedInUser.Fullname + ") - Status: NOT SET (Unique Visit ID: " + Conversions.ToString(oEngineerVisit.EngineerVisitID) + ")";
      }
      else
      {
        job = App.DB.Job.Update(oJob, new ArrayList(), new ArrayList(), new ArrayList());
        App.DB.JobOfWorks.Update_PONumber(jobOfWork);
        App.DB.JobOfWorks.Update_Priority(jobOfWork);
        App.DB.EngineerVisits.Update(oEngineerVisit, this.CurrentJob.JobID, true);
        str7 = "Visit Updated through the Wizard (By User " + App.loggedInUser.Fullname + ") - Status: NOT SET (Unique Visit ID: " + Conversions.ToString(oEngineerVisit.EngineerVisitID) + ")";
      }
      this.jobids = job.JobID;
      App.DB.EngineerVisits.DeleteExtendedProperties(oEngineerVisit.EngineerVisitID);
      App.DB.EngineerVisits.DeleteSymptoms(oEngineerVisit.EngineerVisitID);
      IEnumerator enumerator6;
      try
      {
        enumerator6 = ((IEnumerable) this.DGSymptoms.Rows).GetEnumerator();
        while (enumerator6.MoveNext())
        {
          DataGridViewRow current = (DataGridViewRow) enumerator6.Current;
          App.DB.EngineerVisits.InsertSymptom(oEngineerVisit.EngineerVisitID, Conversions.ToInteger(current.Cells["SypID"].Value));
        }
      }
      finally
      {
        if (enumerator6 is IDisposable)
          (enumerator6 as IDisposable).Dispose();
      }
      if (this.txtAdditional.Text.ToString().Length > 0)
        App.DB.EngineerVisits.InsertAdditionalText(oEngineerVisit.EngineerVisitID, this.txtAdditional.Text.ToString());
      oJobAudit.SetJobID = (object) job.JobID;
      oJobAudit.SetActionChange = (object) str7;
      App.DB.JobAudit.Insert(oJobAudit);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.BookingDetail, "", false) == 0)
      {
        this.BookingDetail = "Job saved as ready for schedule Job Number - " + job.JobNumber;
        DataRow[] dataRowArray2 = this.DTPrivNotes.Select("JobNoteID = 0");
        int index2 = 0;
        while (index2 < dataRowArray2.Length)
        {
          DataRow dataRow = dataRowArray2[index2];
          App.DB.Job.SaveJobNotes(0, Conversions.ToString(dataRow["Note"]), Conversions.ToInteger(dataRow["EditedByUserID"]), job.JobID, Conversions.ToInteger(dataRow["CreatedByUserID"])).ToTable();
          checked { ++index2; }
        }
        this.DTPrivNotes = App.DB.Job.GetAllJobNotes(this.CurrentSite.SiteID);
        try
        {
          this.tcSites.TabPages[0].Enabled = true;
          this.tcSites.TabPages.Remove(this.tabProp);
          this.tcSites.TabPages.Remove(this.tabExistingJobs);
          this.tcSites.TabPages.Remove(this.tabJobType);
          this.tcSites.TabPages.Remove(this.tabJobDetails);
          this.tcSites.TabPages.Remove(this.tabAppliance);
          this.tcSites.TabPages.Remove(this.TabCharging);
          this.tcSites.TabPages.Remove(this.tabAdditional);
          this.tcSites.TabPages.Remove(this.TabBook);
          this.tcSites.TabPages.Insert(this.tcSites.TabCount, this.tcComplete);
          this.tab = checked (this.tcSites.SelectedIndex + 1);
          checked { ++this.tcSites.SelectedIndex; }
          this.tcSites.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.tcSites.TabPages.Insert(this.tcSites.TabCount, this.tcComplete);
          this.tab = checked (this.tcSites.SelectedIndex + 1);
          checked { ++this.tcSites.SelectedIndex; }
          this.tcSites.SelectedIndex = 0;
          ProjectData.ClearProjectError();
        }
        return job;
      }
      if (((visit == 2 ? 1 : 0) | (this.DGVAdditional == null ? 0 : (this.DGVAdditional.Count == 0 ? 1 : 0))) != 0)
      {
        if (this.BookingDetail.Contains("Job saved as ready for schedule Job"))
        {
          // ISSUE: variable of a reference type
          string& local;
          // ISSUE: explicit reference operation
          string str1 = ^(local = ref this.BookingDetail) + " & " + job.JobNumber;
          local = str1;
        }
        else
        {
          DataTable dataTable2 = new DataTable();
          DataTable dtPrivNotes = this.DTPrivNotes;
          DataRow row = dtPrivNotes.NewRow();
          row[0] = (object) 0;
          row[1] = (object) App.loggedInUser.UserID;
          row[2] = (object) App.loggedInUser.UserID;
          row[3] = (object) ("Visit booked with " + App.DB.Engineer.Engineer_Get(EngineerID).Name + " Scheduled " + Datein.ToString("dd/MM/yyyy") + " " + Period);
          row[4] = (object) DateTime.Now;
          row[5] = (object) App.loggedInUser.Username;
          row[6] = (object) DateTime.Now;
          row[7] = (object) App.loggedInUser.Username;
          row[8] = (object) 0;
          row[9] = (object) "New..";
          row[10] = (object) 0;
          dtPrivNotes.Rows.InsertAt(row, 0);
          this.DTPrivNotes = dtPrivNotes;
          DataRow[] dataRowArray2 = this.DTPrivNotes.Select("JobNoteID = 0");
          int index2 = 0;
          while (index2 < dataRowArray2.Length)
          {
            DataRow dataRow = dataRowArray2[index2];
            App.DB.Job.SaveJobNotes(0, Conversions.ToString(dataRow["Note"]), Conversions.ToInteger(dataRow["EditedByUserID"]), job.JobID, Conversions.ToInteger(dataRow["CreatedByUserID"])).ToTable();
            checked { ++index2; }
          }
          this.DTPrivNotes = App.DB.Job.GetAllJobNotes(this.CurrentSite.SiteID);
          try
          {
            this.tcSites.TabPages[0].Enabled = true;
            this.tcSites.TabPages.Remove(this.tabProp);
            this.tcSites.TabPages.Remove(this.tabExistingJobs);
            this.tcSites.TabPages.Remove(this.tabJobType);
            this.tcSites.TabPages.Remove(this.tabJobDetails);
            this.tcSites.TabPages.Remove(this.tabAppliance);
            this.tcSites.TabPages.Remove(this.TabCharging);
            this.tcSites.TabPages.Remove(this.tabAdditional);
            this.tcSites.TabPages.Remove(this.TabBook);
            this.tcSites.SelectedIndex = 1;
            this.tcSites.TabPages.Insert(this.tcSites.TabCount, this.tcComplete);
            this.tab = checked (this.tcSites.SelectedIndex + 1);
            checked { ++this.tcSites.SelectedIndex; }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            this.tcSites.TabPages.Insert(this.tcSites.TabCount, this.tcComplete);
            this.tab = checked (this.tcSites.SelectedIndex + 1);
            checked { ++this.tcSites.SelectedIndex; }
            this.tcSites.SelectedIndex = 0;
            ProjectData.ClearProjectError();
          }
        }
      }
      return job;
    }

    private bool CheckMainApps(string Wordin, bool secondry = false)
    {
      bool flag = true;
      if (flag == Wordin.ToUpper().Contains("SOLID") || flag == Wordin.ToUpper().Contains("WOOD") || flag == Wordin.ToUpper().Contains("OPEN FIRE"))
      {
        this.HETASNEEDED = true;
        this.servTime = 90;
      }
      else if (flag == Wordin.ToUpper().Contains("COMMERCIAL") || flag == Wordin.ToUpper().Contains("CONVECTOR HEATER"))
      {
        this.COMMNEEDED = true;
        this.servTime = 90;
      }
      else
      {
        if (flag == Wordin.ToUpper().Contains("STORE"))
        {
          this.servTime = 45;
          return true;
        }
        if (flag == Wordin.ToUpper().Contains("OIL BOILER"))
        {
          this.servTime = 60;
          this.OILNEEDED = true;
          return true;
        }
        if (flag == Wordin.ToUpper().Contains("BOILER") || flag == Wordin.ToUpper().Contains("COND BOILER") || (flag == Wordin.ToUpper().Contains("COND COMBI") || flag == Wordin.ToUpper().Contains("BACK BOILER")) || flag == Wordin.ToUpper().Contains("STD EFF BOILER") || flag == Wordin.ToUpper().Contains("STD EFF COMBI"))
        {
          this.servTime = 45;
          this.NATNEEDED = true;
          return true;
        }
        if (flag == Wordin.ToUpper().Contains("WARM AIR UNIT"))
        {
          this.NATNEEDED = true;
          this.WAUNEEDED = true;
          this.servTime = 75;
          return true;
        }
        if (flag == Wordin.ToUpper().Contains("AIR SOURCE") || flag == Wordin.ToUpper().Contains("GROUND SOURCE"))
        {
          this.ASNEEDED = true;
          this.servTime = 35;
          return true;
        }
        if (flag == Wordin.ToUpper().Contains("LARGE UNIT HEATER"))
        {
          this.NATNEEDED = true;
          this.servTime = 60;
        }
        else if (flag == Wordin.ToUpper().Contains("UNIT HEATER"))
        {
          this.NATNEEDED = true;
          this.servTime = 30;
        }
        else if (flag == Wordin.ToUpper().Contains("GAS FIRE"))
        {
          this.NATNEEDED = true;
          this.servTime = 45;
        }
        else if (flag == Wordin.ToUpper().Contains("WATER HEATER"))
        {
          this.NATNEEDED = true;
          this.servTime = 60;
        }
        else if (flag == Wordin.ToUpper().Contains("UNVENTED CYLINDER"))
          this.servTime = 15;
        else if (flag == Wordin.ToUpper().Contains("RANGE COOKER"))
        {
          this.NATNEEDED = true;
          this.servTime = 90;
        }
        else if (flag == Wordin.ToUpper().Contains("COOKER"))
        {
          this.NATNEEDED = true;
          this.servTime = 55;
        }
        else if (flag == Wordin.ToUpper().Contains("HOB"))
        {
          this.NATNEEDED = true;
          this.servTime = 30;
        }
      }
      return false;
    }

    private string Pricing(string wordin)
    {
      bool flag = true;
      string str;
      if (flag == wordin.ToUpper().Contains("STORE"))
        str = App.DB.Picklists.Get_Single_Description("STOREBLR", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("OIL BOILER"))
        str = App.DB.Picklists.Get_Single_Description("OILBLR", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("BOILER") || flag == wordin.ToUpper().Contains("COND BOILER") || (flag == wordin.ToUpper().Contains("COND COMBI") || flag == wordin.ToUpper().Contains("BACK BOILER")) || flag == wordin.ToUpper().Contains("STD EFF BOILER") || flag == wordin.ToUpper().Contains("STD EFF COMBI"))
        str = App.DB.Picklists.Get_Single_Description("BOILER", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("WARM AIR UNIT"))
        str = App.DB.Picklists.Get_Single_Description("WARMAIR", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("AIR SOURCE"))
        str = App.DB.Picklists.Get_Single_Description("AIRANDSOL", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("LARGE UNIT HEATER"))
        str = App.DB.Picklists.Get_Single_Description("LRGUNIT", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("UNIT HEATER"))
        str = App.DB.Picklists.Get_Single_Description("UNITHTR", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("GAS FIRE"))
        str = App.DB.Picklists.Get_Single_Description("GASFIRE", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("WATER HEATER"))
        str = App.DB.Picklists.Get_Single_Description("WATERHTR", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("UNVENTED CYLINDER"))
        str = this.DgMain.RowCount != 1 ? App.DB.Picklists.Get_Single_Description("UNVENTPLUS", Enums.PickListTypes.PriceList) : App.DB.Picklists.Get_Single_Description("UNVENT", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("RANGE COOKER"))
        str = App.DB.Picklists.Get_Single_Description("RNGCKR", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("COOKER"))
        str = App.DB.Picklists.Get_Single_Description("CKR", Enums.PickListTypes.PriceList);
      else if (flag == wordin.ToUpper().Contains("HOB"))
        str = App.DB.Picklists.Get_Single_Description("HOB", Enums.PickListTypes.PriceList);
      return str;
    }

    private void FindAppointments(bool SecondVisit = false)
    {
      Button[] buttonArray1 = new Button[9]
      {
        this.btnOption1,
        this.btnOption2,
        this.btnOption3,
        this.btnOption4,
        this.btnOption5,
        this.btnOption6,
        this.btnOption7,
        this.btnOption8,
        this.btnOption10
      };
      int index1 = 0;
      while (index1 < buttonArray1.Length)
      {
        buttonArray1[index1].Visible = false;
        checked { ++index1; }
      }
      Application.DoEvents();
      this.Cursor = Cursors.WaitCursor;
      Application.DoEvents();
      if (this.secTime == 0)
        this.chkKeepTogether.Visible = false;
      else
        this.chkKeepTogether.Visible = true;
      if (this.chkKeepTogether.Checked)
      {
        this.reqtime = checked (this.priTime + this.secTime);
        this.lblBookText.Text = "Booking All Visits";
      }
      else if (!SecondVisit)
      {
        this.reqtime = this.priTime;
        if (this.jobtype.ToUpper().Contains("SERVICE"))
        {
          this.dtpFromDate.Value = DateAndTime.Now.AddDays(14.0);
          this.lblBookText.Text = "Booking Service Visit";
        }
        else
        {
          this.dtpFromDate.Value = DateAndTime.Now;
          this.lblBookText.Text = "Booking " + this.jobtype + " Visit";
        }
      }
      else
      {
        this.reqtime = this.secTime;
        this.dtpFromDate.Value = DateAndTime.Now.AddDays(14.0);
        if (this.jobtype.ToUpper().Contains("SERVICE"))
        {
          this.dtpFromDate.Value = DateAndTime.Now.AddDays(14.0);
          this.lblBookText.Text = "Booking Service Visit";
        }
        else
        {
          this.dtpFromDate.Value = DateAndTime.Now;
          this.lblBookText.Text = "Booking " + this.jobtype + " Visit";
        }
      }
      bool flag1 = false;
      if (this.Temp.Rows.Count == 0 | DateTime.Compare(this.currentFilterDate, DateTime.MinValue) > 0 & DateTime.Compare(this.dtpFromDate.Value.AddDays(-7.0), this.currentFilterDate) > 0 | DateTime.Compare(this.dtpFromDate.Value, this.currentFilterDate) < 0)
      {
        flag1 = true;
        this.currentFilterDate = this.dtpFromDate.Value;
        if (!this.CurrentCustomer.SuperBook)
        {
          this.Temp = App.DB.EngineerVisits.Get_Appointments_Multi(this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm"), this.priTime, 14, 240);
        }
        else
        {
          this.Temp = App.DB.EngineerVisits.Get_Appointments_Multi(this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm"), this.priTime, 1, 240);
          this.Temp.Clear();
        }
        this.Temp.Columns.Add("AssignedArea");
      }
      IList<int> intList1 = (IList<int>) new List<int>();
      int num1 = 0;
      DataRow[] dataRowArray1 = App.DB.Customer.Requirements_Get_For_CustomerID(this.CurrentCustomer.CustomerID).Table.Select("tick = 1");
      int index2 = 0;
      while (index2 < dataRowArray1.Length)
      {
        DataRow dataRow = dataRowArray1[index2];
        intList1.Add(Conversions.ToInteger(dataRow["ManagerID"]));
        checked { ++num1; }
        checked { ++index2; }
      }
      DataTable listForJobType = App.DB.EngineerLevel.Get_List_For_JobType(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cbotypeWiz)));
      IEnumerator enumerator1;
      try
      {
        enumerator1 = listForJobType.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          intList1.Add(Conversions.ToInteger(current["SkillID"]));
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (num1 == 0 & listForJobType.Rows.Count == 0)
        intList1.Add(69697);
      DataView allForSite = App.DB.Sites.SiteFuel_GetAll_ForSite(this.CurrentSite.SiteID);
      if (this.jobtype.ToUpper().Contains("BREAKDOWN") & -(this.CurrentSite.CommercialDistrict ? 1 : 0) == 1)
        this.COMMNEEDED = true;
      this.LPGNEEDED = false;
      Asset asset = new Asset();
      IEnumerator enumerator2;
      try
      {
        enumerator2 = ((IEnumerable) this.DgMain.Rows).GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataGridViewRow current = (DataGridViewRow) enumerator2.Current;
          IEnumerator enumerator3;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current.Cells["ASSETID"].Value, (object) 20, false))
          {
            asset = App.DB.Asset.Asset_Get(Conversions.ToInteger(current.Cells["ASSETID"].Value));
          }
          else
          {
            try
            {
              enumerator3 = allForSite.Table.Rows.GetEnumerator();
              while (enumerator3.MoveNext())
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((DataRow) enumerator3.Current)["FuelID"], (object) 378, false))
                  this.LPGNEEDED = true;
              }
            }
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
          }
          if (asset.GasTypeID == 378)
            this.LPGNEEDED = true;
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      this.SkillsList.Clear();
      if (this.NATNEEDED)
      {
        intList1.Add(68820);
        this.SkillsList.Add("NAT GAS");
      }
      if (this.LPGNEEDED)
      {
        intList1.Add(68857);
        this.SkillsList.Add("LPG");
      }
      if (this.COMMNEEDED)
      {
        intList1.Add(68846);
        this.SkillsList.Add("COMMERCIAL");
      }
      if (this.WAUNEEDED)
      {
        intList1.Add(68836);
        this.SkillsList.Add("WAU");
      }
      if (this.OILNEEDED)
      {
        intList1.Add(68863);
        this.SkillsList.Add("OIL");
      }
      if (this.ASNEEDED)
      {
        intList1.Add(69743);
        this.SkillsList.Add("ASHP");
      }
      if (this.HETASNEEDED)
      {
        intList1.Add(68877);
        this.SkillsList.Add("HEATAS");
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.SpecialTrade, "ELEC", false) == 0)
      {
        intList1.Add(68868);
        this.SkillsList.Add("ELEC");
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.SpecialTrade, "PLUM", false) != 0)
        ;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.SpecialTrade, "BANDM", false) != 0)
        ;
      if (flag1)
      {
        IEnumerator enumerator3;
        try
        {
          enumerator3 = this.Temp.Rows.GetEnumerator();
          while (enumerator3.MoveNext())
            ((DataRow) enumerator3.Current)["AssignedArea"] = (object) 1;
        }
        finally
        {
          if (enumerator3 is IDisposable)
            (enumerator3 as IDisposable).Dispose();
        }
        this.Temp = this.AppointmentStrip(ref this.Temp, (List<int>) intList1, false);
      }
      this.appointments.Clear();
      this.appointments = this.Temp.Clone();
      this.appointments.Columns["EIGHT_TWELVE"].DataType = System.Type.GetType("System.Double");
      this.appointments.Columns["TEN_TWO"].DataType = System.Type.GetType("System.Double");
      this.appointments.Columns["TWELVE_FOUR"].DataType = System.Type.GetType("System.Double");
      this.appointments.Columns["TWO_SIX"].DataType = System.Type.GetType("System.Double");
      this.appointments.Columns.Add("SCORE");
      this.appointments.Columns["SCORE"].DataType = System.Type.GetType("System.Int32");
      IEnumerator enumerator4;
      try
      {
        enumerator4 = this.Temp.Rows.GetEnumerator();
        while (enumerator4.MoveNext())
          this.appointments.ImportRow((DataRow) enumerator4.Current);
      }
      finally
      {
        if (enumerator4 is IDisposable)
          (enumerator4 as IDisposable).Dispose();
      }
      DataView dataView1 = new DataView();
      this.appointments.TableName = "Appointments";
      dataView1.Table = this.appointments;
      DateTime dateTime1 = Conversions.ToDate(this.workingdays(DateTime.Now.ToString(), 2));
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) != 0)
        dateTime1 = Conversions.ToDate(this.workingdays(DateTime.Now.ToString(), 200));
      DataTable table = App.DB.Customer.Priorities_Get_For_CustomerID_Active(this.CurrentCustomer.CustomerID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPriority))).Table;
      DateTime dateTime2;
      if (table.Rows.Count == 1)
      {
        DataRow row = table.Rows[0];
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row["IncludeWeekends"], (object) true, false))
        {
          dateTime2 = DateTime.Now;
          dateTime1 = dateTime2.AddHours(Conversions.ToDouble(row["TargetHours"]));
        }
        else
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(row["TargetHours"], (object) 24, false))
          {
            dateTime2 = DateTime.Now;
            dateTime2.AddHours(Conversions.ToDouble(row["TargetHours"]));
          }
          double a = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(row["TargetHours"], (object) 24));
          if (a < 1.0)
          {
            dateTime2 = DateTime.Now;
            dateTime1 = Conversions.ToDate(this.workingdays(dateTime2.ToString(), 1));
          }
          else
          {
            dateTime2 = DateTime.Now;
            dateTime1 = Conversions.ToDate(this.workingdays(dateTime2.ToString(), checked ((int) Math.Round(a))));
          }
        }
      }
      List<int> intList2 = new List<int>();
      intList2.AddRange((IEnumerable<int>) new int[3]
      {
        67353,
        68032,
        68376
      });
      if (this.CurrentContract != null && intList2.Contains(this.CurrentContract.ContractTypeID))
      {
        dateTime2 = DateTime.Now;
        dateTime2 = dateTime2.AddHours(24.0);
        dateTime1 = Conversions.ToDate(dateTime2.ToString("yyyy-MM-dd") + " 18:00");
      }
      else if (this.CurrentContract != null)
      {
        dateTime2 = Conversions.ToDate(this.workingdays(Conversions.ToString(DateTime.Now), 1));
        dateTime1 = Conversions.ToDate(dateTime2.ToString("yyyy-MM-dd") + " 18:00");
      }
      dataView1.Table.Columns.Add("InTarget");
      IEnumerator enumerator5;
      try
      {
        enumerator5 = dataView1.Table.Rows.GetEnumerator();
        while (enumerator5.MoveNext())
        {
          DataRow current = (DataRow) enumerator5.Current;
          current["InTarget"] = DateTime.Compare(Conversions.ToDate(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["Date"], (object) " 12:00")), dateTime1) >= 0 ? (object) "0" : (object) "1";
        }
      }
      finally
      {
        if (enumerator5 is IDisposable)
          (enumerator5 as IDisposable).Dispose();
      }
      IList<int> intList3 = (IList<int>) new List<int>();
      int num2 = 0;
      DataRow[] dataRowArray2 = App.DB.Customer.Requirements_Get_For_CustomerID(this.CurrentCustomer.CustomerID).Table.Select("tick = 1");
      int index3 = 0;
      while (index3 < dataRowArray2.Length)
      {
        DataRow dataRow = dataRowArray2[index3];
        intList3.Add(Conversions.ToInteger(dataRow["ManagerID"]));
        checked { ++num2; }
        checked { ++index3; }
      }
      if (num2 == 0)
        intList3.Add(69697);
      this.Schedulerapps.Columns.Add("AssignedArea");
      this.Schedulerapps = App.DB.EngineerVisits.Get_Appointments_Scheduler(this.dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm"), this.reqtime);
      this.Schedulerapps = this.AppointmentStrip(ref this.Schedulerapps, (List<int>) intList3, true);
      DataView dataView2 = new DataView();
      this.Schedulerapps.TableName = "SchAppointments";
      dataView2.Table = this.Schedulerapps;
      dataView2.Table.Columns.Add("InTarget");
      IEnumerator enumerator6;
      try
      {
        enumerator6 = dataView2.Table.Rows.GetEnumerator();
        while (enumerator6.MoveNext())
        {
          DataRow current = (DataRow) enumerator6.Current;
          current["InTarget"] = DateTime.Compare(Conversions.ToDate(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["Date"], (object) " 12:00")), dateTime1) >= 0 ? (object) "0" : (object) "1";
        }
      }
      finally
      {
        if (enumerator6 is IDisposable)
          (enumerator6 as IDisposable).Dispose();
      }
      string str1 = "";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboEngineer)) > 0.0)
        str1 = " AND EngineerID = " + Combo.get_GetSelectedItemValue(this.cboEngineer);
      if (!SecondVisit)
      {
        string Left = Combo.get_GetSelectedItemValue(this.cboAppointment);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69938), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND EightAMAvail = 1 AND remainingAM >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69943), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND remainingAM >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69944), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND remainingPM >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69939), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [EIGHT_TWELVE] >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69940), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TEN_TWO] >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69941), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TWELVE_FOUR] >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69942), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TWO_SIX] >= " + Conversions.ToString(this.reqtime) + str1;
        else
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "#" + str1;
      }
      else
      {
        string Left = Combo.get_GetSelectedItemValue(this.cboAppointment);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69938), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND EightAMAvail = 1 AND remainingAM >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69943), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND remainingAM >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69944), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND remainingPM >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69939), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [EIGHT_TWELVE] >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69940), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TEN_TWO] >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69941), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TWELVE_FOUR] >= " + Conversions.ToString(this.reqtime) + str1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(69942), false) == 0)
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TWO_SIX] >= " + Conversions.ToString(this.reqtime) + str1;
        else
          dataView1.RowFilter = "Date>= #" + this.dtpFromDate.Value.ToString("yyyy-MM-dd") + "#" + str1;
      }
      dataView1.Table.Columns.Add("AMCLOSE");
      dataView1.Table.Columns.Add("PMCLOSE");
      dataView1.Table.Columns.Add("COMBCLOSE");
      dataView1.Table.Columns.Add("ORIGAMCLOSE");
      dataView1.Table.Columns.Add("ORIGPMCLOSE");
      IEnumerator enumerator7;
      try
      {
        enumerator7 = dataView1.Table.Rows.GetEnumerator();
        while (enumerator7.MoveNext())
        {
          DataRow current = (DataRow) enumerator7.Current;
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["AMLatitude"])) & !Information.IsDBNull((object) this.CurrentSite.Latitude) & Convert.ToDouble(this.CurrentSite.Latitude) != 0.0)
          {
            double num3 = this.distance(Conversions.ToDouble(current["AMLatitude"]), Conversions.ToDouble(current["AMLongitude"]), Convert.ToDouble(this.CurrentSite.Latitude), Convert.ToDouble(this.CurrentSite.Longitude), 'M');
            current["AMCLOSE"] = (object) num3;
            current["ORIGAMCLOSE"] = (object) Math.Round(num3, 2);
          }
          else
            current["AMCLOSE"] = (object) DBNull.Value;
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["PMLatitude"])) & !Information.IsDBNull((object) this.CurrentSite.Latitude) & Convert.ToDouble(this.CurrentSite.Latitude) != 0.0)
          {
            double num3 = this.distance(Conversions.ToDouble(current["PMLatitude"]), Conversions.ToDouble(current["PMLongitude"]), Convert.ToDouble(this.CurrentSite.Latitude), Convert.ToDouble(this.CurrentSite.Longitude), 'M');
            current["PMCLOSE"] = (object) num3;
            current["ORIGPMCLOSE"] = (object) Math.Round(num3, 2);
          }
          else
            current["PMCLOSE"] = (object) DBNull.Value;
          if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["ORIGPMCLOSE"])) || Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["ORIGPMCLOSE"], (object) "", false))
            current["ORIGPMCLOSE"] = (object) "Unknown";
          if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["ORIGAMCLOSE"])) || Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["ORIGAMCLOSE"], (object) "", false))
            current["ORIGAMCLOSE"] = (object) "Unknown";
          if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["AMCLOSE"])) & Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["PMCLOSE"])))
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["AssignedArea"], (object) 1, false))
            {
              current["AMCLOSE"] = (object) 9;
              current["PMCLOSE"] = (object) 9;
            }
            else
            {
              current["AMCLOSE"] = (object) 21;
              current["PMCLOSE"] = (object) 21;
            }
          }
          else if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["AMCLOSE"])))
            current["AMCLOSE"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(current["PMCLOSE"], (object) 8);
          else if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["PMCLOSE"])))
            current["PMCLOSE"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(current["AMCLOSE"], (object) 8);
          current["COMBCLOSE"] = (object) checked (Conversions.ToInteger(current["PMCLOSE"]) + Conversions.ToInteger(current["AMCLOSE"]));
        }
      }
      finally
      {
        if (enumerator7 is IDisposable)
          (enumerator7 as IDisposable).Dispose();
      }
      IEnumerator enumerator8;
      try
      {
        enumerator8 = dataView1.GetEnumerator();
        while (enumerator8.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator8.Current;
          int num3 = checked ((int) (DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(current["Date"]), this.dtpFromDate.Value, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) * 4L));
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["AssignedArea"], (object) 1, false))
            checked { num3 += 25; }
          int num4 = checked ((int) ((long) num3 + DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(current["Date"]), DateAndTime.Now.Date, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) * 2L));
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) == 0 | SecondVisit)
          {
            num4 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) checked (num4 + 30), Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["ServPri"], (object) -1)));
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["ServPri"], (object) 0, false))
              checked { num4 += -1000; }
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) == 0)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InTarget"], (object) 1, false))
              checked { num4 += 50; }
            num4 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) checked ((int) ((long) num4 + DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(current["Date"]), dateTime1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) * 2L)), Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["BreakPri"], (object) -1)));
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["BreakPri"], (object) 0, false))
              checked { num4 += -1000; }
          }
          int integer = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num4, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["COMBCLOSE"], (object) -1), (object) 2)));
          current["SCORE"] = (object) integer;
        }
      }
      finally
      {
        if (enumerator8 is IDisposable)
          (enumerator8 as IDisposable).Dispose();
      }
      int days = 0;
      this.txtHrs.Text = this.txtHrs.Text.Length == 0 ? "0" : this.txtHrs.Text;
      this.txtDays.Text = this.txtDays.Text.Length == 0 ? "0" : this.txtDays.Text;
      if (Conversions.ToDouble(this.txtDays.Text) > 0.0 && Conversions.ToDouble(this.txtHrs.Text) > 0.0)
        days = checked (Conversions.ToInteger(this.txtDays.Text) + 1);
      List<int> intList4 = new List<int>();
      DataTable dataTable = dataView1.Table.Copy();
      if (Conversions.ToInteger(this.txtHrs.Text) > 8 | Conversions.ToInteger(this.txtDays.Text) > 0)
      {
        IEnumerator enumerator3;
        try
        {
          enumerator3 = dataView1.Table.Rows.GetEnumerator();
          while (enumerator3.MoveNext())
          {
            DataRow current = (DataRow) enumerator3.Current;
            if (!intList4.Contains(Conversions.ToInteger(current["EngineerID"])))
              intList4.Add(Conversions.ToInteger(current["EngineerID"]));
          }
        }
        finally
        {
          if (enumerator3 is IDisposable)
            (enumerator3 as IDisposable).Dispose();
        }
        try
        {
          foreach (int EngineerID in intList4)
          {
            if (App.DB.EngineerVisits.Get_Appointments_ForEngineer(this.dtpFromDate.Value.ToString("yyyy-MM-dd"), 120, EngineerID, days, 240).Rows.Count != days)
            {
              DataRow[] dataRowArray3 = dataTable.Select("EngineerID = " + Conversions.ToString(EngineerID));
              int index4 = 0;
              while (index4 < dataRowArray3.Length)
              {
                DataRow row = dataRowArray3[index4];
                dataTable.Rows.Remove(row);
                checked { ++index4; }
              }
            }
          }
        }
        finally
        {
          List<int>.Enumerator enumerator9;
          enumerator9.Dispose();
        }
        dataView1.Table = dataTable;
      }
      dataView1.Sort = "Score DESC";
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) != 0)
        ;
      dataView2.Sort = "InTarget Desc, daynumber asc, TotalRemaining DESC, RemainingAM ASC,RemainingPM ASC";
      Button[] buttonArray2 = new Button[9]
      {
        this.btnOption1,
        this.btnOption2,
        this.btnOption3,
        this.btnOption4,
        this.btnOption5,
        this.btnOption6,
        this.btnOption7,
        this.btnOption8,
        this.btnOption10
      };
      int num5 = 0;
      int index5 = 0;
      int index6 = 0;
      DateTime dateTime3;
      while (index5 < dataView1.Count && index6 != 8)
      {
        string str2 = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataView1[index5]["AssignedArea"], (object) 1, false) ? "No" : "Yes";
        string str3 = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataView1[index5]["cbuoc"], (object) 1, false) ? "No" : "Yes";
        string str4 = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataView1[index5]["InTarget"], (object) 1, false) ? "No" : "Yes";
        object Left1 = Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataView1[index5]["EightAMAvail"], (object) "1", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["remainingAM"], (object) this.reqtime, false));
        dateTime3 = Conversions.ToDate(dataView1[index5]["Date"]);
        DateTime date1 = Conversions.ToDate(dateTime3.ToString("dd/MM/yyyy") + " 00:00");
        dateTime3 = DateTime.Today;
        DateTime date2 = Conversions.ToDate(dateTime3.ToString("dd/MM/yyyy") + " 08:00");
        // ISSUE: variable of a boxed type
        __Boxed<bool> local = (System.ValueType) (DateTime.Compare(date1, date2) > 0);
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Left1, (object) local)))
        {
          string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distance : ", dataView1[index5]["ORIGAMCLOSE"]), (object) "  Area Engineer : "), (object) str2), (object) "  On Call Engineer : "), (object) str3), (object) "  In Target : "), (object) str4));
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(dataView1[index5]["AMCLOSE"], (object) 22, false) && Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69938.0 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 0.0)
          {
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " 8AM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^8AM"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
            checked { ++num5; }
            if (index6 == 8)
              break;
          }
        }
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["remainingAM"], (object) this.reqtime, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["remainingPM"], (object) this.reqtime, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLess(dataView1[index5]["AMCLOSE"], (object) 22, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLess(dataView1[index5]["PMCLOSE"], (object) 22, false))))
        {
          dateTime3 = DateTime.Now;
          int num3 = dateTime3.Hour > 9 ? 1 : 0;
          dateTime3 = Conversions.ToDate(dataView1[index5]["Date"]);
          string Left2 = dateTime3.ToString("dd/MM/yyyy");
          dateTime3 = DateAndTime.Today;
          string Right = dateTime3.ToString("dd/MM/yyyy");
          int num4 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, Right, false) == 0 ? 1 : 0;
          if ((num3 & num4) == 0 && Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69943.0 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 0.0)
          {
            string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distance : ", dataView1[index5]["ORIGAMCLOSE"]), (object) "  Area Engineer : "), (object) str2), (object) "  On Call Engineer : "), (object) str3), (object) "  In Target : "), (object) str4));
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " AM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^AM"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
            checked { ++num5; }
            if (index6 == 8)
              break;
          }
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69944.0 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 0.0)
          {
            string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distance : ", dataView1[index5]["ORIGPMCLOSE"]), (object) "  Area Engineer : "), (object) str2), (object) "  On Call Engineer : "), (object) str3), (object) "  In Target : "), (object) str4));
            checked { ++num5; }
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " PM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^PM"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69945.0)
          {
            checked { ++num5; }
            string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distance : ", dataView1[index5]["ORIGPMCLOSE"]), (object) "  Area Engineer : "), (object) str2), (object) "  On Call Engineer : "), (object) str3), (object) "  In Target : "), (object) str4));
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " ANYTIME"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^ANY"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69939.0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["EIGHT_TWELVE"], (object) this.reqtime, false))))
          {
            string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distance : ", dataView1[index5]["ORIGAMCLOSE"]), (object) "  Area Engineer : "), (object) str2), (object) "  On Call Engineer : "), (object) str3), (object) "  In Target : "), (object) str4));
            checked { ++num5; }
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " 8AM - 12PM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^8-12"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69940.0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["TEN_TWO"], (object) this.reqtime, false))))
          {
            string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distance : ", dataView1[index5]["ORIGPMCLOSE"]), (object) "  Area Engineer : "), (object) str2), (object) "  On Call Engineer : "), (object) str3), (object) "  In Target : "), (object) str4));
            checked { ++num5; }
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " 10AM - 2PM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^10-2"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69941.0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["TWELVE_FOUR"], (object) this.reqtime, false))))
          {
            string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distance : ", dataView1[index5]["ORIGPMCLOSE"]), (object) "  Area Engineer : "), (object) str2), (object) "  On Call Engineer : "), (object) str3), (object) "  In Target : "), (object) str4));
            checked { ++num5; }
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " 12PM - 4PM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^12-4"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69942.0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["TWO_SIX"], (object) this.reqtime, false))))
          {
            checked { ++num5; }
            string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distance : ", dataView1[index5]["ORIGPMCLOSE"]), (object) "  Area Engineer : "), (object) str2), (object) "  On Call Engineer : "), (object) str3), (object) "  In Target : "), (object) str4));
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " 2PM - 6PM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^2-6"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
        }
        else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["remainingAM"], (object) this.reqtime, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLess(dataView1[index5]["AMCLOSE"], (object) 22, false))))
        {
          dateTime3 = DateTime.Today;
          int num3 = dateTime3.Hour > 9 ? 1 : 0;
          dateTime3 = Conversions.ToDate(dataView1[index5]["Date"]);
          string Left2 = dateTime3.ToString("dd/MM/yyyy");
          dateTime3 = DateAndTime.Today;
          string Right = dateTime3.ToString("dd/MM/yyyy");
          int num4 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, Right, false) == 0 ? 1 : 0;
          if ((num3 & num4) == 0)
          {
            string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distance : ", dataView1[index5]["ORIGAMCLOSE"]), (object) "  Area Engineer : "), (object) str2), (object) "  On Call Engineer : "), (object) str3), (object) "  In Target : "), (object) str4));
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69943.0 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 0.0)
            {
              checked { ++num5; }
              buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " AM"));
              buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^AM"), (object) "^"), (object) str5);
              buttonArray2[index6].Visible = true;
              this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
              buttonArray2[index6].Refresh();
              checked { ++index6; }
            }
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69945.0)
            {
              checked { ++num5; }
              buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " ANYTIME"));
              buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^ANY"), (object) "^"), (object) str5);
              buttonArray2[index6].Visible = true;
              this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
              buttonArray2[index6].Refresh();
              checked { ++index6; }
            }
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69939.0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["EIGHT_TWELVE"], (object) this.reqtime, false))))
            {
              checked { ++num5; }
              buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " 8AM - 12PM"));
              buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^8-12"), (object) "^"), (object) str5);
              buttonArray2[index6].Visible = true;
              this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
              buttonArray2[index6].Refresh();
              checked { ++index6; }
            }
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69940.0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["TEN_TWO"], (object) this.reqtime, false))))
            {
              checked { ++num5; }
              buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " 10AM - 2PM"));
              buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^10-2"), (object) "^"), (object) str5);
              buttonArray2[index6].Visible = true;
              this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
              buttonArray2[index6].Refresh();
              checked { ++index6; }
            }
          }
        }
        else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["remainingPM"], (object) this.reqtime, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLess(dataView1[index5]["PMCLOSE"], (object) 22, false))))
        {
          string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Distance : ", dataView1[index5]["ORIGPMCLOSE"]), (object) "  Area Engineer : "), (object) str2), (object) "  On Call Engineer : "), (object) str3), (object) "  In Target : "), (object) str4));
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69944.0 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 0.0)
          {
            checked { ++num5; }
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " PM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^PM"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69945.0)
          {
            checked { ++num5; }
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " ANYTIME"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^ANY"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69940.0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["TEN_TWO"], (object) this.reqtime, false))))
          {
            checked { ++num5; }
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " 10AM - 2PM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^10-2"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69941.0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["TWELVE_FOUR"], (object) this.reqtime, false))))
          {
            checked { ++num5; }
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " 12PM - 4PM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^12-4"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 69942.0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(dataView1[index5]["TWO_SIX"], (object) this.reqtime, false))))
          {
            checked { ++num5; }
            buttonArray2[index6].Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["name"], (object) "\r\n"), dataView1[index5]["Date"]), (object) " 2PM - 6PM"));
            buttonArray2[index6].Tag = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView1[index5]["EngineerID"], (object) "^"), dataView1[index5]["Date"]), (object) "^2-6"), (object) "^"), (object) str5);
            buttonArray2[index6].Visible = true;
            this.DoButtonColor(dataView1[index5], dateTime1, ref buttonArray2[index6]);
            buttonArray2[index6].Refresh();
            checked { ++index6; }
          }
        }
        checked { ++index5; }
      }
      int index7 = num5;
      if (num5 < 8)
      {
        index7 = num5;
        int num3 = 0;
        Button[] buttonArray3 = buttonArray2;
        int index4 = 0;
        while (index4 < buttonArray3.Length)
        {
          Button button = buttonArray3[index4];
          checked { ++num3; }
          if (num3 > index7)
            button.Visible = false;
          checked { ++index4; }
        }
      }
      string Left3 = Combo.get_GetSelectedItemValue(this.cboAppointment);
      string str6;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, Conversions.ToString(69938), false) == 0)
      {
        dateTime3 = DateAndTime.Today;
        str6 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dateTime3.ToString("tt"), "PM", false) != 0 ? "AM" : "PM";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, Conversions.ToString(69943), false) == 0)
      {
        dateTime3 = DateAndTime.Today;
        str6 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dateTime3.ToString("tt"), "PM", false) != 0 ? "AM" : "PM";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, Conversions.ToString(69944), false) == 0)
        str6 = "PM";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, Conversions.ToString(69939), false) == 0)
      {
        dateTime3 = DateAndTime.Today;
        str6 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dateTime3.ToString("tt"), "PM", false) != 0 ? "8AM - 12PM" : "12PM - 4PM";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, Conversions.ToString(69940), false) == 0)
      {
        dateTime3 = DateAndTime.Today;
        str6 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dateTime3.ToString("tt"), "PM", false) != 0 ? "10AM - 2PM" : "12PM - 4PM";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, Conversions.ToString(69941), false) == 0)
        str6 = "12PM - 4PM";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, Conversions.ToString(69942), false) == 0)
        str6 = "2PM - 6PM";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, Conversions.ToString(69945), false) == 0)
        str6 = "ANYTIME";
      IEnumerator enumerator10;
      bool flag2;
      try
      {
        enumerator10 = dataView2.GetEnumerator();
        while (enumerator10.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator10.Current;
          DateTime date1 = Conversions.ToDate(current["Date"]);
          dateTime3 = DateTime.Now;
          dateTime3 = dateTime3.AddHours(8.0);
          DateTime date2 = Conversions.ToDate(dateTime3.ToString("dd/MM/yyyy"));
          if (DateTime.Compare(date1, date2) >= 0)
          {
            dateTime3 = Conversions.ToDate(current["Date"]);
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dateTime3.ToString("dd/MM/yyyy"), dateTime1.ToString("dd/MM/yyyy"), false) == 0)
            {
              Button button1 = buttonArray2[index7];
              object Left1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["name"], (object) "\r\n");
              dateTime3 = Conversions.ToDate(current["Date"]);
              string str2 = dateTime3.ToString("dd/MM/yyyy");
              string str3 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Left1, (object) str2), (object) " "), (object) str6));
              button1.Text = str3;
              Button button2 = buttonArray2[index7];
              object Left2 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["EngineerID"], (object) "^");
              dateTime3 = Conversions.ToDate(current["Date"]);
              string str4 = dateTime3.ToString("dd/MM/yyyy");
              object obj = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Left2, (object) str4), (object) "^"), (object) str6);
              button2.Tag = obj;
              buttonArray2[index7].Visible = true;
              dateTime3 = Conversions.ToDate(current["Date"]);
              int num3 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dateTime3.ToString("dd/MM/yyyy"), dateTime1.ToString("dd/MM/yyyy"), false) == 0 & DateTime.Compare(Conversions.ToDate(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["Date"], (object) " 18:00")), dateTime1) < 0 ? 1 : 0;
              dateTime3 = Conversions.ToDate(current["Date"]);
              string Left4 = dateTime3.ToString("dd/MM/yyyy");
              dateTime3 = DateAndTime.Today;
              string Right = dateTime3.ToString("dd/MM/yyyy");
              int num4 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left4, Right, false) == 0 ? 1 : 0;
              dateTime3 = DateAndTime.Today;
              int num6 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dateTime3.ToString("tt"), "PM", false) == 0 ? 1 : 0;
              int num7 = num4 & num6;
              if ((num3 | num7) != 0)
                buttonArray2[index7].BackColor = Color.Coral;
              else if (DateTime.Compare(Conversions.ToDate(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["Date"], (object) " 12:00")), dateTime1) < 0)
                buttonArray2[index7].BackColor = Color.PaleGreen;
              else
                buttonArray2[index7].BackColor = Color.Red;
              flag2 = false;
              break;
            }
            Button button3 = buttonArray2[index7];
            object Left5 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView2[0]["name"], (object) "\r\n");
            dateTime3 = Conversions.ToDate(current["Date"]);
            string str5 = dateTime3.ToString("dd/MM/yyyy");
            string str7 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Left5, (object) str5), (object) " "), (object) str6));
            button3.Text = str7;
            Button button4 = buttonArray2[index7];
            object Left6 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataView2[0]["EngineerID"], (object) "^");
            dateTime3 = Conversions.ToDate(current["Date"]);
            string str8 = dateTime3.ToString("dd/MM/yyyy");
            object obj1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Left6, (object) str8), (object) "^"), (object) str6);
            button4.Tag = obj1;
            buttonArray2[index7].Visible = true;
            dateTime3 = Conversions.ToDate(current["Date"]);
            int num8 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dateTime3.ToString("dd/MM/yyyy"), dateTime1.ToString("dd/MM/yyyy"), false) == 0 & DateTime.Compare(Conversions.ToDate(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["Date"], (object) " 18:00")), dateTime1) < 0 ? 1 : 0;
            dateTime3 = Conversions.ToDate(current["Date"]);
            string Left7 = dateTime3.ToString("dd/MM/yyyy");
            dateTime3 = DateAndTime.Today;
            string Right1 = dateTime3.ToString("dd/MM/yyyy");
            int num9 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left7, Right1, false) == 0 ? 1 : 0;
            dateTime3 = DateAndTime.Today;
            int num10 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dateTime3.ToString("tt"), "PM", false) == 0 ? 1 : 0;
            int num11 = num9 & num10;
            if ((num8 | num11) != 0)
              buttonArray2[index7].BackColor = Color.Coral;
            else if (DateTime.Compare(Conversions.ToDate(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["Date"], (object) " 12:00")), dateTime1) < 0)
              buttonArray2[index7].BackColor = Color.PaleGreen;
            else
              buttonArray2[index7].BackColor = Color.Red;
            flag2 = false;
            break;
          }
          flag2 = true;
        }
      }
      finally
      {
        if (enumerator10 is IDisposable)
          (enumerator10 as IDisposable).Dispose();
      }
      if (flag2)
        buttonArray2[index7].Visible = false;
      this.Cursor = Cursors.Default;
    }

    public double distance(double lat1, double lon1, double lat2, double lon2, char unit)
    {
      double deg = lon1 - lon2;
      double num = this.rad2deg(Math.Acos(Math.Sin(this.deg2rad(lat1)) * Math.Sin(this.deg2rad(lat2)) + Math.Cos(this.deg2rad(lat1)) * Math.Cos(this.deg2rad(lat2)) * Math.Cos(this.deg2rad(deg)))) * 60.0 * 1.1515;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(unit), "K", false) == 0)
        num *= 1.609344;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(unit), "N", false) == 0)
        num *= 0.8684;
      return num;
    }

    private double deg2rad(double deg)
    {
      return deg * Math.PI / 180.0;
    }

    private double rad2deg(double rad)
    {
      return rad / Math.PI * 180.0;
    }

    public DataTable AppointmentStrip(
      ref DataTable appointments,
      List<int> levelslist,
      bool IsScheduler = false)
    {
      DataTable table1 = App.DB.EngineerLevel.GetAllInDate().Table;
      int index1 = checked (appointments.Rows.Count - 1);
      while (index1 >= 0)
      {
        DataRow row = appointments.Rows[index1];
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(row["keep"], (object) 0, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(row["remove"], (object) 0, false))))
        {
          bool flag1 = true;
          bool flag2 = true;
          bool flag3 = false;
          try
          {
            foreach (int num in levelslist)
            {
              DataRow[] dataRowArray = table1.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "EngineerID = ", row["EngineerID"])));
              int index2 = 0;
              while (index2 < dataRowArray.Length)
              {
                DataRow dataRow = dataRowArray[index2];
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["ManagerID"], (object) 69698, false))
                  flag3 = true;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual((object) num, dataRow["ManagerID"], false))
                {
                  flag1 = false;
                  break;
                }
                flag1 = true;
                checked { ++index2; }
              }
              if (flag1)
                break;
            }
          }
          finally
          {
            List<int>.Enumerator enumerator;
            enumerator.Dispose();
          }
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "SERVICE", false) == 0)
          {
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["ServPri"])) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row["ServPri"], (object) "10", false))
              flag1 = true;
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.jobtype, "BREAKDOWN", false) == 0 && (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["BreakPri"])) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row["BreakPri"], (object) "10", false)))
            flag1 = true;
          if (flag3 && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row["ONCALL"], (object) 1, false))
            row["cbuoc"] = (object) 1;
          if (!flag1)
          {
            if (IsScheduler)
            {
              flag1 = true;
            }
            else
            {
              flag2 = false;
              flag1 = false;
            }
            List<string> stringList = new List<string>();
            DataTable table2 = App.DB.EngineerPostalRegion.GetTicked(Conversions.ToInteger(row["EngineerID"])).Table;
            IEnumerator enumerator;
            try
            {
              enumerator = table2.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                stringList.Add(Conversions.ToString(current["Name"]));
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            if (stringList.Contains(this.CurrentSite.Postcode.Substring(0, this.CurrentSite.Postcode.IndexOf("-"))))
            {
              if (IsScheduler)
              {
                flag1 = false;
              }
              else
              {
                flag2 = true;
                flag1 = false;
              }
            }
          }
          if (flag3)
          {
            DataRow[] dataRowArray = appointments.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "engineerid = ", row["EngineerID"]), (object) " AND ONCALL = 0")));
            int index2 = 0;
            while (index2 < dataRowArray.Length)
            {
              DataRow dataRow = dataRowArray[index2];
              if (flag1)
              {
                dataRow["remove"] = (object) 1;
              }
              else
              {
                dataRow["keep"] = (object) 1;
                if (!flag2)
                  dataRow["AssignedArea"] = (object) 0;
              }
              checked { ++index2; }
            }
          }
          else
          {
            DataRow[] dataRowArray = appointments.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "engineerid = ", row["EngineerID"])));
            int index2 = 0;
            while (index2 < dataRowArray.Length)
            {
              DataRow dataRow = dataRowArray[index2];
              if (flag1)
              {
                dataRow["remove"] = (object) 1;
              }
              else
              {
                dataRow["keep"] = (object) 1;
                if (!flag2)
                  dataRow["AssignedArea"] = (object) 0;
              }
              checked { ++index2; }
            }
          }
        }
        checked { index1 += -1; }
      }
      DataRow[] dataRowArray1 = appointments.Select("remove = 1  AND CBUOC = 0");
      int index3 = 0;
      while (index3 < dataRowArray1.Length)
      {
        DataRow row = dataRowArray1[index3];
        appointments.Rows.Remove(row);
        checked { ++index3; }
      }
      List<int> intList = new List<int>();
      intList.AddRange((IEnumerable<int>) new int[3]
      {
        67353,
        68032,
        68376
      });
      bool flag = false;
      DataTable table3 = App.DB.Customer.Priorities_Get_For_CustomerID_Active(this.CurrentCustomer.CustomerID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPriority))).Table;
      if (table3.Rows.Count == 1)
        flag = Conversions.ToBoolean(table3.Rows[0]["IncludeWeekends"]);
      if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPriority)) == 66983.0 | flag) && ((this.CurrentContract == null || !intList.Contains(this.CurrentContract.ContractTypeID)) && !this.chkRecall.Checked))
      {
        DataRow[] dataRowArray2 = appointments.Select("1=1");
        int index2 = 0;
        while (index2 < dataRowArray2.Length)
        {
          DataRow row = dataRowArray2[index2];
          DateTime date = Conversions.ToDate(row["thedate"]);
          int num;
          if (date.DayOfWeek != DayOfWeek.Saturday)
          {
            date = Conversions.ToDate(row["thedate"]);
            if (date.DayOfWeek != DayOfWeek.Sunday)
            {
              num = Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row["BH"], (object) 1, false) ? 1 : 0;
              goto label_69;
            }
          }
          num = 1;
label_69:
          if (num != 0)
            appointments.Rows.Remove(row);
          checked { ++index2; }
        }
      }
      return appointments;
    }

    public string workingdays(string Startdate, int Workingdaysin)
    {
      object Left = (object) 0;
      DataView all = App.DB.TimeSlotRates.BankHolidays_GetAll();
      int num1 = Workingdaysin;
      int num2 = 0;
      while (num2 <= num1)
      {
        Left = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Left, (object) 1);
        DayOfWeek dayOfWeek = Conversions.ToDate(Startdate).AddDays(Conversions.ToDouble(Left)).DayOfWeek;
        if (all.Table.Select("BankHolidayDate='" + Conversions.ToString(Conversions.ToDate(Strings.Format((object) Conversions.ToDate(Startdate).AddDays(Conversions.ToDouble(Left)), "dd/MM/yyyy"))) + "'").Length <= 0 && !(dayOfWeek == DayOfWeek.Saturday | dayOfWeek == DayOfWeek.Sunday))
          checked { ++num2; }
        checked { ++num2; }
      }
      DateTime dateTime = Conversions.ToDate(Startdate);
      dateTime = dateTime.AddDays(Conversions.ToDouble(Left));
      return dateTime.ToString();
    }

    private void btnxx1_Click(object sender, EventArgs e)
    {
      this.tab = checked (this.tcSites.SelectedIndex - 1);
      this.tcSites.SelectedTab = this.tcSites.TabPages[this.tab];
      this.Temp.Clear();
    }

    private void dtpFromDate_ValueChanged(object sender, EventArgs e)
    {
      this.FindAppointments(false);
    }

    private void cboAppointment_SelectedIndexChanged_1(object sender, EventArgs e)
    {
      if (!this.tcSites.TabPages.Contains(this.TabBook))
        return;
      this.FindAppointments(false);
    }

    private void DoButtonColor(DataRowView dr, DateTime targettime, ref Button button)
    {
      if (Conversions.ToInteger(dr["SCORE"]) > 10)
        button.BackColor = Color.PaleGreen;
      else if (Conversions.ToInteger(dr["SCORE"]) > -10)
        button.BackColor = Color.Coral;
      else
        button.BackColor = Color.Red;
    }

    private void cboEngineer_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.tab <= 4)
        return;
      this.FindAppointments(false);
    }

    public void ClearSiteDetails()
    {
      this.DGVSites.DataSource = (object) null;
      this.txtAddress1.Text = "";
      this.txtAddress2.Text = "";
      this.txtAddress3.Text = "";
      this.txtPostcode.Text = "";
      this.txtCustomer.Text = "";
      this.txtEmail.Text = "";
      this.txtFirstName.Text = "";
      this.txtMob.Text = "";
      this.txtSurname.Text = "";
      this.txtTel.Text = "";
      this.chkCert.Visible = false;
      this.chkCert.Checked = false;
      this.lblcert.Visible = false;
      this.txtAdditional.Text = "";
      this.CurrentContract = (ContractOriginal) null;
      this.txtContractRef.Text = "";
      this.txtName.Text = "";
      this.txtPONumber.Text = "";
      this.txtSiteNotes.Text = "";
      ComboBox cboTitle = this.cboTitle;
      Combo.SetSelectedComboItem_By_Value(ref cboTitle, Conversions.ToString(0));
      this.cboTitle = cboTitle;
      this.DGVSites.DataSource = (object) null;
    }

    public void Reset()
    {
      this.btnxxNewJob.BackColor = SystemColors.Control;
      this.cbotypeWiz.BackColor = SystemColors.Window;
      this.txtHrs.Text = "";
      this.txtDays.Text = "";
      this.btnxxExistingJobNext.Visible = false;
      this.btnxxJobNext.Visible = false;
      this.btnxxSiteNext.Visible = false;
      this.btnxxDetailsNext.Visible = false;
      IEnumerator enumerator;
      try
      {
        enumerator = this.tabJobType.Controls.GetEnumerator();
        while (enumerator.MoveNext())
        {
          Control current = (Control) enumerator.Current;
          if (current is Button)
            current.BackColor = SystemColors.Control;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.txtSearch.Text = "";
      try
      {
        this.tab = 0;
        this.tcSites.TabPages[0].Enabled = true;
        this.tcSites.TabPages.Remove(this.tabProp);
        this.tcSites.TabPages.Add(this.tabProp);
        this.tcSites.TabPages.Remove(this.tabExistingJobs);
        this.tcSites.TabPages.Remove(this.tabJobType);
        this.tcSites.TabPages.Remove(this.tabJobDetails);
        this.tcSites.TabPages.Remove(this.tabAppliance);
        this.tcSites.TabPages.Remove(this.TabCharging);
        this.tcSites.TabPages.Remove(this.tabAdditional);
        this.tcSites.TabPages.Remove(this.TabBook);
        this.tcSites.TabPages.Remove(this.tcComplete);
        this.tcSites.SelectedIndex = 0;
        this.Temp.Clear();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.tcSites.SelectedIndex = 0;
        ProjectData.ClearProjectError();
      }
      this.GasConfirmedInBoiler = true;
      DataView dataView = new DataView();
      DataTable dataTable = new DataTable();
      dataTable.TableName = "1";
      dataTable.Columns.Add("SypID");
      dataTable.Columns.Add("Code");
      dataTable.Columns.Add("Description");
      dataView.Table = dataTable;
      this.SympDataView = dataView;
      this.DGSymptoms.DataSource = (object) dataTable;
      this.SiteChange = false;
      this.BookingDetail = "";
      this.visitsBooked = 0;
      try
      {
        this.ParentForm.Controls.Find("btnSaveProg", true)[0].Visible = false;
        this.ParentForm.Controls.Find("btnPrivateNotes", true)[0].Visible = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.RunFilter();
    }

    public void SaveProgress()
    {
      this.BookingDetail = "";
      // ISSUE: variable of a reference type
      int& local1;
      // ISSUE: explicit reference operation
      int num1 = checked (^(local1 = ref this.visitsBooked) + 1);
      local1 = num1;
      if (this.tab < 5)
        this.DoCharging();
      this.CurrentJob = this.CreateVisits(0, DateTime.MinValue, "", (double) this.priTime, "", this.visitsBooked);
      if (this.chkKeepTogether.Checked & this.secTime > 0)
      {
        // ISSUE: variable of a reference type
        int& local2;
        // ISSUE: explicit reference operation
        int num2 = checked (^(local2 = ref this.visitsBooked) + 1);
        local2 = num2;
        this.CreateVisits(0, DateTime.MinValue, "", (double) this.secTime, "", this.visitsBooked);
      }
      this.lblBookedInfo.Text = this.BookingDetail + " (Click here to view job)";
      try
      {
        this.ParentForm.Controls.Find("btnSaveProg", true)[0].Visible = false;
        this.ParentForm.Controls.Find("btnPrivateNotes", true)[0].Visible = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.Reset();
    }

    public void Notes()
    {
      FRMPrivNotes frmPrivNotes = new FRMPrivNotes();
      frmPrivNotes.dt = this.DTPrivNotes;
      int num = (int) frmPrivNotes.ShowDialog();
      this.DTPrivNotes = frmPrivNotes.dt;
      if (this.tcSites.TabCount != 9)
        ;
      DataRow[] dataRowArray = this.DTPrivNotes.Select("JobNoteID = 0");
      int index = 0;
      while (index < dataRowArray.Length)
      {
        DataRow dataRow = dataRowArray[index];
        App.DB.Job.SaveJobNotes(0, Conversions.ToString(dataRow["Note"]), Conversions.ToInteger(dataRow["EditedByUserID"]), this.jobids, Conversions.ToInteger(dataRow["CreatedByUserID"]));
        checked { ++index; }
      }
      this.DTPrivNotes = App.DB.Job.GetAllJobNotes(this.CurrentSite.SiteID);
    }

    private void chkKeepTogether_CheckedChanged(object sender, EventArgs e)
    {
      if (this.tcSites.SelectedIndex != 6)
        return;
      this.FindAppointments(false);
    }

    private void Button_Paint(object sender, PaintEventArgs e)
    {
      Button button = (Button) sender;
      string s;
      try
      {
        s = button.Tag.ToString().Split('^')[3];
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        s = "";
        ProjectData.ClearProjectError();
      }
      Font font = new Font("Verdana", 7f);
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Center;
      format.LineAlignment = StringAlignment.Center;
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      e.Graphics.DrawString(s, font, Brushes.Black, (float) checked ((int) Math.Round(unchecked ((double) button.Width / 2.0))), (float) checked (button.Height - 10), format);
    }

    private void btnxx_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.tabJobType.Controls.GetEnumerator();
        while (enumerator.MoveNext())
        {
          Control current = (Control) enumerator.Current;
          if (current is Button)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.Name, ((Control) sender).Name, false) == 0)
            {
              current.BackColor = Color.PaleGreen;
              this.jobtype = current.Text.ToUpper();
              if (current.Tag != null && current.Tag.ToString().Length > 0)
              {
                ComboBox cbotypeWiz = this.cbotypeWiz;
                Combo.SetSelectedComboItem_By_Value(ref cbotypeWiz, Conversions.ToString(current.Tag));
                this.cbotypeWiz = cbotypeWiz;
              }
              this.btnxxJobNext.Visible = true;
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.Name, "btnxxSOR", false) == 0)
              {
                this.pnlSOR.Visible = true;
                this.jobtype = "SOR";
                this.pnlSOR.Visible = true;
                ComboBox cboSor = this.cboSOR;
                Combo.SetUpCombo(ref cboSor, App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(this.CurrentCustomer.CustomerID).Table, "CustomerScheduleOfRateID", "Description", Enums.ComboValues.Please_Select);
                this.cboSOR = cboSor;
                if (this.DGSOR.RowCount > 0)
                {
                  if (!(this.CurrentSite.PoNumReqd & this.txtPONumber.Text.Length == 0) && !(this.cboPriority.Items.Count > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPriority)) < 1.0))
                    this.btnxxJobNext.Visible = true;
                }
                else
                  this.btnxxJobNext.Visible = false;
              }
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.Name, "btnxxOther", false) == 0)
              {
                this.btnxxOther.Visible = false;
                this.pnlSymptoms.Visible = true;
                this.lbltype.Visible = true;
                this.cbotypeWiz.Visible = true;
                this.cbotypeWiz.BackColor = Color.PaleGreen;
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cbotypeWiz)) < 1.0)
                {
                  this.btnxxJobNext.Visible = false;
                }
                else
                {
                  if (!(this.CurrentSite.PoNumReqd & this.txtPONumber.Text.Length == 0) && !(this.cboPriority.Items.Count > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPriority)) < 1.0))
                    this.btnxxJobNext.Visible = true;
                  this.jobtype = Combo.get_GetSelectedItemDescription(this.cbotypeWiz).ToUpper();
                }
              }
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.Name, "BtnxxService", false) == 0)
              {
                this.pnlSymptoms.Visible = false;
                this.chkCert.Checked = true;
              }
              if (this.cboPriority.Items.Count > 1)
              {
                this.lblPriority.Visible = true;
                this.cboPriority.Visible = true;
              }
              else
              {
                this.lblPriority.Visible = false;
                this.cboPriority.Visible = false;
              }
              this.lblAdditional.Visible = true;
              this.txtAdditional.Visible = true;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.Parent.Name, "tabJobType", false) == 0)
            {
              current.BackColor = SystemColors.Control;
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.Name, "btnxxOther", false) == 0)
              {
                current.Visible = true;
                this.lbltype.Visible = false;
                this.cbotypeWiz.Visible = false;
                this.cbotypeWiz.BackColor = SystemColors.Window;
              }
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.Name, "btnxxSOR", false) == 0)
                this.pnlSOR.Visible = false;
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

    private void cboPayTerms_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPayTerms)) < 1.0)
        this.btnxxChargeNext.Visible = false;
      else
        this.btnxxChargeNext.Visible = true;
      this.visitcharge1 = Conversions.ToDouble(this.txtCharge.Text);
      this.visitterm1 = Combo.get_GetSelectedItemDescription(this.cboPayTerms);
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      this.FindAppointments(false);
    }

    private void txtDiscountCode_TextChanged(object sender, EventArgs e)
    {
      this.CheckDiscount();
    }

    private void CheckDiscount()
    {
      this.PromotionText = "";
      DataRow[] dataRowArray = this.PromotionsDT.Select("Code = '" + this.txtDiscountCode.Text + "'");
      if (dataRowArray.Length > 0)
      {
        this.picCross.Visible = false;
        this.picTick.Visible = true;
        this.txtCharge.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject((object) this.FinalCharge, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject((object) this.FinalCharge, Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(dataRowArray[0]["DiscountPercent"], (object) 100))));
        this.txtPayInst.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) (this.FinalText + "\r\nPromotion Applied: "), dataRowArray[0]["PromotionText"]), (object) " = -"), (object) Strings.Format((object) Conversions.ToDouble(Conversions.ToString(NewLateBinding.LateGet((object) null, typeof (Math), "Round", new object[2]
        {
          Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject((object) this.FinalCharge, Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(dataRowArray[0]["DiscountPercent"], (object) 100)),
          (object) 2
        }, (string[]) null, (System.Type[]) null, (bool[]) null))), "C")));
        this.PromotionText = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Promotion Applied: ", dataRowArray[0]["PromotionText"]), (object) " = -"), (object) Strings.Format((object) Conversions.ToDouble(Conversions.ToString(NewLateBinding.LateGet((object) null, typeof (Math), "Round", new object[2]
        {
          Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject((object) this.FinalCharge, Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(dataRowArray[0]["DiscountPercent"], (object) 100)),
          (object) 2
        }, (string[]) null, (System.Type[]) null, (bool[]) null))), "C")));
      }
      else
      {
        this.picCross.Visible = true;
        this.picTick.Visible = false;
        this.txtCharge.Text = Conversions.ToString(this.FinalCharge);
        this.txtPayInst.Text = this.FinalText;
      }
      if (this.txtDiscountCode.Text.Length == 0)
      {
        this.picCross.Visible = false;
        this.picTick.Visible = false;
        this.txtCharge.Text = Conversions.ToString(this.FinalCharge);
        this.txtPayInst.Text = this.FinalText;
      }
      this.txtCharge.Text = Strings.Format((object) Conversions.ToDouble(this.txtCharge.Text), "C");
    }

    private void txtAdditional_TextChanged(object sender, EventArgs e)
    {
      this.ValidateJobDetails();
    }

    private void lblBookedInfo_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMLogCallout), true, new object[3]
      {
        (object) this.CurrentJob.JobID,
        (object) this.CurrentSite.SiteID,
        (object) this
      }, false);
    }

    private void Button1_Click_1(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMDocuments), true, new object[4]
      {
        (object) Enums.TableNames.tblJob,
        (object) this.CurrentJob.JobID,
        (object) 0,
        (object) this
      }, false);
    }

    private void txtSearchSite_MouseClick(object sender, EventArgs e)
    {
      this.RunFilter();
    }
  }
}
