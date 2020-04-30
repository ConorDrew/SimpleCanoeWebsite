using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMOrder : FRMBaseForm, IForm
    {
        

        public FRMOrder() : base()
        {
            
            
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
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._pnlMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            //
            // _btnSave
            //
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Location = new System.Drawing.Point(8, 612);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 25);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // _btnClose
            //
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(75, 613);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 25);
            this._btnClose.TabIndex = 3;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // _pnlMain
            //
            this._pnlMain.AutoSize = true;
            this._pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlMain.Location = new System.Drawing.Point(0, 0);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Padding = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this._pnlMain.Size = new System.Drawing.Size(833, 650);
            this._pnlMain.TabIndex = 1;
            //
            // FRMOrder
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(833, 650);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._pnlMain);
            this.MinimumSize = new System.Drawing.Size(841, 684);
            this.Name = "FRMOrder";
            this.Text = "Order : ID {0}";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this._pnlMain, 0);
            this.Controls.SetChildIndex(this._btnSave, 0);
            this.Controls.SetChildIndex(this._btnClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        
        

        public void LoadMe(object sender, EventArgs e)
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

        
        

        private void CloseTheForm()
        {
            if (((UCOrder)TheLoadedControl).OrderNumberUsed == false)
            {
                App.DB.Job.DeleteReservedOrderNumber(((UCOrder)TheLoadedControl).OrderNumber.Number, ((UCOrder)TheLoadedControl).OrderNumber.Prefix);
            }
        }

        
    }
}