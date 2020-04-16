// Decompiled with JetBrains decompiler
// Type: FSM.FRMSalesCredit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Invoiceds;
using FSM.Entity.SalesCredits;
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
  public class FRMSalesCredit : FRMBaseForm, IForm
  {
    private IContainer components;
    private bool _fromQuoteJob;
    private bool _fromJob;
    private DataView _DataViewToLinkTo;
    private DataRow[] _IDToLinkTo;
    private DataView _dvRates;

    public FRMSalesCredit(DataRow[] IDToLinkToIn, bool FromQuoteJobIn = false, bool FromJobIn = false)
    {
      this.Load += new EventHandler(this.FRMSystemScheduleOfRate_Load);
      this._IDToLinkTo = (DataRow[]) null;
      this.InitializeComponent();
      this.FromQuoteJob = FromQuoteJobIn;
      this.FromJob = FromJobIn;
      this.IDToLinkTo = IDToLinkToIn;
      ComboBox cboUser = this.cboUser;
      Combo.SetUpCombo(ref cboUser, App.DB.User.GetAll().Table, "UserID", "Fullname", Enums.ComboValues.No_Filter);
      this.cboUser = cboUser;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpSystemScheduleOfRate
    {
      get
      {
        return this._grpSystemScheduleOfRate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.grpSystemScheduleOfRate_Enter);
        GroupBox systemScheduleOfRate1 = this._grpSystemScheduleOfRate;
        if (systemScheduleOfRate1 != null)
          systemScheduleOfRate1.Enter -= eventHandler;
        this._grpSystemScheduleOfRate = value;
        GroupBox systemScheduleOfRate2 = this._grpSystemScheduleOfRate;
        if (systemScheduleOfRate2 == null)
          return;
        systemScheduleOfRate2.Enter += eventHandler;
      }
    }

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        Button btnAdd1 = this._btnAdd;
        if (btnAdd1 != null)
          btnAdd1.Click -= eventHandler;
        this._btnAdd = value;
        Button btnAdd2 = this._btnAdd;
        if (btnAdd2 == null)
          return;
        btnAdd2.Click += eventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtReason { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAfter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCredit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInvoiced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtExRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgRates
    {
      get
      {
        return this._dgRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DataGridViewCellEventHandler cellEventHandler = new DataGridViewCellEventHandler(this.dgvParts_CellEndEdit);
        DataGridView dgRates1 = this._dgRates;
        if (dgRates1 != null)
          dgRates1.CellEndEdit -= cellEventHandler;
        this._dgRates = value;
        DataGridView dgRates2 = this._dgRates;
        if (dgRates2 == null)
          return;
        dgRates2.CellEndEdit += cellEventHandler;
      }
    }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker DateTimePicker1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNominal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        Button btnCancel1 = this._btnCancel;
        if (btnCancel1 != null)
          btnCancel1.Click -= eventHandler;
        this._btnCancel = value;
        Button btnCancel2 = this._btnCancel;
        if (btnCancel2 == null)
          return;
        btnCancel2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpSystemScheduleOfRate = new GroupBox();
      this.Label7 = new Label();
      this.DateTimePicker1 = new DateTimePicker();
      this.dgRates = new DataGridView();
      this.txtAfter = new TextBox();
      this.txtCredit = new TextBox();
      this.txtInvoiced = new TextBox();
      this.txtExRef = new TextBox();
      this.cboUser = new ComboBox();
      this.Label1 = new Label();
      this.txtReason = new TextBox();
      this.btnCancel = new Button();
      this.btnAdd = new Button();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label5 = new Label();
      this.Label4 = new Label();
      this.Label6 = new Label();
      this.txtNominal = new TextBox();
      this.Label8 = new Label();
      this.txtDept = new TextBox();
      this.Label9 = new Label();
      this.grpSystemScheduleOfRate.SuspendLayout();
      ((ISupportInitialize) this.dgRates).BeginInit();
      this.SuspendLayout();
      this.grpSystemScheduleOfRate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtDept);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label9);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtNominal);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label8);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label7);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.DateTimePicker1);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.dgRates);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtAfter);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtCredit);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtInvoiced);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtExRef);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.cboUser);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label1);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtReason);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnCancel);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnAdd);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label3);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label2);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label5);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label4);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label6);
      this.grpSystemScheduleOfRate.Location = new System.Drawing.Point(8, 32);
      this.grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate";
      this.grpSystemScheduleOfRate.Size = new Size(632, 432);
      this.grpSystemScheduleOfRate.TabIndex = 2;
      this.grpSystemScheduleOfRate.TabStop = false;
      this.grpSystemScheduleOfRate.Text = "Credit Details";
      this.Label7.AutoSize = true;
      this.Label7.Location = new System.Drawing.Point(6, 287);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(88, 13);
      this.Label7.TabIndex = 49;
      this.Label7.Text = "Date of Credit";
      this.DateTimePicker1.Location = new System.Drawing.Point(9, 303);
      this.DateTimePicker1.Name = "DateTimePicker1";
      this.DateTimePicker1.Size = new Size(324, 21);
      this.DateTimePicker1.TabIndex = 48;
      this.dgRates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgRates.Location = new System.Drawing.Point(6, 20);
      this.dgRates.Name = "dgRates";
      this.dgRates.Size = new Size(620, 170);
      this.dgRates.TabIndex = 47;
      this.txtAfter.Location = new System.Drawing.Point(495, 306);
      this.txtAfter.Name = "txtAfter";
      this.txtAfter.ReadOnly = true;
      this.txtAfter.Size = new Size(112, 21);
      this.txtAfter.TabIndex = 45;
      this.txtCredit.Location = new System.Drawing.Point(495, 262);
      this.txtCredit.Name = "txtCredit";
      this.txtCredit.ReadOnly = true;
      this.txtCredit.Size = new Size(112, 21);
      this.txtCredit.TabIndex = 43;
      this.txtInvoiced.Location = new System.Drawing.Point(495, 221);
      this.txtInvoiced.Name = "txtInvoiced";
      this.txtInvoiced.ReadOnly = true;
      this.txtInvoiced.Size = new Size(112, 21);
      this.txtInvoiced.TabIndex = 41;
      this.txtExRef.Location = new System.Drawing.Point(233, 262);
      this.txtExRef.Name = "txtExRef";
      this.txtExRef.Size = new Size(100, 21);
      this.txtExRef.TabIndex = 39;
      this.cboUser.FormattingEnabled = true;
      this.cboUser.Location = new System.Drawing.Point(9, 221);
      this.cboUser.Name = "cboUser";
      this.cboUser.Size = new Size(324, 21);
      this.cboUser.TabIndex = 37;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(6, 332);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(110, 13);
      this.Label1.TabIndex = 36;
      this.Label1.Text = "Reason For Credit";
      this.txtReason.Location = new System.Drawing.Point(8, 350);
      this.txtReason.Multiline = true;
      this.txtReason.Name = "txtReason";
      this.txtReason.Size = new Size(611, 40);
      this.txtReason.TabIndex = 35;
      this.btnCancel.Location = new System.Drawing.Point(8, 400);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 34;
      this.btnCancel.Text = "Cancel";
      this.btnAdd.Location = new System.Drawing.Point(518, 400);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(101, 23);
      this.btnAdd.TabIndex = 33;
      this.btnAdd.Text = "Create Credit";
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(231, 246);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(44, 13);
      this.Label3.TabIndex = 40;
      this.Label3.Text = "Ex Ref";
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(6, 203);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(86, 13);
      this.Label2.TabIndex = 38;
      this.Label2.Text = "Requested By";
      this.Label5.AutoSize = true;
      this.Label5.Location = new System.Drawing.Point(505, 247);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(87, 13);
      this.Label5.TabIndex = 44;
      this.Label5.Text = "Total Credited";
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(479, 203);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(145, 13);
      this.Label4.TabIndex = 42;
      this.Label4.Text = "Total Originally Invoiced";
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(474, 287);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(150, 13);
      this.Label6.TabIndex = 46;
      this.Label6.Text = "Total Invoice after Credit";
      this.txtNominal.Location = new System.Drawing.Point(9, 263);
      this.txtNominal.Name = "txtNominal";
      this.txtNominal.Size = new Size(100, 21);
      this.txtNominal.TabIndex = 50;
      this.Label8.AutoSize = true;
      this.Label8.Location = new System.Drawing.Point(7, 247);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(53, 13);
      this.Label8.TabIndex = 51;
      this.Label8.Text = "Nominal";
      this.txtDept.Location = new System.Drawing.Point(121, 263);
      this.txtDept.Name = "txtDept";
      this.txtDept.Size = new Size(100, 21);
      this.txtDept.TabIndex = 52;
      this.Label9.AutoSize = true;
      this.Label9.Location = new System.Drawing.Point(119, 247);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(34, 13);
      this.Label9.TabIndex = 53;
      this.Label9.Text = "Dept";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(648, 470);
      this.Controls.Add((Control) this.grpSystemScheduleOfRate);
      this.MinimumSize = new Size(656, 504);
      this.Name = nameof (FRMSalesCredit);
      this.Text = "Property Schedule Of Rates List";
      this.Controls.SetChildIndex((Control) this.grpSystemScheduleOfRate, 0);
      this.grpSystemScheduleOfRate.ResumeLayout(false);
      this.grpSystemScheduleOfRate.PerformLayout();
      ((ISupportInitialize) this.dgRates).EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupRatesDataGrid();
      this.Populate();
    }

    public IUserControl LoadedControl
    {
      get
      {
        IUserControl userControl;
        return userControl;
      }
    }

    public void ResetMe(int newID)
    {
    }

    public bool FromQuoteJob
    {
      get
      {
        return this._fromQuoteJob;
      }
      set
      {
        this._fromQuoteJob = value;
      }
    }

    public bool FromJob
    {
      get
      {
        return this._fromJob;
      }
      set
      {
        this._fromJob = value;
      }
    }

    public DataView DataviewToLinkTo
    {
      get
      {
        return this._DataViewToLinkTo;
      }
      set
      {
        this._DataViewToLinkTo = value;
      }
    }

    public DataRow[] IDToLinkTo
    {
      get
      {
        return this._IDToLinkTo;
      }
      set
      {
        this._IDToLinkTo = value;
      }
    }

    public DataView RatesDataview
    {
      get
      {
        return this._dvRates;
      }
      set
      {
        this._dvRates = value;
        this._dvRates.AllowNew = false;
        this._dvRates.AllowEdit = true;
        this._dvRates.AllowDelete = false;
        this._dvRates.Table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
        this.dgRates.DataSource = (object) this.RatesDataview;
      }
    }

    private DataGridViewRow SelectedRatesDataRow
    {
      get
      {
        return this.dgRates.CurrentRow.Index != -1 ? this.dgRates.CurrentRow : (DataGridViewRow) null;
      }
    }

    public void SetupRatesDataGrid()
    {
      Helper.SetUpDataGridView(this.dgRates, false);
      this.dgRates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgRates.AutoGenerateColumns = false;
      this.dgRates.Columns.Clear();
      this.dgRates.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.FillWeight = 300f;
      viewTextBoxColumn1.HeaderText = "Address";
      viewTextBoxColumn1.DataPropertyName = "Address";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = true;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgRates.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Invoiced (Nett)";
      viewTextBoxColumn2.DataPropertyName = "Amount";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.Width = 100;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgRates.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Credit Applied (Nett)";
      viewTextBoxColumn3.DataPropertyName = "CreditApplied";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.Width = 100;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgRates.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Credit Amount (Nett)";
      viewTextBoxColumn4.DataPropertyName = "Credit";
      viewTextBoxColumn4.ReadOnly = false;
      viewTextBoxColumn4.Visible = true;
      viewTextBoxColumn4.Width = 100;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgRates.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
    }

    private void FRMSystemScheduleOfRate_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (this.Add())
      {
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
      else
      {
        int num = (int) App.ShowMessage("Please ensure the credit value is greater than zero and equal or less to the original invoice value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.btnAdd.Enabled = true;
      }
    }

    private void Populate()
    {
      this.RatesDataview = App.DB.SalesCredit.InvoicedLines_GetAll_ByInvoicedIDRows(this.IDToLinkTo);
      this.RatesDataview.Table.Columns.Add("SalesCreditID");
      this.RatesDataview.Table.Columns.Add("CreditReference");
      this.txtNominal.Text = Conversions.ToString(this.RatesDataview.Table.Rows[0]["NominalCode"]);
      this.txtDept.Text = Conversions.ToString(this.RatesDataview.Table.Rows[0]["Department"]);
    }

    private bool Add()
    {
      this.btnAdd.Enabled = false;
      bool flag = false;
      JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.CONSOLIDATION | Enums.JobDefinition.Contract);
      if (this.txtAfter.Text.Trim().Length == 0)
        return false;
      double num = Helper.MakeDoubleValid((object) this.txtAfter.Text.Trim());
      IEnumerator enumerator;
      try
      {
        enumerator = this.RatesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["Credit"], (object) 0, false) && num >= 0.0)
          {
            flag = true;
            SalesCredit salesCredit = new SalesCredit();
            App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "INSERT INTO tblInvoicedLinesCredit (InvoicedLineID,CreditAmount) VALUES (", current["InvoicedLineID"]), (object) ","), current["Credit"]), (object) ")")), true, false);
            Invoiced invoiced = App.DB.Invoiced.Invoiced_Get(Conversions.ToInteger(current["InvoicedID"]));
            SalesCredit oSalesCredited = new SalesCredit();
            oSalesCredited.SetAmountCredited = RuntimeHelpers.GetObjectValue(current["Credit"]);
            oSalesCredited.SetNotes = (object) "";
            oSalesCredited.SetTaxCodeID = (object) invoiced.VATRateID;
            oSalesCredited.SetExtraRef = (object) this.txtExRef.Text;
            if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["NominalCode"])) || current["NominalCode"].ToString().Length == 0)
            {
              oSalesCredited.SetNominalCode = (object) 4900;
              oSalesCredited.SetDepartmentRef = (object) 100;
            }
            else
            {
              oSalesCredited.SetNominalCode = RuntimeHelpers.GetObjectValue(current["NominalCode"]);
              oSalesCredited.SetDepartmentRef = RuntimeHelpers.GetObjectValue(current["Department"]);
            }
            oSalesCredited.SetNominalCode = (object) this.txtNominal.Text;
            oSalesCredited.SetDepartmentRef = (object) this.txtDept.Text;
            oSalesCredited.SetInvoicedLineID = RuntimeHelpers.GetObjectValue(current["InvoicedLineID"]);
            oSalesCredited.SetAddedByUser = (object) App.loggedInUser.UserID;
            oSalesCredited.SetRequestedBy = (object) Combo.get_GetSelectedItemValue(this.cboUser);
            oSalesCredited.SetReasonForCredit = (object) this.txtReason.Text;
            oSalesCredited.SetCreditReference = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
            oSalesCredited.SetAccountNumber = RuntimeHelpers.GetObjectValue(current["AccountNumber"]);
            oSalesCredited.DateCredited = this.DateTimePicker1.Value;
            current["SalesCreditID"] = (object) App.DB.SalesCredit.Insert(oSalesCredited);
            current["CreditReference"] = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (flag && App.ShowMessage("Do you want to generate the document?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        Printing printing = new Printing((object) this.RatesDataview.Table, "Sales Credit", Enums.SystemDocumentType.SalesCredit, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      }
      return flag;
    }

    private void dgvParts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      if (this.SelectedRatesDataRow == null)
        return;
      this.DoTotals();
    }

    private void DoTotals()
    {
      this.txtCredit.Text = Conversions.ToString(0);
      this.txtInvoiced.Text = Conversions.ToString(0);
      double num = 0.0;
      IEnumerator enumerator;
      try
      {
        enumerator = ((IEnumerable) this.dgRates.Rows).GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataGridViewRow current = (DataGridViewRow) enumerator.Current;
          TextBox txtInvoiced;
          string str1 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) (txtInvoiced = this.txtInvoiced).Text, current.Cells[1].Value));
          txtInvoiced.Text = str1;
          TextBox txtCredit;
          string str2 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) (txtCredit = this.txtCredit).Text, current.Cells[3].Value));
          txtCredit.Text = str2;
          num = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current.Cells[2].Value));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.txtAfter.Text = "£" + Conversions.ToString(Conversions.ToDouble(this.txtInvoiced.Text) - (num + Helper.MakeDoubleValid((object) this.txtCredit.Text)));
      this.txtCredit.Text = "£" + this.txtCredit.Text;
      this.txtInvoiced.Text = "£" + this.txtInvoiced.Text;
    }

    private void grpSystemScheduleOfRate_Enter(object sender, EventArgs e)
    {
    }
  }
}
