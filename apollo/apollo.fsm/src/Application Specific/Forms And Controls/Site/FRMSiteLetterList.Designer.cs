using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMSiteLetterList : FRMBaseForm
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
            this._btnSelect = new System.Windows.Forms.Button();
            this._dgLetters = new System.Windows.Forms.DataGrid();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgLetters)).BeginInit();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Controls.Add(this._btnSelect);
            this._GroupBox1.Controls.Add(this._dgLetters);
            this._GroupBox1.Location = new System.Drawing.Point(8, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(512, 356);
            this._GroupBox1.TabIndex = 2;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Letters";
            // 
            // _btnSelect
            // 
            this._btnSelect.Location = new System.Drawing.Point(429, 322);
            this._btnSelect.Name = "_btnSelect";
            this._btnSelect.Size = new System.Drawing.Size(75, 23);
            this._btnSelect.TabIndex = 3;
            this._btnSelect.Text = "Select";
            this._btnSelect.UseVisualStyleBackColor = true;
            this._btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // _dgLetters
            // 
            this._dgLetters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgLetters.DataMember = "";
            this._dgLetters.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgLetters.Location = new System.Drawing.Point(8, 16);
            this._dgLetters.Name = "_dgLetters";
            this._dgLetters.Size = new System.Drawing.Size(496, 300);
            this._dgLetters.TabIndex = 2;
            // 
            // FRMSiteLetterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 382);
            this.Controls.Add(this._GroupBox1);
            this.Name = "FRMSiteLetterList";
            this.RightToLeftLayout = true;
            this.Text = "Site Letter List";
            this.Load += new System.EventHandler(this.FRMSiteLetterList_Load);
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgLetters)).EndInit();
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

        private Button _btnSelect;

        internal Button btnSelect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelect != null)
                {
                    _btnSelect.Click -= btnSelect_Click;
                }

                _btnSelect = value;
                if (_btnSelect != null)
                {
                    _btnSelect.Click += btnSelect_Click;
                }
            }
        }

        private DataGrid _dgLetters;

        internal DataGrid dgLetters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgLetters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgLetters != null)
                {
                }

                _dgLetters = value;
                if (_dgLetters != null)
                {
                }
            }
        }
    }
}