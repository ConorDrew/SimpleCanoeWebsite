using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMJobWizard : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMJobWizard() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMSite_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCJobWizard();
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

        private Button _btnPrivateNotes;

        internal Button btnPrivateNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrivateNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrivateNotes != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _btnPrivateNotes.Click -= btnReset_Click;
                }

                _btnPrivateNotes = value;
                if (_btnPrivateNotes != null)
                {
                    _btnPrivateNotes.Click += btnReset_Click;
                }
            }
        }

        private Button _btnReset;

        internal Button btnReset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReset != null)
                {
                    _btnReset.Click -= btnReset_Click_1;
                }

                _btnReset = value;
                if (_btnReset != null)
                {
                    _btnReset.Click += btnReset_Click_1;
                }
            }
        }

        private Button _btnSaveProg;

        internal Button btnSaveProg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveProg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveProg != null)
                {
                    _btnSaveProg.Click -= Button1_Click;
                }

                _btnSaveProg = value;
                if (_btnSaveProg != null)
                {
                    _btnSaveProg.Click += Button1_Click;
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
            _btnPrivateNotes = new Button();
            _btnPrivateNotes.Click += new EventHandler(btnReset_Click);
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click_1);
            _btnSaveProg = new Button();
            _btnSaveProg.Click += new EventHandler(Button1_Click);
            SuspendLayout();
            // 
            // btnClose
            // 
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(12, 724);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(87, 25);
            _btnClose.TabIndex = 3;
            _btnClose.Text = "Close";
            // 
            // pnlMain
            // 
            _pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _pnlMain.Location = new Point(0, 32);
            _pnlMain.Name = "pnlMain";
            _pnlMain.Size = new Size(926, 685);
            _pnlMain.TabIndex = 1;
            // 
            // btnPrivateNotes
            // 
            _btnPrivateNotes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnPrivateNotes.Location = new Point(380, 724);
            _btnPrivateNotes.Name = "btnPrivateNotes";
            _btnPrivateNotes.Size = new Size(123, 25);
            _btnPrivateNotes.TabIndex = 4;
            _btnPrivateNotes.Text = "Private Notes";
            // 
            // btnReset
            // 
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(709, 724);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(87, 25);
            _btnReset.TabIndex = 5;
            _btnReset.Text = "Restart";
            // 
            // btnSaveProg
            // 
            _btnSaveProg.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveProg.Location = new Point(802, 724);
            _btnSaveProg.Name = "btnSaveProg";
            _btnSaveProg.Size = new Size(122, 25);
            _btnSaveProg.TabIndex = 6;
            _btnSaveProg.Text = "Save Progress";
            _btnSaveProg.Visible = false;
            // 
            // FRMJobWizard
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(934, 761);
            Controls.Add(_btnSaveProg);
            Controls.Add(_btnReset);
            Controls.Add(_btnPrivateNotes);
            Controls.Add(_btnClose);
            Controls.Add(_pnlMain);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(950, 733);
            Name = "FRMJobWizard";
            Text = "Job Wizard";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_pnlMain, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_btnPrivateNotes, 0);
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_btnSaveProg, 0);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            ((UCJobWizard)LoadedControl).DGVSites.AutoGenerateColumns = false;
            ((UCJobWizard)LoadedControl).SetupSiteDataGridView();
            ((UCJobWizard)LoadedControl).SetupAppsDG();
            ((UCJobWizard)LoadedControl).SetupSOR();
            ((UCJobWizard)LoadedControl).SetupDGSymptoms();
            ((UCJobWizard)LoadedControl).SetupDGAdditional();
            ((UCJobWizard)LoadedControl).SetupExisitingJobs();
            LoadForm(sender, e, this);
            try
            {
                ((UCJobWizard)LoadedControl).FromForm = (Form)get_GetParameter(1);
            }
            catch (Exception ex)
            {
                // DO NOTHING
            }
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
                }
                else
                {
                    PageState = Entity.Sys.Enums.FormState.Update;
                    var oCust = new Entity.Customers.Customer();
                    oCust = App.DB.Customer.Customer_Get_ForSiteID(ID);
                    Text = "Property : ID " + ID + " for Customer: " + oCust.Name + ", Acc: " + oCust.AccountNumber;
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

        private void FRMSite_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
                // CType(LoadedControl, UCJobWizard).CurrentSite = DB.Sites.Get(ID)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            ((UCJobWizard)LoadedControl).Notes();
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            ((UCJobWizard)LoadedControl).Reset();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ((UCJobWizard)LoadedControl).SaveProgress();
        }
    }
}