// Decompiled with JetBrains decompiler
// Type: FSM.UCOrder
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Business.Orders;
using FSM.Entity.CostCentres;
using FSM.Entity.CustomerOrders;
using FSM.Entity.EngineerVisitOrders;
using FSM.Entity.EngineerVisits;
using FSM.Entity.Jobs;
using FSM.Entity.OrderConsolidations;
using FSM.Entity.OrderLocationPart;
using FSM.Entity.OrderLocationProduct;
using FSM.Entity.OrderLocations;
using FSM.Entity.OrderParts;
using FSM.Entity.OrderProducts;
using FSM.Entity.Orders;
using FSM.Entity.PartsToBeCrediteds;
using FSM.Entity.PartSupplierPriceRequests;
using FSM.Entity.PartSuppliers;
using FSM.Entity.PartTransactions;
using FSM.Entity.Products;
using FSM.Entity.ProductSupplierPriceRequests;
using FSM.Entity.ProductSuppliers;
using FSM.Entity.ProductTransactions;
using FSM.Entity.SiteOrders;
using FSM.Entity.Sites;
using FSM.Entity.Suppliers;
using FSM.Entity.Sys;
using FSM.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class UCOrder : UCBase, IUserControl
  {
    private IContainer components;
    private bool IsLoading;
    private UCDocumentsList DocumentsControl;
    public UCOrderForCustomer ucCustomerOrder;
    public UCOrderForJob ucJobOrder;
    public UCOrderForWarehouse ucWarehouseOrder;
    public UCOrderForVan ucVanOrder;
    private Order _currentOrder;
    private int _passedID;
    private string _reason;
    private DataView _ItemsIncludedDataView;
    private DataView _ProductsDataView;
    private DataView _PriceRequestDataView;
    private DataView _PartsDataView;
    private int _supplierUsedID;
    private int _locationUsedID;
    private bool _OrderNumberUsed;
    private JobNumber _OrderNumber;
    private int _customerID;

    public UCOrder()
    {
      this.KeyDown += new KeyEventHandler(this.UCOrder_KeyDown);
      this.Load += new EventHandler(this.UCOrder_Load);
      this.IsLoading = true;
      this.ucCustomerOrder = new UCOrderForCustomer();
      this.ucJobOrder = new UCOrderForJob();
      this.ucWarehouseOrder = new UCOrderForWarehouse();
      this.ucVanOrder = new UCOrderForVan();
      this._reason = "";
      this._ItemsIncludedDataView = (DataView) null;
      this._ProductsDataView = (DataView) null;
      this._PriceRequestDataView = (DataView) null;
      this._PartsDataView = (DataView) null;
      this._OrderNumberUsed = false;
      this._OrderNumber = new JobNumber();
      this.InitializeComponent();
      ComboBox cboOrderTypeId = this.cboOrderTypeID;
      Combo.SetUpCombo(ref cboOrderTypeId, DynamicDataTables.OrderType, "ValueMember", "DisplayMember", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboOrderTypeID = cboOrderTypeId;
      ComboBox cboPartLocation = this.cboPartLocation;
      Combo.SetUpCombo(ref cboPartLocation, DynamicDataTables.LocationType, "ValueMember", "DisplayMember", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboPartLocation = cboPartLocation;
      ComboBox cboProductLocation = this.cboProductLocation;
      Combo.SetUpCombo(ref cboProductLocation, DynamicDataTables.LocationType, "ValueMember", "DisplayMember", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
      this.cboProductLocation = cboProductLocation;
      ComboBox cboOrderStatus = this.cboOrderStatus;
      Combo.SetUpCombo(ref cboOrderStatus, App.DB.Order.OrderStatus_Get_All().Table, "OrderStatusID", "Name", FSM.Entity.Sys.Enums.ComboValues.None);
      this.cboOrderStatus = cboOrderStatus;
      ComboBox invoiceTaxCodeNew = this.cboInvoiceTaxCodeNew;
      Combo.SetUpCombo(ref invoiceTaxCodeNew, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.VATCodes, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Dashes);
      this.cboInvoiceTaxCodeNew = invoiceTaxCodeNew;
      ComboBox cboCreditTax = this.cboCreditTax;
      Combo.SetUpCombo(ref cboCreditTax, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.VATCodes, false).Table, "ManagerID", "Name", FSM.Entity.Sys.Enums.ComboValues.Dashes);
      this.cboCreditTax = cboCreditTax;
      if (true == App.IsGasway)
      {
        ComboBox cboDept = this.cboDept;
        Combo.SetUpCombo(ref cboDept, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Department, false).Table, "Name", "Name", FSM.Entity.Sys.Enums.ComboValues.Please_Select_Negative);
        this.cboDept = cboDept;
      }
      else
      {
        ComboBox cboDept = this.cboDept;
        Combo.SetUpCombo(ref cboDept, App.DB.Picklists.GetAll(FSM.Entity.Sys.Enums.PickListTypes.Department, false).Table, "Name", "Description", FSM.Entity.Sys.Enums.ComboValues.Please_Select_Negative);
        this.cboDept = cboDept;
      }
      this.chkDoNotConsolidate.Checked = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpOrder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDatePlaced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDatePlaced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboOrderTypeID
    {
      get
      {
        return this._cboOrderTypeID;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboOrderTypeID_SelectedIndexChanged);
        ComboBox cboOrderTypeId1 = this._cboOrderTypeID;
        if (cboOrderTypeId1 != null)
          cboOrderTypeId1.SelectedIndexChanged -= eventHandler;
        this._cboOrderTypeID = value;
        ComboBox cboOrderTypeId2 = this._cboOrderTypeID;
        if (cboOrderTypeId2 == null)
          return;
        cboOrderTypeId2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblOrderTypeID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtOrderReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOrderReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabProducts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProductSearch
    {
      get
      {
        return this._txtProductSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtProductSearch_KeyDown);
        TextBox txtProductSearch1 = this._txtProductSearch;
        if (txtProductSearch1 != null)
          txtProductSearch1.KeyDown -= keyEventHandler;
        this._txtProductSearch = value;
        TextBox txtProductSearch2 = this._txtProductSearch;
        if (txtProductSearch2 == null)
          return;
        txtProductSearch2.KeyDown += keyEventHandler;
      }
    }

    internal virtual Button btnProductSearch
    {
      get
      {
        return this._btnProductSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnProductSearch_Click);
        Button btnProductSearch1 = this._btnProductSearch;
        if (btnProductSearch1 != null)
          btnProductSearch1.Click -= eventHandler;
        this._btnProductSearch = value;
        Button btnProductSearch2 = this._btnProductSearch;
        if (btnProductSearch2 == null)
          return;
        btnProductSearch2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgProduct
    {
      get
      {
        return this._dgProduct;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgProduct_DoubleClick);
        EventHandler eventHandler2 = new EventHandler(this.dgProduct_Click);
        EventHandler eventHandler3 = new EventHandler(this.dgProduct_Click);
        DataGrid dgProduct1 = this._dgProduct;
        if (dgProduct1 != null)
        {
          dgProduct1.DoubleClick -= eventHandler1;
          dgProduct1.Click -= eventHandler2;
          dgProduct1.CurrentCellChanged -= eventHandler3;
        }
        this._dgProduct = value;
        DataGrid dgProduct2 = this._dgProduct;
        if (dgProduct2 == null)
          return;
        dgProduct2.DoubleClick += eventHandler1;
        dgProduct2.Click += eventHandler2;
        dgProduct2.CurrentCellChanged += eventHandler3;
      }
    }

    internal virtual TextBox txtPartSearch
    {
      get
      {
        return this._txtPartSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtPartSearch_KeyDown);
        TextBox txtPartSearch1 = this._txtPartSearch;
        if (txtPartSearch1 != null)
          txtPartSearch1.KeyDown -= keyEventHandler;
        this._txtPartSearch = value;
        TextBox txtPartSearch2 = this._txtPartSearch;
        if (txtPartSearch2 == null)
          return;
        txtPartSearch2.KeyDown += keyEventHandler;
      }
    }

    internal virtual Button btnAddProduct
    {
      get
      {
        return this._btnAddProduct;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddProduct_Click);
        Button btnAddProduct1 = this._btnAddProduct;
        if (btnAddProduct1 != null)
          btnAddProduct1.Click -= eventHandler;
        this._btnAddProduct = value;
        Button btnAddProduct2 = this._btnAddProduct;
        if (btnAddProduct2 == null)
          return;
        btnAddProduct2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddPart
    {
      get
      {
        return this._btnAddPart;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddPart_Click);
        Button btnAddPart1 = this._btnAddPart;
        if (btnAddPart1 != null)
          btnAddPart1.Click -= eventHandler;
        this._btnAddPart = value;
        Button btnAddPart2 = this._btnAddPart;
        if (btnAddPart2 == null)
          return;
        btnAddPart2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpPartSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAvailableParts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartQuantity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpProductSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpProductsAvailable { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProductQuantity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPartLocation
    {
      get
      {
        return this._cboPartLocation;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboPartLocation_SelectedIndexChanged);
        ComboBox cboPartLocation1 = this._cboPartLocation;
        if (cboPartLocation1 != null)
          cboPartLocation1.SelectedIndexChanged -= eventHandler;
        this._cboPartLocation = value;
        ComboBox cboPartLocation2 = this._cboPartLocation;
        if (cboPartLocation2 == null)
          return;
        cboPartLocation2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboProductLocation
    {
      get
      {
        return this._cboProductLocation;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboProductLocation_SelectedIndexChanged);
        ComboBox cboProductLocation1 = this._cboProductLocation;
        if (cboProductLocation1 != null)
          cboProductLocation1.SelectedIndexChanged -= eventHandler;
        this._cboProductLocation = value;
        ComboBox cboProductLocation2 = this._cboProductLocation;
        if (cboProductLocation2 == null)
          return;
        cboProductLocation2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Button btnPartSearch
    {
      get
      {
        return this._btnPartSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPartSearch_Click);
        Button btnPartSearch1 = this._btnPartSearch;
        if (btnPartSearch1 != null)
          btnPartSearch1.Click -= eventHandler;
        this._btnPartSearch = value;
        Button btnPartSearch2 = this._btnPartSearch;
        if (btnPartSearch2 == null)
          return;
        btnPartSearch2.Click += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartBuyPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProductSellPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProductBuyPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboOrderStatus
    {
      get
      {
        return this._cboOrderStatus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboOrderStatus_SelectedIndexChanged);
        ComboBox cboOrderStatus1 = this._cboOrderStatus;
        if (cboOrderStatus1 != null)
          cboOrderStatus1.SelectedIndexChanged -= eventHandler;
        this._cboOrderStatus = value;
        ComboBox cboOrderStatus2 = this._cboOrderStatus;
        if (cboOrderStatus2 == null)
          return;
        cboOrderStatus2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TabPage tabPartPriceReq { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUpdatePartPriceRequest
    {
      get
      {
        return this._btnUpdatePartPriceRequest;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdatePartPriceRequest_Click);
        Button partPriceRequest1 = this._btnUpdatePartPriceRequest;
        if (partPriceRequest1 != null)
          partPriceRequest1.Click -= eventHandler;
        this._btnUpdatePartPriceRequest = value;
        Button partPriceRequest2 = this._btnUpdatePartPriceRequest;
        if (partPriceRequest2 == null)
          return;
        partPriceRequest2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddNewPart
    {
      get
      {
        return this._btnAddNewPart;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNewPart_Click);
        Button btnAddNewPart1 = this._btnAddNewPart;
        if (btnAddNewPart1 != null)
          btnAddNewPart1.Click -= eventHandler;
        this._btnAddNewPart = value;
        Button btnAddNewPart2 = this._btnAddNewPart;
        if (btnAddNewPart2 == null)
          return;
        btnAddNewPart2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddNewProduct
    {
      get
      {
        return this._btnAddNewProduct;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNewProduct_Click);
        Button btnAddNewProduct1 = this._btnAddNewProduct;
        if (btnAddNewProduct1 != null)
          btnAddNewProduct1.Click -= eventHandler;
        this._btnAddNewProduct = value;
        Button btnAddNewProduct2 = this._btnAddNewProduct;
        if (btnAddNewProduct2 == null)
          return;
        btnAddNewProduct2.Click += eventHandler;
      }
    }

    internal virtual TabControl tcOrderDetails
    {
      get
      {
        return this._tcOrderDetails;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tcOrderDetails_SelectedIndexChanged);
        TabControl tcOrderDetails1 = this._tcOrderDetails;
        if (tcOrderDetails1 != null)
          tcOrderDetails1.SelectedIndexChanged -= eventHandler;
        this._tcOrderDetails = value;
        TabControl tcOrderDetails2 = this._tcOrderDetails;
        if (tcOrderDetails2 == null)
          return;
        tcOrderDetails2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TabPage tabItemsIncluded { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgItemsIncluded
    {
      get
      {
        return this._dgItemsIncluded;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgProduct_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgItemsIncluded_Click);
        DataGrid dgItemsIncluded1 = this._dgItemsIncluded;
        if (dgItemsIncluded1 != null)
        {
          dgItemsIncluded1.DoubleClick -= eventHandler1;
          dgItemsIncluded1.Click -= eventHandler2;
        }
        this._dgItemsIncluded = value;
        DataGrid dgItemsIncluded2 = this._dgItemsIncluded;
        if (dgItemsIncluded2 == null)
          return;
        dgItemsIncluded2.DoubleClick += eventHandler1;
        dgItemsIncluded2.Click += eventHandler2;
      }
    }

    internal virtual Label lblItemQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnItemQtyUpdate
    {
      get
      {
        return this._btnItemQtyUpdate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnItemRemove_Click);
        Button btnItemQtyUpdate1 = this._btnItemQtyUpdate;
        if (btnItemQtyUpdate1 != null)
          btnItemQtyUpdate1.Click -= eventHandler;
        this._btnItemQtyUpdate = value;
        Button btnItemQtyUpdate2 = this._btnItemQtyUpdate;
        if (btnItemQtyUpdate2 == null)
          return;
        btnItemQtyUpdate2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboPrintType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnPrint
    {
      get
      {
        return this._btnPrint;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrint_Click);
        Button btnPrint1 = this._btnPrint;
        if (btnPrint1 != null)
          btnPrint1.Click -= eventHandler;
        this._btnPrint = value;
        Button btnPrint2 = this._btnPrint;
        if (btnPrint2 == null)
          return;
        btnPrint2.Click += eventHandler;
      }
    }

    internal virtual Button btnEmail
    {
      get
      {
        return this._btnEmail;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEmail_Click);
        Button btnEmail1 = this._btnEmail;
        if (btnEmail1 != null)
          btnEmail1.Click -= eventHandler;
        this._btnEmail = value;
        Button btnEmail2 = this._btnEmail;
        if (btnEmail2 == null)
          return;
        btnEmail2.Click += eventHandler;
      }
    }

    internal virtual Button btnCharges
    {
      get
      {
        return this._btnCharges;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCharges_Click);
        Button btnCharges1 = this._btnCharges;
        if (btnCharges1 != null)
          btnCharges1.Click -= eventHandler;
        this._btnCharges = value;
        Button btnCharges2 = this._btnCharges;
        if (btnCharges2 == null)
          return;
        btnCharges2.Click += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TabPage tabDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOrderStatus
    {
      get
      {
        return this._lblOrderStatus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lblOrderStatus_Click);
        Label lblOrderStatus1 = this._lblOrderStatus;
        if (lblOrderStatus1 != null)
          lblOrderStatus1.Click -= eventHandler;
        this._lblOrderStatus = value;
        Label lblOrderStatus2 = this._lblOrderStatus;
        if (lblOrderStatus2 == null)
          return;
        lblOrderStatus2.Click += eventHandler;
      }
    }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCreatePartRequest
    {
      get
      {
        return this._btnCreatePartRequest;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCreatePartRequest_Click);
        Button createPartRequest1 = this._btnCreatePartRequest;
        if (createPartRequest1 != null)
          createPartRequest1.Click -= eventHandler;
        this._btnCreatePartRequest = value;
        Button createPartRequest2 = this._btnCreatePartRequest;
        if (createPartRequest2 == null)
          return;
        createPartRequest2.Click += eventHandler;
      }
    }

    internal virtual Button btnCreateProductPriceRequest
    {
      get
      {
        return this._btnCreateProductPriceRequest;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCreateProductPriceRequest_Click);
        Button productPriceRequest1 = this._btnCreateProductPriceRequest;
        if (productPriceRequest1 != null)
          productPriceRequest1.Click -= eventHandler;
        this._btnCreateProductPriceRequest = value;
        Button productPriceRequest2 = this._btnCreateProductPriceRequest;
        if (productPriceRequest2 == null)
          return;
        productPriceRequest2.Click += eventHandler;
      }
    }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgPriceRequests
    {
      get
      {
        return this._dgPriceRequests;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgPriceRequests_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgPriceRequests_Click);
        DataGrid dgPriceRequests1 = this._dgPriceRequests;
        if (dgPriceRequests1 != null)
        {
          dgPriceRequests1.Click -= eventHandler1;
          dgPriceRequests1.CurrentCellChanged -= eventHandler2;
        }
        this._dgPriceRequests = value;
        DataGrid dgPriceRequests2 = this._dgPriceRequests;
        if (dgPriceRequests2 == null)
          return;
        dgPriceRequests2.Click += eventHandler1;
        dgPriceRequests2.CurrentCellChanged += eventHandler2;
      }
    }

    internal virtual DateTimePicker dtpSupplierInvoiceDateNew { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNominalCodeNew { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtExtraReferenceNew { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInvoiceTaxCodeNew
    {
      get
      {
        return this._cboInvoiceTaxCodeNew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboTaxCode_SelectedIndexChanged);
        ComboBox invoiceTaxCodeNew1 = this._cboInvoiceTaxCodeNew;
        if (invoiceTaxCodeNew1 != null)
          invoiceTaxCodeNew1.SelectedIndexChanged -= eventHandler;
        this._cboInvoiceTaxCodeNew = value;
        ComboBox invoiceTaxCodeNew2 = this._cboInvoiceTaxCodeNew;
        if (invoiceTaxCodeNew2 == null)
          return;
        invoiceTaxCodeNew2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnReceiveAll
    {
      get
      {
        return this._btnReceiveAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReceiveAll_Click);
        Button btnReceiveAll1 = this._btnReceiveAll;
        if (btnReceiveAll1 != null)
          btnReceiveAll1.Click -= eventHandler;
        this._btnReceiveAll = value;
        Button btnReceiveAll2 = this._btnReceiveAll;
        if (btnReceiveAll2 == null)
          return;
        btnReceiveAll2.Click += eventHandler;
      }
    }

    internal virtual Button btnEngineerReceived
    {
      get
      {
        return this._btnEngineerReceived;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEngineerReceived_Click);
        Button engineerReceived1 = this._btnEngineerReceived;
        if (engineerReceived1 != null)
          engineerReceived1.Click -= eventHandler;
        this._btnEngineerReceived = value;
        Button engineerReceived2 = this._btnEngineerReceived;
        if (engineerReceived2 == null)
          return;
        engineerReceived2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkDoNotConsolidate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabInvoices { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpReceivedInvoices { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgvReceivedInvoices
    {
      get
      {
        return this._dgvReceivedInvoices;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DataGridViewCellEventHandler cellEventHandler = new DataGridViewCellEventHandler(this.dgvReceivedInvoices_CellClick);
        DataGridView receivedInvoices1 = this._dgvReceivedInvoices;
        if (receivedInvoices1 != null)
          receivedInvoices1.CellClick -= cellEventHandler;
        this._dgvReceivedInvoices = value;
        DataGridView receivedInvoices2 = this._dgvReceivedInvoices;
        if (receivedInvoices2 == null)
          return;
        receivedInvoices2.CellClick += cellEventHandler;
      }
    }

    internal virtual BindingSource FSMDataSetBindingSource { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual FSMDataSet FSMDataSet { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddSupplierInvoice
    {
      get
      {
        return this._btnAddSupplierInvoice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddSupplierInvoice_Click);
        Button addSupplierInvoice1 = this._btnAddSupplierInvoice;
        if (addSupplierInvoice1 != null)
          addSupplierInvoice1.Click -= eventHandler;
        this._btnAddSupplierInvoice = value;
        Button addSupplierInvoice2 = this._btnAddSupplierInvoice;
        if (addSupplierInvoice2 == null)
          return;
        addSupplierInvoice2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtTotalAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTotalValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVATAmount
    {
      get
      {
        return this._txtVATAmount;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtVATAmount_LostFocus);
        TextBox txtVatAmount1 = this._txtVATAmount;
        if (txtVatAmount1 != null)
          txtVatAmount1.LostFocus -= eventHandler;
        this._txtVATAmount = value;
        TextBox txtVatAmount2 = this._txtVATAmount;
        if (txtVatAmount2 == null)
          return;
        txtVatAmount2.LostFocus += eventHandler;
      }
    }

    internal virtual Label lblVatValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtGoodsAmount
    {
      get
      {
        return this._txtGoodsAmount;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtGoodsAmount_TextChanged);
        TextBox txtGoodsAmount1 = this._txtGoodsAmount;
        if (txtGoodsAmount1 != null)
          txtGoodsAmount1.LostFocus -= eventHandler;
        this._txtGoodsAmount = value;
        TextBox txtGoodsAmount2 = this._txtGoodsAmount;
        if (txtGoodsAmount2 == null)
          return;
        txtGoodsAmount2.LostFocus += eventHandler;
      }
    }

    internal virtual Label lblGoodsValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplierInvoiceRefNew { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSupplierRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSupplierGoods { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblGoodsTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOrderTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOrderTotalLabel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cboReadySageNew { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUpdateSupplierInvoice
    {
      get
      {
        return this._btnUpdateSupplierInvoice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdateSupplierInvoice_Click);
        Button updateSupplierInvoice1 = this._btnUpdateSupplierInvoice;
        if (updateSupplierInvoice1 != null)
          updateSupplierInvoice1.Click -= eventHandler;
        this._btnUpdateSupplierInvoice = value;
        Button updateSupplierInvoice2 = this._btnUpdateSupplierInvoice;
        if (updateSupplierInvoice2 == null)
          return;
        updateSupplierInvoice2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeleteSupplierInvoice
    {
      get
      {
        return this._btnDeleteSupplierInvoice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteSupplierInvoice_Click);
        Button deleteSupplierInvoice1 = this._btnDeleteSupplierInvoice;
        if (deleteSupplierInvoice1 != null)
          deleteSupplierInvoice1.Click -= eventHandler;
        this._btnDeleteSupplierInvoice = value;
        Button deleteSupplierInvoice2 = this._btnDeleteSupplierInvoice;
        if (deleteSupplierInvoice2 == null)
          return;
        deleteSupplierInvoice2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkRevertStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage TabPage1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCreditDelete
    {
      get
      {
        return this._btnCreditDelete;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteCredit_Click);
        Button btnCreditDelete1 = this._btnCreditDelete;
        if (btnCreditDelete1 != null)
          btnCreditDelete1.Click -= eventHandler;
        this._btnCreditDelete = value;
        Button btnCreditDelete2 = this._btnCreditDelete;
        if (btnCreditDelete2 == null)
          return;
        btnCreditDelete2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtCreditTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCreditVAT
    {
      get
      {
        return this._txtCreditVAT;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtCreditVAT__LostFocus);
        TextBox txtCreditVat1 = this._txtCreditVAT;
        if (txtCreditVat1 != null)
          txtCreditVat1.LostFocus -= eventHandler;
        this._txtCreditVAT = value;
        TextBox txtCreditVat2 = this._txtCreditVAT;
        if (txtCreditVat2 == null)
          return;
        txtCreditVat2.LostFocus += eventHandler;
      }
    }

    internal virtual TextBox txtCreditNominal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCreditGoods
    {
      get
      {
        return this._txtCreditGoods;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtCreditAmount_TextChanged);
        TextBox txtCreditGoods1 = this._txtCreditGoods;
        if (txtCreditGoods1 != null)
          txtCreditGoods1.LostFocus -= eventHandler;
        this._txtCreditGoods = value;
        TextBox txtCreditGoods2 = this._txtCreditGoods;
        if (txtCreditGoods2 == null)
          return;
        txtCreditGoods2.LostFocus += eventHandler;
      }
    }

    internal virtual ComboBox cboCreditTax
    {
      get
      {
        return this._cboCreditTax;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboCreditTaxCode_SelectedIndexChanged);
        ComboBox cboCreditTax1 = this._cboCreditTax;
        if (cboCreditTax1 != null)
          cboCreditTax1.SelectedIndexChanged -= eventHandler;
        this._cboCreditTax = value;
        ComboBox cboCreditTax2 = this._cboCreditTax;
        if (cboCreditTax2 == null)
          return;
        cboCreditTax2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCreditRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label23 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCreditAdd
    {
      get
      {
        return this._btnCreditAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCreditAdd_Click);
        Button btnCreditAdd1 = this._btnCreditAdd;
        if (btnCreditAdd1 != null)
          btnCreditAdd1.Click -= eventHandler;
        this._btnCreditAdd = value;
        Button btnCreditAdd2 = this._btnCreditAdd;
        if (btnCreditAdd2 == null)
          return;
        btnCreditAdd2.Click += eventHandler;
      }
    }

    internal virtual DataGridView dgCredits
    {
      get
      {
        return this._dgCredits;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DataGridViewCellEventHandler cellEventHandler = new DataGridViewCellEventHandler(this.dgCredits_CellClick);
        DataGridView dgCredits1 = this._dgCredits;
        if (dgCredits1 != null)
          dgCredits1.CellClick -= cellEventHandler;
        this._dgCredits = value;
        DataGridView dgCredits2 = this._dgCredits;
        if (dgCredits2 == null)
          return;
        dgCredits2.CellClick += cellEventHandler;
      }
    }

    internal virtual DateTimePicker dtpCreditDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCredits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label25 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOrderBalance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblOrderBalanceLabel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox CheckBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCreditExRef { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label21 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual NumericUpDown nudItemQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUpdateOrderRef
    {
      get
      {
        return this._btnUpdateOrderRef;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdateOrderRef_Click);
        Button btnUpdateOrderRef1 = this._btnUpdateOrderRef;
        if (btnUpdateOrderRef1 != null)
          btnUpdateOrderRef1.Click -= eventHandler;
        this._btnUpdateOrderRef = value;
        Button btnUpdateOrderRef2 = this._btnUpdateOrderRef;
        if (btnUpdateOrderRef2 == null)
          return;
        btnUpdateOrderRef2.Click += eventHandler;
      }
    }

    internal virtual Button btnApproveOrder
    {
      get
      {
        return this._btnApproveOrder;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnApproveOrder_Click);
        Button btnApproveOrder1 = this._btnApproveOrder;
        if (btnApproveOrder1 != null)
          btnApproveOrder1.Click -= eventHandler;
        this._btnApproveOrder = value;
        Button btnApproveOrder2 = this._btnApproveOrder;
        if (btnApproveOrder2 == null)
          return;
        btnApproveOrder2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgParts
    {
      get
      {
        return this._dgParts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgParts_DoubleClick);
        EventHandler eventHandler2 = new EventHandler(this.dgParts_Click);
        EventHandler eventHandler3 = new EventHandler(this.dgParts_Click);
        DataGrid dgParts1 = this._dgParts;
        if (dgParts1 != null)
        {
          dgParts1.DoubleClick -= eventHandler1;
          dgParts1.Click -= eventHandler2;
          dgParts1.CurrentCellChanged -= eventHandler3;
        }
        this._dgParts = value;
        DataGrid dgParts2 = this._dgParts;
        if (dgParts2 == null)
          return;
        dgParts2.DoubleClick += eventHandler1;
        dgParts2.Click += eventHandler2;
        dgParts2.CurrentCellChanged += eventHandler3;
      }
    }

    internal virtual Button btnRelatedJob
    {
      get
      {
        return this._btnRelatedJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRelatedJob_Click);
        Button btnRelatedJob1 = this._btnRelatedJob;
        if (btnRelatedJob1 != null)
          btnRelatedJob1.Click -= eventHandler;
        this._btnRelatedJob = value;
        Button btnRelatedJob2 = this._btnRelatedJob;
        if (btnRelatedJob2 == null)
          return;
        btnRelatedJob2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      this.grpOrder = new GroupBox();
      this.btnApproveOrder = new Button();
      this.btnUpdateOrderRef = new Button();
      this.cboDept = new ComboBox();
      this.lblOrderBalance = new Label();
      this.lblOrderBalanceLabel = new Label();
      this.chkRevertStatus = new CheckBox();
      this.lblOrderTotalLabel = new Label();
      this.lblOrderTotal = new Label();
      this.chkDoNotConsolidate = new CheckBox();
      this.chkDeadlineNA = new CheckBox();
      this.dtpDeliveryDeadline = new DateTimePicker();
      this.Label6 = new Label();
      this.cboOrderStatus = new ComboBox();
      this.Label19 = new Label();
      this.dtpDatePlaced = new DateTimePicker();
      this.lblDatePlaced = new Label();
      this.txtOrderReference = new TextBox();
      this.lblOrderReference = new Label();
      this.tcOrderDetails = new TabControl();
      this.tabDetails = new TabPage();
      this.btnRelatedJob = new Button();
      this.pnlDetails = new Panel();
      this.lblOrderTypeID = new Label();
      this.cboOrderTypeID = new ComboBox();
      this.btnCharges = new Button();
      this.tabParts = new TabPage();
      this.grpPartSearch = new GroupBox();
      this.btnAddNewPart = new Button();
      this.cboPartLocation = new ComboBox();
      this.btnPartSearch = new Button();
      this.txtPartSearch = new TextBox();
      this.grpAvailableParts = new GroupBox();
      this.btnCreatePartRequest = new Button();
      this.Label7 = new Label();
      this.txtPartBuyPrice = new TextBox();
      this.Label3 = new Label();
      this.txtPartQuantity = new TextBox();
      this.btnAddPart = new Button();
      this.tabProducts = new TabPage();
      this.grpProductsAvailable = new GroupBox();
      this.btnCreateProductPriceRequest = new Button();
      this.txtProductSellPrice = new TextBox();
      this.Label5 = new Label();
      this.txtProductBuyPrice = new TextBox();
      this.Label4 = new Label();
      this.Label1 = new Label();
      this.txtProductQuantity = new TextBox();
      this.dgProduct = new DataGrid();
      this.btnAddProduct = new Button();
      this.grpProductSearch = new GroupBox();
      this.btnAddNewProduct = new Button();
      this.cboProductLocation = new ComboBox();
      this.btnProductSearch = new Button();
      this.txtProductSearch = new TextBox();
      this.tabItemsIncluded = new TabPage();
      this.GroupBox3 = new GroupBox();
      this.nudItemQty = new NumericUpDown();
      this.btnEngineerReceived = new Button();
      this.btnReceiveAll = new Button();
      this.lblItemQty = new Label();
      this.btnItemQtyUpdate = new Button();
      this.dgItemsIncluded = new DataGrid();
      this.tabPartPriceReq = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.btnUpdatePartPriceRequest = new Button();
      this.dgPriceRequests = new DataGrid();
      this.tabDocuments = new TabPage();
      this.pnlDocuments = new Panel();
      this.btnEmail = new Button();
      this.cboPrintType = new ComboBox();
      this.btnPrint = new Button();
      this.Label8 = new Label();
      this.tabInvoices = new TabPage();
      this.grpReceivedInvoices = new GroupBox();
      this.btnDeleteSupplierInvoice = new Button();
      this.btnUpdateSupplierInvoice = new Button();
      this.txtTotalAmount = new TextBox();
      this.lblTotalValue = new Label();
      this.txtVATAmount = new TextBox();
      this.txtNominalCodeNew = new TextBox();
      this.Label16 = new Label();
      this.lblVatValue = new Label();
      this.txtGoodsAmount = new TextBox();
      this.cboInvoiceTaxCodeNew = new ComboBox();
      this.txtExtraReferenceNew = new TextBox();
      this.Label13 = new Label();
      this.lblGoodsValue = new Label();
      this.Label15 = new Label();
      this.lblInvoiceDate = new Label();
      this.txtSupplierInvoiceRefNew = new TextBox();
      this.lblSupplierRef = new Label();
      this.btnAddSupplierInvoice = new Button();
      this.dgvReceivedInvoices = new DataGridView();
      this.dtpSupplierInvoiceDateNew = new DateTimePicker();
      this.cboReadySageNew = new CheckBox();
      this.TabPage1 = new TabPage();
      this.GroupBox4 = new GroupBox();
      this.Button1 = new Button();
      this.CheckBox1 = new CheckBox();
      this.txtCreditExRef = new TextBox();
      this.Label21 = new Label();
      this.btnCreditDelete = new Button();
      this.txtCreditTotal = new TextBox();
      this.Label9 = new Label();
      this.txtCreditVAT = new TextBox();
      this.txtCreditNominal = new TextBox();
      this.Label10 = new Label();
      this.Label14 = new Label();
      this.txtCreditGoods = new TextBox();
      this.cboCreditTax = new ComboBox();
      this.Label18 = new Label();
      this.Label20 = new Label();
      this.txtCreditRef = new TextBox();
      this.Label23 = new Label();
      this.btnCreditAdd = new Button();
      this.dgCredits = new DataGridView();
      this.dtpCreditDate = new DateTimePicker();
      this.lblOrderStatus = new Label();
      this.GroupBox1 = new GroupBox();
      this.lblCredits = new Label();
      this.Label25 = new Label();
      this.lblSupplierGoods = new Label();
      this.lblGoodsTotal = new Label();
      this.Label17 = new Label();
      this.FSMDataSetBindingSource = new BindingSource(this.components);
      this.FSMDataSet = new FSMDataSet();
      this.dgParts = new DataGrid();
      this.grpOrder.SuspendLayout();
      this.tcOrderDetails.SuspendLayout();
      this.tabDetails.SuspendLayout();
      this.tabParts.SuspendLayout();
      this.grpPartSearch.SuspendLayout();
      this.grpAvailableParts.SuspendLayout();
      this.tabProducts.SuspendLayout();
      this.grpProductsAvailable.SuspendLayout();
      this.dgProduct.BeginInit();
      this.grpProductSearch.SuspendLayout();
      this.tabItemsIncluded.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.nudItemQty.BeginInit();
      this.dgItemsIncluded.BeginInit();
      this.tabPartPriceReq.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.dgPriceRequests.BeginInit();
      this.tabDocuments.SuspendLayout();
      this.tabInvoices.SuspendLayout();
      this.grpReceivedInvoices.SuspendLayout();
      ((ISupportInitialize) this.dgvReceivedInvoices).BeginInit();
      this.TabPage1.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      ((ISupportInitialize) this.dgCredits).BeginInit();
      this.GroupBox1.SuspendLayout();
      ((ISupportInitialize) this.FSMDataSetBindingSource).BeginInit();
      this.FSMDataSet.BeginInit();
      this.dgParts.BeginInit();
      this.SuspendLayout();
      this.grpOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpOrder.Controls.Add((Control) this.btnApproveOrder);
      this.grpOrder.Controls.Add((Control) this.btnUpdateOrderRef);
      this.grpOrder.Controls.Add((Control) this.cboDept);
      this.grpOrder.Controls.Add((Control) this.lblOrderBalance);
      this.grpOrder.Controls.Add((Control) this.lblOrderBalanceLabel);
      this.grpOrder.Controls.Add((Control) this.chkRevertStatus);
      this.grpOrder.Controls.Add((Control) this.lblOrderTotalLabel);
      this.grpOrder.Controls.Add((Control) this.lblOrderTotal);
      this.grpOrder.Controls.Add((Control) this.chkDoNotConsolidate);
      this.grpOrder.Controls.Add((Control) this.chkDeadlineNA);
      this.grpOrder.Controls.Add((Control) this.dtpDeliveryDeadline);
      this.grpOrder.Controls.Add((Control) this.Label6);
      this.grpOrder.Controls.Add((Control) this.cboOrderStatus);
      this.grpOrder.Controls.Add((Control) this.Label19);
      this.grpOrder.Controls.Add((Control) this.dtpDatePlaced);
      this.grpOrder.Controls.Add((Control) this.lblDatePlaced);
      this.grpOrder.Controls.Add((Control) this.txtOrderReference);
      this.grpOrder.Controls.Add((Control) this.lblOrderReference);
      this.grpOrder.Controls.Add((Control) this.tcOrderDetails);
      this.grpOrder.Controls.Add((Control) this.lblOrderStatus);
      this.grpOrder.Controls.Add((Control) this.GroupBox1);
      this.grpOrder.Controls.Add((Control) this.Label17);
      this.grpOrder.Location = new System.Drawing.Point(8, 1);
      this.grpOrder.Name = "grpOrder";
      this.grpOrder.Size = new Size(1822, 561);
      this.grpOrder.TabIndex = 1;
      this.grpOrder.TabStop = false;
      this.grpOrder.Text = "Main Details";
      this.btnApproveOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnApproveOrder.Location = new System.Drawing.Point(1421, 17);
      this.btnApproveOrder.Name = "btnApproveOrder";
      this.btnApproveOrder.Size = new Size(120, 23);
      this.btnApproveOrder.TabIndex = 126;
      this.btnApproveOrder.Text = "Approve Order";
      this.btnApproveOrder.Visible = false;
      this.btnUpdateOrderRef.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnUpdateOrderRef.Location = new System.Drawing.Point(1230, 17);
      this.btnUpdateOrderRef.Name = "btnUpdateOrderRef";
      this.btnUpdateOrderRef.Size = new Size(120, 23);
      this.btnUpdateOrderRef.TabIndex = 125;
      this.btnUpdateOrderRef.Text = "Change Order Ref";
      this.btnUpdateOrderRef.Visible = false;
      this.cboDept.FormattingEnabled = true;
      this.cboDept.Location = new System.Drawing.Point(80, 94);
      this.cboDept.Name = "cboDept";
      this.cboDept.Size = new Size(170, 21);
      this.cboDept.TabIndex = 124;
      this.lblOrderBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblOrderBalance.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblOrderBalance.Location = new System.Drawing.Point(1685, 107);
      this.lblOrderBalance.Name = "lblOrderBalance";
      this.lblOrderBalance.Size = new Size(122, 15);
      this.lblOrderBalance.TabIndex = 84;
      this.lblOrderBalance.Text = "£0.00";
      this.lblOrderBalance.TextAlign = ContentAlignment.MiddleRight;
      this.lblOrderBalanceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblOrderBalanceLabel.AutoSize = true;
      this.lblOrderBalanceLabel.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblOrderBalanceLabel.Location = new System.Drawing.Point(1563, 108);
      this.lblOrderBalanceLabel.Name = "lblOrderBalanceLabel";
      this.lblOrderBalanceLabel.Size = new Size(96, 13);
      this.lblOrderBalanceLabel.TabIndex = 85;
      this.lblOrderBalanceLabel.Text = "Unallocated : ";
      this.lblOrderBalanceLabel.TextAlign = ContentAlignment.TopRight;
      this.chkRevertStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkRevertStatus.AutoSize = true;
      this.chkRevertStatus.Location = new System.Drawing.Point(1230, 97);
      this.chkRevertStatus.Name = "chkRevertStatus";
      this.chkRevertStatus.Size = new Size(209, 17);
      this.chkRevertStatus.TabIndex = 78;
      this.chkRevertStatus.Text = "Revert to Awaiting Confirmation";
      this.chkRevertStatus.UseVisualStyleBackColor = true;
      this.chkRevertStatus.Visible = false;
      this.lblOrderTotalLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblOrderTotalLabel.AutoSize = true;
      this.lblOrderTotalLabel.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblOrderTotalLabel.Location = new System.Drawing.Point(1559, 13);
      this.lblOrderTotalLabel.Name = "lblOrderTotalLabel";
      this.lblOrderTotalLabel.Size = new Size(157, 13);
      this.lblOrderTotalLabel.TabIndex = 77;
      this.lblOrderTotalLabel.Text = "Purchase Order Total : ";
      this.lblOrderTotalLabel.TextAlign = ContentAlignment.TopRight;
      this.lblOrderTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblOrderTotal.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblOrderTotal.Location = new System.Drawing.Point(1731, 12);
      this.lblOrderTotal.Name = "lblOrderTotal";
      this.lblOrderTotal.Size = new Size(75, 15);
      this.lblOrderTotal.TabIndex = 76;
      this.lblOrderTotal.Text = "£0.00";
      this.lblOrderTotal.TextAlign = ContentAlignment.MiddleRight;
      this.chkDoNotConsolidate.AutoSize = true;
      this.chkDoNotConsolidate.Location = new System.Drawing.Point(256, 97);
      this.chkDoNotConsolidate.Name = "chkDoNotConsolidate";
      this.chkDoNotConsolidate.Size = new Size(136, 17);
      this.chkDoNotConsolidate.TabIndex = 69;
      this.chkDoNotConsolidate.Text = "Do Not Consolidate";
      this.chkDoNotConsolidate.UseVisualStyleBackColor = true;
      this.chkDoNotConsolidate.Visible = false;
      this.chkDeadlineNA.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkDeadlineNA.Location = new System.Drawing.Point(1347, 66);
      this.chkDeadlineNA.Name = "chkDeadlineNA";
      this.chkDeadlineNA.Size = new Size(48, 24);
      this.chkDeadlineNA.TabIndex = 4;
      this.chkDeadlineNA.Text = "N/A";
      this.dtpDeliveryDeadline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpDeliveryDeadline.Location = new System.Drawing.Point(1398, 66);
      this.dtpDeliveryDeadline.Name = "dtpDeliveryDeadline";
      this.dtpDeliveryDeadline.Size = new Size(144, 21);
      this.dtpDeliveryDeadline.TabIndex = 5;
      this.dtpDeliveryDeadline.Tag = (object) "Order.DatePlaced";
      this.Label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label6.Location = new System.Drawing.Point(1225, 70);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(114, 23);
      this.Label6.TabIndex = 42;
      this.Label6.Text = "Delivery Deadline";
      this.cboOrderStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboOrderStatus.Location = new System.Drawing.Point(80, 43);
      this.cboOrderStatus.Name = "cboOrderStatus";
      this.cboOrderStatus.Size = new Size(1142, 21);
      this.cboOrderStatus.TabIndex = 2;
      this.Label19.Location = new System.Drawing.Point(6, 43);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(48, 23);
      this.Label19.TabIndex = 33;
      this.Label19.Text = "Status";
      this.dtpDatePlaced.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dtpDatePlaced.Location = new System.Drawing.Point(80, 67);
      this.dtpDatePlaced.Name = "dtpDatePlaced";
      this.dtpDatePlaced.Size = new Size(1142, 21);
      this.dtpDatePlaced.TabIndex = 3;
      this.dtpDatePlaced.Tag = (object) "Order.DatePlaced";
      this.lblDatePlaced.Location = new System.Drawing.Point(6, 67);
      this.lblDatePlaced.Name = "lblDatePlaced";
      this.lblDatePlaced.Size = new Size(79, 20);
      this.lblDatePlaced.TabIndex = 31;
      this.lblDatePlaced.Text = "Date Placed";
      this.txtOrderReference.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtOrderReference.Location = new System.Drawing.Point(80, 19);
      this.txtOrderReference.MaxLength = 100;
      this.txtOrderReference.Name = "txtOrderReference";
      this.txtOrderReference.ReadOnly = true;
      this.txtOrderReference.Size = new Size(1142, 21);
      this.txtOrderReference.TabIndex = 1;
      this.txtOrderReference.Tag = (object) "Order.OrderReference";
      this.txtOrderReference.Visible = false;
      this.lblOrderReference.Location = new System.Drawing.Point(6, 19);
      this.lblOrderReference.Name = "lblOrderReference";
      this.lblOrderReference.Size = new Size(66, 20);
      this.lblOrderReference.TabIndex = 31;
      this.lblOrderReference.Text = "Order Ref";
      this.tcOrderDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcOrderDetails.Controls.Add((Control) this.tabDetails);
      this.tcOrderDetails.Controls.Add((Control) this.tabParts);
      this.tcOrderDetails.Controls.Add((Control) this.tabProducts);
      this.tcOrderDetails.Controls.Add((Control) this.tabItemsIncluded);
      this.tcOrderDetails.Controls.Add((Control) this.tabPartPriceReq);
      this.tcOrderDetails.Controls.Add((Control) this.tabDocuments);
      this.tcOrderDetails.Controls.Add((Control) this.tabInvoices);
      this.tcOrderDetails.Controls.Add((Control) this.TabPage1);
      this.tcOrderDetails.Location = new System.Drawing.Point(11, 156);
      this.tcOrderDetails.Name = "tcOrderDetails";
      this.tcOrderDetails.SelectedIndex = 0;
      this.tcOrderDetails.Size = new Size(1804, 399);
      this.tcOrderDetails.TabIndex = 6;
      this.tabDetails.Controls.Add((Control) this.btnRelatedJob);
      this.tabDetails.Controls.Add((Control) this.pnlDetails);
      this.tabDetails.Controls.Add((Control) this.lblOrderTypeID);
      this.tabDetails.Controls.Add((Control) this.cboOrderTypeID);
      this.tabDetails.Controls.Add((Control) this.btnCharges);
      this.tabDetails.Location = new System.Drawing.Point(4, 22);
      this.tabDetails.Name = "tabDetails";
      this.tabDetails.Size = new Size(1796, 373);
      this.tabDetails.TabIndex = 0;
      this.tabDetails.Text = "Order Details";
      this.btnRelatedJob.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnRelatedJob.Enabled = false;
      this.btnRelatedJob.Location = new System.Drawing.Point(1491, 7);
      this.btnRelatedJob.Name = "btnRelatedJob";
      this.btnRelatedJob.Size = new Size(120, 23);
      this.btnRelatedJob.TabIndex = 32;
      this.btnRelatedJob.Text = "View Related Job";
      this.pnlDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlDetails.Location = new System.Drawing.Point(0, 40);
      this.pnlDetails.Name = "pnlDetails";
      this.pnlDetails.Size = new Size(1793, 324);
      this.pnlDetails.TabIndex = 9;
      this.lblOrderTypeID.Location = new System.Drawing.Point(8, 8);
      this.lblOrderTypeID.Name = "lblOrderTypeID";
      this.lblOrderTypeID.Size = new Size(64, 20);
      this.lblOrderTypeID.TabIndex = 31;
      this.lblOrderTypeID.Text = "Order For";
      this.cboOrderTypeID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboOrderTypeID.Cursor = Cursors.Hand;
      this.cboOrderTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboOrderTypeID.Location = new System.Drawing.Point(96, 8);
      this.cboOrderTypeID.Name = "cboOrderTypeID";
      this.cboOrderTypeID.Size = new Size(1387, 21);
      this.cboOrderTypeID.TabIndex = 7;
      this.cboOrderTypeID.Tag = (object) "Order.OrderTypeID";
      this.btnCharges.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCharges.Location = new System.Drawing.Point(1617, 7);
      this.btnCharges.Name = "btnCharges";
      this.btnCharges.Size = new Size(168, 23);
      this.btnCharges.TabIndex = 8;
      this.btnCharges.Text = "Manage Additional Charges";
      this.tabParts.Controls.Add((Control) this.grpPartSearch);
      this.tabParts.Controls.Add((Control) this.grpAvailableParts);
      this.tabParts.Location = new System.Drawing.Point(4, 22);
      this.tabParts.Name = "tabParts";
      this.tabParts.Size = new Size(1796, 373);
      this.tabParts.TabIndex = 2;
      this.tabParts.Text = "Parts Available";
      this.grpPartSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpPartSearch.Controls.Add((Control) this.btnAddNewPart);
      this.grpPartSearch.Controls.Add((Control) this.cboPartLocation);
      this.grpPartSearch.Controls.Add((Control) this.btnPartSearch);
      this.grpPartSearch.Controls.Add((Control) this.txtPartSearch);
      this.grpPartSearch.Location = new System.Drawing.Point(8, 8);
      this.grpPartSearch.Name = "grpPartSearch";
      this.grpPartSearch.Size = new Size(1785, 56);
      this.grpPartSearch.TabIndex = 13;
      this.grpPartSearch.TabStop = false;
      this.grpPartSearch.Text = "Part Search From";
      this.btnAddNewPart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddNewPart.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAddNewPart.Location = new System.Drawing.Point(1708, 24);
      this.btnAddNewPart.Name = "btnAddNewPart";
      this.btnAddNewPart.Size = new Size(64, 22);
      this.btnAddNewPart.TabIndex = 4;
      this.btnAddNewPart.Text = "New Part";
      this.cboPartLocation.Location = new System.Drawing.Point(8, 24);
      this.cboPartLocation.Name = "cboPartLocation";
      this.cboPartLocation.Size = new Size(152, 21);
      this.cboPartLocation.TabIndex = 1;
      this.btnPartSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnPartSearch.Enabled = false;
      this.btnPartSearch.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnPartSearch.Location = new System.Drawing.Point(1635, 23);
      this.btnPartSearch.Name = "btnPartSearch";
      this.btnPartSearch.Size = new Size(64, 22);
      this.btnPartSearch.TabIndex = 3;
      this.btnPartSearch.Text = "Find";
      this.txtPartSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPartSearch.Location = new System.Drawing.Point(168, 24);
      this.txtPartSearch.Name = "txtPartSearch";
      this.txtPartSearch.Size = new Size(1460, 21);
      this.txtPartSearch.TabIndex = 2;
      this.grpAvailableParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAvailableParts.Controls.Add((Control) this.btnCreatePartRequest);
      this.grpAvailableParts.Controls.Add((Control) this.Label7);
      this.grpAvailableParts.Controls.Add((Control) this.txtPartBuyPrice);
      this.grpAvailableParts.Controls.Add((Control) this.Label3);
      this.grpAvailableParts.Controls.Add((Control) this.txtPartQuantity);
      this.grpAvailableParts.Controls.Add((Control) this.dgParts);
      this.grpAvailableParts.Controls.Add((Control) this.btnAddPart);
      this.grpAvailableParts.Location = new System.Drawing.Point(8, 72);
      this.grpAvailableParts.Name = "grpAvailableParts";
      this.grpAvailableParts.Size = new Size(1785, 297);
      this.grpAvailableParts.TabIndex = 14;
      this.grpAvailableParts.TabStop = false;
      this.grpAvailableParts.Text = "Available Parts && Packs";
      this.btnCreatePartRequest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.btnCreatePartRequest.Location = new System.Drawing.Point(935, 263);
      this.btnCreatePartRequest.Name = "btnCreatePartRequest";
      this.btnCreatePartRequest.Size = new Size(837, 24);
      this.btnCreatePartRequest.TabIndex = 10;
      this.btnCreatePartRequest.Text = "Part Price Request";
      this.Label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label7.Location = new System.Drawing.Point(8, 269);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(40, 13);
      this.Label7.TabIndex = 23;
      this.Label7.Text = "Qty";
      this.txtPartBuyPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtPartBuyPrice.Location = new System.Drawing.Point(248, 265);
      this.txtPartBuyPrice.Name = "txtPartBuyPrice";
      this.txtPartBuyPrice.Size = new Size(112, 21);
      this.txtPartBuyPrice.TabIndex = 7;
      this.Label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label3.Location = new System.Drawing.Point(176, 269);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(64, 13);
      this.Label3.TabIndex = 14;
      this.Label3.Text = "Buy Price";
      this.txtPartQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtPartQuantity.Location = new System.Drawing.Point(56, 265);
      this.txtPartQuantity.Name = "txtPartQuantity";
      this.txtPartQuantity.Size = new Size(112, 21);
      this.txtPartQuantity.TabIndex = 6;
      this.btnAddPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddPart.Location = new System.Drawing.Point(378, 263);
      this.btnAddPart.Name = "btnAddPart";
      this.btnAddPart.Size = new Size(56, 24);
      this.btnAddPart.TabIndex = 9;
      this.btnAddPart.Text = "Add";
      this.tabProducts.Controls.Add((Control) this.grpProductsAvailable);
      this.tabProducts.Controls.Add((Control) this.grpProductSearch);
      this.tabProducts.Location = new System.Drawing.Point(4, 22);
      this.tabProducts.Name = "tabProducts";
      this.tabProducts.Size = new Size(1796, 373);
      this.tabProducts.TabIndex = 1;
      this.tabProducts.Text = "Products Available";
      this.grpProductsAvailable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpProductsAvailable.Controls.Add((Control) this.btnCreateProductPriceRequest);
      this.grpProductsAvailable.Controls.Add((Control) this.txtProductSellPrice);
      this.grpProductsAvailable.Controls.Add((Control) this.Label5);
      this.grpProductsAvailable.Controls.Add((Control) this.txtProductBuyPrice);
      this.grpProductsAvailable.Controls.Add((Control) this.Label4);
      this.grpProductsAvailable.Controls.Add((Control) this.Label1);
      this.grpProductsAvailable.Controls.Add((Control) this.txtProductQuantity);
      this.grpProductsAvailable.Controls.Add((Control) this.dgProduct);
      this.grpProductsAvailable.Controls.Add((Control) this.btnAddProduct);
      this.grpProductsAvailable.Location = new System.Drawing.Point(8, 72);
      this.grpProductsAvailable.Name = "grpProductsAvailable";
      this.grpProductsAvailable.Size = new Size(1785, 298);
      this.grpProductsAvailable.TabIndex = 10;
      this.grpProductsAvailable.TabStop = false;
      this.grpProductsAvailable.Text = "Available Products ";
      this.btnCreateProductPriceRequest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.btnCreateProductPriceRequest.Location = new System.Drawing.Point(616, 263);
      this.btnCreateProductPriceRequest.Name = "btnCreateProductPriceRequest";
      this.btnCreateProductPriceRequest.Size = new Size(1161, 24);
      this.btnCreateProductPriceRequest.TabIndex = 10;
      this.btnCreateProductPriceRequest.Text = "Product Price Request";
      this.txtProductSellPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtProductSellPrice.Location = new System.Drawing.Point(432, 265);
      this.txtProductSellPrice.Name = "txtProductSellPrice";
      this.txtProductSellPrice.Size = new Size(112, 21);
      this.txtProductSellPrice.TabIndex = 8;
      this.Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label5.Location = new System.Drawing.Point(368, 269);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(64, 13);
      this.Label5.TabIndex = 18;
      this.Label5.Text = "Sell Price";
      this.txtProductBuyPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtProductBuyPrice.Location = new System.Drawing.Point(232, 265);
      this.txtProductBuyPrice.Name = "txtProductBuyPrice";
      this.txtProductBuyPrice.Size = new Size(112, 21);
      this.txtProductBuyPrice.TabIndex = 7;
      this.Label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label4.Location = new System.Drawing.Point(168, 269);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 13);
      this.Label4.TabIndex = 16;
      this.Label4.Text = "Buy Price";
      this.Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label1.Location = new System.Drawing.Point(8, 269);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(40, 13);
      this.Label1.TabIndex = 15;
      this.Label1.Text = "Qty";
      this.txtProductQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtProductQuantity.Location = new System.Drawing.Point(48, 265);
      this.txtProductQuantity.Name = "txtProductQuantity";
      this.txtProductQuantity.Size = new Size(112, 21);
      this.txtProductQuantity.TabIndex = 6;
      this.dgProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgProduct.DataMember = "";
      this.dgProduct.HeaderForeColor = SystemColors.ControlText;
      this.dgProduct.Location = new System.Drawing.Point(8, 20);
      this.dgProduct.Name = "dgProduct";
      this.dgProduct.Size = new Size(1769, 235);
      this.dgProduct.TabIndex = 5;
      this.btnAddProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddProduct.Location = new System.Drawing.Point(552, 263);
      this.btnAddProduct.Name = "btnAddProduct";
      this.btnAddProduct.Size = new Size(56, 24);
      this.btnAddProduct.TabIndex = 9;
      this.btnAddProduct.Text = "Add ";
      this.grpProductSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpProductSearch.Controls.Add((Control) this.btnAddNewProduct);
      this.grpProductSearch.Controls.Add((Control) this.cboProductLocation);
      this.grpProductSearch.Controls.Add((Control) this.btnProductSearch);
      this.grpProductSearch.Controls.Add((Control) this.txtProductSearch);
      this.grpProductSearch.Location = new System.Drawing.Point(8, 8);
      this.grpProductSearch.Name = "grpProductSearch";
      this.grpProductSearch.Size = new Size(1785, 56);
      this.grpProductSearch.TabIndex = 9;
      this.grpProductSearch.TabStop = false;
      this.grpProductSearch.Text = "Product Search From";
      this.btnAddNewProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddNewProduct.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnAddNewProduct.Location = new System.Drawing.Point(1680, 24);
      this.btnAddNewProduct.Name = "btnAddNewProduct";
      this.btnAddNewProduct.Size = new Size(88, 22);
      this.btnAddNewProduct.TabIndex = 4;
      this.btnAddNewProduct.Text = "New Product";
      this.cboProductLocation.Location = new System.Drawing.Point(8, 24);
      this.cboProductLocation.Name = "cboProductLocation";
      this.cboProductLocation.Size = new Size(152, 21);
      this.cboProductLocation.TabIndex = 1;
      this.btnProductSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnProductSearch.Enabled = false;
      this.btnProductSearch.Location = new System.Drawing.Point(1618, 24);
      this.btnProductSearch.Name = "btnProductSearch";
      this.btnProductSearch.Size = new Size(56, 22);
      this.btnProductSearch.TabIndex = 3;
      this.btnProductSearch.Text = "Find";
      this.txtProductSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtProductSearch.Location = new System.Drawing.Point(168, 24);
      this.txtProductSearch.Name = "txtProductSearch";
      this.txtProductSearch.Size = new Size(1444, 21);
      this.txtProductSearch.TabIndex = 2;
      this.tabItemsIncluded.Controls.Add((Control) this.GroupBox3);
      this.tabItemsIncluded.Location = new System.Drawing.Point(4, 22);
      this.tabItemsIncluded.Name = "tabItemsIncluded";
      this.tabItemsIncluded.Size = new Size(1796, 373);
      this.tabItemsIncluded.TabIndex = 8;
      this.tabItemsIncluded.Text = "Items Included";
      this.GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox3.Controls.Add((Control) this.nudItemQty);
      this.GroupBox3.Controls.Add((Control) this.btnEngineerReceived);
      this.GroupBox3.Controls.Add((Control) this.btnReceiveAll);
      this.GroupBox3.Controls.Add((Control) this.lblItemQty);
      this.GroupBox3.Controls.Add((Control) this.btnItemQtyUpdate);
      this.GroupBox3.Controls.Add((Control) this.dgItemsIncluded);
      this.GroupBox3.Location = new System.Drawing.Point(8, 8);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(1785, 361);
      this.GroupBox3.TabIndex = 0;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Double click to mark as received";
      this.nudItemQty.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.nudItemQty.Location = new System.Drawing.Point(70, 327);
      this.nudItemQty.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.nudItemQty.Name = "nudItemQty";
      this.nudItemQty.Size = new Size(64, 21);
      this.nudItemQty.TabIndex = 30;
      this.nudItemQty.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.btnEngineerReceived.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnEngineerReceived.Location = new System.Drawing.Point(1536, 328);
      this.btnEngineerReceived.Name = "btnEngineerReceived";
      this.btnEngineerReceived.Size = new Size(134, 23);
      this.btnEngineerReceived.TabIndex = 12;
      this.btnEngineerReceived.Text = "Engineer Received";
      this.btnEngineerReceived.UseVisualStyleBackColor = true;
      this.btnReceiveAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnReceiveAll.Location = new System.Drawing.Point(1676, 328);
      this.btnReceiveAll.Name = "btnReceiveAll";
      this.btnReceiveAll.Size = new Size(101, 23);
      this.btnReceiveAll.TabIndex = 11;
      this.btnReceiveAll.Text = "Receive All";
      this.btnReceiveAll.UseVisualStyleBackColor = true;
      this.lblItemQty.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblItemQty.Location = new System.Drawing.Point(8, 329);
      this.lblItemQty.Name = "lblItemQty";
      this.lblItemQty.Size = new Size(56, 21);
      this.lblItemQty.TabIndex = 10;
      this.lblItemQty.Text = "Quantity";
      this.btnItemQtyUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnItemQtyUpdate.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnItemQtyUpdate.Location = new System.Drawing.Point(149, 325);
      this.btnItemQtyUpdate.Name = "btnItemQtyUpdate";
      this.btnItemQtyUpdate.Size = new Size(64, 23);
      this.btnItemQtyUpdate.TabIndex = 3;
      this.btnItemQtyUpdate.Text = "Update";
      this.dgItemsIncluded.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgItemsIncluded.DataMember = "";
      this.dgItemsIncluded.HeaderForeColor = SystemColors.ControlText;
      this.dgItemsIncluded.Location = new System.Drawing.Point(8, 20);
      this.dgItemsIncluded.Name = "dgItemsIncluded";
      this.dgItemsIncluded.Size = new Size(1769, 302);
      this.dgItemsIncluded.TabIndex = 1;
      this.tabPartPriceReq.Controls.Add((Control) this.GroupBox2);
      this.tabPartPriceReq.Location = new System.Drawing.Point(4, 22);
      this.tabPartPriceReq.Name = "tabPartPriceReq";
      this.tabPartPriceReq.Size = new Size(1796, 373);
      this.tabPartPriceReq.TabIndex = 7;
      this.tabPartPriceReq.Text = "Price Requests";
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.btnUpdatePartPriceRequest);
      this.GroupBox2.Controls.Add((Control) this.dgPriceRequests);
      this.GroupBox2.Location = new System.Drawing.Point(8, 8);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(1785, 361);
      this.GroupBox2.TabIndex = 1;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Price requests for parts and products";
      this.btnUpdatePartPriceRequest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnUpdatePartPriceRequest.Location = new System.Drawing.Point(8, 329);
      this.btnUpdatePartPriceRequest.Name = "btnUpdatePartPriceRequest";
      this.btnUpdatePartPriceRequest.Size = new Size(75, 24);
      this.btnUpdatePartPriceRequest.TabIndex = 2;
      this.btnUpdatePartPriceRequest.Text = "Update";
      this.dgPriceRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgPriceRequests.DataMember = "";
      this.dgPriceRequests.HeaderForeColor = SystemColors.ControlText;
      this.dgPriceRequests.Location = new System.Drawing.Point(8, 32);
      this.dgPriceRequests.Name = "dgPriceRequests";
      this.dgPriceRequests.Size = new Size(1769, 287);
      this.dgPriceRequests.TabIndex = 1;
      this.tabDocuments.Controls.Add((Control) this.pnlDocuments);
      this.tabDocuments.Controls.Add((Control) this.btnEmail);
      this.tabDocuments.Controls.Add((Control) this.cboPrintType);
      this.tabDocuments.Controls.Add((Control) this.btnPrint);
      this.tabDocuments.Controls.Add((Control) this.Label8);
      this.tabDocuments.Location = new System.Drawing.Point(4, 22);
      this.tabDocuments.Name = "tabDocuments";
      this.tabDocuments.Size = new Size(1796, 373);
      this.tabDocuments.TabIndex = 9;
      this.tabDocuments.Text = "Documents";
      this.pnlDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlDocuments.Location = new System.Drawing.Point(8, 40);
      this.pnlDocuments.Name = "pnlDocuments";
      this.pnlDocuments.Size = new Size(1785, 324);
      this.pnlDocuments.TabIndex = 4;
      this.btnEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnEmail.Location = new System.Drawing.Point(1329, 8);
      this.btnEmail.Name = "btnEmail";
      this.btnEmail.Size = new Size(104, 23);
      this.btnEmail.TabIndex = 3;
      this.btnEmail.Text = "Send Via Email";
      this.btnEmail.Visible = false;
      this.cboPrintType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboPrintType.Location = new System.Drawing.Point(8, 8);
      this.cboPrintType.Name = "cboPrintType";
      this.cboPrintType.Size = new Size(1225, 21);
      this.cboPrintType.TabIndex = 1;
      this.btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnPrint.Location = new System.Drawing.Point(1241, 8);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new Size(56, 23);
      this.btnPrint.TabIndex = 2;
      this.btnPrint.Text = "Print";
      this.Label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label8.Location = new System.Drawing.Point(1305, 12);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(18, 16);
      this.Label8.TabIndex = 45;
      this.Label8.Text = "or";
      this.Label8.Visible = false;
      this.tabInvoices.Controls.Add((Control) this.grpReceivedInvoices);
      this.tabInvoices.Location = new System.Drawing.Point(4, 22);
      this.tabInvoices.Name = "tabInvoices";
      this.tabInvoices.Size = new Size(1796, 373);
      this.tabInvoices.TabIndex = 10;
      this.tabInvoices.Text = "Supplier Invoices";
      this.grpReceivedInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpReceivedInvoices.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.grpReceivedInvoices.Controls.Add((Control) this.btnDeleteSupplierInvoice);
      this.grpReceivedInvoices.Controls.Add((Control) this.btnUpdateSupplierInvoice);
      this.grpReceivedInvoices.Controls.Add((Control) this.txtTotalAmount);
      this.grpReceivedInvoices.Controls.Add((Control) this.lblTotalValue);
      this.grpReceivedInvoices.Controls.Add((Control) this.txtVATAmount);
      this.grpReceivedInvoices.Controls.Add((Control) this.txtNominalCodeNew);
      this.grpReceivedInvoices.Controls.Add((Control) this.Label16);
      this.grpReceivedInvoices.Controls.Add((Control) this.lblVatValue);
      this.grpReceivedInvoices.Controls.Add((Control) this.txtGoodsAmount);
      this.grpReceivedInvoices.Controls.Add((Control) this.cboInvoiceTaxCodeNew);
      this.grpReceivedInvoices.Controls.Add((Control) this.txtExtraReferenceNew);
      this.grpReceivedInvoices.Controls.Add((Control) this.Label13);
      this.grpReceivedInvoices.Controls.Add((Control) this.lblGoodsValue);
      this.grpReceivedInvoices.Controls.Add((Control) this.Label15);
      this.grpReceivedInvoices.Controls.Add((Control) this.lblInvoiceDate);
      this.grpReceivedInvoices.Controls.Add((Control) this.txtSupplierInvoiceRefNew);
      this.grpReceivedInvoices.Controls.Add((Control) this.lblSupplierRef);
      this.grpReceivedInvoices.Controls.Add((Control) this.btnAddSupplierInvoice);
      this.grpReceivedInvoices.Controls.Add((Control) this.dgvReceivedInvoices);
      this.grpReceivedInvoices.Controls.Add((Control) this.dtpSupplierInvoiceDateNew);
      this.grpReceivedInvoices.Controls.Add((Control) this.cboReadySageNew);
      this.grpReceivedInvoices.Location = new System.Drawing.Point(4, 4);
      this.grpReceivedInvoices.Name = "grpReceivedInvoices";
      this.grpReceivedInvoices.Size = new Size(1789, 366);
      this.grpReceivedInvoices.TabIndex = 0;
      this.grpReceivedInvoices.TabStop = false;
      this.grpReceivedInvoices.Text = "Received Invoices";
      this.btnDeleteSupplierInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeleteSupplierInvoice.Location = new System.Drawing.Point(1603, 339);
      this.btnDeleteSupplierInvoice.Name = "btnDeleteSupplierInvoice";
      this.btnDeleteSupplierInvoice.Size = new Size(56, 24);
      this.btnDeleteSupplierInvoice.TabIndex = 121;
      this.btnDeleteSupplierInvoice.Text = "Delete";
      this.btnDeleteSupplierInvoice.Visible = false;
      this.btnUpdateSupplierInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnUpdateSupplierInvoice.Location = new System.Drawing.Point(1665, 339);
      this.btnUpdateSupplierInvoice.Name = "btnUpdateSupplierInvoice";
      this.btnUpdateSupplierInvoice.Size = new Size(56, 24);
      this.btnUpdateSupplierInvoice.TabIndex = 122;
      this.btnUpdateSupplierInvoice.Text = "Update";
      this.btnUpdateSupplierInvoice.Visible = false;
      this.txtTotalAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtTotalAmount.Location = new System.Drawing.Point(547, 340);
      this.txtTotalAmount.Name = "txtTotalAmount";
      this.txtTotalAmount.Size = new Size(100, 21);
      this.txtTotalAmount.TabIndex = 109;
      this.lblTotalValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblTotalValue.AutoSize = true;
      this.lblTotalValue.Location = new System.Drawing.Point(485, 343);
      this.lblTotalValue.Name = "lblTotalValue";
      this.lblTotalValue.Size = new Size(55, 13);
      this.lblTotalValue.TabIndex = 28;
      this.lblTotalValue.Text = "Total (£)";
      this.txtVATAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtVATAmount.Location = new System.Drawing.Point(379, 340);
      this.txtVATAmount.Name = "txtVATAmount";
      this.txtVATAmount.Size = new Size(100, 21);
      this.txtVATAmount.TabIndex = 108;
      this.txtNominalCodeNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtNominalCodeNew.Location = new System.Drawing.Point(633, 311);
      this.txtNominalCodeNew.MaxLength = 100;
      this.txtNominalCodeNew.Name = "txtNominalCodeNew";
      this.txtNominalCodeNew.Size = new Size(70, 21);
      this.txtNominalCodeNew.TabIndex = 105;
      this.txtNominalCodeNew.Tag = (object) "Order.SupplierInvoiceReference";
      this.Label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label16.Location = new System.Drawing.Point(568, 314);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(70, 20);
      this.Label16.TabIndex = 65;
      this.Label16.Text = "Nominal";
      this.lblVatValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblVatValue.AutoSize = true;
      this.lblVatValue.Location = new System.Drawing.Point(322, 343);
      this.lblVatValue.Name = "lblVatValue";
      this.lblVatValue.Size = new Size(50, 13);
      this.lblVatValue.TabIndex = 26;
      this.lblVatValue.Text = "VAT (£)";
      this.txtGoodsAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtGoodsAmount.Location = new System.Drawing.Point(76, 340);
      this.txtGoodsAmount.Name = "txtGoodsAmount";
      this.txtGoodsAmount.Size = new Size(100, 21);
      this.txtGoodsAmount.TabIndex = 106;
      this.cboInvoiceTaxCodeNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cboInvoiceTaxCodeNew.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInvoiceTaxCodeNew.Location = new System.Drawing.Point(258, 340);
      this.cboInvoiceTaxCodeNew.Name = "cboInvoiceTaxCodeNew";
      this.cboInvoiceTaxCodeNew.Size = new Size(58, 21);
      this.cboInvoiceTaxCodeNew.TabIndex = 107;
      this.txtExtraReferenceNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtExtraReferenceNew.Location = new System.Drawing.Point(493, 311);
      this.txtExtraReferenceNew.MaxLength = 100;
      this.txtExtraReferenceNew.Name = "txtExtraReferenceNew";
      this.txtExtraReferenceNew.Size = new Size(70, 21);
      this.txtExtraReferenceNew.TabIndex = 104;
      this.txtExtraReferenceNew.Tag = (object) "Order.SupplierInvoiceReference";
      this.Label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label13.Location = new System.Drawing.Point(182, 343);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(70, 20);
      this.Label13.TabIndex = 59;
      this.Label13.Text = "Tax Code";
      this.lblGoodsValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblGoodsValue.AutoSize = true;
      this.lblGoodsValue.Location = new System.Drawing.Point(6, 343);
      this.lblGoodsValue.Name = "lblGoodsValue";
      this.lblGoodsValue.Size = new Size(64, 13);
      this.lblGoodsValue.TabIndex = 24;
      this.lblGoodsValue.Text = "Goods (£)";
      this.Label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label15.Location = new System.Drawing.Point(435, 314);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(56, 20);
      this.Label15.TabIndex = 63;
      this.Label15.Text = "Ex Ref.";
      this.lblInvoiceDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblInvoiceDate.AutoSize = true;
      this.lblInvoiceDate.Location = new System.Drawing.Point(6, 314);
      this.lblInvoiceDate.Name = "lblInvoiceDate";
      this.lblInvoiceDate.Size = new Size(80, 13);
      this.lblInvoiceDate.TabIndex = 1;
      this.lblInvoiceDate.Text = "Invoice Date";
      this.txtSupplierInvoiceRefNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtSupplierInvoiceRefNew.Location = new System.Drawing.Point(329, 311);
      this.txtSupplierInvoiceRefNew.Name = "txtSupplierInvoiceRefNew";
      this.txtSupplierInvoiceRefNew.Size = new Size(100, 21);
      this.txtSupplierInvoiceRefNew.TabIndex = 103;
      this.lblSupplierRef.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblSupplierRef.AutoSize = true;
      this.lblSupplierRef.Location = new System.Drawing.Point(242, 314);
      this.lblSupplierRef.Name = "lblSupplierRef";
      this.lblSupplierRef.Size = new Size(75, 13);
      this.lblSupplierRef.TabIndex = 1;
      this.lblSupplierRef.Text = "Invoice Ref.";
      this.btnAddSupplierInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnAddSupplierInvoice.Location = new System.Drawing.Point(1727, 339);
      this.btnAddSupplierInvoice.Name = "btnAddSupplierInvoice";
      this.btnAddSupplierInvoice.Size = new Size(56, 24);
      this.btnAddSupplierInvoice.TabIndex = 123;
      this.btnAddSupplierInvoice.Text = "Add ";
      this.dgvReceivedInvoices.AllowUserToAddRows = false;
      gridViewCellStyle1.BackColor = Color.White;
      gridViewCellStyle1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = Color.Navy;
      gridViewCellStyle1.SelectionBackColor = Color.Gainsboro;
      gridViewCellStyle1.SelectionForeColor = Color.Navy;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.dgvReceivedInvoices.AlternatingRowsDefaultCellStyle = gridViewCellStyle1;
      this.dgvReceivedInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgvReceivedInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvReceivedInvoices.BackgroundColor = Color.White;
      this.dgvReceivedInvoices.BorderStyle = BorderStyle.None;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = Color.SteelBlue;
      gridViewCellStyle2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = Color.White;
      gridViewCellStyle2.SelectionBackColor = Color.SteelBlue;
      gridViewCellStyle2.SelectionForeColor = Color.White;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      this.dgvReceivedInvoices.ColumnHeadersDefaultCellStyle = gridViewCellStyle2;
      this.dgvReceivedInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvReceivedInvoices.EnableHeadersVisualStyles = false;
      this.dgvReceivedInvoices.GridColor = Color.LightSteelBlue;
      this.dgvReceivedInvoices.Location = new System.Drawing.Point(3, 17);
      this.dgvReceivedInvoices.MultiSelect = false;
      this.dgvReceivedInvoices.Name = "dgvReceivedInvoices";
      this.dgvReceivedInvoices.RowHeadersVisible = false;
      gridViewCellStyle3.BackColor = Color.White;
      gridViewCellStyle3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = Color.Navy;
      gridViewCellStyle3.SelectionBackColor = Color.Gainsboro;
      gridViewCellStyle3.SelectionForeColor = Color.Navy;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.dgvReceivedInvoices.RowsDefaultCellStyle = gridViewCellStyle3;
      this.dgvReceivedInvoices.RowTemplate.Height = 29;
      this.dgvReceivedInvoices.RowTemplate.ReadOnly = true;
      this.dgvReceivedInvoices.RowTemplate.Resizable = DataGridViewTriState.True;
      this.dgvReceivedInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvReceivedInvoices.Size = new Size(1780, 288);
      this.dgvReceivedInvoices.TabIndex = 0;
      this.dtpSupplierInvoiceDateNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.dtpSupplierInvoiceDateNew.Location = new System.Drawing.Point(92, 311);
      this.dtpSupplierInvoiceDateNew.Name = "dtpSupplierInvoiceDateNew";
      this.dtpSupplierInvoiceDateNew.Size = new Size(144, 21);
      this.dtpSupplierInvoiceDateNew.TabIndex = 101;
      this.dtpSupplierInvoiceDateNew.Tag = (object) "Order.SupplierInvoiceDate";
      this.cboReadySageNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cboReadySageNew.Location = new System.Drawing.Point(653, 338);
      this.cboReadySageNew.Name = "cboReadySageNew";
      this.cboReadySageNew.RightToLeft = RightToLeft.Yes;
      this.cboReadySageNew.Size = new Size(247, 24);
      this.cboReadySageNew.TabIndex = 110;
      this.cboReadySageNew.Text = "Ready to send to Accounts Package";
      this.TabPage1.Controls.Add((Control) this.GroupBox4);
      this.TabPage1.Location = new System.Drawing.Point(4, 22);
      this.TabPage1.Name = "TabPage1";
      this.TabPage1.Size = new Size(1796, 373);
      this.TabPage1.TabIndex = 11;
      this.TabPage1.Text = "Credits";
      this.TabPage1.UseVisualStyleBackColor = true;
      this.GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.GroupBox4.Controls.Add((Control) this.Button1);
      this.GroupBox4.Controls.Add((Control) this.CheckBox1);
      this.GroupBox4.Controls.Add((Control) this.txtCreditExRef);
      this.GroupBox4.Controls.Add((Control) this.Label21);
      this.GroupBox4.Controls.Add((Control) this.btnCreditDelete);
      this.GroupBox4.Controls.Add((Control) this.txtCreditTotal);
      this.GroupBox4.Controls.Add((Control) this.Label9);
      this.GroupBox4.Controls.Add((Control) this.txtCreditVAT);
      this.GroupBox4.Controls.Add((Control) this.txtCreditNominal);
      this.GroupBox4.Controls.Add((Control) this.Label10);
      this.GroupBox4.Controls.Add((Control) this.Label14);
      this.GroupBox4.Controls.Add((Control) this.txtCreditGoods);
      this.GroupBox4.Controls.Add((Control) this.cboCreditTax);
      this.GroupBox4.Controls.Add((Control) this.Label18);
      this.GroupBox4.Controls.Add((Control) this.Label20);
      this.GroupBox4.Controls.Add((Control) this.txtCreditRef);
      this.GroupBox4.Controls.Add((Control) this.Label23);
      this.GroupBox4.Controls.Add((Control) this.btnCreditAdd);
      this.GroupBox4.Controls.Add((Control) this.dgCredits);
      this.GroupBox4.Controls.Add((Control) this.dtpCreditDate);
      this.GroupBox4.Location = new System.Drawing.Point(3, 4);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(1789, 366);
      this.GroupBox4.TabIndex = 1;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Part Credits";
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.Location = new System.Drawing.Point(1495, 339);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(142, 24);
      this.Button1.TabIndex = (int) sbyte.MaxValue;
      this.Button1.Text = "Convert to Van stock";
      this.CheckBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.CheckBox1.Location = new System.Drawing.Point(-20, 312);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.RightToLeft = RightToLeft.Yes;
      this.CheckBox1.Size = new Size(141, 24);
      this.CheckBox1.TabIndex = 126;
      this.CheckBox1.Text = "Credit Recieved";
      this.txtCreditExRef.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtCreditExRef.Location = new System.Drawing.Point(1118, 339);
      this.txtCreditExRef.MaxLength = 100;
      this.txtCreditExRef.Name = "txtCreditExRef";
      this.txtCreditExRef.Size = new Size(70, 21);
      this.txtCreditExRef.TabIndex = 125;
      this.txtCreditExRef.Tag = (object) "Order.SupplierInvoiceReference";
      this.Label21.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label21.Location = new System.Drawing.Point(1073, 342);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(56, 20);
      this.Label21.TabIndex = 124;
      this.Label21.Text = "Ex Ref.";
      this.btnCreditDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCreditDelete.Location = new System.Drawing.Point(1656, 339);
      this.btnCreditDelete.Name = "btnCreditDelete";
      this.btnCreditDelete.Size = new Size(56, 24);
      this.btnCreditDelete.TabIndex = 121;
      this.btnCreditDelete.Text = "Delete";
      this.btnCreditDelete.Visible = false;
      this.txtCreditTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtCreditTotal.Location = new System.Drawing.Point(539, 342);
      this.txtCreditTotal.Name = "txtCreditTotal";
      this.txtCreditTotal.Size = new Size(68, 21);
      this.txtCreditTotal.TabIndex = 109;
      this.Label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label9.AutoSize = true;
      this.Label9.Location = new System.Drawing.Point(467, 345);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(55, 13);
      this.Label9.TabIndex = 28;
      this.Label9.Text = "Total (£)";
      this.txtCreditVAT.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtCreditVAT.Location = new System.Drawing.Point(372, 341);
      this.txtCreditVAT.Name = "txtCreditVAT";
      this.txtCreditVAT.Size = new Size(68, 21);
      this.txtCreditVAT.TabIndex = 108;
      this.txtCreditNominal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtCreditNominal.Location = new System.Drawing.Point(1000, 339);
      this.txtCreditNominal.MaxLength = 100;
      this.txtCreditNominal.Name = "txtCreditNominal";
      this.txtCreditNominal.Size = new Size(70, 21);
      this.txtCreditNominal.TabIndex = 105;
      this.txtCreditNominal.Tag = (object) "Order.SupplierInvoiceReference";
      this.Label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label10.Location = new System.Drawing.Point(947, 342);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(70, 20);
      this.Label10.TabIndex = 65;
      this.Label10.Text = "Nominal";
      this.Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label14.AutoSize = true;
      this.Label14.Location = new System.Drawing.Point(309, 344);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(50, 13);
      this.Label14.TabIndex = 26;
      this.Label14.Text = "VAT (£)";
      this.txtCreditGoods.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtCreditGoods.Location = new System.Drawing.Point(95, 340);
      this.txtCreditGoods.Name = "txtCreditGoods";
      this.txtCreditGoods.Size = new Size(54, 21);
      this.txtCreditGoods.TabIndex = 106;
      this.cboCreditTax.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cboCreditTax.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCreditTax.Location = new System.Drawing.Point(238, 340);
      this.cboCreditTax.Name = "cboCreditTax";
      this.cboCreditTax.Size = new Size(46, 21);
      this.cboCreditTax.TabIndex = 107;
      this.Label18.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label18.Location = new System.Drawing.Point(168, 342);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(70, 20);
      this.Label18.TabIndex = 59;
      this.Label18.Text = "Tax Code";
      this.Label20.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label20.AutoSize = true;
      this.Label20.Location = new System.Drawing.Point(6, 343);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(86, 13);
      this.Label20.TabIndex = 24;
      this.Label20.Text = "Credit Net (£)";
      this.txtCreditRef.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtCreditRef.Location = new System.Drawing.Point(871, 339);
      this.txtCreditRef.Name = "txtCreditRef";
      this.txtCreditRef.Size = new Size(70, 21);
      this.txtCreditRef.TabIndex = 103;
      this.Label23.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label23.AutoSize = true;
      this.Label23.Location = new System.Drawing.Point(801, 344);
      this.Label23.Name = "Label23";
      this.Label23.Size = new Size(68, 13);
      this.Label23.TabIndex = 1;
      this.Label23.Text = "Credit Ref.";
      this.btnCreditAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCreditAdd.Location = new System.Drawing.Point(1727, 339);
      this.btnCreditAdd.Name = "btnCreditAdd";
      this.btnCreditAdd.Size = new Size(56, 24);
      this.btnCreditAdd.TabIndex = 123;
      this.btnCreditAdd.Text = "Add ";
      this.dgCredits.AllowUserToAddRows = false;
      gridViewCellStyle4.BackColor = Color.White;
      gridViewCellStyle4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = Color.Navy;
      gridViewCellStyle4.SelectionBackColor = Color.Gainsboro;
      gridViewCellStyle4.SelectionForeColor = Color.Navy;
      gridViewCellStyle4.WrapMode = DataGridViewTriState.True;
      this.dgCredits.AlternatingRowsDefaultCellStyle = gridViewCellStyle4;
      this.dgCredits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgCredits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.dgCredits.BackgroundColor = Color.White;
      this.dgCredits.BorderStyle = BorderStyle.None;
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle5.BackColor = Color.SteelBlue;
      gridViewCellStyle5.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle5.ForeColor = Color.White;
      gridViewCellStyle5.SelectionBackColor = Color.SteelBlue;
      gridViewCellStyle5.SelectionForeColor = Color.White;
      gridViewCellStyle5.WrapMode = DataGridViewTriState.True;
      this.dgCredits.ColumnHeadersDefaultCellStyle = gridViewCellStyle5;
      this.dgCredits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgCredits.EnableHeadersVisualStyles = false;
      this.dgCredits.GridColor = Color.LightSteelBlue;
      this.dgCredits.Location = new System.Drawing.Point(3, 23);
      this.dgCredits.MultiSelect = false;
      this.dgCredits.Name = "dgCredits";
      this.dgCredits.RowHeadersVisible = false;
      gridViewCellStyle6.BackColor = Color.White;
      gridViewCellStyle6.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle6.ForeColor = Color.Navy;
      gridViewCellStyle6.SelectionBackColor = Color.Gainsboro;
      gridViewCellStyle6.SelectionForeColor = Color.Navy;
      gridViewCellStyle6.WrapMode = DataGridViewTriState.True;
      this.dgCredits.RowsDefaultCellStyle = gridViewCellStyle6;
      this.dgCredits.RowTemplate.Height = 29;
      this.dgCredits.RowTemplate.ReadOnly = true;
      this.dgCredits.RowTemplate.Resizable = DataGridViewTriState.True;
      this.dgCredits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgCredits.Size = new Size(1780, 288);
      this.dgCredits.TabIndex = 0;
      this.dtpCreditDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.dtpCreditDate.Location = new System.Drawing.Point(128, 313);
      this.dtpCreditDate.Name = "dtpCreditDate";
      this.dtpCreditDate.Size = new Size(142, 21);
      this.dtpCreditDate.TabIndex = 101;
      this.dtpCreditDate.Tag = (object) "Order.SupplierInvoiceDate";
      this.lblOrderStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblOrderStatus.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.lblOrderStatus.Font = new Font("Verdana", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblOrderStatus.Location = new System.Drawing.Point(16, 129);
      this.lblOrderStatus.Name = "lblOrderStatus";
      this.lblOrderStatus.Size = new Size(1645, 24);
      this.lblOrderStatus.TabIndex = 0;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.lblCredits);
      this.GroupBox1.Controls.Add((Control) this.Label25);
      this.GroupBox1.Controls.Add((Control) this.lblSupplierGoods);
      this.GroupBox1.Controls.Add((Control) this.lblGoodsTotal);
      this.GroupBox1.Location = new System.Drawing.Point(1547, 36);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(275, 63);
      this.GroupBox1.TabIndex = 76;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Supplier Invoice Totals";
      this.lblCredits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblCredits.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblCredits.Location = new System.Drawing.Point(138, 37);
      this.lblCredits.Name = "lblCredits";
      this.lblCredits.Size = new Size(122, 15);
      this.lblCredits.TabIndex = 80;
      this.lblCredits.Text = "£0.00";
      this.lblCredits.TextAlign = ContentAlignment.MiddleRight;
      this.Label25.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label25.AutoSize = true;
      this.Label25.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label25.Location = new System.Drawing.Point(14, 40);
      this.Label25.Name = "Label25";
      this.Label25.Size = new Size(123, 13);
      this.Label25.TabIndex = 81;
      this.Label25.Text = "Supplier Credits : ";
      this.Label25.TextAlign = ContentAlignment.TopRight;
      this.lblSupplierGoods.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblSupplierGoods.AutoSize = true;
      this.lblSupplierGoods.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblSupplierGoods.Location = new System.Drawing.Point(14, 19);
      this.lblSupplierGoods.Name = "lblSupplierGoods";
      this.lblSupplierGoods.Size = new Size(133, 13);
      this.lblSupplierGoods.TabIndex = 73;
      this.lblSupplierGoods.Text = "Supplier Invoices : ";
      this.lblSupplierGoods.TextAlign = ContentAlignment.TopRight;
      this.lblGoodsTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblGoodsTotal.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblGoodsTotal.Location = new System.Drawing.Point(138, 17);
      this.lblGoodsTotal.Name = "lblGoodsTotal";
      this.lblGoodsTotal.Size = new Size(122, 15);
      this.lblGoodsTotal.TabIndex = 70;
      this.lblGoodsTotal.Text = "£0.00";
      this.lblGoodsTotal.TextAlign = ContentAlignment.MiddleRight;
      this.Label17.Location = new System.Drawing.Point(6, 97);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(79, 20);
      this.Label17.TabIndex = 68;
      this.Label17.Text = "Cost Centre";
      this.FSMDataSetBindingSource.DataSource = (object) this.FSMDataSet;
      this.FSMDataSetBindingSource.Position = 0;
      this.FSMDataSet.DataSetName = "FSMDataSet";
      this.FSMDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgParts.DataMember = "";
      this.dgParts.HeaderForeColor = SystemColors.ControlText;
      this.dgParts.Location = new System.Drawing.Point(8, 20);
      this.dgParts.Name = "dgParts";
      this.dgParts.Size = new Size(1769, 237);
      this.dgParts.TabIndex = 5;
      this.Controls.Add((Control) this.grpOrder);
      this.Name = nameof (UCOrder);
      this.Size = new Size(1835, 571);
      this.grpOrder.ResumeLayout(false);
      this.grpOrder.PerformLayout();
      this.tcOrderDetails.ResumeLayout(false);
      this.tabDetails.ResumeLayout(false);
      this.tabParts.ResumeLayout(false);
      this.grpPartSearch.ResumeLayout(false);
      this.grpPartSearch.PerformLayout();
      this.grpAvailableParts.ResumeLayout(false);
      this.grpAvailableParts.PerformLayout();
      this.tabProducts.ResumeLayout(false);
      this.grpProductsAvailable.ResumeLayout(false);
      this.grpProductsAvailable.PerformLayout();
      this.dgProduct.EndInit();
      this.grpProductSearch.ResumeLayout(false);
      this.grpProductSearch.PerformLayout();
      this.tabItemsIncluded.ResumeLayout(false);
      this.GroupBox3.ResumeLayout(false);
      this.nudItemQty.EndInit();
      this.dgItemsIncluded.EndInit();
      this.tabPartPriceReq.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.dgPriceRequests.EndInit();
      this.tabDocuments.ResumeLayout(false);
      this.tabInvoices.ResumeLayout(false);
      this.grpReceivedInvoices.ResumeLayout(false);
      this.grpReceivedInvoices.PerformLayout();
      ((ISupportInitialize) this.dgvReceivedInvoices).EndInit();
      this.TabPage1.ResumeLayout(false);
      this.GroupBox4.ResumeLayout(false);
      this.GroupBox4.PerformLayout();
      ((ISupportInitialize) this.dgCredits).EndInit();
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      ((ISupportInitialize) this.FSMDataSetBindingSource).EndInit();
      this.FSMDataSet.EndInit();
      this.dgParts.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupProductsDatagrid();
      this.SetupPartsDatagrid();
      this.SetupPriceRequestDatagrid();
      this.SetupSupplierInvoices();
      this.SetupCredits();
      if (this.CurrentOrder != null)
      {
        if (this.CurrentOrder.OrderStatusID == 1 | this.CurrentOrder.OrderStatusID == 0)
          this.txtOrderReference.Visible = false;
        else
          this.txtOrderReference.Visible = true;
      }
      else
        this.txtOrderReference.Visible = false;
      this.tcOrderDetails.TabPages.Remove(this.tabProducts);
      this.tcOrderDetails.TabPages.Remove(this.tabPartPriceReq);
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentOrder;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public event UCOrder.FormCloseEventHandler FormClose;

    public Order CurrentOrder
    {
      get
      {
        return this._currentOrder;
      }
      set
      {
        this._currentOrder = value;
        if (this._currentOrder == null)
        {
          this._currentOrder = new Order();
          this._currentOrder.Exists = false;
        }
        if (!this.CurrentOrder.Exists)
        {
          this.btnEngineerReceived.Visible = false;
          this.OrderNumber = App.DB.Job.GetNextJobNumber(FSM.Entity.Sys.Enums.JobDefinition.ORDER);
          this.cboOrderStatus.Enabled = false;
          this.cboOrderTypeID.Enabled = true;
          this.cboPrintType.Enabled = false;
          this.btnPrint.Enabled = false;
          this.btnEmail.Enabled = false;
          this.btnCharges.Enabled = false;
          ComboBox comboBox = this.cboOrderStatus;
          Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(1));
          this.cboOrderStatus = comboBox;
          this.lblOrderStatus.Text = "SAVE BASE ORDER DETAILS BEFORE MANAGING ITEMS";
          this.lblOrderStatus.Visible = true;
          this.EnableTabs(false);
          comboBox = this.cboPrintType;
          Combo.SetUpCombo(ref comboBox, (DataTable) null, "ValueMember", "DisplayMember", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
          this.cboPrintType = comboBox;
        }
        else
        {
          this.cboOrderStatus.Enabled = true;
          this.cboOrderTypeID.Enabled = false;
          this.cboPrintType.Enabled = true;
          this.btnPrint.Enabled = true;
          this.btnEmail.Enabled = true;
          this.btnCharges.Enabled = true;
          this.pnlDocuments.Controls.Clear();
          this.DocumentsControl = new UCDocumentsList(FSM.Entity.Sys.Enums.TableNames.tblOrder, this.CurrentOrder.OrderID);
          this.pnlDocuments.Controls.Add((Control) this.DocumentsControl);
          ComboBox cboPrintType = this.cboPrintType;
          Combo.SetUpCombo(ref cboPrintType, DynamicDataTables.get_SystemDocumentTypes((FSM.Entity.Sys.Enums.OrderType) this.CurrentOrder.OrderTypeID), "ValueMember", "DisplayMember", FSM.Entity.Sys.Enums.ComboValues.Please_Select);
          this.cboPrintType = cboPrintType;
          this.Populate(0);
          this.EnableTabs(true);
        }
        this.SetupItemsIncludedDatagrid();
        this.IsLoading = false;
      }
    }

    private bool isOrderComplete()
    {
      bool flag = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this.ItemsIncludedDataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["QuantityOnOrder"], current["QuantityReceived"], false))
            flag = false;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return flag;
    }

    private bool isOrderCancelled()
    {
      this.RefreshDataGrids();
      return this.ItemsIncludedDataView.Count <= 0;
    }

    public int PassedID
    {
      get
      {
        return this._passedID;
      }
      set
      {
        this._passedID = value;
      }
    }

    public string Reason
    {
      get
      {
        return this._reason;
      }
      set
      {
        this._reason = value;
      }
    }

    public DataView ItemsIncludedDataView
    {
      get
      {
        return this._ItemsIncludedDataView;
      }
      set
      {
        this._ItemsIncludedDataView = value;
        this._ItemsIncludedDataView.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblOrder.ToString();
        this._ItemsIncludedDataView.AllowNew = false;
        this._ItemsIncludedDataView.AllowEdit = false;
        this._ItemsIncludedDataView.AllowDelete = false;
        this.dgItemsIncluded.DataSource = (object) this.ItemsIncludedDataView;
        this.PopulateOrderTotal();
        if (this.ItemsIncludedDataView.Table.Rows.Count != 0)
          return;
        this.SupplierUsedID = 0;
        this.LocationUsedID = 0;
      }
    }

    private DataRow SelectedItemIncludedDataRow
    {
      get
      {
        return this.dgItemsIncluded.CurrentRowIndex != -1 ? this.ItemsIncludedDataView[this.dgItemsIncluded.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView ProductsDataView
    {
      get
      {
        return this._ProductsDataView;
      }
      set
      {
        this._ProductsDataView = value;
        this._ProductsDataView.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblProduct.ToString();
        this._ProductsDataView.AllowNew = false;
        this._ProductsDataView.AllowEdit = false;
        this._ProductsDataView.AllowDelete = false;
        this.dgProduct.DataSource = (object) this.ProductsDataView;
      }
    }

    private DataRow SelectedProductDataRow
    {
      get
      {
        return this.dgProduct.CurrentRowIndex != -1 ? this.ProductsDataView[this.dgProduct.CurrentRowIndex].Row : (DataRow) null;
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
        this._PriceRequestDataView.Table.TableName = FSM.Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
        this._PriceRequestDataView.AllowNew = false;
        this._PriceRequestDataView.AllowEdit = false;
        this._PriceRequestDataView.AllowDelete = false;
        this.dgPriceRequests.DataSource = (object) this.PriceRequestDataView;
        this.btnUpdatePartPriceRequest.Enabled = false;
      }
    }

    private DataRow SelectedPriceRequestDataRow
    {
      get
      {
        return this.dgPriceRequests.CurrentRowIndex != -1 ? this.PriceRequestDataView[this.dgPriceRequests.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView PartsDataView
    {
      get
      {
        return this._PartsDataView;
      }
      set
      {
        this._PartsDataView = value;
        this._PartsDataView.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblPart.ToString();
        this._PartsDataView.AllowNew = false;
        this._PartsDataView.AllowEdit = false;
        this._PartsDataView.AllowDelete = false;
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

    public int SupplierUsedID
    {
      get
      {
        return this._supplierUsedID;
      }
      set
      {
        this._supplierUsedID = value;
      }
    }

    public int LocationUsedID
    {
      get
      {
        return this._locationUsedID;
      }
      set
      {
        this._locationUsedID = value;
      }
    }

    public bool OrderNumberUsed
    {
      get
      {
        return this._OrderNumberUsed;
      }
      set
      {
        this._OrderNumberUsed = value;
      }
    }

    public JobNumber OrderNumber
    {
      get
      {
        return this._OrderNumber;
      }
      set
      {
        this._OrderNumber = value;
        if (this.CurrentOrder.Exists)
          return;
        this.OrderNumberUsed = false;
        this._OrderNumber.OrderNumber = Conversions.ToString(this.OrderNumber.JobNumber);
        while (this.OrderNumber.OrderNumber.Length < 5)
          this._OrderNumber.OrderNumber = "0" + this.OrderNumber.OrderNumber;
        string str1 = "";
        switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboOrderTypeID)))
        {
          case 1:
            str1 = "W";
            break;
          case 2:
            str1 = "V";
            break;
          case 3:
            str1 = "W";
            break;
          case 4:
            str1 = "V";
            break;
        }
        string str2 = "";
        string[] strArray = App.loggedInUser.Fullname.Split(' ');
        int index = 0;
        while (index < strArray.Length)
        {
          string str3 = strArray[index];
          str2 += str3.Substring(0, 1);
          checked { ++index; }
        }
        this._OrderNumber.OrderNumber = str2 + str1 + this.OrderNumber.OrderNumber;
        this.txtOrderReference.Text = this.OrderNumber.OrderNumber;
      }
    }

    public int CustomerID
    {
      get
      {
        return this._customerID;
      }
      set
      {
        this._customerID = value;
      }
    }

    private void SetupCredits()
    {
      this.dgCredits.AutoGenerateColumns = false;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.FillWeight = 75f;
      viewTextBoxColumn1.HeaderText = "Credit Created";
      viewTextBoxColumn1.DataPropertyName = "DateCreated";
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 75f;
      viewTextBoxColumn2.HeaderText = "Part Number";
      viewTextBoxColumn2.Name = "PartNumber";
      viewTextBoxColumn2.DataPropertyName = "PartNumber";
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.FillWeight = 150f;
      viewTextBoxColumn3.HeaderText = "Part Name";
      viewTextBoxColumn3.Name = "PartName";
      viewTextBoxColumn3.DataPropertyName = "PartName";
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.FillWeight = 30f;
      viewTextBoxColumn4.HeaderText = "Qty";
      viewTextBoxColumn4.Name = "Qty";
      viewTextBoxColumn4.DataPropertyName = "Qty";
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.FillWeight = 50f;
      viewTextBoxColumn5.HeaderText = "Parts Buy Price";
      viewTextBoxColumn5.DataPropertyName = "Total";
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      viewTextBoxColumn5.DefaultCellStyle.Format = "c";
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.FillWeight = 75f;
      viewTextBoxColumn6.HeaderText = "Return Ref.";
      viewTextBoxColumn6.DataPropertyName = "ReturnRef";
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.FillWeight = 75f;
      viewTextBoxColumn7.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
      viewTextBoxColumn7.HeaderText = "Date Part Returned";
      viewTextBoxColumn7.Name = "DatePartReturned";
      viewTextBoxColumn7.DataPropertyName = "DatePartReturned";
      viewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.FillWeight = 150f;
      viewTextBoxColumn8.HeaderText = "Engineer Returning";
      viewTextBoxColumn8.DataPropertyName = "Engineer";
      viewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn8);
      DataGridViewTextBoxColumn viewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn9.FillWeight = 75f;
      viewTextBoxColumn9.HeaderText = "Supplier Credit Ref";
      viewTextBoxColumn9.DataPropertyName = "SupplierCreditRef";
      viewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn9);
      DataGridViewTextBoxColumn viewTextBoxColumn10 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn10.FillWeight = 75f;
      viewTextBoxColumn10.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
      viewTextBoxColumn10.HeaderText = "Date Credit Recieved";
      viewTextBoxColumn10.DataPropertyName = "DateReceived";
      viewTextBoxColumn10.Name = "DateReceived";
      viewTextBoxColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn10);
      DataGridViewTextBoxColumn viewTextBoxColumn11 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn11.FillWeight = 30f;
      viewTextBoxColumn11.HeaderText = "Credit Total";
      viewTextBoxColumn11.DataPropertyName = "AmountReceived";
      viewTextBoxColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
      viewTextBoxColumn11.DefaultCellStyle.Format = "c";
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn11);
      DataGridViewTextBoxColumn viewTextBoxColumn12 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn12.FillWeight = 1f;
      viewTextBoxColumn12.HeaderText = "";
      viewTextBoxColumn12.Visible = true;
      viewTextBoxColumn12.DataPropertyName = "PartCreditsID";
      viewTextBoxColumn12.Name = "PartCreditsID";
      viewTextBoxColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn12);
      DataGridViewTextBoxColumn viewTextBoxColumn13 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn13.FillWeight = 1f;
      viewTextBoxColumn13.HeaderText = "";
      viewTextBoxColumn13.Visible = true;
      viewTextBoxColumn13.DataPropertyName = "PartID";
      viewTextBoxColumn13.Name = "PartID";
      viewTextBoxColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn13);
      DataGridViewTextBoxColumn viewTextBoxColumn14 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn14.FillWeight = 1f;
      viewTextBoxColumn14.HeaderText = "";
      viewTextBoxColumn14.Visible = true;
      viewTextBoxColumn14.DataPropertyName = "OrderPartID";
      viewTextBoxColumn14.Name = "OrderPartID";
      viewTextBoxColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn14);
      DataGridViewTextBoxColumn viewTextBoxColumn15 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn15.FillWeight = 1f;
      viewTextBoxColumn15.HeaderText = "";
      viewTextBoxColumn15.Visible = true;
      viewTextBoxColumn15.DataPropertyName = "PartsToBeCreditedID";
      viewTextBoxColumn15.Name = "PartsToBeCreditedID";
      viewTextBoxColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn15);
      DataGridViewTextBoxColumn viewTextBoxColumn16 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn16.FillWeight = 1f;
      viewTextBoxColumn16.HeaderText = "";
      viewTextBoxColumn16.Visible = true;
      viewTextBoxColumn16.DataPropertyName = "DateExportedToSage";
      viewTextBoxColumn16.Name = "DateExportedToSage";
      viewTextBoxColumn16.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgCredits.Columns.Add((DataGridViewColumn) viewTextBoxColumn16);
    }

    private void SetupSupplierInvoices()
    {
      this.dgvReceivedInvoices.AutoGenerateColumns = false;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.FillWeight = 200f;
      viewTextBoxColumn1.HeaderText = "Invoice Date";
      viewTextBoxColumn1.DataPropertyName = "SupplierInvoiceDate";
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
      this.dgvReceivedInvoices.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.FillWeight = 200f;
      viewTextBoxColumn2.HeaderText = "Supplier Invoice Ref.";
      viewTextBoxColumn2.DataPropertyName = "SupplierInvoiceReference";
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgvReceivedInvoices.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.FillWeight = 200f;
      viewTextBoxColumn3.HeaderText = "Goods";
      viewTextBoxColumn3.Name = "SupplierInvoiceAmount";
      viewTextBoxColumn3.DataPropertyName = "SupplierInvoiceAmount";
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      viewTextBoxColumn3.DefaultCellStyle.Format = "c";
      this.dgvReceivedInvoices.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.FillWeight = 200f;
      viewTextBoxColumn4.HeaderText = "VAT";
      viewTextBoxColumn4.DataPropertyName = "SupplierVATAmount";
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      viewTextBoxColumn4.DefaultCellStyle.Format = "c";
      this.dgvReceivedInvoices.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.FillWeight = 200f;
      viewTextBoxColumn5.HeaderText = "Total";
      viewTextBoxColumn5.DataPropertyName = "SupplierGoodsAmount";
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      viewTextBoxColumn5.DefaultCellStyle.Format = "c";
      this.dgvReceivedInvoices.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.FillWeight = 50f;
      viewTextBoxColumn6.HeaderText = "Trans ID";
      viewTextBoxColumn6.Name = "SupplierInvoiceID";
      viewTextBoxColumn6.DataPropertyName = "SupplierInvoiceID";
      viewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dgvReceivedInvoices.Columns.Add((DataGridViewColumn) viewTextBoxColumn6);
    }

    public void SetupItemsIncludedDatagrid()
    {
      Helper.SetUpDataGrid(this.dgItemsIncluded, false);
      DataGridTableStyle tableStyle = this.dgItemsIncluded.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Supplier";
      dataGridLabelColumn1.MappingName = "SupplierName";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Warehouse Name";
      dataGridLabelColumn2.MappingName = "WarehouseName";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Stock Profile Name";
      dataGridLabelColumn3.MappingName = "Registration";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Item Name";
      dataGridLabelColumn4.MappingName = "Name";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Company Code (GPN)";
      dataGridLabelColumn5.MappingName = "Number";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Supplier Part Code (SPN)";
      dataGridLabelColumn6.MappingName = "SupplierPartCode";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Cost";
      dataGridLabelColumn7.MappingName = "BuyPrice";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 85;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "C";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Sell Price";
      dataGridLabelColumn8.MappingName = "SellPrice";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 85;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Qty In Pack";
      dataGridLabelColumn9.MappingName = "QuantityInPack";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Qty To Order";
      dataGridLabelColumn10.MappingName = "QuantityOnOrder";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 100;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Qty Received";
      dataGridLabelColumn11.MappingName = "QuantityReceived";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 100;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      if (this.CurrentOrder != null && this.CurrentOrder.Exists)
      {
        DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
        dataGridLabelColumn12.Format = "dd/MM/yyyy HH:mm:ss";
        dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn12.HeaderText = "Date Engineer Picked up";
        dataGridLabelColumn12.MappingName = "WithEngineer_Van";
        dataGridLabelColumn12.ReadOnly = true;
        dataGridLabelColumn12.Width = 110;
        dataGridLabelColumn12.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
        DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
        dataGridLabelColumn13.Format = "dd/MM/yyyy HH:mm:ss";
        dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
        dataGridLabelColumn13.HeaderText = "Date Engineer Distributed";
        dataGridLabelColumn13.MappingName = "WithEngineer_Job";
        dataGridLabelColumn13.ReadOnly = true;
        dataGridLabelColumn13.Width = 110;
        dataGridLabelColumn13.NullText = "";
        tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      }
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblOrder.ToString();
      this.dgItemsIncluded.TableStyles.Add(tableStyle);
    }

    public void SetupPartsDatagrid()
    {
      Helper.SetUpDataGrid(this.dgParts, false);
      DataGridTableStyle tableStyle = this.dgParts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      UCOrder.ColourColumn colourColumn = new UCOrder.ColourColumn();
      colourColumn.Format = "";
      colourColumn.FormatInfo = (IFormatProvider) null;
      colourColumn.HeaderText = "Preferred";
      colourColumn.MappingName = "Preferred";
      colourColumn.ReadOnly = true;
      colourColumn.Width = 25;
      colourColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) colourColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Supplier";
      dataGridLabelColumn1.MappingName = "SupplierName";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "No Supplier Assigned";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Engineer Name";
      dataGridLabelColumn2.MappingName = "EngineerName";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Stock Profile Name";
      dataGridLabelColumn3.MappingName = "Registration";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 130;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Warehouse Name";
      dataGridLabelColumn4.MappingName = "warehouseName";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 120;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Address 1";
      dataGridLabelColumn5.MappingName = "address1";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 120;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Postcode";
      dataGridLabelColumn6.MappingName = "postcode";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 120;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Part Name";
      dataGridLabelColumn7.MappingName = "PartName";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 250;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "C";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Cost";
      dataGridLabelColumn8.MappingName = "Price";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 85;
      dataGridLabelColumn8.NullText = "£0.00";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Company Code";
      dataGridLabelColumn9.MappingName = "PartNumber";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Supplier Code";
      dataGridLabelColumn10.MappingName = "PartCode";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 130;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Qty In Pack";
      dataGridLabelColumn11.MappingName = "QuantityInPack";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 120;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "Part Ref";
      dataGridLabelColumn12.MappingName = "Reference";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 100;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "C";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "Sell Price";
      dataGridLabelColumn13.MappingName = "SellPrice";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 85;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      DataGridLabelColumn dataGridLabelColumn14 = new DataGridLabelColumn();
      dataGridLabelColumn14.Format = "";
      dataGridLabelColumn14.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn14.HeaderText = "Amount";
      dataGridLabelColumn14.MappingName = "Amount";
      dataGridLabelColumn14.ReadOnly = true;
      dataGridLabelColumn14.Width = 85;
      dataGridLabelColumn14.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn14);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblPart.ToString();
      this.dgParts.TableStyles.Add(tableStyle);
    }

    public void SetupProductsDatagrid()
    {
      Helper.SetUpDataGrid(this.dgProduct, false);
      DataGridTableStyle tableStyle = this.dgProduct.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Warehouse Name";
      dataGridLabelColumn1.MappingName = "warehouseName";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 120;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Address 1";
      dataGridLabelColumn2.MappingName = "address1";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 120;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Postcode";
      dataGridLabelColumn3.MappingName = "postcode";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 120;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Supplier";
      dataGridLabelColumn4.MappingName = "SupplierName";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "No Supplier Assigned";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Engineer Name";
      dataGridLabelColumn5.MappingName = "EngineerName";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Stock Profile Name";
      dataGridLabelColumn6.MappingName = "Registration";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 130;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Description";
      dataGridLabelColumn7.MappingName = "typemakemodel";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Supplier Product Code";
      dataGridLabelColumn8.MappingName = "ProductCode";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 130;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Product Code";
      dataGridLabelColumn9.MappingName = "ProductNumber";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Product Reference";
      dataGridLabelColumn10.MappingName = "Reference";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 120;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "C";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Cost";
      dataGridLabelColumn11.MappingName = "Price";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 85;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "C";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "Sell Price";
      dataGridLabelColumn12.MappingName = "SellPrice";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 85;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "Quantity In Pack";
      dataGridLabelColumn13.MappingName = "QuantityInPack";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 120;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      DataGridLabelColumn dataGridLabelColumn14 = new DataGridLabelColumn();
      dataGridLabelColumn14.Format = "";
      dataGridLabelColumn14.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn14.HeaderText = "Amount";
      dataGridLabelColumn14.MappingName = "Amount";
      dataGridLabelColumn14.ReadOnly = true;
      dataGridLabelColumn14.Width = 85;
      dataGridLabelColumn14.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn14);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblProduct.ToString();
      this.dgProduct.TableStyles.Add(tableStyle);
    }

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
      dataGridLabelColumn1.Width = 75;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Supplier";
      dataGridLabelColumn2.MappingName = "SupplierName";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Postcode";
      dataGridLabelColumn3.MappingName = "Postcode";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Telephone";
      dataGridLabelColumn4.MappingName = "TelephoneNum";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Part";
      dataGridLabelColumn5.MappingName = "Part";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 150;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Product";
      dataGridLabelColumn6.MappingName = "Product";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 150;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Quantity";
      dataGridLabelColumn7.MappingName = "QuantityInPack";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 110;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
      this.dgPriceRequests.TableStyles.Add(tableStyle);
    }

    private void txtGoodsAmount_TextChanged(object sender, EventArgs e)
    {
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtGoodsAmount.Text, (string) null, false) <= 0U)
        return;
      try
      {
        this.Calculate_Tax();
        this.txtGoodsAmount.Text = Microsoft.VisualBasic.Strings.FormatCurrency((object) this.txtGoodsAmount.Text, -1, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void txtVATAmount_LostFocus(object sender, EventArgs e)
    {
      if (!((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtGoodsAmount.Text, (string) null, false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtVATAmount.Text, (string) null, false) > 0U))
        return;
      this.txtVATAmount.Text = Microsoft.VisualBasic.Strings.FormatCurrency((object) this.txtVATAmount.Text, -1, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
      this.txtTotalAmount.Text = Microsoft.VisualBasic.Strings.FormatCurrency((object) (Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtGoodsAmount.Text, "£", "", 1, -1, CompareMethod.Binary)) + Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtVATAmount.Text, "£", "", 1, -1, CompareMethod.Binary))), -1, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
    }

    private void txtCreditAmount_TextChanged(object sender, EventArgs e)
    {
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCreditGoods.Text, (string) null, false) <= 0U)
        return;
      try
      {
        this.Calculate_Tax2();
        this.txtCreditGoods.Text = Microsoft.VisualBasic.Strings.FormatCurrency((object) this.txtCreditGoods.Text, -1, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void txtCreditVAT__LostFocus(object sender, EventArgs e)
    {
      if (!((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCreditGoods.Text, (string) null, false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCreditVAT.Text, (string) null, false) > 0U))
        return;
      this.txtCreditVAT.Text = Microsoft.VisualBasic.Strings.FormatCurrency((object) this.txtCreditVAT.Text, -1, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
      this.txtCreditTotal.Text = Microsoft.VisualBasic.Strings.FormatCurrency((object) (Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtCreditGoods.Text, "£", "", 1, -1, CompareMethod.Binary)) + Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtCreditVAT.Text, "£", "", 1, -1, CompareMethod.Binary))), -1, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
    }

    private void btnReceiveAll_Click(object sender, EventArgs e)
    {
      if (this.CurrentOrder.OrderConsolidationID > 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(this.SelectedItemIncludedDataRow["Type"]), "OrderPart", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(this.SelectedItemIncludedDataRow["Type"]), "OrderProduct", false) == 0)
      {
        int num1 = (int) App.ShowMessage("This order has been added to a consolidation so should be managed from there.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.CurrentOrder.OrderStatusID != 2)
      {
        int num2 = (int) App.ShowMessage("Order must be confirmed to mark items into stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.ItemsIncludedDataView.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Conversions.ToInteger(current["QuantityOnOrder"]) != Conversions.ToInteger(current["QuantityReceived"]))
            {
              int num3 = checked (Conversions.ToInteger(current["QuantityOnOrder"]) - Conversions.ToInteger(current["QuantityReceived"]));
              string Left = Conversions.ToString(current["Type"]);
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderProduct", false) != 0)
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderPart", false) != 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderLocationProduct", false) != 0)
                  {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderLocationPart", false) == 0)
                    {
                      FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get(Conversions.ToInteger(current["ID"]));
                      PartTransaction orderLocationPart = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(oOrderLocationPart.OrderLocationPartID);
                      orderLocationPart.SetAmount = (object) checked (orderLocationPart.Amount + num3);
                      App.DB.PartTransaction.Update(orderLocationPart);
                      orderLocationPart.SetLocationID = (object) oOrderLocationPart.LocationID;
                      orderLocationPart.SetPartID = (object) oOrderLocationPart.PartID;
                      orderLocationPart.SetOrderLocationPartID = (object) oOrderLocationPart.OrderLocationPartID;
                      orderLocationPart.SetTransactionTypeID = (object) 3;
                      orderLocationPart.SetAmount = (object) checked (-num3);
                      App.DB.PartTransaction.Insert(orderLocationPart);
                      oOrderLocationPart.SetQuantityReceived = (object) checked (oOrderLocationPart.QuantityReceived + num3);
                      App.DB.OrderLocationPart.Update(oOrderLocationPart);
                      switch (this.CurrentOrder.OrderTypeID)
                      {
                        case 3:
                          OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(oOrderLocationPart.OrderID);
                          orderLocationPart.SetLocationID = (object) forOrder.LocationID;
                          orderLocationPart.SetTransactionTypeID = (object) 2;
                          orderLocationPart.SetOrderLocationPartID = (object) oOrderLocationPart.OrderLocationPartID;
                          orderLocationPart.SetAmount = (object) num3;
                          orderLocationPart.SetPartID = (object) oOrderLocationPart.PartID;
                          App.DB.PartTransaction.Insert(orderLocationPart);
                          break;
                      }
                    }
                  }
                  else
                  {
                    FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct = App.DB.OrderLocationProduct.OrderLocationProduct_Get(Conversions.ToInteger(current["ID"]));
                    ProductTransaction orderLocationProduct = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(oOrderLocationProduct.OrderLocationProductID);
                    orderLocationProduct.SetAmount = (object) checked (orderLocationProduct.Amount + num3);
                    App.DB.ProductTransaction.Update(orderLocationProduct);
                    orderLocationProduct.SetLocationID = (object) oOrderLocationProduct.LocationID;
                    orderLocationProduct.SetProductID = (object) oOrderLocationProduct.ProductID;
                    orderLocationProduct.SetOrderLocationProductID = (object) oOrderLocationProduct.OrderLocationProductID;
                    orderLocationProduct.SetTransactionTypeID = (object) 3;
                    orderLocationProduct.SetAmount = (object) checked (-num3);
                    App.DB.ProductTransaction.Insert(orderLocationProduct);
                    oOrderLocationProduct.SetQuantityReceived = (object) checked (oOrderLocationProduct.QuantityReceived + num3);
                    App.DB.OrderLocationProduct.Update(oOrderLocationProduct);
                    switch (this.CurrentOrder.OrderTypeID)
                    {
                      case 3:
                        OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(oOrderLocationProduct.OrderID);
                        orderLocationProduct.SetLocationID = (object) forOrder.LocationID;
                        orderLocationProduct.SetTransactionTypeID = (object) 2;
                        orderLocationProduct.SetOrderLocationProductID = (object) oOrderLocationProduct.OrderLocationProductID;
                        orderLocationProduct.SetAmount = (object) num3;
                        orderLocationProduct.SetProductID = (object) oOrderLocationProduct.ProductID;
                        App.DB.ProductTransaction.Insert(orderLocationProduct);
                        break;
                    }
                  }
                }
                else
                {
                  OrderPart orderPart = new OrderPart();
                  OrderPart oOrderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(current["ID"]));
                  oOrderPart.SetQuantityReceived = (object) checked (oOrderPart.QuantityReceived + num3);
                  App.DB.OrderPart.Update(oOrderPart);
                  switch (this.CurrentOrder.OrderTypeID)
                  {
                    case 3:
                      OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(oOrderPart.OrderID);
                      PartSupplier partSupplier = App.DB.PartSupplier.PartSupplier_Get(oOrderPart.PartSupplierID);
                      App.DB.PartTransaction.Insert(new PartTransaction()
                      {
                        SetLocationID = (object) forOrder.LocationID,
                        SetPartID = (object) partSupplier.PartID,
                        SetOrderPartID = (object) oOrderPart.OrderPartID,
                        SetAmount = (object) ((double) num3 * partSupplier.QuantityInPack),
                        SetTransactionTypeID = (object) 2
                      });
                      break;
                  }
                }
              }
              else
              {
                OrderProduct orderProduct = new OrderProduct();
                Product product = new Product();
                OrderProduct oOrderProduct = App.DB.OrderProduct.OrderProduct_Get(Conversions.ToInteger(current["ID"]));
                ProductSupplier productSupplier = App.DB.ProductSupplier.ProductSupplier_Get(oOrderProduct.ProductSupplierID);
                product = App.DB.Product.Product_Get(productSupplier.ProductID);
                oOrderProduct.SetQuantityReceived = (object) checked (oOrderProduct.QuantityReceived + num3);
                App.DB.OrderProduct.Update(oOrderProduct);
                switch (this.CurrentOrder.OrderTypeID)
                {
                  case 3:
                    OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(oOrderProduct.OrderID);
                    App.DB.ProductTransaction.Insert(new ProductTransaction()
                    {
                      SetLocationID = (object) forOrder.LocationID,
                      SetProductID = (object) productSupplier.ProductID,
                      SetOrderProductID = (object) oOrderProduct.OrderProductID,
                      SetAmount = (object) ((double) num3 * productSupplier.QuantityInPack),
                      SetTransactionTypeID = (object) 2
                    });
                    break;
                }
              }
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        this.Populate(this.CurrentOrder.OrderID);
        if (this.isOrderComplete())
        {
          this.CurrentOrder.SetOrderStatusID = (object) 4;
          App.DB.Order.Update(this.CurrentOrder);
          this.IsLoading = true;
          this.Populate(this.CurrentOrder.OrderID);
          this.IsLoading = false;
          if (this.CurrentOrder.OrderTypeID == 4)
          {
            EngineerVisit asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(this.ucJobOrder.SelectedEngineerVisitDataRow["EngineerVisitID"]), true);
            if (asObject.StatusEnumID == 2)
            {
              DataView forEngineerVisit = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(asObject.EngineerVisitID);
              bool flag = true;
              IEnumerator enumerator2;
              try
              {
                enumerator2 = forEngineerVisit.Table.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                  DataRow current = (DataRow) enumerator2.Current;
                  if ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderStatusID"])) > 0U && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["OrderStatusID"], (object) 4, false))))
                    flag = false;
                }
              }
              finally
              {
                if (enumerator2 is IDisposable)
                  (enumerator2 as IDisposable).Dispose();
              }
              if (flag)
                App.ShowForm(typeof (FRMPickDespatchDetails), true, new object[1]
                {
                  (object) asObject
                }, false);
            }
          }
          if (this.CurrentOrder.OrderTypeID == 1)
            App.ShowForm(typeof (FrmRaiseInvoiceDetails), true, new object[2]
            {
              (object) this.CurrentOrder.OrderID,
              (object) this.CurrentOrder.InvoiceAddressID
            }, false);
        }
      }
    }

    private void btnRelatedJob_Click(object sender, EventArgs e)
    {
      Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.PassedID);
      App.ShowForm(typeof (FRMLogCallout), true, new object[5]
      {
        (object) anEngineerVisitId.JobID,
        (object) anEngineerVisitId.PropertyID,
        (object) this,
        null,
        (object) this.PassedID
      }, false);
    }

    private void UCOrder_KeyDown(object sender, KeyEventArgs e)
    {
      if (this.tcOrderDetails.SelectedIndex == 1)
      {
        if (e.KeyCode != Keys.Return)
          return;
        this.PartSearch();
      }
      else
      {
        if (this.tcOrderDetails.SelectedIndex != 2 || e.KeyCode != Keys.Return)
          return;
        this.ProductSearch();
      }
    }

    private void UCOrder_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
      FSM.Entity.Sys.Enums.SecuritySystemModules ssm = FSM.Entity.Sys.Enums.SecuritySystemModules.POUnlock;
      if (!App.loggedInUser.HasAccessToModule(ssm))
        return;
      this.chkRevertStatus.Visible = true;
    }

    private void cboOrderTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.pnlDetails.Controls.Count > 0)
        this.pnlDetails.Controls.Clear();
      string Left = Combo.get_GetSelectedItemValue(this.cboOrderTypeID);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
        this.pnlDetails.Controls.Add((Control) this.ucCustomerOrder);
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
        this.pnlDetails.Controls.Add((Control) this.ucJobOrder);
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
        this.pnlDetails.Controls.Add((Control) this.ucWarehouseOrder);
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
      {
        if (this._currentOrder.Exists)
          this.pnlDetails.Controls.Add((Control) this.ucVanOrder);
        else
          this.pnlDetails.Controls.Add((Control) this.ucVanOrder);
      }
      else
      {
        this.lblOrderStatus.Text = this.CurrentOrder != null ? (!this.CurrentOrder.Exists ? "SAVE BASE ORDER DETAILS BEFORE MANAGING ITEMS" : "PICK WHAT THE ORDER IS FOR") : "SAVE BASE ORDER DETAILS BEFORE MANAGING ITEMS";
        this.lblOrderStatus.Visible = true;
        return;
      }
      this.OrderNumber = this.OrderNumber;
      switch (this.CurrentOrder.OrderStatusID)
      {
        case 1:
          this.lblOrderStatus.Text = "ORDER AWAITING CONFIRMATION FROM CUSTOMER";
          this.lblOrderStatus.Visible = true;
          break;
        case 2:
        case 7:
          this.DisableFields();
          this.btnCharges.Enabled = true;
          this.lblOrderStatus.Text = "ORDER WAITING FOR ITEMS RECEIVED";
          this.lblOrderStatus.Visible = true;
          break;
        case 3:
          this.DisableFields();
          this.btnCharges.Enabled = false;
          this.lblOrderStatus.Text = "ORDER HAS BEEN CANCELLED (click to view)";
          this.lblOrderStatus.Visible = true;
          break;
        case 4:
          this.DisableFields();
          this.btnCharges.Enabled = false;
          this.lblOrderStatus.Text = "ORDER COMPLETE";
          this.lblOrderStatus.Visible = true;
          if (this.CurrentOrder.ExportedToSage)
          {
            Label lblOrderStatus;
            string str = (lblOrderStatus = this.lblOrderStatus).Text + " - (Invoiced and Sent to Sage)";
            lblOrderStatus.Text = str;
            break;
          }
          if (this.CurrentOrder.Invoiced)
          {
            Label lblOrderStatus;
            string str = (lblOrderStatus = this.lblOrderStatus).Text + " - (Invoiced)";
            lblOrderStatus.Text = str;
          }
          break;
        default:
          this.lblOrderStatus.Text = "";
          this.lblOrderStatus.Visible = false;
          break;
      }
      if (this.CurrentOrder.SentToSage)
      {
        Label lblOrderStatus;
        string str = (lblOrderStatus = this.lblOrderStatus).Text + " *Supplier Invoice(s) sent to Sage*";
        lblOrderStatus.Text = str;
      }
      else
      {
        Label lblOrderStatus;
        string str = (lblOrderStatus = this.lblOrderStatus).Text + " *Supplier Invoice NOT sent to Sage*";
        lblOrderStatus.Text = str;
      }
    }

    private void tcOrderDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.IsLoading || (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.tcOrderDetails.SelectedTab.Name, "tabDetails", false) <= 0U || Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboOrderTypeID)) != 0.0)
        return;
      int num = (int) App.ShowMessage("You must select an Order Type to continue.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      this.tcOrderDetails.SelectedTab = this.tabDetails;
    }

    private void chkDeadlineNA_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkDeadlineNA.Checked)
        this.dtpDeliveryDeadline.Enabled = false;
      else
        this.dtpDeliveryDeadline.Enabled = true;
    }

    private void cboOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      bool flag = false;
      if (!this.IsLoading)
      {
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboOrderStatus)) != 2.0 && this.CurrentOrder.OrderConsolidationID > 0)
        {
          int num = (int) App.ShowMessage("This order has been added to a consolidation so should be managed from there.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.IsLoading = true;
          ComboBox cboOrderStatus = this.cboOrderStatus;
          Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
          this.cboOrderStatus = cboOrderStatus;
          this.IsLoading = false;
          return;
        }
        string Left = Combo.get_GetSelectedItemValue(this.cboOrderStatus);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
        {
          string str = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDept));
          if (Helper.IsValidInteger((object) str) && Helper.MakeIntegerValid((object) str) <= 0)
          {
            int num = (int) App.ShowMessage("Department Reference Missing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.IsLoading = true;
            ComboBox cboOrderStatus = this.cboOrderStatus;
            Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
            this.cboOrderStatus = cboOrderStatus;
            this.IsLoading = false;
          }
          else
          {
            if (App.ShowMessage("Are you sure you want to confirm order? No changes can be made to the order once it has been confirmed.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
              this.IsLoading = true;
              ComboBox cboOrderStatus = this.cboOrderStatus;
              Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
              this.cboOrderStatus = cboOrderStatus;
              this.IsLoading = false;
              return;
            }
            if (this.ItemsIncludedDataView.Table.Rows.Count == 0)
            {
              int num = (int) App.ShowMessage("There are no items included on this order, Order cannot be marked as confirmed until items added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              this.IsLoading = true;
              ComboBox cboOrderStatus = this.cboOrderStatus;
              Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
              this.cboOrderStatus = cboOrderStatus;
              this.IsLoading = false;
              return;
            }
            if (this.CurrentOrder.OrderConsolidationID > 0)
            {
              if (App.ShowMessage("This order will be removed from the consolidation, are you sure you wish to confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
              {
                this.IsLoading = true;
                ComboBox cboOrderStatus = this.cboOrderStatus;
                Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
                this.cboOrderStatus = cboOrderStatus;
                this.IsLoading = false;
                return;
              }
              this.IsLoading = true;
              this.CurrentOrder.SetOrderStatusID = (object) 2;
              flag = true;
            }
            else
            {
              if (this.CurrentOrder.OrderStatusID != 2)
              {
                if (new OrderControl(this.CurrentOrder).IsWithinJobSpendLimit())
                  this.CurrentOrder.SetOrderStatusID = (object) 2;
                else if (App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.POAuthorisation))
                {
                  int num = (int) App.ShowMessage("Job cost capacity was exceeded when creating this purchase order!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  this.CurrentOrder.SetOrderStatusID = (object) 2;
                }
                else
                {
                  int num = (int) App.ShowMessage("Job cost capacity was exceeded when creating this purchase order!\r\n\r\nPlease note that this order is currently awaiting approval!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  this.CurrentOrder.SetOrderStatusID = (object) 7;
                }
              }
              if (this.CurrentOrder.OrderStatusID == 2 && this.CurrentOrder.OrderTypeID == 4)
              {
                int integer = Conversions.ToInteger(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]);
                EngineerVisit asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(integer, true);
                asObject.SetPartsToFit = (object) true;
                App.DB.EngineerVisits.Update(asObject, 0, true);
              }
              string orderReference = this.CurrentOrder.OrderReference;
              if (orderReference.ToLower().EndsWith("f"))
                this.CurrentOrder.SetOrderReference = (object) this.CurrentOrder.OrderReference.Trim().Remove(checked (orderReference.Length - 1));
              if (this.CurrentOrder.OrderTypeID == 4)
              {
                int integer = Conversions.ToInteger(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["SiteID"]);
                if (App.DB.Customer.Customer_Get_ForSiteID(integer).IsPFH && App.DB.Supplier.Supplier_GetSecondaryPrice(this.SupplierUsedID))
                  this.CurrentOrder.SetOrderReference = (object) (this.CurrentOrder.OrderReference + "F");
              }
            }
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
        {
          if (this.CurrentOrder.OrderStatusID != 3)
          {
            if (App.ShowMessage("Are you sure you want to cancel this order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              App.ShowForm(typeof (FRMOrderRejection), true, new object[2]
              {
                (object) this,
                (object) ""
              }, false);
              if (this.dgvReceivedInvoices.RowCount > 0)
              {
                int num = (int) App.ShowMessage("You can not cancel this order as Invoices have been received", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.IsLoading = true;
                ComboBox cboOrderStatus = this.cboOrderStatus;
                Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
                this.cboOrderStatus = cboOrderStatus;
                this.IsLoading = false;
                return;
              }
              if (this.Reason.Trim().Length == 0)
              {
                this.IsLoading = true;
                ComboBox cboOrderStatus = this.cboOrderStatus;
                Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
                this.cboOrderStatus = cboOrderStatus;
                this.IsLoading = false;
                return;
              }
              if (this.CurrentOrder.OrderTypeID == 4)
              {
                DataTable table = App.DB.Order.OrderPart_GetForOrder(this.CurrentOrder.OrderID).Table;
                IEnumerator enumerator;
                try
                {
                  enumerator = table.Rows.GetEnumerator();
                  while (enumerator.MoveNext())
                  {
                    DataRow current = (DataRow) enumerator.Current;
                    App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Delete tblengineerVisitPartAllocated where orderpartid = ", current["OrderPartID"])), true, false);
                  }
                }
                finally
                {
                  if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
                }
              }
              App.DB.PartTransaction.DeleteForOrder(this.CurrentOrder.OrderID);
              App.DB.ProductTransaction.DeleteForOrder(this.CurrentOrder.OrderID);
              this.CurrentOrder.SetReasonForReject = (object) this.Reason;
              this.CurrentOrder.SetOrderStatusID = (object) 3;
            }
            else
            {
              this.IsLoading = true;
              ComboBox cboOrderStatus = this.cboOrderStatus;
              Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
              this.cboOrderStatus = cboOrderStatus;
              this.IsLoading = false;
              return;
            }
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
        {
          string str = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDept));
          if (Helper.IsValidInteger((object) str) && Helper.MakeIntegerValid((object) str) <= 0)
          {
            int num = (int) App.ShowMessage("Department Reference Missing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.IsLoading = true;
            ComboBox cboOrderStatus = this.cboOrderStatus;
            Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
            this.cboOrderStatus = cboOrderStatus;
            this.IsLoading = false;
          }
          else if (this.CurrentOrder.OrderStatusID == 1)
          {
            int num = (int) App.ShowMessage("You cannot complete an order manually.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.IsLoading = true;
            ComboBox cboOrderStatus = this.cboOrderStatus;
            Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
            this.cboOrderStatus = cboOrderStatus;
            this.IsLoading = false;
            return;
          }
        }
        this.CurrentOrder.SetDepartmentRef = (object) Combo.get_GetSelectedItemValue(this.cboDept);
        App.DB.Order.Update(this.CurrentOrder);
        if (flag)
          App.DB.OrderConsolidations.Order_Set_Consolidated(this.CurrentOrder.OrderConsolidationID, this.CurrentOrder.OrderID, true);
        this.IsLoading = true;
        this.CurrentOrder = App.DB.Order.Order_Get(this.CurrentOrder.OrderID);
      }
      if (this.CurrentOrder != null)
      {
        if (this.CurrentOrder.OrderStatusID == 1 | this.CurrentOrder.OrderStatusID == 7 | this.CurrentOrder.OrderStatusID == 0)
        {
          this.txtOrderReference.Visible = false;
          this.btnUpdateOrderRef.Visible = false;
        }
        else
        {
          this.txtOrderReference.Visible = true;
          this.btnUpdateOrderRef.Visible = true;
        }
      }
      else
      {
        this.txtOrderReference.Visible = false;
        this.btnUpdateOrderRef.Visible = false;
      }
    }

    public void ReasonChanged(string Reason)
    {
      this.Reason = Reason;
    }

    private void lblOrderStatus_Click(object sender, EventArgs e)
    {
      if (this.CurrentOrder.OrderStatusID != 3)
        return;
      App.ShowForm(typeof (FRMOrderRejection), true, new object[2]
      {
        (object) this,
        (object) this.CurrentOrder.ReasonForReject
      }, false);
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      this.Print();
    }

    private void btnEmail_Click(object sender, EventArgs e)
    {
      this.Email();
    }

    private void btnCharges_Click(object sender, EventArgs e)
    {
      if (this.CurrentOrder.OrderID == 0)
      {
        int num = (int) App.ShowMessage("You must save the order before adding additional charges", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        App.ShowForm(typeof (FRMOrderCharges), true, new object[1]
        {
          (object) this.CurrentOrder.OrderID
        }, false);
        this.PopulateOrderTotal();
      }
    }

    private void btnCreatePartRequest_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(FSM.Entity.Sys.Enums.TableNames.tblSupplier, 0, "", false));
      try
      {
        if ((uint) integer <= 0U)
          return;
        this.Cursor = Cursors.WaitCursor;
        PartSupplierPriceRequest oPartSupplierPriceRequest = new PartSupplierPriceRequest();
        oPartSupplierPriceRequest.IgnoreExceptionsOnSetMethods = true;
        oPartSupplierPriceRequest.SetPartID = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["PartID"]);
        oPartSupplierPriceRequest.SetQuantityInPack = (object) this.txtPartQuantity.Text.Trim();
        oPartSupplierPriceRequest.SetOrderID = (object) this.CurrentOrder.OrderID;
        oPartSupplierPriceRequest.SetSupplierID = (object) integer;
        oPartSupplierPriceRequest.SetComplete = (object) 0;
        new PartSupplierPriceRequestValidator().Validate(oPartSupplierPriceRequest);
        App.DB.PartPriceRequest.InsertForOrder(oPartSupplierPriceRequest);
        this.RefreshDataGrids();
        this.PartSearch();
        this.ProductSearch();
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
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void btnCreateProductPriceRequest_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(FSM.Entity.Sys.Enums.TableNames.tblSupplier, 0, "", false));
      try
      {
        if ((uint) integer <= 0U)
          return;
        this.Cursor = Cursors.WaitCursor;
        ProductSupplierPriceRequest oProductSupplierPriceRequest = new ProductSupplierPriceRequest();
        oProductSupplierPriceRequest.IgnoreExceptionsOnSetMethods = true;
        oProductSupplierPriceRequest.SetProductID = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["ProductID"]);
        oProductSupplierPriceRequest.SetQuantityInPack = (object) this.txtProductQuantity.Text.Trim();
        oProductSupplierPriceRequest.SetOrderID = (object) this.CurrentOrder.OrderID;
        oProductSupplierPriceRequest.SetSupplierID = (object) integer;
        oProductSupplierPriceRequest.SetComplete = (object) 0;
        new ProductSupplierPriceRequestValidator().Validate(oProductSupplierPriceRequest);
        App.DB.ProductPriceRequest.InsertForOrder(oProductSupplierPriceRequest);
        this.PartSearch();
        this.ProductSearch();
        this.RefreshDataGrids();
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
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void dgPriceRequests_Click(object sender, EventArgs e)
    {
      if (this.SelectedPriceRequestDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select item to update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.btnUpdatePartPriceRequest.Enabled = false;
      }
      else
        this.btnUpdatePartPriceRequest.Enabled = true;
    }

    private void btnUpdatePartPriceRequest_Click(object sender, EventArgs e)
    {
      if (this.SelectedPriceRequestDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select an item to update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.btnUpdatePartPriceRequest.Enabled = false;
      }
      else
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedPriceRequestDataRow["Type"], (object) "Part", false))
          App.ShowForm(typeof (FRMAddtoOrder), true, new object[4]
          {
            (object) this.CurrentOrder,
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
          App.ShowForm(typeof (FRMAddtoOrder), true, new object[4]
          {
            (object) this.CurrentOrder,
            null,
            (object) new ProductSupplier()
            {
              SetProductID = RuntimeHelpers.GetObjectValue(this.SelectedPriceRequestDataRow["PartProductID"]),
              SetSupplierID = RuntimeHelpers.GetObjectValue(this.SelectedPriceRequestDataRow["SupplierID"]),
              SetQuantityInPack = RuntimeHelpers.GetObjectValue(this.SelectedPriceRequestDataRow["QuantityInPack"])
            },
            this.SelectedPriceRequestDataRow["ID"]
          }, false);
        this.RefreshDataGrids();
        this.PartSearch();
        this.ProductSearch();
      }
    }

    private void cboTaxCode_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Calculate_Tax();
    }

    private void cboCreditTaxCode_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Calculate_Tax2();
    }

    private void dgvReceivedInvoices_CellClick(object sender, EventArgs e)
    {
      this.btnUpdateSupplierInvoice.Visible = true;
      this.btnDeleteSupplierInvoice.Visible = true;
      int integer = Conversions.ToInteger(this.dgvReceivedInvoices["SupplierInvoiceID", this.dgvReceivedInvoices.CurrentRow.Index].Value);
      DataTable table = App.DB.SupplierInvoices.Order_GetSupplierInvoice(integer).ToTable();
      DateTime t1 = DateTime.MinValue;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierInvoiceDate"])))
        t1 = Conversions.ToDate(table.Rows[0]["SupplierInvoiceDate"]);
      this.dtpSupplierInvoiceDateNew.Value = DateTime.Compare(t1, DateTime.MinValue) != 0 ? t1 : DateAndTime.Now;
      string str1 = (string) null;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierInvoiceReference"])))
        str1 = Conversions.ToString(table.Rows[0]["SupplierInvoiceReference"]);
      this.txtSupplierInvoiceRefNew.Text = str1;
      string str2 = (string) null;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["ExtraRef"])))
        str2 = Conversions.ToString(table.Rows[0]["ExtraRef"]);
      this.txtExtraReferenceNew.Text = str2;
      string str3 = (string) null;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["NominalCode"])))
        str3 = Conversions.ToString(table.Rows[0]["NominalCode"]);
      this.txtNominalCodeNew.Text = str3;
      double num1 = 0.0;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierGoodsAmount"])))
        num1 = Conversions.ToDouble(table.Rows[0]["SupplierGoodsAmount"]);
      this.txtTotalAmount.Text = Microsoft.VisualBasic.Strings.Format((object) num1, "C");
      double num2 = 0.0;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierVATAmount"])))
        num2 = Conversions.ToDouble(table.Rows[0]["SupplierVATAmount"]);
      this.txtVATAmount.Text = Microsoft.VisualBasic.Strings.Format((object) num2, "C");
      double num3 = 0.0;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierInvoiceAmount"])))
        num3 = Conversions.ToDouble(table.Rows[0]["SupplierInvoiceAmount"]);
      this.txtGoodsAmount.Text = Microsoft.VisualBasic.Strings.Format((object) num3, "C");
      this.cboInvoiceTaxCodeNew.SelectedValue = (object) null;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["TaxCodeID"])))
      {
        ComboBox invoiceTaxCodeNew = this.cboInvoiceTaxCodeNew;
        Combo.SetSelectedComboItem_By_Value(ref invoiceTaxCodeNew, Conversions.ToString(table.Rows[0]["TaxCodeID"]));
        this.cboInvoiceTaxCodeNew = invoiceTaxCodeNew;
      }
      this.cboInvoiceTaxCodeNew.SelectedValue = RuntimeHelpers.GetObjectValue(table.Rows[0]["TaxCodeID"]);
      if (!App.IsGasway)
      {
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(table.Rows[0]["RequiresAuthorisation"], (object) true, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(table.Rows[0]["Authorised"], (object) true, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(table.Rows[0]["RequiresAuthorisation"], (object) false, false))))
          this.cboReadySageNew.Enabled = true;
        else
          this.cboReadySageNew.Enabled = false;
      }
      this.btnAddSupplierInvoice.Text = "New";
      if (Conversions.ToBoolean(table.Rows[0]["SentToSage"]))
      {
        this.dtpSupplierInvoiceDateNew.Enabled = false;
        this.txtSupplierInvoiceRefNew.ReadOnly = true;
        this.txtExtraReferenceNew.ReadOnly = true;
        this.txtNominalCodeNew.ReadOnly = true;
        this.txtGoodsAmount.ReadOnly = true;
        this.txtVATAmount.ReadOnly = true;
        this.txtTotalAmount.ReadOnly = true;
        this.cboInvoiceTaxCodeNew.Enabled = false;
        this.btnUpdateSupplierInvoice.Enabled = false;
        this.btnDeleteSupplierInvoice.Enabled = false;
      }
      else
      {
        this.dtpSupplierInvoiceDateNew.Enabled = true;
        this.txtSupplierInvoiceRefNew.ReadOnly = false;
        this.txtExtraReferenceNew.ReadOnly = false;
        this.txtNominalCodeNew.ReadOnly = false;
        this.txtGoodsAmount.ReadOnly = false;
        this.txtVATAmount.ReadOnly = false;
        this.txtTotalAmount.ReadOnly = false;
        this.cboInvoiceTaxCodeNew.Enabled = true;
        this.btnUpdateSupplierInvoice.Enabled = true;
        this.btnDeleteSupplierInvoice.Enabled = true;
      }
    }

    private void dgCredits_CellClick(object sender, EventArgs e)
    {
      this.btnCreditAdd.Visible = true;
      this.btnCreditDelete.Visible = true;
      if (this.dgCredits["DateReceived", this.dgCredits.CurrentRow.Index].Value.ToString().Length == 0)
        return;
      int integer = Conversions.ToInteger(this.dgCredits["PartCreditsID", this.dgCredits.CurrentRow.Index].Value);
      DataTable table = App.DB.PartsToBeCredited.PartsToBeCredited_Get_Parts_For_CreditID(integer).Table;
      DateTime t1 = DateTime.MinValue;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["DateReceived"])))
        t1 = Conversions.ToDate(table.Rows[0]["DateReceived"]);
      this.dtpCreditDate.Value = DateTime.Compare(t1, DateTime.MinValue) != 0 ? t1 : DateAndTime.Now;
      string str1 = (string) null;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierCreditRef"])))
        str1 = Conversions.ToString(table.Rows[0]["SupplierCreditRef"]);
      this.txtCreditRef.Text = str1;
      string str2 = (string) null;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["ExtraRef"])))
        str2 = Conversions.ToString(table.Rows[0]["ExtraRef"]);
      this.txtCreditExRef.Text = str2;
      string str3 = (string) null;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["NominalCode"])))
        str3 = Conversions.ToString(table.Rows[0]["NominalCode"]);
      this.txtCreditNominal.Text = str3;
      this.cboCreditTax.SelectedValue = (object) null;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["TaxCodeID"])))
      {
        ComboBox cboCreditTax = this.cboCreditTax;
        Combo.SetSelectedComboItem_By_Value(ref cboCreditTax, Conversions.ToString(table.Rows[0]["TaxCodeID"]));
        this.cboCreditTax = cboCreditTax;
      }
      this.cboCreditTax.SelectedValue = RuntimeHelpers.GetObjectValue(table.Rows[0]["TaxCodeID"]);
      double num = 0.0;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["AmountReceived"])))
        num = Conversions.ToDouble(table.Rows[0]["AmountReceived"]);
      this.txtCreditGoods.Text = Microsoft.VisualBasic.Strings.Format((object) num, "C");
      this.Calculate_Tax2();
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table.Rows[0]["DateExportedToSage"])))
      {
        this.dtpCreditDate.Enabled = false;
        this.txtCreditRef.ReadOnly = true;
        this.txtCreditExRef.ReadOnly = true;
        this.txtCreditNominal.ReadOnly = true;
        this.txtCreditGoods.ReadOnly = true;
        this.txtCreditVAT.ReadOnly = true;
        this.txtCreditTotal.ReadOnly = true;
        this.cboCreditTax.Enabled = false;
        this.btnCreditAdd.Enabled = false;
        this.btnCreditDelete.Enabled = false;
      }
      else
      {
        this.dtpCreditDate.Enabled = true;
        this.txtCreditRef.ReadOnly = false;
        this.txtCreditExRef.ReadOnly = false;
        this.txtCreditNominal.ReadOnly = false;
        this.txtCreditGoods.ReadOnly = false;
        this.txtCreditVAT.ReadOnly = false;
        this.txtCreditTotal.ReadOnly = false;
        this.cboCreditTax.Enabled = true;
        this.btnCreditAdd.Enabled = true;
        this.btnCreditDelete.Enabled = true;
      }
    }

    private void btnAddSupplierInvoice_Click(object sender, EventArgs e)
    {
      if (this.CurrentOrder.OrderTypeID == 0)
      {
        int num1 = (int) App.ShowMessage("You must save your order details before continuing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.btnAddSupplierInvoice.Text, "New", false) == 0)
      {
        this.btnAddSupplierInvoice.Text = "Add";
        this.dtpSupplierInvoiceDateNew.Value = DateAndTime.Now;
        this.txtSupplierInvoiceRefNew.Text = (string) null;
        this.txtExtraReferenceNew.Text = (string) null;
        this.txtNominalCodeNew.Text = (string) null;
        this.txtGoodsAmount.Text = (string) null;
        this.txtVATAmount.Text = (string) null;
        this.txtTotalAmount.Text = (string) null;
        ComboBox invoiceTaxCodeNew = this.cboInvoiceTaxCodeNew;
        Combo.SetSelectedComboItem_By_Value(ref invoiceTaxCodeNew, (string) null);
        this.cboInvoiceTaxCodeNew = invoiceTaxCodeNew;
        this.cboReadySageNew.Checked = false;
        this.dtpSupplierInvoiceDateNew.Enabled = true;
        this.txtSupplierInvoiceRefNew.ReadOnly = false;
        this.txtExtraReferenceNew.ReadOnly = false;
        this.txtNominalCodeNew.ReadOnly = false;
        this.txtGoodsAmount.ReadOnly = false;
        this.txtVATAmount.ReadOnly = false;
        this.txtTotalAmount.ReadOnly = false;
        this.cboInvoiceTaxCodeNew.Enabled = true;
        this.cboReadySageNew.Enabled = true;
      }
      else if (this.ValidateSupplierInvoice(false))
      {
        SupplierInvoice oSupplierInvoice = new SupplierInvoice();
        oSupplierInvoice.SetOrderID = (object) this.CurrentOrder.OrderID;
        oSupplierInvoice.SetInvoiceReference = (object) this.txtSupplierInvoiceRefNew.Text;
        oSupplierInvoice.SetInvoiceDate = (object) this.dtpSupplierInvoiceDateNew.Value;
        oSupplierInvoice.SetGoodsAmount = (object) Microsoft.VisualBasic.Strings.Replace(this.txtTotalAmount.Text, "£", "", 1, -1, CompareMethod.Binary);
        oSupplierInvoice.SetVATAmount = (object) Microsoft.VisualBasic.Strings.Replace(this.txtVATAmount.Text, "£", "", 1, -1, CompareMethod.Binary);
        oSupplierInvoice.SetTotalAmount = (object) Microsoft.VisualBasic.Strings.Replace(this.txtGoodsAmount.Text, "£", "", 1, -1, CompareMethod.Binary);
        oSupplierInvoice.SetTaxCodeID = (object) Combo.get_GetSelectedItemValue(this.cboInvoiceTaxCodeNew);
        oSupplierInvoice.SetNominalCode = (object) this.txtNominalCodeNew.Text;
        oSupplierInvoice.SetExtraRef = (object) this.txtExtraReferenceNew.Text;
        oSupplierInvoice.SetReadyToSendToSage = (object) this.cboReadySageNew.Checked;
        oSupplierInvoice.SetSentToSage = (object) 0;
        oSupplierInvoice.SetOldSystemInvoice = (object) 0;
        oSupplierInvoice.SetDateExported = (object) null;
        oSupplierInvoice.SetKeyedBy = (object) App.loggedInUser.UserID;
        try
        {
          App.DB.SupplierInvoices.Insert(oSupplierInvoice);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("An error has occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        this.RefreshDataGrids();
        this.PopulateOrderTotal();
        this.txtSupplierInvoiceRefNew.Text = (string) null;
        this.txtExtraReferenceNew.Text = (string) null;
        this.txtNominalCodeNew.Text = (string) null;
        this.txtGoodsAmount.Text = (string) null;
        this.txtVATAmount.Text = (string) null;
        this.txtTotalAmount.Text = (string) null;
        ComboBox invoiceTaxCodeNew = this.cboInvoiceTaxCodeNew;
        Combo.SetSelectedComboItem_By_Value(ref invoiceTaxCodeNew, (string) null);
        this.cboInvoiceTaxCodeNew = invoiceTaxCodeNew;
      }
    }

    private void btnCreditAdd_Click(object sender, EventArgs e)
    {
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.btnCreditAdd.Text, "New", false) == 0)
      {
        this.btnCreditAdd.Text = "Add";
        this.dtpCreditDate.Value = DateAndTime.Now;
        this.txtCreditRef.Text = (string) null;
        this.txtCreditExRef.Text = (string) null;
        this.txtCreditNominal.Text = (string) null;
        this.txtCreditGoods.Text = (string) null;
        this.txtCreditVAT.Text = (string) null;
        this.txtCreditTotal.Text = (string) null;
        ComboBox cboCreditTax = this.cboCreditTax;
        Combo.SetSelectedComboItem_By_Value(ref cboCreditTax, (string) null);
        this.cboCreditTax = cboCreditTax;
        this.dtpCreditDate.Enabled = true;
        this.txtCreditRef.ReadOnly = false;
        this.txtCreditExRef.ReadOnly = false;
        this.txtCreditNominal.ReadOnly = false;
        this.txtCreditGoods.ReadOnly = false;
        this.txtCreditVAT.ReadOnly = false;
        this.txtCreditTotal.ReadOnly = false;
        this.cboCreditTax.Enabled = true;
      }
      else if (this.ValidateCreditInvoice(false))
      {
        DataView dataView = new DataView();
        using (FRMPartsForCreditList partsForCreditList = new FRMPartsForCreditList(this.CurrentOrder.OrderID, false, true))
        {
          int num = (int) partsForCreditList.ShowDialog();
          dataView = partsForCreditList.RatesDataview;
        }
        DataTable dataTable = new DataTable();
        PartsToBeCredited oPartsToBeCredited = new PartsToBeCredited();
        if (dataView.Table.Select("tick = 1 AND QtyToCredit > 0").Length > 0)
        {
          DataRow[] dataRowArray = dataView.Table.Select("tick = 1 AND QtyToCredit > 0");
          int index = 0;
          while (index < dataRowArray.Length)
          {
            DataRow dataRow = dataRowArray[index];
            oPartsToBeCredited = new PartsToBeCredited();
            oPartsToBeCredited.SetOrderID = (object) this.CurrentOrder.OrderID;
            oPartsToBeCredited.SetOrderReference = (object) this.CurrentOrder.OrderReference;
            oPartsToBeCredited.SetPartID = RuntimeHelpers.GetObjectValue(dataRow["PartProductID"]);
            oPartsToBeCredited.SetQty = RuntimeHelpers.GetObjectValue(dataRow["QtyToCredit"]);
            oPartsToBeCredited.SetCreditReceived = (object) Conversions.ToDouble(this.txtCreditGoods.Text.Replace("£", ""));
            oPartsToBeCredited.SetStatusID = (object) 3;
            oPartsToBeCredited.SetSupplierID = (object) this.SupplierUsedID;
            oPartsToBeCredited.SetPartOrderID = RuntimeHelpers.GetObjectValue(dataRow["ID"]);
            dataTable = App.DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(Conversions.ToInteger(dataRow["ID"])).Table;
            if (dataTable.Rows.Count > 0 && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreditReceived"])))
            {
              oPartsToBeCredited.SetPartsToBeCreditedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartsToBeCreditedID"]);
              App.DB.PartsToBeCredited.Update(oPartsToBeCredited);
            }
            else
              oPartsToBeCredited = App.DB.PartsToBeCredited.Insert(oPartsToBeCredited);
            checked { ++index; }
          }
          if (dataTable.Rows.Count == 0 || !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreditReceived"])))
          {
            int num = App.DB.PartsToBeCredited.PartCredits_Insert(Conversions.ToDouble(this.txtCreditGoods.Text.Replace("£", "")), "", this.dtpCreditDate.Value, DateTime.MinValue, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboCreditTax)), this.txtCreditNominal.Text, this.CurrentOrder.DepartmentRef, this.txtCreditExRef.Text, this.txtCreditRef.Text);
            App.DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" + Conversions.ToString(num) + "," + Conversions.ToString(oPartsToBeCredited.PartsToBeCreditedID) + ")", true, false);
          }
          else
            App.DB.PartsToBeCredited.PartCredits_Update(Conversions.ToInteger(dataTable.Rows[0]["PartCreditsID"]), Conversions.ToDouble(this.txtCreditGoods.Text), "", this.dtpCreditDate.Value, DateTime.MinValue, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboCreditTax)), this.txtCreditNominal.Text, this.CurrentOrder.DepartmentRef, this.txtCreditExRef.Text, this.txtCreditRef.Text);
          this.RefreshDataGrids();
          this.PopulateOrderTotal();
        }
      }
    }

    private void btnUpdateSupplierInvoice_Click(object sender, EventArgs e)
    {
      if (!this.ValidateSupplierInvoice(true))
        return;
      SupplierInvoice oSupplierInvoice = new SupplierInvoice();
      oSupplierInvoice.SetOrderID = (object) this.CurrentOrder.OrderID;
      oSupplierInvoice.SetInvoiceReference = (object) this.txtSupplierInvoiceRefNew.Text;
      oSupplierInvoice.SetInvoiceDate = (object) this.dtpSupplierInvoiceDateNew.Value;
      oSupplierInvoice.SetGoodsAmount = (object) Microsoft.VisualBasic.Strings.Replace(this.txtTotalAmount.Text, "£", "", 1, -1, CompareMethod.Binary);
      oSupplierInvoice.SetVATAmount = (object) Microsoft.VisualBasic.Strings.Replace(this.txtVATAmount.Text, "£", "", 1, -1, CompareMethod.Binary);
      oSupplierInvoice.SetTotalAmount = (object) Microsoft.VisualBasic.Strings.Replace(this.txtGoodsAmount.Text, "£", "", 1, -1, CompareMethod.Binary);
      oSupplierInvoice.SetTaxCodeID = (object) Combo.get_GetSelectedItemValue(this.cboInvoiceTaxCodeNew);
      oSupplierInvoice.SetNominalCode = (object) this.txtNominalCodeNew.Text;
      oSupplierInvoice.SetExtraRef = (object) this.txtExtraReferenceNew.Text;
      oSupplierInvoice.SetReadyToSendToSage = (object) this.cboReadySageNew.Checked;
      oSupplierInvoice.SetSentToSage = (object) 0;
      oSupplierInvoice.SetOldSystemInvoice = (object) 0;
      oSupplierInvoice.SetDateExported = (object) null;
      oSupplierInvoice.SetKeyedBy = (object) App.loggedInUser.UserID;
      int integer = Conversions.ToInteger(this.dgvReceivedInvoices["SupplierInvoiceID", this.dgvReceivedInvoices.CurrentRow.Index].Value);
      oSupplierInvoice.SetInvoiceID = (object) integer;
      try
      {
        App.DB.SupplierInvoices.Update(oSupplierInvoice);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("An error has occurred:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      this.dtpSupplierInvoiceDateNew.Value = DateAndTime.Now;
      this.txtSupplierInvoiceRefNew.Text = (string) null;
      this.txtExtraReferenceNew.Text = (string) null;
      this.txtNominalCodeNew.Text = (string) null;
      this.txtGoodsAmount.Text = (string) null;
      this.txtVATAmount.Text = (string) null;
      this.txtTotalAmount.Text = (string) null;
      ComboBox invoiceTaxCodeNew = this.cboInvoiceTaxCodeNew;
      Combo.SetSelectedComboItem_By_Value(ref invoiceTaxCodeNew, (string) null);
      this.cboInvoiceTaxCodeNew = invoiceTaxCodeNew;
      this.cboReadySageNew.Checked = false;
      this.RefreshDataGrids();
      this.PopulateOrderTotal();
    }

    private void btnDeleteSupplierInvoice_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(this.dgvReceivedInvoices["SupplierInvoiceID", this.dgvReceivedInvoices.CurrentRow.Index].Value);
      App.DB.SupplierInvoices.Delete(integer);
      this.dtpSupplierInvoiceDateNew.Value = DateAndTime.Now;
      this.txtSupplierInvoiceRefNew.Text = (string) null;
      this.txtExtraReferenceNew.Text = (string) null;
      this.txtNominalCodeNew.Text = (string) null;
      this.txtGoodsAmount.Text = (string) null;
      this.txtVATAmount.Text = (string) null;
      this.txtTotalAmount.Text = (string) null;
      ComboBox invoiceTaxCodeNew = this.cboInvoiceTaxCodeNew;
      Combo.SetSelectedComboItem_By_Value(ref invoiceTaxCodeNew, (string) null);
      this.cboInvoiceTaxCodeNew = invoiceTaxCodeNew;
      this.cboReadySageNew.Checked = false;
      this.RefreshDataGrids();
      this.PopulateOrderTotal();
      this.btnAddSupplierInvoice.Text = "Add";
    }

    private void btnDeleteCredit_Click(object sender, EventArgs e)
    {
      int CreditID = 0;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.dgCredits["PartCreditsID", this.dgCredits.CurrentRow.Index].Value)))
        CreditID = Conversions.ToInteger(this.dgCredits["PartCreditsID", this.dgCredits.CurrentRow.Index].Value);
      int num1 = 0;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.dgCredits["OrderPartID", this.dgCredits.CurrentRow.Index].Value)))
        num1 = Conversions.ToInteger(this.dgCredits["OrderPartID", this.dgCredits.CurrentRow.Index].Value);
      int num2 = 0;
      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.dgCredits["PartsToBeCreditedID", this.dgCredits.CurrentRow.Index].Value)))
        num2 = Conversions.ToInteger(this.dgCredits["PartsToBeCreditedID", this.dgCredits.CurrentRow.Index].Value);
      if (num2 > 0)
        App.DB.ExecuteScalar("Delete From tblPartstobeCredited where PartsToBeCreditedID = " + Conversions.ToString(num2), true, false);
      else if (CreditID > 0)
        App.DB.PartsToBeCredited.Delete(CreditID);
      else if (num1 > 0)
      {
        App.DB.ExecuteScalar("Delete From tblPartstobeCredited where OrderPartID = " + Conversions.ToString(num1), true, false);
        App.DB.ExecuteScalar("Delete From tblPArtDistributed Where OrderPartID = " + Conversions.ToString(num1), true, false);
        App.DB.ExecuteScalar("UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 0,CreditQty = 0 WHERE ORDERPARTID = " + Conversions.ToString(num1), true, false);
      }
      this.dtpCreditDate.Value = DateAndTime.Now;
      this.txtCreditRef.Text = (string) null;
      this.txtCreditExRef.Text = (string) null;
      this.txtCreditNominal.Text = (string) null;
      this.txtCreditGoods.Text = (string) null;
      this.txtCreditVAT.Text = (string) null;
      this.txtCreditTotal.Text = (string) null;
      ComboBox cboCreditTax = this.cboCreditTax;
      Combo.SetSelectedComboItem_By_Value(ref cboCreditTax, (string) null);
      this.cboCreditTax = cboCreditTax;
      this.RefreshDataGrids();
      this.PopulateOrderTotal();
    }

    private void cboPartLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.PartsDataView != null)
        this.PartsDataView.Table.Rows.Clear();
      this.UpdatePartSearchOptions();
    }

    private void btnAddNewPart_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMPart), true, new object[2]
      {
        (object) 0,
        (object) true
      }, false);
      this.PartSearch();
    }

    private void btnPartSearch_Click(object sender, EventArgs e)
    {
      this.PartSearch();
    }

    private void dgParts_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedPartDataRow == null || !App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.CreateParts))
        return;
      if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["IsPartPack"])))
        App.ShowForm(typeof (FRMPartPack), true, new object[3]
        {
          (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["PartID"])),
          (object) true,
          (object) true
        }, false);
      else
        App.ShowForm(typeof (FRMPart), true, new object[2]
        {
          (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["PartID"])),
          (object) true
        }, false);
    }

    private void dgParts_Click(object sender, EventArgs e)
    {
      this.UpdatePartSearchOptions();
      if (this.SelectedPartDataRow == null)
        return;
      string Left = Combo.get_GetSelectedItemValue(this.cboPartLocation);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
      {
        this.txtPartQuantity.Text = Conversions.ToString(1);
        this.txtPartQuantity.ReadOnly = false;
        this.txtPartBuyPrice.Text = "N/A";
        this.txtPartBuyPrice.ReadOnly = true;
        this.btnAddPart.Enabled = true;
        this.btnCreatePartRequest.Enabled = false;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
      {
        this.txtPartQuantity.Text = Conversions.ToString(1);
        this.txtPartQuantity.ReadOnly = false;
        this.txtPartBuyPrice.Text = "N/A";
        this.txtPartBuyPrice.ReadOnly = true;
        this.btnAddPart.Enabled = true;
        this.btnCreatePartRequest.Enabled = false;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
      {
        this.txtPartBuyPrice.Enabled = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["IsPartPack"]));
        this.txtPartQuantity.Text = "1";
        this.txtPartQuantity.ReadOnly = false;
        if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["SupplierID"])))
        {
          this.txtPartBuyPrice.Text = "N/A";
          this.txtPartBuyPrice.ReadOnly = true;
          this.btnAddPart.Enabled = false;
        }
        else
        {
          this.txtPartBuyPrice.Text = Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["Price"]), "F");
          this.txtPartBuyPrice.ReadOnly = false;
          this.btnAddPart.Enabled = true;
        }
        this.btnCreatePartRequest.Enabled = true;
      }
    }

    private void AddPartToOrder()
    {
      OrderPart oOrderPart = new OrderPart();
      oOrderPart.IgnoreExceptionsOnSetMethods = true;
      oOrderPart.SetOrderID = (object) this.CurrentOrder.OrderID;
      oOrderPart.SetPartSupplierID = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["PartSupplierID"]);
      int integer = Conversions.ToInteger(this.SelectedPartDataRow["PartID"]);
      if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["IsSpecialPart"])))
      {
        FRMSpecialOrder frmSpecialOrder = new FRMSpecialOrder(Conversions.ToInteger(this.SelectedPartDataRow["PartSupplierID"]), Conversions.ToDouble(this.txtPartBuyPrice.Text.Trim()), Conversions.ToInteger(this.txtPartQuantity.Text.Trim()));
        int num = (int) frmSpecialOrder.ShowDialog();
        if (frmSpecialOrder.DialogResult != DialogResult.OK)
          return;
        oOrderPart.SetQuantity = (object) frmSpecialOrder.Quantity;
        oOrderPart.SetBuyPrice = (object) frmSpecialOrder.Price;
        oOrderPart.SetSpecialDescription = (object) frmSpecialOrder.PartName;
        oOrderPart.SetSpecialPartNumber = (object) frmSpecialOrder.SPN;
      }
      else
      {
        oOrderPart.SetQuantity = (object) this.txtPartQuantity.Text.Trim();
        oOrderPart.SetBuyPrice = (object) this.txtPartBuyPrice.Text.Trim();
      }
      oOrderPart.SetQuantityReceived = (object) 0;
      oOrderPart.SetChildSupplierID = (object) 0;
      int num1 = 0;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = App.DB.Part.Stock_Get_Locations(integer, 0).Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "WAREHOUSE", false) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual(current["Quantity"], (object) oOrderPart.Quantity, false))
          {
            num1 = Conversions.ToInteger(current["WarehouseID"]);
            break;
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if ((uint) num1 > 0U && App.ShowMessage("There is stock available in a warehouse, would you like to still order from supplier?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
      {
        ComboBox cboPartLocation = this.cboPartLocation;
        Combo.SetSelectedComboItem_By_Value(ref cboPartLocation, Conversions.ToString(3));
        this.cboPartLocation = cboPartLocation;
        this.PartSearch();
        int row = 0;
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.PartsDataView.Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["WarehouseID"], (object) num1, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["PartID"], (object) integer, false))))
              checked { ++row; }
            else
              break;
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        this.dgParts.CurrentRowIndex = row;
        this.dgParts.Select(row);
        this.dgParts_Click((object) null, (EventArgs) null);
        this.txtPartQuantity.Text = Conversions.ToString(oOrderPart.Quantity);
      }
      else
      {
        new OrderPartValidator().Validate(oOrderPart);
        OrderPart orderPart = App.DB.OrderPart.Insert(oOrderPart, !this.CurrentOrder.DoNotConsolidated);
        if (this.CurrentOrder.OrderTypeID == 4)
          App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Part", orderPart.Quantity, orderPart.OrderPartID, Conversions.ToInteger(this.SelectedPartDataRow["PartID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPartLocation)));
        this.SupplierUsedID = Conversions.ToInteger(this.SelectedPartDataRow["SupplierID"]);
        this.LocationUsedID = 0;
      }
    }

    private void AddPackToOrder()
    {
      int num1 = Helper.MakeIntegerValid((object) this.txtPartQuantity.Text);
      if (num1 == 0)
        return;
      int SupplierID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["SupplierID"]));
      int PackID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["PartID"]));
      DataView dataView = App.DB.Part.PartPack_Get(PackID);
      IEnumerator enumerator;
      try
      {
        enumerator = dataView.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator.Current;
          int num2 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["PartID"]));
          DataView partIdAndSupplierId = App.DB.PartSupplier.Get_ByPartIDAndSupplierID(num2, SupplierID);
          if (partIdAndSupplierId.Count != 0)
          {
            OrderPart oOrderPart = new OrderPart();
            oOrderPart.IgnoreExceptionsOnSetMethods = true;
            oOrderPart.SetOrderID = (object) this.CurrentOrder.OrderID;
            oOrderPart.SetPartSupplierID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(partIdAndSupplierId[0]["PartSupplierID"]));
            oOrderPart.SetQuantity = (object) checked (num1 * Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Qty"])));
            oOrderPart.SetBuyPrice = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(partIdAndSupplierId[0]["Price"]));
            oOrderPart.SetQuantityReceived = (object) 0;
            oOrderPart.SetChildSupplierID = (object) 0;
            new OrderPartValidator().Validate(oOrderPart);
            OrderPart orderPart = App.DB.OrderPart.Insert(oOrderPart, !this.CurrentOrder.DoNotConsolidated);
            if (this.CurrentOrder.OrderTypeID == 4)
              App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Part", orderPart.Quantity, orderPart.OrderPartID, num2, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPartLocation)));
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.SupplierUsedID = SupplierID;
      this.LocationUsedID = 0;
    }

    private void btnAddPart_Click(object sender, EventArgs e)
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        FSM.Entity.Sys.Enums.SecuritySystemModules ssm1 = FSM.Entity.Sys.Enums.SecuritySystemModules.CreatePO;
        FSM.Entity.Sys.Enums.SecuritySystemModules ssm2 = FSM.Entity.Sys.Enums.SecuritySystemModules.EditPO;
        if (!(App.loggedInUser.HasAccessToModule(ssm1) | App.loggedInUser.HasAccessToModule(ssm2)))
          throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
        string Left = Combo.get_GetSelectedItemValue(this.cboPartLocation);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
        {
          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["IsPartPack"])))
            this.AddPackToOrder();
          else
            this.AddPartToOrder();
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
        {
          FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart = new FSM.Entity.OrderLocationPart.OrderLocationPart();
          oOrderLocationPart.IgnoreExceptionsOnSetMethods = true;
          oOrderLocationPart.SetOrderID = (object) this.CurrentOrder.OrderID;
          oOrderLocationPart.SetPartID = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["PartID"]);
          oOrderLocationPart.SetLocationID = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["LocationID"]);
          oOrderLocationPart.SetQuantity = (object) this.txtPartQuantity.Text.Trim();
          oOrderLocationPart.SetQuantityReceived = (object) 0;
          new OrderLocationPartValidator().Validate(oOrderLocationPart);
          FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, true);
          if (this.CurrentOrder.OrderTypeID == 4)
            App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Part", orderLocationPart.Quantity, orderLocationPart.OrderLocationPartID, Conversions.ToInteger(this.SelectedPartDataRow["PartID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPartLocation)));
          App.DB.PartTransaction.Insert(new PartTransaction()
          {
            IgnoreExceptionsOnSetMethods = true,
            SetOrderLocationPartID = (object) orderLocationPart.OrderLocationPartID,
            SetTransactionTypeID = (object) 5,
            SetPartID = (object) orderLocationPart.PartID,
            SetAmount = (object) checked (-orderLocationPart.Quantity),
            SetLocationID = (object) orderLocationPart.LocationID
          });
          this.LocationUsedID = orderLocationPart.LocationID;
          this.SupplierUsedID = 0;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
        {
          FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart = new FSM.Entity.OrderLocationPart.OrderLocationPart();
          oOrderLocationPart.IgnoreExceptionsOnSetMethods = true;
          oOrderLocationPart.SetOrderID = (object) this.CurrentOrder.OrderID;
          oOrderLocationPart.SetPartID = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["PartID"]);
          oOrderLocationPart.SetLocationID = RuntimeHelpers.GetObjectValue(this.SelectedPartDataRow["LocationID"]);
          oOrderLocationPart.SetQuantity = (object) this.txtPartQuantity.Text.Trim();
          oOrderLocationPart.SetQuantityReceived = (object) 0;
          new OrderLocationPartValidator().Validate(oOrderLocationPart);
          FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, true);
          if (this.CurrentOrder.OrderTypeID == 4)
            App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Part", orderLocationPart.Quantity, orderLocationPart.OrderLocationPartID, Conversions.ToInteger(this.SelectedPartDataRow["PartID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPartLocation)));
          App.DB.PartTransaction.Insert(new PartTransaction()
          {
            IgnoreExceptionsOnSetMethods = true,
            SetOrderLocationPartID = (object) orderLocationPart.OrderLocationPartID,
            SetTransactionTypeID = (object) 5,
            SetPartID = (object) orderLocationPart.PartID,
            SetAmount = (object) checked (-orderLocationPart.Quantity),
            SetLocationID = (object) orderLocationPart.LocationID
          });
          this.LocationUsedID = orderLocationPart.LocationID;
          this.SupplierUsedID = 0;
        }
        this.IsLoading = true;
        this.CurrentOrder = App.DB.Order.Order_Get(this.CurrentOrder.OrderID);
        this.RefreshDataGrids();
        this.PartSearch();
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
        int num = (int) App.ShowMessage("Part could not be added.\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
    }

    private void cboProductLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.ProductsDataView != null)
        this.ProductsDataView.Table.Rows.Clear();
      this.UpdateProductSearchOptions();
    }

    private void btnAddNewProduct_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMProduct), true, new object[2]
      {
        (object) 0,
        (object) true
      }, false);
      this.ProductSearch();
    }

    private void btnProductSearch_Click(object sender, EventArgs e)
    {
      this.ProductSearch();
    }

    private void dgProduct_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedProductDataRow == null)
        return;
      App.ShowForm(typeof (FRMProduct), true, new object[2]
      {
        (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["ProductID"])),
        (object) true
      }, false);
      this.ProductSearch();
    }

    private void dgProduct_Click(object sender, EventArgs e)
    {
      this.UpdateProductSearchOptions();
      if (this.SelectedProductDataRow == null)
        return;
      string Left = Combo.get_GetSelectedItemValue(this.cboProductLocation);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
      {
        this.txtProductQuantity.Text = Conversions.ToString(1);
        this.txtProductQuantity.ReadOnly = false;
        this.txtProductBuyPrice.Text = "N/A";
        this.txtProductBuyPrice.ReadOnly = true;
        if (this.CurrentOrder.OrderTypeID == 2 | this.CurrentOrder.OrderTypeID == 3)
        {
          this.txtProductSellPrice.Text = "N/A";
          this.txtProductSellPrice.ReadOnly = true;
        }
        else
        {
          this.txtProductSellPrice.Text = Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["SellPrice"]), "F");
          this.txtProductSellPrice.ReadOnly = false;
        }
        this.btnAddProduct.Enabled = true;
        this.btnCreateProductPriceRequest.Enabled = false;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
      {
        this.txtProductQuantity.Text = Conversions.ToString(1);
        this.txtProductQuantity.ReadOnly = false;
        this.txtProductBuyPrice.Text = "N/A";
        this.txtProductBuyPrice.ReadOnly = true;
        if (this.CurrentOrder.OrderTypeID == 2 | this.CurrentOrder.OrderTypeID == 3)
        {
          this.txtProductSellPrice.Text = "N/A";
          this.txtProductSellPrice.ReadOnly = true;
        }
        else
        {
          this.txtProductSellPrice.Text = Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["SellPrice"]), "F");
          this.txtProductSellPrice.ReadOnly = false;
        }
        this.btnAddProduct.Enabled = true;
        this.btnCreateProductPriceRequest.Enabled = false;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
      {
        this.txtProductQuantity.Text = "1";
        this.txtProductQuantity.ReadOnly = false;
        if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["SupplierID"])))
        {
          this.txtProductBuyPrice.Text = "N/A";
          this.txtProductBuyPrice.ReadOnly = true;
          this.txtProductSellPrice.Text = "N/A";
          this.txtProductSellPrice.ReadOnly = true;
          this.btnAddProduct.Enabled = false;
        }
        else
        {
          this.txtProductBuyPrice.Text = Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["Price"]), "F");
          this.txtProductBuyPrice.ReadOnly = false;
          if (this.CurrentOrder.OrderTypeID == 2 | this.CurrentOrder.OrderTypeID == 3)
          {
            this.txtProductSellPrice.Text = "N/A";
            this.txtProductSellPrice.ReadOnly = true;
          }
          else
          {
            this.txtProductSellPrice.Text = "";
            this.txtProductSellPrice.ReadOnly = false;
          }
          this.btnAddProduct.Enabled = true;
        }
        this.btnCreateProductPriceRequest.Enabled = true;
      }
    }

    private void btnAddProduct_Click(object sender, EventArgs e)
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        FSM.Entity.Sys.Enums.SecuritySystemModules ssm1 = FSM.Entity.Sys.Enums.SecuritySystemModules.EditPO;
        FSM.Entity.Sys.Enums.SecuritySystemModules ssm2 = FSM.Entity.Sys.Enums.SecuritySystemModules.CreatePO;
        if (!(App.loggedInUser.HasAccessToModule(ssm1) | App.loggedInUser.HasAccessToModule(ssm2)))
          throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
        string Left = Combo.get_GetSelectedItemValue(this.cboProductLocation);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
        {
          OrderProduct oOrderProduct = new OrderProduct();
          oOrderProduct.IgnoreExceptionsOnSetMethods = true;
          oOrderProduct.SetOrderID = (object) this.CurrentOrder.OrderID;
          oOrderProduct.SetProductSupplierID = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["ProductSupplierID"]);
          oOrderProduct.SetQuantity = (object) this.txtProductQuantity.Text.Trim();
          oOrderProduct.SetBuyPrice = (object) this.txtProductBuyPrice.Text.Trim();
          oOrderProduct.SetSellPrice = !this.txtProductSellPrice.ReadOnly ? (object) this.txtProductSellPrice.Text.Trim() : (object) 0.0;
          oOrderProduct.SetQuantityReceived = (object) 0;
          int num = 0;
          int integer = Conversions.ToInteger(this.SelectedProductDataRow["ProductID"]);
          IEnumerator enumerator1;
          try
          {
            enumerator1 = App.DB.Product.Stock_Get_Locations(integer).Table.Rows.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataRow current = (DataRow) enumerator1.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Type"], (object) "WAREHOUSE", false) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual(current["Quantity"], (object) oOrderProduct.Quantity, false))
              {
                num = Conversions.ToInteger(current["WarehouseID"]);
                break;
              }
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
          if ((uint) num > 0U && App.ShowMessage("There is stock available in a warehouse, would you like to still order from supplier?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          {
            ComboBox cboProductLocation = this.cboProductLocation;
            Combo.SetSelectedComboItem_By_Value(ref cboProductLocation, Conversions.ToString(3));
            this.cboProductLocation = cboProductLocation;
            this.ProductSearch();
            int row = 0;
            IEnumerator enumerator2;
            try
            {
              enumerator2 = this.ProductsDataView.Table.Rows.GetEnumerator();
              while (enumerator2.MoveNext())
              {
                DataRow current = (DataRow) enumerator2.Current;
                if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["WarehouseID"], (object) num, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["ProductID"], (object) integer, false))))
                  checked { ++row; }
                else
                  break;
              }
            }
            finally
            {
              if (enumerator2 is IDisposable)
                (enumerator2 as IDisposable).Dispose();
            }
            this.dgProduct.CurrentRowIndex = row;
            this.dgProduct.Select(row);
            this.dgProduct_Click((object) null, (EventArgs) null);
            this.txtProductQuantity.Text = Conversions.ToString(oOrderProduct.Quantity);
            return;
          }
          new OrderProductValidator().Validate(oOrderProduct);
          OrderProduct orderProduct = App.DB.OrderProduct.Insert(oOrderProduct, true);
          if (this.CurrentOrder.OrderTypeID == 4)
            App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Product", orderProduct.Quantity, orderProduct.OrderProductID, Conversions.ToInteger(this.SelectedProductDataRow["ProductID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboProductLocation)));
          this.SupplierUsedID = Conversions.ToInteger(this.SelectedProductDataRow["SupplierID"]);
          this.LocationUsedID = 0;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
        {
          FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct = new FSM.Entity.OrderLocationProduct.OrderLocationProduct();
          oOrderLocationProduct.IgnoreExceptionsOnSetMethods = true;
          oOrderLocationProduct.SetOrderID = (object) this.CurrentOrder.OrderID;
          oOrderLocationProduct.SetProductID = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["ProductID"]);
          oOrderLocationProduct.SetLocationID = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["LocationID"]);
          oOrderLocationProduct.SetQuantity = (object) this.txtProductQuantity.Text.Trim();
          oOrderLocationProduct.SetSellPrice = !this.txtProductSellPrice.ReadOnly ? (object) this.txtProductSellPrice.Text.Trim() : (object) 0.0;
          oOrderLocationProduct.SetQuantityReceived = (object) 0;
          new OrderLocationProductValidator().Validate(oOrderLocationProduct);
          FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct = App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, true);
          if (this.CurrentOrder.OrderTypeID == 4)
            App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Product", orderLocationProduct.Quantity, orderLocationProduct.OrderLocationProductID, Conversions.ToInteger(this.SelectedProductDataRow["ProductID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboProductLocation)));
          App.DB.ProductTransaction.Insert(new ProductTransaction()
          {
            IgnoreExceptionsOnSetMethods = true,
            SetOrderLocationProductID = (object) orderLocationProduct.OrderLocationProductID,
            SetTransactionTypeID = (object) 5,
            SetProductID = (object) orderLocationProduct.ProductID,
            SetAmount = (object) checked (-orderLocationProduct.Quantity),
            SetLocationID = (object) orderLocationProduct.LocationID
          });
          this.SupplierUsedID = 0;
          this.LocationUsedID = orderLocationProduct.LocationID;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
        {
          FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct = new FSM.Entity.OrderLocationProduct.OrderLocationProduct();
          oOrderLocationProduct.IgnoreExceptionsOnSetMethods = true;
          oOrderLocationProduct.SetOrderID = (object) this.CurrentOrder.OrderID;
          oOrderLocationProduct.SetProductID = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["ProductID"]);
          oOrderLocationProduct.SetLocationID = RuntimeHelpers.GetObjectValue(this.SelectedProductDataRow["LocationID"]);
          oOrderLocationProduct.SetQuantity = (object) this.txtProductQuantity.Text.Trim();
          oOrderLocationProduct.SetSellPrice = !this.txtProductSellPrice.ReadOnly ? (object) this.txtProductSellPrice.Text.Trim() : (object) 0.0;
          oOrderLocationProduct.SetQuantityReceived = (object) 0;
          new OrderLocationProductValidator().Validate(oOrderLocationProduct);
          FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct = App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, true);
          if (this.CurrentOrder.OrderTypeID == 4)
            App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Product", orderLocationProduct.Quantity, orderLocationProduct.OrderLocationProductID, Conversions.ToInteger(this.SelectedProductDataRow["ProductID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboProductLocation)));
          App.DB.ProductTransaction.Insert(new ProductTransaction()
          {
            IgnoreExceptionsOnSetMethods = true,
            SetOrderLocationProductID = (object) orderLocationProduct.OrderLocationProductID,
            SetTransactionTypeID = (object) 5,
            SetProductID = (object) orderLocationProduct.ProductID,
            SetAmount = (object) checked (-orderLocationProduct.Quantity),
            SetLocationID = (object) orderLocationProduct.LocationID
          });
          this.SupplierUsedID = 0;
          this.LocationUsedID = orderLocationProduct.LocationID;
        }
        this.RefreshDataGrids();
        this.ProductSearch();
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
        int num = (int) App.ShowMessage("Product could not be added.\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
    }

    private void txtPartSearch_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      Cursor.Current = Cursors.WaitCursor;
      this.PartSearch();
      Cursor.Current = Cursors.Default;
    }

    private void txtProductSearch_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      Cursor.Current = Cursors.WaitCursor;
      this.ProductSearch();
      Cursor.Current = Cursors.Default;
    }

    private void btnItemRemove_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        FSM.Entity.Sys.Enums.SecuritySystemModules ssm1 = FSM.Entity.Sys.Enums.SecuritySystemModules.EditPO;
        FSM.Entity.Sys.Enums.SecuritySystemModules ssm2 = FSM.Entity.Sys.Enums.SecuritySystemModules.CreatePO;
        if (!(App.loggedInUser.HasAccessToModule(ssm1) | App.loggedInUser.HasAccessToModule(ssm2)))
          throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
        if (this.SelectedItemIncludedDataRow == null)
        {
          int num = (int) App.ShowMessage("Please select an item to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          if (Decimal.Compare(this.nudItemQty.Value, Decimal.Zero) == 0 && App.ShowMessage("Completely remove item?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            return;
          if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(this.SelectedItemIncludedDataRow["QuantityReceived"], (object) 0, false))
            ;
          string Left = Conversions.ToString(this.SelectedItemIncludedDataRow["Type"]);
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderProduct", false) != 0)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderPart", false) != 0)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderLocationProduct", false) != 0)
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderLocationPart", false) == 0)
                {
                  FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart1 = new FSM.Entity.OrderLocationPart.OrderLocationPart();
                  FSM.Entity.OrderLocationPart.OrderLocationPart oOrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get(Conversions.ToInteger(this.SelectedItemIncludedDataRow["ID"]));
                  PartTransaction partTransaction = new PartTransaction();
                  PartTransaction orderLocationPart2 = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(oOrderLocationPart.OrderLocationPartID);
                  if (Decimal.Compare(this.nudItemQty.Value, Decimal.Zero) == 0)
                  {
                    App.DB.OrderLocationPart.Delete(oOrderLocationPart.OrderLocationPartID);
                    App.DB.PartTransaction.Delete(orderLocationPart2.PartTransactionID);
                  }
                  else
                  {
                    oOrderLocationPart.SetQuantity = (object) this.nudItemQty.Value;
                    App.DB.OrderLocationPart.Update(oOrderLocationPart);
                    orderLocationPart2.SetAmount = (object) this.nudItemQty.Value;
                    App.DB.PartTransaction.Update(orderLocationPart2);
                  }
                  if (this.CurrentOrder.OrderTypeID == 4)
                    App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_RemoveFromOrder(3, oOrderLocationPart.OrderLocationPartID);
                }
              }
              else
              {
                FSM.Entity.OrderLocationProduct.OrderLocationProduct orderLocationProduct1 = new FSM.Entity.OrderLocationProduct.OrderLocationProduct();
                FSM.Entity.OrderLocationProduct.OrderLocationProduct oOrderLocationProduct = App.DB.OrderLocationProduct.OrderLocationProduct_Get(Conversions.ToInteger(this.SelectedItemIncludedDataRow["ID"]));
                ProductTransaction productTransaction = new ProductTransaction();
                ProductTransaction orderLocationProduct2 = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(oOrderLocationProduct.OrderLocationProductID);
                if (Decimal.Compare(this.nudItemQty.Value, Decimal.Zero) == 0)
                {
                  App.DB.OrderLocationProduct.Delete(oOrderLocationProduct.OrderLocationProductID);
                  App.DB.ProductTransaction.Delete(orderLocationProduct2.ProductTransactionID);
                }
                else
                {
                  oOrderLocationProduct.SetQuantity = (object) this.nudItemQty.Value;
                  App.DB.OrderLocationProduct.Update(oOrderLocationProduct);
                  orderLocationProduct2.SetAmount = (object) this.nudItemQty.Value;
                  App.DB.ProductTransaction.Update(orderLocationProduct2);
                }
                if (this.CurrentOrder.OrderTypeID == 4)
                  App.DB.EngineerVisitPartProductAllocated.EngineerVisitProductAllocated_Delete(3, oOrderLocationProduct.OrderLocationProductID);
              }
            }
            else
            {
              OrderPart orderPart = new OrderPart();
              OrderPart oOrderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(this.SelectedItemIncludedDataRow["ID"]));
              if (Decimal.Compare(this.nudItemQty.Value, Decimal.Zero) == 0)
              {
                App.DB.OrderPart.Delete(oOrderPart.OrderPartID);
              }
              else
              {
                oOrderPart.SetQuantity = (object) this.nudItemQty.Value;
                App.DB.OrderPart.Update(oOrderPart);
              }
              if (this.CurrentOrder.OrderTypeID == 4)
                App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_RemoveFromOrder(1, oOrderPart.OrderPartID);
            }
          }
          else
          {
            OrderProduct orderProduct = new OrderProduct();
            OrderProduct oOrderProduct = App.DB.OrderProduct.OrderProduct_Get(Conversions.ToInteger(this.SelectedItemIncludedDataRow["ID"]));
            if (Decimal.Compare(this.nudItemQty.Value, Decimal.Zero) == 0)
            {
              App.DB.OrderProduct.Delete(oOrderProduct.OrderProductID);
            }
            else
            {
              oOrderProduct.SetQuantity = (object) this.nudItemQty.Value;
              App.DB.OrderProduct.Update(oOrderProduct);
            }
          }
          if (this.isOrderCancelled() & this.CurrentOrder.OrderStatusID > 1)
          {
            this.CurrentOrder.SetOrderStatusID = (object) 3;
            App.DB.Order.Update(this.CurrentOrder);
            if (this.CurrentOrder.OrderConsolidationID > 0)
            {
              bool flag = true;
              IEnumerator enumerator;
              try
              {
                enumerator = App.DB.OrderConsolidations.Order_GetForConsolidationByID(this.CurrentOrder.OrderConsolidationID, 0, 0).Table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(((DataRow) enumerator.Current)["OrderStatusID"], (object) 3, false))
                  {
                    flag = false;
                    break;
                  }
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              if (flag)
              {
                OrderConsolidation oOrderConsolidation = App.DB.OrderConsolidations.OrderConsolidation_Get(this.CurrentOrder.OrderConsolidationID);
                oOrderConsolidation.SetConsolidatedOrderStatusID = 3;
                App.DB.OrderConsolidations.Update(oOrderConsolidation);
              }
            }
            this.IsLoading = true;
            this.Populate(this.CurrentOrder.OrderID);
            this.IsLoading = false;
          }
          else
          {
            if (this.isOrderComplete())
            {
              if (this.CurrentOrder.OrderStatusID > 1)
              {
                this.CurrentOrder.SetOrderStatusID = (object) 4;
                App.DB.Order.Update(this.CurrentOrder);
                if (this.CurrentOrder.OrderConsolidationID > 0)
                {
                  bool flag = true;
                  IEnumerator enumerator;
                  try
                  {
                    enumerator = App.DB.OrderConsolidations.Order_GetForConsolidationByID(this.CurrentOrder.OrderConsolidationID, 0, 0).Table.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLess(((DataRow) enumerator.Current)["OrderStatusID"], (object) 4, false))
                      {
                        flag = false;
                        break;
                      }
                    }
                  }
                  finally
                  {
                    if (enumerator is IDisposable)
                      (enumerator as IDisposable).Dispose();
                  }
                  if (flag)
                  {
                    OrderConsolidation oOrderConsolidation = App.DB.OrderConsolidations.OrderConsolidation_Get(this.CurrentOrder.OrderConsolidationID);
                    oOrderConsolidation.SetConsolidatedOrderStatusID = 4;
                    App.DB.OrderConsolidations.Update(oOrderConsolidation);
                  }
                }
                this.IsLoading = true;
                this.Populate(this.CurrentOrder.OrderID);
                this.IsLoading = false;
              }
              if (this.CurrentOrder.OrderTypeID == 4)
              {
                EngineerVisit asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(this.ucJobOrder.SelectedEngineerVisitDataRow["EngineerVisitID"]), true);
                if (asObject.StatusEnumID == 2)
                {
                  DataView forEngineerVisit = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(asObject.EngineerVisitID);
                  bool flag = true;
                  IEnumerator enumerator;
                  try
                  {
                    enumerator = forEngineerVisit.Table.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                      DataRow current = (DataRow) enumerator.Current;
                      if ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderStatusID"])) > 0U && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["OrderStatusID"], (object) 4, false))))
                        flag = false;
                    }
                  }
                  finally
                  {
                    if (enumerator is IDisposable)
                      (enumerator as IDisposable).Dispose();
                  }
                  if (flag && App.ShowMessage("The visit this order relates to is waiting for parts. Would you like to set the status of the visit to Ready To Schedule?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                  {
                    asObject.SetStatusEnumID = (object) 4;
                    asObject.SetPartsToFit = (object) true;
                    App.DB.EngineerVisits.Update(asObject, 0, true);
                  }
                }
              }
              if (this.CurrentOrder.OrderTypeID == 1)
                App.ShowForm(typeof (FrmRaiseInvoiceDetails), true, new object[2]
                {
                  (object) this.CurrentOrder.OrderID,
                  (object) this.CurrentOrder.InvoiceAddressID
                }, false);
            }
            this.PartSearch();
            this.ProductSearch();
            this.RefreshDataGrids();
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Item cannot be removed.\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.nudItemQty.Value = Decimal.Zero;
        this.Cursor = Cursors.Default;
      }
    }

    private void dgItemsIncluded_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedItemIncludedDataRow == null)
        return;
      if (this.CurrentOrder.OrderConsolidationID > 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(this.SelectedItemIncludedDataRow["Type"]), "OrderPart", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(this.SelectedItemIncludedDataRow["Type"]), "OrderProduct", false) == 0)
      {
        int num1 = (int) App.ShowMessage("This order has been added to a consolidation so should be managed from there.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.CurrentOrder.OrderStatusID != 2)
      {
        int num2 = (int) App.ShowMessage("Order must be confirmed to mark items into stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (Conversions.ToInteger(this.SelectedItemIncludedDataRow["QuantityOnOrder"]) == Conversions.ToInteger(this.SelectedItemIncludedDataRow["QuantityReceived"]))
      {
        int num3 = (int) App.ShowMessage("This stock has been fully received", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        App.ShowForm(typeof (FRMReceiveStock), true, new object[3]
        {
          (object) this.CurrentOrder.OrderID,
          (object) Conversions.ToString(this.SelectedItemIncludedDataRow["Type"]),
          (object) Conversions.ToInteger(this.SelectedItemIncludedDataRow["ID"])
        }, false);
        this.Populate(this.CurrentOrder.OrderID);
        if (this.isOrderComplete())
        {
          if (this.CurrentOrder.OrderStatusID > 1)
          {
            this.CurrentOrder.SetOrderStatusID = (object) 4;
            App.DB.Order.Update(this.CurrentOrder);
            this.IsLoading = true;
            this.Populate(this.CurrentOrder.OrderID);
            this.IsLoading = false;
          }
          if (this.CurrentOrder.OrderTypeID == 4)
          {
            EngineerVisit asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(this.ucJobOrder.SelectedEngineerVisitDataRow["EngineerVisitID"]), true);
            if (asObject.StatusEnumID == 2)
            {
              DataView forEngineerVisit = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(asObject.EngineerVisitID);
              bool flag = true;
              IEnumerator enumerator;
              try
              {
                enumerator = forEngineerVisit.Table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  if ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["OrderStatusID"])) > 0U && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["OrderStatusID"], (object) 4, false))))
                    flag = false;
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              if (flag)
                App.ShowForm(typeof (FRMPickDespatchDetails), true, new object[1]
                {
                  (object) asObject
                }, false);
            }
          }
          if (this.CurrentOrder.OrderTypeID == 1)
            App.ShowForm(typeof (FrmRaiseInvoiceDetails), true, new object[2]
            {
              (object) this.CurrentOrder.OrderID,
              (object) this.CurrentOrder.InvoiceAddressID
            }, false);
        }
      }
    }

    private void dgItemsIncluded_Click(object sender, EventArgs e)
    {
      if (this.SelectedItemIncludedDataRow == null)
        return;
      this.nudItemQty.Value = new Decimal(Conversions.ToInteger(this.SelectedItemIncludedDataRow["QuantityOnOrder"]));
    }

    public bool ValidateSupplierInvoice(bool Update = false)
    {
      string MessageText = "Please correct the following error(s):\r\n";
      bool flag = true;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtSupplierInvoiceRefNew.Text, (string) null, false) == 0)
      {
        MessageText += "- 'Invoice Ref' cannot be empty.\r\n";
        flag = false;
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtNominalCodeNew.Text, (string) null, false) == 0)
      {
        MessageText += "- 'Nominal Code' cannot be empty.\r\n";
        flag = false;
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtGoodsAmount.Text, (string) null, false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Microsoft.VisualBasic.Strings.Format((object) this.txtGoodsAmount.Text, "C"), "£0.00", false) == 0)
      {
        MessageText += "- 'Goods' cannot be empty and must not equals 0.\r\n";
        flag = false;
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtVATAmount.Text, (string) null, false) == 0)
      {
        MessageText += "- 'VAT' cannot be empty.\r\n";
        flag = false;
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtTotalAmount.Text, (string) null, false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Microsoft.VisualBasic.Strings.Format((object) this.txtTotalAmount.Text, "C"), "£0.00", false) == 0)
      {
        MessageText += "- 'Total' cannot be empty and must not equals 0.\r\n";
        flag = false;
      }
      if (!flag)
      {
        int num1 = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      if (flag)
      {
        double num2 = 0.0;
        double num3 = 0.0;
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.ItemsIncludedDataView.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            num2 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["BuyPrice"], current["QuantityOnOrder"])));
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
          enumerator2 = App.DB.OrderCharge.OrderCharge_GetForOrder(this.CurrentOrder.OrderID).Table.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            num2 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, current["Amount"]));
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        IEnumerator enumerator3;
        try
        {
          enumerator3 = App.DB.SupplierInvoices.Order_GetSupplierInvoices(this.CurrentOrder.OrderID).Table.Rows.GetEnumerator();
          while (enumerator3.MoveNext())
          {
            DataRow current = (DataRow) enumerator3.Current;
            num3 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num3, current["SupplierInvoiceAmount"]));
          }
        }
        finally
        {
          if (enumerator3 is IDisposable)
            (enumerator3 as IDisposable).Dispose();
        }
        double num4;
        if (Update)
        {
          double num5 = Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(Conversions.ToString(this.dgvReceivedInvoices["SupplierInvoiceAmount", this.dgvReceivedInvoices.CurrentRow.Index].Value), "£", "", 1, -1, CompareMethod.Binary));
          num4 = num3 - num5 + Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtGoodsAmount.Text, "£", "", 1, -1, CompareMethod.Binary)) - 0.05;
        }
        else
          num4 = num3 + Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtGoodsAmount.Text, "£", "", 1, -1, CompareMethod.Binary)) - 0.05;
        if (num4 > Conversions.ToDouble(Microsoft.VisualBasic.Strings.Format((object) num2, "F")))
        {
          int num5 = (int) App.ShowMessage("The entered supplier invoice amount is greater than the total of the order. You will now be prompted to enter the override password to continue", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          if (!App.EnterOverridePassword())
            return false;
        }
      }
      return flag;
    }

    public bool ValidateCreditInvoice(bool Update = false)
    {
      string MessageText = "Please correct the following error(s):\r\n";
      bool flag = true;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCreditRef.Text, (string) null, false) == 0)
      {
        MessageText += "- 'Invoice Ref' cannot be empty.\r\n";
        flag = false;
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCreditNominal.Text, (string) null, false) == 0)
      {
        MessageText += "- 'Nominal Code' cannot be empty.\r\n";
        flag = false;
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCreditGoods.Text, (string) null, false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Microsoft.VisualBasic.Strings.Format((object) this.txtCreditGoods.Text, "C"), "£0.00", false) == 0)
      {
        MessageText += "- 'Goods' cannot be empty and must not equals 0.\r\n";
        flag = false;
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtCreditVAT.Text, (string) null, false) == 0)
      {
        MessageText += "- 'VAT' cannot be empty.\r\n";
        flag = false;
      }
      if (!flag)
      {
        int num = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      if (flag)
        ;
      return flag;
    }

    void IUserControl.Populate(int ID = 0)
    {
      this.btnEngineerReceived.Visible = false;
      if ((uint) ID > 0U)
        this.CurrentOrder = App.DB.Order.Order_Get(ID);
      this.dtpDatePlaced.Value = this.CurrentOrder.DatePlaced;
      this.txtOrderReference.Text = this.CurrentOrder.OrderReference;
      if (DateTime.Compare(this.CurrentOrder.DeliveryDeadline, DateTime.MinValue) == 0)
      {
        this.chkDeadlineNA.Checked = true;
      }
      else
      {
        this.dtpDeliveryDeadline.Value = this.CurrentOrder.DeliveryDeadline;
        this.chkDeadlineNA.Checked = false;
      }
      ComboBox cboDept = this.cboDept;
      Combo.SetSelectedComboItem_By_Value(ref cboDept, this.CurrentOrder.DepartmentRef);
      this.cboDept = cboDept;
      ComboBox cboOrderTypeId = this.cboOrderTypeID;
      Combo.SetSelectedComboItem_By_Value(ref cboOrderTypeId, Conversions.ToString(this.CurrentOrder.OrderTypeID));
      this.cboOrderTypeID = cboOrderTypeId;
      ComboBox cboOrderStatus = this.cboOrderStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
      this.cboOrderStatus = cboOrderStatus;
      this.chkDoNotConsolidate.Checked = this.CurrentOrder.DoNotConsolidated;
      switch (this.CurrentOrder.OrderStatusID)
      {
        case 1:
          this.lblOrderStatus.Text = "ORDER AWAITING CONFIRMATION FROM CUSTOMER";
          this.lblOrderStatus.Visible = true;
          break;
        case 2:
        case 7:
          this.DisableFields();
          this.btnCharges.Enabled = true;
          this.lblOrderStatus.Text = "ORDER WAITING FOR ITEMS RECEIVED";
          this.lblOrderStatus.Visible = true;
          this.btnPrint.Enabled = this.CurrentOrder.OrderStatusID != 7;
          this.btnApproveOrder.Visible = this.CurrentOrder.OrderStatusID == 7 && App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.POAuthorisation);
          break;
        case 3:
          this.DisableFields();
          this.btnCharges.Enabled = false;
          this.lblOrderStatus.Text = "ORDER HAS BEEN CANCELLED (click to view)";
          this.lblOrderStatus.Visible = true;
          break;
        case 4:
          this.DisableFields();
          this.btnCharges.Enabled = false;
          this.lblOrderStatus.Text = "ORDER COMPLETE";
          this.lblOrderStatus.Visible = true;
          if (this.CurrentOrder.ExportedToSage)
          {
            Label lblOrderStatus;
            string str = (lblOrderStatus = this.lblOrderStatus).Text + " - (Invoiced and Sent to Sage)";
            lblOrderStatus.Text = str;
            break;
          }
          if (this.CurrentOrder.Invoiced)
          {
            Label lblOrderStatus;
            string str = (lblOrderStatus = this.lblOrderStatus).Text + " - (Invoiced)";
            lblOrderStatus.Text = str;
          }
          break;
      }
      this.RefreshDataGrids();
      this.btnUpdateOrderRef.Visible = App.loggedInUser.HasAccessToModule(FSM.Entity.Sys.Enums.SecuritySystemModules.Finance);
      switch (this.CurrentOrder.OrderTypeID)
      {
        case 1:
          this.ucCustomerOrder.Customer = App.DB.Customer.Customer_GetForOrder(this.CurrentOrder.OrderID);
          SiteOrder siteOrder = new SiteOrder();
          SiteOrder forOrder = App.DB.SiteOrder.SiteOrder_GetForOrder(this.CurrentOrder.OrderID);
          if (forOrder == null)
            this.ucCustomerOrder.Warehouse = App.DB.Warehouse.Warehouse_GetByLocationID(App.DB.OrderLocation.OrderLocation_GetForOrder(this.CurrentOrder.OrderID).LocationID);
          else
            this.ucCustomerOrder.theProperty = App.DB.Sites.Get((object) forOrder.SiteID, SiteSQL.GetBy.SiteId, (object) null);
          this.CustomerID = this.ucCustomerOrder.Customer.CustomerID;
          this.ucCustomerOrder.Contact = App.DB.Contact.Contact_Get(this.CurrentOrder.ContactID);
          this.ucCustomerOrder.InvoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(this.CurrentOrder.InvoiceAddressID);
          UCOrderForCustomer ucCustomerOrder = this.ucCustomerOrder;
          ComboBox cboUsers = ucCustomerOrder.cboUsers;
          Combo.SetSelectedComboItem_By_Value(ref cboUsers, Conversions.ToString(this.CurrentOrder.AllocatedToUser));
          ucCustomerOrder.cboUsers = cboUsers;
          this.ucCustomerOrder.txtSpecialInstructions.Text = this.CurrentOrder.SpecialInstructions;
          this.btnRelatedJob.Enabled = false;
          break;
        case 2:
          this.ucVanOrder.Van = App.DB.Van.Van_Get(this.PassedID);
          int deliveryAddressId = App.DB.OrderLocation.OrderLocation_GetForOrder(this.CurrentOrder.OrderID).DeliveryAddressID;
          if ((uint) deliveryAddressId > 0U)
            this.ucVanOrder.DeliveryAddress = App.DB.Warehouse.Warehouse_Get(deliveryAddressId);
          this.btnRelatedJob.Enabled = false;
          this.btnEngineerReceived.Visible = true;
          break;
        case 3:
          this.ucWarehouseOrder.Warehouse = App.DB.Warehouse.Warehouse_Get(this.PassedID);
          this.btnRelatedJob.Enabled = false;
          break;
        case 4:
          this.ucJobOrder.EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Get(this.PassedID);
          if (this.ucJobOrder.EngineerVisitsDataView != null & this.ucJobOrder.EngineerVisitsDataView.Count > 0 && (this.ucJobOrder.EngineerVisitsDataView.Table.Columns.Contains("CustomerID") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(this.ucJobOrder.EngineerVisitsDataView[0]["CustomerID"]))))
            this.CustomerID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.ucJobOrder.EngineerVisitsDataView[0]["CustomerID"]));
          this.ucJobOrder.Warehouse = App.DB.Warehouse.Warehouse_Get(App.DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(this.CurrentOrder.OrderID).WarehouseID);
          this.btnRelatedJob.Enabled = true;
          break;
        default:
          this.lblOrderStatus.Text = "PICK WHAT THE ORDER IS FOR";
          this.lblOrderStatus.Visible = true;
          break;
      }
      if (this.CurrentOrder.OrderConsolidationID == 0)
      {
        Label lblOrderStatus;
        string str = (lblOrderStatus = this.lblOrderStatus).Text + " *Supplier Invoice NOT sent to Sage*";
        lblOrderStatus.Text = str;
      }
      else if (App.DB.OrderConsolidations.OrderConsolidation_Get(this.CurrentOrder.OrderConsolidationID).HasSupplierPO)
      {
        this.txtSupplierInvoiceRefNew.ReadOnly = true;
        this.txtExtraReferenceNew.ReadOnly = true;
        this.txtNominalCodeNew.ReadOnly = true;
        this.txtExtraReferenceNew.ReadOnly = true;
        this.dtpSupplierInvoiceDateNew.Enabled = false;
        this.cboInvoiceTaxCodeNew.Enabled = false;
        this.txtNominalCodeNew.ReadOnly = true;
        this.txtGoodsAmount.ReadOnly = true;
        this.txtVATAmount.ReadOnly = true;
        this.txtTotalAmount.ReadOnly = true;
        this.btnAddSupplierInvoice.Enabled = false;
        this.cboDept.Enabled = true;
        Label lblOrderStatus;
        string str = (lblOrderStatus = this.lblOrderStatus).Text + " *Supplier Invoice managed within consolidation*";
        lblOrderStatus.Text = str;
      }
      else
      {
        Label lblOrderStatus;
        string str = (lblOrderStatus = this.lblOrderStatus).Text + " *Supplier Invoice NOT sent to Sage*";
        lblOrderStatus.Text = str;
      }
      if (!this.isOrderComplete() || this.dgvReceivedInvoices.RowCount <= 0)
        return;
      this.chkRevertStatus.Enabled = false;
    }

    private void PopulateOrderTotal()
    {
      double num1 = 0.0;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.ItemsIncludedDataView.Table.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          num1 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num1, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["BuyPrice"], current["QuantityOnOrder"])));
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
        enumerator2 = App.DB.OrderCharge.OrderCharge_GetForOrder(this.CurrentOrder.OrderID).Table.Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current = (DataRow) enumerator2.Current;
          num1 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num1, current["Amount"]));
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      this.lblOrderTotal.Text = Microsoft.VisualBasic.Strings.Format((object) num1, "C");
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 0.0;
      IEnumerator enumerator3;
      try
      {
        enumerator3 = App.DB.SupplierInvoices.Order_GetSupplierInvoices(this.CurrentOrder.OrderID).Table.Rows.GetEnumerator();
        while (enumerator3.MoveNext())
        {
          DataRow current = (DataRow) enumerator3.Current;
          num2 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, current["SupplierInvoiceAmount"]));
          num3 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num3, current["SupplierVATAmount"]));
          num4 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num4, current["SupplierGoodsAmount"]));
        }
      }
      finally
      {
        if (enumerator3 is IDisposable)
          (enumerator3 as IDisposable).Dispose();
      }
      this.lblGoodsTotal.Text = Microsoft.VisualBasic.Strings.Format((object) num2, "C");
      this.lblCredits.Text = "0";
      IEnumerator enumerator4;
      try
      {
        enumerator4 = App.DB.ExecuteWithReturn("select (AmountReceived) as CreditReceived from tblPartCredits pc inner join (sELECT MAX(tblPartCreditParts.PartsToBeCreditedID) AS MAXIMUN ,PartCreditID  FROM tblPartCreditParts group by PartCreditID) pcp on pcp.PartCreditID = pc.PartCreditsID inner join tblPartsToBeCredited tbc ON tbc.PartsToBeCreditedID = pcp.maximun WHERE OrderID = " + Conversions.ToString(this.CurrentOrder.OrderID), true).Rows.GetEnumerator();
        while (enumerator4.MoveNext())
          this.lblCredits.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) this.lblCredits.Text, ((DataRow) enumerator4.Current)["CreditReceived"]));
      }
      finally
      {
        if (enumerator4 is IDisposable)
          (enumerator4 as IDisposable).Dispose();
      }
      double num5 = num1 - num2 + Conversions.ToDouble(this.lblCredits.Text);
      this.lblCredits.Text = Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDouble(this.lblCredits.Text), "C");
      this.lblOrderBalance.Text = Microsoft.VisualBasic.Strings.Format((object) num5, "C");
      string Left = Microsoft.VisualBasic.Strings.Format((object) num5, "C");
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "£0.00", false) == 0)
        this.lblOrderBalance.ForeColor = Color.Green;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) < 0)
      {
        this.lblOrderBalance.ForeColor = Color.Red;
      }
      else
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) <= 0)
          return;
        this.lblOrderBalance.ForeColor = Color.DarkOrange;
      }
    }

    private void RefreshDataGrids()
    {
      this.ItemsIncludedDataView = App.DB.Order.Order_ItemsGetAll(this.CurrentOrder.OrderID);
      IEnumerator enumerator;
      try
      {
        enumerator = this.ItemsIncludedDataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["SupplierID"])))
          {
            this.SupplierUsedID = Conversions.ToInteger(current["SupplierID"]);
            break;
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (this.SupplierUsedID > 0)
        this.txtNominalCodeNew.Text = App.DB.Supplier.Supplier_Get(this.SupplierUsedID).DefaultNominal;
      this.PriceRequestDataView = App.DB.Order.Order_PriceRequests_GetAll(this.CurrentOrder.OrderID);
      this.dgvReceivedInvoices.DataSource = (object) App.DB.SupplierInvoices.Order_GetSupplierInvoices(this.CurrentOrder.OrderID);
      this.dgCredits.DataSource = (object) App.DB.PartsToBeCredited.PartsToBeCredited_Get_OrderID(this.CurrentOrder.OrderID);
    }

    public void DisableFields()
    {
      this.txtPartBuyPrice.Enabled = false;
      this.txtPartQuantity.Enabled = false;
      this.txtPartSearch.Enabled = false;
      this.txtProductBuyPrice.Enabled = false;
      this.txtProductQuantity.Enabled = false;
      this.txtProductSearch.Enabled = false;
      this.txtProductSellPrice.Enabled = false;
      this.ucVanOrder.Enabled = false;
      this.ucWarehouseOrder.Enabled = false;
      this.ucCustomerOrder.btnFindCustomer.Enabled = false;
      this.ucCustomerOrder.btnFindSite.Enabled = false;
      this.ucCustomerOrder.btnFindWarehouse.Enabled = false;
      this.btnAddPart.Enabled = false;
      this.btnAddProduct.Enabled = false;
      this.btnPartSearch.Enabled = false;
      this.btnProductSearch.Enabled = false;
      this.cboOrderStatus.Enabled = false;
      this.cboOrderTypeID.Enabled = false;
      this.cboPartLocation.Enabled = false;
      this.cboProductLocation.Enabled = false;
      this.dgParts.Enabled = false;
      this.dgProduct.Enabled = false;
      switch (this.CurrentOrder.OrderStatusID)
      {
        case 1:
          this.txtOrderReference.ReadOnly = true;
          this.dtpDatePlaced.Enabled = true;
          this.chkDeadlineNA.Enabled = true;
          break;
        case 2:
        case 7:
          this.txtOrderReference.ReadOnly = true;
          this.dtpDatePlaced.Enabled = true;
          this.chkDeadlineNA.Enabled = true;
          break;
        case 3:
          this.txtOrderReference.ReadOnly = true;
          this.dtpDatePlaced.Enabled = false;
          this.chkDeadlineNA.Enabled = false;
          break;
        case 4:
          this.txtOrderReference.ReadOnly = true;
          this.dtpDatePlaced.Enabled = false;
          this.chkDeadlineNA.Enabled = false;
          this.dtpDeliveryDeadline.Enabled = false;
          break;
      }
    }

    private void EnableTabs(bool Enabled)
    {
      if (this.CurrentOrder.OrderStatusID == 4)
      {
        if (this.CurrentOrder.OrderTypeID == 2)
        {
          bool flag = false;
          IEnumerator enumerator;
          try
          {
            enumerator = this.ItemsIncludedDataView.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["WithEngineer_Van"])), DateTime.MinValue) == 0 & DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["WithEngineer_Job"])), DateTime.MinValue) == 0)
              {
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
          if (flag)
          {
            this.nudItemQty.Enabled = false;
            this.btnItemQtyUpdate.Enabled = false;
            this.btnReceiveAll.Enabled = false;
            this.btnEngineerReceived.Visible = true;
          }
          else
          {
            this.dgItemsIncluded.ReadOnly = true;
            this.btnItemQtyUpdate.Enabled = false;
            this.btnEngineerReceived.Enabled = false;
            this.btnReceiveAll.Enabled = false;
          }
        }
        else
        {
          this.dgItemsIncluded.ReadOnly = true;
          this.btnItemQtyUpdate.Enabled = false;
          this.btnEngineerReceived.Enabled = false;
          this.btnReceiveAll.Enabled = false;
        }
      }
      else
        this.tabItemsIncluded.Enabled = true;
      this.tabPartPriceReq.Enabled = Enabled;
      this.tabParts.Enabled = Enabled;
      this.tabProducts.Enabled = Enabled;
      this.tabDocuments.Enabled = Enabled;
      this.ucCustomerOrder.btnFindCustomer.Enabled = !Enabled;
      this.ucCustomerOrder.btnFindSite.Enabled = !Enabled;
      this.ucCustomerOrder.btnFindWarehouse.Enabled = !Enabled;
      this.ucJobOrder.Enabled = !Enabled;
      this.ucWarehouseOrder.Enabled = !Enabled;
      this.ucVanOrder.Enabled = !Enabled;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        FSM.Entity.Sys.Enums.SecuritySystemModules ssm1 = FSM.Entity.Sys.Enums.SecuritySystemModules.EditPO;
        FSM.Entity.Sys.Enums.SecuritySystemModules ssm2 = FSM.Entity.Sys.Enums.SecuritySystemModules.CreatePO;
        if (!(App.loggedInUser.HasAccessToModule(ssm1) | App.loggedInUser.HasAccessToModule(ssm2)))
          throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
        Order oOrder = new Order();
        oOrder.IgnoreExceptionsOnSetMethods = true;
        oOrder.SetSentToSage = (object) this.CurrentOrder.SentToSage;
        FSM.Entity.Sites.Site site = new FSM.Entity.Sites.Site();
        site.Exists = false;
        string Left = Combo.get_GetSelectedItemValue(this.cboOrderTypeID);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
        {
          if (((UCOrderForCustomer) this.pnlDetails.Controls[0]).Customer == null)
          {
            int num = (int) App.ShowMessage("Please select a Customer this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            flag = false;
            goto label_73;
          }
          else if (((UCOrderForCustomer) this.pnlDetails.Controls[0]).theProperty == null & ((UCOrderForCustomer) this.pnlDetails.Controls[0]).Warehouse == null)
          {
            int num = (int) App.ShowMessage("Please select a Property/Warehouse this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            flag = false;
            goto label_73;
          }
          else
            site = ((UCOrderForCustomer) this.pnlDetails.Controls[0]).theProperty;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
        {
          if (((UCOrderForWarehouse) this.pnlDetails.Controls[0]).Warehouse == null)
          {
            int num = (int) App.ShowMessage("Please select a Warehouse this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            flag = false;
            goto label_73;
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
        {
          if (((UCOrderForVan) this.pnlDetails.Controls[0]).Van == null)
          {
            int num = (int) App.ShowMessage("Please select a Van this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            flag = false;
            goto label_73;
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
        {
          if (((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow == null)
          {
            int num = (int) App.ShowMessage("Please select a Visit this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            flag = false;
            goto label_73;
          }
          else
          {
            site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
            if (!this.CurrentOrder.Exists)
            {
              Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"])));
              DataView forJob = App.DB.Order.Orders_GetForJob(anEngineerVisitId.JobID);
              forJob.RowFilter = "OrderStatus <> 'Cancelled'";
              if (forJob.Count > 0)
              {
                List<string> details = new List<string>();
                IEnumerator enumerator;
                try
                {
                  enumerator = forJob.GetEnumerator();
                  while (enumerator.MoveNext())
                  {
                    DataRowView current = (DataRowView) enumerator.Current;
                    details.Add(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Order Ref: ", current["OrderReference"]), (object) ", Supplier: "), current["Supplier"])));
                  }
                }
                finally
                {
                  if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
                }
                if (App.ShowMessageWithDetails("Existing Purchase Orders", "The following orders have already been placed against this job.\r\n\r\nDo you wish to continue?", details) != DialogResult.OK)
                {
                  flag = false;
                  goto label_73;
                }
              }
              string str = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDept));
              if (Helper.IsValidInteger((object) str) && Helper.MakeIntegerValid((object) str) > -1)
              {
                int costCentre = this.GetCostCentre(anEngineerVisitId, site);
                ComboBox cboDept = this.cboDept;
                Combo.SetSelectedComboItem_By_Value(ref cboDept, costCentre.ToString());
                this.cboDept = cboDept;
              }
              else if (!Versioned.IsNumeric((object) str))
              {
                int costCentre = this.GetCostCentre(anEngineerVisitId, site);
                ComboBox cboDept = this.cboDept;
                Combo.SetSelectedComboItem_By_Value(ref cboDept, costCentre.ToString());
                this.cboDept = cboDept;
              }
            }
          }
        }
        else
        {
          int num = (int) App.ShowMessage("Please select an order type.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          flag = false;
          goto label_73;
        }
        if (site != null && site.Exists)
        {
          if (App.loggedInUser.UserRegions.Count > 0)
          {
            if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + Conversions.ToString(site.RegionID)).Length < 1)
              throw new SecurityException("You do not have the necessary security permissions to create a purchase order on this site.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          }
          else if (site.RegionID != App.loggedInUser.UserID)
            throw new SecurityException("You do not have the necessary security permissions to create a purchase order on this site.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
        }
        oOrder.SetOrderID = (object) this.CurrentOrder.OrderID;
        oOrder.DatePlaced = this.dtpDatePlaced.Value;
        oOrder.SetOrderTypeID = (object) Combo.get_GetSelectedItemValue(this.cboOrderTypeID);
        if (oOrder.UserID == 0)
          oOrder.SetUserID = (object) App.loggedInUser.UserID;
        oOrder.SetOrderStatusID = (object) Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboOrderStatus));
        oOrder.DeliveryDeadline = !this.chkDeadlineNA.Checked ? this.dtpDeliveryDeadline.Value : DateTime.MinValue;
        oOrder.SupplierInvoiceDate = DateTime.MinValue;
        oOrder.SetDepartmentRef = (object) Combo.get_GetSelectedItemValue(this.cboDept);
        oOrder.SetDoNotConsolidated = (object) this.chkDoNotConsolidate.Checked;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboOrderTypeID), Conversions.ToString(1), false) == 0)
        {
          oOrder.SetContactID = ((UCOrderForCustomer) this.pnlDetails.Controls[0]).Contact != null ? (object) ((UCOrderForCustomer) this.pnlDetails.Controls[0]).Contact.ContactID : (object) 0;
          oOrder.SetInvoiceAddressID = ((UCOrderForCustomer) this.pnlDetails.Controls[0]).InvoiceAddress != null ? (object) ((UCOrderForCustomer) this.pnlDetails.Controls[0]).InvoiceAddress.InvoiceAddressID : (object) 0;
          oOrder.SetAllocatedToUser = (object) Combo.get_GetSelectedItemValue(((UCOrderForCustomer) this.pnlDetails.Controls[0]).cboUsers);
          oOrder.SetSpecialInstructions = (object) ((UCOrderForCustomer) this.pnlDetails.Controls[0]).txtSpecialInstructions.Text.Trim();
        }
        oOrder.SetOrderReference = (object) this.txtOrderReference.Text.Trim();
        new OrderValidator().Validate(oOrder);
        if (!this.CurrentOrder.Exists)
        {
          Order order = App.DB.Order.Insert(oOrder);
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(order.OrderReference, this.OrderNumber.OrderNumber, false) == 0)
            this.OrderNumberUsed = true;
          SiteOrder oSiteOrder = new SiteOrder();
          CustomerOrder oCustomerOrder = new CustomerOrder();
          OrderLocation oOrderLocation = new OrderLocation();
          EngineerVisitOrder oEngineerVisitOrder = new EngineerVisitOrder();
          OrderLocation orderLocation;
          switch (order.OrderTypeID)
          {
            case 1:
              oCustomerOrder.SetCustomerID = (object) ((UCOrderForCustomer) this.pnlDetails.Controls[0]).Customer.CustomerID;
              oCustomerOrder.SetOrderID = (object) order.OrderID;
              App.DB.CustomerOrder.DeleteForOrder(order.OrderID);
              App.DB.CustomerOrder.Insert(oCustomerOrder);
              if (((UCOrderForCustomer) this.pnlDetails.Controls[0]).theProperty != null)
              {
                oSiteOrder.SetOrderID = (object) order.OrderID;
                oSiteOrder.SetSiteID = (object) ((UCOrderForCustomer) this.pnlDetails.Controls[0]).theProperty.SiteID;
                App.DB.SiteOrder.DeleteByOrder(order.OrderID);
                this.PassedID = App.DB.SiteOrder.Insert(oSiteOrder).SiteID;
                break;
              }
              oOrderLocation.SetOrderID = (object) order.OrderID;
              oOrderLocation.SetLocationID = RuntimeHelpers.GetObjectValue(App.DB.Warehouse.Warehouse_GetDV(((UCOrderForCustomer) this.pnlDetails.Controls[0]).Warehouse.WarehouseID).Table.Rows[0]["LocationID"]);
              App.DB.OrderLocation.DeleteForOrder(order.OrderID);
              orderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
              this.PassedID = ((UCOrderForCustomer) this.pnlDetails.Controls[0]).Warehouse.WarehouseID;
              break;
            case 2:
              oOrderLocation.SetOrderID = (object) order.OrderID;
              oOrderLocation.SetLocationID = (object) Conversions.ToInteger(App.DB.Van.Van_GetDV(((UCOrderForVan) this.pnlDetails.Controls[0]).Van.VanID).Table.Rows[0]["LocationID"]);
              oOrderLocation.SetDeliveryAddressID = (object) ((UCOrderForVan) this.pnlDetails.Controls[0]).DeliveryAddressID;
              App.DB.OrderLocation.DeleteForOrder(order.OrderID);
              orderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
              this.PassedID = ((UCOrderForVan) this.pnlDetails.Controls[0]).Van.VanID;
              break;
            case 3:
              oOrderLocation.SetOrderID = (object) order.OrderID;
              oOrderLocation.SetLocationID = RuntimeHelpers.GetObjectValue(App.DB.Warehouse.Warehouse_GetDV(((UCOrderForWarehouse) this.pnlDetails.Controls[0]).Warehouse.WarehouseID).Table.Rows[0]["LocationID"]);
              App.DB.OrderLocation.DeleteForOrder(order.OrderID);
              orderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
              this.PassedID = ((UCOrderForWarehouse) this.pnlDetails.Controls[0]).Warehouse.WarehouseID;
              break;
            case 4:
              oEngineerVisitOrder.SetOrderID = (object) order.OrderID;
              if (((UCOrderForJob) this.pnlDetails.Controls[0]).Warehouse != null)
                oEngineerVisitOrder.SetWarehouseID = (object) ((UCOrderForJob) this.pnlDetails.Controls[0]).Warehouse.WarehouseID;
              oEngineerVisitOrder.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]);
              App.DB.EngineerVisitOrder.EngineerVisitOrder_DeleteForOrder(order.OrderID);
              EngineerVisitOrder engineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder);
              EngineerVisit asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitOrder.EngineerVisitID, true);
              if (asObject.StatusEnumID < 5)
              {
                asObject.SetStatusEnumID = (object) 2;
                App.DB.EngineerVisits.Update(asObject, 0, true);
              }
              this.PassedID = Conversions.ToInteger(((UCOrderForJob) this.pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]);
              break;
          }
          this.CurrentOrder = order;
        }
        else
        {
          FSM.Entity.Sys.Enums.SecuritySystemModules ssm3 = FSM.Entity.Sys.Enums.SecuritySystemModules.POUnlock;
          if (App.loggedInUser.HasAccessToModule(ssm3))
          {
            if (this.chkRevertStatus.Checked)
            {
              oOrder.SetOrderStatusID = (object) 1;
              App.DB.Order.Update(oOrder);
              MyProject.Forms.FRMOrder.ResetMe(oOrder.OrderID);
              this.cboPartLocation.Enabled = true;
              this.txtPartSearch.Enabled = true;
              this.btnPartSearch.Enabled = true;
              this.txtPartQuantity.Enabled = true;
              this.txtPartBuyPrice.Enabled = true;
              this.cboProductLocation.Enabled = true;
              this.txtProductSearch.Enabled = true;
              this.txtProductQuantity.Enabled = true;
              this.txtProductBuyPrice.Enabled = true;
              this.txtProductSellPrice.Enabled = true;
              this.btnProductSearch.Enabled = true;
              this.btnItemQtyUpdate.Enabled = true;
              this.nudItemQty.Enabled = true;
              this.dgParts.Enabled = true;
              this.dgProduct.Enabled = true;
              this.btnReceiveAll.Enabled = true;
              this.chkRevertStatus.Checked = false;
            }
            else
              App.DB.Order.Update(oOrder);
          }
        }
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentOrder.OrderID);
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
label_73:
      return flag;
    }

    private void PartSearch()
    {
      string Left = Combo.get_GetSelectedItemValue(this.cboPartLocation);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
        {
          if (this.LocationUsedID == 0)
          {
            FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(this.CustomerID);
            bool isFlagShip = customer != null && customer.IsPFH;
            this.PartsDataView = (DataView) App.DB.PartSupplier.PartSupplier_Search(this.txtPartSearch.Text, this.SupplierUsedID, isFlagShip);
          }
          else
          {
            int num1 = (int) App.ShowMessage("A warehouse/van has been ordered from so no supplier orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
        {
          if (this.SupplierUsedID == 0)
          {
            this.PartsDataView = App.DB.PartTransaction.SearchByVan(this.txtPartSearch.Text, this.LocationUsedID);
          }
          else
          {
            int num2 = (int) App.ShowMessage("A supplier has been ordered from so no stock profile can be added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
        {
          if (this.SupplierUsedID == 0)
          {
            this.PartsDataView = App.DB.PartTransaction.SearchByWarehouse(this.txtPartSearch.Text, this.LocationUsedID);
          }
          else
          {
            int num3 = (int) App.ShowMessage("A supplier has been ordered from so no warehouse orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
      }
      this.UpdatePartSearchOptions();
    }

    private void UpdatePartSearchOptions()
    {
      string Left = Combo.get_GetSelectedItemValue(this.cboPartLocation);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) == 0)
      {
        this.grpPartSearch.Text = "Part Search From";
        this.btnPartSearch.Enabled = false;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
      {
        this.btnPartSearch.Enabled = true;
        this.grpPartSearch.Text = "Search takes place on Part Name, Number (MPN) and Supplier Code (SPN)";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
      {
        this.btnPartSearch.Enabled = true;
        this.grpPartSearch.Text = "Search takes place on Part Name, Number (MPN), Engineer Name and Stock Profile";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
      {
        this.btnPartSearch.Enabled = true;
        this.grpPartSearch.Text = "Search takes place on Part Name, Number (MPN) and Warehouse Name";
      }
      this.txtPartQuantity.Text = "";
      this.txtPartQuantity.ReadOnly = true;
      this.txtPartBuyPrice.Text = "";
      this.txtPartBuyPrice.ReadOnly = true;
      this.btnAddPart.Enabled = false;
      this.btnCreatePartRequest.Enabled = false;
    }

    private void ProductSearch()
    {
      string Left = Combo.get_GetSelectedItemValue(this.cboProductLocation);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
        {
          if (this.LocationUsedID == 0)
          {
            this.ProductsDataView = (DataView) App.DB.ProductSupplier.ProductSupplier_Search(this.txtProductSearch.Text, this.SupplierUsedID);
          }
          else
          {
            int num1 = (int) App.ShowMessage("A warehouse/van has been ordered from so no supplier orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
        {
          if (this.SupplierUsedID == 0)
          {
            this.ProductsDataView = App.DB.ProductTransaction.SearchByVan(this.txtProductSearch.Text, this.LocationUsedID);
          }
          else
          {
            int num2 = (int) App.ShowMessage("A supplier has been ordered from so no stock profile orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
        {
          if (this.SupplierUsedID == 0)
          {
            this.ProductsDataView = App.DB.ProductTransaction.SearchByWarehouse(this.txtProductSearch.Text, this.LocationUsedID);
          }
          else
          {
            int num3 = (int) App.ShowMessage("A supplier has been ordered from so no warehouse orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
      }
      this.UpdateProductSearchOptions();
    }

    private void UpdateProductSearchOptions()
    {
      string Left = Combo.get_GetSelectedItemValue(this.cboProductLocation);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) == 0)
      {
        this.grpProductSearch.Text = "Product Search From";
        this.btnProductSearch.Enabled = false;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
      {
        this.btnProductSearch.Enabled = true;
        this.grpProductSearch.Text = "Search takes place on Product Number, Model, Make, Type  and Supplier Code";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
      {
        this.btnProductSearch.Enabled = true;
        this.grpProductSearch.Text = "Search takes place on Product Number, Model, Make, Type, Engineer Name and stock profile";
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
      {
        this.btnProductSearch.Enabled = true;
        this.grpProductSearch.Text = "Search takes place on Product Number, Model, Make, Type and Warehouse Name";
      }
      this.txtProductQuantity.Text = "";
      this.txtProductQuantity.ReadOnly = true;
      this.txtProductBuyPrice.Text = "";
      this.txtProductBuyPrice.ReadOnly = true;
      this.txtProductSellPrice.Text = "";
      this.txtProductSellPrice.ReadOnly = true;
      this.btnAddProduct.Enabled = false;
      this.btnCreateProductPriceRequest.Enabled = false;
    }

    private void Calculate_Tax()
    {
      if (this.IsLoading)
        return;
      try
      {
        this.txtVATAmount.Text = Microsoft.VisualBasic.Strings.Format((object) (Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtGoodsAmount.Text, "£", "", 1, -1, CompareMethod.Binary)) * (App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboInvoiceTaxCodeNew))).PercentageRate / 100.0)), "C");
        this.txtTotalAmount.Text = Microsoft.VisualBasic.Strings.FormatCurrency((object) (Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtGoodsAmount.Text, "£", "", 1, -1, CompareMethod.Binary)) + Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtVATAmount.Text, "£", "", 1, -1, CompareMethod.Binary))), -1, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.txtVATAmount.Text = (string) null;
        this.txtTotalAmount.Text = (string) null;
        ProjectData.ClearProjectError();
      }
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.dgCredits.CurrentRow == null)
        return;
      if (this.dgCredits["DatePartReturned", this.dgCredits.CurrentRow.Index].Value.ToString().Length > 0)
      {
        int num1 = (int) App.ShowMessage("This part has been returned so no, you cant move it to a van.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        DataTable PartsAndProductsDistribution = new DataTable();
        PartsAndProductsDistribution.Columns.Add("LocationID");
        PartsAndProductsDistribution.Columns.Add("AllocatedID");
        PartsAndProductsDistribution.Columns.Add("Other");
        PartsAndProductsDistribution.Columns.Add("Quantity");
        PartsAndProductsDistribution.Columns.Add("PartProductID");
        PartsAndProductsDistribution.Columns.Add("OrderPartProductID");
        PartsAndProductsDistribution.Columns.Add("StockTransactionType");
        FRMConvertToVan frmConvertToVan = new FRMConvertToVan(false, Conversions.ToInteger(this.dgCredits["Qty", this.dgCredits.CurrentRow.Index].Value), Conversions.ToString(this.dgCredits["PartName", this.dgCredits.CurrentRow.Index].Value), "Part", Conversions.ToInteger(this.dgCredits["PartID", this.dgCredits.CurrentRow.Index].Value), (ArrayList) null);
        if (frmConvertToVan.ShowDialog() == DialogResult.OK)
        {
          IEnumerator enumerator;
          try
          {
            enumerator = frmConvertToVan.Locations.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["Quantity"], (object) 0, false))
              {
                DataRow row = PartsAndProductsDistribution.NewRow();
                int integer = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Select EngineerVisitPartAllocatedID From tblEngineervisitPartAllocated Where OrderPartID = ", this.dgCredits["OrderPartID", this.dgCredits.CurrentRow.Index].Value)), true, false));
                row["LocationID"] = RuntimeHelpers.GetObjectValue(current["LocationID"]);
                row["AllocatedID"] = (object) integer;
                row["Other"] = (object) false;
                row["Quantity"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
                row["PartProductID"] = RuntimeHelpers.GetObjectValue(this.dgCredits["PartID", this.dgCredits.CurrentRow.Index].Value);
                row["OrderPartProductID"] = RuntimeHelpers.GetObjectValue(this.dgCredits["OrderPartID", this.dgCredits.CurrentRow.Index].Value);
                row["StockTransactionType"] = (object) 2;
                PartsAndProductsDistribution.Rows.Add(row);
              }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          App.DB.Order.AllocatedDistributions(PartsAndProductsDistribution);
          App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "DELETE from tblPartsToBeCredited WHERE OrderPartID = ", this.dgCredits["OrderPartID", this.dgCredits.CurrentRow.Index].Value)), true, false);
          int num2 = (int) App.ShowMessage("Moved!", MessageBoxButtons.OK, MessageBoxIcon.Question);
          this.RefreshDataGrids();
        }
      }
    }

    private void Calculate_Tax2()
    {
      if (this.IsLoading)
        return;
      try
      {
        this.txtCreditVAT.Text = Microsoft.VisualBasic.Strings.Format((object) (Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtCreditGoods.Text, "£", "", 1, -1, CompareMethod.Binary)) * (App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboCreditTax))).PercentageRate / 100.0)), "C");
        this.txtCreditTotal.Text = Microsoft.VisualBasic.Strings.FormatCurrency((object) (Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtCreditGoods.Text, "£", "", 1, -1, CompareMethod.Binary)) + Conversions.ToDouble(Microsoft.VisualBasic.Strings.Replace(this.txtCreditVAT.Text, "£", "", 1, -1, CompareMethod.Binary))), -1, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.txtCreditVAT.Text = (string) null;
        this.txtCreditTotal.Text = (string) null;
        ProjectData.ClearProjectError();
      }
    }

    private void btnEngineerReceived_Click(object sender, EventArgs e)
    {
      if (this.CurrentOrder == null)
      {
        int num1 = (int) App.ShowMessage("Order must be created first", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (!this.CurrentOrder.Exists)
      {
        int num2 = (int) App.ShowMessage("Order must be created first", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (this.CurrentOrder.OrderTypeID != 2)
      {
        int num3 = (int) App.ShowMessage("Order must be for a van", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (this.CurrentOrder.OrderStatusID != 4)
      {
        int num4 = (int) App.ShowMessage("Order must be completed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        if (App.ShowMessage("Are you sure you wish to mark all items as received by engineer?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        IEnumerator enumerator;
        try
        {
          enumerator = this.ItemsIncludedDataView.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            bool flag = true;
            if (this.CurrentOrder.OrderTypeID == 2)
            {
              if ((uint) DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["WithEngineer_Van"])), DateTime.MinValue) > 0U)
                flag = false;
            }
            else if (this.CurrentOrder.OrderTypeID == 4 && (uint) DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["WithEngineer_Job"])), DateTime.MinValue) > 0U)
              flag = false;
            if (flag)
            {
              int integer = Conversions.ToInteger(current["QuantityReceived"]);
              string Left = Conversions.ToString(current["Type"]);
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderProduct", false) != 0)
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderPart", false) != 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderLocationProduct", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "OrderLocationPart", false) == 0)
                  {
                    FSM.Entity.OrderLocationPart.OrderLocationPart orderLocationPart1 = App.DB.OrderLocationPart.OrderLocationPart_Get(Conversions.ToInteger(current["ID"]));
                    PartTransaction orderLocationPart2 = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(orderLocationPart1.OrderLocationPartID);
                    OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(orderLocationPart1.OrderID);
                    orderLocationPart2.SetLocationID = (object) forOrder.LocationID;
                    orderLocationPart2.SetTransactionTypeID = (object) 2;
                    orderLocationPart2.SetOrderLocationPartID = (object) orderLocationPart1.OrderLocationPartID;
                    orderLocationPart2.SetAmount = (object) integer;
                    orderLocationPart2.SetPartID = (object) orderLocationPart1.PartID;
                    App.DB.PartTransaction.Insert(orderLocationPart2);
                    App.DB.OrderLocationPart.EngineerReceived(orderLocationPart1.OrderLocationPartID);
                  }
                }
                else
                {
                  OrderPart orderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(current["ID"]));
                  OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(orderPart.OrderID);
                  PartSupplier partSupplier = App.DB.PartSupplier.PartSupplier_Get(orderPart.PartSupplierID);
                  App.DB.PartTransaction.Insert(new PartTransaction()
                  {
                    SetLocationID = (object) forOrder.LocationID,
                    SetPartID = (object) partSupplier.PartID,
                    SetOrderPartID = (object) orderPart.OrderPartID,
                    SetAmount = (object) ((double) integer * partSupplier.QuantityInPack),
                    SetTransactionTypeID = (object) 2
                  });
                  App.DB.OrderPart.EngineerReceived(orderPart.OrderPartID);
                }
              }
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.Populate(this.CurrentOrder.OrderID);
      }
    }

    public int GetCostCentre(Job job, FSM.Entity.Sites.Site site)
    {
      CostCentreSql costCentre1 = App.DB.CostCentre;
      int? nullable1 = job?.JobTypeID;
      int @ref = nullable1.Value;
      int? nullable2;
      if (site == null)
      {
        nullable1 = new int?();
        nullable2 = nullable1;
      }
      else
        nullable2 = new int?(site.CustomerID);
      nullable1 = nullable2;
      int ref2 = nullable1.Value;
      List<CostCentre> source = costCentre1.Get(@ref, ref2, FSM.Entity.CostCentres.Enums.GetBy.JobTypeIdAndCutomerId);
      CostCentre costCentre2 = source != null ? source.FirstOrDefault<CostCentre>() : (CostCentre) null;
      return costCentre2 != null ? costCentre2.Name : -1;
    }

    private void Email()
    {
      if (this.CurrentOrder.Exists)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboPrintType), Conversions.ToString(5), false) != 0)
          return;
        this.PrintSupplierPurchaseOrders(this.CurrentOrder.OrderTypeID, new Emails()
        {
          To = "",
          From = App.TheSystem.Configuration.SalesEmailFrom,
          Subject = "Purchase Order",
          Body = "Purchase Order Attached"
        });
      }
      else
      {
        int num = (int) App.ShowMessage("You must save the order before you can send.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void Print()
    {
      if (this.CurrentOrder.Exists)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboPrintType), Conversions.ToString(5), false) == 0)
          this.PrintSupplierPurchaseOrders(this.CurrentOrder.OrderTypeID, (Emails) null);
        this.pnlDocuments.Controls.Clear();
        this.DocumentsControl = new UCDocumentsList(FSM.Entity.Sys.Enums.TableNames.tblOrder, this.CurrentOrder.OrderID);
        this.pnlDocuments.Controls.Add((Control) this.DocumentsControl);
      }
      else
      {
        int num = (int) App.ShowMessage("You must save the order before you can print.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public bool PrintSupplierPurchaseOrders(int OrderTypeID, Emails oEmail)
    {
      ArrayList arrayList = new ArrayList();
      DataView dataView = App.DB.Order.OrderSupplierItemsForPrint_Get(this.CurrentOrder.OrderID);
      if (dataView.Table.Rows.Count > 0)
      {
        dataView.Sort = "SupplierID";
        DataTable dataTable = dataView.Table.Clone();
        DataSet dataSet = new DataSet();
        int integer = Conversions.ToInteger(dataView.Table.Rows[0]["SupplierID"]);
        IEnumerator enumerator1;
        try
        {
          enumerator1 = dataView.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["SupplierID"], (object) integer, false))
            {
              dataTable.Rows.Add(current.ItemArray);
            }
            else
            {
              dataTable.TableName = "tblOrder" + Conversions.ToString(integer);
              dataSet.Tables.Add(dataTable.Copy());
              dataTable.Rows.Clear();
              dataTable.Rows.Add(current.ItemArray);
            }
            integer = Conversions.ToInteger(current["SupplierID"]);
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        if (dataTable.Rows.Count > 0)
        {
          dataTable.TableName = "tblOrder" + Conversions.ToString(integer);
          dataSet.Tables.Add(dataTable.Copy());
          arrayList.Add((object) dataSet);
        }
        DialogResult dialogResult = App.ShowMessage("Do you want to print to PDF?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        switch (OrderTypeID)
        {
          case 1:
            if (((UCOrderForCustomer) this.pnlDetails.Controls[0]).theProperty == null)
            {
              arrayList.Add((object) "Warehouse");
              arrayList.Add((object) ((UCOrderForCustomer) this.pnlDetails.Controls[0]).Warehouse);
            }
            else
            {
              arrayList.Add((object) "Site");
              arrayList.Add((object) ((UCOrderForCustomer) this.pnlDetails.Controls[0]).theProperty);
            }
            arrayList.Add((object) null);
            arrayList.Add((object) App.DB.User.Get(this.CurrentOrder.UserID, false));
            arrayList.Add((object) this.CurrentOrder.OrderReference);
            arrayList.Add((object) this.CurrentOrder.DeliveryDeadline);
            arrayList.Add((object) App.DB.OrderCharge.OrderCharge_GetForOrder(this.CurrentOrder.OrderID));
            arrayList.Add((object) dialogResult);
            if (oEmail != null)
            {
              Printing printing = new Printing((object) arrayList, "SupplierPurchaseOrder", FSM.Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder, true, this.CurrentOrder.OrderID, true, 13, 0, DateTime.MinValue, (DataTable) null);
              IEnumerator enumerator2;
              try
              {
                enumerator2 = printing.MultiEmail().GetEnumerator();
                while (enumerator2.MoveNext())
                {
                  Supplier current = (Supplier) enumerator2.Current;
                  oEmail.Attachments.Add((object) current.FilePath);
                  oEmail.To = current.EmailAddress;
                  oEmail.SendMe = true;
                  oEmail.Send();
                }
                break;
              }
              finally
              {
                if (enumerator2 is IDisposable)
                  (enumerator2 as IDisposable).Dispose();
              }
            }
            else
            {
              Printing printing = new Printing((object) arrayList, "SupplierPurchaseOrder", FSM.Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder, true, this.CurrentOrder.OrderID, false, 13, 0, DateTime.MinValue, (DataTable) null);
              break;
            }
          case 2:
            arrayList.Add((object) "Stock Profile");
            int deliveryAddressId = App.DB.OrderLocation.OrderLocation_GetForOrder(this.CurrentOrder.OrderID).DeliveryAddressID;
            if ((uint) deliveryAddressId > 0U)
              arrayList.Add((object) App.DB.Warehouse.Warehouse_Get(deliveryAddressId));
            else
              arrayList.Add((object) null);
            arrayList.Add((object) null);
            arrayList.Add((object) App.DB.User.Get(this.CurrentOrder.UserID, false));
            arrayList.Add((object) this.CurrentOrder.OrderReference);
            arrayList.Add((object) this.CurrentOrder.DeliveryDeadline);
            arrayList.Add((object) App.DB.OrderCharge.OrderCharge_GetForOrder(this.CurrentOrder.OrderID));
            arrayList.Add((object) dialogResult);
            if (oEmail != null)
            {
              Printing printing = new Printing((object) arrayList, "SupplierPurchaseOrder", FSM.Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder, true, this.CurrentOrder.OrderID, true, 13, 0, DateTime.MinValue, (DataTable) null);
              IEnumerator enumerator2;
              try
              {
                enumerator2 = printing.MultiEmail().GetEnumerator();
                while (enumerator2.MoveNext())
                {
                  Supplier current = (Supplier) enumerator2.Current;
                  oEmail.Attachments.Add((object) current.FilePath);
                  oEmail.To = current.EmailAddress;
                  oEmail.SendMe = true;
                  oEmail.Send();
                }
                break;
              }
              finally
              {
                if (enumerator2 is IDisposable)
                  (enumerator2 as IDisposable).Dispose();
              }
            }
            else
            {
              Printing printing = new Printing((object) arrayList, "SupplierPurchaseOrder", FSM.Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder, true, this.CurrentOrder.OrderID, false, 13, 0, DateTime.MinValue, (DataTable) null);
              break;
            }
          case 3:
            arrayList.Add((object) "Warehouse");
            arrayList.Add((object) ((UCOrderForWarehouse) this.pnlDetails.Controls[0]).Warehouse);
            arrayList.Add((object) null);
            arrayList.Add((object) App.DB.User.Get(this.CurrentOrder.UserID, false));
            arrayList.Add((object) this.CurrentOrder.OrderReference);
            arrayList.Add((object) this.CurrentOrder.DeliveryDeadline);
            arrayList.Add((object) App.DB.OrderCharge.OrderCharge_GetForOrder(this.CurrentOrder.OrderID));
            arrayList.Add((object) dialogResult);
            if (oEmail != null)
            {
              Printing printing = new Printing((object) arrayList, "SupplierPurchaseOrder", FSM.Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder, true, this.CurrentOrder.OrderID, true, 13, 0, DateTime.MinValue, (DataTable) null);
              IEnumerator enumerator2;
              try
              {
                enumerator2 = printing.MultiEmail().GetEnumerator();
                while (enumerator2.MoveNext())
                {
                  Supplier current = (Supplier) enumerator2.Current;
                  oEmail.Attachments.Add((object) current.FilePath);
                  oEmail.To = current.EmailAddress;
                  oEmail.SendMe = true;
                  oEmail.Send();
                }
                break;
              }
              finally
              {
                if (enumerator2 is IDisposable)
                  (enumerator2 as IDisposable).Dispose();
              }
            }
            else
            {
              Printing printing = new Printing((object) arrayList, "SupplierPurchaseOrder", FSM.Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder, true, this.CurrentOrder.OrderID, false, 13, 0, DateTime.MinValue, (DataTable) null);
              break;
            }
          case 4:
            int warehouseId = App.DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(this.CurrentOrder.OrderID).WarehouseID;
            if (warehouseId > 0)
            {
              arrayList.Add((object) "Warehouse");
              arrayList.Add((object) App.DB.Warehouse.Warehouse_Get(warehouseId));
            }
            else
            {
              arrayList.Add((object) "Site");
              arrayList.Add((object) App.DB.Sites.Get((object) App.DB.Job.Job_Get_For_An_EngineerVisit_ID(App.DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(this.CurrentOrder.OrderID).EngineerVisitID).PropertyID, SiteSQL.GetBy.SiteId, (object) null));
            }
            arrayList.Add((object) null);
            arrayList.Add((object) App.DB.User.Get(this.CurrentOrder.UserID, false));
            arrayList.Add((object) this.CurrentOrder.OrderReference);
            arrayList.Add((object) this.CurrentOrder.DeliveryDeadline);
            arrayList.Add((object) App.DB.OrderCharge.OrderCharge_GetForOrder(this.CurrentOrder.OrderID));
            arrayList.Add((object) dialogResult);
            if (oEmail != null)
            {
              Printing printing = new Printing((object) arrayList, "SupplierPurchaseOrder", FSM.Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder, true, this.CurrentOrder.OrderID, true, 13, 0, DateTime.MinValue, (DataTable) null);
              IEnumerator enumerator2;
              try
              {
                enumerator2 = printing.MultiEmail().GetEnumerator();
                while (enumerator2.MoveNext())
                {
                  Supplier current = (Supplier) enumerator2.Current;
                  oEmail.Attachments.Add((object) current.FilePath);
                  oEmail.To = current.EmailAddress;
                  oEmail.SendMe = true;
                  oEmail.Send();
                }
                break;
              }
              finally
              {
                if (enumerator2 is IDisposable)
                  (enumerator2 as IDisposable).Dispose();
              }
            }
            else
            {
              Printing printing = new Printing((object) arrayList, "SupplierPurchaseOrder", FSM.Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder, true, this.CurrentOrder.OrderID, false, 13, 0, DateTime.MinValue, (DataTable) null);
              break;
            }
        }
      }
      else
      {
        int num = (int) App.ShowMessage("No Items have been ordered from suppliers", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      bool flag;
      return flag;
    }

    private void btnUpdateOrderRef_Click(object sender, EventArgs e)
    {
      if (this.txtOrderReference.ReadOnly)
      {
        if (this.CurrentOrder == null || !this.CurrentOrder.Exists)
          return;
        this.txtOrderReference.ReadOnly = false;
        this.txtOrderReference.Enabled = true;
      }
      else if (App.ShowMessage("Do you wish to update the order ref?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        App.DB.Order.Update_OrderRef(this.CurrentOrder.OrderID, this.txtOrderReference.Text);
        new Emails()
        {
          To = EmailAddress.Accounts,
          From = EmailAddress.FSM,
          Subject = "Purchase Order Changed",
          Body = ("Purchase Order Changed from " + this.CurrentOrder.OrderReference + " to " + this.txtOrderReference.Text + " by " + App.loggedInUser.Fullname),
          SendMe = true
        }.Send();
        this.txtOrderReference.ReadOnly = true;
        this.txtOrderReference.Enabled = false;
      }
    }

    private void btnApproveOrder_Click(object sender, EventArgs e)
    {
      if (this.CurrentOrder.OrderStatusID != 7 || App.ShowMessage("Are you sure you want to approve this order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      App.ShowForm(typeof (FRMOrderRejection), true, new object[3]
      {
        (object) this,
        (object) "",
        (object) true
      }, false);
      if (this.Reason.Trim().Length == 0)
      {
        this.IsLoading = true;
        ComboBox cboOrderStatus = this.cboOrderStatus;
        Combo.SetSelectedComboItem_By_Value(ref cboOrderStatus, Conversions.ToString(this.CurrentOrder.OrderStatusID));
        this.cboOrderStatus = cboOrderStatus;
        this.IsLoading = false;
      }
      else
      {
        this.CurrentOrder.SetReason = (object) this.Reason;
        this.CurrentOrder.SetOrderStatusID = (object) 2;
        App.DB.Order.Update(this.CurrentOrder);
        this.Populate(0);
      }
    }

    public delegate void FormCloseEventHandler();

    public class ColourColumn : DataGridLabelColumn
    {
      protected override void Paint(
        Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum,
        Brush backBrush,
        Brush foreBrush,
        bool alignToRight)
      {
        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        Brush brush = Brushes.White;
        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) "Preferred"
        }, (string[]) null, (System.Type[]) null, (bool[]) null))))
          brush = Brushes.LightGreen;
        this.TextBox.Text = "";
        Rectangle rect = bounds;
        g.FillRectangle(brush, rect);
        g.DrawString("", this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
      }
    }
  }
}
