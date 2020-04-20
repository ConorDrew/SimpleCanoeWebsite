using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCGenerateQuote : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCGenerateQuote() : base()
        {
            base.Load += UCGenerateQuote_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboUsers;
            Combo.SetUpCombo(ref argc, App.DB.User.GetAll().Table, "UserID", "FullName", Entity.Sys.Enums.ComboValues.Please_Select);
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
        private TabControl _tcQuote;

        internal TabControl tcQuote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcQuote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcQuote != null)
                {
                }

                _tcQuote = value;
                if (_tcQuote != null)
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

        private TabPage _tabItems;

        internal TabPage tabItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabItems != null)
                {
                }

                _tabItems = value;
                if (_tabItems != null)
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

        private DataGrid _dgProducts;

        internal DataGrid dgProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgProducts != null)
                {
                }

                _dgProducts = value;
                if (_dgProducts != null)
                {
                }
            }
        }

        private Button _btnRemoveProducts;

        internal Button btnRemoveProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveProducts != null)
                {
                    _btnRemoveProducts.Click -= btnRemoveProducts_Click;
                }

                _btnRemoveProducts = value;
                if (_btnRemoveProducts != null)
                {
                    _btnRemoveProducts.Click += btnRemoveProducts_Click;
                }
            }
        }

        private Button _btnFindProduct;

        internal Button btnFindProduct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindProduct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindProduct != null)
                {
                    _btnFindProduct.Click -= btnFindProduct_Click;
                }

                _btnFindProduct = value;
                if (_btnFindProduct != null)
                {
                    _btnFindProduct.Click += btnFindProduct_Click;
                }
            }
        }

        private Button _btnFindPart;

        internal Button btnFindPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindPart != null)
                {
                    _btnFindPart.Click -= btnFindPart_Click;
                }

                _btnFindPart = value;
                if (_btnFindPart != null)
                {
                    _btnFindPart.Click += btnFindPart_Click;
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
                }

                _dgParts = value;
                if (_dgParts != null)
                {
                }
            }
        }

        private Button _btnRemoveParts;

        internal Button btnRemoveParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveParts != null)
                {
                    _btnRemoveParts.Click -= btnRemoveParts_Click;
                }

                _btnRemoveParts = value;
                if (_btnRemoveParts != null)
                {
                    _btnRemoveParts.Click += btnRemoveParts_Click;
                }
            }
        }

        private TextBox _txtAvailability;

        internal TextBox txtAvailability
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAvailability;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAvailability != null)
                {
                }

                _txtAvailability = value;
                if (_txtAvailability != null)
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

        private TextBox _txtPriceExcludeDetails;

        internal TextBox txtPriceExcludeDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPriceExcludeDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPriceExcludeDetails != null)
                {
                }

                _txtPriceExcludeDetails = value;
                if (_txtPriceExcludeDetails != null)
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

        private TextBox _txtPriceDetails;

        internal TextBox txtPriceDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPriceDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPriceDetails != null)
                {
                }

                _txtPriceDetails = value;
                if (_txtPriceDetails != null)
                {
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

        private DateTimePicker _dtpValidUntil;

        internal DateTimePicker dtpValidUntil
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpValidUntil;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpValidUntil != null)
                {
                }

                _dtpValidUntil = value;
                if (_dtpValidUntil != null)
                {
                }
            }
        }

        private Label _Label12;

        internal Label Label12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label12 != null)
                {
                }

                _Label12 = value;
                if (_Label12 != null)
                {
                }
            }
        }

        private DateTimePicker _dtpEnquiryDate;

        internal DateTimePicker dtpEnquiryDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpEnquiryDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpEnquiryDate != null)
                {
                }

                _dtpEnquiryDate = value;
                if (_dtpEnquiryDate != null)
                {
                }
            }
        }

        private Label _Label11;

        internal Label Label11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label11 != null)
                {
                }

                _Label11 = value;
                if (_Label11 != null)
                {
                }
            }
        }

        private TextBox _txtCustRef;

        internal TextBox txtCustRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustRef != null)
                {
                }

                _txtCustRef = value;
                if (_txtCustRef != null)
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

        private ComboBox _cboUsers;

        internal ComboBox cboUsers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUsers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboUsers != null)
                {
                }

                _cboUsers = value;
                if (_cboUsers != null)
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

        private Button _btnFindContact;

        internal Button btnFindContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindContact != null)
                {
                    _btnFindContact.Click -= btnFindContact_Click;
                }

                _btnFindContact = value;
                if (_btnFindContact != null)
                {
                    _btnFindContact.Click += btnFindContact_Click;
                }
            }
        }

        private TextBox _txtContact;

        internal TextBox txtContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContact != null)
                {
                }

                _txtContact = value;
                if (_txtContact != null)
                {
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

        private Button _btnFindInvoiceAddress;

        internal Button btnFindInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindInvoiceAddress != null)
                {
                    _btnFindInvoiceAddress.Click -= btnFindInvoiceAddress_Click;
                }

                _btnFindInvoiceAddress = value;
                if (_btnFindInvoiceAddress != null)
                {
                    _btnFindInvoiceAddress.Click += btnFindInvoiceAddress_Click;
                }
            }
        }

        private TextBox _txtInvoiceAddress;

        internal TextBox txtInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvoiceAddress != null)
                {
                }

                _txtInvoiceAddress = value;
                if (_txtInvoiceAddress != null)
                {
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

        private TextBox _txtSpecialInstructions;

        internal TextBox txtSpecialInstructions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSpecialInstructions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSpecialInstructions != null)
                {
                }

                _txtSpecialInstructions = value;
                if (_txtSpecialInstructions != null)
                {
                }
            }
        }

        private Button _btnFindSite;

        internal Button btnFindSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click -= btnFindSite_Click;
                }

                _btnFindSite = value;
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click += btnFindSite_Click;
                }
            }
        }

        private TextBox _txtSite;

        internal TextBox txtSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSite != null)
                {
                }

                _txtSite = value;
                if (_txtSite != null)
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

        private Button _btnFindCustomer;

        internal Button btnFindCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click -= btnFindCustomer_Click;
                }

                _btnFindCustomer = value;
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click += btnFindCustomer_Click;
                }
            }
        }

        private TextBox _txtCustomer;

        internal TextBox txtCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomer != null)
                {
                }

                _txtCustomer = value;
                if (_txtCustomer != null)
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

        private ComboBox _cboStatus;

        internal ComboBox cboStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboStatus != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _cboStatus.SelectedIndexChanged -= cboStatus_SelectedIndexChanged;
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                    _cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
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

        private TabPage _tabRequests;

        internal TabPage tabRequests
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabRequests;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabRequests != null)
                {
                }

                _tabRequests = value;
                if (_tabRequests != null)
                {
                }
            }
        }

        private Button _btnSearch;

        internal Button btnSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSearch != null)
                {
                    _btnSearch.Click -= btnSearch_Click;
                }

                _btnSearch = value;
                if (_btnSearch != null)
                {
                    _btnSearch.Click += btnSearch_Click;
                }
            }
        }

        private Label _lblSearch;

        internal Label lblSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSearch != null)
                {
                }

                _lblSearch = value;
                if (_lblSearch != null)
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
                    _dgPriceRequests.DoubleClick -= dgPriceRequests_DoubleClick;
                }

                _dgPriceRequests = value;
                if (_dgPriceRequests != null)
                {
                    _dgPriceRequests.DoubleClick += dgPriceRequests_DoubleClick;
                }
            }
        }

        private Button _btnUpdate;

        internal Button btnUpdate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdate != null)
                {
                    _btnUpdate.Click -= btnUpdate_Click;
                }

                _btnUpdate = value;
                if (_btnUpdate != null)
                {
                    _btnUpdate.Click += btnUpdate_Click;
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

        private DataGrid _dgConfirmedPriceRequests;

        internal DataGrid dgConfirmedPriceRequests
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgConfirmedPriceRequests;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgConfirmedPriceRequests != null)
                {
                }

                _dgConfirmedPriceRequests = value;
                if (_dgConfirmedPriceRequests != null)
                {
                }
            }
        }

        private Label _lblWarehouse;

        internal Label lblWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblWarehouse != null)
                {
                }

                _lblWarehouse = value;
                if (_lblWarehouse != null)
                {
                }
            }
        }

        private TextBox _txtWarehouse;

        internal TextBox txtWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtWarehouse != null)
                {
                }

                _txtWarehouse = value;
                if (_txtWarehouse != null)
                {
                }
            }
        }

        private Button _btnFindWarehouse;

        internal Button btnFindWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindWarehouse != null)
                {
                    _btnFindWarehouse.Click -= btnFindWarehouse_Click;
                }

                _btnFindWarehouse = value;
                if (_btnFindWarehouse != null)
                {
                    _btnFindWarehouse.Click += btnFindWarehouse_Click;
                }
            }
        }

        private Label _lblSpecial;

        internal Label lblSpecial
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSpecial;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSpecial != null)
                {
                }

                _lblSpecial = value;
                if (_lblSpecial != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _tcQuote = new TabControl();
            _tabDetails = new TabPage();
            _btnFindWarehouse = new Button();
            _btnFindWarehouse.Click += new EventHandler(btnFindWarehouse_Click);
            _txtWarehouse = new TextBox();
            _lblWarehouse = new Label();
            _Label3 = new Label();
            _cboStatus = new ComboBox();
            _cboStatus.SelectedIndexChanged += new EventHandler(cboStatus_SelectedIndexChanged);
            _Label16 = new Label();
            _txtAvailability = new TextBox();
            _Label15 = new Label();
            _txtPriceExcludeDetails = new TextBox();
            _Label14 = new Label();
            _txtPriceDetails = new TextBox();
            _Label13 = new Label();
            _dtpValidUntil = new DateTimePicker();
            _Label12 = new Label();
            _dtpEnquiryDate = new DateTimePicker();
            _Label11 = new Label();
            _txtCustRef = new TextBox();
            _Label10 = new Label();
            _cboUsers = new ComboBox();
            _Label9 = new Label();
            _chkDeadlineNA = new CheckBox();
            _chkDeadlineNA.CheckedChanged += new EventHandler(chkDeadlineNA_CheckedChanged);
            _dtpDeliveryDeadline = new DateTimePicker();
            _Label8 = new Label();
            _btnFindContact = new Button();
            _btnFindContact.Click += new EventHandler(btnFindContact_Click);
            _txtContact = new TextBox();
            _Label7 = new Label();
            _btnFindInvoiceAddress = new Button();
            _btnFindInvoiceAddress.Click += new EventHandler(btnFindInvoiceAddress_Click);
            _txtInvoiceAddress = new TextBox();
            _Label6 = new Label();
            _lblSpecial = new Label();
            _txtSpecialInstructions = new TextBox();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _txtSite = new TextBox();
            _Label1 = new Label();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _tabRequests = new TabPage();
            _GroupBox4 = new GroupBox();
            _dgConfirmedPriceRequests = new DataGrid();
            _GroupBox1 = new GroupBox();
            _dgPriceRequests = new DataGrid();
            _dgPriceRequests.DoubleClick += new EventHandler(dgPriceRequests_DoubleClick);
            _btnUpdate = new Button();
            _btnUpdate.Click += new EventHandler(btnUpdate_Click);
            _lblSearch = new Label();
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _tabItems = new TabPage();
            _GroupBox3 = new GroupBox();
            _dgParts = new DataGrid();
            _btnRemoveParts = new Button();
            _btnRemoveParts.Click += new EventHandler(btnRemoveParts_Click);
            _btnFindPart = new Button();
            _btnFindPart.Click += new EventHandler(btnFindPart_Click);
            _GroupBox2 = new GroupBox();
            _dgProducts = new DataGrid();
            _btnRemoveProducts = new Button();
            _btnRemoveProducts.Click += new EventHandler(btnRemoveProducts_Click);
            _btnFindProduct = new Button();
            _btnFindProduct.Click += new EventHandler(btnFindProduct_Click);
            _tcQuote.SuspendLayout();
            _tabDetails.SuspendLayout();
            _tabRequests.SuspendLayout();
            _GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgConfirmedPriceRequests).BeginInit();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPriceRequests).BeginInit();
            _tabItems.SuspendLayout();
            _GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgParts).BeginInit();
            _GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgProducts).BeginInit();
            SuspendLayout();
            // 
            // tcQuote
            // 
            _tcQuote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcQuote.Controls.Add(_tabDetails);
            _tcQuote.Controls.Add(_tabRequests);
            _tcQuote.Controls.Add(_tabItems);
            _tcQuote.Location = new Point(8, 8);
            _tcQuote.Name = "tcQuote";
            _tcQuote.SelectedIndex = 0;
            _tcQuote.Size = new Size(552, 496);
            _tcQuote.TabIndex = 0;
            // 
            // tabDetails
            // 
            _tabDetails.Controls.Add(_btnFindWarehouse);
            _tabDetails.Controls.Add(_txtWarehouse);
            _tabDetails.Controls.Add(_lblWarehouse);
            _tabDetails.Controls.Add(_Label3);
            _tabDetails.Controls.Add(_cboStatus);
            _tabDetails.Controls.Add(_Label16);
            _tabDetails.Controls.Add(_txtAvailability);
            _tabDetails.Controls.Add(_Label15);
            _tabDetails.Controls.Add(_txtPriceExcludeDetails);
            _tabDetails.Controls.Add(_Label14);
            _tabDetails.Controls.Add(_txtPriceDetails);
            _tabDetails.Controls.Add(_Label13);
            _tabDetails.Controls.Add(_dtpValidUntil);
            _tabDetails.Controls.Add(_Label12);
            _tabDetails.Controls.Add(_dtpEnquiryDate);
            _tabDetails.Controls.Add(_Label11);
            _tabDetails.Controls.Add(_txtCustRef);
            _tabDetails.Controls.Add(_Label10);
            _tabDetails.Controls.Add(_cboUsers);
            _tabDetails.Controls.Add(_Label9);
            _tabDetails.Controls.Add(_chkDeadlineNA);
            _tabDetails.Controls.Add(_dtpDeliveryDeadline);
            _tabDetails.Controls.Add(_Label8);
            _tabDetails.Controls.Add(_btnFindContact);
            _tabDetails.Controls.Add(_txtContact);
            _tabDetails.Controls.Add(_Label7);
            _tabDetails.Controls.Add(_btnFindInvoiceAddress);
            _tabDetails.Controls.Add(_txtInvoiceAddress);
            _tabDetails.Controls.Add(_Label6);
            _tabDetails.Controls.Add(_lblSpecial);
            _tabDetails.Controls.Add(_txtSpecialInstructions);
            _tabDetails.Controls.Add(_btnFindSite);
            _tabDetails.Controls.Add(_txtSite);
            _tabDetails.Controls.Add(_Label1);
            _tabDetails.Controls.Add(_btnFindCustomer);
            _tabDetails.Controls.Add(_txtCustomer);
            _tabDetails.Location = new Point(4, 22);
            _tabDetails.Name = "tabDetails";
            _tabDetails.Size = new Size(544, 470);
            _tabDetails.TabIndex = 0;
            _tabDetails.Text = "Quote Details";
            // 
            // btnFindWarehouse
            // 
            _btnFindWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindWarehouse.BackColor = Color.White;
            _btnFindWarehouse.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindWarehouse.Location = new Point(504, 56);
            _btnFindWarehouse.Name = "btnFindWarehouse";
            _btnFindWarehouse.Size = new Size(32, 23);
            _btnFindWarehouse.TabIndex = 117;
            _btnFindWarehouse.Text = "...";
            // 
            // txtWarehouse
            // 
            _txtWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtWarehouse.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtWarehouse.Location = new Point(144, 56);
            _txtWarehouse.Name = "txtWarehouse";
            _txtWarehouse.ReadOnly = true;
            _txtWarehouse.Size = new Size(352, 21);
            _txtWarehouse.TabIndex = 116;
            _txtWarehouse.Text = "";
            // 
            // lblWarehouse
            // 
            _lblWarehouse.Location = new Point(8, 56);
            _lblWarehouse.Name = "lblWarehouse";
            _lblWarehouse.TabIndex = 115;
            _lblWarehouse.Text = "Warehouse";
            // 
            // Label3
            // 
            _Label3.Location = new Point(8, 8);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(80, 23);
            _Label3.TabIndex = 114;
            _Label3.Text = "Customer";
            // 
            // cboStatus
            // 
            _cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboStatus.Location = new Point(144, 248);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(392, 21);
            _cboStatus.TabIndex = 16;
            // 
            // Label16
            // 
            _Label16.Location = new Point(8, 248);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(64, 23);
            _Label16.TabIndex = 113;
            _Label16.Text = "Status:";
            // 
            // txtAvailability
            // 
            _txtAvailability.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAvailability.Location = new Point(144, 356);
            _txtAvailability.Multiline = true;
            _txtAvailability.Name = "txtAvailability";
            _txtAvailability.ScrollBars = ScrollBars.Vertical;
            _txtAvailability.Size = new Size(392, 40);
            _txtAvailability.TabIndex = 19;
            _txtAvailability.Text = "";
            // 
            // Label15
            // 
            _Label15.Location = new Point(8, 356);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(120, 24);
            _Label15.TabIndex = 111;
            _Label15.Text = "Availability:";
            // 
            // txtPriceExcludeDetails
            // 
            _txtPriceExcludeDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPriceExcludeDetails.Location = new Point(144, 314);
            _txtPriceExcludeDetails.Multiline = true;
            _txtPriceExcludeDetails.Name = "txtPriceExcludeDetails";
            _txtPriceExcludeDetails.ScrollBars = ScrollBars.Vertical;
            _txtPriceExcludeDetails.Size = new Size(392, 40);
            _txtPriceExcludeDetails.TabIndex = 18;
            _txtPriceExcludeDetails.Text = "";
            // 
            // Label14
            // 
            _Label14.Location = new Point(8, 314);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(120, 40);
            _Label14.TabIndex = 109;
            _Label14.Text = "Prices Quoted Exclude:";
            // 
            // txtPriceDetails
            // 
            _txtPriceDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPriceDetails.Location = new Point(144, 272);
            _txtPriceDetails.Multiline = true;
            _txtPriceDetails.Name = "txtPriceDetails";
            _txtPriceDetails.ScrollBars = ScrollBars.Vertical;
            _txtPriceDetails.Size = new Size(392, 40);
            _txtPriceDetails.TabIndex = 17;
            _txtPriceDetails.Text = "";
            // 
            // Label13
            // 
            _Label13.Location = new Point(8, 272);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(120, 23);
            _Label13.TabIndex = 107;
            _Label13.Text = "Prices Quoted Are:";
            // 
            // dtpValidUntil
            // 
            _dtpValidUntil.Location = new Point(144, 200);
            _dtpValidUntil.Name = "dtpValidUntil";
            _dtpValidUntil.Size = new Size(216, 21);
            _dtpValidUntil.TabIndex = 13;
            _dtpValidUntil.Tag = "Order.DatePlaced";
            // 
            // Label12
            // 
            _Label12.Location = new Point(8, 200);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(114, 23);
            _Label12.TabIndex = 105;
            _Label12.Text = "Valid Until";
            // 
            // dtpEnquiryDate
            // 
            _dtpEnquiryDate.Location = new Point(144, 176);
            _dtpEnquiryDate.Name = "dtpEnquiryDate";
            _dtpEnquiryDate.Size = new Size(216, 21);
            _dtpEnquiryDate.TabIndex = 12;
            _dtpEnquiryDate.Tag = "Order.DatePlaced";
            // 
            // Label11
            // 
            _Label11.Location = new Point(8, 176);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(114, 23);
            _Label11.TabIndex = 103;
            _Label11.Text = "Enquiry Date";
            // 
            // txtCustRef
            // 
            _txtCustRef.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustRef.Location = new Point(144, 152);
            _txtCustRef.Name = "txtCustRef";
            _txtCustRef.Size = new Size(392, 21);
            _txtCustRef.TabIndex = 11;
            _txtCustRef.Text = "";
            // 
            // Label10
            // 
            _Label10.Location = new Point(8, 152);
            _Label10.Name = "Label10";
            _Label10.TabIndex = 101;
            _Label10.Text = "Customer Ref";
            // 
            // cboUsers
            // 
            _cboUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboUsers.Location = new Point(144, 128);
            _cboUsers.Name = "cboUsers";
            _cboUsers.Size = new Size(392, 21);
            _cboUsers.TabIndex = 10;
            // 
            // Label9
            // 
            _Label9.Location = new Point(8, 128);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(128, 24);
            _Label9.TabIndex = 99;
            _Label9.Text = "Product Co-ordinator";
            // 
            // chkDeadlineNA
            // 
            _chkDeadlineNA.Location = new Point(144, 224);
            _chkDeadlineNA.Name = "chkDeadlineNA";
            _chkDeadlineNA.Size = new Size(48, 24);
            _chkDeadlineNA.TabIndex = 14;
            _chkDeadlineNA.Text = "N/A";
            // 
            // dtpDeliveryDeadline
            // 
            _dtpDeliveryDeadline.Location = new Point(192, 224);
            _dtpDeliveryDeadline.Name = "dtpDeliveryDeadline";
            _dtpDeliveryDeadline.Size = new Size(168, 21);
            _dtpDeliveryDeadline.TabIndex = 15;
            _dtpDeliveryDeadline.Tag = "Order.DatePlaced";
            // 
            // Label8
            // 
            _Label8.Location = new Point(8, 224);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(104, 23);
            _Label8.TabIndex = 96;
            _Label8.Text = "Delivery Deadline";
            // 
            // btnFindContact
            // 
            _btnFindContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindContact.BackColor = Color.White;
            _btnFindContact.Enabled = false;
            _btnFindContact.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindContact.Location = new Point(504, 104);
            _btnFindContact.Name = "btnFindContact";
            _btnFindContact.Size = new Size(32, 24);
            _btnFindContact.TabIndex = 9;
            _btnFindContact.Text = "...";
            // 
            // txtContact
            // 
            _txtContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtContact.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtContact.Location = new Point(144, 104);
            _txtContact.Name = "txtContact";
            _txtContact.ReadOnly = true;
            _txtContact.Size = new Size(352, 21);
            _txtContact.TabIndex = 8;
            _txtContact.Text = "";
            // 
            // Label7
            // 
            _Label7.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label7.Location = new Point(8, 104);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(64, 24);
            _Label7.TabIndex = 93;
            _Label7.Text = "Contact";
            // 
            // btnFindInvoiceAddress
            // 
            _btnFindInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindInvoiceAddress.BackColor = Color.White;
            _btnFindInvoiceAddress.Enabled = false;
            _btnFindInvoiceAddress.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindInvoiceAddress.Location = new Point(504, 80);
            _btnFindInvoiceAddress.Name = "btnFindInvoiceAddress";
            _btnFindInvoiceAddress.Size = new Size(32, 24);
            _btnFindInvoiceAddress.TabIndex = 7;
            _btnFindInvoiceAddress.Text = "...";
            // 
            // txtInvoiceAddress
            // 
            _txtInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtInvoiceAddress.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtInvoiceAddress.Location = new Point(144, 80);
            _txtInvoiceAddress.Name = "txtInvoiceAddress";
            _txtInvoiceAddress.ReadOnly = true;
            _txtInvoiceAddress.Size = new Size(352, 21);
            _txtInvoiceAddress.TabIndex = 6;
            _txtInvoiceAddress.Text = "";
            // 
            // Label6
            // 
            _Label6.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label6.Location = new Point(8, 80);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(104, 24);
            _Label6.TabIndex = 90;
            _Label6.Text = "Invoice Address";
            // 
            // lblSpecial
            // 
            _lblSpecial.Location = new Point(8, 398);
            _lblSpecial.Name = "lblSpecial";
            _lblSpecial.Size = new Size(80, 40);
            _lblSpecial.TabIndex = 87;
            _lblSpecial.Text = "Special Instructions";
            // 
            // txtSpecialInstructions
            // 
            _txtSpecialInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtSpecialInstructions.Location = new Point(144, 398);
            _txtSpecialInstructions.Multiline = true;
            _txtSpecialInstructions.Name = "txtSpecialInstructions";
            _txtSpecialInstructions.ScrollBars = ScrollBars.Vertical;
            _txtSpecialInstructions.Size = new Size(392, 66);
            _txtSpecialInstructions.TabIndex = 20;
            _txtSpecialInstructions.Text = "";
            // 
            // btnFindSite
            // 
            _btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSite.BackColor = Color.White;
            _btnFindSite.Enabled = false;
            _btnFindSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSite.Location = new Point(504, 32);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(32, 23);
            _btnFindSite.TabIndex = 4;
            _btnFindSite.Text = "...";
            // 
            // txtSite
            // 
            _txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSite.Location = new Point(144, 32);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(352, 21);
            _txtSite.TabIndex = 3;
            _txtSite.Text = "";
            // 
            // Label1
            // 
            _Label1.Location = new Point(8, 32);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(80, 23);
            _Label1.TabIndex = 83;
            _Label1.Text = "Property";
            // 
            // btnFindCustomer
            // 
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(504, 8);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 2;
            _btnFindCustomer.Text = "...";
            // 
            // txtCustomer
            // 
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(144, 8);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(352, 21);
            _txtCustomer.TabIndex = 1;
            _txtCustomer.Text = "";
            // 
            // tabRequests
            // 
            _tabRequests.Controls.Add(_GroupBox4);
            _tabRequests.Controls.Add(_GroupBox1);
            _tabRequests.Controls.Add(_lblSearch);
            _tabRequests.Controls.Add(_btnSearch);
            _tabRequests.Location = new Point(4, 22);
            _tabRequests.Name = "tabRequests";
            _tabRequests.Size = new Size(544, 470);
            _tabRequests.TabIndex = 2;
            _tabRequests.Text = "Price Requests";
            // 
            // GroupBox4
            // 
            _GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox4.Controls.Add(_dgConfirmedPriceRequests);
            _GroupBox4.Location = new Point(8, 264);
            _GroupBox4.Name = "GroupBox4";
            _GroupBox4.Size = new Size(528, 192);
            _GroupBox4.TabIndex = 7;
            _GroupBox4.TabStop = false;
            _GroupBox4.Text = "Confirmed Price Requests";
            // 
            // dgConfirmedPriceRequests
            // 
            _dgConfirmedPriceRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgConfirmedPriceRequests.DataMember = "";
            _dgConfirmedPriceRequests.HeaderForeColor = SystemColors.ControlText;
            _dgConfirmedPriceRequests.Location = new Point(8, 27);
            _dgConfirmedPriceRequests.Name = "dgConfirmedPriceRequests";
            _dgConfirmedPriceRequests.Size = new Size(512, 157);
            _dgConfirmedPriceRequests.TabIndex = 2;
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_dgPriceRequests);
            _GroupBox1.Controls.Add(_btnUpdate);
            _GroupBox1.Location = new Point(8, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(528, 216);
            _GroupBox1.TabIndex = 6;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Unconfirmed Price Requests";
            // 
            // dgPriceRequests
            // 
            _dgPriceRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgPriceRequests.DataMember = "";
            _dgPriceRequests.HeaderForeColor = SystemColors.ControlText;
            _dgPriceRequests.Location = new Point(8, 31);
            _dgPriceRequests.Name = "dgPriceRequests";
            _dgPriceRequests.Size = new Size(512, 145);
            _dgPriceRequests.TabIndex = 1;
            // 
            // btnUpdate
            // 
            _btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnUpdate.Location = new Point(8, 184);
            _btnUpdate.Name = "btnUpdate";
            _btnUpdate.Size = new Size(152, 24);
            _btnUpdate.TabIndex = 7;
            _btnUpdate.Text = "Confirm Price Request";
            // 
            // lblSearch
            // 
            _lblSearch.Location = new Point(136, 8);
            _lblSearch.Name = "lblSearch";
            _lblSearch.Size = new Size(336, 23);
            _lblSearch.TabIndex = 5;
            _lblSearch.Text = "Please Save Quote To Allow Search For Price Request";
            // 
            // btnSearch
            // 
            _btnSearch.Location = new Point(8, 8);
            _btnSearch.Name = "btnSearch";
            _btnSearch.Size = new Size(120, 23);
            _btnSearch.TabIndex = 4;
            _btnSearch.Text = "Search For Items";
            // 
            // tabItems
            // 
            _tabItems.Controls.Add(_GroupBox3);
            _tabItems.Controls.Add(_GroupBox2);
            _tabItems.Location = new Point(4, 22);
            _tabItems.Name = "tabItems";
            _tabItems.Size = new Size(544, 470);
            _tabItems.TabIndex = 1;
            _tabItems.Text = "Products / Parts";
            // 
            // GroupBox3
            // 
            _GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox3.Controls.Add(_dgParts);
            _GroupBox3.Controls.Add(_btnRemoveParts);
            _GroupBox3.Controls.Add(_btnFindPart);
            _GroupBox3.Location = new Point(8, 216);
            _GroupBox3.Name = "GroupBox3";
            _GroupBox3.Size = new Size(528, 248);
            _GroupBox3.TabIndex = 57;
            _GroupBox3.TabStop = false;
            _GroupBox3.Text = "Parts - Quantity and Price can be edited by clicking the appropriate cell";
            // 
            // dgParts
            // 
            _dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgParts.DataMember = "";
            _dgParts.HeaderForeColor = SystemColors.ControlText;
            _dgParts.Location = new Point(8, 41);
            _dgParts.Name = "dgParts";
            _dgParts.Size = new Size(512, 167);
            _dgParts.TabIndex = 4;
            // 
            // btnRemoveParts
            // 
            _btnRemoveParts.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemoveParts.Location = new Point(456, 218);
            _btnRemoveParts.Name = "btnRemoveParts";
            _btnRemoveParts.Size = new Size(64, 23);
            _btnRemoveParts.TabIndex = 6;
            _btnRemoveParts.Text = "Remove";
            // 
            // btnFindPart
            // 
            _btnFindPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnFindPart.BackColor = SystemColors.Control;
            _btnFindPart.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindPart.Location = new Point(8, 216);
            _btnFindPart.Name = "btnFindPart";
            _btnFindPart.Size = new Size(128, 23);
            _btnFindPart.TabIndex = 5;
            _btnFindPart.Text = "Search For Part";
            // 
            // GroupBox2
            // 
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox2.Controls.Add(_dgProducts);
            _GroupBox2.Controls.Add(_btnRemoveProducts);
            _GroupBox2.Controls.Add(_btnFindProduct);
            _GroupBox2.Location = new Point(8, 8);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(528, 200);
            _GroupBox2.TabIndex = 52;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Products - Quantity and Price can be edited by clicking the appropriate cell";
            // 
            // dgProducts
            // 
            _dgProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgProducts.DataMember = "";
            _dgProducts.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dgProducts.HeaderForeColor = SystemColors.ControlText;
            _dgProducts.Location = new Point(8, 35);
            _dgProducts.Name = "dgProducts";
            _dgProducts.Size = new Size(512, 126);
            _dgProducts.TabIndex = 1;
            // 
            // btnRemoveProducts
            // 
            _btnRemoveProducts.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemoveProducts.Location = new Point(456, 169);
            _btnRemoveProducts.Name = "btnRemoveProducts";
            _btnRemoveProducts.Size = new Size(64, 23);
            _btnRemoveProducts.TabIndex = 3;
            _btnRemoveProducts.Text = "Remove";
            // 
            // btnFindProduct
            // 
            _btnFindProduct.BackColor = SystemColors.Control;
            _btnFindProduct.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindProduct.Location = new Point(8, 168);
            _btnFindProduct.Name = "btnFindProduct";
            _btnFindProduct.Size = new Size(128, 23);
            _btnFindProduct.TabIndex = 2;
            _btnFindProduct.Text = "Search For Product";
            // 
            // UCGenerateQuote
            // 
            Controls.Add(_tcQuote);
            Name = "UCGenerateQuote";
            Size = new Size(568, 512);
            _tcQuote.ResumeLayout(false);
            _tabDetails.ResumeLayout(false);
            _tabRequests.ResumeLayout(false);
            _GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgConfirmedPriceRequests).EndInit();
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgPriceRequests).EndInit();
            _tabItems.ResumeLayout(false);
            _GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgParts).EndInit();
            _GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgProducts).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupPartsDataGrid();
            SetupProductsDataGrid();
            SetupPriceRequestDatagrid();
            SetupConfirmedPriceRequestDatagrid();
            var argc = cboStatus;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Quote_Status).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        public object LoadedItem
        {
            get
            {
                return default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public DataView PartsDataView
        {
            get
            {
                return m_dTable2;
            }

            set
            {
                m_dTable2 = value;
                m_dTable2.Table.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString();
                m_dTable2.AllowNew = false;
                m_dTable2.AllowEdit = false;
                m_dTable2.AllowDelete = false;
                dgParts.DataSource = PartsDataView;
            }
        }

        private DataView m_dTable2 = null;

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

        public DataView ProductsDataView
        {
            get
            {
                return m_dTable;
            }

            set
            {
                m_dTable = value;
                m_dTable.Table.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString();
                m_dTable.AllowNew = false;
                m_dTable.AllowEdit = false;
                m_dTable.AllowDelete = false;
                dgProducts.DataSource = ProductsDataView;
            }
        }

        private DataView m_dTable = null;

        private DataRow SelectedProductDataRow
        {
            get
            {
                if (!(dgProducts.CurrentRowIndex == -1))
                {
                    return ProductsDataView[dgProducts.CurrentRowIndex].Row;
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
                _PriceRequestDataView.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
                _PriceRequestDataView.AllowNew = false;
                _PriceRequestDataView.AllowEdit = false;
                _PriceRequestDataView.AllowDelete = false;
                dgPriceRequests.DataSource = PriceRequestDataView;
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

        private DataView _ConfirmedPriceRequestDataView = null;

        public DataView ConfirmedPriceRequestDataView
        {
            get
            {
                return _ConfirmedPriceRequestDataView;
            }

            set
            {
                _ConfirmedPriceRequestDataView = value;
                _ConfirmedPriceRequestDataView.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
                _ConfirmedPriceRequestDataView.AllowNew = false;
                _ConfirmedPriceRequestDataView.AllowEdit = false;
                _ConfirmedPriceRequestDataView.AllowDelete = false;
                dgConfirmedPriceRequests.DataSource = ConfirmedPriceRequestDataView;
            }
        }

        private DataRow SelectedConfirmedPriceRequestDataRow
        {
            get
            {
                if (!(dgConfirmedPriceRequests.CurrentRowIndex == -1))
                {
                    return ConfirmedPriceRequestDataView[dgConfirmedPriceRequests.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private bool Loading;
        private Entity.QuoteOrders.QuoteOrder oQuoteOrder;

        public Entity.QuoteOrders.QuoteOrder CurrentQuoteOrder
        {
            get
            {
                return oQuoteOrder;
            }

            set
            {
                oQuoteOrder = value;
                if (CurrentQuoteOrder is null)
                {
                    CurrentQuoteOrder = new Entity.QuoteOrders.QuoteOrder();
                    CurrentQuoteOrder.Exists = false;
                    cboStatus.Enabled = false;
                    var argcombo = cboStatus;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, 1.ToString());
                }
                else
                {
                    cboStatus.Enabled = true;
                }

                if (CurrentQuoteOrder.Exists)
                {
                    btnSearch.Enabled = true;
                    btnUpdate.Enabled = true;
                    lblSearch.Visible = false;
                    Populate();
                }
                else
                {
                    btnSearch.Enabled = false;
                    btnUpdate.Enabled = false;
                    lblSearch.Visible = true;
                }

                Loading = false;
            }
        }

        private Entity.Customers.Customer _oCustomer;

        public Entity.Customers.Customer Customer
        {
            get
            {
                return _oCustomer;
            }

            set
            {
                _oCustomer = value;
                if (_oCustomer is object)
                {
                    txtCustomer.Text = Customer.Name + " ( " + Customer.AccountNumber + ") ";
                    btnFindSite.Enabled = true;
                    theSite = null;
                    InvoiceAddress = null;
                    Contact = null;
                }
                else
                {
                    txtCustomer.Text = "";
                    btnFindSite.Enabled = false;
                }
            }
        }

        private Entity.Sites.Site _oSite;

        public Entity.Sites.Site theSite
        {
            get
            {
                return _oSite;
            }

            set
            {
                _oSite = value;
                if (_oSite is object)
                {
                    txtSite.Text = theSite.Address1 + ", " + theSite.Address2 + ", " + theSite.Postcode;
                    btnFindInvoiceAddress.Enabled = true;
                    btnFindContact.Enabled = true;
                    InvoiceAddress = null;
                    Contact = null;
                    theWarehouse = null;
                }
                else
                {
                    txtSite.Text = "";
                    btnFindInvoiceAddress.Enabled = false;
                    btnFindContact.Enabled = false;
                }
            }
        }

        private Entity.Warehouses.Warehouse _oWarehouse;

        public Entity.Warehouses.Warehouse theWarehouse
        {
            get
            {
                return _oWarehouse;
            }

            set
            {
                _oWarehouse = value;
                if (_oWarehouse is object)
                {
                    txtWarehouse.Text = theWarehouse.Address1 + ", " + theWarehouse.Address2 + ", " + theWarehouse.Postcode;
                    theSite = null;
                }
                // btnFindContact.Enabled = False
                // btnFindInvoiceAddress.Enabled = False
                else
                {
                    txtWarehouse.Text = "";
                }
            }
        }

        private Entity.InvoiceAddresss.InvoiceAddress _invoiceAddress;

        public Entity.InvoiceAddresss.InvoiceAddress InvoiceAddress
        {
            get
            {
                return _invoiceAddress;
            }

            set
            {
                _invoiceAddress = value;
                if (InvoiceAddress is object)
                {
                    txtInvoiceAddress.Text = InvoiceAddress.Address1 + ", " + InvoiceAddress.Address2 + ", " + InvoiceAddress.Postcode;
                }
                else
                {
                    txtInvoiceAddress.Text = "";
                }
            }
        }

        private Entity.Contacts.Contact _contact;

        public Entity.Contacts.Contact Contact
        {
            get
            {
                return _contact;
            }

            set
            {
                _contact = value;
                if (Contact is object)
                {
                    txtContact.Text = Contact.FirstName + " " + Contact.Surname;
                }
                else
                {
                    txtContact.Text = "";
                }
            }
        }

        public event FormCloseEventHandler FormClose;

        public delegate void FormCloseEventHandler();

        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupPriceRequestDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgPriceRequests);
            var tStyle = dgPriceRequests.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 70;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            var SupplierName = new DataGridLabelColumn();
            SupplierName.Format = "";
            SupplierName.FormatInfo = null;
            SupplierName.HeaderText = "Supplier";
            SupplierName.MappingName = "SupplierName";
            SupplierName.ReadOnly = true;
            SupplierName.Width = 140;
            SupplierName.NullText = "";
            tStyle.GridColumnStyles.Add(SupplierName);

            // Dim Postcode As New DataGridLabelColumn
            // Postcode.Format = ""
            // Postcode.FormatInfo = Nothing
            // Postcode.HeaderText = "Postcode"
            // Postcode.MappingName = "Postcode"
            // Postcode.ReadOnly = True
            // Postcode.Width = 120
            // Postcode.NullText = ""
            // tStyle.GridColumnStyles.Add(Postcode)

            // Dim TelephoneNum As New DataGridLabelColumn
            // TelephoneNum.Format = ""
            // TelephoneNum.FormatInfo = Nothing
            // TelephoneNum.HeaderText = "Telephone"
            // TelephoneNum.MappingName = "TelephoneNum"
            // TelephoneNum.ReadOnly = True
            // TelephoneNum.Width = 120
            // TelephoneNum.NullText = ""
            // tStyle.GridColumnStyles.Add(TelephoneNum)

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
            tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
            dgPriceRequests.TableStyles.Add(tStyle);
        }

        public void SetupConfirmedPriceRequestDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgConfirmedPriceRequests);
            dgConfirmedPriceRequests.ReadOnly = false;
            var tStyle = dgConfirmedPriceRequests.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var chk = new DataGridCheckBox();
            chk.HeaderText = "Selected";
            chk.MappingName = "Included";
            chk.ReadOnly = true;
            chk.Width = 50;
            chk.NullText = "0";
            tStyle.GridColumnStyles.Add(chk);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 70;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            var SupplierName = new DataGridLabelColumn();
            SupplierName.Format = "";
            SupplierName.FormatInfo = null;
            SupplierName.HeaderText = "Supplier";
            SupplierName.MappingName = "SupplierName";
            SupplierName.ReadOnly = true;
            SupplierName.Width = 120;
            SupplierName.NullText = "";
            tStyle.GridColumnStyles.Add(SupplierName);
            var partName = new DataGridLabelColumn();
            partName.Format = "";
            partName.FormatInfo = null;
            partName.HeaderText = "Part";
            partName.MappingName = "Part";
            partName.ReadOnly = true;
            partName.Width = 120;
            partName.NullText = "";
            tStyle.GridColumnStyles.Add(partName);
            var ProductName = new DataGridLabelColumn();
            ProductName.Format = "";
            ProductName.FormatInfo = null;
            ProductName.HeaderText = "Product";
            ProductName.MappingName = "Product";
            ProductName.ReadOnly = true;
            ProductName.Width = 120;
            ProductName.NullText = "";
            tStyle.GridColumnStyles.Add(ProductName);
            var PartCode = new DataGridLabelColumn();
            PartCode.Format = "";
            PartCode.FormatInfo = null;
            PartCode.HeaderText = "Supplier Code";
            PartCode.MappingName = "Code";
            PartCode.ReadOnly = true;
            PartCode.Width = 120;
            PartCode.NullText = "";
            tStyle.GridColumnStyles.Add(PartCode);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Buy Price";
            Price.MappingName = "BuyPrice";
            Price.ReadOnly = true;
            Price.Width = 90;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Quantity";
            Amount.MappingName = "QuantityInPack";
            Amount.ReadOnly = true;
            Amount.Width = 90;
            Amount.NullText = "";
            tStyle.GridColumnStyles.Add(Amount);
            var SellPrice = new DataGridOrderTextBoxColumn();
            SellPrice.Format = "C";
            SellPrice.FormatInfo = null;
            SellPrice.HeaderText = "Sell Price";
            SellPrice.MappingName = "SellPrice";
            SellPrice.ReadOnly = false;
            SellPrice.Width = 90;
            SellPrice.NullText = "";
            tStyle.GridColumnStyles.Add(SellPrice);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
            dgConfirmedPriceRequests.TableStyles.Add(tStyle);
        }

        public object SetupPartsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgParts);
            dgParts.ReadOnly = false;
            var tStyle = dgParts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var PartName = new DataGridLabelColumn();
            PartName.Format = "";
            PartName.FormatInfo = null;
            PartName.HeaderText = "Name";
            PartName.MappingName = "Name";
            PartName.ReadOnly = true;
            PartName.Width = 130;
            PartName.NullText = "";
            tStyle.GridColumnStyles.Add(PartName);
            var PartNumber = new DataGridLabelColumn();
            PartNumber.Format = "";
            PartNumber.FormatInfo = null;
            PartNumber.HeaderText = "Number";
            PartNumber.MappingName = "Number";
            PartNumber.ReadOnly = true;
            PartNumber.Width = 130;
            PartNumber.NullText = "";
            tStyle.GridColumnStyles.Add(PartNumber);
            var PartReference = new DataGridLabelColumn();
            PartReference.Format = "";
            PartReference.FormatInfo = null;
            PartReference.HeaderText = "Part Reference";
            PartReference.MappingName = "Reference";
            PartReference.ReadOnly = true;
            PartReference.Width = 200;
            PartReference.NullText = "";
            tStyle.GridColumnStyles.Add(PartReference);
            var ListPrice = new DataGridOrderTextBoxColumn();
            ListPrice.Format = "C";
            ListPrice.FormatInfo = null;
            ListPrice.HeaderText = "List Price";
            ListPrice.MappingName = "SellPrice";
            ListPrice.ReadOnly = false;
            ListPrice.Width = 100;
            ListPrice.NullText = "";
            tStyle.GridColumnStyles.Add(ListPrice);
            var PartQuantity = new DataGridOrderTextBoxColumn();
            PartQuantity.Format = "F";
            PartQuantity.FormatInfo = null;
            PartQuantity.HeaderText = "Quantity";
            PartQuantity.MappingName = "Quantity";
            PartQuantity.ReadOnly = false;
            PartQuantity.Width = 150;
            PartQuantity.NullText = "";
            tStyle.GridColumnStyles.Add(PartQuantity);
            var Price = new DataGridOrderTextBoxColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Quote Price";
            Price.MappingName = "Price";
            Price.ReadOnly = false;
            Price.Width = 150;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString();
            dgParts.TableStyles.Add(tStyle);
            return default;
        }

        public object SetupProductsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgProducts);
            dgProducts.ReadOnly = false;
            var tStyle = dgProducts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var ProductName = new DataGridLabelColumn();
            ProductName.Format = "";
            ProductName.FormatInfo = null;
            ProductName.HeaderText = "Name";
            ProductName.MappingName = "typemakemodel";
            ProductName.ReadOnly = true;
            ProductName.Width = 130;
            ProductName.NullText = "";
            tStyle.GridColumnStyles.Add(ProductName);
            var ProductNumber = new DataGridLabelColumn();
            ProductNumber.Format = "";
            ProductNumber.FormatInfo = null;
            ProductNumber.HeaderText = "Number";
            ProductNumber.MappingName = "Number";
            ProductNumber.ReadOnly = true;
            ProductNumber.Width = 130;
            ProductNumber.NullText = "";
            tStyle.GridColumnStyles.Add(ProductNumber);
            var ProductReference = new DataGridLabelColumn();
            ProductReference.Format = "";
            ProductReference.FormatInfo = null;
            ProductReference.HeaderText = "Product Reference";
            ProductReference.MappingName = "Reference";
            ProductReference.ReadOnly = true;
            ProductReference.Width = 200;
            ProductReference.NullText = "";
            tStyle.GridColumnStyles.Add(ProductReference);
            var ListPrice = new DataGridOrderTextBoxColumn();
            ListPrice.Format = "C";
            ListPrice.FormatInfo = null;
            ListPrice.HeaderText = "List Price";
            ListPrice.MappingName = "SellPrice";
            ListPrice.ReadOnly = false;
            ListPrice.Width = 100;
            ListPrice.NullText = "";
            tStyle.GridColumnStyles.Add(ListPrice);
            var ProductQuantity = new DataGridOrderTextBoxColumn();
            ProductQuantity.Format = "F";
            ProductQuantity.FormatInfo = null;
            ProductQuantity.HeaderText = "Quantity";
            ProductQuantity.MappingName = "Quantity";
            ProductQuantity.ReadOnly = false;
            ProductQuantity.Width = 150;
            ProductQuantity.NullText = "";
            tStyle.GridColumnStyles.Add(ProductQuantity);
            var Price = new DataGridOrderTextBoxColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = false;
            Price.Width = 150;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblProduct.ToString();
            dgProducts.TableStyles.Add(tStyle);
            return default;
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading == false & CurrentQuoteOrder is object)
            {
                if (CurrentQuoteOrder.Exists == true)
                {
                    if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboStatus)) == Entity.Sys.Enums.QuoteContractStatus.Accepted)
                    {
                        MsgBoxResult msgRes;
                        msgRes = (MsgBoxResult)App.ShowMessage("You are converting this quote to an order" + Constants.vbCrLf + "Do you wish to save any changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if ((int)msgRes == (int)DialogResult.Yes)
                        {
                            if (Save() == false)
                            {
                                return;
                            }
                        }
                        else if (msgRes == MsgBoxResult.No)
                        {
                            App.DB.QuoteOrder.Update(oQuoteOrder);
                        }
                        else if (msgRes == MsgBoxResult.Cancel)
                        {
                            var argcombo = cboStatus;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentQuoteOrder.QuoteStatusID.ToString());
                            return;
                        }

                        FRMConvertToAnOrder convertForm = (FRMConvertToAnOrder)Activator.CreateInstance(typeof(FRMConvertToAnOrder));
                        // convertForm.Icon = New Icon(convertForm.GetType(), "Logo.ico")
                        convertForm.ShowInTaskbar = false;
                        convertForm.StartPosition = FormStartPosition.CenterScreen;
                        convertForm.SizeGripStyle = SizeGripStyle.Hide;
                        var PartsAndProducts = new DataView(new DataTable());
                        PartsAndProducts.Table.Columns.Add("PartProductID");
                        PartsAndProducts.Table.Columns.Add("Type");
                        PartsAndProducts.Table.Columns.Add("Number");
                        PartsAndProducts.Table.Columns.Add("Name");
                        PartsAndProducts.Table.Columns.Add("Quantity");
                        PartsAndProducts.Table.Columns.Add("SellPrice");
                        foreach (DataRow row in PartsDataView.Table.Rows)
                        {
                            var newRow = PartsAndProducts.Table.NewRow();
                            newRow["PartProductID"] = row["PartID"];
                            newRow["Type"] = "Part";
                            newRow["Number"] = row["Number"];
                            newRow["Name"] = row["Name"];
                            newRow["Quantity"] = row["Quantity"];
                            newRow["SellPrice"] = row["Price"];
                            PartsAndProducts.Table.Rows.Add(newRow);
                            PartsAndProducts.Table.AcceptChanges();
                        }

                        foreach (DataRow row2 in ProductsDataView.Table.Rows)
                        {
                            var newRow = PartsAndProducts.Table.NewRow();
                            newRow["PartProductID"] = row2["ProductID"];
                            newRow["Type"] = "Product";
                            newRow["Number"] = row2["Number"];
                            newRow["Name"] = row2["typemakemodel"];
                            newRow["Quantity"] = row2["Quantity"];
                            newRow["SellPrice"] = row2["Price"];
                            PartsAndProducts.Table.Rows.Add(newRow);
                            PartsAndProducts.Table.AcceptChanges();
                        }

                        convertForm.PriceRequestItemsDataView = ConfirmedPriceRequestDataView;
                        ((IBaseForm)convertForm).SetFormParameters = new object[] { Conversions.ToInteger(Entity.Sys.Enums.OrderType.Customer), 0, PartsAndProducts, CurrentQuoteOrder, 0, ConfirmedPriceRequestDataView };
                        if (convertForm.ShowDialog() == DialogResult.OK)
                        {
                        }
                        else
                        {
                            var argcombo1 = cboStatus;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Conversions.ToString(Entity.Sys.Enums.QuoteContractStatus.Generated));
                            Save();
                        }

                        Populate(CurrentQuoteOrder.QuoteOrderID);
                    }
                    else if ((Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboStatus)) == Entity.Sys.Enums.QuoteContractStatus.Rejected)
                    {
                        App.ShowForm(typeof(FRMQuoteRejection), true, new object[] { this, "" });
                        Populate(CurrentQuoteOrder.QuoteOrderID);
                    }
                }
            }
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                Customer = App.DB.Customer.Customer_Get(ID);
            }
        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblProduct));
            if (ID > 0)
            {
                addProduct(ID);
            }
        }

        private void btnFindPart_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblPart));
            if (ID > 0)
            {
                addPart(ID);
            }
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSite, Customer.CustomerID));
            if (!(ID == 0))
            {
                theSite = App.DB.Sites.Get(ID);
            }
        }

        private void UCGenerateQuote_Load(object sender, EventArgs e)
        {
            Loading = true;
            LoadForm(sender, e);
        }

        private void btnRemoveProducts_Click(object sender, EventArgs e)
        {
            if (SelectedProductDataRow is null)
            {
                App.ShowMessage("Please select product to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ProductsDataView.Table.Rows.Remove(SelectedProductDataRow);
            ProductsDataView.Table.AcceptChanges();
        }

        private void btnRemoveParts_Click(object sender, EventArgs e)
        {
            if (SelectedPartDataRow is null)
            {
                App.ShowMessage("Please select part to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PartsDataView.Table.Rows.Remove(SelectedPartDataRow);
            PartsDataView.Table.AcceptChanges();
        }

        private void btnFindInvoiceAddress_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblInvoiceAddress, theSite.SiteID));
            if (!(ID == 0))
            {
                InvoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(ID);
            }
        }

        private void btnFindContact_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblContact, theSite.SiteID));
            if (!(ID == 0))
            {
                Contact = App.DB.Contact.Contact_Get(ID);
            }
        }

        private void chkDeadlineNA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeadlineNA.Checked == true)
            {
                dtpDeliveryDeadline.Enabled = false;
            }
            else
            {
                dtpDeliveryDeadline.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DLGAdvancedItemSearch dialogue;
            dialogue = (DLGAdvancedItemSearch)App.checkIfExists(typeof(DLGAdvancedItemSearch).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGAdvancedItemSearch)Activator.CreateInstance(typeof(DLGAdvancedItemSearch));
            }

            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.QuoteID = oQuoteOrder.QuoteOrderID;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                // Return dialogue.ID
            }

            dialogue.Dispose();
            RefreshDatagrids();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePriceRequest();
        }

        private void dgPriceRequests_DoubleClick(object sender, EventArgs e)
        {
            UpdatePriceRequest();
        }

        private void btnFindWarehouse_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse));
            if (!(ID == 0))
            {
                theWarehouse = App.DB.Warehouse.Warehouse_Get(ID);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void UpdatePriceRequest()
        {
            if (SelectedPriceRequestDataRow is null)
            {
                App.ShowMessage("Please select an item to update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPriceRequestDataRow["Type"], "Part", false)))
            {
                var oPartSupplier = new Entity.PartSuppliers.PartSupplier();
                oPartSupplier.SetPartID = SelectedPriceRequestDataRow["PartProductID"];
                oPartSupplier.SetSupplierID = SelectedPriceRequestDataRow["SupplierID"];
                oPartSupplier.SetQuantityInPack = SelectedPriceRequestDataRow["QuantityInPack"];
                App.ShowForm(typeof(FRMAddToQuote), true, new object[] { CurrentQuoteOrder.QuoteOrderID, oPartSupplier, null, SelectedPriceRequestDataRow["ID"] });
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPriceRequestDataRow["Type"], "Product", false)))
            {
                var oProductSupplier = new Entity.ProductSuppliers.ProductSupplier();
                oProductSupplier.SetProductID = SelectedPriceRequestDataRow["PartProductID"];
                oProductSupplier.SetSupplierID = SelectedPriceRequestDataRow["SupplierID"];
                oProductSupplier.SetQuantityInPack = SelectedPriceRequestDataRow["QuantityInPack"];
                App.ShowForm(typeof(FRMAddToQuote), true, new object[] { CurrentQuoteOrder.QuoteOrderID, null, oProductSupplier, SelectedPriceRequestDataRow["ID"] });
            }

            RefreshDatagrids();
        }

        private void RefreshDatagrids()
        {
            PriceRequestDataView = App.DB.QuoteOrder.Quote_PriceRequests_GetAll(CurrentQuoteOrder.QuoteOrderID);
            ConfirmedPriceRequestDataView = App.DB.QuoteOrder.Quote_PriceRequests_GetConfirmed(CurrentQuoteOrder.QuoteOrderID);
        }

        private void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentQuoteOrder = App.DB.QuoteOrder.QuoteOrder_Get(ID);
            }

            Customer = App.DB.Customer.Customer_Get(CurrentQuoteOrder.CustomerID);
            theSite = App.DB.Sites.Get(CurrentQuoteOrder.PropertyID);
            Contact = App.DB.Contact.Contact_Get(CurrentQuoteOrder.ContactID);
            InvoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(CurrentQuoteOrder.InvoiceAddressID);
            theWarehouse = App.DB.Warehouse.Warehouse_Get(CurrentQuoteOrder.WarehouseID);
            txtSpecialInstructions.Text = CurrentQuoteOrder.SpecialInstructions;
            if (CurrentQuoteOrder.DeliveryDeadline == default)
            {
                chkDeadlineNA.Checked = true;
            }
            else
            {
                dtpDeliveryDeadline.Value = CurrentQuoteOrder.DeliveryDeadline;
                chkDeadlineNA.Checked = false;
            }

            var argcombo = cboUsers;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentQuoteOrder.AllocatedToUser.ToString());
            var argcombo1 = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentQuoteOrder.QuoteStatusID.ToString());
            if (CurrentQuoteOrder.QuoteStatusID == Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Generated))
            {
                SetFormState(true);
            }
            else
            {
                SetFormState(false);
            }

            txtCustRef.Text = CurrentQuoteOrder.CustomerRef;
            txtPriceDetails.Text = CurrentQuoteOrder.PriceDetails;
            txtPriceExcludeDetails.Text = CurrentQuoteOrder.PriceExcludeDetails;
            txtAvailability.Text = CurrentQuoteOrder.Availability;
            dtpEnquiryDate.Value = CurrentQuoteOrder.EnquiryDate;
            dtpValidUntil.Value = CurrentQuoteOrder.ValidUntilDate;
            PartsDataView = (DataView)App.DB.QuoteOrderPart.QuoteOrderPart_GetForQuoteOrder(CurrentQuoteOrder.QuoteOrderID);
            ProductsDataView = (DataView)App.DB.QuoteOrderProduct.QuoteOrderProduct_GetForQuoteOrder(CurrentQuoteOrder.QuoteOrderID);
            RefreshDatagrids();
        }

        public bool Save()
        {
            try
            {
                var oQuoteOrder = new Entity.QuoteOrders.QuoteOrder();
                if (CurrentQuoteOrder.Exists == true)
                {
                    oQuoteOrder.SetReasonForReject = CurrentQuoteOrder.ReasonForReject;
                }

                if (Customer is object)
                {
                    oQuoteOrder.SetCustomerID = Customer.CustomerID;
                }
                else
                {
                    oQuoteOrder.SetCustomerID = 0;
                }

                if (theSite is object)
                {
                    oQuoteOrder.SetPropertyID = theSite.SiteID;
                }
                else
                {
                    oQuoteOrder.SetPropertyID = 0;
                }

                if (theWarehouse is object)
                {
                    oQuoteOrder.SetWarehouseID = theWarehouse.WarehouseID;
                }
                else
                {
                    oQuoteOrder.SetWarehouseID = 0;
                }

                oQuoteOrder.SetAllocatedToUser = Combo.get_GetSelectedItemValue(cboUsers);
                oQuoteOrder.SetCreatedByUser = App.loggedInUser.UserID;
                if (Contact is object)
                {
                    oQuoteOrder.SetContactID = Contact.ContactID;
                }
                else
                {
                    oQuoteOrder.SetContactID = 0;
                }

                oQuoteOrder.SetCustomerRef = txtCustRef.Text;
                oQuoteOrder.SetAvailability = txtAvailability.Text;
                oQuoteOrder.SetPriceDetails = txtPriceDetails.Text;
                oQuoteOrder.SetPriceExcludeDetails = txtPriceExcludeDetails.Text;
                oQuoteOrder.EnquiryDate = dtpEnquiryDate.Value;
                oQuoteOrder.ValidUntilDate = dtpValidUntil.Value;
                if (InvoiceAddress is object)
                {
                    oQuoteOrder.SetInvoiceAddressID = InvoiceAddress.InvoiceAddressID;
                }
                else
                {
                    oQuoteOrder.SetInvoiceAddressID = 0;
                }

                oQuoteOrder.SetSpecialInstructions = txtSpecialInstructions.Text;
                oQuoteOrder.SetQuoteStatusID = Combo.get_GetSelectedItemValue(cboStatus);
                if (chkDeadlineNA.Checked == true)
                {
                    oQuoteOrder.DeliveryDeadline = default;
                }
                else
                {
                    oQuoteOrder.DeliveryDeadline = dtpDeliveryDeadline.Value;
                }

                if (CurrentQuoteOrder.Exists)
                {
                    oQuoteOrder.SetQuoteOrderID = CurrentQuoteOrder.QuoteOrderID;
                    var qOValidator = new Entity.QuoteOrders.QuoteOrderValidator();
                    qOValidator.Validate(oQuoteOrder);
                    App.DB.QuoteOrder.Update(oQuoteOrder);
                }
                else
                {
                    var qOValidator = new Entity.QuoteOrders.QuoteOrderValidator();
                    qOValidator.Validate(oQuoteOrder);
                    oQuoteOrder = App.DB.QuoteOrder.Insert(oQuoteOrder);
                }

                App.DB.QuoteOrderPart.QuoteOrderPart_DeleteForQuoteOrder(oQuoteOrder.QuoteOrderID);
                if (PartsDataView is object)
                {
                    foreach (DataRow row in PartsDataView.Table.Rows)
                    {
                        var oQuoteOrderPart = new Entity.QuoteOrderParts.QuoteOrderPart();
                        oQuoteOrderPart.SetQuoteOrderID = oQuoteOrder.QuoteOrderID;
                        oQuoteOrderPart.SetPartID = row["PartID"];
                        oQuoteOrderPart.SetQuantity = Entity.Sys.Helper.MakeIntegerValid(row["Quantity"]);
                        oQuoteOrderPart.SetPrice = Entity.Sys.Helper.MakeDoubleValid(row["Price"]);
                        App.DB.QuoteOrderPart.Insert(oQuoteOrderPart);
                    }
                }

                App.DB.QuoteOrderProduct.QuoteOrderProduct_DeleteForQuoteOrder(oQuoteOrder.QuoteOrderID);
                if (ProductsDataView is object)
                {
                    foreach (DataRow row in ProductsDataView.Table.Rows)
                    {
                        var oQuoteOrderProduct = new Entity.QuoteOrderProducts.QuoteOrderProduct();
                        oQuoteOrderProduct.SetQuoteOrderID = oQuoteOrder.QuoteOrderID;
                        oQuoteOrderProduct.SetProductID = row["ProductID"];
                        oQuoteOrderProduct.SetQuantity = Entity.Sys.Helper.MakeIntegerValid(row["Quantity"]);
                        oQuoteOrderProduct.SetPrice = Entity.Sys.Helper.MakeDoubleValid(row["Price"]);
                        App.DB.QuoteOrderProduct.Insert(oQuoteOrderProduct);
                    }
                }

                App.DB.QuoteOrder.QuoteOrder_DeleteItemsIncluded(oQuoteOrder.QuoteOrderID);
                if (ConfirmedPriceRequestDataView is object)
                {
                    foreach (DataRow row in ConfirmedPriceRequestDataView.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Included"], "1", false)))
                        {
                            if (Information.IsDBNull(row["SellPrice"]) | !Information.IsNumeric(row["SellPrice"]))
                            {
                                App.ShowMessage("Please enter a Sell Price for all Items checked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return default;
                            }
                        }
                    }

                    foreach (DataRow row in ConfirmedPriceRequestDataView.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Included"], "1", false)))
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], "Part", false)))
                            {
                                App.DB.QuoteOrder.QuoteOrderPartsToInclude_Insert(oQuoteOrder.QuoteOrderID, Conversions.ToInteger(row["PartSupplierID"]), Conversions.ToDouble(row["SellPrice"]));
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], "Product", false)))
                            {
                                App.DB.QuoteOrder.QuoteOrderProductsToInclude_Insert(oQuoteOrder.QuoteOrderID, Conversions.ToInteger(row["ProductSupplierID"]), Conversions.ToDouble(row["SellPrice"]));
                            }
                        }
                    }
                }

                oQuoteOrder.Exists = true;
                CurrentQuoteOrder = oQuoteOrder;
                StateChanged?.Invoke(CurrentQuoteOrder.QuoteOrderID);
                return true;
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

        private void SetFormState(bool Enabled)
        {
            btnFindCustomer.Enabled = Enabled;
            if (Enabled == false)
            {
                btnFindInvoiceAddress.Enabled = Enabled;
                btnFindContact.Enabled = Enabled;
            }

            btnFindPart.Enabled = Enabled;
            btnFindProduct.Enabled = Enabled;
            btnFindSite.Enabled = Enabled;
            btnRemoveParts.Enabled = Enabled;
            btnRemoveProducts.Enabled = Enabled;
            cboStatus.Enabled = Enabled;
            cboUsers.Enabled = Enabled;
            chkDeadlineNA.Enabled = Enabled;
            dgParts.Enabled = Enabled;
            dgProducts.Enabled = Enabled;
            dtpDeliveryDeadline.Enabled = Enabled;
            dtpEnquiryDate.Enabled = Enabled;
            dtpValidUntil.Enabled = Enabled;
            txtAvailability.Enabled = Enabled;
            txtCustRef.Enabled = Enabled;
            txtPriceDetails.Enabled = Enabled;
            txtPriceExcludeDetails.Enabled = Enabled;
            txtSpecialInstructions.Enabled = Enabled;
        }

        private void addProduct(int ProductID)
        {
            var oProduct = App.DB.Product.Product_Get(ProductID);
            if (ProductsDataView is null)
            {
                ProductsDataView = new DataView(new DataTable());
                ProductsDataView.Table.Columns.Add("ProductID");
                ProductsDataView.Table.Columns.Add("typemakemodel");
                ProductsDataView.Table.Columns.Add("Number");
                ProductsDataView.Table.Columns.Add("SellPrice");
                ProductsDataView.Table.Columns.Add("Quantity");
                ProductsDataView.Table.Columns.Add("Price");
            }

            var dr = ProductsDataView.Table.NewRow();
            dr["ProductID"] = ProductID;
            dr["typemakemodel"] = oProduct.Name;
            dr["Number"] = oProduct.Number;
            dr["SellPrice"] = oProduct.SellPrice;
            ProductsDataView.Table.Rows.Add(dr);
        }

        private void addPart(int PartID)
        {
            var oPart = App.DB.Part.Part_Get(PartID);
            if (PartsDataView is null)
            {
                PartsDataView = new DataView(new DataTable());
                PartsDataView.Table.Columns.Add("PartID");
                PartsDataView.Table.Columns.Add("Name");
                PartsDataView.Table.Columns.Add("Number");
                PartsDataView.Table.Columns.Add("SellPrice");
                PartsDataView.Table.Columns.Add("Quantity");
                PartsDataView.Table.Columns.Add("Price");
            }

            var dr = PartsDataView.Table.NewRow();
            dr["PartID"] = PartID;
            dr["Name"] = oPart.Name;
            dr["Number"] = oPart.Number;
            dr["SellPrice"] = oPart.SellPrice;
            PartsDataView.Table.Rows.Add(dr);
        }

        public void RejectReasonChanged(string Reason, int ReasonID)
        {
            CurrentQuoteOrder.SetReasonForReject = Reason;
            CurrentQuoteOrder.SetReasonForRejectID = ReasonID;
            Save();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}