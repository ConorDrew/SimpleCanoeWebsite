// Decompiled with JetBrains decompiler
// Type: FSM.UCSite
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Authority;
using FSM.Entity.Contacts;
using FSM.Entity.ContractsOriginal;
using FSM.Entity.CustomerCharges;
using FSM.Entity.Customers;
using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.JobAudits;
using FSM.Entity.Management;
using FSM.Entity.SiteCustomerAudits;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class UCSite : UCBase, IUserControl
  {
    private IContainer components;
    private UCDocumentsList DocumentsControl;
    private UCQuotesList QuotesControl;
    private UCCustomerScheduleOfRate CustomerScheduleOfRateControl;
    private UCContacts ContactControl;
    private Form _FromForm;
    private FSM.Entity.Customers.Customer _currentCustomer;
    private FSM.Entity.Sites.Site _currentSite;
    private DataView _dInvoiceTable;
    private DataView _dcontactTable;
    private DataView _jobsTable;
    private FSM.Entity.Customers.Customer _theCustomer;
    private DataView _dvContracts;
    private int _SelectedCustomerID;
    private FSM.Entity.Authority.Authority _oSiteAuthority;
    private bool FlagShown;
    private DataView _siteNotes;
    private DataView _dvSiteFuels;
    private DataView _dvSiteAuthorityAudit;

    public UCSite()
    {
      this.Load += new EventHandler(this.UCSite_Load);
      this._dInvoiceTable = (DataView) null;
      this._dcontactTable = (DataView) null;
      this._jobsTable = (DataView) null;
      this._SelectedCustomerID = 0;
      this.FlagShown = false;
      this._siteNotes = (DataView) null;
      this._dvSiteFuels = (DataView) null;
      this.InitializeComponent();
      ComboBox cboDefinition = this.cboDefinition;
      Combo.SetUpCombo(ref cboDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboDefinition = cboDefinition;
      ComboBox cboRegionId = this.cboRegionID;
      Combo.SetUpCombo(ref cboRegionId, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboRegionID = cboRegionId;
      ComboBox sourceOfCustomer = this.cboSourceOfCustomer;
      Combo.SetUpCombo(ref sourceOfCustomer, App.DB.Picklists.GetAll(Enums.PickListTypes.SourceOfCustomer, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSourceOfCustomer = sourceOfCustomer;
      ComboBox reasonForContact = this.cboReasonForContact;
      Combo.SetUpCombo(ref reasonForContact, App.DB.Picklists.GetAll(Enums.PickListTypes.ReasonsForContact, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboReasonForContact = reasonForContact;
      ComboBox cboAccomType = this.cboAccomType;
      Combo.SetUpCombo(ref cboAccomType, App.DB.Picklists.GetAll(Enums.PickListTypes.AccomType, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboAccomType = cboAccomType;
      ComboBox cboSalutation = this.cboSalutation;
      Combo.SetUpCombo(ref cboSalutation, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboSalutation = cboSalutation;
      this.dtpBuildDate.Value = (DateTime) SqlDateTime.MinValue;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl tcSites { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkHeadOffice
    {
      get
      {
        return this._chkHeadOffice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkHeadOffice_Click);
        CheckBox chkHeadOffice1 = this._chkHeadOffice;
        if (chkHeadOffice1 != null)
          chkHeadOffice1.Click -= eventHandler;
        this._chkHeadOffice = value;
        CheckBox chkHeadOffice2 = this._chkHeadOffice;
        if (chkHeadOffice2 == null)
          return;
        chkHeadOffice2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCounty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabContacts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddContact
    {
      get
      {
        return this._btnAddContact;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddContact_Click);
        Button btnAddContact1 = this._btnAddContact;
        if (btnAddContact1 != null)
          btnAddContact1.Click -= eventHandler;
        this._btnAddContact = value;
        Button btnAddContact2 = this._btnAddContact;
        if (btnAddContact2 == null)
          return;
        btnAddContact2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeleteContact
    {
      get
      {
        return this._btnDeleteContact;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteContact_Click);
        Button btnDeleteContact1 = this._btnDeleteContact;
        if (btnDeleteContact1 != null)
          btnDeleteContact1.Click -= eventHandler;
        this._btnDeleteContact = value;
        Button btnDeleteContact2 = this._btnDeleteContact;
        if (btnDeleteContact2 == null)
          return;
        btnDeleteContact2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgContacts
    {
      get
      {
        return this._dgContacts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgContacts_DoubleClick);
        DataGrid dgContacts1 = this._dgContacts;
        if (dgContacts1 != null)
          dgContacts1.DoubleClick -= eventHandler;
        this._dgContacts = value;
        DataGrid dgContacts2 = this._dgContacts;
        if (dgContacts2 == null)
          return;
        dgContacts2.DoubleClick += eventHandler;
      }
    }

    internal virtual TabPage tabInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgInvoiceAddresses
    {
      get
      {
        return this._dgInvoiceAddresses;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgInvoiceAddresses_DoubleClick);
        DataGrid invoiceAddresses1 = this._dgInvoiceAddresses;
        if (invoiceAddresses1 != null)
          invoiceAddresses1.DoubleClick -= eventHandler;
        this._dgInvoiceAddresses = value;
        DataGrid invoiceAddresses2 = this._dgInvoiceAddresses;
        if (invoiceAddresses2 == null)
          return;
        invoiceAddresses2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnDeleteAddress
    {
      get
      {
        return this._btnDeleteAddress;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteAddress_Click);
        Button btnDeleteAddress1 = this._btnDeleteAddress;
        if (btnDeleteAddress1 != null)
          btnDeleteAddress1.Click -= eventHandler;
        this._btnDeleteAddress = value;
        Button btnDeleteAddress2 = this._btnDeleteAddress;
        if (btnDeleteAddress2 == null)
          return;
        btnDeleteAddress2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddAddress
    {
      get
      {
        return this._btnAddAddress;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddAddress_Click);
        Button btnAddAddress1 = this._btnAddAddress;
        if (btnAddAddress1 != null)
          btnAddAddress1.Click -= eventHandler;
        this._btnAddAddress = value;
        Button btnAddAddress2 = this._btnAddAddress;
        if (btnAddAddress2 == null)
          return;
        btnAddAddress2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtAddress5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabQuotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlQuotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRatesMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMileageRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartsMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chbAcceptChargeChanges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnEmail
    {
      get
      {
        return this._btnEmail;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEmail_Click);
        Button btnEmail1 = this._btnEmail;
        if (btnEmail1 != null)
          btnEmail1.Click -= eventHandler;
        this._btnEmail = value;
        Button btnEmail2 = this._btnEmail;
        if (btnEmail2 == null)
          return;
        btnEmail2.Click += eventHandler;
      }
    }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDefinition
    {
      get
      {
        return this._cboDefinition;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboDefinition_SelectedIndexChanged);
        ComboBox cboDefinition1 = this._cboDefinition;
        if (cboDefinition1 != null)
          cboDefinition1.SelectedIndexChanged -= eventHandler;
        this._cboDefinition = value;
        ComboBox cboDefinition2 = this._cboDefinition;
        if (cboDefinition2 == null)
          return;
        cboDefinition2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobNumber
    {
      get
      {
        return this._txtJobNumber;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtJobNumber_TextChanged);
        TextBox txtJobNumber1 = this._txtJobNumber;
        if (txtJobNumber1 != null)
          txtJobNumber1.TextChanged -= eventHandler;
        this._txtJobNumber = value;
        TextBox txtJobNumber2 = this._txtJobNumber;
        if (txtJobNumber2 == null)
          return;
        txtJobNumber2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo
    {
      get
      {
        return this._dtpTo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpTo_ValueChanged);
        DateTimePicker dtpTo1 = this._dtpTo;
        if (dtpTo1 != null)
          dtpTo1.ValueChanged -= eventHandler;
        this._dtpTo = value;
        DateTimePicker dtpTo2 = this._dtpTo;
        if (dtpTo2 == null)
          return;
        dtpTo2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFrom
    {
      get
      {
        return this._dtpFrom;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpFrom_ValueChanged);
        DateTimePicker dtpFrom1 = this._dtpFrom;
        if (dtpFrom1 != null)
          dtpFrom1.ValueChanged -= eventHandler;
        this._dtpFrom = value;
        DateTimePicker dtpFrom2 = this._dtpFrom;
        if (dtpFrom2 == null)
          return;
        dtpFrom2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgJobs
    {
      get
      {
        return this._dgJobs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgJobs_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgJobs_DoubleClick);
        DataGrid dgJobs1 = this._dgJobs;
        if (dgJobs1 != null)
        {
          dgJobs1.Click -= eventHandler1;
          dgJobs1.DoubleClick -= eventHandler2;
        }
        this._dgJobs = value;
        DataGrid dgJobs2 = this._dgJobs;
        if (dgJobs2 == null)
          return;
        dgJobs2.Click += eventHandler1;
        dgJobs2.DoubleClick += eventHandler2;
      }
    }

    internal virtual Button btnAddJob
    {
      get
      {
        return this._btnAddJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddJob_Click);
        Button btnAddJob1 = this._btnAddJob;
        if (btnAddJob1 != null)
          btnAddJob1.Click -= eventHandler;
        this._btnAddJob = value;
        Button btnAddJob2 = this._btnAddJob;
        if (btnAddJob2 == null)
          return;
        btnAddJob2.Click += eventHandler;
      }
    }

    internal virtual Button btnShowAllJobs
    {
      get
      {
        return this._btnShowAllJobs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnShowAllJobs_Click);
        Button btnShowAllJobs1 = this._btnShowAllJobs;
        if (btnShowAllJobs1 != null)
          btnShowAllJobs1.Click -= eventHandler;
        this._btnShowAllJobs = value;
        Button btnShowAllJobs2 = this._btnShowAllJobs;
        if (btnShowAllJobs2 == null)
          return;
        btnShowAllJobs2.Click += eventHandler;
      }
    }

    internal virtual Button btnRemoveJob
    {
      get
      {
        return this._btnRemoveJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveJob_Click);
        Button btnRemoveJob1 = this._btnRemoveJob;
        if (btnRemoveJob1 != null)
          btnRemoveJob1.Click -= eventHandler;
        this._btnRemoveJob = value;
        Button btnRemoveJob2 = this._btnRemoveJob;
        if (btnRemoveJob2 == null)
          return;
        btnRemoveJob2.Click += eventHandler;
      }
    }

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

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDomestic
    {
      get
      {
        return this._btnDomestic;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDomestic_Click);
        Button btnDomestic1 = this._btnDomestic;
        if (btnDomestic1 != null)
          btnDomestic1.Click -= eventHandler;
        this._btnDomestic = value;
        Button btnDomestic2 = this._btnDomestic;
        if (btnDomestic2 == null)
          return;
        btnDomestic2.Click += eventHandler;
      }
    }

    internal virtual TabPage tabContracts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbContracts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnCustomerAudit
    {
      get
      {
        return this._btnCustomerAudit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCustomerAudit_Click);
        Button btnCustomerAudit1 = this._btnCustomerAudit;
        if (btnCustomerAudit1 != null)
          btnCustomerAudit1.Click -= eventHandler;
        this._btnCustomerAudit = value;
        Button btnCustomerAudit2 = this._btnCustomerAudit;
        if (btnCustomerAudit2 == null)
          return;
        btnCustomerAudit2.Click += eventHandler;
      }
    }

    internal virtual Button btnSendEmailToSite
    {
      get
      {
        return this._btnSendEmailToSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSendEmailToSite_Click);
        Button btnSendEmailToSite1 = this._btnSendEmailToSite;
        if (btnSendEmailToSite1 != null)
          btnSendEmailToSite1.Click -= eventHandler;
        this._btnSendEmailToSite = value;
        Button btnSendEmailToSite2 = this._btnSendEmailToSite;
        if (btnSendEmailToSite2 == null)
          return;
        btnSendEmailToSite2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkNoMarketing { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContractStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPrintLetters
    {
      get
      {
        return this._btnPrintLetters;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintLetters_Click);
        Button btnPrintLetters1 = this._btnPrintLetters;
        if (btnPrintLetters1 != null)
          btnPrintLetters1.Click -= eventHandler;
        this._btnPrintLetters = value;
        Button btnPrintLetters2 = this._btnPrintLetters;
        if (btnPrintLetters2 == null)
          return;
        btnPrintLetters2.Click += eventHandler;
      }
    }

    internal virtual Button btnShowVisits
    {
      get
      {
        return this._btnShowVisits;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnShowVisits_Click);
        Button btnShowVisits1 = this._btnShowVisits;
        if (btnShowVisits1 != null)
          btnShowVisits1.Click -= eventHandler;
        this._btnShowVisits = value;
        Button btnShowVisits2 = this._btnShowVisits;
        if (btnShowVisits2 == null)
          return;
        btnShowVisits2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkOnStop
    {
      get
      {
        return this._chkOnStop;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkOnStop_Click);
        CheckBox chkOnStop1 = this._chkOnStop;
        if (chkOnStop1 != null)
          chkOnStop1.Click -= eventHandler;
        this._chkOnStop = value;
        CheckBox chkOnStop2 = this._chkOnStop;
        if (chkOnStop2 == null)
          return;
        chkOnStop2.Click += eventHandler;
      }
    }

    internal virtual TabPage tpNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDeleteNote
    {
      get
      {
        return this._btnDeleteNote;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteNote_Click);
        Button btnDeleteNote1 = this._btnDeleteNote;
        if (btnDeleteNote1 != null)
          btnDeleteNote1.Click -= eventHandler;
        this._btnDeleteNote = value;
        Button btnDeleteNote2 = this._btnDeleteNote;
        if (btnDeleteNote2 == null)
          return;
        btnDeleteNote2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgNotes
    {
      get
      {
        return this._dgNotes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgNotes_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgNotes_Click);
        DataGrid dgNotes1 = this._dgNotes;
        if (dgNotes1 != null)
        {
          dgNotes1.Click -= eventHandler1;
          dgNotes1.CurrentCellChanged -= eventHandler2;
        }
        this._dgNotes = value;
        DataGrid dgNotes2 = this._dgNotes;
        if (dgNotes2 == null)
          return;
        dgNotes2.Click += eventHandler1;
        dgNotes2.CurrentCellChanged += eventHandler2;
      }
    }

    internal virtual Button btnAddNote
    {
      get
      {
        return this._btnAddNote;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNote_Click);
        Button btnAddNote1 = this._btnAddNote;
        if (btnAddNote1 != null)
          btnAddNote1.Click -= eventHandler;
        this._btnAddNote = value;
        Button btnAddNote2 = this._btnAddNote;
        if (btnAddNote2 == null)
          return;
        btnAddNote2.Click += eventHandler;
      }
    }

    internal virtual GroupBox gpbNotesDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNoteID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveNote
    {
      get
      {
        return this._btnSaveNote;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveNote_Click);
        Button btnSaveNote1 = this._btnSaveNote;
        if (btnSaveNote1 != null)
          btnSaveNote1.Click -= eventHandler;
        this._btnSaveNote = value;
        Button btnSaveNote2 = this._btnSaveNote;
        if (btnSaveNote2 == null)
          return;
        btnSaveNote2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtNote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractInactive { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkLeaseHolder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkNoService
    {
      get
      {
        return this._chkNoService;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkNoService_Click);
        CheckBox chkNoService1 = this._chkNoService;
        if (chkNoService1 != null)
          chkNoService1.Click -= eventHandler;
        this._chkNoService = value;
        CheckBox chkNoService2 = this._chkNoService;
        if (chkNoService2 == null)
          return;
        chkNoService2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkSolidFuel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkCommercialDistrict { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private virtual Button btnAddModifyPlan
    {
      get
      {
        return this._btnAddModifyPlan;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddModifyPlan_Click);
        Button btnAddModifyPlan1 = this._btnAddModifyPlan;
        if (btnAddModifyPlan1 != null)
          btnAddModifyPlan1.Click -= eventHandler;
        this._btnAddModifyPlan = value;
        Button btnAddModifyPlan2 = this._btnAddModifyPlan;
        if (btnAddModifyPlan2 == null)
          return;
        btnAddModifyPlan2.Click += eventHandler;
      }
    }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFirstName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSalutation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSurname { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegionID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRegionID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPolicyNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTown { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnConvCust
    {
      get
      {
        return this._btnConvCust;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnConvCust_Click);
        Button btnConvCust1 = this._btnConvCust;
        if (btnConvCust1 != null)
          btnConvCust1.Click -= eventHandler;
        this._btnConvCust = value;
        Button btnConvCust2 = this._btnConvCust;
        if (btnConvCust2 == null)
          return;
        btnConvCust2.Click += eventHandler;
      }
    }

    internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAsbestos { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAlert { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label21 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSiteFuel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSiteFuel
    {
      get
      {
        return this._dgSiteFuel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgSiteFuel_MouseUp);
        EventHandler eventHandler = new EventHandler(this.dgSiteFuel_Leave);
        DataGrid dgSiteFuel1 = this._dgSiteFuel;
        if (dgSiteFuel1 != null)
        {
          dgSiteFuel1.MouseUp -= mouseEventHandler;
          dgSiteFuel1.Leave -= eventHandler;
        }
        this._dgSiteFuel = value;
        DataGrid dgSiteFuel2 = this._dgSiteFuel;
        if (dgSiteFuel2 == null)
          return;
        dgSiteFuel2.MouseUp += mouseEventHandler;
        dgSiteFuel2.Leave += eventHandler;
      }
    }

    internal virtual ToolTip ttSiteFuel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnMoreInfo
    {
      get
      {
        return this._btnMoreInfo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.SiteFuelMoreInfo);
        Button btnMoreInfo1 = this._btnMoreInfo;
        if (btnMoreInfo1 != null)
          btnMoreInfo1.Click -= eventHandler;
        this._btnMoreInfo = value;
        Button btnMoreInfo2 = this._btnMoreInfo;
        if (btnMoreInfo2 == null)
          return;
        btnMoreInfo2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkVoid
    {
      get
      {
        return this._chkVoid;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ChkVoid_Click);
        CheckBox chkVoid1 = this._chkVoid;
        if (chkVoid1 != null)
          chkVoid1.Click -= eventHandler;
        this._chkVoid = value;
        CheckBox chkVoid2 = this._chkVoid;
        if (chkVoid2 == null)
          return;
        chkVoid2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtLastServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ContextMenuStrip cmsJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem tsmiMoveJob
    {
      get
      {
        return this._tsmiMoveJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiMoveJob_Click);
        ToolStripMenuItem tsmiMoveJob1 = this._tsmiMoveJob;
        if (tsmiMoveJob1 != null)
          tsmiMoveJob1.Click -= eventHandler;
        this._tsmiMoveJob = value;
        ToolStripMenuItem tsmiMoveJob2 = this._tsmiMoveJob;
        if (tsmiMoveJob2 == null)
          return;
        tsmiMoveJob2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtActualServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabAuthority { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpCustAuth { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustAuthority { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAuthorityAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSiteAuth { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TextBox txtSiteAuth { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSiteReport
    {
      get
      {
        return this._btnSiteReport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSiteReport_Click);
        Button btnSiteReport1 = this._btnSiteReport;
        if (btnSiteReport1 != null)
          btnSiteReport1.Click -= eventHandler;
        this._btnSiteReport = value;
        Button btnSiteReport2 = this._btnSiteReport;
        if (btnSiteReport2 == null)
          return;
        btnSiteReport2.Click += eventHandler;
      }
    }

    internal virtual TabPage tpAdditionalDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAdditionalDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBuildDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtWarrantyPeriod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblWarrantyPeriod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpBuildDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPropertyVoidDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPropertyVoidDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSiteDefects { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSiteDefects { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblHousingOfficer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHousingOfficer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEstateOfficer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEstateOfficer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHousingManager { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblHousingManager { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDefectEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDefectEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    protected virtual Label lblAccomType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAccomType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDDRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDDRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnLetterReport
    {
      get
      {
        return this._btnLetterReport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnLetterReport_Click);
        Button btnLetterReport1 = this._btnLetterReport;
        if (btnLetterReport1 != null)
          btnLetterReport1.Click -= eventHandler;
        this._btnLetterReport = value;
        Button btnLetterReport2 = this._btnLetterReport;
        if (btnLetterReport2 == null)
          return;
        btnLetterReport2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboReasonForContact { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSourceOfCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage TabNewContacts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual FlowLayoutPanel pnlContactsMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.tcSites = new TabControl();
      this.tabDetails = new TabPage();
      this.grpSiteFuel = new GroupBox();
      this.btnMoreInfo = new Button();
      this.dgSiteFuel = new DataGrid();
      this.grpSite = new GroupBox();
      this.txtDDRef = new TextBox();
      this.lblDDRef = new Label();
      this.cboAccomType = new ComboBox();
      this.lblAccomType = new Label();
      this.dtpDefectEndDate = new DateTimePicker();
      this.lblDefectEndDate = new Label();
      this.txtSiteDefects = new TextBox();
      this.lblSiteDefects = new Label();
      this.txtPropertyVoidDate = new TextBox();
      this.lblPropertyVoidDate = new Label();
      this.txtActualServiceDate = new TextBox();
      this.Label17 = new Label();
      this.txtLastServiceDate = new TextBox();
      this.Label16 = new Label();
      this.chkVoid = new CheckBox();
      this.txtFirstName = new TextBox();
      this.txtAlert = new TextBox();
      this.Label21 = new Label();
      this.Label20 = new Label();
      this.txtAsbestos = new TextBox();
      this.btnConvCust = new Button();
      this.Label19 = new Label();
      this.txtSurname = new TextBox();
      this.cboRegionID = new ComboBox();
      this.txtPolicyNumber = new TextBox();
      this.Label12 = new Label();
      this.txtTelephoneNum = new TextBox();
      this.lblTelephoneNum = new Label();
      this.txtAddress4 = new TextBox();
      this.lblTown = new Label();
      this.txtEmailAddress = new TextBox();
      this.lblEmailAddress = new Label();
      this.cboSalutation = new ComboBox();
      this.Label18 = new Label();
      this.txtAddress2 = new TextBox();
      this.lblAddress2 = new Label();
      this.btnAddModifyPlan = new Button();
      this.chkCommercialDistrict = new CheckBox();
      this.chkLeaseHolder = new CheckBox();
      this.chkNoService = new CheckBox();
      this.chkSolidFuel = new CheckBox();
      this.chkOnStop = new CheckBox();
      this.txtContractStatus = new TextBox();
      this.lblNotes = new Label();
      this.chkNoMarketing = new CheckBox();
      this.btnSendEmailToSite = new Button();
      this.btnCustomerAudit = new Button();
      this.btnDomestic = new Button();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.Label10 = new Label();
      this.txtName = new TextBox();
      this.Label3 = new Label();
      this.chkHeadOffice = new CheckBox();
      this.txtNotes = new TextBox();
      this.txtAddress1 = new TextBox();
      this.lblAddress1 = new Label();
      this.txtAddress3 = new TextBox();
      this.lblAddress3 = new Label();
      this.txtAddress5 = new TextBox();
      this.lblCounty = new Label();
      this.txtPostcode = new TextBox();
      this.lblPostcode = new Label();
      this.txtFaxNum = new TextBox();
      this.lblFaxNum = new Label();
      this.lblContractInactive = new Label();
      this.Label14 = new Label();
      this.lblRegionID = new Label();
      this.GroupBox4 = new GroupBox();
      this.btnSiteReport = new Button();
      this.btnShowVisits = new Button();
      this.cboDefinition = new ComboBox();
      this.Label9 = new Label();
      this.txtJobNumber = new TextBox();
      this.Label7 = new Label();
      this.dtpTo = new DateTimePicker();
      this.Label6 = new Label();
      this.dtpFrom = new DateTimePicker();
      this.Label5 = new Label();
      this.dgJobs = new DataGrid();
      this.btnAddJob = new Button();
      this.btnShowAllJobs = new Button();
      this.btnRemoveJob = new Button();
      this.TabNewContacts = new TabPage();
      this.pnlContactsMain = new FlowLayoutPanel();
      this.tabCharges = new TabPage();
      this.gpbCharges = new GroupBox();
      this.chbAcceptChargeChanges = new CheckBox();
      this.pnlCharges = new Panel();
      this.Label2 = new Label();
      this.txtRatesMarkup = new TextBox();
      this.Label4 = new Label();
      this.Label8 = new Label();
      this.txtMileageRate = new TextBox();
      this.txtPartsMarkup = new TextBox();
      this.tabContacts = new TabPage();
      this.btnPrintLetters = new Button();
      this.btnEmail = new Button();
      this.GroupBox1 = new GroupBox();
      this.dgContacts = new DataGrid();
      this.btnDeleteContact = new Button();
      this.btnAddContact = new Button();
      this.tabInvoiceAddress = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.dgInvoiceAddresses = new DataGrid();
      this.btnDeleteAddress = new Button();
      this.btnAddAddress = new Button();
      this.tabDocuments = new TabPage();
      this.pnlDocuments = new Panel();
      this.tabQuotes = new TabPage();
      this.pnlQuotes = new Panel();
      this.tabContracts = new TabPage();
      this.gpbContracts = new GroupBox();
      this.btnDeleteContract = new Button();
      this.dgContracts = new DataGrid();
      this.btnAddContract = new Button();
      this.tpNotes = new TabPage();
      this.gpbNotesDetails = new GroupBox();
      this.txtNoteID = new TextBox();
      this.btnSaveNote = new Button();
      this.txtNote = new TextBox();
      this.Label15 = new Label();
      this.gpbNotes = new GroupBox();
      this.btnDeleteNote = new Button();
      this.dgNotes = new DataGrid();
      this.btnAddNote = new Button();
      this.tabAuthority = new TabPage();
      this.grpSiteAuth = new GroupBox();
      this.btnSaveAuth = new Button();
      this.txtSiteAuth = new TextBox();
      this.gpCustAuth = new GroupBox();
      this.txtCustAuthority = new TextBox();
      this.grpAudit = new GroupBox();
      this.dgAuthorityAudit = new DataGrid();
      this.tpAdditionalDetails = new TabPage();
      this.grpAdditionalDetails = new GroupBox();
      this.btnLetterReport = new Button();
      this.cboReasonForContact = new ComboBox();
      this.Label11 = new Label();
      this.Label13 = new Label();
      this.cboSourceOfCustomer = new ComboBox();
      this.txtEstateOfficer = new TextBox();
      this.lblEstateOfficer = new Label();
      this.txtHousingManager = new TextBox();
      this.lblHousingManager = new Label();
      this.txtHousingOfficer = new TextBox();
      this.lblHousingOfficer = new Label();
      this.dtpBuildDate = new DateTimePicker();
      this.lblBuildDate = new Label();
      this.txtWarrantyPeriod = new TextBox();
      this.lblWarrantyPeriod = new Label();
      this.ttSiteFuel = new ToolTip(this.components);
      this.cmsJobs = new ContextMenuStrip(this.components);
      this.tsmiMoveJob = new ToolStripMenuItem();
      this.tcSites.SuspendLayout();
      this.tabDetails.SuspendLayout();
      this.grpSiteFuel.SuspendLayout();
      this.dgSiteFuel.BeginInit();
      this.grpSite.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      this.dgJobs.BeginInit();
      this.TabNewContacts.SuspendLayout();
      this.tabCharges.SuspendLayout();
      this.gpbCharges.SuspendLayout();
      this.tabContacts.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.dgContacts.BeginInit();
      this.tabInvoiceAddress.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.dgInvoiceAddresses.BeginInit();
      this.tabDocuments.SuspendLayout();
      this.tabQuotes.SuspendLayout();
      this.tabContracts.SuspendLayout();
      this.gpbContracts.SuspendLayout();
      this.dgContracts.BeginInit();
      this.tpNotes.SuspendLayout();
      this.gpbNotesDetails.SuspendLayout();
      this.gpbNotes.SuspendLayout();
      this.dgNotes.BeginInit();
      this.tabAuthority.SuspendLayout();
      this.grpSiteAuth.SuspendLayout();
      this.gpCustAuth.SuspendLayout();
      this.grpAudit.SuspendLayout();
      this.dgAuthorityAudit.BeginInit();
      this.tpAdditionalDetails.SuspendLayout();
      this.grpAdditionalDetails.SuspendLayout();
      this.cmsJobs.SuspendLayout();
      this.SuspendLayout();
      this.tcSites.Controls.Add((Control) this.tabDetails);
      this.tcSites.Controls.Add((Control) this.TabNewContacts);
      this.tcSites.Controls.Add((Control) this.tabCharges);
      this.tcSites.Controls.Add((Control) this.tabContacts);
      this.tcSites.Controls.Add((Control) this.tabInvoiceAddress);
      this.tcSites.Controls.Add((Control) this.tabDocuments);
      this.tcSites.Controls.Add((Control) this.tabQuotes);
      this.tcSites.Controls.Add((Control) this.tabContracts);
      this.tcSites.Controls.Add((Control) this.tpNotes);
      this.tcSites.Controls.Add((Control) this.tabAuthority);
      this.tcSites.Controls.Add((Control) this.tpAdditionalDetails);
      this.tcSites.Dock = DockStyle.Fill;
      this.tcSites.Location = new System.Drawing.Point(0, 0);
      this.tcSites.Name = "tcSites";
      this.tcSites.SelectedIndex = 0;
      this.tcSites.Size = new Size(1080, 666);
      this.tcSites.TabIndex = 0;
      this.tabDetails.Controls.Add((Control) this.grpSiteFuel);
      this.tabDetails.Controls.Add((Control) this.grpSite);
      this.tabDetails.Controls.Add((Control) this.GroupBox4);
      this.tabDetails.Location = new System.Drawing.Point(4, 22);
      this.tabDetails.Name = "tabDetails";
      this.tabDetails.Size = new Size(1072, 640);
      this.tabDetails.TabIndex = 0;
      this.tabDetails.Text = "Main Details";
      this.grpSiteFuel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSiteFuel.Controls.Add((Control) this.btnMoreInfo);
      this.grpSiteFuel.Controls.Add((Control) this.dgSiteFuel);
      this.grpSiteFuel.Location = new System.Drawing.Point(588, 421);
      this.grpSiteFuel.Margin = new Padding(0);
      this.grpSiteFuel.Name = "grpSiteFuel";
      this.grpSiteFuel.Padding = new Padding(0);
      this.grpSiteFuel.Size = new Size(476, 219);
      this.grpSiteFuel.TabIndex = 13;
      this.grpSiteFuel.TabStop = false;
      this.grpSiteFuel.Text = "Site Fuel";
      this.btnMoreInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnMoreInfo.Location = new System.Drawing.Point(371, 19);
      this.btnMoreInfo.Name = "btnMoreInfo";
      this.btnMoreInfo.Size = new Size(96, 23);
      this.btnMoreInfo.TabIndex = 12;
      this.btnMoreInfo.Text = "Update Fuels";
      this.dgSiteFuel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSiteFuel.DataMember = "";
      this.dgSiteFuel.HeaderForeColor = SystemColors.ControlText;
      this.dgSiteFuel.Location = new System.Drawing.Point(5, 19);
      this.dgSiteFuel.Name = "dgSiteFuel";
      this.dgSiteFuel.Size = new Size(360, 195);
      this.dgSiteFuel.TabIndex = 11;
      this.grpSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSite.Controls.Add((Control) this.txtDDRef);
      this.grpSite.Controls.Add((Control) this.lblDDRef);
      this.grpSite.Controls.Add((Control) this.cboAccomType);
      this.grpSite.Controls.Add((Control) this.lblAccomType);
      this.grpSite.Controls.Add((Control) this.dtpDefectEndDate);
      this.grpSite.Controls.Add((Control) this.lblDefectEndDate);
      this.grpSite.Controls.Add((Control) this.txtSiteDefects);
      this.grpSite.Controls.Add((Control) this.lblSiteDefects);
      this.grpSite.Controls.Add((Control) this.txtPropertyVoidDate);
      this.grpSite.Controls.Add((Control) this.lblPropertyVoidDate);
      this.grpSite.Controls.Add((Control) this.txtActualServiceDate);
      this.grpSite.Controls.Add((Control) this.Label17);
      this.grpSite.Controls.Add((Control) this.txtLastServiceDate);
      this.grpSite.Controls.Add((Control) this.Label16);
      this.grpSite.Controls.Add((Control) this.chkVoid);
      this.grpSite.Controls.Add((Control) this.txtFirstName);
      this.grpSite.Controls.Add((Control) this.txtAlert);
      this.grpSite.Controls.Add((Control) this.Label21);
      this.grpSite.Controls.Add((Control) this.Label20);
      this.grpSite.Controls.Add((Control) this.txtAsbestos);
      this.grpSite.Controls.Add((Control) this.btnConvCust);
      this.grpSite.Controls.Add((Control) this.Label19);
      this.grpSite.Controls.Add((Control) this.txtSurname);
      this.grpSite.Controls.Add((Control) this.cboRegionID);
      this.grpSite.Controls.Add((Control) this.txtPolicyNumber);
      this.grpSite.Controls.Add((Control) this.Label12);
      this.grpSite.Controls.Add((Control) this.txtTelephoneNum);
      this.grpSite.Controls.Add((Control) this.lblTelephoneNum);
      this.grpSite.Controls.Add((Control) this.txtAddress4);
      this.grpSite.Controls.Add((Control) this.lblTown);
      this.grpSite.Controls.Add((Control) this.txtEmailAddress);
      this.grpSite.Controls.Add((Control) this.lblEmailAddress);
      this.grpSite.Controls.Add((Control) this.cboSalutation);
      this.grpSite.Controls.Add((Control) this.Label18);
      this.grpSite.Controls.Add((Control) this.txtAddress2);
      this.grpSite.Controls.Add((Control) this.lblAddress2);
      this.grpSite.Controls.Add((Control) this.btnAddModifyPlan);
      this.grpSite.Controls.Add((Control) this.chkCommercialDistrict);
      this.grpSite.Controls.Add((Control) this.chkLeaseHolder);
      this.grpSite.Controls.Add((Control) this.chkNoService);
      this.grpSite.Controls.Add((Control) this.chkSolidFuel);
      this.grpSite.Controls.Add((Control) this.chkOnStop);
      this.grpSite.Controls.Add((Control) this.txtContractStatus);
      this.grpSite.Controls.Add((Control) this.lblNotes);
      this.grpSite.Controls.Add((Control) this.chkNoMarketing);
      this.grpSite.Controls.Add((Control) this.btnSendEmailToSite);
      this.grpSite.Controls.Add((Control) this.btnCustomerAudit);
      this.grpSite.Controls.Add((Control) this.btnDomestic);
      this.grpSite.Controls.Add((Control) this.btnFindCustomer);
      this.grpSite.Controls.Add((Control) this.txtCustomer);
      this.grpSite.Controls.Add((Control) this.Label10);
      this.grpSite.Controls.Add((Control) this.txtName);
      this.grpSite.Controls.Add((Control) this.Label3);
      this.grpSite.Controls.Add((Control) this.chkHeadOffice);
      this.grpSite.Controls.Add((Control) this.txtNotes);
      this.grpSite.Controls.Add((Control) this.txtAddress1);
      this.grpSite.Controls.Add((Control) this.lblAddress1);
      this.grpSite.Controls.Add((Control) this.txtAddress3);
      this.grpSite.Controls.Add((Control) this.lblAddress3);
      this.grpSite.Controls.Add((Control) this.txtAddress5);
      this.grpSite.Controls.Add((Control) this.lblCounty);
      this.grpSite.Controls.Add((Control) this.txtPostcode);
      this.grpSite.Controls.Add((Control) this.lblPostcode);
      this.grpSite.Controls.Add((Control) this.txtFaxNum);
      this.grpSite.Controls.Add((Control) this.lblFaxNum);
      this.grpSite.Controls.Add((Control) this.lblContractInactive);
      this.grpSite.Controls.Add((Control) this.Label14);
      this.grpSite.Controls.Add((Control) this.lblRegionID);
      this.grpSite.Location = new System.Drawing.Point(3, 2);
      this.grpSite.Name = "grpSite";
      this.grpSite.Size = new Size(1061, 416);
      this.grpSite.TabIndex = 0;
      this.grpSite.TabStop = false;
      this.grpSite.Text = "Main Details";
      this.txtDDRef.Location = new System.Drawing.Point(855, 195);
      this.txtDDRef.MaxLength = 100;
      this.txtDDRef.Name = "txtDDRef";
      this.txtDDRef.Size = new Size(145, 21);
      this.txtDDRef.TabIndex = 128;
      this.txtDDRef.Tag = (object) "";
      this.lblDDRef.Location = new System.Drawing.Point(792, 199);
      this.lblDDRef.Name = "lblDDRef";
      this.lblDDRef.Size = new Size(61, 20);
      this.lblDDRef.TabIndex = 129;
      this.lblDDRef.Text = "DD Ref";
      this.lblDDRef.UseMnemonic = false;
      this.cboAccomType.Cursor = Cursors.Hand;
      this.cboAccomType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAccomType.Location = new System.Drawing.Point(789, 225);
      this.cboAccomType.Name = "cboAccomType";
      this.cboAccomType.Size = new Size(145, 21);
      this.cboAccomType.TabIndex = 122;
      this.cboAccomType.Tag = (object) "Site.RegionID";
      this.lblAccomType.Location = new System.Drawing.Point(643, 229);
      this.lblAccomType.Name = "lblAccomType";
      this.lblAccomType.Size = new Size(140, 23);
      this.lblAccomType.TabIndex = 121;
      this.lblAccomType.Text = "Accommodation Type";
      this.dtpDefectEndDate.Location = new System.Drawing.Point(855, 383);
      this.dtpDefectEndDate.Name = "dtpDefectEndDate";
      this.dtpDefectEndDate.Size = new Size(151, 21);
      this.dtpDefectEndDate.TabIndex = 120;
      this.lblDefectEndDate.Location = new System.Drawing.Point(730, 386);
      this.lblDefectEndDate.Name = "lblDefectEndDate";
      this.lblDefectEndDate.Size = new Size(119, 20);
      this.lblDefectEndDate.TabIndex = 119;
      this.lblDefectEndDate.Text = "Defect End Date";
      this.txtSiteDefects.Location = new System.Drawing.Point(534, 383);
      this.txtSiteDefects.MaxLength = 100;
      this.txtSiteDefects.Name = "txtSiteDefects";
      this.txtSiteDefects.RightToLeft = RightToLeft.No;
      this.txtSiteDefects.Size = new Size(181, 21);
      this.txtSiteDefects.TabIndex = 118;
      this.txtSiteDefects.Tag = (object) "";
      this.lblSiteDefects.Location = new System.Drawing.Point(419, 386);
      this.lblSiteDefects.Name = "lblSiteDefects";
      this.lblSiteDefects.Size = new Size(119, 20);
      this.lblSiteDefects.TabIndex = 117;
      this.lblSiteDefects.Text = "Defect Contractor";
      this.txtPropertyVoidDate.BackColor = SystemColors.Control;
      this.txtPropertyVoidDate.Location = new System.Drawing.Point(534, 225);
      this.txtPropertyVoidDate.Name = "txtPropertyVoidDate";
      this.txtPropertyVoidDate.ReadOnly = true;
      this.txtPropertyVoidDate.Size = new Size(89, 21);
      this.txtPropertyVoidDate.TabIndex = 116;
      this.txtPropertyVoidDate.Visible = false;
      this.lblPropertyVoidDate.AutoSize = true;
      this.lblPropertyVoidDate.Location = new System.Drawing.Point(466, 228);
      this.lblPropertyVoidDate.Name = "lblPropertyVoidDate";
      this.lblPropertyVoidDate.Size = new Size(62, 13);
      this.lblPropertyVoidDate.TabIndex = 115;
      this.lblPropertyVoidDate.Text = "Void Date";
      this.lblPropertyVoidDate.Visible = false;
      this.txtActualServiceDate.Location = new System.Drawing.Point(328, 225);
      this.txtActualServiceDate.MaxLength = 100;
      this.txtActualServiceDate.Name = "txtActualServiceDate";
      this.txtActualServiceDate.ReadOnly = true;
      this.txtActualServiceDate.Size = new Size(123, 21);
      this.txtActualServiceDate.TabIndex = 112;
      this.txtActualServiceDate.Tag = (object) "";
      this.Label17.Location = new System.Drawing.Point(244, 229);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(128, 20);
      this.Label17.TabIndex = 111;
      this.Label17.Text = "Service Date";
      this.txtLastServiceDate.Location = new System.Drawing.Point(115, 225);
      this.txtLastServiceDate.MaxLength = 100;
      this.txtLastServiceDate.Name = "txtLastServiceDate";
      this.txtLastServiceDate.ReadOnly = true;
      this.txtLastServiceDate.Size = new Size(123, 21);
      this.txtLastServiceDate.TabIndex = 110;
      this.txtLastServiceDate.Tag = (object) "";
      this.Label16.Location = new System.Drawing.Point(3, 229);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(128, 20);
      this.Label16.TabIndex = 109;
      this.Label16.Text = "Service Due";
      this.chkVoid.AutoCheck = false;
      this.chkVoid.AutoSize = true;
      this.chkVoid.Location = new System.Drawing.Point(630, 199);
      this.chkVoid.Name = "chkVoid";
      this.chkVoid.Size = new Size(103, 17);
      this.chkVoid.TabIndex = 108;
      this.chkVoid.Text = "Void Property";
      this.chkVoid.UseVisualStyleBackColor = true;
      this.txtFirstName.Location = new System.Drawing.Point(328, 42);
      this.txtFirstName.MaxLength = (int) byte.MaxValue;
      this.txtFirstName.Name = "txtFirstName";
      this.txtFirstName.Size = new Size(146, 21);
      this.txtFirstName.TabIndex = 5;
      this.txtFirstName.Tag = (object) "";
      this.txtAlert.Location = new System.Drawing.Point(115, 383);
      this.txtAlert.MaxLength = 100;
      this.txtAlert.Name = "txtAlert";
      this.txtAlert.RightToLeft = RightToLeft.No;
      this.txtAlert.Size = new Size(298, 21);
      this.txtAlert.TabIndex = 105;
      this.txtAlert.Tag = (object) "";
      this.Label21.Location = new System.Drawing.Point(7, 386);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(102, 20);
      this.Label21.TabIndex = 104;
      this.Label21.Text = "Contact Alerts";
      this.Label20.Location = new System.Drawing.Point(7, 335);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(102, 20);
      this.Label20.TabIndex = 103;
      this.Label20.Text = "Asbestos Details";
      this.txtAsbestos.AcceptsReturn = true;
      this.txtAsbestos.Location = new System.Drawing.Point(115, 333);
      this.txtAsbestos.Multiline = true;
      this.txtAsbestos.Name = "txtAsbestos";
      this.txtAsbestos.ReadOnly = true;
      this.txtAsbestos.ScrollBars = ScrollBars.Vertical;
      this.txtAsbestos.Size = new Size(891, 45);
      this.txtAsbestos.TabIndex = 102;
      this.txtAsbestos.Tag = (object) "Site.Notes";
      this.btnConvCust.Location = new System.Drawing.Point(632, 15);
      this.btnConvCust.Name = "btnConvCust";
      this.btnConvCust.Size = new Size(146, 23);
      this.btnConvCust.TabIndex = 101;
      this.btnConvCust.Text = "Convert to Customer";
      this.btnConvCust.UseVisualStyleBackColor = true;
      this.Label19.Location = new System.Drawing.Point(8, 72);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(77, 20);
      this.Label19.TabIndex = 84;
      this.Label19.Text = "Surname";
      this.txtSurname.Location = new System.Drawing.Point(115, 67);
      this.txtSurname.MaxLength = (int) byte.MaxValue;
      this.txtSurname.Name = "txtSurname";
      this.txtSurname.Size = new Size(359, 21);
      this.txtSurname.TabIndex = 6;
      this.txtSurname.Tag = (object) "";
      this.cboRegionID.Cursor = Cursors.Hand;
      this.cboRegionID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegionID.Location = new System.Drawing.Point(328, 166);
      this.cboRegionID.Name = "cboRegionID";
      this.cboRegionID.Size = new Size(146, 21);
      this.cboRegionID.TabIndex = 64;
      this.cboRegionID.Tag = (object) "Site.RegionID";
      this.txtPolicyNumber.Location = new System.Drawing.Point(632, 122);
      this.txtPolicyNumber.MaxLength = 100;
      this.txtPolicyNumber.Name = "txtPolicyNumber";
      this.txtPolicyNumber.Size = new Size(223, 21);
      this.txtPolicyNumber.TabIndex = 16;
      this.txtPolicyNumber.Tag = (object) "";
      this.Label12.Location = new System.Drawing.Point(509, 125);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(112, 20);
      this.Label12.TabIndex = 81;
      this.Label12.Text = "Policy No/UPRN";
      this.txtTelephoneNum.Location = new System.Drawing.Point(632, 69);
      this.txtTelephoneNum.MaxLength = 50;
      this.txtTelephoneNum.Name = "txtTelephoneNum";
      this.txtTelephoneNum.Size = new Size(146, 21);
      this.txtTelephoneNum.TabIndex = 13;
      this.txtTelephoneNum.Tag = (object) "Site.TelephoneNum";
      this.lblTelephoneNum.Location = new System.Drawing.Point(509, 71);
      this.lblTelephoneNum.Name = "lblTelephoneNum";
      this.lblTelephoneNum.Size = new Size(107, 20);
      this.lblTelephoneNum.TabIndex = 79;
      this.lblTelephoneNum.Text = "Tel";
      this.txtAddress4.Location = new System.Drawing.Point(115, 141);
      this.txtAddress4.MaxLength = 100;
      this.txtAddress4.Name = "txtAddress4";
      this.txtAddress4.Size = new Size(146, 21);
      this.txtAddress4.TabIndex = 10;
      this.txtAddress4.Tag = (object) "Site.Town";
      this.lblTown.Location = new System.Drawing.Point(8, 143);
      this.lblTown.Name = "lblTown";
      this.lblTown.Size = new Size(72, 20);
      this.lblTown.TabIndex = 73;
      this.lblTown.Text = "Address 4";
      this.txtEmailAddress.Location = new System.Drawing.Point(632, 95);
      this.txtEmailAddress.MaxLength = 100;
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.Size = new Size(223, 21);
      this.txtEmailAddress.TabIndex = 15;
      this.txtEmailAddress.Tag = (object) "Site.EmailAddress";
      this.lblEmailAddress.Location = new System.Drawing.Point(510, 98);
      this.lblEmailAddress.Name = "lblEmailAddress";
      this.lblEmailAddress.Size = new Size(99, 20);
      this.lblEmailAddress.TabIndex = 71;
      this.lblEmailAddress.Text = "Email Address";
      this.cboSalutation.Cursor = Cursors.Hand;
      this.cboSalutation.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSalutation.Location = new System.Drawing.Point(116, 42);
      this.cboSalutation.Name = "cboSalutation";
      this.cboSalutation.Size = new Size(145, 21);
      this.cboSalutation.TabIndex = 54;
      this.cboSalutation.Tag = (object) "Site.RegionID";
      this.Label18.Location = new System.Drawing.Point(260, 45);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(72, 20);
      this.Label18.TabIndex = 59;
      this.Label18.Text = "First Name";
      this.txtAddress2.Location = new System.Drawing.Point(115, 117);
      this.txtAddress2.MaxLength = (int) byte.MaxValue;
      this.txtAddress2.Name = "txtAddress2";
      this.txtAddress2.Size = new Size(146, 21);
      this.txtAddress2.TabIndex = 8;
      this.txtAddress2.Tag = (object) "Site.Address2";
      this.lblAddress2.Location = new System.Drawing.Point(8, 120);
      this.lblAddress2.Name = "lblAddress2";
      this.lblAddress2.Size = new Size(94, 20);
      this.lblAddress2.TabIndex = 57;
      this.lblAddress2.Text = "Address 2";
      this.btnAddModifyPlan.BackColor = Color.LightGoldenrodYellow;
      this.btnAddModifyPlan.Cursor = Cursors.Hand;
      this.btnAddModifyPlan.Location = new System.Drawing.Point(814, 254);
      this.btnAddModifyPlan.Margin = new Padding(0);
      this.btnAddModifyPlan.Name = "btnAddModifyPlan";
      this.btnAddModifyPlan.Size = new Size(192, 23);
      this.btnAddModifyPlan.TabIndex = 68;
      this.btnAddModifyPlan.Text = "Add / Modify Coverplan";
      this.btnAddModifyPlan.UseVisualStyleBackColor = false;
      this.chkCommercialDistrict.AutoSize = true;
      this.chkCommercialDistrict.Enabled = false;
      this.chkCommercialDistrict.Location = new System.Drawing.Point(457, 199);
      this.chkCommercialDistrict.Name = "chkCommercialDistrict";
      this.chkCommercialDistrict.Size = new Size(140, 17);
      this.chkCommercialDistrict.TabIndex = 46;
      this.chkCommercialDistrict.Text = "Commercial/District";
      this.chkCommercialDistrict.UseVisualStyleBackColor = true;
      this.chkLeaseHolder.AutoSize = true;
      this.chkLeaseHolder.Enabled = false;
      this.chkLeaseHolder.Location = new System.Drawing.Point(328, 199);
      this.chkLeaseHolder.Name = "chkLeaseHolder";
      this.chkLeaseHolder.Size = new Size(100, 17);
      this.chkLeaseHolder.TabIndex = 45;
      this.chkLeaseHolder.Text = "Lease Holder";
      this.chkLeaseHolder.UseVisualStyleBackColor = true;
      this.chkNoService.AutoCheck = false;
      this.chkNoService.AutoSize = true;
      this.chkNoService.Location = new System.Drawing.Point(216, 199);
      this.chkNoService.Name = "chkNoService";
      this.chkNoService.Size = new Size(88, 17);
      this.chkNoService.TabIndex = 44;
      this.chkNoService.Text = "No Service";
      this.chkNoService.UseVisualStyleBackColor = true;
      this.chkSolidFuel.AutoSize = true;
      this.chkSolidFuel.Enabled = false;
      this.chkSolidFuel.Location = new System.Drawing.Point(115, 199);
      this.chkSolidFuel.Name = "chkSolidFuel";
      this.chkSolidFuel.Size = new Size(81, 17);
      this.chkSolidFuel.TabIndex = 43;
      this.chkSolidFuel.Text = "Solid Fuel";
      this.chkSolidFuel.UseVisualStyleBackColor = true;
      this.chkOnStop.AutoCheck = false;
      this.chkOnStop.Font = new Font("Verdana", 8f);
      this.chkOnStop.Location = new System.Drawing.Point(751, 148);
      this.chkOnStop.Name = "chkOnStop";
      this.chkOnStop.Size = new Size(82, 20);
      this.chkOnStop.TabIndex = 42;
      this.chkOnStop.Tag = (object) "Site.HeadOffice";
      this.chkOnStop.Text = "On Stop";
      this.txtContractStatus.Location = new System.Drawing.Point(116, (int) byte.MaxValue);
      this.txtContractStatus.MaxLength = 100;
      this.txtContractStatus.Name = "txtContractStatus";
      this.txtContractStatus.ReadOnly = true;
      this.txtContractStatus.Size = new Size(667, 21);
      this.txtContractStatus.TabIndex = 38;
      this.txtContractStatus.Tag = (object) "";
      this.lblNotes.Location = new System.Drawing.Point(3, 285);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(59, 20);
      this.lblNotes.TabIndex = 39;
      this.lblNotes.Text = "Notes";
      this.chkNoMarketing.Location = new System.Drawing.Point(847, 146);
      this.chkNoMarketing.Name = "chkNoMarketing";
      this.chkNoMarketing.Size = new Size(103, 24);
      this.chkNoMarketing.TabIndex = 32;
      this.chkNoMarketing.Text = "No Marketing";
      this.btnSendEmailToSite.Location = new System.Drawing.Point(861, 94);
      this.btnSendEmailToSite.Name = "btnSendEmailToSite";
      this.btnSendEmailToSite.Size = new Size(145, 23);
      this.btnSendEmailToSite.TabIndex = 25;
      this.btnSendEmailToSite.Text = "Email";
      this.btnCustomerAudit.Location = new System.Drawing.Point(861, 14);
      this.btnCustomerAudit.Name = "btnCustomerAudit";
      this.btnCustomerAudit.Size = new Size(145, 23);
      this.btnCustomerAudit.TabIndex = 4;
      this.btnCustomerAudit.Text = "Audit";
      this.btnDomestic.BackColor = SystemColors.Control;
      this.btnDomestic.Location = new System.Drawing.Point(341, 15);
      this.btnDomestic.Name = "btnDomestic";
      this.btnDomestic.Size = new Size(72, 23);
      this.btnDomestic.TabIndex = 2;
      this.btnDomestic.Text = "Domestic";
      this.btnDomestic.UseVisualStyleBackColor = false;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(419, 15);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(55, 23);
      this.btnFindCustomer.TabIndex = 3;
      this.btnFindCustomer.Text = "Search";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.txtCustomer.Enabled = false;
      this.txtCustomer.Location = new System.Drawing.Point(115, 16);
      this.txtCustomer.MaxLength = (int) byte.MaxValue;
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.Size = new Size(210, 21);
      this.txtCustomer.TabIndex = 1;
      this.txtCustomer.Tag = (object) "";
      this.Label10.Location = new System.Drawing.Point(8, 19);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(64, 20);
      this.Label10.TabIndex = 0;
      this.Label10.Text = "Customer";
      this.txtName.Location = new System.Drawing.Point(632, 43);
      this.txtName.MaxLength = (int) byte.MaxValue;
      this.txtName.Name = "txtName";
      this.txtName.ReadOnly = true;
      this.txtName.Size = new Size(374, 21);
      this.txtName.TabIndex = 100;
      this.txtName.Tag = (object) "";
      this.Label3.Location = new System.Drawing.Point(8, 46);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(122, 20);
      this.Label3.TabIndex = 5;
      this.Label3.Text = "Primary Contact";
      this.chkHeadOffice.AutoCheck = false;
      this.chkHeadOffice.Font = new Font("Verdana", 8f);
      this.chkHeadOffice.Location = new System.Drawing.Point(630, 148);
      this.chkHeadOffice.Name = "chkHeadOffice";
      this.chkHeadOffice.Size = new Size(104, 20);
      this.chkHeadOffice.TabIndex = 30;
      this.chkHeadOffice.Tag = (object) "Site.HeadOffice";
      this.chkHeadOffice.Text = "Head Office";
      this.txtNotes.Location = new System.Drawing.Point(116, 282);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Vertical;
      this.txtNotes.Size = new Size(890, 45);
      this.txtNotes.TabIndex = 37;
      this.txtNotes.Tag = (object) "Site.Notes";
      this.txtAddress1.Location = new System.Drawing.Point(115, 93);
      this.txtAddress1.MaxLength = (int) byte.MaxValue;
      this.txtAddress1.Name = "txtAddress1";
      this.txtAddress1.Size = new Size(359, 21);
      this.txtAddress1.TabIndex = 7;
      this.txtAddress1.Tag = (object) "Site.Address1";
      this.lblAddress1.Location = new System.Drawing.Point(8, 96);
      this.lblAddress1.Name = "lblAddress1";
      this.lblAddress1.Size = new Size(67, 20);
      this.lblAddress1.TabIndex = 7;
      this.lblAddress1.Text = "Address 1";
      this.txtAddress3.Location = new System.Drawing.Point(328, 117);
      this.txtAddress3.MaxLength = (int) byte.MaxValue;
      this.txtAddress3.Name = "txtAddress3";
      this.txtAddress3.Size = new Size(146, 21);
      this.txtAddress3.TabIndex = 9;
      this.txtAddress3.Tag = (object) "Site.Address3";
      this.lblAddress3.Location = new System.Drawing.Point(261, 120);
      this.lblAddress3.Name = "lblAddress3";
      this.lblAddress3.Size = new Size(64, 20);
      this.lblAddress3.TabIndex = 11;
      this.lblAddress3.Text = "Address 3";
      this.txtAddress5.Location = new System.Drawing.Point(328, 141);
      this.txtAddress5.MaxLength = 100;
      this.txtAddress5.Name = "txtAddress5";
      this.txtAddress5.Size = new Size(146, 21);
      this.txtAddress5.TabIndex = 11;
      this.txtAddress5.Tag = (object) "Site.County";
      this.lblCounty.Location = new System.Drawing.Point(262, 143);
      this.lblCounty.Name = "lblCounty";
      this.lblCounty.Size = new Size(64, 20);
      this.lblCounty.TabIndex = 15;
      this.lblCounty.Text = "Address 5";
      this.txtPostcode.Location = new System.Drawing.Point(115, 167);
      this.txtPostcode.MaxLength = 10;
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(146, 21);
      this.txtPostcode.TabIndex = 12;
      this.txtPostcode.Tag = (object) "Site.Postcode";
      this.lblPostcode.Location = new System.Drawing.Point(8, 167);
      this.lblPostcode.Name = "lblPostcode";
      this.lblPostcode.Size = new Size(73, 20);
      this.lblPostcode.TabIndex = 17;
      this.lblPostcode.Text = "Postcode";
      this.txtFaxNum.Location = new System.Drawing.Point(861, 68);
      this.txtFaxNum.MaxLength = 50;
      this.txtFaxNum.Name = "txtFaxNum";
      this.txtFaxNum.Size = new Size(145, 21);
      this.txtFaxNum.TabIndex = 14;
      this.txtFaxNum.Tag = (object) "Site.FaxNum";
      this.lblFaxNum.Location = new System.Drawing.Point(799, 72);
      this.lblFaxNum.Name = "lblFaxNum";
      this.lblFaxNum.Size = new Size(50, 20);
      this.lblFaxNum.TabIndex = 21;
      this.lblFaxNum.Text = "Mobile";
      this.lblContractInactive.BackColor = Color.Red;
      this.lblContractInactive.Location = new System.Drawing.Point(109, 252);
      this.lblContractInactive.Name = "lblContractInactive";
      this.lblContractInactive.Size = new Size(682, 27);
      this.lblContractInactive.TabIndex = 31;
      this.lblContractInactive.Visible = false;
      this.Label14.Location = new System.Drawing.Point(3, 257);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(93, 20);
      this.Label14.TabIndex = 37;
      this.Label14.Text = "Contract";
      this.lblRegionID.Location = new System.Drawing.Point(261, 166);
      this.lblRegionID.Name = "lblRegionID";
      this.lblRegionID.Size = new Size(62, 20);
      this.lblRegionID.TabIndex = 63;
      this.lblRegionID.Text = "Region";
      this.GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.GroupBox4.Controls.Add((Control) this.btnSiteReport);
      this.GroupBox4.Controls.Add((Control) this.btnShowVisits);
      this.GroupBox4.Controls.Add((Control) this.cboDefinition);
      this.GroupBox4.Controls.Add((Control) this.Label9);
      this.GroupBox4.Controls.Add((Control) this.txtJobNumber);
      this.GroupBox4.Controls.Add((Control) this.Label7);
      this.GroupBox4.Controls.Add((Control) this.dtpTo);
      this.GroupBox4.Controls.Add((Control) this.Label6);
      this.GroupBox4.Controls.Add((Control) this.dtpFrom);
      this.GroupBox4.Controls.Add((Control) this.Label5);
      this.GroupBox4.Controls.Add((Control) this.dgJobs);
      this.GroupBox4.Controls.Add((Control) this.btnAddJob);
      this.GroupBox4.Controls.Add((Control) this.btnShowAllJobs);
      this.GroupBox4.Controls.Add((Control) this.btnRemoveJob);
      this.GroupBox4.Location = new System.Drawing.Point(3, 421);
      this.GroupBox4.Margin = new Padding(0);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Padding = new Padding(0);
      this.GroupBox4.Size = new Size(575, 219);
      this.GroupBox4.TabIndex = 1;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Jobs";
      this.btnSiteReport.Location = new System.Drawing.Point(457, 161);
      this.btnSiteReport.Name = "btnSiteReport";
      this.btnSiteReport.Size = new Size(96, 23);
      this.btnSiteReport.TabIndex = 13;
      this.btnSiteReport.Text = "Site Report";
      this.btnSiteReport.UseVisualStyleBackColor = true;
      this.btnShowVisits.Location = new System.Drawing.Point(457, 132);
      this.btnShowVisits.Name = "btnShowVisits";
      this.btnShowVisits.Size = new Size(96, 23);
      this.btnShowVisits.TabIndex = 12;
      this.btnShowVisits.Text = "Show History";
      this.btnShowVisits.UseVisualStyleBackColor = true;
      this.cboDefinition.Location = new System.Drawing.Point(200, 40);
      this.cboDefinition.Name = "cboDefinition";
      this.cboDefinition.Size = new Size(104, 21);
      this.cboDefinition.TabIndex = 7;
      this.cboDefinition.Visible = false;
      this.Label9.Location = new System.Drawing.Point(152, 40);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(40, 23);
      this.Label9.TabIndex = 6;
      this.Label9.Text = "Def.:";
      this.Label9.Visible = false;
      this.txtJobNumber.Location = new System.Drawing.Point(350, 16);
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.Size = new Size(84, 21);
      this.txtJobNumber.TabIndex = 3;
      this.Label7.Location = new System.Drawing.Point(298, 19);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(67, 23);
      this.Label7.TabIndex = 2;
      this.Label7.Text = "Job No:";
      this.dtpTo.Checked = false;
      this.dtpTo.Format = DateTimePickerFormat.Short;
      this.dtpTo.Location = new System.Drawing.Point(186, 16);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.ShowCheckBox = true;
      this.dtpTo.Size = new Size(104, 21);
      this.dtpTo.TabIndex = 5;
      this.Label6.Location = new System.Drawing.Point(156, 19);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(24, 23);
      this.Label6.TabIndex = 4;
      this.Label6.Text = "To:";
      this.dtpFrom.Checked = false;
      this.dtpFrom.Format = DateTimePickerFormat.Short;
      this.dtpFrom.Location = new System.Drawing.Point(48, 16);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.ShowCheckBox = true;
      this.dtpFrom.Size = new Size(104, 21);
      this.dtpFrom.TabIndex = 1;
      this.Label5.Location = new System.Drawing.Point(8, 19);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(40, 23);
      this.Label5.TabIndex = 0;
      this.Label5.Text = "From:";
      this.dgJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.dgJobs.DataMember = "";
      this.dgJobs.HeaderForeColor = SystemColors.ControlText;
      this.dgJobs.Location = new System.Drawing.Point(5, 45);
      this.dgJobs.Name = "dgJobs";
      this.dgJobs.Size = new Size(431, 169);
      this.dgJobs.TabIndex = 11;
      this.btnAddJob.Location = new System.Drawing.Point(457, 45);
      this.btnAddJob.Name = "btnAddJob";
      this.btnAddJob.Size = new Size(96, 23);
      this.btnAddJob.TabIndex = 9;
      this.btnAddJob.Text = "Add";
      this.btnShowAllJobs.Location = new System.Drawing.Point(457, 103);
      this.btnShowAllJobs.Name = "btnShowAllJobs";
      this.btnShowAllJobs.Size = new Size(96, 23);
      this.btnShowAllJobs.TabIndex = 8;
      this.btnShowAllJobs.Text = "Show All";
      this.btnRemoveJob.Location = new System.Drawing.Point(457, 74);
      this.btnRemoveJob.Name = "btnRemoveJob";
      this.btnRemoveJob.Size = new Size(96, 23);
      this.btnRemoveJob.TabIndex = 10;
      this.btnRemoveJob.Text = "Delete";
      this.TabNewContacts.Controls.Add((Control) this.pnlContactsMain);
      this.TabNewContacts.Location = new System.Drawing.Point(4, 22);
      this.TabNewContacts.Name = "TabNewContacts";
      this.TabNewContacts.Padding = new Padding(3);
      this.TabNewContacts.Size = new Size(1072, 640);
      this.TabNewContacts.TabIndex = 13;
      this.TabNewContacts.Text = "Contacts";
      this.TabNewContacts.UseVisualStyleBackColor = true;
      this.pnlContactsMain.Dock = DockStyle.Fill;
      this.pnlContactsMain.Location = new System.Drawing.Point(3, 3);
      this.pnlContactsMain.Name = "pnlContactsMain";
      this.pnlContactsMain.Size = new Size(1066, 634);
      this.pnlContactsMain.TabIndex = 0;
      this.tabCharges.Controls.Add((Control) this.gpbCharges);
      this.tabCharges.Location = new System.Drawing.Point(4, 22);
      this.tabCharges.Name = "tabCharges";
      this.tabCharges.Size = new Size(1072, 640);
      this.tabCharges.TabIndex = 8;
      this.tabCharges.Text = "Charges";
      this.gpbCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbCharges.Controls.Add((Control) this.chbAcceptChargeChanges);
      this.gpbCharges.Controls.Add((Control) this.pnlCharges);
      this.gpbCharges.Controls.Add((Control) this.Label2);
      this.gpbCharges.Controls.Add((Control) this.txtRatesMarkup);
      this.gpbCharges.Controls.Add((Control) this.Label4);
      this.gpbCharges.Controls.Add((Control) this.Label8);
      this.gpbCharges.Controls.Add((Control) this.txtMileageRate);
      this.gpbCharges.Controls.Add((Control) this.txtPartsMarkup);
      this.gpbCharges.Location = new System.Drawing.Point(8, 8);
      this.gpbCharges.Name = "gpbCharges";
      this.gpbCharges.Size = new Size(1056, 626);
      this.gpbCharges.TabIndex = 60;
      this.gpbCharges.TabStop = false;
      this.gpbCharges.Text = "Charges";
      this.chbAcceptChargeChanges.BackColor = SystemColors.Info;
      this.chbAcceptChargeChanges.Location = new System.Drawing.Point(8, 16);
      this.chbAcceptChargeChanges.Name = "chbAcceptChargeChanges";
      this.chbAcceptChargeChanges.Size = new Size(480, 24);
      this.chbAcceptChargeChanges.TabIndex = 61;
      this.chbAcceptChargeChanges.Text = "Always accept changes to default charges made at customer level";
      this.chbAcceptChargeChanges.UseVisualStyleBackColor = false;
      this.pnlCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlCharges.Location = new System.Drawing.Point(8, 88);
      this.pnlCharges.Name = "pnlCharges";
      this.pnlCharges.Size = new Size(1040, 530);
      this.pnlCharges.TabIndex = 59;
      this.Label2.Location = new System.Drawing.Point(296, 48);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(88, 23);
      this.Label2.TabIndex = 58;
      this.Label2.Text = "Rates Markup";
      this.txtRatesMarkup.Location = new System.Drawing.Point(384, 48);
      this.txtRatesMarkup.Name = "txtRatesMarkup";
      this.txtRatesMarkup.Size = new Size(48, 21);
      this.txtRatesMarkup.TabIndex = 5;
      this.Label4.Location = new System.Drawing.Point(8, 48);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(95, 23);
      this.Label4.TabIndex = 48;
      this.Label4.Text = "Labour Markup";
      this.Label8.Location = new System.Drawing.Point(155, 48);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(88, 23);
      this.Label8.TabIndex = 56;
      this.Label8.Text = "Parts Markup";
      this.txtMileageRate.Location = new System.Drawing.Point(104, 48);
      this.txtMileageRate.Name = "txtMileageRate";
      this.txtMileageRate.Size = new Size(48, 21);
      this.txtMileageRate.TabIndex = 0;
      this.txtPartsMarkup.Location = new System.Drawing.Point(244, 48);
      this.txtPartsMarkup.Name = "txtPartsMarkup";
      this.txtPartsMarkup.Size = new Size(48, 21);
      this.txtPartsMarkup.TabIndex = 4;
      this.tabContacts.Controls.Add((Control) this.btnPrintLetters);
      this.tabContacts.Controls.Add((Control) this.btnEmail);
      this.tabContacts.Controls.Add((Control) this.GroupBox1);
      this.tabContacts.Controls.Add((Control) this.btnDeleteContact);
      this.tabContacts.Controls.Add((Control) this.btnAddContact);
      this.tabContacts.Location = new System.Drawing.Point(4, 22);
      this.tabContacts.Name = "tabContacts";
      this.tabContacts.Size = new Size(1072, 640);
      this.tabContacts.TabIndex = 3;
      this.tabContacts.Text = "Associated Contacts";
      this.btnPrintLetters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnPrintLetters.Location = new System.Drawing.Point(136, 612);
      this.btnPrintLetters.Name = "btnPrintLetters";
      this.btnPrintLetters.Size = new Size(112, 25);
      this.btnPrintLetters.TabIndex = 6;
      this.btnPrintLetters.Text = "Print Letters";
      this.btnEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnEmail.Location = new System.Drawing.Point(72, 612);
      this.btnEmail.Name = "btnEmail";
      this.btnEmail.Size = new Size(56, 25);
      this.btnEmail.TabIndex = 5;
      this.btnEmail.Text = "Email";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dgContacts);
      this.GroupBox1.Location = new System.Drawing.Point(8, 8);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(1056, 596);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Contacts";
      this.dgContacts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgContacts.DataMember = "";
      this.dgContacts.HeaderForeColor = SystemColors.ControlText;
      this.dgContacts.Location = new System.Drawing.Point(6, 20);
      this.dgContacts.Name = "dgContacts";
      this.dgContacts.Size = new Size(1045, 568);
      this.dgContacts.TabIndex = 1;
      this.btnDeleteContact.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeleteContact.Location = new System.Drawing.Point(1008, 612);
      this.btnDeleteContact.Name = "btnDeleteContact";
      this.btnDeleteContact.Size = new Size(56, 25);
      this.btnDeleteContact.TabIndex = 3;
      this.btnDeleteContact.Text = "Delete";
      this.btnAddContact.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddContact.Location = new System.Drawing.Point(8, 612);
      this.btnAddContact.Name = "btnAddContact";
      this.btnAddContact.Size = new Size(56, 25);
      this.btnAddContact.TabIndex = 2;
      this.btnAddContact.Text = "Add";
      this.tabInvoiceAddress.Controls.Add((Control) this.GroupBox2);
      this.tabInvoiceAddress.Controls.Add((Control) this.btnDeleteAddress);
      this.tabInvoiceAddress.Controls.Add((Control) this.btnAddAddress);
      this.tabInvoiceAddress.Location = new System.Drawing.Point(4, 22);
      this.tabInvoiceAddress.Name = "tabInvoiceAddress";
      this.tabInvoiceAddress.Size = new Size(1072, 640);
      this.tabInvoiceAddress.TabIndex = 4;
      this.tabInvoiceAddress.Text = "Invoice Addresses";
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.dgInvoiceAddresses);
      this.GroupBox2.Location = new System.Drawing.Point(8, 8);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(1056, 594);
      this.GroupBox2.TabIndex = 6;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Invoice Addresses";
      this.dgInvoiceAddresses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgInvoiceAddresses.DataMember = "";
      this.dgInvoiceAddresses.HeaderForeColor = SystemColors.ControlText;
      this.dgInvoiceAddresses.Location = new System.Drawing.Point(6, 20);
      this.dgInvoiceAddresses.Name = "dgInvoiceAddresses";
      this.dgInvoiceAddresses.Size = new Size(1045, 569);
      this.dgInvoiceAddresses.TabIndex = 1;
      this.btnDeleteAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeleteAddress.Location = new System.Drawing.Point(1000, 610);
      this.btnDeleteAddress.Name = "btnDeleteAddress";
      this.btnDeleteAddress.Size = new Size(64, 23);
      this.btnDeleteAddress.TabIndex = 3;
      this.btnDeleteAddress.Text = "Delete";
      this.btnAddAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddAddress.Location = new System.Drawing.Point(8, 610);
      this.btnAddAddress.Name = "btnAddAddress";
      this.btnAddAddress.Size = new Size(58, 23);
      this.btnAddAddress.TabIndex = 2;
      this.btnAddAddress.Text = "Add";
      this.tabDocuments.Controls.Add((Control) this.pnlDocuments);
      this.tabDocuments.Location = new System.Drawing.Point(4, 22);
      this.tabDocuments.Name = "tabDocuments";
      this.tabDocuments.Size = new Size(1072, 640);
      this.tabDocuments.TabIndex = 2;
      this.tabDocuments.Text = "Documents";
      this.pnlDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlDocuments.Location = new System.Drawing.Point(0, 0);
      this.pnlDocuments.Name = "pnlDocuments";
      this.pnlDocuments.Size = new Size(1072, 642);
      this.pnlDocuments.TabIndex = 1;
      this.tabQuotes.Controls.Add((Control) this.pnlQuotes);
      this.tabQuotes.Location = new System.Drawing.Point(4, 22);
      this.tabQuotes.Name = "tabQuotes";
      this.tabQuotes.Size = new Size(1072, 640);
      this.tabQuotes.TabIndex = 7;
      this.tabQuotes.Text = "Quotes";
      this.pnlQuotes.Dock = DockStyle.Fill;
      this.pnlQuotes.Location = new System.Drawing.Point(0, 0);
      this.pnlQuotes.Name = "pnlQuotes";
      this.pnlQuotes.Size = new Size(1072, 640);
      this.pnlQuotes.TabIndex = 1;
      this.tabContracts.Controls.Add((Control) this.gpbContracts);
      this.tabContracts.Location = new System.Drawing.Point(4, 22);
      this.tabContracts.Name = "tabContracts";
      this.tabContracts.Size = new Size(1072, 640);
      this.tabContracts.TabIndex = 9;
      this.tabContracts.Text = "Contracts";
      this.gpbContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbContracts.Controls.Add((Control) this.btnDeleteContract);
      this.gpbContracts.Controls.Add((Control) this.dgContracts);
      this.gpbContracts.Controls.Add((Control) this.btnAddContract);
      this.gpbContracts.Location = new System.Drawing.Point(8, 8);
      this.gpbContracts.Name = "gpbContracts";
      this.gpbContracts.Size = new Size(1056, 626);
      this.gpbContracts.TabIndex = 1;
      this.gpbContracts.TabStop = false;
      this.gpbContracts.Text = "Contract - Double click to view";
      this.btnDeleteContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeleteContract.Location = new System.Drawing.Point(973, 594);
      this.btnDeleteContract.Name = "btnDeleteContract";
      this.btnDeleteContract.Size = new Size(75, 23);
      this.btnDeleteContract.TabIndex = 2;
      this.btnDeleteContract.Text = "Delete";
      this.dgContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgContracts.DataMember = "";
      this.dgContracts.HeaderForeColor = SystemColors.ControlText;
      this.dgContracts.Location = new System.Drawing.Point(8, 20);
      this.dgContracts.Name = "dgContracts";
      this.dgContracts.Size = new Size(1040, 566);
      this.dgContracts.TabIndex = 1;
      this.btnAddContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddContract.Location = new System.Drawing.Point(8, 594);
      this.btnAddContract.Name = "btnAddContract";
      this.btnAddContract.Size = new Size(75, 23);
      this.btnAddContract.TabIndex = 0;
      this.btnAddContract.Text = "Add";
      this.btnAddContract.UseVisualStyleBackColor = true;
      this.tpNotes.Controls.Add((Control) this.gpbNotesDetails);
      this.tpNotes.Controls.Add((Control) this.gpbNotes);
      this.tpNotes.Location = new System.Drawing.Point(4, 22);
      this.tpNotes.Name = "tpNotes";
      this.tpNotes.Padding = new Padding(3);
      this.tpNotes.Size = new Size(1072, 640);
      this.tpNotes.TabIndex = 10;
      this.tpNotes.Text = "Notes";
      this.gpbNotesDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbNotesDetails.Controls.Add((Control) this.txtNoteID);
      this.gpbNotesDetails.Controls.Add((Control) this.btnSaveNote);
      this.gpbNotesDetails.Controls.Add((Control) this.txtNote);
      this.gpbNotesDetails.Controls.Add((Control) this.Label15);
      this.gpbNotesDetails.Location = new System.Drawing.Point(6, 451);
      this.gpbNotesDetails.Name = "gpbNotesDetails";
      this.gpbNotesDetails.Size = new Size(1060, 183);
      this.gpbNotesDetails.TabIndex = 34;
      this.gpbNotesDetails.TabStop = false;
      this.gpbNotesDetails.Text = "Details";
      this.txtNoteID.Location = new System.Drawing.Point(66, 14);
      this.txtNoteID.Name = "txtNoteID";
      this.txtNoteID.Size = new Size(100, 21);
      this.txtNoteID.TabIndex = 36;
      this.txtNoteID.TabStop = false;
      this.txtNoteID.Visible = false;
      this.btnSaveNote.AccessibleDescription = "";
      this.btnSaveNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveNote.Location = new System.Drawing.Point(975, 154);
      this.btnSaveNote.Name = "btnSaveNote";
      this.btnSaveNote.Size = new Size(79, 23);
      this.btnSaveNote.TabIndex = 1;
      this.btnSaveNote.Text = "Save";
      this.txtNote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNote.Location = new System.Drawing.Point(6, 37);
      this.txtNote.Multiline = true;
      this.txtNote.Name = "txtNote";
      this.txtNote.ScrollBars = ScrollBars.Both;
      this.txtNote.Size = new Size(1048, 111);
      this.txtNote.TabIndex = 0;
      this.Label15.Location = new System.Drawing.Point(3, 20);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(88, 23);
      this.Label15.TabIndex = 34;
      this.Label15.Text = "Note:";
      this.gpbNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbNotes.Controls.Add((Control) this.btnDeleteNote);
      this.gpbNotes.Controls.Add((Control) this.dgNotes);
      this.gpbNotes.Controls.Add((Control) this.btnAddNote);
      this.gpbNotes.Location = new System.Drawing.Point(6, 6);
      this.gpbNotes.Name = "gpbNotes";
      this.gpbNotes.Size = new Size(1060, 439);
      this.gpbNotes.TabIndex = 31;
      this.gpbNotes.TabStop = false;
      this.gpbNotes.Text = "Notes";
      this.btnDeleteNote.AccessibleDescription = "";
      this.btnDeleteNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeleteNote.Location = new System.Drawing.Point(969, 410);
      this.btnDeleteNote.Name = "btnDeleteNote";
      this.btnDeleteNote.Size = new Size(85, 23);
      this.btnDeleteNote.TabIndex = 3;
      this.btnDeleteNote.Text = "Delete";
      this.btnDeleteNote.Visible = false;
      this.dgNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgNotes.DataMember = "";
      this.dgNotes.HeaderForeColor = SystemColors.ControlText;
      this.dgNotes.Location = new System.Drawing.Point(6, 20);
      this.dgNotes.Name = "dgNotes";
      this.dgNotes.Size = new Size(1048, 384);
      this.dgNotes.TabIndex = 1;
      this.btnAddNote.AccessibleDescription = "";
      this.btnAddNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddNote.Location = new System.Drawing.Point(6, 410);
      this.btnAddNote.Name = "btnAddNote";
      this.btnAddNote.Size = new Size(85, 23);
      this.btnAddNote.TabIndex = 2;
      this.btnAddNote.Text = "Add";
      this.tabAuthority.Controls.Add((Control) this.grpSiteAuth);
      this.tabAuthority.Controls.Add((Control) this.gpCustAuth);
      this.tabAuthority.Controls.Add((Control) this.grpAudit);
      this.tabAuthority.Location = new System.Drawing.Point(4, 22);
      this.tabAuthority.Name = "tabAuthority";
      this.tabAuthority.Size = new Size(1072, 640);
      this.tabAuthority.TabIndex = 11;
      this.tabAuthority.Text = "Authority";
      this.tabAuthority.UseVisualStyleBackColor = true;
      this.grpSiteAuth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSiteAuth.Controls.Add((Control) this.btnSaveAuth);
      this.grpSiteAuth.Controls.Add((Control) this.txtSiteAuth);
      this.grpSiteAuth.Location = new System.Drawing.Point(3, 117);
      this.grpSiteAuth.Name = "grpSiteAuth";
      this.grpSiteAuth.Size = new Size(1060, 207);
      this.grpSiteAuth.TabIndex = 37;
      this.grpSiteAuth.TabStop = false;
      this.grpSiteAuth.Text = "Site";
      this.btnSaveAuth.AccessibleDescription = "";
      this.btnSaveAuth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveAuth.Location = new System.Drawing.Point(969, 178);
      this.btnSaveAuth.Name = "btnSaveAuth";
      this.btnSaveAuth.Size = new Size(85, 23);
      this.btnSaveAuth.TabIndex = 3;
      this.btnSaveAuth.Text = "Save";
      this.txtSiteAuth.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSiteAuth.Location = new System.Drawing.Point(6, 20);
      this.txtSiteAuth.Multiline = true;
      this.txtSiteAuth.Name = "txtSiteAuth";
      this.txtSiteAuth.ScrollBars = ScrollBars.Both;
      this.txtSiteAuth.Size = new Size(1048, 152);
      this.txtSiteAuth.TabIndex = 0;
      this.gpCustAuth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpCustAuth.Controls.Add((Control) this.txtCustAuthority);
      this.gpCustAuth.Location = new System.Drawing.Point(3, 3);
      this.gpCustAuth.Name = "gpCustAuth";
      this.gpCustAuth.Size = new Size(1060, 108);
      this.gpCustAuth.TabIndex = 36;
      this.gpCustAuth.TabStop = false;
      this.gpCustAuth.Text = "Customer";
      this.txtCustAuthority.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustAuthority.Location = new System.Drawing.Point(6, 20);
      this.txtCustAuthority.Multiline = true;
      this.txtCustAuthority.Name = "txtCustAuthority";
      this.txtCustAuthority.ReadOnly = true;
      this.txtCustAuthority.ScrollBars = ScrollBars.Both;
      this.txtCustAuthority.Size = new Size(1048, 82);
      this.txtCustAuthority.TabIndex = 0;
      this.grpAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAudit.Controls.Add((Control) this.dgAuthorityAudit);
      this.grpAudit.Location = new System.Drawing.Point(3, 330);
      this.grpAudit.Name = "grpAudit";
      this.grpAudit.Size = new Size(1060, 307);
      this.grpAudit.TabIndex = 35;
      this.grpAudit.TabStop = false;
      this.grpAudit.Text = "Audit";
      this.dgAuthorityAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAuthorityAudit.DataMember = "";
      this.dgAuthorityAudit.HeaderForeColor = SystemColors.ControlText;
      this.dgAuthorityAudit.Location = new System.Drawing.Point(6, 20);
      this.dgAuthorityAudit.Name = "dgAuthorityAudit";
      this.dgAuthorityAudit.Size = new Size(1048, 281);
      this.dgAuthorityAudit.TabIndex = 1;
      this.tpAdditionalDetails.BackColor = SystemColors.Control;
      this.tpAdditionalDetails.Controls.Add((Control) this.grpAdditionalDetails);
      this.tpAdditionalDetails.Location = new System.Drawing.Point(4, 22);
      this.tpAdditionalDetails.Name = "tpAdditionalDetails";
      this.tpAdditionalDetails.Padding = new Padding(3);
      this.tpAdditionalDetails.Size = new Size(1072, 640);
      this.tpAdditionalDetails.TabIndex = 12;
      this.tpAdditionalDetails.Text = "Additional Details";
      this.grpAdditionalDetails.Controls.Add((Control) this.btnLetterReport);
      this.grpAdditionalDetails.Controls.Add((Control) this.cboReasonForContact);
      this.grpAdditionalDetails.Controls.Add((Control) this.Label11);
      this.grpAdditionalDetails.Controls.Add((Control) this.Label13);
      this.grpAdditionalDetails.Controls.Add((Control) this.cboSourceOfCustomer);
      this.grpAdditionalDetails.Controls.Add((Control) this.txtEstateOfficer);
      this.grpAdditionalDetails.Controls.Add((Control) this.lblEstateOfficer);
      this.grpAdditionalDetails.Controls.Add((Control) this.txtHousingManager);
      this.grpAdditionalDetails.Controls.Add((Control) this.lblHousingManager);
      this.grpAdditionalDetails.Controls.Add((Control) this.txtHousingOfficer);
      this.grpAdditionalDetails.Controls.Add((Control) this.lblHousingOfficer);
      this.grpAdditionalDetails.Controls.Add((Control) this.dtpBuildDate);
      this.grpAdditionalDetails.Controls.Add((Control) this.lblBuildDate);
      this.grpAdditionalDetails.Controls.Add((Control) this.txtWarrantyPeriod);
      this.grpAdditionalDetails.Controls.Add((Control) this.lblWarrantyPeriod);
      this.grpAdditionalDetails.Dock = DockStyle.Fill;
      this.grpAdditionalDetails.Location = new System.Drawing.Point(3, 3);
      this.grpAdditionalDetails.Name = "grpAdditionalDetails";
      this.grpAdditionalDetails.Size = new Size(1066, 634);
      this.grpAdditionalDetails.TabIndex = 0;
      this.grpAdditionalDetails.TabStop = false;
      this.grpAdditionalDetails.Text = "Additional Details";
      this.btnLetterReport.Location = new System.Drawing.Point(586, 29);
      this.btnLetterReport.Name = "btnLetterReport";
      this.btnLetterReport.Size = new Size(145, 23);
      this.btnLetterReport.TabIndex = 132;
      this.btnLetterReport.Text = "Letter Report";
      this.cboReasonForContact.Cursor = Cursors.Hand;
      this.cboReasonForContact.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboReasonForContact.Location = new System.Drawing.Point(136, 31);
      this.cboReasonForContact.Name = "cboReasonForContact";
      this.cboReasonForContact.Size = new Size(149, 21);
      this.cboReasonForContact.TabIndex = 131;
      this.cboReasonForContact.Tag = (object) "Site.RegionID";
      this.Label11.Location = new System.Drawing.Point(315, 34);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(71, 23);
      this.Label11.TabIndex = 128;
      this.Label11.Text = "Source";
      this.Label13.Location = new System.Drawing.Point(16, 34);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(129, 23);
      this.Label13.TabIndex = 130;
      this.Label13.Text = "Reason For Contact";
      this.cboSourceOfCustomer.Cursor = Cursors.Hand;
      this.cboSourceOfCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSourceOfCustomer.Location = new System.Drawing.Point(404, 31);
      this.cboSourceOfCustomer.Name = "cboSourceOfCustomer";
      this.cboSourceOfCustomer.Size = new Size(145, 21);
      this.cboSourceOfCustomer.TabIndex = 129;
      this.cboSourceOfCustomer.Tag = (object) "Site.RegionID";
      this.txtEstateOfficer.Location = new System.Drawing.Point(404, 114);
      this.txtEstateOfficer.MaxLength = 100;
      this.txtEstateOfficer.Name = "txtEstateOfficer";
      this.txtEstateOfficer.Size = new Size(145, 21);
      this.txtEstateOfficer.TabIndex = 124;
      this.txtEstateOfficer.Tag = (object) "";
      this.lblEstateOfficer.Location = new System.Drawing.Point(315, 117);
      this.lblEstateOfficer.Name = "lblEstateOfficer";
      this.lblEstateOfficer.Size = new Size(99, 20);
      this.lblEstateOfficer.TabIndex = 123;
      this.lblEstateOfficer.Text = "Estate Officer";
      this.txtHousingManager.Location = new System.Drawing.Point(136, 154);
      this.txtHousingManager.MaxLength = 100;
      this.txtHousingManager.Name = "txtHousingManager";
      this.txtHousingManager.Size = new Size(149, 21);
      this.txtHousingManager.TabIndex = 122;
      this.txtHousingManager.Tag = (object) "";
      this.lblHousingManager.Location = new System.Drawing.Point(16, 157);
      this.lblHousingManager.Name = "lblHousingManager";
      this.lblHousingManager.Size = new Size(110, 20);
      this.lblHousingManager.TabIndex = 121;
      this.lblHousingManager.Text = "Housing Manager";
      this.txtHousingOfficer.Location = new System.Drawing.Point(136, 114);
      this.txtHousingOfficer.MaxLength = 100;
      this.txtHousingOfficer.Name = "txtHousingOfficer";
      this.txtHousingOfficer.Size = new Size(149, 21);
      this.txtHousingOfficer.TabIndex = 118;
      this.txtHousingOfficer.Tag = (object) "";
      this.lblHousingOfficer.Location = new System.Drawing.Point(16, 117);
      this.lblHousingOfficer.Name = "lblHousingOfficer";
      this.lblHousingOfficer.Size = new Size(99, 20);
      this.lblHousingOfficer.TabIndex = 117;
      this.lblHousingOfficer.Text = "Housing Officer";
      this.dtpBuildDate.Location = new System.Drawing.Point(136, 71);
      this.dtpBuildDate.Name = "dtpBuildDate";
      this.dtpBuildDate.Size = new Size(149, 21);
      this.dtpBuildDate.TabIndex = 116;
      this.dtpBuildDate.Value = new DateTime(2019, 5, 22, 14, 54, 59, 0);
      this.lblBuildDate.Location = new System.Drawing.Point(16, 77);
      this.lblBuildDate.Name = "lblBuildDate";
      this.lblBuildDate.Size = new Size(88, 20);
      this.lblBuildDate.TabIndex = 115;
      this.lblBuildDate.Text = "Build Date";
      this.txtWarrantyPeriod.Location = new System.Drawing.Point(477, 74);
      this.txtWarrantyPeriod.MaxLength = 100;
      this.txtWarrantyPeriod.Name = "txtWarrantyPeriod";
      this.txtWarrantyPeriod.Size = new Size(72, 21);
      this.txtWarrantyPeriod.TabIndex = 114;
      this.txtWarrantyPeriod.Tag = (object) "";
      this.lblWarrantyPeriod.Location = new System.Drawing.Point(315, 77);
      this.lblWarrantyPeriod.Name = "lblWarrantyPeriod";
      this.lblWarrantyPeriod.Size = new Size(141, 20);
      this.lblWarrantyPeriod.TabIndex = 113;
      this.lblWarrantyPeriod.Text = "Warranty Period (mths)";
      this.cmsJobs.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.tsmiMoveJob
      });
      this.cmsJobs.Name = "cmsJobs";
      this.cmsJobs.Size = new Size(126, 26);
      this.tsmiMoveJob.Name = "tsmiMoveJob";
      this.tsmiMoveJob.Size = new Size(125, 22);
      this.tsmiMoveJob.Text = "Move Job";
      this.Controls.Add((Control) this.tcSites);
      this.Name = nameof (UCSite);
      this.Size = new Size(1080, 666);
      this.tcSites.ResumeLayout(false);
      this.tabDetails.ResumeLayout(false);
      this.grpSiteFuel.ResumeLayout(false);
      this.dgSiteFuel.EndInit();
      this.grpSite.ResumeLayout(false);
      this.grpSite.PerformLayout();
      this.GroupBox4.ResumeLayout(false);
      this.GroupBox4.PerformLayout();
      this.dgJobs.EndInit();
      this.TabNewContacts.ResumeLayout(false);
      this.tabCharges.ResumeLayout(false);
      this.gpbCharges.ResumeLayout(false);
      this.gpbCharges.PerformLayout();
      this.tabContacts.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.dgContacts.EndInit();
      this.tabInvoiceAddress.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.dgInvoiceAddresses.EndInit();
      this.tabDocuments.ResumeLayout(false);
      this.tabQuotes.ResumeLayout(false);
      this.tabContracts.ResumeLayout(false);
      this.gpbContracts.ResumeLayout(false);
      this.dgContracts.EndInit();
      this.tpNotes.ResumeLayout(false);
      this.gpbNotesDetails.ResumeLayout(false);
      this.gpbNotesDetails.PerformLayout();
      this.gpbNotes.ResumeLayout(false);
      this.dgNotes.EndInit();
      this.tabAuthority.ResumeLayout(false);
      this.grpSiteAuth.ResumeLayout(false);
      this.grpSiteAuth.PerformLayout();
      this.gpCustAuth.ResumeLayout(false);
      this.gpCustAuth.PerformLayout();
      this.grpAudit.ResumeLayout(false);
      this.dgAuthorityAudit.EndInit();
      this.tpAdditionalDetails.ResumeLayout(false);
      this.grpAdditionalDetails.ResumeLayout(false);
      this.grpAdditionalDetails.PerformLayout();
      this.cmsJobs.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.tcSites.TabPages.Clear();
      this.tcSites.TabPages.Add(this.tabDetails);
      if (App.IsGasway)
      {
        this.tcSites.TabPages.Add(this.tabContracts);
        this.tcSites.TabPages.Add(this.tabQuotes);
        this.tcSites.TabPages.Add(this.tabCharges);
      }
      this.tcSites.TabPages.Add(this.TabNewContacts);
      this.tcSites.TabPages.Add(this.tabContacts);
      this.tcSites.TabPages.Add(this.tabInvoiceAddress);
      this.tcSites.TabPages.Add(this.tabDocuments);
      this.tcSites.TabPages.Add(this.tpNotes);
      this.tcSites.TabPages.Add(this.tabAuthority);
      this.tcSites.TabPages.Add(this.tpAdditionalDetails);
      this.ContactControl = new UCContacts(this.CurrentSite);
      this.pnlContactsMain.Controls.Add((Control) this.ContactControl);
      this.SetupContactDataGrid();
      this.SetupInvoiceAddressDataGrid();
      this.SetupJobsDataGrid();
      this.SetupSiteFuelDataGrid();
      this.SetupContractsDataGrid();
      this.SetupNotesDataGrid();
      this.SetupSiteAuthorityAuditDataGrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentSite;
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

    public FSM.Entity.Customers.Customer CurrentCustomer
    {
      get
      {
        return this._currentCustomer;
      }
      set
      {
        this._currentCustomer = value;
        if (this._currentCustomer == null)
        {
          this._currentCustomer = new FSM.Entity.Customers.Customer();
          this._currentCustomer.Exists = false;
          Settings settings = new Settings();
          settings = App.DB.Manager.Get();
          this._currentCustomer.SetAcceptChargesChanges = (object) true;
        }
        if (this._currentCustomer.Exists)
          return;
        this.gpbContracts.Enabled = false;
      }
    }

    public FSM.Entity.Sites.Site CurrentSite
    {
      get
      {
        return this._currentSite;
      }
      set
      {
        this._currentSite = value;
        if (App.IsRFT)
        {
          this.btnDomestic.Visible = false;
          this.btnConvCust.Visible = false;
          this.btnLetterReport.Visible = false;
          this.chkSolidFuel.Visible = false;
          this.btnAddModifyPlan.Visible = false;
          this.tcSites.TabPages.Remove(this.tabQuotes);
        }
        if (this.CurrentSite == null)
        {
          this._currentSite = new FSM.Entity.Sites.Site();
          this._currentSite.Exists = false;
          CustomerCharge customerCharge = new CustomerCharge();
          CustomerCharge forCustomer = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(App.CurrentCustomerID);
          if (forCustomer != null)
          {
            this.txtMileageRate.Text = Conversions.ToString(forCustomer.MileageRate);
            this.txtPartsMarkup.Text = Conversions.ToString(forCustomer.PartsMarkup);
            this.txtRatesMarkup.Text = Conversions.ToString(forCustomer.RatesMarkup);
          }
          else
          {
            Settings settings1 = new Settings();
            Settings settings2 = App.DB.Manager.Get();
            this.txtMileageRate.Text = Conversions.ToString(settings2.MileageRate);
            this.txtPartsMarkup.Text = Conversions.ToString(settings2.PartsMarkup);
            this.txtRatesMarkup.Text = Conversions.ToString(settings2.RatesMarkup);
          }
          this.btnAddAddress.Enabled = false;
          this.btnDeleteAddress.Enabled = false;
          this.btnAddContact.Enabled = false;
          this.btnDeleteContact.Enabled = false;
          this.btnAddJob.Enabled = false;
          this.btnRemoveJob.Enabled = false;
          this.chbAcceptChargeChanges.Checked = true;
          if (App.CurrentCustomerID > 0)
          {
            this.CurrentSite.SetCustomerID = (object) App.CurrentCustomerID;
            this.PopulateCustomerField();
          }
        }
        if (this.CurrentSite.Exists)
        {
          this.CurrentCustomer = App.DB.Customer.Customer_Get(this.CurrentSite.CustomerID);
          this.Populate(0);
          this.pnlDocuments.Controls.Clear();
          this.DocumentsControl = new UCDocumentsList(Enums.TableNames.tblSite, this.CurrentSite.SiteID);
          this.pnlDocuments.Controls.Add((Control) this.DocumentsControl);
          this.pnlQuotes.Controls.Clear();
          this.QuotesControl = new UCQuotesList(Enums.TableNames.tblSite, this.CurrentSite.CustomerID, this.CurrentSite.SiteID);
          this.QuotesControl.RefreshJobs += new UCQuotesList.RefreshJobsEventHandler(this.PopulateJobs);
          this.pnlQuotes.Controls.Add((Control) this.QuotesControl);
          this.pnlCharges.Controls.Clear();
          this.CustomerScheduleOfRateControl = new UCCustomerScheduleOfRate(Enums.TableNames.tblCustomer, this.CurrentSite.CustomerID, true);
          this.pnlCharges.Controls.Add((Control) this.CustomerScheduleOfRateControl);
          this.Contracts = App.DB.ContractOriginal.GetAll_ForSite(this.CurrentSite.SiteID);
          this.gpbContracts.Enabled = true;
          this.btnAddAddress.Enabled = true;
          this.btnDeleteAddress.Enabled = true;
          this.btnAddContact.Enabled = true;
          this.btnDeleteContact.Enabled = true;
          this.btnAddJob.Enabled = true;
          this.btnRemoveJob.Enabled = true;
          this.cboSourceOfCustomer.Enabled = false;
          this.cboReasonForContact.Enabled = false;
          this.PopulateSiteNotes();
          this.gpbNotes.Enabled = true;
          this.gpbNotesDetails.Enabled = true;
          this.btnSaveNote.Enabled = true;
          this.btnAddNote.Enabled = true;
          this.btnDeleteNote.Enabled = true;
          this.btnLetterReport.Enabled = true;
        }
        else
        {
          this.cboSourceOfCustomer.Enabled = true;
          this.cboReasonForContact.Enabled = true;
          this.gpbNotes.Enabled = false;
          this.gpbNotesDetails.Enabled = false;
          this.btnSaveNote.Enabled = false;
          this.btnAddNote.Enabled = false;
          this.btnDeleteNote.Enabled = false;
          this.btnLetterReport.Enabled = false;
        }
        this.PopulateContacts();
        this.PopulateInvoiceAddresses();
        this.PopulateJobs();
      }
    }

    public DataView InvoiceAddressDataView
    {
      get
      {
        return this._dInvoiceTable;
      }
      set
      {
        this._dInvoiceTable = value;
        this._dInvoiceTable.Table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
        this._dInvoiceTable.AllowNew = false;
        this._dInvoiceTable.AllowEdit = false;
        this._dInvoiceTable.AllowDelete = false;
        this.dgInvoiceAddresses.DataSource = (object) this.InvoiceAddressDataView;
      }
    }

    private DataRow SelectedInvoiceAddressDataRow
    {
      get
      {
        return this.dgInvoiceAddresses.CurrentRowIndex != -1 ? this.InvoiceAddressDataView[this.dgInvoiceAddresses.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView ContactsDataView
    {
      get
      {
        return this._dcontactTable;
      }
      set
      {
        this._dcontactTable = value;
        this._dcontactTable.Table.TableName = Enums.TableNames.tblContact.ToString();
        this._dcontactTable.AllowNew = false;
        this._dcontactTable.AllowEdit = false;
        this._dcontactTable.AllowDelete = false;
        this.dgContacts.DataSource = (object) this.ContactsDataView;
      }
    }

    private DataRow SelectedContactDataRow
    {
      get
      {
        return this.dgContacts.CurrentRowIndex != -1 ? this.ContactsDataView[this.dgContacts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView JobsDataView
    {
      get
      {
        return this._jobsTable;
      }
      set
      {
        this._jobsTable = value;
        this._jobsTable.Table.TableName = Enums.TableNames.tblJob.ToString();
        this._jobsTable.AllowNew = false;
        this._jobsTable.AllowEdit = false;
        this._jobsTable.AllowDelete = false;
        this.dgJobs.DataSource = (object) this.JobsDataView;
      }
    }

    private DataRow SelectedJobDataRow
    {
      get
      {
        return this.dgJobs.CurrentRowIndex != -1 ? this.JobsDataView[this.dgJobs.CurrentRowIndex].Row : (DataRow) null;
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

    public FSM.Entity.Authority.Authority SiteAuthority
    {
      get
      {
        return this._oSiteAuthority;
      }
      set
      {
        this._oSiteAuthority = value;
      }
    }

    public void SetupContactDataGrid()
    {
      Helper.SetUpDataGrid(this.dgContacts, false);
      DataGridTableStyle tableStyle = this.dgContacts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "First Name";
      dataGridLabelColumn1.MappingName = "FirstName";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 160;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Surname";
      dataGridLabelColumn2.MappingName = "Surname";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 160;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Email";
      dataGridLabelColumn3.MappingName = "EmailAddress";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 120;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Telephone Number";
      dataGridLabelColumn4.MappingName = "TelephoneNum";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblContact.ToString();
      this.dgContacts.TableStyles.Add(tableStyle);
    }

    public void SetupInvoiceAddressDataGrid()
    {
      Helper.SetUpDataGrid(this.dgInvoiceAddresses, false);
      DataGridTableStyle tableStyle = this.dgInvoiceAddresses.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Address 1";
      dataGridLabelColumn1.MappingName = "Address1";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Address 2";
      dataGridLabelColumn2.MappingName = "Address2";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Address 3";
      dataGridLabelColumn3.MappingName = "Address3";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Address 4";
      dataGridLabelColumn4.MappingName = "Address4";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Address5";
      dataGridLabelColumn5.MappingName = "Address5";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Postcode";
      dataGridLabelColumn6.MappingName = "Postcode";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblInvoiceAddress.ToString();
      this.dgInvoiceAddresses.TableStyles.Add(tableStyle);
    }

    public void SetupJobsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgJobs, false);
      DataGridTableStyle tableStyle = this.dgJobs.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Created";
      dataGridLabelColumn1.MappingName = "DateCreated";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 75;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Job No";
      dataGridLabelColumn2.MappingName = "JobNumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Type";
      dataGridLabelColumn3.MappingName = "Type";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Visit Status";
      dataGridLabelColumn4.MappingName = "VisitStatus";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MM/yyyy";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Last Visit's Date";
      dataGridLabelColumn5.MappingName = "LastVisitDate";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblJob.ToString();
      this.dgJobs.TableStyles.Add(tableStyle);
    }

    public void SetupSiteFuelDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSiteFuel, false);
      DataGridTableStyle tableStyle = this.dgSiteFuel.TableStyles[0];
      DataGridSiteFuelColumn gridSiteFuelColumn1 = new DataGridSiteFuelColumn();
      gridSiteFuelColumn1.Format = "";
      gridSiteFuelColumn1.FormatInfo = (IFormatProvider) null;
      gridSiteFuelColumn1.HeaderText = "Fuel Type";
      gridSiteFuelColumn1.MappingName = "FuelType";
      gridSiteFuelColumn1.ReadOnly = true;
      gridSiteFuelColumn1.Width = 100;
      gridSiteFuelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridSiteFuelColumn1);
      DataGridSiteFuelColumn gridSiteFuelColumn2 = new DataGridSiteFuelColumn();
      gridSiteFuelColumn2.Format = "dd/MM/yyyy";
      gridSiteFuelColumn2.FormatInfo = (IFormatProvider) null;
      gridSiteFuelColumn2.HeaderText = "Service Due";
      gridSiteFuelColumn2.MappingName = "ServiceDue";
      gridSiteFuelColumn2.ReadOnly = true;
      gridSiteFuelColumn2.Width = 105;
      gridSiteFuelColumn2.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridSiteFuelColumn2);
      DataGridSiteFuelColumn gridSiteFuelColumn3 = new DataGridSiteFuelColumn();
      gridSiteFuelColumn3.Format = "dd/MM/yyyy";
      gridSiteFuelColumn3.FormatInfo = (IFormatProvider) null;
      gridSiteFuelColumn3.HeaderText = "Service Date";
      gridSiteFuelColumn3.MappingName = "ActualServiceDate";
      gridSiteFuelColumn3.ReadOnly = true;
      gridSiteFuelColumn3.Width = 105;
      gridSiteFuelColumn3.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridSiteFuelColumn3);
      DataGridSiteFuelColumn gridSiteFuelColumn4 = new DataGridSiteFuelColumn();
      gridSiteFuelColumn4.Format = "dd/MM/yyyy";
      gridSiteFuelColumn4.FormatInfo = (IFormatProvider) null;
      gridSiteFuelColumn4.HeaderText = "Charge Type";
      gridSiteFuelColumn4.MappingName = "FuelChargeType";
      gridSiteFuelColumn4.ReadOnly = true;
      gridSiteFuelColumn4.Width = 170;
      gridSiteFuelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridSiteFuelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblSiteFuel.ToString();
      this.dgSiteFuel.TableStyles.Add(tableStyle);
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
      dataGridLabelColumn3.Width = 100;
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
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Material Costs";
      dataGridLabelColumn7.MappingName = "PartCosts";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "C";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Labour Costs";
      dataGridLabelColumn8.MappingName = "LabourCosts";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 100;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "C";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Contract Payment Income";
      dataGridLabelColumn9.MappingName = "ContractPaymentIncome";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 120;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblContract.ToString();
      this.dgContracts.TableStyles.Add(tableStyle);
    }

    public void CheckServiceDate()
    {
      if (this.FlagShown || !(this.SiteFuelsDataView != null & !this.CurrentSite.CommercialDistrict))
        return;
      string empty = string.Empty;
      IEnumerator enumerator;
      try
      {
        enumerator = this.SiteFuelsDataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          empty += this.GenerateServiceMessage(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["LastServiceDate"])), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["FuelType"])), empty);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (Helper.IsStringEmpty((object) empty))
        empty += this.GenerateServiceMessage(Helper.MakeDateTimeValid((object) this.CurrentSite.LastServiceDate), Helper.MakeStringValid((object) this.CurrentSite.SiteFuel), empty);
      if (!string.IsNullOrEmpty(empty))
      {
        int num = (int) App.ShowMessage(empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.FlagShown = true;
      }
    }

    private string GenerateServiceMessage(DateTime serviceDate, string fuel, string message)
    {
      DateTime today = DateAndTime.Today;
      DateTime t2 = today.AddMonths(3);
      serviceDate = serviceDate.AddYears(1);
      fuel = Helper.IsStringEmpty((object) fuel) ? "N/A" : fuel;
      if (DateTime.Compare(serviceDate, today) >= 0 & DateTime.Compare(serviceDate, t2) <= 0)
      {
        if (!string.IsNullOrEmpty(message))
          message += "\r\n\r\n";
        message = message + fuel + " is due for service within the next 3 months";
      }
      else if (DateTime.Compare(serviceDate, DateTime.MinValue.AddYears(1)) != 0 && DateHelper.IsBetweenDates(Conversions.ToString(DateAndTime.Now.AddYears(-3)), Conversions.ToString(DateAndTime.Now), Conversions.ToString(serviceDate)))
      {
        if (!string.IsNullOrEmpty(message))
          message += "\r\n\r\n";
        message = message + fuel + " is Overdue";
      }
      return message;
    }

    private void btnAddContract_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMContractOriginal), true, new object[3]
      {
        (object) 0,
        (object) Helper.MakeIntegerValid((object) this.CurrentSite.CustomerID),
        (object) Helper.MakeIntegerValid((object) this.CurrentSite.SiteID)
      }, false);
      this.Contracts = App.DB.ContractOriginal.GetAll_ForSite(this.CurrentSite.SiteID);
    }

    private void btnDeleteContract_Click(object sender, EventArgs e)
    {
      if (this.SelectedContractDataRow == null || App.ShowMessage("Are you sure you want to delete this contract - any contract jobs not yet downloaded will be remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      if (this.DeleteOption1())
      {
        this.Contracts = App.DB.ContractOriginal.GetAll_ForSite(this.CurrentSite.SiteID);
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
      App.ShowForm(typeof (FRMContractOriginal), true, new object[2]
      {
        (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractID"])),
        (object) Helper.MakeIntegerValid((object) this.CurrentSite.CustomerID)
      }, false);
      this.Contracts = App.DB.ContractOriginal.GetAll_ForSite(this.CurrentSite.SiteID);
    }

    private void cboDefinition_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.runFilters();
    }

    private void txtJobNumber_TextChanged(object sender, EventArgs e)
    {
      this.runFilters();
    }

    private void dtpFrom_ValueChanged(object sender, EventArgs e)
    {
      this.runFilters();
    }

    private void dtpTo_ValueChanged(object sender, EventArgs e)
    {
      this.runFilters();
    }

    private void btnShowAllJobs_Click(object sender, EventArgs e)
    {
      this.JobsDataView = App.DB.Job.Job_GetTop_For_Site(this.CurrentSite.SiteID, this.CurrentSite.CustomerID, 1000);
    }

    private void UCSite_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgContacts_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedContactDataRow == null)
        return;
      App.ShowForm(typeof (FRMContact), true, new object[3]
      {
        (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContactDataRow["ContactID"])),
        (object) this.CurrentSite.SiteID,
        (object) this
      }, false);
    }

    private void dgInvoiceAddresses_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedInvoiceAddressDataRow == null)
        return;
      App.ShowForm(typeof (FRMInvoiceAddress), true, new object[3]
      {
        (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressDataRow["InvoiceAddressID"])),
        (object) this.CurrentSite.SiteID,
        (object) this
      }, false);
    }

    private void btnAddContact_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMContact), true, new object[3]
      {
        (object) 0,
        (object) this.CurrentSite.SiteID,
        (object) this
      }, false);
    }

    private void btnAddAddress_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMInvoiceAddress), true, new object[3]
      {
        (object) 0,
        (object) this.CurrentSite.SiteID,
        (object) this
      }, false);
    }

    private void btnDeleteContact_Click(object sender, EventArgs e)
    {
      if (this.SelectedContactDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a contact to delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        App.DB.Contact.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContactDataRow["ContactID"])));
        this.ContactsDataView = App.DB.Contact.Contact_GetForSite(this.CurrentSite.SiteID);
      }
    }

    private void btnDeleteAddress_Click(object sender, EventArgs e)
    {
      if (this.SelectedInvoiceAddressDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select an invoice address to delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        App.DB.InvoiceAddress.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressDataRow["InvoiceAddressID"])));
        this.InvoiceAddressDataView = App.DB.InvoiceAddress.InvoiceAddress_GetForSite(this.CurrentSite.SiteID);
      }
    }

    private void dgJobs_Click(object sender, EventArgs e)
    {
      if (this.SelectedJobDataRow == null)
      {
        this.btnRemoveJob.Enabled = false;
      }
      else
      {
        switch (Conversions.ToInteger(this.SelectedJobDataRow["JobDefinitionEnumID"]))
        {
          case 1:
            this.btnRemoveJob.Enabled = true;
            break;
          case 2:
            this.btnRemoveJob.Enabled = true;
            break;
          case 3:
            this.btnRemoveJob.Enabled = true;
            break;
          case 4:
            this.btnRemoveJob.Enabled = true;
            break;
          default:
            this.btnRemoveJob.Enabled = false;
            break;
        }
      }
    }

    private void btnAddJob_Click(object sender, EventArgs e)
    {
      int status = App.DB.Customer.Customer_Get(this.CurrentSite.CustomerID).Status;
      Enums.SecuritySystemModules ssm = Enums.SecuritySystemModules.Finance;
      if (this.chkOnStop.Checked & !App.loggedInUser.HasAccessToModule(ssm))
        throw new SecurityException("This property is on stop and you do not have the necessary security permissions to change this.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      if (status == 3 & !App.loggedInUser.HasAccessToModule(ssm))
        throw new SecurityException("The customer is on hold and you do not have the necessary security permissions to change this.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      if (this.chkOnStop.Checked)
      {
        if (App.ShowMessage("This property is on stop. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
      }
      else if (status == 3 && App.ShowMessage("The customer is on hold. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      if (App.loggedInUser.UserRegions.Count > 0)
      {
        if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + Conversions.ToString(this.CurrentSite.RegionID)).Length < 1)
          throw new SecurityException("You do not have the necessary security permissions to add a job.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      }
      else if (this.CurrentSite.RegionID != App.loggedInUser.UserID)
        throw new SecurityException("You do not have the necessary security permissions to add a job.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      if (string.IsNullOrEmpty(this.CurrentSite.TelephoneNum) & string.IsNullOrEmpty(this.CurrentSite.FaxNum) & string.IsNullOrEmpty(this.CurrentSite.EmailAddress) && App.ShowMessage("The phone number/email address is missing from site. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No || (this.chkLeaseHolder.Checked | DateTime.Compare(this.dtpDefectEndDate.Value, DateAndTime.Now) >= 0) & !App.IsGasway && App.ShowMessage("There are warnings against the site!\r\n\r\nPlease refer to the notes.\r\n\r\nDo you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      App.ShowForm(typeof (FRMLogCallout), true, new object[3]
      {
        (object) 0,
        (object) this.CurrentSite.SiteID,
        (object) this
      }, false);
    }

    private void dgJobs_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedJobDataRow == null)
        return;
      App.ShowForm(typeof (FRMLogCallout), true, new object[3]
      {
        this.SelectedJobDataRow["JobID"],
        (object) this.CurrentSite.SiteID,
        (object) this
      }, false);
    }

    private void btnRemoveJob_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor))
        throw new SecurityException("You do not have the necessary security permissions to delete a job.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      if (App.loggedInUser.UserRegions.Count > 0)
      {
        if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + Conversions.ToString(this.CurrentSite.RegionID)).Length < 1)
          throw new SecurityException("You do not have the necessary security permissions to delete a job.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      }
      else if (this.CurrentSite.RegionID != App.loggedInUser.UserID)
        throw new SecurityException("You do not have the necessary security permissions to delete a job.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      if (this.SelectedJobDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a job to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.FSMAdmin))
        {
          if (Conversions.ToInteger(this.SelectedJobDataRow["StatusEnumID"]) != 1)
          {
            int num2 = (int) App.ShowMessage("Job has progressed passed 'Open' state so job cannot be deleted.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return;
          }
          if (!App.DB.Job.Job_Check_Before_Delete(Conversions.ToInteger(this.SelectedJobDataRow["JobID"])))
          {
            int num2 = (int) App.ShowMessage("At least 1 visit has progressed passed 'Ready' state so job cannot be deleted.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return;
          }
        }
        if (App.ShowMessage("Are you sure you want to remove this job from the system?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        App.DB.Job.Job_Delete(Conversions.ToInteger(this.SelectedJobDataRow["JobID"]));
        this.PopulateJobs();
      }
    }

    private void btnEmail_Click(object sender, EventArgs e)
    {
      if (this.SelectedContactDataRow == null)
        return;
      Process process = new Process();
      process.StartInfo.FileName = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "mailto:", this.SelectedContactDataRow["EmailAddress"]));
      process.StartInfo.UseShellExecute = true;
      process.StartInfo.RedirectStandardOutput = false;
      process.Start();
      process.Dispose();
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      if (this.CurrentSite != null && this.CurrentSite.Exists)
      {
        int customerTypeId = App.DB.Customer.Customer_Get(this.CurrentSite.CustomerID).CustomerTypeID;
        if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) & customerTypeId == 516)
          throw new SecurityException("You do not have the necessary security permissions to change site to customer.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      }
      this.SelectedCustomerID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if (this.SelectedCustomerID == 0)
        return;
      FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(this.SelectedCustomerID);
      if (customer != null && customer.Status == 3 && App.ShowMessage("Customer On Hold. Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      if (this.CurrentSite == null || !this.CurrentSite.Exists)
      {
        this.PopulateCustomerField();
      }
      else
      {
        if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) & customer.CustomerTypeID == 516)
          throw new SecurityException("You do not have the necessary security permissions to change site to customer.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
        if (App.ShowMessage("Update customer details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          App.DB.Sites.Update_Customer(this.CurrentSite.SiteID, this.CurrentSite.CustomerID, this.SelectedCustomerID);
          this.CurrentSite = App.DB.Sites.Get((object) this.CurrentSite.SiteID, SiteSQL.GetBy.SiteId, (object) null);
        }
      }
    }

    private void btnDomestic_Click(object sender, EventArgs e)
    {
      if (this.CurrentSite == null || !this.CurrentSite.Exists)
      {
        this.SelectedCustomerID = 787;
        this.PopulateCustomerField();
      }
      else
      {
        int customerTypeId = App.DB.Customer.Customer_Get(this.CurrentSite.CustomerID).CustomerTypeID;
        if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) & customerTypeId == 516)
          throw new SecurityException("You do not have the necessary security permissions to change site to customer.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
        this.SelectedCustomerID = 787;
        if (App.ShowMessage("Update customer details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          App.DB.Sites.Update_Customer(this.CurrentSite.SiteID, this.CurrentSite.CustomerID, this.SelectedCustomerID);
          this.CurrentSite = App.DB.Sites.Get((object) this.CurrentSite.SiteID, SiteSQL.GetBy.SiteId, (object) null);
        }
      }
    }

    private void btnCustomerAudit_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMSiteCustomerAudit), true, new object[1]
      {
        (object) this.CurrentSite.SiteID
      }, false);
    }

    private void btnSendEmailToSite_Click(object sender, EventArgs e)
    {
      Process process = new Process();
      process.StartInfo.FileName = "mailto:" + this.CurrentSite.EmailAddress;
      process.StartInfo.UseShellExecute = true;
      process.StartInfo.RedirectStandardOutput = false;
      process.Start();
      process.Dispose();
    }

    private void btnPrintLetters_Click(object sender, EventArgs e)
    {
      int num = 0;
      if (this.SelectedContactDataRow != null)
        num = Conversions.ToInteger(this.SelectedContactDataRow["ContactID"]);
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) num,
        (object) this.CurrentSite.SiteID
      }, "SiteLetter", Enums.SystemDocumentType.SiteLetter, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.pnlDocuments.Controls.Clear();
      this.DocumentsControl = new UCDocumentsList(Enums.TableNames.tblSite, this.CurrentSite.SiteID);
      this.pnlDocuments.Controls.Add((Control) this.DocumentsControl);
    }

    private void btnShowVisits_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMSiteVisitManager), true, new object[1]
      {
        (object) this.CurrentSite.SiteID
      }, false);
    }

    private void btnSiteReport_Click(object sender, EventArgs e)
    {
      PdfFactory.GenerateSiteHistoryReport(this.CurrentSite);
    }

    private void chkOnStop_Click(object sender, EventArgs e)
    {
      if (App.ControlLoading)
        return;
      App.ControlLoading = true;
      Enums.SecuritySystemModules ssm = Enums.SecuritySystemModules.Finance;
      if (!App.loggedInUser.HasAccessToModule(ssm))
      {
        string message = "You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.";
        App.ControlLoading = false;
        throw new SecurityException(message);
      }
      this.chkOnStop.Checked = !this.chkOnStop.Checked;
      App.ControlLoading = false;
    }

    private void chkNoService_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Servicing))
        throw new SecurityException("You do not have the necessary security permissions to adjust this setting.\r\nContact your administrator if you think this is wrong or you need the permissions changing.");
      if (this.chkNoService.Checked)
        this.chkNoService.Checked = false;
      else
        this.chkNoService.Checked = true;
    }

    private void ChkVoid_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Voids))
        throw new SecurityException("You do not have the necessary security permissions to adjust this setting.\r\nContact your administrator if you think this is wrong or you need the permissions changing.");
      if (this.CurrentSite.Exists)
      {
        if (this.chkVoid.Checked)
        {
          if (App.ShowMessage("This property is void. \r\nDo you want to reinstate?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
          if (App.ShowMessage("Would you like to use the previous contact information?. ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            DataView allForLink = App.DB.Contact.Contacts_GetAll_ForLink(24, this.CurrentSite.SiteID, true);
            if (allForLink.Count > 0)
            {
              EnumerableRowCollection<DataRow> source1 = allForLink.Table.AsEnumerable();
              Func<DataRow, int> keySelector;
              // ISSUE: reference to a compiler-generated field
              if (UCSite._Closure\u0024__.\u0024I744\u002D0 != null)
              {
                // ISSUE: reference to a compiler-generated field
                keySelector = UCSite._Closure\u0024__.\u0024I744\u002D0;
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                UCSite._Closure\u0024__.\u0024I744\u002D0 = keySelector = (Func<DataRow, int>) (row => row.Field<int>("ContactID"));
              }
              OrderedEnumerableRowCollection<DataRow> source2 = source1.OrderByDescending<DataRow, int>(keySelector);
              Func<DataRow, DataRow> selector;
              // ISSUE: reference to a compiler-generated field
              if (UCSite._Closure\u0024__.\u0024I744\u002D1 != null)
              {
                // ISSUE: reference to a compiler-generated field
                selector = UCSite._Closure\u0024__.\u0024I744\u002D1;
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                UCSite._Closure\u0024__.\u0024I744\u002D1 = selector = (Func<DataRow, DataRow>) (row => row);
              }
              DataRow dataRow = source2.Select<DataRow, DataRow>(selector).FirstOrDefault<DataRow>();
              if (dataRow.Table.Rows.Count > 0)
              {
                this.txtTelephoneNum.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["TelephoneNo"]));
                this.txtFaxNum.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["MobileNo"]));
                this.txtEmailAddress.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["EmailAddress"]));
                this.txtName.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["ContactID"]));
                ComboBox cboSalutation = this.cboSalutation;
                Combo.SetSelectedComboItem_By_Description(ref cboSalutation, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Title"])));
                this.cboSalutation = cboSalutation;
                this.txtFirstName.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["FirstName"]));
                this.txtSurname.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["LastName"]));
              }
            }
          }
          this.chkVoid.Checked = false;
          this.lblPropertyVoidDate.Visible = false;
          this.txtPropertyVoidDate.Visible = false;
          this.CurrentSite.PropertyVoidDate = DateTime.MinValue;
          this.Save();
          App.DB.Sites.SaveSiteNotes(Helper.MakeIntegerValid((object) this.txtNoteID.Text), "Site reinstated", App.loggedInUser.UserID, this.CurrentSite.SiteID, App.loggedInUser.UserID);
        }
        else
        {
          try
          {
            if (App.ShowMessage("All contact information will be wiped.".ToUpper() + "\r\n\r\nDo you want to mark this property as void?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
              return;
            DateTime minValue = DateTime.MinValue;
            FRMContractUpgradeDowngrade upgradeDowngrade = new FRMContractUpgradeDowngrade();
            upgradeDowngrade.Text = "Select Date";
            upgradeDowngrade.lblText.Text = "Please select void date";
            int num = (int) upgradeDowngrade.ShowDialog();
            if (upgradeDowngrade.DialogResult != DialogResult.OK)
              return;
            DateTime effDate = upgradeDowngrade.EffDate;
            Contact oContact = new Contact()
            {
              SetSalutation = (object) Combo.get_GetSelectedItemDescription(this.cboSalutation),
              SetFirstName = (object) Helper.MakeStringValid((object) this.txtFirstName.Text),
              SetSurname = (object) Helper.MakeStringValid((object) this.txtSurname.Text),
              SetMobileNo = (object) Helper.MakeStringValid((object) this.txtFaxNum.Text),
              SetTelephoneNum = (object) Helper.MakeStringValid((object) this.txtTelephoneNum.Text),
              SetEmailAddress = (object) Helper.MakeStringValid((object) this.txtEmailAddress.Text),
              SetNoMarketing = this.chkNoMarketing.Checked,
              SetLinkID = (object) 24,
              SetLinkRef = (object) this.CurrentSite.SiteID
            };
            oContact.SetContactID = (object) App.DB.Contact.Contacts_Update(oContact);
            DataView allForLink = App.DB.Contact.Contacts_GetAll_ForLink(24, this.CurrentSite.SiteID, false);
            IEnumerator enumerator;
            try
            {
              enumerator = allForLink.Table.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                if (!App.DB.Contact.Contacts_Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["ContactID"]))))
                  throw new Exception("Failed to delete!");
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            this.ClearContactForVoid();
            this.chkVoid.Checked = true;
            this.lblPropertyVoidDate.Visible = true;
            this.txtPropertyVoidDate.Visible = true;
            this.txtPropertyVoidDate.Text = effDate.ToString("dd/MM/yyyy");
            this.CurrentSite.PropertyVoidDate = effDate;
            this.Save();
            App.DB.Sites.SaveSiteNotes(Helper.MakeIntegerValid((object) this.txtNoteID.Text), "Site marked as void", App.loggedInUser.UserID, this.CurrentSite.SiteID, App.loggedInUser.UserID);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
          }
        }
      }
      else
        this.chkVoid.Checked = !this.chkVoid.Checked;
    }

    private void btnLetterReport_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        DataTable dataTable = App.DB.LetterManager.LetterReport(this.CurrentSite.SiteID);
        if (dataTable.Rows.Count < 3)
        {
          int num = (int) App.ShowMessage("This site has had less than 3 letter visits", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          Printing printing = new Printing((object) new ArrayList()
          {
            (object) dataTable
          }, "Letter Report", Enums.SystemDocumentType.ServiceLetterReport, true, 0, false, 13, this.CurrentSite.CustomerID, DateTime.MinValue, (DataTable) null);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void runFilters()
    {
      if (this.JobsDataView == null)
        return;
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboDefinition)) != 0.0)
        this.JobsDataView.RowFilter = "JobDefinitionEnumID = '" + Combo.get_GetSelectedItemValue(this.cboDefinition) + "'";
      if (this.JobsDataView.RowFilter.Length > 0)
      {
        DataView jobsDataView;
        string str = (jobsDataView = this.JobsDataView).RowFilter + " AND JobNumber LIKE '%" + this.txtJobNumber.Text + "%'";
        jobsDataView.RowFilter = str;
      }
      else
      {
        DataView jobsDataView;
        string str = (jobsDataView = this.JobsDataView).RowFilter + "JobNumber LIKE '%" + this.txtJobNumber.Text + "%'";
        jobsDataView.RowFilter = str;
      }
      if (this.dtpFrom.Checked)
      {
        if (this.JobsDataView.RowFilter.Length > 0)
        {
          DataView jobsDataView;
          string str = (jobsDataView = this.JobsDataView).RowFilter + " AND DateCreated >= '" + Conversions.ToString(this.dtpFrom.Value.Date) + "'";
          jobsDataView.RowFilter = str;
        }
        else
        {
          DataView jobsDataView;
          string str = (jobsDataView = this.JobsDataView).RowFilter + "DateCreated >= '" + Conversions.ToString(this.dtpFrom.Value.Date) + "'";
          jobsDataView.RowFilter = str;
        }
      }
      if (this.dtpTo.Checked)
      {
        if (this.JobsDataView.RowFilter.Length > 0)
        {
          DataView jobsDataView;
          string str = (jobsDataView = this.JobsDataView).RowFilter + " AND DateCreated <= '" + Conversions.ToString(this.dtpTo.Value.Date) + "'";
          jobsDataView.RowFilter = str;
        }
        else
        {
          DataView jobsDataView;
          string str = (jobsDataView = this.JobsDataView).RowFilter + "DateCreated <= '" + Conversions.ToString(this.dtpTo.Value.Date) + "'";
          jobsDataView.RowFilter = str;
        }
      }
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentSite = App.DB.Sites.Get((object) ID, SiteSQL.GetBy.SiteId, (object) null);
      ContractOriginal currentForSite = App.DB.ContractOriginal.Get_Current_ForSite(this.CurrentSite.SiteID);
      if (currentForSite == null)
      {
        this.txtContractStatus.Text = "Not on contract";
        if (App.DB.ContractOriginal.GetAll_ForSite(this.CurrentSite.SiteID).Table.Rows.Count > 0)
          this.lblContractInactive.Visible = true;
        else
          this.lblContractInactive.Visible = false;
      }
      else
      {
        this.txtContractStatus.Text = currentForSite.ContractType + " ";
        if (currentForSite.GasSupplyPipework | currentForSite.PlumbingDrainage | currentForSite.WindowLockPest)
        {
          if (currentForSite.GasSupplyPipework & currentForSite.PlumbingDrainage & currentForSite.WindowLockPest)
          {
            TextBox txtContractStatus;
            string str = (txtContractStatus = this.txtContractStatus).Text + " + Complete Home Emergency Cover ";
            txtContractStatus.Text = str;
          }
          else
          {
            if (currentForSite.GasSupplyPipework)
            {
              TextBox txtContractStatus;
              string str = (txtContractStatus = this.txtContractStatus).Text + " + Gas Supply Pipework ";
              txtContractStatus.Text = str;
            }
            if (currentForSite.PlumbingDrainage)
            {
              TextBox txtContractStatus;
              string str = (txtContractStatus = this.txtContractStatus).Text + " + Plumbing, Drainage and Electrical ";
              txtContractStatus.Text = str;
            }
            if (currentForSite.WindowLockPest)
            {
              TextBox txtContractStatus;
              string str = (txtContractStatus = this.txtContractStatus).Text + " + Window and Pest ";
              txtContractStatus.Text = str;
            }
          }
        }
        TextBox txtContractStatus1;
        string str1 = (txtContractStatus1 = this.txtContractStatus).Text + ", " + ((Enums.ContractStatus) currentForSite.ContractStatusID).ToString() + ", " + Microsoft.VisualBasic.Strings.Format((object) currentForSite.ContractStartDate, "dd/MM/yyyy") + "-" + Microsoft.VisualBasic.Strings.Format((object) currentForSite.ContractEndDate, "dd/MM/yyyy");
        txtContractStatus1.Text = str1;
        if (currentForSite.ContractStatusID == 4 | currentForSite.ContractStatusID == 5 | DateTime.Compare(Conversions.ToDate(Microsoft.VisualBasic.Strings.Format((object) currentForSite.ContractEndDate, "dd-MMM-yyyy") + " 23:59:59"), DateAndTime.Now) < 0)
          this.lblContractInactive.Visible = true;
        else
          this.lblContractInactive.Visible = false;
        DataView allContractId2 = App.DB.ContractOriginalSite.GetAll_ContractID2(currentForSite.ContractID, 0);
        if (allContractId2.Count > 0)
        {
          DataView assetsForContract1 = App.DB.ContractOriginal.GetAssetsForContract(Conversions.ToInteger(allContractId2.Table.Rows[0]["ContractSiteID"]), true);
          if (assetsForContract1.Count > 0)
          {
            TextBox txtContractStatus2;
            string text = (txtContractStatus2 = this.txtContractStatus).Text;
            EnumerableRowCollection<DataRow> source = assetsForContract1.Table.AsEnumerable();
            Func<DataRow, string> selector;
            // ISSUE: reference to a compiler-generated field
            if (UCSite._Closure\u0024__.\u0024I747\u002D0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              selector = UCSite._Closure\u0024__.\u0024I747\u002D0;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              UCSite._Closure\u0024__.\u0024I747\u002D0 = selector = (Func<DataRow, string>) (r => r.Field<string>("Product"));
            }
            string str2 = string.Join(", ", source.Select<DataRow, string>(selector).ToArray<string>());
            string str3 = text + ", Main Apps: " + str2;
            txtContractStatus2.Text = str3;
          }
          DataView assetsForContract2 = App.DB.ContractOriginal.GetAssetsForContract(Conversions.ToInteger(allContractId2.Table.Rows[0]["ContractSiteID"]), false);
          if (assetsForContract2.Count > 0)
          {
            TextBox txtContractStatus2;
            string text = (txtContractStatus2 = this.txtContractStatus).Text;
            EnumerableRowCollection<DataRow> source = assetsForContract2.Table.AsEnumerable();
            Func<DataRow, string> selector;
            // ISSUE: reference to a compiler-generated field
            if (UCSite._Closure\u0024__.\u0024I747\u002D1 != null)
            {
              // ISSUE: reference to a compiler-generated field
              selector = UCSite._Closure\u0024__.\u0024I747\u002D1;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              UCSite._Closure\u0024__.\u0024I747\u002D1 = selector = (Func<DataRow, string>) (r => r.Field<string>("Product"));
            }
            string str2 = string.Join(", ", source.Select<DataRow, string>(selector).ToArray<string>());
            string str3 = text + ", Second Apps: " + str2;
            txtContractStatus2.Text = str3;
          }
        }
      }
      ComboBox cboRegionId = this.cboRegionID;
      Combo.SetSelectedComboItem_By_Value(ref cboRegionId, Conversions.ToString(this.CurrentSite.RegionID));
      this.cboRegionID = cboRegionId;
      if (!this.CurrentSite.Exists | !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
        this.cboRegionID.Enabled = false;
      FSM.Entity.Customers.Customer currentCustomer1 = this.CurrentCustomer;
      bool? nullable = currentCustomer1 != null ? new bool?(currentCustomer1.CustomerTypeID == 516) : new bool?();
      if ((!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.SocialHousingSecurity) ? nullable : new bool?(false)).GetValueOrDefault())
        this.chkHeadOffice.Enabled = false;
      this.chkHeadOffice.Checked = this.CurrentSite.HeadOffice;
      this.txtNotes.Text = this.CurrentSite.Notes;
      this.txtAsbestos.Text = this.CurrentSite.Asbestos;
      this.txtAddress1.Text = this.CurrentSite.Address1;
      this.txtAddress2.Text = this.CurrentSite.Address2;
      this.txtAddress3.Text = this.CurrentSite.Address3;
      this.txtAddress4.Text = this.CurrentSite.Address4;
      this.txtAddress5.Text = this.CurrentSite.Address5;
      this.txtPostcode.Text = this.CurrentSite.Postcode;
      FSM.Entity.Customers.Customer currentCustomer2 = this.CurrentCustomer;
      if (currentCustomer2 != null && currentCustomer2.CustomerTypeID == 516)
      {
        this.txtAddress1.ReadOnly = true;
        this.txtAddress2.ReadOnly = true;
        this.txtAddress3.ReadOnly = true;
        this.txtAddress4.ReadOnly = true;
        this.txtAddress5.ReadOnly = true;
        this.txtPostcode.ReadOnly = true;
      }
      this.txtPolicyNumber.Text = this.CurrentSite.PolicyNumber;
      this.txtDDRef.Text = this.CurrentSite.DirectDebitRef;
      this.txtTelephoneNum.Text = this.CurrentSite.TelephoneNum;
      this.txtFaxNum.Text = this.CurrentSite.FaxNum;
      this.txtEmailAddress.Text = this.CurrentSite.EmailAddress;
      this.txtName.Text = this.CurrentSite.Name;
      ComboBox cboSalutation = this.cboSalutation;
      Combo.SetSelectedComboItem_By_Description(ref cboSalutation, this.CurrentSite.Salutation);
      this.cboSalutation = cboSalutation;
      this.txtFirstName.Text = this.CurrentSite.FirstName;
      this.txtSurname.Text = this.CurrentSite.Surname;
      this.chbAcceptChargeChanges.Checked = this.CurrentSite.AcceptChargesChanges;
      ComboBox sourceOfCustomer = this.cboSourceOfCustomer;
      Combo.SetSelectedComboItem_By_Value(ref sourceOfCustomer, Conversions.ToString(this.CurrentSite.SourceOfCustomerID));
      this.cboSourceOfCustomer = sourceOfCustomer;
      ComboBox reasonForContact = this.cboReasonForContact;
      Combo.SetSelectedComboItem_By_Value(ref reasonForContact, Conversions.ToString(this.CurrentSite.ReasonForContactID));
      this.cboReasonForContact = reasonForContact;
      ComboBox cboAccomType = this.cboAccomType;
      Combo.SetSelectedComboItem_By_Value(ref cboAccomType, Conversions.ToString(this.CurrentSite.AccomTypeID));
      this.cboAccomType = cboAccomType;
      this.chkNoMarketing.Checked = this.CurrentSite.NoMarketing;
      this.chkOnStop.Checked = this.CurrentSite.OnStop;
      this.chkVoid.Checked = this.CurrentSite.PropertyVoid;
      if (this.CurrentSite.PropertyVoid)
      {
        this.lblPropertyVoidDate.Visible = true;
        this.txtPropertyVoidDate.Visible = true;
        if (!Information.IsNothing((object) this.CurrentSite.PropertyVoidDate))
          this.txtPropertyVoidDate.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentSite.PropertyVoidDate, "dd/MM/yyyy");
      }
      this.txtAlert.Text = this.CurrentSite.ContactAlerts;
      if (Microsoft.VisualBasic.Strings.Trim(this.txtAlert.Text).Length > 0)
        this.txtAlert.BackColor = Color.Orange;
      this.txtSiteDefects.Text = this.CurrentSite.Defects;
      if (Microsoft.VisualBasic.Strings.Trim(this.txtSiteDefects.Text).Length > 0)
      {
        this.txtSiteDefects.BackColor = Color.Yellow;
        this.dtpDefectEndDate.Enabled = false;
      }
      if ((uint) DateTime.Compare(this.CurrentSite.DefectEndDate, DateTime.MinValue) > 0U)
        this.dtpDefectEndDate.Value = this.CurrentSite.DefectEndDate;
      this.chkSolidFuel.Checked = this.CurrentSite.SolidFuel;
      this.chkNoService.Checked = this.CurrentSite.NoService;
      this.chkLeaseHolder.Checked = this.CurrentSite.LeaseHold;
      this.chkCommercialDistrict.Checked = this.CurrentSite.CommercialDistrict;
      if ((uint) DateTime.Compare(this.CurrentSite.LastServiceDate, DateTime.MinValue) > 0U)
      {
        this.txtLastServiceDate.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentSite.LastServiceDate.AddYears(1), "dd/MM/yyyy");
        this.txtActualServiceDate.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentSite.LastServiceDate, "dd/MM/yyyy");
      }
      if ((uint) DateTime.Compare(this.CurrentSite.ActualServiceDate, DateTime.MinValue) > 0U)
        this.txtActualServiceDate.Text = Microsoft.VisualBasic.Strings.Format((object) this.CurrentSite.ActualServiceDate, "dd/MM/yyyy");
      if ((uint) DateTime.Compare(this.CurrentSite.BuildDate, DateTime.MinValue) > 0U)
        this.dtpBuildDate.Value = this.CurrentSite.BuildDate;
      this.txtWarrantyPeriod.Text = Conversions.ToString(this.CurrentSite.WarrantyPeriodInMonths);
      this.dtpBuildDate.Enabled = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor);
      this.txtWarrantyPeriod.ReadOnly = !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor);
      this.txtHousingOfficer.Text = string.IsNullOrEmpty(this.CurrentSite.HousingOfficer) ? "No Housing Officer Set" : this.CurrentSite.HousingOfficer;
      this.txtEstateOfficer.Text = string.IsNullOrEmpty(this.CurrentSite.EstateOfficer) ? "No Estate Officer Set" : this.CurrentSite.EstateOfficer;
      this.txtHousingManager.Text = string.IsNullOrEmpty(this.CurrentSite.HousingManager) ? "No Housing Manager Set" : this.CurrentSite.HousingManager;
      this.PopulateSiteFuels();
      this.PopulateSiteAuthority();
      this.CheckServiceDate();
      this.SelectedCustomerID = this.CurrentSite.CustomerID;
      this.PopulateCustomerField();
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
      if (this.chkHeadOffice.Checked)
        this.btnConvCust.Enabled = false;
      if (!App.IsRFT || !this.CurrentSite.LeaseHold)
        return;
      this.btnAddJob.Enabled = false;
    }

    private void PopulateCustomerField()
    {
      this.theCustomer = App.DB.Customer.Customer_Get(this.SelectedCustomerID);
      if (this.theCustomer != null)
        this.txtCustomer.Text = this.theCustomer.Name;
      else
        this.txtCustomer.Text = "";
    }

    public void PopulateContacts()
    {
      this.ContactsDataView = App.DB.Contact.Contact_GetForSite(this.CurrentSite.SiteID);
    }

    public void PopulateInvoiceAddresses()
    {
      this.InvoiceAddressDataView = App.DB.InvoiceAddress.InvoiceAddress_GetForSite(this.CurrentSite.SiteID);
    }

    public void PopulateJobs()
    {
      this.JobsDataView = App.DB.Job.Job_GetTop100_For_Site(this.CurrentSite.SiteID, this.CurrentSite.CustomerID);
      if (this.JobsDataView.Count <= 0)
        return;
      this.dgJobs.ContextMenuStrip = this.cmsJobs;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentSite.IgnoreExceptionsOnSetMethods = true;
        if (this.chkHeadOffice.Checked)
        {
          FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) this.CurrentSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
          if (site != null && site.SiteID != this.CurrentSite.SiteID)
            throw new SecurityException(this.theCustomer.Name + " has already got a head office against it. '" + site.Address1 + " " + site.Postcode + "'\r\n\r\nPlease remove the current head office before assigning this site.");
        }
        if (!this.CurrentSite.Exists | App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
          this.CurrentSite.SetRegionID = (object) Combo.get_GetSelectedItemValue(this.cboRegionID);
        this.CurrentSite.SetHeadOffice = (object) this.chkHeadOffice.Checked;
        this.CurrentSite.SetNotes = (object) this.txtNotes.Text.Trim();
        this.CurrentSite.SetAddress1 = (object) this.txtAddress1.Text.Trim();
        this.CurrentSite.SetAddress2 = (object) this.txtAddress2.Text.Trim();
        this.CurrentSite.SetAddress3 = (object) this.txtAddress3.Text.Trim();
        this.CurrentSite.SetAddress4 = (object) this.txtAddress4.Text.Trim();
        this.CurrentSite.SetAddress5 = (object) this.txtAddress5.Text.Trim();
        this.CurrentSite.SetPostcode = (object) this.txtPostcode.Text.Trim();
        this.CurrentSite.SetTelephoneNum = (object) this.txtTelephoneNum.Text.Trim();
        this.CurrentSite.SetFaxNum = (object) this.txtFaxNum.Text.Trim();
        this.CurrentSite.SetEmailAddress = (object) this.txtEmailAddress.Text.Trim();
        this.CurrentSite.SetAcceptChargesChanges = (object) this.chbAcceptChargeChanges.Checked;
        this.CurrentSite.SetSourceOfCustomerID = (object) Combo.get_GetSelectedItemValue(this.cboSourceOfCustomer);
        this.CurrentSite.SetPolicyNumber = (object) this.txtPolicyNumber.Text;
        this.CurrentSite.SetDirectDebitRef = (object) this.txtDDRef.Text;
        this.CurrentSite.SetReasonForContactID = (object) Combo.get_GetSelectedItemValue(this.cboReasonForContact);
        this.CurrentSite.SetAccomTypeID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboAccomType));
        this.CurrentSite.SetNoMarketing = (object) this.chkNoMarketing.Checked;
        this.CurrentSite.SetOnStop = (object) this.chkOnStop.Checked;
        this.CurrentSite.SetNoService = (object) this.chkNoService.Checked;
        this.CurrentSite.SetPropertyVoid = (object) this.chkVoid.Checked;
        this.CurrentSite.PropertyVoidDate = !this.chkVoid.Checked ? DateTime.MinValue : Helper.MakeDateTimeValid((object) this.txtPropertyVoidDate.Text);
        if ((SqlDateTime) this.dtpBuildDate.Value > SqlDateTime.MinValue)
          this.CurrentSite.BuildDate = this.dtpBuildDate.Value;
        this.CurrentSite.SetWarrantyPeriodInMonths = (object) Helper.MakeIntegerValid((object) this.txtWarrantyPeriod.Text);
        try
        {
          JObject longLat = (JObject) new FSM.LocationServices.LocationServices().GetLongLat(this.txtPostcode.Text.Trim());
          this.CurrentSite.SetLongitude = Conversions.ToDecimal(longLat.SelectToken("result.longitude").ToString());
          this.CurrentSite.SetLatitude = Conversions.ToDecimal(longLat.SelectToken("result.latitude").ToString());
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        string str = "";
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboSalutation), "0", false) > 0U)
          str += Combo.get_GetSelectedItemDescription(this.cboSalutation);
        if (this.txtFirstName.Text.Length > 0)
        {
          if (str.Length > 0)
            str += " ";
          str += this.txtFirstName.Text.Trim();
        }
        if (this.txtSurname.Text.Length > 0)
        {
          if (str.Length > 0)
            str += " ";
          str += this.txtSurname.Text.Trim();
        }
        if (str.Length > 0)
          this.CurrentSite.SetName = (object) str;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboSalutation), "Company Name", false) == 0)
          this.CurrentSite.SetName = (object) this.txtSurname.Text;
        this.CurrentSite.SetSalutation = (object) Combo.get_GetSelectedItemDescription(this.cboSalutation);
        this.CurrentSite.SetFirstName = (object) this.txtFirstName.Text.Trim();
        this.CurrentSite.SetSurname = (object) this.txtSurname.Text.Trim();
        int num = 0;
        if (this.SelectedCustomerID != this.CurrentSite.CustomerID)
          num = this.CurrentSite.CustomerID;
        this.CurrentSite.SetCustomerID = (object) this.SelectedCustomerID;
        if (string.IsNullOrEmpty(this.CurrentSite.TelephoneNum) & string.IsNullOrEmpty(this.CurrentSite.FaxNum) & string.IsNullOrEmpty(this.CurrentSite.EmailAddress) & !this.CurrentSite.PropertyVoid && App.ShowMessage("The phone number/email address is missing from site. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
          flag = false;
        }
        else
        {
          this.CurrentSite.SetContactAlerts = (object) this.txtAlert.Text.Trim();
          this.CurrentSite.SetDefects = (object) this.txtSiteDefects.Text.Trim();
          this.CurrentSite.DefectEndDate = this.dtpDefectEndDate.Value;
          new SiteValidator().Validate(this.CurrentSite);
          if (this.CurrentSite.Exists)
            App.DB.Sites.Update(this.CurrentSite);
          else
            this.CurrentSite = App.DB.Sites.Insert(this.CurrentSite);
          if (this.FromForm == null)
          {
            App.MainForm.lblRightTitle.Text = "Manage Property for Customer: " + this.theCustomer.Name + ", Acc: " + this.theCustomer.AccountNumber;
            if (App.CurrentCustomerID == 0)
            {
              if (App.MainForm.SearchText.Length > 0)
              {
                // ISSUE: reference to a compiler-generated field
                IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
                if (recordsChangedEvent != null)
                  recordsChangedEvent(App.DB.Sites.Search(App.MainForm.SearchText, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
                if (recordsChangedEvent != null)
                  recordsChangedEvent(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
              }
            }
            else
            {
              App.CurrentCustomerID = this.CurrentSite.CustomerID;
              FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
              if (App.MainForm.SearchText.Length > 0)
              {
                // ISSUE: reference to a compiler-generated field
                IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
                if (recordsChangedEvent != null)
                  recordsChangedEvent(App.DB.Sites.Search(App.MainForm.SearchText, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
                if (recordsChangedEvent != null)
                  recordsChangedEvent(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, customer.Name);
              }
            }
            // ISSUE: reference to a compiler-generated field
            IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
            if (stateChangedEvent != null)
              stateChangedEvent(this.CurrentSite.SiteID);
            App.MainForm.RefreshEntity(this.CurrentSite.SiteID, "");
          }
          else if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.FromForm.Name.ToLower(), typeof (FRMLogCallout).Name.ToLower(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.FromForm.Name.ToLower(), typeof (FRMJobWizard).Name.ToLower(), false) > 0U)
          {
            App.MainForm.lblRightTitle.Text = "Manage Property for Customer: " + this.theCustomer.Name + ", Acc: " + this.theCustomer.AccountNumber;
            if (App.CurrentCustomerID == 0)
            {
              // ISSUE: reference to a compiler-generated field
              IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
              if (recordsChangedEvent != null)
                recordsChangedEvent(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
            }
            else
            {
              App.CurrentCustomerID = this.CurrentSite.CustomerID;
              FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
              // ISSUE: reference to a compiler-generated field
              IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
              if (recordsChangedEvent != null)
                recordsChangedEvent(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, customer.Name);
            }
            // ISSUE: reference to a compiler-generated field
            IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
            if (stateChangedEvent != null)
              stateChangedEvent(this.CurrentSite.SiteID);
            App.MainForm.RefreshEntity(this.CurrentSite.SiteID, "");
          }
          flag = true;
        }
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

    private bool DeleteOption1()
    {
      DataView dataView = new DataView();
      DataView allContractId = App.DB.ContractOriginalSite.GetAll_ContractID(Conversions.ToInteger(this.SelectedContractDataRow["ContractID"]), this.CurrentSite.CustomerID);
      bool flag = true;
      DataRow[] dataRowArray = allContractId.Table.Select("Tick=1");
      int index = 0;
      while (index < dataRowArray.Length)
      {
        DataRow dataRow = dataRowArray[index];
        if (App.DB.ContractOriginalSite.Delete(Conversions.ToInteger(dataRow["ContractSiteID"])) > 0)
          flag = false;
        checked { ++index; }
      }
      if (flag)
        App.DB.ContractOriginal.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractID"])));
      return flag;
    }

    private void ClearContactForVoid()
    {
      this.txtTelephoneNum.Text = string.Empty;
      this.txtFaxNum.Text = string.Empty;
      this.txtEmailAddress.Text = string.Empty;
      this.txtName.Text = "VOID";
      ComboBox cboSalutation = this.cboSalutation;
      Combo.SetUpCombo(ref cboSalutation, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboSalutation = cboSalutation;
      this.txtFirstName.Text = "VOID";
      this.txtSurname.Text = "VOID";
    }

    public DataView SiteNotesDataView
    {
      get
      {
        return this._siteNotes;
      }
      set
      {
        this._siteNotes = value;
        this._siteNotes.Table.TableName = Enums.TableNames.tblSiteNotes.ToString();
        this._siteNotes.AllowNew = false;
        this._siteNotes.AllowEdit = false;
        this._siteNotes.AllowDelete = false;
        this.dgNotes.DataSource = (object) this._siteNotes;
        if (this._siteNotes == null || this._siteNotes.Table == null || this._siteNotes.Table.Rows.Count <= 0)
          ;
      }
    }

    private DataRow SelectedSiteNoteDataRow
    {
      get
      {
        return this.dgNotes.CurrentRowIndex != -1 ? this.SiteNotesDataView[this.dgNotes.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupNotesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgNotes, false);
      DataGridTableStyle tableStyle = this.dgNotes.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgNotes.ReadOnly = true;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Note";
      dataGridLabelColumn1.MappingName = "Note";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 250;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Created By";
      dataGridLabelColumn2.MappingName = "CreatedBy";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 125;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MMM/yyyy HH:mm:ss";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Created";
      dataGridLabelColumn3.MappingName = "DateCreated";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 135;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Edited By";
      dataGridLabelColumn4.MappingName = "EditedBy";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 125;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MMM/yyyy HH:mm:ss";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Last Edited";
      dataGridLabelColumn5.MappingName = "LastEdited";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 135;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblSiteNotes.ToString();
      this.dgNotes.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgNotes);
    }

    private void dgNotes_Click(object sender, EventArgs e)
    {
      if (this.SelectedSiteNoteDataRow == null)
        return;
      this.PopulateSiteNoteFields();
      this.txtNote.ReadOnly = true;
      this.btnSaveNote.Enabled = false;
    }

    private void btnAddNote_Click(object sender, EventArgs e)
    {
      this.ClearNotesFields();
    }

    private void btnDeleteNote_Click(object sender, EventArgs e)
    {
      string text = "Are you sure you want to delete this note?\r\n" + "You will not be able to undo the delete if you proceed.";
      DataRow selectedSiteNoteDataRow = this.SelectedSiteNoteDataRow;
      if (selectedSiteNoteDataRow == null || MessageBox.Show(text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
        return;
      App.DB.Sites.DeleteSiteNote(Conversions.ToInteger(selectedSiteNoteDataRow["SiteNoteID"]));
      this.SiteNotesDataView.Table.Rows.Remove(this.SelectedSiteNoteDataRow);
      this.ClearNotesFields();
    }

    private void btnSaveNote_Click(object sender, EventArgs e)
    {
      if (this.txtNote.Text.Trim().Length > 0)
        this.SiteNotesDataView = App.DB.Sites.SaveSiteNotes(Helper.MakeIntegerValid((object) this.txtNoteID.Text), this.txtNote.Text.Trim(), App.loggedInUser.UserID, this.CurrentSite.SiteID, App.loggedInUser.UserID);
      this.ClearNotesFields();
    }

    private void ClearNotesFields()
    {
      this.txtNoteID.Text = "";
      this.txtNote.Text = "";
      this.ActiveControl = (Control) this.txtNote;
      this.txtNote.ReadOnly = false;
      this.txtNote.Focus();
      this.btnSaveNote.Enabled = true;
      this.tpNotes.Text = "Notes (" + Conversions.ToString(this.SiteNotesDataView.Table.Rows.Count) + ")";
    }

    private void PopulateSiteNoteFields()
    {
      DataRow selectedSiteNoteDataRow = this.SelectedSiteNoteDataRow;
      if (selectedSiteNoteDataRow != null)
      {
        this.txtNoteID.Text = Conversions.ToString(selectedSiteNoteDataRow["SiteNoteID"]);
        this.txtNote.Text = Conversions.ToString(selectedSiteNoteDataRow["Note"]);
      }
      this.ActiveControl = (Control) this.txtNote;
      this.txtNote.Focus();
    }

    private void PopulateSiteNotes()
    {
      this.SiteNotesDataView = App.DB.Sites.GetSiteNotes(this.CurrentSite.SiteID);
      this.tpNotes.Text = "Notes (" + Conversions.ToString(this.SiteNotesDataView.Table.Rows.Count) + ")";
    }

    private void btnAddModifyPlan_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMContractWiz), true, new object[3]
      {
        (object) 0,
        (object) Helper.MakeIntegerValid((object) this.CurrentSite.CustomerID),
        (object) Helper.MakeIntegerValid((object) this.CurrentSite.SiteID)
      }, false);
      this.Contracts = App.DB.ContractOriginal.GetAll_ForSite(this.CurrentSite.SiteID);
      this.PopulateJobs();
    }

    private void btnConvCust_Click(object sender, EventArgs e)
    {
      if (this.CurrentSite != null && this.CurrentSite.Exists)
      {
        int customerTypeId = App.DB.Customer.Customer_Get(this.CurrentSite.CustomerID).CustomerTypeID;
        if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor) & customerTypeId == 516)
          throw new SecurityException("You do not have the necessary security permissions to change site to customer.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      }
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboRegionID)) < 1.0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Please ensure the site has a region selected before converting", MsgBoxStyle.OkOnly, (object) "No Region");
      }
      else if (this.txtFirstName.Text.Length == 0 && this.txtSurname.Text.Length == 0)
      {
        int num2 = (int) Interaction.MsgBox((object) "Please ensure the site has a Surname or Firstname before converting", MsgBoxStyle.OkOnly, (object) "No Name");
      }
      else
      {
        this.Cursor = Cursors.WaitCursor;
        try
        {
          FSM.Entity.Customers.Customer customer1 = App.DB.Customer.Customer_Get(787);
          byte[] array;
          using (MemoryStream memoryStream = new MemoryStream())
          {
            Image.FromFile(Application.StartupPath + "\\TEMP\\GaswayLogo.bmp").Save((Stream) memoryStream, ImageFormat.Jpeg);
            array = memoryStream.ToArray();
          }
          this.CurrentCustomer = new FSM.Entity.Customers.Customer();
          this.CurrentCustomer.IgnoreExceptionsOnSetMethods = true;
          string str = this.txtFirstName.Text;
          if (str.Length > 0)
            str = str.Substring(0, 1);
          this.CurrentCustomer.SetName = (object) (this.txtSurname.Text + " - " + Combo.get_GetSelectedItemDescription(this.cboSalutation) + " " + str);
          this.CurrentCustomer.SetRegionID = (object) Combo.get_GetSelectedItemValue(this.cboRegionID);
          this.CurrentCustomer.SetCustomerTypeID = (object) 518;
          this.CurrentCustomer.SetNotes = (object) "POC ONLY";
          this.CurrentCustomer.SetAccountNumber = (object) customer1?.AccountNumber;
          this.CurrentCustomer.SetStatus = (object) 1;
          this.CurrentCustomer.SetAcceptChargesChanges = (object) this.chbAcceptChargeChanges.Checked;
          this.CurrentCustomer.SetMainContractorDiscount = (object) 0;
          this.CurrentCustomer.SetPoNumReqd = (object) false;
          this.CurrentCustomer.SetJobPriorityMandatory = (object) false;
          this.CurrentCustomer.SetNominal = (object) 4100;
          this.CurrentCustomer.Logo = array;
          this.CurrentSite.SetHeadOffice = (object) false;
          new CustomerValidator().Validate(this.CurrentCustomer);
          if (Conversions.ToInteger(App.DB.ExecuteScalar("Select Count(*) FROM tblCustomer where Deleted = 0 AND Name = '" + this.CurrentCustomer.Name + "'", true, false)) > 0)
          {
            if (App.ShowMessage("There is already a Customer with the same Name, Do you Still wish to proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
              return;
            this.CurrentCustomer.SetName = (object) (this.txtSurname.Text + " - " + Combo.get_GetSelectedItemDescription(this.cboSalutation) + " " + this.txtFirstName.Text);
          }
          if (this.CurrentCustomer.Exists)
          {
            CustomerCharge oCustomerCharge = new CustomerCharge();
            oCustomerCharge.SetMileageRate = (object) 1;
            oCustomerCharge.SetPartsMarkup = (object) 1;
            oCustomerCharge.SetRatesMarkup = (object) 1;
            oCustomerCharge.SetCustomerID = (object) this.CurrentCustomer.CustomerID;
            new CustomerChargeValidator().Validate(oCustomerCharge);
            App.DB.CustomerCharge.Update(oCustomerCharge);
            App.DB.Customer.Update(this.CurrentCustomer);
          }
          else
          {
            CustomerCharge oCustomerCharge = new CustomerCharge();
            oCustomerCharge.SetMileageRate = (object) 1;
            oCustomerCharge.SetPartsMarkup = (object) 1;
            oCustomerCharge.SetRatesMarkup = (object) 1;
            oCustomerCharge.SetCustomerID = (object) 0;
            new CustomerChargeValidator().Validate(oCustomerCharge);
            this.CurrentSite.SetHeadOffice = (object) true;
            this.CurrentCustomer = App.DB.Customer.Insert(this.CurrentCustomer);
            oCustomerCharge.SetCustomerID = (object) this.CurrentCustomer.CustomerID;
            App.DB.CustomerCharge.Insert(oCustomerCharge);
          }
          App.CurrentCustomerID = this.CurrentCustomer.CustomerID;
          DataTable table = App.DB.CustomerScheduleOfRate.GetAll_WithoutDefaults(787).Table;
          IEnumerator enumerator;
          try
          {
            enumerator = table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              App.DB.CustomerScheduleOfRate.Insert(new CustomerScheduleOfRate()
              {
                SetAllowDeleted = (object) 1,
                SetCustomerID = (object) App.CurrentCustomerID,
                SetCode = RuntimeHelpers.GetObjectValue(current["Code"]),
                SetDescription = RuntimeHelpers.GetObjectValue(current["Description"]),
                SetPrice = RuntimeHelpers.GetObjectValue(current["Price"]),
                SetTimeInMins = RuntimeHelpers.GetObjectValue(current["TimeInMins"]),
                SetScheduleOfRatesCategoryID = RuntimeHelpers.GetObjectValue(current["ScheduleOfRatesCategoryID"])
              });
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          App.DB.SiteCustomerAudit.Insert(new SiteCustomerAudit()
          {
            DateChanged = DateAndTime.Now,
            SetSiteID = (object) this.CurrentSite.SiteID,
            SetPreviousCustomerID = (object) this.CurrentSite.CustomerID,
            SetUserID = (object) App.loggedInUser.UserID
          });
          this.CurrentSite.SetCustomerID = (object) App.CurrentCustomerID;
          App.DB.Sites.Update(this.CurrentSite);
          this.btnConvCust.Enabled = false;
          if (this.FromForm == null)
          {
            App.MainForm.lblRightTitle.Text = "Manage Property for Customer: " + this.theCustomer.Name + ", Acc: " + this.theCustomer.AccountNumber;
            if (App.CurrentCustomerID == 0)
            {
              if (App.MainForm.SearchText.Length > 0)
              {
                // ISSUE: reference to a compiler-generated field
                IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
                if (recordsChangedEvent != null)
                  recordsChangedEvent(App.DB.Sites.Search(App.MainForm.SearchText, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
                if (recordsChangedEvent != null)
                  recordsChangedEvent(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
              }
            }
            else
            {
              App.CurrentCustomerID = this.CurrentSite.CustomerID;
              FSM.Entity.Customers.Customer customer2 = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
              if (App.MainForm.SearchText.Length > 0)
              {
                // ISSUE: reference to a compiler-generated field
                IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
                if (recordsChangedEvent != null)
                  recordsChangedEvent(App.DB.Sites.Search(App.MainForm.SearchText, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
                if (recordsChangedEvent != null)
                  recordsChangedEvent(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, customer2.Name);
              }
            }
            // ISSUE: reference to a compiler-generated field
            IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
            if (stateChangedEvent != null)
              stateChangedEvent(this.CurrentSite.SiteID);
            App.MainForm.RefreshEntity(this.CurrentSite.SiteID, "");
          }
          else if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.FromForm.Name.ToLower(), typeof (FRMLogCallout).Name.ToLower(), false) > 0U)
          {
            App.MainForm.lblRightTitle.Text = "Manage Property for Customer: " + this.theCustomer.Name + ", Acc: " + this.theCustomer.AccountNumber;
            if (App.CurrentCustomerID == 0)
            {
              // ISSUE: reference to a compiler-generated field
              IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
              if (recordsChangedEvent != null)
                recordsChangedEvent(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, "");
            }
            else
            {
              App.CurrentCustomerID = this.CurrentSite.CustomerID;
              FSM.Entity.Customers.Customer customer2 = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
              // ISSUE: reference to a compiler-generated field
              IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
              if (recordsChangedEvent != null)
                recordsChangedEvent(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, true, false, customer2.Name);
            }
            // ISSUE: reference to a compiler-generated field
            IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
            if (stateChangedEvent != null)
              stateChangedEvent(this.CurrentSite.SiteID);
            App.MainForm.RefreshEntity(this.CurrentSite.SiteID, "");
          }
        }
        catch (ValidationException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          int num3 = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          ProjectData.ClearProjectError();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num3 = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
    }

    public DataView SiteFuelsDataView
    {
      get
      {
        return this._dvSiteFuels;
      }
      set
      {
        this._dvSiteFuels = value;
        this._dvSiteFuels.AllowNew = false;
        this._dvSiteFuels.AllowEdit = false;
        this._dvSiteFuels.AllowDelete = false;
        this._dvSiteFuels.Table.TableName = Enums.TableNames.tblSiteFuel.ToString();
        this.dgSiteFuel.DataSource = (object) this.SiteFuelsDataView;
      }
    }

    private DataRow SelectedSiteFuelDataRow
    {
      get
      {
        return this.dgSiteFuel.CurrentRowIndex != -1 ? this.SiteFuelsDataView[this.dgSiteFuel.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SiteFuelMoreInfo(object sender, EventArgs e)
    {
      if (this.CurrentSite == null || !this.CurrentSite.Exists)
        return;
      int num = (int) new FRMSiteFuel(this.CurrentSite).ShowDialog();
      this.CurrentSite = App.DB.Sites.Get((object) this.CurrentSite.SiteID, SiteSQL.GetBy.SiteId, (object) null);
    }

    private void dgSiteFuel_MouseUp(object sender, MouseEventArgs e)
    {
      this.ttSiteFuel.Hide((IWin32Window) this.dgSiteFuel);
      if (this.SelectedSiteFuelDataRow == null)
        return;
      string text = "";
      if (this.SelectedSiteFuelDataRow.Table.Columns.Contains("lastservicedate"))
      {
        DateTime t1_1 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedSiteFuelDataRow["lastservicedate"]));
        DateTime now;
        int num1;
        if (DateTime.Compare(t1_1, DateTime.MinValue) != 0)
        {
          DateTime t1_2 = t1_1;
          now = SqlDateTime.MinValue.Value;
          DateTime t2 = now.AddYears(1);
          num1 = DateTime.Compare(t1_2, t2) > 0 ? 1 : 0;
        }
        else
          num1 = 0;
        if (num1 != 0)
        {
          DateTime t1_2 = t1_1;
          now = DateAndTime.Now;
          DateTime t2_1 = now.AddDays(-365.0);
          if (DateTime.Compare(t1_2, t2_1) <= 0)
          {
            text = "Overdue";
          }
          else
          {
            DateTime t1_3 = t1_1;
            now = DateAndTime.Now;
            DateTime t2_2 = now.AddDays(-352.0);
            int num2 = DateTime.Compare(t1_3, t2_2) <= 0 ? 1 : 0;
            DateTime t1_4 = t1_1;
            now = DateAndTime.Now;
            DateTime t2_3 = now.AddDays(-365.0);
            int num3 = DateTime.Compare(t1_4, t2_3) > 0 ? 1 : 0;
            if ((num2 & num3) != 0)
            {
              text = "Third letter stage";
            }
            else
            {
              DateTime t1_5 = t1_1;
              now = DateAndTime.Now;
              DateTime t2_4 = now.AddDays(-330.0);
              int num4 = DateTime.Compare(t1_5, t2_4) <= 0 ? 1 : 0;
              DateTime t1_6 = t1_1;
              now = DateAndTime.Now;
              DateTime t2_5 = now.AddDays(-352.0);
              int num5 = DateTime.Compare(t1_6, t2_5) > 0 ? 1 : 0;
              if ((num4 & num5) != 0)
              {
                text = "Second letter stage";
              }
              else
              {
                DateTime t1_7 = t1_1;
                now = DateAndTime.Now;
                DateTime t2_6 = now.AddDays(-309.0);
                int num6 = DateTime.Compare(t1_7, t2_6) <= 0 ? 1 : 0;
                DateTime t1_8 = t1_1;
                now = DateAndTime.Now;
                DateTime t2_7 = now.AddDays(-330.0);
                int num7 = DateTime.Compare(t1_8, t2_7) > 0 ? 1 : 0;
                if ((num6 & num7) != 0)
                {
                  text = "First letter stage";
                }
                else
                {
                  DateTime t1_9 = t1_1;
                  now = DateAndTime.Now;
                  DateTime t2_8 = now.AddDays(-281.0);
                  int num8 = DateTime.Compare(t1_9, t2_8) <= 0 ? 1 : 0;
                  DateTime t1_10 = t1_1;
                  now = DateAndTime.Now;
                  DateTime t2_9 = now.AddDays(-309.0);
                  int num9 = DateTime.Compare(t1_10, t2_9) > 0 ? 1 : 0;
                  if ((num8 & num9) == 0)
                    return;
                  text = "Service due soon";
                }
              }
            }
          }
        }
        else
          text = "No service recorded";
      }
      DataGrid.HitTestInfo hitTestInfo = this.dgSiteFuel.HitTest(e.X, e.Y);
      if (hitTestInfo.Type == DataGrid.HitTestType.Cell && hitTestInfo.Row >= 0)
        this.ttSiteFuel.Show(text, (IWin32Window) this.dgSiteFuel, e.X, e.Y);
    }

    private void PopulateSiteFuels()
    {
      try
      {
        this.SiteFuelsDataView = App.DB.Sites.SiteFuel_GetAll_ForSite(this.CurrentSite.SiteID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void dgSiteFuel_Leave(object sender, EventArgs e)
    {
      this.ttSiteFuel.Hide((IWin32Window) this.dgSiteFuel);
    }

    private void tsmiMoveJob_Click(object sender, EventArgs e)
    {
      if (this.SelectedJobDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a job", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        Cursor.Current = Cursors.WaitCursor;
        int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, 0, "", false));
        if ((uint) integer > 0U)
        {
          FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) integer, SiteSQL.GetBy.SiteId, (object) null);
          if (site != null && site.Exists)
          {
            if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Move job '", this.SelectedJobDataRow["JobNumber"]), (object) "' to "), (object) site.Address1)), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
              return;
            if (App.DB.Job.Job_MoveSite(Conversions.ToInteger(this.SelectedJobDataRow["JobID"]), this.CurrentSite.SiteID, integer))
            {
              App.DB.JobAudit.Insert(new JobAudit()
              {
                SetJobID = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["JobID"]),
                SetActionChange = (object) ("Job moved from " + this.CurrentSite.Name + ", " + this.CurrentSite.Address1 + " to " + site.Name + ", " + site.Address1)
              });
              int num2 = (int) App.ShowMessage("Job successfully moved!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              this.PopulateJobs();
            }
          }
        }
        Cursor.Current = Cursors.Default;
      }
    }

    private void btnUpdateAlert_Click(object sender, EventArgs e)
    {
      string text = this.txtAlert.Text;
      if (string.IsNullOrEmpty(text) || App.ShowMessage("Do you want to update the alert?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      App.DB.Sites.Site_Update_ContactAlerts(this.CurrentSite.SiteID, text);
      this.CurrentSite = App.DB.Sites.Get((object) this.CurrentSite.SiteID, SiteSQL.GetBy.SiteId, (object) null);
    }

    public void SetupSiteAuthorityAuditDataGrid()
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

    private DataView SiteAuthorityAuditDataView
    {
      get
      {
        return this._dvSiteAuthorityAudit;
      }
      set
      {
        this._dvSiteAuthorityAudit = value;
        this._dvSiteAuthorityAudit.AllowNew = false;
        this._dvSiteAuthorityAudit.AllowEdit = false;
        this._dvSiteAuthorityAudit.AllowDelete = false;
        this._dvSiteAuthorityAudit.Table.TableName = Enums.TableNames.tblAuthority.ToString();
        this.dgAuthorityAudit.DataSource = (object) this.SiteAuthorityAuditDataView;
      }
    }

    private void PopulateSiteAuthority()
    {
      try
      {
        FSM.Entity.Authority.Authority authority = App.DB.Authority.Get((object) this.CurrentSite.CustomerID, AuthoritySQL.GetBy.CustomerId);
        if (authority != null)
          this.txtCustAuthority.Text = authority.Notes;
        this.SiteAuthority = App.DB.Authority.Get((object) this.CurrentSite.SiteID, AuthoritySQL.GetBy.SiteId);
        if (this.SiteAuthority != null)
          this.txtSiteAuth.Text = this.SiteAuthority.Notes;
        this.SiteAuthorityAuditDataView = App.DB.Authority.Audit_Get((object) this.CurrentSite.SiteID, AuthoritySQL.GetBy.SiteId);
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
      if (string.IsNullOrEmpty(this.txtSiteAuth.Text))
        return;
      if (this.SiteAuthority == null)
      {
        this.SiteAuthority = new FSM.Entity.Authority.Authority();
        this.SiteAuthority.SetNotes = (object) this.txtSiteAuth.Text;
        App.DB.Authority.Insert_Site(this.CurrentSite.SiteID, this.SiteAuthority);
      }
      else
      {
        string change = string.Empty;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.SiteAuthority.Notes, this.txtSiteAuth.Text, false) > 0U)
          change = change + "Changed: " + this.SiteAuthority.Notes.Replace("\r", " ").Replace("\n", " ");
        this.SiteAuthority.SetNotes = (object) this.txtSiteAuth.Text;
        App.DB.Authority.Update(this.SiteAuthority, change);
      }
      this.PopulateSiteAuthority();
    }

    private void chkHeadOffice_Click(object sender, EventArgs e)
    {
      this.chkHeadOffice.Checked = !this.chkHeadOffice.Checked;
      if (!this.chkHeadOffice.Checked)
        return;
      FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) this.CurrentSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
      if (site != null && site.SiteID != this.CurrentSite.SiteID)
      {
        string message = this.theCustomer.Name + " has already got a head office against it. '" + site.Address1 + " " + site.Postcode + "'\r\n\r\nPlease remove the current head office before assigning this site.";
        this.chkHeadOffice.Checked = false;
        throw new SecurityException(message);
      }
    }
  }
}
