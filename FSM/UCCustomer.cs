// Decompiled with JetBrains decompiler
// Type: FSM.UCCustomer
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Authority;
using FSM.Entity.CustomerCharges;
using FSM.Entity.Customers;
using FSM.Entity.Management;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCCustomer : UCBase, IUserControl
  {
    private IContainer components;
    private UCDocumentsList DocumentsControl;
    private UCQuotesList QuotesControl;
    private UCCustomerScheduleOfRate CustomerScheduleOfRateControl;
    private UCCustomerServiceProcess UcServiceProcess;
    private FSM.Entity.Customers.Customer _currentCustomer;
    private DataView _Data;
    private FSM.Entity.Authority.Authority _oCustomerAuthority;
    private DataView _PartsDataView;
    private DataView _EngRaiseView;
    private DataView _RequirementDataView;
    private DataView _dvContracts;
    private DataView _dvCustomerAuthorityAudit;
    private DataView _dvCustomerAlerts;

    public UCCustomer()
    {
      this.Load += new EventHandler(this.UCCustomer_Load);
      this._PartsDataView = (DataView) null;
      this._EngRaiseView = (DataView) null;
      this._RequirementDataView = (DataView) null;
      this._dvCustomerAlerts = (DataView) null;
      this.InitializeComponent();
      ComboBox cboRegionId = this.cboRegionID;
      Combo.SetUpCombo(ref cboRegionId, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboRegionID = cboRegionId;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, DynamicDataTables.CustomerStatus, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboStatus = cboStatus;
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, App.DB.Picklists.GetAll(Enums.PickListTypes.CustomerTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboType = cboType;
      ComboBox cboTerms = this.cboTerms;
      Combo.SetUpCombo(ref cboTerms, App.DB.Picklists.GetAll(Enums.PickListTypes.Models | Enums.PickListTypes.Symptoms, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboTerms = cboTerms;
      ComboBox cboAlertType = this.cboAlertType;
      Combo.SetUpCombo(ref cboAlertType, App.DB.Picklists.GetAll(Enums.PickListTypes.AlertTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboAlertType = cboAlertType;
      if (true == App.IsGasway)
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
      else
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
      this.SetupDG();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegionID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRegionID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAccountNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAccountNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabMainDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabContracts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlContracts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabQuotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlQuotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRatesMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMileageRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartsMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grbCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbContracts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgContracts
    {
      get
      {
        return this._dgContracts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgContracts_DoubleClick);
        DataGrid dgContracts1 = this._dgContracts;
        if (dgContracts1 != null)
          dgContracts1.DoubleClick -= eventHandler;
        this._dgContracts = value;
        DataGrid dgContracts2 = this._dgContracts;
        if (dgContracts2 == null)
          return;
        dgContracts2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnAddContract
    {
      get
      {
        return this._btnAddContract;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddContract_Click);
        Button btnAddContract1 = this._btnAddContract;
        if (btnAddContract1 != null)
          btnAddContract1.Click -= eventHandler;
        this._btnAddContract = value;
        Button btnAddContract2 = this._btnAddContract;
        if (btnAddContract2 == null)
          return;
        btnAddContract2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeleteContract
    {
      get
      {
        return this._btnDeleteContract;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteContract_Click);
        Button btnDeleteContract1 = this._btnDeleteContract;
        if (btnDeleteContract1 != null)
          btnDeleteContract1.Click -= eventHandler;
        this._btnDeleteContract = value;
        Button btnDeleteContract2 = this._btnDeleteContract;
        if (btnDeleteContract2 == null)
          return;
        btnDeleteContract2.Click += eventHandler;
      }
    }

    internal virtual ContextMenu cmnuContractOptions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuContractOpt1
    {
      get
      {
        return this._mnuContractOpt1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuContractOpt1_Click);
        MenuItem mnuContractOpt1_1 = this._mnuContractOpt1;
        if (mnuContractOpt1_1 != null)
          mnuContractOpt1_1.Click -= eventHandler;
        this._mnuContractOpt1 = value;
        MenuItem mnuContractOpt1_2 = this._mnuContractOpt1;
        if (mnuContractOpt1_2 == null)
          return;
        mnuContractOpt1_2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chbAcceptChargeChanges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picLogo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSelectLogoImage
    {
      get
      {
        return this._btnSelectLogoImage;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSelectLogoImage_Click);
        Button btnSelectLogoImage1 = this._btnSelectLogoImage;
        if (btnSelectLogoImage1 != null)
          btnSelectLogoImage1.Click -= eventHandler;
        this._btnSelectLogoImage = value;
        Button btnSelectLogoImage2 = this._btnSelectLogoImage;
        if (btnSelectLogoImage2 == null)
          return;
        btnSelectLogoImage2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkPONumReq { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkJobPriorityRequired { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNominal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabPriority { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTerms { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgRequirements
    {
      get
      {
        return this._dgRequirements;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgRequirement_MouseUp);
        DataGrid dgRequirements1 = this._dgRequirements;
        if (dgRequirements1 != null)
          dgRequirements1.MouseUp -= mouseEventHandler;
        this._dgRequirements = value;
        DataGrid dgRequirements2 = this._dgRequirements;
        if (dgRequirements2 == null)
          return;
        dgRequirements2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkSuperBooking { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtServWinter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtServSummer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgvParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual DataGridView dgvPriority { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAlertEmail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabServiceDates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabCreation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnEngDelete
    {
      get
      {
        return this._btnEngDelete;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEngDelete_Click);
        Button btnEngDelete1 = this._btnEngDelete;
        if (btnEngDelete1 != null)
          btnEngDelete1.Click -= eventHandler;
        this._btnEngDelete = value;
        Button btnEngDelete2 = this._btnEngDelete;
        if (btnEngDelete2 == null)
          return;
        btnEngDelete2.Click += eventHandler;
      }
    }

    internal virtual Button btnEngAdd
    {
      get
      {
        return this._btnEngAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEngAdd_Click);
        Button btnEngAdd1 = this._btnEngAdd;
        if (btnEngAdd1 != null)
          btnEngAdd1.Click -= eventHandler;
        this._btnEngAdd = value;
        Button btnEngAdd2 = this._btnEngAdd;
        if (btnEngAdd2 == null)
          return;
        btnEngAdd2.Click += eventHandler;
      }
    }

    internal virtual DataGridView dgRaiseEng
    {
      get
      {
        return this._dgRaiseEng;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DataGridViewCellEventHandler cellEventHandler = new DataGridViewCellEventHandler(this.dgRaiseEng_CellContentClick);
        DataGridView dgRaiseEng1 = this._dgRaiseEng;
        if (dgRaiseEng1 != null)
          dgRaiseEng1.CellDoubleClick -= cellEventHandler;
        this._dgRaiseEng = value;
        DataGridView dgRaiseEng2 = this._dgRaiseEng;
        if (dgRaiseEng2 == null)
          return;
        dgRaiseEng2.CellDoubleClick += cellEventHandler;
      }
    }

    internal virtual CheckBox chkMOTService { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabAuthority { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpCustAuth { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustAuthority { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveAuth
    {
      get
      {
        return this._btnSaveAuth;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveAuth_Click);
        Button btnSaveAuth1 = this._btnSaveAuth;
        if (btnSaveAuth1 != null)
          btnSaveAuth1.Click -= eventHandler;
        this._btnSaveAuth = value;
        Button btnSaveAuth2 = this._btnSaveAuth;
        if (btnSaveAuth2 == null)
          return;
        btnSaveAuth2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAuthorityAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartSearch
    {
      get
      {
        return this._txtPartSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPartSearch_Change);
        TextBox txtPartSearch1 = this._txtPartSearch;
        if (txtPartSearch1 != null)
          txtPartSearch1.TextChanged -= eventHandler;
        this._txtPartSearch = value;
        TextBox txtPartSearch2 = this._txtPartSearch;
        if (txtPartSearch2 == null)
          return;
        txtPartSearch2.TextChanged += eventHandler;
      }
    }

    internal virtual Button btnExportSites
    {
      get
      {
        return this._btnExportSites;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExportSites_Click);
        Button btnExportSites1 = this._btnExportSites;
        if (btnExportSites1 != null)
          btnExportSites1.Click -= eventHandler;
        this._btnExportSites = value;
        Button btnExportSites2 = this._btnExportSites;
        if (btnExportSites2 == null)
          return;
        btnExportSites2.Click += eventHandler;
      }
    }

    internal virtual CheckBox cbIsOutOfScope { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSpendLimit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobSpendLimit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkIsPFH { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabAlerts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpCustomerAlerts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgCustomerAlerts
    {
      get
      {
        return this._dgCustomerAlerts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgCustomerAlerts_Click);
        DataGrid dgCustomerAlerts1 = this._dgCustomerAlerts;
        if (dgCustomerAlerts1 != null)
          dgCustomerAlerts1.Click -= eventHandler;
        this._dgCustomerAlerts = value;
        DataGrid dgCustomerAlerts2 = this._dgCustomerAlerts;
        if (dgCustomerAlerts2 == null)
          return;
        dgCustomerAlerts2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveCustomerAlert
    {
      get
      {
        return this._btnSaveCustomerAlert;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveCustomerAlert_Click);
        Button saveCustomerAlert1 = this._btnSaveCustomerAlert;
        if (saveCustomerAlert1 != null)
          saveCustomerAlert1.Click -= eventHandler;
        this._btnSaveCustomerAlert = value;
        Button saveCustomerAlert2 = this._btnSaveCustomerAlert;
        if (saveCustomerAlert2 == null)
          return;
        saveCustomerAlert2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboAlertType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCustomerAlertEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAlertType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomerAlertEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmailAddressMsg { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDeleteCustomerAlert
    {
      get
      {
        return this._btnDeleteCustomerAlert;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteCustomerAlert_Click);
        Button deleteCustomerAlert1 = this._btnDeleteCustomerAlert;
        if (deleteCustomerAlert1 != null)
          deleteCustomerAlert1.Click -= eventHandler;
        this._btnDeleteCustomerAlert = value;
        Button deleteCustomerAlert2 = this._btnDeleteCustomerAlert;
        if (deleteCustomerAlert2 == null)
          return;
        deleteCustomerAlert2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddCustomerAlert
    {
      get
      {
        return this._btnAddCustomerAlert;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddCustomerAlert_Click);
        Button addCustomerAlert1 = this._btnAddCustomerAlert;
        if (addCustomerAlert1 != null)
          addCustomerAlert1.Click -= eventHandler;
        this._btnAddCustomerAlert = value;
        Button addCustomerAlert2 = this._btnAddCustomerAlert;
        if (addCustomerAlert2 == null)
          return;
        addCustomerAlert2.Click += eventHandler;
      }
    }

    internal virtual ToolTip tt { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlServiceProcess { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMainContractorDiscount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.grpCustomer = new GroupBox();
      this.chkIsPFH = new CheckBox();
      this.cbIsOutOfScope = new CheckBox();
      this.btnExportSites = new Button();
      this.chkMOTService = new CheckBox();
      this.txtAlertEmail = new TextBox();
      this.Label13 = new Label();
      this.txtServWinter = new TextBox();
      this.txtServSummer = new TextBox();
      this.Label12 = new Label();
      this.chkSuperBooking = new CheckBox();
      this.cboTerms = new ComboBox();
      this.Label9 = new Label();
      this.cboDepartment = new ComboBox();
      this.Label8 = new Label();
      this.txtNominal = new TextBox();
      this.Label7 = new Label();
      this.chkJobPriorityRequired = new CheckBox();
      this.chkPONumReq = new CheckBox();
      this.btnSelectLogoImage = new Button();
      this.picLogo = new PictureBox();
      this.Label6 = new Label();
      this.cboType = new ComboBox();
      this.Label2 = new Label();
      this.txtName = new TextBox();
      this.lblName = new Label();
      this.cboRegionID = new ComboBox();
      this.lblRegionID = new Label();
      this.txtNotes = new TextBox();
      this.lblNotes = new Label();
      this.txtAccountNumber = new TextBox();
      this.lblAccountNumber = new Label();
      this.cboStatus = new ComboBox();
      this.lblStatus = new Label();
      this.TabControl1 = new TabControl();
      this.tabMainDetails = new TabPage();
      this.tabContracts = new TabPage();
      this.pnlContracts = new Panel();
      this.gpbContracts = new GroupBox();
      this.btnDeleteContract = new Button();
      this.dgContracts = new DataGrid();
      this.btnAddContract = new Button();
      this.tabCharges = new TabPage();
      this.grbCharges = new GroupBox();
      this.txtSpendLimit = new TextBox();
      this.lblJobSpendLimit = new Label();
      this.txtMainContractorDiscount = new TextBox();
      this.Label5 = new Label();
      this.chbAcceptChargeChanges = new CheckBox();
      this.Label3 = new Label();
      this.txtRatesMarkup = new TextBox();
      this.Label4 = new Label();
      this.Label1 = new Label();
      this.txtMileageRate = new TextBox();
      this.txtPartsMarkup = new TextBox();
      this.pnlCharges = new Panel();
      this.tabDocuments = new TabPage();
      this.pnlDocuments = new Panel();
      this.tabQuotes = new TabPage();
      this.pnlQuotes = new Panel();
      this.tabPriority = new TabPage();
      this.dgvPriority = new DataGridView();
      this.Label11 = new Label();
      this.dgRequirements = new DataGrid();
      this.Label10 = new Label();
      this.tabParts = new TabPage();
      this.Label14 = new Label();
      this.txtPartSearch = new TextBox();
      this.btnDelete = new Button();
      this.btnAdd = new Button();
      this.dgvParts = new DataGridView();
      this.tabServiceDates = new TabPage();
      this.tabCreation = new TabPage();
      this.btnEngDelete = new Button();
      this.btnEngAdd = new Button();
      this.dgRaiseEng = new DataGridView();
      this.tabAuthority = new TabPage();
      this.grpAudit = new GroupBox();
      this.dgAuthorityAudit = new DataGrid();
      this.gpCustAuth = new GroupBox();
      this.btnSaveAuth = new Button();
      this.txtCustAuthority = new TextBox();
      this.tabAlerts = new TabPage();
      this.grpCustomerAlerts = new GroupBox();
      this.grpSite = new GroupBox();
      this.btnAddCustomerAlert = new Button();
      this.btnDeleteCustomerAlert = new Button();
      this.txtCustomerAlertEmailAddress = new TextBox();
      this.lblEmailAddressMsg = new Label();
      this.btnSaveCustomerAlert = new Button();
      this.cboAlertType = new ComboBox();
      this.lblCustomerAlertEmailAddress = new Label();
      this.lblAlertType = new Label();
      this.dgCustomerAlerts = new DataGrid();
      this.cmnuContractOptions = new ContextMenu();
      this.mnuContractOpt1 = new MenuItem();
      this.tt = new ToolTip(this.components);
      this.pnlServiceProcess = new Panel();
      this.grpCustomer.SuspendLayout();
      ((ISupportInitialize) this.picLogo).BeginInit();
      this.TabControl1.SuspendLayout();
      this.tabMainDetails.SuspendLayout();
      this.tabContracts.SuspendLayout();
      this.pnlContracts.SuspendLayout();
      this.gpbContracts.SuspendLayout();
      this.dgContracts.BeginInit();
      this.tabCharges.SuspendLayout();
      this.grbCharges.SuspendLayout();
      this.tabDocuments.SuspendLayout();
      this.tabQuotes.SuspendLayout();
      this.tabPriority.SuspendLayout();
      ((ISupportInitialize) this.dgvPriority).BeginInit();
      this.dgRequirements.BeginInit();
      this.tabParts.SuspendLayout();
      ((ISupportInitialize) this.dgvParts).BeginInit();
      this.tabServiceDates.SuspendLayout();
      this.tabCreation.SuspendLayout();
      ((ISupportInitialize) this.dgRaiseEng).BeginInit();
      this.tabAuthority.SuspendLayout();
      this.grpAudit.SuspendLayout();
      this.dgAuthorityAudit.BeginInit();
      this.gpCustAuth.SuspendLayout();
      this.tabAlerts.SuspendLayout();
      this.grpCustomerAlerts.SuspendLayout();
      this.grpSite.SuspendLayout();
      this.dgCustomerAlerts.BeginInit();
      this.SuspendLayout();
      this.grpCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCustomer.Controls.Add((Control) this.chkIsPFH);
      this.grpCustomer.Controls.Add((Control) this.cbIsOutOfScope);
      this.grpCustomer.Controls.Add((Control) this.btnExportSites);
      this.grpCustomer.Controls.Add((Control) this.chkMOTService);
      this.grpCustomer.Controls.Add((Control) this.txtAlertEmail);
      this.grpCustomer.Controls.Add((Control) this.Label13);
      this.grpCustomer.Controls.Add((Control) this.txtServWinter);
      this.grpCustomer.Controls.Add((Control) this.txtServSummer);
      this.grpCustomer.Controls.Add((Control) this.Label12);
      this.grpCustomer.Controls.Add((Control) this.chkSuperBooking);
      this.grpCustomer.Controls.Add((Control) this.cboTerms);
      this.grpCustomer.Controls.Add((Control) this.Label9);
      this.grpCustomer.Controls.Add((Control) this.cboDepartment);
      this.grpCustomer.Controls.Add((Control) this.Label8);
      this.grpCustomer.Controls.Add((Control) this.txtNominal);
      this.grpCustomer.Controls.Add((Control) this.Label7);
      this.grpCustomer.Controls.Add((Control) this.chkJobPriorityRequired);
      this.grpCustomer.Controls.Add((Control) this.chkPONumReq);
      this.grpCustomer.Controls.Add((Control) this.btnSelectLogoImage);
      this.grpCustomer.Controls.Add((Control) this.picLogo);
      this.grpCustomer.Controls.Add((Control) this.Label6);
      this.grpCustomer.Controls.Add((Control) this.cboType);
      this.grpCustomer.Controls.Add((Control) this.Label2);
      this.grpCustomer.Controls.Add((Control) this.txtName);
      this.grpCustomer.Controls.Add((Control) this.lblName);
      this.grpCustomer.Controls.Add((Control) this.cboRegionID);
      this.grpCustomer.Controls.Add((Control) this.lblRegionID);
      this.grpCustomer.Controls.Add((Control) this.txtNotes);
      this.grpCustomer.Controls.Add((Control) this.lblNotes);
      this.grpCustomer.Controls.Add((Control) this.txtAccountNumber);
      this.grpCustomer.Controls.Add((Control) this.lblAccountNumber);
      this.grpCustomer.Controls.Add((Control) this.cboStatus);
      this.grpCustomer.Controls.Add((Control) this.lblStatus);
      this.grpCustomer.Location = new System.Drawing.Point(9, 8);
      this.grpCustomer.Name = "grpCustomer";
      this.grpCustomer.Size = new Size(629, 558);
      this.grpCustomer.TabIndex = 0;
      this.grpCustomer.TabStop = false;
      this.grpCustomer.Text = "Details";
      this.chkIsPFH.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.chkIsPFH.AutoSize = true;
      this.chkIsPFH.Location = new System.Drawing.Point(555, 353);
      this.chkIsPFH.Name = "chkIsPFH";
      this.chkIsPFH.RightToLeft = RightToLeft.Yes;
      this.chkIsPFH.Size = new Size(62, 17);
      this.chkIsPFH.TabIndex = 58;
      this.chkIsPFH.Text = "Is PFH";
      this.chkIsPFH.UseVisualStyleBackColor = true;
      this.cbIsOutOfScope.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cbIsOutOfScope.AutoSize = true;
      this.cbIsOutOfScope.Location = new System.Drawing.Point(516, 376);
      this.cbIsOutOfScope.Name = "cbIsOutOfScope";
      this.cbIsOutOfScope.RightToLeft = RightToLeft.Yes;
      this.cbIsOutOfScope.Size = new Size(102, 17);
      this.cbIsOutOfScope.TabIndex = 57;
      this.cbIsOutOfScope.Text = "Out Of Scope";
      this.cbIsOutOfScope.UseVisualStyleBackColor = true;
      this.btnExportSites.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExportSites.Location = new System.Drawing.Point(6, 527);
      this.btnExportSites.Name = "btnExportSites";
      this.btnExportSites.Size = new Size(103, 25);
      this.btnExportSites.TabIndex = 56;
      this.btnExportSites.Text = "Export Sites";
      this.chkMOTService.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.chkMOTService.AutoSize = true;
      this.chkMOTService.Location = new System.Drawing.Point(479, 398);
      this.chkMOTService.Name = "chkMOTService";
      this.chkMOTService.RightToLeft = RightToLeft.Yes;
      this.chkMOTService.Size = new Size(139, 17);
      this.chkMOTService.TabIndex = 55;
      this.chkMOTService.Text = "M.O.T Style Service";
      this.chkMOTService.UseVisualStyleBackColor = true;
      this.txtAlertEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAlertEmail.Location = new System.Drawing.Point(120, 261);
      this.txtAlertEmail.MaxLength = (int) byte.MaxValue;
      this.txtAlertEmail.Name = "txtAlertEmail";
      this.txtAlertEmail.Size = new Size(498, 21);
      this.txtAlertEmail.TabIndex = 54;
      this.txtAlertEmail.Tag = (object) "Customer.Name";
      this.Label13.Location = new System.Drawing.Point(8, 264);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(89, 20);
      this.Label13.TabIndex = 53;
      this.Label13.Text = "Alert Email";
      this.txtServWinter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtServWinter.Location = new System.Drawing.Point(540, 520);
      this.txtServWinter.MaxLength = 50;
      this.txtServWinter.Name = "txtServWinter";
      this.txtServWinter.Size = new Size(77, 21);
      this.txtServWinter.TabIndex = 52;
      this.txtServWinter.Tag = (object) " ";
      this.txtServSummer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtServSummer.Location = new System.Drawing.Point(415, 520);
      this.txtServSummer.MaxLength = 50;
      this.txtServSummer.Name = "txtServSummer";
      this.txtServSummer.Size = new Size(77, 21);
      this.txtServSummer.TabIndex = 51;
      this.txtServSummer.Tag = (object) " ";
      this.Label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label12.Location = new System.Drawing.Point(270, 514);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(113, 27);
      this.Label12.TabIndex = 50;
      this.Label12.Text = "Summer/Winter Servicing P/Month";
      this.chkSuperBooking.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.chkSuperBooking.AutoSize = true;
      this.chkSuperBooking.Location = new System.Drawing.Point(444, 464);
      this.chkSuperBooking.Name = "chkSuperBooking";
      this.chkSuperBooking.RightToLeft = RightToLeft.Yes;
      this.chkSuperBooking.Size = new Size(174, 17);
      this.chkSuperBooking.TabIndex = 49;
      this.chkSuperBooking.Text = "Coordinator Booking Only";
      this.chkSuperBooking.UseVisualStyleBackColor = true;
      this.cboTerms.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboTerms.Cursor = Cursors.Hand;
      this.cboTerms.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboTerms.Location = new System.Drawing.Point(120, 227);
      this.cboTerms.Name = "cboTerms";
      this.cboTerms.Size = new Size(498, 21);
      this.cboTerms.TabIndex = 48;
      this.cboTerms.Tag = (object) "Customer.Status";
      this.Label9.Location = new System.Drawing.Point(8, 226);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(103, 20);
      this.Label9.TabIndex = 47;
      this.Label9.Text = "Terms";
      this.cboDepartment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cboDepartment.Cursor = Cursors.Hand;
      this.cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDepartment.Location = new System.Drawing.Point(415, 488);
      this.cboDepartment.Name = "cboDepartment";
      this.cboDepartment.Size = new Size(203, 21);
      this.cboDepartment.TabIndex = 46;
      this.cboDepartment.Tag = (object) "Customer.TypeID";
      this.Label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label8.Location = new System.Drawing.Point(270, 491);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(139, 23);
      this.Label8.TabIndex = 45;
      this.Label8.Text = "Override Department";
      this.txtNominal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNominal.Location = new System.Drawing.Point(120, 193);
      this.txtNominal.MaxLength = 50;
      this.txtNominal.Name = "txtNominal";
      this.txtNominal.Size = new Size(498, 21);
      this.txtNominal.TabIndex = 11;
      this.txtNominal.Tag = (object) " ";
      this.Label7.Location = new System.Drawing.Point(8, 196);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(103, 20);
      this.Label7.TabIndex = 10;
      this.Label7.Text = "Nominal Code";
      this.chkJobPriorityRequired.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.chkJobPriorityRequired.AutoSize = true;
      this.chkJobPriorityRequired.Location = new System.Drawing.Point(473, 442);
      this.chkJobPriorityRequired.Name = "chkJobPriorityRequired";
      this.chkJobPriorityRequired.RightToLeft = RightToLeft.Yes;
      this.chkJobPriorityRequired.Size = new Size(145, 17);
      this.chkJobPriorityRequired.TabIndex = 17;
      this.chkJobPriorityRequired.Text = "Job Priority Required";
      this.chkJobPriorityRequired.UseVisualStyleBackColor = true;
      this.chkPONumReq.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.chkPONumReq.AutoSize = true;
      this.chkPONumReq.Location = new System.Drawing.Point(472, 420);
      this.chkPONumReq.Name = "chkPONumReq";
      this.chkPONumReq.RightToLeft = RightToLeft.Yes;
      this.chkPONumReq.Size = new Size(146, 17);
      this.chkPONumReq.TabIndex = 16;
      this.chkPONumReq.Text = "PO Number Required";
      this.chkPONumReq.UseVisualStyleBackColor = true;
      this.btnSelectLogoImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSelectLogoImage.Location = new System.Drawing.Point(263, 416);
      this.btnSelectLogoImage.Name = "btnSelectLogoImage";
      this.btnSelectLogoImage.Size = new Size(31, 23);
      this.btnSelectLogoImage.TabIndex = 15;
      this.btnSelectLogoImage.Text = "...";
      this.btnSelectLogoImage.UseVisualStyleBackColor = true;
      this.picLogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.picLogo.BackColor = Color.White;
      this.picLogo.BorderStyle = BorderStyle.FixedSingle;
      this.picLogo.Location = new System.Drawing.Point(120, 417);
      this.picLogo.Name = "picLogo";
      this.picLogo.Size = new Size(135, 135);
      this.picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picLogo.TabIndex = 44;
      this.picLogo.TabStop = false;
      this.Label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label6.Location = new System.Drawing.Point(8, 423);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(62, 20);
      this.Label6.TabIndex = 14;
      this.Label6.Text = "Logo";
      this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboType.Cursor = Cursors.Hand;
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(120, 57);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(498, 21);
      this.cboType.TabIndex = 3;
      this.cboType.Tag = (object) "Customer.TypeID";
      this.Label2.Location = new System.Drawing.Point(8, 60);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(66, 23);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Type";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(120, 23);
      this.txtName.MaxLength = (int) byte.MaxValue;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(498, 21);
      this.txtName.TabIndex = 1;
      this.txtName.Tag = (object) "Customer.Name";
      this.lblName.Location = new System.Drawing.Point(8, 26);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(53, 20);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Name";
      this.cboRegionID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboRegionID.Cursor = Cursors.Hand;
      this.cboRegionID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegionID.Location = new System.Drawing.Point(120, 91);
      this.cboRegionID.Name = "cboRegionID";
      this.cboRegionID.Size = new Size(498, 21);
      this.cboRegionID.TabIndex = 5;
      this.cboRegionID.Tag = (object) "Customer.RegionID";
      this.lblRegionID.Location = new System.Drawing.Point(8, 94);
      this.lblRegionID.Name = "lblRegionID";
      this.lblRegionID.Size = new Size(55, 20);
      this.lblRegionID.TabIndex = 4;
      this.lblRegionID.Text = "Region ";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(120, 295);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Vertical;
      this.txtNotes.Size = new Size(497, 50);
      this.txtNotes.TabIndex = 13;
      this.txtNotes.Tag = (object) "Customer.Notes";
      this.lblNotes.Location = new System.Drawing.Point(8, 298);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(62, 20);
      this.lblNotes.TabIndex = 12;
      this.lblNotes.Text = "Notes";
      this.txtAccountNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAccountNumber.Location = new System.Drawing.Point(120, 125);
      this.txtAccountNumber.MaxLength = 50;
      this.txtAccountNumber.Name = "txtAccountNumber";
      this.txtAccountNumber.Size = new Size(498, 21);
      this.txtAccountNumber.TabIndex = 7;
      this.txtAccountNumber.Tag = (object) "Customer.AccountNumber";
      this.lblAccountNumber.Location = new System.Drawing.Point(8, 128);
      this.lblAccountNumber.Name = "lblAccountNumber";
      this.lblAccountNumber.Size = new Size(103, 20);
      this.lblAccountNumber.TabIndex = 6;
      this.lblAccountNumber.Text = "Account Number";
      this.cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboStatus.Cursor = Cursors.Hand;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Location = new System.Drawing.Point(120, 159);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(498, 21);
      this.cboStatus.TabIndex = 9;
      this.cboStatus.Tag = (object) "Customer.Status";
      this.lblStatus.Location = new System.Drawing.Point(8, 162);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new Size(65, 20);
      this.lblStatus.TabIndex = 8;
      this.lblStatus.Text = "Status";
      this.TabControl1.Controls.Add((Control) this.tabMainDetails);
      this.TabControl1.Controls.Add((Control) this.tabContracts);
      this.TabControl1.Controls.Add((Control) this.tabCharges);
      this.TabControl1.Controls.Add((Control) this.tabDocuments);
      this.TabControl1.Controls.Add((Control) this.tabQuotes);
      this.TabControl1.Controls.Add((Control) this.tabPriority);
      this.TabControl1.Controls.Add((Control) this.tabParts);
      this.TabControl1.Controls.Add((Control) this.tabServiceDates);
      this.TabControl1.Controls.Add((Control) this.tabCreation);
      this.TabControl1.Controls.Add((Control) this.tabAuthority);
      this.TabControl1.Controls.Add((Control) this.tabAlerts);
      this.TabControl1.Dock = DockStyle.Fill;
      this.TabControl1.Location = new System.Drawing.Point(0, 0);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(653, 600);
      this.TabControl1.TabIndex = 0;
      this.tabMainDetails.Controls.Add((Control) this.grpCustomer);
      this.tabMainDetails.Location = new System.Drawing.Point(4, 22);
      this.tabMainDetails.Name = "tabMainDetails";
      this.tabMainDetails.Size = new Size(645, 574);
      this.tabMainDetails.TabIndex = 0;
      this.tabMainDetails.Text = "Main Details";
      this.tabContracts.Controls.Add((Control) this.pnlContracts);
      this.tabContracts.Location = new System.Drawing.Point(4, 22);
      this.tabContracts.Name = "tabContracts";
      this.tabContracts.Size = new Size(645, 574);
      this.tabContracts.TabIndex = 4;
      this.tabContracts.Text = "Contracts";
      this.pnlContracts.Controls.Add((Control) this.gpbContracts);
      this.pnlContracts.Dock = DockStyle.Fill;
      this.pnlContracts.Location = new System.Drawing.Point(0, 0);
      this.pnlContracts.Name = "pnlContracts";
      this.pnlContracts.Size = new Size(645, 574);
      this.pnlContracts.TabIndex = 1;
      this.gpbContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbContracts.Controls.Add((Control) this.btnDeleteContract);
      this.gpbContracts.Controls.Add((Control) this.dgContracts);
      this.gpbContracts.Controls.Add((Control) this.btnAddContract);
      this.gpbContracts.Location = new System.Drawing.Point(8, 8);
      this.gpbContracts.Name = "gpbContracts";
      this.gpbContracts.Size = new Size(632, 555);
      this.gpbContracts.TabIndex = 0;
      this.gpbContracts.TabStop = false;
      this.gpbContracts.Text = "Contract - Double click to view";
      this.btnDeleteContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeleteContract.Location = new System.Drawing.Point(549, 523);
      this.btnDeleteContract.Name = "btnDeleteContract";
      this.btnDeleteContract.Size = new Size(75, 23);
      this.btnDeleteContract.TabIndex = 2;
      this.btnDeleteContract.Text = "Delete";
      this.dgContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgContracts.DataMember = "";
      this.dgContracts.HeaderForeColor = SystemColors.ControlText;
      this.dgContracts.Location = new System.Drawing.Point(8, 16);
      this.dgContracts.Name = "dgContracts";
      this.dgContracts.Size = new Size(616, 499);
      this.dgContracts.TabIndex = 1;
      this.btnAddContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddContract.Location = new System.Drawing.Point(8, 523);
      this.btnAddContract.Name = "btnAddContract";
      this.btnAddContract.Size = new Size(75, 23);
      this.btnAddContract.TabIndex = 0;
      this.btnAddContract.Text = "Add";
      this.btnAddContract.UseVisualStyleBackColor = true;
      this.tabCharges.Controls.Add((Control) this.grbCharges);
      this.tabCharges.Location = new System.Drawing.Point(4, 22);
      this.tabCharges.Name = "tabCharges";
      this.tabCharges.Size = new Size(645, 574);
      this.tabCharges.TabIndex = 7;
      this.tabCharges.Text = "Charges";
      this.grbCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grbCharges.Controls.Add((Control) this.txtSpendLimit);
      this.grbCharges.Controls.Add((Control) this.lblJobSpendLimit);
      this.grbCharges.Controls.Add((Control) this.txtMainContractorDiscount);
      this.grbCharges.Controls.Add((Control) this.Label5);
      this.grbCharges.Controls.Add((Control) this.chbAcceptChargeChanges);
      this.grbCharges.Controls.Add((Control) this.Label3);
      this.grbCharges.Controls.Add((Control) this.txtRatesMarkup);
      this.grbCharges.Controls.Add((Control) this.Label4);
      this.grbCharges.Controls.Add((Control) this.Label1);
      this.grbCharges.Controls.Add((Control) this.txtMileageRate);
      this.grbCharges.Controls.Add((Control) this.txtPartsMarkup);
      this.grbCharges.Controls.Add((Control) this.pnlCharges);
      this.grbCharges.Location = new System.Drawing.Point(8, 0);
      this.grbCharges.Name = "grbCharges";
      this.grbCharges.Size = new Size(633, 571);
      this.grbCharges.TabIndex = 0;
      this.grbCharges.TabStop = false;
      this.grbCharges.Text = "Charges";
      this.txtSpendLimit.Location = new System.Drawing.Point(122, 70);
      this.txtSpendLimit.Name = "txtSpendLimit";
      this.txtSpendLimit.Size = new Size(64, 21);
      this.txtSpendLimit.TabIndex = 78;
      this.lblJobSpendLimit.AutoSize = true;
      this.lblJobSpendLimit.Location = new System.Drawing.Point(8, 73);
      this.lblJobSpendLimit.Name = "lblJobSpendLimit";
      this.lblJobSpendLimit.Size = new Size(108, 13);
      this.lblJobSpendLimit.TabIndex = 77;
      this.lblJobSpendLimit.Text = "Job Spend Limit £";
      this.txtMainContractorDiscount.Location = new System.Drawing.Point(461, 72);
      this.txtMainContractorDiscount.Name = "txtMainContractorDiscount";
      this.txtMainContractorDiscount.Size = new Size(64, 21);
      this.txtMainContractorDiscount.TabIndex = 8;
      this.Label5.Location = new System.Drawing.Point(278, 73);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(176, 21);
      this.Label5.TabIndex = 7;
      this.Label5.Text = "Main Contractor Discount %";
      this.chbAcceptChargeChanges.BackColor = SystemColors.Info;
      this.chbAcceptChargeChanges.Location = new System.Drawing.Point(8, 16);
      this.chbAcceptChargeChanges.Name = "chbAcceptChargeChanges";
      this.chbAcceptChargeChanges.Size = new Size(480, 24);
      this.chbAcceptChargeChanges.TabIndex = 0;
      this.chbAcceptChargeChanges.Text = "Always accept changes to default charges made at system level";
      this.chbAcceptChargeChanges.UseVisualStyleBackColor = false;
      this.Label3.Location = new System.Drawing.Point(368, 48);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(93, 21);
      this.Label3.TabIndex = 5;
      this.Label3.Text = "Rates Markup";
      this.txtRatesMarkup.Location = new System.Drawing.Point(461, 48);
      this.txtRatesMarkup.Name = "txtRatesMarkup";
      this.txtRatesMarkup.Size = new Size(64, 21);
      this.txtRatesMarkup.TabIndex = 6;
      this.Label4.Location = new System.Drawing.Point(8, 48);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(97, 21);
      this.Label4.TabIndex = 1;
      this.Label4.Text = "Labour Markup";
      this.Label1.Location = new System.Drawing.Point(210, 48);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(90, 21);
      this.Label1.TabIndex = 3;
      this.Label1.Text = "Parts Markup";
      this.txtMileageRate.Location = new System.Drawing.Point(122, 48);
      this.txtMileageRate.Name = "txtMileageRate";
      this.txtMileageRate.Size = new Size(64, 21);
      this.txtMileageRate.TabIndex = 2;
      this.txtPartsMarkup.Location = new System.Drawing.Point(301, 48);
      this.txtPartsMarkup.Name = "txtPartsMarkup";
      this.txtPartsMarkup.Size = new Size(62, 21);
      this.txtPartsMarkup.TabIndex = 4;
      this.pnlCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlCharges.Location = new System.Drawing.Point(8, 97);
      this.pnlCharges.Name = "pnlCharges";
      this.pnlCharges.Size = new Size(617, 466);
      this.pnlCharges.TabIndex = 9;
      this.tabDocuments.Controls.Add((Control) this.pnlDocuments);
      this.tabDocuments.Location = new System.Drawing.Point(4, 22);
      this.tabDocuments.Name = "tabDocuments";
      this.tabDocuments.Size = new Size(645, 574);
      this.tabDocuments.TabIndex = 2;
      this.tabDocuments.Text = "Documents";
      this.pnlDocuments.Dock = DockStyle.Fill;
      this.pnlDocuments.Location = new System.Drawing.Point(0, 0);
      this.pnlDocuments.Name = "pnlDocuments";
      this.pnlDocuments.Size = new Size(645, 574);
      this.pnlDocuments.TabIndex = 1;
      this.tabQuotes.Controls.Add((Control) this.pnlQuotes);
      this.tabQuotes.Location = new System.Drawing.Point(4, 22);
      this.tabQuotes.Name = "tabQuotes";
      this.tabQuotes.Size = new Size(645, 574);
      this.tabQuotes.TabIndex = 5;
      this.tabQuotes.Text = "Quotes";
      this.pnlQuotes.Dock = DockStyle.Fill;
      this.pnlQuotes.Location = new System.Drawing.Point(0, 0);
      this.pnlQuotes.Name = "pnlQuotes";
      this.pnlQuotes.Size = new Size(645, 574);
      this.pnlQuotes.TabIndex = 1;
      this.tabPriority.Controls.Add((Control) this.dgvPriority);
      this.tabPriority.Controls.Add((Control) this.Label11);
      this.tabPriority.Controls.Add((Control) this.dgRequirements);
      this.tabPriority.Controls.Add((Control) this.Label10);
      this.tabPriority.Location = new System.Drawing.Point(4, 22);
      this.tabPriority.Name = "tabPriority";
      this.tabPriority.Size = new Size(645, 574);
      this.tabPriority.TabIndex = 8;
      this.tabPriority.Text = "Priorities / Requirements";
      this.tabPriority.UseVisualStyleBackColor = true;
      this.dgvPriority.AllowUserToAddRows = false;
      this.dgvPriority.AllowUserToDeleteRows = false;
      this.dgvPriority.AllowUserToResizeColumns = false;
      this.dgvPriority.AllowUserToResizeRows = false;
      this.dgvPriority.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPriority.Location = new System.Drawing.Point(37, 70);
      this.dgvPriority.MultiSelect = false;
      this.dgvPriority.Name = "dgvPriority";
      this.dgvPriority.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvPriority.Size = new Size(456, 170);
      this.dgvPriority.TabIndex = 10;
      this.Label11.Location = new System.Drawing.Point(34, 294);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(103, 20);
      this.Label11.TabIndex = 9;
      this.Label11.Text = "Requirements";
      this.dgRequirements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgRequirements.DataMember = "";
      this.dgRequirements.HeaderForeColor = SystemColors.ControlText;
      this.dgRequirements.Location = new System.Drawing.Point(37, 317);
      this.dgRequirements.Name = "dgRequirements";
      this.dgRequirements.Size = new Size(592, 196);
      this.dgRequirements.TabIndex = 8;
      this.Label10.Location = new System.Drawing.Point(34, 47);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(103, 20);
      this.Label10.TabIndex = 7;
      this.Label10.Text = "Priorities";
      this.tabParts.Controls.Add((Control) this.Label14);
      this.tabParts.Controls.Add((Control) this.txtPartSearch);
      this.tabParts.Controls.Add((Control) this.btnDelete);
      this.tabParts.Controls.Add((Control) this.btnAdd);
      this.tabParts.Controls.Add((Control) this.dgvParts);
      this.tabParts.Location = new System.Drawing.Point(4, 22);
      this.tabParts.Name = "tabParts";
      this.tabParts.Size = new Size(645, 574);
      this.tabParts.TabIndex = 9;
      this.tabParts.Text = "Associated Supplier Parts";
      this.tabParts.UseVisualStyleBackColor = true;
      this.Label14.AutoSize = true;
      this.Label14.Location = new System.Drawing.Point(3, 34);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(47, 13);
      this.Label14.TabIndex = 4;
      this.Label14.Text = "Search";
      this.txtPartSearch.Location = new System.Drawing.Point(82, 31);
      this.txtPartSearch.Name = "txtPartSearch";
      this.txtPartSearch.Size = new Size(560, 21);
      this.txtPartSearch.TabIndex = 3;
      this.btnDelete.Location = new System.Drawing.Point(58, 408);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(61, 23);
      this.btnDelete.TabIndex = 2;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnAdd.Location = new System.Drawing.Point(532, 406);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(65, 25);
      this.btnAdd.TabIndex = 1;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.dgvParts.AllowUserToAddRows = false;
      this.dgvParts.AllowUserToDeleteRows = false;
      this.dgvParts.AllowUserToOrderColumns = true;
      this.dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvParts.Location = new System.Drawing.Point(3, 62);
      this.dgvParts.Name = "dgvParts";
      this.dgvParts.ReadOnly = true;
      this.dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvParts.ShowCellErrors = false;
      this.dgvParts.Size = new Size(639, 340);
      this.dgvParts.TabIndex = 0;
      this.tabServiceDates.BackColor = SystemColors.Control;
      this.tabServiceDates.Controls.Add((Control) this.pnlServiceProcess);
      this.tabServiceDates.Location = new System.Drawing.Point(4, 22);
      this.tabServiceDates.Name = "tabServiceDates";
      this.tabServiceDates.Size = new Size(645, 574);
      this.tabServiceDates.TabIndex = 10;
      this.tabServiceDates.Text = "Service Dates";
      this.tabCreation.Controls.Add((Control) this.btnEngDelete);
      this.tabCreation.Controls.Add((Control) this.btnEngAdd);
      this.tabCreation.Controls.Add((Control) this.dgRaiseEng);
      this.tabCreation.Location = new System.Drawing.Point(4, 22);
      this.tabCreation.Name = "tabCreation";
      this.tabCreation.Size = new Size(645, 574);
      this.tabCreation.TabIndex = 10;
      this.tabCreation.Text = "Engineer Job Creation";
      this.tabCreation.UseVisualStyleBackColor = true;
      this.btnEngDelete.Location = new System.Drawing.Point(58, 429);
      this.btnEngDelete.Name = "btnEngDelete";
      this.btnEngDelete.Size = new Size(61, 23);
      this.btnEngDelete.TabIndex = 5;
      this.btnEngDelete.Text = "Delete";
      this.btnEngDelete.UseVisualStyleBackColor = true;
      this.btnEngAdd.Location = new System.Drawing.Point(384, 429);
      this.btnEngAdd.Name = "btnEngAdd";
      this.btnEngAdd.Size = new Size(65, 25);
      this.btnEngAdd.TabIndex = 4;
      this.btnEngAdd.Text = "Add";
      this.btnEngAdd.UseVisualStyleBackColor = true;
      this.dgRaiseEng.AllowUserToAddRows = false;
      this.dgRaiseEng.AllowUserToDeleteRows = false;
      this.dgRaiseEng.AllowUserToOrderColumns = true;
      this.dgRaiseEng.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgRaiseEng.Location = new System.Drawing.Point(3, 83);
      this.dgRaiseEng.Name = "dgRaiseEng";
      this.dgRaiseEng.ReadOnly = true;
      this.dgRaiseEng.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgRaiseEng.ShowCellErrors = false;
      this.dgRaiseEng.Size = new Size(503, 340);
      this.dgRaiseEng.TabIndex = 3;
      this.tabAuthority.Controls.Add((Control) this.grpAudit);
      this.tabAuthority.Controls.Add((Control) this.gpCustAuth);
      this.tabAuthority.Location = new System.Drawing.Point(4, 22);
      this.tabAuthority.Name = "tabAuthority";
      this.tabAuthority.Size = new Size(645, 574);
      this.tabAuthority.TabIndex = 11;
      this.tabAuthority.Text = "Authority";
      this.tabAuthority.UseVisualStyleBackColor = true;
      this.grpAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAudit.Controls.Add((Control) this.dgAuthorityAudit);
      this.grpAudit.Location = new System.Drawing.Point(3, 236);
      this.grpAudit.Name = "grpAudit";
      this.grpAudit.Size = new Size(639, 335);
      this.grpAudit.TabIndex = 38;
      this.grpAudit.TabStop = false;
      this.grpAudit.Text = "Audit";
      this.dgAuthorityAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAuthorityAudit.DataMember = "";
      this.dgAuthorityAudit.HeaderForeColor = SystemColors.ControlText;
      this.dgAuthorityAudit.Location = new System.Drawing.Point(6, 20);
      this.dgAuthorityAudit.Name = "dgAuthorityAudit";
      this.dgAuthorityAudit.Size = new Size(627, 309);
      this.dgAuthorityAudit.TabIndex = 1;
      this.gpCustAuth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpCustAuth.Controls.Add((Control) this.btnSaveAuth);
      this.gpCustAuth.Controls.Add((Control) this.txtCustAuthority);
      this.gpCustAuth.Location = new System.Drawing.Point(3, 3);
      this.gpCustAuth.Name = "gpCustAuth";
      this.gpCustAuth.Size = new Size(639, 227);
      this.gpCustAuth.TabIndex = 37;
      this.gpCustAuth.TabStop = false;
      this.gpCustAuth.Text = "Customer";
      this.btnSaveAuth.AccessibleDescription = "";
      this.btnSaveAuth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveAuth.Location = new System.Drawing.Point(548, 191);
      this.btnSaveAuth.Name = "btnSaveAuth";
      this.btnSaveAuth.Size = new Size(85, 23);
      this.btnSaveAuth.TabIndex = 4;
      this.btnSaveAuth.Text = "Save";
      this.txtCustAuthority.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustAuthority.Location = new System.Drawing.Point(6, 20);
      this.txtCustAuthority.Multiline = true;
      this.txtCustAuthority.Name = "txtCustAuthority";
      this.txtCustAuthority.ScrollBars = ScrollBars.Both;
      this.txtCustAuthority.Size = new Size(627, 156);
      this.txtCustAuthority.TabIndex = 0;
      this.tabAlerts.Controls.Add((Control) this.grpCustomerAlerts);
      this.tabAlerts.Location = new System.Drawing.Point(4, 22);
      this.tabAlerts.Name = "tabAlerts";
      this.tabAlerts.Size = new Size(645, 574);
      this.tabAlerts.TabIndex = 12;
      this.tabAlerts.Text = "Alerts";
      this.tabAlerts.UseVisualStyleBackColor = true;
      this.grpCustomerAlerts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCustomerAlerts.Controls.Add((Control) this.grpSite);
      this.grpCustomerAlerts.Controls.Add((Control) this.dgCustomerAlerts);
      this.grpCustomerAlerts.Location = new System.Drawing.Point(13, 14);
      this.grpCustomerAlerts.Margin = new Padding(0);
      this.grpCustomerAlerts.Name = "grpCustomerAlerts";
      this.grpCustomerAlerts.Padding = new Padding(0);
      this.grpCustomerAlerts.Size = new Size(620, 547);
      this.grpCustomerAlerts.TabIndex = 15;
      this.grpCustomerAlerts.TabStop = false;
      this.grpCustomerAlerts.Text = "Alerts";
      this.grpSite.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSite.Controls.Add((Control) this.btnAddCustomerAlert);
      this.grpSite.Controls.Add((Control) this.btnDeleteCustomerAlert);
      this.grpSite.Controls.Add((Control) this.txtCustomerAlertEmailAddress);
      this.grpSite.Controls.Add((Control) this.lblEmailAddressMsg);
      this.grpSite.Controls.Add((Control) this.btnSaveCustomerAlert);
      this.grpSite.Controls.Add((Control) this.cboAlertType);
      this.grpSite.Controls.Add((Control) this.lblCustomerAlertEmailAddress);
      this.grpSite.Controls.Add((Control) this.lblAlertType);
      this.grpSite.Location = new System.Drawing.Point(14, 287);
      this.grpSite.Name = "grpSite";
      this.grpSite.Size = new Size(592, 248);
      this.grpSite.TabIndex = 115;
      this.grpSite.TabStop = false;
      this.grpSite.Text = "Alert";
      this.btnAddCustomerAlert.AccessibleDescription = "";
      this.btnAddCustomerAlert.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddCustomerAlert.Location = new System.Drawing.Point(555, 18);
      this.btnAddCustomerAlert.Name = "btnAddCustomerAlert";
      this.btnAddCustomerAlert.Size = new Size(31, 28);
      this.btnAddCustomerAlert.TabIndex = 131;
      this.btnAddCustomerAlert.Text = "+";
      this.tt.SetToolTip((Control) this.btnAddCustomerAlert, "Add new alert");
      this.btnDeleteCustomerAlert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnDeleteCustomerAlert.Location = new System.Drawing.Point(9, 210);
      this.btnDeleteCustomerAlert.Name = "btnDeleteCustomerAlert";
      this.btnDeleteCustomerAlert.Size = new Size(81, 23);
      this.btnDeleteCustomerAlert.TabIndex = 130;
      this.btnDeleteCustomerAlert.Text = "Delete";
      this.btnDeleteCustomerAlert.Visible = false;
      this.txtCustomerAlertEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomerAlertEmailAddress.Location = new System.Drawing.Point(9, 131);
      this.txtCustomerAlertEmailAddress.Multiline = true;
      this.txtCustomerAlertEmailAddress.Name = "txtCustomerAlertEmailAddress";
      this.txtCustomerAlertEmailAddress.ScrollBars = ScrollBars.Vertical;
      this.txtCustomerAlertEmailAddress.Size = new Size(577, 62);
      this.txtCustomerAlertEmailAddress.TabIndex = 129;
      this.txtCustomerAlertEmailAddress.Tag = (object) "Customer.Notes";
      this.lblEmailAddressMsg.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblEmailAddressMsg.Location = new System.Drawing.Point(6, 63);
      this.lblEmailAddressMsg.Name = "lblEmailAddressMsg";
      this.lblEmailAddressMsg.Size = new Size(566, 29);
      this.lblEmailAddressMsg.TabIndex = 128;
      this.lblEmailAddressMsg.Text = "Please seperate each email address with a semi-colon;";
      this.btnSaveCustomerAlert.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveCustomerAlert.Location = new System.Drawing.Point(505, 210);
      this.btnSaveCustomerAlert.Name = "btnSaveCustomerAlert";
      this.btnSaveCustomerAlert.Size = new Size(81, 23);
      this.btnSaveCustomerAlert.TabIndex = (int) sbyte.MaxValue;
      this.btnSaveCustomerAlert.Text = "Save";
      this.cboAlertType.Cursor = Cursors.Hand;
      this.cboAlertType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAlertType.Location = new System.Drawing.Point(117, 20);
      this.cboAlertType.Name = "cboAlertType";
      this.cboAlertType.Size = new Size(161, 21);
      this.cboAlertType.TabIndex = 126;
      this.cboAlertType.Tag = (object) "";
      this.lblCustomerAlertEmailAddress.Location = new System.Drawing.Point(6, 105);
      this.lblCustomerAlertEmailAddress.Name = "lblCustomerAlertEmailAddress";
      this.lblCustomerAlertEmailAddress.Size = new Size(112, 23);
      this.lblCustomerAlertEmailAddress.TabIndex = 125;
      this.lblCustomerAlertEmailAddress.Text = "Email Address(s):";
      this.lblAlertType.Location = new System.Drawing.Point(6, 23);
      this.lblAlertType.Name = "lblAlertType";
      this.lblAlertType.Size = new Size(80, 23);
      this.lblAlertType.TabIndex = 123;
      this.lblAlertType.Text = "Alert Type:";
      this.dgCustomerAlerts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgCustomerAlerts.DataMember = "";
      this.dgCustomerAlerts.HeaderForeColor = SystemColors.ControlText;
      this.dgCustomerAlerts.Location = new System.Drawing.Point(14, 19);
      this.dgCustomerAlerts.Name = "dgCustomerAlerts";
      this.dgCustomerAlerts.Size = new Size(592, 262);
      this.dgCustomerAlerts.TabIndex = 11;
      this.cmnuContractOptions.MenuItems.AddRange(new MenuItem[1]
      {
        this.mnuContractOpt1
      });
      this.mnuContractOpt1.Index = 0;
      this.mnuContractOpt1.Text = "Contract Opt. 1";
      this.pnlServiceProcess.Dock = DockStyle.Fill;
      this.pnlServiceProcess.Location = new System.Drawing.Point(0, 0);
      this.pnlServiceProcess.Name = "pnlServiceProcess";
      this.pnlServiceProcess.Size = new Size(645, 574);
      this.pnlServiceProcess.TabIndex = 2;
      this.Controls.Add((Control) this.TabControl1);
      this.Name = nameof (UCCustomer);
      this.Size = new Size(653, 600);
      this.grpCustomer.ResumeLayout(false);
      this.grpCustomer.PerformLayout();
      ((ISupportInitialize) this.picLogo).EndInit();
      this.TabControl1.ResumeLayout(false);
      this.tabMainDetails.ResumeLayout(false);
      this.tabContracts.ResumeLayout(false);
      this.pnlContracts.ResumeLayout(false);
      this.gpbContracts.ResumeLayout(false);
      this.dgContracts.EndInit();
      this.tabCharges.ResumeLayout(false);
      this.grbCharges.ResumeLayout(false);
      this.grbCharges.PerformLayout();
      this.tabDocuments.ResumeLayout(false);
      this.tabQuotes.ResumeLayout(false);
      this.tabPriority.ResumeLayout(false);
      ((ISupportInitialize) this.dgvPriority).EndInit();
      this.dgRequirements.EndInit();
      this.tabParts.ResumeLayout(false);
      this.tabParts.PerformLayout();
      ((ISupportInitialize) this.dgvParts).EndInit();
      this.tabServiceDates.ResumeLayout(false);
      this.tabCreation.ResumeLayout(false);
      ((ISupportInitialize) this.dgRaiseEng).EndInit();
      this.tabAuthority.ResumeLayout(false);
      this.grpAudit.ResumeLayout(false);
      this.dgAuthorityAudit.EndInit();
      this.gpCustAuth.ResumeLayout(false);
      this.gpCustAuth.PerformLayout();
      this.tabAlerts.ResumeLayout(false);
      this.grpCustomerAlerts.ResumeLayout(false);
      this.grpSite.ResumeLayout(false);
      this.grpSite.PerformLayout();
      this.dgCustomerAlerts.EndInit();
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
        return (object) this.CurrentCustomer;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public FSM.Entity.Customers.Customer CurrentCustomer
    {
      get
      {
        return this._currentCustomer;
      }
      set
      {
        this._currentCustomer = value;
        if (App.IsRFT)
        {
          this.TabControl1.TabPages.Remove(this.tabParts);
          this.TabControl1.TabPages.Remove(this.tabQuotes);
        }
        if (this._currentCustomer == null)
        {
          this._currentCustomer = new FSM.Entity.Customers.Customer();
          this._currentCustomer.Exists = false;
          this.chbAcceptChargeChanges.Checked = true;
        }
        if (this._currentCustomer.Exists)
        {
          this.Populate(0);
          this.pnlDocuments.Controls.Clear();
          this.DocumentsControl = new UCDocumentsList(Enums.TableNames.tblCustomer, this._currentCustomer.CustomerID);
          this.pnlDocuments.Controls.Add((Control) this.DocumentsControl);
          this.Contracts = App.DB.Customer.Customer_Contracts_GetAll(this._currentCustomer.CustomerID);
          this.gpbContracts.Enabled = true;
          this.pnlQuotes.Controls.Clear();
          this.QuotesControl = new UCQuotesList(Enums.TableNames.tblCustomer, this._currentCustomer.CustomerID, 0);
          this.QuotesControl.RefreshContracts += new UCQuotesList.RefreshContractsEventHandler(this.RefreshContractList);
          this.pnlQuotes.Controls.Add((Control) this.QuotesControl);
          this.pnlCharges.Controls.Clear();
          this.CustomerScheduleOfRateControl = new UCCustomerScheduleOfRate(Enums.TableNames.tblCustomer, this._currentCustomer.CustomerID, false);
          this.pnlCharges.Controls.Add((Control) this.CustomerScheduleOfRateControl);
          this.pnlServiceProcess.Controls.Clear();
          this.UcServiceProcess = new UCCustomerServiceProcess(this._currentCustomer.CustomerID);
          this.pnlServiceProcess.Controls.Add((Control) this.UcServiceProcess);
        }
        else
          this.gpbContracts.Enabled = false;
      }
    }

    public DataView Data
    {
      get
      {
        return this._Data;
      }
      set
      {
        this._Data = value;
        this._Data.AllowNew = false;
        this._Data.AllowEdit = true;
        this._Data.AllowDelete = false;
        this.dgvPriority.AutoGenerateColumns = false;
        this.dgvPriority.EditMode = DataGridViewEditMode.EditOnEnter;
        this.dgvPriority.DataSource = (object) this.Data;
      }
    }

    public FSM.Entity.Authority.Authority CustomerAuthority
    {
      get
      {
        return this._oCustomerAuthority;
      }
      set
      {
        this._oCustomerAuthority = value;
      }
    }

    public DataView PartsDataView
    {
      get
      {
        return this._PartsDataView;
      }
      set
      {
        this._PartsDataView = value;
        this._PartsDataView.Table.TableName = Enums.TableNames.tblWarehouse.ToString();
        this._PartsDataView.AllowNew = false;
        this._PartsDataView.AllowEdit = false;
        this._PartsDataView.AllowDelete = false;
        this.dgvParts.DataSource = (object) this.PartsDataView;
      }
    }

    public DataView EngRaiseView
    {
      get
      {
        return this._EngRaiseView;
      }
      set
      {
        this._EngRaiseView = value;
        this._EngRaiseView.Table.TableName = Enums.TableNames.tblWarehouse.ToString();
        this._EngRaiseView.AllowNew = false;
        this._EngRaiseView.AllowEdit = false;
        this._EngRaiseView.AllowDelete = false;
        this.dgRaiseEng.DataSource = (object) this.EngRaiseView;
      }
    }

    public DataView RequirementDataView
    {
      get
      {
        return this._RequirementDataView;
      }
      set
      {
        this._RequirementDataView = value;
        this._RequirementDataView.Table.TableName = Enums.TableNames.tblWarehouse.ToString();
        this._RequirementDataView.AllowNew = false;
        this._RequirementDataView.AllowEdit = false;
        this._RequirementDataView.AllowDelete = false;
        this.dgRequirements.DataSource = (object) this.RequirementDataView;
      }
    }

    private DataRow SelectedRequirmentDataRow
    {
      get
      {
        return this.dgRequirements.CurrentRowIndex != -1 ? this.RequirementDataView[this.dgRequirements.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView Contracts
    {
      get
      {
        return this._dvContracts;
      }
      set
      {
        this._dvContracts = value;
        this._dvContracts.Table.TableName = Enums.TableNames.tblContract.ToString();
        this._dvContracts.AllowNew = false;
        this._dvContracts.AllowEdit = false;
        this._dvContracts.AllowDelete = false;
        this.dgContracts.DataSource = (object) this.Contracts;
      }
    }

    private DataRow SelectedContractDataRow
    {
      get
      {
        return this.dgContracts.CurrentRowIndex != -1 ? this.Contracts[this.dgContracts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDG()
    {
      Helper.SetUpDataGridView(this.dgvParts, false);
      this.dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvParts.AutoGenerateColumns = false;
      this.dgvParts.Columns.Clear();
      this.dgvParts.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "";
      viewTextBoxColumn1.DataPropertyName = "PartSupplierID";
      viewTextBoxColumn1.FillWeight = 1f;
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      viewTextBoxColumn1.Visible = true;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 120f;
      viewTextBoxColumn2.HeaderText = "Part Name";
      viewTextBoxColumn2.DataPropertyName = "PartName";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Part Number";
      viewTextBoxColumn3.DataPropertyName = "PartNumber";
      viewTextBoxColumn3.FillWeight = 50f;
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "SPN";
      viewTextBoxColumn4.DataPropertyName = "PartCode";
      viewTextBoxColumn4.FillWeight = 40f;
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Supplier Name";
      viewTextBoxColumn5.DataPropertyName = "SupplierName";
      viewTextBoxColumn5.FillWeight = 55f;
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      viewTextBoxColumn5.Visible = true;
      this.dgvParts.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      this.dgvParts.Sort((DataGridViewColumn) viewTextBoxColumn5, ListSortDirection.Descending);
    }

    public void SetupPrioritiesDGV()
    {
      DataGridViewCheckBoxColumn viewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn1.FillWeight = 5f;
      viewCheckBoxColumn1.HeaderText = "Tick";
      viewCheckBoxColumn1.DataPropertyName = "Tick";
      viewCheckBoxColumn1.Name = "Tick";
      viewCheckBoxColumn1.ReadOnly = false;
      viewCheckBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPriority.Columns.Add((DataGridViewColumn) viewCheckBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "ManagerID";
      viewTextBoxColumn1.DataPropertyName = "ManagerID";
      viewTextBoxColumn1.Name = "ManagerID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPriority.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Name";
      viewTextBoxColumn2.DataPropertyName = "Name";
      viewTextBoxColumn2.FillWeight = 20f;
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPriority.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "TargetHours";
      viewTextBoxColumn3.FillWeight = 15f;
      viewTextBoxColumn3.DataPropertyName = "TargetHours";
      viewTextBoxColumn3.Name = "TargetHours";
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPriority.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewCheckBoxColumn viewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn2.FillWeight = 5f;
      viewCheckBoxColumn2.HeaderText = "Include OOH";
      viewCheckBoxColumn2.DataPropertyName = "IncludeOOH";
      viewCheckBoxColumn2.Name = "IncludeOOH";
      viewCheckBoxColumn2.ReadOnly = false;
      viewCheckBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPriority.Columns.Add((DataGridViewColumn) viewCheckBoxColumn2);
      DataGridViewCheckBoxColumn viewCheckBoxColumn3 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn3.FillWeight = 5f;
      viewCheckBoxColumn3.HeaderText = "Include Weekends";
      viewCheckBoxColumn3.DataPropertyName = "IncludeWeekends";
      viewCheckBoxColumn3.Name = "IncludeWeekends";
      viewCheckBoxColumn3.ReadOnly = false;
      viewCheckBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPriority.Columns.Add((DataGridViewColumn) viewCheckBoxColumn3);
      DataGridViewCheckBoxColumn viewCheckBoxColumn4 = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn4.FillWeight = 5f;
      viewCheckBoxColumn4.HeaderText = "Include Bank Holidays";
      viewCheckBoxColumn4.DataPropertyName = "IncludeBH";
      viewCheckBoxColumn4.Name = "IncludeBH";
      viewCheckBoxColumn4.ReadOnly = false;
      viewCheckBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvPriority.Columns.Add((DataGridViewColumn) viewCheckBoxColumn4);
    }

    public void SetupRaiseEngDGV()
    {
      Helper.SetUpDataGridView(this.dgRaiseEng, false);
      this.dgRaiseEng.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgRaiseEng.AutoGenerateColumns = false;
      this.dgRaiseEng.Columns.Clear();
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "EngineerID";
      viewTextBoxColumn1.DataPropertyName = "EngineerID";
      viewTextBoxColumn1.Name = "EngineerID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgRaiseEng.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "RaiseJobCustomerEngineerID";
      viewTextBoxColumn2.DataPropertyName = "RaiseJobCustomerEngineerID";
      viewTextBoxColumn2.Name = "RaiseJobCustomerEngineerID";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = false;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgRaiseEng.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "EngineerName";
      viewTextBoxColumn3.FillWeight = 70f;
      viewTextBoxColumn3.DataPropertyName = "EngineerName";
      viewTextBoxColumn3.Name = "EngineerName";
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgRaiseEng.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn.FillWeight = 5f;
      viewCheckBoxColumn.HeaderText = "Super";
      viewCheckBoxColumn.DataPropertyName = "Super";
      viewCheckBoxColumn.Name = "Super";
      viewCheckBoxColumn.ReadOnly = false;
      viewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgRaiseEng.Columns.Add((DataGridViewColumn) viewCheckBoxColumn);
    }

    public void SetupRequirements()
    {
      Helper.SetUpDataGrid(this.dgRequirements, false);
      DataGridTableStyle tableStyle = this.dgRequirements.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.ReadOnly = false;
      tableStyle.AllowSorting = false;
      this.dgRequirements.ReadOnly = false;
      this.dgRequirements.AllowSorting = false;
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
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 300;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "";
      dataGridLabelColumn2.MappingName = "ManagerID";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 1;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.MappingName = Enums.TableNames.tblWarehouse.ToString();
      this.dgRequirements.TableStyles.Add(tableStyle);
    }

    public void SetupContractsDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgContracts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Contract Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Contract Reference";
      dataGridLabelColumn2.MappingName = "ContractReference";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Contract Status";
      dataGridLabelColumn3.MappingName = "ContractStatus";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 180;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "dd/MM/yyyy";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Start Date";
      dataGridLabelColumn4.MappingName = "ContractStartDate";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MM/yyyy";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "End Date";
      dataGridLabelColumn5.MappingName = "ContractEndDate";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Contract Price";
      dataGridLabelColumn6.MappingName = "ContractPrice";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblContract.ToString();
      this.dgContracts.TableStyles.Add(tableStyle);
    }

    private void UCCustomer_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
      this.SetupContractsDataGrid();
      this.SetupPrioritiesDGV();
      this.SetupRequirements();
      this.SetupRaiseEngDGV();
      this.SetupCustomerAuthorityAuditDataGrid();
      this.SetupCustomerAlertsDataGrid();
    }

    private void btnAddContract_Click(object sender, EventArgs e)
    {
      this.cmnuContractOptions.Show((Control) this.btnAddContract, new System.Drawing.Point(0, -30));
    }

    private void mnuContractOpt1_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMContractOriginal), true, new object[2]
      {
        (object) 0,
        (object) Helper.MakeIntegerValid((object) this.CurrentCustomer.CustomerID)
      }, false);
      this.Contracts = App.DB.Customer.Customer_Contracts_GetAll(this.CurrentCustomer.CustomerID);
    }

    private void btnDeleteContract_Click(object sender, EventArgs e)
    {
      if (this.SelectedContractDataRow == null || App.ShowMessage("Are you sure you want to delete this contract - any contract jobs not yet downloaded will be remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      bool flag = true;
      object Left1 = this.SelectedContractDataRow["ContractType"];
      Enums.QuoteType quoteType = Enums.QuoteType.Contract_Opt_1;
      string str1 = quoteType.ToString();
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left1, (object) str1, false))
      {
        flag = this.DeleteOption1();
      }
      else
      {
        object Left2 = this.SelectedContractDataRow["ContractType"];
        quoteType = Enums.QuoteType.Contract_Opt_2;
        string str2 = quoteType.ToString();
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left2, (object) str2, false))
        {
          flag = this.DeleteOption2();
        }
        else
        {
          object Left3 = this.SelectedContractDataRow["ContractType"];
          quoteType = Enums.QuoteType.Contract_Opt_3;
          string str3 = quoteType.ToString();
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left3, (object) str3, false))
            flag = this.DeleteOption3();
        }
      }
      if (flag)
      {
        this.Contracts = App.DB.Customer.Customer_Contracts_GetAll(this.CurrentCustomer.CustomerID);
      }
      else
      {
        int num = (int) App.ShowMessage("Cannot delete the contract - there are active jobs on properties", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void dgContracts_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedContractDataRow == null)
        return;
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedContractDataRow["ContractType"], (object) Enums.QuoteType.Contract_Opt_1.ToString(), false))
        App.ShowForm(typeof (FRMContractOriginal), true, new object[2]
        {
          (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractID"])),
          (object) Helper.MakeIntegerValid((object) this.CurrentCustomer.CustomerID)
        }, false);
      this.Contracts = App.DB.Customer.Customer_Contracts_GetAll(this.CurrentCustomer.CustomerID);
    }

    private bool DeleteOption1()
    {
      DataView dataView = new DataView();
      DataView allContractId = App.DB.ContractOriginalSite.GetAll_ContractID(Conversions.ToInteger(this.SelectedContractDataRow["ContractID"]), this.CurrentCustomer.CustomerID);
      bool flag = true;
      IEnumerator enumerator;
      try
      {
        enumerator = allContractId.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (App.DB.ContractOriginalSite.Delete(Conversions.ToInteger(current["ContractSiteID"])) > 0)
            flag = false;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (flag)
        App.DB.ContractOriginal.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractID"])));
      return flag;
    }

    private bool DeleteOption2()
    {
      DataView dataView = new DataView();
      DataView allContractId = App.DB.ContractAlternativeSite.GetAll_ContractID(Conversions.ToInteger(this.SelectedContractDataRow["ContractID"]), this.CurrentCustomer.CustomerID);
      bool flag = true;
      IEnumerator enumerator;
      try
      {
        enumerator = allContractId.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (App.DB.ContractAlternativeSite.Delete(Conversions.ToInteger(current["ContractSiteID"])) > 0)
            flag = false;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (flag)
        App.DB.ContractAlternative.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractID"])));
      return flag;
    }

    private bool DeleteOption3()
    {
      DataView dataView = new DataView();
      DataView allForContract = App.DB.ContractOption3Site.ContractOption3Site_GetAll_ForContract(Conversions.ToInteger(this.SelectedContractDataRow["ContractID"]), this.CurrentCustomer.CustomerID);
      bool flag = true;
      IEnumerator enumerator;
      try
      {
        enumerator = allForContract.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (App.DB.ContractOption3Site.Delete(Conversions.ToInteger(current["ContractSiteID"])) > 0)
            flag = false;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (flag)
        App.DB.ContractOption3.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractID"])));
      return flag;
    }

    public void RefreshContractList()
    {
      this.Contracts = App.DB.Customer.Customer_Contracts_GetAll(this.CurrentCustomer.CustomerID);
    }

    private void PopulateCharges()
    {
      CustomerCharge customerCharge = new CustomerCharge();
      CustomerCharge forCustomer = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(this.CurrentCustomer.CustomerID);
      if (forCustomer != null)
      {
        this.txtMileageRate.Text = Conversions.ToString(forCustomer.MileageRate);
        this.txtPartsMarkup.Text = Conversions.ToString(forCustomer.PartsMarkup);
        this.txtRatesMarkup.Text = Conversions.ToString(forCustomer.RatesMarkup);
      }
      else
      {
        Settings settings = App.DB.Manager.Get();
        this.txtMileageRate.Text = Conversions.ToString(Helper.MakeDoubleValid((object) settings?.MileageRate));
        this.txtPartsMarkup.Text = Conversions.ToString(Helper.MakeDoubleValid((object) settings?.PartsMarkup));
        this.txtRatesMarkup.Text = Conversions.ToString(Helper.MakeDoubleValid((object) settings?.RatesMarkup));
      }
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentCustomer = App.DB.Customer.Customer_Get(ID);
      this.PopulateCharges();
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.CustomerCharges))
        this.TabControl1.TabPages.Remove(this.tabCharges);
      this.Data = App.DB.Customer.Priorities_Get_For_CustomerID(this.CurrentCustomer.CustomerID);
      this.RequirementDataView = App.DB.Customer.Requirements_Get_For_CustomerID(this.CurrentCustomer.CustomerID);
      this.PartsDataView = App.DB.Part.Customer_Parts_GetAll(this.CurrentCustomer.CustomerID);
      this.EngRaiseView = App.DB.Customer.Customer_EngineerRaise_Get(this.CurrentCustomer.CustomerID);
      this.txtName.Text = this.CurrentCustomer.Name;
      ComboBox cboRegionId = this.cboRegionID;
      Combo.SetSelectedComboItem_By_Value(ref cboRegionId, Conversions.ToString(this.CurrentCustomer.RegionID));
      this.cboRegionID = cboRegionId;
      if (!this.CurrentCustomer.Exists | !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
        this.cboRegionID.Enabled = false;
      ComboBox cboType = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType, Conversions.ToString(this.CurrentCustomer.CustomerTypeID));
      this.cboType = cboType;
      if (this.CurrentCustomer.CustomerTypeID == 516)
        this.cboType.Enabled = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor);
      this.txtAlertEmail.Text = this.CurrentCustomer.AlertEmail;
      this.txtNotes.Text = this.CurrentCustomer.Notes;
      this.txtAccountNumber.Text = this.CurrentCustomer.AccountNumber;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.CurrentCustomer.Status));
      this.cboStatus = cboStatus;
      Enums.SecuritySystemModules ssm = Enums.SecuritySystemModules.Finance;
      if (this.CurrentCustomer.Status == 3 & !App.loggedInUser.HasAccessToModule(ssm))
        this.cboStatus.Enabled = false;
      this.PopulateCustomerAuthority();
      this.PopulateCustomerAlerts();
      this.chbAcceptChargeChanges.Checked = this.CurrentCustomer.AcceptChargesChanges;
      this.chkMOTService.Checked = this.CurrentCustomer.MOTStyleService;
      this.cbIsOutOfScope.Checked = this.CurrentCustomer.IsOutOfScope;
      this.txtMainContractorDiscount.Text = Conversions.ToString(this.CurrentCustomer.MainContractorDiscount);
      this.chkPONumReq.Checked = this.CurrentCustomer.PoNumReqd;
      this.chkJobPriorityRequired.Checked = this.CurrentCustomer.JobPriorityMandatory;
      this.txtNominal.Text = this.CurrentCustomer.Nominal;
      ComboBox cboDepartment = this.cboDepartment;
      Combo.SetSelectedComboItem_By_Value(ref cboDepartment, this.CurrentCustomer.OverrideDept.Trim());
      this.cboDepartment = cboDepartment;
      ComboBox cboTerms = this.cboTerms;
      Combo.SetSelectedComboItem_By_Value(ref cboTerms, Conversions.ToString(this.CurrentCustomer.Terms));
      this.cboTerms = cboTerms;
      this.chkSuperBooking.Checked = this.CurrentCustomer.SuperBook;
      if (this.CurrentCustomer.Logo != null)
        this.picLogo.Image = Image.FromStream((Stream) new MemoryStream(this.CurrentCustomer.Logo));
      this.txtServSummer.Text = Conversions.ToString(this.CurrentCustomer.SummerServ);
      this.txtServWinter.Text = Conversions.ToString(this.CurrentCustomer.WinterServ);
      this.txtSpendLimit.Text = Conversions.ToString(this.CurrentCustomer.JobSpendLimit);
      this.chkIsPFH.Checked = this.CurrentCustomer.IsPFH;
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentCustomer.IgnoreExceptionsOnSetMethods = true;
        this.CurrentCustomer.SetName = (object) this.txtName.Text.Trim();
        if (!this.CurrentCustomer.Exists | App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
          this.CurrentCustomer.SetRegionID = (object) Combo.get_GetSelectedItemValue(this.cboRegionID);
        this.CurrentCustomer.SetCustomerTypeID = (object) Combo.get_GetSelectedItemValue(this.cboType);
        this.CurrentCustomer.SetNotes = (object) this.txtNotes.Text.Trim();
        this.CurrentCustomer.SetAccountNumber = (object) this.txtAccountNumber.Text.Trim();
        this.CurrentCustomer.SetStatus = (object) Combo.get_GetSelectedItemValue(this.cboStatus);
        this.CurrentCustomer.SetAcceptChargesChanges = (object) this.chbAcceptChargeChanges.Checked;
        this.CurrentCustomer.SetMOTStyleService = this.chkMOTService.Checked;
        this.CurrentCustomer.SetIsOutOfScope = this.cbIsOutOfScope.Checked;
        this.CurrentCustomer.SetSuperBook = (object) this.chkSuperBooking.Checked;
        this.CurrentCustomer.SetAlertEmail = (object) this.txtAlertEmail.Text;
        this.CurrentCustomer.SetMainContractorDiscount = this.txtMainContractorDiscount.Text.Trim().Length != 0 ? (object) this.txtMainContractorDiscount.Text : (object) 0;
        this.CurrentCustomer.SetPoNumReqd = (object) this.chkPONumReq.Checked;
        this.CurrentCustomer.SetJobPriorityMandatory = (object) this.chkJobPriorityRequired.Checked;
        this.CurrentCustomer.SetNominal = (object) this.txtNominal.Text;
        this.CurrentCustomer.SetSummerServ = (object) this.txtServSummer.Text;
        this.CurrentCustomer.SetWinterServ = (object) this.txtServWinter.Text;
        this.CurrentCustomer.SetIsPFH = this.chkIsPFH.Checked;
        string str = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDepartment));
        if (Helper.IsValidInteger((object) str) && Helper.MakeIntegerValid((object) str) > 0)
          this.CurrentCustomer.SetOverrideDept = (object) str;
        else if (!Versioned.IsNumeric((object) str))
          this.CurrentCustomer.SetOverrideDept = (object) str;
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboTerms)) > 0.0)
          this.CurrentCustomer.SetTerms = (object) Combo.get_GetSelectedItemValue(this.cboTerms);
        if (this.txtSpendLimit.Text.Trim().Length > 0)
          this.CurrentCustomer.SetJobSpendLimit = (object) Helper.MakeDoubleValid((object) this.txtSpendLimit.Text.Trim());
        new CustomerValidator().Validate(this.CurrentCustomer);
        if (this.CurrentCustomer.Exists)
          App.DB.Customer.Update(this.CurrentCustomer);
        else
          this.CurrentCustomer = App.DB.Customer.Insert(this.CurrentCustomer);
        CustomerCharge oCustomerCharge = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(this.CurrentCustomer.CustomerID) ?? new CustomerCharge();
        oCustomerCharge.SetMileageRate = (object) this.txtMileageRate.Text.Trim();
        oCustomerCharge.SetPartsMarkup = (object) this.txtPartsMarkup.Text.Trim();
        oCustomerCharge.SetRatesMarkup = (object) this.txtRatesMarkup.Text.Trim();
        oCustomerCharge.SetCustomerID = (object) this.CurrentCustomer.CustomerID;
        new CustomerChargeValidator().Validate(oCustomerCharge);
        if (oCustomerCharge.Exists)
          App.DB.CustomerCharge.Update(oCustomerCharge);
        else
          App.DB.CustomerCharge.Insert(oCustomerCharge);
        App.CurrentCustomerID = this.CurrentCustomer.CustomerID;
        App.DB.Customer.Priorities_Delete_For_Customer(this.CurrentCustomer.CustomerID);
        IEnumerator enumerator1;
        try
        {
          enumerator1 = ((IEnumerable) this.dgvPriority.Rows).GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataGridViewRow current = (DataGridViewRow) enumerator1.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current.Cells["Tick"].Value, (object) true, false))
              App.DB.Customer.Priorities_Insert_For_Customer(this.CurrentCustomer.CustomerID, Conversions.ToInteger(current.Cells["ManagerID"].Value), Conversions.ToInteger(current.Cells["TargetHours"].Value), Conversions.ToInteger(current.Cells["IncludeWeekends"].Value), Conversions.ToInteger(current.Cells["IncludeBH"].Value), Conversions.ToInteger(current.Cells["IncludeOOH"].Value));
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        App.DB.Customer.Requirements_Delete_For_Customer(this.CurrentCustomer.CustomerID);
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.RequirementDataView.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Tick"], (object) true, false))
              App.DB.Customer.Requirements_Insert_For_Customer(this.CurrentCustomer.CustomerID, Conversions.ToInteger(current["ManagerID"]));
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        // ISSUE: reference to a compiler-generated field
        IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
        if (recordsChangedEvent != null)
          recordsChangedEvent(App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID), Enums.PageViewing.Customer, true, false, "");
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentCustomer.CustomerID);
        App.MainForm.RefreshEntity(this.CurrentCustomer.CustomerID, "CustomerID");
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    private void btnSelectLogoImage_Click(object sender, EventArgs e)
    {
      try
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Set Image File";
        openFileDialog.Filter = "Image Files|*.bmp;*.Jpg;*.Gif";
        openFileDialog.FileName = "";
        if (openFileDialog.ShowDialog() == DialogResult.Cancel)
          return;
        Image image = Image.FromFile(openFileDialog.FileName.ToString());
        Bitmap bitmap = new Bitmap(226, 226, PixelFormat.Format24bppRgb);
        Graphics graphics = Graphics.FromImage((Image) bitmap);
        if (image.Height > image.Width)
        {
          double num = (double) image.Width / (double) image.Height;
          int width = checked ((int) Math.Round(unchecked ((double) image.Width * num)));
          int height = 226;
          graphics.Clear(Color.White);
          graphics.DrawImage(image, checked (113 - unchecked (width / 2)), 0, width, height);
        }
        else if (image.Height <= image.Width)
        {
          double num = (double) image.Width / (double) image.Height;
          int width = 226;
          int height = checked ((int) Math.Round(unchecked ((double) image.Height * num)));
          graphics.Clear(Color.White);
          graphics.DrawImage(image, 0, checked (113 - unchecked (height / 2)), width, height);
        }
        MemoryStream memoryStream = new MemoryStream();
        bitmap.Save((Stream) memoryStream, ImageFormat.Jpeg);
        this.picLogo.Image = (Image) bitmap;
        this.CurrentCustomer.Logo = memoryStream.GetBuffer();
        App.AnythingChanges(RuntimeHelpers.GetObjectValue(sender), e);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ErrorMsg.ErrorOccured("Reading logo image"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
    }

    private void dgRequirement_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        DataGrid.HitTestInfo hitTestInfo = this.dgRequirements.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgRequirements.CurrentRowIndex = hitTestInfo.Row;
        if ((uint) hitTestInfo.Column > 0U || this.SelectedRequirmentDataRow == null)
          return;
        this.dgRequirements[this.dgRequirements.CurrentRowIndex, 0] = (object) !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgRequirements[this.dgRequirements.CurrentRowIndex, 0]));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (this.CurrentCustomer.CustomerID == 0)
      {
        int num1 = (int) App.ShowMessage("You need to save the customer first!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        FRMFindPart frmFindPart = (FRMFindPart) App.checkIfExists(typeof (FRMFindPart).Name, true) ?? (FRMFindPart) Activator.CreateInstance(typeof (FRMFindPart));
        frmFindPart.ShowInTaskbar = false;
        frmFindPart.TableToSearch = Enums.TableNames.tblPartSupplier;
        int num2 = (int) frmFindPart.ShowDialog();
        if (frmFindPart.DialogResult != DialogResult.OK)
          return;
        DataRow[] datarows = frmFindPart.Datarows;
        int index = 0;
        while (index < datarows.Length)
        {
          DataRow dataRow = datarows[index];
          App.DB.Customer.Part_Insert_For_Customer(this.CurrentCustomer.CustomerID, Conversions.ToInteger(dataRow["PartSupplierID"]));
          checked { ++index; }
        }
        this.PartsDataView = App.DB.Part.Customer_Parts_GetAll(this.CurrentCustomer.CustomerID);
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.dgvParts.SelectedRows[0].Index <= -1)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.dgvParts.SelectedRows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataGridViewRow current = (DataGridViewRow) enumerator.Current;
          App.DB.Customer.Part_Delete_For_Customer(this.CurrentCustomer.CustomerID, Conversions.ToInteger(current.Cells[0].Value));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.PartsDataView = App.DB.Part.Customer_Parts_GetAll(this.CurrentCustomer.CustomerID);
    }

    private void dgRaiseEng_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgRaiseEng.SelectedRows[0].Index <= -1)
        return;
      using (FRMEngineerRaiseJob engineerRaiseJob1 = new FRMEngineerRaiseJob())
      {
        FRMEngineerRaiseJob engineerRaiseJob2 = engineerRaiseJob1;
        ComboBox cboEngineer = engineerRaiseJob2.cboEngineer;
        Combo.SetSelectedComboItem_By_Value(ref cboEngineer, Conversions.ToString(this.dgRaiseEng.SelectedRows[0].Cells["EngineerID"].Value));
        engineerRaiseJob2.cboEngineer = cboEngineer;
        engineerRaiseJob1.chkSuper.Checked = Conversions.ToBoolean(this.dgRaiseEng.SelectedRows[0].Cells["Super"].Value);
        int num = (int) engineerRaiseJob1.ShowDialog();
        if (engineerRaiseJob1.DialogResult == DialogResult.OK)
          App.DB.Customer.Customer_EngineerRaise_Update(this.CurrentCustomer.CustomerID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(engineerRaiseJob1.cboEngineer)), engineerRaiseJob1.chkSuper.Checked, Conversions.ToInteger(this.dgRaiseEng.SelectedRows[0].Cells["RaiseJobCustomerEngineerID"].Value));
      }
      this.EngRaiseView = App.DB.Customer.Customer_EngineerRaise_Get(this.CurrentCustomer.CustomerID);
    }

    private void btnEngAdd_Click(object sender, EventArgs e)
    {
      if (this.CurrentCustomer.CustomerID == 0)
      {
        int num1 = (int) App.ShowMessage("You need to save the customer first!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        using (FRMEngineerRaiseJob engineerRaiseJob = new FRMEngineerRaiseJob())
        {
          int num2 = (int) engineerRaiseJob.ShowDialog();
          if (engineerRaiseJob.DialogResult == DialogResult.OK)
            App.DB.Customer.Customer_EngineerRaise_Insert(this.CurrentCustomer.CustomerID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(engineerRaiseJob.cboEngineer)), engineerRaiseJob.chkSuper.Checked);
        }
        this.EngRaiseView = App.DB.Customer.Customer_EngineerRaise_Get(this.CurrentCustomer.CustomerID);
      }
    }

    private void btnEngDelete_Click(object sender, EventArgs e)
    {
      if (this.dgRaiseEng.SelectedRows[0].Index <= -1)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.dgRaiseEng.SelectedRows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataGridViewRow current = (DataGridViewRow) enumerator.Current;
          App.DB.Customer.Customer_EngineerRaise_Delete(Conversions.ToInteger(this.dgRaiseEng.SelectedRows[0].Cells["RaiseJobCustomerEngineerID"].Value));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.EngRaiseView = App.DB.Customer.Customer_EngineerRaise_Get(this.CurrentCustomer.CustomerID);
    }

    public void SetupCustomerAuthorityAuditDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgAuthorityAudit.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Action";
      dataGridLabelColumn1.MappingName = "ActionChange";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 350;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Date";
      dataGridLabelColumn2.MappingName = "ActionDateTime";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "User";
      dataGridLabelColumn3.MappingName = "Fullname";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblAuthority.ToString();
      this.dgAuthorityAudit.TableStyles.Add(tableStyle);
    }

    private DataView CustomerAuthorityAuditDataView
    {
      get
      {
        return this._dvCustomerAuthorityAudit;
      }
      set
      {
        this._dvCustomerAuthorityAudit = value;
        this._dvCustomerAuthorityAudit.AllowNew = false;
        this._dvCustomerAuthorityAudit.AllowEdit = false;
        this._dvCustomerAuthorityAudit.AllowDelete = false;
        this._dvCustomerAuthorityAudit.Table.TableName = Enums.TableNames.tblAuthority.ToString();
        this.dgAuthorityAudit.DataSource = (object) this.CustomerAuthorityAuditDataView;
      }
    }

    private void PopulateCustomerAuthority()
    {
      try
      {
        this.CustomerAuthority = App.DB.Authority.Get((object) this.CurrentCustomer.CustomerID, AuthoritySQL.GetBy.CustomerId);
        if (this.CustomerAuthority != null)
          this.txtCustAuthority.Text = this.CustomerAuthority.Notes;
        this.CustomerAuthorityAuditDataView = App.DB.Authority.Audit_Get((object) this.CurrentCustomer.CustomerID, AuthoritySQL.GetBy.CustomerId);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnSaveAuth_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.txtCustAuthority.Text))
        return;
      if (this.CustomerAuthority == null)
      {
        this.CustomerAuthority = new FSM.Entity.Authority.Authority();
        this.CustomerAuthority.SetNotes = (object) this.txtCustAuthority.Text;
        App.DB.Authority.Insert_Customer(this.CurrentCustomer.CustomerID, this.CustomerAuthority);
      }
      else
      {
        string change = string.Empty;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.CustomerAuthority.Notes, this.txtCustAuthority.Text, false) > 0U)
          change = change + "Changed: " + this.CustomerAuthority.Notes.Replace("\r", " ").Replace("\n", " ");
        this.CustomerAuthority.SetNotes = (object) this.txtCustAuthority.Text;
        App.DB.Authority.Update(this.CustomerAuthority, change);
      }
      this.PopulateCustomerAuthority();
    }

    private void txtPartSearch_Change(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void RunFilter()
    {
      string str = "0 = 0";
      if ((uint) this.txtPartSearch.Text.Trim().Length > 0U)
        str = str + " AND PartName LIKE '%" + this.txtPartSearch.Text.Trim() + "%' OR PartNumber LIKE '%" + this.txtPartSearch.Text.Trim() + "%' OR PartCode LIKE '%" + this.txtPartSearch.Text.Trim() + "%'";
      this.PartsDataView.RowFilter = str;
    }

    private void btnExportSites_Click(object sender, EventArgs e)
    {
      DataView allSites = App.DB.Customer.Customer_GetAll_Sites(Helper.MakeIntegerValid((object) this.CurrentCustomer?.CustomerID));
      if (allSites.Count <= 0)
        return;
      ExportHelper.Export(allSites.Table, "Sites", Enums.ExportType.XLS);
    }

    public List<CustomerAlert> CustomerAlerts { get; set; }

    public CustomerAlert CustomerAlert { get; set; }

    public DataView DvCustomerAlerts
    {
      get
      {
        return this._dvCustomerAlerts;
      }
      set
      {
        this._dvCustomerAlerts = value;
        if (this._dvCustomerAlerts != null)
        {
          this._dvCustomerAlerts.Table.TableName = Enums.TableNames.tblContact.ToString();
          this._dvCustomerAlerts.AllowNew = false;
          this._dvCustomerAlerts.AllowEdit = false;
          this._dvCustomerAlerts.AllowDelete = false;
        }
        this.dgCustomerAlerts.DataSource = (object) this._dvCustomerAlerts;
      }
    }

    private DataRow DrSelectedCustomerAlert
    {
      get
      {
        return this.dgCustomerAlerts.DataSource != null && this.dgCustomerAlerts.CurrentRowIndex != -1 ? this.DvCustomerAlerts[this.dgCustomerAlerts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupCustomerAlertsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgCustomerAlerts, false);
      DataGridTableStyle tableStyle = this.dgCustomerAlerts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgCustomerAlerts.ReadOnly = true;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Alert Type";
      dataGridLabelColumn1.MappingName = "AlertType";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Email Address(s)";
      dataGridLabelColumn2.MappingName = "EmailAddress";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 400;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblContact.ToString();
      this.dgCustomerAlerts.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgCustomerAlerts);
    }

    public void PopulateCustomerAlerts()
    {
      this.CustomerAlerts = App.DB.CustomerAlert.Get_ForCustomer(this.CurrentCustomer?.CustomerID.Value);
      List<CustomerAlert> customerAlerts = this.CustomerAlerts;
      // ISSUE: explicit non-virtual call
      if (customerAlerts != null && __nonvirtual (customerAlerts.Count) > 0)
        this.DvCustomerAlerts = new DataView(Helper.ToDataTable<CustomerAlert>((IList<CustomerAlert>) this.CustomerAlerts));
      else
        this.DvCustomerAlerts = (DataView) null;
    }

    private void ResetCustomerAlerts()
    {
      this.CustomerAlert = (CustomerAlert) null;
      this.btnDeleteCustomerAlert.Visible = false;
      this.cboAlertType.Enabled = true;
      this.txtCustomerAlertEmailAddress.Text = string.Empty;
      ComboBox cboAlertType = this.cboAlertType;
      Combo.SetSelectedComboItem_By_Value(ref cboAlertType, Conversions.ToString(0));
      this.cboAlertType = cboAlertType;
      this.PopulateCustomerAlerts();
    }

    private void btnSaveCustomerAlert_Click(object sender, EventArgs e)
    {
      FSM.Entity.Customers.Customer currentCustomer = this.CurrentCustomer;
      if (currentCustomer != null && currentCustomer.CustomerID > 0)
      {
        try
        {
          CustomerAlert customerAlert1 = this.CustomerAlert;
          if (customerAlert1 != null && customerAlert1.Id > 0)
          {
            this.CustomerAlert.EmailAddress = this.txtCustomerAlertEmailAddress.Text.Trim();
            App.DB.CustomerAlert.Update(this.CustomerAlert);
            this.ResetCustomerAlerts();
          }
          else
          {
            this.CustomerAlert = new CustomerAlert();
            CustomerAlert customerAlert2 = this.CustomerAlert;
            customerAlert2.CustomerId = this.CurrentCustomer.CustomerID;
            customerAlert2.AlertTypeId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboAlertType));
            customerAlert2.EmailAddress = this.txtCustomerAlertEmailAddress.Text.Trim();
            List<CustomerAlert> customerAlerts = this.CustomerAlerts;
            if (customerAlerts != null && customerAlerts.Where<CustomerAlert>((Func<CustomerAlert, bool>) (X => X.AlertTypeId == this.CustomerAlert.AlertTypeId)).ToList<CustomerAlert>().Count > 0)
            {
              int num = (int) App.ShowMessage("Alert type already exists!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
              return;
            }
            this.CustomerAlert = App.DB.CustomerAlert.Insert(this.CustomerAlert);
            this.ResetCustomerAlerts();
          }
          int num1 = (int) App.ShowMessage("Alert saved!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          int num = (int) App.ShowMessage(exception.Message + " - " + exception.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    private void btnAddCustomerAlert_Click(object sender, EventArgs e)
    {
      this.CustomerAlert = (CustomerAlert) null;
      this.ResetCustomerAlerts();
    }

    private void dgCustomerAlerts_Click(object sender, EventArgs e)
    {
      if (this.DrSelectedCustomerAlert == null)
        return;
      List<CustomerAlert> source = App.DB.CustomerAlert.Get(Conversions.ToInteger(this.DrSelectedCustomerAlert["Id"]));
      this.CustomerAlert = source != null ? source.FirstOrDefault<CustomerAlert>() : (CustomerAlert) null;
      CustomerAlert customerAlert = this.CustomerAlert;
      if (customerAlert != null && customerAlert.Id > 0)
      {
        this.btnDeleteCustomerAlert.Visible = true;
        this.cboAlertType.Enabled = false;
        ComboBox cboAlertType = this.cboAlertType;
        Combo.SetSelectedComboItem_By_Value(ref cboAlertType, Conversions.ToString(this.CustomerAlert.AlertTypeId));
        this.cboAlertType = cboAlertType;
        this.txtCustomerAlertEmailAddress.Text = this.CustomerAlert.EmailAddress.Trim();
      }
    }

    private void btnDeleteCustomerAlert_Click(object sender, EventArgs e)
    {
      CustomerAlert customerAlert = this.CustomerAlert;
      if (customerAlert == null || customerAlert.Id <= 0)
        return;
      App.DB.CustomerAlert.Delete(this.CustomerAlert);
      this.CustomerAlert = (CustomerAlert) null;
      this.ResetCustomerAlerts();
      int num = (int) App.ShowMessage("Alert removed!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
  }
}
