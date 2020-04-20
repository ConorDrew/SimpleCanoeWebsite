using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMChangeJobType : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMChangeJobType));
            _GroupBox1 = new GroupBox();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _cboJobType = new ComboBox();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Controls.Add(_cboJobType);
            _GroupBox1.Location = new Point(5, 1);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(277, 76);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Select Job Type";
            // 
            // btnOK
            // 
            _btnOK.UseVisualStyleBackColor = true;
            _btnOK.Location = new Point(90, 46);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "OK";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // cboJobType
            // 
            _cboJobType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboJobType.FormattingEnabled = true;
            _cboJobType.Location = new Point(7, 19);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(264, 21);
            _cboJobType.TabIndex = 0;
            // 
            // FRMChangeJobType
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(284, 82);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMChangeJobType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Job Type";
            _GroupBox1.ResumeLayout(false);
            Load += new EventHandler(FRMChangeJobType_Load);
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
    }
}