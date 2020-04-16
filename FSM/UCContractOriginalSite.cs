// Decompiled with JetBrains decompiler
// Type: FSM.UCContractOriginalSite
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractOriginalPPMVisits;
using FSM.Entity.ContractOriginalSiteAssets;
using FSM.Entity.ContractOriginalSiteRatess;
using FSM.Entity.ContractOriginalSites;
using FSM.Entity.ContractOriginalVisits;
using FSM.Entity.ContractsOriginal;
using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.EngineerVisits;
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
using System.Windows.Forms;

namespace FSM
{
  public class UCContractOriginalSite : UCBase, IUserControl
  {
    private IContainer components;
    private ContractOriginalSite _OldContractSite;
    private ContractOriginalSite _currentContractSite;
    private int _SiteID;
    private FSM.Entity.Sites.Site _site;
    private ContractOriginal _CurrentContract;
    private DataView _Assets;
    private DataView _SystemRates;
    private DataView _Visits;
    private DataView _Visits2;

    public UCContractOriginalSite()
    {
      this.Load += new EventHandler(this.UCContractSite_Load);
      this._SiteID = 0;
      this.InitializeComponent();
      this.SetupAssetsDataGrid();
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

    internal virtual GroupBox grpContractSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFirstVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFirstVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVisitFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAssets
    {
      get
      {
        return this._dgAssets;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgAssets_MouseUp);
        DataGrid dgAssets1 = this._dgAssets;
        if (dgAssets1 != null)
          dgAssets1.MouseUp -= mouseEventHandler;
        this._dgAssets = value;
        DataGrid dgAssets2 = this._dgAssets;
        if (dgAssets2 == null)
          return;
        dgAssets2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual GroupBox grpVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpScheduleOfRates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSiteScheduleOfRates
    {
      get
      {
        return this._btnSiteScheduleOfRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSiteScheduleOfRates_Click);
        Button siteScheduleOfRates1 = this._btnSiteScheduleOfRates;
        if (siteScheduleOfRates1 != null)
          siteScheduleOfRates1.Click -= eventHandler;
        this._btnSiteScheduleOfRates = value;
        Button siteScheduleOfRates2 = this._btnSiteScheduleOfRates;
        if (siteScheduleOfRates2 == null)
          return;
        siteScheduleOfRates2.Click += eventHandler;
      }
    }

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

    internal virtual DataGrid dgSystemRates
    {
      get
      {
        return this._dgSystemRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgSystemRates_MouseUp);
        DataGrid dgSystemRates1 = this._dgSystemRates;
        if (dgSystemRates1 != null)
          dgSystemRates1.MouseUp -= mouseEventHandler;
        this._dgSystemRates = value;
        DataGrid dgSystemRates2 = this._dgSystemRates;
        if (dgSystemRates2 == null)
          return;
        dgSystemRates2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkLLCertificateReqd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAdditionalNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVisitDuration { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkCommercial { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddVisit
    {
      get
      {
        return this._btnAddVisit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddVisit_Click);
        Button btnAddVisit1 = this._btnAddVisit;
        if (btnAddVisit1 != null)
          btnAddVisit1.Click -= eventHandler;
        this._btnAddVisit = value;
        Button btnAddVisit2 = this._btnAddVisit;
        if (btnAddVisit2 == null)
          return;
        btnAddVisit2.Click += eventHandler;
      }
    }

    internal virtual Button btRemoveVisit
    {
      get
      {
        return this._btRemoveVisit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btRemoveVisit_Click);
        Button btRemoveVisit1 = this._btRemoveVisit;
        if (btRemoveVisit1 != null)
          btRemoveVisit1.Click -= eventHandler;
        this._btRemoveVisit = value;
        Button btRemoveVisit2 = this._btRemoveVisit;
        if (btRemoveVisit2 == null)
          return;
        btRemoveVisit2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgVisitsSetup
    {
      get
      {
        return this._dgVisitsSetup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgVisits2_DoubleClick);
        DataGrid dgVisitsSetup1 = this._dgVisitsSetup;
        if (dgVisitsSetup1 != null)
          dgVisitsSetup1.DoubleClick -= eventHandler;
        this._dgVisitsSetup = value;
        DataGrid dgVisitsSetup2 = this._dgVisitsSetup;
        if (dgVisitsSetup2 == null)
          return;
        dgVisitsSetup2.DoubleClick += eventHandler;
      }
    }

    internal virtual DataGrid dgScheduleOfRates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpContractSite = new GroupBox();
      this.GroupBox1 = new GroupBox();
      this.btnAddVisit = new Button();
      this.btRemoveVisit = new Button();
      this.dgVisitsSetup = new DataGrid();
      this.chkCommercial = new CheckBox();
      this.txtVisitDuration = new TextBox();
      this.txtAdditionalNotes = new TextBox();
      this.Label2 = new Label();
      this.chkLLCertificateReqd = new CheckBox();
      this.grpScheduleOfRates = new GroupBox();
      this.dgSystemRates = new DataGrid();
      this.btnSiteScheduleOfRates = new Button();
      this.btnRemove = new Button();
      this.dgScheduleOfRates = new DataGrid();
      this.Label1 = new Label();
      this.grpAssets = new GroupBox();
      this.dgAssets = new DataGrid();
      this.txtSite = new TextBox();
      this.dtpFirstVisitDate = new DateTimePicker();
      this.lblFirstVisitDate = new Label();
      this.cboVisitFrequencyID = new ComboBox();
      this.lblVisitFrequencyID = new Label();
      this.lblSite = new Label();
      this.grpVisits = new GroupBox();
      this.dgVisits = new DataGrid();
      this.grpContractSite.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.dgVisitsSetup.BeginInit();
      this.grpScheduleOfRates.SuspendLayout();
      this.dgSystemRates.BeginInit();
      this.dgScheduleOfRates.BeginInit();
      this.grpAssets.SuspendLayout();
      this.dgAssets.BeginInit();
      this.grpVisits.SuspendLayout();
      this.dgVisits.BeginInit();
      this.SuspendLayout();
      this.grpContractSite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContractSite.Controls.Add((Control) this.GroupBox1);
      this.grpContractSite.Controls.Add((Control) this.chkCommercial);
      this.grpContractSite.Controls.Add((Control) this.txtVisitDuration);
      this.grpContractSite.Controls.Add((Control) this.txtAdditionalNotes);
      this.grpContractSite.Controls.Add((Control) this.Label2);
      this.grpContractSite.Controls.Add((Control) this.chkLLCertificateReqd);
      this.grpContractSite.Controls.Add((Control) this.grpScheduleOfRates);
      this.grpContractSite.Controls.Add((Control) this.Label1);
      this.grpContractSite.Controls.Add((Control) this.grpAssets);
      this.grpContractSite.Controls.Add((Control) this.txtSite);
      this.grpContractSite.Controls.Add((Control) this.dtpFirstVisitDate);
      this.grpContractSite.Controls.Add((Control) this.lblFirstVisitDate);
      this.grpContractSite.Controls.Add((Control) this.cboVisitFrequencyID);
      this.grpContractSite.Controls.Add((Control) this.lblVisitFrequencyID);
      this.grpContractSite.Controls.Add((Control) this.lblSite);
      this.grpContractSite.Controls.Add((Control) this.grpVisits);
      this.grpContractSite.Location = new System.Drawing.Point(5, 6);
      this.grpContractSite.Name = "grpContractSite";
      this.grpContractSite.Size = new Size(931, 600);
      this.grpContractSite.TabIndex = 0;
      this.grpContractSite.TabStop = false;
      this.grpContractSite.Text = "Main Details";
      this.GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.GroupBox1.Controls.Add((Control) this.btnAddVisit);
      this.GroupBox1.Controls.Add((Control) this.btRemoveVisit);
      this.GroupBox1.Controls.Add((Control) this.dgVisitsSetup);
      this.GroupBox1.Location = new System.Drawing.Point(13, 264);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(912, 164);
      this.GroupBox1.TabIndex = 15;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Commercial Contract Visits Setup";
      this.btnAddVisit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddVisit.Location = new System.Drawing.Point(10, 129);
      this.btnAddVisit.Name = "btnAddVisit";
      this.btnAddVisit.Size = new Size(89, 23);
      this.btnAddVisit.TabIndex = 4;
      this.btnAddVisit.Text = "Add";
      this.btRemoveVisit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btRemoveVisit.Location = new System.Drawing.Point(802, 129);
      this.btRemoveVisit.Name = "btRemoveVisit";
      this.btRemoveVisit.Size = new Size(101, 23);
      this.btRemoveVisit.TabIndex = 5;
      this.btRemoveVisit.Text = "Remove";
      this.dgVisitsSetup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgVisitsSetup.DataMember = "";
      this.dgVisitsSetup.HeaderForeColor = SystemColors.ControlText;
      this.dgVisitsSetup.Location = new System.Drawing.Point(10, 21);
      this.dgVisitsSetup.Name = "dgVisitsSetup";
      this.dgVisitsSetup.Size = new Size(892, 102);
      this.dgVisitsSetup.TabIndex = 0;
      this.chkCommercial.AutoSize = true;
      this.chkCommercial.Location = new System.Drawing.Point(161, 86);
      this.chkCommercial.Name = "chkCommercial";
      this.chkCommercial.RightToLeft = RightToLeft.Yes;
      this.chkCommercial.Size = new Size(95, 17);
      this.chkCommercial.TabIndex = 7;
      this.chkCommercial.Text = "Commercial";
      this.chkCommercial.UseVisualStyleBackColor = true;
      this.txtVisitDuration.Location = new System.Drawing.Point(407, 88);
      this.txtVisitDuration.Name = "txtVisitDuration";
      this.txtVisitDuration.Size = new Size(136, 21);
      this.txtVisitDuration.TabIndex = 9;
      this.txtAdditionalNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAdditionalNotes.Location = new System.Drawing.Point(656, 56);
      this.txtAdditionalNotes.Multiline = true;
      this.txtAdditionalNotes.Name = "txtAdditionalNotes";
      this.txtAdditionalNotes.ScrollBars = ScrollBars.Vertical;
      this.txtAdditionalNotes.Size = new Size(265, 53);
      this.txtAdditionalNotes.TabIndex = 11;
      this.Label2.Location = new System.Drawing.Point(549, 72);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(112, 20);
      this.Label2.TabIndex = 10;
      this.Label2.Text = "Additional Notes";
      this.chkLLCertificateReqd.AutoSize = true;
      this.chkLLCertificateReqd.CheckAlign = ContentAlignment.MiddleRight;
      this.chkLLCertificateReqd.Location = new System.Drawing.Point(16, 86);
      this.chkLLCertificateReqd.Name = "chkLLCertificateReqd";
      this.chkLLCertificateReqd.Size = new Size(139, 17);
      this.chkLLCertificateReqd.TabIndex = 6;
      this.chkLLCertificateReqd.Text = "L/L Certificate Reqd";
      this.chkLLCertificateReqd.UseVisualStyleBackColor = true;
      this.grpScheduleOfRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpScheduleOfRates.Controls.Add((Control) this.dgSystemRates);
      this.grpScheduleOfRates.Controls.Add((Control) this.btnSiteScheduleOfRates);
      this.grpScheduleOfRates.Controls.Add((Control) this.btnRemove);
      this.grpScheduleOfRates.Controls.Add((Control) this.dgScheduleOfRates);
      this.grpScheduleOfRates.Location = new System.Drawing.Point(13, 109);
      this.grpScheduleOfRates.Name = "grpScheduleOfRates";
      this.grpScheduleOfRates.Size = new Size(912, 155);
      this.grpScheduleOfRates.TabIndex = 12;
      this.grpScheduleOfRates.TabStop = false;
      this.grpScheduleOfRates.Text = "Contract Schedule Of Rates";
      this.dgSystemRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSystemRates.DataMember = "";
      this.dgSystemRates.HeaderForeColor = SystemColors.ControlText;
      this.dgSystemRates.Location = new System.Drawing.Point(11, 19);
      this.dgSystemRates.Name = "dgSystemRates";
      this.dgSystemRates.Size = new Size(432, 106);
      this.dgSystemRates.TabIndex = 0;
      this.btnSiteScheduleOfRates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSiteScheduleOfRates.Location = new System.Drawing.Point(449, 126);
      this.btnSiteScheduleOfRates.Name = "btnSiteScheduleOfRates";
      this.btnSiteScheduleOfRates.Size = new Size(89, 23);
      this.btnSiteScheduleOfRates.TabIndex = 2;
      this.btnSiteScheduleOfRates.Text = "Add";
      this.btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemove.Location = new System.Drawing.Point(802, 126);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new Size(101, 23);
      this.btnRemove.TabIndex = 3;
      this.btnRemove.Text = "Remove";
      this.dgScheduleOfRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.dgScheduleOfRates.DataMember = "";
      this.dgScheduleOfRates.HeaderForeColor = SystemColors.ControlText;
      this.dgScheduleOfRates.Location = new System.Drawing.Point(449, 19);
      this.dgScheduleOfRates.Name = "dgScheduleOfRates";
      this.dgScheduleOfRates.Size = new Size(454, 106);
      this.dgScheduleOfRates.TabIndex = 1;
      this.Label1.Location = new System.Drawing.Point(307, 88);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(89, 20);
      this.Label1.TabIndex = 8;
      this.Label1.Text = "Visit Duration";
      this.grpAssets.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpAssets.Controls.Add((Control) this.dgAssets);
      this.grpAssets.Location = new System.Drawing.Point(14, 434);
      this.grpAssets.Name = "grpAssets";
      this.grpAssets.Size = new Size(442, 156);
      this.grpAssets.TabIndex = 13;
      this.grpAssets.TabStop = false;
      this.grpAssets.Text = "Appliances";
      this.dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAssets.DataMember = "";
      this.dgAssets.HeaderForeColor = SystemColors.ControlText;
      this.dgAssets.Location = new System.Drawing.Point(10, 21);
      this.dgAssets.Name = "dgAssets";
      this.dgAssets.Size = new Size(423, 130);
      this.dgAssets.TabIndex = 0;
      this.txtSite.Location = new System.Drawing.Point(78, 19);
      this.txtSite.Multiline = true;
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.ScrollBars = ScrollBars.Vertical;
      this.txtSite.Size = new Size(843, 31);
      this.txtSite.TabIndex = 1;
      this.dtpFirstVisitDate.Location = new System.Drawing.Point(139, 57);
      this.dtpFirstVisitDate.Name = "dtpFirstVisitDate";
      this.dtpFirstVisitDate.Size = new Size(162, 21);
      this.dtpFirstVisitDate.TabIndex = 3;
      this.dtpFirstVisitDate.Tag = (object) "ContractSite.FirstVisitDate";
      this.lblFirstVisitDate.Location = new System.Drawing.Point(18, 58);
      this.lblFirstVisitDate.Name = "lblFirstVisitDate";
      this.lblFirstVisitDate.Size = new Size(89, 20);
      this.lblFirstVisitDate.TabIndex = 2;
      this.lblFirstVisitDate.Text = "First Visit Date";
      this.cboVisitFrequencyID.Cursor = Cursors.Hand;
      this.cboVisitFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVisitFrequencyID.Location = new System.Drawing.Point(407, 58);
      this.cboVisitFrequencyID.Name = "cboVisitFrequencyID";
      this.cboVisitFrequencyID.Size = new Size(136, 21);
      this.cboVisitFrequencyID.TabIndex = 5;
      this.cboVisitFrequencyID.Tag = (object) "ContractSite.VisitFrequencyID";
      this.lblVisitFrequencyID.Location = new System.Drawing.Point(307, 57);
      this.lblVisitFrequencyID.Name = "lblVisitFrequencyID";
      this.lblVisitFrequencyID.Size = new Size(94, 20);
      this.lblVisitFrequencyID.TabIndex = 4;
      this.lblVisitFrequencyID.Text = "Visit Frequency";
      this.lblSite.Location = new System.Drawing.Point(13, 19);
      this.lblSite.Name = "lblSite";
      this.lblSite.Size = new Size(64, 20);
      this.lblSite.TabIndex = 0;
      this.lblSite.Text = "Property";
      this.grpVisits.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVisits.Controls.Add((Control) this.dgVisits);
      this.grpVisits.Location = new System.Drawing.Point(462, 434);
      this.grpVisits.Name = "grpVisits";
      this.grpVisits.Size = new Size(465, 157);
      this.grpVisits.TabIndex = 14;
      this.grpVisits.TabStop = false;
      this.grpVisits.Text = "Visits Created";
      this.dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgVisits.DataMember = "";
      this.dgVisits.HeaderForeColor = SystemColors.ControlText;
      this.dgVisits.Location = new System.Drawing.Point(10, 21);
      this.dgVisits.Name = "dgVisits";
      this.dgVisits.Size = new Size(446, 131);
      this.dgVisits.TabIndex = 0;
      this.Controls.Add((Control) this.grpContractSite);
      this.Name = nameof (UCContractOriginalSite);
      this.Size = new Size(941, 616);
      this.grpContractSite.ResumeLayout(false);
      this.grpContractSite.PerformLayout();
      this.GroupBox1.ResumeLayout(false);
      this.dgVisitsSetup.EndInit();
      this.grpScheduleOfRates.ResumeLayout(false);
      this.dgSystemRates.EndInit();
      this.dgScheduleOfRates.EndInit();
      this.grpAssets.ResumeLayout(false);
      this.dgAssets.EndInit();
      this.grpVisits.ResumeLayout(false);
      this.dgVisits.EndInit();
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
        return (object) this.CurrentContractSite;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public ContractOriginalSite OldContractSite
    {
      get
      {
        return this._OldContractSite;
      }
      set
      {
        this._OldContractSite = value;
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
        this.SetupSystemRatesDataGrid();
        this.SystemRates = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll_WithoutDefaults();
        if (this._currentContractSite == null)
        {
          this._currentContractSite = new ContractOriginalSite();
          this._currentContractSite.Exists = false;
        }
        if (this._currentContractSite.Exists)
        {
          this.Populate(0);
          this.dtpFirstVisitDate.Enabled = false;
          this.cboVisitFrequencyID.Enabled = false;
          this.txtVisitDuration.Enabled = false;
          this.Visits = App.DB.ContractOriginalPPMVisit.GetAll_For_ContractSiteID(this._currentContractSite.ContractSiteID);
        }
        else if (this.OldContractSite == null)
        {
          this._currentContractSite.ContractSiteScheduleOfRates = this.BuildUpScheduleOfRatesDataview();
          this.dtpFirstVisitDate.Value = this.CurrentContract.ContractStartDate;
        }
        else
        {
          this._currentContractSite.ContractSiteScheduleOfRates = this.OldContractSite.ContractSiteScheduleOfRates;
          int num = 0;
          IEnumerator enumerator;
          try
          {
            enumerator = this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              num = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["Qty"], current["TimeInMins"])));
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          this._currentContractSite.SetVisitDuration = (object) num;
          this._currentContractSite.SetAdditionalNotes = (object) this.OldContractSite.AdditionalNotes;
          this._currentContractSite.SetIncludeAssetPrice = (object) this.OldContractSite.IncludeAssetPrice;
          this._currentContractSite.SetIncludeMileagePrice = (object) this.OldContractSite.IncludeMileagePrice;
          this._currentContractSite.SetIncludeRates = (object) this.OldContractSite.IncludeRates;
          this._currentContractSite.SetLLCertReqd = (object) this.OldContractSite.LLCertReqd;
          this._currentContractSite.SetPricePerMile = (object) this.OldContractSite.PricePerMile;
          this._currentContractSite.SetPricePerVisit = (object) this.OldContractSite.PricePerVisit;
          this._currentContractSite.SetAverageMileage = (object) this.OldContractSite.AverageMileage;
          this._currentContractSite.SetTotalSitePrice = (object) this.OldContractSite.TotalSitePrice;
          this._currentContractSite.SetVisitFrequencyID = (object) this.OldContractSite.VisitFrequencyID;
          this._currentContractSite.FirstVisitDate = this.OldContractSite.FirstVisitDate;
          this.Populate(0);
        }
        this.Site = App.DB.Sites.Get((object) this.SiteID, SiteSQL.GetBy.SiteId, (object) null);
        this.txtSite.Text = Strings.Replace(Strings.Replace(Strings.Replace(this.Site.Address1 + ", " + this.Site.Address2 + ", " + this.Site.Address3 + ", " + this.Site.Address4 + ", " + this.Site.Address5 + ", " + this.Site.Postcode + ".", ", , ", ", ", 1, -1, CompareMethod.Binary), ", , ", ", ", 1, -1, CompareMethod.Binary), ", , ", ", ", 1, -1, CompareMethod.Binary);
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

    public FSM.Entity.Sites.Site Site
    {
      get
      {
        return this._site;
      }
      set
      {
        this._site = value;
      }
    }

    public ContractOriginal CurrentContract
    {
      get
      {
        return this._CurrentContract;
      }
      set
      {
        this._CurrentContract = value;
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
        this._Assets.Table.TableName = Enums.TableNames.tblContractSiteAsset.ToString();
        this._Assets.AllowNew = false;
        this._Assets.AllowEdit = true;
        this._Assets.AllowDelete = false;
        this.dgAssets.DataSource = (object) this.Assets;
      }
    }

    private DataView SystemRates
    {
      get
      {
        return this._SystemRates;
      }
      set
      {
        this._SystemRates = value;
        this._SystemRates.Table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
        this._SystemRates.AllowNew = false;
        this._SystemRates.AllowEdit = true;
        this._SystemRates.AllowDelete = false;
        this.dgSystemRates.DataSource = (object) this.SystemRates;
      }
    }

    private DataRow SelectedSystemRatesDataRow
    {
      get
      {
        return this.dgSystemRates.CurrentRowIndex != -1 ? this.SystemRates[this.dgSystemRates.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataView Visits
    {
      get
      {
        return this._Visits;
      }
      set
      {
        this._Visits = value;
        this._Visits.Table.TableName = Enums.TableNames.tblContractPPMVisit.ToString();
        this._Visits.AllowNew = false;
        this._Visits.AllowEdit = true;
        this._Visits.AllowDelete = false;
        this.dgVisits.DataSource = (object) this.Visits;
      }
    }

    private DataView Visits2
    {
      get
      {
        return this._Visits2;
      }
      set
      {
        this._Visits2 = value;
        this._Visits2.Table.TableName = Enums.TableNames.tblContractPPMVisit.ToString();
        this._Visits2.AllowNew = false;
        this._Visits2.AllowEdit = true;
        this._Visits2.AllowDelete = false;
        this.dgVisitsSetup.DataSource = (object) this.Visits2;
      }
    }

    private DataRow SelectedVisitDataRow
    {
      get
      {
        return this.dgVisits.CurrentRowIndex != -1 ? this.Visits[this.dgVisits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataRow SelectedVisitDataRow2
    {
      get
      {
        return this.dgVisitsSetup.CurrentRowIndex != -1 ? this.Visits2[this.dgVisitsSetup.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataRow SelectedAssetDataRow
    {
      get
      {
        return this.dgAssets.CurrentRowIndex != -1 ? this.Assets[this.dgAssets.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataRow SelectedRatesDataRow
    {
      get
      {
        return this.dgScheduleOfRates.CurrentRowIndex != -1 ? this.CurrentContractSite.ContractSiteScheduleOfRates[this.dgScheduleOfRates.CurrentRowIndex].Row : (DataRow) null;
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
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 50;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Product";
      dataGridLabelColumn1.MappingName = "Product";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 94;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Location";
      dataGridLabelColumn2.MappingName = "Location";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 94;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Serial Number";
      dataGridLabelColumn3.MappingName = "SerialNum";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 94;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "C";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "Price Per Visit (Click cell to change)";
      editableTextBoxColumn.MappingName = "PricePerVisit";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 150;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblContractSiteAsset.ToString();
      this.dgAssets.TableStyles.Add(tableStyle);
    }

    public void SetupVisitDataGrid()
    {
      Helper.SetUpDataGrid(this.dgVisits, false);
      DataGridTableStyle tableStyle = this.dgVisits.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Estimated Visit Date";
      dataGridLabelColumn1.MappingName = "EstimatedVisitDate";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Job No.";
      dataGridLabelColumn2.MappingName = "JobNumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 80;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Visit Date";
      dataGridLabelColumn3.MappingName = "StartDateTime";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 80;
      dataGridLabelColumn3.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Engineer";
      dataGridLabelColumn4.MappingName = "Name";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblContractPPMVisit.ToString();
      this.dgVisits.TableStyles.Add(tableStyle);
    }

    public void SetupVisit2DataGrid()
    {
      Helper.SetUpDataGrid(this.dgVisitsSetup, false);
      DataGridTableStyle tableStyle = this.dgVisitsSetup.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Visit Type";
      dataGridLabelColumn1.MappingName = "VisitType";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Frequency";
      dataGridLabelColumn2.MappingName = "Frequency";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Est Visit Date";
      dataGridLabelColumn3.MappingName = "VisitDate";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "SubCon / Pref Engineers";
      dataGridLabelColumn4.MappingName = "EngName";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 250;
      dataGridLabelColumn4.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "C";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "Cost";
      editableTextBoxColumn.MappingName = "COST";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 150;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblContractPPMVisit.ToString();
      this.dgVisitsSetup.TableStyles.Add(tableStyle);
    }

    public void SetupSystemRatesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSystemRates, false);
      DataGridTableStyle tableStyle = this.dgSystemRates.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgSystemRates.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "D";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "Quantity To Add";
      editableTextBoxColumn.MappingName = "Qty";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 100;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Category";
      dataGridLabelColumn1.MappingName = "Category";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Code";
      dataGridLabelColumn2.MappingName = "Code";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Description";
      dataGridLabelColumn3.MappingName = "Description";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Unit Price";
      dataGridLabelColumn4.MappingName = "Price";
      dataGridLabelColumn4.ReadOnly = false;
      dataGridLabelColumn4.Width = 80;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.MappingName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
      this.dgSystemRates.TableStyles.Add(tableStyle);
    }

    public void SetupScheduleOfRatesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgScheduleOfRates, false);
      DataGridTableStyle tableStyle = this.dgScheduleOfRates.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Category";
      dataGridLabelColumn1.MappingName = "Category";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Code";
      dataGridLabelColumn2.MappingName = "Code";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Description";
      dataGridLabelColumn3.MappingName = "Description";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Unit Price";
      dataGridLabelColumn4.MappingName = "Price";
      dataGridLabelColumn4.ReadOnly = false;
      dataGridLabelColumn4.Width = 80;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Unit Qty Per Visit";
      dataGridLabelColumn5.MappingName = "Qty";
      dataGridLabelColumn5.ReadOnly = false;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblContractOriginalSiteRates.ToString();
      this.dgScheduleOfRates.TableStyles.Add(tableStyle);
    }

    private void UCContractSite_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
      if (this.Visits2 != null)
        return;
      this.Visits2 = App.DB.ContractVisits.GetAll_For_ContractSiteID(0);
    }

    private void dgAssets_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgAssets.HitTest(e.X, e.Y);
      if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
        this.dgAssets.CurrentRowIndex = hitTestInfo.Row;
      if (hitTestInfo.Column != 0)
        return;
      this.Assets.Table.Rows[this.dgAssets.CurrentRowIndex]["Tick"] = (object) !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgAssets[this.dgAssets.CurrentRowIndex, 0]));
    }

    private void dgSystemRates_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        if (this.SelectedSystemRatesDataRow == null)
          return;
        DataGrid.HitTestInfo hitTestInfo = this.dgSystemRates.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgSystemRates.CurrentRowIndex = hitTestInfo.Row;
        if (hitTestInfo.Column == 0)
        {
          bool flag = !Conversions.ToBoolean(this.dgSystemRates[this.dgSystemRates.CurrentRowIndex, 0]);
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedSystemRatesDataRow["Qty"], (object) 0, false))
            this.SelectedSystemRatesDataRow["Qty"] = (object) 1;
          this.dgSystemRates[this.dgSystemRates.CurrentRowIndex, 0] = (object) flag;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (this.SelectedRatesDataRow == null)
        return;
      if (MessageBox.Show(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "DELETE :", this.SelectedRatesDataRow["Description"])), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        this.txtVisitDuration.Text = Conversions.ToString(Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject((object) Helper.MakeIntegerValid((object) this.txtVisitDuration.Text), Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(this.SelectedRatesDataRow["Qty"], this.SelectedRatesDataRow["TimeInMins"]))));
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(this.SelectedRatesDataRow["ContractOriginalSiteRateID"], (object) 0, false))
        {
          App.DB.ContractOriginalSiteRates.Delete(Conversions.ToInteger(this.SelectedRatesDataRow["ContractOriginalSiteRateID"]));
          this.CurrentContractSite.ContractSiteScheduleOfRates = App.DB.ContractOriginalSiteRates.ContractOriginalSiteRates_GetForContractSite(this.CurrentContractSite.ContractSiteID);
          this.Save();
        }
        else
          this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.Remove(this.SelectedRatesDataRow);
        this.dgScheduleOfRates.DataSource = (object) this.CurrentContractSite.ContractSiteScheduleOfRates;
      }
    }

    private void btnSiteScheduleOfRates_Click(object sender, EventArgs e)
    {
      DataRow[] dataRowArray1 = this.SystemRates.Table.Select("Tick = 1");
      int index1 = 0;
      while (index1 < dataRowArray1.Length)
      {
        DataRow dataRow1 = dataRowArray1[index1];
        if (this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "RateID = ", dataRow1["SystemScheduleOfRateID"]))).Length > 0)
        {
          DataRow dataRow2 = this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "RateID = ", dataRow1["SystemScheduleOfRateID"])))[0];
          DataRow dataRow3;
          (dataRow3 = dataRow2)["Qty"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow3["Qty"], dataRow1["Qty"]);
          dataRow2["Updated"] = (object) true;
          dataRow2.AcceptChanges();
          this.CurrentContractSite.ContractSiteScheduleOfRates.Table.AcceptChanges();
        }
        else
        {
          DataRow row = this.CurrentContractSite.ContractSiteScheduleOfRates.Table.NewRow();
          row["ContractOriginalSiteRateID"] = (object) 0;
          row["RateID"] = RuntimeHelpers.GetObjectValue(dataRow1["SystemScheduleOfRateID"]);
          row["ScheduleOfRatesCategoryID"] = RuntimeHelpers.GetObjectValue(dataRow1["ScheduleOfRatesCategoryID"]);
          row["Category"] = RuntimeHelpers.GetObjectValue(dataRow1["Category"]);
          row["Code"] = RuntimeHelpers.GetObjectValue(dataRow1["Code"]);
          row["Description"] = RuntimeHelpers.GetObjectValue(dataRow1["Description"]);
          row["Price"] = RuntimeHelpers.GetObjectValue(dataRow1["Price"]);
          row["TimeInMins"] = RuntimeHelpers.GetObjectValue(dataRow1["TimeInMins"]);
          row["Qty"] = RuntimeHelpers.GetObjectValue(dataRow1["Qty"]);
          row["Updated"] = (object) false;
          this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.Add(row);
          this.CurrentContractSite.ContractSiteScheduleOfRates.Table.AcceptChanges();
        }
        this.txtVisitDuration.Text = Conversions.ToString(Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Helper.MakeIntegerValid((object) this.txtVisitDuration.Text), Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(dataRow1["Qty"], dataRow1["TimeInMins"]))));
        checked { ++index1; }
      }
      this.dgScheduleOfRates.DataSource = (object) this.CurrentContractSite.ContractSiteScheduleOfRates;
      DataRow[] dataRowArray2 = this.SystemRates.Table.Select("Tick = 1");
      int index2 = 0;
      while (index2 < dataRowArray2.Length)
      {
        DataRow dataRow = dataRowArray2[index2];
        dataRow["Tick"] = (object) 0;
        dataRow["Qty"] = (object) 0;
        checked { ++index2; }
      }
      this.SystemRates.Table.AcceptChanges();
    }

    private void dgVisits_DoubleClick(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMLogCallout), true, new object[3]
      {
        this.SelectedVisitDataRow["JobID"],
        (object) this.CurrentContractSite.PropertyID,
        (object) this
      }, false);
    }

    private void dgVisits2_DoubleClick(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMLogCallout), true, new object[3]
      {
        this.SelectedVisitDataRow["JobID"],
        (object) this.CurrentContractSite.PropertyID,
        (object) this
      }, false);
    }

    private DataView BuildUpScheduleOfRatesDataview()
    {
      return new DataView(new DataTable()
      {
        Columns = {
          "ContractOriginalSiteRateID",
          "RateID",
          "ScheduleOfRatesCategoryID",
          "Category",
          "Code",
          "Description",
          {
            "TimeInMins",
            typeof (int)
          },
          {
            "Price",
            typeof (double)
          },
          {
            "Qty",
            typeof (int)
          },
          "Updated"
        },
        TableName = Enums.TableNames.tblContractOriginalSiteRates.ToString()
      });
    }

    private double CalculateSiteTotal(double SORPrice)
    {
      int num = 0;
      switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboVisitFrequencyID)))
      {
        case 3:
          num = 52;
          break;
        case 4:
          num = 12;
          break;
        case 5:
          num = 4;
          break;
        case 6:
          num = 2;
          break;
        case 7:
          num = 1;
          break;
      }
      return (double) num * SORPrice;
    }

    void IUserControl.Populate(int ID = 0)
    {
      if (this.Visits2 == null)
        this.Visits2 = App.DB.ContractVisits.GetAll_For_ContractSiteID(0);
      if ((uint) ID > 0U)
      {
        this.CurrentContractSite = App.DB.ContractOriginalSite.Get(ID);
        this.SiteID = this.CurrentContractSite.PropertyID;
        this.CurrentContract.SetContractID = (object) this.CurrentContractSite.ContractID;
        this.dgVisitsSetup.DataSource = (object) App.DB.ContractVisits.GetAll_For_ContractSiteID(this.CurrentContractSite.ContractSiteID);
        this.Visits2 = App.DB.ContractVisits.GetAll_For_ContractSiteID(this.CurrentContractSite.ContractSiteID);
      }
      this.dtpFirstVisitDate.Value = this.CurrentContractSite.FirstVisitDate;
      ComboBox visitFrequencyId = this.cboVisitFrequencyID;
      Combo.SetSelectedComboItem_By_Value(ref visitFrequencyId, Conversions.ToString(this.CurrentContractSite.VisitFrequencyID));
      this.cboVisitFrequencyID = visitFrequencyId;
      this.txtVisitDuration.Text = Conversions.ToString(this.CurrentContractSite.VisitDuration);
      this.txtAdditionalNotes.Text = this.CurrentContractSite.AdditionalNotes;
      this.chkLLCertificateReqd.Checked = this.CurrentContractSite.LLCertReqd;
      this.chkCommercial.Checked = this.CurrentContractSite.Commercial;
      this.dgScheduleOfRates.DataSource = (object) this.CurrentContractSite.ContractSiteScheduleOfRates;
    }

    public void PopAssets()
    {
      this.Assets = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(this.CurrentContractSite.ContractSiteID, this.SiteID);
      if (this.CurrentContractSite.Exists)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.Assets.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["Tick"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public bool Save()
    {
      bool flag;
      try
      {
        if (!this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Columns.Contains("Total"))
        {
          this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Columns.Add(new DataColumn("Total", typeof (double), "Price * Qty"));
          this.CurrentContractSite.ContractSiteScheduleOfRates.Table.AcceptChanges();
        }
        double SORPrice = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Compute("SUM(Total)", ""))) ? Conversions.ToDouble(this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Compute("SUM(Total)", "")) : 0.0;
        this.Cursor = Cursors.WaitCursor;
        this.CurrentContractSite.IgnoreExceptionsOnSetMethods = true;
        this.CurrentContractSite.SetPropertyID = (object) this.SiteID;
        this.CurrentContractSite.SetContractID = (object) this.CurrentContract.ContractID;
        this.CurrentContractSite.SetPricePerVisit = (object) SORPrice;
        this.CurrentContractSite.FirstVisitDate = this.dtpFirstVisitDate.Value;
        this.CurrentContractSite.SetVisitFrequencyID = (object) Combo.get_GetSelectedItemValue(this.cboVisitFrequencyID);
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVisitFrequencyID)) < 1.0)
          this.CurrentContractSite.SetVisitFrequencyID = (object) 7;
        this.CurrentContractSite.SetVisitDuration = (object) this.txtVisitDuration.Text;
        this.CurrentContractSite.SetAverageMileage = (object) 0;
        this.CurrentContractSite.SetIncludeAssetPrice = (object) false;
        this.CurrentContractSite.SetIncludeMileagePrice = (object) false;
        this.CurrentContractSite.SetTotalSitePrice = (object) this.CalculateSiteTotal(SORPrice);
        this.CurrentContractSite.SetPricePerMile = (object) 0;
        this.CurrentContractSite.SetIncludeRates = (object) true;
        this.CurrentContractSite.SetLLCertReqd = (object) this.chkLLCertificateReqd.Checked;
        this.CurrentContractSite.SetAdditionalNotes = (object) this.txtAdditionalNotes.Text;
        this.CurrentContractSite.SetCommercial = (object) this.chkCommercial.Checked;
        if (this.Visits2.Table.Rows.Count < 1)
          new ContractOriginalSiteValidator().Validate(this.CurrentContractSite, this.CurrentContract);
        if (this.CurrentContractSite.Exists)
        {
          if (App.ShowMessage("Are you sure you want to save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
          {
            App.DB.ContractOriginalSite.Update(this.CurrentContractSite);
            App.DB.ContractOriginalSiteAsset.Delete(this.CurrentContractSite.ContractSiteID);
            IEnumerator enumerator1;
            try
            {
              enumerator1 = this.Assets.Table.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current = (DataRow) enumerator1.Current;
                if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Tick"])))
                  App.DB.ContractOriginalSiteAsset.Insert(new ContractOriginalSiteAsset()
                  {
                    SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"]),
                    SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
                    SetPricePerVisit = RuntimeHelpers.GetObjectValue(current["PricePerVisit"])
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
              enumerator2 = this.Visits.Table.Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current1 = (DataRow) enumerator2.Current;
                if (Conversions.ToInteger(App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(Conversions.ToInteger(current1["JobID"])).Table.Rows[0]["StatusEnumID"]) < 6)
                {
                  App.DB.JobAsset.Delete(Conversions.ToInteger(current1["JobID"]));
                  IEnumerator enumerator3;
                  try
                  {
                    enumerator3 = this.Assets.Table.Rows.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                      DataRow current2 = (DataRow) enumerator3.Current;
                      if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current2["Tick"])))
                        App.DB.JobAsset.Insert(new JobAsset()
                        {
                          SetAssetID = RuntimeHelpers.GetObjectValue(current2["AssetID"]),
                          SetJobID = RuntimeHelpers.GetObjectValue(current1["JobID"])
                        });
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
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            this.Assets = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(this.CurrentContractSite.ContractSiteID, this.SiteID);
            IEnumerator enumerator4;
            try
            {
              enumerator4 = this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.GetEnumerator();
              while (enumerator4.MoveNext())
              {
                DataRow current = (DataRow) enumerator4.Current;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Updated"], (object) true, false))
                  App.DB.ContractOriginalSiteRates.Update(new ContractOriginalSiteRates()
                  {
                    SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
                    SetContractOriginalSiteRateID = RuntimeHelpers.GetObjectValue(current["ContractOriginalSiteRateID"]),
                    SetQty = RuntimeHelpers.GetObjectValue(current["Qty"]),
                    SetRateID = RuntimeHelpers.GetObjectValue(current["RateID"])
                  });
                else if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["ContractOriginalSiteRateID"])) == 0)
                  App.DB.ContractOriginalSiteRates.Insert(new ContractOriginalSiteRates()
                  {
                    SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
                    SetQty = RuntimeHelpers.GetObjectValue(current["Qty"]),
                    SetRateID = RuntimeHelpers.GetObjectValue(current["RateID"])
                  });
              }
            }
            finally
            {
              if (enumerator4 is IDisposable)
                (enumerator4 as IDisposable).Dispose();
            }
            string MessageText = "";
            int num1 = 0;
            IEnumerator enumerator5;
            try
            {
              enumerator5 = this.Visits2.Table.Rows.GetEnumerator();
              while (enumerator5.MoveNext())
              {
                DataRow current = (DataRow) enumerator5.Current;
                checked { ++num1; }
                App.DB.ContractVisits.Delete(Conversions.ToInteger(current["ContractVisitID"]));
                if (Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "SELECT COUNT(*) FROM tblContractVisits WHERE ContractVisitID = ", current["ContractVisitID"])), true, false)) > 0)
                {
                  MessageText = MessageText + "row " + Conversions.ToString(num1) + "couldn't be ammended as its gone past scheduled \r\n";
                }
                else
                {
                  App.DB.ContractOriginalSite.Delete_Visits(Conversions.ToInteger(current["ContractSiteID"]));
                  this.ScheduleSingleRow(current);
                }
              }
            }
            finally
            {
              if (enumerator5 is IDisposable)
                (enumerator5 as IDisposable).Dispose();
            }
            if (this.Visits == null || this.Visits.Table.Rows.Count == 0)
              this.ScheduleJob();
            if (MessageText.ToString().Length > 0)
            {
              int num2 = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
          }
          else
            goto label_90;
        }
        else if (App.ShowMessage("Are you sure you want to save?\r\nInformation cannot be altered after save and jobs will be scheduled", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
        {
          this.CurrentContractSite = App.DB.ContractOriginalSite.Insert(this.CurrentContractSite);
          App.DB.ContractOriginalSiteAsset.Delete(this.CurrentContractSite.ContractSiteID);
          IEnumerator enumerator1;
          try
          {
            enumerator1 = this.Assets.Table.Rows.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataRow current = (DataRow) enumerator1.Current;
              if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Tick"])))
                App.DB.ContractOriginalSiteAsset.Insert(new ContractOriginalSiteAsset()
                {
                  SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"]),
                  SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
                  SetPricePerVisit = RuntimeHelpers.GetObjectValue(current["PricePerVisit"])
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
            enumerator2 = this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Updated"], (object) true, false))
                App.DB.ContractOriginalSiteRates.Update(new ContractOriginalSiteRates()
                {
                  SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
                  SetContractOriginalSiteRateID = RuntimeHelpers.GetObjectValue(current["ContractOriginalSiteRateID"]),
                  SetQty = RuntimeHelpers.GetObjectValue(current["Qty"]),
                  SetRateID = RuntimeHelpers.GetObjectValue(current["RateID"])
                });
              else if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["ContractOriginalSiteRateID"])) == 0)
                App.DB.ContractOriginalSiteRates.Insert(new ContractOriginalSiteRates()
                {
                  SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
                  SetQty = RuntimeHelpers.GetObjectValue(current["Qty"]),
                  SetRateID = RuntimeHelpers.GetObjectValue(current["RateID"])
                });
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          if (this.Visits == null || this.Visits.Table.Rows.Count == 0)
            this.ScheduleJob();
        }
        else
          goto label_90;
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentContractSite.ContractSiteID);
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
label_90:
      return flag;
    }

    private void ScheduleJob()
    {
      try
      {
        DateTime date1 = Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00");
        DateTime contractEndDate = this.CurrentContract.ContractEndDate;
        DateTime date2 = Conversions.ToDate(Strings.Format((object) contractEndDate.AddDays(1.0), "dd/MM/yyyy") + " 00:00:00");
        TimeSpan timeSpan = date2.Subtract(date1);
        int days1 = timeSpan.Days;
        int num1 = checked (Math.Abs(date1.Year - date2.Year) * 12 + Math.Abs(date1.Month - date2.Month));
        timeSpan = date2.Subtract(date1);
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
          if (checked ((int) Math.Floor(unchecked ((double) num1 / (double) months))) == 0)
            num2 = 1;
        }
        else if (num3 > 0 && checked ((int) Math.Floor(unchecked ((double) days2 / (double) num3))) == 0)
          num2 = 1;
        contractEndDate = this.dtpFirstVisitDate.Value;
        DateTime dateTime = Conversions.ToDate(Conversions.ToString(contractEndDate.Date) + " 09:00:00");
        string str1 = string.Empty;
        int num4 = 0;
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (num4 > 0)
              str1 += " And ";
            str1 = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["Qty"], (object) 1, false) ? Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str1, current["Description"])) : Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str1, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["Qty"], (object) " x "), current["Description"])));
            checked { ++num4; }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
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
        if (!(DateTime.Compare(Conversions.ToDate(Strings.Format((object) dateTime, "dd/MM/yyyy") + " 00:00:00"), Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00")) >= 0 & DateTime.Compare(Conversions.ToDate(Strings.Format((object) dateTime, "dd/MM/yyyy") + " 00:00:00"), Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractEndDate, "dd/MM/yyyy") + " 00:00:00")) <= 0))
          return;
        if (dateTime.DayOfWeek == DayOfWeek.Saturday)
          dateTime = dateTime.AddDays(2.0);
        else if (dateTime.DayOfWeek == DayOfWeek.Sunday)
          dateTime = dateTime.AddDays(1.0);
        Job oJob = new Job();
        oJob.SetPropertyID = (object) this.CurrentContractSite.PropertyID;
        oJob.SetJobDefinitionEnumID = (object) 2;
        oJob.SetJobTypeID = !this.chkCommercial.Checked ? (!this.chkLLCertificateReqd.Checked ? RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Service'")[0]["ManagerID"]) : RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Service and Certificate'")[0]["ManagerID"])) : RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Commercial'")[0]["ManagerID"]);
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
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.Assets.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Tick"])))
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
        IEnumerator enumerator3;
        try
        {
          enumerator3 = this.CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.GetEnumerator();
          while (enumerator3.MoveNext())
          {
            DataRow current = (DataRow) enumerator3.Current;
            DataTable dataTable = App.DB.CustomerScheduleOfRate.Exists(Conversions.ToInteger(current["ScheduleOfRatesCategoryID"]), Conversions.ToString(current["Description"]), Conversions.ToString(current["Code"]), this.Site.CustomerID);
            int CustomerScheduleOfRateID = 0;
            if (dataTable.Rows.Count > 0)
              CustomerScheduleOfRateID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][0]));
            if (CustomerScheduleOfRateID <= 0)
            {
              CustomerScheduleOfRate oCustomerScheduleOfRate = new CustomerScheduleOfRate()
              {
                SetCode = RuntimeHelpers.GetObjectValue(current["Code"]),
                SetDescription = RuntimeHelpers.GetObjectValue(current["Description"]),
                SetPrice = RuntimeHelpers.GetObjectValue(current["Price"]),
                SetScheduleOfRatesCategoryID = RuntimeHelpers.GetObjectValue(current["ScheduleOfRatesCategoryID"]),
                SetTimeInMins = RuntimeHelpers.GetObjectValue(current["TimeInMins"]),
                SetCustomerID = (object) this.Site.CustomerID
              };
              CustomerScheduleOfRateID = App.DB.CustomerScheduleOfRate.Insert(oCustomerScheduleOfRate).CustomerScheduleOfRateID;
              App.DB.CustomerScheduleOfRate.Delete(CustomerScheduleOfRateID);
            }
            jobOfWork.JobItems.Add((object) new JobItem()
            {
              IgnoreExceptionsOnSetMethods = true,
              SetSummary = RuntimeHelpers.GetObjectValue(current["Description"]),
              SetQty = (object) 1,
              SetRateID = (object) CustomerScheduleOfRateID,
              SetSystemLinkID = (object) 95
            });
          }
        }
        finally
        {
          if (enumerator3 is IDisposable)
            (enumerator3 as IDisposable).Dispose();
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
          EstimatedVisitDate = dateTime,
          SetJobID = (object) job.JobID
        });
        if (num3 == 0)
          dateTime = dateTime.AddMonths(months);
        else if (num3 > 0)
          dateTime = dateTime.AddDays((double) num3);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ScheduleSingleRow(DataRow dr)
    {
      try
      {
        DateTime date1 = Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00");
        DateTime dateTime1 = this.CurrentContract.ContractEndDate;
        DateTime date2 = Conversions.ToDate(Strings.Format((object) dateTime1.AddDays(1.0), "dd/MM/yyyy") + " 00:00:00");
        TimeSpan timeSpan = date2.Subtract(date1);
        int days1 = timeSpan.Days;
        int num1 = checked (Math.Abs(date1.Year - date2.Year) * 12 + Math.Abs(date1.Month - date2.Month));
        timeSpan = date2.Subtract(date1);
        int days2 = timeSpan.Days;
        int num2 = 0;
        int months = 0;
        int num3 = 0;
        dateTime1 = DateAndTime.Today;
        DateTime dateTime2 = Conversions.ToDate(Conversions.ToString(dateTime1.Date) + " 09:00:00");
        Enums.VisitFrequency integer = (Enums.VisitFrequency) Conversions.ToInteger(dr["FrequencyID"]);
        switch (integer)
        {
          case Enums.VisitFrequency.Monthly:
            months = 1;
            dateTime1 = this.CurrentContract.ContractStartDate;
            dateTime2 = dateTime1.AddMonths(1);
            break;
          case Enums.VisitFrequency.Quarterly:
            months = 3;
            dateTime1 = this.CurrentContract.ContractStartDate;
            dateTime2 = dateTime1.AddMonths(3);
            break;
          case Enums.VisitFrequency.Bi_Annually:
            months = 6;
            dateTime1 = this.CurrentContract.ContractStartDate;
            dateTime2 = dateTime1.AddMonths(6);
            break;
          case Enums.VisitFrequency.Annually:
            months = 12;
            dateTime2 = Conversions.ToDate(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(NewLateBinding.LateGet(dr["VisitDate"], (System.Type) null, "Date", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) " 9:00:00"));
            break;
          case Enums.VisitFrequency.GBS_4_Month_Visits:
            months = 4;
            dateTime1 = this.CurrentContract.ContractStartDate;
            dateTime2 = dateTime1.AddMonths(4);
            break;
          case Enums.VisitFrequency.Fortnightly:
            num3 = 14;
            dateTime1 = this.CurrentContract.ContractStartDate;
            dateTime2 = dateTime1.AddDays(14.0);
            break;
        }
        if (num3 == 0)
        {
          if (checked ((int) Math.Floor(unchecked ((double) num1 / (double) months))) == 0)
            num2 = 1;
        }
        else if (num3 > 0 && checked ((int) Math.Floor(unchecked ((double) days2 / (double) num3))) == 0)
          num2 = 1;
        string empty = string.Empty;
        int num4 = Conversions.ToInteger(dr["HoursReq"]);
        if (dateTime2.DayOfWeek == DayOfWeek.Saturday)
          dateTime2 = dateTime2.AddDays(2.0);
        else if (dateTime2.DayOfWeek == DayOfWeek.Sunday)
          dateTime2 = dateTime2.AddDays(1.0);
        Job oJob = new Job();
        oJob.SetPropertyID = (object) this.CurrentContractSite.PropertyID;
        oJob.SetJobDefinitionEnumID = (object) 2;
        oJob.SetJobTypeID = RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Commercial'")[0]["ManagerID"]);
        oJob.SetStatusEnumID = (object) 1;
        oJob.SetCreatedByUserID = (object) App.loggedInUser.UserID;
        oJob.SetFOC = (object) true;
        JobNumber jobNumber = new JobNumber();
        JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
        oJob.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
        oJob.SetPONumber = (object) "";
        oJob.SetQuoteID = (object) 0;
        oJob.SetContractID = (object) this.CurrentContract.ContractID;
        IEnumerator enumerator;
        try
        {
          enumerator = this.Assets.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Tick"])))
              oJob.Assets.Add((object) new JobAsset()
              {
                SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"])
              });
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        while (num4 > 0)
        {
          JobOfWork jobOfWork = new JobOfWork();
          jobOfWork.SetPONumber = (object) "";
          jobOfWork.IgnoreExceptionsOnSetMethods = true;
          if (this.CurrentContract.ContractStatusID == 4)
            jobOfWork.SetDeleted = true;
          string str1 = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["VisitType"], (object) "SubContractor", false) ? Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["VisitType"], (object) " Service ")) : dr["SubContractor"].ToString() + " ";
          string str2 = integer == Enums.VisitFrequency.Annually ? str1 + "Annual Visit. " : Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str1, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["Frequency"], (object) " Visit. ")));
          DataTable dataTable = App.DB.CustomerScheduleOfRate.Exists(4701, "Contracted Visit", "C3", this.Site.CustomerID);
          int num5 = 0;
          if (dataTable.Rows.Count > 0)
            num5 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][0]));
          if (num5 <= 0)
          {
            CustomerScheduleOfRate oCustomerScheduleOfRate = new CustomerScheduleOfRate()
            {
              SetCode = (object) "C3",
              SetDescription = (object) "Contracted Visit",
              SetPrice = (object) 0,
              SetScheduleOfRatesCategoryID = (object) 4701,
              SetTimeInMins = (object) 60,
              SetCustomerID = (object) this.Site.CustomerID
            };
            num5 = App.DB.CustomerScheduleOfRate.Insert(oCustomerScheduleOfRate).CustomerScheduleOfRateID;
          }
          int num6;
          if ((double) num4 < 8.1)
          {
            num6 = num4;
            num4 = 0;
          }
          else
          {
            num6 = 8;
            checked { num4 -= 8; }
          }
          jobOfWork.JobItems.Add((object) new JobItem()
          {
            IgnoreExceptionsOnSetMethods = true,
            SetSummary = (object) str2,
            SetQty = (object) num6,
            SetRateID = (object) num5,
            SetSystemLinkID = (object) 95
          });
          EngineerVisit engineerVisit = new EngineerVisit();
          engineerVisit.IgnoreExceptionsOnSetMethods = true;
          engineerVisit.SetEngineerID = (object) 0;
          string str3 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str2, dr["AdditionalNotes"]));
          engineerVisit.SetNotesToEngineer = (object) str3;
          engineerVisit.StartDateTime = DateTime.MinValue;
          engineerVisit.EndDateTime = DateTime.MinValue;
          engineerVisit.SetStatusEnumID = (object) 4;
          jobOfWork.EngineerVisits.Add((object) engineerVisit);
          oJob.JobOfWorks.Add((object) jobOfWork);
        }
        Job job = App.DB.Job.Insert(oJob);
        App.DB.ContractOriginalPPMVisit.Insert(new ContractOriginalPPMVisit()
        {
          SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
          EstimatedVisitDate = dateTime2,
          SetJobID = (object) job.JobID
        });
        App.DB.ContractVisits.Insert(new ContractOriginalVisit()
        {
          SetAdditionalNotes = RuntimeHelpers.GetObjectValue(dr["AdditionalNotes"]),
          SetContractSiteID = (object) this.CurrentContractSite.ContractSiteID,
          SetCost = RuntimeHelpers.GetObjectValue(dr["Cost"]),
          EstimatedVisitDate = dateTime2,
          SetFrequency = RuntimeHelpers.GetObjectValue(dr["Frequency"]),
          SetFrequencyID = RuntimeHelpers.GetObjectValue(dr["FrequencyID"]),
          SetHoursReq = RuntimeHelpers.GetObjectValue(dr["HoursReq"]),
          SetJobID = (object) job.JobID,
          SetPreferredEngineer = RuntimeHelpers.GetObjectValue(dr["PreferredEngineer"]),
          SetPreferredEngineerID = RuntimeHelpers.GetObjectValue(dr["PreferredEngineerID"]),
          SetSubContractor = RuntimeHelpers.GetObjectValue(dr["SubContractor"]),
          SetSubContractorID = RuntimeHelpers.GetObjectValue(dr["SubContractorID"]),
          SetVisitType = RuntimeHelpers.GetObjectValue(dr["VisitType"]),
          SetVisitTypeID = RuntimeHelpers.GetObjectValue(dr["VisitTypeID"])
        });
        if (num3 == 0)
        {
          dateTime2 = dateTime2.AddMonths(months);
        }
        else
        {
          if (num3 <= 0)
            return;
          dateTime2 = dateTime2.AddDays((double) num3);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private ArrayList MatchingEngineer(Job job, DateTime estVisitDate)
    {
      FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
      int numOfSlotsNeeded = 0;
      ArrayList arrayList = new ArrayList();
      int timeSlot = App.DB.Manager.Get().TimeSlot;
      int integer = Conversions.ToInteger(this.txtVisitDuration.Text);
      if (integer > 0)
        numOfSlotsNeeded = checked ((int) Math.Round(unchecked ((double) integer / (double) timeSlot)));
      FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) job.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
      if (site2.EngineerID > 0)
        arrayList = this.CheckAvailability(estVisitDate, site2.EngineerID, numOfSlotsNeeded);
      if (arrayList.Count > 0)
        return arrayList;
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
          arrayList = this.CheckAvailability(estVisitDate, Conversions.ToInteger(forPostcode.Table.Rows[index]["EngineerID"]), numOfSlotsNeeded);
          if (arrayList.Count > 0)
            return arrayList;
          forPostcode.Table.Rows.Remove(forPostcode.Table.Rows[index]);
          checked { ++num2; }
        }
      }
      return arrayList;
    }

    private ArrayList CheckAvailability(
      DateTime estimatedVisitDate,
      int engineerID,
      int numOfSlotsNeeded)
    {
      ArrayList arrayList1 = new ArrayList();
      DateTime day = estimatedVisitDate;
      ArrayList arrayList2 = new ArrayList();
      int num1 = 0;
      do
      {
        arrayList1.Clear();
        if ((uint) num1 > 0U)
          day = day.AddDays(1.0);
        if (day.DayOfWeek == DayOfWeek.Saturday)
          day = day.AddDays(2.0);
        if (day.DayOfWeek == DayOfWeek.Saturday)
          day = day.AddDays(1.0);
        DataTable dataTable = App.DB.Scheduler.Scheduler_DayTimeSlots(day, Conversions.ToString(engineerID));
        if (dataTable.Rows.Count > 0)
        {
          int num2 = checked (dataTable.Columns.Count - 1);
          int index = 0;
          while (index <= num2)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataTable.Rows[0][index], (object) 0, false))
            {
              arrayList1.Add((object) dataTable.Columns[index].ColumnName);
              if (arrayList1.Count == numOfSlotsNeeded)
                break;
            }
            else
              arrayList1.Clear();
            checked { ++index; }
          }
        }
        else
          arrayList1.Add((object) App.DB.Manager.Get().WorkingHoursStart);
        if (arrayList1.Count > 0 && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (arrayList1.Count == numOfSlotsNeeded), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(arrayList1[0], (object) App.DB.Manager.Get().WorkingHoursStart, false))))
        {
          string str = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(arrayList1[0], (object) App.DB.Manager.Get().WorkingHoursStart, false) ? Strings.Replace(Conversions.ToString(arrayList1[0]), "T", "", 1, -1, CompareMethod.Binary).Insert(2, ":") : Conversions.ToString(arrayList1[0]);
          day = Conversions.ToDate(Strings.Format((object) day, "dd/MM/yyyy") + " " + str);
          arrayList2.Add((object) day);
          arrayList2.Add((object) engineerID);
          return arrayList2;
        }
        checked { ++num1; }
      }
      while (num1 <= 4);
      return arrayList2;
    }

    private void btnAddVisit_Click(object sender, EventArgs e)
    {
      DataTable dataTable = new DataTable();
      if (this.Visits2 == null)
        this.Visits2 = App.DB.ContractVisits.GetAll_For_ContractSiteID(0);
      DataTable table = this.Visits2.Table;
      DLGSetupVisit dlgSetupVisit = new DLGSetupVisit();
      int num = (int) dlgSetupVisit.ShowDialog();
      if (dlgSetupVisit.DialogResult != DialogResult.OK)
        return;
      DataRow row = table.NewRow();
      row["SubContractor"] = (object) Combo.get_GetSelectedItemDescription(dlgSetupVisit.cboSubContractor);
      row["PreferredEngineer"] = (object) Combo.get_GetSelectedItemDescription(dlgSetupVisit.cboPreferredEngineer);
      row["VisitType"] = (object) Combo.get_GetSelectedItemDescription(dlgSetupVisit.cboType);
      row["Frequency"] = (object) Combo.get_GetSelectedItemDescription(dlgSetupVisit.cboFrequency);
      row["VisitTypeID"] = (object) Combo.get_GetSelectedItemValue(dlgSetupVisit.cboType);
      row["VisitDate"] = (object) dlgSetupVisit.dtpTargetDate.Value;
      row["FrequencyID"] = (object) Combo.get_GetSelectedItemValue(dlgSetupVisit.cboFrequency);
      row["Cost"] = (object) dlgSetupVisit.txtFilter.Text.Replace("£", "");
      row["SubContractorID"] = (object) Combo.get_GetSelectedItemValue(dlgSetupVisit.cboSubContractor);
      row["PreferredEngineerID"] = (object) Combo.get_GetSelectedItemValue(dlgSetupVisit.cboPreferredEngineer);
      row["HoursReq"] = (object) dlgSetupVisit.TextBox1.Text;
      row["AdditionalNotes"] = (object) dlgSetupVisit.txtAdditional.Text;
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(dlgSetupVisit.cboPreferredEngineer)) > 0.0)
        row["EngName"] = (object) Combo.get_GetSelectedItemDescription(dlgSetupVisit.cboPreferredEngineer);
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(dlgSetupVisit.cboSubContractor)) > 0.0)
        row["EngName"] = (object) Combo.get_GetSelectedItemDescription(dlgSetupVisit.cboSubContractor);
      table.Rows.Add(row);
      this.dgVisitsSetup.DataSource = (object) table;
      this.Visits2.Table = table;
    }

    private void btRemoveVisit_Click(object sender, EventArgs e)
    {
      if (this.SelectedVisitDataRow2 == null)
        return;
      if (MessageBox.Show(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "DELETE :", this.SelectedVisitDataRow2["VisitType"])), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow2["ContractVisitID"])) || Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(this.SelectedVisitDataRow2["ContractVisitID"], (object) 1, false))
        {
          this.Visits2.Table.Rows.Remove(this.SelectedVisitDataRow2);
        }
        else
        {
          App.DB.ContractVisits.Delete(Conversions.ToInteger(this.SelectedVisitDataRow2["ContractVisitID"]));
          this.Visits2 = App.DB.ContractVisits.GetAll_For_ContractSiteID(this.CurrentContractSite.ContractSiteID);
        }
        this.dgVisitsSetup.DataSource = (object) this.Visits2;
      }
    }
  }
}
