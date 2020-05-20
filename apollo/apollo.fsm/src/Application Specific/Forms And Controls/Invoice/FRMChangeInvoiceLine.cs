using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMChangeInvoiceLine : FRMBaseForm, IForm
    {
        public FRMChangeInvoiceLine() : base()
        {
            base.Load += FRMChangeInvoiceLine_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboInvoiceTaxCodeNew;
            Combo.SetUpCombo(ref argc, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private Label _lblAmount;

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

        private Label _lblVatRate;

        private ComboBox _cboInvoiceTaxCodeNew;

        internal ComboBox cboInvoiceTaxCodeNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInvoiceTaxCodeNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInvoiceTaxCodeNew != null)
                {
                }

                _cboInvoiceTaxCodeNew = value;
                if (_cboInvoiceTaxCodeNew != null)
                {
                }
            }
        }

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
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
                    _btnCancel.Click -= btnCancel_Click_1;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click_1;
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._lblAmount = new System.Windows.Forms.Label();
            this._txtAmount = new System.Windows.Forms.TextBox();
            this._lblVatRate = new System.Windows.Forms.Label();
            this._cboInvoiceTaxCodeNew = new System.Windows.Forms.ComboBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblAmount
            // 
            this._lblAmount.AutoSize = true;
            this._lblAmount.Location = new System.Drawing.Point(12, 16);
            this._lblAmount.Name = "_lblAmount";
            this._lblAmount.Size = new System.Drawing.Size(51, 13);
            this._lblAmount.TabIndex = 1;
            this._lblAmount.Text = "Amount";
            // 
            // _txtAmount
            // 
            this._txtAmount.Location = new System.Drawing.Point(89, 13);
            this._txtAmount.Name = "_txtAmount";
            this._txtAmount.Size = new System.Drawing.Size(192, 21);
            this._txtAmount.TabIndex = 2;
            // 
            // _lblVatRate
            // 
            this._lblVatRate.AutoSize = true;
            this._lblVatRate.Location = new System.Drawing.Point(12, 58);
            this._lblVatRate.Name = "_lblVatRate";
            this._lblVatRate.Size = new System.Drawing.Size(55, 13);
            this._lblVatRate.TabIndex = 3;
            this._lblVatRate.Text = "Vat Rate";
            // 
            // _cboInvoiceTaxCodeNew
            // 
            this._cboInvoiceTaxCodeNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboInvoiceTaxCodeNew.Location = new System.Drawing.Point(89, 55);
            this._cboInvoiceTaxCodeNew.Name = "_cboInvoiceTaxCodeNew";
            this._cboInvoiceTaxCodeNew.Size = new System.Drawing.Size(83, 21);
            this._cboInvoiceTaxCodeNew.TabIndex = 108;
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(206, 95);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 109;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(15, 95);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 110;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // FRMChangeInvoiceLine
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(304, 130);
            this.ControlBox = false;
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._cboInvoiceTaxCodeNew);
            this.Controls.Add(this._lblVatRate);
            this.Controls.Add(this._txtAmount);
            this.Controls.Add(this._lblAmount);
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "FRMChangeInvoiceLine";
            this.Text = "Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void LoadMe(object sender, EventArgs e)
        {
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

        private void FRMChangeInvoiceLine_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
            txtAmount.Text = Entity.Sys.Helper.MakeDoubleValid(get_GetParameter(0)).ToString();
            var argcombo = cboInvoiceTaxCodeNew;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(1)).ToString());
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}