// Decompiled with JetBrains decompiler
// Type: FSM.FRMVATRates
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using FSM.Entity.VATRatess;
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
  public class FRMVATRates : FRMBaseForm, IForm
  {
    private IContainer components;
    private Enums.FormState _pageState;
    private DataView _dvRates;

    public FRMVATRates()
    {
      this.Load += new EventHandler(this.FRMVATRates_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddNew
    {
      get
      {
        return this._btnAddNew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNew_Click);
        Button btnAddNew1 = this._btnAddNew;
        if (btnAddNew1 != null)
          btnAddNew1.Click -= eventHandler;
        this._btnAddNew = value;
        Button btnAddNew2 = this._btnAddNew;
        if (btnAddNew2 == null)
          return;
        btnAddNew2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgVATRates
    {
      get
      {
        return this._dgVATRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgVATRates_Click);
        DataGrid dgVatRates1 = this._dgVATRates;
        if (dgVatRates1 != null)
          dgVatRates1.Click -= eventHandler;
        this._dgVATRates = value;
        DataGrid dgVatRates2 = this._dgVATRates;
        if (dgVatRates2 == null)
          return;
        dgVatRates2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVATRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpVATDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.btnAddNew = new Button();
      this.dgVATRates = new DataGrid();
      this.grpDetails = new GroupBox();
      this.dtpVATDate = new DateTimePicker();
      this.Label1 = new Label();
      this.txtVATRate = new TextBox();
      this.Label2 = new Label();
      this.btnSave = new Button();
      this.Label3 = new Label();
      this.txtCode = new TextBox();
      this.GroupBox1.SuspendLayout();
      this.dgVATRates.BeginInit();
      this.grpDetails.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.btnAddNew);
      this.GroupBox1.Controls.Add((Control) this.dgVATRates);
      this.GroupBox1.Location = new System.Drawing.Point(8, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(512, 328);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "VAT Rates";
      this.btnAddNew.AccessibleDescription = "Add new item";
      this.btnAddNew.Cursor = Cursors.Hand;
      this.btnAddNew.UseVisualStyleBackColor = true;
      this.btnAddNew.Location = new System.Drawing.Point(8, 16);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.Size = new Size(48, 24);
      this.btnAddNew.TabIndex = 0;
      this.btnAddNew.Text = "New";
      this.dgVATRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgVATRates.DataMember = "";
      this.dgVATRates.HeaderForeColor = SystemColors.ControlText;
      this.dgVATRates.Location = new System.Drawing.Point(8, 52);
      this.dgVATRates.Name = "dgVATRates";
      this.dgVATRates.Size = new Size(496, 268);
      this.dgVATRates.TabIndex = 1;
      this.grpDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpDetails.Controls.Add((Control) this.txtCode);
      this.grpDetails.Controls.Add((Control) this.Label3);
      this.grpDetails.Controls.Add((Control) this.dtpVATDate);
      this.grpDetails.Controls.Add((Control) this.Label1);
      this.grpDetails.Controls.Add((Control) this.txtVATRate);
      this.grpDetails.Controls.Add((Control) this.Label2);
      this.grpDetails.Controls.Add((Control) this.btnSave);
      this.grpDetails.Location = new System.Drawing.Point(8, 374);
      this.grpDetails.Name = "grpDetails";
      this.grpDetails.Size = new Size(512, 106);
      this.grpDetails.TabIndex = 1;
      this.grpDetails.TabStop = false;
      this.grpDetails.Text = "Details";
      this.dtpVATDate.Location = new System.Drawing.Point(120, 48);
      this.dtpVATDate.Name = "dtpVATDate";
      this.dtpVATDate.Size = new Size(328, 21);
      this.dtpVATDate.TabIndex = 1;
      this.Label1.Location = new System.Drawing.Point(8, 48);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(120, 23);
      this.Label1.TabIndex = 8;
      this.Label1.Text = "From Date";
      this.txtVATRate.Location = new System.Drawing.Point(120, 24);
      this.txtVATRate.MaxLength = (int) byte.MaxValue;
      this.txtVATRate.Name = "txtVATRate";
      this.txtVATRate.Size = new Size(328, 21);
      this.txtVATRate.TabIndex = 0;
      this.Label2.Location = new System.Drawing.Point(8, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(120, 23);
      this.Label2.TabIndex = 5;
      this.Label2.Text = "Rate Amount (%)";
      this.btnSave.AccessibleDescription = "Save item";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Cursor = Cursors.Hand;
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.ImageIndex = 1;
      this.btnSave.Location = new System.Drawing.Point(456, 74);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(48, 23);
      this.btnSave.TabIndex = 3;
      this.btnSave.Text = "Save";
      this.Label3.Location = new System.Drawing.Point(8, 72);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(120, 23);
      this.Label3.TabIndex = 10;
      this.Label3.Text = "Code";
      this.txtCode.Location = new System.Drawing.Point(120, 75);
      this.txtCode.MaxLength = 5;
      this.txtCode.Name = "txtCode";
      this.txtCode.Size = new Size(328, 21);
      this.txtCode.TabIndex = 2;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(528, 486);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.grpDetails);
      this.Name = nameof (FRMVATRates);
      this.Text = "VAT Rates";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpDetails, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.dgVATRates.EndInit();
      this.grpDetails.ResumeLayout(false);
      this.grpDetails.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupRatesDataGrid();
      this.PopulateDatagrid(Enums.FormState.Insert);
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

    private Enums.FormState PageState
    {
      get
      {
        return this._pageState;
      }
      set
      {
        this._pageState = value;
      }
    }

    private DataView RatesDataview
    {
      get
      {
        return this._dvRates;
      }
      set
      {
        this._dvRates = value;
        this._dvRates.AllowNew = false;
        this._dvRates.AllowEdit = false;
        this._dvRates.AllowDelete = false;
        this._dvRates.Table.TableName = Enums.TableNames.tblVATRates.ToString();
        this.dgVATRates.DataSource = (object) this.RatesDataview;
      }
    }

    private DataRow SelectedVATRateDataRow
    {
      get
      {
        return this.dgVATRates.CurrentRowIndex != -1 ? this.RatesDataview[this.dgVATRates.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupRatesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgVATRates, false);
      DataGridTableStyle tableStyle = this.dgVATRates.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "VAT Rate";
      dataGridLabelColumn1.MappingName = "VATRate";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yyyy";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Date Introduced";
      dataGridLabelColumn2.MappingName = "DateIntroduced";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Code";
      dataGridLabelColumn3.MappingName = "VATRateCode";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblVATRates.ToString();
      this.dgVATRates.TableStyles.Add(tableStyle);
    }

    private void SetUpPageState(Enums.FormState state)
    {
      Helper.ClearGroupBox(this.grpDetails);
      switch (state)
      {
        case Enums.FormState.Load:
          this.grpDetails.Enabled = false;
          this.btnAddNew.Enabled = false;
          this.btnSave.Enabled = false;
          break;
        case Enums.FormState.Insert:
          this.grpDetails.Enabled = true;
          this.btnAddNew.Enabled = true;
          this.btnSave.Enabled = true;
          break;
        case Enums.FormState.Update:
          this.btnAddNew.Enabled = true;
          this.grpDetails.Enabled = true;
          this.btnSave.Enabled = true;
          break;
      }
      this.PageState = state;
    }

    private void FRMVATRates_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgVATRates_Click(object sender, EventArgs e)
    {
      try
      {
        this.SetUpPageState(Enums.FormState.Update);
        if (this.SelectedVATRateDataRow != null)
        {
          this.txtVATRate.Text = Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.SelectedVATRateDataRow["VATRate"])));
          this.dtpVATDate.Value = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedVATRateDataRow["DateIntroduced"]));
          this.txtCode.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedVATRateDataRow["VATRateCode"]));
        }
        else
          this.SetUpPageState(Enums.FormState.Insert);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Item data cannot load : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      this.SetUpPageState(Enums.FormState.Insert);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void PopulateDatagrid(Enums.FormState state)
    {
      this.RatesDataview = App.DB.VATRatesSQL.VATRates_GetAll();
      this.SetUpPageState(state);
    }

    private void Save()
    {
      VATRates oVATRates = new VATRates();
      oVATRates.IgnoreExceptionsOnSetMethods = true;
      oVATRates.SetVATRate = (object) this.txtVATRate.Text;
      oVATRates.DateIntroduced = this.dtpVATDate.Value;
      oVATRates.SetVATRateCode = (object) this.txtCode.Text;
      VATRatesValidator vatRatesValidator = new VATRatesValidator();
      try
      {
        vatRatesValidator.Validate(oVATRates);
        switch (this.PageState)
        {
          case Enums.FormState.Insert:
            App.DB.VATRatesSQL.Insert(oVATRates);
            break;
          case Enums.FormState.Update:
            oVATRates.SetVATRateID = RuntimeHelpers.GetObjectValue(this.SelectedVATRateDataRow["VATRateID"]);
            App.DB.VATRatesSQL.Update(oVATRates);
            break;
        }
        this.PopulateDatagrid(Enums.FormState.Insert);
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(vatRatesValidator.CriticalMessagesString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error Saving : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }
  }
}
