using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMChangeInvoicedTotal : FRMBaseForm, IForm
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
            this._dtpTaxDate = new System.Windows.Forms.DateTimePicker();
            this._txtDept = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._txtNominal = new System.Windows.Forms.TextBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._txtAccount = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtInvoicedTotal = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._txtPassword = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._dtpTaxDate);
            this._GroupBox1.Controls.Add(this._txtDept);
            this._GroupBox1.Controls.Add(this._Label6);
            this._GroupBox1.Controls.Add(this._txtNominal);
            this._GroupBox1.Controls.Add(this._Label5);
            this._GroupBox1.Controls.Add(this._txtAccount);
            this._GroupBox1.Controls.Add(this._Label4);
            this._GroupBox1.Controls.Add(this._Label3);
            this._GroupBox1.Controls.Add(this._txtInvoicedTotal);
            this._GroupBox1.Controls.Add(this._Label2);
            this._GroupBox1.Controls.Add(this._btnSave);
            this._GroupBox1.Controls.Add(this._txtPassword);
            this._GroupBox1.Controls.Add(this._Label1);
            this._GroupBox1.Location = new System.Drawing.Point(12, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(502, 289);
            this._GroupBox1.TabIndex = 0;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Change Invoiced Total";
            // 
            // _dtpTaxDate
            // 
            this._dtpTaxDate.Location = new System.Drawing.Point(194, 68);
            this._dtpTaxDate.Name = "_dtpTaxDate";
            this._dtpTaxDate.Size = new System.Drawing.Size(291, 21);
            this._dtpTaxDate.TabIndex = 13;
            // 
            // _txtDept
            // 
            this._txtDept.Location = new System.Drawing.Point(194, 149);
            this._txtDept.Name = "_txtDept";
            this._txtDept.Size = new System.Drawing.Size(291, 21);
            this._txtDept.TabIndex = 12;
            // 
            // _Label6
            // 
            this._Label6.AutoSize = true;
            this._Label6.Location = new System.Drawing.Point(6, 152);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(75, 13);
            this._Label6.TabIndex = 11;
            this._Label6.Text = "Department";
            // 
            // _txtNominal
            // 
            this._txtNominal.Location = new System.Drawing.Point(194, 122);
            this._txtNominal.Name = "_txtNominal";
            this._txtNominal.Size = new System.Drawing.Size(291, 21);
            this._txtNominal.TabIndex = 10;
            // 
            // _Label5
            // 
            this._Label5.AutoSize = true;
            this._Label5.Location = new System.Drawing.Point(6, 130);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(53, 13);
            this._Label5.TabIndex = 9;
            this._Label5.Text = "Nominal";
            // 
            // _txtAccount
            // 
            this._txtAccount.Location = new System.Drawing.Point(194, 95);
            this._txtAccount.Name = "_txtAccount";
            this._txtAccount.Size = new System.Drawing.Size(291, 21);
            this._txtAccount.TabIndex = 8;
            // 
            // _Label4
            // 
            this._Label4.AutoSize = true;
            this._Label4.Location = new System.Drawing.Point(6, 103);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(52, 13);
            this._Label4.TabIndex = 7;
            this._Label4.Text = "Account";
            // 
            // _Label3
            // 
            this._Label3.AutoSize = true;
            this._Label3.Location = new System.Drawing.Point(6, 76);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(58, 13);
            this._Label3.TabIndex = 5;
            this._Label3.Text = "Tax Date";
            // 
            // _txtInvoicedTotal
            // 
            this._txtInvoicedTotal.Location = new System.Drawing.Point(194, 195);
            this._txtInvoicedTotal.Name = "_txtInvoicedTotal";
            this._txtInvoicedTotal.Size = new System.Drawing.Size(291, 21);
            this._txtInvoicedTotal.TabIndex = 3;
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(6, 203);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(87, 13);
            this._Label2.TabIndex = 2;
            this._Label2.Text = "Invoiced Total";
            // 
            // _btnSave
            // 
            this._btnSave.Enabled = false;
            this._btnSave.Location = new System.Drawing.Point(410, 234);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _txtPassword
            // 
            this._txtPassword.Location = new System.Drawing.Point(194, 27);
            this._txtPassword.Name = "_txtPassword";
            this._txtPassword.PasswordChar = '*';
            this._txtPassword.Size = new System.Drawing.Size(291, 21);
            this._txtPassword.TabIndex = 1;
            this._txtPassword.UseSystemPasswordChar = true;
            this._txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(6, 30);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(169, 13);
            this._Label1.TabIndex = 0;
            this._Label1.Text = "Enter the override password";
            // 
            // FRMChangeInvoicedTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 313);
            this.Controls.Add(this._GroupBox1);
            this.Name = "FRMChangeInvoicedTotal";
            this.Text = "Change Invoiced Total";
            this.Load += new System.EventHandler(this.FRMChangeInvoicedTotal_Load);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        void IForm.LoadMe(object sender, EventArgs e)
        {
            
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

        private TextBox _txtPassword;

        internal TextBox txtPassword
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPassword;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPassword != null)
                {
                    _txtPassword.TextChanged -= txtPassword_TextChanged;
                }

                _txtPassword = value;
                if (_txtPassword != null)
                {
                    _txtPassword.TextChanged += txtPassword_TextChanged;
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

        private TextBox _txtInvoicedTotal;

        internal TextBox txtInvoicedTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvoicedTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvoicedTotal != null)
                {
                }

                _txtInvoicedTotal = value;
                if (_txtInvoicedTotal != null)
                {
                }
            }
        }

        private TextBox _txtDept;

        internal TextBox txtDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDept != null)
                {
                }

                _txtDept = value;
                if (_txtDept != null)
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

        private TextBox _txtNominal;

        internal TextBox txtNominal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNominal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNominal != null)
                {
                }

                _txtNominal = value;
                if (_txtNominal != null)
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

        private TextBox _txtAccount;

        internal TextBox txtAccount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccount != null)
                {
                }

                _txtAccount = value;
                if (_txtAccount != null)
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

        private DateTimePicker _dtpTaxDate;

        internal DateTimePicker dtpTaxDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTaxDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTaxDate != null)
                {
                }

                _dtpTaxDate = value;
                if (_dtpTaxDate != null)
                {
                }
            }
        }
    }
}