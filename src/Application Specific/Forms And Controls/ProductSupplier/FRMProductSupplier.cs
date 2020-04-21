using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMProductSupplier : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMProductSupplier() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMProductSupplier_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCProductSupplier();
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
            _btnSave.Location = new Point(8, 159);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 25);
            _btnSave.TabIndex = 2;
            _btnSave.Text = "Save";
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(72, 159);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 25);
            _btnClose.TabIndex = 3;
            _btnClose.Text = "Close";
            //
            // pnlMain
            //
            _pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _pnlMain.Location = new Point(6, 32);
            _pnlMain.Name = "pnlMain";
            _pnlMain.Size = new Size(586, 120);
            _pnlMain.TabIndex = 1;
            //
            // FRMProductSupplier
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(603, 197);
            Controls.Add(_btnClose);
            Controls.Add(_btnSave);
            Controls.Add(_pnlMain);
            MaximizeBox = false;
            MaximumSize = new Size(611, 231);
            MinimizeBox = false;
            MinimumSize = new Size(611, 231);
            Name = "FRMProductSupplier";
            Text = "Product Supplier : ID {0}";
            Controls.SetChildIndex(_pnlMain, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnClose, 0);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            ((UCProductSupplier)LoadedControl).ProductID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(1));
            ((UCProductSupplier)LoadedControl).CurrentProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(ID);
            LoadForm(sender, e, this);
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
            ((UCProduct)get_GetParameter(2)).PopulateSuppliers();
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
                    Text = "Product Supplier : Adding New...";
                }
                else
                {
                    PageState = Entity.Sys.Enums.FormState.Update;
                    Text = "Product Supplier : ID " + ID;
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

        private void FRMProductSupplier_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
                ((UCProductSupplier)LoadedControl).CurrentProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(ID);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}