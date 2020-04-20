using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMQuoteJobItemAssets : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMQuoteJobItemAssets() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMContract_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCQuoteJobItemAssets();
            pnlMain.Controls.Add((Control)TheLoadedControl);
            LoadedControl.StateChanged += ResetMe;
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

        private Panel _pnlMain;

        internal Panel pnlMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlMain != null)
                {
                }

                _pnlMain = value;
                if (_pnlMain != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _pnlMain = new Panel();
            SuspendLayout();
            // 
            // btnClose
            // 
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(8, 280);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 25);
            _btnClose.TabIndex = 3;
            _btnClose.Text = "Close";
            // 
            // pnlMain
            // 
            _pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _pnlMain.Location = new Point(0, 32);
            _pnlMain.Name = "pnlMain";
            _pnlMain.Size = new Size(600, 240);
            _pnlMain.TabIndex = 1;
            // 
            // FRMJobItemAssets
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(608, 318);
            Controls.Add(_btnClose);
            Controls.Add(_pnlMain);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(400, 300);
            Name = "FRMJobItemAssets";
            Text = "Job Item Assets";
            Controls.SetChildIndex(_pnlMain, 0);
            Controls.SetChildIndex(_btnClose, 0);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            ((UCQuoteJobItemAssets)LoadedControl).IDToLinkTo = ID;
            LoadForm(sender, e, this);
            ((UCQuoteJobItemAssets)LoadedControl).SetupAssetsDataGrid();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return (IUserControl)pnlMain.Controls[0];
            }
        }

        public void ResetMe(int newID)
        {
            ID = newID;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private IUserControl TheLoadedControl;
        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
                Text = "Job Item Assets";
            }
        }

        private void FRMContract_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}