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

        private GroupBox _grpSkillMatrix;

        private Button _btnAddTypeSkill;

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

        private Label _lblSkillType;

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

        private Button _btnSaveSkillType;

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
            this._grpJobSkills = new System.Windows.Forms.GroupBox();
            this._btnAdd = new System.Windows.Forms.Button();
            this._cboJobSkill = new System.Windows.Forms.ComboBox();
            this._lblJobSkill = new System.Windows.Forms.Label();
            this._cboJobType = new System.Windows.Forms.ComboBox();
            this._btnDelete = new System.Windows.Forms.Button();
            this._lblJobType = new System.Windows.Forms.Label();
            this._dgSkills = new System.Windows.Forms.DataGrid();
            this._btnClose = new System.Windows.Forms.Button();
            this._grpSkillMatrix = new System.Windows.Forms.GroupBox();
            this._btnAddTypeSkill = new System.Windows.Forms.Button();
            this._cboTypeSkill = new System.Windows.Forms.ComboBox();
            this._lblTypeSkill = new System.Windows.Forms.Label();
            this._cboSkillType = new System.Windows.Forms.ComboBox();
            this._btnDeleteTypeSkill = new System.Windows.Forms.Button();
            this._lblSkillType = new System.Windows.Forms.Label();
            this._dgSkillMatrix = new System.Windows.Forms.DataGrid();
            this._grpJobImportType = new System.Windows.Forms.GroupBox();
            this._txtSkillTypeName = new System.Windows.Forms.TextBox();
            this._lblSkillTypeName = new System.Windows.Forms.Label();
            this._cboSkillType1 = new System.Windows.Forms.ComboBox();
            this._lblSkillType1 = new System.Windows.Forms.Label();
            this._btnSaveSkillType = new System.Windows.Forms.Button();
            this._grpJobSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSkills)).BeginInit();
            this._grpSkillMatrix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSkillMatrix)).BeginInit();
            this._grpJobImportType.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpJobSkills
            // 
            this._grpJobSkills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobSkills.Controls.Add(this._btnAdd);
            this._grpJobSkills.Controls.Add(this._cboJobSkill);
            this._grpJobSkills.Controls.Add(this._lblJobSkill);
            this._grpJobSkills.Controls.Add(this._cboJobType);
            this._grpJobSkills.Controls.Add(this._btnDelete);
            this._grpJobSkills.Controls.Add(this._lblJobType);
            this._grpJobSkills.Controls.Add(this._dgSkills);
            this._grpJobSkills.Location = new System.Drawing.Point(8, 12);
            this._grpJobSkills.Name = "_grpJobSkills";
            this._grpJobSkills.Size = new System.Drawing.Size(1042, 362);
            this._grpJobSkills.TabIndex = 1;
            this._grpJobSkills.TabStop = false;
            this._grpJobSkills.Text = "Job Skills";
            // 
            // _btnAdd
            // 
            this._btnAdd.AccessibleDescription = "Save item";
            this._btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAdd.ImageIndex = 1;
            this._btnAdd.Location = new System.Drawing.Point(880, 18);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(154, 23);
            this._btnAdd.TabIndex = 33;
            this._btnAdd.Text = "Add";
            this._btnAdd.UseVisualStyleBackColor = true;
            this._btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // _cboJobSkill
            // 
            this._cboJobSkill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboJobSkill.FormattingEnabled = true;
            this._cboJobSkill.Location = new System.Drawing.Point(333, 20);
            this._cboJobSkill.Name = "_cboJobSkill";
            this._cboJobSkill.Size = new System.Drawing.Size(541, 21);
            this._cboJobSkill.TabIndex = 32;
            // 
            // _lblJobSkill
            // 
            this._lblJobSkill.AutoSize = true;
            this._lblJobSkill.Location = new System.Drawing.Point(296, 23);
            this._lblJobSkill.Name = "_lblJobSkill";
            this._lblJobSkill.Size = new System.Drawing.Size(31, 13);
            this._lblJobSkill.TabIndex = 31;
            this._lblJobSkill.Text = "Skill";
            // 
            // _cboJobType
            // 
            this._cboJobType.FormattingEnabled = true;
            this._cboJobType.Location = new System.Drawing.Point(73, 20);
            this._cboJobType.Name = "_cboJobType";
            this._cboJobType.Size = new System.Drawing.Size(204, 21);
            this._cboJobType.TabIndex = 3;
            // 
            // _btnDelete
            // 
            this._btnDelete.AccessibleDescription = "Save item";
            this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDelete.ImageIndex = 1;
            this._btnDelete.Location = new System.Drawing.Point(880, 333);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(154, 23);
            this._btnDelete.TabIndex = 2;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // _lblJobType
            // 
            this._lblJobType.AutoSize = true;
            this._lblJobType.Location = new System.Drawing.Point(12, 23);
            this._lblJobType.Name = "_lblJobType";
            this._lblJobType.Size = new System.Drawing.Size(57, 13);
            this._lblJobType.TabIndex = 2;
            this._lblJobType.Text = "Job Type";
            // 
            // _dgSkills
            // 
            this._dgSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgSkills.DataMember = "";
            this._dgSkills.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgSkills.Location = new System.Drawing.Point(8, 47);
            this._dgSkills.Name = "_dgSkills";
            this._dgSkills.Size = new System.Drawing.Size(1026, 280);
            this._dgSkills.TabIndex = 1;
            // 
            // _btnClose
            // 
            this._btnClose.AccessibleDescription = "Save item";
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnClose.ImageIndex = 1;
            this._btnClose.Location = new System.Drawing.Point(8, 621);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 23);
            this._btnClose.TabIndex = 3;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _grpSkillMatrix
            // 
            this._grpSkillMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSkillMatrix.Controls.Add(this._btnAddTypeSkill);
            this._grpSkillMatrix.Controls.Add(this._cboTypeSkill);
            this._grpSkillMatrix.Controls.Add(this._lblTypeSkill);
            this._grpSkillMatrix.Controls.Add(this._cboSkillType);
            this._grpSkillMatrix.Controls.Add(this._btnDeleteTypeSkill);
            this._grpSkillMatrix.Controls.Add(this._lblSkillType);
            this._grpSkillMatrix.Controls.Add(this._dgSkillMatrix);
            this._grpSkillMatrix.Location = new System.Drawing.Point(8, 391);
            this._grpSkillMatrix.Name = "_grpSkillMatrix";
            this._grpSkillMatrix.Size = new System.Drawing.Size(741, 224);
            this._grpSkillMatrix.TabIndex = 34;
            this._grpSkillMatrix.TabStop = false;
            this._grpSkillMatrix.Text = "Skills Matrix";
            // 
            // _btnAddTypeSkill
            // 
            this._btnAddTypeSkill.AccessibleDescription = "Save item";
            this._btnAddTypeSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddTypeSkill.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddTypeSkill.ImageIndex = 1;
            this._btnAddTypeSkill.Location = new System.Drawing.Point(579, 18);
            this._btnAddTypeSkill.Name = "_btnAddTypeSkill";
            this._btnAddTypeSkill.Size = new System.Drawing.Size(154, 23);
            this._btnAddTypeSkill.TabIndex = 33;
            this._btnAddTypeSkill.Text = "Add";
            this._btnAddTypeSkill.UseVisualStyleBackColor = true;
            this._btnAddTypeSkill.Click += new System.EventHandler(this.btnAddTypeSkill_Click);
            // 
            // _cboTypeSkill
            // 
            this._cboTypeSkill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboTypeSkill.FormattingEnabled = true;
            this._cboTypeSkill.Location = new System.Drawing.Point(333, 20);
            this._cboTypeSkill.Name = "_cboTypeSkill";
            this._cboTypeSkill.Size = new System.Drawing.Size(240, 21);
            this._cboTypeSkill.TabIndex = 32;
            // 
            // _lblTypeSkill
            // 
            this._lblTypeSkill.AutoSize = true;
            this._lblTypeSkill.Location = new System.Drawing.Point(296, 23);
            this._lblTypeSkill.Name = "_lblTypeSkill";
            this._lblTypeSkill.Size = new System.Drawing.Size(31, 13);
            this._lblTypeSkill.TabIndex = 31;
            this._lblTypeSkill.Text = "Skill";
            // 
            // _cboSkillType
            // 
            this._cboSkillType.FormattingEnabled = true;
            this._cboSkillType.Location = new System.Drawing.Point(73, 20);
            this._cboSkillType.Name = "_cboSkillType";
            this._cboSkillType.Size = new System.Drawing.Size(204, 21);
            this._cboSkillType.TabIndex = 3;
            this._cboSkillType.SelectedIndexChanged += new System.EventHandler(this.cboSkillType_SelectedIndexChanged);
            // 
            // _btnDeleteTypeSkill
            // 
            this._btnDeleteTypeSkill.AccessibleDescription = "Save item";
            this._btnDeleteTypeSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeleteTypeSkill.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDeleteTypeSkill.ImageIndex = 1;
            this._btnDeleteTypeSkill.Location = new System.Drawing.Point(579, 195);
            this._btnDeleteTypeSkill.Name = "_btnDeleteTypeSkill";
            this._btnDeleteTypeSkill.Size = new System.Drawing.Size(154, 23);
            this._btnDeleteTypeSkill.TabIndex = 2;
            this._btnDeleteTypeSkill.Text = "Delete";
            this._btnDeleteTypeSkill.UseVisualStyleBackColor = true;
            this._btnDeleteTypeSkill.Click += new System.EventHandler(this.btnDeleteTypeSkill_Click);
            // 
            // _lblSkillType
            // 
            this._lblSkillType.AutoSize = true;
            this._lblSkillType.Location = new System.Drawing.Point(7, 23);
            this._lblSkillType.Name = "_lblSkillType";
            this._lblSkillType.Size = new System.Drawing.Size(62, 13);
            this._lblSkillType.TabIndex = 2;
            this._lblSkillType.Text = "Skill Type";
            // 
            // _dgSkillMatrix
            // 
            this._dgSkillMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgSkillMatrix.DataMember = "";
            this._dgSkillMatrix.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgSkillMatrix.Location = new System.Drawing.Point(8, 47);
            this._dgSkillMatrix.Name = "_dgSkillMatrix";
            this._dgSkillMatrix.Size = new System.Drawing.Size(725, 142);
            this._dgSkillMatrix.TabIndex = 1;
            // 
            // _grpJobImportType
            // 
            this._grpJobImportType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobImportType.Controls.Add(this._txtSkillTypeName);
            this._grpJobImportType.Controls.Add(this._lblSkillTypeName);
            this._grpJobImportType.Controls.Add(this._cboSkillType1);
            this._grpJobImportType.Controls.Add(this._lblSkillType1);
            this._grpJobImportType.Controls.Add(this._btnSaveSkillType);
            this._grpJobImportType.Location = new System.Drawing.Point(755, 391);
            this._grpJobImportType.Name = "_grpJobImportType";
            this._grpJobImportType.Size = new System.Drawing.Size(287, 126);
            this._grpJobImportType.TabIndex = 35;
            this._grpJobImportType.TabStop = false;
            this._grpJobImportType.Text = "Skill Types";
            // 
            // _txtSkillTypeName
            // 
            this._txtSkillTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSkillTypeName.Location = new System.Drawing.Point(138, 60);
            this._txtSkillTypeName.MaxLength = 50;
            this._txtSkillTypeName.Name = "_txtSkillTypeName";
            this._txtSkillTypeName.Size = new System.Drawing.Size(142, 21);
            this._txtSkillTypeName.TabIndex = 18;
            this._txtSkillTypeName.Tag = "SystemScheduleOfRate.Code";
            // 
            // _lblSkillTypeName
            // 
            this._lblSkillTypeName.Location = new System.Drawing.Point(11, 63);
            this._lblSkillTypeName.Name = "_lblSkillTypeName";
            this._lblSkillTypeName.Size = new System.Drawing.Size(100, 20);
            this._lblSkillTypeName.TabIndex = 17;
            this._lblSkillTypeName.Text = "Skill Type Name";
            // 
            // _cboSkillType1
            // 
            this._cboSkillType1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboSkillType1.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboSkillType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboSkillType1.Location = new System.Drawing.Point(138, 26);
            this._cboSkillType1.Name = "_cboSkillType1";
            this._cboSkillType1.Size = new System.Drawing.Size(142, 21);
            this._cboSkillType1.TabIndex = 16;
            this._cboSkillType1.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            // 
            // _lblSkillType1
            // 
            this._lblSkillType1.Location = new System.Drawing.Point(11, 29);
            this._lblSkillType1.Name = "_lblSkillType1";
            this._lblSkillType1.Size = new System.Drawing.Size(118, 20);
            this._lblSkillType1.TabIndex = 15;
            this._lblSkillType1.Text = "Skill Type";
            // 
            // _btnSaveSkillType
            // 
            this._btnSaveSkillType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveSkillType.Location = new System.Drawing.Point(179, 97);
            this._btnSaveSkillType.Name = "_btnSaveSkillType";
            this._btnSaveSkillType.Size = new System.Drawing.Size(101, 23);
            this._btnSaveSkillType.TabIndex = 11;
            this._btnSaveSkillType.Text = "Save";
            this._btnSaveSkillType.Click += new System.EventHandler(this.btnSaveSkillType_Click);
            // 
            // FRMJobSkills
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1058, 656);
            this.Controls.Add(this._grpJobImportType);
            this.Controls.Add(this._grpSkillMatrix);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._grpJobSkills);
            this.MinimumSize = new System.Drawing.Size(793, 520);
            this.Name = "FRMJobSkills";
            this.Text = "Skills";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpJobSkills.ResumeLayout(false);
            this._grpJobSkills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSkills)).EndInit();
            this._grpSkillMatrix.ResumeLayout(false);
            this._grpSkillMatrix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSkillMatrix)).EndInit();
            this._grpJobImportType.ResumeLayout(false);
            this._grpJobImportType.PerformLayout();
            this.ResumeLayout(false);

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