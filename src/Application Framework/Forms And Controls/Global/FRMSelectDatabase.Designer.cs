using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMSelectDatabase : FRMBaseForm
    {
        private DataTable _dbs;

        private DataTable Databases
        {
            get
            {
                return _dbs;
            }
        }
        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is object)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        public FRMSelectDatabase(DataTable dbs) : base()
        {
            _dbs = dbs;
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call
        }
        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _cboDatabase = new ComboBox();
            _btnOk = new Button();
            _btnOk.Click += new EventHandler(btnOk_Click);
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_btnOk);
            _GroupBox1.Controls.Add(_cboDatabase);
            _GroupBox1.Location = new Point(12, 38);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(356, 95);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Please Select The Database.";
            // 
            // cboDatabase
            // 
            _cboDatabase.FormattingEnabled = true;
            _cboDatabase.Location = new Point(6, 29);
            _cboDatabase.Name = "cboDatabase";
            _cboDatabase.Size = new Size(340, 21);
            _cboDatabase.TabIndex = 0;
            // 
            // btnOk
            // 
            _btnOk.Location = new Point(271, 66);
            _btnOk.Name = "btnOk";
            _btnOk.Size = new Size(75, 23);
            _btnOk.TabIndex = 15;
            _btnOk.Text = "OK";
            // 
            // FRMSelectDatabase
            // 
            ClientSize = new Size(380, 145);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FRMSelectDatabase";
            ShowInTaskbar = true;
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            Load += new EventHandler(FRMSelectDatabase_Load);
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

        private ComboBox _cboDatabase;

        internal ComboBox cboDatabase
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDatabase;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDatabase != null)
                {
                }

                _cboDatabase = value;
                if (_cboDatabase != null)
                {
                }
            }
        }
    }
}