// Decompiled with JetBrains decompiler
// Type: FSM.FRMJobImport
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisits;
using FSM.Entity.JobImport;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.PickLists;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMJobImport : FRMBaseForm
  {
    private IContainer components;
    private FileInfo _file;
    private DataTable _failedImports;
    private List<FSM.Entity.Customers.Customer> _customers;
    private Engineer _engineer;

    public FRMJobImport()
    {
      this.Load += new EventHandler(this.FRMJobImport_Load);
      this._failedImports = new DataTable();
      this._customers = new List<FSM.Entity.Customers.Customer>();
      this.InitializeComponent();
      ComboBox cboJobType = this.cboJobType;
      Combo.SetUpCombo(ref cboJobType, App.DB.JobImports.JobImportType_GetAll().Table, "JobImportTypeID", "Name", Enums.ComboValues.Please_Select);
      this.cboJobType = cboJobType;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpExcelFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtExcelFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindExcelFile
    {
      get
      {
        return this._btnFindExcelFile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindExcelFile_Click);
        Button btnFindExcelFile1 = this._btnFindExcelFile;
        if (btnFindExcelFile1 != null)
          btnFindExcelFile1.Click -= eventHandler;
        this._btnFindExcelFile = value;
        Button btnFindExcelFile2 = this._btnFindExcelFile;
        if (btnFindExcelFile2 == null)
          return;
        btnFindExcelFile2.Click += eventHandler;
      }
    }

    internal virtual Button btnImport
    {
      get
      {
        return this._btnImport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnImport_Click);
        Button btnImport1 = this._btnImport;
        if (btnImport1 != null)
          btnImport1.Click -= eventHandler;
        this._btnImport = value;
        Button btnImport2 = this._btnImport;
        if (btnImport2 == null)
          return;
        btnImport2.Click += eventHandler;
      }
    }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    internal virtual ProgressBar pbStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMessages { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpFailedImports { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgFailedImports { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnExportFailed
    {
      get
      {
        return this._btnExportFailed;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExportFailed_Click);
        Button btnExportFailed1 = this._btnExportFailed;
        if (btnExportFailed1 != null)
          btnExportFailed1.Click -= eventHandler;
        this._btnExportFailed = value;
        Button btnExportFailed2 = this._btnExportFailed;
        if (btnExportFailed2 == null)
          return;
        btnExportFailed2.Click += eventHandler;
      }
    }

    internal virtual RadioButton radBtnJobStatus
    {
      get
      {
        return this._radBtnJobStatus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radBtnJob_CheckedChanged);
        RadioButton radBtnJobStatus1 = this._radBtnJobStatus;
        if (radBtnJobStatus1 != null)
          radBtnJobStatus1.CheckedChanged -= eventHandler;
        this._radBtnJobStatus = value;
        RadioButton radBtnJobStatus2 = this._radBtnJobStatus;
        if (radBtnJobStatus2 == null)
          return;
        radBtnJobStatus2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton radBtnJob
    {
      get
      {
        return this._radBtnJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radBtnJob_CheckedChanged);
        RadioButton radBtnJob1 = this._radBtnJob;
        if (radBtnJob1 != null)
          radBtnJob1.CheckedChanged -= eventHandler;
        this._radBtnJob = value;
        RadioButton radBtnJob2 = this._radBtnJob;
        if (radBtnJob2 == null)
          return;
        radBtnJob2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label lblJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label lblCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindEngineer
    {
      get
      {
        return this._btnFindEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindEngineer_Click);
        Button btnFindEngineer1 = this._btnFindEngineer;
        if (btnFindEngineer1 != null)
          btnFindEngineer1.Click -= eventHandler;
        this._btnFindEngineer = value;
        Button btnFindEngineer2 = this._btnFindEngineer;
        if (btnFindEngineer2 == null)
          return;
        btnFindEngineer2.Click += eventHandler;
      }
    }

    internal virtual Label lblEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkCreateJob
    {
      get
      {
        return this._chkCreateJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkCreateJob_Click);
        CheckBox chkCreateJob1 = this._chkCreateJob;
        if (chkCreateJob1 != null)
          chkCreateJob1.Click -= eventHandler;
        this._chkCreateJob = value;
        CheckBox chkCreateJob2 = this._chkCreateJob;
        if (chkCreateJob2 == null)
          return;
        chkCreateJob2.Click += eventHandler;
      }
    }

    internal virtual Label lblProgress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpExcelFile = new GroupBox();
      this.txtCustomer = new TextBox();
      this.btnFindCustomer = new Button();
      this.lblCustomer = new Label();
      this.radBtnJobStatus = new RadioButton();
      this.radBtnJob = new RadioButton();
      this.cboJobType = new ComboBox();
      this.lblJobType = new Label();
      this.lblFile = new Label();
      this.btnImport = new Button();
      this.btnFindExcelFile = new Button();
      this.txtExcelFile = new TextBox();
      this.btnClose = new Button();
      this.pbStatus = new ProgressBar();
      this.lblProgress = new Label();
      this.lblMessages = new Label();
      this.grpFailedImports = new GroupBox();
      this.dgFailedImports = new DataGrid();
      this.btnExportFailed = new Button();
      this.txtEngineer = new TextBox();
      this.btnFindEngineer = new Button();
      this.lblEngineer = new Label();
      this.dtpVisitDate = new DateTimePicker();
      this.lblVisitDate = new Label();
      this.chkCreateJob = new CheckBox();
      this.grpExcelFile.SuspendLayout();
      this.grpFailedImports.SuspendLayout();
      this.dgFailedImports.BeginInit();
      this.SuspendLayout();
      this.grpExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpExcelFile.Controls.Add((Control) this.chkCreateJob);
      this.grpExcelFile.Controls.Add((Control) this.lblVisitDate);
      this.grpExcelFile.Controls.Add((Control) this.dtpVisitDate);
      this.grpExcelFile.Controls.Add((Control) this.txtEngineer);
      this.grpExcelFile.Controls.Add((Control) this.btnFindEngineer);
      this.grpExcelFile.Controls.Add((Control) this.lblEngineer);
      this.grpExcelFile.Controls.Add((Control) this.txtCustomer);
      this.grpExcelFile.Controls.Add((Control) this.btnFindCustomer);
      this.grpExcelFile.Controls.Add((Control) this.lblCustomer);
      this.grpExcelFile.Controls.Add((Control) this.radBtnJobStatus);
      this.grpExcelFile.Controls.Add((Control) this.radBtnJob);
      this.grpExcelFile.Controls.Add((Control) this.cboJobType);
      this.grpExcelFile.Controls.Add((Control) this.lblJobType);
      this.grpExcelFile.Controls.Add((Control) this.lblFile);
      this.grpExcelFile.Controls.Add((Control) this.btnImport);
      this.grpExcelFile.Controls.Add((Control) this.btnFindExcelFile);
      this.grpExcelFile.Controls.Add((Control) this.txtExcelFile);
      this.grpExcelFile.FlatStyle = FlatStyle.System;
      this.grpExcelFile.Location = new System.Drawing.Point(8, 40);
      this.grpExcelFile.Name = "grpExcelFile";
      this.grpExcelFile.Size = new Size(896, 134);
      this.grpExcelFile.TabIndex = 3;
      this.grpExcelFile.TabStop = false;
      this.grpExcelFile.Text = "Select data file to import";
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Location = new System.Drawing.Point(429, 56);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(423, 21);
      this.txtCustomer.TabIndex = 40;
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.Location = new System.Drawing.Point(858, 54);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 39;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = true;
      this.lblCustomer.AutoSize = true;
      this.lblCustomer.Location = new System.Drawing.Point(349, 59);
      this.lblCustomer.Name = "lblCustomer";
      this.lblCustomer.Size = new Size(74, 13);
      this.lblCustomer.TabIndex = 38;
      this.lblCustomer.Text = "Customers:";
      this.radBtnJobStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.radBtnJobStatus.AutoSize = true;
      this.radBtnJobStatus.Checked = true;
      this.radBtnJobStatus.Location = new System.Drawing.Point(670, 24);
      this.radBtnJobStatus.Name = "radBtnJobStatus";
      this.radBtnJobStatus.Size = new Size(84, 17);
      this.radBtnJobStatus.TabIndex = 37;
      this.radBtnJobStatus.TabStop = true;
      this.radBtnJobStatus.Text = "Job Status";
      this.radBtnJobStatus.UseVisualStyleBackColor = true;
      this.radBtnJob.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.radBtnJob.AutoSize = true;
      this.radBtnJob.Location = new System.Drawing.Point(760, 24);
      this.radBtnJob.Name = "radBtnJob";
      this.radBtnJob.Size = new Size(44, 17);
      this.radBtnJob.TabIndex = 36;
      this.radBtnJob.Text = "Job";
      this.radBtnJob.UseVisualStyleBackColor = true;
      this.cboJobType.Cursor = Cursors.Hand;
      this.cboJobType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboJobType.Location = new System.Drawing.Point(86, 56);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new Size(242, 21);
      this.cboJobType.TabIndex = 35;
      this.cboJobType.Tag = (object) "Site.RegionID";
      this.lblJobType.AutoSize = true;
      this.lblJobType.Location = new System.Drawing.Point(6, 59);
      this.lblJobType.Name = "lblJobType";
      this.lblJobType.Size = new Size(62, 13);
      this.lblJobType.TabIndex = 19;
      this.lblJobType.Text = "Job Type:";
      this.lblFile.AutoSize = true;
      this.lblFile.Location = new System.Drawing.Point(6, 23);
      this.lblFile.Name = "lblFile";
      this.lblFile.Size = new Size(31, 13);
      this.lblFile.TabIndex = 13;
      this.lblFile.Text = "File:";
      this.btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnImport.Enabled = false;
      this.btnImport.FlatStyle = FlatStyle.System;
      this.btnImport.Location = new System.Drawing.Point(826, 18);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new Size(64, 23);
      this.btnImport.TabIndex = 7;
      this.btnImport.Text = "Import";
      this.btnFindExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindExcelFile.FlatStyle = FlatStyle.System;
      this.btnFindExcelFile.Location = new System.Drawing.Point(616, 20);
      this.btnFindExcelFile.Name = "btnFindExcelFile";
      this.btnFindExcelFile.Size = new Size(32, 23);
      this.btnFindExcelFile.TabIndex = 5;
      this.btnFindExcelFile.Text = "...";
      this.txtExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtExcelFile.Location = new System.Drawing.Point(43, 20);
      this.txtExcelFile.Name = "txtExcelFile";
      this.txtExcelFile.ReadOnly = true;
      this.txtExcelFile.Size = new Size(567, 21);
      this.txtExcelFile.TabIndex = 4;
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnClose.FlatStyle = FlatStyle.System;
      this.btnClose.Location = new System.Drawing.Point(848, 624);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 23);
      this.btnClose.TabIndex = 9;
      this.btnClose.Text = "Close";
      this.pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pbStatus.Location = new System.Drawing.Point(8, 624);
      this.pbStatus.Name = "pbStatus";
      this.pbStatus.Size = new Size(784, 23);
      this.pbStatus.Step = 1;
      this.pbStatus.TabIndex = 10;
      this.lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.lblProgress.Location = new System.Drawing.Point(800, 627);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new Size(40, 16);
      this.lblProgress.TabIndex = 11;
      this.lblProgress.Text = "0%";
      this.lblProgress.TextAlign = ContentAlignment.MiddleRight;
      this.lblMessages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblMessages.Font = new System.Drawing.Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMessages.ForeColor = Color.Red;
      this.lblMessages.Location = new System.Drawing.Point(5, 595);
      this.lblMessages.Name = "lblMessages";
      this.lblMessages.Size = new Size(787, 19);
      this.lblMessages.TabIndex = 12;
      this.lblMessages.TextAlign = ContentAlignment.MiddleLeft;
      this.lblMessages.Visible = false;
      this.grpFailedImports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFailedImports.Controls.Add((Control) this.dgFailedImports);
      this.grpFailedImports.FlatStyle = FlatStyle.System;
      this.grpFailedImports.Location = new System.Drawing.Point(8, 180);
      this.grpFailedImports.Name = "grpFailedImports";
      this.grpFailedImports.Size = new Size(896, 402);
      this.grpFailedImports.TabIndex = 15;
      this.grpFailedImports.TabStop = false;
      this.grpFailedImports.Text = "Failed Imports";
      this.dgFailedImports.DataMember = "";
      this.dgFailedImports.Dock = DockStyle.Fill;
      this.dgFailedImports.HeaderForeColor = SystemColors.ControlText;
      this.dgFailedImports.Location = new System.Drawing.Point(3, 17);
      this.dgFailedImports.Name = "dgFailedImports";
      this.dgFailedImports.Size = new Size(890, 382);
      this.dgFailedImports.TabIndex = 45;
      this.btnExportFailed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnExportFailed.FlatStyle = FlatStyle.System;
      this.btnExportFailed.Location = new System.Drawing.Point(800, 593);
      this.btnExportFailed.Name = "btnExportFailed";
      this.btnExportFailed.Size = new Size(104, 23);
      this.btnExportFailed.TabIndex = 16;
      this.btnExportFailed.Text = "Export Failures";
      this.btnExportFailed.Visible = false;
      this.txtEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEngineer.Location = new System.Drawing.Point(616, 93);
      this.txtEngineer.Name = "txtEngineer";
      this.txtEngineer.ReadOnly = true;
      this.txtEngineer.Size = new Size(236, 21);
      this.txtEngineer.TabIndex = 43;
      this.btnFindEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindEngineer.Enabled = false;
      this.btnFindEngineer.Location = new System.Drawing.Point(858, 91);
      this.btnFindEngineer.Name = "btnFindEngineer";
      this.btnFindEngineer.Size = new Size(32, 23);
      this.btnFindEngineer.TabIndex = 42;
      this.btnFindEngineer.Text = "...";
      this.btnFindEngineer.UseVisualStyleBackColor = true;
      this.lblEngineer.AutoSize = true;
      this.lblEngineer.Location = new System.Drawing.Point(548, 96);
      this.lblEngineer.Name = "lblEngineer";
      this.lblEngineer.Size = new Size(62, 13);
      this.lblEngineer.TabIndex = 41;
      this.lblEngineer.Text = "Engineer:";
      this.dtpVisitDate.Enabled = false;
      this.dtpVisitDate.Location = new System.Drawing.Point(370, 93);
      this.dtpVisitDate.Name = "dtpVisitDate";
      this.dtpVisitDate.Size = new Size(151, 21);
      this.dtpVisitDate.TabIndex = 44;
      this.lblVisitDate.AutoSize = true;
      this.lblVisitDate.Location = new System.Drawing.Point(290, 96);
      this.lblVisitDate.Name = "lblVisitDate";
      this.lblVisitDate.Size = new Size(67, 13);
      this.lblVisitDate.TabIndex = 45;
      this.lblVisitDate.Text = "Visit Date:";
      this.chkCreateJob.AutoCheck = false;
      this.chkCreateJob.AutoSize = true;
      this.chkCreateJob.Location = new System.Drawing.Point(9, 95);
      this.chkCreateJob.Name = "chkCreateJob";
      this.chkCreateJob.Size = new Size(94, 17);
      this.chkCreateJob.TabIndex = 46;
      this.chkCreateJob.Text = "Create Jobs";
      this.chkCreateJob.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(912, 654);
      this.Controls.Add((Control) this.btnExportFailed);
      this.Controls.Add((Control) this.grpFailedImports);
      this.Controls.Add((Control) this.lblMessages);
      this.Controls.Add((Control) this.lblProgress);
      this.Controls.Add((Control) this.pbStatus);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.grpExcelFile);
      this.MinimumSize = new Size(920, 688);
      this.Name = nameof (FRMJobImport);
      this.Text = "Job Importer";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpExcelFile, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.pbStatus, 0);
      this.Controls.SetChildIndex((Control) this.lblProgress, 0);
      this.Controls.SetChildIndex((Control) this.lblMessages, 0);
      this.Controls.SetChildIndex((Control) this.grpFailedImports, 0);
      this.Controls.SetChildIndex((Control) this.btnExportFailed, 0);
      this.grpExcelFile.ResumeLayout(false);
      this.grpExcelFile.PerformLayout();
      this.grpFailedImports.ResumeLayout(false);
      this.dgFailedImports.EndInit();
      this.ResumeLayout(false);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public FileInfo File
    {
      get
      {
        return this._file;
      }
      set
      {
        this._file = value;
      }
    }

    private DataTable FailedImports
    {
      get
      {
        return this._failedImports;
      }
      set
      {
        this._failedImports = value;
      }
    }

    public List<FSM.Entity.Customers.Customer> Customers
    {
      get
      {
        return this._customers;
      }
      set
      {
        this._customers = value;
        if (this._customers.Count > 0)
        {
          string empty = string.Empty;
          bool flag = false;
          try
          {
            foreach (FSM.Entity.Customers.Customer customer in this._customers)
            {
              if (flag)
                empty += ", ";
              empty += customer.Name;
              flag = true;
            }
          }
          finally
          {
            List<FSM.Entity.Customers.Customer>.Enumerator enumerator;
            enumerator.Dispose();
          }
          this.txtCustomer.Text = empty;
        }
        else
          this.txtCustomer.Text = "";
      }
    }

    public Engineer Engineer
    {
      get
      {
        return this._engineer;
      }
      set
      {
        this._engineer = value;
        if (this._engineer != null)
          this.txtEngineer.Text = this.Engineer.Name;
        else
          this.txtEngineer.Text = "<Not Set>";
      }
    }

    private void FRMJobImport_Load(object sender, EventArgs e)
    {
      this.radBtnJob.Visible = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Compliance);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnFindExcelFile_Click(object sender, EventArgs e)
    {
      this.LoadData();
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      this.Import();
    }

    private void btnExportFailed_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void LoadData()
    {
      OpenFileDialog openFileDialog;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        this.btnFindExcelFile.Enabled = false;
        this.txtExcelFile.Text = "";
        this.btnImport.Enabled = false;
        openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension, ".xls", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(fileInfo.Extension, ".xlsx", false) == 0)
        {
          this.File = fileInfo;
          this.txtExcelFile.Text = this.File.FullName;
          this.btnImport.Enabled = true;
        }
        else
        {
          int num = (int) App.ShowMessage("File must be .xls, or .xlsx.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        this.txtExcelFile.Text = "";
        this.btnImport.Enabled = false;
        int num = (int) App.ShowMessage("File data could not be loaded : \r\n" + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        openFileDialog.Dispose();
        this.btnFindExcelFile.Enabled = true;
        Cursor.Current = Cursors.Default;
      }
    }

    private void Import()
    {
      int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboJobType));
      if (this.radBtnJob.Checked)
      {
        if (integer == 0)
        {
          int num = (int) App.ShowMessage("Please select a job type", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          return;
        }
        if (this.Customers.Count == 0)
        {
          int num = (int) App.ShowMessage("Please select a customer", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          return;
        }
      }
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Application instance;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        this.btnClose.Enabled = false;
        this.btnFindExcelFile.Enabled = false;
        this.btnImport.Enabled = false;
        this.pbStatus.Value = 0;
        this.cboJobType.Enabled = false;
        instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
        instance.DisplayAlerts = false;
        // ISSUE: reference to a compiler-generated method
        instance.Workbooks.Add((object) this.File.FullName);
        // ISSUE: variable of a compiler-generated type
        Worksheet worksheet = (Worksheet) instance.Worksheets[(object) 1];
        string cmdText = " SELECT * FROM [" + worksheet.Name + "$]";
        string connectionString = "";
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.File.Extension.Trim().ToLower(), ".xls".ToLower(), false) == 0)
          connectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + this.File.FullName + " ; Extended Properties=Excel 8.0; ";
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.File.Extension.Trim().ToLower(), ".xlsx".ToLower(), false) == 0)
          connectionString = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + this.File.FullName + " ; Extended Properties=Excel 12.0; ";
        OleDbConnection connection = new OleDbConnection(connectionString);
        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
        DataSet dataSet = new DataSet();
        oleDbDataAdapter.SelectCommand = new OleDbCommand(cmdText, connection);
        dataSet.Clear();
        oleDbDataAdapter.Fill(dataSet);
        if (this.radBtnJob.Checked)
          this.ImportJobs(dataSet, integer);
        else
          this.ImportJobsStatus(dataSet);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("File data could not be imported : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.KillInstances(instance);
        string path = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) App.TheSystem.Configuration.DocumentsLocation, Interaction.IIf(this.radBtnJob.Checked, (object) "JobImports\\", (object) "JobImports\\JobStatusImports\\")));
        Directory.CreateDirectory(path);
        string extension = Path.GetExtension(this.File.Name);
        System.IO.File.Move(this.File.FullName, path + this.File.Name.Replace(extension, "_" + DateAndTime.Now.ToString("dd_MMM_yyyy_HH_mm_ss") + extension));
        this.File = (FileInfo) null;
        this.txtExcelFile.Text = "";
        if (this.FailedImports.Rows.Count > 0)
          this.btnExportFailed.Visible = true;
        this.pbStatus.Value = this.pbStatus.Maximum;
        this.btnClose.Enabled = true;
        this.btnFindExcelFile.Enabled = true;
        this.cboJobType.Enabled = true;
        this.btnImport.Enabled = true;
        this.pbStatus.Value = 0;
        Cursor.Current = Cursors.Default;
      }
    }

    private void ImportJobsStatus(DataSet data)
    {
      data.Tables[0].Columns.Add("Failure Reason");
      this.FailedImports = data.Tables[0].Clone();
      this.pbStatus.Maximum = data.Tables[0].Rows.Count;
      int num1 = checked (data.Tables[0].Rows.Count - 1);
      int index = 0;
      while (index <= num1)
      {
        DataRow row = data.Tables[0].Rows[index];
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        string empty3 = string.Empty;
        EngineerVisit engineerVisit = (EngineerVisit) null;
        if (data.Tables[0].Columns.Contains("EngineerVisitID"))
        {
          if (row["EngineerVisitID"] != DBNull.Value)
          {
            try
            {
              engineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(row["EngineerVisitID"]), true);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              ProjectData.ClearProjectError();
            }
          }
        }
        DateTime dateTime;
        if (engineerVisit == null)
        {
          if (row["JobNumber"] == DBNull.Value)
          {
            row["Failure Reason"] = (object) "No job number";
            this.FailedImports.ImportRow(row);
            goto label_40;
          }
          else
          {
            string jobNumber = Conversions.ToString(row["JobNumber"]);
            if (row["StartDateTime"] == DBNull.Value)
            {
              row["Failure Reason"] = (object) "No visit start date";
              this.FailedImports.ImportRow(row);
              goto label_40;
            }
            else
            {
              string str = Conversions.ToString(row["StartDateTime"]);
              DataView allJobNumberLight = App.DB.EngineerVisits.EngineerVisits_Get_All_JobNumber_Light(jobNumber);
              IEnumerator enumerator;
              if (allJobNumberLight.Count <= 0)
              {
                row["Failure Reason"] = (object) "Cannot find any visits associated to job number";
                this.FailedImports.ImportRow(row);
                goto label_40;
              }
              else
              {
                try
                {
                  enumerator = allJobNumberLight.Table.Rows.GetEnumerator();
                  while (enumerator.MoveNext())
                  {
                    DataRow current = (DataRow) enumerator.Current;
                    dateTime = Conversions.ToDate(current["StartDateTime"]);
                    DateTime date1 = dateTime.Date;
                    dateTime = Conversions.ToDate(str);
                    DateTime date2 = dateTime.Date;
                    if (DateTime.Compare(date1, date2) == 0)
                      engineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(current["EngineerVisitID"]), true);
                  }
                }
                finally
                {
                  if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
                }
              }
            }
          }
        }
        if (row["Status"] == DBNull.Value)
        {
          row["Failure Reason"] = (object) "No status found";
          this.FailedImports.ImportRow(row);
        }
        else
        {
          string str = Conversions.ToString(row["Status"]);
          if (engineerVisit != null)
          {
            if (row["StartDateTime"] == DBNull.Value)
            {
              row["Failure Reason"] = (object) "No visit start date";
              this.FailedImports.ImportRow(row);
            }
            else
            {
              dateTime = Conversions.ToDate(Conversions.ToString(row["StartDateTime"]));
              DateTime date1 = dateTime.Date;
              dateTime = engineerVisit.StartDateTime;
              DateTime date2 = dateTime.Date;
              if ((uint) DateTime.Compare(date1, date2) > 0U)
              {
                row["Failure Reason"] = (object) "Start date does not match";
                this.FailedImports.ImportRow(row);
              }
              else if (engineerVisit.StatusEnumID != 5)
              {
                row["Failure Reason"] = (object) "Visit Status has already been updated";
                this.FailedImports.ImportRow(row);
              }
              else
              {
                int outcomeEnumID;
                switch (Helper.MakeIntegerValid((object) str))
                {
                  case 0:
                    row["Failure Reason"] = (object) "Please manually rescheduled";
                    this.FailedImports.ImportRow(row);
                    goto label_40;
                  case 1:
                    outcomeEnumID = 2;
                    break;
                  case 2:
                    outcomeEnumID = 1;
                    break;
                  default:
                    row["Failure Reason"] = (object) "Invalid status";
                    this.FailedImports.ImportRow(row);
                    goto label_40;
                }
                if (!App.DB.EngineerVisits.EngineerVisits_UpdateStatus(engineerVisit.EngineerVisitID, 7, outcomeEnumID))
                {
                  row["Failure Reason"] = (object) "Failed to update status";
                  this.FailedImports.ImportRow(row);
                }
              }
            }
          }
          else
          {
            row["Failure Reason"] = (object) "Cannot find any visits";
            this.FailedImports.ImportRow(row);
          }
        }
