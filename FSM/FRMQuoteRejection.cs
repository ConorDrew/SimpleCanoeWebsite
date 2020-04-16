// Decompiled with JetBrains decompiler
// Type: FSM.FRMQuoteRejection
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
  public class FRMQuoteRejection : FRMBaseForm, IForm
  {
    private IContainer components;
    private IUserControl TheLoadedControl;
    private int _ID;
    private string _Reason;
    private int _ReasonID;
    private Enums.FormState _pageState;

    public FRMQuoteRejection()
    {
      this.Load += new EventHandler(this.FRMQuoteContractSite_Load);
      this._ID = 0;
      this._Reason = "";
      this._ReasonID = 0;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCQuoteRejection();
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
      this.btnSave.Location = new System.Drawing.Point(8, 312);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 25);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(72, 312);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 25);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlMain.Location = new System.Drawing.Point(0, 32);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new Size(688, 272);
      this.pnlMain.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(696, 350);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.pnlMain);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(704, 384);
      this.Name = nameof (FRMQuoteRejection);
      this.Text = "Reject Quote : ID {0}";
      this.Controls.SetChildIndex((Control) this.pnlMain, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      ((UCQuoteRejection) this.TheLoadedControl).ReasonChanged += new UCQuoteRejection.ReasonChangedEventHandler(this.ReasonChanged);
      this.Reason = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1)));
      this.ReasonID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(2)));
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

    public event FRMQuoteRejection.ReasonEditedEventHandler ReasonEdited;

    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
      }
    }

    public string Reason
    {
      get
      {
        return this._Reason;
      }
      set
      {
        this._Reason = value;
        if (Operators.CompareString(this.Reason, "", false) == 0)
        {
          this.Text = "Add reason for rejection";
        }
        else
        {
          this.Text = "Edit reason for rejection";
          ((UCQuoteRejection) this.TheLoadedControl).txtReason.Text = this.Reason;
        }
      }
    }

    public int ReasonID
    {
      get
      {
        return this._ReasonID;
      }
      set
      {
        this._ReasonID = value;
        if (this.ReasonID == 0)
          return;
        UCQuoteRejection theLoadedControl = (UCQuoteRejection) this.TheLoadedControl;
        ComboBox cboPossibleReasons = theLoadedControl.cboPossibleReasons;
        Combo.SetSelectedComboItem_By_Value(ref cboPossibleReasons, Conversions.ToString(this.ReasonID));
        theLoadedControl.cboPossibleReasons = cboPossibleReasons;
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

    private void FRMQuoteContractSite_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.LoadedControl.Save())
        return;
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

    public void ReasonChanged(string reason, int ReasonID)
    {
      // ISSUE: reference to a compiler-generated field
      FRMQuoteRejection.ReasonEditedEventHandler reasonEditedEvent = this.ReasonEditedEvent;
      if (reasonEditedEvent == null)
        return;
      reasonEditedEvent(reason, ReasonID);
    }

    public delegate void ReasonEditedEventHandler(string reason, int ReasonID);
  }
}
