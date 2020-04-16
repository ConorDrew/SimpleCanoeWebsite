// Decompiled with JetBrains decompiler
// Type: FSM.FRMSiteFuel
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class FRMSiteFuel : FRMBaseForm, IForm
  {
    private IContainer components;
    private FSM.Entity.Sites.Site _osite;
    private DataView _dvSiteFuels;
    private DataView _dvSiteFuelAudit;

    public FRMSiteFuel(FSM.Entity.Sites.Site oSite)
    {
      this.Load += new EventHandler(this.FRMContactInfo_Load);
      this._dvSiteFuels = (DataView) null;
      this.InitializeComponent();
      this.CurrentSite = oSite;
      ComboBox cboFuel = this.cboFuel;
      Combo.SetUpCombo(ref cboFuel, App.DB.Picklists.GetAll(Enums.PickListTypes.GasTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFuel = cboFuel;
      ComboBox cboChargeType = this.cboChargeType;
      Combo.SetUpCombo(ref cboChargeType, App.DB.Sites.SiteFuelCharge_GetAll().Table, "SiteFuelChargeID", "Name", Enums.ComboValues.Please_Select_Negative);
      this.cboChargeType = cboChargeType;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl SiteFuelTabControl { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabSiteFuel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSiteFuels { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSiteFuel
    {
      get
      {
        return this._dgSiteFuel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgSiteFuel_Click);
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgSiteFuel_MouseUp);
        EventHandler eventHandler2 = new EventHandler(this.dgSiteFuel_Leave);
        DataGrid dgSiteFuel1 = this._dgSiteFuel;
        if (dgSiteFuel1 != null)
        {
          dgSiteFuel1.Click -= eventHandler1;
          dgSiteFuel1.MouseUp -= mouseEventHandler;
          dgSiteFuel1.Leave -= eventHandler2;
        }
        this._dgSiteFuel = value;
        DataGrid dgSiteFuel2 = this._dgSiteFuel;
        if (dgSiteFuel2 == null)
          return;
        dgSiteFuel2.Click += eventHandler1;
        dgSiteFuel2.MouseUp += mouseEventHandler;
        dgSiteFuel2.Leave += eventHandler2;
      }
    }

    internal virtual Button btnSaveFuel
    {
      get
      {
        return this._btnSaveFuel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSaveFuel1 = this._btnSaveFuel;
        if (btnSaveFuel1 != null)
          btnSaveFuel1.Click -= eventHandler;
        this._btnSaveFuel = value;
        Button btnSaveFuel2 = this._btnSaveFuel;
        if (btnSaveFuel2 == null)
          return;
        btnSaveFuel2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeleteSiteFuel
    {
      get
      {
        return this._btnDeleteSiteFuel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteSiteFuel_Click);
        Button btnDeleteSiteFuel1 = this._btnDeleteSiteFuel;
        if (btnDeleteSiteFuel1 != null)
          btnDeleteSiteFuel1.Click -= eventHandler;
        this._btnDeleteSiteFuel = value;
        Button btnDeleteSiteFuel2 = this._btnDeleteSiteFuel;
        if (btnDeleteSiteFuel2 == null)
          return;
        btnDeleteSiteFuel2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpSiteFuelUpdate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFuel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFuel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpLastServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLastService { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomerName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSiteName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSiteName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolTip ttSiteFuel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSiteFuelAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSiteFuelAudit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddedOn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddedOn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddedByText { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddedBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblChargeType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboChargeType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpActualServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblActualServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUpdateSiteService
    {
      get
      {
        return this._btnUpdateSiteService;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdateSiteService_Click);
        Button updateSiteService1 = this._btnUpdateSiteService;
        if (updateSiteService1 != null)
          updateSiteService1.Click -= eventHandler;
        this._btnUpdateSiteService = value;
        Button updateSiteService2 = this._btnUpdateSiteService;
        if (updateSiteService2 == null)
          return;
        updateSiteService2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.SiteFuelTabControl = new TabControl();
      this.tabSiteFuel = new TabPage();
      this.grpSiteFuels = new GroupBox();
      this.grpSite = new GroupBox();
      this.btnUpdateSiteService = new Button();
      this.txtSite = new TextBox();
      this.lblSiteName = new Label();
      this.txtCustomerName = new TextBox();
      this.lblSite = new Label();
      this.txtSiteName = new TextBox();
      this.lblCustomer = new Label();
      this.txtTelephoneNum = new TextBox();
      this.lblTelephoneNum = new Label();
      this.txtEmailAddress = new TextBox();
      this.lblEmailAddress = new Label();
      this.txtFaxNum = new TextBox();
      this.lblFaxNum = new Label();
      this.grpSiteFuelUpdate = new GroupBox();
      this.dtpActualServiceDate = new DateTimePicker();
      this.lblActualServiceDate = new Label();
      this.lblChargeType = new Label();
      this.cboChargeType = new ComboBox();
      this.txtAddedOn = new TextBox();
      this.lblAddedOn = new Label();
      this.txtAddedByText = new TextBox();
      this.lblAddedBy = new Label();
      this.dtpLastServiceDate = new DateTimePicker();
      this.lblLastService = new Label();
      this.lblFuel = new Label();
      this.cboFuel = new ComboBox();
      this.btnSaveFuel = new Button();
      this.btnDeleteSiteFuel = new Button();
      this.dgSiteFuel = new DataGrid();
      this.tabAudit = new TabPage();
      this.grpSiteFuelAudit = new GroupBox();
      this.dgSiteFuelAudit = new DataGrid();
      this.ttSiteFuel = new ToolTip(this.components);
      this.SiteFuelTabControl.SuspendLayout();
      this.tabSiteFuel.SuspendLayout();
      this.grpSiteFuels.SuspendLayout();
      this.grpSite.SuspendLayout();
      this.grpSiteFuelUpdate.SuspendLayout();
      this.dgSiteFuel.BeginInit();
      this.tabAudit.SuspendLayout();
      this.grpSiteFuelAudit.SuspendLayout();
      this.dgSiteFuelAudit.BeginInit();
      this.SuspendLayout();
      this.SiteFuelTabControl.Controls.Add((Control) this.tabSiteFuel);
      this.SiteFuelTabControl.Controls.Add((Control) this.tabAudit);
      this.SiteFuelTabControl.Dock = DockStyle.Fill;
      this.SiteFuelTabControl.Location = new System.Drawing.Point(0, 0);
      this.SiteFuelTabControl.Name = "SiteFuelTabControl";
      this.SiteFuelTabControl.SelectedIndex = 0;
      this.SiteFuelTabControl.Size = new Size(800, 557);
      this.SiteFuelTabControl.TabIndex = 2;
      this.tabSiteFuel.Controls.Add((Control) this.grpSiteFuels);
      this.tabSiteFuel.Location = new System.Drawing.Point(4, 22);
      this.tabSiteFuel.Name = "tabSiteFuel";
      this.tabSiteFuel.Padding = new Padding(3);
      this.tabSiteFuel.Size = new Size(792, 531);
      this.tabSiteFuel.TabIndex = 0;
      this.tabSiteFuel.Text = "Site Fuels";
      this.tabSiteFuel.UseVisualStyleBackColor = true;
      this.grpSiteFuels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSiteFuels.Controls.Add((Control) this.grpSite);
      this.grpSiteFuels.Controls.Add((Control) this.grpSiteFuelUpdate);
      this.grpSiteFuels.Controls.Add((Control) this.dgSiteFuel);
      this.grpSiteFuels.Location = new System.Drawing.Point(5, 3);
      this.grpSiteFuels.Margin = new Padding(0);
      this.grpSiteFuels.Name = "grpSiteFuels";
      this.grpSiteFuels.Padding = new Padding(0);
      this.grpSiteFuels.Size = new Size(782, 523);
      this.grpSiteFuels.TabIndex = 14;
      this.grpSiteFuels.TabStop = false;
      this.grpSiteFuels.Text = "Site Fuel";
      this.grpSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.grpSite.Controls.Add((Control) this.btnUpdateSiteService);
      this.grpSite.Controls.Add((Control) this.txtSite);
      this.grpSite.Controls.Add((Control) this.lblSiteName);
      this.grpSite.Controls.Add((Control) this.txtCustomerName);
      this.grpSite.Controls.Add((Control) this.lblSite);
      this.grpSite.Controls.Add((Control) this.txtSiteName);
      this.grpSite.Controls.Add((Control) this.lblCustomer);
      this.grpSite.Controls.Add((Control) this.txtTelephoneNum);
      this.grpSite.Controls.Add((Control) this.lblTelephoneNum);
      this.grpSite.Controls.Add((Control) this.txtEmailAddress);
      this.grpSite.Controls.Add((Control) this.lblEmailAddress);
      this.grpSite.Controls.Add((Control) this.txtFaxNum);
      this.grpSite.Controls.Add((Control) this.lblFaxNum);
      this.grpSite.Location = new System.Drawing.Point(489, 17);
      this.grpSite.Name = "grpSite";
      this.grpSite.Size = new Size(287, 229);
      this.grpSite.TabIndex = 115;
      this.grpSite.TabStop = false;
      this.grpSite.Text = "Site ";
      this.btnUpdateSiteService.Location = new System.Drawing.Point(139, 196);
      this.btnUpdateSiteService.Name = "btnUpdateSiteService";
      this.btnUpdateSiteService.Size = new Size(139, 23);
      this.btnUpdateSiteService.TabIndex = 126;
      this.btnUpdateSiteService.Text = "Update Site Service";
      this.txtSite.Location = new System.Drawing.Point(117, 48);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(161, 21);
      this.txtSite.TabIndex = 121;
      this.lblSiteName.Location = new System.Drawing.Point(8, 51);
      this.lblSiteName.Name = "lblSiteName";
      this.lblSiteName.Size = new Size(80, 23);
      this.lblSiteName.TabIndex = 125;
      this.lblSiteName.Text = "Name:";
      this.txtCustomerName.Location = new System.Drawing.Point(117, 20);
      this.txtCustomerName.Name = "txtCustomerName";
      this.txtCustomerName.ReadOnly = true;
      this.txtCustomerName.Size = new Size(161, 21);
      this.txtCustomerName.TabIndex = 120;
      this.lblSite.Location = new System.Drawing.Point(8, 79);
      this.lblSite.Name = "lblSite";
      this.lblSite.Size = new Size(80, 23);
      this.lblSite.TabIndex = 124;
      this.lblSite.Text = "Property:";
      this.txtSiteName.Location = new System.Drawing.Point(117, 76);
      this.txtSiteName.Name = "txtSiteName";
      this.txtSiteName.ReadOnly = true;
      this.txtSiteName.Size = new Size(161, 21);
      this.txtSiteName.TabIndex = 122;
      this.lblCustomer.Location = new System.Drawing.Point(6, 23);
      this.lblCustomer.Name = "lblCustomer";
      this.lblCustomer.Size = new Size(80, 23);
      this.lblCustomer.TabIndex = 123;
      this.lblCustomer.Text = "Customer:";
      this.txtTelephoneNum.Location = new System.Drawing.Point(117, 104);
      this.txtTelephoneNum.MaxLength = 50;
      this.txtTelephoneNum.Name = "txtTelephoneNum";
      this.txtTelephoneNum.ReadOnly = true;
      this.txtTelephoneNum.Size = new Size(161, 21);
      this.txtTelephoneNum.TabIndex = 114;
      this.txtTelephoneNum.Tag = (object) "Site.TelephoneNum";
      this.lblTelephoneNum.Location = new System.Drawing.Point(8, 107);
      this.lblTelephoneNum.Name = "lblTelephoneNum";
      this.lblTelephoneNum.Size = new Size(48, 20);
      this.lblTelephoneNum.TabIndex = 119;
      this.lblTelephoneNum.Text = "Tel";
      this.txtEmailAddress.Location = new System.Drawing.Point(117, 160);
      this.txtEmailAddress.MaxLength = 100;
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.ReadOnly = true;
      this.txtEmailAddress.Size = new Size(161, 21);
      this.txtEmailAddress.TabIndex = 116;
      this.txtEmailAddress.Tag = (object) "Site.EmailAddress";
      this.lblEmailAddress.Location = new System.Drawing.Point(8, 163);
      this.lblEmailAddress.Name = "lblEmailAddress";
      this.lblEmailAddress.Size = new Size(98, 20);
      this.lblEmailAddress.TabIndex = 118;
      this.lblEmailAddress.Text = "Email Address";
      this.txtFaxNum.Location = new System.Drawing.Point(117, 132);
      this.txtFaxNum.MaxLength = 50;
      this.txtFaxNum.Name = "txtFaxNum";
      this.txtFaxNum.ReadOnly = true;
      this.txtFaxNum.Size = new Size(161, 21);
      this.txtFaxNum.TabIndex = 115;
      this.txtFaxNum.Tag = (object) "Site.FaxNum";
      this.lblFaxNum.Location = new System.Drawing.Point(8, 135);
      this.lblFaxNum.Name = "lblFaxNum";
      this.lblFaxNum.Size = new Size(50, 20);
      this.lblFaxNum.TabIndex = 117;
      this.lblFaxNum.Text = "Mobile";
      this.grpSiteFuelUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.grpSiteFuelUpdate.Controls.Add((Control) this.dtpActualServiceDate);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.lblActualServiceDate);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.lblChargeType);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.cboChargeType);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.txtAddedOn);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.lblAddedOn);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.txtAddedByText);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.lblAddedBy);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.dtpLastServiceDate);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.lblLastService);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.lblFuel);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.cboFuel);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.btnSaveFuel);
      this.grpSiteFuelUpdate.Controls.Add((Control) this.btnDeleteSiteFuel);
      this.grpSiteFuelUpdate.Location = new System.Drawing.Point(489, 252);
      this.grpSiteFuelUpdate.Name = "grpSiteFuelUpdate";
      this.grpSiteFuelUpdate.Size = new Size(287, 266);
      this.grpSiteFuelUpdate.TabIndex = 12;
      this.grpSiteFuelUpdate.TabStop = false;
      this.grpSiteFuelUpdate.Text = "Fuel";
      this.dtpActualServiceDate.Location = new System.Drawing.Point(142, 119);
      this.dtpActualServiceDate.Name = "dtpActualServiceDate";
      this.dtpActualServiceDate.Size = new Size(139, 21);
      this.dtpActualServiceDate.TabIndex = 133;
      this.lblActualServiceDate.Location = new System.Drawing.Point(6, 125);
      this.lblActualServiceDate.Name = "lblActualServiceDate";
      this.lblActualServiceDate.Size = new Size(124, 20);
      this.lblActualServiceDate.TabIndex = 132;
      this.lblActualServiceDate.Text = "Service Date";
      this.lblChargeType.AutoSize = true;
      this.lblChargeType.Location = new System.Drawing.Point(6, 56);
      this.lblChargeType.Name = "lblChargeType";
      this.lblChargeType.Size = new Size(49, 13);
      this.lblChargeType.TabIndex = 131;
      this.lblChargeType.Text = "Charge";
      this.cboChargeType.FormattingEnabled = true;
      this.cboChargeType.Location = new System.Drawing.Point(72, 53);
      this.cboChargeType.Name = "cboChargeType";
      this.cboChargeType.Size = new Size(209, 21);
      this.cboChargeType.TabIndex = 130;
      this.txtAddedOn.Location = new System.Drawing.Point(120, 185);
      this.txtAddedOn.Name = "txtAddedOn";
      this.txtAddedOn.ReadOnly = true;
      this.txtAddedOn.Size = new Size(161, 21);
      this.txtAddedOn.TabIndex = 128;
      this.lblAddedOn.Location = new System.Drawing.Point(8, 188);
      this.lblAddedOn.Name = "lblAddedOn";
      this.lblAddedOn.Size = new Size(80, 23);
      this.lblAddedOn.TabIndex = 129;
      this.lblAddedOn.Text = "Added On:";
      this.txtAddedByText.Location = new System.Drawing.Point(120, 152);
      this.txtAddedByText.Name = "txtAddedByText";
      this.txtAddedByText.ReadOnly = true;
      this.txtAddedByText.Size = new Size(161, 21);
      this.txtAddedByText.TabIndex = 126;
      this.lblAddedBy.Location = new System.Drawing.Point(6, 155);
      this.lblAddedBy.Name = "lblAddedBy";
      this.lblAddedBy.Size = new Size(80, 23);
      this.lblAddedBy.TabIndex = (int) sbyte.MaxValue;
      this.lblAddedBy.Text = "Added By:";
      this.dtpLastServiceDate.Location = new System.Drawing.Point(142, 86);
      this.dtpLastServiceDate.Name = "dtpLastServiceDate";
      this.dtpLastServiceDate.Size = new Size(139, 21);
      this.dtpLastServiceDate.TabIndex = 57;
      this.lblLastService.Location = new System.Drawing.Point(6, 92);
      this.lblLastService.Name = "lblLastService";
      this.lblLastService.Size = new Size(114, 20);
      this.lblLastService.TabIndex = 56;
      this.lblLastService.Text = "Service Due Date";
      this.lblFuel.AutoSize = true;
      this.lblFuel.Location = new System.Drawing.Point(8, 23);
      this.lblFuel.Name = "lblFuel";
      this.lblFuel.Size = new Size(30, 13);
      this.lblFuel.TabIndex = 55;
      this.lblFuel.Text = "Fuel";
      this.cboFuel.FormattingEnabled = true;
      this.cboFuel.Location = new System.Drawing.Point(72, 20);
      this.cboFuel.Name = "cboFuel";
      this.cboFuel.Size = new Size(209, 21);
      this.cboFuel.TabIndex = 54;
      this.btnSaveFuel.Location = new System.Drawing.Point(191, 233);
      this.btnSaveFuel.Name = "btnSaveFuel";
      this.btnSaveFuel.Size = new Size(90, 23);
      this.btnSaveFuel.TabIndex = 9;
      this.btnSaveFuel.Text = "Save";
      this.btnDeleteSiteFuel.Location = new System.Drawing.Point(9, 233);
      this.btnDeleteSiteFuel.Name = "btnDeleteSiteFuel";
      this.btnDeleteSiteFuel.Size = new Size(90, 23);
      this.btnDeleteSiteFuel.TabIndex = 10;
      this.btnDeleteSiteFuel.Text = "Delete";
      this.dgSiteFuel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSiteFuel.DataMember = "";
      this.dgSiteFuel.HeaderForeColor = SystemColors.ControlText;
      this.dgSiteFuel.Location = new System.Drawing.Point(5, 19);
      this.dgSiteFuel.Name = "dgSiteFuel";
      this.dgSiteFuel.Size = new Size(478, 499);
      this.dgSiteFuel.TabIndex = 11;
      this.tabAudit.Controls.Add((Control) this.grpSiteFuelAudit);
      this.tabAudit.Location = new System.Drawing.Point(4, 22);
      this.tabAudit.Name = "tabAudit";
      this.tabAudit.Padding = new Padding(3);
      this.tabAudit.Size = new Size(792, 531);
      this.tabAudit.TabIndex = 1;
      this.tabAudit.Text = "Audit";
      this.tabAudit.UseVisualStyleBackColor = true;
      this.grpSiteFuelAudit.Controls.Add((Control) this.dgSiteFuelAudit);
      this.grpSiteFuelAudit.Dock = DockStyle.Fill;
      this.grpSiteFuelAudit.Location = new System.Drawing.Point(3, 3);
      this.grpSiteFuelAudit.Name = "grpSiteFuelAudit";
      this.grpSiteFuelAudit.Size = new Size(786, 525);
      this.grpSiteFuelAudit.TabIndex = 5;
      this.grpSiteFuelAudit.TabStop = false;
      this.grpSiteFuelAudit.Text = "Site Fuel Audit";
      this.dgSiteFuelAudit.DataMember = "";
      this.dgSiteFuelAudit.Dock = DockStyle.Fill;
      this.dgSiteFuelAudit.HeaderForeColor = SystemColors.ControlText;
      this.dgSiteFuelAudit.Location = new System.Drawing.Point(3, 17);
      this.dgSiteFuelAudit.Name = "dgSiteFuelAudit";
      this.dgSiteFuelAudit.Size = new Size(780, 505);
      this.dgSiteFuelAudit.TabIndex = 15;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(800, 557);
      this.Controls.Add((Control) this.SiteFuelTabControl);
      this.MinimumSize = new Size(1, 1);
      this.Name = nameof (FRMSiteFuel);
      this.Text = "Site Fuel";
      this.Controls.SetChildIndex((Control) this.SiteFuelTabControl, 0);
      this.SiteFuelTabControl.ResumeLayout(false);
      this.tabSiteFuel.ResumeLayout(false);
      this.grpSiteFuels.ResumeLayout(false);
      this.grpSite.ResumeLayout(false);
      this.grpSite.PerformLayout();
      this.grpSiteFuelUpdate.ResumeLayout(false);
      this.grpSiteFuelUpdate.PerformLayout();
      this.dgSiteFuel.EndInit();
      this.tabAudit.ResumeLayout(false);
      this.grpSiteFuelAudit.ResumeLayout(false);
      this.dgSiteFuelAudit.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupSiteFuelDataGrid();
      this.SetupSiteFuelAuditDataGrid();
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

    public void SetupSiteFuelAuditDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgSiteFuelAudit.TableStyles[0];
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
      tableStyle.MappingName = Enums.TableNames.tblSiteFuel.ToString();
      this.dgSiteFuelAudit.TableStyles.Add(tableStyle);
    }

    public FSM.Entity.Sites.Site CurrentSite
    {
      get
      {
        return this._osite;
      }
      set
      {
        this._osite = value;
        this.txtSite.Text = this.CurrentSite.Name;
        this.txtSiteName.Text = this.CurrentSite.Address1 + "," + this.CurrentSite.Postcode;
        FSM.Entity.Customers.Customer customer = new FSM.Entity.Customers.Customer();
        this.txtCustomerName.Text = App.DB.Customer.Customer_Get_Light(this.CurrentSite.CustomerID).Name;
        this.txtTelephoneNum.Text = this.CurrentSite.TelephoneNum;
        this.txtFaxNum.Text = this.CurrentSite.FaxNum;
        this.txtEmailAddress.Text = this.CurrentSite.EmailAddress;
        this.PopulateSiteFuelDataGrid();
        this.PopulateSiteAuditFuelDataGrid();
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

    private DataView SiteFuelAuditDataView
    {
      get
      {
        return this._dvSiteFuelAudit;
      }
      set
      {
        this._dvSiteFuelAudit = value;
        this._dvSiteFuelAudit.AllowNew = false;
        this._dvSiteFuelAudit.AllowEdit = false;
        this._dvSiteFuelAudit.AllowDelete = false;
        this._dvSiteFuelAudit.Table.TableName = Enums.TableNames.tblSiteFuel.ToString();
        this.dgSiteFuelAudit.DataSource = (object) this.SiteFuelAuditDataView;
      }
    }

    private void FRMContactInfo_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      int num1 = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboFuel));
      if (num1 == 0 | num1 == 69498)
        return;
      int num2 = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboChargeType));
      DataRow[] dataRowArray1 = this.SiteFuelsDataView.Table.Select("FuelID = " + Conversions.ToString(num1));
      string str = "";
      bool flag = false;
      string actionChange = Combo.get_GetSelectedItemDescription(this.cboFuel) + " added";
      int siteFuelId = 0;
      DateTime dateTime1;
      if (dataRowArray1.Length > 0)
      {
        if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Servicing))
          throw new SecurityException("You do not have the necessary security permissions.");
        string MessageText = str + "Update Fuel?";
        actionChange = string.Empty;
        DataRow[] dataRowArray2 = dataRowArray1;
        int index = 0;
        while (index < dataRowArray2.Length)
        {
          DataRow dataRow = dataRowArray2[index];
          siteFuelId = Conversions.ToInteger(dataRow["SiteFuelID"]);
          dateTime1 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["LastServiceDate"]));
          dateTime1 = dateTime1.Date;
          DateTime t1 = dateTime1.AddYears(1);
          dateTime1 = this.dtpLastServiceDate.Value;
          dateTime1 = dateTime1.Date;
          DateTime t2 = dateTime1.AddYears(1);
          if ((uint) DateTime.Compare(t1, t2) > 0U)
          {
            MessageText += "\r\n\r\nYou have changed the last service date, do you wish to continue?";
            string[] strArray = new string[6]
            {
              "Updated ",
              Combo.get_GetSelectedItemDescription(this.cboFuel),
              ", changed service due date from ",
              null,
              null,
              null
            };
            dateTime1 = Conversions.ToDate(dataRow["LastServiceDate"]);
            dateTime1 = dateTime1.Date;
            strArray[3] = Conversions.ToString(dateTime1.AddYears(1));
            strArray[4] = " to ";
            dateTime1 = this.dtpLastServiceDate.Value;
            dateTime1 = dateTime1.Date;
            strArray[5] = Conversions.ToString(dateTime1.AddYears(1));
            actionChange = string.Concat(strArray);
          }
          dateTime1 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["ActualServiceDate"]));
          DateTime date1 = dateTime1.Date;
          dateTime1 = this.dtpActualServiceDate.Value;
          DateTime date2 = dateTime1.Date;
          if ((uint) DateTime.Compare(date1, date2) > 0U)
          {
            MessageText += "\r\n\r\nYou have changed the service date, do you wish to continue?";
            string[] strArray = new string[6]
            {
              "Updated ",
              Combo.get_GetSelectedItemDescription(this.cboFuel),
              ", changed service date from ",
              null,
              null,
              null
            };
            dateTime1 = Conversions.ToDate(dataRow["ActualServiceDate"]);
            strArray[3] = Conversions.ToString(dateTime1.Date);
            strArray[4] = " to ";
            dateTime1 = this.dtpLastServiceDate.Value;
            strArray[5] = Conversions.ToString(dateTime1.Date);
            actionChange = string.Concat(strArray);
          }
          if (Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboChargeType)) != Conversions.ToInteger(dataRow["SiteFuelChargeID"]))
            actionChange = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Updated " + Combo.get_GetSelectedItemDescription(this.cboFuel) + ", changed contract charge type from "), dataRow["FuelChargeType"]), (object) " to "), (object) Combo.get_GetSelectedItemDescription(this.cboChargeType)));
          else
            num2 = Conversions.ToInteger(dataRow["SiteFuelChargeID"]);
          checked { ++index; }
        }
        if (App.ShowMessage(MessageText, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
      }
      SiteFuel siteFuel1 = App.DB.Sites.SiteFuel_Get(siteFuelId);
      if (siteFuel1 == null)
      {
        siteFuel1 = new SiteFuel();
        if (App.ShowMessage("Use dates selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          flag = true;
      }
      SiteFuel siteFuel2 = siteFuel1;
      siteFuel2.SetSiteFuelID = (object) siteFuelId;
      siteFuel2.SetSiteID = (object) this.CurrentSite.SiteID;
      siteFuel2.SetFuelID = (object) num1;
      if (flag)
      {
        siteFuel2.LastServiceDate = (DateTime) SqlDateTime.MinValue;
        siteFuel2.ActualServiceDate = (DateTime) SqlDateTime.MinValue;
      }
      else
      {
        SiteFuel siteFuel3 = siteFuel2;
        dateTime1 = this.dtpLastServiceDate.Value;
        DateTime dateTime2 = dateTime1.AddYears(-1);
        siteFuel3.LastServiceDate = dateTime2;
        siteFuel2.ActualServiceDate = this.dtpActualServiceDate.Value;
      }
      siteFuel2.SetSiteFuelChargeID = (object) num2;
      try
      {
        if (!App.DB.Sites.SiteFuel_Update(siteFuel1))
          throw new Exception("Failed to save!");
        dateTime1 = this.CurrentSite.LastServiceDate;
        if (DateTime.Compare(dateTime1.Date, siteFuel1.LastServiceDate) < 0)
          App.DB.Sites.Site_UpdateLastServiceDate(this.CurrentSite.SiteID, siteFuel1.LastServiceDate, siteFuel1.ActualServiceDate, true);
        else if (App.ShowMessage("Service due date on site is later than fuel.\r\n\r\nDo you want to update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          App.DB.Sites.Site_UpdateLastServiceDate(this.CurrentSite.SiteID, siteFuel1.LastServiceDate, siteFuel1.ActualServiceDate, true);
        if (!string.IsNullOrEmpty(actionChange))
          App.DB.Sites.SiteFuelAudit_Insert(this.CurrentSite.SiteID, actionChange);
        this.PopulateSiteFuelDataGrid();
        this.PopulateSiteAuditFuelDataGrid();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num3 = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void dgSiteFuel_Click(object sender, EventArgs e)
    {
      if (this.SelectedSiteFuelDataRow == null)
        return;
      ComboBox cboFuel = this.cboFuel;
      Combo.SetSelectedComboItem_By_Value(ref cboFuel, Conversions.ToString(this.SelectedSiteFuelDataRow["FuelID"]));
      this.cboFuel = cboFuel;
      ComboBox cboChargeType = this.cboChargeType;
      Combo.SetSelectedComboItem_By_Value(ref cboChargeType, Conversions.ToString(this.SelectedSiteFuelDataRow["SiteFuelChargeID"]));
      this.cboChargeType = cboChargeType;
      this.dtpLastServiceDate.Value = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedSiteFuelDataRow["LastServiceDate"])).AddYears(1);
      this.dtpActualServiceDate.Value = Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelectedSiteFuelDataRow["ActualServiceDate"])) ? Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedSiteFuelDataRow["LastServiceDate"])) : Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedSiteFuelDataRow["ActualServiceDate"]));
      this.txtAddedByText.Text = Conversions.ToString(this.SelectedSiteFuelDataRow["Fullname"]);
      this.txtAddedOn.Text = Conversions.ToString(Conversions.ToDate(this.SelectedSiteFuelDataRow["DateAdded"]).Date);
    }

    private void btnDeleteSiteFuel_Click(object sender, EventArgs e)
    {
      if (this.SelectedSiteFuelDataRow == null)
        return;
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Servicing))
        throw new SecurityException("You do not have the necessary security permissions.");
      if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Remove ", this.SelectedSiteFuelDataRow["FuelType"]), (object) "?"), (object) "\r\n"), (object) "\r\n"), (object) "Are you sure?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      int siteFuelId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSiteFuelDataRow["SiteFuelID"]));
      try
      {
        if (!App.DB.Sites.SiteFuel_Delete(siteFuelId))
          throw new Exception("Failed to delete!");
        string actionChange = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.SelectedSiteFuelDataRow["FuelType"], (object) " removed"));
        if (!string.IsNullOrEmpty(actionChange))
          App.DB.Sites.SiteFuelAudit_Insert(this.CurrentSite.SiteID, actionChange);
        this.PopulateSiteFuelDataGrid();
        this.PopulateSiteAuditFuelDataGrid();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
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

    private void dgSiteFuel_Leave(object sender, EventArgs e)
    {
      this.ttSiteFuel.Hide((IWin32Window) this.dgSiteFuel);
    }

    private void PopulateSiteFuelDataGrid()
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

    private void PopulateSiteAuditFuelDataGrid()
    {
      try
      {
        this.SiteFuelAuditDataView = App.DB.Sites.SiteFuelAudit_Get(this.CurrentSite.SiteID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnUpdateSiteService_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Servicing))
        throw new SecurityException("You do not have the necessary security permissions.");
      FRMLastServiceDate frmLastServiceDate = (FRMLastServiceDate) App.ShowForm(typeof (FRMLastServiceDate), true, new object[1]
      {
        (object) this.CurrentSite.SiteID
      }, false);
    }
  }
}
