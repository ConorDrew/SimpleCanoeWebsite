﻿using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMContractOriginalSite : FRMBaseForm, IForm
    {
        

        public FRMContractOriginalSite() : base()
        {
            
            
            base.Load += FRMContractSite_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCContractOriginalSite();
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
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _pnlMain = new Panel();
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
            _pnlMain.Size = new Size(942, 616);
            _pnlMain.TabIndex = 1;
            //
            // FRMContractOriginalSite
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(950, 694);
            Controls.Add(_btnClose);
            Controls.Add(_btnSave);
            Controls.Add(_pnlMain);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(958, 728);
            Name = "FRMContractOriginalSite";
            Text = "Contract Property : ID {0}";
            Controls.SetChildIndex(_pnlMain, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnClose, 0);
            ResumeLayout(false);
        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            SiteID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(1));
            CurrentContract = (Entity.ContractsOriginal.ContractOriginal)get_GetParameter(2);
            try
            {
                OldContractSiteID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(4));
            }
            catch (Exception ex)
            {
                // do nothing
            } ((UCContractOriginalSite)LoadedControl).SiteID = SiteID;
            ((UCContractOriginalSite)LoadedControl).CurrentContract = CurrentContract;
            ((UCContractOriginalSite)LoadedControl).OldContractSite = App.DB.ContractOriginalSite.Get(OldContractSiteID);
            ((UCContractOriginalSite)LoadedControl).CurrentContractSite = App.DB.ContractOriginalSite.Get(ID);
            ((UCContractOriginalSite)LoadedControl).PopAssets();
            LoadForm(sender, e, this);
            ((UCContractOriginalSite)LoadedControl).SetupAssetsDataGrid();
            ((UCContractOriginalSite)LoadedControl).SetupVisitDataGrid();
            ((UCContractOriginalSite)LoadedControl).SetupVisit2DataGrid();
            ((UCContractOriginalSite)LoadedControl).SetupScheduleOfRatesDataGrid();
            ((UCContractOriginalSite)LoadedControl).SetupSystemRatesDataGrid();
            Location = new Point(Conversions.ToInteger(((Control)get_GetParameter(3)).Location.X + 50), Conversions.ToInteger(((Control)get_GetParameter(3)).Location.Y));
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
                    Text = "Contract Property : Adding New...";
                }
                else
                {
                    PageState = Entity.Sys.Enums.FormState.Update;
                    Text = "Contract Property : ID " + ID;
                }
            }
        }

        private int _SiteID = 0;

        private int SiteID
        {
            get
            {
                return _SiteID;
            }

            set
            {
                _SiteID = value;
            }
        }

        private int _OldContractSiteID = 0;

        private int OldContractSiteID
        {
            get
            {
                return _OldContractSiteID;
            }

            set
            {
                _OldContractSiteID = value;
            }
        }

        private Entity.ContractsOriginal.ContractOriginal _CurrentContract;

        public Entity.ContractsOriginal.ContractOriginal CurrentContract
        {
            get
            {
                return _CurrentContract;
            }

            set
            {
                _CurrentContract = value;
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

        private void FRMContractSite_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
                ((UCContractOriginalSite)LoadedControl).CurrentContractSite = App.DB.ContractOriginalSite.Get(ID);
                ((UCContractOriginalSite)LoadedControl).PopAssets();
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