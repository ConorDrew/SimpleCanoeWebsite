// Decompiled with JetBrains decompiler
// Type: FSM.FRMVisitManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMVisitManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private int count;
    private DataView _dvVisits;
    private FSM.Entity.Customers.Customer _theCustomer;
    private FSM.Entity.Sites.Site _oSite;
    private Engineer _theEngineer;
    private DataTable _dtVisit;

    public FRMVisitManager()
    {
      this.Load += new EventHandler(this.FRMVisitManager_Load);
      this.count = 0;
      this._dtVisit = new DataTable();
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPONumber
    {
      get
      {
        return this._txtPONumber;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtJobNumber_TextChanged);
        TextBox txtPoNumber1 = this._txtPONumber;
        if (txtPoNumber1 != null)
          txtPoNumber1.KeyDown -= keyEventHandler;
        this._txtPONumber = value;
        TextBox txtPoNumber2 = this._txtPONumber;
        if (txtPoNumber2 == null)
          return;
        txtPoNumber2.KeyDown += keyEventHandler;
      }
    }

    internal virtual TextBox txtJobNumber
    {
      get
      {
        return this._txtJobNumber;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtJobNumber_TextChanged);
        TextBox txtJobNumber1 = this._txtJobNumber;
        if (txtJobNumber1 != null)
          txtJobNumber1.KeyDown -= keyEventHandler;
        this._txtJobNumber = value;
        TextBox txtJobNumber2 = this._txtJobNumber;
        if (txtJobNumber2 == null)
          return;
        txtJobNumber2.KeyDown += keyEventHandler;
      }
    }

    internal virtual ComboBox cboStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDefinition { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual CheckBox chkVisitDate
    {
      get
      {
        return this._chkVisitDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkVisitDate_CheckedChanged);
        CheckBox chkVisitDate1 = this._chkVisitDate;
        if (chkVisitDate1 != null)
          chkVisitDate1.CheckedChanged -= eventHandler;
        this._chkVisitDate = value;
        CheckBox chkVisitDate2 = this._chkVisitDate;
        if (chkVisitDate2 == null)
          return;
        chkVisitDate2.CheckedChanged += eventHandler;
      }
    }

    internal virtual GroupBox grpEngineerVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgVisits
    {
      get
      {
        return this._dgVisits;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgVisits_DoubleClick);
        DataGrid dgVisits1 = this._dgVisits;
        if (dgVisits1 != null)
          dgVisits1.DoubleClick -= eventHandler;
        this._dgVisits = value;
        DataGrid dgVisits2 = this._dgVisits;
        if (dgVisits2 == null)
          return;
        dgVisits2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnRequiringParts
    {
      get
      {
        return this._btnRequiringParts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRequiringParts_Click);
        Button btnRequiringParts1 = this._btnRequiringParts;
        if (btnRequiringParts1 != null)
          btnRequiringParts1.Click -= eventHandler;
        this._btnRequiringParts = value;
        Button btnRequiringParts2 = this._btnRequiringParts;
        if (btnRequiringParts2 == null)
          return;
        btnRequiringParts2.Click += eventHandler;
      }
    }

    internal virtual Button btnCreateOrder
    {
      get
      {
        return this._btnCreateOrder;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCreateOrder_Click);
        Button btnCreateOrder1 = this._btnCreateOrder;
        if (btnCreateOrder1 != null)
          btnCreateOrder1.Click -= eventHandler;
        this._btnCreateOrder = value;
        Button btnCreateOrder2 = this._btnCreateOrder;
        if (btnCreateOrder2 == null)
          return;
        btnCreateOrder2.Click += eventHandler;
      }
    }

    internal virtual Button btnFindSite
    {
      get
      {
        return this._btnFindSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSite_Click);
        Button btnFindSite1 = this._btnFindSite;
        if (btnFindSite1 != null)
          btnFindSite1.Click -= eventHandler;
        this._btnFindSite = value;
        Button btnFindSite2 = this._btnFindSite;
        if (btnFindSite2 == null)
          return;
        btnFindSite2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode
    {
      get
      {
        return this._txtPostcode;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPostcode_TextChanged);
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtJobNumber_TextChanged);
        TextBox txtPostcode1 = this._txtPostcode;
        if (txtPostcode1 != null)
        {
          txtPostcode1.TextChanged -= eventHandler;
          txtPostcode1.KeyDown -= keyEventHandler;
        }
        this._txtPostcode = value;
        TextBox txtPostcode2 = this._txtPostcode;
        if (txtPostcode2 == null)
          return;
        txtPostcode2.TextChanged += eventHandler;
        txtPostcode2.KeyDown += keyEventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnfindEngineer
    {
      get
      {
        return this._btnfindEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnfindEngineer_Click);
        Button btnfindEngineer1 = this._btnfindEngineer;
        if (btnfindEngineer1 != null)
          btnfindEngineer1.Click -= eventHandler;
        this._btnfindEngineer = value;
        Button btnfindEngineer2 = this._btnfindEngineer;
        if (btnfindEngineer2 == null)
          return;
        btnfindEngineer2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboOutcome
    {
      get
      {
        return this._cboOutcome;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.cboOutcome_TextChanged);
        EventHandler eventHandler2 = new EventHandler(this.cboOutcome_SelectedIndexChanged_1);
        ComboBox cboOutcome1 = this._cboOutcome;
        if (cboOutcome1 != null)
        {
          cboOutcome1.TextChanged -= eventHandler1;
          cboOutcome1.SelectedIndexChanged -= eventHandler2;
        }
        this._cboOutcome = value;
        ComboBox cboOutcome2 = this._cboOutcome;
        if (cboOutcome2 == null)
          return;
        cboOutcome2.TextChanged += eventHandler1;
        cboOutcome2.SelectedIndexChanged += eventHandler2;
      }
    }

    internal virtual Button btnSearch
    {
      get
      {
        return this._btnSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSearch_Click);
        Button btnSearch1 = this._btnSearch;
        if (btnSearch1 != null)
          btnSearch1.Click -= eventHandler;
        this._btnSearch = value;
        Button btnSearch2 = this._btnSearch;
        if (btnSearch2 == null)
          return;
        btnSearch2.Click += eventHandler;
      }
    }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox CboServExp { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkftfcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLetterNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPriority { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpToServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFromServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpVisitEndTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpVisitEndFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitEndTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitEndFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkVisitEnd
    {
      get
      {
        return this._chkVisitEnd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkVisitEnd_CheckedChanged);
        CheckBox chkVisitEnd1 = this._chkVisitEnd;
        if (chkVisitEnd1 != null)
          chkVisitEnd1.CheckedChanged -= eventHandler;
        this._chkVisitEnd = value;
        CheckBox chkVisitEnd2 = this._chkVisitEnd;
        if (chkVisitEnd2 == null)
          return;
        chkVisitEnd2.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkRecharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVisitCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNonChargeable { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblGreenColour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitChargeable { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblYellowColour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQualification { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboQualification { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpEngineerVisits = new GroupBox();
      this.dgVisits = new DataGrid();
      this.btnExport = new Button();
      this.grpFilter = new GroupBox();
      this.lblQualification = new Label();
      this.cboQualification = new ComboBox();
      this.lblNonChargeable = new Label();
      this.lblGreenColour = new Label();
      this.lblVisitChargeable = new Label();
      this.lblYellowColour = new Label();
      this.lblVisitCharge = new Label();
      this.cboVisitCharge = new ComboBox();
      this.chkRecharge = new CheckBox();
      this.dtpVisitEndTo = new DateTimePicker();
      this.dtpVisitEndFrom = new DateTimePicker();
      this.lblVisitEndTo = new Label();
      this.lblVisitEndFrom = new Label();
      this.chkVisitEnd = new CheckBox();
      this.dtpToServiceDate = new DateTimePicker();
      this.dtpFromServiceDate = new DateTimePicker();
      this.Label18 = new Label();
      this.Label19 = new Label();
      this.chkServiceDate = new CheckBox();
      this.Label17 = new Label();
      this.cboPriority = new ComboBox();
      this.Label16 = new Label();
      this.cboLetterNumber = new ComboBox();
      this.chkftfcode = new CheckBox();
      this.Label15 = new Label();
      this.cboDepartment = new ComboBox();
      this.Label14 = new Label();
      this.CboServExp = new ComboBox();
      this.Label13 = new Label();
      this.cboRegion = new ComboBox();
      this.btnSearch = new Button();
      this.Label12 = new Label();
      this.cboOutcome = new ComboBox();
      this.btnfindEngineer = new Button();
      this.txtEngineer = new TextBox();
      this.Label5 = new Label();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.Label4 = new Label();
      this.txtPostcode = new TextBox();
      this.Label1 = new Label();
      this.btnFindSite = new Button();
      this.txtSite = new TextBox();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.txtPONumber = new TextBox();
      this.txtJobNumber = new TextBox();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.chkVisitDate = new CheckBox();
      this.Label7 = new Label();
      this.Label6 = new Label();
      this.Label2 = new Label();
      this.Label10 = new Label();
      this.cboType = new ComboBox();
      this.Label11 = new Label();
      this.cboStatus = new ComboBox();
      this.Label3 = new Label();
      this.cboDefinition = new ComboBox();
      this.btnReset = new Button();
      this.btnRequiringParts = new Button();
      this.btnCreateOrder = new Button();
      this.grpEngineerVisits.SuspendLayout();
      this.dgVisits.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineerVisits.Controls.Add((Control) this.dgVisits);
      this.grpEngineerVisits.Location = new System.Drawing.Point(8, 303);
      this.grpEngineerVisits.Name = "grpEngineerVisits";
      this.grpEngineerVisits.Size = new Size(1438, 222);
      this.grpEngineerVisits.TabIndex = 2;
      this.grpEngineerVisits.TabStop = false;
      this.dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgVisits.DataMember = "";
      this.dgVisits.HeaderForeColor = SystemColors.ControlText;
      this.dgVisits.Location = new System.Drawing.Point(8, 20);
      this.dgVisits.Name = "dgVisits";
      this.dgVisits.Size = new Size(1422, 194);
      this.dgVisits.TabIndex = 14;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 531);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 15;
      this.btnExport.Text = "Export";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.lblQualification);
      this.grpFilter.Controls.Add((Control) this.cboQualification);
      this.grpFilter.Controls.Add((Control) this.lblNonChargeable);
      this.grpFilter.Controls.Add((Control) this.lblGreenColour);
      this.grpFilter.Controls.Add((Control) this.lblVisitChargeable);
      this.grpFilter.Controls.Add((Control) this.lblYellowColour);
      this.grpFilter.Controls.Add((Control) this.lblVisitCharge);
      this.grpFilter.Controls.Add((Control) this.cboVisitCharge);
      this.grpFilter.Controls.Add((Control) this.chkRecharge);
      this.grpFilter.Controls.Add((Control) this.dtpVisitEndTo);
      this.grpFilter.Controls.Add((Control) this.dtpVisitEndFrom);
      this.grpFilter.Controls.Add((Control) this.lblVisitEndTo);
      this.grpFilter.Controls.Add((Control) this.lblVisitEndFrom);
      this.grpFilter.Controls.Add((Control) this.chkVisitEnd);
      this.grpFilter.Controls.Add((Control) this.dtpToServiceDate);
      this.grpFilter.Controls.Add((Control) this.dtpFromServiceDate);
      this.grpFilter.Controls.Add((Control) this.Label18);
      this.grpFilter.Controls.Add((Control) this.Label19);
      this.grpFilter.Controls.Add((Control) this.chkServiceDate);
      this.grpFilter.Controls.Add((Control) this.Label17);
      this.grpFilter.Controls.Add((Control) this.cboPriority);
      this.grpFilter.Controls.Add((Control) this.Label16);
      this.grpFilter.Controls.Add((Control) this.cboLetterNumber);
      this.grpFilter.Controls.Add((Control) this.chkftfcode);
      this.grpFilter.Controls.Add((Control) this.Label15);
      this.grpFilter.Controls.Add((Control) this.cboDepartment);
      this.grpFilter.Controls.Add((Control) this.Label14);
      this.grpFilter.Controls.Add((Control) this.CboServExp);
      this.grpFilter.Controls.Add((Control) this.Label13);
      this.grpFilter.Controls.Add((Control) this.cboRegion);
      this.grpFilter.Controls.Add((Control) this.btnSearch);
      this.grpFilter.Controls.Add((Control) this.Label12);
      this.grpFilter.Controls.Add((Control) this.cboOutcome);
      this.grpFilter.Controls.Add((Control) this.btnfindEngineer);
      this.grpFilter.Controls.Add((Control) this.txtEngineer);
      this.grpFilter.Controls.Add((Control) this.Label5);
      this.grpFilter.Controls.Add((Control) this.btnFindCustomer);
      this.grpFilter.Controls.Add((Control) this.txtCustomer);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.txtPostcode);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.btnFindSite);
      this.grpFilter.Controls.Add((Control) this.txtSite);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.txtPONumber);
      this.grpFilter.Controls.Add((Control) this.txtJobNumber);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Controls.Add((Control) this.chkVisitDate);
      this.grpFilter.Controls.Add((Control) this.Label7);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.Label10);
      this.grpFilter.Controls.Add((Control) this.cboType);
      this.grpFilter.Controls.Add((Control) this.Label11);
      this.grpFilter.Controls.Add((Control) this.cboStatus);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(1438, 271);
      this.grpFilter.TabIndex = 1;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.lblQualification.BackColor = Color.Transparent;
      this.lblQualification.Location = new System.Drawing.Point(662, 150);
      this.lblQualification.Name = "lblQualification";
      this.lblQualification.Size = new Size(90, 16);
      this.lblQualification.TabIndex = 63;
      this.lblQualification.Text = "Qualification";
      this.cboQualification.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboQualification.Location = new System.Drawing.Point(776, 147);
      this.cboQualification.Name = "cboQualification";
      this.cboQualification.Size = new Size(266, 21);
      this.cboQualification.TabIndex = 62;
      this.lblNonChargeable.Location = new System.Drawing.Point(876, 244);
      this.lblNonChargeable.Name = "lblNonChargeable";
      this.lblNonChargeable.Size = new Size(139, 16);
      this.lblNonChargeable.TabIndex = 61;
      this.lblNonChargeable.Text = "Non-Chargeable Visit";
      this.lblGreenColour.BackColor = Color.LightGreen;
      this.lblGreenColour.Location = new System.Drawing.Point(850, 240);
      this.lblGreenColour.Name = "lblGreenColour";
      this.lblGreenColour.Size = new Size(20, 20);
      this.lblGreenColour.TabIndex = 60;
      this.lblVisitChargeable.Location = new System.Drawing.Point(738, 244);
      this.lblVisitChargeable.Name = "lblVisitChargeable";
      this.lblVisitChargeable.Size = new Size(109, 17);
      this.lblVisitChargeable.TabIndex = 59;
      this.lblVisitChargeable.Text = "Chargeable Visit";
      this.lblYellowColour.BackColor = Color.Yellow;
      this.lblYellowColour.Location = new System.Drawing.Point(712, 240);
      this.lblYellowColour.Name = "lblYellowColour";
      this.lblYellowColour.Size = new Size(20, 20);
      this.lblYellowColour.TabIndex = 58;
      this.lblVisitCharge.Location = new System.Drawing.Point(662, 117);
      this.lblVisitCharge.Name = "lblVisitCharge";
      this.lblVisitCharge.Size = new Size(108, 20);
      this.lblVisitCharge.TabIndex = 57;
      this.lblVisitCharge.Text = "Visit Chargeable?";
      this.cboVisitCharge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboVisitCharge.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVisitCharge.Location = new System.Drawing.Point(776, 113);
      this.cboVisitCharge.MinimumSize = new Size(70, 0);
      this.cboVisitCharge.Name = "cboVisitCharge";
      this.cboVisitCharge.Size = new Size(297, 21);
      this.cboVisitCharge.TabIndex = 56;
      this.chkRecharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkRecharge.Cursor = Cursors.Hand;
      this.chkRecharge.Location = new System.Drawing.Point(1106, 209);
      this.chkRecharge.Name = "chkRecharge";
      this.chkRecharge.Size = new Size(95, 24);
      this.chkRecharge.TabIndex = 55;
      this.chkRecharge.Text = "Recharge";
      this.chkRecharge.UseVisualStyleBackColor = true;
      this.dtpVisitEndTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpVisitEndTo.Enabled = false;
      this.dtpVisitEndTo.Location = new System.Drawing.Point(1274, 118);
      this.dtpVisitEndTo.Name = "dtpVisitEndTo";
      this.dtpVisitEndTo.Size = new Size(156, 21);
      this.dtpVisitEndTo.TabIndex = 54;
      this.dtpVisitEndFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpVisitEndFrom.Enabled = false;
      this.dtpVisitEndFrom.Location = new System.Drawing.Point(1274, 91);
      this.dtpVisitEndFrom.Name = "dtpVisitEndFrom";
      this.dtpVisitEndFrom.Size = new Size(156, 21);
      this.dtpVisitEndFrom.TabIndex = 53;
      this.lblVisitEndTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblVisitEndTo.Location = new System.Drawing.Point(1220, 121);
      this.lblVisitEndTo.Name = "lblVisitEndTo";
      this.lblVisitEndTo.Size = new Size(48, 16);
      this.lblVisitEndTo.TabIndex = 51;
      this.lblVisitEndTo.Text = "To";
      this.lblVisitEndFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblVisitEndFrom.Location = new System.Drawing.Point(1220, 93);
      this.lblVisitEndFrom.Name = "lblVisitEndFrom";
      this.lblVisitEndFrom.Size = new Size(48, 16);
      this.lblVisitEndFrom.TabIndex = 50;
      this.lblVisitEndFrom.Text = "From";
      this.chkVisitEnd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkVisitEnd.Cursor = Cursors.Hand;
      this.chkVisitEnd.FlatStyle = FlatStyle.System;
      this.chkVisitEnd.Location = new System.Drawing.Point(1106, 84);
      this.chkVisitEnd.Name = "chkVisitEnd";
      this.chkVisitEnd.Size = new Size(115, 24);
      this.chkVisitEnd.TabIndex = 52;
      this.chkVisitEnd.Text = "Visit End Date";
      this.dtpToServiceDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpToServiceDate.Location = new System.Drawing.Point(1274, 184);
      this.dtpToServiceDate.Name = "dtpToServiceDate";
      this.dtpToServiceDate.Size = new Size(158, 21);
      this.dtpToServiceDate.TabIndex = 49;
      this.dtpFromServiceDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFromServiceDate.Location = new System.Drawing.Point(1274, 153);
      this.dtpFromServiceDate.Name = "dtpFromServiceDate";
      this.dtpFromServiceDate.Size = new Size(158, 21);
      this.dtpFromServiceDate.TabIndex = 48;
      this.Label18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label18.Location = new System.Drawing.Point(1220, 187);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(48, 16);
      this.Label18.TabIndex = 46;
      this.Label18.Text = "To";
      this.Label19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label19.Location = new System.Drawing.Point(1220, 155);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(48, 16);
      this.Label19.TabIndex = 45;
      this.Label19.Text = "From";
      this.chkServiceDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkServiceDate.Cursor = Cursors.Hand;
      this.chkServiceDate.Location = new System.Drawing.Point(1106, 150);
      this.chkServiceDate.Name = "chkServiceDate";
      this.chkServiceDate.Size = new Size(95, 24);
      this.chkServiceDate.TabIndex = 47;
      this.chkServiceDate.Text = "Service Date";
      this.chkServiceDate.UseVisualStyleBackColor = true;
      this.Label17.BackColor = Color.Transparent;
      this.Label17.Location = new System.Drawing.Point(6, 248);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(94, 15);
      this.Label17.TabIndex = 44;
      this.Label17.Text = "Priority";
      this.cboPriority.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPriority.Location = new System.Drawing.Point(104, 243);
      this.cboPriority.Name = "cboPriority";
      this.cboPriority.Size = new Size(184, 21);
      this.cboPriority.TabIndex = 43;
      this.Label16.BackColor = Color.Transparent;
      this.Label16.Location = new System.Drawing.Point(295, 244);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(90, 16);
      this.Label16.TabIndex = 42;
      this.Label16.Text = "Letter Number";
      this.cboLetterNumber.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLetterNumber.Location = new System.Drawing.Point(390, 240);
      this.cboLetterNumber.Name = "cboLetterNumber";
      this.cboLetterNumber.Size = new Size(266, 21);
      this.cboLetterNumber.TabIndex = 41;
      this.chkftfcode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkftfcode.Cursor = Cursors.Hand;
      this.chkftfcode.Location = new System.Drawing.Point(1335, 213);
      this.chkftfcode.Name = "chkftfcode";
      this.chkftfcode.Size = new Size(95, 17);
      this.chkftfcode.TabIndex = 40;
      this.chkftfcode.Text = "No FTF code";
      this.chkftfcode.UseVisualStyleBackColor = true;
      this.chkftfcode.Visible = false;
      this.Label15.Location = new System.Drawing.Point(296, 120);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(81, 20);
      this.Label15.TabIndex = 39;
      this.Label15.Text = "Cost Centre";
      this.cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDepartment.Location = new System.Drawing.Point(390, 116);
      this.cboDepartment.Name = "cboDepartment";
      this.cboDepartment.Size = new Size(266, 21);
      this.cboDepartment.TabIndex = 38;
      this.Label14.BackColor = Color.Transparent;
      this.Label14.Location = new System.Drawing.Point(6, 220);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(96, 13);
      this.Label14.TabIndex = 37;
      this.Label14.Text = "Serv Expires in";
      this.CboServExp.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CboServExp.Location = new System.Drawing.Point(104, 214);
      this.CboServExp.Name = "CboServExp";
      this.CboServExp.Size = new Size(184, 21);
      this.CboServExp.TabIndex = 36;
      this.Label13.Location = new System.Drawing.Point(6, 153);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(72, 16);
      this.Label13.TabIndex = 35;
      this.Label13.Text = "Region";
      this.cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegion.Location = new System.Drawing.Point(104, 149);
      this.cboRegion.Name = "cboRegion";
      this.cboRegion.Size = new Size(184, 21);
      this.cboRegion.TabIndex = 34;
      this.btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSearch.Location = new System.Drawing.Point(1360, 242);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(70, 23);
      this.btnSearch.TabIndex = 33;
      this.btnSearch.Text = "Run Filter";
      this.Label12.Location = new System.Drawing.Point(296, 181);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(62, 22);
      this.Label12.TabIndex = 31;
      this.Label12.Text = "Outcome";
      this.cboOutcome.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboOutcome.Location = new System.Drawing.Point(390, 178);
      this.cboOutcome.Name = "cboOutcome";
      this.cboOutcome.Size = new Size(266, 21);
      this.cboOutcome.TabIndex = 32;
      this.btnfindEngineer.BackColor = Color.White;
      this.btnfindEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindEngineer.Location = new System.Drawing.Point(624, 85);
      this.btnfindEngineer.Name = "btnfindEngineer";
      this.btnfindEngineer.Size = new Size(32, 23);
      this.btnfindEngineer.TabIndex = 29;
      this.btnfindEngineer.Text = "...";
      this.btnfindEngineer.UseVisualStyleBackColor = false;
      this.txtEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEngineer.Location = new System.Drawing.Point(390, 86);
      this.txtEngineer.Name = "txtEngineer";
      this.txtEngineer.ReadOnly = true;
      this.txtEngineer.Size = new Size(228, 21);
      this.txtEngineer.TabIndex = 28;
      this.Label5.Location = new System.Drawing.Point(296, 88);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(70, 16);
      this.Label5.TabIndex = 30;
      this.Label5.Text = "Engineer";
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(1043, 26);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 2;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(104, 25);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(933, 21);
      this.txtCustomer.TabIndex = 1;
      this.Label4.Location = new System.Drawing.Point(8, 24);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 16);
      this.Label4.TabIndex = 27;
      this.Label4.Text = "Customer";
      this.txtPostcode.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPostcode.Location = new System.Drawing.Point(104, 85);
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(184, 21);
      this.txtPostcode.TabIndex = 5;
      this.Label1.Location = new System.Drawing.Point(8, 88);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 16);
      this.Label1.TabIndex = 20;
      this.Label1.Text = "Postcode";
      this.btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSite.BackColor = Color.White;
      this.btnFindSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSite.Location = new System.Drawing.Point(1043, 53);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(32, 23);
      this.btnFindSite.TabIndex = 4;
      this.btnFindSite.Text = "...";
      this.btnFindSite.UseVisualStyleBackColor = false;
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSite.Location = new System.Drawing.Point(104, 55);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(933, 21);
      this.txtSite.TabIndex = 3;
      this.dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpTo.Location = new System.Drawing.Point(1274, 56);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(156, 21);
      this.dtpTo.TabIndex = 13;
      this.dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFrom.Location = new System.Drawing.Point(1274, 29);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(156, 21);
      this.dtpFrom.TabIndex = 12;
      this.txtPONumber.Location = new System.Drawing.Point(104, 182);
      this.txtPONumber.Name = "txtPONumber";
      this.txtPONumber.Size = new Size(184, 21);
      this.txtPONumber.TabIndex = 10;
      this.txtJobNumber.Location = new System.Drawing.Point(390, 210);
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.Size = new Size(266, 21);
      this.txtJobNumber.TabIndex = 9;
      this.Label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label9.Location = new System.Drawing.Point(1220, 59);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(48, 16);
      this.Label9.TabIndex = 10;
      this.Label9.Text = "To";
      this.Label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label8.Location = new System.Drawing.Point(1220, 31);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(48, 16);
      this.Label8.TabIndex = 9;
      this.Label8.Text = "From";
      this.chkVisitDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkVisitDate.Checked = true;
      this.chkVisitDate.CheckState = CheckState.Checked;
      this.chkVisitDate.Cursor = Cursors.Hand;
      this.chkVisitDate.FlatStyle = FlatStyle.System;
      this.chkVisitDate.Location = new System.Drawing.Point(1106, 26);
      this.chkVisitDate.Name = "chkVisitDate";
      this.chkVisitDate.Size = new Size(80, 24);
      this.chkVisitDate.TabIndex = 11;
      this.chkVisitDate.Text = "Visit Date";
      this.Label7.Location = new System.Drawing.Point(8, 187);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(88, 16);
      this.Label7.TabIndex = 7;
      this.Label7.Text = "PO Number";
      this.Label6.Location = new System.Drawing.Point(297, 216);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(80, 16);
      this.Label6.TabIndex = 6;
      this.Label6.Text = "Job Number";
      this.Label2.Location = new System.Drawing.Point(8, 56);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(64, 16);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Property";
      this.Label10.Location = new System.Drawing.Point(296, 150);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(70, 22);
      this.Label10.TabIndex = 4;
      this.Label10.Text = "Job Type";
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(390, 147);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(266, 21);
      this.cboType.TabIndex = 7;
      this.Label11.Location = new System.Drawing.Point(6, 123);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(48, 22);
      this.Label11.TabIndex = 5;
      this.Label11.Text = "Status";
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Location = new System.Drawing.Point(104, 117);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(184, 21);
      this.cboStatus.TabIndex = 8;
      this.Label3.Location = new System.Drawing.Point(8, 116);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(72, 16);
      this.Label3.TabIndex = 3;
      this.Label3.Text = "Definition";
      this.cboDefinition.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDefinition.Location = new System.Drawing.Point(104, 116);
      this.cboDefinition.Name = "cboDefinition";
      this.cboDefinition.Size = new Size(184, 21);
      this.cboDefinition.TabIndex = 6;
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(72, 531);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 16;
      this.btnReset.Text = "Reset";
      this.btnRequiringParts.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRequiringParts.Location = new System.Drawing.Point(136, 531);
      this.btnRequiringParts.Name = "btnRequiringParts";
      this.btnRequiringParts.Size = new Size(144, 23);
      this.btnRequiringParts.TabIndex = 17;
      this.btnRequiringParts.Text = "Visits Requiring Parts";
      this.btnCreateOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCreateOrder.Location = new System.Drawing.Point(288, 531);
      this.btnCreateOrder.Name = "btnCreateOrder";
      this.btnCreateOrder.Size = new Size(112, 23);
      this.btnCreateOrder.TabIndex = 18;
      this.btnCreateOrder.Text = "Create Order";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1454, 561);
      this.Controls.Add((Control) this.btnCreateOrder);
      this.Controls.Add((Control) this.btnRequiringParts);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpEngineerVisits);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(808, 528);
      this.Name = nameof (FRMVisitManager);
      this.Text = "Visit Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpEngineerVisits, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.btnRequiringParts, 0);
      this.Controls.SetChildIndex((Control) this.btnCreateOrder, 0);
      this.grpEngineerVisits.ResumeLayout(false);
      this.dgVisits.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupVisitDataGrid();
      ComboBox cboOutcome = this.cboOutcome;
      Combo.SetUpCombo(ref cboOutcome, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboOutcome = cboOutcome;
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboType = cboType;
      if (App.loggedInUser.UserRegions.Count > 0)
      {
        ComboBox cboRegion = this.cboRegion;
        Combo.SetUpCombo(ref cboRegion, App.loggedInUser.UserRegions.Table, "RegionID", "Name", Enums.ComboValues.No_Filter);
        this.cboRegion = cboRegion;
      }
      else
      {
        ComboBox cboRegion = this.cboRegion;
        Combo.SetUpCombo(ref cboRegion, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
        this.cboRegion = cboRegion;
      }
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboStatus = cboStatus;
      ComboBox cboServExp = this.CboServExp;
      Combo.SetUpCombo(ref cboServExp, DynamicDataTables.ServExpiry, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.CboServExp = cboServExp;
      ComboBox cboLetterNumber = this.cboLetterNumber;
      Combo.SetUpCombo(ref cboLetterNumber, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboLetterNumber = cboLetterNumber;
      ComboBox cboPriority = this.cboPriority;
      Combo.SetUpCombo(ref cboPriority, App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboPriority = cboPriority;
      ComboBox cboVisitCharge = this.cboVisitCharge;
      Combo.SetUpCombo(ref cboVisitCharge, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboVisitCharge = cboVisitCharge;
      ComboBox cboQualification = this.cboQualification;
      Combo.SetUpCombo(ref cboQualification, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboQualification = cboQualification;
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
      if (true == App.IsRFT)
      {
        this.lblQualification.Text = "Trade";
      }
      else
      {
        this.lblQualification.Text = "Qualification";
        this.lblQualification.Visible = false;
        this.cboQualification.Visible = false;
      }
      if (!App.loggedInUser.Admin)
        this.btnExport.Enabled = false;
      if (!(this.get_GetParameter(1) != null & this.get_GetParameter(2) != null))
        return;
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.get_GetParameter(2), (object) "From Invoice Manager", false))
      {
        this.dtVisitFilters = (DataTable) this.get_GetParameter(1);
        this.LoadLastFilters();
      }
      else
        this.PopulateDatagrid(false);
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

    private DataView VisitsDataview
    {
      get
      {
        return this._dvVisits;
      }
      set
      {
        this._dvVisits = value;
        if (this.VisitsDataview != null)
        {
          this._dvVisits.AllowNew = false;
          this._dvVisits.AllowEdit = false;
          this._dvVisits.AllowDelete = false;
          this._dvVisits.Table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
        }
        this.dgVisits.DataSource = (object) this.VisitsDataview;
        if (this.VisitsDataview == null || this.VisitsDataview.Table.Rows.Count <= 0)
          return;
        this.dgVisits.Select(0);
      }
    }

    private DataRow SelectedVisitDataRow
    {
      get
      {
        return this.VisitsDataview == null || this.dgVisits.CurrentRowIndex == -1 ? (DataRow) null : this.VisitsDataview[this.dgVisits.CurrentRowIndex].Row;
      }
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
        this.theSite = (FSM.Entity.Sites.Site) null;
        if (this._theCustomer != null)
          this.txtCustomer.Text = this.theCustomer.Name + " (A/C No : " + this.theCustomer.AccountNumber + ")";
        else
          this.txtCustomer.Text = "";
      }
    }

    public FSM.Entity.Sites.Site theSite
    {
      get
      {
        return this._oSite;
      }
      set
      {
        this._oSite = value;
        if (this._oSite != null)
          this.txtSite.Text = this.theSite.Address1 + ", " + this.theSite.Address2 + ", " + this.theSite.Postcode;
        else
          this.txtSite.Text = "";
      }
    }

    public Engineer theEngineer
    {
      get
      {
        return this._theEngineer;
      }
      set
      {
        this._theEngineer = value;
        if (this._theEngineer != null)
          this.txtEngineer.Text = this.theEngineer.Name;
        else
          this.txtEngineer.Text = "";
      }
    }

    public DataTable dtVisitFilters
    {
      get
      {
        if (this._dtVisit.Columns.Count == 0)
        {
          this._dtVisit.Columns.Add("Field");
          this._dtVisit.Columns.Add("Value");
          this._dtVisit.Columns.Add("Type");
        }
        return this._dtVisit;
      }
      set
      {
        this._dtVisit = value;
      }
    }

    private void SetupVisitDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgVisits.TableStyles[0];
      DataGridVisitManagerColumn visitManagerColumn = new DataGridVisitManagerColumn();
      visitManagerColumn.Format = "";
      visitManagerColumn.FormatInfo = (IFormatProvider) null;
      visitManagerColumn.HeaderText = "";
      visitManagerColumn.MappingName = "VisitChargeable";
      visitManagerColumn.ReadOnly = true;
      visitManagerColumn.Width = 30;
      visitManagerColumn.NullText = "";
      visitManagerColumn.TextBox.Text = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) visitManagerColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Customer";
      dataGridLabelColumn1.MappingName = "Customer";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 120;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Property";
      dataGridLabelColumn2.MappingName = "Site";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 200;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Job Number";
      dataGridLabelColumn3.MappingName = "JobNumber";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 65;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Type";
      dataGridLabelColumn4.MappingName = "Type";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      BitToStringDescriptionColumn descriptionColumn = new BitToStringDescriptionColumn();
      descriptionColumn.Format = "";
      descriptionColumn.FormatInfo = (IFormatProvider) null;
      descriptionColumn.HeaderText = "Parts To Fit";
      descriptionColumn.MappingName = "PartsToFit";
      descriptionColumn.ReadOnly = true;
      descriptionColumn.Width = 25;
      descriptionColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) descriptionColumn);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Status";
      dataGridLabelColumn5.MappingName = "VisitStatus";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Outcome";
      dataGridLabelColumn6.MappingName = "VisitOutcome";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "dd/MMM/yyyy";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Visit Date";
      dataGridLabelColumn7.MappingName = "VisitDate";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 170;
      dataGridLabelColumn7.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      if (true == App.IsRFT)
      {
        DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
        dataGridLabelColumn8.Format = "";
        dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn8.HeaderText = "Trade";
        dataGridLabelColumn8.MappingName = "Qualification";
        dataGridLabelColumn8.ReadOnly = true;
        dataGridLabelColumn8.Width = 85;
        dataGridLabelColumn8.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      }
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Notes to Engineer";
      dataGridLabelColumn9.MappingName = "NotesToEngineer";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 250;
      dataGridLabelColumn9.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Engineer";
      dataGridLabelColumn10.MappingName = "Engineer";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 90;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Invoice Notes";
      dataGridLabelColumn11.MappingName = "InvoiceNotes";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 200;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "dd/MMM/yyyy";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "Service Expiry Date";
      dataGridLabelColumn12.MappingName = "ServiceExpiryDate";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 80;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "Site Fuel";
      dataGridLabelColumn13.MappingName = "SiteFuel";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 75;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      DataGridLabelColumn dataGridLabelColumn14 = new DataGridLabelColumn();
      dataGridLabelColumn14.Format = "";
      dataGridLabelColumn14.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn14.HeaderText = "PO Number";
      dataGridLabelColumn14.MappingName = "PONumber";
      dataGridLabelColumn14.ReadOnly = true;
      dataGridLabelColumn14.Width = 55;
      dataGridLabelColumn14.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn14);
      DataGridLabelColumn dataGridLabelColumn15 = new DataGridLabelColumn();
      dataGridLabelColumn15.Format = "dd/MMM/yyyy";
      dataGridLabelColumn15.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn15.HeaderText = "Estimated Service Date";
      dataGridLabelColumn15.MappingName = "EstimatedVisitDate";
      dataGridLabelColumn15.ReadOnly = true;
      dataGridLabelColumn15.Width = 80;
      dataGridLabelColumn15.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn15);
      DataGridLabelColumn dataGridLabelColumn16 = new DataGridLabelColumn();
      dataGridLabelColumn16.Format = "";
      dataGridLabelColumn16.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn16.HeaderText = "Priority";
      dataGridLabelColumn16.MappingName = "Priority";
      dataGridLabelColumn16.ReadOnly = true;
      dataGridLabelColumn16.Width = 65;
      dataGridLabelColumn16.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn16);
      DataGridLabelColumn dataGridLabelColumn17 = new DataGridLabelColumn();
      dataGridLabelColumn17.Format = "";
      dataGridLabelColumn17.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn17.HeaderText = "Let Num";
      dataGridLabelColumn17.MappingName = "VisitNumber";
      dataGridLabelColumn17.ReadOnly = true;
      dataGridLabelColumn17.Width = 55;
      dataGridLabelColumn17.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn17);
      DataGridLabelColumn dataGridLabelColumn18 = new DataGridLabelColumn();
      dataGridLabelColumn18.Format = "dd/MMM/yyyy";
      dataGridLabelColumn18.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn18.HeaderText = "Job Created";
      dataGridLabelColumn18.MappingName = "JobCreatedDateTime";
      dataGridLabelColumn18.ReadOnly = true;
      dataGridLabelColumn18.Width = 120;
      dataGridLabelColumn18.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn18);
      DataGridLabelColumn dataGridLabelColumn19 = new DataGridLabelColumn();
      dataGridLabelColumn19.Format = "dd/MMM/yyyy";
      dataGridLabelColumn19.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn19.HeaderText = "Visit Created";
      dataGridLabelColumn19.MappingName = "VisitCreatedDateTime";
      dataGridLabelColumn19.ReadOnly = true;
      dataGridLabelColumn19.Width = 120;
      dataGridLabelColumn19.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn19);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisit.ToString();
      this.dgVisits.TableStyles.Add(tableStyle);
    }

    private void FRMVisitManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theCustomer = App.DB.Customer.Customer_Get(integer);
    }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      int num = this.theCustomer != null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, this.theCustomer.CustomerID, "", false)) : Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, 0, "", false));
      if ((uint) num <= 0U)
        return;
      this.theSite = App.DB.Sites.Get((object) num, SiteSQL.GetBy.SiteId, (object) null);
    }

    private void btnfindEngineer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theEngineer = App.DB.Engineer.Engineer_Get(integer);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void chkVisitDate_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkVisitDate.Checked)
      {
        this.dtpFrom.Enabled = true;
        this.dtpTo.Enabled = true;
      }
      else
      {
        this.dtpFrom.Value = DateAndTime.Today;
        this.dtpTo.Value = DateAndTime.Today;
        this.dtpFrom.Enabled = false;
        this.dtpTo.Enabled = false;
      }
    }

    private void chkVisitEnd_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkVisitEnd.Checked)
      {
        this.dtpVisitEndFrom.Enabled = true;
        this.dtpVisitEndTo.Enabled = true;
      }
      else
      {
        this.dtpVisitEndFrom.Value = DateAndTime.Today;
        this.dtpVisitEndTo.Value = DateAndTime.Today;
        this.dtpVisitEndFrom.Enabled = false;
        this.dtpVisitEndTo.Enabled = false;
      }
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void btnRequiringParts_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
      ComboBox cboStatus = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(2));
      this.cboStatus = cboStatus;
      this.PopulateDatagrid(true);
    }

    private void btnCreateOrder_Click(object sender, EventArgs e)
    {
      if (this.SelectedVisitDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a visit to create an order for", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedVisitDataRow["StatusEnumID"], (object) 4, false)), Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedVisitDataRow["StatusEnumID"], (object) 2, false)))))
      {
        int num2 = (int) App.ShowMessage("Only Visits that are waiting for parts or are ready for schedule are allowed to create orders", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        FRMOrder frmOrder = (FRMOrder) App.ShowForm(typeof (FRMOrder), false, new object[3]
        {
          (object) 0,
          this.SelectedVisitDataRow["EngineerVisitID"],
          (object) 4
        }, false);
      }
    }

    private void dgVisits_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedVisitDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a visit to view", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        bool flag = false;
        switch (Conversions.ToInteger(this.SelectedVisitDataRow["StatusEnumID"]))
        {
          case 0:
            if (App.ShowMessage("This visit has not entered a visit life span yet.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              App.ShowForm(typeof (FRMLogCallout), true, new object[5]
              {
                this.SelectedVisitDataRow["JobID"],
                this.SelectedVisitDataRow["SiteID"],
                (object) this,
                null,
                this.SelectedVisitDataRow["EngineerVisitID"]
              }, false);
              break;
            }
            break;
          case 1:
            if (App.ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              App.ShowForm(typeof (FRMLogCallout), true, new object[5]
              {
                this.SelectedVisitDataRow["JobID"],
                this.SelectedVisitDataRow["SiteID"],
                (object) this,
                null,
                this.SelectedVisitDataRow["EngineerVisitID"]
              }, false);
              break;
            }
            break;
          case 2:
            if (App.ShowMessage("This visit is waiting for parts, once recieved you may proceed.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              App.ShowForm(typeof (FRMLogCallout), true, new object[5]
              {
                this.SelectedVisitDataRow["JobID"],
                this.SelectedVisitDataRow["SiteID"],
                (object) this,
                null,
                this.SelectedVisitDataRow["EngineerVisitID"]
              }, false);
              break;
            }
            break;
          case 4:
            if (App.ShowMessage("This visit is ready for schedule, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              flag = true;
              break;
            }
            break;
          case 5:
            if (App.ShowMessage("This visit is scheduled, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              flag = true;
              break;
            }
            break;
          case 6:
            if (App.ShowMessage("This visit is currently with an engineer, once returned you may view the details.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              App.ShowForm(typeof (FRMLogCallout), true, new object[5]
              {
                this.SelectedVisitDataRow["JobID"],
                this.SelectedVisitDataRow["SiteID"],
                (object) this,
                null,
                this.SelectedVisitDataRow["EngineerVisitID"]
              }, false);
              break;
            }
            break;
          case 7:
            flag = true;
            break;
          case 8:
            flag = true;
            break;
          case 9:
            flag = true;
            break;
          case 10:
            flag = true;
            break;
        }
        if (flag)
        {
          App.ShowForm(typeof (FRMEngineerVisit), true, new object[2]
          {
            this.SelectedVisitDataRow["EngineerVisitID"],
            (object) this.dtVisitFilters
          }, false);
          this.updaterow();
        }
      }
    }

    public void updaterow()
    {
      DataView update = App.DB.EngineerVisits.EngineerVisit_GetUpdate(Conversions.ToInteger(this.SelectedVisitDataRow["EngineerVisitID"]));
      this.VisitsDataview.AllowDelete = true;
      this.SelectedVisitDataRow["VisitStatus"] = RuntimeHelpers.GetObjectValue(update.Table.Rows[0]["VisitStatus"]);
      this.SelectedVisitDataRow["StatusEnumID"] = RuntimeHelpers.GetObjectValue(update.Table.Rows[0]["StatusEnumID"]);
      this.SelectedVisitDataRow["InvoiceNotes"] = RuntimeHelpers.GetObjectValue(update.Table.Rows[0]["NotesFromEngineer"]);
    }

    private void txtPostcode_TextChanged(object sender, EventArgs e)
    {
    }

    private void cboOutcome_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      this.PopulateDatagrid(true);
    }

    public void PopulateDatagrid(bool withRun)
    {
      try
      {
        if (this.get_GetParameter(0) == null)
        {
          if (withRun)
          {
            string str1 = "(1 = 1 ";
            string str2 = "(1 = 1 ";
            if (this.theCustomer != null)
              str1 += " AND tblCustomer.CustomerID = " + Conversions.ToString(this.theCustomer.CustomerID);
            if (this.theSite != null)
              str1 += " AND tblSite.SiteID = " + Conversions.ToString(this.theSite.SiteID);
            if (this.theEngineer != null)
              str1 += " AND tblEngineer.EngineerID = " + Conversions.ToString(this.theEngineer.EngineerID);
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboType)) != 0.0)
              str1 += " AND tblJob.JobTypeID = " + Combo.get_GetSelectedItemValue(this.cboType);
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) != 0.0)
              str1 += " AND @THEStatusEnumIDString = " + Combo.get_GetSelectedItemValue(this.cboStatus);
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboOutcome)) != 0.0)
              str1 += " AND tblEngineerVisit.OutcomeEnumID = " + Combo.get_GetSelectedItemValue(this.cboOutcome);
            if (App.loggedInUser.UserRegions.Count > 0)
            {
              if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboRegion)) != 0.0)
              {
                str1 += " AND tblsite.RegionID = " + Combo.get_GetSelectedItemValue(this.cboRegion);
              }
              else
              {
                EnumerableRowCollection<DataRow> source = App.loggedInUser.UserRegions.Table.AsEnumerable();
                Func<DataRow, string> selector;
                // ISSUE: reference to a compiler-generated field
                if (FRMVisitManager._Closure\u0024__.\u0024I311\u002D0 != null)
                {
                  // ISSUE: reference to a compiler-generated field
                  selector = FRMVisitManager._Closure\u0024__.\u0024I311\u002D0;
                }
                else
                {
                  // ISSUE: reference to a compiler-generated field
                  FRMVisitManager._Closure\u0024__.\u0024I311\u002D0 = selector = (Func<DataRow, string>) (x => x.Field<int>("RegionID").ToString());
                }
                string str3 = string.Join(",", source.Select<DataRow, string>(selector).ToArray<string>());
                str1 = str1 + " AND tblsite.RegionID in (" + str3 + ")";
              }
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboRegion)) != 0.0)
              str1 += " AND tblsite.RegionID = " + Combo.get_GetSelectedItemValue(this.cboRegion);
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.CboServExp)) != 0.0)
              str1 = str1 + " AND DATEADD(year,1,tblsite.lastservicedate) < '" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Today.AddDays(Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.CboServExp))), "yyyy-MM-dd") + "'";
            string str4 = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDepartment));
            if (Helper.IsValidInteger((object) str4) && Helper.MakeIntegerValid((object) str4) > 0)
              str1 = str1 + " AND tblEngineer.Department = '" + str4 + "'";
            else if (!Versioned.IsNumeric((object) str4))
              str1 = str1 + " AND tblEngineer.Department = '" + str4 + "'";
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboLetterNumber)) != 0.0)
              str1 = str1 + " AND tblEngineerVisit.VisitNumber = " + Combo.get_GetSelectedItemValue(this.cboLetterNumber);
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPriority)) != 0.0)
              str1 = str1 + " AND pris.managerid = " + Combo.get_GetSelectedItemValue(this.cboPriority);
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVisitCharge)) != 0.0)
              str2 = str2 + " AND VisitChargeable = " + Combo.get_GetSelectedItemValue(this.cboVisitCharge);
            if ((uint) this.txtJobNumber.Text.Trim().Length > 0U)
              str1 = str1 + " AND tblJob.JobNumber LIKE '" + this.txtJobNumber.Text.Trim() + "%'";
            if ((uint) this.txtPONumber.Text.Trim().Length > 0U)
              str1 = str1 + " AND tblJobOfWork.PONumber LIKE '" + this.txtPONumber.Text.Trim() + "%'";
            if (this.chkVisitDate.Checked)
              str1 = str1 + " AND tblEngineerVisit.StartDateTime >= '" + Microsoft.VisualBasic.Strings.Format((object) this.dtpFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblEngineerVisit.StartDateTime <= '" + Microsoft.VisualBasic.Strings.Format((object) this.dtpTo.Value, "dd-MMM-yyyy 23:59:59") + "'";
            if (this.chkVisitEnd.Checked)
              str1 = str1 + " AND tblEngineerVisit.EndDateTime >= '" + Microsoft.VisualBasic.Strings.Format((object) this.dtpVisitEndFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblEngineerVisit.EndDateTime <= '" + Microsoft.VisualBasic.Strings.Format((object) this.dtpVisitEndTo.Value, "dd-MMM-yyyy 23:59:59") + "'";
            if (this.chkServiceDate.Checked)
              str1 = str1 + " AND tblContractOriginalPPMVisit.EstimatedVisitDate >= '" + Microsoft.VisualBasic.Strings.Format((object) this.dtpFromServiceDate.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblContractOriginalPPMVisit.EstimatedVisitDate <= '" + Microsoft.VisualBasic.Strings.Format((object) this.dtpToServiceDate.Value, "dd-MMM-yyyy 23:59:59") + "'";
            if (this.chkftfcode.Checked)
              str1 += " AND tblEngineerVisitQC.FTFCode IS NULL ";
            if (this.chkRecharge.Checked)
              str1 += " AND tblEngineerVisit.Recharge = 1 ";
            if ((uint) this.txtPostcode.Text.Trim().Length > 0U)
              str1 = str1 + " AND tblSite.Postcode LIKE '" + this.txtPostcode.Text.Trim() + "%'";
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboQualification)) != 0.0)
              str1 = str1 + " AND tblJobOfWork.QualificationID = " + Combo.get_GetSelectedItemValue(this.cboQualification);
            string Where = str1 + ")";
            string addtionalWhere = str2 + ")";
            this.VisitsDataview = App.DB.EngineerVisits.EngineerVisits_Manager_Get_ByWhere(Where, addtionalWhere);
            this.count = this.VisitsDataview.Count;
            this.grpEngineerVisits.Text = "Double Click To View / Edit (" + Conversions.ToString(this.count) + ")";
          }
          else
            this.VisitsDataview = (DataView) null;
        }
        else
        {
          this.VisitsDataview = (DataView) this.get_GetParameter(0);
          this.grpFilter.Enabled = false;
        }
        this.LogSearchCriteria();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ResetFilters()
    {
      this.theCustomer = (FSM.Entity.Customers.Customer) null;
      this.theEngineer = (Engineer) null;
      ComboBox cboDefinition = this.cboDefinition;
      Combo.SetSelectedComboItem_By_Value(ref cboDefinition, Conversions.ToString(0));
      this.cboDefinition = cboDefinition;
      ComboBox cboType = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType, Conversions.ToString(0));
      this.cboType = cboType;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(0));
      this.cboStatus = cboStatus;
      ComboBox cboOutcome = this.cboOutcome;
      Combo.SetSelectedComboItem_By_Value(ref cboOutcome, Conversions.ToString(0));
      this.cboOutcome = cboOutcome;
      this.txtJobNumber.Text = "";
      this.txtPONumber.Text = "";
      this.txtPostcode.Text = "";
      this.chkVisitDate.Checked = false;
      this.dtpFrom.Value = DateAndTime.Today;
      this.dtpTo.Value = DateAndTime.Today;
      this.dtpFrom.Enabled = false;
      this.dtpTo.Enabled = false;
      this.grpFilter.Enabled = true;
    }

    public void Export()
    {
      if (this.VisitsDataview != null && this.VisitsDataview.Table.Rows.Count > 0)
      {
        DataTable dtData = new DataTable();
        dtData.Columns.Add("Customer");
        dtData.Columns.Add("Site");
        dtData.Columns.Add("JobNumber");
        dtData.Columns.Add("PONumber");
        dtData.Columns.Add("VisitOutcome");
        dtData.Columns.Add("Type");
        dtData.Columns.Add("VisitStatus");
        dtData.Columns.Add("Engineer");
        dtData.Columns.Add("PolicyNumber");
        dtData.Columns.Add("Priority");
        dtData.Columns.Add("Department");
        dtData.Columns.Add("VisitNumber");
        dtData.Columns.Add("SiteContact");
        dtData.Columns.Add("FirstLine");
        dtData.Columns.Add("Area");
        dtData.Columns.Add("PostCode");
        dtData.Columns.Add("TelephoneNum");
        dtData.Columns.Add("MobileNum");
        dtData.Columns.Add("EmailAddress");
        dtData.Columns.Add("ServiceExpiryDate", typeof (DateTime));
        dtData.Columns.Add("SiteFuel");
        dtData.Columns.Add("StartDateTime", typeof (DateTime));
        dtData.Columns.Add("NotesToEngineer");
        dtData.Columns.Add("NotesFromEngineer");
        dtData.Columns.Add("InvoiceNotes");
        dtData.Columns.Add("JobCreatedDateTime", typeof (DateTime));
        dtData.Columns.Add("VisitCreatedDateTime", typeof (DateTime));
        IEnumerator enumerator;
        try
        {
          enumerator = this.VisitsDataview.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            DataRow row = dtData.NewRow();
            row["Customer"] = RuntimeHelpers.GetObjectValue(current["Customer"]);
            row["Site"] = RuntimeHelpers.GetObjectValue(current["Site"]);
            row["JobNumber"] = RuntimeHelpers.GetObjectValue(current["JobNumber"]);
            row["PONumber"] = RuntimeHelpers.GetObjectValue(current["PONumber"]);
            row["VisitOutcome"] = RuntimeHelpers.GetObjectValue(current["VisitOutcome"]);
            row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
            row["VisitStatus"] = RuntimeHelpers.GetObjectValue(current["VisitStatus"]);
            row["Engineer"] = RuntimeHelpers.GetObjectValue(current["Engineer"]);
            row["PolicyNumber"] = RuntimeHelpers.GetObjectValue(current["PolicyNumber"]);
            row["Priority"] = RuntimeHelpers.GetObjectValue(current["Priority"]);
            row["Department"] = RuntimeHelpers.GetObjectValue(current["Department"]);
            row["VisitNumber"] = RuntimeHelpers.GetObjectValue(current["VisitNumber"]);
            row["SiteContact"] = RuntimeHelpers.GetObjectValue(current["SiteContact"]);
            row["FirstLine"] = RuntimeHelpers.GetObjectValue(current["FirstLine"]);
            row["Area"] = RuntimeHelpers.GetObjectValue(current["Area"]);
            row["PostCode"] = RuntimeHelpers.GetObjectValue(current["PostCode"]);
            row["TelephoneNum"] = RuntimeHelpers.GetObjectValue(current["TelephoneNum"]);
            row["MobileNum"] = RuntimeHelpers.GetObjectValue(current["MobileNum"]);
            row["EmailAddress"] = RuntimeHelpers.GetObjectValue(current["EmailAddress"]);
            row["ServiceExpiryDate"] = RuntimeHelpers.GetObjectValue(current["ServiceExpiryDate"]);
            row["SiteFuel"] = RuntimeHelpers.GetObjectValue(current["SiteFuel"]);
            row["StartDateTime"] = RuntimeHelpers.GetObjectValue(current["StartDateTime"]);
            row["NotesToEngineer"] = RuntimeHelpers.GetObjectValue(current["NotesToEngineer"]);
            row["NotesFromEngineer"] = RuntimeHelpers.GetObjectValue(current["OutcomeDetails"]);
            row["InvoiceNotes"] = RuntimeHelpers.GetObjectValue(current["InvoiceNotes"]);
            row["JobCreatedDateTime"] = RuntimeHelpers.GetObjectValue(current["JobCreatedDateTime"]);
            row["VisitCreatedDateTime"] = RuntimeHelpers.GetObjectValue(current["VisitCreatedDateTime"]);
            dtData.Rows.Add(row);
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        ExportHelper.Export(dtData, "VisitManager", Enums.ExportType.XLS);
      }
      else
      {
        int num = (int) App.ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void cboOutcome_TextChanged(object sender, EventArgs e)
    {
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboOutcome.Text.ToString(), "Further Works", false) == 0)
      {
        this.chkftfcode.Visible = true;
      }
      else
      {
        this.chkftfcode.CheckState = CheckState.Unchecked;
        this.chkftfcode.Visible = true;
      }
    }

    private void cboOutcome_SelectedIndexChanged_1(object sender, EventArgs e)
    {
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.cboOutcome.Text.ToString(), "Further Works", false) == 0)
      {
        this.chkftfcode.Visible = true;
      }
      else
      {
        this.chkftfcode.CheckState = CheckState.Unchecked;
        this.chkftfcode.Visible = false;
      }
    }

    private void LogSearchCriteria()
    {
      this.dtVisitFilters.Rows.Clear();
      DataTable dtVisitFilters = this.dtVisitFilters;
      DataRow row1 = dtVisitFilters.NewRow();
      row1["Field"] = (object) "theCustomer";
      row1["Value"] = this.theCustomer != null ? (object) this.theCustomer.CustomerID : (object) 0;
      row1["Type"] = (object) "Object";
      dtVisitFilters.Rows.Add(row1);
      DataRow row2 = dtVisitFilters.NewRow();
      row2["Field"] = (object) "theSite";
      row2["Value"] = this.theSite != null ? (object) this.theSite.SiteID : (object) 0;
      row2["Type"] = (object) "Object";
      dtVisitFilters.Rows.Add(row2);
      DataRow row3 = dtVisitFilters.NewRow();
      row3["Field"] = (object) "theEngineer";
      row3["Value"] = this.theEngineer != null ? (object) this.theEngineer.EngineerID : (object) 0;
      row3["Type"] = (object) "Object";
      dtVisitFilters.Rows.Add(row3);
      DataRow row4 = dtVisitFilters.NewRow();
      row4["Field"] = (object) "cboType";
      row4["Value"] = (object) Combo.get_GetSelectedItemValue(this.cboType);
      row4["Type"] = (object) "Combo";
      dtVisitFilters.Rows.Add(row4);
      DataRow row5 = dtVisitFilters.NewRow();
      row5["Field"] = (object) "cboStatus";
      row5["Value"] = (object) Combo.get_GetSelectedItemValue(this.cboStatus);
      row5["Type"] = (object) "Combo";
      dtVisitFilters.Rows.Add(row5);
      DataRow row6 = dtVisitFilters.NewRow();
      row6["Field"] = (object) "cboOutcome";
      row6["Value"] = (object) Combo.get_GetSelectedItemValue(this.cboOutcome);
      row6["Type"] = (object) "Combo";
      dtVisitFilters.Rows.Add(row6);
      DataRow row7 = dtVisitFilters.NewRow();
      row7["Field"] = (object) "txtJobNumber";
      row7["Value"] = (object) this.txtJobNumber.Text;
      row7["Type"] = (object) "Text";
      dtVisitFilters.Rows.Add(row7);
      DataRow row8 = dtVisitFilters.NewRow();
      row8["Field"] = (object) "txtPONumber";
      row8["Value"] = (object) this.txtPONumber.Text;
      row8["Type"] = (object) "Text";
      dtVisitFilters.Rows.Add(row8);
      DataRow row9 = dtVisitFilters.NewRow();
      row9["Field"] = (object) "txtPostcode";
      row9["Value"] = (object) this.txtPostcode.Text;
      row9["Type"] = (object) "Text";
      dtVisitFilters.Rows.Add(row9);
      DataRow row10 = dtVisitFilters.NewRow();
      row10["Field"] = (object) "chkVisitDate";
      row10["Value"] = (object) this.chkVisitDate.Checked;
      row10["Type"] = (object) "CHECK";
      dtVisitFilters.Rows.Add(row10);
      DataRow row11 = dtVisitFilters.NewRow();
      row11["Field"] = (object) "dtpFrom";
      row11["Value"] = (object) this.dtpFrom.Value;
      row11["Type"] = (object) "DTP";
      dtVisitFilters.Rows.Add(row11);
      DataRow row12 = dtVisitFilters.NewRow();
      row12["Field"] = (object) "dtpTo";
      row12["Value"] = (object) this.dtpTo.Value;
      row12["Type"] = (object) "DTP";
      dtVisitFilters.Rows.Add(row12);
    }

    private void LoadLastFilters()
    {
      if (this.Controls.Count <= 0)
        return;
      if (this.dtVisitFilters.Rows.Count > 0)
      {
        IEnumerator enumerator;
        try
        {
          enumerator = this.dtVisitFilters.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            string Left1 = current["Type"].ToString();
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Object", false) != 0)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Combo", false) != 0)
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Text", false) != 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Radio", false) != 0)
                  {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "DTP", false) != 0)
                    {
                      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "CHECK", false) == 0)
                        ((CheckBox) this.Controls.Find(Conversions.ToString(current["Field"]), true)[0]).Checked = Conversions.ToBoolean(current["Value"]);
                    }
                    else
                      ((DateTimePicker) this.Controls.Find(Conversions.ToString(current["Field"]), true)[0]).Value = Conversions.ToDate(current["Value"]);
                  }
                  else
                    ((RadioButton) this.Controls.Find(Conversions.ToString(current["Field"]), true)[0]).Checked = Conversions.ToBoolean(current["Value"]);
                }
                else
                  ((TextBox) this.Controls.Find(Conversions.ToString(current["Field"]), true)[0]).Text = Conversions.ToString(current["Value"]);
              }
              else
              {
                Control[] controlArray;
                ComboBox combo = (ComboBox) (controlArray = this.Controls.Find(Conversions.ToString(current["Field"]), true))[0];
                Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(current["Value"]));
                controlArray[0] = (Control) combo;
              }
            }
            else
            {
              string Left2 = current["Field"].ToString();
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "theCustomer", false) != 0)
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "theSite", false) != 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "theEngineer", false) == 0)
                  {
                    Engineer engineer = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(current["Value"]));
                    if (engineer != null)
                      this.theEngineer = engineer;
                  }
                }
                else
                {
                  FSM.Entity.Sites.Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(current["Value"]), SiteSQL.GetBy.SiteId, (object) null);
                  if (site != null)
                    this.theSite = site;
                }
              }
              else
              {
                FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(Conversions.ToInteger(current["Value"]));
                if (customer != null)
                  this.theCustomer = customer;
              }
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.PopulateDatagrid(true);
      }
    }

    private void txtJobNumber_TextChanged(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.PopulateDatagrid(true);
    }
  }
}
