// Decompiled with JetBrains decompiler
// Type: FSM.FRMLastServiceDate
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sites;
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
  public class FRMLastServiceDate : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _ID;

    public FRMLastServiceDate()
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
      this.dtpActualServiceDate = new DateTimePicker();
      this.lblActualServiceDate = new Label();
      this.Label2 = new Label();
      this.btnSave = new Button();
      this.dtpLastServiceDate = new DateTimePicker();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dtpActualServiceDate);
      this.GroupBox1.Controls.Add((Control) this.lblActualServiceDate);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.btnSave);
      this.GroupBox1.Controls.Add((Control) this.dtpLastServiceDate);
      this.GroupBox1.Location = new System.Drawing.Point(12, 38);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(319, 118);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Change Last Service Date";
      this.dtpActualServiceDate.Location = new System.Drawing.Point(173, 43);
      this.dtpActualServiceDate.Name = "dtpActualServiceDate";
      this.dtpActualServiceDate.Size = new Size(139, 21);
      this.dtpActualServiceDate.TabIndex = 140;
      this.lblActualServiceDate.Location = new System.Drawing.Point(6, 49);
      this.lblActualServiceDate.Name = "lblActualServiceDate";
      this.lblActualServiceDate.Size = new Size(124, 20);
      this.lblActualServiceDate.TabIndex = 139;
      this.lblActualServiceDate.Text = "Service Date";
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(6, 23);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(108, 13);
      this.Label2.TabIndex = 138;
      this.Label2.Text = "Service Due Date";
      this.btnSave.Location = new System.Drawing.Point(237, 79);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 137;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.dtpLastServiceDate.Location = new System.Drawing.Point(173, 17);
      this.dtpLastServiceDate.Name = "dtpLastServiceDate";
      this.dtpLastServiceDate.Size = new Size(139, 21);
      this.dtpLastServiceDate.TabIndex = 136;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(343, 168);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FRMLastServiceDate);
      this.Text = "Change Last Service Date";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpActualServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblActualServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual DateTimePicker dtpLastServiceDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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
      FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) this.ID, SiteSQL.GetBy.SiteId, (object) null);
      if (site == null || !site.Exists)
        return;
      if ((uint) DateTime.Compare(site.LastServiceDate, DateTime.MinValue) > 0U)
      {
        this.dtpLastServiceDate.Value = site.LastServiceDate.AddYears(1);
        this.dtpActualServiceDate.Value = site.LastServiceDate;
      }
      if ((uint) DateTime.Compare(site.ActualServiceDate, DateTime.MinValue) > 0U)
        this.dtpActualServiceDate.Value = site.ActualServiceDate;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      App.DB.Sites.Site_UpdateLastServiceDate(this.ID, this.dtpLastServiceDate.Value.AddYears(-1), this.dtpActualServiceDate.Value, true);
      this.DialogResult = DialogResult.OK;
    }
  }
}
