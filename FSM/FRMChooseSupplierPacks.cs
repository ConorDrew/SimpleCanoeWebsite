// Decompiled with JetBrains decompiler
// Type: FSM.FRMChooseSupplierPacks
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMChooseSupplierPacks : FRMBaseForm, IForm
  {
    private IContainer components;
    private SqlTransaction _trans;
    private int _supplierID;
    private int _productID;
    private int _partID;
    private int _productSupplierID;
    private int _partSupplierID;
    private int _Amount;

    public FRMChooseSupplierPacks()
    {
      this.Load += new EventHandler(this.FRMChooseSupplierPacks_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPacks { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.Label1 = new Label();
      this.cboPacks = new ComboBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.Label1.Location = new System.Drawing.Point(8, 40);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(248, 23);
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Item available in the following amounts:";
      this.cboPacks.Location = new System.Drawing.Point(256, 40);
      this.cboPacks.Name = "cboPacks";
      this.cboPacks.Size = new Size(240, 21);
      this.cboPacks.TabIndex = 3;
      this.btnOK.Location = new System.Drawing.Point(416, 72);
      this.btnOK.Name = "btnOK";
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnCancel.Location = new System.Drawing.Point(8, 72);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(504, 102);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.cboPacks);
      this.Controls.Add((Control) this.Label1);
      this.MaximumSize = new Size(512, 136);
      this.MinimumSize = new Size(512, 136);
      this.Name = nameof (FRMChooseSupplierPacks);
      this.Text = "Choose Packs";
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.cboPacks, 0);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.SupplierID = RuntimeHelpers.GetObjectValue(this.get_GetParameter(0));
      this.ProductID = Conversions.ToInteger(this.get_GetParameter(1));
      this.PartID = Conversions.ToInteger(this.get_GetParameter(2));
      this.Trans = (SqlTransaction) this.get_GetParameter(3);
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public void ResetMe(int newID)
    {
    }

    public SqlTransaction Trans
    {
      get
      {
        return this._trans;
      }
      set
      {
        this._trans = value;
      }
    }

    public object SupplierID
    {
      get
      {
        return (object) this._supplierID;
      }
      set
      {
        this._supplierID = Conversions.ToInteger(value);
      }
    }

    public int ProductID
    {
      get
      {
        return this._productID;
      }
      set
      {
        this._productID = value;
      }
    }

    public int PartID
    {
      get
      {
        return this._partID;
      }
      set
      {
        this._partID = value;
      }
    }

    public int ProductSupplierID
    {
      get
      {
        return this._productSupplierID;
      }
      set
      {
        this._productSupplierID = value;
      }
    }

    public int PartSupplierID
    {
      get
      {
        return this._partSupplierID;
      }
      set
      {
        this._partSupplierID = value;
      }
    }

    public int Amount
    {
      get
      {
        return this._Amount;
      }
      set
      {
        this._Amount = value;
      }
    }

    private void FRMChooseSupplierPacks_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.LoadPacks();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.ProductID > 0)
        this.ProductSupplierID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPacks));
      else
        this.PartSupplierID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPacks));
      this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    public object LoadPacks()
    {
      if (this.ProductID > 0)
      {
        DataTable DT = this.Trans == null ? App.DB.ProductSupplier.ProductSupplierPacks_Get(this.ProductID, Conversions.ToInteger(this.SupplierID)).Table : App.DB.ProductSupplier.ProductSupplierPacks_Get(this.ProductID, Conversions.ToInteger(this.SupplierID), this.Trans).Table;
        ComboBox cboPacks1 = this.cboPacks;
        Combo.SetUpCombo(ref cboPacks1, DT, "ProductSupplierID", "Packs", Enums.ComboValues.Please_Select);
        this.cboPacks = cboPacks1;
        ComboBox cboPacks2 = this.cboPacks;
        Combo.SetSelectedComboItem_By_Value(ref cboPacks2, Conversions.ToString(DT.Rows[0]["ProductSupplierID"]));
        this.cboPacks = cboPacks2;
      }
      else if (this.PartID > 0)
      {
        DataTable DT = this.Trans == null ? App.DB.PartSupplier.PartSupplierPacks_Get(this.PartID, Conversions.ToInteger(this.SupplierID)).Table : App.DB.PartSupplier.PartSupplierPacks_Get(this.PartID, Conversions.ToInteger(this.SupplierID), this.Trans).Table;
        ComboBox cboPacks1 = this.cboPacks;
        Combo.SetUpCombo(ref cboPacks1, DT, "PartSupplierID", "Packs", Enums.ComboValues.Please_Select);
        this.cboPacks = cboPacks1;
        ComboBox cboPacks2 = this.cboPacks;
        Combo.SetSelectedComboItem_By_Value(ref cboPacks2, Conversions.ToString(DT.Rows[0]["PartSupplierID"]));
        this.cboPacks = cboPacks2;
      }
      object obj;
      return obj;
    }
  }
}
