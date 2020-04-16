// Decompiled with JetBrains decompiler
// Type: FSM.FRMContractWiz
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
  public class FRMContractWiz : FRMBaseForm, IForm
  {
    private IContainer components;
    private IUserControl TheLoadedControl;
    private int _ID;
    private int _IDToLinkTo;
    private Enums.FormState _pageState;

    public FRMContractWiz()
    {
      this.Load += new EventHandler(this.FRMContract_Load);
      this.Closing += new CancelEventHandler(this.FRMContractOriginal_Closing);
      this._ID = 0;
      this._IDToLinkTo = 0;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCContractWiz();
      this.pnlMain.Controls.Add((Control) this.TheLoadedControl);
      this.LoadedControl.StateChanged += new IUserControl.StateChangedEventHandler(this.ResetMe);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    public virtual Button btnSave
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

    public virtual Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    public virtual Button btnReprintExpiry
    {
      get
      {
        return this._btnReprintExpiry;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReprintExpiry_Click);
        Button btnReprintExpiry1 = this._btnReprintExpiry;
        if (btnReprintExpiry1 != null)
          btnReprintExpiry1.Click -= eventHandler;
        this._btnReprintExpiry = value;
        Button btnReprintExpiry2 = this._btnReprintExpiry;
        if (btnReprintExpiry2 == null)
          return;
        btnReprintExpiry2.Click += eventHandler;
      }
    }

    internal virtual Panel pnlMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnSave = new Button();
      this.btnClose = new Button();
      this.pnlMain = new Panel();
      this.Button1 = new Button();
      this.btnReprintExpiry = new Button();
      this.SuspendLayout();
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnSave.Location = new System.Drawing.Point(905, 734);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(171, 25);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Create Contract";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnClose.Location = new System.Drawing.Point(12, 734);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 25);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlMain.Location = new System.Drawing.Point(0, 32);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new Size(1076, 693);
      this.pnlMain.TabIndex = 1;
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Button1.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button1.Location = new System.Drawing.Point(714, 734);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(171, 25);
      this.Button1.TabIndex = 4;
      this.Button1.Text = "Print Documentation";
      this.btnReprintExpiry.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReprintExpiry.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnReprintExpiry.Location = new System.Drawing.Point(522, 731);
      this.btnReprintExpiry.Name = "btnReprintExpiry";
      this.btnReprintExpiry.Size = new Size(171, 25);
      this.btnReprintExpiry.TabIndex = 5;
      this.btnReprintExpiry.Text = "Print Expiry";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1084, 771);
      this.Controls.Add((Control) this.btnReprintExpiry);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.pnlMain);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(1100, 810);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(1100, 810);
      this.Name = nameof (FRMContractWiz);
      this.Text = "Contract : ID {0}";
      this.Controls.SetChildIndex((Control) this.pnlMain, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.Button1, 0);
      this.Controls.SetChildIndex((Control) this.btnReprintExpiry, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.IDToLinkTo = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1)));
      ((UCContractWiz) this.LoadedControl).CurrentContract = App.DB.ContractOriginal.Get(this.ID);
      ((UCContractWiz) this.LoadedControl).IDToLinkTo = this.IDToLinkTo;
      ((UCContractWiz) this.LoadedControl).SiteID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(2)));
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
          this.Text = "Contract : Adding New...";
        }
        else
        {
          this.PageState = Enums.FormState.Update;
          this.Text = "Contract : ID " + Conversions.ToString(this.ID);
        }
      }
    }

    public int IDToLinkTo
    {
      get
      {
        return this._IDToLinkTo;
      }
      set
      {
        this._IDToLinkTo = value;
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

    private void FRMContract_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.LoadedControl.Save())
        return;
      ((UCContractWiz) this.LoadedControl).CurrentContract = App.DB.ContractOriginal.Get(this.ID);
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      ((UCContractWiz) this.LoadedControl).ProcessContracts();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (!((UCContractWiz) this.LoadedControl).NumberUsed & ((UCContractWiz) this.LoadedControl).Number != null)
        App.DB.Job.DeleteReservedOrderNumber(((UCContractWiz) this.LoadedControl).Number.JobNumber, ((UCContractWiz) this.LoadedControl).Number.Prefix);
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMContractOriginal_Closing(object sender, CancelEventArgs e)
    {
      try
      {
        ((FRMContractManager) this.get_GetParameter(2)).PopulateDatagrid();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void btnReprintExpiry_Click(object sender, EventArgs e)
    {
      ((UCContractWiz) this.LoadedControl).ProcessExpiry();
    }
  }
}
