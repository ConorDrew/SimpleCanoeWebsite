using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMAddVanEquipment : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMAddVanEquipment));
            _grpEquipment = new GroupBox();
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _cboEquipment = new ComboBox();
            _grpEquipment.SuspendLayout();
            SuspendLayout();
            // 
            // grpEquipment
            // 
            _grpEquipment.Controls.Add(_btnAdd);
            _grpEquipment.Controls.Add(_cboEquipment);
            _grpEquipment.FlatStyle = FlatStyle.System;
            _grpEquipment.Location = new Point(5, 1);
            _grpEquipment.Name = "grpEquipment";
            _grpEquipment.Size = new Size(277, 76);
            _grpEquipment.TabIndex = 0;
            _grpEquipment.TabStop = false;
            _grpEquipment.Text = "Select Equipment";
            // 
            // btnAdd
            // 
            _btnAdd.FlatStyle = FlatStyle.System;
            _btnAdd.Location = new Point(90, 46);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(75, 23);
            _btnAdd.TabIndex = 1;
            _btnAdd.Text = "Add";
            _btnAdd.UseVisualStyleBackColor = true;
            // 
            // cboEquipment
            // 
            _cboEquipment.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEquipment.FlatStyle = FlatStyle.System;
            _cboEquipment.FormattingEnabled = true;
            _cboEquipment.Location = new Point(7, 19);
            _cboEquipment.Name = "cboEquipment";
            _cboEquipment.Size = new Size(264, 21);
            _cboEquipment.TabIndex = 0;
            // 
            // FRMAddVanEquipment
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(284, 82);
            Controls.Add(_grpEquipment);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMAddVanEquipment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Van Equipment";
            _grpEquipment.ResumeLayout(false);
            Load += new EventHandler(FRMAddVanEquipment_Load);
            ResumeLayout(false);
        }

        private GroupBox _grpEquipment;

        internal GroupBox grpEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEquipment != null)
                {
                }

                _grpEquipment = value;
                if (_grpEquipment != null)
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

        private ComboBox _cboEquipment;

        internal ComboBox cboEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEquipment != null)
                {
                }

                _cboEquipment = value;
                if (_cboEquipment != null)
                {
                }
            }
        }
    }
}