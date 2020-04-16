// Decompiled with JetBrains decompiler
// Type: FSM.UCQuoteContractOption3Site
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.QuoteContractOption3SiteAssetDurations;
using FSM.Entity.QuoteContractOption3Sites;
using FSM.Entity.Sites;
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
  public class UCQuoteContractOption3Site : UCBase, IUserControl
  {
    private IContainer components;
    private QuoteContractOption3Site _currentQuoteContractOption3Site;
    private DataView _Assets;
    private int _NumOfMonths;
    private ArrayList _Visits;
    private DataView _AssetDurations;

    public UCQuoteContractOption3Site()
    {
      this.Load += new EventHandler(this.UCContractOption3Site_Load);
      this._NumOfMonths = 0;
      this._Visits = new ArrayList();
      this._AssetDurations = new DataView();
      this.InitializeComponent();
      ComboBox visitFrequencyId = this.cboVisitFrequencyID;
      Combo.SetUpCombo(ref visitFrequencyId, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboVisitFrequencyID = visitFrequencyId;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpContractOption3Site { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSiteID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContractSiteReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractSiteReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpStartDate
    {
      get
      {
        return this._dtpStartDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpStartDate_ValueChanged);
        DateTimePicker dtpStartDate1 = this._dtpStartDate;
        if (dtpStartDate1 != null)
          dtpStartDate1.ValueChanged -= eventHandler;
        this._dtpStartDate = value;
        DateTimePicker dtpStartDate2 = this._dtpStartDate;
        if (dtpStartDate2 == null)
          return;
        dtpStartDate2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label lblStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpEndDate
    {
      get
      {
        return this._dtpEndDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpEndDate_ValueChanged);
        DateTimePicker dtpEndDate1 = this._dtpEndDate;
        if (dtpEndDate1 != null)
          dtpEndDate1.ValueChanged -= eventHandler;
        this._dtpEndDate = value;
        DateTimePicker dtpEndDate2 = this._dtpEndDate;
        if (dtpEndDate2 == null)
          return;
        dtpEndDate2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label lblEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFirstVisitDate
    {
      get
      {
        return this._dtpFirstVisitDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpFirstVisitDate_ValueChanged);
        DateTimePicker dtpFirstVisitDate1 = this._dtpFirstVisitDate;
        if (dtpFirstVisitDate1 != null)
          dtpFirstVisitDate1.ValueChanged -= eventHandler;
        this._dtpFirstVisitDate = value;
        DateTimePicker dtpFirstVisitDate2 = this._dtpFirstVisitDate;
        if (dtpFirstVisitDate2 == null)
          return;
        dtpFirstVisitDate2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label lblFirstVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVisitFrequencyID
    {
      get
      {
        return this._cboVisitFrequencyID;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboVisitFrequencyID_SelectedIndexChanged);
        ComboBox visitFrequencyId1 = this._cboVisitFrequencyID;
        if (visitFrequencyId1 != null)
          visitFrequencyId1.SelectedIndexChanged -= eventHandler;
        this._cboVisitFrequencyID = value;
        ComboBox visitFrequencyId2 = this._cboVisitFrequencyID;
        if (visitFrequencyId2 == null)
          return;
        visitFrequencyId2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblVisitFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSitePrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSitePrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblWarning { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRefreshGrid
    {
      get
      {
        return this._btnRefreshGrid;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRefreshGrid_Click);
        Button btnRefreshGrid1 = this._btnRefreshGrid;
        if (btnRefreshGrid1 != null)
          btnRefreshGrid1.Click -= eventHandler;
        this._btnRefreshGrid = value;
        Button btnRefreshGrid2 = this._btnRefreshGrid;
        if (btnRefreshGrid2 == null)
          return;
        btnRefreshGrid2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpContractOption3Site = new GroupBox();
      this.btnRefreshGrid = new Button();
      this.lblWarning = new Label();
      this.gpbAssets = new GroupBox();
      this.dgAssets = new DataGrid();
      this.txtSite = new TextBox();
      this.lblSiteID = new Label();
      this.txtContractSiteReference = new TextBox();
      this.lblContractSiteReference = new Label();
      this.dtpStartDate = new DateTimePicker();
      this.lblStartDate = new Label();
      this.dtpEndDate = new DateTimePicker();
      this.lblEndDate = new Label();
      this.dtpFirstVisitDate = new DateTimePicker();
      this.lblFirstVisitDate = new Label();
      this.cboVisitFrequencyID = new ComboBox();
      this.lblVisitFrequencyID = new Label();
      this.txtSitePrice = new TextBox();
      this.lblSitePrice = new Label();
      this.grpContractOption3Site.SuspendLayout();
      this.gpbAssets.SuspendLayout();
      this.dgAssets.BeginInit();
      this.SuspendLayout();
      this.grpContractOption3Site.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContractOption3Site.Controls.Add((Control) this.btnRefreshGrid);
      this.grpContractOption3Site.Controls.Add((Control) this.lblWarning);
      this.grpContractOption3Site.Controls.Add((Control) this.gpbAssets);
      this.grpContractOption3Site.Controls.Add((Control) this.txtSite);
      this.grpContractOption3Site.Controls.Add((Control) this.lblSiteID);
      this.grpContractOption3Site.Controls.Add((Control) this.txtContractSiteReference);
      this.grpContractOption3Site.Controls.Add((Control) this.lblContractSiteReference);
      this.grpContractOption3Site.Controls.Add((Control) this.dtpStartDate);
      this.grpContractOption3Site.Controls.Add((Control) this.lblStartDate);
      this.grpContractOption3Site.Controls.Add((Control) this.dtpEndDate);
      this.grpContractOption3Site.Controls.Add((Control) this.lblEndDate);
      this.grpContractOption3Site.Controls.Add((Control) this.dtpFirstVisitDate);
      this.grpContractOption3Site.Controls.Add((Control) this.lblFirstVisitDate);
      this.grpContractOption3Site.Controls.Add((Control) this.cboVisitFrequencyID);
      this.grpContractOption3Site.Controls.Add((Control) this.lblVisitFrequencyID);
      this.grpContractOption3Site.Controls.Add((Control) this.txtSitePrice);
      this.grpContractOption3Site.Controls.Add((Control) this.lblSitePrice);
      this.grpContractOption3Site.Location = new System.Drawing.Point(8, 8);
      this.grpContractOption3Site.Name = "grpContractOption3Site";
      this.grpContractOption3Site.Size = new Size(979, 594);
      this.grpContractOption3Site.TabIndex = 1;
      this.grpContractOption3Site.TabStop = false;
      this.grpContractOption3Site.Text = "Main Details";
      this.btnRefreshGrid.UseVisualStyleBackColor = true;
      this.btnRefreshGrid.Location = new System.Drawing.Point(500, 122);
      this.btnRefreshGrid.Name = "btnRefreshGrid";
      this.btnRefreshGrid.Size = new Size(200, 23);
      this.btnRefreshGrid.TabIndex = 8;
      this.btnRefreshGrid.Text = "Load Assets Scheduled";
      this.lblWarning.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblWarning.ForeColor = Color.Red;
      this.lblWarning.Location = new System.Drawing.Point(704, 71);
      this.lblWarning.Name = "lblWarning";
      this.lblWarning.Size = new Size(268, 23);
      this.lblWarning.TabIndex = 34;
      this.lblWarning.Text = "! Date must be between Start &&End Date";
      this.lblWarning.Visible = false;
      this.gpbAssets.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbAssets.Controls.Add((Control) this.dgAssets);
      this.gpbAssets.Location = new System.Drawing.Point(9, 153);
      this.gpbAssets.Name = "gpbAssets";
      this.gpbAssets.Size = new Size(963, 434);
      this.gpbAssets.TabIndex = 9;
      this.gpbAssets.TabStop = false;
      this.gpbAssets.Text = "Assets - Enter duration in hours for each month";
      this.dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAssets.DataMember = "";
      this.dgAssets.HeaderForeColor = SystemColors.ControlText;
      this.dgAssets.Location = new System.Drawing.Point(10, 26);
      this.dgAssets.Name = "dgAssets";
      this.dgAssets.Size = new Size(942, 400);
      this.dgAssets.TabIndex = 0;
      this.txtSite.Location = new System.Drawing.Point(151, 25);
      this.txtSite.Multiline = true;
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.ScrollBars = ScrollBars.Vertical;
      this.txtSite.Size = new Size(200, 77);
      this.txtSite.TabIndex = 0;
      this.txtSite.Text = "";
      this.lblSiteID.Location = new System.Drawing.Point(9, 25);
      this.lblSiteID.Name = "lblSiteID";
      this.lblSiteID.Size = new Size(139, 20);
      this.lblSiteID.TabIndex = 31;
      this.lblSiteID.Text = "Property";
      this.txtContractSiteReference.Location = new System.Drawing.Point(151, 104);
      this.txtContractSiteReference.MaxLength = 100;
      this.txtContractSiteReference.Name = "txtContractSiteReference";
      this.txtContractSiteReference.ReadOnly = true;
      this.txtContractSiteReference.Size = new Size(200, 21);
      this.txtContractSiteReference.TabIndex = 1;
      this.txtContractSiteReference.Tag = (object) "ContractOption3Site.ContractSiteReference";
      this.txtContractSiteReference.Text = "";
      this.lblContractSiteReference.Location = new System.Drawing.Point(10, 104);
      this.lblContractSiteReference.Name = "lblContractSiteReference";
      this.lblContractSiteReference.Size = new Size(139, 20);
      this.lblContractSiteReference.TabIndex = 31;
      this.lblContractSiteReference.Text = "Quote Property Reference";
      this.dtpStartDate.Location = new System.Drawing.Point(500, 25);
      this.dtpStartDate.Name = "dtpStartDate";
      this.dtpStartDate.TabIndex = 4;
      this.dtpStartDate.Tag = (object) "ContractOption3Site.StartDate";
      this.lblStartDate.Location = new System.Drawing.Point(366, 25);
      this.lblStartDate.Name = "lblStartDate";
      this.lblStartDate.Size = new Size(123, 20);
      this.lblStartDate.TabIndex = 31;
      this.lblStartDate.Text = "Start Date";
      this.dtpEndDate.Location = new System.Drawing.Point(500, 49);
      this.dtpEndDate.Name = "dtpEndDate";
      this.dtpEndDate.TabIndex = 5;
      this.dtpEndDate.Tag = (object) "ContractOption3Site.EndDate";
      this.lblEndDate.Location = new System.Drawing.Point(366, 49);
      this.lblEndDate.Name = "lblEndDate";
      this.lblEndDate.Size = new Size(123, 20);
      this.lblEndDate.TabIndex = 31;
      this.lblEndDate.Text = "End Date";
      this.dtpFirstVisitDate.Location = new System.Drawing.Point(500, 72);
      this.dtpFirstVisitDate.Name = "dtpFirstVisitDate";
      this.dtpFirstVisitDate.TabIndex = 6;
      this.dtpFirstVisitDate.Tag = (object) "ContractOption3Site.FirstVisitDate";
      this.lblFirstVisitDate.Location = new System.Drawing.Point(367, 72);
      this.lblFirstVisitDate.Name = "lblFirstVisitDate";
      this.lblFirstVisitDate.Size = new Size(123, 20);
      this.lblFirstVisitDate.TabIndex = 31;
      this.lblFirstVisitDate.Text = "First Visit Date";
      this.cboVisitFrequencyID.Cursor = Cursors.Hand;
      this.cboVisitFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVisitFrequencyID.Location = new System.Drawing.Point(500, 96);
      this.cboVisitFrequencyID.Name = "cboVisitFrequencyID";
      this.cboVisitFrequencyID.Size = new Size(200, 21);
      this.cboVisitFrequencyID.TabIndex = 7;
      this.cboVisitFrequencyID.Tag = (object) "ContractOption3Site.VisitFrequencyID";
      this.lblVisitFrequencyID.Location = new System.Drawing.Point(367, 96);
      this.lblVisitFrequencyID.Name = "lblVisitFrequencyID";
      this.lblVisitFrequencyID.Size = new Size(96, 20);
      this.lblVisitFrequencyID.TabIndex = 31;
      this.lblVisitFrequencyID.Text = "Visit Frequency";
      this.txtSitePrice.Location = new System.Drawing.Point(151, 128);
      this.txtSitePrice.MaxLength = 9;
      this.txtSitePrice.Name = "txtSitePrice";
      this.txtSitePrice.Size = new Size(200, 21);
      this.txtSitePrice.TabIndex = 3;
      this.txtSitePrice.Tag = (object) "ContractOption3Site.SitePrice";
      this.txtSitePrice.Text = "";
      this.lblSitePrice.Location = new System.Drawing.Point(10, 128);
      this.lblSitePrice.Name = "lblSitePrice";
      this.lblSitePrice.Size = new Size(112, 20);
      this.lblSitePrice.TabIndex = 31;
      this.lblSitePrice.Text = "Property Price";
      this.Controls.Add((Control) this.grpContractOption3Site);
      this.Name = nameof (UCQuoteContractOption3Site);
      this.Size = new Size(994, 616);
      this.grpContractOption3Site.ResumeLayout(false);
      this.gpbAssets.ResumeLayout(false);
      this.dgAssets.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentQuoteContractOption3Site;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public QuoteContractOption3Site CurrentQuoteContractOption3Site
    {
      get
      {
        return this._currentQuoteContractOption3Site;
      }
      set
      {
        this._currentQuoteContractOption3Site = value;
        if (this._currentQuoteContractOption3Site == null)
        {
          this._currentQuoteContractOption3Site = new QuoteContractOption3Site();
          this._currentQuoteContractOption3Site.Exists = false;
        }
        if (!this._currentQuoteContractOption3Site.Exists)
          return;
        this.Populate(0);
        FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
        FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) this._currentQuoteContractOption3Site.SiteID, SiteSQL.GetBy.SiteId, (object) null);
        this.txtSite.Text = Strings.Replace(Strings.Replace(Strings.Replace(site2.Address1 + ", " + site2.Address2 + ", " + site2.Address3 + ", " + site2.Address4 + ", " + site2.Address5 + ", " + site2.Postcode + ".", ", , ", ", ", 1, -1, CompareMethod.Binary), ", , ", ", ", 1, -1, CompareMethod.Binary), ", , ", ", ", 1, -1, CompareMethod.Binary);
      }
    }

    private DataView Assets
    {
      get
      {
        return this._Assets;
      }
      set
      {
        this._Assets = value;
        this._Assets.AllowNew = false;
        this._Assets.AllowEdit = true;
        this._Assets.AllowDelete = false;
        this._Assets.Table.TableName = Enums.TableNames.tblAsset.ToString();
        this.dgAssets.DataSource = (object) this._Assets;
      }
    }

    private int NumOfMonths
    {
      get
      {
        return this._NumOfMonths;
      }
      set
      {
        this._NumOfMonths = value;
      }
    }

    private ArrayList Visits
    {
      get
      {
        return this._Visits;
      }
      set
      {
        this._Visits = value;
      }
    }

    private DataView AssetDurations
    {
      get
      {
        return this._AssetDurations;
      }
      set
      {
        this._AssetDurations = value;
      }
    }

    public void SetupAssetsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgAssets, false);
      DataGridTableStyle tableStyle = this.dgAssets.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgAssets.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Product";
      dataGridLabelColumn1.MappingName = "Product";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Location";
      dataGridLabelColumn2.MappingName = "Location";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 90;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Serial Number";
      dataGridLabelColumn3.MappingName = "SerialNum";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 90;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      int int32 = Convert.ToInt32(Math.Ceiling(new Decimal(DateAndTime.DateDiff(DateInterval.Month, this.dtpStartDate.Value, this.dtpEndDate.Value, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))));
      int months = 0;
      while (months <= int32)
      {
        Contract3AssetsColourColumn assetsColourColumn1 = new Contract3AssetsColourColumn();
        Contract3AssetsColourColumn assetsColourColumn2 = assetsColourColumn1;
        DateTime dateTime = this.dtpStartDate.Value;
        string str1 = Strings.Format((object) dateTime.AddMonths(months), "MMM yy");
        assetsColourColumn2.HeaderText = str1;
        Contract3AssetsColourColumn assetsColourColumn3 = assetsColourColumn1;
        dateTime = this.dtpStartDate.Value;
        string str2 = Strings.Format((object) dateTime.AddMonths(months), "MMM yy");
        assetsColourColumn3.MappingName = str2;
        assetsColourColumn1.ReadOnly = false;
        assetsColourColumn1.Width = 50;
        assetsColourColumn1.NullText = "-";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) assetsColourColumn1);
        checked { ++months; }
      }
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblAsset.ToString();
      this.dgAssets.TableStyles.Add(tableStyle);
    }

    private void UCContractOption3Site_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
      this.SetupAssetsDataGrid();
    }

    private void dtpStartDate_ValueChanged(object sender, EventArgs e)
    {
      this.ClearAssetsGrid();
    }

    private void dtpEndDate_ValueChanged(object sender, EventArgs e)
    {
      this.ClearAssetsGrid();
    }

    private void dtpFirstVisitDate_ValueChanged(object sender, EventArgs e)
    {
      this.ClearAssetsGrid();
    }

    private void cboVisitFrequencyID_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ClearAssetsGrid();
    }

    private void btnRefreshGrid_Click(object sender, EventArgs e)
    {
      this.RefreshAssetsGrid();
    }

    private void ClearAssetsGrid()
    {
      if (this.CurrentQuoteContractOption3Site != null)
        this.Assets = App.DB.Asset.Asset_GetForSite(this.CurrentQuoteContractOption3Site.SiteID);
      if (DateTime.Compare(this.dtpFirstVisitDate.Value, this.dtpStartDate.Value) >= 0 & DateTime.Compare(this.dtpFirstVisitDate.Value, this.dtpEndDate.Value) <= 0)
        this.lblWarning.Visible = false;
      else
        this.lblWarning.Visible = true;
    }

    private void RefreshAssetsGrid()
    {
      this.Cursor = Cursors.WaitCursor;
      DateTime minValue = DateTime.MinValue;
      int num1 = 0;
      if (this.CurrentQuoteContractOption3Site != null)
      {
        if (this.Assets != null)
        {
          this.NumOfMonths = Convert.ToInt32(Math.Ceiling(new Decimal(DateAndTime.DateDiff(DateInterval.Month, this.dtpStartDate.Value, this.dtpEndDate.Value, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))));
          this.ClearAssetsGrid();
          this.Visits = new ArrayList();
          int numOfMonths = this.NumOfMonths;
          int months1 = 0;
          DateTime dateTime1;
          while (months1 <= numOfMonths)
          {
            DataColumnCollection columns = this.Assets.Table.Columns;
            dateTime1 = this.dtpStartDate.Value;
            string columnName = Strings.Format((object) dateTime1.AddMonths(months1), "MMM yy");
            columns.Add(columnName);
            checked { ++months1; }
          }
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVisitFrequencyID)) > 0.0)
          {
            dateTime1 = this.dtpFirstVisitDate.Value;
            DateTime date1 = dateTime1.Date;
            dateTime1 = this.dtpStartDate.Value;
            DateTime date2 = dateTime1.Date;
            int num2 = DateTime.Compare(date1, date2) >= 0 ? 1 : 0;
            dateTime1 = this.dtpFirstVisitDate.Value;
            DateTime date3 = dateTime1.Date;
            dateTime1 = this.dtpEndDate.Value;
            DateTime date4 = dateTime1.Date;
            int num3 = DateTime.Compare(date3, date4) <= 0 ? 1 : 0;
            if ((num2 & num3) != 0)
            {
              this.lblWarning.Visible = false;
              num1 = 0;
              int months2 = 0;
              switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboVisitFrequencyID)))
              {
                case 4:
                  months2 = 1;
                  break;
                case 5:
                  months2 = 3;
                  break;
                case 6:
                  months2 = 6;
                  break;
                case 7:
                  months2 = 12;
                  break;
              }
              int num4 = checked ((int) Math.Ceiling(unchecked ((double) DateAndTime.DateDiff(DateInterval.Month, this.dtpStartDate.Value, this.dtpEndDate.Value, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / (double) months2)));
              if (num4 == 0)
                num4 = 1;
              dateTime1 = this.dtpFirstVisitDate.Value;
              DateTime dateTime2 = Conversions.ToDate(Conversions.ToString(dateTime1.Date) + " 09:00:00");
              int num5 = num4;
              int num6 = 1;
              while (num6 <= num5)
              {
                DateTime t1_1 = dateTime2;
                dateTime1 = this.dtpStartDate.Value;
                DateTime date5 = Conversions.ToDate(Strings.Format((object) dateTime1.Date, "dd/MM/yyyy") + " 09:00");
                int num7 = DateTime.Compare(t1_1, date5) >= 0 ? 1 : 0;
                DateTime t1_2 = dateTime2;
                dateTime1 = this.dtpEndDate.Value;
                DateTime date6 = Conversions.ToDate(Strings.Format((object) dateTime1.Date, "dd/MM/yyyy") + " 09:00");
                int num8 = DateTime.Compare(t1_2, date6) <= 0 ? 1 : 0;
                if ((num7 & num8) != 0)
                {
                  DateTime dateTime3 = dateTime2;
                  if (dateTime2.DayOfWeek == DayOfWeek.Saturday)
                    dateTime2 = dateTime2.AddDays(2.0);
                  else if (dateTime2.DayOfWeek == DayOfWeek.Sunday)
                    dateTime2 = dateTime2.AddDays(1.0);
                  IEnumerator enumerator;
                  try
                  {
                    enumerator = this.Assets.Table.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                      DataRow current = (DataRow) enumerator.Current;
                      DataRow[] dataRowArray = this.AssetDurations.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("CompareMonth=" + Strings.Format((object) dateTime2, "yyyyMM") + " AND AssetID="), current["AssetID"])));
                      if (dataRowArray.Length > 0)
                        current[Strings.Format((object) dateTime2, "MMM yy")] = RuntimeHelpers.GetObjectValue(dataRowArray[0]["VisitDuration"]);
                      else
                        current[Strings.Format((object) dateTime2, "MMM yy")] = (object) "0";
                    }
                  }
                  finally
                  {
                    if (enumerator is IDisposable)
                      (enumerator as IDisposable).Dispose();
                  }
                  this.Visits.Add((object) dateTime2);
                  dateTime2 = dateTime3.AddMonths(months2);
                }
                checked { ++num6; }
              }
            }
            else
              this.lblWarning.Visible = true;
          }
        }
        this.SetupAssetsDataGrid();
      }
      this.Cursor = Cursors.Default;
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentQuoteContractOption3Site = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_Get(ID);
      this.AssetDurations = App.DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(this.CurrentQuoteContractOption3Site.QuoteContractSiteID);
      this.txtContractSiteReference.Text = this.CurrentQuoteContractOption3Site.QuoteContractSiteReference;
      try
      {
        this.dtpStartDate.Value = this.CurrentQuoteContractOption3Site.StartDate;
        this.dtpEndDate.Value = this.CurrentQuoteContractOption3Site.EndDate;
        this.dtpFirstVisitDate.Value = this.CurrentQuoteContractOption3Site.FirstVisitDate;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.dtpStartDate.Value = DateAndTime.Now;
        DateTimePicker dtpEndDate = this.dtpEndDate;
        DateTime dateTime1 = DateAndTime.Now;
        dateTime1 = dateTime1.AddYears(1);
        DateTime dateTime2 = dateTime1.AddDays(-1.0);
        dtpEndDate.Value = dateTime2;
        this.dtpFirstVisitDate.Value = DateAndTime.Now;
        ProjectData.ClearProjectError();
      }
      ComboBox visitFrequencyId = this.cboVisitFrequencyID;
      Combo.SetSelectedComboItem_By_Value(ref visitFrequencyId, Conversions.ToString(this.CurrentQuoteContractOption3Site.VisitFrequencyID));
      this.cboVisitFrequencyID = visitFrequencyId;
      this.txtSitePrice.Text = Strings.Format((object) this.CurrentQuoteContractOption3Site.SitePrice, "C");
      this.Assets = App.DB.Asset.Asset_GetForSite(this.CurrentQuoteContractOption3Site.SiteID);
      this.AssetDurations = App.DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(this.CurrentQuoteContractOption3Site.QuoteContractSiteID);
      this.RefreshAssetsGrid();
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentQuoteContractOption3Site.IgnoreExceptionsOnSetMethods = true;
        this.CurrentQuoteContractOption3Site.SetQuoteContractSiteReference = (object) this.txtContractSiteReference.Text.Trim();
        this.CurrentQuoteContractOption3Site.StartDate = this.dtpStartDate.Value;
        this.CurrentQuoteContractOption3Site.EndDate = this.dtpEndDate.Value;
        this.CurrentQuoteContractOption3Site.FirstVisitDate = this.dtpFirstVisitDate.Value;
        this.CurrentQuoteContractOption3Site.SetVisitFrequencyID = (object) Combo.get_GetSelectedItemValue(this.cboVisitFrequencyID);
        this.CurrentQuoteContractOption3Site.SetSitePrice = (object) this.txtSitePrice.Text.Trim().Replace("£", "");
        new QuoteContractOption3SiteValidator().Validate(this.CurrentQuoteContractOption3Site, this.Assets);
        if (this.CurrentQuoteContractOption3Site.Exists)
        {
          App.DB.QuoteContractOption3Site.Update(this.CurrentQuoteContractOption3Site);
          App.DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_Delete(this.CurrentQuoteContractOption3Site.QuoteContractSiteID);
          IEnumerator enumerator1;
          try
          {
            enumerator1 = this.Visits.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              object objectValue = RuntimeHelpers.GetObjectValue(enumerator1.Current);
              IEnumerator enumerator2;
              try
              {
                enumerator2 = this.Assets.Table.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                  DataRow current = (DataRow) enumerator2.Current;
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current[Strings.Format(RuntimeHelpers.GetObjectValue(objectValue), "MMM yy")], (object) 0, false))
                    App.DB.QuoteContractOption3SiteAssetDurations.Insert(new QuoteContractOption3SiteAssetDuration()
                    {
                      SetQuoteContractSiteID = (object) this.CurrentQuoteContractOption3Site.QuoteContractSiteID,
                      SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"]),
                      ScheduledMonth = Conversions.ToDate(objectValue),
                      SetVisitDuration = RuntimeHelpers.GetObjectValue(current[Strings.Format(RuntimeHelpers.GetObjectValue(objectValue), "MMM yy")])
                    });
                }
              }
              finally
              {
                if (enumerator2 is IDisposable)
                  (enumerator2 as IDisposable).Dispose();
              }
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
        }
        else
          this.CurrentQuoteContractOption3Site = App.DB.QuoteContractOption3Site.Insert(this.CurrentQuoteContractOption3Site);
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentQuoteContractOption3Site.QuoteContractSiteID);
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }
  }
}
