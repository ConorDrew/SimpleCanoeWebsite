// Decompiled with JetBrains decompiler
// Type: FSM.FRMContactAttempt
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContactAttempts;
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
  public class FRMContactAttempt : Form
  {
    private IContainer components;
    private Enums.TableNames LinkTable;
    private int LinkID;

    public FRMContactAttempt(Enums.TableNames linkTable, int linkId)
    {
      this.InitializeComponent();
      this.LinkTable = linkTable;
      this.LinkID = linkId;
      ComboBox cboMethod = this.cboMethod;
      Combo.SetUpCombo(ref cboMethod, App.DB.ContactAttempts.ContactMethod_GetAll().Table, "ContactMethodID", "Name", Enums.ComboValues.Please_Select);
      this.cboMethod = cboMethod;
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

    internal virtual Label lblContactMethod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboMethod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnSave = new Button();
      this.lblContactMethod = new Label();
      this.cboMethod = new ComboBox();
      this.lblDate = new Label();
      this.dtpDate = new DateTimePicker();
      this.lblTime = new Label();
      this.dtpTime = new DateTimePicker();
      this.lblNote = new Label();
      this.txtNote = new TextBox();
      this.SuspendLayout();
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(341, 242);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(77, 23);
      this.btnSave.TabIndex = 48;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.lblContactMethod.AutoSize = true;
      this.lblContactMethod.Location = new System.Drawing.Point(12, 18);
      this.lblContactMethod.Name = "lblContactMethod";
      this.lblContactMethod.Size = new Size(46, 13);
      this.lblContactMethod.TabIndex = 49;
      this.lblContactMethod.Text = "Method:";
      this.cboMethod.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboMethod.FormattingEnabled = true;
      this.cboMethod.Location = new System.Drawing.Point(74, 15);
      this.cboMethod.Name = "cboMethod";
      this.cboMethod.Size = new Size(344, 21);
      this.cboMethod.TabIndex = 50;
      this.lblDate.AutoSize = true;
      this.lblDate.Location = new System.Drawing.Point(12, 61);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new Size(33, 13);
      this.lblDate.TabIndex = 51;
      this.lblDate.Text = "Date:";
      this.dtpDate.Location = new System.Drawing.Point(74, 58);
      this.dtpDate.Name = "dtpDate";
      this.dtpDate.Size = new Size(156, 20);
      this.dtpDate.TabIndex = 52;
      this.lblTime.AutoSize = true;
      this.lblTime.Location = new System.Drawing.Point(251, 61);
      this.lblTime.Name = "lblTime";
      this.lblTime.Size = new Size(33, 13);
      this.lblTime.TabIndex = 53;
      this.lblTime.Text = "Time:";
      this.dtpTime.Format = DateTimePickerFormat.Time;
      this.dtpTime.Location = new System.Drawing.Point(290, 58);
      this.dtpTime.Name = "dtpTime";
      this.dtpTime.Size = new Size(69, 20);
      this.dtpTime.TabIndex = 54;
      this.lblNote.AutoSize = true;
      this.lblNote.Location = new System.Drawing.Point(12, 105);
      this.lblNote.Name = "lblNote";
      this.lblNote.Size = new Size(33, 13);
      this.lblNote.TabIndex = 55;
      this.lblNote.Text = "Note:";
      this.txtNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtNote.Location = new System.Drawing.Point(74, 105);
      this.txtNote.Multiline = true;
      this.txtNote.Name = "txtNote";
      this.txtNote.ScrollBars = ScrollBars.Vertical;
      this.txtNote.Size = new Size(344, 112);
      this.txtNote.TabIndex = 56;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.White;
      this.ClientSize = new Size(430, 277);
      this.Controls.Add((Control) this.txtNote);
      this.Controls.Add((Control) this.lblNote);
      this.Controls.Add((Control) this.dtpTime);
      this.Controls.Add((Control) this.lblTime);
      this.Controls.Add((Control) this.dtpDate);
      this.Controls.Add((Control) this.lblDate);
      this.Controls.Add((Control) this.cboMethod);
      this.Controls.Add((Control) this.lblContactMethod);
      this.Controls.Add((Control) this.btnSave);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MaximumSize = new Size(1000, 1000);
      this.MinimizeBox = false;
      this.Name = nameof (FRMContactAttempt);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Contact Attempt";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private bool IsFormValid()
    {
      if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboMethod)) == 0)
      {
        int num = (int) App.ShowMessage("Please select a contact method!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (this.txtNote.Text.Trim().Length != 0)
        return true;
      int num1 = (int) App.ShowMessage("Please add a note!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }

    private void Save()
    {
      try
      {
        if (!this.IsFormValid())
          return;
        ContactAttempt contactAttempt1 = new ContactAttempt();
        ContactAttempt contactAttempt2 = contactAttempt1;
        contactAttempt2.ContactMethedID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboMethod));
        contactAttempt2.LinkID = (int) this.LinkTable;
        contactAttempt2.LinkRef = this.LinkID;
        contactAttempt2.ContactMade = new DateTime(this.dtpDate.Value.Year, this.dtpDate.Value.Month, this.dtpDate.Value.Day, this.dtpTime.Value.Hour, this.dtpTime.Value.Minute, this.dtpTime.Value.Second);
        contactAttempt2.Notes = this.txtNote.Text.Trim();
        contactAttempt2.ContactMadeByUserId = App.loggedInUser.UserID;
        if (App.DB.ContactAttempts.Insert(contactAttempt1).ContactAttemptID > 0)
        {
          int num = (int) App.ShowMessage("Contact attempt saved!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          this.DialogResult = DialogResult.OK;
          if (this.Modal)
            this.Close();
          else
            this.Dispose();
        }
        else
        {
          int num1 = (int) App.ShowMessage("Could not save Contact attempt!, please try re-enter the details.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        int num = (int) App.ShowMessage(exception.Message + " - " + exception.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }
  }
}
