using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class DLGPickPartProductSupplier : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public DLGPickPartProductSupplier() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += DLGPickPartProductSupplier_Load;

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

        private TextBox _txtFilter;

        internal TextBox txtFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFilter != null)
                {
                    _txtFilter.TextChanged -= txtFilter_TextChanged;
                }

                _txtFilter = value;
                if (_txtFilter != null)
                {
                    _txtFilter.TextChanged += txtFilter_TextChanged;
                }
            }
        }

        private GroupBox _grpResults;

        internal GroupBox grpResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpResults != null)
                {
                }

                _grpResults = value;
                if (_grpResults != null)
                {
                }
            }
        }

        private Button _btnOK;

        internal Button btnOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
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

        private DataGrid _dgResults;

        internal DataGrid dgResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgResults != null)
                {
                    _dgResults.DoubleClick -= dgResults_DoubleClick;
                }

                _dgResults = value;
                if (_dgResults != null)
                {
                    _dgResults.DoubleClick += dgResults_DoubleClick;
                }
            }
        }

        private Label _lblDetails;

        internal Label lblDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDetails != null)
                {
                }

                _lblDetails = value;
                if (_lblDetails != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _Label1 = new Label();
            _txtFilter = new TextBox();
            _txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
            _grpResults = new GroupBox();
            _dgResults = new DataGrid();
            _dgResults.DoubleClick += new EventHandler(dgResults_DoubleClick);
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _lblDetails = new Label();
            _grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgResults).BeginInit();
            SuspendLayout();
            // 
            // Label1
            // 
            _Label1.Location = new Point(8, 72);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(100, 24);
            _Label1.TabIndex = 2;
            _Label1.Text = "Filter By Name";
            // 
            // txtFilter
            // 
            _txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFilter.Location = new Point(104, 72);
            _txtFilter.Name = "txtFilter";
            _txtFilter.Size = new Size(584, 21);
            _txtFilter.TabIndex = 1;
            _txtFilter.Text = "";
            // 
            // grpResults
            // 
            _grpResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpResults.Controls.Add(_dgResults);
            _grpResults.Location = new Point(8, 104);
            _grpResults.Name = "grpResults";
            _grpResults.Size = new Size(680, 216);
            _grpResults.TabIndex = 4;
            _grpResults.TabStop = false;
            _grpResults.Text = "Select record and click OK";
            // 
            // dgResults
            // 
            _dgResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgResults.DataMember = "";
            _dgResults.HeaderForeColor = SystemColors.ControlText;
            _dgResults.Location = new Point(8, 25);
            _dgResults.Name = "dgResults";
            _dgResults.Size = new Size(664, 183);
            _dgResults.TabIndex = 2;
            // 
            // btnOK
            // 
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(632, 328);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(56, 23);
            _btnOK.TabIndex = 3;
            _btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(8, 328);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(56, 23);
            _btnCancel.TabIndex = 4;
            _btnCancel.Text = "Cancel";
            // 
            // lblDetails
            // 
            _lblDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _lblDetails.Location = new Point(8, 40);
            _lblDetails.Name = "lblDetails";
            _lblDetails.Size = new Size(680, 24);
            _lblDetails.TabIndex = 7;
            // 
            // DLGPickPartProductSupplier
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(696, 358);
            ControlBox = false;
            Controls.Add(_lblDetails);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            Controls.Add(_grpResults);
            Controls.Add(_txtFilter);
            Controls.Add(_Label1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(704, 392);
            Name = "DLGPickPartProductSupplier";
            Text = "Find {0}";
            Controls.SetChildIndex(_Label1, 0);
            Controls.SetChildIndex(_txtFilter, 0);
            Controls.SetChildIndex(_grpResults, 0);
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_lblDetails, 0);
            _grpResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgResults).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            ActiveControl = txtFilter;
            txtFilter.Focus();
            SetupDG();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _ID;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        private Entity.Sys.Enums.TableNames _TableToSearch = Entity.Sys.Enums.TableNames.NO_TABLE;

        public Entity.Sys.Enums.TableNames TableToSearch
        {
            get
            {
                return _TableToSearch;
            }

            set
            {
                _TableToSearch = value;
                Text = "Pick From Available Suppliers";
                var switchExpr = TableToSearch;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.TableNames.tblPartSupplier:
                        {
                            Records = App.DB.PartSupplier.Get_ByPartID(ID);
                            var oPart = App.DB.Part.Part_Get(ID);
                            lblDetails.Text = "Select supplier for part : " + oPart.Name + " (" + oPart.Number + ")";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblProductSupplier:
                        {
                            Records = App.DB.ProductSupplier.Get_ByProductID(ID);
                            var oProduct = App.DB.Product.Product_Get(ID);
                            lblDetails.Text = "Select supplier for product : " + oProduct.Name + " (" + oProduct.Number + ")";
                            break;
                        }
                }
            }
        }

        private DataView _dvRecords;

        private DataView Records
        {
            get
            {
                return _dvRecords;
            }

            set
            {
                _dvRecords = value;
                _dvRecords.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
                _dvRecords.AllowNew = false;
                _dvRecords.AllowEdit = false;
                _dvRecords.AllowDelete = false;
                dgResults.DataSource = Records;
            }
        }

        private DataRow SelectedDataRow
        {
            get
            {
                if (!(dgResults.CurrentRowIndex == -1))
                {
                    return Records[dgResults.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupDG()
        {
            var tStyle = dgResults.TableStyles[0];
            var switchExpr = TableToSearch;
            switch (switchExpr)
            {
                case Entity.Sys.Enums.TableNames.tblPartSupplier:
                    {
                        var Supplier = new DataGridLabelColumn();
                        Supplier.Format = "";
                        Supplier.FormatInfo = null;
                        Supplier.HeaderText = "Supplier";
                        Supplier.MappingName = "SupplierName";
                        Supplier.ReadOnly = true;
                        Supplier.Width = 130;
                        Supplier.NullText = "";
                        tStyle.GridColumnStyles.Add(Supplier);
                        var PartName = new DataGridLabelColumn();
                        PartName.Format = "";
                        PartName.FormatInfo = null;
                        PartName.HeaderText = "Name";
                        PartName.MappingName = "Name";
                        PartName.ReadOnly = true;
                        PartName.Width = 130;
                        PartName.NullText = "";
                        tStyle.GridColumnStyles.Add(PartName);
                        var PartNumber = new DataGridLabelColumn();
                        PartNumber.Format = "";
                        PartNumber.FormatInfo = null;
                        PartNumber.HeaderText = "Part Number";
                        PartNumber.MappingName = "Number";
                        PartNumber.ReadOnly = true;
                        PartNumber.Width = 130;
                        PartNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(PartNumber);
                        var QuantityInPack = new DataGridLabelColumn();
                        QuantityInPack.Format = "";
                        QuantityInPack.FormatInfo = null;
                        QuantityInPack.HeaderText = "Quantity In Pack";
                        QuantityInPack.MappingName = "QuantityInPack";
                        QuantityInPack.ReadOnly = true;
                        QuantityInPack.Width = 130;
                        QuantityInPack.NullText = "";
                        tStyle.GridColumnStyles.Add(QuantityInPack);
                        var PartCode = new DataGridLabelColumn();
                        PartCode.Format = "";
                        PartCode.FormatInfo = null;
                        PartCode.HeaderText = "Supplier Part Number";
                        PartCode.MappingName = "PartCode";
                        PartCode.ReadOnly = true;
                        PartCode.Width = 130;
                        PartCode.NullText = "";
                        tStyle.GridColumnStyles.Add(PartCode);
                        var Price = new DataGridLabelColumn();
                        Price.Format = "";
                        Price.FormatInfo = null;
                        Price.HeaderText = "Price";
                        Price.MappingName = "Price";
                        Price.ReadOnly = true;
                        Price.Width = 130;
                        Price.NullText = "";
                        tStyle.GridColumnStyles.Add(Price);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblProductSupplier:
                    {
                        var Supplier = new DataGridLabelColumn();
                        Supplier.Format = "";
                        Supplier.FormatInfo = null;
                        Supplier.HeaderText = "Supplier";
                        Supplier.MappingName = "SupplierName";
                        Supplier.ReadOnly = true;
                        Supplier.Width = 130;
                        Supplier.NullText = "";
                        tStyle.GridColumnStyles.Add(Supplier);
                        var ProductName = new DataGridLabelColumn();
                        ProductName.Format = "";
                        ProductName.FormatInfo = null;
                        ProductName.HeaderText = "Name";
                        ProductName.MappingName = "typemakemodel";
                        ProductName.ReadOnly = true;
                        ProductName.Width = 130;
                        ProductName.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductName);
                        var ProductNumber = new DataGridLabelColumn();
                        ProductNumber.Format = "";
                        ProductNumber.FormatInfo = null;
                        ProductNumber.HeaderText = "Product Number";
                        ProductNumber.MappingName = "Number";
                        ProductNumber.ReadOnly = true;
                        ProductNumber.Width = 130;
                        ProductNumber.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductNumber);
                        var QuantityInPack = new DataGridLabelColumn();
                        QuantityInPack.Format = "";
                        QuantityInPack.FormatInfo = null;
                        QuantityInPack.HeaderText = "Quantity In Pack";
                        QuantityInPack.MappingName = "QuantityInPack";
                        QuantityInPack.ReadOnly = true;
                        QuantityInPack.Width = 130;
                        QuantityInPack.NullText = "";
                        tStyle.GridColumnStyles.Add(QuantityInPack);
                        var ProductCode = new DataGridLabelColumn();
                        ProductCode.Format = "";
                        ProductCode.FormatInfo = null;
                        ProductCode.HeaderText = "Supplier Product Number";
                        ProductCode.MappingName = "ProductCode";
                        ProductCode.ReadOnly = true;
                        ProductCode.Width = 130;
                        ProductCode.NullText = "";
                        tStyle.GridColumnStyles.Add(ProductCode);
                        var Price = new DataGridLabelColumn();
                        Price.Format = "";
                        Price.FormatInfo = null;
                        Price.HeaderText = "Price";
                        Price.MappingName = "Price";
                        Price.ReadOnly = true;
                        Price.Width = 130;
                        Price.NullText = "";
                        tStyle.GridColumnStyles.Add(Price);
                        break;
                    }
            }

            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
            dgResults.TableStyles.Add(tStyle);
        }

        private void DLGPickPartProductSupplier_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgResults_DoubleClick(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SelectItem()
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("No record selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var switchExpr = TableToSearch;
            switch (switchExpr)
            {
                case Entity.Sys.Enums.TableNames.tblPartSupplier:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["PartSupplierID"]);
                        break;
                    }

                case Entity.Sys.Enums.TableNames.tblProductSupplier:
                    {
                        ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow["ProductSupplierID"]);
                        break;
                    }
            }

            DialogResult = DialogResult.OK;
        }

        private void RunFilter()
        {
            string whereClause = "Deleted = 0";
            if (!(txtFilter.Text.Trim().Length == 0))
            {
                whereClause += " AND SupplierName LIKE '" + txtFilter.Text.Trim() + "%'";
            }

            Records.RowFilter = whereClause;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}