// Decompiled with JetBrains decompiler
// Type: FSM.FRMFleetVanType
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
  public class FRMFleetVanType : FRMBaseForm, IForm
  {
    private IContainer components;
    private IUserControl TheLoadedControl;
    private int _ID;
    private Enums.FormState _pageState;

    public FRMFleetVanType()
    {
      this.Load += new EventHandler(this.FRMVan_Load);
      this._ID = 0;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCFleetVanType();
      this.pnlMain.Controls.Add((Control) this.TheLoadedControl);
      this.LoadedControl.StateChanged += new IUserControl.StateChangedEventHandler(this.ResetMe);
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

    internal virtual Panel pnlMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnSave = new Button();
      this.btnClose = new Button();
      this.pnlMain = new Panel();
      this.SuspendLayout();
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Location = new System.Drawing.Point(8, 182);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 25);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(72, 182);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 25);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlMain.Location = new System.Drawing.Point(0, 32);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new Size(580, 144);
      this.pnlMain.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(580, 220);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.pnlMain);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FRMVanType";
      this.Text = "Van Type: ID {0}";
      this.Controls.SetChildIndex((Control) this.pnlMain, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      ((UCFleetVanType) this.LoadedControl).CurrentVanType = App.DB.FleetVanType.Get(this.ID);
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) this.pnlMain.Controls[0];
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
        if (this.ID == 0)
        {
          this.PageState = Enums.FormState.Insert;
          this.Text = "Van Type: Adding New...";
        }
        else
        {
          this.PageState = Enums.FormState.Update;
          this.Text = "Van Type: ID " + Conversions.ToString(this.ID);
        }
      }
    }

    private Enums.FormState PageState
    {
      get
      {
        return this._pageState;
      }
      set
      {
        this._pageState = value;
      }
    }

    private void FRMVan_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.LoadedControl.Save())
        return;
      ((UCFleetVanType) this.LoadedControl).CurrentVanType = App.DB.FleetVanType.Get(this.ID);
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
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
