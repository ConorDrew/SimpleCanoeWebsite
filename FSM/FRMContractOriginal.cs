// Decompiled with JetBrains decompiler
// Type: FSM.FRMContractOriginal
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMContractOriginal : FRMBaseForm, IForm
  {
    private IContainer components;
    private IUserControl TheLoadedControl;
    private int _ID;
    private int _IDToLinkTo;
    private Enums.FormState _pageState;

    public FRMContractOriginal()
    {
      this.Load += new EventHandler(this.FRMContract_Load);
      this.Closing += new CancelEventHandler(this.FRMContractOriginal_Closing);
      this._ID = 0;
      this._IDToLinkTo = 0;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCContractOriginal();
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

    internal virtual Button btnPrint
    {
      get
      {
        return this._btnPrint;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrint_Click);
        Button btnPrint1 = this._btnPrint;
        if (btnPrint1 != null)
          btnPrint1.Click -= eventHandler;
        this._btnPrint = value;
        Button btnPrint2 = this._btnPrint;
        if (btnPrint2 == null)
          return;
        btnPrint2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnSave = new Button();
      this.btnClose = new Button();
      this.pnlMain = new Panel();
      this.btnPrint = new Button();
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
      this.pnlMain.Size = new Size(784, 616);
      this.pnlMain.TabIndex = 1;
      this.btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrint.Location = new System.Drawing.Point(728, 656);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new Size(56, 25);
      this.btnPrint.TabIndex = 4;
      this.btnPrint.Text = "Print";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(792, 694);
      this.Controls.Add((Control) this.btnPrint);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.pnlMain);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(800, 728);
      this.Name = nameof (FRMContractOriginal);
      this.Text = "Contract : ID {0}";
      this.Controls.SetChildIndex((Control) this.pnlMain, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.btnPrint, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.IDToLinkTo = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1)));
      int InvoiceToBeRaisedID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(2)));
      ((UCContractOriginal) this.LoadedControl).SetupSitesDataGrid();
      ((UCContractOriginal) this.LoadedControl).SetupInvoiceAddressDataGrid();
      ((UCContractOriginal) this.LoadedControl).CurrentContract = App.DB.ContractOriginal.Get(this.ID);
      ((UCContractOriginal) this.LoadedControl).IDToLinkTo = this.IDToLinkTo;
      ((UCContractOriginal) this.LoadedControl).InvoiceToBeRaised = App.DB.InvoiceToBeRaised.InvoiceToBeRaised_Get(InvoiceToBeRaisedID);
      if (this.IDToLinkTo != 787)
        return;
      try
      {
        if (this.ID > 0)
          ((UCContractOriginal) this.LoadedControl).SiteID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(((UCContractOriginal) this.LoadedControl).Sites.Table.Select("tick=1")[0]["SiteID"]));
        else
          ((UCContractOriginal) this.LoadedControl).SiteID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(2)));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        App.ShowForm(typeof (FRMQuoteJobSelectASite), true, new object[2]
        {
          (object) this.IDToLinkTo,
          (object) this
        }, false);
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
          this.Text = "Contract : Adding New...";
          this.btnPrint.Visible = false;
        }
        else
        {
          this.PageState = Enums.FormState.Update;
          this.Text = "Contract : ID " + Conversions.ToString(this.ID);
          this.btnPrint.Visible = true;
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
      ((UCContractOriginal) this.LoadedControl).CurrentContract = App.DB.ContractOriginal.Get(this.ID);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (!((UCContractOriginal) this.LoadedControl).NumberUsed & ((UCContractOriginal) this.LoadedControl).Number != null)
        App.DB.Job.DeleteReservedOrderNumber(((UCContractOriginal) this.LoadedControl).Number.JobNumber, ((UCContractOriginal) this.LoadedControl).Number.Prefix);
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      DataTable dataTable = App.DB.ContractOriginal.ProcessContract(this.ID);
      if (dataTable == null)
        return;
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) dataTable
      }, ((UCContractOriginal) this.LoadedControl).CurrentContract.ContractReference.Trim() + " ", Enums.SystemDocumentType.ContractOption1, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
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
  }
}
