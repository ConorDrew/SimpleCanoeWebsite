using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMChangePaymentTerms : FRMBaseForm, IForm
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
            _Label2 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _txtPassword = new TextBox();
            _txtPassword.TextChanged += new EventHandler(txtPassword_TextChanged);
            _Label1 = new Label();
            _cboPaymentTerm = new ComboBox();
            _cboPaymentTerm.SelectedIndexChanged += new EventHandler(cboPaymentTerm_SelectedIndexChanged);
            _cboPaidBy = new ComboBox();
            _lblPaidBy = new Label();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_cboPaidBy);
            _GroupBox1.Controls.Add(_lblPaidBy);
            _GroupBox1.Controls.Add(_cboPaymentTerm);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_btnSave);
            _GroupBox1.Controls.Add(_txtPassword);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Location = new Point(12, 38);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(502, 189);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Change Invoiced Total";
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(6, 61);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(90, 13);
            _Label2.TabIndex = 2;
            _Label2.Text = "Payment Term";
            // 
            // btnSave
            // 
            _btnSave.Enabled = false;
            _btnSave.Location = new Point(410, 160);
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
            // cboPaymentTerm
            // 
            _cboPaymentTerm.Enabled = false;
            _cboPaymentTerm.FormattingEnabled = true;
            _cboPaymentTerm.Location = new Point(194, 58);
            _cboPaymentTerm.Name = "cboPaymentTerm";
            _cboPaymentTerm.Size = new Size(291, 21);
            _cboPaymentTerm.TabIndex = 5;
            // 
            // cboPaidBy
            // 
            _cboPaidBy.FormattingEnabled = true;
            _cboPaidBy.Location = new Point(194, 90);
            _cboPaidBy.Name = "cboPaidBy";
            _cboPaidBy.Size = new Size(291, 21);
            _cboPaidBy.TabIndex = 7;
            _cboPaidBy.Visible = false;
            // 
            // lblPaidBy
            // 
            _lblPaidBy.AutoSize = true;
            _lblPaidBy.Location = new Point(6, 93);
            _lblPaidBy.Name = "lblPaidBy";
            _lblPaidBy.Size = new Size(50, 13);
            _lblPaidBy.TabIndex = 6;
            _lblPaidBy.Text = "Paid By";
            _lblPaidBy.Visible = false;
            // 
            // FRMChangePaymentTerms
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 239);
            Controls.Add(_GroupBox1);
            Name = "FRMChangePaymentTerms";
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
                    _cboPaymentTerm.SelectedIndexChanged -= cboPaymentTerm_SelectedIndexChanged;
                }

                _cboPaymentTerm = value;
                if (_cboPaymentTerm != null)
                {
                    _cboPaymentTerm.SelectedIndexChanged += cboPaymentTerm_SelectedIndexChanged;
                }
            }
        }
    }
}