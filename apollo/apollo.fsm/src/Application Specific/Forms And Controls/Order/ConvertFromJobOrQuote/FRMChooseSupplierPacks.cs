using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMChooseSupplierPacks : FRMBaseForm, IForm
    {
        

        public FRMChooseSupplierPacks() : base()
        {
            
            
            base.Load += FRMChooseSupplierPacks_Load;

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

        private ComboBox _cboPacks;

        internal ComboBox cboPacks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPacks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPacks != null)
                {
                }

                _cboPacks = value;
                if (_cboPacks != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._Label1 = new System.Windows.Forms.Label();
            this._cboPacks = new System.Windows.Forms.ComboBox();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(5, 21);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(248, 23);
            this._Label1.TabIndex = 2;
            this._Label1.Text = "Item available in the following amounts:";
            // 
            // _cboPacks
            // 
            this._cboPacks.Location = new System.Drawing.Point(253, 21);
            this._cboPacks.Name = "_cboPacks";
            this._cboPacks.Size = new System.Drawing.Size(240, 21);
            this._cboPacks.TabIndex = 3;
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(416, 72);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "OK";
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(8, 72);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 5;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FRMChooseSupplierPacks
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(496, 97);
            this.ControlBox = false;
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._cboPacks);
            this.Controls.Add(this._Label1);
            this.MaximumSize = new System.Drawing.Size(512, 136);
            this.MinimumSize = new System.Drawing.Size(512, 136);
            this.Name = "FRMChooseSupplierPacks";
            this.Text = "Choose Packs";
            this.ResumeLayout(false);

        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            SupplierID = get_GetParameter(0);
            ProductID = Conversions.ToInteger(get_GetParameter(1));
            PartID = Conversions.ToInteger(get_GetParameter(2));
            Trans = (System.Data.SqlClient.SqlTransaction)get_GetParameter(3);
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
        }

        
        
        private System.Data.SqlClient.SqlTransaction _trans;

        public System.Data.SqlClient.SqlTransaction Trans
        {
            get
            {
                return _trans;
            }

            set
            {
                _trans = value;
            }
        }

        private int _supplierID;

        public object SupplierID
        {
            get
            {
                return _supplierID;
            }

            set
            {
                _supplierID = Conversions.ToInteger(value);
            }
        }

        private int _productID;

        public int ProductID
        {
            get
            {
                return _productID;
            }

            set
            {
                _productID = value;
            }
        }

        private int _partID;

        public int PartID
        {
            get
            {
                return _partID;
            }

            set
            {
                _partID = value;
            }
        }

        private int _productSupplierID;

        public int ProductSupplierID
        {
            get
            {
                return _productSupplierID;
            }

            set
            {
                _productSupplierID = value;
            }
        }

        private int _partSupplierID;

        public int PartSupplierID
        {
            get
            {
                return _partSupplierID;
            }

            set
            {
                _partSupplierID = value;
            }
        }

        private int _Amount;

        public int Amount
        {
            get
            {
                return _Amount;
            }

            set
            {
                _Amount = value;
            }
        }

        private void FRMChooseSupplierPacks_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
            LoadPacks();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ProductID > 0)
            {
                ProductSupplierID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPacks));
            }
            else
            {
                PartSupplierID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPacks));
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
        

        public object LoadPacks()
        {
            if (ProductID > 0)
            {
                DataTable dtProductPacks;
                if (Trans is object)
                {
                    dtProductPacks = App.DB.ProductSupplier.ProductSupplierPacks_Get(ProductID, Conversions.ToInteger(SupplierID), Trans).Table;
                }
                else
                {
                    dtProductPacks = App.DB.ProductSupplier.ProductSupplierPacks_Get(ProductID, Conversions.ToInteger(SupplierID)).Table;
                }

                var argc = cboPacks;
                Combo.SetUpCombo(ref argc, dtProductPacks, "ProductSupplierID", "Packs", Entity.Sys.Enums.ComboValues.Please_Select);
                var argcombo = cboPacks;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(dtProductPacks.Rows[0]["ProductSupplierID"]));
            }
            else if (PartID > 0)
            {
                DataTable dtPartPacks;
                if (Trans is object)
                {
                    dtPartPacks = App.DB.PartSupplier.PartSupplierPacks_Get(PartID, Conversions.ToInteger(SupplierID), Trans).Table;
                }
                else
                {
                    dtPartPacks = App.DB.PartSupplier.PartSupplierPacks_Get(PartID, Conversions.ToInteger(SupplierID)).Table;
                }

                var argc1 = cboPacks;
                Combo.SetUpCombo(ref argc1, dtPartPacks, "PartSupplierID", "Packs", Entity.Sys.Enums.ComboValues.Please_Select);
                var argcombo1 = cboPacks;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, Conversions.ToString(dtPartPacks.Rows[0]["PartSupplierID"]));
            }

            return default;
        }

        
    }
}