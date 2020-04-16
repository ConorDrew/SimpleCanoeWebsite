// Decompiled with JetBrains decompiler
// Type: FSM.FRMEnterEmailAddress
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMEnterEmailAddress : FRMBaseForm, IForm
  {
    private IContainer components;
    private Emails _email;

    public FRMEnterEmailAddress()
    {
      this.Load += new EventHandler(this.FRMEnterEmailAddress_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TextBox txtAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnEmail
    {
      get
      {
        return this._btnEmail;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEmail_Click);
        Button btnEmail1 = this._btnEmail;
        if (btnEmail1 != null)
          btnEmail1.Click -= eventHandler;
        this._btnEmail = value;
        Button btnEmail2 = this._btnEmail;
        if (btnEmail2 == null)
          return;
        btnEmail2.Click += eventHandler;
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

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.txtAddress = new TextBox();
      this.btnEmail = new Button();
      this.btnCancel = new Button();
      this.GroupBox1 = new GroupBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress.Location = new System.Drawing.Point(8, 24);
      this.txtAddress.Name = "txtAddress";
      this.txtAddress.Size = new Size(288, 21);
      this.txtAddress.TabIndex = 1;
      this.txtAddress.Text = "";
      this.btnEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnEmail.Location = new System.Drawing.Point(256, 104);
      this.btnEmail.Name = "btnEmail";
      this.btnEmail.Size = new Size(56, 23);
      this.btnEmail.TabIndex = 2;
      this.btnEmail.Text = "Send";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(8, 104);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(56, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.txtAddress);
      this.GroupBox1.Location = new System.Drawing.Point(8, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(304, 56);
      this.GroupBox1.TabIndex = 6;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Email Address";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(320, 134);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnEmail);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MaximumSize = new Size(326, 166);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(326, 166);
      this.Name = nameof (FRMEnterEmailAddress);
      this.Text = "Enter Email Address";
      this.Controls.SetChildIndex((Control) this.btnEmail, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public Emails Email
    {
      get
      {
        return this._email;
      }
      set
      {
        this._email = value;
      }
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.Email = (Emails) this.get_GetParameter(0);
      this.txtAddress.Text = this.Email.To;
    }

    public IUserControl LoadedControl
    {
      get
      {
        IUserControl userControl;
        return userControl;
      }
    }

    public void ResetMe(int newID)
    {
    }

    private void FRMEnterEmailAddress_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnEmail_Click(object sender, EventArgs e)
    {
      this.Email.To = this.txtAddress.Text;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
