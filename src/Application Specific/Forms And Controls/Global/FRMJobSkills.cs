using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMJobSkills : FRMBaseForm, IForm
    {
        

        public FRMJobSkills() : base()
        {
            
            
            base.Load += FRMJobLocks_Load;

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
        private GroupBox _grpJobSkills;

        internal GroupBox grpJobSkills
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobSkills;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobSkills != null)
                {
                }

                _grpJobSkills = value;
                if (_grpJobSkills != null)
                {
                }
            }
        }

        private DataGrid _dgSkills;

        internal DataGrid dgSkills
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSkills;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSkills != null)
                {
                }

                _dgSkills = value;
                if (_dgSkills != null)
                {
                }
            }
        }

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

        private ComboBox _cboJobType;

        internal ComboBox cboJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJobType != null)
                {
                }

                _cboJobType = value;
                if (_cboJobType != null)
                {
                }
            }
        }

        private Label _lblJobType;

        internal Label lblJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobType != null)
                {
                }

                _lblJobType = value;
                if (_lblJobType != null)
                {
                }
            }
        }

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        private ComboBox _cboJobSkill;

        internal ComboBox cboJobSkill
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJobSkill;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJobSkill != null)
                {
                }

                _cboJobSkill = value;
                if (_cboJobSkill != null)
                {
                }
            }
        }

        private Label _lblJobSkill;

        internal Label lblJobSkill
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobSkill;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobSkill != null)
                {
                }

                _lblJobSkill = value;
                if (_lblJobSkill != null)
                {
                }
            }
        }

        private GroupBox _grpSkillMatrix;

        internal GroupBox grpSkillMatrix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSkillMatrix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSkillMatrix != null)
                {
                }

                _grpSkillMatrix = value;
                if (_grpSkillMatrix != null)
                {
                }
            }
        }

        private Button _btnAddTypeSkill;

        internal Button btnAddTypeSkill
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddTypeSkill;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddTypeSkill != null)
                {
                    _btnAddTypeSkill.Click -= btnAddTypeSkill_Click;
                }

                _btnAddTypeSkill = value;
                if (_btnAddTypeSkill != null)
                {
                    _btnAddTypeSkill.Click += btnAddTypeSkill_Click;
                }
            }
        }

        private ComboBox _cboTypeSkill;

        internal ComboBox cboTypeSkill
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTypeSkill;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTypeSkill != null)
                {
                }

                _cboTypeSkill = value;
                if (_cboTypeSkill != null)
                {
                }
            }
        }

        private Label _lblTypeSkill;

        internal Label lblTypeSkill
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTypeSkill;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTypeSkill != null)
                {
                }

                _lblTypeSkill = value;
                if (_lblTypeSkill != null)
                {
                }
            }
        }

        private ComboBox _cboSkillType;

        internal ComboBox cboSkillType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSkillType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSkillType != null)
                {
                    _cboSkillType.SelectedIndexChanged -= cboSkillType_SelectedIndexChanged;
                }

                _cboSkillType = value;
                if (_cboSkillType != null)
                {
                    _cboSkillType.SelectedIndexChanged += cboSkillType_SelectedIndexChanged;
                }
            }
        }

        private Button _btnDeleteTypeSkill;

        internal Button btnDeleteTypeSkill
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteTypeSkill;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteTypeSkill != null)
                {
                    _btnDeleteTypeSkill.Click -= btnDeleteTypeSkill_Click;
                }

                _btnDeleteTypeSkill = value;
                if (_btnDeleteTypeSkill != null)
                {
                    _btnDeleteTypeSkill.Click += btnDeleteTypeSkill_Click;
                }
            }
        }

        private Label _lblSkillType;

        internal Label lblSkillType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSkillType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSkillType != null)
                {
                }

                _lblSkillType = value;
                if (_lblSkillType != null)
                {
                }
            }
        }

        private DataGrid _dgSkillMatrix;

        internal DataGrid dgSkillMatrix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSkillMatrix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSkillMatrix != null)
                {
                }

                _dgSkillMatrix = value;
                if (_dgSkillMatrix != null)
                {
                }
            }
        }

        private GroupBox _grpJobImportType;

        internal GroupBox grpJobImportType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobImportType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobImportType != null)
                {
                }

                _grpJobImportType = value;
                if (_grpJobImportType != null)
                {
                }
            }
        }

        private TextBox _txtSkillTypeName;

        internal TextBox txtSkillTypeName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSkillTypeName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSkillTypeName != null)
                {
                }

                _txtSkillTypeName = value;
                if (_txtSkillTypeName != null)
                {
                }
            }
        }

        private Label _lblSkillTypeName;

        internal Label lblSkillTypeName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSkillTypeName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSkillTypeName != null)
                {
                }

                _lblSkillTypeName = value;
                if (_lblSkillTypeName != null)
                {
                }
            }
        }

        private ComboBox _cboSkillType1;

        internal ComboBox cboSkillType1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSkillType1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSkillType1 != null)
                {
                }

                _cboSkillType1 = value;
                if (_cboSkillType1 != null)
                {
                }
            }
        }

        private Label _lblSkillType1;

        internal Label lblSkillType1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSkillType1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSkillType1 != null)
                {
                }

                _lblSkillType1 = value;
                if (_lblSkillType1 != null)
                {
                }
            }
        }

        private Button _btnSaveSkillType;

        internal Button btnSaveSkillType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveSkillType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveSkillType != null)
                {
                    _btnSaveSkillType.Click -= btnSaveSkillType_Click;
                }

                _btnSaveSkillType = value;
                if (_btnSaveSkillType != null)
                {
                    _btnSaveSkillType.Click += btnSaveSkillType_Click;
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpJobSkills = new GroupBox();
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _cboJobSkill = new ComboBox();
            _lblJobSkill = new Label();
            _cboJobType = new ComboBox();
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _lblJobType = new Label();
            _dgSkills = new DataGrid();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _grpSkillMatrix = new GroupBox();
            _btnAddTypeSkill = new Button();
            _btnAddTypeSkill.Click += new EventHandler(btnAddTypeSkill_Click);
            _cboTypeSkill = new ComboBox();
            _lblTypeSkill = new Label();
            _cboSkillType = new ComboBox();
            _cboSkillType.SelectedIndexChanged += new EventHandler(cboSkillType_SelectedIndexChanged);
            _btnDeleteTypeSkill = new Button();
            _btnDeleteTypeSkill.Click += new EventHandler(btnDeleteTypeSkill_Click);
            _lblSkillType = new Label();
            _dgSkillMatrix = new DataGrid();
            _grpJobImportType = new GroupBox();
            _txtSkillTypeName = new TextBox();
            _lblSkillTypeName = new Label();
            _cboSkillType1 = new ComboBox();
            _lblSkillType1 = new Label();
            _btnSaveSkillType = new Button();
            _btnSaveSkillType.Click += new EventHandler(btnSaveSkillType_Click);
            _grpJobSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSkills).BeginInit();
            _grpSkillMatrix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSkillMatrix).BeginInit();
            _grpJobImportType.SuspendLayout();
            SuspendLayout();
            //
            // grpJobSkills
            //
            _grpJobSkills.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpJobSkills.Controls.Add(_btnAdd);
            _grpJobSkills.Controls.Add(_cboJobSkill);
            _grpJobSkills.Controls.Add(_lblJobSkill);
            _grpJobSkills.Controls.Add(_cboJobType);
            _grpJobSkills.Controls.Add(_btnDelete);
            _grpJobSkills.Controls.Add(_lblJobType);
            _grpJobSkills.Controls.Add(_dgSkills);
            _grpJobSkills.Location = new Point(8, 53);
            _grpJobSkills.Name = "grpJobSkills";
            _grpJobSkills.Size = new Size(1042, 321);
            _grpJobSkills.TabIndex = 1;
            _grpJobSkills.TabStop = false;
            _grpJobSkills.Text = "Job Skills";
            //
            // btnAdd
            //
            _btnAdd.AccessibleDescription = "Save item";
            _btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAdd.Cursor = Cursors.Hand;
            _btnAdd.ImageIndex = 1;
            _btnAdd.Location = new Point(880, 18);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(154, 23);
            _btnAdd.TabIndex = 33;
            _btnAdd.Text = "Add";
            _btnAdd.UseVisualStyleBackColor = true;
            //
            // cboJobSkill
            //
            _cboJobSkill.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboJobSkill.FormattingEnabled = true;
            _cboJobSkill.Location = new Point(333, 20);
            _cboJobSkill.Name = "cboJobSkill";
            _cboJobSkill.Size = new Size(541, 21);
            _cboJobSkill.TabIndex = 32;
            //
            // lblJobSkill
            //
            _lblJobSkill.AutoSize = true;
            _lblJobSkill.Location = new Point(296, 23);
            _lblJobSkill.Name = "lblJobSkill";
            _lblJobSkill.Size = new Size(31, 13);
            _lblJobSkill.TabIndex = 31;
            _lblJobSkill.Text = "Skill";
            //
            // cboJobType
            //
            _cboJobType.FormattingEnabled = true;
            _cboJobType.Location = new Point(73, 20);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(204, 21);
            _cboJobType.TabIndex = 3;
            //
            // btnDelete
            //
            _btnDelete.AccessibleDescription = "Save item";
            _btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDelete.Cursor = Cursors.Hand;
            _btnDelete.ImageIndex = 1;
            _btnDelete.Location = new Point(880, 292);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(154, 23);
            _btnDelete.TabIndex = 2;
            _btnDelete.Text = "Delete";
            _btnDelete.UseVisualStyleBackColor = true;
            //
            // lblJobType
            //
            _lblJobType.AutoSize = true;
            _lblJobType.Location = new Point(12, 23);
            _lblJobType.Name = "lblJobType";
            _lblJobType.Size = new Size(57, 13);
            _lblJobType.TabIndex = 2;
            _lblJobType.Text = "Job Type";
            //
            // dgSkills
            //
            _dgSkills.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSkills.DataMember = "";
            _dgSkills.HeaderForeColor = SystemColors.ControlText;
            _dgSkills.Location = new Point(8, 47);
            _dgSkills.Name = "dgSkills";
            _dgSkills.Size = new Size(1026, 239);
            _dgSkills.TabIndex = 1;
            //
            // btnClose
            //
            _btnClose.AccessibleDescription = "Save item";
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Cursor = Cursors.Hand;
            _btnClose.ImageIndex = 1;
            _btnClose.Location = new Point(8, 621);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 23);
            _btnClose.TabIndex = 3;
            _btnClose.Text = "Close";
            _btnClose.UseVisualStyleBackColor = true;
            //
            // grpSkillMatrix
            //
            _grpSkillMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSkillMatrix.Controls.Add(_btnAddTypeSkill);
            _grpSkillMatrix.Controls.Add(_cboTypeSkill);
            _grpSkillMatrix.Controls.Add(_lblTypeSkill);
            _grpSkillMatrix.Controls.Add(_cboSkillType);
            _grpSkillMatrix.Controls.Add(_btnDeleteTypeSkill);
            _grpSkillMatrix.Controls.Add(_lblSkillType);
            _grpSkillMatrix.Controls.Add(_dgSkillMatrix);
            _grpSkillMatrix.Location = new Point(8, 391);
            _grpSkillMatrix.Name = "grpSkillMatrix";
            _grpSkillMatrix.Size = new Size(741, 224);
            _grpSkillMatrix.TabIndex = 34;
            _grpSkillMatrix.TabStop = false;
            _grpSkillMatrix.Text = "Skills Matrix";
            //
            // btnAddTypeSkill
            //
            _btnAddTypeSkill.AccessibleDescription = "Save item";
            _btnAddTypeSkill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddTypeSkill.Cursor = Cursors.Hand;
            _btnAddTypeSkill.ImageIndex = 1;
            _btnAddTypeSkill.Location = new Point(579, 18);
            _btnAddTypeSkill.Name = "btnAddTypeSkill";
            _btnAddTypeSkill.Size = new Size(154, 23);
            _btnAddTypeSkill.TabIndex = 33;
            _btnAddTypeSkill.Text = "Add";
            _btnAddTypeSkill.UseVisualStyleBackColor = true;
            //
            // cboTypeSkill
            //
            _cboTypeSkill.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboTypeSkill.FormattingEnabled = true;
            _cboTypeSkill.Location = new Point(333, 20);
            _cboTypeSkill.Name = "cboTypeSkill";
            _cboTypeSkill.Size = new Size(240, 21);
            _cboTypeSkill.TabIndex = 32;
            //
            // lblTypeSkill
            //
            _lblTypeSkill.AutoSize = true;
            _lblTypeSkill.Location = new Point(296, 23);
            _lblTypeSkill.Name = "lblTypeSkill";
            _lblTypeSkill.Size = new Size(31, 13);
            _lblTypeSkill.TabIndex = 31;
            _lblTypeSkill.Text = "Skill";
            //
            // cboSkillType
            //
            _cboSkillType.FormattingEnabled = true;
            _cboSkillType.Location = new Point(73, 20);
            _cboSkillType.Name = "cboSkillType";
            _cboSkillType.Size = new Size(204, 21);
            _cboSkillType.TabIndex = 3;
            //
            // btnDeleteTypeSkill
            //
            _btnDeleteTypeSkill.AccessibleDescription = "Save item";
            _btnDeleteTypeSkill.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeleteTypeSkill.Cursor = Cursors.Hand;
            _btnDeleteTypeSkill.ImageIndex = 1;
            _btnDeleteTypeSkill.Location = new Point(579, 195);
            _btnDeleteTypeSkill.Name = "btnDeleteTypeSkill";
            _btnDeleteTypeSkill.Size = new Size(154, 23);
            _btnDeleteTypeSkill.TabIndex = 2;
            _btnDeleteTypeSkill.Text = "Delete";
            _btnDeleteTypeSkill.UseVisualStyleBackColor = true;
            //
            // lblSkillType
            //
            _lblSkillType.AutoSize = true;
            _lblSkillType.Location = new Point(7, 23);
            _lblSkillType.Name = "lblSkillType";
            _lblSkillType.Size = new Size(62, 13);
            _lblSkillType.TabIndex = 2;
            _lblSkillType.Text = "Skill Type";
            //
            // dgSkillMatrix
            //
            _dgSkillMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSkillMatrix.DataMember = "";
            _dgSkillMatrix.HeaderForeColor = SystemColors.ControlText;
            _dgSkillMatrix.Location = new Point(8, 47);
            _dgSkillMatrix.Name = "dgSkillMatrix";
            _dgSkillMatrix.Size = new Size(725, 142);
            _dgSkillMatrix.TabIndex = 1;
            //
            // grpJobImportType
            //
            _grpJobImportType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _grpJobImportType.Controls.Add(_txtSkillTypeName);
            _grpJobImportType.Controls.Add(_lblSkillTypeName);
            _grpJobImportType.Controls.Add(_cboSkillType1);
            _grpJobImportType.Controls.Add(_lblSkillType1);
            _grpJobImportType.Controls.Add(_btnSaveSkillType);
            _grpJobImportType.Location = new Point(755, 391);
            _grpJobImportType.Name = "grpJobImportType";
            _grpJobImportType.Size = new Size(287, 126);
            _grpJobImportType.TabIndex = 35;
            _grpJobImportType.TabStop = false;
            _grpJobImportType.Text = "Skill Types";
            //
            // txtSkillTypeName
            //
            _txtSkillTypeName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSkillTypeName.Location = new Point(138, 60);
            _txtSkillTypeName.MaxLength = 50;
            _txtSkillTypeName.Name = "txtSkillTypeName";
            _txtSkillTypeName.Size = new Size(142, 21);
            _txtSkillTypeName.TabIndex = 18;
            _txtSkillTypeName.Tag = "SystemScheduleOfRate.Code";
            //
            // lblSkillTypeName
            //
            _lblSkillTypeName.Location = new Point(11, 63);
            _lblSkillTypeName.Name = "lblSkillTypeName";
            _lblSkillTypeName.Size = new Size(100, 20);
            _lblSkillTypeName.TabIndex = 17;
            _lblSkillTypeName.Text = "Skill Type Name";
            //
            // cboSkillType1
            //
            _cboSkillType1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboSkillType1.Cursor = Cursors.Hand;
            _cboSkillType1.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSkillType1.Location = new Point(138, 26);
            _cboSkillType1.Name = "cboSkillType1";
            _cboSkillType1.Size = new Size(142, 21);
            _cboSkillType1.TabIndex = 16;
            _cboSkillType1.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            //
            // lblSkillType1
            //
            _lblSkillType1.Location = new Point(11, 29);
            _lblSkillType1.Name = "lblSkillType1";
            _lblSkillType1.Size = new Size(118, 20);
            _lblSkillType1.TabIndex = 15;
            _lblSkillType1.Text = "Skill Type";
            //
            // btnSaveSkillType
            //
            _btnSaveSkillType.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveSkillType.Location = new Point(179, 97);
            _btnSaveSkillType.Name = "btnSaveSkillType";
            _btnSaveSkillType.Size = new Size(101, 23);
            _btnSaveSkillType.TabIndex = 11;
            _btnSaveSkillType.Text = "Save";
            //
            // FRMJobSkills
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1058, 656);
            Controls.Add(_grpJobImportType);
            Controls.Add(_grpSkillMatrix);
            Controls.Add(_btnClose);
            Controls.Add(_grpJobSkills);
            MinimumSize = new Size(793, 520);
            Name = "FRMJobSkills";
            Text = "Skills";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpJobSkills, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_grpSkillMatrix, 0);
            Controls.SetChildIndex(_grpJobImportType, 0);
            _grpJobSkills.ResumeLayout(false);
            _grpJobSkills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSkills).EndInit();
            _grpSkillMatrix.ResumeLayout(false);
            _grpSkillMatrix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSkillMatrix).EndInit();
            _grpJobImportType.ResumeLayout(false);
            _grpJobImportType.PerformLayout();
            ResumeLayout(false);
        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDataGrid();
            SetupSkillMatrixDataGrid();
            var argc = cboJobType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboSkillType;
            Combo.SetUpCombo(ref argc1, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc2 = cboSkillType1;
            Combo.SetUpCombo(ref argc2, App.DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc3 = cboJobSkill;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            UpdateSkillsDropDown();
            JobSkills = new DataView(App.DB.EngineerLevel.Get_List_For_JobType_GetALL());
            SkillsMatrix = App.DB.Skills.SkillMatrix_GetAll();
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

        
        
        private Entity.Skills.SkillType _skillType;

        public Entity.Skills.SkillType CurrentSkillType
        {
            get
            {
                return _skillType;
            }

            set
            {
                _skillType = value;
                if (CurrentSkillType is null)
                {
                    CurrentSkillType = new Entity.Skills.SkillType();
                    CurrentSkillType.Exists = false;
                }
            }
        }

        private DataView _JobSkills;

        private DataView JobSkills
        {
            get
            {
                return _JobSkills;
            }

            set
            {
                _JobSkills = value;
                _JobSkills.AllowNew = false;
                _JobSkills.AllowEdit = false;
                _JobSkills.AllowDelete = false;
                _JobSkills.Table.TableName = "JobSkills";
                dgSkills.DataSource = JobSkills;
            }
        }

        private DataView _SkillsMatrix;

        private DataView SkillsMatrix
        {
            get
            {
                return _SkillsMatrix;
            }

            set
            {
                _SkillsMatrix = value;
                _SkillsMatrix.AllowNew = false;
                _SkillsMatrix.AllowEdit = false;
                _SkillsMatrix.AllowDelete = false;
                _SkillsMatrix.Table.TableName = "SkillsMatrix";
                dgSkillMatrix.DataSource = SkillsMatrix;
            }
        }

        private DataRow SelectedJobSkillDataRow
        {
            get
            {
                if (!(dgSkills.CurrentRowIndex == -1))
                {
                    return JobSkills[dgSkills.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataRow SelectedSkillMatrixDataRow
        {
            get
            {
                if (!(dgSkillMatrix.CurrentRowIndex == -1))
                {
                    return SkillsMatrix[dgSkillMatrix.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        
        

        private void SetupDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSkills);
            var tbStyle = dgSkills.TableStyles[0];
            var JobTypeID = new DataGridLabelColumn();
            JobTypeID.Format = "";
            JobTypeID.FormatInfo = null;
            JobTypeID.HeaderText = "JobTypeID";
            JobTypeID.MappingName = "JobTypeID";
            JobTypeID.ReadOnly = true;
            JobTypeID.Width = 5;
            JobTypeID.NullText = "";
            tbStyle.GridColumnStyles.Add(JobTypeID);
            var SkillID = new DataGridLabelColumn();
            SkillID.Format = "";
            SkillID.FormatInfo = null;
            SkillID.HeaderText = "SkillID";
            SkillID.MappingName = "SkillID";
            SkillID.ReadOnly = true;
            SkillID.Width = 5;
            SkillID.NullText = "";
            tbStyle.GridColumnStyles.Add(SkillID);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Type";
            JobNumber.MappingName = "JobType";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 150;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var FullName = new DataGridLabelColumn();
            FullName.Format = "";
            FullName.FormatInfo = null;
            FullName.HeaderText = "Skill";
            FullName.MappingName = "Skill";
            FullName.ReadOnly = true;
            FullName.Width = 150;
            FullName.NullText = "";
            tbStyle.GridColumnStyles.Add(FullName);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = "JobSkills";
            dgSkills.TableStyles.Add(tbStyle);
        }

        private void SetupSkillMatrixDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSkillMatrix);
            var tbStyle = dgSkillMatrix.TableStyles[0];
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Skill";
            JobNumber.MappingName = "Skill";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 400;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var FullName = new DataGridLabelColumn();
            FullName.Format = "";
            FullName.FormatInfo = null;
            FullName.HeaderText = "Skill Type";
            FullName.MappingName = "SkillType";
            FullName.ReadOnly = true;
            FullName.Width = 200;
            FullName.NullText = "";
            tbStyle.GridColumnStyles.Add(FullName);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = "SkillsMatrix";
            dgSkillMatrix.TableStyles.Add(tbStyle);
        }

        private void FRMJobLocks_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedJobSkillDataRow is null)
            {
                App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.EnterOverridePassword() == true)
            {
                if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    App.DB.EngineerLevel.EngineerLevel_Delete_For_JobType(Conversions.ToInteger(SelectedJobSkillDataRow["JobTypeID"]), Conversions.ToInteger(SelectedJobSkillDataRow["SkillID"]));
                    JobSkills = new DataView(App.DB.EngineerLevel.Get_List_For_JobType_GetALL());
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Error unlocking job : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobSkill)) > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) > 0)
            {
                App.DB.EngineerLevel.EngineerLevel_Insert_For_JobType(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboJobType)), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboJobSkill)));
                JobSkills = new DataView(App.DB.EngineerLevel.Get_List_For_JobType_GetALL());
            }
        }

        private void btnSaveSkillType_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (CurrentSkillType is null)
                {
                    CurrentSkillType = new Entity.Skills.SkillType();
                }

                {
                    var withBlock = CurrentSkillType;
                    withBlock.SetName = txtSkillTypeName.Text;
                }

                if (CurrentSkillType.Exists)
                {
                    App.DB.Skills.SkillType_Update(CurrentSkillType);
                }
                else
                {
                    CurrentSkillType = App.DB.Skills.SkillType_Insert(CurrentSkillType);
                }

                App.ShowMessage("Skill Type Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CurrentSkillType = null;
                txtSkillTypeName.Text = string.Empty;
                LoadMe(sender, e);
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

        private void btnAddTypeSkill_Click(object sender, EventArgs e)
        {
            int skillTypeId = Entity.Sys.Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboSkillType));
            int skillId = Entity.Sys.Helper.MakeIntegerValid(cboTypeSkill.SelectedValue);
            if (skillTypeId == 0)
                return;
            if (skillId == 0)
                return;

            // check if skill is associated to any other skill
            var skillTypeCheck = App.DB.Skills.SkillType_Get_BySkill(skillId);
            if (skillTypeCheck.Count > 0)
            {
                App.ShowMessage(Combo.get_GetSelectedItemDescription(cboTypeSkill) + " is linked to " + skillTypeCheck.Table.Rows[0]["Name"].ToString() + "!" + Constants.vbCrLf + Constants.vbCrLf + "Please deleted this link", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int skillMatrixId = App.DB.Skills.SkillMatrix_Insert(skillId, skillTypeId);
                if (skillTypeId == 0)
                    throw new Exception("Data cannot save");
                SkillsMatrix = App.DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId);
                UpdateSkillsDropDown();
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnDeleteTypeSkill_Click(object sender, EventArgs e)
        {
            if (SelectedSkillMatrixDataRow is null)
            {
                App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var _ssmList = new List<Entity.Sys.Enums.SecuritySystemModules>();
            _ssmList.Add(Entity.Sys.Enums.SecuritySystemModules.IT);
            _ssmList.Add(Entity.Sys.Enums.SecuritySystemModules.Compliance);
            if (App.loggedInUser.HasAccessToMulitpleModules(_ssmList) == true)
            {
                if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    App.DB.Skills.SkillMatrix_Delete(Conversions.ToInteger(SelectedSkillMatrixDataRow["SkillMatrixID"]));
                    var argcombo = cboSkillType;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
                    UpdateSkillsDropDown();
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Error deleting: " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void cboSkillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int skillTypeId = Entity.Sys.Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboSkillType));
                if (skillTypeId > 0)
                {
                    SkillsMatrix = App.DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId);
                }
                else
                {
                    SkillsMatrix = App.DB.Skills.SkillMatrix_GetAll();
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSkillsDropDown()
        {
            cboTypeSkill.DataSource = App.DB.Skills.Skills_GetAllNotAssignedType().Table;
            cboTypeSkill.DisplayMember = "Skill";
            cboTypeSkill.ValueMember = "SkillID";
        }

        
    }
}