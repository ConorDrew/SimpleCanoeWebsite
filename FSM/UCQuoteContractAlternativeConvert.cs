// Decompiled with JetBrains decompiler
// Type: FSM.UCQuoteContractAlternativeConvert
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractAlternativePPMVisits;
using FSM.Entity.ContractAlternativeSiteAssets;
using FSM.Entity.ContractAlternativeSiteJobOfWorks;
using FSM.Entity.ContractAlternativeSites;
using FSM.Entity.ContractsAlternative;
using FSM.Entity.EngineerVisits;
using FSM.Entity.InvoiceToBeRaiseds;
using FSM.Entity.JobAssets;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.QuoteContractAlternatives;
using FSM.Entity.QuoteContractAlternativeSiteJobOfWorks;
using FSM.Entity.QuoteContractAlternativeSites;
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
  public class UCQuoteContractAlternativeConvert : UCBase, IUserControl
  {
    private IContainer components;
    private QuoteContractAlternative _currentQuoteContract;
    private DataView _Sites;
    private ArrayList _SiteArray;
    public bool IsLoading;
    private DataView _InvoiceAddresses;

    public UCQuoteContractAlternativeConvert()
    {
      this.Load += new EventHandler(this.UCContract_Load);
      this._SiteArray = new ArrayList();
      this.IsLoading = false;
      this.InitializeComponent();
      ComboBox invoiceFrequencyId = this.cboInvoiceFrequencyID;
      Combo.SetUpCombo(ref invoiceFrequencyId, DynamicDataTables.InvoiceFrequency, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboInvoiceFrequencyID = invoiceFrequencyId;
      ComboBox contractStatusId = this.cboContractStatusID;
      Combo.SetUpCombo(ref contractStatusId, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboContractStatusID = contractStatusId;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpContract { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboContractStatusID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractStatusID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInvoiceFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoiceFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSites { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgSites_MouseUp);
        DataGrid dgSites1 = this._dgSites;
        if (dgSites1 != null)
        {
          dgSites1.Click -= eventHandler1;
          dgSites1.CurrentCellChanged -= eventHandler2;
          dgSites1.MouseUp -= mouseEventHandler;
        }
        this._dgSites = value;
        DataGrid dgSites2 = this._dgSites;
        if (dgSites2 == null)
          return;
        dgSites2.Click += eventHandler1;
        dgSites2.CurrentCellChanged += eventHandler2;
        dgSites2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual TextBox txtQuoteContractPrice
    {
      get
      {
        return this._txtQuoteContractPrice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtContractPrice_LostFocus);
        TextBox quoteContractPrice1 = this._txtQuoteContractPrice;
        if (quoteContractPrice1 != null)
          quoteContractPrice1.LostFocus -= eventHandler;
        this._txtQuoteContractPrice = value;
        TextBox quoteContractPrice2 = this._txtQuoteContractPrice;
        if (quoteContractPrice2 == null)
          return;
        quoteContractPrice2.LostFocus += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl TCJobsOfWork { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual DateTimePicker dtpContractStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpContractEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgInvoiceAddress
    {
      get
      {
        return this._dgInvoiceAddress;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgInvoiceAddress_Click);
        DataGrid dgInvoiceAddress1 = this._dgInvoiceAddress;
        if (dgInvoiceAddress1 != null)
          dgInvoiceAddress1.Click -= eventHandler;
        this._dgInvoiceAddress = value;
        DataGrid dgInvoiceAddress2 = this._dgInvoiceAddress;
        if (dgInvoiceAddress2 == null)
          return;
        dgInvoiceAddress2.Click += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpFirstInvoiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpContract = new GroupBox();
      this.grpVisits = new GroupBox();
      this.TCJobsOfWork = new TabControl();
      this.txtQuoteContractPrice = new TextBox();
      this.Label6 = new Label();
      this.grpSites = new GroupBox();
      this.dgSites = new DataGrid();
      this.txtContractReference = new TextBox();
      this.lblContractReference = new Label();
      this.cboContractStatusID = new ComboBox();
      this.lblContractStatusID = new Label();
      this.cboInvoiceFrequencyID = new ComboBox();
      this.lblInvoiceFrequencyID = new Label();
      this.lblContractEndDate = new Label();
      this.btnContractNumber = new Button();
      this.dtpContractStartDate = new DateTimePicker();
      this.lblContractStartDate = new Label();
      this.dtpContractEndDate = new DateTimePicker();
      this.gpbInvoiceAddress = new GroupBox();
      this.dgInvoiceAddress = new DataGrid();
      this.dtpFirstInvoiceDate = new DateTimePicker();
      this.Label1 = new Label();
      this.grpContract.SuspendLayout();
      this.grpVisits.SuspendLayout();
      this.grpSites.SuspendLayout();
      this.dgSites.BeginInit();
      this.gpbInvoiceAddress.SuspendLayout();
      this.dgInvoiceAddress.BeginInit();
      this.SuspendLayout();
      this.grpContract.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContract.Controls.Add((Control) this.gpbInvoiceAddress);
      this.grpContract.Controls.Add((Control) this.dtpFirstInvoiceDate);
      this.grpContract.Controls.Add((Control) this.Label1);
      this.grpContract.Controls.Add((Control) this.grpVisits);
      this.grpContract.Controls.Add((Control) this.txtQuoteContractPrice);
      this.grpContract.Controls.Add((Control) this.grpSites);
      this.grpContract.Controls.Add((Control) this.txtContractReference);
      this.grpContract.Controls.Add((Control) this.lblContractReference);
      this.grpContract.Controls.Add((Control) this.cboContractStatusID);
      this.grpContract.Controls.Add((Control) this.lblContractStatusID);
      this.grpContract.Controls.Add((Control) this.cboInvoiceFrequencyID);
      this.grpContract.Controls.Add((Control) this.lblInvoiceFrequencyID);
      this.grpContract.Controls.Add((Control) this.lblContractEndDate);
      this.grpContract.Controls.Add((Control) this.btnContractNumber);
      this.grpContract.Controls.Add((Control) this.dtpContractStartDate);
      this.grpContract.Controls.Add((Control) this.lblContractStartDate);
      this.grpContract.Controls.Add((Control) this.dtpContractEndDate);
      this.grpContract.Controls.Add((Control) this.Label6);
      this.grpContract.Location = new System.Drawing.Point(8, 0);
      this.grpContract.Name = "grpContract";
      this.grpContract.Size = new Size(968, 664);
      this.grpContract.TabIndex = 0;
      this.grpContract.TabStop = false;
      this.grpContract.Text = "Main Details";
      this.grpVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVisits.Controls.Add((Control) this.TCJobsOfWork);
      this.grpVisits.Location = new System.Drawing.Point(11, 216);
      this.grpVisits.Name = "grpVisits";
      this.grpVisits.Size = new Size(949, 432);
      this.grpVisits.TabIndex = 8;
      this.grpVisits.TabStop = false;
      this.grpVisits.Text = "Jobs Of Work";
      this.TCJobsOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TCJobsOfWork.Location = new System.Drawing.Point(8, 24);
      this.TCJobsOfWork.Name = "TCJobsOfWork";
      this.TCJobsOfWork.SelectedIndex = 0;
      this.TCJobsOfWork.Size = new Size(933, 400);
      this.TCJobsOfWork.TabIndex = 44;
      this.txtQuoteContractPrice.Location = new System.Drawing.Point(136, 64);
      this.txtQuoteContractPrice.MaxLength = 9;
      this.txtQuoteContractPrice.Name = "txtQuoteContractPrice";
      this.txtQuoteContractPrice.Size = new Size(170, 21);
      this.txtQuoteContractPrice.TabIndex = 7;
      this.txtQuoteContractPrice.Tag = (object) "Contract.ContractPrice";
      this.txtQuoteContractPrice.Text = "";
      this.Label6.Location = new System.Drawing.Point(16, 64);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(132, 20);
      this.Label6.TabIndex = 62;
      this.Label6.Text = "Total Contract Price";
      this.grpSites.Controls.Add((Control) this.dgSites);
      this.grpSites.Location = new System.Drawing.Point(11, 112);
      this.grpSites.Name = "grpSites";
      this.grpSites.Size = new Size(949, 104);
      this.grpSites.TabIndex = 7;
      this.grpSites.TabStop = false;
      this.grpSites.Text = "Properties";
      this.dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSites.DataMember = "";
      this.dgSites.HeaderForeColor = SystemColors.ControlText;
      this.dgSites.Location = new System.Drawing.Point(11, 16);
      this.dgSites.Name = "dgSites";
      this.dgSites.Size = new Size(929, 80);
      this.dgSites.TabIndex = 0;
      this.txtContractReference.Location = new System.Drawing.Point(136, 16);
      this.txtContractReference.MaxLength = 100;
      this.txtContractReference.Name = "txtContractReference";
      this.txtContractReference.Size = new Size(170, 21);
      this.txtContractReference.TabIndex = 1;
      this.txtContractReference.Tag = (object) "Contract.ContractReference";
      this.txtContractReference.Text = "";
      this.lblContractReference.Location = new System.Drawing.Point(17, 16);
      this.lblContractReference.Name = "lblContractReference";
      this.lblContractReference.Size = new Size(139, 20);
      this.lblContractReference.TabIndex = 31;
      this.lblContractReference.Text = "Contract Reference";
      this.cboContractStatusID.Cursor = Cursors.Hand;
      this.cboContractStatusID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboContractStatusID.Location = new System.Drawing.Point(136, 40);
      this.cboContractStatusID.Name = "cboContractStatusID";
      this.cboContractStatusID.Size = new Size(170, 21);
      this.cboContractStatusID.TabIndex = 3;
      this.cboContractStatusID.Tag = (object) "Contract.ContractStatusID";
      this.lblContractStatusID.Location = new System.Drawing.Point(16, 40);
      this.lblContractStatusID.Name = "lblContractStatusID";
      this.lblContractStatusID.Size = new Size(139, 20);
      this.lblContractStatusID.TabIndex = 31;
      this.lblContractStatusID.Text = "Contract Status";
      this.cboInvoiceFrequencyID.Cursor = Cursors.Hand;
      this.cboInvoiceFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInvoiceFrequencyID.Location = new System.Drawing.Point(136, 88);
      this.cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID";
      this.cboInvoiceFrequencyID.Size = new Size(170, 21);
      this.cboInvoiceFrequencyID.TabIndex = 6;
      this.cboInvoiceFrequencyID.Tag = (object) "Contract.InvoiceFrequencyID";
      this.lblInvoiceFrequencyID.Location = new System.Drawing.Point(16, 88);
      this.lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID";
      this.lblInvoiceFrequencyID.Size = new Size(139, 20);
      this.lblInvoiceFrequencyID.TabIndex = 4;
      this.lblInvoiceFrequencyID.Text = "Invoice Frequency";
      this.lblContractEndDate.Location = new System.Drawing.Point(312, 64);
      this.lblContractEndDate.Name = "lblContractEndDate";
      this.lblContractEndDate.Size = new Size(56, 20);
      this.lblContractEndDate.TabIndex = 49;
      this.lblContractEndDate.Text = "End Date";
      this.btnContractNumber.UseVisualStyleBackColor = true;
      this.btnContractNumber.Location = new System.Drawing.Point(312, 15);
      this.btnContractNumber.Name = "btnContractNumber";
      this.btnContractNumber.Size = new Size(208, 23);
      this.btnContractNumber.TabIndex = 2;
      this.btnContractNumber.Text = "Next Suggested Contract Number";
      this.dtpContractStartDate.Format = DateTimePickerFormat.Short;
      this.dtpContractStartDate.Location = new System.Drawing.Point(400, 40);
      this.dtpContractStartDate.Name = "dtpContractStartDate";
      this.dtpContractStartDate.Size = new Size(120, 21);
      this.dtpContractStartDate.TabIndex = 4;
      this.dtpContractStartDate.Tag = (object) "Contract.ContractStartDate";
      this.lblContractStartDate.Location = new System.Drawing.Point(312, 40);
      this.lblContractStartDate.Name = "lblContractStartDate";
      this.lblContractStartDate.Size = new Size(64, 20);
      this.lblContractStartDate.TabIndex = 46;
      this.lblContractStartDate.Text = "Start Date";
      this.dtpContractEndDate.Format = DateTimePickerFormat.Short;
      this.dtpContractEndDate.Location = new System.Drawing.Point(400, 64);
      this.dtpContractEndDate.Name = "dtpContractEndDate";
      this.dtpContractEndDate.Size = new Size(120, 21);
      this.dtpContractEndDate.TabIndex = 5;
      this.dtpContractEndDate.Tag = (object) "Contract.ContractEndDate";
      this.gpbInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbInvoiceAddress.Controls.Add((Control) this.dgInvoiceAddress);
      this.gpbInvoiceAddress.Location = new System.Drawing.Point(528, 8);
      this.gpbInvoiceAddress.Name = "gpbInvoiceAddress";
      this.gpbInvoiceAddress.Size = new Size(432, 104);
      this.gpbInvoiceAddress.TabIndex = 64;
      this.gpbInvoiceAddress.TabStop = false;
      this.gpbInvoiceAddress.Text = "Invoice Address";
      this.dgInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgInvoiceAddress.DataMember = "";
      this.dgInvoiceAddress.HeaderForeColor = SystemColors.ControlText;
      this.dgInvoiceAddress.Location = new System.Drawing.Point(8, 20);
      this.dgInvoiceAddress.Name = "dgInvoiceAddress";
      this.dgInvoiceAddress.Size = new Size(416, 76);
      this.dgInvoiceAddress.TabIndex = 0;
      this.dtpFirstInvoiceDate.Format = DateTimePickerFormat.Short;
      this.dtpFirstInvoiceDate.Location = new System.Drawing.Point(400, 88);
      this.dtpFirstInvoiceDate.Name = "dtpFirstInvoiceDate";
      this.dtpFirstInvoiceDate.Size = new Size(120, 21);
      this.dtpFirstInvoiceDate.TabIndex = 63;
      this.dtpFirstInvoiceDate.Tag = (object) "";
      this.Label1.Location = new System.Drawing.Point(312, 88);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(107, 20);
      this.Label1.TabIndex = 65;
      this.Label1.Text = "First Inv. Date";
      this.Controls.Add((Control) this.grpContract);
      this.Name = nameof (UCQuoteContractAlternativeConvert);
      this.Size = new Size(983, 675);
      this.grpContract.ResumeLayout(false);
      this.grpVisits.ResumeLayout(false);
      this.grpSites.ResumeLayout(false);
      this.dgSites.EndInit();
      this.gpbInvoiceAddress.ResumeLayout(false);
      this.dgInvoiceAddress.EndInit();
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
        return (object) this.CurrentQuoteContract;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public QuoteContractAlternative CurrentQuoteContract
    {
      get
      {
        return this._currentQuoteContract;
      }
      set
      {
        this._currentQuoteContract = value;
        if (this._currentQuoteContract == null)
        {
          this._currentQuoteContract = new QuoteContractAlternative();
          this._currentQuoteContract.Exists = false;
        }
        this.Populate(0);
        this.Sites = App.DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(this._currentQuoteContract.QuoteContractID, this._currentQuoteContract.CustomerID);
        this.InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(this._currentQuoteContract.CustomerID);
        IEnumerator enumerator;
        try
        {
          enumerator = this.Sites.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            this.SiteArray.Add((object) App.DB.QuoteContractAlternativeSite.Get(Conversions.ToInteger(current["QuoteContractSiteID"])));
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
        this._Sites.Table.TableName = Enums.TableNames.tblQuoteContractSite.ToString();
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

    public ArrayList SiteArray
    {
      get
      {
        return this._SiteArray;
      }
      set
      {
        this._SiteArray = value;
      }
    }

    private DataView InvoiceAddresses
    {
      get
      {
        return this._InvoiceAddresses;
      }
      set
      {
        this._InvoiceAddresses = value;
        this._InvoiceAddresses.AllowDelete = false;
        this._InvoiceAddresses.AllowEdit = false;
        this._InvoiceAddresses.AllowNew = false;
        this._InvoiceAddresses.Table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
        this.dgInvoiceAddress.DataSource = (object) this.InvoiceAddresses;
      }
    }

    private DataRow SelectedInvoiceAddressesDataRow
    {
      get
      {
        return this.dgInvoiceAddress.CurrentRowIndex != -1 ? this.InvoiceAddresses[this.dgInvoiceAddress.CurrentRowIndex].Row : (DataRow) null;
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
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 40;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Property";
      dataGridLabelColumn.MappingName = "Site";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 400;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblQuoteContractSite.ToString();
      this.dgSites.TableStyles.Add(tableStyle);
    }

    public void SetupInvoiceAddressDataGrid()
    {
      Helper.SetUpDataGrid(this.dgInvoiceAddress, false);
      DataGridTableStyle tableStyle = this.dgInvoiceAddress.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      this.dgInvoiceAddress.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Address Type";
      dataGridLabelColumn1.MappingName = "AddressType";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 95;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Address 1";
      dataGridLabelColumn2.MappingName = "Address1";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Address 2";
      dataGridLabelColumn3.MappingName = "Address2";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Address 3";
      dataGridLabelColumn4.MappingName = "Address3";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Address 4";
      dataGridLabelColumn5.MappingName = "Address4";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Address 5";
      dataGridLabelColumn6.MappingName = "Address5";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Postcode";
      dataGridLabelColumn7.MappingName = "Postcode";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.MappingName = Enums.TableNames.tblInvoiceAddress.ToString();
      this.dgInvoiceAddress.TableStyles.Add(tableStyle);
    }

    private void UCContract_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void txtContractPrice_LostFocus(object sender, EventArgs e)
    {
      this.txtQuoteContractPrice.Text = this.txtQuoteContractPrice.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtQuoteContractPrice.Text.Replace("£", "")) ? Strings.Format((object) Conversions.ToDouble(this.txtQuoteContractPrice.Text.Replace("£", "")), "C") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
    }

    private void dgSites_Click(object sender, EventArgs e)
    {
      if (this.SelectedSiteDataRow == null)
        return;
      this.grpVisits.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Jobs Of Work for ", this.SelectedSiteDataRow["Site"]));
      QuoteContractAlternativeSite contractAlternativeSite = new QuoteContractAlternativeSite();
      QuoteContractAlternativeSite site = (QuoteContractAlternativeSite) this.SiteArray[this.dgSites.CurrentRowIndex];
      this.IsLoading = true;
      if (site != null)
      {
        if (site.JobOfWorks.Count > 0)
        {
          this.TCJobsOfWork.TabPages.Clear();
          IEnumerator enumerator;
          try
          {
            enumerator = site.JobOfWorks.GetEnumerator();
            while (enumerator.MoveNext())
            {
              QuoteContractAlternativeSiteJobOfWork current = (QuoteContractAlternativeSiteJobOfWork) enumerator.Current;
              if (App.DB.QuoteContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(current.QuoteContractSiteJobOfWorkID).Table.Rows.Count > 0)
                this.AddJobOfWork(current, site);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          this.TCJobsOfWork.SelectedTab = this.TCJobsOfWork.TabPages[0];
        }
        else
          this.TCJobsOfWork.TabPages.Clear();
      }
      else
        this.TCJobsOfWork.TabPages.Clear();
      this.IsLoading = false;
    }

    private void dgSites_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgSites.HitTest(e.X, e.Y);
      if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
        this.dgSites.CurrentRowIndex = hitTestInfo.Row;
      if (hitTestInfo.Column != 0)
        return;
      bool flag = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgSites[this.dgSites.CurrentRowIndex, 0]));
      this.Sites.Table.Rows[this.dgSites.CurrentRowIndex]["Tick"] = (object) flag;
      this.TCJobsOfWork.Enabled = flag;
    }

    private void btnContractNumber_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMAvailableContractNos), true, new object[2]
      {
        (object) this.txtContractReference,
        (object) this
      }, false);
    }

    private void dgInvoiceAddress_Click(object sender, EventArgs e)
    {
      this.dgInvoiceAddress.Select(this.dgInvoiceAddress.CurrentRowIndex);
    }

    private DataView BuildUpScheduleOfRatesDataview()
    {
      return new DataView(new DataTable()
      {
        Columns = {
          "ScheduleOfRatesCategoryID",
          "Category",
          "Code",
          "Description",
          "Price",
          "QtyPerVisit"
        },
        TableName = Enums.TableNames.tblSiteScheduleOfRate.ToString()
      });
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentQuoteContract = App.DB.QuoteContractAlternative.Get(ID);
      this.txtContractReference.Text = this.CurrentQuoteContract.QuoteContractReference;
      this.dtpContractStartDate.Value = this.CurrentQuoteContract.ContractStart;
      this.dtpContractEndDate.Value = this.CurrentQuoteContract.ContractEnd;
      ComboBox contractStatusId = this.cboContractStatusID;
      Combo.SetSelectedComboItem_By_Value(ref contractStatusId, Conversions.ToString(3));
      this.cboContractStatusID = contractStatusId;
      this.txtQuoteContractPrice.Text = Strings.Format((object) this.CurrentQuoteContract.QuoteContractPrice, "C");
      this.dtpFirstInvoiceDate.Value = this.CurrentQuoteContract.ContractStart;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        ContractAlternative contractAlternative1 = new ContractAlternative();
        contractAlternative1.IgnoreExceptionsOnSetMethods = true;
        contractAlternative1.SetContractReference = (object) this.txtContractReference.Text.Trim();
        contractAlternative1.ContractStartDate = this.dtpContractStartDate.Value;
        contractAlternative1.ContractEndDate = this.dtpContractEndDate.Value;
        contractAlternative1.SetContractStatusID = (object) Combo.get_GetSelectedItemValue(this.cboContractStatusID);
        contractAlternative1.SetContractPrice = (object) this.txtQuoteContractPrice.Text.Trim().Replace("£", "");
        contractAlternative1.SetInvoiceFrequencyID = (object) Combo.get_GetSelectedItemValue(this.cboInvoiceFrequencyID);
        contractAlternative1.SetQuoteContractID = (object) this.CurrentQuoteContract.QuoteContractID;
        contractAlternative1.SetCustomerID = (object) this.CurrentQuoteContract.CustomerID;
        contractAlternative1.FirstInvoiceDate = this.dtpFirstInvoiceDate.Value;
        if (this.SelectedInvoiceAddressesDataRow != null)
        {
          contractAlternative1.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressID"]);
          contractAlternative1.SetInvoiceAddressTypeID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressTypeID"]);
        }
        new ContractAlternativeValidator().Validate(contractAlternative1);
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.Sites.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Tick"], (object) true, false))
              new ContractAlternativeSiteValidator().Validate(new ContractAlternativeSite()
              {
                SetContractID = (object) contractAlternative1.ContractID,
                SetPropertyID = RuntimeHelpers.GetObjectValue(current["SiteID"])
              }, contractAlternative1);
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        ContractAlternative contractAlternative2 = App.DB.ContractAlternative.Insert(contractAlternative1);
        this.InsertInvoiceToBeRaiseLines(contractAlternative2);
        int index1 = 0;
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.Sites.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator2.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current1["Tick"], (object) true, false))
            {
              ContractAlternativeSite newSite = App.DB.ContractAlternativeSite.Insert(new ContractAlternativeSite()
              {
                SetContractID = (object) contractAlternative2.ContractID,
                SetPropertyID = RuntimeHelpers.GetObjectValue(current1["SiteID"])
              });
              int index2 = 0;
              IEnumerator enumerator3;
              try
              {
                enumerator3 = ((QuoteContractAlternativeSite) this.SiteArray[index1]).JobOfWorks.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                  QuoteContractAlternativeSiteJobOfWork current2 = (QuoteContractAlternativeSiteJobOfWork) enumerator3.Current;
                  if (App.DB.QuoteContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(current2.QuoteContractSiteJobOfWorkID).Table.Rows.Count > 0)
                  {
                    ContractAlternativeSiteJobOfWork newJobOfWork = App.DB.ContractAlternativeSiteJobOfWork.Insert(new ContractAlternativeSiteJobOfWork()
                    {
                      FirstVisitDate = current2.FirstVisitDate,
                      SetAverageMileage = (object) current2.AverageMileage,
                      SetIncludeMileagePrice = (object) current2.IncludeMileagePrice,
                      SetIncludeRates = (object) current2.IncludeRates,
                      SetPricePerMile = (object) current2.PricePerMile,
                      SetPricePerVisit = (object) current2.PricePerVisit,
                      SetTotalSitePrice = (object) current2.TotalSitePrice,
                      SetContractSiteID = (object) newSite.ContractSiteID
                    });
                    App.DB.ContractAlternativeSiteJobOfWork.SaveRates(current2.ScheduledOfRates_UsedForConvertOnly, newJobOfWork.ContractSiteJobOfWorkID);
                    DataView allForJobOfWorkId = App.DB.QuoteContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(((QuoteContractAlternativeSiteJobOfWork) ((QuoteContractAlternativeSite) this.SiteArray[index1]).JobOfWorks[index2]).QuoteContractSiteJobOfWorkID);
                    IEnumerator enumerator4;
                    try
                    {
                      enumerator4 = allForJobOfWorkId.Table.Rows.GetEnumerator();
                      while (enumerator4.MoveNext())
                      {
                        DataRow current3 = (DataRow) enumerator4.Current;
                        FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems alternativeSiteJobItems = App.DB.ContractAlternativeSiteJobItems.Insert(new FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems()
                        {
                          SetContractSiteID = (object) ((QuoteContractAlternativeSite) this.SiteArray[index1]).QuoteContractSiteID,
                          SetDescription = RuntimeHelpers.GetObjectValue(current3["Description"]),
                          SetJobOfWorkID = (object) newJobOfWork.ContractSiteJobOfWorkID,
                          SetItemPricePerVisit = RuntimeHelpers.GetObjectValue(current3["itemPricePerVisit"]),
                          SetVisitDuration = RuntimeHelpers.GetObjectValue(current3["VisitDuration"]),
                          SetVisitFrequencyID = RuntimeHelpers.GetObjectValue(current3["VisitFrequencyID"])
                        });
                        DataView allJobItemId = App.DB.QuoteContractAlternativeSiteAsset.GetAll_JobItemID(Conversions.ToInteger(current3["QuoteContractSiteJobItemID"]));
                        IEnumerator enumerator5;
                        try
                        {
                          enumerator5 = allJobItemId.Table.Rows.GetEnumerator();
                          while (enumerator5.MoveNext())
                          {
                            DataRow current4 = (DataRow) enumerator5.Current;
                            App.DB.ContractAlternativeSiteAsset.Insert(new ContractAlternativeSiteAsset()
                            {
                              SetAssetID = RuntimeHelpers.GetObjectValue(current4["AssetID"]),
                              SetContractSiteJobItemID = (object) alternativeSiteJobItems.ContractSiteJobItemID
                            });
                          }
                        }
                        finally
                        {
                          if (enumerator5 is IDisposable)
                            (enumerator5 as IDisposable).Dispose();
                        }
                      }
                    }
                    finally
                    {
                      if (enumerator4 is IDisposable)
                        (enumerator4 as IDisposable).Dispose();
                    }
                    this.ScheduleJob(contractAlternative2, newSite, newJobOfWork, App.DB.ContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(newJobOfWork.ContractSiteJobOfWorkID));
                    index2 = 1;
                  }
                }
              }
              finally
              {
                if (enumerator3 is IDisposable)
                  (enumerator3 as IDisposable).Dispose();
              }
            }
            checked { ++index1; }
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
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

    private void ScheduleJob(
      ContractAlternative newContract,
      ContractAlternativeSite newSite,
      ContractAlternativeSiteJobOfWork newJobOfWork,
      DataView newJobItems)
    {
      try
      {
        DateTime dateTime1 = newContract.ContractEndDate;
        int days = dateTime1.Subtract(newContract.ContractStartDate).Days;
        int num1 = 0;
        switch (Conversions.ToInteger(newJobItems.Table.Rows[0]["VisitFrequencyID"]))
        {
          case 3:
            num1 = 7;
            break;
          case 4:
            num1 = 30;
            break;
          case 5:
            num1 = 91;
            break;
          case 6:
            num1 = 182;
            break;
          case 7:
            num1 = 365;
            break;
        }
        int num2 = checked ((int) Math.Floor(unchecked ((double) days / (double) num1)));
        if (num2 == 0)
          num2 = 1;
        dateTime1 = newJobOfWork.FirstVisitDate;
        DateTime dateTime2 = Conversions.ToDate(Conversions.ToString(dateTime1.Date) + " 09:00:00");
        int num3 = num2;
        int num4 = 1;
        while (num4 <= num3)
        {
          if (DateTime.Compare(dateTime2, newContract.ContractStartDate) >= 0 & DateTime.Compare(dateTime2, newContract.ContractEndDate) <= 0)
          {
            if (dateTime2.DayOfWeek == DayOfWeek.Saturday)
              dateTime2 = dateTime2.AddDays(2.0);
            else if (dateTime2.DayOfWeek == DayOfWeek.Sunday)
              dateTime2 = dateTime2.AddDays(1.0);
            Job job1 = new Job();
            job1.SetPropertyID = (object) newSite.PropertyID;
            job1.SetJobDefinitionEnumID = (object) 2;
            job1.SetJobTypeID = (object) 0;
            job1.SetStatusEnumID = (object) 1;
            job1.SetCreatedByUserID = (object) App.loggedInUser.UserID;
            JobNumber jobNumber = new JobNumber();
            JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
            job1.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
            job1.SetPONumber = (object) "";
            job1.SetQuoteID = (object) 0;
            job1.SetContractID = (object) newContract.ContractID;
            if (newContract.ContractStatusID == 4)
              job1.SetDeleted = true;
            JobOfWork jobOfWork = new JobOfWork();
            jobOfWork.IgnoreExceptionsOnSetMethods = true;
            if (newContract.ContractStatusID == 4)
              jobOfWork.SetDeleted = true;
            int visitDuration = 0;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = newJobItems.Table.Rows.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                DataRow current1 = (DataRow) enumerator1.Current;
                JobItem jobItem = new JobItem();
                jobItem.IgnoreExceptionsOnSetMethods = true;
                jobItem.SetSummary = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) Helper.MakeStringValid((object) "PPM Contract Visit: "), current1["Description"]);
                visitDuration = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) visitDuration, current1["VisitDuration"]));
                DataView allJobItemId = App.DB.ContractAlternativeSiteAsset.GetAll_JobItemID(Conversions.ToInteger(current1["ContractSiteJobItemID"]));
                IEnumerator enumerator2;
                try
                {
                  enumerator2 = allJobItemId.Table.Rows.GetEnumerator();
                  while (enumerator2.MoveNext())
                  {
                    DataRow current2 = (DataRow) enumerator2.Current;
                    job1.Assets.Add((object) new JobAsset()
                    {
                      SetAssetID = RuntimeHelpers.GetObjectValue(current2["AssetID"])
                    });
                  }
                }
                finally
                {
                  if (enumerator2 is IDisposable)
                    (enumerator2 as IDisposable).Dispose();
                }
                jobOfWork.JobItems.Add((object) jobItem);
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            ArrayList arrayList1 = new ArrayList();
            int num5 = 0;
            DateTime dateTime3 = DateTime.MinValue;
            ArrayList arrayList2 = this.MatchingEngineer(job1, dateTime2, visitDuration);
            if (arrayList2 != null && arrayList2.Count > 0)
            {
              dateTime3 = Conversions.ToDate(arrayList2[0]);
              num5 = Conversions.ToInteger(arrayList2[1]);
            }
            EngineerVisit engineerVisit = new EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.SetEngineerID = (object) num5;
            engineerVisit.SetNotesToEngineer = (object) "PPM Contract Visit";
            if (num5 > 0)
            {
              engineerVisit.StartDateTime = dateTime3;
              engineerVisit.EndDateTime = dateTime3.AddMinutes((double) visitDuration);
              engineerVisit.SetStatusEnumID = (object) 5;
            }
            else
            {
              engineerVisit.StartDateTime = DateTime.MinValue;
              engineerVisit.EndDateTime = DateTime.MinValue;
              engineerVisit.SetStatusEnumID = (object) 4;
            }
            if (newContract.ContractStatusID == 4)
              engineerVisit.SetDeleted = true;
            jobOfWork.EngineerVisits.Add((object) engineerVisit);
            job1.JobOfWorks.Add((object) jobOfWork);
            Job job2 = App.DB.Job.Insert(job1);
            App.DB.ContractAlternativePPMVisit.Insert(new ContractAlternativePPMVisit()
            {
              SetContractSiteJobOfWorkID = (object) newJobOfWork.ContractSiteJobOfWorkID,
              EstimatedVisitDate = dateTime2,
              SetJobID = (object) job2.JobID
            });
            dateTime2 = dateTime2.AddDays((double) num1);
          }
          checked { ++num4; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private ArrayList MatchingEngineer(Job job, DateTime estVisitDate, int visitDuration)
    {
      FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
      int numOfSlotsNeeded = 0;
      ArrayList arrayList = new ArrayList();
      int timeSlot = App.DB.Manager.Get().TimeSlot;
      if (visitDuration > 0)
        numOfSlotsNeeded = checked ((int) Math.Round(unchecked ((double) visitDuration / (double) timeSlot)));
      FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) job.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
      if (site2.EngineerID > 0)
        arrayList = this.CheckAvailability(estVisitDate, site2.EngineerID, numOfSlotsNeeded);
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
          arrayList = this.CheckAvailability(estVisitDate, Conversions.ToInteger(forPostcode.Table.Rows[index]["EngineerID"]), numOfSlotsNeeded);
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
      int numOfSlotsNeeded)
    {
      ArrayList arrayList1 = new ArrayList();
      DateTime day = estimatedVisitDate;
      ArrayList arrayList2 = new ArrayList();
      int num1 = 0;
      do
      {
        arrayList1.Clear();
        if ((uint) num1 > 0U)
          day = day.AddDays(1.0);
        if (day.DayOfWeek == DayOfWeek.Saturday)
          day = day.AddDays(2.0);
        if (day.DayOfWeek == DayOfWeek.Saturday)
          day = day.AddDays(1.0);
        DataTable dataTable = App.DB.Scheduler.Scheduler_DayTimeSlots(day, Conversions.ToString(engineerID));
        if (dataTable.Rows.Count > 0)
        {
          int num2 = checked (dataTable.Columns.Count - 1);
          int index = 0;
          while (index <= num2)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataTable.Rows[0][index], (object) 0, false))
            {
              arrayList1.Add((object) dataTable.Columns[index].ColumnName);
              if (arrayList1.Count == numOfSlotsNeeded)
                break;
            }
            else
              arrayList1.Clear();
            checked { ++index; }
          }
        }
        else
          arrayList1.Add((object) App.DB.Manager.Get().WorkingHoursStart);
        if (arrayList1.Count > 0 && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (arrayList1.Count == numOfSlotsNeeded), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(arrayList1[0], (object) App.DB.Manager.Get().WorkingHoursStart, false))))
        {
          string str = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(arrayList1[0], (object) App.DB.Manager.Get().WorkingHoursStart, false) ? Strings.Replace(Conversions.ToString(arrayList1[0]), "T", "", 1, -1, CompareMethod.Binary).Insert(2, ":") : Conversions.ToString(arrayList1[0]);
          day = Conversions.ToDate(Strings.Format((object) day, "dd/MM/yyyy") + " " + str);
          arrayList2.Add((object) day);
          arrayList2.Add((object) engineerID);
          return arrayList2;
        }
        checked { ++num1; }
      }
      while (num1 <= 4);
      return arrayList2;
    }

    private TabPage AddJobOfWork(
      QuoteContractAlternativeSiteJobOfWork jobOfWork,
      QuoteContractAlternativeSite CurrentQuoteContractSite)
    {
      TabPage tabPage = new TabPage();
      tabPage.BackColor = Color.White;
      UCConvertJobOfWork convertJobOfWork = new UCConvertJobOfWork();
      convertJobOfWork.OnControl = this;
      if (jobOfWork == null)
      {
        jobOfWork = new QuoteContractAlternativeSiteJobOfWork();
        jobOfWork.SetQuoteContractSiteID = (object) CurrentQuoteContractSite.QuoteContractSiteID;
        jobOfWork.FirstVisitDate = this.CurrentQuoteContract.ContractStart.AddDays(1.0);
        jobOfWork = App.DB.QuoteContractAlternativeSiteJobOfWork.Insert(jobOfWork);
      }
      convertJobOfWork.CurrentJobOfWork = jobOfWork;
      convertJobOfWork.Dock = DockStyle.Fill;
      tabPage.Controls.Add((Control) convertJobOfWork);
      this.TCJobsOfWork.TabPages.Add(tabPage);
      this.CheckTabs();
      this.TCJobsOfWork.SelectedTab = tabPage;
      return tabPage;
    }

    private void CheckTabs()
    {
      int num = 1;
      IEnumerator enumerator;
      try
      {
        enumerator = this.TCJobsOfWork.TabPages.GetEnumerator();
        while (enumerator.MoveNext())
        {
          ((TabPage) enumerator.Current).Text = "Job Of Work #" + Conversions.ToString(num);
          checked { ++num; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void InsertInvoiceToBeRaiseLines(ContractAlternative CurrentContract)
    {
      int num1 = 0;
      switch (CurrentContract.InvoiceFrequencyID)
      {
        case 1:
          num1 = checked ((int) Math.Round(unchecked ((double) DateAndTime.DateDiff(DateInterval.Day, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 7.0)));
          break;
        case 2:
          num1 = checked ((int) DateAndTime.DateDiff(DateInterval.Month, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          break;
        case 3:
          num1 = checked ((int) Math.Round(unchecked ((double) DateAndTime.DateDiff(DateInterval.Month, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) / 3.0)));
          break;
        case 4:
          num1 = checked ((int) (DateAndTime.DateDiff(DateInterval.Year, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) * 2L));
          break;
        case 6:
          num1 = checked ((int) DateAndTime.DateDiff(DateInterval.Year, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
          break;
      }
      DateTime dateTime = CurrentContract.FirstInvoiceDate;
      int num2 = num1;
      int num3 = 1;
      while (num3 <= num2)
      {
        App.DB.InvoiceToBeRaised.Insert(new InvoiceToBeRaised()
        {
          SetAddressLinkID = (object) CurrentContract.InvoiceAddressID,
          SetAddressTypeID = (object) CurrentContract.InvoiceAddressTypeID,
          SetInvoiceTypeID = (object) 329,
          SetLinkID = (object) CurrentContract.ContractID,
          RaiseDate = dateTime
        });
        switch (CurrentContract.InvoiceFrequencyID)
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
  }
}
