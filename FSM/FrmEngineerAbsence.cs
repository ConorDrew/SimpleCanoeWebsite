// Decompiled with JetBrains decompiler
// Type: FSM.FrmEngineerAbsence
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FrmEngineerAbsence : FRMBaseForm
  {
    private IContainer components;
    private IUserControl TheLoadedControl;
    private int _absenceID;

    public FrmEngineerAbsence(int absenceID = 0)
    {
      this.Load += new EventHandler(this.FrmEngineerAbsence_Load);
      this._absenceID = 0;
      this.AbsenceID = absenceID;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCAbsences(Enums.UserType.Engineer, absenceID);
      this.pnlAbsence.Controls.Add((Control) this.TheLoadedControl);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

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

    internal virtual Panel pnlAbsence { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnCancel = new Button();
      this.btnSave = new Button();
      this.pnlAbsence = new Panel();
      this.SuspendLayout();
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Font = new Font("Verdana", 8f);
      this.btnCancel.Location = new System.Drawing.Point(12, 315);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(64, 23);
      this.btnCancel.TabIndex = 11;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Font = new Font("Verdana", 8f);
      this.btnSave.Location = new System.Drawing.Point(552, 315);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(64, 24);
      this.btnSave.TabIndex = 10;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.pnlAbsence.Location = new System.Drawing.Point(0, 53);
      this.pnlAbsence.Name = "pnlAbsence";
      this.pnlAbsence.Size = new Size(624, 249);
      this.pnlAbsence.TabIndex = 12;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.AutoSize = true;
      this.ClientSize = new Size(628, 343);
      this.Controls.Add((Control) this.pnlAbsence);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.btnCancel);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (FrmEngineerAbsence);
      this.Text = "Engineer Absence";
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.pnlAbsence, 0);
      this.ResumeLayout(false);
    }

    public int AbsenceID
    {
      get
      {
        return this._absenceID;
      }
      set
      {
        this._absenceID = value;
      }
    }

    private void FrmEngineerAbsence_Load(object sender, EventArgs e)
    {
      this.LoadForm((Form) this);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.TheLoadedControl.Save())
        return;
      this.Close();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
