// Decompiled with JetBrains decompiler
// Type: FSM.UCSearchStaff
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
  public class UCSearchStaff : UCBase, ISearchControl
  {
    private IContainer components;

    public UCSearchStaff()
    {
      this.Load += new EventHandler(this.UCSearchPerformanceSetup_Load);
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

    internal virtual ComboBox cboSearchFor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.Label1 = new Label();
      this.cboSearchFor = new ComboBox();
      this.Label2 = new Label();
      this.txtCriteria = new TextBox();
      this.btnFind = new Button();
      this.SuspendLayout();
      this.Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label1.Location = new System.Drawing.Point(8, 8);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(72, 16);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Search For";
      this.cboSearchFor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cboSearchFor.Cursor = Cursors.Hand;
      this.cboSearchFor.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSearchFor.Location = new System.Drawing.Point(8, 24);
      this.cboSearchFor.Name = "cboSearchFor";
      this.cboSearchFor.Size = new Size(152, 21);
      this.cboSearchFor.TabIndex = 1;
      this.Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label2.Location = new System.Drawing.Point(8, 48);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(152, 16);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Enter Search Criteria";
      this.txtCriteria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtCriteria.Location = new System.Drawing.Point(8, 64);
      this.txtCriteria.MaxLength = 25;
      this.txtCriteria.Name = "txtCriteria";
      this.txtCriteria.Size = new Size(105, 21);
      this.txtCriteria.TabIndex = 2;
      this.btnFind.AccessibleDescription = "Search for records by comparing multiple columns";
      this.btnFind.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnFind.Cursor = Cursors.Hand;
      this.btnFind.Location = new System.Drawing.Point(119, 64);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new Size(41, 23);
      this.btnFind.TabIndex = 3;
      this.btnFind.Text = "Find";
      this.btnFind.UseVisualStyleBackColor = true;
      this.Controls.Add((Control) this.btnFind);
      this.Controls.Add((Control) this.txtCriteria);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.cboSearchFor);
      this.Controls.Add((Control) this.Label1);
      this.Name = nameof (UCSearchStaff);
      this.Size = new Size(160, 96);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void ISearchControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      ComboBox cboSearchFor = this.cboSearchFor;
      Combo.SetUpCombo(ref cboSearchFor, DynamicDataTables.Setup_Search_Options(Enums.MenuTypes.Staff), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboSearchFor = cboSearchFor;
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
        if (Operators.CompareString(Left, Conversions.ToString(17), false) == 0)
          App.MainForm.SetSearchResults(App.DB.Engineer.Engineer_Search(this.txtCriteria.Text.Trim()), Enums.PageViewing.Engineer, false, false, "");
        else if (Operators.CompareString(Left, Conversions.ToString(21), false) == 0)
          App.MainForm.SetSearchResults(App.DB.Van.Van_Search(this.txtCriteria.Text.Trim()), Enums.PageViewing.Van, false, false, "");
        else if (Operators.CompareString(Left, Conversions.ToString(41), false) == 0)
          App.MainForm.SetSearchResults(App.DB.SubContractor.Subcontractor_Search(this.txtCriteria.Text.Trim()), Enums.PageViewing.Subcontractor, false, false, "");
        else if (Operators.CompareString(Left, Conversions.ToString(6), false) == 0)
          App.ShowForm(typeof (FRMUsers), false, new object[1]
          {
            (object) this.txtCriteria.Text.Trim()
          }, false);
        else if (Operators.CompareString(Left, Conversions.ToString(146), false) == 0)
          App.MainForm.SetSearchResults(App.DB.Engineer.Equipment_Search(this.txtCriteria.Text.Trim()), Enums.PageViewing.Equipment, false, false, "");
      }
    }

    private void UCSearchPerformanceSetup_Load(object sender, EventArgs e)
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
