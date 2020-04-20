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
            _GroupBox1 = new GroupBox();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _txtComments = new TextBox();
            _Label1 = new Label();
            _btnFindRecord = new Button();
            _btnFindRecord.Click += new EventHandler(btnFindRecord_Click);
            _txtSearch = new TextBox();
            _dtpTo = new DateTimePicker();
            _dtpFrom = new DateTimePicker();
            _Label9 = new Label();
            _Label8 = new Label();
            _lblSearch = new Label();
            _Label10 = new Label();
            _cboType = new ComboBox();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_btnSave);
            _GroupBox1.Controls.Add(_txtComments);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Controls.Add(_btnFindRecord);
            _GroupBox1.Controls.Add(_txtSearch);
            _GroupBox1.Controls.Add(_dtpTo);
            _GroupBox1.Controls.Add(_dtpFrom);
            _GroupBox1.Controls.Add(_Label9);
            _GroupBox1.Controls.Add(_Label8);
            _GroupBox1.Controls.Add(_lblSearch);
            _GroupBox1.Controls.Add(_Label10);
            _GroupBox1.Controls.Add(_cboType);
            _GroupBox1.Location = new Point(12, 38);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(531, 375);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "General Timesheet";
            // 
            // btnSave
            // 
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(439, 334);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(75, 23);
            _btnSave.TabIndex = 0;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            // 
            // txtComments
            // 
            _txtComments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtComments.Location = new Point(132, 128);
            _txtComments.Multiline = true;
            _txtComments.Name = "txtComments";
            _txtComments.ScrollBars = ScrollBars.Vertical;
            _txtComments.Size = new Size(382, 200);
            _txtComments.TabIndex = 11;
            // 
            // Label1
            // 
            _Label1.Location = new Point(14, 131);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(112, 16);
            _Label1.TabIndex = 10;
            _Label1.Text = "Comments";
            // 
            // btnFindRecord
            // 
            _btnFindRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindRecord.BackColor = Color.White;
            _btnFindRecord.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindRecord.Location = new Point(482, 45);
            _btnFindRecord.Name = "btnFindRecord";
            _btnFindRecord.Size = new Size(32, 23);
            _btnFindRecord.TabIndex = 4;
            _btnFindRecord.Text = "...";
            _btnFindRecord.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            _txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSearch.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSearch.Location = new Point(132, 47);
            _txtSearch.Name = "txtSearch";
            _txtSearch.ReadOnly = true;
            _txtSearch.Size = new Size(344, 21);
            _txtSearch.TabIndex = 3;
            // 
            // dtpTo
            // 
            _dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dtpTo.CustomFormat = "dd MMMM yyyy HH:mm";
            _dtpTo.Format = DateTimePickerFormat.Custom;
            _dtpTo.Location = new Point(132, 101);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(382, 21);
            _dtpTo.TabIndex = 9;
            // 
            // dtpFrom
            // 
            _dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dtpFrom.CustomFormat = "dd MMMM yyyy HH:mm";
            _dtpFrom.Format = DateTimePickerFormat.Custom;
            _dtpFrom.Location = new Point(132, 74);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(382, 21);
            _dtpFrom.TabIndex = 7;
            // 
            // Label9
            // 
            _Label9.Location = new Point(14, 107);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(112, 16);
            _Label9.TabIndex = 8;
            _Label9.Text = "End Date Time";
            // 
            // Label8
            // 
            _Label8.Location = new Point(14, 80);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(112, 16);
            _Label8.TabIndex = 6;
            _Label8.Text = "Start Date Time";
            // 
            // lblSearch
            // 
            _lblSearch.Location = new Point(14, 50);
            _lblSearch.Name = "lblSearch";
            _lblSearch.Size = new Size(112, 20);
            _lblSearch.TabIndex = 2;
            _lblSearch.Text = "Engineer";
            // 
            // Label10
            // 
            _Label10.Location = new Point(14, 23);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(48, 20);
            _Label10.TabIndex = 0;
            _Label10.Text = "Type";
            // 
            // cboType
            // 
            _cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(132, 20);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(382, 21);
            _cboType.TabIndex = 1;
            // 
            // FRMEngineerTimesheet
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 424);
            Controls.Add(_GroupBox1);
            Name = "FRMEngineerTimesheet";
            Text = "Engineer Timesheet";
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            Load += new EventHandler(FRMEngineerTimesheet_Load);
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