using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCVan : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCVan() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCVan_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboPreferredSupplierID;
            Combo.SetUpCombo(ref argc, DynamicDataTables.SupplierIDList, "SupplierID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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
        private TabControl _tcVans;

        internal TabControl tcVans
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcVans;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcVans != null)
                {
                }

                _tcVans = value;
                if (_tcVans != null)
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

        private GroupBox _grpVan;

        internal GroupBox grpVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVan != null)
                {
                }

                _grpVan = value;
                if (_grpVan != null)
                {
                }
            }
        }

        private TextBox _txtProfile;

        internal TextBox txtProfile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProfile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProfile != null)
                {
                }

                _txtProfile = value;
                if (_txtProfile != null)
                {
                }
            }
        }

        private Label _lblProfile;

        internal Label lblProfile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProfile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProfile != null)
                {
                }

                _lblProfile = value;
                if (_lblProfile != null)
                {
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

        private Label _lblNotes;

        internal Label lblNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNotes != null)
                {
                }

                _lblNotes = value;
                if (_lblNotes != null)
                {
                }
            }
        }

        private TabPage _tabStock;

        internal TabPage tabStock
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabStock;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabStock != null)
                {
                }

                _tabStock = value;
                if (_tabStock != null)
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

        private Button _btnCopyProfile;

        internal Button btnCopyProfile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCopyProfile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCopyProfile != null)
                {
                    _btnCopyProfile.Click -= btnCopyVan_Click;
                }

                _btnCopyProfile = value;
                if (_btnCopyProfile != null)
                {
                    _btnCopyProfile.Click += btnCopyVan_Click;
                }
            }
        }

        private TabPage _tpWarehouses;

        internal TabPage tpWarehouses
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpWarehouses;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpWarehouses != null)
                {
                }

                _tpWarehouses = value;
                if (_tpWarehouses != null)
                {
                }
            }
        }

        private GroupBox _grpWarehouses;

        internal GroupBox grpWarehouses
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpWarehouses;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpWarehouses != null)
                {
                }

                _grpWarehouses = value;
                if (_grpWarehouses != null)
                {
                }
            }
        }

        private DataGrid _dgWarehouses;

        internal DataGrid dgWarehouses
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgWarehouses;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgWarehouses != null)
                {
                    _dgWarehouses.MouseUp -= dgWarehouses_MouseUp;
                }

                _dgWarehouses = value;
                if (_dgWarehouses != null)
                {
                    _dgWarehouses.MouseUp += dgWarehouses_MouseUp;
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

        private ComboBox _cboPreferredSupplierID;

        internal ComboBox cboPreferredSupplierID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPreferredSupplierID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPreferredSupplierID != null)
                {
                }

                _cboPreferredSupplierID = value;
                if (_cboPreferredSupplierID != null)
                {
                }
            }
        }

        private CheckBox _chkExcludeFromAutoStockReplen;

        internal CheckBox chkExcludeFromAutoStockReplen
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkExcludeFromAutoStockReplen;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkExcludeFromAutoStockReplen != null)
                {
                }

                _chkExcludeFromAutoStockReplen = value;
                if (_chkExcludeFromAutoStockReplen != null)
                {
                }
            }
        }

        private DataGridView _dgvParts;

        internal DataGridView dgvParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvParts != null)
                {
                    _dgvParts.DoubleClick -= dgvParts_DoubleClick;

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _dgvParts.CellEndEdit -= dgvParts_CellEndEdit;
                    _dgvParts.ColumnHeaderMouseClick -= dgvParts_ColumnHeaderMouseClick;
                }

                _dgvParts = value;
                if (_dgvParts != null)
                {
                    _dgvParts.DoubleClick += dgvParts_DoubleClick;
                    _dgvParts.CellEndEdit += dgvParts_CellEndEdit;
                    _dgvParts.ColumnHeaderMouseClick += dgvParts_ColumnHeaderMouseClick;
                }
            }
        }

        private Button _btnAddPartStockProfile;

        internal Button btnAddPartStockProfile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddPartStockProfile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddPartStockProfile != null)
                {
                    _btnAddPartStockProfile.Click -= btnAddPartVanStock_Click;
                }

                _btnAddPartStockProfile = value;
                if (_btnAddPartStockProfile != null)
                {
                    _btnAddPartStockProfile.Click += btnAddPartVanStock_Click;
                }
            }
        }

        private Button _btnDeletePartStockProfile;

        internal Button btnDeletePartStockProfile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeletePartStockProfile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeletePartStockProfile != null)
                {
                    _btnDeletePartStockProfile.Click -= btnDeletePartVanStock_Click;
                }

                _btnDeletePartStockProfile = value;
                if (_btnDeletePartStockProfile != null)
                {
                    _btnDeletePartStockProfile.Click += btnDeletePartVanStock_Click;
                }
            }
        }

        private Button _btnClearVanStockProfile;

        internal Button btnClearVanStockProfile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClearVanStockProfile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClearVanStockProfile != null)
                {
                    _btnClearVanStockProfile.Click -= btnClearVanStockProfile_Click;
                }

                _btnClearVanStockProfile = value;
                if (_btnClearVanStockProfile != null)
                {
                    _btnClearVanStockProfile.Click += btnClearVanStockProfile_Click;
                }
            }
        }

        private Button _btnExportStockProfile;

        internal Button btnExportStockProfile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExportStockProfile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExportStockProfile != null)
                {
                    _btnExportStockProfile.Click -= btnExportStockProfile_Click;
                }

                _btnExportStockProfile = value;
                if (_btnExportStockProfile != null)
                {
                    _btnExportStockProfile.Click += btnExportStockProfile_Click;
                }
            }
        }

        private Button _btnMerge;

        internal Button btnMerge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMerge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMerge != null)
                {
                    _btnMerge.Click -= btnMergeProfile_Click;
                }

                _btnMerge = value;
                if (_btnMerge != null)
                {
                    _btnMerge.Click += btnMergeProfile_Click;
                }
            }
        }

        private CheckBox _chkSecondaryPrice;

        internal CheckBox chkSecondaryPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSecondaryPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSecondaryPrice != null)
                {
                }

                _chkSecondaryPrice = value;
                if (_chkSecondaryPrice != null)
                {
                }
            }
        }

        private CheckBox _chkContainer;

        internal CheckBox chkContainer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkContainer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkContainer != null)
                {
                }

                _chkContainer = value;
                if (_chkContainer != null)
                {
                }
            }
        }

        private TabPage _tabEquipment;

        internal TabPage tabEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabEquipment != null)
                {
                }

                _tabEquipment = value;
                if (_tabEquipment != null)
                {
                }
            }
        }

        private GroupBox _grpVanEquipment;

        internal GroupBox grpVanEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVanEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVanEquipment != null)
                {
                }

                _grpVanEquipment = value;
                if (_grpVanEquipment != null)
                {
                }
            }
        }

        private Panel _Panel2;

        internal Panel Panel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel2 != null)
                {
                }

                _Panel2 = value;
                if (_Panel2 != null)
                {
                }
            }
        }

        private TextBox _txtEquipmentTool;

        internal TextBox txtEquipmentTool
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEquipmentTool;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEquipmentTool != null)
                {
                }

                _txtEquipmentTool = value;
                if (_txtEquipmentTool != null)
                {
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

        private Button _btnSaveEquipment;

        internal Button btnSaveEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveEquipment != null)
                {
                    _btnSaveEquipment.Click -= btnSaveEquipment_Click;
                }

                _btnSaveEquipment = value;
                if (_btnSaveEquipment != null)
                {
                    _btnSaveEquipment.Click += btnSaveEquipment_Click;
                }
            }
        }

        private Button _btnDeleteEquipment;

        internal Button btnDeleteEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteEquipment != null)
                {
                    _btnDeleteEquipment.Click -= btnDeleteEquipment_Click;
                }

                _btnDeleteEquipment = value;
                if (_btnDeleteEquipment != null)
                {
                    _btnDeleteEquipment.Click += btnDeleteEquipment_Click;
                }
            }
        }

        private DataGrid _dgEquipment;

        internal DataGrid dgEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEquipment != null)
                {
                }

                _dgEquipment = value;
                if (_dgEquipment != null)
                {
                }
            }
        }

        private TextBox _txtCurEngineer;

        internal TextBox txtCurEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCurEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCurEngineer != null)
                {
                }

                _txtCurEngineer = value;
                if (_txtCurEngineer != null)
                {
                }
            }
        }

        private Label _lblCurEngineer;

        internal Label lblCurEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCurEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCurEngineer != null)
                {
                }

                _lblCurEngineer = value;
                if (_lblCurEngineer != null)
                {
                }
            }
        }

        private TextBox _txtCurEngineerFleet;

        internal TextBox txtCurEngineerFleet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCurEngineerFleet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCurEngineerFleet != null)
                {
                }

                _txtCurEngineerFleet = value;
                if (_txtCurEngineerFleet != null)
                {
                }
            }
        }

        private Label _lblCurEngineerFleet;

        internal Label lblCurEngineerFleet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCurEngineerFleet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCurEngineerFleet != null)
                {
                }

                _lblCurEngineerFleet = value;
                if (_lblCurEngineerFleet != null)
                {
                }
            }
        }

        private Button _btnEngineerHistory;

        internal Button btnEngineerHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEngineerHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEngineerHistory != null)
                {
                    _btnEngineerHistory.Click -= btnEngineerHistory_Click;
                }

                _btnEngineerHistory = value;
                if (_btnEngineerHistory != null)
                {
                    _btnEngineerHistory.Click += btnEngineerHistory_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _tcVans = new TabControl();
            _tabDetails = new TabPage();
            _grpVan = new GroupBox();
            _txtCurEngineerFleet = new TextBox();
            _lblCurEngineerFleet = new Label();
            _txtCurEngineer = new TextBox();
            _lblCurEngineer = new Label();
            _btnCopyProfile = new Button();
            _btnCopyProfile.Click += new EventHandler(btnCopyVan_Click);
            _btnEngineerHistory = new Button();
            _btnEngineerHistory.Click += new EventHandler(btnEngineerHistory_Click);
            _txtProfile = new TextBox();
            _lblProfile = new Label();
            _txtNotes = new TextBox();
            _lblNotes = new Label();
            _tabStock = new TabPage();
            _chkContainer = new CheckBox();
            _chkSecondaryPrice = new CheckBox();
            _chkExcludeFromAutoStockReplen = new CheckBox();
            _dgParts = new DataGrid();
            _GroupBox3 = new GroupBox();
            _cboPreferredSupplierID = new ComboBox();
            _GroupBox2 = new GroupBox();
            _btnMerge = new Button();
            _btnMerge.Click += new EventHandler(btnMergeProfile_Click);
            _btnExportStockProfile = new Button();
            _btnExportStockProfile.Click += new EventHandler(btnExportStockProfile_Click);
            _btnClearVanStockProfile = new Button();
            _btnClearVanStockProfile.Click += new EventHandler(btnClearVanStockProfile_Click);
            _btnDeletePartStockProfile = new Button();
            _btnDeletePartStockProfile.Click += new EventHandler(btnDeletePartVanStock_Click);
            _btnAddPartStockProfile = new Button();
            _btnAddPartStockProfile.Click += new EventHandler(btnAddPartVanStock_Click);
            _dgvParts = new DataGridView();
            _dgvParts.DoubleClick += new EventHandler(dgvParts_DoubleClick);
            _dgvParts.CellEndEdit += new DataGridViewCellEventHandler(dgvParts_CellEndEdit);
            _dgvParts.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dgvParts_ColumnHeaderMouseClick);
            _GroupBox1 = new GroupBox();
            _dgProducts = new DataGrid();
            _tpWarehouses = new TabPage();
            _grpWarehouses = new GroupBox();
            _dgWarehouses = new DataGrid();
            _dgWarehouses.MouseUp += new MouseEventHandler(dgWarehouses_MouseUp);
            _tabEquipment = new TabPage();
            _grpVanEquipment = new GroupBox();
            _Panel2 = new Panel();
            _txtEquipmentTool = new TextBox();
            _Label3 = new Label();
            _btnSaveEquipment = new Button();
            _btnSaveEquipment.Click += new EventHandler(btnSaveEquipment_Click);
            _btnDeleteEquipment = new Button();
            _btnDeleteEquipment.Click += new EventHandler(btnDeleteEquipment_Click);
            _dgEquipment = new DataGrid();
            _tcVans.SuspendLayout();
            _tabDetails.SuspendLayout();
            _grpVan.SuspendLayout();
            _tabStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgParts).BeginInit();
            _GroupBox3.SuspendLayout();
            _GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvParts).BeginInit();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgProducts).BeginInit();
            _tpWarehouses.SuspendLayout();
            _grpWarehouses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgWarehouses).BeginInit();
            _tabEquipment.SuspendLayout();
            _grpVanEquipment.SuspendLayout();
            _Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEquipment).BeginInit();
            SuspendLayout();
            // 
            // tcVans
            // 
            _tcVans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcVans.Controls.Add(_tabDetails);
            _tcVans.Controls.Add(_tabStock);
            _tcVans.Controls.Add(_tpWarehouses);
            _tcVans.Controls.Add(_tabEquipment);
            _tcVans.Location = new Point(4, 7);
            _tcVans.Name = "tcVans";
            _tcVans.SelectedIndex = 0;
            _tcVans.Size = new Size(1206, 798);
            _tcVans.TabIndex = 0;
            // 
            // tabDetails
            // 
            _tabDetails.Controls.Add(_grpVan);
            _tabDetails.Location = new Point(4, 22);
            _tabDetails.Name = "tabDetails";
            _tabDetails.Size = new Size(675, 644);
            _tabDetails.TabIndex = 0;
            _tabDetails.Text = "Main Details";
            // 
            // grpVan
            // 
            _grpVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpVan.Controls.Add(_txtCurEngineerFleet);
            _grpVan.Controls.Add(_lblCurEngineerFleet);
            _grpVan.Controls.Add(_txtCurEngineer);
            _grpVan.Controls.Add(_lblCurEngineer);
            _grpVan.Controls.Add(_btnCopyProfile);
            _grpVan.Controls.Add(_btnEngineerHistory);
            _grpVan.Controls.Add(_txtProfile);
            _grpVan.Controls.Add(_lblProfile);
            _grpVan.Controls.Add(_txtNotes);
            _grpVan.Controls.Add(_lblNotes);
            _grpVan.Location = new Point(8, 8);
            _grpVan.Name = "grpVan";
            _grpVan.Size = new Size(664, 631);
            _grpVan.TabIndex = 2;
            _grpVan.TabStop = false;
            _grpVan.Text = "Details";
            // 
            // txtCurEngineerFleet
            // 
            _txtCurEngineerFleet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtCurEngineerFleet.Enabled = false;
            _txtCurEngineerFleet.Location = new Point(131, 77);
            _txtCurEngineerFleet.MaxLength = 20;
            _txtCurEngineerFleet.Name = "txtCurEngineerFleet";
            _txtCurEngineerFleet.Size = new Size(380, 21);
            _txtCurEngineerFleet.TabIndex = 39;
            _txtCurEngineerFleet.Tag = "Profile.EngineerFleet";
            // 
            // lblCurEngineerFleet
            // 
            _lblCurEngineerFleet.Location = new Point(8, 80);
            _lblCurEngineerFleet.Name = "lblCurEngineerFleet";
            _lblCurEngineerFleet.Size = new Size(117, 20);
            _lblCurEngineerFleet.TabIndex = 38;
            _lblCurEngineerFleet.Text = "Engineer Fleet";
            // 
            // txtCurEngineer
            // 
            _txtCurEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtCurEngineer.Enabled = false;
            _txtCurEngineer.Location = new Point(131, 50);
            _txtCurEngineer.MaxLength = 20;
            _txtCurEngineer.Name = "txtCurEngineer";
            _txtCurEngineer.Size = new Size(380, 21);
            _txtCurEngineer.TabIndex = 37;
            _txtCurEngineer.Tag = "Profile.Engineer";
            // 
            // lblCurEngineer
            // 
            _lblCurEngineer.Location = new Point(8, 53);
            _lblCurEngineer.Name = "lblCurEngineer";
            _lblCurEngineer.Size = new Size(117, 20);
            _lblCurEngineer.TabIndex = 36;
            _lblCurEngineer.Text = "Current Engineer";
            // 
            // btnCopyProfile
            // 
            _btnCopyProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCopyProfile.Location = new Point(6, 602);
            _btnCopyProfile.Name = "btnCopyProfile";
            _btnCopyProfile.Size = new Size(87, 23);
            _btnCopyProfile.TabIndex = 35;
            _btnCopyProfile.Text = "Copy Profile";
            _btnCopyProfile.UseVisualStyleBackColor = true;
            // 
            // btnEngineerHistory
            // 
            _btnEngineerHistory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnEngineerHistory.Location = new Point(530, 19);
            _btnEngineerHistory.Name = "btnEngineerHistory";
            _btnEngineerHistory.Size = new Size(112, 23);
            _btnEngineerHistory.TabIndex = 2;
            _btnEngineerHistory.Text = "Engineer History";
            // 
            // txtProfile
            // 
            _txtProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtProfile.Location = new Point(131, 21);
            _txtProfile.MaxLength = 20;
            _txtProfile.Name = "txtProfile";
            _txtProfile.Size = new Size(380, 21);
            _txtProfile.TabIndex = 1;
            _txtProfile.Tag = "Profile.Name";
            // 
            // lblProfile
            // 
            _lblProfile.Location = new Point(8, 24);
            _lblProfile.Name = "lblProfile";
            _lblProfile.Size = new Size(85, 20);
            _lblProfile.TabIndex = 31;
            _lblProfile.Text = "Profile Name";
            // 
            // txtNotes
            // 
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(131, 117);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(511, 473);
            _txtNotes.TabIndex = 7;
            _txtNotes.Tag = "Profile.Notes";
            // 
            // lblNotes
            // 
            _lblNotes.Location = new Point(8, 117);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(53, 22);
            _lblNotes.TabIndex = 31;
            _lblNotes.Text = "Notes";
            // 
            // tabStock
            // 
            _tabStock.Controls.Add(_chkContainer);
            _tabStock.Controls.Add(_chkSecondaryPrice);
            _tabStock.Controls.Add(_chkExcludeFromAutoStockReplen);
            _tabStock.Controls.Add(_dgParts);
            _tabStock.Controls.Add(_GroupBox3);
            _tabStock.Controls.Add(_GroupBox2);
            _tabStock.Controls.Add(_GroupBox1);
            _tabStock.Location = new Point(4, 22);
            _tabStock.Name = "tabStock";
            _tabStock.Size = new Size(1198, 772);
            _tabStock.TabIndex = 1;
            _tabStock.Text = "Stock";
            // 
            // chkContainer
            // 
            _chkContainer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _chkContainer.AutoSize = true;
            _chkContainer.Location = new Point(528, 742);
            _chkContainer.Name = "chkContainer";
            _chkContainer.Size = new Size(143, 17);
            _chkContainer.TabIndex = 5;
            _chkContainer.Text = "Use Container Stock";
            _chkContainer.UseVisualStyleBackColor = true;
            // 
            // chkSecondaryPrice
            // 
            _chkSecondaryPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _chkSecondaryPrice.AutoSize = true;
            _chkSecondaryPrice.Location = new Point(330, 742);
            _chkSecondaryPrice.Name = "chkSecondaryPrice";
            _chkSecondaryPrice.Size = new Size(144, 17);
            _chkSecondaryPrice.TabIndex = 4;
            _chkSecondaryPrice.Text = "Use Secondary Price";
            _chkSecondaryPrice.UseVisualStyleBackColor = true;
            // 
            // chkExcludeFromAutoStockReplen
            // 
            _chkExcludeFromAutoStockReplen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _chkExcludeFromAutoStockReplen.AutoSize = true;
            _chkExcludeFromAutoStockReplen.Location = new Point(16, 742);
            _chkExcludeFromAutoStockReplen.Name = "chkExcludeFromAutoStockReplen";
            _chkExcludeFromAutoStockReplen.Size = new Size(288, 17);
            _chkExcludeFromAutoStockReplen.TabIndex = 3;
            _chkExcludeFromAutoStockReplen.Text = "Exclude From Automatic Stock Replenishment";
            _chkExcludeFromAutoStockReplen.UseVisualStyleBackColor = true;
            // 
            // dgParts
            // 
            _dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgParts.DataMember = "";
            _dgParts.HeaderForeColor = SystemColors.ControlText;
            _dgParts.Location = new Point(637, 259);
            _dgParts.Name = "dgParts";
            _dgParts.Size = new Size(558, 380);
            _dgParts.TabIndex = 2;
            _dgParts.Visible = false;
            // 
            // GroupBox3
            // 
            _GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox3.Controls.Add(_cboPreferredSupplierID);
            _GroupBox3.Location = new Point(8, 680);
            _GroupBox3.Name = "GroupBox3";
            _GroupBox3.Size = new Size(1179, 49);
            _GroupBox3.TabIndex = 2;
            _GroupBox3.TabStop = false;
            _GroupBox3.Text = "Preferred Supplier";
            // 
            // cboPreferredSupplierID
            // 
            _cboPreferredSupplierID.Cursor = Cursors.Hand;
            _cboPreferredSupplierID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPreferredSupplierID.FormattingEnabled = true;
            _cboPreferredSupplierID.Location = new Point(8, 20);
            _cboPreferredSupplierID.Name = "cboPreferredSupplierID";
            _cboPreferredSupplierID.Size = new Size(616, 21);
            _cboPreferredSupplierID.TabIndex = 0;
            // 
            // GroupBox2
            // 
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox2.Controls.Add(_btnMerge);
            _GroupBox2.Controls.Add(_btnExportStockProfile);
            _GroupBox2.Controls.Add(_btnClearVanStockProfile);
            _GroupBox2.Controls.Add(_btnDeletePartStockProfile);
            _GroupBox2.Controls.Add(_btnAddPartStockProfile);
            _GroupBox2.Controls.Add(_dgvParts);
            _GroupBox2.Location = new Point(8, 239);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(1179, 435);
            _GroupBox2.TabIndex = 1;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Parts Held On Profile";
            // 
            // btnMerge
            // 
            _btnMerge.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnMerge.Location = new Point(137, 406);
            _btnMerge.Name = "btnMerge";
            _btnMerge.Size = new Size(159, 23);
            _btnMerge.TabIndex = 37;
            _btnMerge.Text = "Merge Another Profile";
            _btnMerge.UseVisualStyleBackColor = true;
            // 
            // btnExportStockProfile
            // 
            _btnExportStockProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnExportStockProfile.Location = new Point(557, 406);
            _btnExportStockProfile.Name = "btnExportStockProfile";
            _btnExportStockProfile.Size = new Size(200, 23);
            _btnExportStockProfile.TabIndex = 7;
            _btnExportStockProfile.Text = "Export Stock Profile";
            _btnExportStockProfile.UseVisualStyleBackColor = true;
            // 
            // btnClearVanStockProfile
            // 
            _btnClearVanStockProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClearVanStockProfile.Location = new Point(8, 406);
            _btnClearVanStockProfile.MaximumSize = new Size(181, 23);
            _btnClearVanStockProfile.Name = "btnClearVanStockProfile";
            _btnClearVanStockProfile.Size = new Size(123, 23);
            _btnClearVanStockProfile.TabIndex = 6;
            _btnClearVanStockProfile.Text = "Clear Stock Profile";
            _btnClearVanStockProfile.UseVisualStyleBackColor = true;
            // 
            // btnDeletePartStockProfile
            // 
            _btnDeletePartStockProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeletePartStockProfile.Location = new Point(971, 406);
            _btnDeletePartStockProfile.MaximumSize = new Size(0, 23);
            _btnDeletePartStockProfile.Name = "btnDeletePartStockProfile";
            _btnDeletePartStockProfile.Size = new Size(200, 23);
            _btnDeletePartStockProfile.TabIndex = 5;
            _btnDeletePartStockProfile.Text = "Remove Part from Stock Profile";
            _btnDeletePartStockProfile.UseVisualStyleBackColor = true;
            // 
            // btnAddPartStockProfile
            // 
            _btnAddPartStockProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddPartStockProfile.Location = new Point(763, 406);
            _btnAddPartStockProfile.Name = "btnAddPartStockProfile";
            _btnAddPartStockProfile.Size = new Size(200, 23);
            _btnAddPartStockProfile.TabIndex = 4;
            _btnAddPartStockProfile.Text = "Add Part to Stock Profile";
            _btnAddPartStockProfile.UseVisualStyleBackColor = true;
            // 
            // dgvParts
            // 
            _dgvParts.AllowUserToAddRows = false;
            _dgvParts.AllowUserToDeleteRows = false;
            _dgvParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvParts.Location = new Point(8, 20);
            _dgvParts.Name = "dgvParts";
            _dgvParts.Size = new Size(1162, 380);
            _dgvParts.TabIndex = 3;
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_dgProducts);
            _GroupBox1.Location = new Point(8, 8);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(1179, 224);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Products Held On Profile";
            // 
            // dgProducts
            // 
            _dgProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgProducts.DataMember = "";
            _dgProducts.HeaderForeColor = SystemColors.ControlText;
            _dgProducts.Location = new Point(8, 34);
            _dgProducts.Name = "dgProducts";
            _dgProducts.Size = new Size(1163, 184);
            _dgProducts.TabIndex = 1;
            // 
            // tpWarehouses
            // 
            _tpWarehouses.Controls.Add(_grpWarehouses);
            _tpWarehouses.Location = new Point(4, 22);
            _tpWarehouses.Name = "tpWarehouses";
            _tpWarehouses.Padding = new Padding(3);
            _tpWarehouses.Size = new Size(675, 644);
            _tpWarehouses.TabIndex = 2;
            _tpWarehouses.Text = "Warehouse Locations";
            _tpWarehouses.UseVisualStyleBackColor = true;
            // 
            // grpWarehouses
            // 
            _grpWarehouses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpWarehouses.Controls.Add(_dgWarehouses);
            _grpWarehouses.Location = new Point(6, 6);
            _grpWarehouses.Name = "grpWarehouses";
            _grpWarehouses.Size = new Size(663, 632);
            _grpWarehouses.TabIndex = 3;
            _grpWarehouses.TabStop = false;
            _grpWarehouses.Text = "Tick those warehouses for this profile";
            // 
            // dgWarehouses
            // 
            _dgWarehouses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgWarehouses.DataMember = "";
            _dgWarehouses.HeaderForeColor = SystemColors.ControlText;
            _dgWarehouses.Location = new Point(6, 20);
            _dgWarehouses.Name = "dgWarehouses";
            _dgWarehouses.Size = new Size(651, 606);
            _dgWarehouses.TabIndex = 2;
            // 
            // tabEquipment
            // 
            _tabEquipment.BackColor = SystemColors.Control;
            _tabEquipment.Controls.Add(_grpVanEquipment);
            _tabEquipment.Location = new Point(4, 22);
            _tabEquipment.Name = "tabEquipment";
            _tabEquipment.Size = new Size(675, 644);
            _tabEquipment.TabIndex = 3;
            _tabEquipment.Text = "Capital Tools";
            // 
            // grpVanEquipment
            // 
            _grpVanEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpVanEquipment.Controls.Add(_Panel2);
            _grpVanEquipment.Controls.Add(_btnDeleteEquipment);
            _grpVanEquipment.Controls.Add(_dgEquipment);
            _grpVanEquipment.Location = new Point(3, 13);
            _grpVanEquipment.Name = "grpVanEquipment";
            _grpVanEquipment.Size = new Size(662, 617);
            _grpVanEquipment.TabIndex = 14;
            _grpVanEquipment.TabStop = false;
            _grpVanEquipment.Text = "Capital Tools";
            // 
            // Panel2
            // 
            _Panel2.Controls.Add(_txtEquipmentTool);
            _Panel2.Controls.Add(_Label3);
            _Panel2.Controls.Add(_btnSaveEquipment);
            _Panel2.Location = new Point(8, 19);
            _Panel2.Name = "Panel2";
            _Panel2.Size = new Size(648, 69);
            _Panel2.TabIndex = 2;
            // 
            // txtEquipmentTool
            // 
            _txtEquipmentTool.AcceptsReturn = true;
            _txtEquipmentTool.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEquipmentTool.Location = new Point(115, 4);
            _txtEquipmentTool.MaxLength = 255;
            _txtEquipmentTool.Multiline = true;
            _txtEquipmentTool.Name = "txtEquipmentTool";
            _txtEquipmentTool.ScrollBars = ScrollBars.Vertical;
            _txtEquipmentTool.Size = new Size(432, 56);
            _txtEquipmentTool.TabIndex = 1;
            _txtEquipmentTool.Tag = "Engineer.Name";
            // 
            // Label3
            // 
            _Label3.Location = new Point(3, 4);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(112, 20);
            _Label3.TabIndex = 55;
            _Label3.Text = @"Equipment\Tool";
            // 
            // btnSaveEquipment
            // 
            _btnSaveEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSaveEquipment.Location = new Point(560, 36);
            _btnSaveEquipment.Name = "btnSaveEquipment";
            _btnSaveEquipment.Size = new Size(75, 23);
            _btnSaveEquipment.TabIndex = 2;
            _btnSaveEquipment.Text = "Save";
            // 
            // btnDeleteEquipment
            // 
            _btnDeleteEquipment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnDeleteEquipment.Location = new Point(8, 585);
            _btnDeleteEquipment.Name = "btnDeleteEquipment";
            _btnDeleteEquipment.Size = new Size(75, 23);
            _btnDeleteEquipment.TabIndex = 4;
            _btnDeleteEquipment.Text = "Delete";
            // 
            // dgEquipment
            // 
            _dgEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgEquipment.DataMember = "";
            _dgEquipment.HeaderForeColor = SystemColors.ControlText;
            _dgEquipment.Location = new Point(8, 103);
            _dgEquipment.Name = "dgEquipment";
            _dgEquipment.Size = new Size(646, 474);
            _dgEquipment.TabIndex = 3;
            // 
            // UCVan
            // 
            Controls.Add(_tcVans);
            Name = "UCVan";
            Size = new Size(1216, 808);
            _tcVans.ResumeLayout(false);
            _tabDetails.ResumeLayout(false);
            _grpVan.ResumeLayout(false);
            _grpVan.PerformLayout();
            _tabStock.ResumeLayout(false);
            _tabStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgParts).EndInit();
            _GroupBox3.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvParts).EndInit();
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgProducts).EndInit();
            _tpWarehouses.ResumeLayout(false);
            _grpWarehouses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgWarehouses).EndInit();
            _tabEquipment.ResumeLayout(false);
            _grpVanEquipment.ResumeLayout(false);
            _Panel2.ResumeLayout(false);
            _Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEquipment).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupPartsDatagrid();
            SetupProductsDatagrid();
            SetupWarehousesDatagrid();
            SetupPartsDataGridView();
            DgSetupVanEquipment();
            dgParts.ReadOnly = false;
        }

        public object LoadedItem
        {
            get
            {
                return CurrentVan;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private int oldDepartment = 0;
        private Entity.Vans.Van _currentVan;

        public Entity.Vans.Van CurrentVan
        {
            get
            {
                return _currentVan;
            }

            set
            {
                _currentVan = value;
                if (_currentVan is null)
                {
                    _currentVan = new Entity.Vans.Van();
                    _currentVan.Exists = false;
                }

                if (_currentVan.Exists)
                {
                    btnEngineerHistory.Enabled = true;
                }
                else
                {
                    WarehousesDataView = App.DB.Warehouse.Warehouse_GetAll_For_Van2(0);
                    btnEngineerHistory.Enabled = false;
                }
            }
        }

        private DataView m_dTable = null;

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

        private DataView m_dTable2 = null;

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
                m_dTable2.AllowEdit = true;
                m_dTable2.AllowDelete = false;
                dgParts.DataSource = PartsDataView;
            }
        }

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

        private DataGridViewRow SelecteddgvPartDataRow
        {
            get
            {
                if (!(dgvParts.CurrentRow.Index == -1))
                {
                    return dgvParts.CurrentRow;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _WarehousesDataView = null;

        public DataView WarehousesDataView
        {
            get
            {
                return _WarehousesDataView;
            }

            set
            {
                _WarehousesDataView = value;
                _WarehousesDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString();
                _WarehousesDataView.AllowNew = false;
                _WarehousesDataView.AllowEdit = false;
                _WarehousesDataView.AllowDelete = false;
                dgWarehouses.DataSource = WarehousesDataView;
            }
        }

        private DataRow SelectedWarehouseDataRow
        {
            get
            {
                if (!(dgWarehouses.CurrentRowIndex == -1))
                {
                    return WarehousesDataView[dgWarehouses.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataTable m_dTable5 = null;

        public DataTable PartsDataGridView
        {
            get
            {
                return m_dTable5;
            }

            set
            {
                m_dTable5 = value;
                dgvParts.DataSource = value;
            }
        }

        private DataView _dvEquipment = null;

        public DataView DvEquipment
        {
            get
            {
                return _dvEquipment;
            }

            set
            {
                _dvEquipment = value;
                _dvEquipment.AllowNew = false;
                _dvEquipment.AllowEdit = false;
                _dvEquipment.AllowDelete = false;
                dgEquipment.DataSource = DvEquipment;
            }
        }

        private DataRow DrSelectedEquipment
        {
            get
            {
                if (!(dgEquipment.CurrentRowIndex == -1))
                {
                    return DvEquipment[dgEquipment.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void UCVan_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnEngineerHistory_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMEngineerHistory), true, new object[] { CurrentVan.VanID });
            Populate(CurrentVan.VanID);
        }

        private void dgvParts_DoubleClick(object sender, EventArgs e)
        {
            if (dgvParts.CurrentRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMPart), true, new object[] { dgvParts.CurrentRow.Cells[7].Value, true });
            PartsDataGridView = App.DB.PartTransaction.GetByVan2(CurrentVan.VanID, true, false, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPreferredSupplierID)));
        }

        private void btnCopyVan_Click(object sender, EventArgs e)
        {
            if (CurrentVan.Exists)
            {
                try
                {
                    var newVan = new Entity.Vans.Van();
                    Cursor = Cursors.WaitCursor;
                    newVan.IgnoreExceptionsOnSetMethods = true;
                    newVan.SetRegistration = Interaction.InputBox("Please enter new profile name:", "Profile");
                    newVan.SetNotes = txtNotes.Text.Trim();
                    newVan.SetPreferredSupplierID = Combo.get_GetSelectedItemValue(cboPreferredSupplierID);
                    if (CurrentVan.InsuranceDue == default)
                        CurrentVan.InsuranceDue = DateAndTime.Now;
                    if (CurrentVan.MOTDue == default)
                        CurrentVan.MOTDue = DateAndTime.Now;
                    if (CurrentVan.TaxDue == default)
                        CurrentVan.TaxDue = DateAndTime.Now;
                    if (CurrentVan.ServiceDue == default)
                        CurrentVan.ServiceDue = DateAndTime.Now;
                    var cV = new Entity.Vans.VanValidator();
                    cV.Validate(newVan);
                    newVan = App.DB.Van.CopyVan(newVan, CurrentVan.Registration, WarehousesDataView, false);
                    RecordsChanged?.Invoke(App.DB.Van.Van_GetAll(true), Entity.Sys.Enums.PageViewing.StockProfile, true, false, "");
                    StateChanged?.Invoke(CurrentVan.VanID);
                    App.MainForm.RefreshEntity(CurrentVan.VanID);
                    App.ShowMessage("Profile Copy Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ValidationException vex)
                {
                    string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                    msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                    App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                App.ShowMessage("Save current Profile before continuing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMergeProfile_Click(object sender, EventArgs e)
        {
            if (CurrentVan.Exists)
            {
                try
                {
                    var Van = new Entity.Vans.Van();
                    Cursor = Cursors.WaitCursor;
                    int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblVan));
                    if (!(ID == 0))
                    {
                        Van = App.DB.Van.Van_Get(ID);
                    }
                    else
                    {
                        return;
                    }

                    CurrentVan = App.DB.Van.MergeVan(Van, CurrentVan);  // hereer
                    RecordsChanged?.Invoke(App.DB.Van.Van_GetAll(true), Entity.Sys.Enums.PageViewing.Van, true, false, "");
                    StateChanged?.Invoke(CurrentVan.VanID);
                    App.MainForm.RefreshEntity(CurrentVan.VanID);
                    App.ShowMessage("Van Merge Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ValidationException vex)
                {
                    string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                    msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                    App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                App.ShowMessage("Save current van before continuing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgWarehouses_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgWarehouses.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgWarehouses.CurrentRowIndex = HitTestInfo.Row;
                }

                if (!(HitTestInfo.Column == 0))
                {
                    return;
                }

                if (SelectedWarehouseDataRow is null)
                {
                    return;
                }

                bool selected = !Entity.Sys.Helper.MakeBooleanValid(dgWarehouses[dgWarehouses.CurrentRowIndex, 0]);
                if (!selected)
                {
                    if (Conversions.ToBoolean(SelectedWarehouseDataRow["IsGasway"]))
                    {
                        App.ShowMessage("Gasway warehouse cannot be unselected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                dgWarehouses[dgWarehouses.CurrentRowIndex, 0] = selected;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentVan = App.DB.Van.Van_Get(ID);
            }

            CurrentVan.SetRegistration = CurrentVan.Registration.Split('*')[0].Trim();
            var dvCurrentEngineersOnVan = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(ID);
            var drActiveEngineers = dvCurrentEngineersOnVan.Table.Select("EnddateTime > '" + Conversions.ToString(DateTime.Now) + "' Or EnddateTime Is null");
            if (drActiveEngineers.Length < 1)
            {
                txtCurEngineer.Text = "<<No engineer is currently set/active to this profile>>";
                txtCurEngineerFleet.Text = "<<Engineer is not currently assigned to a van>>";
            }
            else
            {
                txtCurEngineer.Text = Conversions.ToString(drActiveEngineers[0]["Engineer"]);
                var dvCurrentEngineerFleet = App.DB.FleetVanEngineer.GetAll_ByEngineerID(Conversions.ToInteger(drActiveEngineers[0]["EngineerID"]));
                if (dvCurrentEngineerFleet?.Count > 0 == true)
                {
                    txtCurEngineerFleet.Text = Conversions.ToString(dvCurrentEngineerFleet[0]["Registration"]);
                }
                else
                {
                    txtCurEngineerFleet.Text = "<<Engineer is not currently assigned to a van>>";
                }
            }

            txtProfile.Text = CurrentVan.Registration;
            txtNotes.Text = CurrentVan.Notes;
            var argcombo = cboPreferredSupplierID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentVan.PreferredSupplierID.ToString());
            if (CurrentVan.ExcludeFromAutoReplenishment == true)
            {
                chkExcludeFromAutoStockReplen.Checked = true;
            }

            if (CurrentVan.UseContainerStock == true)
            {
                chkContainer.Checked = true;
            }

            chkSecondaryPrice.Checked = CurrentVan.SecondaryPrice;
            chkSecondaryPrice.Visible = Conversions.ToBoolean(Interaction.IIf(CurrentVan.EngineerVanID > 0, true, false));
            PartsDataGridView = App.DB.PartTransaction.GetByVan2(CurrentVan.VanID, true, false, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPreferredSupplierID)));
            WarehousesDataView = App.DB.Warehouse.Warehouse_GetAll_For_Van2(CurrentVan.VanID);
            DvEquipment = App.DB.VanEquipments.Get(CurrentVan.VanID);
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentVan.IgnoreExceptionsOnSetMethods = true;
                CurrentVan.SetRegistration = txtProfile.Text.Trim();
                CurrentVan.SetNotes = txtNotes.Text.Trim();
                CurrentVan.SetPreferredSupplierID = Combo.get_GetSelectedItemValue(cboPreferredSupplierID);
                if (CurrentVan.InsuranceDue == default)
                    CurrentVan.InsuranceDue = DateAndTime.Now;
                if (CurrentVan.MOTDue == default)
                    CurrentVan.MOTDue = DateAndTime.Now;
                if (CurrentVan.TaxDue == default)
                    CurrentVan.TaxDue = DateAndTime.Now;
                if (CurrentVan.ServiceDue == default)
                    CurrentVan.ServiceDue = DateAndTime.Now;
                if (CurrentVan.MileageLimit < 1)
                    CurrentVan.SetMileageLimit = 1;
                if (CurrentVan.PeriodValue < 1)
                    CurrentVan.SetPeriodValue = 1;
                if (CurrentVan.PeriodType < 1)
                    CurrentVan.SetPeriodType = 1;
                if (chkExcludeFromAutoStockReplen.Checked == true)
                {
                    CurrentVan.SetExcludeFromAutoReplenishment = true;
                }
                else
                {
                    CurrentVan.SetExcludeFromAutoReplenishment = false;
                }

                if (chkContainer.Checked == true)
                {
                    CurrentVan.SetUseContainerStock = true;
                }
                else
                {
                    CurrentVan.SetUseContainerStock = false;
                }

                CurrentVan.SecondaryPrice = chkSecondaryPrice.Checked;
                var cV = new Entity.Vans.VanValidator();
                cV.Validate(CurrentVan);
                if (CurrentVan.Exists)
                {
                    App.DB.Van.Update(CurrentVan, WarehousesDataView, false);
                }
                else
                {
                    CurrentVan = App.DB.Van.Insert(CurrentVan, "", WarehousesDataView, false);
                }

                App.MainForm.RefreshEntity(CurrentVan.VanID);
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
                App.ShowMessage(CurrentVan.Registration + " profile has been saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
        }

        public void SetupProductsDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgProducts);
            var tStyle = dgProducts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 100;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var ProductName = new DataGridLabelColumn();
            ProductName.Format = "";
            ProductName.FormatInfo = null;
            ProductName.HeaderText = "Description";
            ProductName.MappingName = "typemakemodel";
            ProductName.ReadOnly = true;
            ProductName.Width = 180;
            ProductName.NullText = "";
            tStyle.GridColumnStyles.Add(ProductName);
            var ProductNumber = new DataGridLabelColumn();
            ProductNumber.Format = "";
            ProductNumber.FormatInfo = null;
            ProductNumber.HeaderText = "GC Number";
            ProductNumber.MappingName = "ProductNumber";
            ProductNumber.ReadOnly = true;
            ProductNumber.Width = 140;
            ProductNumber.NullText = "";
            tStyle.GridColumnStyles.Add(ProductNumber);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 120;
            Amount.NullText = "";
            tStyle.GridColumnStyles.Add(Amount);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblProduct.ToString();
            dgProducts.TableStyles.Add(tStyle);
        }

        public void SetupPartsDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgParts);
            dgParts.ReadOnly = false;
            var tStyle = dgParts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.ReadOnly = false;
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 100;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var PartName = new DataGridLabelColumn();
            PartName.Format = "";
            PartName.FormatInfo = null;
            PartName.HeaderText = "Part Name";
            PartName.MappingName = "PartName";
            PartName.ReadOnly = true;
            PartName.Width = 180;
            PartName.NullText = "";
            tStyle.GridColumnStyles.Add(PartName);
            var PartNumber = new DataGridLabelColumn();
            PartNumber.Format = "";
            PartNumber.FormatInfo = null;
            PartNumber.HeaderText = "Part Number";
            PartNumber.MappingName = "PartNumber";
            PartNumber.ReadOnly = true;
            PartNumber.Width = 140;
            PartNumber.NullText = "";
            tStyle.GridColumnStyles.Add(PartNumber);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 120;
            Amount.NullText = "";
            tStyle.GridColumnStyles.Add(Amount);
            var MinQty = new DataGridEditableTextBoxColumn();
            MinQty.Format = "";
            MinQty.FormatInfo = null;
            MinQty.HeaderText = "MinQty";
            MinQty.MappingName = "Min";
            MinQty.ReadOnly = false;
            MinQty.Width = 120;
            MinQty.NullText = "";
            tStyle.GridColumnStyles.Add(MinQty);
            var MaxQty = new DataGridEditableTextBoxColumn();
            MaxQty.Format = "";
            MaxQty.FormatInfo = null;
            MaxQty.HeaderText = "MaxQty";
            MaxQty.MappingName = "Max";
            MaxQty.ReadOnly = false;
            MaxQty.Width = 120;
            MaxQty.NullText = "";
            tStyle.GridColumnStyles.Add(MaxQty);
            var MinMaxID = new DataGridLabelColumn();
            MinMaxID.Format = "";
            MinMaxID.FormatInfo = null;
            MinMaxID.HeaderText = "MinMaxID";
            MinMaxID.MappingName = "MinMaxID";
            MinMaxID.ReadOnly = true;
            MinMaxID.Width = 100;
            MinMaxID.NullText = "";
            tStyle.GridColumnStyles.Add(MinMaxID);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString();
            dgParts.TableStyles.Add(tStyle);
        }

        public void SetupWarehousesDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgWarehouses);
            var tStyle = dgWarehouses.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.ReadOnly = false;
            tStyle.AllowSorting = false;
            dgWarehouses.ReadOnly = false;
            dgWarehouses.AllowSorting = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 300;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString();
            dgWarehouses.TableStyles.Add(tStyle);
        }

        public void DgSetupVanEquipment()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgEquipment);
            var tStyle = dgEquipment.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var equipment = new DataGridLabelColumn();
            equipment.Format = "";
            equipment.FormatInfo = null;
            equipment.HeaderText = "Equipment/Tool";
            equipment.MappingName = "Equipment";
            equipment.ReadOnly = true;
            equipment.Width = 400;
            equipment.NullText = "";
            tStyle.GridColumnStyles.Add(equipment);
            var created = new DataGridLabelColumn();
            created.Format = "dd/MM/yyyy";
            created.FormatInfo = null;
            created.HeaderText = "Date Added";
            created.MappingName = "Created";
            created.ReadOnly = true;
            created.Width = 100;
            created.NullText = "";
            tStyle.GridColumnStyles.Add(created);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblVan.ToString();
            dgEquipment.TableStyles.Add(tStyle);
        }

        public void SetupPartsDataGridView()
        {
            Entity.Sys.Helper.SetUpDataGridView(dgvParts);
            dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParts.AutoGenerateColumns = false;
            dgvParts.Columns.Clear();
            dgvParts.EditMode = DataGridViewEditMode.EditOnEnter;
            var Location = new DataGridViewTextBoxColumn();
            Location.HeaderText = "Location";
            Location.FillWeight = 15;
            Location.DataPropertyName = "Location";
            Location.ReadOnly = true;
            Location.Visible = true;
            Location.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParts.Columns.Add(Location);
            var PartName = new DataGridViewTextBoxColumn();
            PartName.FillWeight = 60;
            PartName.HeaderText = "Part Name";
            PartName.DataPropertyName = "PartName";
            PartName.ReadOnly = true;
            PartName.Visible = true;
            PartName.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParts.Columns.Add(PartName);
            var PartNumber = new DataGridViewTextBoxColumn();
            PartNumber.HeaderText = "Part Number";
            PartNumber.DataPropertyName = "PartNumber";
            PartNumber.FillWeight = 25;
            PartNumber.ReadOnly = true;
            PartNumber.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParts.Columns.Add(PartNumber);
            var Amount = new DataGridViewTextBoxColumn();
            Amount.HeaderText = "Amount";
            Amount.DataPropertyName = "Amount";
            Amount.FillWeight = 15;
            Amount.ReadOnly = true;
            Amount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParts.Columns.Add(Amount);
            var MinQty = new DataGridViewTextBoxColumn();
            MinQty.HeaderText = "Min";
            MinQty.DataPropertyName = "Min";
            MinQty.FillWeight = 15;
            MinQty.ReadOnly = false;
            MinQty.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParts.Columns.Add(MinQty);
            var MaxQty = new DataGridViewTextBoxColumn();
            MaxQty.HeaderText = "Max";
            MaxQty.DataPropertyName = "Max";
            MaxQty.FillWeight = 16;
            MaxQty.ReadOnly = false;
            MaxQty.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParts.Columns.Add(MaxQty);
            var MinMaxID = new DataGridViewTextBoxColumn();
            MinMaxID.HeaderText = "MinMaxID";
            MinMaxID.DataPropertyName = "MinMaxID";
            MinMaxID.FillWeight = 1;
            MinMaxID.ReadOnly = true;
            MinMaxID.SortMode = DataGridViewColumnSortMode.Programmatic;
            MinMaxID.Visible = false;
            dgvParts.Columns.Add(MinMaxID);
            var PartID = new DataGridViewTextBoxColumn();
            PartID.HeaderText = "PartID";
            PartID.DataPropertyName = "PartID";
            // PartID.FillWeight = 75
            PartID.FillWeight = 1;
            PartID.ReadOnly = true;
            PartID.SortMode = DataGridViewColumnSortMode.Programmatic;
            // PartID.Visible = True
            PartID.Visible = false;
            dgvParts.Columns.Add(PartID);
            var LocationID = new DataGridViewTextBoxColumn();
            LocationID.HeaderText = "LocationID";
            LocationID.DataPropertyName = "LocationID";
            LocationID.FillWeight = 1;
            LocationID.ReadOnly = true;
            LocationID.SortMode = DataGridViewColumnSortMode.Programmatic;
            LocationID.Visible = false;
            dgvParts.Columns.Add(LocationID);
            var SPN = new DataGridViewTextBoxColumn();
            SPN.HeaderText = "SPN";
            SPN.DataPropertyName = "SPN";
            SPN.FillWeight = 25;
            SPN.ReadOnly = true;
            SPN.SortMode = DataGridViewColumnSortMode.Programmatic;
            SPN.Visible = true;
            dgvParts.Columns.Add(SPN);
            dgvParts.Sort(MinMaxID, System.ComponentModel.ListSortDirection.Descending);
        }

        private void dgvParts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (SelecteddgvPartDataRow is null)
            {
                return;
            }

            // update the min max record

            int RecordID = 0;
            int MinValue = 0;
            int MaxValue = 0;
            int PartID = 0;
            int LocationID = 0;
            RecordID = Conversions.ToInteger(SelecteddgvPartDataRow.Cells[6].Value);
            MinValue = Conversions.ToInteger(SelecteddgvPartDataRow.Cells[4].Value);
            MaxValue = Conversions.ToInteger(SelecteddgvPartDataRow.Cells[5].Value);
            PartID = Conversions.ToInteger(SelecteddgvPartDataRow.Cells[7].Value);
            LocationID = Conversions.ToInteger(SelecteddgvPartDataRow.Cells[8].Value);
            if (RecordID == 0)
            {
                int NewRecord = App.DB.PartTransaction.PartLocations_Insert2(PartID, LocationID, MinValue, MaxValue);
                SelecteddgvPartDataRow.Cells[6].Value = NewRecord;
            }
            else
            {
                App.DB.PartTransaction.UpdateMinMaxValues(RecordID, MinValue, MaxValue);
            }
        }

        private void btnAddPartVanStock_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int LocationID = 0; // 59 Adam Sutherland
            int PartID = 0; // 499059 15ISV
            int MinQty = 1;
            int MaxQty = 1;
            var locationdv = App.DB.Location.Locations_Get_ForVanReg_ActiveOnly(CurrentVan.Registration);

            // PartID = FindRecord(Entity.Sys.Enums.TableNames.tblPart)
            FRMFindPart dialogue1;
            dialogue1 = (FRMFindPart)App.checkIfExists(typeof(FRMFindPart).Name, true);
            if (dialogue1 is null)
            {
                dialogue1 = (FRMFindPart)Activator.CreateInstance(typeof(FRMFindPart));
            }
            // dialogue1.Icon = New Icon(dialogue1.GetType(), "Logo.ico")
            dialogue1.ShowInTaskbar = false;
            dialogue1.TableToSearch = Entity.Sys.Enums.TableNames.tblPartSupplier;
            dialogue1.ShowDialog();
            DataRow[] datarows;
            if (dialogue1.DialogResult == DialogResult.OK)
            {
                datarows = dialogue1.Datarows;
            }
            else
            {
                return;
            }

            dialogue1.Close();

            // WHICH LOCATION TO ASSIGN TO
            if (locationdv.Count > 0)
            {
                // LocationID = ShowForm(FRMPartSelectLocation, True, locationdv)
                FRMPartSelectLocation dialogue;
                dialogue = (FRMPartSelectLocation)App.checkIfExists(typeof(FRMPartSelectLocation).Name, true);
                if (dialogue is null)
                {
                    dialogue = (FRMPartSelectLocation)Activator.CreateInstance(typeof(FRMPartSelectLocation));
                }

                dialogue.Icon = new Icon(dialogue.GetType(), "Logo.ico");
                dialogue.ShowInTaskbar = false;
                dialogue.LocationsDataGridView = locationdv.ToTable();
                dialogue.ShowDialog();
                if (dialogue.DialogResult == DialogResult.OK)
                {
                    LocationID = dialogue.LocationID;
                }
                else
                {
                }

                dialogue.Close();
            }
            else if (locationdv.Count == 1)
            {
                LocationID = Conversions.ToInteger(locationdv.Table.Rows[0]["LocationID"]);
            }
            else
            {
                App.ShowMessage("No Locations available for this engineer, unable to proceed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (LocationID == 0)
            {
                App.ShowMessage("No Locations selected for this part, unable to proceed, please try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataRow dr in datarows)
            {
                PartID = Conversions.ToInteger(dr["PartID"]);
                bool partAlreadyPresent = PartsDataGridView.Select(string.Format("PartID = {0} and LocationID = {1}", dr["PartID"], LocationID)).Length > 0;
                if (partAlreadyPresent)
                {
                    App.ShowMessage(Conversions.ToString("A part has already been added and therefore cannot be added again. - " + dr["PartName"]), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continue;
                }

                var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                oPartTransaction.SetLocationID = LocationID; // row.Item("LocationID")
                oPartTransaction.SetAmount = 0;
                oPartTransaction.SetPartID = PartID; // row.Item("PartID")
                oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockAdjustment);
                App.DB.PartTransaction.Insert(oPartTransaction);
                App.DB.Part.Part_Locations_Insert(PartID, LocationID, MinQty, MaxQty);
            }

            if (datarows.Length > -1)
            {
                PartsDataGridView = App.DB.PartTransaction.GetByVan2(CurrentVan.VanID, true, false, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPreferredSupplierID)));
                var column = dgvParts.Columns[6];
                if (column is object)
                {
                    dgvParts.Sort(column, System.ComponentModel.ListSortDirection.Descending);
                }

                App.ShowMessage("Part(s) Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor = Cursors.Default;
        }

        private void btnDeletePartVanStock_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var rows = new ArrayList();
            int loops = 0;
            foreach (DataGridViewCell c in dgvParts.SelectedCells)
                rows.Add(c.OwningRow);
            rows.Reverse();
            foreach (DataGridViewRow i in rows)
            {
                int LocationID = 0; // 59 Adam Sutherland
                int PartID = 0; // 499059 15ISV
                if (Conversions.ToInteger(i.Cells[3].Value) > 0)
                {
                    App.ShowMessage("The part " + i.Cells[2].Value + " has positive stock, please process an adjustment before deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.Default;
                    return;
                }
                else
                {
                    PartID = Conversions.ToInteger(i.Cells[7].Value);
                    LocationID = Conversions.ToInteger(i.Cells[8].Value);
                }

                if (!(PartID == 0) & !(LocationID == 0))
                {
                    var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                    oPartTransaction.SetLocationID = LocationID; // row.Item("LocationID")
                    oPartTransaction.SetAmount = 0;
                    oPartTransaction.SetPartID = PartID; // row.Item("PartID")
                    oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockAdjustment);
                    App.DB.PartTransaction.Insert(oPartTransaction);
                    App.DB.PartTransaction.DeleteByPartAndLocation(PartID, LocationID);
                    App.DB.Part.Part_Locations_Delete(PartID, LocationID); // ' deletes part location matrix in tblpartlocations

                    // Dim column As DataGridViewColumn = Me.dgvParts.Columns.Item(6)
                    // If Not column Is Nothing Then
                    // Me.dgvParts.Sort(column, System.ComponentModel.ListSortDirection.Descending)
                    // End If

                }
            }

            PartsDataGridView = App.DB.PartTransaction.GetByVan2(CurrentVan.VanID, true, false, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPreferredSupplierID)));
            App.ShowMessage("Part(s) Removed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor = Cursors.Default;
        }

        private void dgvParts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var newColumn = dgvParts.Columns[e.ColumnIndex];
            var oldColumn = dgvParts.SortedColumn;
            System.ComponentModel.ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not currently sorted.
            if (oldColumn is object)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn && dgvParts.SortOrder == SortOrder.Ascending)
                {
                    direction = System.ComponentModel.ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = System.ComponentModel.ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = System.ComponentModel.ListSortDirection.Ascending;
            }

            // Sort the selected column.
            dgvParts.Sort(newColumn, direction);
            if (direction == System.ComponentModel.ListSortDirection.Ascending)
            {
                newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            }
            else
            {
                newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending;
            }
        }

        private void btnClearVanStockProfile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int PartAmount = 0;
            int MinValue = 0;
            int MaxValue = 0;
            int PartID = 0;
            int LocationID = 0;
            int recordID = 0;
            int DeletedCount = 0;
            Entity.Sys.Enums.SecuritySystemModules ssm;
            ssm = Entity.Sys.Enums.SecuritySystemModules.IT;
            Entity.Sys.Enums.SecuritySystemModules ssm2;
            ssm2 = Entity.Sys.Enums.SecuritySystemModules.AllFeatures;
            if (App.loggedInUser.HasAccessToModule(ssm) == true | App.loggedInUser.HasAccessToModule(ssm2) == true)
            {
                if (App.ShowMessage("Do you want to clear only the items with 0, 0, 0?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvParts.Rows)
                    {
                        PartAmount = Conversions.ToInteger(row.Cells[3].Value);
                        PartID = Conversions.ToInteger(row.Cells[7].Value);
                        LocationID = Conversions.ToInteger(row.Cells[8].Value);
                        recordID = Conversions.ToInteger(row.Cells[6].Value);
                        MinValue = Conversions.ToInteger(row.Cells[4].Value);
                        MaxValue = Conversions.ToInteger(row.Cells[5].Value);
                        if (PartAmount == 0 & MinValue == 0 & MaxValue == 0)
                        {
                            if (!(PartID == 0) & !(LocationID == 0))
                            {
                                var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                oPartTransaction.SetLocationID = LocationID; // row.Item("LocationID")
                                oPartTransaction.SetAmount = 0;
                                oPartTransaction.SetPartID = PartID; // row.Item("PartID")
                                oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockAdjustment);
                                App.DB.PartTransaction.Insert(oPartTransaction);
                                App.DB.PartTransaction.DeleteByPartAndLocation(PartID, LocationID);
                                App.DB.Part.Part_Locations_Delete(PartID, LocationID);
                                DeletedCount += 1;
                            }
                        }
                    }
                }
                else // clear all items
                {
                    foreach (DataGridViewRow row in dgvParts.Rows)
                    {
                        PartAmount = Conversions.ToInteger(row.Cells[3].Value);
                        PartID = Conversions.ToInteger(row.Cells[7].Value);
                        LocationID = Conversions.ToInteger(row.Cells[8].Value);
                        recordID = Conversions.ToInteger(row.Cells[6].Value);
                        MinValue = Conversions.ToInteger(row.Cells[4].Value);
                        MaxValue = Conversions.ToInteger(row.Cells[5].Value);
                        if (!(PartID == 0) & !(LocationID == 0))
                        {
                            var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                            oPartTransaction.SetLocationID = LocationID; // row.Item("LocationID")
                            oPartTransaction.SetAmount = 0;
                            oPartTransaction.SetPartID = PartID; // row.Item("PartID")
                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockAdjustment);
                            App.DB.PartTransaction.Insert(oPartTransaction);
                            App.DB.PartTransaction.DeleteByPartAndLocation(PartID, LocationID);
                            App.DB.Part.Part_Locations_Delete(PartID, LocationID);
                            DeletedCount += 1;
                        }
                    }
                }

                PartsDataGridView = App.DB.PartTransaction.GetByVan2(CurrentVan.VanID, true, false, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPreferredSupplierID)));
                App.ShowMessage("Parts Removed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                App.ShowMessage("This process can only be used by a member of IT or Barry Ellis", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor = Cursors.Default;
        }

        public void Export()
        {
            Entity.Sys.Enums.SecuritySystemModules ssm;
            ssm = Entity.Sys.Enums.SecuritySystemModules.IT;
            var exportData = new DataTable();
            exportData.Columns.Add("Location");
            exportData.Columns.Add("Part Name");
            exportData.Columns.Add("Part Number (MPN)");
            exportData.Columns.Add("Amount");
            exportData.Columns.Add("Min");
            exportData.Columns.Add("Max");
            if (App.loggedInUser.HasAccessToModule(ssm) == true)
            {
                exportData.Columns.Add("PartID");
            }

            exportData.Columns.Add("SPN");
            DataGridViewRow drRow;
            for (int itm = 0, loopTo = dgvParts.Rows.Count - 1; itm <= loopTo; itm++)
            {
                drRow = dgvParts.Rows[itm];
                DataRow newRw;
                newRw = exportData.NewRow();
                newRw["Location"] = drRow.Cells[0].Value;
                newRw["Part Name"] = drRow.Cells[1].Value;
                newRw["Part Number (MPN)"] = drRow.Cells[2].Value;
                newRw["Amount"] = drRow.Cells[3].Value;
                newRw["Min"] = drRow.Cells[4].Value;
                newRw["Max"] = drRow.Cells[5].Value;
                if (App.loggedInUser.HasAccessToModule(ssm) == true)
                {
                    newRw["PartID"] = drRow.Cells[7].Value;
                }

                newRw["SPN"] = drRow.Cells[9].Value;
                exportData.Rows.Add(newRw);

                // dgParts.UnSelect(itm)
            }

            var exporter = new Entity.Sys.Exporting(exportData, "Van Stock Profiles");
            exporter = null;
        }

        private void btnExportStockProfile_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnSaveEquipment_Click(object sender, EventArgs e)
        {
            string equipment = txtEquipmentTool.Text.Trim();
            int vanId = Entity.Sys.Helper.MakeIntegerValid(CurrentVan?.VanID);
            if (vanId == 0)
                return;
            if (string.IsNullOrWhiteSpace(equipment))
            {
                App.ShowMessage("Tool required!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            App.DB.VanEquipments.Insert(vanId, equipment);
            DvEquipment = App.DB.VanEquipments.Get(vanId);
        }

        private void btnDeleteEquipment_Click(object sender, EventArgs e)
        {
            int vanId = Entity.Sys.Helper.MakeIntegerValid(CurrentVan?.VanID);
            if (vanId == 0)
                return;
            if (DrSelectedEquipment is null)
                return;
            int id = Entity.Sys.Helper.MakeIntegerValid(DrSelectedEquipment["Id"]);
            App.DB.VanEquipments.Delete(id);
            DvEquipment = App.DB.VanEquipments.Get(vanId);
        }
    }
}