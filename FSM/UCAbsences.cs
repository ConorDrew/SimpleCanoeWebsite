// Decompiled with JetBrains decompiler
// Type: FSM.UCAbsences
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class UCAbsences : UCBase, IUserControl
  {
    private IContainer components;
    private Enums.UserType _userType;
    private int _absenceID;
    private FSM.Entity.UserAbsence.UserAbsence _userAbsence;
    private FSM.Entity.EngineerAbsence.EngineerAbsence _engineerAbsence;

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
      this.gbAbsence = new GroupBox();
      this.txtEndTimeMinutes = new TextBox();
      this.txtEndTimeHours = new TextBox();
      this.txtStartTimeMinutes = new TextBox();
      this.txtStartTimeHours = new TextBox();
      this.lblTimeToSpacer = new Label();
      this.lblTimeFromSpacer = new Label();
      this.lblType = new Label();
      this.cboType = new ComboBox();
      this.dtTo = new DateTimePicker();
      this.dtFrom = new DateTimePicker();
      this.cboUsers = new ComboBox();
      this.lblUser = new Label();
      this.txtComments = new TextBox();
      this.lblToDate = new Label();
      this.lblFromDate = new Label();
      this.lblComments = new Label();
      this.tcMain = new TabControl();
      this.tpGeneral = new TabPage();
      this.tpRecurring = new TabPage();
      this.gpRecurring = new GroupBox();
      this.lblRecurringTimeTo = new Label();
      this.lblTimeFrom = new Label();
      this.cbSunday = new CheckBox();
      this.cbSaturday = new CheckBox();
      this.cbFriday = new CheckBox();
      this.cbThursday = new CheckBox();
      this.cbWednesday = new CheckBox();
      this.cbTuesday = new CheckBox();
      this.txtRecurringTimeToMins = new TextBox();
      this.cbMonday = new CheckBox();
      this.txtRecurringTimeToHours = new TextBox();
      this.txtRecurringTimeFromMins = new TextBox();
      this.txtRecurringTimeFromHours = new TextBox();
      this.lblRecurringTimeToSpacer = new Label();
      this.lblRecurringTimeFromSpacer = new Label();
      this.lblRecurringType = new Label();
      this.cboRecurringType = new ComboBox();
      this.dtRecurringDateTo = new DateTimePicker();
      this.dtRecurringDateFrom = new DateTimePicker();
      this.cboRecurringUser = new ComboBox();
      this.lblRecurringUser = new Label();
      this.txtRecurringComments = new TextBox();
      this.lblRecurringDateTo = new Label();
      this.lblRecurringDateFrom = new Label();
      this.lblRecurringComments = new Label();
      this.gbAbsence.SuspendLayout();
      this.tcMain.SuspendLayout();
      this.tpGeneral.SuspendLayout();
      this.tpRecurring.SuspendLayout();
      this.gpRecurring.SuspendLayout();
      this.SuspendLayout();
      this.gbAbsence.Anchor = AnchorStyles.Top;
      this.gbAbsence.Controls.Add((Control) this.txtEndTimeMinutes);
      this.gbAbsence.Controls.Add((Control) this.txtEndTimeHours);
      this.gbAbsence.Controls.Add((Control) this.txtStartTimeMinutes);
      this.gbAbsence.Controls.Add((Control) this.txtStartTimeHours);
      this.gbAbsence.Controls.Add((Control) this.lblTimeToSpacer);
      this.gbAbsence.Controls.Add((Control) this.lblTimeFromSpacer);
      this.gbAbsence.Controls.Add((Control) this.lblType);
      this.gbAbsence.Controls.Add((Control) this.cboType);
      this.gbAbsence.Controls.Add((Control) this.dtTo);
      this.gbAbsence.Controls.Add((Control) this.dtFrom);
      this.gbAbsence.Controls.Add((Control) this.cboUsers);
      this.gbAbsence.Controls.Add((Control) this.lblUser);
      this.gbAbsence.Controls.Add((Control) this.txtComments);
      this.gbAbsence.Controls.Add((Control) this.lblToDate);
      this.gbAbsence.Controls.Add((Control) this.lblFromDate);
      this.gbAbsence.Controls.Add((Control) this.lblComments);
      this.gbAbsence.Font = new Font("Verdana", 8f);
      this.gbAbsence.Location = new System.Drawing.Point(3, 6);
      this.gbAbsence.Name = "gbAbsence";
      this.gbAbsence.Size = new Size(613, 156);
      this.gbAbsence.TabIndex = 26;
      this.gbAbsence.TabStop = false;
      this.gbAbsence.Text = "User Absence";
      this.txtEndTimeMinutes.Location = new System.Drawing.Point(336, 120);
      this.txtEndTimeMinutes.MaxLength = 2;
      this.txtEndTimeMinutes.Name = "txtEndTimeMinutes";
      this.txtEndTimeMinutes.Size = new Size(27, 20);
      this.txtEndTimeMinutes.TabIndex = 53;
      this.txtEndTimeHours.Location = new System.Drawing.Point(299, 120);
      this.txtEndTimeHours.MaxLength = 2;
      this.txtEndTimeHours.Name = "txtEndTimeHours";
      this.txtEndTimeHours.Size = new Size(27, 20);
      this.txtEndTimeHours.TabIndex = 46;
      this.txtStartTimeMinutes.Location = new System.Drawing.Point(336, 88);
      this.txtStartTimeMinutes.MaxLength = 2;
      this.txtStartTimeMinutes.Name = "txtStartTimeMinutes";
      this.txtStartTimeMinutes.Size = new Size(27, 20);
      this.txtStartTimeMinutes.TabIndex = 45;
      this.txtStartTimeHours.Location = new System.Drawing.Point(299, 88);
      this.txtStartTimeHours.MaxLength = 2;
      this.txtStartTimeHours.Name = "txtStartTimeHours";
      this.txtStartTimeHours.Size = new Size(27, 20);
      this.txtStartTimeHours.TabIndex = 44;
      this.lblTimeToSpacer.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTimeToSpacer.Location = new System.Drawing.Point(325, 123);
      this.lblTimeToSpacer.Name = "lblTimeToSpacer";
      this.lblTimeToSpacer.Size = new Size(9, 17);
      this.lblTimeToSpacer.TabIndex = 43;
      this.lblTimeToSpacer.Text = ":";
      this.lblTimeFromSpacer.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTimeFromSpacer.Location = new System.Drawing.Point(325, 91);
      this.lblTimeFromSpacer.Name = "lblTimeFromSpacer";
      this.lblTimeFromSpacer.Size = new Size(9, 17);
      this.lblTimeFromSpacer.TabIndex = 42;
      this.lblTimeFromSpacer.Text = ":";
      this.lblType.Font = new Font("Verdana", 8f);
      this.lblType.Location = new System.Drawing.Point(9, 56);
      this.lblType.Name = "lblType";
      this.lblType.Size = new Size(56, 17);
      this.lblType.TabIndex = 37;
      this.lblType.Text = "Type";
      this.cboType.Anchor = AnchorStyles.Top;
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Font = new Font("Verdana", 8f);
      this.cboType.ItemHeight = 13;
      this.cboType.Items.AddRange(new object[3]
      {
        (object) "Holiday",
        (object) "Sickness",
        (object) "Other"
      });
      this.cboType.Location = new System.Drawing.Point(93, 56);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(270, 21);
      this.cboType.TabIndex = 2;
      this.dtTo.Font = new Font("Verdana", 8f);
      this.dtTo.Location = new System.Drawing.Point(93, 120);
      this.dtTo.Name = "dtTo";
      this.dtTo.Size = new Size(201, 20);
      this.dtTo.TabIndex = 6;
      this.dtFrom.Font = new Font("Verdana", 8f);
      this.dtFrom.Location = new System.Drawing.Point(93, 88);
      this.dtFrom.Name = "dtFrom";
      this.dtFrom.Size = new Size(200, 20);
      this.dtFrom.TabIndex = 3;
      this.cboUsers.Anchor = AnchorStyles.Top;
      this.cboUsers.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboUsers.Font = new Font("Verdana", 8f);
      this.cboUsers.ItemHeight = 13;
      this.cboUsers.Items.AddRange(new object[3]
      {
        (object) "Holiday",
        (object) "Sickness",
        (object) "Other"
      });
      this.cboUsers.Location = new System.Drawing.Point(93, 24);
      this.cboUsers.Name = "cboUsers";
      this.cboUsers.Size = new Size(270, 21);
      this.cboUsers.TabIndex = 1;
      this.lblUser.Font = new Font("Verdana", 8f);
      this.lblUser.Location = new System.Drawing.Point(9, 24);
      this.lblUser.Name = "lblUser";
      this.lblUser.Size = new Size(78, 17);
      this.lblUser.TabIndex = 18;
      this.lblUser.Text = "User";
      this.txtComments.Font = new Font("Verdana", 8f);
      this.txtComments.Location = new System.Drawing.Point(373, 48);
      this.txtComments.Multiline = true;
      this.txtComments.Name = "txtComments";
      this.txtComments.ScrollBars = ScrollBars.Both;
      this.txtComments.Size = new Size(234, 96);
      this.txtComments.TabIndex = 9;
      this.lblToDate.Font = new Font("Verdana", 8f);
      this.lblToDate.Location = new System.Drawing.Point(9, 120);
      this.lblToDate.Name = "lblToDate";
      this.lblToDate.Size = new Size(54, 18);
      this.lblToDate.TabIndex = 20;
      this.lblToDate.Text = "To";
      this.lblFromDate.Font = new Font("Verdana", 8f);
      this.lblFromDate.Location = new System.Drawing.Point(9, 88);
      this.lblFromDate.Name = "lblFromDate";
      this.lblFromDate.Size = new Size(47, 18);
      this.lblFromDate.TabIndex = 19;
      this.lblFromDate.Text = "From";
      this.lblComments.Font = new Font("Verdana", 8f);
      this.lblComments.Location = new System.Drawing.Point(373, 24);
      this.lblComments.Name = "lblComments";
      this.lblComments.Size = new Size(84, 17);
      this.lblComments.TabIndex = 23;
      this.lblComments.Text = "Comments";
      this.tcMain.Anchor = AnchorStyles.Top;
      this.tcMain.Controls.Add((Control) this.tpGeneral);
      this.tcMain.Controls.Add((Control) this.tpRecurring);
      this.tcMain.Location = new System.Drawing.Point(3, 3);
      this.tcMain.Name = "tcMain";
      this.tcMain.SelectedIndex = 0;
      this.tcMain.Size = new Size(624, 230);
      this.tcMain.TabIndex = 27;
      this.tpGeneral.BackColor = Color.White;
      this.tpGeneral.Controls.Add((Control) this.gbAbsence);
      this.tpGeneral.Location = new System.Drawing.Point(4, 22);
      this.tpGeneral.Name = "tpGeneral";
      this.tpGeneral.Padding = new Padding(3);
      this.tpGeneral.Size = new Size(616, 204);
      this.tpGeneral.TabIndex = 0;
      this.tpGeneral.Text = "General";
      this.tpRecurring.BackColor = Color.White;
      this.tpRecurring.Controls.Add((Control) this.gpRecurring);
      this.tpRecurring.Location = new System.Drawing.Point(4, 22);
      this.tpRecurring.Name = "tpRecurring";
      this.tpRecurring.Padding = new Padding(3);
      this.tpRecurring.Size = new Size(616, 204);
      this.tpRecurring.TabIndex = 1;
      this.tpRecurring.Text = "Recurring";
      this.gpRecurring.Anchor = AnchorStyles.Top;
      this.gpRecurring.Controls.Add((Control) this.lblRecurringTimeTo);
      this.gpRecurring.Controls.Add((Control) this.lblTimeFrom);
      this.gpRecurring.Controls.Add((Control) this.cbSunday);
      this.gpRecurring.Controls.Add((Control) this.cbSaturday);
      this.gpRecurring.Controls.Add((Control) this.cbFriday);
      this.gpRecurring.Controls.Add((Control) this.cbThursday);
      this.gpRecurring.Controls.Add((Control) this.cbWednesday);
      this.gpRecurring.Controls.Add((Control) this.cbTuesday);
      this.gpRecurring.Controls.Add((Control) this.txtRecurringTimeToMins);
      this.gpRecurring.Controls.Add((Control) this.cbMonday);
      this.gpRecurring.Controls.Add((Control) this.txtRecurringTimeToHours);
      this.gpRecurring.Controls.Add((Control) this.txtRecurringTimeFromMins);
      this.gpRecurring.Controls.Add((Control) this.txtRecurringTimeFromHours);
      this.gpRecurring.Controls.Add((Control) this.lblRecurringTimeToSpacer);
      this.gpRecurring.Controls.Add((Control) this.lblRecurringTimeFromSpacer);
      this.gpRecurring.Controls.Add((Control) this.lblRecurringType);
      this.gpRecurring.Controls.Add((Control) this.cboRecurringType);
      this.gpRecurring.Controls.Add((Control) this.dtRecurringDateTo);
      this.gpRecurring.Controls.Add((Control) this.dtRecurringDateFrom);
      this.gpRecurring.Controls.Add((Control) this.cboRecurringUser);
      this.gpRecurring.Controls.Add((Control) this.lblRecurringUser);
      this.gpRecurring.Controls.Add((Control) this.txtRecurringComments);
      this.gpRecurring.Controls.Add((Control) this.lblRecurringDateTo);
      this.gpRecurring.Controls.Add((Control) this.lblRecurringDateFrom);
      this.gpRecurring.Controls.Add((Control) this.lblRecurringComments);
      this.gpRecurring.Font = new Font("Verdana", 8f);
      this.gpRecurring.Location = new System.Drawing.Point(6, 6);
      this.gpRecurring.Name = "gpRecurring";
      this.gpRecurring.Size = new Size(610, 192);
      this.gpRecurring.TabIndex = 27;
      this.gpRecurring.TabStop = false;
      this.gpRecurring.Text = "User Recurring Absence";
      this.lblRecurringTimeTo.AutoSize = true;
      this.lblRecurringTimeTo.Font = new Font("Verdana", 8f);
      this.lblRecurringTimeTo.Location = new System.Drawing.Point(138, 121);
      this.lblRecurringTimeTo.Name = "lblRecurringTimeTo";
      this.lblRecurringTimeTo.Size = new Size(25, 13);
      this.lblRecurringTimeTo.TabIndex = 61;
      this.lblRecurringTimeTo.Text = "To:";
      this.lblTimeFrom.AutoSize = true;
      this.lblTimeFrom.Font = new Font("Verdana", 8f);
      this.lblTimeFrom.Location = new System.Drawing.Point(9, 121);
      this.lblTimeFrom.Name = "lblTimeFrom";
      this.lblTimeFrom.Size = new Size(41, 13);
      this.lblTimeFrom.TabIndex = 60;
      this.lblTimeFrom.Text = "From:";
      this.cbSunday.Anchor = AnchorStyles.Top;
      this.cbSunday.AutoSize = true;
      this.cbSunday.Cursor = Cursors.Hand;
      this.cbSunday.Location = new System.Drawing.Point(514, 167);
      this.cbSunday.Name = "cbSunday";
      this.cbSunday.RightToLeft = RightToLeft.Yes;
      this.cbSunday.Size = new Size(48, 17);
      this.cbSunday.TabIndex = 59;
      this.cbSunday.Text = "Sun";
      this.cbSunday.UseVisualStyleBackColor = true;
      this.cbSaturday.Anchor = AnchorStyles.Top;
      this.cbSaturday.AutoSize = true;
      this.cbSaturday.Cursor = Cursors.Hand;
      this.cbSaturday.Location = new System.Drawing.Point(436, 167);
      this.cbSaturday.Name = "cbSaturday";
      this.cbSaturday.RightToLeft = RightToLeft.Yes;
      this.cbSaturday.Size = new Size(45, 17);
      this.cbSaturday.TabIndex = 58;
      this.cbSaturday.Text = "Sat";
      this.cbSaturday.UseVisualStyleBackColor = true;
      this.cbFriday.Anchor = AnchorStyles.Top;
      this.cbFriday.AutoSize = true;
      this.cbFriday.Cursor = Cursors.Hand;
      this.cbFriday.Location = new System.Drawing.Point(361, 167);
      this.cbFriday.Name = "cbFriday";
      this.cbFriday.RightToLeft = RightToLeft.Yes;
      this.cbFriday.Size = new Size(40, 17);
      this.cbFriday.TabIndex = 57;
      this.cbFriday.Text = "Fri";
      this.cbFriday.UseVisualStyleBackColor = true;
      this.cbThursday.Anchor = AnchorStyles.Top;
      this.cbThursday.AutoSize = true;
      this.cbThursday.Cursor = Cursors.Hand;
      this.cbThursday.Location = new System.Drawing.Point(269, 167);
      this.cbThursday.Name = "cbThursday";
      this.cbThursday.RightToLeft = RightToLeft.Yes;
      this.cbThursday.Size = new Size(58, 17);
      this.cbThursday.TabIndex = 56;
      this.cbThursday.Text = "Thurs";
      this.cbThursday.UseVisualStyleBackColor = true;
      this.cbWednesday.Anchor = AnchorStyles.Top;
      this.cbWednesday.AutoSize = true;
      this.cbWednesday.Cursor = Cursors.Hand;
      this.cbWednesday.Location = new System.Drawing.Point(179, 167);
      this.cbWednesday.Name = "cbWednesday";
      this.cbWednesday.RightToLeft = RightToLeft.Yes;
      this.cbWednesday.Size = new Size(56, 17);
      this.cbWednesday.TabIndex = 55;
      this.cbWednesday.Text = "Weds";
      this.cbWednesday.UseVisualStyleBackColor = true;
      this.cbTuesday.Anchor = AnchorStyles.Top;
      this.cbTuesday.AutoSize = true;
      this.cbTuesday.Cursor = Cursors.Hand;
      this.cbTuesday.Location = new System.Drawing.Point(93, 167);
      this.cbTuesday.Name = "cbTuesday";
      this.cbTuesday.RightToLeft = RightToLeft.Yes;
      this.cbTuesday.Size = new Size(52, 17);
      this.cbTuesday.TabIndex = 54;
      this.cbTuesday.Text = "Tues";
      this.cbTuesday.UseVisualStyleBackColor = true;
      this.txtRecurringTimeToMins.Location = new System.Drawing.Point(206, 118);
      this.txtRecurringTimeToMins.MaxLength = 2;
      this.txtRecurringTimeToMins.Name = "txtRecurringTimeToMins";
      this.txtRecurringTimeToMins.Size = new Size(27, 20);
      this.txtRecurringTimeToMins.TabIndex = 47;
      this.cbMonday.Anchor = AnchorStyles.Top;
      this.cbMonday.AutoSize = true;
      this.cbMonday.Cursor = Cursors.Hand;
      this.cbMonday.Location = new System.Drawing.Point(10, 167);
      this.cbMonday.Name = "cbMonday";
      this.cbMonday.RightToLeft = RightToLeft.Yes;
      this.cbMonday.Size = new Size(49, 17);
      this.cbMonday.TabIndex = 50;
      this.cbMonday.Text = "Mon";
      this.cbMonday.UseVisualStyleBackColor = true;
      this.txtRecurringTimeToHours.Location = new System.Drawing.Point(169, 118);
      this.txtRecurringTimeToHours.MaxLength = 2;
      this.txtRecurringTimeToHours.Name = "txtRecurringTimeToHours";
      this.txtRecurringTimeToHours.Size = new Size(27, 20);
      this.txtRecurringTimeToHours.TabIndex = 46;
      this.txtRecurringTimeFromMins.Location = new System.Drawing.Point(95, 118);
      this.txtRecurringTimeFromMins.MaxLength = 2;
      this.txtRecurringTimeFromMins.Name = "txtRecurringTimeFromMins";
      this.txtRecurringTimeFromMins.Size = new Size(27, 20);
      this.txtRecurringTimeFromMins.TabIndex = 45;
      this.txtRecurringTimeFromHours.Location = new System.Drawing.Point(58, 118);
      this.txtRecurringTimeFromHours.MaxLength = 2;
      this.txtRecurringTimeFromHours.Name = "txtRecurringTimeFromHours";
      this.txtRecurringTimeFromHours.Size = new Size(27, 20);
      this.txtRecurringTimeFromHours.TabIndex = 44;
      this.lblRecurringTimeToSpacer.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblRecurringTimeToSpacer.Location = new System.Drawing.Point(195, 120);
      this.lblRecurringTimeToSpacer.Name = "lblRecurringTimeToSpacer";
      this.lblRecurringTimeToSpacer.Size = new Size(9, 17);
      this.lblRecurringTimeToSpacer.TabIndex = 43;
      this.lblRecurringTimeToSpacer.Text = ":";
      this.lblRecurringTimeFromSpacer.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblRecurringTimeFromSpacer.Location = new System.Drawing.Point(84, 120);
      this.lblRecurringTimeFromSpacer.Name = "lblRecurringTimeFromSpacer";
      this.lblRecurringTimeFromSpacer.Size = new Size(9, 17);
      this.lblRecurringTimeFromSpacer.TabIndex = 42;
      this.lblRecurringTimeFromSpacer.Text = ":";
      this.lblRecurringType.Font = new Font("Verdana", 8f);
      this.lblRecurringType.Location = new System.Drawing.Point(9, 56);
      this.lblRecurringType.Name = "lblRecurringType";
      this.lblRecurringType.Size = new Size(37, 17);
      this.lblRecurringType.TabIndex = 37;
      this.lblRecurringType.Text = "Type";
      this.cboRecurringType.Anchor = AnchorStyles.Top;
      this.cboRecurringType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRecurringType.Font = new Font("Verdana", 8f);
      this.cboRecurringType.ItemHeight = 13;
      this.cboRecurringType.Items.AddRange(new object[3]
      {
        (object) "Holiday",
        (object) "Sickness",
        (object) "Other"
      });
      this.cboRecurringType.Location = new System.Drawing.Point(81, 52);
      this.cboRecurringType.Name = "cboRecurringType";
      this.cboRecurringType.Size = new Size(274, 21);
      this.cboRecurringType.TabIndex = 2;
      this.dtRecurringDateTo.Font = new Font("Verdana", 8f);
      this.dtRecurringDateTo.Location = new System.Drawing.Point(218, 88);
      this.dtRecurringDateTo.Name = "dtRecurringDateTo";
      this.dtRecurringDateTo.Size = new Size(137, 20);
      this.dtRecurringDateTo.TabIndex = 6;
      this.dtRecurringDateFrom.Checked = false;
      this.dtRecurringDateFrom.Font = new Font("Verdana", 8f);
      this.dtRecurringDateFrom.Location = new System.Drawing.Point(52, 88);
      this.dtRecurringDateFrom.Name = "dtRecurringDateFrom";
      this.dtRecurringDateFrom.Size = new Size(134, 20);
      this.dtRecurringDateFrom.TabIndex = 3;
      this.cboRecurringUser.Anchor = AnchorStyles.Top;
      this.cboRecurringUser.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRecurringUser.Font = new Font("Verdana", 8f);
      this.cboRecurringUser.ItemHeight = 13;
      this.cboRecurringUser.Items.AddRange(new object[3]
      {
        (object) "Holiday",
        (object) "Sickness",
        (object) "Other"
      });
      this.cboRecurringUser.Location = new System.Drawing.Point(81, 20);
      this.cboRecurringUser.Name = "cboRecurringUser";
      this.cboRecurringUser.Size = new Size(274, 21);
      this.cboRecurringUser.TabIndex = 1;
      this.lblRecurringUser.AutoSize = true;
      this.lblRecurringUser.Font = new Font("Verdana", 8f);
      this.lblRecurringUser.Location = new System.Drawing.Point(9, 24);
      this.lblRecurringUser.Name = "lblRecurringUser";
      this.lblRecurringUser.Size = new Size(33, 13);
      this.lblRecurringUser.TabIndex = 18;
      this.lblRecurringUser.Text = "User";
      this.txtRecurringComments.Font = new Font("Verdana", 8f);
      this.txtRecurringComments.Location = new System.Drawing.Point(363, 53);
      this.txtRecurringComments.Multiline = true;
      this.txtRecurringComments.Name = "txtRecurringComments";
      this.txtRecurringComments.ScrollBars = ScrollBars.Both;
      this.txtRecurringComments.Size = new Size(233, 96);
      this.txtRecurringComments.TabIndex = 9;
      this.lblRecurringDateTo.AutoSize = true;
      this.lblRecurringDateTo.Font = new Font("Verdana", 8f);
      this.lblRecurringDateTo.Location = new System.Drawing.Point(192, 93);
      this.lblRecurringDateTo.Name = "lblRecurringDateTo";
      this.lblRecurringDateTo.Size = new Size(20, 13);
      this.lblRecurringDateTo.TabIndex = 20;
      this.lblRecurringDateTo.Text = "To";
      this.lblRecurringDateFrom.Font = new Font("Verdana", 8f);
      this.lblRecurringDateFrom.Location = new System.Drawing.Point(9, 88);
      this.lblRecurringDateFrom.Name = "lblRecurringDateFrom";
      this.lblRecurringDateFrom.Size = new Size(47, 18);
      this.lblRecurringDateFrom.TabIndex = 19;
      this.lblRecurringDateFrom.Text = "From";
      this.lblRecurringComments.Font = new Font("Verdana", 8f);
      this.lblRecurringComments.Location = new System.Drawing.Point(360, 33);
      this.lblRecurringComments.Name = "lblRecurringComments";
      this.lblRecurringComments.Size = new Size(84, 17);
      this.lblRecurringComments.TabIndex = 23;
      this.lblRecurringComments.Text = "Comments";
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.tcMain);
      this.Name = nameof (UCAbsences);
      this.Size = new Size(632, 238);
      this.gbAbsence.ResumeLayout(false);
      this.gbAbsence.PerformLayout();
      this.tcMain.ResumeLayout(false);
      this.tpGeneral.ResumeLayout(false);
      this.tpRecurring.ResumeLayout(false);
      this.gpRecurring.ResumeLayout(false);
      this.gpRecurring.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox gbAbsence { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEndTimeHours
    {
      get
      {
        return this._txtEndTimeHours;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
        TextBox txtEndTimeHours1 = this._txtEndTimeHours;
        if (txtEndTimeHours1 != null)
          txtEndTimeHours1.TextChanged -= eventHandler;
        this._txtEndTimeHours = value;
        TextBox txtEndTimeHours2 = this._txtEndTimeHours;
        if (txtEndTimeHours2 == null)
          return;
        txtEndTimeHours2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtStartTimeMinutes
    {
      get
      {
        return this._txtStartTimeMinutes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
        TextBox startTimeMinutes1 = this._txtStartTimeMinutes;
        if (startTimeMinutes1 != null)
          startTimeMinutes1.TextChanged -= eventHandler;
        this._txtStartTimeMinutes = value;
        TextBox startTimeMinutes2 = this._txtStartTimeMinutes;
        if (startTimeMinutes2 == null)
          return;
        startTimeMinutes2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtStartTimeHours
    {
      get
      {
        return this._txtStartTimeHours;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
        TextBox txtStartTimeHours1 = this._txtStartTimeHours;
        if (txtStartTimeHours1 != null)
          txtStartTimeHours1.TextChanged -= eventHandler;
        this._txtStartTimeHours = value;
        TextBox txtStartTimeHours2 = this._txtStartTimeHours;
        if (txtStartTimeHours2 == null)
          return;
        txtStartTimeHours2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lblTimeToSpacer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTimeFromSpacer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUsers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtComments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblToDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFromDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblComments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEndTimeMinutes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl tcMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpGeneral { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpRecurring { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpRecurring { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRecurringTimeToMins
    {
      get
      {
        return this._txtRecurringTimeToMins;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeRecurringHours_TextChanged);
        TextBox recurringTimeToMins1 = this._txtRecurringTimeToMins;
        if (recurringTimeToMins1 != null)
          recurringTimeToMins1.TextChanged -= eventHandler;
        this._txtRecurringTimeToMins = value;
        TextBox recurringTimeToMins2 = this._txtRecurringTimeToMins;
        if (recurringTimeToMins2 == null)
          return;
        recurringTimeToMins2.TextChanged += eventHandler;
      }
    }

    internal virtual CheckBox cbMonday { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRecurringTimeToHours
    {
      get
      {
        return this._txtRecurringTimeToHours;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeRecurringHours_TextChanged);
        TextBox recurringTimeToHours1 = this._txtRecurringTimeToHours;
        if (recurringTimeToHours1 != null)
          recurringTimeToHours1.TextChanged -= eventHandler;
        this._txtRecurringTimeToHours = value;
        TextBox recurringTimeToHours2 = this._txtRecurringTimeToHours;
        if (recurringTimeToHours2 == null)
          return;
        recurringTimeToHours2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtRecurringTimeFromMins
    {
      get
      {
        return this._txtRecurringTimeFromMins;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeRecurringHours_TextChanged);
        TextBox recurringTimeFromMins1 = this._txtRecurringTimeFromMins;
        if (recurringTimeFromMins1 != null)
          recurringTimeFromMins1.TextChanged -= eventHandler;
        this._txtRecurringTimeFromMins = value;
        TextBox recurringTimeFromMins2 = this._txtRecurringTimeFromMins;
        if (recurringTimeFromMins2 == null)
          return;
        recurringTimeFromMins2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtRecurringTimeFromHours
    {
      get
      {
        return this._txtRecurringTimeFromHours;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeRecurringHours_TextChanged);
        TextBox recurringTimeFromHours1 = this._txtRecurringTimeFromHours;
        if (recurringTimeFromHours1 != null)
          recurringTimeFromHours1.TextChanged -= eventHandler;
        this._txtRecurringTimeFromHours = value;
        TextBox recurringTimeFromHours2 = this._txtRecurringTimeFromHours;
        if (recurringTimeFromHours2 == null)
          return;
        recurringTimeFromHours2.TextChanged += eventHandler;
      }
    }

    internal virtual Label lblRecurringTimeToSpacer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRecurringTimeFromSpacer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRecurringType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRecurringType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtRecurringDateTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtRecurringDateFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRecurringUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRecurringUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRecurringComments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRecurringDateTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRecurringDateFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRecurringComments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRecurringTimeTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTimeFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbSunday { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbSaturday { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbFriday { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbThursday { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbWednesday { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbTuesday { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public UCAbsences(Enums.UserType userType, int absenceID)
    {
      this._userType = new Enums.UserType();
      this._absenceID = 0;
      this._userAbsence = new FSM.Entity.UserAbsence.UserAbsence();
      this._engineerAbsence = new FSM.Entity.EngineerAbsence.EngineerAbsence();
      this.InitializeComponent();
      this.UserType = userType;
      this.AbsenceID = absenceID;
      if (this.AbsenceID > 0)
        this.tcMain.TabPages.Remove(this.tpRecurring);
      if (this.UserType == Enums.UserType.Engineer)
      {
        this.LoadEngineer();
      }
      else
      {
        if (this.UserType != Enums.UserType.User)
          return;
        this.LoadUser();
      }
    }

    public Enums.UserType UserType
    {
      get
      {
        return this._userType;
      }
      set
      {
        this._userType = value;
      }
    }

    public int AbsenceID
    {
      get
      {
        return this._absenceID;
      }
      set
      {
        this._absenceID = value;
      }
    }

    public FSM.Entity.UserAbsence.UserAbsence CurrentUserAbsence
    {
      get
      {
        return this._userAbsence;
      }
      set
      {
        this._userAbsence = value;
        if (Helper.MakeIntegerValid((object) this._userAbsence?.UserAbsenceID) > 0 && this.AbsenceID > 0)
        {
          this.LoadUserAbsence();
          this.Text = "Edit User Absence";
        }
        else
        {
          this._userAbsence = new FSM.Entity.UserAbsence.UserAbsence()
          {
            Exists = false
          };
          this.Text = "Add New User Absence";
        }
      }
    }

    public FSM.Entity.EngineerAbsence.EngineerAbsence CurrentEngineerAbsence
    {
      get
      {
        return this._engineerAbsence;
      }
      set
      {
        this._engineerAbsence = value;
        if (Helper.MakeIntegerValid((object) this._engineerAbsence?.EngineerAbsenceID) > 0 && this.AbsenceID > 0)
        {
          this.LoadEngineerAbsence();
          this.Text = "Edit Engineer Absence";
        }
        else
        {
          this._engineerAbsence = new FSM.Entity.EngineerAbsence.EngineerAbsence()
          {
            Exists = false
          };
          this.Text = "Add New Engineer Absence";
        }
      }
    }

    public object LoadedItem
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public void LoadForm(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }

    private void LoadEngineer()
    {
      this.LoadEngineerComboBox();
      this.LoadEngineerAbsencestypeComboBox();
      this.gbAbsence.Text = "Engineer Absence";
      this.gpRecurring.Text = "Engineer Recurring Absence";
      this.lblUser.Text = "Engineer";
      this.lblRecurringUser.Text = "Engineer";
      this.CurrentEngineerAbsence = App.DB.EngineerAbsence.EngineerAbsence_Get(this.AbsenceID);
    }

    private void LoadUser()
    {
      this.LoadUserComboBox();
      this.LoadUserAbsencestypeComboBox();
      this.CurrentUserAbsence = App.DB.UserAbsence.UserAbsence_Get(this.AbsenceID);
    }

    private void LoadUserComboBox()
    {
      DataTable dataTable = new DataTable();
      DataTable table = App.DB.User.GetAll().Table;
      DataRow row = table.NewRow();
      row["Fullname"] = (object) "-- Please Select --";
      row["UserID"] = (object) 0;
      table.Rows.InsertAt(row, 0);
      table.AcceptChanges();
      this.cboUsers.DataSource = (object) table;
      this.cboUsers.DisplayMember = "Fullname";
      this.cboUsers.ValueMember = "UserID";
      this.cboRecurringUser.DataSource = (object) table;
      this.cboRecurringUser.DisplayMember = "Fullname";
      this.cboRecurringUser.ValueMember = "UserID";
    }

    private void LoadEngineerComboBox()
    {
      DataTable dataTable = new DataTable();
      DataTable table = App.DB.Engineer.Engineer_GetAll().Table;
      DataRow row = table.NewRow();
      row["Name"] = (object) "-- Please Select --";
      row["EngineerID"] = (object) 0;
      table.Rows.InsertAt(row, 0);
      table.AcceptChanges();
      this.cboUsers.DataSource = (object) table;
      this.cboUsers.DisplayMember = "Name";
      this.cboUsers.ValueMember = "EngineerID";
      this.cboRecurringUser.DataSource = (object) table;
      this.cboRecurringUser.DisplayMember = "Name";
      this.cboRecurringUser.ValueMember = "EngineerID";
    }

    private void LoadUserAbsencestypeComboBox()
    {
      DataTable dataTable = new DataTable();
      DataTable all = App.DB.UserAbsence.UserAbsenceTypes_GetAll();
      DataRow row = all.NewRow();
      row["Description"] = (object) "-- Please Select --";
      row["UserAbsenceTypeID"] = (object) 0;
      all.Rows.InsertAt(row, 0);
      all.AcceptChanges();
      this.cboType.DataSource = (object) all;
      this.cboType.DisplayMember = "Description";
      this.cboType.ValueMember = "UserAbsenceTypeID";
      this.cboRecurringType.DataSource = (object) all;
      this.cboRecurringType.DisplayMember = "Description";
      this.cboRecurringType.ValueMember = "UserAbsenceTypeID";
    }

    private void LoadEngineerAbsencestypeComboBox()
    {
      DataTable dataTable = new DataTable();
      DataTable all = App.DB.EngineerAbsence.EngineerAbsenceTypes_GetAll();
      DataRow row = all.NewRow();
      row["Description"] = (object) "-- Please Select --";
      row["EngineerAbsenceTypeID"] = (object) 0;
      all.Rows.InsertAt(row, 0);
      all.AcceptChanges();
      this.cboType.DataSource = (object) all;
      this.cboType.DisplayMember = "Description";
      this.cboType.ValueMember = "EngineerAbsenceTypeID";
      this.cboRecurringType.DataSource = (object) all;
      this.cboRecurringType.DisplayMember = "Description";
      this.cboRecurringType.ValueMember = "EngineerAbsenceTypeID";
    }

    private void LoadUserAbsence()
    {
      this.txtComments.Text = this.CurrentUserAbsence.Comments;
      this.dtFrom.Value = this.CurrentUserAbsence.DateFrom;
      this.dtTo.Value = this.CurrentUserAbsence.DateTo;
      this.cboUsers.SelectedValue = (object) this.CurrentUserAbsence.UserID;
      this.cboType.SelectedValue = (object) this.CurrentUserAbsence.AbsenceTypeID;
      this.txtStartTimeHours.Text = Strings.Format((object) this.CurrentUserAbsence.DateFrom.Hour, "00");
      this.txtStartTimeMinutes.Text = Strings.Format((object) this.CurrentUserAbsence.DateFrom.Minute, "00");
      this.txtEndTimeHours.Text = Strings.Format((object) this.CurrentUserAbsence.DateTo.Hour, "00");
      this.txtEndTimeMinutes.Text = Strings.Format((object) this.CurrentUserAbsence.DateTo.Minute, "00");
    }

    private void LoadEngineerAbsence()
    {
      this.txtComments.Text = this.CurrentEngineerAbsence.Comments;
      this.dtFrom.Value = this.CurrentEngineerAbsence.DateFrom;
      this.dtTo.Value = this.CurrentEngineerAbsence.DateTo;
      this.cboUsers.SelectedValue = (object) this.CurrentEngineerAbsence.EngineerID;
      this.cboType.SelectedValue = (object) this.CurrentEngineerAbsence.AbsenceTypeID;
      this.txtStartTimeHours.Text = Strings.Format((object) this.CurrentEngineerAbsence.DateFrom.Hour, "00");
      this.txtStartTimeMinutes.Text = Strings.Format((object) this.CurrentEngineerAbsence.DateFrom.Minute, "00");
      this.txtEndTimeHours.Text = Strings.Format((object) this.CurrentEngineerAbsence.DateTo.Hour, "00");
      this.txtEndTimeMinutes.Text = Strings.Format((object) this.CurrentEngineerAbsence.DateTo.Minute, "00");
    }

    public void Populate(int ID = 0)
    {
      throw new NotImplementedException();
    }

    public bool Save()
    {
      bool flag;
      if (this.tcMain.SelectedIndex == 0)
      {
        try
        {
          if (this.ValidateForm(this.txtStartTimeHours.Text, this.txtStartTimeMinutes.Text, this.txtEndTimeHours.Text, this.txtEndTimeMinutes.Text, false))
          {
            int year1 = this.dtFrom.Value.Year;
            DateTime dateTime1 = this.dtFrom.Value;
            int month1 = dateTime1.Month;
            dateTime1 = this.dtFrom.Value;
            int day1 = dateTime1.Day;
            int integer1 = Conversions.ToInteger(this.txtStartTimeHours.Text);
            int integer2 = Conversions.ToInteger(this.txtStartTimeMinutes.Text);
            DateTime dateTime2 = new DateTime(year1, month1, day1, integer1, integer2, 0);
            DateTime dateTime3 = this.dtTo.Value;
            int year2 = dateTime3.Year;
            dateTime3 = this.dtTo.Value;
            int month2 = dateTime3.Month;
            dateTime3 = this.dtTo.Value;
            int day2 = dateTime3.Day;
            int integer3 = Conversions.ToInteger(this.txtEndTimeHours.Text);
            int integer4 = Conversions.ToInteger(this.txtEndTimeMinutes.Text);
            DateTime dateTime4 = new DateTime(year2, month2, day2, integer3, integer4, 0);
            if (this.UserType == Enums.UserType.User)
            {
              UserAbsenceValidator absenceValidator = new UserAbsenceValidator();
              FSM.Entity.UserAbsence.UserAbsence currentUserAbsence = this.CurrentUserAbsence;
              currentUserAbsence.IgnoreExceptionsOnSetMethods = false;
              currentUserAbsence.SetComments = (object) this.txtComments.Text;
              currentUserAbsence.SetAbsenceTypeID = RuntimeHelpers.GetObjectValue(this.cboType.SelectedValue);
              currentUserAbsence.SetUserID = RuntimeHelpers.GetObjectValue(this.cboUsers.SelectedValue);
              currentUserAbsence.DateFrom = dateTime2;
              currentUserAbsence.DateTo = dateTime4;
              absenceValidator.Validate(this.CurrentUserAbsence);
              if (this.CurrentUserAbsence.Exists)
              {
                App.DB.UserAbsence.Update(this.CurrentUserAbsence);
                this.CurrentUserAbsence = this.CurrentUserAbsence;
              }
              else
                this.CurrentUserAbsence = App.DB.UserAbsence.Insert(this.CurrentUserAbsence);
            }
            else if (this.UserType == Enums.UserType.Engineer)
            {
              EngineerAbsenceValidator absenceValidator = new EngineerAbsenceValidator();
              FSM.Entity.EngineerAbsence.EngineerAbsence currentEngineerAbsence = this.CurrentEngineerAbsence;
              currentEngineerAbsence.IgnoreExceptionsOnSetMethods = false;
              currentEngineerAbsence.SetComments = (object) this.txtComments.Text;
              currentEngineerAbsence.SetAbsenceTypeID = RuntimeHelpers.GetObjectValue(this.cboType.SelectedValue);
              currentEngineerAbsence.SetEngineerID = RuntimeHelpers.GetObjectValue(this.cboUsers.SelectedValue);
              currentEngineerAbsence.DateFrom = dateTime2;
              currentEngineerAbsence.DateTo = dateTime4;
              absenceValidator.Validate(this.CurrentEngineerAbsence);
              if (this.CurrentEngineerAbsence.Exists)
              {
                App.DB.EngineerAbsence.Update(this.CurrentEngineerAbsence);
                this.CurrentEngineerAbsence = this.CurrentEngineerAbsence;
              }
              else
                this.CurrentEngineerAbsence = App.DB.EngineerAbsence.Insert(this.CurrentEngineerAbsence);
            }
            this.Dispose();
            int num = (int) MessageBox.Show("Absence has been updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            flag = true;
          }
          else
            flag = false;
        }
        catch (ValidationException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          int num = (int) MessageBox.Show(string.Format("Please correct the following errors:{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
          ProjectData.ClearProjectError();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
      else if (this.tcMain.SelectedIndex == 1)
      {
        try
        {
          if (this.ValidateForm(this.txtRecurringTimeFromHours.Text, this.txtRecurringTimeFromMins.Text, this.txtRecurringTimeToHours.Text, this.txtRecurringTimeToMins.Text, true))
          {
            int year1 = this.dtRecurringDateFrom.Value.Year;
            DateTime dateTime1 = this.dtRecurringDateFrom.Value;
            int month1 = dateTime1.Month;
            dateTime1 = this.dtRecurringDateFrom.Value;
            int day1 = dateTime1.Day;
            int integer1 = Conversions.ToInteger(this.txtRecurringTimeFromHours.Text);
            int integer2 = Conversions.ToInteger(this.txtRecurringTimeFromMins.Text);
            DateTime Startdate = new DateTime(year1, month1, day1, integer1, integer2, 0);
            DateTime dateTime2 = this.dtRecurringDateTo.Value;
            int year2 = dateTime2.Year;
            dateTime2 = this.dtRecurringDateTo.Value;
            int month2 = dateTime2.Month;
            dateTime2 = this.dtRecurringDateTo.Value;
            int day2 = dateTime2.Day;
            int integer3 = Conversions.ToInteger(this.txtRecurringTimeToHours.Text);
            int integer4 = Conversions.ToInteger(this.txtRecurringTimeToMins.Text);
            DateTime EndDate = new DateTime(year2, month2, day2, integer3, integer4, 0);
            List<DateTime> datesBetween = DateHelper.GetDatesBetween(Startdate, EndDate);
            if (this.UserType == Enums.UserType.User)
            {
              try
              {
                foreach (DateTime dateCheck in datesBetween)
                {
                  if (this.IsDateTicked(dateCheck))
                  {
                    UserAbsenceValidator absenceValidator = new UserAbsenceValidator();
                    FSM.Entity.UserAbsence.UserAbsence currentUserAbsence = this.CurrentUserAbsence;
                    currentUserAbsence.IgnoreExceptionsOnSetMethods = false;
                    currentUserAbsence.SetComments = (object) this.txtRecurringComments.Text;
                    currentUserAbsence.SetAbsenceTypeID = RuntimeHelpers.GetObjectValue(this.cboRecurringType.SelectedValue);
                    currentUserAbsence.SetUserID = RuntimeHelpers.GetObjectValue(this.cboRecurringUser.SelectedValue);
                    currentUserAbsence.DateFrom = new DateTime(dateCheck.Year, dateCheck.Month, dateCheck.Day, Conversions.ToInteger(this.txtRecurringTimeFromHours.Text), Conversions.ToInteger(this.txtRecurringTimeFromMins.Text), 0);
                    currentUserAbsence.DateTo = new DateTime(dateCheck.Year, dateCheck.Month, dateCheck.Day, Conversions.ToInteger(this.txtRecurringTimeToHours.Text), Conversions.ToInteger(this.txtRecurringTimeToMins.Text), 0);
                    absenceValidator.Validate(this.CurrentUserAbsence);
                    this.CurrentUserAbsence = App.DB.UserAbsence.Insert(this.CurrentUserAbsence);
                  }
                }
              }
              finally
              {
                List<DateTime>.Enumerator enumerator;
                enumerator.Dispose();
              }
            }
            else if (this.UserType == Enums.UserType.Engineer)
            {
              try
              {
                foreach (DateTime dateCheck in datesBetween)
                {
                  if (this.IsDateTicked(dateCheck))
                  {
                    EngineerAbsenceValidator absenceValidator = new EngineerAbsenceValidator();
                    FSM.Entity.EngineerAbsence.EngineerAbsence currentEngineerAbsence = this.CurrentEngineerAbsence;
                    currentEngineerAbsence.IgnoreExceptionsOnSetMethods = false;
                    currentEngineerAbsence.SetComments = (object) this.txtRecurringComments.Text;
                    currentEngineerAbsence.SetAbsenceTypeID = RuntimeHelpers.GetObjectValue(this.cboRecurringType.SelectedValue);
                    currentEngineerAbsence.SetEngineerID = RuntimeHelpers.GetObjectValue(this.cboRecurringUser.SelectedValue);
                    currentEngineerAbsence.DateFrom = new DateTime(dateCheck.Year, dateCheck.Month, dateCheck.Day, Conversions.ToInteger(this.txtRecurringTimeFromHours.Text), Conversions.ToInteger(this.txtRecurringTimeFromMins.Text), 0);
                    currentEngineerAbsence.DateTo = new DateTime(dateCheck.Year, dateCheck.Month, dateCheck.Day, Conversions.ToInteger(this.txtRecurringTimeToHours.Text), Conversions.ToInteger(this.txtRecurringTimeToMins.Text), 0);
                    absenceValidator.Validate(this.CurrentEngineerAbsence);
                    this.CurrentEngineerAbsence = App.DB.EngineerAbsence.Insert(this.CurrentEngineerAbsence);
                  }
                }
              }
              finally
              {
                List<DateTime>.Enumerator enumerator;
                enumerator.Dispose();
              }
            }
            this.Dispose();
            int num = (int) MessageBox.Show("Absence has been updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            flag = true;
            goto label_36;
          }
          else
          {
            flag = false;
            goto label_36;
          }
        }
        catch (ValidationException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          int num = (int) MessageBox.Show(string.Format("Please correct the following errors:{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
          ProjectData.ClearProjectError();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num = (int) MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
label_36:
      return flag;
    }

    private bool IsDateTicked(DateTime dateCheck)
    {
      bool flag;
      switch (dateCheck.DayOfWeek)
      {
        case DayOfWeek.Sunday:
          if (this.cbSunday.Checked)
          {
            flag = true;
            goto label_17;
          }
          else
            break;
        case DayOfWeek.Monday:
          if (this.cbMonday.Checked)
          {
            flag = true;
            goto label_17;
          }
          else
            break;
        case DayOfWeek.Tuesday:
          if (this.cbTuesday.Checked)
          {
            flag = true;
            goto label_17;
          }
          else
            break;
        case DayOfWeek.Wednesday:
          if (this.cbWednesday.Checked)
          {
            flag = true;
            goto label_17;
          }
          else
            break;
        case DayOfWeek.Thursday:
          if (this.cbThursday.Checked)
          {
            flag = true;
            goto label_17;
          }
          else
            break;
        case DayOfWeek.Friday:
          if (this.cbFriday.Checked)
          {
            flag = true;
            goto label_17;
          }
          else
            break;
        case DayOfWeek.Saturday:
          if (this.cbSaturday.Checked)
          {
            flag = true;
            goto label_17;
          }
          else
            break;
        default:
          flag = false;
          goto label_17;
      }
label_17:
      return flag;
    }

    private bool ValidateForm(
      string startHour,
      string startMinutes,
      string endHour,
      string endMinutes,
      bool isRecurring)
    {
      bool flag;
      if (!Versioned.IsNumeric((object) startHour) || Conversions.ToDouble(startHour) < 0.0 || Conversions.ToDouble(startHour) > 23.0 || (!Versioned.IsNumeric((object) startMinutes) || Conversions.ToDouble(startMinutes) < 0.0 || Conversions.ToDouble(startMinutes) > 59.0))
      {
        int num = (int) MessageBox.Show("Start time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
        flag = false;
      }
      else if (!Versioned.IsNumeric((object) endHour) || Conversions.ToDouble(endHour) < 0.0 || (Conversions.ToDouble(endHour) > 23.0 || !Versioned.IsNumeric((object) endMinutes)) || Conversions.ToDouble(endMinutes) < 0.0 || Conversions.ToDouble(endMinutes) > 59.0)
      {
        int num = (int) MessageBox.Show("End time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
        flag = false;
      }
      else
      {
        DateTime t1;
        ref DateTime local1 = ref t1;
        int year1 = this.dtFrom.Value.Year;
        int month1 = this.dtFrom.Value.Month;
        DateTime dateTime = this.dtFrom.Value;
        int day1 = dateTime.Day;
        int integer1 = Conversions.ToInteger(startHour);
        int integer2 = Conversions.ToInteger(startMinutes);
        local1 = new DateTime(year1, month1, day1, integer1, integer2, 0);
        DateTime t2;
        ref DateTime local2 = ref t2;
        dateTime = this.dtTo.Value;
        int year2 = dateTime.Year;
        dateTime = this.dtTo.Value;
        int month2 = dateTime.Month;
        dateTime = this.dtTo.Value;
        int day2 = dateTime.Day;
        int integer3 = Conversions.ToInteger(endHour);
        int integer4 = Conversions.ToInteger(endMinutes);
        local2 = new DateTime(year2, month2, day2, integer3, integer4, 0);
        if (DateTime.Compare(t1, t2) > 0)
        {
          int num = (int) MessageBox.Show("End date can not be before start date!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
          flag = false;
        }
        else
        {
          if (isRecurring)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.cboRecurringType.SelectedValue, (object) 0, false))
            {
              int num = (int) MessageBox.Show("Please select an absence type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
              flag = false;
              goto label_18;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.cboRecurringUser.SelectedValue, (object) 0, false))
            {
              int num = (int) MessageBox.Show("Please select a user!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
              flag = false;
              goto label_18;
            }
            else if (!this.cbMonday.Checked & !this.cbTuesday.Checked & !this.cbWednesday.Checked & !this.cbThursday.Checked & !this.cbFriday.Checked & !this.cbSaturday.Checked & !this.cbSunday.Checked)
            {
              int num = (int) MessageBox.Show("No checkboxes ticked!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
              goto label_18;
            }
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.cboType.SelectedValue, (object) 0, false))
          {
            int num = (int) MessageBox.Show("Please select an absence type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            flag = false;
            goto label_18;
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.cboUsers.SelectedValue, (object) 0, false))
          {
            int num = (int) MessageBox.Show("Please select a user!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            flag = false;
            goto label_18;
          }
          flag = true;
        }
      }
label_18:
      return flag;
    }

    private void txtEndTimeHours_TextChanged(object sender, EventArgs e)
    {
      TextBox[] array = new TextBox[4]
      {
        this.txtStartTimeHours,
        this.txtStartTimeMinutes,
        this.txtEndTimeHours,
        this.txtEndTimeMinutes
      };
      TextBox textBox = (TextBox) sender;
      if (textBox.Text.Length >= 2 && Array.IndexOf<TextBox>(array, textBox) < checked (array.Length - 1))
      {
        array[checked (Array.IndexOf<TextBox>(array, textBox) + 1)].Focus();
      }
      else
      {
        if (textBox.Text.Length != 0 || checked (Array.IndexOf<TextBox>(array, textBox) - 1) < 0)
          return;
        array[checked (Array.IndexOf<TextBox>(array, textBox) - 1)].Focus();
      }
    }

    private void txtEndTimeRecurringHours_TextChanged(object sender, EventArgs e)
    {
      TextBox[] array = new TextBox[4]
      {
        this.txtRecurringTimeFromHours,
        this.txtRecurringTimeFromMins,
        this.txtRecurringTimeToHours,
        this.txtRecurringTimeToMins
      };
      TextBox textBox = (TextBox) sender;
      if (textBox.Text.Length >= 2 && Array.IndexOf<TextBox>(array, textBox) < checked (array.Length - 1))
      {
        array[checked (Array.IndexOf<TextBox>(array, textBox) + 1)].Focus();
      }
      else
      {
        if (textBox.Text.Length != 0 || checked (Array.IndexOf<TextBox>(array, textBox) - 1) < 0)
          return;
        array[checked (Array.IndexOf<TextBox>(array, textBox) - 1)].Focus();
      }
    }
  }
}
