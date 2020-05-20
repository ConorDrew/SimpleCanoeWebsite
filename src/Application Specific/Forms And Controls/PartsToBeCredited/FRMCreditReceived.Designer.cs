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
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._txtSupplierCreditRef = new System.Windows.Forms.TextBox();
            this._Label7 = new System.Windows.Forms.Label();
            this._txtExtraRef = new System.Windows.Forms.TextBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._Label4 = new System.Windows.Forms.Label();
            this._dtpDateReceived = new System.Windows.Forms.DateTimePicker();
            this._txtDepartment = new System.Windows.Forms.TextBox();
            this._txtNominalCode = new System.Windows.Forms.TextBox();
            this._Label16 = new System.Windows.Forms.Label();
            this._txtVAT = new System.Windows.Forms.TextBox();
            this._cboTaxCode = new System.Windows.Forms.ComboBox();
            this._Label13 = new System.Windows.Forms.Label();
            this._txtnotes = new System.Windows.Forms.TextBox();
            this._txtTotalAmount = new System.Windows.Forms.TextBox();
            this._txtCreditReference = new System.Windows.Forms.TextBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._Label14 = new System.Windows.Forms.Label();
            this._Label17 = new System.Windows.Forms.Label();
            this._grpJobs = new System.Windows.Forms.GroupBox();
            this._dgCredits = new System.Windows.Forms.DataGrid();
            this._btnSave = new System.Windows.Forms.Button();
            this._txtOrignalAmount = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._GroupBox1.SuspendLayout();
            this._grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCredits)).BeginInit();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._txtSupplierCreditRef);
            this._GroupBox1.Controls.Add(this._Label7);
            this._GroupBox1.Controls.Add(this._txtExtraRef);
            this._GroupBox1.Controls.Add(this._Label5);
            this._GroupBox1.Controls.Add(this._Label4);
            this._GroupBox1.Controls.Add(this._dtpDateReceived);
            this._GroupBox1.Controls.Add(this._txtDepartment);
            this._GroupBox1.Controls.Add(this._txtNominalCode);
            this._GroupBox1.Controls.Add(this._Label16);
            this._GroupBox1.Controls.Add(this._txtVAT);
            this._GroupBox1.Controls.Add(this._cboTaxCode);
            this._GroupBox1.Controls.Add(this._Label13);
            this._GroupBox1.Controls.Add(this._txtnotes);
            this._GroupBox1.Controls.Add(this._txtTotalAmount);
            this._GroupBox1.Controls.Add(this._txtCreditReference);
            this._GroupBox1.Controls.Add(this._Label3);
            this._GroupBox1.Controls.Add(this._Label2);
            this._GroupBox1.Controls.Add(this._Label1);
            this._GroupBox1.Controls.Add(this._Label14);
            this._GroupBox1.Controls.Add(this._Label17);
            this._GroupBox1.Location = new System.Drawing.Point(12, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(868, 126);
            this._GroupBox1.TabIndex = 2;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Credit Received";
            // 
            // _txtSupplierCreditRef
            // 
            this._txtSupplierCreditRef.Location = new System.Drawing.Point(387, 14);
            this._txtSupplierCreditRef.MaxLength = 100;
            this._txtSupplierCreditRef.Name = "_txtSupplierCreditRef";
            this._txtSupplierCreditRef.Size = new System.Drawing.Size(138, 21);
            this._txtSupplierCreditRef.TabIndex = 3;
            this._txtSupplierCreditRef.Tag = " ";
            // 
            // _Label7
            // 
            this._Label7.AutoSize = true;
            this._Label7.Location = new System.Drawing.Point(265, 17);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(116, 13);
            this._Label7.TabIndex = 78;
            this._Label7.Text = "Supplier Credit Ref";
            // 
            // _txtExtraRef
            // 
            this._txtExtraRef.Location = new System.Drawing.Point(329, 95);
            this._txtExtraRef.MaxLength = 100;
            this._txtExtraRef.Name = "_txtExtraRef";
            this._txtExtraRef.Size = new System.Drawing.Size(195, 21);
            this._txtExtraRef.TabIndex = 8;
            this._txtExtraRef.Tag = " ";
            // 
            // _Label5
            // 
            this._Label5.Location = new System.Drawing.Point(265, 99);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(70, 20);
            this._Label5.TabIndex = 77;
            this._Label5.Text = "Extra Ref";
            // 
            // _Label4
            // 
            this._Label4.AutoSize = true;
            this._Label4.Location = new System.Drawing.Point(6, 70);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(90, 13);
            this._Label4.TabIndex = 75;
            this._Label4.Text = "Date Received";
            // 
            // _dtpDateReceived
            // 
            this._dtpDateReceived.Location = new System.Drawing.Point(116, 66);
            this._dtpDateReceived.Name = "_dtpDateReceived";
            this._dtpDateReceived.Size = new System.Drawing.Size(142, 21);
            this._dtpDateReceived.TabIndex = 2;
            // 
            // _txtDepartment
            // 
            this._txtDepartment.Location = new System.Drawing.Point(437, 43);
            this._txtDepartment.MaxLength = 100;
            this._txtDepartment.Name = "_txtDepartment";
            this._txtDepartment.Size = new System.Drawing.Size(88, 21);
            this._txtDepartment.TabIndex = 5;
            this._txtDepartment.Tag = "Order.SupplierInvoiceReference";
            // 
            // _txtNominalCode
            // 
            this._txtNominalCode.Location = new System.Drawing.Point(329, 43);
            this._txtNominalCode.MaxLength = 100;
            this._txtNominalCode.Name = "_txtNominalCode";
            this._txtNominalCode.Size = new System.Drawing.Size(58, 21);
            this._txtNominalCode.TabIndex = 4;
            this._txtNominalCode.Tag = "Order.SupplierInvoiceReference";
            // 
            // _Label16
            // 
            this._Label16.Location = new System.Drawing.Point(265, 43);
            this._Label16.Name = "_Label16";
            this._Label16.Size = new System.Drawing.Size(70, 20);
            this._Label16.TabIndex = 71;
            this._Label16.Text = "Nominal";
            // 
            // _txtVAT
            // 
            this._txtVAT.Location = new System.Drawing.Point(437, 69);
            this._txtVAT.MaxLength = 100;
            this._txtVAT.Name = "_txtVAT";
            this._txtVAT.ReadOnly = true;
            this._txtVAT.Size = new System.Drawing.Size(87, 21);
            this._txtVAT.TabIndex = 7;
            this._txtVAT.Tag = "Order.SupplierInvoiceAmount";
            // 
            // _cboTaxCode
            // 
            this._cboTaxCode.Location = new System.Drawing.Point(329, 69);
            this._cboTaxCode.Name = "_cboTaxCode";
            this._cboTaxCode.Size = new System.Drawing.Size(58, 21);
            this._cboTaxCode.TabIndex = 6;
            this._cboTaxCode.SelectedIndexChanged += new System.EventHandler(this.cboTaxCode_SelectedIndexChanged);
            // 
            // _Label13
            // 
            this._Label13.Location = new System.Drawing.Point(265, 72);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(70, 20);
            this._Label13.TabIndex = 70;
            this._Label13.Text = "Tax Code";
            // 
            // _txtnotes
            // 
            this._txtnotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtnotes.Location = new System.Drawing.Point(571, 14);
            this._txtnotes.Multiline = true;
            this._txtnotes.Name = "_txtnotes";
            this._txtnotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtnotes.Size = new System.Drawing.Size(290, 102);
            this._txtnotes.TabIndex = 9;
            // 
            // _txtTotalAmount
            // 
            this._txtTotalAmount.Location = new System.Drawing.Point(116, 40);
            this._txtTotalAmount.Name = "_txtTotalAmount";
            this._txtTotalAmount.ReadOnly = true;
            this._txtTotalAmount.Size = new System.Drawing.Size(142, 21);
            this._txtTotalAmount.TabIndex = 1;
            // 
            // _txtCreditReference
            // 
            this._txtCreditReference.Location = new System.Drawing.Point(116, 14);
            this._txtCreditReference.Name = "_txtCreditReference";
            this._txtCreditReference.ReadOnly = true;
            this._txtCreditReference.Size = new System.Drawing.Size(142, 21);
            this._txtCreditReference.TabIndex = 0;
            // 
            // _Label3
            // 
            this._Label3.AutoSize = true;
            this._Label3.Location = new System.Drawing.Point(526, 14);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(39, 13);
            this._Label3.TabIndex = 2;
            this._Label3.Text = "Notes";
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(6, 43);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(82, 13);
            this._Label2.TabIndex = 1;
            this._Label2.Text = "Total Amount";
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(6, 17);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(104, 13);
            this._Label1.TabIndex = 0;
            this._Label1.Text = "Credit Reference";
            // 
            // _Label14
            // 
            this._Label14.Location = new System.Drawing.Point(402, 72);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(38, 20);
            this._Label14.TabIndex = 72;
            this._Label14.Text = "VAT";
            // 
            // _Label17
            // 
            this._Label17.Location = new System.Drawing.Point(402, 46);
            this._Label17.Name = "_Label17";
            this._Label17.Size = new System.Drawing.Size(38, 20);
            this._Label17.TabIndex = 73;
            this._Label17.Text = "Dept";
            // 
            // _grpJobs
            // 
            this._grpJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobs.Controls.Add(this._dgCredits);
            this._grpJobs.Location = new System.Drawing.Point(12, 144);
            this._grpJobs.Name = "_grpJobs";
            this._grpJobs.Size = new System.Drawing.Size(868, 287);
            this._grpJobs.TabIndex = 3;
            this._grpJobs.TabStop = false;
            this._grpJobs.Text = "Parts";
            // 
            // _dgCredits
            // 
            this._dgCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgCredits.DataMember = "";
            this._dgCredits.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgCredits.Location = new System.Drawing.Point(8, 20);
            this._dgCredits.Name = "_dgCredits";
            this._dgCredits.Size = new System.Drawing.Size(852, 259);
            this._dgCredits.TabIndex = 0;
            this._dgCredits.CurrentCellChanged += new System.EventHandler(this.dgCredits_CurrentCellChanged);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Location = new System.Drawing.Point(805, 439);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _txtOrignalAmount
            // 
            this._txtOrignalAmount.Location = new System.Drawing.Point(117, 439);
            this._txtOrignalAmount.Name = "_txtOrignalAmount";
            this._txtOrignalAmount.ReadOnly = true;
            this._txtOrignalAmount.Size = new System.Drawing.Size(142, 21);
            this._txtOrignalAmount.TabIndex = 6;
            // 
            // _Label6
            // 
            this._Label6.AutoSize = true;
            this._Label6.Location = new System.Drawing.Point(12, 442);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(99, 13);
            this._Label6.TabIndex = 5;
            this._Label6.Text = "Original Amount";
            // 
            // FRMCreditReceived
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 470);
            this.Controls.Add(this._txtOrignalAmount);
            this.Controls.Add(this._Label6);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._grpJobs);
            this.Controls.Add(this._GroupBox1);
            this.Name = "FRMCreditReceived";
            this.Text = "Credit Received";
            this.Load += new System.EventHandler(this.FRMCreditReceived_Load);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this._grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgCredits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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