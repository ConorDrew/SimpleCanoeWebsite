// Decompiled with JetBrains decompiler
// Type: FSM.UCSearchSpares
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

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
  public class UCSearchSpares : UCBase, ISearchControl
  {
    private IContainer components;

    public UCSearchSpares()
    {
      this.Load += new EventHandler(this.UCSearchSetup_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSearchFor
    {
      get
      {
        return this._cboSearchFor;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboSearchFor_SelectedIndexChanged);
        ComboBox cboSearchFor1 = this._cboSearchFor;
        if (cboSearchFor1 != null)
          cboSearchFor1.SelectedIndexChanged -= eventHandler;
        this._cboSearchFor = value;
        ComboBox cboSearchFor2 = this._cboSearchFor;
        if (cboSearchFor2 == null)
          return;
        cboSearchFor2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TextBox txtCriteria
    {
      get
      {
        return this._txtCriteria;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtCriteria_KeyUp);
        TextBox txtCriteria1 = this._txtCriteria;
        if (txtCriteria1 != null)
          txtCriteria1.KeyUp -= keyEventHandler;
        this._txtCriteria = value;
        TextBox txtCriteria2 = this._txtCriteria;
        if (txtCriteria2 == null)
          return;
        txtCriteria2.KeyUp += keyEventHandler;
      }
    }

    internal virtual Button btnFind
    {
      get
      {
        return this._btnFind;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFind_Click);
        Button btnFind1 = this._btnFind;
        if (btnFind1 != null)
          btnFind1.Click -= eventHandler;
        this._btnFind = value;
        Button btnFind2 = this._btnFind;
        if (btnFind2 == null)
          return;
        btnFind2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboSearchOn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.Label1 = new Label();
      this.cboSearchFor = new ComboBox();
      this.Label2 = new Label();
      this.txtCriteria = new TextBox();
      this.btnFind = new Button();
      this.cboSearchOn = new ComboBox();
      this.Label3 = new Label();
      this.Label4 = new Label();
      this.SuspendLayout();
      this.Label1.Location = new System.Drawing.Point(8, 3);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(72, 16);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Search";
      this.cboSearchFor.Cursor = Cursors.Hand;
      this.cboSearchFor.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSearchFor.Location = new System.Drawing.Point(34, 18);
      this.cboSearchFor.Name = "cboSearchFor";
      this.cboSearchFor.Size = new Size(123, 21);
      this.cboSearchFor.TabIndex = 1;
      this.Label2.Location = new System.Drawing.Point(7, 65);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(152, 16);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Enter Search Criteria";
      this.txtCriteria.Location = new System.Drawing.Point(10, 84);
      this.txtCriteria.MaxLength = 25;
      this.txtCriteria.Name = "txtCriteria";
      this.txtCriteria.Size = new Size(96, 21);
      this.txtCriteria.TabIndex = 2;
      this.btnFind.AccessibleDescription = "Search for records by comparing multiple columns";
      this.btnFind.Cursor = Cursors.Hand;
      this.btnFind.Location = new System.Drawing.Point(112, 84);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new Size(45, 23);
      this.btnFind.TabIndex = 3;
      this.btnFind.Text = "Find";
      this.btnFind.UseVisualStyleBackColor = true;
      this.cboSearchOn.Cursor = Cursors.Hand;
      this.cboSearchOn.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSearchOn.Location = new System.Drawing.Point(34, 41);
      this.cboSearchOn.Name = "cboSearchOn";
      this.cboSearchOn.Size = new Size(123, 21);
      this.cboSearchOn.TabIndex = 4;
      this.Label3.Location = new System.Drawing.Point(8, 44);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(72, 16);
      this.Label3.TabIndex = 5;
      this.Label3.Text = "On";
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(8, 21);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(25, 13);
      this.Label4.TabIndex = 6;
      this.Label4.Text = "For";
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.cboSearchOn);
      this.Controls.Add((Control) this.btnFind);
      this.Controls.Add((Control) this.txtCriteria);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.cboSearchFor);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.Label3);
      this.Name = nameof (UCSearchSpares);
      this.Size = new Size(160, 111);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void ISearchControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      ComboBox cboSearchFor1 = this.cboSearchFor;
      Combo.SetUpCombo(ref cboSearchFor1, DynamicDataTables.Setup_Search_Options(Enums.MenuTypes.Spares), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboSearchFor = cboSearchFor1;
      ComboBox cboSearchFor2 = this.cboSearchFor;
      Combo.SetSelectedComboItem_By_Value(ref cboSearchFor2, Conversions.ToString(13));
      this.cboSearchFor = cboSearchFor2;
    }

    void ISearchControl.Search()
    {
      if (Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboSearchFor), "0", false) == 0)
      {
        int num = (int) App.ShowMessage("Please select what you would like to search for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        Navigation.Close_Middle();
        Navigation.Close_Right();
        Form[] mdiChildren = App.MainForm.MdiChildren;
        int index = 0;
        while (index < mdiChildren.Length)
        {
          mdiChildren[index].Dispose();
          checked { ++index; }
        }
        string Left = Combo.get_GetSelectedItemValue(this.cboSearchFor);
        if (Operators.CompareString(Left, Conversions.ToString(15), false) == 0)
          App.MainForm.SetSearchResults(App.DB.Supplier.Supplier_Search(this.txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(this.cboSearchOn)), Enums.PageViewing.Supplier, false, false, "");
        else if (Operators.CompareString(Left, Conversions.ToString(14), false) == 0)
          App.MainForm.SetSearchResults(App.DB.Product.Product_Search(this.txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(this.cboSearchOn)), Enums.PageViewing.Product, false, false, "");
        else if (Operators.CompareString(Left, Conversions.ToString(13), false) == 0)
          App.MainForm.SetSearchResults(App.DB.Part.Part_Search(this.txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(this.cboSearchOn)), Enums.PageViewing.Part, false, false, "");
        else if (Operators.CompareString(Left, Conversions.ToString(58), false) == 0)
          App.MainForm.SetSearchResults(App.DB.Warehouse.Warehouse_Search(this.txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(this.cboSearchOn)), Enums.PageViewing.Warehouse, false, false, "");
      }
    }

    private void cboSearchFor_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBox cboSearchOn1 = this.cboSearchOn;
      Combo.SetUpCombo(ref cboSearchOn1, DynamicDataTables.Setup_Search_On_Options(Enums.MenuTypes.Spares, (Enums.TableNames) Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboSearchFor))), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboSearchOn = cboSearchOn1;
      ComboBox cboSearchOn2 = this.cboSearchOn;
      Combo.SetSelectedComboItem_By_Value(ref cboSearchOn2, "");
      this.cboSearchOn = cboSearchOn2;
    }

    private void UCSearchSetup_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
      this.Search();
    }

    private void txtCriteria_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.Search();
    }
  }
}
