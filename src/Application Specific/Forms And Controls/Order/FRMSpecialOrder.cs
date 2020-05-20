using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMSpecialOrder : FRMBaseForm
    {
        public FRMSpecialOrder()
        {
            base.Load += FRMSpecialOrder_Load;
        }

        public FRMSpecialOrder(int supplierCode, double price, int quantity) : base()
        {
            base.Load += FRMSpecialOrder_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            _supplierCode = supplierCode;
            _price = price;
            _quantity = quantity;

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

        private GroupBox _gpbSpecialOrder;

        private TextBox _txtQuantity;

        internal TextBox txtQuantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuantity != null)
                {
                }

                _txtQuantity = value;
                if (_txtQuantity != null)
                {
                }
            }
        }

        private Label _lblQuantity;

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

        private Button _btnAddPart;

        private TextBox _txtPrice;

        internal TextBox txtPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPrice != null)
                {
                }

                _txtPrice = value;
                if (_txtPrice != null)
                {
                }
            }
        }

        private Label _lblPrice;

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

        private Label _lblSupplier;

        private TextBox _txtSPN;

        internal TextBox txtSPN
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSPN;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSPN != null)
                {
                }

                _txtSPN = value;
                if (_txtSPN != null)
                {
                }
            }
        }

        private Label _lblPartCode;

        private TextBox _txtPartName;

        internal TextBox txtPartName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartName != null)
                {
                }

                _txtPartName = value;
                if (_txtPartName != null)
                {
                }
            }
        }

        private Label _lblPartName;

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._gpbSpecialOrder = new System.Windows.Forms.GroupBox();
            this._txtQuantity = new System.Windows.Forms.TextBox();
            this._lblQuantity = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnAddPart = new System.Windows.Forms.Button();
            this._txtPrice = new System.Windows.Forms.TextBox();
            this._lblPrice = new System.Windows.Forms.Label();
            this._txtSupplier = new System.Windows.Forms.TextBox();
            this._lblSupplier = new System.Windows.Forms.Label();
            this._txtSPN = new System.Windows.Forms.TextBox();
            this._lblPartCode = new System.Windows.Forms.Label();
            this._txtPartName = new System.Windows.Forms.TextBox();
            this._lblPartName = new System.Windows.Forms.Label();
            this._gpbSpecialOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gpbSpecialOrder
            // 
            this._gpbSpecialOrder.Controls.Add(this._txtQuantity);
            this._gpbSpecialOrder.Controls.Add(this._lblQuantity);
            this._gpbSpecialOrder.Controls.Add(this._btnCancel);
            this._gpbSpecialOrder.Controls.Add(this._btnAddPart);
            this._gpbSpecialOrder.Controls.Add(this._txtPrice);
            this._gpbSpecialOrder.Controls.Add(this._lblPrice);
            this._gpbSpecialOrder.Controls.Add(this._txtSupplier);
            this._gpbSpecialOrder.Controls.Add(this._lblSupplier);
            this._gpbSpecialOrder.Controls.Add(this._txtSPN);
            this._gpbSpecialOrder.Controls.Add(this._lblPartCode);
            this._gpbSpecialOrder.Controls.Add(this._txtPartName);
            this._gpbSpecialOrder.Controls.Add(this._lblPartName);
            this._gpbSpecialOrder.Location = new System.Drawing.Point(12, 12);
            this._gpbSpecialOrder.Name = "_gpbSpecialOrder";
            this._gpbSpecialOrder.Size = new System.Drawing.Size(449, 209);
            this._gpbSpecialOrder.TabIndex = 17;
            this._gpbSpecialOrder.TabStop = false;
            this._gpbSpecialOrder.Text = "Special Order";
            // 
            // _txtQuantity
            // 
            this._txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtQuantity.Location = new System.Drawing.Point(95, 116);
            this._txtQuantity.Name = "_txtQuantity";
            this._txtQuantity.Size = new System.Drawing.Size(112, 21);
            this._txtQuantity.TabIndex = 45;
            // 
            // _lblQuantity
            // 
            this._lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblQuantity.Location = new System.Drawing.Point(11, 119);
            this._lblQuantity.Name = "_lblQuantity";
            this._lblQuantity.Size = new System.Drawing.Size(78, 18);
            this._lblQuantity.TabIndex = 52;
            this._lblQuantity.Text = "Quantity";
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(14, 174);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(88, 24);
            this._btnCancel.TabIndex = 47;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _btnAddPart
            // 
            this._btnAddPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddPart.Location = new System.Drawing.Point(367, 174);
            this._btnAddPart.Name = "_btnAddPart";
            this._btnAddPart.Size = new System.Drawing.Size(71, 24);
            this._btnAddPart.TabIndex = 46;
            this._btnAddPart.Text = "Add";
            this._btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // _txtPrice
            // 
            this._txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtPrice.Location = new System.Drawing.Point(326, 75);
            this._txtPrice.Name = "_txtPrice";
            this._txtPrice.Size = new System.Drawing.Size(112, 21);
            this._txtPrice.TabIndex = 44;
            // 
            // _lblPrice
            // 
            this._lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblPrice.Location = new System.Drawing.Point(242, 78);
            this._lblPrice.Name = "_lblPrice";
            this._lblPrice.Size = new System.Drawing.Size(78, 18);
            this._lblPrice.TabIndex = 51;
            this._lblPrice.Text = "Price";
            // 
            // _txtSupplier
            // 
            this._txtSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtSupplier.Enabled = false;
            this._txtSupplier.Location = new System.Drawing.Point(95, 75);
            this._txtSupplier.Name = "_txtSupplier";
            this._txtSupplier.Size = new System.Drawing.Size(112, 21);
            this._txtSupplier.TabIndex = 43;
            // 
            // _lblSupplier
            // 
            this._lblSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblSupplier.Location = new System.Drawing.Point(11, 78);
            this._lblSupplier.Name = "_lblSupplier";
            this._lblSupplier.Size = new System.Drawing.Size(78, 18);
            this._lblSupplier.TabIndex = 50;
            this._lblSupplier.Text = "Supplier";
            // 
            // _txtSPN
            // 
            this._txtSPN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtSPN.Location = new System.Drawing.Point(326, 31);
            this._txtSPN.Name = "_txtSPN";
            this._txtSPN.Size = new System.Drawing.Size(112, 21);
            this._txtSPN.TabIndex = 42;
            // 
            // _lblPartCode
            // 
            this._lblPartCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblPartCode.Location = new System.Drawing.Point(242, 34);
            this._lblPartCode.Name = "_lblPartCode";
            this._lblPartCode.Size = new System.Drawing.Size(78, 18);
            this._lblPartCode.TabIndex = 49;
            this._lblPartCode.Text = "Part Code";
            // 
            // _txtPartName
            // 
            this._txtPartName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtPartName.Location = new System.Drawing.Point(95, 31);
            this._txtPartName.Name = "_txtPartName";
            this._txtPartName.Size = new System.Drawing.Size(112, 21);
            this._txtPartName.TabIndex = 41;
            // 
            // _lblPartName
            // 
            this._lblPartName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblPartName.Location = new System.Drawing.Point(11, 34);
            this._lblPartName.Name = "_lblPartName";
            this._lblPartName.Size = new System.Drawing.Size(78, 18);
            this._lblPartName.TabIndex = 48;
            this._lblPartName.Text = "Part Name";
            // 
            // FRMSpecialOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(471, 228);
            this.ControlBox = false;
            this.Controls.Add(this._gpbSpecialOrder);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMSpecialOrder";
            this.Text = "Orders - Special Order";
            this._gpbSpecialOrder.ResumeLayout(false);
            this._gpbSpecialOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        private int _supplierCode = 0;

        public int SupplierCode
        {
            get
            {
                return _supplierCode;
            }
        }

        private double _price = 0.0;

        public double Price
        {
            get
            {
                return _price;
            }
        }

        private string _partName = "";

        public string PartName
        {
            get
            {
                return _partName;
            }
        }

        private string _spn = "";

        public string SPN
        {
            get
            {
                return _spn;
            }
        }

        private int _quantity = 0;

        public int Quantity
        {
            get
            {
                return _quantity;
            }
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            _spn = txtSPN.Text;
            _partName = txtPartName.Text;
            try
            {
                _price = Convert.ToDouble(txtPrice.Text);
                _quantity = Convert.ToInt32(txtQuantity.Text);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Quantity/Price is incorrect format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void FRMSpecialOrder_Load(object sender, EventArgs e)
        {
            if (SupplierCode == 0)
            {
                txtPrice.Text = 0.ToString();
                txtSupplier.Text = "";
                txtQuantity.Text = 1.ToString();
            }
            else
            {
                txtPrice.Text = Price.ToString();
                int supplierID = App.DB.PartSupplier.PartSupplier_Get(SupplierCode).SupplierID;
                string supplier = App.DB.Supplier.Supplier_Get(supplierID).Name;
                txtSupplier.Text = supplier;
                txtQuantity.Text = Quantity.ToString();
            }
        }
    }
}