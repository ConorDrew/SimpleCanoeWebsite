using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMContractWiz : FRMBaseForm, IForm
    {
        public FRMContractWiz() : base()
        {
            base.Load += FRMContract_Load;
            base.Closing += FRMContractOriginal_Closing;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCContractWiz();
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

        public Button btnSave
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

        private Button _Button1;

        public Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        private Button _btnReprintExpiry;

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
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._pnlMain = new System.Windows.Forms.Panel();
            this._Button1 = new System.Windows.Forms.Button();
            this._btnReprintExpiry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnSave.Location = new System.Drawing.Point(905, 734);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(171, 25);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Create Contract";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnClose.Location = new System.Drawing.Point(12, 734);
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
            this._pnlMain.Size = new System.Drawing.Size(1076, 713);
            this._pnlMain.TabIndex = 1;
            // 
            // _Button1
            // 
            this._Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Button1.Location = new System.Drawing.Point(714, 734);
            this._Button1.Name = "_Button1";
            this._Button1.Size = new System.Drawing.Size(171, 25);
            this._Button1.TabIndex = 4;
            this._Button1.Text = "Print Documentation";
            this._Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // _btnReprintExpiry
            // 
            this._btnReprintExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReprintExpiry.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnReprintExpiry.Location = new System.Drawing.Point(522, 731);
            this._btnReprintExpiry.Name = "_btnReprintExpiry";
            this._btnReprintExpiry.Size = new System.Drawing.Size(171, 25);
            this._btnReprintExpiry.TabIndex = 5;
            this._btnReprintExpiry.Text = "Print Expiry";
            this._btnReprintExpiry.Click += new System.EventHandler(this.btnReprintExpiry_Click);
            // 
            // FRMContractWiz
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1084, 771);
            this.Controls.Add(this._btnReprintExpiry);
            this.Controls.Add(this._Button1);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._pnlMain);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 810);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 810);
            this.Name = "FRMContractWiz";
            this.Text = "Contract : ID {0}";
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            IDToLinkTo = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(1));

            // CType(LoadedControl, UCContractWiz).SetupMainDataGrid()
            // CType(LoadedControl, UCContractWiz).SetupInvoiceAddressDataGrid()
            ((UCContractWiz)LoadedControl).CurrentContract = App.DB.ContractOriginal.Get(ID);
            ((UCContractWiz)LoadedControl).IDToLinkTo = IDToLinkTo;
            ((UCContractWiz)LoadedControl).SiteID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(2));

            // If IDToLinkTo = Entity.Sys.Enums.Customer.Domestic Then
            // Try
            // If ID > 0 Then
            // Dim dr As DataRow() = CType(LoadedControl, UCContractWiz).Sites.Table.Select("tick=1")

            // CType(LoadedControl, UCContractWiz).SiteID = Entity.Sys.Helper.MakeIntegerValid(dr(0).Item("SiteID"))
            // Else
            // CType(LoadedControl, UCContractWiz).SiteID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(2))
            // End If
            // Catch ex As Exception
            // ShowForm(GetType(FRMQuoteJobSelectASite), True, New Object() {IDToLinkTo, Me})
            // End Try

            // End If
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
                }
                else
                {
                    PageState = Entity.Sys.Enums.FormState.Update;
                    Text = "Contract : ID " + ID;
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
                ((UCContractWiz)LoadedControl).CurrentContract = App.DB.ContractOriginal.Get(ID);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ((UCContractWiz)LoadedControl).ProcessContracts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (((UCContractWiz)LoadedControl).NumberUsed == false & ((UCContractWiz)LoadedControl).Number is object)
            {
                App.DB.Job.DeleteReservedOrderNumber(((UCContractWiz)LoadedControl).Number.Number, ((UCContractWiz)LoadedControl).Number.Prefix);
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

        private void FRMContractOriginal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var type = get_GetParameter(2)?.GetType();
            if (type == typeof(FRMContractManager))
            {
                ((FRMContractManager)get_GetParameter(2)).PopulateDatagrid();
            }
        }

        private void btnReprintExpiry_Click(object sender, EventArgs e)
        {
            ((UCContractWiz)LoadedControl).ProcessExpiry();
        }
    }
}