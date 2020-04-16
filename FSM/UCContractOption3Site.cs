// Decompiled with JetBrains decompiler
// Type: FSM.UCContractOption3Site
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractOption3s;
using FSM.Entity.ContractOption3SitePPMVisits;
using FSM.Entity.ContractOption3Sites;
using FSM.Entity.EngineerVisits;
using FSM.Entity.InvoiceToBeRaiseds;
using FSM.Entity.JobAssets;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.Management;
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
using System.Windows.Forms;

namespace FSM
{
  public class UCContractOption3Site : UCBase, IUserControl
  {
    private IContainer components;
    private bool _InvoiceInserted;
    private ContractOption3Site _currentContractOption3Site;
    private DataView _Assets;
    private int _NumOfMonths;
    private ArrayList _Visits;
    private DataView _AssetDurations;
    private DataView _PPMSchedule;
    private DataView _InvoiceAddresses;

    public UCContractOption3Site()
    {
      this.Load += new EventHandler(this.UCContractOption3Site_Load);
      this._InvoiceInserted = false;
      this._NumOfMonths = 0;
      this._Visits = new ArrayList();
      this._AssetDurations = new DataView();
      this._PPMSchedule = new DataView();
      this.InitializeComponent();
      ComboBox invoiceFrequencyId = this.cboInvoiceFrequencyID;
      Combo.SetUpCombo(ref invoiceFrequencyId, DynamicDataTables.InvoiceFrequency, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboInvoiceFrequencyID = invoiceFrequencyId;
      ComboBox visitFrequencyId = this.cboVisitFrequencyID;
      Combo.SetUpCombo(ref visitFrequencyId, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboVisitFrequencyID = visitFrequencyId;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpContractOption3Site { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSiteID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContractSiteReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractSiteReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpStartDate
    {
      get
      {
        return this._dtpStartDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpStartDate_ValueChanged);
        DateTimePicker dtpStartDate1 = this._dtpStartDate;
        if (dtpStartDate1 != null)
          dtpStartDate1.ValueChanged -= eventHandler;
        this._dtpStartDate = value;
        DateTimePicker dtpStartDate2 = this._dtpStartDate;
        if (dtpStartDate2 == null)
          return;
        dtpStartDate2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label lblStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpEndDate
    {
      get
      {
        return this._dtpEndDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpEndDate_ValueChanged);
        DateTimePicker dtpEndDate1 = this._dtpEndDate;
        if (dtpEndDate1 != null)
          dtpEndDate1.ValueChanged -= eventHandler;
        this._dtpEndDate = value;
        DateTimePicker dtpEndDate2 = this._dtpEndDate;
        if (dtpEndDate2 == null)
          return;
        dtpEndDate2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label lblEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFirstVisitDate
    {
      get
      {
        return this._dtpFirstVisitDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpFirstVisitDate_ValueChanged);
        DateTimePicker dtpFirstVisitDate1 = this._dtpFirstVisitDate;
        if (dtpFirstVisitDate1 != null)
          dtpFirstVisitDate1.ValueChanged -= eventHandler;
        this._dtpFirstVisitDate = value;
        DateTimePicker dtpFirstVisitDate2 = this._dtpFirstVisitDate;
        if (dtpFirstVisitDate2 == null)
          return;
        dtpFirstVisitDate2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label lblFirstVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVisitFrequencyID
    {
      get
      {
        return this._cboVisitFrequencyID;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboVisitFrequencyID_SelectedIndexChanged);
        ComboBox visitFrequencyId1 = this._cboVisitFrequencyID;
        if (visitFrequencyId1 != null)
          visitFrequencyId1.SelectedIndexChanged -= eventHandler;
        this._cboVisitFrequencyID = value;
        ComboBox visitFrequencyId2 = this._cboVisitFrequencyID;
        if (visitFrequencyId2 == null)
          return;
        visitFrequencyId2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblVisitFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInvoiceFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoiceFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSitePrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSitePrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblWarning { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRefreshGrid
    {
      get
      {
        return this._btnRefreshGrid;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRefreshGrid_Click);
        Button btnRefreshGrid1 = this._btnRefreshGrid;
        if (btnRefreshGrid1 != null)
          btnRefreshGrid1.Click -= eventHandler;
        this._btnRefreshGrid = value;
        Button btnRefreshGrid2 = this._btnRefreshGrid;
        if (btnRefreshGrid2 == null)
          return;
        btnRefreshGrid2.Click += eventHandler;
      }
    }

    internal virtual GroupBox gpbPPM { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPPMVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgInvoiceAddress
    {
      get
      {
        return this._dgInvoiceAddress;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgInvoiceAddress_Click);
        DataGrid dgInvoiceAddress1 = this._dgInvoiceAddress;
        if (dgInvoiceAddress1 != null)
          dgInvoiceAddress1.Click -= eventHandler;
        this._dgInvoiceAddress = value;
        DataGrid dgInvoiceAddress2 = this._dgInvoiceAddress;
        if (dgInvoiceAddress2 == null)
          return;
        dgInvoiceAddress2.Click += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpFirstInvoiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpContractOption3Site = new GroupBox();
      this.gpbPPM = new GroupBox();
      this.dgPPMVisits = new DataGrid();
      this.btnRefreshGrid = new Button();
      this.lblWarning = new Label();
      this.gpbAssets = new GroupBox();
      this.dgAssets = new DataGrid();
      this.txtSite = new TextBox();
      this.lblSiteID = new Label();
      this.txtContractSiteReference = new TextBox();
      this.lblContractSiteReference = new Label();
      this.dtpStartDate = new DateTimePicker();
      this.lblStartDate = new Label();
      this.dtpEndDate = new DateTimePicker();
      this.lblEndDate = new Label();
      this.dtpFirstVisitDate = new DateTimePicker();
      this.lblFirstVisitDate = new Label();
      this.cboVisitFrequencyID = new ComboBox();
      this.lblVisitFrequencyID = new Label();
      this.cboInvoiceFrequencyID = new ComboBox();
      this.lblInvoiceFrequencyID = new Label();
      this.txtSitePrice = new TextBox();
      this.lblSitePrice = new Label();
      this.gpbInvoiceAddress = new GroupBox();
      this.dgInvoiceAddress = new DataGrid();
      this.dtpFirstInvoiceDate = new DateTimePicker();
      this.Label1 = new Label();
      this.grpContractOption3Site.SuspendLayout();
      this.gpbPPM.SuspendLayout();
      this.dgPPMVisits.BeginInit();
      this.gpbAssets.SuspendLayout();
      this.dgAssets.BeginInit();
      this.gpbInvoiceAddress.SuspendLayout();
      this.dgInvoiceAddress.BeginInit();
      this.SuspendLayout();
      this.grpContractOption3Site.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContractOption3Site.Controls.Add((Control) this.gpbInvoiceAddress);
      this.grpContractOption3Site.Controls.Add((Control) this.dtpFirstInvoiceDate);
      this.grpContractOption3Site.Controls.Add((Control) this.Label1);
      this.grpContractOption3Site.Controls.Add((Control) this.gpbPPM);
      this.grpContractOption3Site.Controls.Add((Control) this.btnRefreshGrid);
      this.grpContractOption3Site.Controls.Add((Control) this.lblWarning);
      this.grpContractOption3Site.Controls.Add((Control) this.gpbAssets);
      this.grpContractOption3Site.Controls.Add((Control) this.txtSite);
      this.grpContractOption3Site.Controls.Add((Control) this.lblSiteID);
      this.grpContractOption3Site.Controls.Add((Control) this.txtContractSiteReference);
      this.grpContractOption3Site.Controls.Add((Control) this.lblContractSiteReference);
      this.grpContractOption3Site.Controls.Add((Control) this.dtpStartDate);
      this.grpContractOption3Site.Controls.Add((Control) this.lblStartDate);
      this.grpContractOption3Site.Controls.Add((Control) this.dtpEndDate);
      this.grpContractOption3Site.Controls.Add((Control) this.lblEndDate);
      this.grpContractOption3Site.Controls.Add((Control) this.dtpFirstVisitDate);
      this.grpContractOption3Site.Controls.Add((Control) this.lblFirstVisitDate);
      this.grpContractOption3Site.Controls.Add((Control) this.cboVisitFrequencyID);
      this.grpContractOption3Site.Controls.Add((Control) this.lblVisitFrequencyID);
      this.grpContractOption3Site.Controls.Add((Control) this.cboInvoiceFrequencyID);
      this.grpContractOption3Site.Controls.Add((Control) this.lblInvoiceFrequencyID);
      this.grpContractOption3Site.Controls.Add((Control) this.txtSitePrice);
      this.grpContractOption3Site.Controls.Add((Control) this.lblSitePrice);
      this.grpContractOption3Site.Location = new System.Drawing.Point(8, 8);
      this.grpContractOption3Site.Name = "grpContractOption3Site";
      this.grpContractOption3Site.Size = new Size(979, 594);
      this.grpContractOption3Site.TabIndex = 1;
      this.grpContractOption3Site.TabStop = false;
      this.grpContractOption3Site.Text = "Main Details";
      this.gpbPPM.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbPPM.Controls.Add((Control) this.dgPPMVisits);
      this.gpbPPM.Location = new System.Drawing.Point(9, 449);
      this.gpbPPM.Name = "gpbPPM";
      this.gpbPPM.Size = new Size(963, 139);
      this.gpbPPM.TabIndex = 12;
      this.gpbPPM.TabStop = false;
      this.gpbPPM.Text = "Scheduled Visit";
      this.dgPPMVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPPMVisits.DataMember = "";
      this.dgPPMVisits.HeaderForeColor = SystemColors.ControlText;
      this.dgPPMVisits.Location = new System.Drawing.Point(10, 19);
      this.dgPPMVisits.Name = "dgPPMVisits";
      this.dgPPMVisits.Size = new Size(947, 112);
      this.dgPPMVisits.TabIndex = 0;
      this.btnRefreshGrid.UseVisualStyleBackColor = true;
      this.btnRefreshGrid.Location = new System.Drawing.Point(424, 120);
      this.btnRefreshGrid.Name = "btnRefreshGrid";
      this.btnRefreshGrid.Size = new Size(200, 23);
      this.btnRefreshGrid.TabIndex = 7;
      this.btnRefreshGrid.Text = "Load Assets Scheduled";
      this.lblWarning.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblWarning.ForeColor = Color.Red;
      this.lblWarning.Location = new System.Drawing.Point(328, 144);
      this.lblWarning.Name = "lblWarning";
      this.lblWarning.Size = new Size(296, 16);
      this.lblWarning.TabIndex = 20;
      this.lblWarning.Text = "! First Date must be between Start &&End Date";
      this.lblWarning.Visible = false;
      this.gpbAssets.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbAssets.Controls.Add((Control) this.dgAssets);
      this.gpbAssets.Location = new System.Drawing.Point(9, 168);
      this.gpbAssets.Name = "gpbAssets";
      this.gpbAssets.Size = new Size(963, 272);
      this.gpbAssets.TabIndex = 11;
      this.gpbAssets.TabStop = false;
      this.gpbAssets.Text = "Assets - Enter duration in hours for each month";
      this.dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAssets.DataMember = "";
      this.dgAssets.HeaderForeColor = SystemColors.ControlText;
      this.dgAssets.Location = new System.Drawing.Point(10, 25);
      this.dgAssets.Name = "dgAssets";
      this.dgAssets.Size = new Size(947, 239);
      this.dgAssets.TabIndex = 0;
      this.txtSite.Location = new System.Drawing.Point(120, 24);
      this.txtSite.Multiline = true;
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.ScrollBars = ScrollBars.Vertical;
      this.txtSite.Size = new Size(200, 68);
      this.txtSite.TabIndex = 0;
      this.txtSite.Text = "";
      this.lblSiteID.Location = new System.Drawing.Point(9, 25);
      this.lblSiteID.Name = "lblSiteID";
      this.lblSiteID.Size = new Size(139, 20);
      this.lblSiteID.TabIndex = 13;
      this.lblSiteID.Text = "Property";
      this.txtContractSiteReference.Location = new System.Drawing.Point(120, 96);
      this.txtContractSiteReference.MaxLength = 100;
      this.txtContractSiteReference.Name = "txtContractSiteReference";
      this.txtContractSiteReference.ReadOnly = true;
      this.txtContractSiteReference.Size = new Size(200, 21);
      this.txtContractSiteReference.TabIndex = 1;
      this.txtContractSiteReference.Tag = (object) "ContractOption3Site.ContractSiteReference";
      this.txtContractSiteReference.Text = "";
      this.lblContractSiteReference.Location = new System.Drawing.Point(10, 96);
      this.lblContractSiteReference.Name = "lblContractSiteReference";
      this.lblContractSiteReference.Size = new Size(139, 20);
      this.lblContractSiteReference.TabIndex = 14;
      this.lblContractSiteReference.Text = "Contract Property Ref";
      this.dtpStartDate.Location = new System.Drawing.Point(424, 24);
      this.dtpStartDate.Name = "dtpStartDate";
      this.dtpStartDate.TabIndex = 3;
      this.dtpStartDate.Tag = (object) "ContractOption3Site.StartDate";
      this.lblStartDate.Location = new System.Drawing.Point(328, 25);
      this.lblStartDate.Name = "lblStartDate";
      this.lblStartDate.Size = new Size(96, 20);
      this.lblStartDate.TabIndex = 16;
      this.lblStartDate.Text = "Start Date";
      this.dtpEndDate.Location = new System.Drawing.Point(424, 48);
      this.dtpEndDate.Name = "dtpEndDate";
      this.dtpEndDate.TabIndex = 4;
      this.dtpEndDate.Tag = (object) "ContractOption3Site.EndDate";
      this.lblEndDate.Location = new System.Drawing.Point(328, 49);
      this.lblEndDate.Name = "lblEndDate";
      this.lblEndDate.Size = new Size(96, 20);
      this.lblEndDate.TabIndex = 17;
      this.lblEndDate.Text = "End Date";
      this.dtpFirstVisitDate.Location = new System.Drawing.Point(424, 72);
      this.dtpFirstVisitDate.Name = "dtpFirstVisitDate";
      this.dtpFirstVisitDate.TabIndex = 5;
      this.dtpFirstVisitDate.Tag = (object) "ContractOption3Site.FirstVisitDate";
      this.lblFirstVisitDate.Location = new System.Drawing.Point(328, 72);
      this.lblFirstVisitDate.Name = "lblFirstVisitDate";
      this.lblFirstVisitDate.Size = new Size(96, 20);
      this.lblFirstVisitDate.TabIndex = 18;
      this.lblFirstVisitDate.Text = "First Visit Date";
      this.cboVisitFrequencyID.Cursor = Cursors.Hand;
      this.cboVisitFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVisitFrequencyID.Location = new System.Drawing.Point(424, 96);
      this.cboVisitFrequencyID.Name = "cboVisitFrequencyID";
      this.cboVisitFrequencyID.Size = new Size(200, 21);
      this.cboVisitFrequencyID.TabIndex = 6;
      this.cboVisitFrequencyID.Tag = (object) "ContractOption3Site.VisitFrequencyID";
      this.lblVisitFrequencyID.Location = new System.Drawing.Point(328, 96);
      this.lblVisitFrequencyID.Name = "lblVisitFrequencyID";
      this.lblVisitFrequencyID.Size = new Size(96, 20);
      this.lblVisitFrequencyID.TabIndex = 19;
      this.lblVisitFrequencyID.Text = "Visit Frequency";
      this.cboInvoiceFrequencyID.Cursor = Cursors.Hand;
      this.cboInvoiceFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInvoiceFrequencyID.Location = new System.Drawing.Point(768, 24);
      this.cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID";
      this.cboInvoiceFrequencyID.Size = new Size(200, 21);
      this.cboInvoiceFrequencyID.TabIndex = 8;
      this.cboInvoiceFrequencyID.Tag = (object) "ContractOption3Site.InvoiceFrequencyID";
      this.lblInvoiceFrequencyID.Location = new System.Drawing.Point(632, 24);
      this.lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID";
      this.lblInvoiceFrequencyID.Size = new Size(112, 20);
      this.lblInvoiceFrequencyID.TabIndex = 21;
      this.lblInvoiceFrequencyID.Text = "Invoice Frequency ";
      this.txtSitePrice.Location = new System.Drawing.Point(120, 121);
      this.txtSitePrice.MaxLength = 9;
      this.txtSitePrice.Name = "txtSitePrice";
      this.txtSitePrice.Size = new Size(200, 21);
      this.txtSitePrice.TabIndex = 2;
      this.txtSitePrice.Tag = (object) "ContractOption3Site.SitePrice";
      this.txtSitePrice.Text = "";
      this.lblSitePrice.Location = new System.Drawing.Point(10, 121);
      this.lblSitePrice.Name = "lblSitePrice";
      this.lblSitePrice.Size = new Size(112, 20);
      this.lblSitePrice.TabIndex = 15;
      this.lblSitePrice.Text = "Property Price";
      this.gpbInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbInvoiceAddress.Controls.Add((Control) this.dgInvoiceAddress);
      this.gpbInvoiceAddress.Location = new System.Drawing.Point(636, 72);
      this.gpbInvoiceAddress.Name = "gpbInvoiceAddress";
      this.gpbInvoiceAddress.Size = new Size(336, 96);
      this.gpbInvoiceAddress.TabIndex = 10;
      this.gpbInvoiceAddress.TabStop = false;
      this.gpbInvoiceAddress.Text = "Invoice Address";
      this.dgInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgInvoiceAddress.DataMember = "";
      this.dgInvoiceAddress.HeaderForeColor = SystemColors.ControlText;
      this.dgInvoiceAddress.Location = new System.Drawing.Point(8, 16);
      this.dgInvoiceAddress.Name = "dgInvoiceAddress";
      this.dgInvoiceAddress.Size = new Size(320, 72);
      this.dgInvoiceAddress.TabIndex = 0;
      this.dtpFirstInvoiceDate.Location = new System.Drawing.Point(768, 48);
      this.dtpFirstInvoiceDate.Name = "dtpFirstInvoiceDate";
      this.dtpFirstInvoiceDate.TabIndex = 9;
      this.dtpFirstInvoiceDate.Tag = (object) "";
      this.Label1.Location = new System.Drawing.Point(632, 48);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(132, 20);
      this.Label1.TabIndex = 22;
      this.Label1.Text = "First Invoice Date";
      this.Controls.Add((Control) this.grpContractOption3Site);
      this.Name = nameof (UCContractOption3Site);
      this.Size = new Size(994, 616);
      this.grpContractOption3Site.ResumeLayout(false);
      this.gpbPPM.ResumeLayout(false);
      this.dgPPMVisits.EndInit();
      this.gpbAssets.ResumeLayout(false);
      this.dgAssets.EndInit();
      this.gpbInvoiceAddress.ResumeLayout(false);
      this.dgInvoiceAddress.EndInit();
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
        return (object) this.CurrentContractOption3Site;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    private bool InvoiceInserted
    {
      get
      {
        return this._InvoiceInserted;
      }
      set
      {
        this._InvoiceInserted = value;
      }
    }

    public ContractOption3Site CurrentContractOption3Site
    {
      get
      {
        return this._currentContractOption3Site;
      }
      set
      {
        this._currentContractOption3Site = value;
        if (this.CurrentContractOption3Site == null)
        {
          this.CurrentContractOption3Site = new ContractOption3Site();
          this.CurrentContractOption3Site.Exists = false;
        }
        if (!this.CurrentContractOption3Site.Exists)
          return;
        this.Populate(0);
        FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
        FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) this.CurrentContractOption3Site.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
        this.txtSite.Text = Strings.Replace(Strings.Replace(Strings.Replace(site2.Address1 + ", " + site2.Address2 + ", " + site2.Address3 + ", " + site2.Address4 + ", " + site2.Address5 + ", " + site2.Postcode + ".", ", , ", ", ", 1, -1, CompareMethod.Binary), ", , ", ", ", 1, -1, CompareMethod.Binary), ", , ", ", ", 1, -1, CompareMethod.Binary);
        this.PPMSchedule = App.DB.ContractOption3SitePPMVisit.ContractOption3SitePPMVisit_GetAll_ContractSiteID(this.CurrentContractOption3Site.ContractSiteID);
        if (this.CurrentContractOption3Site.InvoiceAddressID > 0)
          this.InvoiceInserted = true;
        if (this.InvoiceInserted)
        {
          this.dtpFirstInvoiceDate.Enabled = false;
          this.cboInvoiceFrequencyID.Enabled = false;
          this.gpbInvoiceAddress.Enabled = false;
        }
        this.InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_SiteID(this.CurrentContractOption3Site.PropertyID);
        if (this.CurrentContractOption3Site.InvoiceAddressID > 0)
        {
          int num = 0;
          IEnumerator enumerator;
          try
          {
            enumerator = this.InvoiceAddresses.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AddressID"], (object) this.CurrentContractOption3Site.InvoiceAddressID, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AddressTypeID"], (object) this.CurrentContractOption3Site.InvoiceAddressTypeID, false))))
              {
                this.dgInvoiceAddress.CurrentRowIndex = num;
                break;
              }
              checked { ++num; }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        else
          this.dgInvoiceAddress.CurrentRowIndex = 0;
        this.dgInvoiceAddress.Select(this.dgInvoiceAddress.CurrentRowIndex);
      }
    }

    private DataView Assets
    {
      get
      {
        return this._Assets;
      }
      set
      {
        this._Assets = value;
        this._Assets.AllowNew = false;
        this._Assets.AllowEdit = true;
        this._Assets.AllowDelete = false;
        this._Assets.Table.TableName = Enums.TableNames.tblAsset.ToString();
        this.dgAssets.DataSource = (object) this._Assets;
      }
    }

    private int NumOfMonths
    {
      get
      {
        return this._NumOfMonths;
      }
      set
      {
        this._NumOfMonths = value;
      }
    }

    private ArrayList Visits
    {
      get
      {
        return this._Visits;
      }
      set
      {
        this._Visits = value;
      }
    }

    private DataView AssetDurations
    {
      get
      {
        return this._AssetDurations;
      }
      set
      {
        this._AssetDurations = value;
      }
    }

    private DataView PPMSchedule
    {
      get
      {
        return this._PPMSchedule;
      }
      set
      {
        this._PPMSchedule = value;
        this._PPMSchedule.AllowNew = false;
        this._PPMSchedule.AllowEdit = true;
        this._PPMSchedule.AllowDelete = false;
        this._PPMSchedule.Table.TableName = Enums.TableNames.tblContractOption3SitePPMVisit.ToString();
        this.dgPPMVisits.DataSource = (object) this.PPMSchedule;
      }
    }

    private DataView InvoiceAddresses
    {
      get
      {
        return this._InvoiceAddresses;
      }
      set
      {
        this._InvoiceAddresses = value;
        this._InvoiceAddresses.AllowDelete = false;
        this._InvoiceAddresses.AllowEdit = false;
        this._InvoiceAddresses.AllowNew = false;
        this._InvoiceAddresses.Table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
        this.dgInvoiceAddress.DataSource = (object) this.InvoiceAddresses;
      }
    }

    private DataRow SelectedInvoiceAddressesDataRow
    {
      get
      {
        return this.dgInvoiceAddress.CurrentRowIndex != -1 ? this.InvoiceAddresses[this.dgInvoiceAddress.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupAssetsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgAssets, false);
      DataGridTableStyle tableStyle = this.dgAssets.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgAssets.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Product";
      dataGridLabelColumn1.MappingName = "Product";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Location";
      dataGridLabelColumn2.MappingName = "Location";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 90;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Serial Number";
      dataGridLabelColumn3.MappingName = "SerialNum";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 90;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      int int32 = Convert.ToInt32(Math.Ceiling(new Decimal(DateAndTime.DateDiff(DateInterval.Month, this.dtpStartDate.Value, this.dtpEndDate.Value, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))));
      int months = 0;
      while (months <= int32)
      {
        Contract3AssetsColourColumn assetsColourColumn1 = new Contract3AssetsColourColumn();
        Contract3AssetsColourColumn assetsColourColumn2 = assetsColourColumn1;
        DateTime dateTime = this.dtpStartDate.Value;
        string str1 = Strings.Format((object) dateTime.AddMonths(months), "MMM yy");
        assetsColourColumn2.HeaderText = str1;
        Contract3AssetsColourColumn assetsColourColumn3 = assetsColourColumn1;
        dateTime = this.dtpStartDate.Value;
        string str2 = Strings.Format((object) dateTime.AddMonths(months), "MMM yy");
        assetsColourColumn3.MappingName = str2;
        assetsColourColumn1.ReadOnly = false;
        assetsColourColumn1.Width = 50;
        assetsColourColumn1.NullText = "-";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) assetsColourColumn1);
        checked { ++months; }
      }
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblAsset.ToString();
      this.dgAssets.TableStyles.Add(tableStyle);
    }

    public void SetupPPMDataGrid()
    {
      Helper.SetUpDataGrid(this.dgPPMVisits, false);
      DataGridTableStyle tableStyle = this.dgPPMVisits.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Approx. VisitDate";
      dataGridLabelColumn1.MappingName = "VisitDate";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 220;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Job Number";
      dataGridLabelColumn2.MappingName = "JobNumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 220;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Visit Date";
      dataGridLabelColumn3.MappingName = "StartDateTime";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 220;
      dataGridLabelColumn3.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Engineer";
      dataGridLabelColumn4.MappingName = "Name";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 220;
      dataGridLabelColumn4.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblContractOption3SitePPMVisit.ToString();
      this.dgPPMVisits.TableStyles.Add(tableStyle);
    }

    public void SetupInvoiceAddressDataGrid()
    {
      Helper.SetUpDataGrid(this.dgInvoiceAddress, false);
      DataGridTableStyle tableStyle = this.dgInvoiceAddress.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgInvoiceAddress.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Address Type";
      dataGridLabelColumn1.MappingName = "AddressType";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 95;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Address 1";
      dataGridLabelColumn2.MappingName = "Address1";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Address 2";
      dataGridLabelColumn3.MappingName = "Address2";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Address 3";
      dataGridLabelColumn4.MappingName = "Address3";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Address 4";
      dataGridLabelColumn5.MappingName = "Address4";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Address 5";
      dataGridLabelColumn6.MappingName = "Address5";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Postcode";
      dataGridLabelColumn7.MappingName = "Postcode";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.MappingName = Enums.TableNames.tblInvoiceAddress.ToString();
      this.dgInvoiceAddress.TableStyles.Add(tableStyle);
    }

    private void UCContractOption3Site_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
      this.SetupAssetsDataGrid();
      this.SetupPPMDataGrid();
    }

    private void dtpStartDate_ValueChanged(object sender, EventArgs e)
    {
      this.ClearAssetsGrid();
    }

    private void dtpEndDate_ValueChanged(object sender, EventArgs e)
    {
      this.ClearAssetsGrid();
    }

    private void dtpFirstVisitDate_ValueChanged(object sender, EventArgs e)
    {
      this.ClearAssetsGrid();
    }

    private void cboVisitFrequencyID_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ClearAssetsGrid();
    }

    private void btnRefreshGrid_Click(object sender, EventArgs e)
    {
      this.RefreshAssetsGrid();
    }

    private void dgInvoiceAddress_Click(object sender, EventArgs e)
    {
      this.dgInvoiceAddress.Select(this.dgInvoiceAddress.CurrentRowIndex);
    }

    private void ClearAssetsGrid()
    {
      if (this.CurrentContractOption3Site != null)
        this.Assets = App.DB.Asset.Asset_GetForSite(this.CurrentContractOption3Site.PropertyID);
      if (DateTime.Compare(this.dtpFirstVisitDate.Value, this.dtpStartDate.Value) >= 0 & DateTime.Compare(this.dtpFirstVisitDate.Value, this.dtpEndDate.Value) <= 0)
        this.lblWarning.Visible = false;
      else
        this.lblWarning.Visible = true;
    }

    private void RefreshAssetsGrid()
    {
      this.Cursor = Cursors.WaitCursor;
      DateTime minValue = DateTime.MinValue;
      int num1 = 0;
      if (this.CurrentContractOption3Site != null)
      {
        if (this.Assets != null)
        {
          this.NumOfMonths = Convert.ToInt32(Math.Ceiling(new Decimal(DateAndTime.DateDiff(DateInterval.Month, this.dtpStartDate.Value, this.dtpEndDate.Value, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))));
          this.ClearAssetsGrid();
          this.Visits = new ArrayList();
          int numOfMonths = this.NumOfMonths;
          int months1 = 0;
          DateTime dateTime1;
          while (months1 <= numOfMonths)
          {
            DataColumnCollection columns = this.Assets.Table.Columns;
            dateTime1 = this.dtpStartDate.Value;
            string columnName = Strings.Format((object) dateTime1.AddMonths(months1), "MMM yy");
            columns.Add(columnName);
            checked { ++months1; }
          }
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVisitFrequencyID)) > 0.0)
          {
            dateTime1 = this.dtpFirstVisitDate.Value;
            DateTime date1 = dateTime1.Date;
            dateTime1 = this.dtpStartDate.Value;
            DateTime date2 = dateTime1.Date;
            int num2 = DateTime.Compare(date1, date2) >= 0 ? 1 : 0;
            dateTime1 = this.dtpFirstVisitDate.Value;
            DateTime date3 = dateTime1.Date;
            dateTime1 = this.dtpEndDate.Value;
            DateTime date4 = dateTime1.Date;
            int num3 = DateTime.Compare(date3, date4) <= 0 ? 1 : 0;
            if ((num2 & num3) != 0)
            {
              this.lblWarning.Visible = false;
              num1 = 0;
              int months2 = 0;
              switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboVisitFrequencyID)))
              {
                case 4:
                  months2 = 1;
                  break;
                case 5:
                  months2 = 3;
                  break;
                case 6:
                  months2 = 6;
                  break;
                case 7:
                  months2 = 12;
                  break;
              }
              int num4 = checked ((int) Math.Ceiling(unchecked ((double) DateAndTime.DateDiff(DateInterval.Month, this.dtpStartDate.Value, this.dtpEndDate.Value, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / (double) months2)));
              if (num4 == 0)
                num4 = 1;
              dateTime1 = this.dtpFirstVisitDate.Value;
              DateTime dateTime2 = Conversions.ToDate(Conversions.ToString(dateTime1.Date) + " 09:00:00");
              int num5 = num4;
              int num6 = 1;
              while (num6 <= num5)
              {
                DateTime t1_1 = dateTime2;
                dateTime1 = this.dtpStartDate.Value;
                DateTime date5 = Conversions.ToDate(Strings.Format((object) dateTime1.Date, "dd/MM/yyyy") + " 09:00");
                int num7 = DateTime.Compare(t1_1, date5) >= 0 ? 1 : 0;
                DateTime t1_2 = dateTime2;
                dateTime1 = this.dtpEndDate.Value;
                DateTime date6 = Conversions.ToDate(Strings.Format((object) dateTime1.Date, "dd/MM/yyyy") + " 09:00");
                int num8 = DateTime.Compare(t1_2, date6) <= 0 ? 1 : 0;
                if ((num7 & num8) != 0)
                {
                  DateTime dateTime3 = dateTime2;
                  if (dateTime2.DayOfWeek == DayOfWeek.Saturday)
                    dateTime2 = dateTime2.AddDays(2.0);
                  else if (dateTime2.DayOfWeek == DayOfWeek.Sunday)
                    dateTime2 = dateTime2.AddDays(1.0);
                  IEnumerator enumerator;
                  try
                  {
                    enumerator = this.Assets.Table.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                      DataRow current = (DataRow) enumerator.Current;
                      DataRow[] dataRowArray = this.AssetDurations.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("CompareMonth=" + Strings.Format((object) dateTime2, "yyyyMM") + " AND AssetID="), current["AssetID"])));
                      if (dataRowArray.Length > 0)
                        current[Strings.Format((object) dateTime2, "MMM yy")] = RuntimeHelpers.GetObjectValue(dataRowArray[0]["VisitDuration"]);
                      else
                        current[Strings.Format((object) dateTime2, "MMM yy")] = (object) "0";
                    }
                  }
                  finally
                  {
                    if (enumerator is IDisposable)
                      (enumerator as IDisposable).Dispose();
                  }
                  this.Visits.Add((object) dateTime2);
                  dateTime2 = dateTime3.AddMonths(months2);
                }
                checked { ++num6; }
              }
            }
            else
              this.lblWarning.Visible = true;
          }
        }
        this.SetupAssetsDataGrid();
      }
      this.Cursor = Cursors.Default;
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentContractOption3Site = App.DB.ContractOption3Site.ContractOption3Site_Get(ID);
      this.AssetDurations = App.DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_GetAll_ForContractSiteID(this.CurrentContractOption3Site.ContractSiteID);
      this.txtContractSiteReference.Text = this.CurrentContractOption3Site.ContractSiteReference;
      try
      {
        this.dtpStartDate.Value = this.CurrentContractOption3Site.StartDate;
        this.dtpEndDate.Value = this.CurrentContractOption3Site.EndDate;
        this.dtpFirstVisitDate.Value = this.CurrentContractOption3Site.FirstVisitDate;
        this.dtpFirstInvoiceDate.Value = this.CurrentContractOption3Site.FirstInvoiceDate;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.dtpStartDate.Value = DateAndTime.Now;
        DateTimePicker dtpEndDate = this.dtpEndDate;
        DateTime dateTime1 = DateAndTime.Now;
        dateTime1 = dateTime1.AddYears(1);
        DateTime dateTime2 = dateTime1.AddDays(-1.0);
        dtpEndDate.Value = dateTime2;
        this.dtpFirstVisitDate.Value = DateAndTime.Now;
        this.dtpFirstInvoiceDate.Value = DateAndTime.Now;
        ProjectData.ClearProjectError();
      }
      ComboBox combo = this.cboVisitFrequencyID;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentContractOption3Site.VisitFrequencyID));
      this.cboVisitFrequencyID = combo;
      combo = this.cboInvoiceFrequencyID;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentContractOption3Site.InvoiceFrequencyID));
      this.cboInvoiceFrequencyID = combo;
      this.txtSitePrice.Text = Strings.Format((object) this.CurrentContractOption3Site.SitePrice, "C");
      this.Assets = App.DB.Asset.Asset_GetForSite(this.CurrentContractOption3Site.PropertyID);
      this.AssetDurations = App.DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_GetAll_ForContractSiteID(this.CurrentContractOption3Site.ContractSiteID);
      this.RefreshAssetsGrid();
      if (this.AssetDurations.Table.Rows.Count <= 0)
        return;
      this.dtpStartDate.Enabled = false;
      this.dtpEndDate.Enabled = false;
      this.dtpFirstVisitDate.Enabled = false;
      this.cboVisitFrequencyID.Enabled = false;
      this.btnRefreshGrid.Enabled = false;
      this.dgAssets.Enabled = false;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentContractOption3Site.IgnoreExceptionsOnSetMethods = true;
        this.CurrentContractOption3Site.SetContractSiteReference = (object) this.txtContractSiteReference.Text.Trim();
        this.CurrentContractOption3Site.StartDate = this.dtpStartDate.Value;
        this.CurrentContractOption3Site.EndDate = this.dtpEndDate.Value;
        this.CurrentContractOption3Site.FirstVisitDate = this.dtpFirstVisitDate.Value;
        this.CurrentContractOption3Site.SetVisitFrequencyID = (object) Combo.get_GetSelectedItemValue(this.cboVisitFrequencyID);
        this.CurrentContractOption3Site.SetInvoiceFrequencyID = (object) Combo.get_GetSelectedItemValue(this.cboInvoiceFrequencyID);
        this.CurrentContractOption3Site.SetSitePrice = (object) this.txtSitePrice.Text.Trim().Replace("£", "");
        this.CurrentContractOption3Site.FirstInvoiceDate = this.dtpFirstInvoiceDate.Value;
        if (this.SelectedInvoiceAddressesDataRow != null)
        {
          this.CurrentContractOption3Site.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressID"]);
          this.CurrentContractOption3Site.SetInvoiceAddressTypeID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressTypeID"]);
        }
        new ContractOption3SiteValidator().Validate(this.CurrentContractOption3Site, this.Assets);
        if (this.CurrentContractOption3Site.Exists)
        {
          App.DB.ContractOption3Site.Update(this.CurrentContractOption3Site);
          if (this.PPMSchedule.Table.Rows.Count == 0 && App.ShowMessage("Visit will now be scheduled - are you sure you want to save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            App.DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_Delete(this.CurrentContractOption3Site.ContractSiteID);
            IEnumerator enumerator;
            try
            {
              enumerator = this.Visits.GetEnumerator();
              while (enumerator.MoveNext())
              {
                object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
                Job job1 = new Job();
                Job job2 = this.CreateJob(Conversions.ToDate(objectValue));
                App.DB.ContractOption3SitePPMVisit.Insert(new ContractOption3SitePPMVisit()
                {
                  SetContractSiteID = (object) this.CurrentContractOption3Site.ContractSiteID,
                  VisitDate = Conversions.ToDate(objectValue),
                  SetJobID = (object) job2.JobID
                });
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
          }
        }
        else
          this.CurrentContractOption3Site = App.DB.ContractOption3Site.Insert(this.CurrentContractOption3Site);
        if (!this.InvoiceInserted)
          this.InsertInvoiceToBeRaiseLines();
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentContractOption3Site.ContractSiteID);
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

    private Job CreateJob(DateTime vDate)
    {
      double num1 = 0.0;
      DateTime minValue1 = DateTime.MinValue;
      DateTime minValue2 = DateTime.MinValue;
      Job oJob = new Job();
      oJob.SetContractID = (object) this.CurrentContractOption3Site.ContractID;
      oJob.SetCreatedByUserID = (object) App.loggedInUser.UserID;
      oJob.SetJobDefinitionEnumID = (object) Helper.MakeIntegerValid((object) Enums.JobDefinition.Contract);
      JobNumber jobNumber = new JobNumber();
      JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
      oJob.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
      oJob.SetPONumber = (object) "";
      oJob.SetQuoteID = (object) 0;
      oJob.SetJobTypeID = RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Service'")[0]["ManagerID"]);
      oJob.SetPropertyID = (object) this.CurrentContractOption3Site.PropertyID;
      oJob.SetStatusEnumID = (object) Helper.MakeIntegerValid((object) Enums.JobStatus.Open);
      oJob.DateCreated = DateAndTime.Now;
      oJob.SetFOC = (object) true;
      ContractOption3 contractOption3_1 = new ContractOption3();
      ContractOption3 contractOption3_2 = App.DB.ContractOption3.ContractOption3_Get(this.CurrentContractOption3Site.ContractID);
      if (contractOption3_2.ContractStatusID == 4)
        oJob.SetDeleted = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this.Assets.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current[Strings.Format((object) vDate, "MMM yy")], (object) 0, false))
          {
            App.DB.ContractOption3SiteAsset.Insert(new FSM.Entity.ContractOption3SiteAsset.ContractOption3SiteAsset()
            {
              SetContractSiteID = (object) this.CurrentContractOption3Site.ContractSiteID,
              SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"]),
              ScheduledMonth = vDate,
              SetVisitDuration = RuntimeHelpers.GetObjectValue(current[Strings.Format((object) vDate, "MMM yy")])
            });
            oJob.Assets.Add((object) new JobAsset()
            {
              SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"])
            });
            num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current[Strings.Format((object) vDate, "MMM yy")]));
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      JobOfWork jobOfWork = new JobOfWork();
      jobOfWork.IgnoreExceptionsOnSetMethods = true;
      jobOfWork.SetPONumber = (object) "";
      if (contractOption3_2.ContractStatusID == 4)
        jobOfWork.SetDeleted = true;
      jobOfWork.JobItems.Add((object) new JobItem()
      {
        IgnoreExceptionsOnSetMethods = true,
        SetSummary = (object) Helper.MakeStringValid((object) "PPM Contract Visit")
      });
      Settings settings1 = new Settings();
      Settings settings2 = App.DB.Manager.Get();
      double timeSlot = (double) settings2.TimeSlot;
      int num2 = checked ((int) Math.Ceiling(unchecked (num1 <= 0.0 ? 1.0 : (double) checked ((int) Math.Round(unchecked ((double) checked ((int) Math.Round(unchecked (num1 * 60.0))) / timeSlot))) / (double) checked ((int) Math.Round(unchecked ((double) DateAndTime.DateDiff(DateInterval.Minute, Helper.MakeDateTimeValid((object) ("01/01/1900 " + settings2.WorkingHoursStart)), Helper.MakeDateTimeValid((object) ("01/01/1900 " + settings2.WorkingHoursEnd)), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / timeSlot))))) - 1);
      int num3 = 0;
      while (num3 <= num2)
      {
        jobOfWork.EngineerVisits.Add((object) new EngineerVisit()
        {
          IgnoreExceptionsOnSetMethods = true,
          SetEngineerID = (object) 0,
          SetNotesToEngineer = (object) "PPM Contract Visit",
          StartDateTime = DateTime.MinValue,
          EndDateTime = DateTime.MinValue,
          SetStatusEnumID = (object) 4
        });
        checked { ++num3; }
      }
      oJob.JobOfWorks.Add((object) jobOfWork);
      return App.DB.Job.Insert(oJob);
    }

    private ArrayList GetEngineersAndVisits(
      int numOfDaysNeeded,
      int numOfSlotsInADay,
      DateTime estVisitDate)
    {
      FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
      ArrayList arrayList1 = new ArrayList();
      FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) this.CurrentContractOption3Site.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
      if (site2.EngineerID > 0)
        arrayList1 = this.CheckAvailability(estVisitDate, site2.EngineerID, numOfDaysNeeded, numOfSlotsInADay);
      ArrayList arrayList2;
      if (arrayList1.Count > 0)
      {
        arrayList2 = arrayList1;
      }
      else
      {
        string str = site2.Postcode.Replace("-", "").Replace(" ", "");
        string Postcode = str.Substring(0, checked (str.Length - 3));
        DataView forPostcode = App.DB.EngineerPostalRegion.EngineerPostalRegion_Get_For_Postcode(Postcode);
        int count = forPostcode.Table.Rows.Count;
        if (count > 0)
        {
          int num1 = checked (count - 1);
          int num2 = 0;
          while (num2 <= num1)
          {
            VBMath.Randomize();
            int index = checked ((int) Conversion.Int((float) unchecked ((double) forPostcode.Table.Rows.Count * (double) VBMath.Rnd() + 1.0)) - 1);
            ArrayList arrayList3 = this.CheckAvailability(estVisitDate, Conversions.ToInteger(forPostcode.Table.Rows[index]["EngineerID"]), numOfDaysNeeded, numOfSlotsInADay);
            if (arrayList3.Count > 0)
            {
              arrayList2 = arrayList3;
              goto label_11;
            }
            else
            {
              forPostcode.Table.Rows.Remove(forPostcode.Table.Rows[index]);
              checked { ++num2; }
            }
          }
        }
      }
