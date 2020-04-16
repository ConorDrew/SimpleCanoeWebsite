// Decompiled with JetBrains decompiler
// Type: FSM.FRMLastGSRReport
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
  public class FRMLastGSRReport : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _ProductsDataview;
    private FSM.Entity.Customers.Customer _theCustomer;

    public FRMLastGSRReport()
    {
      this.Load += new EventHandler(this.FRMEngineerTimesheetReport_Load);
      this.InitializeComponent();
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

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnPrintGSRReminders
    {
      get
      {
        return this._btnPrintGSRReminders;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintGSRReminders_Click);
        Button printGsrReminders1 = this._btnPrintGSRReminders;
        if (printGsrReminders1 != null)
          printGsrReminders1.Click -= eventHandler;
        this._btnPrintGSRReminders = value;
        Button printGsrReminders2 = this._btnPrintGSRReminders;
        if (printGsrReminders2 == null)
          return;
        printGsrReminders2.Click += eventHandler;
      }
    }

    internal virtual ProgressBar pbStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual CheckBox chkNotPrinted { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboContract { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkIncludeTenantsAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnEmailNone
    {
      get
      {
        return this._btnEmailNone;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEmailNone_Click);
        Button btnEmailNone1 = this._btnEmailNone;
        if (btnEmailNone1 != null)
          btnEmailNone1.Click -= eventHandler;
        this._btnEmailNone = value;
        Button btnEmailNone2 = this._btnEmailNone;
        if (btnEmailNone2 == null)
          return;
        btnEmailNone2.Click += eventHandler;
      }
    }

    internal virtual Button btnEmailAll
    {
      get
      {
        return this._btnEmailAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEmailAll_Click);
        Button btnEmailAll1 = this._btnEmailAll;
        if (btnEmailAll1 != null)
          btnEmailAll1.Click -= eventHandler;
        this._btnEmailAll = value;
        Button btnEmailAll2 = this._btnEmailAll;
        if (btnEmailAll2 == null)
          return;
        btnEmailAll2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgProductsLastGSR
    {
      get
      {
        return this._dgProductsLastGSR;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dg_MouseUp);
        DataGrid dgProductsLastGsr1 = this._dgProductsLastGSR;
        if (dgProductsLastGsr1 != null)
          dgProductsLastGsr1.MouseUp -= mouseEventHandler;
        this._dgProductsLastGSR = value;
        DataGrid dgProductsLastGsr2 = this._dgProductsLastGSR;
        if (dgProductsLastGsr2 == null)
          return;
        dgProductsLastGsr2.MouseUp += mouseEventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobs = new GroupBox();
      this.dgProductsLastGSR = new DataGrid();
      this.btnExport = new Button();
      this.grpFilter = new GroupBox();
      this.btnFilter = new Button();
      this.cboRegion = new ComboBox();
      this.Label2 = new Label();
      this.cboContract = new ComboBox();
      this.Label1 = new Label();
      this.chkIncludeTenantsAssets = new CheckBox();
      this.chkNotPrinted = new CheckBox();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.Label4 = new Label();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.btnReset = new Button();
      this.btnPrintGSRReminders = new Button();
      this.pbStatus = new ProgressBar();
      this.btnUnselect = new Button();
      this.btnSelectAll = new Button();
      this.btnEmailNone = new Button();
      this.btnEmailAll = new Button();
      this.grpJobs.SuspendLayout();
      this.dgProductsLastGSR.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.dgProductsLastGSR);
      this.grpJobs.Location = new System.Drawing.Point(8, 185);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(1172, 271);
      this.grpJobs.TabIndex = 1;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Service Reminders";
      this.dgProductsLastGSR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgProductsLastGSR.DataMember = "";
      this.dgProductsLastGSR.HeaderForeColor = SystemColors.ControlText;
      this.dgProductsLastGSR.Location = new System.Drawing.Point(8, 19);
      this.dgProductsLastGSR.Name = "dgProductsLastGSR";
      this.dgProductsLastGSR.Size = new Size(1156, 244);
      this.dgProductsLastGSR.TabIndex = 0;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 464);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 2;
      this.btnExport.Text = "Export";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.btnFilter);
      this.grpFilter.Controls.Add((Control) this.cboRegion);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.cboContract);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.chkIncludeTenantsAssets);
      this.grpFilter.Controls.Add((Control) this.chkNotPrinted);
      this.grpFilter.Controls.Add((Control) this.btnFindCustomer);
      this.grpFilter.Controls.Add((Control) this.txtCustomer);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(1172, 115);
      this.grpFilter.TabIndex = 0;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.btnFilter.AccessibleDescription = "";
      this.btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFilter.Location = new System.Drawing.Point(1031, 75);
      this.btnFilter.Name = "btnFilter";
      this.btnFilter.Size = new Size(126, 23);
      this.btnFilter.TabIndex = 15;
      this.btnFilter.Text = "Run Filter";
      this.cboRegion.FormattingEnabled = true;
      this.cboRegion.Location = new System.Drawing.Point(310, 73);
      this.cboRegion.Name = "cboRegion";
      this.cboRegion.Size = new Size(144, 21);
      this.cboRegion.TabIndex = 14;
      this.Label2.Location = new System.Drawing.Point(248, 75);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(57, 17);
      this.Label2.TabIndex = 13;
      this.Label2.Text = "Region";
      this.cboContract.FormattingEnabled = true;
      this.cboContract.Location = new System.Drawing.Point(85, 71);
      this.cboContract.Name = "cboContract";
      this.cboContract.Size = new Size(144, 21);
      this.cboContract.TabIndex = 9;
      this.Label1.Location = new System.Drawing.Point(8, 73);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 16);
      this.Label1.TabIndex = 8;
      this.Label1.Text = "Contract";
      this.chkIncludeTenantsAssets.AutoSize = true;
      this.chkIncludeTenantsAssets.Location = new System.Drawing.Point(487, 21);
      this.chkIncludeTenantsAssets.Name = "chkIncludeTenantsAssets";
      this.chkIncludeTenantsAssets.Size = new Size(157, 17);
      this.chkIncludeTenantsAssets.TabIndex = 11;
      this.chkIncludeTenantsAssets.Text = "Include Tenants Assets";
      this.chkIncludeTenantsAssets.UseVisualStyleBackColor = true;
      this.chkNotPrinted.AutoSize = true;
      this.chkNotPrinted.Location = new System.Drawing.Point(664, 23);
      this.chkNotPrinted.Name = "chkNotPrinted";
      this.chkNotPrinted.Size = new Size(66, 17);
      this.chkNotPrinted.TabIndex = 12;
      this.chkNotPrinted.Text = "Printed";
      this.chkNotPrinted.UseVisualStyleBackColor = true;
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(1125, 44);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 7;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(85, 46);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(1034, 21);
      this.txtCustomer.TabIndex = 6;
      this.Label4.Location = new System.Drawing.Point(8, 49);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 16);
      this.Label4.TabIndex = 5;
      this.Label4.Text = "Customer";
      this.dtpTo.Location = new System.Drawing.Point(310, 20);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(144, 21);
      this.dtpTo.TabIndex = 3;
      this.dtpFrom.Location = new System.Drawing.Point(85, 20);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(144, 21);
      this.dtpFrom.TabIndex = 1;
      this.Label9.Location = new System.Drawing.Point(273, 21);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(24, 16);
      this.Label9.TabIndex = 2;
      this.Label9.Text = "To";
      this.Label8.Location = new System.Drawing.Point(8, 22);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(88, 16);
      this.Label8.TabIndex = 0;
      this.Label8.Text = "Date From";
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(72, 464);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 3;
      this.btnReset.Text = "Reset";
      this.btnPrintGSRReminders.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrintGSRReminders.Location = new System.Drawing.Point(1039, 464);
      this.btnPrintGSRReminders.Name = "btnPrintGSRReminders";
      this.btnPrintGSRReminders.Size = new Size(141, 23);
      this.btnPrintGSRReminders.TabIndex = 5;
      this.btnPrintGSRReminders.Text = "Print GSR Reminders";
      this.btnPrintGSRReminders.UseVisualStyleBackColor = true;
      this.pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pbStatus.Location = new System.Drawing.Point(134, 464);
      this.pbStatus.Name = "pbStatus";
      this.pbStatus.Size = new Size(899, 23);
      this.pbStatus.TabIndex = 4;
      this.btnUnselect.Location = new System.Drawing.Point(137, 156);
      this.btnUnselect.Name = "btnUnselect";
      this.btnUnselect.Size = new Size(96, 23);
      this.btnUnselect.TabIndex = 9;
      this.btnUnselect.Text = "Unselect All";
      this.btnUnselect.UseVisualStyleBackColor = true;
      this.btnSelectAll.Location = new System.Drawing.Point(12, 156);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(119, 23);
      this.btnSelectAll.TabIndex = 8;
      this.btnSelectAll.Text = "Select All";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.btnEmailNone.Location = new System.Drawing.Point(373, 156);
      this.btnEmailNone.Name = "btnEmailNone";
      this.btnEmailNone.Size = new Size(96, 23);
      this.btnEmailNone.TabIndex = 11;
      this.btnEmailNone.Text = "Email None";
      this.btnEmailNone.UseVisualStyleBackColor = true;
      this.btnEmailAll.Location = new System.Drawing.Point(248, 156);
      this.btnEmailAll.Name = "btnEmailAll";
      this.btnEmailAll.Size = new Size(119, 23);
      this.btnEmailAll.TabIndex = 10;
      this.btnEmailAll.Text = "Email All";
      this.btnEmailAll.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1188, 494);
      this.Controls.Add((Control) this.btnEmailNone);
      this.Controls.Add((Control) this.btnEmailAll);
      this.Controls.Add((Control) this.btnUnselect);
      this.Controls.Add((Control) this.btnSelectAll);
      this.Controls.Add((Control) this.pbStatus);
      this.Controls.Add((Control) this.btnPrintGSRReminders);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpJobs);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(808, 528);
      this.Name = nameof (FRMLastGSRReport);
      this.Text = "Product Last GSR Report";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.btnPrintGSRReminders, 0);
      this.Controls.SetChildIndex((Control) this.pbStatus, 0);
      this.Controls.SetChildIndex((Control) this.btnSelectAll, 0);
      this.Controls.SetChildIndex((Control) this.btnUnselect, 0);
      this.Controls.SetChildIndex((Control) this.btnEmailAll, 0);
      this.Controls.SetChildIndex((Control) this.btnEmailNone, 0);
      this.grpJobs.ResumeLayout(false);
      this.dgProductsLastGSR.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboContract = this.cboContract;
      Combo.SetUpCombo(ref cboContract, DynamicDataTables.ContractOnOrNone, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboContract = cboContract;
      ComboBox cboRegion = this.cboRegion;
      Combo.SetUpCombo(ref cboRegion, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboRegion = cboRegion;
      this.SetupTimesheetsDataGrid();
      this.dtpFrom.Value = DateAndTime.Today.AddYears(-1);
      DateTimePicker dtpTo = this.dtpTo;
      DateTime dateTime1 = DateAndTime.Today;
      dateTime1 = dateTime1.AddYears(-1);
      DateTime dateTime2 = dateTime1.AddMonths(1);
      dtpTo.Value = dateTime2;
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

    private DataView ProductsDataview
    {
      get
      {
        return this._ProductsDataview;
      }
      set
      {
        this._ProductsDataview = value;
        this._ProductsDataview.AllowNew = false;
        this._ProductsDataview.AllowEdit = false;
        this._ProductsDataview.AllowDelete = false;
        this._ProductsDataview.Table.TableName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
        this.dgProductsLastGSR.DataSource = (object) this.ProductsDataview;
      }
    }

    private DataRow SelectedProductDataRow
    {
      get
      {
        return this.dgProductsLastGSR.CurrentRowIndex != -1 ? this.ProductsDataview[this.dgProductsLastGSR.CurrentRowIndex].Row : (DataRow) null;
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

    private void SetupTimesheetsDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgProductsLastGSR.TableStyles[0];
      DataGridBoolColumn dataGridBoolColumn1 = new DataGridBoolColumn();
      dataGridBoolColumn1.HeaderText = "";
      dataGridBoolColumn1.MappingName = "Tick";
      dataGridBoolColumn1.ReadOnly = true;
      dataGridBoolColumn1.Width = 25;
      dataGridBoolColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn1);
      DataGridBoolColumn dataGridBoolColumn2 = new DataGridBoolColumn();
      dataGridBoolColumn2.HeaderText = "Email?";
      dataGridBoolColumn2.MappingName = "Email";
      dataGridBoolColumn2.ReadOnly = true;
      dataGridBoolColumn2.Width = 75;
      dataGridBoolColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn2);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Last GSR Date";
      dataGridLabelColumn1.MappingName = "VisitDate";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 75;
      dataGridLabelColumn1.NullText = "Not Done";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yyyy";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Due Date";
      dataGridLabelColumn2.MappingName = "DueDate";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "Not Done";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Appliance";
      dataGridLabelColumn3.MappingName = "Appliance";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Property";
      dataGridLabelColumn4.MappingName = "Site";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 200;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Tenant";
      dataGridLabelColumn5.MappingName = "Tenant";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Serial";
      dataGridLabelColumn6.MappingName = "SerialNum";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 70;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Gasway Ref";
      dataGridLabelColumn7.MappingName = "BoughtFrom";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 70;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      BitToStringDescriptionColumn descriptionColumn1 = new BitToStringDescriptionColumn();
      descriptionColumn1.Format = "";
      descriptionColumn1.FormatInfo = (IFormatProvider) null;
      descriptionColumn1.HeaderText = "Active";
      descriptionColumn1.MappingName = "Active";
      descriptionColumn1.ReadOnly = true;
      descriptionColumn1.Width = 70;
      descriptionColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) descriptionColumn1);
      BitToStringDescriptionColumn descriptionColumn2 = new BitToStringDescriptionColumn();
      descriptionColumn2.Format = "";
      descriptionColumn2.FormatInfo = (IFormatProvider) null;
      descriptionColumn2.HeaderText = "Tenants Appliance";
      descriptionColumn2.MappingName = "TenantsAppliance";
      descriptionColumn2.ReadOnly = true;
      descriptionColumn2.Width = 100;
      descriptionColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) descriptionColumn2);
      BitToStringDescriptionColumn descriptionColumn3 = new BitToStringDescriptionColumn();
      descriptionColumn3.Format = "";
      descriptionColumn3.FormatInfo = (IFormatProvider) null;
      descriptionColumn3.HeaderText = "On Contract";
      descriptionColumn3.MappingName = "OnContract";
      descriptionColumn3.ReadOnly = true;
      descriptionColumn3.Width = 75;
      descriptionColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) descriptionColumn3);
      BitToStringDescriptionColumn descriptionColumn4 = new BitToStringDescriptionColumn();
      descriptionColumn4.Format = "";
      descriptionColumn4.FormatInfo = (IFormatProvider) null;
      descriptionColumn4.HeaderText = "Printed";
      descriptionColumn4.MappingName = "Printed";
      descriptionColumn4.ReadOnly = true;
      descriptionColumn4.Width = 75;
      descriptionColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) descriptionColumn4);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Customer";
      dataGridLabelColumn8.MappingName = "CustomerName";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 75;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Contact Numbers";
      dataGridLabelColumn9.MappingName = "ContactNumbers";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 75;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "EmailAddress";
      dataGridLabelColumn10.MappingName = "EmailAddress";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 75;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridBoolColumn dataGridBoolColumn3 = new DataGridBoolColumn();
      dataGridBoolColumn3.HeaderText = "Contact Made";
      dataGridBoolColumn3.MappingName = "OtherContactMade";
      dataGridBoolColumn3.ReadOnly = true;
      dataGridBoolColumn3.Width = 75;
      dataGridBoolColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
      this.dgProductsLastGSR.TableStyles.Add(tableStyle);
    }

    private void FRMEngineerTimesheetReport_Load(object sender, EventArgs e)
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

    private void btnFilter_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      this.PopulateDatagrid();
      Cursor.Current = Cursors.Default;
    }

    private void btnPrintGSRReminders_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      this.pbStatus.Value = 0;
      this.pbStatus.Maximum = checked (((DataView) this.dgProductsLastGSR.DataSource).Count + 5);
      DataView dataView = new DataView();
      dataView.Table = this.ProductsDataview.Table;
      dataView.RowFilter = "tick = 1";
      DataTable dataTable = new DataTable();
      DataTable table = this.ProductsDataview.Table.Clone();
      IEnumerator enumerator;
      try
      {
        enumerator = dataView.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator.Current;
          DataRow row = table.NewRow();
          row["AssetID"] = RuntimeHelpers.GetObjectValue(current["AssetID"]);
          row["VisitDate"] = RuntimeHelpers.GetObjectValue(current["VisitDate"]);
          row["Appliance"] = RuntimeHelpers.GetObjectValue(current["Appliance"]);
          row["Site"] = RuntimeHelpers.GetObjectValue(current["Site"]);
          row["Tenant"] = RuntimeHelpers.GetObjectValue(current["Tenant"]);
          row["Address1"] = RuntimeHelpers.GetObjectValue(current["Address1"]);
          row["Address2"] = RuntimeHelpers.GetObjectValue(current["Address2"]);
          row["Address3"] = RuntimeHelpers.GetObjectValue(current["Address3"]);
          row["Postcode"] = RuntimeHelpers.GetObjectValue(current["Postcode"]);
          row["SerialNum"] = RuntimeHelpers.GetObjectValue(current["SerialNum"]);
          row["CustomerName"] = RuntimeHelpers.GetObjectValue(current["CustomerName"]);
          row["Active"] = RuntimeHelpers.GetObjectValue(current["Active"]);
          row["TenantsAppliance"] = RuntimeHelpers.GetObjectValue(current["TenantsAppliance"]);
          row["BoughtFrom"] = RuntimeHelpers.GetObjectValue(current["BoughtFrom"]);
          row["SiteID"] = RuntimeHelpers.GetObjectValue(current["SiteID"]);
          row["CustomerID"] = RuntimeHelpers.GetObjectValue(current["CustomerID"]);
          row["DueDate"] = RuntimeHelpers.GetObjectValue(current["DueDate"]);
          row["Email"] = RuntimeHelpers.GetObjectValue(current["Email"]);
          row["EmailAddress"] = RuntimeHelpers.GetObjectValue(current["EmailAddress"]);
          table.Rows.Add(row);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) new DataView(table),
        (object) this
      }, "GSR Reminder Letter", Enums.SystemDocumentType.GSRDue, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.MoveProgressOn(true);
      this.pbStatus.Value = 0;
      this.PopulateDatagrid();
      Cursor.Current = Cursors.Default;
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theCustomer = App.DB.Customer.Customer_Get(integer);
    }

    private void dg_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgProductsLastGSR.HitTest(e.X, e.Y);
      if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
      {
        if (hitTestInfo.Column == 0)
        {
          if (this.SelectedProductDataRow == null)
            return;
          this.dgProductsLastGSR[this.dgProductsLastGSR.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgProductsLastGSR[this.dgProductsLastGSR.CurrentRowIndex, 0]);
        }
        if (hitTestInfo.Column == 1)
        {
          if (this.SelectedProductDataRow == null)
            return;
          this.dgProductsLastGSR[this.dgProductsLastGSR.CurrentRowIndex, 1] = (object) !Conversions.ToBoolean(this.dgProductsLastGSR[this.dgProductsLastGSR.CurrentRowIndex, 1]);
        }
        if (hitTestInfo.Column == 14)
        {
          bool flag = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["OtherContactMade"]));
          this.SelectedProductDataRow["OtherContactMade"] = (object) flag;
          int integer = Conversions.ToInteger(App.DB.ExecuteScalar("Select Count(*) from tblPrintedGSRLetters where CONVERT(DATE,DateDue) = CONVERT(DATE,'" + Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["DueDate"])).ToString("yyyy-MM-dd") + "') AND AssetID = " + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["AssetID"]))), true, false));
          int num = !flag ? 0 : 1;
          if (integer == 0)
            App.DB.EngineerVisitAssetWorkSheet.PrintedGSRLettersInsert(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["AssetID"])), Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["DueDate"])), true);
          else
            App.DB.ExecuteScalar("UPDATE tblprintedGSRLetters set OtherContactMade = " + Conversions.ToString(num) + " where CONVERT(DATE,DateDue) = CONVERT(DATE,'" + Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["DueDate"])).ToString("yyyy-MM-dd") + "') AND AssetID = " + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["AssetID"]))), true, false);
        }
      }
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      this.ProductsDataview.AllowEdit = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this.ProductsDataview.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRowView) enumerator.Current)["tick"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.ProductsDataview.AllowEdit = false;
    }

    private void btnUnselect_Click(object sender, EventArgs e)
    {
      this.ProductsDataview.AllowEdit = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this.ProductsDataview.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRowView) enumerator.Current)["tick"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.ProductsDataview.AllowEdit = false;
    }

    private void btnEmailAll_Click(object sender, EventArgs e)
    {
      this.ProductsDataview.AllowEdit = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this.ProductsDataview.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRowView) enumerator.Current)["email"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.ProductsDataview.AllowEdit = false;
    }

    private void btnEmailNone_Click(object sender, EventArgs e)
    {
      this.ProductsDataview.AllowEdit = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this.ProductsDataview.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRowView) enumerator.Current)["email"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.ProductsDataview.AllowEdit = false;
    }

    public void PopulateDatagrid()
    {
      try
      {
        Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboRegion));
        int customerId = 0;
        if (this.theCustomer != null)
          customerId = this.theCustomer.CustomerID;
        int onContract = 0;
        string Left = Combo.get_GetSelectedItemValue(this.cboContract);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "On Contract", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Not On Contract", false) == 0)
            onContract = 2;
        }
        else
          onContract = 1;
        this.ProductsDataview = App.DB.EngineerVisitAssetWorkSheet.Products_LastGSRDone(this.dtpFrom.Value, this.dtpTo.Value, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboRegion)), customerId, onContract, this.chkIncludeTenantsAssets.Checked, this.chkNotPrinted.Checked);
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
      this.theCustomer = (FSM.Entity.Customers.Customer) null;
      this.dtpFrom.Value = DateAndTime.Today.AddYears(-1);
      DateTimePicker dtpTo = this.dtpTo;
      DateTime dateTime1 = DateAndTime.Today;
      dateTime1 = dateTime1.AddYears(-1);
      DateTime dateTime2 = dateTime1.AddMonths(1);
      dtpTo.Value = dateTime2;
      this.grpFilter.Enabled = true;
      ComboBox cboContract = this.cboContract;
      Combo.SetSelectedComboItem_By_Value(ref cboContract, Conversions.ToString(0));
      this.cboContract = cboContract;
      this.chkIncludeTenantsAssets.Checked = false;
      this.chkNotPrinted.Checked = true;
    }

    public void Export()
    {
      DataTable datatableIn = new DataTable();
      datatableIn.Columns.Add(new DataColumn("Visit Date"));
      datatableIn.Columns.Add(new DataColumn("Appliance"));
      datatableIn.Columns.Add(new DataColumn("Customer"));
      datatableIn.Columns.Add(new DataColumn("Tenant"));
      datatableIn.Columns.Add(new DataColumn("Address1"));
      datatableIn.Columns.Add(new DataColumn("Address2"));
      datatableIn.Columns.Add(new DataColumn("Address3"));
      datatableIn.Columns.Add(new DataColumn("Address4"));
      datatableIn.Columns.Add(new DataColumn("Postcode"));
      datatableIn.Columns.Add(new DataColumn("Serial"));
      datatableIn.Columns.Add(new DataColumn("GaswayRef"));
      datatableIn.Columns.Add(new DataColumn("Active"));
      datatableIn.Columns.Add(new DataColumn("TenantsAppliance"));
      datatableIn.Columns.Add(new DataColumn("OnContract"));
      datatableIn.Columns.Add(new DataColumn("Printed"));
      int num = checked (((DataView) this.dgProductsLastGSR.DataSource).Count - 1);
      int row1 = 0;
      while (row1 <= num)
      {
        this.dgProductsLastGSR.CurrentRowIndex = row1;
        DataRow row2 = datatableIn.NewRow();
        row2["Visit Date"] = DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["VisitDate"])), DateTime.MinValue) != 0 ? (object) Strings.Format((object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["VisitDate"])), "dd/MM/yyyy") : (object) "Not Done";
        row2["Appliance"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["Appliance"]);
        row2["Customer"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["CustomerName"]);
        row2["Address1"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["Address1"]);
        row2["Address2"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["Address2"]);
        row2["Address3"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["Address3"]);
        row2["Address4"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["Address4"]);
        row2["Postcode"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["Postcode"]);
        row2["Tenant"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["Tenant"]);
        row2["Serial"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["SerialNum"]);
        row2["Active"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["Active"]);
        row2["TenantsAppliance"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["TenantsAppliance"]);
        row2["GaswayRef"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["BoughtFrom"]);
        row2["OnContract"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["OnContract"]);
        row2["Printed"] = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["Printed"]);
        datatableIn.Rows.Add(row2);
        this.dgProductsLastGSR.UnSelect(row1);
        checked { ++row1; }
      }
      Exporting exporting = new Exporting(datatableIn, "Appliance GSR Report", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }

    public void MoveProgressOn(bool toMaximum = false)
    {
      if (toMaximum)
      {
        this.pbStatus.Value = this.pbStatus.Maximum;
      }
      else
      {
        ProgressBar pbStatus;
        int num = checked ((pbStatus = this.pbStatus).Value + 1);
        pbStatus.Value = num;
      }
      Application.DoEvents();
    }
  }
}
