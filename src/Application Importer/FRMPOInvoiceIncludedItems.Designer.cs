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
            _GroupBox1 = new GroupBox();
            _dgvData = new DataGridView();
            _dgvData.CellValueChanged += new DataGridViewCellEventHandler(dgvData_CellValueChanged);
            _dgvData.Click += new EventHandler(dgvData_Click);
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _GroupBox2 = new GroupBox();
            _dgvPOData = new DataGridView();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvData).BeginInit();
            _GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvPOData).BeginInit();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_dgvData);
            _GroupBox1.Location = new Point(12, 313);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(1073, 287);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "INVOICE Included Items";
            // 
            // dgvData
            // 
            _dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvData.Location = new Point(6, 20);
            _dgvData.Name = "dgvData";
            _dgvData.Size = new Size(1061, 261);
            _dgvData.TabIndex = 0;
            // 
            // btnOK
            // 
            _btnOK.Location = new Point(1010, 606);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 3;
            _btnOK.Text = "OK";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            _btnCancel.Location = new Point(929, 606);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 4;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = true;
            _btnCancel.Visible = false;
            // 
            // GroupBox2
            // 
            _GroupBox2.AutoSize = true;
            _GroupBox2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _GroupBox2.Controls.Add(_dgvPOData);
            _GroupBox2.Location = new Point(13, 39);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(1072, 267);
            _GroupBox2.TabIndex = 5;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "PURCHASE ORDER Included Items";
            // 
            // dgvPOData
            // 
            _dgvPOData.AllowUserToAddRows = false;
            _dgvPOData.AllowUserToDeleteRows = false;
            _dgvPOData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvPOData.Location = new Point(7, 21);
            _dgvPOData.Name = "dgvPOData";
            _dgvPOData.ReadOnly = true;
            _dgvPOData.Size = new Size(1059, 226);
            _dgvPOData.TabIndex = 0;
            // 
            // FRMPOInvoiceIncludedItems
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 641);
            Controls.Add(_GroupBox2);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            Controls.Add(_GroupBox1);
            MinimumSize = new Size(820, 420);
            Name = "FRMPOInvoiceIncludedItems";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "PO Invoice Included Items";
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_GroupBox2, 0);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvData).EndInit();
            _GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvPOData).EndInit();
            Load += new EventHandler(FRMPOInvoiceIncludedItems_Load);
            ResumeLayout(false);
            PerformLayout();
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