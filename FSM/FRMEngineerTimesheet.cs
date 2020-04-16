// Decompiled with JetBrains decompiler
// Type: FSM.FRMEngineerTimesheet
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using FSM.Entity.EngineerTimeSheets;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FRMEngineerTimesheet : FRMBaseForm, IForm
  {
    private IContainer components;
    private EngineerTimeSheet _CurrentTimesheet;
    private Engineer _oEngineer;

    public FRMEngineerTimesheet()
    {
      this.Load += new EventHandler(this.FRMEngineerTimesheet_Load);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.btnSave = new Button();
      this.txtComments = new TextBox();
      this.Label1 = new Label();
      this.btnFindRecord = new Button();
      this.txtSearch = new TextBox();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.lblSearch = new Label();
      this.Label10 = new Label();
      this.cboType = new ComboBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.btnSave);
      this.GroupBox1.Controls.Add((Control) this.txtComments);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.btnFindRecord);
      this.GroupBox1.Controls.Add((Control) this.txtSearch);
      this.GroupBox1.Controls.Add((Control) this.dtpTo);
      this.GroupBox1.Controls.Add((Control) this.dtpFrom);
      this.GroupBox1.Controls.Add((Control) this.Label9);
      this.GroupBox1.Controls.Add((Control) this.Label8);
      this.GroupBox1.Controls.Add((Control) this.lblSearch);
      this.GroupBox1.Controls.Add((Control) this.Label10);
      this.GroupBox1.Controls.Add((Control) this.cboType);
      this.GroupBox1.Location = new System.Drawing.Point(12, 38);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(531, 375);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "General Timesheet";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(439, 334);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.txtComments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtComments.Location = new System.Drawing.Point(132, 128);
      this.txtComments.Multiline = true;
      this.txtComments.Name = "txtComments";
      this.txtComments.ScrollBars = ScrollBars.Vertical;
      this.txtComments.Size = new Size(382, 200);
      this.txtComments.TabIndex = 11;
      this.Label1.Location = new System.Drawing.Point(14, 131);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(112, 16);
      this.Label1.TabIndex = 10;
      this.Label1.Text = "Comments";
      this.btnFindRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindRecord.BackColor = Color.White;
      this.btnFindRecord.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindRecord.Location = new System.Drawing.Point(482, 45);
      this.btnFindRecord.Name = "btnFindRecord";
      this.btnFindRecord.Size = new Size(32, 23);
      this.btnFindRecord.TabIndex = 4;
      this.btnFindRecord.Text = "...";
      this.btnFindRecord.UseVisualStyleBackColor = false;
      this.txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSearch.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSearch.Location = new System.Drawing.Point(132, 47);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.ReadOnly = true;
      this.txtSearch.Size = new Size(344, 21);
      this.txtSearch.TabIndex = 3;
      this.dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dtpTo.CustomFormat = "dd MMMM yyyy HH:mm";
      this.dtpTo.Format = DateTimePickerFormat.Custom;
      this.dtpTo.Location = new System.Drawing.Point(132, 101);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(382, 21);
      this.dtpTo.TabIndex = 9;
      this.dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dtpFrom.CustomFormat = "dd MMMM yyyy HH:mm";
      this.dtpFrom.Format = DateTimePickerFormat.Custom;
      this.dtpFrom.Location = new System.Drawing.Point(132, 74);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(382, 21);
      this.dtpFrom.TabIndex = 7;
      this.Label9.Location = new System.Drawing.Point(14, 107);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(112, 16);
      this.Label9.TabIndex = 8;
      this.Label9.Text = "End Date Time";
      this.Label8.Location = new System.Drawing.Point(14, 80);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(112, 16);
      this.Label8.TabIndex = 6;
      this.Label8.Text = "Start Date Time";
      this.lblSearch.Location = new System.Drawing.Point(14, 50);
      this.lblSearch.Name = "lblSearch";
      this.lblSearch.Size = new Size(112, 20);
      this.lblSearch.TabIndex = 2;
      this.lblSearch.Text = "Engineer";
      this.Label10.Location = new System.Drawing.Point(14, 23);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(48, 20);
      this.Label10.TabIndex = 0;
      this.Label10.Text = "Type";
      this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(132, 20);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(382, 21);
      this.cboType.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(561, 424);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FRMEngineerTimesheet);
      this.Text = "Engineer Timesheet";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtComments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindRecord
    {
      get
      {
        return this._btnFindRecord;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindRecord_Click);
        Button btnFindRecord1 = this._btnFindRecord;
        if (btnFindRecord1 != null)
          btnFindRecord1.Click -= eventHandler;
        this._btnFindRecord = value;
        Button btnFindRecord2 = this._btnFindRecord;
        if (btnFindRecord2 == null)
          return;
        btnFindRecord2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, App.DB.Picklists.GetAll(Enums.PickListTypes.TimeSheetTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboType = cboType;
      this.CurrentTimesheet = App.DB.EngineerTimesheets.Get(Conversions.ToInteger(this.get_GetParameter(0)));
      if (!Operators.ConditionalCompareObjectEqual(this.get_GetParameter(1), (object) "Visit", false))
        return;
      this.cboType.Enabled = false;
      this.btnFindRecord.Enabled = false;
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    void IForm.ResetMe(int newID)
    {
    }

    private EngineerTimeSheet CurrentTimesheet
    {
      get
      {
        return this._CurrentTimesheet;
      }
      set
      {
        this._CurrentTimesheet = value;
        if (this._CurrentTimesheet == null)
        {
          this._CurrentTimesheet = new EngineerTimeSheet();
          this._CurrentTimesheet.Exists = false;
        }
        if (this.CurrentTimesheet.Exists)
        {
          this.Populate();
        }
        else
        {
          this.oEngineer = (Engineer) null;
          ComboBox cboType = this.cboType;
          Combo.SetSelectedComboItem_By_Value(ref cboType, Conversions.ToString(0));
          this.cboType = cboType;
          this.txtComments.Text = "";
          this.dtpFrom.Value = DateAndTime.Now;
          this.dtpTo.Value = DateAndTime.Now;
        }
      }
    }

    public Engineer oEngineer
    {
      get
      {
        return this._oEngineer;
      }
      set
      {
        this._oEngineer = value;
        if (this._oEngineer != null)
          this.txtSearch.Text = this.oEngineer.Name;
        else
          this.txtSearch.Text = "";
      }
    }

    private void FRMEngineerTimesheet_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void btnFindRecord_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.oEngineer = App.DB.Engineer.Engineer_Get(integer);
    }

    private void Populate()
    {
      ComboBox cboType = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType, Conversions.ToString(this.CurrentTimesheet.TimeSheetTypeID));
      this.cboType = cboType;
      this.oEngineer = App.DB.Engineer.Engineer_Get(this.CurrentTimesheet.EngineerID);
      this.txtComments.Text = this.CurrentTimesheet.Comments;
      this.dtpFrom.Value = this.CurrentTimesheet.StartDateTime;
      this.dtpTo.Value = this.CurrentTimesheet.EndDateTime;
    }

    private void Save()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentTimesheet.IgnoreExceptionsOnSetMethods = true;
        this.CurrentTimesheet.SetTimeSheetTypeID = (object) Combo.get_GetSelectedItemValue(this.cboType);
        if (this.oEngineer != null)
          this.CurrentTimesheet.SetEngineerID = (object) this.oEngineer.EngineerID;
        this.CurrentTimesheet.SetComments = (object) this.txtComments.Text;
        this.CurrentTimesheet.StartDateTime = this.dtpFrom.Value;
        this.CurrentTimesheet.EndDateTime = this.dtpTo.Value;
        new EngineerTimeSheetValidator().Validate(this.CurrentTimesheet);
        if (Operators.ConditionalCompareObjectEqual(this.get_GetParameter(1), (object) "General", false))
        {
          if (this.CurrentTimesheet.Exists)
            App.DB.EngineerTimesheets.Update(this.CurrentTimesheet);
          else
            App.DB.EngineerTimesheets.Insert(this.CurrentTimesheet);
        }
        else if (Operators.ConditionalCompareObjectEqual(this.get_GetParameter(1), (object) "Visit", false) && this.CurrentTimesheet.Exists)
          App.DB.EngineerTimesheets.UpdateVisit(this.CurrentTimesheet);
        int num = (int) App.ShowMessage("Timesheet Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }
  }
}
