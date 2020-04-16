// Decompiled with JetBrains decompiler
// Type: FSM.FRMJobManager
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
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMJobManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private int count;
    private DataView _dvJobs;
    private FSM.Entity.Customers.Customer _theCustomer;
    private FSM.Entity.Sites.Site _oSite;

    public FRMJobManager()
    {
      this.Load += new EventHandler(this.FRMJobManager_Load);
      this.count = 0;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlFilters { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpCustomerSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnReset
    {
      get
      {
        return this._btnReset;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnReset_Click);
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

    internal virtual GroupBox grpMiscSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpDateCriteria { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rdoNoDate
    {
      get
      {
        return this._rdoNoDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoNoDate_CheckedChanged);
        RadioButton rdoNoDate1 = this._rdoNoDate;
        if (rdoNoDate1 != null)
          rdoNoDate1.CheckedChanged -= eventHandler;
        this._rdoNoDate = value;
        RadioButton rdoNoDate2 = this._rdoNoDate;
        if (rdoNoDate2 == null)
          return;
        rdoNoDate2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rdoDateCreated
    {
      get
      {
        return this._rdoDateCreated;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoDateCreated_CheckChanged);
        RadioButton rdoDateCreated1 = this._rdoDateCreated;
        if (rdoDateCreated1 != null)
          rdoDateCreated1.CheckedChanged -= eventHandler;
        this._rdoDateCreated = value;
        RadioButton rdoDateCreated2 = this._rdoDateCreated;
        if (rdoDateCreated2 == null)
          return;
        rdoDateCreated2.CheckedChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDateFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDateTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPONumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbPoNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkNotShut { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label lblProperty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual DataGrid dgJobs
    {
      get
      {
        return this._dgJobs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgJobs_DoubleClick);
        DataGrid dgJobs1 = this._dgJobs;
        if (dgJobs1 != null)
          dgJobs1.DoubleClick -= eventHandler;
        this._dgJobs = value;
        DataGrid dgJobs2 = this._dgJobs;
        if (dgJobs2 == null)
          return;
        dgJobs2.DoubleClick += eventHandler;
      }
    }

    internal virtual Label lblRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobs = new GroupBox();
      this.dgJobs = new DataGrid();
      this.pnlFilters = new Panel();
      this.btnExport = new Button();
      this.grpCustomerSearch = new GroupBox();
      this.btnFindSite = new Button();
      this.txtSite = new TextBox();
      this.lblProperty = new Label();
      this.lblCustomer = new Label();
      this.lblPostcode = new Label();
      this.txtPostcode = new TextBox();
      this.txtCustomer = new TextBox();
      this.btnFindCustomer = new Button();
      this.btnReset = new Button();
      this.btnSearch = new Button();
      this.grpMiscSearch = new GroupBox();
      this.lblRegion = new Label();
      this.cboRegion = new ComboBox();
      this.chkNotShut = new CheckBox();
      this.txtPONumber = new TextBox();
      this.lbPoNumber = new Label();
      this.cboStatus = new ComboBox();
      this.lblVisitStatus = new Label();
      this.cboType = new ComboBox();
      this.lblType = new Label();
      this.txtJobNumber = new TextBox();
      this.lblJobNumber = new Label();
      this.grpDateCriteria = new GroupBox();
      this.rdoNoDate = new RadioButton();
      this.rdoDateCreated = new RadioButton();
      this.dtpFrom = new DateTimePicker();
      this.lblDateFrom = new Label();
      this.lblDateTo = new Label();
      this.dtpTo = new DateTimePicker();
      this.grpJobs.SuspendLayout();
      this.dgJobs.BeginInit();
      this.pnlFilters.SuspendLayout();
      this.grpCustomerSearch.SuspendLayout();
      this.grpMiscSearch.SuspendLayout();
      this.grpDateCriteria.SuspendLayout();
      this.SuspendLayout();
      this.grpJobs.Controls.Add((Control) this.dgJobs);
      this.grpJobs.Dock = DockStyle.Fill;
      this.grpJobs.Location = new System.Drawing.Point(0, 247);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(1338, 354);
      this.grpJobs.TabIndex = 44;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Results (awaiting search) - Double Click To View / Edit";
      this.dgJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgJobs.DataMember = "";
      this.dgJobs.HeaderForeColor = SystemColors.ControlText;
      this.dgJobs.Location = new System.Drawing.Point(6, 23);
      this.dgJobs.Name = "dgJobs";
      this.dgJobs.Size = new Size(1326, 298);
      this.dgJobs.TabIndex = 15;
      this.pnlFilters.Controls.Add((Control) this.btnExport);
      this.pnlFilters.Controls.Add((Control) this.grpCustomerSearch);
      this.pnlFilters.Controls.Add((Control) this.btnReset);
      this.pnlFilters.Controls.Add((Control) this.btnSearch);
      this.pnlFilters.Controls.Add((Control) this.grpMiscSearch);
      this.pnlFilters.Controls.Add((Control) this.grpDateCriteria);
      this.pnlFilters.Dock = DockStyle.Top;
      this.pnlFilters.Location = new System.Drawing.Point(0, 0);
      this.pnlFilters.Name = "pnlFilters";
      this.pnlFilters.Size = new Size(1338, 247);
      this.pnlFilters.TabIndex = 43;
      this.btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnExport.Location = new System.Drawing.Point(964, 218);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(118, 23);
      this.btnExport.TabIndex = 40;
      this.btnExport.Text = "Export";
      this.btnExport.UseVisualStyleBackColor = true;
      this.grpCustomerSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCustomerSearch.Controls.Add((Control) this.btnFindSite);
      this.grpCustomerSearch.Controls.Add((Control) this.txtSite);
      this.grpCustomerSearch.Controls.Add((Control) this.lblProperty);
      this.grpCustomerSearch.Controls.Add((Control) this.lblCustomer);
      this.grpCustomerSearch.Controls.Add((Control) this.lblPostcode);
      this.grpCustomerSearch.Controls.Add((Control) this.txtPostcode);
      this.grpCustomerSearch.Controls.Add((Control) this.txtCustomer);
      this.grpCustomerSearch.Controls.Add((Control) this.btnFindCustomer);
      this.grpCustomerSearch.Location = new System.Drawing.Point(4, 3);
      this.grpCustomerSearch.Name = "grpCustomerSearch";
      this.grpCustomerSearch.Size = new Size(943, 105);
      this.grpCustomerSearch.TabIndex = 37;
      this.grpCustomerSearch.TabStop = false;
      this.grpCustomerSearch.Text = "Customer";
      this.btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSite.BackColor = Color.White;
      this.btnFindSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSite.Location = new System.Drawing.Point(912, 43);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(25, 23);
      this.btnFindSite.TabIndex = 35;
      this.btnFindSite.Text = "...";
      this.btnFindSite.UseVisualStyleBackColor = false;
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSite.Location = new System.Drawing.Point(107, 45);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(800, 21);
      this.txtSite.TabIndex = 34;
      this.lblProperty.Location = new System.Drawing.Point(11, 44);
      this.lblProperty.Name = "lblProperty";
      this.lblProperty.Size = new Size(65, 22);
      this.lblProperty.TabIndex = 33;
      this.lblProperty.Text = "Property";
      this.lblCustomer.Location = new System.Drawing.Point(11, 17);
      this.lblCustomer.Name = "lblCustomer";
      this.lblCustomer.Size = new Size(64, 16);
      this.lblCustomer.TabIndex = 27;
      this.lblCustomer.Text = "Customer";
      this.lblPostcode.Location = new System.Drawing.Point(11, 75);
      this.lblPostcode.Name = "lblPostcode";
      this.lblPostcode.Size = new Size(64, 16);
      this.lblPostcode.TabIndex = 20;
      this.lblPostcode.Text = "Postcode";
      this.txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPostcode.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPostcode.Location = new System.Drawing.Point(107, 72);
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(830, 21);
      this.txtPostcode.TabIndex = 5;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(107, 18);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(800, 21);
      this.txtCustomer.TabIndex = 1;
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(912, 17);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(25, 23);
      this.btnFindCustomer.TabIndex = 2;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnReset.Location = new System.Drawing.Point(1088, 218);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(118, 23);
      this.btnReset.TabIndex = 16;
      this.btnReset.Text = "Reset All Filters";
      this.btnReset.UseVisualStyleBackColor = true;
      this.btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSearch.Location = new System.Drawing.Point(1212, 218);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(114, 23);
      this.btnSearch.TabIndex = 39;
      this.btnSearch.Text = "Search";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.grpMiscSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.grpMiscSearch.Controls.Add((Control) this.lblRegion);
      this.grpMiscSearch.Controls.Add((Control) this.cboRegion);
      this.grpMiscSearch.Controls.Add((Control) this.chkNotShut);
      this.grpMiscSearch.Controls.Add((Control) this.txtPONumber);
      this.grpMiscSearch.Controls.Add((Control) this.lbPoNumber);
      this.grpMiscSearch.Controls.Add((Control) this.cboStatus);
      this.grpMiscSearch.Controls.Add((Control) this.lblVisitStatus);
      this.grpMiscSearch.Controls.Add((Control) this.cboType);
      this.grpMiscSearch.Controls.Add((Control) this.lblType);
      this.grpMiscSearch.Controls.Add((Control) this.txtJobNumber);
      this.grpMiscSearch.Controls.Add((Control) this.lblJobNumber);
      this.grpMiscSearch.Location = new System.Drawing.Point(957, 3);
      this.grpMiscSearch.Name = "grpMiscSearch";
      this.grpMiscSearch.Size = new Size(367, 209);
      this.grpMiscSearch.TabIndex = 38;
      this.grpMiscSearch.TabStop = false;
      this.grpMiscSearch.Text = "Misc";
      this.lblRegion.Location = new System.Drawing.Point(8, 77);
      this.lblRegion.Name = "lblRegion";
      this.lblRegion.Size = new Size(88, 16);
      this.lblRegion.TabIndex = 28;
      this.lblRegion.Text = "Region";
      this.cboRegion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegion.Location = new System.Drawing.Point(102, 74);
      this.cboRegion.Name = "cboRegion";
      this.cboRegion.Size = new Size(259, 21);
      this.cboRegion.TabIndex = 27;
      this.chkNotShut.CheckAlign = ContentAlignment.MiddleRight;
      this.chkNotShut.Location = new System.Drawing.Point(102, 155);
      this.chkNotShut.Name = "chkNotShut";
      this.chkNotShut.Size = new Size(245, 32);
      this.chkNotShut.TabIndex = 26;
      this.chkNotShut.Text = "Only Show Jobs which are not completely shutdown";
      this.chkNotShut.UseVisualStyleBackColor = true;
      this.txtPONumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPONumber.Location = new System.Drawing.Point(102, 128);
      this.txtPONumber.Name = "txtPONumber";
      this.txtPONumber.Size = new Size(259, 21);
      this.txtPONumber.TabIndex = 12;
      this.lbPoNumber.Location = new System.Drawing.Point(8, 128);
      this.lbPoNumber.Name = "lbPoNumber";
      this.lbPoNumber.Size = new Size(88, 16);
      this.lbPoNumber.TabIndex = 11;
      this.lbPoNumber.Text = "PO Number";
      this.cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Location = new System.Drawing.Point(102, 47);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(259, 21);
      this.cboStatus.TabIndex = 8;
      this.lblVisitStatus.Location = new System.Drawing.Point(8, 50);
      this.lblVisitStatus.Name = "lblVisitStatus";
      this.lblVisitStatus.Size = new Size(88, 16);
      this.lblVisitStatus.TabIndex = 5;
      this.lblVisitStatus.Text = "Visit Status";
      this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(102, 20);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(259, 21);
      this.cboType.TabIndex = 7;
      this.lblType.Location = new System.Drawing.Point(8, 20);
      this.lblType.Name = "lblType";
      this.lblType.Size = new Size(48, 16);
      this.lblType.TabIndex = 4;
      this.lblType.Text = "Type";
      this.txtJobNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtJobNumber.Location = new System.Drawing.Point(102, 101);
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.Size = new Size(259, 21);
      this.txtJobNumber.TabIndex = 9;
      this.lblJobNumber.Location = new System.Drawing.Point(8, 101);
      this.lblJobNumber.Name = "lblJobNumber";
      this.lblJobNumber.Size = new Size(79, 16);
      this.lblJobNumber.TabIndex = 6;
      this.lblJobNumber.Text = "Job Number";
      this.grpDateCriteria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpDateCriteria.Controls.Add((Control) this.rdoNoDate);
      this.grpDateCriteria.Controls.Add((Control) this.rdoDateCreated);
      this.grpDateCriteria.Controls.Add((Control) this.dtpFrom);
      this.grpDateCriteria.Controls.Add((Control) this.lblDateFrom);
      this.grpDateCriteria.Controls.Add((Control) this.lblDateTo);
      this.grpDateCriteria.Controls.Add((Control) this.dtpTo);
      this.grpDateCriteria.Location = new System.Drawing.Point(4, 114);
      this.grpDateCriteria.Name = "grpDateCriteria";
      this.grpDateCriteria.Size = new Size(943, 98);
      this.grpDateCriteria.TabIndex = 36;
      this.grpDateCriteria.TabStop = false;
      this.grpDateCriteria.Text = "Date Criteria";
      this.rdoNoDate.AutoSize = true;
      this.rdoNoDate.Checked = true;
      this.rdoNoDate.Location = new System.Drawing.Point(8, 28);
      this.rdoNoDate.Name = "rdoNoDate";
      this.rdoNoDate.Size = new Size(54, 17);
      this.rdoNoDate.TabIndex = 11;
      this.rdoNoDate.TabStop = true;
      this.rdoNoDate.Text = "None";
      this.rdoNoDate.UseVisualStyleBackColor = true;
      this.rdoDateCreated.AutoSize = true;
      this.rdoDateCreated.Location = new System.Drawing.Point(8, 48);
      this.rdoDateCreated.Name = "rdoDateCreated";
      this.rdoDateCreated.Size = new Size(102, 17);
      this.rdoDateCreated.TabIndex = 12;
      this.rdoDateCreated.Text = "Date Created";
      this.rdoDateCreated.UseVisualStyleBackColor = true;
      this.dtpFrom.Location = new System.Drawing.Point(230, 30);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(169, 21);
      this.dtpFrom.TabIndex = 14;
      this.lblDateFrom.Location = new System.Drawing.Point(176, 32);
      this.lblDateFrom.Name = "lblDateFrom";
      this.lblDateFrom.Size = new Size(48, 16);
      this.lblDateFrom.TabIndex = 9;
      this.lblDateFrom.Text = "From";
      this.lblDateTo.Location = new System.Drawing.Point(176, 57);
      this.lblDateTo.Name = "lblDateTo";
      this.lblDateTo.Size = new Size(48, 16);
      this.lblDateTo.TabIndex = 10;
      this.lblDateTo.Text = "To";
      this.dtpTo.Location = new System.Drawing.Point(230, 57);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(169, 21);
      this.dtpTo.TabIndex = 15;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1338, 601);
      this.Controls.Add((Control) this.grpJobs);
      this.Controls.Add((Control) this.pnlFilters);
      this.MinimumSize = new Size(808, 528);
      this.Name = nameof (FRMJobManager);
      this.Text = "Job Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.pnlFilters, 0);
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.grpJobs.ResumeLayout(false);
      this.dgJobs.EndInit();
      this.pnlFilters.ResumeLayout(false);
      this.grpCustomerSearch.ResumeLayout(false);
      this.grpCustomerSearch.PerformLayout();
      this.grpMiscSearch.ResumeLayout(false);
      this.grpMiscSearch.PerformLayout();
      this.grpDateCriteria.ResumeLayout(false);
      this.grpDateCriteria.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupJobsDataGrid();
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboStatus = cboStatus;
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboType = cboType;
      ComboBox cboRegion = this.cboRegion;
      Combo.SetUpCombo(ref cboRegion, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboRegion = cboRegion;
      this.rdoDateCreated.Checked = true;
      this.dtpFrom.Value = DateAndTime.Now.AddMonths(-1);
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

    private DataView JobsDataview
    {
      get
      {
        return this._dvJobs;
      }
      set
      {
        this._dvJobs = value;
        if (this.JobsDataview != null)
        {
          this._dvJobs.AllowNew = false;
          this._dvJobs.AllowEdit = false;
          this._dvJobs.AllowDelete = false;
          this._dvJobs.Table.TableName = Enums.TableNames.tblJob.ToString();
        }
        this.dgJobs.DataSource = (object) this.JobsDataview;
        if (this.JobsDataview == null || this.JobsDataview.Table.Rows.Count <= 0)
          return;
        this.dgJobs.Select(0);
      }
    }

    private DataRow SelectedJobsDataRow
    {
      get
      {
        return this.JobsDataview == null || this.dgJobs.CurrentRowIndex == -1 ? (DataRow) null : this.JobsDataview[this.dgJobs.CurrentRowIndex].Row;
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

    private void SetupJobsDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgJobs.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MMM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Date Created";
      dataGridLabelColumn1.MappingName = "DateCreated";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Customer";
      dataGridLabelColumn2.MappingName = "Customer";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 170;
      dataGridLabelColumn2.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Name";
      dataGridLabelColumn3.MappingName = "Name";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 170;
      dataGridLabelColumn3.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Property";
      dataGridLabelColumn4.MappingName = "Site";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 170;
      dataGridLabelColumn4.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Postcode";
      dataGridLabelColumn5.MappingName = "SitePostcode";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 170;
      dataGridLabelColumn5.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Job Number";
      dataGridLabelColumn6.MappingName = "JobNumber";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 90;
      dataGridLabelColumn6.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Tel";
      dataGridLabelColumn7.MappingName = "Telephone";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 110;
      dataGridLabelColumn7.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Mobile";
      dataGridLabelColumn8.MappingName = "Mobile";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 110;
      dataGridLabelColumn8.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Type";
      dataGridLabelColumn9.MappingName = "Type";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 110;
      dataGridLabelColumn9.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Contract Type";
      dataGridLabelColumn10.MappingName = "ContractType";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 170;
      dataGridLabelColumn10.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Visit Statuses";
      dataGridLabelColumn11.MappingName = "VisitStatuses";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 170;
      dataGridLabelColumn11.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "Initial Description";
      dataGridLabelColumn12.MappingName = "NotesToEngineer";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 170;
      dataGridLabelColumn12.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "Last Outcome Details";
      dataGridLabelColumn13.MappingName = "OutcomeDetails";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 170;
      dataGridLabelColumn13.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      DataGridLabelColumn dataGridLabelColumn14 = new DataGridLabelColumn();
      dataGridLabelColumn14.Format = "";
      dataGridLabelColumn14.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn14.HeaderText = "Created By";
      dataGridLabelColumn14.MappingName = "CreatedBy";
      dataGridLabelColumn14.ReadOnly = true;
      dataGridLabelColumn14.Width = 170;
      dataGridLabelColumn14.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn14);
      DataGridLabelColumn dataGridLabelColumn15 = new DataGridLabelColumn();
      dataGridLabelColumn15.Format = "";
      dataGridLabelColumn15.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn15.HeaderText = "Job Status";
      dataGridLabelColumn15.MappingName = "JobStatus";
      dataGridLabelColumn15.ReadOnly = true;
      dataGridLabelColumn15.Width = 120;
      dataGridLabelColumn15.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn15);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblJob.ToString();
      this.dgJobs.TableStyles.Add(tableStyle);
    }

    private void FRMJobManager_Load(object sender, EventArgs e)
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

    private void BtnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void rdoDateCreated_CheckChanged(object sender, EventArgs e)
    {
      this.dtpFrom.Enabled = this.rdoDateCreated.Checked;
      this.dtpTo.Enabled = this.rdoDateCreated.Checked;
    }

    private void rdoNoDate_CheckedChanged(object sender, EventArgs e)
    {
      this.dtpFrom.Enabled = !this.rdoNoDate.Checked;
      this.dtpTo.Enabled = !this.rdoNoDate.Checked;
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      if (this.rdoNoDate.Checked)
      {
        if (App.ShowMessage("No date range is selected, please make sure other fields are selected as this may pull all the files from the database and crash your system, would you like to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
          return;
        this.PopulateDatagrid(true);
      }
      else
        this.PopulateDatagrid(true);
    }

    private void dgJobs_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedJobsDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a visit to view", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
        App.ShowForm(typeof (FRMLogCallout), true, new object[3]
        {
          this.SelectedJobsDataRow["JobID"],
          this.SelectedJobsDataRow["SiteID"],
          (object) this
        }, false);
    }

    public void PopulateDatagrid(bool withRun)
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        if (this.get_GetParameter(0) == null)
        {
          DateTime minValue1 = DateTime.MinValue;
          DateTime minValue2 = DateTime.MinValue;
          int customerId = this.theCustomer != null ? this.theCustomer.CustomerID : 0;
          int siteId = this.theSite != null ? this.theSite.SiteID : 0;
          string postcode = this.txtPostcode.Text.Trim().Length > 0 ? this.txtPostcode.Text : (string) null;
          int integer1 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType));
          int integer2 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboStatus));
          int integer3 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboRegion));
          string jobNumber = this.txtJobNumber.Text.Trim().Length != 0 ? Helper.CleanText(this.txtJobNumber.Text.Trim()) : (string) null;
          string poNumber = this.txtPONumber.Text.Trim().Length != 0 ? Helper.CleanText(this.txtPONumber.Text.Trim()) : (string) null;
          bool isJobOpen = this.chkNotShut.Checked;
          if (this.rdoDateCreated.Checked)
          {
            minValue1 = this.dtpFrom.Value;
            minValue2 = this.dtpTo.Value;
          }
          this.JobsDataview = App.DB.Job.Job_Manager_Search(minValue1, minValue2, jobNumber, postcode, integer1, customerId, siteId, integer2, integer3, poNumber, isJobOpen);
          this.count = this.JobsDataview.Count;
          this.grpJobs.Text = "Double Click To View / Edit (" + Conversions.ToString(this.count) + ")";
        }
        else
          this.JobsDataview = (DataView) null;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
    }

    private void ResetFilters()
    {
      this.theCustomer = (FSM.Entity.Customers.Customer) null;
      this.theSite = (FSM.Entity.Sites.Site) null;
      ComboBox cboType = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType, Conversions.ToString(0));
      this.cboType = cboType;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(0));
      this.cboStatus = cboStatus;
      this.txtJobNumber.Text = "";
      this.txtPONumber.Text = "";
      this.txtPostcode.Text = "";
      this.rdoDateCreated.Checked = true;
      this.dtpFrom.Value = DateAndTime.Today;
      this.dtpTo.Value = DateAndTime.Today;
      this.dtpFrom.Enabled = true;
      this.dtpTo.Enabled = true;
      this.dtpFrom.Value = DateAndTime.Now.AddMonths(-1);
      this.chkNotShut.Checked = false;
    }

    public void Export()
    {
      if (this.JobsDataview == null)
        return;
      ExportHelper.Export(this.JobsDataview.Table, "Job Manager", Enums.ExportType.XLS);
    }
  }
}
