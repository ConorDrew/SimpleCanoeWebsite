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

        internal GroupBox grpAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAssets != null)
                {
                }

                _grpAssets = value;
                if (_grpAssets != null)
                {
                }
            }
        }

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

        internal ToolStripMenuItem PropertyToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PropertyToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PropertyToolStripMenuItem != null)
                {
                    _PropertyToolStripMenuItem.Click -= PropertyToolStripMenuItem_Click;
                }

                _PropertyToolStripMenuItem = value;
                if (_PropertyToolStripMenuItem != null)
                {
                    _PropertyToolStripMenuItem.Click += PropertyToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _CustomerToolStripMenuItem;

        internal ToolStripMenuItem CustomerToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CustomerToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CustomerToolStripMenuItem != null)
                {
                    _CustomerToolStripMenuItem.Click -= CustomerToolStripMenuItem_Click;
                }

                _CustomerToolStripMenuItem = value;
                if (_CustomerToolStripMenuItem != null)
                {
                    _CustomerToolStripMenuItem.Click += CustomerToolStripMenuItem_Click;
                }
            }
        }

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

        internal ToolStripMenuItem HistoryToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HistoryToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HistoryToolStripMenuItem != null)
                {
                    _HistoryToolStripMenuItem.Click -= HistoryToolStripMenuItem_Click;
                }

                _HistoryToolStripMenuItem = value;
                if (_HistoryToolStripMenuItem != null)
                {
                    _HistoryToolStripMenuItem.Click += HistoryToolStripMenuItem_Click;
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

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                }
            }
        }

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

        internal Label lblVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVAT != null)
                {
                }

                _lblVAT = value;
                if (_lblVAT != null)
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

        internal RadioButton rbSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbSite != null)
                {
                }

                _rbSite = value;
                if (_rbSite != null)
                {
                }
            }
        }

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

        internal Label Label46
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label46;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label46 != null)
                {
                }

                _Label46 = value;
                if (_Label46 != null)
                {
                }
            }
        }

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

        internal Button btnQuoteAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnQuoteAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnQuoteAdd != null)
                {
                    _btnQuoteAdd.Click -= BtnQuoteAdd_Click;
                }

                _btnQuoteAdd = value;
                if (_btnQuoteAdd != null)
                {
                    _btnQuoteAdd.Click += BtnQuoteAdd_Click;
                }
            }
        }

        private Label _Label45;

        internal Label Label45
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label45;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label45 != null)
                {
                }

                _Label45 = value;
                if (_Label45 != null)
                {
                }
            }
        }

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

        internal Label Label44
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label44;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label44 != null)
                {
                }

                _Label44 = value;
                if (_Label44 != null)
                {
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

        internal Label lbltc1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltc1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltc1 != null)
                {
                }

                _lbltc1 = value;
                if (_lbltc1 != null)
                {
                }
            }
        }

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

        internal Label lblnumber1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblnumber1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblnumber1 != null)
                {
                }

                _lblnumber1 = value;
                if (_lblnumber1 != null)
                {
                }
            }
        }

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

        internal Label lblpart1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblpart1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblpart1 != null)
                {
                }

                _lblpart1 = value;
                if (_lblpart1 != null)
                {
                }
            }
        }

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

        internal GroupBox grpContactAttemptDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContactAttemptDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContactAttemptDetails != null)
                {
                }

                _grpContactAttemptDetails = value;
                if (_grpContactAttemptDetails != null)
                {
                }
            }
        }

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

        internal Label lblContactNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContactNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContactNotes != null)
                {
                }

                _lblContactNotes = value;
                if (_lblContactNotes != null)
                {
                }
            }
        }

        private GroupBox _grpContactAttempts;

        internal GroupBox grpContactAttempts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContactAttempts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContactAttempts != null)
                {
                }

                _grpContactAttempts = value;
                if (_grpContactAttempts != null)
                {
                }
            }
        }

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
            components = new System.ComponentModel.Container();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _TabControl1 = new TabControl();
            _tpMain = new TabPage();
            _tpAssets = new TabPage();
            _grpAssets = new GroupBox();
            _dgAssets = new DataGrid();
            _dgAssets.Click += new EventHandler(dgAssets_Click);
            _btnAddAppliance = new Button();
            _btnAddAppliance.Click += new EventHandler(btnAddAppliance_Click);
            _tpDocuments = new TabPage();
            _tbquote = new TabPage();
            _GroupBox2 = new GroupBox();
            _GroupBox1 = new GroupBox();
            _rdoAXA = new RadioButton();
            _rdoAXA.CheckedChanged += new EventHandler(rdoCust_CheckedChanged);
            _rdoPOC = new RadioButton();
            _rdoPOC.CheckedChanged += new EventHandler(rdoCust_CheckedChanged);
            _Panel1 = new Panel();
            _txtClaimLimit = new TextBox();
            _lblClaimLimit = new Label();
            _chkExcludeVat = new CheckBox();
            _cboVATRate = new ComboBox();
            _lblVAT = new Label();
            _GroupBox3 = new GroupBox();
            _rbStandard = new RadioButton();
            _rbSite = new RadioButton();
            _txtPartQty = new TextBox();
            _Label46 = new Label();
            _dgvQuote = new DataGridView();
            _cboLabour = new ComboBox();
            _btnQuoteAdd = new Button();
            _btnQuoteAdd.Click += new EventHandler(BtnQuoteAdd_Click);
            _Label45 = new Label();
            _txtLabourQty = new TextBox();
            _Label44 = new Label();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _btnaddtonotes = new Button();
            _btnaddtonotes.Click += new EventHandler(btnaddtonotes_Click);
            _btnEmail = new Button();
            _btnEmail.Click += new EventHandler(btnEmail_Click);
            _btncalc = new Button();
            _btncalc.Click += new EventHandler(btncalc_Click);
            _tbresult = new TextBox();
            _txtPartRate = new TextBox();
            _lbltc1 = new Label();
            _txtPartNumber = new TextBox();
            _lblnumber1 = new Label();
            _txtPartName = new TextBox();
            _lblpart1 = new Label();
            _tpNotes = new TabPage();
            _gpbNotesDetails = new GroupBox();
            _txtNoteID = new TextBox();
            _btnSaveNote = new Button();
            _btnSaveNote.Click += new EventHandler(btnSaveNote_Click);
            _txtNotes = new TextBox();
            _Label1 = new Label();
            _gpbNotes = new GroupBox();
            _btnDeleteNote = new Button();
            _btnDeleteNote.Click += new EventHandler(btnDeleteNote_Click);
            _dgNotes = new DataGrid();
            _dgNotes.Click += new EventHandler(dgNotes_Click);
            _dgNotes.CurrentCellChanged += new EventHandler(dgNotes_Click);
            _dgNotes.Click += new EventHandler(dgNotes_Click);
            _dgNotes.CurrentCellChanged += new EventHandler(dgNotes_Click);
            _btnAddNote = new Button();
            _btnAddNote.Click += new EventHandler(btnAddNote_Click);
            _tpContactAttempts = new TabPage();
            _grpContactAttemptDetails = new GroupBox();
            _txtContactAttemptDetails = new TextBox();
            _lblContactNotes = new Label();
            _grpContactAttempts = new GroupBox();
            _dgContactAttempts = new DataGrid();
            _dgContactAttempts.Click += new EventHandler(dgContactAttempts_Click);
            _btnAddAttempt = new Button();
            _btnAddAttempt.Click += new EventHandler(btnAddAttempt_Click);
            _btnView = new Button();
            _btnView.Click += new EventHandler(btnView_Click);
            _cmsView = new ContextMenuStrip(components);
            _PropertyToolStripMenuItem = new ToolStripMenuItem();
            _PropertyToolStripMenuItem.Click += new EventHandler(PropertyToolStripMenuItem_Click);
            _CustomerToolStripMenuItem = new ToolStripMenuItem();
            _CustomerToolStripMenuItem.Click += new EventHandler(CustomerToolStripMenuItem_Click);
            _AuditTrailToolStripMenuItem = new ToolStripMenuItem();
            _AuditTrailToolStripMenuItem.Click += new EventHandler(AuditTrailToolStripMenuItem_Click);
            _OrdersToolStripMenuItem = new ToolStripMenuItem();
            _OrdersToolStripMenuItem.Click += new EventHandler(OrdersToolStripMenuItem_Click);
            _InvoiceToolStripMenuItem = new ToolStripMenuItem();
            _InvoiceToolStripMenuItem.Click += new EventHandler(InvoiceToolStripMenuItem_Click);
            _QuoteToolStripMenuItem = new ToolStripMenuItem();
            _QuoteToolStripMenuItem.Click += new EventHandler(QuoteToolStripMenuItem_Click);
            _CostingsToolStripMenuItem = new ToolStripMenuItem();
            _CostingsToolStripMenuItem.Click += new EventHandler(CostingsToolStripMenuItem_Click);
            _HistoryToolStripMenuItem = new ToolStripMenuItem();
            _HistoryToolStripMenuItem.Click += new EventHandler(HistoryToolStripMenuItem_Click);
            _TabControl1.SuspendLayout();
            _tpAssets.SuspendLayout();
            _grpAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAssets).BeginInit();
            _tbquote.SuspendLayout();
            _GroupBox2.SuspendLayout();
            _GroupBox1.SuspendLayout();
            _Panel1.SuspendLayout();
            _GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvQuote).BeginInit();
            _tpNotes.SuspendLayout();
            _gpbNotesDetails.SuspendLayout();
            _gpbNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgNotes).BeginInit();
            _tpContactAttempts.SuspendLayout();
            _grpContactAttemptDetails.SuspendLayout();
            _grpContactAttempts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgContactAttempts).BeginInit();
            _cmsView.SuspendLayout();
            SuspendLayout();
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(70, 664);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 23);
            _btnClose.TabIndex = 16;
            _btnClose.Text = "Close";
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSave.Location = new Point(8, 664);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 23);
            _btnSave.TabIndex = 15;
            _btnSave.Text = "Save";
            //
            // TabControl1
            //
            _TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TabControl1.Controls.Add(_tpMain);
            _TabControl1.Controls.Add(_tpAssets);
            _TabControl1.Controls.Add(_tpDocuments);
            _TabControl1.Controls.Add(_tbquote);
            _TabControl1.Controls.Add(_tpNotes);
            _TabControl1.Controls.Add(_tpContactAttempts);
            _TabControl1.Location = new Point(0, 31);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(1184, 627);
            _TabControl1.TabIndex = 23;
            //
            // tpMain
            //
            _tpMain.Location = new Point(4, 22);
            _tpMain.Name = "tpMain";
            _tpMain.Padding = new Padding(3);
            _tpMain.Size = new Size(1176, 601);
            _tpMain.TabIndex = 0;
            _tpMain.Text = "Main Details";
            _tpMain.UseVisualStyleBackColor = true;
            //
            // tpAssets
            //
            _tpAssets.Controls.Add(_grpAssets);
            _tpAssets.Location = new Point(4, 22);
            _tpAssets.Name = "tpAssets";
            _tpAssets.Padding = new Padding(3);
            _tpAssets.Size = new Size(1176, 601);
            _tpAssets.TabIndex = 2;
            _tpAssets.Text = "Appliances";
            _tpAssets.UseVisualStyleBackColor = true;
            //
            // grpAssets
            //
            _grpAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAssets.Controls.Add(_dgAssets);
            _grpAssets.Controls.Add(_btnAddAppliance);
            _grpAssets.Location = new Point(6, 6);
            _grpAssets.Name = "grpAssets";
            _grpAssets.Size = new Size(1162, 596);
            _grpAssets.TabIndex = 29;
            _grpAssets.TabStop = false;
            _grpAssets.Text = "Select those related to the job";
            //
            // dgAssets
            //
            _dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAssets.DataMember = "";
            _dgAssets.HeaderForeColor = SystemColors.ControlText;
            _dgAssets.Location = new Point(6, 20);
            _dgAssets.Name = "dgAssets";
            _dgAssets.Size = new Size(1150, 541);
            _dgAssets.TabIndex = 1;
            //
            // btnAddAppliance
            //
            _btnAddAppliance.AccessibleDescription = "Add Job Of Work";
            _btnAddAppliance.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddAppliance.Location = new Point(6, 567);
            _btnAddAppliance.Name = "btnAddAppliance";
            _btnAddAppliance.Size = new Size(155, 23);
            _btnAddAppliance.TabIndex = 28;
            _btnAddAppliance.Text = "New Appliance";
            //
            // tpDocuments
            //
            _tpDocuments.Location = new Point(4, 22);
            _tpDocuments.Name = "tpDocuments";
            _tpDocuments.Padding = new Padding(3);
            _tpDocuments.Size = new Size(1176, 601);
            _tpDocuments.TabIndex = 1;
            _tpDocuments.Text = "Documents";
            _tpDocuments.UseVisualStyleBackColor = true;
            //
            // tbquote
            //
            _tbquote.Controls.Add(_GroupBox2);
            _tbquote.Location = new Point(4, 22);
            _tbquote.Name = "tbquote";
            _tbquote.Padding = new Padding(3);
            _tbquote.Size = new Size(1176, 601);
            _tbquote.TabIndex = 7;
            _tbquote.Text = "Quote Calc";
            _tbquote.UseVisualStyleBackColor = true;
            //
            // GroupBox2
            //
            _GroupBox2.Controls.Add(_GroupBox1);
            _GroupBox2.Controls.Add(_Panel1);
            _GroupBox2.Dock = DockStyle.Fill;
            _GroupBox2.Location = new Point(3, 3);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(1170, 595);
            _GroupBox2.TabIndex = 0;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Quote Calculator";
            //
            // GroupBox1
            //
            _GroupBox1.Controls.Add(_rdoAXA);
            _GroupBox1.Controls.Add(_rdoPOC);
            _GroupBox1.Location = new Point(55, 26);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(121, 45);
            _GroupBox1.TabIndex = 82;
            _GroupBox1.TabStop = false;
            //
            // rdoAXA
            //
            _rdoAXA.AutoSize = true;
            _rdoAXA.Location = new Point(65, 17);
            _rdoAXA.Name = "rdoAXA";
            _rdoAXA.Size = new Size(49, 17);
            _rdoAXA.TabIndex = 1;
            _rdoAXA.Text = "AXA";
            _rdoAXA.UseVisualStyleBackColor = true;
            //
            // rdoPOC
            //
            _rdoPOC.AutoSize = true;
            _rdoPOC.Checked = true;
            _rdoPOC.Location = new Point(6, 17);
            _rdoPOC.Name = "rdoPOC";
            _rdoPOC.Size = new Size(50, 17);
            _rdoPOC.TabIndex = 0;
            _rdoPOC.TabStop = true;
            _rdoPOC.Text = "POC";
            _rdoPOC.UseVisualStyleBackColor = true;
            //
            // Panel1
            //
            _Panel1.Controls.Add(_txtClaimLimit);
            _Panel1.Controls.Add(_lblClaimLimit);
            _Panel1.Controls.Add(_chkExcludeVat);
            _Panel1.Controls.Add(_cboVATRate);
            _Panel1.Controls.Add(_lblVAT);
            _Panel1.Controls.Add(_GroupBox3);
            _Panel1.Controls.Add(_txtPartQty);
            _Panel1.Controls.Add(_Label46);
            _Panel1.Controls.Add(_dgvQuote);
            _Panel1.Controls.Add(_cboLabour);
            _Panel1.Controls.Add(_btnQuoteAdd);
            _Panel1.Controls.Add(_Label45);
            _Panel1.Controls.Add(_txtLabourQty);
            _Panel1.Controls.Add(_Label44);
            _Panel1.Controls.Add(_btnReset);
            _Panel1.Controls.Add(_btnaddtonotes);
            _Panel1.Controls.Add(_btnEmail);
            _Panel1.Controls.Add(_btncalc);
            _Panel1.Controls.Add(_tbresult);
            _Panel1.Controls.Add(_txtPartRate);
            _Panel1.Controls.Add(_lbltc1);
            _Panel1.Controls.Add(_txtPartNumber);
            _Panel1.Controls.Add(_lblnumber1);
            _Panel1.Controls.Add(_txtPartName);
            _Panel1.Controls.Add(_lblpart1);
            _Panel1.Dock = DockStyle.Fill;
            _Panel1.Location = new Point(3, 17);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(1164, 575);
            _Panel1.TabIndex = 1;
            //
            // txtClaimLimit
            //
            _txtClaimLimit.Location = new Point(585, 62);
            _txtClaimLimit.Name = "txtClaimLimit";
            _txtClaimLimit.Size = new Size(121, 21);
            _txtClaimLimit.TabIndex = 83;
            _txtClaimLimit.Visible = false;
            //
            // lblClaimLimit
            //
            _lblClaimLimit.AutoSize = true;
            _lblClaimLimit.Location = new Point(505, 65);
            _lblClaimLimit.Name = "lblClaimLimit";
            _lblClaimLimit.Size = new Size(71, 13);
            _lblClaimLimit.TabIndex = 82;
            _lblClaimLimit.Text = "Claim Limit";
            _lblClaimLimit.Visible = false;
            //
            // chkExcludeVat
            //
            _chkExcludeVat.AutoSize = true;
            _chkExcludeVat.Location = new Point(425, 505);
            _chkExcludeVat.Name = "chkExcludeVat";
            _chkExcludeVat.Size = new Size(103, 17);
            _chkExcludeVat.TabIndex = 81;
            _chkExcludeVat.Text = "Exclude V.A.T";
            _chkExcludeVat.UseVisualStyleBackColor = true;
            //
            // cboVATRate
            //
            _cboVATRate.FormattingEnabled = true;
            _cboVATRate.Location = new Point(499, 528);
            _cboVATRate.Name = "cboVATRate";
            _cboVATRate.Size = new Size(109, 21);
            _cboVATRate.TabIndex = 79;
            //
            // lblVAT
            //
            _lblVAT.Location = new Point(422, 529);
            _lblVAT.Name = "lblVAT";
            _lblVAT.Size = new Size(68, 17);
            _lblVAT.TabIndex = 80;
            _lblVAT.Text = "VAT Rate";
            _lblVAT.TextAlign = ContentAlignment.MiddleLeft;
            //
            // GroupBox3
            //
            _GroupBox3.Controls.Add(_rbStandard);
            _GroupBox3.Controls.Add(_rbSite);
            _GroupBox3.Location = new Point(48, 491);
            _GroupBox3.Name = "GroupBox3";
            _GroupBox3.Size = new Size(343, 45);
            _GroupBox3.TabIndex = 77;
            _GroupBox3.TabStop = false;
            //
            // rbStandard
            //
            _rbStandard.AutoSize = true;
            _rbStandard.Checked = true;
            _rbStandard.Location = new Point(207, 16);
            _rbStandard.Name = "rbStandard";
            _rbStandard.Size = new Size(121, 17);
            _rbStandard.TabIndex = 1;
            _rbStandard.TabStop = true;
            _rbStandard.Text = "Markup standard";
            _rbStandard.UseVisualStyleBackColor = true;
            //
            // rbSite
            //
            _rbSite.AutoSize = true;
            _rbSite.Location = new Point(6, 17);
            _rbSite.Name = "rbSite";
            _rbSite.Size = new Size(185, 17);
            _rbSite.TabIndex = 0;
            _rbSite.Text = "Markup parts using site rate";
            _rbSite.UseVisualStyleBackColor = true;
            //
            // txtPartQty
            //
            _txtPartQty.Location = new Point(659, 89);
            _txtPartQty.Name = "txtPartQty";
            _txtPartQty.Size = new Size(48, 21);
            _txtPartQty.TabIndex = 76;
            _txtPartQty.Text = "0";
            //
            // Label46
            //
            _Label46.AutoSize = true;
            _Label46.Location = new Point(629, 92);
            _Label46.Name = "Label46";
            _Label46.Size = new Size(27, 13);
            _Label46.TabIndex = 75;
            _Label46.Text = "Qty";
            //
            // dgvQuote
            //
            _dgvQuote.AllowUserToAddRows = false;
            _dgvQuote.AllowUserToResizeColumns = false;
            _dgvQuote.AllowUserToResizeRows = false;
            _dgvQuote.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvQuote.Location = new Point(48, 124);
            _dgvQuote.Name = "dgvQuote";
            _dgvQuote.Size = new Size(811, 210);
            _dgvQuote.TabIndex = 74;
            //
            // cboLabour
            //
            _cboLabour.FormattingEnabled = true;
            _cboLabour.Location = new Point(125, 62);
            _cboLabour.Name = "cboLabour";
            _cboLabour.Size = new Size(294, 21);
            _cboLabour.TabIndex = 73;
            //
            // btnQuoteAdd
            //
            _btnQuoteAdd.Location = new Point(820, 65);
            _btnQuoteAdd.Name = "btnQuoteAdd";
            _btnQuoteAdd.Size = new Size(39, 47);
            _btnQuoteAdd.TabIndex = 72;
            _btnQuoteAdd.Text = "Add";
            _btnQuoteAdd.UseVisualStyleBackColor = true;
            //
            // Label45
            //
            _Label45.AutoSize = true;
            _Label45.Location = new Point(45, 65);
            _Label45.Name = "Label45";
            _Label45.Size = new Size(77, 13);
            _Label45.TabIndex = 71;
            _Label45.Text = "Labour Type";
            //
            // txtLabourQty
            //
            _txtLabourQty.Location = new Point(449, 62);
            _txtLabourQty.Name = "txtLabourQty";
            _txtLabourQty.Size = new Size(29, 21);
            _txtLabourQty.TabIndex = 70;
            _txtLabourQty.Text = "0";
            //
            // Label44
            //
            _Label44.AutoSize = true;
            _Label44.Location = new Point(427, 65);
            _Label44.Name = "Label44";
            _Label44.Size = new Size(15, 13);
            _Label44.TabIndex = 69;
            _Label44.Text = "X";
            //
            // btnReset
            //
            _btnReset.Location = new Point(614, 526);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(110, 23);
            _btnReset.TabIndex = 68;
            _btnReset.Text = "Reset";
            _btnReset.UseVisualStyleBackColor = true;
            //
            // btnaddtonotes
            //
            _btnaddtonotes.Enabled = false;
            _btnaddtonotes.Location = new Point(730, 499);
            _btnaddtonotes.Name = "btnaddtonotes";
            _btnaddtonotes.Size = new Size(130, 23);
            _btnaddtonotes.TabIndex = 67;
            _btnaddtonotes.Text = "Add Quote to Notes";
            _btnaddtonotes.UseVisualStyleBackColor = true;
            //
            // btnEmail
            //
            _btnEmail.Enabled = false;
            _btnEmail.Location = new Point(730, 526);
            _btnEmail.Name = "btnEmail";
            _btnEmail.Size = new Size(130, 23);
            _btnEmail.TabIndex = 66;
            _btnEmail.Text = "Email Quote";
            _btnEmail.UseVisualStyleBackColor = true;
            //
            // btncalc
            //
            _btncalc.Location = new Point(614, 499);
            _btncalc.Name = "btncalc";
            _btncalc.Size = new Size(110, 23);
            _btncalc.TabIndex = 65;
            _btncalc.Text = "Generate Quote";
            _btncalc.UseVisualStyleBackColor = true;
            //
            // tbresult
            //
            _tbresult.Location = new Point(48, 357);
            _tbresult.Multiline = true;
            _tbresult.Name = "tbresult";
            _tbresult.ReadOnly = true;
            _tbresult.RightToLeft = RightToLeft.No;
            _tbresult.Size = new Size(812, 128);
            _tbresult.TabIndex = 64;
            _tbresult.Text = "Please enter details above. Quote will appear here";
            //
            // txtPartRate
            //
            _txtPartRate.Location = new Point(558, 89);
            _txtPartRate.Name = "txtPartRate";
            _txtPartRate.Size = new Size(55, 21);
            _txtPartRate.TabIndex = 5;
            //
            // lbltc1
            //
            _lbltc1.AutoSize = true;
            _lbltc1.Location = new Point(456, 92);
            _lbltc1.Name = "lbltc1";
            _lbltc1.Size = new Size(96, 13);
            _lbltc1.TabIndex = 4;
            _lbltc1.Text = "Part Trade Cost";
            //
            // txtPartNumber
            //
            _txtPartNumber.Location = new Point(349, 89);
            _txtPartNumber.Name = "txtPartNumber";
            _txtPartNumber.Size = new Size(89, 21);
            _txtPartNumber.TabIndex = 3;
            //
            // lblnumber1
            //
            _lblnumber1.AutoSize = true;
            _lblnumber1.Location = new Point(264, 92);
            _lblnumber1.Name = "lblnumber1";
            _lblnumber1.Size = new Size(79, 13);
            _lblnumber1.TabIndex = 2;
            _lblnumber1.Text = "Part Number";
            //
            // txtPartName
            //
            _txtPartName.Location = new Point(125, 89);
            _txtPartName.Name = "txtPartName";
            _txtPartName.Size = new Size(121, 21);
            _txtPartName.TabIndex = 1;
            //
            // lblpart1
            //
            _lblpart1.AutoSize = true;
            _lblpart1.Location = new Point(45, 92);
            _lblpart1.Name = "lblpart1";
            _lblpart1.Size = new Size(67, 13);
            _lblpart1.TabIndex = 0;
            _lblpart1.Text = "Part Name";
            //
            // tpNotes
            //
            _tpNotes.Controls.Add(_gpbNotesDetails);
            _tpNotes.Controls.Add(_gpbNotes);
            _tpNotes.Location = new Point(4, 22);
            _tpNotes.Name = "tpNotes";
            _tpNotes.Size = new Size(1176, 601);
            _tpNotes.TabIndex = 4;
            _tpNotes.Text = "Notes";
            _tpNotes.UseVisualStyleBackColor = true;
            //
            // gpbNotesDetails
            //
            _gpbNotesDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _gpbNotesDetails.Controls.Add(_txtNoteID);
            _gpbNotesDetails.Controls.Add(_btnSaveNote);
            _gpbNotesDetails.Controls.Add(_txtNotes);
            _gpbNotesDetails.Controls.Add(_Label1);
            _gpbNotesDetails.Location = new Point(791, 6);
            _gpbNotesDetails.Name = "gpbNotesDetails";
            _gpbNotesDetails.Size = new Size(377, 596);
            _gpbNotesDetails.TabIndex = 33;
            _gpbNotesDetails.TabStop = false;
            _gpbNotesDetails.Text = "Details";
            //
            // txtNoteID
            //
            _txtNoteID.Location = new Point(66, 14);
            _txtNoteID.Name = "txtNoteID";
            _txtNoteID.Size = new Size(100, 21);
            _txtNoteID.TabIndex = 36;
            _txtNoteID.TabStop = false;
            _txtNoteID.Visible = false;
            //
            // btnSaveNote
            //
            _btnSaveNote.AccessibleDescription = "";
            _btnSaveNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveNote.Location = new Point(292, 567);
            _btnSaveNote.Name = "btnSaveNote";
            _btnSaveNote.Size = new Size(79, 23);
            _btnSaveNote.TabIndex = 1;
            _btnSaveNote.Text = "Save";
            //
            // txtNotes
            //
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(6, 37);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.Size = new Size(365, 524);
            _txtNotes.TabIndex = 0;
            //
            // Label1
            //
            _Label1.Location = new Point(3, 20);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(88, 23);
            _Label1.TabIndex = 34;
            _Label1.Text = "Notes:";
            //
            // gpbNotes
            //
            _gpbNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbNotes.Controls.Add(_btnDeleteNote);
            _gpbNotes.Controls.Add(_dgNotes);
            _gpbNotes.Controls.Add(_btnAddNote);
            _gpbNotes.Location = new Point(7, 6);
            _gpbNotes.Name = "gpbNotes";
            _gpbNotes.Size = new Size(773, 596);
            _gpbNotes.TabIndex = 30;
            _gpbNotes.TabStop = false;
            _gpbNotes.Text = "Notes";
            //
            // btnDeleteNote
            //
            _btnDeleteNote.AccessibleDescription = "";
            _btnDeleteNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnDeleteNote.Location = new Point(95, 567);
            _btnDeleteNote.Name = "btnDeleteNote";
            _btnDeleteNote.Size = new Size(85, 23);
            _btnDeleteNote.TabIndex = 3;
            _btnDeleteNote.Text = "Delete";
            _btnDeleteNote.Visible = false;
            //
            // dgNotes
            //
            _dgNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgNotes.DataMember = "";
            _dgNotes.HeaderForeColor = SystemColors.ControlText;
            _dgNotes.Location = new Point(6, 20);
            _dgNotes.Name = "dgNotes";
            _dgNotes.Size = new Size(761, 541);
            _dgNotes.TabIndex = 1;
            //
            // btnAddNote
            //
            _btnAddNote.AccessibleDescription = "";
            _btnAddNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddNote.Location = new Point(6, 567);
            _btnAddNote.Name = "btnAddNote";
            _btnAddNote.Size = new Size(85, 23);
            _btnAddNote.TabIndex = 2;
            _btnAddNote.Text = "Add";
            //
            // tpContactAttempts
            //
            _tpContactAttempts.Controls.Add(_grpContactAttemptDetails);
            _tpContactAttempts.Controls.Add(_grpContactAttempts);
            _tpContactAttempts.Location = new Point(4, 22);
            _tpContactAttempts.Name = "tpContactAttempts";
            _tpContactAttempts.Size = new Size(1176, 601);
            _tpContactAttempts.TabIndex = 8;
            _tpContactAttempts.Text = "Contact Attempts";
            _tpContactAttempts.UseVisualStyleBackColor = true;
            //
            // grpContactAttemptDetails
            //
            _grpContactAttemptDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _grpContactAttemptDetails.Controls.Add(_txtContactAttemptDetails);
            _grpContactAttemptDetails.Controls.Add(_lblContactNotes);
            _grpContactAttemptDetails.Location = new Point(792, 2);
            _grpContactAttemptDetails.Name = "grpContactAttemptDetails";
            _grpContactAttemptDetails.Size = new Size(377, 596);
            _grpContactAttemptDetails.TabIndex = 35;
            _grpContactAttemptDetails.TabStop = false;
            _grpContactAttemptDetails.Text = "Details";
            //
            // txtContactAttemptDetails
            //
            _txtContactAttemptDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtContactAttemptDetails.Location = new Point(6, 37);
            _txtContactAttemptDetails.Multiline = true;
            _txtContactAttemptDetails.Name = "txtContactAttemptDetails";
            _txtContactAttemptDetails.ReadOnly = true;
            _txtContactAttemptDetails.Size = new Size(365, 553);
            _txtContactAttemptDetails.TabIndex = 0;
            //
            // lblContactNotes
            //
            _lblContactNotes.Location = new Point(3, 20);
            _lblContactNotes.Name = "lblContactNotes";
            _lblContactNotes.Size = new Size(88, 23);
            _lblContactNotes.TabIndex = 34;
            _lblContactNotes.Text = "Notes:";
            //
            // grpContactAttempts
            //
            _grpContactAttempts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpContactAttempts.Controls.Add(_dgContactAttempts);
            _grpContactAttempts.Controls.Add(_btnAddAttempt);
            _grpContactAttempts.Location = new Point(8, 2);
            _grpContactAttempts.Name = "grpContactAttempts";
            _grpContactAttempts.Size = new Size(773, 596);
            _grpContactAttempts.TabIndex = 34;
            _grpContactAttempts.TabStop = false;
            _grpContactAttempts.Text = "Attempts";
            //
            // dgContactAttempts
            //
            _dgContactAttempts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgContactAttempts.DataMember = "";
            _dgContactAttempts.HeaderForeColor = SystemColors.ControlText;
            _dgContactAttempts.Location = new Point(6, 20);
            _dgContactAttempts.Name = "dgContactAttempts";
            _dgContactAttempts.Size = new Size(761, 541);
            _dgContactAttempts.TabIndex = 1;
            //
            // btnAddAttempt
            //
            _btnAddAttempt.AccessibleDescription = "";
            _btnAddAttempt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddAttempt.Location = new Point(6, 567);
            _btnAddAttempt.Name = "btnAddAttempt";
            _btnAddAttempt.Size = new Size(85, 23);
            _btnAddAttempt.TabIndex = 2;
            _btnAddAttempt.Text = "Add";
            //
            // btnView
            //
            _btnView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnView.Location = new Point(132, 664);
            _btnView.Name = "btnView";
            _btnView.Size = new Size(99, 23);
            _btnView.TabIndex = 24;
            _btnView.Text = "View...";
            //
            // cmsView
            //
            _cmsView.Items.AddRange(new ToolStripItem[] { _PropertyToolStripMenuItem, _CustomerToolStripMenuItem, _AuditTrailToolStripMenuItem, _OrdersToolStripMenuItem, _InvoiceToolStripMenuItem, _QuoteToolStripMenuItem, _CostingsToolStripMenuItem, _HistoryToolStripMenuItem });
            _cmsView.Name = "cmsView";
            _cmsView.Size = new Size(128, 180);
            //
            // PropertyToolStripMenuItem
            //
            _PropertyToolStripMenuItem.Name = "PropertyToolStripMenuItem";
            _PropertyToolStripMenuItem.Size = new Size(127, 22);
            _PropertyToolStripMenuItem.Text = "Property";
            //
            // CustomerToolStripMenuItem
            //
            _CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem";
            _CustomerToolStripMenuItem.Size = new Size(127, 22);
            _CustomerToolStripMenuItem.Text = "Customer";
            //
            // AuditTrailToolStripMenuItem
            //
            _AuditTrailToolStripMenuItem.Name = "AuditTrailToolStripMenuItem";
            _AuditTrailToolStripMenuItem.Size = new Size(127, 22);
            _AuditTrailToolStripMenuItem.Text = "Audit Trail";
            //
            // OrdersToolStripMenuItem
            //
            _OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem";
            _OrdersToolStripMenuItem.Size = new Size(127, 22);
            _OrdersToolStripMenuItem.Text = "Orders";
            //
            // InvoiceToolStripMenuItem
            //
            _InvoiceToolStripMenuItem.Name = "InvoiceToolStripMenuItem";
            _InvoiceToolStripMenuItem.Size = new Size(127, 22);
            _InvoiceToolStripMenuItem.Text = "Invoice";
            //
            // QuoteToolStripMenuItem
            //
            _QuoteToolStripMenuItem.Name = "QuoteToolStripMenuItem";
            _QuoteToolStripMenuItem.Size = new Size(127, 22);
            _QuoteToolStripMenuItem.Text = "Quote";
            //
            // CostingsToolStripMenuItem
            //
            _CostingsToolStripMenuItem.Name = "CostingsToolStripMenuItem";
            _CostingsToolStripMenuItem.Size = new Size(127, 22);
            _CostingsToolStripMenuItem.Text = "Costings";
            //
            // HistoryToolStripMenuItem
            //
            _HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem";
            _HistoryToolStripMenuItem.Size = new Size(127, 22);
            _HistoryToolStripMenuItem.Text = "History";
            //
            // FRMLogCallout
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1184, 690);
            ControlBox = false;
            Controls.Add(_btnView);
            Controls.Add(_TabControl1);
            Controls.Add(_btnClose);
            Controls.Add(_btnSave);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1200, 724);
            Name = "FRMLogCallout";
            Text = "Job";
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_TabControl1, 0);
            Controls.SetChildIndex(_btnView, 0);
            _TabControl1.ResumeLayout(false);
            _tpAssets.ResumeLayout(false);
            _grpAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAssets).EndInit();
            _tbquote.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            _Panel1.ResumeLayout(false);
            _Panel1.PerformLayout();
            _GroupBox3.ResumeLayout(false);
            _GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvQuote).EndInit();
            _tpNotes.ResumeLayout(false);
            _gpbNotesDetails.ResumeLayout(false);
            _gpbNotesDetails.PerformLayout();
            _gpbNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgNotes).EndInit();
            _tpContactAttempts.ResumeLayout(false);
            _grpContactAttemptDetails.ResumeLayout(false);
            _grpContactAttemptDetails.PerformLayout();
            _grpContactAttempts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgContactAttempts).EndInit();
            _cmsView.ResumeLayout(false);
            ResumeLayout(false);
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

        public int LastViewedEngineerVisitID { get; set; }

        

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