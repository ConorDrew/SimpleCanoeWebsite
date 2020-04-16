// Decompiled with JetBrains decompiler
// Type: FSM.UCPartSupplier
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.PartSuppliers;
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
  public class UCPartSupplier : UCBase, IUserControl
  {
    private IContainer components;
    private int _PartID;
    private bool _PrimaryUpdate;
    private bool _SecondaryUpdate;
    private PartSupplier _currentPartSupplier;

    public UCPartSupplier()
    {
      this.Load += new EventHandler(this.UCPartSupplier_Load);
      this._PartID = 0;
      this._PrimaryUpdate = false;
      this._SecondaryUpdate = false;
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

    internal virtual GroupBox grpPartSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPartCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSupplierID
    {
      get
      {
        return this._cboSupplierID;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboSupplierID_SelectedIndexChanged);
        ComboBox cboSupplierId1 = this._cboSupplierID;
        if (cboSupplierId1 != null)
          cboSupplierId1.SelectedIndexChanged -= eventHandler;
        this._cboSupplierID = value;
        ComboBox cboSupplierId2 = this._cboSupplierID;
        if (cboSupplierId2 == null)
          return;
        cboSupplierId2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblSupplierID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQuantityInPack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblQuantityInPack { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSecondaryPrice
    {
      get
      {
        return this._txtSecondaryPrice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtPrice_TextChanged);
        TextBox txtSecondaryPrice1 = this._txtSecondaryPrice;
        if (txtSecondaryPrice1 != null)
          txtSecondaryPrice1.KeyDown -= keyEventHandler;
        this._txtSecondaryPrice = value;
        TextBox txtSecondaryPrice2 = this._txtSecondaryPrice;
        if (txtSecondaryPrice2 == null)
          return;
        txtSecondaryPrice2.KeyDown += keyEventHandler;
      }
    }

    internal virtual Label lblSecondaryPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPrice
    {
      get
      {
        return this._txtPrice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtPrice_TextChanged);
        TextBox txtPrice1 = this._txtPrice;
        if (txtPrice1 != null)
          txtPrice1.KeyDown -= keyEventHandler;
        this._txtPrice = value;
        TextBox txtPrice2 = this._txtPrice;
        if (txtPrice2 == null)
          return;
        txtPrice2.KeyDown += keyEventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpPartSupplier = new GroupBox();
      this.txtSecondaryPrice = new TextBox();
      this.lblSecondaryPrice = new Label();
      this.txtPrice = new TextBox();
      this.Label1 = new Label();
      this.txtPartCode = new TextBox();
      this.lblPartCode = new Label();
      this.cboSupplierID = new ComboBox();
      this.lblSupplierID = new Label();
      this.txtQuantityInPack = new TextBox();
      this.lblQuantityInPack = new Label();
      this.grpPartSupplier.SuspendLayout();
      this.SuspendLayout();
      this.grpPartSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpPartSupplier.Controls.Add((Control) this.txtSecondaryPrice);
      this.grpPartSupplier.Controls.Add((Control) this.lblSecondaryPrice);
      this.grpPartSupplier.Controls.Add((Control) this.txtPrice);
      this.grpPartSupplier.Controls.Add((Control) this.Label1);
      this.grpPartSupplier.Controls.Add((Control) this.txtPartCode);
      this.grpPartSupplier.Controls.Add((Control) this.lblPartCode);
      this.grpPartSupplier.Controls.Add((Control) this.cboSupplierID);
      this.grpPartSupplier.Controls.Add((Control) this.lblSupplierID);
      this.grpPartSupplier.Controls.Add((Control) this.txtQuantityInPack);
      this.grpPartSupplier.Controls.Add((Control) this.lblQuantityInPack);
      this.grpPartSupplier.Location = new System.Drawing.Point(9, 1);
      this.grpPartSupplier.Name = "grpPartSupplier";
      this.grpPartSupplier.Size = new Size(578, 141);
      this.grpPartSupplier.TabIndex = 1;
      this.grpPartSupplier.TabStop = false;
      this.grpPartSupplier.Text = "Main Details";
      this.txtSecondaryPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSecondaryPrice.Location = new System.Drawing.Point(376, 107);
      this.txtSecondaryPrice.Name = "txtSecondaryPrice";
      this.txtSecondaryPrice.Size = new Size(192, 21);
      this.txtSecondaryPrice.TabIndex = 33;
      this.txtSecondaryPrice.Visible = false;
      this.lblSecondaryPrice.Location = new System.Drawing.Point(263, 107);
      this.lblSecondaryPrice.Name = "lblSecondaryPrice";
      this.lblSecondaryPrice.Size = new Size(105, 23);
      this.lblSecondaryPrice.TabIndex = 34;
      this.lblSecondaryPrice.Text = "Secondary Price";
      this.lblSecondaryPrice.Visible = false;
      this.txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPrice.Location = new System.Drawing.Point(376, 80);
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new Size(192, 21);
      this.txtPrice.TabIndex = 4;
      this.Label1.Location = new System.Drawing.Point(328, 80);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(40, 23);
      this.Label1.TabIndex = 32;
      this.Label1.Text = "Price";
      this.txtPartCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPartCode.Location = new System.Drawing.Point(128, 52);
      this.txtPartCode.MaxLength = 100;
      this.txtPartCode.Name = "txtPartCode";
      this.txtPartCode.Size = new Size(440, 21);
      this.txtPartCode.TabIndex = 2;
      this.txtPartCode.Tag = (object) "PartSupplier.PartCode";
      this.lblPartCode.Location = new System.Drawing.Point(8, 53);
      this.lblPartCode.Name = "lblPartCode";
      this.lblPartCode.Size = new Size(111, 20);
      this.lblPartCode.TabIndex = 31;
      this.lblPartCode.Text = "Part Code (SPN)";
      this.cboSupplierID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboSupplierID.Cursor = Cursors.Hand;
      this.cboSupplierID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSupplierID.Location = new System.Drawing.Point(128, 23);
      this.cboSupplierID.Name = "cboSupplierID";
      this.cboSupplierID.Size = new Size(440, 21);
      this.cboSupplierID.TabIndex = 1;
      this.cboSupplierID.Tag = (object) "PartSupplier.SupplierID";
      this.lblSupplierID.Location = new System.Drawing.Point(8, 24);
      this.lblSupplierID.Name = "lblSupplierID";
      this.lblSupplierID.Size = new Size(69, 20);
      this.lblSupplierID.TabIndex = 31;
      this.lblSupplierID.Text = "Supplier ";
      this.txtQuantityInPack.Location = new System.Drawing.Point(128, 80);
      this.txtQuantityInPack.MaxLength = 8;
      this.txtQuantityInPack.Name = "txtQuantityInPack";
      this.txtQuantityInPack.Size = new Size(184, 21);
      this.txtQuantityInPack.TabIndex = 3;
      this.txtQuantityInPack.Tag = (object) "PartSupplier.QuantityInPack";
      this.txtQuantityInPack.Text = "1";
      this.lblQuantityInPack.Location = new System.Drawing.Point(8, 82);
      this.lblQuantityInPack.Name = "lblQuantityInPack";
      this.lblQuantityInPack.Size = new Size(111, 20);
      this.lblQuantityInPack.TabIndex = 31;
      this.lblQuantityInPack.Text = "Quantity In Pack";
      this.Controls.Add((Control) this.grpPartSupplier);
      this.Name = nameof (UCPartSupplier);
      this.Size = new Size(592, 150);
      this.grpPartSupplier.ResumeLayout(false);
      this.grpPartSupplier.PerformLayout();
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
        return (object) this.CurrentPartSupplier;
      }
    }

    public int PartID
    {
      get
      {
        return this._PartID;
      }
      set
      {
        this._PartID = value;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public PartSupplier CurrentPartSupplier
    {
      get
      {
        return this._currentPartSupplier;
      }
      set
      {
        this._currentPartSupplier = value;
        if (this.CurrentPartSupplier == null)
        {
          this.CurrentPartSupplier = new PartSupplier();
          this.CurrentPartSupplier.Exists = false;
          this.txtQuantityInPack.Text = "1";
        }
        if (this.CurrentPartSupplier.Exists)
        {
          this.Populate(0);
          this.cboSupplierID.Enabled = false;
        }
        else
          this.cboSupplierID.Enabled = true;
      }
    }

    private void UCPartSupplier_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentPartSupplier = App.DB.PartSupplier.PartSupplier_Get(ID);
      this.txtPartCode.Text = this.CurrentPartSupplier.PartCode;
      ComboBox cboSupplierId = this.cboSupplierID;
      Combo.SetSelectedComboItem_By_Value(ref cboSupplierId, Conversions.ToString(this.CurrentPartSupplier.SupplierID));
      this.cboSupplierID = cboSupplierId;
      this.txtQuantityInPack.Text = Conversions.ToString(this.CurrentPartSupplier.QuantityInPack);
      this.txtPrice.Text = Conversions.ToString(this.CurrentPartSupplier.Price);
      this.txtSecondaryPrice.Text = Conversions.ToString(this.CurrentPartSupplier.SecondaryPrice);
      if (App.DB.Supplier.Supplier_GetSecondaryPrice(this.CurrentPartSupplier.SupplierID))
        return;
      this.txtSecondaryPrice.Visible = false;
      this.lblSecondaryPrice.Visible = false;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        Enums.SecuritySystemModules ssm1 = Enums.SecuritySystemModules.EditParts;
        Enums.SecuritySystemModules ssm2 = Enums.SecuritySystemModules.CreateParts;
        if (App.loggedInUser.HasAccessToModule(ssm1) | App.loggedInUser.HasAccessToModule(ssm2))
        {
          this.Cursor = Cursors.WaitCursor;
          this.CurrentPartSupplier.IgnoreExceptionsOnSetMethods = true;
          this.CurrentPartSupplier.SetPartCode = (object) this.txtPartCode.Text.Trim();
          this.CurrentPartSupplier.SetPartID = (object) this.PartID;
          this.CurrentPartSupplier.SetSupplierID = (object) Combo.get_GetSelectedItemValue(this.cboSupplierID);
          this.CurrentPartSupplier.SetQuantityInPack = (object) this.txtQuantityInPack.Text.Trim();
          this.CurrentPartSupplier.SetPrice = (object) this.txtPrice.Text.Trim();
          if (!string.IsNullOrEmpty(this.txtSecondaryPrice.Text.Trim()))
            this.CurrentPartSupplier.SetSecondaryPrice = (object) this.txtSecondaryPrice.Text.Trim();
          new PartSupplierValidator().Validate(this.CurrentPartSupplier);
          if (this.CurrentPartSupplier.Exists)
            App.DB.PartSupplier.Update(this.CurrentPartSupplier, this._PrimaryUpdate, this._SecondaryUpdate);
          else
            this.CurrentPartSupplier = App.DB.PartSupplier.Insert(this.CurrentPartSupplier);
          // ISSUE: reference to a compiler-generated field
          IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
          if (stateChangedEvent != null)
            stateChangedEvent(this.CurrentPartSupplier.PartSupplierID);
          flag = true;
        }
        else
          flag = false;
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

    private void cboSupplierID_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!App.DB.Supplier.Supplier_GetSecondaryPrice(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboSupplierID))))
      {
        this.txtSecondaryPrice.Visible = false;
        this.lblSecondaryPrice.Visible = false;
      }
      else
      {
        this.txtSecondaryPrice.Visible = true;
        this.lblSecondaryPrice.Visible = true;
      }
    }

    private void txtPrice_TextChanged(object sender, EventArgs e)
    {
      if (Operators.CompareString(((Control) sender).Name, "txtPrice", false) == 0)
      {
        this._PrimaryUpdate = true;
      }
      else
      {
        if (Operators.CompareString(((Control) sender).Name, "txtSecondaryPrice", false) != 0)
          return;
        this._SecondaryUpdate = true;
      }
    }
  }
}
