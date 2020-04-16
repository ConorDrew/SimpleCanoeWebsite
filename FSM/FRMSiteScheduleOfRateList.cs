// Decompiled with JetBrains decompiler
// Type: FSM.FRMSiteScheduleOfRateList
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
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
  public class FRMSiteScheduleOfRateList : FRMBaseForm, IForm
  {
    private IContainer components;
    private bool _fromQuoteJob;
    private bool _fromJob;
    private DataView _DataViewToLinkTo;
    private int _IDToLinkTo;
    private DataView _dvRates;

    public FRMSiteScheduleOfRateList(
      int IDToLinkToIn,
      ref DataView DataviewToLinkToIn,
      bool FromQuoteJobIn = false,
      bool FromJobIn = false)
    {
      this.Load += new EventHandler(this.FRMSystemScheduleOfRate_Load);
      this._IDToLinkTo = 0;
      this.InitializeComponent();
      this.FromQuoteJob = FromQuoteJobIn;
      this.FromJob = FromJobIn;
      this.IDToLinkTo = IDToLinkToIn;
      this.DataviewToLinkTo = DataviewToLinkToIn;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpSystemScheduleOfRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgRates
    {
      get
      {
        return this._dgRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgRates_Click);
        DataGrid dgRates1 = this._dgRates;
        if (dgRates1 != null)
          dgRates1.Click -= eventHandler;
        this._dgRates = value;
        DataGrid dgRates2 = this._dgRates;
        if (dgRates2 == null)
          return;
        dgRates2.Click += eventHandler;
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

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSearch
    {
      get
      {
        return this._txtSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtSearch_TextChanged);
        TextBox txtSearch1 = this._txtSearch;
        if (txtSearch1 != null)
          txtSearch1.KeyUp -= keyEventHandler;
        this._txtSearch = value;
        TextBox txtSearch2 = this._txtSearch;
        if (txtSearch2 == null)
          return;
        txtSearch2.KeyUp += keyEventHandler;
      }
    }

    internal virtual Label lblCategory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCategory
    {
      get
      {
        return this._cboCategory;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboCategory_SelectedIndexChanged);
        ComboBox cboCategory1 = this._cboCategory;
        if (cboCategory1 != null)
          cboCategory1.SelectedIndexChanged -= eventHandler;
        this._cboCategory = value;
        ComboBox cboCategory2 = this._cboCategory;
        if (cboCategory2 == null)
          return;
        cboCategory2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Button btnDeselectAll
    {
      get
      {
        return this._btnDeselectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeselectAll_Click);
        Button btnDeselectAll1 = this._btnDeselectAll;
        if (btnDeselectAll1 != null)
          btnDeselectAll1.Click -= eventHandler;
        this._btnDeselectAll = value;
        Button btnDeselectAll2 = this._btnDeselectAll;
        if (btnDeselectAll2 == null)
          return;
        btnDeselectAll2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpSystemScheduleOfRate = new GroupBox();
      this.cboCategory = new ComboBox();
      this.lblCategory = new Label();
      this.Label1 = new Label();
      this.txtSearch = new TextBox();
      this.btnDeselectAll = new Button();
      this.btnSelectAll = new Button();
      this.btnCancel = new Button();
      this.btnAdd = new Button();
      this.dgRates = new DataGrid();
      this.grpSystemScheduleOfRate.SuspendLayout();
      this.dgRates.BeginInit();
      this.SuspendLayout();
      this.grpSystemScheduleOfRate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.cboCategory);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.lblCategory);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.Label1);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.txtSearch);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnDeselectAll);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnSelectAll);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnCancel);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.btnAdd);
      this.grpSystemScheduleOfRate.Controls.Add((Control) this.dgRates);
      this.grpSystemScheduleOfRate.Location = new System.Drawing.Point(8, 32);
      this.grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate";
      this.grpSystemScheduleOfRate.Size = new Size(1147, 569);
      this.grpSystemScheduleOfRate.TabIndex = 2;
      this.grpSystemScheduleOfRate.TabStop = false;
      this.grpSystemScheduleOfRate.Text = "Main Details";
      this.cboCategory.Cursor = Cursors.Hand;
      this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCategory.Location = new System.Drawing.Point(102, 24);
      this.cboCategory.Name = "cboCategory";
      this.cboCategory.Size = new Size(1039, 21);
      this.cboCategory.TabIndex = 40;
      this.cboCategory.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblCategory.AutoSize = true;
      this.lblCategory.Location = new System.Drawing.Point(11, 27);
      this.lblCategory.Name = "lblCategory";
      this.lblCategory.Size = new Size(60, 13);
      this.lblCategory.TabIndex = 39;
      this.lblCategory.Text = "Category";
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(11, 56);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(47, 13);
      this.Label1.TabIndex = 38;
      this.Label1.Text = "Search";
      this.txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSearch.Location = new System.Drawing.Point(102, 53);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new Size(1039, 21);
      this.txtSearch.TabIndex = 37;
      this.btnDeselectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnDeselectAll.Location = new System.Drawing.Point(112, 497);
      this.btnDeselectAll.Name = "btnDeselectAll";
      this.btnDeselectAll.Size = new Size(96, 23);
      this.btnDeselectAll.TabIndex = 36;
      this.btnDeselectAll.Text = "Deselect All";
      this.btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSelectAll.Location = new System.Drawing.Point(8, 497);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(96, 23);
      this.btnSelectAll.TabIndex = 35;
      this.btnSelectAll.Text = "Select All";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(8, 537);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 34;
      this.btnCancel.Text = "Cancel";
      this.btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAdd.Location = new System.Drawing.Point(1059, 537);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(75, 23);
      this.btnAdd.TabIndex = 33;
      this.btnAdd.Text = "Add";
      this.dgRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgRates.DataMember = "";
      this.dgRates.HeaderForeColor = SystemColors.ControlText;
      this.dgRates.Location = new System.Drawing.Point(14, 84);
      this.dgRates.Name = "dgRates";
      this.dgRates.Size = new Size(1133, 405);
      this.dgRates.TabIndex = 32;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1163, 607);
      this.Controls.Add((Control) this.grpSystemScheduleOfRate);
      this.MinimumSize = new Size(656, 504);
      this.Name = nameof (FRMSiteScheduleOfRateList);
      this.Text = "Property Schedule Of Rates List";
      this.Controls.SetChildIndex((Control) this.grpSystemScheduleOfRate, 0);
      this.grpSystemScheduleOfRate.ResumeLayout(false);
      this.grpSystemScheduleOfRate.PerformLayout();
      this.dgRates.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboCategory = this.cboCategory;
      Combo.SetUpCombo(ref cboCategory, App.DB.Picklists.GetAll(Enums.PickListTypes.ScheduleRatesCategories, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCategory = cboCategory;
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

    private DataView DataviewToLinkTo
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

    public int IDToLinkTo
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
        this._dvRates.AllowEdit = true;
        this._dvRates.AllowDelete = false;
        this._dvRates.Table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
        this.dgRates.DataSource = (object) this.RatesDataview;
      }
    }

    private DataRow SelectedRatesDataRow
    {
      get
      {
        return this.dgRates.CurrentRowIndex != -1 ? this.RatesDataview[this.dgRates.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupRatesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgRates, false);
      DataGridTableStyle tableStyle = this.dgRates.TableStyles[0];
      this.dgRates.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
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
      dataGridLabelColumn1.HeaderText = "Category";
      dataGridLabelColumn1.MappingName = "Category";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Code";
      dataGridLabelColumn2.MappingName = "Code";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 65;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Description";
      dataGridLabelColumn3.MappingName = "Description";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 670;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Time";
      dataGridLabelColumn4.MappingName = "TimeInMins";
      dataGridLabelColumn4.ReadOnly = false;
      dataGridLabelColumn4.Width = 50;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Unit Price";
      dataGridLabelColumn5.MappingName = "Price";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "D";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "Unit Qty Per Visit";
      editableTextBoxColumn.MappingName = "QtyPerVisit";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 110;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      tableStyle.MappingName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
      this.dgRates.TableStyles.Add(tableStyle);
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

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.RatesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) true;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnDeselectAll_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.RatesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void dgRates_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedRatesDataRow == null)
          return;
        this.dgRates[this.dgRates.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgRates[this.dgRates.CurrentRowIndex, 0]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      this.Add();
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void Populate()
    {
      this.RatesDataview = App.DB.CustomerScheduleOfRate.GetAll_For_SiteID(this.IDToLinkTo);
    }

    private void Add()
    {
      if (!this.DataviewToLinkTo.Table.Columns.Contains("SystemLinkID"))
        this.DataviewToLinkTo.Table.Columns.Add(new DataColumn("SystemLinkID"));
      IEnumerator enumerator;
      try
      {
        enumerator = this.RatesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["tick"], (object) true, false))
          {
            DataRow row = this.DataviewToLinkTo.Table.NewRow();
            if (!this.FromJob)
            {
              row["ScheduleOfRatesCategoryID"] = RuntimeHelpers.GetObjectValue(current["ScheduleOfRatesCategoryID"]);
              row["Category"] = RuntimeHelpers.GetObjectValue(current["Category"]);
              row["Code"] = RuntimeHelpers.GetObjectValue(current["Code"]);
              row["Description"] = RuntimeHelpers.GetObjectValue(current["Description"]);
              row["Price"] = RuntimeHelpers.GetObjectValue(current["Price"]);
              if (this.FromQuoteJob)
              {
                row["Quantity"] = RuntimeHelpers.GetObjectValue(current["QtyPerVisit"]);
                row["Total"] = (object) (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Price"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(row["Quantity"])));
                row["TimeInMins"] = RuntimeHelpers.GetObjectValue(current["TimeInMins"]);
              }
              else
                row["QtyPerVisit"] = RuntimeHelpers.GetObjectValue(current["QtyPerVisit"]);
            }
            else
            {
              row["Summary"] = RuntimeHelpers.GetObjectValue(current["Description"]);
              row["Qty"] = RuntimeHelpers.GetObjectValue(current["QtyPerVisit"]);
            }
            if (current.Table.Columns.Contains("SiteScheduleOfRateID"))
              row["RateID"] = RuntimeHelpers.GetObjectValue(current["SiteScheduleOfRateID"]);
            else if (current.Table.Columns.Contains("CustomerScheduleOfRateID"))
            {
              row["RateID"] = RuntimeHelpers.GetObjectValue(current["CustomerScheduleOfRateID"]);
              row["SystemLinkID"] = (object) 95;
            }
            this.DataviewToLinkTo.Table.Rows.Add(row);
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void RunFilter()
    {
      if (this.RatesDataview == null)
        return;
      string str1 = "(Description LIKE '%" + this.txtSearch.Text + "%' OR Code LIKE '%" + this.txtSearch.Text + "%')";
      string str2 = Combo.get_GetSelectedItemDescription(this.cboCategory);
      if (!string.IsNullOrEmpty(str2))
        str1 = str1 + " AND Category = '" + str2 + "'";
      this.RatesDataview.RowFilter = str1;
      this.dgRates.DataSource = (object) this.RatesDataview;
    }
  }
}
