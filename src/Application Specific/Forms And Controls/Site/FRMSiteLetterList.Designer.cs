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
            _GroupBox1 = new GroupBox();
            _dgLetters = new DataGrid();
            _btnSelect = new Button();
            _btnSelect.Click += new EventHandler(btnSelect_Click);
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgLetters).BeginInit();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_btnSelect);
            _GroupBox1.Controls.Add(_dgLetters);
            _GroupBox1.Location = new Point(8, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(512, 328);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Letters";
            // 
            // dgLetters
            // 
            _dgLetters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgLetters.DataMember = "";
            _dgLetters.HeaderForeColor = SystemColors.ControlText;
            _dgLetters.Location = new Point(8, 16);
            _dgLetters.Name = "dgLetters";
            _dgLetters.Size = new Size(496, 272);
            _dgLetters.TabIndex = 2;
            // 
            // btnSelect
            // 
            _btnSelect.Location = new Point(424, 296);
            _btnSelect.Name = "btnSelect";
            _btnSelect.Size = new Size(75, 23);
            _btnSelect.TabIndex = 3;
            _btnSelect.Text = "Select";
            _btnSelect.UseVisualStyleBackColor = true;
            // 
            // FRMSiteLetterList
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 382);
            Controls.Add(_GroupBox1);
            Name = "FRMSiteLetterList";
            RightToLeftLayout = true;
            Text = "Site Letter List";
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgLetters).EndInit();
            Load += new EventHandler(FRMSiteLetterList_Load);
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