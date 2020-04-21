using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class frmSchedulerMain : Form
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public frmSchedulerMain() : base()
        {
            base.Load += frmSchedulerMain_Load;
            base.Closing += frmSchedulerMain_Closing;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            CheckForIllegalCrossThreadCalls = false;
        }

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components is null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private MainMenu _mnuMain;

        internal MainMenu mnuMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuMain != null)
                {
                }

                _mnuMain = value;
                if (_mnuMain != null)
                {
                }
            }
        }

        private MenuItem _mnuScheduler;

        internal MenuItem mnuScheduler
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuScheduler;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuScheduler != null)
                {
                }

                _mnuScheduler = value;
                if (_mnuScheduler != null)
                {
                }
            }
        }

        private MenuItem _mnuOpenSchedule;

        internal MenuItem mnuOpenSchedule
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuOpenSchedule;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuOpenSchedule != null)
                {
                    _mnuOpenSchedule.Click -= mnuOpenSchedule_Click;
                }

                _mnuOpenSchedule = value;
                if (_mnuOpenSchedule != null)
                {
                    _mnuOpenSchedule.Click += mnuOpenSchedule_Click;
                }
            }
        }

        private MenuItem _mnuResetScheduler;

        internal MenuItem mnuResetScheduler
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuResetScheduler;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuResetScheduler != null)
                {
                    _mnuResetScheduler.Click -= mnuResetScheduler_Click;
                }

                _mnuResetScheduler = value;
                if (_mnuResetScheduler != null)
                {
                    _mnuResetScheduler.Click += mnuResetScheduler_Click;
                }
            }
        }

        private MenuItem _mnuCloseScheduler;

        internal MenuItem mnuCloseScheduler
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuCloseScheduler;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuCloseScheduler != null)
                {
                    _mnuCloseScheduler.Click -= mnuCloseScheduler_Click;
                }

                _mnuCloseScheduler = value;
                if (_mnuCloseScheduler != null)
                {
                    _mnuCloseScheduler.Click += mnuCloseScheduler_Click;
                }
            }
        }

        private MenuItem _mnuDividerScheduler;

        internal MenuItem mnuDividerScheduler
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuDividerScheduler;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuDividerScheduler != null)
                {
                }

                _mnuDividerScheduler = value;
                if (_mnuDividerScheduler != null)
                {
                }
            }
        }

        private MenuItem _mnuWeekSchedule;

        internal MenuItem mnuWeekSchedule
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuWeekSchedule;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuWeekSchedule != null)
                {
                }

                _mnuWeekSchedule = value;
                if (_mnuWeekSchedule != null)
                {
                }
            }
        }

        private MenuItem _mnuPrintWeek;

        internal MenuItem mnuPrintWeek
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuPrintWeek;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuPrintWeek != null)
                {
                    _mnuPrintWeek.Click -= mnuPrintWeek_Click;
                }

                _mnuPrintWeek = value;
                if (_mnuPrintWeek != null)
                {
                    _mnuPrintWeek.Click += mnuPrintWeek_Click;
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

        private MenuItem _MenuItem2;

        internal MenuItem MenuItem2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MenuItem2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MenuItem2 != null)
                {
                }

                _MenuItem2 = value;
                if (_MenuItem2 != null)
                {
                }
            }
        }

        private MenuItem _mnuAbsences;

        internal MenuItem mnuAbsences
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuAbsences;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuAbsences != null)
                {
                    _mnuAbsences.Click -= mnuAbsences_Click;
                }

                _mnuAbsences = value;
                if (_mnuAbsences != null)
                {
                    _mnuAbsences.Click += mnuAbsences_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSchedulerMain));
            _mnuMain = new MainMenu(components);
            _mnuScheduler = new MenuItem();
            _mnuOpenSchedule = new MenuItem();
            _mnuOpenSchedule.Click += new EventHandler(mnuOpenSchedule_Click);
            _mnuResetScheduler = new MenuItem();
            _mnuResetScheduler.Click += new EventHandler(mnuResetScheduler_Click);
            _mnuDividerScheduler = new MenuItem();
            _mnuCloseScheduler = new MenuItem();
            _mnuCloseScheduler.Click += new EventHandler(mnuCloseScheduler_Click);
            _mnuAbsences = new MenuItem();
            _mnuAbsences.Click += new EventHandler(mnuAbsences_Click);
            _mnuWeekSchedule = new MenuItem();
            _mnuPrintWeek = new MenuItem();
            _mnuPrintWeek.Click += new EventHandler(mnuPrintWeek_Click);
            _MenuItem1 = new MenuItem();
            _MenuItem2 = new MenuItem();
            SuspendLayout();
            //
            // mnuMain
            //
            _mnuMain.MenuItems.AddRange(new MenuItem[] { _mnuScheduler, _mnuAbsences, _mnuWeekSchedule, _MenuItem2 });
            //
            // mnuScheduler
            //
            _mnuScheduler.Index = 0;
            _mnuScheduler.MenuItems.AddRange(new MenuItem[] { _mnuOpenSchedule, _mnuResetScheduler, _mnuDividerScheduler, _mnuCloseScheduler });
            _mnuScheduler.Text = "&Scheduler";
            //
            // mnuOpenSchedule
            //
            _mnuOpenSchedule.Index = 0;
            _mnuOpenSchedule.Shortcut = Shortcut.F2;
            _mnuOpenSchedule.Text = "&Open";
            //
            // mnuResetScheduler
            //
            _mnuResetScheduler.Index = 1;
            _mnuResetScheduler.Shortcut = Shortcut.F3;
            _mnuResetScheduler.Text = "&Reset";
            //
            // mnuDividerScheduler
            //
            _mnuDividerScheduler.Index = 2;
            _mnuDividerScheduler.Text = "-";
            //
            // mnuCloseScheduler
            //
            _mnuCloseScheduler.Index = 3;
            _mnuCloseScheduler.Text = "&Close";
            //
            // mnuAbsences
            //
            _mnuAbsences.Index = 1;
            _mnuAbsences.Text = "&Absences";
            //
            // mnuWeekSchedule
            //
            _mnuWeekSchedule.Index = 2;
            _mnuWeekSchedule.MenuItems.AddRange(new MenuItem[] { _mnuPrintWeek, _MenuItem1 });
            _mnuWeekSchedule.Text = "&Week Schedule";
            _mnuWeekSchedule.Visible = false;
            //
            // mnuPrintWeek
            //
            _mnuPrintWeek.Index = 0;
            _mnuPrintWeek.Text = "&Print";
            //
            // MenuItem1
            //
            _MenuItem1.Index = 1;
            _MenuItem1.Text = "frmVisit";
            _MenuItem1.Visible = false;
            //
            // MenuItem2
            //
            _MenuItem2.Index = 3;
            _MenuItem2.Text = "Development";
            _MenuItem2.Visible = false;
            //
            // frmSchedulerMain
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(744, 371);
            Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Menu = _mnuMain;
            MinimumSize = new Size(752, 405);
            Name = "frmSchedulerMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Scheduler";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        public Scheduler scheduler;
        // Private _fromDate As DateTime
        // Private _toDate As DateTime

        public event OnVScrollEventHandler OnVScroll;

        public delegate void OnVScrollEventHandler(int position);

        private void mnuOpenSchedule_Click(object sender, EventArgs e)
        {
            scheduler.Open();
        }

        private void frmSchedulerMain_Load(object sender, EventArgs e)
        {
            scheduler = new Scheduler(this);
            scheduler.Open();
        }

        private void mnuResetScheduler_Click(object sender, EventArgs e)
        {
            scheduler.reset();
        }

        private void mnuCloseScheduler_Click(object sender, EventArgs e)
        {
            scheduler.close();
            Dispose();
        }

        private void mnuPrintWeek_Click(object sender, EventArgs e)
        {
        }

        private void mnuAbsences_Click(object sender, EventArgs e)
        {
            var frm = new frmAbsences();
            frm.Closing += FrmEngineerAbsenceClosing;
            frm.ShowDialog();
        }

        private void FrmEngineerAbsenceClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            scheduler.refreshScheduler();
        }

        private void frmSchedulerMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            scheduler.close();
        }
    }
}