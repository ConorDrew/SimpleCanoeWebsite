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
    public class FRMStockUsed : FRMBaseForm, IForm
    {
        public FRMStockUsed() : base()
        {
            base.Load += FRMStockUsed_Load;

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

        private GroupBox _grpParts;

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

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
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

        private ComboBox _cboMonths;

        internal ComboBox cboMonths
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboMonths;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboMonths != null)
                {
                    _cboMonths.SelectedIndexChanged -= cboMonths_SelectedIndexChanged;
                }

                _cboMonths = value;
                if (_cboMonths != null)
                {
                    _cboMonths.SelectedIndexChanged += cboMonths_SelectedIndexChanged;
                }
            }
        }

        private CheckBox _chkQty;

        internal CheckBox chkQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkQty != null)
                {
                    _chkQty.CheckedChanged -= chkQty_CheckedChanged;
                }

                _chkQty = value;
                if (_chkQty != null)
                {
                    _chkQty.CheckedChanged += chkQty_CheckedChanged;
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
            this._grpParts = new System.Windows.Forms.GroupBox();
            this._dgParts = new System.Windows.Forms.DataGrid();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._chkQty = new System.Windows.Forms.CheckBox();
            this._cboMonths = new System.Windows.Forms.ComboBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._txtNumber = new System.Windows.Forms.TextBox();
            this._cboCategory = new System.Windows.Forms.ComboBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtReference = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._btnReset = new System.Windows.Forms.Button();
            this._grpParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgParts)).BeginInit();
            this._grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpParts
            // 
            this._grpParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpParts.Controls.Add(this._dgParts);
            this._grpParts.Location = new System.Drawing.Point(8, 123);
            this._grpParts.Name = "_grpParts";
            this._grpParts.Size = new System.Drawing.Size(697, 175);
            this._grpParts.TabIndex = 2;
            this._grpParts.TabStop = false;
            this._grpParts.Text = "Parts used";
            // 
            // _dgParts
            // 
            this._dgParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgParts.DataMember = "";
            this._dgParts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgParts.Location = new System.Drawing.Point(8, 19);
            this._dgParts.Name = "_dgParts";
            this._dgParts.Size = new System.Drawing.Size(681, 148);
            this._dgParts.TabIndex = 14;
            this._dgParts.DoubleClick += new System.EventHandler(this.dgParts_DoubleClick);
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 306);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 3;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._chkQty);
            this._grpFilter.Controls.Add(this._cboMonths);
            this._grpFilter.Controls.Add(this._Label5);
            this._grpFilter.Controls.Add(this._txtName);
            this._grpFilter.Controls.Add(this._Label4);
            this._grpFilter.Controls.Add(this._txtNumber);
            this._grpFilter.Controls.Add(this._cboCategory);
            this._grpFilter.Controls.Add(this._Label3);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._txtReference);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(697, 105);
            this._grpFilter.TabIndex = 1;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _chkQty
            // 
            this._chkQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkQty.AutoSize = true;
            this._chkQty.Location = new System.Drawing.Point(548, 72);
            this._chkQty.Name = "_chkQty";
            this._chkQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._chkQty.Size = new System.Drawing.Size(133, 17);
            this._chkQty.TabIndex = 16;
            this._chkQty.Text = "Show quantity of 0";
            this._chkQty.UseVisualStyleBackColor = true;
            this._chkQty.CheckedChanged += new System.EventHandler(this.chkQty_CheckedChanged);
            // 
            // _cboMonths
            // 
            this._cboMonths.FormattingEnabled = true;
            this._cboMonths.Location = new System.Drawing.Point(386, 72);
            this._cboMonths.Name = "_cboMonths";
            this._cboMonths.Size = new System.Drawing.Size(82, 21);
            this._cboMonths.TabIndex = 5;
            this._cboMonths.SelectedIndexChanged += new System.EventHandler(this.cboMonths_SelectedIndexChanged);
            // 
            // _Label5
            // 
            this._Label5.Location = new System.Drawing.Point(474, 75);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(53, 18);
            this._Label5.TabIndex = 15;
            this._Label5.Text = "Months";
            // 
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.Location = new System.Drawing.Point(73, 41);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(395, 21);
            this._txtName.TabIndex = 2;
            this._txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(6, 75);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(381, 18);
            this._Label4.TabIndex = 13;
            this._Label4.Text = "Show all parts not used on any job or customer order in the last";
            // 
            // _txtNumber
            // 
            this._txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNumber.Location = new System.Drawing.Point(548, 40);
            this._txtNumber.Name = "_txtNumber";
            this._txtNumber.Size = new System.Drawing.Size(141, 21);
            this._txtNumber.TabIndex = 4;
            this._txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // _cboCategory
            // 
            this._cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboCategory.FormattingEnabled = true;
            this._cboCategory.Location = new System.Drawing.Point(73, 14);
            this._cboCategory.Name = "_cboCategory";
            this._cboCategory.Size = new System.Drawing.Size(395, 21);
            this._cboCategory.TabIndex = 1;
            this._cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(5, 17);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(88, 16);
            this._Label3.TabIndex = 12;
            this._Label3.Text = "Category";
            // 
            // _Label2
            // 
            this._Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label2.Location = new System.Drawing.Point(474, 17);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(67, 18);
            this._Label2.TabIndex = 11;
            this._Label2.Text = "Reference";
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(6, 44);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(88, 16);
            this._Label1.TabIndex = 10;
            this._Label1.Text = "Name";
            // 
            // _txtReference
            // 
            this._txtReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtReference.Location = new System.Drawing.Point(548, 12);
            this._txtReference.Name = "_txtReference";
            this._txtReference.Size = new System.Drawing.Size(141, 21);
            this._txtReference.TabIndex = 3;
            this._txtReference.TextChanged += new System.EventHandler(this.txtReference_TextChanged);
            // 
            // _Label6
            // 
            this._Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label6.Location = new System.Drawing.Point(474, 40);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(88, 16);
            this._Label6.TabIndex = 6;
            this._Label6.Text = "Number";
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(72, 306);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 4;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FRMStockUsed
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(713, 336);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpParts);
            this.Controls.Add(this._btnReset);
            this.MinimumSize = new System.Drawing.Size(721, 370);
            this.Name = "FRMStockUsed";
            this.Text = "Stock Used Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgParts)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDataGrid();
            PopulateDatagrid();
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

        private void SetupDataGrid()
        {
            var tbStyle = dgParts.TableStyles[0];
            var Months = new DataGridLabelColumn();
            Months.Format = "";
            Months.FormatInfo = null;
            Months.HeaderText = "Used within the last (Months)";
            Months.MappingName = "Months";
            Months.ReadOnly = true;
            Months.Width = 100;
            Months.NullText = "Not Used";
            tbStyle.GridColumnStyles.Add(Months);
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
            var StockLevel = new DataGridLabelColumn();
            StockLevel.Format = "";
            StockLevel.FormatInfo = null;
            StockLevel.HeaderText = "Qty";
            StockLevel.MappingName = "StockLevel";
            StockLevel.ReadOnly = true;
            StockLevel.Width = 100;
            StockLevel.NullText = "0";
            tbStyle.GridColumnStyles.Add(StockLevel);
            var WarehouseStock = new DataGridLabelColumn();
            WarehouseStock.Format = "";
            WarehouseStock.FormatInfo = null;
            WarehouseStock.HeaderText = "Warehouse Qty";
            WarehouseStock.MappingName = "WarehouseStock";
            WarehouseStock.ReadOnly = true;
            WarehouseStock.Width = 100;
            WarehouseStock.NullText = "0";
            tbStyle.GridColumnStyles.Add(WarehouseStock);
            var VanStock = new DataGridLabelColumn();
            VanStock.Format = "";
            VanStock.FormatInfo = null;
            VanStock.HeaderText = "Van Qty";
            VanStock.MappingName = "VanStock";
            VanStock.ReadOnly = true;
            VanStock.Width = 100;
            VanStock.NullText = "0";
            tbStyle.GridColumnStyles.Add(VanStock);
            var ReplacementCost = new DataGridLabelColumn();
            ReplacementCost.Format = "C";
            ReplacementCost.FormatInfo = null;
            ReplacementCost.HeaderText = "Cost";
            ReplacementCost.MappingName = "ReplacementCost";
            ReplacementCost.ReadOnly = true;
            ReplacementCost.Width = 100;
            ReplacementCost.NullText = "£0.00";
            tbStyle.GridColumnStyles.Add(ReplacementCost);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString();
            dgParts.TableStyles.Add(tbStyle);
        }

        private void FRMStockUsed_Load(object sender, EventArgs e)
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

        private void cboMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void chkQty_CheckedChanged(object sender, EventArgs e)
        {
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

        private void PopulateDatagrid()
        {
            try
            {
                PartsDataview = App.DB.Part.Stock_Used();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            PopulateDatagrid();
            var argc = cboCategory;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            var argcombo = cboCategory;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            txtName.Text = "";
            txtNumber.Text = "";
            txtReference.Text = "";
            var argc1 = cboMonths;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.get_Count(1, 36), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            var argcombo1 = cboMonths;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            chkQty.Checked = false;
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

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboMonths)) == 0))
            {
                whereClause += " AND (Months = 0 OR Months > " + Combo.get_GetSelectedItemValue(cboMonths) + ")";
            }

            if (!chkQty.Checked)
            {
                whereClause += " AND StockLevel > 0";
            }

            PartsDataview.RowFilter = whereClause;
        }

        public void Export()
        {
            var exportData = new DataTable();
            exportData.Columns.Add("Used with the last (Months)");
            exportData.Columns.Add("Category");
            exportData.Columns.Add("Name");
            exportData.Columns.Add("Number");
            exportData.Columns.Add("Reference");
            exportData.Columns.Add("Cost");
            exportData.Columns.Add("Total Stock");
            exportData.Columns.Add("Warehouse Stock");
            exportData.Columns.Add("Van Stock");
            for (int itm = 0, loopTo = ((DataView)dgParts.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgParts.CurrentRowIndex = itm;
                DataRow newRw;
                newRw = exportData.NewRow();
                newRw["Used with the last (Months)"] = SelectedPartDataRow["Months"];
                newRw["Category"] = SelectedPartDataRow["Category"];
                newRw["Name"] = SelectedPartDataRow["Name"];
                newRw["Number"] = SelectedPartDataRow["Number"];
                newRw["Reference"] = SelectedPartDataRow["Reference"];
                if (SelectedPartDataRow["ReplacementCost"] == DBNull.Value)
                {
                    newRw["Cost"] = null;
                }
                else
                {
                    newRw["Cost"] = Strings.Format(SelectedPartDataRow["ReplacementCost"], "F");
                }

                newRw["Total Stock"] = Strings.Format(SelectedPartDataRow["StockLevel"], "F");
                newRw["Warehouse Stock"] = Strings.Format(SelectedPartDataRow["WarehouseStock"], "F");
                newRw["Van Stock"] = Strings.Format(SelectedPartDataRow["VanStock"], "F");
                exportData.Rows.Add(newRw);
                dgParts.UnSelect(itm);
            }

            ExportHelper.Export(exportData, "Stock Used Report", Enums.ExportType.XLS);
        }
    }
}