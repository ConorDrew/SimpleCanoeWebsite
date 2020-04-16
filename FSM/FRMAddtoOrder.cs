// Decompiled with JetBrains decompiler
// Type: FSM.FRMAddtoOrder
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.OrderParts;
using FSM.Entity.OrderProducts;
using FSM.Entity.Orders;
using FSM.Entity.Parts;
using FSM.Entity.PartSuppliers;
using FSM.Entity.Products;
using FSM.Entity.ProductSuppliers;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMAddtoOrder : FRMBaseForm, IForm
  {
    private IContainer components;
    private Order _oOrder;
    private PartSupplier _partSupplier;
    private ProductSupplier _productSupplier;
    private int _PriceRequestID;

    public FRMAddtoOrder()
    {
      this.Load += new EventHandler(this.FRMAddtoOrder_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQtyInPack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddToOrder
    {
      get
      {
        return this._btnAddToOrder;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddToOrder_Click);
        Button btnAddToOrder1 = this._btnAddToOrder;
        if (btnAddToOrder1 != null)
          btnAddToOrder1.Click -= eventHandler;
        this._btnAddToOrder = value;
        Button btnAddToOrder2 = this._btnAddToOrder;
        if (btnAddToOrder2 == null)
          return;
        btnAddToOrder2.Click += eventHandler;
      }
    }

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        Button btnCancel1 = this._btnCancel;
        if (btnCancel1 != null)
          btnCancel1.Click -= eventHandler;
        this._btnCancel = value;
        Button btnCancel2 = this._btnCancel;
        if (btnCancel2 == null)
          return;
        btnCancel2.Click += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplierCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSellPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBuyPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.lblName = new Label();
      this.lblNumber = new Label();
      this.Label3 = new Label();
      this.lblSupplier = new Label();
      this.lblQty = new Label();
      this.Label7 = new Label();
      this.Label8 = new Label();
      this.txtName = new TextBox();
      this.txtNumber = new TextBox();
      this.txtQtyInPack = new TextBox();
      this.txtSupplierCode = new TextBox();
      this.txtSellPrice = new TextBox();
      this.txtAmount = new TextBox();
      this.btnAddToOrder = new Button();
      this.btnCancel = new Button();
      this.txtBuyPrice = new TextBox();
      this.Label6 = new Label();
      this.GroupBox1 = new GroupBox();
      this.txtSupplier = new TextBox();
      this.GroupBox2 = new GroupBox();
      this.GroupBox1.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.SuspendLayout();
      this.lblName.Location = new System.Drawing.Point(8, 24);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(120, 23);
      this.lblName.TabIndex = 2;
      this.lblName.Text = "Name:";
      this.lblNumber.Location = new System.Drawing.Point(8, 56);
      this.lblNumber.Name = "lblNumber";
      this.lblNumber.Size = new Size(120, 23);
      this.lblNumber.TabIndex = 3;
      this.lblNumber.Text = "Number:";
      this.Label3.Location = new System.Drawing.Point(8, 24);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(104, 23);
      this.Label3.TabIndex = 4;
      this.Label3.Text = "Supplier Code:";
      this.lblSupplier.Location = new System.Drawing.Point(8, 88);
      this.lblSupplier.Name = "lblSupplier";
      this.lblSupplier.Size = new Size(80, 24);
      this.lblSupplier.TabIndex = 5;
      this.lblSupplier.Text = "Supplier:";
      this.lblQty.Location = new System.Drawing.Point(8, 120);
      this.lblQty.Name = "lblQty";
      this.lblQty.Size = new Size(120, 23);
      this.lblQty.TabIndex = 6;
      this.lblQty.Text = "Quantity In Pack:";
      this.Label7.Location = new System.Drawing.Point(8, 88);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(88, 23);
      this.Label7.TabIndex = 8;
      this.Label7.Text = "Sell Price:";
      this.Label8.Location = new System.Drawing.Point(8, 120);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(104, 24);
      this.Label8.TabIndex = 9;
      this.Label8.Text = "Amount to add:";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Enabled = false;
      this.txtName.Location = new System.Drawing.Point(128, 24);
      this.txtName.Name = "txtName";
      this.txtName.ReadOnly = true;
      this.txtName.Size = new Size(296, 21);
      this.txtName.TabIndex = 1;
      this.txtName.Text = "";
      this.txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNumber.Enabled = false;
      this.txtNumber.Location = new System.Drawing.Point(128, 58);
      this.txtNumber.Name = "txtNumber";
      this.txtNumber.ReadOnly = true;
      this.txtNumber.Size = new Size(296, 21);
      this.txtNumber.TabIndex = 2;
      this.txtNumber.Text = "";
      this.txtQtyInPack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtQtyInPack.Enabled = false;
      this.txtQtyInPack.Location = new System.Drawing.Point(128, 122);
      this.txtQtyInPack.Name = "txtQtyInPack";
      this.txtQtyInPack.ReadOnly = true;
      this.txtQtyInPack.Size = new Size(296, 21);
      this.txtQtyInPack.TabIndex = 4;
      this.txtQtyInPack.Text = "";
      this.txtSupplierCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSupplierCode.Location = new System.Drawing.Point(128, 24);
      this.txtSupplierCode.Name = "txtSupplierCode";
      this.txtSupplierCode.Size = new Size(296, 21);
      this.txtSupplierCode.TabIndex = 5;
      this.txtSupplierCode.Text = "";
      this.txtSellPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSellPrice.Location = new System.Drawing.Point(128, 90);
      this.txtSellPrice.Name = "txtSellPrice";
      this.txtSellPrice.Size = new Size(296, 21);
      this.txtSellPrice.TabIndex = 7;
      this.txtSellPrice.Text = "";
      this.txtAmount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAmount.Location = new System.Drawing.Point(128, 122);
      this.txtAmount.Name = "txtAmount";
      this.txtAmount.Size = new Size(168, 21);
      this.txtAmount.TabIndex = 8;
      this.txtAmount.Text = "";
      this.btnAddToOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAddToOrder.Location = new System.Drawing.Point(304, 122);
      this.btnAddToOrder.Name = "btnAddToOrder";
      this.btnAddToOrder.Size = new Size(56, 23);
      this.btnAddToOrder.TabIndex = 9;
      this.btnAddToOrder.Text = "Add";
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.Location = new System.Drawing.Point(368, 122);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(56, 23);
      this.btnCancel.TabIndex = 10;
      this.btnCancel.Text = "Cancel";
      this.txtBuyPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtBuyPrice.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtBuyPrice.Location = new System.Drawing.Point(128, 58);
      this.txtBuyPrice.Name = "txtBuyPrice";
      this.txtBuyPrice.Size = new Size(296, 21);
      this.txtBuyPrice.TabIndex = 6;
      this.txtBuyPrice.Text = "";
      this.Label6.BackColor = Color.White;
      this.Label6.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label6.Location = new System.Drawing.Point(8, 56);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 23);
      this.Label6.TabIndex = 7;
      this.Label6.Text = "Buy Price:";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.lblName);
      this.GroupBox1.Controls.Add((Control) this.lblNumber);
      this.GroupBox1.Controls.Add((Control) this.txtName);
      this.GroupBox1.Controls.Add((Control) this.txtNumber);
      this.GroupBox1.Controls.Add((Control) this.lblSupplier);
      this.GroupBox1.Controls.Add((Control) this.txtSupplier);
      this.GroupBox1.Controls.Add((Control) this.lblQty);
      this.GroupBox1.Controls.Add((Control) this.txtQtyInPack);
      this.GroupBox1.Location = new System.Drawing.Point(8, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(432, 152);
      this.GroupBox1.TabIndex = 20;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Request Details";
      this.txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSupplier.Enabled = false;
      this.txtSupplier.Location = new System.Drawing.Point(128, 90);
      this.txtSupplier.Name = "txtSupplier";
      this.txtSupplier.ReadOnly = true;
      this.txtSupplier.Size = new Size(296, 21);
      this.txtSupplier.TabIndex = 3;
      this.txtSupplier.Text = "";
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.Label3);
      this.GroupBox2.Controls.Add((Control) this.txtSupplierCode);
      this.GroupBox2.Controls.Add((Control) this.txtBuyPrice);
      this.GroupBox2.Controls.Add((Control) this.txtSellPrice);
      this.GroupBox2.Controls.Add((Control) this.Label6);
      this.GroupBox2.Controls.Add((Control) this.Label7);
      this.GroupBox2.Controls.Add((Control) this.Label8);
      this.GroupBox2.Controls.Add((Control) this.txtAmount);
      this.GroupBox2.Controls.Add((Control) this.btnAddToOrder);
      this.GroupBox2.Controls.Add((Control) this.btnCancel);
      this.GroupBox2.Location = new System.Drawing.Point(8, 200);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(432, 152);
      this.GroupBox2.TabIndex = 21;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Order Details";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(448, 358);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.GroupBox1);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(456, 392);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(456, 392);
      this.Name = nameof (FRMAddtoOrder);
      this.Text = "Add Item to Order";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox2, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.oOrder = (Order) this.get_GetParameter(0);
      this.PartSupplier = (PartSupplier) this.get_GetParameter(1);
      this.ProductSupplier = (ProductSupplier) this.get_GetParameter(2);
      this.PriceRequestID = Conversions.ToInteger(this.get_GetParameter(3));
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      if (this.PartSupplier != null)
      {
        Part part = App.DB.Part.Part_Get(this.PartSupplier.PartID);
        this.lblName.Text = "Part Name";
        this.lblNumber.Text = "Part Number";
        this.txtName.Text = part.Name;
        this.txtNumber.Text = part.Number;
        this.txtQtyInPack.Text = Conversions.ToString(this.PartSupplier.QuantityInPack);
        this.txtSupplier.Text = App.DB.Supplier.Supplier_Get(this.PartSupplier.SupplierID).Name;
      }
      if (this.ProductSupplier == null)
        return;
      Product product = App.DB.Product.Product_Get(this.ProductSupplier.ProductID);
      this.lblName.Text = "Product Name";
      this.lblNumber.Text = "Product Number";
      this.txtName.Text = product.Name;
      this.txtNumber.Text = product.Number;
      this.txtQtyInPack.Text = Conversions.ToString(this.ProductSupplier.QuantityInPack);
      this.txtSupplier.Text = App.DB.Supplier.Supplier_Get(this.ProductSupplier.SupplierID).Name;
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

    private Order oOrder
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

    public PartSupplier PartSupplier
    {
      get
      {
        return this._partSupplier;
      }
      set
      {
        this._partSupplier = value;
      }
    }

    public ProductSupplier ProductSupplier
    {
      get
      {
        return this._productSupplier;
      }
      set
      {
        this._productSupplier = value;
      }
    }

    public int PriceRequestID
    {
      get
      {
        return this._PriceRequestID;
      }
      set
      {
        this._PriceRequestID = value;
      }
    }

    private void FRMAddtoOrder_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnAddToOrder_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.PartSupplier != null)
        {
          this.PartSupplier.IgnoreExceptionsOnSetMethods = true;
          this.PartSupplier.SetPrice = (object) this.txtBuyPrice.Text.Trim();
          this.PartSupplier.SetPartCode = (object) this.txtSupplierCode.Text.Trim();
          new PartSupplierValidator().Validate(this.PartSupplier);
          OrderPart oOrderPart = new OrderPart();
          oOrderPart.IgnoreExceptionsOnSetMethods = true;
          oOrderPart.SetSellPrice = (object) this.txtSellPrice.Text.Trim();
          oOrderPart.SetQuantity = (object) this.txtAmount.Text.Trim();
          oOrderPart.SetOrderID = (object) this.oOrder.OrderID;
          new OrderPartValidator().Validate(oOrderPart);
          this.PartSupplier = App.DB.PartSupplier.Insert(this.PartSupplier);
          oOrderPart.SetBuyPrice = (object) this.PartSupplier.Price;
          oOrderPart.SetPartSupplierID = (object) this.PartSupplier.PartSupplierID;
          App.DB.OrderPart.Insert(oOrderPart, !this.oOrder.DoNotConsolidated);
          App.DB.PartPriceRequest.Complete(this.PriceRequestID);
        }
        if (this.ProductSupplier != null)
        {
          this.ProductSupplier.IgnoreExceptionsOnSetMethods = true;
          this.ProductSupplier.SetPrice = (object) this.txtBuyPrice.Text.Trim();
          this.ProductSupplier.SetProductCode = (object) this.txtSupplierCode.Text.Trim();
          new ProductSupplierValidator().Validate(this.ProductSupplier);
          OrderProduct oOrderProduct = new OrderProduct();
          oOrderProduct.IgnoreExceptionsOnSetMethods = true;
          oOrderProduct.SetSellPrice = (object) this.txtSellPrice.Text.Trim();
          oOrderProduct.SetQuantity = (object) this.txtAmount.Text.Trim();
          oOrderProduct.SetOrderID = (object) this.oOrder.OrderID;
          new OrderProductValidator().Validate(oOrderProduct);
          this.ProductSupplier = App.DB.ProductSupplier.Insert(this.ProductSupplier);
          oOrderProduct.SetBuyPrice = (object) this.ProductSupplier.Price;
          oOrderProduct.SetProductSupplierID = (object) this.ProductSupplier.ProductSupplierID;
          App.DB.OrderProduct.Insert(oOrderProduct, true);
          App.DB.ProductPriceRequest.Complete(this.PriceRequestID);
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
