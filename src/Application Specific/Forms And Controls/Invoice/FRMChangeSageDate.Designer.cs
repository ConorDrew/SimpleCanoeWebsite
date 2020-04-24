using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMChangeSageDate : FRMBaseForm, IForm
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
            this._dtpTaxDate = new System.Windows.Forms.DateTimePicker();
            this._Label3 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._dtpTaxDate);
            this._GroupBox1.Controls.Add(this._Label3);
            this._GroupBox1.Controls.Add(this._btnSave);
            this._GroupBox1.Location = new System.Drawing.Point(12, 38);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(502, 97);
            this._GroupBox1.TabIndex = 0;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Change Invoiced Total";
            // 
            // _dtpTaxDate
            // 
            this._dtpTaxDate.Location = new System.Drawing.Point(194, 22);
            this._dtpTaxDate.Name = "_dtpTaxDate";
            this._dtpTaxDate.Size = new System.Drawing.Size(291, 21);
            this._dtpTaxDate.TabIndex = 13;
            // 
            // _Label3
            // 
            this._Label3.AutoSize = true;
            this._Label3.Location = new System.Drawing.Point(6, 30);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(67, 13);
            this._Label3.TabIndex = 5;
            this._Label3.Text = "Sage Date";
            // 
            // _btnSave
            // 
            this._btnSave.Enabled = false;
            this._btnSave.Location = new System.Drawing.Point(410, 58);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FRMChangeSageDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 147);
            this.Controls.Add(this._GroupBox1);
            this.Name = "FRMChangeSageDate";
            this.Text = "Change Sage Date";
            this.Load += new System.EventHandler(this.FRMChangeInvoicedTotal_Load);
            this.Controls.SetChildIndex(this._GroupBox1, 0);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        void IForm.LoadMe(object sender, EventArgs e)
        {
            
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

        private DateTimePicker _dtpTaxDate;

        internal DateTimePicker dtpTaxDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTaxDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTaxDate != null)
                {
                }

                _dtpTaxDate = value;
                if (_dtpTaxDate != null)
                {
                }
            }
        }
    }
}