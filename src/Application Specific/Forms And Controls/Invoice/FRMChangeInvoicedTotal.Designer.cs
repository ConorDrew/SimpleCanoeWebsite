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
            _GroupBox1 = new GroupBox();
            _txtInvoicedTotal = new TextBox();
            _Label2 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _txtPassword = new TextBox();
            _txtPassword.TextChanged += new EventHandler(txtPassword_TextChanged);
            _Label1 = new Label();
            _Label3 = new Label();
            _txtAccount = new TextBox();
            _Label4 = new Label();
            _txtNominal = new TextBox();
            _Label5 = new Label();
            _txtDept = new TextBox();
            _Label6 = new Label();
            _dtpTaxDate = new DateTimePicker();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_dtpTaxDate);
            _GroupBox1.Controls.Add(_txtDept);
            _GroupBox1.Controls.Add(_Label6);
            _GroupBox1.Controls.Add(_txtNominal);
            _GroupBox1.Controls.Add(_Label5);
            _GroupBox1.Controls.Add(_txtAccount);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_txtInvoicedTotal);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_btnSave);
            _GroupBox1.Controls.Add(_txtPassword);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Location = new Point(12, 38);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(502, 263);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Change Invoiced Total";
            // 
            // txtInvoicedTotal
            // 
            _txtInvoicedTotal.Location = new Point(194, 195);
            _txtInvoicedTotal.Name = "txtInvoicedTotal";
            _txtInvoicedTotal.Size = new Size(291, 21);
            _txtInvoicedTotal.TabIndex = 3;
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(6, 203);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(87, 13);
            _Label2.TabIndex = 2;
            _Label2.Text = "Invoiced Total";
            // 
            // btnSave
            // 
            _btnSave.Enabled = false;
            _btnSave.Location = new Point(410, 234);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(75, 23);
            _btnSave.TabIndex = 4;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            _txtPassword.Location = new Point(194, 27);
            _txtPassword.Name = "txtPassword";
            _txtPassword.PasswordChar = (char)42;
            _txtPassword.Size = new Size(291, 21);
            _txtPassword.TabIndex = 1;
            _txtPassword.UseSystemPasswordChar = true;
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Location = new Point(6, 30);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(169, 13);
            _Label1.TabIndex = 0;
            _Label1.Text = "Enter the override password";
            // 
            // Label3
            // 
            _Label3.AutoSize = true;
            _Label3.Location = new Point(6, 76);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(58, 13);
            _Label3.TabIndex = 5;
            _Label3.Text = "Tax Date";
            // 
            // txtAccount
            // 
            _txtAccount.Location = new Point(194, 95);
            _txtAccount.Name = "txtAccount";
            _txtAccount.Size = new Size(291, 21);
            _txtAccount.TabIndex = 8;
            // 
            // Label4
            // 
            _Label4.AutoSize = true;
            _Label4.Location = new Point(6, 103);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(52, 13);
            _Label4.TabIndex = 7;
            _Label4.Text = "Account";
            // 
            // txtNominal
            // 
            _txtNominal.Location = new Point(194, 122);
            _txtNominal.Name = "txtNominal";
            _txtNominal.Size = new Size(291, 21);
            _txtNominal.TabIndex = 10;
            // 
            // Label5
            // 
            _Label5.AutoSize = true;
            _Label5.Location = new Point(6, 130);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(53, 13);
            _Label5.TabIndex = 9;
            _Label5.Text = "Nominal";
            // 
            // txtDept
            // 
            _txtDept.Location = new Point(194, 149);
            _txtDept.Name = "txtDept";
            _txtDept.Size = new Size(291, 21);
            _txtDept.TabIndex = 12;
            // 
            // Label6
            // 
            _Label6.AutoSize = true;
            _Label6.Location = new Point(6, 152);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(75, 13);
            _Label6.TabIndex = 11;
            _Label6.Text = "Department";
            // 
            // dtpTaxDate
            // 
            _dtpTaxDate.Location = new Point(194, 68);
            _dtpTaxDate.Name = "dtpTaxDate";
            _dtpTaxDate.Size = new Size(291, 21);
            _dtpTaxDate.TabIndex = 13;
            // 
            // FRMChangeInvoicedTotal
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 313);
            Controls.Add(_GroupBox1);
            Name = "FRMChangeInvoicedTotal";
            Text = "Change Invoiced Total";
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            Load += new EventHandler(FRMChangeInvoicedTotal_Load);
            ResumeLayout(false);
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