// Decompiled with JetBrains decompiler
// Type: FSM.UCOrderForWarehouse
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
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
  public class UCOrderForWarehouse : UCBase, IUserControl
  {
    private IContainer components;
    private Warehouse _oWarehouse;

    public UCOrderForWarehouse()
    {
      this.Load += new EventHandler(this.UCOrderForWarehouse_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpWarehouseDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindWarehouse
    {
      get
      {
        return this._btnFindWarehouse;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindWarehouse_Click);
        Button btnFindWarehouse1 = this._btnFindWarehouse;
        if (btnFindWarehouse1 != null)
          btnFindWarehouse1.Click -= eventHandler;
        this._btnFindWarehouse = value;
        Button btnFindWarehouse2 = this._btnFindWarehouse;
        if (btnFindWarehouse2 == null)
          return;
        btnFindWarehouse2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtWarehouse { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpWarehouseDetails = new GroupBox();
      this.btnFindWarehouse = new Button();
      this.txtWarehouse = new TextBox();
      this.grpWarehouseDetails.SuspendLayout();
      this.SuspendLayout();
      this.grpWarehouseDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpWarehouseDetails.Controls.Add((Control) this.btnFindWarehouse);
      this.grpWarehouseDetails.Controls.Add((Control) this.txtWarehouse);
      this.grpWarehouseDetails.ForeColor = SystemColors.ControlText;
      this.grpWarehouseDetails.Location = new System.Drawing.Point(8, 8);
      this.grpWarehouseDetails.Name = "grpWarehouseDetails";
      this.grpWarehouseDetails.Size = new Size(552, 64);
      this.grpWarehouseDetails.TabIndex = 1;
      this.grpWarehouseDetails.TabStop = false;
      this.grpWarehouseDetails.Text = "Warehouse Details";
      this.btnFindWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindWarehouse.BackColor = Color.White;
      this.btnFindWarehouse.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindWarehouse.Location = new System.Drawing.Point(512, 31);
      this.btnFindWarehouse.Name = "btnFindWarehouse";
      this.btnFindWarehouse.Size = new Size(32, 23);
      this.btnFindWarehouse.TabIndex = 2;
      this.btnFindWarehouse.Text = "...";
      this.txtWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtWarehouse.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtWarehouse.Location = new System.Drawing.Point(8, 31);
      this.txtWarehouse.Name = "txtWarehouse";
      this.txtWarehouse.ReadOnly = true;
      this.txtWarehouse.Size = new Size(496, 21);
      this.txtWarehouse.TabIndex = 1;
      this.txtWarehouse.Text = "";
      this.Controls.Add((Control) this.grpWarehouseDetails);
      this.Name = nameof (UCOrderForWarehouse);
      this.Size = new Size(568, 88);
      this.grpWarehouseDetails.ResumeLayout(false);
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

    public Warehouse Warehouse
    {
      get
      {
        return this._oWarehouse;
      }
      set
      {
        this._oWarehouse = value;
        this.txtWarehouse.Text = this.Warehouse.Name + " ( " + this.Warehouse.Address1 + ", " + this.Warehouse.Postcode + ") ";
      }
    }

    private void btnFindWarehouse_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Warehouse = App.DB.Warehouse.Warehouse_Get(integer);
    }

    private void UCOrderForWarehouse_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
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
