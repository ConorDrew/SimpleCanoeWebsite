using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMContractOriginal : FRMBaseForm, IForm
    {
        public FRMContractOriginal() : base()
        {
            base.Load += FRMContract_Load;
            base.Closing += FRMContractOriginal_Closing;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCContractOriginal();
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
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._pnlMain = new System.Windows.Forms.Panel();
            this._btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Location = new System.Drawing.Point(8, 656);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 25);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(72, 656);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 25);
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
            this._pnlMain.Size = new System.Drawing.Size(784, 636);
            this._pnlMain.TabIndex = 1;
            // 
            // _btnPrint
            // 
            this._btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPrint.Location = new System.Drawing.Point(728, 656);
            this._btnPrint.Name = "_btnPrint";
            this._btnPrint.Size = new System.Drawing.Size(56, 25);
            this._btnPrint.TabIndex = 4;
            this._btnPrint.Text = "Print";
            this._btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FRMContractOriginal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(792, 694);
            this.Controls.Add(this._btnPrint);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 728);
            this.Name = "FRMContractOriginal";
            this.Text = "Contract : ID {0}";
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            IDToLinkTo = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(1));
            int readyToBeInvoiceID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(2));
            ((UCContractOriginal)LoadedControl).SetupSitesDataGrid();
            ((UCContractOriginal)LoadedControl).SetupInvoiceAddressDataGrid();
            ((UCContractOriginal)LoadedControl).CurrentContract = App.DB.ContractOriginal.Get(ID);
            ((UCContractOriginal)LoadedControl).IDToLinkTo = IDToLinkTo;
            ((UCContractOriginal)LoadedControl).InvoiceToBeRaised = App.DB.InvoiceToBeRaised.InvoiceToBeRaised_Get(readyToBeInvoiceID);
            if (IDToLinkTo == (int)Entity.Sys.Enums.Customer.Domestic)
            {
                try
                {
                    if (ID > 0)
                    {
                        var dr = ((UCContractOriginal)LoadedControl).Sites.Table.Select("tick=1");
                        ((UCContractOriginal)LoadedControl).SiteID = Entity.Sys.Helper.MakeIntegerValid(dr[0]["SiteID"]);
                    }
                    else
                    {
                        ((UCContractOriginal)LoadedControl).SiteID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(2));
                    }
                }
                catch (Exception ex)
                {
                    App.ShowForm(typeof(FRMQuoteJobSelectASite), true, new object[] { IDToLinkTo, this });
                }
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
                    Text = "Contract : Adding New...";
                    btnPrint.Visible = false;
                }
                else
                {
                    PageState = Entity.Sys.Enums.FormState.Update;
                    Text = "Contract : ID " + ID;
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

        private void FRMContract_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
                ((UCContractOriginal)LoadedControl).CurrentContract = App.DB.ContractOriginal.Get(ID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (((UCContractOriginal)LoadedControl).NumberUsed == false & ((UCContractOriginal)LoadedControl).Number is object)
            {
                App.DB.Job.DeleteReservedOrderNumber(((UCContractOriginal)LoadedControl).Number.Number, ((UCContractOriginal)LoadedControl).Number.Prefix);
            }

            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var dtContracts = App.DB.ContractOriginal.ProcessContract(ID);

            if (dtContracts.Rows.Count < 1)
            {
                App.ShowMessage("Contract is not assigned to any properties, unable to print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;

            }
            var details = new ArrayList() { dtContracts };
            var oPrint = new Entity.Sys.Printing(details, ((UCContractOriginal)LoadedControl).CurrentContract.ContractReference.Trim() + " ", Entity.Sys.Enums.SystemDocumentType.ContractOption1);
        }

        private void FRMContractOriginal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var type = get_GetParameter(2)?.GetType();
            if (type == typeof(FRMContractManager))
            {
                ((FRMContractManager)get_GetParameter(2)).PopulateDatagrid();
            }
        }
    }
}