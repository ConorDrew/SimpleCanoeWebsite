// Decompiled with JetBrains decompiler
// Type: FSM.FRMErrors
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMErrors : FRMBaseForm
  {
    private IContainer components;

    public FRMErrors(string errorString)
    {
      this.InitializeComponent();
      this.txtErrors.Text = errorString.Trim();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtErrors { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnClose = new Button();
      this.txtErrors = new TextBox();
      this.SuspendLayout();
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Location = new System.Drawing.Point(776, 432);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 23);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "Close";
      this.txtErrors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtErrors.Location = new System.Drawing.Point(8, 40);
      this.txtErrors.Multiline = true;
      this.txtErrors.Name = "txtErrors";
      this.txtErrors.ReadOnly = true;
      this.txtErrors.ScrollBars = ScrollBars.Both;
      this.txtErrors.Size = new Size(824, 384);
      this.txtErrors.TabIndex = 1;
      this.txtErrors.Text = "";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(840, 462);
      this.ControlBox = false;
      this.Controls.Add((Control) this.txtErrors);
      this.Controls.Add((Control) this.btnClose);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(848, 496);
      this.Name = nameof (FRMErrors);
      this.Text = "Job Portal - Import Errors";
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.txtErrors, 0);
      this.ResumeLayout(false);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
