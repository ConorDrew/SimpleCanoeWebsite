// Decompiled with JetBrains decompiler
// Type: FSM.FRMEngineerTimesheetReport
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

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
  public class FRMEngineerTimesheetReport : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvTimesheets;
    private DataView _dvEngineer;

    public FRMEngineerTimesheetReport()
    {
      this.Load += new EventHandler(this.FRMEngineerTimesheetReport_Load);
      this.InitializeComponent();
      if (true == App.IsGasway)
      {
        ComboBox cboDept = this.cboDept;
        Combo.SetUpCombo(ref cboDept, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
        this.cboDept = cboDept;
      }
      else
      {
        ComboBox cboDept = this.cboDept;
        Combo.SetUpCombo(ref cboDept, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
        this.cboDept = cboDept;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRunReport
    {
      get
      {
        return this._btnRunReport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRunReport_Click);
        Button btnRunReport1 = this._btnRunReport;
        if (btnRunReport1 != null)
          btnRunReport1.Click -= eventHandler;
        this._btnRunReport = value;
        Button btnRunReport2 = this._btnRunReport;
        if (btnRunReport2 == null)
          return;
        btnRunReport2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgEngineers
    {
      get
      {
        return this._dgEngineers;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgEngineers_Clicks);
        EventHandler eventHandler2 = new EventHandler(this.dgEngineers_Clicks);
        DataGrid dgEngineers1 = this._dgEngineers;
        if (dgEngineers1 != null)
        {
          dgEngineers1.Click -= eventHandler1;
          dgEngineers1.DoubleClick -= eventHandler2;
        }
        this._dgEngineers = value;
        DataGrid dgEngineers2 = this._dgEngineers;
        if (dgEngineers2 == null)
          return;
        dgEngineers2.Click += eventHandler1;
        dgEngineers2.DoubleClick += eventHandler2;
      }
    }

    internal virtual Button btnClearAll
    {
      get
      {
        return this._btnClearAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClearAll_Click);
        Button btnClearAll1 = this._btnClearAll;
        if (btnClearAll1 != null)
          btnClearAll1.Click -= eventHandler;
        this._btnClearAll = value;
        Button btnClearAll2 = this._btnClearAll;
        if (btnClearAll2 == null)
          return;
        btnClearAll2.Click += eventHandler;
      }
    }

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

    internal virtual Button btnSummary
    {
      get
      {
        return this._btnSummary;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSummary_Click);
        Button btnSummary1 = this._btnSummary;
        if (btnSummary1 != null)
          btnSummary1.Click -= eventHandler;
        this._btnSummary = value;
        Button btnSummary2 = this._btnSummary;
        if (btnSummary2 == null)
          return;
        btnSummary2.Click += eventHandler;
      }
    }

    internal virtual Label lblDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDept
    {
      get
      {
        return this._cboDept;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboDept_Changed);
        ComboBox cboDept1 = this._cboDept;
        if (cboDept1 != null)
          cboDept1.SelectedIndexChanged -= eventHandler;
        this._cboDept = value;
        ComboBox cboDept2 = this._cboDept;
        if (cboDept2 == null)
          return;
        cboDept2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual DataGrid dgTimesheets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobs = new GroupBox();
      this.dgTimesheets = new DataGrid();
      this.btnExport = new Button();
      this.grpFilter = new GroupBox();
      this.cboDept = new ComboBox();
      this.lblDept = new Label();
      this.btnClearAll = new Button();
      this.btnSelectAll = new Button();
      this.dgEngineers = new DataGrid();
      this.btnRunReport = new Button();
      this.Label4 = new Label();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.txtJobNumber = new TextBox();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.Label6 = new Label();
      this.btnReset = new Button();
      this.btnSummary = new Button();
      this.grpJobs.SuspendLayout();
      this.dgTimesheets.BeginInit();
      this.grpFilter.SuspendLayout();
      this.dgEngineers.BeginInit();
      this.SuspendLayout();
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.dgTimesheets);
      this.grpJobs.Location = new System.Drawing.Point(8, 239);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(844, 409);
      this.grpJobs.TabIndex = 2;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Double Click To View / Edit";
      this.dgTimesheets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgTimesheets.DataMember = "";
      this.dgTimesheets.HeaderForeColor = SystemColors.ControlText;
      this.dgTimesheets.Location = new System.Drawing.Point(8, 19);
      this.dgTimesheets.Name = "dgTimesheets";
      this.dgTimesheets.Size = new Size(828, 382);
      this.dgTimesheets.TabIndex = 14;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 656);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 15;
      this.btnExport.Text = "Export";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.cboDept);
      this.grpFilter.Controls.Add((Control) this.lblDept);
      this.grpFilter.Controls.Add((Control) this.btnClearAll);
      this.grpFilter.Controls.Add((Control) this.btnSelectAll);
      this.grpFilter.Controls.Add((Control) this.dgEngineers);
      this.grpFilter.Controls.Add((Control) this.btnRunReport);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.txtJobNumber);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(844, 201);
      this.grpFilter.TabIndex = 1;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.cboDept.Location = new System.Drawing.Point(367, 35);
      this.cboDept.Name = "cboDept";
      this.cboDept.Size = new Size(126, 21);
      this.cboDept.TabIndex = 30;
      this.lblDept.BackColor = Color.White;
      this.lblDept.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblDept.Location = new System.Drawing.Point(364, 16);
      this.lblDept.Name = "lblDept";
      this.lblDept.Size = new Size(103, 16);
      this.lblDept.TabIndex = 29;
      this.lblDept.Text = "Department";
      this.btnClearAll.Font = new Font("Verdana", 8f);
      this.btnClearAll.Location = new System.Drawing.Point(148, 11);
      this.btnClearAll.Name = "btnClearAll";
      this.btnClearAll.Size = new Size(64, 23);
      this.btnClearAll.TabIndex = 28;
      this.btnClearAll.Text = "Clear All";
      this.btnClearAll.UseVisualStyleBackColor = true;
      this.btnSelectAll.Font = new Font("Verdana", 8f);
      this.btnSelectAll.Location = new System.Drawing.Point(78, 11);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(64, 23);
      this.btnSelectAll.TabIndex = 27;
      this.btnSelectAll.Text = "Select All";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.dgEngineers.AllowNavigation = false;
      this.dgEngineers.AlternatingBackColor = Color.GhostWhite;
      this.dgEngineers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.dgEngineers.BackgroundColor = Color.White;
      this.dgEngineers.BorderStyle = BorderStyle.FixedSingle;
      this.dgEngineers.CaptionBackColor = Color.RoyalBlue;
      this.dgEngineers.CaptionForeColor = Color.White;
      this.dgEngineers.CaptionText = "Engineers";
      this.dgEngineers.CaptionVisible = false;
      this.dgEngineers.DataMember = "";
      this.dgEngineers.Font = new Font("Verdana", 8f);
      this.dgEngineers.ForeColor = Color.MidnightBlue;
      this.dgEngineers.GridLineColor = Color.RoyalBlue;
      this.dgEngineers.HeaderBackColor = Color.MidnightBlue;
      this.dgEngineers.HeaderFont = new Font("Tahoma", 8f, FontStyle.Bold);
      this.dgEngineers.HeaderForeColor = Color.Lavender;
      this.dgEngineers.LinkColor = Color.Teal;
      this.dgEngineers.Location = new System.Drawing.Point(11, 35);
      this.dgEngineers.Name = "dgEngineers";
      this.dgEngineers.ParentRowsBackColor = Color.Lavender;
      this.dgEngineers.ParentRowsForeColor = Color.MidnightBlue;
      this.dgEngineers.ParentRowsVisible = false;
      this.dgEngineers.RowHeadersVisible = false;
      this.dgEngineers.SelectionBackColor = Color.Teal;
      this.dgEngineers.SelectionForeColor = Color.PaleGreen;
      this.dgEngineers.Size = new Size(350, 141);
      this.dgEngineers.TabIndex = 26;
      this.btnRunReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRunReport.Location = new System.Drawing.Point(747, 172);
      this.btnRunReport.Name = "btnRunReport";
      this.btnRunReport.Size = new Size(91, 23);
      this.btnRunReport.TabIndex = 25;
      this.btnRunReport.Text = "Run Report";
      this.Label4.BackColor = Color.White;
      this.Label4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label4.Location = new System.Drawing.Point(8, 16);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 16);
      this.Label4.TabIndex = 24;
      this.Label4.Text = "Engineers";
      this.dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpTo.Location = new System.Drawing.Point(686, 47);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(144, 21);
      this.dtpTo.TabIndex = 13;
      this.dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFrom.Location = new System.Drawing.Point(686, 20);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(144, 21);
      this.dtpFrom.TabIndex = 12;
      this.txtJobNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtJobNumber.Location = new System.Drawing.Point(686, 74);
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.Size = new Size(144, 21);
      this.txtJobNumber.TabIndex = 9;
      this.Label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label9.Location = new System.Drawing.Point(654, 52);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(24, 16);
      this.Label9.TabIndex = 10;
      this.Label9.Text = "To";
      this.Label9.TextAlign = ContentAlignment.TopRight;
      this.Label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label8.Location = new System.Drawing.Point(592, 25);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(88, 16);
      this.Label8.TabIndex = 9;
      this.Label8.Text = "Date From";
      this.Label8.TextAlign = ContentAlignment.TopRight;
      this.Label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label6.Location = new System.Drawing.Point(592, 79);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 16);
      this.Label6.TabIndex = 6;
      this.Label6.Text = "Job Number";
      this.Label6.TextAlign = ContentAlignment.TopRight;
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(72, 656);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 16;
      this.btnReset.Text = "Reset";
      this.btnSummary.AccessibleDescription = "Export Job List To Excel";
      this.btnSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSummary.Location = new System.Drawing.Point(755, 656);
      this.btnSummary.Name = "btnSummary";
      this.btnSummary.Size = new Size(89, 23);
      this.btnSummary.TabIndex = 17;
      this.btnSummary.Text = "Summary";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(860, 686);
      this.Controls.Add((Control) this.btnSummary);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpJobs);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(808, 528);
      this.Name = nameof (FRMEngineerTimesheetReport);
      this.Text = "Engineer Timesheet Report";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.btnSummary, 0);
      this.grpJobs.ResumeLayout(false);
      this.dgTimesheets.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.dgEngineers.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupComboBoxes();
      this.SetupTimesheetsDataGrid();
      this.setUpDataGrid();
      this.PopulateDatagrid();
      this.EngineersDataView = App.DB.Engineer.Engineer_GetAll();
      this.EngineersDataView.Table.Columns.Add(new DataColumn("Include", typeof (bool))
      {
        DefaultValue = (object) true
      });
      this.EngineersDataView.Table.AcceptChanges();
      IEnumerator enumerator;
      try
      {
        enumerator = this.EngineersDataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["Include"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
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

    private DataView TimesheetsDataview
    {
      get
      {
        return this._dvTimesheets;
      }
      set
      {
        this._dvTimesheets = value;
        this._dvTimesheets.AllowNew = false;
        this._dvTimesheets.AllowEdit = false;
        this._dvTimesheets.AllowDelete = false;
        this._dvTimesheets.Table.TableName = Enums.TableNames.tblEngineerVisitTimesheet.ToString();
        this.dgTimesheets.DataSource = (object) this.TimesheetsDataview;
      }
    }

    private DataRow SelectedJobDataRow
    {
      get
      {
        return this.dgTimesheets.CurrentRowIndex != -1 ? this.TimesheetsDataview[this.dgTimesheets.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView EngineersDataView
    {
      get
      {
        return this._dvEngineer;
      }
      set
      {
        this._dvEngineer = value;
        if (this.EngineersDataView != null && this.EngineersDataView.Table != null)
        {
          this._dvEngineer.Table.TableName = "tblEngineers";
          this._dvEngineer.AllowNew = false;
        }
        this.dgEngineers.DataSource = (object) this.EngineersDataView;
      }
    }

    private void SetupComboBoxes()
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("Value");
      dataTable.Columns.Add("Description");
      DataRow row1 = dataTable.NewRow();
      row1["Value"] = (object) 0;
      row1["Description"] = (object) "ALL";
      dataTable.Rows.Add(row1);
      DataRow row2 = dataTable.NewRow();
      row2["Value"] = (object) 1;
      row2["Description"] = (object) "1";
      dataTable.Rows.Add(row2);
      DataRow row3 = dataTable.NewRow();
      row3["Value"] = (object) 2;
      row3["Description"] = (object) "2";
      dataTable.Rows.Add(row3);
      DataRow row4 = dataTable.NewRow();
      row4["Value"] = (object) 4;
      row4["Description"] = (object) "4";
      dataTable.Rows.Add(row4);
      DataRow row5 = dataTable.NewRow();
      row5["Value"] = (object) 5;
      row5["Description"] = (object) "5";
      dataTable.Rows.Add(row5);
    }

    private void setUpDataGrid()
    {
      this.SuspendLayout();
      Helper.SetUpDataGrid(this.dgEngineers, false);
      DataGridTableStyle tableStyle = this.dgEngineers.TableStyles[0];
      tableStyle.ReadOnly = false;
      this.dgEngineers.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "Include";
      dataGridBoolColumn.MappingName = "Include";
      dataGridBoolColumn.ReadOnly = false;
      dataGridBoolColumn.Width = 50;
      dataGridBoolColumn.AllowNull = false;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Engineer ID";
      dataGridLabelColumn1.MappingName = "EngineerID";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 75;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Engineer Name";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 200;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.MappingName = "tblEngineers";
      this.dgEngineers.TableStyles.Add(tableStyle);
      this.ResumeLayout(true);
    }

    private void SetupTimesheetsDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgTimesheets.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Source";
      dataGridLabelColumn1.MappingName = "Source";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Engineer";
      dataGridLabelColumn2.MappingName = "Engineer";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Job Number";
      dataGridLabelColumn3.MappingName = "JobNumber";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Property";
      dataGridLabelColumn4.MappingName = "Site";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Visit Details";
      dataGridLabelColumn5.MappingName = "VisitDetails";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "dd/MM/yyyy";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Date";
      dataGridLabelColumn6.MappingName = "StartDateTime";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "HH:mm";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Start Time";
      dataGridLabelColumn7.MappingName = "StartTime";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "HH:mm";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "End Time";
      dataGridLabelColumn8.MappingName = "EndDateTime";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 100;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Timesheet Type";
      dataGridLabelColumn9.MappingName = "TimesheetType";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisitTimesheet.ToString();
      this.dgTimesheets.TableStyles.Add(tableStyle);
    }

    private void cboDept_Changed(object sender, EventArgs e)
    {
      string Dept = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDept));
      if (Helper.IsValidInteger((object) Dept) && Helper.MakeIntegerValid((object) Dept) <= -1)
        return;
      this.EngineersDataView = App.DB.Engineer.Engineer_GetAllbyDept(Dept);
      this.EngineersDataView.Table.Columns.Add(new DataColumn("Include", typeof (bool))
      {
        DefaultValue = (object) true
      });
      this.EngineersDataView.Table.AcceptChanges();
      IEnumerator enumerator;
      try
      {
        enumerator = this.EngineersDataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["Include"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void FRMEngineerTimesheetReport_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnRunReport_Click(object sender, EventArgs e)
    {
      this.ShowData();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void btnSummary_Click(object sender, EventArgs e)
    {
      this.ExportSummary((string) null);
    }

    private void dgEngineers_Clicks(object sender, EventArgs e)
    {
      try
      {
        int index = 0;
        DataGrid.HitTestInfo hitTestInfo = this.dgEngineers.HitTest(this.dgEngineers.PointToClient(Control.MousePosition));
        BindingManagerBase bindingManagerBase = this.BindingContext[RuntimeHelpers.GetObjectValue(this.dgEngineers.DataSource), this.dgEngineers.DataMember];
        if (hitTestInfo.Row >= bindingManagerBase.Count || hitTestInfo.Type != DataGrid.HitTestType.Cell || hitTestInfo.Column != index)
          return;
        bool flag = !Conversions.ToBoolean(this.dgEngineers[hitTestInfo.Row, index]);
        this.dgEngineers[hitTestInfo.Row, index] = (object) flag;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show(ex.Message);
        ProjectData.ClearProjectError();
      }
      finally
      {
      }
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      if (this.EngineersDataView == null)
        return;
      IEnumerator enumerator;
      if (this.EngineersDataView.Table != null)
      {
        try
        {
          enumerator = this.EngineersDataView.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
            ((DataRow) enumerator.Current)["Include"] = (object) true;
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
    }

    private void btnClearAll_Click(object sender, EventArgs e)
    {
      if (this.EngineersDataView == null)
        return;
      IEnumerator enumerator;
      if (this.EngineersDataView.Table != null)
      {
        try
        {
          enumerator = this.EngineersDataView.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
            ((DataRow) enumerator.Current)["Include"] = (object) false;
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
    }

    public void PopulateDatagrid()
    {
      try
      {
        this.ResetFilters();
        if (this.get_GetParameter(0) == null)
          return;
        this.TimesheetsDataview = (DataView) this.get_GetParameter(0);
        this.grpFilter.Enabled = false;
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
      IEnumerator enumerator;
      if (this.EngineersDataView != null)
      {
        if (this.EngineersDataView.Table != null)
        {
          try
          {
            enumerator = this.EngineersDataView.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
              ((DataRow) enumerator.Current)["Include"] = (object) true;
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
      }
      this.txtJobNumber.Text = "";
      this.dtpFrom.Value = DateAndTime.Today.AddDays(-7.0);
      this.dtpTo.Value = DateAndTime.Today;
      this.grpFilter.Enabled = true;
      this.ShowData();
    }

    private void ShowData()
    {
      this.Cursor = Cursors.WaitCursor;
      string str1 = " WHERE TS.StartDateTime >= '" + Strings.Format((object) this.dtpFrom.Value, "dd/MMM/yyyy 00:00:00") + "' AND TS.EndDateTime <= '" + Strings.Format((object) this.dtpTo.Value, "dd/MMM/yyyy 23:59:59") + "'";
      string str2 = "0,";
      IEnumerator enumerator;
      if (this.EngineersDataView != null)
      {
        if (this.EngineersDataView.Table != null)
        {
          try
          {
            enumerator = this.EngineersDataView.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (Conversions.ToBoolean(current["Include"]))
                str2 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str2, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["EngineerID"], (object) ",")));
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
      }
      string str3 = str2.Substring(0, checked (str2.Length - 1));
      string Where = str1 + " AND tblEngineer.EngineerID IN (" + str3 + ")";
      if ((uint) this.txtJobNumber.Text.Trim().Length > 0U)
        Where = Where + " AND tblJob.JobNumber LIKE '" + this.txtJobNumber.Text.Trim() + "%'";
      this.TimesheetsDataview = App.DB.EngineerVisitsTimeSheet.GetAll(Where);
      this.Cursor = Cursors.Default;
    }

    public void Export()
    {
      if (this.TimesheetsDataview.Count <= 0)
      {
        int num1 = (int) App.ShowMessage("No engineers are being displayed, please change / run filter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        DataTable datatableIn = new DataTable();
        datatableIn.Columns.Add("JobNumber");
        datatableIn.Columns.Add("Site");
        datatableIn.Columns.Add("Visit Details");
        datatableIn.Columns.Add("Notes From Engineer");
        datatableIn.Columns.Add("Start Time");
        datatableIn.Columns.Add("End Time");
        datatableIn.Columns.Add("Timesheet Type");
        datatableIn.Columns.Add("Time");
        DataTable dataTable1 = new DataTable();
        dataTable1.Columns.Add("Day", typeof (DateTime));
        DataRow[] dataRowArray1 = this.TimesheetsDataview.Table.Select("", "StartDateTime");
        int index1 = 0;
        while (index1 < dataRowArray1.Length)
        {
          DataRow dataRow = dataRowArray1[index1];
          if (dataTable1.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(dataRow["StartDateTime"]), "dd/MMM/yyyy") + "'").Length == 0)
          {
            DataRow row = dataTable1.NewRow();
            row["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(dataRow["StartDateTime"]), "dd/MMM/yyyy");
            dataTable1.Rows.Add(row);
          }
          checked { ++index1; }
        }
        if (dataTable1.Rows.Count > 5)
        {
          int count = dataTable1.Rows.Count;
          int num2 = 6;
          while (num2 <= count)
          {
            datatableIn.Columns.Add(Conversions.ToString(num2));
            checked { ++num2; }
          }
        }
        int num3 = 2;
        string Left = "";
        string str = "";
        DataTable dataTable2 = new DataTable();
        dataTable2.Columns.Add("Name");
        DataRow row1 = dataTable2.NewRow();
        row1["Name"] = (object) "TRAVELLING";
        dataTable2.Rows.Add(row1);
        DataRow row2 = dataTable2.NewRow();
        row2["Name"] = (object) "WORKING";
        dataTable2.Rows.Add(row2);
        DataRow row3 = dataTable2.NewRow();
        row3["Name"] = (object) "LUNCH";
        dataTable2.Rows.Add(row3);
        DataRow row4 = dataTable2.NewRow();
        row4["Name"] = (object) "NON-CHARGEABLE";
        dataTable2.Rows.Add(row4);
        DataTable dataTable3 = new DataTable();
        dataTable3.Columns.Add("Engineer");
        dataTable3.Columns.Add("Day");
        dataTable3.Columns.Add("Type");
        dataTable3.Columns.Add("Time");
        DataTable dataTable4 = new DataTable();
        dataTable4.Columns.Add("Engineer");
        dataTable4.Columns.Add("Day");
        dataTable4.Columns.Add("StartDay");
        dataTable4.Columns.Add("EndDay");
        DataTable dataTable5 = new DataTable();
        dataTable5.Columns.Add("Day");
        dataTable5.Columns.Add("Time");
        int num4 = checked (((DataView) this.dgTimesheets.DataSource).Count - 1);
        int row5 = 0;
        while (row5 <= num4)
        {
          this.dgTimesheets.CurrentRowIndex = row5;
          DataRow row6 = datatableIn.NewRow();
          DataRow[] dataRowArray2 = dataTable3.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Engineer='", this.SelectedJobDataRow["Engineer"]), (object) "' AND Day='"), (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy")), (object) "' AND Type='"), this.SelectedJobDataRow["TimeSheetType"]), (object) "'")));
          if (dataRowArray2.Length > 0)
          {
            DataRow dataRow;
            (dataRow = dataRowArray2[0])["Time"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow["Time"], (object) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["EndDateTime"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          }
          else
          {
            DataRow row7 = dataTable3.NewRow();
            row7["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Engineer"]);
            row7["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
            row7["Type"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["TimeSheetType"]);
            row7["Time"] = (object) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["EndDateTime"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            dataTable3.Rows.Add(row7);
          }
          DataRow row8 = dataTable3.NewRow();
          row8["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Engineer"]);
          row8["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
          row8["Type"] = (object) "Total Hours > 17:00";
          int num2 = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess((object) Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy") + " 17:00:00"), this.SelectedJobDataRow["StartDateTime"], false) ? checked ((int) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy") + " 17:00:00"), Conversions.ToDate(this.SelectedJobDataRow["EndDateTime"]), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) : checked ((int) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(this.SelectedJobDataRow["StartDateTime"]), Conversions.ToDate(this.SelectedJobDataRow["EndDateTime"]), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          row8["Time"] = num2 <= 0 ? (object) 0 : (object) num2;
          dataTable3.Rows.Add(row8);
          DataRow[] dataRowArray3 = dataTable4.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Engineer='", this.SelectedJobDataRow["Engineer"]), (object) "' AND Day='"), (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy")), (object) "'")));
          if (dataRowArray3.Length == 0)
          {
            DataRow row7 = dataTable4.NewRow();
            row7["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Engineer"]);
            row7["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
            row7["StartDay"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]);
            row7["EndDay"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["EndDateTime"]);
            dataTable4.Rows.Add(row7);
          }
          else
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(dataRowArray3[0]["StartDay"], this.SelectedJobDataRow["StartDateTime"], false))
              dataRowArray3[0]["StartDay"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]);
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(dataRowArray3[0]["EndDay"], this.SelectedJobDataRow["EndDateTime"], false))
              dataRowArray3[0]["EndDay"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["EndDateTime"]);
          }
          if (num3 == 2)
          {
            DataRow row7 = datatableIn.NewRow();
            row7["JobNumber"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Engineer"]);
            datatableIn.Rows.Add(row7);
            int num5 = checked (num3 + 1);
            DataRow row9 = datatableIn.NewRow();
            datatableIn.Rows.Add(row9);
            int num6 = checked (num5 + 1);
            DataRow row10 = datatableIn.NewRow();
            row10["JobNumber"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dddd");
            row10["Site"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
            datatableIn.Rows.Add(row10);
            num3 = checked (num6 + 1);
            Left = Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
            str = Conversions.ToString(this.SelectedJobDataRow["Engineer"]);
          }
          if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy"), false) > 0U)
          {
            DataRow row7 = datatableIn.NewRow();
            datatableIn.Rows.Add(row7);
            checked { ++num3; }
            Left = Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual((object) str, this.SelectedJobDataRow["Engineer"], false))
            {
              DataRow row9 = datatableIn.NewRow();
              row9["JobNumber"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dddd");
              row9["Site"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
              datatableIn.Rows.Add(row9);
              checked { ++num3; }
            }
          }
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual((object) str, this.SelectedJobDataRow["Engineer"], false))
          {
            DataRow row7 = datatableIn.NewRow();
            datatableIn.Rows.Add(row7);
            int num5 = checked (num3 + 1);
            DataRow row9 = datatableIn.NewRow();
            row9["JobNumber"] = (object) "SUMMARY";
            int index2 = 3;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = dataTable1.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current = (DataRow) enumerator1.Current;
                row9[index2] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM");
                checked { ++index2; }
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            datatableIn.Rows.Add(row9);
            int num6 = checked (num5 + 1);
            IEnumerator enumerator2;
            try
            {
              enumerator2 = dataTable2.Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current1 = (DataRow) enumerator2.Current;
                DataRow row10 = datatableIn.NewRow();
                row10["JobNumber"] = (object) current1["Name"].ToString().ToUpper();
                int index3 = 3;
                IEnumerator enumerator3;
                try
                {
                  enumerator3 = dataTable1.Rows.GetEnumerator();
                  while (enumerator3.MoveNext())
                  {
                    DataRow current2 = (DataRow) enumerator3.Current;
                    DataRow[] dataRowArray4 = dataTable3.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current2["Day"]), "dd/MM/yyyy") + "' AND Engineer='" + str + "' AND Type='" + current1["Name"].ToString() + "'");
                    row10[index3] = dataRowArray4.Length <= 0 ? (object) this.formatTime(0) : (object) this.formatTime(Conversions.ToInteger(dataRowArray4[0]["Time"]));
                    checked { ++index3; }
                  }
                }
                finally
                {
                  if (enumerator3 is IDisposable)
                    (enumerator3 as IDisposable).Dispose();
                }
                datatableIn.Rows.Add(row10);
                checked { ++num6; }
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            DataRow row11 = datatableIn.NewRow();
            row11["JobNumber"] = (object) "Unaccounted".ToUpper();
            int index4 = 3;
            IEnumerator enumerator4;
            try
            {
              enumerator4 = dataTable1.Rows.GetEnumerator();
              while (enumerator4.MoveNext())
              {
                DataRow current = (DataRow) enumerator4.Current;
                DataRow[] dataRowArray4 = dataTable4.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='" + str + "'");
                if (dataRowArray4.Length > 0)
                {
                  DataRow[] dataRowArray5 = dataTable3.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='" + str + "'");
                  if (dataRowArray5.Length > 0)
                  {
                    int num7 = 0;
                    DataRow[] dataRowArray6 = dataRowArray5;
                    int index3 = 0;
                    while (index3 < dataRowArray6.Length)
                    {
                      DataRow dataRow = dataRowArray6[index3];
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dataRow["Type"], (object) "Total Hours > 17:00", false))
                        num7 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num7, dataRow["Time"]));
                      checked { ++index3; }
                    }
                    row11[index4] = (object) this.formatTime(checked ((int) (DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) - (long) num7)));
                    DataRow row10 = dataTable5.NewRow();
                    row10["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy");
                    row10["Time"] = (object) checked (DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) - (long) num7);
                    dataTable5.Rows.Add(row10);
                  }
                  else
                    row11[index4] = (object) this.formatTime(checked ((int) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)));
                }
                else
                  row11[index4] = (object) this.formatTime(0);
                checked { ++index4; }
              }
            }
            finally
            {
              if (enumerator4 is IDisposable)
                (enumerator4 as IDisposable).Dispose();
            }
            datatableIn.Rows.Add(row11);
            int num8 = checked (num6 + 1);
            DataRow row12 = datatableIn.NewRow();
            row12["JobNumber"] = (object) "Total Hours > 17:00".ToUpper();
            int index5 = 3;
            IEnumerator enumerator5;
            try
            {
              enumerator5 = dataTable1.Rows.GetEnumerator();
              while (enumerator5.MoveNext())
              {
                DataRow current = (DataRow) enumerator5.Current;
                DataRow[] dataRowArray4 = dataTable3.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='" + str + "' AND Type='Total Hours > 17:00'");
                if (dataRowArray4.Length > 0)
                {
                  int Minutes = 0;
                  int num7 = checked (dataRowArray4.Length - 1);
                  int index3 = 0;
                  while (index3 <= num7)
                  {
                    Minutes = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Minutes, dataRowArray4[index3]["Time"]));
                    checked { ++index3; }
                  }
                  DataRow dataRow;
                  int index6;
                  (dataRow = row12)[index6 = index5] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow[index6], (object) this.formatTime(Minutes));
                }
                else
                  row12[index5] = (object) this.formatTime(0);
                checked { ++index5; }
              }
            }
            finally
            {
              if (enumerator5 is IDisposable)
                (enumerator5 as IDisposable).Dispose();
            }
            datatableIn.Rows.Add(row12);
            int num9 = checked (num8 + 1);
            DataRow row13 = datatableIn.NewRow();
            datatableIn.Rows.Add(row13);
            int num10 = checked (num9 + 1);
            DataRow row14 = datatableIn.NewRow();
            datatableIn.Rows.Add(row14);
            int num11 = checked (num10 + 1);
            str = Conversions.ToString(this.SelectedJobDataRow["Engineer"]);
            DataRow row15 = datatableIn.NewRow();
            row15["JobNumber"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Engineer"]);
            datatableIn.Rows.Add(row15);
            int num12 = checked (num11 + 1);
            DataRow row16 = datatableIn.NewRow();
            datatableIn.Rows.Add(row16);
            int num13 = checked (num12 + 1);
            DataRow row17 = datatableIn.NewRow();
            row17["JobNumber"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dddd");
            row17["Site"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
            datatableIn.Rows.Add(row17);
            num3 = checked (num13 + 1);
          }
          row6["JobNumber"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["JobNumber"]);
          row6["Site"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Site"]);
          row6["Visit Details"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["VisitDetails"]);
          row6["Notes From Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["NotesFromEngineer"]);
          row6["Start Time"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "HH:mm");
          row6["End Time"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["EndDateTime"]), "HH:mm");
          row6["Timesheet Type"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["TimeSheetType"]);
          row6["Time"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Duration"]);
          datatableIn.Rows.Add(row6);
          this.dgTimesheets.UnSelect(row5);
          checked { ++num3; }
          checked { ++row5; }
        }
        DataRow row18 = datatableIn.NewRow();
        datatableIn.Rows.Add(row18);
        int num14 = checked (num3 + 1);
        DataRow row19 = datatableIn.NewRow();
        row19["JobNumber"] = (object) "SUMMARY";
        int index7 = 3;
        IEnumerator enumerator6;
        try
        {
          enumerator6 = dataTable1.Rows.GetEnumerator();
          while (enumerator6.MoveNext())
          {
            DataRow current = (DataRow) enumerator6.Current;
            row19[index7] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM");
            checked { ++index7; }
          }
        }
        finally
        {
          if (enumerator6 is IDisposable)
            (enumerator6 as IDisposable).Dispose();
        }
        datatableIn.Rows.Add(row19);
        int num15 = checked (num14 + 1);
        IEnumerator enumerator7;
        try
        {
          enumerator7 = dataTable2.Rows.GetEnumerator();
          while (enumerator7.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator7.Current;
            DataRow row6 = datatableIn.NewRow();
            row6["JobNumber"] = (object) current1["Name"].ToString().ToUpper();
            int index2 = 3;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = dataTable1.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current2 = (DataRow) enumerator1.Current;
                DataRow[] dataRowArray2 = dataTable3.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current2["Day"]), "dd/MM/yyyy") + "' AND Engineer='"), this.SelectedJobDataRow["Engineer"]), (object) "' AND Type='"), (object) current1["Name"].ToString()), (object) "'")));
                row6[index2] = dataRowArray2.Length <= 0 ? (object) this.formatTime(0) : (object) this.formatTime(Conversions.ToInteger(dataRowArray2[0]["Time"]));
                checked { ++index2; }
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            datatableIn.Rows.Add(row6);
            checked { ++num15; }
          }
        }
        finally
        {
          if (enumerator7 is IDisposable)
            (enumerator7 as IDisposable).Dispose();
        }
        DataRow row20 = datatableIn.NewRow();
        row20["JobNumber"] = (object) "Unaccounted".ToUpper();
        int index8 = 3;
        IEnumerator enumerator8;
        try
        {
          enumerator8 = dataTable1.Rows.GetEnumerator();
          while (enumerator8.MoveNext())
          {
            DataRow current = (DataRow) enumerator8.Current;
            DataRow[] dataRowArray2 = dataTable4.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='"), this.SelectedJobDataRow["Engineer"]), (object) "'")));
            if (dataRowArray2.Length > 0)
            {
              DataRow[] dataRowArray3 = dataTable3.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='"), this.SelectedJobDataRow["Engineer"]), (object) "'")));
              if (dataRowArray3.Length > 0)
              {
                int num2 = 0;
                DataRow[] dataRowArray4 = dataRowArray3;
                int index2 = 0;
                while (index2 < dataRowArray4.Length)
                {
                  DataRow dataRow = dataRowArray4[index2];
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dataRow["Type"], (object) "Total Hours > 17:00", false))
                    num2 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, dataRow["Time"]));
                  checked { ++index2; }
                }
                row20[index8] = (object) this.formatTime(checked ((int) (DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) - (long) num2)));
                DataRow row6 = dataTable5.NewRow();
                row6["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy");
                row6["Time"] = (object) checked (DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) - (long) num2);
                dataTable5.Rows.Add(row6);
              }
              else
                row20[index8] = (object) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            else
              row20[index8] = (object) this.formatTime(0);
            checked { ++index8; }
          }
        }
        finally
        {
          if (enumerator8 is IDisposable)
            (enumerator8 as IDisposable).Dispose();
        }
        datatableIn.Rows.Add(row20);
        int num16 = checked (num15 + 1);
        DataRow row21 = datatableIn.NewRow();
        row21["JobNumber"] = (object) "Total Hours > 17:00".ToUpper();
        int index9 = 3;
        IEnumerator enumerator9;
        try
        {
          enumerator9 = dataTable1.Rows.GetEnumerator();
          while (enumerator9.MoveNext())
          {
            DataRow current = (DataRow) enumerator9.Current;
            DataRow[] dataRowArray2 = dataTable3.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='"), this.SelectedJobDataRow["Engineer"]), (object) "' AND Type='Total Hours > 17:00'")));
            if (dataRowArray2.Length > 0)
            {
              int Minutes = 0;
              int num2 = checked (dataRowArray2.Length - 1);
              int index2 = 0;
              while (index2 <= num2)
              {
                Minutes = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Minutes, dataRowArray2[index2]["Time"]));
                checked { ++index2; }
              }
              DataRow dataRow;
              int index3;
              (dataRow = row21)[index3 = index9] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow[index3], (object) this.formatTime(Minutes));
            }
            else
              row21[index9] = (object) this.formatTime(0);
            checked { ++index9; }
          }
        }
        finally
        {
          if (enumerator9 is IDisposable)
            (enumerator9 as IDisposable).Dispose();
        }
        datatableIn.Rows.Add(row21);
        int num17 = checked (num16 + 1);
        DataRow row22 = datatableIn.NewRow();
        datatableIn.Rows.Add(row22);
        int num18 = checked (num17 + 1);
        DataRow row23 = datatableIn.NewRow();
        datatableIn.Rows.Add(row23);
        int num19 = checked (num18 + 1);
        DataRow row24 = datatableIn.NewRow();
        datatableIn.Rows.Add(row24);
        int num20 = checked (num19 + 1);
        DataRow row25 = datatableIn.NewRow();
        row25["JobNumber"] = (object) "MASTER SUMMARY";
        int index10 = 3;
        IEnumerator enumerator10;
        try
        {
          enumerator10 = dataTable1.Rows.GetEnumerator();
          while (enumerator10.MoveNext())
          {
            DataRow current = (DataRow) enumerator10.Current;
            row25[index10] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM");
            checked { ++index10; }
          }
        }
        finally
        {
          if (enumerator10 is IDisposable)
            (enumerator10 as IDisposable).Dispose();
        }
        datatableIn.Rows.Add(row25);
        int num21 = checked (num20 + 1);
        IEnumerator enumerator11;
        try
        {
          enumerator11 = dataTable2.Rows.GetEnumerator();
          while (enumerator11.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator11.Current;
            DataRow row6 = datatableIn.NewRow();
            row6["JobNumber"] = (object) current1["Name"].ToString().ToUpper();
            int index2 = 3;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = dataTable1.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current2 = (DataRow) enumerator1.Current;
                DataRow[] dataRowArray2 = dataTable3.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current2["Day"]), "dd/MM/yyyy") + "' AND Type='" + current1["Name"].ToString() + "'");
                if (dataRowArray2.Length > 0)
                {
                  int Minutes = 0;
                  int num2 = checked (dataRowArray2.Length - 1);
                  int index3 = 0;
                  while (index3 <= num2)
                  {
                    Minutes = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Minutes, dataRowArray2[index3]["Time"]));
                    checked { ++index3; }
                  }
                  row6[index2] = (object) this.formatTime(Minutes);
                }
                else
                  row6[index2] = (object) this.formatTime(0);
                checked { ++index2; }
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            datatableIn.Rows.Add(row6);
            checked { ++num21; }
          }
        }
        finally
        {
          if (enumerator11 is IDisposable)
            (enumerator11 as IDisposable).Dispose();
        }
        DataRow row26 = datatableIn.NewRow();
        row26["JobNumber"] = (object) "Unaccounted".ToUpper();
        int index11 = 3;
        IEnumerator enumerator12;
        try
        {
          enumerator12 = dataTable1.Rows.GetEnumerator();
          while (enumerator12.MoveNext())
          {
            DataRow current = (DataRow) enumerator12.Current;
            int Minutes = 0;
            DataRow[] dataRowArray2 = dataTable5.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "'");
            int num2 = checked (dataRowArray2.Length - 1);
            int index2 = 0;
            while (index2 <= num2)
            {
              Minutes = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Minutes, dataRowArray2[index2]["Time"]));
              checked { ++index2; }
            }
            row26[index11] = (object) this.formatTime(Minutes);
            checked { ++index11; }
          }
        }
        finally
        {
          if (enumerator12 is IDisposable)
            (enumerator12 as IDisposable).Dispose();
        }
        datatableIn.Rows.Add(row26);
        int num22 = checked (num21 + 1);
        DataRow row27 = datatableIn.NewRow();
        row27["JobNumber"] = (object) "Total Hours > 17:00".ToUpper();
        int index12 = 3;
        IEnumerator enumerator13;
        try
        {
          enumerator13 = dataTable1.Rows.GetEnumerator();
          while (enumerator13.MoveNext())
          {
            DataRow current = (DataRow) enumerator13.Current;
            DataRow[] dataRowArray2 = dataTable3.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Type='Total Hours > 17:00'");
            if (dataRowArray2.Length > 0)
            {
              int Minutes = 0;
              int num2 = checked (dataRowArray2.Length - 1);
              int index2 = 0;
              while (index2 <= num2)
              {
                Minutes = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) Minutes, dataRowArray2[index2]["Time"]));
                checked { ++index2; }
              }
              row27[index12] = (object) this.formatTime(Minutes);
            }
            else
              row27[index12] = (object) this.formatTime(0);
            checked { ++index12; }
          }
        }
        finally
        {
          if (enumerator13 is IDisposable)
            (enumerator13 as IDisposable).Dispose();
        }
        datatableIn.Rows.Add(row27);
        int num23 = checked (num22 + 1);
        DataRow row28 = datatableIn.NewRow();
        datatableIn.Rows.Add(row28);
        int num24 = checked (num23 + 1);
        DataRow row29 = datatableIn.NewRow();
        datatableIn.Rows.Add(row29);
        int num25 = checked (num24 + 1);
        Exporting exporting = new Exporting(datatableIn, "Timesheet " + Strings.Format((object) this.dtpFrom.Value, "dd-MM-yy") + " - " + Strings.Format((object) this.dtpTo.Value, "dd-MM-yy"), "", "", (DataSet) null);
        exporting = (Exporting) null;
      }
    }

    public void ExportSummary(string Department = null)
    {
      if (this.TimesheetsDataview.Count <= 0)
      {
        int num1 = (int) App.ShowMessage("No engineers are being displayed, please change / run filter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        int index1 = 0;
        DataTable datatableIn = new DataTable();
        datatableIn.Columns.Add("Engineer");
        datatableIn.Columns.Add("Travelling");
        datatableIn.Columns.Add("Working");
        datatableIn.Columns.Add("Lunch");
        datatableIn.Columns.Add("Non Chargeable");
        datatableIn.Columns.Add("Unallocated");
        datatableIn.Columns.Add("Total Hours > 17:00");
        DataTable dataTable1 = new DataTable();
        dataTable1.Columns.Add("Day", typeof (DateTime));
        DataRow[] dataRowArray1 = this.TimesheetsDataview.Table.Select("", "StartDateTime");
        int index2 = 0;
        while (index2 < dataRowArray1.Length)
        {
          DataRow dataRow = dataRowArray1[index2];
          if (dataTable1.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(dataRow["StartDateTime"]), "dd/MMM/yyyy") + "'").Length == 0)
          {
            DataRow row = dataTable1.NewRow();
            row["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(dataRow["StartDateTime"]), "dd/MMM/yyyy");
            dataTable1.Rows.Add(row);
          }
          checked { ++index2; }
        }
        if (dataTable1.Rows.Count > 5)
        {
          int count = dataTable1.Rows.Count;
          int num2 = 6;
          while (num2 <= count)
          {
            datatableIn.Columns.Add(Conversions.ToString(num2));
            checked { ++num2; }
          }
        }
        int num3 = 2;
        string str1 = "";
        string str2 = "";
        DataTable dataTable2 = new DataTable();
        dataTable2.Columns.Add("Name");
        DataRow row1 = dataTable2.NewRow();
        row1["Name"] = (object) "TRAVELLING";
        dataTable2.Rows.Add(row1);
        DataRow row2 = dataTable2.NewRow();
        row2["Name"] = (object) "WORKING";
        dataTable2.Rows.Add(row2);
        DataRow row3 = dataTable2.NewRow();
        row3["Name"] = (object) "LUNCH";
        dataTable2.Rows.Add(row3);
        DataRow row4 = dataTable2.NewRow();
        row4["Name"] = (object) "NON-CHARGEABLE";
        dataTable2.Rows.Add(row4);
        DataTable dataTable3 = new DataTable();
        dataTable3.Columns.Add("Engineer");
        dataTable3.Columns.Add("Day");
        dataTable3.Columns.Add("Type");
        dataTable3.Columns.Add("Time");
        DataTable dataTable4 = new DataTable();
        dataTable4.Columns.Add("Engineer");
        dataTable4.Columns.Add("Day");
        dataTable4.Columns.Add("StartDay");
        dataTable4.Columns.Add("EndDay");
        DataTable dataTable5 = new DataTable();
        dataTable5.Columns.Add("Day");
        dataTable5.Columns.Add("Time");
        int num4 = checked (((DataView) this.dgTimesheets.DataSource).Count - 1);
        int row5 = 0;
        DataRow row6;
        while (row5 <= num4)
        {
          this.dgTimesheets.CurrentRowIndex = row5;
          datatableIn.NewRow();
          DataRow[] dataRowArray2 = dataTable3.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Engineer='", this.SelectedJobDataRow["Engineer"]), (object) "' AND Day='"), (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy")), (object) "' AND Type='"), this.SelectedJobDataRow["TimeSheetType"]), (object) "'")));
          if (dataRowArray2.Length > 0)
          {
            DataRow dataRow;
            (dataRow = dataRowArray2[0])["Time"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow["Time"], (object) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["EndDateTime"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          }
          else
          {
            DataRow row7 = dataTable3.NewRow();
            row7["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Engineer"]);
            row7["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
            row7["Type"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["TimeSheetType"]);
            row7["Time"] = (object) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["EndDateTime"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            dataTable3.Rows.Add(row7);
          }
          DataRow row8 = dataTable3.NewRow();
          row8["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Engineer"]);
          row8["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
          row8["Type"] = (object) "Total Hours > 17:00";
          int num2 = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess((object) Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy") + " 17:00:00"), this.SelectedJobDataRow["StartDateTime"], false) ? checked ((int) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy") + " 17:00:00"), Conversions.ToDate(this.SelectedJobDataRow["EndDateTime"]), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) : checked ((int) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(this.SelectedJobDataRow["StartDateTime"]), Conversions.ToDate(this.SelectedJobDataRow["EndDateTime"]), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          row8["Time"] = num2 <= 0 ? (object) 0 : (object) num2;
          dataTable3.Rows.Add(row8);
          DataRow[] dataRowArray3 = dataTable4.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Engineer='", this.SelectedJobDataRow["Engineer"]), (object) "' AND Day='"), (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy")), (object) "'")));
          if (dataRowArray3.Length == 0)
          {
            DataRow row7 = dataTable4.NewRow();
            row7["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Engineer"]);
            row7["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
            row7["StartDay"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]);
            row7["EndDay"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["EndDateTime"]);
            dataTable4.Rows.Add(row7);
          }
          else
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(dataRowArray3[0]["StartDay"], this.SelectedJobDataRow["StartDateTime"], false))
              dataRowArray3[0]["StartDay"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]);
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(dataRowArray3[0]["EndDay"], this.SelectedJobDataRow["EndDateTime"], false))
              dataRowArray3[0]["EndDay"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["EndDateTime"]);
          }
          if (num3 == 2)
          {
            row6 = datatableIn.NewRow();
            row6["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Engineer"]);
            str1 = Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["StartDateTime"]), "dd/MM/yyyy");
            str2 = Conversions.ToString(this.SelectedJobDataRow["Engineer"]);
          }
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual((object) str2, this.SelectedJobDataRow["Engineer"], false))
          {
            IEnumerator enumerator1;
            try
            {
              enumerator1 = dataTable2.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current1 = (DataRow) enumerator1.Current;
                int num5 = 0;
                IEnumerator enumerator2;
                try
                {
                  enumerator2 = dataTable1.Rows.GetEnumerator();
                  while (enumerator2.MoveNext())
                  {
                    DataRow current2 = (DataRow) enumerator2.Current;
                    DataRow[] dataRowArray4 = dataTable3.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current2["Day"]), "dd/MM/yyyy") + "' AND Engineer='" + str2 + "' AND Type='" + current1["Name"].ToString() + "'");
                    if (dataRowArray4.Length > 0)
                      num5 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num5, dataRowArray4[0]["Time"]));
                  }
                }
                finally
                {
                  if (enumerator2 is IDisposable)
                    (enumerator2 as IDisposable).Dispose();
                }
                row6[index1] = (object) num5;
                checked { ++index1; }
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            int num6 = 0;
            IEnumerator enumerator3;
            try
            {
              enumerator3 = dataTable1.Rows.GetEnumerator();
              while (enumerator3.MoveNext())
              {
                DataRow current = (DataRow) enumerator3.Current;
                DataRow[] dataRowArray4 = dataTable4.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='" + str2 + "'");
                if (dataRowArray4.Length > 0)
                {
                  DataRow[] dataRowArray5 = dataTable3.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='" + str2 + "'");
                  if (dataRowArray5.Length > 0)
                  {
                    int num5 = 0;
                    DataRow[] dataRowArray6 = dataRowArray5;
                    int index3 = 0;
                    while (index3 < dataRowArray6.Length)
                    {
                      DataRow dataRow = dataRowArray6[index3];
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dataRow["Type"], (object) "Total Hours > 17:00", false))
                        num5 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num5, dataRow["Time"]));
                      checked { ++index3; }
                    }
                    num6 = checked ((int) ((long) num6 + (DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) - (long) num5)));
                    DataRow row7 = dataTable5.NewRow();
                    row7["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy");
                    row7["Time"] = (object) checked (DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) - (long) num5);
                    dataTable5.Rows.Add(row7);
                  }
                  else
                    num6 = checked ((int) ((long) num6 + DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray4[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)));
                }
              }
            }
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
            row6[index1] = (object) num6;
            int index4 = checked (index1 + 1);
            int num7 = 0;
            IEnumerator enumerator4;
            try
            {
              enumerator4 = dataTable1.Rows.GetEnumerator();
              while (enumerator4.MoveNext())
              {
                DataRow current = (DataRow) enumerator4.Current;
                DataRow[] dataRowArray4 = dataTable3.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='" + str2 + "' AND Type='Total Hours > 17:00'");
                if (dataRowArray4.Length > 0)
                {
                  int num5 = 0;
                  int num8 = checked (dataRowArray4.Length - 1);
                  int index3 = 0;
                  while (index3 <= num8)
                  {
                    num5 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num5, dataRowArray4[index3]["Time"]));
                    checked { ++index3; }
                  }
                  checked { num7 += num5; }
                }
              }
            }
            finally
            {
              if (enumerator4 is IDisposable)
                (enumerator4 as IDisposable).Dispose();
            }
            row6[index4] = (object) num7;
            datatableIn.Rows.Add(row6);
            checked { ++num3; }
            index1 = checked (index4 + 1);
            str2 = Conversions.ToString(this.SelectedJobDataRow["Engineer"]);
            row6 = datatableIn.NewRow();
            row6["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedJobDataRow["Engineer"]);
          }
          this.dgTimesheets.UnSelect(row5);
          checked { ++num3; }
          checked { ++row5; }
        }
        int index5 = 1;
        IEnumerator enumerator5;
        try
        {
          enumerator5 = dataTable2.Rows.GetEnumerator();
          while (enumerator5.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator5.Current;
            int num2 = 0;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = dataTable1.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current2 = (DataRow) enumerator1.Current;
                DataRow[] dataRowArray2 = dataTable3.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current2["Day"]), "dd/MM/yyyy") + "' AND Engineer='"), this.SelectedJobDataRow["Engineer"]), (object) "' AND Type='"), (object) current1["Name"].ToString()), (object) "'")));
                if (dataRowArray2.Length > 0)
                  num2 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, dataRowArray2[0]["Time"]));
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            row6[index5] = (object) num2;
            checked { ++index5; }
          }
        }
        finally
        {
          if (enumerator5 is IDisposable)
            (enumerator5 as IDisposable).Dispose();
        }
        int num9 = 0;
        IEnumerator enumerator6;
        try
        {
          enumerator6 = dataTable1.Rows.GetEnumerator();
          while (enumerator6.MoveNext())
          {
            DataRow current = (DataRow) enumerator6.Current;
            DataRow[] dataRowArray2 = dataTable4.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='"), this.SelectedJobDataRow["Engineer"]), (object) "'")));
            if (dataRowArray2.Length > 0)
            {
              DataRow[] dataRowArray3 = dataTable3.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='"), this.SelectedJobDataRow["Engineer"]), (object) "'")));
              if (dataRowArray3.Length > 0)
              {
                int num2 = 0;
                DataRow[] dataRowArray4 = dataRowArray3;
                int index3 = 0;
                while (index3 < dataRowArray4.Length)
                {
                  DataRow dataRow = dataRowArray4[index3];
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dataRow["Type"], (object) "Total Hours > 17:00", false))
                    num2 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, dataRow["Time"]));
                  checked { ++index3; }
                }
                num9 = checked ((int) ((long) num9 + (DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) - (long) num2)));
                DataRow row7 = dataTable5.NewRow();
                row7["Day"] = (object) Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy");
                row7["Time"] = (object) checked (DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) - (long) num2);
                dataTable5.Rows.Add(row7);
              }
              else
                num9 = checked ((int) ((long) num9 + DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format((object) Conversions.ToDate(dataRowArray2[0]["EndDay"]), "dd/MM/yyyy HH:mm")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)));
            }
          }
        }
        finally
        {
          if (enumerator6 is IDisposable)
            (enumerator6 as IDisposable).Dispose();
        }
        row6[index5] = (object) num9;
        int index6 = checked (index5 + 1);
        int num10 = 0;
        IEnumerator enumerator7;
        try
        {
          enumerator7 = dataTable1.Rows.GetEnumerator();
          while (enumerator7.MoveNext())
          {
            DataRow current = (DataRow) enumerator7.Current;
            DataRow[] dataRowArray2 = dataTable3.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Engineer='"), this.SelectedJobDataRow["Engineer"]), (object) "' AND Type='Total Hours > 17:00'")));
            if (dataRowArray2.Length > 0)
            {
              int num2 = 0;
              int num5 = checked (dataRowArray2.Length - 1);
              int index3 = 0;
              while (index3 <= num5)
              {
                num2 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, dataRowArray2[index3]["Time"]));
                checked { ++index3; }
              }
              checked { num10 += num2; }
            }
          }
        }
        finally
        {
          if (enumerator7 is IDisposable)
            (enumerator7 as IDisposable).Dispose();
        }
        row6[index6] = (object) num10;
        datatableIn.Rows.Add(row6);
        int num11 = checked (num3 + 1);
        int num12 = checked (index6 + 1);
        DataRow row9 = datatableIn.NewRow();
        row9["Engineer"] = (object) "MASTER SUMMARY";
        int index7 = 1;
        IEnumerator enumerator8;
        try
        {
          enumerator8 = dataTable2.Rows.GetEnumerator();
          while (enumerator8.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator8.Current;
            int num2 = 0;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = dataTable1.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current2 = (DataRow) enumerator1.Current;
                DataRow[] dataRowArray2 = dataTable3.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current2["Day"]), "dd/MM/yyyy") + "' AND Type='" + current1["Name"].ToString() + "'");
                if (dataRowArray2.Length > 0)
                {
                  int num5 = 0;
                  int num6 = checked (dataRowArray2.Length - 1);
                  int index3 = 0;
                  while (index3 <= num6)
                  {
                    num5 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num5, dataRowArray2[index3]["Time"]));
                    checked { ++index3; }
                  }
                  checked { num2 += num5; }
                }
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            row9[index7] = (object) num2;
            checked { ++index7; }
          }
        }
        finally
        {
          if (enumerator8 is IDisposable)
            (enumerator8 as IDisposable).Dispose();
        }
        int num13 = 0;
        IEnumerator enumerator9;
        try
        {
          enumerator9 = dataTable1.Rows.GetEnumerator();
          while (enumerator9.MoveNext())
          {
            DataRow current = (DataRow) enumerator9.Current;
            int num2 = 0;
            DataRow[] dataRowArray2 = dataTable5.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "'");
            int num5 = checked (dataRowArray2.Length - 1);
            int index3 = 0;
            while (index3 <= num5)
            {
              num2 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, dataRowArray2[index3]["Time"]));
              checked { ++index3; }
            }
            checked { num13 += num2; }
          }
        }
        finally
        {
          if (enumerator9 is IDisposable)
            (enumerator9 as IDisposable).Dispose();
        }
        row9[index7] = (object) num13;
        int index8 = checked (index7 + 1);
        int num14 = 0;
        IEnumerator enumerator10;
        try
        {
          enumerator10 = dataTable1.Rows.GetEnumerator();
          while (enumerator10.MoveNext())
          {
            DataRow current = (DataRow) enumerator10.Current;
            DataRow[] dataRowArray2 = dataTable3.Select("Day='" + Strings.Format(RuntimeHelpers.GetObjectValue(current["Day"]), "dd/MM/yyyy") + "' AND Type='Total Hours > 17:00'");
            if (dataRowArray2.Length > 0)
            {
              int num2 = 0;
              int num5 = checked (dataRowArray2.Length - 1);
              int index3 = 0;
              while (index3 <= num5)
              {
                num2 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, dataRowArray2[index3]["Time"]));
                checked { ++index3; }
              }
              checked { num14 += num2; }
            }
          }
        }
        finally
        {
          if (enumerator10 is IDisposable)
            (enumerator10 as IDisposable).Dispose();
        }
        row9[index8] = (object) num14;
        datatableIn.Rows.Add(row9);
        int num15 = checked (num11 + 1);
        num12 = checked (index8 + 1);
        DataRow row10 = datatableIn.NewRow();
        datatableIn.Rows.Add(row10);
        int num16 = checked (num15 + 1);
        DataRow row11 = datatableIn.NewRow();
        datatableIn.Rows.Add(row11);
        int num17 = checked (num16 + 1);
        Exporting exporting = new Exporting(datatableIn, "TS Summary " + Strings.Format((object) this.dtpFrom.Value, "dd-MM-yy") + " - " + Strings.Format((object) this.dtpTo.Value, "dd-MM-yy"), "", "", (DataSet) null);
        exporting = (Exporting) null;
      }
    }

    private string formatTime(int Minutes)
    {
      if (Minutes < 0)
        return "00:00";
      return Minutes % 60 < 10 ? Conversions.ToString(Math.Floor((double) Minutes / 60.0)) + ":0" + Conversions.ToString(Minutes % 60) : Conversions.ToString(Math.Floor((double) Minutes / 60.0)) + ":" + Conversions.ToString(Minutes % 60);
    }
  }
}
