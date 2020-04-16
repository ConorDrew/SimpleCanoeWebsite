// Decompiled with JetBrains decompiler
// Type: FSM.FRMContactDetails
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
  public class FRMContactDetails : FRMBaseForm, IForm
  {
    private IContainer components;

    public FRMContactDetails()
    {
      this.Load += new EventHandler(this.FRMContactDetails_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.lblName = new Label();
      this.lblTel = new Label();
      this.lblAddress1 = new Label();
      this.lblAddress2 = new Label();
      this.lblAddress3 = new Label();
      this.lblAddress4 = new Label();
      this.lblAddress5 = new Label();
      this.lblPostcode = new Label();
      this.SuspendLayout();
      this.lblName.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblName.Location = new System.Drawing.Point(8, 56);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(248, 16);
      this.lblName.TabIndex = 2;
      this.lblTel.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTel.Location = new System.Drawing.Point(32, 80);
      this.lblTel.Name = "lblTel";
      this.lblTel.Size = new Size(144, 16);
      this.lblTel.TabIndex = 7;
      this.lblAddress1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblAddress1.Location = new System.Drawing.Point(248, 80);
      this.lblAddress1.Name = "lblAddress1";
      this.lblAddress1.Size = new Size(184, 16);
      this.lblAddress1.TabIndex = 12;
      this.lblAddress2.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblAddress2.Location = new System.Drawing.Point(248, 104);
      this.lblAddress2.Name = "lblAddress2";
      this.lblAddress2.Size = new Size(184, 16);
      this.lblAddress2.TabIndex = 13;
      this.lblAddress3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblAddress3.Location = new System.Drawing.Point(248, 128);
      this.lblAddress3.Name = "lblAddress3";
      this.lblAddress3.Size = new Size(184, 16);
      this.lblAddress3.TabIndex = 14;
      this.lblAddress4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblAddress4.Location = new System.Drawing.Point(248, 152);
      this.lblAddress4.Name = "lblAddress4";
      this.lblAddress4.Size = new Size(184, 16);
      this.lblAddress4.TabIndex = 15;
      this.lblAddress5.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblAddress5.Location = new System.Drawing.Point(248, 176);
      this.lblAddress5.Name = "lblAddress5";
      this.lblAddress5.Size = new Size(184, 16);
      this.lblAddress5.TabIndex = 16;
      this.lblPostcode.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPostcode.Location = new System.Drawing.Point(248, 200);
      this.lblPostcode.Name = "lblPostcode";
      this.lblPostcode.Size = new Size(184, 16);
      this.lblPostcode.TabIndex = 17;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(448, 233);
      this.Controls.Add((Control) this.lblPostcode);
      this.Controls.Add((Control) this.lblAddress5);
      this.Controls.Add((Control) this.lblAddress4);
      this.Controls.Add((Control) this.lblAddress3);
      this.Controls.Add((Control) this.lblAddress2);
      this.Controls.Add((Control) this.lblAddress1);
      this.Controls.Add((Control) this.lblTel);
      this.Controls.Add((Control) this.lblName);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(464, 272);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(464, 272);
      this.Name = nameof (FRMContactDetails);
      this.Text = "Contact Sheet";
      this.Controls.SetChildIndex((Control) this.lblName, 0);
      this.Controls.SetChildIndex((Control) this.lblTel, 0);
      this.Controls.SetChildIndex((Control) this.lblAddress1, 0);
      this.Controls.SetChildIndex((Control) this.lblAddress2, 0);
      this.Controls.SetChildIndex((Control) this.lblAddress3, 0);
      this.Controls.SetChildIndex((Control) this.lblAddress4, 0);
      this.Controls.SetChildIndex((Control) this.lblAddress5, 0);
      this.Controls.SetChildIndex((Control) this.lblPostcode, 0);
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

    private void FRMContactDetails_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.lblName.Text = App.TheSystem.Configuration.CompanyName;
      this.lblAddress1.Text = App.TheSystem.Configuration.CompanyAddres1;
      this.lblAddress2.Text = App.TheSystem.Configuration.CompanyAddres2;
      this.lblAddress3.Text = App.TheSystem.Configuration.CompanyAddres3;
      this.lblAddress4.Text = App.TheSystem.Configuration.CompanyAddres4;
      this.lblAddress5.Text = App.TheSystem.Configuration.CompanyAddres5;
      this.lblPostcode.Text = App.TheSystem.Configuration.CompanyPostcode;
      this.lblTel.Text = App.TheSystem.Configuration.CompanyTelephoneNumber;
    }
  }
}
