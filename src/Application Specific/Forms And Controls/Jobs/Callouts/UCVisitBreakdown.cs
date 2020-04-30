using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCVisitBreakdown : UCBase, IUserControl
    {
        

        public UCVisitBreakdown() : base()
        {
            
            
            base.Load += UCVisitBreakdown_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

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

        private TextBox _txtNotesToEngineer;

        internal TextBox txtNotesToEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotesToEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotesToEngineer != null)
                {
                    _txtNotesToEngineer.TextChanged -= txtNotesToEngineer_TextChanged;
                }

                _txtNotesToEngineer = value;
                if (_txtNotesToEngineer != null)
                {
                    _txtNotesToEngineer.TextChanged += txtNotesToEngineer_TextChanged;
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

        private TextBox _txtDate;

        internal TextBox txtDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDate != null)
                {
                }

                _txtDate = value;
                if (_txtDate != null)
                {
                }
            }
        }

        private TextBox _txtOutcome;

        internal TextBox txtOutcome
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOutcome;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOutcome != null)
                {
                }

                _txtOutcome = value;
                if (_txtOutcome != null)
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

        private Label _lblOutcome;

        internal Label lblOutcome
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOutcome;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOutcome != null)
                {
                }

                _lblOutcome = value;
                if (_lblOutcome != null)
                {
                }
            }
        }

        private TabControl _TabControl1;

        internal TabControl TabControl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabControl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabControl1 != null)
                {
                }

                _TabControl1 = value;
                if (_TabControl1 != null)
                {
                }
            }
        }

        private TabPage _tpVisitDetails;

        internal TabPage tpVisitDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpVisitDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpVisitDetails != null)
                {
                }

                _tpVisitDetails = value;
                if (_tpVisitDetails != null)
                {
                }
            }
        }

        private TabPage _tpParts;

        internal TabPage tpParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpParts != null)
                {
                }

                _tpParts = value;
                if (_tpParts != null)
                {
                }
            }
        }

        private DataGrid _dgPartsAndProducts;

        internal DataGrid dgPartsAndProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPartsAndProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPartsAndProducts != null)
                {
                }

                _dgPartsAndProducts = value;
                if (_dgPartsAndProducts != null)
                {
                }
            }
        }

        private CheckBox _cbxPartsToFit;

        internal CheckBox cbxPartsToFit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxPartsToFit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxPartsToFit != null)
                {
                }

                _cbxPartsToFit = value;
                if (_cbxPartsToFit != null)
                {
                }
            }
        }

        private ComboBox _cboExpected;

        internal ComboBox cboExpected
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboExpected;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboExpected != null)
                {
                }

                _cboExpected = value;
                if (_cboExpected != null)
                {
                }
            }
        }

        private CheckBox _chkRecharge;

        internal CheckBox chkRecharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkRecharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkRecharge != null)
                {
                }

                _chkRecharge = value;
                if (_chkRecharge != null)
                {
                }
            }
        }

        private Button _btnGetOrderRef;

        internal Button btnGetOrderRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGetOrderRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGetOrderRef != null)
                {
                    _btnGetOrderRef.Click -= btnGetOrderRef_Click;
                }

                _btnGetOrderRef = value;
                if (_btnGetOrderRef != null)
                {
                    _btnGetOrderRef.Click += btnGetOrderRef_Click;
                }
            }
        }

        private TabPage _EstVisitDate;

        internal TabPage EstVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _EstVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_EstVisitDate != null)
                {
                }

                _EstVisitDate = value;
                if (_EstVisitDate != null)
                {
                }
            }
        }

        private Button _BtnEstSave;

        internal Button BtnEstSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BtnEstSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BtnEstSave != null)
                {
                    
                    _BtnEstSave.Click -= btnEstSave_Click;
                }

                _BtnEstSave = value;
                if (_BtnEstSave != null)
                {
                    _BtnEstSave.Click += btnEstSave_Click;
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

        private DateTimePicker _dtpEstimateVisitDate;

        internal DateTimePicker dtpEstimateVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpEstimateVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpEstimateVisitDate != null)
                {
                }

                _dtpEstimateVisitDate = value;
                if (_dtpEstimateVisitDate != null)
                {
                }
            }
        }

        private TextBox _txtPassword;

        internal TextBox txtPassword
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPassword;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPassword != null)
                {
                    _txtPassword.TextChanged -= txtPassword_TextChanged;
                }

                _txtPassword = value;
                if (_txtPassword != null)
                {
                    _txtPassword.TextChanged += txtPassword_TextChanged;
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

        private Button _btnMoveParts;

        internal Button btnMoveParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMoveParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMoveParts != null)
                {
                    _btnMoveParts.Click -= btnMoveParts_Click;
                }

                _btnMoveParts = value;
                if (_btnMoveParts != null)
                {
                    _btnMoveParts.Click += btnMoveParts_Click;
                }
            }
        }

        private ContextMenuStrip _cmsPrint;

        internal ContextMenuStrip cmsPrint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsPrint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsPrint != null)
                {
                }

                _cmsPrint = value;
                if (_cmsPrint != null)
                {
                }
            }
        }

        private ToolStripMenuItem _EngineerJobSheetToolStripMenuItem;

        internal ToolStripMenuItem EngineerJobSheetToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _EngineerJobSheetToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_EngineerJobSheetToolStripMenuItem != null)
                {
                    _EngineerJobSheetToolStripMenuItem.Click -= PrintEngjob;
                }

                _EngineerJobSheetToolStripMenuItem = value;
                if (_EngineerJobSheetToolStripMenuItem != null)
                {
                    _EngineerJobSheetToolStripMenuItem.Click += PrintEngjob;
                }
            }
        }

        private ToolStripMenuItem _ProForrmaToolStripMenuItem;

        internal ToolStripMenuItem ProForrmaToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ProForrmaToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ProForrmaToolStripMenuItem != null)
                {
                    _ProForrmaToolStripMenuItem.Click -= ProForrmaToolStripMenuItem_Click;
                }

                _ProForrmaToolStripMenuItem = value;
                if (_ProForrmaToolStripMenuItem != null)
                {
                    _ProForrmaToolStripMenuItem.Click += ProForrmaToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _btnPrintInstall;

        internal ToolStripMenuItem btnPrintInstall
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintInstall;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintInstall != null)
                {
                    _btnPrintInstall.Click -= btnPrintInstall_Click;
                }

                _btnPrintInstall = value;
                if (_btnPrintInstall != null)
                {
                    _btnPrintInstall.Click += btnPrintInstall_Click;
                }
            }
        }

        private ToolStripMenuItem _BtnPrintServiceLetter;

        internal ToolStripMenuItem BtnPrintServiceLetter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BtnPrintServiceLetter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BtnPrintServiceLetter != null)
                {
                    _BtnPrintServiceLetter.Click -= BtnPrintServiceLetter_Click;
                }

                _BtnPrintServiceLetter = value;
                if (_BtnPrintServiceLetter != null)
                {
                    _BtnPrintServiceLetter.Click += BtnPrintServiceLetter_Click;
                }
            }
        }

        private Label _lblAuthCode;

        internal Label lblAuthCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAuthCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAuthCode != null)
                {
                }

                _lblAuthCode = value;
                if (_lblAuthCode != null)
                {
                }
            }
        }

        private Button _btnGenerateAuthCode;

        internal Button btnGenerateAuthCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGenerateAuthCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGenerateAuthCode != null)
                {
                    _btnGenerateAuthCode.Click -= btnGenerateAuthCode_Click;
                }

                _btnGenerateAuthCode = value;
                if (_btnGenerateAuthCode != null)
                {
                    _btnGenerateAuthCode.Click += btnGenerateAuthCode_Click;
                }
            }
        }

        private ToolStripMenuItem _btnPrintJobLetter;

        internal ToolStripMenuItem btnPrintJobLetter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintJobLetter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintJobLetter != null)
                {
                    _btnPrintJobLetter.Click -= btnPrintJobLetter_Click;
                }

                _btnPrintJobLetter = value;
                if (_btnPrintJobLetter != null)
                {
                    _btnPrintJobLetter.Click += btnPrintJobLetter_Click;
                }
            }
        }

        private CheckBox _chkSendText;

        internal CheckBox chkSendText
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSendText;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSendText != null)
                {
                }

                _chkSendText = value;
                if (_chkSendText != null)
                {
                }
            }
        }

        private Button _btnUploadVisit;

        internal Button btnUploadVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUploadVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUploadVisit != null)
                {
                    _btnUploadVisit.Click -= btnUploadVisit_Click;
                }

                _btnUploadVisit = value;
                if (_btnUploadVisit != null)
                {
                    _btnUploadVisit.Click += btnUploadVisit_Click;
                }
            }
        }

        private ToolStripMenuItem _PrintSolarInstall;

        internal ToolStripMenuItem PrintSolarInstall
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PrintSolarInstall;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PrintSolarInstall != null)
                {
                    _PrintSolarInstall.Click -= PrintSolarInstall_Click;
                }

                _PrintSolarInstall = value;
                if (_PrintSolarInstall != null)
                {
                    _PrintSolarInstall.Click += PrintSolarInstall_Click;
                }
            }
        }

        private ToolStripMenuItem _PrintElectricalAppointment;

        internal ToolStripMenuItem PrintElectricalAppointment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PrintElectricalAppointment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PrintElectricalAppointment != null)
                {
                    _PrintElectricalAppointment.Click -= PrintElectricalAppointment_Click;
                }

                _PrintElectricalAppointment = value;
                if (_PrintElectricalAppointment != null)
                {
                    _PrintElectricalAppointment.Click += PrintElectricalAppointment_Click;
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _txtNotesToEngineer = new TextBox();
            _txtNotesToEngineer.TextChanged += new EventHandler(txtNotesToEngineer_TextChanged);
            _Label1 = new Label();
            _Label2 = new Label();
            _lblDate = new Label();
            _lblOutcome = new Label();
            _txtDate = new TextBox();
            _txtOutcome = new TextBox();
            _cboStatus = new ComboBox();
            _btnView = new Button();
            _btnView.Click += new EventHandler(btnView_Click);
            _TabControl1 = new TabControl();
            _tpVisitDetails = new TabPage();
            _btnUploadVisit = new Button();
            _btnUploadVisit.Click += new EventHandler(btnUploadVisit_Click);
            _chkSendText = new CheckBox();
            _chkRecharge = new CheckBox();
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click);
            _cbxPartsToFit = new CheckBox();
            _cboExpected = new ComboBox();
            _tpParts = new TabPage();
            _lblAuthCode = new Label();
            _btnGenerateAuthCode = new Button();
            _btnGenerateAuthCode.Click += new EventHandler(btnGenerateAuthCode_Click);
            _btnMoveParts = new Button();
            _btnMoveParts.Click += new EventHandler(btnMoveParts_Click);
            _btnGetOrderRef = new Button();
            _btnGetOrderRef.Click += new EventHandler(btnGetOrderRef_Click);
            _dgPartsAndProducts = new DataGrid();
            _EstVisitDate = new TabPage();
            _Label6 = new Label();
            _dtpEstimateVisitDate = new DateTimePicker();
            _txtPassword = new TextBox();
            _txtPassword.TextChanged += new EventHandler(txtPassword_TextChanged);
            _Label7 = new Label();
            _BtnEstSave = new Button();
            _BtnEstSave.Click += new EventHandler(btnEstSave_Click);
            _cmsPrint = new ContextMenuStrip(components);
            _EngineerJobSheetToolStripMenuItem = new ToolStripMenuItem();
            _EngineerJobSheetToolStripMenuItem.Click += new EventHandler(PrintEngjob);
            _ProForrmaToolStripMenuItem = new ToolStripMenuItem();
            _ProForrmaToolStripMenuItem.Click += new EventHandler(ProForrmaToolStripMenuItem_Click);
            _btnPrintInstall = new ToolStripMenuItem();
            _btnPrintInstall.Click += new EventHandler(btnPrintInstall_Click);
            _BtnPrintServiceLetter = new ToolStripMenuItem();
            _BtnPrintServiceLetter.Click += new EventHandler(BtnPrintServiceLetter_Click);
            _btnPrintJobLetter = new ToolStripMenuItem();
            _btnPrintJobLetter.Click += new EventHandler(btnPrintJobLetter_Click);
            _PrintSolarInstall = new ToolStripMenuItem();
            _PrintSolarInstall.Click += new EventHandler(PrintSolarInstall_Click);
            _PrintElectricalAppointment = new ToolStripMenuItem();
            _PrintElectricalAppointment.Click += new EventHandler(PrintElectricalAppointment_Click);
            _TabControl1.SuspendLayout();
            _tpVisitDetails.SuspendLayout();
            _tpParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPartsAndProducts).BeginInit();
            _EstVisitDate.SuspendLayout();
            _cmsPrint.SuspendLayout();
            SuspendLayout();
            //
            // txtNotesToEngineer
            //
            _txtNotesToEngineer.AcceptsReturn = true;
            _txtNotesToEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotesToEngineer.Location = new Point(78, 8);
            _txtNotesToEngineer.Multiline = true;
            _txtNotesToEngineer.Name = "txtNotesToEngineer";
            _txtNotesToEngineer.ScrollBars = ScrollBars.Vertical;
            _txtNotesToEngineer.Size = new Size(406, 89);
            _txtNotesToEngineer.TabIndex = 0;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 8);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(64, 51);
            _Label1.TabIndex = 1;
            _Label1.Text = "Notes To Engineer";
            //
            // Label2
            //
            _Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label2.Location = new Point(8, 103);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(56, 16);
            _Label2.TabIndex = 2;
            _Label2.Text = "Status";
            //
            // lblDate
            //
            _lblDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblDate.Location = new Point(8, 128);
            _lblDate.Name = "lblDate";
            _lblDate.Size = new Size(56, 16);
            _lblDate.TabIndex = 3;
            _lblDate.Text = "Date";
            //
            // lblOutcome
            //
            _lblOutcome.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblOutcome.Location = new Point(8, 157);
            _lblOutcome.Name = "lblOutcome";
            _lblOutcome.Size = new Size(64, 16);
            _lblOutcome.TabIndex = 4;
            _lblOutcome.Text = "Outcome";
            //
            // txtDate
            //
            _txtDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtDate.Location = new Point(78, 128);
            _txtDate.Name = "txtDate";
            _txtDate.ReadOnly = true;
            _txtDate.Size = new Size(283, 21);
            _txtDate.TabIndex = 4;
            //
            // txtOutcome
            //
            _txtOutcome.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtOutcome.Location = new Point(78, 152);
            _txtOutcome.Name = "txtOutcome";
            _txtOutcome.ReadOnly = true;
            _txtOutcome.Size = new Size(207, 21);
            _txtOutcome.TabIndex = 5;
            //
            // cboStatus
            //
            _cboStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.Location = new Point(78, 101);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(283, 21);
            _cboStatus.TabIndex = 1;
            //
            // btnView
            //
            _btnView.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnView.Location = new Point(388, 184);
            _btnView.Name = "btnView";
            _btnView.Size = new Size(96, 23);
            _btnView.TabIndex = 8;
            _btnView.Text = "View Results";
            //
            // TabControl1
            //
            _TabControl1.Controls.Add(_tpVisitDetails);
            _TabControl1.Controls.Add(_tpParts);
            _TabControl1.Controls.Add(_EstVisitDate);
            _TabControl1.Dock = DockStyle.Fill;
            _TabControl1.Location = new Point(0, 0);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(500, 240);
            _TabControl1.TabIndex = 7;
            //
            // tpVisitDetails
            //
            _tpVisitDetails.Controls.Add(_btnUploadVisit);
            _tpVisitDetails.Controls.Add(_chkSendText);
            _tpVisitDetails.Controls.Add(_chkRecharge);
            _tpVisitDetails.Controls.Add(_btnPrint);
            _tpVisitDetails.Controls.Add(_Label1);
            _tpVisitDetails.Controls.Add(_Label2);
            _tpVisitDetails.Controls.Add(_lblDate);
            _tpVisitDetails.Controls.Add(_txtDate);
            _tpVisitDetails.Controls.Add(_txtOutcome);
            _tpVisitDetails.Controls.Add(_cboStatus);
            _tpVisitDetails.Controls.Add(_btnView);
            _tpVisitDetails.Controls.Add(_txtNotesToEngineer);
            _tpVisitDetails.Controls.Add(_cbxPartsToFit);
            _tpVisitDetails.Controls.Add(_cboExpected);
            _tpVisitDetails.Controls.Add(_lblOutcome);
            _tpVisitDetails.Location = new Point(4, 22);
            _tpVisitDetails.Name = "tpVisitDetails";
            _tpVisitDetails.Size = new Size(492, 214);
            _tpVisitDetails.TabIndex = 0;
            _tpVisitDetails.Text = "Visit Details";
            //
            // btnUploadVisit
            //
            _btnUploadVisit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnUploadVisit.Location = new Point(11, 184);
            _btnUploadVisit.Name = "btnUploadVisit";
            _btnUploadVisit.Size = new Size(104, 23);
            _btnUploadVisit.TabIndex = 13;
            _btnUploadVisit.Text = "Upload Visit";
            //
            // chkSendText
            //
            _chkSendText.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _chkSendText.AutoSize = true;
            _chkSendText.Location = new Point(297, 156);
            _chkSendText.Name = "chkSendText";
            _chkSendText.Size = new Size(187, 17);
            _chkSendText.TabIndex = 12;
            _chkSendText.Text = "Exclude From Auto-Message";
            _chkSendText.UseVisualStyleBackColor = true;
            //
            // chkRecharge
            //
            _chkRecharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _chkRecharge.AutoSize = true;
            _chkRecharge.Location = new Point(395, 130);
            _chkRecharge.Name = "chkRecharge";
            _chkRecharge.Size = new Size(80, 17);
            _chkRecharge.TabIndex = 11;
            _chkRecharge.Text = "Recharge";
            _chkRecharge.UseVisualStyleBackColor = true;
            //
            // btnPrint
            //
            _btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrint.Location = new Point(288, 184);
            _btnPrint.Name = "btnPrint";
            _btnPrint.Size = new Size(96, 23);
            _btnPrint.TabIndex = 7;
            _btnPrint.Text = "Print...";
            //
            // cbxPartsToFit
            //
            _cbxPartsToFit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _cbxPartsToFit.AutoSize = true;
            _cbxPartsToFit.Location = new Point(395, 105);
            _cbxPartsToFit.Name = "cbxPartsToFit";
            _cbxPartsToFit.Size = new Size(89, 17);
            _cbxPartsToFit.TabIndex = 2;
            _cbxPartsToFit.Text = "Parts To Fit";
            _cbxPartsToFit.UseVisualStyleBackColor = true;
            //
            // cboExpected
            //
            _cboExpected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _cboExpected.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboExpected.Location = new Point(78, 64);
            _cboExpected.Name = "cboExpected";
            _cboExpected.Size = new Size(364, 21);
            _cboExpected.TabIndex = 3;
            _cboExpected.Visible = false;
            //
            // tpParts
            //
            _tpParts.Controls.Add(_lblAuthCode);
            _tpParts.Controls.Add(_btnGenerateAuthCode);
            _tpParts.Controls.Add(_btnMoveParts);
            _tpParts.Controls.Add(_btnGetOrderRef);
            _tpParts.Controls.Add(_dgPartsAndProducts);
            _tpParts.Location = new Point(4, 22);
            _tpParts.Name = "tpParts";
            _tpParts.Size = new Size(492, 214);
            _tpParts.TabIndex = 1;
            _tpParts.Text = "Parts && Products Allocated";
            //
            // lblAuthCode
            //
            _lblAuthCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblAuthCode.AutoSize = true;
            _lblAuthCode.Location = new Point(111, 187);
            _lblAuthCode.Name = "lblAuthCode";
            _lblAuthCode.Size = new Size(0, 13);
            _lblAuthCode.TabIndex = 28;
            //
            // btnGenerateAuthCode
            //
            _btnGenerateAuthCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnGenerateAuthCode.Location = new Point(12, 182);
            _btnGenerateAuthCode.Name = "btnGenerateAuthCode";
            _btnGenerateAuthCode.Size = new Size(93, 23);
            _btnGenerateAuthCode.TabIndex = 27;
            _btnGenerateAuthCode.Text = "Auth Code";
            _btnGenerateAuthCode.UseVisualStyleBackColor = true;
            //
            // btnMoveParts
            //
            _btnMoveParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnMoveParts.Location = new Point(340, 6);
            _btnMoveParts.Name = "btnMoveParts";
            _btnMoveParts.Size = new Size(144, 23);
            _btnMoveParts.TabIndex = 26;
            _btnMoveParts.Text = "Reallocate Parts";
            _btnMoveParts.UseVisualStyleBackColor = true;
            //
            // btnGetOrderRef
            //
            _btnGetOrderRef.Location = new Point(9, 6);
            _btnGetOrderRef.Name = "btnGetOrderRef";
            _btnGetOrderRef.Size = new Size(145, 23);
            _btnGetOrderRef.TabIndex = 25;
            _btnGetOrderRef.Text = "Create Quick PO";
            _btnGetOrderRef.UseVisualStyleBackColor = true;
            //
            // dgPartsAndProducts
            //
            _dgPartsAndProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgPartsAndProducts.DataMember = "";
            _dgPartsAndProducts.Font = new Font("Verdana", 8.25F);
            _dgPartsAndProducts.HeaderForeColor = SystemColors.ControlText;
            _dgPartsAndProducts.Location = new Point(8, 33);
            _dgPartsAndProducts.Name = "dgPartsAndProducts";
            _dgPartsAndProducts.Size = new Size(476, 143);
            _dgPartsAndProducts.TabIndex = 1;
            //
            // EstVisitDate
            //
            _EstVisitDate.Controls.Add(_Label6);
            _EstVisitDate.Controls.Add(_dtpEstimateVisitDate);
            _EstVisitDate.Controls.Add(_txtPassword);
            _EstVisitDate.Controls.Add(_Label7);
            _EstVisitDate.Controls.Add(_BtnEstSave);
            _EstVisitDate.Location = new Point(4, 22);
            _EstVisitDate.Name = "EstVisitDate";
            _EstVisitDate.Size = new Size(492, 214);
            _EstVisitDate.TabIndex = 2;
            _EstVisitDate.Text = "Est Visit Date";
            _EstVisitDate.UseVisualStyleBackColor = true;
            //
            // Label6
            //
            _Label6.AutoSize = true;
            _Label6.Location = new Point(11, 56);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(122, 13);
            _Label6.TabIndex = 12;
            _Label6.Text = "Estimated Visit Date";
            //
            // dtpEstimateVisitDate
            //
            _dtpEstimateVisitDate.Enabled = false;
            _dtpEstimateVisitDate.Location = new Point(199, 50);
            _dtpEstimateVisitDate.Name = "dtpEstimateVisitDate";
            _dtpEstimateVisitDate.Size = new Size(176, 21);
            _dtpEstimateVisitDate.TabIndex = 11;
            //
            // txtPassword
            //
            _txtPassword.Location = new Point(199, 22);
            _txtPassword.Name = "txtPassword";
            _txtPassword.PasswordChar = (char)42;
            _txtPassword.Size = new Size(176, 21);
            _txtPassword.TabIndex = 10;
            _txtPassword.UseSystemPasswordChar = true;
            //
            // Label7
            //
            _Label7.AutoSize = true;
            _Label7.Location = new Point(11, 25);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(169, 13);
            _Label7.TabIndex = 9;
            _Label7.Text = "Enter the override password";
            //
            // BtnEstSave
            //
            _BtnEstSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _BtnEstSave.Location = new Point(98, 84);
            _BtnEstSave.Name = "BtnEstSave";
            _BtnEstSave.Size = new Size(96, 23);
            _BtnEstSave.TabIndex = 8;
            _BtnEstSave.Text = "Save";
            //
            // cmsPrint
            //
            _cmsPrint.Items.AddRange(new ToolStripItem[] { _EngineerJobSheetToolStripMenuItem, _ProForrmaToolStripMenuItem, _btnPrintInstall, _BtnPrintServiceLetter, _btnPrintJobLetter, _PrintSolarInstall, _PrintElectricalAppointment });
            _cmsPrint.Name = "cmsPrint";
            _cmsPrint.Size = new Size(224, 158);
            //
            // EngineerJobSheetToolStripMenuItem
            //
            _EngineerJobSheetToolStripMenuItem.Name = "EngineerJobSheetToolStripMenuItem";
            _EngineerJobSheetToolStripMenuItem.Size = new Size(223, 22);
            _EngineerJobSheetToolStripMenuItem.Text = "Engineer Job Sheet";
            //
            // ProForrmaToolStripMenuItem
            //
            _ProForrmaToolStripMenuItem.Name = "ProForrmaToolStripMenuItem";
            _ProForrmaToolStripMenuItem.Size = new Size(223, 22);
            _ProForrmaToolStripMenuItem.Text = "Pro-Forma";
            //
            // btnPrintInstall
            //
            _btnPrintInstall.Name = "btnPrintInstall";
            _btnPrintInstall.Size = new Size(223, 22);
            _btnPrintInstall.Text = "Print Install Sheet";
            //
            // BtnPrintServiceLetter
            //
            _BtnPrintServiceLetter.Name = "BtnPrintServiceLetter";
            _BtnPrintServiceLetter.Size = new Size(223, 22);
            _BtnPrintServiceLetter.Text = "Print Service Letter";
            _BtnPrintServiceLetter.Visible = false;
            //
            // btnPrintJobLetter
            //
            _btnPrintJobLetter.Name = "btnPrintJobLetter";
            _btnPrintJobLetter.Size = new Size(223, 22);
            _btnPrintJobLetter.Text = "Print Appointment Letter";
            //
            // PrintSolarInstall
            //
            _PrintSolarInstall.Name = "PrintSolarInstall";
            _PrintSolarInstall.Size = new Size(223, 22);
            _PrintSolarInstall.Text = "Print Solar Installation ";
            _PrintSolarInstall.Visible = false;
            //
            // PrintElectricalAppointment
            //
            _PrintElectricalAppointment.Name = "PrintElectricalAppointment";
            _PrintElectricalAppointment.Size = new Size(223, 22);
            _PrintElectricalAppointment.Text = "Print Electrical Appointment";
            _PrintElectricalAppointment.Visible = false;
            //
            // UCVisitBreakdown
            //
            AutoScroll = false;
            Controls.Add(_TabControl1);
            Name = "UCVisitBreakdown";
            Size = new Size(500, 240);
            _TabControl1.ResumeLayout(false);
            _tpVisitDetails.ResumeLayout(false);
            _tpVisitDetails.PerformLayout();
            _tpParts.ResumeLayout(false);
            _tpParts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPartsAndProducts).EndInit();
            _EstVisitDate.ResumeLayout(false);
            _EstVisitDate.PerformLayout();
            _cmsPrint.ResumeLayout(false);
            ResumeLayout(false);
        }

        
        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupDG();
        }

        public object LoadedItem
        {
            get
            {
                return EngineerVisit;
            }
        }

        
        

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private UCCalloutBreakdown _onControl = null;

        public UCCalloutBreakdown OnControl
        {
            get
            {
                return _onControl;
            }

            set
            {
                _onControl = value;
            }
        }

        private Entity.EngineerVisits.EngineerVisit _engineerVisit = null;

        public Entity.EngineerVisits.EngineerVisit EngineerVisit
        {
            get
            {
                return _engineerVisit;
            }

            set
            {
                _engineerVisit = value;
                if (_engineerVisit is null)
                {
                    _engineerVisit = new Entity.EngineerVisits.EngineerVisit();
                }
            }
        }

        private DataView _PartsAndProducts = null;

        public DataView PartsAndProducts
        {
            get
            {
                return _PartsAndProducts;
            }

            set
            {
                _PartsAndProducts = value;
                _PartsAndProducts.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
                _PartsAndProducts.AllowNew = false;
                _PartsAndProducts.AllowEdit = false;
                _PartsAndProducts.AllowDelete = false;
                dgPartsAndProducts.DataSource = PartsAndProducts;
            }
        }

        private DataRow SelectedPartProductDataRow
        {
            get
            {
                if (!(dgPartsAndProducts.CurrentRowIndex == -1))
                {
                    return PartsAndProducts[dgPartsAndProducts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private int _PartProductID = 0;

        public int PartProductID
        {
            get
            {
                return _PartProductID;
            }

            set
            {
                _PartProductID = value;
            }
        }

        private string _Type = string.Empty;

        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }

        private ArrayList _PartsProductsToRemoveFromOrder = new ArrayList();

        public ArrayList PartsProductsToRemoveFromOrder
        {
            get
            {
                return _PartsProductsToRemoveFromOrder;
            }

            set
            {
                _PartsProductsToRemoveFromOrder = value;
            }
        }

        private ArrayList _PartsProductsToReallocated = new ArrayList();

        public ArrayList PartsProductsToReallocated
        {
            get
            {
                return _PartsProductsToReallocated;
            }

            set
            {
                _PartsProductsToReallocated = value;
            }
        }

        private bool _change = false;

        public bool change
        {
            get
            {
                return _change;
            }

            set
            {
                _change = value;
            }
        }

        private void UCVisitBreakdown_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnGetOrderRef_Click(object sender, EventArgs e)
        {
            if (EngineerVisit.EngineerVisitID == 0)
            {
                App.ShowMessage("Please save visit before creating order!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TabletOrder dialogue;
            dialogue = (TabletOrder)App.checkIfExists(typeof(TabletOrder).Name, true);
            if (dialogue is null)
            {
                dialogue = (TabletOrder)Activator.CreateInstance(typeof(TabletOrder));
            }

            dialogue.EngineerID = EngineerVisit.EngineerID;
            dialogue.EngineerVisitID = EngineerVisit.EngineerVisitID;
            dialogue.ShowInTaskbar = false;
            dialogue.ShowDialog();
            if (OnControl.OnContol.ParentForm is object)
            {
                OnControl.OnContol.Populate();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            bool @continue = false;
            var switchExpr = EngineerVisit.StatusEnumID;
            switch (switchExpr)
            {
                case (int)(Enums.VisitStatus.NOT_SET):
                    {
                        App.ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case (int)(Enums.VisitStatus.Parts_Need_Ordering):
                    {
                        App.ShowMessage("Parts Need Ordering for this visit, once ordered and received you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case (int)(Enums.VisitStatus.Waiting_For_Parts):
                    {
                        App.ShowMessage("This visit is waiting for parts, once received you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case (int)(Enums.VisitStatus.Parts_Despatched):
                    {
                        App.ShowMessage("This visit is waiting for parts to be received by engineer, once received you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case (int)(Enums.VisitStatus.Ready_For_Schedule):
                    {
                        if (App.ShowMessage("This visit is ready for schedule, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            @continue = true;
                        }

                        break;
                    }

                case (int)(Enums.VisitStatus.Scheduled):
                    {
                        if (App.ShowMessage("This visit is scheduled, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            @continue = true;
                        }

                        break;
                    }

                case (int)(Enums.VisitStatus.Downloaded):
                    {
                        App.ShowMessage("This visit is currently with an engineer, once returned you may view the details.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                default:
                    {
                        @continue = true;
                        break;
                    }
            }

            if (@continue)
            {
                App.ShowForm(typeof(FRMEngineerVisit), true, new object[] { EngineerVisit.EngineerVisitID, this });
                if (OnControl.OnContol.ParentForm is object)
                {
                    OnControl.OnContol.Populate();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            cmsPrint.Show(btnPrint, new Point(0, 0)); // Show new ContextStrip instead of a single button click
        }

        private void PrintEngjob(object sender, EventArgs e)
        {
            var details = new ArrayList();
            details.Add(EngineerVisit);
            var oPrint = new Printing(details, "Engineer Jobsheet ", Enums.SystemDocumentType.SVR);
        }

        private void btnPrintInstall_Click(object sender, EventArgs e)
        {
            var details = new ArrayList();
            details.Add(EngineerVisit);
            var oPrint = new Printing(details, "Install ", Enums.SystemDocumentType.Install);
        }

        
        

        public void SetupDG()
        {
            Helper.SetUpDataGrid(dgPartsAndProducts);
            var tStyle = dgPartsAndProducts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var supplier = new DataGridLabelColumn();
            supplier.Format = "";
            supplier.FormatInfo = null;
            supplier.HeaderText = "Supplier";
            supplier.MappingName = "Supplier";
            supplier.ReadOnly = true;
            supplier.Width = 80;
            supplier.NullText = "";
            tStyle.GridColumnStyles.Add(supplier);
            var type = new DataGridLabelColumn();
            type.Format = "";
            type.FormatInfo = null;
            type.HeaderText = "Type";
            type.MappingName = "type";
            type.ReadOnly = true;
            type.Width = 60;
            type.NullText = "";
            tStyle.GridColumnStyles.Add(type);
            var number = new DataGridLabelColumn();
            number.Format = "";
            number.FormatInfo = null;
            number.HeaderText = "Number";
            number.MappingName = "number";
            number.ReadOnly = true;
            number.Width = 80;
            number.NullText = "";
            tStyle.GridColumnStyles.Add(number);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 140;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var quantity = new DataGridLabelColumn();
            quantity.Format = "";
            quantity.FormatInfo = null;
            quantity.HeaderText = "Qty";
            quantity.MappingName = "quantity";
            quantity.ReadOnly = true;
            quantity.Width = 50;
            quantity.NullText = "";
            tStyle.GridColumnStyles.Add(quantity);
            var sellPrice = new DataGridLabelColumn();
            sellPrice.Format = "C";
            sellPrice.FormatInfo = null;
            sellPrice.HeaderText = "Buy Price";
            sellPrice.MappingName = "sellPrice";
            sellPrice.ReadOnly = true;
            sellPrice.Width = 75;
            sellPrice.NullText = "";
            tStyle.GridColumnStyles.Add(sellPrice);
            var OrderReference = new DataGridLabelColumn();
            OrderReference.Format = "";
            OrderReference.FormatInfo = null;
            OrderReference.HeaderText = "Order Ref.";
            OrderReference.MappingName = "OrderReference";
            OrderReference.ReadOnly = true;
            OrderReference.Width = 75;
            OrderReference.NullText = "N/A";
            tStyle.GridColumnStyles.Add(OrderReference);
            var OrderStatus = new DataGridLabelColumn();
            OrderStatus.Format = "";
            OrderStatus.FormatInfo = null;
            OrderStatus.HeaderText = "Order Status";
            OrderStatus.MappingName = "OrderStatus";
            OrderStatus.ReadOnly = true;
            OrderStatus.Width = 75;
            OrderStatus.NullText = "N/A";
            tStyle.GridColumnStyles.Add(OrderStatus);
            var QuantityOrdered = new DataGridLabelColumn();
            QuantityOrdered.Format = "";
            QuantityOrdered.FormatInfo = null;
            QuantityOrdered.HeaderText = "Qty Ordered";
            QuantityOrdered.MappingName = "QuantityOrdered";
            QuantityOrdered.ReadOnly = true;
            QuantityOrdered.Width = 75;
            QuantityOrdered.NullText = "N/A";
            tStyle.GridColumnStyles.Add(QuantityOrdered);
            var QuantityReceived = new DataGridLabelColumn();
            QuantityReceived.Format = "";
            QuantityReceived.FormatInfo = null;
            QuantityReceived.HeaderText = "Order Qty Received";
            QuantityReceived.MappingName = "QuantityReceived";
            QuantityReceived.ReadOnly = true;
            QuantityReceived.Width = 75;
            QuantityReceived.NullText = "N/A";
            tStyle.GridColumnStyles.Add(QuantityReceived);
            var CreditQty = new DataGridLabelColumn();
            CreditQty.Format = "";
            CreditQty.FormatInfo = null;
            CreditQty.HeaderText = "Qty Credit";
            CreditQty.MappingName = "CreditQty";
            CreditQty.ReadOnly = true;
            CreditQty.Width = 75;
            CreditQty.NullText = "0";
            tStyle.GridColumnStyles.Add(CreditQty);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
            dgPartsAndProducts.TableStyles.Add(tStyle);
        }

        
        

        public void Populate(int ID = 0)
        {
            var argc = cboExpected;
            Combo.SetUpCombo(ref argc, OnControl.OnContol.DvEngineers.Table, "EngineerID", "Name", Enums.ComboValues.Not_Applicable);
            var argcombo = cboExpected;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, EngineerVisit.ExpectedEngineerID.ToString());
            if (Information.IsDBNull(EngineerVisit.EstimatedDate))
            {
                dtpEstimateVisitDate.Value = DateAndTime.Today;
            }
            else
            {
                dtpEstimateVisitDate.Value = EngineerVisit.EstimatedDate;
            }

            if (EngineerVisit.ExpectedEngineerID == 0)
            {
                cboExpected.Enabled = true;
            }
            else
            {
                cboExpected.Enabled = false;
            }

            var switchExpr = EngineerVisit.StatusEnumID;
            switch (switchExpr)
            {
                case (int)(Enums.VisitStatus.NOT_SET):
                case (int)(Enums.VisitStatus.Parts_Need_Ordering):
                case (int)(Enums.VisitStatus.Waiting_For_Parts):
                case (int)(Enums.VisitStatus.Parts_Despatched):
                    {
                        var argc1 = cboStatus;
                        Combo.SetUpCombo(ref argc1, DynamicDataTables.VisitStatus_For_Selection, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
                        var argcombo1 = cboStatus;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo1, EngineerVisit.StatusEnumID.ToString());
                        cbxPartsToFit.Checked = EngineerVisit.PartsToFit;
                        chkRecharge.Checked = false;
                        cboStatus.Enabled = true;
                        cbxPartsToFit.Enabled = true;
                        chkRecharge.Enabled = true;
                        btnMoveParts.Enabled = true;
                        txtNotesToEngineer.ReadOnly = false;
                        txtDate.Text = "Not Set";
                        txtOutcome.Text = "Not Set";
                        txtDate.Visible = false;
                        txtOutcome.Visible = false;
                        btnView.Visible = false;
                        btnPrintInstall.Visible = false;
                        lblDate.Visible = false;
                        lblOutcome.Visible = false;
                        break;
                    }

                case (int)(Enums.VisitStatus.Ready_For_Schedule):
                    {
                        var argc2 = cboStatus;
                        Combo.SetUpCombo(ref argc2, DynamicDataTables.VisitStatus_For_Selection, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
                        var argcombo2 = cboStatus;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo2, EngineerVisit.StatusEnumID.ToString());
                        cbxPartsToFit.Checked = EngineerVisit.PartsToFit;
                        cboStatus.Enabled = true;
                        cbxPartsToFit.Enabled = true;
                        chkRecharge.Enabled = true;
                        btnMoveParts.Enabled = true;
                        cboExpected.Enabled = false;
                        txtNotesToEngineer.ReadOnly = false;
                        txtDate.Text = "Not Set";
                        txtOutcome.Text = "Not Set";
                        txtDate.Visible = false;
                        lblDate.Visible = false;
                        lblOutcome.Visible = false;
                        txtOutcome.Visible = false;
                        btnView.Visible = true;
                        btnPrintInstall.Visible = true;
                        break;
                    }

                case (int)(Enums.VisitStatus.Scheduled):
                case (int)(Enums.VisitStatus.Downloaded):
                    {
                        var argc3 = cboStatus;
                        Combo.SetUpCombo(ref argc3, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
                        var argcombo3 = cboStatus;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo3, EngineerVisit.StatusEnumID.ToString());
                        cbxPartsToFit.Checked = EngineerVisit.PartsToFit;
                        cboStatus.Enabled = false;
                        cbxPartsToFit.Enabled = false;
                        chkRecharge.Enabled = false;
                        btnMoveParts.Enabled = false;
                        cboExpected.Enabled = false;
                        txtOutcome.Text = "Not Set";
                        txtNotesToEngineer.ReadOnly = false;
                        txtDate.Visible = true;
                        lblDate.Visible = true;
                        lblOutcome.Visible = false;
                        txtOutcome.Visible = false;
                        btnView.Visible = true;
                        btnPrintInstall.Visible = true;

                        // check if the visit is more than one days
                        int totalDays = DateHelper.GetDays(EngineerVisit.StartDateTime, EngineerVisit.EndDateTime);
                        if (totalDays > 0)
                        {
                            txtDate.Text = EngineerVisit.StartDateTime.ToShortDateString() + " - " + EngineerVisit.EndDateTime.ToShortDateString() + " - " + App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)?.Name;
                        }
                        else if (EngineerVisit.StartDateTime != default)
                        {
                            txtDate.Text = EngineerVisit.StartDateTime.ToShortDateString() + " - " + App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)?.Name;
                        }

                        if ((EngineerVisit.VisitNumber > 0 | OnControl.OnContol.Job?.JobTypeID == Conversions.ToInteger(Enums.JobTypes.ServiceCertificate) | OnControl.OnContol.Job?.JobTypeID == Conversions.ToInteger(Enums.JobTypes.Service)) == true)
                        {
                            BtnPrintServiceLetter.Visible = true;
                        }

                        PrintSolarInstall.Visible = true;
                        PrintElectricalAppointment.Visible = true;
                        break;
                    }

                case (int)(Enums.VisitStatus.Uploaded):
                case (int)(Enums.VisitStatus.Not_To_Be_Invoiced):
                case (int)(Enums.VisitStatus.Ready_To_Be_Invoiced):
                case (int)(Enums.VisitStatus.Invoiced):
                    {
                        var argc4 = cboStatus;
                        Combo.SetUpCombo(ref argc4, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
                        var argcombo4 = cboStatus;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo4, EngineerVisit.StatusEnumID.ToString());
                        cbxPartsToFit.Checked = EngineerVisit.PartsToFit;
                        cboStatus.Enabled = false;
                        cbxPartsToFit.Enabled = false;
                        chkRecharge.Enabled = false;
                        btnMoveParts.Enabled = true;
                        btnView.Enabled = true;
                        cboExpected.Enabled = false;
                        chkSendText.Visible = false;
                        txtNotesToEngineer.ReadOnly = true;
                        txtDate.Visible = true;
                        txtOutcome.Visible = true;
                        lblDate.Visible = true;
                        lblOutcome.Visible = true;
                        btnPrintInstall.Visible = false;

                        // check if the visit is more than one days
                        int totalDays = DateHelper.GetDays(EngineerVisit.StartDateTime, EngineerVisit.EndDateTime);
                        if (EngineerVisit.StartDateTime == default)
                        {
                            txtDate.Text = Strings.Format(EngineerVisit.ManualEntryOn, "dd/MMM/yyyy") + " (Manually Completed)";
                            if (totalDays > 0)
                            {
                                txtDate.Text = EngineerVisit.StartDateTime.ToShortDateString() + " - " + EngineerVisit.EndDateTime.ToShortDateString() + " - " + "(Manually Completed)";
                            }
                        }
                        else
                        {
                            var eng = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
                            if (eng is null)
                            {
                                txtDate.Text = Strings.Format(EngineerVisit.StartDateTime, "dd/MMM/yyyy");
                                if (totalDays > 0)
                                {
                                    txtDate.Text = EngineerVisit.StartDateTime.ToShortDateString() + " - " + EngineerVisit.EndDateTime.ToShortDateString();
                                }
                            }
                            else
                            {
                                txtDate.Text = Strings.Format(EngineerVisit.StartDateTime, "dd/MMM/yyyy") + " - " + eng.Name;
                                if (totalDays > 0)
                                {
                                    txtDate.Text = EngineerVisit.StartDateTime.ToShortDateString() + " - " + EngineerVisit.EndDateTime.ToShortDateString() + " - " + eng.Name;
                                }
                            }
                        }

                        if ((EngineerVisit.VisitNumber > 0 | OnControl.OnContol.Job?.JobTypeID == Conversions.ToInteger(Enums.JobTypes.ServiceCertificate) | OnControl.OnContol.Job?.JobTypeID == Conversions.ToInteger(Enums.JobTypes.Service)) == true)
                        {
                            BtnPrintServiceLetter.Visible = true;
                        }

                        PrintSolarInstall.Visible = true;
                        PrintElectricalAppointment.Visible = true;
                        var switchExpr1 = EngineerVisit.OutcomeEnumID;
                        switch (switchExpr1)
                        {
                            case (int)(Enums.EngineerVisitOutcomes.NOT_SET):
                                {
                                    txtOutcome.Text = "Not Set";
                                    break;
                                }

                            case (int)(Enums.EngineerVisitOutcomes.Complete):
                                {
                                    txtOutcome.Text = "Complete";
                                    break;
                                }

                            case (int)(Enums.EngineerVisitOutcomes.Carded):
                                {
                                    txtOutcome.Text = "Carded";
                                    break;
                                }

                            case (int)(Enums.EngineerVisitOutcomes.Could_Not_Start):
                                {
                                    txtOutcome.Text = "Could Not Start";
                                    break;
                                }

                            case (int)(Enums.EngineerVisitOutcomes.Declined):
                                {
                                    txtOutcome.Text = "Declined";
                                    break;
                                }

                            case (int)(Enums.EngineerVisitOutcomes.Further_Works):
                                {
                                    txtOutcome.Text = "Further Works";
                                    break;
                                }

                            case (int)(Enums.EngineerVisitOutcomes.Visit_Not_Required):
                                {
                                    txtOutcome.Text = "Visit Not Required";
                                    break;
                                }
                        }

                        break;
                    }
            }

            if (EngineerVisit.StatusEnumID == (int)Enums.VisitStatus.Downloaded)
            {
                btnGenerateAuthCode.Visible = true;
                lblAuthCode.Visible = true;
                btnUploadVisit.Visible = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.IT);
            }
            else
            {
                btnGenerateAuthCode.Visible = false;
                lblAuthCode.Visible = false;
                btnUploadVisit.Visible = false;
            }

            chkRecharge.Checked = EngineerVisit.Recharge;
            chkSendText.Checked = EngineerVisit.ExcludeFromTextMessage;
            txtNotesToEngineer.Text = EngineerVisit.NotesToEngineer;
            cbxPartsToFit.Visible = true;
            if (OnControl.OnContol.Job.StatusEnumID >= Conversions.ToInteger(Enums.JobStatus.Complete))
            {
                cboStatus.Enabled = false;
                txtNotesToEngineer.Enabled = false;
                cboExpected.Enabled = false;
            }

            var drPartsAndProducts = OnControl.OnContol.DvEngineerVisitsPartsAllocated.Table.Select("EngineerVisitId = " + EngineerVisit.EngineerVisitID);
            var dtPartsProducts = OnControl.OnContol.DvEngineerVisitsPartsAllocated.Table.Clone();
            if (drPartsAndProducts.Length > 0)
            {
                dtPartsProducts = drPartsAndProducts.CopyToDataTable();
            }

            PartsAndProducts = new DataView(dtPartsProducts);
            change = false;
        }

        public bool Save()
        {
            return default;
            // DO NOTHING
        }

        public void SendToPrint(string fileName = "")
        {
            DataRow dr = null;
            var lm = App.DB.LetterManager.MakeServiceLetter(EngineerVisit.EngineerVisitID);
            lm.Table.Columns.Add("FileName");
            if (lm.Count > 0 & string.IsNullOrEmpty(fileName))
            {
                dr = lm.Table.Rows[0];
            }
            else
            {
                var site = OnControl.OnContol.Site;
                var dt = lm.Table.Clone();
                dr = dt.NewRow();
                dr["Name"] = site.Name;
                dr["Address1"] = site.Address1;
                dr["Address2"] = site.Address2;
                dr["Address3"] = site.Address3;
                dr["Address4"] = site.Address4;
                dr["Address5"] = site.Address5;
                dr["Postcode"] = site.Postcode;
                dr["SiteID"] = site.SiteID;
                dr["CustomerID"] = site.CustomerID;
                dr["SolidFuel"] = site.SolidFuel;
                dr["PropertyVoid"] = site.PropertyVoid;
                dr["LastServiceDate"] = site.LastServiceDate;
                dr["CommercialDistrict"] = site.CommercialDistrict;
                dr["SiteFuel"] = site.SiteFuel;
                dr["Type"] = "Generic";
                dr["NextVisitDate"] = EngineerVisit.StartDateTime;
                dr["StartDateTime"] = EngineerVisit.StartDateTime;
                dr["AMPM"] = "";
                dr["JobID"] = OnControl.OnContol.Job.JobID;
                dr["JobNumber"] = OnControl.OnContol.Job.JobNumber;
                dr["FileName"] = fileName;
                dt.Rows.Add(dr);
                dr = dt.Rows[0];
            }

            var details = new ArrayList();
            details.Add(dr);
            var oPrint = new Printing(details, "Service Letter", Enums.SystemDocumentType.ServiceLetters);
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Type"], "Letter 2", false)))
            {
                dr["Type"] = "Letter 2 HAND";
                details.Clear();
                details.Add(dr);
                oPrint = new Printing(details, "Service Letter", Enums.SystemDocumentType.ServiceLetters);
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Type"], "Letter 3", false)))
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["CommercialDistrict"], "1", false)))
                {
                    dr["Type"] = "Letter 3 COM HAND";
                }
                else
                {
                    dr["Type"] = "Letter 3 HAND";
                }

                details.Clear();
                details.Add(dr);
                oPrint = new Printing(details, "Service Letter", Enums.SystemDocumentType.ServiceLetters);
            }
        }

        private void btnEstSave_Click(object sender, EventArgs e)
        {
            App.DB.EngineerVisits.AlterEstimatedDate(EngineerVisit.JobOfWorkID, Conversions.ToDate(dtpEstimateVisitDate.Value));
            dtpEstimateVisitDate.Enabled = false;
            txtPassword.Text = "";
            BtnEstSave.Enabled = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if ((Helper.HashPassword(txtPassword.Text.Trim()) ?? "") == (App.DB.Manager.Get().OverridePassword ?? ""))
            {
                dtpEstimateVisitDate.Enabled = true;
                BtnEstSave.Enabled = true;
            }
            else
            {
                dtpEstimateVisitDate.Enabled = false;
                BtnEstSave.Enabled = false;
            }
        }

        private void btnMoveParts_Click(object sender, EventArgs e)
        {
            if (EngineerVisit is null || EngineerVisit.EngineerVisitID == 0)
                return;
            var f = new FRMMoveParts();
            f.EngineerVisitId = EngineerVisit.EngineerVisitID;
            f.JobNumber = OnControl.OnContol.Job.JobNumber;
            f.ShowDialog();
            int returnValue = Conversions.ToInteger(Combo.get_GetSelectedItemValue(f.cboVisit));
            if (returnValue > 0)
            {
                if (App.DB.EngineerVisits.MoveParts(EngineerVisit.EngineerVisitID, returnValue))
                {
                    App.ShowMessage("Parts have been moved, please refresh window!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    App.ShowMessage("No parts have been moved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtNotesToEngineer_TextChanged(object sender, EventArgs e)
        {
            change = true;
        }

        private void BtnPrintServiceLetter_Click(object sender, EventArgs e)
        {
            SendToPrint();
        }

        private void ProForrmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var details = new ArrayList();
            var Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);
            details.Add("JOB");
            details.Add(Job);
            var f = new FRMInvoiceExtraDetail();
            f.ShowDialog();
            details.Add(f.txtNotes.Text);
            details.Add(double.TryParse(f.txtCharge.Text, out double val) ? val : 0.0);
            details.Add(App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(f.cbo))).VATRate);
            var oPrint = new Printing(details, "ProFormaFromVisit", Enums.SystemDocumentType.ProFormaFromVisit, true);
        }

        private void btnGenerateAuthCode_Click(object sender, EventArgs e)
        {
            var authCode = default(int);
            if (EngineerVisit.EngineerVisitID > 0 | EngineerVisit.EngineerID > 0)
            {
                authCode = Conversions.ToInteger(Math.Ceiling((EngineerVisit.EngineerVisitID + EngineerVisit.EngineerID) / (double)DateAndTime.Now.Hour));
            }

            lblAuthCode.Text = authCode.ToString();
        }

        private void btnPrintJobLetter_Click(object sender, EventArgs e)
        {
            if (EngineerVisit is object & EngineerVisit.EngineerVisitID > 0)
            {
                var Job = OnControl.OnContol.Job;
                var dvJobImportProcess = App.DB.JobImports.JobImport_Get_ByJobNumber(Job.JobNumber);
                if (dvJobImportProcess.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var details = new ArrayList();
                    details.Add(dvJobImportProcess.Table);
                    var print = new Printing(details, Conversions.ToString(dvJobImportProcess.Table.Rows[0]["Type"]), Enums.SystemDocumentType.JobImportLetters, false, 0, true);
                    Process.Start(print.EmailWP());
                    Cursor.Current = Cursors.Default;
                    return;
                }

                var Site = OnControl.OnContol.Site;
                if (Site is object && Job.JobTypeID == (int)Enums.JobTypes.Remedial)
                {
                    var switchExpr = Site.CustomerID;
                    switch (switchExpr)
                    {
                        case (int)Enums.Customer.Suffolk:
                        case (int)Enums.Customer.Flagship:
                        case (int)Enums.Customer.Victory:
                        case (int)Enums.Customer.NCC:
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                var dt = dvJobImportProcess.Table.Clone();
                                var dr = dt.NewRow();
                                dr["Name"] = Site.Name;
                                dr["Address1"] = Site.Address1.Trim();
                                dr["Address2"] = Site.Address2.Trim();
                                dr["Address3"] = Site.Address3.Trim();
                                dr["Postcode"] = Site.Postcode.Trim();
                                dr["TelNo"] = Site.TelephoneNum.Trim();
                                dr["JobImportID"] = 0;
                                dr["SiteID"] = Site.SiteID;
                                dr["UPRN"] = Site.PolicyNumber.Trim();
                                dr["JobImportTypeID"] = 0;
                                var switchExpr1 = Site.CustomerID;
                                switch (switchExpr1)
                                {
                                    case (int)Enums.Customer.Flagship:
                                        {
                                            dr["Type"] = "FHG-REMEDIAL";
                                            break;
                                        }

                                    case (int)Enums.Customer.Victory:
                                        {
                                            dr["Type"] = "VHT-REMEDIAL";
                                            break;
                                        }

                                    case (int)Enums.Customer.Suffolk:
                                        {
                                            dr["Type"] = "SHS-REMEDIAL";
                                            break;
                                        }

                                    case (int)Enums.Customer.NCC:
                                        {
                                            dr["Type"] = "NCC-REMEDIAL";
                                            break;
                                        }
                                }

                                dr["Dateadded"] = DateAndTime.Now;
                                dr["JobID"] = Job.JobID;
                                dr["JobNumber"] = Job.JobNumber;
                                dr["Status"] = 0;
                                var visitDate = EngineerVisit.StartDateTime != default ? EngineerVisit.StartDateTime : Job.DateCreated;
                                dr["BookedVisit"] = visitDate;
                                dr["Letter1"] = visitDate;
                                dr["Letter2"] = visitDate;
                                dr["Report"] = 0;
                                dr["Deleted"] = 0;
                                dt.Rows.Add(dr);
                                var details = new ArrayList();
                                details.Add(dt);
                                details.Add(EngineerVisit);
                                var print = new Printing(details, Conversions.ToString(dt.Rows[0]["Type"]), Enums.SystemDocumentType.JobImportLetters, false, 0, true);
                                Process.Start(print.EmailWP());
                                Cursor.Current = Cursors.Default;
                                return;
                            }

                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }

        private void btnUploadVisit_Click(object sender, EventArgs e)
        {
            if (EngineerVisit is object)
            {
                EngineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Uploaded);
                EngineerVisit.SetOutcomeEnumID = Conversions.ToInteger(Enums.EngineerVisitOutcomes.Visit_Not_Required);
                EngineerVisit.SetNotesFromEngineer = "Manually Uploaded by " + App.loggedInUser.Fullname;
                App.DB.EngineerVisits.EngineerVisit_ManualUpload(EngineerVisit);
                Populate();
            }
        }

        private void PrintSolarInstall_Click(object sender, EventArgs e)
        {
            SendToPrint(@"\ServiceLetters\SolarAppointment.docx");
        }

        private void PrintElectricalAppointment_Click(object sender, EventArgs e)
        {
            SendToPrint(@"\ServiceLetters\ElectricalTestingLetter.docx");
        }
    }
}