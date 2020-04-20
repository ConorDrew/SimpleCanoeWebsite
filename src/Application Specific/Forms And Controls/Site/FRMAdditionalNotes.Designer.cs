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
            _GroupBox1 = new GroupBox();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _txtAdditionalNotes = new TextBox();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_txtAdditionalNotes);
            _GroupBox1.Controls.Add(_btnSave);
            _GroupBox1.Location = new Point(12, 38);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(504, 118);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Please Detail Additional Access/Appointment Info";
            // 
            // btnSave
            // 
            _btnSave.Location = new Point(423, 89);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(75, 23);
            _btnSave.TabIndex = 3;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            // 
            // txtAdditionalNotes
            // 
            _txtAdditionalNotes.Location = new Point(6, 20);
            _txtAdditionalNotes.Multiline = true;
            _txtAdditionalNotes.Name = "txtAdditionalNotes";
            _txtAdditionalNotes.Size = new Size(492, 49);
            _txtAdditionalNotes.TabIndex = 4;
            // 
            // FrmAdditionalNotes
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 168);
            Controls.Add(_GroupBox1);
            Name = "FrmAdditionalNotes";
            Text = "Add Access/Appointment Info";
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