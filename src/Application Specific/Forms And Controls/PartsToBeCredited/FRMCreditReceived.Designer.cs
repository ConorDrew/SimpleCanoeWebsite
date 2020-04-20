using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMCreditReceived : FRMBaseForm, IForm
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _txtExtraRef = new TextBox();
            _Label5 = new Label();
            _Label4 = new Label();
            _dtpDateReceived = new DateTimePicker();
            _txtDepartment = new TextBox();
            _txtNominalCode = new TextBox();
            _Label16 = new Label();
            _txtVAT = new TextBox();
            _cboTaxCode = new ComboBox();
            _cboTaxCode.SelectedIndexChanged += new EventHandler(cboTaxCode_SelectedIndexChanged);
            _Label13 = new Label();
            _txtnotes = new TextBox();
            _txtTotalAmount = new TextBox();
            _txtCreditReference = new TextBox();
            _Label3 = new Label();
            _Label2 = new Label();
            _Label1 = new Label();
            _Label14 = new Label();
            _Label17 = new Label();
            _grpJobs = new GroupBox();
            _dgCredits = new DataGrid();
            _dgCredits.CurrentCellChanged += new EventHandler(dgCredits_CurrentCellChanged);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _txtOrignalAmount = new TextBox();
            _Label6 = new Label();
            _Label7 = new Label();
            _txtSupplierCreditRef = new TextBox();
            _GroupBox1.SuspendLayout();
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCredits).BeginInit();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_txtSupplierCreditRef);
            _GroupBox1.Controls.Add(_Label7);
            _GroupBox1.Controls.Add(_txtExtraRef);
            _GroupBox1.Controls.Add(_Label5);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_dtpDateReceived);
            _GroupBox1.Controls.Add(_txtDepartment);
            _GroupBox1.Controls.Add(_txtNominalCode);
            _GroupBox1.Controls.Add(_Label16);
            _GroupBox1.Controls.Add(_txtVAT);
            _GroupBox1.Controls.Add(_cboTaxCode);
            _GroupBox1.Controls.Add(_Label13);
            _GroupBox1.Controls.Add(_txtnotes);
            _GroupBox1.Controls.Add(_txtTotalAmount);
            _GroupBox1.Controls.Add(_txtCreditReference);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Controls.Add(_Label14);
            _GroupBox1.Controls.Add(_Label17);
            _GroupBox1.Location = new Point(12, 38);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(868, 126);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Credit Received";
            // 
            // txtExtraRef
            // 
            _txtExtraRef.Location = new Point(329, 95);
            _txtExtraRef.MaxLength = 100;
            _txtExtraRef.Name = "txtExtraRef";
            _txtExtraRef.Size = new Size(195, 21);
            _txtExtraRef.TabIndex = 8;
            _txtExtraRef.Tag = " ";
            // 
            // Label5
            // 
            _Label5.Location = new Point(265, 99);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(70, 20);
            _Label5.TabIndex = 77;
            _Label5.Text = "Extra Ref";
            // 
            // Label4
            // 
            _Label4.AutoSize = true;
            _Label4.Location = new Point(6, 70);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(90, 13);
            _Label4.TabIndex = 75;
            _Label4.Text = "Date Received";
            // 
            // dtpDateReceived
            // 
            _dtpDateReceived.Location = new Point(116, 66);
            _dtpDateReceived.Name = "dtpDateReceived";
            _dtpDateReceived.Size = new Size(142, 21);
            _dtpDateReceived.TabIndex = 2;
            // 
            // txtDepartment
            // 
            _txtDepartment.Location = new Point(437, 43);
            _txtDepartment.MaxLength = 100;
            _txtDepartment.Name = "txtDepartment";
            _txtDepartment.Size = new Size(88, 21);
            _txtDepartment.TabIndex = 5;
            _txtDepartment.Tag = "Order.SupplierInvoiceReference";
            // 
            // txtNominalCode
            // 
            _txtNominalCode.Location = new Point(329, 43);
            _txtNominalCode.MaxLength = 100;
            _txtNominalCode.Name = "txtNominalCode";
            _txtNominalCode.Size = new Size(58, 21);
            _txtNominalCode.TabIndex = 4;
            _txtNominalCode.Tag = "Order.SupplierInvoiceReference";
            // 
            // Label16
            // 
            _Label16.Location = new Point(265, 43);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(70, 20);
            _Label16.TabIndex = 71;
            _Label16.Text = "Nominal";
            // 
            // txtVAT
            // 
            _txtVAT.Location = new Point(437, 69);
            _txtVAT.MaxLength = 100;
            _txtVAT.Name = "txtVAT";
            _txtVAT.ReadOnly = true;
            _txtVAT.Size = new Size(87, 21);
            _txtVAT.TabIndex = 7;
            _txtVAT.Tag = "Order.SupplierInvoiceAmount";
            // 
            // cboTaxCode
            // 
            _cboTaxCode.Location = new Point(329, 69);
            _cboTaxCode.Name = "cboTaxCode";
            _cboTaxCode.Size = new Size(58, 21);
            _cboTaxCode.TabIndex = 6;
            // 
            // Label13
            // 
            _Label13.Location = new Point(265, 72);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(70, 20);
            _Label13.TabIndex = 70;
            _Label13.Text = "Tax Code";
            // 
            // txtnotes
            // 
            _txtnotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtnotes.Location = new Point(571, 14);
            _txtnotes.Multiline = true;
            _txtnotes.Name = "txtnotes";
            _txtnotes.ScrollBars = ScrollBars.Vertical;
            _txtnotes.Size = new Size(290, 102);
            _txtnotes.TabIndex = 9;
            // 
            // txtTotalAmount
            // 
            _txtTotalAmount.Location = new Point(116, 40);
            _txtTotalAmount.Name = "txtTotalAmount";
            _txtTotalAmount.ReadOnly = true;
            _txtTotalAmount.Size = new Size(142, 21);
            _txtTotalAmount.TabIndex = 1;
            // 
            // txtCreditReference
            // 
            _txtCreditReference.Location = new Point(116, 14);
            _txtCreditReference.Name = "txtCreditReference";
            _txtCreditReference.ReadOnly = true;
            _txtCreditReference.Size = new Size(142, 21);
            _txtCreditReference.TabIndex = 0;
            // 
            // Label3
            // 
            _Label3.AutoSize = true;
            _Label3.Location = new Point(526, 14);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(39, 13);
            _Label3.TabIndex = 2;
            _Label3.Text = "Notes";
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(6, 43);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(83, 13);
            _Label2.TabIndex = 1;
            _Label2.Text = "Total Amount";
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Location = new Point(6, 17);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(104, 13);
            _Label1.TabIndex = 0;
            _Label1.Text = "Credit Reference";
            // 
            // Label14
            // 
            _Label14.Location = new Point(402, 72);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(38, 20);
            _Label14.TabIndex = 72;
            _Label14.Text = "VAT";
            // 
            // Label17
            // 
            _Label17.Location = new Point(402, 46);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(38, 20);
            _Label17.TabIndex = 73;
            _Label17.Text = "Dept";
            // 
            // grpJobs
            // 
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_dgCredits);
            _grpJobs.Location = new Point(12, 170);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(868, 261);
            _grpJobs.TabIndex = 3;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Parts";
            // 
            // dgCredits
            // 
            _dgCredits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgCredits.DataMember = "";
            _dgCredits.HeaderForeColor = SystemColors.ControlText;
            _dgCredits.Location = new Point(8, 20);
            _dgCredits.Name = "dgCredits";
            _dgCredits.Size = new Size(852, 233);
            _dgCredits.TabIndex = 0;
            // 
            // btnSave
            // 
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(805, 439);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(75, 23);
            _btnSave.TabIndex = 4;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            // 
            // txtOrignalAmount
            // 
            _txtOrignalAmount.Location = new Point(117, 439);
            _txtOrignalAmount.Name = "txtOrignalAmount";
            _txtOrignalAmount.ReadOnly = true;
            _txtOrignalAmount.Size = new Size(142, 21);
            _txtOrignalAmount.TabIndex = 6;
            // 
            // Label6
            // 
            _Label6.AutoSize = true;
            _Label6.Location = new Point(12, 442);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(99, 13);
            _Label6.TabIndex = 5;
            _Label6.Text = "Original Amount";
            // 
            // Label7
            // 
            _Label7.AutoSize = true;
            _Label7.Location = new Point(265, 17);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(116, 13);
            _Label7.TabIndex = 78;
            _Label7.Text = "Supplier Credit Ref";
            // 
            // txtSupplierCreditRef
            // 
            _txtSupplierCreditRef.Location = new Point(387, 14);
            _txtSupplierCreditRef.MaxLength = 100;
            _txtSupplierCreditRef.Name = "txtSupplierCreditRef";
            _txtSupplierCreditRef.Size = new Size(138, 21);
            _txtSupplierCreditRef.TabIndex = 3;
            _txtSupplierCreditRef.Tag = " ";
            // 
            // FRMCreditReceived
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 470);
            Controls.Add(_txtOrignalAmount);
            Controls.Add(_Label6);
            Controls.Add(_btnSave);
            Controls.Add(_grpJobs);
            Controls.Add(_GroupBox1);
            Name = "FRMCreditReceived";
            Text = "Credit Received";
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_grpJobs, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_Label6, 0);
            Controls.SetChildIndex(_txtOrignalAmount, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgCredits).EndInit();
            Load += new EventHandler(FRMCreditReceived_Load);
            ResumeLayout(false);
            PerformLayout();
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

        private TextBox _txtnotes;

        internal TextBox txtnotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtnotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtnotes != null)
                {
                }

                _txtnotes = value;
                if (_txtnotes != null)
                {
                }
            }
        }

        private TextBox _txtTotalAmount;

        internal TextBox txtTotalAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTotalAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTotalAmount != null)
                {
                }

                _txtTotalAmount = value;
                if (_txtTotalAmount != null)
                {
                }
            }
        }

        private TextBox _txtCreditReference;

        internal TextBox txtCreditReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCreditReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCreditReference != null)
                {
                }

                _txtCreditReference = value;
                if (_txtCreditReference != null)
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

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
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

        private GroupBox _grpJobs;

        internal GroupBox grpJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobs != null)
                {
                }

                _grpJobs = value;
                if (_grpJobs != null)
                {
                }
            }
        }

        private DataGrid _dgCredits;

        internal DataGrid dgCredits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgCredits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgCredits != null)
                {
                    _dgCredits.CurrentCellChanged -= dgCredits_CurrentCellChanged;
                }

                _dgCredits = value;
                if (_dgCredits != null)
                {
                    _dgCredits.CurrentCellChanged += dgCredits_CurrentCellChanged;
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

        private TextBox _txtDepartment;

        internal TextBox txtDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDepartment != null)
                {
                }

                _txtDepartment = value;
                if (_txtDepartment != null)
                {
                }
            }
        }

        private TextBox _txtNominalCode;

        internal TextBox txtNominalCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNominalCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNominalCode != null)
                {
                }

                _txtNominalCode = value;
                if (_txtNominalCode != null)
                {
                }
            }
        }

        private Label _Label16;

        internal Label Label16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label16 != null)
                {
                }

                _Label16 = value;
                if (_Label16 != null)
                {
                }
            }
        }

        private TextBox _txtVAT;

        internal TextBox txtVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVAT != null)
                {
                }

                _txtVAT = value;
                if (_txtVAT != null)
                {
                }
            }
        }

        private ComboBox _cboTaxCode;

        internal ComboBox cboTaxCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTaxCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTaxCode != null)
                {
                    _cboTaxCode.SelectedIndexChanged -= cboTaxCode_SelectedIndexChanged;
                }

                _cboTaxCode = value;
                if (_cboTaxCode != null)
                {
                    _cboTaxCode.SelectedIndexChanged += cboTaxCode_SelectedIndexChanged;
                }
            }
        }

        private Label _Label13;

        internal Label Label13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label13 != null)
                {
                }

                _Label13 = value;
                if (_Label13 != null)
                {
                }
            }
        }

        private Label _Label14;

        internal Label Label14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label14 != null)
                {
                }

                _Label14 = value;
                if (_Label14 != null)
                {
                }
            }
        }

        private Label _Label17;

        internal Label Label17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label17 != null)
                {
                }

                _Label17 = value;
                if (_Label17 != null)
                {
                }
            }
        }

        private TextBox _txtExtraRef;

        internal TextBox txtExtraRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtExtraRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtExtraRef != null)
                {
                }

                _txtExtraRef = value;
                if (_txtExtraRef != null)
                {
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private DateTimePicker _dtpDateReceived;

        internal DateTimePicker dtpDateReceived
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDateReceived;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDateReceived != null)
                {
                }

                _dtpDateReceived = value;
                if (_dtpDateReceived != null)
                {
                }
            }
        }

        private TextBox _txtOrignalAmount;

        internal TextBox txtOrignalAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOrignalAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOrignalAmount != null)
                {
                }

                _txtOrignalAmount = value;
                if (_txtOrignalAmount != null)
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

        private TextBox _txtSupplierCreditRef;

        internal TextBox txtSupplierCreditRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplierCreditRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplierCreditRef != null)
                {
                }

                _txtSupplierCreditRef = value;
                if (_txtSupplierCreditRef != null)
                {
                }
            }
        }

        private Label _Label7;

        internal Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label7 != null)
                {
                }

                _Label7 = value;
                if (_Label7 != null)
                {
                }
            }
        }
    }
}