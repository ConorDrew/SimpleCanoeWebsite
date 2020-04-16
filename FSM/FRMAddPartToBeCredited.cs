// Decompiled with JetBrains decompiler
// Type: FSM.FRMAddPartToBeCredited
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
  public class FRMAddPartToBeCredited : FRMBaseForm, IForm
  {
    private IContainer components;

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
      this.GroupBox1 = new GroupBox();
      this.Label2 = new Label();
      this.txtQtyToReturn = new TextBox();
      this.txtQtyAvailable = new TextBox();
      this.Label1 = new Label();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btnOK.Location = new System.Drawing.Point(298, 52);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.txtQtyToReturn);
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Controls.Add((Control) this.txtQtyAvailable);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Location = new System.Drawing.Point(12, 38);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(384, 91);
      this.GroupBox1.TabIndex = 3;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Return part to the supplier for credit?";
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(6, 57);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(115, 13);
      this.Label2.TabIndex = 3;
      this.Label2.Text = "Quantity To Return";
      this.txtQtyToReturn.Location = new System.Drawing.Point(123, 54);
      this.txtQtyToReturn.Name = "txtQtyToReturn";
      this.txtQtyToReturn.Size = new Size(100, 21);
      this.txtQtyToReturn.TabIndex = 2;
      this.txtQtyToReturn.Text = "0";
      this.txtQtyToReturn.TextAlign = HorizontalAlignment.Right;
      this.txtQtyAvailable.Location = new System.Drawing.Point(123, 27);
      this.txtQtyAvailable.Name = "txtQtyAvailable";
      this.txtQtyAvailable.ReadOnly = true;
      this.txtQtyAvailable.Size = new Size(100, 21);
      this.txtQtyAvailable.TabIndex = 1;
      this.txtQtyAvailable.TextAlign = HorizontalAlignment.Right;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(6, 30);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(111, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Quantity Available";
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(406, 136);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FRMAddPartToBeCredited);
      this.Text = "Add Part To Be Credited";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
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

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQtyToReturn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQtyAvailable { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public FRMAddPartToBeCredited(int qty)
    {
      this.InitializeComponent();
      this.txtQtyAvailable.Text = Conversions.ToString(qty);
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

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (Helper.MakeIntegerValid((object) this.txtQtyAvailable.Text) < Helper.MakeIntegerValid((object) this.txtQtyToReturn.Text))
      {
        int num = (int) App.ShowMessage("Cannot return more than was allocated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
        this.DialogResult = DialogResult.OK;
    }
  }
}
