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
            _grpFaultsFilter = new GroupBox();
            _btnSearchFault = new Button();
            _btnSearchFault.Click += new EventHandler(btnSearchFault_Click);
            _dtpResolvedTo = new DateTimePicker();
            _dtpResolvedFrom = new DateTimePicker();
            _lblResolvedTo = new Label();
            _lblResolvedFrom = new Label();
            _chkResolved = new CheckBox();
            _dtpFaultTo = new DateTimePicker();
            _dtpFaultFrom = new DateTimePicker();
            _lblFaultTo = new Label();
            _lblFaultFrom = new Label();
            _chkFaultDate = new CheckBox();
            _cboFaultType = new ComboBox();
            _lblFaultType = new Label();
            _grpFaultDG = new GroupBox();
            _dgFaults = new DataGrid();
            _dgFaults.DoubleClick += new EventHandler(dgFaults_DoubleClick);
            _grpEngineerFilter = new GroupBox();
            _btnfindEngineer = new Button();
            _btnfindEngineer.Click += new EventHandler(btnfindEngineer_Click);
            _txtEngineer = new TextBox();
            _lblEngineer = new Label();
            _btnSearchEngineer = new Button();
            _btnSearchEngineer.Click += new EventHandler(btnSearchEngineer_Click);
            _dtpEngineerTo = new DateTimePicker();
            _dtpEngineerFrom = new DateTimePicker();
            _lblEngineerTo = new Label();
            _lblEngineerFrom = new Label();
            _grpEngineerHistory = new GroupBox();
            _dgEngineerHistory = new DataGrid();
            _grpFilter = new GroupBox();
            _lblRegistration = new Label();
            _btnfindVan = new Button();
            _btnfindVan.Click += new EventHandler(btnfindVan_Click);
            _txtVanReg = new TextBox();
            _btnClear = new Button();
            _btnClear.Click += new EventHandler(btnClear_Click);
            _grpFaultsFilter.SuspendLayout();
            _grpFaultDG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgFaults).BeginInit();
            _grpEngineerFilter.SuspendLayout();
            _grpEngineerHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEngineerHistory).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            //
            // grpFaultsFilter
            //
            _grpFaultsFilter.Controls.Add(_btnSearchFault);
            _grpFaultsFilter.Controls.Add(_dtpResolvedTo);
            _grpFaultsFilter.Controls.Add(_dtpResolvedFrom);
            _grpFaultsFilter.Controls.Add(_lblResolvedTo);
            _grpFaultsFilter.Controls.Add(_lblResolvedFrom);
            _grpFaultsFilter.Controls.Add(_chkResolved);
            _grpFaultsFilter.Controls.Add(_dtpFaultTo);
            _grpFaultsFilter.Controls.Add(_dtpFaultFrom);
            _grpFaultsFilter.Controls.Add(_lblFaultTo);
            _grpFaultsFilter.Controls.Add(_lblFaultFrom);
            _grpFaultsFilter.Controls.Add(_chkFaultDate);
            _grpFaultsFilter.Controls.Add(_cboFaultType);
            _grpFaultsFilter.Controls.Add(_lblFaultType);
            _grpFaultsFilter.FlatStyle = FlatStyle.System;
            _grpFaultsFilter.Location = new Point(8, 107);
            _grpFaultsFilter.Name = "grpFaultsFilter";
            _grpFaultsFilter.Size = new Size(842, 169);
            _grpFaultsFilter.TabIndex = 3;
            _grpFaultsFilter.TabStop = false;
            _grpFaultsFilter.Text = "Filter Faults";
            //
            // btnSearchFault
            //
            _btnSearchFault.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSearchFault.Location = new Point(766, 140);
            _btnSearchFault.Name = "btnSearchFault";
            _btnSearchFault.Size = new Size(70, 23);
            _btnSearchFault.TabIndex = 78;
            _btnSearchFault.Text = "Run Filter";
            //
            // dtpResolvedTo
            //
            _dtpResolvedTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpResolvedTo.Location = new Point(325, 103);
            _dtpResolvedTo.Name = "dtpResolvedTo";
            _dtpResolvedTo.Size = new Size(156, 21);
            _dtpResolvedTo.TabIndex = 77;
            //
            // dtpResolvedFrom
            //
            _dtpResolvedFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpResolvedFrom.Location = new Point(325, 72);
            _dtpResolvedFrom.Name = "dtpResolvedFrom";
            _dtpResolvedFrom.Size = new Size(156, 21);
            _dtpResolvedFrom.TabIndex = 76;
            //
            // lblResolvedTo
            //
            _lblResolvedTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblResolvedTo.Location = new Point(271, 108);
            _lblResolvedTo.Name = "lblResolvedTo";
            _lblResolvedTo.Size = new Size(48, 16);
            _lblResolvedTo.TabIndex = 74;
            _lblResolvedTo.Text = "To";
            //
            // lblResolvedFrom
            //
            _lblResolvedFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblResolvedFrom.Location = new Point(271, 77);
            _lblResolvedFrom.Name = "lblResolvedFrom";
            _lblResolvedFrom.Size = new Size(48, 16);
            _lblResolvedFrom.TabIndex = 73;
            _lblResolvedFrom.Text = "From";
            //
            // chkResolved
            //
            _chkResolved.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkResolved.Cursor = Cursors.Hand;
            _chkResolved.FlatStyle = FlatStyle.System;
            _chkResolved.Location = new Point(274, 48);
            _chkResolved.Name = "chkResolved";
            _chkResolved.Size = new Size(112, 24);
            _chkResolved.TabIndex = 75;
            _chkResolved.Text = "Resolved Date";
            //
            // dtpFaultTo
            //
            _dtpFaultTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpFaultTo.Location = new Point(61, 104);
            _dtpFaultTo.Name = "dtpFaultTo";
            _dtpFaultTo.Size = new Size(156, 21);
            _dtpFaultTo.TabIndex = 72;
            //
            // dtpFaultFrom
            //
            _dtpFaultFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpFaultFrom.Location = new Point(61, 73);
            _dtpFaultFrom.Name = "dtpFaultFrom";
            _dtpFaultFrom.Size = new Size(156, 21);
            _dtpFaultFrom.TabIndex = 71;
            //
            // lblFaultTo
            //
            _lblFaultTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblFaultTo.Location = new Point(7, 109);
            _lblFaultTo.Name = "lblFaultTo";
            _lblFaultTo.Size = new Size(48, 16);
            _lblFaultTo.TabIndex = 69;
            _lblFaultTo.Text = "To";
            //
            // lblFaultFrom
            //
            _lblFaultFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblFaultFrom.Location = new Point(7, 78);
            _lblFaultFrom.Name = "lblFaultFrom";
            _lblFaultFrom.Size = new Size(48, 16);
            _lblFaultFrom.TabIndex = 68;
            _lblFaultFrom.Text = "From";
            //
            // chkFaultDate
            //
            _chkFaultDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkFaultDate.Cursor = Cursors.Hand;
            _chkFaultDate.FlatStyle = FlatStyle.System;
            _chkFaultDate.Location = new Point(10, 48);
            _chkFaultDate.Name = "chkFaultDate";
            _chkFaultDate.Size = new Size(80, 24);
            _chkFaultDate.TabIndex = 70;
            _chkFaultDate.Text = "Fault Date";
            //
            // cboFaultType
            //
            _cboFaultType.Cursor = Cursors.Hand;
            _cboFaultType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFaultType.Location = new Point(108, 20);
            _cboFaultType.Name = "cboFaultType";
            _cboFaultType.Size = new Size(171, 21);
            _cboFaultType.TabIndex = 32;
            _cboFaultType.Tag = "";
            //
            // lblFaultType
            //
            _lblFaultType.Location = new Point(6, 23);
            _lblFaultType.Name = "lblFaultType";
            _lblFaultType.Size = new Size(96, 20);
            _lblFaultType.TabIndex = 33;
            _lblFaultType.Text = "Fault Type";
            //
            // grpFaultDG
            //
            _grpFaultDG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _grpFaultDG.Controls.Add(_dgFaults);
            _grpFaultDG.FlatStyle = FlatStyle.System;
            _grpFaultDG.Location = new Point(8, 282);
            _grpFaultDG.Name = "grpFaultDG";
            _grpFaultDG.Size = new Size(842, 420);
            _grpFaultDG.TabIndex = 14;
            _grpFaultDG.TabStop = false;
            _grpFaultDG.Text = "Faults";
            //
            // dgFaults
            //
            _dgFaults.DataMember = "";
            _dgFaults.Dock = DockStyle.Fill;
            _dgFaults.HeaderForeColor = SystemColors.ControlText;
            _dgFaults.Location = new Point(3, 17);
            _dgFaults.Name = "dgFaults";
            _dgFaults.Size = new Size(836, 400);
            _dgFaults.TabIndex = 45;
            //
            // grpEngineerFilter
            //
            _grpEngineerFilter.Controls.Add(_btnfindEngineer);
            _grpEngineerFilter.Controls.Add(_txtEngineer);
            _grpEngineerFilter.Controls.Add(_lblEngineer);
            _grpEngineerFilter.Controls.Add(_btnSearchEngineer);
            _grpEngineerFilter.Controls.Add(_dtpEngineerTo);
            _grpEngineerFilter.Controls.Add(_dtpEngineerFrom);
            _grpEngineerFilter.Controls.Add(_lblEngineerTo);
            _grpEngineerFilter.Controls.Add(_lblEngineerFrom);
            _grpEngineerFilter.FlatStyle = FlatStyle.System;
            _grpEngineerFilter.Location = new Point(856, 107);
            _grpEngineerFilter.Name = "grpEngineerFilter";
            _grpEngineerFilter.Size = new Size(639, 169);
            _grpEngineerFilter.TabIndex = 14;
            _grpEngineerFilter.TabStop = false;
            _grpEngineerFilter.Text = "Filter Engineer";
            //
            // btnfindEngineer
            //
            _btnfindEngineer.BackColor = Color.White;
            _btnfindEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindEngineer.Location = new Point(316, 18);
            _btnfindEngineer.Name = "btnfindEngineer";
            _btnfindEngineer.Size = new Size(32, 23);
            _btnfindEngineer.TabIndex = 84;
            _btnfindEngineer.Text = "...";
            _btnfindEngineer.UseVisualStyleBackColor = false;
            //
            // txtEngineer
            //
            _txtEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtEngineer.Location = new Point(100, 20);
            _txtEngineer.Name = "txtEngineer";
            _txtEngineer.ReadOnly = true;
            _txtEngineer.Size = new Size(201, 21);
            _txtEngineer.TabIndex = 83;
            //
            // lblEngineer
            //
            _lblEngineer.Location = new Point(6, 23);
            _lblEngineer.Name = "lblEngineer";
            _lblEngineer.Size = new Size(85, 20);
            _lblEngineer.TabIndex = 85;
            _lblEngineer.Text = "Engineer";
            //
            // btnSearchEngineer
            //
            _btnSearchEngineer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSearchEngineer.Location = new Point(563, 140);
            _btnSearchEngineer.Name = "btnSearchEngineer";
            _btnSearchEngineer.Size = new Size(70, 23);
            _btnSearchEngineer.TabIndex = 79;
            _btnSearchEngineer.Text = "Run Filter";
            //
            // dtpEngineerTo
            //
            _dtpEngineerTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpEngineerTo.Location = new Point(66, 99);
            _dtpEngineerTo.Name = "dtpEngineerTo";
            _dtpEngineerTo.Size = new Size(156, 21);
            _dtpEngineerTo.TabIndex = 82;
            //
            // dtpEngineerFrom
            //
            _dtpEngineerFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpEngineerFrom.Location = new Point(66, 63);
            _dtpEngineerFrom.Name = "dtpEngineerFrom";
            _dtpEngineerFrom.Size = new Size(156, 21);
            _dtpEngineerFrom.TabIndex = 81;
            //
            // lblEngineerTo
            //
            _lblEngineerTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblEngineerTo.Location = new Point(12, 104);
            _lblEngineerTo.Name = "lblEngineerTo";
            _lblEngineerTo.Size = new Size(48, 16);
            _lblEngineerTo.TabIndex = 79;
            _lblEngineerTo.Text = "To";
            //
            // lblEngineerFrom
            //
            _lblEngineerFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblEngineerFrom.Location = new Point(12, 68);
            _lblEngineerFrom.Name = "lblEngineerFrom";
            _lblEngineerFrom.Size = new Size(48, 16);
            _lblEngineerFrom.TabIndex = 78;
            _lblEngineerFrom.Text = "From";
            //
            // grpEngineerHistory
            //
            _grpEngineerHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _grpEngineerHistory.Controls.Add(_dgEngineerHistory);
            _grpEngineerHistory.FlatStyle = FlatStyle.System;
            _grpEngineerHistory.Location = new Point(856, 282);
            _grpEngineerHistory.Name = "grpEngineerHistory";
            _grpEngineerHistory.Size = new Size(639, 420);
            _grpEngineerHistory.TabIndex = 46;
            _grpEngineerHistory.TabStop = false;
            _grpEngineerHistory.Text = "Engineers";
            //
            // dgEngineerHistory
            //
            _dgEngineerHistory.DataMember = "";
            _dgEngineerHistory.Dock = DockStyle.Fill;
            _dgEngineerHistory.HeaderForeColor = SystemColors.ControlText;
            _dgEngineerHistory.Location = new Point(3, 17);
            _dgEngineerHistory.Name = "dgEngineerHistory";
            _dgEngineerHistory.Size = new Size(633, 400);
            _dgEngineerHistory.TabIndex = 45;
            //
            // grpFilter
            //
            _grpFilter.Controls.Add(_btnClear);
            _grpFilter.Controls.Add(_lblRegistration);
            _grpFilter.Controls.Add(_btnfindVan);
            _grpFilter.Controls.Add(_txtVanReg);
            _grpFilter.FlatStyle = FlatStyle.System;
            _grpFilter.Location = new Point(8, 38);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(1484, 63);
            _grpFilter.TabIndex = 40;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // lblRegistration
            //
            _lblRegistration.AutoSize = true;
            _lblRegistration.Location = new Point(6, 22);
            _lblRegistration.Name = "lblRegistration";
            _lblRegistration.Size = new Size(80, 13);
            _lblRegistration.TabIndex = 42;
            _lblRegistration.Text = "Registration:";
            //
            // btnfindVan
            //
            _btnfindVan.BackColor = Color.White;
            _btnfindVan.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindVan.Location = new Point(324, 17);
            _btnfindVan.Name = "btnfindVan";
            _btnfindVan.Size = new Size(32, 23);
            _btnfindVan.TabIndex = 41;
            _btnfindVan.Text = "...";
            _btnfindVan.UseVisualStyleBackColor = false;
            //
            // txtVanReg
            //
            _txtVanReg.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtVanReg.Location = new Point(108, 19);
            _txtVanReg.Name = "txtVanReg";
            _txtVanReg.ReadOnly = true;
            _txtVanReg.Size = new Size(201, 21);
            _txtVanReg.TabIndex = 40;
            //
            // btnClear
            //
            _btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnClear.Location = new Point(1408, 17);
            _btnClear.Name = "btnClear";
            _btnClear.Size = new Size(70, 23);
            _btnClear.TabIndex = 79;
            _btnClear.Text = "Clear";
            //
            // FRMFleetVanManager
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1502, 714);
            Controls.Add(_grpFilter);
            Controls.Add(_grpEngineerHistory);
            Controls.Add(_grpEngineerFilter);
            Controls.Add(_grpFaultDG);
            Controls.Add(_grpFaultsFilter);
            Name = "FRMFleetVanManager";
            Text = "Fleet Van Mileage Import";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpFaultsFilter, 0);
            Controls.SetChildIndex(_grpFaultDG, 0);
            Controls.SetChildIndex(_grpEngineerFilter, 0);
            Controls.SetChildIndex(_grpEngineerHistory, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            _grpFaultsFilter.ResumeLayout(false);
            _grpFaultDG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgFaults).EndInit();
            _grpEngineerFilter.ResumeLayout(false);
            _grpEngineerFilter.PerformLayout();
            _grpEngineerHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgEngineerHistory).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ResumeLayout(false);
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