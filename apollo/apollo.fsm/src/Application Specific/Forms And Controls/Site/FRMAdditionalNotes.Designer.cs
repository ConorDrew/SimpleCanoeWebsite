using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FrmAdditionalNotes : FRMBaseForm, IForm
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
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._txtAdditionalNotes = new System.Windows.Forms.TextBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._txtAdditionalNotes);
            this._GroupBox1.Controls.Add(this._btnSave);
            this._GroupBox1.Location = new System.Drawing.Point(12, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(504, 144);
            this._GroupBox1.TabIndex = 2;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Please Detail Additional Access/Appointment Info";
            // 
            // _txtAdditionalNotes
            // 
            this._txtAdditionalNotes.Location = new System.Drawing.Point(6, 20);
            this._txtAdditionalNotes.Multiline = true;
            this._txtAdditionalNotes.Name = "_txtAdditionalNotes";
            this._txtAdditionalNotes.Size = new System.Drawing.Size(492, 89);
            this._txtAdditionalNotes.TabIndex = 4;
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(423, 115);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 3;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmAdditionalNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 168);
            this.Controls.Add(this._GroupBox1);
            this.Name = "FrmAdditionalNotes";
            this.Text = "Add Access/Appointment Info";
            this.Load += new System.EventHandler(this.FRMLastServiceDate_Load);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this.ResumeLayout(false);

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

        private TextBox _txtAdditionalNotes;

        internal TextBox txtAdditionalNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAdditionalNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAdditionalNotes != null)
                {
                }

                _txtAdditionalNotes = value;
                if (_txtAdditionalNotes != null)
                {
                }
            }
        }
    }
}