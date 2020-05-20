using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMItemReturn : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMItemReturn));
            _cboJobType = new ComboBox();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _GroupBox1 = new GroupBox();
            _TextBox2 = new TextBox();
            _TextBox1 = new TextBox();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cboJobType
            // 
            _cboJobType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboJobType.FormattingEnabled = true;
            _cboJobType.Location = new Point(43, 158);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(385, 21);
            _cboJobType.TabIndex = 0;
            // 
            // btnOK
            // 
            _btnOK.UseVisualStyleBackColor = true;
            _btnOK.Location = new Point(388, 241);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "OK";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            _Button1.UseVisualStyleBackColor = true;
            _Button1.Location = new Point(7, 241);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(75, 23);
            _Button1.TabIndex = 2;
            _Button1.Text = "Cancel";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_TextBox2);
            _GroupBox1.Controls.Add(_TextBox1);
            _GroupBox1.Controls.Add(_Button1);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Controls.Add(_cboJobType);
            _GroupBox1.Location = new Point(5, 1);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(476, 270);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Distribute";
            // 
            // TextBox2
            // 
            _TextBox2.Location = new Point(43, 190);
            _TextBox2.Name = "TextBox2";
            _TextBox2.Size = new Size(385, 20);
            _TextBox2.TabIndex = 4;
            // 
            // TextBox1
            // 
            _TextBox1.BorderStyle = BorderStyle.None;
            _TextBox1.Location = new Point(7, 19);
            _TextBox1.Multiline = true;
            _TextBox1.Name = "TextBox1";
            _TextBox1.Size = new Size(463, 121);
            _TextBox1.TabIndex = 3;
            // 
            // FRMItemReturn
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(493, 283);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMItemReturn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Part Distribution";
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            Load += new EventHandler(FRMChangePriority_Load);
            ResumeLayout(false);
        }

        private ComboBox _cboJobType;

        internal ComboBox cboJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJobType != null)
                {
                }

                _cboJobType = value;
                if (_cboJobType != null)
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

        private TextBox _TextBox1;

        internal TextBox TextBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBox1 != null)
                {
                }

                _TextBox1 = value;
                if (_TextBox1 != null)
                {
                }
            }
        }

        private TextBox _TextBox2;

        internal TextBox TextBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBox2 != null)
                {
                }

                _TextBox2 = value;
                if (_TextBox2 != null)
                {
                }
            }
        }
    }
}