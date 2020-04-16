// Decompiled with JetBrains decompiler
// Type: FSM.UCLogCallout
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContactAttempts;
using FSM.Entity.ContractsOriginal;
using FSM.Entity.Customers;
using FSM.Entity.EngineerVisits;
using FSM.Entity.FleetVans;
using FSM.Entity.JobAssets;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.PartTransactions;
using FSM.Entity.ProductTransactions;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using FSM.Entity.Users;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCLogCallout : UCBase, IUserControl
  {
    private IContainer components;
    private bool IsNewJobOfWork;
    private FRMLogCallout _onForm;
    private int _jobId;
    private int _siteId;
    private Job _job;
    private FSM.Entity.Sites.Site _site;
    private FSM.Entity.Customers.Customer _customer;
    private JobNumber _jobNumber;
    private User _salesRep;
    private FleetVan _fleet;
    private List<JobOfWork> _jobOfWorks;
    private List<EngineerVisit> _engineerVisits;
    private List<ContactAttempt> _contactAttempts;
    private DataView _dvAssests;
    private DataView _dvEngineerVisitsPartsAllocated;
    private DataView _dvSiteAssests;
    private DataView _dvJobItems;
    private DataView _dvEngineers;
    private DataView _dvCustomerPriorities;
    private DataView _dvEngineerLevels;
    private ArrayList _EngineerVisitsRemoved;
    private ArrayList _JobOfWorksRemoved;
    private ArrayList _EngineerVisitsOrdersRemoved;

    public UCLogCallout()
    {
      this.Load += new EventHandler(this.UCLogCallout_Load);
      this.IsNewJobOfWork = false;
      this._onForm = (FRMLogCallout) null;
      this._jobNumber = new JobNumber();
      this._EngineerVisitsRemoved = new ArrayList();
      this._JobOfWorksRemoved = new ArrayList();
      this._EngineerVisitsOrdersRemoved = new ArrayList();
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TextBox txtJobNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboJobType
    {
      get
      {
        return this._cboJobType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboJobType_SelectedIndexChanged);
        ComboBox cboJobType1 = this._cboJobType;
        if (cboJobType1 != null)
          cboJobType1.SelectedIndexChanged -= eventHandler;
        this._cboJobType = value;
        ComboBox cboJobType2 = this._cboJobType;
        if (cboJobType2 == null)
          return;
        cboJobType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSiteDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomerName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rdoQuoted
    {
      get
      {
        return this._rdoQuoted;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoQuoted_CheckedChanged);
        RadioButton rdoQuoted1 = this._rdoQuoted;
        if (rdoQuoted1 != null)
          rdoQuoted1.CheckedChanged -= eventHandler;
        this._rdoQuoted = value;
        RadioButton rdoQuoted2 = this._rdoQuoted;
        if (rdoQuoted2 == null)
          return;
        rdoQuoted2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rdoContract
    {
      get
      {
        return this._rdoContract;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoContract_CheckedChanged);
        RadioButton rdoContract1 = this._rdoContract;
        if (rdoContract1 != null)
          rdoContract1.CheckedChanged -= eventHandler;
        this._rdoContract = value;
        RadioButton rdoContract2 = this._rdoContract;
        if (rdoContract2 == null)
          return;
        rdoContract2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rdoMisc
    {
      get
      {
        return this._rdoMisc;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoMisc_CheckedChanged);
        RadioButton rdoMisc1 = this._rdoMisc;
        if (rdoMisc1 != null)
          rdoMisc1.CheckedChanged -= eventHandler;
        this._rdoMisc = value;
        RadioButton rdoMisc2 = this._rdoMisc;
        if (rdoMisc2 == null)
          return;
        rdoMisc2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rdoCallout
    {
      get
      {
        return this._rdoCallout;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoCallout_CheckedChanged);
        RadioButton rdoCallout1 = this._rdoCallout;
        if (rdoCallout1 != null)
          rdoCallout1.CheckedChanged -= eventHandler;
        this._rdoCallout = value;
        RadioButton rdoCallout2 = this._rdoCallout;
        if (rdoCallout2 == null)
          return;
        rdoCallout2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Button btnRemoveJobOfWork
    {
      get
      {
        return this._btnRemoveJobOfWork;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveJobOfWork_Click);
        Button btnRemoveJobOfWork1 = this._btnRemoveJobOfWork;
        if (btnRemoveJobOfWork1 != null)
          btnRemoveJobOfWork1.Click -= eventHandler;
        this._btnRemoveJobOfWork = value;
        Button btnRemoveJobOfWork2 = this._btnRemoveJobOfWork;
        if (btnRemoveJobOfWork2 == null)
          return;
        btnRemoveJobOfWork2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddJobOfWork
    {
      get
      {
        return this._btnAddJobOfWork;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddJobOfWork_Click);
        Button btnAddJobOfWork1 = this._btnAddJobOfWork;
        if (btnAddJobOfWork1 != null)
          btnAddJobOfWork1.Click -= eventHandler;
        this._btnAddJobOfWork = value;
        Button btnAddJobOfWork2 = this._btnAddJobOfWork;
        if (btnAddJobOfWork2 == null)
          return;
        btnAddJobOfWork2.Click += eventHandler;
      }
    }

    internal virtual TabControl tcJobOfWorks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOnHold { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbxToBePartPaid { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRetention { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCurrentContract { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkPOC { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkOTI { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCustomerName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSiteName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkFoc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractInactive { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnChange
    {
      get
      {
        return this._btnChange;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnChange_Click);
        Button btnChange1 = this._btnChange;
        if (btnChange1 != null)
          btnChange1.Click -= eventHandler;
        this._btnChange = value;
        Button btnChange2 = this._btnChange;
        if (btnChange2 == null)
          return;
        btnChange2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtContact { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gbPaymentType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnfindVan
    {
      get
      {
        return this._btnfindVan;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnfindVan_Click);
        Button btnfindVan1 = this._btnfindVan;
        if (btnfindVan1 != null)
          btnfindVan1.Click -= eventHandler;
        this._btnfindVan = value;
        Button btnfindVan2 = this._btnfindVan;
        if (btnfindVan2 == null)
          return;
        btnfindVan2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtVanReg { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindUser
    {
      get
      {
        return this._btnFindUser;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindUser_Click);
        Button btnFindUser1 = this._btnFindUser;
        if (btnFindUser1 != null)
          btnFindUser1.Click -= eventHandler;
        this._btnFindUser = value;
        Button btnFindUser2 = this._btnFindUser;
        if (btnFindUser2 == null)
          return;
        btnFindUser2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSalesRep { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSalesRep { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpHeadline { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHeadline { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLastContactAttempt { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLastContact { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddContactAttempt
    {
      get
      {
        return this._btnAddContactAttempt;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddContactAttempt_Click);
        Button addContactAttempt1 = this._btnAddContactAttempt;
        if (addContactAttempt1 != null)
          addContactAttempt1.Click -= eventHandler;
        this._btnAddContactAttempt = value;
        Button addContactAttempt2 = this._btnAddContactAttempt;
        if (addContactAttempt2 == null)
          return;
        addContactAttempt2.Click += eventHandler;
      }
    }

    internal virtual ToolTip tt { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkCollectPayment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.btnRemoveJobOfWork = new Button();
      this.btnAddJobOfWork = new Button();
      this.tcJobOfWorks = new TabControl();
      this.rdoContract = new RadioButton();
      this.rdoQuoted = new RadioButton();
      this.txtJobNumber = new TextBox();
      this.Label5 = new Label();
      this.cboJobType = new ComboBox();
      this.label4 = new Label();
      this.rdoMisc = new RadioButton();
      this.rdoCallout = new RadioButton();
      this.Label3 = new Label();
      this.txtSiteDetails = new TextBox();
      this.txtCustomerName = new TextBox();
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.lblOnHold = new Label();
      this.cbxToBePartPaid = new CheckBox();
      this.txtRetention = new TextBox();
      this.Label7 = new Label();
      this.Label8 = new Label();
      this.txtCurrentContract = new TextBox();
      this.chkCollectPayment = new CheckBox();
      this.chkPOC = new CheckBox();
      this.chkOTI = new CheckBox();
      this.lblCustomerName = new Label();
      this.txtSiteName = new TextBox();
      this.chkFoc = new CheckBox();
      this.lblContractInactive = new Label();
      this.btnChange = new Button();
      this.txtContact = new TextBox();
      this.Label10 = new Label();
      this.gbPaymentType = new GroupBox();
      this.btnfindVan = new Button();
      this.txtVanReg = new TextBox();
      this.btnFindUser = new Button();
      this.txtSalesRep = new TextBox();
      this.lblSalesRep = new Label();
      this.grpHeadline = new GroupBox();
      this.txtHeadline = new TextBox();
      this.lblLastContactAttempt = new Label();
      this.txtLastContact = new TextBox();
      this.btnAddContactAttempt = new Button();
      this.tt = new ToolTip(this.components);
      this.gbPaymentType.SuspendLayout();
      this.grpHeadline.SuspendLayout();
      this.SuspendLayout();
      this.btnRemoveJobOfWork.AccessibleDescription = "Remove Selected Job Of Work";
      this.btnRemoveJobOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnRemoveJobOfWork.Location = new System.Drawing.Point(1157, 213);
      this.btnRemoveJobOfWork.Name = "btnRemoveJobOfWork";
      this.btnRemoveJobOfWork.Size = new Size(24, 23);
      this.btnRemoveJobOfWork.TabIndex = 16;
      this.btnRemoveJobOfWork.Text = "_";
      this.btnAddJobOfWork.AccessibleDescription = "Add Job Of Work";
      this.btnAddJobOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddJobOfWork.Location = new System.Drawing.Point(1127, 213);
      this.btnAddJobOfWork.Name = "btnAddJobOfWork";
      this.btnAddJobOfWork.Size = new Size(24, 23);
      this.btnAddJobOfWork.TabIndex = 15;
      this.btnAddJobOfWork.Text = "+";
      this.tcJobOfWorks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcJobOfWorks.Location = new System.Drawing.Point(8, 232);
      this.tcJobOfWorks.Name = "tcJobOfWorks";
      this.tcJobOfWorks.SelectedIndex = 0;
      this.tcJobOfWorks.Size = new Size(1173, 401);
      this.tcJobOfWorks.TabIndex = 17;
      this.rdoContract.Location = new System.Drawing.Point(201, 135);
      this.rdoContract.Name = "rdoContract";
      this.rdoContract.Size = new Size(72, 24);
      this.rdoContract.TabIndex = 10;
      this.rdoContract.Text = "Contract";
      this.rdoContract.UseVisualStyleBackColor = true;
      this.rdoContract.Visible = false;
      this.rdoQuoted.Location = new System.Drawing.Point(162, 123);
      this.rdoQuoted.Name = "rdoQuoted";
      this.rdoQuoted.Size = new Size(64, 24);
      this.rdoQuoted.TabIndex = 9;
      this.rdoQuoted.Text = "Quoted";
      this.rdoQuoted.UseVisualStyleBackColor = true;
      this.rdoQuoted.Visible = false;
      this.txtJobNumber.Location = new System.Drawing.Point(545, 87);
      this.txtJobNumber.MaxLength = 20;
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.ReadOnly = true;
      this.txtJobNumber.Size = new Size(117, 21);
      this.txtJobNumber.TabIndex = 4;
      this.Label5.Location = new System.Drawing.Point(461, 90);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(80, 18);
      this.Label5.TabIndex = 20;
      this.Label5.Text = "Job Number:";
      this.cboJobType.Location = new System.Drawing.Point(307, 185);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new Size(205, 21);
      this.cboJobType.TabIndex = 14;
      this.label4.Location = new System.Drawing.Point(307, 161);
      this.label4.Name = "label4";
      this.label4.Size = new Size(65, 20);
      this.label4.TabIndex = 22;
      this.label4.Text = "Job Type:";
      this.rdoMisc.Cursor = Cursors.Hand;
      this.rdoMisc.Location = new System.Drawing.Point(242, 58);
      this.rdoMisc.Name = "rdoMisc";
      this.rdoMisc.Size = new Size(56, 24);
      this.rdoMisc.TabIndex = 9;
      this.rdoMisc.Text = "Misc.";
      this.rdoMisc.UseVisualStyleBackColor = true;
      this.rdoMisc.Visible = false;
      this.rdoCallout.Cursor = Cursors.Hand;
      this.rdoCallout.Location = new System.Drawing.Point(98, 124);
      this.rdoCallout.Name = "rdoCallout";
      this.rdoCallout.Size = new Size(72, 24);
      this.rdoCallout.TabIndex = 8;
      this.rdoCallout.Text = "Callout";
      this.rdoCallout.UseVisualStyleBackColor = true;
      this.rdoCallout.Visible = false;
      this.Label3.Location = new System.Drawing.Point(20, 128);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(72, 23);
      this.Label3.TabIndex = 3;
      this.Label3.Text = "Definition:";
      this.Label3.Visible = false;
      this.txtSiteDetails.Location = new System.Drawing.Point(93, 58);
      this.txtSiteDetails.Name = "txtSiteDetails";
      this.txtSiteDetails.ReadOnly = true;
      this.txtSiteDetails.Size = new Size(569, 21);
      this.txtSiteDetails.TabIndex = 3;
      this.txtCustomerName.Location = new System.Drawing.Point(93, 0);
      this.txtCustomerName.Name = "txtCustomerName";
      this.txtCustomerName.ReadOnly = true;
      this.txtCustomerName.Size = new Size(569, 21);
      this.txtCustomerName.TabIndex = 1;
      this.Label1.Location = new System.Drawing.Point(6, 0);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(80, 23);
      this.Label1.TabIndex = 18;
      this.Label1.Text = "Customer:";
      this.Label2.Location = new System.Drawing.Point(6, 60);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(80, 23);
      this.Label2.TabIndex = 19;
      this.Label2.Text = "Property:";
      this.lblOnHold.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblOnHold.ForeColor = Color.Red;
      this.lblOnHold.Location = new System.Drawing.Point(89, 212);
      this.lblOnHold.Name = "lblOnHold";
      this.lblOnHold.Size = new Size(290, 24);
      this.lblOnHold.TabIndex = 14;
      this.lblOnHold.Text = "Customer Status: On Hold";
      this.cbxToBePartPaid.Location = new System.Drawing.Point(181, 53);
      this.cbxToBePartPaid.Name = "cbxToBePartPaid";
      this.cbxToBePartPaid.Size = new Size(240, 32);
      this.cbxToBePartPaid.TabIndex = 12;
      this.cbxToBePartPaid.Text = "Job to be paid in parts (One Invoice, many payment applications)";
      this.cbxToBePartPaid.Visible = false;
      this.txtRetention.Location = new System.Drawing.Point(427, 58);
      this.txtRetention.MaxLength = 20;
      this.txtRetention.Name = "txtRetention";
      this.txtRetention.Size = new Size(96, 21);
      this.txtRetention.TabIndex = 11;
      this.txtRetention.Visible = false;
      this.Label7.Location = new System.Drawing.Point(424, 29);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(88, 23);
      this.Label7.TabIndex = 0;
      this.Label7.Text = "Retention %:";
      this.Label7.Visible = false;
      this.Label8.Location = new System.Drawing.Point(7, 121);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(72, 23);
      this.Label8.TabIndex = 24;
      this.Label8.Text = "Contract:";
      this.txtCurrentContract.Location = new System.Drawing.Point(92, 124);
      this.txtCurrentContract.Multiline = true;
      this.txtCurrentContract.Name = "txtCurrentContract";
      this.txtCurrentContract.ReadOnly = true;
      this.txtCurrentContract.ScrollBars = ScrollBars.Vertical;
      this.txtCurrentContract.Size = new Size(203, 78);
      this.txtCurrentContract.TabIndex = 5;
      this.chkCollectPayment.Location = new System.Drawing.Point(11, 123);
      this.chkCollectPayment.Name = "chkCollectPayment";
      this.chkCollectPayment.Size = new Size(120, 24);
      this.chkCollectPayment.TabIndex = 6;
      this.chkCollectPayment.Text = "Collect Payment";
      this.chkCollectPayment.Visible = false;
      this.chkPOC.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.chkPOC.Location = new System.Drawing.Point(81, 21);
      this.chkPOC.Name = "chkPOC";
      this.chkPOC.RightToLeft = RightToLeft.Yes;
      this.chkPOC.Size = new Size(55, 19);
      this.chkPOC.TabIndex = 12;
      this.chkPOC.Text = "POC";
      this.chkOTI.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.chkOTI.Location = new System.Drawing.Point(143, 20);
      this.chkOTI.Name = "chkOTI";
      this.chkOTI.RightToLeft = RightToLeft.Yes;
      this.chkOTI.Size = new Size(56, 20);
      this.chkOTI.TabIndex = 13;
      this.chkOTI.Text = "OTI";
      this.lblCustomerName.Location = new System.Drawing.Point(6, 27);
      this.lblCustomerName.Name = "lblCustomerName";
      this.lblCustomerName.Size = new Size(80, 23);
      this.lblCustomerName.TabIndex = 29;
      this.lblCustomerName.Text = "Name:";
      this.txtSiteName.Location = new System.Drawing.Point(94, 29);
      this.txtSiteName.Name = "txtSiteName";
      this.txtSiteName.ReadOnly = true;
      this.txtSiteName.Size = new Size(568, 21);
      this.txtSiteName.TabIndex = 2;
      this.chkFoc.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.chkFoc.Location = new System.Drawing.Point(13, 20);
      this.chkFoc.Name = "chkFoc";
      this.chkFoc.RightToLeft = RightToLeft.Yes;
      this.chkFoc.Size = new Size(56, 20);
      this.chkFoc.TabIndex = 11;
      this.chkFoc.Text = "FOC";
      this.lblContractInactive.BackColor = Color.Red;
      this.lblContractInactive.Location = new System.Drawing.Point(89, 117);
      this.lblContractInactive.Name = "lblContractInactive";
      this.lblContractInactive.Size = new Size(212, 90);
      this.lblContractInactive.TabIndex = 30;
      this.lblContractInactive.Visible = false;
      this.btnChange.Location = new System.Drawing.Point(518, 184);
      this.btnChange.Name = "btnChange";
      this.btnChange.Size = new Size(82, 22);
      this.btnChange.TabIndex = 31;
      this.btnChange.Text = "Change";
      this.btnChange.UseVisualStyleBackColor = true;
      this.txtContact.Location = new System.Drawing.Point(92, 87);
      this.txtContact.MaxLength = 20;
      this.txtContact.Name = "txtContact";
      this.txtContact.ReadOnly = true;
      this.txtContact.Size = new Size(363, 21);
      this.txtContact.TabIndex = 34;
      this.Label10.Location = new System.Drawing.Point(6, 90);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(84, 23);
      this.Label10.TabIndex = 35;
      this.Label10.Text = "Contact Info:";
      this.gbPaymentType.Controls.Add((Control) this.chkOTI);
      this.gbPaymentType.Controls.Add((Control) this.chkPOC);
      this.gbPaymentType.Controls.Add((Control) this.chkFoc);
      this.gbPaymentType.Location = new System.Drawing.Point(307, 114);
      this.gbPaymentType.Name = "gbPaymentType";
      this.gbPaymentType.Size = new Size(205, 44);
      this.gbPaymentType.TabIndex = 36;
      this.gbPaymentType.TabStop = false;
      this.gbPaymentType.Text = "Payment Type";
      this.btnfindVan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnfindVan.BackColor = Color.White;
      this.btnfindVan.Enabled = false;
      this.btnfindVan.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindVan.Location = new System.Drawing.Point(1149, 179);
      this.btnfindVan.Name = "btnfindVan";
      this.btnfindVan.Size = new Size(32, 23);
      this.btnfindVan.TabIndex = 37;
      this.btnfindVan.Text = "...";
      this.btnfindVan.UseVisualStyleBackColor = false;
      this.btnfindVan.Visible = false;
      this.txtVanReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtVanReg.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtVanReg.Location = new System.Drawing.Point(895, 179);
      this.txtVanReg.Name = "txtVanReg";
      this.txtVanReg.ReadOnly = true;
      this.txtVanReg.Size = new Size(247, 21);
      this.txtVanReg.TabIndex = 36;
      this.txtVanReg.Visible = false;
      this.btnFindUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindUser.BackColor = Color.White;
      this.btnFindUser.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindUser.Location = new System.Drawing.Point(1149, 150);
      this.btnFindUser.Name = "btnFindUser";
      this.btnFindUser.Size = new Size(32, 23);
      this.btnFindUser.TabIndex = 39;
      this.btnFindUser.Text = "...";
      this.btnFindUser.UseVisualStyleBackColor = false;
      this.txtSalesRep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtSalesRep.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSalesRep.Location = new System.Drawing.Point(895, 152);
      this.txtSalesRep.Name = "txtSalesRep";
      this.txtSalesRep.ReadOnly = true;
      this.txtSalesRep.Size = new Size(248, 21);
      this.txtSalesRep.TabIndex = 38;
      this.lblSalesRep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblSalesRep.Location = new System.Drawing.Point(813, 155);
      this.lblSalesRep.Name = "lblSalesRep";
      this.lblSalesRep.Size = new Size(76, 18);
      this.lblSalesRep.TabIndex = 40;
      this.lblSalesRep.Text = "Sales Rep:";
      this.grpHeadline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.grpHeadline.Controls.Add((Control) this.txtHeadline);
      this.grpHeadline.Location = new System.Drawing.Point(709, 0);
      this.grpHeadline.Name = "grpHeadline";
      this.grpHeadline.Size = new Size(472, 52);
      this.grpHeadline.TabIndex = 43;
      this.grpHeadline.TabStop = false;
      this.grpHeadline.Text = "Job Headline";
      this.txtHeadline.Dock = DockStyle.Fill;
      this.txtHeadline.Location = new System.Drawing.Point(3, 17);
      this.txtHeadline.Multiline = true;
      this.txtHeadline.Name = "txtHeadline";
      this.txtHeadline.ScrollBars = ScrollBars.Vertical;
      this.txtHeadline.Size = new Size(466, 32);
      this.txtHeadline.TabIndex = 43;
      this.lblLastContactAttempt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblLastContactAttempt.Location = new System.Drawing.Point(683, 60);
      this.lblLastContactAttempt.Name = "lblLastContactAttempt";
      this.lblLastContactAttempt.Size = new Size(84, 18);
      this.lblLastContactAttempt.TabIndex = 44;
      this.lblLastContactAttempt.Text = "Last Contact:";
      this.txtLastContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtLastContact.Location = new System.Drawing.Point(773, 60);
      this.txtLastContact.Multiline = true;
      this.txtLastContact.Name = "txtLastContact";
      this.txtLastContact.ReadOnly = true;
      this.txtLastContact.ScrollBars = ScrollBars.Vertical;
      this.txtLastContact.Size = new Size(408, 77);
      this.txtLastContact.TabIndex = 45;
      this.btnAddContactAttempt.AccessibleDescription = "";
      this.btnAddContactAttempt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddContactAttempt.Location = new System.Drawing.Point(743, 112);
      this.btnAddContactAttempt.Name = "btnAddContactAttempt";
      this.btnAddContactAttempt.Size = new Size(24, 23);
      this.btnAddContactAttempt.TabIndex = 46;
      this.btnAddContactAttempt.Text = "+";
      this.tt.SetToolTip((Control) this.btnAddContactAttempt, "Add new contact attempt");
      this.Controls.Add((Control) this.btnAddContactAttempt);
      this.Controls.Add((Control) this.txtLastContact);
      this.Controls.Add((Control) this.lblLastContactAttempt);
      this.Controls.Add((Control) this.grpHeadline);
      this.Controls.Add((Control) this.gbPaymentType);
      this.Controls.Add((Control) this.lblSalesRep);
      this.Controls.Add((Control) this.btnFindUser);
      this.Controls.Add((Control) this.txtSalesRep);
      this.Controls.Add((Control) this.btnfindVan);
      this.Controls.Add((Control) this.txtVanReg);
      this.Controls.Add((Control) this.txtContact);
      this.Controls.Add((Control) this.Label10);
      this.Controls.Add((Control) this.txtCurrentContract);
      this.Controls.Add((Control) this.lblContractInactive);
      this.Controls.Add((Control) this.txtJobNumber);
      this.Controls.Add((Control) this.cboJobType);
      this.Controls.Add((Control) this.btnChange);
      this.Controls.Add((Control) this.txtSiteName);
      this.Controls.Add((Control) this.lblCustomerName);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.txtCustomerName);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.rdoCallout);
      this.Controls.Add((Control) this.txtSiteDetails);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.btnRemoveJobOfWork);
      this.Controls.Add((Control) this.btnAddJobOfWork);
      this.Controls.Add((Control) this.tcJobOfWorks);
      this.Controls.Add((Control) this.lblOnHold);
      this.Controls.Add((Control) this.rdoQuoted);
      this.Controls.Add((Control) this.chkCollectPayment);
      this.Controls.Add((Control) this.txtRetention);
      this.Controls.Add((Control) this.Label7);
      this.Controls.Add((Control) this.rdoContract);
      this.Controls.Add((Control) this.cbxToBePartPaid);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.rdoMisc);
      this.Controls.Add((Control) this.label4);
      this.Name = nameof (UCLogCallout);
      this.Size = new Size(1188, 620);
      this.gbPaymentType.ResumeLayout(false);
      this.grpHeadline.ResumeLayout(false);
      this.grpHeadline.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.Job;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public FRMLogCallout OnForm
    {
      get
      {
        return this._onForm;
      }
      set
      {
        this._onForm = value;
      }
    }

    public int JobId
    {
      get
      {
        return this._jobId;
      }
      set
      {
        this._jobId = value;
      }
    }

    public int SiteId
    {
      get
      {
        return this._siteId;
      }
      set
      {
        this._siteId = value;
      }
    }

    public Job Job
    {
      get
      {
        return this._job;
      }
      set
      {
        this._job = value;
        if (this._job != null)
          return;
        this._job = new Job();
      }
    }

    public FSM.Entity.Sites.Site Site
    {
      get
      {
        return this._site;
      }
      set
      {
        this._site = value;
        if (this._site != null)
          return;
        this._site = new FSM.Entity.Sites.Site();
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
      }
    }

    public JobNumber JobNumber
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

    public User SalesRep
    {
      get
      {
        return this._salesRep;
      }
      set
      {
        this._salesRep = value;
        if (this._salesRep == null)
        {
          this._salesRep = new User();
          this._salesRep.Exists = false;
          this.txtSalesRep.Text = "N/A";
        }
        else
          this.txtSalesRep.Text = this._salesRep.Fullname;
      }
    }

    public FleetVan Fleet
    {
      get
      {
        return this._fleet;
      }
      set
      {
        this._fleet = value;
        if (this._fleet == null)
        {
          this._fleet = new FleetVan();
          this._fleet.Exists = false;
        }
        else
          this.txtVanReg.Text = this._fleet.Registration;
      }
    }

    public List<JobOfWork> JobOfWorks
    {
      get
      {
        return this._jobOfWorks;
      }
      set
      {
        this._jobOfWorks = value;
        if (this._jobOfWorks != null)
          return;
        this._jobOfWorks = new List<JobOfWork>();
      }
    }

    public List<EngineerVisit> EngineerVisits
    {
      get
      {
        return this._engineerVisits;
      }
      set
      {
        this._engineerVisits = value;
        if (this._engineerVisits != null)
          return;
        this._engineerVisits = new List<EngineerVisit>();
      }
    }

    public List<ContactAttempt> ContactAttempts
    {
      get
      {
        return this._contactAttempts;
      }
      set
      {
        this._contactAttempts = value;
        if (this._contactAttempts != null)
          return;
        this._contactAttempts = new List<ContactAttempt>();
      }
    }

    public DataView DvAssets
    {
      get
      {
        return this._dvAssests;
      }
      set
      {
        this._dvAssests = value;
      }
    }

    public DataView DvEngineerVisitsPartsAllocated
    {
      get
      {
        return this._dvEngineerVisitsPartsAllocated;
      }
      set
      {
        this._dvEngineerVisitsPartsAllocated = value;
      }
    }

    public DataView DvSiteAssets
    {
      get
      {
        return this._dvSiteAssests;
      }
      set
      {
        this._dvSiteAssests = value;
      }
    }

    public DataView DvJobItems
    {
      get
      {
        return this._dvJobItems;
      }
      set
      {
        this._dvJobItems = value;
      }
    }

    public DataView DvEngineers
    {
      get
      {
        return this._dvEngineers;
      }
      set
      {
        this._dvEngineers = value;
      }
    }

    public DataView DvCustomerPriorities
    {
      get
      {
        return this._dvCustomerPriorities;
      }
      set
      {
        this._dvCustomerPriorities = value;
      }
    }

    public DataView DvEngineerLevels
    {
      get
      {
        return this._dvEngineerLevels;
      }
      set
      {
        this._dvEngineerLevels = value;
      }
    }

    public ArrayList EngineerVisitsRemoved
    {
      get
      {
        return this._EngineerVisitsRemoved;
      }
      set
      {
        this._EngineerVisitsRemoved = value;
      }
    }

    public ArrayList JobOfWorksRemoved
    {
      get
      {
        return this._JobOfWorksRemoved;
      }
      set
      {
        this._JobOfWorksRemoved = value;
      }
    }

    public ArrayList EngineerVisitsOrdersRemoved
    {
      get
      {
        return this._EngineerVisitsOrdersRemoved;
      }
      set
      {
        this._EngineerVisitsOrdersRemoved = value;
      }
    }

    private void UCLogCallout_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void rdoCallout_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Job.JobID == 0)
        this.Job.SetJobDefinitionEnumID = (object) 3;
      this.PaymentTypeChanged();
    }

    private void rdoMisc_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Job.JobID == 0)
        this.Job.SetJobDefinitionEnumID = (object) 4;
      this.PaymentTypeChanged();
    }

    private void rdoContract_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Job.JobID == 0)
        this.Job.SetJobDefinitionEnumID = (object) 2;
      this.PaymentTypeChanged();
    }

    private void rdoQuoted_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Job.JobID == 0)
        this.Job.SetJobDefinitionEnumID = (object) 1;
      this.PaymentTypeChanged();
    }

    private void btnAddJobOfWork_Click(object sender, EventArgs e)
    {
      this.AddJobOfWork((JobOfWork) null);
      this.IsNewJobOfWork = true;
    }

    private void btnRemoveJobOfWork_Click(object sender, EventArgs e)
    {
      this.RemoveJobOfWork();
    }

    private void btnChange_Click(object sender, EventArgs e)
    {
      if (!App.EnterOverridePassword())
        return;
      FRMChangeJobType frmChangeJobType = new FRMChangeJobType();
      int num = (int) frmChangeJobType.ShowDialog();
      ComboBox cboJobType = this.cboJobType;
      Combo.SetSelectedComboItem_By_Value(ref cboJobType, Combo.get_GetSelectedItemValue(frmChangeJobType.cboJobType));
      this.cboJobType = cboJobType;
      this.Save();
    }

    public void Populate(int ID = 0)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.PopulateProperties();
        this.PopulateSite();
        if (!App.IsRFT)
          this.PopulateContract();
        this.PopulateJobOfWorks();
        this.PopulateJob();
        this.PopulateContactAttempts();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot load : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void PopulateProperties()
    {
      this.tcJobOfWorks.TabPages.Clear();
      this.Site = App.DB.Sites.Get((object) this.JobId, SiteSQL.GetBy.JobId, (object) null);
      if (this.Site.SiteID == 0)
        this.Site = App.DB.Sites.Get((object) this.SiteId, SiteSQL.GetBy.SiteId, (object) null);
      this.Customer = App.DB.Customer.Customer_Get(this.Site.CustomerID);
      this.DvSiteAssets = App.DB.Asset.Asset_GetForSite(this.Site.SiteID);
      this.DvEngineerVisitsPartsAllocated = App.DB.EngineerVisitPartProductAllocated.Get_ByJobId(this.JobId);
      this.DvJobItems = App.DB.JobItems.JobItems_Get_For_Job(this.JobId);
      this.DvEngineers = App.DB.Engineer.Engineer_GetAll();
      this.DvAssets = App.DB.JobAsset.JobAsset_Get_For_Job(this.JobId);
      this.DvCustomerPriorities = App.DB.Customer.CustomerPriority_Get(this.Site.CustomerID);
      this.DvEngineerLevels = App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels, false);
      this.Job = App.DB.Job.Get(this.JobId, FSM.Entity.Jobs.GetBy.JobId);
      this.SalesRep = App.DB.User.Get(this.Job.SalesRepUserID, false);
      this.JobOfWorks = App.DB.JobOfWorks.Get_ByJobId(this.JobId);
      this.EngineerVisits = App.DB.EngineerVisits.Get_ByJobId(this.JobId);
    }

    private void PopulateJob()
    {
      if (this.Job.JobID == 0)
        this.Job.SetJobDefinitionEnumID = (object) 3;
      switch (this.Job.JobDefinitionEnumID)
      {
        case 1:
          this.rdoCallout.Checked = false;
          this.rdoMisc.Checked = false;
          this.rdoContract.Checked = false;
          this.rdoQuoted.Checked = true;
          break;
        case 2:
          this.rdoCallout.Checked = false;
          this.rdoMisc.Checked = false;
          this.rdoContract.Checked = true;
          this.rdoQuoted.Checked = false;
          break;
        case 3:
          this.rdoCallout.Checked = true;
          this.rdoMisc.Checked = false;
          this.rdoContract.Checked = false;
          this.rdoQuoted.Checked = false;
          break;
        case 4:
          this.rdoCallout.Checked = false;
          this.rdoMisc.Checked = true;
          this.rdoContract.Checked = false;
          this.rdoQuoted.Checked = false;
          break;
      }
      ComboBox cboJobType1 = this.cboJobType;
      Combo.SetSelectedComboItem_By_Value(ref cboJobType1, Conversions.ToString(this.Job.JobTypeID));
      this.cboJobType = cboJobType1;
      this.txtJobNumber.Text = this.Job.JobNumber;
      this.cbxToBePartPaid.Checked = this.Job.ToBePartPaid;
      this.txtRetention.Text = Conversions.ToString(this.Job.Retention);
      this.chkCollectPayment.Checked = this.Job.CollectPayment;
      this.chkPOC.Checked = this.Job.POC;
      this.chkOTI.Checked = this.Job.OTI;
      this.chkFoc.Checked = this.Job.FOC;
      this.txtHeadline.Text = this.Job.Headline;
      this.btnAddContactAttempt.Enabled = this.Job.JobID > 0;
      if (this.tcJobOfWorks.TabPages.Count > 0)
        this.tcJobOfWorks.SelectedTab = this.tcJobOfWorks.TabPages[0];
      this.rdoCallout.Enabled = false;
      this.rdoMisc.Enabled = false;
      this.rdoContract.Enabled = false;
      this.rdoQuoted.Enabled = false;
      this.cbxToBePartPaid.Enabled = false;
      this.txtRetention.Enabled = false;
      this.chkCollectPayment.Enabled = false;
      if (this.Job.StatusEnumID >= 2)
      {
        this.btnAddJobOfWork.Enabled = false;
        this.btnRemoveJobOfWork.Enabled = false;
        this.OnForm.btnSave.Enabled = false;
        this.OnForm.btnAddAppliance.Visible = false;
      }
      if (this.Job.JobCreationType == 2 & !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor))
      {
        this.btnAddJobOfWork.Visible = false;
        this.btnRemoveJobOfWork.Visible = false;
        IEnumerator enumerator;
        try
        {
          enumerator = this.tcJobOfWorks.TabPages.GetEnumerator();
          while (enumerator.MoveNext())
          {
            TabPage current = (TabPage) enumerator.Current;
            ((UCCalloutBreakdown) current.Controls[0]).btnAddEngineerVisit.Visible = false;
            ((UCCalloutBreakdown) current.Controls[0]).btnRemoveEngineerVisit.Visible = false;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      if (this.Job.JobCreationType == 1)
      {
        bool flag = true;
        try
        {
          foreach (JobOfWork jobOfWork in this.JobOfWorks)
          {
            if (jobOfWork.Status == 1)
              flag = false;
          }
        }
        finally
        {
          List<JobOfWork>.Enumerator enumerator;
          enumerator.Dispose();
        }
        this.btnAddJobOfWork.Visible = flag;
        this.btnRemoveJobOfWork.Visible = flag;
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.tcJobOfWorks.TabPages.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            TabPage current = (TabPage) enumerator1.Current;
            ((UCCalloutBreakdown) current.Controls[0]).btnAddEngineerVisit.Visible = false;
            ((UCCalloutBreakdown) current.Controls[0]).btnRemoveEngineerVisit.Visible = false;
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
      }
      ComboBox cboJobType2;
      if (this.Customer.CustomerID == 4401)
      {
        this.cboJobType.Enabled = true;
        this.btnChange.Visible = false;
        cboJobType2 = this.cboJobType;
        Combo.SetUpCombo(ref cboJobType2, App.DB.Fleet.FleetJobType_GetAll().Table, "JobTypeID", "Name", Enums.ComboValues.Please_Select);
        this.cboJobType = cboJobType2;
        int vanId = 0;
        if (this.Job.JobTypeID == 2)
        {
          FleetVanFault byJobId = App.DB.FleetVanFault.Get_ByJobID(this.Job.JobID);
          if (byJobId != null)
            vanId = byJobId.VanID;
        }
        if (this.Job.JobTypeID == 1)
        {
          vanId = App.DB.FleetVanService.GetVanId_ByJobId(this.Job.JobID);
          this.btnfindVan.Enabled = true;
        }
        if (vanId > 0)
        {
          this.Fleet = App.DB.FleetVan.Get(vanId);
          this.txtVanReg.Text = this.Fleet.Registration;
        }
        this.txtVanReg.Visible = true;
        this.btnfindVan.Visible = true;
      }
      else
      {
        ComboBox cboJobType3 = this.cboJobType;
        Combo.SetUpCombo(ref cboJobType3, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
        this.cboJobType = cboJobType3;
        this.txtVanReg.Visible = false;
        this.btnfindVan.Visible = false;
      }
      cboJobType2 = this.cboJobType;
      Combo.SetSelectedComboItem_By_Value(ref cboJobType2, Conversions.ToString(this.Job.JobTypeID));
      this.cboJobType = cboJobType2;
      IEnumerator enumerator2;
      if (this.DvAssets != null)
      {
        try
        {
          enumerator2 = this.OnForm.AssetsDataView.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator2.Current;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = this.DvAssets.Table.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current2 = (DataRow) enumerator1.Current;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual((object) Conversions.ToInteger(current1["AssetID"]), current2["AssetID"], false))
                {
                  current1["Tick"] = (object) true;
                  break;
                }
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      if (App.IsRFT)
      {
        this.gbPaymentType.Visible = false;
        this.chkOTI.Checked = true;
      }
      int? userId1 = this.OnForm?.JobLock?.UserID;
      int userId2 = App.loggedInUser.UserID;
      if ((userId1.HasValue ? new bool?(userId1.GetValueOrDefault() != userId2) : new bool?()).GetValueOrDefault())
        this.OnForm.MakeReadOnly();
      if (this.Job.JobID != 0 || Helper.IsStringEmpty((object) this.Site.ContactAlerts))
        return;
      ((UCVisitBreakdown) ((UCCalloutBreakdown) this.tcJobOfWorks?.TabPages[0].Controls[0]).tcEngineerVisits.TabPages[0].Controls[0]).txtNotesToEngineer.Text = this.Site.ContactAlerts + " - ";
    }

    private void PopulateSite()
    {
      this.txtCustomerName.Text = this.Customer.Name;
      this.txtSiteDetails.Text = this.Site.Address1 + " " + this.Site.Address2 + ", " + this.Site.Postcode;
      this.txtSiteName.Text = this.Site.Name;
      this.txtContact.Text = "Tel: " + this.Site.TelephoneNum + " Mob: " + this.Site.FaxNum;
      FSM.Entity.Sites.Site site1 = App.DB.Sites.Get((object) this.Customer.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
      if (site1 != null)
      {
        FSM.Entity.Sites.Site site2 = site1;
        TextBox txtCustomerName;
        string str = (txtCustomerName = this.txtCustomerName).Text + " - " + site2.Address1 + ", " + site2.Address2 + " (Tel: " + site2.TelephoneNum + ")";
        txtCustomerName.Text = str;
      }
      if (this.Customer.Status == 3)
        this.lblOnHold.Visible = true;
      else
        this.lblOnHold.Visible = false;
      if (this.OnForm.AssetsDataView != null)
        return;
      this.OnForm.AssetsDataView = this.DvSiteAssets;
    }

    private void PopulateJobOfWorks()
    {
      if (this.JobOfWorks.Count > 0)
      {
        // ISSUE: reference to a compiler-generated method
        this.JobOfWorks.ForEach((Action<JobOfWork>) (a0 => this._Lambda\u0024__292\u002D0(a0)));
      }
      else
        this.AddJobOfWork((JobOfWork) null);
    }

    public void PopulateContract()
    {
      ContractOriginal currentForSite = App.DB.ContractOriginal.Get_Current_ForSite(this.Site.SiteID);
      if (currentForSite == null)
      {
        this.txtCurrentContract.Text = "Not on contract";
        this.lblContractInactive.Visible = false;
      }
      else
      {
        this.txtCurrentContract.Text = currentForSite.ContractType + "\r\n" + ((Enums.ContractStatus) currentForSite.ContractStatusID).ToString() + "\r\nExpires " + Microsoft.VisualBasic.Strings.Format((object) currentForSite.ContractEndDate, "dd/MM/yyyy");
        if (currentForSite.ContractStatusID == 4)
          this.lblContractInactive.Visible = true;
        else
          this.lblContractInactive.Visible = false;
      }
    }

    private void PopulateContactAttempts()
    {
      this.ContactAttempts = App.DB.ContactAttempts.GetAll_ForJob(this.JobId);
      List<ContactAttempt> contactAttempts1 = this.ContactAttempts;
      // ISSUE: explicit non-virtual call
      if (contactAttempts1 == null || __nonvirtual (contactAttempts1.Count) <= 0)
        return;
      List<ContactAttempt> contactAttempts2 = this.ContactAttempts;
      Func<ContactAttempt, DateTime> keySelector;
      // ISSUE: reference to a compiler-generated field
      if (UCLogCallout._Closure\u0024__.\u0024I294\u002D0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        keySelector = UCLogCallout._Closure\u0024__.\u0024I294\u002D0;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        UCLogCallout._Closure\u0024__.\u0024I294\u002D0 = keySelector = (Func<ContactAttempt, DateTime>) (ca => ca.ContactMade);
      }
      ContactAttempt contactAttempt = contactAttempts2.OrderByDescending<ContactAttempt, DateTime>(keySelector).FirstOrDefault<ContactAttempt>();
      if (contactAttempt != null)
      {
        this.txtLastContact.Text = contactAttempt.ContactMade.ToString("dddd, dd MMMM yyyy HH:mm") + ": " + contactAttempt.ContactMethod;
        if (contactAttempt.Notes.Trim().Length > 0)
        {
          TextBox txtLastContact;
          string str = (txtLastContact = this.txtLastContact).Text + " - " + contactAttempt.Notes;
          txtLastContact.Text = str;
        }
        if (contactAttempt.ContactMadeBy.Trim().Length > 0)
        {
          TextBox txtLastContact;
          string str = (txtLastContact = this.txtLastContact).Text + " by " + contactAttempt.ContactMadeBy;
          txtLastContact.Text = str;
        }
      }
    }

    public void PaymentTypeChanged()
    {
      if (this.Job.JobID != 0)
        return;
      App.DB.Job.DeleteReservedOrderNumber(this.JobNumber.JobNumber, this.JobNumber.Prefix);
      this.JobNumber = App.DB.Job.GetNextJobNumber((Enums.JobDefinition) this.Job.JobDefinitionEnumID);
      this.Job.SetJobNumber = (object) (this.JobNumber.Prefix + Conversions.ToString(this.JobNumber.JobNumber));
      this.txtJobNumber.Text = this.Job.JobNumber;
    }

    private TabPage AddJobOfWork(JobOfWork jobOfWork)
    {
      TabPage tabPage = new TabPage();
      tabPage.BackColor = Color.White;
      UCCalloutBreakdown calloutBreakdown = new UCCalloutBreakdown();
      calloutBreakdown.OnContol = this;
      IEnumerator enumerator;
      if (jobOfWork == null)
      {
        try
        {
          enumerator = this.DvSiteAssets.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["WarrantyStartDate"])), DateAndTime.Now) < 0 & DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["WarrantyEndDate"])), DateAndTime.Now) > 0)
            {
              int num = (int) App.ShowMessage("One or more assets are under warranty.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
      calloutBreakdown.JobOfWork = jobOfWork;
      calloutBreakdown.Populate(0);
      calloutBreakdown.Dock = DockStyle.Fill;
      tabPage.Controls.Add((Control) calloutBreakdown);
      this.tcJobOfWorks.TabPages.Add(tabPage);
      this.CheckTabs();
      this.tcJobOfWorks.SelectedTab = tabPage;
      return tabPage;
    }

    private void RemoveJobOfWork()
    {
      if (((UCCalloutBreakdown) this.tcJobOfWorks.SelectedTab.Controls[0]).JobItemsAddedDataView.Table.Rows.Count > 0 && App.ShowMessage("Items of work has been added to this visit, are you sure you want to remove it?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = ((UCCalloutBreakdown) this.tcJobOfWorks.SelectedTab.Controls[0]).tcEngineerVisits.TabPages.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          TabPage current1 = (TabPage) enumerator1.Current;
          if (((UCVisitBreakdown) current1.Controls[0]).EngineerVisit.StatusEnumID >= 5)
          {
            int num = (int) App.ShowMessage("A visit for this job of work has progressed to 'scheduled' or further so job of work cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return;
          }
          if (((UCVisitBreakdown) current1.Controls[0]).EngineerVisit.StatusEnumID == 1)
          {
            int num = (int) App.ShowMessage("A visit for this job of work has a status of 'Parts Need Ordering so job of work cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return;
          }
          bool flag = false;
          IEnumerator enumerator2;
          try
          {
            enumerator2 = ((UCCalloutBreakdown) this.tcJobOfWorks.SelectedTab.Controls[0]).tcEngineerVisits.TabPages.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              TabPage current2 = (TabPage) enumerator2.Current;
              if (((UCVisitBreakdown) current2.Controls[0]).EngineerVisit.EngineerVisitID > 0)
              {
                DataView forEngineerVisit = App.DB.Order.Orders_GetForEngineerVisit(((UCVisitBreakdown) current2.Controls[0]).EngineerVisit.EngineerVisitID);
                IEnumerator enumerator3;
                if (forEngineerVisit.Table.Rows.Count > 0)
                {
                  try
                  {
                    enumerator3 = forEngineerVisit.Table.Rows.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                      DataRow current3 = (DataRow) enumerator3.Current;
                      if (!(Conversions.ToInteger(current3["OrderStatusID"]) == 1 | Conversions.ToInteger(current3["OrderStatusID"]) == 3))
                        flag = true;
                    }
                  }
                  finally
                  {
                    if (enumerator3 is IDisposable)
                      (enumerator3 as IDisposable).Dispose();
                  }
                }
              }
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          if (flag)
          {
            int num = (int) App.ShowMessage("This job of work has orders that are being processed and therefore cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return;
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator4;
      try
      {
        enumerator4 = ((UCCalloutBreakdown) this.tcJobOfWorks.SelectedTab.Controls[0]).tcEngineerVisits.TabPages.GetEnumerator();
        while (enumerator4.MoveNext())
        {
          TabPage current1 = (TabPage) enumerator4.Current;
          if (((UCVisitBreakdown) current1.Controls[0]).EngineerVisit.EngineerVisitID > 0)
          {
            IEnumerator enumerator2;
            try
            {
              enumerator2 = ((UCCalloutBreakdown) this.tcJobOfWorks.SelectedTab.Controls[0]).tcEngineerVisits.TabPages.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                TabPage current2 = (TabPage) enumerator2.Current;
                if (((UCVisitBreakdown) current2.Controls[0]).EngineerVisit.EngineerVisitID > 0)
                {
                  DataView forEngineerVisit = App.DB.Order.Orders_GetForEngineerVisit(((UCVisitBreakdown) current2.Controls[0]).EngineerVisit.EngineerVisitID);
                  IEnumerator enumerator3;
                  if (forEngineerVisit.Table.Rows.Count > 0)
                  {
                    try
                    {
                      enumerator3 = forEngineerVisit.Table.Rows.GetEnumerator();
                      while (enumerator3.MoveNext())
                      {
                        DataRow current3 = (DataRow) enumerator3.Current;
                        if (Conversions.ToInteger(current3["OrderStatusID"]) == 1 | Conversions.ToInteger(current3["OrderStatusID"]) == 3)
                          this.EngineerVisitsOrdersRemoved.Add(RuntimeHelpers.GetObjectValue(current3["OrderID"]));
                      }
                    }
                    finally
                    {
                      if (enumerator3 is IDisposable)
                        (enumerator3 as IDisposable).Dispose();
                    }
                  }
                }
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            this.EngineerVisitsRemoved.Add((object) ((UCVisitBreakdown) current1.Controls[0]).EngineerVisit.EngineerVisitID);
          }
        }
      }
      finally
      {
        if (enumerator4 is IDisposable)
          (enumerator4 as IDisposable).Dispose();
      }
      if (((UCCalloutBreakdown) this.tcJobOfWorks.SelectedTab.Controls[0]).JobOfWork.JobOfWorkID > 0)
        this.JobOfWorksRemoved.Add((object) ((UCCalloutBreakdown) this.tcJobOfWorks.SelectedTab.Controls[0]).JobOfWork.JobOfWorkID);
      this.tcJobOfWorks.TabPages.Remove(this.tcJobOfWorks.SelectedTab);
      this.CheckTabs();
    }

    private void CheckTabs()
    {
      if (this.tcJobOfWorks.TabPages.Count == 1)
        this.btnRemoveJobOfWork.Enabled = false;
      else
        this.btnRemoveJobOfWork.Enabled = true;
      int num = 1;
      IEnumerator enumerator;
      try
      {
        enumerator = this.tcJobOfWorks.TabPages.GetEnumerator();
        while (enumerator.MoveNext())
        {
          ((TabPage) enumerator.Current).Text = "Job Of Work #" + Conversions.ToString(num);
          checked { ++num; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public bool Save()
    {
      int num1 = 0;
      int num2 = 0;
      string str1 = (string) null;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.EngineerVisitsRemoved.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          int integer = Conversions.ToInteger(enumerator1.Current);
          EngineerVisit asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(integer, true);
          if (asObject.StatusEnumID >= 5)
          {
            int num3 = (int) App.ShowMessage("A visit for this job of work has progressed to 'scheduled' or further so job of work cannot be removed.  Job needs to close, please re-do your changes.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.OnForm.CloseForm();
          }
          else if (asObject.StatusEnumID == 1)
          {
            int num3 = (int) App.ShowMessage("A visit for this job of work has a status of 'Parts Need Ordering' so job of work cannot be removed. Job needs to close, please re-do your changes.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.OnForm.CloseForm();
          }
          else
          {
            bool flag = false;
            if (asObject.Exists)
            {
              DataView forEngineerVisit = App.DB.Order.Orders_GetForEngineerVisit(asObject.EngineerVisitID);
              IEnumerator enumerator2;
              if (forEngineerVisit.Table.Rows.Count > 0)
              {
                try
                {
                  enumerator2 = forEngineerVisit.Table.Rows.GetEnumerator();
                  while (enumerator2.MoveNext())
                  {
                    DataRow current = (DataRow) enumerator2.Current;
                    if (!(Conversions.ToInteger(current["OrderStatusID"]) == 1 | Conversions.ToInteger(current["OrderStatusID"]) == 3))
                      flag = true;
                  }
                }
                finally
                {
                  if (enumerator2 is IDisposable)
                    (enumerator2 as IDisposable).Dispose();
                }
              }
            }
            if (flag)
            {
              int num3 = (int) App.ShowMessage("This job of work has orders that are being processed and therefore cannot be removed. Job needs to close, please re-do your changes.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              this.OnForm.CloseForm();
              goto label_163;
            }
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      SqlTransaction trans = (SqlTransaction) null;
      SqlConnection sqlConnection = (SqlConnection) null;
      bool flag1;
      try
      {
        sqlConnection = new SqlConnection(App.DB.ServerConnectionString);
        sqlConnection.Open();
        trans = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
        bool flag2 = true;
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.tcJobOfWorks.TabPages.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            if (((UCCalloutBreakdown) ((Control) enumerator2.Current).Controls[0]).txtPONumber.Text.Length == 0)
              flag2 = false;
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        if (!flag2 & this.Site.PoNumReqd)
        {
          if (App.ShowMessage("A Purchase Order Number is required for this Property, Would you like to Override?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            if (!App.EnterOverridePassword())
            {
              flag1 = false;
              goto label_163;
            }
          }
          else
            goto label_163;
        }
        this.Cursor = Cursors.WaitCursor;
        Job oJob = new Job()
        {
          SetJobID = (object) this.Job.JobID,
          SetJobTypeID = (object) this.Job.JobTypeID,
          SetPropertyID = (object) this.Site.SiteID
        };
        oJob.Exists = oJob.JobID > 0;
        if (oJob.JobTypeID == 1 && (this.Fleet != null && this.Fleet.Exists && App.ShowMessage("Remove service from van?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
          App.DB.FleetVanService.Delete(oJob.JobID);
        oJob.IgnoreExceptionsOnSetMethods = true;
        if (this.rdoCallout.Checked)
          oJob.SetJobDefinitionEnumID = (object) Helper.MakeIntegerValid((object) Enums.JobDefinition.Callout);
        else if (this.rdoMisc.Checked)
          oJob.SetJobDefinitionEnumID = (object) Helper.MakeIntegerValid((object) Enums.JobDefinition.Misc);
        else if (this.rdoContract.Checked)
          oJob.SetJobDefinitionEnumID = (object) Helper.MakeIntegerValid((object) Enums.JobDefinition.Contract);
        else if (this.rdoQuoted.Checked)
          oJob.SetJobDefinitionEnumID = (object) Helper.MakeIntegerValid((object) Enums.JobDefinition.Quoted);
        oJob.SetJobTypeID = (object) Combo.get_GetSelectedItemValue(this.cboJobType);
        oJob.SetJobNumber = (object) this.txtJobNumber.Text.Trim();
        oJob.SetPONumber = (object) "";
        oJob.SetToBePartPaid = (object) this.cbxToBePartPaid.Checked;
        oJob.SetRetention = (object) Helper.MakeDoubleValid((object) this.txtRetention.Text);
        oJob.SetCollectPayment = (object) this.chkCollectPayment.Checked;
        oJob.SetPOC = (object) this.chkPOC.Checked;
        oJob.SetOTI = (object) this.chkOTI.Checked;
        oJob.SetFOC = (object) this.chkFoc.Checked;
        oJob.SetSalesRepUserID = (object) this.SalesRep.UserID;
        oJob.SetHeadline = (object) this.txtHeadline.Text;
        oJob.Assets.Clear();
        IEnumerator enumerator3;
        try
        {
          enumerator3 = this.OnForm.AssetsDataView.Table.Rows.GetEnumerator();
          while (enumerator3.MoveNext())
          {
            DataRow current = (DataRow) enumerator3.Current;
            if (Conversions.ToBoolean(current["Tick"]))
              oJob.Assets.Add((object) new JobAsset()
              {
                SetAssetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["AssetID"]))
              });
          }
        }
        finally
        {
          if (enumerator3 is IDisposable)
            (enumerator3 as IDisposable).Dispose();
        }
        num1 = oJob.JobOfWorks.Count;
        int num3 = 0;
        EngineerVisit engineerVisit1 = (EngineerVisit) null;
        int num4 = 0;
        oJob.JobOfWorks.Clear();
        int num5 = 0;
        IEnumerator enumerator4;
        try
        {
          enumerator4 = this.tcJobOfWorks.TabPages.GetEnumerator();
          while (enumerator4.MoveNext())
          {
            TabPage current1 = (TabPage) enumerator4.Current;
            checked { ++num5; }
            JobOfWork jobOfWork = new JobOfWork()
            {
              SetJobOfWorkID = (object) ((UCCalloutBreakdown) current1.Controls[0]).JobOfWork.JobOfWorkID
            };
            jobOfWork.Exists = jobOfWork.JobOfWorkID > 0;
            jobOfWork.SetPONumber = (object) ((UCCalloutBreakdown) current1.Controls[0]).txtPONumber.Text;
            jobOfWork.SetQualificationID = (object) Combo.get_GetSelectedItemValue(((UCCalloutBreakdown) current1.Controls[0]).cboQualification);
            int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(((UCCalloutBreakdown) current1.Controls[0]).cboPriority));
            if (integer > 0)
              jobOfWork.SetPriority = (object) integer;
            else
              num4 = jobOfWork.Priority;
            if (num5 >= 3)
              str1 = Conversions.ToString(jobOfWork.Priority);
            if (DateTime.Compare(jobOfWork.PriorityDateSet, DateTime.MinValue) == 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(((UCCalloutBreakdown) current1.Controls[0]).cboPriority)) > 0.0)
              jobOfWork.PriorityDateSet = DateAndTime.Now;
            jobOfWork.IgnoreExceptionsOnSetMethods = true;
            jobOfWork.JobItems.Clear();
            IEnumerator enumerator5;
            try
            {
              enumerator5 = ((UCCalloutBreakdown) current1.Controls[0]).JobItemsAddedDataView.Table.Rows.GetEnumerator();
              while (enumerator5.MoveNext())
              {
                DataRow current2 = (DataRow) enumerator5.Current;
                jobOfWork.JobItems.Add((object) new JobItem()
                {
                  IgnoreExceptionsOnSetMethods = true,
                  SetJobItemID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current2["JobItemID"])),
                  SetSummary = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current2["Summary"])),
                  SetRateID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current2["RateID"])),
                  SetQty = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current2["Qty"])),
                  SetSystemLinkID = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current2["SystemLinkID"]))
                });
              }
            }
            finally
            {
              if (enumerator5 is IDisposable)
                (enumerator5 as IDisposable).Dispose();
            }
            jobOfWork.EngineerVisits.Clear();
            int count = ((UCCalloutBreakdown) current1.Controls[0]).tcEngineerVisits.TabPages.Count;
            int num6 = 1;
            IEnumerator enumerator6;
            try
            {
              enumerator6 = ((UCCalloutBreakdown) current1.Controls[0]).tcEngineerVisits.TabPages.GetEnumerator();
              while (enumerator6.MoveNext())
              {
                TabPage current2 = (TabPage) enumerator6.Current;
                EngineerVisit engineerVisit2 = new EngineerVisit()
                {
                  SetEngineerVisitID = (object) ((UCVisitBreakdown) current2.Controls[0]).EngineerVisit.EngineerVisitID
                };
                engineerVisit2.Exists = engineerVisit2.EngineerVisitID > 0;
                engineerVisit2.IgnoreExceptionsOnSetMethods = true;
                engineerVisit2.SetStatusEnumID = (object) Combo.get_GetSelectedItemValue(((UCVisitBreakdown) current2.Controls[0]).cboStatus);
                engineerVisit2.SetNotesToEngineer = (object) ((UCVisitBreakdown) current2.Controls[0]).txtNotesToEngineer.Text.Trim();
                engineerVisit2.SetPartsToFit = (object) ((UCVisitBreakdown) current2.Controls[0]).cbxPartsToFit.Checked;
                engineerVisit2.PartsAndProductsAllocated = ((UCVisitBreakdown) current2.Controls[0]).PartsAndProducts;
                engineerVisit2.SetExpectedEngineerID = (object) Combo.get_GetSelectedItemValue(((UCVisitBreakdown) current2.Controls[0]).cboExpected);
                engineerVisit2.SetRecharge = (object) ((UCVisitBreakdown) current2.Controls[0]).chkRecharge.Checked;
                engineerVisit2.setChange = (object) ((UCVisitBreakdown) current2.Controls[0]).change;
                engineerVisit2.SetExcludeFromTextMessage = (object) ((UCVisitBreakdown) current2.Controls[0]).chkSendText.Checked;
                jobOfWork.EngineerVisits.Add((object) engineerVisit2);
                if (num5 == 1 & count == 1)
                  engineerVisit1 = engineerVisit2;
                this.CleanUpOrdersForPartProductsAllocated(((UCVisitBreakdown) current2.Controls[0]).PartsProductsToRemoveFromOrder, ((UCVisitBreakdown) current2.Controls[0]).PartsProductsToReallocated, trans);
                ((UCVisitBreakdown) current2.Controls[0]).PartsProductsToRemoveFromOrder = (ArrayList) null;
                ((UCVisitBreakdown) current2.Controls[0]).PartsProductsToReallocated = (ArrayList) null;
                int outcomeEnumId = engineerVisit2.OutcomeEnumID;
                if (num6 == count && outcomeEnumId == 1 | outcomeEnumId == 5)
                  checked { ++num3; }
                checked { ++num6; }
              }
            }
            finally
            {
              if (enumerator6 is IDisposable)
                (enumerator6 as IDisposable).Dispose();
            }
            oJob.JobOfWorks.Add((object) jobOfWork);
          }
        }
        finally
        {
          if (enumerator4 is IDisposable)
            (enumerator4 as IDisposable).Dispose();
        }
        try
        {
          new JobValidator().Validate(oJob);
          if (oJob.JobTypeID == 2)
          {
            FleetVanFault fleetVanFault = (FleetVanFault) null;
            if (oJob.Exists)
              fleetVanFault = App.DB.FleetVanFault.Get_ByJobID(oJob.JobID);
            if (fleetVanFault == null)
            {
              int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblFleetVanMaintenance, 0, "", false));
              if ((uint) integer > 0U)
              {
                FleetVanFault oVan = App.DB.FleetVanFault.Get(integer);
                if (oVan != null)
                {
                  oVan.SetJobID = (object) oJob.JobID;
                  App.DB.FleetVanFault.Update(oVan);
                  this.Fleet = App.DB.FleetVan.Get(oVan.VanID);
                }
              }
            }
          }
          if (!oJob.Exists)
          {
            oJob = App.DB.Job.Insert(oJob, trans);
            trans.Commit();
            if (oJob.JobTypeID == 4703)
              this.EmailServiceAlertDate();
            int num6 = (int) App.ShowMessage("Job added for job number : " + oJob.JobNumber, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          else
          {
            App.DB.Job.Update(oJob, this.JobOfWorksRemoved, this.EngineerVisitsRemoved, this.EngineerVisitsOrdersRemoved, trans);
            trans.Commit();
            int num6 = (int) App.ShowMessage("Job details updated for job number : " + oJob.JobNumber, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          if (oJob.JobTypeID == 1 && (this.Fleet != null && this.Fleet.Exists))
          {
            int jobId = oJob.JobID;
            App.DB.FleetVanService.Insert(oJob.JobID, this.Fleet.VanID);
          }
          App.CurrentCustomerID = this.Customer.CustomerID;
          IEnumerator enumerator5;
          try
          {
            enumerator5 = oJob.JobOfWorks.GetEnumerator();
            while (enumerator5.MoveNext())
            {
              JobOfWork current1 = (JobOfWork) enumerator5.Current;
              IEnumerator enumerator6;
              try
              {
                enumerator6 = current1.EngineerVisits.GetEnumerator();
                while (enumerator6.MoveNext())
                {
                  EngineerVisit current2 = (EngineerVisit) enumerator6.Current;
                  App.DB.EngineerVisitPartProductAllocated.SplitToOrder(current2.PartsAndProductsAllocated, current2.EngineerVisitID, oJob.JobID);
                }
              }
              finally
              {
                if (enumerator6 is IDisposable)
                  (enumerator6 as IDisposable).Dispose();
              }
            }
          }
          finally
          {
            if (enumerator5 is IDisposable)
              (enumerator5 as IDisposable).Dispose();
          }
          num2 = oJob.JobOfWorks.Count;
          if (num3 >= 3 & this.IsNewJobOfWork & oJob.JobTypeID == 4703)
          {
            List<string> stringList1 = (List<string>) null;
            int customerId = this.Customer.CustomerTypeID == 516 ? this.Customer.CustomerID : 787;
            List<CustomerAlert> forCustomer = App.DB.CustomerAlert.Get_ForCustomer(customerId);
            // ISSUE: explicit non-virtual call
            if (forCustomer != null && __nonvirtual (forCustomer.Count) > 0)
            {
              List<CustomerAlert> source = forCustomer;
              Func<CustomerAlert, bool> predicate;
              // ISSUE: reference to a compiler-generated field
              if (UCLogCallout._Closure\u0024__.\u0024I299\u002D0 != null)
              {
                // ISSUE: reference to a compiler-generated field
                predicate = UCLogCallout._Closure\u0024__.\u0024I299\u002D0;
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                UCLogCallout._Closure\u0024__.\u0024I299\u002D0 = predicate = (Func<CustomerAlert, bool>) (x => x.AlertTypeId == 71937);
              }
              stringList1 = ((IEnumerable<string>) source.Where<CustomerAlert>(predicate).FirstOrDefault<CustomerAlert>().EmailAddress.Split(';')).ToList<string>();
            }
            List<string> stringList2 = new List<string>();
            if (stringList1 != null)
            {
              try
              {
                foreach (string email in stringList1)
                {
                  if (Helper.IsEmailValid(email))
                    stringList2.Add(email);
                }
              }
              finally
              {
                List<string>.Enumerator enumerator6;
                enumerator6.Dispose();
              }
            }
            if (stringList2.Count > 0)
            {
              string jobNumber = oJob.JobNumber;
              int count = oJob.JobOfWorks.Count;
              string str2 = this.Site.Address1 + " " + this.Site.Address2 + ", " + this.Site.Postcode;
              string name = this.Customer.Name;
              string text = this.txtCurrentContract.Text;
              string fullname = App.loggedInUser.Fullname;
              string str3 = "Coming Soon";
              DateTime now = DateAndTime.Now;
              int num6 = now.Hour >= 3 ? 1 : 0;
              now = DateAndTime.Now;
              int num7 = now.Hour < 12 ? 1 : 0;
              string str4;
              if ((num6 & num7) != 0)
              {
                str4 = "Morning";
              }
              else
              {
                now = DateAndTime.Now;
                int num8 = now.Hour >= 12 ? 1 : 0;
                now = DateAndTime.Now;
                int num9 = now.Hour < 17 ? 1 : 0;
                str4 = (num8 & num9) == 0 ? "Evening" : "Afternoon";
              }
              string str5 = "Good " + str4;
              Emails emails = new Emails();
              emails.From = EmailAddress.Gabriel;
              try
              {
                foreach (string str6 in stringList2)
                  emails.ToList.Add(str6);
              }
              finally
              {
                List<string>.Enumerator enumerator6;
                enumerator6.Dispose();
              }
              emails.Subject = "3rd Job of Works Notification";
              emails.Body = "<span style='font-family: Calibri, Sans-Serif'><p>" + str5 + "</p><p>A new job of works has been created that exceeds the alerting threshold, details are below:-</p><p>Job Number - <b>" + jobNumber + "</b><br/> Priority - <b>" + str1 + "</b><br/>Customer - <b>" + name + "</b><br/>Site - <b>" + str2 + "</b><br/>Contract Type - <b>" + text + "</b><br/>JOW Count - <b>" + Conversions.ToString(count) + "</b><br/>User - <b>" + fullname + "</b><br/>Last Visit - <b>" + str3 + "</b><p>" + App.TheSystem.Configuration.CompanyName + "</p></span>";
              emails.SendMe = true;
              emails.Send();
              this.IsNewJobOfWork = false;
            }
          }
          this.JobId = oJob.JobID;
          this.Populate(0);
        }
        catch (ValidationException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          int num6 = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          trans?.Rollback();
          sqlConnection?.Close();
          flag1 = false;
          ProjectData.ClearProjectError();
          goto label_163;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num6 = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          trans?.Rollback();
          sqlConnection?.Close();
          flag1 = false;
          ProjectData.ClearProjectError();
          goto label_163;
        }
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(oJob.JobID);
        flag1 = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num3 = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        trans?.Rollback();
        sqlConnection?.Close();
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
label_163:
      return flag1;
    }

    private void CleanUpOrdersForPartProductsAllocated(
      ArrayList toRemove,
      ArrayList toReallocate,
      SqlTransaction trans)
    {
      if (toRemove != null)
      {
        int num = checked (toRemove.Count - 1);
        int index = 0;
        while (index <= num)
        {
          ArrayList arrayList = (ArrayList) toRemove[index];
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(arrayList[0], (object) "Part", false), (object) (Conversions.ToInteger(arrayList[4]) == 1))))
            App.DB.OrderPart.Delete(Conversions.ToInteger(arrayList[3]), trans);
          else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(arrayList[0], (object) "Product", false), (object) (Conversions.ToInteger(arrayList[4]) == 1))))
            App.DB.OrderProduct.Delete(Conversions.ToInteger(arrayList[3]), trans);
          else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(arrayList[0], (object) "Part", false), (object) (Conversions.ToInteger(arrayList[4]) != 1))))
          {
            FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart1 = new FSM.Entity.OrderLocationPart.OrderLocationPart();
            FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart2 = App.DB.OrderLocationPart.OrderLocationPart_Get(Conversions.ToInteger(arrayList[3]), trans);
            App.DB.OrderLocationPart.Delete(orderLocationPart2.OrderLocationPartID, trans);
            PartTransaction partTransaction = new PartTransaction();
            PartTransaction orderLocationPart3 = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(orderLocationPart2.OrderLocationPartID, trans);
            if (orderLocationPart3 != null)
              App.DB.PartTransaction.Delete(orderLocationPart3.PartTransactionID, trans);
          }
          else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(arrayList[0], (object) "Product", false), (object) (Conversions.ToInteger(arrayList[4]) != 1))))
          {
            FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct1 = new FSM.Entity.OrderLocationProduct.OrderLocationProduct();
            FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct2 = App.DB.OrderLocationProduct.OrderLocationProduct_Get(Conversions.ToInteger(arrayList[3]), trans);
            App.DB.OrderLocationProduct.Delete(orderLocationProduct2.OrderLocationProductID, trans);
            ProductTransaction productTransaction = new ProductTransaction();
            ProductTransaction orderLocationProduct3 = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(orderLocationProduct2.OrderLocationProductID, trans);
            if (orderLocationProduct3 != null)
              App.DB.ProductTransaction.Delete(orderLocationProduct3.ProductTransactionID, trans);
          }
          checked { ++index; }
        }
      }
      if (toReallocate == null)
        return;
      int num1 = 0;
      if (toReallocate.Count > 0)
        num1 = Conversions.ToInteger(App.FindRecord(Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans, 0, "", false));
      int num2 = checked (toReallocate.Count - 1);
      int index1 = 0;
      while (index1 <= num2)
      {
        ArrayList arrayList = (ArrayList) toReallocate[index1];
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(arrayList[0], (object) "Part", false))
          App.DB.PartTransaction.Insert(new PartTransaction()
          {
            SetAmount = RuntimeHelpers.GetObjectValue(arrayList[1]),
            SetLocationID = (object) num1,
            SetOrderLocationPartID = (object) 0,
            SetOrderPartID = (object) 0,
            SetPartID = RuntimeHelpers.GetObjectValue(arrayList[2]),
            SetTransactionTypeID = (object) 2,
            SetUserID = (object) App.loggedInUser.UserID,
            TransactionDate = DateAndTime.Now
          }, trans);
        else
          App.DB.ProductTransaction.Insert(new ProductTransaction()
          {
            SetAmount = RuntimeHelpers.GetObjectValue(arrayList[1]),
            SetLocationID = (object) num1,
            SetOrderLocationProductID = (object) 0,
            SetOrderProductID = (object) 0,
            SetProductID = RuntimeHelpers.GetObjectValue(arrayList[2]),
            SetTransactionTypeID = (object) 2,
            SetUserID = (object) App.loggedInUser.UserID,
            TransactionDate = DateAndTime.Now
          }, trans);
        checked { ++index1; }
      }
    }

    private void cboJobType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Site.CustomerID != 4401)
        return;
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboJobType)) == 1.0)
        this.btnfindVan.Enabled = true;
      else
        this.btnfindVan.Enabled = false;
    }

    private void btnfindVan_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblFleetVan, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Fleet = App.DB.FleetVan.Get(integer);
    }

    private void EmailServiceAlertDate()
    {
      if (this.Site == null || this.Site.NoService)
        return;
      List<string> stringList1 = (List<string>) null;
      int customerId = this.Customer.CustomerTypeID == 516 ? this.Customer.CustomerID : 787;
      List<CustomerAlert> forCustomer = App.DB.CustomerAlert.Get_ForCustomer(customerId);
      // ISSUE: explicit non-virtual call
      if (forCustomer != null && __nonvirtual (forCustomer.Count) > 0)
      {
        List<CustomerAlert> source = forCustomer;
        Func<CustomerAlert, bool> predicate;
        // ISSUE: reference to a compiler-generated field
        if (UCLogCallout._Closure\u0024__.\u0024I303\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          predicate = UCLogCallout._Closure\u0024__.\u0024I303\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          UCLogCallout._Closure\u0024__.\u0024I303\u002D0 = predicate = (Func<CustomerAlert, bool>) (x => x.AlertTypeId == 71938);
        }
        stringList1 = ((IEnumerable<string>) source.Where<CustomerAlert>(predicate).FirstOrDefault<CustomerAlert>().EmailAddress.Split(';')).ToList<string>();
      }
      List<string> stringList2 = new List<string>();
      if (stringList1 != null)
      {
        try
        {
          foreach (string email in stringList1)
          {
            if (Helper.IsEmailValid(email))
              stringList2.Add(email);
          }
        }
        finally
        {
          List<string>.Enumerator enumerator;
          enumerator.Dispose();
        }
      }
      if (stringList2.Count > 0)
      {
        DateTime dateTime1 = this.Site.LastServiceDate;
        dateTime1 = dateTime1.AddYears(1);
        DateTime t1_1 = dateTime1;
        DateTime dateTime2 = DateTime.MinValue;
        DateTime t2 = dateTime2.AddYears(1);
        int num1;
        if (DateTime.Compare(t1_1, t2) != 0)
        {
          DateTime t1_2 = dateTime1;
          dateTime2 = DateAndTime.Now;
          DateTime date = dateTime2.Date;
          num1 = DateTime.Compare(t1_2, date) <= 0 ? 1 : 0;
        }
        else
          num1 = 0;
        DateTime t1_3 = dateTime1.AddYears(1);
        dateTime2 = DateAndTime.Now;
        DateTime date1 = dateTime2.Date;
        int num2 = DateTime.Compare(t1_3, date1) >= 0 ? 1 : 0;
        if ((num1 & num2) != 0)
        {
          Emails emails = new Emails();
          try
          {
            foreach (string str in stringList2)
              emails.ToList.Add(str);
          }
          finally
          {
            List<string>.Enumerator enumerator;
            enumerator.Dispose();
          }
          emails.From = EmailAddress.FSM;
          emails.Subject = "Job Created on Site Due for Service!";
          string str1 = "<table border='1'>" + "<tr>" + "<td>Name</td><td>Address1</td><td>Address2</td><td>PostCode</td><td>Job Number</td>" + "</tr>" + "<tr>" + "<td>" + this.Site.Name + "</td><td>" + this.Site.Address1 + "</td><td>" + this.Site.Address2 + "</td><td>" + this.Site.Postcode + "</td><td>" + this.Job.JobNumber + "</td>" + "</tr>" + "</table>";
          emails.Body = str1;
          emails.SendMe = true;
          emails.Send();
        }
      }
    }

    private void btnFindUser_Click(object sender, EventArgs e)
    {
      if (this.SalesRep.Exists && !App.EnterOverridePassword())
        return;
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblUser, 0, "", false));
      if ((uint) integer > 0U)
        this.SalesRep = App.DB.User.Get(integer, false);
    }

    private void btnAddContactAttempt_Click(object sender, EventArgs e)
    {
      this.AddContactAttempt();
    }

    public void AddContactAttempt()
    {
      if (this.Job == null && this.Job.JobID <= 0)
        return;
      FRMContactAttempt frmContactAttempt = new FRMContactAttempt(Enums.TableNames.tblJob, this.Job.JobID);
      int num = (int) frmContactAttempt.ShowDialog();
      if (frmContactAttempt.DialogResult == DialogResult.OK)
      {
        this.Populate(this.Job.JobID);
        this.OnForm.PopulateContactAttempts();
      }
    }
  }
}
