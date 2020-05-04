using FSM.Business.Orders;
using FSM.Entity.Jobs;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCOrder : UCBase, IUserControl
    {
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

            base.Load += UCOrder_Load;
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

        private Button _btnAddNewProduct;

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

        private Label _lblInvoiceDate;

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

        private Label _lblSupplierGoods;

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

        private GroupBox _GroupBox4;

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

        private Label _Label14;

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

        private Label _Label20;

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

        private CheckBox _CheckBox1;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this._grpOrder = new System.Windows.Forms.GroupBox();
            this._btnApproveOrder = new System.Windows.Forms.Button();
            this._btnUpdateOrderRef = new System.Windows.Forms.Button();
            this._cboDept = new System.Windows.Forms.ComboBox();
            this._lblOrderBalance = new System.Windows.Forms.Label();
            this._lblOrderBalanceLabel = new System.Windows.Forms.Label();
            this._chkRevertStatus = new System.Windows.Forms.CheckBox();
            this._lblOrderTotalLabel = new System.Windows.Forms.Label();
            this._lblOrderTotal = new System.Windows.Forms.Label();
            this._chkDoNotConsolidate = new System.Windows.Forms.CheckBox();
            this._chkDeadlineNA = new System.Windows.Forms.CheckBox();
            this._dtpDeliveryDeadline = new System.Windows.Forms.DateTimePicker();
            this._Label6 = new System.Windows.Forms.Label();
            this._cboOrderStatus = new System.Windows.Forms.ComboBox();
            this._Label19 = new System.Windows.Forms.Label();
            this._dtpDatePlaced = new System.Windows.Forms.DateTimePicker();
            this._lblDatePlaced = new System.Windows.Forms.Label();
            this._txtOrderReference = new System.Windows.Forms.TextBox();
            this._lblOrderReference = new System.Windows.Forms.Label();
            this._tcOrderDetails = new System.Windows.Forms.TabControl();
            this._tabDetails = new System.Windows.Forms.TabPage();
            this._btnRelatedJob = new System.Windows.Forms.Button();
            this._pnlDetails = new System.Windows.Forms.Panel();
            this._lblOrderTypeID = new System.Windows.Forms.Label();
            this._cboOrderTypeID = new System.Windows.Forms.ComboBox();
            this._btnCharges = new System.Windows.Forms.Button();
            this._tabParts = new System.Windows.Forms.TabPage();
            this._grpPartSearch = new System.Windows.Forms.GroupBox();
            this._btnAddNewPart = new System.Windows.Forms.Button();
            this._cboPartLocation = new System.Windows.Forms.ComboBox();
            this._btnPartSearch = new System.Windows.Forms.Button();
            this._txtPartSearch = new System.Windows.Forms.TextBox();
            this._grpAvailableParts = new System.Windows.Forms.GroupBox();
            this._btnCreatePartRequest = new System.Windows.Forms.Button();
            this._Label7 = new System.Windows.Forms.Label();
            this._txtPartBuyPrice = new System.Windows.Forms.TextBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtPartQuantity = new System.Windows.Forms.TextBox();
            this._dgParts = new System.Windows.Forms.DataGrid();
            this._btnAddPart = new System.Windows.Forms.Button();
            this._tabProducts = new System.Windows.Forms.TabPage();
            this._grpProductsAvailable = new System.Windows.Forms.GroupBox();
            this._btnCreateProductPriceRequest = new System.Windows.Forms.Button();
            this._txtProductSellPrice = new System.Windows.Forms.TextBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._txtProductBuyPrice = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtProductQuantity = new System.Windows.Forms.TextBox();
            this._dgProduct = new System.Windows.Forms.DataGrid();
            this._btnAddProduct = new System.Windows.Forms.Button();
            this._grpProductSearch = new System.Windows.Forms.GroupBox();
            this._btnAddNewProduct = new System.Windows.Forms.Button();
            this._cboProductLocation = new System.Windows.Forms.ComboBox();
            this._btnProductSearch = new System.Windows.Forms.Button();
            this._txtProductSearch = new System.Windows.Forms.TextBox();
            this._tabItemsIncluded = new System.Windows.Forms.TabPage();
            this._GroupBox3 = new System.Windows.Forms.GroupBox();
            this._nudItemQty = new System.Windows.Forms.NumericUpDown();
            this._btnEngineerReceived = new System.Windows.Forms.Button();
            this._btnReceiveAll = new System.Windows.Forms.Button();
            this._lblItemQty = new System.Windows.Forms.Label();
            this._btnItemQtyUpdate = new System.Windows.Forms.Button();
            this._dgItemsIncluded = new System.Windows.Forms.DataGrid();
            this._tabPartPriceReq = new System.Windows.Forms.TabPage();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._btnUpdatePartPriceRequest = new System.Windows.Forms.Button();
            this._dgPriceRequests = new System.Windows.Forms.DataGrid();
            this._tabDocuments = new System.Windows.Forms.TabPage();
            this._pnlDocuments = new System.Windows.Forms.Panel();
            this._btnEmail = new System.Windows.Forms.Button();
            this._cboPrintType = new System.Windows.Forms.ComboBox();
            this._btnPrint = new System.Windows.Forms.Button();
            this._Label8 = new System.Windows.Forms.Label();
            this._tabInvoices = new System.Windows.Forms.TabPage();
            this._grpReceivedInvoices = new System.Windows.Forms.GroupBox();
            this._btnDeleteSupplierInvoice = new System.Windows.Forms.Button();
            this._btnUpdateSupplierInvoice = new System.Windows.Forms.Button();
            this._txtTotalAmount = new System.Windows.Forms.TextBox();
            this._lblTotalValue = new System.Windows.Forms.Label();
            this._txtVATAmount = new System.Windows.Forms.TextBox();
            this._txtNominalCodeNew = new System.Windows.Forms.TextBox();
            this._Label16 = new System.Windows.Forms.Label();
            this._lblVatValue = new System.Windows.Forms.Label();
            this._txtGoodsAmount = new System.Windows.Forms.TextBox();
            this._cboInvoiceTaxCodeNew = new System.Windows.Forms.ComboBox();
            this._txtExtraReferenceNew = new System.Windows.Forms.TextBox();
            this._Label13 = new System.Windows.Forms.Label();
            this._lblGoodsValue = new System.Windows.Forms.Label();
            this._Label15 = new System.Windows.Forms.Label();
            this._lblInvoiceDate = new System.Windows.Forms.Label();
            this._txtSupplierInvoiceRefNew = new System.Windows.Forms.TextBox();
            this._lblSupplierRef = new System.Windows.Forms.Label();
            this._btnAddSupplierInvoice = new System.Windows.Forms.Button();
            this._dgvReceivedInvoices = new System.Windows.Forms.DataGridView();
            this._dtpSupplierInvoiceDateNew = new System.Windows.Forms.DateTimePicker();
            this._cboReadySageNew = new System.Windows.Forms.CheckBox();
            this._TabPage1 = new System.Windows.Forms.TabPage();
            this._GroupBox4 = new System.Windows.Forms.GroupBox();
            this._Button1 = new System.Windows.Forms.Button();
            this._CheckBox1 = new System.Windows.Forms.CheckBox();
            this._txtCreditExRef = new System.Windows.Forms.TextBox();
            this._Label21 = new System.Windows.Forms.Label();
            this._btnCreditDelete = new System.Windows.Forms.Button();
            this._txtCreditTotal = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._txtCreditVAT = new System.Windows.Forms.TextBox();
            this._txtCreditNominal = new System.Windows.Forms.TextBox();
            this._Label10 = new System.Windows.Forms.Label();
            this._Label14 = new System.Windows.Forms.Label();
            this._txtCreditGoods = new System.Windows.Forms.TextBox();
            this._cboCreditTax = new System.Windows.Forms.ComboBox();
            this._Label18 = new System.Windows.Forms.Label();
            this._Label20 = new System.Windows.Forms.Label();
            this._txtCreditRef = new System.Windows.Forms.TextBox();
            this._Label23 = new System.Windows.Forms.Label();
            this._btnCreditAdd = new System.Windows.Forms.Button();
            this._dgCredits = new System.Windows.Forms.DataGridView();
            this._dtpCreditDate = new System.Windows.Forms.DateTimePicker();
            this._lblOrderStatus = new System.Windows.Forms.Label();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._lblCredits = new System.Windows.Forms.Label();
            this._Label25 = new System.Windows.Forms.Label();
            this._lblSupplierGoods = new System.Windows.Forms.Label();
            this._lblGoodsTotal = new System.Windows.Forms.Label();
            this._Label17 = new System.Windows.Forms.Label();
            this._FSMDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._grpOrder.SuspendLayout();
            this._tcOrderDetails.SuspendLayout();
            this._tabDetails.SuspendLayout();
            this._tabParts.SuspendLayout();
            this._grpPartSearch.SuspendLayout();
            this._grpAvailableParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgParts)).BeginInit();
            this._tabProducts.SuspendLayout();
            this._grpProductsAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgProduct)).BeginInit();
            this._grpProductSearch.SuspendLayout();
            this._tabItemsIncluded.SuspendLayout();
            this._GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudItemQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgItemsIncluded)).BeginInit();
            this._tabPartPriceReq.SuspendLayout();
            this._GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgPriceRequests)).BeginInit();
            this._tabDocuments.SuspendLayout();
            this._tabInvoices.SuspendLayout();
            this._grpReceivedInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvReceivedInvoices)).BeginInit();
            this._TabPage1.SuspendLayout();
            this._GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCredits)).BeginInit();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._FSMDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            //
            // _grpOrder
            //
            this._grpOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpOrder.Controls.Add(this._btnApproveOrder);
            this._grpOrder.Controls.Add(this._btnUpdateOrderRef);
            this._grpOrder.Controls.Add(this._cboDept);
            this._grpOrder.Controls.Add(this._lblOrderBalance);
            this._grpOrder.Controls.Add(this._lblOrderBalanceLabel);
            this._grpOrder.Controls.Add(this._chkRevertStatus);
            this._grpOrder.Controls.Add(this._lblOrderTotalLabel);
            this._grpOrder.Controls.Add(this._lblOrderTotal);
            this._grpOrder.Controls.Add(this._chkDoNotConsolidate);
            this._grpOrder.Controls.Add(this._chkDeadlineNA);
            this._grpOrder.Controls.Add(this._dtpDeliveryDeadline);
            this._grpOrder.Controls.Add(this._Label6);
            this._grpOrder.Controls.Add(this._cboOrderStatus);
            this._grpOrder.Controls.Add(this._Label19);
            this._grpOrder.Controls.Add(this._dtpDatePlaced);
            this._grpOrder.Controls.Add(this._lblDatePlaced);
            this._grpOrder.Controls.Add(this._txtOrderReference);
            this._grpOrder.Controls.Add(this._lblOrderReference);
            this._grpOrder.Controls.Add(this._tcOrderDetails);
            this._grpOrder.Controls.Add(this._lblOrderStatus);
            this._grpOrder.Controls.Add(this._GroupBox1);
            this._grpOrder.Controls.Add(this._Label17);
            this._grpOrder.Location = new System.Drawing.Point(8, 1);
            this._grpOrder.Name = "_grpOrder";
            this._grpOrder.Size = new System.Drawing.Size(1687, 890);
            this._grpOrder.TabIndex = 1;
            this._grpOrder.TabStop = false;
            this._grpOrder.Text = "Main Details";
            //
            // _btnApproveOrder
            //
            this._btnApproveOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnApproveOrder.Location = new System.Drawing.Point(1286, 17);
            this._btnApproveOrder.Name = "_btnApproveOrder";
            this._btnApproveOrder.Size = new System.Drawing.Size(120, 23);
            this._btnApproveOrder.TabIndex = 126;
            this._btnApproveOrder.Text = "Approve Order";
            this._btnApproveOrder.Visible = false;
            this._btnApproveOrder.Click += new System.EventHandler(this.btnApproveOrder_Click);
            //
            // _btnUpdateOrderRef
            //
            this._btnUpdateOrderRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnUpdateOrderRef.Location = new System.Drawing.Point(1095, 17);
            this._btnUpdateOrderRef.Name = "_btnUpdateOrderRef";
            this._btnUpdateOrderRef.Size = new System.Drawing.Size(120, 23);
            this._btnUpdateOrderRef.TabIndex = 125;
            this._btnUpdateOrderRef.Text = "Change Order Ref";
            this._btnUpdateOrderRef.Visible = false;
            this._btnUpdateOrderRef.Click += new System.EventHandler(this.btnUpdateOrderRef_Click);
            //
            // _cboDept
            //
            this._cboDept.FormattingEnabled = true;
            this._cboDept.Location = new System.Drawing.Point(80, 94);
            this._cboDept.Name = "_cboDept";
            this._cboDept.Size = new System.Drawing.Size(170, 21);
            this._cboDept.TabIndex = 124;
            //
            // _lblOrderBalance
            //
            this._lblOrderBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblOrderBalance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOrderBalance.Location = new System.Drawing.Point(1550, 107);
            this._lblOrderBalance.Name = "_lblOrderBalance";
            this._lblOrderBalance.Size = new System.Drawing.Size(122, 15);
            this._lblOrderBalance.TabIndex = 84;
            this._lblOrderBalance.Text = "£0.00";
            this._lblOrderBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // _lblOrderBalanceLabel
            //
            this._lblOrderBalanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblOrderBalanceLabel.AutoSize = true;
            this._lblOrderBalanceLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOrderBalanceLabel.Location = new System.Drawing.Point(1428, 108);
            this._lblOrderBalanceLabel.Name = "_lblOrderBalanceLabel";
            this._lblOrderBalanceLabel.Size = new System.Drawing.Size(96, 13);
            this._lblOrderBalanceLabel.TabIndex = 85;
            this._lblOrderBalanceLabel.Text = "Unallocated : ";
            this._lblOrderBalanceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // _chkRevertStatus
            //
            this._chkRevertStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkRevertStatus.AutoSize = true;
            this._chkRevertStatus.Location = new System.Drawing.Point(1095, 97);
            this._chkRevertStatus.Name = "_chkRevertStatus";
            this._chkRevertStatus.Size = new System.Drawing.Size(209, 17);
            this._chkRevertStatus.TabIndex = 78;
            this._chkRevertStatus.Text = "Revert to Awaiting Confirmation";
            this._chkRevertStatus.UseVisualStyleBackColor = true;
            this._chkRevertStatus.Visible = false;
            //
            // _lblOrderTotalLabel
            //
            this._lblOrderTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblOrderTotalLabel.AutoSize = true;
            this._lblOrderTotalLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOrderTotalLabel.Location = new System.Drawing.Point(1424, 13);
            this._lblOrderTotalLabel.Name = "_lblOrderTotalLabel";
            this._lblOrderTotalLabel.Size = new System.Drawing.Size(157, 13);
            this._lblOrderTotalLabel.TabIndex = 77;
            this._lblOrderTotalLabel.Text = "Purchase Order Total : ";
            this._lblOrderTotalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // _lblOrderTotal
            //
            this._lblOrderTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblOrderTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOrderTotal.Location = new System.Drawing.Point(1596, 12);
            this._lblOrderTotal.Name = "_lblOrderTotal";
            this._lblOrderTotal.Size = new System.Drawing.Size(75, 15);
            this._lblOrderTotal.TabIndex = 76;
            this._lblOrderTotal.Text = "£0.00";
            this._lblOrderTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // _chkDoNotConsolidate
            //
            this._chkDoNotConsolidate.AutoSize = true;
            this._chkDoNotConsolidate.Location = new System.Drawing.Point(256, 97);
            this._chkDoNotConsolidate.Name = "_chkDoNotConsolidate";
            this._chkDoNotConsolidate.Size = new System.Drawing.Size(136, 17);
            this._chkDoNotConsolidate.TabIndex = 69;
            this._chkDoNotConsolidate.Text = "Do Not Consolidate";
            this._chkDoNotConsolidate.UseVisualStyleBackColor = true;
            this._chkDoNotConsolidate.Visible = false;
            //
            // _chkDeadlineNA
            //
            this._chkDeadlineNA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkDeadlineNA.Location = new System.Drawing.Point(1212, 66);
            this._chkDeadlineNA.Name = "_chkDeadlineNA";
            this._chkDeadlineNA.Size = new System.Drawing.Size(48, 24);
            this._chkDeadlineNA.TabIndex = 4;
            this._chkDeadlineNA.Text = "N/A";
            this._chkDeadlineNA.CheckedChanged += new System.EventHandler(this.chkDeadlineNA_CheckedChanged);
            //
            // _dtpDeliveryDeadline
            //
            this._dtpDeliveryDeadline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpDeliveryDeadline.Location = new System.Drawing.Point(1263, 66);
            this._dtpDeliveryDeadline.Name = "_dtpDeliveryDeadline";
            this._dtpDeliveryDeadline.Size = new System.Drawing.Size(144, 21);
            this._dtpDeliveryDeadline.TabIndex = 5;
            this._dtpDeliveryDeadline.Tag = "Order.DatePlaced";
            //
            // _Label6
            //
            this._Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label6.Location = new System.Drawing.Point(1090, 70);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(114, 23);
            this._Label6.TabIndex = 42;
            this._Label6.Text = "Delivery Deadline";
            //
            // _cboOrderStatus
            //
            this._cboOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboOrderStatus.Location = new System.Drawing.Point(80, 43);
            this._cboOrderStatus.Name = "_cboOrderStatus";
            this._cboOrderStatus.Size = new System.Drawing.Size(1007, 21);
            this._cboOrderStatus.TabIndex = 2;
            this._cboOrderStatus.SelectedIndexChanged += new System.EventHandler(this.cboOrderStatus_SelectedIndexChanged);
            //
            // _Label19
            //
            this._Label19.Location = new System.Drawing.Point(6, 43);
            this._Label19.Name = "_Label19";
            this._Label19.Size = new System.Drawing.Size(48, 23);
            this._Label19.TabIndex = 33;
            this._Label19.Text = "Status";
            //
            // _dtpDatePlaced
            //
            this._dtpDatePlaced.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpDatePlaced.Location = new System.Drawing.Point(80, 67);
            this._dtpDatePlaced.Name = "_dtpDatePlaced";
            this._dtpDatePlaced.Size = new System.Drawing.Size(1007, 21);
            this._dtpDatePlaced.TabIndex = 3;
            this._dtpDatePlaced.Tag = "Order.DatePlaced";
            //
            // _lblDatePlaced
            //
            this._lblDatePlaced.Location = new System.Drawing.Point(6, 67);
            this._lblDatePlaced.Name = "_lblDatePlaced";
            this._lblDatePlaced.Size = new System.Drawing.Size(79, 20);
            this._lblDatePlaced.TabIndex = 31;
            this._lblDatePlaced.Text = "Date Placed";
            //
            // _txtOrderReference
            //
            this._txtOrderReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtOrderReference.Location = new System.Drawing.Point(80, 19);
            this._txtOrderReference.MaxLength = 100;
            this._txtOrderReference.Name = "_txtOrderReference";
            this._txtOrderReference.ReadOnly = true;
            this._txtOrderReference.Size = new System.Drawing.Size(1007, 21);
            this._txtOrderReference.TabIndex = 1;
            this._txtOrderReference.Tag = "Order.OrderReference";
            this._txtOrderReference.Visible = false;
            //
            // _lblOrderReference
            //
            this._lblOrderReference.Location = new System.Drawing.Point(6, 19);
            this._lblOrderReference.Name = "_lblOrderReference";
            this._lblOrderReference.Size = new System.Drawing.Size(66, 20);
            this._lblOrderReference.TabIndex = 31;
            this._lblOrderReference.Text = "Order Ref";
            //
            // _tcOrderDetails
            //
            this._tcOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tcOrderDetails.Controls.Add(this._tabDetails);
            this._tcOrderDetails.Controls.Add(this._tabParts);
            this._tcOrderDetails.Controls.Add(this._tabProducts);
            this._tcOrderDetails.Controls.Add(this._tabItemsIncluded);
            this._tcOrderDetails.Controls.Add(this._tabPartPriceReq);
            this._tcOrderDetails.Controls.Add(this._tabDocuments);
            this._tcOrderDetails.Controls.Add(this._tabInvoices);
            this._tcOrderDetails.Controls.Add(this._TabPage1);
            this._tcOrderDetails.Location = new System.Drawing.Point(11, 156);
            this._tcOrderDetails.Name = "_tcOrderDetails";
            this._tcOrderDetails.SelectedIndex = 0;
            this._tcOrderDetails.Size = new System.Drawing.Size(1669, 728);
            this._tcOrderDetails.TabIndex = 6;
            this._tcOrderDetails.SelectedIndexChanged += new System.EventHandler(this.tcOrderDetails_SelectedIndexChanged);
            //
            // _tabDetails
            //
            this._tabDetails.Controls.Add(this._btnRelatedJob);
            this._tabDetails.Controls.Add(this._pnlDetails);
            this._tabDetails.Controls.Add(this._lblOrderTypeID);
            this._tabDetails.Controls.Add(this._cboOrderTypeID);
            this._tabDetails.Controls.Add(this._btnCharges);
            this._tabDetails.Location = new System.Drawing.Point(4, 22);
            this._tabDetails.Name = "_tabDetails";
            this._tabDetails.Size = new System.Drawing.Size(1661, 702);
            this._tabDetails.TabIndex = 0;
            this._tabDetails.Text = "Order Details";
            //
            // _btnRelatedJob
            //
            this._btnRelatedJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRelatedJob.Enabled = false;
            this._btnRelatedJob.Location = new System.Drawing.Point(1356, 7);
            this._btnRelatedJob.Name = "_btnRelatedJob";
            this._btnRelatedJob.Size = new System.Drawing.Size(120, 23);
            this._btnRelatedJob.TabIndex = 32;
            this._btnRelatedJob.Text = "View Related Job";
            this._btnRelatedJob.Click += new System.EventHandler(this.btnRelatedJob_Click);
            //
            // _pnlDetails
            //
            this._pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlDetails.Location = new System.Drawing.Point(0, 40);
            this._pnlDetails.Name = "_pnlDetails";
            this._pnlDetails.Size = new System.Drawing.Size(1658, 653);
            this._pnlDetails.TabIndex = 9;
            //
            // _lblOrderTypeID
            //
            this._lblOrderTypeID.Location = new System.Drawing.Point(8, 8);
            this._lblOrderTypeID.Name = "_lblOrderTypeID";
            this._lblOrderTypeID.Size = new System.Drawing.Size(64, 20);
            this._lblOrderTypeID.TabIndex = 31;
            this._lblOrderTypeID.Text = "Order For";
            //
            // _cboOrderTypeID
            //
            this._cboOrderTypeID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboOrderTypeID.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboOrderTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboOrderTypeID.Location = new System.Drawing.Point(96, 8);
            this._cboOrderTypeID.Name = "_cboOrderTypeID";
            this._cboOrderTypeID.Size = new System.Drawing.Size(1252, 21);
            this._cboOrderTypeID.TabIndex = 7;
            this._cboOrderTypeID.Tag = "Order.OrderTypeID";
            this._cboOrderTypeID.SelectedIndexChanged += new System.EventHandler(this.cboOrderTypeID_SelectedIndexChanged);
            //
            // _btnCharges
            //
            this._btnCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCharges.Location = new System.Drawing.Point(1482, 7);
            this._btnCharges.Name = "_btnCharges";
            this._btnCharges.Size = new System.Drawing.Size(168, 23);
            this._btnCharges.TabIndex = 8;
            this._btnCharges.Text = "Manage Additional Charges";
            this._btnCharges.Click += new System.EventHandler(this.btnCharges_Click);
            //
            // _tabParts
            //
            this._tabParts.Controls.Add(this._grpPartSearch);
            this._tabParts.Controls.Add(this._grpAvailableParts);
            this._tabParts.Location = new System.Drawing.Point(4, 22);
            this._tabParts.Name = "_tabParts";
            this._tabParts.Size = new System.Drawing.Size(1796, 373);
            this._tabParts.TabIndex = 2;
            this._tabParts.Text = "Parts Available";
            //
            // _grpPartSearch
            //
            this._grpPartSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpPartSearch.Controls.Add(this._btnAddNewPart);
            this._grpPartSearch.Controls.Add(this._cboPartLocation);
            this._grpPartSearch.Controls.Add(this._btnPartSearch);
            this._grpPartSearch.Controls.Add(this._txtPartSearch);
            this._grpPartSearch.Location = new System.Drawing.Point(8, 8);
            this._grpPartSearch.Name = "_grpPartSearch";
            this._grpPartSearch.Size = new System.Drawing.Size(1785, 56);
            this._grpPartSearch.TabIndex = 13;
            this._grpPartSearch.TabStop = false;
            this._grpPartSearch.Text = "Part Search From";
            //
            // _btnAddNewPart
            //
            this._btnAddNewPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddNewPart.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnAddNewPart.Location = new System.Drawing.Point(1708, 24);
            this._btnAddNewPart.Name = "_btnAddNewPart";
            this._btnAddNewPart.Size = new System.Drawing.Size(64, 22);
            this._btnAddNewPart.TabIndex = 4;
            this._btnAddNewPart.Text = "New Part";
            this._btnAddNewPart.Click += new System.EventHandler(this.btnAddNewPart_Click);
            //
            // _cboPartLocation
            //
            this._cboPartLocation.Location = new System.Drawing.Point(8, 24);
            this._cboPartLocation.Name = "_cboPartLocation";
            this._cboPartLocation.Size = new System.Drawing.Size(152, 21);
            this._cboPartLocation.TabIndex = 1;
            this._cboPartLocation.SelectedIndexChanged += new System.EventHandler(this.cboPartLocation_SelectedIndexChanged);
            //
            // _btnPartSearch
            //
            this._btnPartSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPartSearch.Enabled = false;
            this._btnPartSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnPartSearch.Location = new System.Drawing.Point(1635, 23);
            this._btnPartSearch.Name = "_btnPartSearch";
            this._btnPartSearch.Size = new System.Drawing.Size(64, 22);
            this._btnPartSearch.TabIndex = 3;
            this._btnPartSearch.Text = "Find";
            this._btnPartSearch.Click += new System.EventHandler(this.btnPartSearch_Click);
            //
            // _txtPartSearch
            //
            this._txtPartSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPartSearch.Location = new System.Drawing.Point(168, 24);
            this._txtPartSearch.Name = "_txtPartSearch";
            this._txtPartSearch.Size = new System.Drawing.Size(1460, 21);
            this._txtPartSearch.TabIndex = 2;
            this._txtPartSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartSearch_KeyDown);
            //
            // _grpAvailableParts
            //
            this._grpAvailableParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpAvailableParts.Controls.Add(this._btnCreatePartRequest);
            this._grpAvailableParts.Controls.Add(this._Label7);
            this._grpAvailableParts.Controls.Add(this._txtPartBuyPrice);
            this._grpAvailableParts.Controls.Add(this._Label3);
            this._grpAvailableParts.Controls.Add(this._txtPartQuantity);
            this._grpAvailableParts.Controls.Add(this._dgParts);
            this._grpAvailableParts.Controls.Add(this._btnAddPart);
            this._grpAvailableParts.Location = new System.Drawing.Point(8, 72);
            this._grpAvailableParts.Name = "_grpAvailableParts";
            this._grpAvailableParts.Size = new System.Drawing.Size(1785, 297);
            this._grpAvailableParts.TabIndex = 14;
            this._grpAvailableParts.TabStop = false;
            this._grpAvailableParts.Text = "Available Parts && Packs";
            //
            // _btnCreatePartRequest
            //
            this._btnCreatePartRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCreatePartRequest.Location = new System.Drawing.Point(935, 263);
            this._btnCreatePartRequest.Name = "_btnCreatePartRequest";
            this._btnCreatePartRequest.Size = new System.Drawing.Size(837, 24);
            this._btnCreatePartRequest.TabIndex = 10;
            this._btnCreatePartRequest.Text = "Part Price Request";
            this._btnCreatePartRequest.Click += new System.EventHandler(this.btnCreatePartRequest_Click);
            //
            // _Label7
            //
            this._Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label7.Location = new System.Drawing.Point(8, 269);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(40, 13);
            this._Label7.TabIndex = 23;
            this._Label7.Text = "Qty";
            //
            // _txtPartBuyPrice
            //
            this._txtPartBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtPartBuyPrice.Location = new System.Drawing.Point(248, 265);
            this._txtPartBuyPrice.Name = "_txtPartBuyPrice";
            this._txtPartBuyPrice.Size = new System.Drawing.Size(112, 21);
            this._txtPartBuyPrice.TabIndex = 7;
            //
            // _Label3
            //
            this._Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label3.Location = new System.Drawing.Point(176, 269);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(64, 13);
            this._Label3.TabIndex = 14;
            this._Label3.Text = "Buy Price";
            //
            // _txtPartQuantity
            //
            this._txtPartQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtPartQuantity.Location = new System.Drawing.Point(56, 265);
            this._txtPartQuantity.Name = "_txtPartQuantity";
            this._txtPartQuantity.Size = new System.Drawing.Size(112, 21);
            this._txtPartQuantity.TabIndex = 6;
            //
            // _dgParts
            //
            this._dgParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgParts.DataMember = "";
            this._dgParts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgParts.Location = new System.Drawing.Point(8, 20);
            this._dgParts.Name = "_dgParts";
            this._dgParts.Size = new System.Drawing.Size(1769, 237);
            this._dgParts.TabIndex = 5;
            this._dgParts.CurrentCellChanged += new System.EventHandler(this.dgParts_Click);
            this._dgParts.Click += new System.EventHandler(this.dgParts_Click);
            this._dgParts.DoubleClick += new System.EventHandler(this.dgParts_DoubleClick);
            //
            // _btnAddPart
            //
            this._btnAddPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddPart.Location = new System.Drawing.Point(378, 263);
            this._btnAddPart.Name = "_btnAddPart";
            this._btnAddPart.Size = new System.Drawing.Size(56, 24);
            this._btnAddPart.TabIndex = 9;
            this._btnAddPart.Text = "Add";
            this._btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            //
            // _tabProducts
            //
            this._tabProducts.Controls.Add(this._grpProductsAvailable);
            this._tabProducts.Controls.Add(this._grpProductSearch);
            this._tabProducts.Location = new System.Drawing.Point(4, 22);
            this._tabProducts.Name = "_tabProducts";
            this._tabProducts.Size = new System.Drawing.Size(1796, 373);
            this._tabProducts.TabIndex = 1;
            this._tabProducts.Text = "Products Available";
            //
            // _grpProductsAvailable
            //
            this._grpProductsAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpProductsAvailable.Controls.Add(this._btnCreateProductPriceRequest);
            this._grpProductsAvailable.Controls.Add(this._txtProductSellPrice);
            this._grpProductsAvailable.Controls.Add(this._Label5);
            this._grpProductsAvailable.Controls.Add(this._txtProductBuyPrice);
            this._grpProductsAvailable.Controls.Add(this._Label4);
            this._grpProductsAvailable.Controls.Add(this._Label1);
            this._grpProductsAvailable.Controls.Add(this._txtProductQuantity);
            this._grpProductsAvailable.Controls.Add(this._dgProduct);
            this._grpProductsAvailable.Controls.Add(this._btnAddProduct);
            this._grpProductsAvailable.Location = new System.Drawing.Point(8, 72);
            this._grpProductsAvailable.Name = "_grpProductsAvailable";
            this._grpProductsAvailable.Size = new System.Drawing.Size(1785, 298);
            this._grpProductsAvailable.TabIndex = 10;
            this._grpProductsAvailable.TabStop = false;
            this._grpProductsAvailable.Text = "Available Products ";
            //
            // _btnCreateProductPriceRequest
            //
            this._btnCreateProductPriceRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCreateProductPriceRequest.Location = new System.Drawing.Point(616, 263);
            this._btnCreateProductPriceRequest.Name = "_btnCreateProductPriceRequest";
            this._btnCreateProductPriceRequest.Size = new System.Drawing.Size(1161, 24);
            this._btnCreateProductPriceRequest.TabIndex = 10;
            this._btnCreateProductPriceRequest.Text = "Product Price Request";
            this._btnCreateProductPriceRequest.Click += new System.EventHandler(this.btnCreateProductPriceRequest_Click);
            //
            // _txtProductSellPrice
            //
            this._txtProductSellPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtProductSellPrice.Location = new System.Drawing.Point(432, 265);
            this._txtProductSellPrice.Name = "_txtProductSellPrice";
            this._txtProductSellPrice.Size = new System.Drawing.Size(112, 21);
            this._txtProductSellPrice.TabIndex = 8;
            //
            // _Label5
            //
            this._Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label5.Location = new System.Drawing.Point(368, 269);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(64, 13);
            this._Label5.TabIndex = 18;
            this._Label5.Text = "Sell Price";
            //
            // _txtProductBuyPrice
            //
            this._txtProductBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtProductBuyPrice.Location = new System.Drawing.Point(232, 265);
            this._txtProductBuyPrice.Name = "_txtProductBuyPrice";
            this._txtProductBuyPrice.Size = new System.Drawing.Size(112, 21);
            this._txtProductBuyPrice.TabIndex = 7;
            //
            // _Label4
            //
            this._Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label4.Location = new System.Drawing.Point(168, 269);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(64, 13);
            this._Label4.TabIndex = 16;
            this._Label4.Text = "Buy Price";
            //
            // _Label1
            //
            this._Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label1.Location = new System.Drawing.Point(8, 269);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(40, 13);
            this._Label1.TabIndex = 15;
            this._Label1.Text = "Qty";
            //
            // _txtProductQuantity
            //
            this._txtProductQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtProductQuantity.Location = new System.Drawing.Point(48, 265);
            this._txtProductQuantity.Name = "_txtProductQuantity";
            this._txtProductQuantity.Size = new System.Drawing.Size(112, 21);
            this._txtProductQuantity.TabIndex = 6;
            //
            // _dgProduct
            //
            this._dgProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgProduct.DataMember = "";
            this._dgProduct.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgProduct.Location = new System.Drawing.Point(8, 20);
            this._dgProduct.Name = "_dgProduct";
            this._dgProduct.Size = new System.Drawing.Size(1769, 235);
            this._dgProduct.TabIndex = 5;
            this._dgProduct.CurrentCellChanged += new System.EventHandler(this.dgProduct_Click);
            this._dgProduct.Click += new System.EventHandler(this.dgProduct_Click);
            this._dgProduct.DoubleClick += new System.EventHandler(this.dgProduct_DoubleClick);
            //
            // _btnAddProduct
            //
            this._btnAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddProduct.Location = new System.Drawing.Point(552, 263);
            this._btnAddProduct.Name = "_btnAddProduct";
            this._btnAddProduct.Size = new System.Drawing.Size(56, 24);
            this._btnAddProduct.TabIndex = 9;
            this._btnAddProduct.Text = "Add ";
            this._btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            //
            // _grpProductSearch
            //
            this._grpProductSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpProductSearch.Controls.Add(this._btnAddNewProduct);
            this._grpProductSearch.Controls.Add(this._cboProductLocation);
            this._grpProductSearch.Controls.Add(this._btnProductSearch);
            this._grpProductSearch.Controls.Add(this._txtProductSearch);
            this._grpProductSearch.Location = new System.Drawing.Point(8, 8);
            this._grpProductSearch.Name = "_grpProductSearch";
            this._grpProductSearch.Size = new System.Drawing.Size(1785, 56);
            this._grpProductSearch.TabIndex = 9;
            this._grpProductSearch.TabStop = false;
            this._grpProductSearch.Text = "Product Search From";
            //
            // _btnAddNewProduct
            //
            this._btnAddNewProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddNewProduct.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnAddNewProduct.Location = new System.Drawing.Point(1680, 24);
            this._btnAddNewProduct.Name = "_btnAddNewProduct";
            this._btnAddNewProduct.Size = new System.Drawing.Size(88, 22);
            this._btnAddNewProduct.TabIndex = 4;
            this._btnAddNewProduct.Text = "New Product";
            this._btnAddNewProduct.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            //
            // _cboProductLocation
            //
            this._cboProductLocation.Location = new System.Drawing.Point(8, 24);
            this._cboProductLocation.Name = "_cboProductLocation";
            this._cboProductLocation.Size = new System.Drawing.Size(152, 21);
            this._cboProductLocation.TabIndex = 1;
            this._cboProductLocation.SelectedIndexChanged += new System.EventHandler(this.cboProductLocation_SelectedIndexChanged);
            //
            // _btnProductSearch
            //
            this._btnProductSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnProductSearch.Enabled = false;
            this._btnProductSearch.Location = new System.Drawing.Point(1618, 24);
            this._btnProductSearch.Name = "_btnProductSearch";
            this._btnProductSearch.Size = new System.Drawing.Size(56, 22);
            this._btnProductSearch.TabIndex = 3;
            this._btnProductSearch.Text = "Find";
            this._btnProductSearch.Click += new System.EventHandler(this.btnProductSearch_Click);
            //
            // _txtProductSearch
            //
            this._txtProductSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtProductSearch.Location = new System.Drawing.Point(168, 24);
            this._txtProductSearch.Name = "_txtProductSearch";
            this._txtProductSearch.Size = new System.Drawing.Size(1444, 21);
            this._txtProductSearch.TabIndex = 2;
            this._txtProductSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductSearch_KeyDown);
            //
            // _tabItemsIncluded
            //
            this._tabItemsIncluded.Controls.Add(this._GroupBox3);
            this._tabItemsIncluded.Location = new System.Drawing.Point(4, 22);
            this._tabItemsIncluded.Name = "_tabItemsIncluded";
            this._tabItemsIncluded.Size = new System.Drawing.Size(1796, 373);
            this._tabItemsIncluded.TabIndex = 8;
            this._tabItemsIncluded.Text = "Items Included";
            //
            // _GroupBox3
            //
            this._GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox3.Controls.Add(this._nudItemQty);
            this._GroupBox3.Controls.Add(this._btnEngineerReceived);
            this._GroupBox3.Controls.Add(this._btnReceiveAll);
            this._GroupBox3.Controls.Add(this._lblItemQty);
            this._GroupBox3.Controls.Add(this._btnItemQtyUpdate);
            this._GroupBox3.Controls.Add(this._dgItemsIncluded);
            this._GroupBox3.Location = new System.Drawing.Point(8, 8);
            this._GroupBox3.Name = "_GroupBox3";
            this._GroupBox3.Size = new System.Drawing.Size(1785, 361);
            this._GroupBox3.TabIndex = 0;
            this._GroupBox3.TabStop = false;
            this._GroupBox3.Text = "Double click to mark as received";
            //
            // _nudItemQty
            //
            this._nudItemQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._nudItemQty.Location = new System.Drawing.Point(70, 327);
            this._nudItemQty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._nudItemQty.Name = "_nudItemQty";
            this._nudItemQty.Size = new System.Drawing.Size(64, 21);
            this._nudItemQty.TabIndex = 30;
            this._nudItemQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // _btnEngineerReceived
            //
            this._btnEngineerReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnEngineerReceived.Location = new System.Drawing.Point(1536, 328);
            this._btnEngineerReceived.Name = "_btnEngineerReceived";
            this._btnEngineerReceived.Size = new System.Drawing.Size(134, 23);
            this._btnEngineerReceived.TabIndex = 12;
            this._btnEngineerReceived.Text = "Engineer Received";
            this._btnEngineerReceived.UseVisualStyleBackColor = true;
            this._btnEngineerReceived.Click += new System.EventHandler(this.btnEngineerReceived_Click);
            //
            // _btnReceiveAll
            //
            this._btnReceiveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnReceiveAll.Location = new System.Drawing.Point(1676, 328);
            this._btnReceiveAll.Name = "_btnReceiveAll";
            this._btnReceiveAll.Size = new System.Drawing.Size(101, 23);
            this._btnReceiveAll.TabIndex = 11;
            this._btnReceiveAll.Text = "Receive All";
            this._btnReceiveAll.UseVisualStyleBackColor = true;
            this._btnReceiveAll.Click += new System.EventHandler(this.btnReceiveAll_Click);
            //
            // _lblItemQty
            //
            this._lblItemQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblItemQty.Location = new System.Drawing.Point(8, 329);
            this._lblItemQty.Name = "_lblItemQty";
            this._lblItemQty.Size = new System.Drawing.Size(56, 21);
            this._lblItemQty.TabIndex = 10;
            this._lblItemQty.Text = "Quantity";
            //
            // _btnItemQtyUpdate
            //
            this._btnItemQtyUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnItemQtyUpdate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnItemQtyUpdate.Location = new System.Drawing.Point(149, 325);
            this._btnItemQtyUpdate.Name = "_btnItemQtyUpdate";
            this._btnItemQtyUpdate.Size = new System.Drawing.Size(64, 23);
            this._btnItemQtyUpdate.TabIndex = 3;
            this._btnItemQtyUpdate.Text = "Update";
            this._btnItemQtyUpdate.Click += new System.EventHandler(this.btnItemRemove_Click);
            //
            // _dgItemsIncluded
            //
            this._dgItemsIncluded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgItemsIncluded.DataMember = "";
            this._dgItemsIncluded.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgItemsIncluded.Location = new System.Drawing.Point(8, 20);
            this._dgItemsIncluded.Name = "_dgItemsIncluded";
            this._dgItemsIncluded.Size = new System.Drawing.Size(1769, 302);
            this._dgItemsIncluded.TabIndex = 1;
            this._dgItemsIncluded.Click += new System.EventHandler(this.dgItemsIncluded_Click);
            this._dgItemsIncluded.DoubleClick += new System.EventHandler(this.dgProduct_Click);
            //
            // _tabPartPriceReq
            //
            this._tabPartPriceReq.Controls.Add(this._GroupBox2);
            this._tabPartPriceReq.Location = new System.Drawing.Point(4, 22);
            this._tabPartPriceReq.Name = "_tabPartPriceReq";
            this._tabPartPriceReq.Size = new System.Drawing.Size(1796, 373);
            this._tabPartPriceReq.TabIndex = 7;
            this._tabPartPriceReq.Text = "Price Requests";
            //
            // _GroupBox2
            //
            this._GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox2.Controls.Add(this._btnUpdatePartPriceRequest);
            this._GroupBox2.Controls.Add(this._dgPriceRequests);
            this._GroupBox2.Location = new System.Drawing.Point(8, 8);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(1785, 361);
            this._GroupBox2.TabIndex = 1;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "Price requests for parts and products";
            //
            // _btnUpdatePartPriceRequest
            //
            this._btnUpdatePartPriceRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnUpdatePartPriceRequest.Location = new System.Drawing.Point(8, 329);
            this._btnUpdatePartPriceRequest.Name = "_btnUpdatePartPriceRequest";
            this._btnUpdatePartPriceRequest.Size = new System.Drawing.Size(75, 24);
            this._btnUpdatePartPriceRequest.TabIndex = 2;
            this._btnUpdatePartPriceRequest.Text = "Update";
            this._btnUpdatePartPriceRequest.Click += new System.EventHandler(this.btnUpdatePartPriceRequest_Click);
            //
            // _dgPriceRequests
            //
            this._dgPriceRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgPriceRequests.DataMember = "";
            this._dgPriceRequests.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgPriceRequests.Location = new System.Drawing.Point(8, 32);
            this._dgPriceRequests.Name = "_dgPriceRequests";
            this._dgPriceRequests.Size = new System.Drawing.Size(1769, 287);
            this._dgPriceRequests.TabIndex = 1;
            this._dgPriceRequests.CurrentCellChanged += new System.EventHandler(this.dgPriceRequests_Click);
            this._dgPriceRequests.Click += new System.EventHandler(this.dgPriceRequests_Click);
            //
            // _tabDocuments
            //
            this._tabDocuments.Controls.Add(this._pnlDocuments);
            this._tabDocuments.Controls.Add(this._btnEmail);
            this._tabDocuments.Controls.Add(this._cboPrintType);
            this._tabDocuments.Controls.Add(this._btnPrint);
            this._tabDocuments.Controls.Add(this._Label8);
            this._tabDocuments.Location = new System.Drawing.Point(4, 22);
            this._tabDocuments.Name = "_tabDocuments";
            this._tabDocuments.Size = new System.Drawing.Size(1796, 373);
            this._tabDocuments.TabIndex = 9;
            this._tabDocuments.Text = "Documents";
            //
            // _pnlDocuments
            //
            this._pnlDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlDocuments.Location = new System.Drawing.Point(8, 40);
            this._pnlDocuments.Name = "_pnlDocuments";
            this._pnlDocuments.Size = new System.Drawing.Size(1785, 324);
            this._pnlDocuments.TabIndex = 4;
            //
            // _btnEmail
            //
            this._btnEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnEmail.Location = new System.Drawing.Point(1329, 8);
            this._btnEmail.Name = "_btnEmail";
            this._btnEmail.Size = new System.Drawing.Size(104, 23);
            this._btnEmail.TabIndex = 3;
            this._btnEmail.Text = "Send Via Email";
            this._btnEmail.Visible = false;
            this._btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            //
            // _cboPrintType
            //
            this._cboPrintType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboPrintType.Location = new System.Drawing.Point(8, 8);
            this._cboPrintType.Name = "_cboPrintType";
            this._cboPrintType.Size = new System.Drawing.Size(1225, 21);
            this._cboPrintType.TabIndex = 1;
            //
            // _btnPrint
            //
            this._btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPrint.Location = new System.Drawing.Point(1241, 8);
            this._btnPrint.Name = "_btnPrint";
            this._btnPrint.Size = new System.Drawing.Size(56, 23);
            this._btnPrint.TabIndex = 2;
            this._btnPrint.Text = "Print";
            this._btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            //
            // _Label8
            //
            this._Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label8.Location = new System.Drawing.Point(1305, 12);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(18, 16);
            this._Label8.TabIndex = 45;
            this._Label8.Text = "or";
            this._Label8.Visible = false;
            //
            // _tabInvoices
            //
            this._tabInvoices.Controls.Add(this._grpReceivedInvoices);
            this._tabInvoices.Location = new System.Drawing.Point(4, 22);
            this._tabInvoices.Name = "_tabInvoices";
            this._tabInvoices.Size = new System.Drawing.Size(1796, 373);
            this._tabInvoices.TabIndex = 10;
            this._tabInvoices.Text = "Supplier Invoices";
            //
            // _grpReceivedInvoices
            //
            this._grpReceivedInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpReceivedInvoices.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._grpReceivedInvoices.Controls.Add(this._btnDeleteSupplierInvoice);
            this._grpReceivedInvoices.Controls.Add(this._btnUpdateSupplierInvoice);
            this._grpReceivedInvoices.Controls.Add(this._txtTotalAmount);
            this._grpReceivedInvoices.Controls.Add(this._lblTotalValue);
            this._grpReceivedInvoices.Controls.Add(this._txtVATAmount);
            this._grpReceivedInvoices.Controls.Add(this._txtNominalCodeNew);
            this._grpReceivedInvoices.Controls.Add(this._Label16);
            this._grpReceivedInvoices.Controls.Add(this._lblVatValue);
            this._grpReceivedInvoices.Controls.Add(this._txtGoodsAmount);
            this._grpReceivedInvoices.Controls.Add(this._cboInvoiceTaxCodeNew);
            this._grpReceivedInvoices.Controls.Add(this._txtExtraReferenceNew);
            this._grpReceivedInvoices.Controls.Add(this._Label13);
            this._grpReceivedInvoices.Controls.Add(this._lblGoodsValue);
            this._grpReceivedInvoices.Controls.Add(this._Label15);
            this._grpReceivedInvoices.Controls.Add(this._lblInvoiceDate);
            this._grpReceivedInvoices.Controls.Add(this._txtSupplierInvoiceRefNew);
            this._grpReceivedInvoices.Controls.Add(this._lblSupplierRef);
            this._grpReceivedInvoices.Controls.Add(this._btnAddSupplierInvoice);
            this._grpReceivedInvoices.Controls.Add(this._dgvReceivedInvoices);
            this._grpReceivedInvoices.Controls.Add(this._dtpSupplierInvoiceDateNew);
            this._grpReceivedInvoices.Controls.Add(this._cboReadySageNew);
            this._grpReceivedInvoices.Location = new System.Drawing.Point(4, 4);
            this._grpReceivedInvoices.Name = "_grpReceivedInvoices";
            this._grpReceivedInvoices.Size = new System.Drawing.Size(1789, 366);
            this._grpReceivedInvoices.TabIndex = 0;
            this._grpReceivedInvoices.TabStop = false;
            this._grpReceivedInvoices.Text = "Received Invoices";
            //
            // _btnDeleteSupplierInvoice
            //
            this._btnDeleteSupplierInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeleteSupplierInvoice.Location = new System.Drawing.Point(1603, 339);
            this._btnDeleteSupplierInvoice.Name = "_btnDeleteSupplierInvoice";
            this._btnDeleteSupplierInvoice.Size = new System.Drawing.Size(56, 24);
            this._btnDeleteSupplierInvoice.TabIndex = 121;
            this._btnDeleteSupplierInvoice.Text = "Delete";
            this._btnDeleteSupplierInvoice.Visible = false;
            this._btnDeleteSupplierInvoice.Click += new System.EventHandler(this.btnDeleteSupplierInvoice_Click);
            //
            // _btnUpdateSupplierInvoice
            //
            this._btnUpdateSupplierInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnUpdateSupplierInvoice.Location = new System.Drawing.Point(1665, 339);
            this._btnUpdateSupplierInvoice.Name = "_btnUpdateSupplierInvoice";
            this._btnUpdateSupplierInvoice.Size = new System.Drawing.Size(56, 24);
            this._btnUpdateSupplierInvoice.TabIndex = 122;
            this._btnUpdateSupplierInvoice.Text = "Update";
            this._btnUpdateSupplierInvoice.Visible = false;
            this._btnUpdateSupplierInvoice.Click += new System.EventHandler(this.btnUpdateSupplierInvoice_Click);
            //
            // _txtTotalAmount
            //
            this._txtTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtTotalAmount.Location = new System.Drawing.Point(547, 340);
            this._txtTotalAmount.Name = "_txtTotalAmount";
            this._txtTotalAmount.Size = new System.Drawing.Size(100, 21);
            this._txtTotalAmount.TabIndex = 109;
            //
            // _lblTotalValue
            //
            this._lblTotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblTotalValue.AutoSize = true;
            this._lblTotalValue.Location = new System.Drawing.Point(485, 343);
            this._lblTotalValue.Name = "_lblTotalValue";
            this._lblTotalValue.Size = new System.Drawing.Size(55, 13);
            this._lblTotalValue.TabIndex = 28;
            this._lblTotalValue.Text = "Total (£)";
            //
            // _txtVATAmount
            //
            this._txtVATAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtVATAmount.Location = new System.Drawing.Point(379, 340);
            this._txtVATAmount.Name = "_txtVATAmount";
            this._txtVATAmount.Size = new System.Drawing.Size(100, 21);
            this._txtVATAmount.TabIndex = 108;
            this._txtVATAmount.LostFocus += new System.EventHandler(this.txtVATAmount_LostFocus);
            //
            // _txtNominalCodeNew
            //
            this._txtNominalCodeNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtNominalCodeNew.Location = new System.Drawing.Point(633, 311);
            this._txtNominalCodeNew.MaxLength = 100;
            this._txtNominalCodeNew.Name = "_txtNominalCodeNew";
            this._txtNominalCodeNew.Size = new System.Drawing.Size(70, 21);
            this._txtNominalCodeNew.TabIndex = 105;
            this._txtNominalCodeNew.Tag = "Order.SupplierInvoiceReference";
            //
            // _Label16
            //
            this._Label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label16.Location = new System.Drawing.Point(568, 314);
            this._Label16.Name = "_Label16";
            this._Label16.Size = new System.Drawing.Size(70, 20);
            this._Label16.TabIndex = 65;
            this._Label16.Text = "Nominal";
            //
            // _lblVatValue
            //
            this._lblVatValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblVatValue.AutoSize = true;
            this._lblVatValue.Location = new System.Drawing.Point(322, 343);
            this._lblVatValue.Name = "_lblVatValue";
            this._lblVatValue.Size = new System.Drawing.Size(50, 13);
            this._lblVatValue.TabIndex = 26;
            this._lblVatValue.Text = "VAT (£)";
            //
            // _txtGoodsAmount
            //
            this._txtGoodsAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtGoodsAmount.Location = new System.Drawing.Point(76, 340);
            this._txtGoodsAmount.Name = "_txtGoodsAmount";
            this._txtGoodsAmount.Size = new System.Drawing.Size(100, 21);
            this._txtGoodsAmount.TabIndex = 106;
            this._txtGoodsAmount.LostFocus += new System.EventHandler(this.txtGoodsAmount_TextChanged);
            //
            // _cboInvoiceTaxCodeNew
            //
            this._cboInvoiceTaxCodeNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cboInvoiceTaxCodeNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboInvoiceTaxCodeNew.Location = new System.Drawing.Point(258, 340);
            this._cboInvoiceTaxCodeNew.Name = "_cboInvoiceTaxCodeNew";
            this._cboInvoiceTaxCodeNew.Size = new System.Drawing.Size(58, 21);
            this._cboInvoiceTaxCodeNew.TabIndex = 107;
            this._cboInvoiceTaxCodeNew.SelectedIndexChanged += new System.EventHandler(this.cboTaxCode_SelectedIndexChanged);
            //
            // _txtExtraReferenceNew
            //
            this._txtExtraReferenceNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtExtraReferenceNew.Location = new System.Drawing.Point(493, 311);
            this._txtExtraReferenceNew.MaxLength = 100;
            this._txtExtraReferenceNew.Name = "_txtExtraReferenceNew";
            this._txtExtraReferenceNew.Size = new System.Drawing.Size(70, 21);
            this._txtExtraReferenceNew.TabIndex = 104;
            this._txtExtraReferenceNew.Tag = "Order.SupplierInvoiceReference";
            //
            // _Label13
            //
            this._Label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label13.Location = new System.Drawing.Point(182, 343);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(70, 20);
            this._Label13.TabIndex = 59;
            this._Label13.Text = "Tax Code";
            //
            // _lblGoodsValue
            //
            this._lblGoodsValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblGoodsValue.AutoSize = true;
            this._lblGoodsValue.Location = new System.Drawing.Point(6, 343);
            this._lblGoodsValue.Name = "_lblGoodsValue";
            this._lblGoodsValue.Size = new System.Drawing.Size(64, 13);
            this._lblGoodsValue.TabIndex = 24;
            this._lblGoodsValue.Text = "Goods (£)";
            //
            // _Label15
            //
            this._Label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label15.Location = new System.Drawing.Point(435, 314);
            this._Label15.Name = "_Label15";
            this._Label15.Size = new System.Drawing.Size(56, 20);
            this._Label15.TabIndex = 63;
            this._Label15.Text = "Ex Ref.";
            //
            // _lblInvoiceDate
            //
            this._lblInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblInvoiceDate.AutoSize = true;
            this._lblInvoiceDate.Location = new System.Drawing.Point(6, 314);
            this._lblInvoiceDate.Name = "_lblInvoiceDate";
            this._lblInvoiceDate.Size = new System.Drawing.Size(80, 13);
            this._lblInvoiceDate.TabIndex = 1;
            this._lblInvoiceDate.Text = "Invoice Date";
            //
            // _txtSupplierInvoiceRefNew
            //
            this._txtSupplierInvoiceRefNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtSupplierInvoiceRefNew.Location = new System.Drawing.Point(329, 311);
            this._txtSupplierInvoiceRefNew.Name = "_txtSupplierInvoiceRefNew";
            this._txtSupplierInvoiceRefNew.Size = new System.Drawing.Size(100, 21);
            this._txtSupplierInvoiceRefNew.TabIndex = 103;
            //
            // _lblSupplierRef
            //
            this._lblSupplierRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblSupplierRef.AutoSize = true;
            this._lblSupplierRef.Location = new System.Drawing.Point(242, 314);
            this._lblSupplierRef.Name = "_lblSupplierRef";
            this._lblSupplierRef.Size = new System.Drawing.Size(75, 13);
            this._lblSupplierRef.TabIndex = 1;
            this._lblSupplierRef.Text = "Invoice Ref.";
            //
            // _btnAddSupplierInvoice
            //
            this._btnAddSupplierInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddSupplierInvoice.Location = new System.Drawing.Point(1727, 339);
            this._btnAddSupplierInvoice.Name = "_btnAddSupplierInvoice";
            this._btnAddSupplierInvoice.Size = new System.Drawing.Size(56, 24);
            this._btnAddSupplierInvoice.TabIndex = 123;
            this._btnAddSupplierInvoice.Text = "Add ";
            this._btnAddSupplierInvoice.Click += new System.EventHandler(this.btnAddSupplierInvoice_Click);
            //
            // _dgvReceivedInvoices
            //
            this._dgvReceivedInvoices.AllowUserToAddRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvReceivedInvoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this._dgvReceivedInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvReceivedInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvReceivedInvoices.BackgroundColor = System.Drawing.Color.White;
            this._dgvReceivedInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvReceivedInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this._dgvReceivedInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvReceivedInvoices.EnableHeadersVisualStyles = false;
            this._dgvReceivedInvoices.GridColor = System.Drawing.Color.LightSteelBlue;
            this._dgvReceivedInvoices.Location = new System.Drawing.Point(3, 17);
            this._dgvReceivedInvoices.MultiSelect = false;
            this._dgvReceivedInvoices.Name = "_dgvReceivedInvoices";
            this._dgvReceivedInvoices.RowHeadersVisible = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvReceivedInvoices.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this._dgvReceivedInvoices.RowTemplate.Height = 29;
            this._dgvReceivedInvoices.RowTemplate.ReadOnly = true;
            this._dgvReceivedInvoices.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._dgvReceivedInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvReceivedInvoices.Size = new System.Drawing.Size(1780, 288);
            this._dgvReceivedInvoices.TabIndex = 0;
            this._dgvReceivedInvoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceivedInvoices_CellClick);
            //
            // _dtpSupplierInvoiceDateNew
            //
            this._dtpSupplierInvoiceDateNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._dtpSupplierInvoiceDateNew.Location = new System.Drawing.Point(92, 311);
            this._dtpSupplierInvoiceDateNew.Name = "_dtpSupplierInvoiceDateNew";
            this._dtpSupplierInvoiceDateNew.Size = new System.Drawing.Size(144, 21);
            this._dtpSupplierInvoiceDateNew.TabIndex = 101;
            this._dtpSupplierInvoiceDateNew.Tag = "Order.SupplierInvoiceDate";
            //
            // _cboReadySageNew
            //
            this._cboReadySageNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cboReadySageNew.Location = new System.Drawing.Point(653, 338);
            this._cboReadySageNew.Name = "_cboReadySageNew";
            this._cboReadySageNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._cboReadySageNew.Size = new System.Drawing.Size(247, 24);
            this._cboReadySageNew.TabIndex = 110;
            this._cboReadySageNew.Text = "Ready to send to Accounts Package";
            //
            // _TabPage1
            //
            this._TabPage1.Controls.Add(this._GroupBox4);
            this._TabPage1.Location = new System.Drawing.Point(4, 22);
            this._TabPage1.Name = "_TabPage1";
            this._TabPage1.Size = new System.Drawing.Size(1796, 373);
            this._TabPage1.TabIndex = 11;
            this._TabPage1.Text = "Credits";
            this._TabPage1.UseVisualStyleBackColor = true;
            //
            // _GroupBox4
            //
            this._GroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._GroupBox4.Controls.Add(this._Button1);
            this._GroupBox4.Controls.Add(this._CheckBox1);
            this._GroupBox4.Controls.Add(this._txtCreditExRef);
            this._GroupBox4.Controls.Add(this._Label21);
            this._GroupBox4.Controls.Add(this._btnCreditDelete);
            this._GroupBox4.Controls.Add(this._txtCreditTotal);
            this._GroupBox4.Controls.Add(this._Label9);
            this._GroupBox4.Controls.Add(this._txtCreditVAT);
            this._GroupBox4.Controls.Add(this._txtCreditNominal);
            this._GroupBox4.Controls.Add(this._Label10);
            this._GroupBox4.Controls.Add(this._Label14);
            this._GroupBox4.Controls.Add(this._txtCreditGoods);
            this._GroupBox4.Controls.Add(this._cboCreditTax);
            this._GroupBox4.Controls.Add(this._Label18);
            this._GroupBox4.Controls.Add(this._Label20);
            this._GroupBox4.Controls.Add(this._txtCreditRef);
            this._GroupBox4.Controls.Add(this._Label23);
            this._GroupBox4.Controls.Add(this._btnCreditAdd);
            this._GroupBox4.Controls.Add(this._dgCredits);
            this._GroupBox4.Controls.Add(this._dtpCreditDate);
            this._GroupBox4.Location = new System.Drawing.Point(3, 4);
            this._GroupBox4.Name = "_GroupBox4";
            this._GroupBox4.Size = new System.Drawing.Size(1789, 366);
            this._GroupBox4.TabIndex = 1;
            this._GroupBox4.TabStop = false;
            this._GroupBox4.Text = "Part Credits";
            //
            // _Button1
            //
            this._Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Button1.Location = new System.Drawing.Point(1495, 339);
            this._Button1.Name = "_Button1";
            this._Button1.Size = new System.Drawing.Size(142, 24);
            this._Button1.TabIndex = 127;
            this._Button1.Text = "Convert to Van stock";
            this._Button1.Click += new System.EventHandler(this.Button1_Click);
            //
            // _CheckBox1
            //
            this._CheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._CheckBox1.Location = new System.Drawing.Point(-20, 312);
            this._CheckBox1.Name = "_CheckBox1";
            this._CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._CheckBox1.Size = new System.Drawing.Size(141, 24);
            this._CheckBox1.TabIndex = 126;
            this._CheckBox1.Text = "Credit Recieved";
            //
            // _txtCreditExRef
            //
            this._txtCreditExRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtCreditExRef.Location = new System.Drawing.Point(1118, 339);
            this._txtCreditExRef.MaxLength = 100;
            this._txtCreditExRef.Name = "_txtCreditExRef";
            this._txtCreditExRef.Size = new System.Drawing.Size(70, 21);
            this._txtCreditExRef.TabIndex = 125;
            this._txtCreditExRef.Tag = "Order.SupplierInvoiceReference";
            //
            // _Label21
            //
            this._Label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label21.Location = new System.Drawing.Point(1073, 342);
            this._Label21.Name = "_Label21";
            this._Label21.Size = new System.Drawing.Size(56, 20);
            this._Label21.TabIndex = 124;
            this._Label21.Text = "Ex Ref.";
            //
            // _btnCreditDelete
            //
            this._btnCreditDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCreditDelete.Location = new System.Drawing.Point(1656, 339);
            this._btnCreditDelete.Name = "_btnCreditDelete";
            this._btnCreditDelete.Size = new System.Drawing.Size(56, 24);
            this._btnCreditDelete.TabIndex = 121;
            this._btnCreditDelete.Text = "Delete";
            this._btnCreditDelete.Visible = false;
            this._btnCreditDelete.Click += new System.EventHandler(this.btnDeleteCredit_Click);
            //
            // _txtCreditTotal
            //
            this._txtCreditTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtCreditTotal.Location = new System.Drawing.Point(539, 342);
            this._txtCreditTotal.Name = "_txtCreditTotal";
            this._txtCreditTotal.Size = new System.Drawing.Size(68, 21);
            this._txtCreditTotal.TabIndex = 109;
            //
            // _Label9
            //
            this._Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label9.AutoSize = true;
            this._Label9.Location = new System.Drawing.Point(467, 345);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(55, 13);
            this._Label9.TabIndex = 28;
            this._Label9.Text = "Total (£)";
            //
            // _txtCreditVAT
            //
            this._txtCreditVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtCreditVAT.Location = new System.Drawing.Point(372, 341);
            this._txtCreditVAT.Name = "_txtCreditVAT";
            this._txtCreditVAT.Size = new System.Drawing.Size(68, 21);
            this._txtCreditVAT.TabIndex = 108;
            this._txtCreditVAT.LostFocus += new System.EventHandler(this.txtCreditVAT__LostFocus);
            //
            // _txtCreditNominal
            //
            this._txtCreditNominal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtCreditNominal.Location = new System.Drawing.Point(1000, 339);
            this._txtCreditNominal.MaxLength = 100;
            this._txtCreditNominal.Name = "_txtCreditNominal";
            this._txtCreditNominal.Size = new System.Drawing.Size(70, 21);
            this._txtCreditNominal.TabIndex = 105;
            this._txtCreditNominal.Tag = "Order.SupplierInvoiceReference";
            //
            // _Label10
            //
            this._Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label10.Location = new System.Drawing.Point(947, 342);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(70, 20);
            this._Label10.TabIndex = 65;
            this._Label10.Text = "Nominal";
            //
            // _Label14
            //
            this._Label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label14.AutoSize = true;
            this._Label14.Location = new System.Drawing.Point(309, 344);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(50, 13);
            this._Label14.TabIndex = 26;
            this._Label14.Text = "VAT (£)";
            //
            // _txtCreditGoods
            //
            this._txtCreditGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtCreditGoods.Location = new System.Drawing.Point(95, 340);
            this._txtCreditGoods.Name = "_txtCreditGoods";
            this._txtCreditGoods.Size = new System.Drawing.Size(54, 21);
            this._txtCreditGoods.TabIndex = 106;
            this._txtCreditGoods.LostFocus += new System.EventHandler(this.txtCreditAmount_TextChanged);
            //
            // _cboCreditTax
            //
            this._cboCreditTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cboCreditTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboCreditTax.Location = new System.Drawing.Point(238, 340);
            this._cboCreditTax.Name = "_cboCreditTax";
            this._cboCreditTax.Size = new System.Drawing.Size(46, 21);
            this._cboCreditTax.TabIndex = 107;
            this._cboCreditTax.SelectedIndexChanged += new System.EventHandler(this.cboCreditTaxCode_SelectedIndexChanged);
            //
            // _Label18
            //
            this._Label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label18.Location = new System.Drawing.Point(168, 342);
            this._Label18.Name = "_Label18";
            this._Label18.Size = new System.Drawing.Size(70, 20);
            this._Label18.TabIndex = 59;
            this._Label18.Text = "Tax Code";
            //
            // _Label20
            //
            this._Label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label20.AutoSize = true;
            this._Label20.Location = new System.Drawing.Point(6, 343);
            this._Label20.Name = "_Label20";
            this._Label20.Size = new System.Drawing.Size(86, 13);
            this._Label20.TabIndex = 24;
            this._Label20.Text = "Credit Net (£)";
            //
            // _txtCreditRef
            //
            this._txtCreditRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtCreditRef.Location = new System.Drawing.Point(871, 339);
            this._txtCreditRef.Name = "_txtCreditRef";
            this._txtCreditRef.Size = new System.Drawing.Size(70, 21);
            this._txtCreditRef.TabIndex = 103;
            //
            // _Label23
            //
            this._Label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label23.AutoSize = true;
            this._Label23.Location = new System.Drawing.Point(801, 344);
            this._Label23.Name = "_Label23";
            this._Label23.Size = new System.Drawing.Size(68, 13);
            this._Label23.TabIndex = 1;
            this._Label23.Text = "Credit Ref.";
            //
            // _btnCreditAdd
            //
            this._btnCreditAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCreditAdd.Location = new System.Drawing.Point(1727, 339);
            this._btnCreditAdd.Name = "_btnCreditAdd";
            this._btnCreditAdd.Size = new System.Drawing.Size(56, 24);
            this._btnCreditAdd.TabIndex = 123;
            this._btnCreditAdd.Text = "Add ";
            this._btnCreditAdd.Click += new System.EventHandler(this.btnCreditAdd_Click);
            //
            // _dgCredits
            //
            this._dgCredits.AllowUserToAddRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgCredits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this._dgCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgCredits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgCredits.BackgroundColor = System.Drawing.Color.White;
            this._dgCredits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgCredits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this._dgCredits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgCredits.EnableHeadersVisualStyles = false;
            this._dgCredits.GridColor = System.Drawing.Color.LightSteelBlue;
            this._dgCredits.Location = new System.Drawing.Point(3, 23);
            this._dgCredits.MultiSelect = false;
            this._dgCredits.Name = "_dgCredits";
            this._dgCredits.RowHeadersVisible = false;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dgCredits.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this._dgCredits.RowTemplate.Height = 29;
            this._dgCredits.RowTemplate.ReadOnly = true;
            this._dgCredits.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._dgCredits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgCredits.Size = new System.Drawing.Size(1780, 288);
            this._dgCredits.TabIndex = 0;
            this._dgCredits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCredits_CellClick);
            //
            // _dtpCreditDate
            //
            this._dtpCreditDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._dtpCreditDate.Location = new System.Drawing.Point(128, 313);
            this._dtpCreditDate.Name = "_dtpCreditDate";
            this._dtpCreditDate.Size = new System.Drawing.Size(142, 21);
            this._dtpCreditDate.TabIndex = 101;
            this._dtpCreditDate.Tag = "Order.SupplierInvoiceDate";
            //
            // _lblOrderStatus
            //
            this._lblOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblOrderStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._lblOrderStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOrderStatus.Location = new System.Drawing.Point(16, 129);
            this._lblOrderStatus.Name = "_lblOrderStatus";
            this._lblOrderStatus.Size = new System.Drawing.Size(1510, 353);
            this._lblOrderStatus.TabIndex = 0;
            this._lblOrderStatus.Click += new System.EventHandler(this.lblOrderStatus_Click);
            //
            // _GroupBox1
            //
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._lblCredits);
            this._GroupBox1.Controls.Add(this._Label25);
            this._GroupBox1.Controls.Add(this._lblSupplierGoods);
            this._GroupBox1.Controls.Add(this._lblGoodsTotal);
            this._GroupBox1.Location = new System.Drawing.Point(1412, 36);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(275, 63);
            this._GroupBox1.TabIndex = 76;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Supplier Invoice Totals";
            //
            // _lblCredits
            //
            this._lblCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblCredits.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblCredits.Location = new System.Drawing.Point(138, 37);
            this._lblCredits.Name = "_lblCredits";
            this._lblCredits.Size = new System.Drawing.Size(122, 15);
            this._lblCredits.TabIndex = 80;
            this._lblCredits.Text = "£0.00";
            this._lblCredits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // _Label25
            //
            this._Label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label25.AutoSize = true;
            this._Label25.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label25.Location = new System.Drawing.Point(14, 40);
            this._Label25.Name = "_Label25";
            this._Label25.Size = new System.Drawing.Size(123, 13);
            this._Label25.TabIndex = 81;
            this._Label25.Text = "Supplier Credits : ";
            this._Label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // _lblSupplierGoods
            //
            this._lblSupplierGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblSupplierGoods.AutoSize = true;
            this._lblSupplierGoods.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblSupplierGoods.Location = new System.Drawing.Point(14, 19);
            this._lblSupplierGoods.Name = "_lblSupplierGoods";
            this._lblSupplierGoods.Size = new System.Drawing.Size(133, 13);
            this._lblSupplierGoods.TabIndex = 73;
            this._lblSupplierGoods.Text = "Supplier Invoices : ";
            this._lblSupplierGoods.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // _lblGoodsTotal
            //
            this._lblGoodsTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblGoodsTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblGoodsTotal.Location = new System.Drawing.Point(138, 17);
            this._lblGoodsTotal.Name = "_lblGoodsTotal";
            this._lblGoodsTotal.Size = new System.Drawing.Size(122, 15);
            this._lblGoodsTotal.TabIndex = 70;
            this._lblGoodsTotal.Text = "£0.00";
            this._lblGoodsTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // _Label17
            //
            this._Label17.Location = new System.Drawing.Point(6, 97);
            this._Label17.Name = "_Label17";
            this._Label17.Size = new System.Drawing.Size(79, 20);
            this._Label17.TabIndex = 68;
            this._Label17.Text = "Cost Centre";
            //
            // _FSMDataSetBindingSource
            //
            this._FSMDataSetBindingSource.Position = 0;
            //
            // UCOrder
            //
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this._grpOrder);
            this.Name = "UCOrder";
            this.Size = new System.Drawing.Size(1700, 900);
            this._grpOrder.ResumeLayout(false);
            this._grpOrder.PerformLayout();
            this._tcOrderDetails.ResumeLayout(false);
            this._tabDetails.ResumeLayout(false);
            this._tabParts.ResumeLayout(false);
            this._grpPartSearch.ResumeLayout(false);
            this._grpPartSearch.PerformLayout();
            this._grpAvailableParts.ResumeLayout(false);
            this._grpAvailableParts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgParts)).EndInit();
            this._tabProducts.ResumeLayout(false);
            this._grpProductsAvailable.ResumeLayout(false);
            this._grpProductsAvailable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgProduct)).EndInit();
            this._grpProductSearch.ResumeLayout(false);
            this._grpProductSearch.PerformLayout();
            this._tabItemsIncluded.ResumeLayout(false);
            this._GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._nudItemQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgItemsIncluded)).EndInit();
            this._tabPartPriceReq.ResumeLayout(false);
            this._GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgPriceRequests)).EndInit();
            this._tabDocuments.ResumeLayout(false);
            this._tabInvoices.ResumeLayout(false);
            this._grpReceivedInvoices.ResumeLayout(false);
            this._grpReceivedInvoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvReceivedInvoices)).EndInit();
            this._TabPage1.ResumeLayout(false);
            this._GroupBox4.ResumeLayout(false);
            this._GroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCredits)).EndInit();
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._FSMDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
        }

        public void LoadForm(object sender, EventArgs e)
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

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

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
                if (Conversions.ToBoolean((int)row["QuantityOnOrder"] > (int)row["QuantityReceived"]))
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

        public class ColourColumn : DataGridLabelColumn
        {
            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                // set the color required dependant on the column value
                Brush brush;
                DataRowView dr = (DataRowView)source.List[rowNum];
                brush = Brushes.White;
                if (Helper.MakeBooleanValid(dr["Preferred"]))
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
                                    case (int)(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case (int)(Enums.OrderType.Warehouse):
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
                                    case (int)(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case (int)(Enums.OrderType.Warehouse):
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
                                    case (int)(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case (int)(Enums.OrderType.Warehouse):
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
                                    case (int)(Enums.OrderType.Customer):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)(Enums.OrderType.Job):
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)(Enums.OrderType.StockProfile):
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case (int)(Enums.OrderType.Warehouse):
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
                if (!(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboOrderStatus)) == (int)Enums.OrderStatus.Confirmed))
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
                    if (Conversions.ToBoolean((int)row["Quantity"] >= oOrderPart.Quantity))
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
                                        if (Conversions.ToBoolean((int)row["Quantity"] >= oOrderProduct.Quantity))
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

                    if (Conversions.ToBoolean((int)SelectedItemIncludedDataRow["QuantityReceived"] > 0))
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
                                    if (Conversions.ToBoolean((int)drOrd["OrderStatusID"] < Conversions.ToInteger(Enums.OrderStatus.Complete)))
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
                decimal itemAmount = 0;
                decimal invoiceTotal = 0;
                foreach (DataRow row in ItemsIncludedDataView.Table.Rows)
                    itemAmount += (decimal)row["BuyPrice"] * (int)row["QuantityOnOrder"];
                // PLUS ADDITIONAL
                foreach (DataRow row in App.DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID).Table.Rows)
                    itemAmount += (decimal)row["Amount"];

                // GET EXISTING SUPPLIER INVOICES
                foreach (DataRow row in App.DB.SupplierInvoices.Order_GetSupplierInvoices(CurrentOrder.OrderID).Table.Rows)
                    invoiceTotal += (decimal)row["SupplierInvoiceAmount"];
                decimal CurrentTotal = 0;
                if (Update)
                {
                    decimal UpdateingAmount = Conversions.ToDecimal(Strings.Replace(Conversions.ToString(dgvReceivedInvoices["SupplierInvoiceAmount", dgvReceivedInvoices.CurrentRow.Index].Value), "£", ""));
                    CurrentTotal = invoiceTotal - UpdateingAmount + Conversions.ToDecimal(Strings.Replace(txtGoodsAmount.Text, "£", "")) - 0.05M;
                }
                else
                {
                    CurrentTotal = invoiceTotal + Conversions.ToDecimal(Strings.Replace(txtGoodsAmount.Text, "£", "")) - 0.05M;
                }

                if (CurrentTotal > Conversions.ToDecimal(Strings.Format(itemAmount, "F")))
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
                decimal itemAmount = 0;
                decimal invoiceTotal = 0;
                decimal CurrentTotal = 0;
            }

            return NoError;
        }

        public void Populate(int ID = 0)
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
            decimal total = 0;
            foreach (DataRow row in ItemsIncludedDataView.Table.Rows)
                total += (decimal)row["BuyPrice"] * (int)row["QuantityOnOrder"];
            foreach (DataRow row in App.DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID).Table.Rows)
                total += (decimal)row["Amount"];
            lblOrderTotal.Text = Strings.Format(total, "C");
            decimal GoodsTotal = 0;
            decimal VATTotal = 0;
            decimal GrandTotal = 0;
            foreach (DataRow row in App.DB.SupplierInvoices.Order_GetSupplierInvoices(CurrentOrder.OrderID).Table.Rows)
            {
                GoodsTotal += (decimal)row["SupplierInvoiceAmount"];
                VATTotal += (decimal)row["SupplierVATAmount"];
                GrandTotal += (decimal)row["SupplierGoodsAmount"];
            }

            lblGoodsTotal.Text = Strings.Format(GoodsTotal, "C");
            lblCredits.Text = "0";
            foreach (DataRow row in App.DB.ExecuteWithReturn("select (AmountReceived) as CreditReceived from tblPartCredits pc inner join (sELECT MAX(tblPartCreditParts.PartsToBeCreditedID) AS MAXIMUN ,PartCreditID  FROM tblPartCreditParts group by PartCreditID) pcp on pcp.PartCreditID = pc.PartCreditsID inner join tblPartsToBeCredited tbc ON tbc.PartsToBeCreditedID = pcp.maximun WHERE OrderID = " + CurrentOrder.OrderID).Rows)
                lblCredits.Text = lblCredits.Text + row["CreditReceived"];
            decimal OrderBalance = total - GoodsTotal + Conversions.ToDecimal(lblCredits.Text);
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

                case object _ when Helper.MakeDoubleValid(switchExpr) < 0:
                    {
                        lblOrderBalance.ForeColor = Color.Red;
                        break;
                    }

                case object _ when Helper.MakeDoubleValid(switchExpr) > 0:
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
                case (int)(Enums.OrderStatus.Complete):
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
                            if (Conversions.ToBoolean((int)row["Quantity"] > 0))
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
    }
}