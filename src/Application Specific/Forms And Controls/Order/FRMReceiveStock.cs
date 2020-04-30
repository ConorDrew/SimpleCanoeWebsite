using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMReceiveStock : FRMBaseForm, IForm
    {
        

        public FRMReceiveStock() : base()
        {
            
            
            base.Load += FRMReceiveStock_Load;

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

        private TextBox _txtQuantityPreviouslyReceived;

        internal TextBox txtQuantityPreviouslyReceived
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuantityPreviouslyReceived;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuantityPreviouslyReceived != null)
                {
                }

                _txtQuantityPreviouslyReceived = value;
                if (_txtQuantityPreviouslyReceived != null)
                {
                }
            }
        }

        private TextBox _txtTotalquantity;

        internal TextBox txtTotalquantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTotalquantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTotalquantity != null)
                {
                }

                _txtTotalquantity = value;
                if (_txtTotalquantity != null)
                {
                }
            }
        }

        private TextBox _txtQuantityInput;

        internal TextBox txtQuantityInput
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuantityInput;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuantityInput != null)
                {
                }

                _txtQuantityInput = value;
                if (_txtQuantityInput != null)
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
                }

                _txtLocation = value;
                if (_txtLocation != null)
                {
                }
            }
        }

        private Label _lblItemName;

        internal Label lblItemName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblItemName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblItemName != null)
                {
                }

                _lblItemName = value;
                if (_lblItemName != null)
                {
                }
            }
        }

        private Label _lblItemNumber;

        internal Label lblItemNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblItemNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblItemNumber != null)
                {
                }

                _lblItemNumber = value;
                if (_lblItemNumber != null)
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
            _lblItemName = new Label();
            _txtName = new TextBox();
            _txtNumber = new TextBox();
            _lblItemNumber = new Label();
            _Label3 = new Label();
            _Label4 = new Label();
            _Label5 = new Label();
            _txtQuantityPreviouslyReceived = new TextBox();
            _txtTotalquantity = new TextBox();
            _txtQuantityInput = new TextBox();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _Label6 = new Label();
            _txtLocation = new TextBox();
            _GroupBox1 = new GroupBox();
            _GroupBox2 = new GroupBox();
            _GroupBox1.SuspendLayout();
            _GroupBox2.SuspendLayout();
            SuspendLayout();
            //
            // lblItemName
            //
            _lblItemName.Location = new Point(16, 24);
            _lblItemName.Name = "lblItemName";
            _lblItemName.Size = new Size(96, 23);
            _lblItemName.TabIndex = 2;
            _lblItemName.Text = "Item Name:";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(136, 26);
            _txtName.Name = "txtName";
            _txtName.ReadOnly = true;
            _txtName.Size = new Size(288, 21);
            _txtName.TabIndex = 1;
            //
            // txtNumber
            //
            _txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNumber.Location = new Point(136, 56);
            _txtNumber.Name = "txtNumber";
            _txtNumber.ReadOnly = true;
            _txtNumber.Size = new Size(288, 21);
            _txtNumber.TabIndex = 2;
            //
            // lblItemNumber
            //
            _lblItemNumber.Location = new Point(16, 56);
            _lblItemNumber.Name = "lblItemNumber";
            _lblItemNumber.Size = new Size(96, 23);
            _lblItemNumber.TabIndex = 4;
            _lblItemNumber.Text = "Item Number:";
            //
            // Label3
            //
            _Label3.Location = new Point(16, 120);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(100, 23);
            _Label3.TabIndex = 6;
            _Label3.Text = "Total Ordered:";
            //
            // Label4
            //
            _Label4.Location = new Point(16, 152);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(104, 23);
            _Label4.TabIndex = 7;
            _Label4.Text = "Total Received :";
            //
            // Label5
            //
            _Label5.Location = new Point(15, 24);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(124, 23);
            _Label5.TabIndex = 8;
            _Label5.Text = "Quantity Received:";
            //
            // txtQuantityPreviouslyReceived
            //
            _txtQuantityPreviouslyReceived.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtQuantityPreviouslyReceived.Location = new Point(136, 154);
            _txtQuantityPreviouslyReceived.Name = "txtQuantityPreviouslyReceived";
            _txtQuantityPreviouslyReceived.ReadOnly = true;
            _txtQuantityPreviouslyReceived.Size = new Size(288, 21);
            _txtQuantityPreviouslyReceived.TabIndex = 5;
            //
            // txtTotalquantity
            //
            _txtTotalquantity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTotalquantity.Location = new Point(136, 122);
            _txtTotalquantity.Name = "txtTotalquantity";
            _txtTotalquantity.ReadOnly = true;
            _txtTotalquantity.Size = new Size(288, 21);
            _txtTotalquantity.TabIndex = 4;
            //
            // txtQuantityInput
            //
            _txtQuantityInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtQuantityInput.Location = new Point(136, 24);
            _txtQuantityInput.Name = "txtQuantityInput";
            _txtQuantityInput.Size = new Size(224, 21);
            _txtQuantityInput.TabIndex = 6;
            //
            // btnOK
            //
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(368, 24);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(56, 23);
            _btnOK.TabIndex = 7;
            _btnOK.Text = "OK";
            //
            // Label6
            //
            _Label6.Location = new Point(16, 88);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(72, 23);
            _Label6.TabIndex = 14;
            _Label6.Text = "Order For:";
            //
            // txtLocation
            //
            _txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtLocation.Location = new Point(136, 90);
            _txtLocation.Name = "txtLocation";
            _txtLocation.ReadOnly = true;
            _txtLocation.Size = new Size(288, 21);
            _txtLocation.TabIndex = 3;
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_lblItemNumber);
            _GroupBox1.Controls.Add(_lblItemName);
            _GroupBox1.Controls.Add(_Label6);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_txtNumber);
            _GroupBox1.Controls.Add(_txtLocation);
            _GroupBox1.Controls.Add(_txtName);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_txtTotalquantity);
            _GroupBox1.Controls.Add(_txtQuantityPreviouslyReceived);
            _GroupBox1.Location = new Point(8, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(432, 184);
            _GroupBox1.TabIndex = 16;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Stock Details";
            //
            // GroupBox2
            //
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox2.Controls.Add(_txtQuantityInput);
            _GroupBox2.Controls.Add(_btnOK);
            _GroupBox2.Controls.Add(_Label5);
            _GroupBox2.Location = new Point(8, 232);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(432, 56);
            _GroupBox2.TabIndex = 17;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Stock Received";
            //
            // FRMReceiveStock
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(448, 302);
            Controls.Add(_GroupBox2);
            Controls.Add(_GroupBox1);
            MaximizeBox = false;
            MaximumSize = new Size(456, 336);
            MinimizeBox = false;
            MinimumSize = new Size(456, 336);
            Name = "FRMReceiveStock";
            Text = "Stock Received Manager";
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_GroupBox2, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            _GroupBox2.ResumeLayout(false);
            _GroupBox2.PerformLayout();
            ResumeLayout(false);
        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            Order = App.DB.Order.Order_Get(Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0)));
            OrderType = Entity.Sys.Helper.MakeStringValid(get_GetParameter(1));
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(2));
            LoadForm(sender, e, this);
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

        
        
        private Entity.Orders.Order _oOrder = null;

        public Entity.Orders.Order Order
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

        private string _OrderType = "";

        public string OrderType
        {
            get
            {
                return _OrderType;
            }

            set
            {
                _OrderType = value;
                var switchExpr = OrderType;
                switch (switchExpr)
                {
                    case "OrderProduct":
                        {
                            lblItemName.Text = "Product Name: ";
                            lblItemNumber.Text = "Product Number: ";
                            break;
                        }

                    case "OrderPart":
                        {
                            lblItemName.Text = "Part Name: ";
                            lblItemNumber.Text = "Part Number: ";
                            break;
                        }

                    case "OrderLocationProduct":
                        {
                            lblItemName.Text = "Product Name: ";
                            lblItemNumber.Text = "Product Number: ";
                            break;
                        }

                    case "OrderLocationPart":
                        {
                            lblItemName.Text = "Part Name: ";
                            lblItemNumber.Text = "Part Number: ";
                            break;
                        }
                }
            }
        }

        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
                Entity.Products.Product oProduct;
                Entity.Parts.Part oPart;
                var switchExpr = OrderType;
                switch (switchExpr)
                {
                    case "OrderProduct":
                        {
                            OrderProduct = App.DB.OrderProduct.OrderProduct_Get(ID);
                            var oProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID);
                            oProduct = App.DB.Product.Product_Get(oProductSupplier.ProductID);
                            txtTotalquantity.Text = OrderProduct.Quantity.ToString();
                            txtQuantityPreviouslyReceived.Text = OrderProduct.QuantityReceived.ToString();
                            txtName.Text = oProduct.Name;
                            txtNumber.Text = oProduct.Number;
                            break;
                        }

                    case "OrderPart":
                        {
                            OrderPart = App.DB.OrderPart.OrderPart_Get(ID);
                            var oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID);
                            oPart = App.DB.Part.Part_Get(oPartSupplier.PartID);
                            txtTotalquantity.Text = OrderPart.Quantity.ToString();
                            txtQuantityPreviouslyReceived.Text = OrderPart.QuantityReceived.ToString();
                            txtName.Text = oPart.Name;
                            txtNumber.Text = oPart.Number;
                            break;
                        }

                    case "OrderLocationProduct":
                        {
                            OrderLocationProduct = App.DB.OrderLocationProduct.OrderLocationProduct_Get(ID);
                            oProduct = App.DB.Product.Product_Get(OrderLocationProduct.ProductID);
                            txtTotalquantity.Text = OrderLocationProduct.Quantity.ToString();
                            txtQuantityPreviouslyReceived.Text = OrderLocationProduct.QuantityReceived.ToString();
                            txtName.Text = oProduct.Name;
                            txtNumber.Text = oProduct.Number;
                            break;
                        }

                    case "OrderLocationPart":
                        {
                            OrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get(ID);
                            oPart = App.DB.Part.Part_Get(OrderLocationPart.PartID);
                            txtTotalquantity.Text = OrderLocationPart.Quantity.ToString();
                            txtQuantityPreviouslyReceived.Text = OrderLocationPart.QuantityReceived.ToString();
                            txtName.Text = oPart.Name;
                            txtNumber.Text = oPart.Number;
                            break;
                        }
                }

                var switchExpr1 = Order.OrderTypeID;
                switch (switchExpr1)
                {
                    case (int)(Entity.Sys.Enums.OrderType.Customer):
                        {
                            var oSiteOrder = App.DB.SiteOrder.SiteOrder_GetForOrder(Order.OrderID);
                            if (oSiteOrder is object)
                            {
                                var oSite = App.DB.Sites.Get(oSiteOrder.SiteID);
                                var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                                txtLocation.Text = "Property:" + oSite.Address1 + ", " + oSite.Postcode + " (" + oCustomer.AccountNumber + ")";
                            }
                            else
                            {
                                var oCustomer = App.DB.Customer.Customer_GetForOrder(Order.OrderID);
                                txtLocation.Text = "Customer:" + oCustomer.Name + " - " + oCustomer.AccountNumber;
                            }

                            break;
                        }

                    case (int)(Entity.Sys.Enums.OrderType.Job):
                        {
                            txtLocation.Text = "Engineer Visit";
                            break;
                        }

                    default:
                        {
                            var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(Order.OrderID);
                            var oLocation = App.DB.Location.Locations_Get(oOrderLocation.LocationID);
                            if (oLocation.VanID > 0)
                            {
                                txtLocation.Text = "Van: " + App.DB.Van.Van_Get(oLocation.VanID).Registration;
                            }
                            else if (oLocation.WarehouseID > 0)
                            {
                                txtLocation.Text = "Warehouse: " + App.DB.Warehouse.Warehouse_Get(oLocation.WarehouseID).Name;
                            }

                            break;
                        }
                }
            }
        }

        private Entity.OrderParts.OrderPart _orderPart;

        public Entity.OrderParts.OrderPart OrderPart
        {
            get
            {
                return _orderPart;
            }

            set
            {
                _orderPart = value;
            }
        }

        private Entity.OrderProducts.OrderProduct _orderProduct;

        public Entity.OrderProducts.OrderProduct OrderProduct
        {
            get
            {
                return _orderProduct;
            }

            set
            {
                _orderProduct = value;
            }
        }

        private Entity.OrderLocationProduct.OrderLocationProduct _orderLocationProduct;

        public Entity.OrderLocationProduct.OrderLocationProduct OrderLocationProduct
        {
            get
            {
                return _orderLocationProduct;
            }

            set
            {
                _orderLocationProduct = value;
            }
        }

        private Entity.OrderLocationPart.OrderLocationPart _orderLocationPart;

        public Entity.OrderLocationPart.OrderLocationPart OrderLocationPart
        {
            get
            {
                return _orderLocationPart;
            }

            set
            {
                _orderLocationPart = value;
            }
        }

        private void FRMReceiveStock_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Entity.Sys.Helper.IsValidInteger(txtQuantityInput.Text.Trim()))
            {
                App.ShowMessage("Please enter the quantity that has been received", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (Conversions.ToInteger(txtQuantityInput.Text.Trim()) + Conversions.ToInteger(txtQuantityPreviouslyReceived.Text.Trim()) > Conversions.ToInteger(txtTotalquantity.Text.Trim()))
            {
                App.ShowMessage("Quantity received can not be greater than the quantity ordered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            UpdateOrderItems(Conversions.ToInteger(txtQuantityInput.Text.Trim()));
        }

        
        

        public void UpdateOrderItems(int QuantityInput)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var switchExpr = OrderType;
                switch (switchExpr)
                {
                    case "OrderProduct":
                        {
                            OrderProduct.SetQuantityReceived = OrderProduct.QuantityReceived + QuantityInput;
                            App.DB.OrderProduct.Update(OrderProduct);
                            var switchExpr1 = Order.OrderTypeID;
                            switch (switchExpr1)
                            {
                                case (int)(Entity.Sys.Enums.OrderType.Customer):
                                    {
                                        break;
                                    }
                                // DO NOTHING
                                case (int)(Entity.Sys.Enums.OrderType.Job):
                                    {
                                        break;
                                    }
                                // DO NOTHING
                                case (int)(Entity.Sys.Enums.OrderType.StockProfile):
                                    {
                                        break;
                                    }
                                // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                case (int)(Entity.Sys.Enums.OrderType.Warehouse):
                                    {
                                        var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderProduct.OrderID);
                                        var oProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID);
                                        var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                                        oProductTransaction.SetLocationID = oOrderLocation.LocationID;
                                        oProductTransaction.SetProductID = oProductSupplier.ProductID;
                                        oProductTransaction.SetOrderProductID = OrderProduct.OrderProductID;
                                        oProductTransaction.SetAmount = QuantityInput * oProductSupplier.QuantityInPack;
                                        oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockIn);
                                        App.DB.ProductTransaction.Insert(oProductTransaction);
                                        break;
                                    }
                            }

                            break;
                        }

                    case "OrderPart":
                        {
                            OrderPart.SetQuantityReceived = OrderPart.QuantityReceived + QuantityInput;
                            App.DB.OrderPart.Update(OrderPart);
                            var switchExpr2 = Order.OrderTypeID;
                            switch (switchExpr2)
                            {
                                case (int)(Entity.Sys.Enums.OrderType.Customer):
                                    {
                                        break;
                                    }
                                // DO NOTHING
                                case (int)(Entity.Sys.Enums.OrderType.Job):
                                    {
                                        break;
                                    }
                                // DO NOTHING
                                case (int)(Entity.Sys.Enums.OrderType.StockProfile):
                                    {
                                        break;
                                    }
                                // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                case (int)(Entity.Sys.Enums.OrderType.Warehouse):
                                    {
                                        var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID);
                                        var oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID);
                                        var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                        oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                        oPartTransaction.SetPartID = oPartSupplier.PartID;
                                        oPartTransaction.SetOrderPartID = OrderPart.OrderPartID;
                                        oPartTransaction.SetAmount = QuantityInput * oPartSupplier.QuantityInPack;
                                        oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockIn);
                                        App.DB.PartTransaction.Insert(oPartTransaction);
                                        break;
                                    }
                            }

                            break;
                        }

                    case "OrderLocationProduct":
                        {
                            var oProductTransaction = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(OrderLocationProduct.OrderLocationProductID);
                            oProductTransaction.SetAmount = oProductTransaction.Amount + QuantityInput;
                            App.DB.ProductTransaction.Update(oProductTransaction);
                            oProductTransaction.SetLocationID = OrderLocationProduct.LocationID;
                            oProductTransaction.SetProductID = OrderLocationProduct.ProductID;
                            oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID;
                            oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockOut);
                            oProductTransaction.SetAmount = -QuantityInput;
                            App.DB.ProductTransaction.Insert(oProductTransaction);
                            OrderLocationProduct.SetQuantityReceived = OrderLocationProduct.QuantityReceived + QuantityInput;
                            App.DB.OrderLocationProduct.Update(OrderLocationProduct);
                            var switchExpr3 = Order.OrderTypeID;
                            switch (switchExpr3)
                            {
                                case (int)(Entity.Sys.Enums.OrderType.Customer):
                                    {
                                        break;
                                    }
                                // DO NOTHING
                                case (int)(Entity.Sys.Enums.OrderType.Job):
                                    {
                                        break;
                                    }
                                // DO NOTHING
                                case (int)(Entity.Sys.Enums.OrderType.StockProfile):
                                    {
                                        break;
                                    }
                                // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                case (int)(Entity.Sys.Enums.OrderType.Warehouse):
                                    {
                                        Entity.OrderLocations.OrderLocation oOrderLocation;
                                        oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationProduct.OrderID);
                                        oProductTransaction.SetLocationID = oOrderLocation.LocationID;
                                        oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockIn);
                                        oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID;
                                        oProductTransaction.SetAmount = QuantityInput;
                                        oProductTransaction.SetProductID = OrderLocationProduct.ProductID;
                                        App.DB.ProductTransaction.Insert(oProductTransaction);
                                        break;
                                    }
                            }

                            break;
                        }

                    case "OrderLocationPart":
                        {
                            var oPartTransaction = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(OrderLocationPart.OrderLocationPartID);
                            oPartTransaction.SetAmount = oPartTransaction.Amount + QuantityInput;
                            App.DB.PartTransaction.Update(oPartTransaction);
                            oPartTransaction.SetLocationID = OrderLocationPart.LocationID;
                            oPartTransaction.SetPartID = OrderLocationPart.PartID;
                            oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID;
                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockOut);
                            oPartTransaction.SetAmount = -QuantityInput;
                            App.DB.PartTransaction.Insert(oPartTransaction);
                            OrderLocationPart.SetQuantityReceived = OrderLocationPart.QuantityReceived + QuantityInput;
                            App.DB.OrderLocationPart.Update(OrderLocationPart);
                            var switchExpr4 = Order.OrderTypeID;
                            switch (switchExpr4)
                            {
                                case (int)(Entity.Sys.Enums.OrderType.Customer):
                                    {
                                        break;
                                    }
                                // DO NOTHING
                                case (int)(Entity.Sys.Enums.OrderType.Job):
                                    {
                                        break;
                                    }
                                // DO NOTHING
                                case (int)(Entity.Sys.Enums.OrderType.StockProfile):
                                    {
                                        break;
                                    }
                                // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                case (int)(Entity.Sys.Enums.OrderType.Warehouse):
                                    {
                                        Entity.OrderLocations.OrderLocation oOrderLocation;
                                        oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationPart.OrderID);
                                        oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                        oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockIn);
                                        oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID;
                                        oPartTransaction.SetAmount = QuantityInput;
                                        oPartTransaction.SetPartID = OrderLocationPart.PartID;
                                        App.DB.PartTransaction.Insert(oPartTransaction);
                                        break;
                                    }
                            }

                            break;
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