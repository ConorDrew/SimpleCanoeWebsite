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
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._btnOk = new System.Windows.Forms.Button();
            this._cboDatabase = new System.Windows.Forms.ComboBox();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._btnOk);
            this._GroupBox1.Controls.Add(this._cboDatabase);
            this._GroupBox1.Location = new System.Drawing.Point(12, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(356, 98);
            this._GroupBox1.TabIndex = 2;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Please Select The Database.";
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(271, 66);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 15;
            this._btnOk.Text = "OK";
            this._btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // _cboDatabase
            // 
            this._cboDatabase.FormattingEnabled = true;
            this._cboDatabase.Location = new System.Drawing.Point(6, 29);
            this._cboDatabase.Name = "_cboDatabase";
            this._cboDatabase.Size = new System.Drawing.Size(340, 21);
            this._cboDatabase.TabIndex = 0;
            // 
            // FRMSelectDatabase
            // 
            this.ClientSize = new System.Drawing.Size(380, 122);
            this.ControlBox = false;
            this.Controls.Add(this._GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FRMSelectDatabase";
            this.ShowInTaskbar = true;
            this.Load += new System.EventHandler(this.FRMSelectDatabase_Load);
            this._GroupBox1.ResumeLayout(false);
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