using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMCreateServices : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMCreateServices));
            _GroupBox1 = new GroupBox();
            _chxCert = new CheckBox();
            _Label2 = new Label();
            _txtAmount = new TextBox();
            _Label1 = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _btnclose = new Button();
            _btnclose.Click += new EventHandler(btnclose_Click);
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_btnclose);
            _GroupBox1.Controls.Add(_chxCert);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_txtAmount);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Location = new Point(5, 1);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(277, 86);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Select Qty to Create";
            // 
            // chxCert
            // 
            _chxCert.AutoSize = true;
            _chxCert.Location = new Point(240, 20);
            _chxCert.Name = "chxCert";
            _chxCert.Size = new Size(15, 14);
            _chxCert.TabIndex = 5;
            _chxCert.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(153, 20);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(78, 13);
            _Label2.TabIndex = 4;
            _Label2.Text = "Cert Required?";
            // 
            // txtAmount
            // 
            _txtAmount.Location = new Point(101, 17);
            _txtAmount.Name = "txtAmount";
            _txtAmount.Size = new Size(42, 20);
            _txtAmount.TabIndex = 3;
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Location = new Point(9, 20);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(88, 13);
            _Label1.TabIndex = 2;
            _Label1.Text = "Amount to create";
            // 
            // btnOK
            // 
            _btnOK.UseVisualStyleBackColor = true;
            _btnOK.Location = new Point(196, 57);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "Create";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            _btnclose.UseVisualStyleBackColor = true;
            _btnclose.Location = new Point(6, 57);
            _btnclose.Name = "btnclose";
            _btnclose.Size = new Size(75, 23);
            _btnclose.TabIndex = 6;
            _btnclose.Text = "Close";
            _btnclose.UseVisualStyleBackColor = true;
            // 
            // FRMCreateServices
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(284, 99);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMCreateServices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Services";
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            Load += new EventHandler(FRMChangePriority_Load);
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

        private Button _btnOK;

        internal Button btnOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
                }
            }
        }

        private CheckBox _chxCert;

        internal CheckBox chxCert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chxCert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chxCert != null)
                {
                }

                _chxCert = value;
                if (_chxCert != null)
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

        private Button _btnclose;

        internal Button btnclose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnclose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnclose != null)
                {
                    _btnclose.Click -= btnclose_Click;
                }

                _btnclose = value;
                if (_btnclose != null)
                {
                    _btnclose.Click += btnclose_Click;
                }
            }
        }
    }
}