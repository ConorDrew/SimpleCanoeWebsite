// Decompiled with JetBrains decompiler
// Type: FSM.FRMSpecialOrder
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMSpecialOrder : FRMBaseForm
  {
    private IContainer components;
    private int _supplierCode;
    private double _price;
    private string _partName;
    private string _spn;
    private int _quantity;

    public FRMSpecialOrder(int supplierCode, double price, int quantity)
    {
      this.Load += new EventHandler(this.FRMSpecialOrder_Load);
      this._supplierCode = 0;
      this._price = 0.0;
      this._partName = "";
      this._spn = "";
      this._quantity = 0;
      this.InitializeComponent();
      this._supplierCode = supplierCode;
      this._price = price;
      this._quantity = quantity;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox gpbSpecialOrder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQuantity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuantity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnAddPart
    {
      get
      {
        return this._btnAddPart;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddPart_Click);
        Button btnAddPart1 = this._btnAddPart;
        if (btnAddPart1 != null)
          btnAddPart1.Click -= eventHandler;
        this._btnAddPart = value;
        Button btnAddPart2 = this._btnAddPart;
        if (btnAddPart2 == null)
          return;
        btnAddPart2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSPN { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPartCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPartName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.gpbSpecialOrder = new GroupBox();
      this.txtQuantity = new TextBox();
      this.lblQuantity = new Label();
      this.btnCancel = new Button();
      this.btnAddPart = new Button();
      this.txtPrice = new TextBox();
      this.lblPrice = new Label();
      this.txtSupplier = new TextBox();
      this.lblSupplier = new Label();
      this.txtSPN = new TextBox();
      this.lblPartCode = new Label();
      this.txtPartName = new TextBox();
      this.lblPartName = new Label();
      this.gpbSpecialOrder.SuspendLayout();
      this.SuspendLayout();
      this.gpbSpecialOrder.Controls.Add((Control) this.txtQuantity);
      this.gpbSpecialOrder.Controls.Add((Control) this.lblQuantity);
      this.gpbSpecialOrder.Controls.Add((Control) this.btnCancel);
      this.gpbSpecialOrder.Controls.Add((Control) this.btnAddPart);
      this.gpbSpecialOrder.Controls.Add((Control) this.txtPrice);
      this.gpbSpecialOrder.Controls.Add((Control) this.lblPrice);
      this.gpbSpecialOrder.Controls.Add((Control) this.txtSupplier);
      this.gpbSpecialOrder.Controls.Add((Control) this.lblSupplier);
      this.gpbSpecialOrder.Controls.Add((Control) this.txtSPN);
      this.gpbSpecialOrder.Controls.Add((Control) this.lblPartCode);
      this.gpbSpecialOrder.Controls.Add((Control) this.txtPartName);
      this.gpbSpecialOrder.Controls.Add((Control) this.lblPartName);
      this.gpbSpecialOrder.Location = new System.Drawing.Point(12, 38);
      this.gpbSpecialOrder.Name = "gpbSpecialOrder";
      this.gpbSpecialOrder.Size = new Size(449, 183);
      this.gpbSpecialOrder.TabIndex = 17;
      this.gpbSpecialOrder.TabStop = false;
      this.gpbSpecialOrder.Text = "Special Order";
      this.txtQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtQuantity.Location = new System.Drawing.Point(95, 103);
      this.txtQuantity.Name = "txtQuantity";
      this.txtQuantity.Size = new Size(112, 21);
      this.txtQuantity.TabIndex = 45;
      this.lblQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblQuantity.Location = new System.Drawing.Point(11, 106);
      this.lblQuantity.Name = "lblQuantity";
      this.lblQuantity.Size = new Size(78, 18);
      this.lblQuantity.TabIndex = 52;
      this.lblQuantity.Text = "Quantity";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(14, 148);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(88, 24);
      this.btnCancel.TabIndex = 47;
      this.btnCancel.Text = "Cancel";
      this.btnAddPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddPart.Location = new System.Drawing.Point(367, 148);
      this.btnAddPart.Name = "btnAddPart";
      this.btnAddPart.Size = new Size(71, 24);
      this.btnAddPart.TabIndex = 46;
      this.btnAddPart.Text = "Add";
      this.txtPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtPrice.Location = new System.Drawing.Point(326, 62);
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new Size(112, 21);
      this.txtPrice.TabIndex = 44;
      this.lblPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblPrice.Location = new System.Drawing.Point(242, 65);
      this.lblPrice.Name = "lblPrice";
      this.lblPrice.Size = new Size(78, 18);
      this.lblPrice.TabIndex = 51;
      this.lblPrice.Text = "Price";
      this.txtSupplier.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtSupplier.Enabled = false;
      this.txtSupplier.Location = new System.Drawing.Point(95, 62);
      this.txtSupplier.Name = "txtSupplier";
      this.txtSupplier.Size = new Size(112, 21);
      this.txtSupplier.TabIndex = 43;
      this.lblSupplier.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblSupplier.Location = new System.Drawing.Point(11, 65);
      this.lblSupplier.Name = "lblSupplier";
      this.lblSupplier.Size = new Size(78, 18);
      this.lblSupplier.TabIndex = 50;
      this.lblSupplier.Text = "Supplier";
      this.txtSPN.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtSPN.Location = new System.Drawing.Point(326, 18);
      this.txtSPN.Name = "txtSPN";
      this.txtSPN.Size = new Size(112, 21);
      this.txtSPN.TabIndex = 42;
      this.lblPartCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblPartCode.Location = new System.Drawing.Point(242, 21);
      this.lblPartCode.Name = "lblPartCode";
      this.lblPartCode.Size = new Size(78, 18);
      this.lblPartCode.TabIndex = 49;
      this.lblPartCode.Text = "Part Code";
      this.txtPartName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtPartName.Location = new System.Drawing.Point(95, 18);
      this.txtPartName.Name = "txtPartName";
      this.txtPartName.Size = new Size(112, 21);
      this.txtPartName.TabIndex = 41;
      this.lblPartName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblPartName.Location = new System.Drawing.Point(11, 21);
      this.lblPartName.Name = "lblPartName";
      this.lblPartName.Size = new Size(78, 18);
      this.lblPartName.TabIndex = 48;
      this.lblPartName.Text = "Part Name";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.BackColor = SystemColors.Window;
      this.ClientSize = new Size(471, 228);
      this.ControlBox = false;
      this.Controls.Add((Control) this.gpbSpecialOrder);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (FRMSpecialOrder);
      this.Text = "Orders - Special Order";
      this.Controls.SetChildIndex((Control) this.gpbSpecialOrder, 0);
      this.gpbSpecialOrder.ResumeLayout(false);
      this.gpbSpecialOrder.PerformLayout();
      this.ResumeLayout(false);
    }

    public int SupplierCode
    {
      get
      {
        return this._supplierCode;
      }
    }

    public double Price
    {
      get
      {
        return this._price;
      }
    }

    public string PartName
    {
      get
      {
        return this._partName;
      }
    }

    public string SPN
    {
      get
      {
        return this._spn;
      }
    }

    public int Quantity
    {
      get
      {
        return this._quantity;
      }
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    private void btnAddPart_Click(object sender, EventArgs e)
    {
      this._spn = this.txtSPN.Text;
      this._partName = this.txtPartName.Text;
      try
      {
        this._price = Convert.ToDouble(this.txtPrice.Text);
        this._quantity = Convert.ToInt32(this.txtQuantity.Text);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Quantity/Price is incorrect format", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
        return;
      }
      this.DialogResult = DialogResult.OK;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMSpecialOrder_Load(object sender, EventArgs e)
    {
      if (this.SupplierCode == 0)
      {
        this.txtPrice.Text = Conversions.ToString(0);
        this.txtSupplier.Text = "";
        this.txtQuantity.Text = Conversions.ToString(1);
      }
      else
      {
        this.txtPrice.Text = Conversions.ToString(this.Price);
        int supplierId = App.DB.PartSupplier.PartSupplier_Get(this.SupplierCode).SupplierID;
        this.txtSupplier.Text = App.DB.Supplier.Supplier_Get(supplierId).Name;
        this.txtQuantity.Text = Conversions.ToString(this.Quantity);
      }
    }
  }
}
