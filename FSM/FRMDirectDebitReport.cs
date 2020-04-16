// Decompiled with JetBrains decompiler
// Type: FSM.FRMDirectDebitReport
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

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
  public class FRMDirectDebitReport : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvDD;

    public FRMDirectDebitReport()
    {
      this.Load += new EventHandler(this.FRMJobManager_Load);
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

    internal virtual DateTimePicker dtpTo
    {
      get
      {
        return this._dtpTo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpTo_ValueChanged);
        DateTimePicker dtpTo1 = this._dtpTo;
        if (dtpTo1 != null)
          dtpTo1.ValueChanged -= eventHandler;
        this._dtpTo = value;
        DateTimePicker dtpTo2 = this._dtpTo;
        if (dtpTo2 == null)
          return;
        dtpTo2.ValueChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpFrom
    {
      get
      {
        return this._dtpFrom;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpFrom_ValueChanged);
        DateTimePicker dtpFrom1 = this._dtpFrom;
        if (dtpFrom1 != null)
          dtpFrom1.ValueChanged -= eventHandler;
        this._dtpFrom = value;
        DateTimePicker dtpFrom2 = this._dtpFrom;
        if (dtpFrom2 == null)
          return;
        dtpFrom2.ValueChanged += eventHandler;
      }
    }

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

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgDirectDebits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobs = new GroupBox();
      this.dgDirectDebits = new DataGrid();
      this.btnExport = new Button();
      this.grpFilter = new GroupBox();
      this.Label1 = new Label();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.btnReset = new Button();
      this.grpJobs.SuspendLayout();
      this.dgDirectDebits.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.dgDirectDebits);
      this.grpJobs.Location = new System.Drawing.Point(8, 88);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(784, 368);
      this.grpJobs.TabIndex = 1;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Results";
      this.dgDirectDebits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgDirectDebits.DataMember = "";
      this.dgDirectDebits.HeaderForeColor = SystemColors.ControlText;
      this.dgDirectDebits.Location = new System.Drawing.Point(8, 21);
      this.dgDirectDebits.Name = "dgDirectDebits";
      this.dgDirectDebits.Size = new Size(768, 339);
      this.dgDirectDebits.TabIndex = 0;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 464);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 2;
      this.btnExport.Text = "Export";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(784, 56);
      this.grpFilter.TabIndex = 0;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.Label1.Location = new System.Drawing.Point(8, 25);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(120, 16);
      this.Label1.TabIndex = 5;
      this.Label1.Text = "Invoice Raise Date";
      this.dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dtpTo.Location = new System.Drawing.Point(488, 24);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(248, 21);
      this.dtpTo.TabIndex = 4;
      this.dtpFrom.Location = new System.Drawing.Point(176, 24);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(248, 21);
      this.dtpFrom.TabIndex = 2;
      this.Label9.Location = new System.Drawing.Point(440, 24);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(48, 16);
      this.Label9.TabIndex = 3;
      this.Label9.Text = "To";
      this.Label8.Location = new System.Drawing.Point(136, 25);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(48, 16);
      this.Label8.TabIndex = 1;
      this.Label8.Text = "From";
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(72, 464);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 3;
      this.btnReset.Text = "Reset";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(800, 494);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpJobs);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(808, 528);
      this.Name = nameof (FRMDirectDebitReport);
      this.Text = "Direct Debits Due";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.grpJobs.ResumeLayout(false);
      this.dgDirectDebits.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDirectDebitsDataGrid();
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

    private DataView dvDD
    {
      get
      {
        return this._dvDD;
      }
      set
      {
        this._dvDD = value;
        this._dvDD.AllowNew = false;
        this._dvDD.AllowEdit = false;
        this._dvDD.AllowDelete = false;
        this._dvDD.Table.TableName = Enums.TableNames.tblInvoiceToBeRaised.ToString();
        this.dgDirectDebits.DataSource = (object) this.dvDD;
      }
    }

    private DataRow SelectedDirectDebitDataRow
    {
      get
      {
        return this.dgDirectDebits.CurrentRowIndex != -1 ? this.dvDD[this.dgDirectDebits.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupDirectDebitsDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgDirectDebits.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Contract Ref";
      dataGridLabelColumn1.MappingName = "ContractReference";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MMM/yyyy";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Raise Date";
      dataGridLabelColumn2.MappingName = "RaiseDate";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Customer";
      dataGridLabelColumn3.MappingName = "Customer";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Amount";
      dataGridLabelColumn4.MappingName = "Amount";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Bank Name";
      dataGridLabelColumn5.MappingName = "BankName";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Sort Code";
      dataGridLabelColumn6.MappingName = "SortCode";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Account Number";
      dataGridLabelColumn7.MappingName = "AccountNumber";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblInvoiceToBeRaised.ToString();
      this.dgDirectDebits.TableStyles.Add(tableStyle);
    }

    private void FRMJobManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void dtpFrom_ValueChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void dtpTo_ValueChanged(object sender, EventArgs e)
    {
      this.RunFilter();
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
        {
          this.ResetFilters();
        }
        else
        {
          this.dvDD = (DataView) this.get_GetParameter(0);
          this.grpFilter.Enabled = false;
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
      this.dtpFrom.Value = DateAndTime.Now;
      this.dtpTo.Value = DateAndTime.Now.AddDays(7.0);
      this.grpFilter.Enabled = true;
    }

    private void RunFilter()
    {
      this.dvDD = App.DB.InvoiceToBeRaised.Invoices_GetAll_ForDirectDebitRpt(this.dtpFrom.Value, this.dtpTo.Value);
    }

    public void Export()
    {
      Exporting exporting = new Exporting(this.dvDD.Table, "Direct Debit List", "", "", (DataSet) null);
      exporting = (Exporting) null;
    }
  }
}
