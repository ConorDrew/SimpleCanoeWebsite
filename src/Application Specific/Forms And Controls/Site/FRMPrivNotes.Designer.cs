using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMPrivNotes : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMPrivNotes));
            _GroupBox1 = new GroupBox();
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _dgvNotes = new DataGridView();
            _Label4 = new Label();
            _txtEngineernotes = new TextBox();
            _lblMessage = new Label();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvNotes).BeginInit();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_btnAdd);
            _GroupBox1.Controls.Add(_dgvNotes);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_txtEngineernotes);
            _GroupBox1.Controls.Add(_lblMessage);
            _GroupBox1.Controls.Add(_btnClose);
            _GroupBox1.Location = new Point(5, 1);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(945, 421);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            // 
            // btnAdd
            // 
            _btnAdd.UseVisualStyleBackColor = true;
            _btnAdd.Location = new Point(842, 330);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(97, 51);
            _btnAdd.TabIndex = 16;
            _btnAdd.Text = "Add";
            _btnAdd.UseMnemonic = false;
            _btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgvNotes
            // 
            _dgvNotes.AllowUserToAddRows = false;
            _dgvNotes.AllowUserToDeleteRows = false;
            _dgvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvNotes.Location = new Point(10, 11);
            _dgvNotes.Name = "dgvNotes";
            _dgvNotes.Size = new Size(929, 296);
            _dgvNotes.TabIndex = 15;
            // 
            // Label4
            // 
            _Label4.AutoSize = true;
            _Label4.Location = new Point(19, 333);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(120, 13);
            _Label4.TabIndex = 14;
            _Label4.Text = "Additional Private Notes";
            // 
            // txtEngineernotes
            // 
            _txtEngineernotes.Location = new Point(145, 330);
            _txtEngineernotes.Multiline = true;
            _txtEngineernotes.Name = "txtEngineernotes";
            _txtEngineernotes.Size = new Size(691, 51);
            _txtEngineernotes.TabIndex = 13;
            // 
            // lblMessage
            // 
            _lblMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _lblMessage.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblMessage.ForeColor = Color.Maroon;
            _lblMessage.Location = new Point(7, 241);
            _lblMessage.Name = "lblMessage";
            _lblMessage.Size = new Size(932, 24);
            _lblMessage.TabIndex = 12;
            _lblMessage.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            _btnClose.UseVisualStyleBackColor = true;
            _btnClose.Location = new Point(450, 392);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(75, 23);
            _btnClose.TabIndex = 7;
            _btnClose.Text = "Close";
            _btnClose.UseVisualStyleBackColor = true;
            // 
            // FRMPrivNotes
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(962, 434);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(529, 393);
            Name = "FRMPrivNotes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Private Notes";
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvNotes).EndInit();
            Load += new EventHandler(FRMChangePriority_Load);
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

        private Label _lblMessage;

        internal Label lblMessage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMessage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMessage != null)
                {
                }

                _lblMessage = value;
                if (_lblMessage != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private TextBox _txtEngineernotes;

        internal TextBox txtEngineernotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineernotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineernotes != null)
                {
                }

                _txtEngineernotes = value;
                if (_txtEngineernotes != null)
                {
                }
            }
        }

        private DataGridView _dgvNotes;

        internal DataGridView dgvNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvNotes != null)
                {
                }

                _dgvNotes = value;
                if (_dgvNotes != null)
                {
                }
            }
        }

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }
    }
}