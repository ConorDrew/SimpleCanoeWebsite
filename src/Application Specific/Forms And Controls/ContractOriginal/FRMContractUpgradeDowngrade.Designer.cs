using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMContractUpgradeDowngrade : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMContractUpgradeDowngrade));
            _GroupBox1 = new GroupBox();
            _dtpEffDate = new DateTimePicker();
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _lblText = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_dtpEffDate);
            _GroupBox1.Controls.Add(_btnCancel);
            _GroupBox1.Controls.Add(_lblText);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Location = new Point(5, 1);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(364, 139);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            // 
            // dtpEffDate
            // 
            _dtpEffDate.Location = new Point(10, 56);
            _dtpEffDate.Name = "dtpEffDate";
            _dtpEffDate.Size = new Size(200, 20);
            _dtpEffDate.TabIndex = 8;
            // 
            // btnCancel
            // 
            _btnCancel.UseVisualStyleBackColor = true;
            _btnCancel.Location = new Point(10, 102);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 7;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblText
            // 
            _lblText.AutoSize = true;
            _lblText.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblText.ForeColor = Color.Black;
            _lblText.Location = new Point(7, 16);
            _lblText.Name = "lblText";
            _lblText.Size = new Size(346, 16);
            _lblText.TabIndex = 5;
            _lblText.Text = " Please select the date you want the change to take effect";
            // 
            // btnOK
            // 
            _btnOK.UseVisualStyleBackColor = true;
            _btnOK.Location = new Point(278, 102);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "Proceed";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // FRMContractUpgradeDowngrade
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(376, 145);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMContractUpgradeDowngrade";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contracts";
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

        private Label _lblText;

        internal Label lblText
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblText;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblText != null)
                {
                }

                _lblText = value;
                if (_lblText != null)
                {
                }
            }
        }

        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        private DateTimePicker _dtpEffDate;

        internal DateTimePicker dtpEffDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpEffDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpEffDate != null)
                {
                }

                _dtpEffDate = value;
                if (_dtpEffDate != null)
                {
                }
            }
        }
    }
}