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
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _pnlMain = new Panel();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _btnReprintExpiry = new Button();
            _btnReprintExpiry.Click += new EventHandler(btnReprintExpiry_Click);
            SuspendLayout();
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSave.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnSave.Location = new Point(905, 734);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(171, 25);
            _btnSave.TabIndex = 2;
            _btnSave.Text = "Create Contract";
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnClose.Location = new Point(12, 734);
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
            _pnlMain.Size = new Size(1076, 693);
            _pnlMain.TabIndex = 1;
            //
            // Button1
            //
            _Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Button1.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Button1.Location = new Point(714, 734);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(171, 25);
            _Button1.TabIndex = 4;
            _Button1.Text = "Print Documentation";
            //
            // btnReprintExpiry
            //
            _btnReprintExpiry.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReprintExpiry.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnReprintExpiry.Location = new Point(522, 731);
            _btnReprintExpiry.Name = "btnReprintExpiry";
            _btnReprintExpiry.Size = new Size(171, 25);
            _btnReprintExpiry.TabIndex = 5;
            _btnReprintExpiry.Text = "Print Expiry";
            //
            // FRMContractWiz
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1084, 771);
            Controls.Add(_btnReprintExpiry);
            Controls.Add(_Button1);
            Controls.Add(_btnClose);
            Controls.Add(_btnSave);
            Controls.Add(_pnlMain);
            MaximizeBox = false;
            MaximumSize = new Size(1100, 810);
            MinimizeBox = false;
            MinimumSize = new Size(1100, 810);
            Name = "FRMContractWiz";
            Text = "Contract : ID {0}";
            Controls.SetChildIndex(_pnlMain, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_Button1, 0);
            Controls.SetChildIndex(_btnReprintExpiry, 0);
            ResumeLayout(false);
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