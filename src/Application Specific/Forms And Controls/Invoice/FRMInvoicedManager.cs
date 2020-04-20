using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMInvoicedManager : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMInvoicedManager() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMInvoicedManager_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // PopulateDatagrid()

            // Add any initialization after the InitializeComponent() call

        }

        // Form overrides dispose to clean up the component list.
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
        private Button _btnPrintOneItemOneInvoice;

        internal Button btnPrintOneItemOneInvoice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintOneItemOneInvoice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintOneItemOneInvoice != null)
                {
                    _btnPrintOneItemOneInvoice.Click -= btnPrintOneItemOneInvoice_Click;
                }

                _btnPrintOneItemOneInvoice = value;
                if (_btnPrintOneItemOneInvoice != null)
                {
                    _btnPrintOneItemOneInvoice.Click += btnPrintOneItemOneInvoice_Click;
                }
            }
        }

        private Button _btnExport;

        internal Button btnExport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExport != null)
                {
                    _btnExport.Click -= btnExport_Click;
                }

                _btnExport = value;
                if (_btnExport != null)
                {
                    _btnExport.Click += btnExport_Click;
                }
            }
        }

        private Button _btnReset;

        internal Button btnReset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReset != null)
                {
                    _btnReset.Click -= btnReset_Click;
                }

                _btnReset = value;
                if (_btnReset != null)
                {
                    _btnReset.Click += btnReset_Click;
                }
            }
        }

        private GroupBox _grpFilter;

        internal GroupBox grpFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilter != null)
                {
                }

                _grpFilter = value;
                if (_grpFilter != null)
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

        private Label _lblCustomer;

        internal Label lblCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomer != null)
                {
                }

                _lblCustomer = value;
                if (_lblCustomer != null)
                {
                }
            }
        }

        private TextBox _txtPostcode;

        internal TextBox txtPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPostcode != null)
                {
                    _txtPostcode.KeyDown -= txtJobNumber_TextChanged;
                }

                _txtPostcode = value;
                if (_txtPostcode != null)
                {
                    _txtPostcode.KeyDown += txtJobNumber_TextChanged;
                }
            }
        }

        private Label _lblPostcode;

        internal Label lblPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPostcode != null)
                {
                }

                _lblPostcode = value;
                if (_lblPostcode != null)
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

        private TextBox _txtJobNumber;

        internal TextBox txtJobNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobNumber != null)
                {
                    _txtJobNumber.KeyDown -= txtJobNumber_TextChanged;
                }

                _txtJobNumber = value;
                if (_txtJobNumber != null)
                {
                    _txtJobNumber.KeyDown += txtJobNumber_TextChanged;
                }
            }
        }

        private Label _lblRefNo;

        internal Label lblRefNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRefNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRefNo != null)
                {
                }

                _lblRefNo = value;
                if (_lblRefNo != null)
                {
                }
            }
        }

        private Label _lblProperty;

        internal Label lblProperty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProperty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProperty != null)
                {
                }

                _lblProperty = value;
                if (_lblProperty != null)
                {
                }
            }
        }

        private Label _lblType;

        internal Label lblType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblType != null)
                {
                }

                _lblType = value;
                if (_lblType != null)
                {
                }
            }
        }

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                }

                _cboType = value;
                if (_cboType != null)
                {
                }
            }
        }

        private Label _lblDate;

        internal Label lblDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDate != null)
                {
                }

                _lblDate = value;
                if (_lblDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpRaisedTo;

        internal DateTimePicker dtpRaisedTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpRaisedTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpRaisedTo != null)
                {
                }

                _dtpRaisedTo = value;
                if (_dtpRaisedTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpRaisedFrom;

        internal DateTimePicker dtpRaisedFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpRaisedFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpRaisedFrom != null)
                {
                }

                _dtpRaisedFrom = value;
                if (_dtpRaisedFrom != null)
                {
                }
            }
        }

        private Label _lblDateBetween;

        internal Label lblDateBetween
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDateBetween;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDateBetween != null)
                {
                }

                _lblDateBetween = value;
                if (_lblDateBetween != null)
                {
                }
            }
        }

        private Label _lblInvoiceNumber;

        internal Label lblInvoiceNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoiceNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoiceNumber != null)
                {
                }

                _lblInvoiceNumber = value;
                if (_lblInvoiceNumber != null)
                {
                }
            }
        }

        private Label _lblStatus;

        internal Label lblStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblStatus != null)
                {
                }

                _lblStatus = value;
                if (_lblStatus != null)
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
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                }
            }
        }

        private GroupBox _grpInvoices;

        internal GroupBox grpInvoices
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpInvoices;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpInvoices != null)
                {
                }

                _grpInvoices = value;
                if (_grpInvoices != null)
                {
                }
            }
        }

        private Label _lblInvoicePartPayed;

        internal Label lblInvoicePartPayed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoicePartPayed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoicePartPayed != null)
                {
                }

                _lblInvoicePartPayed = value;
                if (_lblInvoicePartPayed != null)
                {
                }
            }
        }

        private Label _lblInvoicePayed;

        internal Label lblInvoicePayed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoicePayed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoicePayed != null)
                {
                }

                _lblInvoicePayed = value;
                if (_lblInvoicePayed != null)
                {
                }
            }
        }

        private Label _lblGreenColour;

        internal Label lblGreenColour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblGreenColour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblGreenColour != null)
                {
                }

                _lblGreenColour = value;
                if (_lblGreenColour != null)
                {
                }
            }
        }

        private Label _lblGoldColour;

        internal Label lblGoldColour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblGoldColour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblGoldColour != null)
                {
                }

                _lblGoldColour = value;
                if (_lblGoldColour != null)
                {
                }
            }
        }

        private Label _lblInvoicedNotPayed;

        internal Label lblInvoicedNotPayed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoicedNotPayed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoicedNotPayed != null)
                {
                }

                _lblInvoicedNotPayed = value;
                if (_lblInvoicedNotPayed != null)
                {
                }
            }
        }

        private Label _lblRedColour;

        internal Label lblRedColour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRedColour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRedColour != null)
                {
                }

                _lblRedColour = value;
                if (_lblRedColour != null)
                {
                }
            }
        }

        private DataGrid _dgInvoices;

        internal DataGrid dgInvoices
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgInvoices;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgInvoices != null)
                {
                    _dgInvoices.MouseUp -= dgInvoices_MouseUp;
                    _dgInvoices.DoubleClick -= dgInvoices_DoubleClick;
                }

                _dgInvoices = value;
                if (_dgInvoices != null)
                {
                    _dgInvoices.MouseUp += dgInvoices_MouseUp;
                    _dgInvoices.DoubleClick += dgInvoices_DoubleClick;
                }
            }
        }

        private Button _btnSelectAll;

        internal Button btnSelectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click -= btnSelectAll_Click;
                }

                _btnSelectAll = value;
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click += btnSelectAll_Click;
                }
            }
        }

        private Button _btnDeselectAll;

        internal Button btnDeselectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeselectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeselectAll != null)
                {
                    _btnDeselectAll.Click -= btnDeselectAll_Click;
                }

                _btnDeselectAll = value;
                if (_btnDeselectAll != null)
                {
                    _btnDeselectAll.Click += btnDeselectAll_Click;
                }
            }
        }

        private Label _lblUser;

        internal Label lblUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblUser != null)
                {
                }

                _lblUser = value;
                if (_lblUser != null)
                {
                }
            }
        }

        private ComboBox _cboUser;

        internal ComboBox cboUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboUser != null)
                {
                }

                _cboUser = value;
                if (_cboUser != null)
                {
                }
            }
        }

        private TextBox _txtInvoiceNumber;

        internal TextBox txtInvoiceNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvoiceNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvoiceNumber != null)
                {
                    _txtInvoiceNumber.KeyDown -= txtJobNumber_TextChanged;
                }

                _txtInvoiceNumber = value;
                if (_txtInvoiceNumber != null)
                {
                    _txtInvoiceNumber.KeyDown += txtJobNumber_TextChanged;
                }
            }
        }

        private Button _btnChange;

        internal Button btnChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnChange;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnChange != null)
                {
                    _btnChange.Click -= btnChange_Click;
                }

                _btnChange = value;
                if (_btnChange != null)
                {
                    _btnChange.Click += btnChange_Click;
                }
            }
        }

        private Button _btnMarkAsNotExported;

        internal Button btnMarkAsNotExported
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMarkAsNotExported;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMarkAsNotExported != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnMarkAsNotExported.Click -= btnMarkAsNotExported_Click;
                }

                _btnMarkAsNotExported = value;
                if (_btnMarkAsNotExported != null)
                {
                    _btnMarkAsNotExported.Click += btnMarkAsNotExported_Click;
                }
            }
        }

        private ComboBox _cboExported;

        internal ComboBox cboExported
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboExported;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboExported != null)
                {
                    _cboExported.SelectedIndexChanged -= cboExportedToSage_SelectedIndexChanged;
                }

                _cboExported = value;
                if (_cboExported != null)
                {
                    _cboExported.SelectedIndexChanged += cboExportedToSage_SelectedIndexChanged;
                }
            }
        }

        private Label _lblExported;

        internal Label lblExported
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblExported;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblExported != null)
                {
                }

                _lblExported = value;
                if (_lblExported != null)
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

        private Label _lblRegion;

        internal Label lblRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRegion != null)
                {
                }

                _lblRegion = value;
                if (_lblRegion != null)
                {
                }
            }
        }

        private ComboBox _cboRegion;

        internal ComboBox cboRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRegion != null)
                {
                }

                _cboRegion = value;
                if (_cboRegion != null)
                {
                }
            }
        }

        private Button _btnGenVal;

        internal Button btnGenVal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGenVal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGenVal != null)
                {
                    _btnGenVal.Click -= btnGenNCCVal_Click;
                }

                _btnGenVal = value;
                if (_btnGenVal != null)
                {
                    _btnGenVal.Click += btnGenNCCVal_Click;
                }
            }
        }

        private Label _lblSageMonth;

        internal Label lblSageMonth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSageMonth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSageMonth != null)
                {
                }

                _lblSageMonth = value;
                if (_lblSageMonth != null)
                {
                }
            }
        }

        private TextBox _txtSageMonth;

        internal TextBox txtSageMonth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSageMonth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSageMonth != null)
                {
                    _txtSageMonth.DoubleClick -= txtSageMonth_TextChanged;
                }

                _txtSageMonth = value;
                if (_txtSageMonth != null)
                {
                    _txtSageMonth.DoubleClick += txtSageMonth_TextChanged;
                }
            }
        }

        private Button _btnSalesCredit;

        internal Button btnSalesCredit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSalesCredit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSalesCredit != null)
                {
                    _btnSalesCredit.Click -= btnSalesCredit_Click;
                }

                _btnSalesCredit = value;
                if (_btnSalesCredit != null)
                {
                    _btnSalesCredit.Click += btnSalesCredit_Click;
                }
            }
        }

        private ContextMenuStrip _cmsValType;

        internal ContextMenuStrip cmsValType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsValType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsValType != null)
                {
                }

                _cmsValType = value;
                if (_cmsValType != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiNCCVal;

        internal ToolStripMenuItem tsmiNCCVal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiNCCVal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiNCCVal != null)
                {
                    _tsmiNCCVal.Click -= tsmiNCCVal_Click;
                }

                _tsmiNCCVal = value;
                if (_tsmiNCCVal != null)
                {
                    _tsmiNCCVal.Click += tsmiNCCVal_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiGenericVal;

        internal ToolStripMenuItem tsmiGenericVal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiGenericVal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiGenericVal != null)
                {
                    _tsmiGenericVal.Click -= tsmiGenericVal_Click;
                }

                _tsmiGenericVal = value;
                if (_tsmiGenericVal != null)
                {
                    _tsmiGenericVal.Click += tsmiGenericVal_Click;
                }
            }
        }

        private ContextMenuStrip _cmsChange;

        internal ContextMenuStrip cmsChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsChange;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsChange != null)
                {
                }

                _cmsChange = value;
                if (_cmsChange != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiPaymentTerms;

        internal ToolStripMenuItem tsmiPaymentTerms
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiPaymentTerms;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiPaymentTerms != null)
                {
                    _tsmiPaymentTerms.Click -= tsmiPaymentTerms_Click;
                }

                _tsmiPaymentTerms = value;
                if (_tsmiPaymentTerms != null)
                {
                    _tsmiPaymentTerms.Click += tsmiPaymentTerms_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiInvoicedTotal;

        internal ToolStripMenuItem tsmiInvoicedTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiInvoicedTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiInvoicedTotal != null)
                {
                    _tsmiInvoicedTotal.Click -= tsmiInvoicedTotal_Click;
                }

                _tsmiInvoicedTotal = value;
                if (_tsmiInvoicedTotal != null)
                {
                    _tsmiInvoicedTotal.Click += tsmiInvoicedTotal_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiVatRate;

        internal ToolStripMenuItem tsmiVatRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiVatRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiVatRate != null)
                {
                    _tsmiVatRate.Click -= tsmiVatRate_Click;
                }

                _tsmiVatRate = value;
                if (_tsmiVatRate != null)
                {
                    _tsmiVatRate.Click += tsmiVatRate_Click;
                }
            }
        }

        private ContextMenuStrip _cmsSalesCredit;

        internal ContextMenuStrip cmsSalesCredit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsSalesCredit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsSalesCredit != null)
                {
                }

                _cmsSalesCredit = value;
                if (_cmsSalesCredit != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiIssue;

        internal ToolStripMenuItem tsmiIssue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiIssue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiIssue != null)
                {
                    _tsmiIssue.Click -= tsmiIssue_Click;
                }

                _tsmiIssue = value;
                if (_tsmiIssue != null)
                {
                    _tsmiIssue.Click += tsmiIssue_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiRemove;

        internal ToolStripMenuItem tsmiRemove
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiRemove;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiRemove != null)
                {
                    _tsmiRemove.Click -= tsmiRemove_Click;
                }

                _tsmiRemove = value;
                if (_tsmiRemove != null)
                {
                    _tsmiRemove.Click += tsmiRemove_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiBatchPrint;

        internal ToolStripMenuItem tsmiBatchPrint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiBatchPrint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiBatchPrint != null)
                {
                    _tsmiBatchPrint.Click -= tsmiBatchPrint_Click;
                }

                _tsmiBatchPrint = value;
                if (_tsmiBatchPrint != null)
                {
                    _tsmiBatchPrint.Click += tsmiBatchPrint_Click;
                }
            }
        }

        private ContextMenuStrip _cmsExportForAccounts;

        internal ContextMenuStrip cmsExportForAccounts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsExportForAccounts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsExportForAccounts != null)
                {
                }

                _cmsExportForAccounts = value;
                if (_cmsExportForAccounts != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiSunExport;

        internal ToolStripMenuItem tsmiSunExport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiSunExport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiSunExport != null)
                {
                    _tsmiSunExport.Click -= tsmiSunExport_Click;
                }

                _tsmiSunExport = value;
                if (_tsmiSunExport != null)
                {
                    _tsmiSunExport.Click += tsmiSunExport_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiSageExport;

        internal ToolStripMenuItem tsmiSageExport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiSageExport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiSageExport != null)
                {
                    _tsmiSageExport.Click -= tsmiSageExport_Click;
                }

                _tsmiSageExport = value;
                if (_tsmiSageExport != null)
                {
                    _tsmiSageExport.Click += tsmiSageExport_Click;
                }
            }
        }

        private Button _btnExportToAccounts;

        internal Button btnExportToAccounts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExportToAccounts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExportToAccounts != null)
                {
                    _btnExportToAccounts.Click -= btnExportToAccounts_Click;
                }

                _btnExportToAccounts = value;
                if (_btnExportToAccounts != null)
                {
                    _btnExportToAccounts.Click += btnExportToAccounts_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiAccountNumber;

        internal ToolStripMenuItem tsmiAccountNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiAccountNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiAccountNumber != null)
                {
                    _tsmiAccountNumber.Click -= tsmiAccountNumber_Click;
                }

                _tsmiAccountNumber = value;
                if (_tsmiAccountNumber != null)
                {
                    _tsmiAccountNumber.Click += tsmiAccountNumber_Click;
                }
            }
        }

        private Label _lblDept;

        internal Label lblDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDept != null)
                {
                }

                _lblDept = value;
                if (_lblDept != null)
                {
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

        private ToolStripMenuItem _tsmiOrderNo;

        internal ToolStripMenuItem tsmiOrderNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiOrderNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiOrderNo != null)
                {
                    _tsmiOrderNo.Click -= tsmiOrderNo_Click;
                }

                _tsmiOrderNo = value;
                if (_tsmiOrderNo != null)
                {
                    _tsmiOrderNo.Click += tsmiOrderNo_Click;
                }
            }
        }

        private DateTimePicker _dtpExportedOn;

        internal DateTimePicker dtpExportedOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpExportedOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpExportedOn != null)
                {
                }

                _dtpExportedOn = value;
                if (_dtpExportedOn != null)
                {
                }
            }
        }

        private Label _lblExportedOn;

        internal Label lblExportedOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblExportedOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblExportedOn != null)
                {
                }

                _lblExportedOn = value;
                if (_lblExportedOn != null)
                {
                }
            }
        }

        private CheckBox _chkExportedOn;

        internal CheckBox chkExportedOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkExportedOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkExportedOn != null)
                {
                    _chkExportedOn.Click -= chkExportedOn_Click;
                }

                _chkExportedOn = value;
                if (_chkExportedOn != null)
                {
                    _chkExportedOn.Click += chkExportedOn_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiSorVal;

        internal ToolStripMenuItem tsmiSorVal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiSorVal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiSorVal != null)
                {
                    _tsmiSorVal.Click -= tsmiSorVal_Click;
                }

                _tsmiSorVal = value;
                if (_tsmiSorVal != null)
                {
                    _tsmiSorVal.Click += tsmiSorVal_Click;
                }
            }
        }

        private Button _btnView;

        internal Button btnView
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnView;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnView != null)
                {
                    _btnView.Click -= btnView_Click;
                }

                _btnView = value;
                if (_btnView != null)
                {
                    _btnView.Click += btnView_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _btnPrintOneItemOneInvoice = new Button();
            _btnPrintOneItemOneInvoice.Click += new EventHandler(btnPrintOneItemOneInvoice_Click);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _grpFilter = new GroupBox();
            _dtpExportedOn = new DateTimePicker();
            _lblExportedOn = new Label();
            _lblDept = new Label();
            _cboDept = new ComboBox();
            _lblSageMonth = new Label();
            _txtSageMonth = new TextBox();
            _txtSageMonth.DoubleClick += new EventHandler(txtSageMonth_TextChanged);
            _lblRegion = new Label();
            _cboRegion = new ComboBox();
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _cboExported = new ComboBox();
            _cboExported.SelectedIndexChanged += new EventHandler(cboExportedToSage_SelectedIndexChanged);
            _lblExported = new Label();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _lblCustomer = new Label();
            _txtPostcode = new TextBox();
            _txtPostcode.KeyDown += new KeyEventHandler(txtJobNumber_TextChanged);
            _lblPostcode = new Label();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _txtSite = new TextBox();
            _txtJobNumber = new TextBox();
            _txtJobNumber.KeyDown += new KeyEventHandler(txtJobNumber_TextChanged);
            _lblRefNo = new Label();
            _lblProperty = new Label();
            _lblType = new Label();
            _cboType = new ComboBox();
            _lblDateBetween = new Label();
            _dtpRaisedFrom = new DateTimePicker();
            _dtpRaisedTo = new DateTimePicker();
            _lblDate = new Label();
            _cboStatus = new ComboBox();
            _lblStatus = new Label();
            _lblInvoiceNumber = new Label();
            _lblUser = new Label();
            _cboUser = new ComboBox();
            _txtInvoiceNumber = new TextBox();
            _txtInvoiceNumber.KeyDown += new KeyEventHandler(txtJobNumber_TextChanged);
            _chkExportedOn = new CheckBox();
            _chkExportedOn.Click += new EventHandler(chkExportedOn_Click);
            _grpInvoices = new GroupBox();
            _btnSalesCredit = new Button();
            _btnSalesCredit.Click += new EventHandler(btnSalesCredit_Click);
            _btnChange = new Button();
            _btnChange.Click += new EventHandler(btnChange_Click);
            _dgInvoices = new DataGrid();
            _dgInvoices.MouseUp += new MouseEventHandler(dgInvoices_MouseUp);
            _dgInvoices.DoubleClick += new EventHandler(dgInvoices_DoubleClick);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnDeselectAll = new Button();
            _btnDeselectAll.Click += new EventHandler(btnDeselectAll_Click);
            _lblInvoicePartPayed = new Label();
            _lblInvoicePayed = new Label();
            _lblGreenColour = new Label();
            _lblGoldColour = new Label();
            _lblInvoicedNotPayed = new Label();
            _lblRedColour = new Label();
            _btnView = new Button();
            _btnView.Click += new EventHandler(btnView_Click);
            _btnMarkAsNotExported = new Button();
            _btnMarkAsNotExported.Click += new EventHandler(btnMarkAsNotExported_Click);
            _btnGenVal = new Button();
            _btnGenVal.Click += new EventHandler(btnGenNCCVal_Click);
            _cmsValType = new ContextMenuStrip(components);
            _tsmiNCCVal = new ToolStripMenuItem();
            _tsmiNCCVal.Click += new EventHandler(tsmiNCCVal_Click);
            _tsmiGenericVal = new ToolStripMenuItem();
            _tsmiGenericVal.Click += new EventHandler(tsmiGenericVal_Click);
            _tsmiSorVal = new ToolStripMenuItem();
            _tsmiSorVal.Click += new EventHandler(tsmiSorVal_Click);
            _cmsChange = new ContextMenuStrip(components);
            _tsmiPaymentTerms = new ToolStripMenuItem();
            _tsmiPaymentTerms.Click += new EventHandler(tsmiPaymentTerms_Click);
            _tsmiInvoicedTotal = new ToolStripMenuItem();
            _tsmiInvoicedTotal.Click += new EventHandler(tsmiInvoicedTotal_Click);
            _tsmiVatRate = new ToolStripMenuItem();
            _tsmiVatRate.Click += new EventHandler(tsmiVatRate_Click);
            _tsmiAccountNumber = new ToolStripMenuItem();
            _tsmiAccountNumber.Click += new EventHandler(tsmiAccountNumber_Click);
            _tsmiOrderNo = new ToolStripMenuItem();
            _tsmiOrderNo.Click += new EventHandler(tsmiOrderNo_Click);
            _cmsSalesCredit = new ContextMenuStrip(components);
            _tsmiIssue = new ToolStripMenuItem();
            _tsmiIssue.Click += new EventHandler(tsmiIssue_Click);
            _tsmiRemove = new ToolStripMenuItem();
            _tsmiRemove.Click += new EventHandler(tsmiRemove_Click);
            _tsmiBatchPrint = new ToolStripMenuItem();
            _tsmiBatchPrint.Click += new EventHandler(tsmiBatchPrint_Click);
            _cmsExportForAccounts = new ContextMenuStrip(components);
            _tsmiSunExport = new ToolStripMenuItem();
            _tsmiSunExport.Click += new EventHandler(tsmiSunExport_Click);
            _tsmiSageExport = new ToolStripMenuItem();
            _tsmiSageExport.Click += new EventHandler(tsmiSageExport_Click);
            _btnExportToAccounts = new Button();
            _btnExportToAccounts.Click += new EventHandler(btnExportToAccounts_Click);
            _grpFilter.SuspendLayout();
            _grpInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoices).BeginInit();
            _cmsValType.SuspendLayout();
            _cmsChange.SuspendLayout();
            _cmsSalesCredit.SuspendLayout();
            _cmsExportForAccounts.SuspendLayout();
            SuspendLayout();
            // 
            // btnPrintOneItemOneInvoice
            // 
            _btnPrintOneItemOneInvoice.AccessibleDescription = "Export Job List To Excel";
            _btnPrintOneItemOneInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnPrintOneItemOneInvoice.Location = new Point(125, 594);
            _btnPrintOneItemOneInvoice.Name = "btnPrintOneItemOneInvoice";
            _btnPrintOneItemOneInvoice.Size = new Size(141, 23);
            _btnPrintOneItemOneInvoice.TabIndex = 27;
            _btnPrintOneItemOneInvoice.Text = "Regenerate Invoice";
            // 
            // btnExport
            // 
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 594);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 25;
            _btnExport.Text = "Export";
            // 
            // btnReset
            // 
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(67, 594);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(55, 23);
            _btnReset.TabIndex = 26;
            _btnReset.Text = "Reset";
            // 
            // grpFilter
            // 
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_dtpExportedOn);
            _grpFilter.Controls.Add(_lblExportedOn);
            _grpFilter.Controls.Add(_lblDept);
            _grpFilter.Controls.Add(_cboDept);
            _grpFilter.Controls.Add(_lblSageMonth);
            _grpFilter.Controls.Add(_txtSageMonth);
            _grpFilter.Controls.Add(_lblRegion);
            _grpFilter.Controls.Add(_cboRegion);
            _grpFilter.Controls.Add(_btnSearch);
            _grpFilter.Controls.Add(_cboExported);
            _grpFilter.Controls.Add(_lblExported);
            _grpFilter.Controls.Add(_btnFindCustomer);
            _grpFilter.Controls.Add(_txtCustomer);
            _grpFilter.Controls.Add(_lblCustomer);
            _grpFilter.Controls.Add(_txtPostcode);
            _grpFilter.Controls.Add(_lblPostcode);
            _grpFilter.Controls.Add(_btnFindSite);
            _grpFilter.Controls.Add(_txtSite);
            _grpFilter.Controls.Add(_txtJobNumber);
            _grpFilter.Controls.Add(_lblRefNo);
            _grpFilter.Controls.Add(_lblProperty);
            _grpFilter.Controls.Add(_lblType);
            _grpFilter.Controls.Add(_cboType);
            _grpFilter.Controls.Add(_lblDateBetween);
            _grpFilter.Controls.Add(_dtpRaisedFrom);
            _grpFilter.Controls.Add(_dtpRaisedTo);
            _grpFilter.Controls.Add(_lblDate);
            _grpFilter.Controls.Add(_cboStatus);
            _grpFilter.Controls.Add(_lblStatus);
            _grpFilter.Controls.Add(_lblInvoiceNumber);
            _grpFilter.Controls.Add(_lblUser);
            _grpFilter.Controls.Add(_cboUser);
            _grpFilter.Controls.Add(_txtInvoiceNumber);
            _grpFilter.Controls.Add(_chkExportedOn);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(1123, 236);
            _grpFilter.TabIndex = 24;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            // 
            // dtpExportedOn
            // 
            _dtpExportedOn.Location = new Point(541, 163);
            _dtpExportedOn.Name = "dtpExportedOn";
            _dtpExportedOn.Size = new Size(186, 21);
            _dtpExportedOn.TabIndex = 44;
            // 
            // lblExportedOn
            // 
            _lblExportedOn.Location = new Point(416, 164);
            _lblExportedOn.Name = "lblExportedOn";
            _lblExportedOn.Size = new Size(85, 16);
            _lblExportedOn.TabIndex = 45;
            _lblExportedOn.Text = "Exported On";
            // 
            // lblDept
            // 
            _lblDept.AutoSize = true;
            _lblDept.Location = new Point(747, 166);
            _lblDept.Name = "lblDept";
            _lblDept.Size = new Size(76, 13);
            _lblDept.TabIndex = 42;
            _lblDept.Text = "Cost Centre";
            // 
            // cboDept
            // 
            _cboDept.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDept.Location = new Point(845, 164);
            _cboDept.Name = "cboDept";
            _cboDept.Size = new Size(224, 21);
            _cboDept.TabIndex = 43;
            // 
            // lblSageMonth
            // 
            _lblSageMonth.Location = new Point(416, 197);
            _lblSageMonth.Name = "lblSageMonth";
            _lblSageMonth.Size = new Size(98, 19);
            _lblSageMonth.TabIndex = 40;
            _lblSageMonth.Text = "Account Month";
            // 
            // txtSageMonth
            // 
            _txtSageMonth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSageMonth.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSageMonth.Location = new Point(520, 195);
            _txtSageMonth.Name = "txtSageMonth";
            _txtSageMonth.ReadOnly = true;
            _txtSageMonth.Size = new Size(207, 21);
            _txtSageMonth.TabIndex = 41;
            // 
            // lblRegion
            // 
            _lblRegion.Location = new Point(8, 198);
            _lblRegion.Name = "lblRegion";
            _lblRegion.Size = new Size(72, 16);
            _lblRegion.TabIndex = 39;
            _lblRegion.Text = "Region";
            // 
            // cboRegion
            // 
            _cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegion.Location = new Point(160, 195);
            _cboRegion.Name = "cboRegion";
            _cboRegion.Size = new Size(248, 21);
            _cboRegion.TabIndex = 38;
            // 
            // btnSearch
            // 
            _btnSearch.AccessibleDescription = "Export Job List To Excel";
            _btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSearch.Location = new Point(981, 198);
            _btnSearch.Name = "btnSearch";
            _btnSearch.Size = new Size(88, 23);
            _btnSearch.TabIndex = 30;
            _btnSearch.Text = "Run Filter";
            // 
            // cboExported
            // 
            _cboExported.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboExported.Items.AddRange(new object[] { "Show All", "Exported", "Not Exported" });
            _cboExported.Location = new Point(160, 161);
            _cboExported.Name = "cboExported";
            _cboExported.Size = new Size(248, 21);
            _cboExported.TabIndex = 29;
            // 
            // lblExported
            // 
            _lblExported.Location = new Point(8, 164);
            _lblExported.Name = "lblExported";
            _lblExported.Size = new Size(122, 18);
            _lblExported.TabIndex = 28;
            _lblExported.Text = "Exported";
            // 
            // btnFindCustomer
            // 
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(1077, 40);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 2;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = false;
            // 
            // txtCustomer
            // 
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(160, 40);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(909, 21);
            _txtCustomer.TabIndex = 1;
            // 
            // lblCustomer
            // 
            _lblCustomer.Location = new Point(8, 40);
            _lblCustomer.Name = "lblCustomer";
            _lblCustomer.Size = new Size(64, 16);
            _lblCustomer.TabIndex = 27;
            _lblCustomer.Text = "Customer";
            // 
            // txtPostcode
            // 
            _txtPostcode.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPostcode.Location = new Point(160, 88);
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(248, 21);
            _txtPostcode.TabIndex = 5;
            // 
            // lblPostcode
            // 
            _lblPostcode.Location = new Point(8, 88);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(64, 16);
            _lblPostcode.TabIndex = 20;
            _lblPostcode.Text = "Postcode";
            // 
            // btnFindSite
            // 
            _btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSite.BackColor = Color.White;
            _btnFindSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSite.Location = new Point(1077, 64);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(32, 23);
            _btnFindSite.TabIndex = 4;
            _btnFindSite.Text = "...";
            _btnFindSite.UseVisualStyleBackColor = false;
            // 
            // txtSite
            // 
            _txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSite.Location = new Point(160, 64);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(909, 21);
            _txtSite.TabIndex = 3;
            // 
            // txtJobNumber
            // 
            _txtJobNumber.Location = new Point(160, 136);
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.Size = new Size(248, 21);
            _txtJobNumber.TabIndex = 9;
            // 
            // lblRefNo
            // 
            _lblRefNo.Location = new Point(8, 136);
            _lblRefNo.Name = "lblRefNo";
            _lblRefNo.Size = new Size(136, 16);
            _lblRefNo.TabIndex = 6;
            _lblRefNo.Text = "Job/Order/Contract No";
            // 
            // lblProperty
            // 
            _lblProperty.Location = new Point(8, 64);
            _lblProperty.Name = "lblProperty";
            _lblProperty.Size = new Size(64, 16);
            _lblProperty.TabIndex = 2;
            _lblProperty.Text = "Property";
            // 
            // lblType
            // 
            _lblType.Location = new Point(8, 112);
            _lblType.Name = "lblType";
            _lblType.Size = new Size(48, 16);
            _lblType.TabIndex = 4;
            _lblType.Text = "Type";
            // 
            // cboType
            // 
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(160, 112);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(248, 21);
            _cboType.TabIndex = 7;
            // 
            // lblDateBetween
            // 
            _lblDateBetween.Location = new Point(416, 16);
            _lblDateBetween.Name = "lblDateBetween";
            _lblDateBetween.Size = new Size(48, 16);
            _lblDateBetween.TabIndex = 14;
            _lblDateBetween.Text = "and";
            // 
            // dtpRaisedFrom
            // 
            _dtpRaisedFrom.Location = new Point(160, 16);
            _dtpRaisedFrom.Name = "dtpRaisedFrom";
            _dtpRaisedFrom.Size = new Size(248, 21);
            _dtpRaisedFrom.TabIndex = 15;
            // 
            // dtpRaisedTo
            // 
            _dtpRaisedTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dtpRaisedTo.Location = new Point(520, 16);
            _dtpRaisedTo.Name = "dtpRaisedTo";
            _dtpRaisedTo.Size = new Size(549, 21);
            _dtpRaisedTo.TabIndex = 16;
            // 
            // lblDate
            // 
            _lblDate.Location = new Point(8, 16);
            _lblDate.Name = "lblDate";
            _lblDate.Size = new Size(136, 16);
            _lblDate.TabIndex = 17;
            _lblDate.Text = "Raised Date Between : ";
            // 
            // cboStatus
            // 
            _cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.Location = new Point(520, 88);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(549, 21);
            _cboStatus.TabIndex = 8;
            // 
            // lblStatus
            // 
            _lblStatus.Location = new Point(416, 90);
            _lblStatus.Name = "lblStatus";
            _lblStatus.Size = new Size(48, 16);
            _lblStatus.TabIndex = 5;
            _lblStatus.Text = "Status";
            // 
            // lblInvoiceNumber
            // 
            _lblInvoiceNumber.Location = new Point(416, 114);
            _lblInvoiceNumber.Name = "lblInvoiceNumber";
            _lblInvoiceNumber.Size = new Size(104, 16);
            _lblInvoiceNumber.TabIndex = 10;
            _lblInvoiceNumber.Text = "Invoice Number";
            // 
            // lblUser
            // 
            _lblUser.BackColor = Color.White;
            _lblUser.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblUser.Location = new Point(416, 138);
            _lblUser.Name = "lblUser";
            _lblUser.Size = new Size(40, 16);
            _lblUser.TabIndex = 12;
            _lblUser.Text = "User";
            // 
            // cboUser
            // 
            _cboUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboUser.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _cboUser.ItemHeight = 13;
            _cboUser.Location = new Point(520, 136);
            _cboUser.Name = "cboUser";
            _cboUser.Size = new Size(549, 21);
            _cboUser.TabIndex = 13;
            // 
            // txtInvoiceNumber
            // 
            _txtInvoiceNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtInvoiceNumber.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtInvoiceNumber.Location = new Point(520, 112);
            _txtInvoiceNumber.Name = "txtInvoiceNumber";
            _txtInvoiceNumber.Size = new Size(549, 21);
            _txtInvoiceNumber.TabIndex = 11;
            // 
            // chkExportedOn
            // 
            _chkExportedOn.AutoCheck = false;
            _chkExportedOn.AutoSize = true;
            _chkExportedOn.Location = new Point(520, 166);
            _chkExportedOn.Name = "chkExportedOn";
            _chkExportedOn.Size = new Size(30, 17);
            _chkExportedOn.TabIndex = 46;
            _chkExportedOn.Text = " ";
            _chkExportedOn.UseVisualStyleBackColor = true;
            // 
            // grpInvoices
            // 
            _grpInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpInvoices.Controls.Add(_btnSalesCredit);
            _grpInvoices.Controls.Add(_btnChange);
            _grpInvoices.Controls.Add(_dgInvoices);
            _grpInvoices.Controls.Add(_btnSelectAll);
            _grpInvoices.Controls.Add(_btnDeselectAll);
            _grpInvoices.Controls.Add(_lblInvoicePartPayed);
            _grpInvoices.Controls.Add(_lblInvoicePayed);
            _grpInvoices.Controls.Add(_lblGreenColour);
            _grpInvoices.Controls.Add(_lblGoldColour);
            _grpInvoices.Controls.Add(_lblInvoicedNotPayed);
            _grpInvoices.Controls.Add(_lblRedColour);
            _grpInvoices.Location = new Point(8, 274);
            _grpInvoices.Name = "grpInvoices";
            _grpInvoices.Size = new Size(1123, 314);
            _grpInvoices.TabIndex = 23;
            _grpInvoices.TabStop = false;
            _grpInvoices.Text = "Double Click To View / Add Payment Information";
            // 
            // btnSalesCredit
            // 
            _btnSalesCredit.AccessibleDescription = "";
            _btnSalesCredit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSalesCredit.Location = new Point(827, 24);
            _btnSalesCredit.Name = "btnSalesCredit";
            _btnSalesCredit.Size = new Size(148, 23);
            _btnSalesCredit.TabIndex = 35;
            _btnSalesCredit.Text = "Sales Credit";
            // 
            // btnChange
            // 
            _btnChange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnChange.Location = new Point(981, 24);
            _btnChange.Name = "btnChange";
            _btnChange.Size = new Size(136, 23);
            _btnChange.TabIndex = 27;
            _btnChange.Text = "Change";
            // 
            // dgInvoices
            // 
            _dgInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgInvoices.DataMember = "";
            _dgInvoices.HeaderForeColor = SystemColors.ControlText;
            _dgInvoices.Location = new Point(8, 72);
            _dgInvoices.Name = "dgInvoices";
            _dgInvoices.Size = new Size(1109, 232);
            _dgInvoices.TabIndex = 14;
            // 
            // btnSelectAll
            // 
            _btnSelectAll.AccessibleDescription = "Export Job List To Excel";
            _btnSelectAll.Location = new Point(8, 24);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(88, 23);
            _btnSelectAll.TabIndex = 19;
            _btnSelectAll.Text = "Select All";
            // 
            // btnDeselectAll
            // 
            _btnDeselectAll.Location = new Point(104, 24);
            _btnDeselectAll.Name = "btnDeselectAll";
            _btnDeselectAll.Size = new Size(88, 23);
            _btnDeselectAll.TabIndex = 20;
            _btnDeselectAll.Text = "Deselect All";
            // 
            // lblInvoicePartPayed
            // 
            _lblInvoicePartPayed.Location = new Point(259, 52);
            _lblInvoicePartPayed.Name = "lblInvoicePartPayed";
            _lblInvoicePartPayed.Size = new Size(224, 23);
            _lblInvoicePartPayed.TabIndex = 26;
            _lblInvoicePartPayed.Text = "Invoiced - Some Payments Received";
            // 
            // lblInvoicePayed
            // 
            _lblInvoicePayed.Location = new Point(515, 52);
            _lblInvoicePayed.Name = "lblInvoicePayed";
            _lblInvoicePayed.Size = new Size(120, 23);
            _lblInvoicePayed.TabIndex = 25;
            _lblInvoicePayed.Text = "Invoiced and Paid";
            // 
            // lblGreenColour
            // 
            _lblGreenColour.BackColor = Color.LightGreen;
            _lblGreenColour.Location = new Point(491, 52);
            _lblGreenColour.Name = "lblGreenColour";
            _lblGreenColour.Size = new Size(23, 23);
            _lblGreenColour.TabIndex = 24;
            // 
            // lblGoldColour
            // 
            _lblGoldColour.BackColor = Color.Gold;
            _lblGoldColour.Location = new Point(235, 51);
            _lblGoldColour.Name = "lblGoldColour";
            _lblGoldColour.Size = new Size(23, 23);
            _lblGoldColour.TabIndex = 23;
            // 
            // lblInvoicedNotPayed
            // 
            _lblInvoicedNotPayed.Location = new Point(35, 52);
            _lblInvoicedNotPayed.Name = "lblInvoicedNotPayed";
            _lblInvoicedNotPayed.Size = new Size(200, 23);
            _lblInvoicedNotPayed.TabIndex = 22;
            _lblInvoicedNotPayed.Text = "Invoiced - No Payments Received";
            // 
            // lblRedColour
            // 
            _lblRedColour.BackColor = Color.Red;
            _lblRedColour.Location = new Point(11, 51);
            _lblRedColour.Name = "lblRedColour";
            _lblRedColour.Size = new Size(23, 23);
            _lblRedColour.TabIndex = 21;
            // 
            // btnView
            // 
            _btnView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnView.Location = new Point(561, 594);
            _btnView.Name = "btnView";
            _btnView.Size = new Size(59, 23);
            _btnView.TabIndex = 29;
            _btnView.Text = "View";
            // 
            // btnMarkAsNotExported
            // 
            _btnMarkAsNotExported.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnMarkAsNotExported.CausesValidation = false;
            _btnMarkAsNotExported.Location = new Point(813, 594);
            _btnMarkAsNotExported.Name = "btnMarkAsNotExported";
            _btnMarkAsNotExported.Size = new Size(146, 23);
            _btnMarkAsNotExported.TabIndex = 31;
            _btnMarkAsNotExported.Text = "Unmark Exports";
            _btnMarkAsNotExported.UseVisualStyleBackColor = true;
            // 
            // btnGenVal
            // 
            _btnGenVal.AccessibleDescription = "";
            _btnGenVal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnGenVal.Location = new Point(270, 594);
            _btnGenVal.Name = "btnGenVal";
            _btnGenVal.Size = new Size(125, 23);
            _btnGenVal.TabIndex = 32;
            _btnGenVal.Text = "Generate Val";
            // 
            // cmsValType
            // 
            _cmsValType.Items.AddRange(new ToolStripItem[] { _tsmiNCCVal, _tsmiGenericVal, _tsmiSorVal });
            _cmsValType.Name = "cmsValType";
            _cmsValType.Size = new Size(115, 70);
            // 
            // tsmiNCCVal
            // 
            _tsmiNCCVal.Name = "tsmiNCCVal";
            _tsmiNCCVal.Size = new Size(114, 22);
            _tsmiNCCVal.Text = "NCC";
            // 
            // tsmiGenericVal
            // 
            _tsmiGenericVal.Name = "tsmiGenericVal";
            _tsmiGenericVal.Size = new Size(114, 22);
            _tsmiGenericVal.Text = "Generic";
            // 
            // tsmiSorVal
            // 
            _tsmiSorVal.Name = "tsmiSorVal";
            _tsmiSorVal.Size = new Size(114, 22);
            _tsmiSorVal.Text = "SOR";
            // 
            // cmsChange
            // 
            _cmsChange.Items.AddRange(new ToolStripItem[] { _tsmiPaymentTerms, _tsmiInvoicedTotal, _tsmiVatRate, _tsmiAccountNumber, _tsmiOrderNo });
            _cmsChange.Name = "cmsChange";
            _cmsChange.Size = new Size(167, 114);
            // 
            // tsmiPaymentTerms
            // 
            _tsmiPaymentTerms.Name = "tsmiPaymentTerms";
            _tsmiPaymentTerms.Size = new Size(166, 22);
            _tsmiPaymentTerms.Text = "Payment Terms";
            // 
            // tsmiInvoicedTotal
            // 
            _tsmiInvoicedTotal.Name = "tsmiInvoicedTotal";
            _tsmiInvoicedTotal.Size = new Size(166, 22);
            _tsmiInvoicedTotal.Text = "Invoiced Total";
            // 
            // tsmiVatRate
            // 
            _tsmiVatRate.Name = "tsmiVatRate";
            _tsmiVatRate.Size = new Size(166, 22);
            _tsmiVatRate.Text = "Vat Rate";
            // 
            // tsmiAccountNumber
            // 
            _tsmiAccountNumber.Name = "tsmiAccountNumber";
            _tsmiAccountNumber.Size = new Size(166, 22);
            _tsmiAccountNumber.Text = "Account Number";
            // 
            // tsmiOrderNo
            // 
            _tsmiOrderNo.Name = "tsmiOrderNo";
            _tsmiOrderNo.Size = new Size(166, 22);
            _tsmiOrderNo.Text = "Order No";
            // 
            // cmsSalesCredit
            // 
            _cmsSalesCredit.Items.AddRange(new ToolStripItem[] { _tsmiIssue, _tsmiRemove, _tsmiBatchPrint });
            _cmsSalesCredit.Name = "ContextMenuStrip2";
            _cmsSalesCredit.Size = new Size(197, 70);
            // 
            // tsmiIssue
            // 
            _tsmiIssue.Name = "tsmiIssue";
            _tsmiIssue.Size = new Size(196, 22);
            _tsmiIssue.Text = "Issue Sales Credit";
            // 
            // tsmiRemove
            // 
            _tsmiRemove.Name = "tsmiRemove";
            _tsmiRemove.Size = new Size(196, 22);
            _tsmiRemove.Text = "Remove Sales Credit";
            // 
            // tsmiBatchPrint
            // 
            _tsmiBatchPrint.Name = "tsmiBatchPrint";
            _tsmiBatchPrint.Size = new Size(196, 22);
            _tsmiBatchPrint.Text = "Batch Print Sales Credit";
            // 
            // cmsExportForAccounts
            // 
            _cmsExportForAccounts.Items.AddRange(new ToolStripItem[] { _tsmiSunExport, _tsmiSageExport });
            _cmsExportForAccounts.Name = "cmsExportForAccounts";
            _cmsExportForAccounts.Size = new Size(152, 48);
            // 
            // tsmiSunExport
            // 
            _tsmiSunExport.Name = "tsmiSunExport";
            _tsmiSunExport.Size = new Size(151, 22);
            _tsmiSunExport.Text = "Export To Sun";
            // 
            // tsmiSageExport
            // 
            _tsmiSageExport.Name = "tsmiSageExport";
            _tsmiSageExport.Size = new Size(151, 22);
            _tsmiSageExport.Text = "Export To Sage";
            // 
            // btnExportToAccounts
            // 
            _btnExportToAccounts.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnExportToAccounts.Location = new Point(965, 594);
            _btnExportToAccounts.Name = "btnExportToAccounts";
            _btnExportToAccounts.Size = new Size(166, 23);
            _btnExportToAccounts.TabIndex = 35;
            _btnExportToAccounts.Text = "Export To Accounts";
            // 
            // FRMInvoicedManager
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1137, 626);
            Controls.Add(_btnExportToAccounts);
            Controls.Add(_btnGenVal);
            Controls.Add(_btnMarkAsNotExported);
            Controls.Add(_btnView);
            Controls.Add(_btnPrintOneItemOneInvoice);
            Controls.Add(_btnExport);
            Controls.Add(_grpFilter);
            Controls.Add(_btnReset);
            Controls.Add(_grpInvoices);
            Name = "FRMInvoicedManager";
            Text = "Invoiced Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpInvoices, 0);
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_btnPrintOneItemOneInvoice, 0);
            Controls.SetChildIndex(_btnView, 0);
            Controls.SetChildIndex(_btnMarkAsNotExported, 0);
            Controls.SetChildIndex(_btnGenVal, 0);
            Controls.SetChildIndex(_btnExportToAccounts, 0);
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            _grpInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgInvoices).EndInit();
            _cmsValType.ResumeLayout(false);
            _cmsChange.ResumeLayout(false);
            _cmsSalesCredit.ResumeLayout(false);
            _cmsExportForAccounts.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupInvoiceDataGrid();
            ResetFilters();
            try
            {
                if (get_GetParameter(0) is object)
                {
                    InvoicesDataview = (DataView)get_GetParameter(0);
                    ((IBaseForm)this).SetFormParameters = null;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _dvInvoices;

        private DataView InvoicesDataview
        {
            get
            {
                return _dvInvoices;
            }

            set
            {
                _dvInvoices = value;
                _dvInvoices.AllowNew = false;
                _dvInvoices.AllowEdit = true;
                _dvInvoices.AllowDelete = false;
                _dvInvoices.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
                dgInvoices.DataSource = InvoicesDataview;
            }
        }

        private DataRow SelectedInvoiceDataRow
        {
            get
            {
                if (!(dgInvoices.CurrentRowIndex == -1))
                {
                    return InvoicesDataview[dgInvoices.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Customers.Customer _theCustomer;

        public Entity.Customers.Customer theCustomer
        {
            get
            {
                return _theCustomer;
            }

            set
            {
                _theCustomer = value;
                theSite = null;
                if (_theCustomer is object)
                {
                    txtCustomer.Text = theCustomer.Name + " (A/C No : " + theCustomer.AccountNumber + ")";
                }
                else
                {
                    txtCustomer.Text = "";
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
                }
                else
                {
                    txtSite.Text = "";
                }
            }
        }

        private ArrayList _invoicesToPrint = new ArrayList();

        private ArrayList InvoicesToPrint
        {
            get
            {
                return _invoicesToPrint;
            }

            set
            {
                _invoicesToPrint = value;
            }
        }

        private bool _IsLoading = true;

        private bool IsLoading
        {
            get
            {
                return _IsLoading;
            }

            set
            {
                _IsLoading = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupInvoiceDataGrid()
        {
            Helper.SetUpDataGrid(dgInvoices);
            var tbStyle = dgInvoices.TableStyles[0];
            tbStyle.GridColumnStyles.Clear();
            // tbStyle.AllowSorting = False

            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tbStyle.GridColumnStyles.Add(Tick);
            var PaidStatus = new PaidStatusColourColumn();
            PaidStatus.Format = "";
            PaidStatus.FormatInfo = null;
            PaidStatus.HeaderText = "Paid";
            PaidStatus.MappingName = "PaidStatus";
            PaidStatus.ReadOnly = true;
            PaidStatus.Width = 30;
            PaidStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(PaidStatus);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 75;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 75;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var InvoiceType = new DataGridLabelColumn();
            InvoiceType.Format = "";
            InvoiceType.FormatInfo = null;
            InvoiceType.HeaderText = "Inv. Type";
            InvoiceType.MappingName = "InvoiceType";
            InvoiceType.ReadOnly = true;
            InvoiceType.Width = 75;
            InvoiceType.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceType);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job/Ord/Con No.";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 85;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var InvoiceAddressType = new DataGridLabelColumn();
            InvoiceAddressType.Format = "";
            InvoiceAddressType.FormatInfo = null;
            InvoiceAddressType.HeaderText = "Inv. Addr. Type";
            InvoiceAddressType.MappingName = "InvoiceAddressType";
            InvoiceAddressType.ReadOnly = true;
            InvoiceAddressType.Width = 75;
            InvoiceAddressType.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceAddressType);
            var InvoiceAddress = new DataGridLabelColumn();
            InvoiceAddress.Format = "";
            InvoiceAddress.FormatInfo = null;
            InvoiceAddress.HeaderText = "Invoice Add.";
            InvoiceAddress.MappingName = "InvoiceAddress";
            InvoiceAddress.ReadOnly = true;
            InvoiceAddress.Width = 75;
            InvoiceAddress.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceAddress);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "C";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 75;
            Amount.NullText = "";
            tbStyle.GridColumnStyles.Add(Amount);
            var VATRate = new DataGridLabelColumn();
            VATRate.Format = "";
            VATRate.FormatInfo = null;
            VATRate.HeaderText = "VAT Rate";
            VATRate.MappingName = "VATRate";
            VATRate.ReadOnly = true;
            VATRate.Width = 75;
            VATRate.NullText = "";
            tbStyle.GridColumnStyles.Add(VATRate);
            var InvoiceNumber = new DataGridLabelColumn();
            InvoiceNumber.Format = "C";
            InvoiceNumber.FormatInfo = null;
            InvoiceNumber.HeaderText = "Invoice No";
            InvoiceNumber.MappingName = "InvoiceNumber";
            InvoiceNumber.ReadOnly = true;
            InvoiceNumber.Width = 75;
            InvoiceNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceNumber);
            var RaisedOn = new DataGridLabelColumn();
            RaisedOn.Format = "dd/MM/yyyy";
            RaisedOn.FormatInfo = null;
            RaisedOn.HeaderText = "Raised On";
            RaisedOn.MappingName = "RaisedDate";
            RaisedOn.ReadOnly = true;
            RaisedOn.Width = 75;
            RaisedOn.NullText = "";
            tbStyle.GridColumnStyles.Add(RaisedOn);
            var RaisedBy = new DataGridLabelColumn();
            RaisedBy.Format = "";
            RaisedBy.FormatInfo = null;
            RaisedBy.HeaderText = "Raised By";
            RaisedBy.MappingName = "Fullname";
            RaisedBy.ReadOnly = true;
            RaisedBy.Width = 75;
            RaisedBy.NullText = "";
            tbStyle.GridColumnStyles.Add(RaisedBy);
            var DateExportedToSage = new DataGridLabelColumn();
            DateExportedToSage.Format = "dd/MM/yyyy";
            DateExportedToSage.FormatInfo = null;
            DateExportedToSage.HeaderText = "Exported";
            DateExportedToSage.MappingName = "DateExportedToSage";
            DateExportedToSage.ReadOnly = true;
            DateExportedToSage.Width = 105;
            DateExportedToSage.NullText = "";
            tbStyle.GridColumnStyles.Add(DateExportedToSage);
            var SupplierInvoiceID = new DataGridLabelColumn();
            SupplierInvoiceID.Format = "";
            SupplierInvoiceID.FormatInfo = null;
            SupplierInvoiceID.HeaderText = "Supplier Invoice ID";
            SupplierInvoiceID.MappingName = "SupplierInvoiceID";
            SupplierInvoiceID.ReadOnly = true;
            SupplierInvoiceID.Width = 105;
            SupplierInvoiceID.NullText = "";
            tbStyle.GridColumnStyles.Add(SupplierInvoiceID);
            var CreditAmount = new DataGridLabelColumn();
            CreditAmount.Format = "C";
            CreditAmount.FormatInfo = null;
            CreditAmount.HeaderText = "Credited Amount";
            CreditAmount.MappingName = "CreditAmount";
            CreditAmount.ReadOnly = true;
            CreditAmount.Width = 80;
            CreditAmount.NullText = "";
            tbStyle.GridColumnStyles.Add(CreditAmount);
            var PaymentTerm = new DataGridLabelColumn();
            PaymentTerm.Format = "";
            PaymentTerm.FormatInfo = null;
            PaymentTerm.HeaderText = "Payment Term";
            PaymentTerm.MappingName = "PaymentTerm";
            PaymentTerm.ReadOnly = true;
            PaymentTerm.Width = 120;
            PaymentTerm.NullText = "";
            tbStyle.GridColumnStyles.Add(PaymentTerm);
            var PaymentBy = new DataGridLabelColumn();
            PaymentBy.Format = "";
            PaymentBy.FormatInfo = null;
            PaymentBy.HeaderText = "Payment by";
            PaymentBy.MappingName = "PaymentBy";
            PaymentBy.ReadOnly = true;
            PaymentBy.Width = 100;
            PaymentBy.NullText = "";
            tbStyle.GridColumnStyles.Add(PaymentBy);
            var AccountNumber = new DataGridLabelColumn();
            AccountNumber.Format = "";
            AccountNumber.FormatInfo = null;
            AccountNumber.HeaderText = "Acc Number";
            AccountNumber.MappingName = "AccountNumber";
            AccountNumber.ReadOnly = true;
            AccountNumber.Width = 100;
            AccountNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(AccountNumber);
            var orderNo = new DataGridEditableTextBoxColumn();
            orderNo.Format = "";
            orderNo.FormatInfo = null;
            orderNo.HeaderText = "Order No";
            orderNo.MappingName = "OrderNo";
            orderNo.ReadOnly = false;
            orderNo.Width = 100;
            orderNo.NullText = "";
            tbStyle.GridColumnStyles.Add(orderNo);
            tbStyle.ReadOnly = false;
            dgInvoices.ReadOnly = false;
            tbStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
            dgInvoices.TableStyles.Add(tbStyle);
        }

        private void FRMInvoicedManager_Load(object sender, EventArgs e)
        {
            IsLoading = true;
            LoadMe(sender, e);
            IsLoading = false;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            view();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                theCustomer = App.DB.Customer.Customer_Get(ID);
            }
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            int ID;
            if (theCustomer is null)
            {
                ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite));
            }
            else
            {
                ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, theCustomer.CustomerID));
            }

            if (!(ID == 0))
            {
                theSite = App.DB.Sites.Get(ID);
            }
        }

        private void dgInvoices_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgInvoices.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                if (HitTestInfo.Column == 0)
                {
                    bool selected = !Helper.MakeBooleanValid(SelectedInvoiceDataRow["tick"]);
                    SelectedInvoiceDataRow["Tick"] = selected;
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int itm = 0, loopTo = ((DataView)dgInvoices.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgInvoices.CurrentRowIndex = itm;
                SelectedInvoiceDataRow["tick"] = 1;
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int itm = 0, loopTo = ((DataView)dgInvoices.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgInvoices.CurrentRowIndex = itm;
                SelectedInvoiceDataRow["tick"] = 0;
            }
        }

        private void btnPrintOneItemOneInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Check_Supplier_Invoices_And_Continue())
                {
                    return;
                }

                FindPartPayJobs(false);
                var drTicked = (from sf in InvoicesDataview.Table.AsEnumerable()
                                where sf.Field<bool>("Tick") == true
                                select sf).ToArray();
                foreach (DataRow i in drTicked)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(i["InvoiceType"], "Sales Credit", false)))  // its a credit
                    {
                        int amountOfCreditsForInvoice = (from sf in InvoicesDataview.Table.AsEnumerable()
                                                         where (sf.Field<string>("InvoiceType") ?? "") == "Sales Credit" & Operators.ConditionalCompareObjectEqual(sf.Field<string>("InvoiceNumber"), i["InvoiceNumber"], false)
                                                         select sf).Count();
                        DataTable credit = null;
                        DialogResult result = default;
                        if (amountOfCreditsForInvoice > 1)
                        {
                            string message = Conversions.ToString("Invoice No: " + i["InvoiceNumber"] + " has more than one credit." + Constants.vbCrLf + Constants.vbCrLf + "Do you want merge them together?");
                            result = App.ShowMessage(message, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }

                        if (result != default && result == DialogResult.Yes)
                        {
                            credit = App.DB.SalesCredit.InvoicedLines_GetAll_ByInvoicedNumber(Conversions.ToString(i["InvoiceNumber"])).Table;
                        }
                        else
                        {
                            credit = App.DB.SalesCredit.InvoicedLines_GetAll_ByCreditReference(Conversions.ToString(i["JobNumber"])).Table;
                        }

                        credit.Columns.Add("SalesCreditID");
                        credit.Rows[0]["SalesCreditID"] = i["LinkID"];
                        credit.Columns.Add("CreditReference");
                        credit.Rows[0]["CreditReference"] = i["JobNumber"];
                        var oPrint = new Printing(credit, "Sales Credit", Enums.SystemDocumentType.SalesCredit);
                    }
                    else if (Helper.MakeIntegerValid(i["invoicedID"]) == 0)  // normal
                    {
                        var inv = new Entity.Invoiceds.Invoiced();
                        // AMY IS CHEATING AND USING JOB NUMBER - 5 isn't a job definition!
                        var invNum = new JobNumber();
                        invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                        inv.SetInvoiceNumber = invNum.Prefix + invNum.JobNumber;
                        inv.SetRaisedByUserID = App.loggedInUser.UserID;
                        inv.RaisedDate = DateAndTime.Now;
                        inv = App.DB.Invoiced.Insert(inv);
                        var invLines = new Entity.InvoicedLiness.InvoicedLines();
                        invLines.SetAmount = Helper.MakeDoubleValid(i["Amount"]);
                        invLines.SetInvoicedID = inv.InvoicedID;
                        invLines.SetInvoiceToBeRaisedID = i["InvoiceToBeRaisedID"];
                        invLines = App.DB.InvoicedLines.Insert(invLines);
                        var PrintArray = new ArrayList();
                        PrintArray.Add(i["InvoicedID"]);
                        PrintArray.Add(i["RegionID"]);
                        InvoicesToPrint.Add(PrintArray);
                    }
                    else
                    {
                        bool exists = false;
                        foreach (ArrayList al in InvoicesToPrint)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(al[0], i["InvoicedID"], false))) // check if the invoice id is already in....
                            {
                                exists = true;
                            }
                        }

                        if (exists == false) // if not add it.
                        {
                            var PrintArray = new ArrayList();
                            PrintArray.Add(i["InvoicedID"]);
                            PrintArray.Add(i["RegionID"]);
                            InvoicesToPrint.Add(PrintArray);
                        }
                    }
                }

                Print();
                PopulateDatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrintManyItemsOnOneInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Check_Supplier_Invoices_And_Continue())
                {
                    return;
                }

                FindPartPayJobs(true);
                var dtDone = new DataTable();
                dtDone.Columns.Add("AddressTypeID");
                dtDone.Columns.Add("AddressID");
                foreach (DataRow i in InvoicesDataview.Table.Rows)
                {
                    if (Helper.MakeBooleanValid(i["tick"]) == true)
                    {
                        if (Helper.MakeIntegerValid(i["invoicedID"]) == 0)
                        {
                            if (dtDone.Select(Conversions.ToString(Conversions.ToString("AddressTypeID=" + i["AddressTypeID"] + " AND AddressID=") + i["AddressID"])).Length == 0)
                            {
                                var drInv = InvoicesDataview.Table.Select(Conversions.ToString(Conversions.ToString("AddressTypeID=" + i["AddressTypeID"] + " AND AddressID=") + i["AddressID"] + " AND Tick = 1"));
                                var inv = new Entity.Invoiceds.Invoiced();
                                var invNum = new JobNumber();
                                invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                                inv.SetInvoiceNumber = invNum.Prefix + invNum.JobNumber;
                                inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                inv.RaisedDate = DateAndTime.Now;
                                inv = App.DB.Invoiced.Insert(inv);
                                for (int j = 0, loopTo = drInv.Length - 1; j <= loopTo; j++)
                                {
                                    var invLines = new Entity.InvoicedLiness.InvoicedLines();
                                    invLines.SetAmount = Helper.MakeDoubleValid(drInv[j]["Amount"]);
                                    invLines.SetInvoicedID = inv.InvoicedID;
                                    invLines.SetInvoiceToBeRaisedID = drInv[j]["InvoiceToBeRaisedID"];
                                    invLines = App.DB.InvoicedLines.Insert(invLines);
                                }

                                InvoicesToPrint.Add(inv.InvoicedID);
                                DataRow r;
                                r = dtDone.NewRow();
                                r["AddressTypeID"] = i["AddressTypeID"];
                                r["AddressID"] = i["AddressID"];
                                dtDone.Rows.Add(r);
                            }
                        }
                        else if (!InvoicesToPrint.Contains(i["invoicedID"]))
                        {
                            InvoicesToPrint.Add(Helper.MakeIntegerValid(i["invoicedID"]));
                        }
                    }
                }

                Print();
                PopulateDatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgInvoices_DoubleClick(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedInvoiceDataRow is object)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedInvoiceDataRow["InvoiceType"], "Supplier", false) | Operators.ConditionalCompareObjectEqual(SelectedInvoiceDataRow["InvoiceType"], "Consolidation", false)))
                {
                    App.ShowMessage("Payments cannot be managed for a supplier invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!(Helper.MakeIntegerValid(SelectedInvoiceDataRow["InvoicedID"]) == 0))
                {
                    {
                        var withBlock = SelectedInvoiceDataRow;
                        App.ShowForm(typeof(FrmInvoicedPayment), true, new object[] { withBlock["InvoicedID"], withBlock["Customer"], withBlock["InvoiceAddress"], withBlock["InvoiceNumber"], withBlock["RaisedDate"], withBlock["Fullname"], withBlock["EngineerVisitID"], withBlock["VATRate"], this });
                    }
                }
                else
                {
                    App.ShowMessage("An Invoice must be generated before payments can be applied for or received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (SelectedInvoiceDataRow is object)
            {
                foreach (DataRow r in InvoicesDataview.Table.Rows)
                {
                    if (Conversions.ToBoolean(r["tick"]))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Sales Credit", false))) // It was possible to use the change button and it would somehow change the original invoice of the credit so i stopped this.
                        {
                            App.ShowMessage("You can not change credits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
            }

            cmsChange.Show(btnChange, new Point(0, 0));
        }

        private void tsmiPaymentTerms_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedInvoiceDataRow is object)
            {
                // POP UP FORM
                FRMChangePaymentTerms fCIT = (FRMChangePaymentTerms)App.ShowForm(typeof(FRMChangePaymentTerms), true, new object[] { SelectedInvoiceDataRow["InvoicedID"], SelectedInvoiceDataRow["Amount"] });
                if (fCIT.DialogResult == DialogResult.OK)
                {
                    SelectedInvoiceDataRow["PaymentTerm"] = Combo.get_GetSelectedItemDescription(fCIT.cboPaymentTerm);
                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(fCIT.cboPaymentTerm)) == 69491)
                    {
                        SelectedInvoiceDataRow["PaymentBy"] = Combo.get_GetSelectedItemDescription(fCIT.cboPaidBy);
                    }
                    else
                    {
                        SelectedInvoiceDataRow["PaymentBy"] = "";
                    }
                }
            }
        }

        private void tsmiInvoicedTotal_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedInvoiceDataRow is object)
            {
                // POP UP FORM
                if (Conversions.ToBoolean(SelectedInvoiceDataRow["ExportedToSage"]) == false)
                {
                    FRMChangeInvoicedTotal fCIT = (FRMChangeInvoicedTotal)App.ShowForm(typeof(FRMChangeInvoicedTotal), true, new object[] { SelectedInvoiceDataRow["InvoicedLineID"], SelectedInvoiceDataRow["Amount"], SelectedInvoiceDataRow["AccountNumber"], SelectedInvoiceDataRow["Department"], SelectedInvoiceDataRow["NominalCode"], SelectedInvoiceDataRow["RaisedDate"], SelectedInvoiceDataRow["InvoiceTypeID"] });
                    if (fCIT.DialogResult == DialogResult.OK)
                    {
                        SelectedInvoiceDataRow["Amount"] = fCIT.txtInvoicedTotal.Text;
                        SelectedInvoiceDataRow["AccountNumber"] = fCIT.txtAccount.Text;
                        SelectedInvoiceDataRow["Department"] = fCIT.txtDept.Text;
                        SelectedInvoiceDataRow["NominalCode"] = fCIT.txtNominal.Text;
                        SelectedInvoiceDataRow["RaisedDate"] = fCIT.dtpTaxDate.Value;
                    }
                }
                else
                {
                    App.ShowMessage("This invoice has already been exported", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiVatRate_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedInvoiceDataRow is null)
            {
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedInvoiceDataRow["InvoiceType"], "Supplier", false) | Operators.ConditionalCompareObjectEqual(SelectedInvoiceDataRow["InvoiceType"], "Consolidation", false)))
            {
                App.ShowMessage("VAT Rate cannot be changed for a supplier invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new FRMChangeVAT(Conversions.ToInteger(SelectedInvoiceDataRow["VATRateID"]), Conversions.ToInteger(SelectedInvoiceDataRow["InvoicedID"]), Conversions.ToString(SelectedInvoiceDataRow["InvoiceNumber"])))
            {
                f.ShowDialog();
            }

            PopulateDatagrid();
        }

        private void btnSalesCredit_Click(object sender, EventArgs e)
        {
            cmsSalesCredit.Show(btnSalesCredit, new Point(0, 0));
        }

        private void tsmiAccountNumber_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedInvoiceDataRow is null)
                return;
            var f = new FRMGenDropBox();
            f.cbo2.Items.Clear();
            f.cbo1.Visible = false;
            f.cbo2.Visible = false;
            f.lblTop.Visible = false;
            f.lblMiddle.Visible = false;
            f.lblref.Text = "Account Number";
            f.txtref.Visible = true;
            f.ShowDialog();
            f.btnOK.Text = "Save";
            if (f.DialogResult == DialogResult.Cancel)
            {
                return;
            }

            var EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(Conversions.ToInteger(SelectedInvoiceDataRow["EngineerVisitID"]));
            EngVisitCharge.SetForSageAccountCode = f.txtref.Text.Trim();
            App.DB.EngineerVisitCharge.EngineerVisitCharge_Update(EngVisitCharge);
            SelectedInvoiceDataRow["AccountNumber"] = f.txtref.Text.Trim();
        }

        private void tsmiIssue_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (InvoicesDataview is object)
            {
                var r = InvoicesDataview.Table.Select("tick = 1");
                int customerID = 0;
                foreach (DataRow i in r)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r[0]["InvoiceType"], "Sales Credit", false)))
                    {
                        App.ShowMessage("Credits cannot be raised on credit records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (Helper.MakeDoubleValid(i["CreditAmount"]) >= Helper.MakeDoubleValid(i["Amount"]))
                    {
                        App.ShowMessage("Credit Amount cannot be greater than Invoice Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (Conversions.ToBoolean(customerID == 0 | Operators.ConditionalCompareObjectEqual(customerID, i["CustomerID"], false)))
                    {
                        customerID = Conversions.ToInteger(i["customerID"]);
                    }
                    else
                    {
                        App.ShowMessage("Grouped credits must be against one customer only", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (r.Length > 0)
                {
                    using (var f = new FRMSalesCredit(r, false, true))
                    {
                        f.ShowDialog();
                    }

                    PopulateDatagrid();
                }
            }
        }

        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            int @ref = 0;
            if (SelectedInvoiceDataRow is object)
            {
                foreach (DataRow r in InvoicesDataview.Table.Rows)
                {
                    if (Conversions.ToBoolean(r["tick"]))
                    {
                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Sales Credit", false)))
                        {
                            App.ShowMessage("You Can only delete credits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        if (@ref == 0 | @ref == Helper.MakeIntegerValid(r["LinkID"]))
                        {
                            @ref = Helper.MakeIntegerValid(r["LinkID"]);
                        }
                        else
                        {
                            App.ShowMessage("You Can not delete more than one group of credits at once", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        if (@ref != 0)
                        {
                            App.DB.ClearParameter(); // cause we are doing this in the wrong place
                            var dt = App.DB.ExecuteWithReturn("Select CreditReference , DateExportedToSage, InvoicedLineID from tblSalesCredit where SalesCreditID = " + @ref);
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (Information.IsDBNull(dr["DateExportedToSage"]) == false)
                                {
                                    App.ShowMessage("One or more Credits have already been exported, cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }

                            foreach (DataRow dr2 in dt.Rows)
                                App.DB.ExecuteScalar(Conversions.ToString("Delete tblInvoicedLinesCredit where invoicedLineID = " + dr2["InvoicedLineID"]));
                            App.DB.ExecuteScalar("Delete tblSalesCredit Where SalesCreditID = " + @ref);
                            @ref = 0;
                        }
                    }
                }

                PopulateDatagrid();
            }
        }

        private void tsmiBatchPrint_Click(object sender, EventArgs e)
        {
            if (InvoicesDataview is object)
            {
                var dr = (from sf in InvoicesDataview.Table.AsEnumerable()
                          where sf.Field<bool>("Tick") == true & (sf.Field<string>("InvoiceType") ?? "") == "Sales Credit"
                          select sf).ToArray();
                if (dr.Count() < 1)
                {
                    App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dtCredit = new DataTable();
                dtCredit = dr.CopyToDataTable();
                var oPrint = new Printing(dtCredit, "Sales Credit", Enums.SystemDocumentType.SalesCredit, true);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateDatagrid();
        }

        private void btnGenNCCVal_Click(object sender, EventArgs e)
        {
            cmsValType.Show(btnGenVal, new Point(0, 0));
        }

        private void tsmiNCCVal_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var invoicedIds = (from x in InvoicesDataview.Table.AsEnumerable()
                                   where x.Field<bool>("Tick") == true
                                   select x.Field<int>("InvoicedID")).Distinct().ToList();
                if (invoicedIds.Count == 0)
                {
                    App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var exportData = new DataTable();
                exportData.Columns.Add("ValNo");
                exportData.Columns.Add("UPRN");
                exportData.Columns.Add("JOB");
                exportData.Columns.Add("ActualCompDate", typeof(DateTime));
                exportData.Columns.Add("Invoice");
                exportData.Columns.Add("Address");
                exportData.Columns.Add("Code");
                exportData.Columns.Add("SORDescription");
                exportData.Columns.Add("Plant");
                exportData.Columns.Add("Materials", typeof(double));
                exportData.Columns.Add("SubContractor", typeof(double));
                exportData.Columns.Add("Labour", typeof(double));
                exportData.Columns.Add("SORCost", typeof(double));
                exportData.Columns.Add("MarginOnMaterials", typeof(double));
                exportData.Columns.Add("MarginOnSubCon", typeof(double));
                exportData.Columns.Add("Total", typeof(double));
                exportData.Columns.Add("VAT", typeof(double));
                exportData.Columns.Add("GrandTotal", typeof(double));
                exportData.Columns.Add("Recharge");
                exportData.Columns.Add("HPSOfficer");
                foreach (int invoicedId in invoicedIds)
                {
                    var visits = App.DB.Invoiced.NCCValuation(invoicedId);
                    foreach (DataRow dr in visits.Table.Rows)
                    {
                        DataRow newRw;
                        newRw = exportData.NewRow();
                        newRw["ValNo"] = dr["ValNum"];
                        newRw["UPRN"] = dr["UPRN"];
                        newRw["JOB"] = dr["JOB"];
                        newRw["ActualCompDate"] = dr["ActualCompletion"];
                        newRw["Invoice"] = dr["InvoiceNumber"];
                        newRw["Address"] = dr["Address1"];
                        newRw["Code"] = dr["CODE"];
                        newRw["SORDescription"] = dr["Description"];
                        newRw["Plant"] = dr["Plant"];
                        newRw["Materials"] = dr["Material"];
                        newRw["SubContractor"] = dr["SubContractor"];
                        newRw["Labour"] = dr["labour"];
                        newRw["SORCost"] = dr["SORCost"];
                        newRw["MarginOnMaterials"] = dr["MatMark"];
                        newRw["MarginOnSubCon"] = dr["SubConMark"];
                        newRw["Total"] = dr["Total"];
                        newRw["VAT"] = dr["VAT"];
                        newRw["GrandTotal"] = dr["GrandTotal"];
                        newRw["Recharge"] = dr["Recharge"];
                        newRw["HPSOfficer"] = dr["HpsOfficer"];
                        exportData.Rows.Add(newRw);
                    }
                }

                ExportHelper.Export(exportData, "NCC Valuation", Enums.ExportType.XLS);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error generating document!" + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void tsmiSorVal_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (InvoicesDataview is object)
                {
                    var drInvoices = (from sf in InvoicesDataview.Table.AsEnumerable()
                                      where sf.Field<bool>("Tick") == true
                                      select sf).ToArray();
                    if (drInvoices.Count() < 1)
                    {
                        App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var dtValData = new DataTable();
                    dtValData.Columns.Add("UPRN", typeof(string));
                    dtValData.Columns.Add("Client Ref", typeof(string));
                    dtValData.Columns.Add("Gasway Job Number", typeof(string));
                    dtValData.Columns.Add("Completion Date", typeof(DateTime));
                    dtValData.Columns.Add("Invoice Number", typeof(string));
                    dtValData.Columns.Add("Address", typeof(string));
                    dtValData.Columns.Add("Invoice Description", typeof(string));
                    dtValData.Columns.Add("SOR Code", typeof(string));
                    dtValData.Columns.Add("SOR Description", typeof(string));
                    dtValData.Columns.Add("SOR Price", typeof(string));
                    dtValData.Columns.Add("SOR Qty", typeof(int));
                    dtValData.Columns.Add("SOR Total", typeof(string));
                    try
                    {
                        foreach (DataRow drInvoice in drInvoices)
                        {
                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(drInvoice["InvoiceType"], "Visit", false)))
                                continue;
                            if (drInvoice["AccountNumber"].ToString().Contains("IBC"))
                                continue;
                            int engineerVisitId = Helper.MakeIntegerValid(drInvoice["EngineerVisitID"]);
                            var dvEngVisit = App.DB.EngineerVisits.EngineerVisits_Get_ForVal(engineerVisitId);
                            if (dvEngVisit.Count < 1)
                                continue;
                            var dvSorBreakdown = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get_SorBreakdownForVal(engineerVisitId);
                            foreach (DataRowView drSor in dvSorBreakdown)
                            {
                                DataRow newRw;
                                newRw = dtValData.NewRow();
                                newRw["UPRN"] = Helper.MakeStringValid(dvEngVisit[0]["UPRN"]);
                                newRw["Address"] = Helper.MakeStringValid(dvEngVisit[0]["Site"]);
                                newRw["Gasway Job Number"] = Helper.MakeStringValid(dvEngVisit[0]["JobNumber"]);
                                newRw["Completion Date"] = Helper.MakeDateTimeValid(dvEngVisit[0]["CompletedDateTime"]);
                                newRw["Client Ref"] = Helper.MakeStringValid(dvEngVisit[0]["ClientRef"]);
                                newRw["Invoice Number"] = Helper.MakeStringValid(drInvoice["InvoiceNumber"]);
                                newRw["Invoice Description"] = Helper.MakeStringValid(dvEngVisit[0]["InvoiceNotes"]);
                                newRw["SOR Code"] = drSor["Code"];
                                newRw["SOR Description"] = drSor["Description"];
                                newRw["SOR Price"] = Helper.MakeDoubleValid(drSor["Cost"]).ToString("c");
                                newRw["SOR Qty"] = Helper.MakeIntegerValid(drSor["Quantity"]);
                                newRw["SOR Total"] = Helper.MakeDoubleValid(drSor["Charge"]).ToString("c");
                                dtValData.Rows.Add(newRw);
                            }
                        }

                        ExportHelper.Export(dtValData, "Valuation", Enums.ExportType.XLS);
                    }
                    catch (Exception ex)
                    {
                        App.ShowMessage("Error generating document!" + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error generating document!" + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void tsmiGenericVal_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (InvoicesDataview is object)
                {
                    var dr = (from sf in InvoicesDataview.Table.AsEnumerable()
                              where sf.Field<bool>("Tick") == true
                              select sf).ToArray();
                    if (dr.Count() < 1)
                    {
                        App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var exportData = new DataTable();
                    exportData.Columns.Add("UPRN", typeof(string));
                    exportData.Columns.Add("Client Ref", typeof(string));
                    exportData.Columns.Add("Gasway Job Number", typeof(string));
                    exportData.Columns.Add("Completion Date", typeof(DateTime));
                    exportData.Columns.Add("Invoice Number", typeof(string));
                    exportData.Columns.Add("Address", typeof(string));
                    exportData.Columns.Add("Invoice Description", typeof(string));
                    exportData.Columns.Add("SOR Description", typeof(string));
                    exportData.Columns.Add("SOR Cost", typeof(decimal));
                    exportData.Columns.Add("Labour Cost", typeof(decimal));
                    exportData.Columns.Add("Parts Cost", typeof(decimal));
                    exportData.Columns.Add("Additional Cost", typeof(decimal));
                    exportData.Columns.Add("Total ex VAT", typeof(double));
                    exportData.Columns.Add("VAT", typeof(double));
                    exportData.Columns.Add("Total", typeof(double));
                    try
                    {
                        foreach (DataRow r in dr)
                        {
                            // if anything other than visit then we cannot add to val
                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Visit", false)))
                                continue;
                            if (r["AccountNumber"].ToString().Contains("IBC"))
                                continue;
                            int engVisitId = Helper.MakeIntegerValid(r["EngineerVisitID"]);

                            // get visit info
                            var dvEngVisit = App.DB.EngineerVisits.EngineerVisits_Get_ForVal(engVisitId);
                            if (dvEngVisit.Count < 1)
                                continue;

                            // get visitcharge info
                            var dvChargeBreakdown = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get_ChargedBreakDown(engVisitId);

                            // get totals for different areas
                            decimal PARTSTotal = dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "PARTS").Sum(row => row.Field<decimal>("Charge"));
                            decimal SORTotal = dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "SOR").Sum(row => row.Field<decimal>("Charge"));
                            decimal LABOURTotal = dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "LABOUR").Sum(row => row.Field<decimal>("Charge"));
                            decimal ADDITIONALTotal = dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "ADDITIONAL").Sum(row => row.Field<decimal>("Charge"));

                            // get sor descriptions
                            string sorDescription = string.Join(" / ", dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "SOR").Select(row => row.Field<string>("Description")).ToArray());

                            // calculate amounts
                            double amount = Helper.MakeDoubleValid(r["Amount"]);
                            double vatRate = Helper.MakeDoubleValid(r["VATRate"]) / 100;
                            double vatAmount = amount * vatRate;
                            double total = amount + Math.Round(vatAmount, 2, MidpointRounding.ToEven);

                            // insert the info
                            DataRow newRw;
                            newRw = exportData.NewRow();
                            newRw["UPRN"] = Helper.MakeStringValid(dvEngVisit[0]["UPRN"]);
                            newRw["Address"] = Helper.MakeStringValid(dvEngVisit[0]["Site"]);
                            newRw["Gasway Job Number"] = Helper.MakeStringValid(dvEngVisit[0]["JobNumber"]);
                            newRw["Completion Date"] = Helper.MakeDateTimeValid(dvEngVisit[0]["CompletedDateTime"]);
                            newRw["Client Ref"] = Helper.MakeStringValid(dvEngVisit[0]["ClientRef"]);
                            newRw["Invoice Number"] = Helper.MakeStringValid(r["InvoiceNumber"]);
                            newRw["Invoice Description"] = Helper.MakeStringValid(dvEngVisit[0]["InvoiceNotes"]);
                            newRw["SOR Description"] = sorDescription;
                            newRw["SOR Cost"] = SORTotal;
                            newRw["Labour Cost"] = LABOURTotal;
                            newRw["Parts Cost"] = PARTSTotal;
                            newRw["Additional Cost"] = ADDITIONALTotal;
                            newRw["Total ex VAT"] = amount;
                            newRw["VAT"] = Math.Round(vatAmount, 2, MidpointRounding.ToEven);
                            newRw["Total"] = Math.Round(total, 2, MidpointRounding.ToEven);
                            exportData.Rows.Add(newRw);
                        }

                        ExportHelper.Export(exportData, "Valuation", Enums.ExportType.XLS);
                    }
                    catch (Exception ex)
                    {
                        App.ShowMessage("Error generating document!" + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error generating document!" + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void txtJobNumber_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulateDatagrid();
            }
        }

        private void txtSageMonth_TextChanged(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            FRMChangeSageDate fCIT = (FRMChangeSageDate)App.ShowForm(typeof(FRMChangeSageDate), true, null);
            if (fCIT.DialogResult == DialogResult.OK)
            {
                txtSageMonth.Text = Conversions.ToDate(App.DB.ExecuteScalar("Select Name from tblpicklists where enumtypeid = 69")).ToString("MMMM yyyy");
            }
        }

        private void tsmiOrderNo_Click(object sender, EventArgs e)
        {
            // get the difference
            if (MessageBox.Show("Are you sure you want to update the order numbers?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }

            try
            {
                var diff = InvoicesDataview.Table.GetChanges();
                var visitInvoices = diff.Select("InvoiceTypeID = " + Conversions.ToInteger(Enums.InvoiceType.Visit));
                foreach (DataRow visitInvoice in visitInvoices)
                {
                    int jobOfWorkId = visitInvoice.Table.Columns.Contains("JobOfWorkID") ? Helper.MakeIntegerValid(visitInvoice["JobOfWorkID"]) : 0;
                    string ponumber = Helper.MakeStringValid(visitInvoice["OrderNo"]);
                    if (jobOfWorkId > 0)
                    {
                        App.DB.JobOfWorks.Update_PONumberByJobOfWorkID(jobOfWorkId, ponumber);
                    }
                }

                App.ShowMessage("Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Unable to save: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void view()
        {
            if (SelectedInvoiceDataRow is object)
            {
                var switchExpr = (Enums.InvoiceType)Conversions.ToInteger(SelectedInvoiceDataRow["InvoiceTypeID"]);
                switch (switchExpr)
                {
                    case Enums.InvoiceType.Contract_Option1:
                        {
                            App.ShowForm(typeof(FRMContractOriginal), true, new object[] { Helper.MakeIntegerValid(SelectedInvoiceDataRow["ContractID"]), Helper.MakeIntegerValid(SelectedInvoiceDataRow["CustomerID"]) });
                            break;
                        }

                    case Enums.InvoiceType.Order:
                        {
                            var switchExpr1 = Conversions.ToInteger(SelectedInvoiceDataRow["OrderTypeID"]);
                            switch (switchExpr1)
                            {
                                case (int)Enums.OrderType.Customer:
                                    {
                                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedInvoiceDataRow["OrderID"], Helper.MakeIntegerValid(SelectedInvoiceDataRow["OrderSiteID"]), 0, this });
                                        break;
                                    }

                                case (int)Enums.OrderType.StockProfile:
                                    {
                                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedInvoiceDataRow["OrderID"], SelectedInvoiceDataRow["VanID"], 0, this });
                                        break;
                                    }

                                case (int)Enums.OrderType.Warehouse:
                                    {
                                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedInvoiceDataRow["OrderID"], SelectedInvoiceDataRow["WarehouseID"], 0, this });
                                        break;
                                    }

                                case (int)Enums.OrderType.Job:
                                    {
                                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedInvoiceDataRow["OrderID"], SelectedInvoiceDataRow["EngineerVisitID"], 0, this });
                                        break;
                                    }

                                default:
                                    {
                                        // OrderID holds the consolidated order id
                                        App.ShowForm(typeof(FRMConsolidation), true, new object[] { SelectedInvoiceDataRow["OrderID"] });
                                        break;
                                    }
                            }

                            break;
                        }

                    case Enums.InvoiceType.Visit:
                        {
                            App.ShowForm(typeof(FRMEngineerVisit), true, new object[] { Helper.MakeIntegerValid(SelectedInvoiceDataRow["EngineerVisitID"]) });
                            break;
                        }
                }
            }
            else
            {
                App.ShowMessage("Please select an invoice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PopulateDatagrid()
        {
            Cursor = Cursors.WaitCursor;
            int customerId = theCustomer is object ? theCustomer.CustomerID : 0;
            int siteId = theSite is object ? theSite.SiteID : 0;
            string postcode = txtPostcode.Text.Trim().Length > 0 ? txtPostcode.Text : null;
            int invoiceTypeId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType));
            string jobNumber = txtJobNumber.Text.Trim().Length > 0 ? txtJobNumber.Text : null;
            string invoiceNumber = txtInvoiceNumber.Text.Trim().Length > 0 ? txtInvoiceNumber.Text : null;
            int userId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboUser));
            int regionId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboRegion));
            string department = Combo.get_GetSelectedItemValue(cboDept).Trim();
            int exportedToSage = -1;
            if (cboExported.SelectedIndex == 1)
            {
                exportedToSage = 1;
            }
            else if (cboExported.SelectedIndex == 2)
            {
                exportedToSage = 0;
            }

            InvoicesDataview = App.DB.Invoiced.Invoiced_GetAll_Manager(dtpRaisedFrom.Value, dtpRaisedTo.Value, customerId, siteId, postcode, invoiceTypeId, jobNumber, invoiceNumber, userId, regionId, department, exportedToSage);
            if (chkExportedOn.Checked)
            {
                string query = "ExportedOn = #" + dtpExportedOn.Value.ToString("yyyy-MM-dd") + "#";
                InvoicesDataview.RowFilter = query;
            }

            grpInvoices.Text = "Double Click To View / Add Payment Information - Search Results (" + InvoicesDataview.Count + ")";
            Cursor = Cursors.Default;
        }

        private void ResetFilters()
        {
            theCustomer = null;
            var fromDate = default(DateTime);
            var switchExpr = DateAndTime.Today.DayOfWeek;
            switch (switchExpr)
            {
                case DayOfWeek.Monday:
                    {
                        fromDate = DateAndTime.Now;
                        break;
                    }

                case DayOfWeek.Tuesday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-1);
                        break;
                    }

                case DayOfWeek.Wednesday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-2);
                        break;
                    }

                case DayOfWeek.Thursday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-3);
                        break;
                    }

                case DayOfWeek.Friday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-4);
                        break;
                    }

                case DayOfWeek.Saturday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-5);
                        break;
                    }

                case DayOfWeek.Sunday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-6);
                        break;
                    }
            }

            var argc = cboStatus;
            Combo.SetUpCombo(ref argc, DynamicDataTables.InvoiceStatus, "ValueMember", "DisplayMember", Enums.ComboValues.None);
            var argcombo = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, (-3).ToString());
            txtInvoiceNumber.Text = "";
            var argc1 = cboUser;
            Combo.SetUpCombo(ref argc1, App.DB.User.GetAll().Table, "UserID", "Fullname", Enums.ComboValues.No_Filter);
            var argcombo1 = cboUser;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            dtpRaisedFrom.Value = fromDate.AddDays(-21);
            dtpRaisedTo.Value = fromDate.AddDays(7);
            var argc2 = cboType;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.InvoiceTypes).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            var argcombo2 = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, 0.ToString());
            var argc3 = cboRegion;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc4 = cboDept;
                        Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc5 = cboDept;
                        Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

            txtJobNumber.Text = "";
            txtPostcode.Text = "";
            string d1 = Conversions.ToString(App.DB.ExecuteScalar("Select Name from tblpicklists where enumtypeid = 69"));
            if (!Information.IsNothing(d1))
            {
                txtSageMonth.Text = Conversions.ToDate(d1).ToString("MMMM yyyy");
            }
        }

        public void Export()
        {
            if (!(Helper.MakeIntegerValid(InvoicesDataview?.Count) > 0))
            {
                App.ShowMessage("No filter added", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var exportData = new DataTable();
            exportData.Columns.Add("PaidStatus");
            exportData.Columns.Add("Customer");
            exportData.Columns.Add("Site");
            exportData.Columns.Add("InvoiceType");
            exportData.Columns.Add("JobNumber");
            exportData.Columns.Add("InvoiceAddressType");
            exportData.Columns.Add("InvoiceAddress");
            exportData.Columns.Add("Amount", typeof(double));
            exportData.Columns.Add("InvoiceNumber");
            exportData.Columns.Add("RaisedDate");
            exportData.Columns.Add("Fullname");
            exportData.Columns.Add("Department");
            exportData.Columns.Add("Exported");
            foreach (DataRowView dr in (DataView)dgInvoices.DataSource)
            {
                var newRw = exportData.NewRow();
                newRw["PaidStatus"] = SelectedInvoiceDataRow["PaidStatus"];
                newRw["Customer"] = SelectedInvoiceDataRow["Customer"];
                newRw["Site"] = SelectedInvoiceDataRow["Site"];
                newRw["InvoiceType"] = SelectedInvoiceDataRow["InvoiceType"];
                newRw["JobNumber"] = SelectedInvoiceDataRow["JobNumber"];
                newRw["InvoiceAddressType"] = SelectedInvoiceDataRow["InvoiceAddressType"];
                newRw["InvoiceAddress"] = SelectedInvoiceDataRow["InvoiceAddress"];
                newRw["Amount"] = SelectedInvoiceDataRow["Amount"];
                newRw["InvoiceNumber"] = SelectedInvoiceDataRow["InvoiceNumber"];
                newRw["RaisedDate"] = Strings.Format(SelectedInvoiceDataRow["RaisedDate"], "dd/MM/yyyy");
                newRw["Fullname"] = SelectedInvoiceDataRow["Fullname"];
                newRw["Department"] = SelectedInvoiceDataRow["Department"];
                if (Helper.MakeDateTimeValid(SelectedInvoiceDataRow["DateExportedToSage"]) == default)
                {
                    newRw["Exported"] = "";
                }
                else
                {
                    newRw["Exported"] = Strings.Format(SelectedInvoiceDataRow["DateExportedToSage"], "dd/MM/yyyy");
                }

                exportData.Rows.Add(newRw);
            }

            ExportHelper.Export(exportData, "Invoiced List", Enums.ExportType.XLS);
        }

        public void Print()
        {
            if (InvoicesToPrint.Count < 1)
                return;
            var details = new ArrayList();
            details.Add(InvoicesToPrint);
            var oPrint = new Printing(details, "Invoice", Enums.SystemDocumentType.Invoice, true);
            InvoicesToPrint.Clear();
        }

        public void FindPartPayJobs(bool Multi)
        {
            try
            {
                // FOR EVERY TICKED RECORD
                foreach (DataRow dr in InvoicesDataview.Table.Rows)
                {
                    if (Helper.MakeBooleanValid(dr["tick"]) == true)
                    {
                        // VISIT RECORDS
                        if ((Enums.InvoiceType)Conversions.ToInteger(dr["InvoiceTypeID"]) == Enums.InvoiceType.Visit)
                        {
                            // SEE IF JOB IS PART PAY
                            if (App.DB.Job.Job_Get(Conversions.ToInteger(dr["JobID"])).ToBePartPaid == true)
                            {
                                // UNTICK - We'll add to print list from here

                                dr["tick"] = 0;
                                // IS IT INVOICED?
                                if (Helper.MakeIntegerValid(dr["invoicedID"]) == 0) // Invoiced =NO
                                {

                                    // IS THERE AN Invoice for any other visits on this job?
                                    var dt = App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(Conversions.ToInteger(dr["JobID"])).Table;
                                    if (dt.Rows.Count > 0) // Exisiting Invoice =YES
                                    {

                                        // Add to Exisiting Invoice
                                        InsertInvoiceLines(Helper.MakeDoubleValid(dr["Amount"]), Conversions.ToInteger(dt.Rows[0]["InvoicedID"]), Conversions.ToInteger(dr["InvoiceToBeRaisedID"]));

                                        // Add Invoice to print list
                                        if (!InvoicesToPrint.Contains(dt.Rows[0]["InvoicedID"]))
                                        {
                                            InvoicesToPrint.Add(Helper.MakeIntegerValid(dt.Rows[0]["InvoicedID"]));
                                        }
                                    }
                                    else // Exisiting Invoice =NO
                                    {
                                        // CREATE NEW INVOICE
                                        var inv = new Entity.Invoiceds.Invoiced();
                                        var invNum = new JobNumber();
                                        invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                                        inv.SetInvoiceNumber = invNum.Prefix + invNum.JobNumber;
                                        inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                        inv.RaisedDate = DateAndTime.Now;
                                        inv = App.DB.Invoiced.Insert(inv);
                                        // ADD ALL THE VISITS READY FOR INVOICE
                                        var dtVisits = App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(Conversions.ToInteger(dr["JobID"])).Table;
                                        foreach (DataRow v in dtVisits.Rows)
                                            InsertInvoiceLines(Helper.MakeDoubleValid(v["Amount"]), inv.InvoicedID, Conversions.ToInteger(v["InvoiceToBeRaisedID"]));

                                        // IF its multi line invoice add on anyother things
                                        if (Multi)
                                        {
                                            MultiInvoicePPJob(dr, inv, dtVisits);
                                        }

                                        // Add Invoice to print list
                                        if (!InvoicesToPrint.Contains(inv.InvoicedID))
                                        {
                                            InvoicesToPrint.Add(Helper.MakeIntegerValid(inv.InvoicedID));
                                        }
                                    }
                                }
                                else // Invoiced = YES
                                {
                                    // ARE THERE ANY OTHER VISITS THAT SHOUlD BE ONE THIS INVOICE THAT AREN'T?
                                    // ADD THEM
                                    foreach (DataRow v in App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(Conversions.ToInteger(dr["JobID"])))
                                    {
                                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(dr["InvoiceToBeRaisedID"], v["InvoiceToBeRaisedID"], false)))
                                        {
                                            InsertInvoiceLines(Helper.MakeDoubleValid(v["Amount"]), Conversions.ToInteger(dr["invoicedID"]), Conversions.ToInteger(v["InvoiceToBeRaisedID"]));
                                        }
                                    }

                                    // Add Invoice to print list
                                    if (!InvoicesToPrint.Contains(dr["InvoicedID"]))
                                    {
                                        InvoicesToPrint.Add(Helper.MakeIntegerValid(dr["InvoicedID"]));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MultiInvoicePPJob(DataRow dr, Entity.Invoiceds.Invoiced inv, DataTable dtVisits)
        {
            try
            {
                // GET ALL ITEMS THAT YOU WANNA PUT ON THE INVOICE
                var drInv = InvoicesDataview.Table.Select(Conversions.ToString(Conversions.ToString("AddressTypeID=" + dr["AddressTypeID"] + " AND AddressID=") + dr["AddressID"]));
                for (int i = 0, loopTo = drInv.Length - 1; i <= loopTo; i++)
                {

                    // IS IT INVOICED ALREADY?
                    if (Helper.MakeIntegerValid(drInv[i]["invoicedID"]) == 0) // NO
                    {

                        // IS IT A VISIT OR AN ORDER?
                        if ((Enums.InvoiceType)Conversions.ToInteger(drInv[i]["InvoiceTypeID"]) == Enums.InvoiceType.Order)
                        {
                            // ORDER
                            // UNTICK
                            drInv[i]["tick"] = 0;
                            InsertInvoiceLines(Helper.MakeDoubleValid(drInv[i]["Amount"]), inv.InvoicedID, Conversions.ToInteger(drInv[i]["InvoiceToBeRaisedID"]));
                        }

                        // IS THE VISIT ALREADY INSERTED ABOVE?
                        else if (dtVisits.Select(Conversions.ToString("InvoiceToBeRaisedID=" + drInv[i]["InvoiceToBeRaisedID"])).Length > 0) // VISIT
                        {
                            // YES UNTICK
                            drInv[i]["tick"] = 0;
                        }
                        // NO - IS IT PP JOB ?
                        else if (App.DB.Job.Job_Get(Conversions.ToInteger(drInv[i]["JobID"])).ToBePartPaid == true) // YES
                        {
                            // IS THERE ANY EXISTING INVOICES FOR THE JOB'S VISIT
                            bool jobAlreadyInvoiced = false;
                            var alreadyInv = App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(Conversions.ToInteger(drInv[i]["JobID"])).Table;
                            if (alreadyInv.Rows.Count > 0)
                            {
                                // AND ITS A DIFFERENT INVOICE TO THIS ONE
                                foreach (DataRow aInv in alreadyInv.Rows)
                                {
                                    if (Helper.MakeIntegerValid(drInv[i]["InvoicedID"]) == Helper.MakeIntegerValid(aInv["InvoicedID"]))
                                    {
                                        jobAlreadyInvoiced = true; // Just leave the this alone it will picked up later
                                    }
                                }

                                if (jobAlreadyInvoiced)
                                {
                                }
                                // Just leave the this alone it will picked up later
                                else
                                {
                                    // UNTICK AND INSERT
                                    drInv[i]["tick"] = 0;
                                    InsertInvoiceLines(Helper.MakeDoubleValid(drInv[i]["Amount"]), inv.InvoicedID, Conversions.ToInteger(drInv[i]["InvoiceToBeRaisedID"]));
                                }
                            }
                            else // NO INVOICE
                            {
                                // UNTICK AND INSERT
                                drInv[i]["tick"] = 0;
                                InsertInvoiceLines(Helper.MakeDoubleValid(drInv[i]["Amount"]), inv.InvoicedID, Conversions.ToInteger(drInv[i]["InvoiceToBeRaisedID"]));
                            }
                        }
                        else // NO
                        {
                            // UNTICK AND INSERT
                            drInv[i]["tick"] = 0;
                            InsertInvoiceLines(Helper.MakeDoubleValid(drInv[i]["Amount"]), inv.InvoicedID, Conversions.ToInteger(drInv[i]["InvoiceToBeRaisedID"]));
                        }
                    }
                    else // ALREADY INVOICED SO JUST UNTICK
                    {
                        drInv[i]["tick"] = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InsertInvoiceLines(double amount, int invoicedID, int InvoiceToBeRaisedID)
        {
            var invLines = new Entity.InvoicedLiness.InvoicedLines();
            invLines.SetAmount = amount;
            invLines.SetInvoicedID = invoicedID;
            invLines.SetInvoiceToBeRaisedID = InvoiceToBeRaisedID;
            invLines = App.DB.InvoicedLines.Insert(invLines);
        }

        private bool Check_Supplier_Invoices_And_Continue()
        {
            bool invoicesRemoved = false;
            foreach (DataRow row in InvoicesDataview.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["InvoiceType"], "Supplier", false) | Operators.ConditionalCompareObjectEqual(row["InvoiceType"], "Consolidation", false)))
                {
                    if (Conversions.ToBoolean(row["Tick"]))
                    {
                        row["Tick"] = false;
                        invoicesRemoved = true;
                    }
                }
            }

            if (invoicesRemoved)
            {
                if (App.ShowMessage("Supplier invoices have been removed - would you like to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

        private async void btnMarkAsNotExported_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to mark the selected invoices as not exported?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                if (InvoicesDataview is object)
                {
                    DataRow nw = null;
                    foreach (DataRowView r in InvoicesDataview)
                    {
                        if (Conversions.ToBoolean(r["tick"]))
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Supplier", false)))
                            {
                                await App.DB.Invoiced.MarkOrderAsNotExportedAsync(Conversions.ToInteger(r["SupplierInvoiceID"]));
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Part Credit", false)))
                            {
                                await App.DB.Invoiced.MarkPartCreditedAsNotExportedAsync(Conversions.ToInteger(r["OrderID"]), Conversions.ToInteger(r["LinkID"]));
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Consolidation", false)))
                            {
                                await App.DB.Invoiced.MarkConsolidatedOrderAsNotExportedAsync(Conversions.ToInteger(r["OrderID"]));
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Sales Credit", false)))
                            {
                                await App.DB.Invoiced.MarkSalesCreditAsNotExportedAsync(Conversions.ToInteger(r["LinkID"]));
                            }
                            else
                            {
                                await App.DB.Invoiced.MarkInvoiceAsNotExportedAsync(Conversions.ToInteger(r["InvoicedID"]));
                            }
                        }
                    }
                }

                PopulateDatagrid();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
        }

        private void cboExportedToSage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateDatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportToAccounts_Click(object sender, EventArgs e)
        {
            cmsExportForAccounts.Show(btnExportToAccounts, new Point(0, 0));
        }

        private async void tsmiSunExport_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                if (InvoicesDataview is object)
                {
                    var dr = (from sf in InvoicesDataview.Table.AsEnumerable()
                              where sf.Field<bool>("Tick") == true
                              select sf).ToArray();
                    if (dr.Count() < 1)
                    {
                        App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var accountingPeriodDate = new DateTime(Conversions.ToDate(txtSageMonth.Text).Year, Conversions.ToDate(txtSageMonth.Text).Month, 1);
                    var dtSunMaps = App.DB.SunFinance.GetAllMaps();
                    var payload = new Entity.Accounts.Payload();
                    foreach (DataRow r in dr)
                    {
                        string custType = string.Empty;
                        var switchExpr = r["InvoiceType"].ToString();
                        switch (switchExpr)
                        {
                            case "Supplier":
                            case "Part Credit":
                            case "Consolidation":
                                {
                                    custType = "Supplier";
                                    break;
                                }

                            default:
                                {
                                    custType = "Customer";
                                    break;
                                }
                        }

                        bool purchases = (custType ?? "") == "Supplier" ? true : false;
                        if (Helper.MakeBooleanValid(r["ExportedToSage"]) == false)
                        {
                            if (Conversions.ToDouble(r["Amount"]) > 0.0)
                            {
                                if (Conversions.ToDate(Strings.Format(r["Raiseddate"], "dd/MM/yyyy")) < accountingPeriodDate & !purchases)
                                {
                                    App.ShowMessage("A invoice has been stopped in the export as it is for a different month to the current processing month.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    string nominalCode = dtSunMaps.AsEnumerable().Select(x => new
                                    {
                                        Type = x.Field<string>("Type"),
                                        OldVal = x.Field<string>("OldVal"),
                                        NewVal = x.Field<string>("NewVal"),
                                        Deleted = x.Field<bool>("Deleted")
                                    }).Where(s => (s.Type ?? "") == "Nominal" && Operators.ConditionalCompareObjectEqual(s.OldVal, r["NominalCode"], false) && s.Deleted == false).Select(h => h.NewVal).FirstOrDefault();
                                    if (string.IsNullOrEmpty(nominalCode))
                                        nominalCode = Conversions.ToString(r["NominalCode"]);
                                    string account = dtSunMaps.AsEnumerable().Select(x => new
                                    {
                                        Type = x.Field<string>("Type"),
                                        OldVal = x.Field<string>("OldVal"),
                                        NewVal = x.Field<string>("NewVal"),
                                        Deleted = x.Field<bool>("Deleted")
                                    }).Where(s => (s.Type ?? "") == (custType ?? "") && Operators.ConditionalCompareObjectEqual(s.OldVal, r["AccountNumber"], false) && s.Deleted == false).Select(h => h.NewVal).FirstOrDefault();
                                    if (string.IsNullOrEmpty(account))
                                        account = Conversions.ToString(r["AccountNumber"]);
                                    string regionCode = dtSunMaps.AsEnumerable().Select(x => new
                                    {
                                        Type = x.Field<string>("Type"),
                                        OldVal = x.Field<string>("OldVal"),
                                        NewVal = x.Field<string>("NewVal"),
                                        Deleted = x.Field<bool>("Deleted")
                                    }).Where(s => (s.Type ?? "") == "Region" && Operators.ConditionalCompareObjectEqual(s.OldVal, r["Region"], false) && s.Deleted == false).Select(h => h.NewVal).FirstOrDefault();
                                    var netLine = new Entity.Accounts.Line();
                                    Entity.Accounts.Line vatLine = null;
                                    Entity.Accounts.Line grossLine = null;
                                    netLine.AccountCode = nominalCode;
                                    netLine.AccountingPeriod = Entity.Accounts.AccountsHelper.GetAccountPeriod(accountingPeriodDate);
                                    if (!string.IsNullOrEmpty(regionCode))
                                        netLine.AnalysisCode1 = regionCode;
                                    netLine.AnalysisCode2 = Entity.Accounts.AccountsHelper.FormatSunDepartment(Conversions.ToString(r["Department"]));
                                    netLine.TransactionDate = Strings.Format(Conversions.ToDate(r["RaisedDate"]), "ddMMyyyy");
                                    netLine.TransactionReference = Conversions.ToString(r["InvoiceNumber"]);
                                    netLine.EntryDate = DateAndTime.Now.ToString("ddMMyyyy");
                                    if (Helper.MakeIntegerValid(r["JobID"]) > 0)
                                    {
                                        string jobType = Helper.MakeStringValid(r["JobType"]);
                                        string jobTypeMap = dtSunMaps.AsEnumerable().Select(x => new
                                        {
                                            Type = x.Field<string>("Type"),
                                            OldVal = x.Field<string>("OldVal"),
                                            NewVal = x.Field<string>("NewVal"),
                                            Deleted = x.Field<bool>("Deleted")
                                        }).Where(s => (s.Type ?? "") == "JobType" && (s.OldVal ?? "") == (jobType ?? "") && s.Deleted == false).Select(h => h.NewVal).FirstOrDefault();
                                        if (string.IsNullOrEmpty(jobTypeMap))
                                            jobTypeMap = "GENERI";
                                        netLine.AnalysisCode4 = jobTypeMap;
                                    }
                                    else
                                    {
                                        netLine.AnalysisCode4 = "GENERI";
                                    }

                                    if ((netLine.AnalysisCode2 ?? "") == "004")
                                    {
                                        netLine.AnalysisCode6 = "COM";
                                    }
                                    else if (Helper.MakeIntegerValid(r["CustomerTypeID"]) == Conversions.ToInteger(Enums.CustomerType.SocialHousing))
                                    {
                                        netLine.AnalysisCode6 = "GSH";
                                    }
                                    else
                                    {
                                        netLine.AnalysisCode6 = "GAS";
                                    }

                                    netLine.AnalysisCode7 = account;
                                    string customer = Helper.MakeStringValid(r["Customer"]).Replace(" ", "");
                                    netLine.AnalysisCode8 = customer.Substring(0, Math.Min(customer.Length, 15));
                                    netLine.AnalysisCode9 = Conversions.ToString(r["JobNumber"]);
                                    string vatCode = null;
                                    var switchExpr1 = r["Tax_Code"].ToString();
                                    switch (switchExpr1)
                                    {
                                        case "T0":
                                            {
                                                vatCode = "ZR";
                                                break;
                                            }

                                        case "T1":
                                            {
                                                vatCode = "SR";
                                                break;
                                            }

                                        case "T2":
                                            {
                                                vatCode = "ER";
                                                break;
                                            }

                                        case "T5":
                                            {
                                                vatCode = "LR";
                                                break;
                                            }

                                        case "T9":
                                            {
                                                vatCode = "OS";
                                                break;
                                            }
                                    }

                                    var switchExpr2 = r["InvoiceType"].ToString();
                                    switch (switchExpr2)
                                    {
                                        case "Supplier":
                                        case "Part Credit":
                                        case "Consolidation":
                                            {
                                                vatCode = "I" + vatCode;
                                                break;
                                            }

                                        default:
                                            {
                                                vatCode = "O" + vatCode;
                                                break;
                                            }
                                    }

                                    string purchaseVatCode = "B5850";
                                    if (App.IsRFT)
                                    {
                                        netLine.AnalysisCode3 = "NTS";
                                        netLine.AnalysisCode4 = "ADH001";
                                        netLine.AnalysisCode6 = "XXX";
                                        purchaseVatCode = "M9999";
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Supplier", false)))
                                    {
                                        netLine.AnalysisCode5 = vatCode;
                                        if (App.IsRFT)
                                        {
                                            netLine.Description = Conversions.ToString(Conversions.ToString(r["InvoiceAddress"] + " ") + r["JobNumber"]);
                                        }
                                        else
                                        {
                                            netLine.Description = Conversions.ToString(r["JobNumber"]);
                                        }

                                        if (r.Table.Columns.Contains("SubTaxRate") && !Information.IsDBNull(r["SubTaxRate"]))
                                        {
                                            Entity.Accounts.Line cisVatLine = null;
                                            Entity.Accounts.Line cisLine = null;
                                            netLine.JournalType = "PICIS";
                                            vatLine = (Entity.Accounts.Line)netLine.Clone();
                                            grossLine = (Entity.Accounts.Line)netLine.Clone();
                                            vatLine.AccountCode = purchaseVatCode;
                                            grossLine.AccountCode = account;
                                            cisVatLine = (Entity.Accounts.Line)netLine.Clone();
                                            cisLine = (Entity.Accounts.Line)netLine.Clone();
                                            cisVatLine.AccountCode = "B5710";
                                            cisLine.AccountCode = account;
                                            if ((nominalCode ?? "") == "23100")
                                            {
                                                double cisVatAmount = Helper.MakeDoubleValid(r["Amount"]) * Helper.MakeDoubleValid(r["SubTaxRate"]);
                                                cisVatLine.TransactionAmount = -cisVatAmount;
                                                cisLine.TransactionAmount = cisVatAmount;
                                            }
                                            else
                                            {
                                                cisVatLine.TransactionAmount = -0;
                                                cisLine.TransactionAmount = 0;
                                            }

                                            cisVatLine.DebitCredit = "C";
                                            cisLine.DebitCredit = "D";
                                            netLine.DebitCredit = "D";
                                            vatLine.DebitCredit = "D";
                                            grossLine.DebitCredit = "C";
                                            if (App.IsRFT)
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(r["Amount"] + r["VATAmount"]);
                                            }
                                            else
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(r["Amount"]);
                                            }

                                            vatLine.TransactionAmount = Conversions.ToDouble(r["VATAmount"]);
                                            grossLine.TransactionAmount = Conversions.ToDouble(-r["Amount"] + -r["VATAmount"]);
                                            payload.Ledger.Add(netLine);
                                            payload.Ledger.Add(vatLine);
                                            payload.Ledger.Add(grossLine);
                                            if (cisVatLine is object)
                                                payload.Ledger.Add(cisVatLine);
                                            if (cisVatLine is object)
                                                payload.Ledger.Add(cisLine);
                                        }
                                        else
                                        {
                                            netLine.JournalType = "PIGAB";
                                            vatLine = (Entity.Accounts.Line)netLine.Clone();
                                            grossLine = (Entity.Accounts.Line)netLine.Clone();
                                            vatLine.AccountCode = purchaseVatCode;
                                            grossLine.AccountCode = account;
                                            netLine.DebitCredit = "D";
                                            vatLine.DebitCredit = "D";
                                            grossLine.DebitCredit = "C";
                                            if (App.IsRFT)
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(r["Amount"] + r["VATAmount"]);
                                            }
                                            else
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(r["Amount"]);
                                            }

                                            vatLine.TransactionAmount = Conversions.ToDouble(r["VATAmount"]);
                                            grossLine.TransactionAmount = Conversions.ToDouble(-r["Amount"] + -r["VATAmount"]);
                                            payload.Ledger.Add(netLine);
                                            payload.Ledger.Add(vatLine);
                                            payload.Ledger.Add(grossLine);
                                        }

                                        await App.DB.Invoiced.MarkOrderAsExportedAsync(Conversions.ToInteger(r["SupplierInvoiceID"]));
                                    }
                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Part Credit", false)))
                                    {
                                        netLine.AnalysisCode5 = vatCode;
                                        if (App.IsRFT)
                                        {
                                            netLine.Description = Conversions.ToString(Conversions.ToString(r["InvoiceAddress"] + " ") + r["JobNumber"]);
                                        }
                                        else
                                        {
                                            netLine.Description = Conversions.ToString(r["JobNumber"]);
                                        }

                                        if (r.Table.Columns.Contains("SubTaxRate") && !Information.IsDBNull(r["SubTaxRate"]))
                                        {
                                            Entity.Accounts.Line cisVatLine = null;
                                            Entity.Accounts.Line cisLine = null;
                                            netLine.JournalType = "PCCIS";
                                            vatLine = (Entity.Accounts.Line)netLine.Clone();
                                            grossLine = (Entity.Accounts.Line)netLine.Clone();
                                            vatLine.AccountCode = purchaseVatCode;
                                            grossLine.AccountCode = account;
                                            cisVatLine = (Entity.Accounts.Line)netLine.Clone();
                                            cisLine = (Entity.Accounts.Line)netLine.Clone();
                                            cisVatLine.AccountCode = "B5710";
                                            cisLine.AccountCode = account;
                                            if ((nominalCode ?? "") == "23100")
                                            {
                                                double cisVatAmount = Helper.MakeDoubleValid(r["Amount"]) * Helper.MakeDoubleValid(r["SubTaxRate"]);
                                                cisVatLine.TransactionAmount = cisVatAmount;
                                                cisLine.TransactionAmount = -cisVatAmount;
                                            }
                                            else
                                            {
                                                cisVatLine.TransactionAmount = 0;
                                                cisLine.TransactionAmount = -0;
                                            }

                                            cisLine.DebitCredit = "D";
                                            cisVatLine.DebitCredit = "C";
                                            netLine.DebitCredit = "C";
                                            vatLine.DebitCredit = "C";
                                            grossLine.DebitCredit = "D";
                                            if (App.IsRFT)
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(-r["Amount"] + -r["VATAmount"]);
                                            }
                                            else
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(-r["Amount"]);
                                            }

                                            vatLine.TransactionAmount = Conversions.ToDouble(-r["VATAmount"]);
                                            grossLine.TransactionAmount = Conversions.ToDouble(r["Amount"] + r["VATAmount"]);
                                            payload.Ledger.Add(netLine);
                                            payload.Ledger.Add(vatLine);
                                            payload.Ledger.Add(grossLine);
                                            if (cisVatLine is object)
                                                payload.Ledger.Add(cisVatLine);
                                            if (cisVatLine is object)
                                                payload.Ledger.Add(cisLine);
                                        }
                                        else
                                        {
                                            netLine.JournalType = "PCGAB";
                                            vatLine = (Entity.Accounts.Line)netLine.Clone();
                                            grossLine = (Entity.Accounts.Line)netLine.Clone();
                                            vatLine.AccountCode = purchaseVatCode;
                                            grossLine.AccountCode = account;
                                            netLine.DebitCredit = "C";
                                            vatLine.DebitCredit = "C";
                                            grossLine.DebitCredit = "D";
                                            if (App.IsRFT)
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(-r["Amount"] + -r["VATAmount"]);
                                            }
                                            else
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(-r["Amount"]);
                                            }

                                            vatLine.TransactionAmount = Conversions.ToDouble(-r["VATAmount"]);
                                            grossLine.TransactionAmount = Conversions.ToDouble(r["Amount"] + r["VATAmount"]);
                                            payload.Ledger.Add(netLine);
                                            payload.Ledger.Add(vatLine);
                                            payload.Ledger.Add(grossLine);
                                        }

                                        await App.DB.Invoiced.MarkPartCreditedAsExportedAsync(Conversions.ToInteger(r["OrderID"]), Conversions.ToInteger(r["LinkID"]));
                                    }
                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Consolidation", false)))
                                    {
                                        netLine.AnalysisCode5 = vatCode;
                                        if (App.IsRFT)
                                        {
                                            netLine.Description = Conversions.ToString(Conversions.ToString(r["InvoiceAddress"] + " ") + r["JobNumber"]);
                                        }
                                        else
                                        {
                                            netLine.Description = Conversions.ToString(r["JobNumber"]);
                                        }

                                        netLine.JournalType = "PIGAB";
                                        vatLine = (Entity.Accounts.Line)netLine.Clone();
                                        grossLine = (Entity.Accounts.Line)netLine.Clone();
                                        vatLine.AccountCode = purchaseVatCode;
                                        grossLine.AccountCode = account;
                                        netLine.DebitCredit = "D";
                                        vatLine.DebitCredit = "D";
                                        grossLine.DebitCredit = "C";
                                        if (App.IsRFT)
                                        {
                                            netLine.TransactionAmount = Conversions.ToDouble(r["Amount"] + r["VATAmount"]);
                                        }
                                        else
                                        {
                                            netLine.TransactionAmount = Conversions.ToDouble(r["Amount"]);
                                        }

                                        vatLine.TransactionAmount = Conversions.ToDouble(r["VATAmount"]);
                                        grossLine.TransactionAmount = Conversions.ToDouble(-r["Amount"] + -r["VATAmount"]);
                                        payload.Ledger.Add(netLine);
                                        payload.Ledger.Add(vatLine);
                                        payload.Ledger.Add(grossLine);

                                        // OrderID holds the consolidated order id
                                        await App.DB.Invoiced.MarkConsolidatedOrderAsExportedAsync(Conversions.ToInteger(r["OrderID"]));
                                    }
                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Sales Credit", false)))
                                    {
                                        netLine.AnalysisCode5 = vatCode;
                                        netLine.AnalysisCode9 = Conversions.ToString(r["JobNumber"]);
                                        netLine.Description = Conversions.ToString("Credit Against Invoice : " + r["InvoiceNumber"]);
                                        netLine.TransactionReference = Conversions.ToString(r["JobNumber"]);
                                        netLine.JournalType = "SCGAB";
                                        vatLine = (Entity.Accounts.Line)netLine.Clone();
                                        grossLine = (Entity.Accounts.Line)netLine.Clone();
                                        vatLine.AccountCode = "B5800";
                                        grossLine.AccountCode = account;
                                        netLine.DebitCredit = "D";
                                        vatLine.DebitCredit = "D";
                                        grossLine.DebitCredit = "C";
                                        decimal VATRate = Conversions.ToDecimal(r["VATRATE"]);
                                        decimal VATRateDecimal = VATRate / 100;
                                        if (Helper.MakeBooleanValid(r["IsOutOfScope"]))
                                            VATRateDecimal = 0;
                                        netLine.TransactionAmount = Conversions.ToDouble(r["Amount"]);
                                        vatLine.TransactionAmount = Conversions.ToDecimal(r["Amount"]) * VATRateDecimal;
                                        grossLine.TransactionAmount = Conversions.ToDouble(-r["Amount"] + -(Conversions.ToDecimal(r["Amount"]) * VATRateDecimal));
                                        payload.Ledger.Add(netLine);
                                        payload.Ledger.Add(vatLine);
                                        payload.Ledger.Add(grossLine);

                                        // LinkID holds the SalescreditID
                                        await App.DB.Invoiced.MarkSalesCreditAsExportedAsync(Conversions.ToInteger(r["LinkID"]));
                                    }
                                    else
                                    {
                                        netLine.AnalysisCode5 = vatCode;
                                        string description = "";
                                        description += Helper.MakeStringValid(r["Address1"]).Trim().Replace(",", "");
                                        description += " ";
                                        description += Helper.MakeStringValid(r["Address2"]).Trim().Replace(",", "");
                                        description += "- " + Helper.MakeStringValid(r["PolicyNumber"]).Trim().Replace(",", "");
                                        if (description.Trim().Length == 0)
                                        {
                                            description = "FSM INVOICE";
                                        }

                                        netLine.Description = description;
                                        netLine.JournalType = "SIGAB";
                                        vatLine = (Entity.Accounts.Line)netLine.Clone();
                                        grossLine = (Entity.Accounts.Line)netLine.Clone();
                                        vatLine.AccountCode = "B5800";
                                        grossLine.AccountCode = account;
                                        netLine.DebitCredit = "C";
                                        vatLine.DebitCredit = "C";
                                        grossLine.DebitCredit = "D";
                                        decimal VATRate = Conversions.ToDecimal(r["VATRATE"]);
                                        decimal VATRateDecimal = VATRate / 100;
                                        if (Helper.MakeBooleanValid(r["IsOutOfScope"]))
                                            VATRateDecimal = 0;
                                        netLine.TransactionAmount = Conversions.ToDouble(-r["Amount"]);
                                        vatLine.TransactionAmount = Conversions.ToDouble(-(Conversions.ToDecimal(r["Amount"]) * VATRateDecimal));
                                        grossLine.TransactionAmount = Conversions.ToDouble(r["Amount"] + Conversions.ToDecimal(r["Amount"]) * VATRateDecimal);
                                        payload.Ledger.Add(netLine);
                                        payload.Ledger.Add(vatLine);
                                        payload.Ledger.Add(grossLine);
                                        await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(r["InvoicedID"]));
                                    }
                                }
                            }
                            else
                            {
                                await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(r["InvoicedID"]));
                            }
                        }
                    }

                    var SSC = new Entity.Accounts.SSC();
                    SSC.Payload = payload;
                    if (SSC.SaveToXml())
                    {
                        MessageBox.Show("Export Completed!", "Completion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    PopulateDatagrid();
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
        }

        private async void tsmiSageExport_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                var t = new DataTable();
                t.Columns.Add("Type"); // always "SI" for fsm invoices
                t.Columns.Add("AccountNumber");
                t.Columns.Add("NominalCode"); // depends on [JobDefinition]
                t.Columns.Add("DepartmentCode");
                t.Columns.Add("RaisedDate");
                t.Columns.Add("InvoiceNumber");
                t.Columns.Add("Description"); // always Address1<space>Address2 unless both blank then always "FSM Invoice"
                t.Columns.Add("Amount"); // (amount before vat)
                t.Columns.Add("VATCode"); // always "T1" for fsm invoices
                t.Columns.Add("VATAmount");
                t.Columns.Add("ExchangeRate");
                t.Columns.Add("ExtraRef");
                var accountingPeriodDate = new DateTime(Conversions.ToDate(txtSageMonth.Text).Year, Conversions.ToDate(txtSageMonth.Text).Month, 1);
                if (InvoicesDataview is object)
                {
                    DataRow nw;
                    foreach (DataRow r in InvoicesDataview.Table.Rows)
                    {
                        if (Conversions.ToBoolean(r["ExportedToSage"]) == false) // don't export if already marked as done or nill value
                        {
                            if (Conversions.ToDouble(r["Amount"]) > 0.0)
                            {
                                if (Conversions.ToBoolean(r["tick"]))
                                {
                                    string custType = string.Empty;
                                    var switchExpr = r["InvoiceType"].ToString();
                                    switch (switchExpr)
                                    {
                                        case "Supplier":
                                        case "Part Credit":
                                        case "Consolidation":
                                            {
                                                custType = "Supplier";
                                                break;
                                            }

                                        default:
                                            {
                                                custType = "Customer";
                                                break;
                                            }
                                    }

                                    bool purchases = (custType ?? "") == "Supplier" ? true : false;
                                    if (Conversions.ToDate(Strings.Format(r["Raiseddate"], "dd/MM/yyyy")) < accountingPeriodDate & !purchases)
                                    {
                                        App.ShowMessage("A invoice has been stopped in the export as it is for a diffent month to the current processing month.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        nw = t.NewRow();
                                        nw["AccountNumber"] = r["AccountNumber"];
                                        nw["NominalCode"] = r["NominalCode"];
                                        nw["DepartmentCode"] = r["Department"];
                                        nw["RaisedDate"] = Strings.Format(Conversions.ToDate(r["RaisedDate"]), "dd/MM/yyyy");
                                        nw["InvoiceNumber"] = r["InvoiceNumber"];
                                        nw["Amount"] = r["Amount"];
                                        nw["ExchangeRate"] = 1;
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Supplier", false)))
                                        {
                                            nw["VatAmount"] = Strings.Format(Conversions.ToDecimal(r["VATAmount"]), "f");
                                            nw["Type"] = "PI";
                                            nw["Description"] = r["JobNumber"];
                                            nw["VATCode"] = r["Tax_Code"];
                                            nw["ExtraRef"] = r["ExtraRef"];
                                            await App.DB.Invoiced.MarkOrderAsExportedAsync(Conversions.ToInteger(r["SupplierInvoiceID"]));
                                        }
                                        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Part Credit", false)))
                                        {
                                            nw["VatAmount"] = Strings.Format(Conversions.ToDecimal(r["VATAmount"]), "f");
                                            nw["Type"] = "PC";
                                            nw["Description"] = r["JobNumber"];
                                            nw["VATCode"] = r["Tax_Code"];
                                            nw["ExtraRef"] = r["ExtraRef"];
                                            nw["InvoiceNumber"] = r["SupplierCreditRef"];
                                            await App.DB.Invoiced.MarkPartCreditedAsExportedAsync(Conversions.ToInteger(r["OrderID"]), Conversions.ToInteger(r["LinkID"]));
                                        }
                                        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Consolidation", false)))
                                        {
                                            nw["VatAmount"] = Strings.Format(Conversions.ToDecimal(r["VATAmount"]), "f");
                                            nw["Type"] = "PI";
                                            nw["Description"] = r["JobNumber"];
                                            nw["VATCode"] = r["Tax_Code"];
                                            nw["ExtraRef"] = r["ExtraRef"];

                                            // OrderID holds the consolidated order id
                                            await App.DB.Invoiced.MarkConsolidatedOrderAsExportedAsync(Conversions.ToInteger(r["OrderID"]));
                                        }
                                        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Sales Credit", false)))
                                        {
                                            decimal VATRate = Conversions.ToDecimal(r["VATRATE"]);
                                            decimal VATRateDecimal = VATRate / 100;
                                            nw["VatAmount"] = Strings.Format(Conversions.ToDecimal(r["Amount"]) * VATRateDecimal, "f");

                                            // nw("VatAmount") = Format(CDec(r("VATAmount")), "f")
                                            nw["Type"] = "SC";
                                            nw["Description"] = "Credit Against Invoice : " + r["JobNumber"];
                                            nw["VATCode"] = r["Tax_Code"];
                                            nw["ExtraRef"] = r["ExtraRef"];
                                            nw["InvoiceNumber"] = r["SupplierCreditRef"];
                                            // LinkID holds the SalescreditID
                                            await App.DB.Invoiced.MarkSalesCreditAsExportedAsync(Conversions.ToInteger(r["LinkID"]));
                                        }
                                        else
                                        {
                                            decimal VATRate = Conversions.ToDecimal(r["VATRATE"]);
                                            decimal VATRateDecimal = VATRate / 100;
                                            nw["VatAmount"] = Strings.Format(Conversions.ToDecimal(r["Amount"]) * VATRateDecimal, "f");
                                            string description = "";
                                            description += Helper.MakeStringValid(r["Address1"]).Trim().Replace(",", "");
                                            description += " ";
                                            description += Helper.MakeStringValid(r["Address2"]).Trim().Replace(",", "");
                                            description += "- " + Helper.MakeStringValid(r["PolicyNumber"]).Trim().Replace(",", "");
                                            if (description.Trim().Length == 0)
                                            {
                                                description = "FSM INVOICE";
                                            }

                                            nw["Type"] = "SI";
                                            nw["Description"] = description;
                                            nw["VATCode"] = r["Tax_Code"]; // T1
                                            nw["ExtraRef"] = r["JobNumber"];
                                            await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(r["InvoicedID"]));
                                        }

                                        t.Rows.Add(nw);
                                    }
                                }
                            }
                            else
                            {
                                await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(r["InvoicedID"]));
                            }
                        }
                    }

                    if (t.Rows.Count > 0)
                    {
                        var csv = new CSVExporter();
                        csv.CreateCSV(new DataView(t));
                        MessageBox.Show("Export complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Please select invoices to export.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }

                PopulateDatagrid();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
        }

        private void chkExportedOn_Click(object sender, EventArgs e)
        {
            chkExportedOn.Checked = !chkExportedOn.Checked;
            dtpExportedOn.Enabled = chkExportedOn.Checked;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}