label_40:
        this.MoveProgressOn(false);
        checked { ++index; }
      }
      this.MoveProgressOn(true);
      int num2 = (int) App.ShowMessage("Data has been imported", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      this.lblMessages.Visible = false;
      if (this.FailedImports.Rows.Count <= 0)
        return;
      this.dgFailedImports.DataSource = (object) this.FailedImports;
    }

    private void ImportJobs(DataSet data, int jobImportTypeID)
    {
      data.Tables[0].Columns.Add("Failure Reason");
      this.FailedImports = data.Tables[0].Clone();
      this.pbStatus.Maximum = data.Tables[0].Rows.Count;
      int num1 = checked (data.Tables[0].Rows.Count - 1);
      int index = 0;
      while (index <= num1)
      {
        DataRow row = data.Tables[0].Rows[index];
        string empty = string.Empty;
        if (row["UPRN"] == DBNull.Value)
        {
          row["Failure Reason"] = (object) "No uprn";
          this.FailedImports.ImportRow(row);
        }
        else
        {
          string str = Conversions.ToString(row["UPRN"]);
          FSM.Entity.Sites.Site oSite = (FSM.Entity.Sites.Site) null;
          try
          {
            foreach (FSM.Entity.Customers.Customer customer in this.Customers)
            {
              if (oSite == null)
                oSite = App.DB.Sites.Get((object) str, SiteSQL.GetBy.Uprn, (object) customer.CustomerID);
            }
          }
          finally
          {
            List<FSM.Entity.Customers.Customer>.Enumerator enumerator;
            enumerator.Dispose();
          }
          if (oSite == null)
          {
            row["Failure Reason"] = (object) "Cannot find site";
            this.FailedImports.ImportRow(row);
            this.MoveProgressOn(false);
          }
          else
          {
            if (App.DB.JobImports.JobImport_Exist(oSite.SiteID, jobImportTypeID))
            {
              row["Failure Reason"] = (object) "Site and job exists in system";
              this.FailedImports.ImportRow(row);
              this.MoveProgressOn(false);
            }
            FSM.Entity.JobImport.JobImport oJobImport = new FSM.Entity.JobImport.JobImport();
            FSM.Entity.JobImport.JobImport jobImport1 = oJobImport;
            jobImport1.SetSiteID = (object) oSite.SiteID;
            jobImport1.SetUPRN = (object) oSite.PolicyNumber;
            jobImport1.SetJobImportTypeID = (object) jobImportTypeID;
            jobImport1.DateAdded = DateAndTime.Now;
            FSM.Entity.JobImport.JobImport jobImport2 = App.DB.JobImports.JobImport_Insert(oJobImport);
            if (!jobImport2.Exists)
            {
              row["Failure Reason"] = (object) "Database failure";
              this.FailedImports.ImportRow(row);
            }
            if (this.chkCreateJob.Checked && Helper.MakeIntegerValid((object) this.Engineer?.EngineerID) > 0)
            {
              Job job = this.CreateJob(oSite, jobImportTypeID);
              if (Helper.MakeIntegerValid((object) job?.JobID) > 0)
                App.DB.ExecuteWithOutReturn("UPDATE tblJobImport SET JobID = " + Conversions.ToString(job.JobID) + ", JobNumber = '" + job.JobNumber + "', Status = " + Conversions.ToString(0) + ", BookedVisit = '" + Microsoft.VisualBasic.Strings.Format((object) this.dtpVisitDate.Value, "yyyy-MM-dd") + "', Letter1 = '" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "yyyy-MM-dd") + "' WHERE JobImportID = " + Conversions.ToString(jobImport2.JobImportID) ?? "", true);
            }
          }
        }
        this.MoveProgressOn(false);
        checked { ++index; }
      }
      this.MoveProgressOn(true);
      int num2 = (int) App.ShowMessage("Data has been imported", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      this.lblMessages.Visible = false;
      if (this.FailedImports.Rows.Count <= 0)
        return;
      this.dgFailedImports.DataSource = (object) this.FailedImports;
      this.btnExportFailed.Visible = true;
    }

    public Job CreateJob(FSM.Entity.Sites.Site oSite, int jobImportTypeId)
    {
      JobImportType jobImportType = App.DB.JobImports.JobImportType_Get(jobImportTypeId);
      if (jobImportType == null)
        return (Job) null;
      DataTable table = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_Get_ByEngineerQual(jobImportType.EngineerQualID).Table;
      int num1 = 0;
      JobNumber jobNumber = new JobNumber();
      JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout);
      Job oJob = new Job()
      {
        SetPropertyID = (object) oSite.SiteID,
        SetJobDefinitionEnumID = (object) 3,
        SetJobTypeID = (object) jobImportType.JobTypeID,
        SetStatusEnumID = (object) 1,
        SetCreatedByUserID = (object) App.loggedInUser.UserID,
        SetFOC = (object) true,
        SetJobCreationType = (object) 2,
        SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber)),
        SetPONumber = (object) "",
        SetQuoteID = (object) 0,
        SetContractID = (object) 0
      };
      JobOfWork jobOfWork = new JobOfWork();
      Array array = (Array) App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority, false).Table.Select("Name = 'Dayworks'");
      int num2;
      if (array.Length == 0)
        num2 = App.DB.Picklists.Insert(new PickList()
        {
          SetName = (object) "Dayworks",
          SetEnumTypeID = (object) 45
        });
      else
        num2 = Conversions.ToInteger(((DataRow) NewLateBinding.LateIndexGet((object) array, new object[1]
        {
          (object) 0
        }, (string[]) null))["ManagerID"]);
      jobOfWork.SetPONumber = (object) "";
      jobOfWork.SetPriority = (object) num2;
      if ((uint) jobOfWork.Priority > 0U)
        jobOfWork.PriorityDateSet = DateAndTime.Now;
      jobOfWork.IgnoreExceptionsOnSetMethods = true;
      IEnumerator enumerator;
      try
      {
        enumerator = table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          DataTable dataTable = App.DB.CustomerScheduleOfRate.Exists(Conversions.ToInteger(current["ScheduleOfRatesCategoryID"]), Conversions.ToString(current["Description"]), Conversions.ToString(current["Code"]), oSite.CustomerID);
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
              SetCustomerID = (object) oSite.CustomerID
            };
            CustomerScheduleOfRateID = App.DB.CustomerScheduleOfRate.Insert(oCustomerScheduleOfRate).CustomerScheduleOfRateID;
            App.DB.CustomerScheduleOfRate.Delete(CustomerScheduleOfRateID);
          }
          num1 = Conversions.ToInteger(current["TimeInMins"]);
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
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      EngineerVisit engineerVisit = new EngineerVisit()
      {
        IgnoreExceptionsOnSetMethods = true,
        SetEngineerID = (object) 0
      };
      engineerVisit.SetEngineerID = (object) this.Engineer.EngineerID;
      engineerVisit.SetNotesToEngineer = (object) jobImportType.Name;
      engineerVisit.StartDateTime = this.dtpVisitDate.Value;
      engineerVisit.EndDateTime = this.dtpVisitDate.Value.AddHours(1.0);
      engineerVisit.SetStatusEnumID = (object) 5;
      DateTime dateTime;
      engineerVisit.DueDate = dateTime;
      engineerVisit.SetAMPM = (object) "AM";
      engineerVisit.SetVisitNumber = (object) 1;
      jobOfWork.EngineerVisits.Add((object) engineerVisit);
      oJob.JobOfWorks.Add((object) jobOfWork);
      return App.DB.Job.Insert(oJob);
    }

    private void Export()
    {
      ExportHelper.Export(this.FailedImports, "Job Imports", Enums.ExportType.XLS);
      this.FailedImports.Clear();
      this.btnExportFailed.Visible = false;
    }

    public void MoveProgressOn(bool toMaximum = false)
    {
      try
      {
        if (toMaximum)
        {
          this.pbStatus.Value = this.pbStatus.Maximum;
          this.lblProgress.Text = "100%";
        }
        else
        {
          ProgressBar pbStatus;
          int num = checked ((pbStatus = this.pbStatus).Value + 1);
          pbStatus.Value = num;
          this.lblProgress.Text = Conversions.ToString(Math.Floor((double) this.pbStatus.Value / (double) this.pbStatus.Maximum * 100.0)) + "%";
        }
        System.Windows.Forms.Application.DoEvents();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void KillInstances(Microsoft.Office.Interop.Excel.Application app)
    {
      int num1;
      int num2;
      try
      {
label_2:
        ProjectData.ClearProjectError();
        num1 = -2;
label_3:
        int num3 = 2;
        // ISSUE: reference to a compiler-generated method
        app.Quit();
label_4:
        num3 = 3;
        Marshal.ReleaseComObject((object) app);
label_5:
        num3 = 4;
        app = (Microsoft.Office.Interop.Excel.Application) null;
label_6:
        num3 = 5;
        GC.Collect();
label_7:
        num3 = 6;
        Process[] processesByName = Process.GetProcessesByName("EXCEL");
label_8:
        num3 = 7;
        Process[] processArray = processesByName;
        int index = 0;
        goto label_18;
label_10:
        num3 = 8;
        Process process;
        if (!process.Responding)
          goto label_15;
label_11:
        num3 = 9;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(process.MainWindowTitle, "", false) != 0)
          goto label_14;
label_12:
        num3 = 10;
        process.Kill();
label_13:
label_14:
        goto label_17;
label_15:
        num3 = 13;
        process.Kill();
label_16:
label_17:
        num3 = 15;
        checked { ++index; }
label_18:
        if (index < processArray.Length)
        {
          process = processArray[index];
          goto label_10;
        }
label_19:
        ProjectData.ClearProjectError();
        num2 = 0;
        goto label_26;
label_21:
        num2 = num3;
        switch (num1 > -2 ? num1 : 1)
        {
          case 1:
            int num4 = num2 + 1;
            num2 = 0;
            switch (num4)
            {
              case 1:
                goto label_2;
              case 2:
                goto label_3;
              case 3:
                goto label_4;
              case 4:
                goto label_5;
              case 5:
                goto label_6;
              case 6:
                goto label_7;
              case 7:
                goto label_8;
              case 8:
                goto label_10;
              case 9:
                goto label_11;
              case 10:
                goto label_12;
              case 11:
                goto label_13;
              case 12:
              case 15:
                goto label_17;
              case 13:
                goto label_15;
              case 14:
                goto label_16;
              case 16:
                goto label_19;
              case 17:
                goto label_26;
            }
            break;
        }
      }
      catch (Exception ex) when (ex is Exception & (uint) num1 > 0U & num2 == 0)
      {
        ProjectData.SetProjectError(ex);
        goto label_21;
      }
      throw ProjectData.CreateProjectError(-2146828237);
label_26:
      if (num2 == 0)
        return;
      ProjectData.ClearProjectError();
    }

    private void radBtnJob_CheckedChanged(object sender, EventArgs e)
    {
      this.lblJobType.Visible = this.radBtnJob.Checked;
      this.cboJobType.Visible = this.radBtnJob.Checked;
      this.txtCustomer.Visible = this.radBtnJob.Checked;
      this.btnFindCustomer.Visible = this.radBtnJob.Checked;
      this.lblCustomer.Visible = this.radBtnJob.Checked;
      this.lblEngineer.Visible = this.radBtnJob.Checked;
      this.lblVisitDate.Visible = this.radBtnJob.Checked;
      this.dtpVisitDate.Visible = this.radBtnJob.Checked;
      this.txtEngineer.Visible = this.radBtnJob.Checked;
      this.btnFindEngineer.Visible = this.radBtnJob.Checked;
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      FRMFindCustomers frmFindCustomers = new FRMFindCustomers();
      int num = (int) frmFindCustomers.ShowDialog();
      this.Customers = new List<FSM.Entity.Customers.Customer>();
      EnumerableRowCollection<DataRow> source1 = frmFindCustomers.CustomerDataView.Table.AsEnumerable();
      Func<DataRow, bool> predicate;
      // ISSUE: reference to a compiler-generated field
      if (FRMJobImport._Closure\u0024__.\u0024I136\u002D0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        predicate = FRMJobImport._Closure\u0024__.\u0024I136\u002D0;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FRMJobImport._Closure\u0024__.\u0024I136\u002D0 = predicate = (Func<DataRow, bool>) (row => row.Field<bool>("Include"));
      }
      EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
      Func<DataRow, DataRow> selector1;
      // ISSUE: reference to a compiler-generated field
      if (FRMJobImport._Closure\u0024__.\u0024I136\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector1 = FRMJobImport._Closure\u0024__.\u0024I136\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FRMJobImport._Closure\u0024__.\u0024I136\u002D1 = selector1 = (Func<DataRow, DataRow>) (row => row);
      }
      DataRow[] array = source2.Select<DataRow, DataRow>(selector1).ToArray<DataRow>();
      Func<DataRow, int> selector2;
      // ISSUE: reference to a compiler-generated field
      if (FRMJobImport._Closure\u0024__.\u0024I136\u002D2 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector2 = FRMJobImport._Closure\u0024__.\u0024I136\u002D2;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FRMJobImport._Closure\u0024__.\u0024I136\u002D2 = selector2 = (Func<DataRow, int>) (dr => Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["CustomerID"])));
      }
      List<int> list = ((IEnumerable<DataRow>) array).Select<DataRow, int>(selector2).ToList<int>();
      try
      {
        foreach (int CustomerID in list)
          this.Customers.Add(App.DB.Customer.Customer_Get(CustomerID));
      }
      finally
      {
        List<int>.Enumerator enumerator;
        enumerator.Dispose();
      }
      this.Customers = this.Customers;
    }

    private void chkCreateJob_Click(object sender, EventArgs e)
    {
      this.chkCreateJob.Checked = !this.chkCreateJob.Checked;
      this.dtpVisitDate.Enabled = this.chkCreateJob.Checked;
      this.btnFindEngineer.Enabled = this.chkCreateJob.Checked;
    }

    private void btnFindEngineer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Engineer = App.DB.Engineer.Engineer_Get(integer);
    }
  }
}
