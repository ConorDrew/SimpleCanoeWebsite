// Decompiled with JetBrains decompiler
// Type: FSM.DLGPasswordOverride
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
  public class DLGPasswordOverride : FRMBaseForm, IForm
  {
    private IContainer components;

    public DLGPasswordOverride()
    {
      this.Load += new EventHandler(this.DLGPasswordOverride_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TextBox txtPassword { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOk
    {
      get
      {
        return this._btnOk;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOk_Click);
        Button btnOk1 = this._btnOk;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOk = value;
        Button btnOk2 = this._btnOk;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.btnCancel = new Button();
      this.txtPassword = new TextBox();
      this.btnOk = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.btnCancel);
      this.GroupBox1.Controls.Add((Control) this.txtPassword);
      this.GroupBox1.Controls.Add((Control) this.btnOk);
      this.GroupBox1.FlatStyle = FlatStyle.System;
      this.GroupBox1.Location = new System.Drawing.Point(8, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(304, 64);
      this.GroupBox1.TabIndex = 4;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Please enter override password to continue";
      this.btnCancel.AccessibleDescription = "Cancel entry";
      this.btnCancel.Cursor = Cursors.Hand;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Location = new System.Drawing.Point(248, 24);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(48, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.txtPassword.Location = new System.Drawing.Point(8, 24);
      this.txtPassword.MaxLength = 50;
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new Size(176, 21);
      this.txtPassword.TabIndex = 1;
      this.txtPassword.Text = "";
      this.btnOk.AccessibleDescription = "Try password";
      this.btnOk.Cursor = Cursors.Hand;
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Location = new System.Drawing.Point(192, 24);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(48, 23);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "OK";
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(320, 110);
      this.Controls.Add((Control) this.GroupBox1);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(328, 144);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(328, 144);
      this.Name = nameof (DLGPasswordOverride);
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    void IForm.ResetMe(int newID)
    {
    }

    private void DLGPasswordOverride_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (Operators.CompareString(Helper.HashPassword(this.txtPassword.Text.Trim()), App.DB.Manager.Get().OverridePassword, false) == 0)
        this.DialogResult = DialogResult.OK;
      else
        this.DialogResult = DialogResult.Cancel;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }
  }
}
