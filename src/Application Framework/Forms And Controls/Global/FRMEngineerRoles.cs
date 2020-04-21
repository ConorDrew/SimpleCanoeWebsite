using FSM.Entity.EngineerRoles;
using FSM.Entity.Engineers;
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
    public class FRMEngineerRole : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMEngineerRole() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMEngineerRole_Load;

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

        private TabControl _tabEngineerRole;

        internal TabControl tabEngineerRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabEngineerRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabEngineerRole != null)
                {
                }

                _tabEngineerRole = value;
                if (_tabEngineerRole != null)
                {
                }
            }
        }

        private TabPage _tabPageNewRole;

        internal TabPage tabPageNewRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabPageNewRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabPageNewRole != null)
                {
                }

                _tabPageNewRole = value;
                if (_tabPageNewRole != null)
                {
                }
            }
        }

        private GroupBox _grpEngineerRole;

        internal GroupBox grpEngineerRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineerRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineerRole != null)
                {
                }

                _grpEngineerRole = value;
                if (_grpEngineerRole != null)
                {
                }
            }
        }

        private NumericUpDown _nudHourlyCostToCompany;

        internal NumericUpDown nudHourlyCostToCompany
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _nudHourlyCostToCompany;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_nudHourlyCostToCompany != null)
                {
                }

                _nudHourlyCostToCompany = value;
                if (_nudHourlyCostToCompany != null)
                {
                }
            }
        }

        private TextBox _txtDescription;

        internal TextBox txtDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDescription != null)
                {
                }

                _txtDescription = value;
                if (_txtDescription != null)
                {
                }
            }
        }

        private Label _lblDescription;

        internal Label lblDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDescription != null)
                {
                }

                _lblDescription = value;
                if (_lblDescription != null)
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
                    _btnSave.Click -= btnSave_Click_1;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click_1;
                }
            }
        }

        private Label _lblName;

        internal Label lblName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblName != null)
                {
                }

                _lblName = value;
                if (_lblName != null)
                {
                }
            }
        }

        private Label _lblHourlyCostToCompany;

        internal Label lblHourlyCostToCompany
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblHourlyCostToCompany;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblHourlyCostToCompany != null)
                {
                }

                _lblHourlyCostToCompany = value;
                if (_lblHourlyCostToCompany != null)
                {
                }
            }
        }

        private TextBox _txtName;

        internal TextBox txtName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
                {
                }
            }
        }

        private GroupBox _grpAssignEngineerRole;

        internal GroupBox grpAssignEngineerRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAssignEngineerRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAssignEngineerRole != null)
                {
                }

                _grpAssignEngineerRole = value;
                if (_grpAssignEngineerRole != null)
                {
                }
            }
        }

        private DataGrid _dgrdEngineerInRoleList;

        internal DataGrid dgrdEngineerInRoleList
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgrdEngineerInRoleList;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgrdEngineerInRoleList != null)
                {
                    _dgrdEngineerInRoleList.Click -= dgrdEngineerInRoleList_Click;
                }

                _dgrdEngineerInRoleList = value;
                if (_dgrdEngineerInRoleList != null)
                {
                    _dgrdEngineerInRoleList.Click += dgrdEngineerInRoleList_Click;
                }
            }
        }

        private Button _btnAssign;

        internal Button btnAssign
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAssign;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAssign != null)
                {
                    _btnAssign.Click -= btnAssign_Click;
                }

                _btnAssign = value;
                if (_btnAssign != null)
                {
                    _btnAssign.Click += btnAssign_Click;
                }
            }
        }

        private ComboBox _cboEngineerRole;

        internal ComboBox cboEngineerRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineerRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineerRole != null)
                {
                }

                _cboEngineerRole = value;
                if (_cboEngineerRole != null)
                {
                }
            }
        }

        private Label _lblEngRole;

        internal Label lblEngRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngRole != null)
                {
                }

                _lblEngRole = value;
                if (_lblEngRole != null)
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

        private TextBox _txtRoleId;

        internal TextBox txtRoleId
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRoleId;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRoleId != null)
                {
                }

                _txtRoleId = value;
                if (_txtRoleId != null)
                {
                }
            }
        }

        private TextBox _txtEngineerName;

        internal TextBox txtEngineerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineerName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineerName != null)
                {
                }

                _txtEngineerName = value;
                if (_txtEngineerName != null)
                {
                }
            }
        }

        private TextBox _txtEngineerId;

        internal TextBox txtEngineerId
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineerId;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineerId != null)
                {
                }

                _txtEngineerId = value;
                if (_txtEngineerId != null)
                {
                }
            }
        }

        private GroupBox _grpEngRoles;

        internal GroupBox grpEngRoles
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngRoles;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngRoles != null)
                {
                }

                _grpEngRoles = value;
                if (_grpEngRoles != null)
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

        private DataGrid _dgrdEngineerRoles;

        internal DataGrid dgrdEngineerRoles
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgrdEngineerRoles;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgrdEngineerRoles != null)
                {
                    _dgrdEngineerRoles.Click -= dgrdEngineerRoles_Click;
                }

                _dgrdEngineerRoles = value;
                if (_dgrdEngineerRoles != null)
                {
                    _dgrdEngineerRoles.Click += dgrdEngineerRoles_Click;
                }
            }
        }

        private GroupBox _grpEngineersAssignedToRole;

        internal GroupBox grpEngineersAssignedToRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineersAssignedToRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineersAssignedToRole != null)
                {
                }

                _grpEngineersAssignedToRole = value;
                if (_grpEngineersAssignedToRole != null)
                {
                }
            }
        }

        private Button _btnUnassign;

        internal Button btnUnassign
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUnassign;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUnassign != null)
                {
                    _btnUnassign.Click -= btnUnassign_Click;
                }

                _btnUnassign = value;
                if (_btnUnassign != null)
                {
                    _btnUnassign.Click += btnUnassign_Click;
                }
            }
        }

        private TextBox _txtHourlyCostToCompany;

        internal TextBox txtHourlyCostToCompany
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHourlyCostToCompany;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHourlyCostToCompany != null)
                {
                    _txtHourlyCostToCompany.KeyPress -= txtHourlyCostToCompany_KeyPress;
                }

                _txtHourlyCostToCompany = value;
                if (_txtHourlyCostToCompany != null)
                {
                    _txtHourlyCostToCompany.KeyPress += txtHourlyCostToCompany_KeyPress;
                }
            }
        }

        private Button _btnfindEngineer;

        internal Button btnfindEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnfindEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnfindEngineer != null)
                {
                    _btnfindEngineer.Click -= btnfindEngineer_Click;
                }

                _btnfindEngineer = value;
                if (_btnfindEngineer != null)
                {
                    _btnfindEngineer.Click += btnfindEngineer_Click;
                }
            }
        }

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

        private TabPage _tabPageAssignRole;

        internal TabPage tabPageAssignRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabPageAssignRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabPageAssignRole != null)
                {
                }

                _tabPageAssignRole = value;
                if (_tabPageAssignRole != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMEngineerRole));
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _Panel1 = new Panel();
            _tabEngineerRole = new TabControl();
            _tabPageNewRole = new TabPage();
            _grpEngineerRole = new GroupBox();
            _txtHourlyCostToCompany = new TextBox();
            _txtHourlyCostToCompany.KeyPress += new KeyPressEventHandler(txtHourlyCostToCompany_KeyPress);
            _grpEngRoles = new GroupBox();
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _dgrdEngineerRoles = new DataGrid();
            _dgrdEngineerRoles.Click += new EventHandler(dgrdEngineerRoles_Click);
            _txtRoleId = new TextBox();
            _nudHourlyCostToCompany = new NumericUpDown();
            _txtDescription = new TextBox();
            _lblDescription = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click_1);
            _lblName = new Label();
            _lblHourlyCostToCompany = new Label();
            _txtName = new TextBox();
            _tabPageAssignRole = new TabPage();
            _grpAssignEngineerRole = new GroupBox();
            _grpEngineersAssignedToRole = new GroupBox();
            _btnUnassign = new Button();
            _btnUnassign.Click += new EventHandler(btnUnassign_Click);
            _dgrdEngineerInRoleList = new DataGrid();
            _dgrdEngineerInRoleList.Click += new EventHandler(dgrdEngineerInRoleList_Click);
            _txtEngineerId = new TextBox();
            _txtEngineerName = new TextBox();
            _btnAssign = new Button();
            _btnAssign.Click += new EventHandler(btnAssign_Click);
            _cboEngineerRole = new ComboBox();
            _lblEngRole = new Label();
            _lblEngineer = new Label();
            _btnfindEngineer = new Button();
            _btnfindEngineer.Click += new EventHandler(btnfindEngineer_Click);
            _txtEngineer = new TextBox();
            _Panel1.SuspendLayout();
            _tabEngineerRole.SuspendLayout();
            _tabPageNewRole.SuspendLayout();
            _grpEngineerRole.SuspendLayout();
            _grpEngRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgrdEngineerRoles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_nudHourlyCostToCompany).BeginInit();
            _tabPageAssignRole.SuspendLayout();
            _grpAssignEngineerRole.SuspendLayout();
            _grpEngineersAssignedToRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgrdEngineerInRoleList).BeginInit();
            SuspendLayout();
            //
            // btnClose
            //
            _btnClose.Location = new Point(8, 10);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(75, 28);
            _btnClose.TabIndex = 15;
            _btnClose.Text = "Close";
            _btnClose.UseVisualStyleBackColor = true;
            //
            // Panel1
            //
            _Panel1.BackColor = Color.WhiteSmoke;
            _Panel1.Controls.Add(_btnClose);
            _Panel1.Dock = DockStyle.Bottom;
            _Panel1.Location = new Point(0, 565);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(1462, 50);
            _Panel1.TabIndex = 16;
            //
            // tabEngineerRole
            //
            _tabEngineerRole.Controls.Add(_tabPageNewRole);
            _tabEngineerRole.Controls.Add(_tabPageAssignRole);
            _tabEngineerRole.Dock = DockStyle.Fill;
            _tabEngineerRole.Location = new Point(0, 0);
            _tabEngineerRole.Name = "tabEngineerRole";
            _tabEngineerRole.SelectedIndex = 0;
            _tabEngineerRole.Size = new Size(1462, 565);
            _tabEngineerRole.TabIndex = 17;
            //
            // tabPageNewRole
            //
            _tabPageNewRole.Controls.Add(_grpEngineerRole);
            _tabPageNewRole.Location = new Point(4, 22);
            _tabPageNewRole.Name = "tabPageNewRole";
            _tabPageNewRole.Padding = new Padding(3);
            _tabPageNewRole.Size = new Size(1454, 539);
            _tabPageNewRole.TabIndex = 0;
            _tabPageNewRole.Text = "New Engineer Role";
            _tabPageNewRole.UseVisualStyleBackColor = true;
            //
            // grpEngineerRole
            //
            _grpEngineerRole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineerRole.Controls.Add(_txtHourlyCostToCompany);
            _grpEngineerRole.Controls.Add(_grpEngRoles);
            _grpEngineerRole.Controls.Add(_txtRoleId);
            _grpEngineerRole.Controls.Add(_nudHourlyCostToCompany);
            _grpEngineerRole.Controls.Add(_txtDescription);
            _grpEngineerRole.Controls.Add(_lblDescription);
            _grpEngineerRole.Controls.Add(_btnSave);
            _grpEngineerRole.Controls.Add(_lblName);
            _grpEngineerRole.Controls.Add(_lblHourlyCostToCompany);
            _grpEngineerRole.Controls.Add(_txtName);
            _grpEngineerRole.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _grpEngineerRole.Location = new Point(16, 21);
            _grpEngineerRole.Name = "grpEngineerRole";
            _grpEngineerRole.Size = new Size(1430, 512);
            _grpEngineerRole.TabIndex = 13;
            _grpEngineerRole.TabStop = false;
            _grpEngineerRole.Text = "Enter New Role Details";
            //
            // txtHourlyCostToCompany
            //
            _txtHourlyCostToCompany.Location = new Point(96, 56);
            _txtHourlyCostToCompany.Name = "txtHourlyCostToCompany";
            _txtHourlyCostToCompany.Size = new Size(100, 21);
            _txtHourlyCostToCompany.TabIndex = 20;
            //
            // grpEngRoles
            //
            _grpEngRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngRoles.Controls.Add(_btnDelete);
            _grpEngRoles.Controls.Add(_btnAddNew);
            _grpEngRoles.Controls.Add(_dgrdEngineerRoles);
            _grpEngRoles.Location = new Point(96, 180);
            _grpEngRoles.Name = "grpEngRoles";
            _grpEngRoles.Size = new Size(1316, 309);
            _grpEngRoles.TabIndex = 19;
            _grpEngRoles.TabStop = false;
            _grpEngRoles.Text = "Engineer Roles";
            //
            // btnDelete
            //
            _btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDelete.Location = new Point(1221, 280);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(75, 23);
            _btnDelete.TabIndex = 21;
            _btnDelete.Text = "Delete";
            _btnDelete.UseVisualStyleBackColor = true;
            //
            // btnAddNew
            //
            _btnAddNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddNew.Location = new Point(1140, 280);
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.Size = new Size(75, 23);
            _btnAddNew.TabIndex = 20;
            _btnAddNew.Text = "Add New";
            _btnAddNew.UseVisualStyleBackColor = true;
            //
            // dgrdEngineerRoles
            //
            _dgrdEngineerRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgrdEngineerRoles.DataMember = "";
            _dgrdEngineerRoles.HeaderForeColor = SystemColors.ControlText;
            _dgrdEngineerRoles.Location = new Point(18, 20);
            _dgrdEngineerRoles.Name = "dgrdEngineerRoles";
            _dgrdEngineerRoles.Size = new Size(1277, 254);
            _dgrdEngineerRoles.TabIndex = 19;
            //
            // txtRoleId
            //
            _txtRoleId.Location = new Point(96, 151);
            _txtRoleId.Name = "txtRoleId";
            _txtRoleId.Size = new Size(68, 21);
            _txtRoleId.TabIndex = 16;
            _txtRoleId.Visible = false;
            //
            // nudHourlyCostToCompany
            //
            _nudHourlyCostToCompany.DecimalPlaces = 2;
            _nudHourlyCostToCompany.Location = new Point(215, 56);
            _nudHourlyCostToCompany.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            _nudHourlyCostToCompany.Name = "nudHourlyCostToCompany";
            _nudHourlyCostToCompany.Size = new Size(120, 21);
            _nudHourlyCostToCompany.TabIndex = 6;
            _nudHourlyCostToCompany.Visible = false;
            //
            // txtDescription
            //
            _txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtDescription.Location = new Point(96, 83);
            _txtDescription.Multiline = true;
            _txtDescription.Name = "txtDescription";
            _txtDescription.ScrollBars = ScrollBars.Vertical;
            _txtDescription.Size = new Size(1316, 62);
            _txtDescription.TabIndex = 5;
            //
            // lblDescription
            //
            _lblDescription.AutoSize = true;
            _lblDescription.Location = new Point(13, 92);
            _lblDescription.Name = "lblDescription";
            _lblDescription.Size = new Size(71, 13);
            _lblDescription.TabIndex = 4;
            _lblDescription.Text = "Description";
            //
            // btnSave
            //
            _btnSave.AccessibleDescription = "";
            _btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSave.Cursor = Cursors.Hand;
            _btnSave.Location = new Point(1356, 151);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 23);
            _btnSave.TabIndex = 3;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            //
            // lblName
            //
            _lblName.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblName.Location = new Point(13, 32);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(80, 16);
            _lblName.TabIndex = 1;
            _lblName.Text = "Role Name";
            //
            // lblHourlyCostToCompany
            //
            _lblHourlyCostToCompany.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblHourlyCostToCompany.Location = new Point(13, 56);
            _lblHourlyCostToCompany.Name = "lblHourlyCostToCompany";
            _lblHourlyCostToCompany.Size = new Size(80, 29);
            _lblHourlyCostToCompany.TabIndex = 2;
            _lblHourlyCostToCompany.Text = "Hourly Cost To Company";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtName.Location = new Point(96, 29);
            _txtName.MaxLength = 50;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(1316, 21);
            _txtName.TabIndex = 1;
            //
            // tabPageAssignRole
            //
            _tabPageAssignRole.Controls.Add(_grpAssignEngineerRole);
            _tabPageAssignRole.Location = new Point(4, 22);
            _tabPageAssignRole.Name = "tabPageAssignRole";
            _tabPageAssignRole.Padding = new Padding(3);
            _tabPageAssignRole.Size = new Size(1454, 539);
            _tabPageAssignRole.TabIndex = 1;
            _tabPageAssignRole.Text = "Assign Engineer Role";
            _tabPageAssignRole.UseVisualStyleBackColor = true;
            //
            // grpAssignEngineerRole
            //
            _grpAssignEngineerRole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAssignEngineerRole.BackColor = Color.White;
            _grpAssignEngineerRole.Controls.Add(_btnfindEngineer);
            _grpAssignEngineerRole.Controls.Add(_txtEngineer);
            _grpAssignEngineerRole.Controls.Add(_grpEngineersAssignedToRole);
            _grpAssignEngineerRole.Controls.Add(_txtEngineerId);
            _grpAssignEngineerRole.Controls.Add(_txtEngineerName);
            _grpAssignEngineerRole.Controls.Add(_btnAssign);
            _grpAssignEngineerRole.Controls.Add(_cboEngineerRole);
            _grpAssignEngineerRole.Controls.Add(_lblEngRole);
            _grpAssignEngineerRole.Controls.Add(_lblEngineer);
            _grpAssignEngineerRole.Location = new Point(17, 23);
            _grpAssignEngineerRole.Name = "grpAssignEngineerRole";
            _grpAssignEngineerRole.Size = new Size(1421, 510);
            _grpAssignEngineerRole.TabIndex = 15;
            _grpAssignEngineerRole.TabStop = false;
            _grpAssignEngineerRole.Text = "Assign Engineer Role";
            //
            // grpEngineersAssignedToRole
            //
            _grpEngineersAssignedToRole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineersAssignedToRole.Controls.Add(_btnUnassign);
            _grpEngineersAssignedToRole.Controls.Add(_dgrdEngineerInRoleList);
            _grpEngineersAssignedToRole.Location = new Point(113, 112);
            _grpEngineersAssignedToRole.Name = "grpEngineersAssignedToRole";
            _grpEngineersAssignedToRole.Size = new Size(1281, 377);
            _grpEngineersAssignedToRole.TabIndex = 78;
            _grpEngineersAssignedToRole.TabStop = false;
            _grpEngineersAssignedToRole.Text = "Engineers Assigned To Role";
            //
            // btnUnassign
            //
            _btnUnassign.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnUnassign.Location = new Point(1200, 348);
            _btnUnassign.Name = "btnUnassign";
            _btnUnassign.Size = new Size(75, 23);
            _btnUnassign.TabIndex = 76;
            _btnUnassign.Text = "Unassign";
            _btnUnassign.UseVisualStyleBackColor = true;
            //
            // dgrdEngineerInRoleList
            //
            _dgrdEngineerInRoleList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgrdEngineerInRoleList.DataMember = "";
            _dgrdEngineerInRoleList.HeaderForeColor = SystemColors.ControlText;
            _dgrdEngineerInRoleList.Location = new Point(11, 29);
            _dgrdEngineerInRoleList.Name = "dgrdEngineerInRoleList";
            _dgrdEngineerInRoleList.Size = new Size(1264, 313);
            _dgrdEngineerInRoleList.TabIndex = 75;
            //
            // txtEngineerId
            //
            _txtEngineerId.Location = new Point(113, 83);
            _txtEngineerId.Name = "txtEngineerId";
            _txtEngineerId.Size = new Size(100, 21);
            _txtEngineerId.TabIndex = 77;
            _txtEngineerId.Visible = false;
            //
            // txtEngineerName
            //
            _txtEngineerName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEngineerName.Location = new Point(228, 83);
            _txtEngineerName.Name = "txtEngineerName";
            _txtEngineerName.Size = new Size(100, 21);
            _txtEngineerName.TabIndex = 76;
            _txtEngineerName.Text = "--Please Select--";
            _txtEngineerName.Visible = false;
            //
            // btnAssign
            //
            _btnAssign.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAssign.Location = new Point(1319, 83);
            _btnAssign.Name = "btnAssign";
            _btnAssign.Size = new Size(75, 23);
            _btnAssign.TabIndex = 74;
            _btnAssign.Text = "Assign";
            _btnAssign.UseVisualStyleBackColor = true;
            //
            // cboEngineerRole
            //
            _cboEngineerRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboEngineerRole.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEngineerRole.FormattingEnabled = true;
            _cboEngineerRole.Location = new Point(113, 56);
            _cboEngineerRole.Name = "cboEngineerRole";
            _cboEngineerRole.Size = new Size(1281, 21);
            _cboEngineerRole.TabIndex = 73;
            //
            // lblEngRole
            //
            _lblEngRole.AutoSize = true;
            _lblEngRole.Location = new Point(21, 58);
            _lblEngRole.Name = "lblEngRole";
            _lblEngRole.Size = new Size(86, 13);
            _lblEngRole.TabIndex = 72;
            _lblEngRole.Text = "Engineer Role";
            //
            // lblEngineer
            //
            _lblEngineer.AutoSize = true;
            _lblEngineer.Location = new Point(21, 35);
            _lblEngineer.Name = "lblEngineer";
            _lblEngineer.Size = new Size(57, 13);
            _lblEngineer.TabIndex = 71;
            _lblEngineer.Text = "Engineer";
            //
            // btnfindEngineer
            //
            _btnfindEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnfindEngineer.BackColor = Color.White;
            _btnfindEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindEngineer.Location = new Point(1362, 29);
            _btnfindEngineer.Name = "btnfindEngineer";
            _btnfindEngineer.Size = new Size(32, 23);
            _btnfindEngineer.TabIndex = 80;
            _btnfindEngineer.Text = "...";
            _btnfindEngineer.UseVisualStyleBackColor = false;
            //
            // txtEngineer
            //
            _txtEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtEngineer.Location = new Point(113, 29);
            _txtEngineer.Name = "txtEngineer";
            _txtEngineer.ReadOnly = true;
            _txtEngineer.Size = new Size(1243, 21);
            _txtEngineer.TabIndex = 79;
            //
            // FRMEngineerRole
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1462, 615);
            Controls.Add(_tabEngineerRole);
            Controls.Add(_Panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(0, 208);
            Name = "FRMEngineerRole";
            Text = "Engineer Roles";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_Panel1, 0);
            Controls.SetChildIndex(_tabEngineerRole, 0);
            _Panel1.ResumeLayout(false);
            _tabEngineerRole.ResumeLayout(false);
            _tabPageNewRole.ResumeLayout(false);
            _grpEngineerRole.ResumeLayout(false);
            _grpEngineerRole.PerformLayout();
            _grpEngRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgrdEngineerRoles).EndInit();
            ((System.ComponentModel.ISupportInitialize)_nudHourlyCostToCompany).EndInit();
            _tabPageAssignRole.ResumeLayout(false);
            _grpAssignEngineerRole.ResumeLayout(false);
            _grpAssignEngineerRole.PerformLayout();
            _grpEngineersAssignedToRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgrdEngineerInRoleList).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _dvEngineerRole;

        private DataView DvEngineerRole
        {
            get
            {
                return _dvEngineerRole;
            }

            set
            {
                _dvEngineerRole = value;
                _dvEngineerRole.Table.TableName = "EngineerRole";
                dgrdEngineerRoles.DataSource = _dvEngineerRole;
            }
        }

        private DataView _dvCurrentEngineerRoles;

        public DataView CurrentEngineerRoles
        {
            get
            {
                return _dvCurrentEngineerRoles;
            }

            set
            {
                _dvCurrentEngineerRoles = value;
                _dvCurrentEngineerRoles.Table.TableName = "EngineerRole";
                _dvCurrentEngineerRoles.AllowNew = false;
                _dvCurrentEngineerRoles.AllowEdit = false;
                _dvCurrentEngineerRoles.AllowDelete = false;
                dgrdEngineerRoles.DataSource = CurrentEngineerRoles;
            }
        }

        private DataRow SelectedEngineeRoleDataRow
        {
            get
            {
                if (!(dgrdEngineerRoles.CurrentRowIndex == -1))
                {
                    return CurrentEngineerRoles[dgrdEngineerRoles.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _dvEngineerInRoleList;

        private DataView DvEngineerInRoleList
        {
            get
            {
                return _dvEngineerInRoleList;
            }

            set
            {
                _dvEngineerInRoleList = value;
                _dvEngineerInRoleList.Table.TableName = "EngineerInRoleList";
                dgrdEngineerInRoleList.DataSource = _dvEngineerInRoleList;
            }
        }

        private DataView _dvCurrentEngineerRoleLinks;

        public DataView CurrentEngineerRoleLinks
        {
            get
            {
                return _dvCurrentEngineerRoleLinks;
            }

            set
            {
                _dvCurrentEngineerRoleLinks = value;
                _dvCurrentEngineerRoleLinks.Table.TableName = "EngineerInRoleList";
                _dvCurrentEngineerRoleLinks.AllowNew = false;
                _dvCurrentEngineerRoleLinks.AllowEdit = false;
                _dvCurrentEngineerRoleLinks.AllowDelete = false;
                dgrdEngineerInRoleList.DataSource = CurrentEngineerRoleLinks;
            }
        }

        private DataRow SelectedEngineerRoleLinkDataRow
        {
            get
            {
                if (!(dgrdEngineerInRoleList.CurrentRowIndex == -1))
                {
                    return CurrentEngineerRoleLinks[dgrdEngineerInRoleList.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Engineer _engineer;

        public Engineer Engineer
        {
            get
            {
                return _engineer;
            }

            set
            {
                _engineer = value;
                if (_engineer is object)
                {
                    txtEngineer.Text = Engineer.Name;
                }
                else
                {
                    txtEngineer.Text = "<Not Set>";
                }
            }
        }

        private void FRMEngineerRole_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
            SetupDgrdEngineerRoles();
            PopulateEngineerRole();
            SetupdgrdEngineerInRoleList();
            PopulateEngineerInRoleList();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            var answer = App.ShowMessage("Are you sure you want to apply changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No)
            {
                return;
            }

            if ((txtRoleId.Text ?? "") == (string.Empty ?? ""))
            {
                SaveEngineerRole();
            }
            else
            {
                UpdateEngineerRole();
            }

            btnAddNew_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void dgrdEngineerRoles_Click(object sender, EventArgs e)
        {
            if (SelectedEngineeRoleDataRow is null)
            {
                return;
            }

            txtRoleId.Text = Conversions.ToString(SelectedEngineeRoleDataRow["Id"]);
            txtName.Text = Conversions.ToString(SelectedEngineeRoleDataRow["Name"]);
            txtHourlyCostToCompany.Text = Conversions.ToString(SelectedEngineeRoleDataRow["HourlyCostToCompany"]);
            txtDescription.Text = Conversions.ToString(SelectedEngineeRoleDataRow["Description"]);
        }

        private void dgrdEngineerInRoleList_Click(object sender, EventArgs e)
        {
            if (SelectedEngineerRoleLinkDataRow is null)
            {
                return;
            }
            // ''' set comboboxes, cboEngineer & cboEngineerRole
            int engineerID = Helper.MakeIntegerValid(SelectedEngineerRoleLinkDataRow["EngineerID"]);
            int roleId = Helper.MakeIntegerValid(SelectedEngineerRoleLinkDataRow["RoleId"]);
            string engineerName = Helper.MakeStringValid(SelectedEngineerRoleLinkDataRow["EngineerName"]);
            var dtEngineers = App.DB.EngineerRole.GetEngineersNotAssignedToRole().Table;
            var dtSelectedEngineer = new DataTable();
            dtSelectedEngineer.Columns.Add(new DataColumn("EngineerID", typeof(int)));
            dtSelectedEngineer.Columns.Add(new DataColumn("Name", typeof(string)));
            dtSelectedEngineer.Rows.Add(engineerID, engineerName);
            dtEngineers.Merge(dtSelectedEngineer);
            var argcombo = cboEngineerRole;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, roleId.ToString());
            Engineer = App.DB.Engineer.Engineer_Get(engineerID);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtRoleId.Text = "";
            txtName.Text = "";
            txtHourlyCostToCompany.Text = "";
            txtDescription.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedEngineeRoleDataRow is null)
            {
                App.ShowMessage("Please select row to be deleted and try again.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var answer = App.ShowMessage("Are you sure you want to delete selected engineer role?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No)
            {
                return;
            }

            try
            {
                int engineerRoleId = Helper.MakeIntegerValid(SelectedEngineeRoleDataRow["Id"]);
                int success = App.DB.EngineerRole.Delete(engineerRoleId);
                if (success > 0)
                {
                    PopulateEngineerRole();
                }
                else
                {
                    App.ShowMessage("The role you are trying to delete is assigned to engineer(s) and therefore cannot be deleted.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("The operation failed. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (Engineer is null)
                {
                    App.ShowMessage("Please select an engineer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int engineerRoleId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboEngineerRole));
                string newRoleName = Combo.get_GetSelectedItemDescription(cboEngineerRole);
                var engineerRole = App.DB.EngineerRole.GetEngineerRoleId(Engineer.EngineerID);
                string changeRoleMessage;
                if ((newRoleName ?? "") == (string.Empty ?? ""))
                {
                    changeRoleMessage = "Are you sure you want to change current role from " + engineerRole.Name + " to not assigned?";
                }
                else
                {
                    changeRoleMessage = "Are you sure you want to change current role from " + engineerRole.Name + " to " + newRoleName + " ?";
                }

                if (engineerRole.Id > 0)
                {
                    var answer = App.ShowMessage(changeRoleMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.No)
                    {
                        return;
                    }
                }

                if (App.DB.EngineerRole.AssignEngineerToRole(Engineer.EngineerID, engineerRoleId))
                {
                    PopulateEngineerInRoleList();
                }
                else
                {
                    App.ShowMessage("Assign role operation failed due to database issue. Please try again later.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Assign role operation failed. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnassign_Click(object sender, EventArgs e)
        {
            try
            {
                if (Engineer is null)
                    return;
                int engineerRoleId = 0;
                var engineerRole = App.DB.EngineerRole.GetEngineerRoleId(Engineer.EngineerID);
                string changeRoleMessage;
                changeRoleMessage = "Are you sure you want to change current role from " + engineerRole.Name + " to not assigned?";
                var answer = App.ShowMessage(changeRoleMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.No)
                {
                    return;
                }

                if (App.DB.EngineerRole.AssignEngineerToRole(Engineer.EngineerID, engineerRoleId))
                {
                    PopulateEngineerInRoleList();
                }
                else
                {
                    App.ShowMessage("Assign role operation failed due to database issue. Please try again later.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Unssign role operation failed. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHourlyCostToCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !(Conversions.ToString(e.KeyChar) == ".") && !char.IsControl(e.KeyChar))
            {
                e.KeyChar = Conversions.ToChar("");
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void PopulateEngineerRole()
        {
            var dt = Helper.ToDataTable(App.DB.EngineerRole.GetAll());
            var dv = new DataView(dt);
            DvEngineerRole = dv;
            CurrentEngineerRoles = dv;
        }

        private void PopulateEngineerInRoleList()
        {
            Engineer = null;
            var argc = cboEngineerRole;
            Combo.SetUpCombo(ref argc, App.DB.EngineerRole.GetLookupData().Table, "Id", "Name", Enums.ComboValues.Please_Select);
            var dt = Helper.ToDataTable(App.DB.EngineerRole.GetEngineersAssignedToRole());
            var dv = new DataView(dt);
            DvEngineerInRoleList = dv;
            CurrentEngineerRoleLinks = dv;
        }

        public void SaveEngineerRole()
        {
            try
            {
                var engineerRole = new EngineerRole();
                engineerRole.Name = txtName.Text.Trim();
                engineerRole.HourlyCostToCompany = Conversions.ToDecimal(Helper.MakeDoubleValid(Conversions.ToDecimal(Conversion.Val(txtHourlyCostToCompany.Text))));
                engineerRole.Description = txtDescription.Text.Trim();
                engineerRole = App.DB.EngineerRole.Insert(engineerRole);
                if (engineerRole.Id > 0)
                {
                    PopulateEngineerRole();
                    PopulateEngineerInRoleList();
                }
                else
                {
                    App.ShowMessage("Role " + engineerRole.Name + " exists already. Please select role to edit.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("The operation failed. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateEngineerRole()
        {
            try
            {
                var engineerRole = new EngineerRole();
                engineerRole.Id = Conversions.ToInteger(txtRoleId.Text.Trim());
                engineerRole.Name = txtName.Text.Trim();
                engineerRole.HourlyCostToCompany = Conversions.ToDecimal(Helper.MakeDoubleValid(txtHourlyCostToCompany.Text));
                engineerRole.Description = txtDescription.Text.Trim();
                int success = App.DB.EngineerRole.Update(engineerRole);
                if (success == engineerRole.Id)
                {
                    PopulateEngineerRole();
                }
                else
                {
                    App.ShowMessage("The operation failed. Please try again later!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("The operation failed. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupDgrdEngineerRoles()
        {
            Helper.SetUpDataGrid(dgrdEngineerRoles);
            var dgts = dgrdEngineerRoles.TableStyles[0];
            var roleId = new DataGridJobTypeColumn();
            roleId.Format = "";
            roleId.FormatInfo = null;
            roleId.HeaderText = "Role Id";
            roleId.MappingName = "Id";
            roleId.ReadOnly = true;
            roleId.Width = 0;
            roleId.NullText = "";
            dgts.GridColumnStyles.Add(roleId);
            var roleName = new DataGridJobTypeColumn();
            roleName.Format = "";
            roleName.FormatInfo = null;
            roleName.HeaderText = "Role Name";
            roleName.MappingName = "Name";
            roleName.ReadOnly = true;
            roleName.Width = 300;
            roleName.NullText = "";
            dgts.GridColumnStyles.Add(roleName);
            var rate = new DataGridJobTypeColumn();
            rate.Format = "C";
            rate.FormatInfo = null;
            rate.HeaderText = "Hourly Cost To Company";
            rate.MappingName = "HourlyCostToCompany";
            rate.ReadOnly = true;
            rate.Width = 150;
            rate.NullText = "";
            dgts.GridColumnStyles.Add(rate);
            var description = new DataGridJobTypeColumn();
            description.Format = "";
            description.FormatInfo = null;
            description.HeaderText = "Description";
            description.MappingName = "Description";
            description.ReadOnly = true;
            description.Width = 600;
            description.NullText = "";
            dgts.GridColumnStyles.Add(description);
            dgts.ReadOnly = true;
            dgts.MappingName = "EngineerRole";
            dgrdEngineerRoles.TableStyles.Add(dgts);
        }

        private void SetupdgrdEngineerInRoleList()
        {
            Helper.SetUpDataGrid(dgrdEngineerInRoleList);
            var dgts = dgrdEngineerInRoleList.TableStyles[0];
            var engineerID = new DataGridJobTypeColumn();
            engineerID.Format = "";
            engineerID.FormatInfo = null;
            engineerID.HeaderText = "Engineer ID";
            engineerID.MappingName = "EngineerID";
            engineerID.ReadOnly = true;
            engineerID.Width = 1;
            engineerID.NullText = "";
            dgts.GridColumnStyles.Add(engineerID);
            var roleId = new DataGridJobTypeColumn();
            roleId.Format = "";
            roleId.FormatInfo = null;
            roleId.HeaderText = "Role Id";
            roleId.MappingName = "RoleId";
            roleId.ReadOnly = true;
            roleId.Width = 1;
            roleId.NullText = "";
            dgts.GridColumnStyles.Add(roleId);
            var engineerName = new DataGridJobTypeColumn();
            engineerName.Format = "";
            engineerName.FormatInfo = null;
            engineerName.HeaderText = "Engineer Name";
            engineerName.MappingName = "EngineerName";
            engineerName.ReadOnly = true;
            engineerName.Width = 160;
            engineerName.NullText = "";
            dgts.GridColumnStyles.Add(engineerName);
            var engineerRole = new DataGridJobTypeColumn();
            engineerRole.Format = "";
            engineerRole.FormatInfo = null;
            engineerRole.HeaderText = "Role Name";
            engineerRole.MappingName = "EngineerRole";
            engineerRole.ReadOnly = true;
            engineerRole.Width = 160;
            engineerRole.NullText = "";
            dgts.GridColumnStyles.Add(engineerRole);
            var description = new DataGridJobTypeColumn();
            description.Format = "";
            description.FormatInfo = null;
            description.HeaderText = "Description";
            description.MappingName = "Description";
            description.ReadOnly = true;
            description.Width = 600;
            description.NullText = "";
            dgts.GridColumnStyles.Add(description);
            dgts.ReadOnly = true;
            dgts.MappingName = "EngineerInRoleList";
            dgrdEngineerInRoleList.TableStyles.Add(dgts);
        }

        private void btnfindEngineer_Click(object sender, EventArgs e)
        {
            FindEngineer();
        }

        private void FindEngineer()
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineerRole));
            if (!(ID == 0))
            {
                Engineer = App.DB.Engineer.Engineer_Get(ID);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}