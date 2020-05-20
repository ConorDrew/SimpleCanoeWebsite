using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMEngineerTimesheet : FRMBaseForm, IForm
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
            this._btnSave = new System.Windows.Forms.Button();
            this._txtComments = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnFindRecord = new System.Windows.Forms.Button();
            this._txtSearch = new System.Windows.Forms.TextBox();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._lblSearch = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._btnSave);
            this._GroupBox1.Controls.Add(this._txtComments);
            this._GroupBox1.Controls.Add(this._Label1);
            this._GroupBox1.Controls.Add(this._btnFindRecord);
            this._GroupBox1.Controls.Add(this._txtSearch);
            this._GroupBox1.Controls.Add(this._dtpTo);
            this._GroupBox1.Controls.Add(this._dtpFrom);
            this._GroupBox1.Controls.Add(this._Label9);
            this._GroupBox1.Controls.Add(this._Label8);
            this._GroupBox1.Controls.Add(this._lblSearch);
            this._GroupBox1.Controls.Add(this._Label10);
            this._GroupBox1.Controls.Add(this._cboType);
            this._GroupBox1.Location = new System.Drawing.Point(12, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(531, 401);
            this._GroupBox1.TabIndex = 0;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "General Timesheet";
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Location = new System.Drawing.Point(439, 360);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 0;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _txtComments
            // 
            this._txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtComments.Location = new System.Drawing.Point(132, 128);
            this._txtComments.Multiline = true;
            this._txtComments.Name = "_txtComments";
            this._txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtComments.Size = new System.Drawing.Size(382, 226);
            this._txtComments.TabIndex = 11;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(14, 131);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(112, 16);
            this._Label1.TabIndex = 10;
            this._Label1.Text = "Comments";
            // 
            // _btnFindRecord
            // 
            this._btnFindRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindRecord.BackColor = System.Drawing.Color.White;
            this._btnFindRecord.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindRecord.Location = new System.Drawing.Point(482, 45);
            this._btnFindRecord.Name = "_btnFindRecord";
            this._btnFindRecord.Size = new System.Drawing.Size(32, 23);
            this._btnFindRecord.TabIndex = 4;
            this._btnFindRecord.Text = "...";
            this._btnFindRecord.UseVisualStyleBackColor = false;
            this._btnFindRecord.Click += new System.EventHandler(this.btnFindRecord_Click);
            // 
            // _txtSearch
            // 
            this._txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSearch.Location = new System.Drawing.Point(132, 47);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.ReadOnly = true;
            this._txtSearch.Size = new System.Drawing.Size(344, 21);
            this._txtSearch.TabIndex = 3;
            // 
            // _dtpTo
            // 
            this._dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpTo.CustomFormat = "dd MMMM yyyy HH:mm";
            this._dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpTo.Location = new System.Drawing.Point(132, 101);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(382, 21);
            this._dtpTo.TabIndex = 9;
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpFrom.CustomFormat = "dd MMMM yyyy HH:mm";
            this._dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpFrom.Location = new System.Drawing.Point(132, 74);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(382, 21);
            this._dtpFrom.TabIndex = 7;
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(14, 107);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(112, 16);
            this._Label9.TabIndex = 8;
            this._Label9.Text = "End Date Time";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(14, 80);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(112, 16);
            this._Label8.TabIndex = 6;
            this._Label8.Text = "Start Date Time";
            // 
            // _lblSearch
            // 
            this._lblSearch.Location = new System.Drawing.Point(14, 50);
            this._lblSearch.Name = "_lblSearch";
            this._lblSearch.Size = new System.Drawing.Size(112, 20);
            this._lblSearch.TabIndex = 2;
            this._lblSearch.Text = "Engineer";
            // 
            // _Label10
            // 
            this._Label10.Location = new System.Drawing.Point(14, 23);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(48, 20);
            this._Label10.TabIndex = 0;
            this._Label10.Text = "Type";
            // 
            // _cboType
            // 
            this._cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(132, 20);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(382, 21);
            this._cboType.TabIndex = 1;
            // 
            // FRMEngineerTimesheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 424);
            this.Controls.Add(this._GroupBox1);
            this.Name = "FRMEngineerTimesheet";
            this.Text = "Engineer Timesheet";
            this.Load += new System.EventHandler(this.FRMEngineerTimesheet_Load);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
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

        private TextBox _txtComments;

        internal TextBox txtComments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtComments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtComments != null)
                {
                }

                _txtComments = value;
                if (_txtComments != null)
                {
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private Button _btnFindRecord;

        internal Button btnFindRecord
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindRecord;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindRecord != null)
                {
                    _btnFindRecord.Click -= btnFindRecord_Click;
                }

                _btnFindRecord = value;
                if (_btnFindRecord != null)
                {
                    _btnFindRecord.Click += btnFindRecord_Click;
                }
            }
        }

        private TextBox _txtSearch;

        internal TextBox txtSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearch != null)
                {
                }

                _txtSearch = value;
                if (_txtSearch != null)
                {
                }
            }
        }

        private DateTimePicker _dtpTo;

        internal DateTimePicker dtpTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTo != null)
                {
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFrom;

        internal DateTimePicker dtpFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFrom != null)
                {
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
                {
                }
            }
        }

        private Label _Label9;

        internal Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label9 != null)
                {
                }

                _Label9 = value;
                if (_Label9 != null)
                {
                }
            }
        }

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

        private Label _lblSearch;

        internal Label lblSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSearch != null)
                {
                }

                _lblSearch = value;
                if (_lblSearch != null)
                {
                }
            }
        }

        private Label _Label10;

        internal Label Label10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label10 != null)
                {
                }

                _Label10 = value;
                if (_Label10 != null)
                {
                }
            }
        }

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                }

                _cboType = value;
                if (_cboType != null)
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
    }
}