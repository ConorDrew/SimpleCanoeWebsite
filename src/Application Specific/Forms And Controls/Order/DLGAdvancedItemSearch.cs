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
    public class DLGAdvancedItemSearch : FRMBaseForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public DLGAdvancedItemSearch() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            SetupPartsResultsDataGrid();
            var argc = cboSearchFor;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Setup_Advanced_Search_Options(Entity.Sys.Enums.MenuTypes.Spares), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
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
        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private Button _btnSearch;

        internal Button btnSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSearch != null)
                {
                    _btnSearch.Click -= btnSearch_Click;
                }

                _btnSearch = value;
                if (_btnSearch != null)
                {
                    _btnSearch.Click += btnSearch_Click;
                }
            }
        }

        private TextBox _txtCriteria;

        internal TextBox txtCriteria
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCriteria;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCriteria != null)
                {
                }

                _txtCriteria = value;
                if (_txtCriteria != null)
                {
                }
            }
        }

        private Label _Label18;

        internal Label Label18
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label18;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label18 != null)
                {
                }

                _Label18 = value;
                if (_Label18 != null)
                {
                }
            }
        }

        private ComboBox _cboSearchOn;

        internal ComboBox cboSearchOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSearchOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSearchOn != null)
                {
                }

                _cboSearchOn = value;
                if (_cboSearchOn != null)
                {
                }
            }
        }

        private Label _label17;

        internal Label label17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _label17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_label17 != null)
                {
                }

                _label17 = value;
                if (_label17 != null)
                {
                }
            }
        }

        private ComboBox _cboSearchFor;

        internal ComboBox cboSearchFor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSearchFor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSearchFor != null)
                {
                    _cboSearchFor.SelectedIndexChanged -= cboSearchFor_SelectedIndexChanged;
                }

                _cboSearchFor = value;
                if (_cboSearchFor != null)
                {
                    _cboSearchFor.SelectedIndexChanged += cboSearchFor_SelectedIndexChanged;
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

        private Button _btnFindSupplier;

        internal Button btnFindSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSupplier != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnFindSupplier.Click -= btnFindSupplier_Click;
                }

                _btnFindSupplier = value;
                if (_btnFindSupplier != null)
                {
                    _btnFindSupplier.Click += btnFindSupplier_Click;
                }
            }
        }

        private TextBox _txtSupplier;

        internal TextBox txtSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplier != null)
                {
                }

                _txtSupplier = value;
                if (_txtSupplier != null)
                {
                }
            }
        }

        private Label _Label7;

        internal Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label7 != null)
                {
                }

                _Label7 = value;
                if (_Label7 != null)
                {
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
                }

                _dgResults = value;
                if (_dgResults != null)
                {
                }
            }
        }

        private Button _btnRequest;

        internal Button btnRequest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRequest;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRequest != null)
                {
                    _btnRequest.Click -= btnRequest_Click;
                }

                _btnRequest = value;
                if (_btnRequest != null)
                {
                    _btnRequest.Click += btnRequest_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _btnFindSupplier = new Button();
            _btnFindSupplier.Click += new EventHandler(btnFindSupplier_Click);
            _txtSupplier = new TextBox();
            _Label7 = new Label();
            _dgResults = new DataGrid();
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _txtCriteria = new TextBox();
            _Label18 = new Label();
            _cboSearchOn = new ComboBox();
            _label17 = new Label();
            _cboSearchFor = new ComboBox();
            _cboSearchFor.SelectedIndexChanged += new EventHandler(cboSearchFor_SelectedIndexChanged);
            _Label5 = new Label();
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnRequest = new Button();
            _btnRequest.Click += new EventHandler(btnRequest_Click);
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgResults).BeginInit();
            SuspendLayout();
            //
            // GroupBox1
            //
            _GroupBox1.Controls.Add(_btnFindSupplier);
            _GroupBox1.Controls.Add(_txtSupplier);
            _GroupBox1.Controls.Add(_Label7);
            _GroupBox1.Controls.Add(_dgResults);
            _GroupBox1.Controls.Add(_btnSearch);
            _GroupBox1.Controls.Add(_txtCriteria);
            _GroupBox1.Controls.Add(_Label18);
            _GroupBox1.Controls.Add(_cboSearchOn);
            _GroupBox1.Controls.Add(_label17);
            _GroupBox1.Controls.Add(_cboSearchFor);
            _GroupBox1.Controls.Add(_Label5);
            _GroupBox1.Location = new Point(8, 48);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(608, 408);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Search";
            //
            // btnFindSupplier
            //
            _btnFindSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSupplier.BackColor = Color.White;
            _btnFindSupplier.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSupplier.Location = new Point(560, 379);
            _btnFindSupplier.Name = "btnFindSupplier";
            _btnFindSupplier.Size = new Size(32, 24);
            _btnFindSupplier.TabIndex = 95;
            _btnFindSupplier.Text = "...";
            //
            // txtSupplier
            //
            _txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSupplier.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSupplier.Location = new Point(88, 379);
            _txtSupplier.Name = "txtSupplier";
            _txtSupplier.ReadOnly = true;
            _txtSupplier.Size = new Size(464, 21);
            _txtSupplier.TabIndex = 94;
            _txtSupplier.Text = "";
            //
            // Label7
            //
            _Label7.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label7.Location = new Point(16, 376);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(64, 24);
            _Label7.TabIndex = 96;
            _Label7.Text = "Supplier";
            //
            // dgResults
            //
            _dgResults.DataMember = "";
            _dgResults.HeaderForeColor = SystemColors.ControlText;
            _dgResults.Location = new Point(8, 88);
            _dgResults.Name = "dgResults";
            _dgResults.Size = new Size(592, 280);
            _dgResults.TabIndex = 8;
            //
            // btnSearch
            //
            _btnSearch.Location = new Point(520, 56);
            _btnSearch.Name = "btnSearch";
            _btnSearch.TabIndex = 6;
            _btnSearch.Text = "Search";
            //
            // txtCriteria
            //
            _txtCriteria.Location = new Point(104, 56);
            _txtCriteria.Name = "txtCriteria";
            _txtCriteria.Size = new Size(400, 21);
            _txtCriteria.TabIndex = 5;
            _txtCriteria.Text = "";
            //
            // Label18
            //
            _Label18.Location = new Point(8, 56);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(80, 23);
            _Label18.TabIndex = 4;
            _Label18.Text = "Criteria:";
            //
            // cboSearchOn
            //
            _cboSearchOn.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSearchOn.Location = new Point(400, 24);
            _cboSearchOn.Name = "cboSearchOn";
            _cboSearchOn.Size = new Size(200, 21);
            _cboSearchOn.TabIndex = 3;
            //
            // label17
            //
            _label17.Location = new Point(312, 24);
            _label17.Name = "label17";
            _label17.Size = new Size(80, 23);
            _label17.TabIndex = 2;
            _label17.Text = "Search On:";
            //
            // cboSearchFor
            //
            _cboSearchFor.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSearchFor.Items.AddRange(new object[] { "Products", "Parts" });
            _cboSearchFor.Location = new Point(104, 24);
            _cboSearchFor.Name = "cboSearchFor";
            _cboSearchFor.Size = new Size(200, 21);
            _cboSearchFor.TabIndex = 1;
            //
            // Label5
            //
            _Label5.Location = new Point(8, 24);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(88, 23);
            _Label5.TabIndex = 0;
            _Label5.Text = "Search For:";
            //
            // btnCancel
            //
            _btnCancel.Location = new Point(120, 464);
            _btnCancel.Name = "btnCancel";
            _btnCancel.TabIndex = 7;
            _btnCancel.Text = "Cancel";
            //
            // btnRequest
            //
            _btnRequest.Location = new Point(8, 464);
            _btnRequest.Name = "btnRequest";
            _btnRequest.Size = new Size(104, 23);
            _btnRequest.TabIndex = 8;
            _btnRequest.Text = "Request Prices";
            //
            // DLGAdvancedItemSearch
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(624, 494);
            ControlBox = false;
            Controls.Add(_btnRequest);
            Controls.Add(_GroupBox1);
            Controls.Add(_btnCancel);
            MaximumSize = new Size(632, 528);
            MinimumSize = new Size(632, 528);
            Name = "DLGAdvancedItemSearch";
            Text = "Advanced Search";
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_btnRequest, 0);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgResults).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _quoteID;

        public int QuoteID
        {
            get
            {
                return _quoteID;
            }

            set
            {
                _quoteID = value;
            }
        }

        private Entity.Suppliers.Supplier _supplier;

        public Entity.Suppliers.Supplier Supplier
        {
            get
            {
                return _supplier;
            }

            set
            {
                _supplier = value;
                if (_supplier is object)
                {
                    txtSupplier.Text = _supplier.Name + " (" + _supplier.AccountNumber + ")";
                }
            }
        }

        public DataView ItemDataView
        {
            get
            {
                return m_dTable2;
            }

            set
            {
                m_dTable2 = value;
                m_dTable2.Table.TableName = "tblItem";
                m_dTable2.AllowNew = false;
                m_dTable2.AllowEdit = false;
                m_dTable2.AllowDelete = false;
                dgResults.DataSource = ItemDataView;
            }
        }

        private DataView m_dTable2 = null;

        private DataRow SelectedItemDataRow
        {
            get
            {
                if (!(dgResults.CurrentRowIndex == -1))
                {
                    return ItemDataView[dgResults.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void btnFindSupplier_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSupplier));
            if (!(ID == 0))
            {
                Supplier = App.DB.Supplier.Supplier_Get(ID);
            }
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

        private void cboSearchFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var argc = cboSearchOn;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Setup_Search_On_Options(Entity.Sys.Enums.MenuTypes.Spares, (Entity.Sys.Enums.TableNames)Convert.ToInt32(Combo.get_GetSelectedItemValue(cboSearchFor))), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboSearchFor)) == (double)Entity.Sys.Enums.TableNames.tblPart)
            {
                SetupPartsResultsDataGrid();
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboSearchFor)) == (double)Entity.Sys.Enums.TableNames.tblProduct)
            {
                SetupProductsResultsDataGrid();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboSearchFor)) == (double)Entity.Sys.Enums.TableNames.tblPart)
            {
                ItemDataView = App.DB.Part.Part_Search(txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(cboSearchOn));
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboSearchFor)) == (double)Entity.Sys.Enums.TableNames.tblProduct)
            {
                ItemDataView = App.DB.Product.Product_Search(txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(cboSearchOn));
            }
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            SaveRequests();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public object SetupPartsResultsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgResults);
            dgResults.ReadOnly = false;
            var tStyle = dgResults.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var chk = new DataGridCheckBox();
            chk.HeaderText = "Selected";
            chk.MappingName = "Selected";
            chk.ReadOnly = true;
            chk.Width = 50;
            chk.NullText = "";
            tStyle.GridColumnStyles.Add(chk);
            var PartName = new DataGridLabelColumn();
            PartName.Format = "";
            PartName.FormatInfo = null;
            PartName.HeaderText = "Name";
            PartName.MappingName = "Name";
            PartName.ReadOnly = true;
            PartName.Width = 120;
            PartName.NullText = "";
            tStyle.GridColumnStyles.Add(PartName);
            var PartNumber = new DataGridLabelColumn();
            PartNumber.Format = "";
            PartNumber.FormatInfo = null;
            PartNumber.HeaderText = "Number";
            PartNumber.MappingName = "Number";
            PartNumber.ReadOnly = true;
            PartNumber.Width = 110;
            PartNumber.NullText = "";
            tStyle.GridColumnStyles.Add(PartNumber);
            var PartReference = new DataGridLabelColumn();
            PartReference.Format = "";
            PartReference.FormatInfo = null;
            PartReference.HeaderText = "Part Reference";
            PartReference.MappingName = "Reference";
            PartReference.ReadOnly = true;
            PartReference.Width = 170;
            PartReference.NullText = "";
            tStyle.GridColumnStyles.Add(PartReference);
            var Quantity = new DataGridOrderTextBoxColumn();
            Quantity.Format = "F";
            Quantity.FormatInfo = null;
            Quantity.HeaderText = "Quantity";
            Quantity.MappingName = "QuantityHolder";
            Quantity.ReadOnly = false;
            Quantity.Width = 90;
            Quantity.NullText = "";
            tStyle.GridColumnStyles.Add(Quantity);
            tStyle.ReadOnly = false;
            tStyle.MappingName = "tblItem";
            dgResults.TableStyles.Add(tStyle);
            return default;
        }

        public object SetupProductsResultsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgResults);
            dgResults.ReadOnly = false;
            var tStyle = dgResults.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var chk = new DataGridCheckBox();
            chk.HeaderText = "Selected";
            chk.MappingName = "Selected";
            chk.ReadOnly = true;
            chk.Width = 50;
            chk.NullText = "";
            tStyle.GridColumnStyles.Add(chk);
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
            ProductNumber.HeaderText = "Number";
            ProductNumber.MappingName = "Number";
            ProductNumber.ReadOnly = true;
            ProductNumber.Width = 130;
            ProductNumber.NullText = "";
            tStyle.GridColumnStyles.Add(ProductNumber);
            var ProductReference = new DataGridLabelColumn();
            ProductReference.Format = "";
            ProductReference.FormatInfo = null;
            ProductReference.HeaderText = "Product Reference";
            ProductReference.MappingName = "Reference";
            ProductReference.ReadOnly = true;
            ProductReference.Width = 200;
            ProductReference.NullText = "";
            tStyle.GridColumnStyles.Add(ProductReference);
            var Quantity = new DataGridOrderTextBoxColumn();
            Quantity.Format = "F";
            Quantity.FormatInfo = null;
            Quantity.HeaderText = "Quantity";
            Quantity.MappingName = "QuantityHolder";
            Quantity.ReadOnly = false;
            Quantity.Width = 90;
            Quantity.NullText = "";
            tStyle.GridColumnStyles.Add(Quantity);
            tStyle.ReadOnly = false;
            tStyle.MappingName = "tblItem";
            dgResults.TableStyles.Add(tStyle);
            return default;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private object SaveRequests()
        {
            if (Supplier is null)
            {
                App.ShowMessage("Please select a supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }

            foreach (DataRow row in ItemDataView.Table.Select("Selected = 1"))
            {
                if (Information.IsDBNull(row["QuantityHolder"]) | !Information.IsNumeric(row["QuantityHolder"]))
                {
                    App.ShowMessage("Please enter a quantity for each Item you have checked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return default;
                }
            }

            if (QuoteID > 0)
            {
                foreach (DataRow row in ItemDataView.Table.Select("Selected = 1"))
                {
                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboSearchFor)) == (double)Entity.Sys.Enums.TableNames.tblPart)
                    {
                        var partRequest = new Entity.PartSupplierPriceRequests.PartSupplierPriceRequest();
                        partRequest.SetQuoteID = QuoteID;
                        partRequest.SetPartID = row["partID"];
                        partRequest.SetQuantityInPack = row["QuantityHolder"];
                        partRequest.SetSupplierID = Supplier.SupplierID;
                        partRequest.SetComplete = 0;
                        App.DB.PartPriceRequest.InsertForQuote(partRequest);
                    }
                    else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboSearchFor)) == (double)Entity.Sys.Enums.TableNames.tblProduct)
                    {
                        var productRequest = new Entity.ProductSupplierPriceRequests.ProductSupplierPriceRequest();
                        productRequest.SetQuoteID = QuoteID;
                        productRequest.SetProductID = row["productID"];
                        productRequest.SetQuantityInPack = row["QuantityHolder"];
                        productRequest.SetSupplierID = Supplier.SupplierID;
                        productRequest.SetComplete = 0;
                        App.DB.ProductPriceRequest.InsertForQuote(productRequest);
                    }
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

            return default;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}