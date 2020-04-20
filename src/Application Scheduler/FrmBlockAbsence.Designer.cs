using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FrmBlockAbsence : FRMBaseForm
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
            _txtEndTimeMinutes = new TextBox();
            _txtEndTimeHours = new TextBox();
            _txtStartTimeMinutes = new TextBox();
            _txtStartTimeHours = new TextBox();
            _txtStartTimeHours.TextChanged += new EventHandler(txtEndTimeHours_TextChanged);
            _Label4 = new Label();
            _Label3 = new Label();
            _lblType = new Label();
            _cboType = new ComboBox();
            _dtTo = new DateTimePicker();
            _dtFrom = new DateTimePicker();
            _txtComments = new TextBox();
            _lblToDate = new Label();
            _lblFromDate = new Label();
            _lblComments = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _gbEmployees = new GroupBox();
            _cboEmployeeGroup = new ComboBox();
            _cboEmployeeGroup.SelectedIndexChanged += new EventHandler(cboEmployeeGroup_SelectedIndexChanged);
            _Label24 = new Label();
            _btnClearAll = new Button();
            _btnClearAll.Click += new EventHandler(btnClearAll_Click);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _dgEmployees = new DataGrid();
            _dgEmployees.Click += new EventHandler(dgEmployees_Clicks);
            _dgEmployees.DoubleClick += new EventHandler(dgEmployees_Clicks);
            _dgEmployees.Click += new EventHandler(dgEmployees_Clicks);
            _dgEmployees.DoubleClick += new EventHandler(dgEmployees_Clicks);
            _GroupBox1.SuspendLayout();
            _gbEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEmployees).BeginInit();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_txtEndTimeMinutes);
            _GroupBox1.Controls.Add(_txtEndTimeHours);
            _GroupBox1.Controls.Add(_txtStartTimeMinutes);
            _GroupBox1.Controls.Add(_txtStartTimeHours);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_lblType);
            _GroupBox1.Controls.Add(_cboType);
            _GroupBox1.Controls.Add(_dtTo);
            _GroupBox1.Controls.Add(_dtFrom);
            _GroupBox1.Controls.Add(_txtComments);
            _GroupBox1.Controls.Add(_lblToDate);
            _GroupBox1.Controls.Add(_lblFromDate);
            _GroupBox1.Controls.Add(_lblComments);
            _GroupBox1.Font = new Font("Verdana", 8.0F);
            _GroupBox1.Location = new Point(12, 371);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(624, 153);
            _GroupBox1.TabIndex = 26;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Absence Details";
            // 
            // txtEndTimeMinutes
            // 
            _txtEndTimeMinutes.Location = new Point(288, 88);
            _txtEndTimeMinutes.Name = "txtEndTimeMinutes";
            _txtEndTimeMinutes.Size = new Size(24, 20);
            _txtEndTimeMinutes.TabIndex = 53;
            // 
            // txtEndTimeHours
            // 
            _txtEndTimeHours.Location = new Point(256, 88);
            _txtEndTimeHours.Name = "txtEndTimeHours";
            _txtEndTimeHours.Size = new Size(24, 20);
            _txtEndTimeHours.TabIndex = 52;
            // 
            // txtStartTimeMinutes
            // 
            _txtStartTimeMinutes.Location = new Point(288, 56);
            _txtStartTimeMinutes.Name = "txtStartTimeMinutes";
            _txtStartTimeMinutes.Size = new Size(24, 20);
            _txtStartTimeMinutes.TabIndex = 51;
            // 
            // txtStartTimeHours
            // 
            _txtStartTimeHours.Location = new Point(256, 56);
            _txtStartTimeHours.Name = "txtStartTimeHours";
            _txtStartTimeHours.Size = new Size(24, 20);
            _txtStartTimeHours.TabIndex = 50;
            // 
            // Label4
            // 
            _Label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label4.Location = new Point(280, 88);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(8, 17);
            _Label4.TabIndex = 49;
            _Label4.Text = ":";
            // 
            // Label3
            // 
            _Label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label3.Location = new Point(280, 56);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(8, 17);
            _Label3.TabIndex = 48;
            _Label3.Text = ":";
            // 
            // lblType
            // 
            _lblType.Font = new Font("Verdana", 8.0F);
            _lblType.Location = new Point(8, 24);
            _lblType.Name = "lblType";
            _lblType.Size = new Size(70, 17);
            _lblType.TabIndex = 37;
            _lblType.Text = "Type";
            // 
            // cboType
            // 
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Font = new Font("Verdana", 8.0F);
            _cboType.ItemHeight = 13;
            _cboType.Items.AddRange(new object[] { "Holiday", "Sickness", "Other" });
            _cboType.Location = new Point(80, 24);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(232, 21);
            _cboType.TabIndex = 2;
            // 
            // dtTo
            // 
            _dtTo.Font = new Font("Verdana", 8.0F);
            _dtTo.Location = new Point(80, 88);
            _dtTo.Name = "dtTo";
            _dtTo.Size = new Size(173, 20);
            _dtTo.TabIndex = 6;
            // 
            // dtFrom
            // 
            _dtFrom.Font = new Font("Verdana", 8.0F);
            _dtFrom.Location = new Point(80, 56);
            _dtFrom.Name = "dtFrom";
            _dtFrom.Size = new Size(172, 20);
            _dtFrom.TabIndex = 3;
            // 
            // txtComments
            // 
            _txtComments.Font = new Font("Verdana", 8.0F);
            _txtComments.Location = new Point(320, 43);
            _txtComments.Multiline = true;
            _txtComments.Name = "txtComments";
            _txtComments.ScrollBars = ScrollBars.Both;
            _txtComments.Size = new Size(296, 96);
            _txtComments.TabIndex = 9;
            // 
            // lblToDate
            // 
            _lblToDate.Font = new Font("Verdana", 8.0F);
            _lblToDate.Location = new Point(8, 88);
            _lblToDate.Name = "lblToDate";
            _lblToDate.Size = new Size(46, 18);
            _lblToDate.TabIndex = 20;
            _lblToDate.Text = "To";
            // 
            // lblFromDate
            // 
            _lblFromDate.Font = new Font("Verdana", 8.0F);
            _lblFromDate.Location = new Point(8, 56);
            _lblFromDate.Name = "lblFromDate";
            _lblFromDate.Size = new Size(69, 18);
            _lblFromDate.TabIndex = 19;
            _lblFromDate.Text = "From";
            // 
            // lblComments
            // 
            _lblComments.Font = new Font("Verdana", 8.0F);
            _lblComments.Location = new Point(320, 22);
            _lblComments.Name = "lblComments";
            _lblComments.Size = new Size(72, 17);
            _lblComments.TabIndex = 23;
            _lblComments.Text = "Comments";
            // 
            // btnSave
            // 
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.UseVisualStyleBackColor = true;
            _btnSave.Font = new Font("Verdana", 8.0F);
            _btnSave.Location = new Point(572, 529);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(64, 23);
            _btnSave.TabIndex = 27;
            _btnSave.Text = "Save";
            // 
            // btnCancel
            // 
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.UseVisualStyleBackColor = true;
            _btnCancel.Font = new Font("Verdana", 8.0F);
            _btnCancel.Location = new Point(4, 529);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(64, 23);
            _btnCancel.TabIndex = 28;
            _btnCancel.Text = "Cancel";
            // 
            // gbEmployees
            // 
            _gbEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gbEmployees.Controls.Add(_cboEmployeeGroup);
            _gbEmployees.Controls.Add(_Label24);
            _gbEmployees.Controls.Add(_btnClearAll);
            _gbEmployees.Controls.Add(_btnSelectAll);
            _gbEmployees.Controls.Add(_dgEmployees);
            _gbEmployees.Font = new Font("Verdana", 8.0F);
            _gbEmployees.Location = new Point(12, 38);
            _gbEmployees.Name = "gbEmployees";
            _gbEmployees.Size = new Size(624, 327);
            _gbEmployees.TabIndex = 29;
            _gbEmployees.TabStop = false;
            _gbEmployees.Text = "Employees";
            // 
            // cboEmployeeGroup
            // 
            _cboEmployeeGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboEmployeeGroup.Cursor = Cursors.Hand;
            _cboEmployeeGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEmployeeGroup.Items.AddRange(new object[] { "Engineers", "Users" });
            _cboEmployeeGroup.Location = new Point(118, 14);
            _cboEmployeeGroup.Name = "cboEmployeeGroup";
            _cboEmployeeGroup.Size = new Size(322, 21);
            _cboEmployeeGroup.TabIndex = 46;
            _cboEmployeeGroup.Tag = "";
            // 
            // Label24
            // 
            _Label24.Location = new Point(6, 16);
            _Label24.Name = "Label24";
            _Label24.Size = new Size(105, 20);
            _Label24.TabIndex = 47;
            _Label24.Text = "Employee Group";
            // 
            // btnClearAll
            // 
            _btnClearAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClearAll.UseVisualStyleBackColor = true;
            _btnClearAll.Font = new Font("Verdana", 8.0F);
            _btnClearAll.Location = new Point(80, 293);
            _btnClearAll.Name = "btnClearAll";
            _btnClearAll.Size = new Size(64, 23);
            _btnClearAll.TabIndex = 3;
            _btnClearAll.Text = "Clear All";
            // 
            // btnSelectAll
            // 
            _btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSelectAll.UseVisualStyleBackColor = true;
            _btnSelectAll.Font = new Font("Verdana", 8.0F);
            _btnSelectAll.Location = new Point(10, 293);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(64, 23);
            _btnSelectAll.TabIndex = 2;
            _btnSelectAll.Text = "Select All";
            // 
            // dgEmployees
            // 
            _dgEmployees.AllowNavigation = false;
            _dgEmployees.AlternatingBackColor = Color.GhostWhite;
            _dgEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgEmployees.BackgroundColor = Color.White;
            _dgEmployees.BorderStyle = BorderStyle.FixedSingle;
            _dgEmployees.CaptionBackColor = Color.RoyalBlue;
            _dgEmployees.CaptionForeColor = Color.White;
            _dgEmployees.CaptionText = "Engineers";
            _dgEmployees.CaptionVisible = false;
            _dgEmployees.DataMember = "";
            _dgEmployees.Font = new Font("Verdana", 8.0F);
            _dgEmployees.ForeColor = Color.MidnightBlue;
            _dgEmployees.GridLineColor = Color.RoyalBlue;
            _dgEmployees.HeaderBackColor = Color.MidnightBlue;
            _dgEmployees.HeaderFont = new Font("Tahoma", 8.0F, FontStyle.Bold);
            _dgEmployees.HeaderForeColor = Color.Lavender;
            _dgEmployees.LinkColor = Color.Teal;
            _dgEmployees.Location = new Point(10, 41);
            _dgEmployees.Name = "dgEmployees";
            _dgEmployees.ParentRowsBackColor = Color.Lavender;
            _dgEmployees.ParentRowsForeColor = Color.MidnightBlue;
            _dgEmployees.ParentRowsVisible = false;
            _dgEmployees.RowHeadersVisible = false;
            _dgEmployees.SelectionBackColor = Color.Teal;
            _dgEmployees.SelectionForeColor = Color.PaleGreen;
            _dgEmployees.Size = new Size(605, 243);
            _dgEmployees.TabIndex = 1;
            // 
            // FrmBlockAbsence
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 558);
            Controls.Add(_gbEmployees);
            Controls.Add(_btnSave);
            Controls.Add(_btnCancel);
            Controls.Add(_GroupBox1);
            MaximizeBox = false;
            MinimumSize = new Size(656, 592);
            Name = "FrmBlockAbsence";
            Text = "Block Absences";
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_gbEmployees, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            _gbEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgEmployees).EndInit();
            Load += new EventHandler(FrmBlockAbsence_Load);
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

        private TextBox _txtEndTimeMinutes;

        internal TextBox txtEndTimeMinutes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEndTimeMinutes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEndTimeMinutes != null)
                {
                }

                _txtEndTimeMinutes = value;
                if (_txtEndTimeMinutes != null)
                {
                }
            }
        }

        private TextBox _txtEndTimeHours;

        internal TextBox txtEndTimeHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEndTimeHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEndTimeHours != null)
                {
                }

                _txtEndTimeHours = value;
                if (_txtEndTimeHours != null)
                {
                }
            }
        }

        private TextBox _txtStartTimeMinutes;

        internal TextBox txtStartTimeMinutes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtStartTimeMinutes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtStartTimeMinutes != null)
                {
                }

                _txtStartTimeMinutes = value;
                if (_txtStartTimeMinutes != null)
                {
                }
            }
        }

        private TextBox _txtStartTimeHours;

        internal TextBox txtStartTimeHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtStartTimeHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtStartTimeHours != null)
                {
                    _txtStartTimeHours.TextChanged -= txtEndTimeHours_TextChanged;
                }

                _txtStartTimeHours = value;
                if (_txtStartTimeHours != null)
                {
                    _txtStartTimeHours.TextChanged += txtEndTimeHours_TextChanged;
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

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private Label _lblType;

        internal Label lblType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblType != null)
                {
                }

                _lblType = value;
                if (_lblType != null)
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

        private DateTimePicker _dtTo;

        internal DateTimePicker dtTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtTo != null)
                {
                }

                _dtTo = value;
                if (_dtTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtFrom;

        internal DateTimePicker dtFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtFrom != null)
                {
                }

                _dtFrom = value;
                if (_dtFrom != null)
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

        private Label _lblToDate;

        internal Label lblToDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblToDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblToDate != null)
                {
                }

                _lblToDate = value;
                if (_lblToDate != null)
                {
                }
            }
        }

        private Label _lblFromDate;

        internal Label lblFromDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFromDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFromDate != null)
                {
                }

                _lblFromDate = value;
                if (_lblFromDate != null)
                {
                }
            }
        }

        private Label _lblComments;

        internal Label lblComments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblComments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblComments != null)
                {
                }

                _lblComments = value;
                if (_lblComments != null)
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

        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        private GroupBox _gbEmployees;

        internal GroupBox gbEmployees
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gbEmployees;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gbEmployees != null)
                {
                }

                _gbEmployees = value;
                if (_gbEmployees != null)
                {
                }
            }
        }

        private ComboBox _cboEmployeeGroup;

        internal ComboBox cboEmployeeGroup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEmployeeGroup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEmployeeGroup != null)
                {
                    _cboEmployeeGroup.SelectedIndexChanged -= cboEmployeeGroup_SelectedIndexChanged;
                }

                _cboEmployeeGroup = value;
                if (_cboEmployeeGroup != null)
                {
                    _cboEmployeeGroup.SelectedIndexChanged += cboEmployeeGroup_SelectedIndexChanged;
                }
            }
        }

        private Label _Label24;

        internal Label Label24
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label24;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label24 != null)
                {
                }

                _Label24 = value;
                if (_Label24 != null)
                {
                }
            }
        }

        private Button _btnClearAll;

        internal Button btnClearAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClearAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClearAll != null)
                {
                    _btnClearAll.Click -= btnClearAll_Click;
                }

                _btnClearAll = value;
                if (_btnClearAll != null)
                {
                    _btnClearAll.Click += btnClearAll_Click;
                }
            }
        }

        private Button _btnSelectAll;

        internal Button btnSelectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click -= btnSelectAll_Click;
                }

                _btnSelectAll = value;
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click += btnSelectAll_Click;
                }
            }
        }

        private DataGrid _dgEmployees;

        internal DataGrid dgEmployees
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEmployees;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEmployees != null)
                {
                    _dgEmployees.Click -= dgEmployees_Clicks;
                    _dgEmployees.DoubleClick -= dgEmployees_Clicks;
                }

                _dgEmployees = value;
                if (_dgEmployees != null)
                {
                    _dgEmployees.Click += dgEmployees_Clicks;
                    _dgEmployees.DoubleClick += dgEmployees_Clicks;
                }
            }
        }
    }
}