// Decompiled with JetBrains decompiler
// Type: FSM.UCNotes
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Notes;
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
  public class UCNotes : UCBase, IUserControl
  {
    private IContainer components;
    private FSM.Entity.Notes.Notes _currentNotes;

    public UCNotes()
    {
      this.Load += new EventHandler(this.UCNotes_Load);
      this.InitializeComponent();
      ComboBox cboCategoryId = this.cboCategoryID;
      Combo.SetUpCombo(ref cboCategoryId, App.DB.Picklists.GetAll(Enums.PickListTypes.NoteCategory, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCategoryID = cboCategoryId;
      ComboBox cboTimeHours = this.cboTimeHours;
      Combo.SetUpCombo(ref cboTimeHours, DynamicDataTables.Hours, "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboTimeHours = cboTimeHours;
      ComboBox cboTimeMinutes = this.cboTimeMinutes;
      Combo.SetUpCombo(ref cboTimeMinutes, DynamicDataTables.Minutes, "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboTimeMinutes = cboTimeMinutes;
      ComboBox cboReminderHours = this.cboReminderHours;
      Combo.SetUpCombo(ref cboReminderHours, DynamicDataTables.Hours, "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboReminderHours = cboReminderHours;
      ComboBox cboReminderMinutes = this.cboReminderMinutes;
      Combo.SetUpCombo(ref cboReminderMinutes, DynamicDataTables.Minutes, "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboReminderMinutes = cboReminderMinutes;
      ComboBox reminderFrequency1 = this.cboReminderFrequency;
      Combo.SetUpCombo(ref reminderFrequency1, DynamicDataTables.ReminderFrequency, "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboReminderFrequency = reminderFrequency1;
      ComboBox reminderFrequency2 = this.cboReminderFrequency;
      Combo.SetSelectedComboItem_By_Value(ref reminderFrequency2, Conversions.ToString(1));
      this.cboReminderFrequency = reminderFrequency2;
      ComboBox reminderFrequencyValue1 = this.cboReminderFrequencyValue;
      Combo.SetUpCombo(ref reminderFrequencyValue1, DynamicDataTables.NumberSelector, "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboReminderFrequencyValue = reminderFrequencyValue1;
      ComboBox reminderFrequencyValue2 = this.cboReminderFrequencyValue;
      Combo.SetSelectedComboItem_By_Value(ref reminderFrequencyValue2, Conversions.ToString(1));
      this.cboReminderFrequencyValue = reminderFrequencyValue2;
      ComboBox cboUserFor1 = this.cboUserFor;
      Combo.SetUpCombo(ref cboUserFor1, App.DB.User.GetAll().Table, "UserID", "Fullname", Enums.ComboValues.Please_Select);
      this.cboUserFor = cboUserFor1;
      ComboBox cboUserFor2 = this.cboUserFor;
      Combo.SetSelectedComboItem_By_Value(ref cboUserFor2, Conversions.ToString(App.loggedInUser.UserID));
      this.cboUserFor = cboUserFor2;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCategoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCategoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpNoteDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNoteDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpReminderDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkReminderRequired
    {
      get
      {
        return this._chkReminderRequired;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkReminderRequired_CheckedChanged);
        CheckBox reminderRequired1 = this._chkReminderRequired;
        if (reminderRequired1 != null)
          reminderRequired1.CheckedChanged -= eventHandler;
        this._chkReminderRequired = value;
        CheckBox reminderRequired2 = this._chkReminderRequired;
        if (reminderRequired2 == null)
          return;
        reminderRequired2.CheckedChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboReminderFrequency { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTimeHours { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTimeMinutes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlReminderType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton radPeriod
    {
      get
      {
        return this._radPeriod;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radPeriod_CheckedChanged);
        RadioButton radPeriod1 = this._radPeriod;
        if (radPeriod1 != null)
          radPeriod1.CheckedChanged -= eventHandler;
        this._radPeriod = value;
        RadioButton radPeriod2 = this._radPeriod;
        if (radPeriod2 == null)
          return;
        radPeriod2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton radOther
    {
      get
      {
        return this._radOther;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radOther_CheckedChanged);
        RadioButton radOther1 = this._radOther;
        if (radOther1 != null)
          radOther1.CheckedChanged -= eventHandler;
        this._radOther = value;
        RadioButton radOther2 = this._radOther;
        if (radOther2 == null)
          return;
        radOther2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpReminderDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboReminderHours { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboReminderMinutes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboReminderFrequencyValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUserFor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpNotes = new GroupBox();
      this.cboTimeMinutes = new ComboBox();
      this.Label2 = new Label();
      this.grpReminderDetails = new GroupBox();
      this.cboReminderFrequencyValue = new ComboBox();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.pnlReminderType = new Panel();
      this.radOther = new RadioButton();
      this.radPeriod = new RadioButton();
      this.Label1 = new Label();
      this.cboReminderFrequency = new ComboBox();
      this.chkReminderRequired = new CheckBox();
      this.dtpReminderDate = new DateTimePicker();
      this.cboReminderHours = new ComboBox();
      this.cboReminderMinutes = new ComboBox();
      this.cboCategoryID = new ComboBox();
      this.lblCategoryID = new Label();
      this.dtpNoteDate = new DateTimePicker();
      this.lblNoteDate = new Label();
      this.txtNote = new TextBox();
      this.lblNote = new Label();
      this.cboTimeHours = new ComboBox();
      this.Label5 = new Label();
      this.cboUserFor = new ComboBox();
      this.grpNotes.SuspendLayout();
      this.grpReminderDetails.SuspendLayout();
      this.pnlReminderType.SuspendLayout();
      this.SuspendLayout();
      this.grpNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpNotes.Controls.Add((Control) this.cboUserFor);
      this.grpNotes.Controls.Add((Control) this.Label5);
      this.grpNotes.Controls.Add((Control) this.cboTimeMinutes);
      this.grpNotes.Controls.Add((Control) this.Label2);
      this.grpNotes.Controls.Add((Control) this.grpReminderDetails);
      this.grpNotes.Controls.Add((Control) this.cboCategoryID);
      this.grpNotes.Controls.Add((Control) this.lblCategoryID);
      this.grpNotes.Controls.Add((Control) this.dtpNoteDate);
      this.grpNotes.Controls.Add((Control) this.lblNoteDate);
      this.grpNotes.Controls.Add((Control) this.txtNote);
      this.grpNotes.Controls.Add((Control) this.lblNote);
      this.grpNotes.Controls.Add((Control) this.cboTimeHours);
      this.grpNotes.Location = new System.Drawing.Point(8, 8);
      this.grpNotes.Name = "grpNotes";
      this.grpNotes.Size = new Size(732, 308);
      this.grpNotes.TabIndex = 1;
      this.grpNotes.TabStop = false;
      this.grpNotes.Text = "Note Details";
      this.cboTimeMinutes.Location = new System.Drawing.Point(432, 24);
      this.cboTimeMinutes.Name = "cboTimeMinutes";
      this.cboTimeMinutes.Size = new Size(104, 21);
      this.cboTimeMinutes.TabIndex = 3;
      this.Label2.Location = new System.Drawing.Point(288, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(40, 21);
      this.Label2.TabIndex = 33;
      this.Label2.Text = "Time";
      this.grpReminderDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpReminderDetails.Controls.Add((Control) this.cboReminderFrequencyValue);
      this.grpReminderDetails.Controls.Add((Control) this.Label4);
      this.grpReminderDetails.Controls.Add((Control) this.Label3);
      this.grpReminderDetails.Controls.Add((Control) this.pnlReminderType);
      this.grpReminderDetails.Controls.Add((Control) this.Label1);
      this.grpReminderDetails.Controls.Add((Control) this.cboReminderFrequency);
      this.grpReminderDetails.Controls.Add((Control) this.chkReminderRequired);
      this.grpReminderDetails.Controls.Add((Control) this.dtpReminderDate);
      this.grpReminderDetails.Controls.Add((Control) this.cboReminderHours);
      this.grpReminderDetails.Controls.Add((Control) this.cboReminderMinutes);
      this.grpReminderDetails.Location = new System.Drawing.Point(8, 208);
      this.grpReminderDetails.Name = "grpReminderDetails";
      this.grpReminderDetails.Size = new Size(715, 88);
      this.grpReminderDetails.TabIndex = 32;
      this.grpReminderDetails.TabStop = false;
      this.grpReminderDetails.Text = "Reminder Details";
      this.cboReminderFrequencyValue.Location = new System.Drawing.Point(176, 25);
      this.cboReminderFrequencyValue.Name = "cboReminderFrequencyValue";
      this.cboReminderFrequencyValue.Size = new Size(96, 21);
      this.cboReminderFrequencyValue.TabIndex = 9;
      this.Label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label4.Location = new System.Drawing.Point(456, 58);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(40, 20);
      this.Label4.TabIndex = 36;
      this.Label4.Text = "Time";
      this.Label3.Location = new System.Drawing.Point(176, 57);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(40, 20);
      this.Label3.TabIndex = 34;
      this.Label3.Text = "Date";
      this.pnlReminderType.Controls.Add((Control) this.radOther);
      this.pnlReminderType.Controls.Add((Control) this.radPeriod);
      this.pnlReminderType.Location = new System.Drawing.Point(96, 24);
      this.pnlReminderType.Name = "pnlReminderType";
      this.pnlReminderType.Size = new Size(72, 56);
      this.pnlReminderType.TabIndex = 33;
      this.radOther.Location = new System.Drawing.Point(8, 27);
      this.radOther.Name = "radOther";
      this.radOther.Size = new Size(64, 24);
      this.radOther.TabIndex = 8;
      this.radOther.Text = "Other";
      this.radPeriod.Location = new System.Drawing.Point(8, 2);
      this.radPeriod.Name = "radPeriod";
      this.radPeriod.Size = new Size(64, 24);
      this.radPeriod.TabIndex = 7;
      this.radPeriod.Text = "Period";
      this.Label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label1.Location = new System.Drawing.Point(456, 28);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(144, 16);
      this.Label1.TabIndex = 32;
      this.Label1.Text = "Prior to due date && time";
      this.cboReminderFrequency.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboReminderFrequency.Location = new System.Drawing.Point(272, 26);
      this.cboReminderFrequency.Name = "cboReminderFrequency";
      this.cboReminderFrequency.Size = new Size(176, 21);
      this.cboReminderFrequency.TabIndex = 10;
      this.chkReminderRequired.Location = new System.Drawing.Point(8, 24);
      this.chkReminderRequired.Name = "chkReminderRequired";
      this.chkReminderRequired.Size = new Size(88, 56);
      this.chkReminderRequired.TabIndex = 6;
      this.chkReminderRequired.Text = "Reminder Required";
      this.dtpReminderDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dtpReminderDate.Location = new System.Drawing.Point(216, 57);
      this.dtpReminderDate.Name = "dtpReminderDate";
      this.dtpReminderDate.Size = new Size(232, 21);
      this.dtpReminderDate.TabIndex = 11;
      this.dtpReminderDate.Tag = (object) "Notes.NoteDate";
      this.cboReminderHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboReminderHours.Location = new System.Drawing.Point(496, 58);
      this.cboReminderHours.Name = "cboReminderHours";
      this.cboReminderHours.Size = new Size(104, 21);
      this.cboReminderHours.TabIndex = 12;
      this.cboReminderMinutes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboReminderMinutes.Location = new System.Drawing.Point(600, 58);
      this.cboReminderMinutes.Name = "cboReminderMinutes";
      this.cboReminderMinutes.Size = new Size(104, 21);
      this.cboReminderMinutes.TabIndex = 13;
      this.cboCategoryID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboCategoryID.Cursor = Cursors.Hand;
      this.cboCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCategoryID.Location = new System.Drawing.Point(72, 82);
      this.cboCategoryID.Name = "cboCategoryID";
      this.cboCategoryID.Size = new Size(651, 21);
      this.cboCategoryID.TabIndex = 4;
      this.cboCategoryID.Tag = (object) "Notes.CategoryID";
      this.lblCategoryID.Location = new System.Drawing.Point(8, 82);
      this.lblCategoryID.Name = "lblCategoryID";
      this.lblCategoryID.Size = new Size(64, 20);
      this.lblCategoryID.TabIndex = 31;
      this.lblCategoryID.Text = "Category";
      this.dtpNoteDate.Location = new System.Drawing.Point(72, 24);
      this.dtpNoteDate.Name = "dtpNoteDate";
      this.dtpNoteDate.Size = new Size(208, 21);
      this.dtpNoteDate.TabIndex = 1;
      this.dtpNoteDate.Tag = (object) "Notes.NoteDate";
      this.lblNoteDate.Location = new System.Drawing.Point(8, 24);
      this.lblNoteDate.Name = "lblNoteDate";
      this.lblNoteDate.Size = new Size(48, 21);
      this.lblNoteDate.TabIndex = 31;
      this.lblNoteDate.Text = "Date";
      this.txtNote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNote.Location = new System.Drawing.Point(72, 111);
      this.txtNote.Multiline = true;
      this.txtNote.Name = "txtNote";
      this.txtNote.ScrollBars = ScrollBars.Vertical;
      this.txtNote.Size = new Size(651, 88);
      this.txtNote.TabIndex = 5;
      this.txtNote.Tag = (object) "Notes.Note";
      this.txtNote.Text = "";
      this.lblNote.Location = new System.Drawing.Point(8, 111);
      this.lblNote.Name = "lblNote";
      this.lblNote.Size = new Size(48, 20);
      this.lblNote.TabIndex = 31;
      this.lblNote.Text = "Note";
      this.cboTimeHours.Location = new System.Drawing.Point(328, 24);
      this.cboTimeHours.Name = "cboTimeHours";
      this.cboTimeHours.Size = new Size(104, 21);
      this.cboTimeHours.TabIndex = 2;
      this.Label5.Location = new System.Drawing.Point(8, 53);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(64, 20);
      this.Label5.TabIndex = 34;
      this.Label5.Text = "For User:";
      this.cboUserFor.Location = new System.Drawing.Point(72, 53);
      this.cboUserFor.Name = "cboUserFor";
      this.cboUserFor.Size = new Size(208, 21);
      this.cboUserFor.TabIndex = 35;
      this.Controls.Add((Control) this.grpNotes);
      this.Name = nameof (UCNotes);
      this.Size = new Size(747, 325);
      this.grpNotes.ResumeLayout(false);
      this.grpReminderDetails.ResumeLayout(false);
      this.pnlReminderType.ResumeLayout(false);
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
        return (object) this.CurrentNote;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public FSM.Entity.Notes.Notes CurrentNote
    {
      get
      {
        return this._currentNotes;
      }
      set
      {
        this._currentNotes = value;
        if (this._currentNotes == null)
        {
          this._currentNotes = new FSM.Entity.Notes.Notes();
          this._currentNotes.Exists = false;
        }
        if (this.CurrentNote.Exists)
          this.Populate(0);
        else
          this.chkReminderRequired.Checked = false;
        this.SetReminderStatus(false);
      }
    }

    private void UCNotes_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void chkReminderRequired_CheckedChanged(object sender, EventArgs e)
    {
      this.SetReminderStatus(false);
    }

    private void radPeriod_CheckedChanged(object sender, EventArgs e)
    {
      this.SetReminderStatus(true);
    }

    private void radOther_CheckedChanged(object sender, EventArgs e)
    {
      this.SetReminderStatus(true);
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentNote = App.DB.Notes.Notes_Get(ID);
      this.dtpNoteDate.Value = this.CurrentNote.NoteDate.Date;
      ComboBox combo = this.cboTimeHours;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentNote.NoteDate.Hour));
      this.cboTimeHours = combo;
      combo = this.cboTimeMinutes;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentNote.NoteDate.Minute));
      this.cboTimeMinutes = combo;
      combo = this.cboCategoryID;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentNote.CategoryID));
      this.cboCategoryID = combo;
      this.txtNote.Text = this.CurrentNote.Note;
      combo = this.cboUserFor;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentNote.UserIDFor));
      this.cboUserFor = combo;
      if (this.CurrentNote.ReminderStatusID == 1)
        this.chkReminderRequired.Checked = true;
      else
        this.chkReminderRequired.Checked = false;
    }

    private void SetReminderStatus(bool fromTick)
    {
      if (!this.chkReminderRequired.Checked)
      {
        this.radPeriod.Enabled = false;
        this.radOther.Enabled = false;
        this.cboReminderFrequencyValue.Enabled = false;
        this.cboReminderFrequency.Enabled = false;
        this.dtpReminderDate.Enabled = false;
        this.cboReminderHours.Enabled = false;
        this.cboReminderMinutes.Enabled = false;
        this.radOther.Checked = false;
        this.radOther.Checked = false;
      }
      else
      {
        this.radPeriod.Enabled = true;
        this.radOther.Enabled = true;
        if (!fromTick)
        {
          if (this.CurrentNote.ReminderStatusID == 1)
          {
            this.radPeriod.Checked = false;
            this.radOther.Checked = true;
            this.cboReminderFrequencyValue.Enabled = false;
            this.cboReminderFrequency.Enabled = false;
            this.dtpReminderDate.Enabled = true;
            this.cboReminderHours.Enabled = true;
            this.cboReminderMinutes.Enabled = true;
            this.dtpReminderDate.Value = this.CurrentNote.DateTimeOfReminder.Date;
            ComboBox comboBox = this.cboReminderHours;
            ref ComboBox local1 = ref comboBox;
            DateTime dateTimeOfReminder = this.CurrentNote.DateTimeOfReminder;
            string str1 = Conversions.ToString(dateTimeOfReminder.Hour);
            Combo.SetSelectedComboItem_By_Value(ref local1, str1);
            this.cboReminderHours = comboBox;
            comboBox = this.cboReminderMinutes;
            ref ComboBox local2 = ref comboBox;
            dateTimeOfReminder = this.CurrentNote.DateTimeOfReminder;
            string str2 = Conversions.ToString(dateTimeOfReminder.Minute);
            Combo.SetSelectedComboItem_By_Value(ref local2, str2);
            this.cboReminderMinutes = comboBox;
          }
          else if (!this.radPeriod.Checked & !this.radOther.Checked)
            this.radPeriod.Checked = true;
        }
        if (this.radPeriod.Checked)
        {
          this.cboReminderFrequencyValue.Enabled = true;
          this.cboReminderFrequency.Enabled = true;
          this.dtpReminderDate.Enabled = false;
          this.cboReminderHours.Enabled = false;
          this.cboReminderMinutes.Enabled = false;
        }
        else
        {
          this.cboReminderFrequencyValue.Enabled = false;
          this.cboReminderFrequency.Enabled = false;
          this.dtpReminderDate.Enabled = true;
          this.cboReminderHours.Enabled = true;
          this.cboReminderMinutes.Enabled = true;
        }
      }
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentNote.IgnoreExceptionsOnSetMethods = true;
        this.CurrentNote.SetCategoryID = (object) Combo.get_GetSelectedItemValue(this.cboCategoryID);
        this.CurrentNote.NoteDate = Conversions.ToDate(Conversions.ToString(this.dtpNoteDate.Value.Date) + " " + Combo.get_GetSelectedItemValue(this.cboTimeHours) + ":" + Combo.get_GetSelectedItemValue(this.cboTimeMinutes) + ":00");
        this.CurrentNote.SetNote = (object) this.txtNote.Text.Trim();
        this.CurrentNote.SetUserIDFor = (object) Combo.get_GetSelectedItemValue(this.cboUserFor);
        if (!this.chkReminderRequired.Checked)
        {
          this.CurrentNote.SetReminderStatusID = (object) 2;
          this.CurrentNote.DateTimeOfReminder = this.CurrentNote.NoteDate;
        }
        else
        {
          this.CurrentNote.SetReminderStatusID = (object) 1;
          DateTime dateTime1 = new DateTime();
          DateTime dateTime2;
          if (this.radOther.Checked)
          {
            dateTime2 = Conversions.ToDate(Conversions.ToString(this.dtpReminderDate.Value.Date) + " " + Combo.get_GetSelectedItemValue(this.cboReminderHours) + ":" + Combo.get_GetSelectedItemValue(this.cboReminderMinutes) + ":00");
          }
          else
          {
            dateTime2 = this.CurrentNote.NoteDate;
            switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboReminderFrequency)))
            {
              case 1:
                dateTime2 = dateTime2.AddMinutes((double) checked (-Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboReminderFrequencyValue))));
                break;
              case 2:
                dateTime2 = dateTime2.AddHours((double) checked (-Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboReminderFrequencyValue))));
                break;
              case 3:
                dateTime2 = dateTime2.AddDays((double) checked (-Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboReminderFrequencyValue))));
                break;
              case 4:
                dateTime2 = dateTime2.AddDays((double) checked (-Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboReminderFrequencyValue)) * 7));
                break;
              case 5:
                dateTime2 = dateTime2.AddMonths(checked (-Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboReminderFrequencyValue))));
                break;
              case 6:
                dateTime2 = dateTime2.AddYears(checked (-Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboReminderFrequencyValue))));
                break;
            }
          }
          this.CurrentNote.DateTimeOfReminder = dateTime2;
        }
        new NotesValidator().Validate(this.CurrentNote);
        if (this.CurrentNote.Exists)
          App.DB.Notes.Update(this.CurrentNote);
        else
          this.CurrentNote = App.DB.Notes.Insert(this.CurrentNote);
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentNote.NoteID);
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
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
  }
}
