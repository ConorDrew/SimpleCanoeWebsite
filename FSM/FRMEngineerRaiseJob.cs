// Decompiled with JetBrains decompiler
// Type: FSM.FRMEngineerRaiseJob
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMEngineerRaiseJob : FRMBaseForm
  {
    private IContainer components;

    public FRMEngineerRaiseJob()
    {
      this.Load += new EventHandler(this.FRMEngineer_Load);
      this.InitializeComponent();
      ComboBox cboEngineer = this.cboEngineer;
      Combo.SetUpCombo(ref cboEngineer, App.DB.Engineer.Engineer_GetAll().Table, "EngineerID", "Name", Enums.ComboValues.Please_Select);
      this.cboEngineer = cboEngineer;
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

    internal virtual CheckBox chkSuper { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnSave = new Button();
      this.btnClose = new Button();
      this.pnlMain = new Panel();
      this.chkSuper = new CheckBox();
      this.cboEngineer = new ComboBox();
      this.Label1 = new Label();
      this.pnlMain.SuspendLayout();
      this.SuspendLayout();
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Location = new System.Drawing.Point(8, 95);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 25);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(72, 95);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 25);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlMain.Controls.Add((Control) this.chkSuper);
      this.pnlMain.Controls.Add((Control) this.cboEngineer);
      this.pnlMain.Controls.Add((Control) this.Label1);
      this.pnlMain.Location = new System.Drawing.Point(0, 32);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new Size(613, 57);
      this.pnlMain.TabIndex = 1;
      this.chkSuper.AutoSize = true;
      this.chkSuper.Location = new System.Drawing.Point(417, 20);
      this.chkSuper.Name = "chkSuper";
      this.chkSuper.Size = new Size(88, 17);
      this.chkSuper.TabIndex = 2;
      this.chkSuper.Text = "Supervisor";
      this.chkSuper.UseVisualStyleBackColor = true;
      this.cboEngineer.FormattingEnabled = true;
      this.cboEngineer.Location = new System.Drawing.Point(116, 18);
      this.cboEngineer.Name = "cboEngineer";
      this.cboEngineer.Size = new Size(284, 21);
      this.cboEngineer.TabIndex = 1;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(48, 21);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(62, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Engineer:";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(621, 133);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.pnlMain);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(629, 100);
      this.Name = nameof (FRMEngineerRaiseJob);
      this.Text = "Engineer : ID {0}";
      this.Controls.SetChildIndex((Control) this.pnlMain, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.pnlMain.ResumeLayout(false);
      this.pnlMain.PerformLayout();
      this.ResumeLayout(false);
    }

    private void FRMEngineer_Load(object sender, EventArgs e)
    {
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboEngineer)) == 0.0)
      {
        int num = (int) Interaction.MsgBox((object) "Oops You haven't selected an Engineer", MsgBoxStyle.OkOnly, (object) "Error");
      }
      this.DialogResult = DialogResult.OK;
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
