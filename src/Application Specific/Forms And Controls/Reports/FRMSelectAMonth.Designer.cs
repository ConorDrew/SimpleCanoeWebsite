using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FRMSelectAMonth : Form
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
            _dtpDateFrom = new DateTimePicker();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Controls.Add(_dtpDateFrom);
            _GroupBox1.Location = new Point(8, 5);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(200, 73);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Select A Month";
            // 
            // dtpDateFrom
            // 
            _dtpDateFrom.CustomFormat = "MMMM yyyy";
            _dtpDateFrom.Format = DateTimePickerFormat.Custom;
            _dtpDateFrom.Location = new Point(6, 19);
            _dtpDateFrom.Name = "dtpDateFrom";
            _dtpDateFrom.Size = new Size(188, 20);
            _dtpDateFrom.TabIndex = 0;
            // 
            // btnOK
            // 
            _btnOK.Location = new Point(60, 45);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "OK";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // FRMSelectAMonth
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(216, 84);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FRMSelectAMonth";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select A Month";
            _GroupBox1.ResumeLayout(false);
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

        private DateTimePicker _dtpDateFrom;

        internal DateTimePicker dtpDateFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDateFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDateFrom != null)
                {
                }

                _dtpDateFrom = value;
                if (_dtpDateFrom != null)
                {
                }
            }
        }
    }
}