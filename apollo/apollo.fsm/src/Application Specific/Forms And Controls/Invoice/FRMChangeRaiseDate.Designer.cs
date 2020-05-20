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
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpTaxDate = new System.Windows.Forms.DateTimePicker();
            this._Label3 = new System.Windows.Forms.Label();
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
            this._GroupBox1.Controls.Add(this.dtpTaxDate);
            this._GroupBox1.Controls.Add(this._Label3);
            this._GroupBox1.Controls.Add(this._btnSave);
            this._GroupBox1.Controls.Add(this._txtPassword);
            this._GroupBox1.Controls.Add(this._Label1);
            this._GroupBox1.Location = new System.Drawing.Point(12, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(502, 143);
            this._GroupBox1.TabIndex = 0;
            this._GroupBox1.TabStop = false;
            // 
            // dtpTaxDate
            // 
            this.dtpTaxDate.Location = new System.Drawing.Point(194, 68);
            this.dtpTaxDate.Name = "dtpTaxDate";
            this.dtpTaxDate.Size = new System.Drawing.Size(291, 21);
            this.dtpTaxDate.TabIndex = 13;
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
            // _btnSave
            // 
            this._btnSave.Enabled = false;
            this._btnSave.Location = new System.Drawing.Point(410, 104);
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
            // FRMChangeRaiseDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 167);
            this.Controls.Add(this._GroupBox1);
            this.Name = "FRMChangeRaiseDate";
            this.Text = "Confirm Raised Date";
            this.Load += new System.EventHandler(this.FRMChangeInvoicedTotal_Load);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this.ResumeLayout(false);

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