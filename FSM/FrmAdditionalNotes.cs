// Decompiled with JetBrains decompiler
// Type: FSM.FrmAdditionalNotes
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
  public class FrmAdditionalNotes : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _ID;

    public FrmAdditionalNotes()
    {
      this.Load += new EventHandler(this.FRMLastServiceDate_Load);
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
      this.btnSave = new Button();
      this.txtAdditionalNotes = new TextBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.txtAdditionalNotes);
      this.GroupBox1.Controls.Add((Control) this.btnSave);
      this.GroupBox1.Location = new System.Drawing.Point(12, 38);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(504, 118);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Please Detail Additional Access/Appointment Info";
      this.btnSave.Location = new System.Drawing.Point(423, 89);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 3;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.txtAdditionalNotes.Location = new System.Drawing.Point(6, 20);
      this.txtAdditionalNotes.Multiline = true;
      this.txtAdditionalNotes.Name = "txtAdditionalNotes";
      this.txtAdditionalNotes.Size = new Size(492, 49);
      this.txtAdditionalNotes.TabIndex = 4;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(528, 168);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FrmAdditionalNotes);
      this.Text = "Add Access/Appointment Info";
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

    internal virtual TextBox txtAdditionalNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
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

    private void FRMLastServiceDate_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void cboContractCode_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
  }
}
