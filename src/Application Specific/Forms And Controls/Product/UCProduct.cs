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
    public class UCProduct : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCProduct() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCProduct_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboMakeID;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Makes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboModelID;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Models).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc2 = cboTypeID;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Types).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);

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
        private TabControl _TabControl1;

        internal TabControl TabControl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabControl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabControl1 != null)
                {
                }

                _TabControl1 = value;
                if (_TabControl1 != null)
                {
                }
            }
        }

        private TabPage _tabMainDetails;

        internal TabPage tabMainDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabMainDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabMainDetails != null)
                {
                }

                _tabMainDetails = value;
                if (_tabMainDetails != null)
                {
                }
            }
        }

        private GroupBox _grpProduct;

        internal GroupBox grpProduct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpProduct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpProduct != null)
                {
                }

                _grpProduct = value;
                if (_grpProduct != null)
                {
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
                }

                _txtNumber = value;
                if (_txtNumber != null)
                {
                }
            }
        }

        private Label _lblNumber;

        internal Label lblNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNumber != null)
                {
                }

                _lblNumber = value;
                if (_lblNumber != null)
                {
                }
            }
        }

        private ComboBox _cboTypeID;

        internal ComboBox cboTypeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTypeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTypeID != null)
                {
                }

                _cboTypeID = value;
                if (_cboTypeID != null)
                {
                }
            }
        }

        private Label _lblTypeID;

        internal Label lblTypeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTypeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTypeID != null)
                {
                }

                _lblTypeID = value;
                if (_lblTypeID != null)
                {
                }
            }
        }

        private ComboBox _cboMakeID;

        internal ComboBox cboMakeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboMakeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboMakeID != null)
                {
                }

                _cboMakeID = value;
                if (_cboMakeID != null)
                {
                }
            }
        }

        private Label _lblMakeID;

        internal Label lblMakeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMakeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMakeID != null)
                {
                }

                _lblMakeID = value;
                if (_lblMakeID != null)
                {
                }
            }
        }

        private ComboBox _cboModelID;

        internal ComboBox cboModelID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboModelID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboModelID != null)
                {
                }

                _cboModelID = value;
                if (_cboModelID != null)
                {
                }
            }
        }

        private Label _lblModelID;

        internal Label lblModelID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblModelID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblModelID != null)
                {
                }

                _lblModelID = value;
                if (_lblModelID != null)
                {
                }
            }
        }

        private TextBox _txtNotes;

        internal TextBox txtNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotes != null)
                {
                }

                _txtNotes = value;
                if (_txtNotes != null)
                {
                }
            }
        }

        private Label _lblNotes;

        internal Label lblNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNotes != null)
                {
                }

                _lblNotes = value;
                if (_lblNotes != null)
                {
                }
            }
        }

        private TabPage _tabSuppliers;

        internal TabPage tabSuppliers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabSuppliers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabSuppliers != null)
                {
                }

                _tabSuppliers = value;
                if (_tabSuppliers != null)
                {
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

        private DataGrid _dgProductSuppliers;

        internal DataGrid dgProductSuppliers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgProductSuppliers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgProductSuppliers != null)
                {
                    _dgProductSuppliers.DoubleClick -= dgProductSuppliers_DoubleClick;
                }

                _dgProductSuppliers = value;
                if (_dgProductSuppliers != null)
                {
                    _dgProductSuppliers.DoubleClick += dgProductSuppliers_DoubleClick;
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

        private TextBox _txtSellPrice;

        internal TextBox txtSellPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSellPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSellPrice != null)
                {
                }

                _txtSellPrice = value;
                if (_txtSellPrice != null)
                {
                }
            }
        }

        private TextBox _txtRecommendedQuantity;

        internal TextBox txtRecommendedQuantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRecommendedQuantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRecommendedQuantity != null)
                {
                }

                _txtRecommendedQuantity = value;
                if (_txtRecommendedQuantity != null)
                {
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

        private TextBox _txtMinimumQuantity;

        internal TextBox txtMinimumQuantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMinimumQuantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMinimumQuantity != null)
                {
                }

                _txtMinimumQuantity = value;
                if (_txtMinimumQuantity != null)
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
                }

                _txtReference = value;
                if (_txtReference != null)
                {
                }
            }
        }

        private TabPage _tabAssociatedParts;

        internal TabPage tabAssociatedParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabAssociatedParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabAssociatedParts != null)
                {
                }

                _tabAssociatedParts = value;
                if (_tabAssociatedParts != null)
                {
                }
            }
        }

        private GroupBox _grpSupplier;

        internal GroupBox grpSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSupplier != null)
                {
                }

                _grpSupplier = value;
                if (_grpSupplier != null)
                {
                }
            }
        }

        private GroupBox _grpAssociatedParts;

        internal GroupBox grpAssociatedParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAssociatedParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAssociatedParts != null)
                {
                }

                _grpAssociatedParts = value;
                if (_grpAssociatedParts != null)
                {
                }
            }
        }

        private DataGrid _dgAssociatedParts;

        internal DataGrid dgAssociatedParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAssociatedParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAssociatedParts != null)
                {
                    _dgAssociatedParts.DoubleClick -= dgAssociatedParts_DoubleClick;
                    _dgAssociatedParts.Click -= dgAssociatedParts_Clicks;
                }

                _dgAssociatedParts = value;
                if (_dgAssociatedParts != null)
                {
                    _dgAssociatedParts.DoubleClick += dgAssociatedParts_DoubleClick;
                    _dgAssociatedParts.Click += dgAssociatedParts_Clicks;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _TabControl1 = new TabControl();
            _tabMainDetails = new TabPage();
            _grpProduct = new GroupBox();
            _txtReference = new TextBox();
            _Label2 = new Label();
            _txtRecommendedQuantity = new TextBox();
            _Label6 = new Label();
            _txtMinimumQuantity = new TextBox();
            _Label5 = new Label();
            _txtSellPrice = new TextBox();
            _Label1 = new Label();
            _txtNumber = new TextBox();
            _lblNumber = new Label();
            _cboTypeID = new ComboBox();
            _lblTypeID = new Label();
            _cboMakeID = new ComboBox();
            _lblMakeID = new Label();
            _cboModelID = new ComboBox();
            _lblModelID = new Label();
            _txtNotes = new TextBox();
            _lblNotes = new Label();
            _tabSuppliers = new TabPage();
            _grpSupplier = new GroupBox();
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _dgProductSuppliers = new DataGrid();
            _dgProductSuppliers.DoubleClick += new EventHandler(dgProductSuppliers_DoubleClick);
            _tabAssociatedParts = new TabPage();
            _grpAssociatedParts = new GroupBox();
            _dgAssociatedParts = new DataGrid();
            _dgAssociatedParts.DoubleClick += new EventHandler(dgAssociatedParts_DoubleClick);
            _dgAssociatedParts.Click += new EventHandler(dgAssociatedParts_Clicks);
            _TabControl1.SuspendLayout();
            _tabMainDetails.SuspendLayout();
            _grpProduct.SuspendLayout();
            _tabSuppliers.SuspendLayout();
            _grpSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgProductSuppliers).BeginInit();
            _tabAssociatedParts.SuspendLayout();
            _grpAssociatedParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAssociatedParts).BeginInit();
            SuspendLayout();
            // 
            // TabControl1
            // 
            _TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TabControl1.Controls.Add(_tabMainDetails);
            _TabControl1.Controls.Add(_tabSuppliers);
            _TabControl1.Controls.Add(_tabAssociatedParts);
            _TabControl1.Location = new Point(2, 7);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(633, 617);
            _TabControl1.TabIndex = 0;
            // 
            // tabMainDetails
            // 
            _tabMainDetails.Controls.Add(_grpProduct);
            _tabMainDetails.Location = new Point(4, 22);
            _tabMainDetails.Name = "tabMainDetails";
            _tabMainDetails.Size = new Size(625, 591);
            _tabMainDetails.TabIndex = 0;
            _tabMainDetails.Text = "Main Details";
            // 
            // grpProduct
            // 
            _grpProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpProduct.Controls.Add(_txtReference);
            _grpProduct.Controls.Add(_Label2);
            _grpProduct.Controls.Add(_txtRecommendedQuantity);
            _grpProduct.Controls.Add(_Label6);
            _grpProduct.Controls.Add(_txtMinimumQuantity);
            _grpProduct.Controls.Add(_Label5);
            _grpProduct.Controls.Add(_txtSellPrice);
            _grpProduct.Controls.Add(_Label1);
            _grpProduct.Controls.Add(_txtNumber);
            _grpProduct.Controls.Add(_lblNumber);
            _grpProduct.Controls.Add(_cboTypeID);
            _grpProduct.Controls.Add(_lblTypeID);
            _grpProduct.Controls.Add(_cboMakeID);
            _grpProduct.Controls.Add(_lblMakeID);
            _grpProduct.Controls.Add(_cboModelID);
            _grpProduct.Controls.Add(_lblModelID);
            _grpProduct.Controls.Add(_txtNotes);
            _grpProduct.Controls.Add(_lblNotes);
            _grpProduct.Location = new Point(8, 8);
            _grpProduct.Name = "grpProduct";
            _grpProduct.Size = new Size(606, 576);
            _grpProduct.TabIndex = 0;
            _grpProduct.TabStop = false;
            _grpProduct.Text = "Details";
            // 
            // txtReference
            // 
            _txtReference.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtReference.Location = new Point(160, 56);
            _txtReference.MaxLength = 100;
            _txtReference.Name = "txtReference";
            _txtReference.Size = new Size(433, 21);
            _txtReference.TabIndex = 1;
            _txtReference.Tag = "Product.Reference";
            // 
            // Label2
            // 
            _Label2.Location = new Point(8, 56);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(97, 20);
            _Label2.TabIndex = 46;
            _Label2.Text = "Reference";
            // 
            // txtRecommendedQuantity
            // 
            _txtRecommendedQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtRecommendedQuantity.Location = new Point(160, 248);
            _txtRecommendedQuantity.Name = "txtRecommendedQuantity";
            _txtRecommendedQuantity.Size = new Size(433, 21);
            _txtRecommendedQuantity.TabIndex = 7;
            // 
            // Label6
            // 
            _Label6.Location = new Point(8, 246);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(152, 24);
            _Label6.TabIndex = 44;
            _Label6.Text = "Maximum Quantity";
            // 
            // txtMinimumQuantity
            // 
            _txtMinimumQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtMinimumQuantity.Location = new Point(160, 216);
            _txtMinimumQuantity.Name = "txtMinimumQuantity";
            _txtMinimumQuantity.Size = new Size(433, 21);
            _txtMinimumQuantity.TabIndex = 6;
            // 
            // Label5
            // 
            _Label5.Location = new Point(8, 218);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(120, 16);
            _Label5.TabIndex = 42;
            _Label5.Text = "Minimum Quantity";
            // 
            // txtSellPrice
            // 
            _txtSellPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSellPrice.Location = new Point(160, 184);
            _txtSellPrice.Name = "txtSellPrice";
            _txtSellPrice.Size = new Size(433, 21);
            _txtSellPrice.TabIndex = 5;
            // 
            // Label1
            // 
            _Label1.Location = new Point(8, 183);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(64, 23);
            _Label1.TabIndex = 32;
            _Label1.Text = "Sell Price";
            // 
            // txtNumber
            // 
            _txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNumber.Location = new Point(160, 24);
            _txtNumber.MaxLength = 100;
            _txtNumber.Name = "txtNumber";
            _txtNumber.Size = new Size(433, 21);
            _txtNumber.TabIndex = 0;
            _txtNumber.Tag = "Product.Number";
            // 
            // lblNumber
            // 
            _lblNumber.Location = new Point(8, 24);
            _lblNumber.Name = "lblNumber";
            _lblNumber.Size = new Size(120, 20);
            _lblNumber.TabIndex = 31;
            _lblNumber.Text = "GC Number";
            // 
            // cboTypeID
            // 
            _cboTypeID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboTypeID.Cursor = Cursors.Hand;
            _cboTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTypeID.Location = new Point(160, 88);
            _cboTypeID.Name = "cboTypeID";
            _cboTypeID.Size = new Size(433, 21);
            _cboTypeID.TabIndex = 2;
            _cboTypeID.Tag = "Product.TypeID";
            // 
            // lblTypeID
            // 
            _lblTypeID.Location = new Point(8, 88);
            _lblTypeID.Name = "lblTypeID";
            _lblTypeID.Size = new Size(46, 20);
            _lblTypeID.TabIndex = 31;
            _lblTypeID.Text = "Type ";
            // 
            // cboMakeID
            // 
            _cboMakeID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboMakeID.Cursor = Cursors.Hand;
            _cboMakeID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboMakeID.Location = new Point(160, 120);
            _cboMakeID.Name = "cboMakeID";
            _cboMakeID.Size = new Size(433, 21);
            _cboMakeID.TabIndex = 3;
            _cboMakeID.Tag = "Product.MakeID";
            // 
            // lblMakeID
            // 
            _lblMakeID.Location = new Point(8, 120);
            _lblMakeID.Name = "lblMakeID";
            _lblMakeID.Size = new Size(47, 20);
            _lblMakeID.TabIndex = 31;
            _lblMakeID.Text = "Make ";
            // 
            // cboModelID
            // 
            _cboModelID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboModelID.Cursor = Cursors.Hand;
            _cboModelID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboModelID.Location = new Point(160, 152);
            _cboModelID.Name = "cboModelID";
            _cboModelID.Size = new Size(433, 21);
            _cboModelID.TabIndex = 4;
            _cboModelID.Tag = "Product.ModelID";
            // 
            // lblModelID
            // 
            _lblModelID.Location = new Point(8, 152);
            _lblModelID.Name = "lblModelID";
            _lblModelID.Size = new Size(48, 20);
            _lblModelID.TabIndex = 31;
            _lblModelID.Text = "Model ";
            // 
            // txtNotes
            // 
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(160, 280);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(433, 283);
            _txtNotes.TabIndex = 8;
            _txtNotes.Tag = "Product.Notes";
            // 
            // lblNotes
            // 
            _lblNotes.Location = new Point(8, 280);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(48, 20);
            _lblNotes.TabIndex = 31;
            _lblNotes.Text = "Notes";
            // 
            // tabSuppliers
            // 
            _tabSuppliers.Controls.Add(_grpSupplier);
            _tabSuppliers.Location = new Point(4, 22);
            _tabSuppliers.Name = "tabSuppliers";
            _tabSuppliers.Size = new Size(625, 591);
            _tabSuppliers.TabIndex = 1;
            _tabSuppliers.Text = "Suppliers";
            // 
            // grpSupplier
            // 
            _grpSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSupplier.Controls.Add(_btnDelete);
            _grpSupplier.Controls.Add(_btnAdd);
            _grpSupplier.Controls.Add(_dgProductSuppliers);
            _grpSupplier.Location = new Point(7, 8);
            _grpSupplier.Name = "grpSupplier";
            _grpSupplier.Size = new Size(612, 577);
            _grpSupplier.TabIndex = 0;
            _grpSupplier.TabStop = false;
            _grpSupplier.Text = "Suppliers of this product";
            // 
            // btnDelete
            // 
            _btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDelete.Location = new Point(537, 544);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(64, 23);
            _btnDelete.TabIndex = 3;
            _btnDelete.Text = "Remove";
            // 
            // btnAdd
            // 
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAdd.Location = new Point(8, 543);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(64, 23);
            _btnAdd.TabIndex = 2;
            _btnAdd.Text = "Add";
            // 
            // dgProductSuppliers
            // 
            _dgProductSuppliers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dgProductSuppliers.DataMember = "";
            _dgProductSuppliers.HeaderForeColor = SystemColors.ControlText;
            _dgProductSuppliers.Location = new Point(9, 28);
            _dgProductSuppliers.Name = "dgProductSuppliers";
            _dgProductSuppliers.Size = new Size(593, 469);
            _dgProductSuppliers.TabIndex = 1;
            // 
            // tabAssociatedParts
            // 
            _tabAssociatedParts.Controls.Add(_grpAssociatedParts);
            _tabAssociatedParts.Location = new Point(4, 22);
            _tabAssociatedParts.Name = "tabAssociatedParts";
            _tabAssociatedParts.Size = new Size(625, 591);
            _tabAssociatedParts.TabIndex = 2;
            _tabAssociatedParts.Text = "Associated Parts";
            // 
            // grpAssociatedParts
            // 
            _grpAssociatedParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAssociatedParts.Controls.Add(_dgAssociatedParts);
            _grpAssociatedParts.Location = new Point(7, 8);
            _grpAssociatedParts.Name = "grpAssociatedParts";
            _grpAssociatedParts.Size = new Size(612, 577);
            _grpAssociatedParts.TabIndex = 1;
            _grpAssociatedParts.TabStop = false;
            _grpAssociatedParts.Text = "Associated parts of this product";
            // 
            // dgAssociatedParts
            // 
            _dgAssociatedParts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dgAssociatedParts.DataMember = "";
            _dgAssociatedParts.HeaderForeColor = SystemColors.ControlText;
            _dgAssociatedParts.Location = new Point(9, 28);
            _dgAssociatedParts.Name = "dgAssociatedParts";
            _dgAssociatedParts.Size = new Size(593, 542);
            _dgAssociatedParts.TabIndex = 1;
            // 
            // UCProduct
            // 
            Controls.Add(_TabControl1);
            Name = "UCProduct";
            Size = new Size(640, 628);
            _TabControl1.ResumeLayout(false);
            _tabMainDetails.ResumeLayout(false);
            _grpProduct.ResumeLayout(false);
            _grpProduct.PerformLayout();
            _tabSuppliers.ResumeLayout(false);
            _grpSupplier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgProductSuppliers).EndInit();
            _tabAssociatedParts.ResumeLayout(false);
            _grpAssociatedParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAssociatedParts).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupSuppliersDatagrid();
            SetupAssociateDatagrid();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentProduct;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Products.Product _currentProduct;

        public Entity.Products.Product CurrentProduct
        {
            get
            {
                return _currentProduct;
            }

            set
            {
                _currentProduct = value;
                if (CurrentProduct is null)
                {
                    CurrentProduct = new Entity.Products.Product();
                    CurrentProduct.Exists = false;
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                }

                if (CurrentProduct.Exists)
                {
                    Populate();
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                }

                PopulateSuppliers();
            }
        }

        private bool _FromOrder;

        public bool FromOrder
        {
            get
            {
                return _FromOrder;
            }

            set
            {
                _FromOrder = value;
            }
        }

        private DataView _ProductSuppliersDataview = null;

        public DataView ProductSuppliersDataView
        {
            get
            {
                return _ProductSuppliersDataview;
            }

            set
            {
                _ProductSuppliersDataview = value;
                _ProductSuppliersDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblProductSupplier.ToString();
                _ProductSuppliersDataview.AllowNew = false;
                _ProductSuppliersDataview.AllowEdit = false;
                _ProductSuppliersDataview.AllowDelete = false;
                dgProductSuppliers.DataSource = ProductSuppliersDataView;
            }
        }

        private DataRow SelectedProductSupplierDataRow
        {
            get
            {
                if (!(dgProductSuppliers.CurrentRowIndex == -1))
                {
                    return ProductSuppliersDataView[dgProductSuppliers.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _ProductAssociatedPartsDataview = null;

        public DataView ProductAssociatedPartsDataview
        {
            get
            {
                return _ProductAssociatedPartsDataview;
            }

            set
            {
                _ProductAssociatedPartsDataview = value;
                if (_ProductAssociatedPartsDataview is object)
                {
                    _ProductAssociatedPartsDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblProductAssociatedPart.ToString();
                    _ProductAssociatedPartsDataview.AllowNew = false;
                    _ProductAssociatedPartsDataview.AllowEdit = true;
                    _ProductAssociatedPartsDataview.AllowDelete = false;
                }

                dgAssociatedParts.DataSource = ProductAssociatedPartsDataview;
            }
        }

        private DataRow SelectedProductAssociatedPartDataRow
        {
            get
            {
                if (!(dgAssociatedParts.CurrentRowIndex == -1))
                {
                    return ProductAssociatedPartsDataview[dgAssociatedParts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupSuppliersDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgProductSuppliers);
            var tStyle = dgProductSuppliers.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var SupplierName = new DataGridLabelColumn();
            SupplierName.Format = "";
            SupplierName.FormatInfo = null;
            SupplierName.HeaderText = "Supplier";
            SupplierName.MappingName = "SupplierName";
            SupplierName.ReadOnly = true;
            SupplierName.Width = 130;
            SupplierName.NullText = "";
            tStyle.GridColumnStyles.Add(SupplierName);
            var ProductCode = new DataGridLabelColumn();
            ProductCode.Format = "";
            ProductCode.FormatInfo = null;
            ProductCode.HeaderText = "Supplier Product Code";
            ProductCode.MappingName = "ProductCode";
            ProductCode.ReadOnly = true;
            ProductCode.Width = 130;
            ProductCode.NullText = "";
            tStyle.GridColumnStyles.Add(ProductCode);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Supplier Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 85;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var QuantityInPack = new DataGridLabelColumn();
            QuantityInPack.Format = "";
            QuantityInPack.FormatInfo = null;
            QuantityInPack.HeaderText = "Quantity In Pack";
            QuantityInPack.MappingName = "QuantityInPack";
            QuantityInPack.ReadOnly = true;
            QuantityInPack.Width = 110;
            QuantityInPack.NullText = "";
            tStyle.GridColumnStyles.Add(QuantityInPack);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblProductSupplier.ToString();
            dgProductSuppliers.TableStyles.Add(tStyle);
        }

        public void SetupAssociateDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgAssociatedParts);
            var tStyle = dgAssociatedParts.TableStyles[0];
            dgAssociatedParts.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var PartName = new DataGridLabelColumn();
            PartName.Format = "";
            PartName.FormatInfo = null;
            PartName.HeaderText = "Part Name";
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
            var PartReference = new DataGridLabelColumn();
            PartReference.Format = "";
            PartReference.FormatInfo = null;
            PartReference.HeaderText = "Part Reference";
            PartReference.MappingName = "Reference";
            PartReference.ReadOnly = true;
            PartReference.Width = 130;
            PartReference.NullText = "";
            tStyle.GridColumnStyles.Add(PartReference);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblProductAssociatedPart.ToString();
            dgAssociatedParts.TableStyles.Add(tStyle);
        }

        private void UCProduct_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void dgProductSuppliers_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedProductSupplierDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMProductSupplier), true, new object[] { Entity.Sys.Helper.MakeIntegerValid(SelectedProductSupplierDataRow["ProductSupplierID"]), CurrentProduct.ProductID, this });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMProductSupplier), true, new object[] { 0, CurrentProduct.ProductID, this });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedProductSupplierDataRow is null)
            {
                App.ShowMessage("Please select a supplier to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            App.DB.ProductSupplier.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedProductSupplierDataRow["ProductSupplierID"]));
            ProductSuppliersDataView = App.DB.ProductSupplier.Get_ByProductID(CurrentProduct.ProductID);
        }

        private void dgAssociatedParts_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedProductAssociatedPartDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMPart), true, new object[] { Entity.Sys.Helper.MakeIntegerValid(SelectedProductAssociatedPartDataRow["PartID"]), true });
            ProductAssociatedPartsDataview = App.DB.ProductAssociatedPart.GetAll_For_ProductID(CurrentProduct.ProductID);
        }

        private void dgAssociatedParts_Clicks(object sender, EventArgs e)
        {
            try
            {
                if (SelectedProductAssociatedPartDataRow is null)
                {
                    return;
                }

                bool selected = !Conversions.ToBoolean(dgAssociatedParts[dgAssociatedParts.CurrentRowIndex, 0]);
                dgAssociatedParts[dgAssociatedParts.CurrentRowIndex, 0] = selected;
                App.AnythingChanges(sender, e);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void PopulateSuppliers()
        {
            ProductSuppliersDataView = App.DB.ProductSupplier.Get_ByProductID(CurrentProduct.ProductID);
        }

        private void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentProduct = App.DB.Product.Product_Get(ID);
            }

            txtNumber.Text = CurrentProduct.Number;
            txtReference.Text = CurrentProduct.Reference;
            txtSellPrice.Text = CurrentProduct.SellPrice.ToString();
            var argcombo = cboTypeID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentProduct.TypeID.ToString());
            var argcombo1 = cboMakeID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentProduct.MakeID.ToString());
            var argcombo2 = cboModelID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentProduct.ModelID.ToString());
            txtNotes.Text = CurrentProduct.Notes;
            txtMinimumQuantity.Text = CurrentProduct.MinimumQuantity.ToString();
            txtRecommendedQuantity.Text = CurrentProduct.RecommendedQuantity.ToString();
            ProductAssociatedPartsDataview = CurrentProduct.AssociatedPart;
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentProduct.IgnoreExceptionsOnSetMethods = true;
                CurrentProduct.SetNumber = txtNumber.Text.Trim();
                CurrentProduct.SetReference = txtReference.Text.Trim();
                CurrentProduct.SetTypeID = Combo.get_GetSelectedItemValue(cboTypeID);
                CurrentProduct.SetMakeID = Combo.get_GetSelectedItemValue(cboMakeID);
                CurrentProduct.SetModelID = Combo.get_GetSelectedItemValue(cboModelID);
                CurrentProduct.SetNotes = txtNotes.Text.Trim();
                CurrentProduct.SetSellPrice = txtSellPrice.Text.Trim();
                CurrentProduct.SetMinimumQuantity = Entity.Sys.Helper.MakeIntegerValid(txtMinimumQuantity.Text.Trim());
                CurrentProduct.SetRecommendedQuantity = Entity.Sys.Helper.MakeIntegerValid(txtRecommendedQuantity.Text.Trim());
                CurrentProduct.AssociatedPart = ProductAssociatedPartsDataview;
                var cV = new Entity.Products.ProductValidator();
                cV.Validate(CurrentProduct);
                if (CurrentProduct.Exists)
                {
                    App.DB.Product.Update(CurrentProduct);
                }
                else
                {
                    CurrentProduct = App.DB.Product.Insert(CurrentProduct);
                }

                if (FromOrder == false)
                {
                    RecordsChanged?.Invoke(App.DB.Product.Product_GetAll(), Entity.Sys.Enums.PageViewing.Product, true, false, "");
                    App.MainForm.RefreshEntity(CurrentProduct.ProductID);
                }

                StateChanged?.Invoke(CurrentProduct.ProductID);
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

    }
}