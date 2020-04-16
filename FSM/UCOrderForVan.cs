// Decompiled with JetBrains decompiler
// Type: FSM.UCOrderForVan
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using FSM.Entity.Vans;
using FSM.Entity.Warehouses;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCOrderForVan : UCBase, IUserControl
  {
    private IContainer components;
    private Van _oVan;
    private Warehouse _oDeliveryAddress;
    private int _deliveryAddressID;

    public UCOrderForVan()
    {
      this.Load += new EventHandler(this.UCOrderForVan_Load);
      this._deliveryAddressID = 0;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpVanDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindVan
    {
      get
      {
        return this._btnFindVan;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindVan_Click);
        Button btnFindVan1 = this._btnFindVan;
        if (btnFindVan1 != null)
          btnFindVan1.Click -= eventHandler;
        this._btnFindVan = value;
        Button btnFindVan2 = this._btnFindVan;
        if (btnFindVan2 == null)
          return;
        btnFindVan2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtVan { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDeliveryAddress
    {
      get
      {
        return this._btnDeliveryAddress;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeliveryAddress_Click);
        Button btnDeliveryAddress1 = this._btnDeliveryAddress;
        if (btnDeliveryAddress1 != null)
          btnDeliveryAddress1.Click -= eventHandler;
        this._btnDeliveryAddress = value;
        Button btnDeliveryAddress2 = this._btnDeliveryAddress;
        if (btnDeliveryAddress2 == null)
          return;
        btnDeliveryAddress2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtDeliveryAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpVanDetails = new GroupBox();
      this.btnDeliveryAddress = new Button();
      this.txtDeliveryAddress = new TextBox();
      this.Label1 = new Label();
      this.btnFindVan = new Button();
      this.txtVan = new TextBox();
      this.grpVanDetails.SuspendLayout();
      this.SuspendLayout();
      this.grpVanDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVanDetails.Controls.Add((Control) this.btnDeliveryAddress);
      this.grpVanDetails.Controls.Add((Control) this.txtDeliveryAddress);
      this.grpVanDetails.Controls.Add((Control) this.Label1);
      this.grpVanDetails.Controls.Add((Control) this.btnFindVan);
      this.grpVanDetails.Controls.Add((Control) this.txtVan);
      this.grpVanDetails.ForeColor = SystemColors.ControlText;
      this.grpVanDetails.Location = new System.Drawing.Point(8, 8);
      this.grpVanDetails.Name = "grpVanDetails";
      this.grpVanDetails.Size = new Size(576, 272);
      this.grpVanDetails.TabIndex = 2;
      this.grpVanDetails.TabStop = false;
      this.grpVanDetails.Text = "Stock Profile Details";
      this.btnDeliveryAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDeliveryAddress.BackColor = Color.White;
      this.btnDeliveryAddress.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnDeliveryAddress.Location = new System.Drawing.Point(536, 105);
      this.btnDeliveryAddress.Name = "btnDeliveryAddress";
      this.btnDeliveryAddress.Size = new Size(32, 23);
      this.btnDeliveryAddress.TabIndex = 5;
      this.btnDeliveryAddress.Text = "...";
      this.btnDeliveryAddress.UseVisualStyleBackColor = false;
      this.txtDeliveryAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDeliveryAddress.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtDeliveryAddress.Location = new System.Drawing.Point(8, 105);
      this.txtDeliveryAddress.Name = "txtDeliveryAddress";
      this.txtDeliveryAddress.ReadOnly = true;
      this.txtDeliveryAddress.Size = new Size(520, 21);
      this.txtDeliveryAddress.TabIndex = 4;
      this.Label1.Location = new System.Drawing.Point(8, 88);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(216, 23);
      this.Label1.TabIndex = 3;
      this.Label1.Text = "Delivery Address for Supplier";
      this.btnFindVan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindVan.BackColor = Color.White;
      this.btnFindVan.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindVan.Location = new System.Drawing.Point(536, 28);
      this.btnFindVan.Name = "btnFindVan";
      this.btnFindVan.Size = new Size(32, 23);
      this.btnFindVan.TabIndex = 2;
      this.btnFindVan.Text = "...";
      this.btnFindVan.UseVisualStyleBackColor = false;
      this.txtVan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtVan.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtVan.Location = new System.Drawing.Point(8, 28);
      this.txtVan.Name = "txtVan";
      this.txtVan.ReadOnly = true;
      this.txtVan.Size = new Size(520, 21);
      this.txtVan.TabIndex = 1;
      this.Controls.Add((Control) this.grpVanDetails);
      this.Name = nameof (UCOrderForVan);
      this.Size = new Size(592, 288);
      this.grpVanDetails.ResumeLayout(false);
      this.grpVanDetails.PerformLayout();
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
        return (object) null;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Van Van
    {
      get
      {
        return this._oVan;
      }
      set
      {
        this._oVan = value;
        this.txtVan.Text = this._oVan.Registration;
      }
    }

    public Warehouse DeliveryAddress
    {
      get
      {
        return this._oDeliveryAddress;
      }
      set
      {
        this._oDeliveryAddress = value;
        this.txtDeliveryAddress.Text = this._oDeliveryAddress.Name;
        this.DeliveryAddressID = this._oDeliveryAddress.WarehouseID;
      }
    }

    public int DeliveryAddressID
    {
      get
      {
        return this._deliveryAddressID;
      }
      set
      {
        this._deliveryAddressID = value;
      }
    }

    private void UCOrderForVan_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnFindVan_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblVan, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Van = App.DB.Van.Van_Get(integer);
    }

    private void btnDeliveryAddress_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.DeliveryAddress = App.DB.Warehouse.Warehouse_Get(integer);
    }

    void IUserControl.Populate(int ID = 0)
    {
    }

    public bool Save()
    {
      bool flag;
      return flag;
    }
  }
}
