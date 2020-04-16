// Decompiled with JetBrains decompiler
// Type: FSM.FRMQuoteJob
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Jobs;
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
  public class FRMQuoteJob : FRMBaseForm, IForm
  {
    private IContainer components;
    private IUserControl TheLoadedControl;
    private int _ID;
    private Enums.FormState _pageState;
    private Job _Job;

    public FRMQuoteJob()
    {
      this.Load += new EventHandler(this.FRMQuoteJob_Load);
      this.Closing += new CancelEventHandler(this.FRMQuoteJob_Closing);
      this._ID = 0;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCQuoteJob();
      this.pnlMain.Controls.Add((Control) this.TheLoadedControl);
      this.LoadedControl.StateChanged += new IUserControl.StateChangedEventHandler(this.ResetMe);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Panel pnlMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnViewJob
    {
      get
      {
        return this._btnViewJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnViewJob_Click);
        Button btnViewJob1 = this._btnViewJob;
        if (btnViewJob1 != null)
          btnViewJob1.Click -= eventHandler;
        this._btnViewJob = value;
        Button btnViewJob2 = this._btnViewJob;
        if (btnViewJob2 == null)
          return;
        btnViewJob2.Click += eventHandler;
      }
    }

    internal virtual Button btnViewSite
    {
      get
      {
        return this._btnViewSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnViewSite_Click);
        Button btnViewSite1 = this._btnViewSite;
        if (btnViewSite1 != null)
          btnViewSite1.Click -= eventHandler;
        this._btnViewSite = value;
        Button btnViewSite2 = this._btnViewSite;
        if (btnViewSite2 == null)
          return;
        btnViewSite2.Click += eventHandler;
      }
    }

    internal virtual Button btnConvert
    {
      get
      {
        return this._btnConvert;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnConvert_Click);
        Button btnConvert1 = this._btnConvert;
        if (btnConvert1 != null)
          btnConvert1.Click -= eventHandler;
        this._btnConvert = value;
        Button btnConvert2 = this._btnConvert;
        if (btnConvert2 == null)
          return;
        btnConvert2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.pnlMain = new Panel();
      this.btnSave = new Button();
      this.btnClose = new Button();
      this.btnViewJob = new Button();
      this.btnViewSite = new Button();
      this.btnConvert = new Button();
      this.SuspendLayout();
      this.pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlMain.Location = new System.Drawing.Point(0, 32);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new Size(1184, 708);
      this.pnlMain.TabIndex = 1;
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Location = new System.Drawing.Point(8, 747);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 23);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(72, 747);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 23);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.btnViewJob.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnViewJob.Location = new System.Drawing.Point(808, 747);
      this.btnViewJob.Name = "btnViewJob";
      this.btnViewJob.Size = new Size(88, 24);
      this.btnViewJob.TabIndex = 5;
      this.btnViewJob.Text = "View Job";
      this.btnViewJob.Visible = false;
      this.btnViewSite.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnViewSite.Location = new System.Drawing.Point(134, 747);
      this.btnViewSite.Name = "btnViewSite";
      this.btnViewSite.Size = new Size(100, 24);
      this.btnViewSite.TabIndex = 7;
      this.btnViewSite.Text = "View Property";
      this.btnConvert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnConvert.Location = new System.Drawing.Point(1022, 747);
      this.btnConvert.Name = "btnConvert";
      this.btnConvert.Size = new Size(92, 23);
      this.btnConvert.TabIndex = 8;
      this.btnConvert.Text = "Convert";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1184, 781);
      this.Controls.Add((Control) this.btnConvert);
      this.Controls.Add((Control) this.btnViewSite);
      this.Controls.Add((Control) this.btnViewJob);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.pnlMain);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(1200, 820);
      this.Name = nameof (FRMQuoteJob);
      this.Text = "Quote Job : ID {0}";
      this.Controls.SetChildIndex((Control) this.pnlMain, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.btnViewJob, 0);
      this.Controls.SetChildIndex((Control) this.btnViewSite, 0);
      this.Controls.SetChildIndex((Control) this.btnConvert, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      ((UCQuoteJob) this.LoadedControl).RefreshButton += new UCQuoteJob.RefreshButtonEventHandler(this.ShowButton);
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      string jobNumber = App.DB.Job.Job_Get_For_Quote_ID(this.ID)?.JobNumber;
      ((UCQuoteJob) this.LoadedControl).CurrentQuoteJob = App.DB.QuoteJob.Get(this.ID);
      ((UCQuoteJob) this.LoadedControl).CurrentSite = App.DB.Sites.Get((object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1))), SiteSQL.GetBy.SiteId, (object) null);
      ((UCQuoteJob) this.LoadedControl).LoadDepartment();
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ((UCQuoteJob) this.LoadedControl).SetupPartsAndProductsDataGrid();
      ((UCQuoteJob) this.LoadedControl).SetupScheduleOfRatesDataGrid();
      this.ShowButton();
      if (string.IsNullOrWhiteSpace(jobNumber))
        return;
      this.btnConvert.Text = jobNumber;
      this.btnConvert.Enabled = false;
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
          this.Text = "Quote Job : Adding New...";
        }
        else
        {
          this.PageState = Enums.FormState.Update;
          this.Text = "Quote Job : ID " + Conversions.ToString(this.ID);
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

    private Job Job
    {
      get
      {
        return this._Job;
      }
      set
      {
        this._Job = value;
      }
    }

    private void FRMQuoteJob_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.LoadedControl.Save())
        return;
      ((UCQuoteJob) this.LoadedControl).CurrentQuoteJob = App.DB.QuoteJob.Get(this.ID);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnViewJob_Click(object sender, EventArgs e)
    {
      switch (Conversions.ToInteger(this.btnViewJob.Tag))
      {
        case 2:
          App.ShowForm(typeof (FRMLogCallout), true, new object[3]
          {
            (object) this.Job.JobID,
            (object) this.Job.PropertyID,
            (object) this
          }, false);
          break;
        case 3:
          App.ShowForm(typeof (FRMQuoteRejection), true, new object[3]
          {
            (object) this.TheLoadedControl,
            (object) ((UCQuoteJob) this.TheLoadedControl).CurrentQuoteJob.ReasonForReject,
            (object) ((UCQuoteJob) this.TheLoadedControl).CurrentQuoteJob.ReasonForRejectID
          }, false);
          break;
      }
    }

    private void btnViewSite_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMSite), true, new object[2]
      {
        (object) ((UCQuoteJob) this.LoadedControl).CurrentSite.SiteID,
        (object) this
      }, false);
    }

    private void ShowButton()
    {
      switch (((UCQuoteJob) this.TheLoadedControl).CurrentQuoteJob.StatusEnumID)
      {
        case 1:
          this.btnViewJob.Visible = false;
          this.btnViewJob.Tag = (object) 1;
          break;
        case 2:
          this.Job = App.DB.Job.Job_Get_For_Quote_ID(this.ID);
          this.btnViewJob.Tag = (object) 2;
          this.btnViewJob.Text = "View Job";
          this.btnViewJob.Visible = this.Job != null;
          break;
        case 3:
          this.btnViewJob.Tag = (object) 3;
          this.btnViewJob.Text = "View Reason";
          this.btnViewJob.Visible = true;
          break;
      }
    }

    private void FRMQuoteJob_Closing(object sender, CancelEventArgs e)
    {
      this.CloseTheForm();
    }

    private void CloseTheForm()
    {
      if (((UCQuoteJob) this.TheLoadedControl).QuoteNumberUsed)
        return;
      App.DB.QuoteJob.DeleteReservedQuoteNumber(((UCQuoteJob) this.TheLoadedControl).QuoteNumber.JobNumber);
    }

    private void btnConvert_Click(object sender, EventArgs e)
    {
      this.btnConvert.Enabled = false;
      string installJob = ((UCQuoteJob) this.TheLoadedControl).QuoteJob_Create_InstallJob();
      this.btnConvert.Text = installJob.Length > 0 ? installJob : this.btnConvert.Text;
      this.btnConvert.Enabled = installJob.Length <= 0;
    }
  }
}
