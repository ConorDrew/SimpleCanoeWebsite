using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Business.Orders;
using FSM.Entity.Jobs;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCOrder : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCOrder() : base()
        {

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboOrderTypeID;
            Combo.SetUpCombo(ref argc, DynamicDataTables.OrderType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc1 = cboPartLocation;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.LocationType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc2 = cboProductLocation;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.LocationType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc3 = cboOrderStatus;
            Combo.SetUpCombo(ref argc3, App.DB.Order.OrderStatus_Get_All().Table, "OrderStatusID", "Name");
            var argc4 = cboInvoiceTaxCodeNew;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.VATCodes).Table, "ManagerID", "Name", Enums.ComboValues.Dashes);
            var argc5 = cboCreditTax;
            Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Enums.PickListTypes.VATCodes).Table, "ManagerID", "Name", Enums.ComboValues.Dashes);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc6 = cboDept;
                        Combo.SetUpCombo(ref argc6, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc7 = cboDept;
                        Combo.SetUpCombo(ref argc7, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

            chkDoNotConsolidate.Checked = true;
            // Add any initialization after the InitializeComponent() call

        }

        // UserControl overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components is null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private GroupBox _grpOrder;

        internal GroupBox grpOrder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpOrder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpOrder != null)
                {
                }

                _grpOrder = value;
                if (_grpOrder != null)
                {
                }
            }
        }

        private DateTimePicker _dtpDatePlaced;

        internal DateTimePicker dtpDatePlaced
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDatePlaced;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDatePlaced != null)
                {
                }

                _dtpDatePlaced = value;
                if (_dtpDatePlaced != null)
                {
                }
            }
        }

        private Label _lblDatePlaced;

        internal Label lblDatePlaced
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDatePlaced;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDatePlaced != null)
                {
                }

                _lblDatePlaced = value;
                if (_lblDatePlaced != null)
                {
                }
            }
        }

        private ComboBox _cboOrderTypeID;

        internal ComboBox cboOrderTypeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboOrderTypeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboOrderTypeID != null)
                {
                    _cboOrderTypeID.SelectedIndexChanged -= cboOrderTypeID_SelectedIndexChanged;
                }

                _cboOrderTypeID = value;
                if (_cboOrderTypeID != null)
                {
                    _cboOrderTypeID.SelectedIndexChanged += cboOrderTypeID_SelectedIndexChanged;
                }
            }
        }

        private Label _lblOrderTypeID;

        internal Label lblOrderTypeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOrderTypeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOrderTypeID != null)
                {
                }

                _lblOrderTypeID = value;
                if (_lblOrderTypeID != null)
                {
                }
            }
        }

        private TextBox _txtOrderReference;

        internal TextBox txtOrderReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOrderReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOrderReference != null)
                {
                }

                _txtOrderReference = value;
                if (_txtOrderReference != null)
                {
                }
            }
        }

        private Label _lblOrderReference;

        internal Label lblOrderReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOrderReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOrderReference != null)
                {
                }

                _lblOrderReference = value;
                if (_lblOrderReference != null)
                {
                }
            }
        }

        private TabPage _tabDetails;

        internal TabPage tabDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabDetails != null)
                {
                }

                _tabDetails = value;
                if (_tabDetails != null)
                {
                }
            }
        }

        private TabPage _tabProducts;

        internal TabPage tabProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabProducts != null)
                {
                }

                _tabProducts = value;
                if (_tabProducts != null)
                {
                }
            }
        }

        private TabPage _tabParts;

        internal TabPage tabParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabParts != null)
                {
                }

                _tabParts = value;
                if (_tabParts != null)
                {
                }
            }
        }

        private Panel _pnlDetails;

        internal Panel pnlDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlDetails != null)
                {
                }

                _pnlDetails = value;
                if (_pnlDetails != null)
                {
                }
            }
        }

        private TextBox _txtProductSearch;

        internal TextBox txtProductSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProductSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProductSearch != null)
                {
                    _txtProductSearch.KeyDown -= txtProductSearch_KeyDown;
                }

                _txtProductSearch = value;
                if (_txtProductSearch != null)
                {
                    _txtProductSearch.KeyDown += txtProductSearch_KeyDown;
                }
            }
        }

        private Button _btnProductSearch;

        internal Button btnProductSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnProductSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnProductSearch != null)
                {
                    _btnProductSearch.Click -= btnProductSearch_Click;
                }

                _btnProductSearch = value;
                if (_btnProductSearch != null)
                {
                    _btnProductSearch.Click += btnProductSearch_Click;
                }
            }
        }

        private DataGrid _dgProduct;

        internal DataGrid dgProduct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgProduct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgProduct != null)
                {
                    _dgProduct.DoubleClick -= dgProduct_DoubleClick;
                    _dgProduct.Click -= dgProduct_Click;
                    _dgProduct.CurrentCellChanged -= dgProduct_Click;
                }

                _dgProduct = value;
                if (_dgProduct != null)
                {
                    _dgProduct.DoubleClick += dgProduct_DoubleClick;
                    _dgProduct.Click += dgProduct_Click;
                    _dgProduct.CurrentCellChanged += dgProduct_Click;
                }
            }
        }

        private TextBox _txtPartSearch;

        internal TextBox txtPartSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartSearch != null)
                {
                    _txtPartSearch.KeyDown -= txtPartSearch_KeyDown;
                }

                _txtPartSearch = value;
                if (_txtPartSearch != null)
                {
                    _txtPartSearch.KeyDown += txtPartSearch_KeyDown;
                }
            }
        }

        private Button _btnAddProduct;

        internal Button btnAddProduct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddProduct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddProduct != null)
                {
                    _btnAddProduct.Click -= btnAddProduct_Click;
                }

                _btnAddProduct = value;
                if (_btnAddProduct != null)
                {
                    _btnAddProduct.Click += btnAddProduct_Click;
                }
            }
        }

        private Button _btnAddPart;

        internal Button btnAddPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddPart != null)
                {
                    _btnAddPart.Click -= btnAddPart_Click;
                }

                _btnAddPart = value;
                if (_btnAddPart != null)
                {
                    _btnAddPart.Click += btnAddPart_Click;
                }
            }
        }

        private GroupBox _grpPartSearch;

        internal GroupBox grpPartSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPartSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPartSearch != null)
                {
                }

                _grpPartSearch = value;
                if (_grpPartSearch != null)
                {
                }
            }
        }

        private GroupBox _grpAvailableParts;

        internal GroupBox grpAvailableParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAvailableParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAvailableParts != null)
                {
                }

                _grpAvailableParts = value;
                if (_grpAvailableParts != null)
                {
                }
            }
        }

        private TextBox _txtPartQuantity;

        internal TextBox txtPartQuantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartQuantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartQuantity != null)
                {
                }

                _txtPartQuantity = value;
                if (_txtPartQuantity != null)
                {
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private GroupBox _grpProductSearch;

        internal GroupBox grpProductSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpProductSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpProductSearch != null)
                {
                }

                _grpProductSearch = value;
                if (_grpProductSearch != null)
                {
                }
            }
        }

        private GroupBox _grpProductsAvailable;

        internal GroupBox grpProductsAvailable
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpProductsAvailable;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpProductsAvailable != null)
                {
                }

                _grpProductsAvailable = value;
                if (_grpProductsAvailable != null)
                {
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private TextBox _txtProductQuantity;

        internal TextBox txtProductQuantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProductQuantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProductQuantity != null)
                {
                }

                _txtProductQuantity = value;
                if (_txtProductQuantity != null)
                {
                }
            }
        }

        private ComboBox _cboPartLocation;

        internal ComboBox cboPartLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPartLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPartLocation != null)
                {

                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _cboPartLocation.SelectedIndexChanged -= cboPartLocation_SelectedIndexChanged;
                }

                _cboPartLocation = value;
                if (_cboPartLocation != null)
                {
                    _cboPartLocation.SelectedIndexChanged += cboPartLocation_SelectedIndexChanged;
                }
            }
        }

        private ComboBox _cboProductLocation;

        internal ComboBox cboProductLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboProductLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboProductLocation != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _cboProductLocation.SelectedIndexChanged -= cboProductLocation_SelectedIndexChanged;
                }

                _cboProductLocation = value;
                if (_cboProductLocation != null)
                {
                    _cboProductLocation.SelectedIndexChanged += cboProductLocation_SelectedIndexChanged;
                }
            }
        }

        private Button _btnPartSearch;

        internal Button btnPartSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPartSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPartSearch != null)
                {
                    _btnPartSearch.Click -= btnPartSearch_Click;
                }

                _btnPartSearch = value;
                if (_btnPartSearch != null)
                {
                    _btnPartSearch.Click += btnPartSearch_Click;
                }
            }
        }

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private TextBox _txtPartBuyPrice;

        internal TextBox txtPartBuyPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartBuyPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartBuyPrice != null)
                {
                }

                _txtPartBuyPrice = value;
                if (_txtPartBuyPrice != null)
                {
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private TextBox _txtProductSellPrice;

        internal TextBox txtProductSellPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProductSellPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProductSellPrice != null)
                {
                }

                _txtProductSellPrice = value;
                if (_txtProductSellPrice != null)
                {
                }
            }
        }

        private TextBox _txtProductBuyPrice;

        internal TextBox txtProductBuyPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProductBuyPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProductBuyPrice != null)
                {
                }

                _txtProductBuyPrice = value;
                if (_txtProductBuyPrice != null)
                {
                }
            }
        }

        private Label _Label19;

        internal Label Label19
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label19;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label19 != null)
                {
                }

                _Label19 = value;
                if (_Label19 != null)
                {
                }
            }
        }

        private ComboBox _cboOrderStatus;

        internal ComboBox cboOrderStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboOrderStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboOrderStatus != null)
                {
                    _cboOrderStatus.SelectedIndexChanged -= cboOrderStatus_SelectedIndexChanged;
                }

                _cboOrderStatus = value;
                if (_cboOrderStatus != null)
                {
                    _cboOrderStatus.SelectedIndexChanged += cboOrderStatus_SelectedIndexChanged;
                }
            }
        }

        private TabPage _tabPartPriceReq;

        internal TabPage tabPartPriceReq
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabPartPriceReq;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabPartPriceReq != null)
                {
                }

                _tabPartPriceReq = value;
                if (_tabPartPriceReq != null)
                {
                }
            }
        }

        private GroupBox _GroupBox2;

        internal GroupBox GroupBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox2 != null)
                {
                }

                _GroupBox2 = value;
                if (_GroupBox2 != null)
                {
                }
            }
        }

        private Button _btnUpdatePartPriceRequest;

        internal Button btnUpdatePartPriceRequest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdatePartPriceRequest;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdatePartPriceRequest != null)
                {
                    _btnUpdatePartPriceRequest.Click -= btnUpdatePartPriceRequest_Click;
                }

                _btnUpdatePartPriceRequest = value;
                if (_btnUpdatePartPriceRequest != null)
                {
                    _btnUpdatePartPriceRequest.Click += btnUpdatePartPriceRequest_Click;
                }
            }
        }

        private Button _btnAddNewPart;

        internal Button btnAddNewPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddNewPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddNewPart != null)
                {
                    _btnAddNewPart.Click -= btnAddNewPart_Click;
                }

                _btnAddNewPart = value;
                if (_btnAddNewPart != null)
                {
                    _btnAddNewPart.Click += btnAddNewPart_Click;
                }
            }
        }

        private Button _btnAddNewProduct;

        internal Button btnAddNewProduct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddNewProduct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddNewProduct != null)
                {
                    _btnAddNewProduct.Click -= btnAddNewProduct_Click;
                }

                _btnAddNewProduct = value;
                if (_btnAddNewProduct != null)
                {
                    _btnAddNewProduct.Click += btnAddNewProduct_Click;
                }
            }
        }

        private TabControl _tcOrderDetails;

        internal TabControl tcOrderDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcOrderDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcOrderDetails != null)
                {
                    _tcOrderDetails.SelectedIndexChanged -= tcOrderDetails_SelectedIndexChanged;
                }

                _tcOrderDetails = value;
                if (_tcOrderDetails != null)
                {
                    _tcOrderDetails.SelectedIndexChanged += tcOrderDetails_SelectedIndexChanged;
                }
            }
        }

        private TabPage _tabItemsIncluded;

        internal TabPage tabItemsIncluded
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabItemsIncluded;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabItemsIncluded != null)
                {
                }

                _tabItemsIncluded = value;
                if (_tabItemsIncluded != null)
                {
                }
            }
        }

        private GroupBox _GroupBox3;

        internal GroupBox GroupBox3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox3 != null)
                {
                }

                _GroupBox3 = value;
                if (_GroupBox3 != null)
                {
                }
            }
        }

        private DataGrid _dgItemsIncluded;

        internal DataGrid dgItemsIncluded
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgItemsIncluded;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgItemsIncluded != null)
                {
                    _dgItemsIncluded.DoubleClick -= dgProduct_Click;
                    _dgItemsIncluded.Click -= dgItemsIncluded_Click;
                }

                _dgItemsIncluded = value;
                if (_dgItemsIncluded != null)
                {
                    _dgItemsIncluded.DoubleClick += dgProduct_Click;
                    _dgItemsIncluded.Click += dgItemsIncluded_Click;
                }
            }
        }

        private Label _lblItemQty;

        internal Label lblItemQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblItemQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblItemQty != null)
                {
                }

                _lblItemQty = value;
                if (_lblItemQty != null)
                {
                }
            }
        }

        private Button _btnItemQtyUpdate;

        internal Button btnItemQtyUpdate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnItemQtyUpdate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnItemQtyUpdate != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnItemQtyUpdate.Click -= btnItemRemove_Click;
                }

                _btnItemQtyUpdate = value;
                if (_btnItemQtyUpdate != null)
                {
                    _btnItemQtyUpdate.Click += btnItemRemove_Click;
                }
            }
        }

        private ComboBox _cboPrintType;

        internal ComboBox cboPrintType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPrintType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPrintType != null)
                {
                }

                _cboPrintType = value;
                if (_cboPrintType != null)
                {
                }
            }
        }

        private Button _btnPrint;

        internal Button btnPrint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrint != null)
                {
                    _btnPrint.Click -= btnPrint_Click;
                }

                _btnPrint = value;
                if (_btnPrint != null)
                {
                    _btnPrint.Click += btnPrint_Click;
                }
            }
        }

        private Button _btnEmail;

        internal Button btnEmail
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEmail;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEmail != null)
                {
                    _btnEmail.Click -= btnEmail_Click;
                }

                _btnEmail = value;
                if (_btnEmail != null)
                {
                    _btnEmail.Click += btnEmail_Click;
                }
            }
        }

        private Button _btnCharges;

        internal Button btnCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCharges != null)
                {
                    _btnCharges.Click -= btnCharges_Click;
                }

                _btnCharges = value;
                if (_btnCharges != null)
                {
                    _btnCharges.Click += btnCharges_Click;
                }
            }
        }

        private Label _Label6;

        internal Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label6 != null)
                {
                }

                _Label6 = value;
                if (_Label6 != null)
                {
                }
            }
        }

        private CheckBox _chkDeadlineNA;

        internal CheckBox chkDeadlineNA
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDeadlineNA;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDeadlineNA != null)
                {
                    _chkDeadlineNA.CheckedChanged -= chkDeadlineNA_CheckedChanged;
                }

                _chkDeadlineNA = value;
                if (_chkDeadlineNA != null)
                {
                    _chkDeadlineNA.CheckedChanged += chkDeadlineNA_CheckedChanged;
                }
            }
        }

        private DateTimePicker _dtpDeliveryDeadline;

        internal DateTimePicker dtpDeliveryDeadline
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDeliveryDeadline;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDeliveryDeadline != null)
                {
                }

                _dtpDeliveryDeadline = value;
                if (_dtpDeliveryDeadline != null)
                {
                }
            }
        }

        private TabPage _tabDocuments;

        internal TabPage tabDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabDocuments != null)
                {
                }

                _tabDocuments = value;
                if (_tabDocuments != null)
                {
                }
            }
        }

        private Panel _pnlDocuments;

        internal Panel pnlDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlDocuments != null)
                {
                }

                _pnlDocuments = value;
                if (_pnlDocuments != null)
                {
                }
            }
        }

        private Label _lblOrderStatus;

        internal Label lblOrderStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOrderStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOrderStatus != null)
                {
                    _lblOrderStatus.Click -= lblOrderStatus_Click;
                }

                _lblOrderStatus = value;
                if (_lblOrderStatus != null)
                {
                    _lblOrderStatus.Click += lblOrderStatus_Click;
                }
            }
        }

        private Label _Label7;

        internal Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label7 != null)
                {
                }

                _Label7 = value;
                if (_Label7 != null)
                {
                }
            }
        }

        private Button _btnCreatePartRequest;

        internal Button btnCreatePartRequest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreatePartRequest;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreatePartRequest != null)
                {
                    _btnCreatePartRequest.Click -= btnCreatePartRequest_Click;
                }

                _btnCreatePartRequest = value;
                if (_btnCreatePartRequest != null)
                {
                    _btnCreatePartRequest.Click += btnCreatePartRequest_Click;
                }
            }
        }

        private Button _btnCreateProductPriceRequest;

        internal Button btnCreateProductPriceRequest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreateProductPriceRequest;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreateProductPriceRequest != null)
                {
                    _btnCreateProductPriceRequest.Click -= btnCreateProductPriceRequest_Click;
                }

                _btnCreateProductPriceRequest = value;
                if (_btnCreateProductPriceRequest != null)
                {
                    _btnCreateProductPriceRequest.Click += btnCreateProductPriceRequest_Click;
                }
            }
        }

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

        private DataGrid _dgPriceRequests;

        internal DataGrid dgPriceRequests
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPriceRequests;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPriceRequests != null)
                {
                    _dgPriceRequests.Click -= dgPriceRequests_Click;
                    _dgPriceRequests.CurrentCellChanged -= dgPriceRequests_Click;
                }

                _dgPriceRequests = value;
                if (_dgPriceRequests != null)
                {
                    _dgPriceRequests.Click += dgPriceRequests_Click;
                    _dgPriceRequests.CurrentCellChanged += dgPriceRequests_Click;
                }
            }
        }

        private DateTimePicker _dtpSupplierInvoiceDateNew;

        internal DateTimePicker dtpSupplierInvoiceDateNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpSupplierInvoiceDateNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpSupplierInvoiceDateNew != null)
                {
                }

                _dtpSupplierInvoiceDateNew = value;
                if (_dtpSupplierInvoiceDateNew != null)
                {
                }
            }
        }

        private Label _Label17;

        internal Label Label17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label17 != null)
                {
                }

                _Label17 = value;
                if (_Label17 != null)
                {
                }
            }
        }

        private TextBox _txtNominalCodeNew;

        internal TextBox txtNominalCodeNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNominalCodeNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNominalCodeNew != null)
                {
                }

                _txtNominalCodeNew = value;
                if (_txtNominalCodeNew != null)
                {
                }
            }
        }

        private Label _Label16;

        internal Label Label16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label16 != null)
                {
                }

                _Label16 = value;
                if (_Label16 != null)
                {
                }
            }
        }

        private TextBox _txtExtraReferenceNew;

        internal TextBox txtExtraReferenceNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtExtraReferenceNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtExtraReferenceNew != null)
                {
                }

                _txtExtraReferenceNew = value;
                if (_txtExtraReferenceNew != null)
                {
                }
            }
        }

        private Label _Label15;

        internal Label Label15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label15 != null)
                {
                }

                _Label15 = value;
                if (_Label15 != null)
                {
                }
            }
        }

        private ComboBox _cboInvoiceTaxCodeNew;

        internal ComboBox cboInvoiceTaxCodeNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInvoiceTaxCodeNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInvoiceTaxCodeNew != null)
                {
                    _cboInvoiceTaxCodeNew.SelectedIndexChanged -= cboTaxCode_SelectedIndexChanged;
                }

                _cboInvoiceTaxCodeNew = value;
                if (_cboInvoiceTaxCodeNew != null)
                {
                    _cboInvoiceTaxCodeNew.SelectedIndexChanged += cboTaxCode_SelectedIndexChanged;
                }
            }
        }

        private Label _Label13;

        internal Label Label13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label13 != null)
                {
                }

                _Label13 = value;
                if (_Label13 != null)
                {
                }
            }
        }

        private Button _btnReceiveAll;

        internal Button btnReceiveAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReceiveAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReceiveAll != null)
                {
                    _btnReceiveAll.Click -= btnReceiveAll_Click;
                }

                _btnReceiveAll = value;
                if (_btnReceiveAll != null)
                {
                    _btnReceiveAll.Click += btnReceiveAll_Click;
                }
            }
        }

        private Button _btnEngineerReceived;

        internal Button btnEngineerReceived
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEngineerReceived;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEngineerReceived != null)
                {
                    _btnEngineerReceived.Click -= btnEngineerReceived_Click;
                }

                _btnEngineerReceived = value;
                if (_btnEngineerReceived != null)
                {
                    _btnEngineerReceived.Click += btnEngineerReceived_Click;
                }
            }
        }

        private CheckBox _chkDoNotConsolidate;

        internal CheckBox chkDoNotConsolidate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDoNotConsolidate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDoNotConsolidate != null)
                {
                }

                _chkDoNotConsolidate = value;
                if (_chkDoNotConsolidate != null)
                {
                }
            }
        }

        private TabPage _tabInvoices;

        internal TabPage tabInvoices
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabInvoices;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabInvoices != null)
                {
                }

                _tabInvoices = value;
                if (_tabInvoices != null)
                {
                }
            }
        }

        private GroupBox _grpReceivedInvoices;

        internal GroupBox grpReceivedInvoices
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpReceivedInvoices;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpReceivedInvoices != null)
                {
                }

                _grpReceivedInvoices = value;
                if (_grpReceivedInvoices != null)
                {
                }
            }
        }

        private DataGridView _dgvReceivedInvoices;

        internal DataGridView dgvReceivedInvoices
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvReceivedInvoices;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvReceivedInvoices != null)
                {
                    _dgvReceivedInvoices.CellClick -= dgvReceivedInvoices_CellClick;
                }

                _dgvReceivedInvoices = value;
                if (_dgvReceivedInvoices != null)
                {
                    _dgvReceivedInvoices.CellClick += dgvReceivedInvoices_CellClick;
                }
            }
        }

        private BindingSource _FSMDataSetBindingSource;

        internal BindingSource FSMDataSetBindingSource
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FSMDataSetBindingSource;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FSMDataSetBindingSource != null)
                {
                }

                _FSMDataSetBindingSource = value;
                if (_FSMDataSetBindingSource != null)
                {
                }
            }
        }

        private FSMDataSet _FSMDataSet;

        internal FSMDataSet FSMDataSet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FSMDataSet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FSMDataSet != null)
                {
                }

                _FSMDataSet = value;
                if (_FSMDataSet != null)
                {
                }
            }
        }

        private Button _btnAddSupplierInvoice;

        internal Button btnAddSupplierInvoice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddSupplierInvoice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddSupplierInvoice != null)
                {
                    _btnAddSupplierInvoice.Click -= btnAddSupplierInvoice_Click;
                }

                _btnAddSupplierInvoice = value;
                if (_btnAddSupplierInvoice != null)
                {
                    _btnAddSupplierInvoice.Click += btnAddSupplierInvoice_Click;
                }
            }
        }

        private TextBox _txtTotalAmount;

        internal TextBox txtTotalAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTotalAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTotalAmount != null)
                {
                }

                _txtTotalAmount = value;
                if (_txtTotalAmount != null)
                {
                }
            }
        }

        private Label _lblTotalValue;

        internal Label lblTotalValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTotalValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTotalValue != null)
                {
                }

                _lblTotalValue = value;
                if (_lblTotalValue != null)
                {
                }
            }
        }

        private TextBox _txtVATAmount;

        internal TextBox txtVATAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVATAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVATAmount != null)
                {
                    _txtVATAmount.LostFocus -= txtVATAmount_LostFocus;
                }

                _txtVATAmount = value;
                if (_txtVATAmount != null)
                {
                    _txtVATAmount.LostFocus += txtVATAmount_LostFocus;
                }
            }
        }

        private Label _lblVatValue;

        internal Label lblVatValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVatValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVatValue != null)
                {
                }

                _lblVatValue = value;
                if (_lblVatValue != null)
                {
                }
            }
        }

        private TextBox _txtGoodsAmount;

        internal TextBox txtGoodsAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtGoodsAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtGoodsAmount != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _txtGoodsAmount.LostFocus -= txtGoodsAmount_TextChanged;
                }

                _txtGoodsAmount = value;
                if (_txtGoodsAmount != null)
                {
                    _txtGoodsAmount.LostFocus += txtGoodsAmount_TextChanged;
                }
            }
        }

        private Label _lblGoodsValue;

        internal Label lblGoodsValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblGoodsValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblGoodsValue != null)
                {
                }

                _lblGoodsValue = value;
                if (_lblGoodsValue != null)
                {
                }
            }
        }

        private Label _lblInvoiceDate;

        internal Label lblInvoiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoiceDate != null)
                {
                }

                _lblInvoiceDate = value;
                if (_lblInvoiceDate != null)
                {
                }
            }
        }

        private TextBox _txtSupplierInvoiceRefNew;

        internal TextBox txtSupplierInvoiceRefNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplierInvoiceRefNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplierInvoiceRefNew != null)
                {
                }

                _txtSupplierInvoiceRefNew = value;
                if (_txtSupplierInvoiceRefNew != null)
                {
                }
            }
        }

        private Label _lblSupplierRef;

        internal Label lblSupplierRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSupplierRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSupplierRef != null)
                {
                }

                _lblSupplierRef = value;
                if (_lblSupplierRef != null)
                {
                }
            }
        }

        private Label _lblSupplierGoods;

        internal Label lblSupplierGoods
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSupplierGoods;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSupplierGoods != null)
                {
                }

                _lblSupplierGoods = value;
                if (_lblSupplierGoods != null)
                {
                }
            }
        }

        private Label _lblGoodsTotal;

        internal Label lblGoodsTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblGoodsTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblGoodsTotal != null)
                {
                }

                _lblGoodsTotal = value;
                if (_lblGoodsTotal != null)
                {
                }
            }
        }

        private Label _lblOrderTotal;

        internal Label lblOrderTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOrderTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOrderTotal != null)
                {
                }

                _lblOrderTotal = value;
                if (_lblOrderTotal != null)
                {
                }
            }
        }

        private Label _lblOrderTotalLabel;

        internal Label lblOrderTotalLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOrderTotalLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOrderTotalLabel != null)
                {
                }

                _lblOrderTotalLabel = value;
                if (_lblOrderTotalLabel != null)
                {
                }
            }
        }

        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private CheckBox _cboReadySageNew;

        internal CheckBox cboReadySageNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboReadySageNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboReadySageNew != null)
                {
                }

                _cboReadySageNew = value;
                if (_cboReadySageNew != null)
                {
                }
            }
        }

        private Button _btnUpdateSupplierInvoice;

        internal Button btnUpdateSupplierInvoice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdateSupplierInvoice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdateSupplierInvoice != null)
                {
                    _btnUpdateSupplierInvoice.Click -= btnUpdateSupplierInvoice_Click;
                }

                _btnUpdateSupplierInvoice = value;
                if (_btnUpdateSupplierInvoice != null)
                {
                    _btnUpdateSupplierInvoice.Click += btnUpdateSupplierInvoice_Click;
                }
            }
        }

        private Button _btnDeleteSupplierInvoice;

        internal Button btnDeleteSupplierInvoice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteSupplierInvoice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteSupplierInvoice != null)
                {
                    _btnDeleteSupplierInvoice.Click -= btnDeleteSupplierInvoice_Click;
                }

                _btnDeleteSupplierInvoice = value;
                if (_btnDeleteSupplierInvoice != null)
                {
                    _btnDeleteSupplierInvoice.Click += btnDeleteSupplierInvoice_Click;
                }
            }
        }

        private CheckBox _chkRevertStatus;

        internal CheckBox chkRevertStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkRevertStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkRevertStatus != null)
                {
                }

                _chkRevertStatus = value;
                if (_chkRevertStatus != null)
                {
                }
            }
        }

        private TabPage _TabPage1;

        internal TabPage TabPage1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPage1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPage1 != null)
                {
                }

                _TabPage1 = value;
                if (_TabPage1 != null)
                {
                }
            }
        }

        private GroupBox _GroupBox4;

        internal GroupBox GroupBox4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox4 != null)
                {
                }

                _GroupBox4 = value;
                if (_GroupBox4 != null)
                {
                }
            }
        }

        private Button _btnCreditDelete;

        internal Button btnCreditDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreditDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreditDelete != null)
                {
                    _btnCreditDelete.Click -= btnDeleteCredit_Click;
                }

                _btnCreditDelete = value;
                if (_btnCreditDelete != null)
                {
                    _btnCreditDelete.Click += btnDeleteCredit_Click;
                }
            }
        }

        private TextBox _txtCreditTotal;

        internal TextBox txtCreditTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCreditTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCreditTotal != null)
                {
                }

                _txtCreditTotal = value;
                if (_txtCreditTotal != null)
                {
                }
            }
        }

        private Label _Label9;

        internal Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label9 != null)
                {
                }

                _Label9 = value;
                if (_Label9 != null)
                {
                }
            }
        }

        private TextBox _txtCreditVAT;

        internal TextBox txtCreditVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCreditVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCreditVAT != null)
                {
                    _txtCreditVAT.LostFocus -= txtCreditVAT__LostFocus;
                }

                _txtCreditVAT = value;
                if (_txtCreditVAT != null)
                {
                    _txtCreditVAT.LostFocus += txtCreditVAT__LostFocus;
                }
            }
        }

        private TextBox _txtCreditNominal;

        internal TextBox txtCreditNominal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCreditNominal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCreditNominal != null)
                {
                }

                _txtCreditNominal = value;
                if (_txtCreditNominal != null)
                {
                }
            }
        }

        private Label _Label10;

        internal Label Label10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label10 != null)
                {
                }

                _Label10 = value;
                if (_Label10 != null)
                {
                }
            }
        }

        private Label _Label14;

        internal Label Label14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label14 != null)
                {
                }

                _Label14 = value;
                if (_Label14 != null)
                {
                }
            }
        }

        private TextBox _txtCreditGoods;

        internal TextBox txtCreditGoods
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCreditGoods;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCreditGoods != null)
                {
                    _txtCreditGoods.LostFocus -= txtCreditAmount_TextChanged;
                }

                _txtCreditGoods = value;
                if (_txtCreditGoods != null)
                {
                    _txtCreditGoods.LostFocus += txtCreditAmount_TextChanged;
                }
            }
        }

        private ComboBox _cboCreditTax;

        internal ComboBox cboCreditTax
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCreditTax;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCreditTax != null)
                {
                    _cboCreditTax.SelectedIndexChanged -= cboCreditTaxCode_SelectedIndexChanged;
                }

                _cboCreditTax = value;
                if (_cboCreditTax != null)
                {
                    _cboCreditTax.SelectedIndexChanged += cboCreditTaxCode_SelectedIndexChanged;
                }
            }
        }

        private Label _Label18;

        internal Label Label18
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label18;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label18 != null)
                {
                }

                _Label18 = value;
                if (_Label18 != null)
                {
                }
            }
        }

        private Label _Label20;

        internal Label Label20
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label20;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label20 != null)
                {
                }

                _Label20 = value;
                if (_Label20 != null)
                {
                }
            }
        }

        private TextBox _txtCreditRef;

        internal TextBox txtCreditRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCreditRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCreditRef != null)
                {
                }

                _txtCreditRef = value;
                if (_txtCreditRef != null)
                {
                }
            }
        }

        private Label _Label23;

        internal Label Label23
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label23;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label23 != null)
                {
                }

                _Label23 = value;
                if (_Label23 != null)
                {
                }
            }
        }

        private Button _btnCreditAdd;

        internal Button btnCreditAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreditAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreditAdd != null)
                {
                    _btnCreditAdd.Click -= btnCreditAdd_Click;
                }

                _btnCreditAdd = value;
                if (_btnCreditAdd != null)
                {
                    _btnCreditAdd.Click += btnCreditAdd_Click;
                }
            }
        }

        private DataGridView _dgCredits;

        internal DataGridView dgCredits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgCredits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgCredits != null)
                {
                    _dgCredits.CellClick -= dgCredits_CellClick;
                }

                _dgCredits = value;
                if (_dgCredits != null)
                {
                    _dgCredits.CellClick += dgCredits_CellClick;
                }
            }
        }

        private DateTimePicker _dtpCreditDate;

        internal DateTimePicker dtpCreditDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpCreditDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpCreditDate != null)
                {
                }

                _dtpCreditDate = value;
                if (_dtpCreditDate != null)
                {
                }
            }
        }

        private Label _lblCredits;

        internal Label lblCredits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCredits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCredits != null)
                {
                }

                _lblCredits = value;
                if (_lblCredits != null)
                {
                }
            }
        }

        private Label _Label25;

        internal Label Label25
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label25;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label25 != null)
                {
                }

                _Label25 = value;
                if (_Label25 != null)
                {
                }
            }
        }

        private Label _lblOrderBalance;

        internal Label lblOrderBalance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOrderBalance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOrderBalance != null)
                {
                }

                _lblOrderBalance = value;
                if (_lblOrderBalance != null)
                {
                }
            }
        }

        private Label _lblOrderBalanceLabel;

        internal Label lblOrderBalanceLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOrderBalanceLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOrderBalanceLabel != null)
                {
                }

                _lblOrderBalanceLabel = value;
                if (_lblOrderBalanceLabel != null)
                {
                }
            }
        }

        private CheckBox _CheckBox1;

        internal CheckBox CheckBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBox1 != null)
                {
                }

                _CheckBox1 = value;
                if (_CheckBox1 != null)
                {
                }
            }
        }

        private TextBox _txtCreditExRef;

        internal TextBox txtCreditExRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCreditExRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCreditExRef != null)
                {
                }

                _txtCreditExRef = value;
                if (_txtCreditExRef != null)
                {
                }
            }
        }

        private Label _Label21;

        internal Label Label21
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label21;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label21 != null)
                {
                }

                _Label21 = value;
                if (_Label21 != null)
                {
                }
            }
        }

        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        private ComboBox _cboDept;

        internal ComboBox cboDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDept != null)
                {
                }

                _cboDept = value;
                if (_cboDept != null)
                {
                }
            }
        }

        private NumericUpDown _nudItemQty;

        internal NumericUpDown nudItemQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _nudItemQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_nudItemQty != null)
                {
                }

                _nudItemQty = value;
                if (_nudItemQty != null)
                {
                }
            }
        }

        private Button _btnUpdateOrderRef;

        internal Button btnUpdateOrderRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdateOrderRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdateOrderRef != null)
                {
                    _btnUpdateOrderRef.Click -= btnUpdateOrderRef_Click;
                }

                _btnUpdateOrderRef = value;
                if (_btnUpdateOrderRef != null)
                {
                    _btnUpdateOrderRef.Click += btnUpdateOrderRef_Click;
                }
            }
        }

        private Button _btnApproveOrder;

        internal Button btnApproveOrder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnApproveOrder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnApproveOrder != null)
                {
                    _btnApproveOrder.Click -= btnApproveOrder_Click;
                }

                _btnApproveOrder = value;
                if (_btnApproveOrder != null)
                {
                    _btnApproveOrder.Click += btnApproveOrder_Click;
                }
            }
        }

        private DataGrid _dgParts;

        internal DataGrid dgParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgParts != null)
                {
                    _dgParts.DoubleClick -= dgParts_DoubleClick;
                    _dgParts.Click -= dgParts_Click;
                    _dgParts.CurrentCellChanged -= dgParts_Click;
                }

                _dgParts = value;
                if (_dgParts != null)
                {
                    _dgParts.DoubleClick += dgParts_DoubleClick;
                    _dgParts.Click += dgParts_Click;
                    _dgParts.CurrentCellChanged += dgParts_Click;
                }
            }
        }

        private Button _btnRelatedJob;

        internal Button btnRelatedJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRelatedJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRelatedJob != null)
                {
                    _btnRelatedJob.Click -= btnRelatedJob_Click;
                }

                _btnRelatedJob = value;
                if (_btnRelatedJob != null)
                {
                    _btnRelatedJob.Click += btnRelatedJob_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var DataGridViewCellStyle1 = new DataGridViewCellStyle();
            var DataGridViewCellStyle2 = new DataGridViewCellStyle();
            var DataGridViewCellStyle3 = new DataGridViewCellStyle();
            var DataGridViewCellStyle4 = new DataGridViewCellStyle();
            var DataGridViewCellStyle5 = new DataGridViewCellStyle();
            var DataGridViewCellStyle6 = new DataGridViewCellStyle();
            _grpOrder = new GroupBox();
            _btnApproveOrder = new Button();
            _btnApproveOrder.Click += new EventHandler(btnApproveOrder_Click);
            _btnUpdateOrderRef = new Button();
            _btnUpdateOrderRef.Click += new EventHandler(btnUpdateOrderRef_Click);
            _cboDept = new ComboBox();
            _lblOrderBalance = new Label();
            _lblOrderBalanceLabel = new Label();
            _chkRevertStatus = new CheckBox();
            _lblOrderTotalLabel = new Label();
            _lblOrderTotal = new Label();
            _chkDoNotConsolidate = new CheckBox();
            _chkDeadlineNA = new CheckBox();
            _chkDeadlineNA.CheckedChanged += new EventHandler(chkDeadlineNA_CheckedChanged);
            _dtpDeliveryDeadline = new DateTimePicker();
            _Label6 = new Label();
            _cboOrderStatus = new ComboBox();
            _cboOrderStatus.SelectedIndexChanged += new EventHandler(cboOrderStatus_SelectedIndexChanged);
            _Label19 = new Label();
            _dtpDatePlaced = new DateTimePicker();
            _lblDatePlaced = new Label();
            _txtOrderReference = new TextBox();
            _lblOrderReference = new Label();
            _tcOrderDetails = new TabControl();
            _tcOrderDetails.SelectedIndexChanged += new EventHandler(tcOrderDetails_SelectedIndexChanged);
            _tabDetails = new TabPage();
            _btnRelatedJob = new Button();
            _btnRelatedJob.Click += new EventHandler(btnRelatedJob_Click);
            _pnlDetails = new Panel();
            _lblOrderTypeID = new Label();
            _cboOrderTypeID = new ComboBox();
            _cboOrderTypeID.SelectedIndexChanged += new EventHandler(cboOrderTypeID_SelectedIndexChanged);
            _btnCharges = new Button();
            _btnCharges.Click += new EventHandler(btnCharges_Click);
            _tabParts = new TabPage();
            _grpPartSearch = new GroupBox();
            _btnAddNewPart = new Button();
            _btnAddNewPart.Click += new EventHandler(btnAddNewPart_Click);
            _cboPartLocation = new ComboBox();
            _cboPartLocation.SelectedIndexChanged += new EventHandler(cboPartLocation_SelectedIndexChanged);
            _btnPartSearch = new Button();
            _btnPartSearch.Click += new EventHandler(btnPartSearch_Click);
            _txtPartSearch = new TextBox();
            _txtPartSearch.KeyDown += new KeyEventHandler(txtPartSearch_KeyDown);
            _grpAvailableParts = new GroupBox();
            _btnCreatePartRequest = new Button();
            _btnCreatePartRequest.Click += new EventHandler(btnCreatePartRequest_Click);
            _Label7 = new Label();
            _txtPartBuyPrice = new TextBox();
            _Label3 = new Label();
            _txtPartQuantity = new TextBox();
            _btnAddPart = new Button();
            _btnAddPart.Click += new EventHandler(btnAddPart_Click);
            _tabProducts = new TabPage();
            _grpProductsAvailable = new GroupBox();
            _btnCreateProductPriceRequest = new Button();
            _btnCreateProductPriceRequest.Click += new EventHandler(btnCreateProductPriceRequest_Click);
            _txtProductSellPrice = new TextBox();
            _Label5 = new Label();
            _txtProductBuyPrice = new TextBox();
            _Label4 = new Label();
            _Label1 = new Label();
            _txtProductQuantity = new TextBox();
            _dgProduct = new DataGrid();
            _dgProduct.DoubleClick += new EventHandler(dgProduct_DoubleClick);
            _dgProduct.Click += new EventHandler(dgProduct_Click);
            _dgProduct.CurrentCellChanged += new EventHandler(dgProduct_Click);
            _dgProduct.Click += new EventHandler(dgProduct_Click);
            _dgProduct.CurrentCellChanged += new EventHandler(dgProduct_Click);
            _btnAddProduct = new Button();
            _btnAddProduct.Click += new EventHandler(btnAddProduct_Click);
            _grpProductSearch = new GroupBox();
            _btnAddNewProduct = new Button();
            _btnAddNewProduct.Click += new EventHandler(btnAddNewProduct_Click);
            _cboProductLocation = new ComboBox();
            _cboProductLocation.SelectedIndexChanged += new EventHandler(cboProductLocation_SelectedIndexChanged);
            _btnProductSearch = new Button();
            _btnProductSearch.Click += new EventHandler(btnProductSearch_Click);
            _txtProductSearch = new TextBox();
            _txtProductSearch.KeyDown += new KeyEventHandler(txtProductSearch_KeyDown);
            _tabItemsIncluded = new TabPage();
            _GroupBox3 = new GroupBox();
            _nudItemQty = new NumericUpDown();
            _btnEngineerReceived = new Button();
            _btnEngineerReceived.Click += new EventHandler(btnEngineerReceived_Click);
            _btnReceiveAll = new Button();
            _btnReceiveAll.Click += new EventHandler(btnReceiveAll_Click);
            _lblItemQty = new Label();
            _btnItemQtyUpdate = new Button();
            _btnItemQtyUpdate.Click += new EventHandler(btnItemRemove_Click);
            _dgItemsIncluded = new DataGrid();
            _dgItemsIncluded.DoubleClick += new EventHandler(dgProduct_Click);
            _dgItemsIncluded.Click += new EventHandler(dgItemsIncluded_Click);
            _tabPartPriceReq = new TabPage();
            _GroupBox2 = new GroupBox();
            _btnUpdatePartPriceRequest = new Button();
            _btnUpdatePartPriceRequest.Click += new EventHandler(btnUpdatePartPriceRequest_Click);
            _dgPriceRequests = new DataGrid();
            _dgPriceRequests.Click += new EventHandler(dgPriceRequests_Click);
            _dgPriceRequests.CurrentCellChanged += new EventHandler(dgPriceRequests_Click);
            _dgPriceRequests.Click += new EventHandler(dgPriceRequests_Click);
            _dgPriceRequests.CurrentCellChanged += new EventHandler(dgPriceRequests_Click);
            _tabDocuments = new TabPage();
            _pnlDocuments = new Panel();
            _btnEmail = new Button();
            _btnEmail.Click += new EventHandler(btnEmail_Click);
            _cboPrintType = new ComboBox();
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click);
            _Label8 = new Label();
            _tabInvoices = new TabPage();
            _grpReceivedInvoices = new GroupBox();
            _btnDeleteSupplierInvoice = new Button();
            _btnDeleteSupplierInvoice.Click += new EventHandler(btnDeleteSupplierInvoice_Click);
            _btnUpdateSupplierInvoice = new Button();
            _btnUpdateSupplierInvoice.Click += new EventHandler(btnUpdateSupplierInvoice_Click);
            _txtTotalAmount = new TextBox();
            _lblTotalValue = new Label();
            _txtVATAmount = new TextBox();
            _txtVATAmount.LostFocus += new EventHandler(txtVATAmount_LostFocus);
            _txtNominalCodeNew = new TextBox();
            _Label16 = new Label();
            _lblVatValue = new Label();
            _txtGoodsAmount = new TextBox();
            _txtGoodsAmount.LostFocus += new EventHandler(txtGoodsAmount_TextChanged);
            _cboInvoiceTaxCodeNew = new ComboBox();
            _cboInvoiceTaxCodeNew.SelectedIndexChanged += new EventHandler(cboTaxCode_SelectedIndexChanged);
            _txtExtraReferenceNew = new TextBox();
            _Label13 = new Label();
            _lblGoodsValue = new Label();
            _Label15 = new Label();
            _lblInvoiceDate = new Label();
            _txtSupplierInvoiceRefNew = new TextBox();
            _lblSupplierRef = new Label();
            _btnAddSupplierInvoice = new Button();
            _btnAddSupplierInvoice.Click += new EventHandler(btnAddSupplierInvoice_Click);
            _dgvReceivedInvoices = new DataGridView();
            _dgvReceivedInvoices.CellClick += new DataGridViewCellEventHandler(dgvReceivedInvoices_CellClick);
            _dtpSupplierInvoiceDateNew = new DateTimePicker();
            _cboReadySageNew = new CheckBox();
            _TabPage1 = new TabPage();
            _GroupBox4 = new GroupBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _CheckBox1 = new CheckBox();
            _txtCreditExRef = new TextBox();
            _Label21 = new Label();
            _btnCreditDelete = new Button();
            _btnCreditDelete.Click += new EventHandler(btnDeleteCredit_Click);
            _txtCreditTotal = new TextBox();
            _Label9 = new Label();
            _txtCreditVAT = new TextBox();
            _txtCreditVAT.LostFocus += new EventHandler(txtCreditVAT__LostFocus);
            _txtCreditNominal = new TextBox();
            _Label10 = new Label();
            _Label14 = new Label();
            _txtCreditGoods = new TextBox();
            _txtCreditGoods.LostFocus += new EventHandler(txtCreditAmount_TextChanged);
            _cboCreditTax = new ComboBox();
            _cboCreditTax.SelectedIndexChanged += new EventHandler(cboCreditTaxCode_SelectedIndexChanged);
            _Label18 = new Label();
            _Label20 = new Label();
            _txtCreditRef = new TextBox();
            _Label23 = new Label();
            _btnCreditAdd = new Button();
            _btnCreditAdd.Click += new EventHandler(btnCreditAdd_Click);
            _dgCredits = new DataGridView();
            _dgCredits.CellClick += new DataGridViewCellEventHandler(dgCredits_CellClick);
            _dtpCreditDate = new DateTimePicker();
            _lblOrderStatus = new Label();
            _lblOrderStatus.Click += new EventHandler(lblOrderStatus_Click);
            _GroupBox1 = new GroupBox();
            _lblCredits = new Label();
            _Label25 = new Label();
            _lblSupplierGoods = new Label();
            _lblGoodsTotal = new Label();
            _Label17 = new Label();
            _FSMDataSetBindingSource = new BindingSource(components);
            _FSMDataSet = new FSMDataSet();
            _dgParts = new DataGrid();
            _dgParts.DoubleClick += new EventHandler(dgParts_DoubleClick);
            _dgParts.Click += new EventHandler(dgParts_Click);
            _dgParts.CurrentCellChanged += new EventHandler(dgParts_Click);
            _dgParts.Click += new EventHandler(dgParts_Click);
            _dgParts.CurrentCellChanged += new EventHandler(dgParts_Click);
            _grpOrder.SuspendLayout();
            _tcOrderDetails.SuspendLayout();
            _tabDetails.SuspendLayout();
            _tabParts.SuspendLayout();
            _grpPartSearch.SuspendLayout();
            _grpAvailableParts.SuspendLayout();
            _tabProducts.SuspendLayout();
            _grpProductsAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgProduct).BeginInit();
            _grpProductSearch.SuspendLayout();
            _tabItemsIncluded.SuspendLayout();
            _GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_nudItemQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgItemsIncluded).BeginInit();
            _tabPartPriceReq.SuspendLayout();
            _GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPriceRequests).BeginInit();
            _tabDocuments.SuspendLayout();
            _tabInvoices.SuspendLayout();
            _grpReceivedInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvReceivedInvoices).BeginInit();
            _TabPage1.SuspendLayout();
            _GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCredits).BeginInit();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_FSMDataSetBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_FSMDataSet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgParts).BeginInit();
            SuspendLayout();
            // 
            // grpOrder
            // 
            _grpOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpOrder.Controls.Add(_btnApproveOrder);
            _grpOrder.Controls.Add(_btnUpdateOrderRef);
            _grpOrder.Controls.Add(_cboDept);
            _grpOrder.Controls.Add(_lblOrderBalance);
            _grpOrder.Controls.Add(_lblOrderBalanceLabel);
            _grpOrder.Controls.Add(_chkRevertStatus);
            _grpOrder.Controls.Add(_lblOrderTotalLabel);
            _grpOrder.Controls.Add(_lblOrderTotal);
            _grpOrder.Controls.Add(_chkDoNotConsolidate);
            _grpOrder.Controls.Add(_chkDeadlineNA);
            _grpOrder.Controls.Add(_dtpDeliveryDeadline);
            _grpOrder.Controls.Add(_Label6);
            _grpOrder.Controls.Add(_cboOrderStatus);
            _grpOrder.Controls.Add(_Label19);
            _grpOrder.Controls.Add(_dtpDatePlaced);
            _grpOrder.Controls.Add(_lblDatePlaced);
            _grpOrder.Controls.Add(_txtOrderReference);
            _grpOrder.Controls.Add(_lblOrderReference);
            _grpOrder.Controls.Add(_tcOrderDetails);
            _grpOrder.Controls.Add(_lblOrderStatus);
            _grpOrder.Controls.Add(_GroupBox1);
            _grpOrder.Controls.Add(_Label17);
            _grpOrder.Location = new Point(8, 1);
            _grpOrder.Name = "grpOrder";
            _grpOrder.Size = new Size(1822, 561);
            _grpOrder.TabIndex = 1;
            _grpOrder.TabStop = false;
            _grpOrder.Text = "Main Details";
            // 
            // btnApproveOrder
            // 
            _btnApproveOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnApproveOrder.Location = new Point(1421, 17);
            _btnApproveOrder.Name = "btnApproveOrder";
            _btnApproveOrder.Size = new Size(120, 23);
            _btnApproveOrder.TabIndex = 126;
            _btnApproveOrder.Text = "Approve Order";
            _btnApproveOrder.Visible = false;
            // 
            // btnUpdateOrderRef
            // 
            _btnUpdateOrderRef.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnUpdateOrderRef.Location = new Point(1230, 17);
            _btnUpdateOrderRef.Name = "btnUpdateOrderRef";
            _btnUpdateOrderRef.Size = new Size(120, 23);
            _btnUpdateOrderRef.TabIndex = 125;
            _btnUpdateOrderRef.Text = "Change Order Ref";
            _btnUpdateOrderRef.Visible = false;
            // 
            // cboDept
            // 
            _cboDept.FormattingEnabled = true;
            _cboDept.Location = new Point(80, 94);
            _cboDept.Name = "cboDept";
            _cboDept.Size = new Size(170, 21);
            _cboDept.TabIndex = 124;
            // 
            // lblOrderBalance
            // 
            _lblOrderBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblOrderBalance.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblOrderBalance.Location = new Point(1685, 107);
            _lblOrderBalance.Name = "lblOrderBalance";
            _lblOrderBalance.Size = new Size(122, 15);
            _lblOrderBalance.TabIndex = 84;
            _lblOrderBalance.Text = "£0.00";
            _lblOrderBalance.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblOrderBalanceLabel
            // 
            _lblOrderBalanceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblOrderBalanceLabel.AutoSize = true;
            _lblOrderBalanceLabel.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblOrderBalanceLabel.Location = new Point(1563, 108);
            _lblOrderBalanceLabel.Name = "lblOrderBalanceLabel";
            _lblOrderBalanceLabel.Size = new Size(96, 13);
            _lblOrderBalanceLabel.TabIndex = 85;
            _lblOrderBalanceLabel.Text = "Unallocated : ";
            _lblOrderBalanceLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // chkRevertStatus
            // 
            _chkRevertStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkRevertStatus.AutoSize = true;
            _chkRevertStatus.Location = new Point(1230, 97);
            _chkRevertStatus.Name = "chkRevertStatus";
            _chkRevertStatus.Size = new Size(209, 17);
            _chkRevertStatus.TabIndex = 78;
            _chkRevertStatus.Text = "Revert to Awaiting Confirmation";
            _chkRevertStatus.UseVisualStyleBackColor = true;
            _chkRevertStatus.Visible = false;
            // 
            // lblOrderTotalLabel
            // 
            _lblOrderTotalLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblOrderTotalLabel.AutoSize = true;
            _lblOrderTotalLabel.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblOrderTotalLabel.Location = new Point(1559, 13);
            _lblOrderTotalLabel.Name = "lblOrderTotalLabel";
            _lblOrderTotalLabel.Size = new Size(157, 13);
            _lblOrderTotalLabel.TabIndex = 77;
            _lblOrderTotalLabel.Text = "Purchase Order Total : ";
            _lblOrderTotalLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // lblOrderTotal
            // 
            _lblOrderTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblOrderTotal.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblOrderTotal.Location = new Point(1731, 12);
            _lblOrderTotal.Name = "lblOrderTotal";
            _lblOrderTotal.Size = new Size(75, 15);
            _lblOrderTotal.TabIndex = 76;
            _lblOrderTotal.Text = "£0.00";
            _lblOrderTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkDoNotConsolidate
            // 
            _chkDoNotConsolidate.AutoSize = true;
            _chkDoNotConsolidate.Location = new Point(256, 97);
            _chkDoNotConsolidate.Name = "chkDoNotConsolidate";
            _chkDoNotConsolidate.Size = new Size(136, 17);
            _chkDoNotConsolidate.TabIndex = 69;
            _chkDoNotConsolidate.Text = "Do Not Consolidate";
            _chkDoNotConsolidate.UseVisualStyleBackColor = true;
            _chkDoNotConsolidate.Visible = false;
            // 
            // chkDeadlineNA
            // 
            _chkDeadlineNA.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkDeadlineNA.Location = new Point(1347, 66);
            _chkDeadlineNA.Name = "chkDeadlineNA";
            _chkDeadlineNA.Size = new Size(48, 24);
            _chkDeadlineNA.TabIndex = 4;
            _chkDeadlineNA.Text = "N/A";
            // 
            // dtpDeliveryDeadline
            // 
            _dtpDeliveryDeadline.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpDeliveryDeadline.Location = new Point(1398, 66);
            _dtpDeliveryDeadline.Name = "dtpDeliveryDeadline";
            _dtpDeliveryDeadline.Size = new Size(144, 21);
            _dtpDeliveryDeadline.TabIndex = 5;
            _dtpDeliveryDeadline.Tag = "Order.DatePlaced";
            // 
            // Label6
            // 
            _Label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label6.Location = new Point(1225, 70);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(114, 23);
            _Label6.TabIndex = 42;
            _Label6.Text = "Delivery Deadline";
            // 
            // cboOrderStatus
            // 
            _cboOrderStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboOrderStatus.Location = new Point(80, 43);
            _cboOrderStatus.Name = "cboOrderStatus";
            _cboOrderStatus.Size = new Size(1142, 21);
            _cboOrderStatus.TabIndex = 2;
            // 
            // Label19
            // 
            _Label19.Location = new Point(6, 43);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(48, 23);
            _Label19.TabIndex = 33;
            _Label19.Text = "Status";
            // 
            // dtpDatePlaced
            // 
            _dtpDatePlaced.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dtpDatePlaced.Location = new Point(80, 67);
            _dtpDatePlaced.Name = "dtpDatePlaced";
            _dtpDatePlaced.Size = new Size(1142, 21);
            _dtpDatePlaced.TabIndex = 3;
            _dtpDatePlaced.Tag = "Order.DatePlaced";
            // 
            // lblDatePlaced
            // 
            _lblDatePlaced.Location = new Point(6, 67);
            _lblDatePlaced.Name = "lblDatePlaced";
            _lblDatePlaced.Size = new Size(79, 20);
            _lblDatePlaced.TabIndex = 31;
            _lblDatePlaced.Text = "Date Placed";
            // 
            // txtOrderReference
            // 
            _txtOrderReference.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtOrderReference.Location = new Point(80, 19);
            _txtOrderReference.MaxLength = 100;
            _txtOrderReference.Name = "txtOrderReference";
            _txtOrderReference.ReadOnly = true;
            _txtOrderReference.Size = new Size(1142, 21);
            _txtOrderReference.TabIndex = 1;
            _txtOrderReference.Tag = "Order.OrderReference";
            _txtOrderReference.Visible = false;
            // 
            // lblOrderReference
            // 
            _lblOrderReference.Location = new Point(6, 19);
            _lblOrderReference.Name = "lblOrderReference";
            _lblOrderReference.Size = new Size(66, 20);
            _lblOrderReference.TabIndex = 31;
            _lblOrderReference.Text = "Order Ref";
            // 
            // tcOrderDetails
            // 
            _tcOrderDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcOrderDetails.Controls.Add(_tabDetails);
            _tcOrderDetails.Controls.Add(_tabParts);
            _tcOrderDetails.Controls.Add(_tabProducts);
            _tcOrderDetails.Controls.Add(_tabItemsIncluded);
            _tcOrderDetails.Controls.Add(_tabPartPriceReq);
            _tcOrderDetails.Controls.Add(_tabDocuments);
            _tcOrderDetails.Controls.Add(_tabInvoices);
            _tcOrderDetails.Controls.Add(_TabPage1);
            _tcOrderDetails.Location = new Point(11, 156);
            _tcOrderDetails.Name = "tcOrderDetails";
            _tcOrderDetails.SelectedIndex = 0;
            _tcOrderDetails.Size = new Size(1804, 399);
            _tcOrderDetails.TabIndex = 6;
            // 
            // tabDetails
            // 
            _tabDetails.Controls.Add(_btnRelatedJob);
            _tabDetails.Controls.Add(_pnlDetails);
            _tabDetails.Controls.Add(_lblOrderTypeID);
            _tabDetails.Controls.Add(_cboOrderTypeID);
            _tabDetails.Controls.Add(_btnCharges);
            _tabDetails.Location = new Point(4, 22);
            _tabDetails.Name = "tabDetails";
            _tabDetails.Size = new Size(1796, 373);
            _tabDetails.TabIndex = 0;
            _tabDetails.Text = "Order Details";
            // 
            // btnRelatedJob
            // 
            _btnRelatedJob.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnRelatedJob.Enabled = false;
            _btnRelatedJob.Location = new Point(1491, 7);
            _btnRelatedJob.Name = "btnRelatedJob";
            _btnRelatedJob.Size = new Size(120, 23);
            _btnRelatedJob.TabIndex = 32;
            _btnRelatedJob.Text = "View Related Job";
            // 
            // pnlDetails
            // 
            _pnlDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _pnlDetails.Location = new Point(0, 40);
            _pnlDetails.Name = "pnlDetails";
            _pnlDetails.Size = new Size(1793, 324);
            _pnlDetails.TabIndex = 9;
            // 
            // lblOrderTypeID
            // 
            _lblOrderTypeID.Location = new Point(8, 8);
            _lblOrderTypeID.Name = "lblOrderTypeID";
            _lblOrderTypeID.Size = new Size(64, 20);
            _lblOrderTypeID.TabIndex = 31;
            _lblOrderTypeID.Text = "Order For";
            // 
            // cboOrderTypeID
            // 
            _cboOrderTypeID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboOrderTypeID.Cursor = Cursors.Hand;
            _cboOrderTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboOrderTypeID.Location = new Point(96, 8);
            _cboOrderTypeID.Name = "cboOrderTypeID";
            _cboOrderTypeID.Size = new Size(1387, 21);
            _cboOrderTypeID.TabIndex = 7;
            _cboOrderTypeID.Tag = "Order.OrderTypeID";
            // 
            // btnCharges
            // 
            _btnCharges.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnCharges.Location = new Point(1617, 7);
            _btnCharges.Name = "btnCharges";
            _btnCharges.Size = new Size(168, 23);
            _btnCharges.TabIndex = 8;
            _btnCharges.Text = "Manage Additional Charges";
            // 
            // tabParts
            // 
            _tabParts.Controls.Add(_grpPartSearch);
            _tabParts.Controls.Add(_grpAvailableParts);
            _tabParts.Location = new Point(4, 22);
            _tabParts.Name = "tabParts";
            _tabParts.Size = new Size(1796, 373);
            _tabParts.TabIndex = 2;
            _tabParts.Text = "Parts Available";
            // 
            // grpPartSearch
            // 
            _grpPartSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpPartSearch.Controls.Add(_btnAddNewPart);
            _grpPartSearch.Controls.Add(_cboPartLocation);
            _grpPartSearch.Controls.Add(_btnPartSearch);
            _grpPartSearch.Controls.Add(_txtPartSearch);
            _grpPartSearch.Location = new Point(8, 8);
            _grpPartSearch.Name = "grpPartSearch";
            _grpPartSearch.Size = new Size(1785, 56);
            _grpPartSearch.TabIndex = 13;
            _grpPartSearch.TabStop = false;
            _grpPartSearch.Text = "Part Search From";
            // 
            // btnAddNewPart
            // 
            _btnAddNewPart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddNewPart.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnAddNewPart.Location = new Point(1708, 24);
            _btnAddNewPart.Name = "btnAddNewPart";
            _btnAddNewPart.Size = new Size(64, 22);
            _btnAddNewPart.TabIndex = 4;
            _btnAddNewPart.Text = "New Part";
            // 
            // cboPartLocation
            // 
            _cboPartLocation.Location = new Point(8, 24);
            _cboPartLocation.Name = "cboPartLocation";
            _cboPartLocation.Size = new Size(152, 21);
            _cboPartLocation.TabIndex = 1;
            // 
            // btnPartSearch
            // 
            _btnPartSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnPartSearch.Enabled = false;
            _btnPartSearch.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnPartSearch.Location = new Point(1635, 23);
            _btnPartSearch.Name = "btnPartSearch";
            _btnPartSearch.Size = new Size(64, 22);
            _btnPartSearch.TabIndex = 3;
            _btnPartSearch.Text = "Find";
            // 
            // txtPartSearch
            // 
            _txtPartSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPartSearch.Location = new Point(168, 24);
            _txtPartSearch.Name = "txtPartSearch";
            _txtPartSearch.Size = new Size(1460, 21);
            _txtPartSearch.TabIndex = 2;
            // 
            // grpAvailableParts
            // 
            _grpAvailableParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAvailableParts.Controls.Add(_btnCreatePartRequest);
            _grpAvailableParts.Controls.Add(_Label7);
            _grpAvailableParts.Controls.Add(_txtPartBuyPrice);
            _grpAvailableParts.Controls.Add(_Label3);
            _grpAvailableParts.Controls.Add(_txtPartQuantity);
            _grpAvailableParts.Controls.Add(_dgParts);
            _grpAvailableParts.Controls.Add(_btnAddPart);
            _grpAvailableParts.Location = new Point(8, 72);
            _grpAvailableParts.Name = "grpAvailableParts";
            _grpAvailableParts.Size = new Size(1785, 297);
            _grpAvailableParts.TabIndex = 14;
            _grpAvailableParts.TabStop = false;
            _grpAvailableParts.Text = "Available Parts && Packs";
            // 
            // btnCreatePartRequest
            // 
            _btnCreatePartRequest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _btnCreatePartRequest.Location = new Point(935, 263);
            _btnCreatePartRequest.Name = "btnCreatePartRequest";
            _btnCreatePartRequest.Size = new Size(837, 24);
            _btnCreatePartRequest.TabIndex = 10;
            _btnCreatePartRequest.Text = "Part Price Request";
            // 
            // Label7
            // 
            _Label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label7.Location = new Point(8, 269);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(40, 13);
            _Label7.TabIndex = 23;
            _Label7.Text = "Qty";
            // 
            // txtPartBuyPrice
            // 
            _txtPartBuyPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtPartBuyPrice.Location = new Point(248, 265);
            _txtPartBuyPrice.Name = "txtPartBuyPrice";
            _txtPartBuyPrice.Size = new Size(112, 21);
            _txtPartBuyPrice.TabIndex = 7;
            // 
            // Label3
            // 
            _Label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label3.Location = new Point(176, 269);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(64, 13);
            _Label3.TabIndex = 14;
            _Label3.Text = "Buy Price";
            // 
            // txtPartQuantity
            // 
            _txtPartQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtPartQuantity.Location = new Point(56, 265);
            _txtPartQuantity.Name = "txtPartQuantity";
            _txtPartQuantity.Size = new Size(112, 21);
            _txtPartQuantity.TabIndex = 6;
            // 
            // btnAddPart
            // 
            _btnAddPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddPart.Location = new Point(378, 263);
            _btnAddPart.Name = "btnAddPart";
            _btnAddPart.Size = new Size(56, 24);
            _btnAddPart.TabIndex = 9;
            _btnAddPart.Text = "Add";
            // 
            // tabProducts
            // 
            _tabProducts.Controls.Add(_grpProductsAvailable);
            _tabProducts.Controls.Add(_grpProductSearch);
            _tabProducts.Location = new Point(4, 22);
            _tabProducts.Name = "tabProducts";
            _tabProducts.Size = new Size(1796, 373);
            _tabProducts.TabIndex = 1;
            _tabProducts.Text = "Products Available";
            // 
            // grpProductsAvailable
            // 
            _grpProductsAvailable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpProductsAvailable.Controls.Add(_btnCreateProductPriceRequest);
            _grpProductsAvailable.Controls.Add(_txtProductSellPrice);
            _grpProductsAvailable.Controls.Add(_Label5);
            _grpProductsAvailable.Controls.Add(_txtProductBuyPrice);
            _grpProductsAvailable.Controls.Add(_Label4);
            _grpProductsAvailable.Controls.Add(_Label1);
            _grpProductsAvailable.Controls.Add(_txtProductQuantity);
            _grpProductsAvailable.Controls.Add(_dgProduct);
            _grpProductsAvailable.Controls.Add(_btnAddProduct);
            _grpProductsAvailable.Location = new Point(8, 72);
            _grpProductsAvailable.Name = "grpProductsAvailable";
            _grpProductsAvailable.Size = new Size(1785, 298);
            _grpProductsAvailable.TabIndex = 10;
            _grpProductsAvailable.TabStop = false;
            _grpProductsAvailable.Text = "Available Products ";
            // 
            // btnCreateProductPriceRequest
            // 
            _btnCreateProductPriceRequest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _btnCreateProductPriceRequest.Location = new Point(616, 263);
            _btnCreateProductPriceRequest.Name = "btnCreateProductPriceRequest";
            _btnCreateProductPriceRequest.Size = new Size(1161, 24);
            _btnCreateProductPriceRequest.TabIndex = 10;
            _btnCreateProductPriceRequest.Text = "Product Price Request";
            // 
            // txtProductSellPrice
            // 
            _txtProductSellPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtProductSellPrice.Location = new Point(432, 265);
            _txtProductSellPrice.Name = "txtProductSellPrice";
            _txtProductSellPrice.Size = new Size(112, 21);
            _txtProductSellPrice.TabIndex = 8;
            // 
            // Label5
            // 
            _Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label5.Location = new Point(368, 269);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(64, 13);
            _Label5.TabIndex = 18;
            _Label5.Text = "Sell Price";
            // 
            // txtProductBuyPrice
            // 
            _txtProductBuyPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtProductBuyPrice.Location = new Point(232, 265);
            _txtProductBuyPrice.Name = "txtProductBuyPrice";
            _txtProductBuyPrice.Size = new Size(112, 21);
            _txtProductBuyPrice.TabIndex = 7;
            // 
            // Label4
            // 
            _Label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label4.Location = new Point(168, 269);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(64, 13);
            _Label4.TabIndex = 16;
            _Label4.Text = "Buy Price";
            // 
            // Label1
            // 
            _Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label1.Location = new Point(8, 269);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(40, 13);
            _Label1.TabIndex = 15;
            _Label1.Text = "Qty";
            // 
            // txtProductQuantity
            // 
            _txtProductQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtProductQuantity.Location = new Point(48, 265);
            _txtProductQuantity.Name = "txtProductQuantity";
            _txtProductQuantity.Size = new Size(112, 21);
            _txtProductQuantity.TabIndex = 6;
            // 
            // dgProduct
            // 
            _dgProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgProduct.DataMember = "";
            _dgProduct.HeaderForeColor = SystemColors.ControlText;
            _dgProduct.Location = new Point(8, 20);
            _dgProduct.Name = "dgProduct";
            _dgProduct.Size = new Size(1769, 235);
            _dgProduct.TabIndex = 5;
            // 
            // btnAddProduct
            // 
            _btnAddProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddProduct.Location = new Point(552, 263);
            _btnAddProduct.Name = "btnAddProduct";
            _btnAddProduct.Size = new Size(56, 24);
            _btnAddProduct.TabIndex = 9;
            _btnAddProduct.Text = "Add ";
            // 
            // grpProductSearch
            // 
            _grpProductSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpProductSearch.Controls.Add(_btnAddNewProduct);
            _grpProductSearch.Controls.Add(_cboProductLocation);
            _grpProductSearch.Controls.Add(_btnProductSearch);
            _grpProductSearch.Controls.Add(_txtProductSearch);
            _grpProductSearch.Location = new Point(8, 8);
            _grpProductSearch.Name = "grpProductSearch";
            _grpProductSearch.Size = new Size(1785, 56);
            _grpProductSearch.TabIndex = 9;
            _grpProductSearch.TabStop = false;
            _grpProductSearch.Text = "Product Search From";
            // 
            // btnAddNewProduct
            // 
            _btnAddNewProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddNewProduct.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnAddNewProduct.Location = new Point(1680, 24);
            _btnAddNewProduct.Name = "btnAddNewProduct";
            _btnAddNewProduct.Size = new Size(88, 22);
            _btnAddNewProduct.TabIndex = 4;
            _btnAddNewProduct.Text = "New Product";
            // 
            // cboProductLocation
            // 
            _cboProductLocation.Location = new Point(8, 24);
            _cboProductLocation.Name = "cboProductLocation";
            _cboProductLocation.Size = new Size(152, 21);
            _cboProductLocation.TabIndex = 1;
            // 
            // btnProductSearch
            // 
            _btnProductSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnProductSearch.Enabled = false;
            _btnProductSearch.Location = new Point(1618, 24);
            _btnProductSearch.Name = "btnProductSearch";
            _btnProductSearch.Size = new Size(56, 22);
            _btnProductSearch.TabIndex = 3;
            _btnProductSearch.Text = "Find";
            // 
            // txtProductSearch
            // 
            _txtProductSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtProductSearch.Location = new Point(168, 24);
            _txtProductSearch.Name = "txtProductSearch";
            _txtProductSearch.Size = new Size(1444, 21);
            _txtProductSearch.TabIndex = 2;
            // 
            // tabItemsIncluded
            // 
            _tabItemsIncluded.Controls.Add(_GroupBox3);
            _tabItemsIncluded.Location = new Point(4, 22);
            _tabItemsIncluded.Name = "tabItemsIncluded";
            _tabItemsIncluded.Size = new Size(1796, 373);
            _tabItemsIncluded.TabIndex = 8;
            _tabItemsIncluded.Text = "Items Included";
            // 
            // GroupBox3
            // 
            _GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox3.Controls.Add(_nudItemQty);
            _GroupBox3.Controls.Add(_btnEngineerReceived);
            _GroupBox3.Controls.Add(_btnReceiveAll);
            _GroupBox3.Controls.Add(_lblItemQty);
            _GroupBox3.Controls.Add(_btnItemQtyUpdate);
            _GroupBox3.Controls.Add(_dgItemsIncluded);
            _GroupBox3.Location = new Point(8, 8);
            _GroupBox3.Name = "GroupBox3";
            _GroupBox3.Size = new Size(1785, 361);
            _GroupBox3.TabIndex = 0;
            _GroupBox3.TabStop = false;
            _GroupBox3.Text = "Double click to mark as received";
            // 
            // nudItemQty
            // 
            _nudItemQty.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _nudItemQty.Location = new Point(70, 327);
            _nudItemQty.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            _nudItemQty.Name = "nudItemQty";
            _nudItemQty.Size = new Size(64, 21);
            _nudItemQty.TabIndex = 30;
            _nudItemQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnEngineerReceived
            // 
            _btnEngineerReceived.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnEngineerReceived.Location = new Point(1536, 328);
            _btnEngineerReceived.Name = "btnEngineerReceived";
            _btnEngineerReceived.Size = new Size(134, 23);
            _btnEngineerReceived.TabIndex = 12;
            _btnEngineerReceived.Text = "Engineer Received";
            _btnEngineerReceived.UseVisualStyleBackColor = true;
            // 
            // btnReceiveAll
            // 
            _btnReceiveAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnReceiveAll.Location = new Point(1676, 328);
            _btnReceiveAll.Name = "btnReceiveAll";
            _btnReceiveAll.Size = new Size(101, 23);
            _btnReceiveAll.TabIndex = 11;
            _btnReceiveAll.Text = "Receive All";
            _btnReceiveAll.UseVisualStyleBackColor = true;
            // 
            // lblItemQty
            // 
            _lblItemQty.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblItemQty.Location = new Point(8, 329);
            _lblItemQty.Name = "lblItemQty";
            _lblItemQty.Size = new Size(56, 21);
            _lblItemQty.TabIndex = 10;
            _lblItemQty.Text = "Quantity";
            // 
            // btnItemQtyUpdate
            // 
            _btnItemQtyUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnItemQtyUpdate.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnItemQtyUpdate.Location = new Point(149, 325);
            _btnItemQtyUpdate.Name = "btnItemQtyUpdate";
            _btnItemQtyUpdate.Size = new Size(64, 23);
            _btnItemQtyUpdate.TabIndex = 3;
            _btnItemQtyUpdate.Text = "Update";
            // 
            // dgItemsIncluded
            // 
            _dgItemsIncluded.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgItemsIncluded.DataMember = "";
            _dgItemsIncluded.HeaderForeColor = SystemColors.ControlText;
            _dgItemsIncluded.Location = new Point(8, 20);
            _dgItemsIncluded.Name = "dgItemsIncluded";
            _dgItemsIncluded.Size = new Size(1769, 302);
            _dgItemsIncluded.TabIndex = 1;
            // 
            // tabPartPriceReq
            // 
            _tabPartPriceReq.Controls.Add(_GroupBox2);
            _tabPartPriceReq.Location = new Point(4, 22);
            _tabPartPriceReq.Name = "tabPartPriceReq";
            _tabPartPriceReq.Size = new Size(1796, 373);
            _tabPartPriceReq.TabIndex = 7;
            _tabPartPriceReq.Text = "Price Requests";
            // 
            // GroupBox2
            // 
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox2.Controls.Add(_btnUpdatePartPriceRequest);
            _GroupBox2.Controls.Add(_dgPriceRequests);
            _GroupBox2.Location = new Point(8, 8);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(1785, 361);
            _GroupBox2.TabIndex = 1;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Price requests for parts and products";
            // 
            // btnUpdatePartPriceRequest
            // 
            _btnUpdatePartPriceRequest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnUpdatePartPriceRequest.Location = new Point(8, 329);
            _btnUpdatePartPriceRequest.Name = "btnUpdatePartPriceRequest";
            _btnUpdatePartPriceRequest.Size = new Size(75, 24);
            _btnUpdatePartPriceRequest.TabIndex = 2;
            _btnUpdatePartPriceRequest.Text = "Update";
            // 
            // dgPriceRequests
            // 
            _dgPriceRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgPriceRequests.DataMember = "";
            _dgPriceRequests.HeaderForeColor = SystemColors.ControlText;
            _dgPriceRequests.Location = new Point(8, 32);
            _dgPriceRequests.Name = "dgPriceRequests";
            _dgPriceRequests.Size = new Size(1769, 287);
            _dgPriceRequests.TabIndex = 1;
            // 
            // tabDocuments
            // 
            _tabDocuments.Controls.Add(_pnlDocuments);
            _tabDocuments.Controls.Add(_btnEmail);
            _tabDocuments.Controls.Add(_cboPrintType);
            _tabDocuments.Controls.Add(_btnPrint);
            _tabDocuments.Controls.Add(_Label8);
            _tabDocuments.Location = new Point(4, 22);
            _tabDocuments.Name = "tabDocuments";
            _tabDocuments.Size = new Size(1796, 373);
            _tabDocuments.TabIndex = 9;
            _tabDocuments.Text = "Documents";
            // 
            // pnlDocuments
            // 
            _pnlDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _pnlDocuments.Location = new Point(8, 40);
            _pnlDocuments.Name = "pnlDocuments";
            _pnlDocuments.Size = new Size(1785, 324);
            _pnlDocuments.TabIndex = 4;
            // 
            // btnEmail
            // 
            _btnEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnEmail.Location = new Point(1329, 8);
            _btnEmail.Name = "btnEmail";
            _btnEmail.Size = new Size(104, 23);
            _btnEmail.TabIndex = 3;
            _btnEmail.Text = "Send Via Email";
            _btnEmail.Visible = false;
            // 
            // cboPrintType
            // 
            _cboPrintType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboPrintType.Location = new Point(8, 8);
            _cboPrintType.Name = "cboPrintType";
            _cboPrintType.Size = new Size(1225, 21);
            _cboPrintType.TabIndex = 1;
            // 
            // btnPrint
            // 
            _btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnPrint.Location = new Point(1241, 8);
            _btnPrint.Name = "btnPrint";
            _btnPrint.Size = new Size(56, 23);
            _btnPrint.TabIndex = 2;
            _btnPrint.Text = "Print";
            // 
            // Label8
            // 
            _Label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label8.Location = new Point(1305, 12);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(18, 16);
            _Label8.TabIndex = 45;
            _Label8.Text = "or";
            _Label8.Visible = false;
            // 
            // tabInvoices
            // 
            _tabInvoices.Controls.Add(_grpReceivedInvoices);
            _tabInvoices.Location = new Point(4, 22);
            _tabInvoices.Name = "tabInvoices";
            _tabInvoices.Size = new Size(1796, 373);
            _tabInvoices.TabIndex = 10;
            _tabInvoices.Text = "Supplier Invoices";
            // 
            // grpReceivedInvoices
            // 
            _grpReceivedInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpReceivedInvoices.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _grpReceivedInvoices.Controls.Add(_btnDeleteSupplierInvoice);
            _grpReceivedInvoices.Controls.Add(_btnUpdateSupplierInvoice);
            _grpReceivedInvoices.Controls.Add(_txtTotalAmount);
            _grpReceivedInvoices.Controls.Add(_lblTotalValue);
            _grpReceivedInvoices.Controls.Add(_txtVATAmount);
            _grpReceivedInvoices.Controls.Add(_txtNominalCodeNew);
            _grpReceivedInvoices.Controls.Add(_Label16);
            _grpReceivedInvoices.Controls.Add(_lblVatValue);
            _grpReceivedInvoices.Controls.Add(_txtGoodsAmount);
            _grpReceivedInvoices.Controls.Add(_cboInvoiceTaxCodeNew);
            _grpReceivedInvoices.Controls.Add(_txtExtraReferenceNew);
            _grpReceivedInvoices.Controls.Add(_Label13);
            _grpReceivedInvoices.Controls.Add(_lblGoodsValue);
            _grpReceivedInvoices.Controls.Add(_Label15);
            _grpReceivedInvoices.Controls.Add(_lblInvoiceDate);
            _grpReceivedInvoices.Controls.Add(_txtSupplierInvoiceRefNew);
            _grpReceivedInvoices.Controls.Add(_lblSupplierRef);
            _grpReceivedInvoices.Controls.Add(_btnAddSupplierInvoice);
            _grpReceivedInvoices.Controls.Add(_dgvReceivedInvoices);
            _grpReceivedInvoices.Controls.Add(_dtpSupplierInvoiceDateNew);
            _grpReceivedInvoices.Controls.Add(_cboReadySageNew);
            _grpReceivedInvoices.Location = new Point(4, 4);
            _grpReceivedInvoices.Name = "grpReceivedInvoices";
            _grpReceivedInvoices.Size = new Size(1789, 366);
            _grpReceivedInvoices.TabIndex = 0;
            _grpReceivedInvoices.TabStop = false;
            _grpReceivedInvoices.Text = "Received Invoices";
            // 
            // btnDeleteSupplierInvoice
            // 
            _btnDeleteSupplierInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeleteSupplierInvoice.Location = new Point(1603, 339);
            _btnDeleteSupplierInvoice.Name = "btnDeleteSupplierInvoice";
            _btnDeleteSupplierInvoice.Size = new Size(56, 24);
            _btnDeleteSupplierInvoice.TabIndex = 121;
            _btnDeleteSupplierInvoice.Text = "Delete";
            _btnDeleteSupplierInvoice.Visible = false;
            // 
            // btnUpdateSupplierInvoice
            // 
            _btnUpdateSupplierInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnUpdateSupplierInvoice.Location = new Point(1665, 339);
            _btnUpdateSupplierInvoice.Name = "btnUpdateSupplierInvoice";
            _btnUpdateSupplierInvoice.Size = new Size(56, 24);
            _btnUpdateSupplierInvoice.TabIndex = 122;
            _btnUpdateSupplierInvoice.Text = "Update";
            _btnUpdateSupplierInvoice.Visible = false;
            // 
            // txtTotalAmount
            // 
            _txtTotalAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtTotalAmount.Location = new Point(547, 340);
            _txtTotalAmount.Name = "txtTotalAmount";
            _txtTotalAmount.Size = new Size(100, 21);
            _txtTotalAmount.TabIndex = 109;
            // 
            // lblTotalValue
            // 
            _lblTotalValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblTotalValue.AutoSize = true;
            _lblTotalValue.Location = new Point(485, 343);
            _lblTotalValue.Name = "lblTotalValue";
            _lblTotalValue.Size = new Size(55, 13);
            _lblTotalValue.TabIndex = 28;
            _lblTotalValue.Text = "Total (£)";
            // 
            // txtVATAmount
            // 
            _txtVATAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtVATAmount.Location = new Point(379, 340);
            _txtVATAmount.Name = "txtVATAmount";
            _txtVATAmount.Size = new Size(100, 21);
            _txtVATAmount.TabIndex = 108;
            // 
            // txtNominalCodeNew
            // 
            _txtNominalCodeNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtNominalCodeNew.Location = new Point(633, 311);
            _txtNominalCodeNew.MaxLength = 100;
            _txtNominalCodeNew.Name = "txtNominalCodeNew";
            _txtNominalCodeNew.Size = new Size(70, 21);
            _txtNominalCodeNew.TabIndex = 105;
            _txtNominalCodeNew.Tag = "Order.SupplierInvoiceReference";
            // 
            // Label16
            // 
            _Label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label16.Location = new Point(568, 314);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(70, 20);
            _Label16.TabIndex = 65;
            _Label16.Text = "Nominal";
            // 
            // lblVatValue
            // 
            _lblVatValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblVatValue.AutoSize = true;
            _lblVatValue.Location = new Point(322, 343);
            _lblVatValue.Name = "lblVatValue";
            _lblVatValue.Size = new Size(50, 13);
            _lblVatValue.TabIndex = 26;
            _lblVatValue.Text = "VAT (£)";
            // 
            // txtGoodsAmount
            // 
            _txtGoodsAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtGoodsAmount.Location = new Point(76, 340);
            _txtGoodsAmount.Name = "txtGoodsAmount";
            _txtGoodsAmount.Size = new Size(100, 21);
            _txtGoodsAmount.TabIndex = 106;
            // 
            // cboInvoiceTaxCodeNew
            // 
            _cboInvoiceTaxCodeNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _cboInvoiceTaxCodeNew.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInvoiceTaxCodeNew.Location = new Point(258, 340);
            _cboInvoiceTaxCodeNew.Name = "cboInvoiceTaxCodeNew";
            _cboInvoiceTaxCodeNew.Size = new Size(58, 21);
            _cboInvoiceTaxCodeNew.TabIndex = 107;
            // 
            // txtExtraReferenceNew
            // 
            _txtExtraReferenceNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtExtraReferenceNew.Location = new Point(493, 311);
            _txtExtraReferenceNew.MaxLength = 100;
            _txtExtraReferenceNew.Name = "txtExtraReferenceNew";
            _txtExtraReferenceNew.Size = new Size(70, 21);
            _txtExtraReferenceNew.TabIndex = 104;
            _txtExtraReferenceNew.Tag = "Order.SupplierInvoiceReference";
            // 
            // Label13
            // 
            _Label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label13.Location = new Point(182, 343);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(70, 20);
            _Label13.TabIndex = 59;
            _Label13.Text = "Tax Code";
            // 
            // lblGoodsValue
            // 
            _lblGoodsValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblGoodsValue.AutoSize = true;
            _lblGoodsValue.Location = new Point(6, 343);
            _lblGoodsValue.Name = "lblGoodsValue";
            _lblGoodsValue.Size = new Size(64, 13);
            _lblGoodsValue.TabIndex = 24;
            _lblGoodsValue.Text = "Goods (£)";
            // 
            // Label15
            // 
            _Label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label15.Location = new Point(435, 314);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(56, 20);
            _Label15.TabIndex = 63;
            _Label15.Text = "Ex Ref.";
            // 
            // lblInvoiceDate
            // 
            _lblInvoiceDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblInvoiceDate.AutoSize = true;
            _lblInvoiceDate.Location = new Point(6, 314);
            _lblInvoiceDate.Name = "lblInvoiceDate";
            _lblInvoiceDate.Size = new Size(80, 13);
            _lblInvoiceDate.TabIndex = 1;
            _lblInvoiceDate.Text = "Invoice Date";
            // 
            // txtSupplierInvoiceRefNew
            // 
            _txtSupplierInvoiceRefNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtSupplierInvoiceRefNew.Location = new Point(329, 311);
            _txtSupplierInvoiceRefNew.Name = "txtSupplierInvoiceRefNew";
            _txtSupplierInvoiceRefNew.Size = new Size(100, 21);
            _txtSupplierInvoiceRefNew.TabIndex = 103;
            // 
            // lblSupplierRef
            // 
            _lblSupplierRef.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblSupplierRef.AutoSize = true;
            _lblSupplierRef.Location = new Point(242, 314);
            _lblSupplierRef.Name = "lblSupplierRef";
            _lblSupplierRef.Size = new Size(75, 13);
            _lblSupplierRef.TabIndex = 1;
            _lblSupplierRef.Text = "Invoice Ref.";
            // 
            // btnAddSupplierInvoice
            // 
            _btnAddSupplierInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddSupplierInvoice.Location = new Point(1727, 339);
            _btnAddSupplierInvoice.Name = "btnAddSupplierInvoice";
            _btnAddSupplierInvoice.Size = new Size(56, 24);
            _btnAddSupplierInvoice.TabIndex = 123;
            _btnAddSupplierInvoice.Text = "Add ";
            // 
            // dgvReceivedInvoices
            // 
            _dgvReceivedInvoices.AllowUserToAddRows = false;
            DataGridViewCellStyle1.BackColor = Color.White;
            DataGridViewCellStyle1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle1.ForeColor = Color.Navy;
            DataGridViewCellStyle1.SelectionBackColor = Color.Gainsboro;
            DataGridViewCellStyle1.SelectionForeColor = Color.Navy;
            DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            _dgvReceivedInvoices.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;
            _dgvReceivedInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgvReceivedInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvReceivedInvoices.BackgroundColor = Color.White;
            _dgvReceivedInvoices.BorderStyle = BorderStyle.None;
            DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle2.BackColor = Color.SteelBlue;
            DataGridViewCellStyle2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle2.ForeColor = Color.White;
            DataGridViewCellStyle2.SelectionBackColor = Color.SteelBlue;
            DataGridViewCellStyle2.SelectionForeColor = Color.White;
            DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            _dgvReceivedInvoices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2;
            _dgvReceivedInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvReceivedInvoices.EnableHeadersVisualStyles = false;
            _dgvReceivedInvoices.GridColor = Color.LightSteelBlue;
            _dgvReceivedInvoices.Location = new Point(3, 17);
            _dgvReceivedInvoices.MultiSelect = false;
            _dgvReceivedInvoices.Name = "dgvReceivedInvoices";
            _dgvReceivedInvoices.RowHeadersVisible = false;
            DataGridViewCellStyle3.BackColor = Color.White;
            DataGridViewCellStyle3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle3.ForeColor = Color.Navy;
            DataGridViewCellStyle3.SelectionBackColor = Color.Gainsboro;
            DataGridViewCellStyle3.SelectionForeColor = Color.Navy;
            DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            _dgvReceivedInvoices.RowsDefaultCellStyle = DataGridViewCellStyle3;
            _dgvReceivedInvoices.RowTemplate.Height = 29;
            _dgvReceivedInvoices.RowTemplate.ReadOnly = true;
            _dgvReceivedInvoices.RowTemplate.Resizable = DataGridViewTriState.True;
            _dgvReceivedInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvReceivedInvoices.Size = new Size(1780, 288);
            _dgvReceivedInvoices.TabIndex = 0;
            // 
            // dtpSupplierInvoiceDateNew
            // 
            _dtpSupplierInvoiceDateNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _dtpSupplierInvoiceDateNew.Location = new Point(92, 311);
            _dtpSupplierInvoiceDateNew.Name = "dtpSupplierInvoiceDateNew";
            _dtpSupplierInvoiceDateNew.Size = new Size(144, 21);
            _dtpSupplierInvoiceDateNew.TabIndex = 101;
            _dtpSupplierInvoiceDateNew.Tag = "Order.SupplierInvoiceDate";
            // 
            // cboReadySageNew
            // 
            _cboReadySageNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _cboReadySageNew.Location = new Point(653, 338);
            _cboReadySageNew.Name = "cboReadySageNew";
            _cboReadySageNew.RightToLeft = RightToLeft.Yes;
            _cboReadySageNew.Size = new Size(247, 24);
            _cboReadySageNew.TabIndex = 110;
            _cboReadySageNew.Text = "Ready to send to Accounts Package";
            // 
            // TabPage1
            // 
            _TabPage1.Controls.Add(_GroupBox4);
            _TabPage1.Location = new Point(4, 22);
            _TabPage1.Name = "TabPage1";
            _TabPage1.Size = new Size(1796, 373);
            _TabPage1.TabIndex = 11;
            _TabPage1.Text = "Credits";
            _TabPage1.UseVisualStyleBackColor = true;
            // 
            // GroupBox4
            // 
            _GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _GroupBox4.Controls.Add(_Button1);
            _GroupBox4.Controls.Add(_CheckBox1);
            _GroupBox4.Controls.Add(_txtCreditExRef);
            _GroupBox4.Controls.Add(_Label21);
            _GroupBox4.Controls.Add(_btnCreditDelete);
            _GroupBox4.Controls.Add(_txtCreditTotal);
            _GroupBox4.Controls.Add(_Label9);
            _GroupBox4.Controls.Add(_txtCreditVAT);
            _GroupBox4.Controls.Add(_txtCreditNominal);
            _GroupBox4.Controls.Add(_Label10);
            _GroupBox4.Controls.Add(_Label14);
            _GroupBox4.Controls.Add(_txtCreditGoods);
            _GroupBox4.Controls.Add(_cboCreditTax);
            _GroupBox4.Controls.Add(_Label18);
            _GroupBox4.Controls.Add(_Label20);
            _GroupBox4.Controls.Add(_txtCreditRef);
            _GroupBox4.Controls.Add(_Label23);
            _GroupBox4.Controls.Add(_btnCreditAdd);
            _GroupBox4.Controls.Add(_dgCredits);
            _GroupBox4.Controls.Add(_dtpCreditDate);
            _GroupBox4.Location = new Point(3, 4);
            _GroupBox4.Name = "GroupBox4";
            _GroupBox4.Size = new Size(1789, 366);
            _GroupBox4.TabIndex = 1;
            _GroupBox4.TabStop = false;
            _GroupBox4.Text = "Part Credits";
            // 
            // Button1
            // 
            _Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Button1.Location = new Point(1495, 339);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(142, 24);
            _Button1.TabIndex = 127;
            _Button1.Text = "Convert to Van stock";
            // 
            // CheckBox1
            // 
            _CheckBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _CheckBox1.Location = new Point(-20, 312);
            _CheckBox1.Name = "CheckBox1";
            _CheckBox1.RightToLeft = RightToLeft.Yes;
            _CheckBox1.Size = new Size(141, 24);
            _CheckBox1.TabIndex = 126;
            _CheckBox1.Text = "Credit Recieved";
            // 
            // txtCreditExRef
            // 
            _txtCreditExRef.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtCreditExRef.Location = new Point(1118, 339);
            _txtCreditExRef.MaxLength = 100;
            _txtCreditExRef.Name = "txtCreditExRef";
            _txtCreditExRef.Size = new Size(70, 21);
            _txtCreditExRef.TabIndex = 125;
            _txtCreditExRef.Tag = "Order.SupplierInvoiceReference";
            // 
            // Label21
            // 
            _Label21.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label21.Location = new Point(1073, 342);
            _Label21.Name = "Label21";
            _Label21.Size = new Size(56, 20);
            _Label21.TabIndex = 124;
            _Label21.Text = "Ex Ref.";
            // 
            // btnCreditDelete
            // 
            _btnCreditDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnCreditDelete.Location = new Point(1656, 339);
            _btnCreditDelete.Name = "btnCreditDelete";
            _btnCreditDelete.Size = new Size(56, 24);
            _btnCreditDelete.TabIndex = 121;
            _btnCreditDelete.Text = "Delete";
            _btnCreditDelete.Visible = false;
            // 
            // txtCreditTotal
            // 
            _txtCreditTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtCreditTotal.Location = new Point(539, 342);
            _txtCreditTotal.Name = "txtCreditTotal";
            _txtCreditTotal.Size = new Size(68, 21);
            _txtCreditTotal.TabIndex = 109;
            // 
            // Label9
            // 
            _Label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label9.AutoSize = true;
            _Label9.Location = new Point(467, 345);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(55, 13);
            _Label9.TabIndex = 28;
            _Label9.Text = "Total (£)";
            // 
            // txtCreditVAT
            // 
            _txtCreditVAT.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtCreditVAT.Location = new Point(372, 341);
            _txtCreditVAT.Name = "txtCreditVAT";
            _txtCreditVAT.Size = new Size(68, 21);
            _txtCreditVAT.TabIndex = 108;
            // 
            // txtCreditNominal
            // 
            _txtCreditNominal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtCreditNominal.Location = new Point(1000, 339);
            _txtCreditNominal.MaxLength = 100;
            _txtCreditNominal.Name = "txtCreditNominal";
            _txtCreditNominal.Size = new Size(70, 21);
            _txtCreditNominal.TabIndex = 105;
            _txtCreditNominal.Tag = "Order.SupplierInvoiceReference";
            // 
            // Label10
            // 
            _Label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label10.Location = new Point(947, 342);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(70, 20);
            _Label10.TabIndex = 65;
            _Label10.Text = "Nominal";
            // 
            // Label14
            // 
            _Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label14.AutoSize = true;
            _Label14.Location = new Point(309, 344);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(50, 13);
            _Label14.TabIndex = 26;
            _Label14.Text = "VAT (£)";
            // 
            // txtCreditGoods
            // 
            _txtCreditGoods.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtCreditGoods.Location = new Point(95, 340);
            _txtCreditGoods.Name = "txtCreditGoods";
            _txtCreditGoods.Size = new Size(54, 21);
            _txtCreditGoods.TabIndex = 106;
            // 
            // cboCreditTax
            // 
            _cboCreditTax.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _cboCreditTax.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCreditTax.Location = new Point(238, 340);
            _cboCreditTax.Name = "cboCreditTax";
            _cboCreditTax.Size = new Size(46, 21);
            _cboCreditTax.TabIndex = 107;
            // 
            // Label18
            // 
            _Label18.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label18.Location = new Point(168, 342);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(70, 20);
            _Label18.TabIndex = 59;
            _Label18.Text = "Tax Code";
            // 
            // Label20
            // 
            _Label20.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label20.AutoSize = true;
            _Label20.Location = new Point(6, 343);
            _Label20.Name = "Label20";
            _Label20.Size = new Size(86, 13);
            _Label20.TabIndex = 24;
            _Label20.Text = "Credit Net (£)";
            // 
            // txtCreditRef
            // 
            _txtCreditRef.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtCreditRef.Location = new Point(871, 339);
            _txtCreditRef.Name = "txtCreditRef";
            _txtCreditRef.Size = new Size(70, 21);
            _txtCreditRef.TabIndex = 103;
            // 
            // Label23
            // 
            _Label23.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label23.AutoSize = true;
            _Label23.Location = new Point(801, 344);
            _Label23.Name = "Label23";
            _Label23.Size = new Size(68, 13);
            _Label23.TabIndex = 1;
            _Label23.Text = "Credit Ref.";
            // 
            // btnCreditAdd
            // 
            _btnCreditAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnCreditAdd.Location = new Point(1727, 339);
            _btnCreditAdd.Name = "btnCreditAdd";
            _btnCreditAdd.Size = new Size(56, 24);
            _btnCreditAdd.TabIndex = 123;
            _btnCreditAdd.Text = "Add ";
            // 
            // dgCredits
            // 
            _dgCredits.AllowUserToAddRows = false;
            DataGridViewCellStyle4.BackColor = Color.White;
            DataGridViewCellStyle4.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle4.ForeColor = Color.Navy;
            DataGridViewCellStyle4.SelectionBackColor = Color.Gainsboro;
            DataGridViewCellStyle4.SelectionForeColor = Color.Navy;
            DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            _dgCredits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4;
            _dgCredits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgCredits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgCredits.BackgroundColor = Color.White;
            _dgCredits.BorderStyle = BorderStyle.None;
            DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle5.BackColor = Color.SteelBlue;
            DataGridViewCellStyle5.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle5.ForeColor = Color.White;
            DataGridViewCellStyle5.SelectionBackColor = Color.SteelBlue;
            DataGridViewCellStyle5.SelectionForeColor = Color.White;
            DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            _dgCredits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5;
            _dgCredits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgCredits.EnableHeadersVisualStyles = false;
            _dgCredits.GridColor = Color.LightSteelBlue;
            _dgCredits.Location = new Point(3, 23);
            _dgCredits.MultiSelect = false;
            _dgCredits.Name = "dgCredits";
            _dgCredits.RowHeadersVisible = false;
            DataGridViewCellStyle6.BackColor = Color.White;
            DataGridViewCellStyle6.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle6.ForeColor = Color.Navy;
            DataGridViewCellStyle6.SelectionBackColor = Color.Gainsboro;
            DataGridViewCellStyle6.SelectionForeColor = Color.Navy;
            DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            _dgCredits.RowsDefaultCellStyle = DataGridViewCellStyle6;
            _dgCredits.RowTemplate.Height = 29;
            _dgCredits.RowTemplate.ReadOnly = true;
            _dgCredits.RowTemplate.Resizable = DataGridViewTriState.True;
            _dgCredits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgCredits.Size = new Size(1780, 288);
            _dgCredits.TabIndex = 0;
            // 
            // dtpCreditDate
            // 
            _dtpCreditDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _dtpCreditDate.Location = new Point(128, 313);
            _dtpCreditDate.Name = "dtpCreditDate";
            _dtpCreditDate.Size = new Size(142, 21);
            _dtpCreditDate.TabIndex = 101;
            _dtpCreditDate.Tag = "Order.SupplierInvoiceDate";
            // 
            // lblOrderStatus
            // 
            _lblOrderStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _lblOrderStatus.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            _lblOrderStatus.Font = new Font("Verdana", 10.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblOrderStatus.Location = new Point(16, 129);
            _lblOrderStatus.Name = "lblOrderStatus";
            _lblOrderStatus.Size = new Size(1645, 24);
            _lblOrderStatus.TabIndex = 0;
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_lblCredits);
            _GroupBox1.Controls.Add(_Label25);
            _GroupBox1.Controls.Add(_lblSupplierGoods);
            _GroupBox1.Controls.Add(_lblGoodsTotal);
            _GroupBox1.Location = new Point(1547, 36);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(275, 63);
            _GroupBox1.TabIndex = 76;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Supplier Invoice Totals";
            // 
            // lblCredits
            // 
            _lblCredits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblCredits.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblCredits.Location = new Point(138, 37);
            _lblCredits.Name = "lblCredits";
            _lblCredits.Size = new Size(122, 15);
            _lblCredits.TabIndex = 80;
            _lblCredits.Text = "£0.00";
            _lblCredits.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Label25
            // 
            _Label25.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label25.AutoSize = true;
            _Label25.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label25.Location = new Point(14, 40);
            _Label25.Name = "Label25";
            _Label25.Size = new Size(123, 13);
            _Label25.TabIndex = 81;
            _Label25.Text = "Supplier Credits : ";
            _Label25.TextAlign = ContentAlignment.TopRight;
            // 
            // lblSupplierGoods
            // 
            _lblSupplierGoods.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblSupplierGoods.AutoSize = true;
            _lblSupplierGoods.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblSupplierGoods.Location = new Point(14, 19);
            _lblSupplierGoods.Name = "lblSupplierGoods";
            _lblSupplierGoods.Size = new Size(133, 13);
            _lblSupplierGoods.TabIndex = 73;
            _lblSupplierGoods.Text = "Supplier Invoices : ";
            _lblSupplierGoods.TextAlign = ContentAlignment.TopRight;
            // 
            // lblGoodsTotal
            // 
            _lblGoodsTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblGoodsTotal.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblGoodsTotal.Location = new Point(138, 17);
            _lblGoodsTotal.Name = "lblGoodsTotal";
            _lblGoodsTotal.Size = new Size(122, 15);
            _lblGoodsTotal.TabIndex = 70;
            _lblGoodsTotal.Text = "£0.00";
            _lblGoodsTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Label17
            // 
            _Label17.Location = new Point(6, 97);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(79, 20);
            _Label17.TabIndex = 68;
            _Label17.Text = "Cost Centre";
            // 
            // FSMDataSetBindingSource
            // 
            _FSMDataSetBindingSource.DataSource = _FSMDataSet;
            _FSMDataSetBindingSource.Position = 0;
            // 
            // FSMDataSet
            // 
            _FSMDataSet.DataSetName = "FSMDataSet";
            _FSMDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // dgParts
            // 
            _dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgParts.DataMember = "";
            _dgParts.HeaderForeColor = SystemColors.ControlText;
            _dgParts.Location = new Point(8, 20);
            _dgParts.Name = "dgParts";
            _dgParts.Size = new Size(1769, 237);
            _dgParts.TabIndex = 5;
            // 
            // UCOrder
            // 
            Controls.Add(_grpOrder);
            Name = "UCOrder";
            Size = new Size(1835, 571);
            _grpOrder.ResumeLayout(false);
            _grpOrder.PerformLayout();
            _tcOrderDetails.ResumeLayout(false);
            _tabDetails.ResumeLayout(false);
            _tabParts.ResumeLayout(false);
            _grpPartSearch.ResumeLayout(false);
            _grpPartSearch.PerformLayout();
            _grpAvailableParts.ResumeLayout(false);
            _grpAvailableParts.PerformLayout();
            _tabProducts.ResumeLayout(false);
            _grpProductsAvailable.ResumeLayout(false);
            _grpProductsAvailable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgProduct).EndInit();
            _grpProductSearch.ResumeLayout(false);
            _grpProductSearch.PerformLayout();
            _tabItemsIncluded.ResumeLayout(false);
            _GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_nudItemQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgItemsIncluded).EndInit();
            _tabPartPriceReq.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgPriceRequests).EndInit();
            _tabDocuments.ResumeLayout(false);
            _tabInvoices.ResumeLayout(false);
            _grpReceivedInvoices.ResumeLayout(false);
            _grpReceivedInvoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvReceivedInvoices).EndInit();
            _TabPage1.ResumeLayout(false);
            _GroupBox4.ResumeLayout(false);
            _GroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCredits).EndInit();
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_FSMDataSetBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)_FSMDataSet).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgParts).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupProductsDatagrid();
            SetupPartsDatagrid();
            SetupPriceRequestDatagrid();
            SetupSupplierInvoices();
            SetupCredits();
            if (CurrentOrder is object)
            {
                if (CurrentOrder.OrderStatusID == (int)Enums.OrderStatus.AwaitingConfirmation | CurrentOrder.OrderStatusID == 0)
                {
                    txtOrderReference.Visible = false;
                }
                else
                {
                    txtOrderReference.Visible = true;
                }
            }
            else
            {
                txtOrderReference.Visible = false;
            }

            tcOrderDetails.TabPages.Remove(tabProducts);
            tcOrderDetails.TabPages.Remove(tabPartPriceReq);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentOrder;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public event FormCloseEventHandler FormClose;

        public delegate void FormCloseEventHandler();

        private bool IsLoading = true;
        private UCDocumentsList DocumentsControl;
        public UCOrderForCustomer ucCustomerOrder = new UCOrderForCustomer();
        public UCOrderForJob ucJobOrder = new UCOrderForJob();
        public UCOrderForWarehouse ucWarehouseOrder = new UCOrderForWarehouse();
        public UCOrderForVan ucVanOrder = new UCOrderForVan();
        private Entity.Orders.Order _currentOrder;

        public Entity.Orders.Order CurrentOrder
        {
            get
            {
                return _currentOrder;
            }

            set
            {
                _currentOrder = value;
                if (_currentOrder is null)
                {
                    _currentOrder = new Entity.Orders.Order();
                    _currentOrder.Exists = false;
                }

                if (!CurrentOrder.Exists)
                {
                    btnEngineerReceived.Visible = false;
                    OrderNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.ORDER);
                    cboOrderStatus.Enabled = false;
                    // Me.txtOrderReference.Enabled = True
                    // Me.dtpDatePlaced.Enabled = True
                    cboOrderTypeID.Enabled = true;
                    // Me.dtpDeliveryDeadline.Enabled = True
                    // Me.chkDeadlineNA.Enabled = True
                    cboPrintType.Enabled = false;
                    btnPrint.Enabled = false;
                    btnEmail.Enabled = false;
                    btnCharges.Enabled = false;
                    var argcombo = cboOrderStatus;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(Enums.OrderStatus.AwaitingConfirmation));
                    lblOrderStatus.Text = "SAVE BASE ORDER DETAILS BEFORE MANAGING ITEMS";
                    lblOrderStatus.Visible = true;
                    EnableTabs(false);
                    var argc = cboPrintType;
                    Combo.SetUpCombo(ref argc, null, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
                }

                // Me.lblGoodsValue.Text = Format(0, "C")
                // Me.lblVATTotal.Text = Format(0, "C")
                else
                {
                    cboOrderStatus.Enabled = true;
                    // Me.txtOrderReference.Enabled = False
                    // Me.dtpDatePlaced.Enabled = False
                    cboOrderTypeID.Enabled = false;
                    // Me.dtpDeliveryDeadline.Enabled = False
                    // Me.chkDeadlineNA.Enabled = False
                    cboPrintType.Enabled = true;
                    btnPrint.Enabled = true;
                    btnEmail.Enabled = true;
                    btnCharges.Enabled = true;
                    pnlDocuments.Controls.Clear();
                    DocumentsControl = new UCDocumentsList(Enums.TableNames.tblOrder, CurrentOrder.OrderID);
                    pnlDocuments.Controls.Add(DocumentsControl);
                    var argc1 = cboPrintType;
                    Combo.SetUpCombo(ref argc1, DynamicDataTables.get_SystemDocumentTypes((Enums.OrderType)CurrentOrder.OrderTypeID), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
                    Populate();
                    EnableTabs(true);
                }

                SetupItemsIncludedDatagrid();
                IsLoading = false;
            }
        }

        private bool isOrderComplete()
        {
            bool orderComplete = true;
            foreach (DataRow row in ItemsIncludedDataView.Table.Rows)
            {
                if (Conversions.ToBoolean(row["QuantityOnOrder"] > row["QuantityReceived"]))
                {
                    orderComplete = false;
                }
            }

            return orderComplete;
        }

        private bool isOrderCancelled()
        {
            RefreshDataGrids();
            if (ItemsIncludedDataView.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int _passedID;

        public int PassedID
        {
            get
            {
                return _passedID;
            }

            set
            {
                _passedID = value;
            }
        }

        private string _reason = "";

        public string Reason
        {
            get
            {
                return _reason;
            }

            set
            {
                _reason = value;
            }
        }

        private DataView _ItemsIncludedDataView = null;

        public DataView ItemsIncludedDataView
        {
            get
            {
                return _ItemsIncludedDataView;
            }

            set
            {
                _ItemsIncludedDataView = value;
                _ItemsIncludedDataView.Table.TableName = Enums.TableNames.tblOrder.ToString();
                _ItemsIncludedDataView.AllowNew = false;
                _ItemsIncludedDataView.AllowEdit = false;
                _ItemsIncludedDataView.AllowDelete = false;
                dgItemsIncluded.DataSource = ItemsIncludedDataView;
                PopulateOrderTotal();
                if (ItemsIncludedDataView.Table.Rows.Count == 0)
                {
                    SupplierUsedID = 0;
                    LocationUsedID = 0;
                }
            }
        }

        private DataRow SelectedItemIncludedDataRow
        {
            get
            {
                if (!(dgItemsIncluded.CurrentRowIndex == -1))
                {
                    return ItemsIncludedDataView[dgItemsIncluded.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _ProductsDataView = null;

        public DataView ProductsDataView
        {
            get
            {
                return _ProductsDataView;
            }

            set
            {
                _ProductsDataView = value;
                _ProductsDataView.Table.TableName = Enums.TableNames.tblProduct.ToString();
                _ProductsDataView.AllowNew = false;
                _ProductsDataView.AllowEdit = false;
                _ProductsDataView.AllowDelete = false;
                dgProduct.DataSource = ProductsDataView;
            }
        }

        private DataRow SelectedProductDataRow
        {
            get
            {
                if (!(dgProduct.CurrentRowIndex == -1))
                {
                    return ProductsDataView[dgProduct.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _PriceRequestDataView = null;

        public DataView PriceRequestDataView
        {
            get
            {
                return _PriceRequestDataView;
            }

            set
            {
                _PriceRequestDataView = value;
                _PriceRequestDataView.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
                _PriceRequestDataView.AllowNew = false;
                _PriceRequestDataView.AllowEdit = false;
                _PriceRequestDataView.AllowDelete = false;
                dgPriceRequests.DataSource = PriceRequestDataView;
                btnUpdatePartPriceRequest.Enabled = false;
            }
        }

        private DataRow SelectedPriceRequestDataRow
        {
            get
            {
                if (!(dgPriceRequests.CurrentRowIndex == -1))
                {
                    return PriceRequestDataView[dgPriceRequests.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _PartsDataView = null;

        public DataView PartsDataView
        {
            get
            {
                return _PartsDataView;
            }

            set
            {
                _PartsDataView = value;
                _PartsDataView.Table.TableName = Enums.TableNames.tblPart.ToString();
                _PartsDataView.AllowNew = false;
                _PartsDataView.AllowEdit = false;
                _PartsDataView.AllowDelete = false;
                dgParts.DataSource = PartsDataView;
            }
        }

        private DataRow SelectedPartDataRow
        {
            get
            {
                if (!(dgParts.CurrentRowIndex == -1))
                {
                    return PartsDataView[dgParts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        // This is to make sure we can only have one supplier per order
        private int _supplierUsedID;

        public int SupplierUsedID
        {
            get
            {
                return _supplierUsedID;
            }

            set
            {
                _supplierUsedID = value;
            }
        }

        private int _locationUsedID;

        public int LocationUsedID
        {
            get
            {
                return _locationUsedID;
            }

            set
            {
                _locationUsedID = value;
            }
        }

        private bool _OrderNumberUsed = false;

        public bool OrderNumberUsed
        {
            get
            {
                return _OrderNumberUsed;
            }

            set
            {
                _OrderNumberUsed = value;
            }
        }

        private JobNumber _OrderNumber = new JobNumber();

        public JobNumber OrderNumber
        {
            get
            {
                return _OrderNumber;
            }

            set
            {
                _OrderNumber = value;
                if (CurrentOrder.Exists == false)
                {
                    OrderNumberUsed = false;
                    _OrderNumber.OrderNumber = OrderNumber.Number.ToString();
                    while (OrderNumber.OrderNumber.Length < 5)
                        _OrderNumber.OrderNumber = "0" + OrderNumber.OrderNumber;
                    string typePrefix = "";
                    var switchExpr = (Enums.OrderType)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboOrderTypeID));
                    switch (switchExpr)
                    {
                        case Enums.OrderType.Customer:
                            {
                                typePrefix = "W";
                                break;
                            }

                        case Enums.OrderType.StockProfile:
                            {
                                typePrefix = "V";
                                break;
                            }

                        case Enums.OrderType.Warehouse:
                            {
                                typePrefix = "W";
                                break;
                            }

                        case Enums.OrderType.Job:
                            {
                                typePrefix = "V";
                                break;
                            }
                    }

                    string userPrefix = "";
                    var username = App.loggedInUser.Fullname.Split(' ');
                    foreach (string s in username)
                        userPrefix += s.Substring(0, 1);
                    _OrderNumber.OrderNumber = userPrefix + typePrefix + OrderNumber.OrderNumber;
                    txtOrderReference.Text = OrderNumber.OrderNumber;
                }
            }
        }

        private int _customerID;

        public int CustomerID
        {
            get
            {
                return _customerID;
            }

            set
            {
                _customerID = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public class ColourColumn : DataGridLabelColumn
        {
            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                // set the color required dependant on the column value
                Brush brush;
                brush = Brushes.White;
                if (Helper.MakeBooleanValid(source.List[rowNum].row.item("Preferred")))
                {
                    brush = Brushes.LightGreen;
                }

                TextBox.Text = "";
                // color the row cell
                var rect = bounds;
                g.FillRectangle(brush, rect);
                g.DrawString("", DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupCredits()
        {
            dgCredits.AutoGenerateColumns = false;
            var CreditInvoiceDate = new DataGridViewTextBoxColumn();
            CreditInvoiceDate.FillWeight = 75;
            CreditInvoiceDate.HeaderText = "Credit Created";
            CreditInvoiceDate.DataPropertyName = "DateCreated";
            CreditInvoiceDate.SortMode = DataGridViewColumnSortMode.Automatic;
            dgCredits.Columns.Add(CreditInvoiceDate);
            var CreditInvoiceID = new DataGridViewTextBoxColumn();
            CreditInvoiceID.FillWeight = 75;
            CreditInvoiceID.HeaderText = "Part Number";
            CreditInvoiceID.Name = "PartNumber";
            CreditInvoiceID.DataPropertyName = "PartNumber";
            CreditInvoiceID.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCredits.Columns.Add(CreditInvoiceID);
            var CreditInvoiceAmount = new DataGridViewTextBoxColumn();
            CreditInvoiceAmount.FillWeight = 150;
            CreditInvoiceAmount.HeaderText = "Part Name";
            CreditInvoiceAmount.Name = "PartName";
            CreditInvoiceAmount.DataPropertyName = "PartName";
            CreditInvoiceAmount.SortMode = DataGridViewColumnSortMode.NotSortable;
            // CreditInvoiceAmount.DefaultCellStyle.Format = "c"
            dgCredits.Columns.Add(CreditInvoiceAmount);
            var CreditGoodsAmount = new DataGridViewTextBoxColumn();
            CreditGoodsAmount.FillWeight = 30;
            CreditGoodsAmount.HeaderText = "Qty";
            CreditGoodsAmount.Name = "Qty";
            CreditGoodsAmount.DataPropertyName = "Qty";
            CreditGoodsAmount.SortMode = DataGridViewColumnSortMode.NotSortable;
            // CreditGoodsAmount.DefaultCellStyle.Format = "c"
            dgCredits.Columns.Add(CreditGoodsAmount);
            var CreditVATAmount = new DataGridViewTextBoxColumn();
            CreditVATAmount.FillWeight = 50;
            CreditVATAmount.HeaderText = "Parts Buy Price";
            CreditVATAmount.DataPropertyName = "Total";
            CreditVATAmount.SortMode = DataGridViewColumnSortMode.NotSortable;
            CreditVATAmount.DefaultCellStyle.Format = "c";
            dgCredits.Columns.Add(CreditVATAmount);
            var CreditInvoiceReference = new DataGridViewTextBoxColumn();
            CreditInvoiceReference.FillWeight = 75;
            CreditInvoiceReference.HeaderText = "Return Ref.";
            CreditInvoiceReference.DataPropertyName = "ReturnRef";
            CreditInvoiceReference.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCredits.Columns.Add(CreditInvoiceReference);
            var CreditInvoiceReference2 = new DataGridViewTextBoxColumn();
            CreditInvoiceReference2.FillWeight = 75;
            CreditInvoiceReference2.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            CreditInvoiceReference2.HeaderText = "Date Part Returned";
            CreditInvoiceReference2.Name = "DatePartReturned";
            CreditInvoiceReference2.DataPropertyName = "DatePartReturned";
            CreditInvoiceReference2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCredits.Columns.Add(CreditInvoiceReference2);
            var CreditInvoiceReference3 = new DataGridViewTextBoxColumn();
            CreditInvoiceReference3.FillWeight = 150;
            CreditInvoiceReference3.HeaderText = "Engineer Returning";
            CreditInvoiceReference3.DataPropertyName = "Engineer";
            CreditInvoiceReference3.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCredits.Columns.Add(CreditInvoiceReference3);
            var CreditInvoiceReference4 = new DataGridViewTextBoxColumn();
            CreditInvoiceReference4.FillWeight = 75;
            CreditInvoiceReference4.HeaderText = "Supplier Credit Ref";
            CreditInvoiceReference4.DataPropertyName = "SupplierCreditRef";
            CreditInvoiceReference4.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCredits.Columns.Add(CreditInvoiceReference4);
            var CreditInvoiceReference5 = new DataGridViewTextBoxColumn();
            CreditInvoiceReference5.FillWeight = 75;
            CreditInvoiceReference5.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            CreditInvoiceReference5.HeaderText = "Date Credit Recieved";
            CreditInvoiceReference5.DataPropertyName = "DateReceived";
            CreditInvoiceReference5.Name = "DateReceived";
            CreditInvoiceReference5.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCredits.Columns.Add(CreditInvoiceReference5);
            var CreditAmount = new DataGridViewTextBoxColumn();
            CreditAmount.FillWeight = 30;
            CreditAmount.HeaderText = "Credit Total";
            // CreditGoodsAmount.Name = "Qty"
            CreditAmount.DataPropertyName = "AmountReceived";
            CreditAmount.SortMode = DataGridViewColumnSortMode.NotSortable;
            CreditAmount.DefaultCellStyle.Format = "c";
            dgCredits.Columns.Add(CreditAmount);
            var CreditPartsID = new DataGridViewTextBoxColumn();
            CreditPartsID.FillWeight = 1;
            CreditPartsID.HeaderText = "";
            CreditPartsID.Visible = true;
            CreditPartsID.DataPropertyName = "PartCreditsID";
            CreditPartsID.Name = "PartCreditsID";
            CreditPartsID.SortMode = DataGridViewColumnSortMode.NotSortable;
            // CreditGoodsAmount.DefaultCellStyle.Format = "c"
            dgCredits.Columns.Add(CreditPartsID);
            var CreditPartsIDs = new DataGridViewTextBoxColumn();
            CreditPartsIDs.FillWeight = 1;
            CreditPartsIDs.HeaderText = "";
            CreditPartsIDs.Visible = true;
            CreditPartsIDs.DataPropertyName = "PartID";
            CreditPartsIDs.Name = "PartID";
            CreditPartsIDs.SortMode = DataGridViewColumnSortMode.NotSortable;
            // CreditGoodsAmount.DefaultCellStyle.Format = "c"
            dgCredits.Columns.Add(CreditPartsIDs);
            var CreditPartsIDss = new DataGridViewTextBoxColumn();
            CreditPartsIDss.FillWeight = 1;
            CreditPartsIDss.HeaderText = "";
            CreditPartsIDss.Visible = true;
            CreditPartsIDss.DataPropertyName = "OrderPartID";
            CreditPartsIDss.Name = "OrderPartID";
            CreditPartsIDss.SortMode = DataGridViewColumnSortMode.NotSortable;
            // CreditGoodsAmount.DefaultCellStyle.Format = "c"
            dgCredits.Columns.Add(CreditPartsIDss);
            var PartsToBeCreditedID = new DataGridViewTextBoxColumn();
            PartsToBeCreditedID.FillWeight = 1;
            PartsToBeCreditedID.HeaderText = "";
            PartsToBeCreditedID.Visible = true;
            PartsToBeCreditedID.DataPropertyName = "PartsToBeCreditedID";
            PartsToBeCreditedID.Name = "PartsToBeCreditedID";
            PartsToBeCreditedID.SortMode = DataGridViewColumnSortMode.NotSortable;
            // CreditGoodsAmount.DefaultCellStyle.Format = "c"
            dgCredits.Columns.Add(PartsToBeCreditedID);
            var CreditPartsIDsss = new DataGridViewTextBoxColumn();
            CreditPartsIDsss.FillWeight = 1;
            CreditPartsIDsss.HeaderText = "";
            CreditPartsIDsss.Visible = true;
            CreditPartsIDsss.DataPropertyName = "DateExportedToSage";
            CreditPartsIDsss.Name = "DateExportedToSage";
            CreditPartsIDsss.SortMode = DataGridViewColumnSortMode.NotSortable;
            // CreditGoodsAmount.DefaultCellStyle.Format = "c"
            dgCredits.Columns.Add(CreditPartsIDsss);
        }

        private void SetupSupplierInvoices()
        {
            dgvReceivedInvoices.AutoGenerateColumns = false;
            var SupplierInvoiceDate = new DataGridViewTextBoxColumn();
            SupplierInvoiceDate.FillWeight = 200;
            SupplierInvoiceDate.HeaderText = "Invoice Date";
            SupplierInvoiceDate.DataPropertyName = "SupplierInvoiceDate";
            SupplierInvoiceDate.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvReceivedInvoices.Columns.Add(SupplierInvoiceDate);
            var SupplierInvoiceReference = new DataGridViewTextBoxColumn();
            SupplierInvoiceReference.FillWeight = 200;
            SupplierInvoiceReference.HeaderText = "Supplier Invoice Ref.";
            SupplierInvoiceReference.DataPropertyName = "SupplierInvoiceReference";
            SupplierInvoiceReference.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvReceivedInvoices.Columns.Add(SupplierInvoiceReference);
            var SupplierGoodsAmount = new DataGridViewTextBoxColumn();
            SupplierGoodsAmount.FillWeight = 200;
            SupplierGoodsAmount.HeaderText = "Goods";
            SupplierGoodsAmount.Name = "SupplierInvoiceAmount";
            SupplierGoodsAmount.DataPropertyName = "SupplierInvoiceAmount";
            SupplierGoodsAmount.SortMode = DataGridViewColumnSortMode.NotSortable;
            SupplierGoodsAmount.DefaultCellStyle.Format = "c";
            dgvReceivedInvoices.Columns.Add(SupplierGoodsAmount);
            var SupplierVATAmount = new DataGridViewTextBoxColumn();
            SupplierVATAmount.FillWeight = 200;
            SupplierVATAmount.HeaderText = "VAT";
            SupplierVATAmount.DataPropertyName = "SupplierVATAmount";
            SupplierVATAmount.SortMode = DataGridViewColumnSortMode.NotSortable;
            SupplierVATAmount.DefaultCellStyle.Format = "c";
            dgvReceivedInvoices.Columns.Add(SupplierVATAmount);
            var SupplierInvoiceAmount = new DataGridViewTextBoxColumn();
            SupplierInvoiceAmount.FillWeight = 200;
            SupplierInvoiceAmount.HeaderText = "Total";
            SupplierInvoiceAmount.DataPropertyName = "SupplierGoodsAmount";
            SupplierInvoiceAmount.SortMode = DataGridViewColumnSortMode.NotSortable;
            SupplierInvoiceAmount.DefaultCellStyle.Format = "c";
            dgvReceivedInvoices.Columns.Add(SupplierInvoiceAmount);
            var SupplierInvoiceID = new DataGridViewTextBoxColumn();
            SupplierInvoiceID.FillWeight = 50;
            SupplierInvoiceID.HeaderText = "Trans ID";
            SupplierInvoiceID.Name = "SupplierInvoiceID";
            SupplierInvoiceID.DataPropertyName = "SupplierInvoiceID";
            SupplierInvoiceID.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvReceivedInvoices.Columns.Add(SupplierInvoiceID);
        }

        public void SetupItemsIncludedDatagrid()
        {
            Helper.SetUpDataGrid(dgItemsIncluded);
            var tStyle = dgItemsIncluded.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var SupplierName = new DataGridLabelColumn();
            SupplierName.Format = "";
            SupplierName.FormatInfo = null;
            SupplierName.HeaderText = "Supplier";
            SupplierName.MappingName = "SupplierName";
            SupplierName.ReadOnly = true;
            SupplierName.Width = 100;
            SupplierName.NullText = "N/A";
            tStyle.GridColumnStyles.Add(SupplierName);
            var WarehouseName = new DataGridLabelColumn();
            WarehouseName.Format = "";
            WarehouseName.FormatInfo = null;
            WarehouseName.HeaderText = "Warehouse Name";
            WarehouseName.MappingName = "WarehouseName";
            WarehouseName.ReadOnly = true;
            WarehouseName.Width = 100;
            WarehouseName.NullText = "N/A";
            tStyle.GridColumnStyles.Add(WarehouseName);
            var VanReg = new DataGridLabelColumn();
            VanReg.Format = "";
            VanReg.FormatInfo = null;
            VanReg.HeaderText = "Stock Profile Name";
            VanReg.MappingName = "Registration";
            VanReg.ReadOnly = true;
            VanReg.Width = 100;
            VanReg.NullText = "N/A";
            tStyle.GridColumnStyles.Add(VanReg);
            var ProductName = new DataGridLabelColumn();
            ProductName.Format = "";
            ProductName.FormatInfo = null;
            ProductName.HeaderText = "Item Name";
            ProductName.MappingName = "Name";
            ProductName.ReadOnly = true;
            ProductName.Width = 150;
            ProductName.NullText = "";
            tStyle.GridColumnStyles.Add(ProductName);
            var ProductCode = new DataGridLabelColumn();
            ProductCode.Format = "";
            ProductCode.FormatInfo = null;
            ProductCode.HeaderText = "Company Code (GPN)";
            ProductCode.MappingName = "Number";
            ProductCode.ReadOnly = true;
            ProductCode.Width = 100;
            ProductCode.NullText = "";
            tStyle.GridColumnStyles.Add(ProductCode);
            var SuppProductCode = new DataGridLabelColumn();
            SuppProductCode.Format = "";
            SuppProductCode.FormatInfo = null;
            SuppProductCode.HeaderText = "Supplier Part Code (SPN)";
            SuppProductCode.MappingName = "SupplierPartCode";
            SuppProductCode.ReadOnly = true;
            SuppProductCode.Width = 100;
            SuppProductCode.NullText = "";
            tStyle.GridColumnStyles.Add(SuppProductCode);
            var BuyPrice = new DataGridLabelColumn();
            BuyPrice.Format = "C";
            BuyPrice.FormatInfo = null;
            BuyPrice.HeaderText = "Cost";
            BuyPrice.MappingName = "BuyPrice";
            BuyPrice.ReadOnly = true;
            BuyPrice.Width = 85;
            BuyPrice.NullText = "";
            tStyle.GridColumnStyles.Add(BuyPrice);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Sell Price";
            Price.MappingName = "SellPrice";
            Price.ReadOnly = true;
            Price.Width = 85;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var QuantityInPack = new DataGridLabelColumn();
            QuantityInPack.Format = "";
            QuantityInPack.FormatInfo = null;
            QuantityInPack.HeaderText = "Qty In Pack";
            QuantityInPack.MappingName = "QuantityInPack";
            QuantityInPack.ReadOnly = true;
            QuantityInPack.Width = 100;
            QuantityInPack.NullText = "";
            tStyle.GridColumnStyles.Add(QuantityInPack);
            var QuantityOnOrder = new DataGridLabelColumn();
            QuantityOnOrder.Format = "";
            QuantityOnOrder.FormatInfo = null;
            QuantityOnOrder.HeaderText = "Qty To Order";
            QuantityOnOrder.MappingName = "QuantityOnOrder";
            QuantityOnOrder.ReadOnly = true;
            QuantityOnOrder.Width = 100;
            QuantityOnOrder.NullText = "";
            tStyle.GridColumnStyles.Add(QuantityOnOrder);
            var QuantityReceived = new DataGridLabelColumn();
            QuantityReceived.Format = "";
            QuantityReceived.FormatInfo = null;
            QuantityReceived.HeaderText = "Qty Received";
            QuantityReceived.MappingName = "QuantityReceived";
            QuantityReceived.ReadOnly = true;
            QuantityReceived.Width = 100;
            QuantityReceived.NullText = "";
            tStyle.GridColumnStyles.Add(QuantityReceived);
            if (CurrentOrder is object)
            {
                if (CurrentOrder.Exists)
                {
                    var WithVan = new DataGridLabelColumn();
                    WithVan.Format = "dd/MM/yyyy HH:mm:ss";
                    WithVan.FormatInfo = null;
                    WithVan.HeaderText = "Date Engineer Picked up";
                    WithVan.MappingName = "WithEngineer_Van";
                    WithVan.ReadOnly = true;
                    WithVan.Width = 110;
                    WithVan.NullText = "";
                    tStyle.GridColumnStyles.Add(WithVan);
                    var WithEngineer = new DataGridLabelColumn();
                    WithEngineer.Format = "dd/MM/yyyy HH:mm:ss";
                    WithEngineer.FormatInfo = null;
                    WithEngineer.HeaderText = "Date Engineer Distributed";
                    WithEngineer.MappingName = "WithEngineer_Job";
                    WithEngineer.ReadOnly = true;
                    WithEngineer.Width = 110;
                    WithEngineer.NullText = "";
                    tStyle.GridColumnStyles.Add(WithEngineer);
                }
            }

            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblOrder.ToString();
            dgItemsIncluded.TableStyles.Add(tStyle);
        }

        public void SetupPartsDatagrid()
        {
            Helper.SetUpDataGrid(dgParts);
            var tStyle = dgParts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Preferred = new ColourColumn();
            Preferred.Format = "";
            Preferred.FormatInfo = null;
            Preferred.HeaderText = "Preferred";
            Preferred.MappingName = "Preferred";
            Preferred.ReadOnly = true;
            Preferred.Width = 25;
            Preferred.NullText = "";
            tStyle.GridColumnStyles.Add(Preferred);
            var SupplierName = new DataGridLabelColumn();
            SupplierName.Format = "";
            SupplierName.FormatInfo = null;
            SupplierName.HeaderText = "Supplier";
            SupplierName.MappingName = "SupplierName";
            SupplierName.ReadOnly = true;
            SupplierName.Width = 100;
            SupplierName.NullText = "No Supplier Assigned";
            tStyle.GridColumnStyles.Add(SupplierName);
            var EngineerName = new DataGridLabelColumn();
            EngineerName.Format = "";
            EngineerName.FormatInfo = null;
            EngineerName.HeaderText = "Engineer Name";
            EngineerName.MappingName = "EngineerName";
            EngineerName.ReadOnly = true;
            EngineerName.Width = 100;
            EngineerName.NullText = "";
            tStyle.GridColumnStyles.Add(EngineerName);
            var VanRegistration = new DataGridLabelColumn();
            VanRegistration.Format = "";
            VanRegistration.FormatInfo = null;
            VanRegistration.HeaderText = "Stock Profile Name";
            VanRegistration.MappingName = "Registration";
            VanRegistration.ReadOnly = true;
            VanRegistration.Width = 130;
            VanRegistration.NullText = "";
            tStyle.GridColumnStyles.Add(VanRegistration);
            var warehouseName = new DataGridLabelColumn();
            warehouseName.Format = "";
            warehouseName.FormatInfo = null;
            warehouseName.HeaderText = "Warehouse Name";
            warehouseName.MappingName = "warehouseName";
            warehouseName.ReadOnly = true;
            warehouseName.Width = 120;
            warehouseName.NullText = "";
            tStyle.GridColumnStyles.Add(warehouseName);
            var address1 = new DataGridLabelColumn();
            address1.Format = "";
            address1.FormatInfo = null;
            address1.HeaderText = "Address 1";
            address1.MappingName = "address1";
            address1.ReadOnly = true;
            address1.Width = 120;
            address1.NullText = "";
            tStyle.GridColumnStyles.Add(address1);
            var postcode = new DataGridLabelColumn();
            postcode.Format = "";
            postcode.FormatInfo = null;
            postcode.HeaderText = "Postcode";
            postcode.MappingName = "postcode";
            postcode.ReadOnly = true;
            postcode.Width = 120;
            postcode.NullText = "";
            tStyle.GridColumnStyles.Add(postcode);
            var PartName = new DataGridLabelColumn();
            PartName.Format = "";
            PartName.FormatInfo = null;
            PartName.HeaderText = "Part Name";
            PartName.MappingName = "PartName";
            PartName.ReadOnly = true;
            PartName.Width = 250;
            PartName.NullText = "";
            tStyle.GridColumnStyles.Add(PartName);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Cost";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 85;
            Price.NullText = "£0.00";
            tStyle.GridColumnStyles.Add(Price);
            var PartNumber = new DataGridLabelColumn();
            PartNumber.Format = "";
            PartNumber.FormatInfo = null;
            PartNumber.HeaderText = "Company Code";
            PartNumber.MappingName = "PartNumber";
            PartNumber.ReadOnly = true;
            PartNumber.Width = 100;
            PartNumber.NullText = "";
            tStyle.GridColumnStyles.Add(PartNumber);
            var PartCode = new DataGridLabelColumn();
            PartCode.Format = "";
            PartCode.FormatInfo = null;
            PartCode.HeaderText = "Supplier Code";
            PartCode.MappingName = "PartCode";
            PartCode.ReadOnly = true;
            PartCode.Width = 130;
            PartCode.NullText = "";
            tStyle.GridColumnStyles.Add(PartCode);
            var QuantityInPack = new DataGridLabelColumn();
            QuantityInPack.Format = "";
            QuantityInPack.FormatInfo = null;
            QuantityInPack.HeaderText = "Qty In Pack";
            QuantityInPack.MappingName = "QuantityInPack";
            QuantityInPack.ReadOnly = true;
            QuantityInPack.Width = 120;
            QuantityInPack.NullText = "";
            tStyle.GridColumnStyles.Add(QuantityInPack);
            var PartReference = new DataGridLabelColumn();
            PartReference.Format = "";
            PartReference.FormatInfo = null;
            PartReference.HeaderText = "Part Ref";
            PartReference.MappingName = "Reference";
            PartReference.ReadOnly = true;
            PartReference.Width = 100;
            PartReference.NullText = "";
            tStyle.GridColumnStyles.Add(PartReference);
            var SellPrice = new DataGridLabelColumn();
            SellPrice.Format = "C";
            SellPrice.FormatInfo = null;
            SellPrice.HeaderText = "Sell Price";
            SellPrice.MappingName = "SellPrice";
            SellPrice.ReadOnly = true;
            SellPrice.Width = 85;
            SellPrice.NullText = "";
            tStyle.GridColumnStyles.Add(SellPrice);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 85;
            Amount.NullText = "";
            tStyle.GridColumnStyles.Add(Amount);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblPart.ToString();
            dgParts.TableStyles.Add(tStyle);
        }

        public void SetupProductsDatagrid()
        {
            Helper.SetUpDataGrid(dgProduct);
            var tStyle = dgProduct.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var warehouseName = new DataGridLabelColumn();
            warehouseName.Format = "";
            warehouseName.FormatInfo = null;
            warehouseName.HeaderText = "Warehouse Name";
            warehouseName.MappingName = "warehouseName";
            warehouseName.ReadOnly = true;
            warehouseName.Width = 120;
            warehouseName.NullText = "";
            tStyle.GridColumnStyles.Add(warehouseName);
            var address1 = new DataGridLabelColumn();
            address1.Format = "";
            address1.FormatInfo = null;
            address1.HeaderText = "Address 1";
            address1.MappingName = "address1";
            address1.ReadOnly = true;
            address1.Width = 120;
            address1.NullText = "";
            tStyle.GridColumnStyles.Add(address1);
            var postcode = new DataGridLabelColumn();
            postcode.Format = "";
            postcode.FormatInfo = null;
            postcode.HeaderText = "Postcode";
            postcode.MappingName = "postcode";
            postcode.ReadOnly = true;
            postcode.Width = 120;
            postcode.NullText = "";
            tStyle.GridColumnStyles.Add(postcode);
            var SupplierName = new DataGridLabelColumn();
            SupplierName.Format = "";
            SupplierName.FormatInfo = null;
            SupplierName.HeaderText = "Supplier";
            SupplierName.MappingName = "SupplierName";
            SupplierName.ReadOnly = true;
            SupplierName.Width = 100;
            SupplierName.NullText = "No Supplier Assigned";
            tStyle.GridColumnStyles.Add(SupplierName);
            var EngineerName = new DataGridLabelColumn();
            EngineerName.Format = "";
            EngineerName.FormatInfo = null;
            EngineerName.HeaderText = "Engineer Name";
            EngineerName.MappingName = "EngineerName";
            EngineerName.ReadOnly = true;
            EngineerName.Width = 100;
            EngineerName.NullText = "";
            tStyle.GridColumnStyles.Add(EngineerName);
            var VanRegistration = new DataGridLabelColumn();
            VanRegistration.Format = "";
            VanRegistration.FormatInfo = null;
            VanRegistration.HeaderText = "Stock Profile Name";
            VanRegistration.MappingName = "Registration";
            VanRegistration.ReadOnly = true;
            VanRegistration.Width = 130;
            VanRegistration.NullText = "";
            tStyle.GridColumnStyles.Add(VanRegistration);
            var ProductName = new DataGridLabelColumn();
            ProductName.Format = "";
            ProductName.FormatInfo = null;
            ProductName.HeaderText = "Description";
            ProductName.MappingName = "typemakemodel";
            ProductName.ReadOnly = true;
            ProductName.Width = 100;
            ProductName.NullText = "";
            tStyle.GridColumnStyles.Add(ProductName);
            var ProductCode = new DataGridLabelColumn();
            ProductCode.Format = "";
            ProductCode.FormatInfo = null;
            ProductCode.HeaderText = "Supplier Product Code";
            ProductCode.MappingName = "ProductCode";
            ProductCode.ReadOnly = true;
            ProductCode.Width = 130;
            ProductCode.NullText = "";
            tStyle.GridColumnStyles.Add(ProductCode);
            var ProductNumber = new DataGridLabelColumn();
            ProductNumber.Format = "";
            ProductNumber.FormatInfo = null;
            ProductNumber.HeaderText = "Product Code";
            ProductNumber.MappingName = "ProductNumber";
            ProductNumber.ReadOnly = true;
            ProductNumber.Width = 100;
            ProductNumber.NullText = "";
            tStyle.GridColumnStyles.Add(ProductNumber);
            var ProductReference = new DataGridLabelColumn();
            ProductReference.Format = "";
            ProductReference.FormatInfo = null;
            ProductReference.HeaderText = "Product Reference";
            ProductReference.MappingName = "Reference";
            ProductReference.ReadOnly = true;
            ProductReference.Width = 120;
            ProductReference.NullText = "";
            tStyle.GridColumnStyles.Add(ProductReference);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Cost";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 85;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var SellPrice = new DataGridLabelColumn();
            SellPrice.Format = "C";
            SellPrice.FormatInfo = null;
            SellPrice.HeaderText = "Sell Price";
            SellPrice.MappingName = "SellPrice";
            SellPrice.ReadOnly = true;
            SellPrice.Width = 85;
            SellPrice.NullText = "";
            tStyle.GridColumnStyles.Add(SellPrice);
            var QuantityInPack = new DataGridLabelColumn();
            QuantityInPack.Format = "";
            QuantityInPack.FormatInfo = null;
            QuantityInPack.HeaderText = "Quantity In Pack";
            QuantityInPack.MappingName = "QuantityInPack";
            QuantityInPack.ReadOnly = true;
            QuantityInPack.Width = 120;
            QuantityInPack.NullText = "";
            tStyle.GridColumnStyles.Add(QuantityInPack);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 85;
            Amount.NullText = "";
            tStyle.GridColumnStyles.Add(Amount);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblProduct.ToString();
            dgProduct.TableStyles.Add(tStyle);
        }

        public void SetupPriceRequestDatagrid()
        {
            Helper.SetUpDataGrid(dgPriceRequests);
            var tStyle = dgPriceRequests.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            var SupplierName = new DataGridLabelColumn();
            SupplierName.Format = "";
            SupplierName.FormatInfo = null;
            SupplierName.HeaderText = "Supplier";
            SupplierName.MappingName = "SupplierName";
            SupplierName.ReadOnly = true;
            SupplierName.Width = 150;
            SupplierName.NullText = "";
            tStyle.GridColumnStyles.Add(SupplierName);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "Postcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 150;
            Postcode.NullText = "";
            tStyle.GridColumnStyles.Add(Postcode);
            var TelephoneNum = new DataGridLabelColumn();
            TelephoneNum.Format = "";
            TelephoneNum.FormatInfo = null;
            TelephoneNum.HeaderText = "Telephone";
            TelephoneNum.MappingName = "TelephoneNum";
            TelephoneNum.ReadOnly = true;
            TelephoneNum.Width = 150;
            TelephoneNum.NullText = "";
            tStyle.GridColumnStyles.Add(TelephoneNum);
            var partName = new DataGridLabelColumn();
            partName.Format = "";
            partName.FormatInfo = null;
            partName.HeaderText = "Part";
            partName.MappingName = "Part";
            partName.ReadOnly = true;
            partName.Width = 150;
            partName.NullText = "";
            tStyle.GridColumnStyles.Add(partName);
            var ProductName = new DataGridLabelColumn();
            ProductName.Format = "";
            ProductName.FormatInfo = null;
            ProductName.HeaderText = "Product";
            ProductName.MappingName = "Product";
            ProductName.ReadOnly = true;
            ProductName.Width = 150;
            ProductName.NullText = "";
            tStyle.GridColumnStyles.Add(ProductName);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Quantity";
            Amount.MappingName = "QuantityInPack";
            Amount.ReadOnly = true;
            Amount.Width = 110;
            Amount.NullText = "";
            tStyle.GridColumnStyles.Add(Amount);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
            dgPriceRequests.TableStyles.Add(tStyle);
        }

        private void txtGoodsAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtGoodsAmount.Text != default)
            {
                try
                {
                    Calculate_Tax();
                    txtGoodsAmount.Text = Strings.FormatCurrency(txtGoodsAmount.Text);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void txtVATAmount_LostFocus(object sender, EventArgs e)
        {
            if (txtGoodsAmount.Text != default & txtVATAmount.Text != default)
            {
                txtVATAmount.Text = Strings.FormatCurrency(txtVATAmount.Text);
                txtTotalAmount.Text = Strings.FormatCurrency(Conversions.ToDouble(Strings.Replace(txtGoodsAmount.Text, "£", "")) + Conversions.ToDouble(Strings.Replace(txtVATAmount.Text, "£", "")));
            }
        }

        private void txtCreditAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCreditGoods.Text != default)
            {
                try
                {
                    Calculate_Tax2();
                    txtCreditGoods.Text = Strings.FormatCurrency(txtCreditGoods.Text);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void txtCreditVAT__LostFocus(object sender, EventArgs e)
        {
            if (txtCreditGoods.Text != default & txtCreditVAT.Text != default)
            {
                txtCreditVAT.Text = Strings.FormatCurrency(txtCreditVAT.Text);
                txtCreditTotal.Text = Strings.FormatCurrency(Conversions.ToDouble(Strings.Replace(txtCreditGoods.Text, "£", "")) + Conversions.ToDouble(Strings.Replace(txtCreditVAT.Text, "£", "")));
            }
        }

        private void btnReceiveAll_Click(object sender, EventArgs e)
        {
            if (CurrentOrder.OrderConsolidationID > 0)
            {
                if ((Conversions.ToString(SelectedItemIncludedDataRow["Type"]) ?? "") == "OrderPart" | (Conversions.ToString(SelectedItemIncludedDataRow["Type"]) ?? "") == "OrderProduct")
                {
                    App.ShowMessage("This order has been added to a consolidation so should be managed from there.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (!(CurrentOrder.OrderStatusID == Conversions.ToInteger(Enums.OrderStatus.Confirmed)))
            {
                App.ShowMessage("Order must be confirmed to mark items into stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataRow itemRow in ItemsIncludedDataView.Table.Rows)
            {
                if (!(Conversions.ToInteger(itemRow["QuantityOnOrder"]) == Conversions.ToInteger(itemRow["QuantityReceived"])))
                {
                    int quantityInput = Conversions.ToInteger(itemRow["QuantityOnOrder"]) - Conversions.ToInteger(itemRow["QuantityReceived"]);
                    var switchExpr = Conversions.ToString(itemRow["Type"]);
                    switch (switchExpr)
                    {
                        case "OrderProduct":
                            {
                                var OrderProduct = new Entity.OrderProducts.OrderProduct();
                                var oProduct = new Entity.Products.Product();
                                OrderProduct = App.DB.OrderProduct.OrderProduct_Get(Conversions.ToInteger(itemRow["ID"]));
                                var oProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID);
                                oProduct = App.DB.Product.Product_Get(oProductSupplier.ProductID);
                                OrderProduct.SetQuantityReceived = OrderProduct.QuantityReceived + quantityInput;
                                App.DB.OrderProduct.Update(OrderProduct);
                                var switchExpr1 = CurrentOrder.OrderTypeID;
                                switch (switchExpr1)
                                {
                                    case Conversions.ToInteger(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case Conversions.ToInteger(Enums.OrderType.Warehouse):
                                        {
                                            var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderProduct.OrderID);
                                            var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                                            oProductTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oProductTransaction.SetProductID = oProductSupplier.ProductID;
                                            oProductTransaction.SetOrderProductID = OrderProduct.OrderProductID;
                                            oProductTransaction.SetAmount = quantityInput * oProductSupplier.QuantityInPack;
                                            oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
                                            App.DB.ProductTransaction.Insert(oProductTransaction);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "OrderPart":
                            {
                                var OrderPart = new Entity.OrderParts.OrderPart();
                                OrderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(itemRow["ID"]));
                                OrderPart.SetQuantityReceived = OrderPart.QuantityReceived + quantityInput;
                                App.DB.OrderPart.Update(OrderPart);
                                var switchExpr2 = CurrentOrder.OrderTypeID;
                                switch (switchExpr2)
                                {
                                    case Conversions.ToInteger(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case Conversions.ToInteger(Enums.OrderType.Warehouse):
                                        {
                                            var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID);
                                            var oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID);
                                            var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                            oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oPartTransaction.SetPartID = oPartSupplier.PartID;
                                            oPartTransaction.SetOrderPartID = OrderPart.OrderPartID;
                                            oPartTransaction.SetAmount = quantityInput * oPartSupplier.QuantityInPack;
                                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
                                            App.DB.PartTransaction.Insert(oPartTransaction);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "OrderLocationProduct":
                            {
                                var OrderLocationProduct = App.DB.OrderLocationProduct.OrderLocationProduct_Get(Conversions.ToInteger(itemRow["ID"]));
                                var oProductTransaction = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(OrderLocationProduct.OrderLocationProductID);
                                oProductTransaction.SetAmount = oProductTransaction.Amount + quantityInput;
                                App.DB.ProductTransaction.Update(oProductTransaction);
                                oProductTransaction.SetLocationID = OrderLocationProduct.LocationID;
                                oProductTransaction.SetProductID = OrderLocationProduct.ProductID;
                                oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID;
                                oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockOut);
                                oProductTransaction.SetAmount = -quantityInput;
                                App.DB.ProductTransaction.Insert(oProductTransaction);
                                OrderLocationProduct.SetQuantityReceived = OrderLocationProduct.QuantityReceived + quantityInput;
                                App.DB.OrderLocationProduct.Update(OrderLocationProduct);
                                var switchExpr3 = CurrentOrder.OrderTypeID;
                                switch (switchExpr3)
                                {
                                    case Conversions.ToInteger(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case Conversions.ToInteger(Enums.OrderType.Warehouse):
                                        {
                                            Entity.OrderLocations.OrderLocation oOrderLocation;
                                            oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationProduct.OrderID);
                                            oProductTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
                                            oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID;
                                            oProductTransaction.SetAmount = quantityInput;
                                            oProductTransaction.SetProductID = OrderLocationProduct.ProductID;
                                            App.DB.ProductTransaction.Insert(oProductTransaction);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "OrderLocationPart":
                            {
                                var OrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get(Conversions.ToInteger(itemRow["ID"]));
                                var oPartTransaction = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(OrderLocationPart.OrderLocationPartID);
                                oPartTransaction.SetAmount = oPartTransaction.Amount + quantityInput;
                                App.DB.PartTransaction.Update(oPartTransaction);
                                oPartTransaction.SetLocationID = OrderLocationPart.LocationID;
                                oPartTransaction.SetPartID = OrderLocationPart.PartID;
                                oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID;
                                oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockOut);
                                oPartTransaction.SetAmount = -quantityInput;
                                App.DB.PartTransaction.Insert(oPartTransaction);
                                OrderLocationPart.SetQuantityReceived = OrderLocationPart.QuantityReceived + quantityInput;
                                App.DB.OrderLocationPart.Update(OrderLocationPart);
                                var switchExpr4 = CurrentOrder.OrderTypeID;
                                switch (switchExpr4)
                                {
                                    case Conversions.ToInteger(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case Conversions.ToInteger(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case Conversions.ToInteger(Enums.OrderType.Warehouse):
                                        {
                                            Entity.OrderLocations.OrderLocation oOrderLocation;
                                            oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationPart.OrderID);
                                            oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
                                            oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID;
                                            oPartTransaction.SetAmount = quantityInput;
                                            oPartTransaction.SetPartID = OrderLocationPart.PartID;
                                            App.DB.PartTransaction.Insert(oPartTransaction);
                                            break;
                                        }
                                }

                                break;
                            }
                    }
                }
            }

            Populate(CurrentOrder.OrderID);
            if (isOrderComplete() == true)
            {
                CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Complete);
                App.DB.Order.Update(CurrentOrder);
                IsLoading = true;
                Populate(CurrentOrder.OrderID);
                IsLoading = false;
                if (CurrentOrder.OrderTypeID == Conversions.ToInteger(Enums.OrderType.Job))
                {
                    var oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(ucJobOrder.SelectedEngineerVisitDataRow["EngineerVisitID"]));
                    if (oEngineerVisit.StatusEnumID == Conversions.ToInteger(Enums.VisitStatus.Waiting_For_Parts))
                    {

                        // LETS SEE FIRST IF ALL THE ORDERS RELATING TO THIS VISIT ARE COMPLETE? - ALP 22/01/08
                        var dv = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(oEngineerVisit.EngineerVisitID);
                        bool allComplete = true;
                        foreach (DataRow dr in dv.Table.Rows)
                        {
                            if (!(Helper.MakeIntegerValid(dr["OrderStatusID"]) == 0))
                            {
                                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(dr["OrderStatusID"], Conversions.ToInteger(Enums.OrderStatus.Complete), false)))
                                {
                                    allComplete = false;
                                }
                            }
                        }

                        if (allComplete)
                        {
                            App.ShowForm(typeof(FRMPickDespatchDetails), true, new object[] { oEngineerVisit });
                        }
                    }
                }

                // IF ORDER IS COMPLETE AND ITS A CUSTOMER ORDER THEN ADD ROW TO RAISE INVOICE TABLE
                if ((Enums.OrderType)Conversions.ToInteger(CurrentOrder.OrderTypeID) == Enums.OrderType.Customer)
                {
                    App.ShowForm(typeof(FrmRaiseInvoiceDetails), true, new object[] { CurrentOrder.OrderID, CurrentOrder.InvoiceAddressID });
                }
            }
        }

        private void btnRelatedJob_Click(object sender, EventArgs e)
        {
            var oJob = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(PassedID);
            App.ShowForm(typeof(FRMLogCallout), true, new object[] { oJob.JobID, oJob.PropertyID, this, null, PassedID });
        }

        private void UCOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (tcOrderDetails.SelectedIndex == 1) // parts
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PartSearch();
                }
            }
            else if (tcOrderDetails.SelectedIndex == 2) // products
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ProductSearch();
                }
            }
            else
            {
            }
        }

        private void UCOrder_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            Enums.SecuritySystemModules ssm3;
            ssm3 = Enums.SecuritySystemModules.POUnlock;
            if (App.loggedInUser.HasAccessToModule(ssm3) == true)
            {
                chkRevertStatus.Visible = true;
            }
        }

        private void cboOrderTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlDetails.Controls.Count > 0)
            {
                pnlDetails.Controls.Clear();
            }

            var switchExpr = Combo.get_GetSelectedItemValue(cboOrderTypeID);
            switch (switchExpr)
            {
                case var @case when @case == Conversions.ToString(Enums.OrderType.Customer):
                    {
                        pnlDetails.Controls.Add(ucCustomerOrder);
                        break;
                    }

                case var case1 when case1 == Conversions.ToString(Enums.OrderType.Job):
                    {
                        pnlDetails.Controls.Add(ucJobOrder);
                        break;
                    }

                case var case2 when case2 == Conversions.ToString(Enums.OrderType.Warehouse):
                    {
                        pnlDetails.Controls.Add(ucWarehouseOrder);
                        break;
                    }

                case var case3 when case3 == Conversions.ToString(Enums.OrderType.StockProfile):
                    {
                        if (_currentOrder.Exists)
                        {
                            pnlDetails.Controls.Add(ucVanOrder);
                        }
                        else
                        {
                            // ShowMessage("Van Orders Have been suspended.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            // Combo.SetSelectedComboItem_By_Value(Me.cboOrderTypeID, 0)
                            // Exit Sub
                            pnlDetails.Controls.Add(ucVanOrder);
                        }

                        break;
                    }

                default:
                    {
                        if (CurrentOrder is null)
                        {
                            lblOrderStatus.Text = "SAVE BASE ORDER DETAILS BEFORE MANAGING ITEMS";
                        }
                        else if (CurrentOrder.Exists)
                        {
                            lblOrderStatus.Text = "PICK WHAT THE ORDER IS FOR";
                        }
                        else
                        {
                            lblOrderStatus.Text = "SAVE BASE ORDER DETAILS BEFORE MANAGING ITEMS";
                        }

                        lblOrderStatus.Visible = true;
                        return;
                    }
            }

            OrderNumber = OrderNumber;
            var switchExpr1 = CurrentOrder.OrderStatusID;
            switch (switchExpr1)
            {
                case (int)Enums.OrderStatus.Confirmed:
                case (int)Enums.OrderStatus.AwaitingApproval:
                    {
                        DisableFields();
                        btnCharges.Enabled = true;
                        lblOrderStatus.Text = "ORDER WAITING FOR ITEMS RECEIVED";
                        lblOrderStatus.Visible = true;
                        break;
                    }

                case (int)Enums.OrderStatus.Cancelled:
                    {
                        DisableFields();
                        btnCharges.Enabled = false;
                        lblOrderStatus.Text = "ORDER HAS BEEN CANCELLED (click to view)";
                        lblOrderStatus.Visible = true;
                        break;
                    }

                case (int)Enums.OrderStatus.Complete:
                    {
                        DisableFields();
                        btnCharges.Enabled = false;
                        lblOrderStatus.Text = "ORDER COMPLETE";
                        lblOrderStatus.Visible = true;
                        if (CurrentOrder.ExportedToSage)
                        {
                            lblOrderStatus.Text += " - (Invoiced and Sent to Sage)";
                        }
                        else if (CurrentOrder.Invoiced)
                        {
                            lblOrderStatus.Text += " - (Invoiced)";
                        }

                        break;
                    }

                case (int)Enums.OrderStatus.AwaitingConfirmation:
                    {
                        lblOrderStatus.Text = "ORDER AWAITING CONFIRMATION FROM CUSTOMER";
                        lblOrderStatus.Visible = true;
                        break;
                    }

                default:
                    {
                        lblOrderStatus.Text = "";
                        lblOrderStatus.Visible = false;
                        break;
                    }
            }

            if (CurrentOrder.SentToSage)
            {
                lblOrderStatus.Text += " *Supplier Invoice(s) sent to Sage*";
            }
            else
            {
                lblOrderStatus.Text += " *Supplier Invoice NOT sent to Sage*";
            }
        }

        private void tcOrderDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsLoading == false)
            {
                if (!((tcOrderDetails.SelectedTab.Name ?? "") == "tabDetails"))
                {
                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboOrderTypeID)) == 0)
                    {
                        App.ShowMessage("You must select an Order Type to continue.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tcOrderDetails.SelectedTab = tabDetails;
                    }
                }
            }
        }

        private void chkDeadlineNA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeadlineNA.Checked)
            {
                dtpDeliveryDeadline.Enabled = false;
            }
            else
            {
                dtpDeliveryDeadline.Enabled = true;
            }
        }

        private void cboOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool RemoveConsolidation = false;
            if (IsLoading == false)
            {
                if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboOrderStatus)) == (double)Enums.OrderStatus.Confirmed))
                {
                    if (CurrentOrder.OrderConsolidationID > 0)
                    {
                        App.ShowMessage("This order has been added to a consolidation so should be managed from there.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsLoading = true;
                        var argcombo = cboOrderStatus;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentOrder.OrderStatusID.ToString());
                        IsLoading = false;
                        return;
                    }
                }

                var switchExpr = Combo.get_GetSelectedItemValue(cboOrderStatus);
                switch (switchExpr)
                {
                    case var @case when @case == Conversions.ToString(Enums.OrderStatus.Confirmed):
                        {
                            string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDept));
                            if (Helper.IsValidInteger(department) && Helper.MakeIntegerValid(department) <= 0)
                            {
                                App.ShowMessage("Department Reference Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                IsLoading = true;
                                var argcombo1 = cboOrderStatus;
                                Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentOrder.OrderStatusID.ToString());
                                IsLoading = false;
                            }
                            else if (App.ShowMessage("Are you sure you want to confirm order? No changes can be made to the order once it has been confirmed.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                IsLoading = true;
                                var argcombo2 = cboOrderStatus;
                                Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentOrder.OrderStatusID.ToString());
                                IsLoading = false;
                                return;
                            }
                            else if (ItemsIncludedDataView.Table.Rows.Count == 0)
                            {
                                App.ShowMessage("There are no items included on this order, Order cannot be marked as confirmed until items added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                IsLoading = true;
                                var argcombo3 = cboOrderStatus;
                                Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentOrder.OrderStatusID.ToString());
                                IsLoading = false;
                                return;
                            }
                            else if (CurrentOrder.OrderConsolidationID > 0)
                            {
                                if (App.ShowMessage("This order will be removed from the consolidation, are you sure you wish to confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    IsLoading = true;
                                    var argcombo4 = cboOrderStatus;
                                    Combo.SetSelectedComboItem_By_Value(ref argcombo4, CurrentOrder.OrderStatusID.ToString());
                                    IsLoading = false;
                                    return;
                                }
                                else
                                {
                                    IsLoading = true;
                                    CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Confirmed);
                                    RemoveConsolidation = true;
                                }
                            }
                            else
                            {
                                if (CurrentOrder.OrderStatusID != Conversions.ToInteger(Enums.OrderStatus.Confirmed))
                                {
                                    var orderControl = new OrderControl(CurrentOrder);
                                    if (orderControl.IsWithinJobSpendLimit())
                                    {
                                        CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Confirmed);
                                    }
                                    else if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.POAuthorisation))
                                    {
                                        App.ShowMessage("Job cost capacity was exceeded when creating this purchase order!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Confirmed);
                                    }
                                    else
                                    {
                                        App.ShowMessage("Job cost capacity was exceeded when creating this purchase order!" + Constants.vbCrLf + Constants.vbCrLf + "Please note that this order is currently awaiting approval!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.AwaitingApproval);
                                    }
                                }

                                if (CurrentOrder.OrderStatusID == Conversions.ToInteger(Enums.OrderStatus.Confirmed) && CurrentOrder.OrderTypeID == (int)Enums.OrderType.Job)
                                {
                                    int engineerVisitId = Conversions.ToInteger(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]);
                                    var oEngVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId);
                                    oEngVisit.SetPartsToFit = true;
                                    App.DB.EngineerVisits.Update(oEngVisit, 0, true);
                                }

                                // check if the order has an f on the end
                                string orderRef = CurrentOrder.OrderReference;
                                if (orderRef.ToLower().EndsWith("f"))
                                {
                                    // remove the f
                                    CurrentOrder.SetOrderReference = CurrentOrder.OrderReference.Trim().Remove(orderRef.Length - 1);
                                }

                                if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.Job)
                                {
                                    int siteId = Conversions.ToInteger(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["SiteID"]);
                                    var currentCustomer = App.DB.Customer.Customer_Get_ForSiteID(siteId);
                                    if (currentCustomer.IsPFH)
                                    {
                                        if (App.DB.Supplier.Supplier_GetSecondaryPrice(SupplierUsedID))
                                        {
                                            CurrentOrder.SetOrderReference = CurrentOrder.OrderReference + "F";
                                        }
                                    }
                                }
                            }

                            break;
                        }

                    case var case1 when case1 == Conversions.ToString(Enums.OrderStatus.Cancelled):
                        {
                            if (!(CurrentOrder.OrderStatusID == (int)Enums.OrderStatus.Cancelled))
                            {
                                if (App.ShowMessage("Are you sure you want to cancel this order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    App.ShowForm(typeof(FRMOrderRejection), true, new object[] { this, "" });
                                    if (dgvReceivedInvoices.RowCount > 0)
                                    {
                                        App.ShowMessage("You can not cancel this order as Invoices have been received", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        IsLoading = true;
                                        var argcombo5 = cboOrderStatus;
                                        Combo.SetSelectedComboItem_By_Value(ref argcombo5, CurrentOrder.OrderStatusID.ToString());
                                        IsLoading = false;
                                        return;
                                    }

                                    if (Reason.Trim().Length == 0)
                                    {
                                        IsLoading = true;
                                        var argcombo6 = cboOrderStatus;
                                        Combo.SetSelectedComboItem_By_Value(ref argcombo6, CurrentOrder.OrderStatusID.ToString());
                                        IsLoading = false;
                                        return;
                                    }
                                    else
                                    {

                                        // remove parts allocated
                                        if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.Job)
                                        {
                                            var dt = App.DB.Order.OrderPart_GetForOrder(CurrentOrder.OrderID).Table;
                                            foreach (DataRow d in dt.Rows)
                                                App.DB.ExecuteScalar(Conversions.ToString("Delete tblengineerVisitPartAllocated where orderpartid = " + d["OrderPartID"]));
                                        }

                                        App.DB.PartTransaction.DeleteForOrder(CurrentOrder.OrderID);
                                        App.DB.ProductTransaction.DeleteForOrder(CurrentOrder.OrderID);
                                        CurrentOrder.SetReasonForReject = Reason;
                                        CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Cancelled);
                                    }
                                }
                                else
                                {
                                    IsLoading = true;
                                    var argcombo7 = cboOrderStatus;
                                    Combo.SetSelectedComboItem_By_Value(ref argcombo7, CurrentOrder.OrderStatusID.ToString());
                                    IsLoading = false;
                                    return;
                                }
                            }

                            break;
                        }

                    case var case2 when case2 == Conversions.ToString(Enums.OrderStatus.Complete):
                        {
                            string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDept));
                            if (Helper.IsValidInteger(department) && Helper.MakeIntegerValid(department) <= 0)
                            {
                                App.ShowMessage("Department Reference Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                IsLoading = true;
                                var argcombo8 = cboOrderStatus;
                                Combo.SetSelectedComboItem_By_Value(ref argcombo8, CurrentOrder.OrderStatusID.ToString());
                                IsLoading = false;
                            }
                            else if (CurrentOrder.OrderStatusID == (int)Enums.OrderStatus.AwaitingConfirmation)
                            {
                                App.ShowMessage("You cannot complete an order manually.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                IsLoading = true;
                                var argcombo9 = cboOrderStatus;
                                Combo.SetSelectedComboItem_By_Value(ref argcombo9, CurrentOrder.OrderStatusID.ToString());
                                IsLoading = false;
                                return;
                            }

                            break;
                        }
                }

                CurrentOrder.SetDepartmentRef = Combo.get_GetSelectedItemValue(cboDept);
                App.DB.Order.Update(CurrentOrder);
                if (RemoveConsolidation)
                {
                    App.DB.OrderConsolidations.Order_Set_Consolidated(CurrentOrder.OrderConsolidationID, CurrentOrder.OrderID, true);
                }

                IsLoading = true;
                CurrentOrder = App.DB.Order.Order_Get(CurrentOrder.OrderID);
            }

            if (CurrentOrder is object)
            {
                if (CurrentOrder.OrderStatusID == (int)Enums.OrderStatus.AwaitingConfirmation | CurrentOrder.OrderStatusID == (int)Enums.OrderStatus.AwaitingApproval | CurrentOrder.OrderStatusID == 0)
                {
                    txtOrderReference.Visible = false;
                    btnUpdateOrderRef.Visible = false;
                }
                else
                {
                    txtOrderReference.Visible = true;
                    btnUpdateOrderRef.Visible = true;
                }
            }
            else
            {
                txtOrderReference.Visible = false;
                btnUpdateOrderRef.Visible = false;
            }
        }

        public void ReasonChanged(string Reason)
        {
            this.Reason = Reason;
        }

        private void lblOrderStatus_Click(object sender, EventArgs e)
        {
            if (CurrentOrder.OrderStatusID == (int)Enums.OrderStatus.Cancelled)
            {
                App.ShowForm(typeof(FRMOrderRejection), true, new object[] { this, CurrentOrder.ReasonForReject });
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Email();
        }

        private void btnCharges_Click(object sender, EventArgs e)
        {
            if (CurrentOrder.OrderID == 0)
            {
                App.ShowMessage("You must save the order before adding additional charges", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            App.ShowForm(typeof(FRMOrderCharges), true, new object[] { CurrentOrder.OrderID });
            PopulateOrderTotal();
        }

        private void btnCreatePartRequest_Click(object sender, EventArgs e)
        {
            int supplierID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSupplier));
            try
            {
                if (!(supplierID == 0))
                {
                    Cursor = Cursors.WaitCursor;
                    var oPartPriceRequest = new Entity.PartSupplierPriceRequests.PartSupplierPriceRequest();
                    oPartPriceRequest.IgnoreExceptionsOnSetMethods = true;
                    oPartPriceRequest.SetPartID = SelectedPartDataRow["PartID"];
                    oPartPriceRequest.SetQuantityInPack = txtPartQuantity.Text.Trim();
                    oPartPriceRequest.SetOrderID = CurrentOrder.OrderID;
                    oPartPriceRequest.SetSupplierID = supplierID;
                    oPartPriceRequest.SetComplete = 0;
                    var val = new Entity.PartSupplierPriceRequests.PartSupplierPriceRequestValidator();
                    val.Validate(oPartPriceRequest);
                    App.DB.PartPriceRequest.InsertForOrder(oPartPriceRequest);
                    RefreshDataGrids();
                    PartSearch();
                    ProductSearch();
                }
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCreateProductPriceRequest_Click(object sender, EventArgs e)
        {
            int supplierID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSupplier));
            try
            {
                if (!(supplierID == 0))
                {
                    Cursor = Cursors.WaitCursor;
                    var oProductPriceRequest = new Entity.ProductSupplierPriceRequests.ProductSupplierPriceRequest();
                    oProductPriceRequest.IgnoreExceptionsOnSetMethods = true;
                    oProductPriceRequest.SetProductID = SelectedProductDataRow["ProductID"];
                    oProductPriceRequest.SetQuantityInPack = txtProductQuantity.Text.Trim();
                    oProductPriceRequest.SetOrderID = CurrentOrder.OrderID;
                    oProductPriceRequest.SetSupplierID = supplierID;
                    oProductPriceRequest.SetComplete = 0;
                    var val = new Entity.ProductSupplierPriceRequests.ProductSupplierPriceRequestValidator();
                    val.Validate(oProductPriceRequest);
                    App.DB.ProductPriceRequest.InsertForOrder(oProductPriceRequest);
                    PartSearch();
                    ProductSearch();
                    RefreshDataGrids();
                }
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgPriceRequests_Click(object sender, EventArgs e)
        {
            if (SelectedPriceRequestDataRow is null)
            {
                App.ShowMessage("Please select item to update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnUpdatePartPriceRequest.Enabled = false;
                return;
            }

            btnUpdatePartPriceRequest.Enabled = true;
        }

        private void btnUpdatePartPriceRequest_Click(object sender, EventArgs e)
        {
            if (SelectedPriceRequestDataRow is null)
            {
                App.ShowMessage("Please select an item to update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnUpdatePartPriceRequest.Enabled = false;
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPriceRequestDataRow["Type"], "Part", false)))
            {
                var oPartSupplier = new Entity.PartSuppliers.PartSupplier();
                oPartSupplier.SetPartID = SelectedPriceRequestDataRow["PartProductID"];
                oPartSupplier.SetSupplierID = SelectedPriceRequestDataRow["SupplierID"];
                oPartSupplier.SetQuantityInPack = SelectedPriceRequestDataRow["QuantityInPack"];
                App.ShowForm(typeof(FRMAddtoOrder), true, new object[] { CurrentOrder, oPartSupplier, null, SelectedPriceRequestDataRow["ID"] });
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPriceRequestDataRow["Type"], "Product", false)))
            {
                var oProductSupplier = new Entity.ProductSuppliers.ProductSupplier();
                oProductSupplier.SetProductID = SelectedPriceRequestDataRow["PartProductID"];
                oProductSupplier.SetSupplierID = SelectedPriceRequestDataRow["SupplierID"];
                oProductSupplier.SetQuantityInPack = SelectedPriceRequestDataRow["QuantityInPack"];
                App.ShowForm(typeof(FRMAddtoOrder), true, new object[] { CurrentOrder, null, oProductSupplier, SelectedPriceRequestDataRow["ID"] });
            }

            RefreshDataGrids();
            PartSearch();
            ProductSearch();
        }

        private void cboTaxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate_Tax();
        }

        private void cboCreditTaxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate_Tax2();
        }

        private void dgvReceivedInvoices_CellClick(object sender, EventArgs e)
        {
            btnUpdateSupplierInvoice.Visible = true;
            btnDeleteSupplierInvoice.Visible = true;
            int SupplierInvoiceID = Conversions.ToInteger(dgvReceivedInvoices["SupplierInvoiceID", dgvReceivedInvoices.CurrentRow.Index].Value);
            var dt = App.DB.SupplierInvoices.Order_GetSupplierInvoice(SupplierInvoiceID).ToTable();
            DateTime SupplierInvoiceDate = default;
            if (!Information.IsDBNull(dt.Rows[0]["SupplierInvoiceDate"]))
                SupplierInvoiceDate = Conversions.ToDate(dt.Rows[0]["SupplierInvoiceDate"]);
            if (SupplierInvoiceDate == default)
            {
                // chkInvoiceSupInvDateNANew.Checked = True
                dtpSupplierInvoiceDateNew.Value = DateAndTime.Now;
            }
            else
            {
                // chkInvoiceSupInvDateNANew.Checked = False
                dtpSupplierInvoiceDateNew.Value = SupplierInvoiceDate;
            }

            string SupplierInvoiceRef = null;
            if (!Information.IsDBNull(dt.Rows[0]["SupplierInvoiceReference"]))
                SupplierInvoiceRef = Conversions.ToString(dt.Rows[0]["SupplierInvoiceReference"]);
            txtSupplierInvoiceRefNew.Text = SupplierInvoiceRef;
            string ExtraRef = null;
            if (!Information.IsDBNull(dt.Rows[0]["ExtraRef"]))
                ExtraRef = Conversions.ToString(dt.Rows[0]["ExtraRef"]);
            txtExtraReferenceNew.Text = ExtraRef;
            string NominalCode = null;
            if (!Information.IsDBNull(dt.Rows[0]["NominalCode"]))
                NominalCode = Conversions.ToString(dt.Rows[0]["NominalCode"]);
            txtNominalCodeNew.Text = NominalCode;
            double SupplierInvoiceGoods = default;
            if (!Information.IsDBNull(dt.Rows[0]["SupplierGoodsAmount"]))
                SupplierInvoiceGoods = Conversions.ToDouble(dt.Rows[0]["SupplierGoodsAmount"]);
            txtTotalAmount.Text = Strings.Format(SupplierInvoiceGoods, "C");
            double SupplierInvoiceVAT = default;
            if (!Information.IsDBNull(dt.Rows[0]["SupplierVATAmount"]))
                SupplierInvoiceVAT = Conversions.ToDouble(dt.Rows[0]["SupplierVATAmount"]);
            txtVATAmount.Text = Strings.Format(SupplierInvoiceVAT, "C");
            double SupplierInvoiceTotal = default;
            if (!Information.IsDBNull(dt.Rows[0]["SupplierInvoiceAmount"]))
                SupplierInvoiceTotal = Conversions.ToDouble(dt.Rows[0]["SupplierInvoiceAmount"]);
            txtGoodsAmount.Text = Strings.Format(SupplierInvoiceTotal, "C");
            cboInvoiceTaxCodeNew.SelectedValue = null;
            if (!Information.IsDBNull(dt.Rows[0]["TaxCodeID"]))
            {
                var argcombo = cboInvoiceTaxCodeNew;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(dt.Rows[0]["TaxCodeID"]));
            }

            cboInvoiceTaxCodeNew.SelectedValue = dt.Rows[0]["TaxCodeID"];
            if (!App.IsGasway)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dt.Rows[0]["RequiresAuthorisation"], true, false) & Operators.ConditionalCompareObjectEqual(dt.Rows[0]["Authorised"], true, false) | Operators.ConditionalCompareObjectEqual(dt.Rows[0]["RequiresAuthorisation"], false, false)))
                {
                    cboReadySageNew.Enabled = true;
                }
                else
                {
                    cboReadySageNew.Enabled = false;
                }
            }

            btnAddSupplierInvoice.Text = "New";
            if (Conversions.ToBoolean(dt.Rows[0]["SentToSage"]) == true)
            {
                dtpSupplierInvoiceDateNew.Enabled = false;
                txtSupplierInvoiceRefNew.ReadOnly = true;
                txtExtraReferenceNew.ReadOnly = true;
                txtNominalCodeNew.ReadOnly = true;
                txtGoodsAmount.ReadOnly = true;
                txtVATAmount.ReadOnly = true;
                txtTotalAmount.ReadOnly = true;
                cboInvoiceTaxCodeNew.Enabled = false;
                btnUpdateSupplierInvoice.Enabled = false;
                btnDeleteSupplierInvoice.Enabled = false;
            }
            else
            {
                dtpSupplierInvoiceDateNew.Enabled = true;
                txtSupplierInvoiceRefNew.ReadOnly = false;
                txtExtraReferenceNew.ReadOnly = false;
                txtNominalCodeNew.ReadOnly = false;
                txtGoodsAmount.ReadOnly = false;
                txtVATAmount.ReadOnly = false;
                txtTotalAmount.ReadOnly = false;
                cboInvoiceTaxCodeNew.Enabled = true;
                btnUpdateSupplierInvoice.Enabled = true;
                btnDeleteSupplierInvoice.Enabled = true;
            }
        }

        private void dgCredits_CellClick(object sender, EventArgs e)
        {
            btnCreditAdd.Visible = true;
            btnCreditDelete.Visible = true;
            if (dgCredits["DateReceived", dgCredits.CurrentRow.Index].Value.ToString().Length == 0)
            {
            }
            else
            {
                int CreditID = Conversions.ToInteger(dgCredits["PartCreditsID", dgCredits.CurrentRow.Index].Value);
                var dt = App.DB.PartsToBeCredited.PartsToBeCredited_Get_Parts_For_CreditID(CreditID).Table;
                DateTime SupplierInvoiceDate = default;
                if (!Information.IsDBNull(dt.Rows[0]["DateReceived"]))
                    SupplierInvoiceDate = Conversions.ToDate(dt.Rows[0]["DateReceived"]);
                if (SupplierInvoiceDate == default)
                {
                    // chkInvoiceSupInvDateNANew.Checked = True
                    dtpCreditDate.Value = DateAndTime.Now;
                }
                else
                {
                    // chkInvoiceSupInvDateNANew.Checked = False
                    dtpCreditDate.Value = SupplierInvoiceDate;
                }

                string SupplierInvoiceRef = null;
                if (!Information.IsDBNull(dt.Rows[0]["SupplierCreditRef"]))
                    SupplierInvoiceRef = Conversions.ToString(dt.Rows[0]["SupplierCreditRef"]);
                txtCreditRef.Text = SupplierInvoiceRef;
                string ExtraRef = null;
                if (!Information.IsDBNull(dt.Rows[0]["ExtraRef"]))
                    ExtraRef = Conversions.ToString(dt.Rows[0]["ExtraRef"]);
                txtCreditExRef.Text = ExtraRef;
                string NominalCode = null;
                if (!Information.IsDBNull(dt.Rows[0]["NominalCode"]))
                    NominalCode = Conversions.ToString(dt.Rows[0]["NominalCode"]);
                txtCreditNominal.Text = NominalCode;
                cboCreditTax.SelectedValue = null;
                if (!Information.IsDBNull(dt.Rows[0]["TaxCodeID"]))
                {
                    var argcombo = cboCreditTax;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(dt.Rows[0]["TaxCodeID"]));
                }

                cboCreditTax.SelectedValue = dt.Rows[0]["TaxCodeID"];
                double SupplierInvoiceGoods = default;
                if (!Information.IsDBNull(dt.Rows[0]["AmountReceived"]))
                    SupplierInvoiceGoods = Conversions.ToDouble(dt.Rows[0]["AmountReceived"]);
                txtCreditGoods.Text = Strings.Format(SupplierInvoiceGoods, "C");
                // / (1 + (DB.Picklists.Get_One_As_Object(Combo.GetSelectedItemValue(Me.cboCreditTax)).PercentageRate / 100))

                Calculate_Tax2();
                if (Information.IsDBNull(dt.Rows[0]["DateExportedToSage"]) == false)
                {
                    dtpCreditDate.Enabled = false;
                    // chkInvoiceSupInvDateNANew.Enabled = False
                    txtCreditRef.ReadOnly = true;
                    txtCreditExRef.ReadOnly = true;
                    txtCreditNominal.ReadOnly = true;
                    txtCreditGoods.ReadOnly = true;
                    txtCreditVAT.ReadOnly = true;
                    txtCreditTotal.ReadOnly = true;
                    cboCreditTax.Enabled = false;
                    btnCreditAdd.Enabled = false;
                    btnCreditDelete.Enabled = false;
                }
                else
                {
                    dtpCreditDate.Enabled = true;
                    // chkInvoiceSupInvDateNANew.Enabled = False
                    txtCreditRef.ReadOnly = false;
                    txtCreditExRef.ReadOnly = false;
                    txtCreditNominal.ReadOnly = false;
                    txtCreditGoods.ReadOnly = false;
                    txtCreditVAT.ReadOnly = false;
                    txtCreditTotal.ReadOnly = false;
                    cboCreditTax.Enabled = true;
                    btnCreditAdd.Enabled = true;
                    btnCreditDelete.Enabled = true;
                }
            }
        }

        private void btnAddSupplierInvoice_Click(object sender, EventArgs e)
        {
            if (CurrentOrder.OrderTypeID == 0)
            {
                App.ShowMessage("You must save your order details before continuing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((btnAddSupplierInvoice.Text ?? "") == "New")
            {
                btnAddSupplierInvoice.Text = "Add";
                dtpSupplierInvoiceDateNew.Value = DateAndTime.Now;
                txtSupplierInvoiceRefNew.Text = null;
                txtExtraReferenceNew.Text = null;
                txtNominalCodeNew.Text = null;
                txtGoodsAmount.Text = null;
                txtVATAmount.Text = null;
                txtTotalAmount.Text = null;
                var argcombo = cboInvoiceTaxCodeNew;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, null);
                cboReadySageNew.Checked = false;
                dtpSupplierInvoiceDateNew.Enabled = true;
                txtSupplierInvoiceRefNew.ReadOnly = false;
                txtExtraReferenceNew.ReadOnly = false;
                txtNominalCodeNew.ReadOnly = false;
                txtGoodsAmount.ReadOnly = false;
                txtVATAmount.ReadOnly = false;
                txtTotalAmount.ReadOnly = false;
                cboInvoiceTaxCodeNew.Enabled = true;
                cboReadySageNew.Enabled = true;
            }
            else if (ValidateSupplierInvoice())
            {
                var oSupplierInvoice = new Entity.Orders.SupplierInvoice();
                oSupplierInvoice.SetOrderID = CurrentOrder.OrderID;
                oSupplierInvoice.SetInvoiceReference = txtSupplierInvoiceRefNew.Text;
                oSupplierInvoice.SetInvoiceDate = dtpSupplierInvoiceDateNew.Value;
                oSupplierInvoice.SetGoodsAmount = Strings.Replace(txtTotalAmount.Text, "£", "");
                oSupplierInvoice.SetVATAmount = Strings.Replace(txtVATAmount.Text, "£", "");
                oSupplierInvoice.SetTotalAmount = Strings.Replace(txtGoodsAmount.Text, "£", "");
                oSupplierInvoice.SetTaxCodeID = Combo.get_GetSelectedItemValue(cboInvoiceTaxCodeNew);
                oSupplierInvoice.SetNominalCode = txtNominalCodeNew.Text;
                oSupplierInvoice.SetExtraRef = txtExtraReferenceNew.Text;
                oSupplierInvoice.SetReadyToSendToSage = cboReadySageNew.Checked;
                oSupplierInvoice.SetSentToSage = 0;
                oSupplierInvoice.SetOldSystemInvoice = 0;
                oSupplierInvoice.SetDateExported = null;
                oSupplierInvoice.SetKeyedBy = App.loggedInUser.UserID;
                try
                {
                    App.DB.SupplierInvoices.Insert(oSupplierInvoice);
                }
                catch (Exception ex)
                {
                    App.ShowMessage("An error has occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshDataGrids();
                PopulateOrderTotal();
                txtSupplierInvoiceRefNew.Text = null;
                txtExtraReferenceNew.Text = null;
                txtNominalCodeNew.Text = null;
                txtGoodsAmount.Text = null;
                txtVATAmount.Text = null;
                txtTotalAmount.Text = null;
                var argcombo1 = cboInvoiceTaxCodeNew;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, null);
            }
        }

        private void btnCreditAdd_Click(object sender, EventArgs e)
        {
            if ((btnCreditAdd.Text ?? "") == "New")
            {
                btnCreditAdd.Text = "Add";
                dtpCreditDate.Value = DateAndTime.Now;
                txtCreditRef.Text = null;
                txtCreditExRef.Text = null;
                txtCreditNominal.Text = null;
                txtCreditGoods.Text = null;
                txtCreditVAT.Text = null;
                txtCreditTotal.Text = null;
                var argcombo = cboCreditTax;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, null);
                dtpCreditDate.Enabled = true;
                txtCreditRef.ReadOnly = false;
                txtCreditExRef.ReadOnly = false;
                txtCreditNominal.ReadOnly = false;
                txtCreditGoods.ReadOnly = false;
                txtCreditVAT.ReadOnly = false;
                txtCreditTotal.ReadOnly = false;
                cboCreditTax.Enabled = true;
            }
            else if (ValidateCreditInvoice())
            {
                var dv = new DataView();
                using (var f = new FRMPartsForCreditList(CurrentOrder.OrderID, false, true))
                {
                    f.ShowDialog();
                    dv = f.RatesDataview;
                }

                var dtc = new DataTable();
                var oCredit = new Entity.PartsToBeCrediteds.PartsToBeCredited();
                if (dv.Table.Select("tick = 1 AND QtyToCredit > 0").Length > 0)
                {
                    foreach (DataRow r in dv.Table.Select("tick = 1 AND QtyToCredit > 0"))
                    {
                        oCredit = new Entity.PartsToBeCrediteds.PartsToBeCredited();
                        oCredit.SetOrderID = CurrentOrder.OrderID;
                        oCredit.SetOrderReference = CurrentOrder.OrderReference;
                        oCredit.SetPartID = r["PartProductID"];
                        oCredit.SetQty = r["QtyToCredit"];
                        oCredit.SetCreditReceived = Conversions.ToDouble(txtCreditGoods.Text.Replace("£", ""));
                        oCredit.SetStatusID = 3;
                        oCredit.SetSupplierID = SupplierUsedID;
                        oCredit.SetPartOrderID = r["ID"];  // orderpartid
                        dtc = App.DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(Conversions.ToInteger(r["ID"])).Table;
                        if (dtc.Rows.Count > 0 && !Information.IsDBNull(dtc.Rows[0]["CreditReceived"])) // Update  there are rows but we havent allocated the credit yet
                        {
                            oCredit.SetPartsToBeCreditedID = dtc.Rows[0]["PartsToBeCreditedID"];
                            App.DB.PartsToBeCredited.Update(oCredit);
                        }
                        else // Insert they may be rows but we already adddeda  credit for that add a new line
                        {
                            oCredit = App.DB.PartsToBeCredited.Insert(oCredit);
                        }

                        // insert the credit?

                    }

                    if (dtc.Rows.Count == 0 || !Information.IsDBNull(dtc.Rows[0]["CreditReceived"]))  // if there are no credits against this order for this part or there is but already has a credit allocated - add a new line
                    {
                        int partcreditsID = App.DB.PartsToBeCredited.PartCredits_Insert(Conversions.ToDouble(txtCreditGoods.Text.Replace("£", "")), "", dtpCreditDate.Value, DateTime.MinValue, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboCreditTax)), txtCreditNominal.Text, CurrentOrder.DepartmentRef, txtCreditExRef.Text, txtCreditRef.Text);
                        App.DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" + partcreditsID + "," + oCredit.PartsToBeCreditedID + ")");
                    }
                    else
                    {
                        App.DB.PartsToBeCredited.PartCredits_Update(Conversions.ToInteger(dtc.Rows[0]["PartCreditsID"]), Conversions.ToDouble(txtCreditGoods.Text), "", dtpCreditDate.Value, DateTime.MinValue, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboCreditTax)), txtCreditNominal.Text, CurrentOrder.DepartmentRef, txtCreditExRef.Text, txtCreditRef.Text);
                    }

                    RefreshDataGrids();
                    PopulateOrderTotal();
                }
            }
        }

        private void btnUpdateSupplierInvoice_Click(object sender, EventArgs e)
        {
            if (ValidateSupplierInvoice(true))
            {
                var oSupplierInvoice = new Entity.Orders.SupplierInvoice();
                oSupplierInvoice.SetOrderID = CurrentOrder.OrderID;
                oSupplierInvoice.SetInvoiceReference = txtSupplierInvoiceRefNew.Text;
                oSupplierInvoice.SetInvoiceDate = dtpSupplierInvoiceDateNew.Value;
                oSupplierInvoice.SetGoodsAmount = Strings.Replace(txtTotalAmount.Text, "£", "");
                oSupplierInvoice.SetVATAmount = Strings.Replace(txtVATAmount.Text, "£", "");
                oSupplierInvoice.SetTotalAmount = Strings.Replace(txtGoodsAmount.Text, "£", "");
                oSupplierInvoice.SetTaxCodeID = Combo.get_GetSelectedItemValue(cboInvoiceTaxCodeNew);
                oSupplierInvoice.SetNominalCode = txtNominalCodeNew.Text;
                oSupplierInvoice.SetExtraRef = txtExtraReferenceNew.Text;
                oSupplierInvoice.SetReadyToSendToSage = cboReadySageNew.Checked;
                oSupplierInvoice.SetSentToSage = 0;
                oSupplierInvoice.SetOldSystemInvoice = 0;
                oSupplierInvoice.SetDateExported = null;
                oSupplierInvoice.SetKeyedBy = App.loggedInUser.UserID;
                int SupplierInvoiceID = Conversions.ToInteger(dgvReceivedInvoices["SupplierInvoiceID", dgvReceivedInvoices.CurrentRow.Index].Value);
                oSupplierInvoice.SetInvoiceID = SupplierInvoiceID;
                try
                {
                    App.DB.SupplierInvoices.Update(oSupplierInvoice);
                }
                catch (Exception ex)
                {
                    App.ShowMessage("An error has occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dtpSupplierInvoiceDateNew.Value = DateAndTime.Now;
                txtSupplierInvoiceRefNew.Text = null;
                txtExtraReferenceNew.Text = null;
                txtNominalCodeNew.Text = null;
                txtGoodsAmount.Text = null;
                txtVATAmount.Text = null;
                txtTotalAmount.Text = null;
                var argcombo = cboInvoiceTaxCodeNew;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, null);
                cboReadySageNew.Checked = false;
                RefreshDataGrids();
                PopulateOrderTotal();
            }
        }

        private void btnDeleteSupplierInvoice_Click(object sender, EventArgs e)
        {
            int SupplierInvoiceID = Conversions.ToInteger(dgvReceivedInvoices["SupplierInvoiceID", dgvReceivedInvoices.CurrentRow.Index].Value);
            App.DB.SupplierInvoices.Delete(SupplierInvoiceID);
            dtpSupplierInvoiceDateNew.Value = DateAndTime.Now;
            txtSupplierInvoiceRefNew.Text = null;
            txtExtraReferenceNew.Text = null;
            txtNominalCodeNew.Text = null;
            txtGoodsAmount.Text = null;
            txtVATAmount.Text = null;
            txtTotalAmount.Text = null;
            var argcombo = cboInvoiceTaxCodeNew;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, null);
            cboReadySageNew.Checked = false;
            RefreshDataGrids();
            PopulateOrderTotal();
            btnAddSupplierInvoice.Text = "Add";
        }

        private void btnDeleteCredit_Click(object sender, EventArgs e)
        {
            int CreditID = 0;
            if (Information.IsDBNull(dgCredits["PartCreditsID", dgCredits.CurrentRow.Index].Value))
            {
            }
            else
            {
                CreditID = Conversions.ToInteger(dgCredits["PartCreditsID", dgCredits.CurrentRow.Index].Value);
            }

            int OrderPartID = 0;
            if (Information.IsDBNull(dgCredits["OrderPartID", dgCredits.CurrentRow.Index].Value))
            {
            }
            else
            {
                OrderPartID = Conversions.ToInteger(dgCredits["OrderPartID", dgCredits.CurrentRow.Index].Value);
            }

            int partCreditId = 0;
            if (Information.IsDBNull(dgCredits["PartsToBeCreditedID", dgCredits.CurrentRow.Index].Value))
            {
            }
            else
            {
                partCreditId = Conversions.ToInteger(dgCredits["PartsToBeCreditedID", dgCredits.CurrentRow.Index].Value);
            }

            if (partCreditId > 0)
            {
                App.DB.ExecuteScalar("Delete From tblPartstobeCredited where PartsToBeCreditedID = " + partCreditId);
            }
            else if (CreditID > 0)
            {
                App.DB.PartsToBeCredited.Delete(CreditID);
            }
            else if (OrderPartID > 0)
            {
                App.DB.ExecuteScalar("Delete From tblPartstobeCredited where OrderPartID = " + OrderPartID);
                App.DB.ExecuteScalar("Delete From tblPArtDistributed Where OrderPartID = " + OrderPartID);
                App.DB.ExecuteScalar("UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 0,CreditQty = 0 WHERE ORDERPARTID = " + OrderPartID);
            }

            dtpCreditDate.Value = DateAndTime.Now;
            txtCreditRef.Text = null;
            txtCreditExRef.Text = null;
            txtCreditNominal.Text = null;
            txtCreditGoods.Text = null;
            txtCreditVAT.Text = null;
            txtCreditTotal.Text = null;
            var argcombo = cboCreditTax;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, null);
            RefreshDataGrids();
            PopulateOrderTotal();
        }

        private void cboPartLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PartsDataView is object)
            {
                PartsDataView.Table.Rows.Clear();
            }

            UpdatePartSearchOptions();
        }

        private void btnAddNewPart_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMPart), true, new object[] { 0, true });
            PartSearch();
        }

        private void btnPartSearch_Click(object sender, EventArgs e)
        {
            PartSearch();
        }

        private void dgParts_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedPartDataRow is object)
            {
                if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.CreateParts))
                {
                    bool isPartPack = Helper.MakeBooleanValid(SelectedPartDataRow["IsPartPack"]);
                    if (isPartPack)
                    {
                        App.ShowForm(typeof(FRMPartPack), true, new object[] { Helper.MakeIntegerValid(SelectedPartDataRow["PartID"]), true, true });
                    }
                    else
                    {
                        App.ShowForm(typeof(FRMPart), true, new object[] { Helper.MakeIntegerValid(SelectedPartDataRow["PartID"]), true });
                    }
                }
            }
        }

        private void dgParts_Click(object sender, EventArgs e)
        {
            UpdatePartSearchOptions();
            if (SelectedPartDataRow is null)
            {
                return;
            }

            var switchExpr = Combo.get_GetSelectedItemValue(cboPartLocation);
            switch (switchExpr)
            {
                case var @case when @case == Conversions.ToString(Enums.LocationType.Van):
                    {
                        txtPartQuantity.Text = 1.ToString();
                        txtPartQuantity.ReadOnly = false;
                        txtPartBuyPrice.Text = "N/A";
                        txtPartBuyPrice.ReadOnly = true;
                        btnAddPart.Enabled = true;
                        btnCreatePartRequest.Enabled = false;
                        break;
                    }

                case var case1 when case1 == Conversions.ToString(Enums.LocationType.Warehouse):
                    {
                        txtPartQuantity.Text = 1.ToString();
                        txtPartQuantity.ReadOnly = false;
                        txtPartBuyPrice.Text = "N/A";
                        txtPartBuyPrice.ReadOnly = true;
                        btnAddPart.Enabled = true;
                        btnCreatePartRequest.Enabled = false;
                        break;
                    }

                case var case2 when case2 == Conversions.ToString(Enums.LocationType.Supplier):
                    {
                        bool isPartPack = Helper.MakeBooleanValid(SelectedPartDataRow["IsPartPack"]);
                        txtPartBuyPrice.Enabled = !isPartPack;
                        txtPartQuantity.Text = "1";
                        txtPartQuantity.ReadOnly = false;
                        if (Information.IsDBNull(SelectedPartDataRow["SupplierID"]))
                        {
                            txtPartBuyPrice.Text = "N/A";
                            txtPartBuyPrice.ReadOnly = true;
                            btnAddPart.Enabled = false;
                        }
                        else
                        {
                            txtPartBuyPrice.Text = Strings.Format(SelectedPartDataRow["Price"], "F");
                            txtPartBuyPrice.ReadOnly = false;
                            btnAddPart.Enabled = true;
                        }

                        btnCreatePartRequest.Enabled = true;
                        break;
                    }
            }
        }

        private void AddPartToOrder()
        {
            var oOrderPart = new Entity.OrderParts.OrderPart();
            oOrderPart.IgnoreExceptionsOnSetMethods = true;
            oOrderPart.SetOrderID = CurrentOrder.OrderID;
            oOrderPart.SetPartSupplierID = SelectedPartDataRow["PartSupplierID"];
            int partid = Conversions.ToInteger(SelectedPartDataRow["PartID"]);
            bool isSpecialPart = Helper.MakeBooleanValid(SelectedPartDataRow["IsSpecialPart"]);
            if (isSpecialPart)
            {
                var f = new FRMSpecialOrder(Conversions.ToInteger(SelectedPartDataRow["PartSupplierID"]), Conversions.ToDouble(txtPartBuyPrice.Text.Trim()), Conversions.ToInteger(txtPartQuantity.Text.Trim()));
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    oOrderPart.SetQuantity = f.Quantity;
                    oOrderPart.SetBuyPrice = f.Price;
                    oOrderPart.SetSpecialDescription = f.PartName;
                    oOrderPart.SetSpecialPartNumber = f.SPN;
                }
                else
                {
                    return;
                }
            }
            else
            {
                oOrderPart.SetQuantity = txtPartQuantity.Text.Trim();
                oOrderPart.SetBuyPrice = txtPartBuyPrice.Text.Trim();
            }

            oOrderPart.SetQuantityReceived = 0;
            oOrderPart.SetChildSupplierID = 0;
            int warehouseID = 0;
            foreach (DataRow row in App.DB.Part.Stock_Get_Locations(partid).Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], "WAREHOUSE", false)))
                {
                    if (Conversions.ToBoolean(row["Quantity"] >= oOrderPart.Quantity))
                    {
                        warehouseID = Conversions.ToInteger(row["WarehouseID"]);
                        break;
                    }
                }
            }

            if (!(warehouseID == 0))
            {
                if (App.ShowMessage("There is stock available in a warehouse, would you like to still order from supplier?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    var argcombo = cboPartLocation;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToInteger(Enums.LocationType.Warehouse).ToString());
                    PartSearch();
                    int index = 0;
                    foreach (DataRow row in PartsDataView.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["WarehouseID"], warehouseID, false) & Operators.ConditionalCompareObjectEqual(row["PartID"], partid, false)))
                        {
                            break;
                        }
                        else
                        {
                            index += 1;
                        }
                    }

                    dgParts.CurrentRowIndex = index;
                    dgParts.Select(index);
                    dgParts_Click(null, null);
                    txtPartQuantity.Text = oOrderPart.Quantity.ToString();
                    return;
                }
            }

            var val = new Entity.OrderParts.OrderPartValidator();
            val.Validate(oOrderPart);
            oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !CurrentOrder.DoNotConsolidated);
            if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.Job)
            {
                App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Part", oOrderPart.Quantity, oOrderPart.OrderPartID, Conversions.ToInteger(SelectedPartDataRow["PartID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPartLocation)));
            }

            SupplierUsedID = Conversions.ToInteger(SelectedPartDataRow["SupplierID"]);
            LocationUsedID = 0;
        }

        private void AddPackToOrder()
        {
            int qty = Helper.MakeIntegerValid(txtPartQuantity.Text);
            if (qty == 0)
                return;
            int supplierId = Helper.MakeIntegerValid(SelectedPartDataRow["SupplierID"]);
            int packId = Helper.MakeIntegerValid(SelectedPartDataRow["PartID"]);
            var dvPartPack = App.DB.Part.PartPack_Get(packId);
            foreach (DataRowView drPart in dvPartPack)
            {
                int partId = Helper.MakeIntegerValid(drPart["PartID"]);
                var dvPartSupplier = App.DB.PartSupplier.Get_ByPartIDAndSupplierID(partId, supplierId);
                if (dvPartSupplier.Count == 0)
                    continue;
                var oOrderPart = new Entity.OrderParts.OrderPart();
                oOrderPart.IgnoreExceptionsOnSetMethods = true;
                oOrderPart.SetOrderID = CurrentOrder.OrderID;
                oOrderPart.SetPartSupplierID = Helper.MakeIntegerValid(dvPartSupplier[0]["PartSupplierID"]);
                oOrderPart.SetQuantity = qty * Helper.MakeIntegerValid(drPart["Qty"]);
                oOrderPart.SetBuyPrice = Helper.MakeDoubleValid(dvPartSupplier[0]["Price"]);
                oOrderPart.SetQuantityReceived = 0;
                oOrderPart.SetChildSupplierID = 0;
                var val = new Entity.OrderParts.OrderPartValidator();
                val.Validate(oOrderPart);
                oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !CurrentOrder.DoNotConsolidated);
                if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.Job)
                {
                    App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Part", oOrderPart.Quantity, oOrderPart.OrderPartID, partId, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPartLocation)));
                }
            }

            SupplierUsedID = supplierId;
            LocationUsedID = 0;
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Enums.SecuritySystemModules ssm;
                ssm = Enums.SecuritySystemModules.CreatePO;
                Enums.SecuritySystemModules ssm2;
                ssm2 = Enums.SecuritySystemModules.EditPO;
                if (App.loggedInUser.HasAccessToModule(ssm) == true | App.loggedInUser.HasAccessToModule(ssm2) == true)
                {
                    var switchExpr = Combo.get_GetSelectedItemValue(cboPartLocation);
                    switch (switchExpr)
                    {
                        case var @case when @case == Conversions.ToString(Enums.LocationType.Supplier):
                            {
                                bool isPartPack = Helper.MakeBooleanValid(SelectedPartDataRow["IsPartPack"]);
                                if (isPartPack)
                                {
                                    AddPackToOrder();
                                }
                                else
                                {
                                    AddPartToOrder();
                                }

                                break;
                            }

                        case var case1 when case1 == Conversions.ToString(Enums.LocationType.Van):
                            {
                                var oOrderLocationPart = new Entity.OrderLocationPart.OrderLocationPart();
                                oOrderLocationPart.IgnoreExceptionsOnSetMethods = true;
                                oOrderLocationPart.SetOrderID = CurrentOrder.OrderID;
                                oOrderLocationPart.SetPartID = SelectedPartDataRow["PartID"];
                                oOrderLocationPart.SetLocationID = SelectedPartDataRow["LocationID"];
                                oOrderLocationPart.SetQuantity = txtPartQuantity.Text.Trim();
                                oOrderLocationPart.SetQuantityReceived = 0;
                                var val = new Entity.OrderLocationPart.OrderLocationPartValidator();
                                val.Validate(oOrderLocationPart);
                                oOrderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, true);
                                if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.Job)
                                {
                                    App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Part", oOrderLocationPart.Quantity, oOrderLocationPart.OrderLocationPartID, Conversions.ToInteger(SelectedPartDataRow["PartID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPartLocation)));
                                }

                                var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                oPartTransaction.IgnoreExceptionsOnSetMethods = true;
                                oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID;
                                oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockReserve);
                                oPartTransaction.SetPartID = oOrderLocationPart.PartID;
                                oPartTransaction.SetAmount = -oOrderLocationPart.Quantity;
                                oPartTransaction.SetLocationID = oOrderLocationPart.LocationID;
                                oPartTransaction = App.DB.PartTransaction.Insert(oPartTransaction);
                                LocationUsedID = oOrderLocationPart.LocationID;
                                SupplierUsedID = 0;
                                break;
                            }

                        case var case2 when case2 == Conversions.ToString(Enums.LocationType.Warehouse):
                            {
                                var oOrderLocationPart = new Entity.OrderLocationPart.OrderLocationPart();
                                oOrderLocationPart.IgnoreExceptionsOnSetMethods = true;
                                oOrderLocationPart.SetOrderID = CurrentOrder.OrderID;
                                oOrderLocationPart.SetPartID = SelectedPartDataRow["PartID"];
                                oOrderLocationPart.SetLocationID = SelectedPartDataRow["LocationID"];
                                oOrderLocationPart.SetQuantity = txtPartQuantity.Text.Trim();
                                oOrderLocationPart.SetQuantityReceived = 0;
                                var val = new Entity.OrderLocationPart.OrderLocationPartValidator();
                                val.Validate(oOrderLocationPart);
                                oOrderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, true);
                                if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.Job)
                                {
                                    App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Part", oOrderLocationPart.Quantity, oOrderLocationPart.OrderLocationPartID, Conversions.ToInteger(SelectedPartDataRow["PartID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPartLocation)));
                                }

                                var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                oPartTransaction.IgnoreExceptionsOnSetMethods = true;
                                oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID;
                                oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockReserve);
                                oPartTransaction.SetPartID = oOrderLocationPart.PartID;
                                oPartTransaction.SetAmount = -oOrderLocationPart.Quantity;
                                oPartTransaction.SetLocationID = oOrderLocationPart.LocationID;
                                oPartTransaction = App.DB.PartTransaction.Insert(oPartTransaction);
                                LocationUsedID = oOrderLocationPart.LocationID;
                                SupplierUsedID = 0;
                                break;
                            }
                    }

                    IsLoading = true;
                    CurrentOrder = App.DB.Order.Order_Get(CurrentOrder.OrderID);
                    RefreshDataGrids();
                    PartSearch();
                }
                else
                {
                    string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Part could not be added." + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cboProductLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductsDataView is object)
            {
                ProductsDataView.Table.Rows.Clear();
            }

            UpdateProductSearchOptions();
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMProduct), true, new object[] { 0, true });
            ProductSearch();
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            ProductSearch();
        }

        private void dgProduct_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedProductDataRow is object)
            {
                App.ShowForm(typeof(FRMProduct), true, new object[] { Helper.MakeIntegerValid(SelectedProductDataRow["ProductID"]), true });
                ProductSearch();
            }
        }

        private void dgProduct_Click(object sender, EventArgs e)
        {
            UpdateProductSearchOptions();
            if (SelectedProductDataRow is null)
            {
                return;
            }

            var switchExpr = Combo.get_GetSelectedItemValue(cboProductLocation);
            switch (switchExpr)
            {
                case var @case when @case == Conversions.ToString(Enums.LocationType.Van):
                    {
                        txtProductQuantity.Text = 1.ToString();
                        txtProductQuantity.ReadOnly = false;
                        txtProductBuyPrice.Text = "N/A";
                        txtProductBuyPrice.ReadOnly = true;
                        if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.StockProfile | CurrentOrder.OrderTypeID == (int)Enums.OrderType.Warehouse)
                        {
                            txtProductSellPrice.Text = "N/A";
                            txtProductSellPrice.ReadOnly = true;
                        }
                        else
                        {
                            txtProductSellPrice.Text = Strings.Format(SelectedProductDataRow["SellPrice"], "F");
                            txtProductSellPrice.ReadOnly = false;
                        }

                        btnAddProduct.Enabled = true;
                        btnCreateProductPriceRequest.Enabled = false;
                        break;
                    }

                case var case1 when case1 == Conversions.ToString(Enums.LocationType.Warehouse):
                    {
                        txtProductQuantity.Text = 1.ToString();
                        txtProductQuantity.ReadOnly = false;
                        txtProductBuyPrice.Text = "N/A";
                        txtProductBuyPrice.ReadOnly = true;
                        if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.StockProfile | CurrentOrder.OrderTypeID == (int)Enums.OrderType.Warehouse)
                        {
                            txtProductSellPrice.Text = "N/A";
                            txtProductSellPrice.ReadOnly = true;
                        }
                        else
                        {
                            txtProductSellPrice.Text = Strings.Format(SelectedProductDataRow["SellPrice"], "F");
                            txtProductSellPrice.ReadOnly = false;
                        }

                        btnAddProduct.Enabled = true;
                        btnCreateProductPriceRequest.Enabled = false;
                        break;
                    }

                case var case2 when case2 == Conversions.ToString(Enums.LocationType.Supplier):
                    {
                        txtProductQuantity.Text = "1";
                        txtProductQuantity.ReadOnly = false;
                        if (Information.IsDBNull(SelectedProductDataRow["SupplierID"]))
                        {
                            txtProductBuyPrice.Text = "N/A";
                            txtProductBuyPrice.ReadOnly = true;
                            txtProductSellPrice.Text = "N/A";
                            txtProductSellPrice.ReadOnly = true;
                            btnAddProduct.Enabled = false;
                        }
                        else
                        {
                            txtProductBuyPrice.Text = Strings.Format(SelectedProductDataRow["Price"], "F");
                            txtProductBuyPrice.ReadOnly = false;
                            if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.StockProfile | CurrentOrder.OrderTypeID == (int)Enums.OrderType.Warehouse)
                            {
                                txtProductSellPrice.Text = "N/A";
                                txtProductSellPrice.ReadOnly = true;
                            }
                            else
                            {
                                txtProductSellPrice.Text = "";
                                txtProductSellPrice.ReadOnly = false;
                            }

                            btnAddProduct.Enabled = true;
                        }

                        btnCreateProductPriceRequest.Enabled = true;
                        break;
                    }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Enums.SecuritySystemModules ssm;
                ssm = Enums.SecuritySystemModules.EditPO;
                Enums.SecuritySystemModules ssm2;
                ssm2 = Enums.SecuritySystemModules.CreatePO;
                if (App.loggedInUser.HasAccessToModule(ssm) == true | App.loggedInUser.HasAccessToModule(ssm2) == true)
                {
                    var switchExpr = Combo.get_GetSelectedItemValue(cboProductLocation);
                    switch (switchExpr)
                    {
                        case var @case when @case == Conversions.ToString(Enums.LocationType.Supplier):
                            {
                                var oOrderProduct = new Entity.OrderProducts.OrderProduct();
                                oOrderProduct.IgnoreExceptionsOnSetMethods = true;
                                oOrderProduct.SetOrderID = CurrentOrder.OrderID;
                                oOrderProduct.SetProductSupplierID = SelectedProductDataRow["ProductSupplierID"];
                                oOrderProduct.SetQuantity = txtProductQuantity.Text.Trim();
                                oOrderProduct.SetBuyPrice = txtProductBuyPrice.Text.Trim();
                                if (txtProductSellPrice.ReadOnly)
                                {
                                    oOrderProduct.SetSellPrice = 0.0;
                                }
                                else
                                {
                                    oOrderProduct.SetSellPrice = txtProductSellPrice.Text.Trim();
                                }

                                oOrderProduct.SetQuantityReceived = 0;
                                int warehouseID = 0;
                                int productID = Conversions.ToInteger(SelectedProductDataRow["ProductID"]);
                                foreach (DataRow row in App.DB.Product.Stock_Get_Locations(productID).Table.Rows)
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], "WAREHOUSE", false)))
                                    {
                                        if (Conversions.ToBoolean(row["Quantity"] >= oOrderProduct.Quantity))
                                        {
                                            warehouseID = Conversions.ToInteger(row["WarehouseID"]);
                                            break;
                                        }
                                    }
                                }

                                if (!(warehouseID == 0))
                                {
                                    if (App.ShowMessage("There is stock available in a warehouse, would you like to still order from supplier?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        var argcombo = cboProductLocation;
                                        Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToInteger(Enums.LocationType.Warehouse).ToString());
                                        ProductSearch();
                                        int index = 0;
                                        foreach (DataRow row in ProductsDataView.Table.Rows)
                                        {
                                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["WarehouseID"], warehouseID, false) & Operators.ConditionalCompareObjectEqual(row["ProductID"], productID, false)))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                index += 1;
                                            }
                                        }

                                        dgProduct.CurrentRowIndex = index;
                                        dgProduct.Select(index);
                                        dgProduct_Click(null, null);
                                        txtProductQuantity.Text = oOrderProduct.Quantity.ToString();
                                        return;
                                    }
                                }

                                var val = new Entity.OrderProducts.OrderProductValidator();
                                val.Validate(oOrderProduct);
                                oOrderProduct = App.DB.OrderProduct.Insert(oOrderProduct, true);
                                if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.Job)
                                {
                                    App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Product", oOrderProduct.Quantity, oOrderProduct.OrderProductID, Conversions.ToInteger(SelectedProductDataRow["ProductID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboProductLocation)));
                                }

                                SupplierUsedID = Conversions.ToInteger(SelectedProductDataRow["SupplierID"]);
                                LocationUsedID = 0;
                                break;
                            }

                        case var case1 when case1 == Conversions.ToString(Enums.LocationType.Van):
                            {
                                var oOrderLocationProduct = new Entity.OrderLocationProduct.OrderLocationProduct();
                                oOrderLocationProduct.IgnoreExceptionsOnSetMethods = true;
                                oOrderLocationProduct.SetOrderID = CurrentOrder.OrderID;
                                oOrderLocationProduct.SetProductID = SelectedProductDataRow["ProductID"];
                                oOrderLocationProduct.SetLocationID = SelectedProductDataRow["LocationID"];
                                oOrderLocationProduct.SetQuantity = txtProductQuantity.Text.Trim();
                                if (txtProductSellPrice.ReadOnly)
                                {
                                    oOrderLocationProduct.SetSellPrice = 0.0;
                                }
                                else
                                {
                                    oOrderLocationProduct.SetSellPrice = txtProductSellPrice.Text.Trim();
                                }

                                oOrderLocationProduct.SetQuantityReceived = 0;
                                var val = new Entity.OrderLocationProduct.OrderLocationProductValidator();
                                val.Validate(oOrderLocationProduct);
                                oOrderLocationProduct = App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, true);
                                if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.Job)
                                {
                                    App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Product", oOrderLocationProduct.Quantity, oOrderLocationProduct.OrderLocationProductID, Conversions.ToInteger(SelectedProductDataRow["ProductID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboProductLocation)));
                                }

                                var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                                oProductTransaction.IgnoreExceptionsOnSetMethods = true;
                                oProductTransaction.SetOrderLocationProductID = oOrderLocationProduct.OrderLocationProductID;
                                oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockReserve);
                                oProductTransaction.SetProductID = oOrderLocationProduct.ProductID;
                                oProductTransaction.SetAmount = -oOrderLocationProduct.Quantity;
                                oProductTransaction.SetLocationID = oOrderLocationProduct.LocationID;
                                oProductTransaction = App.DB.ProductTransaction.Insert(oProductTransaction);
                                SupplierUsedID = 0;
                                LocationUsedID = oOrderLocationProduct.LocationID;
                                break;
                            }

                        case var case2 when case2 == Conversions.ToString(Enums.LocationType.Warehouse):
                            {
                                var oOrderLocationProduct = new Entity.OrderLocationProduct.OrderLocationProduct();
                                oOrderLocationProduct.IgnoreExceptionsOnSetMethods = true;
                                oOrderLocationProduct.SetOrderID = CurrentOrder.OrderID;
                                oOrderLocationProduct.SetProductID = SelectedProductDataRow["ProductID"];
                                oOrderLocationProduct.SetLocationID = SelectedProductDataRow["LocationID"];
                                oOrderLocationProduct.SetQuantity = txtProductQuantity.Text.Trim();
                                if (txtProductSellPrice.ReadOnly)
                                {
                                    oOrderLocationProduct.SetSellPrice = 0.0;
                                }
                                else
                                {
                                    oOrderLocationProduct.SetSellPrice = txtProductSellPrice.Text.Trim();
                                }

                                oOrderLocationProduct.SetQuantityReceived = 0;
                                var val = new Entity.OrderLocationProduct.OrderLocationProductValidator();
                                val.Validate(oOrderLocationProduct);
                                oOrderLocationProduct = App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, true);
                                if (CurrentOrder.OrderTypeID == (int)Enums.OrderType.Job)
                                {
                                    App.DB.EngineerVisitPartProductAllocated.InsertOne(Conversions.ToInteger(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]), "Product", oOrderLocationProduct.Quantity, oOrderLocationProduct.OrderLocationProductID, Conversions.ToInteger(SelectedProductDataRow["ProductID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboProductLocation)));
                                }

                                var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                                oProductTransaction.IgnoreExceptionsOnSetMethods = true;
                                oProductTransaction.SetOrderLocationProductID = oOrderLocationProduct.OrderLocationProductID;
                                oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockReserve);
                                oProductTransaction.SetProductID = oOrderLocationProduct.ProductID;
                                oProductTransaction.SetAmount = -oOrderLocationProduct.Quantity;
                                oProductTransaction.SetLocationID = oOrderLocationProduct.LocationID;
                                oProductTransaction = App.DB.ProductTransaction.Insert(oProductTransaction);
                                SupplierUsedID = 0;
                                LocationUsedID = oOrderLocationProduct.LocationID;
                                break;
                            }
                    }

                    RefreshDataGrids();
                    ProductSearch();
                }
                else
                {
                    string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Product could not be added." + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtPartSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                PartSearch();
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtProductSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                ProductSearch();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnItemRemove_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Enums.SecuritySystemModules ssm;
                ssm = Enums.SecuritySystemModules.EditPO;
                Enums.SecuritySystemModules ssm2;
                ssm2 = Enums.SecuritySystemModules.CreatePO;
                if (App.loggedInUser.HasAccessToModule(ssm) == true | App.loggedInUser.HasAccessToModule(ssm2) == true)
                {
                    if (SelectedItemIncludedDataRow is null)
                    {
                        App.ShowMessage("Please select an item to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (nudItemQty.Value == 0)
                    {
                        if (App.ShowMessage("Completely remove item?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    if (Conversions.ToBoolean(SelectedItemIncludedDataRow["QuantityReceived"] > 0))
                    {
                        // ShowMessage("Items have been recieved. Quantity cannot be ammended!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        // Exit Sub
                    }

                    var switchExpr = Conversions.ToString(SelectedItemIncludedDataRow["Type"]);
                    switch (switchExpr)
                    {
                        case "OrderProduct":
                            {
                                var oOrderProduct = new Entity.OrderProducts.OrderProduct();
                                oOrderProduct = App.DB.OrderProduct.OrderProduct_Get(Conversions.ToInteger(SelectedItemIncludedDataRow["ID"]));
                                if (nudItemQty.Value == 0)
                                {
                                    App.DB.OrderProduct.Delete(oOrderProduct.OrderProductID);
                                }
                                else
                                {
                                    oOrderProduct.SetQuantity = nudItemQty.Value;
                                    App.DB.OrderProduct.Update(oOrderProduct);
                                }

                                break;
                            }
                        // 'IF ITS A JOB ORDER REMOVE THE PARTS FROM THE JOB ALLOCATION
                        // If CurrentOrder.OrderTypeID = CInt(Entity.Sys.Enums.OrderType.Job) Then
                        // DB.EngineerVisitPartProductAllocated.EngineerVisitProductAllocated_Delete(CInt(Entity.Sys.Enums.LocationType.Supplier), oOrderProduct.OrderProductID)
                        // End If
                        // *************************************************************
                        case "OrderPart":
                            {
                                var oOrderPart = new Entity.OrderParts.OrderPart();
                                oOrderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(SelectedItemIncludedDataRow["ID"]));
                                if (nudItemQty.Value == 0)
                                {
                                    App.DB.OrderPart.Delete(oOrderPart.OrderPartID);
                                }
                                else
                                {
                                    oOrderPart.SetQuantity = nudItemQty.Value;
                                    App.DB.OrderPart.Update(oOrderPart);
                                }
                                // IF ITS A JOB ORDER REMOVE THE PARTS FROM THE JOB ALLOCATION
                                if (CurrentOrder.OrderTypeID == Conversions.ToInteger(Enums.OrderType.Job))
                                {
                                    // DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_Delete(CInt(Entity.Sys.Enums.LocationType.Supplier), oOrderPart.OrderPartID)
                                    App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_RemoveFromOrder(Conversions.ToInteger(Enums.LocationType.Supplier), oOrderPart.OrderPartID);
                                }

                                break;
                            }
                        // *************************************************************
                        case "OrderLocationProduct":
                            {
                                var oOrderLocationProduct = new Entity.OrderLocationProduct.OrderLocationProduct();
                                oOrderLocationProduct = App.DB.OrderLocationProduct.OrderLocationProduct_Get(Conversions.ToInteger(SelectedItemIncludedDataRow["ID"]));
                                var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                                oProductTransaction = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(oOrderLocationProduct.OrderLocationProductID);
                                if (nudItemQty.Value == 0)
                                {
                                    App.DB.OrderLocationProduct.Delete(oOrderLocationProduct.OrderLocationProductID);
                                    App.DB.ProductTransaction.Delete(oProductTransaction.ProductTransactionID);
                                }
                                else
                                {
                                    oOrderLocationProduct.SetQuantity = nudItemQty.Value;
                                    App.DB.OrderLocationProduct.Update(oOrderLocationProduct);
                                    oProductTransaction.SetAmount = nudItemQty.Value;
                                    App.DB.ProductTransaction.Update(oProductTransaction);
                                }
                                // IF ITS A JOB ORDER REMOVE THE PARTS FROM THE JOB ALLOCATION
                                if (CurrentOrder.OrderTypeID == Conversions.ToInteger(Enums.OrderType.Job))
                                {
                                    App.DB.EngineerVisitPartProductAllocated.EngineerVisitProductAllocated_Delete(Conversions.ToInteger(Enums.LocationType.Warehouse), oOrderLocationProduct.OrderLocationProductID);
                                }

                                break;
                            }
                        // *************************************************************
                        case "OrderLocationPart":
                            {
                                var oOrderLocationPart = new Entity.OrderLocationPart.OrderLocationPart();
                                oOrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get(Conversions.ToInteger(SelectedItemIncludedDataRow["ID"]));
                                var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                oPartTransaction = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(oOrderLocationPart.OrderLocationPartID);
                                if (nudItemQty.Value == 0)
                                {
                                    App.DB.OrderLocationPart.Delete(oOrderLocationPart.OrderLocationPartID);
                                    App.DB.PartTransaction.Delete(oPartTransaction.PartTransactionID);
                                }
                                else
                                {
                                    oOrderLocationPart.SetQuantity = nudItemQty.Value;
                                    App.DB.OrderLocationPart.Update(oOrderLocationPart);
                                    oPartTransaction.SetAmount = nudItemQty.Value;
                                    App.DB.PartTransaction.Update(oPartTransaction);
                                }

                                // IF ITS A JOB ORDER REMOVE THE PARTS FROM THE JOB ALLOCATION
                                if (CurrentOrder.OrderTypeID == Conversions.ToInteger(Enums.OrderType.Job))
                                {
                                    App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_RemoveFromOrder(Conversions.ToInteger(Enums.LocationType.Warehouse), oOrderLocationPart.OrderLocationPartID);
                                    // DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_Delete(CInt(Entity.Sys.Enums.LocationType.Warehouse), oOrderLocationPart.OrderLocationPartID)
                                }

                                break;
                            }
                            // *************************************************************
                    }

                    if (isOrderCancelled() & CurrentOrder.OrderStatusID > Conversions.ToInteger(Enums.OrderStatus.AwaitingConfirmation))
                    {
                        CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Cancelled);
                        App.DB.Order.Update(CurrentOrder);

                        // IS THIS ON A CONSOLIDATED
                        if (CurrentOrder.OrderConsolidationID > 0)
                        {
                            bool allCancelled = true;
                            // CHECK AND CANCEL Consolidated order if nessary
                            foreach (DataRow drOrd in App.DB.OrderConsolidations.Order_GetForConsolidationByID(CurrentOrder.OrderConsolidationID, 0, 0).Table.Rows)
                            {
                                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(drOrd["OrderStatusID"], Conversions.ToInteger(Enums.OrderStatus.Cancelled), false)))
                                {
                                    allCancelled = false;
                                    break;
                                }
                            }

                            if (allCancelled)
                            {
                                var oConOrder = App.DB.OrderConsolidations.OrderConsolidation_Get(CurrentOrder.OrderConsolidationID);
                                oConOrder.SetConsolidatedOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Cancelled);
                                App.DB.OrderConsolidations.Update(oConOrder);
                            }
                        }

                        IsLoading = true;
                        Populate(CurrentOrder.OrderID);
                        IsLoading = false;
                        return;
                    }

                    if (isOrderComplete() == true)
                    {
                        if (CurrentOrder.OrderStatusID > Conversions.ToInteger(Enums.OrderStatus.AwaitingConfirmation))
                        {
                            CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Complete);
                            App.DB.Order.Update(CurrentOrder);

                            // IS THIS ON A CONSOLIDATED
                            if (CurrentOrder.OrderConsolidationID > 0)
                            {
                                bool allComplete = true;
                                // CHECK AND COMPLETE Consolidated order if nessary
                                foreach (DataRow drOrd in App.DB.OrderConsolidations.Order_GetForConsolidationByID(CurrentOrder.OrderConsolidationID, 0, 0).Table.Rows)
                                {
                                    if (Conversions.ToBoolean(drOrd["OrderStatusID"] < Conversions.ToInteger(Enums.OrderStatus.Complete)))
                                    {
                                        allComplete = false;
                                        break;
                                    }
                                }

                                if (allComplete)
                                {
                                    var oConOrder = App.DB.OrderConsolidations.OrderConsolidation_Get(CurrentOrder.OrderConsolidationID);
                                    oConOrder.SetConsolidatedOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Complete);
                                    App.DB.OrderConsolidations.Update(oConOrder);
                                }
                            }

                            IsLoading = true;
                            Populate(CurrentOrder.OrderID);
                            IsLoading = false;
                        }

                        if (CurrentOrder.OrderTypeID == Conversions.ToInteger(Enums.OrderType.Job))
                        {
                            var oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(ucJobOrder.SelectedEngineerVisitDataRow["EngineerVisitID"]));
                            if (oEngineerVisit.StatusEnumID == Conversions.ToInteger(Enums.VisitStatus.Waiting_For_Parts))
                            {

                                // LETS SEE FIRST IF ALL THE ORDERS RELATING TO THIS VISIT ARE COMPLETE? - ALP 22/01/08
                                var dv = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(oEngineerVisit.EngineerVisitID);
                                bool allComplete = true;
                                foreach (DataRow dr in dv.Table.Rows)
                                {
                                    if (!(Helper.MakeIntegerValid(dr["OrderStatusID"]) == 0))
                                    {
                                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(dr["OrderStatusID"], Conversions.ToInteger(Enums.OrderStatus.Complete), false)))
                                        {
                                            allComplete = false;
                                        }
                                    }
                                }

                                if (allComplete)
                                {
                                    if (App.ShowMessage("The visit this order relates to is waiting for parts. Would you like to set the status of the visit to Ready To Schedule?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        oEngineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule);
                                        oEngineerVisit.SetPartsToFit = true;
                                        App.DB.EngineerVisits.Update(oEngineerVisit, 0, true);
                                    }
                                }
                            }
                        }

                        // IF ORDER IS COMPLETE AND ITS A CUSTOMER ORDER THEN ADD ROW TO RAISE INVOICE TABLE
                        if ((Enums.OrderType)Conversions.ToInteger(CurrentOrder.OrderTypeID) == Enums.OrderType.Customer)
                        {
                            App.ShowForm(typeof(FrmRaiseInvoiceDetails), true, new object[] { CurrentOrder.OrderID, CurrentOrder.InvoiceAddressID });
                        }
                    }

                    PartSearch();
                    ProductSearch();
                    RefreshDataGrids();
                }
                else
                {
                    string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Item cannot be removed." + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                nudItemQty.Value = 0;
                Cursor = Cursors.Default;
            }
        }

        private void dgItemsIncluded_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedItemIncludedDataRow is null)
            {
                return;
            }

            if (CurrentOrder.OrderConsolidationID > 0)
            {
                if ((Conversions.ToString(SelectedItemIncludedDataRow["Type"]) ?? "") == "OrderPart" | (Conversions.ToString(SelectedItemIncludedDataRow["Type"]) ?? "") == "OrderProduct")
                {
                    App.ShowMessage("This order has been added to a consolidation so should be managed from there.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (!(CurrentOrder.OrderStatusID == Conversions.ToInteger(Enums.OrderStatus.Confirmed)))
            {
                App.ShowMessage("Order must be confirmed to mark items into stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Conversions.ToInteger(SelectedItemIncludedDataRow["QuantityOnOrder"]) == Conversions.ToInteger(SelectedItemIncludedDataRow["QuantityReceived"]))
            {
                App.ShowMessage("This stock has been fully received", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            App.ShowForm(typeof(FRMReceiveStock), true, new object[] { CurrentOrder.OrderID, Conversions.ToString(SelectedItemIncludedDataRow["Type"]), Conversions.ToInteger(SelectedItemIncludedDataRow["ID"]) });
            Populate(CurrentOrder.OrderID);
            if (isOrderComplete() == true)
            {
                if (CurrentOrder.OrderStatusID > Conversions.ToInteger(Enums.OrderStatus.AwaitingConfirmation))
                {
                    CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Complete);
                    App.DB.Order.Update(CurrentOrder);
                    IsLoading = true;
                    Populate(CurrentOrder.OrderID);
                    IsLoading = false;
                }

                if (CurrentOrder.OrderTypeID == Conversions.ToInteger(Enums.OrderType.Job))
                {
                    var oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(ucJobOrder.SelectedEngineerVisitDataRow["EngineerVisitID"]));
                    if (oEngineerVisit.StatusEnumID == Conversions.ToInteger(Enums.VisitStatus.Waiting_For_Parts))
                    {

                        // LETS SEE FIRST IF ALL THE ORDERS RELATING TO THIS VISIT ARE COMPLETE? - ALP 22/01/08
                        var dv = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(oEngineerVisit.EngineerVisitID);
                        bool allComplete = true;
                        foreach (DataRow dr in dv.Table.Rows)
                        {
                            if (!(Helper.MakeIntegerValid(dr["OrderStatusID"]) == 0))
                            {
                                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(dr["OrderStatusID"], Conversions.ToInteger(Enums.OrderStatus.Complete), false)))
                                {
                                    allComplete = false;
                                }
                            }
                        }

                        if (allComplete)
                        {
                            App.ShowForm(typeof(FRMPickDespatchDetails), true, new object[] { oEngineerVisit });
                        }
                    }
                }

                // IF ORDER IS COMPLETE AND ITS A CUSTOMER ORDER THEN ADD ROW TO RAISE INVOICE TABLE
                if ((Enums.OrderType)Conversions.ToInteger(CurrentOrder.OrderTypeID) == Enums.OrderType.Customer)
                {
                    App.ShowForm(typeof(FrmRaiseInvoiceDetails), true, new object[] { CurrentOrder.OrderID, CurrentOrder.InvoiceAddressID });
                }
            }
        }

        private void dgItemsIncluded_Click(object sender, EventArgs e)
        {
            if (SelectedItemIncludedDataRow is null)
            {
                return;
            }

            nudItemQty.Value = Conversions.ToInteger(SelectedItemIncludedDataRow["QuantityOnOrder"]);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public bool ValidateSupplierInvoice(bool Update = false)
        {
            string Errors = "Please correct the following error(s):" + Constants.vbNewLine;
            bool NoError = true;
            if (txtSupplierInvoiceRefNew.Text == default)
            {
                Errors += "- 'Invoice Ref' cannot be empty." + Constants.vbNewLine;
                NoError = false;
            }

            if (txtNominalCodeNew.Text == default)
            {
                Errors += "- 'Nominal Code' cannot be empty." + Constants.vbNewLine;
                NoError = false;
            }

            if (txtGoodsAmount.Text == default | (Strings.Format(txtGoodsAmount.Text, "C") ?? "") == "£0.00")
            {
                Errors += "- 'Goods' cannot be empty and must not equals 0." + Constants.vbNewLine;
                NoError = false;
            }

            if (txtVATAmount.Text == default)
            {
                Errors += "- 'VAT' cannot be empty." + Constants.vbNewLine;
                NoError = false;
            }

            if (txtTotalAmount.Text == default | (Strings.Format(txtTotalAmount.Text, "C") ?? "") == "£0.00")
            {
                Errors += "- 'Total' cannot be empty and must not equals 0." + Constants.vbNewLine;
                NoError = false;
            }

            if (NoError == false)
            {
                App.ShowMessage(Errors, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (NoError)
            {
                double itemAmount = 0.0;
                double invoiceTotal = 0.0;
                foreach (DataRow row in ItemsIncludedDataView.Table.Rows)
                    itemAmount += row["BuyPrice"] * row["QuantityOnOrder"];
                // PLUS ADDITIONAL
                foreach (DataRow row in App.DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID).Table.Rows)
                    itemAmount += row["Amount"];

                // GET EXISTING SUPPLIER INVOICES
                foreach (DataRow row in App.DB.SupplierInvoices.Order_GetSupplierInvoices(CurrentOrder.OrderID).Table.Rows)
                    invoiceTotal += row["SupplierInvoiceAmount"];
                double CurrentTotal = 0;
                if (Update)
                {
                    double UpdateingAmount = Conversions.ToDouble(Strings.Replace(Conversions.ToString(dgvReceivedInvoices["SupplierInvoiceAmount", dgvReceivedInvoices.CurrentRow.Index].Value), "£", ""));
                    CurrentTotal = invoiceTotal - UpdateingAmount + Conversions.ToDouble(Strings.Replace(txtGoodsAmount.Text, "£", "")) - 0.05;
                }
                else
                {
                    CurrentTotal = invoiceTotal + Conversions.ToDouble(Strings.Replace(txtGoodsAmount.Text, "£", "")) - 0.05;
                }

                if (CurrentTotal > Conversions.ToDouble(Strings.Format(itemAmount, "F")))
                {
                    App.ShowMessage("The entered supplier invoice amount is greater than the total of the order. You will now be prompted to enter the override password to continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!App.EnterOverridePassword())
                    {
                        return false;
                    }
                }
            }

            return NoError;
        }

        public bool ValidateCreditInvoice(bool Update = false)
        {
            string Errors = "Please correct the following error(s):" + Constants.vbNewLine;
            bool NoError = true;
            if (txtCreditRef.Text == default)
            {
                Errors += "- 'Invoice Ref' cannot be empty." + Constants.vbNewLine;
                NoError = false;
            }

            if (txtCreditNominal.Text == default)
            {
                Errors += "- 'Nominal Code' cannot be empty." + Constants.vbNewLine;
                NoError = false;
            }

            if (txtCreditGoods.Text == default | (Strings.Format(txtCreditGoods.Text, "C") ?? "") == "£0.00")
            {
                Errors += "- 'Goods' cannot be empty and must not equals 0." + Constants.vbNewLine;
                NoError = false;
            }

            if (txtCreditVAT.Text == default)
            {
                Errors += "- 'VAT' cannot be empty." + Constants.vbNewLine;
                NoError = false;
            }

            if (NoError == false)
            {
                App.ShowMessage(Errors, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (NoError)
            {
                double itemAmount = 0.0;
                double invoiceTotal = 0.0;
                double CurrentTotal = 0;
            }

            return NoError;
        }

        private void Populate(int ID = 0)
        {
            btnEngineerReceived.Visible = false;
            if (!(ID == 0))
            {
                CurrentOrder = App.DB.Order.Order_Get(ID);
            }

            dtpDatePlaced.Value = CurrentOrder.DatePlaced;
            txtOrderReference.Text = CurrentOrder.OrderReference;
            if (CurrentOrder.DeliveryDeadline == default)
            {
                chkDeadlineNA.Checked = true;
            }
            else
            {
                dtpDeliveryDeadline.Value = CurrentOrder.DeliveryDeadline;
                chkDeadlineNA.Checked = false;
            }

            var argcombo = cboDept;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentOrder.DepartmentRef);
            var argcombo1 = cboOrderTypeID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentOrder.OrderTypeID.ToString());
            var argcombo2 = cboOrderStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentOrder.OrderStatusID.ToString());
            chkDoNotConsolidate.Checked = CurrentOrder.DoNotConsolidated;
            var switchExpr = CurrentOrder.OrderStatusID;
            switch (switchExpr)
            {
                case (int)Enums.OrderStatus.Confirmed:
                case (int)Enums.OrderStatus.AwaitingApproval:
                    {
                        DisableFields();
                        btnCharges.Enabled = true;
                        lblOrderStatus.Text = "ORDER WAITING FOR ITEMS RECEIVED";
                        lblOrderStatus.Visible = true;
                        btnPrint.Enabled = !(CurrentOrder.OrderStatusID == (int)Enums.OrderStatus.AwaitingApproval);
                        btnApproveOrder.Visible = CurrentOrder.OrderStatusID == (int)Enums.OrderStatus.AwaitingApproval && App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.POAuthorisation);
                        break;
                    }

                case (int)Enums.OrderStatus.Cancelled:
                    {
                        DisableFields();
                        btnCharges.Enabled = false;
                        lblOrderStatus.Text = "ORDER HAS BEEN CANCELLED (click to view)";
                        lblOrderStatus.Visible = true;
                        break;
                    }

                case (int)Enums.OrderStatus.Complete:
                    {
                        DisableFields();
                        btnCharges.Enabled = false;
                        lblOrderStatus.Text = "ORDER COMPLETE";
                        lblOrderStatus.Visible = true;
                        if (CurrentOrder.ExportedToSage)
                        {
                            lblOrderStatus.Text += " - (Invoiced and Sent to Sage)";
                        }
                        else if (CurrentOrder.Invoiced)
                        {
                            lblOrderStatus.Text += " - (Invoiced)";
                        }

                        break;
                    }

                case (int)Enums.OrderStatus.AwaitingConfirmation:
                    {
                        lblOrderStatus.Text = "ORDER AWAITING CONFIRMATION FROM CUSTOMER";
                        lblOrderStatus.Visible = true;
                        break;
                    }
            }

            RefreshDataGrids();
            btnUpdateOrderRef.Visible = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance);
            var switchExpr1 = CurrentOrder.OrderTypeID;
            switch (switchExpr1)
            {
                case (int)Enums.OrderType.Customer:
                    {
                        ucCustomerOrder.Customer = App.DB.Customer.Customer_GetForOrder(CurrentOrder.OrderID);
                        var oSiteOrder = new Entity.SiteOrders.SiteOrder();
                        oSiteOrder = App.DB.SiteOrder.SiteOrder_GetForOrder(CurrentOrder.OrderID);
                        if (oSiteOrder is null)
                        {
                            ucCustomerOrder.Warehouse = App.DB.Warehouse.Warehouse_GetByLocationID(App.DB.OrderLocation.OrderLocation_GetForOrder(CurrentOrder.OrderID).LocationID);
                        }
                        else
                        {
                            ucCustomerOrder.theProperty = App.DB.Sites.Get(oSiteOrder.SiteID);
                        }

                        CustomerID = ucCustomerOrder.Customer.CustomerID;
                        ucCustomerOrder.Contact = App.DB.Contact.Contact_Get(CurrentOrder.ContactID);
                        ucCustomerOrder.InvoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(CurrentOrder.InvoiceAddressID);
                        var argcombo3 = ucCustomerOrder.cboUsers;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentOrder.AllocatedToUser.ToString());
                        ucCustomerOrder.txtSpecialInstructions.Text = CurrentOrder.SpecialInstructions;
                        btnRelatedJob.Enabled = false;
                        break;
                    }

                case (int)Enums.OrderType.StockProfile:
                    {
                        ucVanOrder.Van = App.DB.Van.Van_Get(PassedID);
                        int deliveryAddressID = App.DB.OrderLocation.OrderLocation_GetForOrder(CurrentOrder.OrderID).DeliveryAddressID;
                        if (!(deliveryAddressID == 0))
                        {
                            ucVanOrder.DeliveryAddress = App.DB.Warehouse.Warehouse_Get(deliveryAddressID);
                        }

                        btnRelatedJob.Enabled = false;
                        btnEngineerReceived.Visible = true;
                        break;
                    }

                case (int)Enums.OrderType.Warehouse:
                    {
                        ucWarehouseOrder.Warehouse = App.DB.Warehouse.Warehouse_Get(PassedID);
                        btnRelatedJob.Enabled = false;
                        break;
                    }

                case (int)Enums.OrderType.Job:
                    {
                        ucJobOrder.EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Get(PassedID);
                        if (ucJobOrder.EngineerVisitsDataView is object & ucJobOrder.EngineerVisitsDataView.Count > 0)
                        {
                            if (ucJobOrder.EngineerVisitsDataView.Table.Columns.Contains("CustomerID") && !Information.IsDBNull(ucJobOrder.EngineerVisitsDataView[0]["CustomerID"]))
                            {
                                CustomerID = Helper.MakeIntegerValid(ucJobOrder.EngineerVisitsDataView[0]["CustomerID"]);
                            }
                        }

                        ucJobOrder.Warehouse = App.DB.Warehouse.Warehouse_Get(App.DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(CurrentOrder.OrderID).WarehouseID);
                        btnRelatedJob.Enabled = true;
                        break;
                    }

                default:
                    {
                        lblOrderStatus.Text = "PICK WHAT THE ORDER IS FOR";
                        lblOrderStatus.Visible = true;
                        break;
                    }
            }

            if (CurrentOrder.OrderConsolidationID == 0)
            {
                lblOrderStatus.Text += " *Supplier Invoice NOT sent to Sage*";
            }
            else if (App.DB.OrderConsolidations.OrderConsolidation_Get(CurrentOrder.OrderConsolidationID).HasSupplierPO)
            {
                // Supplier Invoices
                txtSupplierInvoiceRefNew.ReadOnly = true;
                txtExtraReferenceNew.ReadOnly = true;
                txtNominalCodeNew.ReadOnly = true;
                txtExtraReferenceNew.ReadOnly = true;
                dtpSupplierInvoiceDateNew.Enabled = false;
                cboInvoiceTaxCodeNew.Enabled = false;
                txtNominalCodeNew.ReadOnly = true;
                txtGoodsAmount.ReadOnly = true;
                txtVATAmount.ReadOnly = true;
                txtTotalAmount.ReadOnly = true;
                btnAddSupplierInvoice.Enabled = false;
                cboDept.Enabled = true;
                lblOrderStatus.Text += " *Supplier Invoice managed within consolidation*";
            }
            else
            {
                lblOrderStatus.Text += " *Supplier Invoice NOT sent to Sage*";
            }

            if (isOrderComplete() == true && dgvReceivedInvoices.RowCount > 0)
            {
                chkRevertStatus.Enabled = false;
            }
            // End If
        }

        private void PopulateOrderTotal()
        {
            double total = 0.0;
            foreach (DataRow row in ItemsIncludedDataView.Table.Rows)
                total += row["BuyPrice"] * row["QuantityOnOrder"];
            foreach (DataRow row in App.DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID).Table.Rows)
                total += row["Amount"];
            lblOrderTotal.Text = Strings.Format(total, "C");
            double GoodsTotal = 0.0;
            double VATTotal = 0.0;
            double GrandTotal = 0.0;
            foreach (DataRow row in App.DB.SupplierInvoices.Order_GetSupplierInvoices(CurrentOrder.OrderID).Table.Rows)
            {
                GoodsTotal += row["SupplierInvoiceAmount"];
                VATTotal += row["SupplierVATAmount"];
                GrandTotal += row["SupplierGoodsAmount"];
            }

            lblGoodsTotal.Text = Strings.Format(GoodsTotal, "C");
            lblCredits.Text = "0";
            foreach (DataRow row in App.DB.ExecuteWithReturn("select (AmountReceived) as CreditReceived from tblPartCredits pc inner join (sELECT MAX(tblPartCreditParts.PartsToBeCreditedID) AS MAXIMUN ,PartCreditID  FROM tblPartCreditParts group by PartCreditID) pcp on pcp.PartCreditID = pc.PartCreditsID inner join tblPartsToBeCredited tbc ON tbc.PartsToBeCreditedID = pcp.maximun WHERE OrderID = " + CurrentOrder.OrderID).Rows)
                lblCredits.Text = lblCredits.Text + row["CreditReceived"];
            double OrderBalance = total - GoodsTotal + Conversions.ToDouble(lblCredits.Text);
            lblCredits.Text = Strings.Format(Conversions.ToDouble(lblCredits.Text), "C");
            lblOrderBalance.Text = Strings.Format(OrderBalance, "C");
            var switchExpr = Strings.Format(OrderBalance, "C");
            switch (switchExpr)
            {
                case "£0.00":
                    {
                        lblOrderBalance.ForeColor = Color.Green;
                        break;
                    }

                case object _ when switchExpr < 0:
                    {
                        lblOrderBalance.ForeColor = Color.Red;
                        break;
                    }

                case object _ when switchExpr > 0:
                    {
                        lblOrderBalance.ForeColor = Color.DarkOrange;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private void RefreshDataGrids()
        {
            ItemsIncludedDataView = App.DB.Order.Order_ItemsGetAll(CurrentOrder.OrderID);
            foreach (DataRow row in ItemsIncludedDataView.Table.Rows)
            {
                if (!Information.IsDBNull(row["SupplierID"]))
                {
                    SupplierUsedID = Conversions.ToInteger(row["SupplierID"]);
                    break;
                }
            }

            if (SupplierUsedID > 0)
                txtNominalCodeNew.Text = App.DB.Supplier.Supplier_Get(SupplierUsedID).DefaultNominal;
            PriceRequestDataView = App.DB.Order.Order_PriceRequests_GetAll(CurrentOrder.OrderID);
            dgvReceivedInvoices.DataSource = App.DB.SupplierInvoices.Order_GetSupplierInvoices(CurrentOrder.OrderID);
            dgCredits.DataSource = App.DB.PartsToBeCredited.PartsToBeCredited_Get_OrderID(CurrentOrder.OrderID);
        }

        public void DisableFields()
        {
            // Me.txtOrderReference.Enabled = False
            txtPartBuyPrice.Enabled = false;
            txtPartQuantity.Enabled = false;
            txtPartSearch.Enabled = false;
            txtProductBuyPrice.Enabled = false;
            txtProductQuantity.Enabled = false;
            txtProductSearch.Enabled = false;
            txtProductSellPrice.Enabled = false;
            // Me.txtItemQuantity.Enabled = False
            // Me.btnItemRemove.Enabled = False
            ucVanOrder.Enabled = false;
            ucWarehouseOrder.Enabled = false;
            ucCustomerOrder.btnFindCustomer.Enabled = false;
            ucCustomerOrder.btnFindSite.Enabled = false;
            ucCustomerOrder.btnFindWarehouse.Enabled = false;
            btnAddPart.Enabled = false;
            btnAddProduct.Enabled = false;
            btnPartSearch.Enabled = false;
            btnProductSearch.Enabled = false;
            // Me.btnCharges.Enabled = False
            cboOrderStatus.Enabled = false;
            cboOrderTypeID.Enabled = false;
            cboPartLocation.Enabled = false;
            cboProductLocation.Enabled = false;
            dgParts.Enabled = false;
            dgProduct.Enabled = false;
            var switchExpr = CurrentOrder.OrderStatusID;
            switch (switchExpr)
            {
                case (int)Enums.OrderStatus.Confirmed:
                case (int)Enums.OrderStatus.AwaitingApproval:
                    {
                        txtOrderReference.ReadOnly = true;
                        dtpDatePlaced.Enabled = true;
                        chkDeadlineNA.Enabled = true;
                        break;
                    }

                case (int)Enums.OrderStatus.Cancelled:
                    {
                        txtOrderReference.ReadOnly = true;
                        dtpDatePlaced.Enabled = false;
                        chkDeadlineNA.Enabled = false;
                        break;
                    }

                case (int)Enums.OrderStatus.Complete:
                    {
                        txtOrderReference.ReadOnly = true;
                        dtpDatePlaced.Enabled = false;
                        chkDeadlineNA.Enabled = false;
                        dtpDeliveryDeadline.Enabled = false;
                        break;
                    }

                case (int)Enums.OrderStatus.AwaitingConfirmation:
                    {
                        txtOrderReference.ReadOnly = true;
                        dtpDatePlaced.Enabled = true;
                        chkDeadlineNA.Enabled = true;
                        break;
                    }
            }
        }

        private void EnableTabs(bool Enabled)
        {
            var switchExpr = CurrentOrder.OrderStatusID;
            switch (switchExpr)
            {
                case Conversions.ToInteger(Enums.OrderStatus.Complete):
                    {
                        if (CurrentOrder.OrderTypeID == Conversions.ToInteger(Enums.OrderType.StockProfile))
                        {
                            bool someNotWithEngineer = false;
                            foreach (DataRow itemRow in ItemsIncludedDataView.Table.Rows)
                            {
                                if (Helper.MakeDateTimeValid(itemRow["WithEngineer_Van"]) == default & Helper.MakeDateTimeValid(itemRow["WithEngineer_Job"]) == default)
                                {
                                    someNotWithEngineer = true;
                                    break;
                                }
                            }

                            if (someNotWithEngineer)
                            {
                                // Me.dgItemsIncluded.Enabled = False
                                nudItemQty.Enabled = false;
                                btnItemQtyUpdate.Enabled = false;
                                btnReceiveAll.Enabled = false;
                                btnEngineerReceived.Visible = true;
                            }
                            else
                            {
                                // Me.tabItemsIncluded.Enabled = False
                                dgItemsIncluded.ReadOnly = true;
                                btnItemQtyUpdate.Enabled = false;
                                btnEngineerReceived.Enabled = false;
                                btnReceiveAll.Enabled = false;
                            }
                        }
                        else
                        {
                            // Me.tabItemsIncluded.Enabled = False
                            dgItemsIncluded.ReadOnly = true;
                            btnItemQtyUpdate.Enabled = false;
                            btnEngineerReceived.Enabled = false;
                            btnReceiveAll.Enabled = false;
                        }

                        break;
                    }

                default:
                    {
                        tabItemsIncluded.Enabled = true;
                        break;
                    }
            }

            tabPartPriceReq.Enabled = Enabled;
            tabParts.Enabled = Enabled;
            tabProducts.Enabled = Enabled;
            tabDocuments.Enabled = Enabled;
            ucCustomerOrder.btnFindCustomer.Enabled = !Enabled;
            ucCustomerOrder.btnFindSite.Enabled = !Enabled;
            ucCustomerOrder.btnFindWarehouse.Enabled = !Enabled;
            ucJobOrder.Enabled = !Enabled;
            ucWarehouseOrder.Enabled = !Enabled;
            ucVanOrder.Enabled = !Enabled;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Enums.SecuritySystemModules ssm;
                ssm = Enums.SecuritySystemModules.EditPO;
                Enums.SecuritySystemModules ssm2;
                ssm2 = Enums.SecuritySystemModules.CreatePO;
                if (App.loggedInUser.HasAccessToModule(ssm) == true | App.loggedInUser.HasAccessToModule(ssm2) == true)
                {
                    var oOrder = new Entity.Orders.Order();
                    oOrder.IgnoreExceptionsOnSetMethods = true;
                    oOrder.SetSentToSage = CurrentOrder.SentToSage;
                    var oSite = new Site();
                    Job oJob = null;
                    oSite.Exists = false;

                    // validate a customer/van/warehouse has been selected
                    var switchExpr = Combo.get_GetSelectedItemValue(cboOrderTypeID);
                    switch (switchExpr)
                    {
                        case var @case when @case == Conversions.ToString(Enums.OrderType.Customer):
                            {
                                if (((UCOrderForCustomer)pnlDetails.Controls[0]).Customer is null)
                                {
                                    App.ShowMessage("Please select a Customer this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return false;
                                }

                                if (((UCOrderForCustomer)pnlDetails.Controls[0]).theProperty is null & ((UCOrderForCustomer)pnlDetails.Controls[0]).Warehouse is null)
                                {
                                    App.ShowMessage("Please select a Property/Warehouse this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return false;
                                }

                                oSite = ((UCOrderForCustomer)pnlDetails.Controls[0]).theProperty;
                                break;
                            }

                        case var case1 when case1 == Conversions.ToString(Enums.OrderType.Warehouse):
                            {
                                if (((UCOrderForWarehouse)pnlDetails.Controls[0]).Warehouse is null)
                                {
                                    App.ShowMessage("Please select a Warehouse this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return false;
                                }

                                break;
                            }

                        case var case2 when case2 == Conversions.ToString(Enums.OrderType.StockProfile):
                            {
                                if (((UCOrderForVan)pnlDetails.Controls[0]).Van is null)
                                {
                                    App.ShowMessage("Please select a Van this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return false;
                                }

                                break;
                            }

                        case var case3 when case3 == Conversions.ToString(Enums.OrderType.Job):
                            {
                                if (((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow is null)
                                {
                                    App.ShowMessage("Please select a Visit this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return false;
                                }

                                oSite = App.DB.Sites.Get(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["SiteID"]);
                                if (!CurrentOrder.Exists)
                                {
                                    oJob = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(Helper.MakeIntegerValid(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]));
                                    var dvOrders = App.DB.Order.Orders_GetForJob(oJob.JobID);
                                    dvOrders.RowFilter = "OrderStatus <> 'Cancelled'";
                                    if (dvOrders.Count > 0)
                                    {
                                        var exOrders = new List<string>();
                                        foreach (DataRowView dvRow in dvOrders)
                                            exOrders.Add(Conversions.ToString(Conversions.ToString("Order Ref: " + dvRow["OrderReference"] + ", Supplier: ") + dvRow["Supplier"]));
                                        if (App.ShowMessageWithDetails("Existing Purchase Orders", "The following orders have already been placed against this job." + Constants.vbCrLf + Constants.vbCrLf + "Do you wish to continue?", exOrders) != DialogResult.OK)
                                        {
                                            return false;
                                        }
                                    }

                                    string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDept));
                                    if (Helper.IsValidInteger(department) && !(Helper.MakeIntegerValid(department) <= -1))
                                    {
                                        int cc = GetCostCentre(oJob, oSite);
                                        var argcombo = cboDept;
                                        Combo.SetSelectedComboItem_By_Value(ref argcombo, cc.ToString());
                                    }
                                    else if (!Information.IsNumeric(department))
                                    {
                                        int cc = GetCostCentre(oJob, oSite);
                                        var argcombo1 = cboDept;
                                        Combo.SetSelectedComboItem_By_Value(ref argcombo1, cc.ToString());
                                    }
                                }

                                break;
                            }

                        default:
                            {
                                App.ShowMessage("Please select an order type.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                    }

                    // if we have a site check if user has region permission
                    if (oSite?.Exists == true)
                    {
                        if (App.loggedInUser.UserRegions.Count > 0)
                        {
                            if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + oSite.RegionID).Length < 1)
                            {
                                string msg = "You do not have the necessary security permissions to create a purchase order on this site." + Constants.vbCrLf;
                                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                                throw new System.Security.SecurityException(msg);
                            }
                        }
                        else if (oSite.RegionID != App.loggedInUser.UserID)
                        {
                            string msg = "You do not have the necessary security permissions to create a purchase order on this site." + Constants.vbCrLf;
                            msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                            throw new System.Security.SecurityException(msg);
                        }
                    }

                    oOrder.SetOrderID = CurrentOrder.OrderID;
                    oOrder.DatePlaced = dtpDatePlaced.Value;
                    oOrder.SetOrderTypeID = Combo.get_GetSelectedItemValue(cboOrderTypeID);
                    if (oOrder.UserID == 0)
                        oOrder.SetUserID = App.loggedInUser.UserID;
                    oOrder.SetOrderStatusID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboOrderStatus));
                    if (chkDeadlineNA.Checked)
                    {
                        oOrder.DeliveryDeadline = default;
                    }
                    else
                    {
                        oOrder.DeliveryDeadline = dtpDeliveryDeadline.Value;
                    }

                    oOrder.SupplierInvoiceDate = default;
                    oOrder.SetDepartmentRef = Combo.get_GetSelectedItemValue(cboDept);
                    oOrder.SetDoNotConsolidated = chkDoNotConsolidate.Checked;
                    var switchExpr1 = Combo.get_GetSelectedItemValue(cboOrderTypeID);
                    switch (switchExpr1)
                    {
                        case var case4 when case4 == Conversions.ToString(Enums.OrderType.Customer):
                            {
                                if (((UCOrderForCustomer)pnlDetails.Controls[0]).Contact is null)
                                {
                                    oOrder.SetContactID = 0;
                                }
                                else
                                {
                                    oOrder.SetContactID = ((UCOrderForCustomer)pnlDetails.Controls[0]).Contact.ContactID;
                                }

                                if (((UCOrderForCustomer)pnlDetails.Controls[0]).InvoiceAddress is null)
                                {
                                    oOrder.SetInvoiceAddressID = 0;
                                }
                                else
                                {
                                    oOrder.SetInvoiceAddressID = ((UCOrderForCustomer)pnlDetails.Controls[0]).InvoiceAddress.InvoiceAddressID;
                                }

                                oOrder.SetAllocatedToUser = Combo.get_GetSelectedItemValue(((UCOrderForCustomer)pnlDetails.Controls[0]).cboUsers);
                                oOrder.SetSpecialInstructions = ((UCOrderForCustomer)pnlDetails.Controls[0]).txtSpecialInstructions.Text.Trim();
                                break;
                            }
                    }

                    oOrder.SetOrderReference = txtOrderReference.Text.Trim();
                    var cV = new Entity.Orders.OrderValidator();
                    cV.Validate(oOrder);
                    if (!CurrentOrder.Exists)
                    {
                        oOrder = App.DB.Order.Insert(oOrder);
                        if ((oOrder.OrderReference ?? "") == (OrderNumber.OrderNumber ?? ""))
                        {
                            OrderNumberUsed = true;
                        }

                        var oSiteOrder = new Entity.SiteOrders.SiteOrder();
                        var oCustomerOrder = new Entity.CustomerOrders.CustomerOrder();
                        var oOrderLocation = new Entity.OrderLocations.OrderLocation();
                        var oEngineerVisitOrder = new Entity.EngineerVisitOrders.EngineerVisitOrder();

                        // Insert an order location, this is who/where the order is for
                        var switchExpr2 = oOrder.OrderTypeID;
                        switch (switchExpr2)
                        {
                            case (int)Enums.OrderType.Customer:
                                {
                                    oCustomerOrder.SetCustomerID = ((UCOrderForCustomer)pnlDetails.Controls[0]).Customer.CustomerID;
                                    oCustomerOrder.SetOrderID = oOrder.OrderID;
                                    App.DB.CustomerOrder.DeleteForOrder(oOrder.OrderID);
                                    oCustomerOrder = App.DB.CustomerOrder.Insert(oCustomerOrder);
                                    if (((UCOrderForCustomer)pnlDetails.Controls[0]).theProperty is object)
                                    {
                                        oSiteOrder.SetOrderID = oOrder.OrderID;
                                        oSiteOrder.SetSiteID = ((UCOrderForCustomer)pnlDetails.Controls[0]).theProperty.SiteID;
                                        App.DB.SiteOrder.DeleteByOrder(oOrder.OrderID);
                                        oSiteOrder = App.DB.SiteOrder.Insert(oSiteOrder);
                                        PassedID = oSiteOrder.SiteID;
                                    }
                                    else
                                    {
                                        oOrderLocation.SetOrderID = oOrder.OrderID;
                                        oOrderLocation.SetLocationID = App.DB.Warehouse.Warehouse_GetDV(((UCOrderForCustomer)pnlDetails.Controls[0]).Warehouse.WarehouseID).Table.Rows[0]["LocationID"];
                                        App.DB.OrderLocation.DeleteForOrder(oOrder.OrderID);
                                        oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
                                        PassedID = ((UCOrderForCustomer)pnlDetails.Controls[0]).Warehouse.WarehouseID;
                                    }

                                    break;
                                }

                            case (int)Enums.OrderType.Warehouse:
                                {
                                    oOrderLocation.SetOrderID = oOrder.OrderID;
                                    oOrderLocation.SetLocationID = App.DB.Warehouse.Warehouse_GetDV(((UCOrderForWarehouse)pnlDetails.Controls[0]).Warehouse.WarehouseID).Table.Rows[0]["LocationID"];
                                    App.DB.OrderLocation.DeleteForOrder(oOrder.OrderID);
                                    oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
                                    PassedID = ((UCOrderForWarehouse)pnlDetails.Controls[0]).Warehouse.WarehouseID;
                                    break;
                                }

                            case (int)Enums.OrderType.StockProfile:
                                {
                                    oOrderLocation.SetOrderID = oOrder.OrderID;
                                    oOrderLocation.SetLocationID = Conversions.ToInteger(App.DB.Van.Van_GetDV(((UCOrderForVan)pnlDetails.Controls[0]).Van.VanID).Table.Rows[0]["LocationID"]);
                                    oOrderLocation.SetDeliveryAddressID = ((UCOrderForVan)pnlDetails.Controls[0]).DeliveryAddressID;
                                    App.DB.OrderLocation.DeleteForOrder(oOrder.OrderID);
                                    oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
                                    PassedID = ((UCOrderForVan)pnlDetails.Controls[0]).Van.VanID;
                                    break;
                                }

                            case (int)Enums.OrderType.Job:
                                {
                                    oEngineerVisitOrder.SetOrderID = oOrder.OrderID;
                                    if (((UCOrderForJob)pnlDetails.Controls[0]).Warehouse is object)
                                    {
                                        oEngineerVisitOrder.SetWarehouseID = ((UCOrderForJob)pnlDetails.Controls[0]).Warehouse.WarehouseID;
                                    }

                                    oEngineerVisitOrder.SetEngineerVisitID = ((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"];
                                    App.DB.EngineerVisitOrder.EngineerVisitOrder_DeleteForOrder(oOrder.OrderID);
                                    oEngineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder);
                                    Entity.EngineerVisits.EngineerVisit oEngineerVisit;
                                    oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(oEngineerVisitOrder.EngineerVisitID);
                                    if (oEngineerVisit.StatusEnumID < Conversions.ToInteger(Enums.VisitStatus.Scheduled))
                                    {
                                        oEngineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Waiting_For_Parts);
                                        App.DB.EngineerVisits.Update(oEngineerVisit, 0, true);
                                    }

                                    PassedID = Conversions.ToInteger(((UCOrderForJob)pnlDetails.Controls[0]).SelectedEngineerVisitDataRow["EngineerVisitID"]);
                                    break;
                                }
                        }

                        CurrentOrder = oOrder;
                    }
                    else
                    {
                        Enums.SecuritySystemModules ssm3;
                        ssm3 = Enums.SecuritySystemModules.POUnlock;
                        if (App.loggedInUser.HasAccessToModule(ssm3) == true)
                        {
                            if (chkRevertStatus.Checked == true)
                            {
                                oOrder.SetOrderStatusID = 1;
                                // LoadForm(Me, System.EventArgs)
                                App.DB.Order.Update(oOrder);
                                My.MyProject.Forms.FRMOrder.ResetMe(oOrder.OrderID);
                                cboPartLocation.Enabled = true;
                                txtPartSearch.Enabled = true;
                                btnPartSearch.Enabled = true;
                                txtPartQuantity.Enabled = true;
                                txtPartBuyPrice.Enabled = true;
                                cboProductLocation.Enabled = true;
                                txtProductSearch.Enabled = true;
                                txtProductQuantity.Enabled = true;
                                txtProductBuyPrice.Enabled = true;
                                txtProductSellPrice.Enabled = true;
                                btnProductSearch.Enabled = true;
                                btnItemQtyUpdate.Enabled = true;
                                nudItemQty.Enabled = true;
                                dgParts.Enabled = true;
                                dgProduct.Enabled = true;
                                btnReceiveAll.Enabled = true;
                                chkRevertStatus.Checked = false;
                            }
                            else
                            {
                                App.DB.Order.Update(oOrder);
                            }
                        }
                        // DB.Order.Update(oOrder)
                    }

                    StateChanged?.Invoke(CurrentOrder.OrderID);
                    return true;
                }
                else
                {
                    string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                    return false;
                }
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void PartSearch()
        {
            var switchExpr = Combo.get_GetSelectedItemValue(cboPartLocation);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString():
                    {
                        break;
                    }
                // do nothing
                case var case1 when case1 == Conversions.ToString(Enums.LocationType.Supplier):
                    {
                        if (LocationUsedID == 0)
                        {
                            bool isFlagship = false;
                            var currentCustomer = App.DB.Customer.Customer_Get(CustomerID);
                            isFlagship = currentCustomer is object && currentCustomer.IsPFH;
                            PartsDataView = (DataView)App.DB.PartSupplier.PartSupplier_Search(txtPartSearch.Text, SupplierUsedID, isFlagship);
                        }
                        else
                        {
                            App.ShowMessage("A warehouse/van has been ordered from so no supplier orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case var case2 when case2 == Conversions.ToString(Enums.LocationType.Van):
                    {
                        if (SupplierUsedID == 0)
                        {
                            PartsDataView = App.DB.PartTransaction.SearchByVan(txtPartSearch.Text, LocationUsedID);
                        }
                        else
                        {
                            App.ShowMessage("A supplier has been ordered from so no stock profile can be added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case var case3 when case3 == Conversions.ToString(Enums.LocationType.Warehouse):
                    {
                        if (SupplierUsedID == 0)
                        {
                            PartsDataView = App.DB.PartTransaction.SearchByWarehouse(txtPartSearch.Text, LocationUsedID);
                        }
                        else
                        {
                            App.ShowMessage("A supplier has been ordered from so no warehouse orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }

            UpdatePartSearchOptions();
        }

        private void UpdatePartSearchOptions()
        {
            var switchExpr = Combo.get_GetSelectedItemValue(cboPartLocation);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString():
                    {
                        grpPartSearch.Text = "Part Search From";
                        btnPartSearch.Enabled = false;
                        break;
                    }

                case var case1 when case1 == Conversions.ToString(Enums.LocationType.Supplier):
                    {
                        btnPartSearch.Enabled = true;
                        grpPartSearch.Text = "Search takes place on Part Name, Number (MPN) and Supplier Code (SPN)";
                        break;
                    }

                case var case2 when case2 == Conversions.ToString(Enums.LocationType.Van):
                    {
                        btnPartSearch.Enabled = true;
                        grpPartSearch.Text = "Search takes place on Part Name, Number (MPN), Engineer Name and Stock Profile";
                        break;
                    }

                case var case3 when case3 == Conversions.ToString(Enums.LocationType.Warehouse):
                    {
                        btnPartSearch.Enabled = true;
                        grpPartSearch.Text = "Search takes place on Part Name, Number (MPN) and Warehouse Name";
                        break;
                    }
            }

            // Me.txtPartSearch.Text = ""
            txtPartQuantity.Text = "";
            txtPartQuantity.ReadOnly = true;
            txtPartBuyPrice.Text = "";
            txtPartBuyPrice.ReadOnly = true;
            btnAddPart.Enabled = false;
            btnCreatePartRequest.Enabled = false;
        }

        private void ProductSearch()
        {
            var switchExpr = Combo.get_GetSelectedItemValue(cboProductLocation);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString():
                    {
                        break;
                    }
                // do nothing
                case var case1 when case1 == Conversions.ToString(Enums.LocationType.Supplier):
                    {
                        if (LocationUsedID == 0)
                        {
                            ProductsDataView = (DataView)App.DB.ProductSupplier.ProductSupplier_Search(txtProductSearch.Text, SupplierUsedID);
                        }
                        else
                        {
                            App.ShowMessage("A warehouse/van has been ordered from so no supplier orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case var case2 when case2 == Conversions.ToString(Enums.LocationType.Van):
                    {
                        if (SupplierUsedID == 0)
                        {
                            ProductsDataView = App.DB.ProductTransaction.SearchByVan(txtProductSearch.Text, LocationUsedID);
                        }
                        else
                        {
                            App.ShowMessage("A supplier has been ordered from so no stock profile orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case var case3 when case3 == Conversions.ToString(Enums.LocationType.Warehouse):
                    {
                        if (SupplierUsedID == 0)
                        {
                            ProductsDataView = App.DB.ProductTransaction.SearchByWarehouse(txtProductSearch.Text, LocationUsedID);
                        }
                        else
                        {
                            App.ShowMessage("A supplier has been ordered from so no warehouse orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }

            UpdateProductSearchOptions();
        }

        private void UpdateProductSearchOptions()
        {
            var switchExpr = Combo.get_GetSelectedItemValue(cboProductLocation);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString():
                    {
                        grpProductSearch.Text = "Product Search From";
                        btnProductSearch.Enabled = false;
                        break;
                    }

                case var case1 when case1 == Conversions.ToString(Enums.LocationType.Supplier):
                    {
                        btnProductSearch.Enabled = true;
                        grpProductSearch.Text = "Search takes place on Product Number, Model, Make, Type  and Supplier Code";
                        break;
                    }

                case var case2 when case2 == Conversions.ToString(Enums.LocationType.Van):
                    {
                        btnProductSearch.Enabled = true;
                        grpProductSearch.Text = "Search takes place on Product Number, Model, Make, Type, Engineer Name and stock profile";
                        break;
                    }

                case var case3 when case3 == Conversions.ToString(Enums.LocationType.Warehouse):
                    {
                        btnProductSearch.Enabled = true;
                        grpProductSearch.Text = "Search takes place on Product Number, Model, Make, Type and Warehouse Name";
                        break;
                    }
            }

            // Me.txtProductSearch.Text = ""
            txtProductQuantity.Text = "";
            txtProductQuantity.ReadOnly = true;
            txtProductBuyPrice.Text = "";
            txtProductBuyPrice.ReadOnly = true;
            txtProductSellPrice.Text = "";
            txtProductSellPrice.ReadOnly = true;
            btnAddProduct.Enabled = false;
            btnCreateProductPriceRequest.Enabled = false;
        }

        private void Calculate_Tax()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                txtVATAmount.Text = Strings.Format(Conversions.ToDouble(Strings.Replace(txtGoodsAmount.Text, "£", "")) * (App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboInvoiceTaxCodeNew))).PercentageRate / 100), "C");
                txtTotalAmount.Text = Strings.FormatCurrency(Conversions.ToDouble(Strings.Replace(txtGoodsAmount.Text, "£", "")) + Conversions.ToDouble(Strings.Replace(txtVATAmount.Text, "£", "")));
            }
            catch (Exception ex)
            {
                txtVATAmount.Text = null;
                txtTotalAmount.Text = null;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dgCredits.CurrentRow is object)
            {
                if (dgCredits["DatePartReturned", dgCredits.CurrentRow.Index].Value.ToString().Length > 0)
                {
                    App.ShowMessage("This part has been returned so no, you cant move it to a van.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    var PartsAndProductsDistribution = new DataTable();
                    PartsAndProductsDistribution.Columns.Add("LocationID");
                    PartsAndProductsDistribution.Columns.Add("AllocatedID");
                    PartsAndProductsDistribution.Columns.Add("Other");
                    PartsAndProductsDistribution.Columns.Add("Quantity");
                    PartsAndProductsDistribution.Columns.Add("PartProductID");
                    PartsAndProductsDistribution.Columns.Add("OrderPartProductID");
                    PartsAndProductsDistribution.Columns.Add("StockTransactionType");
                    var frmDistribution = new FRMConvertToVan(false, Conversions.ToInteger(dgCredits["Qty", dgCredits.CurrentRow.Index].Value), Conversions.ToString(dgCredits["PartName", dgCredits.CurrentRow.Index].Value), "Part", Conversions.ToInteger(dgCredits["PartID", dgCredits.CurrentRow.Index].Value), null);
                    if (frmDistribution.ShowDialog() == DialogResult.OK)
                    {
                        foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                        {
                            if (Conversions.ToBoolean(row["Quantity"] > 0))
                            {
                                var r = PartsAndProductsDistribution.NewRow();
                                int allocated = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString("Select EngineerVisitPartAllocatedID From tblEngineervisitPartAllocated Where OrderPartID = " + dgCredits["OrderPartID", dgCredits.CurrentRow.Index].Value)));
                                // r("DistributedID") = 0
                                r["LocationID"] = row["LocationID"];
                                r["AllocatedID"] = allocated;
                                r["Other"] = false;
                                r["Quantity"] = row["Quantity"];
                                r["PartProductID"] = dgCredits["PartID", dgCredits.CurrentRow.Index].Value;
                                r["OrderPartProductID"] = dgCredits["OrderPartID", dgCredits.CurrentRow.Index].Value;
                                r["StockTransactionType"] = Conversions.ToInteger(Enums.Transaction.StockIn);
                                PartsAndProductsDistribution.Rows.Add(r);
                            }
                        }

                        App.DB.Order.AllocatedDistributions(PartsAndProductsDistribution);
                        App.DB.ExecuteScalar(Conversions.ToString("DELETE from tblPartsToBeCredited WHERE OrderPartID = " + dgCredits["OrderPartID", dgCredits.CurrentRow.Index].Value));
                        App.ShowMessage("Moved!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        RefreshDataGrids();
                    }
                }
            }
        }

        private void Calculate_Tax2()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                txtCreditVAT.Text = Strings.Format(Conversions.ToDouble(Strings.Replace(txtCreditGoods.Text, "£", "")) * (App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboCreditTax))).PercentageRate / 100), "C");
                txtCreditTotal.Text = Strings.FormatCurrency(Conversions.ToDouble(Strings.Replace(txtCreditGoods.Text, "£", "")) + Conversions.ToDouble(Strings.Replace(txtCreditVAT.Text, "£", "")));
            }
            catch (Exception ex)
            {
                txtCreditVAT.Text = null;
                txtCreditTotal.Text = null;
            }
        }

        private void btnEngineerReceived_Click(object sender, EventArgs e)
        {
            if (CurrentOrder is null)
            {
                App.ShowMessage("Order must be created first", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!CurrentOrder.Exists)
            {
                App.ShowMessage("Order must be created first", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!(CurrentOrder.OrderTypeID == Conversions.ToInteger(Enums.OrderType.StockProfile)))
            {
                App.ShowMessage("Order must be for a van", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!(CurrentOrder.OrderStatusID == Conversions.ToInteger(Enums.OrderStatus.Complete)))
            {
                App.ShowMessage("Order must be completed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (App.ShowMessage("Are you sure you wish to mark all items as received by engineer?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            foreach (DataRow itemRow in ItemsIncludedDataView.Table.Rows)
            {
                bool continueSave = true;
                if (CurrentOrder.OrderTypeID == Conversions.ToInteger(Enums.OrderType.StockProfile))
                {
                    if (Helper.MakeDateTimeValid(itemRow["WithEngineer_Van"]) != default)
                    {
                        continueSave = false;
                    }
                }
                else if (CurrentOrder.OrderTypeID == Conversions.ToInteger(Enums.OrderType.Job))
                {
                    if (Helper.MakeDateTimeValid(itemRow["WithEngineer_Job"]) != default)
                    {
                        continueSave = false;
                    }
                }

                if (continueSave)
                {
                    int QuantityReceived = Conversions.ToInteger(itemRow["QuantityReceived"]);
                    var switchExpr = Conversions.ToString(itemRow["Type"]);
                    switch (switchExpr)
                    {
                        case "OrderProduct":
                            {
                                break;
                            }
                        // DO NOTHING

                        case "OrderPart":
                            {
                                var OrderPart = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(itemRow["ID"]));
                                var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID);
                                var oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID);
                                var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                oPartTransaction.SetPartID = oPartSupplier.PartID;
                                oPartTransaction.SetOrderPartID = OrderPart.OrderPartID;
                                oPartTransaction.SetAmount = QuantityReceived * oPartSupplier.QuantityInPack;
                                oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
                                App.DB.PartTransaction.Insert(oPartTransaction);
                                App.DB.OrderPart.EngineerReceived(OrderPart.OrderPartID);
                                break;
                            }

                        case "OrderLocationProduct":
                            {
                                break;
                            }
                        // DO NOTHING

                        case "OrderLocationPart":
                            {
                                var OrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get(Conversions.ToInteger(itemRow["ID"]));
                                var oPartTransaction = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(OrderLocationPart.OrderLocationPartID);
                                Entity.OrderLocations.OrderLocation oOrderLocation;
                                oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationPart.OrderID);
                                oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockIn);
                                oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID;
                                oPartTransaction.SetAmount = QuantityReceived;
                                oPartTransaction.SetPartID = OrderLocationPart.PartID;
                                App.DB.PartTransaction.Insert(oPartTransaction);
                                App.DB.OrderLocationPart.EngineerReceived(OrderLocationPart.OrderLocationPartID);
                                break;
                            }
                    }
                }
            }

            Populate(CurrentOrder.OrderID);
        }

        public int GetCostCentre(Job job, Site site)
        {
            var cc = App.DB.CostCentre.Get((int)job?.JobTypeID, (int)site?.CustomerID, Entity.CostCentres.Enums.GetBy.JobTypeIdAndCutomerId)?.FirstOrDefault();
            return cc is object ? cc.CostCentreId : -1;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Email()
        {
            if (CurrentOrder.Exists == true)
            {
                var switchExpr = Combo.get_GetSelectedItemValue(cboPrintType);
                switch (switchExpr)
                {
                    case var @case when @case == Conversions.ToString(Enums.SystemDocumentType.SupplierPurchaseOrder):
                        {
                            var email = new Emails();
                            email.To = "";
                            email.From = App.TheSystem.Configuration.SalesEmailFrom;
                            email.Subject = "Purchase Order";
                            email.Body = "Purchase Order Attached";
                            PrintSupplierPurchaseOrders(CurrentOrder.OrderTypeID, email);
                            break;
                        }
                }
            }
            else
            {
                App.ShowMessage("You must save the order before you can send.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void Print()
        {
            if (CurrentOrder.Exists == true)
            {
                var switchExpr = Combo.get_GetSelectedItemValue(cboPrintType);
                switch (switchExpr)
                {
                    case var @case when @case == Conversions.ToString(Enums.SystemDocumentType.SupplierPurchaseOrder):
                        {
                            PrintSupplierPurchaseOrders(CurrentOrder.OrderTypeID, null);
                            break;
                        }
                }

                pnlDocuments.Controls.Clear();
                DocumentsControl = new UCDocumentsList(Enums.TableNames.tblOrder, CurrentOrder.OrderID);
                pnlDocuments.Controls.Add(DocumentsControl);
            }
            else
            {
                App.ShowMessage("You must save the order before you can print.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool PrintSupplierPurchaseOrders(int OrderTypeID, Emails oEmail)
        {
            var details = new ArrayList();
            var orderDV = App.DB.Order.OrderSupplierItemsForPrint_Get(CurrentOrder.OrderID);
            if (orderDV.Table.Rows.Count > 0)
            {
                orderDV.Sort = "SupplierID";
                var printDT = orderDV.Table.Clone();
                var printDS = new DataSet();
                int prevSupplierID = Conversions.ToInteger(orderDV.Table.Rows[0]["SupplierID"]);
                foreach (DataRow row in orderDV.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["SupplierID"], prevSupplierID, false)))
                    {
                        printDT.Rows.Add(row.ItemArray);
                    }
                    else
                    {
                        printDT.TableName = "tblOrder" + Conversions.ToString(prevSupplierID);
                        printDS.Tables.Add(printDT.Copy());
                        printDT.Rows.Clear();
                        printDT.Rows.Add(row.ItemArray);
                    }

                    prevSupplierID = Conversions.ToInteger(row["SupplierID"]);
                }

                if (printDT.Rows.Count > 0)
                {
                    printDT.TableName = "tblOrder" + Conversions.ToString(prevSupplierID);
                    printDS.Tables.Add(printDT.Copy());
                    details.Add(printDS);
                }

                var answer = App.ShowMessage("Do you want to print to PDF?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (OrderTypeID)
                {
                    case (int)Enums.OrderType.Customer:
                        {
                            // details.Add(CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).theSite)
                            if (((UCOrderForCustomer)pnlDetails.Controls[0]).theProperty is null)
                            {
                                details.Add("Warehouse");
                                details.Add(((UCOrderForCustomer)pnlDetails.Controls[0]).Warehouse);
                            }
                            else
                            {
                                details.Add("Site");
                                details.Add(((UCOrderForCustomer)pnlDetails.Controls[0]).theProperty);
                            }

                            details.Add(null);
                            details.Add(App.DB.User.Get(CurrentOrder.UserID));
                            details.Add(CurrentOrder.OrderReference);
                            details.Add(CurrentOrder.DeliveryDeadline);
                            details.Add(App.DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID));
                            details.Add(answer);
                            if (oEmail is object)
                            {
                                var oPrint = new Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, true, CurrentOrder.OrderID, true);
                                foreach (Entity.Suppliers.Supplier oSupplier in oPrint.MultiEmail())
                                {
                                    oEmail.Attachments.Add(oSupplier.FilePath);
                                    oEmail.To = oSupplier.EmailAddress;
                                    oEmail.SendMe = true;
                                    oEmail.Send();
                                }
                            }
                            else
                            {
                                var oPrint = new Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, true, CurrentOrder.OrderID);
                            }

                            break;
                        }

                    case (int)Enums.OrderType.Warehouse:
                        {
                            details.Add("Warehouse");
                            details.Add(((UCOrderForWarehouse)pnlDetails.Controls[0]).Warehouse);
                            details.Add(null);
                            details.Add(App.DB.User.Get(CurrentOrder.UserID));
                            details.Add(CurrentOrder.OrderReference);
                            details.Add(CurrentOrder.DeliveryDeadline);
                            details.Add(App.DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID));
                            details.Add(answer);
                            if (oEmail is object)
                            {
                                var oPrint = new Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, true, CurrentOrder.OrderID, true);
                                foreach (Entity.Suppliers.Supplier oSupplier in oPrint.MultiEmail())
                                {
                                    oEmail.Attachments.Add(oSupplier.FilePath);
                                    oEmail.To = oSupplier.EmailAddress;
                                    oEmail.SendMe = true;
                                    oEmail.Send();
                                }
                            }
                            else
                            {
                                var oPrint = new Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, true, CurrentOrder.OrderID);
                            }

                            break;
                        }

                    case (int)Enums.OrderType.Job:
                        {
                            int warehouseID = App.DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(CurrentOrder.OrderID).WarehouseID;
                            if (warehouseID > 0)
                            {
                                details.Add("Warehouse");
                                details.Add(App.DB.Warehouse.Warehouse_Get(warehouseID));
                            }
                            else
                            {
                                details.Add("Site");
                                details.Add(App.DB.Sites.Get(App.DB.Job.Job_Get_For_An_EngineerVisit_ID(App.DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(CurrentOrder.OrderID).EngineerVisitID).PropertyID));
                            }

                            details.Add(null);
                            details.Add(App.DB.User.Get(CurrentOrder.UserID));
                            details.Add(CurrentOrder.OrderReference);
                            details.Add(CurrentOrder.DeliveryDeadline);
                            details.Add(App.DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID));
                            details.Add(answer);
                            if (oEmail is object)
                            {
                                var oPrint = new Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, true, CurrentOrder.OrderID, true);
                                foreach (Entity.Suppliers.Supplier oSupplier in oPrint.MultiEmail())
                                {
                                    oEmail.Attachments.Add(oSupplier.FilePath);
                                    oEmail.To = oSupplier.EmailAddress;
                                    oEmail.SendMe = true;
                                    oEmail.Send();
                                }
                            }
                            else
                            {
                                var oPrint = new Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, true, CurrentOrder.OrderID);
                            }

                            break;
                        }

                    case (int)Enums.OrderType.StockProfile:
                        {
                            details.Add("Stock Profile");
                            int deliveryAddressID = App.DB.OrderLocation.OrderLocation_GetForOrder(CurrentOrder.OrderID).DeliveryAddressID;
                            if (!(deliveryAddressID == 0))
                            {
                                details.Add(App.DB.Warehouse.Warehouse_Get(deliveryAddressID));
                            }
                            else
                            {
                                details.Add(null);
                            }

                            details.Add(null);
                            details.Add(App.DB.User.Get(CurrentOrder.UserID));
                            details.Add(CurrentOrder.OrderReference);
                            details.Add(CurrentOrder.DeliveryDeadline);
                            details.Add(App.DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID));
                            details.Add(answer);
                            if (oEmail is object)
                            {
                                var oPrint = new Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, true, CurrentOrder.OrderID, true);
                                foreach (Entity.Suppliers.Supplier oSupplier in oPrint.MultiEmail())
                                {
                                    oEmail.Attachments.Add(oSupplier.FilePath);
                                    oEmail.To = oSupplier.EmailAddress;
                                    oEmail.SendMe = true;
                                    oEmail.Send();
                                }
                            }
                            else
                            {
                                var oPrint = new Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, true, CurrentOrder.OrderID);
                            }

                            break;
                        }
                }
            }
            else
            {
                App.ShowMessage("No Items have been ordered from suppliers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return default;
        }

        private void btnUpdateOrderRef_Click(object sender, EventArgs e)
        {
            if (txtOrderReference.ReadOnly == true)
            {
                if (CurrentOrder is null)
                    return;
                if (!CurrentOrder.Exists)
                    return;
                txtOrderReference.ReadOnly = false;
                txtOrderReference.Enabled = true;
            }
            // update
            else if (App.ShowMessage("Do you wish to update the order ref?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                App.DB.Order.Update_OrderRef(CurrentOrder.OrderID, txtOrderReference.Text);
                var email = new Emails();
                email.To = EmailAddress.Accounts;
                email.From = EmailAddress.FSM;
                email.Subject = "Purchase Order Changed";
                email.Body = "Purchase Order Changed from " + CurrentOrder.OrderReference + " to " + txtOrderReference.Text + " by " + App.loggedInUser.Fullname;
                email.SendMe = true;
                email.Send();
                txtOrderReference.ReadOnly = true;
                txtOrderReference.Enabled = false;
            }
        }

        private void btnApproveOrder_Click(object sender, EventArgs e)
        {
            if (CurrentOrder.OrderStatusID != (int)Enums.OrderStatus.AwaitingApproval)
                return;
            if (App.ShowMessage("Are you sure you want to approve this order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                App.ShowForm(typeof(FRMOrderRejection), true, new object[] { this, "", true });
                if (Reason.Trim().Length == 0)
                {
                    IsLoading = true;
                    var argcombo = cboOrderStatus;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentOrder.OrderStatusID.ToString());
                    IsLoading = false;
                    return;
                }
                else
                {
                    CurrentOrder.SetReason = Reason;
                    CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Confirmed);
                    App.DB.Order.Update(CurrentOrder);
                    Populate();
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}