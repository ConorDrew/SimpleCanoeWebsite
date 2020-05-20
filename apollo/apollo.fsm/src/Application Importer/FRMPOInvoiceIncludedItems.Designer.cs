using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMPOInvoiceIncludedItems : FRMBaseForm
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
            this._dgvData = new System.Windows.Forms.DataGridView();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._dgvPOData = new System.Windows.Forms.DataGridView();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvData)).BeginInit();
            this._GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPOData)).BeginInit();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Controls.Add(this._dgvData);
            this._GroupBox1.Location = new System.Drawing.Point(12, 285);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(1073, 315);
            this._GroupBox1.TabIndex = 2;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "INVOICE Included Items";
            // 
            // _dgvData
            // 
            this._dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvData.Location = new System.Drawing.Point(6, 20);
            this._dgvData.Name = "_dgvData";
            this._dgvData.Size = new System.Drawing.Size(1061, 289);
            this._dgvData.TabIndex = 0;
            this._dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValueChanged);
            this._dgvData.Click += new System.EventHandler(this.dgvData_Click);
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(1010, 606);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 3;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(929, 606);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 4;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Visible = false;
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _GroupBox2
            // 
            this._GroupBox2.AutoSize = true;
            this._GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._GroupBox2.Controls.Add(this._dgvPOData);
            this._GroupBox2.Location = new System.Drawing.Point(13, 12);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(1072, 267);
            this._GroupBox2.TabIndex = 5;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "PURCHASE ORDER Included Items";
            // 
            // _dgvPOData
            // 
            this._dgvPOData.AllowUserToAddRows = false;
            this._dgvPOData.AllowUserToDeleteRows = false;
            this._dgvPOData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvPOData.Location = new System.Drawing.Point(7, 21);
            this._dgvPOData.Name = "_dgvPOData";
            this._dgvPOData.ReadOnly = true;
            this._dgvPOData.Size = new System.Drawing.Size(1059, 226);
            this._dgvPOData.TabIndex = 0;
            // 
            // FRMPOInvoiceIncludedItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 641);
            this.Controls.Add(this._GroupBox2);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._GroupBox1);
            this.MinimumSize = new System.Drawing.Size(820, 420);
            this.Name = "FRMPOInvoiceIncludedItems";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "PO Invoice Included Items";
            this.Load += new System.EventHandler(this.FRMPOInvoiceIncludedItems_Load);
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvData)).EndInit();
            this._GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvPOData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private DataGridView _dgvData;

        internal DataGridView dgvData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvData != null)
                {
                    _dgvData.CellValueChanged -= dgvData_CellValueChanged;
                    _dgvData.Click -= dgvData_Click;
                }

                _dgvData = value;
                if (_dgvData != null)
                {
                    _dgvData.CellValueChanged += dgvData_CellValueChanged;
                    _dgvData.Click += dgvData_Click;
                }
            }
        }

        private GroupBox _GroupBox2;

        internal GroupBox GroupBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox2 != null)
                {
                }

                _GroupBox2 = value;
                if (_GroupBox2 != null)
                {
                }
            }
        }

        private DataGridView _dgvPOData;

        internal DataGridView dgvPOData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvPOData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvPOData != null)
                {
                }

                _dgvPOData = value;
                if (_dgvPOData != null)
                {
                }
            }
        }
    }
}