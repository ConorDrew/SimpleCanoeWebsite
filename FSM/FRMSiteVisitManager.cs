// Decompiled with JetBrains decompiler
// Type: FSM.FRMSiteVisitManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
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
  public class FRMSiteVisitManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvVisits;
    private Engineer _theEngineer;
    private int _siteID;

    public FRMSiteVisitManager()
    {
      this.Load += new EventHandler(this.FRMVisitManager_Load);
      this._siteID = 0;
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

    internal virtual TextBox txtJobNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDefinition { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cboOutcome { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpEngineerVisits = new GroupBox();
      this.dgVisits = new DataGrid();
      this.btnExport = new Button();
      this.grpFilter = new GroupBox();
      this.btnSearch = new Button();
      this.Label12 = new Label();
      this.cboOutcome = new ComboBox();
      this.btnfindEngineer = new Button();
      this.txtEngineer = new TextBox();
      this.Label5 = new Label();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.txtJobNumber = new TextBox();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.chkVisitDate = new CheckBox();
      this.Label6 = new Label();
      this.cboType = new ComboBox();
      this.Label11 = new Label();
      this.cboDefinition = new ComboBox();
      this.cboStatus = new ComboBox();
      this.Label3 = new Label();
      this.Label10 = new Label();
      this.btnReset = new Button();
      this.grpEngineerVisits.SuspendLayout();
      this.dgVisits.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineerVisits.Controls.Add((Control) this.dgVisits);
      this.grpEngineerVisits.Location = new System.Drawing.Point(8, 173);
      this.grpEngineerVisits.Name = "grpEngineerVisits";
      this.grpEngineerVisits.Size = new Size(976, 407);
      this.grpEngineerVisits.TabIndex = 2;
      this.grpEngineerVisits.TabStop = false;
      this.grpEngineerVisits.Text = "Double Click To View / Edit";
      this.dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgVisits.DataMember = "";
      this.dgVisits.HeaderForeColor = SystemColors.ControlText;
      this.dgVisits.Location = new System.Drawing.Point(8, 20);
      this.dgVisits.Name = "dgVisits";
      this.dgVisits.Size = new Size(960, 379);
      this.dgVisits.TabIndex = 14;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 586);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 15;
      this.btnExport.Text = "Export";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.btnSearch);
      this.grpFilter.Controls.Add((Control) this.Label12);
      this.grpFilter.Controls.Add((Control) this.cboOutcome);
      this.grpFilter.Controls.Add((Control) this.btnfindEngineer);
      this.grpFilter.Controls.Add((Control) this.txtEngineer);
      this.grpFilter.Controls.Add((Control) this.Label5);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.txtJobNumber);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Controls.Add((Control) this.chkVisitDate);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Controls.Add((Control) this.cboType);
      this.grpFilter.Controls.Add((Control) this.Label11);
      this.grpFilter.Controls.Add((Control) this.cboDefinition);
      this.grpFilter.Controls.Add((Control) this.cboStatus);
      this.grpFilter.Controls.Add((Control) this.Label3);
      this.grpFilter.Controls.Add((Control) this.Label10);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(976, 135);
      this.grpFilter.TabIndex = 1;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSearch.Location = new System.Drawing.Point(898, 106);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(70, 23);
      this.btnSearch.TabIndex = 33;
      this.btnSearch.Text = "Run Filter";
      this.Label12.Location = new System.Drawing.Point(304, 77);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(62, 22);
      this.Label12.TabIndex = 31;
      this.Label12.Text = "Outcome";
      this.cboOutcome.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboOutcome.Location = new System.Drawing.Point(377, 74);
      this.cboOutcome.Name = "cboOutcome";
      this.cboOutcome.Size = new Size(184, 21);
      this.cboOutcome.TabIndex = 32;
      this.btnfindEngineer.BackColor = Color.White;
      this.btnfindEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindEngineer.Location = new System.Drawing.Point(258, 20);
      this.btnfindEngineer.Name = "btnfindEngineer";
      this.btnfindEngineer.Size = new Size(32, 23);
      this.btnfindEngineer.TabIndex = 29;
      this.btnfindEngineer.Text = "...";
      this.btnfindEngineer.UseVisualStyleBackColor = false;
      this.txtEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEngineer.Location = new System.Drawing.Point(68, 20);
      this.txtEngineer.Name = "txtEngineer";
      this.txtEngineer.ReadOnly = true;
      this.txtEngineer.Size = new Size(184, 21);
      this.txtEngineer.TabIndex = 28;
      this.Label5.Location = new System.Drawing.Point(7, 19);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(70, 16);
      this.Label5.TabIndex = 30;
      this.Label5.Text = "Engineer";
      this.dtpTo.Location = new System.Drawing.Point(621, 78);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(155, 21);
      this.dtpTo.TabIndex = 13;
      this.dtpFrom.Location = new System.Drawing.Point(621, 47);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(155, 21);
      this.dtpFrom.TabIndex = 12;
      this.txtJobNumber.Location = new System.Drawing.Point(377, 20);
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.Size = new Size(184, 21);
      this.txtJobNumber.TabIndex = 9;
      this.Label9.Location = new System.Drawing.Point(565, 79);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(48, 16);
      this.Label9.TabIndex = 10;
      this.Label9.Text = "To";
      this.Label8.Location = new System.Drawing.Point(565, 47);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(48, 16);
      this.Label8.TabIndex = 9;
      this.Label8.Text = "From";
      this.chkVisitDate.Cursor = Cursors.Hand;
      this.chkVisitDate.UseVisualStyleBackColor = true;
      this.chkVisitDate.Location = new System.Drawing.Point(567, 18);
      this.chkVisitDate.Name = "chkVisitDate";
      this.chkVisitDate.Size = new Size(80, 24);
      this.chkVisitDate.TabIndex = 11;
      this.chkVisitDate.Text = "Visit Date";
      this.Label6.Location = new System.Drawing.Point(304, 21);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 16);
      this.Label6.TabIndex = 6;
      this.Label6.Text = "Job Number";
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(377, 47);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(184, 21);
      this.cboType.TabIndex = 7;
      this.Label11.Location = new System.Drawing.Point(8, 77);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(48, 22);
      this.Label11.TabIndex = 5;
      this.Label11.Text = "Status";
      this.cboDefinition.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDefinition.Location = new System.Drawing.Point(68, 47);
      this.cboDefinition.Name = "cboDefinition";
      this.cboDefinition.Size = new Size(184, 21);
      this.cboDefinition.TabIndex = 6;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Location = new System.Drawing.Point(68, 74);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(184, 21);
      this.cboStatus.TabIndex = 8;
      this.Label3.Location = new System.Drawing.Point(8, 50);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(72, 16);
      this.Label3.TabIndex = 3;
      this.Label3.Text = "Definition";
      this.Label10.Location = new System.Drawing.Point(304, 47);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(55, 22);
      this.Label10.TabIndex = 4;
      this.Label10.Text = "Type";
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(72, 586);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 16;
      this.btnReset.Text = "Reset";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(992, 616);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpEngineerVisits);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(1000, 528);
      this.Name = nameof (FRMSiteVisitManager);
      this.Text = "Site Visit Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpEngineerVisits, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
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
      ComboBox cboDefinition = this.cboDefinition;
      Combo.SetUpCombo(ref cboDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboDefinition = cboDefinition;
      ComboBox cboOutcome = this.cboOutcome;
      Combo.SetUpCombo(ref cboOutcome, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboOutcome = cboOutcome;
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboType = cboType;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboStatus = cboStatus;
      if (!App.loggedInUser.Admin)
        this.btnExport.Enabled = false;
      this.SiteID = Conversions.ToInteger(this.get_GetParameter(0));
      this.PopulateDatagrid(true);
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

    private int SiteID
    {
      get
      {
        return this._siteID;
      }
      set
      {
        this._siteID = value;
      }
    }

    private void SetupVisitDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgVisits.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Visit Date";
      dataGridLabelColumn1.MappingName = "VisitDate";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 60;
      dataGridLabelColumn1.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Engineer";
      dataGridLabelColumn2.MappingName = "Engineer";
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
      dataGridLabelColumn4.HeaderText = "Notes To Engineer";
      dataGridLabelColumn4.MappingName = "NotesToEngineer";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 325;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Notes From Engineer";
      dataGridLabelColumn5.MappingName = "NotesFromEngineer";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 325;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Charge";
      dataGridLabelColumn6.MappingName = "VisitCharge";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 45;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Job No";
      dataGridLabelColumn7.MappingName = "JobNumber";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Status";
      dataGridLabelColumn8.MappingName = "VisitStatus";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 60;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Outcome";
      dataGridLabelColumn9.MappingName = "VisitOutcome";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 60;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      BitToStringDescriptionColumn descriptionColumn = new BitToStringDescriptionColumn();
      descriptionColumn.Format = "";
      descriptionColumn.FormatInfo = (IFormatProvider) null;
      descriptionColumn.HeaderText = "Parts To Fit";
      descriptionColumn.MappingName = "PartsToFit";
      descriptionColumn.ReadOnly = true;
      descriptionColumn.Width = 60;
      descriptionColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) descriptionColumn);
      if (true == App.IsRFT)
      {
        DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
        dataGridLabelColumn10.Format = "";
        dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn10.HeaderText = "Trade";
        dataGridLabelColumn10.MappingName = "Qualification";
        dataGridLabelColumn10.ReadOnly = true;
        dataGridLabelColumn10.Width = 85;
        dataGridLabelColumn10.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      }
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "C";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Visit Value";
      dataGridLabelColumn11.MappingName = "VisitValue";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 60;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "C";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "Engineer Cost";
      dataGridLabelColumn12.MappingName = "EngineerCost";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 60;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "C";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "Part\\Product Cost";
      dataGridLabelColumn13.MappingName = "PartProductCost";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 60;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisit.ToString();
      this.dgVisits.TableStyles.Add(tableStyle);
    }

    private void FRMVisitManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void btnfindEngineer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theEngineer = App.DB.Engineer.Engineer_Get(integer);
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

    private void dgVisits_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedVisitDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a visit to view", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        bool flag = false;
        switch (Conversions.ToInteger(this.SelectedVisitDataRow["StatusEnumID"]))
        {
          case 0:
            int num2 = (int) App.ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          case 1:
            int num3 = (int) App.ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          case 2:
            int num4 = (int) App.ShowMessage("This visit is waiting for parts, once recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            int num5 = (int) App.ShowMessage("This visit is currently with an engineer, once returned you may view the details.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
          App.ShowForm(typeof (FRMEngineerVisit), true, new object[1]
          {
            this.SelectedVisitDataRow["EngineerVisitID"]
          }, false);
          this.PopulateDatagrid(true);
        }
      }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      this.PopulateDatagrid(true);
    }

    public void PopulateDatagrid(bool withRun)
    {
      try
      {
        if (withRun)
        {
          string str = "AND (tblSite.SiteID = " + Conversions.ToString(this.SiteID);
          if (this.theEngineer != null)
            str += " AND tblEngineer.EngineerID = " + Conversions.ToString(this.theEngineer.EngineerID);
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboDefinition)) != 0.0)
            str += " AND tblJob.JobDefinitionEnumID = " + Combo.get_GetSelectedItemValue(this.cboDefinition);
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboType)) != 0.0)
            str += " AND tblJob.JobTypeID = " + Combo.get_GetSelectedItemValue(this.cboType);
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) != 0.0)
            str += " AND @THEStatusEnumIDString = " + Combo.get_GetSelectedItemValue(this.cboStatus);
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboOutcome)) != 0.0)
            str += " AND tblEngineerVisit.OutcomeEnumID = " + Combo.get_GetSelectedItemValue(this.cboOutcome);
          if ((uint) this.txtJobNumber.Text.Trim().Length > 0U)
            str = str + " AND tblJob.JobNumber LIKE '" + this.txtJobNumber.Text.Trim() + "%'";
          if (this.chkVisitDate.Checked)
            str = str + " AND tblEngineerVisit.StartDateTime >= '" + Strings.Format((object) this.dtpFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblEngineerVisit.StartDateTime <= '" + Strings.Format((object) this.dtpTo.Value, "dd-MMM-yyyy 23:59:59") + "'";
          string Where = str + ")";
          this.VisitsDataview = App.DB.EngineerVisits.EngineerVisits_Get_All_ForSite(Where);
        }
        else
          this.VisitsDataview = (DataView) null;
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
      this.chkVisitDate.Checked = false;
      this.dtpFrom.Value = DateAndTime.Today;
      this.dtpTo.Value = DateAndTime.Today;
      this.dtpFrom.Enabled = false;
      this.dtpTo.Enabled = false;
      this.grpFilter.Enabled = true;
    }

    public void Export()
    {
      if (this.VisitsDataview == null)
        return;
      ExportHelper.Export(this.VisitsDataview.Table, "SiteReport", Enums.ExportType.XLS);
    }
  }
}
