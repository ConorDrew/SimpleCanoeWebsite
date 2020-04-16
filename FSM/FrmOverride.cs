// Decompiled with JetBrains decompiler
// Type: FSM.FrmOverride
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FrmOverride : FRMBaseForm
  {
    private IContainer components;
    private bool isCopy;
    private int _engineerVisitID;
    private ArrayList _fails;
    private bool _cancelSchedule;
    private bool _passwordPrompt;

    public FrmOverride()
    {
      this.Load += new EventHandler(this.FrmOverride_Load);
      this.isCopy = false;
      this.InitializeComponent();
    }

    public FrmOverride(
      ArrayList fails,
      int engineerVisitIDIn,
      bool isCopyIn,
      bool _cancelScheduled,
      bool _passwordPrompt)
    {
      this.Load += new EventHandler(this.FrmOverride_Load);
      this.isCopy = false;
      this.InitializeComponent();
      this.ReasonsForFailure = fails;
      this.CancelSchedule = _cancelScheduled;
      this.PasswordPrompt = _passwordPrompt;
      this.EngineerVisitID = engineerVisitIDIn;
      this.isCopy = isCopyIn;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TreeView TreeView1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOk
    {
      get
      {
        return this._btnOk;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnYes_Click);
        Button btnOk1 = this._btnOk;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOk = value;
        Button btnOk2 = this._btnOk;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
      }
    }

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnNo_Click);
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
      this.TreeView1 = new TreeView();
      this.Label1 = new Label();
      this.GroupBox2 = new GroupBox();
      this.btnOk = new Button();
      this.btnCancel = new Button();
      this.GroupBox2.SuspendLayout();
      this.SuspendLayout();
      this.TreeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TreeView1.Font = new Font("Verdana", 8f);
      this.TreeView1.ImageIndex = -1;
      this.TreeView1.Location = new System.Drawing.Point(8, 56);
      this.TreeView1.Name = "TreeView1";
      this.TreeView1.SelectedImageIndex = -1;
      this.TreeView1.Size = new Size(518, 392);
      this.TreeView1.TabIndex = 1;
      this.Label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.Label1.Font = new Font("Verdana", 8f);
      this.Label1.Location = new System.Drawing.Point(8, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(501, 30);
      this.Label1.TabIndex = 1;
      this.Label1.Text = "The test you are trying to assign does not satisfy all the conditions of the engineer scheduler due to the reasons below.";
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.Label1);
      this.GroupBox2.Controls.Add((Control) this.TreeView1);
      this.GroupBox2.Font = new Font("Verdana", 8f);
      this.GroupBox2.Location = new System.Drawing.Point(8, 40);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(538, 456);
      this.GroupBox2.TabIndex = 5;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Result";
      this.btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Font = new Font("Verdana", 8f);
      this.btnOk.Location = new System.Drawing.Point(472, 504);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(72, 23);
      this.btnOk.TabIndex = 3;
      this.btnOk.Text = "Continue";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Font = new Font("Verdana", 8f);
      this.btnCancel.Location = new System.Drawing.Point(8, 502);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(72, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      this.AcceptButton = (IButtonControl) this.btnOk;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.CancelButton = (IButtonControl) this.btnCancel;
      this.ClientSize = new Size(552, 534);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOk);
      this.Controls.Add((Control) this.GroupBox2);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(560, 568);
      this.Name = nameof (FrmOverride);
      this.Text = "Are you sure you want to schedule this work here?";
      this.Controls.SetChildIndex((Control) this.GroupBox2, 0);
      this.Controls.SetChildIndex((Control) this.btnOk, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.GroupBox2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private int EngineerVisitID
    {
      get
      {
        return this._engineerVisitID;
      }
      set
      {
        this._engineerVisitID = value;
      }
    }

    public ArrayList ReasonsForFailure
    {
      get
      {
        return this._fails;
      }
      set
      {
        this._fails = value;
      }
    }

    private bool CancelSchedule
    {
      get
      {
        return this._cancelSchedule;
      }
      set
      {
        this._cancelSchedule = value;
      }
    }

    private bool PasswordPrompt
    {
      get
      {
        return this._passwordPrompt;
      }
      set
      {
        this._passwordPrompt = value;
      }
    }

    private void FrmOverride_Load(object sender, EventArgs e)
    {
      this.LoadForm((Form) this);
      this.LoadReasons();
    }

    private void LoadReasons()
    {
      int num = checked (this.ReasonsForFailure.Count - 1);
      int index = 0;
      while (index <= num)
      {
        this.TreeView1.Nodes.Add(Conversions.ToString(this.ReasonsForFailure[index]));
        checked { ++index; }
      }
    }

    private void btnNo_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.No;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnYes_Click(object sender, EventArgs e)
    {
      int num1 = checked (this.ReasonsForFailure.Count - 1);
      int num2 = 0;
      while (num2 <= num1)
      {
        if (this.PasswordPrompt)
        {
          DLGPasswordOverride passwordOverride = (DLGPasswordOverride) App.checkIfExists(typeof (DLGPasswordOverride).Name, true) ?? (DLGPasswordOverride) Activator.CreateInstance(typeof (DLGPasswordOverride));
          passwordOverride.ShowInTaskbar = false;
          int num3 = (int) passwordOverride.ShowDialog();
          if (passwordOverride.DialogResult == DialogResult.OK)
          {
            this.DialogResult = DialogResult.OK;
            break;
          }
          this.DialogResult = DialogResult.No;
          int num4 = (int) App.ShowMessage("Override Password is required to continue, visit not scheduled.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          break;
        }
        if (this.CancelSchedule)
        {
          this.DialogResult = DialogResult.No;
          int num3 = (int) App.ShowMessage("Visit not scheduled.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          break;
        }
        this.DialogResult = DialogResult.OK;
        checked { ++num2; }
      }
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
