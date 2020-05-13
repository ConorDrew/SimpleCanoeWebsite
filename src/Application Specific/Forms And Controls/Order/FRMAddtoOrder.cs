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
            _lblName = new Label();
            _lblNumber = new Label();
            _Label3 = new Label();
            _lblSupplier = new Label();
            _lblQty = new Label();
            _Label7 = new Label();
            _Label8 = new Label();
            _txtName = new TextBox();
            _txtNumber = new TextBox();
            _txtQtyInPack = new TextBox();
            _txtSupplierCode = new TextBox();
            _txtSellPrice = new TextBox();
            _txtAmount = new TextBox();
            _btnAddToOrder = new Button();
            _btnAddToOrder.Click += new EventHandler(btnAddToOrder_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _txtBuyPrice = new TextBox();
            _Label6 = new Label();
            _GroupBox1 = new GroupBox();
            _txtSupplier = new TextBox();
            _GroupBox2 = new GroupBox();
            _GroupBox1.SuspendLayout();
            _GroupBox2.SuspendLayout();
            SuspendLayout();
            //
            // lblName
            //
            _lblName.Location = new Point(8, 24);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(120, 23);
            _lblName.TabIndex = 2;
            _lblName.Text = "Name:";
            //
            // lblNumber
            //
            _lblNumber.Location = new Point(8, 56);
            _lblNumber.Name = "lblNumber";
            _lblNumber.Size = new Size(120, 23);
            _lblNumber.TabIndex = 3;
            _lblNumber.Text = "Number:";
            //
            // Label3
            //
            _Label3.Location = new Point(8, 24);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(104, 23);
            _Label3.TabIndex = 4;
            _Label3.Text = "Supplier Code:";
            //
            // lblSupplier
            //
            _lblSupplier.Location = new Point(8, 88);
            _lblSupplier.Name = "lblSupplier";
            _lblSupplier.Size = new Size(80, 24);
            _lblSupplier.TabIndex = 5;
            _lblSupplier.Text = "Supplier:";
            //
            // lblQty
            //
            _lblQty.Location = new Point(8, 120);
            _lblQty.Name = "lblQty";
            _lblQty.Size = new Size(120, 23);
            _lblQty.TabIndex = 6;
            _lblQty.Text = "Quantity In Pack:";
            //
            // Label7
            //
            _Label7.Location = new Point(8, 88);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(88, 23);
            _Label7.TabIndex = 8;
            _Label7.Text = "Sell Price:";
            //
            // Label8
            //
            _Label8.Location = new Point(8, 120);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(104, 24);
            _Label8.TabIndex = 9;
            _Label8.Text = "Amount to add:";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Enabled = false;
            _txtName.Location = new Point(128, 24);
            _txtName.Name = "txtName";
            _txtName.ReadOnly = true;
            _txtName.Size = new Size(296, 21);
            _txtName.TabIndex = 1;
            _txtName.Text = "";
            //
            // txtNumber
            //
            _txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNumber.Enabled = false;
            _txtNumber.Location = new Point(128, 58);
            _txtNumber.Name = "txtNumber";
            _txtNumber.ReadOnly = true;
            _txtNumber.Size = new Size(296, 21);
            _txtNumber.TabIndex = 2;
            _txtNumber.Text = "";
            //
            // txtQtyInPack
            //
            _txtQtyInPack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtQtyInPack.Enabled = false;
            _txtQtyInPack.Location = new Point(128, 122);
            _txtQtyInPack.Name = "txtQtyInPack";
            _txtQtyInPack.ReadOnly = true;
            _txtQtyInPack.Size = new Size(296, 21);
            _txtQtyInPack.TabIndex = 4;
            _txtQtyInPack.Text = "";
            //
            // txtSupplierCode
            //
            _txtSupplierCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSupplierCode.Location = new Point(128, 24);
            _txtSupplierCode.Name = "txtSupplierCode";
            _txtSupplierCode.Size = new Size(296, 21);
            _txtSupplierCode.TabIndex = 5;
            _txtSupplierCode.Text = "";
            //
            // txtSellPrice
            //
            _txtSellPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSellPrice.Location = new Point(128, 90);
            _txtSellPrice.Name = "txtSellPrice";
            _txtSellPrice.Size = new Size(296, 21);
            _txtSellPrice.TabIndex = 7;
            _txtSellPrice.Text = "";
            //
            // txtAmount
            //
            _txtAmount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAmount.Location = new Point(128, 122);
            _txtAmount.Name = "txtAmount";
            _txtAmount.Size = new Size(168, 21);
            _txtAmount.TabIndex = 8;
            _txtAmount.Text = "";
            //
            // btnAddToOrder
            //
            _btnAddToOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddToOrder.Location = new Point(304, 122);
            _btnAddToOrder.Name = "btnAddToOrder";
            _btnAddToOrder.Size = new Size(56, 23);
            _btnAddToOrder.TabIndex = 9;
            _btnAddToOrder.Text = "Add";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnCancel.Location = new Point(368, 122);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(56, 23);
            _btnCancel.TabIndex = 10;
            _btnCancel.Text = "Cancel";
            //
            // txtBuyPrice
            //
            _txtBuyPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtBuyPrice.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtBuyPrice.Location = new Point(128, 58);
            _txtBuyPrice.Name = "txtBuyPrice";
            _txtBuyPrice.Size = new Size(296, 21);
            _txtBuyPrice.TabIndex = 6;
            _txtBuyPrice.Text = "";
            //
            // Label6
            //
            _Label6.BackColor = Color.White;
            _Label6.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label6.Location = new Point(8, 56);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(88, 23);
            _Label6.TabIndex = 7;
            _Label6.Text = "Buy Price:";
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_lblName);
            _GroupBox1.Controls.Add(_lblNumber);
            _GroupBox1.Controls.Add(_txtName);
            _GroupBox1.Controls.Add(_txtNumber);
            _GroupBox1.Controls.Add(_lblSupplier);
            _GroupBox1.Controls.Add(_txtSupplier);
            _GroupBox1.Controls.Add(_lblQty);
            _GroupBox1.Controls.Add(_txtQtyInPack);
            _GroupBox1.Location = new Point(8, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(432, 152);
            _GroupBox1.TabIndex = 20;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Request Details";
            //
            // txtSupplier
            //
            _txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSupplier.Enabled = false;
            _txtSupplier.Location = new Point(128, 90);
            _txtSupplier.Name = "txtSupplier";
            _txtSupplier.ReadOnly = true;
            _txtSupplier.Size = new Size(296, 21);
            _txtSupplier.TabIndex = 3;
            _txtSupplier.Text = "";
            //
            // GroupBox2
            //
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox2.Controls.Add(_Label3);
            _GroupBox2.Controls.Add(_txtSupplierCode);
            _GroupBox2.Controls.Add(_txtBuyPrice);
            _GroupBox2.Controls.Add(_txtSellPrice);
            _GroupBox2.Controls.Add(_Label6);
            _GroupBox2.Controls.Add(_Label7);
            _GroupBox2.Controls.Add(_Label8);
            _GroupBox2.Controls.Add(_txtAmount);
            _GroupBox2.Controls.Add(_btnAddToOrder);
            _GroupBox2.Controls.Add(_btnCancel);
            _GroupBox2.Location = new Point(8, 200);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(432, 152);
            _GroupBox2.TabIndex = 21;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Order Details";
            //
            // FRMAddtoOrder
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(448, 358);
            Controls.Add(_GroupBox2);
            Controls.Add(_GroupBox1);
            MaximizeBox = false;
            MaximumSize = new Size(456, 392);
            MinimizeBox = false;
            MinimumSize = new Size(456, 392);
            Name = "FRMAddtoOrder";
            Text = "Add Item to Order";
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_GroupBox2, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            ResumeLayout(false);
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
                    ProductSupplier.IgnoreExceptionsOnSetMethods = true;
                    ProductSupplier.SetPrice = txtBuyPrice.Text.Trim();
                    ProductSupplier.SetProductCode = txtSupplierCode.Text.Trim();
                    var val = new Entity.ProductSuppliers.ProductSupplierValidator();
                    val.Validate(ProductSupplier);
                    var OrderProduct = new Entity.OrderProducts.OrderProduct();
                    OrderProduct.IgnoreExceptionsOnSetMethods = true;
                    OrderProduct.SetSellPrice = txtSellPrice.Text.Trim();
                    OrderProduct.SetQuantity = txtAmount.Text.Trim();
                    OrderProduct.SetOrderID = oOrder.OrderID;
                    var val2 = new Entity.OrderProducts.OrderProductValidator();
                    val2.Validate(OrderProduct);
                    ProductSupplier = App.DB.ProductSupplier.Insert(ProductSupplier);
                    OrderProduct.SetBuyPrice = ProductSupplier.Price;
                    OrderProduct.SetProductSupplierID = ProductSupplier.ProductSupplierID;
                    var oOrderAudit = new FSM.Entity.OrderAudit();
                    oOrderAudit.SetOrderID = oOrder.OrderID;
                    oOrderAudit.SetReason = FSM.Entity.Sys.Helper.MakeIntegerValid(FSM.Entity.Sys.Enums.OrderAuditReason.PartsAdded);
                    oOrderAudit.SetDescription = "PartID " + PartSupplier.PartID + " Quantity " + OrderProduct.Quantity + " Price " + OrderProduct.BuyPrice + " From supplier " + PartSupplier.PartSupplierID;
                    App.DB.OrderProduct.Insert(OrderProduct, true);
                    App.DB.OrderAudits.Insert(oOrderAudit);
                    App.DB.ProductPriceRequest.Complete(PriceRequestID);
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