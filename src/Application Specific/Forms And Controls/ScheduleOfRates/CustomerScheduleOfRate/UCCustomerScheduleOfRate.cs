using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCCustomerScheduleOfRate : UCBase, IUserControl
    {
        public UCCustomerScheduleOfRate()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCCustomerScheduleOfRate_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCCustomerScheduleOfRate(Entity.Sys.Enums.TableNames EntityToLinkToIn, int IDToLinkToIn, bool _readOnly = false) : base()
        {
            base.Load += UCCustomerScheduleOfRate_Load;
            IsReadOnlyMode = _readOnly;
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            EntityToLinkTo = EntityToLinkToIn;
            IDToLinkTo = IDToLinkToIn;
            Dock = DockStyle.Fill;
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

        private GroupBox _grpCustomerScheduleOfRate;

        internal GroupBox grpCustomerScheduleOfRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCustomerScheduleOfRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCustomerScheduleOfRate != null)
                {
                }

                _grpCustomerScheduleOfRate = value;
                if (_grpCustomerScheduleOfRate != null)
                {
                }
            }
        }

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

        internal Label lblScheduleOfRatesCategoryID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblScheduleOfRatesCategoryID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblScheduleOfRatesCategoryID != null)
                {
                }

                _lblScheduleOfRatesCategoryID = value;
                if (_lblScheduleOfRatesCategoryID != null)
                {
                }
            }
        }

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

        internal Label lblCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCode != null)
                {
                }

                _lblCode = value;
                if (_lblCode != null)
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

        internal Label lblPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPrice != null)
                {
                }

                _lblPrice = value;
                if (_lblPrice != null)
                {
                }
            }
        }

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

        private Button _btnAddSystemScheduleOfRates;

        internal Button btnAddSystemScheduleOfRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddSystemScheduleOfRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddSystemScheduleOfRates != null)
                {
                    _btnAddSystemScheduleOfRates.Click -= btnAddSystemScheduleOfRates_Click;
                }

                _btnAddSystemScheduleOfRates = value;
                if (_btnAddSystemScheduleOfRates != null)
                {
                    _btnAddSystemScheduleOfRates.Click += btnAddSystemScheduleOfRates_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpCustomerScheduleOfRate = new GroupBox();
            _txtTimeInMins = new TextBox();
            _Label1 = new Label();
            _btnAddSystemScheduleOfRates = new Button();
            _btnAddSystemScheduleOfRates.Click += new EventHandler(btnAddSystemScheduleOfRates_Click);
            _btnAddUpdate = new Button();
            _btnAddUpdate.Click += new EventHandler(btnAddUpdate_Click);
            _btnRemove = new Button();
            _btnRemove.Click += new EventHandler(btnRemove_Click);
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _dgRates = new DataGrid();
            _dgRates.Click += new EventHandler(dgRates_Click);
            _cboScheduleOfRatesCategoryID = new ComboBox();
            _lblScheduleOfRatesCategoryID = new Label();
            _txtCode = new TextBox();
            _lblCode = new Label();
            _txtDescription = new TextBox();
            _lblDescription = new Label();
            _txtPrice = new TextBox();
            _lblPrice = new Label();
            _grpCustomerScheduleOfRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgRates).BeginInit();
            SuspendLayout();
            //
            // grpCustomerScheduleOfRate
            //
            _grpCustomerScheduleOfRate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpCustomerScheduleOfRate.Controls.Add(_txtTimeInMins);
            _grpCustomerScheduleOfRate.Controls.Add(_Label1);
            _grpCustomerScheduleOfRate.Controls.Add(_btnAddSystemScheduleOfRates);
            _grpCustomerScheduleOfRate.Controls.Add(_btnAddUpdate);
            _grpCustomerScheduleOfRate.Controls.Add(_btnRemove);
            _grpCustomerScheduleOfRate.Controls.Add(_btnAddNew);
            _grpCustomerScheduleOfRate.Controls.Add(_dgRates);
            _grpCustomerScheduleOfRate.Controls.Add(_cboScheduleOfRatesCategoryID);
            _grpCustomerScheduleOfRate.Controls.Add(_lblScheduleOfRatesCategoryID);
            _grpCustomerScheduleOfRate.Controls.Add(_txtCode);
            _grpCustomerScheduleOfRate.Controls.Add(_lblCode);
            _grpCustomerScheduleOfRate.Controls.Add(_txtDescription);
            _grpCustomerScheduleOfRate.Controls.Add(_lblDescription);
            _grpCustomerScheduleOfRate.Controls.Add(_txtPrice);
            _grpCustomerScheduleOfRate.Controls.Add(_lblPrice);
            _grpCustomerScheduleOfRate.Location = new Point(0, -1);
            _grpCustomerScheduleOfRate.Name = "grpCustomerScheduleOfRate";
            _grpCustomerScheduleOfRate.Size = new Size(477, 419);
            _grpCustomerScheduleOfRate.TabIndex = 0;
            _grpCustomerScheduleOfRate.TabStop = false;
            _grpCustomerScheduleOfRate.Text = "Schedule Of Rates";
            //
            // txtTimeInMins
            //
            _txtTimeInMins.Location = new Point(194, 135);
            _txtTimeInMins.MaxLength = 9;
            _txtTimeInMins.Name = "txtTimeInMins";
            _txtTimeInMins.Size = new Size(266, 21);
            _txtTimeInMins.TabIndex = 7;
            _txtTimeInMins.Tag = "SystemScheduleOfRate.Price";
            //
            // Label1
            //
            _Label1.Location = new Point(13, 135);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(177, 20);
            _Label1.TabIndex = 6;
            _Label1.Text = "Time (In Minutes)";
            //
            // btnAddSystemScheduleOfRates
            //
            _btnAddSystemScheduleOfRates.Location = new Point(139, 188);
            _btnAddSystemScheduleOfRates.Name = "btnAddSystemScheduleOfRates";
            _btnAddSystemScheduleOfRates.Size = new Size(200, 23);
            _btnAddSystemScheduleOfRates.TabIndex = 12;
            _btnAddSystemScheduleOfRates.Text = "Add System Schedule of Rates";
            //
            // btnAddUpdate
            //
            _btnAddUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddUpdate.Location = new Point(368, 157);
            _btnAddUpdate.Name = "btnAddUpdate";
            _btnAddUpdate.Size = new Size(101, 23);
            _btnAddUpdate.TabIndex = 10;
            _btnAddUpdate.Text = "Add/Update";
            //
            // btnRemove
            //
            _btnRemove.Location = new Point(10, 186);
            _btnRemove.Name = "btnRemove";
            _btnRemove.Size = new Size(101, 23);
            _btnRemove.TabIndex = 11;
            _btnRemove.Text = "Remove";
            //
            // btnAddNew
            //
            _btnAddNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddNew.Location = new Point(367, 187);
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.Size = new Size(101, 23);
            _btnAddNew.TabIndex = 13;
            _btnAddNew.Text = "Add New";
            //
            // dgRates
            //
            _dgRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgRates.DataMember = "";
            _dgRates.HeaderForeColor = SystemColors.ControlText;
            _dgRates.Location = new Point(8, 214);
            _dgRates.Name = "dgRates";
            _dgRates.Size = new Size(460, 196);
            _dgRates.TabIndex = 14;
            //
            // cboScheduleOfRatesCategoryID
            //
            _cboScheduleOfRatesCategoryID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboScheduleOfRatesCategoryID.Cursor = Cursors.Hand;
            _cboScheduleOfRatesCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboScheduleOfRatesCategoryID.Location = new Point(194, 20);
            _cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID";
            _cboScheduleOfRatesCategoryID.Size = new Size(266, 21);
            _cboScheduleOfRatesCategoryID.TabIndex = 1;
            _cboScheduleOfRatesCategoryID.Tag = "CustomerScheduleOfRate.ScheduleOfRatesCategoryID";
            //
            // lblScheduleOfRatesCategoryID
            //
            _lblScheduleOfRatesCategoryID.Location = new Point(11, 19);
            _lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID";
            _lblScheduleOfRatesCategoryID.Size = new Size(179, 20);
            _lblScheduleOfRatesCategoryID.TabIndex = 0;
            _lblScheduleOfRatesCategoryID.Text = "Schedule Of Rates Category";
            //
            // txtCode
            //
            _txtCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCode.Location = new Point(194, 47);
            _txtCode.MaxLength = 50;
            _txtCode.Name = "txtCode";
            _txtCode.Size = new Size(266, 21);
            _txtCode.TabIndex = 3;
            _txtCode.Tag = "SystemScheduleOfRate.Code";
            //
            // lblCode
            //
            _lblCode.Location = new Point(11, 47);
            _lblCode.Name = "lblCode";
            _lblCode.Size = new Size(179, 20);
            _lblCode.TabIndex = 2;
            _lblCode.Text = "Code";
            //
            // txtDescription
            //
            _txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtDescription.Location = new Point(194, 76);
            _txtDescription.MaxLength = 0;
            _txtDescription.Multiline = true;
            _txtDescription.Name = "txtDescription";
            _txtDescription.ScrollBars = ScrollBars.Vertical;
            _txtDescription.Size = new Size(266, 53);
            _txtDescription.TabIndex = 5;
            _txtDescription.Tag = "CustomerScheduleOfRate.Description";
            //
            // lblDescription
            //
            _lblDescription.Location = new Point(11, 75);
            _lblDescription.Name = "lblDescription";
            _lblDescription.Size = new Size(179, 20);
            _lblDescription.TabIndex = 4;
            _lblDescription.Text = "Description";
            //
            // txtPrice
            //
            _txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPrice.Location = new Point(194, 161);
            _txtPrice.MaxLength = 9;
            _txtPrice.Name = "txtPrice";
            _txtPrice.Size = new Size(160, 21);
            _txtPrice.TabIndex = 9;
            _txtPrice.Tag = "CustomerScheduleOfRate.Price";
            //
            // lblPrice
            //
            _lblPrice.Location = new Point(11, 160);
            _lblPrice.Name = "lblPrice";
            _lblPrice.Size = new Size(179, 20);
            _lblPrice.TabIndex = 8;
            _lblPrice.Text = "Price";
            //
            // UCCustomerScheduleOfRate
            //
            Controls.Add(_grpCustomerScheduleOfRate);
            Name = "UCCustomerScheduleOfRate";
            Size = new Size(481, 424);
            _grpCustomerScheduleOfRate.ResumeLayout(false);
            _grpCustomerScheduleOfRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgRates).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            var argc = cboScheduleOfRatesCategoryID;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        public object LoadedItem
        {
            get
            {
                return default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Sys.Enums.TableNames _EntityToLinkTo;

        public Entity.Sys.Enums.TableNames EntityToLinkTo
        {
            get
            {
                return _EntityToLinkTo;
            }

            set
            {
                _EntityToLinkTo = value;
            }
        }

        private int _IDToLinkTo = 0;

        public int IDToLinkTo
        {
            get
            {
                return _IDToLinkTo;
            }

            set
            {
                _IDToLinkTo = value;
                if (IDToLinkTo == 0)
                {
                    grpCustomerScheduleOfRate.Enabled = false;
                }
                else
                {
                    grpCustomerScheduleOfRate.Enabled = true;
                    Populate(IDToLinkTo);
                }
            }
        }

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
                _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblCustomerScheduleOfRate.ToString();
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

        private Entity.CustomerScheduleOfRates.CustomerScheduleOfRate _currentCustomerScheduleOfRate = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRate();

        public Entity.CustomerScheduleOfRates.CustomerScheduleOfRate CurrentCustomerScheduleOfRate
        {
            get
            {
                return _currentCustomerScheduleOfRate;
            }

            set
            {
                _currentCustomerScheduleOfRate = value;
            }
        }

        private bool _isReadOnlyMode;

        public bool IsReadOnlyMode
        {
            get
            {
                return _isReadOnlyMode;
            }

            set
            {
                _isReadOnlyMode = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupRatesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgRates);
            var tbStyle = dgRates.TableStyles[0];
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 90;
            Category.NullText = "";
            tbStyle.GridColumnStyles.Add(Category);
            var Code = new DataGridLabelColumn();
            Code.Format = "";
            Code.FormatInfo = null;
            Code.HeaderText = "Code";
            Code.MappingName = "Code";
            Code.ReadOnly = true;
            Code.Width = 65;
            Code.NullText = "";
            tbStyle.GridColumnStyles.Add(Code);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 170;
            Description.NullText = "";
            tbStyle.GridColumnStyles.Add(Description);
            var TimeInMins = new DataGridLabelColumn();
            TimeInMins.Format = "";
            TimeInMins.FormatInfo = null;
            TimeInMins.HeaderText = "Time (Mins)";
            TimeInMins.MappingName = "TimeInMins";
            TimeInMins.ReadOnly = true;
            TimeInMins.Width = 50;
            TimeInMins.NullText = "";
            tbStyle.GridColumnStyles.Add(TimeInMins);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Unit Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 75;
            Price.NullText = "";
            tbStyle.GridColumnStyles.Add(Price);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblCustomerScheduleOfRate.ToString();
            dgRates.TableStyles.Add(tbStyle);
        }

        private void PageSetup()
        {
            if (IsReadOnlyMode)
            {
                btnAddNew.Enabled = false;
                btnRemove.Enabled = false;
                btnAddUpdate.Enabled = false;
                btnAddSystemScheduleOfRates.Enabled = false;
                txtCode.Enabled = false;
                txtDescription.Enabled = false;
                txtPrice.Enabled = false;
                txtTimeInMins.Enabled = false;
                cboScheduleOfRatesCategoryID.Enabled = false;
            }
            else if (PageState == Entity.Sys.Enums.FormState.Insert)
            {
                btnAddNew.Text = "Cancel Add";
                btnAddUpdate.Text = "Add";
                dgRates.Enabled = false;
                btnAddNew.Enabled = true;
                btnRemove.Enabled = false;
                btnAddUpdate.Enabled = true;
                cboScheduleOfRatesCategoryID.Enabled = true;
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
                    var argcombo1 = cboScheduleOfRatesCategoryID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
                    cboScheduleOfRatesCategoryID.Enabled = false;
                    txtCode.Enabled = false;
                    txtDescription.Enabled = false;
                }
                else
                {
                    cboScheduleOfRatesCategoryID.Enabled = true;
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
                txtCode.Enabled = false;
                txtDescription.Enabled = false;
                txtPrice.Enabled = false;
                txtTimeInMins.Enabled = false;
                var argcombo = cboScheduleOfRatesCategoryID;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
                txtCode.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = Strings.Format(0, "C");
                txtTimeInMins.Text = "";
            }
        }

        private void UCCustomerScheduleOfRate_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            SetupRatesDataGrid();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (PageState == Entity.Sys.Enums.FormState.Insert | PageState == Entity.Sys.Enums.FormState.Update)
            {
                Populate(IDToLinkTo);
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
            if (!IsReadOnlyMode)
            {
                if (SelectedRatesDataRow is object)
                {
                    {
                        var withBlock = SelectedRatesDataRow;
                        var argcombo = cboScheduleOfRatesCategoryID;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(withBlock["ScheduleOfRatesCategoryID"]));
                        txtCode.Text = Conversions.ToString(withBlock["Code"]);
                        txtDescription.Text = Conversions.ToString(withBlock["Description"]);
                        txtPrice.Text = Strings.Format(withBlock["Price"], "C");
                        txtTimeInMins.Text = Conversions.ToString(withBlock["TimeInMins"]);
                    }

                    PageState = Entity.Sys.Enums.FormState.Update;
                }
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

        private void btnAddSystemScheduleOfRates_Click(object sender, EventArgs e)
        {
            using (var f = new FRMSystemScheduleOfRateList(Entity.Sys.Enums.TableNames.tblCustomer, IDToLinkTo))
            {
                f.ShowDialog();
            }

            Populate(IDToLinkTo);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Populate(int ID = 0)
        {
            RatesDataview = App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(ID);
            PageState = Entity.Sys.Enums.FormState.Load;
        }

        public bool Save()
        {
            try
            {
                if (PageState == Entity.Sys.Enums.FormState.Update)
                {
                    CurrentCustomerScheduleOfRate.SetAllowDeleted = SelectedRatesDataRow["AllowDeleted"];
                }
                else
                {
                    CurrentCustomerScheduleOfRate.SetAllowDeleted = 1;
                }

                CurrentCustomerScheduleOfRate.SetCustomerID = IDToLinkTo;
                CurrentCustomerScheduleOfRate.SetCode = txtCode.Text.Trim();
                CurrentCustomerScheduleOfRate.SetDescription = txtDescription.Text.Trim();
                CurrentCustomerScheduleOfRate.SetPrice = Strings.Replace(txtPrice.Text.Trim(), "£", "");
                CurrentCustomerScheduleOfRate.SetTimeInMins = txtTimeInMins.Text.Trim();
                if (CurrentCustomerScheduleOfRate.AllowDeleted)
                {
                    CurrentCustomerScheduleOfRate.SetScheduleOfRatesCategoryID = Combo.get_GetSelectedItemValue(cboScheduleOfRatesCategoryID);
                }
                else
                {
                    CurrentCustomerScheduleOfRate.SetScheduleOfRatesCategoryID = -1;
                }

                var rV = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRateValidator();
                rV.Validate(CurrentCustomerScheduleOfRate);

                // Try
                // With SelectedRatesDataRow

                // If CBool(.Item("AllowDeleted")) Then
                // If MessageBox.Show("UPDATE :" & .Item("Description"), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                // DB.CustomerScheduleOfRate.Delete(.Item("CustomerScheduleOfRateID"))

                // End If
                // Else
                // MessageBox.Show("This rate is a system default and cannot be deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                // End If

                // End With
                // Catch ex As Exception
                // MessageBox.Show("ERROR: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                // End Try

                if (PageState == Entity.Sys.Enums.FormState.Update)
                {
                    CurrentCustomerScheduleOfRate.SetCustomerScheduleOfRateID = SelectedRatesDataRow["CustomerScheduleOfRateID"];
                    App.DB.CustomerScheduleOfRate.Update(CurrentCustomerScheduleOfRate);

                    // UPDATE SITE SCHEDULER OF RATES WITH CUSTOMER - WHERE THEY ACCPET CHANGES
                    try
                    {
                        {
                            var withBlock = SelectedRatesDataRow;
                            if (Conversions.ToBoolean(withBlock["AllowDeleted"]))
                            {
                                if ((int)MessageBox.Show(Conversions.ToString("UPDATE :" + withBlock["Description"]), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)MsgBoxResult.Yes)
                                {
                                    App.DB.CustomerScheduleOfRate.Delete(Conversions.ToInteger(withBlock["CustomerScheduleOfRateID"]));
                                    CurrentCustomerScheduleOfRate = App.DB.CustomerScheduleOfRate.Insert(CurrentCustomerScheduleOfRate);
                                    // Populate(IDToLinkTo)
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

                // CurrentCustomerScheduleOfRate = DB.CustomerScheduleOfRate.Insert(CurrentCustomerScheduleOfRate)

                // With CurrentCustomerScheduleOfRate
                // DB.SiteScheduleOfRate.SiteScheduleOfRates_UpdateForCustomer(.CustomerID, .Price, _
                // .Description, .Code, _
                // .ScheduleOfRatesCategoryID, .TimeInMins)

                // End With
                else
                {
                    CurrentCustomerScheduleOfRate = App.DB.CustomerScheduleOfRate.Insert(CurrentCustomerScheduleOfRate);
                }

                Populate(IDToLinkTo);
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

        private object DeleteRate()
        {
            try
            {
                {
                    var withBlock = SelectedRatesDataRow;
                    if (Conversions.ToBoolean(withBlock["AllowDeleted"]))
                    {
                        if ((int)MessageBox.Show(Conversions.ToString("DELETE :" + withBlock["Description"]), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)MsgBoxResult.Yes)
                        {
                            App.DB.CustomerScheduleOfRate.Delete(Conversions.ToInteger(withBlock["CustomerScheduleOfRateID"]));
                            Populate(IDToLinkTo);
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

            return default;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}