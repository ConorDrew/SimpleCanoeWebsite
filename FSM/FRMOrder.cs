// Decompiled with JetBrains decompiler
// Type: FSM.FRMOrder
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.QuoteOrders;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMOrder : FRMBaseForm, IForm
  {
    private IContainer components;
    private IUserControl TheLoadedControl;
    private int _ID;
    private Enums.FormState _pageState;

    public FRMOrder()
    {
      this.Load += new EventHandler(this.FRMOrder_Load);
      this.Closing += new CancelEventHandler(this.FRMOrder_Closing);
      this._ID = 0;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCOrder();
      this.pnlMain.Controls.Add((Control) this.TheLoadedControl);
      ((UCOrder) this.TheLoadedControl).FormClose += new UCOrder.FormCloseEventHandler(this.CloseTheForm);
      this.LoadedControl.StateChanged += new IUserControl.StateChangedEventHandler(this.ResetMe);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    internal virtual Panel pnlMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnSave = new Button();
      this.btnClose = new Button();
      this.pnlMain = new Panel();
      this.SuspendLayout();
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Location = new System.Drawing.Point(8, 612);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 25);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(75, 613);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 25);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlMain.Location = new System.Drawing.Point(0, 32);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new Size(825, 570);
      this.pnlMain.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(833, 650);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.pnlMain);
      this.MinimumSize = new Size(841, 684);
      this.Name = nameof (FRMOrder);
      this.Text = "Order : ID {0}";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.pnlMain, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ((UCOrder) this.LoadedControl).ucJobOrder.SetupVisitsDataGrid();
      ((UCOrder) this.LoadedControl).SetupProductsDatagrid();
      ((UCOrder) this.LoadedControl).SetupPartsDatagrid();
      ((UCOrder) this.LoadedControl).SetupPriceRequestDatagrid();
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      ((UCOrder) this.LoadedControl).PassedID = Conversions.ToInteger(this.get_GetParameter(1));
      ((UCOrder) this.LoadedControl).CurrentOrder = App.DB.Order.Order_Get(this.ID);
      if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(2))) > 0)
      {
        UCOrder loadedControl = (UCOrder) this.LoadedControl;
        ComboBox cboOrderTypeId = loadedControl.cboOrderTypeID;
        Combo.SetSelectedComboItem_By_Value(ref cboOrderTypeId, Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(2)))));
        loadedControl.cboOrderTypeID = cboOrderTypeId;
        ((UCOrder) this.LoadedControl).cboOrderTypeID.Enabled = false;
        if (((UCOrder) this.LoadedControl).PassedID == 0)
        {
          ((UCOrder) this.LoadedControl).ucJobOrder.EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Get(Conversions.ToInteger(this.get_GetParameter(1)));
          ((UCOrder) this.LoadedControl).ucJobOrder.txtJobSearch.Enabled = false;
          ((UCOrder) this.LoadedControl).ucJobOrder.btnSearch.Enabled = false;
          ((UCOrder) this.LoadedControl).lblOrderStatus.Text = "PLEASE SAVE BASE ORDER DETAILS BEFORE ADDING ITEMS";
          ((UCOrder) this.LoadedControl).lblOrderStatus.Visible = true;
        }
        else
        {
          switch ((Enums.OrderType) Conversions.ToInteger(this.get_GetParameter(2)))
          {
            case Enums.OrderType.Customer:
              QuoteOrder quoteOrder = (QuoteOrder) this.get_GetParameter(3);
              ((UCOrder) this.LoadedControl).txtOrderReference.Text = quoteOrder.CustomerRef;
              ((UCOrder) this.LoadedControl).txtOrderReference.ReadOnly = true;
              ((UCOrder) this.LoadedControl).dtpDatePlaced.Enabled = false;
              if (DateTime.Compare(quoteOrder.DeliveryDeadline, DateTime.MinValue) == 0)
              {
                ((UCOrder) this.LoadedControl).chkDeadlineNA.Checked = true;
                ((UCOrder) this.LoadedControl).dtpDeliveryDeadline.Enabled = false;
              }
              else
              {
                ((UCOrder) this.LoadedControl).chkDeadlineNA.Checked = false;
                ((UCOrder) this.LoadedControl).dtpDeliveryDeadline.Enabled = true;
                ((UCOrder) this.LoadedControl).dtpDeliveryDeadline.Value = quoteOrder.DeliveryDeadline;
              }
              ((UCOrder) this.LoadedControl).ucCustomerOrder.Customer = App.DB.Customer.Customer_Get(quoteOrder.CustomerID);
              ((UCOrder) this.LoadedControl).ucCustomerOrder.theProperty = App.DB.Sites.Get((object) quoteOrder.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
              ((UCOrder) this.LoadedControl).lblOrderStatus.Text = "";
              ((UCOrder) this.LoadedControl).lblOrderStatus.Visible = false;
              ((UCOrder) this.LoadedControl).ucJobOrder.Enabled = false;
              this.LoadedControl.Save();
              ((UCOrder) this.LoadedControl).CurrentOrder = App.DB.Order.Order_Get(this.ID);
              ((UCOrder) this.LoadedControl).tcOrderDetails.SelectedTab = ((UCOrder) this.LoadedControl).tabParts;
              break;
            case Enums.OrderType.Job:
              ((UCOrder) this.LoadedControl).ucJobOrder.txtJobSearch.Enabled = false;
              ((UCOrder) this.LoadedControl).ucJobOrder.btnSearch.Enabled = false;
              ((UCOrder) this.LoadedControl).txtOrderReference.ReadOnly = true;
              ((UCOrder) this.LoadedControl).dtpDatePlaced.Enabled = false;
              ((UCOrder) this.LoadedControl).chkDeadlineNA.Checked = true;
              ((UCOrder) this.LoadedControl).chkDeadlineNA.Enabled = false;
              ((UCOrder) this.LoadedControl).lblOrderStatus.Text = "";
              ((UCOrder) this.LoadedControl).lblOrderStatus.Visible = false;
              ((UCOrder) this.LoadedControl).ucJobOrder.Enabled = false;
              ((UCOrder) this.LoadedControl).ucJobOrder.EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Get(Conversions.ToInteger(this.get_GetParameter(1)));
              ((UCOrder) this.LoadedControl).txtOrderReference.Text = Conversions.ToString(Operators.ConcatenateObject((object) "VisitOrder-", ((UCOrder) this.LoadedControl).ucJobOrder.EngineerVisitsDataView.Table.Rows[0]["EngineerVisitID"]));
              this.LoadedControl.Save();
              ((UCOrder) this.LoadedControl).CurrentOrder = App.DB.Order.Order_Get(this.ID);
              ((UCOrder) this.LoadedControl).tcOrderDetails.SelectedTab = ((UCOrder) this.LoadedControl).tabParts;
              break;
          }
        }
      }
      ((UCOrder) this.LoadedControl).SetupItemsIncludedDatagrid();
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) this.pnlMain.Controls[0];
      }
    }

    public void ResetMe(int newID)
    {
      this.ID = newID;
    }

    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
        if (this.ID == 0)
        {
          this.PageState = Enums.FormState.Insert;
          this.Text = "Order : Adding New...";
          this.btnSave.Enabled = true;
        }
        else
        {
          this.PageState = Enums.FormState.Update;
          this.Text = "Order : ID " + Conversions.ToString(this.ID);
          this.btnSave.Enabled = true;
        }
      }
    }

    private Enums.FormState PageState
    {
      get
      {
        return this._pageState;
      }
      set
      {
        this._pageState = value;
      }
    }

    private void FRMOrder_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void FRMOrder_Closing(object sender, CancelEventArgs e)
    {
      this.CloseTheForm();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.LoadedControl.Save())
        return;
      ((UCOrder) this.LoadedControl).CurrentOrder = App.DB.Order.Order_Get(this.ID);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void CloseTheForm()
    {
      if (((UCOrder) this.TheLoadedControl).OrderNumberUsed)
        return;
      App.DB.Job.DeleteReservedOrderNumber(((UCOrder) this.TheLoadedControl).OrderNumber.JobNumber, ((UCOrder) this.TheLoadedControl).OrderNumber.Prefix);
    }
  }
}
