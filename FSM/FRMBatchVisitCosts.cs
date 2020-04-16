// Decompiled with JetBrains decompiler
// Type: FSM.FRMBatchVisitCosts
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
  public class FRMBatchVisitCosts : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvVisits;

    public FRMBatchVisitCosts()
    {
      this.Load += new EventHandler(this.FRMVisitManager_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
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
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgVisits_MouseUp);
        DataGrid dgVisits1 = this._dgVisits;
        if (dgVisits1 != null)
          dgVisits1.MouseUp -= mouseEventHandler;
        this._dgVisits = value;
        DataGrid dgVisits2 = this._dgVisits;
        if (dgVisits2 == null)
          return;
        dgVisits2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnShowdata
    {
      get
      {
        return this._btnShowdata;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnShowdata_Click);
        Button btnShowdata1 = this._btnShowdata;
        if (btnShowdata1 != null)
          btnShowdata1.Click -= eventHandler;
        this._btnShowdata = value;
        Button btnShowdata2 = this._btnShowdata;
        if (btnShowdata2 == null)
          return;
        btnShowdata2.Click += eventHandler;
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

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpEngineerVisits = new GroupBox();
      this.dgVisits = new DataGrid();
      this.btnExport = new Button();
      this.Label8 = new Label();
      this.Label9 = new Label();
      this.dtpFrom = new DateTimePicker();
      this.dtpTo = new DateTimePicker();
      this.btnShowdata = new Button();
      this.btnSelectAll = new Button();
      this.btnUnselect = new Button();
      this.grpFilter = new GroupBox();
      this.Label1 = new Label();
      this.grpEngineerVisits.SuspendLayout();
      this.dgVisits.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineerVisits.Controls.Add((Control) this.dgVisits);
      this.grpEngineerVisits.Location = new System.Drawing.Point(8, 121);
      this.grpEngineerVisits.Name = "grpEngineerVisits";
      this.grpEngineerVisits.Size = new Size(784, 340);
      this.grpEngineerVisits.TabIndex = 2;
      this.grpEngineerVisits.TabStop = false;
      this.grpEngineerVisits.Text = "Double Click To View / Edit";
      this.dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgVisits.DataMember = "";
      this.dgVisits.HeaderForeColor = SystemColors.ControlText;
      this.dgVisits.Location = new System.Drawing.Point(8, 18);
      this.dgVisits.Name = "dgVisits";
      this.dgVisits.Size = new Size(768, 314);
      this.dgVisits.TabIndex = 14;
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(16, 467);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(96, 23);
      this.btnExport.TabIndex = 37;
      this.btnExport.Text = "Export";
      this.Label8.Location = new System.Drawing.Point(76, 24);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(48, 16);
      this.Label8.TabIndex = 9;
      this.Label8.Text = "From";
      this.Label9.Location = new System.Drawing.Point(279, 24);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(48, 16);
      this.Label9.TabIndex = 10;
      this.Label9.Text = "To";
      this.dtpFrom.Location = new System.Drawing.Point(116, 21);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(144, 21);
      this.dtpFrom.TabIndex = 12;
      this.dtpTo.Location = new System.Drawing.Point(319, 21);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(144, 21);
      this.dtpTo.TabIndex = 13;
      this.btnShowdata.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnShowdata.Location = new System.Drawing.Point(679, 51);
      this.btnShowdata.Name = "btnShowdata";
      this.btnShowdata.Size = new Size(96, 23);
      this.btnShowdata.TabIndex = 35;
      this.btnShowdata.Text = "Show Data";
      this.btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSelectAll.Location = new System.Drawing.Point(11, 51);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(96, 23);
      this.btnSelectAll.TabIndex = 36;
      this.btnSelectAll.Text = "Select All";
      this.btnUnselect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnUnselect.Location = new System.Drawing.Point(113, 51);
      this.btnUnselect.Name = "btnUnselect";
      this.btnUnselect.Size = new Size(96, 23);
      this.btnUnselect.TabIndex = 37;
      this.btnUnselect.Text = "Unselect All";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.btnUnselect);
      this.grpFilter.Controls.Add((Control) this.btnSelectAll);
      this.grpFilter.Controls.Add((Control) this.btnShowdata);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(784, 83);
      this.grpFilter.TabIndex = 1;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(8, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(62, 13);
      this.Label1.TabIndex = 38;
      this.Label1.Text = "Visit Date";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(800, 494);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpEngineerVisits);
      this.Controls.Add((Control) this.grpFilter);
      this.MinimumSize = new Size(808, 528);
      this.Name = nameof (FRMBatchVisitCosts);
      this.Text = "Batch Visit Costs Data Report";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.grpEngineerVisits, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
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
      this.PopulateDatagrid();
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
        this._dvVisits.AllowNew = false;
        this._dvVisits.AllowEdit = true;
        this._dvVisits.AllowDelete = false;
        this._dvVisits.Table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
        this.dgVisits.DataSource = (object) this.VisitsDataview;
      }
    }

    private DataRow SelectedVisitDataRow
    {
      get
      {
        return this.dgVisits.CurrentRowIndex != -1 ? this.VisitsDataview[this.dgVisits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupVisitDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgVisits.TableStyles[0];
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "tick";
      dataGridBoolColumn.ReadOnly = false;
      dataGridBoolColumn.Width = 25;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "StartDateTime";
      dataGridLabelColumn1.MappingName = "StartDateTime";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "VisitStatus";
      dataGridLabelColumn2.MappingName = "VisitStatus";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "NotesToEngineer";
      dataGridLabelColumn3.MappingName = "NotesToEngineer";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "NotesFromEngineer";
      dataGridLabelColumn4.MappingName = "NotesFromEngineer";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "OutcomeDetails";
      dataGridLabelColumn5.MappingName = "OutcomeDetails";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 150;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "VisitOutcome";
      dataGridLabelColumn6.MappingName = "VisitOutcome";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 150;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Customer";
      dataGridLabelColumn7.MappingName = "Customer";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 150;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "ForSageAccountCode";
      dataGridLabelColumn8.MappingName = "ForSageAccountCode";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 150;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Site";
      dataGridLabelColumn9.MappingName = "Site";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Postcode";
      dataGridLabelColumn10.MappingName = "SitePostcode";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 75;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "JobID";
      dataGridLabelColumn11.MappingName = "JobID";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 75;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "Job Number";
      dataGridLabelColumn12.MappingName = "JobNumber";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 75;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "JobDefinition";
      dataGridLabelColumn13.MappingName = "JobDefinition";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 75;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      DataGridLabelColumn dataGridLabelColumn14 = new DataGridLabelColumn();
      dataGridLabelColumn14.Format = "";
      dataGridLabelColumn14.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn14.HeaderText = "Type";
      dataGridLabelColumn14.MappingName = "Type";
      dataGridLabelColumn14.ReadOnly = true;
      dataGridLabelColumn14.Width = 75;
      dataGridLabelColumn14.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn14);
      DataGridLabelColumn dataGridLabelColumn15 = new DataGridLabelColumn();
      dataGridLabelColumn15.Format = "";
      dataGridLabelColumn15.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn15.HeaderText = "Engineer";
      dataGridLabelColumn15.MappingName = "Engineer";
      dataGridLabelColumn15.ReadOnly = true;
      dataGridLabelColumn15.Width = 75;
      dataGridLabelColumn15.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn15);
      DataGridLabelColumn dataGridLabelColumn16 = new DataGridLabelColumn();
      dataGridLabelColumn16.Format = "";
      dataGridLabelColumn16.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn16.HeaderText = "VisitCharge";
      dataGridLabelColumn16.MappingName = "VisitCharge";
      dataGridLabelColumn16.ReadOnly = true;
      dataGridLabelColumn16.Width = 75;
      dataGridLabelColumn16.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn16);
      DataGridLabelColumn dataGridLabelColumn17 = new DataGridLabelColumn();
      dataGridLabelColumn17.Format = "";
      dataGridLabelColumn17.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn17.HeaderText = "EngineerCost";
      dataGridLabelColumn17.MappingName = "EngineerCost";
      dataGridLabelColumn17.ReadOnly = true;
      dataGridLabelColumn17.Width = 75;
      dataGridLabelColumn17.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn17);
      DataGridLabelColumn dataGridLabelColumn18 = new DataGridLabelColumn();
      dataGridLabelColumn18.Format = "";
      dataGridLabelColumn18.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn18.HeaderText = "PartProductCost";
      dataGridLabelColumn18.MappingName = "PartProductCost";
      dataGridLabelColumn18.ReadOnly = true;
      dataGridLabelColumn18.Width = 75;
      dataGridLabelColumn18.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn18);
      DataGridLabelColumn dataGridLabelColumn19 = new DataGridLabelColumn();
      dataGridLabelColumn19.Format = "";
      dataGridLabelColumn19.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn19.HeaderText = "PartsToFit";
      dataGridLabelColumn19.MappingName = "PartsToFit";
      dataGridLabelColumn19.ReadOnly = true;
      dataGridLabelColumn19.Width = 75;
      dataGridLabelColumn19.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn19);
      DataGridLabelColumn dataGridLabelColumn20 = new DataGridLabelColumn();
      dataGridLabelColumn20.Format = "";
      dataGridLabelColumn20.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn20.HeaderText = "SupInvoice";
      dataGridLabelColumn20.MappingName = "SupInvoice";
      dataGridLabelColumn20.ReadOnly = true;
      dataGridLabelColumn20.Width = 75;
      dataGridLabelColumn20.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn20);
      DataGridLabelColumn dataGridLabelColumn21 = new DataGridLabelColumn();
      dataGridLabelColumn21.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn21.HeaderText = "Credit";
      dataGridLabelColumn21.MappingName = "Credit";
      dataGridLabelColumn21.ReadOnly = true;
      dataGridLabelColumn21.Width = 100;
      dataGridLabelColumn21.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn21);
      DataGridLabelColumn dataGridLabelColumn22 = new DataGridLabelColumn();
      dataGridLabelColumn22.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn22.HeaderText = "ContractType";
      dataGridLabelColumn22.MappingName = "ContractType";
      dataGridLabelColumn22.ReadOnly = true;
      dataGridLabelColumn22.Width = 100;
      dataGridLabelColumn22.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn22);
      DataGridLabelColumn dataGridLabelColumn23 = new DataGridLabelColumn();
      dataGridLabelColumn23.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn23.HeaderText = "Jobitems";
      dataGridLabelColumn23.MappingName = "Jobitems";
      dataGridLabelColumn23.ReadOnly = true;
      dataGridLabelColumn23.Width = 100;
      dataGridLabelColumn23.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn23);
      DataGridLabelColumn dataGridLabelColumn24 = new DataGridLabelColumn();
      dataGridLabelColumn24.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn24.HeaderText = "Department";
      dataGridLabelColumn24.MappingName = "Department";
      dataGridLabelColumn24.ReadOnly = true;
      dataGridLabelColumn24.Width = 100;
      dataGridLabelColumn24.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn24);
      DataGridLabelColumn dataGridLabelColumn25 = new DataGridLabelColumn();
      dataGridLabelColumn25.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn25.HeaderText = "NominalCode";
      dataGridLabelColumn25.MappingName = "NominalCode";
      dataGridLabelColumn25.ReadOnly = true;
      dataGridLabelColumn25.Width = 100;
      dataGridLabelColumn25.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn25);
      DataGridLabelColumn dataGridLabelColumn26 = new DataGridLabelColumn();
      dataGridLabelColumn26.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn26.HeaderText = "JobValue";
      dataGridLabelColumn26.MappingName = "JobValue";
      dataGridLabelColumn26.ReadOnly = true;
      dataGridLabelColumn26.Width = 100;
      dataGridLabelColumn26.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn26);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisit.ToString();
      this.dgVisits.TableStyles.Add(tableStyle);
    }

    public DataRow SelectedJobRow
    {
      get
      {
        return this.dgVisits.CurrentRowIndex != -1 ? this.VisitsDataview[this.dgVisits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void FRMVisitManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void btnShowdata_Click(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void dgVisits_MouseUp(object sender, MouseEventArgs e)
    {
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.VisitsDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnUnselect_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.VisitsDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    public void PopulateDatagrid()
    {
      try
      {
        this.ResetFilters();
        if (this.get_GetParameter(0) == null)
          return;
        this.VisitsDataview = (DataView) this.get_GetParameter(0);
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
      this.dtpFrom.Value = DateAndTime.Today.AddDays(-1.0);
      this.dtpTo.Value = DateAndTime.Today.AddMonths(-1);
      this.dtpFrom.Enabled = true;
      this.dtpTo.Enabled = true;
      this.grpFilter.Enabled = true;
    }

    private void RunFilter()
    {
      string Where = "WHERE tblEngineerVisit.Deleted = 0 AND tblJobOfWork.Deleted = 0 AND tblJob.Deleted = 0 AND (tblInvoiceToBeRaised.InvoiceTypeID = 260 OR tblInvoiceToBeRaised.InvoiceTypeID is null) AND (DATEADD(dd, 0, DATEDIFF(dd, 0, tblEngineerVisit.StartDateTime))>= CONVERT(DATETIME, '" + Strings.Format((object) this.dtpFrom.Value, "yyyy-MM-dd 00:00:00") + "', 102)) AND (DATEADD(dd, 0, DATEDIFF(dd, 0, tblEngineerVisit.StartDateTime))<= CONVERT(DATETIME, '" + Strings.Format((object) this.dtpTo.Value, "yyyy-MM-dd 23:59:59") + "', 102)) AND (tblEngineerVisit.Deleted = 0)";
      this.VisitsDataview = App.DB.Reports.Reports_BatchVisitCosts(Where);
      this.grpEngineerVisits.Text = "Visits: " + Conversions.ToString(this.VisitsDataview.Table.Rows.Count);
    }

    public void Export()
    {
      DataTable datatableIn = new DataTable();
      datatableIn.Columns.Add("StartDateTime", typeof (DateTime));
      datatableIn.Columns.Add("VisitStatus");
      datatableIn.Columns.Add("NotesToEngineer");
      datatableIn.Columns.Add("NotesFromEngineer");
      datatableIn.Columns.Add("OutcomeDetails");
      datatableIn.Columns.Add("VisitOutcome");
      datatableIn.Columns.Add("Customer");
      datatableIn.Columns.Add("ForSageAccountCode");
      datatableIn.Columns.Add("Site");
      datatableIn.Columns.Add("Postcode");
      datatableIn.Columns.Add("JobID");
      datatableIn.Columns.Add("JobNumber");
      datatableIn.Columns.Add("JobDefinition");
      datatableIn.Columns.Add("Type");
      datatableIn.Columns.Add("Engineer");
      datatableIn.Columns.Add("VisitCharge", typeof (double));
      datatableIn.Columns.Add("EngineerCost");
      datatableIn.Columns.Add("PartProductCost");
      datatableIn.Columns.Add("PartsToFit");
      datatableIn.Columns.Add("SupInvoice");
      datatableIn.Columns.Add("Credit");
      datatableIn.Columns.Add("ContractType");
      datatableIn.Columns.Add("Jobitems");
      datatableIn.Columns.Add("Department");
      datatableIn.Columns.Add("NominalCode");
      datatableIn.Columns.Add("JobValue", typeof (double));
      datatableIn.Columns.Add("WorkingHours");
      datatableIn.Columns.Add("TravelingHours");
      int num = checked (((DataView) this.dgVisits.DataSource).Count - 1);
      int row1 = 0;
      while (row1 <= num)
      {
        this.dgVisits.CurrentRowIndex = row1;
        DataRow row2 = datatableIn.NewRow();
        row2["StartDateTime"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["StartDateTime"]);
        row2["VisitStatus"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["VisitStatus"]);
        row2["NotesToEngineer"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["NotesToEngineer"]);
        row2["NotesFromEngineer"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["NotesFromEngineer"]);
        row2["OutcomeDetails"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["OutcomeDetails"]);
        row2["VisitOutcome"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["VisitOutcome"]);
        row2["Customer"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Customer"]);
        row2["ForSageAccountCode"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["ForSageAccountCode"]);
        row2["Site"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Site"]);
        row2["Postcode"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Postcode"]);
        row2["JobID"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["JobID"]);
        row2["JobNumber"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["JobNumber"]);
        row2["JobDefinition"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["JobDefinition"]);
        row2["Type"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Type"]);
        row2["Engineer"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Engineer"]);
        row2["VisitCharge"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["VisitCharge"]);
        row2["EngineerCost"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["EngineerCost"]);
        row2["PartProductCost"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["PartProductCost"]);
        row2["PartsToFit"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["PartsToFit"]);
        row2["SupInvoice"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["SupInvoice"]);
        row2["Credit"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Credit"]);
        row2["ContractType"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["ContractType"]);
        row2["Jobitems"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Jobitems"]);
        row2["Department"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["Department"]);
        row2["NominalCode"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["NominalCode"]);
        row2["JobValue"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["JobValue"]);
        row2["WorkingHours"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["WorkingHours"]);
        row2["TravelingHours"] = RuntimeHelpers.GetObjectValue(this.SelectedVisitDataRow["TravelingHours"]);
        datatableIn.Rows.Add(row2);
        this.dgVisits.UnSelect(row1);
        checked { ++row1; }
      }
      Exporting exporting = new Exporting(datatableIn, "Batch Visit Costs Report", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }
  }
}
