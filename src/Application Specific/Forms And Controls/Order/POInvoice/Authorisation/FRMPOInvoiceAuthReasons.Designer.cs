using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FRMPOInvoiceAuthReasons : FRMBaseForm
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
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _grbAuthReasons = new GroupBox();
            _txtAuthReasonOther = new TextBox();
            _txtAuthReasonOther.TextChanged += new EventHandler(txtAuthReasonOther_TextChanged);
            _AuthReasonOption1 = new RadioButton();
            _AuthReasonOption1.CheckedChanged += new EventHandler(AuthReasonOption1_CheckedChanged);
            _AuthReasonOption3 = new RadioButton();
            _AuthReasonOption3.CheckedChanged += new EventHandler(AuthReasonOption3_CheckedChanged);
            _AuthReasonOption2 = new RadioButton();
            _AuthReasonOption2.CheckedChanged += new EventHandler(AuthReasonOption2_CheckedChanged);
            _grbAuthReasons.SuspendLayout();
            SuspendLayout();
            // 
            // btnOK
            // 
            _btnOK.Location = new Point(441, 347);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 4;
            _btnOK.Text = "OK";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Location = new Point(360, 347);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 5;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = true;
            _btnCancel.Visible = false;
            // 
            // grbAuthReasons
            // 
            _grbAuthReasons.Controls.Add(_txtAuthReasonOther);
            _grbAuthReasons.Controls.Add(_AuthReasonOption1);
            _grbAuthReasons.Controls.Add(_AuthReasonOption3);
            _grbAuthReasons.Controls.Add(_AuthReasonOption2);
            _grbAuthReasons.Location = new Point(12, 48);
            _grbAuthReasons.Name = "grbAuthReasons";
            _grbAuthReasons.Size = new Size(504, 119);
            _grbAuthReasons.TabIndex = 17;
            _grbAuthReasons.TabStop = false;
            _grbAuthReasons.Text = "Authorisation Reason";
            // 
            // txtAuthReasonOther
            // 
            _txtAuthReasonOther.Location = new Point(48, 82);
            _txtAuthReasonOther.Name = "txtAuthReasonOther";
            _txtAuthReasonOther.Size = new Size(433, 21);
            _txtAuthReasonOther.TabIndex = 16;
            // 
            // AuthReasonOption1
            // 
            _AuthReasonOption1.AutoSize = true;
            _AuthReasonOption1.Location = new Point(48, 18);
            _AuthReasonOption1.Name = "AuthReasonOption1";
            _AuthReasonOption1.Size = new Size(213, 17);
            _AuthReasonOption1.TabIndex = 13;
            _AuthReasonOption1.TabStop = true;
            _AuthReasonOption1.Text = "PO price wrong but value correct";
            _AuthReasonOption1.UseVisualStyleBackColor = true;
            // 
            // AuthReasonOption3
            // 
            _AuthReasonOption3.AutoSize = true;
            _AuthReasonOption3.Location = new Point(48, 58);
            _AuthReasonOption3.Name = "AuthReasonOption3";
            _AuthReasonOption3.Size = new Size(57, 17);
            _AuthReasonOption3.TabIndex = 15;
            _AuthReasonOption3.TabStop = true;
            _AuthReasonOption3.Text = "Other";
            _AuthReasonOption3.UseVisualStyleBackColor = true;
            // 
            // AuthReasonOption2
            // 
            _AuthReasonOption2.AutoSize = true;
            _AuthReasonOption2.Location = new Point(48, 39);
            _AuthReasonOption2.Name = "AuthReasonOption2";
            _AuthReasonOption2.Size = new Size(200, 17);
            _AuthReasonOption2.TabIndex = 14;
            _AuthReasonOption2.TabStop = true;
            _AuthReasonOption2.Text = "PO price wrong credit required";
            _AuthReasonOption2.UseVisualStyleBackColor = true;
            // 
            // FRMPOInvoiceAuthReasons
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 382);
            Controls.Add(_grbAuthReasons);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            Name = "FRMPOInvoiceAuthReasons";
            Text = "FRMPOInvoiceAuthReasons";
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_grbAuthReasons, 0);
            _grbAuthReasons.ResumeLayout(false);
            _grbAuthReasons.PerformLayout();
            ResumeLayout(false);
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

        private GroupBox _grbAuthReasons;

        internal GroupBox grbAuthReasons
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grbAuthReasons;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grbAuthReasons != null)
                {
                }

                _grbAuthReasons = value;
                if (_grbAuthReasons != null)
                {
                }
            }
        }

        private TextBox _txtAuthReasonOther;

        internal TextBox txtAuthReasonOther
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAuthReasonOther;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAuthReasonOther != null)
                {
                    _txtAuthReasonOther.TextChanged -= txtAuthReasonOther_TextChanged;
                }

                _txtAuthReasonOther = value;
                if (_txtAuthReasonOther != null)
                {
                    _txtAuthReasonOther.TextChanged += txtAuthReasonOther_TextChanged;
                }
            }
        }

        private RadioButton _AuthReasonOption1;

        internal RadioButton AuthReasonOption1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AuthReasonOption1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AuthReasonOption1 != null)
                {
                    _AuthReasonOption1.CheckedChanged -= AuthReasonOption1_CheckedChanged;
                }

                _AuthReasonOption1 = value;
                if (_AuthReasonOption1 != null)
                {
                    _AuthReasonOption1.CheckedChanged += AuthReasonOption1_CheckedChanged;
                }
            }
        }

        private RadioButton _AuthReasonOption3;

        internal RadioButton AuthReasonOption3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AuthReasonOption3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AuthReasonOption3 != null)
                {
                    _AuthReasonOption3.CheckedChanged -= AuthReasonOption3_CheckedChanged;
                }

                _AuthReasonOption3 = value;
                if (_AuthReasonOption3 != null)
                {
                    _AuthReasonOption3.CheckedChanged += AuthReasonOption3_CheckedChanged;
                }
            }
        }

        private RadioButton _AuthReasonOption2;

        internal RadioButton AuthReasonOption2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AuthReasonOption2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AuthReasonOption2 != null)
                {
                    _AuthReasonOption2.CheckedChanged -= AuthReasonOption2_CheckedChanged;
                }

                _AuthReasonOption2 = value;
                if (_AuthReasonOption2 != null)
                {
                    _AuthReasonOption2.CheckedChanged += AuthReasonOption2_CheckedChanged;
                }
            }
        }
    }
}