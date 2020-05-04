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
    public class UCSystemScheduleOfRate : UCBase, IUserControl
    {
        public UCSystemScheduleOfRate() : base()
        {
            base.Load += UCSystemScheduleOfRate_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

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

        private GroupBox _grpSystemScheduleOfRate;

        private ComboBox _cboScheduleOfRatesCategoryID;

        internal ComboBox cboScheduleOfRatesCategoryID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboScheduleOfRatesCategoryID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboScheduleOfRatesCategoryID != null)
                {
                }

                _cboScheduleOfRatesCategoryID = value;
                if (_cboScheduleOfRatesCategoryID != null)
                {
                }
            }
        }

        private Label _lblScheduleOfRatesCategoryID;

        private TextBox _txtCode;

        internal TextBox txtCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCode != null)
                {
                }

                _txtCode = value;
                if (_txtCode != null)
                {
                }
            }
        }

        private Label _lblCode;

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

        private TextBox _txtPrice;

        internal TextBox txtPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPrice != null)
                {
                }

                _txtPrice = value;
                if (_txtPrice != null)
                {
                }
            }
        }

        private Label _lblPrice;

        private DataGrid _dgRates;

        internal DataGrid dgRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgRates != null)
                {
                    _dgRates.Click -= dgRates_Click;
                }

                _dgRates = value;
                if (_dgRates != null)
                {
                    _dgRates.Click += dgRates_Click;
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

        private Button _btnRemove;

        internal Button btnRemove
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemove;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemove != null)
                {
                    _btnRemove.Click -= btnRemove_Click;
                }

                _btnRemove = value;
                if (_btnRemove != null)
                {
                    _btnRemove.Click += btnRemove_Click;
                }
            }
        }

        private TextBox _txtTimeInMins;

        internal TextBox txtTimeInMins
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTimeInMins;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTimeInMins != null)
                {
                }

                _txtTimeInMins = value;
                if (_txtTimeInMins != null)
                {
                }
            }
        }

        private Label _lblTime;

        private GroupBox _grpSOR;

        private GroupBox _grpJobImportType;

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

        private Button _btnRemoveType;

        private ComboBox _cboJobImportType;

        internal ComboBox cboJobImportType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJobImportType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJobImportType != null)
                {
                    _cboJobImportType.SelectedIndexChanged -= cboJobImportType_SelectedIndexChanged;
                }

                _cboJobImportType = value;
                if (_cboJobImportType != null)
                {
                    _cboJobImportType.SelectedIndexChanged += cboJobImportType_SelectedIndexChanged;
                }
            }
        }

        private Label _lblJobImportType;

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

        private TextBox _txtJobTypeName;

        internal TextBox txtJobTypeName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobTypeName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobTypeName != null)
                {
                }

                _txtJobTypeName = value;
                if (_txtJobTypeName != null)
                {
                }
            }
        }

        private Label _lblJobTypeName;

        private Button _btnAddNewType;

        private TextBox _txtCycle;

        internal TextBox txtCycle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCycle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCycle != null)
                {
                }

                _txtCycle = value;
                if (_txtCycle != null)
                {
                }
            }
        }

        private Label _lblCycle;

        private ComboBox _cboSORJobType;

        internal ComboBox cboSORJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSORJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSORJobType != null)
                {
                }

                _cboSORJobType = value;
                if (_cboSORJobType != null)
                {
                }
            }
        }

        private Label _Label9;

        private GroupBox _grpEngineerSkillSOR;

        private TextBox _txtSOR;

        internal TextBox txtSOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSOR != null)
                {
                }

                _txtSOR = value;
                if (_txtSOR != null)
                {
                }
            }
        }

        private Label _lblSORName;

        private Button _btnSaveEngineerQual;

        private GroupBox _grpEngineerSkills;

        private DataGrid _dgEngineerQual;

        internal DataGrid dgEngineerQual
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEngineerQual;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEngineerQual != null)
                {
                    _dgEngineerQual.Click -= dgEngineerQual_Click;
                }

                _dgEngineerQual = value;
                if (_dgEngineerQual != null)
                {
                    _dgEngineerQual.Click += dgEngineerQual_Click;
                }
            }
        }

        private Button _btnFindSOR;

        private Button _btnClearAll;

        private Button _btnFindEngineerQual;

        private TextBox _txtEngineerQual;

        internal TextBox txtEngineerQual
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineerQual;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineerQual != null)
                {
                }

                _txtEngineerQual = value;
                if (_txtEngineerQual != null)
                {
                }
            }
        }

        private Label _lblEngineerQual;

        private Button _btnAddUpdate;

        internal Button btnAddUpdate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddUpdate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddUpdate != null)
                {
                    _btnAddUpdate.Click -= btnAddUpdate_Click;
                }

                _btnAddUpdate = value;
                if (_btnAddUpdate != null)
                {
                    _btnAddUpdate.Click += btnAddUpdate_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpSystemScheduleOfRate = new GroupBox();
            _cboSORJobType = new ComboBox();
            _Label9 = new Label();
            _grpSOR = new GroupBox();
            _dgRates = new DataGrid();
            _dgRates.Click += new EventHandler(dgRates_Click);
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _btnRemove = new Button();
            _btnRemove.Click += new EventHandler(btnRemove_Click);
            _txtTimeInMins = new TextBox();
            _lblTime = new Label();
            _btnAddUpdate = new Button();
            _btnAddUpdate.Click += new EventHandler(btnAddUpdate_Click);
            _cboScheduleOfRatesCategoryID = new ComboBox();
            _lblScheduleOfRatesCategoryID = new Label();
            _txtCode = new TextBox();
            _lblCode = new Label();
            _txtDescription = new TextBox();
            _lblDescription = new Label();
            _txtPrice = new TextBox();
            _lblPrice = new Label();
            _grpJobImportType = new GroupBox();
            _btnFindEngineerQual = new Button();
            _btnFindEngineerQual.Click += new EventHandler(btnFindEngineerQual_Click);
            _txtEngineerQual = new TextBox();
            _lblEngineerQual = new Label();
            _txtCycle = new TextBox();
            _lblCycle = new Label();
            _btnAddNewType = new Button();
            _btnAddNewType.Click += new EventHandler(btnAddNewType_Click);
            _cboJobType = new ComboBox();
            _lblJobType = new Label();
            _txtJobTypeName = new TextBox();
            _lblJobTypeName = new Label();
            _cboJobImportType = new ComboBox();
            _cboJobImportType.SelectedIndexChanged += new EventHandler(cboJobImportType_SelectedIndexChanged);
            _lblJobImportType = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnRemoveType = new Button();
            _btnRemoveType.Click += new EventHandler(btnRemoveType_Click);
            _grpEngineerSkillSOR = new GroupBox();
            _btnClearAll = new Button();
            _btnClearAll.Click += new EventHandler(btnClearAll_Click);
            _grpEngineerSkills = new GroupBox();
            _dgEngineerQual = new DataGrid();
            _dgEngineerQual.Click += new EventHandler(dgEngineerQual_Click);
            _btnFindSOR = new Button();
            _btnFindSOR.Click += new EventHandler(btnFindSOR_Click);
            _txtSOR = new TextBox();
            _lblSORName = new Label();
            _btnSaveEngineerQual = new Button();
            _btnSaveEngineerQual.Click += new EventHandler(btnSaveEngineerQual_Click);
            _grpSystemScheduleOfRate.SuspendLayout();
            _grpSOR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgRates).BeginInit();
            _grpJobImportType.SuspendLayout();
            _grpEngineerSkillSOR.SuspendLayout();
            _grpEngineerSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEngineerQual).BeginInit();
            SuspendLayout();
            //
            // grpSystemScheduleOfRate
            //
            _grpSystemScheduleOfRate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _grpSystemScheduleOfRate.Controls.Add(_cboSORJobType);
            _grpSystemScheduleOfRate.Controls.Add(_Label9);
            _grpSystemScheduleOfRate.Controls.Add(_grpSOR);
            _grpSystemScheduleOfRate.Controls.Add(_btnAddNew);
            _grpSystemScheduleOfRate.Controls.Add(_btnRemove);
            _grpSystemScheduleOfRate.Controls.Add(_txtTimeInMins);
            _grpSystemScheduleOfRate.Controls.Add(_lblTime);
            _grpSystemScheduleOfRate.Controls.Add(_btnAddUpdate);
            _grpSystemScheduleOfRate.Controls.Add(_cboScheduleOfRatesCategoryID);
            _grpSystemScheduleOfRate.Controls.Add(_lblScheduleOfRatesCategoryID);
            _grpSystemScheduleOfRate.Controls.Add(_txtCode);
            _grpSystemScheduleOfRate.Controls.Add(_lblCode);
            _grpSystemScheduleOfRate.Controls.Add(_txtDescription);
            _grpSystemScheduleOfRate.Controls.Add(_lblDescription);
            _grpSystemScheduleOfRate.Controls.Add(_txtPrice);
            _grpSystemScheduleOfRate.Controls.Add(_lblPrice);
            _grpSystemScheduleOfRate.Location = new Point(8, 8);
            _grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate";
            _grpSystemScheduleOfRate.Size = new Size(746, 713);
            _grpSystemScheduleOfRate.TabIndex = 0;
            _grpSystemScheduleOfRate.TabStop = false;
            _grpSystemScheduleOfRate.Text = "Main Details";
            //
            // cboSORJobType
            //
            _cboSORJobType.Cursor = Cursors.Hand;
            _cboSORJobType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSORJobType.Location = new Point(194, 59);
            _cboSORJobType.Name = "cboSORJobType";
            _cboSORJobType.Size = new Size(540, 21);
            _cboSORJobType.TabIndex = 27;
            _cboSORJobType.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            //
            // Label9
            //
            _Label9.Location = new Point(11, 59);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(118, 20);
            _Label9.TabIndex = 26;
            _Label9.Text = "Job Type";
            //
            // grpSOR
            //
            _grpSOR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSOR.Controls.Add(_dgRates);
            _grpSOR.Location = new Point(14, 259);
            _grpSOR.Name = "grpSOR";
            _grpSOR.Size = new Size(720, 409);
            _grpSOR.TabIndex = 14;
            _grpSOR.TabStop = false;
            _grpSOR.Text = "Schedule of Rates";
            //
            // dgRates
            //
            _dgRates.DataMember = "";
            _dgRates.Dock = DockStyle.Fill;
            _dgRates.HeaderForeColor = SystemColors.ControlText;
            _dgRates.Location = new Point(3, 17);
            _dgRates.Name = "dgRates";
            _dgRates.Size = new Size(714, 389);
            _dgRates.TabIndex = 13;
            //
            // btnAddNew
            //
            _btnAddNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddNew.Location = new Point(14, 674);
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.Size = new Size(101, 23);
            _btnAddNew.TabIndex = 11;
            _btnAddNew.Text = "Add New";
            //
            // btnRemove
            //
            _btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemove.Location = new Point(633, 674);
            _btnRemove.Name = "btnRemove";
            _btnRemove.Size = new Size(101, 23);
            _btnRemove.TabIndex = 12;
            _btnRemove.Text = "Remove";
            //
            // txtTimeInMins
            //
            _txtTimeInMins.Location = new Point(512, 96);
            _txtTimeInMins.MaxLength = 9;
            _txtTimeInMins.Name = "txtTimeInMins";
            _txtTimeInMins.Size = new Size(103, 21);
            _txtTimeInMins.TabIndex = 7;
            _txtTimeInMins.Tag = "SystemScheduleOfRate.Price";
            //
            // lblTime
            //
            _lblTime.Location = new Point(428, 99);
            _lblTime.Name = "lblTime";
            _lblTime.Size = new Size(78, 20);
            _lblTime.TabIndex = 6;
            _lblTime.Text = "Time (Mins)";
            //
            // btnAddUpdate
            //
            _btnAddUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddUpdate.Location = new Point(633, 232);
            _btnAddUpdate.Name = "btnAddUpdate";
            _btnAddUpdate.Size = new Size(101, 23);
            _btnAddUpdate.TabIndex = 10;
            _btnAddUpdate.Text = "Add/Update";
            //
            // cboScheduleOfRatesCategoryID
            //
            _cboScheduleOfRatesCategoryID.Cursor = Cursors.Hand;
            _cboScheduleOfRatesCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboScheduleOfRatesCategoryID.Location = new Point(194, 25);
            _cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID";
            _cboScheduleOfRatesCategoryID.Size = new Size(540, 21);
            _cboScheduleOfRatesCategoryID.TabIndex = 1;
            _cboScheduleOfRatesCategoryID.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            //
            // lblScheduleOfRatesCategoryID
            //
            _lblScheduleOfRatesCategoryID.Location = new Point(11, 25);
            _lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID";
            _lblScheduleOfRatesCategoryID.Size = new Size(179, 20);
            _lblScheduleOfRatesCategoryID.TabIndex = 0;
            _lblScheduleOfRatesCategoryID.Text = "Schedule Of Rates Category";
            //
            // txtCode
            //
            _txtCode.Location = new Point(279, 96);
            _txtCode.MaxLength = 50;
            _txtCode.Name = "txtCode";
            _txtCode.Size = new Size(131, 21);
            _txtCode.TabIndex = 3;
            _txtCode.Tag = "SystemScheduleOfRate.Code";
            //
            // lblCode
            //
            _lblCode.Location = new Point(231, 99);
            _lblCode.Name = "lblCode";
            _lblCode.Size = new Size(42, 20);
            _lblCode.TabIndex = 2;
            _lblCode.Text = "Code";
            //
            // txtDescription
            //
            _txtDescription.Location = new Point(95, 145);
            _txtDescription.MaxLength = 0;
            _txtDescription.Multiline = true;
            _txtDescription.Name = "txtDescription";
            _txtDescription.ScrollBars = ScrollBars.Vertical;
            _txtDescription.Size = new Size(639, 79);
            _txtDescription.TabIndex = 5;
            _txtDescription.Tag = "SystemScheduleOfRate.Description";
            //
            // lblDescription
            //
            _lblDescription.Location = new Point(12, 145);
            _lblDescription.Name = "lblDescription";
            _lblDescription.Size = new Size(77, 20);
            _lblDescription.TabIndex = 4;
            _lblDescription.Text = "Description";
            //
            // txtPrice
            //
            _txtPrice.Location = new Point(59, 96);
            _txtPrice.MaxLength = 9;
            _txtPrice.Name = "txtPrice";
            _txtPrice.Size = new Size(131, 21);
            _txtPrice.TabIndex = 9;
            _txtPrice.Tag = "SystemScheduleOfRate.Price";
            //
            // lblPrice
            //
            _lblPrice.Location = new Point(11, 99);
            _lblPrice.Name = "lblPrice";
            _lblPrice.Size = new Size(42, 20);
            _lblPrice.TabIndex = 8;
            _lblPrice.Text = "Price";
            //
            // grpJobImportType
            //
            _grpJobImportType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _grpJobImportType.Controls.Add(_btnFindEngineerQual);
            _grpJobImportType.Controls.Add(_txtEngineerQual);
            _grpJobImportType.Controls.Add(_lblEngineerQual);
            _grpJobImportType.Controls.Add(_txtCycle);
            _grpJobImportType.Controls.Add(_lblCycle);
            _grpJobImportType.Controls.Add(_btnAddNewType);
            _grpJobImportType.Controls.Add(_cboJobType);
            _grpJobImportType.Controls.Add(_lblJobType);
            _grpJobImportType.Controls.Add(_txtJobTypeName);
            _grpJobImportType.Controls.Add(_lblJobTypeName);
            _grpJobImportType.Controls.Add(_cboJobImportType);
            _grpJobImportType.Controls.Add(_lblJobImportType);
            _grpJobImportType.Controls.Add(_btnSave);
            _grpJobImportType.Controls.Add(_btnRemoveType);
            _grpJobImportType.Location = new Point(760, 472);
            _grpJobImportType.Name = "grpJobImportType";
            _grpJobImportType.Size = new Size(375, 249);
            _grpJobImportType.TabIndex = 15;
            _grpJobImportType.TabStop = false;
            _grpJobImportType.Text = "Job Import Types";
            //
            // btnFindEngineerQual
            //
            _btnFindEngineerQual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindEngineerQual.BackColor = Color.White;
            _btnFindEngineerQual.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindEngineerQual.Location = new Point(336, 126);
            _btnFindEngineerQual.Name = "btnFindEngineerQual";
            _btnFindEngineerQual.Size = new Size(32, 23);
            _btnFindEngineerQual.TabIndex = 41;
            _btnFindEngineerQual.Text = "...";
            _btnFindEngineerQual.UseVisualStyleBackColor = false;
            //
            // txtEngineerQual
            //
            _txtEngineerQual.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEngineerQual.Location = new Point(138, 128);
            _txtEngineerQual.MaxLength = 50;
            _txtEngineerQual.Name = "txtEngineerQual";
            _txtEngineerQual.ReadOnly = true;
            _txtEngineerQual.Size = new Size(183, 21);
            _txtEngineerQual.TabIndex = 40;
            _txtEngineerQual.Tag = "SystemScheduleOfRate.Code";
            //
            // lblEngineerQual
            //
            _lblEngineerQual.Location = new Point(11, 131);
            _lblEngineerQual.Name = "lblEngineerQual";
            _lblEngineerQual.Size = new Size(163, 20);
            _lblEngineerQual.TabIndex = 39;
            _lblEngineerQual.Text = "Engineer Qual";
            //
            // txtCycle
            //
            _txtCycle.Location = new Point(139, 162);
            _txtCycle.MaxLength = 50;
            _txtCycle.Name = "txtCycle";
            _txtCycle.Size = new Size(230, 21);
            _txtCycle.TabIndex = 25;
            _txtCycle.Tag = "";
            //
            // lblCycle
            //
            _lblCycle.Location = new Point(11, 165);
            _lblCycle.Name = "lblCycle";
            _lblCycle.Size = new Size(100, 20);
            _lblCycle.TabIndex = 24;
            _lblCycle.Text = "Cycle (Yrs)";
            //
            // btnAddNewType
            //
            _btnAddNewType.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddNewType.Location = new Point(152, 210);
            _btnAddNewType.Name = "btnAddNewType";
            _btnAddNewType.Size = new Size(101, 23);
            _btnAddNewType.TabIndex = 23;
            _btnAddNewType.Text = "Add New";
            //
            // cboJobType
            //
            _cboJobType.Cursor = Cursors.Hand;
            _cboJobType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboJobType.Location = new Point(138, 94);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(230, 21);
            _cboJobType.TabIndex = 22;
            _cboJobType.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            //
            // lblJobType
            //
            _lblJobType.Location = new Point(11, 97);
            _lblJobType.Name = "lblJobType";
            _lblJobType.Size = new Size(118, 20);
            _lblJobType.TabIndex = 21;
            _lblJobType.Text = "Job Type";
            //
            // txtJobTypeName
            //
            _txtJobTypeName.Location = new Point(138, 60);
            _txtJobTypeName.MaxLength = 50;
            _txtJobTypeName.Name = "txtJobTypeName";
            _txtJobTypeName.Size = new Size(230, 21);
            _txtJobTypeName.TabIndex = 18;
            _txtJobTypeName.Tag = "SystemScheduleOfRate.Code";
            //
            // lblJobTypeName
            //
            _lblJobTypeName.Location = new Point(11, 63);
            _lblJobTypeName.Name = "lblJobTypeName";
            _lblJobTypeName.Size = new Size(100, 20);
            _lblJobTypeName.TabIndex = 17;
            _lblJobTypeName.Text = "Job Type Name";
            //
            // cboJobImportType
            //
            _cboJobImportType.Cursor = Cursors.Hand;
            _cboJobImportType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboJobImportType.Location = new Point(138, 26);
            _cboJobImportType.Name = "cboJobImportType";
            _cboJobImportType.Size = new Size(230, 21);
            _cboJobImportType.TabIndex = 16;
            _cboJobImportType.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            //
            // lblJobImportType
            //
            _lblJobImportType.Location = new Point(11, 29);
            _lblJobImportType.Name = "lblJobImportType";
            _lblJobImportType.Size = new Size(118, 20);
            _lblJobImportType.TabIndex = 15;
            _lblJobImportType.Text = "Job Import Type";
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(268, 210);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(101, 23);
            _btnSave.TabIndex = 11;
            _btnSave.Text = "Save";
            //
            // btnRemoveType
            //
            _btnRemoveType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemoveType.Location = new Point(14, 210);
            _btnRemoveType.Name = "btnRemoveType";
            _btnRemoveType.Size = new Size(101, 23);
            _btnRemoveType.TabIndex = 12;
            _btnRemoveType.Text = "Remove";
            //
            // grpEngineerSkillSOR
            //
            _grpEngineerSkillSOR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineerSkillSOR.Controls.Add(_btnClearAll);
            _grpEngineerSkillSOR.Controls.Add(_grpEngineerSkills);
            _grpEngineerSkillSOR.Controls.Add(_btnFindSOR);
            _grpEngineerSkillSOR.Controls.Add(_txtSOR);
            _grpEngineerSkillSOR.Controls.Add(_lblSORName);
            _grpEngineerSkillSOR.Controls.Add(_btnSaveEngineerQual);
            _grpEngineerSkillSOR.Location = new Point(760, 8);
            _grpEngineerSkillSOR.Name = "grpEngineerSkillSOR";
            _grpEngineerSkillSOR.Size = new Size(375, 458);
            _grpEngineerSkillSOR.TabIndex = 27;
            _grpEngineerSkillSOR.TabStop = false;
            _grpEngineerSkillSOR.Text = "Engineer Skills SOR";
            //
            // btnClearAll
            //
            _btnClearAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClearAll.Location = new Point(14, 419);
            _btnClearAll.Name = "btnClearAll";
            _btnClearAll.Size = new Size(101, 23);
            _btnClearAll.TabIndex = 39;
            _btnClearAll.Text = "Clear All";
            //
            // grpEngineerSkills
            //
            _grpEngineerSkills.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineerSkills.Controls.Add(_dgEngineerQual);
            _grpEngineerSkills.Location = new Point(14, 65);
            _grpEngineerSkills.Name = "grpEngineerSkills";
            _grpEngineerSkills.Size = new Size(345, 348);
            _grpEngineerSkills.TabIndex = 15;
            _grpEngineerSkills.TabStop = false;
            _grpEngineerSkills.Text = "Qualifications / Skills";
            //
            // dgEngineerQual
            //
            _dgEngineerQual.DataMember = "";
            _dgEngineerQual.Dock = DockStyle.Fill;
            _dgEngineerQual.HeaderForeColor = SystemColors.ControlText;
            _dgEngineerQual.Location = new Point(3, 17);
            _dgEngineerQual.Name = "dgEngineerQual";
            _dgEngineerQual.Size = new Size(339, 328);
            _dgEngineerQual.TabIndex = 13;
            //
            // btnFindSOR
            //
            _btnFindSOR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSOR.BackColor = Color.White;
            _btnFindSOR.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSOR.Location = new Point(327, 23);
            _btnFindSOR.Name = "btnFindSOR";
            _btnFindSOR.Size = new Size(32, 23);
            _btnFindSOR.TabIndex = 38;
            _btnFindSOR.Text = "...";
            _btnFindSOR.UseVisualStyleBackColor = false;
            //
            // txtSOR
            //
            _txtSOR.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSOR.Location = new Point(182, 25);
            _txtSOR.MaxLength = 50;
            _txtSOR.Name = "txtSOR";
            _txtSOR.ReadOnly = true;
            _txtSOR.Size = new Size(139, 21);
            _txtSOR.TabIndex = 18;
            _txtSOR.Tag = "SystemScheduleOfRate.Code";
            //
            // lblSORName
            //
            _lblSORName.Location = new Point(15, 28);
            _lblSORName.Name = "lblSORName";
            _lblSORName.Size = new Size(162, 20);
            _lblSORName.TabIndex = 15;
            _lblSORName.Text = "System Schedule of Rate";
            //
            // btnSaveEngineerQual
            //
            _btnSaveEngineerQual.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveEngineerQual.Location = new Point(258, 422);
            _btnSaveEngineerQual.Name = "btnSaveEngineerQual";
            _btnSaveEngineerQual.Size = new Size(101, 23);
            _btnSaveEngineerQual.TabIndex = 11;
            _btnSaveEngineerQual.Text = "Save";
            //
            // UCSystemScheduleOfRate
            //
            Controls.Add(_grpEngineerSkillSOR);
            Controls.Add(_grpJobImportType);
            Controls.Add(_grpSystemScheduleOfRate);
            Name = "UCSystemScheduleOfRate";
            Size = new Size(1144, 735);
            _grpSystemScheduleOfRate.ResumeLayout(false);
            _grpSystemScheduleOfRate.PerformLayout();
            _grpSOR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgRates).EndInit();
            _grpJobImportType.ResumeLayout(false);
            _grpJobImportType.PerformLayout();
            _grpEngineerSkillSOR.ResumeLayout(false);
            _grpEngineerSkillSOR.PerformLayout();
            _grpEngineerSkills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgEngineerQual).EndInit();
            ResumeLayout(false);
        }

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            var argc = cboScheduleOfRatesCategoryID;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboJobType;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc2 = cboSORJobType;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc3 = cboJobImportType;
            Combo.SetUpCombo(ref argc3, App.DB.JobImports.JobImportType_GetAll().Table, "JobImportTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        public object LoadedItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private DataView _dvRates;

        private DataView RatesDataview
        {
            get
            {
                return _dvRates;
            }

            set
            {
                _dvRates = value;
                _dvRates.AllowNew = false;
                _dvRates.AllowEdit = false;
                _dvRates.AllowDelete = false;
                _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                dgRates.DataSource = RatesDataview;
            }
        }

        private DataRow SelectedRatesDataRow
        {
            get
            {
                if (!(dgRates.CurrentRowIndex == -1))
                {
                    return RatesDataview[dgRates.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _dvEngineerQuals;

        private DataView EngineerQualsDataview
        {
            get
            {
                return _dvEngineerQuals;
            }

            set
            {
                _dvEngineerQuals = value;
                _dvEngineerQuals.Table.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                dgEngineerQual.DataSource = EngineerQualsDataview;
            }
        }

        private DataRow SelectedEngineerQualDataRow
        {
            get
            {
                if (!(dgEngineerQual.CurrentRowIndex == -1))
                {
                    return EngineerQualsDataview[dgEngineerQual.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.SystemScheduleOfRates.SystemScheduleOfRate _engineerQualSOR;

        public Entity.SystemScheduleOfRates.SystemScheduleOfRate EngineerQualSOR
        {
            get
            {
                return _engineerQualSOR;
            }

            set
            {
                _engineerQualSOR = value;
                if (_engineerQualSOR is null)
                {
                    _engineerQualSOR = new Entity.SystemScheduleOfRates.SystemScheduleOfRate();
                    _engineerQualSOR.Exists = false;
                    txtSOR.Text = string.Empty;
                }
                else
                {
                    txtSOR.Text = _engineerQualSOR.Description;
                }
            }
        }

        private Entity.PickLists.PickList _engineerQual;

        public Entity.PickLists.PickList EngineerQual
        {
            get
            {
                return _engineerQual;
            }

            set
            {
                _engineerQual = value;
                if (_engineerQual is null)
                {
                    _engineerQual = new Entity.PickLists.PickList();
                    _engineerQual.Exists = false;
                    txtEngineerQual.Text = string.Empty;
                }
                else
                {
                    txtEngineerQual.Text = _engineerQual.Name;
                }
            }
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
                PageSetup();
            }
        }

        private Entity.JobImport.JobImportType _currentJobImportType;

        public Entity.JobImport.JobImportType CurrentJobImportType
        {
            get
            {
                return _currentJobImportType;
            }

            set
            {
                _currentJobImportType = value;
                if (_currentJobImportType is null)
                {
                    _currentJobImportType = new Entity.JobImport.JobImportType();
                    _currentJobImportType.Exists = false;
                }
            }
        }

        private Entity.SystemScheduleOfRates.SystemScheduleOfRate _currentSystemScheduleOfRate = new Entity.SystemScheduleOfRates.SystemScheduleOfRate();

        public Entity.SystemScheduleOfRates.SystemScheduleOfRate CurrentSystemScheduleOfRate
        {
            get
            {
                return _currentSystemScheduleOfRate;
            }

            set
            {
                _currentSystemScheduleOfRate = value;
            }
        }

        public void SetupRatesDataGrid()
        {
            var tbStyle = dgRates.TableStyles[0];
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 100;
            Category.NullText = "";
            tbStyle.GridColumnStyles.Add(Category);
            var Code = new DataGridLabelColumn();
            Code.Format = "";
            Code.FormatInfo = null;
            Code.HeaderText = "Code";
            Code.MappingName = "Code";
            Code.ReadOnly = true;
            Code.Width = 100;
            Code.NullText = "";
            tbStyle.GridColumnStyles.Add(Code);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 250;
            Description.NullText = "";
            tbStyle.GridColumnStyles.Add(Description);
            var TimeInMins = new DataGridLabelColumn();
            TimeInMins.Format = "";
            TimeInMins.FormatInfo = null;
            TimeInMins.HeaderText = "Time (Mins)";
            TimeInMins.MappingName = "TimeInMins";
            TimeInMins.ReadOnly = true;
            TimeInMins.Width = 80;
            TimeInMins.NullText = "";
            tbStyle.GridColumnStyles.Add(TimeInMins);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Unit Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 80;
            Price.NullText = "";
            tbStyle.GridColumnStyles.Add(Price);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
            dgRates.TableStyles.Add(tbStyle);
        }

        public void SetupEngineerQualDataGrid()
        {
            var tbStyle = dgEngineerQual.TableStyles[0];
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tbStyle.GridColumnStyles.Add(Tick);
            var name = new DataGridLabelColumn();
            name.Format = "";
            name.FormatInfo = null;
            name.HeaderText = "Name";
            name.MappingName = "Name";
            name.ReadOnly = true;
            name.Width = 150;
            name.NullText = "";
            tbStyle.GridColumnStyles.Add(name);
            var description = new DataGridLabelColumn();
            description.Format = "";
            description.FormatInfo = null;
            description.HeaderText = "Description";
            description.MappingName = "Description";
            description.ReadOnly = true;
            description.Width = 250;
            description.NullText = "";
            tbStyle.GridColumnStyles.Add(description);
            var percentage = new DataGridLabelColumn();
            percentage.Format = "";
            percentage.FormatInfo = null;
            percentage.HeaderText = "Percentage";
            percentage.MappingName = "Percentage";
            percentage.ReadOnly = true;
            percentage.Width = 80;
            percentage.NullText = "";
            tbStyle.GridColumnStyles.Add(percentage);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
            dgEngineerQual.TableStyles.Add(tbStyle);
        }

        private void PageSetup()
        {
            if (PageState == Entity.Sys.Enums.FormState.Insert)
            {
                btnAddNew.Text = "Cancel Add";
                btnAddUpdate.Text = "Add";
                dgRates.Enabled = false;
                btnAddNew.Enabled = true;
                btnRemove.Enabled = false;
                btnAddUpdate.Enabled = true;
                cboScheduleOfRatesCategoryID.Enabled = true;
                cboSORJobType.Enabled = true;
                txtCode.Enabled = true;
                txtDescription.Enabled = true;
                txtPrice.Enabled = true;
                txtTimeInMins.Enabled = true;
            }
            else if (PageState == Entity.Sys.Enums.FormState.Update)
            {
                btnAddNew.Text = "Cancel Update";
                btnAddUpdate.Text = "Update";
                dgRates.Enabled = true;
                btnAddNew.Enabled = true;
                btnRemove.Enabled = true;
                btnAddUpdate.Enabled = true;
                if (Conversions.ToBoolean(SelectedRatesDataRow["AllowDeleted"]) == false)
                {
                    var argcombo2 = cboScheduleOfRatesCategoryID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo2, 0.ToString());
                    var argcombo3 = cboSORJobType;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo3, 0.ToString());
                    cboScheduleOfRatesCategoryID.Enabled = false;
                    cboSORJobType.Enabled = false;
                    txtCode.Enabled = false;
                    txtDescription.Enabled = false;
                }
                else
                {
                    cboScheduleOfRatesCategoryID.Enabled = true;
                    cboSORJobType.Enabled = true;
                    txtCode.Enabled = true;
                    txtDescription.Enabled = true;
                }

                txtPrice.Enabled = true;
                txtTimeInMins.Enabled = true;
            }
            else // Load
            {
                btnAddNew.Text = "Add New";
                dgRates.Enabled = true;
                btnAddNew.Enabled = true;
                btnRemove.Enabled = false;
                btnAddUpdate.Enabled = false;
                cboScheduleOfRatesCategoryID.Enabled = false;
                cboSORJobType.Enabled = false;
                txtCode.Enabled = false;
                txtDescription.Enabled = false;
                txtPrice.Enabled = false;
                txtTimeInMins.Enabled = false;
                var argcombo = cboScheduleOfRatesCategoryID;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
                var argcombo1 = cboSORJobType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
                txtCode.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = Strings.Format(0, "C");
                txtTimeInMins.Text = "";
            }
        }

        private void UCSystemScheduleOfRate_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (PageState == Entity.Sys.Enums.FormState.Insert | PageState == Entity.Sys.Enums.FormState.Update)
            {
                Populate();
                PageState = Entity.Sys.Enums.FormState.Load;
            }
            else
            {
                PageState = Entity.Sys.Enums.FormState.Insert;
            }
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void dgRates_Click(object sender, EventArgs e)
        {
            if (SelectedRatesDataRow is object)
            {
                {
                    var withBlock = SelectedRatesDataRow;
                    var argcombo = cboScheduleOfRatesCategoryID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(withBlock["ScheduleOfRatesCategoryID"]));
                    var argcombo1 = cboSORJobType;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo1, Conversions.ToString(withBlock["JobTypeID"]));
                    txtCode.Text = Conversions.ToString(withBlock["Code"]);
                    txtDescription.Text = Conversions.ToString(withBlock["Description"]);
                    txtPrice.Text = Strings.Format(withBlock["Price"], "C");
                    txtTimeInMins.Text = Conversions.ToString(withBlock["TimeInMins"]);
                }

                PageState = Entity.Sys.Enums.FormState.Update;
            }
            else
            {
                PageState = Entity.Sys.Enums.FormState.Load;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (SelectedRatesDataRow is object)
            {
                DeleteRate();
            }
            else
            {
                PageState = Entity.Sys.Enums.FormState.Load;
            }
        }

        private void btnSaveEngineerQual_Click(object sender, EventArgs e)
        {
            if (EngineerQualSOR == null)
                return;

            App.DB.SystemScheduleOfRate.SOREnginerQual_Delete(EngineerQualSOR.SystemScheduleOfRateID);
            foreach (DataRow dr in EngineerQualsDataview.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Tick"], true, false)))
                {
                    App.DB.SystemScheduleOfRate.SOREnginerQual_Insert(EngineerQualSOR.SystemScheduleOfRateID, Conversions.ToInteger(dr["ManagerID"]));
                }
            }
        }

        private void btnAddNewType_Click(object sender, EventArgs e)
        {
            var argc = cboJobImportType;
            Combo.SetUpCombo(ref argc, App.DB.JobImports.JobImportType_GetAll().Table, "JobImportTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argcombo = cboJobType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            txtJobTypeName.Text = string.Empty;
            txtEngineerQual.Text = string.Empty;
            txtCycle.Text = string.Empty;
        }

        private void btnFindSOR_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate));
            if (!(ID == 0))
            {
                EngineerQualSOR = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_Get(ID);
                PopulateEngineerQuals(ID);
            }
        }

        private void btnFindEngineerQual_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblEngineerSkills));
            if (!(ID == 0))
            {
                EngineerQual = App.DB.Picklists.Get_One_As_Object(ID);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in EngineerQualsDataview.Table.Select(EngineerQualsDataview.RowFilter))
                dr["Tick"] = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (CurrentJobImportType is null)
                {
                    CurrentJobImportType = new Entity.JobImport.JobImportType();
                }

                {
                    var withBlock = CurrentJobImportType;
                    withBlock.SetJobImportTypeID = Combo.get_GetSelectedItemValue(cboJobImportType);
                    withBlock.SetName = txtJobTypeName.Text;
                    withBlock.SetJobTypeID = Combo.get_GetSelectedItemValue(cboJobType);
                    withBlock.SetEngineerQualID = Interaction.IIf(EngineerQual is object, EngineerQual.ManagerID, 0);
                    withBlock.SetCycle = Conversions.ToInteger(txtCycle.Text);
                }

                var cVE = new Entity.JobImport.JobImportTypeValidator();
                cVE.Validate(CurrentJobImportType);
                if (CurrentJobImportType.Exists)
                {
                    App.DB.JobImports.JobImportType_Update(CurrentJobImportType);
                }
                else
                {
                    CurrentJobImportType = App.DB.JobImports.JobImportType_Insert(CurrentJobImportType);
                }

                App.ShowMessage("Job Import Type Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                var argcombo = cboJobImportType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentJobImportType.JobImportTypeID.ToString());
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

        private void btnRemoveType_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage("Are you sure you want to remove this job type?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                App.DB.JobImports.JobImportType_Delete(CurrentJobImportType);
                btnAddNewType_Click(sender, e);
            }
        }

        private void dgEngineerQual_Click(object sender, EventArgs e)
        {
            if (SelectedEngineerQualDataRow is null)
            {
                return;
            }

            bool selected = !Conversions.ToBoolean(dgEngineerQual[dgEngineerQual.CurrentRowIndex, 0]);
            dgEngineerQual[dgEngineerQual.CurrentRowIndex, 0] = selected;
        }

        private void cboJobImportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (App.ControlLoading == true)
            {
                return;
            }

            CurrentJobImportType = App.DB.JobImports.JobImportType_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboJobImportType)));
            if (CurrentJobImportType.Exists)
            {
                txtJobTypeName.Text = CurrentJobImportType.Name;
                var argcombo = cboJobType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentJobImportType.JobTypeID.ToString());
                txtEngineerQual.Text = App.DB.Picklists.Get_One_As_Object(CurrentJobImportType.EngineerQualID).Name;
                txtCycle.Text = CurrentJobImportType.Cycle.ToString();
            }
            else
            {
                txtJobTypeName.Text = string.Empty;
                var argcombo1 = cboJobType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
                txtEngineerQual.Text = string.Empty;
                txtCycle.Text = string.Empty;
            }
        }

        public void Populate(int ID = 0)
        {
            RatesDataview = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll();
            PopulateEngineerQuals();
            PageState = Entity.Sys.Enums.FormState.Load;
        }

        public bool Save()
        {
            try
            {
                if (PageState == Entity.Sys.Enums.FormState.Update)
                {
                    CurrentSystemScheduleOfRate.SetAllowDeleted = SelectedRatesDataRow["AllowDeleted"];
                }
                else
                {
                    CurrentSystemScheduleOfRate.SetAllowDeleted = 1;
                }

                CurrentSystemScheduleOfRate.SetCode = txtCode.Text.Trim();
                CurrentSystemScheduleOfRate.SetDescription = txtDescription.Text.Trim();
                CurrentSystemScheduleOfRate.SetPrice = Strings.Replace(txtPrice.Text.Trim(), "£", "");
                CurrentSystemScheduleOfRate.SetTimeInMins = txtTimeInMins.Text.Trim();
                if (CurrentSystemScheduleOfRate.AllowDeleted)
                {
                    CurrentSystemScheduleOfRate.SetScheduleOfRatesCategoryID = Combo.get_GetSelectedItemValue(cboScheduleOfRatesCategoryID);
                    CurrentSystemScheduleOfRate.SetJobTypeID = Combo.get_GetSelectedItemValue(cboSORJobType);
                }
                else
                {
                    CurrentSystemScheduleOfRate.SetScheduleOfRatesCategoryID = -1;
                    CurrentSystemScheduleOfRate.SetJobTypeID = 0;
                }

                var rV = new Entity.SystemScheduleOfRates.SystemScheduleOfRateValidator();
                rV.Validate(CurrentSystemScheduleOfRate);
                if (PageState == Entity.Sys.Enums.FormState.Update)
                {
                    CurrentSystemScheduleOfRate.SetSystemScheduleOfRateID = SelectedRatesDataRow["SystemScheduleOfRateID"];
                    App.DB.SystemScheduleOfRate.Update(CurrentSystemScheduleOfRate);
                    {
                        var withBlock = CurrentSystemScheduleOfRate;
                        // UPDATE ALL CUSTOMERS WHO ACCEPTS CHANGES
                        App.DB.CustomerScheduleOfRate.CustomerScheduleOfRates_UpdateForALL(Conversions.ToDecimal(withBlock.Price), withBlock.Description, withBlock.Code, withBlock.ScheduleOfRatesCategoryID, withBlock.TimeInMins);
                    }
                }
                else
                {
                    CurrentSystemScheduleOfRate = App.DB.SystemScheduleOfRate.Insert(CurrentSystemScheduleOfRate);
                }

                Populate();
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return default;
        }

        private void DeleteRate()
        {
            try
            {
                {
                    var withBlock = SelectedRatesDataRow;
                    if (Conversions.ToBoolean(withBlock["AllowDeleted"]))
                    {
                        if ((int)MessageBox.Show(Conversions.ToString("DELETE :" + withBlock["Description"]), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)MsgBoxResult.Yes)
                        {
                            App.DB.SystemScheduleOfRate.Delete(Conversions.ToInteger(withBlock["SystemScheduleOfRateID"]));
                            Populate();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This rate is a system default and cannot be deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PopulateEngineerQuals(int ID = 0)
        {
            EngineerQualsDataview = App.DB.SystemScheduleOfRate.SOREnginerQual_Get_ForSOR(ID);
        }
    }
}