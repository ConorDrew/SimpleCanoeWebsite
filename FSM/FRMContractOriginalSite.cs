// Decompiled with JetBrains decompiler
// Type: FSM.FRMContractOriginalSite
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractsOriginal;
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
  public class FRMContractOriginalSite : FRMBaseForm, IForm
  {
    private IContainer components;
    private IUserControl TheLoadedControl;
    private int _ID;
    private int _SiteID;
    private int _OldContractSiteID;
    private ContractOriginal _CurrentContract;
    private Enums.FormState _pageState;

    public FRMContractOriginalSite()
    {
      this.Load += new EventHandler(this.FRMContractSite_Load);
      this._ID = 0;
      this._SiteID = 0;
      this._OldContractSiteID = 0;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCContractOriginalSite();
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
      this.btnSave.Location = new System.Drawing.Point(8, 656);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 25);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(72, 656);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 25);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlMain.Location = new System.Drawing.Point(0, 32);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new Size(942, 616);
      this.pnlMain.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(950, 694);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.pnlMain);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(958, 728);
      this.Name = nameof (FRMContractOriginalSite);
      this.Text = "Contract Property : ID {0}";
      this.Controls.SetChildIndex((Control) this.pnlMain, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.SiteID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1)));
      this.CurrentContract = (ContractOriginal) this.get_GetParameter(2);
      try
      {
        this.OldContractSiteID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(4)));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      ((UCContractOriginalSite) this.LoadedControl).SiteID = this.SiteID;
      ((UCContractOriginalSite) this.LoadedControl).CurrentContract = this.CurrentContract;
      ((UCContractOriginalSite) this.LoadedControl).OldContractSite = App.DB.ContractOriginalSite.Get(this.OldContractSiteID);
      ((UCContractOriginalSite) this.LoadedControl).CurrentContractSite = App.DB.ContractOriginalSite.Get(this.ID);
      ((UCContractOriginalSite) this.LoadedControl).PopAssets();
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ((UCContractOriginalSite) this.LoadedControl).SetupAssetsDataGrid();
      ((UCContractOriginalSite) this.LoadedControl).SetupVisitDataGrid();
      ((UCContractOriginalSite) this.LoadedControl).SetupVisit2DataGrid();
      ((UCContractOriginalSite) this.LoadedControl).SetupScheduleOfRatesDataGrid();
      ((UCContractOriginalSite) this.LoadedControl).SetupSystemRatesDataGrid();
      this.Location = new System.Drawing.Point(Conversions.ToInteger(Operators.AddObject(NewLateBinding.LateGet(NewLateBinding.LateGet(this.get_GetParameter(3), (System.Type) null, "Location", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "X", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) 50)), Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(this.get_GetParameter(3), (System.Type) null, "Location", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "Y", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null)));
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
          this.Text = "Contract Property : Adding New...";
        }
        else
        {
          this.PageState = Enums.FormState.Update;
          this.Text = "Contract Property : ID " + Conversions.ToString(this.ID);
        }
      }
    }

    private int SiteID
    {
      get
      {
        return this._SiteID;
      }
      set
      {
        this._SiteID = value;
      }
    }

    private int OldContractSiteID
    {
      get
      {
        return this._OldContractSiteID;
      }
      set
      {
        this._OldContractSiteID = value;
      }
    }

    public ContractOriginal CurrentContract
    {
      get
      {
        return this._CurrentContract;
      }
      set
      {
        this._CurrentContract = value;
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

    private void FRMContractSite_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.LoadedControl.Save())
        return;
      ((UCContractOriginalSite) this.LoadedControl).CurrentContractSite = App.DB.ContractOriginalSite.Get(this.ID);
      ((UCContractOriginalSite) this.LoadedControl).PopAssets();
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
