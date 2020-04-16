// Decompiled with JetBrains decompiler
// Type: FSM.FRMQuoteContractOption3
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractOption3s;
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
  public class FRMQuoteContractOption3 : FRMBaseForm, IForm
  {
    private IContainer components;
    private IUserControl TheLoadedControl;
    private int _ID;
    private int _IDToLinkTo;
    private Enums.FormState _pageState;
    private ContractOption3 _Contract;

    public FRMQuoteContractOption3()
    {
      this.Load += new EventHandler(this.FRMQuoteContractOption3_Load);
      this._ID = 0;
      this._IDToLinkTo = 0;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCQuoteContractOption3();
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

    internal virtual Button btnViewContract
    {
      get
      {
        return this._btnViewContract;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnViewContract_Click);
        Button btnViewContract1 = this._btnViewContract;
        if (btnViewContract1 != null)
          btnViewContract1.Click -= eventHandler;
        this._btnViewContract = value;
        Button btnViewContract2 = this._btnViewContract;
        if (btnViewContract2 == null)
          return;
        btnViewContract2.Click += eventHandler;
      }
    }

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
      this.btnViewContract = new Button();
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
      this.pnlMain.Size = new Size(640, 616);
      this.pnlMain.TabIndex = 1;
      this.btnViewContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnViewContract.Location = new System.Drawing.Point(472, 656);
      this.btnViewContract.Name = "btnViewContract";
      this.btnViewContract.Size = new Size(104, 25);
      this.btnViewContract.TabIndex = 5;
      this.btnViewContract.Text = "View Contract";
      this.btnViewContract.Visible = false;
      this.btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrint.Location = new System.Drawing.Point(584, 656);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new Size(55, 25);
      this.btnPrint.TabIndex = 6;
      this.btnPrint.Text = "Print";
      this.btnPrint.Visible = false;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(648, 694);
      this.Controls.Add((Control) this.btnPrint);
      this.Controls.Add((Control) this.btnViewContract);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.pnlMain);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(656, 728);
      this.Name = nameof (FRMQuoteContractOption3);
      this.Text = "Quote Contract Option3 : ID {0}";
      this.Controls.SetChildIndex((Control) this.pnlMain, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.btnViewContract, 0);
      this.Controls.SetChildIndex((Control) this.btnPrint, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      ((UCQuoteContractOption3) this.LoadedControl).CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.QuoteContractOption3_Get(this.ID);
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ((UCQuoteContractOption3) this.LoadedControl).RefreshButton += new UCQuoteContractOption3.RefreshButtonEventHandler(this.ShowButton);
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.IDToLinkTo = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1)));
      ((UCQuoteContractOption3) this.LoadedControl).IDToLinkTo = this.IDToLinkTo;
      ((UCQuoteContractOption3) this.LoadedControl).CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.QuoteContractOption3_Get(this.ID);
      ((UCQuoteContractOption3) this.LoadedControl).SetupSitesDataGrid();
      this.ShowButton();
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
          this.Text = "Quote Contract : Adding New...";
          this.btnPrint.Visible = false;
        }
        else
        {
          this.PageState = Enums.FormState.Update;
          this.Text = "Quote Contract: ID " + Conversions.ToString(this.ID);
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

    private ContractOption3 Contract
    {
      get
      {
        return this._Contract;
      }
      set
      {
        this._Contract = value;
      }
    }

    private void FRMQuoteContractOption3_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.LoadedControl.Save())
        return;
      ((UCQuoteContractOption3) this.LoadedControl).CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.QuoteContractOption3_Get(this.ID);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnViewContract_Click(object sender, EventArgs e)
    {
      switch ((Enums.QuoteContractStatus) Conversions.ToInteger(this.btnViewContract.Tag))
      {
        case Enums.QuoteContractStatus.Rejected:
          App.ShowForm(typeof (FRMQuoteRejection), true, new object[2]
          {
            (object) this.TheLoadedControl,
            (object) ((UCQuoteContractOption3) this.TheLoadedControl).CurrentQuoteContractOption3.ReasonForReject
          }, false);
          break;
      }
    }

    private void ShowButton()
    {
      switch (((UCQuoteContractOption3) this.TheLoadedControl).CurrentQuoteContractOption3.QuoteContractStatusID)
      {
        case 1:
          this.btnViewContract.Visible = false;
          this.btnViewContract.Tag = (object) 1;
          break;
        case 2:
          this.Contract = App.DB.ContractOption3.ContractOption3_Get_For_Quote_ID(this.ID);
          this.btnViewContract.Tag = (object) 2;
          this.btnViewContract.Text = "View Contract";
          this.btnViewContract.Visible = this.Contract != null;
          break;
        case 3:
          this.btnViewContract.Tag = (object) 3;
          this.btnViewContract.Text = "View Reason";
          this.btnViewContract.Visible = true;
          break;
      }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.ID
      }, ((UCQuoteContractOption3) this.LoadedControl).CurrentQuoteContractOption3.QuoteContractReference.Trim() + " ", Enums.SystemDocumentType.QuoteContractOption3, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }
  }
}
