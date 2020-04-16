// Decompiled with JetBrains decompiler
// Type: FSM.UCProductSupplier
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

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
  public class UCProductSupplier : UCBase, IUserControl
  {
    private IContainer components;
    private int _ProductID;
    private ProductSupplier _currentProductSupplier;

    public UCProductSupplier()
    {
      this.Load += new EventHandler(this.UCProductSupplier_Load);
      this._ProductID = 0;
      this.InitializeComponent();
      ComboBox cboSupplierId = this.cboSupplierID;
      Combo.SetUpCombo(ref cboSupplierId, App.DB.Supplier.Supplier_GetAll().Table, "SupplierID", "Name", Enums.ComboValues.Please_Select);
      this.cboSupplierID = cboSupplierId;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpProductSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSupplierID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSupplierID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProductCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblProductCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQuantityInPack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuantityInPack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpProductSupplier = new GroupBox();
      this.txtPrice = new TextBox();
      this.Label1 = new Label();
      this.cboSupplierID = new ComboBox();
      this.lblSupplierID = new Label();
      this.txtProductCode = new TextBox();
      this.lblProductCode = new Label();
      this.txtQuantityInPack = new TextBox();
      this.lblQuantityInPack = new Label();
      this.grpProductSupplier.SuspendLayout();
      this.SuspendLayout();
      this.grpProductSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpProductSupplier.Controls.Add((Control) this.txtPrice);
      this.grpProductSupplier.Controls.Add((Control) this.Label1);
      this.grpProductSupplier.Controls.Add((Control) this.cboSupplierID);
      this.grpProductSupplier.Controls.Add((Control) this.lblSupplierID);
      this.grpProductSupplier.Controls.Add((Control) this.txtProductCode);
      this.grpProductSupplier.Controls.Add((Control) this.lblProductCode);
      this.grpProductSupplier.Controls.Add((Control) this.txtQuantityInPack);
      this.grpProductSupplier.Controls.Add((Control) this.lblQuantityInPack);
      this.grpProductSupplier.Location = new System.Drawing.Point(0, 1);
      this.grpProductSupplier.Name = "grpProductSupplier";
      this.grpProductSupplier.Size = new Size(584, 112);
      this.grpProductSupplier.TabIndex = 1;
      this.grpProductSupplier.TabStop = false;
      this.grpProductSupplier.Text = "Main Details";
      this.txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPrice.Location = new System.Drawing.Point(384, 80);
      this.txtPrice.MaxLength = 8;
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new Size(191, 21);
      this.txtPrice.TabIndex = 33;
      this.txtPrice.Tag = (object) "ProductSupplier.Price";
      this.Label1.Location = new System.Drawing.Point(336, 80);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(37, 18);
      this.Label1.TabIndex = 32;
      this.Label1.Text = "Price";
      this.cboSupplierID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboSupplierID.Cursor = Cursors.Hand;
      this.cboSupplierID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSupplierID.Location = new System.Drawing.Point(136, 24);
      this.cboSupplierID.Name = "cboSupplierID";
      this.cboSupplierID.Size = new Size(439, 21);
      this.cboSupplierID.TabIndex = 3;
      this.cboSupplierID.Tag = (object) "ProductSupplier.SupplierID";
      this.lblSupplierID.Location = new System.Drawing.Point(8, 24);
      this.lblSupplierID.Name = "lblSupplierID";
      this.lblSupplierID.Size = new Size(67, 20);
      this.lblSupplierID.TabIndex = 31;
      this.lblSupplierID.Text = "Supplier";
      this.txtProductCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtProductCode.Location = new System.Drawing.Point(136, 51);
      this.txtProductCode.MaxLength = 100;
      this.txtProductCode.Name = "txtProductCode";
      this.txtProductCode.Size = new Size(439, 21);
      this.txtProductCode.TabIndex = 4;
      this.txtProductCode.Tag = (object) "ProductSupplier.ProductCode";
      this.lblProductCode.Location = new System.Drawing.Point(8, 51);
      this.lblProductCode.Name = "lblProductCode";
      this.lblProductCode.Size = new Size(94, 20);
      this.lblProductCode.TabIndex = 31;
      this.lblProductCode.Text = "Product Code";
      this.txtQuantityInPack.Location = new System.Drawing.Point(136, 79);
      this.txtQuantityInPack.MaxLength = 8;
      this.txtQuantityInPack.Name = "txtQuantityInPack";
      this.txtQuantityInPack.Size = new Size(184, 21);
      this.txtQuantityInPack.TabIndex = 6;
      this.txtQuantityInPack.Tag = (object) "ProductSupplier.QuantityInPack";
      this.txtQuantityInPack.Text = "1";
      this.lblQuantityInPack.Location = new System.Drawing.Point(8, 79);
      this.lblQuantityInPack.Name = "lblQuantityInPack";
      this.lblQuantityInPack.Size = new Size(114, 20);
      this.lblQuantityInPack.TabIndex = 31;
      this.lblQuantityInPack.Text = "Quantity In Pack";
      this.Controls.Add((Control) this.grpProductSupplier);
      this.Name = nameof (UCProductSupplier);
      this.Size = new Size(592, 120);
      this.grpProductSupplier.ResumeLayout(false);
      this.grpProductSupplier.PerformLayout();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentProductSupplier;
      }
    }

    public int ProductID
    {
      get
      {
        return this._ProductID;
      }
      set
      {
        this._ProductID = value;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public ProductSupplier CurrentProductSupplier
    {
      get
      {
        return this._currentProductSupplier;
      }
      set
      {
        this._currentProductSupplier = value;
        if (this.CurrentProductSupplier == null)
        {
          this.CurrentProductSupplier = new ProductSupplier();
          this.CurrentProductSupplier.Exists = false;
          this.txtQuantityInPack.Text = "1";
        }
        if (this.CurrentProductSupplier.Exists)
        {
          this.Populate(0);
          this.cboSupplierID.Enabled = false;
        }
        else
          this.cboSupplierID.Enabled = true;
      }
    }

    private void UCProductSupplier_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(ID);
      ComboBox cboSupplierId = this.cboSupplierID;
      Combo.SetSelectedComboItem_By_Value(ref cboSupplierId, Conversions.ToString(this.CurrentProductSupplier.SupplierID));
      this.cboSupplierID = cboSupplierId;
      this.txtProductCode.Text = this.CurrentProductSupplier.ProductCode;
      this.txtQuantityInPack.Text = Conversions.ToString(this.CurrentProductSupplier.QuantityInPack);
      this.txtPrice.Text = Conversions.ToString(this.CurrentProductSupplier.Price);
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentProductSupplier.IgnoreExceptionsOnSetMethods = true;
        this.CurrentProductSupplier.SetProductID = (object) this.ProductID;
        this.CurrentProductSupplier.SetSupplierID = (object) Combo.get_GetSelectedItemValue(this.cboSupplierID);
        this.CurrentProductSupplier.SetProductCode = (object) this.txtProductCode.Text.Trim();
        this.CurrentProductSupplier.SetQuantityInPack = (object) this.txtQuantityInPack.Text.Trim();
        this.CurrentProductSupplier.SetPrice = (object) this.txtPrice.Text;
        new ProductSupplierValidator().Validate(this.CurrentProductSupplier);
        if (this.CurrentProductSupplier.Exists)
          App.DB.ProductSupplier.Update(this.CurrentProductSupplier);
        else
          this.CurrentProductSupplier = App.DB.ProductSupplier.Insert(this.CurrentProductSupplier);
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentProductSupplier.ProductSupplierID);
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }
  }
}
