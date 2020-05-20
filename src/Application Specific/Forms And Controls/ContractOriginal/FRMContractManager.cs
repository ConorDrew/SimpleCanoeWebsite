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

        private Button _btnPrintExpiryLetter;

        private Button _btnSelectAll;

        private Button _btnDeselectAll;

        private Button _btnActivate;

        private Button _btnDeActive;

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

        private Button _btnSearch;

        private Label _Label13;

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
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._cbxDoNotRenew = new System.Windows.Forms.CheckBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._CboRenewal = new System.Windows.Forms.ComboBox();
            this._Label13 = new System.Windows.Forms.Label();
            this._cboRegion = new System.Windows.Forms.ComboBox();
            this._btnResetFilters = new System.Windows.Forms.Button();
            this._btnSearch = new System.Windows.Forms.Button();
            this._Label1 = new System.Windows.Forms.Label();
            this._cboInvoiceFrequency = new System.Windows.Forms.ComboBox();
            this._chxStartedBetween = new System.Windows.Forms.CheckBox();
            this._cbxCancelledDate = new System.Windows.Forms.CheckBox();
            this._cbxAllVisitsComplete = new System.Windows.Forms.CheckBox();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._txtContractReference = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._cbxContractExpiryDate = new System.Windows.Forms.CheckBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._Label11 = new System.Windows.Forms.Label();
            this._cboStatus = new System.Windows.Forms.ComboBox();
            this._Label10 = new System.Windows.Forms.Label();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpContracts = new System.Windows.Forms.GroupBox();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnDeselectAll = new System.Windows.Forms.Button();
            this._dgContracts = new System.Windows.Forms.DataGrid();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnRenew = new System.Windows.Forms.Button();
            this._btnPrintExpiryLetter = new System.Windows.Forms.Button();
            this._pbStatus = new System.Windows.Forms.ProgressBar();
            this._btnActivate = new System.Windows.Forms.Button();
            this._btnDeActive = new System.Windows.Forms.Button();
            this._grpFilter.SuspendLayout();
            this._grpContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._cbxDoNotRenew);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._CboRenewal);
            this._grpFilter.Controls.Add(this._Label13);
            this._grpFilter.Controls.Add(this._cboRegion);
            this._grpFilter.Controls.Add(this._btnResetFilters);
            this._grpFilter.Controls.Add(this._btnSearch);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._cboInvoiceFrequency);
            this._grpFilter.Controls.Add(this._chxStartedBetween);
            this._grpFilter.Controls.Add(this._cbxCancelledDate);
            this._grpFilter.Controls.Add(this._cbxAllVisitsComplete);
            this._grpFilter.Controls.Add(this._btnFindCustomer);
            this._grpFilter.Controls.Add(this._txtCustomer);
            this._grpFilter.Controls.Add(this._Label4);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._txtContractReference);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._cbxContractExpiryDate);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Controls.Add(this._cboType);
            this._grpFilter.Controls.Add(this._Label11);
            this._grpFilter.Controls.Add(this._cboStatus);
            this._grpFilter.Controls.Add(this._Label10);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(882, 209);
            this._grpFilter.TabIndex = 17;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _cbxDoNotRenew
            // 
            this._cbxDoNotRenew.BackColor = System.Drawing.Color.White;
            this._cbxDoNotRenew.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxDoNotRenew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbxDoNotRenew.Location = new System.Drawing.Point(104, 149);
            this._cbxDoNotRenew.Name = "_cbxDoNotRenew";
            this._cbxDoNotRenew.Size = new System.Drawing.Size(192, 24);
            this._cbxDoNotRenew.TabIndex = 40;
            this._cbxDoNotRenew.Text = "Also Show Do Not renew ";
            this._cbxDoNotRenew.UseVisualStyleBackColor = false;
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(532, 148);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(74, 16);
            this._Label2.TabIndex = 39;
            this._Label2.Text = "Renewed";
            // 
            // _CboRenewal
            // 
            this._CboRenewal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._CboRenewal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._CboRenewal.Location = new System.Drawing.Point(659, 145);
            this._CboRenewal.Name = "_CboRenewal";
            this._CboRenewal.Size = new System.Drawing.Size(167, 21);
            this._CboRenewal.TabIndex = 38;
            // 
            // _Label13
            // 
            this._Label13.Location = new System.Drawing.Point(532, 121);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(49, 16);
            this._Label13.TabIndex = 37;
            this._Label13.Text = "Region";
            // 
            // _cboRegion
            // 
            this._cboRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboRegion.Location = new System.Drawing.Point(659, 118);
            this._cboRegion.Name = "_cboRegion";
            this._cboRegion.Size = new System.Drawing.Size(167, 21);
            this._cboRegion.TabIndex = 36;
            // 
            // _btnResetFilters
            // 
            this._btnResetFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnResetFilters.Location = new System.Drawing.Point(651, 174);
            this._btnResetFilters.Name = "_btnResetFilters";
            this._btnResetFilters.Size = new System.Drawing.Size(96, 23);
            this._btnResetFilters.TabIndex = 31;
            this._btnResetFilters.Text = "Reset Filters";
            this._btnResetFilters.UseVisualStyleBackColor = true;
            // 
            // _btnSearch
            // 
            this._btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSearch.Location = new System.Drawing.Point(753, 174);
            this._btnSearch.Name = "_btnSearch";
            this._btnSearch.Size = new System.Drawing.Size(75, 23);
            this._btnSearch.TabIndex = 30;
            this._btnSearch.Text = "Search";
            this._btnSearch.UseVisualStyleBackColor = true;
            this._btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(532, 94);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(120, 19);
            this._Label1.TabIndex = 29;
            this._Label1.Text = "Invoice Frequency";
            // 
            // _cboInvoiceFrequency
            // 
            this._cboInvoiceFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboInvoiceFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboInvoiceFrequency.Location = new System.Drawing.Point(659, 91);
            this._cboInvoiceFrequency.Name = "_cboInvoiceFrequency";
            this._cboInvoiceFrequency.Size = new System.Drawing.Size(167, 21);
            this._cboInvoiceFrequency.TabIndex = 28;
            // 
            // _chxStartedBetween
            // 
            this._chxStartedBetween.BackColor = System.Drawing.Color.White;
            this._chxStartedBetween.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chxStartedBetween.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chxStartedBetween.Location = new System.Drawing.Point(104, 86);
            this._chxStartedBetween.Name = "_chxStartedBetween";
            this._chxStartedBetween.Size = new System.Drawing.Size(192, 24);
            this._chxStartedBetween.TabIndex = 27;
            this._chxStartedBetween.Text = "Contract Started between";
            this._chxStartedBetween.UseVisualStyleBackColor = false;
            this._chxStartedBetween.CheckedChanged += new System.EventHandler(this.chxStartedBetween_CheckedChanged);
            // 
            // _cbxCancelledDate
            // 
            this._cbxCancelledDate.BackColor = System.Drawing.Color.White;
            this._cbxCancelledDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxCancelledDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbxCancelledDate.Location = new System.Drawing.Point(104, 128);
            this._cbxCancelledDate.Name = "_cbxCancelledDate";
            this._cbxCancelledDate.Size = new System.Drawing.Size(192, 24);
            this._cbxCancelledDate.TabIndex = 26;
            this._cbxCancelledDate.Text = "Contract Cancelled between";
            this._cbxCancelledDate.UseVisualStyleBackColor = false;
            this._cbxCancelledDate.CheckedChanged += new System.EventHandler(this.cbxCancelledDate_CheckedChanged);
            // 
            // _cbxAllVisitsComplete
            // 
            this._cbxAllVisitsComplete.Location = new System.Drawing.Point(104, 111);
            this._cbxAllVisitsComplete.Name = "_cbxAllVisitsComplete";
            this._cbxAllVisitsComplete.Size = new System.Drawing.Size(192, 16);
            this._cbxAllVisitsComplete.TabIndex = 25;
            this._cbxAllVisitsComplete.Text = "All Visits Complete";
            this._cbxAllVisitsComplete.CheckedChanged += new System.EventHandler(this.cbxAllVisitsComplete_CheckedChanged);
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(834, 16);
            this._btnFindCustomer.Name = "_btnFindCustomer";
            this._btnFindCustomer.Size = new System.Drawing.Size(32, 23);
            this._btnFindCustomer.TabIndex = 2;
            this._btnFindCustomer.Text = "...";
            this._btnFindCustomer.UseVisualStyleBackColor = false;
            this._btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCustomer.Location = new System.Drawing.Point(104, 16);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(722, 21);
            this._txtCustomer.TabIndex = 1;
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(8, 19);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(64, 16);
            this._Label4.TabIndex = 24;
            this._Label4.Text = "Customer";
            // 
            // _dtpTo
            // 
            this._dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpTo.Location = new System.Drawing.Point(576, 64);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(250, 21);
            this._dtpTo.TabIndex = 13;
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Location = new System.Drawing.Point(328, 64);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(184, 21);
            this._dtpFrom.TabIndex = 12;
            // 
            // _txtContractReference
            // 
            this._txtContractReference.Location = new System.Drawing.Point(104, 40);
            this._txtContractReference.Name = "_txtContractReference";
            this._txtContractReference.Size = new System.Drawing.Size(184, 21);
            this._txtContractReference.TabIndex = 9;
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(520, 64);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(48, 16);
            this._Label9.TabIndex = 10;
            this._Label9.Text = "And";
            // 
            // _cbxContractExpiryDate
            // 
            this._cbxContractExpiryDate.BackColor = System.Drawing.Color.White;
            this._cbxContractExpiryDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cbxContractExpiryDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbxContractExpiryDate.Location = new System.Drawing.Point(104, 64);
            this._cbxContractExpiryDate.Name = "_cbxContractExpiryDate";
            this._cbxContractExpiryDate.Size = new System.Drawing.Size(176, 24);
            this._cbxContractExpiryDate.TabIndex = 11;
            this._cbxContractExpiryDate.Text = "Contract Expiries between";
            this._cbxContractExpiryDate.UseVisualStyleBackColor = false;
            this._cbxContractExpiryDate.CheckedChanged += new System.EventHandler(this.cbxContractExpiryDate_CheckedChanged);
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(8, 40);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(88, 16);
            this._Label6.TabIndex = 6;
            this._Label6.Text = "Contract Ref.";
            // 
            // _cboType
            // 
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(328, 40);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(184, 21);
            this._cboType.TabIndex = 7;
            // 
            // _Label11
            // 
            this._Label11.Location = new System.Drawing.Point(520, 40);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(48, 16);
            this._Label11.TabIndex = 5;
            this._Label11.Text = "Status";
            // 
            // _cboStatus
            // 
            this._cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStatus.Location = new System.Drawing.Point(576, 40);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(250, 21);
            this._cboStatus.TabIndex = 8;
            // 
            // _Label10
            // 
            this._Label10.BackColor = System.Drawing.Color.White;
            this._Label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label10.Location = new System.Drawing.Point(292, 40);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(48, 16);
            this._Label10.TabIndex = 4;
            this._Label10.Text = "Type";
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 544);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 19;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _grpContracts
            // 
            this._grpContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpContracts.Controls.Add(this._btnSelectAll);
            this._grpContracts.Controls.Add(this._btnDeselectAll);
            this._grpContracts.Controls.Add(this._dgContracts);
            this._grpContracts.Location = new System.Drawing.Point(8, 227);
            this._grpContracts.Name = "_grpContracts";
            this._grpContracts.Size = new System.Drawing.Size(882, 311);
            this._grpContracts.TabIndex = 18;
            this._grpContracts.TabStop = false;
            this._grpContracts.Text = "Double Click To View / Edit";
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.AccessibleDescription = "Export Job List To Excel";
            this._btnSelectAll.Location = new System.Drawing.Point(8, 13);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(88, 23);
            this._btnSelectAll.TabIndex = 21;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnDeselectAll
            // 
            this._btnDeselectAll.Location = new System.Drawing.Point(104, 13);
            this._btnDeselectAll.Name = "_btnDeselectAll";
            this._btnDeselectAll.Size = new System.Drawing.Size(88, 23);
            this._btnDeselectAll.TabIndex = 22;
            this._btnDeselectAll.Text = "Deselect All";
            this._btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // _dgContracts
            // 
            this._dgContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgContracts.DataMember = "";
            this._dgContracts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgContracts.Location = new System.Drawing.Point(8, 42);
            this._dgContracts.Name = "_dgContracts";
            this._dgContracts.Size = new System.Drawing.Size(866, 261);
            this._dgContracts.TabIndex = 14;
            this._dgContracts.DoubleClick += new System.EventHandler(this.dgContracts_DoubleClick);
            this._dgContracts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgContracts_MouseUp);
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(72, 544);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 20;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _btnRenew
            // 
            this._btnRenew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnRenew.Location = new System.Drawing.Point(136, 544);
            this._btnRenew.Name = "_btnRenew";
            this._btnRenew.Size = new System.Drawing.Size(56, 23);
            this._btnRenew.TabIndex = 21;
            this._btnRenew.Text = "Renew";
            this._btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // _btnPrintExpiryLetter
            // 
            this._btnPrintExpiryLetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPrintExpiryLetter.Location = new System.Drawing.Point(746, 544);
            this._btnPrintExpiryLetter.Name = "_btnPrintExpiryLetter";
            this._btnPrintExpiryLetter.Size = new System.Drawing.Size(136, 23);
            this._btnPrintExpiryLetter.TabIndex = 22;
            this._btnPrintExpiryLetter.Text = "Print Expiry Letters";
            this._btnPrintExpiryLetter.Click += new System.EventHandler(this.btnPrintExpiryLetter_Click);
            // 
            // _pbStatus
            // 
            this._pbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pbStatus.Location = new System.Drawing.Point(373, 544);
            this._pbStatus.Name = "_pbStatus";
            this._pbStatus.Size = new System.Drawing.Size(365, 23);
            this._pbStatus.TabIndex = 23;
            // 
            // _btnActivate
            // 
            this._btnActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnActivate.Location = new System.Drawing.Point(198, 544);
            this._btnActivate.Name = "_btnActivate";
            this._btnActivate.Size = new System.Drawing.Size(74, 23);
            this._btnActivate.TabIndex = 24;
            this._btnActivate.Text = "Activate";
            this._btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // _btnDeActive
            // 
            this._btnDeActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnDeActive.Location = new System.Drawing.Point(278, 544);
            this._btnDeActive.Name = "_btnDeActive";
            this._btnDeActive.Size = new System.Drawing.Size(89, 23);
            this._btnDeActive.TabIndex = 25;
            this._btnDeActive.Text = "Deactivate";
            this._btnDeActive.Click += new System.EventHandler(this.btnDeActive_Click);
            // 
            // FRMContractManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(898, 574);
            this.Controls.Add(this._btnDeActive);
            this.Controls.Add(this._btnActivate);
            this.Controls.Add(this._pbStatus);
            this.Controls.Add(this._btnPrintExpiryLetter);
            this.Controls.Add(this._btnRenew);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpContracts);
            this.Controls.Add(this._btnReset);
            this.MinimumSize = new System.Drawing.Size(808, 528);
            this.Name = "FRMContractManager";
            this.Text = "Contract Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this._grpContracts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgContracts)).EndInit();
            this.ResumeLayout(false);

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