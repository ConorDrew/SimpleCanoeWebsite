using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMMoveParts : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMMoveParts));
            _GroupBox1 = new GroupBox();
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _cboVisit = new ComboBox();
            _txtJobNumber = new TextBox();
            _lblJob = new Label();
            _btnChange = new Button();
            _btnChange.Click += new EventHandler(btnChange_Click);
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_btnChange);
            _GroupBox1.Controls.Add(_txtJobNumber);
            _GroupBox1.Controls.Add(_lblJob);
            _GroupBox1.Controls.Add(_btnCancel);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Controls.Add(_cboVisit);
            _GroupBox1.Dock = DockStyle.Fill;
            _GroupBox1.Location = new Point(0, 0);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(414, 112);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Select Visit To Move Parts to";
            // 
            // btnCancel
            // 
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(7, 82);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 2;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(333, 83);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "OK";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // cboVisit
            // 
            _cboVisit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboVisit.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVisit.FormattingEnabled = true;
            _cboVisit.Location = new Point(7, 51);
            _cboVisit.Name = "cboVisit";
            _cboVisit.Size = new Size(401, 21);
            _cboVisit.TabIndex = 0;
            // 
            // txtJobNumber
            // 
            _txtJobNumber.Location = new Point(64, 22);
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.Size = new Size(84, 20);
            _txtJobNumber.TabIndex = 5;
            // 
            // lblJob
            // 
            _lblJob.Location = new Point(12, 25);
            _lblJob.Name = "lblJob";
            _lblJob.Size = new Size(67, 23);
            _lblJob.TabIndex = 4;
            _lblJob.Text = "Job No:";
            // 
            // btnChange
            // 
            _btnChange.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnChange.Location = new Point(164, 20);
            _btnChange.Name = "btnChange";
            _btnChange.Size = new Size(75, 23);
            _btnChange.TabIndex = 6;
            _btnChange.Text = "Change";
            _btnChange.UseVisualStyleBackColor = true;
            // 
            // FRMMoveParts
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(414, 112);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMMoveParts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Move Parts";
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            Load += new EventHandler(FRMMoveParts_Load);
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

        private ComboBox _cboVisit;

        internal ComboBox cboVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboVisit != null)
                {
                }

                _cboVisit = value;
                if (_cboVisit != null)
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

        private Button _btnChange;

        internal Button btnChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnChange;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnChange != null)
                {
                    _btnChange.Click -= btnChange_Click;
                }

                _btnChange = value;
                if (_btnChange != null)
                {
                    _btnChange.Click += btnChange_Click;
                }
            }
        }

        private TextBox _txtJobNumber;

        internal TextBox txtJobNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobNumber != null)
                {
                }

                _txtJobNumber = value;
                if (_txtJobNumber != null)
                {
                }
            }
        }

        private Label _lblJob;

        internal Label lblJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJob != null)
                {
                }

                _lblJob = value;
                if (_lblJob != null)
                {
                }
            }
        }
    }
}