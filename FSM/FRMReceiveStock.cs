// Decompiled with JetBrains decompiler
// Type: FSM.FRMReceiveStock
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Locationss;
using FSM.Entity.OrderLocations;
using FSM.Entity.OrderParts;
using FSM.Entity.OrderProducts;
using FSM.Entity.Orders;
using FSM.Entity.Parts;
using FSM.Entity.PartSuppliers;
using FSM.Entity.PartTransactions;
using FSM.Entity.Products;
using FSM.Entity.ProductSuppliers;
using FSM.Entity.ProductTransactions;
using FSM.Entity.SiteOrders;
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
  public class FRMReceiveStock : FRMBaseForm, IForm
  {
    private IContainer components;
    private Order _oOrder;
    private string _OrderType;
    private int _ID;
    private OrderPart _orderPart;
    private OrderProduct _orderProduct;
    private FSM.Entity.OrderLocationProduct.OrderLocationProduct _orderLocationProduct;
    private FSM.Entity.OrderLocationPart.OrderLocationPart _orderLocationPart;

    public FRMReceiveStock()
    {
      this.Load += new EventHandler(this.FRMReceiveStock_Load);
      this._oOrder = (Order) null;
      this._OrderType = "";
      this._ID = 0;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        Button btnOk1 = this._btnOK;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOK = value;
        Button btnOk2 = this._btnOK;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtQuantityPreviouslyReceived { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTotalquantity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQuantityInput { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLocation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblItemName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblItemNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.lblItemName = new Label();
      this.txtName = new TextBox();
      this.txtNumber = new TextBox();
      this.lblItemNumber = new Label();
      this.Label3 = new Label();
      this.Label4 = new Label();
      this.Label5 = new Label();
      this.txtQuantityPreviouslyReceived = new TextBox();
      this.txtTotalquantity = new TextBox();
      this.txtQuantityInput = new TextBox();
      this.btnOK = new Button();
      this.Label6 = new Label();
      this.txtLocation = new TextBox();
      this.GroupBox1 = new GroupBox();
      this.GroupBox2 = new GroupBox();
      this.GroupBox1.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.SuspendLayout();
      this.lblItemName.Location = new System.Drawing.Point(16, 24);
      this.lblItemName.Name = "lblItemName";
      this.lblItemName.Size = new Size(96, 23);
      this.lblItemName.TabIndex = 2;
      this.lblItemName.Text = "Item Name:";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(136, 26);
      this.txtName.Name = "txtName";
      this.txtName.ReadOnly = true;
      this.txtName.Size = new Size(288, 21);
      this.txtName.TabIndex = 1;
      this.txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNumber.Location = new System.Drawing.Point(136, 56);
      this.txtNumber.Name = "txtNumber";
      this.txtNumber.ReadOnly = true;
      this.txtNumber.Size = new Size(288, 21);
      this.txtNumber.TabIndex = 2;
      this.lblItemNumber.Location = new System.Drawing.Point(16, 56);
      this.lblItemNumber.Name = "lblItemNumber";
      this.lblItemNumber.Size = new Size(96, 23);
      this.lblItemNumber.TabIndex = 4;
      this.lblItemNumber.Text = "Item Number:";
      this.Label3.Location = new System.Drawing.Point(16, 120);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(100, 23);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Total Ordered:";
      this.Label4.Location = new System.Drawing.Point(16, 152);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(104, 23);
      this.Label4.TabIndex = 7;
      this.Label4.Text = "Total Received :";
      this.Label5.Location = new System.Drawing.Point(15, 24);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(124, 23);
      this.Label5.TabIndex = 8;
      this.Label5.Text = "Quantity Received:";
      this.txtQuantityPreviouslyReceived.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtQuantityPreviouslyReceived.Location = new System.Drawing.Point(136, 154);
      this.txtQuantityPreviouslyReceived.Name = "txtQuantityPreviouslyReceived";
      this.txtQuantityPreviouslyReceived.ReadOnly = true;
      this.txtQuantityPreviouslyReceived.Size = new Size(288, 21);
      this.txtQuantityPreviouslyReceived.TabIndex = 5;
      this.txtTotalquantity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTotalquantity.Location = new System.Drawing.Point(136, 122);
      this.txtTotalquantity.Name = "txtTotalquantity";
      this.txtTotalquantity.ReadOnly = true;
      this.txtTotalquantity.Size = new Size(288, 21);
      this.txtTotalquantity.TabIndex = 4;
      this.txtQuantityInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtQuantityInput.Location = new System.Drawing.Point(136, 24);
      this.txtQuantityInput.Name = "txtQuantityInput";
      this.txtQuantityInput.Size = new Size(224, 21);
      this.txtQuantityInput.TabIndex = 6;
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(368, 24);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(56, 23);
      this.btnOK.TabIndex = 7;
      this.btnOK.Text = "OK";
      this.Label6.Location = new System.Drawing.Point(16, 88);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(72, 23);
      this.Label6.TabIndex = 14;
      this.Label6.Text = "Order For:";
      this.txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtLocation.Location = new System.Drawing.Point(136, 90);
      this.txtLocation.Name = "txtLocation";
      this.txtLocation.ReadOnly = true;
      this.txtLocation.Size = new Size(288, 21);
      this.txtLocation.TabIndex = 3;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.lblItemNumber);
      this.GroupBox1.Controls.Add((Control) this.lblItemName);
      this.GroupBox1.Controls.Add((Control) this.Label6);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.txtNumber);
      this.GroupBox1.Controls.Add((Control) this.txtLocation);
      this.GroupBox1.Controls.Add((Control) this.txtName);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.txtTotalquantity);
      this.GroupBox1.Controls.Add((Control) this.txtQuantityPreviouslyReceived);
      this.GroupBox1.Location = new System.Drawing.Point(8, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(432, 184);
      this.GroupBox1.TabIndex = 16;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Stock Details";
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.txtQuantityInput);
      this.GroupBox2.Controls.Add((Control) this.btnOK);
      this.GroupBox2.Controls.Add((Control) this.Label5);
      this.GroupBox2.Location = new System.Drawing.Point(8, 232);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(432, 56);
      this.GroupBox2.TabIndex = 17;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Stock Received";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(448, 302);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.GroupBox1);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(456, 336);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(456, 336);
      this.Name = nameof (FRMReceiveStock);
      this.Text = "Stock Received Manager";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox2, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox2.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.Order = App.DB.Order.Order_Get(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0))));
      this.OrderType = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1)));
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(2)));
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    void IForm.ResetMe(int newID)
    {
    }

    public Order Order
    {
      get
      {
        return this._oOrder;
      }
      set
      {
        this._oOrder = value;
      }
    }

    public string OrderType
    {
      get
      {
        return this._OrderType;
      }
      set
      {
        this._OrderType = value;
        string orderType = this.OrderType;
        if (Operators.CompareString(orderType, "OrderProduct", false) != 0)
        {
          if (Operators.CompareString(orderType, "OrderPart", false) != 0)
          {
            if (Operators.CompareString(orderType, "OrderLocationProduct", false) != 0)
            {
              if (Operators.CompareString(orderType, "OrderLocationPart", false) != 0)
                return;
              this.lblItemName.Text = "Part Name: ";
              this.lblItemNumber.Text = "Part Number: ";
            }
            else
            {
              this.lblItemName.Text = "Product Name: ";
              this.lblItemNumber.Text = "Product Number: ";
            }
          }
          else
          {
            this.lblItemName.Text = "Part Name: ";
            this.lblItemNumber.Text = "Part Number: ";
          }
        }
        else
        {
          this.lblItemName.Text = "Product Name: ";
          this.lblItemNumber.Text = "Product Number: ";
        }
      }
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
        string orderType = this.OrderType;
        if (Operators.CompareString(orderType, "OrderProduct", false) != 0)
        {
          if (Operators.CompareString(orderType, "OrderPart", false) != 0)
          {
            if (Operators.CompareString(orderType, "OrderLocationProduct", false) != 0)
            {
              if (Operators.CompareString(orderType, "OrderLocationPart", false) == 0)
              {
                this.OrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get(this.ID);
                Part part = App.DB.Part.Part_Get(this.OrderLocationPart.PartID);
                this.txtTotalquantity.Text = Conversions.ToString(this.OrderLocationPart.Quantity);
                this.txtQuantityPreviouslyReceived.Text = Conversions.ToString(this.OrderLocationPart.QuantityReceived);
                this.txtName.Text = part.Name;
                this.txtNumber.Text = part.Number;
              }
            }
            else
            {
              this.OrderLocationProduct = App.DB.OrderLocationProduct.OrderLocationProduct_Get(this.ID);
              Product product = App.DB.Product.Product_Get(this.OrderLocationProduct.ProductID);
              this.txtTotalquantity.Text = Conversions.ToString(this.OrderLocationProduct.Quantity);
              this.txtQuantityPreviouslyReceived.Text = Conversions.ToString(this.OrderLocationProduct.QuantityReceived);
              this.txtName.Text = product.Name;
              this.txtNumber.Text = product.Number;
            }
          }
          else
          {
            this.OrderPart = App.DB.OrderPart.OrderPart_Get(this.ID);
            PartSupplier partSupplier = App.DB.PartSupplier.PartSupplier_Get(this.OrderPart.PartSupplierID);
            Part part = App.DB.Part.Part_Get(partSupplier.PartID);
            this.txtTotalquantity.Text = Conversions.ToString(this.OrderPart.Quantity);
            this.txtQuantityPreviouslyReceived.Text = Conversions.ToString(this.OrderPart.QuantityReceived);
            this.txtName.Text = part.Name;
            this.txtNumber.Text = part.Number;
          }
        }
        else
        {
          this.OrderProduct = App.DB.OrderProduct.OrderProduct_Get(this.ID);
          ProductSupplier productSupplier = App.DB.ProductSupplier.ProductSupplier_Get(this.OrderProduct.ProductSupplierID);
          Product product = App.DB.Product.Product_Get(productSupplier.ProductID);
          this.txtTotalquantity.Text = Conversions.ToString(this.OrderProduct.Quantity);
          this.txtQuantityPreviouslyReceived.Text = Conversions.ToString(this.OrderProduct.QuantityReceived);
          this.txtName.Text = product.Name;
          this.txtNumber.Text = product.Number;
        }
        switch (this.Order.OrderTypeID)
        {
          case 1:
            SiteOrder forOrder1 = App.DB.SiteOrder.SiteOrder_GetForOrder(this.Order.OrderID);
            if (forOrder1 != null)
            {
              FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) forOrder1.SiteID, SiteSQL.GetBy.SiteId, (object) null);
              FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(site.CustomerID);
              this.txtLocation.Text = "Property:" + site.Address1 + ", " + site.Postcode + " (" + customer.AccountNumber + ")";
              break;
            }
            FSM.Entity.Customers.Customer forOrder2 = App.DB.Customer.Customer_GetForOrder(this.Order.OrderID);
            this.txtLocation.Text = "Customer:" + forOrder2.Name + " - " + forOrder2.AccountNumber;
            break;
          case 4:
            this.txtLocation.Text = "Engineer Visit";
            break;
          default:
            OrderLocation forOrder3 = App.DB.OrderLocation.OrderLocation_GetForOrder(this.Order.OrderID);
            Locations locations = App.DB.Location.Locations_Get(forOrder3.LocationID);
            if (locations.VanID > 0)
            {
              this.txtLocation.Text = "Van: " + App.DB.Van.Van_Get(locations.VanID).Registration;
              break;
            }
            if (locations.WarehouseID <= 0)
              break;
            this.txtLocation.Text = "Warehouse: " + App.DB.Warehouse.Warehouse_Get(locations.WarehouseID).Name;
            break;
        }
      }
    }

    public OrderPart OrderPart
    {
      get
      {
        return this._orderPart;
      }
      set
      {
        this._orderPart = value;
      }
    }

    public OrderProduct OrderProduct
    {
      get
      {
        return this._orderProduct;
      }
      set
      {
        this._orderProduct = value;
      }
    }

    public FSM.Entity.OrderLocationProduct.OrderLocationProduct OrderLocationProduct
    {
      get
      {
        return this._orderLocationProduct;
      }
      set
      {
        this._orderLocationProduct = value;
      }
    }

    public FSM.Entity.OrderLocationPart.OrderLocationPart OrderLocationPart
    {
      get
      {
        return this._orderLocationPart;
      }
      set
      {
        this._orderLocationPart = value;
      }
    }

    private void FRMReceiveStock_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (!Helper.IsValidInteger((object) this.txtQuantityInput.Text.Trim()))
      {
        int num1 = (int) App.ShowMessage("Please enter the quantity that has been received", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (checked (Conversions.ToInteger(this.txtQuantityInput.Text.Trim()) + Conversions.ToInteger(this.txtQuantityPreviouslyReceived.Text.Trim())) > Conversions.ToInteger(this.txtTotalquantity.Text.Trim()))
      {
        int num2 = (int) App.ShowMessage("Quantity received can not be greater than the quantity ordered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
        this.UpdateOrderItems(Conversions.ToInteger(this.txtQuantityInput.Text.Trim()));
    }

    public void UpdateOrderItems(int QuantityInput)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        string orderType = this.OrderType;
        if (Operators.CompareString(orderType, "OrderProduct", false) != 0)
        {
          if (Operators.CompareString(orderType, "OrderPart", false) != 0)
          {
            if (Operators.CompareString(orderType, "OrderLocationProduct", false) != 0)
            {
              if (Operators.CompareString(orderType, "OrderLocationPart", false) == 0)
              {
                PartTransaction orderLocationPart = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(this.OrderLocationPart.OrderLocationPartID);
                orderLocationPart.SetAmount = (object) checked (orderLocationPart.Amount + QuantityInput);
                App.DB.PartTransaction.Update(orderLocationPart);
                orderLocationPart.SetLocationID = (object) this.OrderLocationPart.LocationID;
                orderLocationPart.SetPartID = (object) this.OrderLocationPart.PartID;
                orderLocationPart.SetOrderLocationPartID = (object) this.OrderLocationPart.OrderLocationPartID;
                orderLocationPart.SetTransactionTypeID = (object) 3;
                orderLocationPart.SetAmount = (object) checked (-QuantityInput);
                App.DB.PartTransaction.Insert(orderLocationPart);
                this.OrderLocationPart.SetQuantityReceived = (object) checked (this.OrderLocationPart.QuantityReceived + QuantityInput);
                App.DB.OrderLocationPart.Update(this.OrderLocationPart);
                switch (this.Order.OrderTypeID)
                {
                  case 3:
                    OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(this.OrderLocationPart.OrderID);
                    orderLocationPart.SetLocationID = (object) forOrder.LocationID;
                    orderLocationPart.SetTransactionTypeID = (object) 2;
                    orderLocationPart.SetOrderLocationPartID = (object) this.OrderLocationPart.OrderLocationPartID;
                    orderLocationPart.SetAmount = (object) QuantityInput;
                    orderLocationPart.SetPartID = (object) this.OrderLocationPart.PartID;
                    App.DB.PartTransaction.Insert(orderLocationPart);
                    break;
                }
              }
            }
            else
            {
              ProductTransaction orderLocationProduct = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(this.OrderLocationProduct.OrderLocationProductID);
              orderLocationProduct.SetAmount = (object) checked (orderLocationProduct.Amount + QuantityInput);
              App.DB.ProductTransaction.Update(orderLocationProduct);
              orderLocationProduct.SetLocationID = (object) this.OrderLocationProduct.LocationID;
              orderLocationProduct.SetProductID = (object) this.OrderLocationProduct.ProductID;
              orderLocationProduct.SetOrderLocationProductID = (object) this.OrderLocationProduct.OrderLocationProductID;
              orderLocationProduct.SetTransactionTypeID = (object) 3;
              orderLocationProduct.SetAmount = (object) checked (-QuantityInput);
              App.DB.ProductTransaction.Insert(orderLocationProduct);
              this.OrderLocationProduct.SetQuantityReceived = (object) checked (this.OrderLocationProduct.QuantityReceived + QuantityInput);
              App.DB.OrderLocationProduct.Update(this.OrderLocationProduct);
              switch (this.Order.OrderTypeID)
              {
                case 3:
                  OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(this.OrderLocationProduct.OrderID);
                  orderLocationProduct.SetLocationID = (object) forOrder.LocationID;
                  orderLocationProduct.SetTransactionTypeID = (object) 2;
                  orderLocationProduct.SetOrderLocationProductID = (object) this.OrderLocationProduct.OrderLocationProductID;
                  orderLocationProduct.SetAmount = (object) QuantityInput;
                  orderLocationProduct.SetProductID = (object) this.OrderLocationProduct.ProductID;
                  App.DB.ProductTransaction.Insert(orderLocationProduct);
                  break;
              }
            }
          }
          else
          {
            this.OrderPart.SetQuantityReceived = (object) checked (this.OrderPart.QuantityReceived + QuantityInput);
            App.DB.OrderPart.Update(this.OrderPart);
            switch (this.Order.OrderTypeID)
            {
              case 3:
                OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(this.OrderPart.OrderID);
                PartSupplier partSupplier = App.DB.PartSupplier.PartSupplier_Get(this.OrderPart.PartSupplierID);
                App.DB.PartTransaction.Insert(new PartTransaction()
                {
                  SetLocationID = (object) forOrder.LocationID,
                  SetPartID = (object) partSupplier.PartID,
                  SetOrderPartID = (object) this.OrderPart.OrderPartID,
                  SetAmount = (object) ((double) QuantityInput * partSupplier.QuantityInPack),
                  SetTransactionTypeID = (object) 2
                });
                break;
            }
          }
        }
        else
        {
          this.OrderProduct.SetQuantityReceived = (object) checked (this.OrderProduct.QuantityReceived + QuantityInput);
          App.DB.OrderProduct.Update(this.OrderProduct);
          switch (this.Order.OrderTypeID)
          {
            case 3:
              OrderLocation forOrder = App.DB.OrderLocation.OrderLocation_GetForOrder(this.OrderProduct.OrderID);
              ProductSupplier productSupplier = App.DB.ProductSupplier.ProductSupplier_Get(this.OrderProduct.ProductSupplierID);
              App.DB.ProductTransaction.Insert(new ProductTransaction()
              {
                SetLocationID = (object) forOrder.LocationID,
                SetProductID = (object) productSupplier.ProductID,
                SetOrderProductID = (object) this.OrderProduct.OrderProductID,
                SetAmount = (object) ((double) QuantityInput * productSupplier.QuantityInPack),
                SetTransactionTypeID = (object) 2
              });
              break;
          }
        }
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }
  }
}
