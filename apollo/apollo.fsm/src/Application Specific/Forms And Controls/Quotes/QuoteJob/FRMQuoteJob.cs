using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMQuoteJob : FRMBaseForm, IForm
    {
        public FRMQuoteJob() : base()
        {
            base.Load += FRMQuoteJob_Load;
            base.Closing += FRMQuoteJob_Closing;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            TheLoadedControl = new UCQuoteJob();
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

        private Button _btnViewJob;

        internal Button btnViewJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnViewJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnViewJob != null)
                {
                    _btnViewJob.Click -= btnViewJob_Click;
                }

                _btnViewJob = value;
                if (_btnViewJob != null)
                {
                    _btnViewJob.Click += btnViewJob_Click;
                }
            }
        }

        private Button _btnViewSite;

        private Button _btnConvert;

        internal Button btnConvert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnConvert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnConvert != null)
                {
                    _btnConvert.Click -= btnConvert_Click;
                }

                _btnConvert = value;
                if (_btnConvert != null)
                {
                    _btnConvert.Click += btnConvert_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._pnlMain = new System.Windows.Forms.Panel();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._btnViewJob = new System.Windows.Forms.Button();
            this._btnViewSite = new System.Windows.Forms.Button();
            this._btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _pnlMain
            // 
            this._pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlMain.Location = new System.Drawing.Point(0, 12);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(1184, 728);
            this._pnlMain.TabIndex = 1;
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Location = new System.Drawing.Point(8, 747);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 23);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(72, 747);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 23);
            this._btnClose.TabIndex = 3;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _btnViewJob
            // 
            this._btnViewJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnViewJob.Location = new System.Drawing.Point(808, 747);
            this._btnViewJob.Name = "_btnViewJob";
            this._btnViewJob.Size = new System.Drawing.Size(88, 24);
            this._btnViewJob.TabIndex = 5;
            this._btnViewJob.Text = "View Job";
            this._btnViewJob.Visible = false;
            this._btnViewJob.Click += new System.EventHandler(this.btnViewJob_Click);
            // 
            // _btnViewSite
            // 
            this._btnViewSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnViewSite.Location = new System.Drawing.Point(134, 747);
            this._btnViewSite.Name = "_btnViewSite";
            this._btnViewSite.Size = new System.Drawing.Size(100, 24);
            this._btnViewSite.TabIndex = 7;
            this._btnViewSite.Text = "View Property";
            this._btnViewSite.Click += new System.EventHandler(this.btnViewSite_Click);
            // 
            // _btnConvert
            // 
            this._btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnConvert.Location = new System.Drawing.Point(1022, 747);
            this._btnConvert.Name = "_btnConvert";
            this._btnConvert.Size = new System.Drawing.Size(92, 23);
            this._btnConvert.TabIndex = 8;
            this._btnConvert.Text = "Convert";
            this._btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // FRMQuoteJob
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1184, 781);
            this.Controls.Add(this._btnConvert);
            this.Controls.Add(this._btnViewSite);
            this.Controls.Add(this._btnViewJob);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 820);
            this.Name = "FRMQuoteJob";
            this.Text = "Quote Job : ID {0}";
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            ((UCQuoteJob)LoadedControl).RefreshButton += ShowButton;
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            string convertedJobNumber = App.DB.Job.Job_Get_For_Quote_ID(ID)?.JobNumber;
            ((UCQuoteJob)LoadedControl).CurrentQuoteJob = App.DB.QuoteJob.Get(ID);
            ((UCQuoteJob)LoadedControl).CurrentSite = App.DB.Sites.Get(Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(1)));
            ((UCQuoteJob)LoadedControl).LoadDepartment();
            LoadForm(sender, e, this);
            ((UCQuoteJob)LoadedControl).SetupPartsAndProductsDataGrid();
            ((UCQuoteJob)LoadedControl).SetupScheduleOfRatesDataGrid();
            ShowButton();
            if (!string.IsNullOrWhiteSpace(convertedJobNumber))
            {
                btnConvert.Text = convertedJobNumber;
                btnConvert.Enabled = false;
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
                    Text = "Quote Job : Adding New...";
                }
                else
                {
                    PageState = Entity.Sys.Enums.FormState.Update;
                    Text = "Quote Job : ID " + ID;
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

        private Entity.Jobs.Job _Job;

        private Entity.Jobs.Job Job
        {
            get
            {
                return _Job;
            }

            set
            {
                _Job = value;
            }
        }

        private void FRMQuoteJob_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
                ((UCQuoteJob)LoadedControl).CurrentQuoteJob = App.DB.QuoteJob.Get(ID);
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

        private void btnViewJob_Click(object sender, EventArgs e)
        {
            var switchExpr = (Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(btnViewJob.Tag);
            switch (switchExpr)
            {
                case Entity.Sys.Enums.QuoteContractStatus.Accepted:
                    {
                        App.ShowForm(typeof(FRMLogCallout), true, new object[] { Job.JobID, Job.PropertyID, this });
                        break;
                    }

                case Entity.Sys.Enums.QuoteContractStatus.Rejected:
                    {
                        App.ShowForm(typeof(FRMQuoteRejection), true, new object[] { TheLoadedControl, ((UCQuoteJob)TheLoadedControl).CurrentQuoteJob.ReasonForReject, ((UCQuoteJob)TheLoadedControl).CurrentQuoteJob.ReasonForRejectID });
                        break;
                    }

                case Entity.Sys.Enums.QuoteContractStatus.Generated:
                    {
                        break;
                    }
            }
        }

        private void btnViewSite_Click(object sender, EventArgs e)
        {
            // ShowForm(GetType(FRMSite), True, New Object() {Job.PropertyID, Me})
            App.ShowForm(typeof(FRMSite), true, new object[] { ((UCQuoteJob)LoadedControl).CurrentSite.SiteID, this });
        }

        private void ShowButton()
        {
            var switchExpr = (Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(((UCQuoteJob)TheLoadedControl).CurrentQuoteJob.StatusEnumID);
            switch (switchExpr)
            {
                case Entity.Sys.Enums.QuoteContractStatus.Accepted:
                    {
                        Job = App.DB.Job.Job_Get_For_Quote_ID(ID);
                        btnViewJob.Tag = Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Accepted);
                        btnViewJob.Text = "View Job";
                        btnViewJob.Visible = Job is object;
                        break;
                    }

                case Entity.Sys.Enums.QuoteContractStatus.Rejected:
                    {
                        btnViewJob.Tag = Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Rejected);
                        btnViewJob.Text = "View Reason";
                        btnViewJob.Visible = true;
                        break;
                    }

                case Entity.Sys.Enums.QuoteContractStatus.Generated:
                    {
                        btnViewJob.Visible = false;
                        btnViewJob.Tag = Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Generated);
                        break;
                    }
            }
        }

        private void FRMQuoteJob_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseTheForm();
        }

        private void CloseTheForm()
        {
            if (((UCQuoteJob)TheLoadedControl).QuoteNumberUsed == false)
            {
                App.DB.QuoteJob.DeleteReservedQuoteNumber(((UCQuoteJob)TheLoadedControl).QuoteNumber.Number);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            btnConvert.Enabled = false;
            string jobNumber = ((UCQuoteJob)TheLoadedControl).QuoteJob_Create_InstallJob();
            btnConvert.Text = jobNumber.Length > 0 ? jobNumber : btnConvert.Text;
            btnConvert.Enabled = !(jobNumber.Length > 0);
        }
    }
}