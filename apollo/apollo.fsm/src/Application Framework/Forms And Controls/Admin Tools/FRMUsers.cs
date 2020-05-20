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
    public class FRMUsers : FRMBaseForm, IForm
    {
        public FRMUsers() : base()
        {
            base.Load += FRMUsers_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            btnPopulateNewSecurityModules.Visible = false;

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

        private GroupBox _grpDetails;

        internal GroupBox grpDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpDetails != null)
                {
                }

                _grpDetails = value;
                if (_grpDetails != null)
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

        private TextBox _txtFullName;

        internal TextBox txtFullName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFullName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFullName != null)
                {
                }

                _txtFullName = value;
                if (_txtFullName != null)
                {
                }
            }
        }

        private CheckBox _chkEnabled;

        internal CheckBox chkEnabled
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkEnabled;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkEnabled != null)
                {
                }

                _chkEnabled = value;
                if (_chkEnabled != null)
                {
                }
            }
        }

        private TextBox _txtUserName;

        internal TextBox txtUserName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtUserName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtUserName != null)
                {
                }

                _txtUserName = value;
                if (_txtUserName != null)
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
                }

                _txtPassword = value;
                if (_txtPassword != null)
                {
                }
            }
        }

        private TextBox _txtConfirm;

        internal TextBox txtConfirm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtConfirm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtConfirm != null)
                {
                }

                _txtConfirm = value;
                if (_txtConfirm != null)
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

        private GroupBox _grpUsers;

        private DataGrid _dgUsers;

        internal DataGrid dgUsers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgUsers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgUsers != null)
                {
                    _dgUsers.Click -= dgUsers_Click;
                    _dgUsers.CurrentCellChanged -= dgUsers_Click;
                }

                _dgUsers = value;
                if (_dgUsers != null)
                {
                    _dgUsers.Click += dgUsers_Click;
                    _dgUsers.CurrentCellChanged += dgUsers_Click;
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

        private DataGrid _dgSecurityUserModules;

        internal DataGrid dgSecurityUserModules
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSecurityUserModules;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSecurityUserModules != null)
                {
                    _dgSecurityUserModules.Click -= dgSecurityUserModules_Click;
                }

                _dgSecurityUserModules = value;
                if (_dgSecurityUserModules != null)
                {
                    _dgSecurityUserModules.Click += dgSecurityUserModules_Click;
                }
            }
        }

        private CheckBox _chkAdmin;

        internal CheckBox chkAdmin
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkAdmin;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkAdmin != null)
                {
                }

                _chkAdmin = value;
                if (_chkAdmin != null)
                {
                }
            }
        }

        private Button _btnPopulateNewSecurityModules;

        internal Button btnPopulateNewSecurityModules
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPopulateNewSecurityModules;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPopulateNewSecurityModules != null)
                {
                    _btnPopulateNewSecurityModules.Click -= btnPopulateNewSecurityModules_Click;
                }

                _btnPopulateNewSecurityModules = value;
                if (_btnPopulateNewSecurityModules != null)
                {
                    _btnPopulateNewSecurityModules.Click += btnPopulateNewSecurityModules_Click;
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

        private TextBox _txtEmailAddress;

        internal TextBox txtEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEmailAddress != null)
                {
                }

                _txtEmailAddress = value;
                if (_txtEmailAddress != null)
                {
                }
            }
        }

        private CheckBox _chkSDV;

        internal CheckBox chkSDV
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSDV;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSDV != null)
                {
                }

                _chkSDV = value;
                if (_chkSDV != null)
                {
                }
            }
        }

        private ComboBox _cboDEG;

        internal ComboBox cboDEG
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDEG;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDEG != null)
                {
                }

                _cboDEG = value;
                if (_cboDEG != null)
                {
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

        private GroupBox _grpUserRegions;

        internal GroupBox grpUserRegions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpUserRegions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpUserRegions != null)
                {
                }

                _grpUserRegions = value;
                if (_grpUserRegions != null)
                {
                }
            }
        }

        private DataGrid _dgUserRegions;

        internal DataGrid dgUserRegions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgUserRegions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgUserRegions != null)
                {
                    _dgUserRegions.Click -= dgUserRegions_Click;
                }

                _dgUserRegions = value;
                if (_dgUserRegions != null)
                {
                    _dgUserRegions.Click += dgUserRegions_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpUsers = new System.Windows.Forms.GroupBox();
            this._dgUsers = new System.Windows.Forms.DataGrid();
            this._btnAddNew = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._grpDetails = new System.Windows.Forms.GroupBox();
            this._cboDEG = new System.Windows.Forms.ComboBox();
            this._Label7 = new System.Windows.Forms.Label();
            this._chkSDV = new System.Windows.Forms.CheckBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._txtEmailAddress = new System.Windows.Forms.TextBox();
            this._chkAdmin = new System.Windows.Forms.CheckBox();
            this._btnReset = new System.Windows.Forms.Button();
            this._txtConfirm = new System.Windows.Forms.TextBox();
            this._txtPassword = new System.Windows.Forms.TextBox();
            this._txtUserName = new System.Windows.Forms.TextBox();
            this._chkEnabled = new System.Windows.Forms.CheckBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtFullName = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._dgSecurityUserModules = new System.Windows.Forms.DataGrid();
            this._btnPopulateNewSecurityModules = new System.Windows.Forms.Button();
            this._grpUserRegions = new System.Windows.Forms.GroupBox();
            this._dgUserRegions = new System.Windows.Forms.DataGrid();
            this._grpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgUsers)).BeginInit();
            this._grpDetails.SuspendLayout();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSecurityUserModules)).BeginInit();
            this._grpUserRegions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgUserRegions)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpUsers
            // 
            this._grpUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpUsers.Controls.Add(this._dgUsers);
            this._grpUsers.Controls.Add(this._btnAddNew);
            this._grpUsers.Controls.Add(this._btnDelete);
            this._grpUsers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpUsers.Location = new System.Drawing.Point(8, 12);
            this._grpUsers.Name = "_grpUsers";
            this._grpUsers.Size = new System.Drawing.Size(312, 575);
            this._grpUsers.TabIndex = 6;
            this._grpUsers.TabStop = false;
            this._grpUsers.Text = "Users";
            // 
            // _dgUsers
            // 
            this._dgUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgUsers.DataMember = "";
            this._dgUsers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgUsers.Location = new System.Drawing.Point(8, 57);
            this._dgUsers.Name = "_dgUsers";
            this._dgUsers.Size = new System.Drawing.Size(296, 510);
            this._dgUsers.TabIndex = 2;
            this._dgUsers.CurrentCellChanged += new System.EventHandler(this.dgUsers_Click);
            this._dgUsers.Click += new System.EventHandler(this.dgUsers_Click);
            // 
            // _btnAddNew
            // 
            this._btnAddNew.AccessibleDescription = "Add new user";
            this._btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddNew.Location = new System.Drawing.Point(8, 24);
            this._btnAddNew.Name = "_btnAddNew";
            this._btnAddNew.Size = new System.Drawing.Size(48, 23);
            this._btnAddNew.TabIndex = 1;
            this._btnAddNew.Text = "New";
            this._btnAddNew.UseVisualStyleBackColor = true;
            this._btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.AccessibleDescription = "Delete user";
            this._btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDelete.Location = new System.Drawing.Point(62, 24);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(59, 23);
            this._btnDelete.TabIndex = 3;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // _grpDetails
            // 
            this._grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpDetails.Controls.Add(this._cboDEG);
            this._grpDetails.Controls.Add(this._Label7);
            this._grpDetails.Controls.Add(this._chkSDV);
            this._grpDetails.Controls.Add(this._Label6);
            this._grpDetails.Controls.Add(this._txtEmailAddress);
            this._grpDetails.Controls.Add(this._chkAdmin);
            this._grpDetails.Controls.Add(this._btnReset);
            this._grpDetails.Controls.Add(this._txtConfirm);
            this._grpDetails.Controls.Add(this._txtPassword);
            this._grpDetails.Controls.Add(this._txtUserName);
            this._grpDetails.Controls.Add(this._chkEnabled);
            this._grpDetails.Controls.Add(this._Label4);
            this._grpDetails.Controls.Add(this._Label3);
            this._grpDetails.Controls.Add(this._Label1);
            this._grpDetails.Controls.Add(this._txtFullName);
            this._grpDetails.Controls.Add(this._Label2);
            this._grpDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpDetails.Location = new System.Drawing.Point(328, 12);
            this._grpDetails.Name = "_grpDetails";
            this._grpDetails.Size = new System.Drawing.Size(457, 272);
            this._grpDetails.TabIndex = 8;
            this._grpDetails.TabStop = false;
            this._grpDetails.Text = "Details";
            // 
            // _cboDEG
            // 
            this._cboDEG.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboDEG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDEG.Location = new System.Drawing.Point(127, 208);
            this._cboDEG.Name = "_cboDEG";
            this._cboDEG.Size = new System.Drawing.Size(324, 21);
            this._cboDEG.TabIndex = 20;
            // 
            // _Label7
            // 
            this._Label7.AutoSize = true;
            this._Label7.Location = new System.Drawing.Point(9, 211);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(112, 13);
            this._Label7.TabIndex = 19;
            this._Label7.Text = "Default Eng Group";
            // 
            // _chkSDV
            // 
            this._chkSDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkSDV.Location = new System.Drawing.Point(300, 150);
            this._chkSDV.Name = "_chkSDV";
            this._chkSDV.Size = new System.Drawing.Size(149, 24);
            this._chkSDV.TabIndex = 17;
            this._chkSDV.Text = "Scheduler Day View";
            // 
            // _Label6
            // 
            this._Label6.AutoSize = true;
            this._Label6.Location = new System.Drawing.Point(9, 184);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(38, 13);
            this._Label6.TabIndex = 16;
            this._Label6.Text = "Email";
            // 
            // _txtEmailAddress
            // 
            this._txtEmailAddress.Location = new System.Drawing.Point(127, 181);
            this._txtEmailAddress.Name = "_txtEmailAddress";
            this._txtEmailAddress.Size = new System.Drawing.Size(322, 21);
            this._txtEmailAddress.TabIndex = 15;
            // 
            // _chkAdmin
            // 
            this._chkAdmin.Location = new System.Drawing.Point(182, 151);
            this._chkAdmin.Name = "_chkAdmin";
            this._chkAdmin.Size = new System.Drawing.Size(63, 24);
            this._chkAdmin.TabIndex = 14;
            this._chkAdmin.Text = "Admin";
            // 
            // _btnReset
            // 
            this._btnReset.AccessibleDescription = "Reset the users password";
            this._btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnReset.Location = new System.Drawing.Point(399, 86);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(48, 23);
            this._btnReset.TabIndex = 7;
            this._btnReset.Text = "Reset";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _txtConfirm
            // 
            this._txtConfirm.Location = new System.Drawing.Point(127, 120);
            this._txtConfirm.MaxLength = 50;
            this._txtConfirm.Name = "_txtConfirm";
            this._txtConfirm.PasswordChar = '*';
            this._txtConfirm.Size = new System.Drawing.Size(322, 21);
            this._txtConfirm.TabIndex = 8;
            // 
            // _txtPassword
            // 
            this._txtPassword.Location = new System.Drawing.Point(127, 88);
            this._txtPassword.MaxLength = 50;
            this._txtPassword.Name = "_txtPassword";
            this._txtPassword.PasswordChar = '*';
            this._txtPassword.Size = new System.Drawing.Size(266, 21);
            this._txtPassword.TabIndex = 6;
            // 
            // _txtUserName
            // 
            this._txtUserName.Location = new System.Drawing.Point(127, 56);
            this._txtUserName.MaxLength = 50;
            this._txtUserName.Name = "_txtUserName";
            this._txtUserName.Size = new System.Drawing.Size(322, 21);
            this._txtUserName.TabIndex = 5;
            // 
            // _chkEnabled
            // 
            this._chkEnabled.Checked = true;
            this._chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkEnabled.Location = new System.Drawing.Point(12, 150);
            this._chkEnabled.Name = "_chkEnabled";
            this._chkEnabled.Size = new System.Drawing.Size(113, 24);
            this._chkEnabled.TabIndex = 10;
            this._chkEnabled.Text = "Logon Enabled";
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(8, 120);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(64, 16);
            this._Label4.TabIndex = 10;
            this._Label4.Text = "Confirm";
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(8, 88);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(64, 16);
            this._Label3.TabIndex = 9;
            this._Label3.Text = "Password";
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 56);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(74, 16);
            this._Label1.TabIndex = 8;
            this._Label1.Text = "Username";
            // 
            // _txtFullName
            // 
            this._txtFullName.Location = new System.Drawing.Point(127, 24);
            this._txtFullName.MaxLength = 255;
            this._txtFullName.Name = "_txtFullName";
            this._txtFullName.Size = new System.Drawing.Size(322, 21);
            this._txtFullName.TabIndex = 4;
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(8, 24);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(64, 16);
            this._Label2.TabIndex = 5;
            this._Label2.Text = "Full Name";
            // 
            // _btnSave
            // 
            this._btnSave.AccessibleDescription = "Save user details";
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSave.Location = new System.Drawing.Point(737, 564);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(48, 23);
            this._btnSave.TabIndex = 11;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._dgSecurityUserModules);
            this._GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._GroupBox1.Location = new System.Drawing.Point(326, 504);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(459, 54);
            this._GroupBox1.TabIndex = 12;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Module Access";
            // 
            // _dgSecurityUserModules
            // 
            this._dgSecurityUserModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgSecurityUserModules.DataMember = "";
            this._dgSecurityUserModules.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgSecurityUserModules.Location = new System.Drawing.Point(8, 20);
            this._dgSecurityUserModules.Name = "_dgSecurityUserModules";
            this._dgSecurityUserModules.Size = new System.Drawing.Size(443, 26);
            this._dgSecurityUserModules.TabIndex = 2;
            this._dgSecurityUserModules.Click += new System.EventHandler(this.dgSecurityUserModules_Click);
            // 
            // _btnPopulateNewSecurityModules
            // 
            this._btnPopulateNewSecurityModules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPopulateNewSecurityModules.Location = new System.Drawing.Point(536, 564);
            this._btnPopulateNewSecurityModules.Name = "_btnPopulateNewSecurityModules";
            this._btnPopulateNewSecurityModules.Size = new System.Drawing.Size(195, 23);
            this._btnPopulateNewSecurityModules.TabIndex = 13;
            this._btnPopulateNewSecurityModules.Text = "Populate New Security Modules";
            this._btnPopulateNewSecurityModules.UseVisualStyleBackColor = true;
            this._btnPopulateNewSecurityModules.Click += new System.EventHandler(this.btnPopulateNewSecurityModules_Click);
            // 
            // _grpUserRegions
            // 
            this._grpUserRegions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpUserRegions.Controls.Add(this._dgUserRegions);
            this._grpUserRegions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpUserRegions.Location = new System.Drawing.Point(328, 290);
            this._grpUserRegions.Name = "_grpUserRegions";
            this._grpUserRegions.Size = new System.Drawing.Size(459, 208);
            this._grpUserRegions.TabIndex = 13;
            this._grpUserRegions.TabStop = false;
            this._grpUserRegions.Text = "User Regions";
            // 
            // _dgUserRegions
            // 
            this._dgUserRegions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgUserRegions.DataMember = "";
            this._dgUserRegions.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgUserRegions.Location = new System.Drawing.Point(8, 20);
            this._dgUserRegions.Name = "_dgUserRegions";
            this._dgUserRegions.Size = new System.Drawing.Size(443, 180);
            this._dgUserRegions.TabIndex = 2;
            this._dgUserRegions.Click += new System.EventHandler(this.dgUserRegions_Click);
            // 
            // FRMUsers
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(793, 593);
            this.Controls.Add(this._grpUserRegions);
            this.Controls.Add(this._btnPopulateNewSecurityModules);
            this.Controls.Add(this._GroupBox1);
            this.Controls.Add(this._grpDetails);
            this.Controls.Add(this._grpUsers);
            this.Controls.Add(this._btnSave);
            this.MinimumSize = new System.Drawing.Size(800, 576);
            this.Name = "FRMUsers";
            this.Text = "Users";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgUsers)).EndInit();
            this._grpDetails.ResumeLayout(false);
            this._grpDetails.PerformLayout();
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgSecurityUserModules)).EndInit();
            this._grpUserRegions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgUserRegions)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            if (Conversions.ToString(get_GetParameter(0)).Trim().Length > 0)
            {
                Users = App.DB.User.User_Search(Conversions.ToString(get_GetParameter(0)));
            }
            else
            {
                Users = App.DB.User.GetAll();
            }

            SetupUsersAndEngineersDataGrid();
            SetupUserModulesDatagrid();
            SetupUserRegionsDatagrid();
            var argc = cboDEG;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.EngineerGroup).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
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

        private Entity.Sys.Enums.FormState _pageState;

        private Entity.Sys.Enums.FormState PageState
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

        private DataView _dvUsers;

        private DataView Users
        {
            get
            {
                return _dvUsers;
            }

            set
            {
                _dvUsers = value;
                _dvUsers.Table.TableName = Entity.Sys.Enums.TableNames.tblUser.ToString();
                _dvUsers.AllowNew = false;
                _dvUsers.AllowEdit = false;
                _dvUsers.AllowDelete = false;
                dgUsers.DataSource = Users;
                SetUpPageState(Entity.Sys.Enums.FormState.Load);
                UserModules = null;
                UserRegions = null;
            }
        }

        private DataRow SelectedUserDataRow
        {
            get
            {
                if (!(dgUsers.CurrentRowIndex == -1))
                {
                    return Users[dgUsers.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void SetupUsersAndEngineersDataGrid()
        {
            var tStyle = dgUsers.TableStyles[0];
            var fullName = new DataGridLabelColumn();
            fullName.Format = "";
            fullName.FormatInfo = null;
            fullName.HeaderText = "Name";
            fullName.MappingName = "FullName";
            fullName.ReadOnly = true;
            fullName.Width = 125;
            fullName.NullText = "";
            tStyle.GridColumnStyles.Add(fullName);
            var userName = new DataGridLabelColumn();
            userName.Format = "";
            userName.FormatInfo = null;
            userName.HeaderText = "Username";
            userName.MappingName = "UserName";
            userName.ReadOnly = true;
            userName.Width = 125;
            userName.NullText = "";
            tStyle.GridColumnStyles.Add(userName);
            var pdaID = new DataGridLabelColumn();
            pdaID.Format = "";
            pdaID.FormatInfo = null;
            pdaID.HeaderText = "PDA";
            pdaID.MappingName = "PDAID";
            pdaID.ReadOnly = true;
            pdaID.Width = 55;
            pdaID.NullText = "";
            tStyle.GridColumnStyles.Add(pdaID);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblUser.ToString();
            dgUsers.TableStyles.Add(tStyle);
        }

        public void SetupUserRegionsDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgUserRegions);
            var tStyle = dgUserRegions.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.ReadOnly = false;
            tStyle.AllowSorting = false;
            dgUserRegions.ReadOnly = false;
            dgUserRegions.AllowSorting = false;
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
            var Name2 = new DataGridLabelColumn();
            Name2.Format = "";
            Name2.FormatInfo = null;
            Name2.HeaderText = "";
            Name2.MappingName = "ManagerID";
            Name2.ReadOnly = true;
            Name2.Width = 1;
            Name2.NullText = "";
            tStyle.GridColumnStyles.Add(Name2);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblRegion.ToString();
            dgUserRegions.TableStyles.Add(tStyle);
        }

        private void FRMUsers_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SetUpPageState(Entity.Sys.Enums.FormState.Insert);
        }

        private void dgUsers_Click(object sender, EventArgs e)
        {
            try
            {
                SetUpPageState(Entity.Sys.Enums.FormState.Update);
                if (SelectedUserDataRow is null)
                {
                    SetUpPageState(Entity.Sys.Enums.FormState.Load);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Details cannot load : " + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetPassword();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnPopulateNewSecurityModules_Click(object sender, EventArgs e)
        {
            PopulateNewSecurityModules();
        }

        private void SetUpPageState(Entity.Sys.Enums.FormState state)
        {
            Entity.Sys.Helper.ClearGroupBox(grpDetails);
            switch (state)
            {
                case Entity.Sys.Enums.FormState.Load:
                    {
                        btnAddNew.Enabled = true;
                        btnDelete.Enabled = false;
                        btnReset.Enabled = false;
                        grpDetails.Enabled = false;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Insert:
                    {
                        btnAddNew.Enabled = true;
                        btnDelete.Enabled = false;
                        btnReset.Enabled = false;
                        grpDetails.Enabled = true;
                        txtPassword.ReadOnly = false;
                        txtConfirm.ReadOnly = false;
                        chkEnabled.Checked = true;
                        chkAdmin.Checked = false;
                        UserModules = App.DB.User.GetSecurityUserModulesDefaults();
                        UserRegions = App.DB.User.GetUserRegionsDefaults();
                        break;
                    }

                case Entity.Sys.Enums.FormState.Update:
                    {
                        btnAddNew.Enabled = true;
                        btnDelete.Enabled = true;
                        btnReset.Enabled = true;
                        grpDetails.Enabled = true;
                        txtPassword.ReadOnly = true;
                        txtConfirm.ReadOnly = true;
                        PopulateDetails();
                        break;
                    }
            }

            PageState = state;
        }

        private void PopulateDetails()
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedUserDataRow["UserID"], App.TheSystem.Configuration.SuperAdminID, false) & App.loggedInUser.UserID != App.TheSystem.Configuration.SuperAdminID))
            {
                App.ShowMessage("You may not view this data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetUpPageState(Entity.Sys.Enums.FormState.Load);
                return;
            }
            else
            {
                txtFullName.Text = Entity.Sys.Helper.MakeStringValid(SelectedUserDataRow["Fullname"]);
                txtUserName.Text = Entity.Sys.Helper.MakeStringValid(SelectedUserDataRow["UserName"]);
                txtPassword.Text = "**********";
                txtConfirm.Text = "**********";
                chkEnabled.Checked = Entity.Sys.Helper.MakeBooleanValid(SelectedUserDataRow["Enabled"]);
                chkAdmin.Checked = Entity.Sys.Helper.MakeBooleanValid(SelectedUserDataRow["Admin"]);
                chkSDV.Checked = Entity.Sys.Helper.MakeBooleanValid(SelectedUserDataRow["SchedulerDayView"]);
                if (!Information.IsDBNull(SelectedUserDataRow["DefaultSchedulerEngineerGroup"]))
                {
                    var argcombo = cboDEG;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(SelectedUserDataRow["DefaultSchedulerEngineerGroup"]));
                }

                var argcombo1 = cboDEG;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, Entity.Sys.Helper.MakeIntegerValid(SelectedUserDataRow["DefaultSchedulerEngineerGroup"]).ToString());
                txtEmailAddress.Text = Entity.Sys.Helper.MakeStringValid(SelectedUserDataRow["EmailAddress"]);
                var u = App.DB.User.Get(Conversions.ToInteger(SelectedUserDataRow["UserID"]));
                UserModules = u.SecurityUserModules;
                UserRegions = App.DB.User.GetUserRegions(Conversions.ToInteger(SelectedUserDataRow["UserID"]));
            }
        }

        private void Save()
        {
            var user = new Entity.Users.User();
            user.IgnoreExceptionsOnSetMethods = true;
            user.SetFullname = txtFullName.Text.Trim();
            user.SetUsername = txtUserName.Text.Trim();
            user.SetPassword = txtPassword.Text.Trim();
            user.SetEnabled = chkEnabled.Checked;
            user.SetAdmin = chkAdmin.Checked;
            user.SetEmailAddress = txtEmailAddress.Text.Trim();
            user.SetSchedulerDayView = chkSDV.Checked;
            user.SetDefaultEngineerGroup = Combo.get_GetSelectedItemValue(cboDEG);
            if (PageState == Entity.Sys.Enums.FormState.Update)
            {
                user.SetUserID = Entity.Sys.Helper.MakeIntegerValid(SelectedUserDataRow["UserID"]);
            }

            user.SecurityUserModules = UserModules;
            var validator = new Entity.Users.UserValidator();
            try
            {
                validator.Validate(user);
                var switchExpr = PageState;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.FormState.Insert:
                        {
                            user.SetUserID = App.DB.User.Insert(user);
                            break;
                        }

                    case Entity.Sys.Enums.FormState.Update:
                        {
                            App.DB.User.Update(user);
                            break;
                        }
                }

                var diff = UserRegions.Table.GetChanges();
                if (diff is object)
                {
                    string changes = string.Empty;
                    bool addAnd = false;
                    foreach (DataRow dr in diff.Rows)
                    {
                        if (addAnd)
                            changes += " and ";
                        changes += Entity.Sys.Helper.MakeStringValid(dr["Name"]) + " set to " + Entity.Sys.Helper.MakeStringValid(dr["Tick"]);
                        addAnd = true;
                    }

                    if (!string.IsNullOrEmpty(changes))
                        App.DB.User.UserAccessAudit_Insert(user.UserID, changes);
                }

                App.DB.User.UserRegions_Delete(user.UserID);
                foreach (DataRow dr in UserRegions.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Tick"], true, false)))
                    {
                        App.DB.User.UserRegions_Insert(user.UserID, Conversions.ToInteger(dr["ManagerID"]));
                    }
                }

                Users = App.DB.User.GetAll();
            }
            catch (ValidationException ex)
            {
                App.ShowMessage(validator.CriticalMessagesString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error Saving : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetPassword()
        {
            try
            {
                if (SelectedUserDataRow is object)
                {
                    if ((int)App.ShowMessage(Conversions.ToString("Are you sure you want to reset the password for \"" + SelectedUserDataRow["FullName"] + "\"?"), MessageBoxButtons.YesNo, (MessageBoxIcon)MsgBoxStyle.Question) == (int)MsgBoxResult.Yes)
                    {
                        App.DB.User.UpdatePassword(Conversions.ToInteger(SelectedUserDataRow["UserID"]), "password", true);
                        App.ShowMessage("Password has been reset to 'password'.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Users = App.DB.User.GetAll();
                    }
                }
                else
                {
                    App.ShowMessage("Please select a user to reset password for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error resetting password : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            try
            {
                if (SelectedUserDataRow is object)
                {
                    if ((int)App.ShowMessage(Conversions.ToString("Are you sure you want to delete \"" + SelectedUserDataRow["FullName"] + "\"?"), MessageBoxButtons.YesNo, (MessageBoxIcon)MsgBoxStyle.Question) == (int)MsgBoxResult.Yes)
                    {
                        App.DB.User.Delete(Conversions.ToInteger(SelectedUserDataRow["UserID"]));
                        Users = App.DB.User.GetAll();
                    }
                }
                else
                {
                    App.ShowMessage("Please select a user to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error deleting : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateNewSecurityModules()
        {
            try
            {
                Users = App.DB.User.GetAll();
                for (int u = 0, loopTo = Users.Count - 1; u <= loopTo; u++)
                {
                    var AllSecurityModules = App.DB.User.GetSecurityUserModulesDefaults();
                    for (int i = 0, loopTo1 = AllSecurityModules.Count - 1; i <= loopTo1; i++)
                    {
                        var usersecuritymodules = App.DB.User.GetSecurityUserModules(Conversions.ToInteger(Users.Table.Rows[u][0].ToString()));
                        var rows = usersecuritymodules.Table.Select(string.Format("SystemModuleID = {0}", Conversions.ToInteger(AllSecurityModules.Table.Rows[i][1].ToString())));
                        if (rows.Length == 1)
                        {
                        }
                        else
                        {
                            App.DB.User.InsertNewSecurityUserModules(Conversions.ToInteger(Users.Table.Rows[u][0].ToString()), Conversions.ToInteger(AllSecurityModules.Table.Rows[i][1].ToString()), false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error creating security module : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetupUserModulesDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSecurityUserModules);
            var tStyle = dgSecurityUserModules.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgSecurityUserModules.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var ModuleName = new DataGridLabelColumn();
            ModuleName.Format = "";
            ModuleName.FormatInfo = null;
            ModuleName.HeaderText = "Module";
            ModuleName.MappingName = "ModuleName";
            ModuleName.ReadOnly = true;
            ModuleName.Width = 250;
            ModuleName.NullText = "";
            tStyle.GridColumnStyles.Add(ModuleName);
            var AccessPermitted = new DataGridBoolColumn();
            AccessPermitted.HeaderText = "Allow";
            AccessPermitted.MappingName = "AccessPermitted";
            AccessPermitted.ReadOnly = true;
            AccessPermitted.Width = 55;
            AccessPermitted.NullText = "";
            tStyle.GridColumnStyles.Add(AccessPermitted);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSecurityUserModules.ToString();
            dgSecurityUserModules.TableStyles.Add(tStyle);
            Entity.Sys.Helper.RemoveEventHandlers(dgSecurityUserModules);
        }

        private DataView _userModules = null;

        public DataView UserModules
        {
            get
            {
                return _userModules;
            }

            set
            {
                _userModules = value;
                if (_userModules is object)
                {
                    _userModules.Table.TableName = Entity.Sys.Enums.TableNames.tblSecurityUserModules.ToString();
                    _userModules.AllowNew = false;
                    _userModules.AllowEdit = false;
                    _userModules.AllowDelete = false;
                }

                dgSecurityUserModules.DataSource = _userModules;
            }
        }

        private DataRow SelectedUserModuleDataRow
        {
            get
            {
                if (!(dgSecurityUserModules.CurrentRowIndex == -1))
                {
                    return UserModules[dgSecurityUserModules.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _userRegions = null;

        public DataView UserRegions
        {
            get
            {
                return _userRegions;
            }

            set
            {
                _userRegions = value;
                if (_userRegions is object)
                {
                    _userRegions.Table.TableName = Entity.Sys.Enums.TableNames.tblRegion.ToString();
                    _userRegions.AllowNew = false;
                    _userRegions.AllowEdit = false;
                    _userRegions.AllowDelete = false;
                }

                dgUserRegions.DataSource = _userRegions;
            }
        }

        private DataRow SelectedUserRegionDataRow
        {
            get
            {
                if (!(dgUserRegions.CurrentRowIndex == -1))
                {
                    return UserRegions[dgUserRegions.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void dgSecurityUserModules_Click(object sender, EventArgs e)
        {
            if (SelectedUserModuleDataRow is null)
            {
                return;
            }

            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.IT))
            {
                int accessPermittedColumn = 1;
                bool selected = !Conversions.ToBoolean(dgSecurityUserModules[dgSecurityUserModules.CurrentRowIndex, accessPermittedColumn]);
                dgSecurityUserModules[dgSecurityUserModules.CurrentRowIndex, accessPermittedColumn] = selected;
            }
            else
            {
                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }
        }

        private void dgUserRegions_Click(object sender, EventArgs e)
        {
            if (SelectedUserRegionDataRow is null)
            {
                return;
            }

            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.IT) == false)
            {
                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }
            else
            {
                bool selected = !Conversions.ToBoolean(dgUserRegions[dgUserRegions.CurrentRowIndex, 0]);
                dgUserRegions[dgUserRegions.CurrentRowIndex, 0] = selected;
            }
        }
    }
}