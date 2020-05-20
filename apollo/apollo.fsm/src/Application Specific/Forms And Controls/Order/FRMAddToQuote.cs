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
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtSupplierCode = new System.Windows.Forms.TextBox();
            this._txtBuyPrice = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._btnConfirm = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._lblName = new System.Windows.Forms.Label();
            this._lblNumber = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtNumber = new System.Windows.Forms.TextBox();
            this._lblSupplier = new System.Windows.Forms.Label();
            this._txtSupplier = new System.Windows.Forms.TextBox();
            this._lblQty = new System.Windows.Forms.Label();
            this._txtQtyInPack = new System.Windows.Forms.TextBox();
            this._GroupBox2.SuspendLayout();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox2
            // 
            this._GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox2.Controls.Add(this._Label3);
            this._GroupBox2.Controls.Add(this._txtSupplierCode);
            this._GroupBox2.Controls.Add(this._txtBuyPrice);
            this._GroupBox2.Controls.Add(this._Label6);
            this._GroupBox2.Controls.Add(this._btnConfirm);
            this._GroupBox2.Controls.Add(this._btnCancel);
            this._GroupBox2.Location = new System.Drawing.Point(8, 195);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(512, 125);
            this._GroupBox2.TabIndex = 23;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "Quote Details";
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(8, 24);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(104, 23);
            this._Label3.TabIndex = 4;
            this._Label3.Text = "Supplier Code:";
            // 
            // _txtSupplierCode
            // 
            this._txtSupplierCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSupplierCode.Location = new System.Drawing.Point(128, 24);
            this._txtSupplierCode.Name = "_txtSupplierCode";
            this._txtSupplierCode.Size = new System.Drawing.Size(376, 21);
            this._txtSupplierCode.TabIndex = 5;
            // 
            // _txtBuyPrice
            // 
            this._txtBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtBuyPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtBuyPrice.Location = new System.Drawing.Point(128, 63);
            this._txtBuyPrice.Name = "_txtBuyPrice";
            this._txtBuyPrice.Size = new System.Drawing.Size(376, 21);
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
            // _btnConfirm
            // 
            this._btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnConfirm.Location = new System.Drawing.Point(352, 96);
            this._btnConfirm.Name = "_btnConfirm";
            this._btnConfirm.Size = new System.Drawing.Size(88, 23);
            this._btnConfirm.TabIndex = 9;
            this._btnConfirm.Text = "Confirm";
            this._btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.Location = new System.Drawing.Point(448, 96);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(56, 23);
            this._btnCancel.TabIndex = 10;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this._GroupBox1.Size = new System.Drawing.Size(512, 175);
            this._GroupBox1.TabIndex = 22;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Request Details";
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
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.Enabled = false;
            this._txtName.Location = new System.Drawing.Point(128, 24);
            this._txtName.Name = "_txtName";
            this._txtName.ReadOnly = true;
            this._txtName.Size = new System.Drawing.Size(376, 21);
            this._txtName.TabIndex = 1;
            // 
            // _txtNumber
            // 
            this._txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNumber.Enabled = false;
            this._txtNumber.Location = new System.Drawing.Point(128, 63);
            this._txtNumber.Name = "_txtNumber";
            this._txtNumber.ReadOnly = true;
            this._txtNumber.Size = new System.Drawing.Size(376, 21);
            this._txtNumber.TabIndex = 2;
            // 
            // _lblSupplier
            // 
            this._lblSupplier.Location = new System.Drawing.Point(8, 88);
            this._lblSupplier.Name = "_lblSupplier";
            this._lblSupplier.Size = new System.Drawing.Size(80, 24);
            this._lblSupplier.TabIndex = 5;
            this._lblSupplier.Text = "Supplier:";
            // 
            // _txtSupplier
            // 
            this._txtSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSupplier.Enabled = false;
            this._txtSupplier.Location = new System.Drawing.Point(128, 95);
            this._txtSupplier.Name = "_txtSupplier";
            this._txtSupplier.ReadOnly = true;
            this._txtSupplier.Size = new System.Drawing.Size(376, 21);
            this._txtSupplier.TabIndex = 3;
            // 
            // _lblQty
            // 
            this._lblQty.Location = new System.Drawing.Point(8, 120);
            this._lblQty.Name = "_lblQty";
            this._lblQty.Size = new System.Drawing.Size(120, 23);
            this._lblQty.TabIndex = 6;
            this._lblQty.Text = "Quantity In Pack:";
            // 
            // _txtQtyInPack
            // 
            this._txtQtyInPack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtQtyInPack.Enabled = false;
            this._txtQtyInPack.Location = new System.Drawing.Point(128, 127);
            this._txtQtyInPack.Name = "_txtQtyInPack";
            this._txtQtyInPack.ReadOnly = true;
            this._txtQtyInPack.Size = new System.Drawing.Size(376, 21);
            this._txtQtyInPack.TabIndex = 4;
            // 
            // FRMAddToQuote
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(520, 321);
            this.Controls.Add(this._GroupBox2);
            this.Controls.Add(this._GroupBox1);
            this.MaximumSize = new System.Drawing.Size(536, 360);
            this.MinimumSize = new System.Drawing.Size(536, 360);
            this.Name = "FRMAddToQuote";
            this.Text = "Confrim Price Request";
            this._GroupBox2.ResumeLayout(false);
            this._GroupBox2.PerformLayout();
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this.ResumeLayout(false);

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