using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMFleetVan : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMFleetVan() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMVan_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCFleetVan();
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
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            SuspendLayout();
            // 
            // btnClose
            // 
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(625, 888);
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
            _pnlMain.Size = new Size(693, 847);
            _pnlMain.TabIndex = 1;
            // 
            // btnSave
            // 
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSave.Location = new Point(12, 888);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 25);
            _btnSave.TabIndex = 4;
            _btnSave.Text = "Save";
            _btnSave.Visible = false;
            // 
            // FRMFleetVan
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(693, 925);
            Controls.Add(_btnSave);
            Controls.Add(_btnClose);
            Controls.Add(_pnlMain);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(543, 570);
            Name = "FRMFleetVan";
            Text = "Fleet Van : ID {0}";
            Controls.SetChildIndex(_pnlMain, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_btnSave, 0);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            ((UCFleetVan)LoadedControl).CurrentVan = App.DB.FleetVan.Get(ID);
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
                if (ID == 0)
                {
                    PageState = Entity.Sys.Enums.FormState.Insert;
                    Text = "Fleet Van : Adding New...";
                    btnSave.Visible = true;
                }
                else
                {
                    PageState = Entity.Sys.Enums.FormState.Update;
                    Text = "Fleet Van : ID " + ID;
                    btnSave.Visible = false;
                }
            }
        }

        private Entity.Sys.Enums.FormState _pageState;

        private Entity.Sys.Enums.FormState PageState
        {
            get
            {
                return _pageState;
            }

            set
            {
                _pageState = value;
            }
        }

        private void FRMVan_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
                ((UCFleetVan)LoadedControl).CurrentVan = App.DB.FleetVan.Get(ID);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}