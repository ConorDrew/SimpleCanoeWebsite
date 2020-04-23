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
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._grbAuthReasons = new System.Windows.Forms.GroupBox();
            this._txtAuthReasonOther = new System.Windows.Forms.TextBox();
            this._AuthReasonOption1 = new System.Windows.Forms.RadioButton();
            this._AuthReasonOption3 = new System.Windows.Forms.RadioButton();
            this._AuthReasonOption2 = new System.Windows.Forms.RadioButton();
            this._grbAuthReasons.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(439, 133);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.Location = new System.Drawing.Point(358, 133);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 5;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Visible = false;
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _grbAuthReasons
            // 
            this._grbAuthReasons.Controls.Add(this._txtAuthReasonOther);
            this._grbAuthReasons.Controls.Add(this._AuthReasonOption1);
            this._grbAuthReasons.Controls.Add(this._AuthReasonOption3);
            this._grbAuthReasons.Controls.Add(this._AuthReasonOption2);
            this._grbAuthReasons.Location = new System.Drawing.Point(12, 5);
            this._grbAuthReasons.Name = "_grbAuthReasons";
            this._grbAuthReasons.Size = new System.Drawing.Size(504, 119);
            this._grbAuthReasons.TabIndex = 17;
            this._grbAuthReasons.TabStop = false;
            this._grbAuthReasons.Text = "Authorisation Reason";
            // 
            // _txtAuthReasonOther
            // 
            this._txtAuthReasonOther.Location = new System.Drawing.Point(48, 82);
            this._txtAuthReasonOther.Name = "_txtAuthReasonOther";
            this._txtAuthReasonOther.Size = new System.Drawing.Size(433, 21);
            this._txtAuthReasonOther.TabIndex = 16;
            this._txtAuthReasonOther.TextChanged += new System.EventHandler(this.txtAuthReasonOther_TextChanged);
            // 
            // _AuthReasonOption1
            // 
            this._AuthReasonOption1.AutoSize = true;
            this._AuthReasonOption1.Location = new System.Drawing.Point(48, 18);
            this._AuthReasonOption1.Name = "_AuthReasonOption1";
            this._AuthReasonOption1.Size = new System.Drawing.Size(213, 17);
            this._AuthReasonOption1.TabIndex = 13;
            this._AuthReasonOption1.TabStop = true;
            this._AuthReasonOption1.Text = "PO price wrong but value correct";
            this._AuthReasonOption1.UseVisualStyleBackColor = true;
            this._AuthReasonOption1.CheckedChanged += new System.EventHandler(this.AuthReasonOption1_CheckedChanged);
            // 
            // _AuthReasonOption3
            // 
            this._AuthReasonOption3.AutoSize = true;
            this._AuthReasonOption3.Location = new System.Drawing.Point(48, 58);
            this._AuthReasonOption3.Name = "_AuthReasonOption3";
            this._AuthReasonOption3.Size = new System.Drawing.Size(57, 17);
            this._AuthReasonOption3.TabIndex = 15;
            this._AuthReasonOption3.TabStop = true;
            this._AuthReasonOption3.Text = "Other";
            this._AuthReasonOption3.UseVisualStyleBackColor = true;
            this._AuthReasonOption3.CheckedChanged += new System.EventHandler(this.AuthReasonOption3_CheckedChanged);
            // 
            // _AuthReasonOption2
            // 
            this._AuthReasonOption2.AutoSize = true;
            this._AuthReasonOption2.Location = new System.Drawing.Point(48, 39);
            this._AuthReasonOption2.Name = "_AuthReasonOption2";
            this._AuthReasonOption2.Size = new System.Drawing.Size(200, 17);
            this._AuthReasonOption2.TabIndex = 14;
            this._AuthReasonOption2.TabStop = true;
            this._AuthReasonOption2.Text = "PO price wrong credit required";
            this._AuthReasonOption2.UseVisualStyleBackColor = true;
            this._AuthReasonOption2.CheckedChanged += new System.EventHandler(this.AuthReasonOption2_CheckedChanged);
            // 
            // FRMPOInvoiceAuthReasons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 170);
            this.Controls.Add(this._grbAuthReasons);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.MinimumSize = new System.Drawing.Size(542, 209);
            this.Name = "FRMPOInvoiceAuthReasons";
            this.Text = "FRMPOInvoiceAuthReasons";
            this.Controls.SetChildIndex(this._btnOK, 0);
            this.Controls.SetChildIndex(this._btnCancel, 0);
            this.Controls.SetChildIndex(this._grbAuthReasons, 0);
            this._grbAuthReasons.ResumeLayout(false);
            this._grbAuthReasons.PerformLayout();
            this.ResumeLayout(false);

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