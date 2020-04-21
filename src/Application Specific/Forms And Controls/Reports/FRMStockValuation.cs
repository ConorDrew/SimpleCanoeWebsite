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
    public class FRMStockValuation : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMStockValuation() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMStockValuation_Load;

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
        private GroupBox _grpFilter;

        internal GroupBox grpFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilter != null)
                {
                }

                _grpFilter = value;
                if (_grpFilter != null)
                {
                }
            }
        }

        private GroupBox _grpParts;

        internal GroupBox grpParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpParts != null)
                {
                }

                _grpParts = value;
                if (_grpParts != null)
                {
                }
            }
        }

        private TextBox _txtReference;

        internal TextBox txtReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtReference != null)
                {
                    _txtReference.TextChanged -= txtReference_TextChanged;
                }

                _txtReference = value;
                if (_txtReference != null)
                {
                    _txtReference.TextChanged += txtReference_TextChanged;
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

        private Button _btnExport;

        internal Button btnExport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExport != null)
                {
                    _btnExport.Click -= btnExport_Click;
                }

                _btnExport = value;
                if (_btnExport != null)
                {
                    _btnExport.Click += btnExport_Click;
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
                    _txtName.TextChanged -= txtName_TextChanged;
                }

                _txtName = value;
                if (_txtName != null)
                {
                    _txtName.TextChanged += txtName_TextChanged;
                }
            }
        }

        private TextBox _txtNumber;

        internal TextBox txtNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNumber != null)
                {
                    _txtNumber.TextChanged -= txtNumber_TextChanged;
                }

                _txtNumber = value;
                if (_txtNumber != null)
                {
                    _txtNumber.TextChanged += txtNumber_TextChanged;
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

        private ComboBox _cboLocation;

        internal ComboBox cboLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLocation != null)
                {
                    _cboLocation.SelectedIndexChanged -= cboLocation_SelectedIndexChanged;
                }

                _cboLocation = value;
                if (_cboLocation != null)
                {
                    _cboLocation.SelectedIndexChanged += cboLocation_SelectedIndexChanged;
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

        private TextBox _txtLocation;

        internal TextBox txtLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLocation != null)
                {
                    _txtLocation.TextChanged -= txtLocation_TextChanged;
                }

                _txtLocation = value;
                if (_txtLocation != null)
                {
                    _txtLocation.TextChanged += txtLocation_TextChanged;
                }
            }
        }

        private CheckBox _chkExact;

        internal CheckBox chkExact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkExact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkExact != null)
                {
                    _chkExact.CheckedChanged -= chkExact_CheckedChanged;
                }

                _chkExact = value;
                if (_chkExact != null)
                {
                    _chkExact.CheckedChanged += chkExact_CheckedChanged;
                }
            }
        }

        private DataGrid _dgParts;

        internal DataGrid dgParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgParts != null)
                {
                    _dgParts.DoubleClick -= dgParts_DoubleClick;
                }

                _dgParts = value;
                if (_dgParts != null)
                {
                    _dgParts.DoubleClick += dgParts_DoubleClick;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpParts = new GroupBox();
            _dgParts = new DataGrid();
            _dgParts.DoubleClick += new EventHandler(dgParts_DoubleClick);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpFilter = new GroupBox();
            _chkExact = new CheckBox();
            _chkExact.CheckedChanged += new EventHandler(chkExact_CheckedChanged);
            _txtLocation = new TextBox();
            _txtLocation.TextChanged += new EventHandler(txtLocation_TextChanged);
            _cboLocation = new ComboBox();
            _cboLocation.SelectedIndexChanged += new EventHandler(cboLocation_SelectedIndexChanged);
            _Label4 = new Label();
            _txtName = new TextBox();
            _txtName.TextChanged += new EventHandler(txtName_TextChanged);
            _txtNumber = new TextBox();
            _txtNumber.TextChanged += new EventHandler(txtNumber_TextChanged);
            _cboCategory = new ComboBox();
            _cboCategory.SelectedIndexChanged += new EventHandler(cboCategory_SelectedIndexChanged);
            _Label3 = new Label();
            _Label2 = new Label();
            _Label1 = new Label();
            _txtReference = new TextBox();
            _txtReference.TextChanged += new EventHandler(txtReference_TextChanged);
            _Label6 = new Label();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _grpParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgParts).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            //
            // grpParts
            //
            _grpParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpParts.Controls.Add(_dgParts);
            _grpParts.Location = new Point(8, 136);
            _grpParts.Name = "grpParts";
            _grpParts.Size = new Size(630, 162);
            _grpParts.TabIndex = 2;
            _grpParts.TabStop = false;
            _grpParts.Text = "Part replacement costs based on supplier";
            //
            // dgParts
            //
            _dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgParts.DataMember = "";
            _dgParts.HeaderForeColor = SystemColors.ControlText;
            _dgParts.Location = new Point(8, 19);
            _dgParts.Name = "dgParts";
            _dgParts.Size = new Size(614, 135);
            _dgParts.TabIndex = 14;
            //
            // btnExport
            //
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 306);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 3;
            _btnExport.Text = "Export";
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_chkExact);
            _grpFilter.Controls.Add(_txtLocation);
            _grpFilter.Controls.Add(_cboLocation);
            _grpFilter.Controls.Add(_Label4);
            _grpFilter.Controls.Add(_txtName);
            _grpFilter.Controls.Add(_txtNumber);
            _grpFilter.Controls.Add(_cboCategory);
            _grpFilter.Controls.Add(_Label3);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_txtReference);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(630, 98);
            _grpFilter.TabIndex = 1;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // chkExact
            //
            _chkExact.AutoSize = true;
            _chkExact.Location = new Point(52, 41);
            _chkExact.Name = "chkExact";
            _chkExact.RightToLeft = RightToLeft.Yes;
            _chkExact.Size = new Size(237, 17);
            _chkExact.TabIndex = 17;
            _chkExact.Text = "Advanced Location Filter Exact Match";
            _chkExact.UseVisualStyleBackColor = true;
            //
            // txtLocation
            //
            _txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtLocation.Location = new Point(307, 39);
            _txtLocation.MaxLength = 50;
            _txtLocation.Name = "txtLocation";
            _txtLocation.Size = new Size(58, 21);
            _txtLocation.TabIndex = 16;
            //
            // cboLocation
            //
            _cboLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboLocation.FormattingEnabled = true;
            _cboLocation.Location = new Point(64, 14);
            _cboLocation.Name = "cboLocation";
            _cboLocation.Size = new Size(301, 21);
            _cboLocation.TabIndex = 14;
            //
            // Label4
            //
            _Label4.Location = new Point(6, 17);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(88, 16);
            _Label4.TabIndex = 13;
            _Label4.Text = "Location";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(64, 69);
            _txtName.Name = "txtName";
            _txtName.Size = new Size(301, 21);
            _txtName.TabIndex = 2;
            //
            // txtNumber
            //
            _txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtNumber.Location = new Point(445, 69);
            _txtNumber.Name = "txtNumber";
            _txtNumber.Size = new Size(181, 21);
            _txtNumber.TabIndex = 4;
            //
            // cboCategory
            //
            _cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboCategory.FormattingEnabled = true;
            _cboCategory.Location = new Point(445, 14);
            _cboCategory.Name = "cboCategory";
            _cboCategory.Size = new Size(181, 21);
            _cboCategory.TabIndex = 1;
            //
            // Label3
            //
            _Label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label3.Location = new Point(369, 17);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(88, 16);
            _Label3.TabIndex = 12;
            _Label3.Text = "Category";
            //
            // Label2
            //
            _Label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label2.Location = new Point(371, 46);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(67, 18);
            _Label2.TabIndex = 11;
            _Label2.Text = "Reference";
            //
            // Label1
            //
            _Label1.Location = new Point(4, 72);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(88, 16);
            _Label1.TabIndex = 10;
            _Label1.Text = "Name";
            //
            // txtReference
            //
            _txtReference.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtReference.Location = new Point(445, 41);
            _txtReference.Name = "txtReference";
            _txtReference.Size = new Size(181, 21);
            _txtReference.TabIndex = 3;
            //
            // Label6
            //
            _Label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label6.Location = new Point(371, 69);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(88, 16);
            _Label6.TabIndex = 6;
            _Label6.Text = "Number";
            //
            // btnReset
            //
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(72, 306);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 4;
            _btnReset.Text = "Reset";
            //
            // FRMStockValuation
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(646, 336);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpParts);
            Controls.Add(_btnReset);
            MinimumSize = new Size(654, 370);
            Name = "FRMStockValuation";
            Text = "Stock Valuation Report";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpParts, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            _grpParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgParts).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDataGrid();

            // PopulateDatagrid()

            ResetFilters();
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
        private DataView _dvParts;

        private DataView PartsDataview
        {
            get
            {
                return _dvParts;
            }

            set
            {
                _dvParts = value;
                _dvParts.AllowNew = false;
                _dvParts.AllowEdit = false;
                _dvParts.AllowDelete = false;
                _dvParts.Table.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString();
                dgParts.DataSource = PartsDataview;
            }
        }

        private DataRow SelectedPartDataRow
        {
            get
            {
                if (!(dgParts.CurrentRowIndex == -1))
                {
                    return PartsDataview[dgParts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupDataGrid()
        {
            var tbStyle = dgParts.TableStyles[0];
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 150;
            Category.NullText = "";
            tbStyle.GridColumnStyles.Add(Category);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 150;
            Name.NullText = "";
            tbStyle.GridColumnStyles.Add(Name);
            var Number = new DataGridLabelColumn();
            Number.Format = "";
            Number.FormatInfo = null;
            Number.HeaderText = "Number";
            Number.MappingName = "Number";
            Number.ReadOnly = true;
            Number.Width = 75;
            Number.NullText = "";
            tbStyle.GridColumnStyles.Add(Number);
            var Reference = new DataGridLabelColumn();
            Reference.Format = "";
            Reference.FormatInfo = null;
            Reference.HeaderText = "Reference";
            Reference.MappingName = "Reference";
            Reference.ReadOnly = true;
            Reference.Width = 75;
            Reference.NullText = "";
            tbStyle.GridColumnStyles.Add(Reference);
            var ReplacementCost = new DataGridLabelColumn();
            ReplacementCost.Format = "C";
            ReplacementCost.FormatInfo = null;
            ReplacementCost.HeaderText = "Cost";
            ReplacementCost.MappingName = "ReplacementCost";
            ReplacementCost.ReadOnly = true;
            ReplacementCost.Width = 100;
            ReplacementCost.NullText = "£0.00";
            tbStyle.GridColumnStyles.Add(ReplacementCost);
            var Undistributed = new DataGridLabelColumn();
            Undistributed.Format = "C";
            Undistributed.FormatInfo = null;
            Undistributed.HeaderText = "Undistributed";
            Undistributed.MappingName = "Undistributed";
            Undistributed.ReadOnly = true;
            Undistributed.Width = 100;
            Undistributed.NullText = "£0.00";
            tbStyle.GridColumnStyles.Add(Undistributed);
            var Supplier = new DataGridLabelColumn();
            Supplier.Format = "";
            Supplier.FormatInfo = null;
            Supplier.HeaderText = "Supplier";
            Supplier.MappingName = "Supplier";
            Supplier.ReadOnly = true;
            Supplier.Width = 250;
            Supplier.NullText = "No Supplier";
            tbStyle.GridColumnStyles.Add(Supplier);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString();
            dgParts.TableStyles.Add(tbStyle);
        }

        private void FRMStockValuation_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void txtReference_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDatagrid();
            RunFilter();
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            PopulateDatagrid();
            RunFilter();
        }

        private void chkExact_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDatagrid();
            RunFilter();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void dgParts_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedPartDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMPart), true, new object[] { SelectedPartDataRow["PartID"], true });
            PopulateDatagrid();
            RunFilter();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void PopulateDatagrid()
        {
            try
            {
                int WarehouseID = 0;
                int VanID = 0;
                if (!((Combo.get_GetSelectedItemValue(cboLocation) ?? "") == "0"))
                {
                    if (Combo.get_GetSelectedItemValue(cboLocation).StartsWith("W"))
                    {
                        WarehouseID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLocation).Replace("W", ""));
                    }
                    else
                    {
                        VanID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLocation).Replace("V", ""));
                    }
                }

                PartsDataview = new DataView(App.DB.Part.Stock_Valuation(0, WarehouseID, VanID, txtLocation.Text.Trim(), chkExact.Checked).Tables[0]);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            // PopulateDatagrid()

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Location"));
            dt.Columns.Add(new DataColumn("Name"));
            foreach (DataRow row in App.DB.Warehouse.Warehouse_GetAll().Table.Rows)
            {
                var r = dt.NewRow();
                r["Location"] = "W" + row["WarehouseID"];
                r["Name"] = row["Name"];
                dt.Rows.Add(r);
            }

            foreach (DataRow row in App.DB.Van.Van_GetAll(false).Table.Rows)
            {
                var r = dt.NewRow();
                r["Location"] = "V" + row["VanID"];
                r["Name"] = row["Registration"];
                dt.Rows.Add(r);
            }

            var argc = cboLocation;
            Combo.SetUpCombo(ref argc, dt, "Location", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            var argcombo = cboLocation;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argc1 = cboCategory;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            var argcombo1 = cboCategory;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            txtName.Text = "";
            txtNumber.Text = "";
            txtReference.Text = "";
            RunFilter();
        }

        private void RunFilter()
        {
            string whereClause = "1 = 1";
            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboCategory)) == 0))
            {
                whereClause += " AND CategoryID = " + Combo.get_GetSelectedItemValue(cboCategory) + "";
            }

            if (!(txtName.Text.Trim().Length == 0))
            {
                whereClause += " AND Name LIKE '%" + txtName.Text.Trim() + "%'";
            }

            if (!(txtNumber.Text.Trim().Length == 0))
            {
                whereClause += " AND Number LIKE '%" + txtNumber.Text.Trim() + "%'";
            }

            if (!(txtReference.Text.Trim().Length == 0))
            {
                whereClause += " AND Reference LIKE '%" + txtReference.Text.Trim() + "%'";
            }

            PartsDataview.RowFilter = whereClause;
        }

        public void Export()
        {
            var exportData = new DataTable();
            exportData.Columns.Add("Category");
            exportData.Columns.Add("Name");
            exportData.Columns.Add("Number");
            exportData.Columns.Add("Reference");
            exportData.Columns.Add("Cost");
            exportData.Columns.Add("Undistributed");
            exportData.Columns.Add("Supplier");
            for (int itm = 0, loopTo = ((DataView)dgParts.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgParts.CurrentRowIndex = itm;
                DataRow newRw;
                newRw = exportData.NewRow();
                newRw["Category"] = SelectedPartDataRow["Category"];
                newRw["Name"] = SelectedPartDataRow["Name"];
                newRw["Number"] = SelectedPartDataRow["Number"];
                newRw["Reference"] = SelectedPartDataRow["Reference"];
                newRw["Cost"] = Strings.Format(SelectedPartDataRow["ReplacementCost"], "F");
                newRw["Undistributed"] = Strings.Format(SelectedPartDataRow["Undistributed"], "F");
                newRw["Supplier"] = SelectedPartDataRow["Supplier"];
                exportData.Rows.Add(newRw);
                dgParts.UnSelect(itm);
            }

            ExportHelper.Export(exportData, "Stock Value Report", Enums.ExportType.XLS);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}