using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMAddtoOrder : FRMBaseForm, IForm
    {
        public FRMAddtoOrder() : base()
        {
            base.Load += FRMAddtoOrder_Load;

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

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

        private TextBox _txtQtyInPack;

        internal TextBox txtQtyInPack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQtyInPack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQtyInPack != null)
                {
                }

                _txtQtyInPack = value;
                if (_txtQtyInPack != null)
                {
                }
            }
        }

        private Button _btnAddToOrder;

        internal Button btnAddToOrder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddToOrder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddToOrder != null)
                {
                    _btnAddToOrder.Click -= btnAddToOrder_Click;
                }

                _btnAddToOrder = value;
                if (_btnAddToOrder != null)
                {
                    _btnAddToOrder.Click += btnAddToOrder_Click;
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

        private Label _lblName;

        internal Label lblName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblName != null)
                {
                }

                _lblName = value;
                if (_lblName != null)
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

        private Label _lblSupplier;

        internal Label lblSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSupplier != null)
                {
                }

                _lblSupplier = value;
                if (_lblSupplier != null)
                {
                }
            }
        }

        private Label _lblQty;

        internal Label lblQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQty != null)
                {
                }

                _lblQty = value;
                if (_lblQty != null)
                {
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
                }

                _txtName = value;
                if (_txtName != null)
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

        private TextBox _txtSupplierCode;

        internal TextBox txtSupplierCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplierCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplierCode != null)
                {
                }

                _txtSupplierCode = value;
                if (_txtSupplierCode != null)
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

        private TextBox _txtAmount;

        internal TextBox txtAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAmount != null)
                {
                }

                _txtAmount = value;
                if (_txtAmount != null)
                {
                }
            }
        }

        private TextBox _txtBuyPrice;

        internal TextBox txtBuyPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBuyPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBuyPrice != null)
                {
                }

                _txtBuyPrice = value;
                if (_txtBuyPrice != null)
                {
                }
            }
        }

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

        private GroupBox _GroupBox2;

        internal GroupBox GroupBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox2 != null)
                {
                }

                _GroupBox2 = value;
                if (_GroupBox2 != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._lblName = new System.Windows.Forms.Label();
            this._lblNumber = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._lblSupplier = new System.Windows.Forms.Label();
            this._lblQty = new System.Windows.Forms.Label();
            this._Label7 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtNumber = new System.Windows.Forms.TextBox();
            this._txtQtyInPack = new System.Windows.Forms.TextBox();
            this._txtSupplierCode = new System.Windows.Forms.TextBox();
            this._txtSellPrice = new System.Windows.Forms.TextBox();
            this._txtAmount = new System.Windows.Forms.TextBox();
            this._btnAddToOrder = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._txtBuyPrice = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._txtSupplier = new System.Windows.Forms.TextBox();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._GroupBox1.SuspendLayout();
            this._GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lblName
            // 
            this._lblName.Location = new System.Drawing.Point(8, 24);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(120, 23);
            this._lblName.TabIndex = 2;
            this._lblName.Text = "Name:";
            // 
            // _lblNumber
            // 
            this._lblNumber.Location = new System.Drawing.Point(8, 56);
            this._lblNumber.Name = "_lblNumber";
            this._lblNumber.Size = new System.Drawing.Size(120, 23);
            this._lblNumber.TabIndex = 3;
            this._lblNumber.Text = "Number:";
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(8, 24);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(104, 23);
            this._Label3.TabIndex = 4;
            this._Label3.Text = "Supplier Code:";
            // 
            // _lblSupplier
            // 
            this._lblSupplier.Location = new System.Drawing.Point(8, 88);
            this._lblSupplier.Name = "_lblSupplier";
            this._lblSupplier.Size = new System.Drawing.Size(80, 24);
            this._lblSupplier.TabIndex = 5;
            this._lblSupplier.Text = "Supplier:";
            // 
            // _lblQty
            // 
            this._lblQty.Location = new System.Drawing.Point(8, 120);
            this._lblQty.Name = "_lblQty";
            this._lblQty.Size = new System.Drawing.Size(120, 23);
            this._lblQty.TabIndex = 6;
            this._lblQty.Text = "Quantity In Pack:";
            // 
            // _Label7
            // 
            this._Label7.Location = new System.Drawing.Point(8, 88);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(88, 23);
            this._Label7.TabIndex = 8;
            this._Label7.Text = "Sell Price:";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(8, 120);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(104, 24);
            this._Label8.TabIndex = 9;
            this._Label8.Text = "Amount to add:";
            // 
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.Enabled = false;
            this._txtName.Location = new System.Drawing.Point(128, 24);
            this._txtName.Name = "_txtName";
            this._txtName.ReadOnly = true;
            this._txtName.Size = new System.Drawing.Size(296, 21);
            this._txtName.TabIndex = 1;
            // 
            // _txtNumber
            // 
            this._txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNumber.Enabled = false;
            this._txtNumber.Location = new System.Drawing.Point(128, 58);
            this._txtNumber.Name = "_txtNumber";
            this._txtNumber.ReadOnly = true;
            this._txtNumber.Size = new System.Drawing.Size(296, 21);
            this._txtNumber.TabIndex = 2;
            // 
            // _txtQtyInPack
            // 
            this._txtQtyInPack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtQtyInPack.Enabled = false;
            this._txtQtyInPack.Location = new System.Drawing.Point(128, 122);
            this._txtQtyInPack.Name = "_txtQtyInPack";
            this._txtQtyInPack.ReadOnly = true;
            this._txtQtyInPack.Size = new System.Drawing.Size(296, 21);
            this._txtQtyInPack.TabIndex = 4;
            // 
            // _txtSupplierCode
            // 
            this._txtSupplierCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSupplierCode.Location = new System.Drawing.Point(128, 24);
            this._txtSupplierCode.Name = "_txtSupplierCode";
            this._txtSupplierCode.Size = new System.Drawing.Size(296, 21);
            this._txtSupplierCode.TabIndex = 5;
            // 
            // _txtSellPrice
            // 
            this._txtSellPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSellPrice.Location = new System.Drawing.Point(128, 90);
            this._txtSellPrice.Name = "_txtSellPrice";
            this._txtSellPrice.Size = new System.Drawing.Size(296, 21);
            this._txtSellPrice.TabIndex = 7;
            // 
            // _txtAmount
            // 
            this._txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAmount.Location = new System.Drawing.Point(128, 122);
            this._txtAmount.Name = "_txtAmount";
            this._txtAmount.Size = new System.Drawing.Size(168, 21);
            this._txtAmount.TabIndex = 8;
            // 
            // _btnAddToOrder
            // 
            this._btnAddToOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddToOrder.Location = new System.Drawing.Point(304, 122);
            this._btnAddToOrder.Name = "_btnAddToOrder";
            this._btnAddToOrder.Size = new System.Drawing.Size(56, 23);
            this._btnAddToOrder.TabIndex = 9;
            this._btnAddToOrder.Text = "Add";
            this._btnAddToOrder.Click += new System.EventHandler(this.btnAddToOrder_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.Location = new System.Drawing.Point(368, 122);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(56, 23);
            this._btnCancel.TabIndex = 10;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _txtBuyPrice
            // 
            this._txtBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtBuyPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtBuyPrice.Location = new System.Drawing.Point(128, 58);
            this._txtBuyPrice.Name = "_txtBuyPrice";
            this._txtBuyPrice.Size = new System.Drawing.Size(296, 21);
            this._txtBuyPrice.TabIndex = 6;
            // 
            // _Label6
            // 
            this._Label6.BackColor = System.Drawing.Color.White;
            this._Label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label6.Location = new System.Drawing.Point(8, 56);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(88, 23);
            this._Label6.TabIndex = 7;
            this._Label6.Text = "Buy Price:";
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._lblName);
            this._GroupBox1.Controls.Add(this._lblNumber);
            this._GroupBox1.Controls.Add(this._txtName);
            this._GroupBox1.Controls.Add(this._txtNumber);
            this._GroupBox1.Controls.Add(this._lblSupplier);
            this._GroupBox1.Controls.Add(this._txtSupplier);
            this._GroupBox1.Controls.Add(this._lblQty);
            this._GroupBox1.Controls.Add(this._txtQtyInPack);
            this._GroupBox1.Location = new System.Drawing.Point(8, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(432, 180);
            this._GroupBox1.TabIndex = 20;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Request Details";
            // 
            // _txtSupplier
            // 
            this._txtSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSupplier.Enabled = false;
            this._txtSupplier.Location = new System.Drawing.Point(128, 90);
            this._txtSupplier.Name = "_txtSupplier";
            this._txtSupplier.ReadOnly = true;
            this._txtSupplier.Size = new System.Drawing.Size(296, 21);
            this._txtSupplier.TabIndex = 3;
            // 
            // _GroupBox2
            // 
            this._GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox2.Controls.Add(this._Label3);
            this._GroupBox2.Controls.Add(this._txtSupplierCode);
            this._GroupBox2.Controls.Add(this._txtBuyPrice);
            this._GroupBox2.Controls.Add(this._txtSellPrice);
            this._GroupBox2.Controls.Add(this._Label6);
            this._GroupBox2.Controls.Add(this._Label7);
            this._GroupBox2.Controls.Add(this._Label8);
            this._GroupBox2.Controls.Add(this._txtAmount);
            this._GroupBox2.Controls.Add(this._btnAddToOrder);
            this._GroupBox2.Controls.Add(this._btnCancel);
            this._GroupBox2.Location = new System.Drawing.Point(8, 200);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(432, 152);
            this._GroupBox2.TabIndex = 21;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "Order Details";
            // 
            // FRMAddtoOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(440, 353);
            this.Controls.Add(this._GroupBox2);
            this.Controls.Add(this._GroupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(456, 392);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(456, 392);
            this.Name = "FRMAddtoOrder";
            this.Text = "Add Item to Order";
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this._GroupBox2.ResumeLayout(false);
            this._GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            oOrder = (Entity.Orders.Order)get_GetParameter(0);
            PartSupplier = (Entity.PartSuppliers.PartSupplier)get_GetParameter(1);
            ProductSupplier = (Entity.ProductSuppliers.ProductSupplier)get_GetParameter(2);
            PriceRequestID = Conversions.ToInteger(get_GetParameter(3));
            LoadForm(sender, e, this);
            if (PartSupplier is object)
            {
                var oPart = App.DB.Part.Part_Get(PartSupplier.PartID);
                lblName.Text = "Part Name";
                lblNumber.Text = "Part Number";
                txtName.Text = oPart.Name;
                txtNumber.Text = oPart.Number;
                txtQtyInPack.Text = PartSupplier.QuantityInPack.ToString();
                txtSupplier.Text = App.DB.Supplier.Supplier_Get(PartSupplier.SupplierID).Name;
            }

            if (ProductSupplier is object)
            {
                var oProduct = App.DB.Product.Product_Get(ProductSupplier.ProductID);
                lblName.Text = "Product Name";
                lblNumber.Text = "Product Number";
                txtName.Text = oProduct.Name;
                txtNumber.Text = oProduct.Number;
                txtQtyInPack.Text = ProductSupplier.QuantityInPack.ToString();
                txtSupplier.Text = App.DB.Supplier.Supplier_Get(ProductSupplier.SupplierID).Name;
            }
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
            // DO NOTHING
        }

        private Entity.Orders.Order _oOrder;

        private Entity.Orders.Order oOrder
        {
            get
            {
                return _oOrder;
            }

            set
            {
                _oOrder = value;
            }
        }

        // Private _OrderID As Integer
        // Public Property OrderID() As Integer
        // Get
        // Return _OrderID
        // End Get
        // Set(ByVal Value As Integer)
        // _OrderID = Value
        // End Set
        // End Property

        private Entity.PartSuppliers.PartSupplier _partSupplier;

        public Entity.PartSuppliers.PartSupplier PartSupplier
        {
            get
            {
                return _partSupplier;
            }

            set
            {
                _partSupplier = value;
            }
        }

        private Entity.ProductSuppliers.ProductSupplier _productSupplier;

        public Entity.ProductSuppliers.ProductSupplier ProductSupplier
        {
            get
            {
                return _productSupplier;
            }

            set
            {
                _productSupplier = value;
            }
        }

        private int _PriceRequestID;

        public int PriceRequestID
        {
            get
            {
                return _PriceRequestID;
            }

            set
            {
                _PriceRequestID = value;
            }
        }

        private void FRMAddtoOrder_Load(object sender, EventArgs e)
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

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (PartSupplier is object)
                {
                    PartSupplier.IgnoreExceptionsOnSetMethods = true;
                    PartSupplier.SetPrice = txtBuyPrice.Text.Trim();
                    PartSupplier.SetPartCode = txtSupplierCode.Text.Trim();
                    var val = new Entity.PartSuppliers.PartSupplierValidator();
                    val.Validate(PartSupplier);
                    var OrderPart = new Entity.OrderParts.OrderPart();
                    OrderPart.IgnoreExceptionsOnSetMethods = true;
                    OrderPart.SetSellPrice = txtSellPrice.Text.Trim();
                    OrderPart.SetQuantity = txtAmount.Text.Trim();
                    OrderPart.SetOrderID = oOrder.OrderID;
                    var val2 = new Entity.OrderParts.OrderPartValidator();
                    val2.Validate(OrderPart);
                    PartSupplier = App.DB.PartSupplier.Insert(PartSupplier);
                    OrderPart.SetBuyPrice = PartSupplier.Price;
                    OrderPart.SetPartSupplierID = PartSupplier.PartSupplierID;

                    var oOrderAudit = new FSM.Entity.OrderAudit();
                    oOrderAudit.SetOrderID = oOrder.OrderID;
                    oOrderAudit.SetReason = FSM.Entity.Sys.Helper.MakeIntegerValid(FSM.Entity.Sys.Enums.OrderAuditReason.PartsAdded);
                    oOrderAudit.SetDescription = "PartID " + PartSupplier.PartID + " Quantity " + OrderPart.Quantity + " Price " + OrderPart.BuyPrice + " From supplier " + OrderPart.PartSupplierID;

                    App.DB.OrderPart.Insert(OrderPart, !oOrder.DoNotConsolidated);
                    App.DB.OrderAudits.Insert(oOrderAudit);
                    App.DB.PartPriceRequest.Complete(PriceRequestID);
                }

                if (ProductSupplier is object)
                {
                    //ProductSupplier.IgnoreExceptionsOnSetMethods = true;
                    //ProductSupplier.SetPrice = txtBuyPrice.Text.Trim();
                    //ProductSupplier.SetProductCode = txtSupplierCode.Text.Trim();
                    //var val = new Entity.ProductSuppliers.ProductSupplierValidator();
                    //val.Validate(ProductSupplier);
                    //var OrderProduct = new Entity.OrderProducts.OrderProduct();
                    //OrderProduct.IgnoreExceptionsOnSetMethods = true;
                    //OrderProduct.SetSellPrice = txtSellPrice.Text.Trim();
                    //OrderProduct.SetQuantity = txtAmount.Text.Trim();
                    //OrderProduct.SetOrderID = oOrder.OrderID;
                    //var val2 = new Entity.OrderProducts.OrderProductValidator();
                    //val2.Validate(OrderProduct);
                    //ProductSupplier = App.DB.ProductSupplier.Insert(ProductSupplier);
                    //OrderProduct.SetBuyPrice = ProductSupplier.Price;
                    //OrderProduct.SetProductSupplierID = ProductSupplier.ProductSupplierID;
                    //var oOrderAudit = new FSM.Entity.OrderAudit();
                    //oOrderAudit.SetOrderID = oOrder.OrderID;
                    //oOrderAudit.SetReason = FSM.Entity.Sys.Helper.MakeIntegerValid(FSM.Entity.Sys.Enums.OrderAuditReason.PartsAdded);
                    //oOrderAudit.SetDescription = "PartID " + PartSupplier.PartID + " Quantity " + OrderProduct.Quantity + " Price " + OrderProduct.BuyPrice + " From supplier " + PartSupplier.PartSupplierID;
                    //App.DB.OrderProduct.Insert(OrderProduct, true);
                    //App.DB.OrderAudits.Insert(oOrderAudit);
                    //App.DB.ProductPriceRequest.Complete(PriceRequestID);
                    throw new NotImplementedException("Products are not used anymore.");
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
    }
}