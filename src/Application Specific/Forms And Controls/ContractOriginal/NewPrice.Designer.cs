using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMNewPrice : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMNewPrice));
            _GroupBox1 = new GroupBox();
            _txtPrice = new TextBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _Label3 = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_txtPrice);
            _GroupBox1.Controls.Add(_Button1);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Location = new Point(5, 1);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(505, 169);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            // 
            // txtPrice
            // 
            _txtPrice.Location = new Point(117, 71);
            _txtPrice.Name = "txtPrice";
            _txtPrice.Size = new Size(278, 20);
            _txtPrice.TabIndex = 8;
            // 
            // Button1
            // 
            _Button1.UseVisualStyleBackColor = true;
            _Button1.Location = new Point(10, 140);
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
            _Label3.ForeColor = Color.Maroon;
            _Label3.Location = new Point(84, 19);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(372, 16);
            _Label3.TabIndex = 6;
            _Label3.Text = "Unable to calculate new/renewal price.  Please input the Price" + (char)13 + (char)10;
            // 
            // btnOK
            // 
            _btnOK.UseVisualStyleBackColor = true;
            _btnOK.Location = new Point(424, 140);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "Proceed";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // FRMNewPrice
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(513, 182);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMNewPrice";
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

        private TextBox _txtPrice;

        internal TextBox txtPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPrice != null)
                {
                }

                _txtPrice = value;
                if (_txtPrice != null)
                {
                }
            }
        }
    }
}