using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMAddToQuote : FRMBaseForm, IForm
    {
        

        public FRMAddToQuote() : base()
        {
            
            
            base.Load += FRMAddToQuote_Load;

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

        private Button _btnConfirm;

        internal Button btnConfirm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnConfirm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnConfirm != null)
                {
                    _btnConfirm.Click -= btnConfirm_Click;
                }

                _btnConfirm = value;
                if (_btnConfirm != null)
                {
                    _btnConfirm.Click += btnConfirm_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox2 = new GroupBox();
            _Label3 = new Label();
            _txtSupplierCode = new TextBox();
            _txtBuyPrice = new TextBox();
            _Label6 = new Label();
            _btnConfirm = new Button();
            _btnConfirm.Click += new EventHandler(btnConfirm_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _GroupBox1 = new GroupBox();
            _lblName = new Label();
            _lblNumber = new Label();
            _txtName = new TextBox();
            _txtNumber = new TextBox();
            _lblSupplier = new Label();
            _txtSupplier = new TextBox();
            _lblQty = new Label();
            _txtQtyInPack = new TextBox();
            _GroupBox2.SuspendLayout();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            //
            // GroupBox2
            //
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox2.Controls.Add(_Label3);
            _GroupBox2.Controls.Add(_txtSupplierCode);
            _GroupBox2.Controls.Add(_txtBuyPrice);
            _GroupBox2.Controls.Add(_Label6);
            _GroupBox2.Controls.Add(_btnConfirm);
            _GroupBox2.Controls.Add(_btnCancel);
            _GroupBox2.Location = new Point(8, 195);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(512, 125);
            _GroupBox2.TabIndex = 23;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Quote Details";
            //
            // Label3
            //
            _Label3.Location = new Point(8, 24);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(104, 23);
            _Label3.TabIndex = 4;
            _Label3.Text = "Supplier Code:";
            //
            // txtSupplierCode
            //
            _txtSupplierCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSupplierCode.Location = new Point(128, 24);
            _txtSupplierCode.Name = "txtSupplierCode";
            _txtSupplierCode.Size = new Size(376, 21);
            _txtSupplierCode.TabIndex = 5;
            _txtSupplierCode.Text = "";
            //
            // txtBuyPrice
            //
            _txtBuyPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtBuyPrice.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtBuyPrice.Location = new Point(128, 63);
            _txtBuyPrice.Name = "txtBuyPrice";
            _txtBuyPrice.Size = new Size(376, 21);
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
            // btnConfirm
            //
            _btnConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnConfirm.Location = new Point(352, 96);
            _btnConfirm.Name = "btnConfirm";
            _btnConfirm.Size = new Size(88, 23);
            _btnConfirm.TabIndex = 9;
            _btnConfirm.Text = "Confirm";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnCancel.Location = new Point(448, 96);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(56, 23);
            _btnCancel.TabIndex = 10;
            _btnCancel.Text = "Cancel";
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
            _GroupBox1.Location = new Point(8, 35);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(512, 152);
            _GroupBox1.TabIndex = 22;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Request Details";
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
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Enabled = false;
            _txtName.Location = new Point(128, 24);
            _txtName.Name = "txtName";
            _txtName.ReadOnly = true;
            _txtName.Size = new Size(376, 21);
            _txtName.TabIndex = 1;
            _txtName.Text = "";
            //
            // txtNumber
            //
            _txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNumber.Enabled = false;
            _txtNumber.Location = new Point(128, 63);
            _txtNumber.Name = "txtNumber";
            _txtNumber.ReadOnly = true;
            _txtNumber.Size = new Size(376, 21);
            _txtNumber.TabIndex = 2;
            _txtNumber.Text = "";
            //
            // lblSupplier
            //
            _lblSupplier.Location = new Point(8, 88);
            _lblSupplier.Name = "lblSupplier";
            _lblSupplier.Size = new Size(80, 24);
            _lblSupplier.TabIndex = 5;
            _lblSupplier.Text = "Supplier:";
            //
            // txtSupplier
            //
            _txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSupplier.Enabled = false;
            _txtSupplier.Location = new Point(128, 95);
            _txtSupplier.Name = "txtSupplier";
            _txtSupplier.ReadOnly = true;
            _txtSupplier.Size = new Size(376, 21);
            _txtSupplier.TabIndex = 3;
            _txtSupplier.Text = "";
            //
            // lblQty
            //
            _lblQty.Location = new Point(8, 120);
            _lblQty.Name = "lblQty";
            _lblQty.Size = new Size(120, 23);
            _lblQty.TabIndex = 6;
            _lblQty.Text = "Quantity In Pack:";
            //
            // txtQtyInPack
            //
            _txtQtyInPack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtQtyInPack.Enabled = false;
            _txtQtyInPack.Location = new Point(128, 127);
            _txtQtyInPack.Name = "txtQtyInPack";
            _txtQtyInPack.ReadOnly = true;
            _txtQtyInPack.Size = new Size(376, 21);
            _txtQtyInPack.TabIndex = 4;
            _txtQtyInPack.Text = "";
            //
            // FRMAddToQuote
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(528, 326);
            Controls.Add(_GroupBox2);
            Controls.Add(_GroupBox1);
            MaximumSize = new Size(536, 360);
            MinimumSize = new Size(536, 360);
            Name = "FRMAddToQuote";
            Text = "Confrim Price Request";
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_GroupBox2, 0);
            _GroupBox2.ResumeLayout(false);
            _GroupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            QuoteID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
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

        
        
        private int _QuoteID;

        public int QuoteID
        {
            get
            {
                return _QuoteID;
            }

            set
            {
                _QuoteID = value;
            }
        }

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

        private void FRMAddToQuote_Load(object sender, EventArgs e)
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

        private void btnConfirm_Click(object sender, EventArgs e)
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
                    PartSupplier = App.DB.PartSupplier.Insert(PartSupplier);
                    App.DB.PartPriceRequest.Complete(PriceRequestID);
                }

                if (ProductSupplier is object)
                {
                    ProductSupplier.IgnoreExceptionsOnSetMethods = true;
                    ProductSupplier.SetPrice = txtBuyPrice.Text.Trim();
                    ProductSupplier.SetProductCode = txtSupplierCode.Text.Trim();
                    var val = new Entity.ProductSuppliers.ProductSupplierValidator();
                    val.Validate(ProductSupplier);
                    ProductSupplier = App.DB.ProductSupplier.Insert(ProductSupplier);
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