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
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._txtEndTimeMinutes = new System.Windows.Forms.TextBox();
            this._txtEndTimeHours = new System.Windows.Forms.TextBox();
            this._txtStartTimeMinutes = new System.Windows.Forms.TextBox();
            this._txtStartTimeHours = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._lblType = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._dtTo = new System.Windows.Forms.DateTimePicker();
            this._dtFrom = new System.Windows.Forms.DateTimePicker();
            this._txtComments = new System.Windows.Forms.TextBox();
            this._lblToDate = new System.Windows.Forms.Label();
            this._lblFromDate = new System.Windows.Forms.Label();
            this._lblComments = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._gbEmployees = new System.Windows.Forms.GroupBox();
            this._cboEmployeeGroup = new System.Windows.Forms.ComboBox();
            this._Label24 = new System.Windows.Forms.Label();
            this._btnClearAll = new System.Windows.Forms.Button();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._dgEmployees = new System.Windows.Forms.DataGrid();
            this._GroupBox1.SuspendLayout();
            this._gbEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._txtEndTimeMinutes);
            this._GroupBox1.Controls.Add(this._txtEndTimeHours);
            this._GroupBox1.Controls.Add(this._txtStartTimeMinutes);
            this._GroupBox1.Controls.Add(this._txtStartTimeHours);
            this._GroupBox1.Controls.Add(this._Label4);
            this._GroupBox1.Controls.Add(this._Label3);
            this._GroupBox1.Controls.Add(this._lblType);
            this._GroupBox1.Controls.Add(this._cboType);
            this._GroupBox1.Controls.Add(this._dtTo);
            this._GroupBox1.Controls.Add(this._dtFrom);
            this._GroupBox1.Controls.Add(this._txtComments);
            this._GroupBox1.Controls.Add(this._lblToDate);
            this._GroupBox1.Controls.Add(this._lblFromDate);
            this._GroupBox1.Controls.Add(this._lblComments);
            this._GroupBox1.Font = new System.Drawing.Font("Verdana", 8F);
            this._GroupBox1.Location = new System.Drawing.Point(12, 371);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(624, 153);
            this._GroupBox1.TabIndex = 26;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Absence Details";
            // 
            // _txtEndTimeMinutes
            // 
            this._txtEndTimeMinutes.Location = new System.Drawing.Point(288, 88);
            this._txtEndTimeMinutes.Name = "_txtEndTimeMinutes";
            this._txtEndTimeMinutes.Size = new System.Drawing.Size(24, 20);
            this._txtEndTimeMinutes.TabIndex = 53;
            // 
            // _txtEndTimeHours
            // 
            this._txtEndTimeHours.Location = new System.Drawing.Point(256, 88);
            this._txtEndTimeHours.Name = "_txtEndTimeHours";
            this._txtEndTimeHours.Size = new System.Drawing.Size(24, 20);
            this._txtEndTimeHours.TabIndex = 52;
            // 
            // _txtStartTimeMinutes
            // 
            this._txtStartTimeMinutes.Location = new System.Drawing.Point(288, 56);
            this._txtStartTimeMinutes.Name = "_txtStartTimeMinutes";
            this._txtStartTimeMinutes.Size = new System.Drawing.Size(24, 20);
            this._txtStartTimeMinutes.TabIndex = 51;
            // 
            // _txtStartTimeHours
            // 
            this._txtStartTimeHours.Location = new System.Drawing.Point(256, 56);
            this._txtStartTimeHours.Name = "_txtStartTimeHours";
            this._txtStartTimeHours.Size = new System.Drawing.Size(24, 20);
            this._txtStartTimeHours.TabIndex = 50;
            this._txtStartTimeHours.TextChanged += new System.EventHandler(this.txtEndTimeHours_TextChanged);
            // 
            // _Label4
            // 
            this._Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label4.Location = new System.Drawing.Point(280, 88);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(8, 17);
            this._Label4.TabIndex = 49;
            this._Label4.Text = ":";
            // 
            // _Label3
            // 
            this._Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label3.Location = new System.Drawing.Point(280, 56);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(8, 17);
            this._Label3.TabIndex = 48;
            this._Label3.Text = ":";
            // 
            // _lblType
            // 
            this._lblType.Font = new System.Drawing.Font("Verdana", 8F);
            this._lblType.Location = new System.Drawing.Point(8, 24);
            this._lblType.Name = "_lblType";
            this._lblType.Size = new System.Drawing.Size(70, 17);
            this._lblType.TabIndex = 37;
            this._lblType.Text = "Type";
            // 
            // _cboType
            // 
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Font = new System.Drawing.Font("Verdana", 8F);
            this._cboType.ItemHeight = 13;
            this._cboType.Items.AddRange(new object[] {
            "Holiday",
            "Sickness",
            "Other"});
            this._cboType.Location = new System.Drawing.Point(80, 24);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(232, 21);
            this._cboType.TabIndex = 2;
            // 
            // _dtTo
            // 
            this._dtTo.Font = new System.Drawing.Font("Verdana", 8F);
            this._dtTo.Location = new System.Drawing.Point(80, 88);
            this._dtTo.Name = "_dtTo";
            this._dtTo.Size = new System.Drawing.Size(173, 20);
            this._dtTo.TabIndex = 6;
            // 
            // _dtFrom
            // 
            this._dtFrom.Font = new System.Drawing.Font("Verdana", 8F);
            this._dtFrom.Location = new System.Drawing.Point(80, 56);
            this._dtFrom.Name = "_dtFrom";
            this._dtFrom.Size = new System.Drawing.Size(172, 20);
            this._dtFrom.TabIndex = 3;
            // 
            // _txtComments
            // 
            this._txtComments.Font = new System.Drawing.Font("Verdana", 8F);
            this._txtComments.Location = new System.Drawing.Point(320, 43);
            this._txtComments.Multiline = true;
            this._txtComments.Name = "_txtComments";
            this._txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtComments.Size = new System.Drawing.Size(296, 96);
            this._txtComments.TabIndex = 9;
            // 
            // _lblToDate
            // 
            this._lblToDate.Font = new System.Drawing.Font("Verdana", 8F);
            this._lblToDate.Location = new System.Drawing.Point(8, 88);
            this._lblToDate.Name = "_lblToDate";
            this._lblToDate.Size = new System.Drawing.Size(46, 18);
            this._lblToDate.TabIndex = 20;
            this._lblToDate.Text = "To";
            // 
            // _lblFromDate
            // 
            this._lblFromDate.Font = new System.Drawing.Font("Verdana", 8F);
            this._lblFromDate.Location = new System.Drawing.Point(8, 56);
            this._lblFromDate.Name = "_lblFromDate";
            this._lblFromDate.Size = new System.Drawing.Size(69, 18);
            this._lblFromDate.TabIndex = 19;
            this._lblFromDate.Text = "From";
            // 
            // _lblComments
            // 
            this._lblComments.Font = new System.Drawing.Font("Verdana", 8F);
            this._lblComments.Location = new System.Drawing.Point(320, 22);
            this._lblComments.Name = "_lblComments";
            this._lblComments.Size = new System.Drawing.Size(72, 17);
            this._lblComments.TabIndex = 23;
            this._lblComments.Text = "Comments";
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnSave.Location = new System.Drawing.Point(572, 529);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(64, 23);
            this._btnSave.TabIndex = 27;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnCancel.Location = new System.Drawing.Point(4, 529);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(64, 23);
            this._btnCancel.TabIndex = 28;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _gbEmployees
            // 
            this._gbEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gbEmployees.Controls.Add(this._cboEmployeeGroup);
            this._gbEmployees.Controls.Add(this._Label24);
            this._gbEmployees.Controls.Add(this._btnClearAll);
            this._gbEmployees.Controls.Add(this._btnSelectAll);
            this._gbEmployees.Controls.Add(this._dgEmployees);
            this._gbEmployees.Font = new System.Drawing.Font("Verdana", 8F);
            this._gbEmployees.Location = new System.Drawing.Point(12, 12);
            this._gbEmployees.Name = "_gbEmployees";
            this._gbEmployees.Size = new System.Drawing.Size(624, 353);
            this._gbEmployees.TabIndex = 29;
            this._gbEmployees.TabStop = false;
            this._gbEmployees.Text = "Employees";
            // 
            // _cboEmployeeGroup
            // 
            this._cboEmployeeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboEmployeeGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboEmployeeGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboEmployeeGroup.Items.AddRange(new object[] {
            "Engineers",
            "Users"});
            this._cboEmployeeGroup.Location = new System.Drawing.Point(118, 14);
            this._cboEmployeeGroup.Name = "_cboEmployeeGroup";
            this._cboEmployeeGroup.Size = new System.Drawing.Size(322, 21);
            this._cboEmployeeGroup.TabIndex = 46;
            this._cboEmployeeGroup.Tag = "";
            this._cboEmployeeGroup.SelectedIndexChanged += new System.EventHandler(this.cboEmployeeGroup_SelectedIndexChanged);
            // 
            // _Label24
            // 
            this._Label24.Location = new System.Drawing.Point(6, 16);
            this._Label24.Name = "_Label24";
            this._Label24.Size = new System.Drawing.Size(105, 20);
            this._Label24.TabIndex = 47;
            this._Label24.Text = "Employee Group";
            // 
            // _btnClearAll
            // 
            this._btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClearAll.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnClearAll.Location = new System.Drawing.Point(80, 319);
            this._btnClearAll.Name = "_btnClearAll";
            this._btnClearAll.Size = new System.Drawing.Size(64, 23);
            this._btnClearAll.TabIndex = 3;
            this._btnClearAll.Text = "Clear All";
            this._btnClearAll.UseVisualStyleBackColor = true;
            this._btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSelectAll.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnSelectAll.Location = new System.Drawing.Point(10, 319);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(64, 23);
            this._btnSelectAll.TabIndex = 2;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.UseVisualStyleBackColor = true;
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _dgEmployees
            // 
            this._dgEmployees.AllowNavigation = false;
            this._dgEmployees.AlternatingBackColor = System.Drawing.Color.GhostWhite;
            this._dgEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgEmployees.BackgroundColor = System.Drawing.Color.White;
            this._dgEmployees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._dgEmployees.CaptionBackColor = System.Drawing.Color.RoyalBlue;
            this._dgEmployees.CaptionForeColor = System.Drawing.Color.White;
            this._dgEmployees.CaptionText = "Engineers";
            this._dgEmployees.CaptionVisible = false;
            this._dgEmployees.DataMember = "";
            this._dgEmployees.Font = new System.Drawing.Font("Verdana", 8F);
            this._dgEmployees.ForeColor = System.Drawing.Color.MidnightBlue;
            this._dgEmployees.GridLineColor = System.Drawing.Color.RoyalBlue;
            this._dgEmployees.HeaderBackColor = System.Drawing.Color.MidnightBlue;
            this._dgEmployees.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._dgEmployees.HeaderForeColor = System.Drawing.Color.Lavender;
            this._dgEmployees.LinkColor = System.Drawing.Color.Teal;
            this._dgEmployees.Location = new System.Drawing.Point(10, 41);
            this._dgEmployees.Name = "_dgEmployees";
            this._dgEmployees.ParentRowsBackColor = System.Drawing.Color.Lavender;
            this._dgEmployees.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this._dgEmployees.ParentRowsVisible = false;
            this._dgEmployees.RowHeadersVisible = false;
            this._dgEmployees.SelectionBackColor = System.Drawing.Color.Teal;
            this._dgEmployees.SelectionForeColor = System.Drawing.Color.PaleGreen;
            this._dgEmployees.Size = new System.Drawing.Size(605, 269);
            this._dgEmployees.TabIndex = 1;
            this._dgEmployees.Click += new System.EventHandler(this.dgEmployees_Clicks);
            this._dgEmployees.DoubleClick += new System.EventHandler(this.dgEmployees_Clicks);
            // 
            // FrmBlockAbsence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 558);
            this.Controls.Add(this._gbEmployees);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._GroupBox1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(656, 592);
            this.Name = "FrmBlockAbsence";
            this.Text = "Block Absences";
            this.Load += new System.EventHandler(this.FrmBlockAbsence_Load);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this._gbEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgEmployees)).EndInit();
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