// Decompiled with JetBrains decompiler
// Type: FSM.FRMManualApp
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
  public class FRMManualApp : Form
  {
    private IContainer components;

    public FRMManualApp()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMManualApp));
      this.GroupBox1 = new GroupBox();
      this.Button1 = new Button();
      this.lblMsg = new Label();
      this.btnOK = new Button();
      this.cboInitialPaymentType = new ComboBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.Button1);
      this.GroupBox1.Controls.Add((Control) this.lblMsg);
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Controls.Add((Control) this.cboInitialPaymentType);
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
      this.lblMsg.AutoSize = true;
      this.lblMsg.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblMsg.ForeColor = Color.Maroon;
      this.lblMsg.Location = new System.Drawing.Point(6, 19);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new Size(489, 16);
      this.lblMsg.TabIndex = 6;
      this.lblMsg.Text = "As you haven't identified a description of an applaince please provide one below.";
      this.btnOK.Location = new System.Drawing.Point(424, 140);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "Proceed";
      this.btnOK.UseVisualStyleBackColor = true;
      this.cboInitialPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInitialPaymentType.FormattingEnabled = true;
      this.cboInitialPaymentType.Location = new System.Drawing.Point(96, 47);
      this.cboInitialPaymentType.Name = "cboInitialPaymentType";
      this.cboInitialPaymentType.Size = new Size(330, 21);
      this.cboInitialPaymentType.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(513, 182);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FRMManualApp);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Take Payment";
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

    internal virtual ComboBox cboInitialPaymentType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMsg { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboInitialPaymentType)) == 0.0)
      {
        int num = (int) App.ShowMessage("Please select an Appliance type", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMChangePriority_Load(object sender, EventArgs e)
    {
      ComboBox initialPaymentType = this.cboInitialPaymentType;
      Combo.SetUpCombo(ref initialPaymentType, DynamicDataTables.ManualApp, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboInitialPaymentType = initialPaymentType;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      ComboBox initialPaymentType = this.cboInitialPaymentType;
      Combo.SetSelectedComboItem_By_Value(ref initialPaymentType, "0");
      this.cboInitialPaymentType = initialPaymentType;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
