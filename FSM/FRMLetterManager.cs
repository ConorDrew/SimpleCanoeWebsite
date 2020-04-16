// Decompiled with JetBrains decompiler
// Type: FSM.FRMLetterManager
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
  [DesignerGenerated]
  public class FRMLetterManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvServiceDue;
    private FSM.Entity.Customers.Customer _customer;

    public FRMLetterManager()
    {
      this.Load += new EventHandler(this.FRMJobManager_Load);
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
      this.tbMinsPerDay = new TextBox();
      this.cboLetterNumber = new ComboBox();
      this.lbMinsPerDay = new Label();
      this.Label14 = new Label();
      this.btnFilter = new Button();
      this.Label1 = new Label();
      this.dtpLetterCreateDate = new DateTimePicker();
      this.txtCustomer = new TextBox();
      this.Label4 = new Label();
      this.btnSelectAll = new Button();
      this.btnUnselect = new Button();
      this.btnGenerateLetters = new Button();
      this.grpServices.SuspendLayout();
      this.dgServicesDue.BeginInit();
      this.grpFilters.SuspendLayout();
      this.SuspendLayout();
      this.grpServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpServices.Controls.Add((Control) this.dgServicesDue);
      this.grpServices.Location = new System.Drawing.Point(12, 180);
      this.grpServices.Name = "grpServices";
      this.grpServices.Size = new Size(962, 245);
      this.grpServices.TabIndex = 3;
      this.grpServices.TabStop = false;
      this.grpServices.Text = "Services Due";
      this.dgServicesDue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgServicesDue.DataMember = "";
      this.dgServicesDue.HeaderForeColor = SystemColors.ControlText;
      this.dgServicesDue.Location = new System.Drawing.Point(8, 20);
      this.dgServicesDue.Name = "dgServicesDue";
      this.dgServicesDue.Size = new Size(946, 217);
      this.dgServicesDue.TabIndex = 14;
      this.btnResetFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnResetFilters.Location = new System.Drawing.Point(20, 431);
      this.btnResetFilters.Name = "btnResetFilters";
      this.btnResetFilters.Size = new Size(111, 23);
      this.btnResetFilters.TabIndex = 4;
      this.btnResetFilters.Text = "Reset Filters";
      this.btnResetFilters.UseVisualStyleBackColor = true;
      this.grpFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilters.Controls.Add((Control) this.tbMinsPerDay);
      this.grpFilters.Controls.Add((Control) this.cboLetterNumber);
      this.grpFilters.Controls.Add((Control) this.lbMinsPerDay);
      this.grpFilters.Controls.Add((Control) this.Label14);
      this.grpFilters.Controls.Add((Control) this.btnFilter);
      this.grpFilters.Controls.Add((Control) this.Label1);
      this.grpFilters.Controls.Add((Control) this.dtpLetterCreateDate);
      this.grpFilters.Controls.Add((Control) this.txtCustomer);
      this.grpFilters.Controls.Add((Control) this.Label4);
      this.grpFilters.Location = new System.Drawing.Point(12, 38);
      this.grpFilters.Name = "grpFilters";
      this.grpFilters.Size = new Size(962, 107);
      this.grpFilters.TabIndex = 5;
      this.grpFilters.TabStop = false;
      this.grpFilters.Text = "Filters";
      this.tbMinsPerDay.Location = new System.Drawing.Point(142, 76);
      this.tbMinsPerDay.Name = "tbMinsPerDay";
      this.tbMinsPerDay.Size = new Size(53, 21);
      this.tbMinsPerDay.TabIndex = 5;
      this.tbMinsPerDay.Text = "400";
      this.cboLetterNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboLetterNumber.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLetterNumber.Location = new System.Drawing.Point(415, 49);
      this.cboLetterNumber.Name = "cboLetterNumber";
      this.cboLetterNumber.Size = new Size(324, 21);
      this.cboLetterNumber.TabIndex = 41;
      this.lbMinsPerDay.AutoSize = true;
      this.lbMinsPerDay.Location = new System.Drawing.Point(6, 79);
      this.lbMinsPerDay.Name = "lbMinsPerDay";
      this.lbMinsPerDay.Size = new Size(132, 13);
      this.lbMinsPerDay.TabIndex = 4;
      this.lbMinsPerDay.Text = "Working Mins Per Day";
      this.Label14.Location = new System.Drawing.Point(351, 53);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(96, 16);
      this.Label14.TabIndex = 40;
      this.Label14.Text = "Letter No.";
      this.btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFilter.Location = new System.Drawing.Point(879, 74);
      this.btnFilter.Name = "btnFilter";
      this.btnFilter.Size = new Size(75, 23);
      this.btnFilter.TabIndex = 30;
      this.btnFilter.Text = "Filter";
      this.btnFilter.UseVisualStyleBackColor = true;
      this.Label1.Location = new System.Drawing.Point(6, 55);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(130, 16);
      this.Label1.TabIndex = 29;
      this.Label1.Text = "Letter Create Date";
      this.dtpLetterCreateDate.Location = new System.Drawing.Point(142, 50);
      this.dtpLetterCreateDate.Name = "dtpLetterCreateDate";
      this.dtpLetterCreateDate.Size = new Size(200, 21);
      this.dtpLetterCreateDate.TabIndex = 28;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(142, 22);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(774, 21);
      this.txtCustomer.TabIndex = 25;
      this.Label4.Location = new System.Drawing.Point(6, 23);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 16);
      this.Label4.TabIndex = 27;
      this.Label4.Text = "Customer";
      this.btnSelectAll.Location = new System.Drawing.Point(12, 151);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(75, 23);
      this.btnSelectAll.TabIndex = 6;
      this.btnSelectAll.Text = "Select All";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.btnUnselect.Location = new System.Drawing.Point(93, 151);
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
      this.btnGenerateLetters.Text = "Generate Letters";
      this.btnGenerateLetters.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(986, 466);
      this.Controls.Add((Control) this.btnGenerateLetters);
      this.Controls.Add((Control) this.btnUnselect);
      this.Controls.Add((Control) this.btnSelectAll);
      this.Controls.Add((Control) this.grpFilters);
      this.Controls.Add((Control) this.btnResetFilters);
      this.Controls.Add((Control) this.grpServices);
      this.Name = nameof (FRMLetterManager);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Letter Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpServices, 0);
      this.Controls.SetChildIndex((Control) this.btnResetFilters, 0);
      this.Controls.SetChildIndex((Control) this.grpFilters, 0);
      this.Controls.SetChildIndex((Control) this.btnSelectAll, 0);
      this.Controls.SetChildIndex((Control) this.btnUnselect, 0);
      this.Controls.SetChildIndex((Control) this.btnGenerateLetters, 0);
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
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgServicesDue_MouseUp);
        DataGrid dgServicesDue1 = this._dgServicesDue;
        if (dgServicesDue1 != null)
          dgServicesDue1.MouseUp -= mouseEventHandler;
        this._dgServicesDue = value;
        DataGrid dgServicesDue2 = this._dgServicesDue;
        if (dgServicesDue2 == null)
          return;
        dgServicesDue2.MouseUp += mouseEventHandler;
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

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboLetterNumber = this.cboLetterNumber;
      Combo.SetUpCombo(ref cboLetterNumber, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboLetterNumber = cboLetterNumber;
      this.ResetFilters();
      this.SetupLettersDataGrid();
      this.PopulateDatagrid();
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

    public FSM.Entity.Customers.Customer Customer
    {
      get
      {
        return this._customer;
      }
      set
      {
        this._customer = value;
        if (this._customer != null)
          this.txtCustomer.Text = this._customer.Name + " (A/C No : " + this._customer.AccountNumber + ")";
        else
          this.txtCustomer.Text = "";
      }
    }

    private void SetupLettersDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgServicesDue.TableStyles[0];
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
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 80;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "SiteFuel";
      dataGridLabelColumn2.MappingName = "SiteFuel";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Name";
      dataGridLabelColumn3.MappingName = "Name";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Address1";
      dataGridLabelColumn4.MappingName = "Address1";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Address2";
      dataGridLabelColumn5.MappingName = "Address2";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 150;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Address3";
      dataGridLabelColumn6.MappingName = "Address3";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 150;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Postcode";
      dataGridLabelColumn7.MappingName = "Postcode";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 150;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "dd/MM/yyyy";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Last Service Date";
      dataGridLabelColumn8.MappingName = "LastServiceDate";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 150;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DueDateColourColumn dateColourColumn = new DueDateColourColumn();
      dateColourColumn.Format = "dddd dd/MM/yyyy";
      dateColourColumn.FormatInfo = (IFormatProvider) null;
      dateColourColumn.HeaderText = "Due Date";
      dateColourColumn.MappingName = "NextVisitDate";
      dateColourColumn.ReadOnly = true;
      dateColourColumn.Width = 150;
      dateColourColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dateColourColumn);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "ServiceDue";
      this.dgServicesDue.TableStyles.Add(tableStyle);
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
      this.btnGenerateLetters.Enabled = true;
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      this.ServiceDueDataview.AllowEdit = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this.ServiceDueDataview.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRowView) enumerator.Current)["Tick"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.ServiceDueDataview.Table.AcceptChanges();
      this.ServiceDueDataview.AllowEdit = false;
    }

    private void btnUnselect_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.ServiceDueDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["Tick"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnGenerateLetters_Click(object sender, EventArgs e)
    {
      this.GenerateLetters();
    }

    private void dgServicesDue_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgServicesDue.HitTest(e.X, e.Y);
      if (hitTestInfo.Type != DataGrid.HitTestType.Cell || hitTestInfo.Column != 0)
        return;
      this.SelectedServiceDueDataRow["Tick"] = (object) !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedServiceDueDataRow["tick"]));
    }

    public void PopulateDatagrid()
    {
      try
      {
        DataTable dataTable1 = new DataTable();
        this.ServiceDueDataview = this.Customer.CustomerID != -1 ? App.DB.LetterManager.Letter1Manager(Conversions.ToDate(Strings.Format((object) this.GetTheFriday(this.dtpLetterCreateDate.Value), "dd/MM/yyyy")), this.Customer.CustomerID, -309) : App.DB.LetterManager.Letter1Manager(Conversions.ToDate(Strings.Format((object) this.GetTheFriday(this.dtpLetterCreateDate.Value), "dd/MM/yyyy")), this.Customer.CustomerID, -323);
        DataTable dataTable2 = this.Customer.CustomerID != -1 ? App.DB.LetterManager.Letter2Manager(Conversions.ToDate(Strings.Format((object) this.dtpLetterCreateDate.Value, "dd/MM/yyyy")), this.Customer.CustomerID, -330) : App.DB.LetterManager.Letter2Manager(Conversions.ToDate(Strings.Format((object) this.dtpLetterCreateDate.Value, "dd/MM/yyyy")), this.Customer.CustomerID, -337);
        IEnumerator enumerator1;
        try
        {
          enumerator1 = dataTable2.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            DataRow row = this.ServiceDueDataview.Table.NewRow();
            row["Tick"] = RuntimeHelpers.GetObjectValue(current["Tick"]);
            row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
            row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
            row["Address1"] = RuntimeHelpers.GetObjectValue(current["Address1"]);
            row["Address2"] = RuntimeHelpers.GetObjectValue(current["Address2"]);
            row["Address3"] = RuntimeHelpers.GetObjectValue(current["Address3"]);
            row["Address4"] = RuntimeHelpers.GetObjectValue(current["Address4"]);
            row["Address5"] = RuntimeHelpers.GetObjectValue(current["Address5"]);
            row["Postcode"] = RuntimeHelpers.GetObjectValue(current["Postcode"]);
            row["SiteID"] = RuntimeHelpers.GetObjectValue(current["SiteID"]);
            row["SolidFuel"] = RuntimeHelpers.GetObjectValue(current["SolidFuel"]);
            row["Notes"] = RuntimeHelpers.GetObjectValue(current["Notes"]);
            row["PropertyVoid"] = RuntimeHelpers.GetObjectValue(current["PropertyVoid"]);
            row["LastServiceDate"] = RuntimeHelpers.GetObjectValue(current["LastServiceDate"]);
            row["NextVisitDate"] = RuntimeHelpers.GetObjectValue(current["NextVisitDate"]);
            row["SiteFuel"] = RuntimeHelpers.GetObjectValue(current["SiteFuel"]);
            this.ServiceDueDataview.Table.Rows.Add(row);
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        DataTable dataTable3 = App.DB.LetterManager.Letter3Manager(Conversions.ToDate(Strings.Format((object) this.dtpLetterCreateDate.Value, "yyyy-MM-dd")), this.Customer.CustomerID);
        IEnumerator enumerator2;
        if (this.Customer.CustomerID == 2846)
        {
          try
          {
            enumerator2 = dataTable3.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              DataRow row = this.ServiceDueDataview.Table.NewRow();
              row["Tick"] = RuntimeHelpers.GetObjectValue(current["Tick"]);
              row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
              row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
              row["Address1"] = RuntimeHelpers.GetObjectValue(current["Address1"]);
              row["Address2"] = RuntimeHelpers.GetObjectValue(current["Address2"]);
              row["Address3"] = RuntimeHelpers.GetObjectValue(current["Address3"]);
              row["Address4"] = RuntimeHelpers.GetObjectValue(current["Address4"]);
              row["Address5"] = RuntimeHelpers.GetObjectValue(current["Address5"]);
              row["Postcode"] = RuntimeHelpers.GetObjectValue(current["Postcode"]);
              row["SiteID"] = RuntimeHelpers.GetObjectValue(current["SiteID"]);
              row["SolidFuel"] = RuntimeHelpers.GetObjectValue(current["SolidFuel"]);
              row["Notes"] = RuntimeHelpers.GetObjectValue(current["Notes"]);
              row["PropertyVoid"] = RuntimeHelpers.GetObjectValue(current["PropertyVoid"]);
              row["LastServiceDate"] = RuntimeHelpers.GetObjectValue(current["LastServiceDate"]);
              row["NextVisitDate"] = RuntimeHelpers.GetObjectValue(current["NextVisitDate"]);
              row["SiteFuel"] = RuntimeHelpers.GetObjectValue(current["SiteFuel"]);
              this.ServiceDueDataview.Table.Rows.Add(row);
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboLetterNumber), "0", false) > 0U)
          this.ServiceDueDataview.RowFilter = "Type ='" + Combo.get_GetSelectedItemDescription(this.cboLetterNumber) + "'";
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

    private DateTime GetTheFriday(DateTime DateIn)
    {
      DateTime dateTime;
      switch (DateIn.DayOfWeek)
      {
        case DayOfWeek.Sunday:
          dateTime = DateIn.AddDays(5.0);
          break;
        case DayOfWeek.Monday:
          dateTime = DateIn.AddDays(4.0);
          break;
        case DayOfWeek.Tuesday:
          dateTime = DateIn.AddDays(3.0);
          break;
        case DayOfWeek.Wednesday:
          dateTime = DateIn.AddDays(2.0);
          break;
        case DayOfWeek.Thursday:
          dateTime = DateIn.AddDays(1.0);
          break;
        case DayOfWeek.Friday:
          dateTime = DateIn;
          break;
        case DayOfWeek.Saturday:
          dateTime = DateIn.AddDays(6.0);
          break;
      }
      return dateTime;
    }

    private void ResetFilters()
    {
      ComboBox cboLetterNumber = this.cboLetterNumber;
      Combo.SetSelectedComboItem_By_Value(ref cboLetterNumber, Conversions.ToString(0));
      this.cboLetterNumber = cboLetterNumber;
      this.dtpLetterCreateDate.Value = DateAndTime.Now;
      this.Customer = App.DB.Customer.Customer_Get(2846);
    }

    private void GenerateLetters()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        DateTime now1 = DateAndTime.Now;
        Printing printing = new Printing((object) new ArrayList()
        {
          (object) this.SelectedServiceDueDataRow.Table.Select("Tick=1")
        }, "NCC Service Letters", Enums.SystemDocumentType.ServiceLetters, true, 0, false, Conversions.ToInteger(this.tbMinsPerDay.Text), this.Customer.CustomerID, Conversions.ToDate(this.dtpLetterCreateDate.Text), (DataTable) null);
        this.PopulateDatagrid();
        DateTime now2 = DateAndTime.Now;
        int num = (int) Interaction.MsgBox((object) ("Start: " + Conversions.ToString(now1) + "\r\nEnd: " + Conversions.ToString(now2)), MsgBoxStyle.OkOnly, (object) null);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }
  }
}
