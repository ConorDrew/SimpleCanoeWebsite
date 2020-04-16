// Decompiled with JetBrains decompiler
// Type: FSM.FRMAddToQuote
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Parts;
using FSM.Entity.PartSuppliers;
using FSM.Entity.Products;
using FSM.Entity.ProductSuppliers;
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
  public class FRMAddToQuote : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _QuoteID;
    private PartSupplier _partSupplier;
    private ProductSupplier _productSupplier;
    private int _PriceRequestID;

    public FRMAddToQuote()
    {
      this.Load += new EventHandler(this.FRMAddToQuote_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplierCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBuyPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQtyInPack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnConfirm
    {
      get
      {
        return this._btnConfirm;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnConfirm_Click);
        Button btnConfirm1 = this._btnConfirm;
        if (btnConfirm1 != null)
          btnConfirm1.Click -= eventHandler;
        this._btnConfirm = value;
        Button btnConfirm2 = this._btnConfirm;
        if (btnConfirm2 == null)
          return;
        btnConfirm2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox2 = new GroupBox();
      this.Label3 = new Label();
      this.txtSupplierCode = new TextBox();
      this.txtBuyPrice = new TextBox();
      this.Label6 = new Label();
      this.btnConfirm = new Button();
      this.btnCancel = new Button();
      this.GroupBox1 = new GroupBox();
      this.lblName = new Label();
      this.lblNumber = new Label();
      this.txtName = new TextBox();
      this.txtNumber = new TextBox();
      this.lblSupplier = new Label();
      this.txtSupplier = new TextBox();
      this.lblQty = new Label();
      this.txtQtyInPack = new TextBox();
      this.GroupBox2.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.Label3);
      this.GroupBox2.Controls.Add((Control) this.txtSupplierCode);
      this.GroupBox2.Controls.Add((Control) this.txtBuyPrice);
      this.GroupBox2.Controls.Add((Control) this.Label6);
      this.GroupBox2.Controls.Add((Control) this.btnConfirm);
      this.GroupBox2.Controls.Add((Control) this.btnCancel);
      this.GroupBox2.Location = new System.Drawing.Point(8, 195);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(512, 125);
      this.GroupBox2.TabIndex = 23;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Quote Details";
      this.Label3.Location = new System.Drawing.Point(8, 24);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(104, 23);
      this.Label3.TabIndex = 4;
      this.Label3.Text = "Supplier Code:";
      this.txtSupplierCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSupplierCode.Location = new System.Drawing.Point(128, 24);
      this.txtSupplierCode.Name = "txtSupplierCode";
      this.txtSupplierCode.Size = new Size(376, 21);
      this.txtSupplierCode.TabIndex = 5;
      this.txtSupplierCode.Text = "";
      this.txtBuyPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtBuyPrice.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtBuyPrice.Location = new System.Drawing.Point(128, 63);
      this.txtBuyPrice.Name = "txtBuyPrice";
      this.txtBuyPrice.Size = new Size(376, 21);
      this.txtBuyPrice.TabIndex = 6;
      this.txtBuyPrice.Text = "";
      this.Label6.BackColor = Color.White;
      this.Label6.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label6.Location = new System.Drawing.Point(8, 56);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 23);
      this.Label6.TabIndex = 7;
      this.Label6.Text = "Buy Price:";
      this.btnConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnConfirm.Location = new System.Drawing.Point(352, 96);
      this.btnConfirm.Name = "btnConfirm";
      this.btnConfirm.Size = new Size(88, 23);
      this.btnConfirm.TabIndex = 9;
      this.btnConfirm.Text = "Confirm";
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.Location = new System.Drawing.Point(448, 96);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(56, 23);
      this.btnCancel.TabIndex = 10;
      this.btnCancel.Text = "Cancel";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.lblName);
      this.GroupBox1.Controls.Add((Control) this.lblNumber);
      this.GroupBox1.Controls.Add((Control) this.txtName);
      this.GroupBox1.Controls.Add((Control) this.txtNumber);
      this.GroupBox1.Controls.Add((Control) this.lblSupplier);
      this.GroupBox1.Controls.Add((Control) this.txtSupplier);
      this.GroupBox1.Controls.Add((Control) this.lblQty);
      this.GroupBox1.Controls.Add((Control) this.txtQtyInPack);
      this.GroupBox1.Location = new System.Drawing.Point(8, 35);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(512, 152);
      this.GroupBox1.TabIndex = 22;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Request Details";
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
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Enabled = false;
      this.txtName.Location = new System.Drawing.Point(128, 24);
      this.txtName.Name = "txtName";
      this.txtName.ReadOnly = true;
      this.txtName.Size = new Size(376, 21);
      this.txtName.TabIndex = 1;
      this.txtName.Text = "";
      this.txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNumber.Enabled = false;
      this.txtNumber.Location = new System.Drawing.Point(128, 63);
      this.txtNumber.Name = "txtNumber";
      this.txtNumber.ReadOnly = true;
      this.txtNumber.Size = new Size(376, 21);
      this.txtNumber.TabIndex = 2;
      this.txtNumber.Text = "";
      this.lblSupplier.Location = new System.Drawing.Point(8, 88);
      this.lblSupplier.Name = "lblSupplier";
      this.lblSupplier.Size = new Size(80, 24);
      this.lblSupplier.TabIndex = 5;
      this.lblSupplier.Text = "Supplier:";
      this.txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSupplier.Enabled = false;
      this.txtSupplier.Location = new System.Drawing.Point(128, 95);
      this.txtSupplier.Name = "txtSupplier";
      this.txtSupplier.ReadOnly = true;
      this.txtSupplier.Size = new Size(376, 21);
      this.txtSupplier.TabIndex = 3;
      this.txtSupplier.Text = "";
      this.lblQty.Location = new System.Drawing.Point(8, 120);
      this.lblQty.Name = "lblQty";
      this.lblQty.Size = new Size(120, 23);
      this.lblQty.TabIndex = 6;
      this.lblQty.Text = "Quantity In Pack:";
      this.txtQtyInPack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtQtyInPack.Enabled = false;
      this.txtQtyInPack.Location = new System.Drawing.Point(128, (int) sbyte.MaxValue);
      this.txtQtyInPack.Name = "txtQtyInPack";
      this.txtQtyInPack.ReadOnly = true;
      this.txtQtyInPack.Size = new Size(376, 21);
      this.txtQtyInPack.TabIndex = 4;
      this.txtQtyInPack.Text = "";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(528, 326);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.GroupBox1);
      this.MaximumSize = new Size(536, 360);
      this.MinimumSize = new Size(536, 360);
      this.Name = nameof (FRMAddToQuote);
      this.Text = "Confrim Price Request";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox2, 0);
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.QuoteID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
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

    public int QuoteID
    {
      get
      {
        return this._QuoteID;
      }
      set
      {
        this._QuoteID = value;
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

    private void FRMAddToQuote_Load(object sender, EventArgs e)
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

    private void btnConfirm_Click(object sender, EventArgs e)
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
          this.PartSupplier = App.DB.PartSupplier.Insert(this.PartSupplier);
          App.DB.PartPriceRequest.Complete(this.PriceRequestID);
        }
        if (this.ProductSupplier != null)
        {
          this.ProductSupplier.IgnoreExceptionsOnSetMethods = true;
          this.ProductSupplier.SetPrice = (object) this.txtBuyPrice.Text.Trim();
          this.ProductSupplier.SetProductCode = (object) this.txtSupplierCode.Text.Trim();
          new ProductSupplierValidator().Validate(this.ProductSupplier);
          this.ProductSupplier = App.DB.ProductSupplier.Insert(this.ProductSupplier);
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
