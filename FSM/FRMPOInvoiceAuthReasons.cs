// Decompiled with JetBrains decompiler
// Type: FSM.FRMPOInvoiceAuthReasons
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

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
  public class FRMPOInvoiceAuthReasons : FRMBaseForm, IForm
  {
    private IContainer components;
    public string _AuthReason;
    public string _AuthReasonDetail;

    public FRMPOInvoiceAuthReasons()
    {
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
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.grbAuthReasons = new GroupBox();
      this.txtAuthReasonOther = new TextBox();
      this.AuthReasonOption1 = new RadioButton();
      this.AuthReasonOption3 = new RadioButton();
      this.AuthReasonOption2 = new RadioButton();
      this.grbAuthReasons.SuspendLayout();
      this.SuspendLayout();
      this.btnOK.Location = new System.Drawing.Point(441, 347);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnCancel.Location = new System.Drawing.Point(360, 347);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Visible = false;
      this.grbAuthReasons.Controls.Add((Control) this.txtAuthReasonOther);
      this.grbAuthReasons.Controls.Add((Control) this.AuthReasonOption1);
      this.grbAuthReasons.Controls.Add((Control) this.AuthReasonOption3);
      this.grbAuthReasons.Controls.Add((Control) this.AuthReasonOption2);
      this.grbAuthReasons.Location = new System.Drawing.Point(12, 48);
      this.grbAuthReasons.Name = "grbAuthReasons";
      this.grbAuthReasons.Size = new Size(504, 119);
      this.grbAuthReasons.TabIndex = 17;
      this.grbAuthReasons.TabStop = false;
      this.grbAuthReasons.Text = "Authorisation Reason";
      this.txtAuthReasonOther.Location = new System.Drawing.Point(48, 82);
      this.txtAuthReasonOther.Name = "txtAuthReasonOther";
      this.txtAuthReasonOther.Size = new Size(433, 21);
      this.txtAuthReasonOther.TabIndex = 16;
      this.AuthReasonOption1.AutoSize = true;
      this.AuthReasonOption1.Location = new System.Drawing.Point(48, 18);
      this.AuthReasonOption1.Name = "AuthReasonOption1";
      this.AuthReasonOption1.Size = new Size(213, 17);
      this.AuthReasonOption1.TabIndex = 13;
      this.AuthReasonOption1.TabStop = true;
      this.AuthReasonOption1.Text = "PO price wrong but value correct";
      this.AuthReasonOption1.UseVisualStyleBackColor = true;
      this.AuthReasonOption3.AutoSize = true;
      this.AuthReasonOption3.Location = new System.Drawing.Point(48, 58);
      this.AuthReasonOption3.Name = "AuthReasonOption3";
      this.AuthReasonOption3.Size = new Size(57, 17);
      this.AuthReasonOption3.TabIndex = 15;
      this.AuthReasonOption3.TabStop = true;
      this.AuthReasonOption3.Text = "Other";
      this.AuthReasonOption3.UseVisualStyleBackColor = true;
      this.AuthReasonOption2.AutoSize = true;
      this.AuthReasonOption2.Location = new System.Drawing.Point(48, 39);
      this.AuthReasonOption2.Name = "AuthReasonOption2";
      this.AuthReasonOption2.Size = new Size(200, 17);
      this.AuthReasonOption2.TabIndex = 14;
      this.AuthReasonOption2.TabStop = true;
      this.AuthReasonOption2.Text = "PO price wrong credit required";
      this.AuthReasonOption2.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(528, 382);
      this.Controls.Add((Control) this.grbAuthReasons);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Name = nameof (FRMPOInvoiceAuthReasons);
      this.Text = nameof (FRMPOInvoiceAuthReasons);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.grbAuthReasons, 0);
      this.grbAuthReasons.ResumeLayout(false);
      this.grbAuthReasons.PerformLayout();
      this.ResumeLayout(false);
    }

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

    internal virtual GroupBox grbAuthReasons { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAuthReasonOther
    {
      get
      {
        return this._txtAuthReasonOther;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtAuthReasonOther_TextChanged);
        TextBox txtAuthReasonOther1 = this._txtAuthReasonOther;
        if (txtAuthReasonOther1 != null)
          txtAuthReasonOther1.TextChanged -= eventHandler;
        this._txtAuthReasonOther = value;
        TextBox txtAuthReasonOther2 = this._txtAuthReasonOther;
        if (txtAuthReasonOther2 == null)
          return;
        txtAuthReasonOther2.TextChanged += eventHandler;
      }
    }

    internal virtual RadioButton AuthReasonOption1
    {
      get
      {
        return this._AuthReasonOption1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.AuthReasonOption1_CheckedChanged);
        RadioButton authReasonOption1_1 = this._AuthReasonOption1;
        if (authReasonOption1_1 != null)
          authReasonOption1_1.CheckedChanged -= eventHandler;
        this._AuthReasonOption1 = value;
        RadioButton authReasonOption1_2 = this._AuthReasonOption1;
        if (authReasonOption1_2 == null)
          return;
        authReasonOption1_2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton AuthReasonOption3
    {
      get
      {
        return this._AuthReasonOption3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.AuthReasonOption3_CheckedChanged);
        RadioButton authReasonOption3_1 = this._AuthReasonOption3;
        if (authReasonOption3_1 != null)
          authReasonOption3_1.CheckedChanged -= eventHandler;
        this._AuthReasonOption3 = value;
        RadioButton authReasonOption3_2 = this._AuthReasonOption3;
        if (authReasonOption3_2 == null)
          return;
        authReasonOption3_2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton AuthReasonOption2
    {
      get
      {
        return this._AuthReasonOption2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.AuthReasonOption2_CheckedChanged);
        RadioButton authReasonOption2_1 = this._AuthReasonOption2;
        if (authReasonOption2_1 != null)
          authReasonOption2_1.CheckedChanged -= eventHandler;
        this._AuthReasonOption2 = value;
        RadioButton authReasonOption2_2 = this._AuthReasonOption2;
        if (authReasonOption2_2 == null)
          return;
        authReasonOption2_2.CheckedChanged += eventHandler;
      }
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public void LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
    }

    public void ResetMe(int newID)
    {
    }

    public string AuthReason
    {
      get
      {
        string str;
        return str;
      }
      set
      {
        this._AuthReason = value;
      }
    }

    public string AuthReasonDetail
    {
      get
      {
        string str;
        return str;
      }
      set
      {
        this._AuthReasonDetail = value;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.AuthReasonOption3.Checked & Operators.CompareString(this.txtAuthReasonOther.Text, "", false) == 0)
      {
        int num = (int) App.ShowMessage("An error has occurred:\r\nWhen selecting other you must enter a reason", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void AuthReasonOption1_CheckedChanged(object sender, EventArgs e)
    {
      this._AuthReason = this.AuthReasonOption1.Text;
    }

    private void AuthReasonOption2_CheckedChanged(object sender, EventArgs e)
    {
      this._AuthReason = this.AuthReasonOption2.Text;
    }

    private void AuthReasonOption3_CheckedChanged(object sender, EventArgs e)
    {
      this._AuthReason = this.AuthReasonOption3.Text;
    }

    private void txtAuthReasonOther_TextChanged(object sender, EventArgs e)
    {
      this._AuthReasonDetail = this.txtAuthReasonOther.Text;
    }
  }
}
