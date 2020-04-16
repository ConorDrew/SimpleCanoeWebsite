// Decompiled with JetBrains decompiler
// Type: FSM.FRMLetterManagerMK3
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisits;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FRMLetterManagerMK3 : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataTable Avail;
    private DataView AvailView;
    private int amtServ;
    private bool profile;
    private bool siteOnly;
    private List<string> Postcodes;
    private DataView _dvServiceDue;
    private FSM.Entity.Customers.Customer _theCustomer;

    public FRMLetterManagerMK3()
    {
      this.Load += new EventHandler(this.FRMLetterManagerMK3_Load);
      this.Avail = new DataTable();
      this.AvailView = new DataView();
      this.amtServ = 0;
      this.profile = false;
      this.siteOnly = false;
      this.Postcodes = new List<string>();
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpServices = new GroupBox();
      this.dgServicesDue = new DataGrid();
      this.btnResetFilters = new Button();
      this.grpFilters = new GroupBox();
      this.chkIncludePatchChecks = new CheckBox();
      this.chkVoidProperty = new CheckBox();
      this.chkLastService = new CheckBox();
      this.txtTravelBetween = new TextBox();
      this.Label3 = new Label();
      this.txtMaxTravel = new TextBox();
      this.Label2 = new Label();
      this.chkLettersOnly = new CheckBox();
      this.tbMinsPerDay = new TextBox();
      this.cboLetterNumber = new ComboBox();
      this.lbMinsPerDay = new Label();
      this.Label14 = new Label();
      this.btnFilter = new Button();
      this.Label1 = new Label();
      this.dtpLetterCreateDate = new DateTimePicker();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.Label4 = new Label();
      this.btnSelectAll = new Button();
      this.btnUnselect = new Button();
      this.btnGenerateLetters = new Button();
      this.btnReleaseLockedSites = new Button();
      this.btnFindSite = new Button();
      this.grpServices.SuspendLayout();
      this.dgServicesDue.BeginInit();
      this.grpFilters.SuspendLayout();
      this.SuspendLayout();
      this.grpServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpServices.Controls.Add((Control) this.dgServicesDue);
      this.grpServices.Location = new System.Drawing.Point(12, 180);
      this.grpServices.Name = "grpServices";
      this.grpServices.Size = new Size(1264, 383);
      this.grpServices.TabIndex = 3;
      this.grpServices.TabStop = false;
      this.grpServices.Text = "Services Due";
      this.dgServicesDue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgServicesDue.DataMember = "";
      this.dgServicesDue.HeaderForeColor = SystemColors.ControlText;
      this.dgServicesDue.Location = new System.Drawing.Point(16, 20);
      this.dgServicesDue.Name = "dgServicesDue";
      this.dgServicesDue.Size = new Size(1248, 355);
      this.dgServicesDue.TabIndex = 14;
      this.btnResetFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnResetFilters.Location = new System.Drawing.Point(20, 569);
      this.btnResetFilters.Name = "btnResetFilters";
      this.btnResetFilters.Size = new Size(111, 23);
      this.btnResetFilters.TabIndex = 4;
      this.btnResetFilters.Text = "Reset Filters";
      this.btnResetFilters.UseVisualStyleBackColor = true;
      this.grpFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilters.Controls.Add((Control) this.chkIncludePatchChecks);
      this.grpFilters.Controls.Add((Control) this.chkVoidProperty);
      this.grpFilters.Controls.Add((Control) this.chkLastService);
      this.grpFilters.Controls.Add((Control) this.txtTravelBetween);
      this.grpFilters.Controls.Add((Control) this.Label3);
      this.grpFilters.Controls.Add((Control) this.txtMaxTravel);
      this.grpFilters.Controls.Add((Control) this.Label2);
      this.grpFilters.Controls.Add((Control) this.chkLettersOnly);
      this.grpFilters.Controls.Add((Control) this.tbMinsPerDay);
      this.grpFilters.Controls.Add((Control) this.cboLetterNumber);
      this.grpFilters.Controls.Add((Control) this.lbMinsPerDay);
      this.grpFilters.Controls.Add((Control) this.Label14);
      this.grpFilters.Controls.Add((Control) this.btnFilter);
      this.grpFilters.Controls.Add((Control) this.Label1);
      this.grpFilters.Controls.Add((Control) this.dtpLetterCreateDate);
      this.grpFilters.Controls.Add((Control) this.btnFindCustomer);
      this.grpFilters.Controls.Add((Control) this.txtCustomer);
      this.grpFilters.Controls.Add((Control) this.Label4);
      this.grpFilters.Location = new System.Drawing.Point(12, 38);
      this.grpFilters.Name = "grpFilters";
      this.grpFilters.Size = new Size(1264, 107);
      this.grpFilters.TabIndex = 5;
      this.grpFilters.TabStop = false;
      this.grpFilters.Text = "Filters";
      this.chkIncludePatchChecks.AutoSize = true;
      this.chkIncludePatchChecks.Location = new System.Drawing.Point(911, 78);
      this.chkIncludePatchChecks.Name = "chkIncludePatchChecks";
      this.chkIncludePatchChecks.Size = new Size(149, 17);
      this.chkIncludePatchChecks.TabIndex = 50;
      this.chkIncludePatchChecks.Text = "Include Patch Checks";
      this.chkIncludePatchChecks.UseVisualStyleBackColor = true;
      this.chkVoidProperty.AutoSize = true;
      this.chkVoidProperty.Checked = true;
      this.chkVoidProperty.CheckState = CheckState.Checked;
      this.chkVoidProperty.Location = new System.Drawing.Point(755, 78);
      this.chkVoidProperty.Name = "chkVoidProperty";
      this.chkVoidProperty.Size = new Size(147, 17);
      this.chkVoidProperty.TabIndex = 49;
      this.chkVoidProperty.Text = "Show Void Properties";
      this.chkVoidProperty.UseVisualStyleBackColor = true;
      this.chkLastService.AutoSize = true;
      this.chkLastService.Location = new System.Drawing.Point(755, 51);
      this.chkLastService.Name = "chkLastService";
      this.chkLastService.Size = new Size(150, 17);
      this.chkLastService.TabIndex = 48;
      this.chkLastService.Text = "Prioritise Last Service";
      this.chkLastService.UseVisualStyleBackColor = true;
      this.txtTravelBetween.Cursor = Cursors.Default;
      this.txtTravelBetween.Location = new System.Drawing.Point(686, 76);
      this.txtTravelBetween.Name = "txtTravelBetween";
      this.txtTravelBetween.Size = new Size(53, 21);
      this.txtTravelBetween.TabIndex = 46;
      this.txtTravelBetween.Text = "10";
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(465, 79);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(206, 13);
      this.Label3.TabIndex = 45;
      this.Label3.Text = "Max Travel Between AM/PM (Miles)";
      this.txtMaxTravel.Location = new System.Drawing.Point(390, 76);
      this.txtMaxTravel.Name = "txtMaxTravel";
      this.txtMaxTravel.Size = new Size(53, 21);
      this.txtMaxTravel.TabIndex = 44;
      this.txtMaxTravel.Text = "5";
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(210, 79);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(174, 13);
      this.Label2.TabIndex = 43;
      this.Label2.Text = "Max Travel Per Period (Miles)";
      this.chkLettersOnly.AutoSize = true;
      this.chkLettersOnly.Location = new System.Drawing.Point(911, 51);
      this.chkLettersOnly.Name = "chkLettersOnly";
      this.chkLettersOnly.Size = new Size(161, 17);
      this.chkLettersOnly.TabIndex = 42;
      this.chkLettersOnly.Text = "Print Booked Visits only";
      this.chkLettersOnly.UseVisualStyleBackColor = true;
      this.tbMinsPerDay.Location = new System.Drawing.Point(142, 76);
      this.tbMinsPerDay.Name = "tbMinsPerDay";
      this.tbMinsPerDay.Size = new Size(53, 21);
      this.tbMinsPerDay.TabIndex = 5;
      this.tbMinsPerDay.Text = "275";
      this.cboLetterNumber.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLetterNumber.Location = new System.Drawing.Point(368, 50);
      this.cboLetterNumber.Name = "cboLetterNumber";
      this.cboLetterNumber.Size = new Size(371, 21);
      this.cboLetterNumber.TabIndex = 41;
      this.lbMinsPerDay.AutoSize = true;
      this.lbMinsPerDay.Location = new System.Drawing.Point(6, 79);
      this.lbMinsPerDay.Name = "lbMinsPerDay";
      this.lbMinsPerDay.Size = new Size(132, 13);
      this.lbMinsPerDay.TabIndex = 4;
      this.lbMinsPerDay.Text = "Working Mins Per Day";
      this.Label14.Location = new System.Drawing.Point(296, 52);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(75, 16);
      this.Label14.TabIndex = 40;
      this.Label14.Text = "Letter No.";
      this.btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFilter.Location = new System.Drawing.Point(1181, 74);
      this.btnFilter.Name = "btnFilter";
      this.btnFilter.Size = new Size(75, 23);
      this.btnFilter.TabIndex = 30;
      this.btnFilter.Text = "Filter";
      this.btnFilter.UseVisualStyleBackColor = true;
      this.Label1.Location = new System.Drawing.Point(6, 52);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(130, 16);
      this.Label1.TabIndex = 29;
      this.Label1.Text = "Letter Create Date";
      this.dtpLetterCreateDate.Location = new System.Drawing.Point(142, 50);
      this.dtpLetterCreateDate.Name = "dtpLetterCreateDate";
      this.dtpLetterCreateDate.Size = new Size(138, 21);
      this.dtpLetterCreateDate.TabIndex = 28;
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(1224, 20);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 26;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(142, 22);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(1076, 21);
      this.txtCustomer.TabIndex = 25;
      this.Label4.Location = new System.Drawing.Point(6, 23);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 16);
      this.Label4.TabIndex = 27;
      this.Label4.Text = "Customer";
      this.btnSelectAll.Location = new System.Drawing.Point(12, 151);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(119, 23);
      this.btnSelectAll.TabIndex = 6;
      this.btnSelectAll.Text = "Select All";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.btnUnselect.Location = new System.Drawing.Point(154, 151);
      this.btnUnselect.Name = "btnUnselect";
      this.btnUnselect.Size = new Size(96, 23);
      this.btnUnselect.TabIndex = 7;
      this.btnUnselect.Text = "Unselect All";
      this.btnUnselect.UseVisualStyleBackColor = true;
      this.btnGenerateLetters.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnGenerateLetters.Location = new System.Drawing.Point(1110, 569);
      this.btnGenerateLetters.Name = "btnGenerateLetters";
      this.btnGenerateLetters.Size = new Size(158, 23);
      this.btnGenerateLetters.TabIndex = 8;
      this.btnGenerateLetters.Text = "Generate Letters";
      this.btnGenerateLetters.UseVisualStyleBackColor = true;
      this.btnReleaseLockedSites.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReleaseLockedSites.Location = new System.Drawing.Point(137, 569);
      this.btnReleaseLockedSites.Name = "btnReleaseLockedSites";
      this.btnReleaseLockedSites.Size = new Size(139, 23);
      this.btnReleaseLockedSites.TabIndex = 9;
      this.btnReleaseLockedSites.Text = "Release Locked Sites";
      this.btnReleaseLockedSites.UseVisualStyleBackColor = true;
      this.btnFindSite.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnFindSite.Location = new System.Drawing.Point(285, 569);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(111, 23);
      this.btnFindSite.TabIndex = 47;
      this.btnFindSite.Text = "Find Site";
      this.btnFindSite.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1288, 604);
      this.Controls.Add((Control) this.btnFindSite);
      this.Controls.Add((Control) this.btnReleaseLockedSites);
      this.Controls.Add((Control) this.btnGenerateLetters);
      this.Controls.Add((Control) this.btnUnselect);
      this.Controls.Add((Control) this.btnSelectAll);
      this.Controls.Add((Control) this.grpFilters);
      this.Controls.Add((Control) this.btnResetFilters);
      this.Controls.Add((Control) this.grpServices);
      this.Name = nameof (FRMLetterManagerMK3);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Letter Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpServices, 0);
      this.Controls.SetChildIndex((Control) this.btnResetFilters, 0);
      this.Controls.SetChildIndex((Control) this.grpFilters, 0);
      this.Controls.SetChildIndex((Control) this.btnSelectAll, 0);
      this.Controls.SetChildIndex((Control) this.btnUnselect, 0);
      this.Controls.SetChildIndex((Control) this.btnGenerateLetters, 0);
      this.Controls.SetChildIndex((Control) this.btnReleaseLockedSites, 0);
      this.Controls.SetChildIndex((Control) this.btnFindSite, 0);
      this.grpServices.ResumeLayout(false);
      this.dgServicesDue.EndInit();
      this.grpFilters.ResumeLayout(false);
      this.grpFilters.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox grpServices { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgServicesDue
    {
      get
      {
        return this._dgServicesDue;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgServicesDue_MouseClick);
        DataGrid dgServicesDue1 = this._dgServicesDue;
        if (dgServicesDue1 != null)
          dgServicesDue1.MouseClick -= mouseEventHandler;
        this._dgServicesDue = value;
        DataGrid dgServicesDue2 = this._dgServicesDue;
        if (dgServicesDue2 == null)
          return;
        dgServicesDue2.MouseClick += mouseEventHandler;
      }
    }

    internal virtual Button btnResetFilters
    {
      get
      {
        return this._btnResetFilters;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnResetFilters_Click);
        Button btnResetFilters1 = this._btnResetFilters;
        if (btnResetFilters1 != null)
          btnResetFilters1.Click -= eventHandler;
        this._btnResetFilters = value;
        Button btnResetFilters2 = this._btnResetFilters;
        if (btnResetFilters2 == null)
          return;
        btnResetFilters2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpFilters { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFilter
    {
      get
      {
        return this._btnFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFilter_Click);
        Button btnFilter1 = this._btnFilter;
        if (btnFilter1 != null)
          btnFilter1.Click -= eventHandler;
        this._btnFilter = value;
        Button btnFilter2 = this._btnFilter;
        if (btnFilter2 == null)
          return;
        btnFilter2.Click += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpLetterCreateDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnSelectAll
    {
      get
      {
        return this._btnSelectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSelectAll_Click);
        Button btnSelectAll1 = this._btnSelectAll;
        if (btnSelectAll1 != null)
          btnSelectAll1.Click -= eventHandler;
        this._btnSelectAll = value;
        Button btnSelectAll2 = this._btnSelectAll;
        if (btnSelectAll2 == null)
          return;
        btnSelectAll2.Click += eventHandler;
      }
    }

    internal virtual Button btnUnselect
    {
      get
      {
        return this._btnUnselect;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUnselect_Click);
        Button btnUnselect1 = this._btnUnselect;
        if (btnUnselect1 != null)
          btnUnselect1.Click -= eventHandler;
        this._btnUnselect = value;
        Button btnUnselect2 = this._btnUnselect;
        if (btnUnselect2 == null)
          return;
        btnUnselect2.Click += eventHandler;
      }
    }

    internal virtual Button btnGenerateLetters
    {
      get
      {
        return this._btnGenerateLetters;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnGenerateLetters_Click);
        Button btnGenerateLetters1 = this._btnGenerateLetters;
        if (btnGenerateLetters1 != null)
          btnGenerateLetters1.Click -= eventHandler;
        this._btnGenerateLetters = value;
        Button btnGenerateLetters2 = this._btnGenerateLetters;
        if (btnGenerateLetters2 == null)
          return;
        btnGenerateLetters2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboLetterNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox tbMinsPerDay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbMinsPerDay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkLettersOnly
    {
      get
      {
        return this._chkLettersOnly;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkLettersOnly_CheckedChanged);
        CheckBox chkLettersOnly1 = this._chkLettersOnly;
        if (chkLettersOnly1 != null)
          chkLettersOnly1.CheckedChanged -= eventHandler;
        this._chkLettersOnly = value;
        CheckBox chkLettersOnly2 = this._chkLettersOnly;
        if (chkLettersOnly2 == null)
          return;
        chkLettersOnly2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Button btnReleaseLockedSites
    {
      get
      {
        return this._btnReleaseLockedSites;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReleaseLockedSites_Click);
        Button releaseLockedSites1 = this._btnReleaseLockedSites;
        if (releaseLockedSites1 != null)
          releaseLockedSites1.Click -= eventHandler;
        this._btnReleaseLockedSites = value;
        Button releaseLockedSites2 = this._btnReleaseLockedSites;
        if (releaseLockedSites2 == null)
          return;
        releaseLockedSites2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtMaxTravel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTravelBetween { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkLastService { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual CheckBox chkVoidProperty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkIncludePatchChecks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboLetterNumber = this.cboLetterNumber;
      Combo.SetUpCombo(ref cboLetterNumber, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboLetterNumber = cboLetterNumber;
      this.cboLetterNumber.Items.RemoveAt(0);
      this.ResetFilters();
      this.SetupLettersDataGrid();
      this.WindowState = FormWindowState.Maximized;
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

    private DataView ServiceDueDataview
    {
      get
      {
        return this._dvServiceDue;
      }
      set
      {
        this._dvServiceDue = value;
        this._dvServiceDue.AllowNew = false;
        this._dvServiceDue.AllowEdit = false;
        this._dvServiceDue.AllowDelete = false;
        this._dvServiceDue.Table.TableName = "ServiceDue";
        this.dgServicesDue.DataSource = (object) this.ServiceDueDataview;
      }
    }

    private DataRow SelectedServiceDueDataRow
    {
      get
      {
        return this.dgServicesDue.CurrentRowIndex != -1 ? this.ServiceDueDataview[this.dgServicesDue.CurrentRowIndex].Row : (DataRow) null;
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
        if (this._theCustomer != null)
          this.txtCustomer.Text = this.theCustomer.Name + " (A/C No : " + this.theCustomer.AccountNumber + ")";
        else
          this.txtCustomer.Text = "";
      }
    }

    private void SetupLettersDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgServicesDue.TableStyles[0];
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "Send Letter";
      dataGridBoolColumn.MappingName = "SendLetterTick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 75;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 60;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridDistrictColumn gridDistrictColumn = new DataGridDistrictColumn();
      gridDistrictColumn.Format = "";
      gridDistrictColumn.FormatInfo = (IFormatProvider) null;
      gridDistrictColumn.HeaderText = "Fuel Type";
      gridDistrictColumn.MappingName = "SiteFuel";
      gridDistrictColumn.ReadOnly = true;
      gridDistrictColumn.Width = 80;
      gridDistrictColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridDistrictColumn);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Name";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 300;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Address 1";
      dataGridLabelColumn3.MappingName = "Address1";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 250;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Address 2";
      dataGridLabelColumn4.MappingName = "Address2";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 140;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Postcode";
      dataGridLabelColumn5.MappingName = "Postcode";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 80;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridVoidColumn dataGridVoidColumn = new DataGridVoidColumn();
      dataGridVoidColumn.Format = "";
      dataGridVoidColumn.FormatInfo = (IFormatProvider) null;
      dataGridVoidColumn.HeaderText = "Void";
      dataGridVoidColumn.MappingName = "PropertyVoid";
      dataGridVoidColumn.ReadOnly = true;
      dataGridVoidColumn.Width = 80;
      dataGridVoidColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridVoidColumn);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "dd/MM/yyyy";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Last Service Date";
      dataGridLabelColumn6.MappingName = "LastServiceDate";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 110;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DueDateColourColumn dateColourColumn = new DueDateColourColumn();
      dateColourColumn.Format = "dd/MM/yyyy";
      dateColourColumn.FormatInfo = (IFormatProvider) null;
      dateColourColumn.HeaderText = "Suggested Visit Date";
      dateColourColumn.MappingName = "NextVisitDate";
      dateColourColumn.ReadOnly = true;
      dateColourColumn.Width = 160;
      dateColourColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dateColourColumn);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "AM/PM";
      dataGridLabelColumn7.MappingName = "AMPM";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 50;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Engineer";
      dataGridLabelColumn8.MappingName = "EngName";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 180;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "dd/MM/yyyy";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Next Visit";
      dataGridLabelColumn9.MappingName = "NextVisit";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "ServiceDue";
      this.dgServicesDue.TableStyles.Add(tableStyle);
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if (integer > 0)
        this.theCustomer = App.DB.Customer.Customer_Get(integer);
      this.btnGenerateLetters.Enabled = false;
    }

    private void FRMLetterManagerMK3_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnResetFilters_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void btnFilter_Click(object sender, EventArgs e)
    {
      DateTime dateTime = this.dtpLetterCreateDate.Value;
      bool flag = false;
      DataView all = App.DB.TimeSlotRates.BankHolidays_GetAll();
      int num = 1;
      do
      {
        dateTime = dateTime.AddDays(1.0);
        if (all.Table.Select("BankHolidayDate='" + Conversions.ToString(Conversions.ToDate(Strings.Format((object) dateTime, "dd/MM/yyyy"))) + "'").Length > 0)
          flag = true;
        else if (dateTime.DayOfWeek != DayOfWeek.Saturday & (uint) dateTime.DayOfWeek > 0U)
          break;
        checked { ++num; }
      }
      while (num <= 4);
      if (flag && App.ShowMessage("Bank Holdiays are due soon, would you like to amended the filter dates before proceeding", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        return;
      this.PopulateDatagrid();
      if (!this.chkLettersOnly.Checked)
        this.GetAppointments(false);
      this.btnGenerateLetters.Enabled = true;
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      if (this.ServiceDueDataview == null || this.ServiceDueDataview.Count <= 0)
        return;
      this.ServiceDueDataview.AllowEdit = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this.ServiceDueDataview.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRowView) enumerator.Current)["SendLetterTick"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.ServiceDueDataview.AllowEdit = false;
    }

    private void btnUnselect_Click(object sender, EventArgs e)
    {
      if (this.ServiceDueDataview == null || this.ServiceDueDataview.Count <= 0)
        return;
      this.ServiceDueDataview.AllowEdit = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this.ServiceDueDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["SendLetterTick"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.ServiceDueDataview.AllowEdit = false;
    }

    private void btnGenerateLetters_Click(object sender, EventArgs e)
    {
      if (!this.chkLettersOnly.Checked)
      {
        this.GetAppointments(true);
        if (this.siteOnly)
        {
          this.grpServices.Text = "Services Due";
          this.ServiceDueDataview = new DataView(new DataTable());
          this.siteOnly = false;
        }
        else
        {
          this.PopulateDatagrid();
          this.GetAppointments(false);
        }
      }
      else
      {
        Printing printing = new Printing((object) new ArrayList()
        {
          (object) new DataView()
          {
            Table = this.ServiceDueDataview.Table,
            RowFilter = "SendLetterTick = 1"
          }
        }, "NCC Service Letters MK3", Enums.SystemDocumentType.ServiceLettersMK2, true, 0, false, Conversions.ToInteger(this.tbMinsPerDay.Text), this.theCustomer.CustomerID, Conversions.ToDate(this.dtpLetterCreateDate.Text), (DataTable) null);
      }
    }

    private void chkLettersOnly_CheckedChanged(object sender, EventArgs e)
    {
      if (this.ServiceDueDataview == null || this.ServiceDueDataview.Count <= 0)
        return;
      this.ServiceDueDataview.Table.Clear();
    }

    private void btnReleaseLockedSites_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.ServiceDueDataview.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator.Current;
          App.DB.LetterManager.ClearStuckSite(Conversions.ToDate(current["LastServiceDate"]), Conversions.ToInteger(current["SiteID"]), Conversions.ToString(current["Type"]));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void dgServicesDue_MouseClick(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgServicesDue.HitTest(e.X, e.Y);
      if (hitTestInfo.Type == DataGrid.HitTestType.Cell && hitTestInfo.Column == 0 && this.SelectedServiceDueDataRow != null)
      {
        this.dgServicesDue[this.dgServicesDue.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgServicesDue[this.dgServicesDue.CurrentRowIndex, 0]);
        if (!this.SelectedServiceDueDataRow.Table.Columns.Contains("MultipleFuelSite") || !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedServiceDueDataRow["MultipleFuelSite"])))
          return;
        DataRow[] dataRowArray = this.ServiceDueDataview.Table.Select("SiteID = " + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedServiceDueDataRow["SiteID"]))) + "AND MultipleFuelSite = True");
        int index = 0;
        while (index < dataRowArray.Length)
        {
          dataRowArray[index]["SendLetterTick"] = RuntimeHelpers.GetObjectValue(this.SelectedServiceDueDataRow["SendLetterTick"]);
          checked { ++index; }
        }
      }
    }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) integer, SiteSQL.GetBy.SiteId, (object) null);
      if (site != null && site.Exists)
      {
        this.ServiceDueDataview = App.DB.LetterManager.LetterManagerAddSiteMK3(this.dtpLetterCreateDate.Value, site.SiteID);
        if (this.ServiceDueDataview.Count > 0)
        {
          this.CalcAvail();
          this.grpServices.Text = "Site";
          this.GetAppointments(false);
          this.siteOnly = true;
          this.btnGenerateLetters.Enabled = true;
        }
        else
        {
          int num = (int) App.ShowMessage("Site could not be added to process, please check site or contact IT!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
    }

    public void CalcAvail()
    {
      this.profile = false;
      bool flag = false;
      if (this.Avail.Columns.Count == 0)
      {
        this.Avail.Columns.Add("Day");
        this.Avail.Columns.Add("Avail");
        this.Avail.Columns["Avail"].DataType = System.Type.GetType("System.Int32");
        this.Avail.TableName = "apps";
      }
      this.Avail.Clear();
      this.AvailView.Table = this.Avail;
      if (this.theCustomer.WinterServ > 0 & this.theCustomer.SummerServ > 0)
      {
        DateTime theFriday = DateHelper.GetTheFriday(this.dtpLetterCreateDate.Value.AddDays(14.0));
        int num1 = -4;
        do
        {
          int workingDays = DateHelper.GetWorkingDays(DateHelper.GetFirstDayOfMonth(theFriday.AddDays((double) num1)), DateHelper.GetLastDayOfMonth(theFriday.AddDays((double) num1)));
          DataRow row = this.AvailView.Table.NewRow();
          if (DateHelper.GetWorkingDays(theFriday.AddDays((double) num1), theFriday.AddDays((double) num1)) > 0)
          {
            DataTable table = App.DB.LetterManager.GetBucketsL1(theFriday.AddDays((double) num1), this.theCustomer.CustomerID).Table;
            int num2 = 0;
            if (table.Rows.Count > 0)
              num2 = Conversions.ToInteger(table.Rows[0]["ServicesBooked"]);
            if (DateAndTime.Month(theFriday.AddDays((double) num1)) < 4 | DateAndTime.Month(theFriday.AddDays((double) num1)) > 9)
            {
              row["Day"] = (object) checked (num1 + 5);
              row["Avail"] = (object) checked ((int) Conversion.Int(unchecked ((double) this.theCustomer.WinterServ / (double) workingDays - (double) num2)));
              this.AvailView.Table.Rows.Add(row);
            }
            else
            {
              row["Day"] = (object) checked (num1 + 5);
              row["Avail"] = (object) checked ((int) Conversion.Int(unchecked ((double) this.theCustomer.SummerServ / (double) workingDays - (double) num2)));
              this.AvailView.Table.Rows.Add(row);
            }
          }
          else
          {
            row["Day"] = (object) checked (num1 + 5);
            row["Avail"] = (object) 0;
            this.AvailView.Table.Rows.Add(row);
          }
          checked { ++num1; }
        }
        while (num1 <= 0);
      }
      else
      {
        int num = 0;
        do
        {
          DataRow row = this.AvailView.Table.NewRow();
          row["Day"] = (object) checked (num + 1);
          row["Avail"] = (object) 0;
          this.AvailView.Table.Rows.Add(row);
          checked { ++num; }
        }
        while (num <= 4);
        flag = true;
      }
      IEnumerator enumerator;
      try
      {
        enumerator = this.AvailView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          this.amtServ = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) this.amtServ, ((DataRow) enumerator.Current)["Avail"]));
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (!(this.AvailView.Count > 0 & !flag))
        return;
      this.profile = true;
    }

    public void PopulateDatagrid()
    {
      try
      {
        if (!this.chkLettersOnly.Checked)
        {
          this.CalcAvail();
          string Left = Combo.get_GetSelectedItemValue(this.cboLetterNumber);
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "1", false) != 0)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "2", false) != 0)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "3", false) == 0)
              {
                switch (this.theCustomer.CustomerID)
                {
                  case 2846:
                  case 3174:
                  case 5155:
                  case 5385:
                  case 6526:
                  case 6561:
                    this.ServiceDueDataview = App.DB.LetterManager.Get_Letter3Jobs(this.dtpLetterCreateDate.Value, this.theCustomer.CustomerID, 0);
                    break;
                }
              }
              else
              {
                this.ServiceDueDataview = App.DB.LetterManager.Get_Letter1Jobs_MultipleFuel(DateHelper.GetTheFriday(this.dtpLetterCreateDate.Value), this.theCustomer.CustomerID);
                if (this.ServiceDueDataview.Count > 0 & this.amtServ > 0)
                {
                  // ISSUE: variable of a reference type
                  int& local;
                  // ISSUE: explicit reference operation
                  int num = checked (^(local = ref this.amtServ) - this.ServiceDueDataview.Count);
                  local = num;
                }
                if (this.amtServ < 0)
                  this.amtServ = 0;
                this.ServiceDueDataview.Table.Merge(App.DB.LetterManager.Get_Letter1Jobs(DateHelper.GetTheFriday(this.dtpLetterCreateDate.Value), this.theCustomer.CustomerID, this.profile, this.amtServ).Table);
                this.ServiceDueDataview.Table.Merge(App.DB.LetterManager.Get_Letter2Jobs(this.dtpLetterCreateDate.Value, this.theCustomer.CustomerID).Table);
                this.ServiceDueDataview.Table.Merge(App.DB.LetterManager.Get_Letter3Jobs(this.dtpLetterCreateDate.Value, this.theCustomer.CustomerID, 0).Table);
              }
            }
            else
              this.ServiceDueDataview = App.DB.LetterManager.Get_Letter2Jobs(this.dtpLetterCreateDate.Value, this.theCustomer.CustomerID);
          }
          else
          {
            this.ServiceDueDataview = App.DB.LetterManager.Get_Letter1Jobs_MultipleFuel(DateHelper.GetTheFriday(this.dtpLetterCreateDate.Value), this.theCustomer.CustomerID);
            if (this.ServiceDueDataview.Count > 0 & this.amtServ > 0)
            {
              // ISSUE: variable of a reference type
              int& local;
              // ISSUE: explicit reference operation
              int num = checked (^(local = ref this.amtServ) - this.ServiceDueDataview.Count);
              local = num;
            }
            if (this.amtServ < 0)
              this.amtServ = 0;
            this.ServiceDueDataview.Table.Merge(App.DB.LetterManager.Get_Letter1Jobs(DateHelper.GetTheFriday(this.dtpLetterCreateDate.Value), this.theCustomer.CustomerID, this.profile, this.amtServ).Table);
          }
          if (!this.chkVoidProperty.Checked)
            this.ServiceDueDataview.RowFilter = "PropertyVoid = 0";
          if (!this.chkIncludePatchChecks.Checked && this.ServiceDueDataview.Table.Columns.Contains("PatchCheck"))
            this.ServiceDueDataview.RowFilter = "PatchCheck = 0";
        }
        else
          this.ServiceDueDataview = App.DB.LetterManager.GetLetterScheduledAppointmentsMK3(this.dtpLetterCreateDate.Value, this.theCustomer.CustomerID);
        this.grpServices.Text = "Services Due - " + Conversions.ToString(this.ServiceDueDataview.Count);
        this.btnGenerateLetters.Enabled = true;
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
      ComboBox cboLetterNumber = this.cboLetterNumber;
      Combo.SetSelectedComboItem_By_Value(ref cboLetterNumber, Conversions.ToString(1));
      this.cboLetterNumber = cboLetterNumber;
      this.dtpLetterCreateDate.Value = DateAndTime.Now;
      this.theCustomer = App.DB.Customer.Customer_Get(5338);
    }

    public DataTable AppointmentStrip(
      ref DataTable appointments,
      List<int> levelslist,
      List<string> Postcodes,
      bool keepweekends = false)
    {
      appointments.Columns.Add("SolidQual");
      appointments.Columns.Add("OilQual");
      appointments.Columns.Add("GasQual");
      appointments.Columns.Add("ASHPQual");
      appointments.Columns.Add("ComQual");
      int index1 = checked (appointments.Rows.Count - 1);
      while (index1 >= 0)
      {
        DataRow row = appointments.Rows[index1];
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(row["keep"], (object) 0, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(row["remove"], (object) 0, false))))
        {
          DataTable table1 = App.DB.EngineerLevel.Get(Conversions.ToInteger(row["EngineerID"])).Table;
          bool flag1 = true;
          bool flag2 = false;
          bool flag3 = false;
          bool flag4 = false;
          bool flag5 = false;
          bool flag6 = false;
          bool flag7 = false;
          try
          {
            foreach (int num in levelslist)
            {
              DataRow[] dataRowArray1 = table1.Select("tick = 1");
              int index2 = 0;
              while (index2 < dataRowArray1.Length)
              {
                DataRow dataRow = dataRowArray1[index2];
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["ManagerID"], (object) 69698, false))
                  flag2 = true;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["ManagerID"], (object) 68877, false))
                  flag3 = true;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["ManagerID"], (object) 68889, false))
                  flag4 = true;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["ManagerID"], (object) 68820, false))
                  flag5 = true;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["ManagerID"], (object) 69743, false))
                  flag6 = true;
                if (Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Name"])).Length > 2 && Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Name"])).Substring(0, 3).Contains("COM"))
                  flag7 = true;
                checked { ++index2; }
              }
              DataRow[] dataRowArray2 = table1.Select("tick = 1");
              int index3 = 0;
              while (index3 < dataRowArray2.Length)
              {
                DataRow dataRow = dataRowArray2[index3];
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual((object) num, dataRow["ManagerID"], false))
                {
                  flag1 = false;
                  break;
                }
                flag1 = true;
                checked { ++index3; }
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
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["ServPri"])) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row["ServPri"], (object) "10", false))
            flag1 = true;
          if (!flag1)
          {
            flag1 = true;
            List<string> stringList = new List<string>();
            DataTable table2 = App.DB.EngineerPostalRegion.GetTicked(Conversions.ToInteger(row["EngineerID"])).Table;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = table2.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current = (DataRow) enumerator1.Current;
                stringList.Add(Conversions.ToString(current["Name"]));
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            try
            {
              foreach (string postcode in Postcodes)
              {
                if (stringList.Contains(postcode))
                  flag1 = false;
              }
            }
            finally
            {
              List<string>.Enumerator enumerator2;
              enumerator2.Dispose();
            }
          }
          if (!flag1 && (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["ServPri"])) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row["ServPri"], (object) 10, false)))
            flag1 = true;
          DataRow[] dataRowArray = appointments.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "engineerid = ", row["EngineerID"])));
          int index4 = 0;
          while (index4 < dataRowArray.Length)
          {
            DataRow dataRow = dataRowArray[index4];
            if (flag1)
            {
              dataRow["remove"] = (object) 1;
            }
            else
            {
              dataRow["keep"] = (object) 1;
              dataRow["OilQual"] = !flag4 ? (object) 0 : (object) 1;
              dataRow["SolidQual"] = !flag3 ? (object) 0 : (object) 1;
              dataRow["ASHPQual"] = !flag6 ? (object) 0 : (object) 1;
              dataRow["GasQual"] = !flag5 ? (object) 0 : (object) 1;
              dataRow["ComQual"] = !flag7 ? (object) 0 : (object) 1;
            }
            checked { ++index4; }
          }
        }
        checked { index1 += -1; }
      }
      DataRow[] dataRowArray3 = appointments.Select("remove = 1  AND CBUOC = 0");
      int index5 = 0;
      while (index5 < dataRowArray3.Length)
      {
        DataRow row = dataRowArray3[index5];
        appointments.Rows.Remove(row);
        checked { ++index5; }
      }
      if (!keepweekends)
      {
        DataRow[] dataRowArray1 = appointments.Select("1=1");
        int index2 = 0;
        while (index2 < dataRowArray1.Length)
        {
          DataRow row = dataRowArray1[index2];
          if (Conversions.ToDate(row["thedate"]).DayOfWeek == DayOfWeek.Saturday || Conversions.ToDate(row["thedate"]).DayOfWeek == DayOfWeek.Sunday || Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(row["BH"], (object) 1, false))
            appointments.Rows.Remove(row);
          checked { ++index2; }
        }
      }
      return appointments;
    }

    private bool GetAppointments(bool DoJobs = false)
    {
      string Left1 = "";
      this.Cursor = Cursors.WaitCursor;
      DateTime now1 = DateAndTime.Now;
      DataView dataView1 = new DataView();
      bool flag1;
      if (this.ServiceDueDataview != null && this.ServiceDueDataview.Count > 0)
      {
        dataView1.Table = this.SelectedServiceDueDataRow.Table;
        if (!dataView1.Table.Columns.Contains("EngName"))
          dataView1.Table.Columns.Add("EngName");
        if (DoJobs)
          dataView1.RowFilter = "SendLetterTick = 1";
        if (dataView1.Count == 0)
        {
          int num = (int) App.ShowMessage("No Services to Process!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          goto label_124;
        }
        else
        {
          dataView1.Sort = !this.chkLastService.Checked ? "Postcode" : "LastServiceDate";
          DataView dataView2 = new DataView();
          dataView2.Table = App.DB.LetterManager.Get_Appointments_Main_MK3(DateHelper.GetTheMonday(this.dtpLetterCreateDate.Value), 15, 31, checked ((int) Math.Round(unchecked ((double) Conversions.ToInteger(this.tbMinsPerDay.Text) / 2.0))));
          IList<int> intList = (IList<int>) new List<int>();
          int num1 = 0;
          DataRow[] dataRowArray1 = App.DB.Customer.Requirements_Get_For_CustomerID(this.theCustomer.CustomerID).Table.Select("tick = 1");
          int index1 = 0;
          while (index1 < dataRowArray1.Length)
          {
            DataRow dataRow = dataRowArray1[index1];
            intList.Add(Conversions.ToInteger(dataRow["ManagerID"]));
            checked { ++num1; }
            checked { ++index1; }
          }
          if (num1 == 0)
            intList.Add(69697);
          this.Postcodes.Clear();
          IEnumerator enumerator1;
          try
          {
            enumerator1 = dataView1.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataRowView current = (DataRowView) enumerator1.Current;
              List<string> postcodes = this.Postcodes;
              object Instance;
              object obj1;
              object[] objArray;
              bool[] flagArray;
              object obj2 = NewLateBinding.LateGet(current["Postcode"], (System.Type) null, "Substring", objArray = new object[2]
              {
                (object) 0,
                NewLateBinding.LateGet(Instance = current["Postcode"], (System.Type) null, "IndexOf", new object[1]
                {
                  (object) (string) (obj1 = (object) "-")
                }, (string[]) null, (System.Type[]) null, (bool[]) null)
              }, (string[]) null, (System.Type[]) null, flagArray = new bool[2]
              {
                false,
                true
              });
              if (flagArray[1])
                NewLateBinding.LateSetComplex(Instance, (System.Type) null, "IndexOf", new object[2]
                {
                  obj1,
                  objArray[1]
                }, (string[]) null, (System.Type[]) null, true, true);
              string str = Conversions.ToString(obj2);
              postcodes.Add(str);
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
          DataView dataView3 = dataView2;
          DataView dataView4;
          DataTable table1 = (dataView4 = dataView2).Table;
          DataTable dataTable1 = this.AppointmentStrip(ref table1, (List<int>) intList, this.Postcodes, false);
          dataView4.Table = table1;
          dataView3.Table = dataTable1;
          DataTable dataTable2 = dataView2.Table.Clone();
          dataTable2.Columns.Add("AMCLOSE");
          dataTable2.Columns.Add("PMCLOSE");
          dataTable2.Columns["AMCLOSE"].DataType = System.Type.GetType("System.Int32");
          dataTable2.Columns["PMCLOSE"].DataType = System.Type.GetType("System.Int32");
          dataTable2.Columns["DATE"].DataType = System.Type.GetType("System.DateTime");
          IEnumerator enumerator2;
          try
          {
            enumerator2 = dataView2.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              dataTable2.ImportRow(current);
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          dataView2.Table = dataTable2;
          dataView2.Sort = "ServPri ASC, EngineerID, daynumber";
          DataView allTicked = App.DB.EngineerPostalRegion.GetALLTicked();
          try
          {
            int index2 = -1;
            do
            {
              checked { ++index2; }
              DataRowView dataRowView = dataView1[index2];
              IEnumerator enumerator3;
              try
              {
                enumerator3 = dataView2.Table.Rows.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                  DataRow current = (DataRow) enumerator3.Current;
                  if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["AMLatitude"])) & !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["Latitude"])))
                  {
                    double num2 = Helper.MakeDoubleValid((object) Helper.Distance(Conversions.ToDouble(current["AMLatitude"]), Conversions.ToDouble(current["AMLongitude"]), Conversions.ToDouble(dataRowView["Latitude"]), Conversions.ToDouble(dataRowView["Longitude"]), 'M'));
                    current["AMCLOSE"] = (object) num2;
                  }
                  else
                    current["AMCLOSE"] = (object) DBNull.Value;
                  if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["PMLatitude"])) & !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["Latitude"])))
                  {
                    double num2 = Helper.MakeDoubleValid((object) Helper.Distance(Conversions.ToDouble(current["PMLatitude"]), Conversions.ToDouble(current["PMLongitude"]), Conversions.ToDouble(dataRowView["Latitude"]), Conversions.ToDouble(dataRowView["Longitude"]), 'M'));
                    current["PMCLOSE"] = (object) num2;
                  }
                  else
                    current["PMCLOSE"] = (object) DBNull.Value;
                }
              }
              finally
              {
                if (enumerator3 is IDisposable)
                  (enumerator3 as IDisposable).Dispose();
              }
              if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["FuelID"])))
                dataRowView["FuelID"] = (object) 0;
              if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["CommercialDistrict"])))
                dataRowView["CommercialDistrict"] = (object) false;
              string str1 = "";
              bool boolean = Conversions.ToBoolean((object) (bool) (!dataRowView.Row.Table.Columns.Contains("PatchCheck") ? 0 : (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowView["PatchCheck"], (object) true, false)) ? 1 : 0)));
              int num3 = !Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowView["CommercialDistrict"], (object) true, false), (object) boolean)) ? (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (bool) (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["FuelID"])) ? 0 : (Conversions.ToInteger(dataRowView["FuelID"]) == 69497 ? 1 : 0)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowView["SolidFuel"], (object) true, false)), (object) dataRowView["SiteFuel"].ToString().ToUpper().Contains("SOLID FUEL"))) ? (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (bool) (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["FuelID"])) ? 0 : (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowView["FuelID"], (object) Enums.FuelTypes.Oil, false)) ? 1 : 0)), (object) dataRowView["SiteFuel"].ToString().ToUpper().Contains("OIL"))) ? 40 : 60) : 75) : 15;
              DateTime dateTime1 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRowView["NextVisitDate"]));
              string Left2 = dataRowView["Type"].ToString();
              DateTime dateTime2;
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 1", false) != 0)
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 2", false) != 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 3", false) == 0)
                    dataView2.RowFilter = "DATE = #" + DateHelper.CheckBankHolidaySatOrSun(dateTime1, false).ToString("yyyy-MM-dd") + "#";
                }
                else
                {
                  dateTime1 = DateHelper.CheckBankHolidaySatOrSunForward(dateTime1, false);
                  dataView2.RowFilter = "DATE <= #" + DateHelper.GetTheFriday(dateTime1).ToString("yyyy-MM-dd") + "# AND DATE >= #" + dateTime1.ToString("yyyy-MM-dd") + "#";
                }
              }
              else
              {
                DataView dataView5 = dataView2;
                string[] strArray = new string[5]
                {
                  "DATE <= #",
                  null,
                  null,
                  null,
                  null
                };
                dateTime2 = DateHelper.GetTheFriday(dateTime1);
                strArray[1] = dateTime2.ToString("yyyy-MM-dd");
                strArray[2] = "# AND DATE >= #";
                dateTime2 = DateHelper.GetTheMonday(dateTime1);
                strArray[3] = dateTime2.ToString("yyyy-MM-dd");
                strArray[4] = "#";
                string str2 = string.Concat(strArray);
                dataView5.RowFilter = str2;
              }
              IEnumerator enumerator4;
              try
              {
                enumerator4 = dataView2.GetEnumerator();
                while (enumerator4.MoveNext())
                {
                  DataRowView current = (DataRowView) enumerator4.Current;
                  if (allTicked.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "EngineerID = ", current["EngineerID"]), (object) " AND Name = '"), (object) dataRowView["Postcode"].ToString().Substring(0, Conversions.ToInteger(NewLateBinding.LateGet(dataRowView["Postcode"], (System.Type) null, "IndexOf", new object[1]
                  {
                    (object) "-"
                  }, (string[]) null, (System.Type[]) null, (bool[]) null)))), (object) "'"))).Length > 0 && !Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowView["FuelID"], (object) Enums.FuelTypes.NatGas, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowView["FuelID"], (object) Enums.FuelTypes.LPG, false)), (object) dataRowView["SiteFuel"].ToString().ToUpper().Contains("GAS")), (object) dataRowView["SiteFuel"].ToString().ToUpper().Contains("LPG")), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["GasQual"], (object) 0, false)), Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowView["FuelID"], (object) Enums.FuelTypes.SolidFuel, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowView["SolidFuel"], (object) true, false)), (object) dataRowView["SiteFuel"].ToString().ToUpper().Contains("SOLID FUEL")), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["SolidQual"], (object) 0, false))), Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowView["FuelID"], (object) Enums.FuelTypes.Oil, false), (object) dataRowView["SiteFuel"].ToString().ToUpper().Contains("OIL")), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["OilQual"], (object) 0, false))), Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (dataRowView["SiteFuel"].ToString().ToUpper().Contains("AIR SOURCE") | dataRowView["SiteFuel"].ToString().ToUpper().Contains("ASHP")), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["ASHPQual"], (object) 0, false))), Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowView["CommercialDistrict"], (object) true, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["ComQual"], (object) 0, false)))))
                  {
                    bool flag2 = false;
                    bool flag3 = false;
                    if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["AMCLOSE"])) & Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["PMCLOSE"])))
                    {
                      current["AMCLOSE"] = (object) -1;
                      current["PMCLOSE"] = (object) -1;
                    }
                    else if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["AMCLOSE"])))
                    {
                      current["AMCLOSE"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(current["PMCLOSE"], (object) Conversions.ToInteger(this.txtTravelBetween.Text));
                      flag2 = true;
                    }
                    else if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["PMCLOSE"])))
                    {
                      current["PMCLOSE"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(current["AMCLOSE"], (object) Conversions.ToInteger(this.txtTravelBetween.Text));
                      flag3 = true;
                    }
                    if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(current["remainingAM"], (object) num3, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLess(current["AMCLOSE"], (object) Conversions.ToInteger(this.txtMaxTravel.Text), false)), (object) !(str1 != null & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "PM", false) == 0))))
                    {
                      dataRowView["EngName"] = RuntimeHelpers.GetObjectValue(current["Name"]);
                      dataRowView["EngineerID"] = RuntimeHelpers.GetObjectValue(current["EngineerID"]);
                      dataRowView["BookedDateTime"] = RuntimeHelpers.GetObjectValue(current["Date"]);
                      dataRowView["NextVisitDate"] = RuntimeHelpers.GetObjectValue(current["Date"]);
                      dataRowView["AMPM"] = (object) "AM";
                      current["remainingAM"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(current["remainingAM"], (object) num3);
                      DataRowCollection rows1 = this.AvailView.Table.Rows;
                      dateTime2 = Conversions.ToDate(current["Date"]);
                      int index3 = (int) (dateTime2.DayOfWeek - 1);
                      DataRow dataRow1 = rows1[index3];
                      DataRowCollection rows2 = this.AvailView.Table.Rows;
                      dateTime2 = Conversions.ToDate(current["Date"]);
                      int index4 = (int) (dateTime2.DayOfWeek - 1);
                      object obj = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(rows2[index4]["Avail"], (object) 1);
                      dataRow1["Avail"] = obj;
                      if (Conversions.ToInteger(current["PMCLOSE"]) == -1 | flag2)
                      {
                        DataRow[] dataRowArray2 = dataView2.Table.Select("EngineerID = " + Conversions.ToString(Conversions.ToInteger(dataRowView["EngineerID"])) + " AND DATE = #" + dateTime1.ToString("yyyy-MM-dd") + "#");
                        if (dataRowArray2.Length > -1)
                        {
                          DataRow[] dataRowArray3 = dataRowArray2;
                          int index5 = 0;
                          while (index5 < dataRowArray3.Length)
                          {
                            DataRow dataRow2 = dataRowArray3[index5];
                            dataRow2["AMLatitude"] = RuntimeHelpers.GetObjectValue(dataRowView["Latitude"]);
                            dataRow2["AMLongitude"] = RuntimeHelpers.GetObjectValue(dataRowView["Longitude"]);
                            checked { ++index5; }
                          }
                        }
                        break;
                      }
                      break;
                    }
                    if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(current["RemainingPM"], (object) num3, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLess(current["PMCLOSE"], (object) Conversions.ToInteger(this.txtMaxTravel.Text), false)), (object) !(str1 != null & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "AM", false) == 0))))
                    {
                      dataRowView["EngName"] = RuntimeHelpers.GetObjectValue(current["Name"]);
                      dataRowView["EngineerID"] = RuntimeHelpers.GetObjectValue(current["EngineerID"]);
                      dataRowView["BookedDateTime"] = RuntimeHelpers.GetObjectValue(current["Date"]);
                      dataRowView["NextVisitDate"] = RuntimeHelpers.GetObjectValue(current["Date"]);
                      dataRowView["AMPM"] = (object) "PM";
                      current["remainingPM"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(current["remainingPM"], (object) num3);
                      DataRowCollection rows1 = this.AvailView.Table.Rows;
                      dateTime2 = Conversions.ToDate(current["Date"]);
                      int index3 = (int) (dateTime2.DayOfWeek - 1);
                      DataRow dataRow1 = rows1[index3];
                      DataRowCollection rows2 = this.AvailView.Table.Rows;
                      dateTime2 = Conversions.ToDate(current["Date"]);
                      int index4 = (int) (dateTime2.DayOfWeek - 1);
                      object obj = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(rows2[index4]["Avail"], (object) 1);
                      dataRow1["Avail"] = obj;
                      if (Conversions.ToInteger(current["PMCLOSE"]) == -1 | flag3)
                      {
                        DataRow[] dataRowArray2 = dataView2.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "EngineerID = '", dataRowView["EngineerID"]), (object) "' AND DATE = #"), (object) dateTime1.ToString("yyyy-MM-dd")), (object) "#")));
                        int index5 = 0;
                        while (index5 < dataRowArray2.Length)
                        {
                          DataRow dataRow2 = dataRowArray2[index5];
                          dataRow2["PMLatitude"] = RuntimeHelpers.GetObjectValue(dataRowView["Latitude"]);
                          dataRow2["PMLongitude"] = RuntimeHelpers.GetObjectValue(dataRowView["Longitude"]);
                          checked { ++index5; }
                        }
                        break;
                      }
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
              if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRowView["MultipleFuelSite"])) & !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["BookedDateTime"])))
              {
                DataRow[] dataRowArray2 = dataView1.Table.Select("SiteID = " + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRowView["SiteID"]))));
                int index3 = 0;
                while (index3 < dataRowArray2.Length)
                {
                  DataRow dataRow = dataRowArray2[index3];
                  if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["MultipleFuelSite"])))
                    dataRow["NextVisitDate"] = RuntimeHelpers.GetObjectValue(dataRowView["NextVisitDate"]);
                  checked { ++index3; }
                }
              }
            }
            while (index2 < checked (dataView1.Count - 1));
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int num2 = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
          }
          DataView dataView6 = new DataView();
          DataView dataView7 = dataView6;
          EngineerVisitSQL engineerVisits = App.DB.EngineerVisits;
          DateTime dateTime3 = DateTime.Now;
          string StartDate = dateTime3.ToString("yyyy-MM-dd");
          DataTable appointmentsScheduler = engineerVisits.Get_Appointments_Scheduler(StartDate, 15);
          dataView7.Table = appointmentsScheduler;
          DataView dataView8 = dataView6;
          DataView dataView9;
          DataTable table2 = (dataView9 = dataView6).Table;
          DataTable dataTable3 = this.AppointmentStrip(ref table2, (List<int>) intList, this.Postcodes, false);
          dataView9.Table = table2;
          dataView8.Table = dataTable3;
          dataView6.Sort = "Daynumber";
          if (dataView6.Count == 0)
          {
            int num2 = (int) Interaction.MsgBox((object) ("Please ensure there is a scheduler which can except " + App.DB.Picklists.Get_One_As_Object(intList[0]).Name + " And you are not booking further than 28 days ahead"), MsgBoxStyle.Critical, (object) null);
            flag1 = false;
            goto label_124;
          }
          else
          {
            this.AvailView.Sort = "Avail DESC";
            DataTable table3 = this.AvailView.ToTable();
            dataView1.RowFilter = "EngineerID = 0 OR EngineerID IS NULL or EngName LIKE '%SCHED%'";
            dataView1.Sort = "MultipleFuelSite Desc";
            int num2 = 0;
            IEnumerator enumerator3;
            try
            {
              enumerator3 = dataView1.GetEnumerator();
              while (enumerator3.MoveNext())
              {
                DataRowView current1 = (DataRowView) enumerator3.Current;
                string str1 = "";
                checked { ++num2; }
                DateTime dateTime1 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current1["NextVisitDate"]));
                string Left2 = current1["Type"].ToString();
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 1", false) != 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 2", false) != 0)
                  {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 3", false) == 0)
                    {
                      DataView dataView5 = dataView6;
                      dateTime3 = DateHelper.CheckBankHolidaySatOrSun(dateTime1, false);
                      string str2 = "DATE = #" + dateTime3.ToString("yyyy-MM-dd") + "#";
                      dataView5.RowFilter = str2;
                      dateTime3 = DateHelper.CheckBankHolidaySatOrSun(dateTime1, false);
                      str1 = dateTime3.ToString("dd/MM/yyyy");
                    }
                  }
                  else
                  {
                    DataView dataView5 = dataView6;
                    string[] strArray = new string[5]
                    {
                      "DATE <= #",
                      null,
                      null,
                      null,
                      null
                    };
                    dateTime3 = DateHelper.GetTheFriday(dateTime1);
                    strArray[1] = dateTime3.ToString("yyyy-MM-dd");
                    strArray[2] = "# AND DATE >= #";
                    dateTime3 = DateHelper.GetTheMonday(dateTime1);
                    strArray[3] = dateTime3.ToString("yyyy-MM-dd");
                    strArray[4] = "#";
                    string str2 = string.Concat(strArray);
                    dataView5.RowFilter = str2;
                    dateTime3 = DateHelper.GetTheMonday(this.dtpLetterCreateDate.Value);
                    str1 = Conversions.ToString(DateHelper.CheckBankHolidaySatOrSunForward(dateTime3.AddDays(Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) 14, Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(table3.Rows[0]["Day"], (object) 1)))), false));
                  }
                }
                else
                {
                  DataView dataView5 = dataView6;
                  string[] strArray = new string[5]
                  {
                    "DATE <= #",
                    null,
                    null,
                    null,
                    null
                  };
                  dateTime3 = DateHelper.GetTheFriday(dateTime1);
                  strArray[1] = dateTime3.ToString("yyyy-MM-dd");
                  strArray[2] = "# AND DATE >= #";
                  dateTime3 = DateHelper.GetTheMonday(dateTime1);
                  strArray[3] = dateTime3.ToString("yyyy-MM-dd");
                  strArray[4] = "#";
                  string str2 = string.Concat(strArray);
                  dataView5.RowFilter = str2;
                  dateTime3 = DateHelper.GetTheMonday(this.dtpLetterCreateDate.Value);
                  str1 = Conversions.ToString(DateHelper.CheckBankHolidaySatOrSunForward(dateTime3.AddDays(Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) 14, Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(table3.Rows[0]["Day"], (object) 1)))), false));
                }
                if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current1["MultipleFuelSite"])))
                  str1 = Conversions.ToString(dateTime1);
                IEnumerator enumerator4;
                try
                {
                  enumerator4 = dataView6.GetEnumerator();
                  while (enumerator4.MoveNext())
                  {
                    DataRowView current2 = (DataRowView) enumerator4.Current;
                    if (allTicked.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "EngineerID = ", current2["EngineerID"]), (object) " AND Name = '"), (object) current1["Postcode"].ToString().Substring(0, Conversions.ToInteger(NewLateBinding.LateGet(current1["Postcode"], (System.Type) null, "IndexOf", new object[1]
                    {
                      (object) "-"
                    }, (string[]) null, (System.Type[]) null, (bool[]) null)))), (object) "'"))).Length > 0)
                    {
                      current1["EngName"] = RuntimeHelpers.GetObjectValue(current2["Name"]);
                      current1["EngineerID"] = RuntimeHelpers.GetObjectValue(current2["EngineerID"]);
                      current1["BookedDateTime"] = (object) str1;
                      current1["NextVisitDate"] = (object) str1;
                      if (num2 < 5)
                      {
                        current1["AMPM"] = (object) "AM";
                        this.AvailView.Table.Rows[Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(table3.Rows[0]["Day"], (object) 1))]["Avail"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.AvailView.Table.Rows[Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(table3.Rows[0]["Day"], (object) 1))]["Avail"], (object) 1);
                      }
                      else if (num2 > 4)
                      {
                        current1["AMPM"] = (object) "PM";
                        this.AvailView.Table.Rows[Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(table3.Rows[0]["Day"], (object) 1))]["Avail"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(this.AvailView.Table.Rows[Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(table3.Rows[0]["Day"], (object) 1))]["Avail"], (object) 1);
                        if (num2 > 7)
                        {
                          num2 = 0;
                          this.AvailView.Sort = "Avail DESC";
                          table3 = this.AvailView.ToTable();
                        }
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
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
            try
            {
              if (DoJobs)
              {
                dataView1.RowFilter = "SendLetterTick = 1";
                Printing printing = new Printing((object) new ArrayList()
                {
                  (object) dataView1
                }, "NCC Service Letters MK2", Enums.SystemDocumentType.ServiceLettersMK2, true, 0, false, Conversions.ToInteger(this.tbMinsPerDay.Text), this.theCustomer.CustomerID, Conversions.ToDate(this.dtpLetterCreateDate.Text), (DataTable) null);
                DateTime now2 = DateAndTime.Now;
                int num3 = (int) Interaction.MsgBox((object) ("Start: " + Conversions.ToString(now1) + "\r\nEnd: " + Conversions.ToString(now2)), MsgBoxStyle.OkOnly, (object) null);
              }
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              flag1 = false;
              ProjectData.ClearProjectError();
              goto label_124;
            }
            finally
            {
              this.Cursor = Cursors.Default;
            }
          }
        }
      }
      this.Cursor = Cursors.Default;
      flag1 = true;
label_124:
      return flag1;
    }
  }
}
