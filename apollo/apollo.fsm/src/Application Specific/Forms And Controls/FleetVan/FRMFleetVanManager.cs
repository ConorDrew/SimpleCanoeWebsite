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
    public class FRMFleetVanManager : FRMBaseForm
    {
        public FRMFleetVanManager() : base()
        {
            this.Load += FRMImport_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboFaultType;
            Combo.SetUpCombo(ref argc, App.DB.FleetVanFault.FaultTypes_GetAll().Table, "VanFaultTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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
        private GroupBox _grpFaultsFilter;

        private GroupBox _grpFaultDG;

        internal GroupBox grpFaultDG
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFaultDG;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFaultDG != null)
                {
                }

                _grpFaultDG = value;
                if (_grpFaultDG != null)
                {
                }
            }
        }

        private DataGrid _dgFaults;

        internal DataGrid dgFaults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgFaults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgFaults != null)
                {
                    _dgFaults.DoubleClick -= dgFaults_DoubleClick;
                }

                _dgFaults = value;
                if (_dgFaults != null)
                {
                    _dgFaults.DoubleClick += dgFaults_DoubleClick;
                }
            }
        }

        private GroupBox _grpEngineerFilter;

        private GroupBox _grpEngineerHistory;

        internal GroupBox grpEngineerHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineerHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineerHistory != null)
                {
                }

                _grpEngineerHistory = value;
                if (_grpEngineerHistory != null)
                {
                }
            }
        }

        private GroupBox _grpFilter;

        private Label _lblRegistration;

        private Button _btnfindVan;

        private TextBox _txtVanReg;

        internal TextBox txtVanReg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVanReg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVanReg != null)
                {
                }

                _txtVanReg = value;
                if (_txtVanReg != null)
                {
                }
            }
        }

        private ComboBox _cboFaultType;

        internal ComboBox cboFaultType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFaultType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFaultType != null)
                {
                }

                _cboFaultType = value;
                if (_cboFaultType != null)
                {
                }
            }
        }

        private Label _lblFaultType;

        private DateTimePicker _dtpResolvedTo;

        internal DateTimePicker dtpResolvedTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpResolvedTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpResolvedTo != null)
                {
                }

                _dtpResolvedTo = value;
                if (_dtpResolvedTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpResolvedFrom;

        internal DateTimePicker dtpResolvedFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpResolvedFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpResolvedFrom != null)
                {
                }

                _dtpResolvedFrom = value;
                if (_dtpResolvedFrom != null)
                {
                }
            }
        }

        private Label _lblResolvedTo;

        private Label _lblResolvedFrom;

        private CheckBox _chkResolved;

        internal CheckBox chkResolved
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkResolved;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkResolved != null)
                {
                }

                _chkResolved = value;
                if (_chkResolved != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFaultTo;

        internal DateTimePicker dtpFaultTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFaultTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFaultTo != null)
                {
                }

                _dtpFaultTo = value;
                if (_dtpFaultTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFaultFrom;

        internal DateTimePicker dtpFaultFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFaultFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFaultFrom != null)
                {
                }

                _dtpFaultFrom = value;
                if (_dtpFaultFrom != null)
                {
                }
            }
        }

        private Label _lblFaultTo;

        private Label _lblFaultFrom;

        private CheckBox _chkFaultDate;

        internal CheckBox chkFaultDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkFaultDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkFaultDate != null)
                {
                }

                _chkFaultDate = value;
                if (_chkFaultDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpEngineerTo;

        internal DateTimePicker dtpEngineerTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpEngineerTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpEngineerTo != null)
                {
                }

                _dtpEngineerTo = value;
                if (_dtpEngineerTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpEngineerFrom;

        internal DateTimePicker dtpEngineerFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpEngineerFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpEngineerFrom != null)
                {
                }

                _dtpEngineerFrom = value;
                if (_dtpEngineerFrom != null)
                {
                }
            }
        }

        private Label _lblEngineerTo;

        internal Label lblEngineerTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngineerTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngineerTo != null)
                {
                }

                _lblEngineerTo = value;
                if (_lblEngineerTo != null)
                {
                }
            }
        }

        private Label _lblEngineerFrom;

        private Button _btnSearchFault;

        private Button _btnSearchEngineer;

        private Button _btnfindEngineer;

        private TextBox _txtEngineer;

        internal TextBox txtEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineer != null)
                {
                }

                _txtEngineer = value;
                if (_txtEngineer != null)
                {
                }
            }
        }

        private Label _lblEngineer;

        internal Label lblEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngineer != null)
                {
                }

                _lblEngineer = value;
                if (_lblEngineer != null)
                {
                }
            }
        }

        private Button _btnClear;

        internal Button btnClear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClear != null)
                {
                    _btnClear.Click -= btnClear_Click;
                }

                _btnClear = value;
                if (_btnClear != null)
                {
                    _btnClear.Click += btnClear_Click;
                }
            }
        }

        private DataGrid _dgEngineerHistory;

        internal DataGrid dgEngineerHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEngineerHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEngineerHistory != null)
                {
                }

                _dgEngineerHistory = value;
                if (_dgEngineerHistory != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpFaultsFilter = new System.Windows.Forms.GroupBox();
            this._btnSearchFault = new System.Windows.Forms.Button();
            this._dtpResolvedTo = new System.Windows.Forms.DateTimePicker();
            this._dtpResolvedFrom = new System.Windows.Forms.DateTimePicker();
            this._lblResolvedTo = new System.Windows.Forms.Label();
            this._lblResolvedFrom = new System.Windows.Forms.Label();
            this._chkResolved = new System.Windows.Forms.CheckBox();
            this._dtpFaultTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFaultFrom = new System.Windows.Forms.DateTimePicker();
            this._lblFaultTo = new System.Windows.Forms.Label();
            this._lblFaultFrom = new System.Windows.Forms.Label();
            this._chkFaultDate = new System.Windows.Forms.CheckBox();
            this._cboFaultType = new System.Windows.Forms.ComboBox();
            this._lblFaultType = new System.Windows.Forms.Label();
            this._grpFaultDG = new System.Windows.Forms.GroupBox();
            this._dgFaults = new System.Windows.Forms.DataGrid();
            this._grpEngineerFilter = new System.Windows.Forms.GroupBox();
            this._btnfindEngineer = new System.Windows.Forms.Button();
            this._txtEngineer = new System.Windows.Forms.TextBox();
            this._lblEngineer = new System.Windows.Forms.Label();
            this._btnSearchEngineer = new System.Windows.Forms.Button();
            this._dtpEngineerTo = new System.Windows.Forms.DateTimePicker();
            this._dtpEngineerFrom = new System.Windows.Forms.DateTimePicker();
            this._lblEngineerTo = new System.Windows.Forms.Label();
            this._lblEngineerFrom = new System.Windows.Forms.Label();
            this._grpEngineerHistory = new System.Windows.Forms.GroupBox();
            this._dgEngineerHistory = new System.Windows.Forms.DataGrid();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._btnClear = new System.Windows.Forms.Button();
            this._lblRegistration = new System.Windows.Forms.Label();
            this._btnfindVan = new System.Windows.Forms.Button();
            this._txtVanReg = new System.Windows.Forms.TextBox();
            this._grpFaultsFilter.SuspendLayout();
            this._grpFaultDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgFaults)).BeginInit();
            this._grpEngineerFilter.SuspendLayout();
            this._grpEngineerHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgEngineerHistory)).BeginInit();
            this._grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpFaultsFilter
            // 
            this._grpFaultsFilter.Controls.Add(this._btnSearchFault);
            this._grpFaultsFilter.Controls.Add(this._dtpResolvedTo);
            this._grpFaultsFilter.Controls.Add(this._dtpResolvedFrom);
            this._grpFaultsFilter.Controls.Add(this._lblResolvedTo);
            this._grpFaultsFilter.Controls.Add(this._lblResolvedFrom);
            this._grpFaultsFilter.Controls.Add(this._chkResolved);
            this._grpFaultsFilter.Controls.Add(this._dtpFaultTo);
            this._grpFaultsFilter.Controls.Add(this._dtpFaultFrom);
            this._grpFaultsFilter.Controls.Add(this._lblFaultTo);
            this._grpFaultsFilter.Controls.Add(this._lblFaultFrom);
            this._grpFaultsFilter.Controls.Add(this._chkFaultDate);
            this._grpFaultsFilter.Controls.Add(this._cboFaultType);
            this._grpFaultsFilter.Controls.Add(this._lblFaultType);
            this._grpFaultsFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpFaultsFilter.Location = new System.Drawing.Point(8, 81);
            this._grpFaultsFilter.Name = "_grpFaultsFilter";
            this._grpFaultsFilter.Size = new System.Drawing.Size(842, 169);
            this._grpFaultsFilter.TabIndex = 3;
            this._grpFaultsFilter.TabStop = false;
            this._grpFaultsFilter.Text = "Filter Faults";
            // 
            // _btnSearchFault
            // 
            this._btnSearchFault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSearchFault.Location = new System.Drawing.Point(766, 140);
            this._btnSearchFault.Name = "_btnSearchFault";
            this._btnSearchFault.Size = new System.Drawing.Size(70, 23);
            this._btnSearchFault.TabIndex = 78;
            this._btnSearchFault.Text = "Run Filter";
            this._btnSearchFault.Click += new System.EventHandler(this.btnSearchFault_Click);
            // 
            // _dtpResolvedTo
            // 
            this._dtpResolvedTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpResolvedTo.Location = new System.Drawing.Point(325, 103);
            this._dtpResolvedTo.Name = "_dtpResolvedTo";
            this._dtpResolvedTo.Size = new System.Drawing.Size(156, 21);
            this._dtpResolvedTo.TabIndex = 77;
            // 
            // _dtpResolvedFrom
            // 
            this._dtpResolvedFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpResolvedFrom.Location = new System.Drawing.Point(325, 72);
            this._dtpResolvedFrom.Name = "_dtpResolvedFrom";
            this._dtpResolvedFrom.Size = new System.Drawing.Size(156, 21);
            this._dtpResolvedFrom.TabIndex = 76;
            // 
            // _lblResolvedTo
            // 
            this._lblResolvedTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblResolvedTo.Location = new System.Drawing.Point(271, 108);
            this._lblResolvedTo.Name = "_lblResolvedTo";
            this._lblResolvedTo.Size = new System.Drawing.Size(48, 16);
            this._lblResolvedTo.TabIndex = 74;
            this._lblResolvedTo.Text = "To";
            // 
            // _lblResolvedFrom
            // 
            this._lblResolvedFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblResolvedFrom.Location = new System.Drawing.Point(271, 77);
            this._lblResolvedFrom.Name = "_lblResolvedFrom";
            this._lblResolvedFrom.Size = new System.Drawing.Size(48, 16);
            this._lblResolvedFrom.TabIndex = 73;
            this._lblResolvedFrom.Text = "From";
            // 
            // _chkResolved
            // 
            this._chkResolved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkResolved.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkResolved.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._chkResolved.Location = new System.Drawing.Point(274, 48);
            this._chkResolved.Name = "_chkResolved";
            this._chkResolved.Size = new System.Drawing.Size(112, 24);
            this._chkResolved.TabIndex = 75;
            this._chkResolved.Text = "Resolved Date";
            // 
            // _dtpFaultTo
            // 
            this._dtpFaultTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpFaultTo.Location = new System.Drawing.Point(61, 104);
            this._dtpFaultTo.Name = "_dtpFaultTo";
            this._dtpFaultTo.Size = new System.Drawing.Size(156, 21);
            this._dtpFaultTo.TabIndex = 72;
            // 
            // _dtpFaultFrom
            // 
            this._dtpFaultFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpFaultFrom.Location = new System.Drawing.Point(61, 73);
            this._dtpFaultFrom.Name = "_dtpFaultFrom";
            this._dtpFaultFrom.Size = new System.Drawing.Size(156, 21);
            this._dtpFaultFrom.TabIndex = 71;
            // 
            // _lblFaultTo
            // 
            this._lblFaultTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblFaultTo.Location = new System.Drawing.Point(7, 109);
            this._lblFaultTo.Name = "_lblFaultTo";
            this._lblFaultTo.Size = new System.Drawing.Size(48, 16);
            this._lblFaultTo.TabIndex = 69;
            this._lblFaultTo.Text = "To";
            // 
            // _lblFaultFrom
            // 
            this._lblFaultFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblFaultFrom.Location = new System.Drawing.Point(7, 78);
            this._lblFaultFrom.Name = "_lblFaultFrom";
            this._lblFaultFrom.Size = new System.Drawing.Size(48, 16);
            this._lblFaultFrom.TabIndex = 68;
            this._lblFaultFrom.Text = "From";
            // 
            // _chkFaultDate
            // 
            this._chkFaultDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkFaultDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkFaultDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._chkFaultDate.Location = new System.Drawing.Point(10, 48);
            this._chkFaultDate.Name = "_chkFaultDate";
            this._chkFaultDate.Size = new System.Drawing.Size(80, 24);
            this._chkFaultDate.TabIndex = 70;
            this._chkFaultDate.Text = "Fault Date";
            // 
            // _cboFaultType
            // 
            this._cboFaultType.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboFaultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboFaultType.Location = new System.Drawing.Point(108, 20);
            this._cboFaultType.Name = "_cboFaultType";
            this._cboFaultType.Size = new System.Drawing.Size(171, 21);
            this._cboFaultType.TabIndex = 32;
            this._cboFaultType.Tag = "";
            // 
            // _lblFaultType
            // 
            this._lblFaultType.Location = new System.Drawing.Point(6, 23);
            this._lblFaultType.Name = "_lblFaultType";
            this._lblFaultType.Size = new System.Drawing.Size(96, 20);
            this._lblFaultType.TabIndex = 33;
            this._lblFaultType.Text = "Fault Type";
            // 
            // _grpFaultDG
            // 
            this._grpFaultDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._grpFaultDG.Controls.Add(this._dgFaults);
            this._grpFaultDG.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpFaultDG.Location = new System.Drawing.Point(8, 256);
            this._grpFaultDG.Name = "_grpFaultDG";
            this._grpFaultDG.Size = new System.Drawing.Size(842, 446);
            this._grpFaultDG.TabIndex = 14;
            this._grpFaultDG.TabStop = false;
            this._grpFaultDG.Text = "Faults";
            // 
            // _dgFaults
            // 
            this._dgFaults.DataMember = "";
            this._dgFaults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgFaults.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgFaults.Location = new System.Drawing.Point(3, 17);
            this._dgFaults.Name = "_dgFaults";
            this._dgFaults.Size = new System.Drawing.Size(836, 426);
            this._dgFaults.TabIndex = 45;
            this._dgFaults.DoubleClick += new System.EventHandler(this.dgFaults_DoubleClick);
            // 
            // _grpEngineerFilter
            // 
            this._grpEngineerFilter.Controls.Add(this._btnfindEngineer);
            this._grpEngineerFilter.Controls.Add(this._txtEngineer);
            this._grpEngineerFilter.Controls.Add(this._lblEngineer);
            this._grpEngineerFilter.Controls.Add(this._btnSearchEngineer);
            this._grpEngineerFilter.Controls.Add(this._dtpEngineerTo);
            this._grpEngineerFilter.Controls.Add(this._dtpEngineerFrom);
            this._grpEngineerFilter.Controls.Add(this._lblEngineerTo);
            this._grpEngineerFilter.Controls.Add(this._lblEngineerFrom);
            this._grpEngineerFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpEngineerFilter.Location = new System.Drawing.Point(856, 81);
            this._grpEngineerFilter.Name = "_grpEngineerFilter";
            this._grpEngineerFilter.Size = new System.Drawing.Size(639, 169);
            this._grpEngineerFilter.TabIndex = 14;
            this._grpEngineerFilter.TabStop = false;
            this._grpEngineerFilter.Text = "Filter Engineer";
            // 
            // _btnfindEngineer
            // 
            this._btnfindEngineer.BackColor = System.Drawing.Color.White;
            this._btnfindEngineer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnfindEngineer.Location = new System.Drawing.Point(316, 18);
            this._btnfindEngineer.Name = "_btnfindEngineer";
            this._btnfindEngineer.Size = new System.Drawing.Size(32, 23);
            this._btnfindEngineer.TabIndex = 84;
            this._btnfindEngineer.Text = "...";
            this._btnfindEngineer.UseVisualStyleBackColor = false;
            this._btnfindEngineer.Click += new System.EventHandler(this.btnfindEngineer_Click);
            // 
            // _txtEngineer
            // 
            this._txtEngineer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEngineer.Location = new System.Drawing.Point(100, 20);
            this._txtEngineer.Name = "_txtEngineer";
            this._txtEngineer.ReadOnly = true;
            this._txtEngineer.Size = new System.Drawing.Size(201, 21);
            this._txtEngineer.TabIndex = 83;
            // 
            // _lblEngineer
            // 
            this._lblEngineer.Location = new System.Drawing.Point(6, 23);
            this._lblEngineer.Name = "_lblEngineer";
            this._lblEngineer.Size = new System.Drawing.Size(85, 20);
            this._lblEngineer.TabIndex = 85;
            this._lblEngineer.Text = "Engineer";
            // 
            // _btnSearchEngineer
            // 
            this._btnSearchEngineer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSearchEngineer.Location = new System.Drawing.Point(563, 140);
            this._btnSearchEngineer.Name = "_btnSearchEngineer";
            this._btnSearchEngineer.Size = new System.Drawing.Size(70, 23);
            this._btnSearchEngineer.TabIndex = 79;
            this._btnSearchEngineer.Text = "Run Filter";
            this._btnSearchEngineer.Click += new System.EventHandler(this.btnSearchEngineer_Click);
            // 
            // _dtpEngineerTo
            // 
            this._dtpEngineerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpEngineerTo.Location = new System.Drawing.Point(66, 99);
            this._dtpEngineerTo.Name = "_dtpEngineerTo";
            this._dtpEngineerTo.Size = new System.Drawing.Size(156, 21);
            this._dtpEngineerTo.TabIndex = 82;
            // 
            // _dtpEngineerFrom
            // 
            this._dtpEngineerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpEngineerFrom.Location = new System.Drawing.Point(66, 63);
            this._dtpEngineerFrom.Name = "_dtpEngineerFrom";
            this._dtpEngineerFrom.Size = new System.Drawing.Size(156, 21);
            this._dtpEngineerFrom.TabIndex = 81;
            // 
            // _lblEngineerTo
            // 
            this._lblEngineerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblEngineerTo.Location = new System.Drawing.Point(12, 104);
            this._lblEngineerTo.Name = "_lblEngineerTo";
            this._lblEngineerTo.Size = new System.Drawing.Size(48, 16);
            this._lblEngineerTo.TabIndex = 79;
            this._lblEngineerTo.Text = "To";
            // 
            // _lblEngineerFrom
            // 
            this._lblEngineerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblEngineerFrom.Location = new System.Drawing.Point(12, 68);
            this._lblEngineerFrom.Name = "_lblEngineerFrom";
            this._lblEngineerFrom.Size = new System.Drawing.Size(48, 16);
            this._lblEngineerFrom.TabIndex = 78;
            this._lblEngineerFrom.Text = "From";
            // 
            // _grpEngineerHistory
            // 
            this._grpEngineerHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._grpEngineerHistory.Controls.Add(this._dgEngineerHistory);
            this._grpEngineerHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpEngineerHistory.Location = new System.Drawing.Point(856, 256);
            this._grpEngineerHistory.Name = "_grpEngineerHistory";
            this._grpEngineerHistory.Size = new System.Drawing.Size(639, 446);
            this._grpEngineerHistory.TabIndex = 46;
            this._grpEngineerHistory.TabStop = false;
            this._grpEngineerHistory.Text = "Engineers";
            // 
            // _dgEngineerHistory
            // 
            this._dgEngineerHistory.DataMember = "";
            this._dgEngineerHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgEngineerHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgEngineerHistory.Location = new System.Drawing.Point(3, 17);
            this._dgEngineerHistory.Name = "_dgEngineerHistory";
            this._dgEngineerHistory.Size = new System.Drawing.Size(633, 426);
            this._dgEngineerHistory.TabIndex = 45;
            // 
            // _grpFilter
            // 
            this._grpFilter.Controls.Add(this._btnClear);
            this._grpFilter.Controls.Add(this._lblRegistration);
            this._grpFilter.Controls.Add(this._btnfindVan);
            this._grpFilter.Controls.Add(this._txtVanReg);
            this._grpFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(1484, 63);
            this._grpFilter.TabIndex = 40;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _btnClear
            // 
            this._btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClear.Location = new System.Drawing.Point(1408, 17);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(70, 23);
            this._btnClear.TabIndex = 79;
            this._btnClear.Text = "Clear";
            this._btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // _lblRegistration
            // 
            this._lblRegistration.AutoSize = true;
            this._lblRegistration.Location = new System.Drawing.Point(6, 22);
            this._lblRegistration.Name = "_lblRegistration";
            this._lblRegistration.Size = new System.Drawing.Size(80, 13);
            this._lblRegistration.TabIndex = 42;
            this._lblRegistration.Text = "Registration:";
            // 
            // _btnfindVan
            // 
            this._btnfindVan.BackColor = System.Drawing.Color.White;
            this._btnfindVan.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnfindVan.Location = new System.Drawing.Point(324, 17);
            this._btnfindVan.Name = "_btnfindVan";
            this._btnfindVan.Size = new System.Drawing.Size(32, 23);
            this._btnfindVan.TabIndex = 41;
            this._btnfindVan.Text = "...";
            this._btnfindVan.UseVisualStyleBackColor = false;
            this._btnfindVan.Click += new System.EventHandler(this.btnfindVan_Click);
            // 
            // _txtVanReg
            // 
            this._txtVanReg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtVanReg.Location = new System.Drawing.Point(108, 19);
            this._txtVanReg.Name = "_txtVanReg";
            this._txtVanReg.ReadOnly = true;
            this._txtVanReg.Size = new System.Drawing.Size(201, 21);
            this._txtVanReg.TabIndex = 40;
            // 
            // FRMFleetVanManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1502, 714);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._grpEngineerHistory);
            this.Controls.Add(this._grpEngineerFilter);
            this.Controls.Add(this._grpFaultDG);
            this.Controls.Add(this._grpFaultsFilter);
            this.Name = "FRMFleetVanManager";
            this.Text = "Fleet Van Mileage Import";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpFaultsFilter.ResumeLayout(false);
            this._grpFaultDG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgFaults)).EndInit();
            this._grpEngineerFilter.ResumeLayout(false);
            this._grpEngineerFilter.PerformLayout();
            this._grpEngineerHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgEngineerHistory)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private Entity.FleetVans.FleetVan _currentVan;

        public Entity.FleetVans.FleetVan CurrentVan
        {
            get
            {
                return _currentVan;
            }

            set
            {
                _currentVan = value;
                if (CurrentVan is null)
                {
                    CurrentVan = new Entity.FleetVans.FleetVan();
                    CurrentVan.Exists = false;
                    txtVanReg.Text = "";
                }
                else
                {
                    txtVanReg.Text = CurrentVan.Registration;
                }
            }
        }

        private Entity.Engineers.Engineer _engineer;

        public Entity.Engineers.Engineer Engineer
        {
            get
            {
                return _engineer;
            }

            set
            {
                _engineer = value;
                if (Engineer is null)
                {
                    Engineer = new Entity.Engineers.Engineer();
                    CurrentVan.Exists = false;
                    txtEngineer.Text = "";
                }
                else
                {
                    txtEngineer.Text = Engineer.Name;
                }
            }
        }

        private DataView _dvFaults = null;

        public DataView FaultsDataView
        {
            get
            {
                return _dvFaults;
            }

            set
            {
                _dvFaults = value;
                if (FaultsDataView is object)
                {
                    _dvFaults.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString();
                    _dvFaults.AllowNew = false;
                    _dvFaults.AllowEdit = false;
                    _dvFaults.AllowDelete = false;
                }

                dgFaults.DataSource = FaultsDataView;
            }
        }

        private DataRow SelectedFaultDataRow
        {
            get
            {
                if (!(dgFaults.CurrentRowIndex == -1))
                {
                    return FaultsDataView[dgFaults.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _dvEngineerHistory;

        private DataView EngineerHistoryDataview
        {
            get
            {
                return _dvEngineerHistory;
            }

            set
            {
                _dvEngineerHistory = value;
                if (EngineerHistoryDataview is object)
                {
                    _dvEngineerHistory.AllowNew = false;
                    _dvEngineerHistory.AllowEdit = false;
                    _dvEngineerHistory.AllowDelete = false;
                    _dvEngineerHistory.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanEngineer.ToString();
                }

                dgEngineerHistory.DataSource = EngineerHistoryDataview;
            }
        }

        private DataRow SelectedEngineerDataRow
        {
            get
            {
                if (!(dgEngineerHistory.CurrentRowIndex == -1))
                {
                    return EngineerHistoryDataview[dgEngineerHistory.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetupDGFault()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgFaults);
            var tStyle = dgFaults.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var reg = new DataGridLabelColumn();
            reg.Format = "";
            reg.FormatInfo = null;
            reg.HeaderText = "Registration";
            reg.MappingName = "Registration";
            reg.ReadOnly = true;
            reg.Width = 130;
            reg.NullText = "";
            tStyle.GridColumnStyles.Add(reg);
            var faultType = new DataGridLabelColumn();
            faultType.Format = "";
            faultType.FormatInfo = null;
            faultType.HeaderText = "Fault";
            faultType.MappingName = "Name";
            faultType.ReadOnly = true;
            faultType.Width = 130;
            faultType.NullText = "";
            tStyle.GridColumnStyles.Add(faultType);
            var faultDate = new DataGridLabelColumn();
            faultDate.Format = "dd/MM/yyyy";
            faultDate.FormatInfo = null;
            faultDate.HeaderText = "Fault Date";
            faultDate.MappingName = "FaultDate";
            faultDate.ReadOnly = true;
            faultDate.Width = 105;
            faultDate.NullText = "";
            tStyle.GridColumnStyles.Add(faultDate);
            var resolvedDate = new DataGridLabelColumn();
            resolvedDate.Format = "dd/MM/yyyy";
            resolvedDate.FormatInfo = null;
            resolvedDate.HeaderText = "Resolved Date";
            resolvedDate.MappingName = "ResolvedDate";
            resolvedDate.ReadOnly = true;
            resolvedDate.Width = 105;
            resolvedDate.NullText = "";
            tStyle.GridColumnStyles.Add(resolvedDate);
            var engineerNotes = new DataGridLabelColumn();
            engineerNotes.Format = "dd/MM/yyyy";
            engineerNotes.FormatInfo = null;
            engineerNotes.HeaderText = "Engineer Notes";
            engineerNotes.MappingName = "EngineerNotes";
            engineerNotes.ReadOnly = true;
            engineerNotes.Width = 200;
            engineerNotes.NullText = "";
            tStyle.GridColumnStyles.Add(engineerNotes);
            var lastChanged = new DataGridLabelColumn();
            lastChanged.Format = "dd/MM/yyyy";
            lastChanged.FormatInfo = null;
            lastChanged.HeaderText = "Last Changed";
            lastChanged.MappingName = "LastChanged";
            lastChanged.ReadOnly = true;
            lastChanged.Width = 105;
            lastChanged.NullText = "";
            tStyle.GridColumnStyles.Add(lastChanged);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString();
            dgFaults.TableStyles.Add(tStyle);
        }

        public void SetupDGEngineerHistory()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgEngineerHistory);
            var tStyle = dgEngineerHistory.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var reg = new DataGridLabelColumn();
            reg.Format = "";
            reg.FormatInfo = null;
            reg.HeaderText = "Registration";
            reg.MappingName = "Registration";
            reg.ReadOnly = true;
            reg.Width = 130;
            reg.NullText = "";
            tStyle.GridColumnStyles.Add(reg);
            var name = new DataGridLabelColumn();
            name.Format = "";
            name.FormatInfo = null;
            name.HeaderText = "Name";
            name.MappingName = "Name";
            name.ReadOnly = true;
            name.Width = 130;
            name.NullText = "";
            tStyle.GridColumnStyles.Add(name);
            var startDate = new DataGridLabelColumn();
            startDate.Format = "dd/MM/yyyy";
            startDate.FormatInfo = null;
            startDate.HeaderText = "From";
            startDate.MappingName = "StartDateTime";
            startDate.ReadOnly = true;
            startDate.Width = 150;
            startDate.NullText = "";
            tStyle.GridColumnStyles.Add(startDate);
            var endDate = new DataGridLabelColumn();
            endDate.Format = "dd/MM/yyyy";
            endDate.FormatInfo = null;
            endDate.HeaderText = "To";
            endDate.MappingName = "EndDateTime";
            endDate.ReadOnly = true;
            endDate.Width = 150;
            endDate.NullText = "";
            tStyle.GridColumnStyles.Add(endDate);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanEngineer.ToString();
            dgEngineerHistory.TableStyles.Add(tStyle);
        }

        private void FRMImport_Load(object sender, EventArgs e)
        {
            SetupDGFault();
            SetupDGEngineerHistory();
        }

        private void btnfindVan_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblFleetVan));
            if (!(ID == 0))
            {
                CurrentVan = App.DB.FleetVan.Get(ID);
            }
        }

        private void btnfindEngineer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                Engineer = App.DB.Engineer.Engineer_Get(ID);
            }
        }

        private void btnSearchFault_Click(object sender, EventArgs e)
        {
            PopulateFaultsDatagrid();
        }

        private void btnSearchEngineer_Click(object sender, EventArgs e)
        {
            PopulateEngineerDatagrid();
        }

        private void dgFaults_DoubleClick(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblFleetVan));
            if (!(ID == 0))
            {
                var newVan = App.DB.FleetVan.Get(ID);
                if (newVan is object)
                {
                    if (App.ShowMessage("Move fault? The fault will now be assigned to: " + newVan.Registration + ", Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var faultToMove = App.DB.FleetVanFault.Get(Conversions.ToInteger(SelectedFaultDataRow["VanFaultID"]));
                        faultToMove.SetVanID = newVan.VanID;
                        App.DB.FleetVanFault.Update(faultToMove);
                        App.ShowMessage("Fault has been moved to " + newVan.Registration, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FaultsDataView = null;
            EngineerHistoryDataview = null;
            CurrentVan = null;
            Engineer = null;
        }

        public void PopulateFaultsDatagrid()
        {
            try
            {
                string whereClause = "(1 = 1";
                if (CurrentVan is object)
                {
                    whereClause += " AND tblFleetVan.VanID = " + CurrentVan.VanID + "";
                }

                if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboFaultType)) == 0))
                {
                    whereClause += " AND tblFleetVanFault.FaultType = " + Combo.get_GetSelectedItemValue(cboFaultType) + "";
                }

                if (chkFaultDate.Checked)
                {
                    whereClause += " AND tblFleetVanFault.FaultDate >= '" + Strings.Format(dtpFaultFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblFleetVanFault.FaultDate <= '" + Strings.Format(dtpFaultTo.Value, "dd-MMM-yyyy 23:59:59") + "'";
                }

                if (chkResolved.Checked)
                {
                    whereClause += " AND tblFleetVanFault.ResolvedDate >= '" + Strings.Format(dtpResolvedFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblFleetVanFault.ResolvedDate <= '" + Strings.Format(dtpResolvedTo.Value, "dd-MMM-yyyy 23:59:59") + "'";
                }

                whereClause += ")";
                FaultsDataView = App.DB.FleetVanFault.GetAll_Trans(whereClause);
                int count = 0;
                count = FaultsDataView.Count;
                grpFaultDG.Text = "Double Click To Move Fault (" + Conversions.ToString(count) + ")";
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PopulateEngineerDatagrid()
        {
            try
            {
                string whereClause = "(1 = 1";
                if (CurrentVan is object)
                {
                    whereClause += " AND tblFleetVan.VanID = " + CurrentVan.VanID + "";
                }

                if (Engineer is object)
                {
                    whereClause += " AND tblFleetVanEngineer.EngineerID = " + Engineer.EngineerID + "";
                }

                whereClause += " AND tblFleetVanEngineer.StartDateTime >= '" + Strings.Format(dtpEngineerFrom.Value, "dd-MMM-yyyy 00:00:00") + "'" + " And tblFleetVanEngineer.StartDateTime <= '" + Strings.Format(dtpEngineerTo.Value, "dd-MMM-yyyy 23:59:59") + "'" + " AND ((tblFleetVanEngineer.EndDateTime >= '" + Strings.Format(dtpEngineerFrom.Value, "dd-MMM-yyyy 00:00:00") + "'" + " AND tblFleetVanEngineer.EndDateTime <= '" + Strings.Format(dtpEngineerTo.Value, "dd-MMM-yyyy 23:59:59") + "')" + "Or tblFleetVanEngineer.EndDateTime Is NULL)";
                whereClause += ")";
                EngineerHistoryDataview = App.DB.FleetVanEngineer.GetAll_Trans(whereClause);
                int count = 0;
                count = EngineerHistoryDataview.Count;
                grpEngineerHistory.Text = "Vehicles (" + Conversions.ToString(count) + ")";
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}