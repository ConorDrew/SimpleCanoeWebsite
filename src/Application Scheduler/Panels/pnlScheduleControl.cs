using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class pnlScheduleControl : UserControl
    {
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

        private Label _lblTo;

        internal Label lblTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTo != null)
                {
                }

                _lblTo = value;
                if (_lblTo != null)
                {
                }
            }
        }

        private Button _btnGo;

        internal Button btnGo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGo != null)
                {
                    _btnGo.Click -= btnGo_Click;
                }

                _btnGo = value;
                if (_btnGo != null)
                {
                    _btnGo.Click += btnGo_Click;
                }
            }
        }

        private Button _btnAbsenceLegend;

        internal Button btnAbsenceLegend
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAbsenceLegend;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAbsenceLegend != null)
                {
                    _btnAbsenceLegend.Click -= btnAbsenceLegend_Click;
                }

                _btnAbsenceLegend = value;
                if (_btnAbsenceLegend != null)
                {
                    _btnAbsenceLegend.Click += btnAbsenceLegend_Click;
                }
            }
        }

        private Button _btnBack;

        internal Button btnBack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnBack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnBack != null)
                {
                    _btnBack.Click -= btnBack_Click;
                }

                _btnBack = value;
                if (_btnBack != null)
                {
                    _btnBack.Click += btnBack_Click;
                }
            }
        }

        private Button _btnForward;

        internal Button btnForward
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnForward;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnForward != null)
                {
                    _btnForward.Click -= btnForward_Click;
                }

                _btnForward = value;
                if (_btnForward != null)
                {
                    _btnForward.Click += btnForward_Click;
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

        private TextBox _txtTextSize;

        internal TextBox txtTextSize
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTextSize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTextSize != null)
                {
                }

                _txtTextSize = value;
                if (_txtTextSize != null)
                {
                }
            }
        }

        private Button _btnTextApply;

        internal Button btnTextApply
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnTextApply;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnTextApply != null)
                {
                    _btnTextApply.Click -= btnTextApply_Click;
                }

                _btnTextApply = value;
                if (_btnTextApply != null)
                {
                    _btnTextApply.Click += btnTextApply_Click;
                }
            }
        }

        private Button _btnFind;

        internal Button btnFind
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFind;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFind != null)
                {
                    _btnFind.Click -= btnFind_Click;
                }

                _btnFind = value;
                if (_btnFind != null)
                {
                    _btnFind.Click += btnFind_Click;
                }
            }
        }

        private Button _btnNewJob;

        internal Button btnNewJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnNewJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnNewJob != null)
                {
                    _btnNewJob.Click -= btnNewJob_Click;
                }

                _btnNewJob = value;
                if (_btnNewJob != null)
                {
                    _btnNewJob.Click += btnNewJob_Click;
                }
            }
        }

        private Button _btnRefresh;

        internal Button btnRefresh
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRefresh;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRefresh != null)
                {
                    _btnRefresh.Click -= btnRefresh_Click;
                }

                _btnRefresh = value;
                if (_btnRefresh != null)
                {
                    _btnRefresh.Click += btnRefresh_Click;
                }
            }
        }

        public pnlScheduleControl() : base()
        {
            InitializeComponent();
            if (App.loggedInUser.SchedulerTextSize > 0)
            {
                txtTextSize.Text = App.loggedInUser.SchedulerTextSize.ToString();
                textsize = Conversions.ToInteger(txtTextSize.Text);
            }
            else
            {
                txtTextSize.Text = 8.ToString();
                textsize = Conversions.ToInteger(txtTextSize.Text);
            }
        }

        public event dateRangeChangedEventHandler dateRangeChanged;

        public delegate void dateRangeChangedEventHandler(DateTime fromDate, DateTime toDate);

        public event refreshSchedulerEventHandler refreshScheduler;

        public delegate void refreshSchedulerEventHandler();

        public event closeSchedulerEventHandler closeScheduler;

        public delegate void closeSchedulerEventHandler();

        public event displayEngineersEventHandler displayEngineers;

        public delegate void displayEngineersEventHandler();

        public event loadEngineerSchedulesEventHandler loadEngineerSchedules;

        public delegate void loadEngineerSchedulesEventHandler(DateTime fromDate, DateTime toDate);

        public event ResizeSchedulingAreaEventHandler ResizeSchedulingArea;

        public delegate void ResizeSchedulingAreaEventHandler();

        private string _datesString = string.Empty;
        public int textsize = 0;

        public DateTime dateFrom
        {
            get
            {
                return dtpFromDate.Value;
            }

            set
            {
                dtpFromDate.Value = value;
            }
        }

        public DateTime dateTo
        {
            get
            {
                return dtpToDate.Value;
            }

            set
            {
                dtpToDate.Value = value;
            }
        }

        public string datesString
        {
            get
            {
                if ((_datesString ?? "") == (string.Empty ?? ""))
                {
                    // This will always have one iteration
                    for (int dayCount = 0, loopTo = dateTo.Date.Subtract(dateFrom.Date).Days; dayCount <= loopTo; dayCount++)
                    {
                        if (dayCount == 0)
                        {
                            _datesString += Strings.Format(dateFrom.AddDays(dayCount).Date, "yyyy-MM-dd");
                        }
                        else
                        {
                            _datesString += "," + Strings.Format(dateFrom.AddDays(dayCount).Date, "yyyy-MM-dd");
                        }
                    }
                }

                return _datesString;
            }
        }

        private DateTimePicker _dtpFromDate;

        internal DateTimePicker dtpFromDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFromDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFromDate != null)
                {
                }

                _dtpFromDate = value;
                if (_dtpFromDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpToDate;

        internal DateTimePicker dtpToDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpToDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpToDate != null)
                {
                }

                _dtpToDate = value;
                if (_dtpToDate != null)
                {
                }
            }
        }

        private PictureBox _picBoxCal1;

        internal PictureBox picBoxCal1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picBoxCal1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picBoxCal1 != null)
                {
                }

                _picBoxCal1 = value;
                if (_picBoxCal1 != null)
                {
                }
            }
        }

        private PictureBox _picBoxCal2;

        internal PictureBox picBoxCal2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picBoxCal2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picBoxCal2 != null)
                {
                }

                _picBoxCal2 = value;
                if (_picBoxCal2 != null)
                {
                }
            }
        }

        private Panel _pnlControls;

        internal Panel pnlControls
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlControls;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlControls != null)
                {
                }

                _pnlControls = value;
                if (_pnlControls != null)
                {
                }
            }
        }

        private Button _btnDisplayEngineers;

        internal Button btnDisplayEngineers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDisplayEngineers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDisplayEngineers != null)
                {
                    _btnDisplayEngineers.Click -= btnDisplayEngineers_Click;
                }

                _btnDisplayEngineers = value;
                if (_btnDisplayEngineers != null)
                {
                    _btnDisplayEngineers.Click += btnDisplayEngineers_Click;
                }
            }
        }

        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(pnlScheduleControl));
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _dtpFromDate = new DateTimePicker();
            _dtpToDate = new DateTimePicker();
            _lblFromDate = new Label();
            _lblTo = new Label();
            _btnRefresh = new Button();
            _btnRefresh.Click += new EventHandler(btnRefresh_Click);
            _pnlControls = new Panel();
            _btnBack = new Button();
            _btnBack.Click += new EventHandler(btnBack_Click);
            _btnForward = new Button();
            _btnForward.Click += new EventHandler(btnForward_Click);
            _btnGo = new Button();
            _btnGo.Click += new EventHandler(btnGo_Click);
            _picBoxCal1 = new PictureBox();
            _picBoxCal2 = new PictureBox();
            _btnDisplayEngineers = new Button();
            _btnDisplayEngineers.Click += new EventHandler(btnDisplayEngineers_Click);
            _btnAbsenceLegend = new Button();
            _btnAbsenceLegend.Click += new EventHandler(btnAbsenceLegend_Click);
            _Label1 = new Label();
            _txtTextSize = new TextBox();
            _btnTextApply = new Button();
            _btnTextApply.Click += new EventHandler(btnTextApply_Click);
            _btnFind = new Button();
            _btnFind.Click += new EventHandler(btnFind_Click);
            _btnNewJob = new Button();
            _btnNewJob.Click += new EventHandler(btnNewJob_Click);
            _pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_picBoxCal1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picBoxCal2).BeginInit();
            SuspendLayout();
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnClose.Location = new Point(1306, 3);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 23);
            _btnClose.TabIndex = 5;
            _btnClose.Text = "Close";
            _btnClose.UseVisualStyleBackColor = true;
            //
            // dtpFromDate
            //
            _dtpFromDate.Location = new Point(128, 4);
            _dtpFromDate.Name = "dtpFromDate";
            _dtpFromDate.Size = new Size(144, 21);
            _dtpFromDate.TabIndex = 1;
            //
            // dtpToDate
            //
            _dtpToDate.Location = new Point(296, 4);
            _dtpToDate.Name = "dtpToDate";
            _dtpToDate.Size = new Size(144, 21);
            _dtpToDate.TabIndex = 2;
            //
            // lblFromDate
            //
            _lblFromDate.BackColor = Color.Transparent;
            _lblFromDate.Location = new Point(56, 8);
            _lblFromDate.Name = "lblFromDate";
            _lblFromDate.Size = new Size(76, 14);
            _lblFromDate.TabIndex = 3;
            _lblFromDate.Text = "Diary From";
            //
            // lblTo
            //
            _lblTo.BackColor = Color.Transparent;
            _lblTo.Location = new Point(272, 8);
            _lblTo.Name = "lblTo";
            _lblTo.Size = new Size(24, 16);
            _lblTo.TabIndex = 4;
            _lblTo.Text = "To";
            //
            // btnRefresh
            //
            _btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnRefresh.Location = new Point(1244, 3);
            _btnRefresh.Name = "btnRefresh";
            _btnRefresh.Size = new Size(56, 23);
            _btnRefresh.TabIndex = 4;
            _btnRefresh.Text = "Refresh";
            _btnRefresh.UseVisualStyleBackColor = true;
            //
            // pnlControls
            //
            _pnlControls.BackColor = Color.Transparent;
            _pnlControls.Controls.Add(_btnBack);
            _pnlControls.Controls.Add(_btnForward);
            _pnlControls.Controls.Add(_btnGo);
            _pnlControls.Controls.Add(_dtpFromDate);
            _pnlControls.Controls.Add(_dtpToDate);
            _pnlControls.Controls.Add(_lblFromDate);
            _pnlControls.Controls.Add(_lblTo);
            _pnlControls.Location = new Point(447, 0);
            _pnlControls.Name = "pnlControls";
            _pnlControls.Size = new Size(564, 30);
            _pnlControls.TabIndex = 7;
            //
            // btnBack
            //
            _btnBack.Location = new Point(14, 3);
            _btnBack.Name = "btnBack";
            _btnBack.Size = new Size(36, 23);
            _btnBack.TabIndex = 7;
            _btnBack.Text = "<<";
            _btnBack.UseVisualStyleBackColor = true;
            //
            // btnForward
            //
            _btnForward.Location = new Point(494, 3);
            _btnForward.Name = "btnForward";
            _btnForward.Size = new Size(36, 23);
            _btnForward.TabIndex = 6;
            _btnForward.Text = ">>";
            _btnForward.UseVisualStyleBackColor = true;
            //
            // btnGo
            //
            _btnGo.Location = new Point(452, 3);
            _btnGo.Name = "btnGo";
            _btnGo.Size = new Size(36, 23);
            _btnGo.TabIndex = 5;
            _btnGo.Text = "Go";
            _btnGo.UseVisualStyleBackColor = true;
            //
            // picBoxCal1
            //
            _picBoxCal1.Image = (Image)resources.GetObject("picBoxCal1.Image");
            _picBoxCal1.Location = new Point(0, 0);
            _picBoxCal1.Name = "picBoxCal1";
            _picBoxCal1.Size = new Size(120, 32);
            _picBoxCal1.TabIndex = 8;
            _picBoxCal1.TabStop = false;
            //
            // picBoxCal2
            //
            _picBoxCal2.Image = (Image)resources.GetObject("picBoxCal2.Image");
            _picBoxCal2.Location = new Point(117, 0);
            _picBoxCal2.Name = "picBoxCal2";
            _picBoxCal2.Size = new Size(267, 30);
            _picBoxCal2.SizeMode = PictureBoxSizeMode.StretchImage;
            _picBoxCal2.TabIndex = 9;
            _picBoxCal2.TabStop = false;
            //
            // btnDisplayEngineers
            //
            _btnDisplayEngineers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnDisplayEngineers.Location = new Point(1182, 3);
            _btnDisplayEngineers.Name = "btnDisplayEngineers";
            _btnDisplayEngineers.Size = new Size(56, 23);
            _btnDisplayEngineers.TabIndex = 3;
            _btnDisplayEngineers.Text = "Display";
            _btnDisplayEngineers.UseVisualStyleBackColor = true;
            //
            // btnAbsenceLegend
            //
            _btnAbsenceLegend.Location = new Point(3, 3);
            _btnAbsenceLegend.Name = "btnAbsenceLegend";
            _btnAbsenceLegend.Size = new Size(135, 23);
            _btnAbsenceLegend.TabIndex = 10;
            _btnAbsenceLegend.Text = "Absence Colour Key";
            _btnAbsenceLegend.UseVisualStyleBackColor = true;
            //
            // Label1
            //
            _Label1.BackColor = Color.Transparent;
            _Label1.Location = new Point(162, 10);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(89, 14);
            _Label1.TabIndex = 11;
            _Label1.Text = "Text Size 6-12";
            //
            // txtTextSize
            //
            _txtTextSize.Location = new Point(257, 5);
            _txtTextSize.Name = "txtTextSize";
            _txtTextSize.Size = new Size(41, 21);
            _txtTextSize.TabIndex = 12;
            //
            // btnTextApply
            //
            _btnTextApply.Location = new Point(316, 4);
            _btnTextApply.Name = "btnTextApply";
            _btnTextApply.Size = new Size(47, 23);
            _btnTextApply.TabIndex = 13;
            _btnTextApply.Text = "Apply";
            _btnTextApply.UseVisualStyleBackColor = true;
            //
            // btnFind
            //
            _btnFind.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFind.Location = new Point(1120, 3);
            _btnFind.Name = "btnFind";
            _btnFind.Size = new Size(56, 23);
            _btnFind.TabIndex = 14;
            _btnFind.Text = "Find";
            _btnFind.UseVisualStyleBackColor = true;
            //
            // btnNewJob
            //
            _btnNewJob.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnNewJob.Location = new Point(1052, 3);
            _btnNewJob.Name = "btnNewJob";
            _btnNewJob.Size = new Size(62, 23);
            _btnNewJob.TabIndex = 15;
            _btnNewJob.Text = "New Job";
            _btnNewJob.UseVisualStyleBackColor = true;
            //
            // pnlScheduleControl
            //
            BackColor = Color.White;
            Controls.Add(_btnNewJob);
            Controls.Add(_btnFind);
            Controls.Add(_btnTextApply);
            Controls.Add(_txtTextSize);
            Controls.Add(_Label1);
            Controls.Add(_btnAbsenceLegend);
            Controls.Add(_pnlControls);
            Controls.Add(_btnDisplayEngineers);
            Controls.Add(_picBoxCal2);
            Controls.Add(_picBoxCal1);
            Controls.Add(_btnRefresh);
            Controls.Add(_btnClose);
            Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Name = "pnlScheduleControl";
            Size = new Size(1370, 30);
            _pnlControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_picBoxCal1).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picBoxCal2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtpToDate.MinDate = dtpFromDate.Value;
            _datesString = string.Empty;
            refreshScheduler?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            closeScheduler?.Invoke();
        }

        protected override void OnResize(EventArgs e)
        {
            pnlControls.Left = Conversions.ToInteger(Width / (double)2 - pnlControls.Width / (double)2);
            picBoxCal2.Width = Conversions.ToInteger(Width * 0.21) - picBoxCal1.Width;
        }

        private void btnDisplayEngineers_Click(object sender, EventArgs e)
        {
            displayEngineers?.Invoke();
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateAndTime.Now;
            dtpToDate.Value = DateAndTime.Now;
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateAndTime.Now;
            dtpToDate.Value = DateAndTime.Now.AddDays(7);
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateAndTime.Now;
            dtpToDate.Value = DateAndTime.Now.AddMonths(1);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            dtpToDate.MinDate = dtpFromDate.Value;
            _datesString = string.Empty;
            dateRangeChanged?.Invoke(dtpFromDate.Value, dtpToDate.Value);
        }

        private void btnAbsenceLegend_Click(object sender, EventArgs e)
        {
            var f = new FRMAbsenceColourKey();
            f.ShowDialog();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            dtpFromDate.Value = Conversions.ToDate(dtpFromDate.Value.AddDays(1).ToString("dd/MM/yyyy"));
            dtpToDate.Value = Conversions.ToDate(dtpToDate.Value.AddDays(1).ToString("dd/MM/yyyy"));
            _datesString = string.Empty;
            dateRangeChanged?.Invoke(dtpFromDate.Value, dtpToDate.Value);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dtpFromDate.Value = Conversions.ToDate(dtpFromDate.Value.AddDays(-1).ToString("dd/MM/yyyy"));
            dtpToDate.Value = Conversions.ToDate(dtpToDate.Value.AddDays(-1).ToString("dd/MM/yyyy"));
            _datesString = string.Empty;
            dateRangeChanged?.Invoke(dtpFromDate.Value, dtpToDate.Value);
        }

        private void btnTextApply_Click(object sender, EventArgs e)
        {
            if ((txtTextSize.Text.Length > 0 && Information.IsNumeric(txtTextSize.Text) && Conversions.ToDouble(txtTextSize.Text) > 5) & Conversions.ToDouble(txtTextSize.Text) < 13)
            {
                App.DB.User.User_Update_TextSize(App.loggedInUser.UserID, Conversions.ToInteger(txtTextSize.Text));
                App.loggedInUser.SetSchedulerTextSize = Conversions.ToInteger(txtTextSize.Text);
                textsize = Conversions.ToInteger(txtTextSize.Text);
                ResizeSchedulingArea?.Invoke();
            }
            else
            {
                App.ShowMessage("Please enter a valid text Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var frmFind = new FRMSchedulerFind();
            frmFind.ShowDialog();
        }

        private void btnNewJob_Click(object sender, EventArgs e)
        {
            using (var frmNewJob = new FRMNewJob())
            {
                frmNewJob.ShowDialog();
            }

            refreshScheduler?.Invoke();
        }
    }
}