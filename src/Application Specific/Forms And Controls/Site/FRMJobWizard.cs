using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMJobWizard : FRMBaseForm, IForm
    {
        public FRMJobWizard() : base()
        {
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
            this._btnClose = new System.Windows.Forms.Button();
            this._pnlMain = new System.Windows.Forms.Panel();
            this._btnPrivateNotes = new System.Windows.Forms.Button();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnSaveProg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(12, 724);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(87, 25);
            this._btnClose.TabIndex = 3;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _pnlMain
            // 
            this._pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlMain.Location = new System.Drawing.Point(0, 12);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(926, 705);
            this._pnlMain.TabIndex = 1;
            // 
            // _btnPrivateNotes
            // 
            this._btnPrivateNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnPrivateNotes.Location = new System.Drawing.Point(380, 724);
            this._btnPrivateNotes.Name = "_btnPrivateNotes";
            this._btnPrivateNotes.Size = new System.Drawing.Size(123, 25);
            this._btnPrivateNotes.TabIndex = 4;
            this._btnPrivateNotes.Text = "Private Notes";
            this._btnPrivateNotes.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(709, 724);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(87, 25);
            this._btnReset.TabIndex = 5;
            this._btnReset.Text = "Restart";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // _btnSaveProg
            // 
            this._btnSaveProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveProg.Location = new System.Drawing.Point(802, 724);
            this._btnSaveProg.Name = "_btnSaveProg";
            this._btnSaveProg.Size = new System.Drawing.Size(122, 25);
            this._btnSaveProg.TabIndex = 6;
            this._btnSaveProg.Text = "Save Progress";
            this._btnSaveProg.Visible = false;
            this._btnSaveProg.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FRMJobWizard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(934, 761);
            this.Controls.Add(this._btnSaveProg);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._btnPrivateNotes);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(950, 733);
            this.Name = "FRMJobWizard";
            this.Text = "Job Wizard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
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