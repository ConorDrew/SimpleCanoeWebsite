// Decompiled with JetBrains decompiler
// Type: FSM.FRMJobWizard
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
  public class FRMJobWizard : FRMBaseForm, IForm
  {
    private IContainer components;
    private IUserControl TheLoadedControl;
    private int _ID;
    private Enums.FormState _pageState;

    public FRMJobWizard()
    {
      this.Load += new EventHandler(this.FRMSite_Load);
      this._ID = 0;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCJobWizard();
      this.pnlMain.Controls.Add((Control) this.TheLoadedControl);
      this.LoadedControl.StateChanged += new IUserControl.StateChangedEventHandler(this.ResetMe);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
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

    internal virtual Button btnPrivateNotes
    {
      get
      {
        return this._btnPrivateNotes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReset_Click);
        Button btnPrivateNotes1 = this._btnPrivateNotes;
        if (btnPrivateNotes1 != null)
          btnPrivateNotes1.Click -= eventHandler;
        this._btnPrivateNotes = value;
        Button btnPrivateNotes2 = this._btnPrivateNotes;
        if (btnPrivateNotes2 == null)
          return;
        btnPrivateNotes2.Click += eventHandler;
      }
    }

    internal virtual Button btnReset
    {
      get
      {
        return this._btnReset;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReset_Click_1);
        Button btnReset1 = this._btnReset;
        if (btnReset1 != null)
          btnReset1.Click -= eventHandler;
        this._btnReset = value;
        Button btnReset2 = this._btnReset;
        if (btnReset2 == null)
          return;
        btnReset2.Click += eventHandler;
      }
    }

    internal virtual Button btnSaveProg
    {
      get
      {
        return this._btnSaveProg;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button btnSaveProg1 = this._btnSaveProg;
        if (btnSaveProg1 != null)
          btnSaveProg1.Click -= eventHandler;
        this._btnSaveProg = value;
        Button btnSaveProg2 = this._btnSaveProg;
        if (btnSaveProg2 == null)
          return;
        btnSaveProg2.Click += eventHandler;
      }
    }

    internal virtual Panel pnlMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnClose = new Button();
      this.pnlMain = new Panel();
      this.btnPrivateNotes = new Button();
      this.btnReset = new Button();
      this.btnSaveProg = new Button();
      this.SuspendLayout();
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(12, 724);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(87, 25);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlMain.Location = new System.Drawing.Point(0, 32);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new Size(926, 685);
      this.pnlMain.TabIndex = 1;
      this.btnPrivateNotes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnPrivateNotes.Location = new System.Drawing.Point(380, 724);
      this.btnPrivateNotes.Name = "btnPrivateNotes";
      this.btnPrivateNotes.Size = new Size(123, 25);
      this.btnPrivateNotes.TabIndex = 4;
      this.btnPrivateNotes.Text = "Private Notes";
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(709, 724);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(87, 25);
      this.btnReset.TabIndex = 5;
      this.btnReset.Text = "Restart";
      this.btnSaveProg.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveProg.Location = new System.Drawing.Point(802, 724);
      this.btnSaveProg.Name = "btnSaveProg";
      this.btnSaveProg.Size = new Size(122, 25);
      this.btnSaveProg.TabIndex = 6;
      this.btnSaveProg.Text = "Save Progress";
      this.btnSaveProg.Visible = false;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(934, 761);
      this.Controls.Add((Control) this.btnSaveProg);
      this.Controls.Add((Control) this.btnReset);
      this.Controls.Add((Control) this.btnPrivateNotes);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.pnlMain);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(950, 733);
      this.Name = nameof (FRMJobWizard);
      this.Text = "Job Wizard";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.pnlMain, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.btnPrivateNotes, 0);
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.btnSaveProg, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      ((UCJobWizard) this.LoadedControl).DGVSites.AutoGenerateColumns = false;
      ((UCJobWizard) this.LoadedControl).SetupSiteDataGridView();
      ((UCJobWizard) this.LoadedControl).SetupAppsDG();
      ((UCJobWizard) this.LoadedControl).SetupSOR();
      ((UCJobWizard) this.LoadedControl).SetupDGSymptoms();
      ((UCJobWizard) this.LoadedControl).SetupDGAdditional();
      ((UCJobWizard) this.LoadedControl).SetupExisitingJobs();
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      try
      {
        ((UCJobWizard) this.LoadedControl).FromForm = (Form) this.get_GetParameter(1);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
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
        }
        else
        {
          this.PageState = Enums.FormState.Update;
          FSM.Entity.Customers.Customer customer = new FSM.Entity.Customers.Customer();
          FSM.Entity.Customers.Customer forSiteId = App.DB.Customer.Customer_Get_ForSiteID(this.ID);
          this.Text = "Property : ID " + Conversions.ToString(this.ID) + " for Customer: " + forSiteId.Name + ", Acc: " + forSiteId.AccountNumber;
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

    private void FRMSite_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.LoadedControl.Save())
        ;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      ((UCJobWizard) this.LoadedControl).Notes();
    }

    private void btnReset_Click_1(object sender, EventArgs e)
    {
      ((UCJobWizard) this.LoadedControl).Reset();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      ((UCJobWizard) this.LoadedControl).SaveProgress();
    }
  }
}
