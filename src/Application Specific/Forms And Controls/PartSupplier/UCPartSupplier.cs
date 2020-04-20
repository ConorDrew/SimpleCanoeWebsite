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
    public class UCPartSupplier : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCPartSupplier() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCPartSupplier_Load;

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

        private GroupBox _grpPartSupplier;

        internal GroupBox grpPartSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPartSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPartSupplier != null)
                {
                }

                _grpPartSupplier = value;
                if (_grpPartSupplier != null)
                {
                }
            }
        }

        private TextBox _txtPartCode;

        internal TextBox txtPartCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartCode != null)
                {
                }

                _txtPartCode = value;
                if (_txtPartCode != null)
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
                    _cboSupplierID.SelectedIndexChanged -= cboSupplierID_SelectedIndexChanged;
                }

                _cboSupplierID = value;
                if (_cboSupplierID != null)
                {
                    _cboSupplierID.SelectedIndexChanged += cboSupplierID_SelectedIndexChanged;
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

        private TextBox _txtSecondaryPrice;

        internal TextBox txtSecondaryPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSecondaryPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSecondaryPrice != null)
                {
                    _txtSecondaryPrice.KeyDown -= txtPrice_TextChanged;
                }

                _txtSecondaryPrice = value;
                if (_txtSecondaryPrice != null)
                {
                    _txtSecondaryPrice.KeyDown += txtPrice_TextChanged;
                }
            }
        }

        private Label _lblSecondaryPrice;

        internal Label lblSecondaryPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSecondaryPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSecondaryPrice != null)
                {
                }

                _lblSecondaryPrice = value;
                if (_lblSecondaryPrice != null)
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
                    _txtPrice.KeyDown -= txtPrice_TextChanged;
                }

                _txtPrice = value;
                if (_txtPrice != null)
                {
                    _txtPrice.KeyDown += txtPrice_TextChanged;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpPartSupplier = new GroupBox();
            _txtSecondaryPrice = new TextBox();
            _txtSecondaryPrice.KeyDown += new KeyEventHandler(txtPrice_TextChanged);
            _lblSecondaryPrice = new Label();
            _txtPrice = new TextBox();
            _txtPrice.KeyDown += new KeyEventHandler(txtPrice_TextChanged);
            _Label1 = new Label();
            _txtPartCode = new TextBox();
            _lblPartCode = new Label();
            _cboSupplierID = new ComboBox();
            _cboSupplierID.SelectedIndexChanged += new EventHandler(cboSupplierID_SelectedIndexChanged);
            _lblSupplierID = new Label();
            _txtQuantityInPack = new TextBox();
            _lblQuantityInPack = new Label();
            _grpPartSupplier.SuspendLayout();
            SuspendLayout();
            // 
            // grpPartSupplier
            // 
            _grpPartSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpPartSupplier.Controls.Add(_txtSecondaryPrice);
            _grpPartSupplier.Controls.Add(_lblSecondaryPrice);
            _grpPartSupplier.Controls.Add(_txtPrice);
            _grpPartSupplier.Controls.Add(_Label1);
            _grpPartSupplier.Controls.Add(_txtPartCode);
            _grpPartSupplier.Controls.Add(_lblPartCode);
            _grpPartSupplier.Controls.Add(_cboSupplierID);
            _grpPartSupplier.Controls.Add(_lblSupplierID);
            _grpPartSupplier.Controls.Add(_txtQuantityInPack);
            _grpPartSupplier.Controls.Add(_lblQuantityInPack);
            _grpPartSupplier.Location = new Point(9, 1);
            _grpPartSupplier.Name = "grpPartSupplier";
            _grpPartSupplier.Size = new Size(578, 141);
            _grpPartSupplier.TabIndex = 1;
            _grpPartSupplier.TabStop = false;
            _grpPartSupplier.Text = "Main Details";
            // 
            // txtSecondaryPrice
            // 
            _txtSecondaryPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSecondaryPrice.Location = new Point(376, 107);
            _txtSecondaryPrice.Name = "txtSecondaryPrice";
            _txtSecondaryPrice.Size = new Size(192, 21);
            _txtSecondaryPrice.TabIndex = 33;
            _txtSecondaryPrice.Visible = false;
            // 
            // lblSecondaryPrice
            // 
            _lblSecondaryPrice.Location = new Point(263, 107);
            _lblSecondaryPrice.Name = "lblSecondaryPrice";
            _lblSecondaryPrice.Size = new Size(105, 23);
            _lblSecondaryPrice.TabIndex = 34;
            _lblSecondaryPrice.Text = "Secondary Price";
            _lblSecondaryPrice.Visible = false;
            // 
            // txtPrice
            // 
            _txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPrice.Location = new Point(376, 80);
            _txtPrice.Name = "txtPrice";
            _txtPrice.Size = new Size(192, 21);
            _txtPrice.TabIndex = 4;
            // 
            // Label1
            // 
            _Label1.Location = new Point(328, 80);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(40, 23);
            _Label1.TabIndex = 32;
            _Label1.Text = "Price";
            // 
            // txtPartCode
            // 
            _txtPartCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPartCode.Location = new Point(128, 52);
            _txtPartCode.MaxLength = 100;
            _txtPartCode.Name = "txtPartCode";
            _txtPartCode.Size = new Size(440, 21);
            _txtPartCode.TabIndex = 2;
            _txtPartCode.Tag = "PartSupplier.PartCode";
            // 
            // lblPartCode
            // 
            _lblPartCode.Location = new Point(8, 53);
            _lblPartCode.Name = "lblPartCode";
            _lblPartCode.Size = new Size(111, 20);
            _lblPartCode.TabIndex = 31;
            _lblPartCode.Text = "Part Code (SPN)";
            // 
            // cboSupplierID
            // 
            _cboSupplierID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboSupplierID.Cursor = Cursors.Hand;
            _cboSupplierID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSupplierID.Location = new Point(128, 23);
            _cboSupplierID.Name = "cboSupplierID";
            _cboSupplierID.Size = new Size(440, 21);
            _cboSupplierID.TabIndex = 1;
            _cboSupplierID.Tag = "PartSupplier.SupplierID";
            // 
            // lblSupplierID
            // 
            _lblSupplierID.Location = new Point(8, 24);
            _lblSupplierID.Name = "lblSupplierID";
            _lblSupplierID.Size = new Size(69, 20);
            _lblSupplierID.TabIndex = 31;
            _lblSupplierID.Text = "Supplier ";
            // 
            // txtQuantityInPack
            // 
            _txtQuantityInPack.Location = new Point(128, 80);
            _txtQuantityInPack.MaxLength = 8;
            _txtQuantityInPack.Name = "txtQuantityInPack";
            _txtQuantityInPack.Size = new Size(184, 21);
            _txtQuantityInPack.TabIndex = 3;
            _txtQuantityInPack.Tag = "PartSupplier.QuantityInPack";
            _txtQuantityInPack.Text = "1";
            // 
            // lblQuantityInPack
            // 
            _lblQuantityInPack.Location = new Point(8, 82);
            _lblQuantityInPack.Name = "lblQuantityInPack";
            _lblQuantityInPack.Size = new Size(111, 20);
            _lblQuantityInPack.TabIndex = 31;
            _lblQuantityInPack.Text = "Quantity In Pack";
            // 
            // UCPartSupplier
            // 
            Controls.Add(_grpPartSupplier);
            Name = "UCPartSupplier";
            Size = new Size(592, 150);
            _grpPartSupplier.ResumeLayout(false);
            _grpPartSupplier.PerformLayout();
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
                return CurrentPartSupplier;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _PartID = 0;
        private bool _PrimaryUpdate = false;
        private bool _SecondaryUpdate = false;

        public int PartID
        {
            get
            {
                return _PartID;
            }

            set
            {
                _PartID = value;
            }
        }

        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.PartSuppliers.PartSupplier _currentPartSupplier;

        public Entity.PartSuppliers.PartSupplier CurrentPartSupplier
        {
            get
            {
                return _currentPartSupplier;
            }

            set
            {
                _currentPartSupplier = value;
                if (CurrentPartSupplier is null)
                {
                    CurrentPartSupplier = new Entity.PartSuppliers.PartSupplier();
                    CurrentPartSupplier.Exists = false;
                    txtQuantityInPack.Text = "1";
                }

                if (CurrentPartSupplier.Exists)
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

        private void UCPartSupplier_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentPartSupplier = App.DB.PartSupplier.PartSupplier_Get(ID);
            }

            txtPartCode.Text = CurrentPartSupplier.PartCode;
            var argcombo = cboSupplierID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentPartSupplier.SupplierID.ToString());
            txtQuantityInPack.Text = CurrentPartSupplier.QuantityInPack.ToString();
            txtPrice.Text = CurrentPartSupplier.Price.ToString();
            txtSecondaryPrice.Text = CurrentPartSupplier.SecondaryPrice.ToString();
            if (!App.DB.Supplier.Supplier_GetSecondaryPrice(CurrentPartSupplier.SupplierID))
            {
                txtSecondaryPrice.Visible = false;
                lblSecondaryPrice.Visible = false;
            }
        }

        public bool Save()
        {
            try
            {
                // If EnterOverridePassword() Then
                Entity.Sys.Enums.SecuritySystemModules ssm;
                ssm = Entity.Sys.Enums.SecuritySystemModules.EditParts;
                Entity.Sys.Enums.SecuritySystemModules ssm2;
                ssm2 = Entity.Sys.Enums.SecuritySystemModules.CreateParts;
                if (App.loggedInUser.HasAccessToModule(ssm) == true | App.loggedInUser.HasAccessToModule(ssm2) == true)
                {
                    Cursor = Cursors.WaitCursor;
                    CurrentPartSupplier.IgnoreExceptionsOnSetMethods = true;
                    CurrentPartSupplier.SetPartCode = txtPartCode.Text.Trim();
                    CurrentPartSupplier.SetPartID = PartID;
                    CurrentPartSupplier.SetSupplierID = Combo.get_GetSelectedItemValue(cboSupplierID);
                    CurrentPartSupplier.SetQuantityInPack = txtQuantityInPack.Text.Trim();
                    CurrentPartSupplier.SetPrice = txtPrice.Text.Trim();
                    if (!string.IsNullOrEmpty(txtSecondaryPrice.Text.Trim()))
                    {
                        CurrentPartSupplier.SetSecondaryPrice = txtSecondaryPrice.Text.Trim();
                    }

                    var cV = new Entity.PartSuppliers.PartSupplierValidator();
                    cV.Validate(CurrentPartSupplier);
                    if (CurrentPartSupplier.Exists)
                    {
                        App.DB.PartSupplier.Update(CurrentPartSupplier, _PrimaryUpdate, _SecondaryUpdate);
                    }
                    else
                    {
                        CurrentPartSupplier = App.DB.PartSupplier.Insert(CurrentPartSupplier);
                    }

                    StateChanged?.Invoke(CurrentPartSupplier.PartSupplierID);
                    return true;
                }
                else
                {
                    return false;
                }
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

        private void cboSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!App.DB.Supplier.Supplier_GetSecondaryPrice(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboSupplierID))))
            {
                txtSecondaryPrice.Visible = false;
                lblSecondaryPrice.Visible = false;
            }
            else
            {
                txtSecondaryPrice.Visible = true;
                lblSecondaryPrice.Visible = true;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if ((((TextBox)sender).Name ?? "") == "txtPrice")
            {
                _PrimaryUpdate = true;
            }
            else if ((((TextBox)sender).Name ?? "") == "txtSecondaryPrice")
            {
                _SecondaryUpdate = true;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}