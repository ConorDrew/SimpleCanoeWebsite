using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMCostCentre : FRMBaseForm, IForm
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
            _cboContractCode = new ComboBox();
            _Label2 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_cboContractCode);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_btnSave);
            _GroupBox1.Location = new Point(12, 38);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(504, 118);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Please Select Contract Code";
            // 
            // cboContractCode
            // 
            _cboContractCode.FormattingEnabled = true;
            _cboContractCode.Location = new Point(130, 43);
            _cboContractCode.Name = "cboContractCode";
            _cboContractCode.Size = new Size(355, 21);
            _cboContractCode.TabIndex = 5;
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(6, 46);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(95, 13);
            _Label2.TabIndex = 4;
            _Label2.Text = "Contract Code:";
            // 
            // btnSave
            // 
            _btnSave.Location = new Point(410, 82);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(75, 23);
            _btnSave.TabIndex = 3;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            // 
            // FRMCostCentre
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 168);
            Controls.Add(_GroupBox1);
            Name = "FRMCostCentre";
            Text = "Select Contract Code";
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            Load += new EventHandler(FRMLastServiceDate_Load);
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

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private ComboBox _cboContractCode;

        internal ComboBox cboContractCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboContractCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboContractCode != null)
                {
                }

                _cboContractCode = value;
                if (_cboContractCode != null)
                {
                }
            }
        }
    }
}