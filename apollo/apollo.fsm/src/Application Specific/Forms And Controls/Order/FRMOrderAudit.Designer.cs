using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMOrderAudit
    {

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _grpOrderAudit = new GroupBox();
            _dgOrderAudits = new DataGrid();
            _grpOrderAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgOrderAudits).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            _btnClose.AccessibleDescription = "Export Job List To Excel";
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(12, 448);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(67, 25);
            _btnClose.TabIndex = 18;
            _btnClose.Text = "Close";
            _btnClose.UseVisualStyleBackColor = true;
            // 
            // grpOrderAudit
            // 
            _grpOrderAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpOrderAudit.Controls.Add(_dgOrderAudits);
            _grpOrderAudit.Location = new Point(12, 41);
            _grpOrderAudit.Name = "grpOrderAudit";
            _grpOrderAudit.Size = new Size(837, 400);
            _grpOrderAudit.TabIndex = 17;
            _grpOrderAudit.TabStop = false;
            _grpOrderAudit.Text = "Order Audit Trail";
            // 
            // dgOrderAudits
            // 
            _dgOrderAudits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgOrderAudits.DataMember = "";
            _dgOrderAudits.HeaderForeColor = SystemColors.ControlText;
            _dgOrderAudits.Location = new Point(10, 18);
            _dgOrderAudits.Name = "dgOrderAudits";
            _dgOrderAudits.Size = new Size(817, 374);
            _dgOrderAudits.TabIndex = 14;
            // 
            // FRMOrderAudit
            // 
            this.AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(848, 481);
            this.Controls.Add(_btnClose);
            this.Controls.Add(_grpOrderAudit);
            this.Name = "Order Audit Trail";
            this.Text = "Order Audit Trail";
            this.Controls.SetChildIndex(_grpOrderAudit, 0);
            this.Controls.SetChildIndex(_btnClose, 0);
            _grpOrderAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgOrderAudits).EndInit();
            this.Load += new EventHandler(FRMOrderAudit_Load);
            this.ResumeLayout(false);
        }

        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        private GroupBox _grpOrderAudit;

        internal GroupBox grpOrderAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpOrderAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpOrderAudit != null)
                {
                }

                _grpOrderAudit = value;
                if (_grpOrderAudit != null)
                {
                }
            }
        }

        private DataGrid _dgOrderAudits;

        internal DataGrid dgOrderAudits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgOrderAudits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgOrderAudits != null)
                {
                }

                _dgOrderAudits = value;
                if (_dgOrderAudits != null)
                {
                }
            }
        }
    }
}