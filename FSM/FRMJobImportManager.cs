// Decompiled with JetBrains decompiler
// Type: FSM.FRMJobImportManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.JobImport;
using FSM.Entity.Jobs;
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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FRMJobImportManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvJobs;
    private int jobsPerWeek;

    public FRMJobImportManager()
    {
      this.Load += new EventHandler(this.FRMJobManager_Load);
      this.jobsPerWeek = 0;
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
      this.components = (IContainer) new Container();
      this.grpJobs = new GroupBox();
      this.dgJobs = new DataGrid();
      this.btnResetFilters = new Button();
      this.grpFilters = new GroupBox();
      this.chkSortPostcode = new CheckBox();
      this.cboJobType = new ComboBox();
      this.lblJobType = new Label();
      this.txtJobsPerDay = new TextBox();
      this.cboLetterNumber = new ComboBox();
      this.lblJobsPerDay = new Label();
      this.Label14 = new Label();
      this.btnFilter = new Button();
      this.Label1 = new Label();
      this.dtpLetterCreateDate = new DateTimePicker();
      this.btnSelectAll = new Button();
      this.btnUnselect = new Button();
      this.btnGenerateLetters = new Button();
      this.chkScheduleJobs = new CheckBox();
      this.btnFindSite = new Button();
      this.cmsAction = new ContextMenuStrip(this.components);
      this.tsmiDeleteSite = new ToolStripMenuItem();
      this.tsmiCreateJob = new ToolStripMenuItem();
      this.grpJobs.SuspendLayout();
      this.dgJobs.BeginInit();
      this.grpFilters.SuspendLayout();
      this.cmsAction.SuspendLayout();
      this.SuspendLayout();
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.dgJobs);
      this.grpJobs.Location = new System.Drawing.Point(12, 154);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(962, 271);
      this.grpJobs.TabIndex = 3;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Jobs";
      this.dgJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgJobs.DataMember = "";
      this.dgJobs.HeaderForeColor = SystemColors.ControlText;
      this.dgJobs.Location = new System.Drawing.Point(8, 20);
      this.dgJobs.Name = "dgJobs";
      this.dgJobs.Size = new Size(946, 243);
      this.dgJobs.TabIndex = 14;
      this.btnResetFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnResetFilters.Location = new System.Drawing.Point(20, 431);
      this.btnResetFilters.Name = "btnResetFilters";
      this.btnResetFilters.Size = new Size(111, 23);
      this.btnResetFilters.TabIndex = 4;
      this.btnResetFilters.Text = "Reset Filters";
      this.btnResetFilters.UseVisualStyleBackColor = true;
      this.grpFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilters.Controls.Add((Control) this.chkSortPostcode);
      this.grpFilters.Controls.Add((Control) this.cboJobType);
      this.grpFilters.Controls.Add((Control) this.lblJobType);
      this.grpFilters.Controls.Add((Control) this.txtJobsPerDay);
      this.grpFilters.Controls.Add((Control) this.cboLetterNumber);
      this.grpFilters.Controls.Add((Control) this.lblJobsPerDay);
      this.grpFilters.Controls.Add((Control) this.Label14);
      this.grpFilters.Controls.Add((Control) this.btnFilter);
      this.grpFilters.Controls.Add((Control) this.Label1);
      this.grpFilters.Controls.Add((Control) this.dtpLetterCreateDate);
      this.grpFilters.Location = new System.Drawing.Point(12, 38);
      this.grpFilters.Name = "grpFilters";
      this.grpFilters.Size = new Size(962, 81);
      this.grpFilters.TabIndex = 5;
      this.grpFilters.TabStop = false;
      this.grpFilters.Text = "Filters";
      this.chkSortPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkSortPostcode.AutoSize = true;
      this.chkSortPostcode.Checked = true;
      this.chkSortPostcode.CheckState = CheckState.Checked;
      this.chkSortPostcode.Location = new System.Drawing.Point(440, 49);
      this.chkSortPostcode.Name = "chkSortPostcode";
      this.chkSortPostcode.Size = new Size(123, 17);
      this.chkSortPostcode.TabIndex = 46;
      this.chkSortPostcode.Text = "Sort by postcode";
      this.chkSortPostcode.UseVisualStyleBackColor = true;
      this.cboJobType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboJobType.Cursor = Cursors.Hand;
      this.cboJobType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboJobType.Location = new System.Drawing.Point(258, 47);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new Size(167, 21);
      this.cboJobType.TabIndex = 43;
      this.cboJobType.Tag = (object) "Site.RegionID";
      this.lblJobType.AutoSize = true;
      this.lblJobType.Location = new System.Drawing.Point(178, 50);
      this.lblJobType.Name = "lblJobType";
      this.lblJobType.Size = new Size(62, 13);
      this.lblJobType.TabIndex = 42;
      this.lblJobType.Text = "Job Type:";
      this.txtJobsPerDay.Location = new System.Drawing.Point(94, 47);
      this.txtJobsPerDay.Name = "txtJobsPerDay";
      this.txtJobsPerDay.Size = new Size(53, 21);
      this.txtJobsPerDay.TabIndex = 5;
      this.txtJobsPerDay.Text = "32";
      this.cboLetterNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboLetterNumber.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLetterNumber.Location = new System.Drawing.Point(424, 14);
      this.cboLetterNumber.Name = "cboLetterNumber";
      this.cboLetterNumber.Size = new Size(324, 21);
      this.cboLetterNumber.TabIndex = 41;
      this.lblJobsPerDay.AutoSize = true;
      this.lblJobsPerDay.Location = new System.Drawing.Point(6, 50);
      this.lblJobsPerDay.Name = "lblJobsPerDay";
      this.lblJobsPerDay.Size = new Size(82, 13);
      this.lblJobsPerDay.TabIndex = 4;
      this.lblJobsPerDay.Text = "Jobs Per Day";
      this.Label14.Location = new System.Drawing.Point(360, 18);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(96, 16);
      this.Label14.TabIndex = 40;
      this.Label14.Text = "Letter No.";
      this.btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFilter.Location = new System.Drawing.Point(879, 39);
      this.btnFilter.Name = "btnFilter";
      this.btnFilter.Size = new Size(75, 23);
      this.btnFilter.TabIndex = 30;
      this.btnFilter.Text = "Filter";
      this.btnFilter.UseVisualStyleBackColor = true;
      this.Label1.Location = new System.Drawing.Point(6, 17);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(130, 16);
      this.Label1.TabIndex = 29;
      this.Label1.Text = "Letter Create Date";
      this.dtpLetterCreateDate.Location = new System.Drawing.Point(142, 12);
      this.dtpLetterCreateDate.Name = "dtpLetterCreateDate";
      this.dtpLetterCreateDate.Size = new Size(200, 21);
      this.dtpLetterCreateDate.TabIndex = 28;
      this.btnSelectAll.Location = new System.Drawing.Point(12, 125);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(119, 23);
      this.btnSelectAll.TabIndex = 6;
      this.btnSelectAll.Text = "Select All";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.btnUnselect.Location = new System.Drawing.Point(154, 125);
      this.btnUnselect.Name = "btnUnselect";
      this.btnUnselect.Size = new Size(96, 23);
      this.btnUnselect.TabIndex = 7;
      this.btnUnselect.Text = "Unselect All";
      this.btnUnselect.UseVisualStyleBackColor = true;
      this.btnGenerateLetters.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnGenerateLetters.Location = new System.Drawing.Point(808, 431);
      this.btnGenerateLetters.Name = "btnGenerateLetters";
      this.btnGenerateLetters.Size = new Size(158, 23);
      this.btnGenerateLetters.TabIndex = 8;
      this.btnGenerateLetters.Text = "Generate Jobs";
      this.btnGenerateLetters.UseVisualStyleBackColor = true;
      this.chkScheduleJobs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkScheduleJobs.AutoSize = true;
      this.chkScheduleJobs.Checked = true;
      this.chkScheduleJobs.CheckState = CheckState.Checked;
      this.chkScheduleJobs.Location = new System.Drawing.Point(867, 131);
      this.chkScheduleJobs.Name = "chkScheduleJobs";
      this.chkScheduleJobs.Size = new Size(107, 17);
      this.chkScheduleJobs.TabIndex = 45;
      this.chkScheduleJobs.Text = "Schedule Jobs";
      this.chkScheduleJobs.UseVisualStyleBackColor = true;
      this.btnFindSite.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnFindSite.Location = new System.Drawing.Point(137, 431);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(111, 23);
      this.btnFindSite.TabIndex = 46;
      this.btnFindSite.Text = "Find Site";
      this.btnFindSite.UseVisualStyleBackColor = true;
      this.cmsAction.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.tsmiDeleteSite,
        (ToolStripItem) this.tsmiCreateJob
      });
      this.cmsAction.Name = "cmsAction";
      this.cmsAction.Size = new Size(130, 48);
      this.tsmiDeleteSite.Name = "tsmiDeleteSite";
      this.tsmiDeleteSite.Size = new Size(129, 22);
      this.tsmiDeleteSite.Text = "Delete Site";
      this.tsmiCreateJob.Name = "tsmiCreateJob";
      this.tsmiCreateJob.Size = new Size(129, 22);
      this.tsmiCreateJob.Text = "Create Job";
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(986, 466);
      this.Controls.Add((Control) this.btnFindSite);
      this.Controls.Add((Control) this.chkScheduleJobs);
      this.Controls.Add((Control) this.btnGenerateLetters);
      this.Controls.Add((Control) this.btnUnselect);
      this.Controls.Add((Control) this.btnSelectAll);
      this.Controls.Add((Control) this.grpFilters);
      this.Controls.Add((Control) this.btnResetFilters);
      this.Controls.Add((Control) this.grpJobs);
      this.Name = nameof (FRMJobImportManager);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Letter Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.Controls.SetChildIndex((Control) this.btnResetFilters, 0);
      this.Controls.SetChildIndex((Control) this.grpFilters, 0);
      this.Controls.SetChildIndex((Control) this.btnSelectAll, 0);
      this.Controls.SetChildIndex((Control) this.btnUnselect, 0);
      this.Controls.SetChildIndex((Control) this.btnGenerateLetters, 0);
      this.Controls.SetChildIndex((Control) this.chkScheduleJobs, 0);
      this.Controls.SetChildIndex((Control) this.btnFindSite, 0);
      this.grpJobs.ResumeLayout(false);
      this.dgJobs.EndInit();
      this.grpFilters.ResumeLayout(false);
      this.grpFilters.PerformLayout();
      this.cmsAction.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual GroupBox grpJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgJobs
    {
      get
      {
        return this._dgJobs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgJobs_Click);
        DataGrid dgJobs1 = this._dgJobs;
        if (dgJobs1 != null)
          dgJobs1.Click -= eventHandler;
        this._dgJobs = value;
        DataGrid dgJobs2 = this._dgJobs;
        if (dgJobs2 == null)
          return;
        dgJobs2.Click += eventHandler;
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

    internal virtual TextBox txtJobsPerDay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobsPerDay { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkScheduleJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkSortPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ContextMenuStrip cmsAction { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem tsmiDeleteSite
    {
      get
      {
        return this._tsmiDeleteSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiDeleteSite_Click);
        ToolStripMenuItem tsmiDeleteSite1 = this._tsmiDeleteSite;
        if (tsmiDeleteSite1 != null)
          tsmiDeleteSite1.Click -= eventHandler;
        this._tsmiDeleteSite = value;
        ToolStripMenuItem tsmiDeleteSite2 = this._tsmiDeleteSite;
        if (tsmiDeleteSite2 == null)
          return;
        tsmiDeleteSite2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem tsmiCreateJob
    {
      get
      {
        return this._tsmiCreateJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiCreateJob_Click);
        ToolStripMenuItem tsmiCreateJob1 = this._tsmiCreateJob;
        if (tsmiCreateJob1 != null)
          tsmiCreateJob1.Click -= eventHandler;
        this._tsmiCreateJob = value;
        ToolStripMenuItem tsmiCreateJob2 = this._tsmiCreateJob;
        if (tsmiCreateJob2 == null)
          return;
        tsmiCreateJob2.Click += eventHandler;
      }
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboLetterNumber1 = this.cboLetterNumber;
      Combo.SetUpCombo(ref cboLetterNumber1, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboLetterNumber = cboLetterNumber1;
      this.cboLetterNumber.Items.RemoveAt(0);
      this.cboLetterNumber.Items.RemoveAt(2);
      ComboBox cboLetterNumber2 = this.cboLetterNumber;
      Combo.SetSelectedComboItem_By_Value(ref cboLetterNumber2, Conversions.ToString(1));
      this.cboLetterNumber = cboLetterNumber2;
      ComboBox cboJobType = this.cboJobType;
      Combo.SetUpCombo(ref cboJobType, App.DB.JobImports.JobImportType_GetAll().Table, "JobImportTypeID", "Name", Enums.ComboValues.Please_Select);
      this.cboJobType = cboJobType;
      this.SetupJobDataGrid();
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

    private DataView JobsDataView
    {
      get
      {
        return this._dvJobs;
      }
      set
      {
        this._dvJobs = value;
        this._dvJobs.Table.TableName = Enums.TableNames.tblJob.ToString();
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

    private void SetupJobDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgJobs.TableStyles[0];
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
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Address 1";
      dataGridLabelColumn2.MappingName = "Address1";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Address 2";
      dataGridLabelColumn3.MappingName = "Address2";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 120;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Address 3";
      dataGridLabelColumn4.MappingName = "Address3";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 120;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Postcode";
      dataGridLabelColumn5.MappingName = "Postcode";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 85;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Tel No.";
      dataGridLabelColumn6.MappingName = "TelNo";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 175;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "UPRN";
      dataGridLabelColumn7.MappingName = "UPRN";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Type";
      dataGridLabelColumn8.MappingName = "Type";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 75;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "dd/MM/yyyy";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Letter 1 Date";
      dataGridLabelColumn9.MappingName = "Letter1";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 110;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "dd/MM/yyyy";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Letter 2 Date";
      dataGridLabelColumn10.MappingName = "Letter2";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 110;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "dddd dd/MM/yyyy";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Suggested Visit Date";
      dataGridLabelColumn11.MappingName = "NextVisitDate";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 130;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "AM/PM";
      dataGridLabelColumn12.MappingName = "AMPM";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 50;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "Engineer";
      dataGridLabelColumn13.MappingName = "EngName";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 180;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblJob.ToString();
      this.dgJobs.TableStyles.Add(tableStyle);
    }

    private void FRMJobManager_Load(object sender, EventArgs e)
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
        if (all.Table.Select("BankHolidayDate='" + Conversions.ToString(Conversions.ToDate(Microsoft.VisualBasic.Strings.Format((object) dateTime, "dd/MM/yyyy"))) + "'").Length > 0)
          flag = true;
        else if (dateTime.DayOfWeek != DayOfWeek.Saturday & (uint) dateTime.DayOfWeek > 0U)
          break;
        checked { ++num; }
      }
      while (num <= 13);
      if (flag && App.ShowMessage("Bank Holdiays are due soon, would you like to amended the filter dates before proceeding", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        return;
      this.PopulateDatagrid();
      this.GetAppointments(false);
      this.btnGenerateLetters.Enabled = true;
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      if (this.JobsDataView == null || this.JobsDataView.Count <= 0)
        return;
      DataRow[] dataRowArray = this.JobsDataView.Table.Select(this.JobsDataView.RowFilter);
      int index = 0;
      while (index < dataRowArray.Length)
      {
        dataRowArray[index]["Tick"] = (object) true;
        checked { ++index; }
      }
    }

    private void btnUnselect_Click(object sender, EventArgs e)
    {
      if (this.JobsDataView == null || this.JobsDataView.Count <= 0)
        return;
      DataRow[] dataRowArray = this.JobsDataView.Table.Select(this.JobsDataView.RowFilter);
      int index = 0;
      while (index < dataRowArray.Length)
      {
        dataRowArray[index]["Tick"] = (object) false;
        checked { ++index; }
      }
    }

    private void btnGenerateLetters_Click(object sender, EventArgs e)
    {
      this.GetAppointments(true);
      this.PopulateDatagrid();
      this.GetAppointments(false);
    }

    private void dgJobs_Click(object sender, EventArgs e)
    {
      if (this.SelectedJobDataRow == null)
        return;
      this.dgJobs[this.dgJobs.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgJobs[this.dgJobs.CurrentRowIndex, 0]);
    }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, 0, "", false));
      if ((uint) integer > 0U)
      {
        FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) integer, SiteSQL.GetBy.SiteId, (object) null);
        if (site != null && site.Exists)
        {
          this.grpJobs.Text = "Sites";
          this.JobsDataView = App.DB.JobImports.JobImport_Get_BySiteID(site.SiteID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboJobType)));
          if (this.JobsDataView.Count > 0)
            this.dgJobs.ContextMenuStrip = this.cmsAction;
          else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboJobType)) == 0.0)
          {
            int num = (int) App.ShowMessage("If you want to add site to the process.\r\nPlease select a work stream for site", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          else
          {
            if (App.ShowMessage("Add site to " + Combo.get_GetSelectedItemDescription(this.cboJobType) + " process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
              return;
            FSM.Entity.JobImport.JobImport oJobImport = new FSM.Entity.JobImport.JobImport();
            FSM.Entity.JobImport.JobImport jobImport = oJobImport;
            jobImport.SetSiteID = (object) site.SiteID;
            jobImport.SetUPRN = (object) site.PolicyNumber;
            jobImport.SetJobImportTypeID = (object) Combo.get_GetSelectedItemValue(this.cboJobType);
            jobImport.DateAdded = DateAndTime.Now;
            if (App.DB.JobImports.JobImport_Insert(oJobImport).Exists && App.ShowMessage("Create job?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              this.JobsDataView = App.DB.JobImports.JobImport_Get_BySiteID(site.SiteID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboJobType)));
              this.dgJobs.ContextMenuStrip = this.cmsAction;
            }
          }
        }
      }
    }

    private void tsmiDeleteSite_Click(object sender, EventArgs e)
    {
      if (this.SelectedJobDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a site", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        try
        {
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["JobImportID"])))
          {
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["JobID"])) && App.ShowMessage("There is a job against this site!\r\n\r\nDo you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
              throw new Exception("Operation cancelled by user!");
            int jobImportId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["JobImportID"]));
            int jobImportTypeId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["JobImportTypeID"]));
            App.DB.JobImports.JobImport_Delete_WithJobType(jobImportId, jobImportTypeId);
            int num2 = (int) App.ShowMessage("Site has been removed!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          this.grpJobs.Text = "Jobs";
          this.JobsDataView = new DataView(new DataTable());
          this.dgJobs.ContextMenuStrip = (ContextMenuStrip) null;
        }
      }
    }

    private void tsmiCreateJob_Click(object sender, EventArgs e)
    {
      if (this.SelectedJobDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a site", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        try
        {
          Job job = new Job();
          Job importAdHocVisit = App.DB.Job.CreateJobImportAdHocVisit(this.SelectedJobDataRow, false);
          if (importAdHocVisit == null)
            throw new Exception("Failed to generate job");
          int jobImportId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["JobImportID"]));
          App.DB.JobImports.JobImport_Update_Job(jobImportId, importAdHocVisit);
          int num2 = (int) App.ShowMessage("Job Created\r\n\r\nJob Number: " + importAdHocVisit.JobNumber, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          this.grpJobs.Text = "Jobs";
          this.JobsDataView = new DataView(new DataTable());
          this.dgJobs.ContextMenuStrip = (ContextMenuStrip) null;
        }
      }
    }

    public void PopulateDatagrid()
    {
      try
      {
        if (Helper.MakeIntegerValid((object) this.txtJobsPerDay.Text) == 0)
        {
          int num1 = (int) App.ShowMessage("Cannot have 0 jobs a day!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          int num2 = Helper.MakeIntegerValid((object) this.txtJobsPerDay.Text);
          int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboJobType));
          DateTime DateIn = this.dtpLetterCreateDate.Value.AddDays(14.0);
          DateHelper.GetWorkingDays(DateHelper.GetTheMonday(DateIn), DateHelper.GetTheFriday(DateIn));
          bool flag = Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboLetterNumber)) == 1.0;
          DataTable table = !this.chkSortPostcode.Checked ? (flag ? App.DB.JobImports.JobImport_Get_L1Jobs_NoOrder(integer).Table : App.DB.JobImports.JobImport_Get_L2Jobs(integer).Table) : (flag ? App.DB.JobImports.JobImport_Get_L1Jobs(integer).Table : App.DB.JobImports.JobImport_Get_L2Jobs(integer).Table);
          table.Columns.Add("NextVisitDate");
          table.Columns.Add("LetterDate");
          List<DateTime> workingDates = DateHelper.GetWorkingDates(DateHelper.GetTheMonday(DateIn), DateHelper.GetTheFriday(DateIn));
          int num3 = checked (workingDates.Count * num2);
          IEnumerator enumerator;
          if (table != null && table.Rows.Count > 0)
          {
            try
            {
              enumerator = table?.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                if (current["NextVisitDate"] == null | Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["NextVisitDate"])))
                  current["NextVisitDate"] = (object) workingDates.FirstOrDefault<DateTime>();
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
          }
          this.JobsDataView = new DataView(table);
        }
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
      Combo.SetSelectedComboItem_By_Value(ref cboLetterNumber, Conversions.ToString(0));
      this.cboLetterNumber = cboLetterNumber;
      ComboBox cboJobType = this.cboJobType;
      Combo.SetSelectedComboItem_By_Value(ref cboJobType, Conversions.ToString(0));
      this.cboJobType = cboJobType;
      this.txtJobsPerDay.Text = Conversions.ToString(6);
      this.dtpLetterCreateDate.Value = DateAndTime.Now;
    }

    private bool GetAppointments(bool doJobs = false)
    {
      this.Cursor = Cursors.WaitCursor;
      DateTime now1 = DateAndTime.Now;
      DataView dataView = new DataView();
      bool flag;
      if (this.JobsDataView != null && this.JobsDataView.Count > 0)
      {
        dataView.Table = this.SelectedJobDataRow.Table;
        if (!dataView.Table.Columns.Contains("EngName"))
          dataView.Table.Columns.Add("EngName");
        if (!dataView.Table.Columns.Contains("EngineerID"))
          dataView.Table.Columns.Add("EngineerID");
        if (!dataView.Table.Columns.Contains("AMPM"))
          dataView.Table.Columns.Add("AMPM");
        if (!dataView.Table.Columns.Contains("ETA"))
          dataView.Table.Columns.Add("ETA");
        if (doJobs)
          dataView.RowFilter = "Tick = 1";
        if (dataView.Count == 0)
        {
          int num = (int) App.ShowMessage("No Services to Process!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          goto label_47;
        }
        else
        {
          dataView.Sort = "Postcode";
          DateTime DateIn = this.dtpLetterCreateDate.Value.AddDays(14.0);
          DateTime startDate = DateHelper.CheckBankHolidaySatOrSunForward(DateHelper.GetDateZeroTime(DateHelper.GetTheMonday(DateIn)), false);
          DateTime endDate = DateHelper.CheckBankHolidaySatOrSun(DateHelper.GetDateZeroTime(DateHelper.GetTheFriday(DateIn)), false).AddDays(1.0);
          int integer1 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboJobType));
          JobImportType jobImportType = App.DB.JobImports.JobImportType_Get(integer1);
          int num1 = Helper.MakeIntegerValid((object) this.txtJobsPerDay.Text);
          DataView engineerJobs = App.DB.JobImports.JobImport_Get_EngineerJobs(startDate, endDate, integer1);
          int integer2 = Conversions.ToInteger(App.DB.SystemScheduleOfRate.SystemScheduleOfRate_Get_ByEngineerQual(jobImportType.EngineerQualID).Table.Rows[0]["TimeInMins"]);
          DataView allTicked = App.DB.EngineerPostalRegion.GetALLTicked();
          try
          {
            int index = -1;
            do
            {
              checked { ++index; }
              DataRowView dataRowView = dataView[index];
              if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["Letter1"])))
                engineerJobs.RowFilter = "TheDate <= #" + DateHelper.GetTheFriday(Conversions.ToDate(dataRowView["NextVisitDate"])).ToString("yyyy-MM-dd") + "# AND TheDate >= #" + DateHelper.GetTheMonday(Conversions.ToDate(dataRowView["NextVisitDate"])).ToString("yyyy-MM-dd") + "#";
              else if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["Letter2"])))
                engineerJobs.RowFilter = "TheDate <= #" + DateHelper.GetTheFriday(Conversions.ToDate(dataRowView["NextVisitDate"])).ToString("yyyy-MM-dd") + "# AND TheDate >= #" + Conversions.ToDate(dataRowView["NextVisitDate"]).ToString("yyyy-MM-dd") + "#";
              IEnumerator enumerator;
              try
              {
                enumerator = engineerJobs.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  // ISSUE: object of a compiler-generated type is created
                  // ISSUE: variable of a compiler-generated type
                  FRMJobImportManager._Closure\u0024__117\u002D0 closure1170 = new FRMJobImportManager._Closure\u0024__117\u002D0(closure1170);
                  // ISSUE: reference to a compiler-generated field
                  closure1170.\u0024VB\u0024Local_appointment = (DataRowView) enumerator.Current;
                  // ISSUE: reference to a compiler-generated method
                  EnumerableRowCollection<DataRow> source = dataView.Table.AsEnumerable().Where<DataRow>(new Func<DataRow, bool>(closure1170._Lambda\u0024__0));
                  Func<DataRow, DataRow> selector;
                  // ISSUE: reference to a compiler-generated field
                  if (FRMJobImportManager._Closure\u0024__.\u0024I117\u002D1 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    selector = FRMJobImportManager._Closure\u0024__.\u0024I117\u002D1;
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    FRMJobImportManager._Closure\u0024__.\u0024I117\u002D1 = selector = (Func<DataRow, DataRow>) (row => row);
                  }
                  if (((IEnumerable<DataRow>) source.Select<DataRow, DataRow>(selector).ToArray<DataRow>()).Count<DataRow>() != num1)
                  {
                    // ISSUE: reference to a compiler-generated field
                    FRMJobImportManager.MaxAmPmAmounts maxAmPmAmount = this.GetMaxAmPmAmount(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(closure1170.\u0024VB\u0024Local_appointment["MaxSOR"])), integer2);
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(closure1170.\u0024VB\u0024Local_appointment["AM"])) < maxAmPmAmount.amAmount & (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["BookedVisit"])) | !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["Letter1"])))), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(closure1170.\u0024VB\u0024Local_appointment["RemainingSOR"], (object) 0, false)), (object) Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["ETA"]))), (object) (allTicked.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "EngineerID = ", closure1170.\u0024VB\u0024Local_appointment["EngineerID"]), (object) " And Name = '"), dataRowView["OutwardCode"]), (object) "'"))).Length > 0))))
                    {
                      // ISSUE: reference to a compiler-generated field
                      dataRowView["EngName"] = RuntimeHelpers.GetObjectValue(closure1170.\u0024VB\u0024Local_appointment["Name"]);
                      // ISSUE: reference to a compiler-generated field
                      dataRowView["EngineerID"] = RuntimeHelpers.GetObjectValue(closure1170.\u0024VB\u0024Local_appointment["EngineerID"]);
                      // ISSUE: reference to a compiler-generated field
                      dataRowView["NextVisitDate"] = (object) Conversions.ToDate(closure1170.\u0024VB\u0024Local_appointment["TheDate"]).ToString("dd/MM/yyyy");
                      dataRowView["AMPM"] = (object) "AM";
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      closure1170.\u0024VB\u0024Local_appointment["AM"] = (object) checked (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(closure1170.\u0024VB\u0024Local_appointment["AM"])) + 1);
                      dataRowView["LetterDate"] = (object) this.dtpLetterCreateDate.Value;
                      dataRowView["ETA"] = (object) true;
                      DataRowView localAppointment;
                      // ISSUE: reference to a compiler-generated field
                      (localAppointment = closure1170.\u0024VB\u0024Local_appointment)["RemainingSOR"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(localAppointment["RemainingSOR"], (object) integer2);
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(closure1170.\u0024VB\u0024Local_appointment["PM"])) < maxAmPmAmount.pmAmount & (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["BookedVisit"])) | !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["Letter1"])))), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(closure1170.\u0024VB\u0024Local_appointment["RemainingSOR"], (object) 0, false)), (object) Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRowView["ETA"]))), (object) (allTicked.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "EngineerID = ", closure1170.\u0024VB\u0024Local_appointment["EngineerID"]), (object) " And Name = '"), dataRowView["OutwardCode"]), (object) "'"))).Length > 0))))
                      {
                        // ISSUE: reference to a compiler-generated field
                        dataRowView["EngName"] = RuntimeHelpers.GetObjectValue(closure1170.\u0024VB\u0024Local_appointment["Name"]);
                        // ISSUE: reference to a compiler-generated field
                        dataRowView["EngineerID"] = RuntimeHelpers.GetObjectValue(closure1170.\u0024VB\u0024Local_appointment["EngineerID"]);
                        // ISSUE: reference to a compiler-generated field
                        dataRowView["NextVisitDate"] = (object) Conversions.ToDate(closure1170.\u0024VB\u0024Local_appointment["TheDate"]).ToString("dd/MM/yyyy");
                        dataRowView["AMPM"] = (object) "PM";
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        closure1170.\u0024VB\u0024Local_appointment["PM"] = (object) checked (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(closure1170.\u0024VB\u0024Local_appointment["PM"])) + 1);
                        dataRowView["LetterDate"] = (object) this.dtpLetterCreateDate.Value;
                        dataRowView["ETA"] = (object) true;
                        DataRowView localAppointment;
                        // ISSUE: reference to a compiler-generated field
                        (localAppointment = closure1170.\u0024VB\u0024Local_appointment)["RemainingSOR"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(localAppointment["RemainingSOR"], (object) integer2);
                      }
                    }
                  }
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
            }
            while (index < checked (dataView.Count - 1));
            if (this.chkScheduleJobs.Checked)
              this.JobsDataView.RowFilter = "AMPM Is Not Null";
            this.JobsDataView.Sort = "NextVisitDate ASC, AMPM ASC";
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int num2 = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
          }
          try
          {
            if (doJobs)
            {
              dataView.RowFilter = "Tick = 1";
              ArrayList arrayList = new ArrayList();
              arrayList.Add((object) dataView);
              arrayList.Add((object) this.chkScheduleJobs.Checked);
              string documentNameIn = Combo.get_GetSelectedItemDescription(this.cboJobType);
              Printing printing = new Printing((object) arrayList, documentNameIn, Enums.SystemDocumentType.JobImportLetters, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
              DateTime now2 = DateAndTime.Now;
              int num2 = (int) Interaction.MsgBox((object) ("Start: " + Conversions.ToString(now1) + "\r\nEnd: " + Conversions.ToString(now2)), MsgBoxStyle.OkOnly, (object) null);
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            flag = false;
            ProjectData.ClearProjectError();
            goto label_47;
          }
          finally
          {
            this.Cursor = Cursors.Default;
          }
        }
      }
      this.Cursor = Cursors.Default;
      flag = true;
label_47:
      return flag;
    }

    public FRMJobImportManager.MaxAmPmAmounts GetMaxAmPmAmount(
      int maxSor,
      int visitMins)
    {
      FRMJobImportManager.MaxAmPmAmounts maxAmPmAmounts1 = new FRMJobImportManager.MaxAmPmAmounts();
      int num1 = checked ((int) Math.Round(unchecked ((double) maxSor / (double) visitMins)));
      int num2 = checked ((int) Math.Round(Math.Round(unchecked ((double) num1 / 2.0), 0, MidpointRounding.AwayFromZero)));
      int num3 = checked ((int) Math.Floor(unchecked ((double) num1 / 2.0)));
      FRMJobImportManager.MaxAmPmAmounts maxAmPmAmounts2 = maxAmPmAmounts1;
      maxAmPmAmounts2.amAmount = num2;
      maxAmPmAmounts2.pmAmount = num3;
      return maxAmPmAmounts1;
    }

    public class MaxAmPmAmounts
    {
      public int amAmount;
      public int pmAmount;
    }
  }
}
