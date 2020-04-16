// Decompiled with JetBrains decompiler
// Type: FSM.FRMChangeRaiseDate
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
  public class FRMChangeRaiseDate : FRMBaseForm, IForm
  {
    private IContainer components;
    public DateTimePicker dtpTaxDate;
    private int typeID;
    private int _ID;

    public FRMChangeRaiseDate()
    {
      this.Load += new EventHandler(this.FRMChangeInvoicedTotal_Load);
      this._ID = 0;
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
      this.GroupBox1 = new GroupBox();
      this.dtpTaxDate = new DateTimePicker();
      this.Label3 = new Label();
      this.btnSave = new Button();
      this.txtPassword = new TextBox();
      this.Label1 = new Label();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dtpTaxDate);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.btnSave);
      this.GroupBox1.Controls.Add((Control) this.txtPassword);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Location = new System.Drawing.Point(12, 38);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(502, 263);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.dtpTaxDate.Location = new System.Drawing.Point(194, 68);
      this.dtpTaxDate.Name = "dtpTaxDate";
      this.dtpTaxDate.Size = new Size(291, 21);
      this.dtpTaxDate.TabIndex = 13;
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(6, 76);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(58, 13);
      this.Label3.TabIndex = 5;
      this.Label3.Text = "Tax Date";
      this.btnSave.Enabled = false;
      this.btnSave.Location = new System.Drawing.Point(410, 234);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.txtPassword.Location = new System.Drawing.Point(194, 27);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new Size(291, 21);
      this.txtPassword.TabIndex = 1;
      this.txtPassword.UseSystemPasswordChar = true;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(6, 30);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(169, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Enter the override password";
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(526, 313);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FRMChangeRaiseDate);
      this.Text = "Confirm Raised Date";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtPassword
    {
      get
      {
        return this._txtPassword;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPassword_TextChanged);
        TextBox txtPassword1 = this._txtPassword;
        if (txtPassword1 != null)
          txtPassword1.TextChanged -= eventHandler;
        this._txtPassword = value;
        TextBox txtPassword2 = this._txtPassword;
        if (txtPassword2 == null)
          return;
        txtPassword2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.dtpTaxDate.Enabled = false;
      this.btnSave.Enabled = false;
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
      this.ID = newID;
    }

    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
      }
    }

    private void FRMChangeInvoicedTotal_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void txtPassword_TextChanged(object sender, EventArgs e)
    {
      if (Operators.CompareString(Helper.HashPassword(this.txtPassword.Text.Trim()), Helper.HashPassword("boiler123"), false) == 0)
      {
        this.dtpTaxDate.Enabled = true;
        this.btnSave.Enabled = true;
      }
      else
      {
        this.dtpTaxDate.Enabled = false;
        this.btnSave.Enabled = false;
      }
    }
  }
}
