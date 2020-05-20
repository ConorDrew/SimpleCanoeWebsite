using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMLogCallout : FRMBaseForm, IForm
    {
        public FRMLogCallout() : base()
        {
            base.Load += FRMLogCallout_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            TheLoadedControl = new UCLogCallout();
            tpMain.Controls.Add((Control)TheLoadedControl);
            LoadedControl.StateChanged += ResetMe;
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
        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
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

        private TabPage _tpMain;

        internal TabPage tpMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpMain != null)
                {
                }

                _tpMain = value;
                if (_tpMain != null)
                {
                }
            }
        }

        private TabPage _tpDocuments;

        internal TabPage tpDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpDocuments != null)
                {
                }

                _tpDocuments = value;
                if (_tpDocuments != null)
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

        private TabPage _tpAssets;

        internal TabPage tpAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpAssets != null)
                {
                }

                _tpAssets = value;
                if (_tpAssets != null)
                {
                }
            }
        }

        private DataGrid _dgAssets;

        internal DataGrid dgAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAssets != null)
                {
                    _dgAssets.Click -= dgAssets_Click;
                }

                _dgAssets = value;
                if (_dgAssets != null)
                {
                    _dgAssets.Click += dgAssets_Click;
                }
            }
        }

        private Button _btnAddAppliance;

        internal Button btnAddAppliance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddAppliance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddAppliance != null)
                {
                    _btnAddAppliance.Click -= btnAddAppliance_Click;
                }

                _btnAddAppliance = value;
                if (_btnAddAppliance != null)
                {
                    _btnAddAppliance.Click += btnAddAppliance_Click;
                }
            }
        }

        private GroupBox _grpAssets;

        private TabPage _tpNotes;

        internal TabPage tpNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpNotes != null)
                {
                }

                _tpNotes = value;
                if (_tpNotes != null)
                {
                }
            }
        }

        private GroupBox _gpbNotes;

        internal GroupBox gpbNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbNotes != null)
                {
                }

                _gpbNotes = value;
                if (_gpbNotes != null)
                {
                }
            }
        }

        private DataGrid _dgNotes;

        internal DataGrid dgNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgNotes != null)
                {
                    _dgNotes.Click -= dgNotes_Click;
                    _dgNotes.CurrentCellChanged -= dgNotes_Click;
                }

                _dgNotes = value;
                if (_dgNotes != null)
                {
                    _dgNotes.Click += dgNotes_Click;
                    _dgNotes.CurrentCellChanged += dgNotes_Click;
                }
            }
        }

        private Button _btnAddNote;

        internal Button btnAddNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddNote != null)
                {
                    _btnAddNote.Click -= btnAddNote_Click;
                }

                _btnAddNote = value;
                if (_btnAddNote != null)
                {
                    _btnAddNote.Click += btnAddNote_Click;
                }
            }
        }

        private GroupBox _gpbNotesDetails;

        internal GroupBox gpbNotesDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbNotesDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbNotesDetails != null)
                {
                }

                _gpbNotesDetails = value;
                if (_gpbNotesDetails != null)
                {
                }
            }
        }

        private TextBox _txtNoteID;

        internal TextBox txtNoteID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNoteID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNoteID != null)
                {
                }

                _txtNoteID = value;
                if (_txtNoteID != null)
                {
                }
            }
        }

        private Button _btnSaveNote;

        internal Button btnSaveNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveNote != null)
                {
                    _btnSaveNote.Click -= btnSaveNote_Click;
                }

                _btnSaveNote = value;
                if (_btnSaveNote != null)
                {
                    _btnSaveNote.Click += btnSaveNote_Click;
                }
            }
        }

        private TextBox _txtNotes;

        internal TextBox txtNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotes != null)
                {
                }

                _txtNotes = value;
                if (_txtNotes != null)
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

        private Button _btnDeleteNote;

        internal Button btnDeleteNote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteNote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteNote != null)
                {
                    _btnDeleteNote.Click -= btnDeleteNote_Click;
                }

                _btnDeleteNote = value;
                if (_btnDeleteNote != null)
                {
                    _btnDeleteNote.Click += btnDeleteNote_Click;
                }
            }
        }

        private TabPage _tbquote;

        internal TabPage tbquote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tbquote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tbquote != null)
                {
                }

                _tbquote = value;
                if (_tbquote != null)
                {
                }
            }
        }

        private GroupBox _GroupBox2;

        private ContextMenuStrip _cmsView;

        internal ContextMenuStrip cmsView
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsView;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsView != null)
                {
                }

                _cmsView = value;
                if (_cmsView != null)
                {
                }
            }
        }

        private ToolStripMenuItem _PropertyToolStripMenuItem;

        private ToolStripMenuItem _CustomerToolStripMenuItem;

        private ToolStripMenuItem _AuditTrailToolStripMenuItem;

        internal ToolStripMenuItem AuditTrailToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AuditTrailToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AuditTrailToolStripMenuItem != null)
                {
                    _AuditTrailToolStripMenuItem.Click -= AuditTrailToolStripMenuItem_Click;
                }

                _AuditTrailToolStripMenuItem = value;
                if (_AuditTrailToolStripMenuItem != null)
                {
                    _AuditTrailToolStripMenuItem.Click += AuditTrailToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _OrdersToolStripMenuItem;

        internal ToolStripMenuItem OrdersToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OrdersToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OrdersToolStripMenuItem != null)
                {
                    _OrdersToolStripMenuItem.Click -= OrdersToolStripMenuItem_Click;
                }

                _OrdersToolStripMenuItem = value;
                if (_OrdersToolStripMenuItem != null)
                {
                    _OrdersToolStripMenuItem.Click += OrdersToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _InvoiceToolStripMenuItem;

        internal ToolStripMenuItem InvoiceToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _InvoiceToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_InvoiceToolStripMenuItem != null)
                {
                    _InvoiceToolStripMenuItem.Click -= InvoiceToolStripMenuItem_Click;
                }

                _InvoiceToolStripMenuItem = value;
                if (_InvoiceToolStripMenuItem != null)
                {
                    _InvoiceToolStripMenuItem.Click += InvoiceToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _QuoteToolStripMenuItem;

        internal ToolStripMenuItem QuoteToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _QuoteToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_QuoteToolStripMenuItem != null)
                {
                    _QuoteToolStripMenuItem.Click -= QuoteToolStripMenuItem_Click;
                }

                _QuoteToolStripMenuItem = value;
                if (_QuoteToolStripMenuItem != null)
                {
                    _QuoteToolStripMenuItem.Click += QuoteToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _CostingsToolStripMenuItem;

        internal ToolStripMenuItem CostingsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CostingsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CostingsToolStripMenuItem != null)
                {
                    _CostingsToolStripMenuItem.Click -= CostingsToolStripMenuItem_Click;
                }

                _CostingsToolStripMenuItem = value;
                if (_CostingsToolStripMenuItem != null)
                {
                    _CostingsToolStripMenuItem.Click += CostingsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _HistoryToolStripMenuItem;

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

        private RadioButton _rdoAXA;

        internal RadioButton rdoAXA
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoAXA;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoAXA != null)
                {
                    _rdoAXA.CheckedChanged -= rdoCust_CheckedChanged;
                }

                _rdoAXA = value;
                if (_rdoAXA != null)
                {
                    _rdoAXA.CheckedChanged += rdoCust_CheckedChanged;
                }
            }
        }

        private RadioButton _rdoPOC;

        internal RadioButton rdoPOC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoPOC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoPOC != null)
                {
                    _rdoPOC.CheckedChanged -= rdoCust_CheckedChanged;
                }

                _rdoPOC = value;
                if (_rdoPOC != null)
                {
                    _rdoPOC.CheckedChanged += rdoCust_CheckedChanged;
                }
            }
        }

        private Panel _Panel1;

        private CheckBox _chkExcludeVat;

        internal CheckBox chkExcludeVat
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkExcludeVat;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkExcludeVat != null)
                {
                }

                _chkExcludeVat = value;
                if (_chkExcludeVat != null)
                {
                }
            }
        }

        private ComboBox _cboVATRate;

        internal ComboBox cboVATRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVATRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboVATRate != null)
                {
                }

                _cboVATRate = value;
                if (_cboVATRate != null)
                {
                }
            }
        }

        private Label _lblVAT;

        private GroupBox _GroupBox3;

        private RadioButton _rbStandard;

        internal RadioButton rbStandard
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbStandard;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbStandard != null)
                {
                }

                _rbStandard = value;
                if (_rbStandard != null)
                {
                }
            }
        }

        private RadioButton _rbSite;

        private TextBox _txtPartQty;

        internal TextBox txtPartQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartQty != null)
                {
                }

                _txtPartQty = value;
                if (_txtPartQty != null)
                {
                }
            }
        }

        private Label _Label46;

        private DataGridView _dgvQuote;

        internal DataGridView dgvQuote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvQuote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvQuote != null)
                {
                }

                _dgvQuote = value;
                if (_dgvQuote != null)
                {
                }
            }
        }

        private ComboBox _cboLabour;

        internal ComboBox cboLabour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLabour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLabour != null)
                {
                }

                _cboLabour = value;
                if (_cboLabour != null)
                {
                }
            }
        }

        private Button _btnQuoteAdd;

        private Label _Label45;

        private TextBox _txtLabourQty;

        internal TextBox txtLabourQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLabourQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLabourQty != null)
                {
                }

                _txtLabourQty = value;
                if (_txtLabourQty != null)
                {
                }
            }
        }

        private Label _Label44;

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

        private Button _btnaddtonotes;

        internal Button btnaddtonotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnaddtonotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnaddtonotes != null)
                {
                    _btnaddtonotes.Click -= btnaddtonotes_Click;
                }

                _btnaddtonotes = value;
                if (_btnaddtonotes != null)
                {
                    _btnaddtonotes.Click += btnaddtonotes_Click;
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

        private Button _btncalc;

        internal Button btncalc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btncalc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btncalc != null)
                {
                    _btncalc.Click -= btncalc_Click;
                }

                _btncalc = value;
                if (_btncalc != null)
                {
                    _btncalc.Click += btncalc_Click;
                }
            }
        }

        private TextBox _tbresult;

        internal TextBox tbresult
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tbresult;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tbresult != null)
                {
                }

                _tbresult = value;
                if (_tbresult != null)
                {
                }
            }
        }

        private TextBox _txtPartRate;

        internal TextBox txtPartRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartRate != null)
                {
                }

                _txtPartRate = value;
                if (_txtPartRate != null)
                {
                }
            }
        }

        private Label _lbltc1;

        private TextBox _txtPartNumber;

        internal TextBox txtPartNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartNumber != null)
                {
                }

                _txtPartNumber = value;
                if (_txtPartNumber != null)
                {
                }
            }
        }

        private Label _lblnumber1;

        private TextBox _txtPartName;

        internal TextBox txtPartName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartName != null)
                {
                }

                _txtPartName = value;
                if (_txtPartName != null)
                {
                }
            }
        }

        private Label _lblpart1;

        private TextBox _txtClaimLimit;

        internal TextBox txtClaimLimit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtClaimLimit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtClaimLimit != null)
                {
                }

                _txtClaimLimit = value;
                if (_txtClaimLimit != null)
                {
                }
            }
        }

        private TabPage _tpContactAttempts;

        internal TabPage tpContactAttempts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpContactAttempts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpContactAttempts != null)
                {
                }

                _tpContactAttempts = value;
                if (_tpContactAttempts != null)
                {
                }
            }
        }

        private GroupBox _grpContactAttemptDetails;

        private TextBox _txtContactAttemptDetails;

        internal TextBox txtContactAttemptDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContactAttemptDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContactAttemptDetails != null)
                {
                }

                _txtContactAttemptDetails = value;
                if (_txtContactAttemptDetails != null)
                {
                }
            }
        }

        private Label _lblContactNotes;

        private GroupBox _grpContactAttempts;

        private DataGrid _dgContactAttempts;

        internal DataGrid dgContactAttempts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgContactAttempts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgContactAttempts != null)
                {
                    _dgContactAttempts.Click -= dgContactAttempts_Click;
                }

                _dgContactAttempts = value;
                if (_dgContactAttempts != null)
                {
                    _dgContactAttempts.Click += dgContactAttempts_Click;
                }
            }
        }

        private Button _btnAddAttempt;

        internal Button btnAddAttempt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddAttempt;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddAttempt != null)
                {
                    _btnAddAttempt.Click -= btnAddAttempt_Click;
                }

                _btnAddAttempt = value;
                if (_btnAddAttempt != null)
                {
                    _btnAddAttempt.Click += btnAddAttempt_Click;
                }
            }
        }

        private Label _lblClaimLimit;

        internal Label lblClaimLimit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblClaimLimit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblClaimLimit != null)
                {
                }

                _lblClaimLimit = value;
                if (_lblClaimLimit != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._btnClose = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._TabControl1 = new System.Windows.Forms.TabControl();
            this._tpMain = new System.Windows.Forms.TabPage();
            this._tpAssets = new System.Windows.Forms.TabPage();
            this._grpAssets = new System.Windows.Forms.GroupBox();
            this._dgAssets = new System.Windows.Forms.DataGrid();
            this._btnAddAppliance = new System.Windows.Forms.Button();
            this._tpDocuments = new System.Windows.Forms.TabPage();
            this._tbquote = new System.Windows.Forms.TabPage();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._rdoAXA = new System.Windows.Forms.RadioButton();
            this._rdoPOC = new System.Windows.Forms.RadioButton();
            this._Panel1 = new System.Windows.Forms.Panel();
            this._txtClaimLimit = new System.Windows.Forms.TextBox();
            this._lblClaimLimit = new System.Windows.Forms.Label();
            this._chkExcludeVat = new System.Windows.Forms.CheckBox();
            this._cboVATRate = new System.Windows.Forms.ComboBox();
            this._lblVAT = new System.Windows.Forms.Label();
            this._GroupBox3 = new System.Windows.Forms.GroupBox();
            this._rbStandard = new System.Windows.Forms.RadioButton();
            this._rbSite = new System.Windows.Forms.RadioButton();
            this._txtPartQty = new System.Windows.Forms.TextBox();
            this._Label46 = new System.Windows.Forms.Label();
            this._dgvQuote = new System.Windows.Forms.DataGridView();
            this._cboLabour = new System.Windows.Forms.ComboBox();
            this._btnQuoteAdd = new System.Windows.Forms.Button();
            this._Label45 = new System.Windows.Forms.Label();
            this._txtLabourQty = new System.Windows.Forms.TextBox();
            this._Label44 = new System.Windows.Forms.Label();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnaddtonotes = new System.Windows.Forms.Button();
            this._btnEmail = new System.Windows.Forms.Button();
            this._btncalc = new System.Windows.Forms.Button();
            this._tbresult = new System.Windows.Forms.TextBox();
            this._txtPartRate = new System.Windows.Forms.TextBox();
            this._lbltc1 = new System.Windows.Forms.Label();
            this._txtPartNumber = new System.Windows.Forms.TextBox();
            this._lblnumber1 = new System.Windows.Forms.Label();
            this._txtPartName = new System.Windows.Forms.TextBox();
            this._lblpart1 = new System.Windows.Forms.Label();
            this._tpNotes = new System.Windows.Forms.TabPage();
            this._gpbNotesDetails = new System.Windows.Forms.GroupBox();
            this._txtNoteID = new System.Windows.Forms.TextBox();
            this._btnSaveNote = new System.Windows.Forms.Button();
            this._txtNotes = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._gpbNotes = new System.Windows.Forms.GroupBox();
            this._btnDeleteNote = new System.Windows.Forms.Button();
            this._dgNotes = new System.Windows.Forms.DataGrid();
            this._btnAddNote = new System.Windows.Forms.Button();
            this._tpContactAttempts = new System.Windows.Forms.TabPage();
            this._grpContactAttemptDetails = new System.Windows.Forms.GroupBox();
            this._txtContactAttemptDetails = new System.Windows.Forms.TextBox();
            this._lblContactNotes = new System.Windows.Forms.Label();
            this._grpContactAttempts = new System.Windows.Forms.GroupBox();
            this._dgContactAttempts = new System.Windows.Forms.DataGrid();
            this._btnAddAttempt = new System.Windows.Forms.Button();
            this._btnView = new System.Windows.Forms.Button();
            this._cmsView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._PropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._CustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._AuditTrailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._OrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._InvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._QuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._CostingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._HistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._TabControl1.SuspendLayout();
            this._tpAssets.SuspendLayout();
            this._grpAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgAssets)).BeginInit();
            this._tbquote.SuspendLayout();
            this._GroupBox2.SuspendLayout();
            this._GroupBox1.SuspendLayout();
            this._Panel1.SuspendLayout();
            this._GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvQuote)).BeginInit();
            this._tpNotes.SuspendLayout();
            this._gpbNotesDetails.SuspendLayout();
            this._gpbNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgNotes)).BeginInit();
            this._tpContactAttempts.SuspendLayout();
            this._grpContactAttemptDetails.SuspendLayout();
            this._grpContactAttempts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgContactAttempts)).BeginInit();
            this._cmsView.SuspendLayout();
            this.SuspendLayout();
            //
            // _btnClose
            //
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(70, 698);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 23);
            this._btnClose.TabIndex = 16;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // _btnSave
            //
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Location = new System.Drawing.Point(8, 698);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 23);
            this._btnSave.TabIndex = 15;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // _TabControl1
            //
            this._TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TabControl1.Controls.Add(this._tpMain);
            this._TabControl1.Controls.Add(this._tpAssets);
            this._TabControl1.Controls.Add(this._tpDocuments);
            this._TabControl1.Controls.Add(this._tbquote);
            this._TabControl1.Controls.Add(this._tpNotes);
            this._TabControl1.Controls.Add(this._tpContactAttempts);
            this._TabControl1.Location = new System.Drawing.Point(0, 12);
            this._TabControl1.Name = "_TabControl1";
            this._TabControl1.SelectedIndex = 0;
            this._TabControl1.Size = new System.Drawing.Size(1200, 680);
            this._TabControl1.TabIndex = 23;
            //
            // _tpMain
            //
            this._tpMain.Location = new System.Drawing.Point(4, 22);
            this._tpMain.Name = "_tpMain";
            this._tpMain.Padding = new System.Windows.Forms.Padding(3);
            this._tpMain.Size = new System.Drawing.Size(1192, 654);
            this._tpMain.TabIndex = 0;
            this._tpMain.Text = "Main Details";
            this._tpMain.UseVisualStyleBackColor = true;
            //
            // _tpAssets
            //
            this._tpAssets.Controls.Add(this._grpAssets);
            this._tpAssets.Location = new System.Drawing.Point(4, 22);
            this._tpAssets.Name = "_tpAssets";
            this._tpAssets.Padding = new System.Windows.Forms.Padding(3);
            this._tpAssets.Size = new System.Drawing.Size(1192, 654);
            this._tpAssets.TabIndex = 2;
            this._tpAssets.Text = "Appliances";
            this._tpAssets.UseVisualStyleBackColor = true;
            //
            // _grpAssets
            //
            this._grpAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpAssets.Controls.Add(this._dgAssets);
            this._grpAssets.Controls.Add(this._btnAddAppliance);
            this._grpAssets.Location = new System.Drawing.Point(6, 6);
            this._grpAssets.Name = "_grpAssets";
            this._grpAssets.Size = new System.Drawing.Size(1178, 649);
            this._grpAssets.TabIndex = 29;
            this._grpAssets.TabStop = false;
            this._grpAssets.Text = "Select those related to the job";
            //
            // _dgAssets
            //
            this._dgAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgAssets.DataMember = "";
            this._dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgAssets.Location = new System.Drawing.Point(6, 20);
            this._dgAssets.Name = "_dgAssets";
            this._dgAssets.Size = new System.Drawing.Size(1166, 594);
            this._dgAssets.TabIndex = 1;
            this._dgAssets.Click += new System.EventHandler(this.dgAssets_Click);
            //
            // _btnAddAppliance
            //
            this._btnAddAppliance.AccessibleDescription = "Add Job Of Work";
            this._btnAddAppliance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddAppliance.Location = new System.Drawing.Point(6, 620);
            this._btnAddAppliance.Name = "_btnAddAppliance";
            this._btnAddAppliance.Size = new System.Drawing.Size(155, 23);
            this._btnAddAppliance.TabIndex = 28;
            this._btnAddAppliance.Text = "New Appliance";
            this._btnAddAppliance.Click += new System.EventHandler(this.btnAddAppliance_Click);
            //
            // _tpDocuments
            //
            this._tpDocuments.Location = new System.Drawing.Point(4, 22);
            this._tpDocuments.Name = "_tpDocuments";
            this._tpDocuments.Padding = new System.Windows.Forms.Padding(3);
            this._tpDocuments.Size = new System.Drawing.Size(1192, 654);
            this._tpDocuments.TabIndex = 1;
            this._tpDocuments.Text = "Documents";
            this._tpDocuments.UseVisualStyleBackColor = true;
            //
            // _tbquote
            //
            this._tbquote.Controls.Add(this._GroupBox2);
            this._tbquote.Location = new System.Drawing.Point(4, 22);
            this._tbquote.Name = "_tbquote";
            this._tbquote.Padding = new System.Windows.Forms.Padding(3);
            this._tbquote.Size = new System.Drawing.Size(1192, 654);
            this._tbquote.TabIndex = 7;
            this._tbquote.Text = "Quote Calc";
            this._tbquote.UseVisualStyleBackColor = true;
            //
            // _GroupBox2
            //
            this._GroupBox2.Controls.Add(this._GroupBox1);
            this._GroupBox2.Controls.Add(this._Panel1);
            this._GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._GroupBox2.Location = new System.Drawing.Point(3, 3);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(1186, 648);
            this._GroupBox2.TabIndex = 0;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "Quote Calculator";
            //
            // _GroupBox1
            //
            this._GroupBox1.Controls.Add(this._rdoAXA);
            this._GroupBox1.Controls.Add(this._rdoPOC);
            this._GroupBox1.Location = new System.Drawing.Point(55, 26);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(121, 45);
            this._GroupBox1.TabIndex = 82;
            this._GroupBox1.TabStop = false;
            //
            // _rdoAXA
            //
            this._rdoAXA.AutoSize = true;
            this._rdoAXA.Location = new System.Drawing.Point(65, 17);
            this._rdoAXA.Name = "_rdoAXA";
            this._rdoAXA.Size = new System.Drawing.Size(49, 17);
            this._rdoAXA.TabIndex = 1;
            this._rdoAXA.Text = "AXA";
            this._rdoAXA.UseVisualStyleBackColor = true;
            this._rdoAXA.CheckedChanged += new System.EventHandler(this.rdoCust_CheckedChanged);
            //
            // _rdoPOC
            //
            this._rdoPOC.AutoSize = true;
            this._rdoPOC.Checked = true;
            this._rdoPOC.Location = new System.Drawing.Point(6, 17);
            this._rdoPOC.Name = "_rdoPOC";
            this._rdoPOC.Size = new System.Drawing.Size(50, 17);
            this._rdoPOC.TabIndex = 0;
            this._rdoPOC.TabStop = true;
            this._rdoPOC.Text = "POC";
            this._rdoPOC.UseVisualStyleBackColor = true;
            this._rdoPOC.CheckedChanged += new System.EventHandler(this.rdoCust_CheckedChanged);
            //
            // _Panel1
            //
            this._Panel1.Controls.Add(this._txtClaimLimit);
            this._Panel1.Controls.Add(this._lblClaimLimit);
            this._Panel1.Controls.Add(this._chkExcludeVat);
            this._Panel1.Controls.Add(this._cboVATRate);
            this._Panel1.Controls.Add(this._lblVAT);
            this._Panel1.Controls.Add(this._GroupBox3);
            this._Panel1.Controls.Add(this._txtPartQty);
            this._Panel1.Controls.Add(this._Label46);
            this._Panel1.Controls.Add(this._dgvQuote);
            this._Panel1.Controls.Add(this._cboLabour);
            this._Panel1.Controls.Add(this._btnQuoteAdd);
            this._Panel1.Controls.Add(this._Label45);
            this._Panel1.Controls.Add(this._txtLabourQty);
            this._Panel1.Controls.Add(this._Label44);
            this._Panel1.Controls.Add(this._btnReset);
            this._Panel1.Controls.Add(this._btnaddtonotes);
            this._Panel1.Controls.Add(this._btnEmail);
            this._Panel1.Controls.Add(this._btncalc);
            this._Panel1.Controls.Add(this._tbresult);
            this._Panel1.Controls.Add(this._txtPartRate);
            this._Panel1.Controls.Add(this._lbltc1);
            this._Panel1.Controls.Add(this._txtPartNumber);
            this._Panel1.Controls.Add(this._lblnumber1);
            this._Panel1.Controls.Add(this._txtPartName);
            this._Panel1.Controls.Add(this._lblpart1);
            this._Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Panel1.Location = new System.Drawing.Point(3, 17);
            this._Panel1.Name = "_Panel1";
            this._Panel1.Size = new System.Drawing.Size(1180, 628);
            this._Panel1.TabIndex = 1;
            //
            // _txtClaimLimit
            //
            this._txtClaimLimit.Location = new System.Drawing.Point(585, 62);
            this._txtClaimLimit.Name = "_txtClaimLimit";
            this._txtClaimLimit.Size = new System.Drawing.Size(121, 21);
            this._txtClaimLimit.TabIndex = 83;
            this._txtClaimLimit.Visible = false;
            //
            // _lblClaimLimit
            //
            this._lblClaimLimit.AutoSize = true;
            this._lblClaimLimit.Location = new System.Drawing.Point(505, 65);
            this._lblClaimLimit.Name = "_lblClaimLimit";
            this._lblClaimLimit.Size = new System.Drawing.Size(71, 13);
            this._lblClaimLimit.TabIndex = 82;
            this._lblClaimLimit.Text = "Claim Limit";
            this._lblClaimLimit.Visible = false;
            //
            // _chkExcludeVat
            //
            this._chkExcludeVat.AutoSize = true;
            this._chkExcludeVat.Location = new System.Drawing.Point(425, 505);
            this._chkExcludeVat.Name = "_chkExcludeVat";
            this._chkExcludeVat.Size = new System.Drawing.Size(103, 17);
            this._chkExcludeVat.TabIndex = 81;
            this._chkExcludeVat.Text = "Exclude V.A.T";
            this._chkExcludeVat.UseVisualStyleBackColor = true;
            //
            // _cboVATRate
            //
            this._cboVATRate.FormattingEnabled = true;
            this._cboVATRate.Location = new System.Drawing.Point(499, 528);
            this._cboVATRate.Name = "_cboVATRate";
            this._cboVATRate.Size = new System.Drawing.Size(109, 21);
            this._cboVATRate.TabIndex = 79;
            //
            // _lblVAT
            //
            this._lblVAT.Location = new System.Drawing.Point(422, 529);
            this._lblVAT.Name = "_lblVAT";
            this._lblVAT.Size = new System.Drawing.Size(68, 17);
            this._lblVAT.TabIndex = 80;
            this._lblVAT.Text = "VAT Rate";
            this._lblVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _GroupBox3
            //
            this._GroupBox3.Controls.Add(this._rbStandard);
            this._GroupBox3.Controls.Add(this._rbSite);
            this._GroupBox3.Location = new System.Drawing.Point(48, 491);
            this._GroupBox3.Name = "_GroupBox3";
            this._GroupBox3.Size = new System.Drawing.Size(343, 45);
            this._GroupBox3.TabIndex = 77;
            this._GroupBox3.TabStop = false;
            //
            // _rbStandard
            //
            this._rbStandard.AutoSize = true;
            this._rbStandard.Checked = true;
            this._rbStandard.Location = new System.Drawing.Point(207, 16);
            this._rbStandard.Name = "_rbStandard";
            this._rbStandard.Size = new System.Drawing.Size(121, 17);
            this._rbStandard.TabIndex = 1;
            this._rbStandard.TabStop = true;
            this._rbStandard.Text = "Markup standard";
            this._rbStandard.UseVisualStyleBackColor = true;
            //
            // _rbSite
            //
            this._rbSite.AutoSize = true;
            this._rbSite.Location = new System.Drawing.Point(6, 17);
            this._rbSite.Name = "_rbSite";
            this._rbSite.Size = new System.Drawing.Size(185, 17);
            this._rbSite.TabIndex = 0;
            this._rbSite.Text = "Markup parts using site rate";
            this._rbSite.UseVisualStyleBackColor = true;
            //
            // _txtPartQty
            //
            this._txtPartQty.Location = new System.Drawing.Point(659, 89);
            this._txtPartQty.Name = "_txtPartQty";
            this._txtPartQty.Size = new System.Drawing.Size(48, 21);
            this._txtPartQty.TabIndex = 76;
            this._txtPartQty.Text = "0";
            //
            // _Label46
            //
            this._Label46.AutoSize = true;
            this._Label46.Location = new System.Drawing.Point(629, 92);
            this._Label46.Name = "_Label46";
            this._Label46.Size = new System.Drawing.Size(27, 13);
            this._Label46.TabIndex = 75;
            this._Label46.Text = "Qty";
            //
            // _dgvQuote
            //
            this._dgvQuote.AllowUserToAddRows = false;
            this._dgvQuote.AllowUserToResizeColumns = false;
            this._dgvQuote.AllowUserToResizeRows = false;
            this._dgvQuote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvQuote.Location = new System.Drawing.Point(48, 124);
            this._dgvQuote.Name = "_dgvQuote";
            this._dgvQuote.Size = new System.Drawing.Size(811, 210);
            this._dgvQuote.TabIndex = 74;
            //
            // _cboLabour
            //
            this._cboLabour.FormattingEnabled = true;
            this._cboLabour.Location = new System.Drawing.Point(125, 62);
            this._cboLabour.Name = "_cboLabour";
            this._cboLabour.Size = new System.Drawing.Size(294, 21);
            this._cboLabour.TabIndex = 73;
            //
            // _btnQuoteAdd
            //
            this._btnQuoteAdd.Location = new System.Drawing.Point(820, 65);
            this._btnQuoteAdd.Name = "_btnQuoteAdd";
            this._btnQuoteAdd.Size = new System.Drawing.Size(39, 47);
            this._btnQuoteAdd.TabIndex = 72;
            this._btnQuoteAdd.Text = "Add";
            this._btnQuoteAdd.UseVisualStyleBackColor = true;
            this._btnQuoteAdd.Click += new System.EventHandler(this.BtnQuoteAdd_Click);
            //
            // _Label45
            //
            this._Label45.AutoSize = true;
            this._Label45.Location = new System.Drawing.Point(45, 65);
            this._Label45.Name = "_Label45";
            this._Label45.Size = new System.Drawing.Size(77, 13);
            this._Label45.TabIndex = 71;
            this._Label45.Text = "Labour Type";
            //
            // _txtLabourQty
            //
            this._txtLabourQty.Location = new System.Drawing.Point(449, 62);
            this._txtLabourQty.Name = "_txtLabourQty";
            this._txtLabourQty.Size = new System.Drawing.Size(29, 21);
            this._txtLabourQty.TabIndex = 70;
            this._txtLabourQty.Text = "0";
            //
            // _Label44
            //
            this._Label44.AutoSize = true;
            this._Label44.Location = new System.Drawing.Point(427, 65);
            this._Label44.Name = "_Label44";
            this._Label44.Size = new System.Drawing.Size(15, 13);
            this._Label44.TabIndex = 69;
            this._Label44.Text = "X";
            //
            // _btnReset
            //
            this._btnReset.Location = new System.Drawing.Point(614, 526);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(110, 23);
            this._btnReset.TabIndex = 68;
            this._btnReset.Text = "Reset";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // _btnaddtonotes
            //
            this._btnaddtonotes.Enabled = false;
            this._btnaddtonotes.Location = new System.Drawing.Point(730, 499);
            this._btnaddtonotes.Name = "_btnaddtonotes";
            this._btnaddtonotes.Size = new System.Drawing.Size(130, 23);
            this._btnaddtonotes.TabIndex = 67;
            this._btnaddtonotes.Text = "Add Quote to Notes";
            this._btnaddtonotes.UseVisualStyleBackColor = true;
            this._btnaddtonotes.Click += new System.EventHandler(this.btnaddtonotes_Click);
            //
            // _btnEmail
            //
            this._btnEmail.Enabled = false;
            this._btnEmail.Location = new System.Drawing.Point(730, 526);
            this._btnEmail.Name = "_btnEmail";
            this._btnEmail.Size = new System.Drawing.Size(130, 23);
            this._btnEmail.TabIndex = 66;
            this._btnEmail.Text = "Email Quote";
            this._btnEmail.UseVisualStyleBackColor = true;
            this._btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            //
            // _btncalc
            //
            this._btncalc.Location = new System.Drawing.Point(614, 499);
            this._btncalc.Name = "_btncalc";
            this._btncalc.Size = new System.Drawing.Size(110, 23);
            this._btncalc.TabIndex = 65;
            this._btncalc.Text = "Generate Quote";
            this._btncalc.UseVisualStyleBackColor = true;
            this._btncalc.Click += new System.EventHandler(this.btncalc_Click);
            //
            // _tbresult
            //
            this._tbresult.Location = new System.Drawing.Point(48, 357);
            this._tbresult.Multiline = true;
            this._tbresult.Name = "_tbresult";
            this._tbresult.ReadOnly = true;
            this._tbresult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._tbresult.Size = new System.Drawing.Size(812, 128);
            this._tbresult.TabIndex = 64;
            this._tbresult.Text = "Please enter details above. Quote will appear here";
            //
            // _txtPartRate
            //
            this._txtPartRate.Location = new System.Drawing.Point(558, 89);
            this._txtPartRate.Name = "_txtPartRate";
            this._txtPartRate.Size = new System.Drawing.Size(55, 21);
            this._txtPartRate.TabIndex = 5;
            //
            // _lbltc1
            //
            this._lbltc1.AutoSize = true;
            this._lbltc1.Location = new System.Drawing.Point(456, 92);
            this._lbltc1.Name = "_lbltc1";
            this._lbltc1.Size = new System.Drawing.Size(96, 13);
            this._lbltc1.TabIndex = 4;
            this._lbltc1.Text = "Part Trade Cost";
            //
            // _txtPartNumber
            //
            this._txtPartNumber.Location = new System.Drawing.Point(349, 89);
            this._txtPartNumber.Name = "_txtPartNumber";
            this._txtPartNumber.Size = new System.Drawing.Size(89, 21);
            this._txtPartNumber.TabIndex = 3;
            //
            // _lblnumber1
            //
            this._lblnumber1.AutoSize = true;
            this._lblnumber1.Location = new System.Drawing.Point(264, 92);
            this._lblnumber1.Name = "_lblnumber1";
            this._lblnumber1.Size = new System.Drawing.Size(79, 13);
            this._lblnumber1.TabIndex = 2;
            this._lblnumber1.Text = "Part Number";
            //
            // _txtPartName
            //
            this._txtPartName.Location = new System.Drawing.Point(125, 89);
            this._txtPartName.Name = "_txtPartName";
            this._txtPartName.Size = new System.Drawing.Size(121, 21);
            this._txtPartName.TabIndex = 1;
            //
            // _lblpart1
            //
            this._lblpart1.AutoSize = true;
            this._lblpart1.Location = new System.Drawing.Point(45, 92);
            this._lblpart1.Name = "_lblpart1";
            this._lblpart1.Size = new System.Drawing.Size(67, 13);
            this._lblpart1.TabIndex = 0;
            this._lblpart1.Text = "Part Name";
            //
            // _tpNotes
            //
            this._tpNotes.Controls.Add(this._gpbNotesDetails);
            this._tpNotes.Controls.Add(this._gpbNotes);
            this._tpNotes.Location = new System.Drawing.Point(4, 22);
            this._tpNotes.Name = "_tpNotes";
            this._tpNotes.Size = new System.Drawing.Size(1192, 654);
            this._tpNotes.TabIndex = 4;
            this._tpNotes.Text = "Notes";
            this._tpNotes.UseVisualStyleBackColor = true;
            //
            // _gpbNotesDetails
            //
            this._gpbNotesDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gpbNotesDetails.Controls.Add(this._txtNoteID);
            this._gpbNotesDetails.Controls.Add(this._btnSaveNote);
            this._gpbNotesDetails.Controls.Add(this._txtNotes);
            this._gpbNotesDetails.Controls.Add(this._Label1);
            this._gpbNotesDetails.Location = new System.Drawing.Point(807, 6);
            this._gpbNotesDetails.Name = "_gpbNotesDetails";
            this._gpbNotesDetails.Size = new System.Drawing.Size(377, 649);
            this._gpbNotesDetails.TabIndex = 33;
            this._gpbNotesDetails.TabStop = false;
            this._gpbNotesDetails.Text = "Details";
            //
            // _txtNoteID
            //
            this._txtNoteID.Location = new System.Drawing.Point(66, 14);
            this._txtNoteID.Name = "_txtNoteID";
            this._txtNoteID.Size = new System.Drawing.Size(100, 21);
            this._txtNoteID.TabIndex = 36;
            this._txtNoteID.TabStop = false;
            this._txtNoteID.Visible = false;
            //
            // _btnSaveNote
            //
            this._btnSaveNote.AccessibleDescription = "";
            this._btnSaveNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveNote.Location = new System.Drawing.Point(292, 620);
            this._btnSaveNote.Name = "_btnSaveNote";
            this._btnSaveNote.Size = new System.Drawing.Size(79, 23);
            this._btnSaveNote.TabIndex = 1;
            this._btnSaveNote.Text = "Save";
            this._btnSaveNote.Click += new System.EventHandler(this.btnSaveNote_Click);
            //
            // _txtNotes
            //
            this._txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNotes.Location = new System.Drawing.Point(6, 37);
            this._txtNotes.Multiline = true;
            this._txtNotes.Name = "_txtNotes";
            this._txtNotes.Size = new System.Drawing.Size(365, 577);
            this._txtNotes.TabIndex = 0;
            //
            // _Label1
            //
            this._Label1.Location = new System.Drawing.Point(3, 20);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(88, 23);
            this._Label1.TabIndex = 34;
            this._Label1.Text = "Notes:";
            //
            // _gpbNotes
            //
            this._gpbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gpbNotes.Controls.Add(this._btnDeleteNote);
            this._gpbNotes.Controls.Add(this._dgNotes);
            this._gpbNotes.Controls.Add(this._btnAddNote);
            this._gpbNotes.Location = new System.Drawing.Point(7, 6);
            this._gpbNotes.Name = "_gpbNotes";
            this._gpbNotes.Size = new System.Drawing.Size(789, 649);
            this._gpbNotes.TabIndex = 30;
            this._gpbNotes.TabStop = false;
            this._gpbNotes.Text = "Notes";
            //
            // _btnDeleteNote
            //
            this._btnDeleteNote.AccessibleDescription = "";
            this._btnDeleteNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnDeleteNote.Location = new System.Drawing.Point(95, 620);
            this._btnDeleteNote.Name = "_btnDeleteNote";
            this._btnDeleteNote.Size = new System.Drawing.Size(85, 23);
            this._btnDeleteNote.TabIndex = 3;
            this._btnDeleteNote.Text = "Delete";
            this._btnDeleteNote.Visible = false;
            this._btnDeleteNote.Click += new System.EventHandler(this.btnDeleteNote_Click);
            //
            // _dgNotes
            //
            this._dgNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgNotes.DataMember = "";
            this._dgNotes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgNotes.Location = new System.Drawing.Point(6, 20);
            this._dgNotes.Name = "_dgNotes";
            this._dgNotes.Size = new System.Drawing.Size(777, 594);
            this._dgNotes.TabIndex = 1;
            this._dgNotes.CurrentCellChanged += new System.EventHandler(this.dgNotes_Click);
            this._dgNotes.Click += new System.EventHandler(this.dgNotes_Click);
            //
            // _btnAddNote
            //
            this._btnAddNote.AccessibleDescription = "";
            this._btnAddNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddNote.Location = new System.Drawing.Point(6, 620);
            this._btnAddNote.Name = "_btnAddNote";
            this._btnAddNote.Size = new System.Drawing.Size(85, 23);
            this._btnAddNote.TabIndex = 2;
            this._btnAddNote.Text = "Add";
            this._btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            //
            // _tpContactAttempts
            //
            this._tpContactAttempts.Controls.Add(this._grpContactAttemptDetails);
            this._tpContactAttempts.Controls.Add(this._grpContactAttempts);
            this._tpContactAttempts.Location = new System.Drawing.Point(4, 22);
            this._tpContactAttempts.Name = "_tpContactAttempts";
            this._tpContactAttempts.Size = new System.Drawing.Size(1192, 654);
            this._tpContactAttempts.TabIndex = 8;
            this._tpContactAttempts.Text = "Contact Attempts";
            this._tpContactAttempts.UseVisualStyleBackColor = true;
            //
            // _grpContactAttemptDetails
            //
            this._grpContactAttemptDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpContactAttemptDetails.Controls.Add(this._txtContactAttemptDetails);
            this._grpContactAttemptDetails.Controls.Add(this._lblContactNotes);
            this._grpContactAttemptDetails.Location = new System.Drawing.Point(808, 2);
            this._grpContactAttemptDetails.Name = "_grpContactAttemptDetails";
            this._grpContactAttemptDetails.Size = new System.Drawing.Size(377, 649);
            this._grpContactAttemptDetails.TabIndex = 35;
            this._grpContactAttemptDetails.TabStop = false;
            this._grpContactAttemptDetails.Text = "Details";
            //
            // _txtContactAttemptDetails
            //
            this._txtContactAttemptDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtContactAttemptDetails.Location = new System.Drawing.Point(6, 37);
            this._txtContactAttemptDetails.Multiline = true;
            this._txtContactAttemptDetails.Name = "_txtContactAttemptDetails";
            this._txtContactAttemptDetails.ReadOnly = true;
            this._txtContactAttemptDetails.Size = new System.Drawing.Size(365, 606);
            this._txtContactAttemptDetails.TabIndex = 0;
            //
            // _lblContactNotes
            //
            this._lblContactNotes.Location = new System.Drawing.Point(3, 20);
            this._lblContactNotes.Name = "_lblContactNotes";
            this._lblContactNotes.Size = new System.Drawing.Size(88, 23);
            this._lblContactNotes.TabIndex = 34;
            this._lblContactNotes.Text = "Notes:";
            //
            // _grpContactAttempts
            //
            this._grpContactAttempts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpContactAttempts.Controls.Add(this._dgContactAttempts);
            this._grpContactAttempts.Controls.Add(this._btnAddAttempt);
            this._grpContactAttempts.Location = new System.Drawing.Point(8, 2);
            this._grpContactAttempts.Name = "_grpContactAttempts";
            this._grpContactAttempts.Size = new System.Drawing.Size(789, 649);
            this._grpContactAttempts.TabIndex = 34;
            this._grpContactAttempts.TabStop = false;
            this._grpContactAttempts.Text = "Attempts";
            //
            // _dgContactAttempts
            //
            this._dgContactAttempts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgContactAttempts.DataMember = "";
            this._dgContactAttempts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgContactAttempts.Location = new System.Drawing.Point(6, 20);
            this._dgContactAttempts.Name = "_dgContactAttempts";
            this._dgContactAttempts.Size = new System.Drawing.Size(777, 594);
            this._dgContactAttempts.TabIndex = 1;
            this._dgContactAttempts.Click += new System.EventHandler(this.dgContactAttempts_Click);
            //
            // _btnAddAttempt
            //
            this._btnAddAttempt.AccessibleDescription = "";
            this._btnAddAttempt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddAttempt.Location = new System.Drawing.Point(6, 620);
            this._btnAddAttempt.Name = "_btnAddAttempt";
            this._btnAddAttempt.Size = new System.Drawing.Size(85, 23);
            this._btnAddAttempt.TabIndex = 2;
            this._btnAddAttempt.Text = "Add";
            this._btnAddAttempt.Click += new System.EventHandler(this.btnAddAttempt_Click);
            //
            // _btnView
            //
            this._btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnView.Location = new System.Drawing.Point(132, 698);
            this._btnView.Name = "_btnView";
            this._btnView.Size = new System.Drawing.Size(99, 23);
            this._btnView.TabIndex = 24;
            this._btnView.Text = "View...";
            this._btnView.Click += new System.EventHandler(this.btnView_Click);
            //
            // _cmsView
            //
            this._cmsView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._PropertyToolStripMenuItem,
            this._CustomerToolStripMenuItem,
            this._AuditTrailToolStripMenuItem,
            this._OrdersToolStripMenuItem,
            this._InvoiceToolStripMenuItem,
            this._QuoteToolStripMenuItem,
            this._CostingsToolStripMenuItem,
            this._HistoryToolStripMenuItem});
            this._cmsView.Name = "cmsView";
            this._cmsView.Size = new System.Drawing.Size(128, 180);
            //
            // _PropertyToolStripMenuItem
            //
            this._PropertyToolStripMenuItem.Name = "_PropertyToolStripMenuItem";
            this._PropertyToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this._PropertyToolStripMenuItem.Text = "Property";
            this._PropertyToolStripMenuItem.Click += new System.EventHandler(this.PropertyToolStripMenuItem_Click);
            //
            // _CustomerToolStripMenuItem
            //
            this._CustomerToolStripMenuItem.Name = "_CustomerToolStripMenuItem";
            this._CustomerToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this._CustomerToolStripMenuItem.Text = "Customer";
            this._CustomerToolStripMenuItem.Click += new System.EventHandler(this.CustomerToolStripMenuItem_Click);
            //
            // _AuditTrailToolStripMenuItem
            //
            this._AuditTrailToolStripMenuItem.Name = "_AuditTrailToolStripMenuItem";
            this._AuditTrailToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this._AuditTrailToolStripMenuItem.Text = "Audit Trail";
            this._AuditTrailToolStripMenuItem.Click += new System.EventHandler(this.AuditTrailToolStripMenuItem_Click);
            //
            // _OrdersToolStripMenuItem
            //
            this._OrdersToolStripMenuItem.Name = "_OrdersToolStripMenuItem";
            this._OrdersToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this._OrdersToolStripMenuItem.Text = "Orders";
            this._OrdersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            //
            // _InvoiceToolStripMenuItem
            //
            this._InvoiceToolStripMenuItem.Name = "_InvoiceToolStripMenuItem";
            this._InvoiceToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this._InvoiceToolStripMenuItem.Text = "Invoice";
            this._InvoiceToolStripMenuItem.Click += new System.EventHandler(this.InvoiceToolStripMenuItem_Click);
            //
            // _QuoteToolStripMenuItem
            //
            this._QuoteToolStripMenuItem.Name = "_QuoteToolStripMenuItem";
            this._QuoteToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this._QuoteToolStripMenuItem.Text = "Quote";
            this._QuoteToolStripMenuItem.Click += new System.EventHandler(this.QuoteToolStripMenuItem_Click);
            //
            // _CostingsToolStripMenuItem
            //
            this._CostingsToolStripMenuItem.Name = "_CostingsToolStripMenuItem";
            this._CostingsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this._CostingsToolStripMenuItem.Text = "Costings";
            this._CostingsToolStripMenuItem.Click += new System.EventHandler(this.CostingsToolStripMenuItem_Click);
            //
            // _HistoryToolStripMenuItem
            //
            this._HistoryToolStripMenuItem.Name = "_HistoryToolStripMenuItem";
            this._HistoryToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this._HistoryToolStripMenuItem.Text = "History";
            this._HistoryToolStripMenuItem.Click += new System.EventHandler(this.HistoryToolStripMenuItem_Click);
            //
            // FRMLogCallout
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1200, 724);
            this.Controls.Add(this._btnView);
            this.Controls.Add(this._TabControl1);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 724);
            this.Name = "FRMLogCallout";
            this.Text = "Job";
            this._TabControl1.ResumeLayout(false);
            this._tpAssets.ResumeLayout(false);
            this._grpAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgAssets)).EndInit();
            this._tbquote.ResumeLayout(false);
            this._GroupBox2.ResumeLayout(false);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this._Panel1.ResumeLayout(false);
            this._Panel1.PerformLayout();
            this._GroupBox3.ResumeLayout(false);
            this._GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvQuote)).EndInit();
            this._tpNotes.ResumeLayout(false);
            this._gpbNotesDetails.ResumeLayout(false);
            this._gpbNotesDetails.PerformLayout();
            this._gpbNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgNotes)).EndInit();
            this._tpContactAttempts.ResumeLayout(false);
            this._grpContactAttemptDetails.ResumeLayout(false);
            this._grpContactAttemptDetails.PerformLayout();
            this._grpContactAttempts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgContactAttempts)).EndInit();
            this._cmsView.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            if (App.IsRFT)
            {
                TabControl1.Controls.Remove(tbquote);
            }

            ID = Helper.MakeIntegerValid(get_GetParameter(0));
            ((UCLogCallout)LoadedControl).OnForm = this;
            ((UCLogCallout)LoadedControl).JobId = ID;
            if (get_GetParameter(1).GetType() == typeof(Entity.Jobs.Job))
            {
                ((UCLogCallout)LoadedControl).SiteId = ((Entity.Jobs.Job)get_GetParameter(1)).PropertyID;
            }
            else
            {
                ((UCLogCallout)LoadedControl).SiteId = Helper.MakeIntegerValid(get_GetParameter(1));
            } ((UCLogCallout)LoadedControl).Populate();
            foreach (TabPage LogCallout in ((UCLogCallout)LoadedControl).tcJobOfWorks.TabPages)
            {
                foreach (TabPage CalloutBreakdown in ((UCCalloutBreakdown)LogCallout.Controls[0]).tcEngineerVisits.TabPages)
                    ((UCVisitBreakdown)CalloutBreakdown.Controls[0]).SetupDG();
            }

            if (((UCLogCallout)LoadedControl).Job.QuoteID == 0)
            {
                QuoteToolStripMenuItem.Visible = false;
            }

            var argc = cboLabour;
            Combo.SetUpCombo(ref argc, App.DB.CustomerScheduleOfRate.CustomerScheduleOfRates_GetALL_Labour(((UCLogCallout)LoadedControl).Site.CustomerID).Table, "Price", "Description", Enums.ComboValues.Not_Applicable);
            var argcombo = cboLabour;
            Combo.SetSelectedComboItem_By_Description(ref argcombo, "Normal Labour");
            var argc1 = cboVATRate;
            Combo.SetUpCombo(ref argc1, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", Enums.ComboValues.Not_Applicable);
            var argcombo1 = cboVATRate;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 6.ToString());
            SetupAssetDataGrid();
            SetupNotesDataGrid();
            SetupContactAttemptDataGrid();
            SetupQuoteDGV();
            PopulateContactAttempts();
            try
            {
                if (GetParameterCount > 4 && Helper.MakeIntegerValid(get_GetParameter(4)) != 0)
                {
                    var dvEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get(Conversions.ToInteger(get_GetParameter(4)));
                    int jobOfWorkNum = Conversions.ToInteger(dvEngineerVisit.Table.Rows[0]["JOWNo"]);
                    int engineerVisitNum = Conversions.ToInteger(dvEngineerVisit.Table.Rows[0]["VisitNo"]);
                    ((UCLogCallout)LoadedControl).tcJobOfWorks.SelectedIndex = jobOfWorkNum - 1;
                    ((UCCalloutBreakdown)((UCLogCallout)LoadedControl).tcJobOfWorks.SelectedTab.Controls[0]).tcEngineerVisits.SelectedIndex = engineerVisitNum - 1;
                }
            }
            catch
            {
            }

            if (ID > 0)
            {
                if (JobLock is null)
                    JobLock = App.DB.JobLock.JobLock(ID);
                if (JobLock?.UserID != App.loggedInUser.UserID == true)
                {
                    string message = "The job is currently being viewed by: " + JobLock.NameOfUserWhoLocked;
                    MessageBox.Show(message, "READ ONLY - JOB LOCKED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MakeReadOnly();
                    Text += " Job Locked by: " + JobLock.NameOfUserWhoLocked;
                }
            }
        }

        public IUserControl LoadedControl
        {
            get
            {
                return (IUserControl)tpMain.Controls[0];
            }
        }

        public void ResetMe(int newID)
        {
            ID = newID;
            var formType = get_GetParameter(2)?.GetType();
            if (formType == typeof(UCSite))
            {
                ((UCSite)get_GetParameter(2)).PopulateJobs();
                App.MainForm.RefreshEntity(Helper.MakeIntegerValid(get_GetParameter(1)));
            }

            if (formType == typeof(UCAsset))
            {
                ((UCAsset)get_GetParameter(2)).PopulateJobs();
                App.MainForm.RefreshEntity(Helper.MakeIntegerValid(get_GetParameter(1)));
            }

            if (formType == typeof(UCQuoteJob))
            {
                // CType(LoadedControl, UCLogCallout).CurrentJob = DB.Job.Job_Get(ID)
            }
        }

        private UCDocumentsList DocumentsControl;

        // Private CostingsControl As UCJobCostings
        private IUserControl TheLoadedControl;

        private DataView _Data;

        public DataView Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
                _Data.AllowNew = false;
                _Data.AllowEdit = false;
                _Data.AllowDelete = true;
                dgvQuote.AutoGenerateColumns = false;
                dgvQuote.DataSource = Data;
            }
        }

        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
                if (ID == 0)
                {
                    PageState = Enums.FormState.Insert;
                    Text = "Job : Adding New...";
                    btnSave.Enabled = true;
                    AuditTrailToolStripMenuItem.Visible = false;
                    OrdersToolStripMenuItem.Visible = false;
                    InvoiceToolStripMenuItem.Visible = false;
                    gpbNotes.Enabled = false;
                    gpbNotesDetails.Enabled = false;
                    btnSaveNote.Enabled = false;
                    btnAddNote.Enabled = false;
                    btnDeleteNote.Enabled = false;
                    CostingsToolStripMenuItem.Visible = false;
                    btnAddAttempt.Enabled = false;
                }
                else
                {
                    PageState = Enums.FormState.Update;
                    Text = "Job : ID " + ID;
                    AuditTrailToolStripMenuItem.Visible = true;
                    OrdersToolStripMenuItem.Visible = true;
                    InvoiceToolStripMenuItem.Visible = true;
                    tpDocuments.Controls.Clear();
                    DocumentsControl = new UCDocumentsList(Enums.TableNames.tblJob, ID);
                    tpDocuments.Controls.Add(DocumentsControl);
                    PopulateJobNotes();
                    gpbNotes.Enabled = true;
                    gpbNotesDetails.Enabled = true;
                    btnSaveNote.Enabled = true;
                    btnAddNote.Enabled = true;
                    btnDeleteNote.Enabled = true;
                }
            }
        }

        private Enums.FormState _pageState;

        private Enums.FormState PageState
        {
            get
            {
                return _pageState;
            }

            set
            {
                _pageState = value;
            }
        }

        private DataView _AssetsTable = null;

        public DataView AssetsDataView
        {
            get
            {
                return _AssetsTable;
            }

            set
            {
                _AssetsTable = value;
                _AssetsTable.Table.TableName = Enums.TableNames.tblAsset.ToString();
                _AssetsTable.AllowNew = false;
                _AssetsTable.AllowEdit = false;
                _AssetsTable.AllowDelete = false;
                dgAssets.DataSource = AssetsDataView;
            }
        }

        private DataRow SelectedAssetDataRow
        {
            get
            {
                if (!(dgAssets.CurrentRowIndex == -1))
                {
                    return AssetsDataView[dgAssets.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.JobLock.JobLock _JobLock;

        public Entity.JobLock.JobLock JobLock
        {
            get
            {
                return _JobLock;
            }

            set
            {
                _JobLock = value;
            }
        }

        private Entity.JobInstalls.JobInstall _JI;

        private Entity.JobInstalls.JobInstall JI
        {
            get
            {
                return _JI;
            }

            set
            {
                _JI = value;
            }
        }

        public void SetupQuoteDGV()
        {
            Data = new DataView();
            var dt = new DataTable();
            dt.TableName = "QuoteTable";
            Data.Table = dt;
            Data.Table.Columns.Add("PartName", typeof(string));
            Data.Table.Columns.Add("PartNumber", typeof(string));
            Data.Table.Columns.Add("PartCost", typeof(decimal));
            Data.Table.Columns.Add("PartQty", typeof(int));
            var ID = new DataGridViewTextBoxColumn();
            ID.HeaderText = "CustomerScheduleOfRateID";
            ID.DataPropertyName = "CustomerScheduleOfRateID";
            ID.Name = "CustomerScheduleOfRateID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvQuote.Columns.Add(ID);
            var PartName = new DataGridViewTextBoxColumn();
            PartName.HeaderText = "Part Name";
            PartName.FillWeight = 15;
            PartName.DataPropertyName = "PartName";
            PartName.Name = "PartName";
            PartName.Visible = true;
            PartName.MinimumWidth = 400;
            PartName.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvQuote.Columns.Add(PartName);
            var PartNo = new DataGridViewTextBoxColumn();
            PartNo.HeaderText = "Part Number";
            PartNo.FillWeight = 15;
            PartNo.DataPropertyName = "PartNumber";
            PartNo.Name = "PartNumber";
            PartNo.Visible = true;
            PartNo.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvQuote.Columns.Add(PartNo);
            var PartRate = new DataGridViewTextBoxColumn();
            PartRate.HeaderText = "Part U.Cost";
            PartRate.FillWeight = 15;
            PartRate.DataPropertyName = "PartCost";
            PartRate.Name = "PartCost";
            PartRate.Visible = true;
            PartRate.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvQuote.Columns.Add(PartRate);
            var PartQty = new DataGridViewTextBoxColumn();
            PartQty.HeaderText = "Part Qty";
            PartQty.FillWeight = 15;
            PartQty.DataPropertyName = "PartQty";
            PartQty.Name = "PartQty";
            PartQty.Visible = true;
            PartQty.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvQuote.Columns.Add(PartQty);
        }

        public void SetupAssetDataGrid()
        {
            Helper.SetUpDataGrid(dgAssets);
            var tStyle = dgAssets.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgAssets.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Active = new BitToStringDescriptionColumn();
            Active.Format = "";
            Active.FormatInfo = null;
            Active.HeaderText = "Active";
            Active.MappingName = "Active";
            Active.ReadOnly = true;
            Active.Width = 50;
            Active.NullText = "";
            tStyle.GridColumnStyles.Add(Active);
            var TenantsAppliance = new BitToStringDescriptionColumn();
            TenantsAppliance.Format = "";
            TenantsAppliance.FormatInfo = null;
            TenantsAppliance.HeaderText = "Tenants Appliance";
            TenantsAppliance.MappingName = "TenantsAppliance";
            TenantsAppliance.ReadOnly = true;
            TenantsAppliance.Width = 50;
            TenantsAppliance.NullText = "";
            tStyle.GridColumnStyles.Add(TenantsAppliance);
            var Product = new DataGridLabelColumn();
            Product.Format = "";
            Product.FormatInfo = null;
            Product.HeaderText = "Product";
            Product.MappingName = "Product";
            Product.ReadOnly = true;
            Product.Width = 250;
            Product.NullText = "";
            tStyle.GridColumnStyles.Add(Product);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 75;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var SerialNum = new DataGridLabelColumn();
            SerialNum.Format = "";
            SerialNum.FormatInfo = null;
            SerialNum.HeaderText = "Serial";
            SerialNum.MappingName = "SerialNum";
            SerialNum.ReadOnly = true;
            SerialNum.Width = 75;
            SerialNum.NullText = "";
            tStyle.GridColumnStyles.Add(SerialNum);
            var GaswayRef = new DataGridLabelColumn();
            GaswayRef.Format = "";
            GaswayRef.FormatInfo = null;
            GaswayRef.HeaderText = "Gasway Ref";
            GaswayRef.MappingName = "BoughtFrom";
            GaswayRef.ReadOnly = true;
            GaswayRef.Width = 75;
            GaswayRef.NullText = "";
            tStyle.GridColumnStyles.Add(GaswayRef);
            var GCNum = new DataGridLabelColumn();
            GCNum.Format = "";
            GCNum.FormatInfo = null;
            GCNum.HeaderText = "GC Number";
            GCNum.MappingName = "GCNumber";
            GCNum.ReadOnly = true;
            GCNum.Width = 75;
            GCNum.NullText = "";
            tStyle.GridColumnStyles.Add(GCNum);
            var YearOfManufacture = new DataGridLabelColumn();
            YearOfManufacture.Format = "";
            YearOfManufacture.FormatInfo = null;
            YearOfManufacture.HeaderText = "Year Of Manufacture";
            YearOfManufacture.MappingName = "YearOfManufacture";
            YearOfManufacture.ReadOnly = true;
            YearOfManufacture.Width = 75;
            YearOfManufacture.NullText = "";
            tStyle.GridColumnStyles.Add(YearOfManufacture);
            var ApproxValue = new DataGridLabelColumn();
            ApproxValue.Format = "C";
            ApproxValue.FormatInfo = null;
            ApproxValue.HeaderText = "Approx.Value";
            ApproxValue.MappingName = "ApproximateValue";
            ApproxValue.ReadOnly = true;
            ApproxValue.Width = 75;
            ApproxValue.NullText = "";
            tStyle.GridColumnStyles.Add(ApproxValue);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblAsset.ToString();
            dgAssets.TableStyles.Add(tStyle);
            Helper.RemoveEventHandlers(dgAssets);
        }

        private void FRMLogCallout_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        public void MakeReadOnly()
        {
            btnSave.Enabled = false;
            tpAssets.Enabled = false;
            tbquote.Enabled = false;
            tpDocuments.Enabled = false;
            ((UCLogCallout)LoadedControl).gbPaymentType.Enabled = false;
            ((UCLogCallout)LoadedControl).btnFindUser.Enabled = false;
            ((UCLogCallout)LoadedControl).cboJobType.Enabled = false;
            ((UCLogCallout)LoadedControl).btnChange.Enabled = false;
            ((UCLogCallout)LoadedControl).btnfindVan.Enabled = false;
            ((UCLogCallout)LoadedControl).btnAddJobOfWork.Enabled = false;
            ((UCLogCallout)LoadedControl).btnRemoveJobOfWork.Enabled = false;
            foreach (TabPage tp in ((UCLogCallout)LoadedControl)?.tcJobOfWorks?.TabPages)
            {
                ((UCCalloutBreakdown)tp.Controls[0]).txtPONumber.Enabled = false;
                ((UCCalloutBreakdown)tp.Controls[0]).cboPriority.Enabled = false;
                ((UCCalloutBreakdown)tp.Controls[0]).cboQualification.Enabled = false;
                ((UCCalloutBreakdown)tp.Controls[0]).btnAddEngineerVisit.Enabled = false;
                ((UCCalloutBreakdown)tp.Controls[0]).btnRemoveEngineerVisit.Enabled = false;
                ((UCCalloutBreakdown)tp.Controls[0]).txtJobItemSummary.Enabled = false;
                ((UCCalloutBreakdown)tp.Controls[0]).btnRemoveItem.Enabled = false;
                ((UCCalloutBreakdown)tp.Controls[0]).btnSaveItem.Enabled = false;
                ((UCCalloutBreakdown)tp.Controls[0]).btnAddRate.Enabled = false;
                foreach (TabPage tp1 in ((UCCalloutBreakdown)tp.Controls[0])?.tcEngineerVisits?.TabPages)
                {
                    ((UCVisitBreakdown)tp1.Controls[0]).tpParts.Enabled = false;
                    ((UCVisitBreakdown)tp1.Controls[0]).EstVisitDate.Enabled = false;
                    ((UCVisitBreakdown)tp1.Controls[0]).chkRecharge.Enabled = false;
                    ((UCVisitBreakdown)tp1.Controls[0]).cbxPartsToFit.Enabled = false;
                    ((UCVisitBreakdown)tp1.Controls[0]).txtNotesToEngineer.Enabled = false;
                }
            }
        }

        private void dgAssets_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedAssetDataRow is null)
                {
                    return;
                }

                bool selected = !Conversions.ToBoolean(dgAssets[dgAssets.CurrentRowIndex, 0]);
                dgAssets[dgAssets.CurrentRowIndex, 0] = selected;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddAppliance_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMAsset), true, new object[] { 0, 0, ((UCLogCallout)LoadedControl).Site.SiteID });
            AssetsDataView = App.DB.Asset.Asset_GetForSite(((UCLogCallout)LoadedControl).Job.PropertyID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
                // NO NEED TO DO ANYTHING AS THIS WILL ACTION THE SAME THING TWICE
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            cmsView.Show(btnView, new Point(0, 0));
        }

        public void CloseForm()
        {
            if (((UCLogCallout)TheLoadedControl).Job.JobID == 0)
            {
                App.DB.Job.DeleteReservedOrderNumber(((UCLogCallout)TheLoadedControl).JobNumber.Number, ((UCLogCallout)TheLoadedControl).JobNumber.Prefix);
            }

            if (JobLock is object)
            {
                if (JobLock.UserID == App.loggedInUser.UserID)
                {
                    App.DB.JobLock.Delete(JobLock.JobLockID);
                }
            }

            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private DataView _jobNotes = null;

        public DataView JobNotesDataView
        {
            get
            {
                return _jobNotes;
            }

            set
            {
                _jobNotes = value;
                _jobNotes.Table.TableName = Enums.TableNames.tblJobNotes.ToString();
                _jobNotes.AllowNew = false;
                _jobNotes.AllowEdit = false;
                _jobNotes.AllowDelete = false;
                dgNotes.DataSource = _jobNotes;
            }
        }

        private DataRow SelectedJobNoteDataRow
        {
            get
            {
                if (!(dgNotes.CurrentRowIndex == -1))
                {
                    return JobNotesDataView[dgNotes.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetupNotesDataGrid()
        {
            Helper.SetUpDataGrid(dgNotes);
            var tStyle = dgNotes.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgNotes.ReadOnly = true;
            var Note = new DataGridLabelColumn();
            Note.Format = "";
            Note.FormatInfo = null;
            Note.HeaderText = "Note";
            Note.MappingName = "Note";
            Note.ReadOnly = true;
            Note.Width = 250;
            Note.NullText = "";
            tStyle.GridColumnStyles.Add(Note);
            var CreatedBy = new DataGridLabelColumn();
            CreatedBy.Format = "";
            CreatedBy.FormatInfo = null;
            CreatedBy.HeaderText = "Created By";
            CreatedBy.MappingName = "CreatedBy";
            CreatedBy.ReadOnly = true;
            CreatedBy.Width = 125;
            CreatedBy.NullText = "";
            tStyle.GridColumnStyles.Add(CreatedBy);
            var DateCreated = new DataGridLabelColumn();
            DateCreated.Format = "dd/MMM/yyyy HH:mm:ss";
            DateCreated.FormatInfo = null;
            DateCreated.HeaderText = "Created";
            DateCreated.MappingName = "DateCreated";
            DateCreated.ReadOnly = true;
            DateCreated.Width = 135;
            DateCreated.NullText = "";
            tStyle.GridColumnStyles.Add(DateCreated);
            var EditedBy = new DataGridLabelColumn();
            EditedBy.Format = "";
            EditedBy.FormatInfo = null;
            EditedBy.HeaderText = "Edited By";
            EditedBy.MappingName = "EditedBy";
            EditedBy.ReadOnly = true;
            EditedBy.Width = 125;
            EditedBy.NullText = "";
            tStyle.GridColumnStyles.Add(EditedBy);
            var LastEdited = new DataGridLabelColumn();
            LastEdited.Format = "dd/MMM/yyyy HH:mm:ss";
            LastEdited.FormatInfo = null;
            LastEdited.HeaderText = "Last Edited";
            LastEdited.MappingName = "LastEdited";
            LastEdited.ReadOnly = true;
            LastEdited.Width = 135;
            LastEdited.NullText = "";
            tStyle.GridColumnStyles.Add(LastEdited);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblJobNotes.ToString();
            dgNotes.TableStyles.Add(tStyle);
            Helper.RemoveEventHandlers(dgNotes);
        }

        private void dgNotes_Click(object sender, EventArgs e)
        {
            if (SelectedJobNoteDataRow is null)
            {
                return;
            }
            else
            {
                PopulateJobNoteFields();
                txtNotes.ReadOnly = true;
                btnSaveNote.Enabled = false;
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            ClearNotesFields();
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to delete this note?" + Constants.vbCrLf;
            msg += "You will not be able to undo the delete if you proceed.";
            DataRow r;
            r = SelectedJobNoteDataRow;
            if (r is object)
            {
                if (MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    App.DB.Job.DeleteJobNote(Conversions.ToInteger(r["JobNoteID"]));
                    JobNotesDataView.Table.Rows.Remove(SelectedJobNoteDataRow);
                    ClearNotesFields();
                }
            }
        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            if (txtNotes.Text.Trim().Length > 0)
            {
                JobNotesDataView = App.DB.Job.SaveJobNotes(Helper.MakeIntegerValid(txtNoteID.Text), txtNotes.Text.Trim(), App.loggedInUser.UserID, ID, App.loggedInUser.UserID);
            }

            ClearNotesFields();
        }

        private void ClearNotesFields()
        {
            txtNoteID.Text = "";
            txtNotes.Text = "";
            ActiveControl = txtNotes;
            txtNotes.ReadOnly = false;
            txtNotes.Focus();
            btnSaveNote.Enabled = true;
            tpNotes.Text = "Notes (" + JobNotesDataView.Table.Rows.Count + ")";
        }

        private void PopulateJobNoteFields()
        {
            DataRow r;
            r = SelectedJobNoteDataRow;
            if (r is object)
            {
                txtNoteID.Text = Conversions.ToString(r["JobNoteID"]);
                txtNotes.Text = Conversions.ToString(r["Note"]);
            }

            ActiveControl = txtNotes;
            txtNotes.Focus();
        }

        private void PopulateJobNotes()
        {
            JobNotesDataView = App.DB.Job.GetJobNotes(ID);
            tpNotes.Text = "Notes (" + JobNotesDataView.Table.Rows.Count + ")";
        }

        public bool quotecreated = false;
        public string quoteresult = "";

        private void btncalc_Click(object sender, EventArgs e)
        {
            try
            {
                double labourRate = Helper.MakeDoubleValid(Combo.get_GetSelectedItemValue(cboLabour));
                if (labourRate <= 0)
                    throw new Exception("No Labour Rate selected!");
                double labour = Helper.MakeDoubleValid(txtLabourQty.Text);
                if (labour <= 0)
                    throw new Exception("Labour Value incorrect!");
                double labourCost = Math.Round(labour * labourRate, 2);
                decimal claimLimit = Conversions.ToDecimal(Helper.MakeDoubleValid(txtClaimLimit.Text));
                if (rdoAXA.Checked & claimLimit < 0)
                    throw new Exception("Invalid claim limit!");
                string partResult = "";
                string LabourResult = "";
                string result = "";
                double partMup = 0.0;
                double partTotal = 0.0;
                double axaCallout = 59.08;
                double axaAdmin = 30;
                int rCount = 0;
                decimal markup2 = (decimal)(1 + Helper.MakeDoubleValid(App.DB.CustomerCharge.CustomerCharge_GetForCustomer(((UCLogCallout)LoadedControl).Site.CustomerID)?.PartsMarkup / 100));
                result = "Quote for Works:" + Constants.vbCrLf;
                foreach (DataRow dr in Data.Table.Rows)
                {
                    if (Conversions.ToBoolean(rbStandard.Checked & (int)dr["PartQty"] > 0))
                    {
                        rCount += 1;
                        partMup = Conversions.ToDouble(Markup(Math.Round(decimal.Parse(Conversions.ToString(dr["PartCost"])), 2, MidpointRounding.AwayFromZero)));
                        partResult += Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString("Materials " + rCount + ": Code: " + dr["PartNumber"] + " / Name: ") + dr["PartName"] + " / Cost: £") + partMup + " X ") + dr["PartQty"] + " = £") + Math.Round(partMup * (int)dr["PartQty"], 2, MidpointRounding.AwayFromZero) + Constants.vbCrLf;
                        partTotal += Math.Round(partMup * (int)dr["PartQty"], 2, MidpointRounding.AwayFromZero);
                    }
                    else if (Conversions.ToBoolean((int)dr["PartQty"] > 0))
                    {
                        rCount += 1;
                        partMup = Conversions.ToDouble((decimal)dr["Partcost"] * markup2);
                        partResult += Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString("Materials " + rCount + ": Code: " + dr["PartNumber"] + " / Name: ") + dr["PartName"] + " / Cost: £") + partMup + " X ") + dr["PartQty"] + " = £") + Math.Round(partMup * (int)dr["PartQty"], 2, MidpointRounding.AwayFromZero) + Constants.vbCrLf;
                        partTotal += Math.Round(partMup * (int)dr["PartQty"], 2, MidpointRounding.AwayFromZero);
                    }
                }

                LabourResult += "Labour @ £" + labourRate + " X " + labour + " = £" + labourCost + Constants.vbCrLf;
                decimal subtotal = 0.0M;
                if (rdoPOC.Checked)
                {
                    subtotal = Conversions.ToDecimal(Math.Round(partTotal + labourCost, 2, MidpointRounding.AwayFromZero));
                }
                else
                {
                    subtotal = Conversions.ToDecimal(Math.Round(partTotal + axaCallout + labourCost, 2, MidpointRounding.AwayFromZero));
                }

                decimal vat = 0;
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVATRate)) > 0)
                {
                    vat = Conversions.ToDecimal(Math.Round(Conversions.ToDouble(subtotal) * (1 + App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboVATRate))).VATRate / 100) - Conversions.ToDouble(subtotal), 2, MidpointRounding.AwayFromZero));
                }

                decimal total = subtotal + vat;
                result += partResult;
                if (rdoAXA.Checked)
                {
                    result += "Callout @ £" + axaCallout + Constants.vbCrLf;
                }

                result += LabourResult;
                result += "Sub Total = £" + subtotal;
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVATRate)) > 0 & !chkExcludeVat.Checked)
                {
                    if (rdoPOC.Checked)
                    {
                        result += " + VAT (£" + total + " inc VAT) ";
                    }
                    else
                    {
                        result += " + VAT (£" + total + " inc VAT) ";
                        result += " Plus AXA admin fee: £" + axaAdmin;
                        total += (decimal)axaAdmin;
                        result += " Grand total: £" + total + Constants.vbCrLf;
                        result += "Total Price for work: £" + total + " minus claim limit £" + claimLimit;
                        double grandtotal = (double)total - (double)claimLimit;
                        if (grandtotal <= 0)
                        {
                            result += " = Underlimit - Please proceed";
                        }
                        else
                        {
                            result += " = Total payable of £" + grandtotal + " inc VAT";
                        }
                    }
                }
                else
                {
                    result += " Ex VAT";
                }

                quotecreated = true;
                quoteresult = result;
                tbresult.Text = result;
                btnaddtonotes.Enabled = true;
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal Markup(decimal cost)
        {
            decimal thiscost;
            if (cost <= 20)
            {
                thiscost = cost * 2;
            }
            else if (cost > 20 & cost <= 50)
            {
                thiscost = (decimal)(Conversions.ToDouble(cost) * 1.8);
            }
            else if (cost > 50 & cost <= 100)
            {
                thiscost = (decimal)(Conversions.ToDouble(cost) * 1.7);
            }
            else if (cost > 100 & cost <= 200)
            {
                thiscost = (decimal)(Conversions.ToDouble(cost) * 1.6);
            }
            else if (cost > 200 & cost <= 300)
            {
                thiscost = (decimal)(Conversions.ToDouble(cost) * 1.5);
            }
            else if (cost > 300 & cost <= 400)
            {
                thiscost = (decimal)(Conversions.ToDouble(cost) * 1.45);
            }
            else
            {
                thiscost = (decimal)(Conversions.ToDouble(cost) * 1.4);
            }

            return Math.Round(thiscost, 2, MidpointRounding.AwayFromZero);
        }

        private double numbertest(string number)
        {
            decimal Result;
            double outcome;
            if (decimal.TryParse(number, out Result))
            {
                outcome = Conversions.ToDouble(number);
            }
            else
            {
                outcome = 0;
            }

            return outcome;
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please manually email this quote to the client. Button not in operation", "Gasway Services: Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnaddtonotes_Click(object sender, EventArgs e)
        {
            if (quoteresult.Length > 1 == true)
            {
                JobNotesDataView = App.DB.Job.SaveJobNotes(0, quoteresult, App.loggedInUser.UserID, ID, App.loggedInUser.UserID);
                PopulateJobNotes();
                btnEmail.Enabled = true;
            }
        }

        private void BtnQuoteAdd_Click(object sender, EventArgs e)
        {
            var dr = Data.Table.NewRow();
            if (numbertest(txtPartQty.Text) > 0 && numbertest(txtPartRate.Text) > 0)
            {
                if (numbertest(txtPartQty.Text) > 0)
                {
                    dr["PartQty"] = numbertest(txtPartQty.Text);
                    dr["PartName"] = txtPartName.Text;
                    dr["PartNumber"] = txtPartNumber.Text;
                    dr["PartCost"] = numbertest(txtPartRate.Text);
                }
                else
                {
                    dr["PartQty"] = "0";
                    dr["PartName"] = "N/A";
                    dr["PartNumber"] = "N/A";
                    dr["PartCost"] = "N/A";
                }

                Data.Table.Rows.Add(dr);
                txtPartQty.Text = 0.ToString();
                txtPartName.Text = "";
                txtPartNumber.Text = "";
                txtPartRate.Text = "";
            }
            else
            {
                Interaction.MsgBox("Nothing to add", MsgBoxStyle.OkOnly, "Error");
            }
        }

        private void PropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMSite), true, new object[] { ((UCLogCallout)LoadedControl).Site.SiteID, this });
        }

        private void AuditTrailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMJobAudit), true, new object[] { ID });
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Navigation.Navigate(Enums.MenuTypes.Spares))
                {
                    CloseForm();
                    App.ShowForm(typeof(FRMOrderManager), false, new object[] { App.DB.Order.Orders_GetForJob(ID), null });
                }
            }
        }

        private void InvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Navigation.Navigate(Enums.MenuTypes.Invoicing) == true)
                {
                    CloseForm();
                    var dv = App.DB.InvoiceToBeRaised.Invoices_GetAll_For_JobID(ID);
                    bool @checked = true;
                    if (dv.Table.Rows.Count > 0)
                    {
                        if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(dv.Table.Rows[0]["InvoiceToBeRaisedID"])).Table.Rows.Count > 0)
                        {
                            @checked = false;
                        }
                    }

                    App.ShowForm(typeof(FRMInvoiceManager), false, new object[] { dv, @checked });
                }
            }
        }

        private void QuoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMQuoteJob), true, new object[] { ((UCLogCallout)LoadedControl).Job.QuoteID, ((UCLogCallout)LoadedControl).Site.SiteID });
        }

        private void HistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMSiteVisitManager), true, new object[] { ((UCLogCallout)LoadedControl).Site.SiteID });
        }

        private void CostingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfFactory.GenerateJobCostings(((UCLogCallout)LoadedControl).Job);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbresult.Text = "";
            Data.Table.Clear();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMCustomer), true, new object[] { ((UCLogCallout)LoadedControl).Site.CustomerID });
        }

        private void rdoCust_CheckedChanged(object sender, EventArgs e)
        {
            lblClaimLimit.Visible = rdoAXA.Checked;
            txtClaimLimit.Visible = rdoAXA.Checked;
            chkExcludeVat.Visible = rdoPOC.Checked;
            if (rdoAXA.Checked)
            {
                chkExcludeVat.Checked = false;
            }
        }

        private DataView _dvcontactAttempts = null;

        public DataView DvContactAttempts
        {
            get
            {
                return _dvcontactAttempts;
            }

            set
            {
                _dvcontactAttempts = value;
                _dvcontactAttempts.Table.TableName = Enums.TableNames.tblContact.ToString();
                _dvcontactAttempts.AllowNew = false;
                _dvcontactAttempts.AllowEdit = false;
                _dvcontactAttempts.AllowDelete = false;
                dgContactAttempts.DataSource = _dvcontactAttempts;
            }
        }

        private DataRow DrSelectedContactAttempt
        {
            get
            {
                if (!(dgContactAttempts.CurrentRowIndex == -1))
                {
                    return DvContactAttempts[dgContactAttempts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetupContactAttemptDataGrid()
        {
            Helper.SetUpDataGrid(dgContactAttempts);
            var tStyle = dgContactAttempts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgContactAttempts.ReadOnly = true;
            var contactMethod = new DataGridLabelColumn();
            contactMethod.Format = "";
            contactMethod.FormatInfo = null;
            contactMethod.HeaderText = "Method";
            contactMethod.MappingName = "ContactMethod";
            contactMethod.ReadOnly = true;
            contactMethod.Width = 250;
            contactMethod.NullText = "";
            tStyle.GridColumnStyles.Add(contactMethod);
            var contactDate = new DataGridLabelColumn();
            contactDate.Format = "dd/MMM/yyyy HH:mm:ss";
            contactDate.FormatInfo = null;
            contactDate.HeaderText = "Contact Date";
            contactDate.MappingName = "ContactMade";
            contactDate.ReadOnly = true;
            contactDate.Width = 135;
            contactDate.NullText = "";
            tStyle.GridColumnStyles.Add(contactDate);
            var notes = new DataGridLabelColumn();
            notes.Format = "";
            notes.FormatInfo = null;
            notes.HeaderText = "Note";
            notes.MappingName = "Note";
            notes.ReadOnly = true;
            notes.Width = 250;
            notes.NullText = "";
            tStyle.GridColumnStyles.Add(notes);
            var contactMadeBy = new DataGridLabelColumn();
            contactMadeBy.Format = "";
            contactMadeBy.FormatInfo = null;
            contactMadeBy.HeaderText = "By";
            contactMadeBy.MappingName = "ContactMadeBy";
            contactMadeBy.ReadOnly = true;
            contactMadeBy.Width = 125;
            contactMadeBy.NullText = "";
            tStyle.GridColumnStyles.Add(contactMadeBy);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblContact.ToString();
            dgContactAttempts.TableStyles.Add(tStyle);
            Helper.RemoveEventHandlers(dgContactAttempts);
        }

        public void PopulateContactAttempts()
        {
            int countRows = 0;
            if (((UCLogCallout)LoadedControl).ContactAttempts?.Count > 0 == true)
            {
                DvContactAttempts = new DataView(Helper.ToDataTable(((UCLogCallout)LoadedControl).ContactAttempts));
                countRows = DvContactAttempts.Table.Rows.Count;
            }

            tpContactAttempts.Text = "Contact Attempts (" + countRows + ")";
        }

        private void btnAddAttempt_Click(object sender, EventArgs e)
        {
            ((UCLogCallout)LoadedControl).AddContactAttempt();
        }

        private void dgContactAttempts_Click(object sender, EventArgs e)
        {
            if (DrSelectedContactAttempt is null)
            {
                return;
            }
            else
            {
                txtContactAttemptDetails.Text = Conversions.ToString(DrSelectedContactAttempt["ContactMethod"] + " on " + Helper.MakeDateTimeValid(DrSelectedContactAttempt["ContactMade"]).ToString("dddd, dd MMMM yyyy HH:mm"));
                txtContactAttemptDetails.Text += Constants.vbCrLf + "By " + DrSelectedContactAttempt["ContactMadeBy"];
                txtContactAttemptDetails.Text += Constants.vbCrLf + Constants.vbCrLf + "Note: " + DrSelectedContactAttempt["Notes"];
            }
        }
    }
}