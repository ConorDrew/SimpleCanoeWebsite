// Decompiled with JetBrains decompiler
// Type: FSM.DLGEngineerVisitDefect
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisitDefectss;
using FSM.Entity.EngineerVisits;
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
  public class DLGEngineerVisitDefect : FRMBaseForm
  {
    private IContainer components;
    private bool _updating;
    private EngineerVisitDefects _Defect;
    private EngineerVisit _EngineerVisit;
    private int _jobID;

    public DLGEngineerVisitDefect()
    {
      this.Load += new EventHandler(this.DLGEngineerVisitDefect_Load);
      this._updating = true;
      this.InitializeComponent();
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

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
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

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCategory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAsset { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtReason { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtComments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtActionTaken { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkWarningNoticeIssued { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkDisconnected { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnSave = new Button();
      this.btnCancel = new Button();
      this.GroupBox1 = new GroupBox();
      this.txtActionTaken = new TextBox();
      this.Label5 = new Label();
      this.txtComments = new TextBox();
      this.Label4 = new Label();
      this.txtReason = new TextBox();
      this.Label3 = new Label();
      this.chkDisconnected = new CheckBox();
      this.chkWarningNoticeIssued = new CheckBox();
      this.cboAsset = new ComboBox();
      this.Label2 = new Label();
      this.cboCategory = new ComboBox();
      this.Label1 = new Label();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Location = new System.Drawing.Point(448, 384);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Location = new System.Drawing.Point(8, 384);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.txtActionTaken);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.txtComments);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.txtReason);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.chkDisconnected);
      this.GroupBox1.Controls.Add((Control) this.chkWarningNoticeIssued);
      this.GroupBox1.Controls.Add((Control) this.cboAsset);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.cboCategory);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Location = new System.Drawing.Point(8, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(512, 336);
      this.GroupBox1.TabIndex = 4;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Defect Details";
      this.txtActionTaken.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtActionTaken.Location = new System.Drawing.Point(120, 226);
      this.txtActionTaken.Multiline = true;
      this.txtActionTaken.Name = "txtActionTaken";
      this.txtActionTaken.ScrollBars = ScrollBars.Vertical;
      this.txtActionTaken.Size = new Size(384, 48);
      this.txtActionTaken.TabIndex = 11;
      this.Label5.Location = new System.Drawing.Point(16, 224);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(80, 23);
      this.Label5.TabIndex = 10;
      this.Label5.Text = "Action Taken";
      this.txtComments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtComments.Location = new System.Drawing.Point(120, 282);
      this.txtComments.Multiline = true;
      this.txtComments.Name = "txtComments";
      this.txtComments.ScrollBars = ScrollBars.Vertical;
      this.txtComments.Size = new Size(384, 46);
      this.txtComments.TabIndex = 9;
      this.Label4.Location = new System.Drawing.Point(16, 280);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(80, 23);
      this.Label4.TabIndex = 8;
      this.Label4.Text = "Comments";
      this.txtReason.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtReason.Location = new System.Drawing.Point(120, 170);
      this.txtReason.Multiline = true;
      this.txtReason.Name = "txtReason";
      this.txtReason.ScrollBars = ScrollBars.Vertical;
      this.txtReason.Size = new Size(384, 48);
      this.txtReason.TabIndex = 7;
      this.Label3.Location = new System.Drawing.Point(16, 168);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(80, 23);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Reason";
      this.chkDisconnected.CheckAlign = ContentAlignment.MiddleRight;
      this.chkDisconnected.Location = new System.Drawing.Point(16, 136);
      this.chkDisconnected.Name = "chkDisconnected";
      this.chkDisconnected.Size = new Size(120, 24);
      this.chkDisconnected.TabIndex = 5;
      this.chkDisconnected.Text = "Disconnected";
      this.chkWarningNoticeIssued.CheckAlign = ContentAlignment.MiddleRight;
      this.chkWarningNoticeIssued.Location = new System.Drawing.Point(16, 88);
      this.chkWarningNoticeIssued.Name = "chkWarningNoticeIssued";
      this.chkWarningNoticeIssued.Size = new Size(120, 40);
      this.chkWarningNoticeIssued.TabIndex = 4;
      this.chkWarningNoticeIssued.Text = "Warning Notice Issued";
      this.cboAsset.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboAsset.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAsset.Location = new System.Drawing.Point(120, 27);
      this.cboAsset.Name = "cboAsset";
      this.cboAsset.Size = new Size(384, 21);
      this.cboAsset.TabIndex = 3;
      this.Label2.Location = new System.Drawing.Point(16, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(72, 23);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Appliance";
      this.cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCategory.Location = new System.Drawing.Point(120, 59);
      this.cboCategory.Name = "cboCategory";
      this.cboCategory.Size = new Size(384, 21);
      this.cboCategory.TabIndex = 1;
      this.Label1.Location = new System.Drawing.Point(16, 56);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(72, 23);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Category";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(528, 414);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnSave);
      this.MinimumSize = new Size(536, 448);
      this.Name = nameof (DLGEngineerVisitDefect);
      this.Text = "Engineer Visit Defect";
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    public bool Updating
    {
      get
      {
        return this._updating;
      }
      set
      {
        this._updating = value;
      }
    }

    public EngineerVisitDefects Defect
    {
      get
      {
        return this._Defect;
      }
      set
      {
        this._Defect = value;
      }
    }

    public EngineerVisit EngineerVisit
    {
      get
      {
        return this._EngineerVisit;
      }
      set
      {
        this._EngineerVisit = value;
      }
    }

    public int JobID
    {
      get
      {
        return this._jobID;
      }
      set
      {
        this._jobID = value;
      }
    }

    private void populateDefect()
    {
      ComboBox cboAsset = this.cboAsset;
      Combo.SetSelectedComboItem_By_Value(ref cboAsset, Conversions.ToString(this.Defect.AssetID));
      this.cboAsset = cboAsset;
      ComboBox cboCategory = this.cboCategory;
      Combo.SetSelectedComboItem_By_Value(ref cboCategory, Conversions.ToString(this.Defect.CategoryID));
      this.cboCategory = cboCategory;
      this.chkDisconnected.Checked = this.Defect.Disconnected;
      this.chkWarningNoticeIssued.Checked = this.Defect.WarningNoticeIssued;
      this.txtReason.Text = this.Defect.Reason;
      this.txtActionTaken.Text = this.Defect.ActionTaken;
      this.txtComments.Text = this.Defect.Comments;
    }

    private void DLGEngineerVisitDefect_Load(object sender, EventArgs e)
    {
      if (!App.loggedInUser.Admin)
      {
        this.btnSave.Enabled = false;
        this.cboAsset.Enabled = false;
        this.cboCategory.Enabled = false;
        this.chkDisconnected.Enabled = false;
        this.chkWarningNoticeIssued.Enabled = false;
        this.txtActionTaken.ReadOnly = true;
        this.txtComments.ReadOnly = true;
        this.txtReason.ReadOnly = true;
      }
      ComboBox cboCategory = this.cboCategory;
      Combo.SetUpCombo(ref cboCategory, App.DB.Picklists.GetAll(Enums.PickListTypes.DefectCategorys, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCategory = cboCategory;
      ComboBox cboAsset = this.cboAsset;
      Combo.SetUpCombo(ref cboAsset, App.DB.JobAsset.JobAsset_Get_For_Job(this.JobID).Table, "AssetID", "AssetDescriptionWithLocation", Enums.ComboValues.Not_Applicable);
      this.cboAsset = cboAsset;
      if (!(this.Defect.Exists & this.Updating))
        return;
      this.populateDefect();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.Defect.SetAssetID = (object) Combo.get_GetSelectedItemValue(this.cboAsset);
        this.Defect.SetCategoryID = (object) Combo.get_GetSelectedItemValue(this.cboCategory);
        this.Defect.SetActionTaken = (object) this.txtActionTaken.Text;
        this.Defect.SetComments = (object) this.txtComments.Text;
        this.Defect.SetDisconnected = (object) this.chkDisconnected.Checked;
        this.Defect.SetWarningNoticeIssued = (object) this.chkWarningNoticeIssued.Checked;
        this.Defect.SetReason = (object) this.txtReason.Text;
        this.Defect.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
        new EngineerVisitDefectsValidator().Validate(this.Defect);
        if (this.Updating)
          App.DB.EngineerVisitDefects.Update(this.Defect);
        else
          App.DB.EngineerVisitDefects.Insert(this.Defect);
        this.DialogResult = DialogResult.OK;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error saving details : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }
  }
}
