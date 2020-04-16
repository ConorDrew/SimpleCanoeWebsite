// Decompiled with JetBrains decompiler
// Type: FSM.UCQuoteRejection
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
  public class UCQuoteRejection : UCBase, IUserControl
  {
    private IContainer components;

    public UCQuoteRejection()
    {
      this.Load += new EventHandler(this.UCQuoteContractSite_Load);
      this.InitializeComponent();
      ComboBox cboPossibleReasons = this.cboPossibleReasons;
      Combo.SetUpCombo(ref cboPossibleReasons, App.DB.Picklists.GetAll(Enums.PickListTypes.QuoteRejectionReasons, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPossibleReasons = cboPossibleReasons;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPossibleReasons { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtReason { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        Button btnAdd1 = this._btnAdd;
        if (btnAdd1 != null)
          btnAdd1.Click -= eventHandler;
        this._btnAdd = value;
        Button btnAdd2 = this._btnAdd;
        if (btnAdd2 == null)
          return;
        btnAdd2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpMain = new GroupBox();
      this.btnAdd = new Button();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.txtReason = new TextBox();
      this.cboPossibleReasons = new ComboBox();
      this.grpMain.SuspendLayout();
      this.SuspendLayout();
      this.grpMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpMain.Controls.Add((Control) this.btnAdd);
      this.grpMain.Controls.Add((Control) this.Label2);
      this.grpMain.Controls.Add((Control) this.Label1);
      this.grpMain.Controls.Add((Control) this.txtReason);
      this.grpMain.Controls.Add((Control) this.cboPossibleReasons);
      this.grpMain.Location = new System.Drawing.Point(8, 8);
      this.grpMain.Name = "grpMain";
      this.grpMain.Size = new Size(625, 266);
      this.grpMain.TabIndex = 1;
      this.grpMain.TabStop = false;
      this.grpMain.Text = "Quote Rejection Reason";
      this.btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAdd.Location = new System.Drawing.Point(568, 33);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(48, 23);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "Add";
      this.Label2.Location = new System.Drawing.Point(16, 32);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(112, 23);
      this.Label2.TabIndex = 3;
      this.Label2.Text = "Possible Reasons:";
      this.Label1.Location = new System.Drawing.Point(16, 64);
      this.Label1.Name = "Label1";
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Reason:";
      this.txtReason.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtReason.Location = new System.Drawing.Point(136, 64);
      this.txtReason.Multiline = true;
      this.txtReason.Name = "txtReason";
      this.txtReason.ScrollBars = ScrollBars.Vertical;
      this.txtReason.Size = new Size(480, 192);
      this.txtReason.TabIndex = 3;
      this.txtReason.Text = "";
      this.cboPossibleReasons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboPossibleReasons.Location = new System.Drawing.Point(136, 33);
      this.cboPossibleReasons.Name = "cboPossibleReasons";
      this.cboPossibleReasons.Size = new Size(424, 21);
      this.cboPossibleReasons.TabIndex = 1;
      this.Controls.Add((Control) this.grpMain);
      this.Name = nameof (UCQuoteRejection);
      this.Size = new Size(640, 288);
      this.grpMain.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.txtReason.Text;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public event UCQuoteRejection.ReasonChangedEventHandler ReasonChanged;

    private void UCQuoteContractSite_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (this.txtReason.Text.Trim().Length > 0)
      {
        TextBox txtReason;
        string str = (txtReason = this.txtReason).Text + " " + Combo.get_GetSelectedItemDescription(this.cboPossibleReasons);
        txtReason.Text = str;
      }
      else
      {
        TextBox txtReason;
        string str = (txtReason = this.txtReason).Text + Combo.get_GetSelectedItemDescription(this.cboPossibleReasons);
        txtReason.Text = str;
      }
    }

    void IUserControl.Populate(int ID = 0)
    {
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.txtReason.Text.Trim().Length > 0)
        {
          // ISSUE: reference to a compiler-generated field
          UCQuoteRejection.ReasonChangedEventHandler reasonChangedEvent = this.ReasonChangedEvent;
          if (reasonChangedEvent != null)
            reasonChangedEvent(this.txtReason.Text.Trim(), Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPossibleReasons)));
          flag = true;
        }
        else
        {
          int num = (int) App.ShowMessage("Please enter a reason", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          flag = false;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    public delegate void ReasonChangedEventHandler(string reason, int ReasonID);
  }
}
