// Decompiled with JetBrains decompiler
// Type: FSM.UCGenerateQuote
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Contacts;
using FSM.Entity.InvoiceAddresss;
using FSM.Entity.Parts;
using FSM.Entity.PartSuppliers;
using FSM.Entity.Products;
using FSM.Entity.ProductSuppliers;
using FSM.Entity.QuoteOrderParts;
using FSM.Entity.QuoteOrderProducts;
using FSM.Entity.QuoteOrders;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using FSM.Entity.Warehouses;
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
  public class UCGenerateQuote : UCBase, IUserControl
  {
    private IContainer components;
    private DataView m_dTable2;
    private DataView m_dTable;
    private DataView _PriceRequestDataView;
    private DataView _ConfirmedPriceRequestDataView;
    private bool Loading;
    private QuoteOrder oQuoteOrder;
    private FSM.Entity.Customers.Customer _oCustomer;
    private FSM.Entity.Sites.Site _oSite;
    private Warehouse _oWarehouse;
    private InvoiceAddress _invoiceAddress;
    private Contact _contact;

    public UCGenerateQuote()
    {
      this.Load += new EventHandler(this.UCGenerateQuote_Load);
      this.m_dTable2 = (DataView) null;
      this.m_dTable = (DataView) null;
      this._PriceRequestDataView = (DataView) null;
      this._ConfirmedPriceRequestDataView = (DataView) null;
      this.InitializeComponent();
      ComboBox cboUsers = this.cboUsers;
      Combo.SetUpCombo(ref cboUsers, App.DB.User.GetAll().Table, "UserID", "FullName", Enums.ComboValues.Please_Select);
      this.cboUsers = cboUsers;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl tcQuote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabItems { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgProducts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveProducts
    {
      get
      {
        return this._btnRemoveProducts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveProducts_Click);
        Button btnRemoveProducts1 = this._btnRemoveProducts;
        if (btnRemoveProducts1 != null)
          btnRemoveProducts1.Click -= eventHandler;
        this._btnRemoveProducts = value;
        Button btnRemoveProducts2 = this._btnRemoveProducts;
        if (btnRemoveProducts2 == null)
          return;
        btnRemoveProducts2.Click += eventHandler;
      }
    }

    internal virtual Button btnFindProduct
    {
      get
      {
        return this._btnFindProduct;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindProduct_Click);
        Button btnFindProduct1 = this._btnFindProduct;
        if (btnFindProduct1 != null)
          btnFindProduct1.Click -= eventHandler;
        this._btnFindProduct = value;
        Button btnFindProduct2 = this._btnFindProduct;
        if (btnFindProduct2 == null)
          return;
        btnFindProduct2.Click += eventHandler;
      }
    }

    internal virtual Button btnFindPart
    {
      get
      {
        return this._btnFindPart;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindPart_Click);
        Button btnFindPart1 = this._btnFindPart;
        if (btnFindPart1 != null)
          btnFindPart1.Click -= eventHandler;
        this._btnFindPart = value;
        Button btnFindPart2 = this._btnFindPart;
        if (btnFindPart2 == null)
          return;
        btnFindPart2.Click += eventHandler;
      }
    }

    internal virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnRemoveParts
    {
      get
      {
        return this._btnRemoveParts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveParts_Click);
        Button btnRemoveParts1 = this._btnRemoveParts;
        if (btnRemoveParts1 != null)
          btnRemoveParts1.Click -= eventHandler;
        this._btnRemoveParts = value;
        Button btnRemoveParts2 = this._btnRemoveParts;
        if (btnRemoveParts2 == null)
          return;
        btnRemoveParts2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtAvailability { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPriceExcludeDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPriceDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpValidUntil { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpEnquiryDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUsers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkDeadlineNA
    {
      get
      {
        return this._chkDeadlineNA;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkDeadlineNA_CheckedChanged);
        CheckBox chkDeadlineNa1 = this._chkDeadlineNA;
        if (chkDeadlineNa1 != null)
          chkDeadlineNa1.CheckedChanged -= eventHandler;
        this._chkDeadlineNA = value;
        CheckBox chkDeadlineNa2 = this._chkDeadlineNA;
        if (chkDeadlineNa2 == null)
          return;
        chkDeadlineNa2.CheckedChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpDeliveryDeadline { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindContact
    {
      get
      {
        return this._btnFindContact;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindContact_Click);
        Button btnFindContact1 = this._btnFindContact;
        if (btnFindContact1 != null)
          btnFindContact1.Click -= eventHandler;
        this._btnFindContact = value;
        Button btnFindContact2 = this._btnFindContact;
        if (btnFindContact2 == null)
          return;
        btnFindContact2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtContact { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindInvoiceAddress
    {
      get
      {
        return this._btnFindInvoiceAddress;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindInvoiceAddress_Click);
        Button findInvoiceAddress1 = this._btnFindInvoiceAddress;
        if (findInvoiceAddress1 != null)
          findInvoiceAddress1.Click -= eventHandler;
        this._btnFindInvoiceAddress = value;
        Button findInvoiceAddress2 = this._btnFindInvoiceAddress;
        if (findInvoiceAddress2 == null)
          return;
        findInvoiceAddress2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSpecialInstructions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindSite
    {
      get
      {
        return this._btnFindSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSite_Click);
        Button btnFindSite1 = this._btnFindSite;
        if (btnFindSite1 != null)
          btnFindSite1.Click -= eventHandler;
        this._btnFindSite = value;
        Button btnFindSite2 = this._btnFindSite;
        if (btnFindSite2 == null)
          return;
        btnFindSite2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindCustomer
    {
      get
      {
        return this._btnFindCustomer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindCustomer_Click);
        Button btnFindCustomer1 = this._btnFindCustomer;
        if (btnFindCustomer1 != null)
          btnFindCustomer1.Click -= eventHandler;
        this._btnFindCustomer = value;
        Button btnFindCustomer2 = this._btnFindCustomer;
        if (btnFindCustomer2 == null)
          return;
        btnFindCustomer2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStatus
    {
      get
      {
        return this._cboStatus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboStatus_SelectedIndexChanged);
        ComboBox cboStatus1 = this._cboStatus;
        if (cboStatus1 != null)
          cboStatus1.SelectedIndexChanged -= eventHandler;
        this._cboStatus = value;
        ComboBox cboStatus2 = this._cboStatus;
        if (cboStatus2 == null)
          return;
        cboStatus2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabRequests { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSearch
    {
      get
      {
        return this._btnSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSearch_Click);
        Button btnSearch1 = this._btnSearch;
        if (btnSearch1 != null)
          btnSearch1.Click -= eventHandler;
        this._btnSearch = value;
        Button btnSearch2 = this._btnSearch;
        if (btnSearch2 == null)
          return;
        btnSearch2.Click += eventHandler;
      }
    }

    internal virtual Label lblSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPriceRequests
    {
      get
      {
        return this._dgPriceRequests;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgPriceRequests_DoubleClick);
        DataGrid dgPriceRequests1 = this._dgPriceRequests;
        if (dgPriceRequests1 != null)
          dgPriceRequests1.DoubleClick -= eventHandler;
        this._dgPriceRequests = value;
        DataGrid dgPriceRequests2 = this._dgPriceRequests;
        if (dgPriceRequests2 == null)
          return;
        dgPriceRequests2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnUpdate
    {
      get
      {
        return this._btnUpdate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdate_Click);
        Button btnUpdate1 = this._btnUpdate;
        if (btnUpdate1 != null)
          btnUpdate1.Click -= eventHandler;
        this._btnUpdate = value;
        Button btnUpdate2 = this._btnUpdate;
        if (btnUpdate2 == null)
          return;
        btnUpdate2.Click += eventHandler;
      }
    }

    internal virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgConfirmedPriceRequests { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblWarehouse { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtWarehouse { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindWarehouse
    {
      get
      {
        return this._btnFindWarehouse;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindWarehouse_Click);
        Button btnFindWarehouse1 = this._btnFindWarehouse;
        if (btnFindWarehouse1 != null)
          btnFindWarehouse1.Click -= eventHandler;
        this._btnFindWarehouse = value;
        Button btnFindWarehouse2 = this._btnFindWarehouse;
        if (btnFindWarehouse2 == null)
          return;
        btnFindWarehouse2.Click += eventHandler;
      }
    }

    internal virtual Label lblSpecial { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.tcQuote = new TabControl();
      this.tabDetails = new TabPage();
      this.btnFindWarehouse = new Button();
      this.txtWarehouse = new TextBox();
      this.lblWarehouse = new Label();
      this.Label3 = new Label();
      this.cboStatus = new ComboBox();
      this.Label16 = new Label();
      this.txtAvailability = new TextBox();
      this.Label15 = new Label();
      this.txtPriceExcludeDetails = new TextBox();
      this.Label14 = new Label();
      this.txtPriceDetails = new TextBox();
      this.Label13 = new Label();
      this.dtpValidUntil = new DateTimePicker();
      this.Label12 = new Label();
      this.dtpEnquiryDate = new DateTimePicker();
      this.Label11 = new Label();
      this.txtCustRef = new TextBox();
      this.Label10 = new Label();
      this.cboUsers = new ComboBox();
      this.Label9 = new Label();
      this.chkDeadlineNA = new CheckBox();
      this.dtpDeliveryDeadline = new DateTimePicker();
      this.Label8 = new Label();
      this.btnFindContact = new Button();
      this.txtContact = new TextBox();
      this.Label7 = new Label();
      this.btnFindInvoiceAddress = new Button();
      this.txtInvoiceAddress = new TextBox();
      this.Label6 = new Label();
      this.lblSpecial = new Label();
      this.txtSpecialInstructions = new TextBox();
      this.btnFindSite = new Button();
      this.txtSite = new TextBox();
      this.Label1 = new Label();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.tabRequests = new TabPage();
      this.GroupBox4 = new GroupBox();
      this.dgConfirmedPriceRequests = new DataGrid();
      this.GroupBox1 = new GroupBox();
      this.dgPriceRequests = new DataGrid();
      this.btnUpdate = new Button();
      this.lblSearch = new Label();
      this.btnSearch = new Button();
      this.tabItems = new TabPage();
      this.GroupBox3 = new GroupBox();
      this.dgParts = new DataGrid();
      this.btnRemoveParts = new Button();
      this.btnFindPart = new Button();
      this.GroupBox2 = new GroupBox();
      this.dgProducts = new DataGrid();
      this.btnRemoveProducts = new Button();
      this.btnFindProduct = new Button();
      this.tcQuote.SuspendLayout();
      this.tabDetails.SuspendLayout();
      this.tabRequests.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      this.dgConfirmedPriceRequests.BeginInit();
      this.GroupBox1.SuspendLayout();
      this.dgPriceRequests.BeginInit();
      this.tabItems.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.dgParts.BeginInit();
      this.GroupBox2.SuspendLayout();
      this.dgProducts.BeginInit();
      this.SuspendLayout();
      this.tcQuote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcQuote.Controls.Add((Control) this.tabDetails);
      this.tcQuote.Controls.Add((Control) this.tabRequests);
      this.tcQuote.Controls.Add((Control) this.tabItems);
      this.tcQuote.Location = new System.Drawing.Point(8, 8);
      this.tcQuote.Name = "tcQuote";
      this.tcQuote.SelectedIndex = 0;
      this.tcQuote.Size = new Size(552, 496);
      this.tcQuote.TabIndex = 0;
      this.tabDetails.Controls.Add((Control) this.btnFindWarehouse);
      this.tabDetails.Controls.Add((Control) this.txtWarehouse);
      this.tabDetails.Controls.Add((Control) this.lblWarehouse);
      this.tabDetails.Controls.Add((Control) this.Label3);
      this.tabDetails.Controls.Add((Control) this.cboStatus);
      this.tabDetails.Controls.Add((Control) this.Label16);
      this.tabDetails.Controls.Add((Control) this.txtAvailability);
      this.tabDetails.Controls.Add((Control) this.Label15);
      this.tabDetails.Controls.Add((Control) this.txtPriceExcludeDetails);
      this.tabDetails.Controls.Add((Control) this.Label14);
      this.tabDetails.Controls.Add((Control) this.txtPriceDetails);
      this.tabDetails.Controls.Add((Control) this.Label13);
      this.tabDetails.Controls.Add((Control) this.dtpValidUntil);
      this.tabDetails.Controls.Add((Control) this.Label12);
      this.tabDetails.Controls.Add((Control) this.dtpEnquiryDate);
      this.tabDetails.Controls.Add((Control) this.Label11);
      this.tabDetails.Controls.Add((Control) this.txtCustRef);
      this.tabDetails.Controls.Add((Control) this.Label10);
      this.tabDetails.Controls.Add((Control) this.cboUsers);
      this.tabDetails.Controls.Add((Control) this.Label9);
      this.tabDetails.Controls.Add((Control) this.chkDeadlineNA);
      this.tabDetails.Controls.Add((Control) this.dtpDeliveryDeadline);
      this.tabDetails.Controls.Add((Control) this.Label8);
      this.tabDetails.Controls.Add((Control) this.btnFindContact);
      this.tabDetails.Controls.Add((Control) this.txtContact);
      this.tabDetails.Controls.Add((Control) this.Label7);
      this.tabDetails.Controls.Add((Control) this.btnFindInvoiceAddress);
      this.tabDetails.Controls.Add((Control) this.txtInvoiceAddress);
      this.tabDetails.Controls.Add((Control) this.Label6);
      this.tabDetails.Controls.Add((Control) this.lblSpecial);
      this.tabDetails.Controls.Add((Control) this.txtSpecialInstructions);
      this.tabDetails.Controls.Add((Control) this.btnFindSite);
      this.tabDetails.Controls.Add((Control) this.txtSite);
      this.tabDetails.Controls.Add((Control) this.Label1);
      this.tabDetails.Controls.Add((Control) this.btnFindCustomer);
      this.tabDetails.Controls.Add((Control) this.txtCustomer);
      this.tabDetails.Location = new System.Drawing.Point(4, 22);
      this.tabDetails.Name = "tabDetails";
      this.tabDetails.Size = new Size(544, 470);
      this.tabDetails.TabIndex = 0;
      this.tabDetails.Text = "Quote Details";
      this.btnFindWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindWarehouse.BackColor = Color.White;
      this.btnFindWarehouse.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindWarehouse.Location = new System.Drawing.Point(504, 56);
      this.btnFindWarehouse.Name = "btnFindWarehouse";
      this.btnFindWarehouse.Size = new Size(32, 23);
      this.btnFindWarehouse.TabIndex = 117;
      this.btnFindWarehouse.Text = "...";
      this.txtWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtWarehouse.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtWarehouse.Location = new System.Drawing.Point(144, 56);
      this.txtWarehouse.Name = "txtWarehouse";
      this.txtWarehouse.ReadOnly = true;
      this.txtWarehouse.Size = new Size(352, 21);
      this.txtWarehouse.TabIndex = 116;
      this.txtWarehouse.Text = "";
      this.lblWarehouse.Location = new System.Drawing.Point(8, 56);
      this.lblWarehouse.Name = "lblWarehouse";
      this.lblWarehouse.TabIndex = 115;
      this.lblWarehouse.Text = "Warehouse";
      this.Label3.Location = new System.Drawing.Point(8, 8);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(80, 23);
      this.Label3.TabIndex = 114;
      this.Label3.Text = "Customer";
      this.cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboStatus.Location = new System.Drawing.Point(144, 248);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(392, 21);
      this.cboStatus.TabIndex = 16;
      this.Label16.Location = new System.Drawing.Point(8, 248);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(64, 23);
      this.Label16.TabIndex = 113;
      this.Label16.Text = "Status:";
      this.txtAvailability.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAvailability.Location = new System.Drawing.Point(144, 356);
      this.txtAvailability.Multiline = true;
      this.txtAvailability.Name = "txtAvailability";
      this.txtAvailability.ScrollBars = ScrollBars.Vertical;
      this.txtAvailability.Size = new Size(392, 40);
      this.txtAvailability.TabIndex = 19;
      this.txtAvailability.Text = "";
      this.Label15.Location = new System.Drawing.Point(8, 356);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(120, 24);
      this.Label15.TabIndex = 111;
      this.Label15.Text = "Availability:";
      this.txtPriceExcludeDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPriceExcludeDetails.Location = new System.Drawing.Point(144, 314);
      this.txtPriceExcludeDetails.Multiline = true;
      this.txtPriceExcludeDetails.Name = "txtPriceExcludeDetails";
      this.txtPriceExcludeDetails.ScrollBars = ScrollBars.Vertical;
      this.txtPriceExcludeDetails.Size = new Size(392, 40);
      this.txtPriceExcludeDetails.TabIndex = 18;
      this.txtPriceExcludeDetails.Text = "";
      this.Label14.Location = new System.Drawing.Point(8, 314);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(120, 40);
      this.Label14.TabIndex = 109;
      this.Label14.Text = "Prices Quoted Exclude:";
      this.txtPriceDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPriceDetails.Location = new System.Drawing.Point(144, 272);
      this.txtPriceDetails.Multiline = true;
      this.txtPriceDetails.Name = "txtPriceDetails";
      this.txtPriceDetails.ScrollBars = ScrollBars.Vertical;
      this.txtPriceDetails.Size = new Size(392, 40);
      this.txtPriceDetails.TabIndex = 17;
      this.txtPriceDetails.Text = "";
      this.Label13.Location = new System.Drawing.Point(8, 272);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(120, 23);
      this.Label13.TabIndex = 107;
      this.Label13.Text = "Prices Quoted Are:";
      this.dtpValidUntil.Location = new System.Drawing.Point(144, 200);
      this.dtpValidUntil.Name = "dtpValidUntil";
      this.dtpValidUntil.Size = new Size(216, 21);
      this.dtpValidUntil.TabIndex = 13;
      this.dtpValidUntil.Tag = (object) "Order.DatePlaced";
      this.Label12.Location = new System.Drawing.Point(8, 200);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(114, 23);
      this.Label12.TabIndex = 105;
      this.Label12.Text = "Valid Until";
      this.dtpEnquiryDate.Location = new System.Drawing.Point(144, 176);
      this.dtpEnquiryDate.Name = "dtpEnquiryDate";
      this.dtpEnquiryDate.Size = new Size(216, 21);
      this.dtpEnquiryDate.TabIndex = 12;
      this.dtpEnquiryDate.Tag = (object) "Order.DatePlaced";
      this.Label11.Location = new System.Drawing.Point(8, 176);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(114, 23);
      this.Label11.TabIndex = 103;
      this.Label11.Text = "Enquiry Date";
      this.txtCustRef.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustRef.Location = new System.Drawing.Point(144, 152);
      this.txtCustRef.Name = "txtCustRef";
      this.txtCustRef.Size = new Size(392, 21);
      this.txtCustRef.TabIndex = 11;
      this.txtCustRef.Text = "";
      this.Label10.Location = new System.Drawing.Point(8, 152);
      this.Label10.Name = "Label10";
      this.Label10.TabIndex = 101;
      this.Label10.Text = "Customer Ref";
      this.cboUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboUsers.Location = new System.Drawing.Point(144, 128);
      this.cboUsers.Name = "cboUsers";
      this.cboUsers.Size = new Size(392, 21);
      this.cboUsers.TabIndex = 10;
      this.Label9.Location = new System.Drawing.Point(8, 128);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(128, 24);
      this.Label9.TabIndex = 99;
      this.Label9.Text = "Product Co-ordinator";
      this.chkDeadlineNA.Location = new System.Drawing.Point(144, 224);
      this.chkDeadlineNA.Name = "chkDeadlineNA";
      this.chkDeadlineNA.Size = new Size(48, 24);
      this.chkDeadlineNA.TabIndex = 14;
      this.chkDeadlineNA.Text = "N/A";
      this.dtpDeliveryDeadline.Location = new System.Drawing.Point(192, 224);
      this.dtpDeliveryDeadline.Name = "dtpDeliveryDeadline";
      this.dtpDeliveryDeadline.Size = new Size(168, 21);
      this.dtpDeliveryDeadline.TabIndex = 15;
      this.dtpDeliveryDeadline.Tag = (object) "Order.DatePlaced";
      this.Label8.Location = new System.Drawing.Point(8, 224);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(104, 23);
      this.Label8.TabIndex = 96;
      this.Label8.Text = "Delivery Deadline";
      this.btnFindContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindContact.BackColor = Color.White;
      this.btnFindContact.Enabled = false;
      this.btnFindContact.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindContact.Location = new System.Drawing.Point(504, 104);
      this.btnFindContact.Name = "btnFindContact";
      this.btnFindContact.Size = new Size(32, 24);
      this.btnFindContact.TabIndex = 9;
      this.btnFindContact.Text = "...";
      this.txtContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtContact.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtContact.Location = new System.Drawing.Point(144, 104);
      this.txtContact.Name = "txtContact";
      this.txtContact.ReadOnly = true;
      this.txtContact.Size = new Size(352, 21);
      this.txtContact.TabIndex = 8;
      this.txtContact.Text = "";
      this.Label7.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label7.Location = new System.Drawing.Point(8, 104);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(64, 24);
      this.Label7.TabIndex = 93;
      this.Label7.Text = "Contact";
      this.btnFindInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindInvoiceAddress.BackColor = Color.White;
      this.btnFindInvoiceAddress.Enabled = false;
      this.btnFindInvoiceAddress.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindInvoiceAddress.Location = new System.Drawing.Point(504, 80);
      this.btnFindInvoiceAddress.Name = "btnFindInvoiceAddress";
      this.btnFindInvoiceAddress.Size = new Size(32, 24);
      this.btnFindInvoiceAddress.TabIndex = 7;
      this.btnFindInvoiceAddress.Text = "...";
      this.txtInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtInvoiceAddress.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInvoiceAddress.Location = new System.Drawing.Point(144, 80);
      this.txtInvoiceAddress.Name = "txtInvoiceAddress";
      this.txtInvoiceAddress.ReadOnly = true;
      this.txtInvoiceAddress.Size = new Size(352, 21);
      this.txtInvoiceAddress.TabIndex = 6;
      this.txtInvoiceAddress.Text = "";
      this.Label6.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label6.Location = new System.Drawing.Point(8, 80);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(104, 24);
      this.Label6.TabIndex = 90;
      this.Label6.Text = "Invoice Address";
      this.lblSpecial.Location = new System.Drawing.Point(8, 398);
      this.lblSpecial.Name = "lblSpecial";
      this.lblSpecial.Size = new Size(80, 40);
      this.lblSpecial.TabIndex = 87;
      this.lblSpecial.Text = "Special Instructions";
      this.txtSpecialInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSpecialInstructions.Location = new System.Drawing.Point(144, 398);
      this.txtSpecialInstructions.Multiline = true;
      this.txtSpecialInstructions.Name = "txtSpecialInstructions";
      this.txtSpecialInstructions.ScrollBars = ScrollBars.Vertical;
      this.txtSpecialInstructions.Size = new Size(392, 66);
      this.txtSpecialInstructions.TabIndex = 20;
      this.txtSpecialInstructions.Text = "";
      this.btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSite.BackColor = Color.White;
      this.btnFindSite.Enabled = false;
      this.btnFindSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSite.Location = new System.Drawing.Point(504, 32);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(32, 23);
      this.btnFindSite.TabIndex = 4;
      this.btnFindSite.Text = "...";
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSite.Location = new System.Drawing.Point(144, 32);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(352, 21);
      this.txtSite.TabIndex = 3;
      this.txtSite.Text = "";
      this.Label1.Location = new System.Drawing.Point(8, 32);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(80, 23);
      this.Label1.TabIndex = 83;
      this.Label1.Text = "Property";
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(504, 8);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 2;
      this.btnFindCustomer.Text = "...";
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(144, 8);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(352, 21);
      this.txtCustomer.TabIndex = 1;
      this.txtCustomer.Text = "";
      this.tabRequests.Controls.Add((Control) this.GroupBox4);
      this.tabRequests.Controls.Add((Control) this.GroupBox1);
      this.tabRequests.Controls.Add((Control) this.lblSearch);
      this.tabRequests.Controls.Add((Control) this.btnSearch);
      this.tabRequests.Location = new System.Drawing.Point(4, 22);
      this.tabRequests.Name = "tabRequests";
      this.tabRequests.Size = new Size(544, 470);
      this.tabRequests.TabIndex = 2;
      this.tabRequests.Text = "Price Requests";
      this.GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox4.Controls.Add((Control) this.dgConfirmedPriceRequests);
      this.GroupBox4.Location = new System.Drawing.Point(8, 264);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(528, 192);
      this.GroupBox4.TabIndex = 7;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Confirmed Price Requests";
      this.dgConfirmedPriceRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgConfirmedPriceRequests.DataMember = "";
      this.dgConfirmedPriceRequests.HeaderForeColor = SystemColors.ControlText;
      this.dgConfirmedPriceRequests.Location = new System.Drawing.Point(8, 27);
      this.dgConfirmedPriceRequests.Name = "dgConfirmedPriceRequests";
      this.dgConfirmedPriceRequests.Size = new Size(512, 157);
      this.dgConfirmedPriceRequests.TabIndex = 2;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dgPriceRequests);
      this.GroupBox1.Controls.Add((Control) this.btnUpdate);
      this.GroupBox1.Location = new System.Drawing.Point(8, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(528, 216);
      this.GroupBox1.TabIndex = 6;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Unconfirmed Price Requests";
      this.dgPriceRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPriceRequests.DataMember = "";
      this.dgPriceRequests.HeaderForeColor = SystemColors.ControlText;
      this.dgPriceRequests.Location = new System.Drawing.Point(8, 31);
      this.dgPriceRequests.Name = "dgPriceRequests";
      this.dgPriceRequests.Size = new Size(512, 145);
      this.dgPriceRequests.TabIndex = 1;
      this.btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnUpdate.Location = new System.Drawing.Point(8, 184);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.Size = new Size(152, 24);
      this.btnUpdate.TabIndex = 7;
      this.btnUpdate.Text = "Confirm Price Request";
      this.lblSearch.Location = new System.Drawing.Point(136, 8);
      this.lblSearch.Name = "lblSearch";
      this.lblSearch.Size = new Size(336, 23);
      this.lblSearch.TabIndex = 5;
      this.lblSearch.Text = "Please Save Quote To Allow Search For Price Request";
      this.btnSearch.Location = new System.Drawing.Point(8, 8);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(120, 23);
      this.btnSearch.TabIndex = 4;
      this.btnSearch.Text = "Search For Items";
      this.tabItems.Controls.Add((Control) this.GroupBox3);
      this.tabItems.Controls.Add((Control) this.GroupBox2);
      this.tabItems.Location = new System.Drawing.Point(4, 22);
      this.tabItems.Name = "tabItems";
      this.tabItems.Size = new Size(544, 470);
      this.tabItems.TabIndex = 1;
      this.tabItems.Text = "Products / Parts";
      this.GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox3.Controls.Add((Control) this.dgParts);
      this.GroupBox3.Controls.Add((Control) this.btnRemoveParts);
      this.GroupBox3.Controls.Add((Control) this.btnFindPart);
      this.GroupBox3.Location = new System.Drawing.Point(8, 216);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(528, 248);
      this.GroupBox3.TabIndex = 57;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Parts - Quantity and Price can be edited by clicking the appropriate cell";
      this.dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgParts.DataMember = "";
      this.dgParts.HeaderForeColor = SystemColors.ControlText;
      this.dgParts.Location = new System.Drawing.Point(8, 41);
      this.dgParts.Name = "dgParts";
      this.dgParts.Size = new Size(512, 167);
      this.dgParts.TabIndex = 4;
      this.btnRemoveParts.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemoveParts.Location = new System.Drawing.Point(456, 218);
      this.btnRemoveParts.Name = "btnRemoveParts";
      this.btnRemoveParts.Size = new Size(64, 23);
      this.btnRemoveParts.TabIndex = 6;
      this.btnRemoveParts.Text = "Remove";
      this.btnFindPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnFindPart.BackColor = SystemColors.Control;
      this.btnFindPart.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindPart.Location = new System.Drawing.Point(8, 216);
      this.btnFindPart.Name = "btnFindPart";
      this.btnFindPart.Size = new Size(128, 23);
      this.btnFindPart.TabIndex = 5;
      this.btnFindPart.Text = "Search For Part";
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.dgProducts);
      this.GroupBox2.Controls.Add((Control) this.btnRemoveProducts);
      this.GroupBox2.Controls.Add((Control) this.btnFindProduct);
      this.GroupBox2.Location = new System.Drawing.Point(8, 8);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(528, 200);
      this.GroupBox2.TabIndex = 52;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Products - Quantity and Price can be edited by clicking the appropriate cell";
      this.dgProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgProducts.DataMember = "";
      this.dgProducts.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dgProducts.HeaderForeColor = SystemColors.ControlText;
      this.dgProducts.Location = new System.Drawing.Point(8, 35);
      this.dgProducts.Name = "dgProducts";
      this.dgProducts.Size = new Size(512, 126);
      this.dgProducts.TabIndex = 1;
      this.btnRemoveProducts.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnRemoveProducts.Location = new System.Drawing.Point(456, 169);
      this.btnRemoveProducts.Name = "btnRemoveProducts";
      this.btnRemoveProducts.Size = new Size(64, 23);
      this.btnRemoveProducts.TabIndex = 3;
      this.btnRemoveProducts.Text = "Remove";
      this.btnFindProduct.BackColor = SystemColors.Control;
      this.btnFindProduct.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindProduct.Location = new System.Drawing.Point(8, 168);
      this.btnFindProduct.Name = "btnFindProduct";
      this.btnFindProduct.Size = new Size(128, 23);
      this.btnFindProduct.TabIndex = 2;
      this.btnFindProduct.Text = "Search For Product";
      this.Controls.Add((Control) this.tcQuote);
      this.Name = nameof (UCGenerateQuote);
      this.Size = new Size(568, 512);
      this.tcQuote.ResumeLayout(false);
      this.tabDetails.ResumeLayout(false);
      this.tabRequests.ResumeLayout(false);
      this.GroupBox4.ResumeLayout(false);
      this.dgConfirmedPriceRequests.EndInit();
      this.GroupBox1.ResumeLayout(false);
      this.dgPriceRequests.EndInit();
      this.tabItems.ResumeLayout(false);
      this.GroupBox3.ResumeLayout(false);
      this.dgParts.EndInit();
      this.GroupBox2.ResumeLayout(false);
      this.dgProducts.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupPartsDataGrid();
      this.SetupProductsDataGrid();
      this.SetupPriceRequestDatagrid();
      this.SetupConfirmedPriceRequestDatagrid();
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, App.DB.Picklists.GetAll(Enums.PickListTypes.Quote_Status, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboStatus = cboStatus;
    }

    public object LoadedItem
    {
      get
      {
        object obj;
        return obj;
      }
    }

    public DataView PartsDataView
    {
      get
      {
        return this.m_dTable2;
      }
      set
      {
        this.m_dTable2 = value;
        this.m_dTable2.Table.TableName = Enums.TableNames.tblPart.ToString();
        this.m_dTable2.AllowNew = false;
        this.m_dTable2.AllowEdit = false;
        this.m_dTable2.AllowDelete = false;
        this.dgParts.DataSource = (object) this.PartsDataView;
      }
    }

    private DataRow SelectedPartDataRow
    {
      get
      {
        return this.dgParts.CurrentRowIndex != -1 ? this.PartsDataView[this.dgParts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView ProductsDataView
    {
      get
      {
        return this.m_dTable;
      }
      set
      {
        this.m_dTable = value;
        this.m_dTable.Table.TableName = Enums.TableNames.tblProduct.ToString();
        this.m_dTable.AllowNew = false;
        this.m_dTable.AllowEdit = false;
        this.m_dTable.AllowDelete = false;
        this.dgProducts.DataSource = (object) this.ProductsDataView;
      }
    }

    private DataRow SelectedProductDataRow
    {
      get
      {
        return this.dgProducts.CurrentRowIndex != -1 ? this.ProductsDataView[this.dgProducts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView PriceRequestDataView
    {
      get
      {
        return this._PriceRequestDataView;
      }
      set
      {
        this._PriceRequestDataView = value;
        this._PriceRequestDataView.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
        this._PriceRequestDataView.AllowNew = false;
        this._PriceRequestDataView.AllowEdit = false;
        this._PriceRequestDataView.AllowDelete = false;
        this.dgPriceRequests.DataSource = (object) this.PriceRequestDataView;
      }
    }

    private DataRow SelectedPriceRequestDataRow
    {
      get
      {
        return this.dgPriceRequests.CurrentRowIndex != -1 ? this.PriceRequestDataView[this.dgPriceRequests.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView ConfirmedPriceRequestDataView
    {
      get
      {
        return this._ConfirmedPriceRequestDataView;
      }
      set
      {
        this._ConfirmedPriceRequestDataView = value;
        this._ConfirmedPriceRequestDataView.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
        this._ConfirmedPriceRequestDataView.AllowNew = false;
        this._ConfirmedPriceRequestDataView.AllowEdit = false;
        this._ConfirmedPriceRequestDataView.AllowDelete = false;
        this.dgConfirmedPriceRequests.DataSource = (object) this.ConfirmedPriceRequestDataView;
      }
    }

    private DataRow SelectedConfirmedPriceRequestDataRow
    {
      get
      {
        return this.dgConfirmedPriceRequests.CurrentRowIndex != -1 ? this.ConfirmedPriceRequestDataView[this.dgConfirmedPriceRequests.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public QuoteOrder CurrentQuoteOrder
    {
      get
      {
        return this.oQuoteOrder;
      }
      set
      {
        this.oQuoteOrder = value;
        if (this.CurrentQuoteOrder == null)
        {
          this.CurrentQuoteOrder = new QuoteOrder();
          this.CurrentQuoteOrder.Exists = false;
          this.cboStatus.Enabled = false;
          ComboBox cboStatus = this.cboStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(1));
          this.cboStatus = cboStatus;
        }
        else
          this.cboStatus.Enabled = true;
        if (this.CurrentQuoteOrder.Exists)
        {
          this.btnSearch.Enabled = true;
          this.btnUpdate.Enabled = true;
          this.lblSearch.Visible = false;
          this.Populate(0);
        }
        else
        {
          this.btnSearch.Enabled = false;
          this.btnUpdate.Enabled = false;
          this.lblSearch.Visible = true;
        }
        this.Loading = false;
      }
    }

    public FSM.Entity.Customers.Customer Customer
    {
      get
      {
        return this._oCustomer;
      }
      set
      {
        this._oCustomer = value;
        if (this._oCustomer != null)
        {
          this.txtCustomer.Text = this.Customer.Name + " ( " + this.Customer.AccountNumber + ") ";
          this.btnFindSite.Enabled = true;
          this.theSite = (FSM.Entity.Sites.Site) null;
          this.InvoiceAddress = (InvoiceAddress) null;
          this.Contact = (Contact) null;
        }
        else
        {
          this.txtCustomer.Text = "";
          this.btnFindSite.Enabled = false;
        }
      }
    }

    public FSM.Entity.Sites.Site theSite
    {
      get
      {
        return this._oSite;
      }
      set
      {
        this._oSite = value;
        if (this._oSite != null)
        {
          this.txtSite.Text = this.theSite.Address1 + ", " + this.theSite.Address2 + ", " + this.theSite.Postcode;
          this.btnFindInvoiceAddress.Enabled = true;
          this.btnFindContact.Enabled = true;
          this.InvoiceAddress = (InvoiceAddress) null;
          this.Contact = (Contact) null;
          this.theWarehouse = (Warehouse) null;
        }
        else
        {
          this.txtSite.Text = "";
          this.btnFindInvoiceAddress.Enabled = false;
          this.btnFindContact.Enabled = false;
        }
      }
    }

    public Warehouse theWarehouse
    {
      get
      {
        return this._oWarehouse;
      }
      set
      {
        this._oWarehouse = value;
        if (this._oWarehouse != null)
        {
          this.txtWarehouse.Text = this.theWarehouse.Address1 + ", " + this.theWarehouse.Address2 + ", " + this.theWarehouse.Postcode;
          this.theSite = (FSM.Entity.Sites.Site) null;
        }
        else
          this.txtWarehouse.Text = "";
      }
    }

    public InvoiceAddress InvoiceAddress
    {
      get
      {
        return this._invoiceAddress;
      }
      set
      {
        this._invoiceAddress = value;
        if (this.InvoiceAddress != null)
          this.txtInvoiceAddress.Text = this.InvoiceAddress.Address1 + ", " + this.InvoiceAddress.Address2 + ", " + this.InvoiceAddress.Postcode;
        else
          this.txtInvoiceAddress.Text = "";
      }
    }

    public Contact Contact
    {
      get
      {
        return this._contact;
      }
      set
      {
        this._contact = value;
        if (this.Contact != null)
          this.txtContact.Text = this.Contact.FirstName + " " + this.Contact.Surname;
        else
          this.txtContact.Text = "";
      }
    }

    public event UCGenerateQuote.FormCloseEventHandler FormClose;

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public void SetupPriceRequestDatagrid()
    {
      Helper.SetUpDataGrid(this.dgPriceRequests, false);
      DataGridTableStyle tableStyle = this.dgPriceRequests.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 70;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Supplier";
      dataGridLabelColumn2.MappingName = "SupplierName";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 140;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Part";
      dataGridLabelColumn3.MappingName = "Part";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Product";
      dataGridLabelColumn4.MappingName = "Product";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Quantity";
      dataGridLabelColumn5.MappingName = "QuantityInPack";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 110;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
      this.dgPriceRequests.TableStyles.Add(tableStyle);
    }

    public void SetupConfirmedPriceRequestDatagrid()
    {
      Helper.SetUpDataGrid(this.dgConfirmedPriceRequests, false);
      this.dgConfirmedPriceRequests.ReadOnly = false;
      DataGridTableStyle tableStyle = this.dgConfirmedPriceRequests.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridCheckBox dataGridCheckBox = new DataGridCheckBox();
      dataGridCheckBox.HeaderText = "Selected";
      dataGridCheckBox.MappingName = "Included";
      dataGridCheckBox.ReadOnly = true;
      dataGridCheckBox.Width = 50;
      dataGridCheckBox.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridCheckBox);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Type";
      dataGridLabelColumn1.MappingName = "Type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 70;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Supplier";
      dataGridLabelColumn2.MappingName = "SupplierName";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 120;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Part";
      dataGridLabelColumn3.MappingName = "Part";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 120;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Product";
      dataGridLabelColumn4.MappingName = "Product";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 120;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Supplier Code";
      dataGridLabelColumn5.MappingName = "Code";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 120;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "C";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Buy Price";
      dataGridLabelColumn6.MappingName = "BuyPrice";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 90;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Quantity";
      dataGridLabelColumn7.MappingName = "QuantityInPack";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 90;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridOrderTextBoxColumn orderTextBoxColumn = new DataGridOrderTextBoxColumn();
      orderTextBoxColumn.Format = "C";
      orderTextBoxColumn.FormatInfo = (IFormatProvider) null;
      orderTextBoxColumn.HeaderText = "Sell Price";
      orderTextBoxColumn.MappingName = "SellPrice";
      orderTextBoxColumn.ReadOnly = false;
      orderTextBoxColumn.Width = 90;
      orderTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) orderTextBoxColumn);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
      this.dgConfirmedPriceRequests.TableStyles.Add(tableStyle);
    }

    public object SetupPartsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgParts, false);
      this.dgParts.ReadOnly = false;
      DataGridTableStyle tableStyle = this.dgParts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Number";
      dataGridLabelColumn2.MappingName = "Number";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 130;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Part Reference";
      dataGridLabelColumn3.MappingName = "Reference";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridOrderTextBoxColumn orderTextBoxColumn1 = new DataGridOrderTextBoxColumn();
      orderTextBoxColumn1.Format = "C";
      orderTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      orderTextBoxColumn1.HeaderText = "List Price";
      orderTextBoxColumn1.MappingName = "SellPrice";
      orderTextBoxColumn1.ReadOnly = false;
      orderTextBoxColumn1.Width = 100;
      orderTextBoxColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) orderTextBoxColumn1);
      DataGridOrderTextBoxColumn orderTextBoxColumn2 = new DataGridOrderTextBoxColumn();
      orderTextBoxColumn2.Format = "F";
      orderTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      orderTextBoxColumn2.HeaderText = "Quantity";
      orderTextBoxColumn2.MappingName = "Quantity";
      orderTextBoxColumn2.ReadOnly = false;
      orderTextBoxColumn2.Width = 150;
      orderTextBoxColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) orderTextBoxColumn2);
      DataGridOrderTextBoxColumn orderTextBoxColumn3 = new DataGridOrderTextBoxColumn();
      orderTextBoxColumn3.Format = "C";
      orderTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      orderTextBoxColumn3.HeaderText = "Quote Price";
      orderTextBoxColumn3.MappingName = "Price";
      orderTextBoxColumn3.ReadOnly = false;
      orderTextBoxColumn3.Width = 150;
      orderTextBoxColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) orderTextBoxColumn3);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblPart.ToString();
      this.dgParts.TableStyles.Add(tableStyle);
      object obj;
      return obj;
    }

    public object SetupProductsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgProducts, false);
      this.dgProducts.ReadOnly = false;
      DataGridTableStyle tableStyle = this.dgProducts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "typemakemodel";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Number";
      dataGridLabelColumn2.MappingName = "Number";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 130;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Product Reference";
      dataGridLabelColumn3.MappingName = "Reference";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridOrderTextBoxColumn orderTextBoxColumn1 = new DataGridOrderTextBoxColumn();
      orderTextBoxColumn1.Format = "C";
      orderTextBoxColumn1.FormatInfo = (IFormatProvider) null;
      orderTextBoxColumn1.HeaderText = "List Price";
      orderTextBoxColumn1.MappingName = "SellPrice";
      orderTextBoxColumn1.ReadOnly = false;
      orderTextBoxColumn1.Width = 100;
      orderTextBoxColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) orderTextBoxColumn1);
      DataGridOrderTextBoxColumn orderTextBoxColumn2 = new DataGridOrderTextBoxColumn();
      orderTextBoxColumn2.Format = "F";
      orderTextBoxColumn2.FormatInfo = (IFormatProvider) null;
      orderTextBoxColumn2.HeaderText = "Quantity";
      orderTextBoxColumn2.MappingName = "Quantity";
      orderTextBoxColumn2.ReadOnly = false;
      orderTextBoxColumn2.Width = 150;
      orderTextBoxColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) orderTextBoxColumn2);
      DataGridOrderTextBoxColumn orderTextBoxColumn3 = new DataGridOrderTextBoxColumn();
      orderTextBoxColumn3.Format = "C";
      orderTextBoxColumn3.FormatInfo = (IFormatProvider) null;
      orderTextBoxColumn3.HeaderText = "Price";
      orderTextBoxColumn3.MappingName = "Price";
      orderTextBoxColumn3.ReadOnly = false;
      orderTextBoxColumn3.Width = 150;
      orderTextBoxColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) orderTextBoxColumn3);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblProduct.ToString();
      this.dgProducts.TableStyles.Add(tableStyle);
      object obj;
      return obj;
    }

    private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.Loading & this.CurrentQuoteOrder != null && this.CurrentQuoteOrder.Exists)
      {
        if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboStatus)) == 2)
        {
          switch ((MsgBoxResult) App.ShowMessage("You are converting this quote to an order\r\nDo you wish to save any changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
          {
            case MsgBoxResult.Cancel:
              ComboBox cboStatus1 = this.cboStatus;
              Combo.SetSelectedComboItem_By_Value(ref cboStatus1, Conversions.ToString(this.CurrentQuoteOrder.QuoteStatusID));
              this.cboStatus = cboStatus1;
              return;
            case MsgBoxResult.Yes:
              if (!this.Save())
                return;
              break;
            case MsgBoxResult.No:
              App.DB.QuoteOrder.Update(this.oQuoteOrder);
              break;
          }
          FRMConvertToAnOrder instance = (FRMConvertToAnOrder) Activator.CreateInstance(typeof (FRMConvertToAnOrder));
          instance.ShowInTaskbar = false;
          instance.StartPosition = FormStartPosition.CenterScreen;
          instance.SizeGripStyle = SizeGripStyle.Hide;
          DataView dataView = new DataView(new DataTable());
          dataView.Table.Columns.Add("PartProductID");
          dataView.Table.Columns.Add("Type");
          dataView.Table.Columns.Add("Number");
          dataView.Table.Columns.Add("Name");
          dataView.Table.Columns.Add("Quantity");
          dataView.Table.Columns.Add("SellPrice");
          IEnumerator enumerator1;
          try
          {
            enumerator1 = this.PartsDataView.Table.Rows.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataRow current = (DataRow) enumerator1.Current;
              DataRow row = dataView.Table.NewRow();
              row["PartProductID"] = RuntimeHelpers.GetObjectValue(current["PartID"]);
              row["Type"] = (object) "Part";
              row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
              row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
              row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
              row["SellPrice"] = RuntimeHelpers.GetObjectValue(current["Price"]);
              dataView.Table.Rows.Add(row);
              dataView.Table.AcceptChanges();
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
          IEnumerator enumerator2;
          try
          {
            enumerator2 = this.ProductsDataView.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              DataRow row = dataView.Table.NewRow();
              row["PartProductID"] = RuntimeHelpers.GetObjectValue(current["ProductID"]);
              row["Type"] = (object) "Product";
              row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
              row["Name"] = RuntimeHelpers.GetObjectValue(current["typemakemodel"]);
              row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
              row["SellPrice"] = RuntimeHelpers.GetObjectValue(current["Price"]);
              dataView.Table.Rows.Add(row);
              dataView.Table.AcceptChanges();
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          instance.PriceRequestItemsDataView = this.ConfirmedPriceRequestDataView;
          ((IBaseForm) instance).SetFormParameters = (Array) new object[6]
          {
            (object) 1,
            (object) 0,
            (object) dataView,
            (object) this.CurrentQuoteOrder,
            (object) 0,
            (object) this.ConfirmedPriceRequestDataView
          };
          if (instance.ShowDialog() != DialogResult.OK)
          {
            ComboBox cboStatus2 = this.cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref cboStatus2, Conversions.ToString(1));
            this.cboStatus = cboStatus2;
            this.Save();
          }
          this.Populate(this.CurrentQuoteOrder.QuoteOrderID);
        }
        else if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboStatus)) == 3)
        {
          App.ShowForm(typeof (FRMQuoteRejection), true, new object[2]
          {
            (object) this,
            (object) ""
          }, false);
          this.Populate(this.CurrentQuoteOrder.QuoteOrderID);
        }
      }
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Customer = App.DB.Customer.Customer_Get(integer);
    }

    private void btnFindProduct_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblProduct, 0, "", false));
      if (integer <= 0)
        return;
      this.addProduct(integer);
    }

    private void btnFindPart_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblPart, 0, "", false));
      if (integer <= 0)
        return;
      this.addPart(integer);
    }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, this.Customer.CustomerID, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theSite = App.DB.Sites.Get((object) integer, SiteSQL.GetBy.SiteId, (object) null);
    }

    private void UCGenerateQuote_Load(object sender, EventArgs e)
    {
      this.Loading = true;
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnRemoveProducts_Click(object sender, EventArgs e)
    {
      if (this.SelectedProductDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select product to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        this.ProductsDataView.Table.Rows.Remove(this.SelectedProductDataRow);
        this.ProductsDataView.Table.AcceptChanges();
      }
    }

    private void btnRemoveParts_Click(object sender, EventArgs e)
    {
      if (this.SelectedPartDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select part to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        this.PartsDataView.Table.Rows.Remove(this.SelectedPartDataRow);
        this.PartsDataView.Table.AcceptChanges();
      }
    }

    private void btnFindInvoiceAddress_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblInvoiceAddress, this.theSite.SiteID, "", false));
      if ((uint) integer <= 0U)
        return;
      this.InvoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(integer);
    }

    private void btnFindContact_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblContact, this.theSite.SiteID, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Contact = App.DB.Contact.Contact_Get(integer);
    }

    private void chkDeadlineNA_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkDeadlineNA.Checked)
        this.dtpDeliveryDeadline.Enabled = false;
      else
        this.dtpDeliveryDeadline.Enabled = true;
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      DLGAdvancedItemSearch advancedItemSearch = (DLGAdvancedItemSearch) App.checkIfExists(typeof (DLGAdvancedItemSearch).Name, true) ?? (DLGAdvancedItemSearch) Activator.CreateInstance(typeof (DLGAdvancedItemSearch));
      advancedItemSearch.ShowInTaskbar = false;
      advancedItemSearch.QuoteID = this.oQuoteOrder.QuoteOrderID;
      int num = (int) advancedItemSearch.ShowDialog();
      if (advancedItemSearch.DialogResult != DialogResult.OK)
        ;
      advancedItemSearch.Dispose();
      this.RefreshDatagrids();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      this.UpdatePriceRequest();
    }

    private void dgPriceRequests_DoubleClick(object sender, EventArgs e)
    {
      this.UpdatePriceRequest();
    }

    private void btnFindWarehouse_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theWarehouse = App.DB.Warehouse.Warehouse_Get(integer);
    }

    private void UpdatePriceRequest()
    {
      if (this.SelectedPriceRequestDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select an item to update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedPriceRequestDataRow["Type"], (object) "Part", false))
          App.ShowForm(typeof (FRMAddToQuote), true, new object[4]
          {
            (object) this.CurrentQuoteOrder.QuoteOrderID,
            (object) new PartSupplier()
            {
              SetPartID = RuntimeHelpers.GetObjectValue(this.SelectedPriceRequestDataRow["PartProductID"]),
              SetSupplierID = RuntimeHelpers.GetObjectValue(this.SelectedPriceRequestDataRow["SupplierID"]),
              SetQuantityInPack = RuntimeHelpers.GetObjectValue(this.SelectedPriceRequestDataRow["QuantityInPack"])
            },
            null,
            this.SelectedPriceRequestDataRow["ID"]
          }, false);
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedPriceRequestDataRow["Type"], (object) "Product", false))
          App.ShowForm(typeof (FRMAddToQuote), true, new object[4]
          {
            (object) this.CurrentQuoteOrder.QuoteOrderID,
            null,
            (object) new ProductSupplier()
            {
              SetProductID = RuntimeHelpers.GetObjectValue(this.SelectedPriceRequestDataRow["PartProductID"]),
              SetSupplierID = RuntimeHelpers.GetObjectValue(this.SelectedPriceRequestDataRow["SupplierID"]),
              SetQuantityInPack = RuntimeHelpers.GetObjectValue(this.SelectedPriceRequestDataRow["QuantityInPack"])
            },
            this.SelectedPriceRequestDataRow["ID"]
          }, false);
        this.RefreshDatagrids();
      }
    }

    private void RefreshDatagrids()
    {
      this.PriceRequestDataView = App.DB.QuoteOrder.Quote_PriceRequests_GetAll(this.CurrentQuoteOrder.QuoteOrderID);
      this.ConfirmedPriceRequestDataView = App.DB.QuoteOrder.Quote_PriceRequests_GetConfirmed(this.CurrentQuoteOrder.QuoteOrderID);
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentQuoteOrder = App.DB.QuoteOrder.QuoteOrder_Get(ID);
      this.Customer = App.DB.Customer.Customer_Get(this.CurrentQuoteOrder.CustomerID);
      this.theSite = App.DB.Sites.Get((object) this.CurrentQuoteOrder.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
      this.Contact = App.DB.Contact.Contact_Get(this.CurrentQuoteOrder.ContactID);
      this.InvoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(this.CurrentQuoteOrder.InvoiceAddressID);
      this.theWarehouse = App.DB.Warehouse.Warehouse_Get(this.CurrentQuoteOrder.WarehouseID);
      this.txtSpecialInstructions.Text = this.CurrentQuoteOrder.SpecialInstructions;
      if (DateTime.Compare(this.CurrentQuoteOrder.DeliveryDeadline, DateTime.MinValue) == 0)
      {
        this.chkDeadlineNA.Checked = true;
      }
      else
      {
        this.dtpDeliveryDeadline.Value = this.CurrentQuoteOrder.DeliveryDeadline;
        this.chkDeadlineNA.Checked = false;
      }
      ComboBox cboUsers = this.cboUsers;
      Combo.SetSelectedComboItem_By_Value(ref cboUsers, Conversions.ToString(this.CurrentQuoteOrder.AllocatedToUser));
      this.cboUsers = cboUsers;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.CurrentQuoteOrder.QuoteStatusID));
      this.cboStatus = cboStatus;
      if (this.CurrentQuoteOrder.QuoteStatusID == 1)
        this.SetFormState(true);
      else
        this.SetFormState(false);
      this.txtCustRef.Text = this.CurrentQuoteOrder.CustomerRef;
      this.txtPriceDetails.Text = this.CurrentQuoteOrder.PriceDetails;
      this.txtPriceExcludeDetails.Text = this.CurrentQuoteOrder.PriceExcludeDetails;
      this.txtAvailability.Text = this.CurrentQuoteOrder.Availability;
      this.dtpEnquiryDate.Value = this.CurrentQuoteOrder.EnquiryDate;
      this.dtpValidUntil.Value = this.CurrentQuoteOrder.ValidUntilDate;
      this.PartsDataView = (DataView) App.DB.QuoteOrderPart.QuoteOrderPart_GetForQuoteOrder(this.CurrentQuoteOrder.QuoteOrderID);
      this.ProductsDataView = (DataView) App.DB.QuoteOrderProduct.QuoteOrderProduct_GetForQuoteOrder(this.CurrentQuoteOrder.QuoteOrderID);
      this.RefreshDatagrids();
    }

    public bool Save()
    {
      bool flag;
      try
      {
        QuoteOrder oQuoteOrder = new QuoteOrder();
        if (this.CurrentQuoteOrder.Exists)
          oQuoteOrder.SetReasonForReject = (object) this.CurrentQuoteOrder.ReasonForReject;
        oQuoteOrder.SetCustomerID = this.Customer == null ? (object) 0 : (object) this.Customer.CustomerID;
        oQuoteOrder.SetPropertyID = this.theSite == null ? (object) 0 : (object) this.theSite.SiteID;
        oQuoteOrder.SetWarehouseID = this.theWarehouse == null ? (object) 0 : (object) this.theWarehouse.WarehouseID;
        oQuoteOrder.SetAllocatedToUser = (object) Combo.get_GetSelectedItemValue(this.cboUsers);
        oQuoteOrder.SetCreatedByUser = (object) App.loggedInUser.UserID;
        oQuoteOrder.SetContactID = this.Contact == null ? (object) 0 : (object) this.Contact.ContactID;
        oQuoteOrder.SetCustomerRef = (object) this.txtCustRef.Text;
        oQuoteOrder.SetAvailability = (object) this.txtAvailability.Text;
        oQuoteOrder.SetPriceDetails = (object) this.txtPriceDetails.Text;
        oQuoteOrder.SetPriceExcludeDetails = (object) this.txtPriceExcludeDetails.Text;
        oQuoteOrder.EnquiryDate = this.dtpEnquiryDate.Value;
        oQuoteOrder.ValidUntilDate = this.dtpValidUntil.Value;
        oQuoteOrder.SetInvoiceAddressID = this.InvoiceAddress == null ? (object) 0 : (object) this.InvoiceAddress.InvoiceAddressID;
        oQuoteOrder.SetSpecialInstructions = (object) this.txtSpecialInstructions.Text;
        oQuoteOrder.SetQuoteStatusID = (object) Combo.get_GetSelectedItemValue(this.cboStatus);
        oQuoteOrder.DeliveryDeadline = !this.chkDeadlineNA.Checked ? this.dtpDeliveryDeadline.Value : DateTime.MinValue;
        if (this.CurrentQuoteOrder.Exists)
        {
          oQuoteOrder.SetQuoteOrderID = (object) this.CurrentQuoteOrder.QuoteOrderID;
          new QuoteOrderValidator().Validate(oQuoteOrder);
          App.DB.QuoteOrder.Update(oQuoteOrder);
        }
        else
        {
          new QuoteOrderValidator().Validate(oQuoteOrder);
          oQuoteOrder = App.DB.QuoteOrder.Insert(oQuoteOrder);
        }
        App.DB.QuoteOrderPart.QuoteOrderPart_DeleteForQuoteOrder(oQuoteOrder.QuoteOrderID);
        IEnumerator enumerator1;
        if (this.PartsDataView != null)
        {
          try
          {
            enumerator1 = this.PartsDataView.Table.Rows.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataRow current = (DataRow) enumerator1.Current;
              App.DB.QuoteOrderPart.Insert(new QuoteOrderPart()
              {
                SetQuoteOrderID = (object) oQuoteOrder.QuoteOrderID,
                SetPartID = RuntimeHelpers.GetObjectValue(current["PartID"]),
                SetQuantity = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Quantity"])),
                SetPrice = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Price"]))
              });
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
        }
        App.DB.QuoteOrderProduct.QuoteOrderProduct_DeleteForQuoteOrder(oQuoteOrder.QuoteOrderID);
        IEnumerator enumerator2;
        if (this.ProductsDataView != null)
        {
          try
          {
            enumerator2 = this.ProductsDataView.Table.Rows.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRow current = (DataRow) enumerator2.Current;
              App.DB.QuoteOrderProduct.Insert(new QuoteOrderProduct()
              {
                SetQuoteOrderID = (object) oQuoteOrder.QuoteOrderID,
                SetProductID = RuntimeHelpers.GetObjectValue(current["ProductID"]),
                SetQuantity = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Quantity"])),
                SetPrice = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Price"]))
              });
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
        App.DB.QuoteOrder.QuoteOrder_DeleteItemsIncluded(oQuoteOrder.QuoteOrderID);
        if (this.ConfirmedPriceRequestDataView != null)
        {
          IEnumerator enumerator3;
          try
          {
            enumerator3 = this.ConfirmedPriceRequestDataView.Table.Rows.GetEnumerator();
            while (enumerator3.MoveNext())
            {
              DataRow current = (DataRow) enumerator3.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Included"], (object) "1", false) && Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["SellPrice"])) | !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(current["SellPrice"])))
              {
                int num = (int) App.ShowMessage("Please enter a Sell Price for all Items checked", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto label_46;
              }
            }
          }
          finally
          {
            if (enumerator3 is IDisposable)
              (enumerator3 as IDisposable).Dispose();
          }
          IEnumerator enumerator4;
          try
          {
            enumerator4 = this.ConfirmedPriceRequestDataView.Table.Rows.GetEnumerator();
            while (enumerator4.MoveNext())
            {
              DataRow current = (DataRow) enumerator4.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Included"], (object) "1", false))
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Part", false))
                  App.DB.QuoteOrder.QuoteOrderPartsToInclude_Insert(oQuoteOrder.QuoteOrderID, Conversions.ToInteger(current["PartSupplierID"]), Conversions.ToDouble(current["SellPrice"]));
                else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "Product", false))
                  App.DB.QuoteOrder.QuoteOrderProductsToInclude_Insert(oQuoteOrder.QuoteOrderID, Conversions.ToInteger(current["ProductSupplierID"]), Conversions.ToDouble(current["SellPrice"]));
              }
            }
          }
          finally
          {
            if (enumerator4 is IDisposable)
              (enumerator4 as IDisposable).Dispose();
          }
        }
        oQuoteOrder.Exists = true;
        this.CurrentQuoteOrder = oQuoteOrder;
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentQuoteOrder.QuoteOrderID);
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
label_46:
      return flag;
    }

    private void SetFormState(bool Enabled)
    {
      this.btnFindCustomer.Enabled = Enabled;
      if (!Enabled)
      {
        this.btnFindInvoiceAddress.Enabled = Enabled;
        this.btnFindContact.Enabled = Enabled;
      }
      this.btnFindPart.Enabled = Enabled;
      this.btnFindProduct.Enabled = Enabled;
      this.btnFindSite.Enabled = Enabled;
      this.btnRemoveParts.Enabled = Enabled;
      this.btnRemoveProducts.Enabled = Enabled;
      this.cboStatus.Enabled = Enabled;
      this.cboUsers.Enabled = Enabled;
      this.chkDeadlineNA.Enabled = Enabled;
      this.dgParts.Enabled = Enabled;
      this.dgProducts.Enabled = Enabled;
      this.dtpDeliveryDeadline.Enabled = Enabled;
      this.dtpEnquiryDate.Enabled = Enabled;
      this.dtpValidUntil.Enabled = Enabled;
      this.txtAvailability.Enabled = Enabled;
      this.txtCustRef.Enabled = Enabled;
      this.txtPriceDetails.Enabled = Enabled;
      this.txtPriceExcludeDetails.Enabled = Enabled;
      this.txtSpecialInstructions.Enabled = Enabled;
    }

    private void addProduct(int ProductID)
    {
      Product product = App.DB.Product.Product_Get(ProductID);
      if (this.ProductsDataView == null)
      {
        this.ProductsDataView = new DataView(new DataTable());
        this.ProductsDataView.Table.Columns.Add(nameof (ProductID));
        this.ProductsDataView.Table.Columns.Add("typemakemodel");
        this.ProductsDataView.Table.Columns.Add("Number");
        this.ProductsDataView.Table.Columns.Add("SellPrice");
        this.ProductsDataView.Table.Columns.Add("Quantity");
        this.ProductsDataView.Table.Columns.Add("Price");
      }
      DataRow row = this.ProductsDataView.Table.NewRow();
      row[nameof (ProductID)] = (object) ProductID;
      row["typemakemodel"] = (object) product.Name;
      row["Number"] = (object) product.Number;
      row["SellPrice"] = (object) product.SellPrice;
      this.ProductsDataView.Table.Rows.Add(row);
    }

    private void addPart(int PartID)
    {
      Part part = App.DB.Part.Part_Get(PartID);
      if (this.PartsDataView == null)
      {
        this.PartsDataView = new DataView(new DataTable());
        this.PartsDataView.Table.Columns.Add(nameof (PartID));
        this.PartsDataView.Table.Columns.Add("Name");
        this.PartsDataView.Table.Columns.Add("Number");
        this.PartsDataView.Table.Columns.Add("SellPrice");
        this.PartsDataView.Table.Columns.Add("Quantity");
        this.PartsDataView.Table.Columns.Add("Price");
      }
      DataRow row = this.PartsDataView.Table.NewRow();
      row[nameof (PartID)] = (object) PartID;
      row["Name"] = (object) part.Name;
      row["Number"] = (object) part.Number;
      row["SellPrice"] = (object) part.SellPrice;
      this.PartsDataView.Table.Rows.Add(row);
    }

    public void RejectReasonChanged(string Reason, int ReasonID)
    {
      this.CurrentQuoteOrder.SetReasonForReject = (object) Reason;
      this.CurrentQuoteOrder.SetReasonForRejectID = (object) ReasonID;
      this.Save();
    }

    public delegate void FormCloseEventHandler();
  }
}
