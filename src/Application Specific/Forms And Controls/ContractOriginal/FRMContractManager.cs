using FSM.Entity.ContactAttempts;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMContractManager : FRMBaseForm, IForm
    {
        

        public FRMContractManager() : base()
        {
            
            
            base.Load += FRMContractManager_Load;

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

        private DateTimePicker _dtpTo;

        internal DateTimePicker dtpTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTo != null)
                {
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFrom;

        internal DateTimePicker dtpFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFrom != null)
                {
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
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

        private TextBox _txtContractReference;

        internal TextBox txtContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractReference != null)
                {
                }

                _txtContractReference = value;
                if (_txtContractReference != null)
                {
                }
            }
        }

        private GroupBox _grpContracts;

        internal GroupBox grpContracts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContracts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContracts != null)
                {
                }

                _grpContracts = value;
                if (_grpContracts != null)
                {
                }
            }
        }

        private DataGrid _dgContracts;

        internal DataGrid dgContracts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgContracts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgContracts != null)
                {
                    _dgContracts.DoubleClick -= dgContracts_DoubleClick;
                    _dgContracts.MouseUp -= dgContracts_MouseUp;
                }

                _dgContracts = value;
                if (_dgContracts != null)
                {
                    _dgContracts.DoubleClick += dgContracts_DoubleClick;
                    _dgContracts.MouseUp += dgContracts_MouseUp;
                }
            }
        }

        private CheckBox _cbxContractExpiryDate;

        internal CheckBox cbxContractExpiryDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxContractExpiryDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxContractExpiryDate != null)
                {
                    _cbxContractExpiryDate.CheckedChanged -= cbxContractExpiryDate_CheckedChanged;
                }

                _cbxContractExpiryDate = value;
                if (_cbxContractExpiryDate != null)
                {
                    _cbxContractExpiryDate.CheckedChanged += cbxContractExpiryDate_CheckedChanged;
                }
            }
        }

        private CheckBox _cbxAllVisitsComplete;

        internal CheckBox cbxAllVisitsComplete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxAllVisitsComplete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxAllVisitsComplete != null)
                {
                    _cbxAllVisitsComplete.CheckedChanged -= cbxAllVisitsComplete_CheckedChanged;
                }

                _cbxAllVisitsComplete = value;
                if (_cbxAllVisitsComplete != null)
                {
                    _cbxAllVisitsComplete.CheckedChanged += cbxAllVisitsComplete_CheckedChanged;
                }
            }
        }

        private Button _btnRenew;

        internal Button btnRenew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRenew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRenew != null)
                {
                    _btnRenew.Click -= btnRenew_Click;
                }

                _btnRenew = value;
                if (_btnRenew != null)
                {
                    _btnRenew.Click += btnRenew_Click;
                }
            }
        }

        private Button _btnPrintExpiryLetter;

        internal Button btnPrintExpiryLetter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintExpiryLetter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintExpiryLetter != null)
                {
                    _btnPrintExpiryLetter.Click -= btnPrintExpiryLetter_Click;
                }

                _btnPrintExpiryLetter = value;
                if (_btnPrintExpiryLetter != null)
                {
                    _btnPrintExpiryLetter.Click += btnPrintExpiryLetter_Click;
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

        private Button _btnActivate;

        internal Button btnActivate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnActivate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnActivate != null)
                {
                    _btnActivate.Click -= btnActivate_Click;
                }

                _btnActivate = value;
                if (_btnActivate != null)
                {
                    _btnActivate.Click += btnActivate_Click;
                }
            }
        }

        private Button _btnDeActive;

        internal Button btnDeActive
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeActive;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeActive != null)
                {
                    _btnDeActive.Click -= btnDeActive_Click;
                }

                _btnDeActive = value;
                if (_btnDeActive != null)
                {
                    _btnDeActive.Click += btnDeActive_Click;
                }
            }
        }

        private CheckBox _cbxCancelledDate;

        internal CheckBox cbxCancelledDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxCancelledDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxCancelledDate != null)
                {
                    _cbxCancelledDate.CheckedChanged -= cbxCancelledDate_CheckedChanged;
                }

                _cbxCancelledDate = value;
                if (_cbxCancelledDate != null)
                {
                    _cbxCancelledDate.CheckedChanged += cbxCancelledDate_CheckedChanged;
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

        private ComboBox _cboInvoiceFrequency;

        internal ComboBox cboInvoiceFrequency
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInvoiceFrequency;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInvoiceFrequency != null)
                {
                }

                _cboInvoiceFrequency = value;
                if (_cboInvoiceFrequency != null)
                {
                }
            }
        }

        private CheckBox _chxStartedBetween;

        internal CheckBox chxStartedBetween
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chxStartedBetween;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chxStartedBetween != null)
                {
                    _chxStartedBetween.CheckedChanged -= chxStartedBetween_CheckedChanged;
                }

                _chxStartedBetween = value;
                if (_chxStartedBetween != null)
                {
                    _chxStartedBetween.CheckedChanged += chxStartedBetween_CheckedChanged;
                }
            }
        }

        private Button _btnResetFilters;

        internal Button btnResetFilters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnResetFilters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnResetFilters != null)
                {
                }

                _btnResetFilters = value;
                if (_btnResetFilters != null)
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

        private ComboBox _CboRenewal;

        internal ComboBox CboRenewal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CboRenewal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CboRenewal != null)
                {
                }

                _CboRenewal = value;
                if (_CboRenewal != null)
                {
                }
            }
        }

        private CheckBox _cbxDoNotRenew;

        internal CheckBox cbxDoNotRenew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxDoNotRenew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxDoNotRenew != null)
                {
                }

                _cbxDoNotRenew = value;
                if (_cbxDoNotRenew != null)
                {
                }
            }
        }

        private ProgressBar _pbStatus;

        internal ProgressBar pbStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbStatus != null)
                {
                }

                _pbStatus = value;
                if (_pbStatus != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpFilter = new GroupBox();
            _cbxDoNotRenew = new CheckBox();
            _Label2 = new Label();
            _CboRenewal = new ComboBox();
            _Label13 = new Label();
            _cboRegion = new ComboBox();
            _btnResetFilters = new Button();
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _Label1 = new Label();
            _cboInvoiceFrequency = new ComboBox();
            _chxStartedBetween = new CheckBox();
            _chxStartedBetween.CheckedChanged += new EventHandler(chxStartedBetween_CheckedChanged);
            _cbxCancelledDate = new CheckBox();
            _cbxCancelledDate.CheckedChanged += new EventHandler(cbxCancelledDate_CheckedChanged);
            _cbxAllVisitsComplete = new CheckBox();
            _cbxAllVisitsComplete.CheckedChanged += new EventHandler(cbxAllVisitsComplete_CheckedChanged);
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _Label4 = new Label();
            _dtpTo = new DateTimePicker();
            _dtpFrom = new DateTimePicker();
            _txtContractReference = new TextBox();
            _Label9 = new Label();
            _cbxContractExpiryDate = new CheckBox();
            _cbxContractExpiryDate.CheckedChanged += new EventHandler(cbxContractExpiryDate_CheckedChanged);
            _Label6 = new Label();
            _cboType = new ComboBox();
            _Label11 = new Label();
            _cboStatus = new ComboBox();
            _Label10 = new Label();
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpContracts = new GroupBox();
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnDeselectAll = new Button();
            _btnDeselectAll.Click += new EventHandler(btnDeselectAll_Click);
            _dgContracts = new DataGrid();
            _dgContracts.DoubleClick += new EventHandler(dgContracts_DoubleClick);
            _dgContracts.MouseUp += new MouseEventHandler(dgContracts_MouseUp);
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _btnRenew = new Button();
            _btnRenew.Click += new EventHandler(btnRenew_Click);
            _btnPrintExpiryLetter = new Button();
            _btnPrintExpiryLetter.Click += new EventHandler(btnPrintExpiryLetter_Click);
            _pbStatus = new ProgressBar();
            _btnActivate = new Button();
            _btnActivate.Click += new EventHandler(btnActivate_Click);
            _btnDeActive = new Button();
            _btnDeActive.Click += new EventHandler(btnDeActive_Click);
            _grpFilter.SuspendLayout();
            _grpContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgContracts).BeginInit();
            SuspendLayout();
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_cbxDoNotRenew);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_CboRenewal);
            _grpFilter.Controls.Add(_Label13);
            _grpFilter.Controls.Add(_cboRegion);
            _grpFilter.Controls.Add(_btnResetFilters);
            _grpFilter.Controls.Add(_btnSearch);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_cboInvoiceFrequency);
            _grpFilter.Controls.Add(_chxStartedBetween);
            _grpFilter.Controls.Add(_cbxCancelledDate);
            _grpFilter.Controls.Add(_cbxAllVisitsComplete);
            _grpFilter.Controls.Add(_btnFindCustomer);
            _grpFilter.Controls.Add(_txtCustomer);
            _grpFilter.Controls.Add(_Label4);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_txtContractReference);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_cbxContractExpiryDate);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Controls.Add(_cboType);
            _grpFilter.Controls.Add(_Label11);
            _grpFilter.Controls.Add(_cboStatus);
            _grpFilter.Controls.Add(_Label10);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(882, 206);
            _grpFilter.TabIndex = 17;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // cbxDoNotRenew
            //
            _cbxDoNotRenew.BackColor = Color.White;
            _cbxDoNotRenew.Cursor = Cursors.Hand;
            _cbxDoNotRenew.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _cbxDoNotRenew.Location = new Point(104, 149);
            _cbxDoNotRenew.Name = "cbxDoNotRenew";
            _cbxDoNotRenew.Size = new Size(192, 24);
            _cbxDoNotRenew.TabIndex = 40;
            _cbxDoNotRenew.Text = "Also Show Do Not renew ";
            _cbxDoNotRenew.UseVisualStyleBackColor = false;
            //
            // Label2
            //
            _Label2.Location = new Point(532, 148);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(74, 16);
            _Label2.TabIndex = 39;
            _Label2.Text = "Renewed";
            //
            // CboRenewal
            //
            _CboRenewal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _CboRenewal.DropDownStyle = ComboBoxStyle.DropDownList;
            _CboRenewal.Location = new Point(659, 145);
            _CboRenewal.Name = "CboRenewal";
            _CboRenewal.Size = new Size(167, 21);
            _CboRenewal.TabIndex = 38;
            //
            // Label13
            //
            _Label13.Location = new Point(532, 121);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(49, 16);
            _Label13.TabIndex = 37;
            _Label13.Text = "Region";
            //
            // cboRegion
            //
            _cboRegion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegion.Location = new Point(659, 118);
            _cboRegion.Name = "cboRegion";
            _cboRegion.Size = new Size(167, 21);
            _cboRegion.TabIndex = 36;
            //
            // btnResetFilters
            //
            _btnResetFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnResetFilters.Location = new Point(651, 171);
            _btnResetFilters.Name = "btnResetFilters";
            _btnResetFilters.Size = new Size(96, 23);
            _btnResetFilters.TabIndex = 31;
            _btnResetFilters.Text = "Reset Filters";
            _btnResetFilters.UseVisualStyleBackColor = true;
            //
            // btnSearch
            //
            _btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSearch.Location = new Point(753, 171);
            _btnSearch.Name = "btnSearch";
            _btnSearch.Size = new Size(75, 23);
            _btnSearch.TabIndex = 30;
            _btnSearch.Text = "Search";
            _btnSearch.UseVisualStyleBackColor = true;
            //
            // Label1
            //
            _Label1.Location = new Point(532, 94);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(120, 19);
            _Label1.TabIndex = 29;
            _Label1.Text = "Invoice Frequency";
            //
            // cboInvoiceFrequency
            //
            _cboInvoiceFrequency.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboInvoiceFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInvoiceFrequency.Location = new Point(659, 91);
            _cboInvoiceFrequency.Name = "cboInvoiceFrequency";
            _cboInvoiceFrequency.Size = new Size(167, 21);
            _cboInvoiceFrequency.TabIndex = 28;
            //
            // chxStartedBetween
            //
            _chxStartedBetween.BackColor = Color.White;
            _chxStartedBetween.Cursor = Cursors.Hand;
            _chxStartedBetween.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _chxStartedBetween.Location = new Point(104, 86);
            _chxStartedBetween.Name = "chxStartedBetween";
            _chxStartedBetween.Size = new Size(192, 24);
            _chxStartedBetween.TabIndex = 27;
            _chxStartedBetween.Text = "Contract Started between";
            _chxStartedBetween.UseVisualStyleBackColor = false;
            //
            // cbxCancelledDate
            //
            _cbxCancelledDate.BackColor = Color.White;
            _cbxCancelledDate.Cursor = Cursors.Hand;
            _cbxCancelledDate.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _cbxCancelledDate.Location = new Point(104, 128);
            _cbxCancelledDate.Name = "cbxCancelledDate";
            _cbxCancelledDate.Size = new Size(192, 24);
            _cbxCancelledDate.TabIndex = 26;
            _cbxCancelledDate.Text = "Contract Cancelled between";
            _cbxCancelledDate.UseVisualStyleBackColor = false;
            //
            // cbxAllVisitsComplete
            //
            _cbxAllVisitsComplete.Location = new Point(104, 111);
            _cbxAllVisitsComplete.Name = "cbxAllVisitsComplete";
            _cbxAllVisitsComplete.Size = new Size(192, 16);
            _cbxAllVisitsComplete.TabIndex = 25;
            _cbxAllVisitsComplete.Text = "All Visits Complete";
            //
            // btnFindCustomer
            //
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(834, 16);
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
            _txtCustomer.Location = new Point(104, 16);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(722, 21);
            _txtCustomer.TabIndex = 1;
            //
            // Label4
            //
            _Label4.Location = new Point(8, 19);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(64, 16);
            _Label4.TabIndex = 24;
            _Label4.Text = "Customer";
            //
            // dtpTo
            //
            _dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dtpTo.Location = new Point(576, 64);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(250, 21);
            _dtpTo.TabIndex = 13;
            //
            // dtpFrom
            //
            _dtpFrom.Location = new Point(328, 64);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(184, 21);
            _dtpFrom.TabIndex = 12;
            //
            // txtContractReference
            //
            _txtContractReference.Location = new Point(104, 40);
            _txtContractReference.Name = "txtContractReference";
            _txtContractReference.Size = new Size(184, 21);
            _txtContractReference.TabIndex = 9;
            //
            // Label9
            //
            _Label9.Location = new Point(520, 64);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(48, 16);
            _Label9.TabIndex = 10;
            _Label9.Text = "And";
            //
            // cbxContractExpiryDate
            //
            _cbxContractExpiryDate.BackColor = Color.White;
            _cbxContractExpiryDate.Cursor = Cursors.Hand;
            _cbxContractExpiryDate.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _cbxContractExpiryDate.Location = new Point(104, 64);
            _cbxContractExpiryDate.Name = "cbxContractExpiryDate";
            _cbxContractExpiryDate.Size = new Size(176, 24);
            _cbxContractExpiryDate.TabIndex = 11;
            _cbxContractExpiryDate.Text = "Contract Expiries between";
            _cbxContractExpiryDate.UseVisualStyleBackColor = false;
            //
            // Label6
            //
            _Label6.Location = new Point(8, 40);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(88, 16);
            _Label6.TabIndex = 6;
            _Label6.Text = "Contract Ref.";
            //
            // cboType
            //
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(328, 40);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(184, 21);
            _cboType.TabIndex = 7;
            //
            // Label11
            //
            _Label11.Location = new Point(520, 40);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(48, 16);
            _Label11.TabIndex = 5;
            _Label11.Text = "Status";
            //
            // cboStatus
            //
            _cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.Location = new Point(576, 40);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(250, 21);
            _cboStatus.TabIndex = 8;
            //
            // Label10
            //
            _Label10.BackColor = Color.White;
            _Label10.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label10.Location = new Point(292, 40);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(48, 16);
            _Label10.TabIndex = 4;
            _Label10.Text = "Type";
            //
            // btnExport
            //
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 544);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 19;
            _btnExport.Text = "Export";
            //
            // grpContracts
            //
            _grpContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpContracts.Controls.Add(_btnSelectAll);
            _grpContracts.Controls.Add(_btnDeselectAll);
            _grpContracts.Controls.Add(_dgContracts);
            _grpContracts.Location = new Point(8, 244);
            _grpContracts.Name = "grpContracts";
            _grpContracts.Size = new Size(882, 294);
            _grpContracts.TabIndex = 18;
            _grpContracts.TabStop = false;
            _grpContracts.Text = "Double Click To View / Edit";
            //
            // btnSelectAll
            //
            _btnSelectAll.AccessibleDescription = "Export Job List To Excel";
            _btnSelectAll.Location = new Point(8, 13);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(88, 23);
            _btnSelectAll.TabIndex = 21;
            _btnSelectAll.Text = "Select All";
            //
            // btnDeselectAll
            //
            _btnDeselectAll.Location = new Point(104, 13);
            _btnDeselectAll.Name = "btnDeselectAll";
            _btnDeselectAll.Size = new Size(88, 23);
            _btnDeselectAll.TabIndex = 22;
            _btnDeselectAll.Text = "Deselect All";
            //
            // dgContracts
            //
            _dgContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgContracts.DataMember = "";
            _dgContracts.HeaderForeColor = SystemColors.ControlText;
            _dgContracts.Location = new Point(8, 42);
            _dgContracts.Name = "dgContracts";
            _dgContracts.Size = new Size(866, 244);
            _dgContracts.TabIndex = 14;
            //
            // btnReset
            //
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(72, 544);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 20;
            _btnReset.Text = "Reset";
            //
            // btnRenew
            //
            _btnRenew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRenew.Location = new Point(136, 544);
            _btnRenew.Name = "btnRenew";
            _btnRenew.Size = new Size(56, 23);
            _btnRenew.TabIndex = 21;
            _btnRenew.Text = "Renew";
            //
            // btnPrintExpiryLetter
            //
            _btnPrintExpiryLetter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrintExpiryLetter.Location = new Point(746, 544);
            _btnPrintExpiryLetter.Name = "btnPrintExpiryLetter";
            _btnPrintExpiryLetter.Size = new Size(136, 23);
            _btnPrintExpiryLetter.TabIndex = 22;
            _btnPrintExpiryLetter.Text = "Print Expiry Letters";
            //
            // pbStatus
            //
            _pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pbStatus.Location = new Point(373, 544);
            _pbStatus.Name = "pbStatus";
            _pbStatus.Size = new Size(365, 23);
            _pbStatus.TabIndex = 23;
            //
            // btnActivate
            //
            _btnActivate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnActivate.Location = new Point(198, 544);
            _btnActivate.Name = "btnActivate";
            _btnActivate.Size = new Size(74, 23);
            _btnActivate.TabIndex = 24;
            _btnActivate.Text = "Activate";
            //
            // btnDeActive
            //
            _btnDeActive.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnDeActive.Location = new Point(278, 544);
            _btnDeActive.Name = "btnDeActive";
            _btnDeActive.Size = new Size(89, 23);
            _btnDeActive.TabIndex = 25;
            _btnDeActive.Text = "Deactivate";
            //
            // FRMContractManager
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(898, 574);
            Controls.Add(_btnDeActive);
            Controls.Add(_btnActivate);
            Controls.Add(_pbStatus);
            Controls.Add(_btnPrintExpiryLetter);
            Controls.Add(_btnRenew);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpContracts);
            Controls.Add(_btnReset);
            MinimumSize = new Size(808, 528);
            Name = "FRMContractManager";
            Text = "Contract Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpContracts, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            Controls.SetChildIndex(_btnRenew, 0);
            Controls.SetChildIndex(_btnPrintExpiryLetter, 0);
            Controls.SetChildIndex(_pbStatus, 0);
            Controls.SetChildIndex(_btnActivate, 0);
            Controls.SetChildIndex(_btnDeActive, 0);
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            _grpContracts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgContracts).EndInit();
            ResumeLayout(false);
        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            Loading = true;
            LoadForm(sender, e, this);
            SetupContractsDataGrid();
            var argc = cboType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.ContractTypes).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            var argc1 = cboStatus;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            var argc2 = cboInvoiceFrequency;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.InvoiceFrequency, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            var argc3 = cboRegion;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            var argc4 = CboRenewal;
            Combo.SetUpCombo(ref argc4, DynamicDataTables.ContractRenewal, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            ResetFilters();
            // PopulateDatagrid()
            Loading = false;
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        public void ResetMe(int newID)
        {
        }

        
        
        private DataView _Contracts;

        private DataView Contracts
        {
            get
            {
                return _Contracts;
            }

            set
            {
                _Contracts = value;
                _Contracts.AllowNew = false;
                _Contracts.AllowEdit = false;
                _Contracts.AllowDelete = false;
                _Contracts.Table.TableName = Enums.TableNames.tblContract.ToString();
                dgContracts.DataSource = Contracts;
            }
        }

        private DataRow SelectedContractDataRow
        {
            get
            {
                if (!(dgContracts.CurrentRowIndex == -1))
                {
                    return Contracts[dgContracts.CurrentRowIndex].Row;
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

        private bool _Loading = true;

        public bool Loading
        {
            get
            {
                return _Loading;
            }

            set
            {
                _Loading = value;
            }
        }

        
        

        private void SetupContractsDataGrid()
        {
            var tbStyle = dgContracts.TableStyles[0];
            var tick = new DataGridBoolColumn();
            tick.HeaderText = "";
            tick.MappingName = "tick";
            tick.ReadOnly = true;
            tick.Width = 25;
            tick.NullText = "";
            tbStyle.GridColumnStyles.Add(tick);
            var madeContact = new DataGridBoolColumn();
            madeContact.HeaderText = "Contact Made";
            madeContact.MappingName = "ContactMade";
            madeContact.ReadOnly = true;
            madeContact.Width = 100;
            madeContact.NullText = "";
            tbStyle.GridColumnStyles.Add(madeContact);
            var PropertySite = new DataGridLabelColumn();
            PropertySite.Format = "";
            PropertySite.FormatInfo = null;
            PropertySite.HeaderText = "Property";
            PropertySite.MappingName = "Property";
            PropertySite.ReadOnly = true;
            PropertySite.Width = 150;
            PropertySite.NullText = "";
            tbStyle.GridColumnStyles.Add(PropertySite);
            var ContractReference = new DataGridLabelColumn();
            ContractReference.Format = "";
            ContractReference.FormatInfo = null;
            ContractReference.HeaderText = "Contract Reference";
            ContractReference.MappingName = "ContractReference";
            ContractReference.ReadOnly = true;
            ContractReference.Width = 120;
            ContractReference.NullText = "";
            tbStyle.GridColumnStyles.Add(ContractReference);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 100;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            var ContractStatus = new DataGridLabelColumn();
            ContractStatus.Format = "";
            ContractStatus.FormatInfo = null;
            ContractStatus.HeaderText = "Contract Status";
            ContractStatus.MappingName = "ContractStatus";
            ContractStatus.ReadOnly = true;
            ContractStatus.Width = 100;
            ContractStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(ContractStatus);
            var ContractStartDate = new DataGridLabelColumn();
            ContractStartDate.Format = "dd/MMM/yyyy";
            ContractStartDate.FormatInfo = null;
            ContractStartDate.HeaderText = "Start Date";
            ContractStartDate.MappingName = "ContractStartDate";
            ContractStartDate.ReadOnly = true;
            ContractStartDate.Width = 80;
            ContractStartDate.NullText = "";
            tbStyle.GridColumnStyles.Add(ContractStartDate);
            var ContractEndDate = new DataGridLabelColumn();
            ContractEndDate.Format = "dd/MMM/yyyy";
            ContractEndDate.FormatInfo = null;
            ContractEndDate.HeaderText = "End Date";
            ContractEndDate.MappingName = "ContractEndDate";
            ContractEndDate.ReadOnly = true;
            ContractEndDate.Width = 80;
            ContractEndDate.NullText = "";
            tbStyle.GridColumnStyles.Add(ContractEndDate);
            var ContractPrice = new DataGridLabelColumn();
            ContractPrice.Format = "C";
            ContractPrice.FormatInfo = null;
            ContractPrice.HeaderText = "Contract Price";
            ContractPrice.MappingName = "ContractPrice";
            ContractPrice.ReadOnly = true;
            ContractPrice.Width = 90;
            ContractPrice.NullText = "";
            tbStyle.GridColumnStyles.Add(ContractPrice);
            var Renewed = new DataGridContractColumn();
            Renewed.Format = "";
            Renewed.FormatInfo = null;
            Renewed.HeaderText = "Renewed";
            Renewed.MappingName = "Renewed";
            Renewed.ReadOnly = true;
            Renewed.Width = 100;
            Renewed.NullText = "";
            tbStyle.GridColumnStyles.Add(Renewed);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 150;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var CancelledDate = new DataGridLabelColumn();
            CancelledDate.HeaderText = "Cancelled Date";
            CancelledDate.MappingName = "CancelledDate";
            CancelledDate.ReadOnly = true;
            CancelledDate.Width = 100;
            CancelledDate.NullText = "n/a";
            tbStyle.GridColumnStyles.Add(CancelledDate);
            var CancelledReason = new DataGridLabelColumn();
            CancelledReason.Format = "";
            CancelledReason.FormatInfo = null;
            CancelledReason.HeaderText = "Cancelled Reason";
            CancelledReason.MappingName = "CancelledReason";
            CancelledReason.ReadOnly = true;
            CancelledReason.Width = 150;
            CancelledReason.NullText = "";
            tbStyle.GridColumnStyles.Add(CancelledReason);
            var GasSupplyPipework = new DataGridLabelColumn();
            GasSupplyPipework.Format = "";
            GasSupplyPipework.FormatInfo = null;
            GasSupplyPipework.HeaderText = "AHE";
            GasSupplyPipework.MappingName = "AHE"; // change for ahe
            GasSupplyPipework.ReadOnly = true;
            GasSupplyPipework.Width = 80;
            GasSupplyPipework.NullText = "";
            tbStyle.GridColumnStyles.Add(GasSupplyPipework);
            var InvoiceFrequency = new DataGridLabelColumn();
            InvoiceFrequency.Format = "";
            InvoiceFrequency.FormatInfo = null;
            InvoiceFrequency.HeaderText = "Invoice Frequency";
            InvoiceFrequency.MappingName = "InvoiceFrequency";
            InvoiceFrequency.ReadOnly = true;
            InvoiceFrequency.Width = 100;
            InvoiceFrequency.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceFrequency);
            var madeContactDate = new DataGridLabelColumn();
            madeContactDate.HeaderText = "Date Contact Made";
            madeContactDate.MappingName = "DateContactMade";
            madeContactDate.ReadOnly = true;
            madeContactDate.Width = 120;
            madeContactDate.NullText = "";
            tbStyle.GridColumnStyles.Add(madeContactDate);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Enums.TableNames.tblContract.ToString();
            dgContracts.TableStyles.Add(tbStyle);
        }

        private void FRMContractManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                theCustomer = App.DB.Customer.Customer_Get(ID);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void cbxContractExpiryDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxContractExpiryDate.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void cbxCancelledDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCancelledDate.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void chxStartedBetween_CheckedChanged(object sender, EventArgs e)
        {
            if (chxStartedBetween.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void cbxAllVisitsComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllVisitsComplete.Checked)
            {
                cbxContractExpiryDate.Checked = false;
                cbxCancelledDate.Checked = false;
                chxStartedBetween.Checked = false;
            }
        }

        private void dgContracts_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedContractDataRow is null)
            {
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedContractDataRow["ContractType"], Enums.QuoteType.Contract_Opt_1.ToString(), false)))
            {
                App.ShowForm(typeof(FRMContractOriginal), true, new object[] { Helper.MakeIntegerValid(SelectedContractDataRow["ContractID"]), SelectedContractDataRow["CustomerID"], 0, this });
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (SelectedContractDataRow is object)
            {
                if (Helper.MakeIntegerValid(SelectedContractDataRow["NewContractID"]) != 0)
                {
                    if (App.ShowMessage("This contract has already been renewed. Would you like to reprint the renewal document?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var switchExpr = Helper.MakeStringValid(SelectedContractDataRow["ContractType"]);
                        switch (switchExpr)
                        {
                            case var @case when @case == Enums.QuoteType.Contract_Opt_1.ToString():
                                {
                                    int newContractID = App.DB.ContractManager.ContractRenewals_GetNewID_ByOldID(Conversions.ToInteger(SelectedContractDataRow["ContractID"]), Conversions.ToInteger(Enums.QuoteType.Contract_Opt_1));
                                    var dtContracts = App.DB.ContractOriginal.ProcessContract(newContractID);
                                    if (dtContracts is null)
                                        return;
                                    var details = new ArrayList() { dtContracts };
                                    var oPrint = new Printing(details, "", Enums.SystemDocumentType.ContractOption1);
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    App.ShowForm(typeof(FRMContractRenewal), true, new object[] { SelectedContractDataRow["ContractType"], SelectedContractDataRow["ContractID"], this });
                }
            }
        }

        private void btnPrintExpiryLetter_Click(object sender, EventArgs e)
        {
            pbStatus.Value = 0;
            pbStatus.Maximum = ((DataView)dgContracts.DataSource).Count + ((DataView)dgContracts.DataSource).Count + 5;
            string ContractIDs = "";
            for (int itm = 0, loopTo = ((DataView)dgContracts.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgContracts.CurrentRowIndex = itm;
                ContractIDs += SelectedContractDataRow["ContractID"] + ",";
            }

            if (ContractIDs.Length > 0)
            {
                ContractIDs = ContractIDs.Substring(0, ContractIDs.Length - 1);
            }

            var dvAddresses = App.DB.ContractManager.Contracts_GetAddresses(ContractIDs);
            var printData = new DataTable();
            printData.Columns.Add("ContractID");
            printData.Columns.Add("ContractReference");
            printData.Columns.Add("Name");
            printData.Columns.Add("Address1");
            printData.Columns.Add("Address2");
            printData.Columns.Add("Address3");
            printData.Columns.Add("Address4");
            printData.Columns.Add("Address5");
            printData.Columns.Add("Postcode");
            printData.Columns.Add("ContractEndDate");
            printData.Columns.Add("Cheque");
            printData.Columns.Add("CreditCard");
            printData.Columns.Add("DirectDebit");
            printData.Columns.Add("ContractType");
            printData.Columns.Add("SiteAddress1");
            for (int itm = 0, loopTo1 = ((DataView)dgContracts.DataSource).Count - 1; itm <= loopTo1; itm++)
            {
                dgContracts.CurrentRowIndex = itm;
                DataRow newRw;
                newRw = printData.NewRow();
                newRw["ContractID"] = SelectedContractDataRow["ContractID"];
                newRw["ContractReference"] = SelectedContractDataRow["ContractReference"];
                newRw["ContractEndDate"] = SelectedContractDataRow["ContractEndDate"];
                newRw["Cheque"] = SelectedContractDataRow["Cheque"];
                newRw["CreditCard"] = SelectedContractDataRow["CreditCard"];
                newRw["DirectDebit"] = SelectedContractDataRow["DirectDebit"];
                newRw["ContractType"] = SelectedContractDataRow["Type"];
                newRw["SiteAddress1"] = SelectedContractDataRow["SiteAddress1"];
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedContractDataRow["CustomerID"], Enums.Customer.Domestic, false)))
                {
                    // GET SITE ADDRESS FOR DOMESTIC CUSTOMER
                    // drAdd = dvAddresses.Table.Select("Type='Site' AND ContractID=" & SelectedContractDataRow("ContractID"))
                    newRw["Name"] = Helper.MakeStringValid(SelectedContractDataRow["SiteName"]);
                    newRw["Address1"] = Helper.MakeStringValid(SelectedContractDataRow["SiteAddress1"]);
                    newRw["Address2"] = Helper.MakeStringValid(SelectedContractDataRow["SiteAddress2"]);
                    newRw["Address3"] = Helper.MakeStringValid(SelectedContractDataRow["SiteAddress3"]);
                    newRw["Address4"] = Helper.MakeStringValid(SelectedContractDataRow["SiteAddress4"]);
                    newRw["Address5"] = Helper.MakeStringValid(SelectedContractDataRow["SiteAddress5"]);
                    newRw["Postcode"] = Helper.MakeStringValid(SelectedContractDataRow["SitePostcode"]);
                }
                else  // ELSE CUSTOMER HQ
                {
                    DataRow[] drAdd;
                    drAdd = dvAddresses.Table.Select(Conversions.ToString("Type='HQ' AND ContractID=" + SelectedContractDataRow["ContractID"]));
                    if (drAdd.Length > 0)
                    {
                        newRw["Name"] = Helper.MakeStringValid(drAdd[0]["Name"]);
                        newRw["Address1"] = Helper.MakeStringValid(drAdd[0]["Address1"]);
                        newRw["Address2"] = Helper.MakeStringValid(drAdd[0]["Address2"]);
                        newRw["Address3"] = Helper.MakeStringValid(drAdd[0]["Address3"]);
                        newRw["Address4"] = Helper.MakeStringValid(drAdd[0]["Address4"]);
                        newRw["Address5"] = Helper.MakeStringValid(drAdd[0]["Address5"]);
                        newRw["Postcode"] = Helper.MakeStringValid(drAdd[0]["Postcode"]);
                    }
                    else
                    {
                        newRw["Name"] = "";
                        newRw["Address1"] = "";
                        newRw["Address2"] = "";
                        newRw["Address3"] = "";
                        newRw["Address4"] = "";
                        newRw["Address5"] = "";
                        newRw["Postcode"] = "";
                    }
                }

                printData.Rows.Add(newRw);
                dgContracts.UnSelect(itm);
                MoveProgressOn();
            }

            var details = new ArrayList();
            details.Add(printData);
            details.Add(this);
            var oPrint = new Printing(details, "Contract_Expiry_Letter", Enums.SystemDocumentType.ContractExpiry, true);
            for (int itm = 0, loopTo2 = ((DataView)dgContracts.DataSource).Count - 1; itm <= loopTo2; itm++)
            {
                dgContracts.CurrentRowIndex = itm;
                App.DB.ExecuteScalar("UPDATE tblContractOriginal SET Printed = 1 WHERE ContractID = " + Conversions.ToInteger(SelectedContractDataRow["ContractID"]));
            }

            MoveProgressOn(true);
        }

        private void dgContracts_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgContracts.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                if (HitTestInfo.Column == 0)
                {
                    bool selected = !Helper.MakeBooleanValid(SelectedContractDataRow["tick"]);
                    SelectedContractDataRow["Tick"] = selected;
                }

                if (HitTestInfo.Column == 1)
                {
                    bool contactMade = Helper.MakeBooleanValid(SelectedContractDataRow["ContactMade"]);
                    if (contactMade)
                        return;
                    var f = new FRMGenDropBox();
                    var contactMethod = App.DB.ContactAttempts.ContactMethod_GetAll().Table;
                    f.cbo2.Items.Clear();
                    var dt = new DataTable();
                    dt.Columns.Add(new DataColumn("ValueMember"));
                    dt.Columns.Add(new DataColumn("DisplayMember"));
                    dt.Columns.Add(new DataColumn("Deleted"));
                    foreach (DataRow dr in contactMethod.Rows)
                        dt.Rows.Add(new string[] { dr["ContactMethodID"].ToString(), dr["Name"].ToString(), "0" });
                    var argc = f.cbo2;
                    Combo.SetUpCombo(ref argc, dt, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
                    f.cbo1.Visible = false;
                    f.cbo2.Visible = true;
                    f.lblTop.Text = "Please select method of contact";
                    f.lblMiddle.Text = "";
                    f.lblref.Text = "";
                    f.txtref.Visible = false;
                    f.ShowDialog();
                    if (f.DialogResult == DialogResult.Cancel)
                    {
                        return;
                    }

                    var contactAttempt = new ContactAttempt();
                    {
                        var withBlock = contactAttempt;
                        withBlock.ContactMethedID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(f.cbo2));
                        withBlock.LinkID = Conversions.ToInteger(Enums.TableNames.tblContract);
                        withBlock.LinkRef = Helper.MakeIntegerValid(SelectedContractDataRow["ContractID"]);
                        withBlock.ContactMade = DateAndTime.Now;
                        withBlock.Notes = "";
                        withBlock.ContactMadeByUserId = App.loggedInUser.UserID;
                    }

                    contactAttempt = App.DB.ContactAttempts.Insert(contactAttempt);
                    if (contactAttempt.ContactAttemptID > 0)
                    {
                        SelectedContractDataRow["ContactMade"] = true;
                        SelectedContractDataRow["DateContactMade"] = DateAndTime.Now;
                    }
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (Contracts is object && Contracts.Count > 0)
            {
                foreach (DataRow dr in Contracts.Table.Rows)
                    dr["tick"] = 1;
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            if (Contracts is object && Contracts.Count > 0)
            {
                foreach (DataRow dr in Contracts.Table.Rows)
                    dr["tick"] = 0;
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            var oContracts = new List<int>();
            if (App.ShowMessage("This will set the status of the selected contracts to active. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataRowView dr in Contracts)
                {
                    if (Helper.MakeBooleanValid(dr["tick"]) == true)
                    {
                        Entity.ContractsOriginal.ContractOriginal CurrentContract;
                        CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(dr["ContractID"]));
                        DataView Sites;
                        Sites = App.DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, CurrentContract.CustomerID);
                        if (CurrentContract is object)
                        {
                            // IF UPDATING
                            if (CurrentContract.Exists == true)
                            {
                                // REACTIVE ANY SITE JOBS PREVIOUSLY DEACTIVATED
                                foreach (DataRow site in Sites.Table.Rows)
                                {
                                    if (Conversions.ToBoolean((int)site["ContractSiteID"] > 0))
                                    {
                                        App.DB.ContractOriginalSite.ActiveInactive(Conversions.ToInteger(site["ContractSiteID"]), false);
                                    }
                                }

                                oContracts.Add(Helper.MakeIntegerValid(dr["ContractID"]));
                            }
                        }

                        CurrentContract.SetContractStatusID = Conversions.ToInteger(Enums.ContractStatus.Active);
                        App.DB.ContractOriginal.Update(CurrentContract);
                    }
                }

                if (oContracts.Count > 0)
                {
                    var oPrint = new Printing(oContracts, "Certificates", Enums.SystemDocumentType.ContractOption1, true);
                }

                PopulateDatagrid();
            }
        }

        private void btnDeActive_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage("This will set the status of the selected contracts to inactive. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataRowView dr in Contracts)
                {
                    if (Helper.MakeBooleanValid(dr["tick"]) == true)
                    {
                        Entity.ContractsOriginal.ContractOriginal CurrentContract;
                        CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(dr["ContractID"]));
                        DataView Sites;
                        Sites = App.DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, CurrentContract.CustomerID);
                        if (CurrentContract is object)
                        {
                            // IF UPDATING
                            if (CurrentContract.Exists == true)
                            {
                                // REACTIVE ANY SITE JOBS PREVIOUSLY DEACTIVATED
                                foreach (DataRow site in Sites.Table.Rows)
                                {
                                    if (Conversions.ToBoolean((int)site["ContractSiteID"] > 0))
                                    {
                                        App.DB.ContractOriginalSite.ActiveInactive(Conversions.ToInteger(site["ContractSiteID"]), true);
                                    }
                                }
                            }
                        }

                        CurrentContract.SetContractStatusID = Conversions.ToInteger(Enums.ContractStatus.Inactive);
                        CurrentContract.CancelledDate = DateAndTime.Now;
                        App.DB.ContractOriginal.Update(CurrentContract);
                    }
                }

                PopulateDatagrid();
            }
        }

        
        

        public void PopulateDatagrid()
        {
            try
            {
                if (get_GetParameter(0) is null)
                {
                    DateTime DateFrom = Conversions.ToDate("1900-01-01");
                    if (cbxAllVisitsComplete.Checked == false)
                    {
                        if (dtpFrom.Value != default)
                        {
                            DateFrom = dtpFrom.Value;
                        }
                    }

                    Contracts = App.DB.ContractManager.Contracts_GetAll(DateFrom);
                    RunFilter();
                    grpContracts.Text = "(" + Contracts.Count + " records)" + " Double Click To View / Edit";
                }
                else
                {
                    Contracts = (DataView)get_GetParameter(0);
                    grpFilter.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            theCustomer = null;
            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            txtContractReference.Text = "";
            cbxContractExpiryDate.Checked = true;
            dtpFrom.Value = DateAndTime.Today;
            dtpTo.Value = DateAndTime.Today.AddMonths(1);
            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;
            grpFilter.Enabled = true;
            cbxAllVisitsComplete.Checked = false;
            cbxCancelledDate.Checked = false;
        }

        private void RunFilter()
        {
            if (Contracts is object)
            {
                string whereClause = "Deleted = 0 ";
                if (theCustomer is object)
                {
                    whereClause += " AND CustomerID = " + theCustomer.CustomerID + "";
                }

                if (!(txtContractReference.Text.Trim().Length == 0))
                {
                    whereClause += " AND ContractReference LIKE '" + txtContractReference.Text.Trim() + "%'";
                }

                if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboType)) == 0))
                {
                    whereClause += " AND ContractTypeID = " + Combo.get_GetSelectedItemValue(cboType);
                }

                if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboRegion)) == 0))
                {
                    whereClause += " AND RegionID = " + Combo.get_GetSelectedItemValue(cboRegion);
                }

                if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == 0))
                {
                    whereClause += " AND ContractStatusID = " + Combo.get_GetSelectedItemValue(cboStatus) + "";
                }

                if (cbxDoNotRenew.Checked == false)
                {
                    whereClause += " AND DoNotRenew = 0";
                }

                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(CboRenewal)) == 0)
                {
                }
                else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(CboRenewal)) == 3)
                {
                    whereClause += " AND Renewed = 'Renewed'";
                }
                else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(CboRenewal)) == 4)
                {
                    whereClause += " AND Renewed = 'Not Renewed'";
                }

                if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboInvoiceFrequency)) == 0))
                {
                    whereClause += " AND InvoiceFrequencyID = " + Combo.get_GetSelectedItemValue(cboInvoiceFrequency) + "";
                }

                if (cbxContractExpiryDate.Checked)
                {
                    whereClause += " AND ContractEndDate >= '" + Strings.Format(dtpFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND ContractEndDate <= '" + Strings.Format(dtpTo.Value, "dd/MM/yyyy 23:59:59") + "'";
                }

                if (chxStartedBetween.Checked)
                {
                    whereClause += " AND ContractStartDate >= '" + Strings.Format(dtpFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND ContractStartDate <= '" + Strings.Format(dtpTo.Value, "dd/MM/yyyy 23:59:59") + "'";
                }

                if (cbxCancelledDate.Checked)
                {
                    whereClause += " AND CancelledDate >= '" + Strings.Format(dtpFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND CancelledDate <= '" + Strings.Format(dtpTo.Value, "dd/MM/yyyy 23:59:59") + "'";
                }

                if (cbxAllVisitsComplete.Checked)
                {
                    whereClause += " AND VisitsNotUploaded= 0";
                }

                Contracts.RowFilter = whereClause;
            }
        }

        public void Export()
        {
            var exportData = new DataTable();
            exportData.Columns.Add("Property");
            exportData.Columns.Add("SitePostcode");
            exportData.Columns.Add("ContractReference");
            exportData.Columns.Add("ContractType");
            exportData.Columns.Add("ContractStatus");
            exportData.Columns.Add("ContractStartDate", typeof(DateTime));
            exportData.Columns.Add("ContractEndDate", typeof(DateTime));
            exportData.Columns.Add("ContractPrice", typeof(double));
            exportData.Columns.Add("VisitsNotUploaded");
            exportData.Columns.Add("Renewed");
            exportData.Columns.Add("Customer");
            exportData.Columns.Add("SiteEmail");
            exportData.Columns.Add("CancelledDate", typeof(DateTime));
            exportData.Columns.Add("CancelledReason");
            exportData.Columns.Add("InvoiceFrequencyID");
            exportData.Columns.Add("GasSupplyPipework");
            exportData.Columns.Add("PlumbingDrainage");
            exportData.Columns.Add("WindowLockPest");
            exportData.Columns.Add("NoOfAppliancesCovered");
            exportData.Columns.Add("NoOfPrimaryAppliancesCovered");
            exportData.Columns.Add("NoOfAdditionalAppliancesCovered");
            exportData.Columns.Add("InvoiceFrequency");
            exportData.Columns.Add("CustomerType");
            exportData.Columns.Add("NoMarketing");
            foreach (DataRowView dr in (DataView)dgContracts.DataSource)
            {
                var newRw = exportData.NewRow();
                newRw["Customer"] = dr["Customer"];
                newRw["ContractReference"] = dr["ContractReference"];
                newRw["ContractType"] = dr["ContractType"];
                newRw["ContractStatus"] = dr["ContractStatus"];
                newRw["ContractStartDate"] = dr["ContractStartDate"];
                newRw["ContractEndDate"] = dr["ContractEndDate"];
                newRw["ContractPrice"] = dr["ContractPrice"];
                newRw["VisitsNotUploaded"] = dr["VisitsNotUploaded"];
                newRw["Renewed"] = dr["Renewed"];
                newRw["Property"] = dr["Property"];
                newRw["SitePostcode"] = dr["SitePostcode"];
                newRw["SiteEmail"] = dr["SiteEmail"];
                newRw["CancelledDate"] = dr["CancelledDate"];
                newRw["CancelledReason"] = dr["CancelledReason"];
                newRw["InvoiceFrequencyID"] = dr["InvoiceFrequencyID"];
                newRw["GasSupplyPipework"] = dr["GasSupplyPipework"];
                newRw["PlumbingDrainage"] = dr["PlumbingDrainage"];
                newRw["WindowLockPest"] = dr["WindowLockPest"];
                newRw["NoOfAppliancesCovered"] = dr["NoOfAppliancesCovered"];
                newRw["NoOfPrimaryAppliancesCovered"] = dr["NoOfPrimaryAppliancesCovered"];
                newRw["NoOfAdditionalAppliancesCovered"] = dr["NoOfAdditionalAppliancesCovered"];
                newRw["InvoiceFrequency"] = dr["InvoiceFrequency"];
                newRw["CustomerType"] = dr["NoOfContracts"];
                newRw["NoMarketing"] = dr["SiteNoMarketing"];
                exportData.Rows.Add(newRw);
            }

            ExportHelper.Export(exportData, "Contracts List", Enums.ExportType.XLS);
        }

        public void MoveProgressOn(bool toMaximum = false)
        {
            if (toMaximum)
            {
                pbStatus.Value = pbStatus.Maximum;
            }
            else
            {
                pbStatus.Value += 1;
            }

            Application.DoEvents();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PopulateDatagrid();
            Cursor.Current = Cursors.Default;
        }

        
    }
}