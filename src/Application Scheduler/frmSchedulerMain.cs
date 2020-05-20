using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class frmSchedulerMain : FRMBaseForm, IForm
    {
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
            get { return _mnuMain; }

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

        private MenuItem _mnuOpenSchedule;

        private MenuItem _mnuResetScheduler;

        private MenuItem _mnuCloseScheduler;

        private MenuItem _mnuDividerScheduler;

        private MenuItem _mnuWeekSchedule;

        private MenuItem _mnuPrintWeek;

        private MenuItem _MenuItem1;

        private MenuItem _MenuItem2;

        private MenuItem _mnuAbsences;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSchedulerMain));
            this._mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this._mnuScheduler = new System.Windows.Forms.MenuItem();
            this._mnuOpenSchedule = new System.Windows.Forms.MenuItem();
            this._mnuResetScheduler = new System.Windows.Forms.MenuItem();
            this._mnuDividerScheduler = new System.Windows.Forms.MenuItem();
            this._mnuCloseScheduler = new System.Windows.Forms.MenuItem();
            this._mnuAbsences = new System.Windows.Forms.MenuItem();
            this._mnuWeekSchedule = new System.Windows.Forms.MenuItem();
            this._mnuPrintWeek = new System.Windows.Forms.MenuItem();
            this._MenuItem1 = new System.Windows.Forms.MenuItem();
            this._MenuItem2 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // _mnuMain
            // 
            this._mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnuScheduler,
            this._mnuAbsences,
            this._mnuWeekSchedule,
            this._MenuItem2});
            // 
            // _mnuScheduler
            // 
            this._mnuScheduler.Index = 0;
            this._mnuScheduler.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnuOpenSchedule,
            this._mnuResetScheduler,
            this._mnuDividerScheduler,
            this._mnuCloseScheduler});
            this._mnuScheduler.Text = "&Scheduler";
            // 
            // _mnuOpenSchedule
            // 
            this._mnuOpenSchedule.Index = 0;
            this._mnuOpenSchedule.Shortcut = System.Windows.Forms.Shortcut.F2;
            this._mnuOpenSchedule.Text = "&Open";
            this._mnuOpenSchedule.Click += new System.EventHandler(this.mnuOpenSchedule_Click);
            // 
            // _mnuResetScheduler
            // 
            this._mnuResetScheduler.Index = 1;
            this._mnuResetScheduler.Shortcut = System.Windows.Forms.Shortcut.F3;
            this._mnuResetScheduler.Text = "&Reset";
            this._mnuResetScheduler.Click += new System.EventHandler(this.mnuResetScheduler_Click);
            // 
            // _mnuDividerScheduler
            // 
            this._mnuDividerScheduler.Index = 2;
            this._mnuDividerScheduler.Text = "-";
            // 
            // _mnuCloseScheduler
            // 
            this._mnuCloseScheduler.Index = 3;
            this._mnuCloseScheduler.Text = "&Close";
            this._mnuCloseScheduler.Click += new System.EventHandler(this.mnuCloseScheduler_Click);
            // 
            // _mnuAbsences
            // 
            this._mnuAbsences.Index = 1;
            this._mnuAbsences.Text = "&Absences";
            this._mnuAbsences.Click += new System.EventHandler(this.mnuAbsences_Click);
            // 
            // _mnuWeekSchedule
            // 
            this._mnuWeekSchedule.Index = 2;
            this._mnuWeekSchedule.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnuPrintWeek,
            this._MenuItem1});
            this._mnuWeekSchedule.Text = "&Week Schedule";
            this._mnuWeekSchedule.Visible = false;
            // 
            // _mnuPrintWeek
            // 
            this._mnuPrintWeek.Index = 0;
            this._mnuPrintWeek.Text = "&Print";
            this._mnuPrintWeek.Click += new System.EventHandler(this.mnuPrintWeek_Click);
            // 
            // _MenuItem1
            // 
            this._MenuItem1.Index = 1;
            this._MenuItem1.Text = "frmVisit";
            this._MenuItem1.Visible = false;
            // 
            // _MenuItem2
            // 
            this._MenuItem2.Index = 3;
            this._MenuItem2.Text = "Development";
            this._MenuItem2.Visible = false;
            // 
            // frmSchedulerMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(744, 371);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this._mnuMain;
            this.MinimumSize = new System.Drawing.Size(752, 405);
            this.Name = "frmSchedulerMain";
            this.ShowInTaskbar = true;
            this.Text = "Scheduler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

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
            LoadMe(sender, e);
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

        public void UpdateMessage()
        {
            Text = App.TheSystem.Configuration.CompanyName + " " + Text;
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            UpdateMessage();
            scheduler = new Scheduler(this);
            scheduler.Open();
        }

        public IUserControl LoadedControl { get; }

        public void ResetMe(int newID)
        {
            throw new NotImplementedException();
        }
    }
}