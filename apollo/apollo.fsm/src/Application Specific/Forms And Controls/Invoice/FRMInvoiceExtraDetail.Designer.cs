using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMInvoiceExtraDetail : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMInvoiceExtraDetail));
            _GroupBox1 = new GroupBox();
            _cbo = new ComboBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _Label3 = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _txtNotes = new TextBox();
            _Label1 = new Label();
            _Label2 = new Label();
            _txtCharge = new TextBox();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_txtCharge);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Controls.Add(_txtNotes);
            _GroupBox1.Controls.Add(_cbo);
            _GroupBox1.Controls.Add(_Button1);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Location = new Point(5, 1);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(505, 258);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            // 
            // cbo
            // 
            _cbo.FormattingEnabled = true;
            _cbo.Location = new Point(150, 195);
            _cbo.Name = "cbo";
            _cbo.Size = new Size(298, 21);
            _cbo.TabIndex = 8;
            // 
            // Button1
            // 
            _Button1.UseVisualStyleBackColor = true;
            _Button1.Location = new Point(9, 230);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(75, 23);
            _Button1.TabIndex = 7;
            _Button1.Text = "Cancel";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            _Label3.AutoSize = true;
            _Label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label3.ForeColor = SystemColors.ActiveCaptionText;
            _Label3.Location = new Point(52, 196);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(67, 16);
            _Label3.TabIndex = 6;
            _Label3.Text = "VAT Rate";
            // 
            // btnOK
            // 
            _btnOK.UseVisualStyleBackColor = true;
            _btnOK.Location = new Point(423, 230);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "Proceed";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            _txtNotes.Location = new Point(150, 19);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.Size = new Size(298, 127);
            _txtNotes.TabIndex = 9;
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.ForeColor = SystemColors.ActiveCaptionText;
            _Label1.Location = new Point(52, 20);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(44, 16);
            _Label1.TabIndex = 10;
            _Label1.Text = "Notes";
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label2.ForeColor = SystemColors.ActiveCaptionText;
            _Label2.Location = new Point(52, 164);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(100, 16);
            _Label2.TabIndex = 11;
            _Label2.Text = "Charge Ex VAT";
            // 
            // txtCharge
            // 
            _txtCharge.Location = new Point(150, 163);
            _txtCharge.Name = "txtCharge";
            _txtCharge.Size = new Size(298, 20);
            _txtCharge.TabIndex = 12;
            // 
            // FRMInvoiceExtraDetail
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(513, 271);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMInvoiceExtraDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Take Payment";
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

        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        private ComboBox _cbo;

        internal ComboBox cbo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo != null)
                {
                }

                _cbo = value;
                if (_cbo != null)
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

        private TextBox _txtNotes;

        internal TextBox txtNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotes != null)
                {
                }

                _txtNotes = value;
                if (_txtNotes != null)
                {
                }
            }
        }

        private TextBox _txtCharge;

        internal TextBox txtCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCharge != null)
                {
                }

                _txtCharge = value;
                if (_txtCharge != null)
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
    }
}