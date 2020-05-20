using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMLastServiceDate : FRMBaseForm, IForm
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
            this._dtpActualServiceDate = new System.Windows.Forms.DateTimePicker();
            this._lblActualServiceDate = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._dtpLastServiceDate = new System.Windows.Forms.DateTimePicker();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._dtpActualServiceDate);
            this._GroupBox1.Controls.Add(this._lblActualServiceDate);
            this._GroupBox1.Controls.Add(this._Label2);
            this._GroupBox1.Controls.Add(this._btnSave);
            this._GroupBox1.Controls.Add(this._dtpLastServiceDate);
            this._GroupBox1.Location = new System.Drawing.Point(12, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(319, 144);
            this._GroupBox1.TabIndex = 2;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Change Last Service Date";
            // 
            // _dtpActualServiceDate
            // 
            this._dtpActualServiceDate.Location = new System.Drawing.Point(173, 43);
            this._dtpActualServiceDate.Name = "_dtpActualServiceDate";
            this._dtpActualServiceDate.Size = new System.Drawing.Size(139, 21);
            this._dtpActualServiceDate.TabIndex = 140;
            // 
            // _lblActualServiceDate
            // 
            this._lblActualServiceDate.Location = new System.Drawing.Point(6, 49);
            this._lblActualServiceDate.Name = "_lblActualServiceDate";
            this._lblActualServiceDate.Size = new System.Drawing.Size(124, 20);
            this._lblActualServiceDate.TabIndex = 139;
            this._lblActualServiceDate.Text = "Service Date";
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(6, 23);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(108, 13);
            this._Label2.TabIndex = 138;
            this._Label2.Text = "Service Due Date";
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(237, 79);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 137;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _dtpLastServiceDate
            // 
            this._dtpLastServiceDate.Location = new System.Drawing.Point(173, 17);
            this._dtpLastServiceDate.Name = "_dtpLastServiceDate";
            this._dtpLastServiceDate.Size = new System.Drawing.Size(139, 21);
            this._dtpLastServiceDate.TabIndex = 136;
            // 
            // FRMLastServiceDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 168);
            this.Controls.Add(this._GroupBox1);
            this.Name = "FRMLastServiceDate";
            this.Text = "Change Last Service Date";
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

        private DateTimePicker _dtpActualServiceDate;

        internal DateTimePicker dtpActualServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpActualServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpActualServiceDate != null)
                {
                }

                _dtpActualServiceDate = value;
                if (_dtpActualServiceDate != null)
                {
                }
            }
        }

        private Label _lblActualServiceDate;

        internal Label lblActualServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblActualServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblActualServiceDate != null)
                {
                }

                _lblActualServiceDate = value;
                if (_lblActualServiceDate != null)
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

        private DateTimePicker _dtpLastServiceDate;

        internal DateTimePicker dtpLastServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpLastServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpLastServiceDate != null)
                {
                }

                _dtpLastServiceDate = value;
                if (_dtpLastServiceDate != null)
                {
                }
            }
        }
    }
}