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
            base.Load += FRMSystemScheduleOfRate_Load;
        }

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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpSystemScheduleOfRate = new System.Windows.Forms.GroupBox();
            this._cboCategory = new System.Windows.Forms.ComboBox();
            this._lblCategory = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtSearch = new System.Windows.Forms.TextBox();
            this._btnDeselectAll = new System.Windows.Forms.Button();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnAdd = new System.Windows.Forms.Button();
            this._dgRates = new System.Windows.Forms.DataGrid();
            this._grpSystemScheduleOfRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgRates)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpSystemScheduleOfRate
            // 
            this._grpSystemScheduleOfRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSystemScheduleOfRate.Controls.Add(this._cboCategory);
            this._grpSystemScheduleOfRate.Controls.Add(this._lblCategory);
            this._grpSystemScheduleOfRate.Controls.Add(this._Label1);
            this._grpSystemScheduleOfRate.Controls.Add(this._txtSearch);
            this._grpSystemScheduleOfRate.Controls.Add(this._btnDeselectAll);
            this._grpSystemScheduleOfRate.Controls.Add(this._btnSelectAll);
            this._grpSystemScheduleOfRate.Controls.Add(this._btnCancel);
            this._grpSystemScheduleOfRate.Controls.Add(this._btnAdd);
            this._grpSystemScheduleOfRate.Controls.Add(this._dgRates);
            this._grpSystemScheduleOfRate.Location = new System.Drawing.Point(8, 12);
            this._grpSystemScheduleOfRate.Name = "_grpSystemScheduleOfRate";
            this._grpSystemScheduleOfRate.Size = new System.Drawing.Size(1147, 589);
            this._grpSystemScheduleOfRate.TabIndex = 2;
            this._grpSystemScheduleOfRate.TabStop = false;
            this._grpSystemScheduleOfRate.Text = "Main Details";
            // 
            // _cboCategory
            // 
            this._cboCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboCategory.Location = new System.Drawing.Point(102, 24);
            this._cboCategory.Name = "_cboCategory";
            this._cboCategory.Size = new System.Drawing.Size(1039, 21);
            this._cboCategory.TabIndex = 40;
            this._cboCategory.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            this._cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // _lblCategory
            // 
            this._lblCategory.AutoSize = true;
            this._lblCategory.Location = new System.Drawing.Point(11, 27);
            this._lblCategory.Name = "_lblCategory";
            this._lblCategory.Size = new System.Drawing.Size(60, 13);
            this._lblCategory.TabIndex = 39;
            this._lblCategory.Text = "Category";
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(11, 56);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(47, 13);
            this._Label1.TabIndex = 38;
            this._Label1.Text = "Search";
            // 
            // _txtSearch
            // 
            this._txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSearch.Location = new System.Drawing.Point(102, 53);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.Size = new System.Drawing.Size(1039, 21);
            this._txtSearch.TabIndex = 37;
            this._txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_TextChanged);
            // 
            // _btnDeselectAll
            // 
            this._btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnDeselectAll.Location = new System.Drawing.Point(112, 517);
            this._btnDeselectAll.Name = "_btnDeselectAll";
            this._btnDeselectAll.Size = new System.Drawing.Size(96, 23);
            this._btnDeselectAll.TabIndex = 36;
            this._btnDeselectAll.Text = "Deselect All";
            this._btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSelectAll.Location = new System.Drawing.Point(8, 517);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(96, 23);
            this._btnSelectAll.TabIndex = 35;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(8, 557);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 34;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _btnAdd
            // 
            this._btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAdd.Location = new System.Drawing.Point(1059, 557);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(75, 23);
            this._btnAdd.TabIndex = 33;
            this._btnAdd.Text = "Add";
            this._btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // _dgRates
            // 
            this._dgRates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgRates.DataMember = "";
            this._dgRates.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgRates.Location = new System.Drawing.Point(14, 84);
            this._dgRates.Name = "_dgRates";
            this._dgRates.Size = new System.Drawing.Size(1133, 425);
            this._dgRates.TabIndex = 32;
            this._dgRates.Click += new System.EventHandler(this.dgRates_Click);
            // 
            // FRMSiteScheduleOfRateList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1163, 607);
            this.Controls.Add(this._grpSystemScheduleOfRate);
            this.MinimumSize = new System.Drawing.Size(656, 504);
            this.Name = "FRMSiteScheduleOfRateList";
            this.Text = "Property Schedule Of Rates List";
            this._grpSystemScheduleOfRate.ResumeLayout(false);
            this._grpSystemScheduleOfRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgRates)).EndInit();
            this.ResumeLayout(false);

        }

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