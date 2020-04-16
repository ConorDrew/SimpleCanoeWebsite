// Decompiled with JetBrains decompiler
// Type: FSM.UCContractOriginal
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractsOriginal;
using FSM.Entity.InvoiceToBeRaiseds;
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
  public class UCContractOriginal : UCBase, IUserControl
  {
    private IContainer components;
    private ContractOriginal _currentContract;
    private InvoiceToBeRaised _InvoiceToBeRaised;
    private int _IDToLinkTo;
    private DataView _Sites;
    private DataView _InvoiceAddresses;
    private int _SiteID;
    private bool _NumberUsed;
    public JobNumber Number;

    public UCContractOriginal()
    {
      this.Load += new EventHandler(this.UCContract_Load);
      this._IDToLinkTo = 0;
      this._SiteID = 0;
      this._NumberUsed = false;
      this.Number = (JobNumber) null;
      this.InitializeComponent();
      this.SetupSitesDataGrid();
      ComboBox invoiceFrequencyId = this.cboInvoiceFrequencyID;
      Combo.SetUpCombo(ref invoiceFrequencyId, DynamicDataTables.InvoiceFrequency_NoWeekly, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboInvoiceFrequencyID = invoiceFrequencyId;
      ComboBox contractStatusId = this.cboContractStatusID;
      Combo.SetUpCombo(ref contractStatusId, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboContractStatusID = contractStatusId;
      ComboBox cboContractType = this.cboContractType;
      Combo.SetUpCombo(ref cboContractType, App.DB.Picklists.GetAll(Enums.PickListTypes.ContractTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboContractType = cboContractType;
      ComboBox cboReasonId = this.cboReasonID;
      Combo.SetUpCombo(ref cboReasonId, App.DB.Picklists.GetAll(Enums.PickListTypes.CancellationReasons, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboReasonID = cboReasonId;
      ComboBox cboDiscount = this.cboDiscount;
      Combo.SetUpCombo(ref cboDiscount, App.DB.Picklists.GetAll(Enums.PickListTypes.CoverPlanDiscounts, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboDiscount = cboDiscount;
      ComboBox cboInvType = this.cboInvType;
      Combo.SetUpCombo(ref cboInvType, App.DB.Picklists.GetAll(Enums.PickListTypes.InvoiceTerms, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboInvType = cboInvType;
      ComboBox cboPaidBy = this.cboPaidBy;
      Combo.SetUpCombo(ref cboPaidBy, App.DB.Picklists.GetAll(Enums.PickListTypes.Locations | Enums.PickListTypes.Symptoms, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPaidBy = cboPaidBy;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpContract { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpContractStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractStartDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpContractEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboContractStatusID
    {
      get
      {
        return this._cboContractStatusID;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboContractStatusID_SelectedIndexChanged);
        ComboBox contractStatusId1 = this._cboContractStatusID;
        if (contractStatusId1 != null)
          contractStatusId1.SelectedIndexChanged -= eventHandler;
        this._cboContractStatusID = value;
        ComboBox contractStatusId2 = this._cboContractStatusID;
        if (contractStatusId2 == null)
          return;
        contractStatusId2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblContractStatusID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContractPrice
    {
      get
      {
        return this._txtContractPrice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtContractPrice_LostFocus);
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

    internal virtual Label lblContractPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual GroupBox grpSites { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSites
    {
      get
      {
        return this._dgSites;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgSites_MouseUp);
        EventHandler eventHandler = new EventHandler(this.dgSites_DoubleClick);
        NavigateEventHandler navigateEventHandler = new NavigateEventHandler(this.dgSites_Navigate);
        DataGrid dgSites1 = this._dgSites;
        if (dgSites1 != null)
        {
          dgSites1.MouseUp -= mouseEventHandler;
          dgSites1.DoubleClick -= eventHandler;
          dgSites1.Navigate -= navigateEventHandler;
        }
        this._dgSites = value;
        DataGrid dgSites2 = this._dgSites;
        if (dgSites2 == null)
          return;
        dgSites2.MouseUp += mouseEventHandler;
        dgSites2.DoubleClick += eventHandler;
        dgSites2.Navigate += navigateEventHandler;
      }
    }

    internal virtual Label lblMsg { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFirstInvoiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFirstInvoiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label lblContractType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboContractType
    {
      get
      {
        return this._cboContractType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboContractType_SelectedIndexChanged);
        ComboBox cboContractType1 = this._cboContractType;
        if (cboContractType1 != null)
          cboContractType1.SelectedIndexChanged -= eventHandler;
        this._cboContractType = value;
        ComboBox cboContractType2 = this._cboContractType;
        if (cboContractType2 == null)
          return;
        cboContractType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TabControl tcBottomSection { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabProperties { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabChargeDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbChargeDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rdoCheque { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rdoCreditCard { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rdoDirectDebit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBankName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAccountNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSortCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblBankName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAccount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkGasSupplyPipework { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCancelledDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpCancelledDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkPlumbingDrainage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkWindowLockPest { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPONumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPONumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cboDoNotRenew { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDDMSRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDDMSRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDiscount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDiscount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboReasonID
    {
      get
      {
        return this._cboReasonID;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboReasonID_SelectedIndexChanged_1);
        ComboBox cboReasonId1 = this._cboReasonID;
        if (cboReasonId1 != null)
          cboReasonId1.SelectedIndexChanged -= eventHandler;
        this._cboReasonID = value;
        ComboBox cboReasonId2 = this._cboReasonID;
        if (cboReasonId2 == null)
          return;
        cboReasonId2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblReason { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabAdditionalNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbInvoiceInformation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RichTextBox txtAdditionalInvoiceNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInvType
    {
      get
      {
        return this._cboInvType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboInvType_SelectedIndexChanged);
        ComboBox cboInvType1 = this._cboInvType;
        if (cboInvType1 != null)
          cboInvType1.SelectedIndexChanged -= eventHandler;
        this._cboInvType = value;
        ComboBox cboInvType2 = this._cboInvType;
        if (cboInvType2 == null)
          return;
        cboInvType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblInvType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPaidBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPaidBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSearchFilter
    {
      get
      {
        return this._txtSearchFilter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.filterChange);
        TextBox txtSearchFilter1 = this._txtSearchFilter;
        if (txtSearchFilter1 != null)
          txtSearchFilter1.TextChanged -= eventHandler;
        this._txtSearchFilter = value;
        TextBox txtSearchFilter2 = this._txtSearchFilter;
        if (txtSearchFilter2 == null)
          return;
        txtSearchFilter2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lblSearchFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSortCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpContract = new GroupBox();
      this.txtSearchFilter = new TextBox();
      this.lblSearchFilter = new Label();
      this.cboPaidBy = new ComboBox();
      this.lblPaidBy = new Label();
      this.lblMsg = new Label();
      this.lblInvType = new Label();
      this.cboInvType = new ComboBox();
      this.cboReasonID = new ComboBox();
      this.lblReason = new Label();
      this.lblDiscount = new Label();
      this.cboDiscount = new ComboBox();
      this.txtDDMSRef = new TextBox();
      this.lblDDMSRef = new Label();
      this.cboDoNotRenew = new CheckBox();
      this.txtContractReference = new TextBox();
      this.lblContractReference = new Label();
      this.txtPONumber = new TextBox();
      this.lblPONumber = new Label();
      this.chkPlumbingDrainage = new CheckBox();
      this.chkWindowLockPest = new CheckBox();
      this.lblCancelledDate = new Label();
      this.dtpCancelledDate = new DateTimePicker();
      this.chkGasSupplyPipework = new CheckBox();
      this.tcBottomSection = new TabControl();
      this.tabProperties = new TabPage();
      this.grpSites = new GroupBox();
      this.dgSites = new DataGrid();
      this.tabChargeDetails = new TabPage();
      this.gpbChargeDetails = new GroupBox();
      this.lblSortCode = new Label();
      this.lblAccount = new Label();
      this.lblBankName = new Label();
      this.txtSortCode = new TextBox();
      this.txtAccountNumber = new TextBox();
      this.txtBankName = new TextBox();
      this.rdoDirectDebit = new RadioButton();
      this.rdoCreditCard = new RadioButton();
      this.rdoCheque = new RadioButton();
      this.tabAdditionalNotes = new TabPage();
      this.gpbInvoiceInformation = new GroupBox();
      this.txtAdditionalInvoiceNotes = new RichTextBox();
      this.cboContractType = new ComboBox();
      this.lblContractType = new Label();
      this.gpbInvoiceAddress = new GroupBox();
      this.dgInvoiceAddress = new DataGrid();
      this.dtpFirstInvoiceDate = new DateTimePicker();
      this.lblFirstInvoiceDate = new Label();
      this.dtpContractStartDate = new DateTimePicker();
      this.lblContractStartDate = new Label();
      this.dtpContractEndDate = new DateTimePicker();
      this.lblContractEndDate = new Label();
      this.cboContractStatusID = new ComboBox();
      this.lblContractStatusID = new Label();
      this.txtContractPrice = new TextBox();
      this.lblContractPrice = new Label();
      this.cboInvoiceFrequencyID = new ComboBox();
      this.lblInvoiceFrequencyID = new Label();
      this.grpContract.SuspendLayout();
      this.tcBottomSection.SuspendLayout();
      this.tabProperties.SuspendLayout();
      this.grpSites.SuspendLayout();
      this.dgSites.BeginInit();
      this.tabChargeDetails.SuspendLayout();
      this.gpbChargeDetails.SuspendLayout();
      this.tabAdditionalNotes.SuspendLayout();
      this.gpbInvoiceInformation.SuspendLayout();
      this.gpbInvoiceAddress.SuspendLayout();
      this.dgInvoiceAddress.BeginInit();
      this.SuspendLayout();
      this.grpContract.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContract.Controls.Add((Control) this.txtSearchFilter);
      this.grpContract.Controls.Add((Control) this.lblSearchFilter);
      this.grpContract.Controls.Add((Control) this.cboPaidBy);
      this.grpContract.Controls.Add((Control) this.lblPaidBy);
      this.grpContract.Controls.Add((Control) this.lblMsg);
      this.grpContract.Controls.Add((Control) this.lblInvType);
      this.grpContract.Controls.Add((Control) this.cboInvType);
      this.grpContract.Controls.Add((Control) this.cboReasonID);
      this.grpContract.Controls.Add((Control) this.lblReason);
      this.grpContract.Controls.Add((Control) this.lblDiscount);
      this.grpContract.Controls.Add((Control) this.cboDiscount);
      this.grpContract.Controls.Add((Control) this.txtDDMSRef);
      this.grpContract.Controls.Add((Control) this.lblDDMSRef);
      this.grpContract.Controls.Add((Control) this.cboDoNotRenew);
      this.grpContract.Controls.Add((Control) this.txtContractReference);
      this.grpContract.Controls.Add((Control) this.lblContractReference);
      this.grpContract.Controls.Add((Control) this.txtPONumber);
      this.grpContract.Controls.Add((Control) this.lblPONumber);
      this.grpContract.Controls.Add((Control) this.chkPlumbingDrainage);
      this.grpContract.Controls.Add((Control) this.chkWindowLockPest);
      this.grpContract.Controls.Add((Control) this.lblCancelledDate);
      this.grpContract.Controls.Add((Control) this.dtpCancelledDate);
      this.grpContract.Controls.Add((Control) this.chkGasSupplyPipework);
      this.grpContract.Controls.Add((Control) this.tcBottomSection);
      this.grpContract.Controls.Add((Control) this.cboContractType);
      this.grpContract.Controls.Add((Control) this.lblContractType);
      this.grpContract.Controls.Add((Control) this.gpbInvoiceAddress);
      this.grpContract.Controls.Add((Control) this.dtpFirstInvoiceDate);
      this.grpContract.Controls.Add((Control) this.lblFirstInvoiceDate);
      this.grpContract.Controls.Add((Control) this.dtpContractStartDate);
      this.grpContract.Controls.Add((Control) this.lblContractStartDate);
      this.grpContract.Controls.Add((Control) this.dtpContractEndDate);
      this.grpContract.Controls.Add((Control) this.lblContractEndDate);
      this.grpContract.Controls.Add((Control) this.cboContractStatusID);
      this.grpContract.Controls.Add((Control) this.lblContractStatusID);
      this.grpContract.Controls.Add((Control) this.txtContractPrice);
      this.grpContract.Controls.Add((Control) this.lblContractPrice);
      this.grpContract.Controls.Add((Control) this.cboInvoiceFrequencyID);
      this.grpContract.Controls.Add((Control) this.lblInvoiceFrequencyID);
      this.grpContract.Location = new System.Drawing.Point(8, 8);
      this.grpContract.Name = "grpContract";
      this.grpContract.Size = new Size(769, 627);
      this.grpContract.TabIndex = 0;
      this.grpContract.TabStop = false;
      this.grpContract.Text = "Main Details";
      this.txtSearchFilter.Location = new System.Drawing.Point(496, 133);
      this.txtSearchFilter.MaxLength = 100;
      this.txtSearchFilter.Name = "txtSearchFilter";
      this.txtSearchFilter.Size = new Size(248, 21);
      this.txtSearchFilter.TabIndex = 44;
      this.txtSearchFilter.Tag = (object) "";
      this.lblSearchFilter.Location = new System.Drawing.Point(360, 137);
      this.lblSearchFilter.Name = "lblSearchFilter";
      this.lblSearchFilter.Size = new Size(132, 20);
      this.lblSearchFilter.TabIndex = 43;
      this.lblSearchFilter.Text = "Search Filter";
      this.cboPaidBy.FormattingEnabled = true;
      this.cboPaidBy.Location = new System.Drawing.Point(496, 105);
      this.cboPaidBy.Name = "cboPaidBy";
      this.cboPaidBy.Size = new Size(248, 21);
      this.cboPaidBy.TabIndex = 41;
      this.cboPaidBy.Visible = false;
      this.lblPaidBy.Location = new System.Drawing.Point(360, 106);
      this.lblPaidBy.Name = "lblPaidBy";
      this.lblPaidBy.Size = new Size(130, 17);
      this.lblPaidBy.TabIndex = 42;
      this.lblPaidBy.Text = "Paid By";
      this.lblPaidBy.TextAlign = ContentAlignment.MiddleLeft;
      this.lblPaidBy.Visible = false;
      this.lblMsg.BackColor = Color.LightGoldenrodYellow;
      this.lblMsg.BorderStyle = BorderStyle.FixedSingle;
      this.lblMsg.Location = new System.Drawing.Point(366, 366);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new Size(376, 23);
      this.lblMsg.TabIndex = 25;
      this.lblMsg.Text = "Please save before adding properties";
      this.lblMsg.TextAlign = ContentAlignment.MiddleLeft;
      this.lblInvType.Location = new System.Drawing.Point(360, 79);
      this.lblInvType.Name = "lblInvType";
      this.lblInvType.Size = new Size(130, 17);
      this.lblInvType.TabIndex = 40;
      this.lblInvType.Text = "Invoice Type";
      this.lblInvType.TextAlign = ContentAlignment.MiddleLeft;
      this.cboInvType.FormattingEnabled = true;
      this.cboInvType.Location = new System.Drawing.Point(496, 78);
      this.cboInvType.Name = "cboInvType";
      this.cboInvType.Size = new Size(248, 21);
      this.cboInvType.TabIndex = 39;
      this.cboReasonID.Cursor = Cursors.Hand;
      this.cboReasonID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboReasonID.Location = new System.Drawing.Point(144, 242);
      this.cboReasonID.Name = "cboReasonID";
      this.cboReasonID.Size = new Size(195, 21);
      this.cboReasonID.TabIndex = 38;
      this.cboReasonID.Tag = (object) "Contract.ContractStatusID";
      this.lblReason.Location = new System.Drawing.Point(17, 245);
      this.lblReason.Name = "lblReason";
      this.lblReason.Size = new Size(132, 20);
      this.lblReason.TabIndex = 37;
      this.lblReason.Text = "Reason";
      this.lblDiscount.Location = new System.Drawing.Point(17, 321);
      this.lblDiscount.Name = "lblDiscount";
      this.lblDiscount.Size = new Size(121, 20);
      this.lblDiscount.TabIndex = 36;
      this.lblDiscount.Text = "Discount";
      this.cboDiscount.Cursor = Cursors.Hand;
      this.cboDiscount.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDiscount.Location = new System.Drawing.Point(144, 318);
      this.cboDiscount.Name = "cboDiscount";
      this.cboDiscount.Size = new Size(195, 21);
      this.cboDiscount.TabIndex = 35;
      this.cboDiscount.Tag = (object) "";
      this.txtDDMSRef.Location = new System.Drawing.Point(494, 310);
      this.txtDDMSRef.MaxLength = 100;
      this.txtDDMSRef.Name = "txtDDMSRef";
      this.txtDDMSRef.Size = new Size(248, 21);
      this.txtDDMSRef.TabIndex = 34;
      this.txtDDMSRef.Tag = (object) "";
      this.lblDDMSRef.Location = new System.Drawing.Point(367, 313);
      this.lblDDMSRef.Name = "lblDDMSRef";
      this.lblDDMSRef.Size = new Size(132, 20);
      this.lblDDMSRef.TabIndex = 33;
      this.lblDDMSRef.Text = "DDMS Ref";
      this.cboDoNotRenew.AutoSize = true;
      this.cboDoNotRenew.Location = new System.Drawing.Point(20, 296);
      this.cboDoNotRenew.Name = "cboDoNotRenew";
      this.cboDoNotRenew.Size = new Size(107, 17);
      this.cboDoNotRenew.TabIndex = 32;
      this.cboDoNotRenew.Text = "Do Not Renew";
      this.cboDoNotRenew.UseVisualStyleBackColor = true;
      this.txtContractReference.Location = new System.Drawing.Point(144, 45);
      this.txtContractReference.MaxLength = 100;
      this.txtContractReference.Name = "txtContractReference";
      this.txtContractReference.Size = new Size(195, 21);
      this.txtContractReference.TabIndex = 31;
      this.txtContractReference.Tag = (object) "Contract.ContractReference";
      this.lblContractReference.Location = new System.Drawing.Point(16, 47);
      this.lblContractReference.Name = "lblContractReference";
      this.lblContractReference.Size = new Size(132, 20);
      this.lblContractReference.TabIndex = 30;
      this.lblContractReference.Text = "Contract Reference";
      this.txtPONumber.Location = new System.Drawing.Point(494, 337);
      this.txtPONumber.MaxLength = 100;
      this.txtPONumber.Name = "txtPONumber";
      this.txtPONumber.Size = new Size(248, 21);
      this.txtPONumber.TabIndex = 29;
      this.txtPONumber.Tag = (object) "";
      this.lblPONumber.Location = new System.Drawing.Point(367, 340);
      this.lblPONumber.Name = "lblPONumber";
      this.lblPONumber.Size = new Size(132, 20);
      this.lblPONumber.TabIndex = 28;
      this.lblPONumber.Text = "PO Number";
      this.chkPlumbingDrainage.AutoSize = true;
      this.chkPlumbingDrainage.Location = new System.Drawing.Point(20, 201);
      this.chkPlumbingDrainage.Name = "chkPlumbingDrainage";
      this.chkPlumbingDrainage.Size = new Size(252, 17);
      this.chkPlumbingDrainage.TabIndex = 27;
      this.chkPlumbingDrainage.Text = "Plumbing, drainage and electrical cover";
      this.chkPlumbingDrainage.UseVisualStyleBackColor = true;
      this.chkWindowLockPest.AutoSize = true;
      this.chkWindowLockPest.Location = new System.Drawing.Point(20, 221);
      this.chkWindowLockPest.Name = "chkWindowLockPest";
      this.chkWindowLockPest.Size = new Size(190, 17);
      this.chkWindowLockPest.TabIndex = 26;
      this.chkWindowLockPest.Text = "Window, lock and pest cover";
      this.chkWindowLockPest.UseVisualStyleBackColor = true;
      this.lblCancelledDate.Location = new System.Drawing.Point(17, 275);
      this.lblCancelledDate.Name = "lblCancelledDate";
      this.lblCancelledDate.Size = new Size(121, 20);
      this.lblCancelledDate.TabIndex = 15;
      this.lblCancelledDate.Text = "Cancelled Date";
      this.dtpCancelledDate.Location = new System.Drawing.Point(144, 271);
      this.dtpCancelledDate.Name = "dtpCancelledDate";
      this.dtpCancelledDate.Size = new Size(195, 21);
      this.dtpCancelledDate.TabIndex = 16;
      this.chkGasSupplyPipework.AutoSize = true;
      this.chkGasSupplyPipework.Location = new System.Drawing.Point(20, 180);
      this.chkGasSupplyPipework.Name = "chkGasSupplyPipework";
      this.chkGasSupplyPipework.Size = new Size(147, 17);
      this.chkGasSupplyPipework.TabIndex = 14;
      this.chkGasSupplyPipework.Text = "Gas Supply Pipework";
      this.chkGasSupplyPipework.UseVisualStyleBackColor = true;
      this.tcBottomSection.Controls.Add((Control) this.tabProperties);
      this.tcBottomSection.Controls.Add((Control) this.tabChargeDetails);
      this.tcBottomSection.Controls.Add((Control) this.tabAdditionalNotes);
      this.tcBottomSection.Location = new System.Drawing.Point(19, 374);
      this.tcBottomSection.Name = "tcBottomSection";
      this.tcBottomSection.SelectedIndex = 0;
      this.tcBottomSection.Size = new Size(736, 249);
      this.tcBottomSection.TabIndex = 24;
      this.tabProperties.Controls.Add((Control) this.grpSites);
      this.tabProperties.Location = new System.Drawing.Point(4, 22);
      this.tabProperties.Name = "tabProperties";
      this.tabProperties.Size = new Size(728, 223);
      this.tabProperties.TabIndex = 0;
      this.tabProperties.Text = "Properties";
      this.grpSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSites.Controls.Add((Control) this.dgSites);
      this.grpSites.Location = new System.Drawing.Point(8, 3);
      this.grpSites.Name = "grpSites";
      this.grpSites.RightToLeft = RightToLeft.No;
      this.grpSites.Size = new Size(720, 214);
      this.grpSites.TabIndex = 0;
      this.grpSites.TabStop = false;
      this.grpSites.Text = "Properties - Double click to view/edit";
      this.dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSites.DataMember = "";
      this.dgSites.HeaderForeColor = SystemColors.ControlText;
      this.dgSites.Location = new System.Drawing.Point(11, 22);
      this.dgSites.Name = "dgSites";
      this.dgSites.Size = new Size(700, 185);
      this.dgSites.TabIndex = 0;
      this.tabChargeDetails.Controls.Add((Control) this.gpbChargeDetails);
      this.tabChargeDetails.Location = new System.Drawing.Point(4, 22);
      this.tabChargeDetails.Name = "tabChargeDetails";
      this.tabChargeDetails.Size = new Size(728, 223);
      this.tabChargeDetails.TabIndex = 1;
      this.tabChargeDetails.Text = "Charge Details";
      this.gpbChargeDetails.Controls.Add((Control) this.lblSortCode);
      this.gpbChargeDetails.Controls.Add((Control) this.lblAccount);
      this.gpbChargeDetails.Controls.Add((Control) this.lblBankName);
      this.gpbChargeDetails.Controls.Add((Control) this.txtSortCode);
      this.gpbChargeDetails.Controls.Add((Control) this.txtAccountNumber);
      this.gpbChargeDetails.Controls.Add((Control) this.txtBankName);
      this.gpbChargeDetails.Controls.Add((Control) this.rdoDirectDebit);
      this.gpbChargeDetails.Controls.Add((Control) this.rdoCreditCard);
      this.gpbChargeDetails.Controls.Add((Control) this.rdoCheque);
      this.gpbChargeDetails.Location = new System.Drawing.Point(8, 0);
      this.gpbChargeDetails.Name = "gpbChargeDetails";
      this.gpbChargeDetails.Size = new Size(712, 320);
      this.gpbChargeDetails.TabIndex = 0;
      this.gpbChargeDetails.TabStop = false;
      this.gpbChargeDetails.Text = "Charge Details";
      this.lblSortCode.Location = new System.Drawing.Point(128, 152);
      this.lblSortCode.Name = "lblSortCode";
      this.lblSortCode.Size = new Size(100, 23);
      this.lblSortCode.TabIndex = 8;
      this.lblSortCode.Text = "Sort Code";
      this.lblAccount.Location = new System.Drawing.Point(128, 120);
      this.lblAccount.Name = "lblAccount";
      this.lblAccount.Size = new Size(100, 23);
      this.lblAccount.TabIndex = 7;
      this.lblAccount.Text = "Account Number";
      this.lblBankName.Location = new System.Drawing.Point(128, 88);
      this.lblBankName.Name = "lblBankName";
      this.lblBankName.Size = new Size(100, 23);
      this.lblBankName.TabIndex = 6;
      this.lblBankName.Text = "Bank Name";
      this.txtSortCode.Location = new System.Drawing.Point(232, 152);
      this.txtSortCode.Name = "txtSortCode";
      this.txtSortCode.Size = new Size(360, 21);
      this.txtSortCode.TabIndex = 5;
      this.txtAccountNumber.Location = new System.Drawing.Point(232, 120);
      this.txtAccountNumber.Name = "txtAccountNumber";
      this.txtAccountNumber.Size = new Size(360, 21);
      this.txtAccountNumber.TabIndex = 4;
      this.txtBankName.Location = new System.Drawing.Point(232, 88);
      this.txtBankName.Name = "txtBankName";
      this.txtBankName.Size = new Size(360, 21);
      this.txtBankName.TabIndex = 3;
      this.rdoDirectDebit.Location = new System.Drawing.Point(16, 88);
      this.rdoDirectDebit.Name = "rdoDirectDebit";
      this.rdoDirectDebit.Size = new Size(104, 24);
      this.rdoDirectDebit.TabIndex = 2;
      this.rdoDirectDebit.Text = "Direct Debit";
      this.rdoCreditCard.Location = new System.Drawing.Point(16, 56);
      this.rdoCreditCard.Name = "rdoCreditCard";
      this.rdoCreditCard.Size = new Size(104, 24);
      this.rdoCreditCard.TabIndex = 1;
      this.rdoCreditCard.Text = "Credit Card";
      this.rdoCheque.Location = new System.Drawing.Point(16, 24);
      this.rdoCheque.Name = "rdoCheque";
      this.rdoCheque.Size = new Size(104, 24);
      this.rdoCheque.TabIndex = 0;
      this.rdoCheque.Text = "Cheque";
      this.tabAdditionalNotes.Controls.Add((Control) this.gpbInvoiceInformation);
      this.tabAdditionalNotes.Location = new System.Drawing.Point(4, 22);
      this.tabAdditionalNotes.Name = "tabAdditionalNotes";
      this.tabAdditionalNotes.Size = new Size(728, 223);
      this.tabAdditionalNotes.TabIndex = 2;
      this.tabAdditionalNotes.Text = "Additional Notes";
      this.tabAdditionalNotes.UseVisualStyleBackColor = true;
      this.gpbInvoiceInformation.BackColor = SystemColors.Control;
      this.gpbInvoiceInformation.Controls.Add((Control) this.txtAdditionalInvoiceNotes);
      this.gpbInvoiceInformation.Dock = DockStyle.Fill;
      this.gpbInvoiceInformation.Location = new System.Drawing.Point(0, 0);
      this.gpbInvoiceInformation.Name = "gpbInvoiceInformation";
      this.gpbInvoiceInformation.Size = new Size(728, 223);
      this.gpbInvoiceInformation.TabIndex = 3;
      this.gpbInvoiceInformation.TabStop = false;
      this.gpbInvoiceInformation.Text = "Additional Notes";
      this.txtAdditionalInvoiceNotes.Location = new System.Drawing.Point(6, 20);
      this.txtAdditionalInvoiceNotes.Name = "txtAdditionalInvoiceNotes";
      this.txtAdditionalInvoiceNotes.Size = new Size(499, 130);
      this.txtAdditionalInvoiceNotes.TabIndex = 13;
      this.txtAdditionalInvoiceNotes.Text = "";
      this.cboContractType.Cursor = Cursors.Hand;
      this.cboContractType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboContractType.Location = new System.Drawing.Point(144, 20);
      this.cboContractType.Name = "cboContractType";
      this.cboContractType.Size = new Size(195, 21);
      this.cboContractType.TabIndex = 4;
      this.cboContractType.Tag = (object) "";
      this.lblContractType.Location = new System.Drawing.Point(16, 22);
      this.lblContractType.Name = "lblContractType";
      this.lblContractType.Size = new Size(132, 20);
      this.lblContractType.TabIndex = 3;
      this.lblContractType.Text = "Contract Type";
      this.gpbInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbInvoiceAddress.Controls.Add((Control) this.dgInvoiceAddress);
      this.gpbInvoiceAddress.Location = new System.Drawing.Point(363, 160);
      this.gpbInvoiceAddress.Name = "gpbInvoiceAddress";
      this.gpbInvoiceAddress.Size = new Size(392, 140);
      this.gpbInvoiceAddress.TabIndex = 23;
      this.gpbInvoiceAddress.TabStop = false;
      this.gpbInvoiceAddress.Text = "Invoice Address";
      this.dgInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgInvoiceAddress.DataMember = "";
      this.dgInvoiceAddress.HeaderForeColor = SystemColors.ControlText;
      this.dgInvoiceAddress.Location = new System.Drawing.Point(8, 20);
      this.dgInvoiceAddress.Name = "dgInvoiceAddress";
      this.dgInvoiceAddress.Size = new Size(376, 112);
      this.dgInvoiceAddress.TabIndex = 0;
      this.dtpFirstInvoiceDate.Location = new System.Drawing.Point(496, 51);
      this.dtpFirstInvoiceDate.Name = "dtpFirstInvoiceDate";
      this.dtpFirstInvoiceDate.Size = new Size(248, 21);
      this.dtpFirstInvoiceDate.TabIndex = 22;
      this.dtpFirstInvoiceDate.Tag = (object) "";
      this.lblFirstInvoiceDate.Location = new System.Drawing.Point(360, 57);
      this.lblFirstInvoiceDate.Name = "lblFirstInvoiceDate";
      this.lblFirstInvoiceDate.Size = new Size(132, 20);
      this.lblFirstInvoiceDate.TabIndex = 21;
      this.lblFirstInvoiceDate.Text = "First Invoice Date";
      this.dtpContractStartDate.Location = new System.Drawing.Point(144, 96);
      this.dtpContractStartDate.Name = "dtpContractStartDate";
      this.dtpContractStartDate.Size = new Size(195, 21);
      this.dtpContractStartDate.TabIndex = 8;
      this.dtpContractStartDate.Tag = (object) "Contract.ContractStartDate";
      this.lblContractStartDate.Location = new System.Drawing.Point(17, 96);
      this.lblContractStartDate.Name = "lblContractStartDate";
      this.lblContractStartDate.Size = new Size(132, 20);
      this.lblContractStartDate.TabIndex = 7;
      this.lblContractStartDate.Text = "Contract Start Date";
      this.dtpContractEndDate.Location = new System.Drawing.Point(144, 120);
      this.dtpContractEndDate.Name = "dtpContractEndDate";
      this.dtpContractEndDate.Size = new Size(195, 21);
      this.dtpContractEndDate.TabIndex = 10;
      this.dtpContractEndDate.Tag = (object) "Contract.ContractEndDate";
      this.lblContractEndDate.Location = new System.Drawing.Point(17, 120);
      this.lblContractEndDate.Name = "lblContractEndDate";
      this.lblContractEndDate.Size = new Size(132, 20);
      this.lblContractEndDate.TabIndex = 9;
      this.lblContractEndDate.Text = "Contract End Date";
      this.cboContractStatusID.Cursor = Cursors.Hand;
      this.cboContractStatusID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboContractStatusID.Location = new System.Drawing.Point(144, 72);
      this.cboContractStatusID.Name = "cboContractStatusID";
      this.cboContractStatusID.Size = new Size(195, 21);
      this.cboContractStatusID.TabIndex = 6;
      this.cboContractStatusID.Tag = (object) "Contract.ContractStatusID";
      this.lblContractStatusID.Location = new System.Drawing.Point(17, 72);
      this.lblContractStatusID.Name = "lblContractStatusID";
      this.lblContractStatusID.Size = new Size(132, 20);
      this.lblContractStatusID.TabIndex = 5;
      this.lblContractStatusID.Text = "Contract Status";
      this.lblContractStatusID.Visible = false;
      this.txtContractPrice.Location = new System.Drawing.Point(144, 144);
      this.txtContractPrice.MaxLength = 9;
      this.txtContractPrice.Name = "txtContractPrice";
      this.txtContractPrice.Size = new Size(195, 21);
      this.txtContractPrice.TabIndex = 12;
      this.txtContractPrice.Tag = (object) "Contract.ContractPrice";
      this.lblContractPrice.Location = new System.Drawing.Point(16, 144);
      this.lblContractPrice.Name = "lblContractPrice";
      this.lblContractPrice.Size = new Size(132, 20);
      this.lblContractPrice.TabIndex = 11;
      this.lblContractPrice.Text = "Total Contract Price";
      this.cboInvoiceFrequencyID.Cursor = Cursors.Hand;
      this.cboInvoiceFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInvoiceFrequencyID.Location = new System.Drawing.Point(496, 24);
      this.cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID";
      this.cboInvoiceFrequencyID.Size = new Size(248, 21);
      this.cboInvoiceFrequencyID.TabIndex = 20;
      this.cboInvoiceFrequencyID.Tag = (object) "Contract.InvoiceFrequencyID";
      this.lblInvoiceFrequencyID.Location = new System.Drawing.Point(360, 27);
      this.lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID";
      this.lblInvoiceFrequencyID.Size = new Size(132, 20);
      this.lblInvoiceFrequencyID.TabIndex = 19;
      this.lblInvoiceFrequencyID.Text = "Invoice Frequency";
      this.Controls.Add((Control) this.grpContract);
      this.Name = nameof (UCContractOriginal);
      this.Size = new Size(784, 638);
      this.grpContract.ResumeLayout(false);
      this.grpContract.PerformLayout();
      this.tcBottomSection.ResumeLayout(false);
      this.tabProperties.ResumeLayout(false);
      this.grpSites.ResumeLayout(false);
      this.dgSites.EndInit();
      this.tabChargeDetails.ResumeLayout(false);
      this.gpbChargeDetails.ResumeLayout(false);
      this.gpbChargeDetails.PerformLayout();
      this.tabAdditionalNotes.ResumeLayout(false);
      this.gpbInvoiceInformation.ResumeLayout(false);
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
        return (object) this.CurrentContract;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public ContractOriginal CurrentContract
    {
      get
      {
        return this._currentContract;
      }
      set
      {
        this._currentContract = value;
        if (this._currentContract == null)
        {
          this._currentContract = new ContractOriginal();
          this._currentContract.Exists = false;
          ComboBox contractStatusId = this.cboContractStatusID;
          Combo.SetSelectedComboItem_By_Value(ref contractStatusId, Conversions.ToString(3));
          this.cboContractStatusID = contractStatusId;
        }
        if (this._currentContract.Exists)
        {
          this.Populate(0);
          this.grpSites.Enabled = true;
          this.lblMsg.Visible = false;
          this.dtpContractEndDate.Enabled = false;
          this.dtpContractStartDate.Enabled = false;
          this.dtpFirstInvoiceDate.Enabled = false;
          this.cboInvoiceFrequencyID.Enabled = false;
          this.gpbInvoiceAddress.Enabled = false;
        }
        else
        {
          this.grpSites.Enabled = false;
          this.lblMsg.Visible = true;
          this.txtContractPrice.Text = Strings.Format((object) 0.0, "C");
        }
      }
    }

    public InvoiceToBeRaised InvoiceToBeRaised
    {
      get
      {
        return this._InvoiceToBeRaised;
      }
      set
      {
        this._InvoiceToBeRaised = value;
        if (this.InvoiceToBeRaised == null)
        {
          this.InvoiceToBeRaised = new InvoiceToBeRaised();
          this.InvoiceToBeRaised.Exists = false;
          ComboBox cboInvType = this.cboInvType;
          Combo.SetSelectedComboItem_By_Value(ref cboInvType, Conversions.ToString(1));
          this.cboInvType = cboInvType;
        }
        else
        {
          ComboBox cboInvType = this.cboInvType;
          Combo.SetSelectedComboItem_By_Value(ref cboInvType, Conversions.ToString(this.InvoiceToBeRaised.PaymentTermID));
          this.cboInvType = cboInvType;
        }
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
        if (!this.CurrentContract.Exists)
        {
          DataTable table = App.DB.Customer.Customer_Contracts_GetAll(this.IDToLinkTo).Table;
          if (table.Rows.Count > 0)
          {
            int length = table.Select("ContractType = 'Contract_Opt_1'").Length;
            if (length > 0)
            {
              this.txtContractReference.Text = Conversions.ToString(table.Select("ContractType = 'Contract_Opt_1'")[checked (length - 1)]["ContractReference"]);
              this.txtContractReference.Text = "";
            }
          }
        }
        this.Sites = App.DB.ContractOriginalSite.GetAll_ContractID(this.CurrentContract.ContractID, this.IDToLinkTo);
        this.InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(this.IDToLinkTo);
        if (this.CurrentContract.InvoiceAddressID > 0)
        {
          int num = 0;
          IEnumerator enumerator;
          try
          {
            enumerator = this.InvoiceAddresses.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AddressID"], (object) this.CurrentContract.InvoiceAddressID, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["AddressTypeID"], (object) this.CurrentContract.InvoiceAddressTypeID, false))))
              {
                this.dgInvoiceAddress.CurrentRowIndex = num;
                break;
              }
              checked { ++num; }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        else
          this.dgInvoiceAddress.CurrentRowIndex = 0;
        this.dgInvoiceAddress.Select(this.dgInvoiceAddress.CurrentRowIndex);
      }
    }

    public DataView Sites
    {
      get
      {
        return this._Sites;
      }
      set
      {
        this._Sites = value;
        this._Sites.Table.TableName = Enums.TableNames.tblContractSite.ToString();
        this._Sites.AllowNew = false;
        this._Sites.AllowEdit = false;
        this._Sites.AllowDelete = false;
        this.SiteID = this.SiteID;
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

    public int SiteID
    {
      get
      {
        return this._SiteID;
      }
      set
      {
        this._SiteID = value;
        if (!(this.SiteID > 0 & this.IDToLinkTo == 787))
          return;
        this._Sites.RowFilter = "SiteID=" + Conversions.ToString(this.SiteID);
        this._InvoiceAddresses.RowFilter = "(AddressType ='Customer HQ') OR (AddressType ='Invoice') OR (AddressID=" + Conversions.ToString(this.SiteID) + ")";
      }
    }

    public bool NumberUsed
    {
      get
      {
        return this._NumberUsed;
      }
      set
      {
        this._NumberUsed = value;
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
      dataGridBoolColumn.Width = 50;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Property";
      dataGridLabelColumn1.MappingName = "Site";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 200;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MM/yyyy";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "First Visit Date";
      dataGridLabelColumn2.MappingName = "FirstVisitDate";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "C";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Price Per Visit";
      dataGridLabelColumn3.MappingName = "PricePerVisit";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Visit Frequency";
      dataGridLabelColumn4.MappingName = "VisitFrequency";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Total Property Price";
      dataGridLabelColumn5.MappingName = "TotalSitePrice";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.Alignment = HorizontalAlignment.Center;
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Visit Duration (Mins)";
      dataGridLabelColumn6.MappingName = "VisitDuration";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 120;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Property Price";
      dataGridLabelColumn7.MappingName = "SitePrice";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblContractSite.ToString();
      this.dgSites.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgSites);
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

    private void dgSites_MouseUp(object sender, MouseEventArgs e)
    {
      try
      {
        DataGrid.HitTestInfo hitTestInfo = this.dgSites.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
          this.dgSites.CurrentRowIndex = hitTestInfo.Row;
        if ((uint) hitTestInfo.Column > 0U || this.SelectedSiteDataRow == null)
          return;
        if (!Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgSites[this.dgSites.CurrentRowIndex, 0])))
        {
          this.Save();
          App.ShowForm(typeof (FRMContractOriginalSite), true, new object[4]
          {
            (object) 0,
            this.SelectedSiteDataRow["SiteID"],
            (object) this.CurrentContract,
            (object) this
          }, false);
        }
        else if (App.ShowMessage("You are about to remove this property from the contract.\r\nThis will remove all contract property jobs and visits not yet downloaded by the engineer\r\nDo you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && App.DB.ContractOriginalSite.Delete(Conversions.ToInteger(this.SelectedSiteDataRow["ContractSiteID"])) > 0)
        {
          int num = (int) App.ShowMessage("Could not remove property from contract as there are active visits", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        this.Sites = App.DB.ContractOriginalSite.GetAll_ContractID(this.CurrentContract.ContractID, this.IDToLinkTo);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void dgSites_DoubleClick(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedSiteDataRow == null)
          return;
        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgSites[this.dgSites.CurrentRowIndex, 0])))
        {
          App.ShowForm(typeof (FRMContractOriginalSite), true, new object[4]
          {
            this.SelectedSiteDataRow["ContractSiteID"],
            this.SelectedSiteDataRow["SiteID"],
            (object) this.CurrentContract,
            (object) this
          }, false);
        }
        else
        {
          this.Save();
          App.ShowForm(typeof (FRMContractOriginalSite), true, new object[4]
          {
            (object) 0,
            this.SelectedSiteDataRow["SiteID"],
            (object) this.CurrentContract,
            (object) this
          }, false);
        }
        this.Sites = App.DB.ContractOriginalSite.GetAll_ContractID(this.CurrentContract.ContractID, this.IDToLinkTo);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void txtContractPrice_LostFocus(object sender, EventArgs e)
    {
      this.txtContractPrice.Text = this.txtContractPrice.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtContractPrice.Text.Replace("£", "")) ? Strings.Format((object) Conversions.ToDouble(this.txtContractPrice.Text.Replace("£", "")), "C") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
    }

    private void btnCalculatePrice_Click(object sender, EventArgs e)
    {
      if (this.CurrentContract.ContractID <= 0)
        return;
      this.txtContractPrice.Text = Strings.Format((object) App.DB.ContractOriginal.ContractCalculatedTotal(this.CurrentContract.ContractID), "C");
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

    private void cboContractStatusID_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboContractStatusID)) != 5.0)
        return;
      int num1 = Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboReasonID)) == 0.0 ? 1 : 0;
      DateTime today = this.dtpCancelledDate.Value;
      DateTime date1 = today.Date;
      today = DateAndTime.Today;
      DateTime date2 = today.Date;
      int num2 = DateTime.Compare(date1, date2) > 0 ? 1 : 0;
      if ((num1 | num2) != 0)
      {
        int num3 = (int) Interaction.MsgBox((object) "You can not mark this contract as 'Cancelled' as you have not entered a cancelled reason or the cancelled date is in the future", MsgBoxStyle.OkOnly, (object) null);
        ComboBox contractStatusId = this.cboContractStatusID;
        Combo.SetSelectedComboItem_By_Value(ref contractStatusId, Conversions.ToString(this.CurrentContract.ContractStatusID));
        this.cboContractStatusID = contractStatusId;
      }
    }

    void IUserControl.Populate(int ID = 0)
    {
      if (this.CurrentContract.Exists)
        this.txtContractReference.Text = this.CurrentContract.ContractReference;
      ComboBox cboReasonId = this.cboReasonID;
      Combo.SetSelectedComboItem_By_Value(ref cboReasonId, Conversions.ToString(this.CurrentContract.ReasonID));
      this.cboReasonID = cboReasonId;
      ComboBox combo;
      if (this.CurrentContract.ContractStatusID == 0)
      {
        ComboBox contractStatusId = this.cboContractStatusID;
        Combo.SetSelectedComboItem_By_Value(ref contractStatusId, Conversions.ToString(3));
        this.cboContractStatusID = contractStatusId;
      }
      else
      {
        combo = this.cboContractStatusID;
        Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentContract.ContractStatusID));
        this.cboContractStatusID = combo;
      }
      this.dtpContractStartDate.Value = this.CurrentContract.ContractStartDate;
      this.dtpContractEndDate.Value = this.CurrentContract.ContractEndDate;
      this.txtContractPrice.Text = Strings.Format((object) this.CurrentContract.ContractPrice, "C");
      combo = this.cboInvoiceFrequencyID;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentContract.InvoiceFrequencyID));
      this.cboInvoiceFrequencyID = combo;
      this.dtpFirstInvoiceDate.Value = this.CurrentContract.FirstInvoiceDate;
      combo = this.cboContractType;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentContract.ContractTypeID));
      this.cboContractType = combo;
      this.txtPONumber.Text = this.CurrentContract.PoNumber;
      this.rdoCheque.Checked = this.CurrentContract.Cheque;
      this.rdoCreditCard.Checked = this.CurrentContract.CreditCard;
      this.rdoDirectDebit.Checked = this.CurrentContract.DirectDebit;
      this.txtBankName.Text = this.CurrentContract.BankName;
      this.txtAccountNumber.Text = this.CurrentContract.AccountNumber;
      this.txtSortCode.Text = this.CurrentContract.SortCode;
      this.chkGasSupplyPipework.Checked = this.CurrentContract.GasSupplyPipework;
      this.chkPlumbingDrainage.Checked = this.CurrentContract.PlumbingDrainage;
      this.chkWindowLockPest.Checked = this.CurrentContract.WindowLockPest;
      this.cboDoNotRenew.Checked = this.CurrentContract.DoNotRenew;
      this.txtAdditionalInvoiceNotes.Text = this.CurrentContract.Notes;
      combo = this.cboDiscount;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentContract.DiscountID));
      this.cboDiscount = combo;
      if (this.CurrentContract.ReasonID > 0 & (uint) DateTime.Compare(this.CurrentContract.CancelledDate, DateTime.MinValue) > 0U)
      {
        this.dtpCancelledDate.Value = this.CurrentContract.CancelledDate;
        this.dtpCancelledDate.Visible = true;
        this.lblCancelledDate.Visible = true;
      }
      else
      {
        this.dtpCancelledDate.Visible = false;
        this.lblCancelledDate.Visible = false;
      }
      this.cboReasonID.Visible = true;
      this.lblReason.Visible = true;
      if (this.CurrentContract.ContractStatusID == 5)
        this.cboDoNotRenew.Checked = true;
      this.txtDDMSRef.Text = this.CurrentContract.DDMSRef;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentContract.IgnoreExceptionsOnSetMethods = true;
        this.ChangeStatus();
        this.CurrentContract.SetContractReference = (object) this.txtContractReference.Text.Trim();
        this.CurrentContract.ContractStartDate = this.dtpContractStartDate.Value;
        this.CurrentContract.ContractEndDate = this.dtpContractEndDate.Value;
        this.CurrentContract.SetContractStatusID = (object) Combo.get_GetSelectedItemValue(this.cboContractStatusID);
        this.CurrentContract.SetContractPrice = (object) this.txtContractPrice.Text.Trim().Replace("£", "");
        this.CurrentContract.SetInvoiceFrequencyID = (object) Combo.get_GetSelectedItemValue(this.cboInvoiceFrequencyID);
        this.CurrentContract.FirstInvoiceDate = this.dtpFirstInvoiceDate.Value;
        this.CurrentContract.SetContractTypeID = (object) Combo.get_GetSelectedItemValue(this.cboContractType);
        this.CurrentContract.SetCheque = (object) this.rdoCheque.Checked;
        this.CurrentContract.SetCreditCard = (object) this.rdoCreditCard.Checked;
        this.CurrentContract.SetDirectDebit = (object) this.rdoDirectDebit.Checked;
        this.CurrentContract.SetBankName = (object) this.txtBankName.Text;
        this.CurrentContract.SetAccountNumber = (object) this.txtAccountNumber.Text;
        this.CurrentContract.SetSortCode = (object) this.txtSortCode.Text;
        this.CurrentContract.SetPoNumber = (object) this.txtPONumber.Text;
        this.CurrentContract.SetGasSupplyPipework = (object) this.chkGasSupplyPipework.Checked;
        this.CurrentContract.SetPlumbingDrainage = (object) this.chkPlumbingDrainage.Checked;
        this.CurrentContract.SetWindowLockPest = (object) this.chkWindowLockPest.Checked;
        this.CurrentContract.SetDoNotRenew = (object) this.cboDoNotRenew.Checked;
        this.CurrentContract.SetDDMSRef = (object) this.txtDDMSRef.Text;
        this.CurrentContract.SetNotes = (object) this.txtAdditionalInvoiceNotes.Text;
        this.CurrentContract.SetDiscountID = (object) Combo.get_GetSelectedItemValue(this.cboDiscount);
        if (this.SelectedInvoiceAddressesDataRow != null)
        {
          this.CurrentContract.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressID"]);
          this.CurrentContract.SetInvoiceAddressTypeID = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceAddressesDataRow["AddressTypeID"]);
        }
        if (this.CurrentContract.Exists)
        {
          this.CurrentContract.SetReasonID = (object) Combo.get_GetSelectedItemValue(this.cboReasonID);
          this.CurrentContract.CancelledDate = this.dtpCancelledDate.Value;
          new ContractOriginalValidator().Validate(this.CurrentContract);
          App.DB.ContractOriginal.Update(this.CurrentContract);
          this.NumberUsed = true;
        }
        else
        {
          this.CurrentContract.SetCustomerID = (object) this.IDToLinkTo;
          new ContractOriginalValidator().Validate(this.CurrentContract);
          this.CurrentContract = App.DB.ContractOriginal.Insert(this.CurrentContract);
          this.NumberUsed = true;
          this.InsertInvoiceToBeRaiseLines();
        }
        if (this.InvoiceToBeRaised.Exists)
        {
          this.InvoiceToBeRaised.SetPaymentTermID = (object) Combo.get_GetSelectedItemValue(this.cboInvType);
          this.InvoiceToBeRaised.SetPaidByID = (object) Combo.get_GetSelectedItemValue(this.cboPaidBy);
          App.DB.InvoiceToBeRaised.Update(this.InvoiceToBeRaised);
        }
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentContract.ContractID);
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

    public void ChangeStatus()
    {
      if (this.CurrentContract == null || !this.CurrentContract.Exists)
        return;
      IEnumerator enumerator1;
      if ((double) this.CurrentContract.ContractStatusID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboContractStatusID)) & Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractStatusID)) == 4)
      {
        MsgBoxResult msgBoxResult = new MsgBoxResult();
        switch ((MsgBoxResult) App.ShowMessage("You are setting this contract to inactive\r\nDo you want to remove any contract job/visits scheduled but not downloaded?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
        {
          case MsgBoxResult.Cancel:
            ComboBox contractStatusId = this.cboContractStatusID;
            Combo.SetSelectedComboItem_By_Value(ref contractStatusId, Conversions.ToString(3));
            this.cboContractStatusID = contractStatusId;
            break;
          case MsgBoxResult.Yes:
            IEnumerator enumerator2;
            try
            {
              enumerator2 = this.Sites.Table.Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current = (DataRow) enumerator2.Current;
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["ContractSiteID"], (object) 0, false))
                  App.DB.ContractOriginalSite.ActiveInactive(Conversions.ToInteger(current["ContractSiteID"]), true);
              }
              break;
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
        }
      }
      else if ((double) this.CurrentContract.ContractStatusID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboContractStatusID)) & Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractStatusID)) == 3)
      {
        try
        {
          enumerator1 = this.Sites.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["ContractSiteID"], (object) 0, false))
              App.DB.ContractOriginalSite.ActiveInactive(Conversions.ToInteger(current["ContractSiteID"]), false);
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
      }
    }

    private void InsertInvoiceToBeRaiseLines()
    {
      DateTime date1 = Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00");
      DateTime date2 = Conversions.ToDate(Strings.Format((object) this.CurrentContract.ContractEndDate.AddDays(1.0), "dd/MM/yyyy") + " 00:00:00");
      int num1 = checked (Math.Abs(date1.Year - date2.Year) * 12 + Math.Abs(date1.Month - date2.Month));
      int days = date2.Subtract(date1).Days;
      int num2 = 0;
      switch (this.CurrentContract.InvoiceFrequencyID)
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
      DateTime dateTime = this.CurrentContract.FirstInvoiceDate;
      int num3 = num2;
      int num4 = 1;
      while (num4 <= num3)
      {
        App.DB.InvoiceToBeRaised.Insert(new InvoiceToBeRaised()
        {
          SetAddressLinkID = (object) this.CurrentContract.InvoiceAddressID,
          SetAddressTypeID = (object) this.CurrentContract.InvoiceAddressTypeID,
          SetInvoiceTypeID = (object) 327,
          SetLinkID = (object) this.CurrentContract.ContractID,
          RaiseDate = dateTime
        });
        switch (this.CurrentContract.InvoiceFrequencyID)
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

    private void cboContractType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboContractType)) <= 0.0 || this.CurrentContract.Exists)
        return;
      if (this.Number != null)
        App.DB.Job.DeleteReservedOrderNumber(this.Number.JobNumber, this.Number.Prefix);
      this.Number = App.DB.Job.GetNextJobNumber((Enums.JobDefinition) Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboContractType)));
      int jobNumber = this.Number.JobNumber;
      if (jobNumber.ToString().Length < 3)
      {
        this.txtContractReference.Text = this.Number.Prefix + "00" + Conversions.ToString(this.Number.JobNumber);
      }
      else
      {
        jobNumber = this.Number.JobNumber;
        this.txtContractReference.Text = jobNumber.ToString().Length >= 4 ? this.Number.Prefix + Conversions.ToString(this.Number.JobNumber) : this.Number.Prefix + "0" + Conversions.ToString(this.Number.JobNumber);
      }
      this.txtContractReference.Text = this.Number.Prefix + Conversions.ToString(this.Number.JobNumber);
    }

    public void CloseForm()
    {
      if (this.Number != null & !this.NumberUsed)
        App.DB.Job.DeleteReservedOrderNumber(this.Number.JobNumber, this.Number.Prefix);
      this.Dispose();
    }

    private void cboReasonID_SelectedIndexChanged_1(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboReasonID)) > 0.0)
      {
        if ((uint) DateTime.Compare(this.CurrentContract.CancelledDate, DateTime.MinValue) <= 0U)
          return;
        this.dtpCancelledDate.Value = this.CurrentContract.CancelledDate;
        this.dtpCancelledDate.Visible = true;
        this.lblCancelledDate.Visible = true;
      }
      else
      {
        this.dtpCancelledDate.Visible = false;
        this.lblCancelledDate.Visible = false;
      }
    }

    private void dgSites_Navigate(object sender, NavigateEventArgs ne)
    {
    }

    private void cboInvType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboInvType)) == 69491.0)
      {
        this.lblPaidBy.Visible = true;
        this.cboPaidBy.Visible = true;
      }
      else
      {
        this.lblPaidBy.Visible = false;
        this.cboPaidBy.Visible = false;
      }
    }

    private void filterChange(object sender, EventArgs e)
    {
      this.InvoiceAddresses.RowFilter = "Address1 LIKE '%" + Helper.RemoveSpecialCharacters(this.txtSearchFilter.Text) + "%' OR Postcode LIKE '%" + Helper.RemoveSpecialCharacters(this.txtSearchFilter.Text) + "%'";
    }
  }
}
