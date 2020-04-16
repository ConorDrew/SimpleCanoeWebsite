// Decompiled with JetBrains decompiler
// Type: FSM.FRMSupport
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
  public class FRMSupport : FRMBaseForm, IForm
  {
    private IContainer components;

    public FRMSupport()
    {
      this.Load += new EventHandler(this.FRMSupport_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpContactUs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFax { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpContactUs = new GroupBox();
      this.Label1 = new Label();
      this.Label8 = new Label();
      this.Label2 = new Label();
      this.txtFax = new TextBox();
      this.txtTel = new TextBox();
      this.txtAddress = new TextBox();
      this.grpContactUs.SuspendLayout();
      this.SuspendLayout();
      this.grpContactUs.Anchor = AnchorStyles.Left;
      this.grpContactUs.Controls.Add((Control) this.Label1);
      this.grpContactUs.Controls.Add((Control) this.Label8);
      this.grpContactUs.Controls.Add((Control) this.Label2);
      this.grpContactUs.Controls.Add((Control) this.txtFax);
      this.grpContactUs.Controls.Add((Control) this.txtTel);
      this.grpContactUs.Controls.Add((Control) this.txtAddress);
      this.grpContactUs.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grpContactUs.Location = new System.Drawing.Point(8, 40);
      this.grpContactUs.Name = "grpContactUs";
      this.grpContactUs.Size = new Size(296, 264);
      this.grpContactUs.TabIndex = 8;
      this.grpContactUs.TabStop = false;
      this.grpContactUs.Text = "Contact Us";
      this.Label1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new System.Drawing.Point(16, 200);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(72, 23);
      this.Label1.TabIndex = 16;
      this.Label1.Text = "Tel";
      this.Label8.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label8.Location = new System.Drawing.Point(16, 232);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(72, 23);
      this.Label8.TabIndex = 15;
      this.Label8.Text = "Fax";
      this.Label2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.Location = new System.Drawing.Point(16, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(72, 23);
      this.Label2.TabIndex = 9;
      this.Label2.Text = "Address";
      this.txtFax.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFax.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtFax.Location = new System.Drawing.Point(104, 232);
      this.txtFax.Name = "txtFax";
      this.txtFax.ReadOnly = true;
      this.txtFax.Size = new Size(184, 20);
      this.txtFax.TabIndex = 3;
      this.txtFax.Text = "";
      this.txtTel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTel.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtTel.Location = new System.Drawing.Point(104, 200);
      this.txtTel.Name = "txtTel";
      this.txtTel.ReadOnly = true;
      this.txtTel.Size = new Size(184, 20);
      this.txtTel.TabIndex = 2;
      this.txtTel.Text = "";
      this.txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtAddress.Location = new System.Drawing.Point(104, 24);
      this.txtAddress.Multiline = true;
      this.txtAddress.Name = "txtAddress";
      this.txtAddress.ReadOnly = true;
      this.txtAddress.ScrollBars = ScrollBars.Both;
      this.txtAddress.Size = new Size(184, 168);
      this.txtAddress.TabIndex = 1;
      this.txtAddress.Text = "";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(312, 310);
      this.Controls.Add((Control) this.grpContactUs);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(320, 344);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(320, 344);
      this.Name = nameof (FRMSupport);
      this.Text = "Support";
      this.Controls.SetChildIndex((Control) this.grpContactUs, 0);
      this.grpContactUs.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.txtAddress.Text = App.TheSystem.Address;
      this.txtTel.Text = App.TheSystem.Telephone;
      this.txtFax.Text = App.TheSystem.Fax;
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

    private void FRMSupport_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }
  }
}
