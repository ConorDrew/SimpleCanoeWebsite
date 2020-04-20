using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMEngineerRolesDeleteMe
    {
        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _tabEngineerRole = new TabControl();
            _tabPgCreateEngineerRole = new TabPage();
            _txtHourlyCostToCompany = new TextBox();
            _txtName = new TextBox();
            _lblHrlyCostToCompany = new Label();
            _lblName = new Label();
            _tabPgAssignEngineerRole = new TabPage();
            _lblDescription = new Label();
            _txtDescription = new TextBox();
            _cmdSave = new Button();
            _cmdSave.Click += new EventHandler(cmdSave_Click);
            _lblEngineerName = new Label();
            _lblRoleToAssign = new Label();
            _cboEngineer = new ComboBox();
            _cboRoleToAssign = new ComboBox();
            _cmdApply = new Button();
            _dgrdEngineerRoles = new DataGrid();
            _tabEngineerRole.SuspendLayout();
            _tabPgCreateEngineerRole.SuspendLayout();
            _tabPgAssignEngineerRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgrdEngineerRoles).BeginInit();

            // tabEngineerRole
            // 
            _tabEngineerRole.Controls.Add(_tabPgCreateEngineerRole);
            _tabEngineerRole.Controls.Add(_tabPgAssignEngineerRole);
            _tabEngineerRole.Location = new Point(12, 12);
            _tabEngineerRole.Name = "tabEngineerRole";
            _tabEngineerRole.SelectedIndex = 0;
            _tabEngineerRole.Size = new Size(691, 547);
            _tabEngineerRole.TabIndex = 0;
            // 
            // tabPgCreateEngineerRole
            // 
            _tabPgCreateEngineerRole.Controls.Add(_dgrdEngineerRoles);
            _tabPgCreateEngineerRole.Controls.Add(_cmdSave);
            _tabPgCreateEngineerRole.Controls.Add(_txtDescription);
            _tabPgCreateEngineerRole.Controls.Add(_lblDescription);
            _tabPgCreateEngineerRole.Controls.Add(_txtHourlyCostToCompany);
            _tabPgCreateEngineerRole.Controls.Add(_txtName);
            _tabPgCreateEngineerRole.Controls.Add(_lblHrlyCostToCompany);
            _tabPgCreateEngineerRole.Controls.Add(_lblName);
            _tabPgCreateEngineerRole.Location = new Point(4, 22);
            _tabPgCreateEngineerRole.Name = "tabPgCreateEngineerRole";
            _tabPgCreateEngineerRole.Padding = new Padding(3);
            _tabPgCreateEngineerRole.Size = new Size(683, 521);
            _tabPgCreateEngineerRole.TabIndex = 0;
            _tabPgCreateEngineerRole.Text = "Create Engineer Role";
            _tabPgCreateEngineerRole.UseVisualStyleBackColor = true;
            // 
            // txtHourlyCostToCompany
            // 
            _txtHourlyCostToCompany.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtHourlyCostToCompany.Location = new Point(92, 52);
            _txtHourlyCostToCompany.Name = "txtHourlyCostToCompany";
            _txtHourlyCostToCompany.Size = new Size(162, 20);
            _txtHourlyCostToCompany.TabIndex = 4;
            // 
            // txtName
            // 
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(92, 26);
            _txtName.Name = "txtName";
            _txtName.Size = new Size(494, 20);
            _txtName.TabIndex = 3;
            // 
            // lblHrlyCostToCompany
            // 
            _lblHrlyCostToCompany.AutoSize = true;
            _lblHrlyCostToCompany.Location = new Point(22, 56);
            _lblHrlyCostToCompany.Name = "lblHrlyCostToCompany";
            _lblHrlyCostToCompany.Size = new Size(61, 13);
            _lblHrlyCostToCompany.TabIndex = 1;
            _lblHrlyCostToCompany.Text = "Hourly Cost";
            // 
            // lblName
            // 
            _lblName.AutoSize = true;
            _lblName.Location = new Point(22, 29);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(60, 13);
            _lblName.TabIndex = 0;
            _lblName.Text = "Role Name";
            // 
            // tabPgAssignEngineerRole
            // 
            _tabPgAssignEngineerRole.Controls.Add(_cmdApply);
            _tabPgAssignEngineerRole.Controls.Add(_cboRoleToAssign);
            _tabPgAssignEngineerRole.Controls.Add(_cboEngineer);
            _tabPgAssignEngineerRole.Controls.Add(_lblRoleToAssign);
            _tabPgAssignEngineerRole.Controls.Add(_lblEngineerName);
            _tabPgAssignEngineerRole.Location = new Point(4, 22);
            _tabPgAssignEngineerRole.Name = "tabPgAssignEngineerRole";
            _tabPgAssignEngineerRole.Padding = new Padding(3);
            _tabPgAssignEngineerRole.Size = new Size(683, 521);
            _tabPgAssignEngineerRole.TabIndex = 1;
            _tabPgAssignEngineerRole.Text = "Assign Engineer Role";
            _tabPgAssignEngineerRole.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            _lblDescription.AutoSize = true;
            _lblDescription.Location = new Point(22, 78);
            _lblDescription.Name = "lblDescription";
            _lblDescription.Size = new Size(60, 13);
            _lblDescription.TabIndex = 5;
            _lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            _txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtDescription.Location = new Point(91, 78);
            _txtDescription.Multiline = true;
            _txtDescription.Name = "txtDescription";
            _txtDescription.ScrollBars = ScrollBars.Vertical;
            _txtDescription.Size = new Size(495, 88);
            _txtDescription.TabIndex = 6;
            // 
            // cmdSave
            // 
            _cmdSave.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cmdSave.Location = new Point(600, 143);
            _cmdSave.Name = "cmdSave";
            _cmdSave.Size = new Size(67, 23);
            _cmdSave.TabIndex = 7;
            _cmdSave.Text = "Save";
            _cmdSave.UseVisualStyleBackColor = true;
            // 
            // lblEngineerName
            // 
            _lblEngineerName.AutoSize = true;
            _lblEngineerName.Location = new Point(28, 25);
            _lblEngineerName.Name = "lblEngineerName";
            _lblEngineerName.Size = new Size(80, 13);
            _lblEngineerName.TabIndex = 0;
            _lblEngineerName.Text = "Engineer Name";
            // 
            // lblRoleToAssign
            // 
            _lblRoleToAssign.AutoSize = true;
            _lblRoleToAssign.Location = new Point(31, 55);
            _lblRoleToAssign.Name = "lblRoleToAssign";
            _lblRoleToAssign.Size = new Size(79, 13);
            _lblRoleToAssign.TabIndex = 1;
            _lblRoleToAssign.Text = "Role To Assign";
            // 
            // cboEngineer
            // 
            _cboEngineer.FormattingEnabled = true;
            _cboEngineer.Location = new Point(110, 25);
            _cboEngineer.Name = "cboEngineer";
            _cboEngineer.Size = new Size(302, 21);
            _cboEngineer.TabIndex = 2;
            // 
            // cboRoleToAssign
            // 
            _cboRoleToAssign.FormattingEnabled = true;
            _cboRoleToAssign.Location = new Point(110, 55);
            _cboRoleToAssign.Name = "cboRoleToAssign";
            _cboRoleToAssign.Size = new Size(302, 21);
            _cboRoleToAssign.TabIndex = 3;
            // 
            // cmdApply
            // 
            _cmdApply.Location = new Point(337, 82);
            _cmdApply.Name = "cmdApply";
            _cmdApply.Size = new Size(75, 23);
            _cmdApply.TabIndex = 4;
            _cmdApply.Text = "Apply";
            _cmdApply.UseVisualStyleBackColor = true;
            // 
            // dgrdEngineerRoles
            // 
            _dgrdEngineerRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgrdEngineerRoles.DataMember = "";
            _dgrdEngineerRoles.HeaderForeColor = SystemColors.ControlText;
            _dgrdEngineerRoles.Location = new Point(25, 185);
            _dgrdEngineerRoles.Name = "dgrdEngineerRoles";
            _dgrdEngineerRoles.Size = new Size(642, 316);
            _dgrdEngineerRoles.TabIndex = 9;
            // 

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

        private TabPage _tabPgCreateEngineerRole;

        internal TabPage tabPgCreateEngineerRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabPgCreateEngineerRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabPgCreateEngineerRole != null)
                {
                }

                _tabPgCreateEngineerRole = value;
                if (_tabPgCreateEngineerRole != null)
                {
                }
            }
        }

        private Label _lblHrlyCostToCompany;

        internal Label lblHrlyCostToCompany
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblHrlyCostToCompany;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblHrlyCostToCompany != null)
                {
                }

                _lblHrlyCostToCompany = value;
                if (_lblHrlyCostToCompany != null)
                {
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

        private TabPage _tabPgAssignEngineerRole;

        internal TabPage tabPgAssignEngineerRole
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabPgAssignEngineerRole;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabPgAssignEngineerRole != null)
                {
                }

                _tabPgAssignEngineerRole = value;
                if (_tabPgAssignEngineerRole != null)
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
                }

                _txtHourlyCostToCompany = value;
                if (_txtHourlyCostToCompany != null)
                {
                }
            }
        }

        private Button _cmdSave;

        internal Button cmdSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmdSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmdSave != null)
                {
                    _cmdSave.Click -= cmdSave_Click;
                }

                _cmdSave = value;
                if (_cmdSave != null)
                {
                    _cmdSave.Click += cmdSave_Click;
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

        private Button _cmdApply;

        internal Button cmdApply
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmdApply;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmdApply != null)
                {
                }

                _cmdApply = value;
                if (_cmdApply != null)
                {
                }
            }
        }

        private ComboBox _cboRoleToAssign;

        internal ComboBox cboRoleToAssign
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRoleToAssign;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRoleToAssign != null)
                {
                }

                _cboRoleToAssign = value;
                if (_cboRoleToAssign != null)
                {
                }
            }
        }

        private ComboBox _cboEngineer;

        internal ComboBox cboEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineer != null)
                {
                }

                _cboEngineer = value;
                if (_cboEngineer != null)
                {
                }
            }
        }

        private Label _lblRoleToAssign;

        internal Label lblRoleToAssign
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRoleToAssign;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRoleToAssign != null)
                {
                }

                _lblRoleToAssign = value;
                if (_lblRoleToAssign != null)
                {
                }
            }
        }

        private Label _lblEngineerName;

        internal Label lblEngineerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngineerName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngineerName != null)
                {
                }

                _lblEngineerName = value;
                if (_lblEngineerName != null)
                {
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
                }

                _dgrdEngineerRoles = value;
                if (_dgrdEngineerRoles != null)
                {
                }
            }
        }
    }
}