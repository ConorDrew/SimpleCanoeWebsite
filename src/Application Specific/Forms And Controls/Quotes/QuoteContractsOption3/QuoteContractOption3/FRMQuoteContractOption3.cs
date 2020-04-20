using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMQuoteContractOption3 : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMQuoteContractOption3() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMQuoteContractOption3_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCQuoteContractOption3();
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

        private Button _btnViewContract;

        internal Button btnViewContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnViewContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnViewContract != null)
                {
                    _btnViewContract.Click -= btnViewContract_Click;
                }

                _btnViewContract = value;
                if (_btnViewContract != null)
                {
                    _btnViewContract.Click += btnViewContract_Click;
                }
            }
        }

        private Button _btnPrint;

        internal Button btnPrint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrint != null)
                {
                    _btnPrint.Click -= btnPrint_Click;
                }

                _btnPrint = value;
                if (_btnPrint != null)
                {
                    _btnPrint.Click += btnPrint_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _pnlMain = new Panel();
            _btnViewContract = new Button();
            _btnViewContract.Click += new EventHandler(btnViewContract_Click);
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click);
            SuspendLayout();
            // 
            // btnSave
            // 
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSave.Location = new Point(8, 656);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 25);
            _btnSave.TabIndex = 2;
            _btnSave.Text = "Save";
            // 
            // btnClose
            // 
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(72, 656);
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
            _pnlMain.Size = new Size(640, 616);
            _pnlMain.TabIndex = 1;
            // 
            // btnViewContract
            // 
            _btnViewContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnViewContract.Location = new Point(472, 656);
            _btnViewContract.Name = "btnViewContract";
            _btnViewContract.Size = new Size(104, 25);
            _btnViewContract.TabIndex = 5;
            _btnViewContract.Text = "View Contract";
            _btnViewContract.Visible = false;
            // 
            // btnPrint
            // 
            _btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrint.Location = new Point(584, 656);
            _btnPrint.Name = "btnPrint";
            _btnPrint.Size = new Size(55, 25);
            _btnPrint.TabIndex = 6;
            _btnPrint.Text = "Print";
            _btnPrint.Visible = false;
            // 
            // FRMQuoteContractOption3
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(648, 694);
            Controls.Add(_btnPrint);
            Controls.Add(_btnViewContract);
            Controls.Add(_btnClose);
            Controls.Add(_btnSave);
            Controls.Add(_pnlMain);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(656, 728);
            Name = "FRMQuoteContractOption3";
            Text = "Quote Contract Option3 : ID {0}";
            Controls.SetChildIndex(_pnlMain, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_btnViewContract, 0);
            Controls.SetChildIndex(_btnPrint, 0);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            ((UCQuoteContractOption3)LoadedControl).CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.QuoteContractOption3_Get(ID);
            LoadForm(sender, e, this);
            ((UCQuoteContractOption3)LoadedControl).RefreshButton += ShowButton;
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            IDToLinkTo = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(1));
            ((UCQuoteContractOption3)LoadedControl).IDToLinkTo = IDToLinkTo;
            ((UCQuoteContractOption3)LoadedControl).CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.QuoteContractOption3_Get(ID);
            ((UCQuoteContractOption3)LoadedControl).SetupSitesDataGrid();
            ShowButton();
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
                    Text = "Quote Contract : Adding New...";
                    btnPrint.Visible = false;
                }
                else
                {
                    PageState = Entity.Sys.Enums.FormState.Update;
                    Text = "Quote Contract: ID " + ID;
                    btnPrint.Visible = true;
                }
            }
        }

        private int _IDToLinkTo = 0;

        public int IDToLinkTo
        {
            get
            {
                return _IDToLinkTo;
            }

            set
            {
                _IDToLinkTo = value;
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

        private Entity.ContractOption3s.ContractOption3 _Contract;

        private Entity.ContractOption3s.ContractOption3 Contract
        {
            get
            {
                return _Contract;
            }

            set
            {
                _Contract = value;
            }
        }

        private void FRMQuoteContractOption3_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
                ((UCQuoteContractOption3)LoadedControl).CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.QuoteContractOption3_Get(ID);
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

        private void btnViewContract_Click(object sender, EventArgs e)
        {
            var switchExpr = (Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(btnViewContract.Tag);
            switch (switchExpr)
            {
                case Entity.Sys.Enums.QuoteContractStatus.Rejected:
                    {
                        App.ShowForm(typeof(FRMQuoteRejection), true, new object[] { TheLoadedControl, ((UCQuoteContractOption3)TheLoadedControl).CurrentQuoteContractOption3.ReasonForReject });
                        break;
                    }

                case Entity.Sys.Enums.QuoteContractStatus.Generated:
                    {
                        break;
                    }
            }
        }

        private void ShowButton()
        {
            var switchExpr = (Entity.Sys.Enums.QuoteContractStatus)Conversions.ToInteger(((UCQuoteContractOption3)TheLoadedControl).CurrentQuoteContractOption3.QuoteContractStatusID);
            switch (switchExpr)
            {
                case Entity.Sys.Enums.QuoteContractStatus.Accepted:
                    {
                        Contract = App.DB.ContractOption3.ContractOption3_Get_For_Quote_ID(ID);
                        btnViewContract.Tag = Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Accepted);
                        btnViewContract.Text = "View Contract";
                        btnViewContract.Visible = Contract is object;
                        break;
                    }

                case Entity.Sys.Enums.QuoteContractStatus.Rejected:
                    {
                        btnViewContract.Tag = Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Rejected);
                        btnViewContract.Text = "View Reason";
                        btnViewContract.Visible = true;
                        break;
                    }

                case Entity.Sys.Enums.QuoteContractStatus.Generated:
                    {
                        btnViewContract.Visible = false;
                        btnViewContract.Tag = Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Generated);
                        break;
                    }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var details = new ArrayList();
            details.Add(ID);
            var oPrint = new Entity.Sys.Printing(details, ((UCQuoteContractOption3)LoadedControl).CurrentQuoteContractOption3.QuoteContractReference.Trim() + " ", Entity.Sys.Enums.SystemDocumentType.QuoteContractOption3);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}