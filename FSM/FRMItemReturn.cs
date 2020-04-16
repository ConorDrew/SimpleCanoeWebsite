// Decompiled with JetBrains decompiler
// Type: FSM.FRMItemReturn
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

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
  [DesignerGenerated]
  public class FRMItemReturn : Form
  {
    private IContainer components;

    public FRMItemReturn()
    {
      this.Load += new EventHandler(this.FRMChangePriority_Load);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMItemReturn));
      this.cboJobType = new ComboBox();
      this.btnOK = new Button();
      this.Button1 = new Button();
      this.GroupBox1 = new GroupBox();
      this.TextBox2 = new TextBox();
      this.TextBox1 = new TextBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.cboJobType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboJobType.FormattingEnabled = true;
      this.cboJobType.Location = new System.Drawing.Point(43, 158);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new Size(385, 21);
      this.cboJobType.TabIndex = 0;
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Location = new System.Drawing.Point(388, 241);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.Button1.UseVisualStyleBackColor = true;
      this.Button1.Location = new System.Drawing.Point(7, 241);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 2;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.GroupBox1.Controls.Add((Control) this.TextBox2);
      this.GroupBox1.Controls.Add((Control) this.TextBox1);
      this.GroupBox1.Controls.Add((Control) this.Button1);
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Controls.Add((Control) this.cboJobType);
      this.GroupBox1.Location = new System.Drawing.Point(5, 1);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(476, 270);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Distribute";
      this.TextBox2.Location = new System.Drawing.Point(43, 190);
      this.TextBox2.Name = "TextBox2";
      this.TextBox2.Size = new Size(385, 20);
      this.TextBox2.TabIndex = 4;
      this.TextBox1.BorderStyle = BorderStyle.None;
      this.TextBox1.Location = new System.Drawing.Point(7, 19);
      this.TextBox1.Multiline = true;
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(463, 121);
      this.TextBox1.TabIndex = 3;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(493, 283);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FRMItemReturn);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Part Distribution";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual ComboBox cboJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox TextBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox TextBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboJobType)) == 0.0)
      {
        int num1 = (int) App.ShowMessage("Please select an option", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboJobType)) == 2.0 & this.TextBox2.Text.Length < 2)
      {
        int num2 = (int) App.ShowMessage("Please enter a location to return / collect from", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMChangePriority_Load(object sender, EventArgs e)
    {
      DataTable table = App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority, false).Table;
      table.Select("Name<>'RC - Recall'");
      DataTable DT = table.Clone();
      DataRow row1 = DT.NewRow();
      row1["ManagerID"] = (object) 0;
      row1["Name"] = (object) " - Please Select - ";
      DT.Rows.Add(row1);
      DataRow row2 = DT.NewRow();
      row2["ManagerID"] = (object) 1;
      row2["Name"] = (object) " Original Engineer To return Parts to supplier as not needed ";
      DT.Rows.Add(row2);
      DataRow row3 = DT.NewRow();
      row3["ManagerID"] = (object) 2;
      row3["Name"] = (object) " Original Engineer to Return Parts to the below location ready for the next engineer to pick up. ";
      DT.Rows.Add(row3);
      ComboBox cboJobType = this.cboJobType;
      Combo.SetUpCombo(ref cboJobType, DT, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboJobType = cboJobType;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      ComboBox cboJobType = this.cboJobType;
      Combo.SetSelectedComboItem_By_Value(ref cboJobType, Conversions.ToString(0));
      this.cboJobType = cboJobType;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
