﻿using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using FSM.Entity.ContactAttempts;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class frmEngineerSchedule : Form, ISchedulerForm
    {
        public frmEngineerSchedule()
        {
            EngineerScheduleTimer = new Timer();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public frmEngineerSchedule(MouseEventHandler gridMouseDown, MouseEventHandler gridMouseMove, DragEventHandler gridDragOver, DragEventHandler gridDragDrop, MouseEventHandler gridMouseUp, DataRow Engineer, int textsizes) : base()
        {
            EngineerScheduleTimer = new Timer();

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            dgDay.MouseDown += gridMouseDown;
            dgDay.MouseMove += gridMouseMove;
            dgDaySummary.DragOver += gridDragOver;
            dgDaySummary.DragDrop += gridDragDrop;
            dgDay.MouseUp += gridMouseUp;
            _engineerID = Conversions.ToString(Engineer["EngineerID"]);
            _engineer = Engineer;
            TEXTSIZE = textsizes;
        }

        private MenuItem _btnPrintLsr;

        internal MenuItem btnPrintLsr
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintLsr;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintLsr != null)
                {
                    _btnPrintLsr.Click -= btnPrintLsr_Click;
                }

                _btnPrintLsr = value;
                if (_btnPrintLsr != null)
                {
                    _btnPrintLsr.Click += btnPrintLsr_Click;
                }
            }
        }

        private MenuItem _btnReschedule;

        internal MenuItem btnReschedule
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReschedule;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReschedule != null)
                {
                    _btnReschedule.Click -= btnReschedule_Click;
                }

                _btnReschedule = value;
                if (_btnReschedule != null)
                {
                    _btnReschedule.Click += btnReschedule_Click;
                }
            }
        }

        private MenuItem _btnCreateJob;

        internal MenuItem btnCreateJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreateJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreateJob != null)
                {
                    _btnCreateJob.Click -= btnCreateJob_Click;
                }

                _btnCreateJob = value;
                if (_btnCreateJob != null)
                {
                    _btnCreateJob.Click += btnCreateJob_Click;
                }
            }
        }

        private MenuItem _btnSiteReport;

        internal MenuItem btnSiteReport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSiteReport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSiteReport != null)
                {
                    _btnSiteReport.Click -= btnSiteReport_Click;
                }

                _btnSiteReport = value;
                if (_btnSiteReport != null)
                {
                    _btnSiteReport.Click += btnSiteReport_Click;
                }
            }
        }

        private ToolTip _ttStatus;

        internal ToolTip ttStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ttStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ttStatus != null)
                {
                }

                _ttStatus = value;
                if (_ttStatus != null)
                {
                }
            }
        }

        private PictureBox _pbInfomation;

        internal PictureBox pbInfomation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbInfomation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbInfomation != null)
                {
                    _pbInfomation.Click -= imgEye_Click;
                }

                _pbInfomation = value;
                if (_pbInfomation != null)
                {
                    _pbInfomation.Click += imgEye_Click;
                }
            }
        }

        private MenuItem _btnTextMessage;

        internal MenuItem btnTextMessage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnTextMessage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnTextMessage != null)
                {
                    _btnTextMessage.Click -= btnTextMessage_Click;
                }

                _btnTextMessage = value;
                if (_btnTextMessage != null)
                {
                    _btnTextMessage.Click += btnTextMessage_Click;
                }
            }
        }

        private MenuItem _MenuItem1;

        internal MenuItem MenuItem1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MenuItem1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MenuItem1 != null)
                {
                }

                _MenuItem1 = value;
                if (_MenuItem1 != null)
                {
                }
            }
        }

        private MenuItem _btnServiceLetter;

        internal MenuItem btnServiceLetter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnServiceLetter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnServiceLetter != null)
                {
                    _btnServiceLetter.Click -= btnServiceLetter_Click;
                }

                _btnServiceLetter = value;
                if (_btnServiceLetter != null)
                {
                    _btnServiceLetter.Click += btnServiceLetter_Click;
                }
            }
        }

        private MenuItem _btnSolarInstallation;

        internal MenuItem btnSolarInstallation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSolarInstallation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSolarInstallation != null)
                {
                    _btnSolarInstallation.Click -= btnSolarInstallation_Click;
                }

                _btnSolarInstallation = value;
                if (_btnSolarInstallation != null)
                {
                    _btnSolarInstallation.Click += btnSolarInstallation_Click;
                }
            }
        }

        private MenuItem _btnElectricalAppointment;

        internal MenuItem btnElectricalAppointment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnElectricalAppointment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnElectricalAppointment != null)
                {
                    _btnElectricalAppointment.Click -= btnElectricalAppointment_Click;
                }

                _btnElectricalAppointment = value;
                if (_btnElectricalAppointment != null)
                {
                    _btnElectricalAppointment.Click += btnElectricalAppointment_Click;
                }
            }
        }

        private int TEXTSIZE = 0;

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            try
            {
                detailPopup.Dispose();
                if (disposing)
                {
                    if (!(components is null))
                    {
                        components.Dispose();
                    }
                }

                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private Panel _pnlHeader;

        internal Panel pnlHeader
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlHeader;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlHeader != null)
                {
                }

                _pnlHeader = value;
                if (_pnlHeader != null)
                {
                }
            }
        }

        private Label _lblTitle;

        internal Label lblTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTitle != null)
                {
                }

                _lblTitle = value;
                if (_lblTitle != null)
                {
                }
            }
        }

        private Splitter _splitEngineer;

        internal Splitter splitEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _splitEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_splitEngineer != null)
                {
                    _splitEngineer.SplitterMoved -= splitEngineer_SplitterMoved;
                }

                _splitEngineer = value;
                if (_splitEngineer != null)
                {
                    _splitEngineer.SplitterMoved += splitEngineer_SplitterMoved;
                }
            }
        }

        private DataGrid _dgDaySummary;

        internal DataGrid dgDaySummary
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgDaySummary;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgDaySummary != null)
                {
                    _dgDaySummary.MouseUp -= dgDaySummary_MouseUp;
                }

                _dgDaySummary = value;
                if (_dgDaySummary != null)
                {
                    _dgDaySummary.MouseUp += dgDaySummary_MouseUp;
                }
            }
        }

        private ImageList _imgLstIcons;

        internal ImageList imgLstIcons
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _imgLstIcons;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_imgLstIcons != null)
                {
                }

                _imgLstIcons = value;
                if (_imgLstIcons != null)
                {
                }
            }
        }

        private ContextMenu _mnuVisitAction;

        internal ContextMenu mnuVisitAction
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuVisitAction;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuVisitAction != null)
                {
                    _mnuVisitAction.Popup -= mnuVisitAction_Popup;
                }

                _mnuVisitAction = value;
                if (_mnuVisitAction != null)
                {
                    _mnuVisitAction.Popup += mnuVisitAction_Popup;
                }
            }
        }

        private MenuItem _btnSendText;

        internal MenuItem btnSendText
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSendText;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSendText != null)
                {
                    _btnSendText.Click -= btnSendText_Click;
                }

                _btnSendText = value;
                if (_btnSendText != null)
                {
                    _btnSendText.Click += btnSendText_Click;
                }
            }
        }

        private ContextMenu _mnuDayAction;

        internal ContextMenu mnuDayAction
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuDayAction;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuDayAction != null)
                {
                }

                _mnuDayAction = value;
                if (_mnuDayAction != null)
                {
                }
            }
        }

        private MenuItem _btnExportJobs;

        internal MenuItem btnExportJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExportJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExportJobs != null)
                {
                    _btnExportJobs.Click -= btnExportJobs_Click;
                }

                _btnExportJobs = value;
                if (_btnExportJobs != null)
                {
                    _btnExportJobs.Click += btnExportJobs_Click;
                }
            }
        }

        private PictureBox _picPlanner;

        internal PictureBox picPlanner
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picPlanner;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picPlanner != null)
                {
                    _picPlanner.MouseUp -= picPlanner_MouseUp;
                }

                _picPlanner = value;
                if (_picPlanner != null)
                {
                    _picPlanner.MouseUp += picPlanner_MouseUp;
                }
            }
        }

        private DataGrid _dgDay;

        internal DataGrid dgDay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgDay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgDay != null)
                {
                    _dgDay.DoubleClick -= dgDay_DoubleClick;
                    _dgDay.MouseUp -= dgDay_MouseUp;
                    _dgDay.MouseMove -= dgDay_MouseMove;
                }

                _dgDay = value;
                if (_dgDay != null)
                {
                    _dgDay.DoubleClick += dgDay_DoubleClick;
                    _dgDay.MouseUp += dgDay_MouseUp;
                    _dgDay.MouseMove += dgDay_MouseMove;
                }
            }
        }

        private PictureBox _picRegion;

        internal PictureBox picRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picRegion != null)
                {
                }

                _picRegion = value;
                if (_picRegion != null)
                {
                }
            }
        }

        private PictureBox _picPostalRegions;

        internal PictureBox picPostalRegions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picPostalRegions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picPostalRegions != null)
                {
                }

                _picPostalRegions = value;
                if (_picPostalRegions != null)
                {
                }
            }
        }

        private PictureBox _picVan;

        internal PictureBox picVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picVan != null)
                {
                }

                _picVan = value;
                if (_picVan != null)
                {
                }
            }
        }

        private PictureBox _picQuestion;

        internal PictureBox picQuestion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picQuestion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picQuestion != null)
                {
                }

                _picQuestion = value;
                if (_picQuestion != null)
                {
                }
            }
        }

        private PictureBox _picSpanner;

        internal PictureBox picSpanner
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picSpanner;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picSpanner != null)
                {
                }

                _picSpanner = value;
                if (_picSpanner != null)
                {
                }
            }
        }

        private PictureBox _pbRed;

        internal PictureBox pbRed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbRed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbRed != null)
                {
                }

                _pbRed = value;
                if (_pbRed != null)
                {
                }
            }
        }

        private PictureBox _pbGreen;

        internal PictureBox pbGreen
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbGreen;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbGreen != null)
                {
                }

                _pbGreen = value;
                if (_pbGreen != null)
                {
                }
            }
        }

        private PictureBox _pbClose;

        internal PictureBox pbClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbClose != null)
                {
                    _pbClose.Click -= PictureBox1_Click;
                }

                _pbClose = value;
                if (_pbClose != null)
                {
                    _pbClose.Click += PictureBox1_Click;
                }
            }
        }

        private PictureBox _picLevels;

        internal PictureBox picLevels
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picLevels;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picLevels != null)
                {
                }

                _picLevels = value;
                if (_picLevels != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEngineerSchedule));
            _pnlHeader = new Panel();
            _pbClose = new PictureBox();
            _pbClose.Click += new EventHandler(PictureBox1_Click);
            _pbGreen = new PictureBox();
            _pbRed = new PictureBox();
            _picVan = new PictureBox();
            _picQuestion = new PictureBox();
            _picSpanner = new PictureBox();
            _picLevels = new PictureBox();
            _picPostalRegions = new PictureBox();
            _picRegion = new PictureBox();
            _lblTitle = new Label();
            _pbInfomation = new PictureBox();
            _pbInfomation.Click += new EventHandler(imgEye_Click);
            _dgDaySummary = new DataGrid();
            _dgDaySummary.MouseUp += new MouseEventHandler(dgDaySummary_MouseUp);
            _mnuDayAction = new ContextMenu();
            _btnCreateJob = new MenuItem();
            _btnCreateJob.Click += new EventHandler(btnCreateJob_Click);
            _btnExportJobs = new MenuItem();
            _btnExportJobs.Click += new EventHandler(btnExportJobs_Click);
            _splitEngineer = new Splitter();
            _splitEngineer.SplitterMoved += new SplitterEventHandler(splitEngineer_SplitterMoved);
            _mnuVisitAction = new ContextMenu();
            _mnuVisitAction.Popup += new EventHandler(mnuVisitAction_Popup);
            _btnSendText = new MenuItem();
            _btnSendText.Click += new EventHandler(btnSendText_Click);
            _btnReschedule = new MenuItem();
            _btnReschedule.Click += new EventHandler(btnReschedule_Click);
            _btnTextMessage = new MenuItem();
            _btnTextMessage.Click += new EventHandler(btnTextMessage_Click);
            _MenuItem1 = new MenuItem();
            _btnSiteReport = new MenuItem();
            _btnSiteReport.Click += new EventHandler(btnSiteReport_Click);
            _btnPrintLsr = new MenuItem();
            _btnPrintLsr.Click += new EventHandler(btnPrintLsr_Click);
            _btnServiceLetter = new MenuItem();
            _btnServiceLetter.Click += new EventHandler(btnServiceLetter_Click);
            _btnSolarInstallation = new MenuItem();
            _btnSolarInstallation.Click += new EventHandler(btnSolarInstallation_Click);
            _btnElectricalAppointment = new MenuItem();
            _btnElectricalAppointment.Click += new EventHandler(btnElectricalAppointment_Click);
            _imgLstIcons = new ImageList(components);
            _dgDay = new DataGrid();
            _dgDay.DoubleClick += new EventHandler(dgDay_DoubleClick);
            _dgDay.MouseUp += new MouseEventHandler(dgDay_MouseUp);
            _dgDay.MouseMove += new MouseEventHandler(dgDay_MouseMove);
            _picPlanner = new PictureBox();
            _picPlanner.MouseUp += new MouseEventHandler(picPlanner_MouseUp);
            _ttStatus = new ToolTip(components);
            _pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_pbClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_pbGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_pbRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picVan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picQuestion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picSpanner).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picLevels).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picPostalRegions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picRegion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_pbInfomation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgDaySummary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgDay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picPlanner).BeginInit();
            SuspendLayout();
            //
            // pnlHeader
            //
            _pnlHeader.BackColor = Color.SteelBlue;
            _pnlHeader.Controls.Add(_pbClose);
            _pnlHeader.Controls.Add(_pbGreen);
            _pnlHeader.Controls.Add(_pbRed);
            _pnlHeader.Controls.Add(_picVan);
            _pnlHeader.Controls.Add(_picQuestion);
            _pnlHeader.Controls.Add(_picSpanner);
            _pnlHeader.Controls.Add(_picLevels);
            _pnlHeader.Controls.Add(_picPostalRegions);
            _pnlHeader.Controls.Add(_picRegion);
            _pnlHeader.Controls.Add(_lblTitle);
            _pnlHeader.Controls.Add(_pbInfomation);
            _pnlHeader.Dock = DockStyle.Top;
            _pnlHeader.Location = new Point(0, 0);
            _pnlHeader.Name = "pnlHeader";
            _pnlHeader.Size = new Size(432, 18);
            _pnlHeader.TabIndex = 1;
            //
            // pbClose
            //
            _pbClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _pbClose.BackColor = Color.Transparent;
            _pbClose.Cursor = Cursors.Hand;
            _pbClose.Image = My.Resources.Resources.delete;
            _pbClose.Location = new Point(410, 1);
            _pbClose.Name = "pbClose";
            _pbClose.Size = new Size(19, 17);
            _pbClose.SizeMode = PictureBoxSizeMode.StretchImage;
            _pbClose.TabIndex = 9;
            _pbClose.TabStop = false;
            //
            // pbGreen
            //
            _pbGreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _pbGreen.BackColor = Color.Transparent;
            _pbGreen.Image = My.Resources.Resources.green_light;
            _pbGreen.Location = new Point(358, 1);
            _pbGreen.Name = "pbGreen";
            _pbGreen.Size = new Size(19, 17);
            _pbGreen.SizeMode = PictureBoxSizeMode.StretchImage;
            _pbGreen.TabIndex = 8;
            _pbGreen.TabStop = false;
            _pbGreen.Visible = false;
            //
            // pbRed
            //
            _pbRed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _pbRed.BackColor = Color.Transparent;
            _pbRed.Image = My.Resources.Resources.red_light;
            _pbRed.Location = new Point(358, 1);
            _pbRed.Name = "pbRed";
            _pbRed.Size = new Size(19, 17);
            _pbRed.SizeMode = PictureBoxSizeMode.StretchImage;
            _pbRed.TabIndex = 7;
            _pbRed.TabStop = false;
            _pbRed.Visible = false;
            //
            // picVan
            //
            _picVan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _picVan.BackColor = Color.Transparent;
            _picVan.Image = My.Resources.Resources.Van;
            _picVan.Location = new Point(383, 1);
            _picVan.Name = "picVan";
            _picVan.Size = new Size(19, 17);
            _picVan.SizeMode = PictureBoxSizeMode.StretchImage;
            _picVan.TabIndex = 6;
            _picVan.TabStop = false;
            _picVan.Visible = false;
            //
            // picQuestion
            //
            _picQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _picQuestion.BackColor = Color.Transparent;
            _picQuestion.Image = My.Resources.Resources.Question_mark_icon;
            _picQuestion.Location = new Point(383, 0);
            _picQuestion.Name = "picQuestion";
            _picQuestion.Size = new Size(15, 18);
            _picQuestion.SizeMode = PictureBoxSizeMode.StretchImage;
            _picQuestion.TabIndex = 5;
            _picQuestion.TabStop = false;
            _picQuestion.Visible = false;
            //
            // picSpanner
            //
            _picSpanner.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _picSpanner.BackColor = Color.Transparent;
            _picSpanner.Image = My.Resources.Resources.imagesWITCGZO5;
            _picSpanner.Location = new Point(383, 1);
            _picSpanner.Name = "picSpanner";
            _picSpanner.Size = new Size(16, 16);
            _picSpanner.SizeMode = PictureBoxSizeMode.StretchImage;
            _picSpanner.TabIndex = 4;
            _picSpanner.TabStop = false;
            _picSpanner.Visible = false;
            //
            // picLevels
            //
            _picLevels.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _picLevels.BackColor = Color.Transparent;
            _picLevels.Image = (Image)resources.GetObject("picLevels.Image");
            _picLevels.Location = new Point(306, 1);
            _picLevels.Name = "picLevels";
            _picLevels.Size = new Size(16, 16);
            _picLevels.SizeMode = PictureBoxSizeMode.StretchImage;
            _picLevels.TabIndex = 3;
            _picLevels.TabStop = false;
            _picLevels.Visible = false;
            //
            // picPostalRegions
            //
            _picPostalRegions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _picPostalRegions.BackColor = Color.Transparent;
            _picPostalRegions.Image = (Image)resources.GetObject("picPostalRegions.Image");
            _picPostalRegions.Location = new Point(286, 2);
            _picPostalRegions.Name = "picPostalRegions";
            _picPostalRegions.Size = new Size(16, 16);
            _picPostalRegions.SizeMode = PictureBoxSizeMode.StretchImage;
            _picPostalRegions.TabIndex = 2;
            _picPostalRegions.TabStop = false;
            _picPostalRegions.Visible = false;
            //
            // picRegion
            //
            _picRegion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _picRegion.BackColor = Color.Transparent;
            _picRegion.Image = (Image)resources.GetObject("picRegion.Image");
            _picRegion.Location = new Point(328, 0);
            _picRegion.Name = "picRegion";
            _picRegion.Size = new Size(16, 16);
            _picRegion.SizeMode = PictureBoxSizeMode.StretchImage;
            _picRegion.TabIndex = 1;
            _picRegion.TabStop = false;
            _picRegion.Visible = false;
            //
            // lblTitle
            //
            _lblTitle.AutoSize = true;
            _lblTitle.Dock = DockStyle.Left;
            _lblTitle.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblTitle.ForeColor = Color.White;
            _lblTitle.Location = new Point(19, 0);
            _lblTitle.Name = "lblTitle";
            _lblTitle.Size = new Size(142, 16);
            _lblTitle.TabIndex = 0;
            _lblTitle.Text = "Engineer Schedule";
            _lblTitle.TextAlign = ContentAlignment.MiddleRight;
            //
            // pbInfomation
            //
            _pbInfomation.BackColor = Color.Transparent;
            _pbInfomation.Cursor = Cursors.Hand;
            _pbInfomation.Dock = DockStyle.Left;
            _pbInfomation.Image = (Image)resources.GetObject("pbInfomation.Image");
            _pbInfomation.Location = new Point(0, 0);
            _pbInfomation.Name = "pbInfomation";
            _pbInfomation.Size = new Size(19, 18);
            _pbInfomation.SizeMode = PictureBoxSizeMode.StretchImage;
            _pbInfomation.TabIndex = 10;
            _pbInfomation.TabStop = false;
            _ttStatus.SetToolTip(_pbInfomation, "View Engineer Information");
            //
            // dgDaySummary
            //
            _dgDaySummary.AllowDrop = true;
            _dgDaySummary.ContextMenu = _mnuDayAction;
            _dgDaySummary.DataMember = "";
            _dgDaySummary.Dock = DockStyle.Left;
            _dgDaySummary.HeaderForeColor = SystemColors.ControlText;
            _dgDaySummary.Location = new Point(0, 18);
            _dgDaySummary.Name = "dgDaySummary";
            _dgDaySummary.Size = new Size(63, 103);
            _dgDaySummary.TabIndex = 2;
            //
            // mnuDayAction
            //
            _mnuDayAction.MenuItems.AddRange(new MenuItem[] { _btnCreateJob, _btnExportJobs });
            //
            // btnCreateJob
            //
            _btnCreateJob.Index = 0;
            _btnCreateJob.Text = "Create Job";
            //
            // btnExportJobs
            //
            _btnExportJobs.Index = 1;
            _btnExportJobs.Text = "&Export Jobs";
            _btnExportJobs.Visible = false;
            //
            // splitEngineer
            //
            _splitEngineer.Location = new Point(63, 18);
            _splitEngineer.Name = "splitEngineer";
            _splitEngineer.Size = new Size(3, 103);
            _splitEngineer.TabIndex = 3;
            _splitEngineer.TabStop = false;
            //
            // mnuVisitAction
            //
            _mnuVisitAction.MenuItems.AddRange(new MenuItem[] { _btnSendText, _btnReschedule, _btnTextMessage, _MenuItem1 });
            //
            // btnSendText
            //
            _btnSendText.Index = 0;
            _btnSendText.Text = "&Send Text";
            _btnSendText.Visible = false;
            //
            // btnReschedule
            //
            _btnReschedule.Index = 1;
            _btnReschedule.Text = "Reschedule";
            _btnReschedule.Visible = false;
            //
            // btnTextMessage
            //
            _btnTextMessage.Index = 2;
            _btnTextMessage.Text = "Include In Message Run";
            //
            // MenuItem1
            //
            _MenuItem1.Index = 3;
            _MenuItem1.MenuItems.AddRange(new MenuItem[] { _btnSiteReport, _btnPrintLsr, _btnServiceLetter, _btnSolarInstallation, _btnElectricalAppointment });
            _MenuItem1.Text = "Print";
            //
            // btnSiteReport
            //
            _btnSiteReport.Index = 0;
            _btnSiteReport.Text = "Site Report";
            //
            // btnPrintLsr
            //
            _btnPrintLsr.Index = 1;
            _btnPrintLsr.Text = "LSR";
            _btnPrintLsr.Visible = false;
            //
            // btnServiceLetter
            //
            _btnServiceLetter.Index = 2;
            _btnServiceLetter.Text = "Service Letter";
            //
            // btnSolarInstallation
            //
            _btnSolarInstallation.Index = 3;
            _btnSolarInstallation.Text = "Solar Installation";
            //
            // btnElectricalAppointment
            //
            _btnElectricalAppointment.Index = 4;
            _btnElectricalAppointment.Text = "Electrical Appointment";
            //
            // imgLstIcons
            //
            _imgLstIcons.ColorDepth = ColorDepth.Depth24Bit;
            _imgLstIcons.ImageSize = new Size(16, 16);
            _imgLstIcons.TransparentColor = Color.Transparent;
            //
            // dgDay
            //
            _dgDay.CaptionFont = new Font("Verdana", 6.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _dgDay.ContextMenu = _mnuVisitAction;
            _dgDay.DataMember = "";
            _dgDay.Dock = DockStyle.Fill;
            _dgDay.Font = new Font("Verdana", 5.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dgDay.HeaderFont = new Font("Verdana", 6.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _dgDay.HeaderForeColor = SystemColors.ControlText;
            _dgDay.Location = new Point(66, 18);
            _dgDay.Name = "dgDay";
            _dgDay.PreferredRowHeight = 12;
            _dgDay.Size = new Size(366, 79);
            _dgDay.TabIndex = 6;
            //
            // picPlanner
            //
            _picPlanner.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            _picPlanner.BorderStyle = BorderStyle.Fixed3D;
            _picPlanner.Dock = DockStyle.Bottom;
            _picPlanner.Location = new Point(66, 97);
            _picPlanner.Name = "picPlanner";
            _picPlanner.Size = new Size(366, 24);
            _picPlanner.TabIndex = 5;
            _picPlanner.TabStop = false;
            //
            // frmEngineerSchedule
            //
            ClientSize = new Size(432, 121);
            ControlBox = false;
            Controls.Add(_dgDay);
            Controls.Add(_picPlanner);
            Controls.Add(_splitEngineer);
            Controls.Add(_dgDaySummary);
            Controls.Add(_pnlHeader);
            Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "frmEngineerSchedule";
            Opacity = 0D;
            StartPosition = FormStartPosition.Manual;
            _pnlHeader.ResumeLayout(false);
            _pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_pbClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)_pbGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)_pbRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picVan).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picQuestion).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picSpanner).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picLevels).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picPostalRegions).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picRegion).EndInit();
            ((System.ComponentModel.ISupportInitialize)_pbInfomation).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgDaySummary).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgDay).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picPlanner).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public class StatusDependentDataGridCell : DataGridLabelColumn
        {
            private bool _Selected = true;

            private bool Selected
            {
                get
                {
                    return _Selected;
                }

                set
                {
                    _Selected = value;
                }
            }

            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                int Status = 0;
                string text = string.Empty;
                {
                    var withBlock = (DataRow)source.List[rowNum];
                    Status = Conversions.ToInteger(withBlock["VisitStatusID"]);
                    text = Helper.MakeStringValid(withBlock[MappingName]);
                }

                var greenBrush = new SolidBrush(Color.LightGreen);
                var blueBrush = new SolidBrush(Color.Blue);
                if (Status == Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule))
                {
                    var rectRed = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
                    if (TextBox.Focus())
                    {
                        g.FillRectangle(blueBrush, rectRed);
                    }
                    else
                    {
                        g.FillRectangle(greenBrush, rectRed);

                        // Selected = False
                    }

                    g.DrawString(text, TextBox.Font, foreBrush, bounds.X + 2, bounds.Y + 2);
                }
            }

            protected override void ConcedeFocus()
            {
                Selected = false;
            }
        }

        public class visitStatusBar : DataGridLabelColumn
        {
            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                Brush brush;
                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(((DataRow)source.List[rowNum])["VisitStatusID"], Conversions.ToInteger(Enums.VisitStatus.Scheduled), false) & !Operators.ConditionalCompareObjectEqual(((DataRow)source.List[rowNum])["VisitStatusID"], Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule), false)))
                {
                    brush = new SolidBrush(Color.LightGreen);
                }
                else
                {
                    brush = backBrush;
                }

                g.FillRectangle(brush, bounds);
            }
        }

        public class unavailableBar : DataGridLabelColumn
        {
            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                var brush = Brushes.White;
                var strBrush = Brushes.MidnightBlue;
                string str = "";

                var switchExpr = source.List[rowNum].row.item("AbsenceColumn");
                switch (switchExpr)
                {
                    case var @case when @case == 0:
                        {
                            brush = Brushes.White;
                            str = "";
                            break;
                        }

                    case var case1 when case1 == 1:
                        {
                            brush = Brushes.Pink;
                            str = "HB";
                            break;
                        }

                    case var case2 when case2 == 2:
                        {
                            brush = Brushes.Red;
                            str = "SI";
                            break;
                        }

                    case var case3 when case3 == 3:
                        {
                            brush = Brushes.White;
                            str = "OT";
                            break;
                        }

                    case var case4 when case4 == 4:
                        {
                            brush = Brushes.Blue;
                            str = "UP";
                            strBrush = Brushes.White;
                            break;
                        }

                    case var case5 when case5 == 5:
                        {
                            brush = Brushes.Orange;
                            str = "SE";
                            break;
                        }

                    case var case6 when case6 == 6:
                        {
                            brush = Brushes.Black;
                            str = "TR";
                            strBrush = Brushes.White;
                            break;
                        }

                    case var case7 when case7 == 7:
                        {
                            brush = Brushes.Green;
                            str = "AP";
                            strBrush = Brushes.White;
                            break;
                        }

                    case var case8 when case8 == 8:
                        {
                            brush = Brushes.Purple;
                            str = "HD";
                            strBrush = Brushes.White;
                            break;
                        }

                    case var case9 when case9 == 9:
                        {
                            brush = Brushes.Yellow;
                            str = "BH";
                            break;
                        }

                    case var case10 when case10 == 10:
                        {
                            brush = Brushes.Orange;
                            str = "CO";
                            break;
                        }

                    default:
                        {
                            brush = Brushes.White;
                            str = "";
                            break;
                        }
                }

                var rect = bounds;
                g.FillRectangle(brush, rect);
                g.DrawString(str, DataGridTableStyle.DataGrid.Font, strBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string _currentDays;
        private string _startDate;
        private string _endDate;
        private Timer _EngineerScheduleTimer;

        public Timer EngineerScheduleTimer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _EngineerScheduleTimer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _EngineerScheduleTimer = value;
            }
        }

        // Dataset to display to user - Dates, snapshot work load
        private DataSet _dsEngineerSchedule = new DataSet();

        public DateTime CurrentDate;
        public DateTime LastHeartBeat;
        public int LockedVisitId;
        public DateTime HeartLastCheck;

        // These are the tests to be carried out on a visit row
        private ScheduleTest[] _tests = new ScheduleTest[] { new RegionCheck(), new PostcodeRegionCheck(), new LevelsCheck(), new AbsenceOverlapCheck(), new SOROverloadCheck(), new DueDateCheck(), new PriorityCheck() };

        private DataTable _dtday = new DataTable();

        private DataTable CurrentDayDataTable
        {
            get
            {
                return _dtday;
            }

            set
            {
                _dtday = value;
            }
        }

        private DataRow SelectedDataRow
        {
            get
            {
                if (!(dgDay.CurrentRowIndex == -1))
                {
                    return Helper.GetDataRowFromDataSource(dgDay.DataSource, dgDay.CurrentRowIndex);
                }
                else
                {
                    return null;
                }
            }
        }

        private string _engineerID;

        public string EngineerID
        {
            get
            {
                return _engineerID;
            }

            set
            {
                _engineerID = value;
            }
        }

        private DataRow _engineer;

        public DataRow Engineer
        {
            get
            {
                return _engineer;
            }

            set
            {
                _engineer = value;
            }
        }

        private frmDetailsPopup _detailPopup;

        public frmDetailsPopup detailPopup
        {
            get
            {
                return _detailPopup;
            }

            set
            {
                _detailPopup = value;
            }
        }

        private bool _opening;

        public bool opening
        {
            get
            {
                return _opening;
            }

            set
            {
                _opening = value;
            }
        }

        private Entity.EngineerVisits.EngineerVisit _engineerVisit;

        public Entity.EngineerVisits.EngineerVisit EngineerVisit
        {
            get
            {
                return _engineerVisit;
            }

            set
            {
                _engineerVisit = value;
            }
        }

        public bool IsFormDisposed
        {
            get
            {
                return IsDisposed;
            }
        }

        public PictureBox ThePlanner
        {
            get
            {
                return picPlanner;
            }
        }

        public IntPtr TheHandle
        {
            get
            {
                return Handle;
            }
        }

        public string MyName
        {
            get
            {
                return "frmEngineerSchedule";
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void setUpDayDg()
        {
            ModScheduler.SetUpSchedulerDataGrid(dgDay, false);
            var tStyle = dgDay.TableStyles[0];
            double diff = 0.9;
            var switchExpr = TEXTSIZE;
            switch (switchExpr)
            {
                case 7:
                    {
                        diff = 1;
                        break;
                    }

                case 8:
                    {
                        diff = 1.1;
                        break;
                    }

                case 9:
                    {
                        diff = 1.2;
                        break;
                    }

                case 10:
                    {
                        diff = 1.25;
                        break;
                    }

                case 11:
                    {
                        diff = 1.3;
                        break;
                    }

                case 12:
                    {
                        diff = 1.35;
                        break;
                    }
            }

            tStyle.DataGrid.Font = new Font("Verdana", TEXTSIZE, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            tStyle.DataGrid.HeaderFont = new Font("Verdana", TEXTSIZE, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            var jobStatus = new DataGridSchedulerColumn();
            jobStatus.Format = "";
            jobStatus.FormatInfo = null;
            jobStatus.HeaderText = "";
            jobStatus.MappingName = "JobStatus";
            jobStatus.ReadOnly = true;
            jobStatus.Width = Conversions.ToInteger(15 * diff);
            jobStatus.NullText = "";
            tStyle.GridColumnStyles.Add(jobStatus);
            var JobID = new DataGridSchedulerJobColumn();
            JobID.Format = "";
            JobID.FormatInfo = null;
            JobID.HeaderText = "Job No";
            JobID.MappingName = "JobNumber";
            JobID.ReadOnly = true;
            JobID.Width = Conversions.ToInteger(60 * diff);
            JobID.NullText = "";
            tStyle.GridColumnStyles.Add(JobID);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Address 1";
            Site.MappingName = "Address1";
            Site.ReadOnly = true;
            Site.Width = Conversions.ToInteger(125 * diff);
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            var PostCode = new DataGridLabelColumn();
            PostCode.Format = "";
            PostCode.FormatInfo = null;
            PostCode.HeaderText = "Postcode";
            PostCode.MappingName = "PostCode";
            PostCode.ReadOnly = true;
            PostCode.Width = Conversions.ToInteger(65 * diff);
            PostCode.NullText = "";
            tStyle.GridColumnStyles.Add(PostCode);
            var Items = new DataGridLabelColumn();
            Items.Format = "";
            Items.FormatInfo = null;
            Items.HeaderText = "Job Summary";
            Items.MappingName = "JobItems";
            Items.ReadOnly = true;
            Items.Width = Conversions.ToInteger(100 * diff);
            Items.NullText = "";
            tStyle.GridColumnStyles.Add(Items);
            var Notes = new DataGridLabelColumn();
            Notes.Format = "";
            Notes.FormatInfo = null;
            Notes.HeaderText = "Notes";
            Notes.MappingName = "NotesToEngineer";
            Notes.ReadOnly = true;
            Notes.Width = Conversions.ToInteger(325 * diff);
            Notes.NullText = "";
            tStyle.GridColumnStyles.Add(Notes);
            var startTime = new DataGridLabelColumn();
            startTime.Format = "HH:mm";
            startTime.FormatInfo = null;
            startTime.HeaderText = "Start";
            startTime.MappingName = "StartDateTime";
            startTime.ReadOnly = true;
            startTime.Width = Conversions.ToInteger(40 * diff);
            startTime.NullText = "";
            tStyle.GridColumnStyles.Add(startTime);
            var endTime = new DataGridLabelColumn();
            endTime.Format = "HH:mm";
            endTime.FormatInfo = null;
            endTime.HeaderText = "End";
            endTime.MappingName = "EndDateTime";
            endTime.ReadOnly = true;
            endTime.Width = Conversions.ToInteger(40 * diff);
            endTime.NullText = "";
            tStyle.GridColumnStyles.Add(endTime);
            var VisitStatus = new DataGridLabelColumn();
            VisitStatus.Format = "";
            VisitStatus.FormatInfo = null;
            VisitStatus.HeaderText = "Status";
            VisitStatus.MappingName = "VisitStatus";
            VisitStatus.ReadOnly = true;
            VisitStatus.Width = Conversions.ToInteger(80 * diff);
            VisitStatus.NullText = "";
            tStyle.GridColumnStyles.Add(VisitStatus);
            var CustomerName = new DataGridLabelColumn();
            CustomerName.Format = "";
            CustomerName.FormatInfo = null;
            CustomerName.HeaderText = "Customer";
            CustomerName.MappingName = "customername";
            CustomerName.ReadOnly = true;
            CustomerName.Width = Conversions.ToInteger(75 * diff);
            CustomerName.NullText = "";
            tStyle.GridColumnStyles.Add(CustomerName);
            var JobType = new DataGridJobTypeColumn();
            JobType.Format = "";
            JobType.FormatInfo = null;
            JobType.HeaderText = "Type";
            JobType.MappingName = "JobType";
            JobType.ReadOnly = true;
            JobType.Width = Conversions.ToInteger(150 * diff);
            JobType.NullText = "";
            tStyle.GridColumnStyles.Add(JobType);
            var SummedSOR = new DataGridLabelColumn();
            SummedSOR.Format = "#";
            SummedSOR.FormatInfo = null;
            SummedSOR.HeaderText = "SOR";
            SummedSOR.MappingName = "SummedSOR";
            SummedSOR.ReadOnly = true;
            SummedSOR.Width = Conversions.ToInteger(50 * diff);
            SummedSOR.NullText = "";
            tStyle.GridColumnStyles.Add(SummedSOR);
            var EstimatedVisitDate = new DataGridLabelColumn();
            EstimatedVisitDate.Format = "dd/MM/yyyy";
            EstimatedVisitDate.FormatInfo = null;
            EstimatedVisitDate.HeaderText = "Est Date";
            EstimatedVisitDate.MappingName = "EstimatedVisitDate";
            EstimatedVisitDate.ReadOnly = true;
            EstimatedVisitDate.Width = Conversions.ToInteger(60 * diff);
            EstimatedVisitDate.NullText = "N/A";
            tStyle.GridColumnStyles.Add(EstimatedVisitDate);
            tStyle.MappingName = "";
        }

        private void setUpSummaryDg()
        {
            ModScheduler.SetUpSchedulerDataGrid(dgDaySummary, false);
            double diff = 0.9;
            var switchExpr = TEXTSIZE;
            switch (switchExpr)
            {
                case 7:
                    {
                        diff = 1;
                        break;
                    }

                case 8:
                    {
                        diff = 1.1;
                        break;
                    }

                case 9:
                    {
                        diff = 1.2;
                        break;
                    }

                case 10:
                    {
                        diff = 1.3;
                        break;
                    }

                case 11:
                    {
                        diff = 1.5;
                        break;
                    }

                case 12:
                    {
                        diff = 1.7;
                        break;
                    }
            }

            var tsSummary = dgDaySummary.TableStyles[0];
            tsSummary.DataGrid.Font = new Font("Verdana", TEXTSIZE, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            tsSummary.DataGrid.HeaderFont = new Font("Verdana", TEXTSIZE, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            var absence = new unavailableBar();
            absence.Format = "";
            absence.FormatInfo = null;
            absence.HeaderText = "";
            absence.MappingName = "AbsenceColumn";
            absence.ReadOnly = true;
            absence.Width = Conversions.ToInteger(22 * diff);
            absence.NullText = "";
            tsSummary.GridColumnStyles.Add(absence);
            var csDayDate = new DataGridLabelColumn();
            csDayDate.MappingName = "dayDate";
            csDayDate.HeaderText = "Date";
            csDayDate.ReadOnly = true;
            csDayDate.Width = Conversions.ToInteger(70 * diff);
            tsSummary.GridColumnStyles.Add(csDayDate);
            var csDay = new DataGridLabelColumn();
            csDay.MappingName = "day";
            csDay.HeaderText = "Day";
            csDay.ReadOnly = true;
            csDay.Width = Conversions.ToInteger(30 * diff);
            tsSummary.GridColumnStyles.Add(csDay);
            var csWorkCount = new DataGridLabelColumn();
            csWorkCount.MappingName = "workCount";
            csWorkCount.HeaderText = "Work";
            csWorkCount.ReadOnly = true;
            csWorkCount.Alignment = HorizontalAlignment.Center;
            csWorkCount.Width = Conversions.ToInteger(30 * diff);
            tsSummary.GridColumnStyles.Add(csWorkCount);
            var csSummedSOR = new DataGridLabelColumn();
            csSummedSOR.Format = "#";
            csSummedSOR.FormatInfo = null;
            csSummedSOR.HeaderText = "SOR";
            csSummedSOR.MappingName = "SummedSOR";
            csSummedSOR.ReadOnly = true;
            csSummedSOR.Width = Conversions.ToInteger(30 * diff);
            csSummedSOR.NullText = "";
            tsSummary.GridColumnStyles.Add(csSummedSOR);
            tsSummary.MappingName = "ScheduleSummary";
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void frmEngineerSchedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_refreshAsyncResult is object)
            {
                while (_refreshAsyncResult.IsCompleted == false)
                {
                    if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures))
                        System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                }
            }

            if (_refreshSummary is object)
            {
                while (_refreshSummary.IsCompleted == false)
                {
                    if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures))
                        System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
        }

        private void frmEngineerSchedule_Load(object sender, EventArgs e)
        {
            setUpDayDg();
            setUpSummaryDg();
            detailPopup = new frmDetailsPopup(this);
            SetupHeartBeat();
            DisplayLastLocation();
            EngineerScheduleTimer.Interval = 300000;
            EngineerScheduleTimer.Start();
        }

        private void frmEngineerSchedule_Resize(object sender, EventArgs e)
        {
            double diff = 0.15; // 6
            var switchExpr = TEXTSIZE;
            switch (switchExpr)
            {
                case 7:
                    {
                        diff = 0.16;
                        break;
                    }

                case 8:
                    {
                        diff = 0.17;
                        break;
                    }

                case 9:
                    {
                        diff = 0.18;
                        break;
                    }

                case 10:
                    {
                        diff = 0.19;
                        break;
                    }

                case 11:
                    {
                        diff = 0.22;
                        break;
                    }

                case 12:
                    {
                        diff = 0.25;
                        break;
                    }
            }

            dgDaySummary.Width = (int)(Width * diff);
        }

        private void dgDaySummary_MouseUp(object sender, MouseEventArgs e)
        {
            var hitTest = dgDaySummary.HitTest(e.X, e.Y);
            if (hitTest.Type == DataGrid.HitTestType.Cell)
            {
                dgDaySummary.CurrentRowIndex = hitTest.Row;
                ShowDay(SelectedDay());
            }
        }

        private void dgDay_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("Please select a visit to open the job", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var oSite = App.DB.Sites.Get(SelectedDataRow["SiteID"]);
            if (oSite is null || !oSite.Exists)
            {
                App.ShowMessage("Unable to access site!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + oSite.RegionID).Length < 1)
            {
                string msg = "You do not have the necessary security permissions." + Constants.vbCrLf + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }

            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedDataRow["JobID"], SelectedDataRow["SiteID"], this, null, SelectedDataRow["EngineerVisitID"] });
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Reset()
        {
            _dsEngineerSchedule = new DataSet();
            try
            {
                dgDay.DataSource = null;
                dgDaySummary.DataSource = null;
            }
            catch
            {
            }
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public delegate Hashtable refreshAcceptanceDelegate();

        private DataRow _testRow;
        private IAsyncResult _refreshAsyncResult;

        public void RefreshAcceptance(DataRow testRow)
        {
            _testRow = testRow;
            var acceptance = new refreshAcceptanceDelegate(BeginRefreshAcceptance);
            var acceptanceComplete = new AsyncCallback(refreshAccptanceComplete);
            _refreshAsyncResult = acceptance.BeginInvoke(acceptanceComplete, null);
        }

        public Hashtable BeginRefreshAcceptance()
        {
            try
            {
                if (_testRow is object)
                {
                    var results = new Hashtable();
                    foreach (ScheduleTest test in _tests)
                    {
                        if (_testRow is object)
                        {
                            var testResult = test.Test(_testRow, Conversions.ToInteger(EngineerID), CurrentDate);
                            results.Add(test, testResult);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    return results;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

            // GC.Collect()
            // GC.WaitForPendingFinalizers()

            // GC.Collect()
            // GC.WaitForPendingFinalizers()
        }

        public void refreshAccptanceComplete(IAsyncResult ar)
        {
            refreshAcceptanceDelegate o_MyDelegate = (refreshAcceptanceDelegate)((AsyncResult)ar).AsyncDelegate;
            var results = o_MyDelegate.EndInvoke(ar);
            if (!IsFormDisposed)
            {
                try
                {
                    Invoke(new resultsDisplayDelegate(SetResultDisplay), results);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private delegate void resultsDisplayDelegate(Hashtable results);

        public void SetResultDisplay(Hashtable results)
        {
            try
            {
                _testRow = null;
                if (results is object)
                {
                    bool pass = true;
                    foreach (ScheduleTest test in _tests)
                    {
                        ScheduleTest.TestResult testresult = (ScheduleTest.TestResult)results[test];
                        if (testresult.pass == false)
                        {
                            pass = false;
                        }

                        var switchExpr = test.GetType().Name.ToLower();
                        switch (switchExpr)
                        {
                            case var @case when @case == "RegionCheck".ToLower():
                                {
                                    picRegion.Visible = testresult.pass;
                                    break;
                                }

                            case var case1 when case1 == "PostcodeRegionCheck".ToLower():
                                {
                                    picPostalRegions.Visible = testresult.pass;
                                    break;
                                }

                            case var case2 when case2 == "LevelsCheck".ToLower():
                                {
                                    picLevels.Visible = testresult.pass;
                                    break;
                                }
                        }
                    }

                    if (pass == true)
                    {
                        pnlHeader.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        pnlHeader.BackColor = Color.Salmon;
                    }
                }
                else
                {
                    ResetHeader();
                }
            }
            catch (Exception ex)
            {
            }

            Application.DoEvents();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        public bool TestAcceptance(DataRow testRow)
        {
            bool pass = true;
            foreach (ScheduleTest test in _tests)
            {
                var testResult = test.Test(testRow, Conversions.ToInteger(EngineerID), CurrentDate);
                if (testResult.pass == false)
                {
                    pass = false;
                }

                var switchExpr = test.GetType().Name.ToLower();
                switch (switchExpr)
                {
                    case var @case when @case == "RegionCheck".ToLower():
                        {
                            picRegion.Visible = testResult.pass;
                            break;
                        }

                    case var case1 when case1 == "PostcodeRegionCheck".ToLower():
                        {
                            picPostalRegions.Visible = testResult.pass;
                            break;
                        }

                    case var case2 when case2 == "LevelsCheck".ToLower():
                        {
                            picLevels.Visible = testResult.pass;
                            break;
                        }
                }
            }

            if (pass == true)
            {
                pnlHeader.BackColor = Color.LightGreen;
                return true;
            }
            else
            {
                pnlHeader.BackColor = Color.Salmon;
                return false;
            }
        }

        public bool GetAcceptance(DataRow testRow, bool isCopy)
        {
            bool pass = true;
            bool cancelSchedule = false;
            bool passwordPrompt = false;
            var failureString = new ArrayList();
            foreach (ScheduleTest test in _tests)
            {
                var testResult = test.Test(testRow, Conversions.ToInteger(EngineerID), CurrentDate);
                if (testResult.pass == false)
                {
                    if (testResult.failMessages.Count == 0)
                    {
                        failureString.Add(testResult.failMessage);
                    }
                    else
                    {
                        foreach (string message in testResult.failMessages)
                            failureString.Add(message);
                    }

                    pass = false;
                }

                if (testResult.CancelSchedule)
                {
                    cancelSchedule = testResult.CancelSchedule;
                    break;
                }

                if (testResult.PasswordPrompt)
                {
                    passwordPrompt = testResult.PasswordPrompt;
                    break;
                }
            }

            var @override = new FrmOverride(failureString, Conversions.ToInteger(testRow["EngineerVisitID"]), isCopy, cancelSchedule, passwordPrompt);
            if (@override.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetHeader()
        {
            pnlHeader.BackColor = Color.SteelBlue;
            picRegion.Visible = false;
            picPostalRegions.Visible = false;
            picLevels.Visible = false;
            _testRow = null;
        }

        public DataTable GetDay(string date)
        {
            if (_dsEngineerSchedule.Tables[date] is null)
            {
                DataTable loadedDay;
                loadedDay = App.DB.Scheduler.Get_ScheduledJobsDay(Conversions.ToDate(date), EngineerID);
                loadedDay.TableName = date;
                _dsEngineerSchedule.Tables.Add(loadedDay);
            }

            DtTimeSlot = App.DB.Scheduler.Scheduler_DayTimeSlots(Conversions.ToDate(SelectedDay()), EngineerID);
            picPlanner.Image = Scheduler_DayTimeSlots_Bitmap();
            SetupTimeSheetStatus();
            var scheduledVisits = _dsEngineerSchedule.Tables[date].Select("VisitStatusID = " + Enums.VisitStatus.Scheduled);
            if (App.IsGasway)
                btnSendText.Visible = scheduledVisits.Length > 0;
            var rescheduleVisits = _dsEngineerSchedule.Tables[date].Select("VisitStatusID IN ( " + Enums.VisitStatus.Scheduled + " , " + Enums.VisitStatus.Downloaded + ")");
            btnReschedule.Visible = rescheduleVisits.Length > 0;
            var serviceList = _dsEngineerSchedule.Tables[date].Select("OutcomeEnumID = " + Enums.EngineerVisitOutcomes.Complete + " AND JobTypeID In (" + Enums.JobTypes.Service + ", " + Enums.JobTypes.ServiceCertificate + ", " + Enums.JobTypes.Commission + ")");
            btnPrintLsr.Visible = serviceList.Length > 0;
            return AddJobStatus(_dsEngineerSchedule.Tables[date], Conversions.ToDate(date));
        }

        private DataTable AddJobStatus(DataTable dt, DateTime date)
        {
            if (!dt.Columns.Contains("JobStatus"))
            {
                var dcServiceOverDue = new DataColumn("JobStatus", typeof(int));
                dcServiceOverDue.DefaultValue = false;
                dt.Columns.Add(dcServiceOverDue);
            }

            if (!dt.Columns.Contains("IsServiceOverDue"))
            {
                var dcServiceOverDue = new DataColumn("IsServiceOverDue", typeof(bool));
                dcServiceOverDue.DefaultValue = false;
                dt.Columns.Add(dcServiceOverDue);
            }

            foreach (DataRow row in dt.Rows)
                row["IsServiceOverDue"] = App.DB.Scheduler.IsSiteOverdue(Helper.MakeIntegerValid(row["SiteID"]));
            if (date.Date != DateTime.Today)
                return dt;
            if (!dt.Columns.Contains("IsJobLate"))
            {
                var dcJobLate = new DataColumn("IsJobLate", typeof(bool));
                dcJobLate.DefaultValue = false;
                dt.Columns.Add(dcJobLate);
            }

            foreach (DataRow row in dt.Rows)
            {
                if (row.Table.Columns.Contains("Declined"))
                {
                    if (Helper.MakeBooleanValid(row["Declined"]))
                        continue;
                }

                row["IsJobLate"] = App.DB.Scheduler.IsVisitLate(Helper.MakeIntegerValid(row["EngineerVisitID"]));
            }

            return dt;
        }

        public void Timer_tick(object myObject, EventArgs myEventArgs)
        {
            SetupHeartBeat();
            RefreshDay();
            DisplayLastLocation();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private delegate DataTable refreshSummaryDelegate();

        private IAsyncResult _refreshSummary;

        public void RefreshSummary(string start, string endin)
        {
            _startDate = start;
            _endDate = endin;
            var summaryRefresh = new refreshSummaryDelegate(BeginRefreshSummary);
            var summaryRefreshComplete = new AsyncCallback(RefreshSummaryComplete);
            _refreshSummary = summaryRefresh.BeginInvoke(summaryRefreshComplete, null);
        }

        public DataTable BeginRefreshSummary()
        {
            try
            {
                var dtSummary = App.DB.Scheduler.getSummaryNEW(EngineerID, Conversions.ToDate(_startDate), Conversions.ToDate(_endDate));
                dtSummary.TableName = "ScheduleSummary";
                return dtSummary;
            }
            catch
            {
                return null;
            }
        }

        public void RefreshSummaryComplete(IAsyncResult ar)
        {
            try
            {
                refreshSummaryDelegate o_MyDelegate = (refreshSummaryDelegate)((AsyncResult)ar).AsyncDelegate;
                var result = o_MyDelegate.EndInvoke(ar);
                if (result is object & !IsFormDisposed)
                {
                    Invoke(new setSummaryDelegate(SetSummary), result);
                }

                opening = false;
            }
            catch (Exception ex)
            {
            }
        }

        public void DisplayLastLocation()
        {
            var engineer = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(EngineerID));
            if (engineer is object)
            {
                var u = App.DB.User.GetAsync(engineer.ManagerUserID);
                string manager = "N/A";
                if (u is object)
                    manager = u.Fullname;
                var dvEngineerLocation = App.DB.Scheduler.Get_EngineerLocation(Conversions.ToInteger(EngineerID));
                string lastAppointment = " : Last update N/A";
                if (dvEngineerLocation.Count > 0)
                {
                    string timesheetType = Helper.MakeStringValid(dvEngineerLocation[0]["TimeSheetType"]);
                    if ((timesheetType ?? "") == "Working")
                    {
                        timesheetType += " at";
                    }
                    else if ((timesheetType ?? "") == "Travelling")
                    {
                        timesheetType += " to";
                    }

                    string address;
                    if (App.loggedInUser is object && App.loggedInUser.UserRegions.Table.Select("RegionID = " + Helper.MakeIntegerValid(dvEngineerLocation[0]["RegionID"])).Length < 1)
                    {
                        address = "xxx, " + Helper.MakeStringValid(dvEngineerLocation[0]["Postcode"]).Substring(0, Helper.MakeStringValid(dvEngineerLocation[0]["Postcode"]).IndexOf("-")) + "-xxx";
                    }
                    else
                    {
                        address = Helper.MakeStringValid(dvEngineerLocation[0]["Address1"]) + ", " + Helper.MakeStringValid(dvEngineerLocation[0]["Postcode"]);
                    }

                    lastAppointment = " : Last update " + Helper.MakeStringValid(dvEngineerLocation[0]["ArrivalTime"]) + " - " + timesheetType + " " + Helper.MakeStringValid(dvEngineerLocation[0]["JobNumber"]) + ", " + address;
                }

                lblTitle.Text = engineer.Name + " :  Manager: " + manager + lastAppointment;
            }
        }

        public void RefreshDay()
        {
            // update the day schedules that are opened at 11:30 and 13:00
            var refreshTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 30, 0);
            var refreshTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0);
            if (DateTime.Now.Hour == refreshTime1.Hour & DateTime.Now.Minute >= refreshTime1.Minute & DateTime.Now.Minute <= refreshTime1.AddMinutes(5).Minute)
            {
                ShowDay(SelectedDay());
            }

            if (DateTime.Now.Hour == refreshTime2.Hour & DateTime.Now.Minute >= refreshTime2.Minute & DateTime.Now.Minute <= refreshTime1.AddMinutes(5).Minute)
            {
                ShowDay(SelectedDay());
            }
        }

        public delegate void setSummaryDelegate(DataTable dtSummary);

        public void SetSummary(DataTable dtSummary)
        {
            try
            {
                DataTable currentTable;
                if (dgDaySummary.DataSource is object)
                {
                    currentTable = ((DataView)dgDaySummary.DataSource).Table;
                    var dvSummary = new DataView(dtSummary);
                    var dvCurrentTable = new DataView(currentTable);
                    dvCurrentTable.Sort = "dayDate";
                    foreach (DataRow newRow in dtSummary.Rows)
                    {
                        int foundIndex = dvCurrentTable.Find(newRow["dayDate"]);
                        if (foundIndex != -1)
                        {
                            var dayDate = currentTable.Rows[foundIndex];
                            dayDate["workCount"] = newRow["workCount"];
                            dayDate["SummedSOR"] = newRow["SummedSOR"];
                        }
                        else
                        {
                            currentTable.ImportRow(newRow);
                        }
                    }

                    DtTimeSlot = App.DB.Scheduler.Scheduler_DayTimeSlots(Conversions.ToDate(SelectedDay()), EngineerID);
                    picPlanner.Image = Scheduler_DayTimeSlots_Bitmap();
                }
                else
                {
                    dgDaySummary.DataSource = new DataView(dtSummary);
                    Application.DoEvents();
                }

                if (App.loggedInUser.SchedulerDayView)
                {
                    int selectedIndex = dgDaySummary.CurrentRowIndex;
                    dgDaySummary.DataSource = new DataView(dtSummary);
                    if (selectedIndex != -1)
                    {
                        dgDaySummary.Select(selectedIndex);
                        ShowDay(SelectedDay());
                        Application.DoEvents();
                    }
                }

                var daysWithWork = dtSummary.Select("workCount > 0");
                btnExportJobs.Visible = daysWithWork.Length > 0;
            }
            catch (Exception ex)
            {
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        public void ShowDay(string date)
        {
            dgDay.TableStyles[0].MappingName = date;
            dgDay.DataSource = new DataView(GetDay(date));
        }

        public string SelectedDay()
        {
            if (dgDaySummary is object)
            {
                DataView dvSummary = (DataView)dgDaySummary.DataSource;
                dgDaySummary.Select(dgDaySummary.CurrentRowIndex);
                return Conversions.ToString(dvSummary[dgDaySummary.CurrentRowIndex]["dayDate"]);
            }
            else
            {
                return DateAndTime.Now.ToString();
            }
        }

        public void ClearSelections()
        {
            if (dgDay.DataSource is object)
            {
                for (int rowCount = 0, loopTo = ((DataView)dgDay.DataSource).Count - 1; rowCount <= loopTo; rowCount++)
                    dgDay.UnSelect(rowCount);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataTable timeSlotDt;

        public DataTable DtTimeSlot
        {
            get
            {
                return timeSlotDt;
            }

            set
            {
                timeSlotDt = value;
            }
        }

        public PictureBox PicPlanner => throw new NotImplementedException();

        public DataTable TimeSlotDt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Bitmap Scheduler_DayTimeSlots_Bitmap()
        {
            if (DtTimeSlot is object && picPlanner.Height > 0 && picPlanner.Width > 0)
            {
                var timeSlots = new Bitmap(picPlanner.Width, picPlanner.Height);
                var timeSlotGfx = Graphics.FromImage(timeSlots);
                float slotWidth = Conversions.ToSingle(timeSlots.Width - 9) / Conversions.ToSingle(DtTimeSlot.Columns.Count - 1);
                string currentHour = "";
                timeSlotGfx.FillRectangle(new SolidBrush(Color.WhiteSmoke), 0, picPlanner.Height - 15, picPlanner.Width, 15);
                foreach (DataColumn time in DtTimeSlot.Columns)
                {
                    if (DtTimeSlot.Rows.Count > 0 && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(DtTimeSlot.Rows[0][time], 1, false)))
                    {
                        timeSlotGfx.FillRectangle(new SolidBrush(Color.LightSteelBlue), new RectangleF(slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth, Conversions.ToSingle(picPlanner.Height - 15)));
                    }

                    if ((time.ColumnName.Substring(1, 2) ?? "") != (currentHour ?? ""))
                    {
                        currentHour = time.ColumnName.Substring(1, 2);
                        timeSlotGfx.DrawLine(new Pen(Color.RoyalBlue), slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)), Conversions.ToSingle(picPlanner.Height - 12));
                        var hourFont = new Font(dgDay.Font.Name, 6, FontStyle.Regular);
                        timeSlotGfx.DrawString(currentHour, hourFont, new SolidBrush(Color.Black), slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)) - timeSlotGfx.MeasureString(currentHour, hourFont).Width / 2, Conversions.ToSingle(picPlanner.Height - timeSlotGfx.MeasureString(currentHour, hourFont).Height - 1));
                    }
                    else
                    {
                        timeSlotGfx.DrawLine(new Pen(Color.RoyalBlue), slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)), Conversions.ToSingle(picPlanner.Height - 13));
                    }
                }

                return timeSlots;
            }
            else
            {
                return null;
            }
        }

        private void frmVisit_SizeChanged(object sender, EventArgs e)
        {
            picPlanner.Image = Scheduler_DayTimeSlots_Bitmap();
        }

        private void splitEngineer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            picPlanner.Image = Scheduler_DayTimeSlots_Bitmap();
        }

        public void SendToPrint(string fileName = "")
        {
            DataRow dr = null;
            var lm = App.DB.LetterManager.MakeServiceLetter(EngineerVisit.EngineerVisitID);
            lm.Table.Columns.Add("FileName");
            if (lm.Count > 0 & string.IsNullOrEmpty(fileName))
            {
                dr = lm.Table.Rows[0];
            }
            else
            {
                var site = App.DB.Sites.Get(SelectedDataRow["SiteID"]);
                var dt = lm.Table.Clone();
                dr = dt.NewRow();
                dr["Name"] = site.Name;
                dr["Address1"] = site.Address1;
                dr["Address2"] = site.Address2;
                dr["Address3"] = site.Address3;
                dr["Address4"] = site.Address4;
                dr["Address5"] = site.Address5;
                dr["Postcode"] = site.Postcode;
                dr["SiteID"] = site.SiteID;
                dr["CustomerID"] = site.CustomerID;
                dr["SolidFuel"] = site.SolidFuel;
                dr["PropertyVoid"] = site.PropertyVoid;
                dr["LastServiceDate"] = site.LastServiceDate;
                dr["CommercialDistrict"] = site.CommercialDistrict;
                dr["SiteFuel"] = site.SiteFuel;
                dr["Type"] = "Generic";
                dr["NextVisitDate"] = SelectedDataRow["StartDateTime"];
                dr["StartDateTime"] = SelectedDataRow["StartDateTime"];
                dr["AMPM"] = "";
                dr["JobID"] = SelectedDataRow["JobID"];
                dr["JobNumber"] = SelectedDataRow["JobNumber"];
                dr["FileName"] = fileName;
                dt.Rows.Add(dr);
                dr = dt.Rows[0];
            }

            var details = new ArrayList();
            details.Add(dr);
            var oPrint = new Printing(details, "Service Letter", Enums.SystemDocumentType.ServiceLetters);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        private void SetupTimeSheetStatus()
        {
            int i = App.DB.Scheduler.getTimesheetStatus(Conversions.ToInteger(EngineerID));
            switch (i)
            {
                case 1: // Engineer Working
                    {
                        picQuestion.Visible = false;
                        picSpanner.Visible = true;
                        picVan.Visible = false;
                        break;
                    }

                case 2: // Engineer Travelling
                    {
                        picQuestion.Visible = false;
                        picSpanner.Visible = false;
                        picVan.Visible = true;
                        break;
                    }

                case 3: // No idea
                    {
                        picQuestion.Visible = true;
                        picSpanner.Visible = false;
                        picVan.Visible = false;
                        break;
                    }
            }
        }

        public void SetupHeartBeat()
        {
            var hb = App.DB.Scheduler.GetLatestHeartBeat(Conversions.ToInteger(EngineerID));
            if (Information.IsDBNull(hb.LastHeartBeat))
            {
                pbGreen.Visible = false;
                pbRed.Visible = false;
            }

            LastHeartBeat = hb.LastHeartBeat;
            LockedVisitId = hb.LockedVisitID;
            HeartLastCheck = hb.LastCheck;
            if (DateTime.Now.AddMinutes(-2) > LastHeartBeat)
            {
                pbGreen.Visible = false;
                pbRed.Visible = true;
            }
            else
            {
                pbGreen.Visible = true;
                pbRed.Visible = false;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSendText_Click(object sender, EventArgs e)
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedDataRow["VisitStatusID"], Enums.VisitStatus.Scheduled, false)))
                {
                    var oSite = App.DB.Sites.Get(SelectedDataRow["SiteID"]);
                    if (oSite is null || !oSite.Exists)
                        throw new Exception("Site missing");
                    string mobNum = oSite.FaxNum.Trim();
                    if (!Helper.ValidatePhoneNumber(mobNum))
                    {
                        App.ShowMessage("Mobile number invalid, please update!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (var frmContactInfo = new FRMContactInfo(oSite))
                        {
                            frmContactInfo.ShowDialog();
                            mobNum = frmContactInfo.CurrentSite.FaxNum.Trim();
                            if (!(frmContactInfo.DialogResult == DialogResult.Yes) | !Helper.ValidatePhoneNumber(mobNum))
                            {
                                throw new Exception("Mobile Number invalid!");
                            }
                        }
                    }

                    string timePeriod = string.Empty;
                    DateTime visitDate = Conversions.ToDate(SelectedDataRow["StartDateTime"]);
                    int appointmentId = Helper.MakeIntegerValid(SelectedDataRow["AppointmentID"]);
                    switch (appointmentId)
                    {
                        case (int)Enums.Appointments.FirstCall:
                        case (int)Enums.AppointmentsPicklist.FirstCall:
                            {
                                timePeriod = "8:00am - 9:00am";
                                break;
                            }

                        case (int)Enums.Appointments.EightAmTillTwelvePm:
                        case (int)Enums.AppointmentsPicklist.EightAmTillTwelvePm:
                            {
                                timePeriod = "8:00am - 12:00pm";
                                break;
                            }

                        case (int)Enums.Appointments.TenAmTillTwoPm:
                        case (int)Enums.AppointmentsPicklist.TenAmTillTwoPm:
                            {
                                timePeriod = "10:00am - 2:00pm";
                                break;
                            }

                        case (int)Enums.Appointments.TwelvePmTillFourPm:
                        case (int)Enums.AppointmentsPicklist.TwelvePmTillFourPm:
                            {
                                timePeriod = "12:00pm - 4:00pm";
                                break;
                            }

                        case (int)Enums.Appointments.TwoPmTillSixPm:
                        case (int)Enums.AppointmentsPicklist.TwoPmTillSixPm:
                            {
                                timePeriod = "2:00pm - 6:00pm";
                                break;
                            }

                        case (int)Enums.Appointments.Am:
                        case (int)Enums.AppointmentsPicklist.Am:
                            {
                                timePeriod = "8:00am - 1:00pm";
                                break;
                            }

                        case (int)Enums.Appointments.Pm:
                        case (int)Enums.AppointmentsPicklist.Pm:
                            {
                                timePeriod = "12:00pm - 6:00pm";
                                break;
                            }

                        case (int)Enums.Appointments.Anytime:
                        case (int)Enums.AppointmentsPicklist.Anytime:
                            {
                                timePeriod = "08:00am - 6:00pm";
                                break;
                            }

                        default:
                            {
                                timePeriod = visitDate.Hour < 12 ? "8:00am - 1:00pm" : "12:00pm - 6:00pm";
                                break;
                            }
                    }

                    var mb = new MessageBird.TextClient();
                    string textMessage = "CONFIRMATION - Hello, we are happy to confirm that your appointment has been booked for " + visitDate.DayOfWeek.ToString() + " " + visitDate.ToLongDateString() + ". The engineer will arrive between " + timePeriod + ".";
                    mb.MakeCall(textMessage, mobNum, App.TheSystem.Configuration.CompanyName);
                    App.DB.ExecuteScalar(Conversions.ToString("INSERT INTO tblText VALUES (0, GETDATE(),'" + mobNum + "'," + SelectedDataRow["EngineerVisitID"] + ") "));
                    var contactAttempt = new ContactAttempt();
                    {
                        var withBlock = contactAttempt;
                        withBlock.ContactMethedID = 7;
                        withBlock.LinkID = Conversions.ToInteger(Enums.TableNames.tblEngineerVisit);
                        withBlock.LinkRef = Helper.MakeIntegerValid(SelectedDataRow["EngineerVisitID"]);
                        withBlock.ContactMade = DateAndTime.Now;
                        withBlock.Notes = textMessage;
                        withBlock.ContactMadeByUserId = App.loggedInUser.UserID;
                    }

                    contactAttempt = App.DB.ContactAttempts.Insert(contactAttempt);
                    App.ShowMessage("Text message sent!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportJobs_Click(object sender, EventArgs e)
        {
            if (SelectedDay() is null)
            {
                App.ShowMessage("Please select a day", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dtDayJobs = GetDay(Conversions.ToString(Helper.MakeDateTimeValid(SelectedDay())));
            if (dtDayJobs.Rows.Count == 0)
            {
                App.ShowMessage("No Jobs to Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var engineer = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(EngineerID));
            string enginnerName = string.Empty;
            if (engineer is object)
                enginnerName = engineer.Name + "_";
            var exportData = new DataTable();
            exportData.Columns.Add("Job Number", typeof(string));
            exportData.Columns.Add("Address 1", typeof(string));
            exportData.Columns.Add("Postcode", typeof(string));
            exportData.Columns.Add("Job Summary", typeof(string));
            exportData.Columns.Add("Notes", typeof(string));
            exportData.Columns.Add("Start", typeof(DateTime));
            exportData.Columns.Add("End", typeof(DateTime));
            exportData.Columns.Add("Status", typeof(string));
            exportData.Columns.Add("Customer", typeof(string));
            exportData.Columns.Add("Type", typeof(string));
            exportData.Columns.Add("SOR", typeof(string));
            exportData.Columns.Add("Est Date", typeof(string));
            foreach (DataRow dr in dtDayJobs.Rows)
            {
                DataRow newRw;
                newRw = exportData.NewRow();
                newRw["Job Number"] = dr["JobNumber"];
                newRw["Address 1"] = dr["Address1"];
                newRw["Postcode"] = dr["PostCode"];
                newRw["Job Summary"] = dr["JobItems"];
                newRw["Notes"] = dr["NotesToEngineer"];
                newRw["Start"] = Helper.MakeDateTimeValid(dr["StartDateTime"]);
                newRw["End"] = Helper.MakeDateTimeValid(dr["EndDateTime"]);
                newRw["Status"] = dr["VisitStatus"];
                newRw["Customer"] = dr["CustomerName"];
                newRw["Type"] = dr["JobType"];
                newRw["SOR"] = dr["SummedSOR"];
                newRw["Est Date"] = dr["EstimatedVisitDate"];
                exportData.Rows.Add(newRw);
            }

            ExportHelper.Export(exportData, enginnerName + SelectedDay() + "_Jobs", Enums.ExportType.XLS);
        }

        private void picPlanner_MouseUp(object sender, MouseEventArgs e)
        {
            var point = Cursor.Position;
            detailPopup.MoveMoved(point);
        }

        private void btnPrintLsr_Click(object sender, EventArgs e)
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (Helper.MakeIntegerValid(SelectedDataRow["JobTypeID"]) == (int)Enums.JobTypes.ServiceCertificate | Helper.MakeIntegerValid(SelectedDataRow["JobTypeID"]) == (int)Enums.JobTypes.Service | Helper.MakeIntegerValid(SelectedDataRow["JobTypeID"]) == (int)Enums.JobTypes.Commission)
                {
                }
                else
                {
                    App.ShowMessage("This job does not have an LSR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Helper.MakeIntegerValid(SelectedDataRow["OutcomeEnumID"]) == (int)Enums.EngineerVisitOutcomes.Complete)
                {
                    int evId = Helper.MakeIntegerValid(SelectedDataRow["EngineerVisitId"]);
                    var details = new ArrayList();
                    details.Add(evId);
                    details.Add(SelectedDataRow["CustomerID"]);
                    var oPrint = new Printing(details, "Gas Safety Record ", Enums.SystemDocumentType.GSR);
                }
                else
                {
                    App.ShowMessage("This job does not have an LSR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            int jobId = Helper.MakeIntegerValid(SelectedDataRow?["JobID"]);
            int engineerVisitId = Helper.MakeIntegerValid(SelectedDataRow?["EngineerVisitID"]);
            int statusId = Helper.MakeIntegerValid(SelectedDataRow?["StatusEnumID"]);
            if (engineerVisitId == 0)
            {
                App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (statusId)
            {
                case (int)Enums.VisitStatus.Scheduled:
                case (int)Enums.VisitStatus.Downloaded:
                    {
                        break;
                    }

                default:
                    {
                        App.ShowMessage("This visit cannot be rescheduled!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }

            var JobLock = App.DB.JobLock.Check(jobId);
            if (JobLock is object)
            {
                string message = "This visit cannot be rescheduled because is it currently locked:" + Constants.vbCrLf;
                message += string.Format("Locked by: {0}", JobLock.NameOfUserWhoLocked) + Constants.vbCrLf;
                message += string.Format("Date Locked: {0}", JobLock.DateLock) + Constants.vbCrLf;
                MessageBox.Show(message, "Job Lock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmSchedulerMain frmSm = null;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmSchedulerMain))
                {
                    frmSm = (frmSchedulerMain)form;
                }
            }

            int tabletActionId = App.DB.EngineerVisits.EngineerVisit_GetActionID(engineerVisitId);
            string errorMsg = frmSm?.scheduler.CanMoveDownloadedVisit(this, engineerVisitId, tabletActionId);
            if (statusId == (int)Enums.VisitStatus.Scheduled | string.IsNullOrEmpty(errorMsg))
            {
                using (var frmRescheduleVisit = new FRMRescheduleVisit(engineerVisitId))
                {
                    frmRescheduleVisit.ShowDialog();
                }

                frmSm?.scheduler.refreshScheduler();
            }
            else
            {
                App.ShowMessage(errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateJob_Click(object sender, EventArgs e)
        {
            if (SelectedDay() is null)
            {
                App.ShowMessage("Please select a day", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmSchedulerMain frmSm = null;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frmSchedulerMain))
                {
                    frmSm = (frmSchedulerMain)form;
                }
            }

            using (var frmNewJob = new FRMNewJob(Helper.MakeDateTimeValid(SelectedDay()), Conversions.ToInteger(EngineerID)))
            {
                frmNewJob.ShowDialog();
                frmSm?.scheduler.refreshScheduler();
            }
        }

        private void btnSiteReport_Click(object sender, EventArgs e)
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("Please select a visit to open the site report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var oSite = App.DB.Sites.Get(SelectedDataRow["SiteID"]);
            if (oSite is null || !oSite.Exists)
            {
                App.ShowMessage("Unable to access site!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + oSite.RegionID).Length < 1)
            {
                string msg = "You do not have the necessary security permissions." + Constants.vbCrLf + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }

            PdfFactory.GenerateSiteHistoryReport(oSite);
        }

        private void dgDay_MouseUp(object sender, MouseEventArgs e)
        {
            ttStatus.Hide(dgDay);
            if (SelectedDataRow is null)
            {
                return;
            }

            string msg = "";
            if (SelectedDataRow.Table.Columns.Contains("IsJobLate"))
            {
                if (Helper.MakeBooleanValid(SelectedDataRow["IsJobLate"]))
                {
                    msg = "Engineer is running late to visit!";
                }
            }

            if (SelectedDataRow.Table.Columns.Contains("IsServiceOverDue"))
            {
                if (Helper.MakeBooleanValid(SelectedDataRow["IsServiceOverDue"]))
                {
                    msg = "Service is overdue on site!";
                }
            }

            if (SelectedDataRow.Table.Columns.Contains("Declined"))
            {
                if (Helper.MakeBooleanValid(SelectedDataRow["Declined"]))
                {
                    msg = "Visit has been declined!";
                }
            }

            if (string.IsNullOrWhiteSpace(msg))
                return;
            var hittest = dgDay.HitTest(e.X, e.Y);
            if (hittest.Type == DataGrid.HitTestType.Cell)
            {
                if (hittest.Column == 0 | hittest.Column == 1)
                {
                    ttStatus.Show(msg, dgDay, e.X, e.Y);
                }
            }
        }

        private void dgDay_MouseMove(object sender, MouseEventArgs e)
        {
            var hittest = dgDay.HitTest(e.X, e.Y);
            if (hittest.Type == DataGrid.HitTestType.Cell)
            {
                if (hittest.Column != 0 && hittest.Column != 1)
                {
                    ttStatus.Hide(dgDay);
                }
            }
            else
            {
                ttStatus.Hide(dgDay);
            }
        }

        private void imgEye_Click(object sender, EventArgs e)
        {
            if (Engineer is object)
            {
                var dtEngineer = Engineer.Table.Clone();
                dtEngineer.Rows.Add(Engineer.ItemArray);
                using (var frmViewEngineer = new FRMViewEngineer(dtEngineer))
                {
                    frmViewEngineer.ShowDialog();
                }
            }
        }

        private void mnuVisitAction_Popup(object sender, EventArgs e)
        {
            Enums.VisitStatus visitStatus = (Enums.VisitStatus)Conversions.ToInteger(Helper.MakeIntegerValid(SelectedDataRow["VisitStatusID"]));
            if (visitStatus == Enums.VisitStatus.Scheduled | visitStatus == Enums.VisitStatus.Downloaded)
            {
                btnTextMessage.Visible = true;
                btnSolarInstallation.Visible = true;
                btnElectricalAppointment.Visible = true;
                EngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Helper.MakeIntegerValid(SelectedDataRow["EngineerVisitID"]), false);
                if (EngineerVisit?.ExcludeFromTextMessage == true)
                {
                    btnTextMessage.Text = "Include in auto-messages";
                }
                else
                {
                    btnTextMessage.Text = "Exclude from auto-messages";
                }

                if (Conversions.ToBoolean(EngineerVisit.VisitNumber > 0 | Operators.ConditionalCompareObjectEqual(SelectedDataRow["JobTypeID"], Conversions.ToInteger(Enums.JobTypes.ServiceCertificate), false) | Operators.ConditionalCompareObjectEqual(SelectedDataRow["JobTypeID"], Conversions.ToInteger(Enums.JobTypes.Service), false)))
                {
                    btnServiceLetter.Visible = true;
                }
                else
                {
                    btnServiceLetter.Visible = false;
                }
            }
            else
            {
                btnTextMessage.Visible = false;
                btnServiceLetter.Visible = false;
                btnSolarInstallation.Visible = false;
                btnElectricalAppointment.Visible = false;
            }
        }

        private void btnTextMessage_Click(object sender, EventArgs e)
        {
            if (EngineerVisit is object)
            {
                EngineerVisit.SetExcludeFromTextMessage = !EngineerVisit.ExcludeFromTextMessage;
                App.DB.EngineerVisits.Update(EngineerVisit, 0, true);
            }
        }

        private void btnServiceLetter_Click(object sender, EventArgs e)
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SendToPrint();
        }

        private void btnSolarInstallation_Click(object sender, EventArgs e)
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SendToPrint(@"\ServiceLetters\SolarAppointment.docx");
        }

        private void btnElectricalAppointment_Click(object sender, EventArgs e)
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SendToPrint(@"\ServiceLetters\ElectricalTestingLetter.docx");
        }

        public string selectedDay()
        {
            throw new NotImplementedException();
        }
    }
}