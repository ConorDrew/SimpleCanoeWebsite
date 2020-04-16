// Decompiled with JetBrains decompiler
// Type: FSM.UCSignature
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCSignature : UserControl
  {
    private IContainer components;
    private string _signatureData;

    public UCSignature()
    {
      this._signatureData = "";
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual PictureBox pbSignature { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.pbSignature = new PictureBox();
      this.SuspendLayout();
      this.pbSignature.Location = new System.Drawing.Point(0, 0);
      this.pbSignature.Name = "pbSignature";
      this.pbSignature.Size = new Size(320, 88);
      this.pbSignature.TabIndex = 12;
      this.pbSignature.TabStop = false;
      this.Controls.Add((Control) this.pbSignature);
      this.Name = nameof (UCSignature);
      this.Size = new Size(320, 88);
      this.ResumeLayout(false);
    }

    public string SignatureData
    {
      get
      {
        return this._signatureData;
      }
      set
      {
        this._signatureData = value;
        PictureBox pbSignature = this.pbSignature;
        SignatureBox signatureBox = new SignatureBox(ref pbSignature);
        this.pbSignature = pbSignature;
        signatureBox.plotSignature(this.SignatureData);
      }
    }
  }
}
