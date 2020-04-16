// Decompiled with JetBrains decompiler
// Type: FSM.FRMContractUpgradeDowngrade
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
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
  public class FRMContractUpgradeDowngrade : Form
  {
    private IContainer components;
    private DateTime _EffDate;

    public FRMContractUpgradeDowngrade()
    {
      this.Load += new EventHandler(this.FRMChangePriority_Load);
      this._EffDate = DateTime.MinValue;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMContractUpgradeDowngrade));
      this.GroupBox1 = new GroupBox();
      this.dtpEffDate = new DateTimePicker();
      this.btnCancel = new Button();
      this.lblText = new Label();
      this.btnOK = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.dtpEffDate);
      this.GroupBox1.Controls.Add((Control) this.btnCancel);
      this.GroupBox1.Controls.Add((Control) this.lblText);
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Location = new System.Drawing.Point(5, 1);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(364, 139);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.dtpEffDate.Location = new System.Drawing.Point(10, 56);
      this.dtpEffDate.Name = "dtpEffDate";
      this.dtpEffDate.Size = new Size(200, 20);
      this.dtpEffDate.TabIndex = 8;
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Location = new System.Drawing.Point(10, 102);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.lblText.AutoSize = true;
      this.lblText.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblText.ForeColor = Color.Black;
      this.lblText.Location = new System.Drawing.Point(7, 16);
      this.lblText.Name = "lblText";
      this.lblText.Size = new Size(346, 16);
      this.lblText.TabIndex = 5;
      this.lblText.Text = " Please select the date you want the change to take effect";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Location = new System.Drawing.Point(278, 102);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "Proceed";
      this.btnOK.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(376, 145);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FRMContractUpgradeDowngrade);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Contracts";
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

    internal virtual Label lblText { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual DateTimePicker dtpEffDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public DateTime EffDate
    {
      get
      {
        return this._EffDate;
      }
      set
      {
        this._EffDate = value;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.EffDate = this.dtpEffDate.Value;
      this.DialogResult = DialogResult.OK;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMChangePriority_Load(object sender, EventArgs e)
    {
      this.dtpEffDate.Value = DateAndTime.Now;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