label_11:
      return arrayList2;
    }

    private ArrayList CheckAvailability(
      DateTime estimatedVisitDate,
      int engineerID,
      int numOfDaysNeeded,
      int numOfSlotsInADay)
    {
      ArrayList arrayList1 = new ArrayList();
      DateTime day = estimatedVisitDate;
      ArrayList arrayList2 = new ArrayList();
      int num1 = 0;
      do
      {
        arrayList2.Clear();
        int num2 = 0;
        if ((uint) num1 > 0U)
          day = estimatedVisitDate.AddDays(1.0);
        int num3 = numOfDaysNeeded;
        int num4 = 1;
        while (num4 <= num3)
        {
          arrayList1.Clear();
          if (num4 != 1)
            day = day.AddDays(1.0);
          if (day.DayOfWeek == DayOfWeek.Saturday)
            day = day.AddDays(2.0);
          if (day.DayOfWeek == DayOfWeek.Saturday)
            day = day.AddDays(1.0);
          DataTable dataTable = App.DB.Scheduler.Scheduler_DayTimeSlots(day, Conversions.ToString(engineerID));
          if (dataTable.Rows.Count > 0)
          {
            int num5 = checked (dataTable.Columns.Count - 1);
            int index = 0;
            while (index <= num5)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataTable.Rows[0][index], (object) 0, false))
              {
                arrayList1.Add((object) dataTable.Columns[index].ColumnName);
                if (arrayList1.Count == numOfSlotsInADay)
                  break;
              }
              else
                arrayList1.Clear();
              checked { ++index; }
            }
          }
          else
            arrayList1.Add((object) App.DB.Manager.Get().WorkingHoursStart);
          if (arrayList1.Count > 0)
          {
            ArrayList arrayList3 = new ArrayList();
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (arrayList1.Count == numOfSlotsInADay), Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(arrayList1[0], (object) App.DB.Manager.Get().WorkingHoursStart, false), (object) (arrayList1.Count == 1)))))
            {
              string str = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(arrayList1[0], (object) App.DB.Manager.Get().WorkingHoursStart, false) ? Strings.Replace(Conversions.ToString(arrayList1[0]), "T", "", 1, -1, CompareMethod.Binary).Insert(2, ":") : Conversions.ToString(arrayList1[0]);
              day = Conversions.ToDate(Strings.Format((object) day, "dd/MM/yyyy") + " " + str);
              arrayList3.Add((object) day);
              arrayList3.Add((object) engineerID);
              arrayList2.Add((object) arrayList3);
              checked { ++num2; }
            }
            else
            {
              arrayList3.Add((object) null);
              arrayList3.Add((object) 0);
              arrayList2.Add((object) arrayList3);
            }
          }
          if (num2 == num4)
            checked { ++num4; }
          else
            break;
        }
        if (num2 == numOfDaysNeeded)
          return arrayList2;
        checked { ++num1; }
      }
      while (num1 <= 4);
      return arrayList2;
    }

    private void InsertInvoiceToBeRaiseLines()
    {
      int num1 = 0;
      switch (this.CurrentContractOption3Site.InvoiceFrequencyID)
      {
        case 1:
          num1 = checked ((int) Math.Round(unchecked ((double) DateAndTime.DateDiff(DateInterval.Day, this.CurrentContractOption3Site.StartDate, this.CurrentContractOption3Site.EndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 7.0)));
          break;
        case 2:
          num1 = checked ((int) DateAndTime.DateDiff(DateInterval.Month, this.CurrentContractOption3Site.StartDate, this.CurrentContractOption3Site.EndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          break;
        case 3:
          num1 = checked ((int) Math.Round(unchecked ((double) DateAndTime.DateDiff(DateInterval.Month, this.CurrentContractOption3Site.StartDate, this.CurrentContractOption3Site.EndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 3.0)));
          break;
        case 4:
          num1 = checked ((int) (DateAndTime.DateDiff(DateInterval.Year, this.CurrentContractOption3Site.StartDate, this.CurrentContractOption3Site.EndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) * 2L));
          break;
        case 6:
          num1 = checked ((int) DateAndTime.DateDiff(DateInterval.Year, this.CurrentContractOption3Site.StartDate, this.CurrentContractOption3Site.EndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          break;
      }
      DateTime dateTime = this.CurrentContractOption3Site.FirstInvoiceDate;
      int num2 = num1;
      int num3 = 1;
      while (num3 <= num2)
      {
        App.DB.InvoiceToBeRaised.Insert(new InvoiceToBeRaised()
        {
          SetAddressLinkID = (object) this.CurrentContractOption3Site.InvoiceAddressID,
          SetAddressTypeID = (object) this.CurrentContractOption3Site.InvoiceAddressTypeID,
          SetInvoiceTypeID = (object) 330,
          SetLinkID = (object) this.CurrentContractOption3Site.ContractSiteID,
          RaiseDate = dateTime
        });
        switch (this.CurrentContractOption3Site.InvoiceFrequencyID)
        {
          case 1:
            dateTime = dateTime.AddDays(7.0);
            break;
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
            dateTime = dateTime.AddYears(1);
            break;
        }
        checked { ++num3; }
      }
    }
  }
}
