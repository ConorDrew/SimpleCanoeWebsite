using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMOrder : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMOrder() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMOrder_Load;
            base.Closing += FRMOrder_Closing;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCOrder();
            pnlMain.Controls.Add((Control)TheLoadedControl);
            ((UCOrder)TheLoadedControl).FormClose += CloseTheForm;
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
            _btnSave.Location = new Point(8, 612);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 25);
            _btnSave.TabIndex = 2;
            _btnSave.Text = "Save";
            // 
            // btnClose
            // 
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(75, 613);
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
            _pnlMain.Size = new Size(825, 570);
            _pnlMain.TabIndex = 1;
            // 
            // FRMOrder
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(833, 650);
            Controls.Add(_btnClose);
            Controls.Add(_btnSave);
            Controls.Add(_pnlMain);
            MinimumSize = new Size(841, 684);
            Name = "FRMOrder";
            Text = "Order : ID {0}";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_pnlMain, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnClose, 0);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            ((UCOrder)LoadedControl).ucJobOrder.SetupVisitsDataGrid();
            ((UCOrder)LoadedControl).SetupProductsDatagrid();
            ((UCOrder)LoadedControl).SetupPartsDatagrid();
            ((UCOrder)LoadedControl).SetupPriceRequestDatagrid();
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            ((UCOrder)LoadedControl).PassedID = Conversions.ToInteger(get_GetParameter(1));
            ((UCOrder)LoadedControl).CurrentOrder = App.DB.Order.Order_Get(ID);
            if (Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(2)) > 0)
            {
                var argcombo = ((UCOrder)LoadedControl).cboOrderTypeID;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(2)).ToString());
                ((UCOrder)LoadedControl).cboOrderTypeID.Enabled = false;
                if (((UCOrder)LoadedControl).PassedID == 0)
                {
                    ((UCOrder)LoadedControl).ucJobOrder.EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Get(Conversions.ToInteger(get_GetParameter(1)));
                    ((UCOrder)LoadedControl).ucJobOrder.txtJobSearch.Enabled = false;
                    ((UCOrder)LoadedControl).ucJobOrder.btnSearch.Enabled = false;
                    ((UCOrder)LoadedControl).lblOrderStatus.Text = "PLEASE SAVE BASE ORDER DETAILS BEFORE ADDING ITEMS";
                    ((UCOrder)LoadedControl).lblOrderStatus.Visible = true;
                }
                else
                {
                    var switchExpr = (Entity.Sys.Enums.OrderType)Conversions.ToInteger(get_GetParameter(2));
                    switch (switchExpr)
                    {
                        case Entity.Sys.Enums.OrderType.Job:
                            {
                                ((UCOrder)LoadedControl).ucJobOrder.txtJobSearch.Enabled = false;
                                ((UCOrder)LoadedControl).ucJobOrder.btnSearch.Enabled = false;
                                ((UCOrder)LoadedControl).txtOrderReference.ReadOnly = true;
                                ((UCOrder)LoadedControl).dtpDatePlaced.Enabled = false;
                                ((UCOrder)LoadedControl).chkDeadlineNA.Checked = true;
                                ((UCOrder)LoadedControl).chkDeadlineNA.Enabled = false;
                                ((UCOrder)LoadedControl).lblOrderStatus.Text = "";
                                ((UCOrder)LoadedControl).lblOrderStatus.Visible = false;
                                ((UCOrder)LoadedControl).ucJobOrder.Enabled = false;
                                ((UCOrder)LoadedControl).ucJobOrder.EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Get(Conversions.ToInteger(get_GetParameter(1)));
                                ((UCOrder)LoadedControl).txtOrderReference.Text = Conversions.ToString("VisitOrder-" + ((UCOrder)LoadedControl).ucJobOrder.EngineerVisitsDataView.Table.Rows[0]["EngineerVisitID"]);
                                LoadedControl.Save();
                                ((UCOrder)LoadedControl).CurrentOrder = App.DB.Order.Order_Get(ID);
                                ((UCOrder)LoadedControl).tcOrderDetails.SelectedTab = ((UCOrder)LoadedControl).tabParts;
                                break;
                            }

                        case Entity.Sys.Enums.OrderType.Customer:
                            {
                                Entity.QuoteOrders.QuoteOrder oQuoteOrder = (Entity.QuoteOrders.QuoteOrder)get_GetParameter(3);
                                ((UCOrder)LoadedControl).txtOrderReference.Text = oQuoteOrder.CustomerRef;
                                ((UCOrder)LoadedControl).txtOrderReference.ReadOnly = true;
                                ((UCOrder)LoadedControl).dtpDatePlaced.Enabled = false;
                                if (oQuoteOrder.DeliveryDeadline == default)
                                {
                                    ((UCOrder)LoadedControl).chkDeadlineNA.Checked = true;
                                    ((UCOrder)LoadedControl).dtpDeliveryDeadline.Enabled = false;
                                }
                                else
                                {
                                    ((UCOrder)LoadedControl).chkDeadlineNA.Checked = false;
                                    ((UCOrder)LoadedControl).dtpDeliveryDeadline.Enabled = true;
                                    ((UCOrder)LoadedControl).dtpDeliveryDeadline.Value = oQuoteOrder.DeliveryDeadline;
                                } ((UCOrder)LoadedControl).ucCustomerOrder.Customer = App.DB.Customer.Customer_Get(oQuoteOrder.CustomerID);
                                ((UCOrder)LoadedControl).ucCustomerOrder.theProperty = App.DB.Sites.Get(oQuoteOrder.PropertyID);
                                ((UCOrder)LoadedControl).lblOrderStatus.Text = "";
                                ((UCOrder)LoadedControl).lblOrderStatus.Visible = false;
                                ((UCOrder)LoadedControl).ucJobOrder.Enabled = false;
                                LoadedControl.Save();
                                ((UCOrder)LoadedControl).CurrentOrder = App.DB.Order.Order_Get(ID);
                                ((UCOrder)LoadedControl).tcOrderDetails.SelectedTab = ((UCOrder)LoadedControl).tabParts;
                                break;
                            }
                    }
                }
            } ((UCOrder)LoadedControl).SetupItemsIncludedDatagrid();
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
                    Text = "Order : Adding New...";
                    btnSave.Enabled = true;
                }
                else
                {
                    PageState = Entity.Sys.Enums.FormState.Update;
                    Text = "Order : ID " + ID;
                    btnSave.Enabled = true;
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

        private void FRMOrder_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void FRMOrder_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseTheForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
            {
                ((UCOrder)LoadedControl).CurrentOrder = App.DB.Order.Order_Get(ID);
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
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void CloseTheForm()
        {
            if (((UCOrder)TheLoadedControl).OrderNumberUsed == false)
            {
                App.DB.Job.DeleteReservedOrderNumber(((UCOrder)TheLoadedControl).OrderNumber.Number, ((UCOrder)TheLoadedControl).OrderNumber.Prefix);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}