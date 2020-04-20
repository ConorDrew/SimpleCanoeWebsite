using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class UCProductSupplier : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCProductSupplier() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCProductSupplier_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboSupplierID;
            Combo.SetUpCombo(ref argc, App.DB.Supplier.Supplier_GetAll().Table, "SupplierID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private GroupBox _grpProductSupplier;

        internal GroupBox grpProductSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpProductSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpProductSupplier != null)
                {
                }

                _grpProductSupplier = value;
                if (_grpProductSupplier != null)
                {
                }
            }
        }

        private ComboBox _cboSupplierID;

        internal ComboBox cboSupplierID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSupplierID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSupplierID != null)
                {
                }

                _cboSupplierID = value;
                if (_cboSupplierID != null)
                {
                }
            }
        }

        private Label _lblSupplierID;

        internal Label lblSupplierID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSupplierID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSupplierID != null)
                {
                }

                _lblSupplierID = value;
                if (_lblSupplierID != null)
                {
                }
            }
        }

        private TextBox _txtProductCode;

        internal TextBox txtProductCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProductCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProductCode != null)
                {
                }

                _txtProductCode = value;
                if (_txtProductCode != null)
                {
                }
            }
        }

        private Label _lblProductCode;

        internal Label lblProductCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProductCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProductCode != null)
                {
                }

                _lblProductCode = value;
                if (_lblProductCode != null)
                {
                }
            }
        }

        private TextBox _txtQuantityInPack;

        internal TextBox txtQuantityInPack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuantityInPack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuantityInPack != null)
                {
                }

                _txtQuantityInPack = value;
                if (_txtQuantityInPack != null)
                {
                }
            }
        }

        private Label _lblQuantityInPack;

        internal Label lblQuantityInPack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuantityInPack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuantityInPack != null)
                {
                }

                _lblQuantityInPack = value;
                if (_lblQuantityInPack != null)
                {
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpProductSupplier = new GroupBox();
            _txtPrice = new TextBox();
            _Label1 = new Label();
            _cboSupplierID = new ComboBox();
            _lblSupplierID = new Label();
            _txtProductCode = new TextBox();
            _lblProductCode = new Label();
            _txtQuantityInPack = new TextBox();
            _lblQuantityInPack = new Label();
            _grpProductSupplier.SuspendLayout();
            SuspendLayout();
            // 
            // grpProductSupplier
            // 
            _grpProductSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpProductSupplier.Controls.Add(_txtPrice);
            _grpProductSupplier.Controls.Add(_Label1);
            _grpProductSupplier.Controls.Add(_cboSupplierID);
            _grpProductSupplier.Controls.Add(_lblSupplierID);
            _grpProductSupplier.Controls.Add(_txtProductCode);
            _grpProductSupplier.Controls.Add(_lblProductCode);
            _grpProductSupplier.Controls.Add(_txtQuantityInPack);
            _grpProductSupplier.Controls.Add(_lblQuantityInPack);
            _grpProductSupplier.Location = new Point(0, 1);
            _grpProductSupplier.Name = "grpProductSupplier";
            _grpProductSupplier.Size = new Size(584, 112);
            _grpProductSupplier.TabIndex = 1;
            _grpProductSupplier.TabStop = false;
            _grpProductSupplier.Text = "Main Details";
            // 
            // txtPrice
            // 
            _txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPrice.Location = new Point(384, 80);
            _txtPrice.MaxLength = 8;
            _txtPrice.Name = "txtPrice";
            _txtPrice.Size = new Size(191, 21);
            _txtPrice.TabIndex = 33;
            _txtPrice.Tag = "ProductSupplier.Price";
            // 
            // Label1
            // 
            _Label1.Location = new Point(336, 80);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(37, 18);
            _Label1.TabIndex = 32;
            _Label1.Text = "Price";
            // 
            // cboSupplierID
            // 
            _cboSupplierID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboSupplierID.Cursor = Cursors.Hand;
            _cboSupplierID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSupplierID.Location = new Point(136, 24);
            _cboSupplierID.Name = "cboSupplierID";
            _cboSupplierID.Size = new Size(439, 21);
            _cboSupplierID.TabIndex = 3;
            _cboSupplierID.Tag = "ProductSupplier.SupplierID";
            // 
            // lblSupplierID
            // 
            _lblSupplierID.Location = new Point(8, 24);
            _lblSupplierID.Name = "lblSupplierID";
            _lblSupplierID.Size = new Size(67, 20);
            _lblSupplierID.TabIndex = 31;
            _lblSupplierID.Text = "Supplier";
            // 
            // txtProductCode
            // 
            _txtProductCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtProductCode.Location = new Point(136, 51);
            _txtProductCode.MaxLength = 100;
            _txtProductCode.Name = "txtProductCode";
            _txtProductCode.Size = new Size(439, 21);
            _txtProductCode.TabIndex = 4;
            _txtProductCode.Tag = "ProductSupplier.ProductCode";
            // 
            // lblProductCode
            // 
            _lblProductCode.Location = new Point(8, 51);
            _lblProductCode.Name = "lblProductCode";
            _lblProductCode.Size = new Size(94, 20);
            _lblProductCode.TabIndex = 31;
            _lblProductCode.Text = "Product Code";
            // 
            // txtQuantityInPack
            // 
            _txtQuantityInPack.Location = new Point(136, 79);
            _txtQuantityInPack.MaxLength = 8;
            _txtQuantityInPack.Name = "txtQuantityInPack";
            _txtQuantityInPack.Size = new Size(184, 21);
            _txtQuantityInPack.TabIndex = 6;
            _txtQuantityInPack.Tag = "ProductSupplier.QuantityInPack";
            _txtQuantityInPack.Text = "1";
            // 
            // lblQuantityInPack
            // 
            _lblQuantityInPack.Location = new Point(8, 79);
            _lblQuantityInPack.Name = "lblQuantityInPack";
            _lblQuantityInPack.Size = new Size(114, 20);
            _lblQuantityInPack.TabIndex = 31;
            _lblQuantityInPack.Text = "Quantity In Pack";
            // 
            // UCProductSupplier
            // 
            Controls.Add(_grpProductSupplier);
            Name = "UCProductSupplier";
            Size = new Size(592, 120);
            _grpProductSupplier.ResumeLayout(false);
            _grpProductSupplier.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentProductSupplier;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _ProductID = 0;

        public int ProductID
        {
            get
            {
                return _ProductID;
            }

            set
            {
                _ProductID = value;
            }
        }

        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.ProductSuppliers.ProductSupplier _currentProductSupplier;

        public Entity.ProductSuppliers.ProductSupplier CurrentProductSupplier
        {
            get
            {
                return _currentProductSupplier;
            }

            set
            {
                _currentProductSupplier = value;
                if (CurrentProductSupplier is null)
                {
                    CurrentProductSupplier = new Entity.ProductSuppliers.ProductSupplier();
                    CurrentProductSupplier.Exists = false;
                    txtQuantityInPack.Text = "1";
                }

                if (CurrentProductSupplier.Exists)
                {
                    Populate();
                    cboSupplierID.Enabled = false;
                }
                else
                {
                    cboSupplierID.Enabled = true;
                }
            }
        }

        private void UCProductSupplier_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(ID);
            }

            var argcombo = cboSupplierID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentProductSupplier.SupplierID.ToString());
            txtProductCode.Text = CurrentProductSupplier.ProductCode;
            txtQuantityInPack.Text = CurrentProductSupplier.QuantityInPack.ToString();
            txtPrice.Text = CurrentProductSupplier.Price.ToString();
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentProductSupplier.IgnoreExceptionsOnSetMethods = true;
                CurrentProductSupplier.SetProductID = ProductID;
                CurrentProductSupplier.SetSupplierID = Combo.get_GetSelectedItemValue(cboSupplierID);
                CurrentProductSupplier.SetProductCode = txtProductCode.Text.Trim();
                CurrentProductSupplier.SetQuantityInPack = txtQuantityInPack.Text.Trim();
                CurrentProductSupplier.SetPrice = txtPrice.Text;
                var cV = new Entity.ProductSuppliers.ProductSupplierValidator();
                cV.Validate(CurrentProductSupplier);
                if (CurrentProductSupplier.Exists)
                {
                    App.DB.ProductSupplier.Update(CurrentProductSupplier);
                }
                else
                {
                    CurrentProductSupplier = App.DB.ProductSupplier.Insert(CurrentProductSupplier);
                }

                StateChanged?.Invoke(CurrentProductSupplier.ProductSupplierID);
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