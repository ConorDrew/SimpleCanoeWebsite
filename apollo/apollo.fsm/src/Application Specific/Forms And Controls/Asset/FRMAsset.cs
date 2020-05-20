using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMAsset : FRMBaseForm, IForm
    {
        

        public FRMAsset() : base()
        {
            
            
            base.Load += FRMAsset_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCAsset();
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._pnlMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Location = new System.Drawing.Point(8, 675);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 25);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(72, 675);
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
            this._pnlMain.Location = new System.Drawing.Point(6, 12);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(775, 658);
            this._pnlMain.TabIndex = 1;
            // 
            // FRMAsset
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(786, 713);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(656, 601);
            this.Name = "FRMAsset";
            this.Text = "Asset : ID {0}";
            this.ResumeLayout(false);

        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            try
            {
                ((UCAsset)LoadedControl).LoadProductID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(1));
                ((UCAsset)LoadedControl).LoadSiteID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(2));
            }
            catch (Exception ex)
            {
                // Yes an empty try - ALP
            } ((UCAsset)LoadedControl).CurrentAsset = App.DB.Asset.Asset_Get(ID);
            LoadForm(sender, e, this);
            ((UCAsset)LoadedControl).SetupJobsDataGrid();
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
                    Text = "Asset : Adding New...";
                }
                else
                {
                    PageState = Entity.Sys.Enums.FormState.Update;
                    var oSite = new Entity.Sites.Site();
                    oSite = App.DB.Sites.Get(ID, Entity.Sites.SiteSQL.GetBy.Asset);
                    var oCust = new Entity.Customers.Customer();
                    oCust = App.DB.Customer.Customer_Get_ForSiteID(oSite.SiteID);
                    Text = "Asset : ID " + ID + " for Property: " + oSite.Name + ", " + oSite.Postcode + ", Customer: " + oCust.Name + ", Acc: " + oCust.AccountNumber;
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

        private void FRMAsset_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
                if (((UCAsset)LoadedControl).LoadSiteID > 0)
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
                else
                {
                    ((UCAsset)LoadedControl).CurrentAsset = App.DB.Asset.Asset_Get(ID);
                }
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

        
    }
}