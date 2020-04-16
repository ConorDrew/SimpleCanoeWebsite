// Decompiled with JetBrains decompiler
// Type: FSM.FRMGenDropBox
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
  [DesignerGenerated]
  public class FRMGenDropBox : Form
  {
    private IContainer components;
    public bool IncDD;

    public FRMGenDropBox()
    {
      this.Load += new EventHandler(this.FRMChangePriority_Load);
      this.IncDD = true;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMGenDropBox));
      this.GroupBox1 = new GroupBox();
      this.Button1 = new Button();
      this.lblTop = new Label();
      this.lblMiddle = new Label();
      this.lblref = new Label();
      this.txtref = new TextBox();
      this.btnOK = new Button();
      this.cbo1 = new ComboBox();
      this.cbo2 = new ComboBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.cbo2);
      this.GroupBox1.Controls.Add((Control) this.Button1);
      this.GroupBox1.Controls.Add((Control) this.lblTop);
      this.GroupBox1.Controls.Add((Control) this.lblMiddle);
      this.GroupBox1.Controls.Add((Control) this.lblref);
      this.GroupBox1.Controls.Add((Control) this.txtref);
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Controls.Add((Control) this.cbo1);
      this.GroupBox1.Location = new System.Drawing.Point(5, 1);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(505, 169);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.Button1.Location = new System.Drawing.Point(10, 140);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 7;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.lblTop.AutoSize = true;
      this.lblTop.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTop.ForeColor = Color.Maroon;
      this.lblTop.Location = new System.Drawing.Point(6, 19);
      this.lblTop.Name = "lblTop";
      this.lblTop.Size = new Size(366, 16);
      this.lblTop.TabIndex = 6;
      this.lblTop.Text = "You Must Take Payment Now In order to set up this Contract. ";
      this.lblMiddle.AutoSize = true;
      this.lblMiddle.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblMiddle.ForeColor = Color.Maroon;
      this.lblMiddle.Location = new System.Drawing.Point(5, 45);
      this.lblMiddle.Name = "lblMiddle";
      this.lblMiddle.Size = new Size(354, 16);
      this.lblMiddle.TabIndex = 5;
      this.lblMiddle.Text = " Please select payment type and detail payment reference";
      this.lblref.AutoSize = true;
      this.lblref.Location = new System.Drawing.Point(93, 115);
      this.lblref.Name = "lblref";
      this.lblref.Size = new Size(101, 13);
      this.lblref.TabIndex = 3;
      this.lblref.Text = "Payment Reference";
      this.txtref.Location = new System.Drawing.Point(200, 112);
      this.txtref.Name = "txtref";
      this.txtref.Size = new Size(226, 20);
      this.txtref.TabIndex = 2;
      this.btnOK.Location = new System.Drawing.Point(424, 140);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "Proceed";
      this.btnOK.UseVisualStyleBackColor = true;
      this.cbo1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo1.FormattingEnabled = true;
      this.cbo1.Location = new System.Drawing.Point(97, 76);
      this.cbo1.Name = "cbo1";
      this.cbo1.Size = new Size(330, 21);
      this.cbo1.TabIndex = 0;
      this.cbo2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo2.FormattingEnabled = true;
      this.cbo2.Location = new System.Drawing.Point(96, 76);
      this.cbo2.Name = "cbo2";
      this.cbo2.Size = new Size(330, 21);
      this.cbo2.TabIndex = 8;
      this.cbo2.Visible = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(513, 182);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FRMGenDropBox);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cbo1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTop { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMiddle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblref { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtref { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cbo2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.cbo1.Visible & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cbo1)) == 0.0)
      {
        int num1 = (int) App.ShowMessage("Please select a Valid Option", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.cbo2.Visible & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cbo2)) == 0.0)
      {
        int num2 = (int) App.ShowMessage("Please select a Valid Option", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.txtref.Visible & this.txtref.Text.Length == 0)
      {
        int num3 = (int) App.ShowMessage("Please enter a payment reference", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        this.DialogResult = DialogResult.OK;
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
    }

    private void FRMChangePriority_Load(object sender, EventArgs e)
    {
      ComboBox cbo1 = this.cbo1;
      Combo.SetUpCombo(ref cbo1, DynamicDataTables.ContractInitialPaymentTypes, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cbo1 = cbo1;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      ComboBox cbo1 = this.cbo1;
      Combo.SetSelectedComboItem_By_Value(ref cbo1, "0");
      this.cbo1 = cbo1;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
