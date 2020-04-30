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

        internal GroupBox gpbPayment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbPayment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbPayment != null)
                {
                }

                _gpbPayment = value;
                if (_gpbPayment != null)
                {
                }
            }
        }

        private Button _btnPay;

        internal Button btnPay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPay != null)
                {
                    _btnPay.Click -= btnAddPayment_Click;
                }

                _btnPay = value;
                if (_btnPay != null)
                {
                    _btnPay.Click += btnAddPayment_Click;
                }
            }
        }

        private GroupBox _gpbInvoiceInformation;

        internal GroupBox gpbInvoiceInformation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbInvoiceInformation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbInvoiceInformation != null)
                {
                }

                _gpbInvoiceInformation = value;
                if (_gpbInvoiceInformation != null)
                {
                }
            }
        }

        private Label _lblCustomer;

        internal Label lblCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomer != null)
                {
                }

                _lblCustomer = value;
                if (_lblCustomer != null)
                {
                }
            }
        }

        private Label _lblInvoiceAddress;

        internal Label lblInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoiceAddress != null)
                {
                }

                _lblInvoiceAddress = value;
                if (_lblInvoiceAddress != null)
                {
                }
            }
        }

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

        internal Label lblInvoiceTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoiceTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoiceTotal != null)
                {
                }

                _lblInvoiceTotal = value;
                if (_lblInvoiceTotal != null)
                {
                }
            }
        }

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

        internal Label lblRaisedBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRaisedBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRaisedBy != null)
                {
                }

                _lblRaisedBy = value;
                if (_lblRaisedBy != null)
                {
                }
            }
        }

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

        internal Label lblPaidBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPaidBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPaidBy != null)
                {
                }

                _lblPaidBy = value;
                if (_lblPaidBy != null)
                {
                }
            }
        }

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

        internal Label lblPaymentTerm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPaymentTerm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPaymentTerm != null)
                {
                }

                _lblPaymentTerm = value;
                if (_lblPaymentTerm != null)
                {
                }
            }
        }

        private Label _lblAccountNumber;

        internal Label lblAccountNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAccountNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAccountNumber != null)
                {
                }

                _lblAccountNumber = value;
                if (_lblAccountNumber != null)
                {
                }
            }
        }

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

        internal Label lblRaisedDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRaisedDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRaisedDate != null)
                {
                }

                _lblRaisedDate = value;
                if (_lblRaisedDate != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _gpbPayment = new GroupBox();
            _lblAccountNumber = new Label();
            _txtAccountNumber = new TextBox();
            _cboPaidBy = new ComboBox();
            _lblPaidBy = new Label();
            _cboPaymentTerm = new ComboBox();
            _lblPaymentTerm = new Label();
            _btnPay = new Button();
            _btnPay.Click += new EventHandler(btnAddPayment_Click);
            _gpbInvoiceInformation = new GroupBox();
            _txtRaisedBy = new TextBox();
            _txtRaisedDate = new TextBox();
            _lblRaisedBy = new Label();
            _lblRaisedDate = new Label();
            _txtInvAmount = new TextBox();
            _txtInvNumber = new TextBox();
            _lblInvoiceTotal = new Label();
            _lblInvoice = new Label();
            _txtInvoiceAddress = new TextBox();
            _txtCustomer = new TextBox();
            _lblInvoiceAddress = new Label();
            _lblCustomer = new Label();
            _gpbPayment.SuspendLayout();
            _gpbInvoiceInformation.SuspendLayout();
            SuspendLayout();
            //
            // gpbPayment
            //
            _gpbPayment.Controls.Add(_lblAccountNumber);
            _gpbPayment.Controls.Add(_txtAccountNumber);
            _gpbPayment.Controls.Add(_cboPaidBy);
            _gpbPayment.Controls.Add(_lblPaidBy);
            _gpbPayment.Controls.Add(_cboPaymentTerm);
            _gpbPayment.Controls.Add(_lblPaymentTerm);
            _gpbPayment.Controls.Add(_btnPay);
            _gpbPayment.Location = new Point(8, 170);
            _gpbPayment.Name = "gpbPayment";
            _gpbPayment.Size = new Size(436, 153);
            _gpbPayment.TabIndex = 1;
            _gpbPayment.TabStop = false;
            _gpbPayment.Text = "Payment";
            //
            // lblAccountNumber
            //
            _lblAccountNumber.Location = new Point(8, 84);
            _lblAccountNumber.Name = "lblAccountNumber";
            _lblAccountNumber.Size = new Size(136, 23);
            _lblAccountNumber.TabIndex = 16;
            _lblAccountNumber.Text = "Account Number";
            //
            // txtAccountNumber
            //
            _txtAccountNumber.Location = new Point(145, 81);
            _txtAccountNumber.Name = "txtAccountNumber";
            _txtAccountNumber.Size = new Size(279, 21);
            _txtAccountNumber.TabIndex = 15;
            //
            // cboPaidBy
            //
            _cboPaidBy.FormattingEnabled = true;
            _cboPaidBy.Location = new Point(145, 54);
            _cboPaidBy.Name = "cboPaidBy";
            _cboPaidBy.Size = new Size(279, 21);
            _cboPaidBy.TabIndex = 14;
            //
            // lblPaidBy
            //
            _lblPaidBy.AutoSize = true;
            _lblPaidBy.Location = new Point(9, 54);
            _lblPaidBy.Name = "lblPaidBy";
            _lblPaidBy.Size = new Size(50, 13);
            _lblPaidBy.TabIndex = 13;
            _lblPaidBy.Text = "Paid By";
            //
            // cboPaymentTerm
            //
            _cboPaymentTerm.FormattingEnabled = true;
            _cboPaymentTerm.Location = new Point(145, 24);
            _cboPaymentTerm.Name = "cboPaymentTerm";
            _cboPaymentTerm.Size = new Size(279, 21);
            _cboPaymentTerm.TabIndex = 12;
            //
            // lblPaymentTerm
            //
            _lblPaymentTerm.AutoSize = true;
            _lblPaymentTerm.Location = new Point(8, 24);
            _lblPaymentTerm.Name = "lblPaymentTerm";
            _lblPaymentTerm.Size = new Size(90, 13);
            _lblPaymentTerm.TabIndex = 11;
            _lblPaymentTerm.Text = "Payment Term";
            //
            // btnPay
            //
            _btnPay.Location = new Point(349, 114);
            _btnPay.Name = "btnPay";
            _btnPay.Size = new Size(75, 23);
            _btnPay.TabIndex = 6;
            _btnPay.Text = "Pay";
            //
            // gpbInvoiceInformation
            //
            _gpbInvoiceInformation.Controls.Add(_txtRaisedBy);
            _gpbInvoiceInformation.Controls.Add(_txtRaisedDate);
            _gpbInvoiceInformation.Controls.Add(_lblRaisedBy);
            _gpbInvoiceInformation.Controls.Add(_lblRaisedDate);
            _gpbInvoiceInformation.Controls.Add(_txtInvAmount);
            _gpbInvoiceInformation.Controls.Add(_txtInvNumber);
            _gpbInvoiceInformation.Controls.Add(_lblInvoiceTotal);
            _gpbInvoiceInformation.Controls.Add(_lblInvoice);
            _gpbInvoiceInformation.Controls.Add(_txtInvoiceAddress);
            _gpbInvoiceInformation.Controls.Add(_txtCustomer);
            _gpbInvoiceInformation.Controls.Add(_lblInvoiceAddress);
            _gpbInvoiceInformation.Controls.Add(_lblCustomer);
            _gpbInvoiceInformation.Location = new Point(8, 32);
            _gpbInvoiceInformation.Name = "gpbInvoiceInformation";
            _gpbInvoiceInformation.Size = new Size(436, 132);
            _gpbInvoiceInformation.TabIndex = 2;
            _gpbInvoiceInformation.TabStop = false;
            _gpbInvoiceInformation.Text = "Invoice Information";
            //
            // txtRaisedBy
            //
            _txtRaisedBy.Location = new Point(312, 94);
            _txtRaisedBy.Name = "txtRaisedBy";
            _txtRaisedBy.ReadOnly = true;
            _txtRaisedBy.Size = new Size(112, 21);
            _txtRaisedBy.TabIndex = 11;
            //
            // txtRaisedDate
            //
            _txtRaisedDate.Location = new Point(312, 70);
            _txtRaisedDate.Name = "txtRaisedDate";
            _txtRaisedDate.ReadOnly = true;
            _txtRaisedDate.Size = new Size(112, 21);
            _txtRaisedDate.TabIndex = 10;
            //
            // lblRaisedBy
            //
            _lblRaisedBy.Location = new Point(232, 94);
            _lblRaisedBy.Name = "lblRaisedBy";
            _lblRaisedBy.Size = new Size(80, 23);
            _lblRaisedBy.TabIndex = 9;
            _lblRaisedBy.Text = "Raised By";
            //
            // lblRaisedDate
            //
            _lblRaisedDate.Location = new Point(232, 70);
            _lblRaisedDate.Name = "lblRaisedDate";
            _lblRaisedDate.Size = new Size(80, 23);
            _lblRaisedDate.TabIndex = 8;
            _lblRaisedDate.Text = "Raised Date";
            //
            // txtInvAmount
            //
            _txtInvAmount.Location = new Point(112, 94);
            _txtInvAmount.Name = "txtInvAmount";
            _txtInvAmount.ReadOnly = true;
            _txtInvAmount.Size = new Size(112, 21);
            _txtInvAmount.TabIndex = 7;
            //
            // txtInvNumber
            //
            _txtInvNumber.Location = new Point(112, 70);
            _txtInvNumber.Name = "txtInvNumber";
            _txtInvNumber.ReadOnly = true;
            _txtInvNumber.Size = new Size(112, 21);
            _txtInvNumber.TabIndex = 6;
            //
            // lblInvoiceTotal
            //
            _lblInvoiceTotal.Location = new Point(8, 94);
            _lblInvoiceTotal.Name = "lblInvoiceTotal";
            _lblInvoiceTotal.Size = new Size(96, 23);
            _lblInvoiceTotal.TabIndex = 5;
            _lblInvoiceTotal.Text = "Invoice Total";
            //
            // lblInvoice
            //
            _lblInvoice.Location = new Point(8, 70);
            _lblInvoice.Name = "lblInvoice";
            _lblInvoice.Size = new Size(101, 23);
            _lblInvoice.TabIndex = 4;
            _lblInvoice.Text = "Invoice Number";
            //
            // txtInvoiceAddress
            //
            _txtInvoiceAddress.Location = new Point(112, 40);
            _txtInvoiceAddress.Name = "txtInvoiceAddress";
            _txtInvoiceAddress.ReadOnly = true;
            _txtInvoiceAddress.Size = new Size(312, 21);
            _txtInvoiceAddress.TabIndex = 3;
            //
            // txtCustomer
            //
            _txtCustomer.Location = new Point(112, 16);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(312, 21);
            _txtCustomer.TabIndex = 2;
            //
            // lblInvoiceAddress
            //
            _lblInvoiceAddress.Location = new Point(8, 40);
            _lblInvoiceAddress.Name = "lblInvoiceAddress";
            _lblInvoiceAddress.Size = new Size(100, 23);
            _lblInvoiceAddress.TabIndex = 1;
            _lblInvoiceAddress.Text = "Invoice Address";
            //
            // lblCustomer
            //
            _lblCustomer.Location = new Point(8, 16);
            _lblCustomer.Name = "lblCustomer";
            _lblCustomer.Size = new Size(100, 23);
            _lblCustomer.TabIndex = 0;
            _lblCustomer.Text = "Customer";
            //
            // FrmInvoicedPayment
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(451, 334);
            Controls.Add(_gpbInvoiceInformation);
            Controls.Add(_gpbPayment);
            Name = "FrmInvoicedPayment";
            Text = "Invoice Payment";
            Controls.SetChildIndex(_gpbPayment, 0);
            Controls.SetChildIndex(_gpbInvoiceInformation, 0);
            _gpbPayment.ResumeLayout(false);
            _gpbPayment.PerformLayout();
            _gpbInvoiceInformation.ResumeLayout(false);
            _gpbInvoiceInformation.PerformLayout();
            ResumeLayout(false);
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