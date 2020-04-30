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

        internal Button btnViewSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnViewSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnViewSite != null)
                {
                    _btnViewSite.Click -= btnViewSite_Click;
                }

                _btnViewSite = value;
                if (_btnViewSite != null)
                {
                    _btnViewSite.Click += btnViewSite_Click;
                }
            }
        }

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
            _pnlMain = new Panel();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _btnViewJob = new Button();
            _btnViewJob.Click += new EventHandler(btnViewJob_Click);
            _btnViewSite = new Button();
            _btnViewSite.Click += new EventHandler(btnViewSite_Click);
            _btnConvert = new Button();
            _btnConvert.Click += new EventHandler(btnConvert_Click);
            SuspendLayout();
            //
            // pnlMain
            //
            _pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _pnlMain.Location = new Point(0, 32);
            _pnlMain.Name = "pnlMain";
            _pnlMain.Size = new Size(1184, 708);
            _pnlMain.TabIndex = 1;
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSave.Location = new Point(8, 747);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 23);
            _btnSave.TabIndex = 2;
            _btnSave.Text = "Save";
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(72, 747);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 23);
            _btnClose.TabIndex = 3;
            _btnClose.Text = "Close";
            //
            // btnViewJob
            //
            _btnViewJob.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnViewJob.Location = new Point(808, 747);
            _btnViewJob.Name = "btnViewJob";
            _btnViewJob.Size = new Size(88, 24);
            _btnViewJob.TabIndex = 5;
            _btnViewJob.Text = "View Job";
            _btnViewJob.Visible = false;
            //
            // btnViewSite
            //
            _btnViewSite.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnViewSite.Location = new Point(134, 747);
            _btnViewSite.Name = "btnViewSite";
            _btnViewSite.Size = new Size(100, 24);
            _btnViewSite.TabIndex = 7;
            _btnViewSite.Text = "View Property";
            //
            // btnConvert
            //
            _btnConvert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnConvert.Location = new Point(1022, 747);
            _btnConvert.Name = "btnConvert";
            _btnConvert.Size = new Size(92, 23);
            _btnConvert.TabIndex = 8;
            _btnConvert.Text = "Convert";
            //
            // FRMQuoteJob
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1184, 781);
            Controls.Add(_btnConvert);
            Controls.Add(_btnViewSite);
            Controls.Add(_btnViewJob);
            Controls.Add(_btnClose);
            Controls.Add(_btnSave);
            Controls.Add(_pnlMain);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1200, 820);
            Name = "FRMQuoteJob";
            Text = "Quote Job : ID {0}";
            Controls.SetChildIndex(_pnlMain, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_btnViewJob, 0);
            Controls.SetChildIndex(_btnViewSite, 0);
            Controls.SetChildIndex(_btnConvert, 0);
            ResumeLayout(false);
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