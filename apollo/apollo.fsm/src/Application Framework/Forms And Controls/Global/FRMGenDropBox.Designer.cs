using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMGenDropBox : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMGenDropBox));
            _GroupBox1 = new GroupBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _lblTop = new Label();
            _lblMiddle = new Label();
            _lblref = new Label();
            _txtref = new TextBox();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _cbo1 = new ComboBox();
            _cbo2 = new ComboBox();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_cbo2);
            _GroupBox1.Controls.Add(_Button1);
            _GroupBox1.Controls.Add(_lblTop);
            _GroupBox1.Controls.Add(_lblMiddle);
            _GroupBox1.Controls.Add(_lblref);
            _GroupBox1.Controls.Add(_txtref);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Controls.Add(_cbo1);
            _GroupBox1.Location = new Point(5, 1);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(505, 169);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            // 
            // Button1
            // 
            _Button1.Location = new Point(10, 140);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(75, 23);
            _Button1.TabIndex = 7;
            _Button1.Text = "Cancel";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // lblTop
            // 
            _lblTop.AutoSize = true;
            _lblTop.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblTop.ForeColor = Color.Maroon;
            _lblTop.Location = new Point(6, 19);
            _lblTop.Name = "lblTop";
            _lblTop.Size = new Size(366, 16);
            _lblTop.TabIndex = 6;
            _lblTop.Text = "You Must Take Payment Now In order to set up this Contract. ";
            // 
            // lblMiddle
            // 
            _lblMiddle.AutoSize = true;
            _lblMiddle.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblMiddle.ForeColor = Color.Maroon;
            _lblMiddle.Location = new Point(5, 45);
            _lblMiddle.Name = "lblMiddle";
            _lblMiddle.Size = new Size(354, 16);
            _lblMiddle.TabIndex = 5;
            _lblMiddle.Text = " Please select payment type and detail payment reference";
            // 
            // lblref
            // 
            _lblref.AutoSize = true;
            _lblref.Location = new Point(93, 115);
            _lblref.Name = "lblref";
            _lblref.Size = new Size(101, 13);
            _lblref.TabIndex = 3;
            _lblref.Text = "Payment Reference";
            // 
            // txtref
            // 
            _txtref.Location = new Point(200, 112);
            _txtref.Name = "txtref";
            _txtref.Size = new Size(226, 20);
            _txtref.TabIndex = 2;
            // 
            // btnOK
            // 
            _btnOK.Location = new Point(424, 140);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "Proceed";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // cbo1
            // 
            _cbo1.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo1.FormattingEnabled = true;
            _cbo1.Location = new Point(97, 76);
            _cbo1.Name = "cbo1";
            _cbo1.Size = new Size(330, 21);
            _cbo1.TabIndex = 0;
            // 
            // cbo2
            // 
            _cbo2.DropDownStyle = ComboBoxStyle.DropDownList;
            _cbo2.FormattingEnabled = true;
            _cbo2.Location = new Point(96, 76);
            _cbo2.Name = "cbo2";
            _cbo2.Size = new Size(330, 21);
            _cbo2.TabIndex = 8;
            _cbo2.Visible = false;
            // 
            // FRMGenDropBox
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(513, 182);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMGenDropBox";
            StartPosition = FormStartPosition.CenterScreen;
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

        private ComboBox _cbo1;

        internal ComboBox cbo1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo1 != null)
                {
                }

                _cbo1 = value;
                if (_cbo1 != null)
                {
                }
            }
        }

        private Label _lblTop;

        internal Label lblTop
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTop;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTop != null)
                {
                }

                _lblTop = value;
                if (_lblTop != null)
                {
                }
            }
        }

        private Label _lblMiddle;

        internal Label lblMiddle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMiddle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMiddle != null)
                {
                }

                _lblMiddle = value;
                if (_lblMiddle != null)
                {
                }
            }
        }

        private Label _lblref;

        internal Label lblref
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblref;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblref != null)
                {
                }

                _lblref = value;
                if (_lblref != null)
                {
                }
            }
        }

        private TextBox _txtref;

        internal TextBox txtref
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtref;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtref != null)
                {
                }

                _txtref = value;
                if (_txtref != null)
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

        private ComboBox _cbo2;

        internal ComboBox cbo2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbo2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbo2 != null)
                {
                }

                _cbo2 = value;
                if (_cbo2 != null)
                {
                }
            }
        }
    }
}