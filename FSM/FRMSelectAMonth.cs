// Decompiled with JetBrains decompiler
// Type: FSM.FRMSelectAMonth
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
  public class FRMSelectAMonth : Form
  {
    private IContainer components;

    public FRMSelectAMonth()
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
      this.GroupBox1 = new GroupBox();
      this.dtpDateFrom = new DateTimePicker();
      this.btnOK = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Controls.Add((Control) this.dtpDateFrom);
      this.GroupBox1.Location = new System.Drawing.Point(8, 5);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(200, 73);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Select A Month";
      this.dtpDateFrom.CustomFormat = "MMMM yyyy";
      this.dtpDateFrom.Format = DateTimePickerFormat.Custom;
      this.dtpDateFrom.Location = new System.Drawing.Point(6, 19);
      this.dtpDateFrom.Name = "dtpDateFrom";
      this.dtpDateFrom.Size = new Size(188, 20);
      this.dtpDateFrom.TabIndex = 0;
      this.btnOK.Location = new System.Drawing.Point(60, 45);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(216, 84);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = nameof (FRMSelectAMonth);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Select A Month";
      this.GroupBox1.ResumeLayout(false);
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

    internal virtual DateTimePicker dtpDateFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }
  }
}
