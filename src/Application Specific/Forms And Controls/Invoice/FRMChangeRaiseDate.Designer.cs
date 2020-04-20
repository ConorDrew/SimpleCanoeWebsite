using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMChangeRaiseDate : FRMBaseForm, IForm
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
            dtpTaxDate = new DateTimePicker();
            _Label3 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _txtPassword = new TextBox();
            _txtPassword.TextChanged += new EventHandler(txtPassword_TextChanged);
            _Label1 = new Label();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(dtpTaxDate);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_btnSave);
            _GroupBox1.Controls.Add(_txtPassword);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Location = new Point(12, 38);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(502, 263);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            // 
            // dtpTaxDate
            // 
            dtpTaxDate.Location = new Point(194, 68);
            dtpTaxDate.Name = "dtpTaxDate";
            dtpTaxDate.Size = new Size(291, 21);
            dtpTaxDate.TabIndex = 13;
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
            // FRMChangeRaiseDate
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 313);
            Controls.Add(_GroupBox1);
            Name = "FRMChangeRaiseDate";
            Text = "Confirm Raised Date";
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

        public DateTimePicker dtpTaxDate;
    }
}