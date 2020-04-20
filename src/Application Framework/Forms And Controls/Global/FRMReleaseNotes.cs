using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMReleaseNotes : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMReleaseNotes() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMReleaseNotes_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

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

        private RichTextBox _rtbReleaseNotes;

        internal RichTextBox rtbReleaseNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rtbReleaseNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rtbReleaseNotes != null)
                {
                    _rtbReleaseNotes.LinkClicked -= rtbReleaseNotes_LinkClicked;
                }

                _rtbReleaseNotes = value;
                if (_rtbReleaseNotes != null)
                {
                    _rtbReleaseNotes.LinkClicked += rtbReleaseNotes_LinkClicked;
                }
            }
        }


        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _rtbReleaseNotes = new RichTextBox();
            _rtbReleaseNotes.LinkClicked += new LinkClickedEventHandler(rtbReleaseNotes_LinkClicked);
            SuspendLayout();
            // 
            // rtbReleaseNotes
            // 
            _rtbReleaseNotes.Dock = DockStyle.Fill;
            _rtbReleaseNotes.Location = new Point(0, 32);
            _rtbReleaseNotes.Name = "rtbReleaseNotes";
            _rtbReleaseNotes.Size = new Size(478, 300);
            _rtbReleaseNotes.TabIndex = 2;
            _rtbReleaseNotes.Text = "";
            // 
            // FRMReleaseNotes
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(478, 332);
            Controls.Add(_rtbReleaseNotes);
            MaximizeBox = false;
            MaximumSize = new Size(1000, 1000);
            MinimizeBox = false;
            MinimumSize = new Size(416, 208);
            Name = "FRMReleaseNotes";
            Controls.SetChildIndex(_rtbReleaseNotes, 0);
            ResumeLayout(false);
        }

        public Process process = new Process();
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            FillReleaseNotes();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void ResetMe(int newID)
        {
        }

        private void FRMReleaseNotes_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void FillReleaseNotes()
        {
            string releaseNote = Entity.Sys.Helper.GetTextResource(App.ReleaseNoteTextFile);
            rtbReleaseNotes.Text = releaseNote;
        }

        private void rtbReleaseNotes_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            process = Process.Start(e.LinkText);
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}