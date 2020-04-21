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
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMUsers() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMUsers_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            if ((App.loggedInUser.Fullname ?? "") == "Hayleigh Mann")
            {
                btnPopulateNewSecurityModules.Visible = true;
            }
            else
            {
                btnPopulateNewSecurityModules.Visible = false;
            }

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

        internal GroupBox grpUsers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpUsers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpUsers != null)
                {
                }

                _grpUsers = value;
                if (_grpUsers != null)
                {
                }
            }
        }

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
            _grpUsers = new GroupBox();
            _dgUsers = new DataGrid();
            _dgUsers.Click += new EventHandler(dgUsers_Click);
            _dgUsers.CurrentCellChanged += new EventHandler(dgUsers_Click);
            _dgUsers.Click += new EventHandler(dgUsers_Click);
            _dgUsers.CurrentCellChanged += new EventHandler(dgUsers_Click);
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _grpDetails = new GroupBox();
            _cboDEG = new ComboBox();
            _Label7 = new Label();
            _chkSDV = new CheckBox();
            _Label6 = new Label();
            _txtEmailAddress = new TextBox();
            _chkAdmin = new CheckBox();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _txtConfirm = new TextBox();
            _txtPassword = new TextBox();
            _txtUserName = new TextBox();
            _chkEnabled = new CheckBox();
            _Label4 = new Label();
            _Label3 = new Label();
            _Label1 = new Label();
            _txtFullName = new TextBox();
            _Label2 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _GroupBox1 = new GroupBox();
            _dgSecurityUserModules = new DataGrid();
            _dgSecurityUserModules.Click += new EventHandler(dgSecurityUserModules_Click);
            _btnPopulateNewSecurityModules = new Button();
            _btnPopulateNewSecurityModules.Click += new EventHandler(btnPopulateNewSecurityModules_Click);
            _grpUserRegions = new GroupBox();
            _dgUserRegions = new DataGrid();
            _dgUserRegions.Click += new EventHandler(dgUserRegions_Click);
            _grpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgUsers).BeginInit();
            _grpDetails.SuspendLayout();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSecurityUserModules).BeginInit();
            _grpUserRegions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgUserRegions).BeginInit();
            SuspendLayout();
            //
            // grpUsers
            //
            _grpUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpUsers.Controls.Add(_dgUsers);
            _grpUsers.Controls.Add(_btnAddNew);
            _grpUsers.Controls.Add(_btnDelete);
            _grpUsers.FlatStyle = FlatStyle.System;
            _grpUsers.Location = new Point(8, 40);
            _grpUsers.Name = "grpUsers";
            _grpUsers.Size = new Size(312, 547);
            _grpUsers.TabIndex = 6;
            _grpUsers.TabStop = false;
            _grpUsers.Text = "Users";
            //
            // dgUsers
            //
            _dgUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgUsers.DataMember = "";
            _dgUsers.HeaderForeColor = SystemColors.ControlText;
            _dgUsers.Location = new Point(8, 57);
            _dgUsers.Name = "dgUsers";
            _dgUsers.Size = new Size(296, 482);
            _dgUsers.TabIndex = 2;
            //
            // btnAddNew
            //
            _btnAddNew.AccessibleDescription = "Add new user";
            _btnAddNew.Cursor = Cursors.Hand;
            _btnAddNew.Location = new Point(8, 24);
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.Size = new Size(48, 23);
            _btnAddNew.TabIndex = 1;
            _btnAddNew.Text = "New";
            _btnAddNew.UseVisualStyleBackColor = true;
            //
            // btnDelete
            //
            _btnDelete.AccessibleDescription = "Delete user";
            _btnDelete.Cursor = Cursors.Hand;
            _btnDelete.Location = new Point(62, 24);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(59, 23);
            _btnDelete.TabIndex = 3;
            _btnDelete.Text = "Delete";
            _btnDelete.UseVisualStyleBackColor = true;
            //
            // grpDetails
            //
            _grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _grpDetails.Controls.Add(_cboDEG);
            _grpDetails.Controls.Add(_Label7);
            _grpDetails.Controls.Add(_chkSDV);
            _grpDetails.Controls.Add(_Label6);
            _grpDetails.Controls.Add(_txtEmailAddress);
            _grpDetails.Controls.Add(_chkAdmin);
            _grpDetails.Controls.Add(_btnReset);
            _grpDetails.Controls.Add(_txtConfirm);
            _grpDetails.Controls.Add(_txtPassword);
            _grpDetails.Controls.Add(_txtUserName);
            _grpDetails.Controls.Add(_chkEnabled);
            _grpDetails.Controls.Add(_Label4);
            _grpDetails.Controls.Add(_Label3);
            _grpDetails.Controls.Add(_Label1);
            _grpDetails.Controls.Add(_txtFullName);
            _grpDetails.Controls.Add(_Label2);
            _grpDetails.FlatStyle = FlatStyle.System;
            _grpDetails.Location = new Point(328, 40);
            _grpDetails.Name = "grpDetails";
            _grpDetails.Size = new Size(457, 244);
            _grpDetails.TabIndex = 8;
            _grpDetails.TabStop = false;
            _grpDetails.Text = "Details";
            //
            // cboDEG
            //
            _cboDEG.Cursor = Cursors.Hand;
            _cboDEG.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDEG.Location = new Point(127, 208);
            _cboDEG.Name = "cboDEG";
            _cboDEG.Size = new Size(324, 21);
            _cboDEG.TabIndex = 20;
            //
            // Label7
            //
            _Label7.AutoSize = true;
            _Label7.Location = new Point(9, 211);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(112, 13);
            _Label7.TabIndex = 19;
            _Label7.Text = "Default Eng Group";
            //
            // chkSDV
            //
            _chkSDV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkSDV.Location = new Point(300, 150);
            _chkSDV.Name = "chkSDV";
            _chkSDV.Size = new Size(149, 24);
            _chkSDV.TabIndex = 17;
            _chkSDV.Text = "Scheduler Day View";
            //
            // Label6
            //
            _Label6.AutoSize = true;
            _Label6.Location = new Point(9, 184);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(38, 13);
            _Label6.TabIndex = 16;
            _Label6.Text = "Email";
            //
            // txtEmailAddress
            //
            _txtEmailAddress.Location = new Point(127, 181);
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(322, 21);
            _txtEmailAddress.TabIndex = 15;
            //
            // chkAdmin
            //
            _chkAdmin.Location = new Point(182, 151);
            _chkAdmin.Name = "chkAdmin";
            _chkAdmin.Size = new Size(63, 24);
            _chkAdmin.TabIndex = 14;
            _chkAdmin.Text = "Admin";
            //
            // btnReset
            //
            _btnReset.AccessibleDescription = "Reset the users password";
            _btnReset.Cursor = Cursors.Hand;
            _btnReset.Location = new Point(399, 86);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(48, 23);
            _btnReset.TabIndex = 7;
            _btnReset.Text = "Reset";
            _btnReset.UseVisualStyleBackColor = true;
            //
            // txtConfirm
            //
            _txtConfirm.Location = new Point(127, 120);
            _txtConfirm.MaxLength = 50;
            _txtConfirm.Name = "txtConfirm";
            _txtConfirm.PasswordChar = (char)42;
            _txtConfirm.Size = new Size(322, 21);
            _txtConfirm.TabIndex = 8;
            //
            // txtPassword
            //
            _txtPassword.Location = new Point(127, 88);
            _txtPassword.MaxLength = 50;
            _txtPassword.Name = "txtPassword";
            _txtPassword.PasswordChar = (char)42;
            _txtPassword.Size = new Size(266, 21);
            _txtPassword.TabIndex = 6;
            //
            // txtUserName
            //
            _txtUserName.Location = new Point(127, 56);
            _txtUserName.MaxLength = 50;
            _txtUserName.Name = "txtUserName";
            _txtUserName.Size = new Size(322, 21);
            _txtUserName.TabIndex = 5;
            //
            // chkEnabled
            //
            _chkEnabled.Checked = true;
            _chkEnabled.CheckState = CheckState.Checked;
            _chkEnabled.Location = new Point(12, 150);
            _chkEnabled.Name = "chkEnabled";
            _chkEnabled.Size = new Size(113, 24);
            _chkEnabled.TabIndex = 10;
            _chkEnabled.Text = "Logon Enabled";
            //
            // Label4
            //
            _Label4.Location = new Point(8, 120);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(64, 16);
            _Label4.TabIndex = 10;
            _Label4.Text = "Confirm";
            //
            // Label3
            //
            _Label3.Location = new Point(8, 88);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(64, 16);
            _Label3.TabIndex = 9;
            _Label3.Text = "Password";
            //
            // Label1
            //
            _Label1.Location = new Point(8, 56);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(74, 16);
            _Label1.TabIndex = 8;
            _Label1.Text = "Username";
            //
            // txtFullName
            //
            _txtFullName.Location = new Point(127, 24);
            _txtFullName.MaxLength = 255;
            _txtFullName.Name = "txtFullName";
            _txtFullName.Size = new Size(322, 21);
            _txtFullName.TabIndex = 4;
            //
            // Label2
            //
            _Label2.Location = new Point(8, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(64, 16);
            _Label2.TabIndex = 5;
            _Label2.Text = "Full Name";
            //
            // btnSave
            //
            _btnSave.AccessibleDescription = "Save user details";
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Cursor = Cursors.Hand;
            _btnSave.Location = new Point(737, 564);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(48, 23);
            _btnSave.TabIndex = 11;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_dgSecurityUserModules);
            _GroupBox1.FlatStyle = FlatStyle.System;
            _GroupBox1.Location = new Point(326, 504);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(459, 54);
            _GroupBox1.TabIndex = 12;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Module Access";
            //
            // dgSecurityUserModules
            //
            _dgSecurityUserModules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSecurityUserModules.DataMember = "";
            _dgSecurityUserModules.HeaderForeColor = SystemColors.ControlText;
            _dgSecurityUserModules.Location = new Point(8, 20);
            _dgSecurityUserModules.Name = "dgSecurityUserModules";
            _dgSecurityUserModules.Size = new Size(443, 26);
            _dgSecurityUserModules.TabIndex = 2;
            //
            // btnPopulateNewSecurityModules
            //
            _btnPopulateNewSecurityModules.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPopulateNewSecurityModules.Location = new Point(536, 564);
            _btnPopulateNewSecurityModules.Name = "btnPopulateNewSecurityModules";
            _btnPopulateNewSecurityModules.Size = new Size(195, 23);
            _btnPopulateNewSecurityModules.TabIndex = 13;
            _btnPopulateNewSecurityModules.Text = "Populate New Security Modules";
            _btnPopulateNewSecurityModules.UseVisualStyleBackColor = true;
            //
            // grpUserRegions
            //
            _grpUserRegions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _grpUserRegions.Controls.Add(_dgUserRegions);
            _grpUserRegions.FlatStyle = FlatStyle.System;
            _grpUserRegions.Location = new Point(328, 290);
            _grpUserRegions.Name = "grpUserRegions";
            _grpUserRegions.Size = new Size(459, 208);
            _grpUserRegions.TabIndex = 13;
            _grpUserRegions.TabStop = false;
            _grpUserRegions.Text = "User Regions";
            //
            // dgUserRegions
            //
            _dgUserRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgUserRegions.DataMember = "";
            _dgUserRegions.HeaderForeColor = SystemColors.ControlText;
            _dgUserRegions.Location = new Point(8, 20);
            _dgUserRegions.Name = "dgUserRegions";
            _dgUserRegions.Size = new Size(443, 180);
            _dgUserRegions.TabIndex = 2;
            //
            // FRMUsers
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(793, 593);
            Controls.Add(_grpUserRegions);
            Controls.Add(_btnPopulateNewSecurityModules);
            Controls.Add(_GroupBox1);
            Controls.Add(_grpDetails);
            Controls.Add(_grpUsers);
            Controls.Add(_btnSave);
            MinimumSize = new Size(800, 576);
            Name = "FRMUsers";
            Text = "Users";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_grpUsers, 0);
            Controls.SetChildIndex(_grpDetails, 0);
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_btnPopulateNewSecurityModules, 0);
            Controls.SetChildIndex(_grpUserRegions, 0);
            _grpUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgUsers).EndInit();
            _grpDetails.ResumeLayout(false);
            _grpDetails.PerformLayout();
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSecurityUserModules).EndInit();
            _grpUserRegions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgUserRegions).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}