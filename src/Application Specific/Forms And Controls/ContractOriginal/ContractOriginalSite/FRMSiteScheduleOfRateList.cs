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
    public class FRMSiteScheduleOfRateList : FRMBaseForm, IForm
    {
        public FRMSiteScheduleOfRateList()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMSystemScheduleOfRate_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMSiteScheduleOfRateList(int IDToLinkToIn, ref DataView DataviewToLinkToIn, bool FromQuoteJobIn = false, bool FromJobIn = false) : base()
        {
            base.Load += FRMSystemScheduleOfRate_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            FromQuoteJob = FromQuoteJobIn;
            FromJob = FromJobIn;
            IDToLinkTo = IDToLinkToIn;
            DataviewToLinkTo = DataviewToLinkToIn;
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
        private GroupBox _grpSystemScheduleOfRate;

        internal GroupBox grpSystemScheduleOfRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSystemScheduleOfRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSystemScheduleOfRate != null)
                {
                }

                _grpSystemScheduleOfRate = value;
                if (_grpSystemScheduleOfRate != null)
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

        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        private Button _btnSelectAll;

        internal Button btnSelectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click -= btnSelectAll_Click;
                }

                _btnSelectAll = value;
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click += btnSelectAll_Click;
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

        private TextBox _txtSearch;

        internal TextBox txtSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearch != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _txtSearch.KeyUp -= txtSearch_TextChanged;
                }

                _txtSearch = value;
                if (_txtSearch != null)
                {
                    _txtSearch.KeyUp += txtSearch_TextChanged;
                }
            }
        }

        private Label _lblCategory;

        internal Label lblCategory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCategory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCategory != null)
                {
                }

                _lblCategory = value;
                if (_lblCategory != null)
                {
                }
            }
        }

        private ComboBox _cboCategory;

        internal ComboBox cboCategory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCategory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCategory != null)
                {
                    _cboCategory.SelectedIndexChanged -= cboCategory_SelectedIndexChanged;
                }

                _cboCategory = value;
                if (_cboCategory != null)
                {
                    _cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
                }
            }
        }

        private Button _btnDeselectAll;

        internal Button btnDeselectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeselectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeselectAll != null)
                {
                    _btnDeselectAll.Click -= btnDeselectAll_Click;
                }

                _btnDeselectAll = value;
                if (_btnDeselectAll != null)
                {
                    _btnDeselectAll.Click += btnDeselectAll_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpSystemScheduleOfRate = new GroupBox();
            _cboCategory = new ComboBox();
            _cboCategory.SelectedIndexChanged += new EventHandler(cboCategory_SelectedIndexChanged);
            _lblCategory = new Label();
            _Label1 = new Label();
            _txtSearch = new TextBox();
            _txtSearch.KeyUp += new KeyEventHandler(txtSearch_TextChanged);
            _btnDeselectAll = new Button();
            _btnDeselectAll.Click += new EventHandler(btnDeselectAll_Click);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _dgRates = new DataGrid();
            _dgRates.Click += new EventHandler(dgRates_Click);
            _grpSystemScheduleOfRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgRates).BeginInit();
            SuspendLayout();
            //
            // grpSystemScheduleOfRate
            //
            _grpSystemScheduleOfRate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSystemScheduleOfRate.Controls.Add(_cboCategory);
            _grpSystemScheduleOfRate.Controls.Add(_lblCategory);
            _grpSystemScheduleOfRate.Controls.Add(_Label1);
            _grpSystemScheduleOfRate.Controls.Add(_txtSearch);
            _grpSystemScheduleOfRate.Controls.Add(_btnDeselectAll);
            _grpSystemScheduleOfRate.Controls.Add(_btnSelectAll);
            _grpSystemScheduleOfRate.Controls.Add(_btnCancel);
            _grpSystemScheduleOfRate.Controls.Add(_btnAdd);
            _grpSystemScheduleOfRate.Controls.Add(_dgRates);
            _grpSystemScheduleOfRate.Location = new Point(8, 32);
            _grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate";
            _grpSystemScheduleOfRate.Size = new Size(1147, 569);
            _grpSystemScheduleOfRate.TabIndex = 2;
            _grpSystemScheduleOfRate.TabStop = false;
            _grpSystemScheduleOfRate.Text = "Main Details";
            //
            // cboCategory
            //
            _cboCategory.Cursor = Cursors.Hand;
            _cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCategory.Location = new Point(102, 24);
            _cboCategory.Name = "cboCategory";
            _cboCategory.Size = new Size(1039, 21);
            _cboCategory.TabIndex = 40;
            _cboCategory.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            //
            // lblCategory
            //
            _lblCategory.AutoSize = true;
            _lblCategory.Location = new Point(11, 27);
            _lblCategory.Name = "lblCategory";
            _lblCategory.Size = new Size(60, 13);
            _lblCategory.TabIndex = 39;
            _lblCategory.Text = "Category";
            //
            // Label1
            //
            _Label1.AutoSize = true;
            _Label1.Location = new Point(11, 56);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(47, 13);
            _Label1.TabIndex = 38;
            _Label1.Text = "Search";
            //
            // txtSearch
            //
            _txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSearch.Location = new Point(102, 53);
            _txtSearch.Name = "txtSearch";
            _txtSearch.Size = new Size(1039, 21);
            _txtSearch.TabIndex = 37;
            //
            // btnDeselectAll
            //
            _btnDeselectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnDeselectAll.Location = new Point(112, 497);
            _btnDeselectAll.Name = "btnDeselectAll";
            _btnDeselectAll.Size = new Size(96, 23);
            _btnDeselectAll.TabIndex = 36;
            _btnDeselectAll.Text = "Deselect All";
            //
            // btnSelectAll
            //
            _btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSelectAll.Location = new Point(8, 497);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(96, 23);
            _btnSelectAll.TabIndex = 35;
            _btnSelectAll.Text = "Select All";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(8, 537);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 34;
            _btnCancel.Text = "Cancel";
            //
            // btnAdd
            //
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAdd.Location = new Point(1059, 537);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(75, 23);
            _btnAdd.TabIndex = 33;
            _btnAdd.Text = "Add";
            //
            // dgRates
            //
            _dgRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgRates.DataMember = "";
            _dgRates.HeaderForeColor = SystemColors.ControlText;
            _dgRates.Location = new Point(14, 84);
            _dgRates.Name = "dgRates";
            _dgRates.Size = new Size(1133, 405);
            _dgRates.TabIndex = 32;
            //
            // FRMSiteScheduleOfRateList
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1163, 607);
            Controls.Add(_grpSystemScheduleOfRate);
            MinimumSize = new Size(656, 504);
            Name = "FRMSiteScheduleOfRateList";
            Text = "Property Schedule Of Rates List";
            Controls.SetChildIndex(_grpSystemScheduleOfRate, 0);
            _grpSystemScheduleOfRate.ResumeLayout(false);
            _grpSystemScheduleOfRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgRates).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboCategory;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            SetupRatesDataGrid();
            Populate();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return default;
            }
        }

        public void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool _fromQuoteJob;

        public bool FromQuoteJob
        {
            get
            {
                return _fromQuoteJob;
            }

            set
            {
                _fromQuoteJob = value;
            }
        }

        private bool _fromJob;

        public bool FromJob
        {
            get
            {
                return _fromJob;
            }

            set
            {
                _fromJob = value;
            }
        }

        private DataView _DataViewToLinkTo;

        private DataView DataviewToLinkTo
        {
            get
            {
                return _DataViewToLinkTo;
            }

            set
            {
                _DataViewToLinkTo = value;
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
                _dvRates.AllowEdit = true;
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupRatesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgRates);
            var tbStyle = dgRates.TableStyles[0];
            dgRates.ReadOnly = false;
            tbStyle.AllowSorting = false;
            tbStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tbStyle.GridColumnStyles.Add(Tick);
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
            Code.Width = 65;
            Code.NullText = "";
            tbStyle.GridColumnStyles.Add(Code);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 670;
            Description.NullText = "";
            tbStyle.GridColumnStyles.Add(Description);
            var TimeInMins = new DataGridLabelColumn();
            TimeInMins.Format = "";
            TimeInMins.FormatInfo = null;
            TimeInMins.HeaderText = "Time";
            TimeInMins.MappingName = "TimeInMins";
            TimeInMins.ReadOnly = false;
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
            var QtyPerVisit = new DataGridEditableTextBoxColumn();
            QtyPerVisit.Format = "D"; // Decimal
            QtyPerVisit.FormatInfo = null;
            QtyPerVisit.HeaderText = "Unit Qty Per Visit";
            QtyPerVisit.MappingName = "QtyPerVisit";
            QtyPerVisit.ReadOnly = false;
            QtyPerVisit.Width = 110;
            QtyPerVisit.NullText = "";
            tbStyle.GridColumnStyles.Add(QtyPerVisit);
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
            dgRates.TableStyles.Add(tbStyle);
        }

        private void FRMSystemScheduleOfRate_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in RatesDataview.Table.Rows)
                dr["tick"] = true;
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in RatesDataview.Table.Rows)
                dr["tick"] = false;
        }

        private void dgRates_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedRatesDataRow is null)
                {
                    return;
                }

                bool selected = !Conversions.ToBoolean(dgRates[dgRates.CurrentRowIndex, 0]);
                dgRates[dgRates.CurrentRowIndex, 0] = selected;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void Populate()
        {
            RatesDataview = App.DB.CustomerScheduleOfRate.GetAll_For_SiteID(IDToLinkTo);
        }

        private void Add()
        {
            if (!DataviewToLinkTo.Table.Columns.Contains("SystemLinkID"))
            {
                DataviewToLinkTo.Table.Columns.Add(new DataColumn("SystemLinkID"));
            }

            foreach (DataRow dr in RatesDataview.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["tick"], true, false)))
                {
                    DataRow newRow;
                    newRow = DataviewToLinkTo.Table.NewRow();
                    if (!FromJob)
                    {
                        newRow["ScheduleOfRatesCategoryID"] = dr["ScheduleOfRatesCategoryID"];
                        newRow["Category"] = dr["Category"];
                        newRow["Code"] = dr["Code"];
                        newRow["Description"] = dr["Description"];
                        newRow["Price"] = dr["Price"];
                        if (FromQuoteJob == true)
                        {
                            newRow["Quantity"] = dr["QtyPerVisit"];
                            newRow["Total"] = Entity.Sys.Helper.MakeDoubleValid(dr["Price"]) * Entity.Sys.Helper.MakeDoubleValid(newRow["Quantity"]);
                            newRow["TimeInMins"] = dr["TimeInMins"];
                        }
                        else
                        {
                            newRow["QtyPerVisit"] = dr["QtyPerVisit"];
                        }
                    }
                    else
                    {
                        newRow["Summary"] = dr["Description"];
                        newRow["Qty"] = dr["QtyPerVisit"];
                    }

                    if (dr.Table.Columns.Contains("SiteScheduleOfRateID"))
                    {
                        newRow["RateID"] = dr["SiteScheduleOfRateID"];
                    }
                    else if (dr.Table.Columns.Contains("CustomerScheduleOfRateID"))
                    {
                        newRow["RateID"] = dr["CustomerScheduleOfRateID"];
                        newRow["SystemLinkID"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblCustomerScheduleOfRate);
                    }

                    DataviewToLinkTo.Table.Rows.Add(newRow);
                }
            }

            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void RunFilter()
        {
            if (RatesDataview is null)
            {
                return;
            }

            string filter = "(Description LIKE '%" + txtSearch.Text + "%' OR Code LIKE '%" + txtSearch.Text + "%')";
            string category = Combo.get_GetSelectedItemDescription(cboCategory);
            if (!string.IsNullOrEmpty(category))
            {
                filter += " AND Category = '" + category + "'";
            }

            RatesDataview.RowFilter = filter;
            dgRates.DataSource = RatesDataview;
        }
    }
}