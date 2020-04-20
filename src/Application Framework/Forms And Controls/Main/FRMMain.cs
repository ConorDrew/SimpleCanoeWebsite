using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMMain : Form, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMMain() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMMenu_Load;
            base.Closing += FRMMenu_Closing;
            base.KeyDown += FRMMenu_KeyDown;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

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
        private MainMenu _MnuMainNav;

        internal MainMenu MnuMainNav
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MnuMainNav;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MnuMainNav != null)
                {
                }

                _MnuMainNav = value;
                if (_MnuMainNav != null)
                {
                }
            }
        }

        private MenuItem _mnuFile;

        internal MenuItem mnuFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuFile != null)
                {
                }

                _mnuFile = value;
                if (_mnuFile != null)
                {
                }
            }
        }

        private MenuItem _mnuChangeLogin;

        internal MenuItem mnuChangeLogin
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuChangeLogin;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuChangeLogin != null)
                {

                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _mnuChangeLogin.Click -= mnuChangeLogin_Click;
                }

                _mnuChangeLogin = value;
                if (_mnuChangeLogin != null)
                {
                    _mnuChangeLogin.Click += mnuChangeLogin_Click;
                }
            }
        }

        private MenuItem _MenuItem3;

        internal MenuItem MenuItem3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MenuItem3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MenuItem3 != null)
                {
                }

                _MenuItem3 = value;
                if (_MenuItem3 != null)
                {
                }
            }
        }

        private MenuItem _mnuLogout;

        internal MenuItem mnuLogout
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuLogout;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuLogout != null)
                {
                    _mnuLogout.Click -= mnuLogout_Click;
                }

                _mnuLogout = value;
                if (_mnuLogout != null)
                {
                    _mnuLogout.Click += mnuLogout_Click;
                }
            }
        }

        private MenuItem _MenuItem15;

        internal MenuItem MenuItem15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MenuItem15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MenuItem15 != null)
                {
                }

                _MenuItem15 = value;
                if (_MenuItem15 != null)
                {
                }
            }
        }

        private MenuItem _mnuAbout;

        internal MenuItem mnuAbout
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuAbout;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuAbout != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _mnuAbout.Click -= mnuAbout_Click;
                }

                _mnuAbout = value;
                if (_mnuAbout != null)
                {
                    _mnuAbout.Click += mnuAbout_Click;
                }
            }
        }

        private MenuItem _mnuContactSheet;

        internal MenuItem mnuContactSheet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuContactSheet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuContactSheet != null)
                {
                    _mnuContactSheet.Click -= mnuContactSheet_Click;
                }

                _mnuContactSheet = value;
                if (_mnuContactSheet != null)
                {
                    _mnuContactSheet.Click += mnuContactSheet_Click;
                }
            }
        }

        private StatusBar _infoBar;

        internal StatusBar infoBar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _infoBar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_infoBar != null)
                {
                }

                _infoBar = value;
                if (_infoBar != null)
                {
                }
            }
        }

        private MenuItem _mnuSystemHelp;

        internal MenuItem mnuSystemHelp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuSystemHelp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuSystemHelp != null)
                {
                }

                _mnuSystemHelp = value;
                if (_mnuSystemHelp != null)
                {
                }
            }
        }

        private MenuItem _mnuSetup;

        internal MenuItem mnuSetup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuSetup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuSetup != null)
                {
                    _mnuSetup.Click -= mnuSetup_Click;
                }

                _mnuSetup = value;
                if (_mnuSetup != null)
                {
                    _mnuSetup.Click += mnuSetup_Click;
                }
            }
        }

        private MenuItem _mnuReports;

        internal MenuItem mnuReports
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuReports;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuReports != null)
                {
                    _mnuReports.Click -= mnuReports_Click;
                }

                _mnuReports = value;
                if (_mnuReports != null)
                {
                    _mnuReports.Click += mnuReports_Click;
                }
            }
        }

        private Panel _pnlMiddle;

        internal Panel pnlMiddle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlMiddle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlMiddle != null)
                {
                    _pnlMiddle.Resize -= pnlMiddle_Resize;
                }

                _pnlMiddle = value;
                if (_pnlMiddle != null)
                {
                    _pnlMiddle.Resize += pnlMiddle_Resize;
                }
            }
        }

        private Panel _pnlButtons;

        internal Panel pnlButtons
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlButtons;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlButtons != null)
                {
                }

                _pnlButtons = value;
                if (_pnlButtons != null)
                {
                }
            }
        }

        private Panel _pnlMiddleTitle;

        internal Panel pnlMiddleTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlMiddleTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlMiddleTitle != null)
                {
                }

                _pnlMiddleTitle = value;
                if (_pnlMiddleTitle != null)
                {
                }
            }
        }

        private Button _btnCloseMiddle;

        internal Button btnCloseMiddle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCloseMiddle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCloseMiddle != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _btnCloseMiddle.Click -= btnCloseMiddle_Click;
                }

                _btnCloseMiddle = value;
                if (_btnCloseMiddle != null)
                {
                    _btnCloseMiddle.Click += btnCloseMiddle_Click;
                }
            }
        }

        private DataGrid _dgSearchResults;

        internal DataGrid dgSearchResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSearchResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSearchResults != null)
                {
                    _dgSearchResults.Click -= dgSearchResults_Click;
                    _dgSearchResults.CurrentCellChanged -= dgSearchResults_Click;
                    _dgSearchResults.DoubleClick -= dgSearchResults_DoubleClick;
                }

                _dgSearchResults = value;
                if (_dgSearchResults != null)
                {
                    _dgSearchResults.Click += dgSearchResults_Click;
                    _dgSearchResults.CurrentCellChanged += dgSearchResults_Click;
                    _dgSearchResults.DoubleClick += dgSearchResults_DoubleClick;
                }
            }
        }

        private Splitter _splitLeftAndMiddle;

        internal Splitter splitLeftAndMiddle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _splitLeftAndMiddle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_splitLeftAndMiddle != null)
                {
                }

                _splitLeftAndMiddle = value;
                if (_splitLeftAndMiddle != null)
                {
                }
            }
        }

        private Splitter _splitMiddleTop;

        internal Splitter splitMiddleTop
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _splitMiddleTop;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_splitMiddleTop != null)
                {
                }

                _splitMiddleTop = value;
                if (_splitMiddleTop != null)
                {
                }
            }
        }

        private Splitter _splitMiddleBottom;

        internal Splitter splitMiddleBottom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _splitMiddleBottom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_splitMiddleBottom != null)
                {
                }

                _splitMiddleBottom = value;
                if (_splitMiddleBottom != null)
                {
                }
            }
        }

        private Panel _pnlLeft;

        internal Panel pnlLeft
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlLeft;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlLeft != null)
                {
                }

                _pnlLeft = value;
                if (_pnlLeft != null)
                {
                }
            }
        }

        private Label _lblMiddleTitle;

        internal Label lblMiddleTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMiddleTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMiddleTitle != null)
                {
                }

                _lblMiddleTitle = value;
                if (_lblMiddleTitle != null)
                {
                }
            }
        }

        private Button _btnDelete;

        internal Button btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
                }
            }
        }

        private Button _btnAddNew;

        internal Button btnAddNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddNew != null)
                {
                    _btnAddNew.Click -= btnAddNew_Click;
                }

                _btnAddNew = value;
                if (_btnAddNew != null)
                {
                    _btnAddNew.Click += btnAddNew_Click;
                }
            }
        }

        private Panel _pnlRight;

        internal Panel pnlRight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlRight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlRight != null)
                {
                }

                _pnlRight = value;
                if (_pnlRight != null)
                {
                }
            }
        }

        private Panel _pnleHeaderRight;

        internal Panel pnleHeaderRight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnleHeaderRight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnleHeaderRight != null)
                {
                }

                _pnleHeaderRight = value;
                if (_pnleHeaderRight != null)
                {
                }
            }
        }

        private Label _lblRightTitle;

        internal Label lblRightTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRightTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRightTitle != null)
                {
                }

                _lblRightTitle = value;
                if (_lblRightTitle != null)
                {
                }
            }
        }

        private Button _btnCloseRight;

        internal Button btnCloseRight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCloseRight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCloseRight != null)
                {
                    _btnCloseRight.Click -= btnCloseRight_Click;
                }

                _btnCloseRight = value;
                if (_btnCloseRight != null)
                {
                    _btnCloseRight.Click += btnCloseRight_Click;
                }
            }
        }

        private Splitter _Splitter1;

        internal Splitter Splitter1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Splitter1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Splitter1 != null)
                {
                }

                _Splitter1 = value;
                if (_Splitter1 != null)
                {
                }
            }
        }

        private Panel _pnlContent;

        internal Panel pnlContent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlContent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlContent != null)
                {
                }

                _pnlContent = value;
                if (_pnlContent != null)
                {
                }
            }
        }

        private Panel _pnlButtonsRight;

        internal Panel pnlButtonsRight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlButtonsRight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlButtonsRight != null)
                {
                }

                _pnlButtonsRight = value;
                if (_pnlButtonsRight != null)
                {
                }
            }
        }

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private Splitter _Splitter2;

        internal Splitter Splitter2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Splitter2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Splitter2 != null)
                {
                }

                _Splitter2 = value;
                if (_Splitter2 != null)
                {
                }
            }
        }

        private MenuItem _mnuCustomers;

        internal MenuItem mnuCustomers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuCustomers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuCustomers != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _mnuCustomers.Click -= mnuCustomers_Click;
                }

                _mnuCustomers = value;
                if (_mnuCustomers != null)
                {
                    _mnuCustomers.Click += mnuCustomers_Click;
                }
            }
        }

        private MenuItem _mnuSpares;

        internal MenuItem mnuSpares
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuSpares;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuSpares != null)
                {
                    _mnuSpares.Click -= mnuSpares_Click;
                }

                _mnuSpares = value;
                if (_mnuSpares != null)
                {
                    _mnuSpares.Click += mnuSpares_Click;
                }
            }
        }

        private MenuItem _mnuStaff;

        internal MenuItem mnuStaff
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuStaff;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuStaff != null)
                {
                    _mnuStaff.Click -= mnuStaff_Click;
                }

                _mnuStaff = value;
                if (_mnuStaff != null)
                {
                    _mnuStaff.Click += mnuStaff_Click;
                }
            }
        }

        private MenuItem _mnuJobs;

        internal MenuItem mnuJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuJobs != null)
                {
                    _mnuJobs.Click -= mnuJobs_Click;
                }

                _mnuJobs = value;
                if (_mnuJobs != null)
                {
                    _mnuJobs.Click += mnuJobs_Click;
                }
            }
        }

        private MenuItem _mnuInvoicing;

        internal MenuItem mnuInvoicing
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuInvoicing;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuInvoicing != null)
                {
                    _mnuInvoicing.Click -= mnuInvoicing_Click;
                }

                _mnuInvoicing = value;
                if (_mnuInvoicing != null)
                {
                    _mnuInvoicing.Click += mnuInvoicing_Click;
                }
            }
        }

        private MenuItem _mnuScheduler;

        internal MenuItem mnuScheduler
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuScheduler;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuScheduler != null)
                {
                    _mnuScheduler.Click -= mnuScheduler_Click;
                }

                _mnuScheduler = value;
                if (_mnuScheduler != null)
                {
                    _mnuScheduler.Click += mnuScheduler_Click;
                }
            }
        }

        private Button _btnHQ;

        internal Button btnHQ
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnHQ;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnHQ != null)
                {
                    _btnHQ.Click -= btnHQ_Click;
                }

                _btnHQ = value;
                if (_btnHQ != null)
                {
                    _btnHQ.Click += btnHQ_Click;
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

        private MenuItem _mnuVan;

        internal MenuItem mnuVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuVan != null)
                {
                    _mnuVan.Click -= mnuVan_Click;
                }

                _mnuVan = value;
                if (_mnuVan != null)
                {
                    _mnuVan.Click += mnuVan_Click;
                }
            }
        }

        private MenuItem _mnuNpPrint;

        internal MenuItem mnuNpPrint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuNpPrint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuNpPrint != null)
                {
                }

                _mnuNpPrint = value;
                if (_mnuNpPrint != null)
                {
                }
            }
        }

        private MenuItem _mnuUpstairs;

        internal MenuItem mnuUpstairs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuUpstairs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuUpstairs != null)
                {
                    _mnuUpstairs.Click -= mnuUpstairs_Click;
                }

                _mnuUpstairs = value;
                if (_mnuUpstairs != null)
                {
                    _mnuUpstairs.Click += mnuUpstairs_Click;
                }
            }
        }

        private MenuItem _mnuDownstairs;

        internal MenuItem mnuDownstairs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuDownstairs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuDownstairs != null)
                {
                    _mnuDownstairs.Click -= mnuDownstairs_Click;
                }

                _mnuDownstairs = value;
                if (_mnuDownstairs != null)
                {
                    _mnuDownstairs.Click += mnuDownstairs_Click;
                }
            }
        }

        private TableLayoutPanel _ContainerMiddlePanelBtns;

        internal TableLayoutPanel ContainerMiddlePanelBtns
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ContainerMiddlePanelBtns;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ContainerMiddlePanelBtns != null)
                {
                }

                _ContainerMiddlePanelBtns = value;
                if (_ContainerMiddlePanelBtns != null)
                {
                }
            }
        }

        private Splitter _splitMiddleAndRight;

        internal Splitter splitMiddleAndRight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _splitMiddleAndRight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_splitMiddleAndRight != null)
                {
                }

                _splitMiddleAndRight = value;
                if (_splitMiddleAndRight != null)
                {
                }
            }
        }

        private Button _btnGoBack;

        internal Button btnGoBack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGoBack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGoBack != null)
                {
                    _btnGoBack.Click -= btnGoBack_Click;
                }

                _btnGoBack = value;
                if (_btnGoBack != null)
                {
                    _btnGoBack.Click += btnGoBack_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMMain));
            _MnuMainNav = new MainMenu(components);
            _mnuFile = new MenuItem();
            _mnuChangeLogin = new MenuItem();
            _mnuChangeLogin.Click += new EventHandler(mnuChangeLogin_Click);
            _MenuItem3 = new MenuItem();
            _mnuLogout = new MenuItem();
            _mnuLogout.Click += new EventHandler(mnuLogout_Click);
            _mnuCustomers = new MenuItem();
            _mnuCustomers.Click += new EventHandler(mnuCustomers_Click);
            _mnuSpares = new MenuItem();
            _mnuSpares.Click += new EventHandler(mnuSpares_Click);
            _mnuStaff = new MenuItem();
            _mnuStaff.Click += new EventHandler(mnuStaff_Click);
            _mnuJobs = new MenuItem();
            _mnuJobs.Click += new EventHandler(mnuJobs_Click);
            _mnuScheduler = new MenuItem();
            _mnuScheduler.Click += new EventHandler(mnuScheduler_Click);
            _mnuInvoicing = new MenuItem();
            _mnuInvoicing.Click += new EventHandler(mnuInvoicing_Click);
            _mnuReports = new MenuItem();
            _mnuReports.Click += new EventHandler(mnuReports_Click);
            _mnuVan = new MenuItem();
            _mnuVan.Click += new EventHandler(mnuVan_Click);
            _mnuSetup = new MenuItem();
            _mnuSetup.Click += new EventHandler(mnuSetup_Click);
            _mnuSystemHelp = new MenuItem();
            _mnuContactSheet = new MenuItem();
            _mnuContactSheet.Click += new EventHandler(mnuContactSheet_Click);
            _MenuItem15 = new MenuItem();
            _mnuAbout = new MenuItem();
            _mnuAbout.Click += new EventHandler(mnuAbout_Click);
            _mnuNpPrint = new MenuItem();
            _mnuUpstairs = new MenuItem();
            _mnuUpstairs.Click += new EventHandler(mnuUpstairs_Click);
            _mnuDownstairs = new MenuItem();
            _mnuDownstairs.Click += new EventHandler(mnuDownstairs_Click);
            _infoBar = new StatusBar();
            _pnlLeft = new Panel();
            _splitLeftAndMiddle = new Splitter();
            _pnlMiddle = new Panel();
            _pnlMiddle.Resize += new EventHandler(pnlMiddle_Resize);
            _dgSearchResults = new DataGrid();
            _dgSearchResults.Click += new EventHandler(dgSearchResults_Click);
            _dgSearchResults.CurrentCellChanged += new EventHandler(dgSearchResults_Click);
            _dgSearchResults.Click += new EventHandler(dgSearchResults_Click);
            _dgSearchResults.CurrentCellChanged += new EventHandler(dgSearchResults_Click);
            _dgSearchResults.DoubleClick += new EventHandler(dgSearchResults_DoubleClick);
            _splitMiddleTop = new Splitter();
            _pnlMiddleTitle = new Panel();
            _btnCloseMiddle = new Button();
            _btnCloseMiddle.Click += new EventHandler(btnCloseMiddle_Click);
            _lblMiddleTitle = new Label();
            _splitMiddleBottom = new Splitter();
            _pnlButtons = new Panel();
            _ContainerMiddlePanelBtns = new TableLayoutPanel();
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _pnlRight = new Panel();
            _Splitter2 = new Splitter();
            _pnlContent = new Panel();
            _Splitter1 = new Splitter();
            _pnleHeaderRight = new Panel();
            _btnHQ = new Button();
            _btnHQ.Click += new EventHandler(btnHQ_Click);
            _btnCloseRight = new Button();
            _btnCloseRight.Click += new EventHandler(btnCloseRight_Click);
            _lblRightTitle = new Label();
            _pnlButtonsRight = new Panel();
            _btnGoBack = new Button();
            _btnGoBack.Click += new EventHandler(btnGoBack_Click);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _splitMiddleAndRight = new Splitter();
            _pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSearchResults).BeginInit();
            _pnlMiddleTitle.SuspendLayout();
            _pnlButtons.SuspendLayout();
            _ContainerMiddlePanelBtns.SuspendLayout();
            _pnlRight.SuspendLayout();
            _pnleHeaderRight.SuspendLayout();
            _pnlButtonsRight.SuspendLayout();
            SuspendLayout();
            // 
            // MnuMainNav
            // 
            _MnuMainNav.MenuItems.AddRange(new MenuItem[] { _mnuFile, _mnuCustomers, _mnuSpares, _mnuStaff, _mnuJobs, _mnuScheduler, _mnuInvoicing, _mnuReports, _mnuVan, _mnuSetup, _mnuSystemHelp, _mnuNpPrint });
            // 
            // mnuFile
            // 
            _mnuFile.Index = 0;
            _mnuFile.MenuItems.AddRange(new MenuItem[] { _mnuChangeLogin, _MenuItem3, _mnuLogout });
            resources.ApplyResources(_mnuFile, "mnuFile");
            // 
            // mnuChangeLogin
            // 
            _mnuChangeLogin.Index = 0;
            resources.ApplyResources(_mnuChangeLogin, "mnuChangeLogin");
            // 
            // MenuItem3
            // 
            _MenuItem3.Index = 1;
            resources.ApplyResources(_MenuItem3, "MenuItem3");
            // 
            // mnuLogout
            // 
            _mnuLogout.Index = 2;
            resources.ApplyResources(_mnuLogout, "mnuLogout");
            // 
            // mnuCustomers
            // 
            _mnuCustomers.Index = 1;
            resources.ApplyResources(_mnuCustomers, "mnuCustomers");
            // 
            // mnuSpares
            // 
            _mnuSpares.Index = 2;
            resources.ApplyResources(_mnuSpares, "mnuSpares");
            // 
            // mnuStaff
            // 
            _mnuStaff.Index = 3;
            resources.ApplyResources(_mnuStaff, "mnuStaff");
            // 
            // mnuJobs
            // 
            _mnuJobs.Index = 4;
            resources.ApplyResources(_mnuJobs, "mnuJobs");
            // 
            // mnuScheduler
            // 
            _mnuScheduler.Index = 5;
            resources.ApplyResources(_mnuScheduler, "mnuScheduler");
            // 
            // mnuInvoicing
            // 
            _mnuInvoicing.Index = 6;
            resources.ApplyResources(_mnuInvoicing, "mnuInvoicing");
            // 
            // mnuReports
            // 
            _mnuReports.Index = 7;
            resources.ApplyResources(_mnuReports, "mnuReports");
            // 
            // mnuVan
            // 
            _mnuVan.Index = 8;
            resources.ApplyResources(_mnuVan, "mnuVan");
            // 
            // mnuSetup
            // 
            _mnuSetup.Index = 9;
            resources.ApplyResources(_mnuSetup, "mnuSetup");
            // 
            // mnuSystemHelp
            // 
            _mnuSystemHelp.Index = 10;
            _mnuSystemHelp.MenuItems.AddRange(new MenuItem[] { _mnuContactSheet, _MenuItem15, _mnuAbout });
            resources.ApplyResources(_mnuSystemHelp, "mnuSystemHelp");
            // 
            // mnuContactSheet
            // 
            _mnuContactSheet.Index = 0;
            resources.ApplyResources(_mnuContactSheet, "mnuContactSheet");
            // 
            // MenuItem15
            // 
            _MenuItem15.Index = 1;
            resources.ApplyResources(_MenuItem15, "MenuItem15");
            // 
            // mnuAbout
            // 
            _mnuAbout.Index = 2;
            resources.ApplyResources(_mnuAbout, "mnuAbout");
            // 
            // mnuNpPrint
            // 
            _mnuNpPrint.Index = 11;
            _mnuNpPrint.MenuItems.AddRange(new MenuItem[] { _mnuUpstairs, _mnuDownstairs });
            resources.ApplyResources(_mnuNpPrint, "mnuNpPrint");
            // 
            // mnuUpstairs
            // 
            _mnuUpstairs.Index = 0;
            resources.ApplyResources(_mnuUpstairs, "mnuUpstairs");
            // 
            // mnuDownstairs
            // 
            _mnuDownstairs.Index = 1;
            resources.ApplyResources(_mnuDownstairs, "mnuDownstairs");
            // 
            // infoBar
            // 
            resources.ApplyResources(_infoBar, "infoBar");
            _infoBar.Name = "infoBar";
            _infoBar.SizingGrip = false;
            // 
            // pnlLeft
            // 
            _pnlLeft.BackColor = Color.White;
            resources.ApplyResources(_pnlLeft, "pnlLeft");
            _pnlLeft.Name = "pnlLeft";
            // 
            // splitLeftAndMiddle
            // 
            _splitLeftAndMiddle.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(244)), Conversions.ToInteger(Conversions.ToByte(244)), Conversions.ToInteger(Conversions.ToByte(244)));
            resources.ApplyResources(_splitLeftAndMiddle, "splitLeftAndMiddle");
            _splitLeftAndMiddle.Name = "splitLeftAndMiddle";
            _splitLeftAndMiddle.TabStop = false;
            // 
            // pnlMiddle
            // 
            _pnlMiddle.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            _pnlMiddle.Controls.Add(_dgSearchResults);
            _pnlMiddle.Controls.Add(_splitMiddleTop);
            _pnlMiddle.Controls.Add(_pnlMiddleTitle);
            _pnlMiddle.Controls.Add(_splitMiddleBottom);
            _pnlMiddle.Controls.Add(_pnlButtons);
            resources.ApplyResources(_pnlMiddle, "pnlMiddle");
            _pnlMiddle.Name = "pnlMiddle";
            // 
            // dgSearchResults
            // 
            _dgSearchResults.DataMember = "";
            resources.ApplyResources(_dgSearchResults, "dgSearchResults");
            _dgSearchResults.HeaderForeColor = SystemColors.ControlText;
            _dgSearchResults.Name = "dgSearchResults";
            // 
            // splitMiddleTop
            // 
            _splitMiddleTop.BackColor = Color.Silver;
            resources.ApplyResources(_splitMiddleTop, "splitMiddleTop");
            _splitMiddleTop.Name = "splitMiddleTop";
            _splitMiddleTop.TabStop = false;
            // 
            // pnlMiddleTitle
            // 
            resources.ApplyResources(_pnlMiddleTitle, "pnlMiddleTitle");
            _pnlMiddleTitle.Controls.Add(_btnCloseMiddle);
            _pnlMiddleTitle.Controls.Add(_lblMiddleTitle);
            _pnlMiddleTitle.Name = "pnlMiddleTitle";
            // 
            // btnCloseMiddle
            // 
            resources.ApplyResources(_btnCloseMiddle, "btnCloseMiddle");
            _btnCloseMiddle.Cursor = Cursors.Hand;
            _btnCloseMiddle.Name = "btnCloseMiddle";
            // 
            // lblMiddleTitle
            // 
            _lblMiddleTitle.BackColor = Color.Transparent;
            resources.ApplyResources(_lblMiddleTitle, "lblMiddleTitle");
            _lblMiddleTitle.ForeColor = Color.White;
            _lblMiddleTitle.Name = "lblMiddleTitle";
            // 
            // splitMiddleBottom
            // 
            _splitMiddleBottom.BackColor = Color.Silver;
            resources.ApplyResources(_splitMiddleBottom, "splitMiddleBottom");
            _splitMiddleBottom.Name = "splitMiddleBottom";
            _splitMiddleBottom.TabStop = false;
            // 
            // pnlButtons
            // 
            _pnlButtons.BackColor = Color.White;
            _pnlButtons.Controls.Add(_ContainerMiddlePanelBtns);
            resources.ApplyResources(_pnlButtons, "pnlButtons");
            _pnlButtons.Name = "pnlButtons";
            // 
            // ContainerMiddlePanelBtns
            // 
            resources.ApplyResources(_ContainerMiddlePanelBtns, "ContainerMiddlePanelBtns");
            _ContainerMiddlePanelBtns.Controls.Add(_btnExport, 2, 0);
            _ContainerMiddlePanelBtns.Controls.Add(_btnAddNew, 0, 0);
            _ContainerMiddlePanelBtns.Controls.Add(_btnDelete, 1, 0);
            _ContainerMiddlePanelBtns.Name = "ContainerMiddlePanelBtns";
            // 
            // btnExport
            // 
            resources.ApplyResources(_btnExport, "btnExport");
            _btnExport.BackColor = SystemColors.Control;
            _btnExport.Cursor = Cursors.Hand;
            _btnExport.Name = "btnExport";
            _btnExport.UseVisualStyleBackColor = false;
            // 
            // btnAddNew
            // 
            resources.ApplyResources(_btnAddNew, "btnAddNew");
            _btnAddNew.BackColor = SystemColors.Control;
            _btnAddNew.Cursor = Cursors.Hand;
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            resources.ApplyResources(_btnDelete, "btnDelete");
            _btnDelete.BackColor = SystemColors.Control;
            _btnDelete.Cursor = Cursors.Hand;
            _btnDelete.Name = "btnDelete";
            _btnDelete.UseVisualStyleBackColor = false;
            // 
            // pnlRight
            // 
            resources.ApplyResources(_pnlRight, "pnlRight");
            _pnlRight.BackColor = Color.White;
            _pnlRight.Controls.Add(_Splitter2);
            _pnlRight.Controls.Add(_pnlContent);
            _pnlRight.Controls.Add(_Splitter1);
            _pnlRight.Controls.Add(_pnleHeaderRight);
            _pnlRight.Controls.Add(_pnlButtonsRight);
            _pnlRight.Name = "pnlRight";
            // 
            // Splitter2
            // 
            _Splitter2.BackColor = Color.Silver;
            resources.ApplyResources(_Splitter2, "Splitter2");
            _Splitter2.Name = "Splitter2";
            _Splitter2.TabStop = false;
            // 
            // pnlContent
            // 
            _pnlContent.BackColor = Color.Transparent;
            resources.ApplyResources(_pnlContent, "pnlContent");
            _pnlContent.Name = "pnlContent";
            // 
            // Splitter1
            // 
            _Splitter1.BackColor = Color.Silver;
            resources.ApplyResources(_Splitter1, "Splitter1");
            _Splitter1.Name = "Splitter1";
            _Splitter1.TabStop = false;
            // 
            // pnleHeaderRight
            // 
            resources.ApplyResources(_pnleHeaderRight, "pnleHeaderRight");
            _pnleHeaderRight.Controls.Add(_btnHQ);
            _pnleHeaderRight.Controls.Add(_btnCloseRight);
            _pnleHeaderRight.Controls.Add(_lblRightTitle);
            _pnleHeaderRight.Name = "pnleHeaderRight";
            // 
            // btnHQ
            // 
            resources.ApplyResources(_btnHQ, "btnHQ");
            _btnHQ.Cursor = Cursors.Hand;
            _btnHQ.Name = "btnHQ";
            // 
            // btnCloseRight
            // 
            resources.ApplyResources(_btnCloseRight, "btnCloseRight");
            _btnCloseRight.Cursor = Cursors.Hand;
            _btnCloseRight.Name = "btnCloseRight";
            // 
            // lblRightTitle
            // 
            _lblRightTitle.BackColor = Color.Transparent;
            resources.ApplyResources(_lblRightTitle, "lblRightTitle");
            _lblRightTitle.ForeColor = Color.White;
            _lblRightTitle.Name = "lblRightTitle";
            // 
            // pnlButtonsRight
            // 
            _pnlButtonsRight.BackColor = Color.White;
            _pnlButtonsRight.Controls.Add(_btnGoBack);
            _pnlButtonsRight.Controls.Add(_btnSave);
            resources.ApplyResources(_pnlButtonsRight, "pnlButtonsRight");
            _pnlButtonsRight.Name = "pnlButtonsRight";
            // 
            // btnGoBack
            // 
            _btnGoBack.BackColor = SystemColors.Control;
            resources.ApplyResources(_btnGoBack, "btnGoBack");
            _btnGoBack.Name = "btnGoBack";
            _btnGoBack.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            resources.ApplyResources(_btnSave, "btnSave");
            _btnSave.BackColor = SystemColors.Control;
            _btnSave.Cursor = Cursors.Hand;
            _btnSave.Name = "btnSave";
            _btnSave.UseVisualStyleBackColor = false;
            // 
            // splitMiddleAndRight
            // 
            resources.ApplyResources(_splitMiddleAndRight, "splitMiddleAndRight");
            _splitMiddleAndRight.Name = "splitMiddleAndRight";
            _splitMiddleAndRight.TabStop = false;
            // 
            // FRMMain
            // 
            resources.ApplyResources(this, "$this");
            BackColor = Color.Gainsboro;
            Controls.Add(_splitMiddleAndRight);
            Controls.Add(_pnlRight);
            Controls.Add(_pnlMiddle);
            Controls.Add(_splitLeftAndMiddle);
            Controls.Add(_pnlLeft);
            Controls.Add(_infoBar);
            IsMdiContainer = true;
            Menu = _MnuMainNav;
            Name = "FRMMain";
            ShowIcon = false;
            WindowState = FormWindowState.Maximized;
            _pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSearchResults).EndInit();
            _pnlMiddleTitle.ResumeLayout(false);
            _pnlButtons.ResumeLayout(false);
            _ContainerMiddlePanelBtns.ResumeLayout(false);
            _pnlRight.ResumeLayout(false);
            _pnleHeaderRight.ResumeLayout(false);
            _pnlButtonsRight.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            var menu = new UCSideBar();
            menu.Dock = DockStyle.Fill;
            pnlLeft.Controls.Add(menu);
            _FormButtons = new ArrayList();
            LoopControls(this);
            SetupButtonMouseOvers();
            UpdateMessage();
            mnuNpPrint.Visible = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.NeopostPrint);
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
        private ArrayList _FormButtons = null;

        public ArrayList FormButtons
        {
            get
            {
                return _FormButtons;
            }

            set
            {
                _FormButtons = value;
            }
        }

        public UCSideBar MenuBar
        {
            get
            {
                return (UCSideBar)pnlLeft.Controls[0];
            }
        }

        private Enums.MenuTypes _SelectedMenu = Enums.MenuTypes.NONE;

        public Enums.MenuTypes SelectedMenu
        {
            get
            {
                return _SelectedMenu;
            }

            set
            {
                _SelectedMenu = value;
            }
        }

        private Enums.PageViewing _Page = Enums.PageViewing.NONE;

        public Enums.PageViewing Page
        {
            get
            {
                return _Page;
            }

            set
            {
                _Page = value;
            }
        }

        private DataView _dvSearchResults;

        private DataView SearchResults
        {
            get
            {
                return _dvSearchResults;
            }

            set
            {
                _dvSearchResults = value;
                _dvSearchResults.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
                _dvSearchResults.AllowNew = false;
                _dvSearchResults.AllowEdit = false;
                _dvSearchResults.AllowDelete = false;
                dgSearchResults.DataSource = SearchResults;
            }
        }

        private DataRow SelectedSearchResultDataRow
        {
            get
            {
                if (!(dgSearchResults.CurrentRowIndex == -1))
                {
                    return SearchResults[dgSearchResults.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private bool _Exporting = false;

        private bool Exporting
        {
            get
            {
                return _Exporting;
            }

            set
            {
                _Exporting = value;
            }
        }

        private string _SearchText = string.Empty;

        public string SearchText
        {
            get
            {
                return _SearchText;
            }

            set
            {
                _SearchText = value;
            }
        }

        private void FRMMenu_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void FRMMenu_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            App.Logout();
        }

        private void FRMMenu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    App.Logout();
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Action cannot be completed : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuChangeLogin_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.NONE);
            App.ShowForm(typeof(FRMChangePassword), false, null);
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.NONE);
            App.Logout();
        }

        private void mnuCustomers_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.Customers);
        }

        private void mnuSpares_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.Spares);
        }

        private void mnuStaff_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.Staff);
        }

        private void mnuJobs_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.Jobs);
        }

        private void mnuScheduler_Click(object sender, EventArgs e)
        {
            var schedulerMain = new frmSchedulerMain();
            schedulerMain.Show();
        }

        private void mnuInvoicing_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.Invoicing);
        }

        private void mnuReports_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.Reports);
        }

        private void mnuVan_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.FleetVan);
        }

        private void mnuSetup_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.Setup);
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.NONE);
            App.ShowForm(typeof(FRMAbout), false, null);
        }

        private void mnuContactSheet_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.NONE);
            App.ShowForm(typeof(FRMContactDetails), false, null);
        }

        private void btnCloseMiddle_Click(object sender, EventArgs e)
        {
            Navigation.Close_Middle();
            App.CurrentCustomerID = 0;
            App.CurrentPropertyID = 0;
        }

        private void btnCloseRight_Click(object sender, EventArgs e)
        {
            Navigation.Close_Right();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void dgSearchResults_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            View();
            Cursor = Cursors.Default;
        }

        private void dgSearchResults_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Open();
            Cursor = Cursors.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            if (Page == Enums.PageViewing.Asset)
            {
                int assetsPropertyID = ((Entity.Assets.Asset)((IUserControl)pnlContent.Controls[0]).LoadedItem).PropertyID;
                SetSearchResults(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, false, false);
                SearchResults.RowFilter = "SiteID =" + assetsPropertyID;
                dgSearchResults.Select(0);
                dgSearchResults_Click(sender, e);
            }
            else if (Page == Enums.PageViewing.Property)
            {
                int PropertyCustID = ((Entity.Sites.Site)((IUserControl)pnlContent.Controls[0]).LoadedItem).CustomerID;
                SetSearchResults(App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID), Enums.PageViewing.Customer, false, false);
                SearchResults.RowFilter = "CustomerID =" + PropertyCustID;
                dgSearchResults.Select(0);
                dgSearchResults_Click(sender, e);
            }
            else
            {
                btnGoBack.Visible = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var switchExpr = Page;
            switch (switchExpr)
            {
                case Enums.PageViewing.Engineer:
                    {
                        var exportData = new DataTable();
                        exportData.Columns.Add("Name");
                        exportData.Columns.Add("Department");
                        exportData.Columns.Add("EngineerID");
                        exportData.Columns.Add("Region");
                        exportData.Columns.Add("TelephoneNum");
                        exportData.Columns.Add("Technician");
                        exportData.Columns.Add("Supervisor");
                        foreach (DataRowView dr in (DataView)dgSearchResults.DataSource)
                        {
                            var newRw = exportData.NewRow();
                            newRw["Name"] = dr["Name"];
                            newRw["Department"] = dr["Department"];
                            newRw["EngineerID"] = dr["EngineerID"];
                            newRw["Region"] = dr["Region"];
                            newRw["TelephoneNum"] = dr["TelephoneNum"];
                            newRw["Technician"] = dr["Technician"];
                            newRw["Supervisor"] = dr["Supervisor"];
                            exportData.Rows.Add(newRw);
                        }

                        ExportHelper.Export(exportData, "Engineers", Enums.ExportType.XLS);
                        break;
                    }

                case Enums.PageViewing.Property:
                    {
                        Exporting = true;
                        var exportData = new DataTable();
                        exportData.Columns.Add("Customer");
                        exportData.Columns.Add("Name");
                        exportData.Columns.Add("Address 1");
                        exportData.Columns.Add("Address 2");
                        exportData.Columns.Add("Address 3");
                        exportData.Columns.Add("Postcode");
                        exportData.Columns.Add("Telephone");
                        exportData.Columns.Add("Mobile");
                        exportData.Columns.Add("Email");
                        exportData.Columns.Add("Date added to system", Type.GetType("System.DateTime"));
                        exportData.Columns.Add("SiteFuel");
                        exportData.Columns.Add("PolicyNumber");
                        exportData.Columns.Add("LastServiceDate");
                        foreach (DataRowView dr in (DataView)dgSearchResults.DataSource)
                        {
                            var newRw = exportData.NewRow();
                            newRw["Customer"] = dr["CustomerName"];
                            newRw["Name"] = dr["Name"];
                            newRw["Address 1"] = dr["Address1"];
                            newRw["Address 2"] = dr["Address2"];
                            newRw["Address 3"] = dr["Address3"];
                            newRw["Postcode"] = dr["Postcode"];
                            newRw["Telephone"] = dr["TelephoneNum"];
                            newRw["Mobile"] = dr["FaxNum"];
                            newRw["Email"] = dr["EmailAddress"];
                            newRw["Date added to system"] = Conversions.ToDate(Strings.Format(dr["SiteAddedOnDateTime"], "dd/MM/yyyy"));
                            newRw["SiteFuel"] = dr["SiteFuel"];
                            newRw["PolicyNumber"] = dr["PolicyNumber"];
                            newRw["LastServiceDate"] = dr["LastServiceDate"];
                            exportData.Rows.Add(newRw);
                        }

                        ExportHelper.Export(exportData, "Properties", Enums.ExportType.XLS);
                        Exporting = false;
                        break;
                    }

                case Enums.PageViewing.FleetVan:
                    {
                        var dv = App.DB.FleetVan.GetAll();
                        ExportHelper.Export(dv.Table, "Fleet Vans", Enums.ExportType.XLS);
                        break;
                    }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoopControls(Control controlToLoop)
        {
            foreach (Control control in controlToLoop.Controls)
            {
                if ((control.GetType().Name ?? "") == "TabControl")
                {
                    LoopControls(control);
                }
                else if ((control.GetType().Name ?? "") == "TabPage")
                {
                    ((TabPage)control).BackColor = Color.White;
                    LoopControls(control);
                }
                else if ((control.GetType().Name ?? "") == "GroupBox")
                {
                    ((GroupBox)control).FlatStyle = FlatStyle.System;
                    LoopControls(control);
                }
                else if ((control.GetType().Name ?? "") == "Panel")
                {
                    LoopControls(control);
                }
                else if ((control.GetType().Name ?? "") == "Button")
                {
                    ((Button)control).FlatStyle = FlatStyle.Standard;
                    ((Button)control).Cursor = Cursors.Hand;
                    ((Button)control).UseVisualStyleBackColor = false;
                    ((Button)control).BackColor = SystemColors.Control;
                    ((Button)control).AccessibleDescription = ((Button)control).Text;
                    FormButtons.Add(control);
                }
                else if ((control.GetType().Name ?? "") == "ComboBox")
                {
                    ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
                    ((ComboBox)control).Cursor = Cursors.Hand;
                }
                else if ((control.GetType().Name ?? "") == "CheckBox")
                {
                    ((CheckBox)control).FlatStyle = FlatStyle.System;
                    ((CheckBox)control).Cursor = Cursors.Hand;
                }
                else if ((control.GetType().Name ?? "") == "NumericUpDown")
                {
                    ((NumericUpDown)control).Cursor = Cursors.Hand;
                }
                else if ((control.GetType().Name ?? "") == "DataGrid")
                {
                    Helper.SetUpDataGrid((DataGrid)control);
                    var tStyle = ((DataGrid)control).TableStyles[0];
                    tStyle.ReadOnly = true;
                    tStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
                    ((DataGrid)control).TableStyles.Add(tStyle);
                }
                else if ((control.GetType().Name ?? "") == "UCButton")
                {
                    ((Button)control).FlatStyle = FlatStyle.Standard;
                    ((Button)control).Cursor = Cursors.Hand;
                    ((Button)control).UseVisualStyleBackColor = false;
                    ((Button)control).BackColor = SystemColors.Control;
                    ((Button)control).AccessibleDescription = ((Button)control).Text;
                    FormButtons.Add(control);
                }
                else if (control.GetType().IsSubclassOf(typeof(UCBase)))
                {
                    LoopControls((UCBase)control);
                }
            }
        }

        private void SetupButtonMouseOvers()
        {
            foreach (object btn in FormButtons)
                ((Button)btn).MouseHover += CreateHover;
        }

        private void CreateHover(object sender, EventArgs e)
        {
            Button argbtn = (Button)sender;
            Helper.Setup_Button(ref argbtn, ((Button)sender).AccessibleDescription);
        }

        public void SetSearchResults(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete = false, string ExtraText = "")
        {
            SetupSearchResultsDataGrid(dv, pageIn, FromASave, FromADelete, ExtraText);
        }

        public void UpdateMessage()
        {
            Text = App.TheSystem.Configuration.CompanyName + " " + Text + " v." + App.TheSystem.Configuration.SystemVersion;
            infoBar.Text = "Welcome " + App.loggedInUser.Fullname + ". " + App.DB.User.LastLogon(App.loggedInUser.UserID);
            var switchExpr = App.TheSystem.Configuration.DBName;
            switch (switchExpr)
            {
                case Enums.DataBaseName.RftFsm_Beta:
                case Enums.DataBaseName.GaswayServicesFSM_Beta:
                case Enums.DataBaseName.BlueflameServicesFsm_Beta:
                    {
                        infoBar.Text += " THIS IS THE BETA DATABASE";
                        if (pnlLeft.Controls.Count > 0)
                        {
                            foreach (UCSideBar pnlLeft in pnlLeft.Controls)
                                pnlLeft.BackColor = Color.LightGoldenrodYellow;
                        }

                        break;
                    }
            }
        }

        private void SetupSearchResultsDataGrid(DataView dv, Enums.PageViewing pageIn, bool FromASave = true, bool FromADelete = false, string ExtraText = "")
        {
            if (FromASave)
            {
                pnlRight.Visible = true;
            }
            else if (FromADelete)
            {
                App.MainForm.pnlRight.Visible = false;
                App.MainForm.pnlContent.Controls.Clear();
            }
            else if (!Navigation.Close_Right())
            {
                return;
            }

            Page = pageIn;
            var tStyle = dgSearchResults.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            btnAddNew.Enabled = true;
            btnDelete.Visible = true;
            btnAddNew.Visible = true;
            btnGoBack.Visible = false;
            btnExport.Visible = false;
            btnHQ.Visible = false;
            var switchExpr = Page;
            switch (switchExpr)
            {
                case Enums.PageViewing.Customer:
                    {
                        var CustomerName = new DataGridLabelColumn();
                        CustomerName.Format = "";
                        CustomerName.FormatInfo = null;
                        CustomerName.HeaderText = "Name";
                        CustomerName.MappingName = "Name";
                        CustomerName.ReadOnly = true;
                        CustomerName.Width = 200;
                        CustomerName.NullText = "";
                        tStyle.GridColumnStyles.Add(CustomerName);
                        var AccountNumber = new DataGridLabelColumn();
                        AccountNumber.Format = "";
                        AccountNumber.FormatInfo = null;
                        AccountNumber.HeaderText = "Account Number";
                        AccountNumber.MappingName = "AccountNumber";
                        AccountNumber.ReadOnly = true;
                        AccountNumber.Width = 140;
                        AccountNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(AccountNumber);
                        var Region = new DataGridLabelColumn();
                        Region.Format = "";
                        Region.FormatInfo = null;
                        Region.HeaderText = "Region";
                        Region.MappingName = "Region";
                        Region.ReadOnly = true;
                        Region.Width = 140;
                        Region.NullText = "";
                        tStyle.GridColumnStyles.Add(Region);
                        lblMiddleTitle.Text = "Customers";
                        break;
                    }

                case Enums.PageViewing.Property:
                    {
                        btnHQ.Visible = true;
                        btnGoBack.Text = "Go to Customer";
                        btnGoBack.Visible = true;
                        btnExport.Visible = false;
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 100;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Address1 = new DataGridLabelColumn();
                        Address1.Format = "";
                        Address1.FormatInfo = null;
                        Address1.HeaderText = "Address 1";
                        Address1.MappingName = "Address1";
                        Address1.ReadOnly = true;
                        Address1.Width = 100;
                        Address1.NullText = "";
                        tStyle.GridColumnStyles.Add(Address1);
                        var Address2 = new DataGridLabelColumn();
                        Address2.Format = "";
                        Address2.FormatInfo = null;
                        Address2.HeaderText = "Address 2";
                        Address2.MappingName = "Address2";
                        Address2.ReadOnly = true;
                        Address2.Width = 100;
                        Address2.NullText = "";
                        tStyle.GridColumnStyles.Add(Address2);
                        var Postcode = new DataGridLabelColumn();
                        Postcode.Format = "";
                        Postcode.FormatInfo = null;
                        Postcode.HeaderText = "Postcode";
                        Postcode.MappingName = "Postcode";
                        Postcode.ReadOnly = true;
                        Postcode.Width = 75;
                        Postcode.NullText = "";
                        tStyle.GridColumnStyles.Add(Postcode);
                        var HeadOffice = new DataGridLabelColumn();
                        HeadOffice.Format = "";
                        HeadOffice.FormatInfo = null;
                        HeadOffice.HeaderText = "HO";
                        HeadOffice.MappingName = "HeadOfficeResult";
                        HeadOffice.ReadOnly = true;
                        HeadOffice.Width = 75;
                        HeadOffice.NullText = "";
                        tStyle.GridColumnStyles.Add(HeadOffice);
                        var Region = new DataGridLabelColumn();
                        Region.Format = "";
                        Region.FormatInfo = null;
                        Region.HeaderText = "Region";
                        Region.MappingName = "Region";
                        Region.ReadOnly = true;
                        Region.Width = 100;
                        Region.NullText = "";
                        tStyle.GridColumnStyles.Add(Region);
                        var SiteFuel = new DataGridLabelColumn();
                        SiteFuel.Format = "";
                        SiteFuel.FormatInfo = null;
                        SiteFuel.HeaderText = "SiteFuel";
                        SiteFuel.MappingName = "SiteFuel";
                        SiteFuel.ReadOnly = true;
                        SiteFuel.Width = 100;
                        SiteFuel.NullText = "";
                        tStyle.GridColumnStyles.Add(SiteFuel);
                        var PolicyNumber = new DataGridLabelColumn();
                        PolicyNumber.Format = "";
                        PolicyNumber.FormatInfo = null;
                        PolicyNumber.HeaderText = "PolicyNumber";
                        PolicyNumber.MappingName = "PolicyNumber";
                        PolicyNumber.ReadOnly = true;
                        PolicyNumber.Width = 100;
                        PolicyNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(PolicyNumber);
                        var LastServiceDate = new DataGridLabelColumn();
                        LastServiceDate.Format = "";
                        LastServiceDate.FormatInfo = null;
                        LastServiceDate.HeaderText = "Last Service Date";
                        LastServiceDate.MappingName = "LastServiceDate";
                        LastServiceDate.ReadOnly = true;
                        LastServiceDate.Width = 100;
                        LastServiceDate.NullText = "";
                        tStyle.GridColumnStyles.Add(LastServiceDate);
                        if (ExtraText.Trim().Length > 0)
                        {
                            lblMiddleTitle.Text = "Properties For " + ExtraText;
                        }
                        else
                        {
                            lblMiddleTitle.Text = "Properties";
                        }

                        break;
                    }

                case Enums.PageViewing.Asset:
                    {
                        btnGoBack.Text = "Go to Property";
                        btnGoBack.Visible = true;
                        var Product = new DataGridLabelColumn();
                        Product.Format = "";
                        Product.FormatInfo = null;
                        Product.HeaderText = "Product";
                        Product.MappingName = "Product";
                        Product.ReadOnly = true;
                        Product.Width = 150;
                        Product.NullText = "";
                        tStyle.GridColumnStyles.Add(Product);
                        var Location = new DataGridLabelColumn();
                        Location.Format = "";
                        Location.FormatInfo = null;
                        Location.HeaderText = "Location";
                        Location.MappingName = "Location";
                        Location.ReadOnly = true;
                        Location.Width = 100;
                        Location.NullText = "";
                        tStyle.GridColumnStyles.Add(Location);
                        var SerialNum = new DataGridLabelColumn();
                        SerialNum.Format = "";
                        SerialNum.FormatInfo = null;
                        SerialNum.HeaderText = "Serial";
                        SerialNum.MappingName = "SerialNum";
                        SerialNum.ReadOnly = true;
                        SerialNum.Width = 150;
                        SerialNum.NullText = "";
                        tStyle.GridColumnStyles.Add(SerialNum);
                        if (ExtraText.Trim().Length > 0)
                        {
                            lblMiddleTitle.Text = "Appliances For " + ExtraText;
                        }
                        else
                        {
                            lblMiddleTitle.Text = "Appliances";
                        }

                        if (App.ViewingAllAssets)
                        {
                            btnAddNew.Enabled = false;
                        }

                        break;
                    }

                case Enums.PageViewing.Part:
                    {
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
                        PartNumber.HeaderText = "Number (MPN)";
                        PartNumber.MappingName = "Number";
                        PartNumber.ReadOnly = true;
                        PartNumber.Width = 130;
                        PartNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(PartNumber);
                        var PartReference = new DataGridLabelColumn();
                        PartReference.Format = "";
                        PartReference.FormatInfo = null;
                        PartReference.HeaderText = "Reference";
                        PartReference.MappingName = "Reference";
                        PartReference.ReadOnly = true;
                        PartReference.Width = 130;
                        PartReference.NullText = "";
                        tStyle.GridColumnStyles.Add(PartReference);
                        var Quantity = new DataGridLabelColumn();
                        Quantity.Format = "";
                        Quantity.FormatInfo = null;
                        Quantity.HeaderText = "Qty";
                        Quantity.MappingName = "WarehouseQuantity";
                        Quantity.ReadOnly = true;
                        Quantity.Width = 50;
                        Quantity.NullText = "";
                        tStyle.GridColumnStyles.Add(Quantity);
                        var UnitType = new DataGridLabelColumn();
                        UnitType.Format = "";
                        UnitType.FormatInfo = null;
                        UnitType.HeaderText = "Unit Type";
                        UnitType.MappingName = "UnitType";
                        UnitType.ReadOnly = true;
                        UnitType.Width = 130;
                        UnitType.NullText = "";
                        tStyle.GridColumnStyles.Add(UnitType);
                        var SellPrice = new DataGridLabelColumn();
                        SellPrice.Format = "C";
                        SellPrice.FormatInfo = null;
                        SellPrice.HeaderText = "Sell Price";
                        SellPrice.MappingName = "SellPrice";
                        SellPrice.ReadOnly = true;
                        SellPrice.Width = 120;
                        SellPrice.NullText = "";
                        tStyle.GridColumnStyles.Add(SellPrice);
                        lblMiddleTitle.Text = "Parts";
                        break;
                    }

                case Enums.PageViewing.PartPack:
                    {
                        var PartName = new DataGridLabelColumn();
                        PartName.Format = "";
                        PartName.FormatInfo = null;
                        PartName.HeaderText = "Pack Name";
                        PartName.MappingName = "PackName";
                        PartName.ReadOnly = true;
                        PartName.Width = 250;
                        PartName.NullText = "";
                        tStyle.GridColumnStyles.Add(PartName);
                        lblMiddleTitle.Text = "Part Packs";
                        break;
                    }

                case Enums.PageViewing.Product:
                    {
                        var ProductName = new DataGridLabelColumn();
                        ProductName.Format = "";
                        ProductName.FormatInfo = null;
                        ProductName.HeaderText = "Description";
                        ProductName.MappingName = "typemakemodel";
                        ProductName.ReadOnly = true;
                        ProductName.Width = 200;
                        ProductName.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductName);
                        var ProductNumber = new DataGridLabelColumn();
                        ProductNumber.Format = "";
                        ProductNumber.FormatInfo = null;
                        ProductNumber.HeaderText = "GC Number";
                        ProductNumber.MappingName = "Number";
                        ProductNumber.ReadOnly = true;
                        ProductNumber.Width = 120;
                        ProductNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductNumber);
                        var ProductReference = new DataGridLabelColumn();
                        ProductReference.Format = "";
                        ProductReference.FormatInfo = null;
                        ProductReference.HeaderText = "Reference";
                        ProductReference.MappingName = "Reference";
                        ProductReference.ReadOnly = true;
                        ProductReference.Width = 120;
                        ProductReference.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductReference);
                        lblMiddleTitle.Text = "Products";
                        break;
                    }

                case Enums.PageViewing.Supplier:
                    {
                        var SupplierName = new DataGridLabelColumn();
                        SupplierName.Format = "";
                        SupplierName.FormatInfo = null;
                        SupplierName.HeaderText = "Name";
                        SupplierName.MappingName = "Name";
                        SupplierName.ReadOnly = true;
                        SupplierName.Width = 120;
                        SupplierName.NullText = "";
                        tStyle.GridColumnStyles.Add(SupplierName);
                        var Address1 = new DataGridLabelColumn();
                        Address1.Format = "";
                        Address1.FormatInfo = null;
                        Address1.HeaderText = "Address 1";
                        Address1.MappingName = "Address1";
                        Address1.ReadOnly = true;
                        Address1.Width = 100;
                        Address1.NullText = "";
                        tStyle.GridColumnStyles.Add(Address1);
                        var Postcode = new DataGridLabelColumn();
                        Postcode.Format = "";
                        Postcode.FormatInfo = null;
                        Postcode.HeaderText = "Postcode";
                        Postcode.MappingName = "Postcode";
                        Postcode.ReadOnly = true;
                        Postcode.Width = 100;
                        Postcode.NullText = "";
                        tStyle.GridColumnStyles.Add(Postcode);
                        var Tel = new DataGridLabelColumn();
                        Tel.Format = "";
                        Tel.FormatInfo = null;
                        Tel.HeaderText = "Tel";
                        Tel.MappingName = "TelephoneNum";
                        Tel.ReadOnly = true;
                        Tel.Width = 100;
                        Tel.NullText = "";
                        tStyle.GridColumnStyles.Add(Tel);
                        lblMiddleTitle.Text = "Suppliers";
                        break;
                    }

                case Enums.PageViewing.Engineer:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 160;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var PDAID = new DataGridLabelColumn();
                        PDAID.Format = "";
                        PDAID.FormatInfo = null;
                        PDAID.HeaderText = "Engineer ID";
                        PDAID.MappingName = "EngineerID";
                        PDAID.ReadOnly = true;
                        PDAID.Width = 80;
                        PDAID.NullText = "";
                        tStyle.GridColumnStyles.Add(PDAID);
                        var Region = new DataGridLabelColumn();
                        Region.Format = "";
                        Region.FormatInfo = null;
                        Region.HeaderText = "Region";
                        Region.MappingName = "Region";
                        Region.ReadOnly = true;
                        Region.Width = 120;
                        Region.NullText = "";
                        tStyle.GridColumnStyles.Add(Region);
                        var TelNum = new DataGridLabelColumn();
                        TelNum.Format = "";
                        TelNum.FormatInfo = null;
                        TelNum.HeaderText = "Telephone Number";
                        TelNum.MappingName = "TelephoneNum";
                        TelNum.ReadOnly = true;
                        TelNum.Width = 120;
                        TelNum.NullText = "";
                        tStyle.GridColumnStyles.Add(TelNum);
                        var technician = new DataGridLabelColumn();
                        technician.Format = "";
                        technician.FormatInfo = null;
                        technician.HeaderText = "Technician";
                        technician.MappingName = "Technician";
                        technician.ReadOnly = true;
                        technician.Width = 100;
                        technician.NullText = "";
                        tStyle.GridColumnStyles.Add(technician);
                        var supervisor = new DataGridLabelColumn();
                        supervisor.Format = "";
                        supervisor.FormatInfo = null;
                        supervisor.HeaderText = "Supervisor";
                        supervisor.MappingName = "Supervisor";
                        supervisor.ReadOnly = true;
                        supervisor.Width = 100;
                        supervisor.NullText = "";
                        tStyle.GridColumnStyles.Add(supervisor);
                        lblMiddleTitle.Text = "Engineers";
                        btnExport.Visible = true;
                        break;
                    }

                case Enums.PageViewing.Equipment:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Equipment";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 160;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Region = new DataGridLabelColumn();
                        Region.Format = "";
                        Region.FormatInfo = null;
                        Region.HeaderText = "Serial";
                        Region.MappingName = "SerialNumber";
                        Region.ReadOnly = true;
                        Region.Width = 120;
                        Region.NullText = "";
                        tStyle.GridColumnStyles.Add(Region);
                        var Warranty = new DataGridLabelColumn();
                        Warranty.Format = "";
                        Warranty.FormatInfo = null;
                        Warranty.HeaderText = "Warranty";
                        Warranty.MappingName = "WarrantyEndDate";
                        Warranty.ReadOnly = true;
                        Warranty.Width = 120;
                        Warranty.NullText = "";
                        tStyle.GridColumnStyles.Add(Warranty);
                        lblMiddleTitle.Text = "Equipment";
                        btnExport.Visible = true;
                        break;
                    }

                case Enums.PageViewing.Subcontractor:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 160;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Region = new DataGridLabelColumn();
                        Region.Format = "";
                        Region.FormatInfo = null;
                        Region.HeaderText = "Region";
                        Region.MappingName = "Region";
                        Region.ReadOnly = true;
                        Region.Width = 120;
                        Region.NullText = "";
                        tStyle.GridColumnStyles.Add(Region);
                        var Address1 = new DataGridLabelColumn();
                        Address1.Format = "";
                        Address1.FormatInfo = null;
                        Address1.HeaderText = "Address1";
                        Address1.MappingName = "Address1";
                        Address1.ReadOnly = true;
                        Address1.Width = 80;
                        Address1.NullText = "";
                        tStyle.GridColumnStyles.Add(Address1);
                        var Postcode = new DataGridLabelColumn();
                        Postcode.Format = "";
                        Postcode.FormatInfo = null;
                        Postcode.HeaderText = "Postcode";
                        Postcode.MappingName = "Postcode";
                        Postcode.ReadOnly = true;
                        Postcode.Width = 80;
                        Postcode.NullText = "";
                        tStyle.GridColumnStyles.Add(Postcode);
                        var TelNum = new DataGridLabelColumn();
                        TelNum.Format = "";
                        TelNum.FormatInfo = null;
                        TelNum.HeaderText = "Telephone Number";
                        TelNum.MappingName = "TelephoneNum";
                        TelNum.ReadOnly = true;
                        TelNum.Width = 120;
                        TelNum.NullText = "";
                        tStyle.GridColumnStyles.Add(TelNum);
                        lblMiddleTitle.Text = "Subcontractors";
                        break;
                    }

                case Enums.PageViewing.StockProfile:
                    {
                        var Registration = new DataGridLabelColumn();
                        Registration.Format = "";
                        Registration.FormatInfo = null;
                        Registration.HeaderText = "Profile Name";
                        Registration.MappingName = "Registration";
                        Registration.ReadOnly = true;
                        Registration.Width = 200;
                        Registration.NullText = "";
                        tStyle.GridColumnStyles.Add(Registration);
                        var department = new DataGridLabelColumn();
                        department.Format = "";
                        department.FormatInfo = null;
                        department.HeaderText = "Department";
                        department.MappingName = "Department";
                        department.ReadOnly = true;
                        department.Width = 100;
                        department.NullText = "";
                        tStyle.GridColumnStyles.Add(department);
                        lblMiddleTitle.Text = "Stock Profiles";
                        btnExport.Visible = true;
                        btnDelete.Visible = true;
                        break;
                    }

                case Enums.PageViewing.Warehouse:
                    {
                        var Name = new DataGridLabelColumn();
                        Name.Format = "";
                        Name.FormatInfo = null;
                        Name.HeaderText = "Name";
                        Name.MappingName = "Name";
                        Name.ReadOnly = true;
                        Name.Width = 100;
                        Name.NullText = "";
                        tStyle.GridColumnStyles.Add(Name);
                        var Size = new DataGridLabelColumn();
                        Size.Format = "";
                        Size.FormatInfo = null;
                        Size.HeaderText = "Size";
                        Size.MappingName = "Size";
                        Size.ReadOnly = true;
                        Size.Width = 80;
                        Size.NullText = "";
                        tStyle.GridColumnStyles.Add(Size);
                        var Address1 = new DataGridLabelColumn();
                        Address1.Format = "";
                        Address1.FormatInfo = null;
                        Address1.HeaderText = "Address 1";
                        Address1.MappingName = "Address1";
                        Address1.ReadOnly = true;
                        Address1.Width = 100;
                        Address1.NullText = "";
                        tStyle.GridColumnStyles.Add(Address1);
                        var Address2 = new DataGridLabelColumn();
                        Address2.Format = "";
                        Address2.FormatInfo = null;
                        Address2.HeaderText = "Address 2";
                        Address2.MappingName = "Address2";
                        Address2.ReadOnly = true;
                        Address2.Width = 100;
                        Address2.NullText = "";
                        tStyle.GridColumnStyles.Add(Address2);
                        var Postcode = new DataGridLabelColumn();
                        Postcode.Format = "";
                        Postcode.FormatInfo = null;
                        Postcode.HeaderText = "Postcode";
                        Postcode.MappingName = "Postcode";
                        Postcode.ReadOnly = true;
                        Postcode.Width = 75;
                        Postcode.NullText = "";
                        tStyle.GridColumnStyles.Add(Postcode);
                        lblMiddleTitle.Text = "Warehouses";
                        break;
                    }

                case Enums.PageViewing.FleetVan:
                    {
                        var registration = new DataGridLabelColumn();
                        registration.Format = "";
                        registration.FormatInfo = null;
                        registration.HeaderText = "Registration";
                        registration.MappingName = "Registration";
                        registration.ReadOnly = true;
                        registration.Width = 100;
                        registration.NullText = "";
                        tStyle.GridColumnStyles.Add(registration);
                        var make = new DataGridLabelColumn();
                        make.Format = "";
                        make.FormatInfo = null;
                        make.HeaderText = "Engineer";
                        make.MappingName = "Name";
                        make.ReadOnly = true;
                        make.Width = 200;
                        make.NullText = "";
                        tStyle.GridColumnStyles.Add(make);
                        lblMiddleTitle.Text = "Fleet Vans";
                        btnExport.Visible = true;
                        break;
                    }

                case Enums.PageViewing.FleetVanType:
                    {
                        var make = new DataGridLabelColumn();
                        make.Format = "";
                        make.FormatInfo = null;
                        make.HeaderText = "Make";
                        make.MappingName = "Make";
                        make.ReadOnly = true;
                        make.Width = 140;
                        make.NullText = "";
                        tStyle.GridColumnStyles.Add(make);
                        var model = new DataGridLabelColumn();
                        model.Format = "";
                        model.FormatInfo = null;
                        model.HeaderText = "Model";
                        model.MappingName = "Model";
                        model.ReadOnly = true;
                        model.Width = 210;
                        model.NullText = "";
                        tStyle.GridColumnStyles.Add(model);
                        lblMiddleTitle.Text = "Van Types";
                        break;
                    }

                case Enums.PageViewing.FleetEquipment:
                    {
                        var name = new DataGridLabelColumn();
                        name.Format = "";
                        name.FormatInfo = null;
                        name.HeaderText = "Name";
                        name.MappingName = "Name";
                        name.ReadOnly = true;
                        name.Width = 140;
                        name.NullText = "";
                        tStyle.GridColumnStyles.Add(name);
                        var cost = new DataGridLabelColumn();
                        cost.Format = "C";
                        cost.FormatInfo = null;
                        cost.HeaderText = "Cost";
                        cost.MappingName = "Cost";
                        cost.ReadOnly = true;
                        cost.Width = 210;
                        cost.NullText = "";
                        tStyle.GridColumnStyles.Add(cost);
                        lblMiddleTitle.Text = "Fleet Equipment";
                        break;
                    }

                case Enums.PageViewing.UserQuals:
                    {
                        var fullName = new DataGridLabelColumn();
                        fullName.Format = "";
                        fullName.FormatInfo = null;
                        fullName.HeaderText = "Name";
                        fullName.MappingName = "FullName";
                        fullName.ReadOnly = true;
                        fullName.Width = 125;
                        fullName.NullText = "";
                        tStyle.GridColumnStyles.Add(fullName);
                        lblMiddleTitle.Text = "Users";
                        btnAddNew.Visible = false;
                        btnDelete.Visible = false;
                        btnExport.Visible = false;
                        break;
                    }
            }

            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
            // Me.dgSearchResults.TableStyles.Add(tStyle)

            pnlMiddle.Visible = true;
            SearchResults = dv;
            if (Page == Enums.PageViewing.Property)
            {
                if (!FromADelete)
                {
                    if (!(App.CurrentPropertyID == 0))
                    {
                        int rwCnt = 0;
                        foreach (DataRow row in SearchResults.Table.Rows)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["SiteID"], App.CurrentPropertyID, false)))
                            {
                                break;
                            }
                            else
                            {
                                rwCnt += 1;
                            }
                        }

                        dgSearchResults.CurrentRowIndex = rwCnt;
                    }
                }
            }
        }

        private void btnHQ_Click(object sender, EventArgs e)
        {
            var TheHQ = App.DB.Sites.Get(SelectedSearchResultDataRow["CustomerID"], Entity.Sites.SiteSQL.GetBy.CustomerHq);
            if (TheHQ is null || !TheHQ.Exists)
            {
                App.ShowMessage("No head office has been assigned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (TheHQ.SiteID == Helper.MakeIntegerValid(SelectedSearchResultDataRow["SiteID"]))
            {
                App.ShowMessage("This site is the head office", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            App.ShowForm(typeof(FRMSitePopup), true, new object[] { TheHQ.SiteID });
        }

        private void Add()
        {
            var switchExpr = Page;
            switch (switchExpr)
            {
                case Enums.PageViewing.Customer:
                    {
                        App.ShowForm(typeof(FRMCustomer), true, null);
                        break;
                    }

                case Enums.PageViewing.Property:
                    {
                        var custCheck = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
                        if (custCheck is object)
                        {
                            if (custCheck.Status == (int)Enums.CustomerStatus.OnHold)
                            {
                                App.ShowMessage("Customer On Hold.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        App.ShowForm(typeof(FRMSite), true, null);
                        break;
                    }

                case Enums.PageViewing.Asset:
                    {
                        App.ShowForm(typeof(FRMAsset), true, null);
                        break;
                    }

                case Enums.PageViewing.Subcontractor:
                    {
                        App.ShowForm(typeof(FRMSubcontractor), true, null);
                        break;
                    }

                case Enums.PageViewing.Supplier:
                    {
                        var _ssmList = new List<Enums.SecuritySystemModules>();
                        _ssmList.Add(Enums.SecuritySystemModules.Finance);
                        _ssmList.Add(Enums.SecuritySystemModules.Compliance);
                        if (App.loggedInUser.HasAccessToMulitpleModules(_ssmList))
                        {
                            App.ShowForm(typeof(FRMSupplier), true, null);
                        }
                        else
                        {
                            string msg = "You do not have the necessary security permissions." + Constants.vbCrLf;
                            msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                            throw new System.Security.SecurityException(msg);
                        }

                        break;
                    }

                case Enums.PageViewing.Product:
                    {
                        App.ShowForm(typeof(FRMProduct), true, null);
                        break;
                    }

                case Enums.PageViewing.Part:
                    {
                        if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.CreateParts) == false)
                        {
                            string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                            msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                            throw new System.Security.SecurityException(msg);
                        }
                        else
                        {
                            // If EnterOverridePassword() Then
                            App.ShowForm(typeof(FRMPart), true, null);
                        }

                        break;
                    }

                case Enums.PageViewing.PartPack:
                    {
                        Enums.SecuritySystemModules ssm;
                        ssm = Enums.SecuritySystemModules.CreateParts;
                        if (App.loggedInUser.HasAccessToModule(ssm) == false)
                        {
                            string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                            msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                            throw new System.Security.SecurityException(msg);
                        }
                        else
                        {
                            // If EnterOverridePassword() Then
                            App.ShowForm(typeof(FRMPartPack), true, null);
                        }

                        break;
                    }

                case Enums.PageViewing.Engineer:
                    {
                        App.ShowForm(typeof(FRMEngineer), true, null);
                        break;
                    }

                case Enums.PageViewing.StockProfile:
                    {
                        App.ShowForm(typeof(FRMVan), true, null);
                        break;
                    }

                case Enums.PageViewing.FleetVan:
                    {
                        App.ShowForm(typeof(FRMFleetVan), true, null);
                        break;
                    }

                case Enums.PageViewing.FleetVanType:
                    {
                        App.ShowForm(typeof(FRMFleetVanType), true, null);
                        break;
                    }

                case Enums.PageViewing.FleetEquipment:
                    {
                        App.ShowForm(typeof(FRMFleetEquipment), true, null);
                        break;
                    }

                case Enums.PageViewing.Equipment:
                    {
                        App.ShowForm(typeof(FRMEquipment), true, null);
                        break;
                    }

                case Enums.PageViewing.Warehouse:
                    {
                        App.ShowForm(typeof(FRMWarehouse), true, null);
                        break;
                    }
            }
        }

        private void Delete()
        {
            if (SelectedSearchResultDataRow is null)
            {
                return;
            }

            if (App.ShowMessage("You are about to delete an item." + Constants.vbCrLf + Constants.vbCrLf + "Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            }
            else
            {
                return;
            }

            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.IT))
            {
                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
                return;
            }

            var switchExpr = Page;
            switch (switchExpr)
            {
                case Enums.PageViewing.Supplier:
                    {
                        App.DB.Supplier.Delete(Helper.MakeIntegerValid(SelectedSearchResultDataRow["SupplierID"]));
                        SetSearchResults(App.DB.Supplier.Supplier_GetAll(), Enums.PageViewing.Supplier, false, true);
                        break;
                    }

                case Enums.PageViewing.Customer:
                    {
                        int customerID = Helper.MakeIntegerValid(SelectedSearchResultDataRow["CustomerID"]);

                        // check if the customer has active sites if so then we can't delete
                        if (App.DB.Customer.Customer_GetActiveSiteCount(customerID) == 0)
                        {
                            App.DB.Customer.Delete(customerID);
                            SetSearchResults(App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID), Enums.PageViewing.Customer, false, true);
                        }
                        else
                        {
                            App.ShowMessage("This customer has active sites so cannot be deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case Enums.PageViewing.Property:
                    {
                        // SHOULD NOT BE ABLE TO DELETE A SITE IF IT HAS ACTIVE JOBS OR ORDERS
                        if (App.DB.Sites.Site_CanItBeDeleted(Helper.MakeIntegerValid(SelectedSearchResultDataRow["SiteID"])).Table.Rows.Count > 0)
                        {
                            if (App.ShowMessage("This site has active jobs or orders" + Constants.vbCrLf + Constants.vbCrLf + "Do you wish to continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                            {
                                return;
                            }
                        }

                        App.DB.Job.Job_Delete_BySite(Conversions.ToInteger(SelectedSearchResultDataRow["SiteID"]));
                        App.DB.Sites.Delete(Helper.MakeIntegerValid(SelectedSearchResultDataRow["SiteID"]));
                        if (App.CurrentCustomerID == 0)
                        {
                            SetSearchResults(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, false, true);
                        }
                        else
                        {
                            var cust = new Entity.Customers.Customer();
                            cust = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
                            SetSearchResults(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, false, true, cust.Name + " (" + cust.AccountNumber + ")");
                        }

                        break;
                    }

                case Enums.PageViewing.Asset:
                    {
                        App.DB.Asset.Delete(Helper.MakeIntegerValid(SelectedSearchResultDataRow["AssetID"]));
                        if (App.CurrentPropertyID == 0)
                        {
                            SetSearchResults(App.DB.Asset.Asset_GetAll(App.loggedInUser.UserID), Enums.PageViewing.Asset, false, true);
                        }
                        else
                        {
                            var site = new Entity.Sites.Site();
                            site = App.DB.Sites.Get(App.CurrentPropertyID);
                            var cust = new Entity.Customers.Customer();
                            cust = App.DB.Customer.Customer_Get(site.CustomerID);
                            SetSearchResults(App.DB.Asset.Asset_GetForSite(App.CurrentPropertyID), Enums.PageViewing.Asset, false, true, site.Address1 + ", " + site.Postcode + " (" + cust.AccountNumber + ")");
                        }

                        break;
                    }

                case Enums.PageViewing.Product:
                    {
                        App.DB.Product.Delete(Helper.MakeIntegerValid(SelectedSearchResultDataRow["ProductID"]));
                        SetSearchResults(App.DB.Product.Product_GetAll(), Enums.PageViewing.Product, false, true);
                        break;
                    }

                case Enums.PageViewing.Part:
                    {
                        int partID = Helper.MakeIntegerValid(SelectedSearchResultDataRow["PartID"]);
                        var suppliers = App.DB.PartSupplier.Get_ByPartID(partID);
                        var stockList = App.DB.Part.Stock_Get_Locations(partID);
                        if (suppliers.Table.Rows.Count > 0 & stockList.Table.Rows.Count > 0)
                        {
                            App.ShowMessage("This part has active suppliers and stock so cannot be deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        App.DB.Part.Delete(partID);
                        ISearchControl ctrl = (ISearchControl)MenuBar.pnlSearch.Controls[0];
                        if (ctrl is object)
                            ctrl.Search();
                        break;
                    }
                // SetSearchResults(DB.Part.Part_GetAll, Entity.Sys.Enums.PageViewing.Part, False, True)
                case Enums.PageViewing.PartPack:
                    {
                        App.DB.ExecuteScalar(Conversions.ToString("DELETE FROM tblPartPack WHERE PackID = " + SelectedSearchResultDataRow["PackID"]));
                        SetSearchResults(App.DB.Part.PartPack_GetAll(), Enums.PageViewing.PartPack, false, true);
                        break;
                    }

                case Enums.PageViewing.Engineer:
                    {
                        int engineerId = Helper.MakeIntegerValid(SelectedSearchResultDataRow["EngineerID"]);
                        var dvJobs = App.DB.EngineerVisits.Get_ByEngineerIdAndStatusEnumId(engineerId, Conversions.ToInteger(Enums.VisitStatus.Scheduled));
                        dvJobs.Table.Merge(App.DB.EngineerVisits.Get_ByEngineerIdAndStatusEnumId(engineerId, Conversions.ToInteger(Enums.VisitStatus.Downloaded)).Table);
                        if (dvJobs.Count > 1)
                        {
                            App.ShowMessage("This engineer has jobs that are scheduled/downloaded so cannot be deleted!" + Constants.vbCrLf + Constants.vbCrLf + "An export of their jobs will follow!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ExportHelper.Export(dvJobs.Table, "Jobs", Enums.ExportType.XLS);
                            return;
                        }
                        else
                        {
                            App.DB.Engineer.Delete(engineerId);
                            SetSearchResults(App.DB.Engineer.Engineer_GetAll_NoSub(), Enums.PageViewing.Engineer, false, true);
                        }

                        break;
                    }

                case Enums.PageViewing.Equipment:
                    {
                        App.DB.Engineer.DeleteEquipment(Helper.MakeIntegerValid(SelectedSearchResultDataRow["EquipmentID"]));
                        SetSearchResults(App.DB.Engineer.Equipment_GetAll(), Enums.PageViewing.Equipment, false, true);
                        break;
                    }

                case Enums.PageViewing.FleetVanType:
                    {
                        App.DB.FleetVanType.Delete(Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanTypeID"]));
                        SetSearchResults(App.DB.FleetVanType.GetAll(), Enums.PageViewing.FleetVanType, false, true);
                        break;
                    }

                case Enums.PageViewing.FleetEquipment:
                    {
                        int equipmentID = Helper.MakeIntegerValid(SelectedSearchResultDataRow["EquipmentID"]);
                        if (App.DB.FleetEquipment.GetActiveCount(equipmentID) == 0)
                        {
                            App.DB.FleetEquipment.Delete(equipmentID);
                            SetSearchResults(App.DB.FleetEquipment.GetAll(), Enums.PageViewing.FleetEquipment, false, true);
                        }
                        else
                        {
                            App.ShowMessage("This equipment is still in use by vans", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case Enums.PageViewing.FleetVan:
                    {
                        App.ShowMessage("Vans cannot be deleted, only returned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                case Enums.PageViewing.Subcontractor:
                    {
                        App.DB.SubContractor.Delete(Helper.MakeIntegerValid(SelectedSearchResultDataRow["SubcontractorID"]));
                        SetSearchResults(App.DB.SubContractor.Subcontractor_GetAll(), Enums.PageViewing.Subcontractor, false, true);
                        break;
                    }

                case Enums.PageViewing.StockProfile:
                    {
                        App.DB.Van.Delete(Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanID"]));
                        SetSearchResults(App.DB.Van.Van_GetAll(true), Enums.PageViewing.StockProfile, false, true);
                        break;
                    }

                case Enums.PageViewing.Warehouse:
                    {
                        App.DB.Warehouse.Delete(Helper.MakeIntegerValid(SelectedSearchResultDataRow["WarehouseID"]));
                        SetSearchResults(App.DB.Warehouse.Warehouse_GetAll(), Enums.PageViewing.Warehouse, false, true);
                        break;
                    }
            }
        }

        public void View()
        {
            if (Exporting)
            {
                return;
            }

            if (SelectedSearchResultDataRow is null)
            {
                return;
            }

            IUserControl ctrl = null;
            if (!(Page == Enums.PageViewing.Property))
            {
                SearchText = "";
            }

            var switchExpr = Page;
            switch (switchExpr)
            {
                case Enums.PageViewing.Supplier:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["SupplierID"]) == ((Entity.Suppliers.Supplier)((IUserControl)pnlContent.Controls[0]).LoadedItem).SupplierID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Supplier";
                        ctrl = new UCSupplier();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["SupplierID"]));
                        break;
                    }

                case Enums.PageViewing.Customer:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["CustomerID"]) == ((Entity.Customers.Customer)((IUserControl)pnlContent.Controls[0]).LoadedItem).CustomerID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Customer";
                        ctrl = new UCCustomer();
                        App.CurrentCustomerID = Helper.MakeIntegerValid(SelectedSearchResultDataRow["CustomerID"]);
                        ctrl.Populate(App.CurrentCustomerID);
                        break;
                    }

                case Enums.PageViewing.Property:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["SiteID"]) == ((Entity.Sites.Site)((IUserControl)pnlContent.Controls[0]).LoadedItem).SiteID)
                                {
                                    return;
                                }
                            }
                        }

                        var oCust = new Entity.Customers.Customer();
                        oCust = App.DB.Customer.Customer_Get_ForSiteID(Conversions.ToInteger(SelectedSearchResultDataRow["SiteID"]));
                        lblRightTitle.Text = "Manage Property for Customer: " + oCust.Name + ", Acc: " + oCust.AccountNumber;
                        ctrl = new UCSite();
                        App.CurrentPropertyID = Helper.MakeIntegerValid(SelectedSearchResultDataRow["SiteID"]);
                        ctrl.Populate(App.CurrentPropertyID);
                        break;
                    }

                case Enums.PageViewing.Asset:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["AssetID"]) == ((Entity.Assets.Asset)((IUserControl)pnlContent.Controls[0]).LoadedItem).AssetID)
                                {
                                    return;
                                }
                            }
                        }

                        var oProperty = new Entity.Sites.Site();
                        oProperty = App.DB.Sites.Get(SelectedSearchResultDataRow["AssetID"], Entity.Sites.SiteSQL.GetBy.Asset);
                        var oCust = new Entity.Customers.Customer();
                        oCust = App.DB.Customer.Customer_Get_ForSiteID(oProperty.SiteID);
                        lblRightTitle.Text = "Manage Appliance for Property: " + oProperty.Name + ", " + oProperty.Postcode + ", Customer: " + oCust.Name + ", Acc: " + oCust.AccountNumber;
                        ctrl = new UCAsset();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["AssetID"]));
                        break;
                    }

                case Enums.PageViewing.Contact:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["ContactID"]) == ((Entity.Contacts.Contact)((IUserControl)pnlContent.Controls[0]).LoadedItem).ContactID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Contact";
                        ctrl = new UCContact();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["ContactID"]));
                        break;
                    }

                case Enums.PageViewing.Part:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["PartID"]) == ((Entity.Parts.Part)((IUserControl)pnlContent.Controls[0]).LoadedItem).PartID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Part";
                        ctrl = new UCPart();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["PartID"]));
                        break;
                    }

                case Enums.PageViewing.PartPack:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["PackID"]) == ((UCPartPack)pnlContent.Controls[0]).PackID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Part Pack";
                        ctrl = new UCPartPack();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["PackID"]));
                        break;
                    }

                case Enums.PageViewing.Product:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["ProductID"]) == ((Entity.Products.Product)((IUserControl)pnlContent.Controls[0]).LoadedItem).ProductID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Product";
                        ctrl = new UCProduct();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["ProductID"]));
                        break;
                    }

                case Enums.PageViewing.Engineer:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["EngineerID"]) == ((Entity.Engineers.Engineer)((IUserControl)pnlContent.Controls[0]).LoadedItem).EngineerID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Engineer";
                        ctrl = new UCEngineer();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["EngineerID"]));
                        break;
                    }

                case Enums.PageViewing.Subcontractor:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["SubcontractorID"]) == ((Entity.Subcontractors.Subcontractor)((IUserControl)pnlContent.Controls[0]).LoadedItem).SubcontractorID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Subcontractor";
                        ctrl = new UCSubcontractor();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["SubcontractorID"]));
                        break;
                    }

                case Enums.PageViewing.StockProfile:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanID"]) == ((Entity.Vans.Van)((IUserControl)pnlContent.Controls[0]).LoadedItem).VanID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Van Stock Profiles";
                        ctrl = new UCVan();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanID"]));
                        break;
                    }

                case Enums.PageViewing.Equipment:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["EquipmentID"]) == ((Entity.Engineers.Equipment)((IUserControl)pnlContent.Controls[0]).LoadedItem).EquipmentID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Equipment";
                        ctrl = new UCEquipment();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["EquipmentID"]));
                        break;
                    }

                case var @case when @case == Enums.PageViewing.StockProfile:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanID"]) == ((Entity.Vans.Van)((IUserControl)pnlContent.Controls[0]).LoadedItem).VanID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Profiles";
                        ctrl = new UCVan();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanID"]));
                        break;
                    }

                case Enums.PageViewing.FleetVan:
                    {
                        if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Fleet) == false)
                        {
                            string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                            msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                            throw new System.Security.SecurityException(msg);
                        }

                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanID"]) == ((Entity.FleetVans.FleetVan)((IUserControl)pnlContent.Controls[0]).LoadedItem).VanID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Van";
                        ctrl = new UCFleetVan();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanID"]));
                        break;
                    }

                case Enums.PageViewing.FleetVanType:
                    {
                        if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Fleet) == false)
                        {
                            string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                            msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                            throw new System.Security.SecurityException(msg);
                        }

                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanTypeID"]) == ((Entity.FleetVans.FleetVanType)((IUserControl)pnlContent.Controls[0]).LoadedItem).VanTypeID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Van Type";
                        ctrl = new UCFleetVanType();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanTypeID"]));
                        break;
                    }

                case Enums.PageViewing.FleetEquipment:
                    {
                        if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Fleet) == false)
                        {
                            string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                            msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                            throw new System.Security.SecurityException(msg);
                        }

                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["EquipmentID"]) == ((Entity.FleetVans.FleetEquipment)((IUserControl)pnlContent.Controls[0]).LoadedItem).EquipmentID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Equipment";
                        ctrl = new UCFleetEquipment();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["EquipmentID"]));
                        break;
                    }

                case Enums.PageViewing.Warehouse:
                    {
                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["WarehouseID"]) == ((Entity.Warehouses.Warehouse)((IUserControl)pnlContent.Controls[0]).LoadedItem).WarehouseID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage Warehouse";
                        ctrl = new UCWarehouse();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["WarehouseID"]));
                        break;
                    }

                case Enums.PageViewing.UserQuals:
                    {
                        var _ssmList = new List<Enums.SecuritySystemModules>() { Enums.SecuritySystemModules.Compliance, Enums.SecuritySystemModules.IT };
                        if (App.loggedInUser.HasAccessToMulitpleModules(_ssmList) == false)
                        {
                            string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                            msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                            throw new System.Security.SecurityException(msg);
                        }

                        if (pnlRight.Visible)
                        {
                            if (pnlContent.Controls.Count > 0)
                            {
                                if (Helper.MakeIntegerValid(SelectedSearchResultDataRow["UserID"]) == ((Entity.Users.User)((IUserControl)pnlContent.Controls[0]).LoadedItem).UserID)
                                {
                                    return;
                                }
                            }
                        }

                        lblRightTitle.Text = "Manage User";
                        ctrl = new UCUserQualification();
                        ctrl.Populate(Helper.MakeIntegerValid(SelectedSearchResultDataRow["UserID"]));
                        break;
                    }
            }

            ctrl.RecordsChanged += App.MainForm.SetSearchResults;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add((Control)ctrl);
            Navigation.Show_Right();
        }

        private void Open()
        {
            if (SelectedSearchResultDataRow is null)
            {
                return;
            }

            var switchExpr = Page;
            switch (switchExpr)
            {
                case Enums.PageViewing.Supplier:
                    {
                        App.ShowForm(typeof(FRMSupplier), true, new object[] { Helper.MakeIntegerValid(SelectedSearchResultDataRow["SupplierID"]) });
                        break;
                    }

                case Enums.PageViewing.Customer:
                    {
                        App.ShowForm(typeof(FRMCustomer), true, new object[] { Helper.MakeIntegerValid(SelectedSearchResultDataRow["CustomerID"]) });
                        break;
                    }

                case Enums.PageViewing.Property:
                    {
                        App.ShowForm(typeof(FRMSite), true, new object[] { Helper.MakeIntegerValid(SelectedSearchResultDataRow["SiteID"]) });
                        break;
                    }

                case Enums.PageViewing.Asset:
                    {
                        App.ShowForm(typeof(FRMAsset), true, new object[] { Helper.MakeIntegerValid(SelectedSearchResultDataRow["AssetID"]) });
                        break;
                    }

                case Enums.PageViewing.Product:
                    {
                        App.ShowForm(typeof(FRMProduct), true, new object[] { Helper.MakeIntegerValid(SelectedSearchResultDataRow["ProductID"]), false });
                        break;
                    }

                case Enums.PageViewing.Part:
                    {
                        App.ShowForm(typeof(FRMPart), true, new object[] { Helper.MakeIntegerValid(SelectedSearchResultDataRow["PartID"]), false });
                        break;
                    }

                case Enums.PageViewing.Engineer:
                    {
                        App.ShowForm(typeof(FRMEngineer), true, new object[] { Helper.MakeIntegerValid(SelectedSearchResultDataRow["EngineerID"]) });
                        break;
                    }

                case Enums.PageViewing.Subcontractor:
                    {
                        App.ShowForm(typeof(FRMSubcontractor), true, new object[] { Helper.MakeIntegerValid(SelectedSearchResultDataRow["SubcontractorID"]) });
                        break;
                    }

                case Enums.PageViewing.StockProfile:
                    {
                        App.ShowForm(typeof(FRMVan), true, new object[] { Helper.MakeIntegerValid(SelectedSearchResultDataRow["VanID"]) });
                        break;
                    }

                case Enums.PageViewing.Warehouse:
                    {
                        App.ShowForm(typeof(FRMWarehouse), true, new object[] { Helper.MakeIntegerValid(SelectedSearchResultDataRow["WarehouseID"]) });
                        break;
                    }
            }
        }

        private void Save()
        {
            ((IUserControl)pnlContent.Controls[0]).Save();
        }

        public void RefreshEntity(int id, string IDColumnName = "")
        {
            if (string.IsNullOrEmpty(IDColumnName))
            {
                if (SearchResults is object)
                {
                    if (SearchResults.Table.Rows.Count == 1)
                    {
                        dgSearchResults.Select(0);
                    }
                }
            }
            else
            {
                int index = 0;
                foreach (DataRow row in ((DataView)dgSearchResults.DataSource).Table.Rows)
                {
                    if (Conversions.ToInteger(row[IDColumnName]) == id)
                    {
                        dgSearchResults.CurrentRowIndex = index;
                        break;
                    }
                    else
                    {
                        index += 1;
                    }
                }
            }

            View();
            if (pnlContent.Controls.Count > 0)
            {
                ((IUserControl)pnlContent.Controls[0]).Populate(id);
            }
        }

        private void mnuUpstairs_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var tempfile = new FileInfo(dlg.FileName);
                    if ((Path.GetExtension(tempfile.Name) ?? "") != ".docx")
                        throw new Exception("Incorrect File Format");
                    var pdfFile = new FileInfo(PrintHelper.ToPdf(tempfile.FullName));
                    if ((Path.GetExtension(pdfFile.Name) ?? "") != ".pdf")
                        throw new Exception("Error converting to pdf");
                    string filePath = @"\\PHOCAS.gasway.co.uk\Aggregator_IO\Inputs\Upstairs Documents\";
                    string fileType = Path.GetExtension(pdfFile.Name);
                    File.Copy(pdfFile.FullName, filePath + pdfFile.Name.Replace(fileType, "_" + DateAndTime.Now.ToString("ddMMyyHHmmss") + fileType));
                    File.Delete(pdfFile.FullName);
                    App.ShowMessage("File successfully copy to Upstairs Printer! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("File data could not be printed : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }
        }

        private void mnuDownstairs_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var tempfile = new FileInfo(dlg.FileName);
                    if ((Path.GetExtension(tempfile.Name) ?? "") != ".docx")
                        throw new Exception("Incorrect File Format");
                    var pdfFile = new FileInfo(PrintHelper.ToPdf(tempfile.FullName));
                    if ((Path.GetExtension(pdfFile.Name) ?? "") != ".pdf")
                        throw new Exception("Error converting to pdf");
                    string filePath = @"\\PHOCAS.gasway.co.uk\Aggregator_IO\Inputs\Downstairs Documents\";
                    string fileType = Path.GetExtension(pdfFile.Name);
                    File.Copy(pdfFile.FullName, filePath + pdfFile.Name.Replace(fileType, "_" + DateAndTime.Now.ToString("ddMMyyHHmmss") + fileType));
                    File.Delete(pdfFile.FullName);
                    App.ShowMessage("File successfully copy to Downstairs Printer! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("File data could not be printed : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlMiddle_Resize(object sender, EventArgs e)
        {
            int width = pnlMiddle.Width;
            if (App.MainForm is object)
            {
                Navigation.ResponsiveUI();
            }

            Navigation.Show_Right();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}