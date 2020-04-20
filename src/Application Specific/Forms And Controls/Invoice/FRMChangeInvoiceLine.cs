using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMChangeInvoiceLine : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMChangeInvoiceLine() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */


            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal Label lblAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAmount != null)
                {
                }

                _lblAmount = value;
                if (_lblAmount != null)
                {
                }
            }
        }

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

        internal Label lblVatRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVatRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVatRate != null)
                {
                }

                _lblVatRate = value;
                if (_lblVatRate != null)
                {
                }
            }
        }

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
            _lblAmount = new Label();
            _txtAmount = new TextBox();
            _lblVatRate = new Label();
            _cboInvoiceTaxCodeNew = new ComboBox();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click_1);
            SuspendLayout();
            // 
            // lblAmount
            // 
            _lblAmount.AutoSize = true;
            _lblAmount.Location = new Point(12, 66);
            _lblAmount.Name = "lblAmount";
            _lblAmount.Size = new Size(51, 13);
            _lblAmount.TabIndex = 1;
            _lblAmount.Text = "Amount";
            // 
            // txtAmount
            // 
            _txtAmount.Location = new Point(89, 63);
            _txtAmount.Name = "txtAmount";
            _txtAmount.Size = new Size(192, 21);
            _txtAmount.TabIndex = 2;
            // 
            // lblVatRate
            // 
            _lblVatRate.AutoSize = true;
            _lblVatRate.Location = new Point(12, 108);
            _lblVatRate.Name = "lblVatRate";
            _lblVatRate.Size = new Size(55, 13);
            _lblVatRate.TabIndex = 3;
            _lblVatRate.Text = "Vat Rate";
            // 
            // cboInvoiceTaxCodeNew
            // 
            _cboInvoiceTaxCodeNew.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInvoiceTaxCodeNew.Location = new Point(89, 105);
            _cboInvoiceTaxCodeNew.Name = "cboInvoiceTaxCodeNew";
            _cboInvoiceTaxCodeNew.Size = new Size(83, 21);
            _cboInvoiceTaxCodeNew.TabIndex = 108;
            // 
            // btnSave
            // 
            _btnSave.Location = new Point(206, 145);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(75, 23);
            _btnSave.TabIndex = 109;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Location = new Point(15, 145);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 110;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // FRMChangeInvoiceLine
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(304, 180);
            ControlBox = false;
            Controls.Add(_btnCancel);
            Controls.Add(_btnSave);
            Controls.Add(_cboInvoiceTaxCodeNew);
            Controls.Add(_lblVatRate);
            Controls.Add(_txtAmount);
            Controls.Add(_lblAmount);
            MaximumSize = new Size(1000, 1000);
            Name = "FRMChangeInvoiceLine";
            Text = "Update";
            Controls.SetChildIndex(_lblAmount, 0);
            Controls.SetChildIndex(_txtAmount, 0);
            Controls.SetChildIndex(_lblVatRate, 0);
            Controls.SetChildIndex(_cboInvoiceTaxCodeNew, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
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

        private void ResetMe(int newID)
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}