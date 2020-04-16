// Decompiled with JetBrains decompiler
// Type: FSM.UCPartsToBeCredited
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Orders;
using FSM.Entity.Parts;
using FSM.Entity.PartsToBeCrediteds;
using FSM.Entity.Suppliers;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCPartsToBeCredited : UCBase, IUserControl
  {
    private IContainer components;
    private PartsToBeCredited _currentPartsToBeCredited;
    private int _OrderID;
    private int _SupplierID;
    private int _PartID;

    public UCPartsToBeCredited()
    {
      this.Load += new EventHandler(this.UCPartsToBeCredited_Load);
      this._PartID = 0;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox PartToBeCredited { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindPart
    {
      get
      {
        return this._btnFindPart;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindPart_Click);
        Button btnFindPart1 = this._btnFindPart;
        if (btnFindPart1 != null)
          btnFindPart1.Click -= eventHandler;
        this._btnFindPart = value;
        Button btnFindPart2 = this._btnFindPart;
        if (btnFindPart2 == null)
          return;
        btnFindPart2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtPart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindSupplier
    {
      get
      {
        return this._btnFindSupplier;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSupplier_Click);
        Button btnFindSupplier1 = this._btnFindSupplier;
        if (btnFindSupplier1 != null)
          btnFindSupplier1.Click -= eventHandler;
        this._btnFindSupplier = value;
        Button btnFindSupplier2 = this._btnFindSupplier;
        if (btnFindSupplier2 == null)
          return;
        btnFindSupplier2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindOrder
    {
      get
      {
        return this._btnFindOrder;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindOrder_Click);
        Button btnFindOrder1 = this._btnFindOrder;
        if (btnFindOrder1 != null)
          btnFindOrder1.Click -= eventHandler;
        this._btnFindOrder = value;
        Button btnFindOrder2 = this._btnFindOrder;
        if (btnFindOrder2 == null)
          return;
        btnFindOrder2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtOrder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.PartToBeCredited = new GroupBox();
      this.btnFindPart = new Button();
      this.txtPart = new TextBox();
      this.Label4 = new Label();
      this.btnFindSupplier = new Button();
      this.txtSupplier = new TextBox();
      this.Label3 = new Label();
      this.btnFindOrder = new Button();
      this.txtQty = new TextBox();
      this.txtOrder = new TextBox();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.PartToBeCredited.SuspendLayout();
      this.SuspendLayout();
      this.PartToBeCredited.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.PartToBeCredited.Controls.Add((Control) this.btnFindPart);
      this.PartToBeCredited.Controls.Add((Control) this.txtPart);
      this.PartToBeCredited.Controls.Add((Control) this.Label4);
      this.PartToBeCredited.Controls.Add((Control) this.btnFindSupplier);
      this.PartToBeCredited.Controls.Add((Control) this.txtSupplier);
      this.PartToBeCredited.Controls.Add((Control) this.Label3);
      this.PartToBeCredited.Controls.Add((Control) this.btnFindOrder);
      this.PartToBeCredited.Controls.Add((Control) this.txtQty);
      this.PartToBeCredited.Controls.Add((Control) this.txtOrder);
      this.PartToBeCredited.Controls.Add((Control) this.Label2);
      this.PartToBeCredited.Controls.Add((Control) this.Label1);
      this.PartToBeCredited.Location = new System.Drawing.Point(0, 3);
      this.PartToBeCredited.Name = "PartToBeCredited";
      this.PartToBeCredited.Size = new Size(548, 147);
      this.PartToBeCredited.TabIndex = 0;
      this.PartToBeCredited.TabStop = false;
      this.PartToBeCredited.Text = "Part To Be Credited";
      this.btnFindPart.Location = new System.Drawing.Point(465, 82);
      this.btnFindPart.Name = "btnFindPart";
      this.btnFindPart.Size = new Size(34, 23);
      this.btnFindPart.TabIndex = 8;
      this.btnFindPart.Text = "...";
      this.btnFindPart.UseVisualStyleBackColor = true;
      this.txtPart.Location = new System.Drawing.Point(106, 84);
      this.txtPart.Name = "txtPart";
      this.txtPart.ReadOnly = true;
      this.txtPart.Size = new Size(353, 21);
      this.txtPart.TabIndex = 7;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(18, 87);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(30, 13);
      this.Label4.TabIndex = 6;
      this.Label4.Text = "Part";
      this.btnFindSupplier.Location = new System.Drawing.Point(465, 55);
      this.btnFindSupplier.Name = "btnFindSupplier";
      this.btnFindSupplier.Size = new Size(34, 23);
      this.btnFindSupplier.TabIndex = 5;
      this.btnFindSupplier.Text = "...";
      this.btnFindSupplier.UseVisualStyleBackColor = true;
      this.txtSupplier.Location = new System.Drawing.Point(106, 57);
      this.txtSupplier.Name = "txtSupplier";
      this.txtSupplier.ReadOnly = true;
      this.txtSupplier.Size = new Size(353, 21);
      this.txtSupplier.TabIndex = 4;
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(18, 60);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(54, 13);
      this.Label3.TabIndex = 3;
      this.Label3.Text = "Supplier";
      this.btnFindOrder.Location = new System.Drawing.Point(465, 28);
      this.btnFindOrder.Name = "btnFindOrder";
      this.btnFindOrder.Size = new Size(34, 23);
      this.btnFindOrder.TabIndex = 2;
      this.btnFindOrder.Text = "...";
      this.btnFindOrder.UseVisualStyleBackColor = true;
      this.txtQty.Location = new System.Drawing.Point(106, 111);
      this.txtQty.Name = "txtQty";
      this.txtQty.Size = new Size(100, 21);
      this.txtQty.TabIndex = 10;
      this.txtOrder.Location = new System.Drawing.Point(106, 30);
      this.txtOrder.Name = "txtOrder";
      this.txtOrder.Size = new Size(353, 21);
      this.txtOrder.TabIndex = 1;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(18, 114);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(55, 13);
      this.Label2.TabIndex = 9;
      this.Label2.Text = "Quantity";
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(18, 33);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(40, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Order";
      this.Controls.Add((Control) this.PartToBeCredited);
      this.Name = nameof (UCPartsToBeCredited);
      this.Size = new Size(565, 163);
      this.PartToBeCredited.ResumeLayout(false);
      this.PartToBeCredited.PerformLayout();
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
        return (object) this.CurrentPartsToBeCredited;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public PartsToBeCredited CurrentPartsToBeCredited
    {
      get
      {
        return this._currentPartsToBeCredited;
      }
      set
      {
        this._currentPartsToBeCredited = value;
        if (this.CurrentPartsToBeCredited == null)
        {
          this._currentPartsToBeCredited = new PartsToBeCredited();
          this._currentPartsToBeCredited.Exists = false;
        }
        if (!this.CurrentPartsToBeCredited.Exists)
          return;
        this.Populate(0);
      }
    }

    public int OrderID
    {
      get
      {
        return this._OrderID;
      }
      set
      {
        this._OrderID = value;
        if (this._OrderID > 0)
        {
          Order order = App.DB.Order.Order_Get(this.OrderID);
          if (!order.Exists)
            return;
          this.txtOrder.Text = order.OrderReference;
          this.txtOrder.ReadOnly = true;
          DataRow[] dataRowArray = App.DB.Order.Order_ItemsGetAll(this.OrderID).Table.Select("SupplierID > 0 ");
          if (dataRowArray.Length > 0)
          {
            this.SupplierID = Conversions.ToInteger(dataRowArray[0]["SupplierID"]);
            this.btnFindSupplier.Enabled = false;
          }
          else
          {
            this.SupplierID = 0;
            this.btnFindSupplier.Enabled = true;
          }
        }
        else
        {
          this.txtOrder.Text = "";
          this.txtOrder.ReadOnly = false;
          this.SupplierID = 0;
          this.btnFindSupplier.Enabled = true;
        }
      }
    }

    public int SupplierID
    {
      get
      {
        return this._SupplierID;
      }
      set
      {
        this._SupplierID = value;
        if (this._SupplierID > 0)
        {
          Supplier supplier = App.DB.Supplier.Supplier_Get(this._SupplierID);
          if (!supplier.Exists)
            return;
          this.txtSupplier.Text = supplier.Name;
        }
        else
          this.txtSupplier.Text = "";
      }
    }

    private int PartID
    {
      get
      {
        return this._PartID;
      }
      set
      {
        this._PartID = value;
        if (this._PartID > 0)
        {
          Part part = App.DB.Part.Part_Get(this._PartID);
          if (part == null)
            return;
          this.txtPart.Text = part.Name + " (" + part.Number + ") ";
        }
        else
          this.txtPart.Text = "";
      }
    }

    private void UCPartsToBeCredited_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnFindOrder_Click(object sender, EventArgs e)
    {
      this.OrderID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblOrder, 0, "", false));
    }

    private void btnFindSupplier_Click(object sender, EventArgs e)
    {
      this.SupplierID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSupplier, 0, "", false));
    }

    private void btnFindPart_Click(object sender, EventArgs e)
    {
      this.FindPart("");
    }

    private void FindPart(string PartNumber = "")
    {
      this.PartID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblPart, this.OrderID, PartNumber, false));
      if (this.PartID <= 0 || this.SupplierID <= 0 || App.DB.PartSupplier.PartSupplierPacks_Get(this.PartID, this.SupplierID).Table.Rows.Count != 0)
        return;
      int num = (int) App.ShowMessage("This part is not supplied by the choosen supplier.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      string number = App.DB.Part.Part_Get(this.PartID).Number;
      this.PartID = 0;
      this.FindPart(number);
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentPartsToBeCredited = App.DB.PartsToBeCredited.PartsToBeCredited_Get(ID);
      this.OrderID = this.CurrentPartsToBeCredited.OrderID;
      this.SupplierID = this.CurrentPartsToBeCredited.SupplierID;
      this.PartID = this.CurrentPartsToBeCredited.PartID;
      this.txtOrder.Text = this.CurrentPartsToBeCredited.OrderReference;
      this.txtQty.Text = Conversions.ToString(this.CurrentPartsToBeCredited.Qty);
    }

    public bool Save()
    {
      bool flag1;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        bool flag2 = false;
        this.CurrentPartsToBeCredited.IgnoreExceptionsOnSetMethods = true;
        this.CurrentPartsToBeCredited.SetOrderID = (object) this.OrderID;
        this.CurrentPartsToBeCredited.SetSupplierID = (object) this.SupplierID;
        this.CurrentPartsToBeCredited.SetPartID = (object) this.PartID;
        this.CurrentPartsToBeCredited.SetQty = (object) this.txtQty.Text.Trim();
        this.CurrentPartsToBeCredited.SetStatusID = (object) 1;
        this.CurrentPartsToBeCredited.SetManuallyAdded = (object) true;
        this.CurrentPartsToBeCredited.SetOrderReference = (object) this.txtOrder.Text;
        new PartsToBeCreditedValidator().Validate(this.CurrentPartsToBeCredited);
        if (this.CurrentPartsToBeCredited.Exists)
        {
          App.DB.PartsToBeCredited.Update(this.CurrentPartsToBeCredited);
        }
        else
        {
          this.CurrentPartsToBeCredited = App.DB.PartsToBeCredited.Insert(this.CurrentPartsToBeCredited);
          flag2 = true;
        }
        if (flag2)
        {
          this.CurrentPartsToBeCredited = new PartsToBeCredited();
          this.PartID = 0;
          this.txtQty.Text = "";
          // ISSUE: reference to a compiler-generated field
          IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
          if (stateChangedEvent != null)
            stateChangedEvent(0);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
          if (stateChangedEvent != null)
            stateChangedEvent(this.CurrentPartsToBeCredited.PartsToBeCreditedID);
        }
        int num = (int) App.ShowMessage("Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        flag1 = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag1;
    }
  }
}
