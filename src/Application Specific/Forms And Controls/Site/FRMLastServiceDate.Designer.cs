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
            _GroupBox1 = new GroupBox();
            _dtpActualServiceDate = new DateTimePicker();
            _lblActualServiceDate = new Label();
            _Label2 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _dtpLastServiceDate = new DateTimePicker();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_dtpActualServiceDate);
            _GroupBox1.Controls.Add(_lblActualServiceDate);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_btnSave);
            _GroupBox1.Controls.Add(_dtpLastServiceDate);
            _GroupBox1.Location = new Point(12, 38);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(319, 118);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Change Last Service Date";
            // 
            // dtpActualServiceDate
            // 
            _dtpActualServiceDate.Location = new Point(173, 43);
            _dtpActualServiceDate.Name = "dtpActualServiceDate";
            _dtpActualServiceDate.Size = new Size(139, 21);
            _dtpActualServiceDate.TabIndex = 140;
            // 
            // lblActualServiceDate
            // 
            _lblActualServiceDate.Location = new Point(6, 49);
            _lblActualServiceDate.Name = "lblActualServiceDate";
            _lblActualServiceDate.Size = new Size(124, 20);
            _lblActualServiceDate.TabIndex = 139;
            _lblActualServiceDate.Text = "Service Date";
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(6, 23);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(108, 13);
            _Label2.TabIndex = 138;
            _Label2.Text = "Service Due Date";
            // 
            // btnSave
            // 
            _btnSave.Location = new Point(237, 79);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(75, 23);
            _btnSave.TabIndex = 137;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            // 
            // dtpLastServiceDate
            // 
            _dtpLastServiceDate.Location = new Point(173, 17);
            _dtpLastServiceDate.Name = "dtpLastServiceDate";
            _dtpLastServiceDate.Size = new Size(139, 21);
            _dtpLastServiceDate.TabIndex = 136;
            // 
            // FRMLastServiceDate
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 168);
            Controls.Add(_GroupBox1);
            Name = "FRMLastServiceDate";
            Text = "Change Last Service Date";
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            Load += new EventHandler(FRMLastServiceDate_Load);
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