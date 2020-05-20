using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FrmInvoicedPayment : FRMBaseForm, IForm
    {
        public FrmInvoicedPayment() : base()
        {
            base.Load += FRMInvoiceManager_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboPaymentTerm;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll((Entity.Sys.Enums.PickListTypes)65).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboPaidBy;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll((Entity.Sys.Enums.PickListTypes)66).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private GroupBox _gpbPayment;

        private Button _btnPay;

        private GroupBox _gpbInvoiceInformation;

        private Label _lblCustomer;

        private Label _lblInvoiceAddress;

        private TextBox _txtCustomer;

        internal TextBox txtCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomer != null)
                {
                }

                _txtCustomer = value;
                if (_txtCustomer != null)
                {
                }
            }
        }

        private TextBox _txtInvoiceAddress;

        internal TextBox txtInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvoiceAddress != null)
                {
                }

                _txtInvoiceAddress = value;
                if (_txtInvoiceAddress != null)
                {
                }
            }
        }

        private TextBox _txtInvAmount;

        internal TextBox txtInvAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvAmount != null)
                {
                }

                _txtInvAmount = value;
                if (_txtInvAmount != null)
                {
                }
            }
        }

        private TextBox _txtInvNumber;

        internal TextBox txtInvNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvNumber != null)
                {
                }

                _txtInvNumber = value;
                if (_txtInvNumber != null)
                {
                }
            }
        }

        private Label _lblInvoiceTotal;

        private Label _lblInvoice;

        internal Label lblInvoice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoice != null)
                {
                }

                _lblInvoice = value;
                if (_lblInvoice != null)
                {
                }
            }
        }

        private TextBox _txtRaisedBy;

        internal TextBox txtRaisedBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRaisedBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRaisedBy != null)
                {
                }

                _txtRaisedBy = value;
                if (_txtRaisedBy != null)
                {
                }
            }
        }

        private TextBox _txtRaisedDate;

        internal TextBox txtRaisedDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRaisedDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRaisedDate != null)
                {
                }

                _txtRaisedDate = value;
                if (_txtRaisedDate != null)
                {
                }
            }
        }

        private Label _lblRaisedBy;

        private ComboBox _cboPaidBy;

        internal ComboBox cboPaidBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPaidBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPaidBy != null)
                {
                }

                _cboPaidBy = value;
                if (_cboPaidBy != null)
                {
                }
            }
        }

        private Label _lblPaidBy;

        private ComboBox _cboPaymentTerm;

        internal ComboBox cboPaymentTerm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPaymentTerm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPaymentTerm != null)
                {
                }

                _cboPaymentTerm = value;
                if (_cboPaymentTerm != null)
                {
                }
            }
        }

        private Label _lblPaymentTerm;

        private Label _lblAccountNumber;

        private TextBox _txtAccountNumber;

        internal TextBox txtAccountNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccountNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccountNumber != null)
                {
                }

                _txtAccountNumber = value;
                if (_txtAccountNumber != null)
                {
                }
            }
        }

        private Label _lblRaisedDate;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._gpbPayment = new System.Windows.Forms.GroupBox();
            this._lblAccountNumber = new System.Windows.Forms.Label();
            this._txtAccountNumber = new System.Windows.Forms.TextBox();
            this._cboPaidBy = new System.Windows.Forms.ComboBox();
            this._lblPaidBy = new System.Windows.Forms.Label();
            this._cboPaymentTerm = new System.Windows.Forms.ComboBox();
            this._lblPaymentTerm = new System.Windows.Forms.Label();
            this._btnPay = new System.Windows.Forms.Button();
            this._gpbInvoiceInformation = new System.Windows.Forms.GroupBox();
            this._txtRaisedBy = new System.Windows.Forms.TextBox();
            this._txtRaisedDate = new System.Windows.Forms.TextBox();
            this._lblRaisedBy = new System.Windows.Forms.Label();
            this._lblRaisedDate = new System.Windows.Forms.Label();
            this._txtInvAmount = new System.Windows.Forms.TextBox();
            this._txtInvNumber = new System.Windows.Forms.TextBox();
            this._lblInvoiceTotal = new System.Windows.Forms.Label();
            this._lblInvoice = new System.Windows.Forms.Label();
            this._txtInvoiceAddress = new System.Windows.Forms.TextBox();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._lblInvoiceAddress = new System.Windows.Forms.Label();
            this._lblCustomer = new System.Windows.Forms.Label();
            this._gpbPayment.SuspendLayout();
            this._gpbInvoiceInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gpbPayment
            // 
            this._gpbPayment.Controls.Add(this._lblAccountNumber);
            this._gpbPayment.Controls.Add(this._txtAccountNumber);
            this._gpbPayment.Controls.Add(this._cboPaidBy);
            this._gpbPayment.Controls.Add(this._lblPaidBy);
            this._gpbPayment.Controls.Add(this._cboPaymentTerm);
            this._gpbPayment.Controls.Add(this._lblPaymentTerm);
            this._gpbPayment.Controls.Add(this._btnPay);
            this._gpbPayment.Location = new System.Drawing.Point(8, 150);
            this._gpbPayment.Name = "_gpbPayment";
            this._gpbPayment.Size = new System.Drawing.Size(436, 173);
            this._gpbPayment.TabIndex = 1;
            this._gpbPayment.TabStop = false;
            this._gpbPayment.Text = "Payment";
            // 
            // _lblAccountNumber
            // 
            this._lblAccountNumber.Location = new System.Drawing.Point(8, 84);
            this._lblAccountNumber.Name = "_lblAccountNumber";
            this._lblAccountNumber.Size = new System.Drawing.Size(136, 23);
            this._lblAccountNumber.TabIndex = 16;
            this._lblAccountNumber.Text = "Account Number";
            // 
            // _txtAccountNumber
            // 
            this._txtAccountNumber.Location = new System.Drawing.Point(145, 81);
            this._txtAccountNumber.Name = "_txtAccountNumber";
            this._txtAccountNumber.Size = new System.Drawing.Size(279, 21);
            this._txtAccountNumber.TabIndex = 15;
            // 
            // _cboPaidBy
            // 
            this._cboPaidBy.FormattingEnabled = true;
            this._cboPaidBy.Location = new System.Drawing.Point(145, 54);
            this._cboPaidBy.Name = "_cboPaidBy";
            this._cboPaidBy.Size = new System.Drawing.Size(279, 21);
            this._cboPaidBy.TabIndex = 14;
            // 
            // _lblPaidBy
            // 
            this._lblPaidBy.AutoSize = true;
            this._lblPaidBy.Location = new System.Drawing.Point(9, 54);
            this._lblPaidBy.Name = "_lblPaidBy";
            this._lblPaidBy.Size = new System.Drawing.Size(50, 13);
            this._lblPaidBy.TabIndex = 13;
            this._lblPaidBy.Text = "Paid By";
            // 
            // _cboPaymentTerm
            // 
            this._cboPaymentTerm.FormattingEnabled = true;
            this._cboPaymentTerm.Location = new System.Drawing.Point(145, 24);
            this._cboPaymentTerm.Name = "_cboPaymentTerm";
            this._cboPaymentTerm.Size = new System.Drawing.Size(279, 21);
            this._cboPaymentTerm.TabIndex = 12;
            // 
            // _lblPaymentTerm
            // 
            this._lblPaymentTerm.AutoSize = true;
            this._lblPaymentTerm.Location = new System.Drawing.Point(8, 24);
            this._lblPaymentTerm.Name = "_lblPaymentTerm";
            this._lblPaymentTerm.Size = new System.Drawing.Size(90, 13);
            this._lblPaymentTerm.TabIndex = 11;
            this._lblPaymentTerm.Text = "Payment Term";
            // 
            // _btnPay
            // 
            this._btnPay.Location = new System.Drawing.Point(349, 114);
            this._btnPay.Name = "_btnPay";
            this._btnPay.Size = new System.Drawing.Size(75, 23);
            this._btnPay.TabIndex = 6;
            this._btnPay.Text = "Pay";
            this._btnPay.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // _gpbInvoiceInformation
            // 
            this._gpbInvoiceInformation.Controls.Add(this._txtRaisedBy);
            this._gpbInvoiceInformation.Controls.Add(this._txtRaisedDate);
            this._gpbInvoiceInformation.Controls.Add(this._lblRaisedBy);
            this._gpbInvoiceInformation.Controls.Add(this._lblRaisedDate);
            this._gpbInvoiceInformation.Controls.Add(this._txtInvAmount);
            this._gpbInvoiceInformation.Controls.Add(this._txtInvNumber);
            this._gpbInvoiceInformation.Controls.Add(this._lblInvoiceTotal);
            this._gpbInvoiceInformation.Controls.Add(this._lblInvoice);
            this._gpbInvoiceInformation.Controls.Add(this._txtInvoiceAddress);
            this._gpbInvoiceInformation.Controls.Add(this._txtCustomer);
            this._gpbInvoiceInformation.Controls.Add(this._lblInvoiceAddress);
            this._gpbInvoiceInformation.Controls.Add(this._lblCustomer);
            this._gpbInvoiceInformation.Location = new System.Drawing.Point(8, 12);
            this._gpbInvoiceInformation.Name = "_gpbInvoiceInformation";
            this._gpbInvoiceInformation.Size = new System.Drawing.Size(436, 132);
            this._gpbInvoiceInformation.TabIndex = 2;
            this._gpbInvoiceInformation.TabStop = false;
            this._gpbInvoiceInformation.Text = "Invoice Information";
            // 
            // _txtRaisedBy
            // 
            this._txtRaisedBy.Location = new System.Drawing.Point(312, 94);
            this._txtRaisedBy.Name = "_txtRaisedBy";
            this._txtRaisedBy.ReadOnly = true;
            this._txtRaisedBy.Size = new System.Drawing.Size(112, 21);
            this._txtRaisedBy.TabIndex = 11;
            // 
            // _txtRaisedDate
            // 
            this._txtRaisedDate.Location = new System.Drawing.Point(312, 70);
            this._txtRaisedDate.Name = "_txtRaisedDate";
            this._txtRaisedDate.ReadOnly = true;
            this._txtRaisedDate.Size = new System.Drawing.Size(112, 21);
            this._txtRaisedDate.TabIndex = 10;
            // 
            // _lblRaisedBy
            // 
            this._lblRaisedBy.Location = new System.Drawing.Point(232, 94);
            this._lblRaisedBy.Name = "_lblRaisedBy";
            this._lblRaisedBy.Size = new System.Drawing.Size(80, 23);
            this._lblRaisedBy.TabIndex = 9;
            this._lblRaisedBy.Text = "Raised By";
            // 
            // _lblRaisedDate
            // 
            this._lblRaisedDate.Location = new System.Drawing.Point(232, 70);
            this._lblRaisedDate.Name = "_lblRaisedDate";
            this._lblRaisedDate.Size = new System.Drawing.Size(80, 23);
            this._lblRaisedDate.TabIndex = 8;
            this._lblRaisedDate.Text = "Raised Date";
            // 
            // _txtInvAmount
            // 
            this._txtInvAmount.Location = new System.Drawing.Point(112, 94);
            this._txtInvAmount.Name = "_txtInvAmount";
            this._txtInvAmount.ReadOnly = true;
            this._txtInvAmount.Size = new System.Drawing.Size(112, 21);
            this._txtInvAmount.TabIndex = 7;
            // 
            // _txtInvNumber
            // 
            this._txtInvNumber.Location = new System.Drawing.Point(112, 70);
            this._txtInvNumber.Name = "_txtInvNumber";
            this._txtInvNumber.ReadOnly = true;
            this._txtInvNumber.Size = new System.Drawing.Size(112, 21);
            this._txtInvNumber.TabIndex = 6;
            // 
            // _lblInvoiceTotal
            // 
            this._lblInvoiceTotal.Location = new System.Drawing.Point(8, 94);
            this._lblInvoiceTotal.Name = "_lblInvoiceTotal";
            this._lblInvoiceTotal.Size = new System.Drawing.Size(96, 23);
            this._lblInvoiceTotal.TabIndex = 5;
            this._lblInvoiceTotal.Text = "Invoice Total";
            // 
            // _lblInvoice
            // 
            this._lblInvoice.Location = new System.Drawing.Point(8, 70);
            this._lblInvoice.Name = "_lblInvoice";
            this._lblInvoice.Size = new System.Drawing.Size(101, 23);
            this._lblInvoice.TabIndex = 4;
            this._lblInvoice.Text = "Invoice Number";
            // 
            // _txtInvoiceAddress
            // 
            this._txtInvoiceAddress.Location = new System.Drawing.Point(112, 40);
            this._txtInvoiceAddress.Name = "_txtInvoiceAddress";
            this._txtInvoiceAddress.ReadOnly = true;
            this._txtInvoiceAddress.Size = new System.Drawing.Size(312, 21);
            this._txtInvoiceAddress.TabIndex = 3;
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Location = new System.Drawing.Point(112, 16);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(312, 21);
            this._txtCustomer.TabIndex = 2;
            // 
            // _lblInvoiceAddress
            // 
            this._lblInvoiceAddress.Location = new System.Drawing.Point(8, 40);
            this._lblInvoiceAddress.Name = "_lblInvoiceAddress";
            this._lblInvoiceAddress.Size = new System.Drawing.Size(100, 23);
            this._lblInvoiceAddress.TabIndex = 1;
            this._lblInvoiceAddress.Text = "Invoice Address";
            // 
            // _lblCustomer
            // 
            this._lblCustomer.Location = new System.Drawing.Point(8, 16);
            this._lblCustomer.Name = "_lblCustomer";
            this._lblCustomer.Size = new System.Drawing.Size(100, 23);
            this._lblCustomer.TabIndex = 0;
            this._lblCustomer.Text = "Customer";
            // 
            // FrmInvoicedPayment
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(451, 334);
            this.Controls.Add(this._gpbInvoiceInformation);
            this.Controls.Add(this._gpbPayment);
            this.Name = "FrmInvoicedPayment";
            this.Text = "Invoice Payment";
            this._gpbPayment.ResumeLayout(false);
            this._gpbPayment.PerformLayout();
            this._gpbInvoiceInformation.ResumeLayout(false);
            this._gpbInvoiceInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            InvoicedID = Conversions.ToInteger(get_GetParameter(0));
            EngineerVisitID = Conversions.ToInteger(get_GetParameter(6));
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

        private bool _changingAmount = false;
        private int _InvoicedID = 0;

        private int InvoicedID
        {
            get
            {
                return _InvoicedID;
            }

            set
            {
                _InvoicedID = value;
                Populate();
            }
        }

        private double _InvoiceTotal = 0;

        private double InvoiceTotal
        {
            get
            {
                return _InvoiceTotal;
            }

            set
            {
                _InvoiceTotal = value;
            }
        }

        private int _EngineerVisitID = 0;

        private int EngineerVisitID
        {
            get
            {
                return _EngineerVisitID;
            }

            set
            {
                _EngineerVisitID = value;
            }
        }

        private void FRMInvoiceManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            MakePayment();
        }

        private void Populate()
        {
            txtCustomer.Text = Conversions.ToString(get_GetParameter(1));
            txtInvoiceAddress.Text = Conversions.ToString(get_GetParameter(2));
            txtInvNumber.Text = Conversions.ToString(get_GetParameter(3));
            txtRaisedDate.Text = Strings.Format(get_GetParameter(4), "dd/MM/yyyy");
            txtRaisedBy.Text = Conversions.ToString(get_GetParameter(5));
            foreach (DataRow dr in App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(InvoicedID).Table.Rows)
                InvoiceTotal += Entity.Sys.Helper.MakeDoubleValid(dr["Amount"]);
            double vatRate = Entity.Sys.Helper.MakeDoubleValid(get_GetParameter(7)) / 100;
            double vatAmount = InvoiceTotal * vatRate;
            double total = InvoiceTotal + Math.Round(vatAmount, 2, MidpointRounding.ToEven);
            txtInvAmount.Text = Strings.Format(total, "C");
        }

        private void MakePayment()
        {
            try
            {
                int PaidBy = 0;
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPaidBy)) > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPaymentTerm)) == 69491)
                {
                    PaidBy = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPaidBy));
                }

                App.DB.InvoicedLines.Invoiced_ChangeTerm(InvoicedID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPaymentTerm)), PaidBy);
                var EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(EngineerVisitID);
                EngVisitCharge.SetForSageAccountCode = txtAccountNumber.Text.Trim();
                App.DB.EngineerVisitCharge.EngineerVisitCharge_Update(EngVisitCharge);
                if (App.ShowMessage("Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                var oPrint = new Entity.Sys.Printing(InvoicedID, "Receipt", Entity.Sys.Enums.SystemDocumentType.PaymentReceipt);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error processing payment" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}