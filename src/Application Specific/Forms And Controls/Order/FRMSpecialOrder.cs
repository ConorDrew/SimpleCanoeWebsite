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

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        internal GroupBox gpbSpecialOrder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbSpecialOrder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbSpecialOrder != null)
                {
                }

                _gpbSpecialOrder = value;
                if (_gpbSpecialOrder != null)
                {
                }
            }
        }

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

        internal Label lblQuantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuantity != null)
                {
                }

                _lblQuantity = value;
                if (_lblQuantity != null)
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

        private Button _btnAddPart;

        internal Button btnAddPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddPart != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnAddPart.Click -= btnAddPart_Click;
                }

                _btnAddPart = value;
                if (_btnAddPart != null)
                {
                    _btnAddPart.Click += btnAddPart_Click;
                }
            }
        }

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

        internal Label lblPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPrice != null)
                {
                }

                _lblPrice = value;
                if (_lblPrice != null)
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

        internal Label lblPartCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPartCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPartCode != null)
                {
                }

                _lblPartCode = value;
                if (_lblPartCode != null)
                {
                }
            }
        }

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

        internal Label lblPartName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPartName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPartName != null)
                {
                }

                _lblPartName = value;
                if (_lblPartName != null)
                {
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _gpbSpecialOrder = new GroupBox();
            _txtQuantity = new TextBox();
            _lblQuantity = new Label();
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnAddPart = new Button();
            _btnAddPart.Click += new EventHandler(btnAddPart_Click);
            _txtPrice = new TextBox();
            _lblPrice = new Label();
            _txtSupplier = new TextBox();
            _lblSupplier = new Label();
            _txtSPN = new TextBox();
            _lblPartCode = new Label();
            _txtPartName = new TextBox();
            _lblPartName = new Label();
            _gpbSpecialOrder.SuspendLayout();
            SuspendLayout();
            //
            // gpbSpecialOrder
            //
            _gpbSpecialOrder.Controls.Add(_txtQuantity);
            _gpbSpecialOrder.Controls.Add(_lblQuantity);
            _gpbSpecialOrder.Controls.Add(_btnCancel);
            _gpbSpecialOrder.Controls.Add(_btnAddPart);
            _gpbSpecialOrder.Controls.Add(_txtPrice);
            _gpbSpecialOrder.Controls.Add(_lblPrice);
            _gpbSpecialOrder.Controls.Add(_txtSupplier);
            _gpbSpecialOrder.Controls.Add(_lblSupplier);
            _gpbSpecialOrder.Controls.Add(_txtSPN);
            _gpbSpecialOrder.Controls.Add(_lblPartCode);
            _gpbSpecialOrder.Controls.Add(_txtPartName);
            _gpbSpecialOrder.Controls.Add(_lblPartName);
            _gpbSpecialOrder.Location = new Point(12, 38);
            _gpbSpecialOrder.Name = "gpbSpecialOrder";
            _gpbSpecialOrder.Size = new Size(449, 183);
            _gpbSpecialOrder.TabIndex = 17;
            _gpbSpecialOrder.TabStop = false;
            _gpbSpecialOrder.Text = "Special Order";
            //
            // txtQuantity
            //
            _txtQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtQuantity.Location = new Point(95, 103);
            _txtQuantity.Name = "txtQuantity";
            _txtQuantity.Size = new Size(112, 21);
            _txtQuantity.TabIndex = 45;
            //
            // lblQuantity
            //
            _lblQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblQuantity.Location = new Point(11, 106);
            _lblQuantity.Name = "lblQuantity";
            _lblQuantity.Size = new Size(78, 18);
            _lblQuantity.TabIndex = 52;
            _lblQuantity.Text = "Quantity";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(14, 148);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(88, 24);
            _btnCancel.TabIndex = 47;
            _btnCancel.Text = "Cancel";
            //
            // btnAddPart
            //
            _btnAddPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddPart.Location = new Point(367, 148);
            _btnAddPart.Name = "btnAddPart";
            _btnAddPart.Size = new Size(71, 24);
            _btnAddPart.TabIndex = 46;
            _btnAddPart.Text = "Add";
            //
            // txtPrice
            //
            _txtPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtPrice.Location = new Point(326, 62);
            _txtPrice.Name = "txtPrice";
            _txtPrice.Size = new Size(112, 21);
            _txtPrice.TabIndex = 44;
            //
            // lblPrice
            //
            _lblPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblPrice.Location = new Point(242, 65);
            _lblPrice.Name = "lblPrice";
            _lblPrice.Size = new Size(78, 18);
            _lblPrice.TabIndex = 51;
            _lblPrice.Text = "Price";
            //
            // txtSupplier
            //
            _txtSupplier.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtSupplier.Enabled = false;
            _txtSupplier.Location = new Point(95, 62);
            _txtSupplier.Name = "txtSupplier";
            _txtSupplier.Size = new Size(112, 21);
            _txtSupplier.TabIndex = 43;
            //
            // lblSupplier
            //
            _lblSupplier.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblSupplier.Location = new Point(11, 65);
            _lblSupplier.Name = "lblSupplier";
            _lblSupplier.Size = new Size(78, 18);
            _lblSupplier.TabIndex = 50;
            _lblSupplier.Text = "Supplier";
            //
            // txtSPN
            //
            _txtSPN.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtSPN.Location = new Point(326, 18);
            _txtSPN.Name = "txtSPN";
            _txtSPN.Size = new Size(112, 21);
            _txtSPN.TabIndex = 42;
            //
            // lblPartCode
            //
            _lblPartCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblPartCode.Location = new Point(242, 21);
            _lblPartCode.Name = "lblPartCode";
            _lblPartCode.Size = new Size(78, 18);
            _lblPartCode.TabIndex = 49;
            _lblPartCode.Text = "Part Code";
            //
            // txtPartName
            //
            _txtPartName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtPartName.Location = new Point(95, 18);
            _txtPartName.Name = "txtPartName";
            _txtPartName.Size = new Size(112, 21);
            _txtPartName.TabIndex = 41;
            //
            // lblPartName
            //
            _lblPartName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblPartName.Location = new Point(11, 21);
            _lblPartName.Name = "lblPartName";
            _lblPartName.Size = new Size(78, 18);
            _lblPartName.TabIndex = 48;
            _lblPartName.Text = "Part Name";
            //
            // FRMSpecialOrder
            //
            AutoScaleBaseSize = new Size(6, 14);
            BackColor = SystemColors.Window;
            ClientSize = new Size(471, 228);
            ControlBox = false;
            Controls.Add(_gpbSpecialOrder);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FRMSpecialOrder";
            Text = "Orders - Special Order";
            Controls.SetChildIndex(_gpbSpecialOrder, 0);
            _gpbSpecialOrder.ResumeLayout(false);
            _gpbSpecialOrder.PerformLayout();
            ResumeLayout(false);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}