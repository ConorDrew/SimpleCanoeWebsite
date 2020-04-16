// Decompiled with JetBrains decompiler
// Type: FSM.FRMContractRenewal
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractAlternativePPMVisits;
using FSM.Entity.ContractAlternativeSites;
using FSM.Entity.ContractOption3s;
using FSM.Entity.ContractOriginalPPMVisits;
using FSM.Entity.ContractOriginalSites;
using FSM.Entity.ContractsAlternative;
using FSM.Entity.ContractsOriginal;
using FSM.Entity.EngineerVisits;
using FSM.Entity.InvoiceToBeRaiseds;
using FSM.Entity.JobAssets;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
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
  public class FRMContractRenewal : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _ContractID;
    private Enums.QuoteType _ContractType;
    private ContractOriginal _OldContractOne;
    private ContractAlternative _OldContractTwo;
    private ContractOption3 _OldContractThree;
    private DataView _OldSites;
    private DataView _InvoiceAddresses;

    public FRMContractRenewal()
    {
      this.Load += new EventHandler(this.FRMContractManager_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TextBox txtPercentMarkup
    {
      get
      {
        return this._txtPercentMarkup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPercentMarkup_TextChanged);
        TextBox txtPercentMarkup1 = this._txtPercentMarkup;
        if (txtPercentMarkup1 != null)
          txtPercentMarkup1.TextChanged -= eventHandler;
        this._txtPercentMarkup = value;
        TextBox txtPercentMarkup2 = this._txtPercentMarkup;
        if (txtPercentMarkup2 == null)
          return;
        txtPercentMarkup2.TextChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual DataGrid dgFirstVisitDates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCreateContract
    {
      get
      {
        return this._btnCreateContract;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCreateContract_Click);
        Button btnCreateContract1 = this._btnCreateContract;
        if (btnCreateContract1 != null)
          btnCreateContract1.Click -= eventHandler;
        this._btnCreateContract = value;
        Button btnCreateContract2 = this._btnCreateContract;
        if (btnCreateContract2 == null)
          return;
        btnCreateContract2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtNewPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbContract { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbSites { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpInvoiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInvoiceFrequencyID
    {
      get
      {
        return this._cboInvoiceFrequencyID;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboInvoiceFrequencyID_SelectedIndexChanged);
        ComboBox invoiceFrequencyId1 = this._cboInvoiceFrequencyID;
        if (invoiceFrequencyId1 != null)
          invoiceFrequencyId1.SelectedIndexChanged -= eventHandler;
        this._cboInvoiceFrequencyID = value;
        ComboBox invoiceFrequencyId2 = this._cboInvoiceFrequencyID;
        if (invoiceFrequencyId2 == null)
          return;
        invoiceFrequencyId2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblInvoiceFrequencyID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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
      this.gpbContract = new GroupBox();
      this.gpbInvoiceAddress = new GroupBox();
      this.dgInvoiceAddress = new DataGrid();
      this.cboInvoiceFrequencyID = new ComboBox();
      this.lblInvoiceFrequencyID = new Label();
      this.Label6 = new Label();
      this.Label5 = new Label();
      this.dtpInvoiceDate = new DateTimePicker();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.txtNewPrice = new TextBox();
      this.dtpStartDate = new DateTimePicker();
      this.dtpEndDate = new DateTimePicker();
      this.txtPercentMarkup = new TextBox();
      this.btnCreateContract = new Button();
      this.dgFirstVisitDates = new DataGrid();
      this.gpbSites = new GroupBox();
      this.btnCancel = new Button();
      this.gpbContract.SuspendLayout();
      this.gpbInvoiceAddress.SuspendLayout();
      this.dgInvoiceAddress.BeginInit();
      this.dgFirstVisitDates.BeginInit();
      this.gpbSites.SuspendLayout();
      this.SuspendLayout();
      this.gpbContract.Controls.Add((Control) this.gpbInvoiceAddress);
      this.gpbContract.Controls.Add((Control) this.cboInvoiceFrequencyID);
      this.gpbContract.Controls.Add((Control) this.lblInvoiceFrequencyID);
      this.gpbContract.Controls.Add((Control) this.Label6);
      this.gpbContract.Controls.Add((Control) this.Label5);
      this.gpbContract.Controls.Add((Control) this.dtpInvoiceDate);
      this.gpbContract.Controls.Add((Control) this.Label4);
      this.gpbContract.Controls.Add((Control) this.Label3);
      this.gpbContract.Controls.Add((Control) this.Label2);
      this.gpbContract.Controls.Add((Control) this.Label1);
      this.gpbContract.Controls.Add((Control) this.txtNewPrice);
      this.gpbContract.Controls.Add((Control) this.dtpStartDate);
      this.gpbContract.Controls.Add((Control) this.dtpEndDate);
      this.gpbContract.Controls.Add((Control) this.txtPercentMarkup);
      this.gpbContract.Location = new System.Drawing.Point(6, 38);
      this.gpbContract.Name = "gpbContract";
      this.gpbContract.Size = new Size(908, 185);
      this.gpbContract.TabIndex = 2;
      this.gpbContract.TabStop = false;
      this.gpbContract.Text = "Contract";
      this.gpbInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbInvoiceAddress.Controls.Add((Control) this.dgInvoiceAddress);
      this.gpbInvoiceAddress.Location = new System.Drawing.Point(350, 15);
      this.gpbInvoiceAddress.Name = "gpbInvoiceAddress";
      this.gpbInvoiceAddress.Size = new Size(539, 162);
      this.gpbInvoiceAddress.TabIndex = 16;
      this.gpbInvoiceAddress.TabStop = false;
      this.gpbInvoiceAddress.Text = "Invoice Address";
      this.dgInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgInvoiceAddress.DataMember = "";
      this.dgInvoiceAddress.HeaderForeColor = SystemColors.ControlText;
      this.dgInvoiceAddress.Location = new System.Drawing.Point(8, 20);
      this.dgInvoiceAddress.Name = "dgInvoiceAddress";
      this.dgInvoiceAddress.Size = new Size(523, 134);
      this.dgInvoiceAddress.TabIndex = 0;
      this.cboInvoiceFrequencyID.Cursor = Cursors.Hand;
      this.cboInvoiceFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInvoiceFrequencyID.Location = new System.Drawing.Point(123, 154);
      this.cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID";
      this.cboInvoiceFrequencyID.Size = new Size(195, 21);
      this.cboInvoiceFrequencyID.TabIndex = 15;
      this.cboInvoiceFrequencyID.Tag = (object) "Contract.InvoiceFrequencyID";
      this.lblInvoiceFrequencyID.Location = new System.Drawing.Point(8, 157);
      this.lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID";
      this.lblInvoiceFrequencyID.Size = new Size(132, 20);
      this.lblInvoiceFrequencyID.TabIndex = 14;
      this.lblInvoiceFrequencyID.Text = "Invoice Frequency";
      this.Label6.Location = new System.Drawing.Point(8, 43);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(80, 23);
      this.Label6.TabIndex = 12;
      this.Label6.Text = "New Price";
      this.Label6.TextAlign = ContentAlignment.MiddleLeft;
      this.Label5.Location = new System.Drawing.Point(8, 125);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(93, 23);
      this.Label5.TabIndex = 11;
      this.Label5.Text = "Invoice Date";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      this.dtpInvoiceDate.Location = new System.Drawing.Point(123, 126);
      this.dtpInvoiceDate.Name = "dtpInvoiceDate";
      this.dtpInvoiceDate.Size = new Size(195, 21);
      this.dtpInvoiceDate.TabIndex = 10;
      this.Label4.Location = new System.Drawing.Point(8, 98);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 23);
      this.Label4.TabIndex = 9;
      this.Label4.Text = "End Date";
      this.Label4.TextAlign = ContentAlignment.MiddleLeft;
      this.Label3.Location = new System.Drawing.Point(8, 71);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(100, 23);
      this.Label3.TabIndex = 8;
      this.Label3.Text = "Start Date";
      this.Label3.TextAlign = ContentAlignment.MiddleLeft;
      this.Label2.Location = new System.Drawing.Point(324, 15);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(30, 23);
      this.Label2.TabIndex = 7;
      this.Label2.Text = "%";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      this.Label1.Location = new System.Drawing.Point(8, 15);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(100, 23);
      this.Label1.TabIndex = 6;
      this.Label1.Text = "Markup Amount";
      this.Label1.TextAlign = ContentAlignment.MiddleLeft;
      this.txtNewPrice.Location = new System.Drawing.Point(123, 45);
      this.txtNewPrice.Name = "txtNewPrice";
      this.txtNewPrice.Size = new Size(195, 21);
      this.txtNewPrice.TabIndex = 5;
      this.dtpStartDate.Location = new System.Drawing.Point(123, 72);
      this.dtpStartDate.Name = "dtpStartDate";
      this.dtpStartDate.Size = new Size(195, 21);
      this.dtpStartDate.TabIndex = 2;
      this.dtpEndDate.Location = new System.Drawing.Point(123, 99);
      this.dtpEndDate.Name = "dtpEndDate";
      this.dtpEndDate.Size = new Size(195, 21);
      this.dtpEndDate.TabIndex = 1;
      this.txtPercentMarkup.Location = new System.Drawing.Point(123, 17);
      this.txtPercentMarkup.Name = "txtPercentMarkup";
      this.txtPercentMarkup.Size = new Size(195, 21);
      this.txtPercentMarkup.TabIndex = 0;
      this.btnCreateContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCreateContract.Location = new System.Drawing.Point(790, 251);
      this.btnCreateContract.Name = "btnCreateContract";
      this.btnCreateContract.Size = new Size(112, 23);
      this.btnCreateContract.TabIndex = 4;
      this.btnCreateContract.Text = "Create Contract";
      this.dgFirstVisitDates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgFirstVisitDates.DataMember = "";
      this.dgFirstVisitDates.HeaderForeColor = SystemColors.ControlText;
      this.dgFirstVisitDates.Location = new System.Drawing.Point(8, 24);
      this.dgFirstVisitDates.Name = "dgFirstVisitDates";
      this.dgFirstVisitDates.Size = new Size(894, 221);
      this.dgFirstVisitDates.TabIndex = 3;
      this.gpbSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbSites.Controls.Add((Control) this.btnCancel);
      this.gpbSites.Controls.Add((Control) this.dgFirstVisitDates);
      this.gpbSites.Controls.Add((Control) this.btnCreateContract);
      this.gpbSites.Location = new System.Drawing.Point(6, 229);
      this.gpbSites.Name = "gpbSites";
      this.gpbSites.Size = new Size(908, 281);
      this.gpbSites.TabIndex = 3;
      this.gpbSites.TabStop = false;
      this.gpbSites.Text = "Properties - Enter Dates";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(8, 251);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(928, 509);
      this.ControlBox = false;
      this.Controls.Add((Control) this.gpbSites);
      this.Controls.Add((Control) this.gpbContract);
      this.MinimumSize = new Size(928, 529);
      this.Name = nameof (FRMContractRenewal);
      this.Text = "Contract Renewal";
      this.Controls.SetChildIndex((Control) this.gpbContract, 0);
      this.Controls.SetChildIndex((Control) this.gpbSites, 0);
      this.gpbContract.ResumeLayout(false);
      this.gpbContract.PerformLayout();
      this.gpbInvoiceAddress.ResumeLayout(false);
      this.dgInvoiceAddress.EndInit();
      this.dgFirstVisitDates.EndInit();
      this.gpbSites.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      object Left = this.get_GetParameter(0);
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) Enums.QuoteType.Contract_Opt_1.ToString(), false))
        this.ContractType = Enums.QuoteType.Contract_Opt_1;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) Enums.QuoteType.Contract_Opt_2.ToString(), false))
        this.ContractType = Enums.QuoteType.Contract_Opt_2;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) Enums.QuoteType.Contract_Opt_3.ToString(), false))
        this.ContractType = Enums.QuoteType.Contract_Opt_3;
      this.ContractID = Conversions.ToInteger(this.get_GetParameter(1));
      ComboBox invoiceFrequencyId = this.cboInvoiceFrequencyID;
      Combo.SetUpCombo(ref invoiceFrequencyId, DynamicDataTables.InvoiceFrequency_NoWeekly, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboInvoiceFrequencyID = invoiceFrequencyId;
      this.FormSetUp();
      this.Populate();
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

    private int ContractID
    {
      get
      {
        return this._ContractID;
      }
      set
      {
        this._ContractID = value;
      }
    }

    private Enums.QuoteType ContractType
    {
      get
      {
        return this._ContractType;
      }
      set
      {
        this._ContractType = value;
      }
    }

    private ContractOriginal OldContractOne
    {
      get
      {
        return this._OldContractOne;
      }
      set
      {
        this._OldContractOne = value;
      }
    }

    private ContractAlternative OldContractTwo
    {
      get
      {
        return this._OldContractTwo;
      }
      set
      {
        this._OldContractTwo = value;
      }
    }

    private ContractOption3 OldContractThree
    {
      get
      {
        return this._OldContractThree;
      }
      set
      {
        this._OldContractThree = value;
      }
    }

    private DataView OldSites
    {
      get
      {
        return this._OldSites;
      }
      set
      {
        this._OldSites = value;
        this._OldSites.AllowDelete = false;
        this._OldSites.AllowEdit = true;
        this._OldSites.AllowNew = false;
        this._OldSites.Table.TableName = Enums.TableNames.NO_TABLE.ToString();
        this.dgFirstVisitDates.DataSource = (object) this.OldSites;
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

    private void FormSetUp()
    {
      this.SetupInvoiceAddressDataGrid();
      switch (this.ContractType)
      {
        case Enums.QuoteType.Contract_Opt_1:
          this.SetupdgContractOne();
          break;
        case Enums.QuoteType.Contract_Opt_2:
          this.SetupdgContractTwo();
          break;
        case Enums.QuoteType.Contract_Opt_3:
          this.SetupContractThree();
          break;
      }
    }

    private void SetupdgContractOne()
    {
      DataGridTableStyle tableStyle = this.dgFirstVisitDates.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Property";
      dataGridLabelColumn.MappingName = "Site";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 300;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "dd/MM/yyyy";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "First Visit Date";
      editableTextBoxColumn.MappingName = "FirstVisitDate";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 120;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
      this.dgFirstVisitDates.ReadOnly = false;
      this.dgFirstVisitDates.TableStyles.Add(tableStyle);
    }

    private void SetupdgContractTwo()
    {
      DataGridTableStyle tableStyle = this.dgFirstVisitDates.TableStyles[0];
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
      dataGridLabelColumn2.HeaderText = "Visit Frequency";
      dataGridLabelColumn2.MappingName = "VisitFrequency";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "dd/MM/yyyy";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "First Visit Date";
      editableTextBoxColumn.MappingName = "FirstVisitDate";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 100;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
      this.dgFirstVisitDates.ReadOnly = false;
      this.dgFirstVisitDates.TableStyles.Add(tableStyle);
    }

    private void SetupContractThree()
    {
      DataGridTableStyle tableStyle = this.dgFirstVisitDates.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Property";
      dataGridLabelColumn.MappingName = "Site";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 250;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      DataGridEditableTextBoxColumn editableTextBoxColumn1 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn1.Format = "dd/MM/yyyy";
      editableTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn1.HeaderText = "Start Date";
      editableTextBoxColumn1.MappingName = "StartDate";
      editableTextBoxColumn1.ReadOnly = false;
      editableTextBoxColumn1.Width = 100;
      editableTextBoxColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn1);
      DataGridEditableTextBoxColumn editableTextBoxColumn2 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn2.Format = "dd/MM/yyyy";
      editableTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn2.HeaderText = "End Date";
      editableTextBoxColumn2.MappingName = "EndDate";
      editableTextBoxColumn2.ReadOnly = false;
      editableTextBoxColumn2.Width = 100;
      editableTextBoxColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn2);
      DataGridEditableTextBoxColumn editableTextBoxColumn3 = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn3.Format = "dd/MM/yyyy";
      editableTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn3.HeaderText = "First Visit Date";
      editableTextBoxColumn3.MappingName = "FirstVisitDate";
      editableTextBoxColumn3.ReadOnly = false;
      editableTextBoxColumn3.Width = 100;
      editableTextBoxColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn3);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
      this.dgFirstVisitDates.ReadOnly = false;
      this.dgFirstVisitDates.TableStyles.Add(tableStyle);
    }

    public void SetupInvoiceAddressDataGrid()
    {
      Helper.SetUpDataGrid(this.dgInvoiceAddress, false);
      DataGridTableStyle tableStyle = this.dgInvoiceAddress.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
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

    private void FRMContractManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void txtPercentMarkup_TextChanged(object sender, EventArgs e)
    {
      double num = 0.0;
      if ((uint) this.txtPercentMarkup.Text.Length > 0U && Versioned.IsNumeric((object) this.txtPercentMarkup.Text))
        num = Conversions.ToDouble(this.txtPercentMarkup.Text);
      switch (this.ContractType)
      {
        case Enums.QuoteType.Contract_Opt_1:
          this.txtNewPrice.Text = Strings.Format((object) (Convert.ToDouble(this.OldContractOne.ContractPrice) * (num / 100.0) + Convert.ToDouble(this.OldContractOne.ContractPrice)), "C");
          break;
        case Enums.QuoteType.Contract_Opt_2:
          this.txtNewPrice.Text = Strings.Format((object) (this.OldContractTwo.ContractPrice * (num / 100.0) + this.OldContractTwo.ContractPrice), "C");
          break;
        case Enums.QuoteType.Contract_Opt_3:
          this.txtNewPrice.Text = Strings.Format((object) (this.OldContractThree.ContractPrice * (num / 100.0) + this.OldContractThree.ContractPrice), "C");
          break;
      }
      if (num != 0.0)
        return;
      this.txtPercentMarkup.Text = Conversions.ToString(num);
    }

    private void dtpStartDate_ValueChanged(object sender, EventArgs e)
    {
      DateTime dateTime1;
      if (DateTime.Compare(this.dtpEndDate.Value, this.dtpStartDate.Value) < 0)
      {
        DateTimePicker dtpEndDate = this.dtpEndDate;
        dateTime1 = this.dtpStartDate.Value.AddYears(1);
        DateTime dateTime2 = dateTime1.AddDays(-1.0);
        dtpEndDate.Value = dateTime2;
      }
      if (this.OldSites == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.OldSites.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          dateTime1 = this.dtpStartDate.Value;
          // ISSUE: variable of a boxed type
          __Boxed<DateTime> local = (System.ValueType) dateTime1.AddDays(1.0);
          current["FirstVisitDate"] = (object) local;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnCreateContract_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      bool flag = false;
      if (this.ContractType == Enums.QuoteType.Contract_Opt_1)
        flag = this.SaveOne();
      if (flag)
      {
        if (this.ContractType == Enums.QuoteType.Contract_Opt_1)
        {
          int newIdByOldId = App.DB.ContractManager.ContractRenewals_GetNewID_ByOldID(this.ContractID, 1);
          DataTable dataTable = App.DB.ContractOriginal.ProcessContract(newIdByOldId);
          if (dataTable == null)
            return;
          Printing printing = new Printing((object) new ArrayList()
          {
            (object) dataTable
          }, "", Enums.SystemDocumentType.ContractOption1, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
        }
        this.Cursor = Cursors.Default;
        ((FRMContractManager) this.get_GetParameter(2)).PopulateDatagrid();
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void Populate()
    {
      try
      {
        switch (this.ContractType)
        {
          case Enums.QuoteType.Contract_Opt_1:
            this.PopulateOne();
            break;
          case Enums.QuoteType.Contract_Opt_2:
            this.PopulateTwo();
            break;
          case Enums.QuoteType.Contract_Opt_3:
            this.PopulateThree();
            break;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void PopulateOne()
    {
      this.OldContractOne = App.DB.ContractOriginal.Get(this.ContractID);
      this.txtPercentMarkup.Text = Conversions.ToString(0);
      this.dtpStartDate.Value = DateAndTime.Now;
      DateTimePicker dtpEndDate = this.dtpEndDate;
      DateTime dateTime1 = DateAndTime.Now;
      dateTime1 = dateTime1.AddYears(1);
      DateTime dateTime2 = dateTime1.AddDays(-1.0);
      dtpEndDate.Value = dateTime2;
      this.dtpInvoiceDate.Value = DateAndTime.Now;
      ComboBox invoiceFrequencyId = this.cboInvoiceFrequencyID;
      Combo.SetSelectedComboItem_By_Value(ref invoiceFrequencyId, Conversions.ToString(this.OldContractOne.InvoiceFrequencyID));
      this.cboInvoiceFrequencyID = invoiceFrequencyId;
      DataTable table = new DataTable();
      table.Columns.Add("SiteID");
      table.Columns.Add("ContractSiteID");
      table.Columns.Add("Site");
      table.Columns.Add("FirstVisitDate", typeof (DateTime));
      IEnumerator enumerator1;
      try
      {
        enumerator1 = App.DB.ContractOriginalSite.GetAll_ContractID(this.ContractID, this.OldContractOne.CustomerID).Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Tick"])))
          {
            DataRow row = table.NewRow();
            row["SiteID"] = RuntimeHelpers.GetObjectValue(current["SiteID"]);
            row["ContractSiteID"] = RuntimeHelpers.GetObjectValue(current["ContractSiteID"]);
            row["Site"] = RuntimeHelpers.GetObjectValue(current["Site"]);
            row["FirstVisitDate"] = (object) this.dtpStartDate.Value.AddDays(1.0);
            table.Rows.Add(row);
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      this.OldSites = new DataView(table);
      this.InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(this.OldContractOne.CustomerID);
      if (this.OldContractOne.InvoiceAddressID > 0)
      {
        int num = 0;
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.InvoiceAddresses.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AddressID"], (object) this.OldContractOne.InvoiceAddressID, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AddressTypeID"], (object) this.OldContractOne.InvoiceAddressTypeID, false))))
            {
              this.dgInvoiceAddress.CurrentRowIndex = num;
              break;
            }
            checked { ++num; }
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      else
        this.dgInvoiceAddress.CurrentRowIndex = 0;
      if (this.dgInvoiceAddress.CurrentRowIndex >= 0)
        return;
      this.dgInvoiceAddress.Select(this.dgInvoiceAddress.CurrentRowIndex);
    }

    private void PopulateTwo()
    {
      this.OldContractTwo = App.DB.ContractAlternative.Get(this.ContractID);
      this.txtPercentMarkup.Text = Conversions.ToString(0);
      this.dtpStartDate.Value = DateAndTime.Now;
      DateTimePicker dtpEndDate = this.dtpEndDate;
      DateTime dateTime1 = DateAndTime.Now;
      dateTime1 = dateTime1.AddYears(1);
      DateTime dateTime2 = dateTime1.AddDays(-1.0);
      dtpEndDate.Value = dateTime2;
      this.dtpInvoiceDate.Value = DateAndTime.Now;
      ComboBox invoiceFrequencyId = this.cboInvoiceFrequencyID;
      Combo.SetSelectedComboItem_By_Value(ref invoiceFrequencyId, Conversions.ToString(this.OldContractTwo.InvoiceFrequencyID));
      this.cboInvoiceFrequencyID = invoiceFrequencyId;
      DataTable table = new DataTable();
      table.Columns.Add("ContractSiteID");
      table.Columns.Add("Site");
      table.Columns.Add("SiteID");
      table.Columns.Add("VisitFrequency");
      table.Columns.Add("FirstVisitDate", typeof (DateTime));
      table.Columns.Add("ContractSiteJobOfWorkID");
      IEnumerator enumerator1;
      try
      {
        enumerator1 = App.DB.ContractManager.ContractRenewal_AlternativeSitesJobOfWorks(this.ContractID).Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          DataRow row = table.NewRow();
          row["ContractSiteID"] = RuntimeHelpers.GetObjectValue(current["ContractSiteID"]);
          row["Site"] = RuntimeHelpers.GetObjectValue(current["Site"]);
          row["SiteID"] = RuntimeHelpers.GetObjectValue(current["SiteID"]);
          row["VisitFrequency"] = RuntimeHelpers.GetObjectValue(current["VisitFrequency"]);
          row["FirstVisitDate"] = (object) this.dtpStartDate.Value.AddDays(1.0);
          row["ContractSiteJobOfWorkID"] = RuntimeHelpers.GetObjectValue(current["ContractSiteJobOfWorkID"]);
          table.Rows.Add(row);
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      this.OldSites = new DataView(table);
      this.InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(this.OldContractTwo.CustomerID);
      if (this.OldContractTwo.InvoiceAddressID > 0)
      {
        int num = 0;
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.InvoiceAddresses.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AddressID"], (object) this.OldContractTwo.InvoiceAddressID, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AddressTypeID"], (object) this.OldContractTwo.InvoiceAddressTypeID, false))))
            {
              this.dgInvoiceAddress.CurrentRowIndex = num;
              break;
            }
            checked { ++num; }
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      else
        this.dgInvoiceAddress.CurrentRowIndex = 0;
      if (this.dgInvoiceAddress.CurrentRowIndex >= 0)
        return;
      this.dgInvoiceAddress.Select(this.dgInvoiceAddress.CurrentRowIndex);
    }

    private void PopulateThree()
    {
      this.OldContractThree = App.DB.ContractOption3.ContractOption3_Get(this.ContractID);
      this.txtPercentMarkup.Text = Conversions.ToString(0);
      this.dtpStartDate.Enabled = false;
      this.dtpEndDate.Enabled = false;
      this.dtpInvoiceDate.Value = DateAndTime.Now;
      DataTable table = new DataTable();
      table.Columns.Add("ContractSiteID");
      table.Columns.Add("Site");
      table.Columns.Add("OrderID");
      table.Columns.Add("StartDate", typeof (DateTime));
      table.Columns.Add("EndDate", typeof (DateTime));
      table.Columns.Add("FirstVisitDate", typeof (DateTime));
      IEnumerator enumerator;
      try
      {
        enumerator = App.DB.ContractOption3Site.ContractOption3Site_GetAll_ForContract(this.ContractID, this.OldContractThree.CustomerID).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["tick"])))
          {
            DataRow row = table.NewRow();
            row["ContractSiteID"] = RuntimeHelpers.GetObjectValue(current["ContractSiteID"]);
            row["Site"] = RuntimeHelpers.GetObjectValue(current["Site"]);
            row["OrderID"] = RuntimeHelpers.GetObjectValue(current["OrderID"]);
            row["StartDate"] = (object) DateAndTime.Now;
            DataRow dataRow1 = row;
            DateTime dateTime = DateAndTime.Now;
            dateTime = dateTime.AddYears(1);
            // ISSUE: variable of a boxed type
            __Boxed<DateTime> local1 = (System.ValueType) dateTime.AddDays(-1.0);
            dataRow1["EndDate"] = (object) local1;
            DataRow dataRow2 = row;
            dateTime = DateAndTime.Now;
            // ISSUE: variable of a boxed type
            __Boxed<DateTime> local2 = (System.ValueType) dateTime.AddDays(1.0);
            dataRow2["FirstVisitDate"] = (object) local2;
            table.Rows.Add(row);
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.OldSites = new DataView(table);
    }

    private bool SaveOne()
    {
      bool flag;
      try
      {
        ContractOriginal oContract = new ContractOriginal();
        if (this.SelectedInvoiceAddressesDataRow != null)
        {
          oContract.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressID"]);
          oContract.SetInvoiceAddressTypeID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressTypeID"]);
        }
        string str = "";
        if (DateTime.Compare(this.dtpEndDate.Value, this.dtpStartDate.Value) <= 0)
          str += "* End Date must be after Start Date\r\n";
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboInvoiceFrequencyID)) == 0.0)
          str += "* Select Invoice Frequency";
        if (oContract.InvoiceAddressID == 0)
          str += "* Select Invoice Address";
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.OldSites.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(current["FirstVisitDate"], (object) this.dtpStartDate.Value, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectLess(current["FirstVisitDate"], (object) this.dtpEndDate.Value, false)))))
              str += "* First Visit Dates must be between contract start and end dates.\r\n";
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        if (str.Length > 0)
        {
          int num = (int) App.ShowMessage("Please correct the following errors\r\n" + str, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          flag = false;
        }
        else
        {
          oContract.SetContractPrice = (object) this.txtNewPrice.Text.Replace("£", "");
          oContract.SetContractReference = (object) this.OldContractOne.ContractReference;
          oContract.SetContractStatusID = (object) 3;
          oContract.SetCustomerID = (object) this.OldContractOne.CustomerID;
          oContract.SetInvoiceFrequencyID = (object) Combo.get_GetSelectedItemValue(this.cboInvoiceFrequencyID);
          oContract.ContractStartDate = this.dtpStartDate.Value;
          oContract.ContractEndDate = this.dtpEndDate.Value;
          oContract.FirstInvoiceDate = this.dtpInvoiceDate.Value;
          oContract.SetContractTypeID = (object) this.OldContractOne.ContractTypeID;
          oContract.SetGasSupplyPipework = (object) this.OldContractOne.GasSupplyPipework;
          ContractOriginal contractOriginal1 = App.DB.ContractOriginal.Insert(oContract);
          ContractOriginal contractOriginal2 = contractOriginal1;
          this.InsertInvoiceToBeRaiseLines(contractOriginal2.InvoiceFrequencyID, contractOriginal2.ContractStartDate, contractOriginal2.ContractEndDate, contractOriginal2.FirstInvoiceDate, contractOriginal2.InvoiceAddressID, contractOriginal2.InvoiceAddressTypeID, contractOriginal2.ContractID, 327);
          IEnumerator enumerator2;
          try
          {
            enumerator2 = this.OldSites.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              App.ShowForm(typeof (FRMContractOriginalSite), true, new object[5]
              {
                (object) 0,
                current["SiteID"],
                (object) contractOriginal1,
                (object) this,
                current["ContractSiteID"]
              }, false);
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          App.DB.ContractManager.ContractRenewalsInsert(this.OldContractOne.ContractID, contractOriginal1.ContractID, 1);
          flag = true;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private void ScheduleJobContractOne(
      ContractOriginal Contract,
      ContractOriginalSite CurrentContractSite)
    {
      try
      {
        DateTime dateTime1 = Contract.ContractEndDate;
        int days = dateTime1.Subtract(Contract.ContractStartDate).Days;
        int num1 = 0;
        switch (CurrentContractSite.VisitFrequencyID)
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
        dateTime1 = CurrentContractSite.FirstVisitDate;
        DateTime estVisitDate = Conversions.ToDate(Conversions.ToString(dateTime1.Date) + " 09:00:00");
        int num3 = num2;
        int num4 = 1;
        while (num4 <= num3)
        {
          if (DateTime.Compare(Conversions.ToDate(Strings.Format((object) estVisitDate, "dd/MM/yyyy") + " 00:00:00"), Conversions.ToDate(Strings.Format((object) Contract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00")) >= 0 & DateTime.Compare(Conversions.ToDate(Strings.Format((object) estVisitDate, "dd/MM/yyyy") + " 00:00:00"), Conversions.ToDate(Strings.Format((object) Contract.ContractEndDate, "dd/MM/yyyy") + " 00:00:00")) <= 0)
          {
            if (estVisitDate.DayOfWeek == DayOfWeek.Saturday)
              estVisitDate = estVisitDate.AddDays(2.0);
            else if (estVisitDate.DayOfWeek == DayOfWeek.Sunday)
              estVisitDate = estVisitDate.AddDays(1.0);
            Job job1 = new Job();
            job1.SetPropertyID = (object) CurrentContractSite.PropertyID;
            job1.SetJobDefinitionEnumID = (object) 2;
            job1.SetJobTypeID = (object) 0;
            job1.SetStatusEnumID = (object) 1;
            job1.SetCreatedByUserID = (object) App.loggedInUser.UserID;
            JobNumber jobNumber = new JobNumber();
            JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
            job1.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
            job1.SetPONumber = (object) "";
            job1.SetQuoteID = (object) 0;
            job1.SetContractID = (object) Contract.ContractID;
            if (Contract.ContractStatusID == 4)
              job1.SetDeleted = true;
            IEnumerator enumerator;
            try
            {
              enumerator = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(CurrentContractSite.ContractSiteID, CurrentContractSite.PropertyID).Table.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Tick"])))
                  job1.Assets.Add((object) new JobAsset()
                  {
                    SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"])
                  });
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            JobOfWork jobOfWork = new JobOfWork();
            jobOfWork.IgnoreExceptionsOnSetMethods = true;
            jobOfWork.SetPONumber = (object) "";
            jobOfWork.SetDeleted = true;
            jobOfWork.JobItems.Add((object) new JobItem()
            {
              IgnoreExceptionsOnSetMethods = true,
              SetSummary = (object) Helper.MakeStringValid((object) "PPM Contract Visit")
            });
            ArrayList arrayList1 = new ArrayList();
            int num5 = 0;
            DateTime dateTime2 = DateTime.MinValue;
            ArrayList arrayList2 = this.MatchingEngineerContractOne(job1, estVisitDate, (double) CurrentContractSite.VisitDuration);
            if (arrayList2 != null && arrayList2.Count > 0)
            {
              dateTime2 = Conversions.ToDate(arrayList2[0]);
              num5 = Conversions.ToInteger(arrayList2[1]);
            }
            EngineerVisit engineerVisit = new EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.SetEngineerID = (object) num5;
            engineerVisit.SetNotesToEngineer = (object) "PPM Contract Visit";
            if (num5 > 0)
            {
              engineerVisit.StartDateTime = dateTime2;
              engineerVisit.EndDateTime = dateTime2.AddHours((double) CurrentContractSite.VisitDuration);
              engineerVisit.SetStatusEnumID = (object) 5;
            }
            else
            {
              engineerVisit.StartDateTime = DateTime.MinValue;
              engineerVisit.EndDateTime = DateTime.MinValue;
              engineerVisit.SetStatusEnumID = (object) 4;
            }
            if (Contract.ContractStatusID == 4)
              engineerVisit.SetDeleted = true;
            jobOfWork.EngineerVisits.Add((object) engineerVisit);
            job1.JobOfWorks.Add((object) jobOfWork);
            Job job2 = App.DB.Job.Insert(job1);
            App.DB.ContractOriginalPPMVisit.Insert(new ContractOriginalPPMVisit()
            {
              SetContractSiteID = (object) CurrentContractSite.ContractSiteID,
              EstimatedVisitDate = estVisitDate,
              SetJobID = (object) job2.JobID
            });
            estVisitDate = estVisitDate.AddDays((double) num1);
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

    private ArrayList MatchingEngineerContractOne(
      Job job,
      DateTime estVisitDate,
      double visitDuration)
    {
      FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
      int numOfSlotsNeeded = 0;
      ArrayList arrayList1 = new ArrayList();
      int timeSlot = App.DB.Manager.Get().TimeSlot;
      if (visitDuration > 0.0)
        numOfSlotsNeeded = checked ((int) Math.Round(unchecked (visitDuration / (double) timeSlot)));
      FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) job.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
      if (site2.EngineerID > 0)
        arrayList1 = this.CheckAvailabilityContractOne(estVisitDate, site2.EngineerID, numOfSlotsNeeded);
      ArrayList arrayList2;
      if (arrayList1.Count > 0)
      {
        arrayList2 = arrayList1;
      }
      else
      {
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
            ArrayList arrayList3 = this.CheckAvailabilityContractOne(estVisitDate, Conversions.ToInteger(forPostcode.Table.Rows[index]["EngineerID"]), numOfSlotsNeeded);
            if (arrayList3.Count > 0)
            {
              arrayList2 = arrayList3;
              goto label_13;
            }
            else
            {
              forPostcode.Table.Rows.Remove(forPostcode.Table.Rows[index]);
              checked { ++num2; }
            }
          }
        }
      }
label_13:
      return arrayList2;
    }

    private ArrayList CheckAvailabilityContractOne(
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

    private void ScheduleJobContractTwo(
      DataView JobItemDV,
      DateTime FirstVisitDate,
      int ContractSiteJobOfWorkID,
      ContractAlternative CurrentContract,
      ContractAlternativeSite CurrentContractSite)
    {
      try
      {
        int days = CurrentContract.ContractEndDate.Subtract(CurrentContract.ContractStartDate).Days;
        int num1 = 0;
        switch (Conversions.ToInteger(JobItemDV.Table.Rows[0]["VisitFrequencyID"]))
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
        DateTime dateTime1 = Conversions.ToDate(Conversions.ToString(FirstVisitDate.Date) + " 09:00:00");
        int num3 = num2;
        int num4 = 1;
        while (num4 <= num3)
        {
          if (DateTime.Compare(dateTime1, CurrentContract.ContractStartDate) >= 0 & DateTime.Compare(dateTime1, CurrentContract.ContractEndDate) <= 0)
          {
            if (dateTime1.DayOfWeek == DayOfWeek.Saturday)
              dateTime1 = dateTime1.AddDays(2.0);
            else if (dateTime1.DayOfWeek == DayOfWeek.Sunday)
              dateTime1 = dateTime1.AddDays(1.0);
            Job job1 = new Job();
            job1.SetPropertyID = (object) CurrentContractSite.PropertyID;
            job1.SetJobDefinitionEnumID = (object) 2;
            job1.SetJobTypeID = (object) 0;
            job1.SetStatusEnumID = (object) 1;
            job1.SetCreatedByUserID = (object) App.loggedInUser.UserID;
            JobNumber jobNumber = new JobNumber();
            JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
            job1.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
            job1.SetPONumber = (object) "";
            job1.SetQuoteID = (object) 0;
            job1.SetContractID = (object) CurrentContract.ContractID;
            if (CurrentContract.ContractStatusID == 4)
              job1.SetDeleted = true;
            JobOfWork jobOfWork = new JobOfWork();
            jobOfWork.IgnoreExceptionsOnSetMethods = true;
            jobOfWork.SetPONumber = (object) "";
            if (CurrentContract.ContractStatusID == 4)
              jobOfWork.SetDeleted = true;
            int visitDuration = 0;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = JobItemDV.Table.Rows.GetEnumerator();
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
            DateTime dateTime2 = DateTime.MinValue;
            ArrayList arrayList2 = this.MatchingEngineerContractTwo(job1, dateTime1, visitDuration);
            if (arrayList2 != null && arrayList2.Count > 0)
            {
              dateTime2 = Conversions.ToDate(arrayList2[0]);
              num5 = Conversions.ToInteger(arrayList2[1]);
            }
            EngineerVisit engineerVisit = new EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.SetEngineerID = (object) num5;
            engineerVisit.SetNotesToEngineer = (object) "PPM Contract Visit";
            if (num5 > 0)
            {
              engineerVisit.StartDateTime = dateTime2;
              engineerVisit.EndDateTime = dateTime2.AddHours((double) visitDuration);
              engineerVisit.SetStatusEnumID = (object) 5;
            }
            else
            {
              engineerVisit.StartDateTime = DateTime.MinValue;
              engineerVisit.EndDateTime = DateTime.MinValue;
              engineerVisit.SetStatusEnumID = (object) 4;
            }
            if (CurrentContract.ContractStatusID == 4)
              engineerVisit.SetDeleted = true;
            jobOfWork.EngineerVisits.Add((object) engineerVisit);
            job1.JobOfWorks.Add((object) jobOfWork);
            Job job2 = App.DB.Job.Insert(job1);
            App.DB.ContractAlternativePPMVisit.Insert(new ContractAlternativePPMVisit()
            {
              SetContractSiteJobOfWorkID = (object) ContractSiteJobOfWorkID,
              EstimatedVisitDate = dateTime1,
              SetJobID = (object) job2.JobID
            });
            dateTime1 = dateTime1.AddDays((double) num1);
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

    private ArrayList MatchingEngineerContractTwo(
      Job job,
      DateTime estVisitDate,
      int visitDuration)
    {
      FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
      int numOfSlotsNeeded = 0;
      ArrayList arrayList1 = new ArrayList();
      int timeSlot = App.DB.Manager.Get().TimeSlot;
      if (visitDuration > 0)
        numOfSlotsNeeded = checked ((int) Math.Round(unchecked ((double) visitDuration / (double) timeSlot)));
      FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) job.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
      if (site2.EngineerID > 0)
        arrayList1 = this.CheckAvailabilityContractTwo(estVisitDate, site2.EngineerID, numOfSlotsNeeded);
      ArrayList arrayList2;
      if (arrayList1.Count > 0)
      {
        arrayList2 = arrayList1;
      }
      else
      {
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
            ArrayList arrayList3 = this.CheckAvailabilityContractTwo(estVisitDate, Conversions.ToInteger(forPostcode.Table.Rows[index]["EngineerID"]), numOfSlotsNeeded);
            if (arrayList3.Count > 0)
            {
              arrayList2 = arrayList3;
              goto label_13;
            }
            else
            {
              forPostcode.Table.Rows.Remove(forPostcode.Table.Rows[index]);
              checked { ++num2; }
            }
          }
        }
      }
label_13:
      return arrayList2;
    }

    private ArrayList CheckAvailabilityContractTwo(
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

    private void InsertInvoiceToBeRaiseLines(
      int InvoiceFrequencyID,
      DateTime StartDate,
      DateTime EndDate,
      DateTime FirstInvoiceDate,
      int InvoiceAddressID,
      int InvoiceAddressTypeID,
      int LinkID,
      int InvoiceType)
    {
      StartDate = Conversions.ToDate(Strings.Format((object) StartDate, "dd/MM/yyyy") + " 00:00:00");
      EndDate = Conversions.ToDate(Strings.Format((object) EndDate.AddDays(1.0), "dd/MM/yyyy") + " 00:00:00");
      int num1 = checked (Math.Abs(StartDate.Year - EndDate.Year) * 12 + Math.Abs(StartDate.Month - EndDate.Month));
      int days = EndDate.Subtract(StartDate).Days;
      int num2 = 0;
      switch (InvoiceFrequencyID)
      {
        case 2:
          num2 = checked ((int) Math.Round(unchecked ((double) num1 / 1.0)));
          break;
        case 3:
          num2 = checked ((int) Math.Round(unchecked ((double) num1 / 3.0)));
          break;
        case 4:
          num2 = checked ((int) Math.Round(unchecked ((double) num1 / 6.0)));
          break;
        case 6:
          num2 = checked ((int) Math.Round(unchecked ((double) num1 / 12.0)));
          break;
        case 8:
          num2 = checked ((int) Math.Round(unchecked ((double) num1 / 4.0)));
          break;
      }
      if (num2 == 0)
        num2 = 1;
      DateTime dateTime = FirstInvoiceDate;
      int num3 = num2;
      int num4 = 1;
      while (num4 <= num3)
      {
        App.DB.InvoiceToBeRaised.Insert(new InvoiceToBeRaised()
        {
          SetAddressLinkID = (object) InvoiceAddressID,
          SetAddressTypeID = (object) InvoiceAddressTypeID,
          SetInvoiceTypeID = (object) 327,
          SetLinkID = (object) LinkID,
          RaiseDate = dateTime
        });
        switch (InvoiceFrequencyID)
        {
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
          case 8:
            dateTime = dateTime.AddMonths(4);
            break;
        }
        checked { ++num4; }
      }
    }

    private void cboInvoiceFrequencyID_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
  }
}
