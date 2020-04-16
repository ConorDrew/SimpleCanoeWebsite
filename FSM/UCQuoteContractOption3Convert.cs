// Decompiled with JetBrains decompiler
// Type: FSM.UCQuoteContractOption3Convert
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractOption3s;
using FSM.Entity.ContractOption3SitePPMVisits;
using FSM.Entity.ContractOption3Sites;
using FSM.Entity.EngineerVisits;
using FSM.Entity.InvoiceToBeRaiseds;
using FSM.Entity.JobAssets;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.Management;
using FSM.Entity.QuoteContractOption3s;
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
  public class UCQuoteContractOption3Convert : UCBase, IUserControl
  {
    private IContainer components;
    private bool _loading;
    private QuoteContractOption3 _currentQuoteContractOption3;
    private DataView _Sites;
    private ArrayList _Assets;
    private ArrayList _AssetsDurations;
    private ArrayList _Visits;

    public UCQuoteContractOption3Convert()
    {
      this.Load += new EventHandler(this.UCQuoteContractOption3_Load);
      this._loading = false;
      this._Assets = new ArrayList();
      this._AssetsDurations = new ArrayList();
      this._Visits = new ArrayList();
      this.InitializeComponent();
      ComboBox cboContractStatus = this.cboContractStatus;
      Combo.SetUpCombo(ref cboContractStatus, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboContractStatus = cboContractStatus;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpQuoteContractOption3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContractPrice
    {
      get
      {
        return this._txtContractPrice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtQuoteContractPrice_LostFocus);
        TextBox txtContractPrice1 = this._txtContractPrice;
        if (txtContractPrice1 != null)
          txtContractPrice1.LostFocus -= eventHandler;
        this._txtContractPrice = value;
        TextBox txtContractPrice2 = this._txtContractPrice;
        if (txtContractPrice2 == null)
          return;
        txtContractPrice2.LostFocus += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMsg { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSites
    {
      get
      {
        return this._dgSites;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgSites_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgSites_Click);
        DataGrid dgSites1 = this._dgSites;
        if (dgSites1 != null)
        {
          dgSites1.CurrentCellChanged -= eventHandler1;
          dgSites1.Click -= eventHandler2;
        }
        this._dgSites = value;
        DataGrid dgSites2 = this._dgSites;
        if (dgSites2 == null)
          return;
        dgSites2.CurrentCellChanged += eventHandler1;
        dgSites2.Click += eventHandler2;
      }
    }

    internal virtual TextBox txtContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboContractStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnContractNumber
    {
      get
      {
        return this._btnContractNumber;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnContractNumber_Click);
        Button btnContractNumber1 = this._btnContractNumber;
        if (btnContractNumber1 != null)
          btnContractNumber1.Click -= eventHandler;
        this._btnContractNumber = value;
        Button btnContractNumber2 = this._btnContractNumber;
        if (btnContractNumber2 == null)
          return;
        btnContractNumber2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpQuoteContractOption3 = new GroupBox();
      this.btnContractNumber = new Button();
      this.cboContractStatus = new ComboBox();
      this.lblContractStatus = new Label();
      this.grpAssets = new GroupBox();
      this.dgAssets = new DataGrid();
      this.txtContractPrice = new TextBox();
      this.Label1 = new Label();
      this.lblMsg = new Label();
      this.gpbSite = new GroupBox();
      this.dgSites = new DataGrid();
      this.txtContractReference = new TextBox();
      this.lblContractReference = new Label();
      this.grpQuoteContractOption3.SuspendLayout();
      this.grpAssets.SuspendLayout();
      this.dgAssets.BeginInit();
      this.gpbSite.SuspendLayout();
      this.dgSites.BeginInit();
      this.SuspendLayout();
      this.grpQuoteContractOption3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpQuoteContractOption3.Controls.Add((Control) this.btnContractNumber);
      this.grpQuoteContractOption3.Controls.Add((Control) this.cboContractStatus);
      this.grpQuoteContractOption3.Controls.Add((Control) this.lblContractStatus);
      this.grpQuoteContractOption3.Controls.Add((Control) this.grpAssets);
      this.grpQuoteContractOption3.Controls.Add((Control) this.txtContractPrice);
      this.grpQuoteContractOption3.Controls.Add((Control) this.Label1);
      this.grpQuoteContractOption3.Controls.Add((Control) this.lblMsg);
      this.grpQuoteContractOption3.Controls.Add((Control) this.gpbSite);
      this.grpQuoteContractOption3.Controls.Add((Control) this.txtContractReference);
      this.grpQuoteContractOption3.Controls.Add((Control) this.lblContractReference);
      this.grpQuoteContractOption3.Location = new System.Drawing.Point(8, 8);
      this.grpQuoteContractOption3.Name = "grpQuoteContractOption3";
      this.grpQuoteContractOption3.Size = new Size(906, 594);
      this.grpQuoteContractOption3.TabIndex = 1;
      this.grpQuoteContractOption3.TabStop = false;
      this.grpQuoteContractOption3.Text = "Main Details";
      this.btnContractNumber.UseVisualStyleBackColor = true;
      this.btnContractNumber.Location = new System.Drawing.Point(14, 55);
      this.btnContractNumber.Name = "btnContractNumber";
      this.btnContractNumber.Size = new Size(291, 23);
      this.btnContractNumber.TabIndex = 2;
      this.btnContractNumber.Text = "Next Suggested Contract Number";
      this.cboContractStatus.Cursor = Cursors.Hand;
      this.cboContractStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboContractStatus.Location = new System.Drawing.Point(728, 25);
      this.cboContractStatus.Name = "cboContractStatus";
      this.cboContractStatus.Size = new Size(158, 21);
      this.cboContractStatus.TabIndex = 4;
      this.cboContractStatus.Tag = (object) "ContractOption3.ContractStatus";
      this.lblContractStatus.Location = new System.Drawing.Point(621, 25);
      this.lblContractStatus.Name = "lblContractStatus";
      this.lblContractStatus.Size = new Size(99, 20);
      this.lblContractStatus.TabIndex = 59;
      this.lblContractStatus.Text = "Contract Status";
      this.grpAssets.Controls.Add((Control) this.dgAssets);
      this.grpAssets.Location = new System.Drawing.Point(10, 331);
      this.grpAssets.Name = "grpAssets";
      this.grpAssets.Size = new Size(884, 243);
      this.grpAssets.TabIndex = 57;
      this.grpAssets.TabStop = false;
      this.grpAssets.Text = "Assets";
      this.dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAssets.DataMember = "";
      this.dgAssets.HeaderForeColor = SystemColors.ControlText;
      this.dgAssets.Location = new System.Drawing.Point(10, 21);
      this.dgAssets.Name = "dgAssets";
      this.dgAssets.Size = new Size(865, 217);
      this.dgAssets.TabIndex = 1;
      this.txtContractPrice.Location = new System.Drawing.Point(424, 25);
      this.txtContractPrice.MaxLength = 100;
      this.txtContractPrice.Name = "txtContractPrice";
      this.txtContractPrice.Size = new Size(175, 21);
      this.txtContractPrice.TabIndex = 3;
      this.txtContractPrice.Tag = (object) "ContractOption3.ContractPrice";
      this.txtContractPrice.Text = "";
      this.Label1.Location = new System.Drawing.Point(326, 25);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(99, 20);
      this.Label1.TabIndex = 56;
      this.Label1.Text = "Contract Price";
      this.lblMsg.BackColor = Color.LightGoldenrodYellow;
      this.lblMsg.BorderStyle = BorderStyle.FixedSingle;
      this.lblMsg.Location = new System.Drawing.Point(326, 55);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new Size(274, 23);
      this.lblMsg.TabIndex = 54;
      this.lblMsg.Text = "Please save before adding properties";
      this.lblMsg.TextAlign = ContentAlignment.MiddleLeft;
      this.gpbSite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbSite.Controls.Add((Control) this.dgSites);
      this.gpbSite.Location = new System.Drawing.Point(10, 84);
      this.gpbSite.Name = "gpbSite";
      this.gpbSite.Size = new Size(884, 239);
      this.gpbSite.TabIndex = 53;
      this.gpbSite.TabStop = false;
      this.gpbSite.Text = "Properties - Click a site to view the related assets.";
      this.dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSites.DataMember = "";
      this.dgSites.HeaderForeColor = SystemColors.ControlText;
      this.dgSites.Location = new System.Drawing.Point(10, 19);
      this.dgSites.Name = "dgSites";
      this.dgSites.Size = new Size(865, 210);
      this.dgSites.TabIndex = 0;
      this.txtContractReference.Location = new System.Drawing.Point(131, 25);
      this.txtContractReference.MaxLength = 100;
      this.txtContractReference.Name = "txtContractReference";
      this.txtContractReference.Size = new Size(175, 21);
      this.txtContractReference.TabIndex = 1;
      this.txtContractReference.Tag = (object) "ContractOption3.ContractReference";
      this.txtContractReference.Text = "";
      this.lblContractReference.Location = new System.Drawing.Point(14, 25);
      this.lblContractReference.Name = "lblContractReference";
      this.lblContractReference.Size = new Size(118, 20);
      this.lblContractReference.TabIndex = 52;
      this.lblContractReference.Text = "Contract Reference";
      this.Controls.Add((Control) this.grpQuoteContractOption3);
      this.Name = nameof (UCQuoteContractOption3Convert);
      this.Size = new Size(921, 616);
      this.grpQuoteContractOption3.ResumeLayout(false);
      this.grpAssets.ResumeLayout(false);
      this.dgAssets.EndInit();
      this.gpbSite.ResumeLayout(false);
      this.dgSites.EndInit();
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
        return (object) this.CurrentQuoteContractOption3;
      }
    }

    private bool Loading
    {
      get
      {
        return this._loading;
      }
      set
      {
        this._loading = value;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public QuoteContractOption3 CurrentQuoteContractOption3
    {
      get
      {
        return this._currentQuoteContractOption3;
      }
      set
      {
        this._currentQuoteContractOption3 = value;
        if (this._currentQuoteContractOption3 == null)
        {
          this._currentQuoteContractOption3 = new QuoteContractOption3();
          this._currentQuoteContractOption3.Exists = false;
        }
        if (this.CurrentQuoteContractOption3.Exists)
        {
          this.Loading = true;
          this.Populate(0);
          this.gpbSite.Enabled = true;
          this.lblMsg.Visible = false;
          this.Loading = false;
        }
        else
        {
          this.gpbSite.Enabled = false;
          this.lblMsg.Visible = true;
          this.txtContractPrice.Text = Strings.Format((object) 0.0, "C");
        }
        this.Sites = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_GetSelected_ForQuoteContract(this.CurrentQuoteContractOption3.QuoteContractID);
        IEnumerator enumerator;
        try
        {
          enumerator = this.Sites.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            this.SetAssetsDurations = (object) App.DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(Conversions.ToInteger(current["QuoteContractSiteID"]));
            this.SetAssets = (object) this.CreateAssetDataView(Conversions.ToInteger(current["SiteID"]), Conversions.ToInteger(current["QuoteContractSiteID"]));
            this.Visits.Add((object) new ArrayList());
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
    }

    private DataView Sites
    {
      get
      {
        return this._Sites;
      }
      set
      {
        this._Sites = value;
        this._Sites.Table.TableName = Enums.TableNames.tblQuoteContractOption3Site.ToString();
        this._Sites.AllowNew = false;
        this._Sites.AllowEdit = true;
        this._Sites.AllowDelete = false;
        this.dgSites.DataSource = (object) this.Sites;
      }
    }

    private DataRow SelectedSiteDataRow
    {
      get
      {
        return this.dgSites.CurrentRowIndex != -1 ? this.Sites[this.dgSites.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private ArrayList Assets
    {
      get
      {
        return this._Assets;
      }
    }

    private object SetAssets
    {
      set
      {
        NewLateBinding.LateSetComplex(NewLateBinding.LateGet(value, (System.Type) null, "Table", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "TableName", new object[1]
        {
          (object) Enums.TableNames.tblAsset.ToString()
        }, (string[]) null, (System.Type[]) null, false, true);
        NewLateBinding.LateSet(value, (System.Type) null, "AllowNew", new object[1]
        {
          (object) false
        }, (string[]) null, (System.Type[]) null);
        NewLateBinding.LateSet(value, (System.Type) null, "AllowEdit", new object[1]
        {
          (object) true
        }, (string[]) null, (System.Type[]) null);
        NewLateBinding.LateSet(value, (System.Type) null, "AllowDelete", new object[1]
        {
          (object) false
        }, (string[]) null, (System.Type[]) null);
        this._Assets.Add(RuntimeHelpers.GetObjectValue(value));
      }
    }

    public ArrayList AssetsDurations
    {
      get
      {
        return this._AssetsDurations;
      }
    }

    private object SetAssetsDurations
    {
      set
      {
        NewLateBinding.LateSetComplex(NewLateBinding.LateGet(value, (System.Type) null, "Table", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "TableName", new object[1]
        {
          (object) Enums.TableNames.tblAsset.ToString()
        }, (string[]) null, (System.Type[]) null, false, true);
        NewLateBinding.LateSet(value, (System.Type) null, "AllowNew", new object[1]
        {
          (object) false
        }, (string[]) null, (System.Type[]) null);
        NewLateBinding.LateSet(value, (System.Type) null, "AllowEdit", new object[1]
        {
          (object) true
        }, (string[]) null, (System.Type[]) null);
        NewLateBinding.LateSet(value, (System.Type) null, "AllowDelete", new object[1]
        {
          (object) false
        }, (string[]) null, (System.Type[]) null);
        this._AssetsDurations.Add(RuntimeHelpers.GetObjectValue(value));
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

    public void SetupSitesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSites, false);
      DataGridTableStyle tableStyle = this.dgSites.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgSites.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Property";
      dataGridLabelColumn1.MappingName = "Site";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 250;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Property Reference";
      dataGridLabelColumn2.MappingName = "QuoteContractSiteReference";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridEditableTextBoxColumn editableTextBoxColumn1 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn1.Format = "dd/MM/yyyy";
      editableTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn1.HeaderText = "Start Date";
      editableTextBoxColumn1.MappingName = "StartDate";
      editableTextBoxColumn1.ReadOnly = false;
      editableTextBoxColumn1.Width = 75;
      editableTextBoxColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn1);
      DataGridEditableTextBoxColumn editableTextBoxColumn2 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn2.Format = "dd/MM/yyyy";
      editableTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn2.HeaderText = "End Date";
      editableTextBoxColumn2.MappingName = "EndDate";
      editableTextBoxColumn2.ReadOnly = false;
      editableTextBoxColumn2.Width = 75;
      editableTextBoxColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn2);
      DataGridEditableTextBoxColumn editableTextBoxColumn3 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn3.Format = "dd/MM/yyyy";
      editableTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn3.HeaderText = "First Visit Date";
      editableTextBoxColumn3.MappingName = "FirstVisitDate";
      editableTextBoxColumn3.ReadOnly = false;
      editableTextBoxColumn3.Width = 120;
      editableTextBoxColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn3);
      DataGridComboBoxColumn gridComboBoxColumn1 = new DataGridComboBoxColumn(false);
      gridComboBoxColumn1.HeaderText = "Visit Frequency";
      gridComboBoxColumn1.MappingName = "VisitFrequencyID";
      gridComboBoxColumn1.ReadOnly = false;
      gridComboBoxColumn1.Width = 100;
      gridComboBoxColumn1.ComboBox.DataSource = (object) App.DB.QuoteContractOption3.VisitFrequency_Get();
      gridComboBoxColumn1.ComboBox.DisplayMember = "DisplayMember";
      gridComboBoxColumn1.ComboBox.ValueMember = "VisitFrequencyID";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn1);
      DataGridComboBoxColumn gridComboBoxColumn2 = new DataGridComboBoxColumn(false);
      gridComboBoxColumn2.HeaderText = "Invoice Frequency";
      gridComboBoxColumn2.MappingName = "InvoiceFrequencyID";
      gridComboBoxColumn2.ReadOnly = false;
      gridComboBoxColumn2.Width = 120;
      gridComboBoxColumn2.ComboBox.DataSource = (object) App.DB.QuoteContractOption3.InvoiceFrequency_Get();
      gridComboBoxColumn2.ComboBox.DisplayMember = "DisplayMember";
      gridComboBoxColumn2.ComboBox.ValueMember = "InvoiceFrequencyID";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn2);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblQuoteContractOption3Site.ToString();
      this.dgSites.TableStyles.Add(tableStyle);
    }

    public void SetupAssetsDataGrid(DateTime startdate, DateTime enddate)
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
      int int32 = Convert.ToInt32(Math.Ceiling(new Decimal(DateAndTime.DateDiff(DateInterval.Month, startdate, enddate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))));
      int months = 0;
      while (months <= int32)
      {
        Contract3AssetsColourColumnConvert colourColumnConvert = new Contract3AssetsColourColumnConvert();
        colourColumnConvert.theUserControl = (object) this;
        colourColumnConvert.HeaderText = Strings.Format((object) startdate.AddMonths(months), "MMM yy");
        colourColumnConvert.MappingName = Strings.Format((object) startdate.AddMonths(months), "MMM yy");
        colourColumnConvert.ReadOnly = false;
        colourColumnConvert.Width = 50;
        colourColumnConvert.NullText = "-";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) colourColumnConvert);
        checked { ++months; }
      }
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblAsset.ToString();
      this.dgAssets.TableStyles.Add(tableStyle);
    }

    private void UCQuoteContractOption3_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
      this.SetupSitesDataGrid();
    }

    private void txtQuoteContractPrice_LostFocus(object sender, EventArgs e)
    {
      this.txtContractPrice.Text = this.txtContractPrice.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtContractPrice.Text.Replace("£", "")) ? Strings.Format((object) Conversions.ToDouble(this.txtContractPrice.Text.Replace("£", "")), "C") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
    }

    private void dgSites_Click(object sender, EventArgs e)
    {
      if (this.SelectedSiteDataRow == null)
        return;
      this.grpAssets.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Assets for ", this.SelectedSiteDataRow["Site"]));
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelectedSiteDataRow["StartDate"])) & !Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelectedSiteDataRow["EndDate"])))
      {
        this.Assets[this.dgSites.CurrentRowIndex] = (object) this.CreateAssetDataView(Conversions.ToInteger(this.SelectedSiteDataRow["SiteID"]), Conversions.ToInteger(this.SelectedSiteDataRow["QuoteContractSiteID"]));
        this.dgAssets.DataSource = RuntimeHelpers.GetObjectValue(this.Assets[this.dgSites.CurrentRowIndex]);
      }
      else
        this.dgAssets.DataSource = (object) null;
    }

    private void btnContractNumber_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMAvailableContractNos), true, new object[2]
      {
        (object) this.txtContractReference,
        (object) this
      }, false);
    }

    public void UpdateDurations(double Duration, DateTime mappingName)
    {
      bool flag = false;
      DataView assetsDuration = (DataView) this.AssetsDurations[this.dgSites.CurrentRowIndex];
      IEnumerator enumerator;
      try
      {
        enumerator = assetsDuration.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["CompareMonth"], (object) Strings.Format((object) mappingName, "yyyyMM"), false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AssetID"], ((DataView) this.dgAssets.DataSource).Table.Rows[this.dgAssets.CurrentRowIndex]["AssetID"], false))))
          {
            current["visitDuration"] = (object) Duration;
            flag = true;
            break;
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (!flag)
      {
        DataRow row = assetsDuration.Table.NewRow();
        row["CompareMonth"] = (object) Strings.Format((object) mappingName, "yyyyMM");
        row["AssetID"] = RuntimeHelpers.GetObjectValue(((DataView) this.dgAssets.DataSource).Table.Rows[this.dgAssets.CurrentRowIndex]["AssetID"]);
        row["visitDuration"] = (object) Duration;
        row["ScheduledMonth"] = (object) mappingName;
        assetsDuration.Table.Rows.Add(row);
      }
      this.AssetsDurations[this.dgSites.CurrentRowIndex] = (object) assetsDuration;
    }

    private DataView CreateAssetDataView(int siteID, int quoteContractSiteID)
    {
      DateTime minValue = DateTime.MinValue;
      int num1 = 0;
      DataView dataView = new DataView();
      DataView forSite = App.DB.Asset.Asset_GetForSite(siteID);
      int int32 = Convert.ToInt32(Math.Ceiling(new Decimal(DateAndTime.DateDiff(DateInterval.Month, Conversions.ToDate(this.SelectedSiteDataRow["StartDate"]), Conversions.ToDate(this.SelectedSiteDataRow["EndDate"]), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1))));
      ArrayList arrayList = new ArrayList();
      int num2 = int32;
      int num3 = 0;
      while (num3 <= num2)
      {
        DataColumnCollection columns = forSite.Table.Columns;
        object[] objArray;
        bool[] flagArray;
        object obj = NewLateBinding.LateGet(this.SelectedSiteDataRow["StartDate"], (System.Type) null, "AddMonths", objArray = new object[1]
        {
          (object) num3
        }, (string[]) null, (System.Type[]) null, flagArray = new bool[1]
        {
          true
        });
        if (flagArray[0])
          num3 = (int) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof (int));
        string columnName = Strings.Format(RuntimeHelpers.GetObjectValue(obj), "MMM yy");
        columns.Add(columnName);
        checked { ++num3; }
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(this.SelectedSiteDataRow["VisitFrequencyID"], (object) 0, false) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreaterEqual(NewLateBinding.LateGet(this.SelectedSiteDataRow["FirstVisitDate"], (System.Type) null, "Date", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), NewLateBinding.LateGet(this.SelectedSiteDataRow["StartDate"], (System.Type) null, "Date", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLessEqual(NewLateBinding.LateGet(this.SelectedSiteDataRow["FirstVisitDate"], (System.Type) null, "Date", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), NewLateBinding.LateGet(this.SelectedSiteDataRow["EndDate"], (System.Type) null, "Date", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), false))))
      {
        num1 = 0;
        int months = 0;
        switch (Conversions.ToInteger(this.SelectedSiteDataRow["VisitFrequencyID"]))
        {
          case 4:
            months = 1;
            break;
          case 5:
            months = 3;
            break;
          case 6:
            months = 6;
            break;
          case 7:
            months = 12;
            break;
        }
        int num4 = checked ((int) Math.Ceiling(unchecked ((double) DateAndTime.DateDiff(DateInterval.Month, Conversions.ToDate(this.SelectedSiteDataRow["StartDate"]), Conversions.ToDate(this.SelectedSiteDataRow["EndDate"]), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / (double) months)));
        if (num4 == 0)
          num4 = 1;
        DateTime t1 = Conversions.ToDate(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(NewLateBinding.LateGet(this.SelectedSiteDataRow["FirstVisitDate"], (System.Type) null, "Date", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) " 09:00:00"));
        int num5 = num4;
        int num6 = 1;
        while (num6 <= num5)
        {
          if (DateTime.Compare(t1, Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.SelectedSiteDataRow["StartDate"], (System.Type) null, "Date", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null)), "dd/MM/yyyy") + " 09:00")) >= 0 & DateTime.Compare(t1, Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.SelectedSiteDataRow["EndDate"], (System.Type) null, "Date", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null)), "dd/MM/yyyy") + " 09:00")) <= 0)
          {
            DateTime dateTime = t1;
            if (t1.DayOfWeek == DayOfWeek.Saturday)
              t1 = t1.AddDays(2.0);
            else if (t1.DayOfWeek == DayOfWeek.Sunday)
              t1 = t1.AddDays(1.0);
            IEnumerator enumerator;
            try
            {
              enumerator = forSite.Table.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                DataRow[] dataRowArray = ((DataView) this.AssetsDurations[this.dgSites.CurrentRowIndex]).Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("CompareMonth=" + Strings.Format((object) t1, "yyyyMM") + " AND AssetID="), current["AssetID"])));
                if (dataRowArray.Length > 0)
                  current[Strings.Format((object) t1, "MMM yy")] = RuntimeHelpers.GetObjectValue(dataRowArray[0]["VisitDuration"]);
                else
                  current[Strings.Format((object) t1, "MMM yy")] = (object) "0";
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            arrayList.Add((object) t1);
            t1 = dateTime.AddMonths(months);
          }
          checked { ++num6; }
        }
      }
      if (this.Visits.Count > 0)
        this.Visits[this.dgSites.CurrentRowIndex] = (object) arrayList;
      this.SetupAssetsDataGrid(Conversions.ToDate(this.SelectedSiteDataRow["StartDate"]), Conversions.ToDate(this.SelectedSiteDataRow["EndDate"]));
      this.Cursor = Cursors.Default;
      forSite.AllowDelete = false;
      forSite.AllowEdit = true;
      forSite.AllowNew = false;
      return forSite;
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.QuoteContractOption3_Get(ID);
      this.txtContractReference.Text = this.CurrentQuoteContractOption3.QuoteContractReference;
      this.txtContractPrice.Text = Strings.Format((object) this.CurrentQuoteContractOption3.QuoteContractPrice, "C");
      ComboBox cboContractStatus = this.cboContractStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboContractStatus, Conversions.ToString(3));
      this.cboContractStatus = cboContractStatus;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        ContractOption3 oContractOption3 = new ContractOption3();
        oContractOption3.SetContractPrice = (object) this.txtContractPrice.Text.Trim().Replace("£", "");
        oContractOption3.SetContractReference = (object) this.txtContractReference.Text;
        oContractOption3.SetContractStatusID = (object) Combo.get_GetSelectedItemValue(this.cboContractStatus);
        oContractOption3.SetCustomerID = (object) this.CurrentQuoteContractOption3.CustomerID;
        oContractOption3.SetQuoteContractID = (object) this.CurrentQuoteContractOption3.QuoteContractID;
        new ContractOption3Validator().Validate(oContractOption3);
        ContractOption3SiteValidator option3SiteValidator = new ContractOption3SiteValidator();
        int index = 0;
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.Sites.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            option3SiteValidator.Validate(new ContractOption3Site()
            {
              SetContractSiteReference = RuntimeHelpers.GetObjectValue(current["QuoteContractSiteReference"]),
              SetInvoiceFrequencyID = RuntimeHelpers.GetObjectValue(current["InvoiceFrequencyID"]),
              SetPropertyID = RuntimeHelpers.GetObjectValue(current["SiteID"]),
              SetSitePrice = RuntimeHelpers.GetObjectValue(current["SitePrice"]),
              SetVisitFrequencyID = RuntimeHelpers.GetObjectValue(current["VisitFrequencyID"]),
              StartDate = Conversions.ToDate(current["StartDate"]),
              EndDate = Conversions.ToDate(current["EndDate"]),
              FirstVisitDate = Conversions.ToDate(current["FirstVisitDate"]),
              FirstInvoiceDate = Conversions.ToDate(current["FirstVisitDate"]),
              SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(current["SiteID"]),
              SetInvoiceAddressTypeID = (object) 253
            }, (DataView) this.Assets[index]);
            checked { ++index; }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        ContractOption3 curContract = App.DB.ContractOption3.Insert(oContractOption3);
        int currentSiteRow = 0;
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.Sites.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            ContractOption3Site contractOption3Site = App.DB.ContractOption3Site.Insert(new ContractOption3Site()
            {
              SetContractSiteReference = RuntimeHelpers.GetObjectValue(current["QuoteContractSiteReference"]),
              SetInvoiceFrequencyID = RuntimeHelpers.GetObjectValue(current["InvoiceFrequencyID"]),
              SetPropertyID = RuntimeHelpers.GetObjectValue(current["SiteID"]),
              SetSitePrice = RuntimeHelpers.GetObjectValue(current["SitePrice"]),
              SetVisitFrequencyID = RuntimeHelpers.GetObjectValue(current["VisitFrequencyID"]),
              StartDate = Conversions.ToDate(current["StartDate"]),
              EndDate = Conversions.ToDate(current["EndDate"]),
              FirstVisitDate = Conversions.ToDate(current["FirstVisitDate"]),
              SetContractID = (object) curContract.ContractID,
              FirstInvoiceDate = Conversions.ToDate(current["FirstVisitDate"]),
              SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(current["SiteID"]),
              SetInvoiceAddressTypeID = (object) 253
            });
            this.InsertInvoiceToBeRaiseLines(contractOption3Site);
            App.DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_Delete(contractOption3Site.ContractSiteID);
            IEnumerator enumerator3;
            try
            {
              enumerator3 = ((IEnumerable) this.Visits[currentSiteRow]).GetEnumerator();
              while (enumerator3.MoveNext())
              {
                object objectValue = RuntimeHelpers.GetObjectValue(enumerator3.Current);
                Job job1 = new Job();
                Job job2 = this.CreateJob(Conversions.ToDate(objectValue), contractOption3Site, currentSiteRow, curContract);
                App.DB.ContractOption3SitePPMVisit.Insert(new ContractOption3SitePPMVisit()
                {
                  SetContractSiteID = (object) contractOption3Site.ContractSiteID,
                  VisitDate = Conversions.ToDate(objectValue),
                  SetJobID = (object) job2.JobID
                });
              }
            }
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
            checked { ++currentSiteRow; }
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentQuoteContractOption3.QuoteContractID);
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

    private void InsertInvoiceToBeRaiseLines(ContractOption3Site CurrentContractOption3Site)
    {
      int num1 = 0;
      switch (CurrentContractOption3Site.InvoiceFrequencyID)
      {
        case 1:
          num1 = checked ((int) Math.Round(unchecked ((double) DateAndTime.DateDiff(DateInterval.Day, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 7.0)));
          break;
        case 2:
          num1 = checked ((int) DateAndTime.DateDiff(DateInterval.Month, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          break;
        case 3:
          num1 = checked ((int) Math.Round(unchecked ((double) DateAndTime.DateDiff(DateInterval.Month, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 3.0)));
          break;
        case 4:
          num1 = checked ((int) (DateAndTime.DateDiff(DateInterval.Year, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) * 2L));
          break;
        case 6:
          num1 = checked ((int) DateAndTime.DateDiff(DateInterval.Year, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          break;
      }
      DateTime dateTime = CurrentContractOption3Site.FirstInvoiceDate;
      int num2 = num1;
      int num3 = 1;
      while (num3 <= num2)
      {
        App.DB.InvoiceToBeRaised.Insert(new InvoiceToBeRaised()
        {
          SetAddressLinkID = (object) CurrentContractOption3Site.InvoiceAddressID,
          SetAddressTypeID = (object) CurrentContractOption3Site.InvoiceAddressTypeID,
          SetInvoiceTypeID = (object) 330,
          SetLinkID = (object) CurrentContractOption3Site.ContractSiteID,
          RaiseDate = dateTime
        });
        switch (CurrentContractOption3Site.InvoiceFrequencyID)
        {
          case 1:
            dateTime = dateTime.AddDays(7.0);
            break;
          case 2:
            dateTime = dateTime.AddMonths(1);
            break;
          case 3:
            dateTime = dateTime.AddMonths(3);
            break;
          case 4:
            dateTime = dateTime.AddMonths(6);
            break;
          case 6:
            dateTime = dateTime.AddYears(1);
            break;
        }
        checked { ++num3; }
      }
    }

    private Job CreateJob(
      DateTime vDate,
      ContractOption3Site newSite,
      int currentSiteRow,
      ContractOption3 curContract)
    {
      double num1 = 0.0;
      DateTime minValue1 = DateTime.MinValue;
      DateTime minValue2 = DateTime.MinValue;
      int num2 = 0;
      Job oJob = new Job();
      oJob.SetContractID = (object) newSite.ContractID;
      oJob.SetCreatedByUserID = (object) App.loggedInUser.UserID;
      oJob.SetJobDefinitionEnumID = (object) Helper.MakeIntegerValid((object) Enums.JobDefinition.Contract);
      JobNumber jobNumber = new JobNumber();
      JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
      oJob.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
      oJob.SetPONumber = (object) "";
      oJob.SetQuoteID = (object) 0;
      oJob.SetPropertyID = (object) newSite.PropertyID;
      oJob.SetStatusEnumID = (object) Helper.MakeIntegerValid((object) Enums.JobStatus.Open);
      oJob.DateCreated = DateAndTime.Now;
      if (curContract.ContractStatusID == 4)
        oJob.SetDeleted = true;
      IEnumerator enumerator;
      try
      {
        enumerator = ((DataView) this.Assets[currentSiteRow]).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current[Strings.Format((object) vDate, "MMM yy")], (object) 0, false))
          {
            App.DB.ContractOption3SiteAsset.Insert(new FSM.Entity.ContractOption3SiteAsset.ContractOption3SiteAsset()
            {
              SetContractSiteID = (object) newSite.ContractSiteID,
              SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"]),
              ScheduledMonth = vDate,
              SetVisitDuration = RuntimeHelpers.GetObjectValue(current[Strings.Format((object) vDate, "MMM yy")])
            });
            oJob.Assets.Add((object) new JobAsset()
            {
              SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"])
            });
            num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current[Strings.Format((object) vDate, "MMM yy")]));
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      JobOfWork jobOfWork = new JobOfWork();
      jobOfWork.IgnoreExceptionsOnSetMethods = true;
      if (curContract.ContractStatusID == 4)
        jobOfWork.SetDeleted = true;
      jobOfWork.JobItems.Add((object) new JobItem()
      {
        IgnoreExceptionsOnSetMethods = true,
        SetSummary = (object) Helper.MakeStringValid((object) "PPM Contract Visit")
      });
      Settings settings1 = new Settings();
      Settings settings2 = App.DB.Manager.Get();
      double timeSlot = (double) settings2.TimeSlot;
      int num3;
      if (num1 > 0.0)
      {
        num2 = checked ((int) Math.Round(unchecked (num1 * 60.0)));
        num3 = checked ((int) Math.Round(unchecked ((double) num2 / timeSlot)));
      }
      else
        num3 = 1;
      double num4 = (double) DateAndTime.DateDiff(DateInterval.Minute, Helper.MakeDateTimeValid((object) ("01/01/1900 " + settings2.WorkingHoursStart)), Helper.MakeDateTimeValid((object) ("01/01/1900 " + settings2.WorkingHoursEnd)), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
      int numOfSlotsInADay = checked ((int) Math.Round(unchecked (num4 / timeSlot)));
      int numOfDaysNeeded = checked ((int) Math.Ceiling(unchecked ((double) num3 / (double) numOfSlotsInADay)));
      ArrayList arrayList = new ArrayList();
      ArrayList engineersAndVisits = this.GetEngineersAndVisits(numOfDaysNeeded, numOfSlotsInADay, vDate, newSite);
      int num5 = checked (numOfDaysNeeded - 1);
      int index = 0;
      while (index <= num5)
      {
        EngineerVisit engineerVisit = new EngineerVisit();
        engineerVisit.IgnoreExceptionsOnSetMethods = true;
        try
        {
          engineerVisit.SetEngineerID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(((ArrayList) engineersAndVisits[index])[1]));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          engineerVisit.SetEngineerID = (object) 0;
          ProjectData.ClearProjectError();
        }
        engineerVisit.SetNotesToEngineer = (object) "PPM Contract Visit";
        if (engineerVisit.EngineerID > 0)
        {
          engineerVisit.StartDateTime = Conversions.ToDate(((ArrayList) engineersAndVisits[index])[0]);
          if ((double) num2 > num4)
          {
            engineerVisit.EndDateTime = Conversions.ToDate(NewLateBinding.LateGet(((ArrayList) engineersAndVisits[index])[0], (System.Type) null, "AddHours", new object[1]
            {
              (object) Math.Ceiling(num4 / 60.0)
            }, (string[]) null, (System.Type[]) null, (bool[]) null));
            num2 = checked ((int) Math.Round(unchecked ((double) num2 - num4)));
          }
          else
            engineerVisit.EndDateTime = Conversions.ToDate(NewLateBinding.LateGet(((ArrayList) engineersAndVisits[index])[0], (System.Type) null, "AddHours", new object[1]
            {
              (object) Math.Ceiling((double) num2 / 60.0)
            }, (string[]) null, (System.Type[]) null, (bool[]) null));
          engineerVisit.SetStatusEnumID = (object) 5;
        }
        else
        {
          engineerVisit.StartDateTime = DateTime.MinValue;
          engineerVisit.EndDateTime = DateTime.MinValue;
          engineerVisit.SetStatusEnumID = (object) 4;
        }
        jobOfWork.EngineerVisits.Add((object) engineerVisit);
        checked { ++index; }
      }
      oJob.JobOfWorks.Add((object) jobOfWork);
      return App.DB.Job.Insert(oJob);
    }

    private ArrayList GetEngineersAndVisits(
      int numOfDaysNeeded,
      int numOfSlotsInADay,
      DateTime estVisitDate,
      ContractOption3Site newSite)
    {
      FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
      ArrayList arrayList = new ArrayList();
      FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) newSite.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
      if (site2.EngineerID > 0)
        arrayList = this.CheckAvailability(estVisitDate, site2.EngineerID, numOfDaysNeeded, numOfSlotsInADay);
      if (arrayList.Count > 0)
        return arrayList;
      string str = site2.Postcode.Replace("-", "").Replace(" ", "");
      string Postcode = str.Substring(0, checked (str.Length - 3));
      DataView forPostcode = App.DB.EngineerPostalRegion.EngineerPostalRegion_Get_For_Postcode(Postcode);
      int count = forPostcode.Table.Rows.Count;
      if (count > 0)
      {
        int num1 = checked (count - 1);
        int num2 = 0;
        while (num2 <= num1)
        {
          VBMath.Randomize();
          int index = checked ((int) Conversion.Int((float) unchecked ((double) forPostcode.Table.Rows.Count * (double) VBMath.Rnd() + 1.0)) - 1);
          arrayList = this.CheckAvailability(estVisitDate, Conversions.ToInteger(forPostcode.Table.Rows[index]["EngineerID"]), numOfDaysNeeded, numOfSlotsInADay);
          if (arrayList.Count > 0)
            return arrayList;
          forPostcode.Table.Rows.Remove(forPostcode.Table.Rows[index]);
          checked { ++num2; }
        }
      }
      return arrayList;
    }

    private ArrayList CheckAvailability(
      DateTime estimatedVisitDate,
      int engineerID,
      int numOfDaysNeeded,
      int numOfSlotsInADay)
    {
      ArrayList arrayList1 = new ArrayList();
      DateTime day = estimatedVisitDate;
      ArrayList arrayList2 = new ArrayList();
      int num1 = 0;
      do
      {
        arrayList2.Clear();
        int num2 = 0;
        if ((uint) num1 > 0U)
          day = estimatedVisitDate.AddDays(1.0);
        int num3 = numOfDaysNeeded;
        int num4 = 1;
        while (num4 <= num3)
        {
          arrayList1.Clear();
          if (num4 != 1)
            day = day.AddDays(1.0);
          if (day.DayOfWeek == DayOfWeek.Saturday)
            day = day.AddDays(2.0);
          if (day.DayOfWeek == DayOfWeek.Saturday)
            day = day.AddDays(1.0);
          DataTable dataTable = App.DB.Scheduler.Scheduler_DayTimeSlots(day, Conversions.ToString(engineerID));
          if (dataTable.Rows.Count > 0)
          {
            int num5 = checked (dataTable.Columns.Count - 1);
            int index = 0;
            while (index <= num5)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataTable.Rows[0][index], (object) 0, false))
              {
                arrayList1.Add((object) dataTable.Columns[index].ColumnName);
                if (arrayList1.Count == numOfSlotsInADay)
                  break;
              }
              else
                arrayList1.Clear();
              checked { ++index; }
            }
          }
          else
            arrayList1.Add((object) App.DB.Manager.Get().WorkingHoursStart);
          if (arrayList1.Count > 0)
          {
            ArrayList arrayList3 = new ArrayList();
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (arrayList1.Count == numOfSlotsInADay), Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(arrayList1[0], (object) App.DB.Manager.Get().WorkingHoursStart, false), (object) (arrayList1.Count == 1)))))
            {
              string str = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(arrayList1[0], (object) App.DB.Manager.Get().WorkingHoursStart, false) ? Strings.Replace(Conversions.ToString(arrayList1[0]), "T", "", 1, -1, CompareMethod.Binary).Insert(2, ":") : Conversions.ToString(arrayList1[0]);
              day = Conversions.ToDate(Strings.Format((object) day, "dd/MM/yyyy") + " " + str);
              arrayList3.Add((object) day);
              arrayList3.Add((object) engineerID);
              arrayList2.Add((object) arrayList3);
              checked { ++num2; }
            }
            else
            {
              arrayList3.Add((object) null);
              arrayList3.Add((object) 0);
              arrayList2.Add((object) arrayList3);
            }
          }
          if (num2 == num4)
            checked { ++num4; }
          else
            break;
        }
        if (num2 == numOfDaysNeeded)
          return arrayList2;
        checked { ++num1; }
      }
      while (num1 <= 4);
      return arrayList2;
    }
  }
}
