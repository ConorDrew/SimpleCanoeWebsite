// Decompiled with JetBrains decompiler
// Type: FSM.UCCustomerScheduleOfRate
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.CustomerScheduleOfRates;
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
  public class UCCustomerScheduleOfRate : UCBase, IUserControl
  {
    private IContainer components;
    private Enums.TableNames _EntityToLinkTo;
    private int _IDToLinkTo;
    private DataView _dvRates;
    private Enums.FormState _pageState;
    private CustomerScheduleOfRate _currentCustomerScheduleOfRate;
    private bool _isReadOnlyMode;

    public UCCustomerScheduleOfRate(
      Enums.TableNames EntityToLinkToIn,
      int IDToLinkToIn,
      bool _readOnly = false)
    {
      this.Load += new EventHandler(this.UCCustomerScheduleOfRate_Load);
      this._IDToLinkTo = 0;
      this._currentCustomerScheduleOfRate = new CustomerScheduleOfRate();
      this.IsReadOnlyMode = _readOnly;
      this.InitializeComponent();
      this.EntityToLinkTo = EntityToLinkToIn;
      this.IDToLinkTo = IDToLinkToIn;
      this.Dock = DockStyle.Fill;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpCustomerScheduleOfRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboScheduleOfRatesCategoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblScheduleOfRatesCategoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnRemove
    {
      get
      {
        return this._btnRemove;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemove_Click);
        Button btnRemove1 = this._btnRemove;
        if (btnRemove1 != null)
          btnRemove1.Click -= eventHandler;
        this._btnRemove = value;
        Button btnRemove2 = this._btnRemove;
        if (btnRemove2 == null)
          return;
        btnRemove2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddUpdate
    {
      get
      {
        return this._btnAddUpdate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddUpdate_Click);
        Button btnAddUpdate1 = this._btnAddUpdate;
        if (btnAddUpdate1 != null)
          btnAddUpdate1.Click -= eventHandler;
        this._btnAddUpdate = value;
        Button btnAddUpdate2 = this._btnAddUpdate;
        if (btnAddUpdate2 == null)
          return;
        btnAddUpdate2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtTimeInMins { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddSystemScheduleOfRates
    {
      get
      {
        return this._btnAddSystemScheduleOfRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddSystemScheduleOfRates_Click);
        Button systemScheduleOfRates1 = this._btnAddSystemScheduleOfRates;
        if (systemScheduleOfRates1 != null)
          systemScheduleOfRates1.Click -= eventHandler;
        this._btnAddSystemScheduleOfRates = value;
        Button systemScheduleOfRates2 = this._btnAddSystemScheduleOfRates;
        if (systemScheduleOfRates2 == null)
          return;
        systemScheduleOfRates2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpCustomerScheduleOfRate = new GroupBox();
      this.txtTimeInMins = new TextBox();
      this.Label1 = new Label();
      this.btnAddSystemScheduleOfRates = new Button();
      this.btnAddUpdate = new Button();
      this.btnRemove = new Button();
      this.btnAddNew = new Button();
      this.dgRates = new DataGrid();
      this.cboScheduleOfRatesCategoryID = new ComboBox();
      this.lblScheduleOfRatesCategoryID = new Label();
      this.txtCode = new TextBox();
      this.lblCode = new Label();
      this.txtDescription = new TextBox();
      this.lblDescription = new Label();
      this.txtPrice = new TextBox();
      this.lblPrice = new Label();
      this.grpCustomerScheduleOfRate.SuspendLayout();
      this.dgRates.BeginInit();
      this.SuspendLayout();
      this.grpCustomerScheduleOfRate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.txtTimeInMins);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.Label1);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.btnAddSystemScheduleOfRates);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.btnAddUpdate);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.btnRemove);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.btnAddNew);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.dgRates);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.cboScheduleOfRatesCategoryID);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.lblScheduleOfRatesCategoryID);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.txtCode);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.lblCode);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.txtDescription);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.lblDescription);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.txtPrice);
      this.grpCustomerScheduleOfRate.Controls.Add((Control) this.lblPrice);
      this.grpCustomerScheduleOfRate.Location = new System.Drawing.Point(0, -1);
      this.grpCustomerScheduleOfRate.Name = "grpCustomerScheduleOfRate";
      this.grpCustomerScheduleOfRate.Size = new Size(477, 419);
      this.grpCustomerScheduleOfRate.TabIndex = 0;
      this.grpCustomerScheduleOfRate.TabStop = false;
      this.grpCustomerScheduleOfRate.Text = "Schedule Of Rates";
      this.txtTimeInMins.Location = new System.Drawing.Point(194, 135);
      this.txtTimeInMins.MaxLength = 9;
      this.txtTimeInMins.Name = "txtTimeInMins";
      this.txtTimeInMins.Size = new Size(266, 21);
      this.txtTimeInMins.TabIndex = 7;
      this.txtTimeInMins.Tag = (object) "SystemScheduleOfRate.Price";
      this.Label1.Location = new System.Drawing.Point(13, 135);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(177, 20);
      this.Label1.TabIndex = 6;
      this.Label1.Text = "Time (In Minutes)";
      this.btnAddSystemScheduleOfRates.Location = new System.Drawing.Point(139, 188);
      this.btnAddSystemScheduleOfRates.Name = "btnAddSystemScheduleOfRates";
      this.btnAddSystemScheduleOfRates.Size = new Size(200, 23);
      this.btnAddSystemScheduleOfRates.TabIndex = 12;
      this.btnAddSystemScheduleOfRates.Text = "Add System Schedule of Rates";
      this.btnAddUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddUpdate.Location = new System.Drawing.Point(368, 157);
      this.btnAddUpdate.Name = "btnAddUpdate";
      this.btnAddUpdate.Size = new Size(101, 23);
      this.btnAddUpdate.TabIndex = 10;
      this.btnAddUpdate.Text = "Add/Update";
      this.btnRemove.Location = new System.Drawing.Point(10, 186);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new Size(101, 23);
      this.btnRemove.TabIndex = 11;
      this.btnRemove.Text = "Remove";
      this.btnAddNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddNew.Location = new System.Drawing.Point(367, 187);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.Size = new Size(101, 23);
      this.btnAddNew.TabIndex = 13;
      this.btnAddNew.Text = "Add New";
      this.dgRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgRates.DataMember = "";
      this.dgRates.HeaderForeColor = SystemColors.ControlText;
      this.dgRates.Location = new System.Drawing.Point(8, 214);
      this.dgRates.Name = "dgRates";
      this.dgRates.Size = new Size(460, 196);
      this.dgRates.TabIndex = 14;
      this.cboScheduleOfRatesCategoryID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboScheduleOfRatesCategoryID.Cursor = Cursors.Hand;
      this.cboScheduleOfRatesCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboScheduleOfRatesCategoryID.Location = new System.Drawing.Point(194, 20);
      this.cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID";
      this.cboScheduleOfRatesCategoryID.Size = new Size(266, 21);
      this.cboScheduleOfRatesCategoryID.TabIndex = 1;
      this.cboScheduleOfRatesCategoryID.Tag = (object) "CustomerScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblScheduleOfRatesCategoryID.Location = new System.Drawing.Point(11, 19);
      this.lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID";
      this.lblScheduleOfRatesCategoryID.Size = new Size(179, 20);
      this.lblScheduleOfRatesCategoryID.TabIndex = 0;
      this.lblScheduleOfRatesCategoryID.Text = "Schedule Of Rates Category";
      this.txtCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCode.Location = new System.Drawing.Point(194, 47);
      this.txtCode.MaxLength = 50;
      this.txtCode.Name = "txtCode";
      this.txtCode.Size = new Size(266, 21);
      this.txtCode.TabIndex = 3;
      this.txtCode.Tag = (object) "SystemScheduleOfRate.Code";
      this.lblCode.Location = new System.Drawing.Point(11, 47);
      this.lblCode.Name = "lblCode";
      this.lblCode.Size = new Size(179, 20);
      this.lblCode.TabIndex = 2;
      this.lblCode.Text = "Code";
      this.txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDescription.Location = new System.Drawing.Point(194, 76);
      this.txtDescription.MaxLength = 0;
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ScrollBars = ScrollBars.Vertical;
      this.txtDescription.Size = new Size(266, 53);
      this.txtDescription.TabIndex = 5;
      this.txtDescription.Tag = (object) "CustomerScheduleOfRate.Description";
      this.lblDescription.Location = new System.Drawing.Point(11, 75);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new Size(179, 20);
      this.lblDescription.TabIndex = 4;
      this.lblDescription.Text = "Description";
      this.txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPrice.Location = new System.Drawing.Point(194, 161);
      this.txtPrice.MaxLength = 9;
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new Size(160, 21);
      this.txtPrice.TabIndex = 9;
      this.txtPrice.Tag = (object) "CustomerScheduleOfRate.Price";
      this.lblPrice.Location = new System.Drawing.Point(11, 160);
      this.lblPrice.Name = "lblPrice";
      this.lblPrice.Size = new Size(179, 20);
      this.lblPrice.TabIndex = 8;
      this.lblPrice.Text = "Price";
      this.Controls.Add((Control) this.grpCustomerScheduleOfRate);
      this.Name = nameof (UCCustomerScheduleOfRate);
      this.Size = new Size(481, 424);
      this.grpCustomerScheduleOfRate.ResumeLayout(false);
      this.grpCustomerScheduleOfRate.PerformLayout();
      this.dgRates.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
      Combo.SetUpCombo(ref ofRatesCategoryId, App.DB.Picklists.GetAll(Enums.PickListTypes.ScheduleRatesCategories, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
    }

    public object LoadedItem
    {
      get
      {
        object obj;
        return obj;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Enums.TableNames EntityToLinkTo
    {
      get
      {
        return this._EntityToLinkTo;
      }
      set
      {
        this._EntityToLinkTo = value;
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
        if (this.IDToLinkTo == 0)
        {
          this.grpCustomerScheduleOfRate.Enabled = false;
        }
        else
        {
          this.grpCustomerScheduleOfRate.Enabled = true;
          this.Populate(this.IDToLinkTo);
        }
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
        this._dvRates.Table.TableName = Enums.TableNames.tblCustomerScheduleOfRate.ToString();
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

    private Enums.FormState PageState
    {
      get
      {
        return this._pageState;
      }
      set
      {
        this._pageState = value;
        this.PageSetup();
      }
    }

    public CustomerScheduleOfRate CurrentCustomerScheduleOfRate
    {
      get
      {
        return this._currentCustomerScheduleOfRate;
      }
      set
      {
        this._currentCustomerScheduleOfRate = value;
      }
    }

    public bool IsReadOnlyMode
    {
      get
      {
        return this._isReadOnlyMode;
      }
      set
      {
        this._isReadOnlyMode = value;
      }
    }

    public void SetupRatesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgRates, false);
      DataGridTableStyle tableStyle = this.dgRates.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Category";
      dataGridLabelColumn1.MappingName = "Category";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 90;
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
      dataGridLabelColumn3.Width = 170;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Time (Mins)";
      dataGridLabelColumn4.MappingName = "TimeInMins";
      dataGridLabelColumn4.ReadOnly = true;
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
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblCustomerScheduleOfRate.ToString();
      this.dgRates.TableStyles.Add(tableStyle);
    }

    private void PageSetup()
    {
      if (this.IsReadOnlyMode)
      {
        this.btnAddNew.Enabled = false;
        this.btnRemove.Enabled = false;
        this.btnAddUpdate.Enabled = false;
        this.btnAddSystemScheduleOfRates.Enabled = false;
        this.txtCode.Enabled = false;
        this.txtDescription.Enabled = false;
        this.txtPrice.Enabled = false;
        this.txtTimeInMins.Enabled = false;
        this.cboScheduleOfRatesCategoryID.Enabled = false;
      }
      else if (this.PageState == Enums.FormState.Insert)
      {
        this.btnAddNew.Text = "Cancel Add";
        this.btnAddUpdate.Text = "Add";
        this.dgRates.Enabled = false;
        this.btnAddNew.Enabled = true;
        this.btnRemove.Enabled = false;
        this.btnAddUpdate.Enabled = true;
        this.cboScheduleOfRatesCategoryID.Enabled = true;
        this.txtCode.Enabled = true;
        this.txtDescription.Enabled = true;
        this.txtPrice.Enabled = true;
        this.txtTimeInMins.Enabled = true;
      }
      else if (this.PageState == Enums.FormState.Update)
      {
        this.btnAddNew.Text = "Cancel Update";
        this.btnAddUpdate.Text = "Update";
        this.dgRates.Enabled = true;
        this.btnAddNew.Enabled = true;
        this.btnRemove.Enabled = true;
        this.btnAddUpdate.Enabled = true;
        if (!Conversions.ToBoolean(this.SelectedRatesDataRow["AllowDeleted"]))
        {
          ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
          Combo.SetSelectedComboItem_By_Value(ref ofRatesCategoryId, Conversions.ToString(0));
          this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
          this.cboScheduleOfRatesCategoryID.Enabled = false;
          this.txtCode.Enabled = false;
          this.txtDescription.Enabled = false;
        }
        else
        {
          this.cboScheduleOfRatesCategoryID.Enabled = true;
          this.txtCode.Enabled = true;
          this.txtDescription.Enabled = true;
        }
        this.txtPrice.Enabled = true;
        this.txtTimeInMins.Enabled = true;
      }
      else
      {
        this.btnAddNew.Text = "Add New";
        this.dgRates.Enabled = true;
        this.btnAddNew.Enabled = true;
        this.btnRemove.Enabled = false;
        this.btnAddUpdate.Enabled = false;
        this.cboScheduleOfRatesCategoryID.Enabled = false;
        this.txtCode.Enabled = false;
        this.txtDescription.Enabled = false;
        this.txtPrice.Enabled = false;
        this.txtTimeInMins.Enabled = false;
        ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
        Combo.SetSelectedComboItem_By_Value(ref ofRatesCategoryId, Conversions.ToString(0));
        this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
        this.txtCode.Text = "";
        this.txtDescription.Text = "";
        this.txtPrice.Text = Strings.Format((object) 0, "C");
        this.txtTimeInMins.Text = "";
      }
    }

    private void UCCustomerScheduleOfRate_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
      this.SetupRatesDataGrid();
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      if (this.PageState == Enums.FormState.Insert | this.PageState == Enums.FormState.Update)
      {
        this.Populate(this.IDToLinkTo);
        this.PageState = Enums.FormState.Load;
      }
      else
        this.PageState = Enums.FormState.Insert;
    }

    private void btnAddUpdate_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void dgRates_Click(object sender, EventArgs e)
    {
      if (this.IsReadOnlyMode || this.SelectedRatesDataRow == null)
        return;
      DataRow selectedRatesDataRow = this.SelectedRatesDataRow;
      ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
      Combo.SetSelectedComboItem_By_Value(ref ofRatesCategoryId, Conversions.ToString(selectedRatesDataRow["ScheduleOfRatesCategoryID"]));
      this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
      this.txtCode.Text = Conversions.ToString(selectedRatesDataRow["Code"]);
      this.txtDescription.Text = Conversions.ToString(selectedRatesDataRow["Description"]);
      this.txtPrice.Text = Strings.Format(RuntimeHelpers.GetObjectValue(selectedRatesDataRow["Price"]), "C");
      this.txtTimeInMins.Text = Conversions.ToString(selectedRatesDataRow["TimeInMins"]);
      this.PageState = Enums.FormState.Update;
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (this.SelectedRatesDataRow != null)
        this.DeleteRate();
      else
        this.PageState = Enums.FormState.Load;
    }

    private void btnAddSystemScheduleOfRates_Click(object sender, EventArgs e)
    {
      using (FRMSystemScheduleOfRateList scheduleOfRateList = new FRMSystemScheduleOfRateList(Enums.TableNames.tblCustomer, this.IDToLinkTo, 0))
      {
        int num = (int) scheduleOfRateList.ShowDialog();
      }
      this.Populate(this.IDToLinkTo);
    }

    public void Populate(int ID = 0)
    {
      this.RatesDataview = App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(ID);
      this.PageState = Enums.FormState.Load;
    }

    public bool Save()
    {
      try
      {
        this.CurrentCustomerScheduleOfRate.SetAllowDeleted = this.PageState != Enums.FormState.Update ? (object) 1 : RuntimeHelpers.GetObjectValue(this.SelectedRatesDataRow["AllowDeleted"]);
        this.CurrentCustomerScheduleOfRate.SetCustomerID = (object) this.IDToLinkTo;
        this.CurrentCustomerScheduleOfRate.SetCode = (object) this.txtCode.Text.Trim();
        this.CurrentCustomerScheduleOfRate.SetDescription = (object) this.txtDescription.Text.Trim();
        this.CurrentCustomerScheduleOfRate.SetPrice = (object) Strings.Replace(this.txtPrice.Text.Trim(), "£", "", 1, -1, CompareMethod.Binary);
        this.CurrentCustomerScheduleOfRate.SetTimeInMins = (object) this.txtTimeInMins.Text.Trim();
        this.CurrentCustomerScheduleOfRate.SetScheduleOfRatesCategoryID = !this.CurrentCustomerScheduleOfRate.AllowDeleted ? (object) -1 : (object) Combo.get_GetSelectedItemValue(this.cboScheduleOfRatesCategoryID);
        new CustomerScheduleOfRateValidator().Validate(this.CurrentCustomerScheduleOfRate);
        if (this.PageState == Enums.FormState.Update)
        {
          this.CurrentCustomerScheduleOfRate.SetCustomerScheduleOfRateID = RuntimeHelpers.GetObjectValue(this.SelectedRatesDataRow["CustomerScheduleOfRateID"]);
          App.DB.CustomerScheduleOfRate.Update(this.CurrentCustomerScheduleOfRate);
          try
          {
            DataRow selectedRatesDataRow = this.SelectedRatesDataRow;
            if (Conversions.ToBoolean(selectedRatesDataRow["AllowDeleted"]))
            {
              if (MessageBox.Show(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "UPDATE :", selectedRatesDataRow["Description"])), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              {
                App.DB.CustomerScheduleOfRate.Delete(Conversions.ToInteger(selectedRatesDataRow["CustomerScheduleOfRateID"]));
                this.CurrentCustomerScheduleOfRate = App.DB.CustomerScheduleOfRate.Insert(this.CurrentCustomerScheduleOfRate);
              }
            }
            else
            {
              int num = (int) MessageBox.Show("This rate is a system default and cannot be deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            int num = (int) MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ProjectData.ClearProjectError();
          }
        }
        else
          this.CurrentCustomerScheduleOfRate = App.DB.CustomerScheduleOfRate.Insert(this.CurrentCustomerScheduleOfRate);
        this.Populate(this.IDToLinkTo);
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
      bool flag;
      return flag;
    }

    private object DeleteRate()
    {
      try
      {
        DataRow selectedRatesDataRow = this.SelectedRatesDataRow;
        if (Conversions.ToBoolean(selectedRatesDataRow["AllowDeleted"]))
        {
          if (MessageBox.Show(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "DELETE :", selectedRatesDataRow["Description"])), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            App.DB.CustomerScheduleOfRate.Delete(Conversions.ToInteger(selectedRatesDataRow["CustomerScheduleOfRateID"]));
            this.Populate(this.IDToLinkTo);
          }
        }
        else
        {
          int num = (int) MessageBox.Show("This rate is a system default and cannot be deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
      object obj;
      return obj;
    }
  }
}
