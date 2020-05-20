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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._lblItemName = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtNumber = new System.Windows.Forms.TextBox();
            this._lblItemNumber = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label5 = new System.Windows.Forms.Label();
            this._txtQuantityPreviouslyReceived = new System.Windows.Forms.TextBox();
            this._txtTotalquantity = new System.Windows.Forms.TextBox();
            this._txtQuantityInput = new System.Windows.Forms.TextBox();
            this._btnOK = new System.Windows.Forms.Button();
            this._Label6 = new System.Windows.Forms.Label();
            this._txtLocation = new System.Windows.Forms.TextBox();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._GroupBox1.SuspendLayout();
            this._GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lblItemName
            // 
            this._lblItemName.Location = new System.Drawing.Point(16, 24);
            this._lblItemName.Name = "_lblItemName";
            this._lblItemName.Size = new System.Drawing.Size(96, 23);
            this._lblItemName.TabIndex = 2;
            this._lblItemName.Text = "Item Name:";
            // 
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.Location = new System.Drawing.Point(136, 26);
            this._txtName.Name = "_txtName";
            this._txtName.ReadOnly = true;
            this._txtName.Size = new System.Drawing.Size(288, 21);
            this._txtName.TabIndex = 1;
            // 
            // _txtNumber
            // 
            this._txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNumber.Location = new System.Drawing.Point(136, 56);
            this._txtNumber.Name = "_txtNumber";
            this._txtNumber.ReadOnly = true;
            this._txtNumber.Size = new System.Drawing.Size(288, 21);
            this._txtNumber.TabIndex = 2;
            // 
            // _lblItemNumber
            // 
            this._lblItemNumber.Location = new System.Drawing.Point(16, 56);
            this._lblItemNumber.Name = "_lblItemNumber";
            this._lblItemNumber.Size = new System.Drawing.Size(96, 23);
            this._lblItemNumber.TabIndex = 4;
            this._lblItemNumber.Text = "Item Number:";
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(16, 120);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(100, 23);
            this._Label3.TabIndex = 6;
            this._Label3.Text = "Total Ordered:";
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(16, 152);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(104, 23);
            this._Label4.TabIndex = 7;
            this._Label4.Text = "Total Received :";
            // 
            // _Label5
            // 
            this._Label5.Location = new System.Drawing.Point(15, 24);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(124, 23);
            this._Label5.TabIndex = 8;
            this._Label5.Text = "Quantity Received:";
            // 
            // _txtQuantityPreviouslyReceived
            // 
            this._txtQuantityPreviouslyReceived.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtQuantityPreviouslyReceived.Location = new System.Drawing.Point(136, 154);
            this._txtQuantityPreviouslyReceived.Name = "_txtQuantityPreviouslyReceived";
            this._txtQuantityPreviouslyReceived.ReadOnly = true;
            this._txtQuantityPreviouslyReceived.Size = new System.Drawing.Size(288, 21);
            this._txtQuantityPreviouslyReceived.TabIndex = 5;
            // 
            // _txtTotalquantity
            // 
            this._txtTotalquantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTotalquantity.Location = new System.Drawing.Point(136, 122);
            this._txtTotalquantity.Name = "_txtTotalquantity";
            this._txtTotalquantity.ReadOnly = true;
            this._txtTotalquantity.Size = new System.Drawing.Size(288, 21);
            this._txtTotalquantity.TabIndex = 4;
            // 
            // _txtQuantityInput
            // 
            this._txtQuantityInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtQuantityInput.Location = new System.Drawing.Point(136, 24);
            this._txtQuantityInput.Name = "_txtQuantityInput";
            this._txtQuantityInput.Size = new System.Drawing.Size(224, 21);
            this._txtQuantityInput.TabIndex = 6;
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(368, 24);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(56, 23);
            this._btnOK.TabIndex = 7;
            this._btnOK.Text = "OK";
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(16, 88);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(72, 23);
            this._Label6.TabIndex = 14;
            this._Label6.Text = "Order For:";
            // 
            // _txtLocation
            // 
            this._txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtLocation.Location = new System.Drawing.Point(136, 90);
            this._txtLocation.Name = "_txtLocation";
            this._txtLocation.ReadOnly = true;
            this._txtLocation.Size = new System.Drawing.Size(288, 21);
            this._txtLocation.TabIndex = 3;
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._lblItemNumber);
            this._GroupBox1.Controls.Add(this._lblItemName);
            this._GroupBox1.Controls.Add(this._Label6);
            this._GroupBox1.Controls.Add(this._Label3);
            this._GroupBox1.Controls.Add(this._txtNumber);
            this._GroupBox1.Controls.Add(this._txtLocation);
            this._GroupBox1.Controls.Add(this._txtName);
            this._GroupBox1.Controls.Add(this._Label4);
            this._GroupBox1.Controls.Add(this._txtTotalquantity);
            this._GroupBox1.Controls.Add(this._txtQuantityPreviouslyReceived);
            this._GroupBox1.Location = new System.Drawing.Point(8, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(432, 212);
            this._GroupBox1.TabIndex = 16;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Stock Details";
            // 
            // _GroupBox2
            // 
            this._GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox2.Controls.Add(this._txtQuantityInput);
            this._GroupBox2.Controls.Add(this._btnOK);
            this._GroupBox2.Controls.Add(this._Label5);
            this._GroupBox2.Location = new System.Drawing.Point(8, 232);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(432, 56);
            this._GroupBox2.TabIndex = 17;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "Stock Received";
            // 
            // FRMReceiveStock
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(440, 297);
            this.Controls.Add(this._GroupBox2);
            this.Controls.Add(this._GroupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(456, 336);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(456, 336);
            this.Name = "FRMReceiveStock";
            this.Text = "Stock Received Manager";
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this._GroupBox2.ResumeLayout(false);
            this._GroupBox2.PerformLayout();
            this.ResumeLayout(false);

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