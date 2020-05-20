using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMManualApp : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMManualApp));
            _GroupBox1 = new GroupBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _lblMsg = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _cboInitialPaymentType = new ComboBox();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_Button1);
            _GroupBox1.Controls.Add(_lblMsg);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Controls.Add(_cboInitialPaymentType);
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
            // lblMsg
            // 
            _lblMsg.AutoSize = true;
            _lblMsg.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblMsg.ForeColor = Color.Maroon;
            _lblMsg.Location = new Point(6, 19);
            _lblMsg.Name = "lblMsg";
            _lblMsg.Size = new Size(489, 16);
            _lblMsg.TabIndex = 6;
            _lblMsg.Text = "As you haven't identified a description of an applaince please provide one below." + "";
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
            // cboInitialPaymentType
            // 
            _cboInitialPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInitialPaymentType.FormattingEnabled = true;
            _cboInitialPaymentType.Location = new Point(96, 47);
            _cboInitialPaymentType.Name = "cboInitialPaymentType";
            _cboInitialPaymentType.Size = new Size(330, 21);
            _cboInitialPaymentType.TabIndex = 0;
            // 
            // FRMManualApp
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(513, 182);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMManualApp";
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

        private ComboBox _cboInitialPaymentType;

        internal ComboBox cboInitialPaymentType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInitialPaymentType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInitialPaymentType != null)
                {
                }

                _cboInitialPaymentType = value;
                if (_cboInitialPaymentType != null)
                {
                }
            }
        }

        private Label _lblMsg;

        internal Label lblMsg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMsg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMsg != null)
                {
                }

                _lblMsg = value;
                if (_lblMsg != null)
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
    }
}